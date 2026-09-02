using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.Util;
using UnrealEngine;

// Token: 0x020012F8 RID: 4856
[NullableContext(1)]
[Nullable(new byte[]
{
	0,
	1
})]
public class DangoMonopolyResultRoundItem : GridProxyAbstract<DangoMonopolyBoardData>
{
	// Token: 0x060083CF RID: 33743 RVA: 0x0022CFD4 File Offset: 0x0022B1D4
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUIExtendToggle)),
			new ValueTuple<int, Type>(1, typeof(UUIText))
		};
		this.BtnBindInfo = new List<ValueTuple<int, Delegate>>
		{
			new ValueTuple<int, Delegate>(0, new Action<EToggleState>(this.OnClickToggle))
		};
	}

	// Token: 0x060083D0 RID: 33744 RVA: 0x0022D03C File Offset: 0x0022B23C
	public override void Refresh(DangoMonopolyBoardData data, bool isSelected, int gridIndex)
	{
		this.ItemData = data;
		this.ItemData.LogInfo();
		UUIText text = base.GetText(1);
		if (text != null)
		{
			text.SetText(this.ItemData.GetPosition().ToString(), true);
		}
		UUIExtendToggle selfToggle = this.GetSelfToggle();
		if (selfToggle == null)
		{
			return;
		}
		selfToggle.SetToggleState(isSelected ? EToggleState.ETT_Checked : EToggleState.ETT_UnChecked, false, false, false);
	}

	// Token: 0x060083D1 RID: 33745 RVA: 0x0022D09C File Offset: 0x0022B29C
	private void OnClickToggle(EToggleState toggleState)
	{
		if (toggleState == EToggleState.ETT_Checked)
		{
			IScrollViewDelegate<IGridProxy<DangoMonopolyBoardData>, DangoMonopolyBoardData> scrollViewDelegate = base.ScrollViewDelegate;
			if (scrollViewDelegate == null)
			{
				return;
			}
			scrollViewDelegate.SelectGridProxy(base.GridIndex, base.DisplayIndex, false);
		}
	}

	// Token: 0x060083D2 RID: 33746 RVA: 0x0022D0BF File Offset: 0x0022B2BF
	public override void OnSelected(bool fireEvent)
	{
		UUIExtendToggle selfToggle = this.GetSelfToggle();
		if (selfToggle != null)
		{
			selfToggle.SetToggleState(EToggleState.ETT_Checked, false, false, false);
		}
		Action<DangoMonopolyBoardData> clickCallBack = this.ClickCallBack;
		if (clickCallBack == null)
		{
			return;
		}
		clickCallBack(this.ItemData);
	}

	// Token: 0x060083D3 RID: 33747 RVA: 0x0022D0ED File Offset: 0x0022B2ED
	public override void OnDeselected(bool fireEvent)
	{
		UUIExtendToggle selfToggle = this.GetSelfToggle();
		if (selfToggle == null)
		{
			return;
		}
		selfToggle.SetToggleState(EToggleState.ETT_UnChecked, false, false, false);
	}

	// Token: 0x060083D4 RID: 33748 RVA: 0x0022D104 File Offset: 0x0022B304
	public UUIExtendToggle GetSelfToggle()
	{
		return base.GetExtendToggle(0);
	}

	// Token: 0x04003E91 RID: 16017
	private DangoMonopolyBoardData ItemData;

	// Token: 0x04003E92 RID: 16018
	[Nullable(new byte[]
	{
		2,
		1
	})]
	public Action<DangoMonopolyBoardData> ClickCallBack;

	// Token: 0x0200768E RID: 30350
	[NullableContext(0)]
	private enum EChildType
	{
		// Token: 0x04028D99 RID: 167321
		ToggleSelf,
		// Token: 0x04028D9A RID: 167322
		TxtIndex
	}
}
