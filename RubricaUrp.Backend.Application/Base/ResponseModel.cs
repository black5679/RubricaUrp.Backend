using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RubricaUrp.Backend.Application.Base
{
    public class ResponseModel
    {
        public ResponseModel()
        {

        }
        public ResponseModel(string? message)
        {
            Message = message;
        }
        public ResponseModel(string? message, dynamic data)
        {
            Message = message;
            Data = data;
        }

        public string? Message { get; set; }
        public dynamic? Data { get; set; }
    }
}
