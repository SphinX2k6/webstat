using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Ui;
using UnrealEngine;

// Token: 0x02001F4B RID: 8011
public class HonamiStoryPollutionLevelUpdateView : UiViewBase
{
	// Token: 0x0600EFE0 RID: 61408 RVA: 0x00418A9E File Offset: 0x00416C9E
	[NullableContext(1)]
	public HonamiStoryPollutionLevelUpdateView(UiViewInfo viewInfo) : base(viewInfo)
	{
	}

	// Token: 0x0600EFE1 RID: 61409 RVA: 0x00418AA8 File Offset: 0x00416CA8
	protected unsafe override void OnRegisterComponent()
	{
		int num = 2;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int num2 = 0;
		*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIText));
		this.ComponentRegisterInfos = list;
	}

	// Token: 0x0600EFE2 RID: 61410 RVA: 0x00418B14 File Offset: 0x00416D14
	protected override void OnStart()
	{
		IHonamiStoryPollutionUpdateParams honamiStoryPollutionUpdateParams = (IHonamiStoryPollutionUpdateParams)this.OpenParam;
		base.GetText(0).SetText(honamiStoryPollutionUpdateParams.PollutionLevel.ToString(), true);
		base.GetText(1).SetText(honamiStoryPollutionUpdateParams.MonsterIncreaseLevel.ToString(), true);
		TimerSystem.GameplayTimeInstance.Delay(delegate(float _)
		{
			base.CloseMe(null);
		}, 3500f, null, null, true, 1f);
	}

	// Token: 0x020082D2 RID: 33490
	private enum EComponentType
	{
		// Token: 0x0402C5B6 RID: 181686
		PollutionLevelText,
		// Token: 0x0402C5B7 RID: 181687
		MonsterLevelText
	}
}
