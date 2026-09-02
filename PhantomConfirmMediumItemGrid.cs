using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.Common.MediumItemGrid;
using CSharpScript.Game.Module.Item;

// Token: 0x0200190D RID: 6413
[NullableContext(2)]
[Nullable(0)]
public class PhantomConfirmMediumItemGrid : LoopScrollMediumItemGrid<int>
{
	// Token: 0x0600B849 RID: 47177 RVA: 0x0030FA24 File Offset: 0x0030DC24
	protected override void OnExtendToggleClicked()
	{
		ControllerBase<ItemController>.Instance.OpenItemTipsByItemUid(this.CurrentData.GetUniqueId(), this.CurrentData.GetConfigId(false), true, null);
	}

	// Token: 0x0600B84A RID: 47178 RVA: 0x0030FA4C File Offset: 0x0030DC4C
	protected override void OnRefresh(int uniqueId, bool isSelected, int gridIndex)
	{
		InventoryModel instance = ModelBase<InventoryModel>.Instance;
		PhantomBattleData phantomBattleData = ModelBase<PhantomBattleModel>.Instance.GetPhantomDataBase(uniqueId) as PhantomBattleData;
		if (phantomBattleData == null)
		{
			return;
		}
		this.CurrentData = phantomBattleData;
		PhantomItemData phantomItemData = instance.GetPhantomItemData(uniqueId);
		int quality = phantomBattleData.GetQuality();
		PhantomMediumItemGrid phantomMediumItemGrid = new PhantomMediumItemGrid
		{
			Data = phantomBattleData,
			ItemConfigId = new int?(phantomBattleData.GetConfigId(true)),
			BottomText = "+" + phantomBattleData.GetPhantomLevel().ToString(),
			StarLevel = new int?(quality),
			QualityId = new int?(quality),
			IsLockVisible = new bool?(phantomItemData.GetIsLock()),
			IsDeprecate = new bool?(phantomItemData.GetIsDeprecated()),
			IsRedDotVisible = new bool?(false),
			IsNewVisible = new bool?(false),
			Level = new int?(phantomBattleData.GetCost()),
			IsLevelTextUseChangeColor = new bool?(true),
			FetterGroupId = new int?(phantomBattleData.GetFetterGroupId())
		};
		if (ControllerBase<PhantomBattleController>.Instance.CheckIsEquip(uniqueId))
		{
			int? equipRole = ControllerBase<PhantomBattleController>.Instance.GetEquipRole(uniqueId);
			bool value = ModelBase<PhantomBattleModel>.Instance.CheckPhantomIsMain(uniqueId);
			phantomMediumItemGrid.VisionRoleHeadInfo = new VisionRoleHeadInfo
			{
				RoleConfigId = equipRole,
				VisionUniqueId = new int?(uniqueId)
			};
			phantomMediumItemGrid.IsMainVisionVisible = new bool?(value);
		}
		base.Apply<PhantomMediumItemGrid>(phantomMediumItemGrid);
	}

	// Token: 0x0600B84B RID: 47179 RVA: 0x0030FBA6 File Offset: 0x0030DDA6
	public PhantomBattleData GetCurrentData()
	{
		return this.CurrentData;
	}

	// Token: 0x040056D2 RID: 22226
	private PhantomBattleData CurrentData;
}
