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

CREATE TABLE [estado] (
    [id] int NOT NULL IDENTITY,
    [nome] varchar(100) NOT NULL,
    [usuario_criacao] int NULL,
    [cadastrado_em] datetime2 NULL,
    [usuario_alteracao] int NULL,
    [alterado_em] datetime2 NULL,
    CONSTRAINT [pk_estado] PRIMARY KEY ([id])
);
GO

CREATE TABLE [senioridade] (
    [id] int NOT NULL IDENTITY,
    [nome] varchar(100) NOT NULL,
    [usuario_criacao] int NULL,
    [cadastrado_em] datetime2 NULL,
    [usuario_alteracao] int NULL,
    [alterado_em] datetime2 NULL,
    CONSTRAINT [pk_senioridade] PRIMARY KEY ([id])
);
GO

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
GO

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
GO

CREATE TABLE [empresa] (
    [id] int NOT NULL IDENTITY,
    [nome] varchar(100) NOT NULL,
    [cidade_id] int NOT NULL,
    [usuario_criacao] int NULL,
    [cadastrado_em] datetime2 NULL,
    [usuario_alteracao] int NULL,
    [alterado_em] datetime2 NULL,
    CONSTRAINT [pk_empresa] PRIMARY KEY ([id]),
    CONSTRAINT [fk_empresa_cidade_cidade_id] FOREIGN KEY ([cidade_id]) REFERENCES [cidade] ([id]) ON DELETE CASCADE
);
GO

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
    CONSTRAINT [fk_perfil_cidade_cidade_id] FOREIGN KEY ([cidade_id]) REFERENCES [cidade] ([id]) ON DELETE CASCADE,
    CONSTRAINT [fk_perfil_usuario_usuario_id] FOREIGN KEY ([usuario_id]) REFERENCES [usuario] ([id]) ON DELETE CASCADE
);
GO

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
    CONSTRAINT [fk_vaga_empresa_empresa_id] FOREIGN KEY ([empresa_id]) REFERENCES [empresa] ([id]) ON DELETE CASCADE,
    CONSTRAINT [fk_vaga_senioridade_senioridade_id] FOREIGN KEY ([senioridade_id]) REFERENCES [senioridade] ([id]) ON DELETE CASCADE
);
GO

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
    CONSTRAINT [fk_experiencia_perfil_perfil_id] FOREIGN KEY ([perfil_id]) REFERENCES [perfil] ([id]) ON DELETE CASCADE
);
GO

CREATE TABLE [habilidade] (
    [id] int NOT NULL IDENTITY,
    [nome] varchar(100) NOT NULL,
    [perfil_id] int NOT NULL,
    [usuario_criacao] int NULL,
    [cadastrado_em] datetime2 NULL,
    [usuario_alteracao] int NULL,
    [alterado_em] datetime2 NULL,
    CONSTRAINT [pk_habilidade] PRIMARY KEY ([id]),
    CONSTRAINT [fk_habilidade_perfil_perfil_id] FOREIGN KEY ([perfil_id]) REFERENCES [perfil] ([id]) ON DELETE CASCADE
);
GO

CREATE TABLE [pagina] (
    [id] int NOT NULL IDENTITY,
    [empresa_id] int NOT NULL,
    [perfil_id] int NOT NULL,
    [usuario_criacao] int NULL,
    [cadastrado_em] datetime2 NULL,
    [usuario_alteracao] int NULL,
    [alterado_em] datetime2 NULL,
    CONSTRAINT [pk_pagina] PRIMARY KEY ([id]),
    CONSTRAINT [fk_pagina_empresa_empresa_id] FOREIGN KEY ([empresa_id]) REFERENCES [empresa] ([id]) ON DELETE CASCADE,
    CONSTRAINT [fk_pagina_perfil_perfil_id] FOREIGN KEY ([perfil_id]) REFERENCES [perfil] ([id]) ON DELETE CASCADE
);
GO

CREATE TABLE [candidato] (
    [id] int NOT NULL IDENTITY,
    [perfil_id] int NOT NULL,
    [vaga_id] int NOT NULL,
    [usuario_criacao] int NULL,
    [cadastrado_em] datetime2 NULL,
    [usuario_alteracao] int NULL,
    [alterado_em] datetime2 NULL,
    CONSTRAINT [pk_candidato] PRIMARY KEY ([id]),
    CONSTRAINT [fk_candidato_perfil_perfil_id] FOREIGN KEY ([perfil_id]) REFERENCES [perfil] ([id]) ON DELETE CASCADE,
    CONSTRAINT [fk_candidato_vaga_vaga_id] FOREIGN KEY ([vaga_id]) REFERENCES [vaga] ([id]) ON DELETE CASCADE
);
GO

CREATE TABLE [like] (
    [id] int NOT NULL IDENTITY,
    [perfil_id] int NOT NULL,
    [vaga_id] int NOT NULL,
    [usuario_criacao] int NULL,
    [cadastrado_em] datetime2 NULL,
    [usuario_alteracao] int NULL,
    [alterado_em] datetime2 NULL,
    CONSTRAINT [pk_like] PRIMARY KEY ([id]),
    CONSTRAINT [fk_like_perfil_perfil_id] FOREIGN KEY ([perfil_id]) REFERENCES [perfil] ([id]) ON DELETE CASCADE,
    CONSTRAINT [fk_like_vaga_vaga_id] FOREIGN KEY ([vaga_id]) REFERENCES [vaga] ([id]) ON DELETE CASCADE
);
GO

CREATE INDEX [ix_candidato_perfil_id] ON [candidato] ([perfil_id]);
GO

CREATE INDEX [ix_candidato_vaga_id] ON [candidato] ([vaga_id]);
GO

CREATE INDEX [ix_cidade_estado_id] ON [cidade] ([estado_id]);
GO

CREATE INDEX [ix_empresa_cidade_id] ON [empresa] ([cidade_id]);
GO

CREATE INDEX [ix_experiencia_perfil_id] ON [experiencia] ([perfil_id]);
GO

CREATE INDEX [ix_habilidade_perfil_id] ON [habilidade] ([perfil_id]);
GO

CREATE INDEX [ix_like_perfil_id] ON [like] ([perfil_id]);
GO

CREATE INDEX [ix_like_vaga_id] ON [like] ([vaga_id]);
GO

CREATE UNIQUE INDEX [ix_pagina_empresa_id] ON [pagina] ([empresa_id]);
GO

CREATE INDEX [ix_pagina_perfil_id] ON [pagina] ([perfil_id]);
GO

CREATE INDEX [ix_perfil_cidade_id] ON [perfil] ([cidade_id]);
GO

CREATE UNIQUE INDEX [ix_perfil_usuario_id] ON [perfil] ([usuario_id]);
GO

CREATE INDEX [ix_vaga_empresa_id] ON [vaga] ([empresa_id]);
GO

CREATE UNIQUE INDEX [ix_vaga_senioridade_id] ON [vaga] ([senioridade_id]);
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20210906012507_primeiro-migration', N'5.0.1');
GO

COMMIT;
GO

