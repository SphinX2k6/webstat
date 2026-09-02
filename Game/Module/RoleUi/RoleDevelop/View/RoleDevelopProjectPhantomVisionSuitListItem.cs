using System;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Module.Inventory;
using CSharpScript.Game.Module.Item;

namespace CSharpScript.Game.Module.RoleUi.RoleDevelop.View
{
	// Token: 0x020050BF RID: 20671
	[NullableContext(1)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	public class RoleDevelopProjectPhantomVisionSuitListItem : LoopScrollSmallItemGrid<RoleDevelopPhantomVisionSuitListItemData>
	{
		// Token: 0x0603541E RID: 218142 RVA: 0x00D5A929 File Offset: 0x00D58B29
		protected override void OnRefresh(RoleDevelopPhantomVisionSuitListItemData data, bool isSelected, int gridIndex)
		{
			this.ItemData = data;
			if (data.RewardData != null)
			{
				this.RefreshRewardItem(data.RewardData);
				return;
			}
			if (data.MonsterData != null)
			{
				this.RefreshMonsterItem(data.MonsterData);
			}
		}

		// Token: 0x0603541F RID: 218143 RVA: 0x00D5A95C File Offset: 0x00D58B5C
		private void RefreshRewardItem(DropRewardItemData data)
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

		// Token: 0x06035420 RID: 218144 RVA: 0x00D5A9C4 File Offset: 0x00D58BC4
		private void RefreshMonsterItem(PhantomMonsterItemData data)
		{
			bool flag = ModelBase<HandBookModel>.Instance.GetHandBookInfo(EHandBookTabType.Phantom, data.MonsterId) != null;
			CalabashDevelopReward? calabashDevelopRewardByMonsterId = ConfigBase<CalabashConfig>.Instance.GetCalabashDevelopRewardByMonsterId(data.MonsterId);
			if (calabashDevelopRewardByMonsterId == null)
			{
				return;
			}
			int? itemConfigId = null;
			if (data.QualityId > 0)
			{
				int[] phantomItemIdArrayByMonsterId = ModelBase<PhantomBattleModel>.Instance.GetPhantomItemIdArrayByMonsterId(data.MonsterId);
				itemConfigId = new int?(phantomItemIdArrayByMonsterId[data.QualityId - 1]);
			}
			PhantomSmallItemGrid parameters = new PhantomSmallItemGrid
			{
				Data = data,
				ItemConfigId = itemConfigId,
				BottomText = "",
				IsNotFoundVisible = new bool?(!flag),
				MonsterId = new int?(calabashDevelopRewardByMonsterId.Value.MonsterInfoId),
				IconHidden = new bool?(!flag)
			};
			base.Apply<PhantomSmallItemGrid>(parameters);
		}

		// Token: 0x06035421 RID: 218145 RVA: 0x00D5AA98 File Offset: 0x00D58C98
		protected override void OnExtendToggleClicked()
		{
			RoleDevelopPhantomVisionSuitListItemData itemData = this.ItemData;
			if (itemData == null)
			{
				return;
			}
			if (itemData.RewardData != null)
			{
				ControllerBase<ItemController>.Instance.OpenItemTipsByItemId(itemData.RewardData.ItemId, true, null);
				return;
			}
			if (itemData.MonsterData != null)
			{
				ControllerBase<AdventureGuideController>.Instance.TryJumpToTargetViewByMonsterId(itemData.MonsterData.MonsterId, null);
			}
		}

		// Token: 0x06035422 RID: 218146 RVA: 0x00D5AAEE File Offset: 0x00D58CEE
		protected override bool OnCanExecuteChange()
		{
			return false;
		}

		// Token: 0x0401EA45 RID: 125509
		private RoleDevelopPhantomVisionSuitListItemData ItemData;
	}
}
