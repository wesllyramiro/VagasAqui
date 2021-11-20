namespace VA.Infrastructure.Shared
{

    public static class ResponseConstants
    {
        /// <summary>
        /// Variável de retorno indicando que não foi possível incluir erros à lista de erros.
        /// </summary>
        public static string ErrorMessageIsNullOrEmptyMessage => "Error while trying to add string to ErrorMessage Collection. It is null or empty, please verify.";

        /// <summary>
        /// Variável de retorno indicando que não foi possível incluir mensagens à lista.
        /// </summary>
        public static string MessageIsNullOrEmptyMessage => "Error while trying to add string to Message Collection. It is null or empty, please verify.";

        /// <summary>
        /// Variável de retorno indicando que o objeto de response retornou null.
        /// </summary>
        public static string ResultNullMessage => "Result object is null, please verify.";

        /// <summary>
        /// Variável de retorno indicando que o processo de validação (FailFast) retornou null.
        /// </summary>
        public static string ValidationResultNullMessage => "ValidationResult is null, please verify.";

        /// <summary>
        /// Variável de retorno quando a request recebe alguma exception.
        /// </summary>
        public static string ErrorMessageWhenOccurExceptionInRequest => "An error occurred during the request. Please see the application logs";
    }
}
