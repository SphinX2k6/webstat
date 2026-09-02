using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using Aki.Config;
using Aki.Protocol;
using CSharpScript.Game.Common.Event;

namespace CSharpScript.Game.Module.Kurotato.Data
{
	// Token: 0x02005AE8 RID: 23272
	[NullableContext(1)]
	[Nullable(0)]
	public class KurotatoActivityData : ActivityBaseData
	{
		// Token: 0x170095A9 RID: 38313
		// (get) Token: 0x0603AD45 RID: 240965 RVA: 0x00EEB708 File Offset: 0x00EE9908
		public int KurotatoConfigId
		{
			get
			{
				return this.KurotatoConfigIdInternal;
			}
		}

		// Token: 0x0603AD46 RID: 240966 RVA: 0x00EEB710 File Offset: 0x00EE9910
		protected override void OnInit(ActivityData data)
		{
			if (data.KurotatoActivityData == null)
			{
				Singleton<Log>.Instance.Error(ELogModule.Kurotato, ELogAuthor.CXJ, "Kurotato活动数据不存在", default(ReadOnlySpan<ValueTuple<string, object>>));
				return;
			}
			KurotatoActivityConfig? activityConfig = ConfigBase<KurotatoConfig>.Instance.GetActivityConfig(base.Id);
			this.KurotatoConfigIdInternal = ((activityConfig != null) ? activityConfig.GetValueOrDefault().Id : 0);
			this.InitLevelData();
			this.InitRoleData();
			this.InitKurotatoItemData();
			this.InitKurotatoWeaponData();
		}

		// Token: 0x0603AD47 RID: 240967 RVA: 0x00EEB790 File Offset: 0x00EE9990
		protected override void PhraseEx(ActivityData data)
		{
			KurotatoActivityData kurotatoActivityData = data.KurotatoActivityData;
			if (kurotatoActivityData == null)
			{
				Singleton<Log>.Instance.Error(ELogModule.Kurotato, ELogAuthor.CXJ, "Kurotato活动数据不存在", default(ReadOnlySpan<ValueTuple<string, object>>));
				return;
			}
			this.UpdateLevelData(kurotatoActivityData.KurotatoLevelInfos, false);
			this.UpdateRoleData(kurotatoActivityData.KurotatoRoleInfos, false);
			this.UpdateKurotatoItemDataList(kurotatoActivityData.UnlockItems, false);
			this.UpdateKurotatoWeaponDataList(kurotatoActivityData.UnlockWeapons, false);
			this.InitKurotatoNormalRewardData(kurotatoActivityData.ResTasks);
			this.InitKurotatoLimitRewardData(kurotatoActivityData.LimitTasks);
			this.InitScoreRewardReceivedData(kurotatoActivityData.ScoreTasks);
		}

		// Token: 0x0603AD48 RID: 240968 RVA: 0x00EEB820 File Offset: 0x00EE9A20
		protected override bool GetExDataFinishShowState()
		{
			if (!base.IsUnLock())
			{
				return false;
			}
			ValueTuple<int, int> normalRewardProgress = this.GetNormalRewardProgress();
			int item = normalRewardProgress.Item1;
			int item2 = normalRewardProgress.Item2;
			ValueTuple<int, int> limitedTimeRewardProgress = this.GetLimitedTimeRewardProgress();
			int item3 = limitedTimeRewardProgress.Item1;
			int item4 = limitedTimeRewardProgress.Item2;
			return item >= item2 && item3 >= item4;
		}

		// Token: 0x0603AD49 RID: 240969 RVA: 0x00EEB86A File Offset: 0x00EE9A6A
		public override bool GetExDataRedPointShowState()
		{
			return this.IsActHaveRedDot();
		}

		// Token: 0x0603AD4A RID: 240970 RVA: 0x00EEB874 File Offset: 0x00EE9A74
		public bool IsActHaveRedDot()
		{
			return this.IsNormalRewardViewHasRedDot() || this.IsLimitTimeRewardViewHasRedDot() || this.IsRoleHasRedDot() || this.IsKurotatoItemHasRedDot() || this.IsKurotatoWeaponHasRedDot() || this.IsStageEntranceRedDot(EKurotatoLevelMode.Teach) || this.IsStageEntranceRedDot(EKurotatoLevelMode.Endless) || this.IsScoreRewardHasRedDot();
		}

		// Token: 0x0603AD4B RID: 240971 RVA: 0x00EEB8C4 File Offset: 0x00EE9AC4
		private void InitLevelData()
		{
			foreach (KurotatoLevel config in ConfigBase<KurotatoConfig>.Instance.GetLevelList())
			{
				KurotatoLevelData kurotatoLevelData = new KurotatoLevelData(config, base.Id);
				this.LevelMap[config.Id] = kurotatoLevelData;
				int levelGroup = config.LevelGroup;
				if (!this.LevelGroupMap.ContainsKey(levelGroup))
				{
					this.LevelGroupMap[levelGroup] = new List<KurotatoLevelData>();
				}
				this.LevelGroupMap[levelGroup].Add(kurotatoLevelData);
			}
			using (Dictionary<int, List<KurotatoLevelData>>.ValueCollection.Enumerator enumerator2 = this.LevelGroupMap.Values.GetEnumerator())
			{
				while (enumerator2.MoveNext())
				{
					enumerator2.Current.Sort((KurotatoLevelData a, KurotatoLevelData b) => a.SortId - b.SortId);
				}
			}
		}

		// Token: 0x0603AD4C RID: 240972 RVA: 0x00EEB9CC File Offset: 0x00EE9BCC
		[NullableContext(2)]
		public KurotatoLevelData GetKurotatoLevelData(int id)
		{
			KurotatoLevelData result;
			if (!this.LevelMap.TryGetValue(id, out result))
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.Kurotato;
				ELogAuthor author = ELogAuthor.CXJ;
				string message = "获取KurotatoLevelData失败";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("id", id);
				instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
				return null;
			}
			return result;
		}

		// Token: 0x0603AD4D RID: 240973 RVA: 0x00EEBA1C File Offset: 0x00EE9C1C
		public bool IsLevelUnLock(int id)
		{
			KurotatoLevelData kurotatoLevelData = this.GetKurotatoLevelData(id);
			return kurotatoLevelData != null && kurotatoLevelData.IsUnLock;
		}

		// Token: 0x0603AD4E RID: 240974 RVA: 0x00EEBA3C File Offset: 0x00EE9C3C
		public bool IsLevelFinished(int id)
		{
			KurotatoLevelData kurotatoLevelData = this.GetKurotatoLevelData(id);
			return kurotatoLevelData != null && kurotatoLevelData.IsFinished;
		}

		// Token: 0x0603AD4F RID: 240975 RVA: 0x00EEBA5C File Offset: 0x00EE9C5C
		public void UpdateLevelData(IList<KurotatoLevelInfo> levelInfoList, bool needEmit = false)
		{
			foreach (KurotatoLevelInfo kurotatoLevelInfo in levelInfoList)
			{
				KurotatoLevelData kurotatoLevelData = this.GetKurotatoLevelData(kurotatoLevelInfo.LevelId);
				if (kurotatoLevelData != null)
				{
					kurotatoLevelData.IsUnLock = kurotatoLevelInfo.IsUnlock;
					kurotatoLevelData.IsFinished = kurotatoLevelInfo.IsFinished;
					kurotatoLevelData.UnlockTime = Singleton<MathUtils>.Instance.LongToNumber(kurotatoLevelInfo.UnlockTime);
					if (kurotatoLevelInfo.EndlessLevelInfo != null && kurotatoLevelInfo.EndlessLevelInfo.PassRoleIds.Count > 0)
					{
						kurotatoLevelData.HistoryWave = kurotatoLevelInfo.EndlessLevelInfo.FinishWave;
						kurotatoLevelData.HistoryRoleId = kurotatoLevelInfo.EndlessLevelInfo.PassRoleIds[0];
						kurotatoLevelData.HistoryKillNum = kurotatoLevelInfo.EndlessLevelInfo.TotalKillCount;
					}
					KurotatoInstInfo instData = kurotatoLevelInfo.InstData;
					kurotatoLevelData.ArchivedData = ((instData != null && instData.RoleId != 0) ? instData : null);
				}
			}
			if (needEmit)
			{
				Singleton<EventSystem>.Instance.Emit<int>(EEventName.RefreshCommonActivityRedDot, base.Id);
			}
		}

		// Token: 0x0603AD50 RID: 240976 RVA: 0x00EEBB70 File Offset: 0x00EE9D70
		[NullableContext(0)]
		public ValueTuple<int, int> GetLevelProgress()
		{
			int num = 0;
			using (Dictionary<int, KurotatoLevelData>.ValueCollection.Enumerator enumerator = this.LevelMap.Values.GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					if (enumerator.Current.IsFinished)
					{
						num++;
					}
				}
			}
			return new ValueTuple<int, int>(num, this.LevelMap.Count);
		}

		// Token: 0x0603AD51 RID: 240977 RVA: 0x00EEBBE0 File Offset: 0x00EE9DE0
		[NullableContext(0)]
		public ValueTuple<int, int> GetLevelProgressByLevelGroup(int levelGroup)
		{
			int num = 0;
			List<KurotatoLevelData> list;
			if (!this.LevelGroupMap.TryGetValue(levelGroup, out list))
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.Kurotato;
				ELogAuthor author = ELogAuthor.CXJ;
				string message = "获取KurotatoLevelData列表失败,LevelGroup下不存在关卡";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("LevelGroupId", levelGroup);
				instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
				return new ValueTuple<int, int>(0, 0);
			}
			using (List<KurotatoLevelData>.Enumerator enumerator = list.GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					if (enumerator.Current.IsFinished)
					{
						num++;
					}
				}
			}
			return new ValueTuple<int, int>(num, list.Count);
		}

		// Token: 0x0603AD52 RID: 240978 RVA: 0x00EEBC88 File Offset: 0x00EE9E88
		public int GetLatestUnfinishedLevelId(int levelGroupId)
		{
			List<KurotatoLevelData> list;
			if (!this.LevelGroupMap.TryGetValue(levelGroupId, out list) || list.Count == 0)
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.Kurotato;
				ELogAuthor author = ELogAuthor.CXJ;
				string message = "获取KurotatoLevelData列表失败,LevelGroup下不存在关卡";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("LevelGroupId", levelGroupId);
				instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
				return 0;
			}
			foreach (KurotatoLevelData kurotatoLevelData in list)
			{
				if (!kurotatoLevelData.IsFinished)
				{
					return kurotatoLevelData.Id;
				}
			}
			return list[list.Count - 1].Id;
		}

		// Token: 0x0603AD53 RID: 240979 RVA: 0x00EEBD40 File Offset: 0x00EE9F40
		public bool IsStageEntranceUnLock(EKurotatoLevelMode mode)
		{
			if (mode == EKurotatoLevelMode.Teach)
			{
				return true;
			}
			KurotatoLevelGroup? levelGroupConfig = ConfigBase<KurotatoConfig>.Instance.GetLevelGroupConfig((int)mode);
			if (levelGroupConfig == null)
			{
				return false;
			}
			KurotatoLevelData kurotatoLevelData = this.GetKurotatoLevelData(levelGroupConfig.Value.LevelId);
			return kurotatoLevelData != null && kurotatoLevelData.IsUnLock;
		}

		// Token: 0x0603AD54 RID: 240980 RVA: 0x00EEBD90 File Offset: 0x00EE9F90
		public bool IsStageEntranceRedDot(EKurotatoLevelMode mode)
		{
			List<KurotatoLevelData> list;
			if (!this.LevelGroupMap.TryGetValue((int)mode, out list) || list.Count == 0)
			{
				return false;
			}
			using (List<KurotatoLevelData>.Enumerator enumerator = list.GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					if (enumerator.Current.HasRedDot)
					{
						return true;
					}
				}
			}
			return false;
		}

		// Token: 0x0603AD55 RID: 240981 RVA: 0x00EEBE00 File Offset: 0x00EEA000
		public int GetCurrentEndlessModeWave()
		{
			List<KurotatoLevelData> list;
			if (!this.LevelGroupMap.TryGetValue(3, out list) || list.Count == 0)
			{
				return 0;
			}
			return list[0].HistoryWave;
		}

		// Token: 0x0603AD56 RID: 240982 RVA: 0x00EEBE34 File Offset: 0x00EEA034
		public long GetEndlessLevelUnlockTime()
		{
			List<KurotatoLevelData> list;
			if (!this.LevelGroupMap.TryGetValue(3, out list) || list.Count == 0)
			{
				return 0L;
			}
			return list[0].UnlockTime;
		}

		// Token: 0x0603AD57 RID: 240983 RVA: 0x00EEBE68 File Offset: 0x00EEA068
		public string GetCurrentScoreLevelIcon(int maxWave)
		{
			foreach (KurotatoWaveLevel kurotatoWaveLevel in ConfigBase<KurotatoConfig>.Instance.GetWaveLevelConfigList())
			{
				if (kurotatoWaveLevel.WaveRange(0) <= maxWave && maxWave <= kurotatoWaveLevel.WaveRange(1))
				{
					return kurotatoWaveLevel.Icon;
				}
			}
			return "";
		}

		// Token: 0x0603AD58 RID: 240984 RVA: 0x00EEBEDC File Offset: 0x00EEA0DC
		public int GetNextLevelId(int currentLevelId)
		{
			KurotatoLevelData kurotatoLevelData = this.GetKurotatoLevelData(currentLevelId);
			if (kurotatoLevelData == null)
			{
				return 0;
			}
			List<KurotatoLevelData> list;
			if (!this.LevelGroupMap.TryGetValue(kurotatoLevelData.LevelGroup, out list))
			{
				return 0;
			}
			int num = list.FindIndex((KurotatoLevelData level) => level.Id == currentLevelId);
			if (num < 0 || num >= list.Count - 1)
			{
				return 0;
			}
			return list[num + 1].Id;
		}

		// Token: 0x0603AD59 RID: 240985 RVA: 0x00EEBF54 File Offset: 0x00EEA154
		private void InitRoleData()
		{
			EPlayerGender playerGender = ModelBase<PlayerInfoModel>.Instance.GetPlayerGender();
			foreach (KurotatoCharacter config in ConfigBase<KurotatoConfig>.Instance.GetCharacterListByActivityId(this.KurotatoConfigId))
			{
				KurotatoRoleData kurotatoRoleData = new KurotatoRoleData(config, base.Id);
				this.RoleMap[config.Id] = kurotatoRoleData;
				if (this.CheckRoleIsValid((EKurotatoRoleType)config.Type, playerGender))
				{
					this.RoleList.Add(kurotatoRoleData);
				}
			}
			this.RoleList.Sort((KurotatoRoleData a, KurotatoRoleData b) => a.SortId - b.SortId);
		}

		// Token: 0x0603AD5A RID: 240986 RVA: 0x00EEC018 File Offset: 0x00EEA218
		private bool CheckRoleIsValid(EKurotatoRoleType type, EPlayerGender gender)
		{
			return type == EKurotatoRoleType.Normal || (type == EKurotatoRoleType.MainRoleMale && gender == EPlayerGender.Male) || (type == EKurotatoRoleType.MainRoleFemale && gender == EPlayerGender.Female);
		}

		// Token: 0x0603AD5B RID: 240987 RVA: 0x00EEC030 File Offset: 0x00EEA230
		[NullableContext(2)]
		public KurotatoRoleData GetKurotatoRoleData(int id)
		{
			KurotatoRoleData result;
			if (!this.RoleMap.TryGetValue(id, out result))
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.Kurotato;
				ELogAuthor author = ELogAuthor.CXJ;
				string message = "获取KurotatoRoleData失败";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("id", id);
				instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
				return null;
			}
			return result;
		}

		// Token: 0x0603AD5C RID: 240988 RVA: 0x00EEC080 File Offset: 0x00EEA280
		public void UpdateRoleData(IList<KurotatoRoleInfo> roleInfoList, bool needEmit = false)
		{
			foreach (KurotatoRoleInfo kurotatoRoleInfo in roleInfoList)
			{
				KurotatoRoleData kurotatoRoleData = this.GetKurotatoRoleData(kurotatoRoleInfo.RoleId);
				if (kurotatoRoleData != null)
				{
					kurotatoRoleData.IsUnLock = kurotatoRoleInfo.IsUnlock;
					kurotatoRoleData.HistoryWave = kurotatoRoleInfo.MaxFinishWave;
					kurotatoRoleData.HistoryKillNum = kurotatoRoleInfo.KillCount;
					KurotatoInstInfo instData = kurotatoRoleInfo.InstData;
					kurotatoRoleData.ArchivedData = ((instData != null && instData.RoleId != 0) ? instData : null);
				}
			}
			if (needEmit)
			{
				Singleton<EventSystem>.Instance.Emit<int>(EEventName.RefreshCommonActivityRedDot, base.Id);
				Singleton<EventSystem>.Instance.Emit(EEventName.OnRefreshKurotatoRoleRedDot);
			}
		}

		// Token: 0x0603AD5D RID: 240989 RVA: 0x00EEC13C File Offset: 0x00EEA33C
		public List<KurotatoRoleData> GetKurotatoRoleList()
		{
			return this.RoleList;
		}

		// Token: 0x0603AD5E RID: 240990 RVA: 0x00EEC144 File Offset: 0x00EEA344
		public List<int> GetKurotatoRoleListInLevel(List<int> limitRoleList, List<int> recommendRoleList)
		{
			List<int> list = (from data in this.RoleList
			select data.Id).ToList<int>();
			list.Sort(delegate(int a, int b)
			{
				bool flag = limitRoleList.Contains(a);
				bool flag2 = limitRoleList.Contains(b);
				if (flag != flag2)
				{
					if (!flag)
					{
						return 1;
					}
					return -1;
				}
				else
				{
					bool flag3 = recommendRoleList.Contains(a);
					bool flag4 = recommendRoleList.Contains(b);
					if (flag3 != flag4)
					{
						if (!flag3)
						{
							return 1;
						}
						return -1;
					}
					else
					{
						KurotatoRoleData kurotatoRoleData = this.GetKurotatoRoleData(a);
						KurotatoRoleData kurotatoRoleData2 = this.GetKurotatoRoleData(b);
						if (kurotatoRoleData.HasRoleSelectRedDot != kurotatoRoleData2.HasRoleSelectRedDot)
						{
							if (!kurotatoRoleData.HasRoleSelectRedDot)
							{
								return 1;
							}
							return -1;
						}
						else
						{
							if (kurotatoRoleData.IsUnLock == kurotatoRoleData2.IsUnLock)
							{
								return kurotatoRoleData.SortId - kurotatoRoleData2.SortId;
							}
							if (!kurotatoRoleData.IsUnLock)
							{
								return 1;
							}
							return -1;
						}
					}
				}
			});
			return list;
		}

		// Token: 0x0603AD5F RID: 240991 RVA: 0x00EEC1B0 File Offset: 0x00EEA3B0
		public bool IsRoleHasRedDot()
		{
			using (Dictionary<int, KurotatoRoleData>.ValueCollection.Enumerator enumerator = this.RoleMap.Values.GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					if (enumerator.Current.HasHandBookRedDot)
					{
						return true;
					}
				}
			}
			return false;
		}

		// Token: 0x0603AD60 RID: 240992 RVA: 0x00EEC210 File Offset: 0x00EEA410
		public void ReadRoleRedDot()
		{
			if (!this.IsRoleHasRedDot())
			{
				return;
			}
			foreach (KurotatoRoleData kurotatoRoleData in this.RoleMap.Values)
			{
				if (kurotatoRoleData.HasHandBookRedDot)
				{
					kurotatoRoleData.ReadHandBookRedDot(false);
				}
			}
			Singleton<EventSystem>.Instance.Emit<int>(EEventName.RefreshCommonActivityRedDot, base.Id);
			Singleton<EventSystem>.Instance.Emit(EEventName.OnRefreshKurotatoRoleRedDot);
		}

		// Token: 0x0603AD61 RID: 240993 RVA: 0x00EEC2A0 File Offset: 0x00EEA4A0
		[NullableContext(0)]
		public ValueTuple<int, int> GetRoleUnlockNum()
		{
			int num = 0;
			using (List<KurotatoRoleData>.Enumerator enumerator = this.RoleList.GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					if (enumerator.Current.IsUnLock)
					{
						num++;
					}
				}
			}
			return new ValueTuple<int, int>(num, this.RoleList.Count);
		}

		// Token: 0x0603AD62 RID: 240994 RVA: 0x00EEC30C File Offset: 0x00EEA50C
		private void InitKurotatoItemData()
		{
			IReadOnlyList<KurotatoHandbook> kurotatoHandBookListByActivityIdAndType = ConfigBase<KurotatoConfig>.Instance.GetKurotatoHandBookListByActivityIdAndType(this.KurotatoConfigId, EKurotatoHandBookType.Item);
			if (kurotatoHandBookListByActivityIdAndType == null)
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.Kurotato;
				ELogAuthor author = ELogAuthor.CXJ;
				string message = "获取KurotatoHandbook道具列表失败";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("activityId", base.Id);
				instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
				return;
			}
			foreach (KurotatoHandbook kurotatoHandbook in kurotatoHandBookListByActivityIdAndType)
			{
				KurotatoItem? itemConfigByItemId = ConfigBase<KurotatoConfig>.Instance.GetItemConfigByItemId(kurotatoHandbook.Index);
				if (itemConfigByItemId == null)
				{
					Log instance2 = Singleton<Log>.Instance;
					ELogModule module2 = ELogModule.Kurotato;
					ELogAuthor author2 = ELogAuthor.CXJ;
					string message2 = "获取KurotatoItem配置失败";
					ValueTuple<string, object> valueTuple2 = new ValueTuple<string, object>("index", kurotatoHandbook.Index);
					instance2.Error(module2, author2, message2, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple2));
				}
				else
				{
					KurotatoItemData kurotatoItemData = new KurotatoItemData(itemConfigByItemId.Value, base.Id);
					this.ItemDataMap[itemConfigByItemId.Value.Id] = kurotatoItemData;
					this.ItemDataList.Add(kurotatoItemData);
				}
			}
		}

		// Token: 0x0603AD63 RID: 240995 RVA: 0x00EEC430 File Offset: 0x00EEA630
		public void UpdateKurotatoItemDataList(IList<int> itemIdList, bool needEmit = false)
		{
			foreach (int itemId in itemIdList)
			{
				this.UpdateKurotatoItemData(itemId);
			}
			this.SortItemDataList();
			this.ItemGridItemDataList.Clear();
			if (needEmit)
			{
				Singleton<EventSystem>.Instance.Emit<int>(EEventName.RefreshCommonActivityRedDot, base.Id);
				Singleton<EventSystem>.Instance.Emit(EEventName.OnRefreshKurotatoWeaponAndPropRedDot);
			}
		}

		// Token: 0x0603AD64 RID: 240996 RVA: 0x00EEC4B4 File Offset: 0x00EEA6B4
		public void UpdateKurotatoItemData(int itemId)
		{
			KurotatoItemData kurotatoItemData = this.GetKurotatoItemData(itemId);
			if (kurotatoItemData == null)
			{
				return;
			}
			kurotatoItemData.IsUnLock = true;
		}

		// Token: 0x0603AD65 RID: 240997 RVA: 0x00EEC4D4 File Offset: 0x00EEA6D4
		private void SortItemDataList()
		{
			this.ItemDataList.Sort(delegate(KurotatoItemData a, KurotatoItemData b)
			{
				if (a.IsUnLock != b.IsUnLock)
				{
					if (!a.IsUnLock)
					{
						return 1;
					}
					return -1;
				}
				else
				{
					if (a.Quality != b.Quality)
					{
						return b.Quality - a.Quality;
					}
					return a.Id - b.Id;
				}
			});
		}

		// Token: 0x0603AD66 RID: 240998 RVA: 0x00EEC500 File Offset: 0x00EEA700
		[NullableContext(2)]
		public KurotatoItemData GetKurotatoItemData(int id)
		{
			KurotatoItemData result;
			if (!this.ItemDataMap.TryGetValue(id, out result))
			{
				return null;
			}
			return result;
		}

		// Token: 0x0603AD67 RID: 240999 RVA: 0x00EEC520 File Offset: 0x00EEA720
		[NullableContext(0)]
		public ValueTuple<int, int> GetItemUnlockNum()
		{
			int num = 0;
			using (List<KurotatoItemData>.Enumerator enumerator = this.ItemDataList.GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					if (enumerator.Current.IsUnLock)
					{
						num++;
					}
				}
			}
			return new ValueTuple<int, int>(num, this.ItemDataList.Count);
		}

		// Token: 0x0603AD68 RID: 241000 RVA: 0x00EEC58C File Offset: 0x00EEA78C
		public bool IsKurotatoItemHasRedDot()
		{
			using (Dictionary<int, KurotatoItemData>.ValueCollection.Enumerator enumerator = this.ItemDataMap.Values.GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					if (enumerator.Current.HasRedDot)
					{
						return true;
					}
				}
			}
			return false;
		}

		// Token: 0x0603AD69 RID: 241001 RVA: 0x00EEC5EC File Offset: 0x00EEA7EC
		public void ReadKurotatoItemRedDot()
		{
			if (!this.IsKurotatoItemHasRedDot())
			{
				return;
			}
			foreach (KurotatoItemData kurotatoItemData in this.ItemDataMap.Values)
			{
				kurotatoItemData.ReadRedDot(false);
			}
			Singleton<EventSystem>.Instance.Emit<int>(EEventName.RefreshCommonActivityRedDot, base.Id);
			Singleton<EventSystem>.Instance.Emit(EEventName.OnRefreshKurotatoWeaponAndPropRedDot);
		}

		// Token: 0x0603AD6A RID: 241002 RVA: 0x00EEC674 File Offset: 0x00EEA874
		public List<IKurotatoMediumItemGridData> GetKurotatoItemList()
		{
			if (this.ItemGridItemDataList.Count > 0)
			{
				return this.ItemGridItemDataList;
			}
			foreach (KurotatoItemData kurotatoItemData in this.ItemDataList)
			{
				KurotatoMediumItemGridData item = new KurotatoMediumItemGridData
				{
					Id = kurotatoItemData.Id,
					Type = EKurotatoCardType.Item,
					IncId = 0,
					Count = 0
				};
				this.ItemGridItemDataList.Add(item);
			}
			return this.ItemGridItemDataList;
		}

		// Token: 0x0603AD6B RID: 241003 RVA: 0x00EEC710 File Offset: 0x00EEA910
		private void InitKurotatoWeaponData()
		{
			IReadOnlyList<KurotatoHandbook> kurotatoHandBookListByActivityIdAndType = ConfigBase<KurotatoConfig>.Instance.GetKurotatoHandBookListByActivityIdAndType(this.KurotatoConfigId, EKurotatoHandBookType.Weapon);
			if (kurotatoHandBookListByActivityIdAndType == null)
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.Kurotato;
				ELogAuthor author = ELogAuthor.CXJ;
				string message = "获取KurotatoHandbook武器列表失败";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("activityId", base.Id);
				instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
				return;
			}
			foreach (KurotatoHandbook kurotatoHandbook in kurotatoHandBookListByActivityIdAndType)
			{
				KurotatoWeapon? weaponConfigByWeaponId = ConfigBase<KurotatoConfig>.Instance.GetWeaponConfigByWeaponId(kurotatoHandbook.Index);
				if (weaponConfigByWeaponId == null)
				{
					Log instance2 = Singleton<Log>.Instance;
					ELogModule module2 = ELogModule.Kurotato;
					ELogAuthor author2 = ELogAuthor.CXJ;
					string message2 = "获取KurotatoWeapon配置失败";
					ValueTuple<string, object> valueTuple2 = new ValueTuple<string, object>("index", kurotatoHandbook.Index);
					instance2.Error(module2, author2, message2, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple2));
				}
				else
				{
					KurotatoWeaponData kurotatoWeaponData = new KurotatoWeaponData(weaponConfigByWeaponId.Value, base.Id);
					this.WeaponDataMap[weaponConfigByWeaponId.Value.Id] = kurotatoWeaponData;
					this.WeaponDataList.Add(kurotatoWeaponData);
				}
			}
		}

		// Token: 0x0603AD6C RID: 241004 RVA: 0x00EEC834 File Offset: 0x00EEAA34
		private void SortWeaponDataList()
		{
			this.WeaponDataList.Sort(delegate(KurotatoWeaponData a, KurotatoWeaponData b)
			{
				if (a.IsUnLock != b.IsUnLock)
				{
					if (!a.IsUnLock)
					{
						return 1;
					}
					return -1;
				}
				else
				{
					if (a.Quality != b.Quality)
					{
						return b.Quality - a.Quality;
					}
					return a.Id - b.Id;
				}
			});
		}

		// Token: 0x0603AD6D RID: 241005 RVA: 0x00EEC860 File Offset: 0x00EEAA60
		public void UpdateKurotatoWeaponDataList(IList<int> itemIdList, bool needEmit = false)
		{
			foreach (int itemId in itemIdList)
			{
				this.UpdateKurotatoWeaponData(itemId);
			}
			this.SortWeaponDataList();
			this.WeaponGridItemDataList.Clear();
			if (needEmit)
			{
				Singleton<EventSystem>.Instance.Emit<int>(EEventName.RefreshCommonActivityRedDot, base.Id);
				Singleton<EventSystem>.Instance.Emit(EEventName.OnRefreshKurotatoWeaponAndPropRedDot);
			}
		}

		// Token: 0x0603AD6E RID: 241006 RVA: 0x00EEC8E4 File Offset: 0x00EEAAE4
		public void UpdateKurotatoWeaponData(int itemId)
		{
			KurotatoWeaponData kurotatoWeaponData = this.GetKurotatoWeaponData(itemId);
			if (kurotatoWeaponData == null)
			{
				return;
			}
			kurotatoWeaponData.IsUnLock = true;
		}

		// Token: 0x0603AD6F RID: 241007 RVA: 0x00EEC904 File Offset: 0x00EEAB04
		[NullableContext(2)]
		public KurotatoWeaponData GetKurotatoWeaponData(int id)
		{
			KurotatoWeaponData result;
			if (!this.WeaponDataMap.TryGetValue(id, out result))
			{
				return null;
			}
			return result;
		}

		// Token: 0x0603AD70 RID: 241008 RVA: 0x00EEC924 File Offset: 0x00EEAB24
		[NullableContext(0)]
		public ValueTuple<int, int> GetWeaponUnlockNum()
		{
			int num = 0;
			using (List<KurotatoWeaponData>.Enumerator enumerator = this.WeaponDataList.GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					if (enumerator.Current.IsUnLock)
					{
						num++;
					}
				}
			}
			return new ValueTuple<int, int>(num, this.WeaponDataList.Count);
		}

		// Token: 0x0603AD71 RID: 241009 RVA: 0x00EEC990 File Offset: 0x00EEAB90
		public bool IsKurotatoWeaponHasRedDot()
		{
			using (Dictionary<int, KurotatoWeaponData>.ValueCollection.Enumerator enumerator = this.WeaponDataMap.Values.GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					if (enumerator.Current.HasRedDot)
					{
						return true;
					}
				}
			}
			return false;
		}

		// Token: 0x0603AD72 RID: 241010 RVA: 0x00EEC9F0 File Offset: 0x00EEABF0
		public void ReadKurotatoWeaponRedDot()
		{
			if (!this.IsKurotatoWeaponHasRedDot())
			{
				return;
			}
			foreach (KurotatoWeaponData kurotatoWeaponData in this.WeaponDataMap.Values)
			{
				kurotatoWeaponData.ReadRedDot(false);
			}
			Singleton<EventSystem>.Instance.Emit<int>(EEventName.RefreshCommonActivityRedDot, base.Id);
			Singleton<EventSystem>.Instance.Emit(EEventName.OnRefreshKurotatoWeaponAndPropRedDot);
		}

		// Token: 0x0603AD73 RID: 241011 RVA: 0x00EECA78 File Offset: 0x00EEAC78
		public List<IKurotatoMediumItemGridData> GetKurotatoWeaponList()
		{
			if (this.WeaponGridItemDataList.Count > 0)
			{
				return this.WeaponGridItemDataList;
			}
			foreach (KurotatoWeaponData kurotatoWeaponData in this.WeaponDataList)
			{
				KurotatoMediumItemGridData item = new KurotatoMediumItemGridData
				{
					Id = kurotatoWeaponData.Id,
					Type = EKurotatoCardType.Weapon,
					IncId = 0,
					Count = 0
				};
				this.WeaponGridItemDataList.Add(item);
			}
			return this.WeaponGridItemDataList;
		}

		// Token: 0x0603AD74 RID: 241012 RVA: 0x00EECB14 File Offset: 0x00EEAD14
		private void InitKurotatoNormalRewardData(IList<ConditionTask> taskList)
		{
			this.NormalRewardDataMap.Clear();
			foreach (ConditionTask conditionTask in taskList)
			{
				KurotatoNormalRewardItemData value = new KurotatoNormalRewardItemData(conditionTask.Id, conditionTask.Current, conditionTask.Target, (int)conditionTask.Status);
				this.NormalRewardDataMap[conditionTask.Id] = value;
			}
		}

		// Token: 0x0603AD75 RID: 241013 RVA: 0x00EECB90 File Offset: 0x00EEAD90
		private void InitKurotatoLimitRewardData(IList<ConditionTask> taskList)
		{
			this.LimitRewardDataMap.Clear();
			this.TabIdToLimitRewardDataListMap.Clear();
			foreach (ConditionTask conditionTask in taskList)
			{
				KurotatoLimitedTimeRewardItemData kurotatoLimitedTimeRewardItemData = new KurotatoLimitedTimeRewardItemData(conditionTask.Id, conditionTask.Current, conditionTask.Target, (int)conditionTask.Status);
				this.LimitRewardDataMap[conditionTask.Id] = kurotatoLimitedTimeRewardItemData;
				int tabId = kurotatoLimitedTimeRewardItemData.GetTabId();
				if (!this.TabIdToLimitRewardDataListMap.ContainsKey(tabId))
				{
					this.TabIdToLimitRewardDataListMap[tabId] = new List<KurotatoLimitedTimeRewardItemData>();
				}
				this.TabIdToLimitRewardDataListMap[tabId].Add(kurotatoLimitedTimeRewardItemData);
			}
		}

		// Token: 0x0603AD76 RID: 241014 RVA: 0x00EECC50 File Offset: 0x00EEAE50
		public void UpdateNormalRewardData(IList<ConditionTask> taskList)
		{
			foreach (ConditionTask conditionTask in taskList)
			{
				KurotatoNormalRewardItemData kurotatoNormalRewardItemData;
				if (this.NormalRewardDataMap.TryGetValue(conditionTask.Id, out kurotatoNormalRewardItemData))
				{
					kurotatoNormalRewardItemData.Refresh(conditionTask);
				}
			}
			Singleton<EventSystem>.Instance.Emit(EEventName.OnRefreshKurotatoNormalRewardData);
			Singleton<EventSystem>.Instance.Emit<int>(EEventName.RefreshCommonActivityRedDot, base.Id);
		}

		// Token: 0x0603AD77 RID: 241015 RVA: 0x00EECCD4 File Offset: 0x00EEAED4
		public void UpdateLimitTimeRewardData(IList<ConditionTask> taskList)
		{
			foreach (ConditionTask conditionTask in taskList)
			{
				KurotatoLimitedTimeRewardItemData kurotatoLimitedTimeRewardItemData;
				if (this.LimitRewardDataMap.TryGetValue(conditionTask.Id, out kurotatoLimitedTimeRewardItemData))
				{
					kurotatoLimitedTimeRewardItemData.Refresh(conditionTask);
				}
			}
			Singleton<EventSystem>.Instance.Emit(EEventName.OnRefreshKurotatoLimitRewardData);
			Singleton<EventSystem>.Instance.Emit<int>(EEventName.RefreshCommonActivityRedDot, base.Id);
		}

		// Token: 0x0603AD78 RID: 241016 RVA: 0x00EECD58 File Offset: 0x00EEAF58
		public void SetNormalRewardReceived(List<int> idList)
		{
			foreach (int key in idList)
			{
				KurotatoNormalRewardItemData kurotatoNormalRewardItemData;
				if (this.NormalRewardDataMap.TryGetValue(key, out kurotatoNormalRewardItemData))
				{
					kurotatoNormalRewardItemData.Status = EKurotatoRewardStatus.Taken;
				}
			}
			Singleton<EventSystem>.Instance.Emit(EEventName.OnRefreshKurotatoNormalRewardData);
			Singleton<EventSystem>.Instance.Emit<int>(EEventName.RefreshCommonActivityRedDot, base.Id);
		}

		// Token: 0x0603AD79 RID: 241017 RVA: 0x00EECDDC File Offset: 0x00EEAFDC
		public void SetLimitTimeRewardReceived(List<int> idList)
		{
			foreach (int key in idList)
			{
				KurotatoLimitedTimeRewardItemData kurotatoLimitedTimeRewardItemData;
				if (this.LimitRewardDataMap.TryGetValue(key, out kurotatoLimitedTimeRewardItemData))
				{
					kurotatoLimitedTimeRewardItemData.Status = EKurotatoRewardStatus.Taken;
				}
			}
			Singleton<EventSystem>.Instance.Emit(EEventName.OnRefreshKurotatoLimitRewardData);
			Singleton<EventSystem>.Instance.Emit<int>(EEventName.RefreshCommonActivityRedDot, base.Id);
		}

		// Token: 0x0603AD7A RID: 241018 RVA: 0x00EECE60 File Offset: 0x00EEB060
		public bool IsNormalRewardViewHasRedDot()
		{
			using (Dictionary<int, KurotatoNormalRewardItemData>.ValueCollection.Enumerator enumerator = this.NormalRewardDataMap.Values.GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					if (enumerator.Current.Status == EKurotatoRewardStatus.CanReceive)
					{
						return true;
					}
				}
			}
			return false;
		}

		// Token: 0x0603AD7B RID: 241019 RVA: 0x00EECEC0 File Offset: 0x00EEB0C0
		[NullableContext(2)]
		public KurotatoNormalRewardItemData GetNormalRewardData(int id)
		{
			KurotatoNormalRewardItemData result;
			if (!this.NormalRewardDataMap.TryGetValue(id, out result))
			{
				return null;
			}
			return result;
		}

		// Token: 0x0603AD7C RID: 241020 RVA: 0x00EECEE0 File Offset: 0x00EEB0E0
		public List<KurotatoNormalRewardItemData> GetNormalRewardDataList()
		{
			return new List<KurotatoNormalRewardItemData>(this.NormalRewardDataMap.Values);
		}

		// Token: 0x0603AD7D RID: 241021 RVA: 0x00EECEF4 File Offset: 0x00EEB0F4
		public List<int> GetNormalRewardCanClaimableIdList()
		{
			List<int> list = new List<int>();
			foreach (KurotatoNormalRewardItemData kurotatoNormalRewardItemData in this.NormalRewardDataMap.Values)
			{
				if (kurotatoNormalRewardItemData.Status == EKurotatoRewardStatus.CanReceive)
				{
					list.Add(kurotatoNormalRewardItemData.Id);
				}
			}
			return list;
		}

		// Token: 0x0603AD7E RID: 241022 RVA: 0x00EECF64 File Offset: 0x00EEB164
		[NullableContext(0)]
		public ValueTuple<int, int> GetNormalRewardProgress()
		{
			int num = 0;
			int count = this.NormalRewardDataMap.Count;
			using (Dictionary<int, KurotatoNormalRewardItemData>.ValueCollection.Enumerator enumerator = this.NormalRewardDataMap.Values.GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					if (enumerator.Current.Status == EKurotatoRewardStatus.Taken)
					{
						num++;
					}
				}
			}
			return new ValueTuple<int, int>(num, count);
		}

		// Token: 0x0603AD7F RID: 241023 RVA: 0x00EECFD8 File Offset: 0x00EEB1D8
		public int GetCurrentMilestone()
		{
			if (this.MilestoneItemId == 0)
			{
				KurotatoActivityConfig? activityConfig = ModelBase<KurotatoModel>.Instance.GetActivityConfig();
				this.MilestoneItemId = ((activityConfig != null) ? activityConfig.GetValueOrDefault().ScoreItem : 0);
			}
			return ModelBase<InventoryModel>.Instance.GetItemCountByConfigId(this.MilestoneItemId, 0);
		}

		// Token: 0x0603AD80 RID: 241024 RVA: 0x00EED02C File Offset: 0x00EEB22C
		private void InitScoreRewardReceivedData(IList<int> scoreTaskList)
		{
			this.ScoreRewardReceivedIdSet.Clear();
			if (scoreTaskList == null)
			{
				return;
			}
			foreach (int item in scoreTaskList)
			{
				this.ScoreRewardReceivedIdSet.Add(item);
			}
		}

		// Token: 0x0603AD81 RID: 241025 RVA: 0x00EED08C File Offset: 0x00EEB28C
		public void SetScoreRewardReceived(List<int> idList)
		{
			foreach (int item in idList)
			{
				this.ScoreRewardReceivedIdSet.Add(item);
			}
			Singleton<EventSystem>.Instance.Emit(EEventName.OnRefreshKurotatoLimitRewardData);
			Singleton<EventSystem>.Instance.Emit<int>(EEventName.RefreshCommonActivityRedDot, base.Id);
		}

		// Token: 0x0603AD82 RID: 241026 RVA: 0x00EED108 File Offset: 0x00EEB308
		public bool IsScoreRewardCanReceived(int id)
		{
			KurotatoScoreAward? kurotatoScoreAwardConfigById = ConfigBase<KurotatoConfig>.Instance.GetKurotatoScoreAwardConfigById(id);
			return kurotatoScoreAwardConfigById != null && this.GetCurrentMilestone() >= kurotatoScoreAwardConfigById.Value.Score && !this.IsScoreRewardReceived(id);
		}

		// Token: 0x0603AD83 RID: 241027 RVA: 0x00EED14F File Offset: 0x00EEB34F
		public bool IsScoreRewardReceived(int id)
		{
			return this.ScoreRewardReceivedIdSet.Contains(id);
		}

		// Token: 0x0603AD84 RID: 241028 RVA: 0x00EED160 File Offset: 0x00EEB360
		public int GetLastNotTakenScoreRewardIndex()
		{
			IReadOnlyList<KurotatoScoreAward> allKurotatoScoreAwardConfig = ConfigBase<KurotatoConfig>.Instance.GetAllKurotatoScoreAwardConfig();
			for (int i = allKurotatoScoreAwardConfig.Count - 1; i >= 0; i--)
			{
				if (this.IsScoreRewardCanReceived(allKurotatoScoreAwardConfig[i].Id))
				{
					return i + 1;
				}
			}
			return 0;
		}

		// Token: 0x0603AD85 RID: 241029 RVA: 0x00EED1A8 File Offset: 0x00EEB3A8
		public List<int> GetCanClaimedScoreRewardList()
		{
			List<int> list = new List<int>();
			foreach (KurotatoScoreAward kurotatoScoreAward in ConfigBase<KurotatoConfig>.Instance.GetAllKurotatoScoreAwardConfig())
			{
				if (this.IsScoreRewardCanReceived(kurotatoScoreAward.Id))
				{
					list.Add(kurotatoScoreAward.Id);
				}
			}
			return list;
		}

		// Token: 0x0603AD86 RID: 241030 RVA: 0x00EED218 File Offset: 0x00EEB418
		public bool IsScoreRewardHasRedDot()
		{
			foreach (KurotatoScoreAward kurotatoScoreAward in ConfigBase<KurotatoConfig>.Instance.GetAllKurotatoScoreAwardConfig())
			{
				if (this.IsScoreRewardCanReceived(kurotatoScoreAward.Id))
				{
					return true;
				}
			}
			return false;
		}

		// Token: 0x0603AD87 RID: 241031 RVA: 0x00EED278 File Offset: 0x00EEB478
		public bool IsLimitTimeRewardViewHasRedDot()
		{
			using (Dictionary<int, KurotatoLimitedTimeRewardItemData>.ValueCollection.Enumerator enumerator = this.LimitRewardDataMap.Values.GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					if (enumerator.Current.Status == EKurotatoRewardStatus.CanReceive)
					{
						return true;
					}
				}
			}
			return false;
		}

		// Token: 0x0603AD88 RID: 241032 RVA: 0x00EED2D8 File Offset: 0x00EEB4D8
		public List<KurotatoLimitedTimeRewardItemData> GetLimitedTimeTaskListByTabId(int tabId)
		{
			List<KurotatoLimitedTimeRewardItemData> collection;
			if (!this.TabIdToLimitRewardDataListMap.TryGetValue(tabId, out collection))
			{
				return new List<KurotatoLimitedTimeRewardItemData>();
			}
			return new List<KurotatoLimitedTimeRewardItemData>(collection);
		}

		// Token: 0x0603AD89 RID: 241033 RVA: 0x00EED304 File Offset: 0x00EEB504
		public List<int> GetLimitedTimeTaskCanClaimableIdListByTabId(int tabId)
		{
			List<KurotatoLimitedTimeRewardItemData> list;
			if (!this.TabIdToLimitRewardDataListMap.TryGetValue(tabId, out list))
			{
				return new List<int>();
			}
			List<int> list2 = new List<int>();
			foreach (KurotatoLimitedTimeRewardItemData kurotatoLimitedTimeRewardItemData in list)
			{
				if (kurotatoLimitedTimeRewardItemData.Status == EKurotatoRewardStatus.CanReceive)
				{
					list2.Add(kurotatoLimitedTimeRewardItemData.Id);
				}
			}
			return list2;
		}

		// Token: 0x0603AD8A RID: 241034 RVA: 0x00EED380 File Offset: 0x00EEB580
		public bool IsLimitedTimeTaskTabHasAnyClaimable(int tabId)
		{
			List<KurotatoLimitedTimeRewardItemData> list;
			if (!this.TabIdToLimitRewardDataListMap.TryGetValue(tabId, out list) || list.Count <= 0)
			{
				return false;
			}
			using (List<KurotatoLimitedTimeRewardItemData>.Enumerator enumerator = list.GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					if (enumerator.Current.Status == EKurotatoRewardStatus.CanReceive)
					{
						return true;
					}
				}
			}
			return false;
		}

		// Token: 0x0603AD8B RID: 241035 RVA: 0x00EED3F0 File Offset: 0x00EEB5F0
		[NullableContext(2)]
		public KurotatoLimitedTimeRewardItemData GetLimitedTimeTaskRewardTaskData(int id)
		{
			KurotatoLimitedTimeRewardItemData result;
			if (!this.LimitRewardDataMap.TryGetValue(id, out result))
			{
				return null;
			}
			return result;
		}

		// Token: 0x0603AD8C RID: 241036 RVA: 0x00EED410 File Offset: 0x00EEB610
		[NullableContext(0)]
		public ValueTuple<int, int> GetLimitedTimeRewardProgress()
		{
			int num = 0;
			int count = this.LimitRewardDataMap.Count;
			using (Dictionary<int, KurotatoLimitedTimeRewardItemData>.ValueCollection.Enumerator enumerator = this.LimitRewardDataMap.Values.GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					if (enumerator.Current.Status == EKurotatoRewardStatus.Taken)
					{
						num++;
					}
				}
			}
			return new ValueTuple<int, int>(num, count);
		}

		// Token: 0x0603AD8D RID: 241037 RVA: 0x00EED484 File Offset: 0x00EEB684
		[NullableContext(0)]
		public ValueTuple<int, int> GetLimitedTimeTabRewardProgress(int tabId)
		{
			List<KurotatoLimitedTimeRewardItemData> list;
			if (!this.TabIdToLimitRewardDataListMap.TryGetValue(tabId, out list))
			{
				return new ValueTuple<int, int>(0, 0);
			}
			int num = 0;
			int count = list.Count;
			using (List<KurotatoLimitedTimeRewardItemData>.Enumerator enumerator = list.GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					if (enumerator.Current.Status == EKurotatoRewardStatus.Taken)
					{
						num++;
					}
				}
			}
			return new ValueTuple<int, int>(num, count);
		}

		// Token: 0x040213D4 RID: 136148
		private int KurotatoConfigIdInternal;

		// Token: 0x040213D5 RID: 136149
		private readonly Dictionary<int, KurotatoLevelData> LevelMap = new Dictionary<int, KurotatoLevelData>();

		// Token: 0x040213D6 RID: 136150
		private readonly Dictionary<int, List<KurotatoLevelData>> LevelGroupMap = new Dictionary<int, List<KurotatoLevelData>>();

		// Token: 0x040213D7 RID: 136151
		private readonly Dictionary<int, KurotatoRoleData> RoleMap = new Dictionary<int, KurotatoRoleData>();

		// Token: 0x040213D8 RID: 136152
		private readonly List<KurotatoRoleData> RoleList = new List<KurotatoRoleData>();

		// Token: 0x040213D9 RID: 136153
		private readonly Dictionary<int, KurotatoItemData> ItemDataMap = new Dictionary<int, KurotatoItemData>();

		// Token: 0x040213DA RID: 136154
		private readonly List<KurotatoItemData> ItemDataList = new List<KurotatoItemData>();

		// Token: 0x040213DB RID: 136155
		private readonly List<IKurotatoMediumItemGridData> ItemGridItemDataList = new List<IKurotatoMediumItemGridData>();

		// Token: 0x040213DC RID: 136156
		private readonly Dictionary<int, KurotatoWeaponData> WeaponDataMap = new Dictionary<int, KurotatoWeaponData>();

		// Token: 0x040213DD RID: 136157
		private readonly List<KurotatoWeaponData> WeaponDataList = new List<KurotatoWeaponData>();

		// Token: 0x040213DE RID: 136158
		private readonly List<IKurotatoMediumItemGridData> WeaponGridItemDataList = new List<IKurotatoMediumItemGridData>();

		// Token: 0x040213DF RID: 136159
		private readonly Dictionary<int, KurotatoNormalRewardItemData> NormalRewardDataMap = new Dictionary<int, KurotatoNormalRewardItemData>();

		// Token: 0x040213E0 RID: 136160
		private readonly Dictionary<int, KurotatoLimitedTimeRewardItemData> LimitRewardDataMap = new Dictionary<int, KurotatoLimitedTimeRewardItemData>();

		// Token: 0x040213E1 RID: 136161
		private readonly Dictionary<int, List<KurotatoLimitedTimeRewardItemData>> TabIdToLimitRewardDataListMap = new Dictionary<int, List<KurotatoLimitedTimeRewardItemData>>();

		// Token: 0x040213E2 RID: 136162
		private int MilestoneItemId;

		// Token: 0x040213E3 RID: 136163
		private readonly HashSet<int> ScoreRewardReceivedIdSet = new HashSet<int>();
	}
}
