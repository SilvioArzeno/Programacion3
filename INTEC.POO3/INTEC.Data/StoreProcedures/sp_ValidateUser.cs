using System;
namespace INTEC.Data.StoreProcedures
{
    public class sp_ValidateUser
    {
        public String UserName { get; set; }
        public String Password { get; set; }
        public Boolean Valid { get; set; }
    }
}
