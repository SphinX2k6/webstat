using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Ui;
using UnrealEngine;

// Token: 0x02001F43 RID: 8003
public class MascotCollectBookToggleItem : UiPanelBase
{
	// Token: 0x0600EF78 RID: 61304 RVA: 0x00416FCC File Offset: 0x004151CC
	protected unsafe override void OnRegisterComponent()
	{
		int num = 2;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int num2 = 0;
		*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIExtendToggle));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIItem));
		this.ComponentRegisterInfos = list;
		num2 = 1;
		List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
		CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
		Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
		num = 0;
		*span2[num] = new ValueTuple<int, Delegate>(0, new Action<EToggleState>(this.OnToggle));
		this.BtnBindInfo = list2;
	}

	// Token: 0x0600EF79 RID: 61305 RVA: 0x00417072 File Offset: 0x00415272
	protected override void OnStart()
	{
		base.GetItem(1).SetUIActive(false);
	}

	// Token: 0x0600EF7A RID: 61306 RVA: 0x00417081 File Offset: 0x00415281
	public void SetSelectType(HonamiStoryMascotCollectBookView.EMascotCollectBookType type)
	{
		this.SelectType = type;
		this.RefreshToggleItem(this.SelectType);
	}

	// Token: 0x0600EF7B RID: 61307 RVA: 0x00417096 File Offset: 0x00415296
	[NullableContext(1)]
	public void BindToggleCallBack(Action<HonamiStoryMascotCollectBookView.EMascotCollectBookType> callBack)
	{
		this.ToggleCallBack = callBack;
	}

	// Token: 0x0600EF7C RID: 61308 RVA: 0x0041709F File Offset: 0x0041529F
	public void SetRedDotVisible(bool visible)
	{
		base.GetItem(1).SetUIActive(visible);
	}

	// Token: 0x0600EF7D RID: 61309 RVA: 0x004170AE File Offset: 0x004152AE
	public void RefreshToggleItem(HonamiStoryMascotCollectBookView.EMascotCollectBookType curSelectType)
	{
		if (curSelectType == this.SelectType)
		{
			this.OnSelected();
			return;
		}
		this.OnDeselected();
	}

	// Token: 0x0600EF7E RID: 61310 RVA: 0x004170C6 File Offset: 0x004152C6
	private void OnToggle(EToggleState toggleState)
	{
		Action<HonamiStoryMascotCollectBookView.EMascotCollectBookType> toggleCallBack = this.ToggleCallBack;
		if (toggleCallBack == null)
		{
			return;
		}
		toggleCallBack(this.SelectType);
	}

	// Token: 0x0600EF7F RID: 61311 RVA: 0x004170DE File Offset: 0x004152DE
	private void OnSelected()
	{
		base.GetExtendToggle(0).SetToggleStateForce(EToggleState.ETT_Checked, false, false, false);
	}

	// Token: 0x0600EF80 RID: 61312 RVA: 0x004170F0 File Offset: 0x004152F0
	private void OnDeselected()
	{
		base.GetExtendToggle(0).SetToggleStateForce(EToggleState.ETT_UnChecked, false, false, false);
	}

	// Token: 0x0400732F RID: 29487
	private HonamiStoryMascotCollectBookView.EMascotCollectBookType SelectType;

	// Token: 0x04007330 RID: 29488
	[Nullable(2)]
	private Action<HonamiStoryMascotCollectBookView.EMascotCollectBookType> ToggleCallBack;
}
