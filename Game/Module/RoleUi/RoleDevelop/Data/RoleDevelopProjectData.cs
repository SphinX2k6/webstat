using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Module.RoleUi.RoleDevelop.View;

namespace CSharpScript.Game.Module.RoleUi.RoleDevelop.Data
{
	// Token: 0x020050D7 RID: 20695
	[NullableContext(1)]
	[Nullable(0)]
	public class RoleDevelopProjectData : RoleDevelopProjectBaseData
	{
		// Token: 0x06035549 RID: 218441 RVA: 0x00D60D7E File Offset: 0x00D5EF7E
		public RoleDevelopProjectData(int id, RoleDevelopRoleBaseData developRoleData) : base(id, developRoleData)
		{
		}

		// Token: 0x0603554A RID: 218442 RVA: 0x00D60D88 File Offset: 0x00D5EF88
		public override ERoleDevelopRoleType GetRoleType()
		{
			return ERoleDevelopRoleType.Normal;
		}

		// Token: 0x0603554B RID: 218443 RVA: 0x00D60D8C File Offset: 0x00D5EF8C
		public RoleDevProject GetRoleDevProjectConfig()
		{
			return ConfigBase<RoleDevConfig>.Instance.GetRoleDevProjectConfig(this.Id).GetValueOrDefault();
		}

		// Token: 0x0603554C RID: 218444 RVA: 0x00D60DB4 File Offset: 0x00D5EFB4
		public RoleDevCultivateProject GetCultivateProject()
		{
			return RoleDevelopUtil.GetCultivateProject(this.Id).GetValueOrDefault();
		}

		// Token: 0x0603554D RID: 218445 RVA: 0x00D60DD4 File Offset: 0x00D5EFD4
		public RoleDataBase GetRoleData()
		{
			int id = this.Id;
			return ModelBase<RoleModel>.Instance.GetRoleDataById(id, true);
		}

		// Token: 0x0603554E RID: 218446 RVA: 0x00D60DF4 File Offset: 0x00D5EFF4
		public int GetRoleLevel()
		{
			if (ModelBase<RoleModel>.Instance.IsRoleOwned(this.Id))
			{
				return this.GetRoleData().GetLevelData().GetLevel();
			}
			return 1;
		}

		// Token: 0x0603554F RID: 218447 RVA: 0x00D60E1A File Offset: 0x00D5F01A
		public int GetRoleBreachLevel()
		{
			if (ModelBase<RoleModel>.Instance.IsRoleOwned(this.Id))
			{
				return this.GetRoleData().GetLevelData().GetBreachLevel();
			}
			return 0;
		}

		// Token: 0x06035550 RID: 218448 RVA: 0x00D60E40 File Offset: 0x00D5F040
		public int GetRoleExp()
		{
			if (ModelBase<RoleModel>.Instance.IsRoleOwned(this.Id))
			{
				return this.GetRoleData().GetLevelData().GetExp();
			}
			return 0;
		}

		// Token: 0x06035551 RID: 218449 RVA: 0x00D60E66 File Offset: 0x00D5F066
		public bool IsRoleMaxLevel()
		{
			return ModelBase<RoleModel>.Instance.IsRoleOwned(this.Id) && this.GetRoleData().GetLevelData().GetRoleIsMaxLevel();
		}

		// Token: 0x06035552 RID: 218450 RVA: 0x00D60E8C File Offset: 0x00D5F08C
		public bool IsRoleNeedBreakUp()
		{
			return !ModelBase<RoleModel>.Instance.IsRoleOwned(this.Id) || this.GetRoleData().GetLevelData().GetRoleNeedBreakUp();
		}

		// Token: 0x06035553 RID: 218451 RVA: 0x00D60EB4 File Offset: 0x00D5F0B4
		public override int GetRoleTargetLevel()
		{
			return this.GetCultivateProject().RoleLevel;
		}

		// Token: 0x06035554 RID: 218452 RVA: 0x00D60ED0 File Offset: 0x00D5F0D0
		public int GetRoleTargetBreachLevel()
		{
			return this.GetCultivateProject().RoleBreachLevel;
		}

		// Token: 0x06035555 RID: 218453 RVA: 0x00D60EEC File Offset: 0x00D5F0EC
		public override int GetRoleUpgradeExp()
		{
			int num = 0;
			int id = this.Id;
			int roleTargetLevel = this.GetRoleTargetLevel();
			int roleLevel = this.GetRoleLevel();
			int roleExp = this.GetRoleExp();
			for (int i = roleLevel + 1; i <= roleTargetLevel; i++)
			{
				num += ModelBase<RoleModel>.Instance.GetRoleLevelUpExp(id, i);
			}
			return num + this.GetRoleBreachOverflowExp() - roleExp;
		}

		// Token: 0x06035556 RID: 218454 RVA: 0x00D60F44 File Offset: 0x00D5F144
		public int GetRoleBreachOverflowExp()
		{
			int roleBreachLevel = this.GetRoleBreachLevel();
			int num = this.GetRoleTargetBreachLevel() - roleBreachLevel;
			if (num <= 0)
			{
				return 0;
			}
			RoleDevConfig instance = ConfigBase<RoleDevConfig>.Instance;
			RoleDevCulProjectConfig? roleDevCulProjectConfig;
			int valueOrDefault = ((instance != null) ? ((instance.GetRoleDevStaticConfig() != null) ? new int?(roleDevCulProjectConfig.GetValueOrDefault().OverflowExperience) : null) : null).GetValueOrDefault(1);
			return num * valueOrDefault;
		}

		// Token: 0x06035557 RID: 218455 RVA: 0x00D60FB8 File Offset: 0x00D5F1B8
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

		// Token: 0x06035558 RID: 218456 RVA: 0x00D61058 File Offset: 0x00D5F258
		public override List<RoleDevelopNeedItem> GetRoleBreachNeedItems()
		{
			int id = this.Id;
			Dictionary<int, RoleDevelopNeedItem> dictionary = new Dictionary<int, RoleDevelopNeedItem>();
			int roleBreachLevel = this.GetRoleBreachLevel();
			int roleTargetBreachLevel = this.GetRoleTargetBreachLevel();
			for (int i = roleBreachLevel + 1; i <= roleTargetBreachLevel; i++)
			{
				RoleBreach? roleBreachConfig = ConfigBase<RoleConfig>.Instance.GetRoleBreachConfig(id, i);
				if (roleBreachConfig != null)
				{
					foreach (DicIntInt dicIntInt in roleBreachConfig.Value.BreachConsumeIter())
					{
						int key = dicIntInt.Key;
						int value = dicIntInt.Value;
						if (!base.IsShouldSkipItem(key))
						{
							RoleDevelopNeedItem roleDevelopNeedItem;
							if (dictionary.TryGetValue(key, out roleDevelopNeedItem))
							{
								roleDevelopNeedItem.Count += value;
							}
							else
							{
								dictionary[key] = new RoleDevelopNeedItem
								{
									ItemId = key,
									Count = value
								};
							}
						}
					}
				}
			}
			return new List<RoleDevelopNeedItem>(dictionary.Values);
		}

		// Token: 0x06035559 RID: 218457 RVA: 0x00D61158 File Offset: 0x00D5F358
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
						Count = roleDevelopNeedItem.Count
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
						Count = roleDevelopNeedItem3.Count
					};
				}
			}
			return new List<RoleDevelopNeedItem>(dictionary.Values);
		}

		// Token: 0x0603555A RID: 218458 RVA: 0x00D61298 File Offset: 0x00D5F498
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

		// Token: 0x0603555B RID: 218459 RVA: 0x00D61330 File Offset: 0x00D5F530
		public override int GetWeaponType()
		{
			return this.GetRoleDevProjectConfig().WeaponType;
		}

		// Token: 0x0603555C RID: 218460 RVA: 0x00D6134C File Offset: 0x00D5F54C
		public override int GetWeaponTargetLevel()
		{
			return this.GetCultivateProject().WeaponLevel;
		}

		// Token: 0x0603555D RID: 218461 RVA: 0x00D61368 File Offset: 0x00D5F568
		public override int GetWeaponUpgradeExp()
		{
			if (!ModelBase<RoleModel>.Instance.IsRoleOwned(this.Id))
			{
				RoleDevProject? roleDevProjectConfig = ConfigBase<RoleDevConfig>.Instance.GetRoleDevProjectConfig(base.GetId());
				RoleDevWeaponItem? roleDevWeaponItemConfig = ConfigBase<RoleDevConfig>.Instance.GetRoleDevWeaponItemConfig(roleDevProjectConfig.Value.WeaponType);
				int currentProjectNum = RoleDevelopUtil.GetCurrentProjectNum();
				return roleDevWeaponItemConfig.Value.WeaponTypeExperience(currentProjectNum);
			}
			RoleDevelopRoleBaseData developRoleData = this.DevelopRoleData;
			int num = 0;
			WeaponInstance weaponInstance = developRoleData.GetWeaponInstance();
			if (weaponInstance == null)
			{
				return 0;
			}
			int weaponTargetLevel = this.GetWeaponTargetLevel();
			int weaponLevel = developRoleData.GetWeaponLevel();
			int weaponExp = developRoleData.GetWeaponExp();
			for (int i = weaponLevel; i < weaponTargetLevel; i++)
			{
				num += weaponInstance.GetLevelExp(i);
			}
			return num + this.GetWeaponBreachOverflowExp() - weaponExp;
		}

		// Token: 0x0603555E RID: 218462 RVA: 0x00D61424 File Offset: 0x00D5F624
		private int GetWeaponBreachOverflowExp()
		{
			RoleDevelopRoleBaseData developRoleData = this.DevelopRoleData;
			WeaponInstance weaponInstance = developRoleData.GetWeaponInstance();
			if (weaponInstance == null)
			{
				return 0;
			}
			int breachLevel = weaponInstance.GetBreachLevel();
			int num = developRoleData.GetWeaponTargetBreachLevel() - breachLevel;
			if (num <= 0)
			{
				return 0;
			}
			RoleDevConfig instance = ConfigBase<RoleDevConfig>.Instance;
			RoleDevCulProjectConfig? roleDevCulProjectConfig;
			int valueOrDefault = ((instance != null) ? ((instance.GetRoleDevStaticConfig() != null) ? new int?(roleDevCulProjectConfig.GetValueOrDefault().OverflowExperience) : null) : null).GetValueOrDefault(1);
			return num * valueOrDefault;
		}

		// Token: 0x0603555F RID: 218463 RVA: 0x00D614B0 File Offset: 0x00D5F6B0
		public override List<RoleDevelopNeedItem> GetWeaponUpgradeNeedItems()
		{
			if (ModelBase<RoleModel>.Instance.IsRoleOwned(this.Id))
			{
				WeaponInstance weaponInstance = this.DevelopRoleData.GetWeaponInstance();
				if (weaponInstance != null && !ModelBase<WeaponModel>.Instance.IsWeaponHighQuality(weaponInstance))
				{
					return new List<RoleDevelopNeedItem>();
				}
			}
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

		// Token: 0x06035560 RID: 218464 RVA: 0x00D61584 File Offset: 0x00D5F784
		public override List<RoleDevelopNeedItem> GetWeaponBreachNeedItems()
		{
			RoleDevelopRoleBaseData developRoleData = this.DevelopRoleData;
			int weaponTargetBreachLevel = developRoleData.GetWeaponTargetBreachLevel();
			Dictionary<int, RoleDevelopNeedItem> dictionary = new Dictionary<int, RoleDevelopNeedItem>();
			if (!ModelBase<RoleModel>.Instance.IsRoleOwned(this.Id))
			{
				int weaponType = ConfigBase<RoleDevConfig>.Instance.GetRoleDevProjectConfig(base.GetId()).Value.WeaponType;
				RoleDevWeaponItem? roleDevWeaponItemConfig = ConfigBase<RoleDevConfig>.Instance.GetRoleDevWeaponItemConfig(weaponType);
				for (int i = 0; i <= weaponTargetBreachLevel; i++)
				{
					WeaponBreach? weaponBreach = ConfigBase<WeaponConfig>.Instance.GetWeaponBreach(roleDevWeaponItemConfig.Value.WeaponItemGroup, i);
					if (weaponBreach != null)
					{
						foreach (DicIntInt dicIntInt in weaponBreach.Value.ConsumeIter())
						{
							int key = dicIntInt.Key;
							int value = dicIntInt.Value;
							if (!base.IsShouldSkipItem(key))
							{
								RoleDevelopNeedItem roleDevelopNeedItem;
								if (dictionary.TryGetValue(key, out roleDevelopNeedItem))
								{
									roleDevelopNeedItem.Count += value;
								}
								else
								{
									dictionary[key] = new RoleDevelopNeedItem
									{
										ItemId = key,
										Count = value
									};
								}
							}
						}
					}
				}
				return new List<RoleDevelopNeedItem>(dictionary.Values);
			}
			WeaponInstance weaponInstance = developRoleData.GetWeaponInstance();
			if (weaponInstance == null)
			{
				return new List<RoleDevelopNeedItem>();
			}
			if (!ModelBase<WeaponModel>.Instance.IsWeaponHighQuality(weaponInstance))
			{
				return new List<RoleDevelopNeedItem>();
			}
			WeaponConf? weaponConfig = weaponInstance.GetWeaponConfig();
			for (int j = weaponInstance.GetBreachLevel(); j < weaponTargetBreachLevel; j++)
			{
				WeaponBreach? weaponBreach2 = ConfigBase<WeaponConfig>.Instance.GetWeaponBreach(weaponConfig.Value.BreachId, j);
				if (weaponBreach2 != null)
				{
					foreach (DicIntInt dicIntInt2 in weaponBreach2.Value.ConsumeIter())
					{
						int key2 = dicIntInt2.Key;
						int value2 = dicIntInt2.Value;
						if (!base.IsShouldSkipItem(key2))
						{
							RoleDevelopNeedItem roleDevelopNeedItem2;
							if (dictionary.TryGetValue(key2, out roleDevelopNeedItem2))
							{
								roleDevelopNeedItem2.Count += value2;
							}
							else
							{
								dictionary[key2] = new RoleDevelopNeedItem
								{
									ItemId = key2,
									Count = value2
								};
							}
						}
					}
				}
			}
			return new List<RoleDevelopNeedItem>(dictionary.Values);
		}

		// Token: 0x06035561 RID: 218465 RVA: 0x00D617F0 File Offset: 0x00D5F9F0
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

		// Token: 0x06035562 RID: 218466 RVA: 0x00D61888 File Offset: 0x00D5FA88
		public override List<RoleDevelopSkillData> GetSkillDevelopData()
		{
			int id = this.Id;
			RoleDevCultivateProject cultivateProject = this.GetCultivateProject();
			int[] prefectSkillLevelArray = cultivateProject.GetPrefectSkillLevelArray();
			int[] canLevelUpSkillNodeIndexList = ConfigBase<RoleDevConfig>.Instance.GetCanLevelUpSkillNodeIndexList();
			if (canLevelUpSkillNodeIndexList.Length != prefectSkillLevelArray.Length)
			{
				Singleton<Log>.Instance.Error(ELogModule.RoleDev, ELogAuthor.LJS, "LevelUpSkillNodeIndexList长度与PrefectSkillLevel长度不一致", default(ReadOnlySpan<ValueTuple<string, object>>));
				return new List<RoleDevelopSkillData>();
			}
			List<int> list = new List<int>();
			List<int> list2 = new List<int>();
			List<int> list3 = new List<int>();
			RoleInfo? roleConfig = ConfigBase<RoleConfig>.Instance.GetRoleConfig(id);
			bool flag = ModelBase<RoleModel>.Instance.IsRoleOwned(id);
			for (int i = 0; i < canLevelUpSkillNodeIndexList.Length; i++)
			{
				int nodeIndex = canLevelUpSkillNodeIndexList[i];
				int id2 = ConfigBase<RoleSkillConfig>.Instance.GetSkillTreeNodeByGroupIdAndIndex(roleConfig.Value.SkillTreeGroupId, nodeIndex).Value.Id;
				list3.Add(id2);
				if (flag)
				{
					list.Add(ModelBase<RoleModel>.Instance.GetRoleSkillTreeNodeLevel(id, id2));
				}
				else
				{
					list.Add(1);
				}
				list2.Add(prefectSkillLevelArray[i]);
			}
			int[] skillTreeConfigArrayArray = cultivateProject.GetSkillTreeConfigArrayArray();
			if (skillTreeConfigArrayArray != null)
			{
				foreach (int nodeIndex2 in skillTreeConfigArrayArray)
				{
					int id3 = ConfigBase<RoleSkillConfig>.Instance.GetSkillTreeNodeByGroupIdAndIndex(roleConfig.Value.SkillTreeGroupId, nodeIndex2).Value.Id;
					list3.Add(id3);
					if (flag)
					{
						list.Add(ModelBase<RoleModel>.Instance.GetRoleSkillTreeNodeLevel(id, id3));
					}
					else
					{
						list.Add(0);
					}
					list2.Add(1);
				}
			}
			List<RoleDevelopSkillData> list4 = new List<RoleDevelopSkillData>();
			for (int k = 0; k < list3.Count; k++)
			{
				RoleDevelopSkillData item = new RoleDevelopSkillData
				{
					RoleId = id,
					SkillNodeId = list3[k],
					CurrentLevel = list[k],
					TargetLevel = list2[k],
					Index = k
				};
				list4.Add(item);
			}
			return list4;
		}

		// Token: 0x06035563 RID: 218467 RVA: 0x00D61A8D File Offset: 0x00D5FC8D
		public override bool IsSkillPlanFinished()
		{
			if (!ModelBase<RoleModel>.Instance.IsRoleOwned(this.Id))
			{
				return false;
			}
			return this.GetSkillDevelopData().TrueForAll((RoleDevelopSkillData skill) => skill.CurrentLevel >= skill.TargetLevel);
		}

		// Token: 0x06035564 RID: 218468 RVA: 0x00D61AD0 File Offset: 0x00D5FCD0
		public override List<RoleDevelopNeedItem> GetSkillPlanNeedItems()
		{
			Dictionary<int, RoleDevelopNeedItem> dictionary = new Dictionary<int, RoleDevelopNeedItem>();
			bool flag = ModelBase<RoleModel>.Instance.IsRoleOwned(this.Id);
			foreach (RoleDevelopSkillData roleDevelopSkillData in this.GetSkillDevelopData())
			{
				int skillNodeId = roleDevelopSkillData.SkillNodeId;
				int currentLevel = flag ? ModelBase<RoleModel>.Instance.GetRoleSkillTreeNodeLevel(this.Id, skillNodeId) : roleDevelopSkillData.CurrentLevel;
				int targetLevel = roleDevelopSkillData.TargetLevel;
				this.CollectSkillNodeNeedItems(skillNodeId, currentLevel, targetLevel, dictionary);
			}
			return new List<RoleDevelopNeedItem>(dictionary.Values);
		}

		// Token: 0x06035565 RID: 218469 RVA: 0x00D61B7C File Offset: 0x00D5FD7C
		private void CollectSkillNodeNeedItems(int skillNodeId, int currentLevel, int targetLevel, Dictionary<int, RoleDevelopNeedItem> needItemMap)
		{
			if (targetLevel - currentLevel <= 0)
			{
				return;
			}
			for (int i = currentLevel + 1; i <= targetLevel; i++)
			{
				IEnumerable<DicIntInt?> roleSkillTreeConsume = ConfigBase<RoleSkillConfig>.Instance.GetRoleSkillTreeConsume(skillNodeId, i);
				if (roleSkillTreeConsume != null)
				{
					foreach (DicIntInt? dicIntInt in roleSkillTreeConsume)
					{
						int key = dicIntInt.Value.Key;
						int value = dicIntInt.Value.Value;
						if (!base.IsShouldSkipItem(key))
						{
							RoleDevelopNeedItem roleDevelopNeedItem;
							if (needItemMap.TryGetValue(key, out roleDevelopNeedItem))
							{
								roleDevelopNeedItem.Count += value;
							}
							else
							{
								needItemMap[key] = new RoleDevelopNeedItem
								{
									ItemId = key,
									Count = value
								};
							}
						}
					}
				}
			}
		}

		// Token: 0x06035566 RID: 218470 RVA: 0x00D61C58 File Offset: 0x00D5FE58
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

		// Token: 0x06035567 RID: 218471 RVA: 0x00D61CD8 File Offset: 0x00D5FED8
		public override bool IsShowUpgradeHint(ERoleDevelopCategoryType categoryType)
		{
			if (ModelBase<RoleModel>.Instance.IsRoleOwned(this.Id))
			{
				switch (categoryType)
				{
				case ERoleDevelopCategoryType.Role:
					return !this.IsRoleDevelopFinished() && RoleDevelopUtil.CheckIsAllNeedItemsEnoughOrCanBeFilled(this.GetRoleDevelopNeedItems());
				case ERoleDevelopCategoryType.Weapon:
				{
					WeaponInstance weaponInstance = this.DevelopRoleData.GetWeaponInstance();
					if (weaponInstance == null || !ModelBase<WeaponModel>.Instance.IsWeaponHighQuality(weaponInstance) || this.IsWeaponDevelopFinished())
					{
						return false;
					}
					List<RoleDevelopNeedItem> list = new List<RoleDevelopNeedItem>();
					list.AddRange(this.GetWeaponUpgradeNeedItems());
					list.AddRange(this.GetWeaponBreachNeedItems());
					return RoleDevelopUtil.CheckIsAllNeedItemsEnoughOrCanBeFilled(list);
				}
				case ERoleDevelopCategoryType.Phantom:
					return false;
				case ERoleDevelopCategoryType.Skill:
					return !this.IsSkillPlanFinished() && RoleDevelopUtil.CheckIsAllNeedItemsEnoughOrCanBeFilled(this.GetSkillPlanNeedItems());
				}
			}
			return false;
		}

		// Token: 0x06035568 RID: 218472 RVA: 0x00D61D8C File Offset: 0x00D5FF8C
		public override bool IsShowFinishHint(ERoleDevelopCategoryType categoryType)
		{
			if (ModelBase<RoleModel>.Instance.IsRoleOwned(this.Id))
			{
				switch (categoryType)
				{
				case ERoleDevelopCategoryType.Role:
					return this.IsRoleDevelopFinished();
				case ERoleDevelopCategoryType.Weapon:
				{
					WeaponInstance weaponInstance = this.DevelopRoleData.GetWeaponInstance();
					return weaponInstance != null && ModelBase<WeaponModel>.Instance.IsWeaponHighQuality(weaponInstance) && this.IsWeaponDevelopFinished();
				}
				case ERoleDevelopCategoryType.Phantom:
					return false;
				case ERoleDevelopCategoryType.Skill:
					return this.IsSkillPlanFinished();
				}
			}
			return false;
		}

		// Token: 0x06035569 RID: 218473 RVA: 0x00D61DFB File Offset: 0x00D5FFFB
		public override bool IsRoleDevelopFinished()
		{
			return this.IsRoleReachTargetLevel() && this.IsRoleReachBreachLevel();
		}

		// Token: 0x0603556A RID: 218474 RVA: 0x00D61E0D File Offset: 0x00D6000D
		public override bool IsWeaponDevelopFinished()
		{
			return this.IsWeaponReachTargetLevel() && this.IsWeaponReachBreachLevel();
		}

		// Token: 0x0603556B RID: 218475 RVA: 0x00D61E1F File Offset: 0x00D6001F
		public override bool IsRoleReachTargetLevel()
		{
			return this.GetRoleLevel() >= this.GetRoleTargetLevel();
		}

		// Token: 0x0603556C RID: 218476 RVA: 0x00D61E32 File Offset: 0x00D60032
		public override bool IsRoleReachBreachLevel()
		{
			return this.GetRoleBreachLevel() >= this.GetRoleTargetBreachLevel();
		}

		// Token: 0x0603556D RID: 218477 RVA: 0x00D61E45 File Offset: 0x00D60045
		public override bool IsWeaponReachTargetLevel()
		{
			return this.DevelopRoleData.GetWeaponLevel() >= this.GetWeaponTargetLevel();
		}

		// Token: 0x0603556E RID: 218478 RVA: 0x00D61E5D File Offset: 0x00D6005D
		public override bool IsWeaponReachBreachLevel()
		{
			return this.DevelopRoleData.GetWeaponBreachLevel() >= this.DevelopRoleData.GetWeaponTargetBreachLevel();
		}
	}
}
