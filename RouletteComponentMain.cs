using System;
using System.Runtime.CompilerServices;
using CSharpScript.Core.Common;
using CSharpScript.Game.Ui;

// Token: 0x02002928 RID: 10536
[NullableContext(1)]
[Nullable(0)]
public class RouletteComponentMain : RouletteComponentBase
{
	// Token: 0x06014EA6 RID: 85670 RVA: 0x005C9DDE File Offset: 0x005C7FDE
	public void RegisterViewProxy(RouletteMainViewProxyBase viewProxy)
	{
		this.ViewProxy = viewProxy;
	}

	// Token: 0x06014EA7 RID: 85671 RVA: 0x005C9DE8 File Offset: 0x005C7FE8
	protected override void OnStart()
	{
		base.OnStart();
		if (Singleton<Info>.Instance.IsInGamepad())
		{
			int rouletteSelectConfig = ModelBase<RouletteModel>.Instance.GetRouletteSelectConfig();
			this.CanEmitSelectOnFlag = (rouletteSelectConfig == 1);
		}
	}

	// Token: 0x06014EA8 RID: 85672 RVA: 0x005C9E1C File Offset: 0x005C801C
	protected override void GamepadReturnEmptyGrid()
	{
		if (this.CurrentEquipGridIndex == this.CurrentGridIndex)
		{
			this.IsEmptyChoose = true;
			return;
		}
		RouletteGridBase rouletteGridBase = null;
		if (this.CurrentEquipGridIndex >= 0 && this.CurrentEquipGridIndex < this.RouletteGridList.Count)
		{
			rouletteGridBase = this.RouletteGridList[this.CurrentEquipGridIndex];
		}
		RouletteGridBase rouletteGridBase2 = this.RouletteGridList[this.CurrentGridIndex];
		RouletteData data = rouletteGridBase2.Data;
		if (data.State == EGridBehavior.Forbidden)
		{
			RouletteGridForbiddenSettings.TipsForbiddenState(data.GridType, data.Id);
			this.CurrentGridIndex = -1;
			this.IsEmptyChoose = true;
			return;
		}
		if (data.Id != 0 || data.GridType == ERouletteGridType.EquipItem)
		{
			if (rouletteGridBase != null)
			{
				rouletteGridBase.SetGridEquipped(false);
			}
			if (rouletteGridBase2 != null)
			{
				rouletteGridBase2.SetGridEquipped(true);
			}
			this.CurrentEquipGridIndex = this.CurrentGridIndex;
			this.OnEmitCurrentGridSelectOn();
			this.CloseRouletteMain();
		}
		this.IsEmptyChoose = true;
	}

	// Token: 0x06014EA9 RID: 85673 RVA: 0x005C9EF4 File Offset: 0x005C80F4
	public void TryEmitCurrentGridSelectOn()
	{
		if (!this.CanEmitSelectOnFlag)
		{
			return;
		}
		this.OnEmitCurrentGridSelectOn();
	}

	// Token: 0x06014EAA RID: 85674 RVA: 0x005C9F05 File Offset: 0x005C8105
	protected void OnEmitCurrentGridSelectOn()
	{
		if (this.IsEmitGridSelectOn)
		{
			return;
		}
		this.IsEmitGridSelectOn = true;
		RouletteGridBase currentGrid = base.GetCurrentGrid();
		if (currentGrid == null)
		{
			return;
		}
		currentGrid.SelectOnGrid(true);
	}

	// Token: 0x06014EAB RID: 85675 RVA: 0x005C9F28 File Offset: 0x005C8128
	protected override bool IsCurrentEquippedId(RouletteData gridData)
	{
		ERouletteGridType gridType = gridData.GridType;
		if (gridType != ERouletteGridType.Explore)
		{
			if (gridType == ERouletteGridType.EquipItem)
			{
				return ModelBase<RouletteModel>.Instance.IsEquipItemSelectOn;
			}
		}
		else
		{
			int currentExploreSkillId = ModelBase<RouletteModel>.Instance.CurrentExploreSkillId;
			if (currentExploreSkillId != 0 && gridData.Id == currentExploreSkillId)
			{
				return true;
			}
		}
		return false;
	}

	// Token: 0x06014EAC RID: 85676 RVA: 0x005C9F6A File Offset: 0x005C816A
	protected override int GetGridId(int index, ERouletteGridType gridType)
	{
		return this.ViewProxy.GetRouletteGridId(index, gridType);
	}

	// Token: 0x06014EAD RID: 85677 RVA: 0x005C9F79 File Offset: 0x005C8179
	protected override void SetCurrentToggleState(bool bSelect)
	{
		RouletteGridBase currentGrid = base.GetCurrentGrid();
		if (currentGrid != null)
		{
			currentGrid.SetGridToggleState(bSelect, true);
		}
		if (bSelect)
		{
			Singleton<AudioSystem>.Instance.PostEvent("play_ui_float_spl_roulette");
		}
	}

	// Token: 0x06014EAE RID: 85678 RVA: 0x005C9FA4 File Offset: 0x005C81A4
	protected override void RefreshCurrentShowName()
	{
		bool flag = Singleton<Info>.Instance.IsInTouch();
		RouletteGridBase currentGrid = base.GetCurrentGrid();
		string text;
		if (currentGrid == null)
		{
			text = null;
		}
		else
		{
			RouletteData data = currentGrid.Data;
			text = ((data != null) ? data.Name : null);
		}
		string text2 = text;
		if (!string.IsNullOrEmpty(text2))
		{
			base.SetNameVisible(true);
			base.RefreshName(text2);
			return;
		}
		base.SetNameVisible(flag);
		if (flag)
		{
			base.RefreshName("Text_ProbeToolFunctionNotice2_Text");
		}
	}

	// Token: 0x06014EAF RID: 85679 RVA: 0x005CA008 File Offset: 0x005C8208
	protected override void RefreshTips()
	{
		bool flag = Singleton<Info>.Instance.IsInTouch();
		bool isEmptyChoose = this.IsEmptyChoose;
		RouletteGridBase currentGrid = base.GetCurrentGrid();
		bool flag2 = currentGrid == null || currentGrid.Data.State != EGridBehavior.Normal;
		string refreshTips = this.GetRefreshTips(isEmptyChoose || flag2);
		base.RefreshTipsByText(refreshTips, !flag);
		this.ViewProxy.RefreshTips();
	}

	// Token: 0x06014EB0 RID: 85680 RVA: 0x005CA065 File Offset: 0x005C8265
	[NullableContext(2)]
	protected virtual string GetRefreshTips(bool isEmpty)
	{
		return null;
	}

	// Token: 0x06014EB1 RID: 85681 RVA: 0x005CA068 File Offset: 0x005C8268
	protected void CloseRouletteMain()
	{
		Singleton<UiManager>.Instance.CloseView(EUiViewName.PhantomExploreView, null);
	}

	// Token: 0x0400A131 RID: 41265
	private bool CanEmitSelectOnFlag = true;

	// Token: 0x0400A132 RID: 41266
	private bool IsEmitGridSelectOn;

	// Token: 0x0400A133 RID: 41267
	protected RouletteMainViewProxyBase ViewProxy;
}
