using System;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Module.Common.MediumItemGrid;
using CSharpScript.Game.Module.RoleUi;
using UnrealEngine;

// Token: 0x02001634 RID: 5684
[NullableContext(1)]
[Nullable(0)]
public class WheelTowerEnhanceRoleGridItem : LoopScrollMediumItemGrid<int>
{
	// Token: 0x0600A018 RID: 40984 RVA: 0x0029DDA5 File Offset: 0x0029BFA5
	protected override void OnStart()
	{
		this.GetItemGridExtendToggle().bLockStateOnSelect = true;
		base.BindOnExtendToggleStateChanged(new Action<MediumItemGridExtendCallback>(this.OnExtendToggleStateChangedInternal));
		base.BindOnExtendToggleClicked(delegate(MediumItemGridExtendCallback _)
		{
			this.OnExtendToggleClickedInternal();
		});
	}

	// Token: 0x0600A019 RID: 40985 RVA: 0x0029DDD8 File Offset: 0x0029BFD8
	protected override void OnRefresh(int roleId, bool isSelected, int gridIndex)
	{
		this.RoleId = roleId;
		if (roleId == 0)
		{
			base.Apply<OnlyEmptyItemGrid>(new OnlyEmptyItemGrid
			{
				IsClickable = new bool?(false)
			});
			this.SetSelected(false, true);
			return;
		}
		RoleInfo? roleConfig = ConfigBase<RoleConfig>.Instance.GetRoleConfig(roleId);
		if (roleConfig == null)
		{
			return;
		}
		base.SetUseFixedAsync(true);
		CharacterMediumItemGrid characterMediumItemGrid = new CharacterMediumItemGrid
		{
			ItemConfigId = new int?(roleId),
			SkinId = roleConfig.Value.SkinId,
			BottomTextId = roleConfig.Value.Name,
			ElementId = new int?(roleConfig.Value.ElementId)
		};
		int specialUpRoleAddEnergy = ModelBase<WheelTowerModel>.Instance.GetSpecialUpRoleAddEnergy(roleId);
		if (specialUpRoleAddEnergy > 0)
		{
			CharacterMediumItemGrid characterMediumItemGrid2 = characterMediumItemGrid;
			MediumItemGridCostComponentData mediumItemGridCostComponentData = new MediumItemGridCostComponentData();
			DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(1, 1);
			defaultInterpolatedStringHandler.AppendLiteral("+");
			defaultInterpolatedStringHandler.AppendFormatted<int>(specialUpRoleAddEnergy);
			mediumItemGridCostComponentData.Text = defaultInterpolatedStringHandler.ToStringAndClear();
			mediumItemGridCostComponentData.Cost = 0;
			mediumItemGridCostComponentData.Color = TowerData.highColor.Value;
			characterMediumItemGrid2.ShowCostData = mediumItemGridCostComponentData;
		}
		base.Apply<CharacterMediumItemGrid>(characterMediumItemGrid);
		this.SetSelected(isSelected, true);
	}

	// Token: 0x0600A01A RID: 40986 RVA: 0x0029DEED File Offset: 0x0029C0ED
	public void SetToggleClickCallback(Action<int> callback)
	{
		this.ToggleClickCallback = callback;
	}

	// Token: 0x0600A01B RID: 40987 RVA: 0x0029DEF6 File Offset: 0x0029C0F6
	public override void OnSelected(bool fireEvent)
	{
		this.SetSelected(true, true);
	}

	// Token: 0x0600A01C RID: 40988 RVA: 0x0029DF00 File Offset: 0x0029C100
	public override void OnDeselected(bool fireEvent)
	{
		this.SetSelected(false, true);
	}

	// Token: 0x0600A01D RID: 40989 RVA: 0x0029DF0A File Offset: 0x0029C10A
	private void OnExtendToggleStateChangedInternal(MediumItemGridExtendCallback callback)
	{
		if (callback.State == EToggleState.ETT_Checked)
		{
			Action<int> toggleClickCallback = this.ToggleClickCallback;
			if (toggleClickCallback == null)
			{
				return;
			}
			toggleClickCallback(this.RoleId);
		}
	}

	// Token: 0x0600A01E RID: 40990 RVA: 0x0029DF2B File Offset: 0x0029C12B
	private void OnExtendToggleClickedInternal()
	{
		if (this.IsSelected)
		{
			return;
		}
		Action<int> toggleClickCallback = this.ToggleClickCallback;
		if (toggleClickCallback == null)
		{
			return;
		}
		toggleClickCallback(this.RoleId);
	}

	// Token: 0x04004991 RID: 18833
	private int RoleId;

	// Token: 0x04004992 RID: 18834
	[Nullable(2)]
	private Action<int> ToggleClickCallback;
}
