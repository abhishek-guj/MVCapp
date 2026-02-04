using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCapp.PL.Filter.Error
{
    public class ErrorResponse(int status, string? msg, string? details)
    {
        private int Status { get; set; } = status;
        private string? Message { get; set; } = msg;
        private string? Details { get; set; } = details;
    }
}