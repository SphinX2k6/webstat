using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Ui;
using UnrealEngine;

// Token: 0x02001854 RID: 6228
[NullableContext(1)]
[Nullable(0)]
public class ChatOptionButton : UiPanelBase
{
	// Token: 0x0600B225 RID: 45605 RVA: 0x002F8782 File Offset: 0x002F6982
	public ChatOptionButton(UUIItem uiItem)
	{
		base.CreateThenShowByActor(uiItem.GetOwner(), null);
	}

	// Token: 0x0600B226 RID: 45606 RVA: 0x002F8798 File Offset: 0x002F6998
	protected unsafe override void OnRegisterComponent()
	{
		int num = 2;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int num2 = 0;
		*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIButtonComponent));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIText));
		this.ComponentRegisterInfos = list;
		num2 = 1;
		List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
		CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
		Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
		num = 0;
		*span2[num] = new ValueTuple<int, Delegate>(0, new Action(this.OnClickButton));
		this.BtnBindInfo = list2;
	}

	// Token: 0x0600B227 RID: 45607 RVA: 0x002F883E File Offset: 0x002F6A3E
	private void OnClickButton()
	{
		Action clickCallBack = this.ClickCallBack;
		if (clickCallBack == null)
		{
			return;
		}
		clickCallBack();
	}

	// Token: 0x0600B228 RID: 45608 RVA: 0x002F8850 File Offset: 0x002F6A50
	public void RefreshButtonText(string str)
	{
		base.GetText(1).SetText(str, true);
	}

	// Token: 0x0600B229 RID: 45609 RVA: 0x002F8860 File Offset: 0x002F6A60
	public void SetClickCallBack(Action call)
	{
		this.ClickCallBack = call;
	}

	// Token: 0x04005467 RID: 21607
	[Nullable(2)]
	private Action ClickCallBack;

	// Token: 0x02007BF4 RID: 31732
	[NullableContext(0)]
	private class EChatOptionButtonType
	{
		// Token: 0x0402A5A3 RID: 173475
		public const int Button = 0;

		// Token: 0x0402A5A4 RID: 173476
		public const int Text = 1;
	}
}
