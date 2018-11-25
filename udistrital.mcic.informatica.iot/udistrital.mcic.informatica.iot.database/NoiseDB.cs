using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using udistrital.mcic.informatica.iot.dto;

namespace udistrital.mcic.informatica.iot.database
{
    public class NoiseDB
    {
        IotEntities context = new IotEntities();

        public void insertNoise(Noise noise)
        {
            var noiseDb = new noise
            {
                dateNoise = noise.dateNoise,
                levelNoise = noise.levelNoise
            };

            context.noise.Add(noiseDb);
            context.SaveChanges();
        }

        public List<Noise> selectNoises(DateTime startDateTime, DateTime endDateTime)
        {
            var noises = context.noise.Where(n => n.dateNoise >= startDateTime).Where(n => n.dateNoise <= endDateTime).Select(n => new Noise
            {
                dateNoise = n.dateNoise,
                levelNoise = n.levelNoise
            }
            ).ToList();



            return noises;
        }

        public NoiseConfig selectNoiseConfig()
        {
            var noiseConfig = context.noiseConfig.Select(n => new NoiseConfig
            {
                OnNoiseConfig = n.onNoiseConfig.Trim(),
                TimeSendInfoNoiseConfig = n.timeSendInfoNoiseConfig
            }
            ).FirstOrDefault();

            return noiseConfig;
        }

        public void updateNoiseConfig(NoiseConfig noiseConfig)
        {
            var noiseConfigQuery = (from a in context.noiseConfig
                                    where a.idNoiseConfig == 1
                                    select a).FirstOrDefault();

            noiseConfigQuery.onNoiseConfig = noiseConfig.OnNoiseConfig;
            noiseConfigQuery.timeSendInfoNoiseConfig = noiseConfig.TimeSendInfoNoiseConfig;

            context.SaveChanges();
        }
    }
}
