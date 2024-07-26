﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;

namespace TMOnline.Shared.Infrastructure.Models
{
    [Serializable]
    [DataContract(Name = "ApiResponse")]
    public record ApiResponseModel
    {
        [DataMember(Name = "ErrorMessages")]
        public IEnumerable<string> ErrorMessages { get; internal set; }

        [DataMember(Name = "IsSuccess")]
        public bool IsSuccess
        {
            get
            {
                if (this.ErrorMessages != null && this.ErrorMessages.Count() > 0)
                    return false;
                else
                    return true;
            }
        }

        public ApiResponseModel() { }

        public ApiResponseModel(IEnumerable<string> errorMessages) => ErrorMessages = errorMessages;
    }

    [Serializable]
    [DataContract(Name = "ApiResponse")]
    public record ApiResponseModel<TData> : ApiResponseModel
    {
        [DataMember(Name = "Data")]
        public TData Data { get; internal set; }

        public ApiResponseModel(TData data) => Data = data;
    }
}
