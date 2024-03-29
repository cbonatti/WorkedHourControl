﻿using WorkedHourControl.Application.DTOs.Responses.EmployeeResponses;

namespace WorkedHourControl.Application.DTOs.Responses
{
    public class LoginConfirmedResponse
    {
        public string Username { get; set; }
        public EmployeeResponse Employee { get; set; }
        public string Token { get; set; }
    }
}
