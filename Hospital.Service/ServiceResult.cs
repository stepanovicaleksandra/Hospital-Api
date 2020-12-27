﻿namespace Hospital.Service
{
    public abstract class ServiceResult
    {
        public bool Success { get; protected set; }

        public string Message { get; protected set; }

        protected ServiceResult(bool success)
        {
            Success = success;
        }

        protected ServiceResult(bool success, string message)
        {
            Success = success;
            Message = message;
        }
    }
        public class ServiceResult<T> : ServiceResult
        {
            public T ResultObject { get; set; }

            public ServiceResult(bool success)
                : base(success)
            {
            }

            public ServiceResult(bool success, T resultObject)
                : base(success)
            {
                ResultObject = resultObject;
            }

            public ServiceResult(bool success, string message)
                : base(success, message)
            {
            }

            public ServiceResult(bool success, string message, T resultObject)
                : base(success, message)
            {
                ResultObject = resultObject;
            }
        }
    }

