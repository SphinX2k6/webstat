using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using CSharpScript.Game.Module.HonamiStory;
using CSharpScript.Game.Ui;
using UnrealEngine;

// Token: 0x02001F5D RID: 8029
public class HonamiStoryBozaiTalkPanel : UiPanelBase
{
	// Token: 0x0600F063 RID: 61539 RVA: 0x0041B2AC File Offset: 0x004194AC
	protected unsafe override void OnRegisterComponent()
	{
		int num = 1;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int index = 0;
		*span[index] = new ValueTuple<int, Type>(0, typeof(UUIText));
		this.ComponentRegisterInfos = list;
	}

	// Token: 0x0600F064 RID: 61540 RVA: 0x0041B2F4 File Offset: 0x004194F4
	public void SetTalkInfoTextAndPlayAudio(HonamiStoryOutDialog? config)
	{
		if (config == null)
		{
			return;
		}
		double num;
		if (!this.LastTimeMap.TryGetValue((EHonamiStoryOutDialogType)config.Value.Type, out num))
		{
			num = 0.0;
		}
		if (Math.Abs(Singleton<Time>.Instance.ServerTimeStamp / 1000.0 - num) < (double)config.Value.Interval)
		{
			return;
		}
		this.LastTimeMap[(EHonamiStoryOutDialogType)config.Value.Type] = Singleton<Time>.Instance.ServerTimeStamp;
		if (!StringUtils.IsBlank(config.Value.Desc))
		{
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(0), config.Value.Desc, Array.Empty<object>());
		}
		Singleton<AudioSystem>.Instance.PostEvent(config.Value.AudioEvent);
	}

	// Token: 0x04007387 RID: 29575
	[Nullable(1)]
	private readonly Dictionary<EHonamiStoryOutDialogType, double> LastTimeMap = new Dictionary<EHonamiStoryOutDialogType, double>();

	// Token: 0x020082EA RID: 33514
	private enum EBoZaiComponent
	{
		// Token: 0x0402C635 RID: 181813
		TxtBoZaiTalk
	}
}
