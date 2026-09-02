using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Ui;
using UnrealEngine;

// Token: 0x02001532 RID: 5426
public class RegressBpLevelUpTipsView : UiViewBase
{
	// Token: 0x06009806 RID: 38918 RVA: 0x0027CBC7 File Offset: 0x0027ADC7
	[NullableContext(1)]
	public RegressBpLevelUpTipsView(UiViewInfo viewInfo) : base(viewInfo)
	{
	}

	// Token: 0x06009807 RID: 38919 RVA: 0x0027CBD0 File Offset: 0x0027ADD0
	protected unsafe override void OnRegisterComponent()
	{
		int num = 4;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int num2 = 0;
		*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIText));
		this.ComponentRegisterInfos = list;
	}

	// Token: 0x06009808 RID: 38920 RVA: 0x0027CC7C File Offset: 0x0027AE7C
	protected override void OnStart()
	{
		IRegressBpLevelUpTipsData regressBpLevelUpTipsData = this.OpenParam as IRegressBpLevelUpTipsData;
		if (regressBpLevelUpTipsData != null)
		{
			int? num = regressBpLevelUpTipsData.PrevLevel;
			if (num != null)
			{
				UUIItem item = base.GetItem(2);
				if (item != null)
				{
					item.SetUIActive(true);
				}
				UUIText text = base.GetText(3);
				if (text != null)
				{
					text.SetUIActive(false);
				}
				UUIText text2 = base.GetText(0);
				if (text2 != null)
				{
					num = regressBpLevelUpTipsData.PrevLevel;
					text2.SetText(((num != null) ? num.GetValueOrDefault().ToString() : null) ?? "", true);
				}
				UUIText text3 = base.GetText(1);
				if (text3 == null)
				{
					goto IL_EF;
				}
				num = regressBpLevelUpTipsData.CurLevel;
				text3.SetText(((num != null) ? num.GetValueOrDefault().ToString() : null) ?? "", true);
				goto IL_EF;
			}
		}
		UUIItem item2 = base.GetItem(2);
		if (item2 != null)
		{
			item2.SetUIActive(false);
		}
		UUIText text4 = base.GetText(3);
		if (text4 != null)
		{
			text4.SetUIActive(true);
		}
		IL_EF:
		TimerSystem.GameplayTimeInstance.Delay(delegate(float _)
		{
			base.CloseMe(null);
		}, 2000f, null, null, true, 1f);
	}

	// Token: 0x020078E0 RID: 30944
	private class ELevelUpTipsComponents
	{
		// Token: 0x040298BC RID: 170172
		public const int TxtCurLevel = 0;

		// Token: 0x040298BD RID: 170173
		public const int TxtTargetLevel = 1;

		// Token: 0x040298BE RID: 170174
		public const int PanelLevelUpDesc = 2;

		// Token: 0x040298BF RID: 170175
		public const int TxtOpenTips = 3;
	}
}
