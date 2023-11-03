﻿using GaLegalGeorgia.Application.Models.Email;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GaLegalGeorgia.Application.Contracts.Email
{
    public interface IEmailSender
    {
        Task<bool> SendPasswordResetEmail(string token, string recipientEmail);
    }
}
