using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestaurantAPI.Models
{
    public class ResponseModel<T>
    {
        public T Value { get; set; }
        public bool isSuccess { get; set; }
        public IEnumerable<string> Errors { get; set; }
        public ErrorResponseType ErrorType { get; set; }
    }

    public enum ErrorResponseType
    {
        NotFound,
        InternalError,
        InvalidOperation
    }
}
