using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.Util;
using UnrealEngine;

// Token: 0x02001416 RID: 5142
[NullableContext(1)]
[Nullable(new byte[]
{
	0,
	1
})]
public class RewardTargetTabItem : GridProxyAbstract<RewardTabData>
{
	// Token: 0x06008E84 RID: 36484 RVA: 0x00256E20 File Offset: 0x00255020
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUIText)),
			new ValueTuple<int, Type>(1, typeof(UUIExtendToggle)),
			new ValueTuple<int, Type>(2, typeof(UUIItem))
		};
		this.BtnBindInfo = new List<ValueTuple<int, Delegate>>
		{
			new ValueTuple<int, Delegate>(1, new Action<EToggleState>(this.OnTabToggle))
		};
	}

	// Token: 0x06008E85 RID: 36485 RVA: 0x00256EA0 File Offset: 0x002550A0
	public void SetToggleState(bool bSelect, bool bFire)
	{
		EToggleState state = bSelect ? EToggleState.ETT_Checked : EToggleState.ETT_UnChecked;
		base.GetExtendToggle(1).SetToggleState(state, bFire, false, false);
	}

	// Token: 0x06008E86 RID: 36486 RVA: 0x00256EC6 File Offset: 0x002550C6
	private void SetRedDotVisible(bool bVisible)
	{
		base.GetItem(2).SetUIActive(bVisible);
	}

	// Token: 0x06008E87 RID: 36487 RVA: 0x00256ED5 File Offset: 0x002550D5
	public override void Refresh(RewardTabData data, bool isSelected, int gridIndex)
	{
		this.TabData = data;
		this.TabIndex = data.Index;
		if (data.NameTextId != null)
		{
			base.GetText(0).ShowTextNew(data.NameTextId);
		}
		this.RefreshRedDot();
	}

	// Token: 0x06008E88 RID: 36488 RVA: 0x00256F0C File Offset: 0x0025510C
	public void RefreshRedDot()
	{
		bool redDotVisible = this.TabData != null && this.TabData.RefreshRedDot != null && this.TabData.RefreshRedDot(this.TabIndex + 1);
		this.SetRedDotVisible(redDotVisible);
	}

	// Token: 0x06008E89 RID: 36489 RVA: 0x00256F51 File Offset: 0x00255151
	private void OnTabToggle(EToggleState state)
	{
		if (this.TabData != null && this.TabData.ClickedCallback != null)
		{
			this.TabData.ClickedCallback(this.TabIndex);
		}
	}

	// Token: 0x04004264 RID: 16996
	private RewardTabData TabData;

	// Token: 0x04004265 RID: 16997
	private int TabIndex = -1;

	// Token: 0x02007809 RID: 30729
	[NullableContext(0)]
	private class EComponentDefine
	{
		// Token: 0x040294A7 RID: 169127
		public const int Name = 0;

		// Token: 0x040294A8 RID: 169128
		public const int Toggle = 1;

		// Token: 0x040294A9 RID: 169129
		public const int RedDot = 2;
	}
}
