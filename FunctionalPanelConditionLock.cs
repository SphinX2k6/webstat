using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Ui;
using UnrealEngine;

// Token: 0x02001604 RID: 5636
[NullableContext(2)]
[Nullable(0)]
public class FunctionalPanelConditionLock : UiPanelBase
{
	// Token: 0x17000D6D RID: 3437
	// (get) Token: 0x06009F1C RID: 40732 RVA: 0x00299788 File Offset: 0x00297988
	// (set) Token: 0x06009F1D RID: 40733 RVA: 0x00299790 File Offset: 0x00297990
	public Action ButtonCallBack { get; set; }

	// Token: 0x06009F1E RID: 40734 RVA: 0x0029979C File Offset: 0x0029799C
	protected unsafe override void OnRegisterComponent()
	{
		int num = 3;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int num2 = 0;
		*span[num2] = new ValueTuple<int, Type>(0, typeof(UUISprite));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIButtonComponent));
		this.ComponentRegisterInfos = list;
		num2 = 1;
		List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
		CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
		Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
		num = 0;
		*span2[num] = new ValueTuple<int, Delegate>(2, new Action(this.ButtonCallBackInternal));
		this.BtnBindInfo = list2;
	}

	// Token: 0x06009F1F RID: 40735 RVA: 0x00299863 File Offset: 0x00297A63
	[NullableContext(1)]
	public void SetTextByTextId(string textId, params string[] args)
	{
		Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(1), textId, args);
	}

	// Token: 0x06009F20 RID: 40736 RVA: 0x00299878 File Offset: 0x00297A78
	[NullableContext(1)]
	public void SetTextByText(string text)
	{
		base.GetText(1).SetText(text, true);
	}

	// Token: 0x06009F21 RID: 40737 RVA: 0x00299888 File Offset: 0x00297A88
	[NullableContext(1)]
	public UUISprite GetIconSprite()
	{
		return base.GetSprite(0);
	}

	// Token: 0x06009F22 RID: 40738 RVA: 0x00299891 File Offset: 0x00297A91
	public void SetSpriteVisible(bool bVisible)
	{
		base.GetSprite(0).SetUIActive(bVisible);
	}

	// Token: 0x06009F23 RID: 40739 RVA: 0x002998A0 File Offset: 0x00297AA0
	public void SetButtonVisible(bool bVisible)
	{
		base.GetButton(2).RootUIComp.Get().SetUIActive(bVisible);
	}

	// Token: 0x06009F24 RID: 40740 RVA: 0x002998C7 File Offset: 0x00297AC7
	private void ButtonCallBackInternal()
	{
		Action buttonCallBack = this.ButtonCallBack;
		if (buttonCallBack == null)
		{
			return;
		}
		buttonCallBack();
	}

	// Token: 0x020079CF RID: 31183
	[NullableContext(0)]
	private class ERedComponents
	{
		// Token: 0x04029D0B RID: 171275
		public const int Sprite = 0;

		// Token: 0x04029D0C RID: 171276
		public const int Txt = 1;

		// Token: 0x04029D0D RID: 171277
		public const int Button = 2;
	}
}
