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
    public class NoiseConfigController : ApiController
    {
        NoiseBusiness noiseBusiness = new NoiseBusiness();
        // GET: api/NoiseConfig
        public IHttpActionResult Get()
        {
            return Ok(noiseBusiness.getNoiseConfig());
        }

        // PUT: api/NoiseConfig/5
        public void Put([FromBody] NoiseConfig noiseConfig)
        {
            noiseBusiness.updateNoiseConfig(noiseConfig);
        }

        // DELETE: api/NoiseConfig/5
        public void Delete(int id)
        {
        }
    }
}
