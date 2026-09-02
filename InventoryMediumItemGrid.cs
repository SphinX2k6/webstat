using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Module.Common.MediumItemGrid;
using CSharpScript.Game.Module.Inventory;
using CSharpScript.Game.Module.RoleUi;
using CSharpScript.Game.Module.RoleUi.RoleDevelop;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x0200202B RID: 8235
[NullableContext(1)]
[Nullable(new byte[]
{
	0,
	1
})]
public class InventoryMediumItemGrid : LoopScrollMediumItemGrid<global::ItemViewData>
{
	// Token: 0x0600FA6A RID: 64106 RVA: 0x00449C85 File Offset: 0x00447E85
	public override void CreateThenShowByActor(AActor actor)
	{
	}

	// Token: 0x0600FA6B RID: 64107 RVA: 0x00449C88 File Offset: 0x00447E88
	public override UniTask CreateThenShowByActorAsync(AActor actor)
	{
		InventoryMediumItemGrid.<CreateThenShowByActorAsync>d__1 <CreateThenShowByActorAsync>d__;
		<CreateThenShowByActorAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<CreateThenShowByActorAsync>d__.<>1__state = -1;
		<CreateThenShowByActorAsync>d__.<>t__builder.Start<InventoryMediumItemGrid.<CreateThenShowByActorAsync>d__1>(ref <CreateThenShowByActorAsync>d__);
		return <CreateThenShowByActorAsync>d__.<>t__builder.Task;
	}

	// Token: 0x0600FA6C RID: 64108 RVA: 0x00449CC4 File Offset: 0x00447EC4
	public override UniTask CreateByActorAsync(AActor actor)
	{
		InventoryMediumItemGrid.<CreateByActorAsync>d__2 <CreateByActorAsync>d__;
		<CreateByActorAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<CreateByActorAsync>d__.<>1__state = -1;
		<CreateByActorAsync>d__.<>t__builder.Start<InventoryMediumItemGrid.<CreateByActorAsync>d__2>(ref <CreateByActorAsync>d__);
		return <CreateByActorAsync>d__.<>t__builder.Task;
	}

	// Token: 0x0600FA6D RID: 64109 RVA: 0x00449CFF File Offset: 0x00447EFF
	protected override void OnStart()
	{
		base.SetUseFixedAsync(true);
	}

	// Token: 0x0600FA6E RID: 64110 RVA: 0x00449D08 File Offset: 0x00447F08
	protected override void OnRefresh(global::ItemViewData data, bool isSelected, int gridIndex)
	{
		this.ItemViewData = data;
		InventoryDefine.IItemViewDataInfo itemViewInfo = data.GetItemViewInfo();
		InventoryDefine.EItemDataType itemDataType = itemViewInfo.ItemDataType;
		int qualityId = itemViewInfo.QualityId;
		bool flag = data.GetItemOperationType() == ItemViewDefine.EItemOperationMode.Destruction;
		PropMediumItemGrid propMediumItemGrid = new PropMediumItemGrid
		{
			Data = data,
			ItemConfigId = new int?(data.GetConfigId()),
			StarLevel = new int?(qualityId),
			IsNewVisible = new bool?(itemViewInfo.IsNewItem),
			IsLockVisible = new bool?(itemViewInfo.IsLock),
			IsDeprecate = new bool?(itemViewInfo.IsDeprecate),
			CoolDown = new float?(this.GetRemainingCoolDownTime()),
			TotalCoolDown = new float?(this.GetTotalCoolDownTime()),
			IsRedDotVisible = new bool?(itemViewInfo.HasRedDot),
			IsDisable = new bool?(flag && !data.IsItemCanDestroy()),
			IsCheckTick = new bool?(itemViewInfo.IsSelectOn)
		};
		switch (itemDataType)
		{
		case InventoryDefine.EItemDataType.CommonItem:
			this.ApplyCommonItemView(propMediumItemGrid, data, itemViewInfo);
			goto IL_131;
		case InventoryDefine.EItemDataType.WeaponItem:
			this.ApplyWeaponItemView(propMediumItemGrid);
			goto IL_131;
		case InventoryDefine.EItemDataType.PhantomItem:
			this.ApplyPhantomItemView(propMediumItemGrid, qualityId);
			goto IL_131;
		}
		propMediumItemGrid.BottomText = data.GetCount().ToString();
		IL_131:
		base.Apply<PropMediumItemGrid>(propMediumItemGrid);
		base.SetCheckTickPerformance(new bool?(itemViewInfo.IsSelectOn), "bf5c5c", new float?(0.9f), "663738");
		this.SetSelected(isSelected, false);
	}

	// Token: 0x0600FA6F RID: 64111 RVA: 0x00449E7C File Offset: 0x0044807C
	private void ApplyCommonItemView(PropMediumItemGrid propMediumItemGrid, global::ItemViewData data, InventoryDefine.IItemViewDataInfo itemViewInfo)
	{
		CommonItemData commonItemData = (CommonItemData)this.ItemViewData.GetItemDataBase();
		if (itemViewInfo.SelectOnNum != 0)
		{
			string bottomText = StringUtils.Format(ConfigMultiTextLang.GetLocalTextNew("Text_ItemRecycleChosen_text", null), new string[]
			{
				itemViewInfo.SelectOnNum.ToString(),
				data.GetCount().ToString()
			});
			propMediumItemGrid.BottomText = bottomText;
		}
		else
		{
			propMediumItemGrid.BottomText = data.GetCount().ToString();
		}
		propMediumItemGrid.IsTimeFlagVisible = new bool?(commonItemData.IsLimitTimeItem());
		propMediumItemGrid.BuffIconType = new EMediumItemGridBuffType?((EMediumItemGridBuffType)commonItemData.GetConfig().As<ItemInfo>().Value.ItemBuffType);
		propMediumItemGrid.IsOmitBottomText = new bool?(false);
		RoleDevelopModel instance = ModelBase<RoleDevelopModel>.Instance;
		if (instance.DevTargetRoleId == 0)
		{
			return;
		}
		int configId = data.GetConfigId();
		InventoryModel instance2 = ModelBase<InventoryModel>.Instance;
		bool flag = instance2.GetCurrentMainTypeId().GetValueOrDefault() == InventoryDefine.EItemMainTypeId.Weapon && commonItemData.GetShowTypeList().Contains(12);
		if ((!instance2.IsResourceOrMaterialTab() && !flag) || !instance.IsDevelopRoleNeedItem(configId))
		{
			return;
		}
		int devTargetRoleId = instance.DevTargetRoleId;
		string roleIconPath = "";
		if (RoleDevelopUtil.IsAnyProspectRole(devTargetRoleId))
		{
			roleIconPath = instance.GetRoleDevelopData(devTargetRoleId).GetDevelopRoleData().GetRoleSmallIconPath();
		}
		else if (ModelBase<RoleModel>.Instance.GetRoleDataById(devTargetRoleId, true) == null)
		{
			roleIconPath = ConfigBase<RoleConfig>.Instance.GetRoleHeadIcon(devTargetRoleId, false);
		}
		propMediumItemGrid.RoleHeadInfo = new RoleHeadInfo
		{
			RoleConfigId = new int?(devTargetRoleId),
			RoleIconPath = roleIconPath
		};
	}

	// Token: 0x0600FA70 RID: 64112 RVA: 0x0044A004 File Offset: 0x00448204
	private void ApplyWeaponItemView(PropMediumItemGrid propMediumItemGrid)
	{
		int uniqueId = (this.ItemViewData.GetItemDataBase() as WeaponItemData).GetUniqueId();
		WeaponInstance weaponDataByIncId = ModelBase<WeaponModel>.Instance.GetWeaponDataByIncId(uniqueId);
		propMediumItemGrid.BottomTextId = "Text_LevelShow_Text";
		propMediumItemGrid.BottomTextParameter = new object[]
		{
			weaponDataByIncId.GetLevel()
		};
		propMediumItemGrid.Level = new int?(weaponDataByIncId.GetResonanceLevel());
		propMediumItemGrid.RoleHeadInfo = new RoleHeadInfo
		{
			RoleConfigId = new int?(weaponDataByIncId.GetRoleId())
		};
	}

	// Token: 0x0600FA71 RID: 64113 RVA: 0x0044A088 File Offset: 0x00448288
	private void ApplyPhantomItemView(PropMediumItemGrid propMediumItemGrid, int qualityId)
	{
		int uniqueId = (this.ItemViewData.GetItemDataBase() as PhantomItemData).GetUniqueId();
		PhantomBattleData phantomBattleData = ModelBase<PhantomBattleModel>.Instance.GetPhantomBattleData(uniqueId);
		List<VisionSlotData> currentSlotData = phantomBattleData.GetCurrentSlotData();
		propMediumItemGrid.ItemConfigId = new int?(phantomBattleData.GetConfigId(true));
		propMediumItemGrid.QualityId = new int?(qualityId);
		propMediumItemGrid.Level = new int?(phantomBattleData.GetCost());
		propMediumItemGrid.IsLevelTextUseChangeColor = new bool?(true);
		propMediumItemGrid.BottomText = "+" + phantomBattleData.GetPhantomLevel().ToString();
		propMediumItemGrid.IsOmitBottomText = new bool?(true);
		if (currentSlotData.Count > 0)
		{
			EVisionSlotState? evisionSlotState;
			if (currentSlotData.Count <= 0)
			{
				evisionSlotState = null;
			}
			else
			{
				VisionSlotData visionSlotData = currentSlotData[0];
				evisionSlotState = ((visionSlotData != null) ? new EVisionSlotState?(visionSlotData.SlotState) : null);
			}
			EVisionSlotState? evisionSlotState2 = evisionSlotState;
			EVisionSlotState? evisionSlotState3;
			if (currentSlotData.Count <= 1)
			{
				evisionSlotState3 = null;
			}
			else
			{
				VisionSlotData visionSlotData2 = currentSlotData[1];
				evisionSlotState3 = ((visionSlotData2 != null) ? new EVisionSlotState?(visionSlotData2.SlotState) : null);
			}
			EVisionSlotState? evisionSlotState4 = evisionSlotState3;
			EVisionSlotState? evisionSlotState5;
			if (currentSlotData.Count <= 2)
			{
				evisionSlotState5 = null;
			}
			else
			{
				VisionSlotData visionSlotData3 = currentSlotData[2];
				evisionSlotState5 = ((visionSlotData3 != null) ? new EVisionSlotState?(visionSlotData3.SlotState) : null);
			}
			EVisionSlotState? evisionSlotState6 = evisionSlotState5;
			EVisionSlotState valueOrDefault = evisionSlotState2.GetValueOrDefault();
			EVisionSlotState valueOrDefault2 = evisionSlotState4.GetValueOrDefault();
			EVisionSlotState valueOrDefault3 = evisionSlotState6.GetValueOrDefault();
			propMediumItemGrid.VisionSlotStateList = this.BuildVisionSlotStateList((InventoryDefine.EQuality)qualityId, valueOrDefault, valueOrDefault2, valueOrDefault3);
		}
		if (ControllerBase<PhantomBattleController>.Instance.CheckIsEquip(uniqueId))
		{
			int uniqueId2 = phantomBattleData.GetUniqueId();
			int? equipRole = ControllerBase<PhantomBattleController>.Instance.GetEquipRole(uniqueId2);
			bool value = ModelBase<PhantomBattleModel>.Instance.CheckPhantomIsMain(uniqueId2);
			propMediumItemGrid.VisionRoleHeadInfo = new VisionRoleHeadInfo
			{
				RoleConfigId = equipRole,
				VisionUniqueId = new int?(uniqueId2)
			};
			propMediumItemGrid.IsMainVisionVisible = new bool?(value);
		}
		propMediumItemGrid.VisionFetterGroupId = new int?(phantomBattleData.GetFetterGroupId());
	}

	// Token: 0x0600FA72 RID: 64114 RVA: 0x0044A274 File Offset: 0x00448474
	[NullableContext(2)]
	private int[] BuildVisionSlotStateList(InventoryDefine.EQuality qualityId, EVisionSlotState visionSlotState1, EVisionSlotState visionSlotState2, EVisionSlotState visionSlotState3)
	{
		switch (qualityId)
		{
		case InventoryDefine.EQuality.Blue:
			return new int[]
			{
				(int)visionSlotState1
			};
		case InventoryDefine.EQuality.Purple:
			return new int[]
			{
				(int)visionSlotState1,
				(int)visionSlotState2
			};
		case InventoryDefine.EQuality.Orange:
			return new int[]
			{
				(int)visionSlotState1,
				(int)visionSlotState2,
				(int)visionSlotState3
			};
		default:
			return null;
		}
	}

	// Token: 0x0600FA73 RID: 64115 RVA: 0x0044A2C6 File Offset: 0x004484C6
	public override void OnSelected(bool fireEvent)
	{
		this.SetSelected(true, false);
	}

	// Token: 0x0600FA74 RID: 64116 RVA: 0x0044A2D0 File Offset: 0x004484D0
	public override void OnDeselected(bool fireEvent)
	{
		this.SetSelected(false, false);
	}

	// Token: 0x0600FA75 RID: 64117 RVA: 0x0044A2DC File Offset: 0x004484DC
	public float GetRemainingCoolDownTime()
	{
		int configId = this.ItemViewData.GetConfigId();
		return (float)ModelBase<BuffItemModel>.Instance.GetBuffItemRemainCdTime(configId);
	}

	// Token: 0x0600FA76 RID: 64118 RVA: 0x0044A304 File Offset: 0x00448504
	public float GetTotalCoolDownTime()
	{
		int configId = this.ItemViewData.GetConfigId();
		return (float)ModelBase<BuffItemModel>.Instance.GetBuffItemTotalCdTime(configId);
	}

	// Token: 0x0600FA77 RID: 64119 RVA: 0x0044A32C File Offset: 0x0044852C
	public void RefreshCoolDown()
	{
		float remainingCoolDownTime = this.GetRemainingCoolDownTime();
		float totalCoolDownTime = this.GetTotalCoolDownTime();
		base.SetCoolDown(new float?(remainingCoolDownTime), new float?(totalCoolDownTime));
	}

	// Token: 0x0600FA78 RID: 64120 RVA: 0x0044A359 File Offset: 0x00448559
	public void BindOnItemButtonClickedCallback(Action<global::ItemViewData> onItemButtonClicked)
	{
		this.OnItemButtonClickedCallback = onItemButtonClicked;
	}

	// Token: 0x0600FA79 RID: 64121 RVA: 0x0044A362 File Offset: 0x00448562
	protected override void OnExtendToggleStateChanged(EToggleState state)
	{
		if (this.OnItemButtonClickedCallback != null)
		{
			this.OnItemButtonClickedCallback(this.ItemViewData);
		}
	}

	// Token: 0x04007843 RID: 30787
	[Nullable(2)]
	private global::ItemViewData ItemViewData;

	// Token: 0x04007844 RID: 30788
	[Nullable(new byte[]
	{
		2,
		1
	})]
	private Action<global::ItemViewData> OnItemButtonClickedCallback;

	// Token: 0x04007845 RID: 30789
	private const string RED_TICK_HEX = "bf5c5c";

	// Token: 0x04007846 RID: 30790
	private const string TICK_COLOR_HEX = "663738";

	// Token: 0x04007847 RID: 30791
	private const float RED_TICK_ALPHA = 0.9f;
}
