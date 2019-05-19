using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IDNumber.Models;
using IDNumbers.DAL;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SAIDValidator.Web.Api.Helpers;


namespace SAID_Validator_WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValidateController : ControllerBase
    {
        IIDNumberRepository _idNumberRepository;
        public ValidateController(IIDNumberRepository idNumberRepository)
        {
            _idNumberRepository = idNumberRepository;
        }
        // GET: api/Validate
        [HttpGet]
        public IEnumerable<IDNumberDetails> Get()
        {
            return _idNumberRepository.GetAll();
        }
  
        // POST: api/Validate
        [HttpPost]
        public IEnumerable<IDNumberDetails> Post([FromBody] List<string> idNumbers)
        {
            if (idNumbers.Count ==0) return null;
            List<IDNumberDetails> validIdNumbers = new List<IDNumberDetails>();

            foreach (var idNumber in idNumbers)
            {
                if (ValidateIdNumberHelper.Validate(idNumber).IsValid)
                {
                    IDNumberDetails idObject = ParseIdNumberHelper.Parse(idNumber);
                    validIdNumbers.Add(idObject);
                }
                else
                {
                    validIdNumbers.Add(new IDNumberDetails(idNumber,"Invalid", ValidateIdNumberHelper.Validate(idNumber).Reasons));
                }
            }

              _idNumberRepository.AddRange(validIdNumbers);
            return Get();
        }

    }
}