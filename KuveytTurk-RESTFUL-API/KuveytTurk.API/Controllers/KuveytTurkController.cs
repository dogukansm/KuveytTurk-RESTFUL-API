using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KuveytTurk.BUSINESS.Abstract;
using KuveytTurk.ENTITIES.Dto;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.ChangeTracking.Internal;

namespace KuveytTurk.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class KuveytTurkController : ControllerBase
    {
        private readonly IKuveytTurkService _kuveytService;

        public KuveytTurkController(IKuveytTurkService kuveytService)
        {
            _kuveytService = kuveytService; 
        }

        [HttpGet(template: "GenerateAccessToken")]
        public async Task<IActionResult> GenerateAccessToken()
        {
            var result = await _kuveytService.GenerateAccessToken();

            if (result.Success)
            {
                return Ok(result.Data);
            }

            return BadRequest();
        }

        [HttpPost(template: "GenerateGetSignature")]
        public async Task<IActionResult> GenerateGetSignature(string accessToken)
        {
            var result = _kuveytService.GetSignature(accessToken);

            if (!string.IsNullOrEmpty(result))
            {
                return Ok(result);
            }

            return BadRequest();
        }

        [HttpPost(template: "GeneratePostSignature")]
        public async Task<IActionResult> GeneratePostSignature(string accessToken, string data)
        {
            return Ok();
        }
        
        [HttpPost(template: "AccountTransactions")]
        public async Task<IActionResult> AccountTransactions(GetAccountTransactionsDto model)
        {
            var data = await _kuveytService.AccountTransactions(model);

            if (data.Success)
            {
                return Ok(data.Data);
            }

            return BadRequest();
        }

        [HttpPost(template: "TransactionList")]
        public async Task<IActionResult> TransactionList(GetAccountTransactionsDto model)
        {
            var data = await _kuveytService.TransactionList(model);

            if (data.Success)
            {
                return Ok(data.Data);
            }

            return BadRequest();
        }
        
        [HttpPost(template: "CustomerIBANInfo")]
        public async Task<IActionResult> CustomerIBANInfo(GetCustomerWithIBANDto model)
        {
            var data = await _kuveytService.CustomerIBANInfo(model);

            if (data.Success)
            {
                return Ok(data.Data);
            }

            return BadRequest();
        }
        
    }
}
