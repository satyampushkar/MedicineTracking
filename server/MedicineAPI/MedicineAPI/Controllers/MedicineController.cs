using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MedicineModel;
using MedicineService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace MedicineAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MedicineController : ControllerBase
    {
        private readonly ILogger<MedicineController> _logger;
        private readonly IMedicineService _medicineService;
        public MedicineController(ILogger<MedicineController> logger, IMedicineService medicineService)
        {
            _logger = logger;
            _medicineService = medicineService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Medicine>> Get()
        {
            try
            {
                return Ok(_medicineService.GetAll());
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
        [HttpGet("{id}")]
        public ActionResult<Medicine> Get(string id)
        {
            try
            {
                return Ok(_medicineService.Get(Guid.Parse(id)));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
        [HttpGet("[action]/{name}")]
        public ActionResult<IEnumerable<Medicine>> Search(string name)
        {
            try
            {
                return Ok(_medicineService.Search(name));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
        [HttpPost]
        public ActionResult<Medicine> Post([FromBody]Medicine medicine)
        {
            try
            {
                medicine.Id = Guid.NewGuid();
                var res = _medicineService.Add(medicine);
                return Ok(res);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
        [HttpPut]
        public ActionResult<Medicine> Put([FromBody]Medicine medicine)
        {
            try
            {
                return Ok(_medicineService.Update(medicine));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
    }
}
