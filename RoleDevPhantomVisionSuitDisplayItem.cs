using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Module.Inventory;
using CSharpScript.Game.Module.Item;

// Token: 0x02002815 RID: 10261
[NullableContext(1)]
[Nullable(new byte[]
{
	0,
	1
})]
public class RoleDevPhantomVisionSuitDisplayItem : LoopScrollSmallItemGrid<IRoleDevPhantomSuitDisplayItemData>
{
	// Token: 0x0601440C RID: 82956 RVA: 0x005A33AC File Offset: 0x005A15AC
	protected override void OnRefresh(IRoleDevPhantomSuitDisplayItemData data, bool isSelected, int gridIndex)
	{
		this.ItemData = data;
		if (data.RewardData != null)
		{
			this.RefreshRewardItem(data.RewardData);
		}
		else if (data.MonsterData != null)
		{
			this.RefreshMonsterItem(data.MonsterData);
		}
		this.SetSelected(isSelected, false);
	}

	// Token: 0x0601440D RID: 82957 RVA: 0x005A33E7 File Offset: 0x005A15E7
	public override void OnSelected(bool fireEvent)
	{
		this.SetSelected(true, false);
	}

	// Token: 0x0601440E RID: 82958 RVA: 0x005A33F1 File Offset: 0x005A15F1
	public override void OnDeselected(bool fireEvent)
	{
		this.SetSelected(false, true);
	}

	// Token: 0x0601440F RID: 82959 RVA: 0x005A33FC File Offset: 0x005A15FC
	private void RefreshRewardItem(IDropRewardItemData data)
	{
		if (ConfigBase<InventoryConfig>.Instance.GetItemConfigData(data.ItemId) == null)
		{
			return;
		}
		PropSmallItemGrid parameters = new PropSmallItemGrid
		{
			Data = data,
			BottomText = ((data.Count == 0) ? "" : data.Count.ToString()),
			ItemConfigId = new int?(data.ItemId)
		};
		base.Apply<PropSmallItemGrid>(parameters);
	}

	// Token: 0x06014410 RID: 82960 RVA: 0x005A3464 File Offset: 0x005A1664
	protected override void OnExtendToggleClicked()
	{
		IRoleDevPhantomSuitDisplayItemData itemData = this.ItemData;
		IDropRewardItemData dropRewardItemData = (itemData != null) ? itemData.RewardData : null;
		if (dropRewardItemData != null)
		{
			ControllerBase<ItemController>.Instance.OpenItemTipsByItemId(dropRewardItemData.ItemId, true, null);
			return;
		}
		IRoleDevPhantomSuitDisplayItemData itemData2 = this.ItemData;
		IPhantomMonsterItemData phantomMonsterItemData = (itemData2 != null) ? itemData2.MonsterData : null;
		if (phantomMonsterItemData != null)
		{
			ControllerBase<AdventureGuideController>.Instance.TryJumpToTargetViewByMonsterId(phantomMonsterItemData.MonsterId, null);
		}
	}

	// Token: 0x06014411 RID: 82961 RVA: 0x005A34C4 File Offset: 0x005A16C4
	private void RefreshMonsterItem(IPhantomMonsterItemData data)
	{
		bool flag = ModelBase<HandBookModel>.Instance.GetHandBookInfo(EHandBookTabType.Phantom, data.MonsterId) != null;
		RoleInstance roleInstanceById = ModelBase<RoleModel>.Instance.GetRoleInstanceById(data.RoleId);
		int? visionRoleHeadInfo = null;
		if (roleInstanceById != null)
		{
			RolePhantomData phantomData = roleInstanceById.GetPhantomData();
			Dictionary<int, PhantomDataBase> dictionary = (phantomData != null) ? phantomData.GetDataMap() : null;
			if (dictionary != null)
			{
				foreach (KeyValuePair<int, PhantomDataBase> keyValuePair in dictionary)
				{
					PhantomDataBase value = keyValuePair.Value;
					if (value != null && value.GetConfig().MonsterId == data.MonsterId)
					{
						visionRoleHeadInfo = new int?(roleInstanceById.GetRoleId());
						break;
					}
				}
			}
		}
		CalabashDevelopReward? calabashDevelopRewardByMonsterId = ConfigBase<CalabashConfig>.Instance.GetCalabashDevelopRewardByMonsterId(data.MonsterId);
		if (calabashDevelopRewardByMonsterId == null)
		{
			return;
		}
		int? itemConfigId = null;
		if (data.QualityId > 0)
		{
			int[] phantomItemIdArrayByMonsterId = ModelBase<PhantomBattleModel>.Instance.GetPhantomItemIdArrayByMonsterId(data.MonsterId);
			if (phantomItemIdArrayByMonsterId != null && phantomItemIdArrayByMonsterId.Length != 0 && data.QualityId - 1 < phantomItemIdArrayByMonsterId.Length)
			{
				itemConfigId = new int?(phantomItemIdArrayByMonsterId[data.QualityId - 1]);
			}
		}
		PhantomSmallItemGrid parameters = new PhantomSmallItemGrid
		{
			Data = data,
			ItemConfigId = itemConfigId,
			BottomText = "",
			IsNotFoundVisible = new bool?(!flag),
			MonsterId = new int?(calabashDevelopRewardByMonsterId.Value.MonsterInfoId),
			IconHidden = new bool?(!flag),
			VisionRoleHeadInfo = visionRoleHeadInfo
		};
		base.Apply<PhantomSmallItemGrid>(parameters);
	}

	// Token: 0x06014412 RID: 82962 RVA: 0x005A365C File Offset: 0x005A185C
	protected override bool OnCanExecuteChange()
	{
		return false;
	}

	// Token: 0x04009D94 RID: 40340
	[Nullable(2)]
	private IRoleDevPhantomSuitDisplayItemData ItemData;
}
