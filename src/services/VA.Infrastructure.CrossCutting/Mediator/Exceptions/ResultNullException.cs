using System;
using System.Runtime.Serialization;

namespace VA.Infrastructure.CrossCutting.Mediator.Exceptions
{
    /// <summary>
    /// Classe que encapsula erros para o campo de resultado(que é o objeto de Output em si) no pacote
    /// </summary>
    [Serializable]
    public class ResultNullException : Exception
    {
        /// <summary>
        /// Construtor que recebe a constant de erro para tipar exception
        /// </summary>
        /// <param name="message"></param>
        public ResultNullException(string message) : base(message)
        {
        }

        /// <summary>
        /// Construtor propagando innerException, se existente.
        /// </summary>
        /// <param name="message"></param>
        /// <param name="innerException"></param>
        public ResultNullException(string message, Exception innerException)
            : base(message, innerException)
        {
        }

        /// <summary>
        /// Construtor para desserialização via remote call.
        /// </summary>
        /// <param name="info"></param>
        /// <param name="context"></param>
        protected ResultNullException(SerializationInfo info,
        StreamingContext context) : base(info, context) { }
    }
}
