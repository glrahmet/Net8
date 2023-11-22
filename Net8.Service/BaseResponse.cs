using Net8.Service.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Net8.Service
{
    public class BaseResponse<T>
    {
        public int StatusCode { get; set; }
        public string ErrorCode { get; set; }
        public string Message { get; set; }
        public string Subject { get; set; }
        public string ReturnUrl { get; set; }
        public T Data { get; set; }
        public void SetSuccess(string mesaj)
        {
            this.StatusCode = StatusCodeEnum.Success;
            this.Subject = ResponseSubjectEnum.Success;
            this.Message = mesaj;
        }
        public void SetWarning(string mesaj, string errorCode = null)
        {
            this.StatusCode = StatusCodeEnum.Warning;
            this.Subject = ResponseSubjectEnum.Warning;
            this.Message = mesaj;
            this.ErrorCode = errorCode;
        }
        public void SetError(string mesaj, string errorCode = null)
        {
            this.StatusCode = StatusCodeEnum.Error;
            this.Subject = ResponseSubjectEnum.Error;
            this.Message = mesaj;
            this.ErrorCode = errorCode;
        }
        public bool HasErrorOrHasWarning
        {
            get
            {
                return this.StatusCode == StatusCodeEnum.Warning || this.StatusCode == StatusCodeEnum.Error;
            }
        }
    }
}
