using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chessinator.Application.Dtos.Responses
{
    public class ResponseDto<T> : object
    {
        public bool Success { get; set; }
        public T Data { get; set; }
    }
}
