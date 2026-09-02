using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Ui;
using UnrealEngine;

// Token: 0x02001C7B RID: 7291
[NullableContext(2)]
[Nullable(0)]
public class FloroRanchUnlockSuccessPanel : UiPanelBase
{
	// Token: 0x17001128 RID: 4392
	// (get) Token: 0x0600D506 RID: 54534 RVA: 0x0038DB40 File Offset: 0x0038BD40
	// (set) Token: 0x0600D507 RID: 54535 RVA: 0x0038DB48 File Offset: 0x0038BD48
	public UiBehaviorLevelSequence UiLevelSequence { get; set; }

	// Token: 0x0600D508 RID: 54536 RVA: 0x0038DB54 File Offset: 0x0038BD54
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
		*span2[num] = new ValueTuple<int, Delegate>(0, new Action(this.OnCloseBtnClick));
		this.BtnBindInfo = list2;
	}

	// Token: 0x0600D509 RID: 54537 RVA: 0x0038DBFA File Offset: 0x0038BDFA
	protected override void OnBeforeCreate()
	{
		this.UiLevelSequence = new UiBehaviorLevelSequence(this);
		base.AddUiBehavior(this.UiLevelSequence);
	}

	// Token: 0x0600D50A RID: 54538 RVA: 0x0038DC14 File Offset: 0x0038BE14
	[NullableContext(1)]
	public void RefreshPanel(string textId)
	{
		Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(1), textId, Array.Empty<object>());
		base.SetUiActive(true);
		UiBehaviorLevelSequence uiLevelSequence = this.UiLevelSequence;
		if (uiLevelSequence == null)
		{
			return;
		}
		uiLevelSequence.PlaySequence("Start", false, null);
	}

	// Token: 0x0600D50B RID: 54539 RVA: 0x0038DC60 File Offset: 0x0038BE60
	private void OnCloseBtnClick()
	{
		UiBehaviorLevelSequence uiLevelSequence = this.UiLevelSequence;
		if (uiLevelSequence == null)
		{
			return;
		}
		uiLevelSequence.PlaySequence("Close", false, null);
	}

	// Token: 0x02007FCB RID: 32715
	[NullableContext(0)]
	private class EComponents
	{
		// Token: 0x0402B7EC RID: 178156
		public const int BtnClose = 0;

		// Token: 0x0402B7ED RID: 178157
		public const int TextDes = 1;
	}
}
