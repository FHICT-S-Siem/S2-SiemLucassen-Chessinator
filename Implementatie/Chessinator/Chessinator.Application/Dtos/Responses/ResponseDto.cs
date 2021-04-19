﻿namespace Chessinator.Application.Dtos.Responses
{
    public class ResponseDto<T> : object
    {
        public bool Success { get; set; }
        public T Data { get; set; }
    }
}
