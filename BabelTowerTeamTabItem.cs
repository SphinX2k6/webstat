using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Module.Util;
using UnrealEngine;

// Token: 0x02001220 RID: 4640
[NullableContext(1)]
[Nullable(new byte[]
{
	0,
	1
})]
public class BabelTowerTeamTabItem : GridProxyAbstract<string>
{
	// Token: 0x06007B76 RID: 31606 RVA: 0x00205B9C File Offset: 0x00203D9C
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
		*span2[num] = new ValueTuple<int, Delegate>(0, new Action<EToggleState>(this.OnToggleClick));
		this.BtnBindInfo = list2;
	}

	// Token: 0x06007B77 RID: 31607 RVA: 0x00205C63 File Offset: 0x00203E63
	protected override void OnStart()
	{
		UUIItem item = base.GetItem(2);
		if (item == null)
		{
			return;
		}
		item.SetUIActive(false);
	}

	// Token: 0x06007B78 RID: 31608 RVA: 0x00205C77 File Offset: 0x00203E77
	public override void Refresh(string data, bool isSelected, int gridIndex)
	{
		UUIText text = base.GetText(1);
		if (text != null)
		{
			text.ShowTextNew(data);
		}
		this.SetSelected(isSelected);
	}

	// Token: 0x06007B79 RID: 31609 RVA: 0x00205C93 File Offset: 0x00203E93
	public void SetToggleClickCallback(Action<EBabelTowerTeamTabType> callback)
	{
		this.ToggleClickCallback = callback;
	}

	// Token: 0x06007B7A RID: 31610 RVA: 0x00205C9C File Offset: 0x00203E9C
	private void OnToggleClick(EToggleState state)
	{
		if (state != EToggleState.ETT_Checked)
		{
			return;
		}
		Action<EBabelTowerTeamTabType> toggleClickCallback = this.ToggleClickCallback;
		if (toggleClickCallback == null)
		{
			return;
		}
		toggleClickCallback((EBabelTowerTeamTabType)base.GridIndex);
	}

	// Token: 0x06007B7B RID: 31611 RVA: 0x00205CBB File Offset: 0x00203EBB
	public override void OnSelected(bool fireEvent)
	{
		this.SetSelected(true);
		if (fireEvent)
		{
			Action<EBabelTowerTeamTabType> toggleClickCallback = this.ToggleClickCallback;
			if (toggleClickCallback == null)
			{
				return;
			}
			toggleClickCallback((EBabelTowerTeamTabType)base.GridIndex);
		}
	}

	// Token: 0x06007B7C RID: 31612 RVA: 0x00205CDD File Offset: 0x00203EDD
	public override void OnDeselected(bool fireEvent)
	{
		this.SetSelected(false);
	}

	// Token: 0x06007B7D RID: 31613 RVA: 0x00205CE6 File Offset: 0x00203EE6
	private void SetSelected(bool selected)
	{
		UUIExtendToggle extendToggle = base.GetExtendToggle(0);
		if (extendToggle == null)
		{
			return;
		}
		extendToggle.SetToggleStateForce(selected ? EToggleState.ETT_Checked : EToggleState.ETT_UnChecked, false, false, false);
	}

	// Token: 0x04003B1F RID: 15135
	[Nullable(2)]
	private Action<EBabelTowerTeamTabType> ToggleClickCallback;

	// Token: 0x02007587 RID: 30087
	[NullableContext(0)]
	private class ETabItem
	{
		// Token: 0x040288D2 RID: 166098
		public const int Toggle = 0;

		// Token: 0x040288D3 RID: 166099
		public const int Name = 1;

		// Token: 0x040288D4 RID: 166100
		public const int RedDot = 2;
	}
}
