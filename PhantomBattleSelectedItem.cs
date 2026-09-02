using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Ui;
using UnrealEngine;

// Token: 0x02002495 RID: 9365
public class PhantomBattleSelectedItem : UiPanelBase
{
	// Token: 0x060122B9 RID: 74425 RVA: 0x004FF639 File Offset: 0x004FD839
	[NullableContext(1)]
	public PhantomBattleSelectedItem(UUIItem uiItem)
	{
		base.CreateThenShowByActor(uiItem.GetOwner(), null);
	}

	// Token: 0x060122BA RID: 74426 RVA: 0x004FF650 File Offset: 0x004FD850
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUIItem)),
			new ValueTuple<int, Type>(1, typeof(UUIText)),
			new ValueTuple<int, Type>(2, typeof(UUIItem)),
			new ValueTuple<int, Type>(3, typeof(UUIItem))
		};
		this.BtnBindInfo = new List<ValueTuple<int, Delegate>>();
	}

	// Token: 0x060122BB RID: 74427 RVA: 0x004FF6CB File Offset: 0x004FD8CB
	protected override void OnStart()
	{
		base.GetItem(0).SetUIActive(true);
		base.GetItem(2).SetUIActive(false);
	}

	// Token: 0x060122BC RID: 74428 RVA: 0x004FF6E8 File Offset: 0x004FD8E8
	public void UpdateSelectedItem(int current, int sum)
	{
		string newText;
		if (current != sum)
		{
			DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(47, 2);
			defaultInterpolatedStringHandler.AppendLiteral("<color=#9d2437>");
			defaultInterpolatedStringHandler.AppendFormatted<int>(current);
			defaultInterpolatedStringHandler.AppendLiteral("</color><color=#ffffff>/");
			defaultInterpolatedStringHandler.AppendFormatted<int>(sum);
			defaultInterpolatedStringHandler.AppendLiteral("</color>");
			newText = defaultInterpolatedStringHandler.ToStringAndClear();
		}
		else
		{
			DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(47, 2);
			defaultInterpolatedStringHandler.AppendLiteral("<color=#ffffff>");
			defaultInterpolatedStringHandler.AppendFormatted<int>(current);
			defaultInterpolatedStringHandler.AppendLiteral("</color><color=#ffffff>/");
			defaultInterpolatedStringHandler.AppendFormatted<int>(sum);
			defaultInterpolatedStringHandler.AppendLiteral("</color>");
			newText = defaultInterpolatedStringHandler.ToStringAndClear();
		}
		base.GetText(1).SetText(newText, true);
	}

	// Token: 0x020087B2 RID: 34738
	private enum ESelectedItemComponent
	{
		// Token: 0x0402DDD9 RID: 187865
		SelectedItem,
		// Token: 0x0402DDDA RID: 187866
		SelectedNumText,
		// Token: 0x0402DDDB RID: 187867
		DecomposeItem,
		// Token: 0x0402DDDC RID: 187868
		DecomposeButton
	}
}
