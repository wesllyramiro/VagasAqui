using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace VA.Infrastructure.Data.Migrations
{
    public partial class primeiromigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "estado",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nome = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
                    usuario_criacao = table.Column<int>(type: "int", nullable: true),
                    cadastrado_em = table.Column<DateTime>(type: "datetime2", nullable: true),
                    usuario_alteracao = table.Column<int>(type: "int", nullable: true),
                    alterado_em = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_estado", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "senioridade",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nome = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
                    usuario_criacao = table.Column<int>(type: "int", nullable: true),
                    cadastrado_em = table.Column<DateTime>(type: "datetime2", nullable: true),
                    usuario_alteracao = table.Column<int>(type: "int", nullable: true),
                    alterado_em = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_senioridade", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "usuario",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    email = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
                    senha = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    usuario_criacao = table.Column<int>(type: "int", nullable: true),
                    cadastrado_em = table.Column<DateTime>(type: "datetime2", nullable: true),
                    usuario_alteracao = table.Column<int>(type: "int", nullable: true),
                    alterado_em = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_usuario", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "cidade",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nome = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
                    estado_id = table.Column<int>(type: "int", nullable: false),
                    usuario_criacao = table.Column<int>(type: "int", nullable: true),
                    cadastrado_em = table.Column<DateTime>(type: "datetime2", nullable: true),
                    usuario_alteracao = table.Column<int>(type: "int", nullable: true),
                    alterado_em = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_cidade", x => x.id);
                    table.ForeignKey(
                        name: "fk_cidade_estado_estado_id",
                        column: x => x.estado_id,
                        principalTable: "estado",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "empresa",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nome = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
                    cidade_id = table.Column<int>(type: "int", nullable: false),
                    usuario_criacao = table.Column<int>(type: "int", nullable: true),
                    cadastrado_em = table.Column<DateTime>(type: "datetime2", nullable: true),
                    usuario_alteracao = table.Column<int>(type: "int", nullable: true),
                    alterado_em = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_empresa", x => x.id);
                    table.ForeignKey(
                        name: "fk_empresa_cidade_cidade_id",
                        column: x => x.cidade_id,
                        principalTable: "cidade",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "perfil",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nome = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    curriculo = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    ddd = table.Column<string>(type: "varchar(3)", unicode: false, maxLength: 3, nullable: false),
                    telefone = table.Column<string>(type: "varchar(11)", unicode: false, maxLength: 11, nullable: false),
                    usuario_id = table.Column<int>(type: "int", nullable: false),
                    cidade_id = table.Column<int>(type: "int", nullable: false),
                    usuario_criacao = table.Column<int>(type: "int", nullable: true),
                    cadastrado_em = table.Column<DateTime>(type: "datetime2", nullable: true),
                    usuario_alteracao = table.Column<int>(type: "int", nullable: true),
                    alterado_em = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_perfil", x => x.id);
                    table.ForeignKey(
                        name: "fk_perfil_cidade_cidade_id",
                        column: x => x.cidade_id,
                        principalTable: "cidade",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_perfil_usuario_usuario_id",
                        column: x => x.usuario_id,
                        principalTable: "usuario",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "vaga",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    titulo = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    descricao = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    ativo = table.Column<bool>(type: "bit", nullable: false),
                    empresa_id = table.Column<int>(type: "int", nullable: false),
                    senioridade_id = table.Column<int>(type: "int", nullable: false),
                    usuario_criacao = table.Column<int>(type: "int", nullable: true),
                    cadastrado_em = table.Column<DateTime>(type: "datetime2", nullable: true),
                    usuario_alteracao = table.Column<int>(type: "int", nullable: true),
                    alterado_em = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_vaga", x => x.id);
                    table.ForeignKey(
                        name: "fk_vaga_empresa_empresa_id",
                        column: x => x.empresa_id,
                        principalTable: "empresa",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_vaga_senioridade_senioridade_id",
                        column: x => x.senioridade_id,
                        principalTable: "senioridade",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "experiencia",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nome = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
                    descricao = table.Column<string>(type: "varchar(300)", unicode: false, maxLength: 300, nullable: false),
                    data_inicio = table.Column<DateTime>(type: "datetime2", nullable: false),
                    data_fim = table.Column<DateTime>(type: "datetime2", nullable: false),
                    perfil_id = table.Column<int>(type: "int", nullable: false),
                    usuario_criacao = table.Column<int>(type: "int", nullable: true),
                    cadastrado_em = table.Column<DateTime>(type: "datetime2", nullable: true),
                    usuario_alteracao = table.Column<int>(type: "int", nullable: true),
                    alterado_em = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_experiencia", x => x.id);
                    table.ForeignKey(
                        name: "fk_experiencia_perfil_perfil_id",
                        column: x => x.perfil_id,
                        principalTable: "perfil",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "habilidade",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nome = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
                    perfil_id = table.Column<int>(type: "int", nullable: false),
                    usuario_criacao = table.Column<int>(type: "int", nullable: true),
                    cadastrado_em = table.Column<DateTime>(type: "datetime2", nullable: true),
                    usuario_alteracao = table.Column<int>(type: "int", nullable: true),
                    alterado_em = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_habilidade", x => x.id);
                    table.ForeignKey(
                        name: "fk_habilidade_perfil_perfil_id",
                        column: x => x.perfil_id,
                        principalTable: "perfil",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "pagina",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    empresa_id = table.Column<int>(type: "int", nullable: false),
                    perfil_id = table.Column<int>(type: "int", nullable: false),
                    usuario_criacao = table.Column<int>(type: "int", nullable: true),
                    cadastrado_em = table.Column<DateTime>(type: "datetime2", nullable: true),
                    usuario_alteracao = table.Column<int>(type: "int", nullable: true),
                    alterado_em = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_pagina", x => x.id);
                    table.ForeignKey(
                        name: "fk_pagina_empresa_empresa_id",
                        column: x => x.empresa_id,
                        principalTable: "empresa",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_pagina_perfil_perfil_id",
                        column: x => x.perfil_id,
                        principalTable: "perfil",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "candidato",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    perfil_id = table.Column<int>(type: "int", nullable: false),
                    vaga_id = table.Column<int>(type: "int", nullable: false),
                    usuario_criacao = table.Column<int>(type: "int", nullable: true),
                    cadastrado_em = table.Column<DateTime>(type: "datetime2", nullable: true),
                    usuario_alteracao = table.Column<int>(type: "int", nullable: true),
                    alterado_em = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_candidato", x => x.id);
                    table.ForeignKey(
                        name: "fk_candidato_perfil_perfil_id",
                        column: x => x.perfil_id,
                        principalTable: "perfil",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_candidato_vaga_vaga_id",
                        column: x => x.vaga_id,
                        principalTable: "vaga",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "like",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    perfil_id = table.Column<int>(type: "int", nullable: false),
                    vaga_id = table.Column<int>(type: "int", nullable: false),
                    usuario_criacao = table.Column<int>(type: "int", nullable: true),
                    cadastrado_em = table.Column<DateTime>(type: "datetime2", nullable: true),
                    usuario_alteracao = table.Column<int>(type: "int", nullable: true),
                    alterado_em = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_like", x => x.id);
                    table.ForeignKey(
                        name: "fk_like_perfil_perfil_id",
                        column: x => x.perfil_id,
                        principalTable: "perfil",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_like_vaga_vaga_id",
                        column: x => x.vaga_id,
                        principalTable: "vaga",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "ix_candidato_perfil_id",
                table: "candidato",
                column: "perfil_id");

            migrationBuilder.CreateIndex(
                name: "ix_candidato_vaga_id",
                table: "candidato",
                column: "vaga_id");

            migrationBuilder.CreateIndex(
                name: "ix_cidade_estado_id",
                table: "cidade",
                column: "estado_id");

            migrationBuilder.CreateIndex(
                name: "ix_empresa_cidade_id",
                table: "empresa",
                column: "cidade_id");

            migrationBuilder.CreateIndex(
                name: "ix_experiencia_perfil_id",
                table: "experiencia",
                column: "perfil_id");

            migrationBuilder.CreateIndex(
                name: "ix_habilidade_perfil_id",
                table: "habilidade",
                column: "perfil_id");

            migrationBuilder.CreateIndex(
                name: "ix_like_perfil_id",
                table: "like",
                column: "perfil_id");

            migrationBuilder.CreateIndex(
                name: "ix_like_vaga_id",
                table: "like",
                column: "vaga_id");

            migrationBuilder.CreateIndex(
                name: "ix_pagina_empresa_id",
                table: "pagina",
                column: "empresa_id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_pagina_perfil_id",
                table: "pagina",
                column: "perfil_id");

            migrationBuilder.CreateIndex(
                name: "ix_perfil_cidade_id",
                table: "perfil",
                column: "cidade_id");

            migrationBuilder.CreateIndex(
                name: "ix_perfil_usuario_id",
                table: "perfil",
                column: "usuario_id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_vaga_empresa_id",
                table: "vaga",
                column: "empresa_id");

            migrationBuilder.CreateIndex(
                name: "ix_vaga_senioridade_id",
                table: "vaga",
                column: "senioridade_id",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "candidato");

            migrationBuilder.DropTable(
                name: "experiencia");

            migrationBuilder.DropTable(
                name: "habilidade");

            migrationBuilder.DropTable(
                name: "like");

            migrationBuilder.DropTable(
                name: "pagina");

            migrationBuilder.DropTable(
                name: "vaga");

            migrationBuilder.DropTable(
                name: "perfil");

            migrationBuilder.DropTable(
                name: "empresa");

            migrationBuilder.DropTable(
                name: "senioridade");

            migrationBuilder.DropTable(
                name: "usuario");

            migrationBuilder.DropTable(
                name: "cidade");

            migrationBuilder.DropTable(
                name: "estado");
        }
    }
}
