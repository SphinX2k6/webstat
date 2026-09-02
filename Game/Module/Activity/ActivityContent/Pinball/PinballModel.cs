using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Module.Inventory;
using CSharpScript.Game.Module.RoleUi;
using UnrealEngine;

namespace CSharpScript.Game.Module.Activity.ActivityContent.Pinball
{
	// Token: 0x0200658D RID: 25997
	[NullableContext(1)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	[Model(0)]
	public class PinballModel : ModelBase<PinballModel>
	{
		// Token: 0x06040F49 RID: 266057 RVA: 0x010AABA1 File Offset: 0x010A8DA1
		public void SetActivityId(int id)
		{
			this.ActivityDataIdInternal = id;
		}

		// Token: 0x17009EB4 RID: 40628
		// (get) Token: 0x06040F4A RID: 266058 RVA: 0x010AABAA File Offset: 0x010A8DAA
		public PinballActivityData ActivityData
		{
			get
			{
				return ModelBase<ActivityModel>.Instance.GetActivityById(this.ActivityDataIdInternal) as PinballActivityData;
			}
		}

		// Token: 0x06040F4B RID: 266059 RVA: 0x010AABC4 File Offset: 0x010A8DC4
		[NullableContext(2)]
		public PinballActivityData GetActivityDataByActivityId(int activityId)
		{
			ActivityBaseData activityById = ModelBase<ActivityModel>.Instance.GetActivityById(activityId);
			if (activityById == null)
			{
				return null;
			}
			return activityById as PinballActivityData;
		}

		// Token: 0x06040F4C RID: 266060 RVA: 0x010AABE8 File Offset: 0x010A8DE8
		public List<PinballWeaponData> GetAllWeaponDataList()
		{
			return this.ActivityData.GetWeaponDataAll();
		}

		// Token: 0x06040F4D RID: 266061 RVA: 0x010AABF5 File Offset: 0x010A8DF5
		[NullableContext(2)]
		public PinballWeaponData GetWeaponDataByIncId(int incId)
		{
			return this.ActivityData.GetWeaponDataByIncId(incId);
		}

		// Token: 0x06040F4E RID: 266062 RVA: 0x010AAC03 File Offset: 0x010A8E03
		public void RemoveWeaponData(List<int> incIdList)
		{
			this.ActivityData.RemoveWeaponData(incIdList);
			this.ActivityData.UpdateRoleWeaponRedDot();
		}

		// Token: 0x06040F4F RID: 266063 RVA: 0x010AAC1C File Offset: 0x010A8E1C
		public int GetWeaponItemCount(int configId)
		{
			return this.ActivityData.GetWeaponCountByConfigId(configId);
		}

		// Token: 0x06040F50 RID: 266064 RVA: 0x010AAC2C File Offset: 0x010A8E2C
		public string GetFormatAttributeValueString(PinballPropertyIndex config, float attributeValue)
		{
			float num = attributeValue;
			if (config.ShowCoefficient > 1)
			{
				num /= (float)config.ShowCoefficient;
			}
			if (config.IsPercent)
			{
				int num2 = 100;
				return Singleton<MathUtils>.Instance.GetFloatPointFloorString((double)(num / (float)num2), 1) + "%";
			}
			return ((int)Math.Floor((double)num)).ToString();
		}

		// Token: 0x06040F51 RID: 266065 RVA: 0x010AAC88 File Offset: 0x010A8E88
		public int GetMaxLevelByGroupId(int groupId)
		{
			IReadOnlyList<PinballRoleLevelConfig> pinballRoleLevelConfigListByGroupId = ConfigBase<PinballConfig>.Instance.GetPinballRoleLevelConfigListByGroupId(groupId);
			int num = 0;
			if (pinballRoleLevelConfigListByGroupId != null)
			{
				foreach (PinballRoleLevelConfig pinballRoleLevelConfig in pinballRoleLevelConfigListByGroupId)
				{
					num = Math.Max(num, pinballRoleLevelConfig.Level);
				}
			}
			return num;
		}

		// Token: 0x06040F52 RID: 266066 RVA: 0x010AACEC File Offset: 0x010A8EEC
		public int GetMaxLevelByPinballRoleConfig(PinballRoleConfig roleConfig)
		{
			return this.GetMaxLevelByGroupId(roleConfig.GradeUpGroup);
		}

		// Token: 0x06040F53 RID: 266067 RVA: 0x010AACFC File Offset: 0x010A8EFC
		public int GetMaxLevelByPinballByRoleId(int roleId)
		{
			PinballRoleConfig? pinballRoleConfigById = ConfigBase<PinballConfig>.Instance.GetPinballRoleConfigById(roleId);
			if (pinballRoleConfigById == null)
			{
				return 0;
			}
			return this.GetMaxLevelByPinballRoleConfig(pinballRoleConfigById.Value);
		}

		// Token: 0x06040F54 RID: 266068 RVA: 0x010AAD30 File Offset: 0x010A8F30
		public string GetRoleNameByPinballRoleConfig(PinballRoleConfig roleConfig)
		{
			RoleInfo? roleConfig2 = ConfigBase<RoleConfig>.Instance.GetRoleConfig(roleConfig.RoleId);
			return ((roleConfig2 != null) ? roleConfig2.GetValueOrDefault().Name : null) ?? "";
		}

		// Token: 0x06040F55 RID: 266069 RVA: 0x010AAD74 File Offset: 0x010A8F74
		public string GetRoleNameByPinballRoleId(int roleId)
		{
			PinballRoleConfig? pinballRoleConfigById = ConfigBase<PinballConfig>.Instance.GetPinballRoleConfigById(roleId);
			if (pinballRoleConfigById == null)
			{
				return "";
			}
			return this.GetRoleNameByPinballRoleConfig(pinballRoleConfigById.Value);
		}

		// Token: 0x06040F56 RID: 266070 RVA: 0x010AADAC File Offset: 0x010A8FAC
		public int GetRoleLevelUpCostItemId(int activityId)
		{
			PinballActivity? pinballActivityConfigByActivityId = ConfigBase<PinballConfig>.Instance.GetPinballActivityConfigByActivityId(activityId);
			if (pinballActivityConfigByActivityId == null)
			{
				return 0;
			}
			return pinballActivityConfigByActivityId.Value.ExpItemId;
		}

		// Token: 0x06040F57 RID: 266071 RVA: 0x010AADE0 File Offset: 0x010A8FE0
		public int GetRoleLevelUpCostCount(int gradeUpGroup, int curLevel, int targetLevel)
		{
			int num = 0;
			for (int i = curLevel; i < targetLevel; i++)
			{
				PinballRoleLevelConfig? pinballRoleLevelConfigByGroupIdAndLevel = ConfigBase<PinballConfig>.Instance.GetPinballRoleLevelConfigByGroupIdAndLevel(gradeUpGroup, i);
				if (pinballRoleLevelConfigByGroupIdAndLevel != null)
				{
					num += pinballRoleLevelConfigByGroupIdAndLevel.Value.Consume;
				}
			}
			return num;
		}

		// Token: 0x06040F58 RID: 266072 RVA: 0x010AAE24 File Offset: 0x010A9024
		public bool IsRoleMaxLevel(int roleId)
		{
			PinballRoleConfig? pinballRoleConfigById = ConfigBase<PinballConfig>.Instance.GetPinballRoleConfigById(roleId);
			if (pinballRoleConfigById == null)
			{
				return false;
			}
			int maxLevelByPinballRoleConfig = this.GetMaxLevelByPinballRoleConfig(pinballRoleConfigById.Value);
			PinballRoleData roleData = ModelBase<PinballModel>.Instance.ActivityData.GetRoleData(roleId);
			return roleData != null && roleData.GetLevel() >= maxLevelByPinballRoleConfig;
		}

		// Token: 0x06040F59 RID: 266073 RVA: 0x010AAE78 File Offset: 0x010A9078
		public int GetPinballWeaponPackageCapacity()
		{
			int itemTypeId = 10;
			int packageId = ConfigBase<InventoryConfig>.Instance.GetItemMainTypeConfig(itemTypeId).Value.PackageId;
			return ConfigBase<InventoryConfig>.Instance.GetPackageConfig(packageId).Value.Capacity;
		}

		// Token: 0x06040F5A RID: 266074 RVA: 0x010AAEC1 File Offset: 0x010A90C1
		public void SetBattleCenterRootItem(UUIItem item)
		{
			this.BattleCenterRootItem = item;
		}

		// Token: 0x06040F5B RID: 266075 RVA: 0x010AAECA File Offset: 0x010A90CA
		[NullableContext(2)]
		public UUIItem GetBattleCenterRootItem()
		{
			return this.BattleCenterRootItem;
		}

		// Token: 0x06040F5C RID: 266076 RVA: 0x010AAED2 File Offset: 0x010A90D2
		public void ClearBattleCenterRootItem()
		{
			this.BattleCenterRootItem = null;
		}

		// Token: 0x06040F5D RID: 266077 RVA: 0x010AAEDB File Offset: 0x010A90DB
		public int GetSelectRoleFormationNumber(int roleId)
		{
			return this.SelectRoleHandleList.IndexOf(roleId) + 1;
		}

		// Token: 0x06040F5E RID: 266078 RVA: 0x010AAEEC File Offset: 0x010A90EC
		public void UnSelectRoleInHandleList(int roleId)
		{
			this.SelectRoleHandleList.RemoveAll((int id) => id == roleId);
		}

		// Token: 0x06040F5F RID: 266079 RVA: 0x010AAF1E File Offset: 0x010A911E
		public void SelectRoleInHandleList(int roleId)
		{
			this.SelectRoleHandleList.Add(roleId);
		}

		// Token: 0x06040F60 RID: 266080 RVA: 0x010AAF2C File Offset: 0x010A912C
		public List<int> GetPinballCanSelectRoleList()
		{
			PinballActivityData activityData = this.ActivityData;
			return ((activityData != null) ? activityData.GetUnlockRoleList() : null) ?? new List<int>();
		}

		// Token: 0x06040F61 RID: 266081 RVA: 0x010AAF4C File Offset: 0x010A914C
		public int GetPinballSelectRoleLevelAverage(List<int> roleIdList)
		{
			if (roleIdList.Count <= 0)
			{
				return 0;
			}
			int num = 0;
			foreach (int roleId in roleIdList)
			{
				num += this.GetRoleLevel(roleId);
			}
			return num / roleIdList.Count;
		}

		// Token: 0x06040F62 RID: 266082 RVA: 0x010AAFB4 File Offset: 0x010A91B4
		public List<int> GetPinballLevelLastSelectedRoleList(int formationGroup)
		{
			PinballActivityData activityData = this.ActivityData;
			int[] collection;
			if (activityData != null && activityData.LevelFormationMap.TryGetValue(formationGroup, out collection))
			{
				return new List<int>(collection);
			}
			return new List<int>();
		}

		// Token: 0x06040F63 RID: 266083 RVA: 0x010AAFE9 File Offset: 0x010A91E9
		[NullableContext(2)]
		public PinballRoleData GetRoleData(int roleId)
		{
			PinballActivityData activityData = this.ActivityData;
			if (activityData == null)
			{
				return null;
			}
			return activityData.GetRoleData(roleId);
		}

		// Token: 0x06040F64 RID: 266084 RVA: 0x010AAFFD File Offset: 0x010A91FD
		public bool IsRoleUnlock(int roleId)
		{
			PinballActivityData activityData = this.ActivityData;
			return ((activityData != null) ? activityData.GetRoleData(roleId) : null) != null;
		}

		// Token: 0x06040F65 RID: 266085 RVA: 0x010AB018 File Offset: 0x010A9218
		public int GetRoleLevel(int roleId)
		{
			PinballActivityData activityData = this.ActivityData;
			int? num;
			if (activityData == null)
			{
				num = null;
			}
			else
			{
				PinballRoleData roleData = activityData.GetRoleData(roleId);
				num = ((roleData != null) ? new int?(roleData.GetLevel()) : null);
			}
			int? num2 = num;
			return num2.GetValueOrDefault();
		}

		// Token: 0x06040F66 RID: 266086 RVA: 0x010AB061 File Offset: 0x010A9261
		[NullableContext(2)]
		public PinballWeaponData GetRoleWeapon(int roleId)
		{
			PinballActivityData activityData = this.ActivityData;
			if (activityData == null)
			{
				return null;
			}
			PinballRoleData roleData = activityData.GetRoleData(roleId);
			if (roleData == null)
			{
				return null;
			}
			return roleData.GetWeaponData();
		}

		// Token: 0x06040F67 RID: 266087 RVA: 0x010AB080 File Offset: 0x010A9280
		public bool IsRecommendRole(int roleId)
		{
			if (this.CurrentFormationLevel == 0)
			{
				return false;
			}
			PinballLevelConfig? pinballLevelConfigById = ConfigBase<PinballConfig>.Instance.GetPinballLevelConfigById(this.CurrentFormationLevel);
			if (pinballLevelConfigById == null)
			{
				return false;
			}
			int recommendRoleLength = pinballLevelConfigById.Value.RecommendRoleLength;
			for (int i = 0; i < recommendRoleLength; i++)
			{
				if (pinballLevelConfigById.Value.RecommendRole(i) == roleId)
				{
					return true;
				}
			}
			return false;
		}

		// Token: 0x06040F68 RID: 266088 RVA: 0x010AB0E5 File Offset: 0x010A92E5
		public bool IsRoleFunctionOpen()
		{
			PinballActivityData activityData = this.ActivityData;
			return activityData != null && activityData.IsRoleFunctionOpen();
		}

		// Token: 0x06040F69 RID: 266089 RVA: 0x010AB0F8 File Offset: 0x010A92F8
		public bool GetRoleRedDot(int activityId, int roleId)
		{
			PinballActivityData activityDataByActivityId = this.GetActivityDataByActivityId(activityId);
			if (activityDataByActivityId == null)
			{
				return false;
			}
			PinballRoleData roleData = activityDataByActivityId.GetRoleData(roleId);
			if (roleData == null)
			{
				return false;
			}
			if (roleData.IsLocked())
			{
				return false;
			}
			int subId = roleData.GetConfig().SubId;
			return ModelBase<ActivityModel>.Instance.GetActivityCacheData(activityId, 0, subId, 0, 0) == 0;
		}

		// Token: 0x06040F6A RID: 266090 RVA: 0x010AB14C File Offset: 0x010A934C
		public HashSet<int> CollectMonsterTypesByLevel(int levelId)
		{
			HashSet<int> hashSet = new HashSet<int>();
			IReadOnlyList<PinballWaveConfig> pinballWaveConfigListByLevel = ConfigBase<PinballConfig>.Instance.GetPinballWaveConfigListByLevel(levelId);
			if (pinballWaveConfigListByLevel == null)
			{
				return hashSet;
			}
			foreach (PinballWaveConfig pinballWaveConfig in pinballWaveConfigListByLevel)
			{
				int monsterSpawnGroupLength = pinballWaveConfig.MonsterSpawnGroupLength;
				for (int i = 0; i < monsterSpawnGroupLength; i++)
				{
					int id = pinballWaveConfig.MonsterSpawnGroup(i);
					PinballSpawnConfig? pinballSpawnConfigById = ConfigBase<PinballConfig>.Instance.GetPinballSpawnConfigById(id);
					if (pinballSpawnConfigById != null)
					{
						int monsterIdsLength = pinballSpawnConfigById.Value.MonsterIdsLength;
						for (int j = 0; j < monsterIdsLength; j++)
						{
							int id2 = pinballSpawnConfigById.Value.MonsterIds(j);
							hashSet.Add(ConfigBase<PinballConfig>.Instance.GetPinballMonsterConfigById(id2).Value.MonsterType);
						}
					}
				}
			}
			return hashSet;
		}

		// Token: 0x06040F6B RID: 266091 RVA: 0x010AB24C File Offset: 0x010A944C
		[NullableContext(2)]
		public BuffView CreateBuffView(int buffId, int buffCount)
		{
			PinballBuffConfig? pinballBuffConfigById = ConfigBase<PinballConfig>.Instance.GetPinballBuffConfigById(buffId);
			if (pinballBuffConfigById == null)
			{
				return null;
			}
			return new BuffView
			{
				BuffId = buffId,
				BuffType = (EPinballBuffType)pinballBuffConfigById.Value.BuffType,
				BuffCount = buffCount,
				Sort = pinballBuffConfigById.Value.Sort
			};
		}

		// Token: 0x06040F6C RID: 266092 RVA: 0x010AB2B0 File Offset: 0x010A94B0
		public List<IBuffView> GetBuffViewList(List<IBuffView> rawBuffViewList, int targetCount = -1)
		{
			int num = (targetCount >= 0) ? targetCount : rawBuffViewList.Count;
			List<IBuffView> list = new List<IBuffView>();
			List<IBuffView> list2 = new List<IBuffView>();
			foreach (IBuffView buffView in rawBuffViewList)
			{
				if (buffView.BuffType == EPinballBuffType.Special)
				{
					list2.Add(buffView);
				}
			}
			list2.Sort((IBuffView a, IBuffView b) => b.Sort - a.Sort);
			list.AddRange(list2);
			this.MergeBuffByType(rawBuffViewList, EPinballBuffType.Critical, list);
			this.MergeBuffByType(rawBuffViewList, EPinballBuffType.Attack, list);
			this.MergeBuffByType(rawBuffViewList, EPinballBuffType.Defense, list);
			if (list.Count > num)
			{
				return list.GetRange(0, num);
			}
			return list;
		}

		// Token: 0x06040F6D RID: 266093 RVA: 0x010AB380 File Offset: 0x010A9580
		private void MergeBuffByType(List<IBuffView> rawBuffViewList, EPinballBuffType buffType, List<IBuffView> buffViewList)
		{
			List<IBuffView> list = new List<IBuffView>();
			foreach (IBuffView buffView in rawBuffViewList)
			{
				if (buffView.BuffType == buffType)
				{
					list.Add(buffView);
				}
			}
			if (list.Count > 0)
			{
				int num = 0;
				foreach (IBuffView buffView2 in list)
				{
					num += buffView2.BuffCount;
				}
				BuffView item = new BuffView
				{
					BuffId = 0,
					BuffType = buffType,
					BuffCount = num,
					Sort = 0
				};
				buffViewList.Add(item);
			}
		}

		// Token: 0x06040F6E RID: 266094 RVA: 0x010AB454 File Offset: 0x010A9654
		public int GetPersonWeaponType(int roleId)
		{
			PinballRoleConfig? pinballRoleConfigById = ConfigBase<PinballConfig>.Instance.GetPinballRoleConfigById(roleId);
			if (pinballRoleConfigById == null)
			{
				return 0;
			}
			return pinballRoleConfigById.Value.PersonWeaponType;
		}

		// Token: 0x06040F6F RID: 266095 RVA: 0x010AB487 File Offset: 0x010A9687
		public bool CheckWeaponCanEquip(PinballWeaponData weaponData, int weaponType, int personWeaponType)
		{
			return weaponData.Type == weaponType && (!weaponData.GetIsPersonWeapon() || weaponData.PersonType == personWeaponType);
		}

		// Token: 0x06040F70 RID: 266096 RVA: 0x010AB4A8 File Offset: 0x010A96A8
		public bool GetWeaponRedDot(int activityId, int roleId)
		{
			PinballActivityData activityDataByActivityId = this.GetActivityDataByActivityId(activityId);
			return activityDataByActivityId != null && activityDataByActivityId.GetRoleWeaponRedDot(roleId);
		}

		// Token: 0x04024700 RID: 149248
		private int ActivityDataIdInternal = -1;

		// Token: 0x04024701 RID: 149249
		public int CurLevelConfigId;

		// Token: 0x04024702 RID: 149250
		public int CurLevelId;

		// Token: 0x04024703 RID: 149251
		[Nullable(2)]
		private UUIItem BattleCenterRootItem;

		// Token: 0x04024704 RID: 149252
		public List<int> SelectRoleHandleList = new List<int>();

		// Token: 0x04024705 RID: 149253
		public int CurrentFormationLevel;
	}
}
