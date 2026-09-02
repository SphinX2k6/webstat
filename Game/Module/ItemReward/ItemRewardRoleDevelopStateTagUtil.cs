using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Module.RoleUi.RoleDevelop;

namespace CSharpScript.Game.Module.ItemReward
{
	// Token: 0x02005B3E RID: 23358
	[NullableContext(1)]
	[Nullable(0)]
	public class ItemRewardRoleDevelopStateTagUtil
	{
		// Token: 0x0603B146 RID: 241990 RVA: 0x00EF3534 File Offset: 0x00EF1734
		private static EItemRequirementState? GetRewardExpItemDevelopUpgradeState(int itemId)
		{
			IRoleDevelopExpStateProvider roleDevelopExpStateProvider = ModelBase<RoleDevelopModel>.Instance as IRoleDevelopExpStateProvider;
			if (roleDevelopExpStateProvider == null)
			{
				return null;
			}
			Func<int, EItemRequirementState?> getExpItemRequirementState = roleDevelopExpStateProvider.GetExpItemRequirementState;
			if (getExpItemRequirementState == null)
			{
				return null;
			}
			return getExpItemRequirementState(itemId);
		}

		// Token: 0x0603B147 RID: 241991 RVA: 0x00EF3574 File Offset: 0x00EF1774
		private static ERoleDevelopStateTagType? ConvertRequirementStateToTagType(EItemRequirementState? state)
		{
			if (state != null)
			{
				switch (state.GetValueOrDefault())
				{
				case EItemRequirementState.Satisfied:
					return new ERoleDevelopStateTagType?(ERoleDevelopStateTagType.Completed);
				case EItemRequirementState.Supplement:
					return new ERoleDevelopStateTagType?(ERoleDevelopStateTagType.CanBeFilled);
				case EItemRequirementState.NotSatisfied:
					return new ERoleDevelopStateTagType?(ERoleDevelopStateTagType.Lack);
				}
			}
			return null;
		}

		// Token: 0x0603B148 RID: 241992 RVA: 0x00EF35C4 File Offset: 0x00EF17C4
		private static ERoleDevelopStateTagType? GetRewardRoleDevelopStateTagType(RewardItemData rewardItemData)
		{
			RoleDevelopModel instance = ModelBase<RoleDevelopModel>.Instance;
			RoleDevConfig instance2 = ConfigBase<RoleDevConfig>.Instance;
			if (instance == null || instance2 == null || instance.DevTargetRoleId == 0)
			{
				return null;
			}
			int configId = rewardItemData.ConfigId;
			if (!instance.IsDevelopRoleNeedItem(configId))
			{
				return null;
			}
			RoleDevItemJumpGroup? itemJumpGroupConfig = instance2.GetItemJumpGroupConfig(configId);
			int? num = (itemJumpGroupConfig != null) ? new int?(itemJumpGroupConfig.GetValueOrDefault().ItemType) : null;
			if (num.GetValueOrDefault() == 1 || num.GetValueOrDefault() == 2)
			{
				ERoleDevelopStateTagType? result = ItemRewardRoleDevelopStateTagUtil.ConvertRequirementStateToTagType(ItemRewardRoleDevelopStateTagUtil.GetRewardExpItemDevelopUpgradeState(configId));
				if (result != null)
				{
					return result;
				}
			}
			int developRoleNeedItemCount = instance.GetDevelopRoleNeedItemCount(configId);
			if (developRoleNeedItemCount <= 0)
			{
				return null;
			}
			if (ModelBase<InventoryModel>.Instance.GetItemCountByConfigId(configId, 0) >= developRoleNeedItemCount)
			{
				return new ERoleDevelopStateTagType?(ERoleDevelopStateTagType.Completed);
			}
			if (instance.IsDevelopRoleNeedItemCanBeSupplemented(configId))
			{
				return new ERoleDevelopStateTagType?(ERoleDevelopStateTagType.CanBeFilled);
			}
			return new ERoleDevelopStateTagType?(ERoleDevelopStateTagType.Lack);
		}

		// Token: 0x0603B149 RID: 241993 RVA: 0x00EF36B8 File Offset: 0x00EF18B8
		public static void FillRewardRoleDevelopStateTagType(List<RewardItemData> rewardItemDataList)
		{
			RoleDevelopModel instance = ModelBase<RoleDevelopModel>.Instance;
			if (instance == null || instance.DevTargetRoleId == 0)
			{
				return;
			}
			foreach (RewardItemData rewardItemData in rewardItemDataList)
			{
				ERoleDevelopStateTagType? rewardRoleDevelopStateTagType = ItemRewardRoleDevelopStateTagUtil.GetRewardRoleDevelopStateTagType(rewardItemData);
				if (rewardRoleDevelopStateTagType != null)
				{
					rewardItemData.SetRoleDevelopStateTagType(rewardRoleDevelopStateTagType);
				}
			}
		}
	}
}
