IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210906215759_first-migration')
BEGIN
    CREATE TABLE [asp_net_roles] (
        [id] varchar(900) NOT NULL,
        [name] varchar(256) NULL,
        [normalized_name] varchar(256) NULL,
        [concurrency_stamp] varchar(max) NULL,
        CONSTRAINT [pk_asp_net_roles] PRIMARY KEY ([id])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210906215759_first-migration')
BEGIN
    CREATE TABLE [asp_net_users] (
        [id] varchar(900) NOT NULL,
        [user_name] varchar(256) NULL,
        [normalized_user_name] varchar(256) NULL,
        [email] varchar(256) NULL,
        [normalized_email] varchar(256) NULL,
        [email_confirmed] bit NOT NULL,
        [password_hash] varchar(max) NULL,
        [security_stamp] varchar(max) NULL,
        [concurrency_stamp] varchar(max) NULL,
        [phone_number] varchar(max) NULL,
        [phone_number_confirmed] bit NOT NULL,
        [two_factor_enabled] bit NOT NULL,
        [lockout_end] datetimeoffset NULL,
        [lockout_enabled] bit NOT NULL,
        [access_failed_count] int NOT NULL,
        CONSTRAINT [pk_asp_net_users] PRIMARY KEY ([id])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210906215759_first-migration')
BEGIN
    CREATE TABLE [estado] (
        [id] int NOT NULL IDENTITY,
        [nome] varchar(100) NOT NULL,
        [usuario_criacao] int NULL,
        [cadastrado_em] datetime2 NULL,
        [usuario_alteracao] int NULL,
        [alterado_em] datetime2 NULL,
        CONSTRAINT [pk_estado] PRIMARY KEY ([id])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210906215759_first-migration')
BEGIN
    CREATE TABLE [senioridade] (
        [id] int NOT NULL IDENTITY,
        [nome] varchar(100) NOT NULL,
        [usuario_criacao] int NULL,
        [cadastrado_em] datetime2 NULL,
        [usuario_alteracao] int NULL,
        [alterado_em] datetime2 NULL,
        CONSTRAINT [pk_senioridade] PRIMARY KEY ([id])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210906215759_first-migration')
BEGIN
    CREATE TABLE [usuario] (
        [id] int NOT NULL IDENTITY,
        [email] varchar(100) NOT NULL,
        [senha] varchar(50) NOT NULL,
        [usuario_criacao] int NULL,
        [cadastrado_em] datetime2 NULL,
        [usuario_alteracao] int NULL,
        [alterado_em] datetime2 NULL,
        CONSTRAINT [pk_usuario] PRIMARY KEY ([id])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210906215759_first-migration')
BEGIN
    CREATE TABLE [asp_net_role_claims] (
        [id] int NOT NULL IDENTITY,
        [role_id] varchar(900) NOT NULL,
        [claim_type] varchar(max) NULL,
        [claim_value] varchar(max) NULL,
        CONSTRAINT [pk_asp_net_role_claims] PRIMARY KEY ([id]),
        CONSTRAINT [fk_asp_net_role_claims_asp_net_roles_role_id] FOREIGN KEY ([role_id]) REFERENCES [asp_net_roles] ([id]) ON DELETE CASCADE
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210906215759_first-migration')
BEGIN
    CREATE TABLE [asp_net_user_claims] (
        [id] int NOT NULL IDENTITY,
        [user_id] varchar(900) NOT NULL,
        [claim_type] varchar(max) NULL,
        [claim_value] varchar(max) NULL,
        CONSTRAINT [pk_asp_net_user_claims] PRIMARY KEY ([id]),
        CONSTRAINT [fk_asp_net_user_claims_asp_net_users_user_id] FOREIGN KEY ([user_id]) REFERENCES [asp_net_users] ([id]) ON DELETE CASCADE
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210906215759_first-migration')
BEGIN
    CREATE TABLE [asp_net_user_logins] (
        [login_provider] varchar(900) NOT NULL,
        [provider_key] varchar(900) NOT NULL,
        [provider_display_name] varchar(max) NULL,
        [user_id] varchar(900) NOT NULL,
        CONSTRAINT [pk_asp_net_user_logins] PRIMARY KEY ([login_provider], [provider_key]),
        CONSTRAINT [fk_asp_net_user_logins_asp_net_users_user_id] FOREIGN KEY ([user_id]) REFERENCES [asp_net_users] ([id]) ON DELETE CASCADE
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210906215759_first-migration')
BEGIN
    CREATE TABLE [asp_net_user_roles] (
        [user_id] varchar(900) NOT NULL,
        [role_id] varchar(900) NOT NULL,
        CONSTRAINT [pk_asp_net_user_roles] PRIMARY KEY ([user_id], [role_id]),
        CONSTRAINT [fk_asp_net_user_roles_asp_net_roles_role_id] FOREIGN KEY ([role_id]) REFERENCES [asp_net_roles] ([id]) ON DELETE CASCADE,
        CONSTRAINT [fk_asp_net_user_roles_asp_net_users_user_id] FOREIGN KEY ([user_id]) REFERENCES [asp_net_users] ([id]) ON DELETE CASCADE
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210906215759_first-migration')
BEGIN
    CREATE TABLE [asp_net_user_tokens] (
        [user_id] varchar(900) NOT NULL,
        [login_provider] varchar(900) NOT NULL,
        [name] varchar(900) NOT NULL,
        [value] varchar(max) NULL,
        CONSTRAINT [pk_asp_net_user_tokens] PRIMARY KEY ([user_id], [login_provider], [name]),
        CONSTRAINT [fk_asp_net_user_tokens_asp_net_users_user_id] FOREIGN KEY ([user_id]) REFERENCES [asp_net_users] ([id]) ON DELETE CASCADE
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210906215759_first-migration')
BEGIN
    CREATE TABLE [cidade] (
        [id] int NOT NULL IDENTITY,
        [nome] varchar(100) NOT NULL,
        [estado_id] int NOT NULL,
        [usuario_criacao] int NULL,
        [cadastrado_em] datetime2 NULL,
        [usuario_alteracao] int NULL,
        [alterado_em] datetime2 NULL,
        CONSTRAINT [pk_cidade] PRIMARY KEY ([id]),
        CONSTRAINT [fk_cidade_estado_estado_id] FOREIGN KEY ([estado_id]) REFERENCES [estado] ([id]) ON DELETE NO ACTION
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210906215759_first-migration')
BEGIN
    CREATE TABLE [empresa] (
        [id] int NOT NULL IDENTITY,
        [nome] varchar(100) NOT NULL,
        [cidade_id] int NOT NULL,
        [usuario_criacao] int NULL,
        [cadastrado_em] datetime2 NULL,
        [usuario_alteracao] int NULL,
        [alterado_em] datetime2 NULL,
        CONSTRAINT [pk_empresa] PRIMARY KEY ([id]),
        CONSTRAINT [fk_empresa_cidade_cidade_id] FOREIGN KEY ([cidade_id]) REFERENCES [cidade] ([id]) ON DELETE NO ACTION
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210906215759_first-migration')
BEGIN
    CREATE TABLE [perfil] (
        [id] int NOT NULL IDENTITY,
        [nome] varchar(50) NOT NULL,
        [curriculo] varchar(100) NULL,
        [ddd] varchar(3) NOT NULL,
        [telefone] varchar(11) NOT NULL,
        [usuario_id] int NOT NULL,
        [cidade_id] int NOT NULL,
        [usuario_criacao] int NULL,
        [cadastrado_em] datetime2 NULL,
        [usuario_alteracao] int NULL,
        [alterado_em] datetime2 NULL,
        CONSTRAINT [pk_perfil] PRIMARY KEY ([id]),
        CONSTRAINT [fk_perfil_cidade_cidade_id] FOREIGN KEY ([cidade_id]) REFERENCES [cidade] ([id]) ON DELETE NO ACTION,
        CONSTRAINT [fk_perfil_usuario_usuario_id] FOREIGN KEY ([usuario_id]) REFERENCES [usuario] ([id]) ON DELETE NO ACTION
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210906215759_first-migration')
BEGIN
    CREATE TABLE [vaga] (
        [id] int NOT NULL IDENTITY,
        [titulo] varchar(50) NOT NULL,
        [descricao] varchar(50) NOT NULL,
        [ativo] bit NOT NULL,
        [empresa_id] int NOT NULL,
        [senioridade_id] int NOT NULL,
        [usuario_criacao] int NULL,
        [cadastrado_em] datetime2 NULL,
        [usuario_alteracao] int NULL,
        [alterado_em] datetime2 NULL,
        CONSTRAINT [pk_vaga] PRIMARY KEY ([id]),
        CONSTRAINT [fk_vaga_empresa_empresa_id] FOREIGN KEY ([empresa_id]) REFERENCES [empresa] ([id]) ON DELETE NO ACTION,
        CONSTRAINT [fk_vaga_senioridade_senioridade_id] FOREIGN KEY ([senioridade_id]) REFERENCES [senioridade] ([id]) ON DELETE NO ACTION
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210906215759_first-migration')
BEGIN
    CREATE TABLE [experiencia] (
        [id] int NOT NULL IDENTITY,
        [nome] varchar(100) NOT NULL,
        [descricao] varchar(300) NOT NULL,
        [data_inicio] datetime2 NOT NULL,
        [data_fim] datetime2 NOT NULL,
        [perfil_id] int NOT NULL,
        [usuario_criacao] int NULL,
        [cadastrado_em] datetime2 NULL,
        [usuario_alteracao] int NULL,
        [alterado_em] datetime2 NULL,
        CONSTRAINT [pk_experiencia] PRIMARY KEY ([id]),
        CONSTRAINT [fk_experiencia_perfil_perfil_id] FOREIGN KEY ([perfil_id]) REFERENCES [perfil] ([id]) ON DELETE NO ACTION
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210906215759_first-migration')
BEGIN
    CREATE TABLE [habilidade] (
        [id] int NOT NULL IDENTITY,
        [nome] varchar(100) NOT NULL,
        [perfil_id] int NOT NULL,
        [usuario_criacao] int NULL,
        [cadastrado_em] datetime2 NULL,
        [usuario_alteracao] int NULL,
        [alterado_em] datetime2 NULL,
        CONSTRAINT [pk_habilidade] PRIMARY KEY ([id]),
        CONSTRAINT [fk_habilidade_perfil_perfil_id] FOREIGN KEY ([perfil_id]) REFERENCES [perfil] ([id]) ON DELETE NO ACTION
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210906215759_first-migration')
BEGIN
    CREATE TABLE [pagina] (
        [id] int NOT NULL IDENTITY,
        [empresa_id] int NOT NULL,
        [perfil_id] int NOT NULL,
        [usuario_criacao] int NULL,
        [cadastrado_em] datetime2 NULL,
        [usuario_alteracao] int NULL,
        [alterado_em] datetime2 NULL,
        CONSTRAINT [pk_pagina] PRIMARY KEY ([id]),
        CONSTRAINT [fk_pagina_empresa_empresa_id] FOREIGN KEY ([empresa_id]) REFERENCES [empresa] ([id]) ON DELETE NO ACTION,
        CONSTRAINT [fk_pagina_perfil_perfil_id] FOREIGN KEY ([perfil_id]) REFERENCES [perfil] ([id]) ON DELETE NO ACTION
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210906215759_first-migration')
BEGIN
    CREATE TABLE [candidato] (
        [id] int NOT NULL IDENTITY,
        [perfil_id] int NOT NULL,
        [vaga_id] int NOT NULL,
        [usuario_criacao] int NULL,
        [cadastrado_em] datetime2 NULL,
        [usuario_alteracao] int NULL,
        [alterado_em] datetime2 NULL,
        CONSTRAINT [pk_candidato] PRIMARY KEY ([id]),
        CONSTRAINT [fk_candidato_perfil_perfil_id] FOREIGN KEY ([perfil_id]) REFERENCES [perfil] ([id]) ON DELETE NO ACTION,
        CONSTRAINT [fk_candidato_vaga_vaga_id] FOREIGN KEY ([vaga_id]) REFERENCES [vaga] ([id]) ON DELETE NO ACTION
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210906215759_first-migration')
BEGIN
    CREATE TABLE [like] (
        [id] int NOT NULL IDENTITY,
        [perfil_id] int NOT NULL,
        [vaga_id] int NOT NULL,
        [usuario_criacao] int NULL,
        [cadastrado_em] datetime2 NULL,
        [usuario_alteracao] int NULL,
        [alterado_em] datetime2 NULL,
        CONSTRAINT [pk_like] PRIMARY KEY ([id]),
        CONSTRAINT [fk_like_perfil_perfil_id] FOREIGN KEY ([perfil_id]) REFERENCES [perfil] ([id]) ON DELETE NO ACTION,
        CONSTRAINT [fk_like_vaga_vaga_id] FOREIGN KEY ([vaga_id]) REFERENCES [vaga] ([id]) ON DELETE NO ACTION
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210906215759_first-migration')
BEGIN
    CREATE INDEX [ix_asp_net_role_claims_role_id] ON [asp_net_role_claims] ([role_id]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210906215759_first-migration')
BEGIN
    EXEC(N'CREATE UNIQUE INDEX [role_name_index] ON [asp_net_roles] ([normalized_name]) WHERE [normalized_name] IS NOT NULL');
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210906215759_first-migration')
BEGIN
    CREATE INDEX [ix_asp_net_user_claims_user_id] ON [asp_net_user_claims] ([user_id]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210906215759_first-migration')
BEGIN
    CREATE INDEX [ix_asp_net_user_logins_user_id] ON [asp_net_user_logins] ([user_id]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210906215759_first-migration')
BEGIN
    CREATE INDEX [ix_asp_net_user_roles_role_id] ON [asp_net_user_roles] ([role_id]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210906215759_first-migration')
BEGIN
    CREATE INDEX [email_index] ON [asp_net_users] ([normalized_email]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210906215759_first-migration')
BEGIN
    EXEC(N'CREATE UNIQUE INDEX [user_name_index] ON [asp_net_users] ([normalized_user_name]) WHERE [normalized_user_name] IS NOT NULL');
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210906215759_first-migration')
BEGIN
    CREATE INDEX [ix_candidato_perfil_id] ON [candidato] ([perfil_id]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210906215759_first-migration')
BEGIN
    CREATE INDEX [ix_candidato_vaga_id] ON [candidato] ([vaga_id]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210906215759_first-migration')
BEGIN
    CREATE INDEX [ix_cidade_estado_id] ON [cidade] ([estado_id]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210906215759_first-migration')
BEGIN
    CREATE INDEX [ix_empresa_cidade_id] ON [empresa] ([cidade_id]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210906215759_first-migration')
BEGIN
    CREATE INDEX [ix_experiencia_perfil_id] ON [experiencia] ([perfil_id]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210906215759_first-migration')
BEGIN
    CREATE INDEX [ix_habilidade_perfil_id] ON [habilidade] ([perfil_id]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210906215759_first-migration')
BEGIN
    CREATE INDEX [ix_like_perfil_id] ON [like] ([perfil_id]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210906215759_first-migration')
BEGIN
    CREATE INDEX [ix_like_vaga_id] ON [like] ([vaga_id]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210906215759_first-migration')
BEGIN
    CREATE UNIQUE INDEX [ix_pagina_empresa_id] ON [pagina] ([empresa_id]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210906215759_first-migration')
BEGIN
    CREATE INDEX [ix_pagina_perfil_id] ON [pagina] ([perfil_id]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210906215759_first-migration')
BEGIN
    CREATE INDEX [ix_perfil_cidade_id] ON [perfil] ([cidade_id]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210906215759_first-migration')
BEGIN
    CREATE UNIQUE INDEX [ix_perfil_usuario_id] ON [perfil] ([usuario_id]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210906215759_first-migration')
BEGIN
    CREATE INDEX [ix_vaga_empresa_id] ON [vaga] ([empresa_id]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210906215759_first-migration')
BEGIN
    CREATE UNIQUE INDEX [ix_vaga_senioridade_id] ON [vaga] ([senioridade_id]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210906215759_first-migration')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20210906215759_first-migration', N'5.0.9');
END;
GO

COMMIT;
GO

