using System;
using System.Collections.Generic;

namespace FileManagement.Common.Exceptions
{
    public abstract class HttpException : Exception
    {
        public virtual int StatusCode { get; }

        public IList<string> ErrorDetails { get; set; }

        protected HttpException()
        {

        }

        protected HttpException(string message)
            : base(message)
        {

        }
    }
}
