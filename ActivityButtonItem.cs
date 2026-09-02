using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Ui;
using UnrealEngine;

// Token: 0x02001600 RID: 5632
[NullableContext(1)]
[Nullable(0)]
public class ActivityButtonItem : UiPanelBase
{
	// Token: 0x06009EB9 RID: 40633 RVA: 0x002985B0 File Offset: 0x002967B0
	protected unsafe override void OnRegisterComponent()
	{
		int num = 3;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int num2 = 0;
		*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIButtonComponent));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIItem));
		this.ComponentRegisterInfos = list;
		num2 = 1;
		List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
		CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
		Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
		num = 0;
		*span2[num] = new ValueTuple<int, Delegate>(0, new Action(this.ButtonClick));
		this.BtnBindInfo = list2;
	}

	// Token: 0x06009EBA RID: 40634 RVA: 0x00298677 File Offset: 0x00296877
	protected override void OnBeforeDestroy()
	{
		this.ButtonFunction = null;
		this.ExtraButtonFunctionSet.Clear();
		this.UnBindGivenUid(this.RedDotUid);
	}

	// Token: 0x06009EBB RID: 40635 RVA: 0x00298698 File Offset: 0x00296898
	[return: Nullable(new byte[]
	{
		2,
		1
	})]
	public override UUIItem[] GetGuideUiItemAndUiItemForShowEx(string[] configParams)
	{
		UUIButtonComponent button = base.GetButton(0);
		TWeakObjectPtr<UUIItem>? tweakObjectPtr = (button != null) ? new TWeakObjectPtr<UUIItem>?(button.RootUIComp) : null;
		if (tweakObjectPtr == null)
		{
			return null;
		}
		UUIItem[] array = new UUIItem[2];
		int num = 0;
		TWeakObjectPtr<UUIItem>? tweakObjectPtr2 = tweakObjectPtr;
		array[num] = ((tweakObjectPtr2 != null) ? tweakObjectPtr2.GetValueOrDefault() : null);
		int num2 = 1;
		tweakObjectPtr2 = tweakObjectPtr;
		array[num2] = ((tweakObjectPtr2 != null) ? tweakObjectPtr2.GetValueOrDefault() : null);
		return array;
	}

	// Token: 0x06009EBC RID: 40636 RVA: 0x00298714 File Offset: 0x00296914
	private void ButtonClick()
	{
		Action buttonFunction = this.ButtonFunction;
		if (buttonFunction != null)
		{
			buttonFunction();
		}
		foreach (Action action in this.ExtraButtonFunctionSet)
		{
			action();
		}
	}

	// Token: 0x06009EBD RID: 40637 RVA: 0x00298778 File Offset: 0x00296978
	public void SetButtonAllowEventBubbleUp(bool value)
	{
		base.GetButton(0).AllowEventBubbleUp = value;
	}

	// Token: 0x06009EBE RID: 40638 RVA: 0x00298788 File Offset: 0x00296988
	public void SetText(string text)
	{
		UUIText text2 = base.GetText(1);
		if (text2 != null)
		{
			text2.SetText(text, true);
		}
	}

	// Token: 0x06009EBF RID: 40639 RVA: 0x002987A8 File Offset: 0x002969A8
	public void SetLocalTextNew(string textId, params object[] args)
	{
		Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(1), textId, args);
	}

	// Token: 0x06009EC0 RID: 40640 RVA: 0x002987BD File Offset: 0x002969BD
	public void SetShowText(string text)
	{
		base.GetText(1).ShowTextNew(text);
	}

	// Token: 0x06009EC1 RID: 40641 RVA: 0x002987CC File Offset: 0x002969CC
	public void SetEnableClick(bool state)
	{
		UUIButtonComponent button = base.GetButton(0);
		if (button == null)
		{
			return;
		}
		button.SetSelfInteractive(state);
	}

	// Token: 0x06009EC2 RID: 40642 RVA: 0x002987E0 File Offset: 0x002969E0
	public void SetFunction(Action buttonFunction)
	{
		this.ButtonFunction = buttonFunction;
	}

	// Token: 0x06009EC3 RID: 40643 RVA: 0x002987E9 File Offset: 0x002969E9
	public void SetExtraFunction(Action buttonFunction)
	{
		this.ExtraButtonFunctionSet.Add(buttonFunction);
	}

	// Token: 0x06009EC4 RID: 40644 RVA: 0x002987F8 File Offset: 0x002969F8
	public void DeleteExtraFunction(Action buttonFunction)
	{
		this.ExtraButtonFunctionSet.Remove(buttonFunction);
	}

	// Token: 0x06009EC5 RID: 40645 RVA: 0x00298807 File Offset: 0x00296A07
	public void SetRedDotVisible(bool bVisible)
	{
		base.GetItem(2).SetUIActive(bVisible);
	}

	// Token: 0x06009EC6 RID: 40646 RVA: 0x00298818 File Offset: 0x00296A18
	public void BindRedDot(ERedDotName redDotName, int uId = 0)
	{
		UUIItem item = base.GetItem(2);
		if (item == null)
		{
			return;
		}
		this.RedDotName = new ERedDotName?(redDotName);
		this.RedDotUid = uId;
		if (this.RedDotName != null)
		{
			ControllerBase<RedDotController>.Instance.BindRedDot(redDotName, item, null, uId);
		}
	}

	// Token: 0x06009EC7 RID: 40647 RVA: 0x0029885F File Offset: 0x00296A5F
	public void UnBindGivenUid(int uId)
	{
		if (this.RedDotName != null)
		{
			ControllerBase<RedDotController>.Instance.UnBindGivenUi(this.RedDotName.Value, base.GetItem(2), uId);
			this.RedDotName = null;
			this.RedDotUid = 0;
		}
	}

	// Token: 0x06009EC8 RID: 40648 RVA: 0x0029889E File Offset: 0x00296A9E
	public void UnBindRedDot()
	{
		if (this.RedDotName != null)
		{
			ControllerBase<RedDotController>.Instance.UnBindRedDot(this.RedDotName.Value);
			this.RedDotName = null;
			this.RedDotUid = 0;
		}
	}

	// Token: 0x040048F3 RID: 18675
	private ERedDotName? RedDotName;

	// Token: 0x040048F4 RID: 18676
	private int RedDotUid;

	// Token: 0x040048F5 RID: 18677
	private readonly HashSet<Action> ExtraButtonFunctionSet = new HashSet<Action>();

	// Token: 0x040048F6 RID: 18678
	[Nullable(2)]
	private Action ButtonFunction;

	// Token: 0x020079C0 RID: 31168
	[NullableContext(0)]
	private class EButtonItemDefine
	{
		// Token: 0x04029CD9 RID: 171225
		public const int Button = 0;

		// Token: 0x04029CDA RID: 171226
		public const int ButtonText = 1;

		// Token: 0x04029CDB RID: 171227
		public const int RedDot = 2;
	}
}
