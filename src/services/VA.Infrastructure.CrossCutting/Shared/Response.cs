using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;

namespace VA.Infrastructure.CrossCutting.Shared
{

    /// <summary>
    /// Response padrão para retornos de chamadas.
    /// </summary>
    public class Response<T> where T : notnull
    {
        /// <summary>
        /// Objeto para retornar as mensagem de aviso da chamada.
        /// </summary>
        private readonly List<string> _messages;

        /// <summary>
        /// Objeto para retornar as mensagem de erro da chamada.
        /// </summary>
        private readonly List<string> _errorMessages;

        /// <summary>
        /// Objeto para retornar um dicionário contendo códigos e mensagem de erro da chamada.
        /// </summary>
        private readonly Dictionary<int, string> _errorCodeMessages;

        /// <summary>
        /// Cria um response com o objeto a ser retornado da chamada.
        /// </summary>
        public Response(T result, bool isSuccess = true)
        {
            IsSuccess = isSuccess;
            _messages = new List<string>();
            _errorMessages = new List<string>();
            _errorCodeMessages = new Dictionary<int, string>();

            AddResult(result);
        }

        /// <summary>
        /// Cria um response com resultado de validações feitas via fail fast validation (FluentValidation)
        /// </summary>
        public Response(ValidationResult validationResult)
        {
            _errorMessages = new List<string>();
            _messages = new List<string>();
            _errorCodeMessages = new Dictionary<int, string>();

            ProcessValidationResults(validationResult);
        }

        public Response(IEnumerable<ValidationResult> validationResults)
        {
            _errorMessages = new List<string>();
            _messages = new List<string>();
            _errorCodeMessages = new Dictionary<int, string>();

            ProcessValidationResults(validationResults.ToArray());
        }

        /// <summary>
        /// Cria um response com as mensagens de aviso ou erro (em caso de sucesso ou insucesso, respectivamente) da chamada
        /// </summary>
        /// <param name="messages">Enumeração contendo as mensagens de aviso ou erro</param>
        /// <param name="isSuccess">Indicador de chamada com sucesso ou insucesso. Fator de decisão para as mensagens serem de aviso ou erro, respectivamente</param>
        public Response(IEnumerable<string> messages, bool isSuccess)
        {
            IsSuccess = isSuccess;
            _errorMessages = new List<string>();
            _messages = new List<string>();
            _errorCodeMessages = new Dictionary<int, string>();

            ProcessMessageResults(messages);
        }

        /// <summary>
        /// Cria um response com as mensagens de erro da chamada
        /// </summary>
        /// <param name="errorMessages">Enumeração contendo as mensagens de erro</param>
        public Response(IEnumerable<string> errorMessages) : this(errorMessages, false)
        {
        }

        /// <summary>
        /// Cria um response com o objeto a ser retornado da chamada adiconando vários códigos de erro atrelado à mensagens de erro.
        /// </summary>
        /// <param name="errorCodeMessages">Dicionário contendo o código e mensagem de erro</param>
        public Response(IReadOnlyDictionary<int, string> errorCodeMessages)
        {
            _errorMessages = new List<string>();
            _messages = new List<string>();
            _errorCodeMessages = new Dictionary<int, string>();

            AddErrorCodeMessages(errorCodeMessages);
        }

        private void ProcessValidationResults(params ValidationResult[] validationResults)
        {
            foreach (var validationResult in validationResults)
            {
                CheckValidationResult(validationResult);
                AddValidationResult(validationResult);
            }

            VerifyValidity();
        }

        private void ProcessMessageResults(IEnumerable<string> messages)
        {
            if (IsSuccess)
            {
                _messages.AddRange(messages);
                return;
            }

            _errorMessages.AddRange(messages);
        }

        /// <summary>
        /// Readonly: Mensagens de erro ocorridos durante a chamada.
        /// </summary>
        public virtual IReadOnlyCollection<string> ErrorMessages => _errorMessages?.AsReadOnly();

        /// <summary>
        /// Readonly: Mensagens de ocorridos durante a chamada.
        /// </summary>
        public virtual IReadOnlyCollection<string> Messages => _messages?.AsReadOnly();

        /// <summary>
        /// Objeto para retornar um dicionário contendo códigos e mensagem de erro da chamada.
        /// </summary>
        public virtual IReadOnlyDictionary<int, string> ErrorCodeMessages => _errorCodeMessages;


        /// <summary>
        /// Verifica se o Response está válido
        /// </summary>
        public bool IsSuccess { get; private set; }

        /// <summary>
        /// Verifica se existe mensagens de erro e retorna um indicador de sucesso.
        /// </summary>
        private void VerifyValidity() => IsSuccess = (ErrorCodeMessages.Count == 0 && ErrorMessages.Count == 0);

        public T Result { get; private set; }

        /// <summary>
        /// Adiciona uma mensagem de erro a coleção ErrorMessages
        /// <para> Altera o estado da propriedade IsValid para false </para>
        /// </summary>
        public void AddErrorMessage(string message)
        {
            AddErrorMessages(message);
            VerifyValidity();
        }

        /// <summary>
        /// Adiciona uma ou mais mensagens de erro a coleção ErrorMessages
        /// <para> Altera o estado da propriedade IsValid para false </para>
        /// <para> Checa se mensagens são nulas ou vazias e lança a exceção <see cref="ErrorMessageNullOrEmptyException"/> </para>
        /// </summary>
        public void AddErrorMessages(params string[] messages)
        {
            foreach (string message in messages)
            {
                VerifyErrorMessage(message);

                _errorMessages.Add(message);
            }

            VerifyValidity();
        }

        /// <summary>
        /// Adiciona mensagem a coleção Messages
        /// </summary>
        public void AddMessage(string message) => AddMessages(message);

        /// <summary>
        /// Adiciona uma ou mais mensagens a coleção Messages
        /// </summary>
        public void AddMessages(params string[] messages)
        {
            foreach (var message in messages)
            {
                VerifyMessage(message);

                _messages.Add(message);
            }
        }

        /// <summary>
        /// Adicona um código de erro atrelado a uma mensagem de erro
        /// </summary>
        /// <param name="errorCode">Código de erro</param>
        /// <param name="errorMessage">Mensagem de erro</param>
        public void AddErrorCodeMessage(int errorCode, string errorMessage)
        {
            VerifyErrorMessage(errorMessage);
            _errorCodeMessages.Add(errorCode, errorMessage);
            VerifyValidity();
        }

        /// <summary>
        /// Adicona vários códigos de erro atrelado a mensagens de erro
        /// </summary>
        /// <param name="errorCodeMessages">Dicionário contendo o código e mensagem de erro</param>
        public void AddErrorCodeMessages(IReadOnlyDictionary<int, string> errorCodeMessages)
        {
            foreach (var kvp in errorCodeMessages)
            {
                AddErrorCodeMessage(kvp.Key, kvp.Value);
            }
        }

        /// <summary>
        /// Adiciona ao response um objeto que será devolvido para quem fez a chamada (Result)
        /// </summary>
        public void AddResult(T result) => Result = result ?? throw new ArgumentNullException();

        /// <summary>
        /// Adiciona a coleção ErrorMessages resultado de validações feitas via fail fast validation (FluentValidation)
        /// <para> Modifica a propriedade IsValid para a mesma que o FluentValidation </para>
        /// </summary>
        public void AddValidationResult(ValidationResult validationResult)
        {
            IsSuccess = validationResult.IsValid;
            VerifyErrorMessages(validationResult);
        }

        private static void CheckValidationResult(ValidationResult validationResult)
        {
            if (validationResult == null)
            {
                throw new ArgumentNullException(ResponseConstants.ValidationResultNullMessage);
            }
        }

        private static void VerifyErrorMessage(string message)
        {
            if (string.IsNullOrEmpty(message))
            {
                throw new ArgumentNullException(ResponseConstants.ErrorMessageIsNullOrEmptyMessage);
            }
        }

        private static void VerifyMessage(string message)
        {
            if (string.IsNullOrEmpty(message))
            {
                throw new ArgumentNullException(ResponseConstants.MessageIsNullOrEmptyMessage);
            }
        }

        private void VerifyErrorMessages(ValidationResult validationResult)
        {
            _errorMessages.AddRange(validationResult.Errors.Select(e => e.ErrorMessage).ToList());
        }
    }

    /// <summary>
    /// Response padrão para retornos de chamadas.
    /// </summary>
    public class Response : Response<object>
    {
        /// <summary>
        /// Cria um response com resultado de validações feitas via fail fast validation (FluentValidation)
        /// </summary>
        public Response(ValidationResult validationResult) : base(validationResult) { }

        public Response(IEnumerable<ValidationResult> validationResults) : base(validationResults) { }

        /// <summary>
        /// Cria um response com as mensagens de erro da chamada
        /// </summary>
        /// <param name="errorMessages">Enumeração contendo as mensagens de erro</param>
        public Response(IEnumerable<string> errorMessages) : base(errorMessages) { }

        /// <summary>
        /// Cria um response com as mensagens de aviso ou erro (em caso de sucesso ou insucesso, respectivamente) da chamada
        /// </summary>
        /// <param name="messages">Enumeração contendo as mensagens de aviso ou erro</param>
        /// <param name="isSuccess">Indicador de chamada com sucesso ou insucesso. Fator de decisão para as mensagens serem de aviso ou erro, respectivamente</param>
        public Response(IEnumerable<string> messages, bool isSuccess) : base(messages, isSuccess) { }

        /// <summary>
        /// Cria um response com o objeto a ser retornado da chamada.
        /// </summary>
        public Response(object result, bool isSuccess = true) : base(result, isSuccess) { }

        /// <summary>
        /// Cria um response com o objeto a ser retornado da chamada adiconando vários códigos de erro atrelado à mensagens de erro.
        /// </summary>
        /// <param name="errorCodeMessages">Dicionário contendo o código e mensagem de erro</param>
        public Response(IReadOnlyDictionary<int, string> errorCodeMessages) : base(errorCodeMessages) { }


        public T GetResult<T>() => (T)Result;
    }
}
