using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using JobHub.Context;
using JobHub.Models;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using JobHub.ViewModels;
using Microsoft.AspNetCore.Identity;

namespace JobHub.Controllers
{
    [Authorize]
    public class UsuariosController : Controller
    {
        private readonly IEmailService _emailService;
        private readonly AppDbContext _context;

        public UsuariosController(AppDbContext context, IEmailService emailService)
        {
            _context = context;
            _emailService = emailService;
        }

        // GET: Usuarios
        public async Task<IActionResult> Index()
        {
              return View(await _context.Usuarios.ToListAsync());
        }

        [AllowAnonymous]
        public IActionResult Login()
        {
            return View();
        }

        [AllowAnonymous]
        public IActionResult AccessDenied()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> LoginAsync(Usuario usuario)
        {
            var user = await _context.Usuarios.FirstOrDefaultAsync(u => u.Email == usuario.Email);
            if (user != null)
            {
                if (BCrypt.Net.BCrypt.Verify(usuario.Senha, user.Senha))
                {
                    var claims = new List<Claim>
                    {
                        new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                        new Claim(ClaimTypes.Email, user.Email),
                        new Claim(ClaimTypes.Role, user.Perfil.ToString())
                    };

                    var usuarioIdentity = new ClaimsIdentity(claims, "login");
                    ClaimsPrincipal principal = new ClaimsPrincipal(usuarioIdentity);

                    var props = new AuthenticationProperties
                    {
                        AllowRefresh = true,
                        ExpiresUtc = DateTime.UtcNow.ToLocalTime().AddHours(8),
                        IsPersistent = true
                    };

                    await HttpContext.SignInAsync(principal, props);

                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError("", "Usuário e/ou senha inválidos!");
                    return View();
                }
            }
            else
            {
                ModelState.AddModelError("", "Usuário e/ou senha inválidos!");
            }
            return View();
        }

        [AllowAnonymous]
        public async Task<IActionResult> LogoutAsync()
        {
            await HttpContext.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }

        // GET: Usuarios/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Usuarios == null)
            {
                return NotFound();
            }

            var usuario = await _context.Usuarios
                .FirstOrDefaultAsync(m => m.Id == id);
            if (usuario == null)
            {
                return NotFound();
            }

            return View(usuario);
        }

        // GET: Usuarios/Create

        [AllowAnonymous]
        public IActionResult Create()
        {
            var model = new RegisterViewModel();
            return View(model);
        }

        // POST: Usuarios/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [AllowAnonymous]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                if (model.Perfil == Perfil.Candidato)
                {
                    var candidato = new Candidato
                    {
                        Nome = model.Candidato.Nome,
                        Email = model.Email,
                        Senha = BCrypt.Net.BCrypt.HashPassword(model.Senha),
                        Perfil = model.Perfil
                    };
                    _context.Add(candidato);
                }
                else
                {
                    var empresa = new Empresa
                    {
                        NomeDaEmpresa = model.Empresa.NomeDaEmpresa,
                        Cnpj = model.Empresa.Cnpj,
                        Email = model.Email,
                        Senha = BCrypt.Net.BCrypt.HashPassword(model.Senha),
                        Perfil = model.Perfil
                    };
                    _context.Add(empresa);
                }
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }

        // GET: Usuarios/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Usuarios == null)
            {
                return NotFound();
            }

            var usuario = await _context.Usuarios.FindAsync(id);
            if (usuario == null)
            {
                return NotFound();
            }
            return View(usuario);
        }

        // POST: Usuarios/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nome,Email,Senha")] Usuario usuario)
        {
            if (id != usuario.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    usuario.Senha = BCrypt.Net.BCrypt.HashPassword(usuario.Senha);
                    _context.Update(usuario);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UsuarioExists(usuario.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(usuario);
        }

        // GET: Usuarios/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Usuarios == null)
            {
                return NotFound();
            }

            var usuario = await _context.Usuarios
                .FirstOrDefaultAsync(m => m.Id == id);
            if (usuario == null)
            {
                return NotFound();
            }

            return View(usuario);
        }

        // POST: Usuarios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Usuarios == null)
            {
                return Problem("Entity set 'AppDbContext.Usuarios'  is null.");
            }
            var usuario = await _context.Usuarios.FindAsync(id);
            if (usuario != null)
            {
                _context.Usuarios.Remove(usuario);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        [AllowAnonymous]
        public IActionResult PerfilCandidato1()
        {
            // Obtenha o ID do usuário atualmente autenticado
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            if (userId == null)
            {
                return NotFound(); // Ou redirecione para uma página de erro
            }

            // Consulte o banco de dados para obter o candidato correspondente ao ID do usuário
            var candidato = _context.Usuarios.OfType<Candidato>().FirstOrDefault(u => u.Id.ToString() == userId);

            if (candidato == null)
            {
                return NotFound(); // Ou redirecione para uma página de erro
            }

            return View(candidato);
        }




        private bool UsuarioExists(int id)
        {
          return _context.Usuarios.Any(e => e.Id == id);
        }

        [AllowAnonymous]
        public IActionResult RedefinirSenha() 
        { 
            return View(); 
        }

        [AllowAnonymous]
        public IActionResult RedefinicaoDeSenhaEnviada()
        {
            return View();
        }


        [AllowAnonymous]
        public IActionResult TrocarSenha(string token)
        {
            if (string.IsNullOrEmpty(token))
                return BadRequest("Token inválido");

            var model = new TrocarSenhaViewModel { Token = token };
            return View(model);
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> TrocarSenha(TrocarSenhaViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            var user = await _context.Usuarios.FirstOrDefaultAsync(u => u.Email == model.Email);
            if (user == null)
                return BadRequest("Usuário não encontrado");

            // Verificar se o token é válido (necessário implementar a lógica de verificação)
            if (user.Token != model.Token ||
                user.DataExpiracaoToken == null ||
                user.DataExpiracaoToken < DateTime.UtcNow)
            {
                // Token inválido ou expirado
                return BadRequest("Token de redefinição de senha inválido ou expirado.");
            }

            // Se o token for válido, redefina a senha
            user.Senha = BCrypt.Net.BCrypt.HashPassword(model.NovaSenha);
            user.Token = null;
            user.DataExpiracaoToken = null;

            _context.Update(user);
            await _context.SaveChangesAsync();

            // Redirecionar para a página de login ou outra página de confirmação
            return RedirectToAction("Login");
        }


        [HttpPost]
        [AllowAnonymous]

        public async Task<IActionResult> EnviarLinkParaRedefinirSenha(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
            {
                // Adicione uma mensagem de erro ou lógica conforme necessário
                return View();
            }

            var user = await _context.Usuarios.FirstOrDefaultAsync(u => u.Email == email);

            // Gerar um token de redefinição de senha simples (não seguro)
            var token = Guid.NewGuid().ToString(); // Exemplo simples. Use um método mais seguro.

            // Salvar o token no banco de dados associado ao usuário (necessário implementar)
            user.Token = token;
            user.DataExpiracaoToken = DateTime.UtcNow.AddHours(24); // Expira em 24 horas

            // Salvar as alterações no banco de dados
            _context.Update(user);
            await _context.SaveChangesAsync();

            var callbackUrl = Url.Action(
                "TrocarSenha", // Nome do método de ação para redefinir a senha
                "Usuarios", // Nome do controlador onde o método de ação está localizado
                new { token = token }, // Parâmetros
                protocol: HttpContext.Request.Scheme);

            // Enviar email
            var emailService = new EmailService(); // Inicializar corretamente de acordo com sua configuração
            await _emailService.SendEmailAsync(
                email,
                "Redefinir Senha",
                $"Por favor, redefina sua senha clicando aqui: <a href='{callbackUrl}'>link</a>");

            // Redirecionar para a página de confirmação ou voltar para a página de login
            return RedirectToAction("RedefinicaoDeSenhaEnviada");
        }


    }
}
