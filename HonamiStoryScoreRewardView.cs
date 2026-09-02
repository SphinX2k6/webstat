using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Ui;
using UnrealEngine;

// Token: 0x02001F4F RID: 8015
public class HonamiStoryScoreRewardView : UiViewBase
{
	// Token: 0x0600EFFD RID: 61437 RVA: 0x0041958D File Offset: 0x0041778D
	[NullableContext(1)]
	public HonamiStoryScoreRewardView(UiViewInfo viewInfo) : base(viewInfo)
	{
	}

	// Token: 0x0600EFFE RID: 61438 RVA: 0x00419598 File Offset: 0x00417798
	protected unsafe override void OnRegisterComponent()
	{
		int num = 1;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int index = 0;
		*span[index] = new ValueTuple<int, Type>(0, typeof(UUIItem));
		this.ComponentRegisterInfos = list;
	}

	// Token: 0x020082D8 RID: 33496
	private enum EHonamiStoryScoreRewardComponent
	{
		// Token: 0x0402C5DA RID: 181722
		ItemCaption
	}
}
