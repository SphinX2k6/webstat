using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Ui;
using UnrealEngine;

// Token: 0x02001D62 RID: 7522
public class PinballBattleBossSkillTips : PinballBattleTipsBase
{
	// Token: 0x0600DD8C RID: 56716 RVA: 0x003B944B File Offset: 0x003B764B
	[NullableContext(1)]
	public PinballBattleBossSkillTips(UiViewInfo viewInfo) : base(viewInfo)
	{
	}

	// Token: 0x0600DD8D RID: 56717 RVA: 0x003B9454 File Offset: 0x003B7654
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

	// Token: 0x0600DD8E RID: 56718 RVA: 0x003B949C File Offset: 0x003B769C
	protected override void OnStart()
	{
		base.OnStart();
		IPinballBattleBossSkillTipsParam pinballBattleBossSkillTipsParam = this.OpenParam as IPinballBattleBossSkillTipsParam;
		UUIText text = base.GetText(0);
		if (text == null)
		{
			return;
		}
		text.ShowTextNew(pinballBattleBossSkillTipsParam.TextId);
	}
}
