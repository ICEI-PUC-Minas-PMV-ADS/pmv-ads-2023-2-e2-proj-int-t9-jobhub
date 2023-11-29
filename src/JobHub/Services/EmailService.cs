using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

public interface IEmailService
{
    Task SendEmailAsync(string email, string subject, string message);
}

public class EmailService : IEmailService
{
    public async Task SendEmailAsync(string email, string subject, string message)
    {
        var smtpClient = new SmtpClient("smtp.gmail.com") // Substitua com seu servidor SMTP
        {
            Port = 587, // Substitua com a porta do seu servidor SMTP
            Credentials = new NetworkCredential("animelistproject0@gmail.com", "exrdxnkcnqmpzdxq"), // Substitua com suas credenciais
            EnableSsl = true,
        };

        var mailMessage = new MailMessage
        {
            From = new MailAddress("animelistproject0@gmail.com"), // Substitua com o endereço de email do remetente
            Subject = subject,
            Body = message,
            IsBodyHtml = true,
        };
        mailMessage.To.Add(email);

        await smtpClient.SendMailAsync(mailMessage);
    }
}
