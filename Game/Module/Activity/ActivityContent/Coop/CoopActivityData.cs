using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using Aki.Protocol;
using CSharpScript.Game.ServerStorage;
using CSharpScript.Game.ServerStorage.Container;

namespace CSharpScript.Game.Module.Activity.ActivityContent.Coop
{
	// Token: 0x02006984 RID: 27012
	[NullableContext(1)]
	[Nullable(0)]
	public class CoopActivityData : ActivityBaseData
	{
		// Token: 0x1700A1DE RID: 41438
		// (get) Token: 0x06043070 RID: 274544 RVA: 0x0113620B File Offset: 0x0113440B
		public List<CoopRoleData> CoopRoleDataList
		{
			get
			{
				return new List<CoopRoleData>(this.CoopRoleDataDict.Values);
			}
		}

		// Token: 0x06043071 RID: 274545 RVA: 0x01136220 File Offset: 0x01134420
		protected override void PhraseEx(ActivityData data)
		{
			this.InitCoopRoleItemDataList(data.RoleCoopActivityData.CoopRoleInfos);
			this.InitCoopLevelItemDataList(data.RoleCoopActivityData.CoopTaskCompleteInfos);
			this.InitCoopSpRewardDataList(data.RoleCoopActivityData.RewardGetList);
			this.UpdatePreCompleteLevelIdSet(data.RoleCoopActivityData.PreCompleteIds);
		}

		// Token: 0x06043072 RID: 274546 RVA: 0x01136271 File Offset: 0x01134471
		public override bool GetExternalButtonRedPointState()
		{
			return this.IsAnyRoleHasRedDot() || this.IsHasCoopSpRewardRedDot();
		}

		// Token: 0x06043073 RID: 274547 RVA: 0x01136283 File Offset: 0x01134483
		public override bool GetExDataRedPointShowState()
		{
			return this.IsAnyRoleHasRedDot() || this.IsHasCoopSpRewardRedDot();
		}

		// Token: 0x06043074 RID: 274548 RVA: 0x01136298 File Offset: 0x01134498
		protected override bool GetExDataFinishShowState()
		{
			using (List<CoopSpRewardData>.Enumerator enumerator = this.CoopSpRewardDataList.GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					if (enumerator.Current.State != ECoopSpRewardState.Done)
					{
						return false;
					}
				}
			}
			foreach (CoopRoleData coopRoleData in this.CoopRoleDataDict.Values)
			{
				using (Dictionary<int, CoopLevelData>.ValueCollection.Enumerator enumerator3 = coopRoleData.CoopLevelDataDict.Values.GetEnumerator())
				{
					while (enumerator3.MoveNext())
					{
						if (enumerator3.Current.State != ECoopLevelStatus.Done)
						{
							return false;
						}
					}
				}
			}
			return true;
		}

		// Token: 0x06043075 RID: 274549 RVA: 0x01136380 File Offset: 0x01134580
		private void InitCoopRoleItemDataList(IList<CoopRoleInfo> dataList)
		{
			this.CoopRoleDataDict.Clear();
			foreach (CoopRoleInfo coopRoleInfo in dataList)
			{
				int coopRoleId = coopRoleInfo.CoopRoleId;
				CoopRoleData coopRoleData = new CoopRoleData(coopRoleId);
				this.CoopRoleDataDict[coopRoleId] = coopRoleData;
				IReadOnlyList<CoopRoleLevel> coopConfigAllLevel = ConfigBase<CoopConfig>.Instance.GetCoopConfigAllLevel(base.Id, coopRoleId);
				if (coopConfigAllLevel != null)
				{
					foreach (CoopRoleLevel coopRoleLevel in coopConfigAllLevel)
					{
						CoopLevelData value = new CoopLevelData(coopRoleLevel.Id);
						coopRoleData.CoopLevelDataDict[coopRoleLevel.Id] = value;
						this.CoopLevelDataDict[coopRoleLevel.Id] = value;
					}
					coopRoleData.UpdateCurLevel(coopRoleInfo.RoleLevel, coopRoleInfo.RewardLevel);
					if (coopRoleInfo.FinishTime != 0L)
					{
						coopRoleData.SetMaxLevelTimeStamp(coopRoleInfo.FinishTime);
					}
				}
			}
			List<int> list = new List<int>(this.CoopRoleDataDict.Keys);
			list.Sort();
			Dictionary<int, CoopRoleData> dictionary = new Dictionary<int, CoopRoleData>();
			foreach (int key in list)
			{
				CoopRoleData value2;
				if (this.CoopRoleDataDict.TryGetValue(key, out value2))
				{
					dictionary[key] = value2;
				}
			}
			this.CoopRoleDataDict = dictionary;
		}

		// Token: 0x06043076 RID: 274550 RVA: 0x01136514 File Offset: 0x01134714
		private void InitCoopLevelItemDataList(IList<CoopTaskCompleteInfo> dataList)
		{
			foreach (CoopTaskCompleteInfo data in dataList)
			{
				this.UpdateOneRoleLevelSubConditionData(data);
			}
		}

		// Token: 0x06043077 RID: 274551 RVA: 0x0113655C File Offset: 0x0113475C
		private void InitCoopSpRewardDataList(IList<int> idList)
		{
			this.CoopSpRewardClaimedSet.Clear();
			foreach (int item in idList)
			{
				this.CoopSpRewardClaimedSet.Add(item);
			}
			this.UpdateCoopSpRewardDataList();
		}

		// Token: 0x06043078 RID: 274552 RVA: 0x011365BC File Offset: 0x011347BC
		public void UpdatePreCompleteLevelIdSet(IList<int> preCompleteIds)
		{
			foreach (int item in preCompleteIds)
			{
				this.PreCompleteLevelIdSet.Add(item);
			}
			this.UpdateAllCoopRoleLevelDataState();
		}

		// Token: 0x06043079 RID: 274553 RVA: 0x01136610 File Offset: 0x01134810
		private void UpdateCoopSpRewardDataList()
		{
			IReadOnlyList<CoopSpReward> coopSpRewardConfigByActivityId = ConfigBase<CoopConfig>.Instance.GetCoopSpRewardConfigByActivityId(base.Id);
			if (coopSpRewardConfigByActivityId == null)
			{
				return;
			}
			int curTotalCoopLevel = this.GetCurTotalCoopLevel();
			if (this.CoopSpRewardDataList.Count != coopSpRewardConfigByActivityId.Count)
			{
				this.CoopSpRewardDataList = new List<CoopSpRewardData>();
			}
			for (int i = 0; i < coopSpRewardConfigByActivityId.Count; i++)
			{
				CoopSpReward coopSpReward = coopSpRewardConfigByActivityId[i];
				ECoopSpRewardState state = ECoopSpRewardState.Lock;
				if (this.CoopSpRewardClaimedSet.Contains(coopSpReward.Id))
				{
					state = ECoopSpRewardState.Done;
				}
				else if (curTotalCoopLevel >= coopSpReward.RoleLevelSum)
				{
					state = ECoopSpRewardState.Reward;
				}
				if (i < this.CoopSpRewardDataList.Count)
				{
					this.CoopSpRewardDataList[i].SetState(state);
				}
				else
				{
					this.CoopSpRewardDataList.Add(new CoopSpRewardData(coopSpReward.Id, state));
				}
			}
		}

		// Token: 0x0604307A RID: 274554 RVA: 0x011366D5 File Offset: 0x011348D5
		public bool IsLevelPreComplete(int levelId)
		{
			return this.PreCompleteLevelIdSet.Contains(levelId);
		}

		// Token: 0x0604307B RID: 274555 RVA: 0x011366E4 File Offset: 0x011348E4
		public int GetCurTotalCoopLevel()
		{
			int num = 0;
			foreach (CoopRoleData coopRoleData in this.CoopRoleDataList)
			{
				num += coopRoleData.CurRoleLevel;
			}
			return num;
		}

		// Token: 0x0604307C RID: 274556 RVA: 0x0113673C File Offset: 0x0113493C
		public bool UpdateOneRoleData(CoopRoleInfo data)
		{
			CoopRoleData coopRoleData;
			if (!this.CoopRoleDataDict.TryGetValue(data.CoopRoleId, out coopRoleData))
			{
				return false;
			}
			int curRoleLevel = coopRoleData.CurRoleLevel;
			coopRoleData.UpdateCurLevel(data.RoleLevel, data.RewardLevel);
			if (data.FinishTime != 0L)
			{
				coopRoleData.SetMaxLevelTimeStamp(data.FinishTime);
			}
			this.UpdateCoopSpRewardDataList();
			return curRoleLevel < data.RoleLevel;
		}

		// Token: 0x0604307D RID: 274557 RVA: 0x011367A0 File Offset: 0x011349A0
		public void UpdateOneRoleLevelSubConditionData(CoopTaskCompleteInfo data)
		{
			CoopTaskConfig? coopTaskConfigById = ConfigBase<CoopConfig>.Instance.GetCoopTaskConfigById(data.CoopTaskId);
			if (coopTaskConfigById == null)
			{
				return;
			}
			int coopLevelId = coopTaskConfigById.Value.CoopLevelId;
			CoopLevelData coopLevelData;
			if (!this.CoopLevelDataDict.TryGetValue(coopLevelId, out coopLevelData))
			{
				return;
			}
			if (!coopLevelData.IsHaveSubCondition)
			{
				return;
			}
			coopLevelData.UpdateSubConditionState(data);
		}

		// Token: 0x0604307E RID: 274558 RVA: 0x011367FC File Offset: 0x011349FC
		public void UpdateCoopRoleReward(int levelId)
		{
			CoopRoleLevel? coopConfigById = ConfigBase<CoopConfig>.Instance.GetCoopConfigById(levelId);
			if (coopConfigById == null || coopConfigById.Value.CoopRoleId == 0)
			{
				return;
			}
			CoopRoleData coopRoleData;
			if (!this.CoopRoleDataDict.TryGetValue(coopConfigById.Value.CoopRoleId, out coopRoleData))
			{
				return;
			}
			coopRoleData.CurRewardLevel = coopRoleData.CurRoleLevel;
			coopRoleData.UpdateAllCoopLevelDataState();
		}

		// Token: 0x0604307F RID: 274559 RVA: 0x01136864 File Offset: 0x01134A64
		public void UpdateCoopSpRewardClaimed(List<int> rewardIds)
		{
			foreach (int item in rewardIds)
			{
				this.CoopSpRewardClaimedSet.Add(item);
			}
			this.UpdateCoopSpRewardDataList();
		}

		// Token: 0x06043080 RID: 274560 RVA: 0x011368C0 File Offset: 0x01134AC0
		[NullableContext(2)]
		public CoopRoleData GetRoleData(int roleId)
		{
			if (!this.CoopRoleDataDict.ContainsKey(roleId))
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.Activity;
				ELogAuthor author = ELogAuthor.LZK;
				DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(28, 1);
				defaultInterpolatedStringHandler.AppendLiteral("[Coop] 获取Coop角色数据失败，roleId: ");
				defaultInterpolatedStringHandler.AppendFormatted<int>(roleId);
				instance.Error(module, author, defaultInterpolatedStringHandler.ToStringAndClear(), default(ReadOnlySpan<ValueTuple<string, object>>));
				return null;
			}
			CoopRoleData result;
			this.CoopRoleDataDict.TryGetValue(roleId, out result);
			return result;
		}

		// Token: 0x06043081 RID: 274561 RVA: 0x0113692C File Offset: 0x01134B2C
		public int GetRoleIndexByRoleId(int roleId)
		{
			int num = new List<int>(this.CoopRoleDataDict.Keys).IndexOf(roleId);
			if (num == -1)
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.Activity;
				ELogAuthor author = ELogAuthor.LZK;
				DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(28, 1);
				defaultInterpolatedStringHandler.AppendLiteral("[Coop] 获取Coop角色索引失败，roleId: ");
				defaultInterpolatedStringHandler.AppendFormatted<int>(roleId);
				instance.Error(module, author, defaultInterpolatedStringHandler.ToStringAndClear(), default(ReadOnlySpan<ValueTuple<string, object>>));
			}
			return num;
		}

		// Token: 0x06043082 RID: 274562 RVA: 0x01136994 File Offset: 0x01134B94
		public int GetRoleIdByIndex(int index)
		{
			if (index < 0 || index >= this.CoopRoleDataList.Count)
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.Activity;
				ELogAuthor author = ELogAuthor.LZK;
				DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(27, 1);
				defaultInterpolatedStringHandler.AppendLiteral("[Coop] 获取Coop角色Id失败，index: ");
				defaultInterpolatedStringHandler.AppendFormatted<int>(index);
				instance.Error(module, author, defaultInterpolatedStringHandler.ToStringAndClear(), default(ReadOnlySpan<ValueTuple<string, object>>));
				return -1;
			}
			return this.CoopRoleDataList[index].RoleId;
		}

		// Token: 0x06043083 RID: 274563 RVA: 0x01136A08 File Offset: 0x01134C08
		[return: Nullable(new byte[]
		{
			2,
			1
		})]
		public List<CoopLevelData> GetCoopLevelDataListByRoleId(int roleId)
		{
			CoopRoleData coopRoleData;
			if (this.CoopRoleDataDict.TryGetValue(roleId, out coopRoleData))
			{
				return coopRoleData.GetCoopLevelDataList();
			}
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.Activity;
			ELogAuthor author = ELogAuthor.LZK;
			DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(32, 1);
			defaultInterpolatedStringHandler.AppendLiteral("[Coop] 获取角色Coop等级数据列表失败，roleId: ");
			defaultInterpolatedStringHandler.AppendFormatted<int>(roleId);
			instance.Error(module, author, defaultInterpolatedStringHandler.ToStringAndClear(), default(ReadOnlySpan<ValueTuple<string, object>>));
			return null;
		}

		// Token: 0x06043084 RID: 274564 RVA: 0x01136A6C File Offset: 0x01134C6C
		public long GetRoleMaxLevelTimeStamp(int roleId)
		{
			CoopRoleData roleData = this.GetRoleData(roleId);
			if (roleData == null)
			{
				return 0L;
			}
			return roleData.MaxLevelTimeStamp;
		}

		// Token: 0x06043085 RID: 274565 RVA: 0x01136A84 File Offset: 0x01134C84
		[NullableContext(2)]
		public CoopLevelData GetCoopLevelData(int levelId)
		{
			if (!this.CoopLevelDataDict.ContainsKey(levelId))
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.Activity;
				ELogAuthor author = ELogAuthor.LZK;
				DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(29, 1);
				defaultInterpolatedStringHandler.AppendLiteral("[Coop] 获取Coop等级数据失败，levelId: ");
				defaultInterpolatedStringHandler.AppendFormatted<int>(levelId);
				instance.Error(module, author, defaultInterpolatedStringHandler.ToStringAndClear(), default(ReadOnlySpan<ValueTuple<string, object>>));
				return null;
			}
			CoopLevelData result;
			this.CoopLevelDataDict.TryGetValue(levelId, out result);
			return result;
		}

		// Token: 0x06043086 RID: 274566 RVA: 0x01136AF0 File Offset: 0x01134CF0
		public int GetRoleCurCoopLevel(int roleId)
		{
			CoopRoleData coopRoleData;
			if (this.CoopRoleDataDict.TryGetValue(roleId, out coopRoleData))
			{
				return coopRoleData.CurRoleLevel;
			}
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.Activity;
			ELogAuthor author = ELogAuthor.LZK;
			DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(32, 1);
			defaultInterpolatedStringHandler.AppendLiteral("[Coop] 获取角色Coop等级失败，roleId: ");
			defaultInterpolatedStringHandler.AppendFormatted<int>(roleId);
			defaultInterpolatedStringHandler.AppendLiteral("，返回0");
			instance.Error(module, author, defaultInterpolatedStringHandler.ToStringAndClear(), default(ReadOnlySpan<ValueTuple<string, object>>));
			return 0;
		}

		// Token: 0x06043087 RID: 274567 RVA: 0x01136B60 File Offset: 0x01134D60
		public int GetRoleCurCoopLevelId(int roleId)
		{
			CoopRoleData coopRoleData;
			this.CoopRoleDataDict.TryGetValue(roleId, out coopRoleData);
			IReadOnlyList<CoopRoleLevel> coopConfigAllLevel = ConfigBase<CoopConfig>.Instance.GetCoopConfigAllLevel(base.Id, roleId);
			if (coopRoleData == null || coopConfigAllLevel == null)
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.Activity;
				ELogAuthor author = ELogAuthor.LZK;
				DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(65, 1);
				defaultInterpolatedStringHandler.AppendLiteral("[Coop] 获取角色Coop等级Id失败，roleData or allLevelConfig is null，roleId: ");
				defaultInterpolatedStringHandler.AppendFormatted<int>(roleId);
				instance.Error(module, author, defaultInterpolatedStringHandler.ToStringAndClear(), default(ReadOnlySpan<ValueTuple<string, object>>));
				return 0;
			}
			CoopRoleLevel? coopRoleLevel = null;
			foreach (CoopRoleLevel value in coopConfigAllLevel)
			{
				if (value.CoopLevel == coopRoleData.CurRoleLevel)
				{
					coopRoleLevel = new CoopRoleLevel?(value);
					break;
				}
			}
			if (coopRoleLevel == null)
			{
				return coopConfigAllLevel[0].Id;
			}
			return coopRoleLevel.GetValueOrDefault().Id;
		}

		// Token: 0x06043088 RID: 274568 RVA: 0x01136C5C File Offset: 0x01134E5C
		public int GetRoleCurCoopLevelIdFinalZero(int roleId)
		{
			CoopRoleData coopRoleData;
			this.CoopRoleDataDict.TryGetValue(roleId, out coopRoleData);
			IReadOnlyList<CoopRoleLevel> coopConfigAllLevel = ConfigBase<CoopConfig>.Instance.GetCoopConfigAllLevel(base.Id, roleId);
			if (coopRoleData == null || coopConfigAllLevel == null)
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.Activity;
				ELogAuthor author = ELogAuthor.LZK;
				DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(65, 1);
				defaultInterpolatedStringHandler.AppendLiteral("[Coop] 获取角色Coop等级Id失败，roleData or allLevelConfig is null，roleId: ");
				defaultInterpolatedStringHandler.AppendFormatted<int>(roleId);
				instance.Error(module, author, defaultInterpolatedStringHandler.ToStringAndClear(), default(ReadOnlySpan<ValueTuple<string, object>>));
				return 0;
			}
			CoopRoleLevel? coopRoleLevel = null;
			foreach (CoopRoleLevel value in coopConfigAllLevel)
			{
				if (value.CoopLevel == coopRoleData.CurRoleLevel)
				{
					coopRoleLevel = new CoopRoleLevel?(value);
					break;
				}
			}
			if (coopRoleLevel == null)
			{
				return 0;
			}
			return coopRoleLevel.GetValueOrDefault().Id;
		}

		// Token: 0x06043089 RID: 274569 RVA: 0x01136D48 File Offset: 0x01134F48
		public int GetClaimedRewardCount()
		{
			int num = 0;
			using (List<CoopSpRewardData>.Enumerator enumerator = this.CoopSpRewardDataList.GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					if (enumerator.Current.State == ECoopSpRewardState.Done)
					{
						num++;
					}
				}
			}
			return num;
		}

		// Token: 0x0604308A RID: 274570 RVA: 0x01136DA4 File Offset: 0x01134FA4
		public bool IsRoleCurCoopLevelMax(int roleId)
		{
			CoopRoleData coopRoleData;
			return this.CoopRoleDataDict.TryGetValue(roleId, out coopRoleData) && coopRoleData.IsMaxLevel;
		}

		// Token: 0x0604308B RID: 274571 RVA: 0x01136DCC File Offset: 0x01134FCC
		public bool IsAnyRoleHasRedDot()
		{
			foreach (CoopRoleData coopRoleData in this.CoopRoleDataDict.Values)
			{
				if (this.IsRoleHasRedDot(coopRoleData.RoleId))
				{
					return true;
				}
			}
			return false;
		}

		// Token: 0x0604308C RID: 274572 RVA: 0x01136E34 File Offset: 0x01135034
		public bool IsHasCoopSpRewardRedDot()
		{
			using (List<CoopSpRewardData>.Enumerator enumerator = this.CoopSpRewardDataList.GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					if (enumerator.Current.State == ECoopSpRewardState.Reward)
					{
						return true;
					}
				}
			}
			return false;
		}

		// Token: 0x0604308D RID: 274573 RVA: 0x01136E90 File Offset: 0x01135090
		public bool IsRoleHasRedDot(int roleId)
		{
			CoopRoleData coopRoleData;
			return this.CoopRoleDataDict.TryGetValue(roleId, out coopRoleData) && coopRoleData.IsUnLock && (this.IsRoleHasPhotoRedDot(roleId) || this.IsRoleHasCoopLevelRedDot(roleId));
		}

		// Token: 0x0604308E RID: 274574 RVA: 0x01136ECC File Offset: 0x011350CC
		public bool IsRoleHasPhotoRedDot(int roleId)
		{
			return this.IsRoleCurCoopLevelMax(roleId) && !(ModelBase<ServerStorageModel>.Instance.Get(EClientStorageSystemIdType.CoopRolePhotoRedDot) as ServerStorageSet).Has(roleId);
		}

		// Token: 0x0604308F RID: 274575 RVA: 0x01136EF8 File Offset: 0x011350F8
		private bool IsRoleHasCoopLevelRedDot(int roleId)
		{
			CoopRoleData coopRoleData;
			this.CoopRoleDataDict.TryGetValue(roleId, out coopRoleData);
			foreach (CoopLevelData coopLevelData in coopRoleData.CoopLevelDataDict.Values)
			{
				if (coopLevelData.State == ECoopLevelStatus.Reward)
				{
					return true;
				}
				if (coopLevelData.IsShowDoingNew)
				{
					return true;
				}
			}
			return false;
		}

		// Token: 0x06043090 RID: 274576 RVA: 0x01136F74 File Offset: 0x01135174
		public void ClearRolePhotoRedDot(int roleId)
		{
		}

		// Token: 0x06043091 RID: 274577 RVA: 0x01136F78 File Offset: 0x01135178
		public void UpdateAllCoopRoleLevelDataState()
		{
			foreach (CoopRoleData coopRoleData in this.CoopRoleDataDict.Values)
			{
				coopRoleData.UpdateAllCoopLevelDataState();
			}
		}

		// Token: 0x04025539 RID: 152889
		public Dictionary<int, CoopRoleData> CoopRoleDataDict = new Dictionary<int, CoopRoleData>();

		// Token: 0x0402553A RID: 152890
		public Dictionary<int, CoopLevelData> CoopLevelDataDict = new Dictionary<int, CoopLevelData>();

		// Token: 0x0402553B RID: 152891
		public HashSet<int> CoopSpRewardClaimedSet = new HashSet<int>();

		// Token: 0x0402553C RID: 152892
		public List<CoopSpRewardData> CoopSpRewardDataList = new List<CoopSpRewardData>();

		// Token: 0x0402553D RID: 152893
		public HashSet<int> PreCompleteLevelIdSet = new HashSet<int>();
	}
}
