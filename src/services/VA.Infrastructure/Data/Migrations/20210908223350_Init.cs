using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace VA.Infrastructure.Data.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "asp_net_roles",
                columns: table => new
                {
                    id = table.Column<string>(type: "varchar(900)", unicode: false, nullable: false),
                    name = table.Column<string>(type: "varchar(256)", unicode: false, maxLength: 256, nullable: true),
                    normalized_name = table.Column<string>(type: "varchar(256)", unicode: false, maxLength: 256, nullable: true),
                    concurrency_stamp = table.Column<string>(type: "varchar(max)", unicode: false, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_asp_net_roles", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "asp_net_users",
                columns: table => new
                {
                    id = table.Column<string>(type: "varchar(900)", unicode: false, nullable: false),
                    user_name = table.Column<string>(type: "varchar(256)", unicode: false, maxLength: 256, nullable: true),
                    normalized_user_name = table.Column<string>(type: "varchar(256)", unicode: false, maxLength: 256, nullable: true),
                    email = table.Column<string>(type: "varchar(256)", unicode: false, maxLength: 256, nullable: true),
                    normalized_email = table.Column<string>(type: "varchar(256)", unicode: false, maxLength: 256, nullable: true),
                    email_confirmed = table.Column<bool>(type: "bit", nullable: false),
                    password_hash = table.Column<string>(type: "varchar(max)", unicode: false, nullable: true),
                    security_stamp = table.Column<string>(type: "varchar(max)", unicode: false, nullable: true),
                    concurrency_stamp = table.Column<string>(type: "varchar(max)", unicode: false, nullable: true),
                    phone_number = table.Column<string>(type: "varchar(max)", unicode: false, nullable: true),
                    phone_number_confirmed = table.Column<bool>(type: "bit", nullable: false),
                    two_factor_enabled = table.Column<bool>(type: "bit", nullable: false),
                    lockout_end = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    lockout_enabled = table.Column<bool>(type: "bit", nullable: false),
                    access_failed_count = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_asp_net_users", x => x.id);
                });

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
                name: "refresh_tokens",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    username = table.Column<string>(type: "varchar(max)", unicode: false, nullable: true),
                    token = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    expiration_date = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_refresh_tokens", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "security_keys",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    parameters = table.Column<string>(type: "varchar(max)", unicode: false, nullable: true),
                    key_id = table.Column<string>(type: "varchar(max)", unicode: false, nullable: true),
                    type = table.Column<string>(type: "varchar(max)", unicode: false, nullable: true),
                    jws_algorithm = table.Column<string>(type: "varchar(max)", unicode: false, nullable: true),
                    jwe_algorithm = table.Column<string>(type: "varchar(max)", unicode: false, nullable: true),
                    jwe_encryption = table.Column<string>(type: "varchar(max)", unicode: false, nullable: true),
                    creation_date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    jwk_type = table.Column<int>(type: "int", nullable: false),
                    is_revoked = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_security_keys", x => x.id);
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
                name: "asp_net_role_claims",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    role_id = table.Column<string>(type: "varchar(900)", unicode: false, nullable: false),
                    claim_type = table.Column<string>(type: "varchar(max)", unicode: false, nullable: true),
                    claim_value = table.Column<string>(type: "varchar(max)", unicode: false, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_asp_net_role_claims", x => x.id);
                    table.ForeignKey(
                        name: "fk_asp_net_role_claims_asp_net_roles_role_id",
                        column: x => x.role_id,
                        principalTable: "asp_net_roles",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "asp_net_user_claims",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    user_id = table.Column<string>(type: "varchar(900)", unicode: false, nullable: false),
                    claim_type = table.Column<string>(type: "varchar(max)", unicode: false, nullable: true),
                    claim_value = table.Column<string>(type: "varchar(max)", unicode: false, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_asp_net_user_claims", x => x.id);
                    table.ForeignKey(
                        name: "fk_asp_net_user_claims_asp_net_users_user_id",
                        column: x => x.user_id,
                        principalTable: "asp_net_users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "asp_net_user_logins",
                columns: table => new
                {
                    login_provider = table.Column<string>(type: "varchar(900)", unicode: false, nullable: false),
                    provider_key = table.Column<string>(type: "varchar(900)", unicode: false, nullable: false),
                    provider_display_name = table.Column<string>(type: "varchar(max)", unicode: false, nullable: true),
                    user_id = table.Column<string>(type: "varchar(900)", unicode: false, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_asp_net_user_logins", x => new { x.login_provider, x.provider_key });
                    table.ForeignKey(
                        name: "fk_asp_net_user_logins_asp_net_users_user_id",
                        column: x => x.user_id,
                        principalTable: "asp_net_users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "asp_net_user_roles",
                columns: table => new
                {
                    user_id = table.Column<string>(type: "varchar(900)", unicode: false, nullable: false),
                    role_id = table.Column<string>(type: "varchar(900)", unicode: false, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_asp_net_user_roles", x => new { x.user_id, x.role_id });
                    table.ForeignKey(
                        name: "fk_asp_net_user_roles_asp_net_roles_role_id",
                        column: x => x.role_id,
                        principalTable: "asp_net_roles",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "fk_asp_net_user_roles_asp_net_users_user_id",
                        column: x => x.user_id,
                        principalTable: "asp_net_users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "asp_net_user_tokens",
                columns: table => new
                {
                    user_id = table.Column<string>(type: "varchar(900)", unicode: false, nullable: false),
                    login_provider = table.Column<string>(type: "varchar(900)", unicode: false, nullable: false),
                    name = table.Column<string>(type: "varchar(900)", unicode: false, nullable: false),
                    value = table.Column<string>(type: "varchar(max)", unicode: false, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_asp_net_user_tokens", x => new { x.user_id, x.login_provider, x.name });
                    table.ForeignKey(
                        name: "fk_asp_net_user_tokens_asp_net_users_user_id",
                        column: x => x.user_id,
                        principalTable: "asp_net_users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
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
                        onDelete: ReferentialAction.Restrict);
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
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "fk_perfil_usuario_usuario_id",
                        column: x => x.usuario_id,
                        principalTable: "usuario",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
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
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "fk_vaga_senioridade_senioridade_id",
                        column: x => x.senioridade_id,
                        principalTable: "senioridade",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
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
                        onDelete: ReferentialAction.Restrict);
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
                        onDelete: ReferentialAction.Restrict);
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
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "fk_pagina_perfil_perfil_id",
                        column: x => x.perfil_id,
                        principalTable: "perfil",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
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
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "fk_candidato_vaga_vaga_id",
                        column: x => x.vaga_id,
                        principalTable: "vaga",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
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
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "fk_like_vaga_vaga_id",
                        column: x => x.vaga_id,
                        principalTable: "vaga",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "ix_asp_net_role_claims_role_id",
                table: "asp_net_role_claims",
                column: "role_id");

            migrationBuilder.CreateIndex(
                name: "role_name_index",
                table: "asp_net_roles",
                column: "normalized_name",
                unique: true,
                filter: "[normalized_name] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "ix_asp_net_user_claims_user_id",
                table: "asp_net_user_claims",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "ix_asp_net_user_logins_user_id",
                table: "asp_net_user_logins",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "ix_asp_net_user_roles_role_id",
                table: "asp_net_user_roles",
                column: "role_id");

            migrationBuilder.CreateIndex(
                name: "email_index",
                table: "asp_net_users",
                column: "normalized_email");

            migrationBuilder.CreateIndex(
                name: "user_name_index",
                table: "asp_net_users",
                column: "normalized_user_name",
                unique: true,
                filter: "[normalized_user_name] IS NOT NULL");

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
                name: "asp_net_role_claims");

            migrationBuilder.DropTable(
                name: "asp_net_user_claims");

            migrationBuilder.DropTable(
                name: "asp_net_user_logins");

            migrationBuilder.DropTable(
                name: "asp_net_user_roles");

            migrationBuilder.DropTable(
                name: "asp_net_user_tokens");

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
                name: "refresh_tokens");

            migrationBuilder.DropTable(
                name: "security_keys");

            migrationBuilder.DropTable(
                name: "asp_net_roles");

            migrationBuilder.DropTable(
                name: "asp_net_users");

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
