using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Ui;
using UnrealEngine;

// Token: 0x02001671 RID: 5745
public class WheelTowerChallengeBtn : UiPanelBase
{
	// Token: 0x0600A0B4 RID: 41140 RVA: 0x002A1820 File Offset: 0x0029FA20
	protected unsafe override void OnRegisterComponent()
	{
		int num = 4;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int num2 = 0;
		*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIButtonComponent));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIItem));
		this.ComponentRegisterInfos = list;
		num2 = 1;
		List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
		CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
		Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
		num = 0;
		*span2[num] = new ValueTuple<int, Delegate>(0, new Action(this.ButtonClick));
		this.BtnBindInfo = list2;
	}

	// Token: 0x0600A0B5 RID: 41141 RVA: 0x002A1908 File Offset: 0x0029FB08
	public void SetRedDotVisible(bool visible)
	{
		UUIItem item = base.GetItem(3);
		if (item == null)
		{
			return;
		}
		item.SetUIActive(visible);
	}

	// Token: 0x0600A0B6 RID: 41142 RVA: 0x002A191C File Offset: 0x0029FB1C
	public void SetEnableClick(bool state)
	{
		UUIButtonComponent button = base.GetButton(0);
		if (button == null)
		{
			return;
		}
		button.SetSelfInteractive(state);
	}

	// Token: 0x0600A0B7 RID: 41143 RVA: 0x002A1930 File Offset: 0x0029FB30
	[NullableContext(1)]
	public void SetFunction(Action buttonFunction)
	{
		this.ButtonFunction = buttonFunction;
	}

	// Token: 0x0600A0B8 RID: 41144 RVA: 0x002A1939 File Offset: 0x0029FB39
	public void ExecuteButtonFunction()
	{
		Action buttonFunction = this.ButtonFunction;
		if (buttonFunction == null)
		{
			return;
		}
		buttonFunction();
	}

	// Token: 0x0600A0B9 RID: 41145 RVA: 0x002A194B File Offset: 0x0029FB4B
	private void ButtonClick()
	{
		this.ExecuteButtonFunction();
	}

	// Token: 0x04004A65 RID: 19045
	[Nullable(2)]
	private Action ButtonFunction;
}
