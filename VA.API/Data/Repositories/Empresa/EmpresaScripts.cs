namespace VA.API.Data.Repositories.Empresa
{
    public static class EmpresaScripts
    {
        public static string CriarEmpresa()
        {
            return @"
                    
                    INSERT INTO EMPRESA(
	                    NOME,ID_CIDADE, USUARIO_CRIACAO, DATA_CRIACAO
                    )
                    VALUES 
                    (
	                    @Nome, @IdCidade, @Usuario, @DataCriacao
                    )

                   ";
        }
    }
}
