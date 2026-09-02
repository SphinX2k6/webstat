using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;

// Token: 0x0200280A RID: 10250
public class RoleDevPhantomFetterGroupData : RoleDevPhantomVisionSuitItemData
{
	// Token: 0x060143A9 RID: 82857 RVA: 0x005A22E8 File Offset: 0x005A04E8
	[NullableContext(2)]
	public void InitByFetterGroup(int fetterGroupId, int roleId, List<int> recommendGroupIds = null)
	{
		if (recommendGroupIds == null)
		{
			recommendGroupIds = new List<int>();
		}
		int num = 4;
		int[] fetterGroupMonsterIdArray = ModelBase<PhantomBattleModel>.Instance.GetFetterGroupMonsterIdArray(fetterGroupId);
		if (fetterGroupMonsterIdArray != null && fetterGroupMonsterIdArray.Length != 0)
		{
			List<IPhantomMonsterItemData> list = new List<IPhantomMonsterItemData>();
			foreach (int monsterId in fetterGroupMonsterIdArray)
			{
				if (this.IsMonsterCost4(monsterId, num))
				{
					list.Add(this.CreateMonsterData(monsterId));
				}
			}
			if (list.Count > 0)
			{
				string buttonName = "RoleProject_Button02";
				int id = 1;
				EVisionSuitItemType itemType = EVisionSuitItemType.Phantom;
				DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(4, 1);
				defaultInterpolatedStringHandler.AppendLiteral("Cost");
				defaultInterpolatedStringHandler.AppendFormatted<int>(num);
				base.InitByBaseData(id, itemType, defaultInterpolatedStringHandler.ToStringAndClear(), num, buttonName, "");
				base.SetMonsterDataList(list);
				base.SetFetterGroupInfo(fetterGroupId, roleId, recommendGroupIds);
			}
		}
	}

	// Token: 0x060143AA RID: 82858 RVA: 0x005A23A8 File Offset: 0x005A05A8
	private bool IsMonsterCost4(int monsterId, int targetCost)
	{
		IReadOnlyList<PhantomItem> phantomItemByMonsterId = ConfigBase<PhantomBattleConfig>.Instance.GetPhantomItemByMonsterId(monsterId);
		if (phantomItemByMonsterId == null || phantomItemByMonsterId.Count == 0)
		{
			return false;
		}
		int rarity = phantomItemByMonsterId[0].Rarity;
		PhantomRarity? phantomRareConfig = ConfigBase<PhantomBattleConfig>.Instance.GetPhantomRareConfig(rarity);
		return phantomRareConfig != null && phantomRareConfig.Value.Cost == targetCost;
	}

	// Token: 0x060143AB RID: 82859 RVA: 0x005A2408 File Offset: 0x005A0608
	[NullableContext(1)]
	private IPhantomMonsterItemData CreateMonsterData(int monsterId)
	{
		return new PhantomMonsterItemData
		{
			MonsterId = monsterId,
			QualityId = 0,
			RoleId = 0
		};
	}
}
