using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Ui;
using UnrealEngine;

// Token: 0x02001606 RID: 5638
[NullableContext(1)]
[Nullable(0)]
public class ActivityQuestTipsItem : UiPanelBase
{
	// Token: 0x06009F2C RID: 40748 RVA: 0x00299994 File Offset: 0x00297B94
	protected unsafe override void OnRegisterComponent()
	{
		int num = 2;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int num2 = 0;
		*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIButtonComponent));
		this.ComponentRegisterInfos = list;
		num2 = 1;
		List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
		CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
		Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
		num = 0;
		*span2[num] = new ValueTuple<int, Delegate>(1, new Action(this.ButtonClick));
		this.BtnBindInfo = list2;
	}

	// Token: 0x06009F2D RID: 40749 RVA: 0x00299A3A File Offset: 0x00297C3A
	public void SetContentByTextId(string textId, params string[] args)
	{
		Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(0), textId, args);
	}

	// Token: 0x06009F2E RID: 40750 RVA: 0x00299A4F File Offset: 0x00297C4F
	public void SetContentByText(string text)
	{
		base.GetText(0).SetText(text, true);
	}

	// Token: 0x06009F2F RID: 40751 RVA: 0x00299A5F File Offset: 0x00297C5F
	public void SetContentVisible(bool bVisible)
	{
		base.GetText(0).SetUIActive(bVisible);
	}

	// Token: 0x06009F30 RID: 40752 RVA: 0x00299A6E File Offset: 0x00297C6E
	private void ButtonClick()
	{
		Action buttonFunction = this.ButtonFunction;
		if (buttonFunction == null)
		{
			return;
		}
		buttonFunction();
	}

	// Token: 0x06009F31 RID: 40753 RVA: 0x00299A80 File Offset: 0x00297C80
	public void SetRewardButtonVisible(bool state)
	{
		base.GetItem(1).SetUIActive(state);
	}

	// Token: 0x06009F32 RID: 40754 RVA: 0x00299A8F File Offset: 0x00297C8F
	public void SetRewardButtonFunction(Action buttonFunction)
	{
		this.ButtonFunction = buttonFunction;
	}

	// Token: 0x04004903 RID: 18691
	[Nullable(2)]
	private Action ButtonFunction;

	// Token: 0x020079D1 RID: 31185
	[NullableContext(0)]
	private class EComponents
	{
		// Token: 0x04029D10 RID: 171280
		public const int TxtTips = 0;

		// Token: 0x04029D11 RID: 171281
		public const int ButtonGo = 1;
	}
}
