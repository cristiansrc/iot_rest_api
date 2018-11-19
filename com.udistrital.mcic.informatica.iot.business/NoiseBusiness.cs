using com.udistrital.mcic.informatica.iot.database;
using com.udistrital.mcic.informatica.iot.dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace com.udistrital.mcic.informatica.iot.business
{
    public class NoiseBusiness
    {
        private NoiseDB noiseDB = new NoiseDB();

        public void saveNoise(LevelNoise levelNoise)
        {
            Noise noise = new Noise();
            noise.levelNoise = levelNoise.levelNoise;

            TimeZoneInfo colombiaZone = TimeZoneInfo.FindSystemTimeZoneById("SA Pacific Standard Time");
            noise.dateNoise = TimeZoneInfo.ConvertTime(DateTime.Now, colombiaZone);

            noiseDB.insertNoise(noise);
        }

        public List<Noise> listNoises(String startDate, String startHour, String endDate, String endHour)
        {
            string[] startHourArr = startHour.Split(":".ToCharArray());
            string[] endHourArr = endHour.Split(":".ToCharArray());

            DateTime startDateTime = DateTime.Parse(startDate);
            startDateTime = startDateTime.AddHours(Int32.Parse(startHourArr[0]));
            startDateTime = startDateTime.AddMinutes(Int32.Parse(startHourArr[1]));

            DateTime endDateTime = DateTime.Parse(endDate);
            endDateTime = endDateTime.AddHours(Int32.Parse(endHourArr[0]));
            endDateTime = endDateTime.AddMinutes(Int32.Parse(endHourArr[1]));

            return noiseDB.selectNoises(startDateTime, endDateTime);
        }


        public NoiseConfig getNoiseConfig()
        {
            return noiseDB.selectNoiseConfig();
        }

        public void updateNoiseConfig(NoiseConfig noiseConfig)
        {
            noiseDB.updateNoiseConfig(noiseConfig);
        }
    }
}
