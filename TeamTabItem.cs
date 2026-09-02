using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Module.Util;
using UnrealEngine;

// Token: 0x020016AB RID: 5803
[NullableContext(1)]
[Nullable(new byte[]
{
	0,
	1
})]
internal class TeamTabItem : GridProxyAbstract<string>
{
	// Token: 0x0600A184 RID: 41348 RVA: 0x002A72CC File Offset: 0x002A54CC
	protected unsafe override void OnRegisterComponent()
	{
		int num = 3;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int num2 = 0;
		*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIExtendToggle));
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
		*span2[num] = new ValueTuple<int, Delegate>(0, new Action<EToggleState>(this.ToggleClick));
		this.BtnBindInfo = list2;
	}

	// Token: 0x0600A185 RID: 41349 RVA: 0x002A7393 File Offset: 0x002A5593
	protected override void OnStart()
	{
		UUIItem item = base.GetItem(2);
		if (item == null)
		{
			return;
		}
		item.SetUIActive(false);
	}

	// Token: 0x0600A186 RID: 41350 RVA: 0x002A73A7 File Offset: 0x002A55A7
	public override void Refresh(string data, bool isSelected, int gridIndex)
	{
		UUIText text = base.GetText(1);
		if (text != null)
		{
			text.ShowTextNew(data);
		}
		this.SetSelectedState(isSelected);
	}

	// Token: 0x0600A187 RID: 41351 RVA: 0x002A73C3 File Offset: 0x002A55C3
	public override void OnSelected(bool fireEvent)
	{
		this.SetSelectedState(true);
	}

	// Token: 0x0600A188 RID: 41352 RVA: 0x002A73CC File Offset: 0x002A55CC
	public override void OnDeselected(bool fireEvent)
	{
		this.SetSelectedState(false);
	}

	// Token: 0x0600A189 RID: 41353 RVA: 0x002A73D5 File Offset: 0x002A55D5
	public void SetToggleClickCallback(Action<int> callback)
	{
		this.ToggleClickCallback = callback;
	}

	// Token: 0x0600A18A RID: 41354 RVA: 0x002A73DE File Offset: 0x002A55DE
	private void ToggleClick(EToggleState state)
	{
		if (state != EToggleState.ETT_Checked)
		{
			return;
		}
		Action<int> toggleClickCallback = this.ToggleClickCallback;
		if (toggleClickCallback == null)
		{
			return;
		}
		toggleClickCallback(base.GridIndex);
	}

	// Token: 0x0600A18B RID: 41355 RVA: 0x002A73FB File Offset: 0x002A55FB
	private void SetSelectedState(bool selected)
	{
		UUIExtendToggle extendToggle = base.GetExtendToggle(0);
		if (extendToggle == null)
		{
			return;
		}
		extendToggle.SetToggleStateForce(selected ? EToggleState.ETT_Checked : EToggleState.ETT_UnChecked, false, false, false);
	}

	// Token: 0x04004B7A RID: 19322
	[Nullable(2)]
	private Action<int> ToggleClickCallback;
}
