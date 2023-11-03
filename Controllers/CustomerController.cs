using CustomersApi.Models;
using CustomersApi.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace CustomersApi.Controllers
{
    [ApiController]
    [Route("api/customers")]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomersRepository _customersRepository;
        private readonly ICustomersProvider _customersProvider;
        public CustomerController(ICustomersRepository customersRepository, ICustomersProvider customersProvider)
        {
            _customersRepository = customersRepository;
            _customersProvider = customersProvider;
        }

        [HttpGet]
        public ActionResult Get()
        {
            try
            {
                var customers = _customersProvider.Get();
                return Ok(customers);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet("{id}", Name = "CustomerById")]
        public ActionResult GetById(int id)
        {
            try
            {
                var company = _customersProvider.GetById(id);
                if (company == null)
                    return NotFound();
                return Ok(company);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPost]
        public ActionResult Post(CustomerDto customer)
        {
            try
            {
                _customersRepository.Add(customer);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpDelete("{id}", Name = "DeleteCustomer")]
        public ActionResult Delete(int id)
        {
            try
            {
                _customersRepository.Delete(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPut("{id}", Name = "UpdateCustomer")]

        public ActionResult Update(int id, CustomerDto customer)
        {
            try
            {
                var dbCompany = _customersProvider.GetById(id);
                if (dbCompany == null)
                    return NotFound();

                _customersRepository.Update(id, customer);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}