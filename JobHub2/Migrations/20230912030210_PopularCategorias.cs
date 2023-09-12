using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JobHub2.Migrations
{
    /// <inheritdoc />
    public partial class PopularCategorias : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT INTO Categorias (Nome, Descricao) VALUES ('Desenvolvedor Full-Stack', 'Desenvolvedor Full-Stack')");
            migrationBuilder.Sql("INSERT INTO Categorias (Nome, Descricao) VALUES ('Desenvolvedor Front-End', 'Desenvolvedor Front-End')");
            migrationBuilder.Sql("INSERT INTO Categorias (Nome, Descricao) VALUES ('Desenvolvedor Back-End', 'Desenvolvedor Back-End')");
            migrationBuilder.Sql("INSERT INTO Categorias (Nome, Descricao) VALUES ('Desenvolvedor Mobile', 'Desenvolvedor Mobile')");
            migrationBuilder.Sql("INSERT INTO Categorias (Nome, Descricao) VALUES ('Desenvolvedor Desktop', 'Desenvolvedor Desktop')");
            migrationBuilder.Sql("INSERT INTO Categorias (Nome, Descricao) VALUES ('Desenvolvedor Web', 'Desenvolvedor Web')");
            migrationBuilder.Sql("INSERT INTO Categorias (Nome, Descricao) VALUES ('Cientista de Dados', 'Cientista de Dados')");
            migrationBuilder.Sql("INSERT INTO Categorias (Nome, Descricao) VALUES ('Analista de Dados', 'Analista de Dados')");
            migrationBuilder.Sql("INSERT INTO Categorias (Nome, Descricao) VALUES ('Machine Learning', 'Machine Learning')");
            migrationBuilder.Sql("INSERT INTO Categorias (Nome, Descricao) VALUES ('Engenheiro de Dados', 'Engenheiro de Dados')");
            migrationBuilder.Sql("INSERT INTO Categorias (Nome, Descricao) VALUES ('Engenheiro de Software', 'Engenheiro de Software')");
            migrationBuilder.Sql("INSERT INTO Categorias (Nome, Descricao) VALUES ('DevOps', 'DevOps')");
            migrationBuilder.Sql("INSERT INTO Categorias (Nome, Descricao) VALUES ('Desenvolvedor de Jogos', 'Desenvolvedor de Jogos')");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FROM Categorias");
        }
    }
}
