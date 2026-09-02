using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Ui;
using UnrealEngine;

// Token: 0x02001697 RID: 5783
public class WheelTowerSettlementRoundPanel : UiPanelBase
{
	// Token: 0x0600A130 RID: 41264 RVA: 0x002A5120 File Offset: 0x002A3320
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

	// Token: 0x0600A131 RID: 41265 RVA: 0x002A5189 File Offset: 0x002A3389
	public void RefreshRoundScore(int roundScore)
	{
		UUIText text = base.GetText(1);
		if (text == null)
		{
			return;
		}
		text.SetText(roundScore.ToString(), true);
	}

	// Token: 0x0600A132 RID: 41266 RVA: 0x002A51A4 File Offset: 0x002A33A4
	[NullableContext(1)]
	public void RefreshRoundTitle(string title)
	{
		Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(0), title, Array.Empty<object>());
	}
}
