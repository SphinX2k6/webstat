using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using Aki.Protocol;
using Aki.TDConfigMgr.Quest;
using CSharpScript.Game.Common;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.PayShop;

namespace CSharpScript.Game.Module.Activity.ActivityContent.Pinball
{
	// Token: 0x0200658B RID: 25995
	[NullableContext(1)]
	[Nullable(0)]
	public class PinballActivityData : ActivityBaseData
	{
		// Token: 0x06040EB3 RID: 265907 RVA: 0x010A7678 File Offset: 0x010A5878
		protected override void PhraseEx(ActivityData data)
		{
			ModelBase<PinballModel>.Instance.SetActivityId(base.Id);
			PinballActivityData pinballActivityData = data.PinballActivityData;
			if (pinballActivityData == null)
			{
				return;
			}
			foreach (Aki.Protocol.PinballChapterData data2 in pinballActivityData.Chapters)
			{
				this.UpdateChapterData(data2);
			}
			foreach (PinballLevelData data3 in pinballActivityData.Levels)
			{
				this.UpdateLevelData(data3);
			}
			this.CheckChapterUnlocked();
			PinballRoles roles = pinballActivityData.Roles;
			if (roles != null && roles.Roles.Count > 0)
			{
				foreach (Aki.Protocol.PinballRoleData data4 in roles.Roles)
				{
					this.UpdateRoleByServerData(data4);
				}
			}
			PinballWeapons weapons = pinballActivityData.Weapons;
			if (weapons != null && weapons.PinballWeaponList.Count > 0)
			{
				foreach (PinballWeapon data5 in weapons.PinballWeaponList)
				{
					this.UpdateWeaponData(data5);
				}
			}
			if (pinballActivityData.ConditionTasks.Count > 0)
			{
				List<ConditionTask> list = new List<ConditionTask>();
				foreach (ConditionTask item in pinballActivityData.ConditionTasks)
				{
					list.Add(item);
				}
				this.InitTaskData(list);
			}
			PinballActivity? config = ConfigPinballActivityByActivityId.GetConfig(base.Id, true);
			this.ShopId = ((config != null) ? config.GetValueOrDefault().ShopId : 5);
			if (pinballActivityData.GroupFormations.Count > 0)
			{
				List<GroupFormation> list2 = new List<GroupFormation>();
				foreach (GroupFormation item2 in pinballActivityData.GroupFormations)
				{
					list2.Add(item2);
				}
				this.InitLevelFormationData(list2);
			}
			this.UpdateRoleWeaponRedDot();
		}

		// Token: 0x06040EB4 RID: 265908 RVA: 0x010A78E0 File Offset: 0x010A5AE0
		private global::PinballRoleData AddRoleData(int configId)
		{
			global::PinballRoleData pinballRoleData = new global::PinballRoleData(configId);
			this.RoleDataMap[configId] = pinballRoleData;
			Singleton<EventSystem>.Instance.Emit<int>(EEventName.RefreshPinballRoleRedDot, configId);
			Singleton<EventSystem>.Instance.Emit<int>(EEventName.RefreshCommonActivityRedDot, base.Id);
			return pinballRoleData;
		}

		// Token: 0x06040EB5 RID: 265909 RVA: 0x010A792C File Offset: 0x010A5B2C
		public void UpdateRoleByServerData(Aki.Protocol.PinballRoleData data)
		{
			int configId = data.ConfigId;
			PinballRoleDataBase pinballRoleDataBase;
			this.RoleDataMap.TryGetValue(configId, out pinballRoleDataBase);
			if (pinballRoleDataBase == null)
			{
				pinballRoleDataBase = this.AddRoleData(configId);
			}
			pinballRoleDataBase.SetLevel(data.RoleLevel);
		}

		// Token: 0x06040EB6 RID: 265910 RVA: 0x010A7968 File Offset: 0x010A5B68
		[NullableContext(2)]
		public global::PinballRoleData GetRoleData(int configId)
		{
			PinballRoleDataBase pinballRoleDataBase;
			if (this.RoleDataMap.TryGetValue(configId, out pinballRoleDataBase))
			{
				return pinballRoleDataBase as global::PinballRoleData;
			}
			return null;
		}

		// Token: 0x06040EB7 RID: 265911 RVA: 0x010A7990 File Offset: 0x010A5B90
		public List<int> GetUnlockRoleList()
		{
			List<int> list = new List<int>();
			foreach (int item in this.RoleDataMap.Keys)
			{
				list.Add(item);
			}
			return list;
		}

		// Token: 0x06040EB8 RID: 265912 RVA: 0x010A79F0 File Offset: 0x010A5BF0
		public PinballWeaponData UpdateWeaponData(PinballWeapon data)
		{
			PinballWeaponData pinballWeaponData;
			this.WeaponDataMap.TryGetValue(data.IncrId, out pinballWeaponData);
			if (pinballWeaponData == null)
			{
				pinballWeaponData = new PinballWeaponData();
			}
			pinballWeaponData.Phrase(data);
			int roleId = pinballWeaponData.RoleId;
			if (roleId > 0)
			{
				global::PinballRoleData roleData = this.GetRoleData(roleId);
				if (roleData != null)
				{
					roleData.SetWeaponData(pinballWeaponData);
				}
			}
			this.WeaponDataMap[data.IncrId] = pinballWeaponData;
			return pinballWeaponData;
		}

		// Token: 0x06040EB9 RID: 265913 RVA: 0x010A7A54 File Offset: 0x010A5C54
		public void RemoveWeaponData(List<int> incIdList)
		{
			foreach (int key in incIdList)
			{
				this.WeaponDataMap.Remove(key);
			}
		}

		// Token: 0x06040EBA RID: 265914 RVA: 0x010A7AA8 File Offset: 0x010A5CA8
		[NullableContext(2)]
		public PinballWeaponData GetWeaponDataByIncId(int incId)
		{
			PinballWeaponData result;
			this.WeaponDataMap.TryGetValue(incId, out result);
			return result;
		}

		// Token: 0x06040EBB RID: 265915 RVA: 0x010A7AC8 File Offset: 0x010A5CC8
		public List<PinballWeaponData> GetWeaponDataAll()
		{
			List<PinballWeaponData> list = new List<PinballWeaponData>();
			foreach (PinballWeaponData item in this.WeaponDataMap.Values)
			{
				list.Add(item);
			}
			return list;
		}

		// Token: 0x06040EBC RID: 265916 RVA: 0x010A7B28 File Offset: 0x010A5D28
		public int GetWeaponCountByConfigId(int configId)
		{
			int num = 0;
			using (Dictionary<int, PinballWeaponData>.ValueCollection.Enumerator enumerator = this.WeaponDataMap.Values.GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					if (enumerator.Current.Id == configId)
					{
						num++;
					}
				}
			}
			return num;
		}

		// Token: 0x06040EBD RID: 265917 RVA: 0x010A7B88 File Offset: 0x010A5D88
		public void AddAllGmUnlockChapterId()
		{
			foreach (int chapterId in this.ChapterMap.Keys)
			{
				this.AddGmUnlockChapterId(chapterId);
			}
		}

		// Token: 0x06040EBE RID: 265918 RVA: 0x010A7BE0 File Offset: 0x010A5DE0
		public void AddGmUnlockChapterId(int chapterId)
		{
			if (this.GmUnlockChapterIdList.Contains(chapterId))
			{
				return;
			}
			this.GmUnlockChapterIdList.Add(chapterId);
		}

		// Token: 0x06040EBF RID: 265919 RVA: 0x010A7C00 File Offset: 0x010A5E00
		public void RemoveGmUnlockChapterId(int chapterId)
		{
			List<int> list = new List<int>();
			foreach (int num in this.GmUnlockChapterIdList)
			{
				if (num != chapterId)
				{
					list.Add(num);
				}
			}
			this.GmUnlockChapterIdList = list;
		}

		// Token: 0x06040EC0 RID: 265920 RVA: 0x010A7C64 File Offset: 0x010A5E64
		public void RemoveAllGmUnlockChapterId()
		{
			this.GmUnlockChapterIdList = new List<int>();
		}

		// Token: 0x06040EC1 RID: 265921 RVA: 0x010A7C71 File Offset: 0x010A5E71
		public bool IsGmUnlockChapter(int chapterId)
		{
			return this.GmUnlockChapterIdList.Contains(chapterId);
		}

		// Token: 0x06040EC2 RID: 265922 RVA: 0x010A7C80 File Offset: 0x010A5E80
		public void SetGmPassedChapter(int chapterId, bool isPassed)
		{
			global::PinballChapterData pinballChapterData;
			this.ChapterMap.TryGetValue(chapterId, out pinballChapterData);
			if (pinballChapterData == null)
			{
				return;
			}
			foreach (int levelId in pinballChapterData.LevelIds)
			{
				PinballLevelRecordData levelData = this.GetLevelData(levelId);
				if (levelData != null)
				{
					levelData.PassStatus = (isPassed ? EPinballLevelPassStatus.Finished : EPinballLevelPassStatus.Unfinished);
				}
			}
		}

		// Token: 0x06040EC3 RID: 265923 RVA: 0x010A7CD4 File Offset: 0x010A5ED4
		public void UpdateChapterData(Aki.Protocol.PinballChapterData data)
		{
			global::PinballChapterData pinballChapterData;
			this.ChapterMap.TryGetValue(data.ChapterId, out pinballChapterData);
			if (pinballChapterData == null)
			{
				pinballChapterData = new global::PinballChapterData();
				pinballChapterData.ChapterId = data.ChapterId;
			}
			long num = Singleton<MathUtils>.Instance.LongToNumber(data.UnLockTime);
			PinballChapterConfig? pinballChapterConfigById = ConfigBase<PinballConfig>.Instance.GetPinballChapterConfigById(data.ChapterId);
			int preChapterId = pinballChapterConfigById.Value.PreChapterId;
			int[] array = new int[pinballChapterConfigById.Value.LevelListLength];
			for (int i = 0; i < pinballChapterConfigById.Value.LevelListLength; i++)
			{
				array[i] = pinballChapterConfigById.Value.LevelList(i);
			}
			pinballChapterData.UnlockTime = (int)num;
			pinballChapterData.LevelIds = array;
			pinballChapterData.PreChapterId = preChapterId;
			this.ChapterMap[data.ChapterId] = pinballChapterData;
		}

		// Token: 0x06040EC4 RID: 265924 RVA: 0x010A7DB4 File Offset: 0x010A5FB4
		public List<global::PinballChapterData> GetMainChapterList()
		{
			List<global::PinballChapterData> list = new List<global::PinballChapterData>();
			foreach (global::PinballChapterData pinballChapterData in this.ChapterMap.Values)
			{
				int levelId = pinballChapterData.LevelIds[0];
				PinballLevelRecordData levelData = this.GetLevelData(levelId);
				if (levelData != null && levelData.LevelShowType == EPinballLevelShowType.Normal)
				{
					list.Add(pinballChapterData);
				}
			}
			return list;
		}

		// Token: 0x06040EC5 RID: 265925 RVA: 0x010A7E34 File Offset: 0x010A6034
		[NullableContext(2)]
		public global::PinballChapterData GetTowerChapterData()
		{
			foreach (global::PinballChapterData pinballChapterData in this.ChapterMap.Values)
			{
				int levelId = pinballChapterData.LevelIds[0];
				PinballLevelRecordData levelData = this.GetLevelData(levelId);
				if (levelData != null && levelData.LevelShowType == EPinballLevelShowType.Tower)
				{
					return pinballChapterData;
				}
			}
			return null;
		}

		// Token: 0x06040EC6 RID: 265926 RVA: 0x010A7EAC File Offset: 0x010A60AC
		[NullableContext(2)]
		public global::PinballChapterData GetDailyChapterData()
		{
			foreach (global::PinballChapterData pinballChapterData in this.ChapterMap.Values)
			{
				int[] levelIds = pinballChapterData.LevelIds;
				for (int i = 0; i < levelIds.Length; i++)
				{
					if (levelIds[i] == this.DailyConfigId)
					{
						return pinballChapterData;
					}
				}
			}
			return null;
		}

		// Token: 0x06040EC7 RID: 265927 RVA: 0x010A7F28 File Offset: 0x010A6128
		[NullableContext(2)]
		public global::PinballChapterData GetChapterData(int chapterId)
		{
			global::PinballChapterData result;
			this.ChapterMap.TryGetValue(chapterId, out result);
			return result;
		}

		// Token: 0x06040EC8 RID: 265928 RVA: 0x010A7F48 File Offset: 0x010A6148
		public int GetChapterIdByLevel(int levelId)
		{
			foreach (global::PinballChapterData pinballChapterData in this.ChapterMap.Values)
			{
				int[] levelIds = pinballChapterData.LevelIds;
				for (int i = 0; i < levelIds.Length; i++)
				{
					if (levelIds[i] == levelId)
					{
						return pinballChapterData.ChapterId;
					}
				}
			}
			return 0;
		}

		// Token: 0x06040EC9 RID: 265929 RVA: 0x010A7FC4 File Offset: 0x010A61C4
		public EPinballChapterLevelLockStatus GetChapterLockStatus(int chapterId)
		{
			global::PinballChapterData pinballChapterData;
			this.ChapterMap.TryGetValue(chapterId, out pinballChapterData);
			if (pinballChapterData == null)
			{
				return EPinballChapterLevelLockStatus.Lock;
			}
			PinballChapterConfig? pinballChapterConfigById = ConfigBase<PinballConfig>.Instance.GetPinballChapterConfigById(chapterId);
			if (pinballChapterConfigById == null)
			{
				return EPinballChapterLevelLockStatus.Lock;
			}
			double serverTime = Singleton<TimeUtil>.Instance.GetServerTime();
			int unlockTime = pinballChapterData.UnlockTime;
			if (serverTime < (double)unlockTime)
			{
				return EPinballChapterLevelLockStatus.Lock;
			}
			int preChapterId = pinballChapterConfigById.Value.PreChapterId;
			if (!this.IsChapterPassed(preChapterId))
			{
				return EPinballChapterLevelLockStatus.PreLock;
			}
			return EPinballChapterLevelLockStatus.Activated;
		}

		// Token: 0x06040ECA RID: 265930 RVA: 0x010A8038 File Offset: 0x010A6238
		private void CheckChapterUnlocked()
		{
			if (this.ChapterUnlockRecord.Count == 0)
			{
				foreach (int num in this.ChapterMap.Keys)
				{
					bool value = this.GetChapterLockStatus(num) == EPinballChapterLevelLockStatus.Activated;
					this.ChapterUnlockRecord[num] = value;
				}
			}
		}

		// Token: 0x06040ECB RID: 265931 RVA: 0x010A80B0 File Offset: 0x010A62B0
		public bool IsNewChapterUnlocked(int targetChapterId)
		{
			this.UpdateChapterNewUnlockState(targetChapterId);
			bool flag;
			this.ChapterNewUnlockRecord.TryGetValue(targetChapterId, out flag);
			if (flag)
			{
				this.ChapterNewUnlockRecord[targetChapterId] = false;
			}
			return flag;
		}

		// Token: 0x06040ECC RID: 265932 RVA: 0x010A80E4 File Offset: 0x010A62E4
		private void UpdateChapterNewUnlockState(int chapterId)
		{
			bool flag;
			this.ChapterUnlockRecord.TryGetValue(chapterId, out flag);
			bool flag2 = this.GetChapterLockStatus(chapterId) == EPinballChapterLevelLockStatus.Activated;
			if (flag2 && flag != flag2)
			{
				this.ChapterNewUnlockRecord[chapterId] = true;
				if (this.GetChapterRedDotState(chapterId) == EPinballChapterRedDotState.None)
				{
					this.SetChapterRedDotState(chapterId, EPinballChapterRedDotState.Unread);
				}
			}
			this.ChapterUnlockRecord[chapterId] = flag2;
		}

		// Token: 0x06040ECD RID: 265933 RVA: 0x010A813D File Offset: 0x010A633D
		private EPinballChapterRedDotState GetChapterRedDotState(int chapterId)
		{
			return (EPinballChapterRedDotState)ModelBase<ActivityModel>.Instance.GetActivityCacheData(base.Id, 0, 0, chapterId, 0);
		}

		// Token: 0x06040ECE RID: 265934 RVA: 0x010A8153 File Offset: 0x010A6353
		private void SetChapterRedDotState(int chapterId, EPinballChapterRedDotState state)
		{
			ModelBase<ActivityModel>.Instance.SaveActivityData(base.Id, 0, chapterId, 0, (int)state);
		}

		// Token: 0x06040ECF RID: 265935 RVA: 0x010A8169 File Offset: 0x010A6369
		public bool HasNewChapterRedDot(int chapterId)
		{
			this.UpdateChapterNewUnlockState(chapterId);
			return this.GetChapterRedDotState(chapterId) == EPinballChapterRedDotState.Unread;
		}

		// Token: 0x06040ED0 RID: 265936 RVA: 0x010A817C File Offset: 0x010A637C
		public bool HasAnyNewChapterRedDot()
		{
			global::PinballChapterData dailyChapterData = this.GetDailyChapterData();
			int num = (dailyChapterData != null) ? dailyChapterData.ChapterId : 0;
			foreach (int num2 in this.ChapterMap.Keys)
			{
				if (num2 != num && this.HasNewChapterRedDot(num2))
				{
					return true;
				}
			}
			return false;
		}

		// Token: 0x06040ED1 RID: 265937 RVA: 0x010A81F4 File Offset: 0x010A63F4
		public bool CheckToSetChapterRedDotAsRead(int chapterId)
		{
			if (!this.HasNewChapterRedDot(chapterId))
			{
				return false;
			}
			this.SetChapterRedDotAsRead(chapterId);
			return true;
		}

		// Token: 0x06040ED2 RID: 265938 RVA: 0x010A8209 File Offset: 0x010A6409
		public void SetChapterRedDotAsRead(int chapterId)
		{
			this.SetChapterRedDotState(chapterId, EPinballChapterRedDotState.Read);
			Singleton<EventSystem>.Instance.Emit<int>(EEventName.RefreshCommonActivityRedDot, base.Id);
		}

		// Token: 0x06040ED3 RID: 265939 RVA: 0x010A822C File Offset: 0x010A642C
		public bool IsChapterPassed(int chapterId)
		{
			if (chapterId == 0)
			{
				return true;
			}
			global::PinballChapterData pinballChapterData;
			this.ChapterMap.TryGetValue(chapterId, out pinballChapterData);
			if (pinballChapterData == null)
			{
				return false;
			}
			foreach (int levelId in pinballChapterData.LevelIds)
			{
				if (!this.IsLevelPassed(levelId))
				{
					return false;
				}
			}
			return true;
		}

		// Token: 0x06040ED4 RID: 265940 RVA: 0x010A8278 File Offset: 0x010A6478
		public void AddAllGmUnlockLevelId()
		{
			foreach (int levelId in this.LevelRecordMap.Keys)
			{
				this.AddGmUnlockLevelId(levelId);
			}
		}

		// Token: 0x06040ED5 RID: 265941 RVA: 0x010A82D0 File Offset: 0x010A64D0
		public void AddGmUnlockLevelId(int levelId)
		{
			if (this.GmUnlockLevelIdList.Contains(levelId))
			{
				return;
			}
			this.GmUnlockLevelIdList.Add(levelId);
		}

		// Token: 0x06040ED6 RID: 265942 RVA: 0x010A82ED File Offset: 0x010A64ED
		public void RemoveAllGmUnlockLevelId()
		{
			this.GmUnlockLevelIdList = new List<int>();
		}

		// Token: 0x06040ED7 RID: 265943 RVA: 0x010A82FA File Offset: 0x010A64FA
		public bool IsGmUnlockLevel(int levelId)
		{
			return this.GmUnlockLevelIdList.Contains(levelId);
		}

		// Token: 0x06040ED8 RID: 265944 RVA: 0x010A8308 File Offset: 0x010A6508
		public void UpdateLevelData(PinballLevelData data)
		{
			PinballLevelRecordData pinballLevelRecordData;
			this.LevelRecordMap.TryGetValue(data.ConfigId, out pinballLevelRecordData);
			if (pinballLevelRecordData == null)
			{
				pinballLevelRecordData = new PinballLevelRecordData();
				pinballLevelRecordData.LevelId = data.ConfigId;
				pinballLevelRecordData.ChapterId = this.GetChapterIdByLevel(data.ConfigId);
			}
			PinballLevelConfig? pinballLevelConfigById = ConfigBase<PinballConfig>.Instance.GetPinballLevelConfigById(data.ConfigId);
			pinballLevelRecordData.LevelShowType = (EPinballLevelShowType)pinballLevelConfigById.Value.Type;
			if (pinballLevelRecordData.LevelShowType == EPinballLevelShowType.Daily)
			{
				this.DailyConfigId = data.ConfigId;
			}
			CowLevel cowLevel = data.CowLevel;
			NormalLevel normalLevel = data.NormalLevel;
			TowerLevel towerLevel = data.TowerLevel;
			DailyLevel dailyLevel = data.DailyLevel;
			if (cowLevel != null)
			{
				int levelMaxScore = this.GetLevelMaxScore(data.ConfigId);
				if (cowLevel.LevelScore > 0)
				{
					bool flag = cowLevel.LevelScore >= levelMaxScore;
					pinballLevelRecordData.PassStatus = (flag ? EPinballLevelPassStatus.Perfect : EPinballLevelPassStatus.Finished);
				}
				else
				{
					pinballLevelRecordData.PassStatus = EPinballLevelPassStatus.Unfinished;
				}
				pinballLevelRecordData.LevelScore = cowLevel.LevelScore;
			}
			if (normalLevel != null)
			{
				int starByte = normalLevel.StarByte;
				int starCondLength = pinballLevelConfigById.Value.StarCondLength;
				int[] array = new int[starCondLength];
				for (int i = 0; i < starCondLength; i++)
				{
					array[i] = pinballLevelConfigById.Value.StarCond(i);
				}
				int[] passedConditionIdsByStarByte = this.GetPassedConditionIdsByStarByte(starByte, array);
				int num = passedConditionIdsByStarByte.Length;
				int num2 = starCondLength;
				if (num > 0)
				{
					bool flag2 = num >= num2;
					pinballLevelRecordData.PassStatus = (flag2 ? EPinballLevelPassStatus.Perfect : EPinballLevelPassStatus.Finished);
				}
				else
				{
					pinballLevelRecordData.PassStatus = EPinballLevelPassStatus.Unfinished;
				}
				pinballLevelRecordData.LevelStarConditionIds = passedConditionIdsByStarByte;
			}
			if (towerLevel != null)
			{
				int starByte2 = towerLevel.StarByte;
				int starCondLength2 = pinballLevelConfigById.Value.StarCondLength;
				int[] array2 = new int[starCondLength2];
				for (int j = 0; j < starCondLength2; j++)
				{
					array2[j] = pinballLevelConfigById.Value.StarCond(j);
				}
				int[] passedConditionIdsByStarByte2 = this.GetPassedConditionIdsByStarByte(starByte2, array2);
				int num3 = passedConditionIdsByStarByte2.Length;
				int num4 = starCondLength2;
				if (num3 > 0)
				{
					bool flag3 = num3 >= num4;
					pinballLevelRecordData.PassStatus = (flag3 ? EPinballLevelPassStatus.Perfect : EPinballLevelPassStatus.Finished);
				}
				else
				{
					pinballLevelRecordData.PassStatus = EPinballLevelPassStatus.Unfinished;
				}
				pinballLevelRecordData.LevelStarConditionIds = passedConditionIdsByStarByte2;
				pinballLevelRecordData.LevelPassedTime = towerLevel.CostTime;
			}
			if (dailyLevel != null)
			{
				this.RandomDailyLevelId = dailyLevel.RandomLevelId;
			}
			this.LevelRecordMap[data.ConfigId] = pinballLevelRecordData;
		}

		// Token: 0x06040ED9 RID: 265945 RVA: 0x010A855A File Offset: 0x010A675A
		public int GetDailyConfigId()
		{
			return this.DailyConfigId;
		}

		// Token: 0x06040EDA RID: 265946 RVA: 0x010A8564 File Offset: 0x010A6764
		public int GetDailyRandomLevelId()
		{
			if (this.RandomDailyLevelId == 0)
			{
				PinballActivity? pinballActivityConfigByActivityId = ConfigBase<PinballConfig>.Instance.GetPinballActivityConfigByActivityId(base.Id);
				if (pinballActivityConfigByActivityId != null)
				{
					this.RandomDailyLevelId = pinballActivityConfigByActivityId.Value.DefaultDailyRandomId;
				}
			}
			return this.RandomDailyLevelId;
		}

		// Token: 0x06040EDB RID: 265947 RVA: 0x010A85B0 File Offset: 0x010A67B0
		public int GetCurDailyRewardDropId()
		{
			int num = 0;
			foreach (PinballLevelRecordData pinballLevelRecordData in this.LevelRecordMap.Values)
			{
				bool flag = pinballLevelRecordData.LevelShowType != EPinballLevelShowType.Daily;
				bool flag2 = pinballLevelRecordData.PassStatus != EPinballLevelPassStatus.Unfinished;
				if (flag && flag2)
				{
					num++;
				}
			}
			IReadOnlyList<PinballDailyConfig> allPinballDailyConfigList = ConfigBase<PinballConfig>.Instance.GetAllPinballDailyConfigList();
			int dailyClearDropId = allPinballDailyConfigList[0].DailyClearDropId;
			foreach (PinballDailyConfig pinballDailyConfig in allPinballDailyConfigList)
			{
				if (num >= pinballDailyConfig.LevelCompleteNum)
				{
					dailyClearDropId = pinballDailyConfig.DailyClearDropId;
				}
			}
			return dailyClearDropId;
		}

		// Token: 0x06040EDC RID: 265948 RVA: 0x010A868C File Offset: 0x010A688C
		[NullableContext(2)]
		public PinballLevelRecordData GetLevelData(int levelId)
		{
			PinballLevelRecordData result;
			this.LevelRecordMap.TryGetValue(levelId, out result);
			return result;
		}

		// Token: 0x06040EDD RID: 265949 RVA: 0x010A86AC File Offset: 0x010A68AC
		public List<PinballLevelRecordData> GetLevelDataListInChapter(int levelId)
		{
			List<PinballLevelRecordData> list = new List<PinballLevelRecordData>();
			PinballLevelRecordData levelData = this.GetLevelData(levelId);
			if (levelData == null)
			{
				return new List<PinballLevelRecordData>();
			}
			global::PinballChapterData chapterData = this.GetChapterData(levelData.ChapterId);
			if (chapterData == null)
			{
				return new List<PinballLevelRecordData>();
			}
			foreach (int levelId2 in chapterData.LevelIds)
			{
				PinballLevelRecordData levelData2 = this.GetLevelData(levelId2);
				if (levelData2 != null)
				{
					list.Add(levelData2);
				}
			}
			return list;
		}

		// Token: 0x06040EDE RID: 265950 RVA: 0x010A871C File Offset: 0x010A691C
		public int GetLevelMaxStarNum(int levelId)
		{
			PinballLevelConfig? pinballLevelConfigById = ConfigBase<PinballConfig>.Instance.GetPinballLevelConfigById(levelId);
			if (pinballLevelConfigById == null)
			{
				return 0;
			}
			return pinballLevelConfigById.Value.StarCondLength;
		}

		// Token: 0x06040EDF RID: 265951 RVA: 0x010A874F File Offset: 0x010A694F
		private bool CheckStarConditionPassedByStarByte(int starByte, int conditionId)
		{
			return conditionId > 0 && (starByte & 1 << conditionId) > 0;
		}

		// Token: 0x06040EE0 RID: 265952 RVA: 0x010A8764 File Offset: 0x010A6964
		private int[] GetPassedConditionIdsByStarByte(int starByte, int[] conditionIds)
		{
			List<int> list = new List<int>();
			foreach (int num in conditionIds)
			{
				if (this.CheckStarConditionPassedByStarByte(starByte, num))
				{
					list.Add(num);
				}
			}
			return list.ToArray();
		}

		// Token: 0x06040EE1 RID: 265953 RVA: 0x010A87A4 File Offset: 0x010A69A4
		public int GetLevelMaxScore(int levelId)
		{
			PinballLevelConfig? pinballLevelConfigById = ConfigBase<PinballConfig>.Instance.GetPinballLevelConfigById(levelId);
			if (pinballLevelConfigById == null)
			{
				return 0;
			}
			int num = 0;
			for (int i = 0; i < pinballLevelConfigById.Value.ScoreLevelRewardLength; i++)
			{
				DicIntInt? dicIntInt = pinballLevelConfigById.Value.ScoreLevelReward(i);
				if (dicIntInt != null)
				{
					int key = dicIntInt.Value.Key;
					if (key > num)
					{
						num = key;
					}
				}
			}
			return num;
		}

		// Token: 0x06040EE2 RID: 265954 RVA: 0x010A881C File Offset: 0x010A6A1C
		public EPinballChapterLevelLockStatus GetLevelLockStatus(int levelId)
		{
			PinballLevelRecordData pinballLevelRecordData;
			this.LevelRecordMap.TryGetValue(levelId, out pinballLevelRecordData);
			if (pinballLevelRecordData == null)
			{
				return EPinballChapterLevelLockStatus.Lock;
			}
			PinballLevelConfig? pinballLevelConfigById = ConfigBase<PinballConfig>.Instance.GetPinballLevelConfigById(levelId);
			if (pinballLevelConfigById == null)
			{
				return EPinballChapterLevelLockStatus.Lock;
			}
			int preLevelIdsLength = pinballLevelConfigById.Value.PreLevelIdsLength;
			int[] array = new int[preLevelIdsLength];
			for (int i = 0; i < preLevelIdsLength; i++)
			{
				array[i] = pinballLevelConfigById.Value.PreLevelIds(i);
			}
			if (!this.IsLevelsPassed(array))
			{
				return EPinballChapterLevelLockStatus.PreLock;
			}
			return EPinballChapterLevelLockStatus.Activated;
		}

		// Token: 0x06040EE3 RID: 265955 RVA: 0x010A88A0 File Offset: 0x010A6AA0
		public string GetLevelPreConditionLockTexts(int levelId)
		{
			PinballLevelConfig? pinballLevelConfigById = ConfigBase<PinballConfig>.Instance.GetPinballLevelConfigById(levelId);
			if (pinballLevelConfigById == null)
			{
				return "";
			}
			List<string> list = new List<string>();
			int num = 0;
			int preLevelIdsLength = pinballLevelConfigById.Value.PreLevelIdsLength;
			for (int i = 0; i < preLevelIdsLength; i++)
			{
				int num2 = pinballLevelConfigById.Value.PreLevelIds(i);
				PinballLevelRecordData pinballLevelRecordData;
				this.LevelRecordMap.TryGetValue(num2, out pinballLevelRecordData);
				if (pinballLevelRecordData != null)
				{
					PinballLevelConfig? pinballLevelConfigById2 = ConfigBase<PinballConfig>.Instance.GetPinballLevelConfigById(num2);
					if (pinballLevelConfigById2 != null)
					{
						string localTextNew = ConfigMultiTextLang.GetLocalTextNew(pinballLevelConfigById2.Value.Name, null);
						if (pinballLevelRecordData.PassStatus == EPinballLevelPassStatus.Unfinished && localTextNew != null)
						{
							list.Add(localTextNew);
							num++;
						}
					}
				}
			}
			if (num == 0)
			{
				return "";
			}
			return StringUtils.Format(ConfigMultiTextLang.GetLocalTextNew((num == 1) ? "Pinball_Level_UnlockInfo" : "Pinball_Level_UnlockInfo_01", null), list.ToArray());
		}

		// Token: 0x06040EE4 RID: 265956 RVA: 0x010A898C File Offset: 0x010A6B8C
		public bool IsLevelsPassed(int[] levelIdList)
		{
			foreach (int levelId in levelIdList)
			{
				if (!this.IsLevelPassed(levelId))
				{
					return false;
				}
			}
			return true;
		}

		// Token: 0x06040EE5 RID: 265957 RVA: 0x010A89BC File Offset: 0x010A6BBC
		public bool IsLevelPassed(int levelId)
		{
			if (levelId == 0)
			{
				return true;
			}
			PinballLevelRecordData pinballLevelRecordData;
			this.LevelRecordMap.TryGetValue(levelId, out pinballLevelRecordData);
			return pinballLevelRecordData != null && pinballLevelRecordData.PassStatus != EPinballLevelPassStatus.Unfinished;
		}

		// Token: 0x06040EE6 RID: 265958 RVA: 0x010A89F0 File Offset: 0x010A6BF0
		public int GetTitleTipId()
		{
			PinballActivity? config = ConfigPinballActivityByActivityId.GetConfig(base.Id, true);
			if (config == null)
			{
				return 0;
			}
			return config.GetValueOrDefault().TitleTipId;
		}

		// Token: 0x06040EE7 RID: 265959 RVA: 0x010A8A24 File Offset: 0x010A6C24
		public bool IsRoleFunctionOpen()
		{
			PinballActivity? config = ConfigPinballActivityByActivityId.GetConfig(base.Id, true);
			int num = (config != null) ? config.GetValueOrDefault().RoleFuncId : 0;
			return num == 0 || ModelBase<FunctionModel>.Instance.IsOpen(num);
		}

		// Token: 0x06040EE8 RID: 265960 RVA: 0x010A8A6C File Offset: 0x010A6C6C
		public void InitTaskData(List<ConditionTask> taskInfos)
		{
			if (taskInfos == null)
			{
				return;
			}
			this.TaskDataMap.Clear();
			this.TimeLimitTaskDataMap.Clear();
			this.PermanentTaskDataMap.Clear();
			foreach (ConditionTask conditionTask in taskInfos)
			{
				PinballTaskData pinballTaskData = new PinballTaskData(conditionTask);
				PinballTask? pinballTaskConfigById = ConfigBase<PinballConfig>.Instance.GetPinballTaskConfigById(conditionTask.Id);
				if (pinballTaskConfigById != null)
				{
					string text = pinballTaskConfigById.Value.TaskName ?? "";
					pinballTaskData.QuestNameTextKey = text;
					pinballTaskData.QuestName = (ConfigMultiTextLang.GetLocalTextNew(text, null) ?? text);
					pinballTaskData.SetRewardList(pinballTaskConfigById.Value.DropId);
					pinballTaskData.TaskTab = (EPinballTaskTab)pinballTaskConfigById.Value.TaskTab;
					if (pinballTaskConfigById.Value.TaskType == 1)
					{
						this.TimeLimitTaskDataMap[conditionTask.Id] = pinballTaskData;
					}
					else
					{
						this.PermanentTaskDataMap[conditionTask.Id] = pinballTaskData;
					}
				}
				else
				{
					this.PermanentTaskDataMap[conditionTask.Id] = pinballTaskData;
				}
				this.TaskDataMap[conditionTask.Id] = pinballTaskData;
			}
		}

		// Token: 0x06040EE9 RID: 265961 RVA: 0x010A8BD0 File Offset: 0x010A6DD0
		public void UpdateTaskData(ConditionTask taskInfo)
		{
			PinballTaskData pinballTaskData;
			this.TaskDataMap.TryGetValue(taskInfo.Id, out pinballTaskData);
			if (pinballTaskData != null)
			{
				pinballTaskData.UpdateTaskData(taskInfo);
				return;
			}
			PinballTaskData pinballTaskData2 = new PinballTaskData(taskInfo);
			PinballTask? pinballTaskConfigById = ConfigBase<PinballConfig>.Instance.GetPinballTaskConfigById(taskInfo.Id);
			if (pinballTaskConfigById != null)
			{
				string text = pinballTaskConfigById.Value.TaskName ?? "";
				pinballTaskData2.QuestNameTextKey = text;
				pinballTaskData2.QuestName = (ConfigMultiTextLang.GetLocalTextNew(text, null) ?? text);
				pinballTaskData2.SetRewardList(pinballTaskConfigById.Value.DropId);
				pinballTaskData2.TaskTab = (EPinballTaskTab)pinballTaskConfigById.Value.TaskTab;
				if (pinballTaskConfigById.Value.TaskType == 1)
				{
					this.TimeLimitTaskDataMap[taskInfo.Id] = pinballTaskData2;
				}
				else
				{
					this.PermanentTaskDataMap[taskInfo.Id] = pinballTaskData2;
				}
			}
			else
			{
				this.PermanentTaskDataMap[taskInfo.Id] = pinballTaskData2;
			}
			this.TaskDataMap[taskInfo.Id] = pinballTaskData2;
		}

		// Token: 0x06040EEA RID: 265962 RVA: 0x010A8CE0 File Offset: 0x010A6EE0
		public List<PinballTaskData> GetTaskDataList()
		{
			List<PinballTaskData> list = new List<PinballTaskData>();
			foreach (PinballTaskData item in this.TaskDataMap.Values)
			{
				list.Add(item);
			}
			return list;
		}

		// Token: 0x06040EEB RID: 265963 RVA: 0x010A8D40 File Offset: 0x010A6F40
		[NullableContext(2)]
		public PinballTaskData GetTaskDataById(int taskId)
		{
			PinballTaskData result;
			this.TaskDataMap.TryGetValue(taskId, out result);
			return result;
		}

		// Token: 0x06040EEC RID: 265964 RVA: 0x010A8D60 File Offset: 0x010A6F60
		public List<PinballTaskData> GetTaskDataSortList()
		{
			List<PinballTaskData> list = new List<PinballTaskData>();
			foreach (PinballTaskData item in this.TaskDataMap.Values)
			{
				list.Add(item);
			}
			list.Sort((PinballTaskData a, PinballTaskData b) => this.TaskPriority(a) - this.TaskPriority(b));
			return list;
		}

		// Token: 0x06040EED RID: 265965 RVA: 0x010A8DD4 File Offset: 0x010A6FD4
		public List<PinballTaskData> GetTimeLimitTaskList()
		{
			List<PinballTaskData> list = new List<PinballTaskData>();
			foreach (PinballTaskData item in this.TimeLimitTaskDataMap.Values)
			{
				list.Add(item);
			}
			list.Sort((PinballTaskData a, PinballTaskData b) => this.TaskPriority(a) - this.TaskPriority(b));
			return list;
		}

		// Token: 0x06040EEE RID: 265966 RVA: 0x010A8E48 File Offset: 0x010A7048
		public List<PinballTaskData> GetPermanentTaskList()
		{
			List<PinballTaskData> list = new List<PinballTaskData>();
			foreach (PinballTaskData item in this.PermanentTaskDataMap.Values)
			{
				list.Add(item);
			}
			list.Sort((PinballTaskData a, PinballTaskData b) => this.TaskPriority(a) - this.TaskPriority(b));
			return list;
		}

		// Token: 0x06040EEF RID: 265967 RVA: 0x010A8EBC File Offset: 0x010A70BC
		private int TaskPriority(PinballTaskData task)
		{
			if (task.IsUnclaimed)
			{
				return 0;
			}
			if (task.IsDoing)
			{
				return 1;
			}
			return 2;
		}

		// Token: 0x06040EF0 RID: 265968 RVA: 0x010A8ED4 File Offset: 0x010A70D4
		public bool IsExistClaimableTask()
		{
			using (Dictionary<int, PinballTaskData>.ValueCollection.Enumerator enumerator = this.TaskDataMap.Values.GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					if (enumerator.Current.IsUnclaimed)
					{
						return true;
					}
				}
			}
			return false;
		}

		// Token: 0x06040EF1 RID: 265969 RVA: 0x010A8F34 File Offset: 0x010A7134
		public override bool GetExDataRedPointShowState()
		{
			return this.IsMainHubEntranceHasRedDot();
		}

		// Token: 0x06040EF2 RID: 265970 RVA: 0x010A8F3C File Offset: 0x010A713C
		public List<int> GetClaimableTaskIdList()
		{
			List<int> list = new List<int>();
			foreach (PinballTaskData pinballTaskData in this.TaskDataMap.Values)
			{
				if (pinballTaskData.IsUnclaimed)
				{
					list.Add(pinballTaskData.Data.Id);
				}
			}
			return list;
		}

		// Token: 0x06040EF3 RID: 265971 RVA: 0x010A8FB0 File Offset: 0x010A71B0
		public List<int> GetClaimablePermanentTaskIdList()
		{
			List<int> list = new List<int>();
			foreach (PinballTaskData pinballTaskData in this.PermanentTaskDataMap.Values)
			{
				if (pinballTaskData.IsUnclaimed && pinballTaskData.Data != null)
				{
					list.Add(pinballTaskData.Data.Id);
				}
			}
			return list;
		}

		// Token: 0x06040EF4 RID: 265972 RVA: 0x010A902C File Offset: 0x010A722C
		public List<int> GetClaimableTimeLimitTaskIdListWithoutBigReward()
		{
			List<int> list = new List<int>();
			foreach (PinballTaskData pinballTaskData in this.TimeLimitTaskDataMap.Values)
			{
				if (pinballTaskData.IsUnclaimed && pinballTaskData.Data != null && pinballTaskData.TaskTab != EPinballTaskTab.BigReward)
				{
					list.Add(pinballTaskData.Data.Id);
				}
			}
			return list;
		}

		// Token: 0x06040EF5 RID: 265973 RVA: 0x010A90B0 File Offset: 0x010A72B0
		[NullableContext(0)]
		[return: TupleElementNames(new string[]
		{
			"claimed",
			"total"
		})]
		public ValueTuple<int, int> GetPermanentTaskProgress()
		{
			List<PinballTaskData> permanentTaskList = this.GetPermanentTaskList();
			int count = permanentTaskList.Count;
			int num = 0;
			using (List<PinballTaskData>.Enumerator enumerator = permanentTaskList.GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					if (enumerator.Current.IsFinished)
					{
						num++;
					}
				}
			}
			return new ValueTuple<int, int>(num, count);
		}

		// Token: 0x06040EF6 RID: 265974 RVA: 0x010A9118 File Offset: 0x010A7318
		[NullableContext(0)]
		[return: TupleElementNames(new string[]
		{
			"claimed",
			"total"
		})]
		public ValueTuple<int, int> GetTimeLimitTaskProgress()
		{
			List<PinballTaskData> timeLimitTaskList = this.GetTimeLimitTaskList();
			int count = timeLimitTaskList.Count;
			int num = 0;
			using (List<PinballTaskData>.Enumerator enumerator = timeLimitTaskList.GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					if (enumerator.Current.IsFinished)
					{
						num++;
					}
				}
			}
			return new ValueTuple<int, int>(num, count);
		}

		// Token: 0x06040EF7 RID: 265975 RVA: 0x010A9180 File Offset: 0x010A7380
		public bool IsTimeLimitTaskHasRedDot()
		{
			if (!base.CheckIfInRewardTime())
			{
				return false;
			}
			using (Dictionary<int, PinballTaskData>.ValueCollection.Enumerator enumerator = this.TimeLimitTaskDataMap.Values.GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					if (enumerator.Current.IsUnclaimed)
					{
						return true;
					}
				}
			}
			return false;
		}

		// Token: 0x06040EF8 RID: 265976 RVA: 0x010A91E8 File Offset: 0x010A73E8
		public bool IsPermanentTaskHasRedDot()
		{
			using (Dictionary<int, PinballTaskData>.ValueCollection.Enumerator enumerator = this.PermanentTaskDataMap.Values.GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					if (enumerator.Current.IsUnclaimed)
					{
						return true;
					}
				}
			}
			return false;
		}

		// Token: 0x06040EF9 RID: 265977 RVA: 0x010A9248 File Offset: 0x010A7448
		public bool IsShopEntranceHasRedDot()
		{
			if (this.ShopId <= 0)
			{
				return false;
			}
			foreach (PayShopGoods payShopGoods in ModelBase<PayShopModel>.Instance.GetPayShopTabData((PayShopDefine.EPayShopTabType)this.ShopId, 1, false))
			{
				int goodsId = payShopGoods.GetGoodsId();
				if (goodsId > 0 && !ModelBase<NewFlagModel>.Instance.HasNewFlag(ELocalStoragePlayerKey.PayShopTabItemChecked, goodsId))
				{
					return true;
				}
			}
			return false;
		}

		// Token: 0x06040EFA RID: 265978 RVA: 0x010A92CC File Offset: 0x010A74CC
		public bool IsMainHubEntranceHasRedDot()
		{
			if (this.HasAnyNewChapterRedDot())
			{
				return true;
			}
			if (this.IsPreGuideQuestTaskRedDotActive())
			{
				return true;
			}
			if (this.IsPermanentTaskHasRedDot())
			{
				return true;
			}
			if (this.IsTimeLimitTaskHasRedDot())
			{
				return true;
			}
			if (ModelBase<FunctionModel>.Instance.IsOpen(10153) && this.IsShopEntranceHasRedDot())
			{
				return true;
			}
			if (!this.IsRoleFunctionOpen())
			{
				return false;
			}
			foreach (int roleId in this.GetUnlockRoleList())
			{
				if (ModelBase<PinballModel>.Instance.GetRoleRedDot(base.Id, roleId))
				{
					return true;
				}
			}
			return false;
		}

		// Token: 0x06040EFB RID: 265979 RVA: 0x010A9380 File Offset: 0x010A7580
		public bool IsPreGuideQuestTaskRedDotActive()
		{
			List<int> preGuideQuestIds = base.GetPreGuideQuestIds();
			if (preGuideQuestIds == null || preGuideQuestIds.Count == 0)
			{
				return false;
			}
			QuestNewModel instance = ModelBase<QuestNewModel>.Instance;
			foreach (int questId in preGuideQuestIds)
			{
				if (instance.CheckQuestRedDotDataState(questId).GetValueOrDefault())
				{
					return true;
				}
			}
			return false;
		}

		// Token: 0x06040EFC RID: 265980 RVA: 0x010A93FC File Offset: 0x010A75FC
		protected override bool GetExDataFinishShowState()
		{
			Dictionary<int, PinballTaskData> dictionary = base.CheckIfInRewardTime() ? this.TaskDataMap : this.PermanentTaskDataMap;
			if (dictionary.Count <= 0)
			{
				return false;
			}
			using (Dictionary<int, PinballTaskData>.ValueCollection.Enumerator enumerator = dictionary.Values.GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					if (!enumerator.Current.IsFinished)
					{
						return false;
					}
				}
			}
			return true;
		}

		// Token: 0x06040EFD RID: 265981 RVA: 0x010A9478 File Offset: 0x010A7678
		private void SortAndUpdateRank(List<global::PinballRankData> rankDataList)
		{
			rankDataList.Sort(delegate(global::PinballRankData a, global::PinballRankData b)
			{
				if (a.TowerLevel != b.TowerLevel)
				{
					return b.TowerLevel - a.TowerLevel;
				}
				return a.CostTime - b.CostTime;
			});
			for (int i = 0; i < rankDataList.Count; i++)
			{
				rankDataList[i].Ranking = i + 1;
			}
		}

		// Token: 0x06040EFE RID: 265982 RVA: 0x010A94CA File Offset: 0x010A76CA
		private void SortAndUpdateInternalRank()
		{
			this.SortAndUpdateRank(this.RankDataList);
		}

		// Token: 0x06040EFF RID: 265983 RVA: 0x010A94D8 File Offset: 0x010A76D8
		public void SetRankDataList(List<Aki.Protocol.PinballRankData> rankDataList)
		{
			this.RankDataList.Clear();
			if (rankDataList != null)
			{
				foreach (Aki.Protocol.PinballRankData pinballRankData in rankDataList)
				{
					if (global::PinballRankData.IsValidServerRankData(pinballRankData))
					{
						global::PinballRankData pinballRankData2 = new global::PinballRankData(false);
						pinballRankData2.SetDataByServerInfo(pinballRankData);
						this.RankDataList.Add(pinballRankData2);
					}
				}
				this.SortAndUpdateInternalRank();
			}
			this.ConfigRankList = null;
		}

		// Token: 0x06040F00 RID: 265984 RVA: 0x010A955C File Offset: 0x010A775C
		public List<global::PinballRankData> GetRankList()
		{
			List<global::PinballRankData> list = new List<global::PinballRankData>();
			foreach (global::PinballRankData item in this.RankDataList)
			{
				list.Add(item);
			}
			if (this.MyRankData != null && this.MyRankData.HasData)
			{
				list.Add(this.MyRankData);
			}
			int count = list.Count;
			foreach (global::PinballRankData pinballRankData in this.GetConfigRankList())
			{
				if (pinballRankData.HasData && count < pinballRankData.DisplayThreshold)
				{
					list.Add(pinballRankData);
				}
			}
			this.SortAndUpdateRank(list);
			return list;
		}

		// Token: 0x06040F01 RID: 265985 RVA: 0x010A963C File Offset: 0x010A783C
		private List<global::PinballRankData> GetConfigRankList()
		{
			if (this.ConfigRankList != null)
			{
				return this.ConfigRankList;
			}
			this.ConfigRankList = new List<global::PinballRankData>();
			IReadOnlyList<PinballRank> allPinballRankConfigList = ConfigBase<PinballConfig>.Instance.GetAllPinballRankConfigList();
			if (allPinballRankConfigList != null)
			{
				foreach (PinballRank pinballRank in allPinballRankConfigList)
				{
					int tower = pinballRank.Tower;
					global::PinballRankData pinballRankData = new global::PinballRankData(false);
					pinballRankData.SetDataByConfig(tower);
					if (pinballRankData.HasData)
					{
						this.ConfigRankList.Add(pinballRankData);
					}
				}
			}
			return this.ConfigRankList;
		}

		// Token: 0x06040F02 RID: 265986 RVA: 0x010A96DC File Offset: 0x010A78DC
		[NullableContext(2)]
		public void SetMyRankData(Aki.Protocol.PinballRankData rankData)
		{
			this.MyRankData = new global::PinballRankData(true);
			this.MyRankData.SetMyRankData(rankData);
		}

		// Token: 0x06040F03 RID: 265987 RVA: 0x010A96F6 File Offset: 0x010A78F6
		[NullableContext(2)]
		public global::PinballRankData GetMyRankData()
		{
			return this.MyRankData;
		}

		// Token: 0x06040F04 RID: 265988 RVA: 0x010A9700 File Offset: 0x010A7900
		[NullableContext(0)]
		[return: TupleElementNames(new string[]
		{
			"LevelId",
			"TowerNum",
			"CostTime"
		})]
		private ValueTuple<int, int, int>? GetBestPassedTowerLevelContext()
		{
			int num = 0;
			int num2 = 0;
			int item = 0;
			foreach (PinballLevelRecordData pinballLevelRecordData in this.LevelRecordMap.Values)
			{
				if (pinballLevelRecordData.LevelShowType == EPinballLevelShowType.Tower && pinballLevelRecordData.PassStatus == EPinballLevelPassStatus.Perfect)
				{
					PinballLevelConfig? pinballLevelConfigById = ConfigBase<PinballConfig>.Instance.GetPinballLevelConfigById(pinballLevelRecordData.LevelId);
					int num3 = (pinballLevelConfigById != null) ? pinballLevelConfigById.GetValueOrDefault().TowerNum : 0;
					if (num3 > num || (num3 == num && pinballLevelRecordData.LevelId > num2))
					{
						num = num3;
						num2 = pinballLevelRecordData.LevelId;
						item = pinballLevelRecordData.LevelPassedTime;
					}
				}
			}
			if (num <= 0 || num2 <= 0)
			{
				return null;
			}
			return new ValueTuple<int, int, int>?(new ValueTuple<int, int, int>(num2, num, item));
		}

		// Token: 0x06040F05 RID: 265989 RVA: 0x010A97E4 File Offset: 0x010A79E4
		[return: TupleElementNames(new string[]
		{
			"RoleId",
			"Level"
		})]
		[return: Nullable(new byte[]
		{
			1,
			0
		})]
		private List<ValueTuple<int, int>> BuildRankFormationFromRoleIds(int[] roleIds)
		{
			List<ValueTuple<int, int>> list = new List<ValueTuple<int, int>>();
			foreach (int num in roleIds)
			{
				if (num != 0)
				{
					global::PinballRoleData roleData = this.GetRoleData(num);
					list.Add(new ValueTuple<int, int>(num, (roleData != null) ? roleData.GetLevel() : 0));
				}
			}
			return list;
		}

		// Token: 0x06040F06 RID: 265990 RVA: 0x010A9834 File Offset: 0x010A7A34
		private int GetFormationGroupFromTowerLevelRecord(int towerLevel)
		{
			int num = 0;
			foreach (PinballLevelRecordData pinballLevelRecordData in this.LevelRecordMap.Values)
			{
				if (pinballLevelRecordData.LevelShowType == EPinballLevelShowType.Tower && pinballLevelRecordData.PassStatus == EPinballLevelPassStatus.Perfect)
				{
					PinballLevelConfig? pinballLevelConfigById = ConfigBase<PinballConfig>.Instance.GetPinballLevelConfigById(pinballLevelRecordData.LevelId);
					if (pinballLevelConfigById != null && pinballLevelConfigById.Value.TowerNum == towerLevel && (num == 0 || pinballLevelRecordData.LevelId > num))
					{
						num = pinballLevelRecordData.LevelId;
					}
				}
			}
			if (num <= 0)
			{
				return 0;
			}
			PinballLevelConfig? pinballLevelConfigById2 = ConfigBase<PinballConfig>.Instance.GetPinballLevelConfigById(num);
			if (pinballLevelConfigById2 == null)
			{
				return 0;
			}
			return pinballLevelConfigById2.GetValueOrDefault().FormationGroup;
		}

		// Token: 0x06040F07 RID: 265991 RVA: 0x010A9908 File Offset: 0x010A7B08
		private int[] ResolveFormationRoleIdsForRank(int formationGroup)
		{
			int[] array;
			this.LevelFormationMap.TryGetValue(formationGroup, out array);
			if (array != null && array.Length != 0)
			{
				return array;
			}
			foreach (int[] array2 in this.LevelFormationMap.Values)
			{
				if (array2 != null && array2.Length != 0)
				{
					return array2;
				}
			}
			return Array.Empty<int>();
		}

		// Token: 0x06040F08 RID: 265992 RVA: 0x010A9984 File Offset: 0x010A7B84
		public void TryFillMyRankFormationFromLocal(global::PinballRankData rankData)
		{
			if (!rankData.IsMyRank || rankData.Formation.Count > 0)
			{
				return;
			}
			int num = (rankData.TowerLevel > 0) ? this.GetFormationGroupFromTowerLevelRecord(rankData.TowerLevel) : 0;
			if (num <= 0)
			{
				ValueTuple<int, int, int>? bestPassedTowerLevelContext = this.GetBestPassedTowerLevelContext();
				if (bestPassedTowerLevelContext == null)
				{
					return;
				}
				PinballLevelConfig? pinballLevelConfigById = ConfigBase<PinballConfig>.Instance.GetPinballLevelConfigById(bestPassedTowerLevelContext.Value.Item1);
				num = ((pinballLevelConfigById != null) ? pinballLevelConfigById.GetValueOrDefault().FormationGroup : 0);
			}
			int[] roleIds = this.ResolveFormationRoleIdsForRank(num);
			rankData.Formation = this.BuildRankFormationFromRoleIds(roleIds);
		}

		// Token: 0x06040F09 RID: 265993 RVA: 0x010A9A20 File Offset: 0x010A7C20
		public void ApplyLocalTowerRankFallbackToMyRank(global::PinballRankData rankData)
		{
			if (rankData.HasData)
			{
				return;
			}
			ValueTuple<int, int, int>? bestPassedTowerLevelContext = this.GetBestPassedTowerLevelContext();
			if (bestPassedTowerLevelContext == null)
			{
				return;
			}
			rankData.Name = (ModelBase<FunctionModel>.Instance.GetPlayerName() ?? "");
			rankData.TowerLevel = bestPassedTowerLevelContext.Value.Item2;
			rankData.CostTime = bestPassedTowerLevelContext.Value.Item3;
			rankData.HasData = true;
		}

		// Token: 0x06040F0A RID: 265994 RVA: 0x010A9A8C File Offset: 0x010A7C8C
		private void InitLevelFormationData(List<GroupFormation> dataList)
		{
			this.LevelFormationMap.Clear();
			foreach (GroupFormation groupFormation in dataList)
			{
				int[] array = new int[groupFormation.RoleIds.Count];
				for (int i = 0; i < groupFormation.RoleIds.Count; i++)
				{
					array[i] = groupFormation.RoleIds[i];
				}
				this.LevelFormationMap[groupFormation.LevelGroup] = array;
			}
		}

		// Token: 0x06040F0B RID: 265995 RVA: 0x010A9B28 File Offset: 0x010A7D28
		public void UpDateLevelFormationData(GroupFormation data)
		{
			int[] array = new int[data.RoleIds.Count];
			for (int i = 0; i < data.RoleIds.Count; i++)
			{
				array[i] = data.RoleIds[i];
			}
			this.LevelFormationMap[data.LevelGroup] = array;
		}

		// Token: 0x06040F0C RID: 265996 RVA: 0x010A9B7D File Offset: 0x010A7D7D
		public string GetRecommendTaskTips()
		{
			return "Pinball_Activity_RecommendTaskTips";
		}

		// Token: 0x06040F0D RID: 265997 RVA: 0x010A9B84 File Offset: 0x010A7D84
		public int GetRecommendTaskId()
		{
			if (ConfigPinballActivityByActivityId.GetConfig(base.Id, true) == null)
			{
				return 0;
			}
			PinballActivity? pinballActivity;
			return pinballActivity.GetValueOrDefault().RecommendTaskId;
		}

		// Token: 0x06040F0E RID: 265998 RVA: 0x010A9BB8 File Offset: 0x010A7DB8
		public bool IsRecommendTaskFinished()
		{
			int recommendTaskId = this.GetRecommendTaskId();
			return recommendTaskId == 0 || ModelBase<QuestNewModel>.Instance.CheckQuestFinished(recommendTaskId);
		}

		// Token: 0x06040F0F RID: 265999 RVA: 0x010A9BDC File Offset: 0x010A7DDC
		public string GetRecommendTaskDisplayName()
		{
			int recommendTaskId = this.GetRecommendTaskId();
			if (recommendTaskId == 0)
			{
				return "";
			}
			string questName = ModelBase<QuestNewModel>.Instance.GetQuestName(recommendTaskId);
			if (questName != null)
			{
				return questName;
			}
			IQuest questConfig = ModelBase<QuestNewModel>.Instance.GetQuestConfig(recommendTaskId);
			string text = (questConfig != null) ? questConfig.TidName : null;
			if (text != null)
			{
				return Singleton<PublicUtil>.Instance.GetConfigTextByKey(text) ?? "";
			}
			return "";
		}

		// Token: 0x06040F10 RID: 266000 RVA: 0x010A9C40 File Offset: 0x010A7E40
		public void UpdateRoleWeaponRedDot()
		{
			this.RebuildWeaponMaxIndex();
			this.RoleWeaponMaxQualityMap.Clear();
			foreach (PinballRoleDataBase pinballRoleDataBase in this.RoleDataMap.Values)
			{
				int id = pinballRoleDataBase.GetId();
				this.RoleWeaponMaxQualityMap[id] = this.CalRoleWeaponMaxQuality(id);
				Singleton<EventSystem>.Instance.Emit<int>(EEventName.RefreshPinballWeaponRedDot, id);
			}
		}

		// Token: 0x06040F11 RID: 266001 RVA: 0x010A9CCC File Offset: 0x010A7ECC
		private void RebuildWeaponMaxIndex()
		{
			this.CommonTypeMaxQualityMap.Clear();
			this.PersonTypeMaxQualityMap.Clear();
			foreach (PinballWeaponData pinballWeaponData in this.WeaponDataMap.Values)
			{
				if (pinballWeaponData.RoleId == 0)
				{
					if (!pinballWeaponData.GetIsPersonWeapon())
					{
						int num;
						this.CommonTypeMaxQualityMap.TryGetValue(pinballWeaponData.Type, out num);
						if (pinballWeaponData.Quality > num)
						{
							this.CommonTypeMaxQualityMap[pinballWeaponData.Type] = pinballWeaponData.Quality;
						}
					}
					else
					{
						this.PersonTypeMaxQualityMap[pinballWeaponData.PersonType] = pinballWeaponData.Quality;
					}
				}
			}
		}

		// Token: 0x06040F12 RID: 266002 RVA: 0x010A9D90 File Offset: 0x010A7F90
		private int CalRoleWeaponMaxQuality(int roleId)
		{
			global::PinballRoleData roleData = this.GetRoleData(roleId);
			if (roleData == null || roleData.IsLocked())
			{
				return 0;
			}
			PinballRoleConfig config = roleData.GetConfig();
			PinballWeaponData weaponData = roleData.GetWeaponData();
			int num = (weaponData != null) ? weaponData.Quality : 0;
			int val;
			this.PersonTypeMaxQualityMap.TryGetValue(config.PersonWeaponType, out val);
			int val2;
			this.CommonTypeMaxQualityMap.TryGetValue(config.WeaponType, out val2);
			int num2 = Math.Max(val, val2);
			if (num2 <= num)
			{
				return 0;
			}
			return num2;
		}

		// Token: 0x06040F13 RID: 266003 RVA: 0x010A9E0C File Offset: 0x010A800C
		public int GetRoleWeaponMaxQuality(int roleId)
		{
			int result;
			this.RoleWeaponMaxQualityMap.TryGetValue(roleId, out result);
			return result;
		}

		// Token: 0x06040F14 RID: 266004 RVA: 0x010A9E29 File Offset: 0x010A8029
		public bool GetRoleWeaponRedDot(int roleId)
		{
			return this.GetRoleWeaponMaxQuality(roleId) > 0;
		}

		// Token: 0x040246EA RID: 149226
		private readonly Dictionary<int, PinballWeaponData> WeaponDataMap = new Dictionary<int, PinballWeaponData>();

		// Token: 0x040246EB RID: 149227
		protected Dictionary<int, PinballRoleDataBase> RoleDataMap = new Dictionary<int, PinballRoleDataBase>();

		// Token: 0x040246EC RID: 149228
		private readonly Dictionary<int, int> RoleWeaponMaxQualityMap = new Dictionary<int, int>();

		// Token: 0x040246ED RID: 149229
		private readonly Dictionary<int, int> CommonTypeMaxQualityMap = new Dictionary<int, int>();

		// Token: 0x040246EE RID: 149230
		private readonly Dictionary<int, int> PersonTypeMaxQualityMap = new Dictionary<int, int>();

		// Token: 0x040246EF RID: 149231
		private readonly Dictionary<int, global::PinballChapterData> ChapterMap = new Dictionary<int, global::PinballChapterData>();

		// Token: 0x040246F0 RID: 149232
		private readonly Dictionary<int, bool> ChapterUnlockRecord = new Dictionary<int, bool>();

		// Token: 0x040246F1 RID: 149233
		private readonly Dictionary<int, bool> ChapterNewUnlockRecord = new Dictionary<int, bool>();

		// Token: 0x040246F2 RID: 149234
		private List<int> GmUnlockChapterIdList = new List<int>();

		// Token: 0x040246F3 RID: 149235
		private readonly Dictionary<int, PinballLevelRecordData> LevelRecordMap = new Dictionary<int, PinballLevelRecordData>();

		// Token: 0x040246F4 RID: 149236
		private int DailyConfigId;

		// Token: 0x040246F5 RID: 149237
		private int RandomDailyLevelId;

		// Token: 0x040246F6 RID: 149238
		private List<int> GmUnlockLevelIdList = new List<int>();

		// Token: 0x040246F7 RID: 149239
		private readonly Dictionary<int, PinballTaskData> TaskDataMap = new Dictionary<int, PinballTaskData>();

		// Token: 0x040246F8 RID: 149240
		private readonly Dictionary<int, PinballTaskData> TimeLimitTaskDataMap = new Dictionary<int, PinballTaskData>();

		// Token: 0x040246F9 RID: 149241
		private readonly Dictionary<int, PinballTaskData> PermanentTaskDataMap = new Dictionary<int, PinballTaskData>();

		// Token: 0x040246FA RID: 149242
		public int ShopId;

		// Token: 0x040246FB RID: 149243
		private const int DEFAULT_SHOP_ID = 5;

		// Token: 0x040246FC RID: 149244
		private readonly List<global::PinballRankData> RankDataList = new List<global::PinballRankData>();

		// Token: 0x040246FD RID: 149245
		[Nullable(2)]
		private global::PinballRankData MyRankData;

		// Token: 0x040246FE RID: 149246
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private List<global::PinballRankData> ConfigRankList;

		// Token: 0x040246FF RID: 149247
		public Dictionary<int, int[]> LevelFormationMap = new Dictionary<int, int[]>();

		// Token: 0x0200C567 RID: 50535
		[NullableContext(0)]
		private enum EStorageKey
		{
			// Token: 0x0403CC17 RID: 248855
			ChapterRedDot
		}
	}
}
