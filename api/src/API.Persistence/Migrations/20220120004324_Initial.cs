using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace API.Persistence.Migrations
{
  public partial class Initial : Migration
  {
    protected override void Up(MigrationBuilder migrationBuilder)
    {
      migrationBuilder.CreateTable(
          name: "Atracoes",
          columns: table => new
          {
            Id = table.Column<int>(type: "int", nullable: false)
                  .Annotation("SqlServer:Identity", "1, 1"),
            Nome = table.Column<string>(type: "nvarchar(max)", nullable: true),
            TipoAtracao = table.Column<string>(type: "nvarchar(max)", nullable: true),
            ImagemURL = table.Column<string>(type: "nvarchar(max)", nullable: true),
            Telefone = table.Column<string>(type: "nvarchar(max)", nullable: true),
            Email = table.Column<string>(type: "nvarchar(max)", nullable: true)
          },
          constraints: table =>
          {
            table.PrimaryKey("PK_Atracoes", x => x.Id);
          });

      migrationBuilder.CreateTable(
          name: "Eventos",
          columns: table => new
          {
            Id = table.Column<int>(type: "int", nullable: false)
                  .Annotation("SqlServer:Identity", "1, 1"),
            EventoId = table.Column<int>(type: "int", nullable: false),
            Tema = table.Column<string>(type: "nvarchar(max)", nullable: true),
            Local = table.Column<string>(type: "nvarchar(max)", nullable: true),
            Foto = table.Column<string>(type: "nvarchar(max)", nullable: true),
            QtdPessoas = table.Column<int>(type: "int", nullable: false),
            DataEvento = table.Column<DateTime>(type: "datetime2", nullable: false),
            Telefone = table.Column<string>(type: "nvarchar(max)", nullable: true),
            Email = table.Column<string>(type: "nvarchar(max)", nullable: true)
          },
          constraints: table =>
          {
            table.PrimaryKey("PK_Eventos", x => x.Id);
          });

      migrationBuilder.CreateTable(
          name: "AtracoesEventos",
          columns: table => new
          {
            AtracaoId = table.Column<int>(type: "int", nullable: false),
            EventoId = table.Column<int>(type: "int", nullable: false)
          },
          constraints: table =>
          {
            table.PrimaryKey("PK_AtracoesEventos", x => new { x.EventoId, x.AtracaoId });
            table.ForeignKey(
                      name: "FK_AtracoesEventos_Atracoes_AtracaoId",
                      column: x => x.AtracaoId,
                      principalTable: "Atracoes",
                      principalColumn: "Id",
                      onDelete: ReferentialAction.Cascade);
            table.ForeignKey(
                      name: "FK_AtracoesEventos_Eventos_EventoId",
                      column: x => x.EventoId,
                      principalTable: "Eventos",
                      principalColumn: "Id",
                      onDelete: ReferentialAction.Cascade);
          });

      migrationBuilder.CreateTable(
          name: "Lotes",
          columns: table => new
          {
            Id = table.Column<int>(type: "int", nullable: false)
                  .Annotation("SqlServer:Identity", "1, 1"),
            Nome = table.Column<string>(type: "nvarchar(max)", nullable: true),
            Preco = table.Column<int>(type: "int", nullable: false),
            DataInicio = table.Column<DateTime>(type: "datetime2", nullable: true),
            DataFim = table.Column<DateTime>(type: "datetime2", nullable: true),
            Quantidade = table.Column<int>(type: "int", nullable: false),
            EventoId = table.Column<int>(type: "int", nullable: false)
          },
          constraints: table =>
          {
            table.PrimaryKey("PK_Lotes", x => x.Id);
            table.ForeignKey(
                      name: "FK_Lotes_Eventos_EventoId",
                      column: x => x.EventoId,
                      principalTable: "Eventos",
                      principalColumn: "Id",
                      onDelete: ReferentialAction.Cascade);
          });

      migrationBuilder.CreateTable(
          name: "RedesSociais",
          columns: table => new
          {
            Id = table.Column<int>(type: "int", nullable: false)
                  .Annotation("SqlServer:Identity", "1, 1"),
            Nome = table.Column<string>(type: "nvarchar(max)", nullable: true),
            URL = table.Column<string>(type: "nvarchar(max)", nullable: true),
            EventoId = table.Column<int>(type: "int", nullable: true),
            AtracaoId = table.Column<int>(type: "int", nullable: true)
          },
          constraints: table =>
          {
            table.PrimaryKey("PK_RedesSociais", x => x.Id);
            table.ForeignKey(
                      name: "FK_RedesSociais_Atracoes_AtracaoId",
                      column: x => x.AtracaoId,
                      principalTable: "Atracoes",
                      principalColumn: "Id",
                      onDelete: ReferentialAction.Restrict);
            table.ForeignKey(
                      name: "FK_RedesSociais_Eventos_EventoId",
                      column: x => x.EventoId,
                      principalTable: "Eventos",
                      principalColumn: "Id",
                      onDelete: ReferentialAction.Restrict);
          });

      migrationBuilder.CreateIndex(
          name: "IX_AtracoesEventos_AtracaoId",
          table: "AtracoesEventos",
          column: "AtracaoId");

      migrationBuilder.CreateIndex(
          name: "IX_Lotes_EventoId",
          table: "Lotes",
          column: "EventoId");

      migrationBuilder.CreateIndex(
          name: "IX_RedesSociais_AtracaoId",
          table: "RedesSociais",
          column: "AtracaoId");

      migrationBuilder.CreateIndex(
          name: "IX_RedesSociais_EventoId",
          table: "RedesSociais",
          column: "EventoId");
    }

    protected override void Down(MigrationBuilder migrationBuilder)
    {
      migrationBuilder.DropTable(
          name: "AtracoesEventos");

      migrationBuilder.DropTable(
          name: "Lotes");

      migrationBuilder.DropTable(
          name: "RedesSociais");

      migrationBuilder.DropTable(
          name: "Atracoes");

      migrationBuilder.DropTable(
          name: "Eventos");
    }
  }
}
