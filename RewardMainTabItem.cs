using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Ui;
using UnrealEngine;

// Token: 0x02001412 RID: 5138
public class RewardMainTabItem : CommonTabItemBase, ITabViewRegister
{
	// Token: 0x06008E5B RID: 36443 RVA: 0x00256714 File Offset: 0x00254914
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUIExtendToggle)),
			new ValueTuple<int, Type>(1, typeof(UUIItem))
		};
		this.BtnBindInfo = new List<ValueTuple<int, Delegate>>
		{
			new ValueTuple<int, Delegate>(0, new Action<EToggleState>(this.OnToggle))
		};
	}

	// Token: 0x06008E5C RID: 36444 RVA: 0x0025677B File Offset: 0x0025497B
	protected override void OnStart()
	{
		this.SetRedDotVisible(false);
	}

	// Token: 0x06008E5D RID: 36445 RVA: 0x00256784 File Offset: 0x00254984
	[NullableContext(1)]
	public void RegisterViewModule(UiTabViewBase tabView)
	{
		tabView.AddUiTabViewBehavior<UiTabSequence>().SetRootItem(tabView);
	}

	// Token: 0x06008E5E RID: 36446 RVA: 0x00256792 File Offset: 0x00254992
	public void SetRedDotVisible(bool bVisible)
	{
		base.GetItem(1).SetUIActive(bVisible);
	}

	// Token: 0x06008E5F RID: 36447 RVA: 0x002567A1 File Offset: 0x002549A1
	[NullableContext(1)]
	protected override void OnUpdateTabIcon(string iconPath)
	{
	}

	// Token: 0x06008E60 RID: 36448 RVA: 0x002567A3 File Offset: 0x002549A3
	protected override void OnSetToggleState(EToggleState state, bool bFire)
	{
		base.GetExtendToggle(0).SetToggleState(state, bFire, false, false);
	}

	// Token: 0x06008E61 RID: 36449 RVA: 0x002567B6 File Offset: 0x002549B6
	[NullableContext(1)]
	protected override UUIExtendToggle GetTabToggle()
	{
		return base.GetExtendToggle(0);
	}

	// Token: 0x06008E62 RID: 36450 RVA: 0x002567BF File Offset: 0x002549BF
	protected void OnToggle(EToggleState state)
	{
		if (state == EToggleState.ETT_Checked && this.SelectedCallBack != null)
		{
			this.SelectedCallBack(this.TabIndex);
		}
	}

	// Token: 0x0400425C RID: 16988
	public int TabIndex;

	// Token: 0x02007800 RID: 30720
	private class EComponentDefine
	{
		// Token: 0x04029487 RID: 169095
		public const int Toggle = 0;

		// Token: 0x04029488 RID: 169096
		public const int RedDot = 1;
	}
}
