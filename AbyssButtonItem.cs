using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Ui;
using UnrealEngine;

// Token: 0x02001AC8 RID: 6856
[NullableContext(1)]
[Nullable(0)]
public class AbyssButtonItem : UiPanelBase
{
	// Token: 0x0600C567 RID: 50535 RVA: 0x00342278 File Offset: 0x00340478
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
		*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIText));
		this.ComponentRegisterInfos = list;
		num2 = 1;
		List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
		CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
		Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
		num = 0;
		*span2[num] = new ValueTuple<int, Delegate>(0, new Action(this.ButtonCallBackInternal));
		this.BtnBindInfo = list2;
	}

	// Token: 0x0600C568 RID: 50536 RVA: 0x00342360 File Offset: 0x00340560
	public void RefreshRedDotVisible(bool visible)
	{
		base.GetItem(2).SetUIActive(visible);
	}

	// Token: 0x0600C569 RID: 50537 RVA: 0x0034236F File Offset: 0x0034056F
	public void SetNumText(string text)
	{
		base.GetText(1).SetText(text, true);
	}

	// Token: 0x0600C56A RID: 50538 RVA: 0x0034237F File Offset: 0x0034057F
	public void SetNameText(string text)
	{
		base.GetText(3).SetText(text, true);
	}

	// Token: 0x0600C56B RID: 50539 RVA: 0x0034238F File Offset: 0x0034058F
	private void ButtonCallBackInternal()
	{
		Action buttonCallBack = this.ButtonCallBack;
		if (buttonCallBack == null)
		{
			return;
		}
		buttonCallBack();
	}

	// Token: 0x0600C56C RID: 50540 RVA: 0x003423A1 File Offset: 0x003405A1
	public void SetSelfInteractive(bool interactive)
	{
		base.GetButton(0).SetSelfInteractive(interactive);
	}

	// Token: 0x0600C56D RID: 50541 RVA: 0x003423B0 File Offset: 0x003405B0
	public void BindClickCallBack(Action callBack)
	{
		this.ButtonCallBack = callBack;
	}

	// Token: 0x0600C56E RID: 50542 RVA: 0x003423B9 File Offset: 0x003405B9
	public void SetRedDotVisible(bool visible)
	{
		base.GetItem(2).SetUIActive(visible);
	}

	// Token: 0x0600C56F RID: 50543 RVA: 0x003423C8 File Offset: 0x003405C8
	public void BindRedDot(ERedDotName redDotName, int? uId = null)
	{
		UUIItem item = base.GetItem(2);
		if (item == null)
		{
			return;
		}
		this.UnBindRedDot();
		this.RedDotName = new ERedDotName?(redDotName);
		if (this.RedDotName != null)
		{
			ControllerBase<RedDotController>.Instance.BindRedDot(redDotName, item, null, uId.GetValueOrDefault());
		}
	}

	// Token: 0x0600C570 RID: 50544 RVA: 0x00342414 File Offset: 0x00340614
	public void UnBindRedDot()
	{
		if (this.RedDotName != null)
		{
			UUIItem item = base.GetItem(2);
			ControllerBase<RedDotController>.Instance.UnBindGivenUi(this.RedDotName.Value, item, 0);
			this.RedDotName = null;
		}
	}

	// Token: 0x04005EA0 RID: 24224
	private ERedDotName? RedDotName;

	// Token: 0x04005EA1 RID: 24225
	[Nullable(2)]
	public Action ButtonCallBack;

	// Token: 0x02007D9B RID: 32155
	[NullableContext(0)]
	private enum EButtonComponent
	{
		// Token: 0x0402AC81 RID: 175233
		Button,
		// Token: 0x0402AC82 RID: 175234
		NumText,
		// Token: 0x0402AC83 RID: 175235
		RedDot,
		// Token: 0x0402AC84 RID: 175236
		NameText
	}
}
