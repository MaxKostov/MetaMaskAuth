﻿using Microsoft.AspNetCore.Mvc;
using Nethereum.Signer;

namespace MetaMaskAuth.AppHost.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        [HttpPost("verify")]
        public IActionResult Verify([FromBody] AuthRequest request)
        {
            var signer = new EthereumMessageSigner();
            var recoveredAddress = signer.EncodeUTF8AndEcRecover(request.Message, request.Signature);

            if (recoveredAddress == request.Account)
            {
                return Ok(new { success = true });
            }

            return Unauthorized();
        }
    }

    public class AuthRequest
    {
        public string Account { get; set; }
        public string Signature { get; set; }
        public string Message { get; set; }
    }

}
