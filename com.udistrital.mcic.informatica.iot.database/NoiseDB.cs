using com.udistrital.mcic.informatica.iot.dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace com.udistrital.mcic.informatica.iot.database
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

            context.noises.Add(noiseDb);
            context.SaveChanges();
        }

        public List<Noise> selectNoises(DateTime startDateTime, DateTime endDateTime)  
        {
            
            //var studentList = ctx.Students.Where(s => s.StudentName == "Bill").ToList();
            var noises = context.noises.Where(n => n.dateNoise >= startDateTime).Where(n => n.dateNoise <= endDateTime).Select(n => new Noise
                {
                    dateNoise = n.dateNoise,
                    levelNoise = n.levelNoise
                }
            ).ToList();

           

            return noises;
        }

        public NoiseConfig selectNoiseConfig()
        {
            var noiseConfig = context.noiseConfigs.Select(n => new NoiseConfig
                {
                    OnNoiseConfig = n.onNoiseConfig
                }
            ).FirstOrDefault();

            return noiseConfig;
        }

        public void updateNoiseConfig(NoiseConfig noiseConfig)
        {
            var noiseConfigQuery = (from a in context.noiseConfigs
                                    where a.idNoiseConfig == 1
                                    select a).FirstOrDefault();

            noiseConfigQuery.onNoiseConfig = noiseConfig.OnNoiseConfig;

            context.SaveChanges();
        }
    }
}