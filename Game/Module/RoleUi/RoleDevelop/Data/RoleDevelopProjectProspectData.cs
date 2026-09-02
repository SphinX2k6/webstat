using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Module.RoleUi.RoleDevelop.View;

namespace CSharpScript.Game.Module.RoleUi.RoleDevelop.Data
{
	// Token: 0x020050D8 RID: 20696
	[NullableContext(1)]
	[Nullable(0)]
	public class RoleDevelopProjectProspectData : RoleDevelopProjectBaseData
	{
		// Token: 0x0603556F RID: 218479 RVA: 0x00D61E7A File Offset: 0x00D6007A
		public RoleDevelopProjectProspectData(int id, RoleDevelopRoleBaseData developRoleData) : base(id, developRoleData)
		{
		}

		// Token: 0x06035570 RID: 218480 RVA: 0x00D61E84 File Offset: 0x00D60084
		public override ERoleDevelopRoleType GetRoleType()
		{
			return ERoleDevelopRoleType.Prospect;
		}

		// Token: 0x06035571 RID: 218481 RVA: 0x00D61E87 File Offset: 0x00D60087
		public IRoleDevProsProjectConfig GetProsProjectConfig()
		{
			return ConfigBase<RoleDevConfig>.Instance.GetRoleDevProsProjectConfig(this.Id);
		}

		// Token: 0x06035572 RID: 218482 RVA: 0x00D61E99 File Offset: 0x00D60099
		public override int GetRoleTargetLevel()
		{
			return this.GetProsProjectConfig().RoleGoalLevel;
		}

		// Token: 0x06035573 RID: 218483 RVA: 0x00D61EA6 File Offset: 0x00D600A6
		public override int GetRoleUpgradeExp()
		{
			return this.GetProsProjectConfig().RoleExperience;
		}

		// Token: 0x06035574 RID: 218484 RVA: 0x00D61EB4 File Offset: 0x00D600B4
		public override List<RoleDevelopNeedItem> GetRoleUpgradeNeedItems()
		{
			List<RoleDevelopNeedItem> list = new List<RoleDevelopNeedItem>();
			foreach (ISelectedData selectedData in base.GetSortedRoleExpItemList())
			{
				list.Add(new RoleDevelopNeedItem
				{
					ItemId = selectedData.ItemId,
					Count = selectedData.Count
				});
			}
			return RoleDevelopUtil.CalcUpgradeNeedItems(this.GetRoleUpgradeExp(), list, (int itemId) => ModelBase<RoleModel>.Instance.GetRoleExpItemExp(itemId).GetValueOrDefault(0));
		}

		// Token: 0x06035575 RID: 218485 RVA: 0x00D61F54 File Offset: 0x00D60154
		public override List<RoleDevelopNeedItem> GetRoleBreachNeedItems()
		{
			List<RoleDevelopNeedItem> list = new List<RoleDevelopNeedItem>();
			foreach (int itemGroupId in this.GetProsProjectConfig().RoleItemGroup)
			{
				RoleDevProsRoleItem? roleDevProsRoleItemConfig = ConfigBase<RoleDevConfig>.Instance.GetRoleDevProsRoleItemConfig(itemGroupId);
				EItemMaterialType itemTypeId = (EItemMaterialType)roleDevProsRoleItemConfig.Value.ItemTypeId;
				foreach (IntPair intPair in roleDevProsRoleItemConfig.Value.ItemGroupIter())
				{
					int item = intPair.Item1;
					int item2 = intPair.Item2;
					list.Add(new RoleDevelopNeedItem
					{
						ItemId = item,
						Count = item2,
						Type = new EItemMaterialType?(itemTypeId)
					});
				}
			}
			return list;
		}

		// Token: 0x06035576 RID: 218486 RVA: 0x00D62050 File Offset: 0x00D60250
		public override List<RoleDevelopNeedItem> GetRoleDevelopNeedItems()
		{
			Dictionary<int, RoleDevelopNeedItem> dictionary = new Dictionary<int, RoleDevelopNeedItem>();
			List<RoleDevelopNeedItem> roleUpgradeNeedItems = this.GetRoleUpgradeNeedItems();
			List<RoleDevelopNeedItem> roleBreachNeedItems = this.GetRoleBreachNeedItems();
			foreach (RoleDevelopNeedItem roleDevelopNeedItem in roleUpgradeNeedItems)
			{
				RoleDevelopNeedItem roleDevelopNeedItem2;
				if (dictionary.TryGetValue(roleDevelopNeedItem.ItemId, out roleDevelopNeedItem2))
				{
					roleDevelopNeedItem2.Count += roleDevelopNeedItem.Count;
				}
				else
				{
					dictionary[roleDevelopNeedItem.ItemId] = new RoleDevelopNeedItem
					{
						ItemId = roleDevelopNeedItem.ItemId,
						Count = roleDevelopNeedItem.Count,
						Type = roleDevelopNeedItem.Type
					};
				}
			}
			foreach (RoleDevelopNeedItem roleDevelopNeedItem3 in roleBreachNeedItems)
			{
				RoleDevelopNeedItem roleDevelopNeedItem4;
				if (dictionary.TryGetValue(roleDevelopNeedItem3.ItemId, out roleDevelopNeedItem4))
				{
					roleDevelopNeedItem4.Count += roleDevelopNeedItem3.Count;
				}
				else
				{
					dictionary[roleDevelopNeedItem3.ItemId] = new RoleDevelopNeedItem
					{
						ItemId = roleDevelopNeedItem3.ItemId,
						Count = roleDevelopNeedItem3.Count,
						Type = roleDevelopNeedItem3.Type
					};
				}
			}
			return new List<RoleDevelopNeedItem>(dictionary.Values);
		}

		// Token: 0x06035577 RID: 218487 RVA: 0x00D621A8 File Offset: 0x00D603A8
		public override List<RoleDevelopProjectMaterialItemData> GetRoleDevelopProjectViewItems()
		{
			List<RoleDevelopProjectMaterialItemData> list = new List<RoleDevelopProjectMaterialItemData>();
			List<RoleDevelopNeedItem> list2 = new List<RoleDevelopNeedItem>();
			list2.AddRange(this.GetRoleUpgradeNeedItems());
			list2.AddRange(this.GetRoleBreachNeedItems());
			foreach (RoleDevelopItemGroup groupItem in RoleDevelopUtil.BuildGroupItemDataByNeedItems(list2, false, true, false))
			{
				list.Add(new RoleDevelopProjectMaterialItemData
				{
					GroupItem = groupItem,
					JumpCallback = new Action<RoleDevelopItemGroup>(base.HandleItemJumpCallback)
				});
			}
			return list;
		}

		// Token: 0x06035578 RID: 218488 RVA: 0x00D62240 File Offset: 0x00D60440
		public override int GetWeaponType()
		{
			return this.GetProsProjectConfig().WeaponType;
		}

		// Token: 0x06035579 RID: 218489 RVA: 0x00D6224D File Offset: 0x00D6044D
		public override int GetWeaponTargetLevel()
		{
			return this.GetProsProjectConfig().WeaponGoalLevel;
		}

		// Token: 0x0603557A RID: 218490 RVA: 0x00D6225A File Offset: 0x00D6045A
		public override int GetWeaponUpgradeExp()
		{
			return this.GetProsProjectConfig().WeaponExperience;
		}

		// Token: 0x0603557B RID: 218491 RVA: 0x00D62268 File Offset: 0x00D60468
		public override List<RoleDevelopNeedItem> GetWeaponUpgradeNeedItems()
		{
			List<RoleDevelopNeedItem> list = new List<RoleDevelopNeedItem>();
			foreach (ISelectedData selectedData in base.GetSortedWeaponExpItemList())
			{
				list.Add(new RoleDevelopNeedItem
				{
					ItemId = selectedData.ItemId,
					Count = selectedData.Count
				});
			}
			return RoleDevelopUtil.CalcUpgradeNeedItems(this.GetWeaponUpgradeExp(), list, (int itemId) => ModelBase<WeaponModel>.Instance.GetWeaponItemExp(0, itemId));
		}

		// Token: 0x0603557C RID: 218492 RVA: 0x00D62308 File Offset: 0x00D60508
		public override List<RoleDevelopNeedItem> GetWeaponBreachNeedItems()
		{
			IRoleDevProsProjectConfig prosProjectConfig = this.GetProsProjectConfig();
			List<RoleDevelopNeedItem> list = new List<RoleDevelopNeedItem>();
			foreach (int itemGroupId in prosProjectConfig.WeaponBreachItemGroup)
			{
				RoleDevProsRoleItem? roleDevProsRoleItemConfig = ConfigBase<RoleDevConfig>.Instance.GetRoleDevProsRoleItemConfig(itemGroupId);
				if (roleDevProsRoleItemConfig != null)
				{
					EItemMaterialType itemTypeId = (EItemMaterialType)roleDevProsRoleItemConfig.Value.ItemTypeId;
					foreach (IntPair intPair in roleDevProsRoleItemConfig.Value.ItemGroupIter())
					{
						int item = intPair.Item1;
						int item2 = intPair.Item2;
						list.Add(new RoleDevelopNeedItem
						{
							ItemId = item,
							Count = item2,
							Type = new EItemMaterialType?(itemTypeId)
						});
					}
				}
			}
			return list;
		}

		// Token: 0x0603557D RID: 218493 RVA: 0x00D62410 File Offset: 0x00D60610
		public override List<RoleDevelopProjectMaterialItemData> GetWeaponDevelopProjectViewItems()
		{
			List<RoleDevelopProjectMaterialItemData> list = new List<RoleDevelopProjectMaterialItemData>();
			List<RoleDevelopNeedItem> list2 = new List<RoleDevelopNeedItem>();
			list2.AddRange(this.GetWeaponUpgradeNeedItems());
			list2.AddRange(this.GetWeaponBreachNeedItems());
			foreach (RoleDevelopItemGroup groupItem in RoleDevelopUtil.BuildGroupItemDataByNeedItems(list2, false, true, false))
			{
				list.Add(new RoleDevelopProjectMaterialItemData
				{
					GroupItem = groupItem,
					JumpCallback = new Action<RoleDevelopItemGroup>(base.HandleItemJumpCallback)
				});
			}
			return list;
		}

		// Token: 0x0603557E RID: 218494 RVA: 0x00D624A8 File Offset: 0x00D606A8
		public override List<RoleDevelopSkillData> GetSkillDevelopData()
		{
			int[] canLevelUpSkillNodeIndexList = ConfigBase<RoleDevConfig>.Instance.GetCanLevelUpSkillNodeIndexList();
			List<RoleDevelopSkillData> list = new List<RoleDevelopSkillData>();
			for (int i = 0; i < canLevelUpSkillNodeIndexList.Length; i++)
			{
				RoleDevelopSkillData item = new RoleDevelopSkillData
				{
					RoleId = this.Id,
					SkillNodeId = 0,
					CurrentLevel = 1,
					TargetLevel = 10,
					Index = i
				};
				list.Add(item);
			}
			return list;
		}

		// Token: 0x0603557F RID: 218495 RVA: 0x00D6250B File Offset: 0x00D6070B
		public override bool IsSkillPlanFinished()
		{
			return false;
		}

		// Token: 0x06035580 RID: 218496 RVA: 0x00D62510 File Offset: 0x00D60710
		public override List<RoleDevelopNeedItem> GetSkillPlanNeedItems()
		{
			IRoleDevProsProjectConfig prosProjectConfig = this.GetProsProjectConfig();
			List<RoleDevelopNeedItem> list = new List<RoleDevelopNeedItem>();
			foreach (int itemGroupId in prosProjectConfig.SkillItemGroup)
			{
				RoleDevProsRoleItem? roleDevProsRoleItemConfig = ConfigBase<RoleDevConfig>.Instance.GetRoleDevProsRoleItemConfig(itemGroupId);
				if (roleDevProsRoleItemConfig != null)
				{
					EItemMaterialType itemTypeId = (EItemMaterialType)roleDevProsRoleItemConfig.Value.ItemTypeId;
					foreach (IntPair intPair in roleDevProsRoleItemConfig.Value.ItemGroupIter())
					{
						int item = intPair.Item1;
						int item2 = intPair.Item2;
						list.Add(new RoleDevelopNeedItem
						{
							ItemId = item,
							Count = item2,
							Type = new EItemMaterialType?(itemTypeId)
						});
					}
				}
			}
			return list;
		}

		// Token: 0x06035581 RID: 218497 RVA: 0x00D62618 File Offset: 0x00D60818
		public override List<RoleDevelopProjectMaterialItemData> GetSkillDevelopProjectViewItems()
		{
			List<RoleDevelopProjectMaterialItemData> list = new List<RoleDevelopProjectMaterialItemData>();
			foreach (RoleDevelopItemGroup groupItem in RoleDevelopUtil.BuildGroupItemDataByNeedItems(this.GetSkillPlanNeedItems(), false, true, false))
			{
				list.Add(new RoleDevelopProjectMaterialItemData
				{
					GroupItem = groupItem,
					JumpCallback = new Action<RoleDevelopItemGroup>(base.HandleItemJumpCallback)
				});
			}
			return list;
		}

		// Token: 0x06035582 RID: 218498 RVA: 0x00D62698 File Offset: 0x00D60898
		public override bool IsShowUpgradeHint(ERoleDevelopCategoryType categoryType)
		{
			return false;
		}

		// Token: 0x06035583 RID: 218499 RVA: 0x00D6269B File Offset: 0x00D6089B
		public override bool IsShowFinishHint(ERoleDevelopCategoryType categoryType)
		{
			return false;
		}

		// Token: 0x06035584 RID: 218500 RVA: 0x00D6269E File Offset: 0x00D6089E
		public override bool IsRoleDevelopFinished()
		{
			return false;
		}

		// Token: 0x06035585 RID: 218501 RVA: 0x00D626A1 File Offset: 0x00D608A1
		public override bool IsWeaponDevelopFinished()
		{
			return false;
		}

		// Token: 0x06035586 RID: 218502 RVA: 0x00D626A4 File Offset: 0x00D608A4
		public override bool IsRoleReachTargetLevel()
		{
			return false;
		}

		// Token: 0x06035587 RID: 218503 RVA: 0x00D626A7 File Offset: 0x00D608A7
		public override bool IsRoleReachBreachLevel()
		{
			return false;
		}

		// Token: 0x06035588 RID: 218504 RVA: 0x00D626AA File Offset: 0x00D608AA
		public override bool IsWeaponReachTargetLevel()
		{
			return false;
		}

		// Token: 0x06035589 RID: 218505 RVA: 0x00D626AD File Offset: 0x00D608AD
		public override bool IsWeaponReachBreachLevel()
		{
			return false;
		}
	}
}
