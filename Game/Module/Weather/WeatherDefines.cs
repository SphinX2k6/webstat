using System;

namespace CSharpScript.Game.Module.Weather
{
	// Token: 0x02004BFD RID: 19453
	public class WeatherDefines
	{
		// Token: 0x0401D8A9 RID: 121001
		public const int REFRESH_WEATHER_TIMER_INTERVAL = 1000;

		// Token: 0x0200ACF1 RID: 44273
		public enum EWeatherType
		{
			// Token: 0x04035B6B RID: 220011
			None,
			// Token: 0x04035B6C RID: 220012
			Sunny,
			// Token: 0x04035B6D RID: 220013
			Cloudy,
			// Token: 0x04035B6E RID: 220014
			Rainy,
			// Token: 0x04035B6F RID: 220015
			ThunderRain,
			// Token: 0x04035B70 RID: 220016
			Snowy
		}
	}
}
