using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using udistrital.mcic.informatica.iot.business;
using udistrital.mcic.informatica.iot.dto;

namespace udistrital.mcic.informatica.iot.rest.Controllers
{
    public class NoiseController : ApiController
    {
        NoiseBusiness noiseBusiness = new NoiseBusiness();
        // GET: api/Noise
        public IHttpActionResult Get(String startDate, String startHour, String endDate, String endHour)
        {
            return Ok(noiseBusiness.listNoises(startDate, startHour, endDate, endHour));
        }

        // POST: api/Noise
        public IHttpActionResult Post([FromBody] LevelNoise levelNoise)
        {
            noiseBusiness.saveNoise(levelNoise);
            return Ok();
        }

    }
}
