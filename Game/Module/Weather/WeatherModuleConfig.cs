using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;

namespace CSharpScript.Game.Module.Weather
{
	// Token: 0x02004BFF RID: 19455
	[NullableContext(2)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	[Config(0)]
	public class WeatherModuleConfig : ConfigBase<WeatherModuleConfig>
	{
		// Token: 0x06032C5F RID: 207967 RVA: 0x00CB8184 File Offset: 0x00CB6384
		public Weather? GetWeatherConfig(int id)
		{
			Weather? config = ConfigWeatherById.GetConfig(id, true);
			if (config != null)
			{
				return new Weather?(config.Value);
			}
			return null;
		}

		// Token: 0x06032C60 RID: 207968 RVA: 0x00CB81B8 File Offset: 0x00CB63B8
		public WeatherDefines.EWeatherType GetWeatherType(int id)
		{
			Weather? config = ConfigWeatherById.GetConfig(id, true);
			if (config != null)
			{
				return (WeatherDefines.EWeatherType)config.Value.WeatherType;
			}
			return WeatherDefines.EWeatherType.None;
		}

		// Token: 0x06032C61 RID: 207969 RVA: 0x00CB81E8 File Offset: 0x00CB63E8
		public WeatherSwitch? GetWeatherSwitchConfig(int id)
		{
			WeatherSwitch? config = ConfigWeatherSwitchById.GetConfig(id, true);
			if (config != null)
			{
				return new WeatherSwitch?(config.Value);
			}
			return null;
		}

		// Token: 0x06032C62 RID: 207970 RVA: 0x00CB821C File Offset: 0x00CB641C
		public IReadOnlyList<WeatherSwitch> GetWeatherSwitchConfigAll()
		{
			return ConfigWeatherSwitchAll.GetConfigList(true);
		}
	}
}
