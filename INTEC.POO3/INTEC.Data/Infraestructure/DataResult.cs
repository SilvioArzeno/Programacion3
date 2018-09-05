using System;
using System.Text;

namespace INTEC.Data.Infraestructure
{
    public class DataResult
    {
        public Boolean Successfull { get; set; } = true;
        public dynamic Data { get; set; }

        public void LogError(Exception ex)
        {
            this.Successfull = false;
            this.Data = ex.Message;
        }
    }
}
