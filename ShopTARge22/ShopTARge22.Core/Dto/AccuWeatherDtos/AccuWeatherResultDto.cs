﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopTARge22.Core.Dto
{
    public class AccuWeatherResultDto
    {
        public DateTime EffectiveDate { get; set; }
        public int EffectiveEpochDate { get; set; }
        public int Severity { get; set; }
        public string Text { get; set; }
        public string Category { get; set; }
        public DateTime EndDate { get; set; }
        public int EndEpochDate { get; set; }
        public string MobileLink { get; set; }
        public string Link { get; set; }

        public DateTime DailyForecastsDay { get; set; }
        public int DailyForecastsEpochDate { get; set; }

        public float TempMinValue { get; set; }
        public string TempMinUnit { get; set; }
        public int TempMinUnitType { get; set; }

        public float TempMaxValue { get; set; }
        public string TempMaxUnit { get; set; }
        public int TempMaxUnitType { get; set; }

        public int DayIcon { get; set; }
        public string DayIconPhrase { get; set; }
        public bool DayHasPrecipitation { get; set; }
        public string DayPrecipitationType { get; set; }
        public string DayPrecipitationIntensity { get; set; }

        public int NightIcon { get; set; }
        public string NightIconPhrase { get; set; }
        public bool NightHasPrecipitation { get; set; }
        public string NightPrecipitationType { get; set; }
        public string NightPrecipitationIntensity { get; set; }
    }
}
