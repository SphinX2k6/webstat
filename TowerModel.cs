using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using Aki.Config;
using Aki.Protocol;
using CSharpScript.Game.Common;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.AdventureGuide;
using CSharpScript.Game.ServerStorage;
using CSharpScript.Game.ServerStorage.Container;
using CSharpScript.Game.Ui;

// Token: 0x02002BE5 RID: 11237
[NullableContext(1)]
[Nullable(new byte[]
{
	0,
	1
})]
[Model(0)]
public class TowerModel : ModelBase<TowerModel>
{
	// Token: 0x060166A2 RID: 91810 RVA: 0x00639628 File Offset: 0x00637828
	protected override bool OnInit()
	{
		this.MaxRoleCost = ConfigCommonParamById.GetIntConfig("TowerRoleTotalCost").Value;
		this.TowerGuideDelayTime = ConfigCommonParamById.GetIntConfig("TowerGuideDelayTime").Value;
		this.TowerSettlementDelayTime = ConfigCommonParamById.GetIntConfig("TowerSettleDelayTime").Value;
		return true;
	}

	// Token: 0x060166A3 RID: 91811 RVA: 0x0063967E File Offset: 0x0063787E
	protected override bool OnLeaveLevel()
	{
		this.CurrentSelectFloor = -1;
		return true;
	}

	// Token: 0x060166A4 RID: 91812 RVA: 0x00639688 File Offset: 0x00637888
	private void InitReward()
	{
		this.SetDifficultyReward(1, null);
		this.SetDifficultyReward(2, null);
		this.SetDifficultyReward(3, null);
		this.SetDifficultyReward(4, null);
	}

	// Token: 0x060166A5 RID: 91813 RVA: 0x006396AC File Offset: 0x006378AC
	public void RefreshTowerInfo(TowerInfo towerInfo)
	{
		this.TowerBeginTime = new long?(towerInfo.BeginTime);
		this.TowerEndTime = new long?(towerInfo.EndTime);
		this.MaxUnlockDifficulty = towerInfo.MaxUnlockDifficulty;
		this.QuickPassId = towerInfo.QuickPassId;
		if (this.CurrentSeason != towerInfo.CurrentSeason)
		{
			Singleton<EventSystem>.Instance.Emit<int>(EEventName.RefreshCommonActivityRedDot, 100300002);
		}
		this.CurrentSeason = towerInfo.CurrentSeason;
		this.InitReward();
		this.DataSeason = towerInfo.DataSeason;
		this.RefreshTowerInfoByDifficulty(towerInfo.TowerDifficulties);
		this.ReportPeriodicActivityRedAppear();
	}

	// Token: 0x060166A6 RID: 91814 RVA: 0x00639748 File Offset: 0x00637948
	public void RefreshTowerInfoByFloor(IList<TowerFloorPb> floorInfo)
	{
		foreach (TowerFloorPb infoFormFloor in floorInfo)
		{
			this.SetInfoFormFloor(infoFormFloor);
		}
	}

	// Token: 0x060166A7 RID: 91815 RVA: 0x00639790 File Offset: 0x00637990
	public void RefreshTowerInfoByDifficulty(IList<TowerDifficultyPb> difficultyInfo)
	{
		foreach (TowerDifficultyPb towerDifficultyPb in difficultyInfo)
		{
			this.SetDifficultyReward(towerDifficultyPb.Difficulty, towerDifficultyPb.RewardIndex);
			this.SetTowerInfoMapFormAreasData(towerDifficultyPb.TowerAreas);
			this.TowerDifficultiesMaxStarMap[towerDifficultyPb.Difficulty] = towerDifficultyPb.MaxStar;
		}
	}

	// Token: 0x060166A8 RID: 91816 RVA: 0x00639808 File Offset: 0x00637A08
	public void DeleteVariationTowerInfo()
	{
		List<int> list = new List<int>();
		foreach (KeyValuePair<int, TowerFloorInfo> keyValuePair in this.TowerInfoMap)
		{
			if (keyValuePair.Value.Difficulties == 3)
			{
				list.Add(keyValuePair.Key);
			}
		}
		for (int i = 0; i < list.Count; i++)
		{
			this.TowerInfoMap.Remove(list[i]);
		}
		this.TowerDifficultiesRewardMap.Remove(3);
		this.TowerDifficultiesMaxStarMap[3] = 0;
		foreach (Dictionary<int, int> dictionary in this.RoleDifficultyFormationMap.Values)
		{
			dictionary[3] = 0;
		}
	}

	// Token: 0x060166A9 RID: 91817 RVA: 0x006398FC File Offset: 0x00637AFC
	public int? GetFloorStars(int towerId)
	{
		TowerFloorInfo towerFloorInfo;
		if (this.TowerInfoMap.TryGetValue(towerId, out towerFloorInfo))
		{
			return new int?(towerFloorInfo.Star);
		}
		return null;
	}

	// Token: 0x060166AA RID: 91818 RVA: 0x00639930 File Offset: 0x00637B30
	[NullableContext(2)]
	public List<int> GetFloorStarsIndex(int towerId)
	{
		TowerFloorInfo towerFloorInfo;
		if (this.TowerInfoMap.TryGetValue(towerId, out towerFloorInfo))
		{
			return towerFloorInfo.StarIndex;
		}
		return null;
	}

	// Token: 0x060166AB RID: 91819 RVA: 0x00639958 File Offset: 0x00637B58
	public int GetAreaStars(int difficulty, int area, bool useHandle = false)
	{
		int num = 0;
		if (!useHandle)
		{
			using (Dictionary<int, TowerFloorInfo>.ValueCollection.Enumerator enumerator = this.TowerInfoMap.Values.GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					TowerFloorInfo towerFloorInfo = enumerator.Current;
					if (towerFloorInfo.Difficulties == difficulty && towerFloorInfo.Area == area)
					{
						num += towerFloorInfo.Star;
					}
				}
				return num;
			}
		}
		if (this.TowerInfoMapHandle != null)
		{
			foreach (TowerFloorInfo towerFloorInfo2 in this.TowerInfoMapHandle.Values)
			{
				if (towerFloorInfo2.Difficulties == difficulty && towerFloorInfo2.Area == area)
				{
					num += towerFloorInfo2.Star;
				}
			}
		}
		return num;
	}

	// Token: 0x060166AC RID: 91820 RVA: 0x00639A30 File Offset: 0x00637C30
	public int GetDifficultyMaxStars(int difficulty, bool useHandle = false)
	{
		int? num = null;
		int value2;
		if (!useHandle)
		{
			int value;
			if (this.TowerDifficultiesMaxStarMap.TryGetValue(difficulty, out value))
			{
				num = new int?(value);
			}
		}
		else if (this.TowerDifficultiesMaxStarMapHandle != null && this.TowerDifficultiesMaxStarMapHandle.TryGetValue(difficulty, out value2))
		{
			num = new int?(value2);
		}
		return num.GetValueOrDefault();
	}

	// Token: 0x060166AD RID: 91821 RVA: 0x00639A8C File Offset: 0x00637C8C
	public int GetDifficultyStars(int difficulty)
	{
		int num = 0;
		foreach (TowerFloorInfo towerFloorInfo in this.TowerInfoMap.Values)
		{
			if (towerFloorInfo.Difficulties == difficulty)
			{
				num += towerFloorInfo.Star;
			}
		}
		return num;
	}

	// Token: 0x060166AE RID: 91822 RVA: 0x00639AF4 File Offset: 0x00637CF4
	public int GetAreaAllStars(int difficulty, int area)
	{
		return 3 * ConfigBase<TowerClimbConfig>.Instance.GetAreaFloorNumber(this.CurrentSeason, difficulty, area);
	}

	// Token: 0x060166AF RID: 91823 RVA: 0x00639B0A File Offset: 0x00637D0A
	public int GetDifficultyAllStars(int difficulty, bool useHandle = false)
	{
		return 3 * ConfigBase<TowerClimbConfig>.Instance.GetDifficultyFloorNumber(useHandle ? this.SeasonHandle : this.CurrentSeason, difficulty);
	}

	// Token: 0x060166B0 RID: 91824 RVA: 0x00639B2C File Offset: 0x00637D2C
	[return: Nullable(new byte[]
	{
		2,
		1
	})]
	public List<TowerReward> GetDifficultyReward(int difficulty)
	{
		List<TowerReward> result;
		if (this.TowerDifficultiesRewardMap.TryGetValue(difficulty, out result))
		{
			return result;
		}
		return null;
	}

	// Token: 0x060166B1 RID: 91825 RVA: 0x00639B4C File Offset: 0x00637D4C
	public bool GetHaveChallengeFloor(int floorId)
	{
		return this.TowerInfoMap.ContainsKey(floorId);
	}

	// Token: 0x060166B2 RID: 91826 RVA: 0x00639B5C File Offset: 0x00637D5C
	public bool GetHaveChallengeFloorAndFormation(int floorId)
	{
		TowerFloorInfo towerFloorInfo;
		return this.TowerInfoMap.TryGetValue(floorId, out towerFloorInfo) && towerFloorInfo.Formation != null && towerFloorInfo.Formation.Count != 0;
	}

	// Token: 0x060166B3 RID: 91827 RVA: 0x00639B94 File Offset: 0x00637D94
	[NullableContext(2)]
	public TowerFloorInfo GetFloorData(int floorId)
	{
		TowerFloorInfo result;
		if (this.TowerInfoMap.TryGetValue(floorId, out result))
		{
			return result;
		}
		return null;
	}

	// Token: 0x060166B4 RID: 91828 RVA: 0x00639BB4 File Offset: 0x00637DB4
	[NullableContext(2)]
	private void SetDifficultyReward(int difficulty, IList<int> rewardIndex)
	{
		List<TowerReward> difficultyReward = this.GetDifficultyReward(difficulty);
		if (difficultyReward != null)
		{
			for (int i = 0; i < difficultyReward.Count; i++)
			{
				TowerReward towerReward = difficultyReward[i];
				towerReward.IsReceived = new bool?(rewardIndex != null && this.Contains(rewardIndex, towerReward.Index));
			}
			return;
		}
		TowerSeason? towerSeason = ConfigBase<TowerClimbConfig>.Instance.GetTowerSeason(this.CurrentSeason);
		IReadOnlyList<IntPair> difficultyReward2 = ConfigBase<TowerClimbConfig>.Instance.GetDifficultyReward(difficulty, (towerSeason != null) ? towerSeason.GetValueOrDefault().RewardGroup : 0);
		int num = (difficultyReward2 != null) ? difficultyReward2.Count : 0;
		List<TowerReward> list = new List<TowerReward>();
		for (int j = 0; j < num; j++)
		{
			IntPair intPair = difficultyReward2[j];
			list.Add(new TowerReward(intPair.Item1, intPair.Item2, j)
			{
				IsReceived = new bool?(rewardIndex != null && this.Contains(rewardIndex, j))
			});
		}
		this.TowerDifficultiesRewardMap[difficulty] = list;
	}

	// Token: 0x060166B5 RID: 91829 RVA: 0x00639CBC File Offset: 0x00637EBC
	private void SetTowerInfoMapFormAreasData(IList<TowerAreaPb> areas)
	{
		foreach (TowerAreaPb towerAreaPb in areas)
		{
			foreach (TowerFloorPb infoFormFloor in towerAreaPb.TowerFloors)
			{
				this.SetInfoFormFloor(infoFormFloor);
			}
		}
	}

	// Token: 0x060166B6 RID: 91830 RVA: 0x00639D38 File Offset: 0x00637F38
	private void SetInfoFormFloor(TowerFloorPb floorData)
	{
		TowerFloorInfo towerFloorInfo;
		if (this.TowerInfoMap.TryGetValue(floorData.TowerConfigId, out towerFloorInfo))
		{
			towerFloorInfo.Star = floorData.Star;
			towerFloorInfo.StarIndex = floorData.StarIndex.ToList<int>();
			towerFloorInfo.IsQuickPass = floorData.IsQuickPass;
			if (towerFloorInfo.Formation != null)
			{
				for (int i = 0; i < towerFloorInfo.Formation.Count; i++)
				{
					TowerRolePb towerRolePb = towerFloorInfo.Formation[i];
					this.ReduceRoleFormationCost(towerRolePb.RoleId, towerFloorInfo.Difficulties, towerFloorInfo.Cost);
				}
			}
			towerFloorInfo.Formation = floorData.Formation.ToList<TowerRolePb>();
		}
		else
		{
			towerFloorInfo = new TowerFloorInfo(floorData.TowerConfigId, floorData.Star, floorData.Formation.ToList<TowerRolePb>(), floorData.StarIndex.ToList<int>(), floorData.IsQuickPass);
			this.TowerInfoMap[floorData.TowerConfigId] = towerFloorInfo;
			Singleton<EventSystem>.Instance.Emit<int, int>(EEventName.OnTowerRecordUpdate, floorData.TowerConfigId, towerFloorInfo.Difficulties);
		}
		if (towerFloorInfo.Formation != null)
		{
			for (int j = 0; j < towerFloorInfo.Formation.Count; j++)
			{
				TowerRolePb towerRolePb2 = towerFloorInfo.Formation[j];
				this.AddRoleFormationCost(towerRolePb2.RoleId, towerFloorInfo.Difficulties, towerFloorInfo.Cost);
			}
		}
	}

	// Token: 0x060166B7 RID: 91831 RVA: 0x00639E7C File Offset: 0x0063807C
	private void AddRoleFormationCost(int roleId, int difficulty, int cost)
	{
		Dictionary<int, int> dictionary;
		if (!this.RoleDifficultyFormationMap.TryGetValue(roleId, out dictionary))
		{
			dictionary = new Dictionary<int, int>();
		}
		int num;
		if (dictionary.TryGetValue(difficulty, out num))
		{
			num += cost;
			dictionary[difficulty] = num;
		}
		else
		{
			dictionary[difficulty] = cost;
		}
		this.RoleDifficultyFormationMap[roleId] = dictionary;
	}

	// Token: 0x060166B8 RID: 91832 RVA: 0x00639ED0 File Offset: 0x006380D0
	public void ReduceRoleFormationCost(int roleId, int difficulty, int cost)
	{
		Dictionary<int, int> dictionary;
		int num;
		if (this.RoleDifficultyFormationMap.TryGetValue(roleId, out dictionary) && dictionary.TryGetValue(difficulty, out num) && num != 0)
		{
			num -= cost;
			dictionary[difficulty] = num;
		}
	}

	// Token: 0x060166B9 RID: 91833 RVA: 0x00639F08 File Offset: 0x00638108
	[NullableContext(0)]
	public ValueTuple<int, int> GetDifficultyProgress(int difficultId)
	{
		int[] difficultyAllFloor = ConfigBase<TowerClimbConfig>.Instance.GetDifficultyAllFloor(this.CurrentSeason, difficultId);
		int num = 0;
		foreach (int key in difficultyAllFloor)
		{
			if (this.TowerInfoMap.ContainsKey(key))
			{
				num++;
			}
		}
		return new ValueTuple<int, int>(num, difficultyAllFloor.Length);
	}

	// Token: 0x060166BA RID: 91834 RVA: 0x00639F58 File Offset: 0x00638158
	public bool GetDifficultyIsClear(int currentDifficulty)
	{
		if (this.MaxUnlockDifficulty > currentDifficulty)
		{
			return true;
		}
		foreach (int key in ConfigBase<TowerClimbConfig>.Instance.GetDifficultyAllFloor(this.CurrentSeason, currentDifficulty))
		{
			if (!this.TowerInfoMap.ContainsKey(key))
			{
				return false;
			}
		}
		return true;
	}

	// Token: 0x060166BB RID: 91835 RVA: 0x00639FA5 File Offset: 0x006381A5
	public int GetMaxDifficulty()
	{
		if (!this.GetDifficultyIsClear(1))
		{
			return 1;
		}
		if (!this.GetDifficultyIsClear(2))
		{
			return 2;
		}
		if (this.GetDifficultyRewardProgress(3) != 1f)
		{
			return 3;
		}
		if (this.GetDifficultyRewardProgress(4) != 1f)
		{
			return 4;
		}
		return 3;
	}

	// Token: 0x060166BC RID: 91836 RVA: 0x00639FE2 File Offset: 0x006381E2
	public int[] GetDifficultyAllAreaFirstFloor(int difficulty, bool useHandle = false)
	{
		return ConfigBase<TowerClimbConfig>.Instance.GetDifficultyAllAreaFirstFloor(useHandle ? this.SeasonHandle : this.CurrentSeason, difficulty);
	}

	// Token: 0x060166BD RID: 91837 RVA: 0x0063A000 File Offset: 0x00638200
	public int[] GetDifficultyAreaAllFloor(int difficulty, int area)
	{
		return ConfigBase<TowerClimbConfig>.Instance.GetDifficultyAreaAllFloor(this.CurrentSeason, difficulty, area);
	}

	// Token: 0x060166BE RID: 91838 RVA: 0x0063A014 File Offset: 0x00638214
	public int[] GetDifficultyAllFloor(int difficulty)
	{
		return ConfigBase<TowerClimbConfig>.Instance.GetDifficultyAllFloor(this.CurrentSeason, difficulty);
	}

	// Token: 0x060166BF RID: 91839 RVA: 0x0063A028 File Offset: 0x00638228
	public bool GetFloorIsUnlock(int towerId)
	{
		if (this.GetHaveChallengeFloor(towerId))
		{
			return true;
		}
		int lastFloorInArea = ConfigBase<TowerClimbConfig>.Instance.GetLastFloorInArea(towerId);
		return lastFloorInArea == 0 || this.GetHaveChallengeFloor(lastFloorInArea);
	}

	// Token: 0x060166C0 RID: 91840 RVA: 0x0063A058 File Offset: 0x00638258
	public int GetRoleRemainCost(int roleId, int difficulty)
	{
		Dictionary<int, int> dictionary;
		if (!this.RoleDifficultyFormationMap.TryGetValue(roleId, out dictionary))
		{
			return this.MaxRoleCost;
		}
		int num;
		if (!dictionary.TryGetValue(difficulty, out num))
		{
			return this.MaxRoleCost;
		}
		return this.MaxRoleCost - num;
	}

	// Token: 0x060166C1 RID: 91841 RVA: 0x0063A098 File Offset: 0x00638298
	public bool GetFloorIncludeRole(int roleId, int towerId)
	{
		TowerFloorInfo towerFloorInfo;
		if (!this.TowerInfoMap.TryGetValue(towerId, out towerFloorInfo))
		{
			return false;
		}
		if (towerFloorInfo.Formation == null)
		{
			return false;
		}
		for (int i = 0; i < towerFloorInfo.Formation.Count; i++)
		{
			if (towerFloorInfo.Formation[i].RoleId == roleId)
			{
				return true;
			}
		}
		return false;
	}

	// Token: 0x060166C2 RID: 91842 RVA: 0x0063A0F0 File Offset: 0x006382F0
	public void OpenTowerFormationView(int towerId)
	{
		this.CurrentSelectFloor = towerId;
		TowerConfig? towerInfo = ConfigBase<TowerClimbConfig>.Instance.GetTowerInfo(towerId);
		ControllerBase<EditBattleTeamController>.Instance.PlayerOpenEditBattleTeamView(towerInfo.Value.InstanceId, false, true, false, null);
	}

	// Token: 0x060166C3 RID: 91843 RVA: 0x0063A135 File Offset: 0x00638335
	public bool IsOpenFloorFormation()
	{
		return this.CurrentSelectFloor != -1;
	}

	// Token: 0x060166C4 RID: 91844 RVA: 0x0063A144 File Offset: 0x00638344
	public string GetCurrentFloorName()
	{
		string localTextNew = ConfigMultiTextLang.GetLocalTextNew(ConfigBase<TextConfig>.Instance.GetTextContentIdById("TowerAreaFloor"), null);
		TowerConfig value = ConfigBase<TowerClimbConfig>.Instance.GetTowerInfo(this.CurrentTowerId).Value;
		string localTextNew2 = ConfigMultiTextLang.GetLocalTextNew(value.AreaName, null);
		return localTextNew.Replace("{0}", localTextNew2).Replace("{1}", value.Floor.ToString() ?? "");
	}

	// Token: 0x060166C5 RID: 91845 RVA: 0x0063A1BC File Offset: 0x006383BC
	public List<int> GetFloorFormation(int towerId)
	{
		List<int> list = new List<int>();
		TowerFloorInfo towerFloorInfo;
		if (!this.TowerInfoMap.TryGetValue(towerId, out towerFloorInfo) || towerFloorInfo.Formation == null)
		{
			return list;
		}
		for (int i = 0; i < towerFloorInfo.Formation.Count; i++)
		{
			list.Add(towerFloorInfo.Formation[i].RoleId);
		}
		return list;
	}

	// Token: 0x060166C6 RID: 91846 RVA: 0x0063A217 File Offset: 0x00638417
	public void SaveNeedOpenConfirmView()
	{
		this.NeedOpenConfirmViewTowerId = this.CurrentTowerId;
		this.NeedOpenConfirmView = true;
	}

	// Token: 0x060166C7 RID: 91847 RVA: 0x0063A22C File Offset: 0x0063842C
	public void ClearNotConfirmedData()
	{
		this.NeedOpenConfirmViewTowerId = -1;
		this.NeedOpenConfirmView = false;
		this.CurrentNotConfirmedFloor = null;
	}

	// Token: 0x060166C8 RID: 91848 RVA: 0x0063A243 File Offset: 0x00638443
	public void OpenReviewView()
	{
		if (!this.NeedOpenReviveView)
		{
			return;
		}
		this.NeedOpenReviveView = false;
		if (this.GetDifficultyMaxStars(3, true) > 0)
		{
			Singleton<UiManager>.Instance.OpenView(EUiViewName.TowerReviewView, null, null);
		}
		this.DataSeason = this.CurrentSeason;
	}

	// Token: 0x060166C9 RID: 91849 RVA: 0x0063A27D File Offset: 0x0063847D
	public void SaveHandleData()
	{
		this.TowerInfoMapHandle = new Dictionary<int, TowerFloorInfo>(this.TowerInfoMap);
		this.TowerDifficultiesMaxStarMapHandle = new Dictionary<int, int>(this.TowerDifficultiesMaxStarMap);
		this.SeasonHandle = this.DataSeason;
	}

	// Token: 0x060166CA RID: 91850 RVA: 0x0063A2AD File Offset: 0x006384AD
	public void ClearHandleData()
	{
		Dictionary<int, TowerFloorInfo> towerInfoMapHandle = this.TowerInfoMapHandle;
		if (towerInfoMapHandle != null)
		{
			towerInfoMapHandle.Clear();
		}
		this.TowerInfoMapHandle = null;
		Dictionary<int, int> towerDifficultiesMaxStarMapHandle = this.TowerDifficultiesMaxStarMapHandle;
		if (towerDifficultiesMaxStarMapHandle != null)
		{
			towerDifficultiesMaxStarMapHandle.Clear();
		}
		this.TowerDifficultiesMaxStarMapHandle = null;
		this.SeasonHandle = -1;
	}

	// Token: 0x060166CB RID: 91851 RVA: 0x0063A2E6 File Offset: 0x006384E6
	public bool CheckInTower()
	{
		return this.CurrentTowerId != -1;
	}

	// Token: 0x060166CC RID: 91852 RVA: 0x0063A2F4 File Offset: 0x006384F4
	public CommonDefine.ICountDown GetSeasonCountDownData()
	{
		double num = (double)Singleton<MathUtils>.Instance.LongToNumber(this.TowerEndTime.GetValueOrDefault()) - Singleton<TimeUtil>.Instance.GetServerTime();
		if (num <= 1.0)
		{
			num = 1.0;
		}
		CommonDefine.ETimeType value = (num >= 86400.0) ? CommonDefine.ETimeType.Day : ((num >= 3600.0) ? CommonDefine.ETimeType.Hour : CommonDefine.ETimeType.Minute);
		CommonDefine.ETimeType value2 = (num >= 86400.0) ? CommonDefine.ETimeType.Hour : ((num >= 3600.0) ? CommonDefine.ETimeType.Minute : CommonDefine.ETimeType.Second);
		return Singleton<TimeUtil>.Instance.GetCountDownDataFormat2(num, new CommonDefine.ETimeType?(value), new CommonDefine.ETimeType?(value2));
	}

	// Token: 0x060166CD RID: 91853 RVA: 0x0063A390 File Offset: 0x00638590
	public bool CanGetReward()
	{
		List<TowerReward> difficultyReward = this.GetDifficultyReward(this.CurrentSelectDifficulties);
		if (difficultyReward == null)
		{
			return false;
		}
		int difficultyMaxStars = this.GetDifficultyMaxStars(this.CurrentSelectDifficulties, false);
		for (int i = 0; i < difficultyReward.Count; i++)
		{
			TowerReward towerReward = difficultyReward[i];
			if (difficultyMaxStars >= towerReward.Target)
			{
				bool? isReceived = towerReward.IsReceived;
				bool flag = false;
				if (isReceived.GetValueOrDefault() == flag & isReceived != null)
				{
					return true;
				}
			}
		}
		return false;
	}

	// Token: 0x060166CE RID: 91854 RVA: 0x0063A404 File Offset: 0x00638604
	public bool CanGetRewardByDifficulties(int difficultId)
	{
		List<TowerReward> difficultyReward = this.GetDifficultyReward(difficultId);
		if (difficultyReward == null)
		{
			return false;
		}
		int difficultyMaxStars = this.GetDifficultyMaxStars(difficultId, false);
		for (int i = 0; i < difficultyReward.Count; i++)
		{
			TowerReward towerReward = difficultyReward[i];
			if (difficultyMaxStars >= towerReward.Target)
			{
				bool? isReceived = towerReward.IsReceived;
				bool flag = false;
				if (isReceived.GetValueOrDefault() == flag & isReceived != null)
				{
					return true;
				}
			}
		}
		return false;
	}

	// Token: 0x060166CF RID: 91855 RVA: 0x0063A46C File Offset: 0x0063866C
	public bool CanGetRewardAllDifficulties()
	{
		for (int i = 1; i <= 3; i++)
		{
			List<TowerReward> difficultyReward = this.GetDifficultyReward(i);
			int difficultyMaxStars = this.GetDifficultyMaxStars(i, false);
			if (difficultyReward != null)
			{
				for (int j = 0; j < difficultyReward.Count; j++)
				{
					TowerReward towerReward = difficultyReward[j];
					if (difficultyMaxStars >= towerReward.Target)
					{
						bool? isReceived = towerReward.IsReceived;
						bool flag = false;
						if (isReceived.GetValueOrDefault() == flag & isReceived != null)
						{
							return true;
						}
					}
				}
			}
		}
		return false;
	}

	// Token: 0x060166D0 RID: 91856 RVA: 0x0063A4E4 File Offset: 0x006386E4
	public bool IsRewardAllFinished(int? difficultId = null)
	{
		int difficulty = difficultId ?? this.CurrentSelectDifficulties;
		List<TowerReward> difficultyReward = this.GetDifficultyReward(difficulty);
		if (difficultyReward == null)
		{
			return true;
		}
		for (int i = 0; i < difficultyReward.Count; i++)
		{
			bool? isReceived = difficultyReward[i].IsReceived;
			bool flag = false;
			if (isReceived.GetValueOrDefault() == flag & isReceived != null)
			{
				return false;
			}
		}
		return true;
	}

	// Token: 0x060166D1 RID: 91857 RVA: 0x0063A554 File Offset: 0x00638754
	public bool IsRoleCostEnough(int roleId)
	{
		TowerConfig? towerConfig;
		return this.GetFloorIncludeRole(roleId, this.CurrentSelectFloor) || this.GetRoleRemainCost(roleId, this.CurrentSelectDifficulties) >= ((ConfigBase<TowerClimbConfig>.Instance.GetTowerInfo(this.CurrentSelectFloor) != null) ? new int?(towerConfig.GetValueOrDefault().Cost) : null).GetValueOrDefault();
	}

	// Token: 0x060166D2 RID: 91858 RVA: 0x0063A5C8 File Offset: 0x006387C8
	public bool GetIsInOnceTower()
	{
		TowerConfig value = ConfigBase<TowerClimbConfig>.Instance.GetTowerInfo(this.CurrentTowerId).Value;
		return value.Difficulty == 1 || value.Difficulty == 2;
	}

	// Token: 0x060166D3 RID: 91859 RVA: 0x0063A608 File Offset: 0x00638808
	public float GetDifficultyRewardProgress(int difficulty)
	{
		List<TowerReward> difficultyReward = this.GetDifficultyReward(difficulty);
		int num = 0;
		for (int i = 0; i < ((difficultyReward != null) ? difficultyReward.Count : 0); i++)
		{
			if (difficultyReward[i].IsReceived.GetValueOrDefault())
			{
				num++;
			}
		}
		return (float)num / (float)((difficultyReward != null) ? difficultyReward.Count : 1);
	}

	// Token: 0x060166D4 RID: 91860 RVA: 0x0063A660 File Offset: 0x00638860
	public bool GetOverLockHasShow()
	{
		bool? flag = (ModelBase<ServerStorageModel>.Instance.Get(EClientStorageSystemIdType.TowerOverLockArea) as ServerStorageBoolean).Get();
		if (!flag.GetValueOrDefault())
		{
			flag = new bool?(LocalStorage.GetPlayer<bool>(ELocalStoragePlayerKey.TowerOverLockArea, false));
		}
		return flag.GetValueOrDefault();
	}

	// Token: 0x060166D5 RID: 91861 RVA: 0x0063A6A2 File Offset: 0x006388A2
	public void SetOverLockHasShow()
	{
		(ModelBase<ServerStorageModel>.Instance.Get(EClientStorageSystemIdType.TowerOverLockArea) as ServerStorageBoolean).Set(new bool?(true));
	}

	// Token: 0x060166D6 RID: 91862 RVA: 0x0063A6C0 File Offset: 0x006388C0
	public int GetLoopTowerIsClickSeason()
	{
		ServerStorageUtil.OverrideLocalNumberToServerNumber(ELocalStoragePlayerKey.LoopTowerIsClickSeason, EClientStorageSystemIdType.LoopTowerIsClickSeason);
		return (ModelBase<ServerStorageModel>.Instance.Get(EClientStorageSystemIdType.LoopTowerIsClickSeason) as ServerStorageNumber).Get().GetValueOrDefault(-1);
	}

	// Token: 0x060166D7 RID: 91863 RVA: 0x0063A6F4 File Offset: 0x006388F4
	public void SetLoopTowerIsClickSeason(int season)
	{
		(ModelBase<ServerStorageModel>.Instance.Get(EClientStorageSystemIdType.LoopTowerIsClickSeason) as ServerStorageNumber).Set(new int?(season));
		Singleton<EventSystem>.Instance.Emit(EEventName.RedDotAdventurePeriodicityTabUpdate);
		Singleton<EventSystem>.Instance.Emit<int>(EEventName.RefreshCommonActivityRedDot, 100300002);
	}

	// Token: 0x060166D8 RID: 91864 RVA: 0x0063A744 File Offset: 0x00638944
	public bool GetLoopTowerIsClickShop()
	{
		ServerStorageUtil.OverrideLocalBooleanToServerBoolean(ELocalStoragePlayerKey.LoopTowerIsClickShop, EClientStorageSystemIdType.LoopTowerIsClickShop);
		return (ModelBase<ServerStorageModel>.Instance.Get(EClientStorageSystemIdType.LoopTowerIsClickShop) as ServerStorageBoolean).Get().GetValueOrDefault();
	}

	// Token: 0x060166D9 RID: 91865 RVA: 0x0063A777 File Offset: 0x00638977
	public void SetLoopTowerIsClickShop(bool click)
	{
		(ModelBase<ServerStorageModel>.Instance.Get(EClientStorageSystemIdType.LoopTowerIsClickShop) as ServerStorageBoolean).Set(new bool?(click));
		Singleton<EventSystem>.Instance.Emit<int>(EEventName.RefreshCommonActivityRedDot, 100300002);
	}

	// Token: 0x060166DA RID: 91866 RVA: 0x0063A7AC File Offset: 0x006389AC
	[NullableContext(2)]
	public int[] GetRewardIdsByDifficulties(int difficultId, bool isCanReceive)
	{
		List<TowerReward> difficultyReward = this.GetDifficultyReward(difficultId);
		if (difficultyReward == null)
		{
			return null;
		}
		int difficultyMaxStars = this.GetDifficultyMaxStars(difficultId, false);
		List<int> list = new List<int>();
		for (int i = 0; i < difficultyReward.Count; i++)
		{
			TowerReward towerReward = difficultyReward[i];
			if (isCanReceive)
			{
				if (difficultyMaxStars >= towerReward.Target)
				{
					bool? isReceived = towerReward.IsReceived;
					bool flag = false;
					if (isReceived.GetValueOrDefault() == flag & isReceived != null)
					{
						list.Add(towerReward.RewardId);
					}
				}
			}
			else if (towerReward.IsReceived.GetValueOrDefault())
			{
				list.Add(towerReward.RewardId);
			}
		}
		return list.ToArray();
	}

	// Token: 0x060166DB RID: 91867 RVA: 0x0063A850 File Offset: 0x00638A50
	private void ReportPeriodicActivityRedAppear()
	{
		ActivityLoopTowerData activityLoopTowerData = ModelBase<ActivityModel>.Instance.GetActivityById(100300002) as ActivityLoopTowerData;
		if (activityLoopTowerData != null && activityLoopTowerData.RedPointShowState)
		{
			AdventureGuideModel instance = ModelBase<AdventureGuideModel>.Instance;
			if (instance == null)
			{
				return;
			}
			instance.ReportPeriodicActivityRedAppear(EDungeonSubType.LoopTower);
		}
	}

	// Token: 0x060166DC RID: 91868 RVA: 0x0063A890 File Offset: 0x00638A90
	private bool Contains(IList<int> list, int value)
	{
		for (int i = 0; i < list.Count; i++)
		{
			if (list[i] == value)
			{
				return true;
			}
		}
		return false;
	}

	// Token: 0x0400AD92 RID: 44434
	public const int FLOOR_STAR = 3;

	// Token: 0x0400AD93 RID: 44435
	public const string FINISH_COLOR = "#FFD12F";

	// Token: 0x0400AD94 RID: 44436
	public const string NORMOL_COLOR = "#ECE5D8";

	// Token: 0x0400AD95 RID: 44437
	public const string LOCK_COLOR = "#ADADAD";

	// Token: 0x0400AD96 RID: 44438
	public const int TOWER_LOOP_ACTIVITY_ID = 100300002;

	// Token: 0x0400AD97 RID: 44439
	public long? TowerBeginTime;

	// Token: 0x0400AD98 RID: 44440
	public long? TowerEndTime;

	// Token: 0x0400AD99 RID: 44441
	public int CurrentSeason = -1;

	// Token: 0x0400AD9A RID: 44442
	public int DataSeason;

	// Token: 0x0400AD9B RID: 44443
	public int CurrentSelectDifficulties = -1;

	// Token: 0x0400AD9C RID: 44444
	public int CurrentTowerId = -1;

	// Token: 0x0400AD9D RID: 44445
	[Nullable(2)]
	public List<int> CurrentTowerFormation;

	// Token: 0x0400AD9E RID: 44446
	public bool NeedChangeFormation;

	// Token: 0x0400AD9F RID: 44447
	[Nullable(2)]
	public TowerFloorInfo CurrentNotConfirmedFloor;

	// Token: 0x0400ADA0 RID: 44448
	public int NeedOpenConfirmViewTowerId = -1;

	// Token: 0x0400ADA1 RID: 44449
	public bool NeedOpenConfirmView;

	// Token: 0x0400ADA2 RID: 44450
	public int CurrentSelectFloor = -1;

	// Token: 0x0400ADA3 RID: 44451
	public Dictionary<int, Dictionary<int, int>> RoleDifficultyFormationMap = new Dictionary<int, Dictionary<int, int>>();

	// Token: 0x0400ADA4 RID: 44452
	[Nullable(new byte[]
	{
		2,
		1
	})]
	public TowerRecommendFormation[] RecommendFormation;

	// Token: 0x0400ADA5 RID: 44453
	public bool CurrentTowerLock;

	// Token: 0x0400ADA6 RID: 44454
	public int DefaultFloor = -1;

	// Token: 0x0400ADA7 RID: 44455
	private int MaxRoleCost;

	// Token: 0x0400ADA8 RID: 44456
	public int TowerGuideDelayTime;

	// Token: 0x0400ADA9 RID: 44457
	public int TowerSettlementDelayTime;

	// Token: 0x0400ADAA RID: 44458
	private readonly Dictionary<int, TowerFloorInfo> TowerInfoMap = new Dictionary<int, TowerFloorInfo>();

	// Token: 0x0400ADAB RID: 44459
	[Nullable(new byte[]
	{
		2,
		1
	})]
	private Dictionary<int, TowerFloorInfo> TowerInfoMapHandle;

	// Token: 0x0400ADAC RID: 44460
	private int SeasonHandle = -1;

	// Token: 0x0400ADAD RID: 44461
	private readonly Dictionary<int, List<TowerReward>> TowerDifficultiesRewardMap = new Dictionary<int, List<TowerReward>>();

	// Token: 0x0400ADAE RID: 44462
	private readonly Dictionary<int, int> TowerDifficultiesMaxStarMap = new Dictionary<int, int>();

	// Token: 0x0400ADAF RID: 44463
	[Nullable(2)]
	private Dictionary<int, int> TowerDifficultiesMaxStarMapHandle;

	// Token: 0x0400ADB0 RID: 44464
	public bool NeedOpenReviveView;

	// Token: 0x0400ADB1 RID: 44465
	public int MaxUnlockDifficulty;

	// Token: 0x0400ADB2 RID: 44466
	public int QuickPassId;

	// Token: 0x0400ADB3 RID: 44467
	public bool IsWaitTowerStart;

	// Token: 0x0400ADB4 RID: 44468
	public bool IsWaitTowerSettlement;
}
