using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.AutoAttach;
using UnrealEngine;

// Token: 0x020017F7 RID: 6135
[NullableContext(2)]
[Nullable(new byte[]
{
	0,
	1
})]
public class CalabashGrid : AutoAttachItem<CalabashGridData>
{
	// Token: 0x0600AE51 RID: 44625 RVA: 0x002E5D34 File Offset: 0x002E3F34
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUIItem)),
			new ValueTuple<int, Type>(1, typeof(UUIItem)),
			new ValueTuple<int, Type>(2, typeof(UUIItem)),
			new ValueTuple<int, Type>(3, typeof(UUIText)),
			new ValueTuple<int, Type>(4, typeof(UUIItem)),
			new ValueTuple<int, Type>(5, typeof(UUIItem)),
			new ValueTuple<int, Type>(6, typeof(UUISprite)),
			new ValueTuple<int, Type>(7, typeof(UUISprite)),
			new ValueTuple<int, Type>(8, typeof(UUIItem)),
			new ValueTuple<int, Type>(9, typeof(UUIExtendToggle)),
			new ValueTuple<int, Type>(10, typeof(UUIItem)),
			new ValueTuple<int, Type>(11, typeof(UUIItem)),
			new ValueTuple<int, Type>(12, typeof(UUIItem)),
			new ValueTuple<int, Type>(13, typeof(UUIItem))
		};
		this.BtnBindInfo = new List<ValueTuple<int, Delegate>>
		{
			new ValueTuple<int, Delegate>(9, new Action<EToggleState>(this.SelectedItem))
		};
	}

	// Token: 0x0600AE52 RID: 44626 RVA: 0x002E5EA9 File Offset: 0x002E40A9
	protected override void OnStart()
	{
		UUIExtendToggle extendToggle = base.GetExtendToggle(9);
		if (extendToggle == null)
		{
			return;
		}
		extendToggle.CanExecuteChange.Bind(new Func<bool>(this.CheckCanClick));
	}

	// Token: 0x0600AE53 RID: 44627 RVA: 0x002E5ECE File Offset: 0x002E40CE
	private bool CheckCanClick()
	{
		return this.CheckToggleCanClick == null || this.CheckToggleCanClick();
	}

	// Token: 0x0600AE54 RID: 44628 RVA: 0x002E5EE8 File Offset: 0x002E40E8
	[NullableContext(1)]
	protected override void OnRefreshItem(CalabashGridData data)
	{
		int level = data.Level;
		ECalabashRewardState receiveRewardStateByLevel = ModelBase<CalabashModel>.Instance.GetReceiveRewardStateByLevel(level);
		bool levelReach = ModelBase<CalabashModel>.Instance.GetCalabashLevel() >= level;
		this.LevelReach = levelReach;
		base.GetItem(4).SetUIActive(receiveRewardStateByLevel == ECalabashRewardState.CanReceive);
		base.GetItem(8).SetUIActive(receiveRewardStateByLevel == ECalabashRewardState.HasReceived);
		if (data.IsMaxLevel)
		{
			base.GetItem(5).SetUIActive(false);
		}
		else
		{
			base.GetItem(5).SetUIActive(true);
			int maxExp = data.MaxExp;
			int overFlowExp = data.OverFlowExp;
			base.GetSprite(6).SetFillAmount((float)overFlowExp / (float)maxExp);
			base.GetSprite(7).SetFillAmount((float)data.LimitExp / (float)maxExp);
		}
		bool currentSelectedState = base.GetCurrentSelectedState();
		UUIExtendToggle extendToggle = base.GetExtendToggle(9);
		if (extendToggle != null)
		{
			extendToggle.SetToggleState(currentSelectedState ? EToggleState.ETT_Checked : EToggleState.ETT_UnChecked, false, false, false);
		}
		this.SetSelectState(currentSelectedState);
		this.RefreshLevelText(level);
		this.RefreshLevelTextColor(currentSelectedState, levelReach);
		this.RefreshSpecialUi(level, levelReach);
		this.RefreshSpecialActiveEffectItem(levelReach, data.IsMaxLevel);
	}

	// Token: 0x0600AE55 RID: 44629 RVA: 0x002E5FF0 File Offset: 0x002E41F0
	private void RefreshSpecialReachItem(int level, bool levelReach)
	{
		UUIItem item = base.GetItem(10);
		if (item == null)
		{
			return;
		}
		item.SetUIActive(levelReach);
	}

	// Token: 0x0600AE56 RID: 44630 RVA: 0x002E6012 File Offset: 0x002E4212
	private void RefreshSpecialActiveEffectItem(bool levelReach, bool isMaxLevel)
	{
		UUIItem item = base.GetItem(12);
		if (item != null)
		{
			item.SetUIActive(levelReach && isMaxLevel);
		}
		UUIItem item2 = base.GetItem(13);
		if (item2 == null)
		{
			return;
		}
		item2.SetUIActive(levelReach && isMaxLevel);
	}

	// Token: 0x0600AE57 RID: 44631 RVA: 0x002E6040 File Offset: 0x002E4240
	private void RefreshSpecialInActiveItem(int level, bool levelReach)
	{
		bool uiactive = !levelReach;
		UUIItem item = base.GetItem(11);
		if (item == null)
		{
			return;
		}
		item.SetUIActive(uiactive);
	}

	// Token: 0x0600AE58 RID: 44632 RVA: 0x002E6068 File Offset: 0x002E4268
	private void RefreshSpecialUi(int level, bool levelReach)
	{
		if (ConfigBase<CalabashConfig>.Instance.GetCalabashConfigByLevel(level) == null)
		{
			this.RefreshSpecialReachItem(0, levelReach);
			this.RefreshSpecialInActiveItem(0, levelReach);
			return;
		}
		this.RefreshSpecialReachItem(level, levelReach);
		this.RefreshSpecialInActiveItem(level, levelReach);
	}

	// Token: 0x0600AE59 RID: 44633 RVA: 0x002E60AC File Offset: 0x002E42AC
	private void RefreshLevelText(int level)
	{
		UUIText text = base.GetText(3);
		if (text != null)
		{
			text.SetText(level.ToString(), true);
		}
	}

	// Token: 0x0600AE5A RID: 44634 RVA: 0x002E60D4 File Offset: 0x002E42D4
	private void RefreshLevelTextColor(bool isSelected, bool levelReach)
	{
		UUIText text = base.GetText(3);
		if (text != null)
		{
			UUIItem uuiitem = text;
			bool bUseChangeColor = !isSelected && !levelReach;
			FColor? fcolor = new FColor?(text.changeColor);
			uuiitem.SetChangeColor(bUseChangeColor, fcolor);
		}
	}

	// Token: 0x0600AE5B RID: 44635 RVA: 0x002E6106 File Offset: 0x002E4306
	private void SelectedItem(EToggleState toggleState)
	{
		Action<int> buttonFunction = this.ButtonFunction;
		if (buttonFunction == null)
		{
			return;
		}
		buttonFunction(this.CurrentShowItemIndex);
	}

	// Token: 0x0600AE5C RID: 44636 RVA: 0x002E611E File Offset: 0x002E431E
	public override void OnSelect()
	{
		this.SetSelectState(true);
		this.SelectedItem(EToggleState.ETT_Checked);
		UUIExtendToggle extendToggle = base.GetExtendToggle(9);
		if (extendToggle != null)
		{
			extendToggle.SetToggleState(EToggleState.ETT_Checked, false, false, false);
		}
		this.RefreshLevelTextColor(true, this.LevelReach);
	}

	// Token: 0x0600AE5D RID: 44637 RVA: 0x002E6154 File Offset: 0x002E4354
	protected override void OnUnSelect()
	{
		this.SetSelectState(false);
		bool bIngnoreAnim = true;
		if (base.GetCurrentSelectedState())
		{
			bIngnoreAnim = false;
		}
		UUIExtendToggle extendToggle = base.GetExtendToggle(9);
		if (extendToggle != null)
		{
			extendToggle.SetToggleState(EToggleState.ETT_UnChecked, false, bIngnoreAnim, false);
		}
		this.RefreshLevelTextColor(false, this.LevelReach);
	}

	// Token: 0x0600AE5E RID: 44638 RVA: 0x002E6199 File Offset: 0x002E4399
	public void SetSelectState(bool isSelected)
	{
	}

	// Token: 0x0600AE5F RID: 44639 RVA: 0x002E619B File Offset: 0x002E439B
	protected override void OnMoveItem()
	{
	}

	// Token: 0x0600AE60 RID: 44640 RVA: 0x002E619D File Offset: 0x002E439D
	public CalabashGrid() : base(null)
	{
	}

	// Token: 0x0400529D RID: 21149
	public Action<int> ButtonFunction;

	// Token: 0x0400529E RID: 21150
	public Func<bool> CheckToggleCanClick;

	// Token: 0x0400529F RID: 21151
	public UCurveFloat ItemCurve;

	// Token: 0x040052A0 RID: 21152
	private bool LevelReach;
}
