using com.udistrital.mcic.informatica.iot.business;
using com.udistrital.mcic.informatica.iot.dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace com.udistrital.mcic.informatica.iot.api.Controllers
{
    public class NoiseController : ApiController
    {
        NoiseBusiness noiseBusiness = new NoiseBusiness();
        // GET: api/Noise
        public IHttpActionResult Get(String startDate, String startHour, String endDate, String endHour)
        {
            return Ok(noiseBusiness.listNoises(startDate,startHour,endDate,endHour));
        }

        // POST: api/Noise
        public IHttpActionResult Post([FromBody] LevelNoise levelNoise)
        {
            noiseBusiness.saveNoise(levelNoise);
            return Ok();
        }

        // PUT: api/Noise/5
        public IHttpActionResult Put(int id, [FromBody]string value)
        {
            List<String> timeZone = new List<string>();

            foreach (TimeZoneInfo z in TimeZoneInfo.GetSystemTimeZones())
            {
                timeZone.Add(z.Id);

            }

            return Ok(timeZone);
        }

    }
}
