using System;
using INTEC.Helpers.Infraestructure;
using INTEC.Models.Insfraestructure;

namespace INTEC.Helpers.Extensions
{
    public static class ServiceResultExtensions
    {
        public static ServiceResult LogError(this ServiceResult sr, Exception ex)
        {
            sr.Success = false;
            sr.ResultObject = Error.GetErrorMessage(Error.UnexpectedError);
            sr.Messages.Add(ex.Message);

            return sr;
        }
    }
}
