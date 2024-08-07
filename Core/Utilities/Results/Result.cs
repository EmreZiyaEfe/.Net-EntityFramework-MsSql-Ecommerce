using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Results
{
    public class Result : IResult
    {

        public Result(bool success, string message):this(success) //iki parametre gönderen için this yani bu classın success kısmıda çalışması lazım
        {
           Message = message; // Aşağıdaki Messageyi message olarak constructorda set ettik
        }

        public Result(bool success)
        {
            Success = success;
        }

        public bool Success { get; }

        public string Message { get; }
    }
}
