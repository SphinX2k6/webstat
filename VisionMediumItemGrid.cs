using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Module.Activity.ActivityContent.WheelTower;
using CSharpScript.Game.Module.Common.MediumItemGrid;
using CSharpScript.Game.Module.RoleUi;
using UnrealEngine;

// Token: 0x02002528 RID: 9512
[NullableContext(1)]
[Nullable(new byte[]
{
	0,
	1
})]
public class VisionMediumItemGrid : LoopScrollMediumItemGrid<PhantomBattleData>
{
	// Token: 0x06012821 RID: 75809 RVA: 0x00519525 File Offset: 0x00517725
	protected override void OnStart()
	{
		base.BindOnExtendToggleStateChanged(delegate(MediumItemGridExtendCallback _)
		{
			this.OnClickEvent();
		});
		base.BindOnExtendTogglePress(delegate(MediumItemGridExtendCallback _)
		{
			this.OnToggleDown();
		});
		base.BindOnExtendToggleRelease(delegate(MediumItemGridExtendCallback _)
		{
			this.OnToggleUp();
		});
	}

	// Token: 0x06012822 RID: 75810 RVA: 0x0051955D File Offset: 0x0051775D
	public void SetOnPointDownCallBack(Action<VisionMediumItemGrid, PhantomBattleData> call)
	{
		this.OnPointDownCallBack = call;
	}

	// Token: 0x06012823 RID: 75811 RVA: 0x00519566 File Offset: 0x00517766
	public void SetOnPointUpCallBack(Action<VisionMediumItemGrid, PhantomBattleData> call)
	{
		this.OnPointUpCallBack = call;
	}

	// Token: 0x06012824 RID: 75812 RVA: 0x0051956F File Offset: 0x0051776F
	private void OnToggleDown()
	{
		if (this.CurrentData != null)
		{
			Action<VisionMediumItemGrid, PhantomBattleData> onPointDownCallBack = this.OnPointDownCallBack;
			if (onPointDownCallBack == null)
			{
				return;
			}
			onPointDownCallBack(this, this.CurrentData);
		}
	}

	// Token: 0x06012825 RID: 75813 RVA: 0x00519590 File Offset: 0x00517790
	private void OnToggleUp()
	{
		if (this.CurrentData != null)
		{
			Action<VisionMediumItemGrid, PhantomBattleData> onPointUpCallBack = this.OnPointUpCallBack;
			if (onPointUpCallBack == null)
			{
				return;
			}
			onPointUpCallBack(this, this.CurrentData);
		}
	}

	// Token: 0x06012826 RID: 75814 RVA: 0x005195B1 File Offset: 0x005177B1
	private void OnClickEvent()
	{
		if (this.CurrentData != null)
		{
			Action<PhantomBattleData, int> onClickCallBack = this.OnClickCallBack;
			if (onClickCallBack == null)
			{
				return;
			}
			onClickCallBack(this.CurrentData, this.CurrentIndex);
		}
	}

	// Token: 0x06012827 RID: 75815 RVA: 0x005195D7 File Offset: 0x005177D7
	public void SetClickToggleEvent(Action<PhantomBattleData, int> call)
	{
		this.OnClickCallBack = call;
	}

	// Token: 0x06012828 RID: 75816 RVA: 0x005195E0 File Offset: 0x005177E0
	public override void OnSelected(bool fireEvent)
	{
		if (this.GetItemGridExtendToggle().ToggleState != EToggleState.ETT_Checked)
		{
			this.SetSelected(true, false);
		}
		base.SetNewVisible(new bool?(false));
		if (this.CurrentData != null)
		{
			base.SetRedDotVisible(new bool?(ModelBase<PhantomBattleModel>.Instance.GetMonsterSkinListHasNew(this.CurrentData.GetConfigId(false))));
			ModelBase<InventoryModel>.Instance.RemoveNewAttributeItem(this.CurrentData.GetUniqueId());
			ModelBase<InventoryModel>.Instance.SaveNewAttributeItemUniqueIdList();
		}
	}

	// Token: 0x06012829 RID: 75817 RVA: 0x00519659 File Offset: 0x00517859
	public override void OnDeselected(bool fireEvent)
	{
		if (this.GetItemGridExtendToggle().ToggleState != EToggleState.ETT_UnChecked)
		{
			this.SetSelected(false, true);
		}
	}

	// Token: 0x0601282A RID: 75818 RVA: 0x00519670 File Offset: 0x00517870
	public void SetOnRefreshEvent(Action<VisionMediumItemGrid> call)
	{
		this.OnRefreshCallBack = call;
	}

	// Token: 0x0601282B RID: 75819 RVA: 0x00519679 File Offset: 0x00517879
	public bool CheckSelectedState(PhantomBattleData currentSelectData)
	{
		return currentSelectData == this.CurrentData;
	}

	// Token: 0x0601282C RID: 75820 RVA: 0x00519688 File Offset: 0x00517888
	protected override void OnRefresh(PhantomBattleData data, bool isSelected, int gridIndex)
	{
		this.CurrentData = data;
		this.CurrentIndex = gridIndex;
		InventoryModel instance = ModelBase<InventoryModel>.Instance;
		int uniqueId = data.GetUniqueId();
		bool flag = instance.IsNewAttributeItem(uniqueId);
		PhantomItemData phantomItemData = instance.GetPhantomItemData(uniqueId);
		if (phantomItemData == null)
		{
			return;
		}
		List<VisionSlotData> currentSlotData = data.GetCurrentSlotData();
		int quality = data.GetQuality();
		bool value = !flag && ModelBase<PhantomBattleModel>.Instance.GetMonsterSkinListHasNew(data.GetConfigId(false));
		MediumWarningPanelInfo warningPanelInfo = this.GetWarningPanelInfo(data);
		PhantomMediumItemGrid phantomMediumItemGrid = new PhantomMediumItemGrid
		{
			Data = data,
			ItemConfigId = new int?(data.GetConfigId(true)),
			BottomText = "+" + data.GetPhantomLevel().ToString(),
			StarLevel = new int?(quality),
			QualityId = new int?(quality),
			IsLockVisible = new bool?(phantomItemData.GetIsLock()),
			IsDeprecate = new bool?(phantomItemData.GetIsDeprecated()),
			IsRedDotVisible = new bool?(value),
			IsNewVisible = new bool?(flag),
			Level = new int?(data.GetCost()),
			IsLevelTextUseChangeColor = new bool?(true),
			FetterGroupId = new int?(data.GetFetterGroupId()),
			WarningPanelInfo = warningPanelInfo
		};
		if (currentSlotData.Count > 0)
		{
			VisionSlotData visionSlotData = currentSlotData[0];
			EVisionSlotState evisionSlotState = (visionSlotData != null) ? visionSlotData.SlotState : EVisionSlotState.UnlockAndNoProp;
			EVisionSlotState evisionSlotState2;
			if (currentSlotData.Count <= 1)
			{
				evisionSlotState2 = EVisionSlotState.UnlockAndNoProp;
			}
			else
			{
				VisionSlotData visionSlotData2 = currentSlotData[1];
				evisionSlotState2 = ((visionSlotData2 != null) ? visionSlotData2.SlotState : EVisionSlotState.UnlockAndNoProp);
			}
			EVisionSlotState evisionSlotState3 = evisionSlotState2;
			EVisionSlotState evisionSlotState4;
			if (currentSlotData.Count <= 2)
			{
				evisionSlotState4 = EVisionSlotState.UnlockAndNoProp;
			}
			else
			{
				VisionSlotData visionSlotData3 = currentSlotData[2];
				evisionSlotState4 = ((visionSlotData3 != null) ? visionSlotData3.SlotState : EVisionSlotState.UnlockAndNoProp);
			}
			EVisionSlotState evisionSlotState5 = evisionSlotState4;
			switch (quality)
			{
			case 3:
				phantomMediumItemGrid.VisionSlotStateList = new int[]
				{
					(int)evisionSlotState
				};
				break;
			case 4:
				phantomMediumItemGrid.VisionSlotStateList = new int[]
				{
					(int)evisionSlotState,
					(int)evisionSlotState3
				};
				break;
			case 5:
				phantomMediumItemGrid.VisionSlotStateList = new int[]
				{
					(int)evisionSlotState,
					(int)evisionSlotState3,
					(int)evisionSlotState5
				};
				break;
			}
		}
		if (ControllerBase<PhantomBattleController>.Instance.CheckIsEquip(uniqueId))
		{
			int? equipRole = ControllerBase<PhantomBattleController>.Instance.GetEquipRole(uniqueId);
			bool value2 = ModelBase<PhantomBattleModel>.Instance.CheckPhantomIsMain(uniqueId);
			phantomMediumItemGrid.VisionRoleHeadInfo = new VisionRoleHeadInfo
			{
				RoleConfigId = equipRole,
				VisionUniqueId = new int?(uniqueId)
			};
			phantomMediumItemGrid.IsMainVisionVisible = new bool?(value2);
		}
		base.Apply<PhantomMediumItemGrid>(phantomMediumItemGrid);
		if (this.GetItemGridExtendToggle().ToggleState != EToggleState.ETT_UnChecked)
		{
			this.SetSelected(false, true);
		}
		Action<VisionMediumItemGrid> onRefreshCallBack = this.OnRefreshCallBack;
		if (onRefreshCallBack == null)
		{
			return;
		}
		onRefreshCallBack(this);
	}

	// Token: 0x0601282D RID: 75821 RVA: 0x00519904 File Offset: 0x00517B04
	[return: Nullable(2)]
	private MediumWarningPanelInfo GetWarningPanelInfo(PhantomBattleData data)
	{
		if (this.Source == ERoleViewSource.WheelTower)
		{
			int incrId = data.GetIncrId();
			EnergyInfo selectedEnergyInfo = ModelBase<WheelTowerModel>.Instance.SelectedEnergyInfo;
			if (!selectedEnergyInfo.GetPhantomCanUse(incrId, this.RoleId))
			{
				int phantomOccupyRoleId = selectedEnergyInfo.GetPhantomOccupyRoleId(incrId, this.RoleId);
				Aki.Config.RoleInfo? roleConfig = ConfigBase<RoleConfig>.Instance.GetRoleConfig(phantomOccupyRoleId);
				string multiText = ConfigBase<TextConfig>.Instance.GetMultiText("WheelTower_Occupy_Tip", Array.Empty<string>());
				return new MediumWarningPanelInfo
				{
					TipText = multiText,
					IconPath = roleConfig.Value.Card
				};
			}
		}
		return null;
	}

	// Token: 0x04009049 RID: 36937
	[Nullable(2)]
	private PhantomBattleData CurrentData;

	// Token: 0x0400904A RID: 36938
	private int CurrentIndex;

	// Token: 0x0400904B RID: 36939
	public ERoleViewSource Source;

	// Token: 0x0400904C RID: 36940
	public int RoleId;

	// Token: 0x0400904D RID: 36941
	[Nullable(new byte[]
	{
		2,
		1
	})]
	private Action<PhantomBattleData, int> OnClickCallBack;

	// Token: 0x0400904E RID: 36942
	[Nullable(new byte[]
	{
		2,
		1
	})]
	private Action<VisionMediumItemGrid> OnRefreshCallBack;

	// Token: 0x0400904F RID: 36943
	[Nullable(new byte[]
	{
		2,
		1,
		1
	})]
	private Action<VisionMediumItemGrid, PhantomBattleData> OnPointDownCallBack;

	// Token: 0x04009050 RID: 36944
	[Nullable(new byte[]
	{
		2,
		1,
		1
	})]
	private Action<VisionMediumItemGrid, PhantomBattleData> OnPointUpCallBack;
}
