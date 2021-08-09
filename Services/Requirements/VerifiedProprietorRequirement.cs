using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Vizitz.Entities;

namespace Vizitz.Services.Requirements
{
    public class VerifiedProprietorRequirement : IAuthorizationRequirement
    {
        public bool IsVerified { get; private set; }

        public VerifiedProprietorRequirement()
        {

        }
    }
}
