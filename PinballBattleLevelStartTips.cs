using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Ui;
using UnrealEngine;

// Token: 0x02001D65 RID: 7525
public class PinballBattleLevelStartTips : PinballBattleTipsBase
{
	// Token: 0x0600DD91 RID: 56721 RVA: 0x003B94D2 File Offset: 0x003B76D2
	[NullableContext(1)]
	public PinballBattleLevelStartTips(UiViewInfo viewInfo) : base(viewInfo)
	{
	}

	// Token: 0x0600DD92 RID: 56722 RVA: 0x003B94DC File Offset: 0x003B76DC
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

	// Token: 0x0600DD93 RID: 56723 RVA: 0x003B9524 File Offset: 0x003B7724
	protected override void OnStart()
	{
		base.OnStart();
		IPinballBattleLevelStartTipsParam pinballBattleLevelStartTipsParam = this.OpenParam as IPinballBattleLevelStartTipsParam;
		UUIText text = base.GetText(0);
		if (text == null)
		{
			return;
		}
		text.SetText(pinballBattleLevelStartTipsParam.CurWave.ToString() + "/" + pinballBattleLevelStartTipsParam.MaxWave.ToString(), true);
	}
}
