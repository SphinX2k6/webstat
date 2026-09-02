using System;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.Weather;

// Token: 0x020033F2 RID: 13298
public class RedDotWeatherCentral : RedDotBase
{
	// Token: 0x0601B9D8 RID: 113112 RVA: 0x0083D689 File Offset: 0x0083B889
	protected override ERedDotName? OnGetParentName()
	{
		return new ERedDotName?(ERedDotName.FunctionMap);
	}

	// Token: 0x0601B9D9 RID: 113113 RVA: 0x0083D692 File Offset: 0x0083B892
	protected override void AddCheckEvent()
	{
		Singleton<EventSystem>.Instance.Add(EEventName.OnWeatherCentralRedDotUpdate, new Action(base.EventCheck));
	}

	// Token: 0x0601B9DA RID: 113114 RVA: 0x0083D6B0 File Offset: 0x0083B8B0
	protected override void RemoveCheckEvent()
	{
		Singleton<EventSystem>.Instance.Remove(EEventName.OnWeatherCentralRedDotUpdate, new Action(base.EventCheck));
	}

	// Token: 0x0601B9DB RID: 113115 RVA: 0x0083D6CE File Offset: 0x0083B8CE
	protected override bool OnCheck(int uId = 0)
	{
		return ModelBase<WeatherModel>.Instance.HasAnyNewWeather();
	}
}
