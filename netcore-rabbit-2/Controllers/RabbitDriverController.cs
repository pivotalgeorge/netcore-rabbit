using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Rubicon.Cms.Publisher.Services;

namespace Rubicon.Cms.Publisher.Controllers
{
    [Route("api/[controller]")]
    public class RabbitDriverController : Controller
    {



        // GET api/values
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] {"rabbit", "driver"};
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
			//var publisher = new Services.Publisher ("guest", "guest", "localhost");
			//publisher.Publish (null);
        }

        
        
        
    }
}