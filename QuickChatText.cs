using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Ui;
using UnrealEngine;

// Token: 0x02001859 RID: 6233
[NullableContext(1)]
[Nullable(0)]
public class QuickChatText : UiPanelBase
{
	// Token: 0x0600B284 RID: 45700 RVA: 0x002FAF96 File Offset: 0x002F9196
	public QuickChatText(AActor rootActor)
	{
		base.CreateThenShowByActor(rootActor, null);
	}

	// Token: 0x0600B285 RID: 45701 RVA: 0x002FAFB4 File Offset: 0x002F91B4
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
		*span2[num] = new ValueTuple<int, Delegate>(1, new Action(this.OnClickedQuickChatButton));
		this.BtnBindInfo = list2;
	}

	// Token: 0x0600B286 RID: 45702 RVA: 0x002FB05A File Offset: 0x002F925A
	protected override void OnBeforeDestroy()
	{
		this.OnClicked = null;
	}

	// Token: 0x0600B287 RID: 45703 RVA: 0x002FB063 File Offset: 0x002F9263
	private void OnClickedQuickChatButton()
	{
		Action<string> onClicked = this.OnClicked;
		if (onClicked == null)
		{
			return;
		}
		onClicked(this.QuickChatString);
	}

	// Token: 0x0600B288 RID: 45704 RVA: 0x002FB07B File Offset: 0x002F927B
	public void Refresh(string quickChatString)
	{
		base.GetText(0).SetText(quickChatString, true);
		this.QuickChatString = quickChatString;
	}

	// Token: 0x0600B289 RID: 45705 RVA: 0x002FB092 File Offset: 0x002F9292
	public void BindOnClicked(Action<string> onClicked)
	{
		this.OnClicked = onClicked;
	}

	// Token: 0x0400547B RID: 21627
	private string QuickChatString = "";

	// Token: 0x0400547C RID: 21628
	[Nullable(new byte[]
	{
		2,
		1
	})]
	private Action<string> OnClicked;

	// Token: 0x02007BFF RID: 31743
	[NullableContext(0)]
	private class EChildType
	{
		// Token: 0x0402A5E7 RID: 173543
		public const int QuickChatText = 0;

		// Token: 0x0402A5E8 RID: 173544
		public const int QuickChatButton = 1;
	}
}
