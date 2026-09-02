using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using Aki.Config;
using Aki.Protocol;
using CSharpScript.Game.Module.Activity.ActivityContent.WheelTower;
using CSharpScript.Game.ServerStorage;
using CSharpScript.Game.ServerStorage.Container;

// Token: 0x0200170C RID: 5900
[NullableContext(1)]
[Nullable(new byte[]
{
	0,
	1
})]
[Model(0)]
public class WheelTowerModel : ModelBase<WheelTowerModel>
{
	// Token: 0x0600A3A6 RID: 41894 RVA: 0x002B3E3D File Offset: 0x002B203D
	protected override bool OnInit()
	{
		this.BuildRoleData();
		return true;
	}

	// Token: 0x0600A3A7 RID: 41895 RVA: 0x002B3E46 File Offset: 0x002B2046
	protected override bool OnClear()
	{
		this.ClearRoleData();
		return true;
	}

	// Token: 0x0600A3A8 RID: 41896 RVA: 0x002B3E4F File Offset: 0x002B204F
	public void SetActivityId(int id)
	{
		this.ActivityDataIdInternal = id;
	}

	// Token: 0x17000D98 RID: 3480
	// (get) Token: 0x0600A3A9 RID: 41897 RVA: 0x002B3E58 File Offset: 0x002B2058
	public WheelTowerData ActivityData
	{
		get
		{
			return ModelBase<ActivityModel>.Instance.GetActivityById(this.ActivityDataIdInternal) as WheelTowerData;
		}
	}

	// Token: 0x0600A3AA RID: 41898 RVA: 0x002B3E70 File Offset: 0x002B2070
	public NewTowerParam GetTowerConfig()
	{
		return ConfigBase<WheelTowerConfig>.Instance.GetTowerConfig(this.ActivityData.CycleId).Value;
	}

	// Token: 0x0600A3AB RID: 41899 RVA: 0x002B3E9C File Offset: 0x002B209C
	public int GetTeamMaxRoleCount()
	{
		return this.GetTowerConfig().RoleCount;
	}

	// Token: 0x0600A3AC RID: 41900 RVA: 0x002B3EB8 File Offset: 0x002B20B8
	public int GetRoleCost(int roleId)
	{
		if (this.RoleCostMap == null)
		{
			this.RoleCostMap = new Dictionary<int, int>();
			foreach (DicIntInt dicIntInt in this.GetTowerConfig().CostEnergyIter())
			{
				this.RoleCostMap[dicIntInt.Key] = dicIntInt.Value;
			}
			this.DefaultRoleCost = this.GetTowerConfig().DefaultCostEnergy;
		}
		return this.RoleCostMap.GetValueOrDefault(roleId, this.DefaultRoleCost);
	}

	// Token: 0x0600A3AD RID: 41901 RVA: 0x002B3F58 File Offset: 0x002B2158
	public CommonDefine.ICountDown GetSeasonCountDownData()
	{
		long endOpenTime = this.ActivityData.EndOpenTime;
		double num = (double)Singleton<MathUtils>.Instance.LongToNumber(endOpenTime) - Singleton<TimeUtil>.Instance.GetServerTime();
		if (num <= 1.0)
		{
			num = 1.0;
		}
		CommonDefine.ETimeType value = (num >= 86400.0) ? CommonDefine.ETimeType.Day : ((num >= 3600.0) ? CommonDefine.ETimeType.Hour : CommonDefine.ETimeType.Minute);
		CommonDefine.ETimeType value2 = (num >= 86400.0) ? CommonDefine.ETimeType.Hour : ((num >= 3600.0) ? CommonDefine.ETimeType.Minute : CommonDefine.ETimeType.Second);
		return Singleton<TimeUtil>.Instance.GetCountDownDataFormat2(num, new CommonDefine.ETimeType?(value), new CommonDefine.ETimeType?(value2));
	}

	// Token: 0x0600A3AE RID: 41902 RVA: 0x002B3FF6 File Offset: 0x002B21F6
	public NewTowerClimbingLevelRecord GetCurrentLevelRecord(bool? endless = null)
	{
		if (endless == null)
		{
			return this.ActivityData.GetLevelRecord(this.EndlessMode);
		}
		return this.ActivityData.GetLevelRecord(endless.Value);
	}

	// Token: 0x0600A3AF RID: 41903 RVA: 0x002B4025 File Offset: 0x002B2225
	public int GetTotalScore()
	{
		return this.ActivityData.GetTotalScore(this.EndlessMode);
	}

	// Token: 0x0600A3B0 RID: 41904 RVA: 0x002B4038 File Offset: 0x002B2238
	public int GetBestTotalScore()
	{
		return this.ActivityData.GetHistoryBestScore(this.EndlessMode);
	}

	// Token: 0x0600A3B1 RID: 41905 RVA: 0x002B404C File Offset: 0x002B224C
	public List<int> GetLevelBuffList()
	{
		int levelId = this.GetCurrentLevelRecord(null).LevelId;
		return ConfigBase<WheelTowerConfig>.Instance.GetLevelConfigById(levelId).Value.GetNewTowerBuffsArray().ToList<int>();
	}

	// Token: 0x0600A3B2 RID: 41906 RVA: 0x002B4090 File Offset: 0x002B2290
	public int GetLevelCanSelectBuffCount()
	{
		int levelId = this.GetCurrentLevelRecord(null).LevelId;
		return ConfigBase<WheelTowerConfig>.Instance.GetLevelConfigById(levelId).Value.NewTowerBuffCount;
	}

	// Token: 0x0600A3B3 RID: 41907 RVA: 0x002B40D0 File Offset: 0x002B22D0
	public bool IsLevelCompleted(bool endless)
	{
		if (endless)
		{
			return false;
		}
		MonsterInfoPreview nextMonsterInfoPreview = this.ActivityData.GetLevelRecord(false).NextMonsterInfoPreview;
		return nextMonsterInfoPreview != null && this.GetBossHpPercentage(nextMonsterInfoPreview) <= 0.0;
	}

	// Token: 0x0600A3B4 RID: 41908 RVA: 0x002B410C File Offset: 0x002B230C
	public int GetLastChallengeRound(bool? endless = null)
	{
		return this.GetCurrentLevelRecord(endless).TeamChallengeInfos.Count - 1;
	}

	// Token: 0x0600A3B5 RID: 41909 RVA: 0x002B4124 File Offset: 0x002B2324
	public bool IsRoundChallenged(int round, bool? endless = null)
	{
		int lastChallengeRound = this.GetLastChallengeRound(endless);
		return lastChallengeRound != -1 && round <= lastChallengeRound;
	}

	// Token: 0x0600A3B6 RID: 41910 RVA: 0x002B4144 File Offset: 0x002B2344
	public bool IsTeamRoundCanChallenge(int round)
	{
		if (this.IsRoundChallenged(round, null))
		{
			return true;
		}
		int maxChallengeRound = this.GetMaxChallengeRound(null);
		return round <= maxChallengeRound;
	}

	// Token: 0x0600A3B7 RID: 41911 RVA: 0x002B417C File Offset: 0x002B237C
	public bool HasChallengeAnyRound(bool? isEndless = null)
	{
		return this.GetLastChallengeRound(isEndless) >= 0;
	}

	// Token: 0x0600A3B8 RID: 41912 RVA: 0x002B418C File Offset: 0x002B238C
	public int GetMaxChallengeRound(bool? isEndless = null)
	{
		int lastChallengeRound = this.GetLastChallengeRound(isEndless);
		if (this.IsLastRound(lastChallengeRound, isEndless))
		{
			return lastChallengeRound;
		}
		return lastChallengeRound + 1;
	}

	// Token: 0x0600A3B9 RID: 41913 RVA: 0x002B41B0 File Offset: 0x002B23B0
	public bool IsLastRound(int round, bool? isEndless = null)
	{
		bool flag = isEndless ?? this.EndlessMode;
		if (flag)
		{
			return false;
		}
		int lastChallengeRound = this.GetLastChallengeRound(new bool?(flag));
		if (lastChallengeRound < 0 || round < lastChallengeRound)
		{
			return false;
		}
		NewTowerClimbingLevelRecord currentLevelRecord = this.GetCurrentLevelRecord(null);
		int num = -1;
		List<IBossInfo> roundBossInfo = this.GetRoundBossInfo(round, null);
		for (int i = 0; i < roundBossInfo.Count; i++)
		{
			if (roundBossInfo[i].HpPercentage > 0.0)
			{
				num = i;
				break;
			}
		}
		return num < 0 || this.IsLastRoundCheckLimit(currentLevelRecord.LevelId, round);
	}

	// Token: 0x0600A3BA RID: 41914 RVA: 0x002B4264 File Offset: 0x002B2464
	public bool IsLastRoundCheckLimit(int levelId, int round)
	{
		int teamLimit = ConfigBase<WheelTowerConfig>.Instance.GetLevelConfigById(levelId).Value.TeamLimit;
		return teamLimit != 0 && round == teamLimit - 1;
	}

	// Token: 0x0600A3BB RID: 41915 RVA: 0x002B4298 File Offset: 0x002B2498
	public int GetRoundBossRound(int round)
	{
		NewTowerClimbingLevelRecord currentLevelRecord = this.GetCurrentLevelRecord(null);
		MonsterInfoPreview monsterInfoPreview;
		if (!this.IsRoundChallenged(round, null))
		{
			monsterInfoPreview = currentLevelRecord.NextMonsterInfoPreview;
		}
		else
		{
			monsterInfoPreview = currentLevelRecord.TeamChallengeInfos[round].LastMonsterInfoPreview;
		}
		return monsterInfoPreview.Round;
	}

	// Token: 0x0600A3BC RID: 41916 RVA: 0x002B42EC File Offset: 0x002B24EC
	public MonsterInfoPreview GetBossInfoByRound(int round, bool? isEndless = null)
	{
		NewTowerClimbingLevelRecord currentLevelRecord = this.GetCurrentLevelRecord(isEndless);
		MonsterInfoPreview result;
		if (!this.IsRoundChallenged(round, isEndless))
		{
			result = currentLevelRecord.NextMonsterInfoPreview;
		}
		else
		{
			result = currentLevelRecord.TeamChallengeInfos[round].LastMonsterInfoPreview;
		}
		return result;
	}

	// Token: 0x0600A3BD RID: 41917 RVA: 0x002B432C File Offset: 0x002B252C
	public MonsterInfoPreview GetLastBossInfo(bool isEndless)
	{
		int lastChallengeRound = this.GetLastChallengeRound(new bool?(isEndless));
		return this.GetBossInfoByRound(lastChallengeRound, new bool?(isEndless));
	}

	// Token: 0x0600A3BE RID: 41918 RVA: 0x002B4354 File Offset: 0x002B2554
	public List<IBossInfo> GetRoundBossInfo(int round, bool? isEndless = null)
	{
		NewTowerClimbingLevelRecord currentLevelRecord = this.GetCurrentLevelRecord(isEndless);
		MonsterInfoPreview monsterInfoPreview;
		if (!this.IsRoundChallenged(round, isEndless))
		{
			monsterInfoPreview = currentLevelRecord.NextMonsterInfoPreview;
		}
		else
		{
			monsterInfoPreview = currentLevelRecord.TeamChallengeInfos[round].LastMonsterInfoPreview;
		}
		int waveConfigId = monsterInfoPreview.WaveConfigId;
		int round2 = monsterInfoPreview.Round;
		double bossHpPercentage = this.GetBossHpPercentage(monsterInfoPreview);
		List<int> waveBatch = this.GetWaveBatch(currentLevelRecord.LevelId, waveConfigId);
		int num = -1;
		for (int i = 0; i < waveBatch.Count; i++)
		{
			if (waveBatch[i] == waveConfigId)
			{
				num = i;
				break;
			}
		}
		List<IBossInfo> list = new List<IBossInfo>();
		for (int j = 0; j < waveBatch.Count; j++)
		{
			double hpPercentage = 0.0;
			if (j == num)
			{
				hpPercentage = bossHpPercentage;
			}
			else if (j > num)
			{
				hpPercentage = 100.0;
			}
			int waveConfigId2 = waveBatch[j];
			list.Add(new BossInfo
			{
				WaveConfigId = waveConfigId2,
				Round = round2,
				HpPercentage = hpPercentage
			});
		}
		return list;
	}

	// Token: 0x0600A3BF RID: 41919 RVA: 0x002B4458 File Offset: 0x002B2658
	public int GetCurrentWaveId(int? round = null, bool? isEndless = null)
	{
		NewTowerClimbingLevelRecord currentLevelRecord = this.GetCurrentLevelRecord(isEndless);
		int num = round ?? this.SelectedRound;
		MonsterInfoPreview monsterInfoPreview;
		if (!this.IsRoundChallenged(num, null))
		{
			monsterInfoPreview = currentLevelRecord.NextMonsterInfoPreview;
		}
		else
		{
			monsterInfoPreview = currentLevelRecord.TeamChallengeInfos[num].LastMonsterInfoPreview;
		}
		return monsterInfoPreview.WaveConfigId;
	}

	// Token: 0x0600A3C0 RID: 41920 RVA: 0x002B44C0 File Offset: 0x002B26C0
	[NullableContext(0)]
	public ValueTuple<int, int> GetBossProgress(int round, bool? isEndless = null)
	{
		List<IBossInfo> roundBossInfo = this.GetRoundBossInfo(round, isEndless);
		int num = 0;
		for (int i = 0; i < roundBossInfo.Count; i++)
		{
			if (roundBossInfo[i].HpPercentage <= 0.0)
			{
				num++;
			}
		}
		return new ValueTuple<int, int>((num == roundBossInfo.Count) ? num : (num + 1), roundBossInfo.Count);
	}

	// Token: 0x0600A3C1 RID: 41921 RVA: 0x002B4520 File Offset: 0x002B2720
	public List<IBossInfo> GetTeamKillBossInfo(int teamRound, bool? isEndlessMode = null)
	{
		bool flag = isEndlessMode ?? this.EndlessMode;
		NewTowerClimbingLevelRecord currentLevelRecord = this.GetCurrentLevelRecord(new bool?(flag));
		IReadOnlyList<NewTowerWave> waveConfigListByLevelId = ConfigBase<WheelTowerConfig>.Instance.GetWaveConfigListByLevelId(currentLevelRecord.LevelId);
		MonsterInfoPreview bossInfoByRound = this.GetBossInfoByRound(teamRound, new bool?(flag));
		MonsterInfoPreview monsterInfoPreview = null;
		int num = waveConfigListByLevelId[0].Id;
		double num2 = 0.0;
		if (teamRound > 0)
		{
			monsterInfoPreview = this.GetBossInfoByRound(teamRound - 1, new bool?(flag));
			num = monsterInfoPreview.WaveConfigId;
			num2 = Singleton<MathUtils>.Instance.GetRoundToNDecimalPlaces(this.GetBossHpPercentage(monsterInfoPreview), 2);
		}
		List<IBossInfo> list = new List<IBossInfo>();
		int num3 = -1;
		int num4 = -1;
		if (flag)
		{
			for (int i = 0; i < waveConfigListByLevelId.Count; i++)
			{
				if (waveConfigListByLevelId[i].Round == 3)
				{
					num3 = waveConfigListByLevelId[i].Id;
					break;
				}
			}
			for (int j = waveConfigListByLevelId.Count - 1; j >= 0; j--)
			{
				if (waveConfigListByLevelId[j].Round == 3)
				{
					num4 = waveConfigListByLevelId[j].Id;
					break;
				}
			}
		}
		int num5 = num;
		int num6 = (monsterInfoPreview != null) ? monsterInfoPreview.Round : waveConfigListByLevelId[0].Round;
		for (;;)
		{
			NewTowerWave? waveConfigById = ConfigBase<WheelTowerConfig>.Instance.GetWaveConfigById(num5);
			num6 = ((num6 <= 3) ? waveConfigById.Value.Round : num6);
			double num7 = 0.0;
			double value = 100.0;
			if (num5 == num && monsterInfoPreview != null && num6 == monsterInfoPreview.Round)
			{
				value = num2;
			}
			bool flag2 = num5 == bossInfoByRound.WaveConfigId && num6 == bossInfoByRound.Round;
			if (flag2)
			{
				num7 = this.GetBossHpPercentage(bossInfoByRound);
				value = Singleton<MathUtils>.Instance.GetRoundToNDecimalPlaces(100.0 - num7, 2);
			}
			if (waveConfigById.Value.IsShowInView)
			{
				list.Add(new BossInfo
				{
					WaveConfigId = num5,
					Round = num6,
					HpPercentage = num7,
					LoseHpPercentage = new double?(value)
				});
			}
			if (flag2)
			{
				break;
			}
			if (num4 != -1 && num5 == num4)
			{
				num5 = num3;
				num6++;
			}
			else
			{
				num5++;
			}
		}
		return list;
	}

	// Token: 0x0600A3C2 RID: 41922 RVA: 0x002B477C File Offset: 0x002B297C
	public List<IBossInfo> GetPrevRoundBossInfo(int round)
	{
		List<IBossInfo> roundBossInfo = this.GetRoundBossInfo(round, null);
		if (round == 0)
		{
			for (int i = 0; i < roundBossInfo.Count; i++)
			{
				roundBossInfo[i].HpPercentage = 100.0;
			}
			return roundBossInfo;
		}
		List<IBossInfo> roundBossInfo2 = this.GetRoundBossInfo(round - 1, null);
		int round2 = roundBossInfo[0].Round;
		int round3 = roundBossInfo2[0].Round;
		if (round2 == round3)
		{
			return roundBossInfo2;
		}
		for (int j = 0; j < roundBossInfo.Count; j++)
		{
			roundBossInfo[j].HpPercentage = 100.0;
		}
		return roundBossInfo;
	}

	// Token: 0x0600A3C3 RID: 41923 RVA: 0x002B4828 File Offset: 0x002B2A28
	public double GetRecordPrevBossHpPercentage(int round, int waveConfigId, int bossRound)
	{
		NewTowerClimbingLevelRecord currentLevelRecord = this.GetCurrentLevelRecord(null);
		for (int i = Math.Min(round, currentLevelRecord.TeamChallengeInfos.Count); i >= 0; i--)
		{
			MonsterInfoPreview lastMonsterInfoPreview = currentLevelRecord.TeamChallengeInfos[i].LastMonsterInfoPreview;
			if (lastMonsterInfoPreview != null && lastMonsterInfoPreview.WaveConfigId == waveConfigId && lastMonsterInfoPreview != null && lastMonsterInfoPreview.Round == bossRound)
			{
				return this.GetBossHpPercentage(lastMonsterInfoPreview);
			}
		}
		return 100.0;
	}

	// Token: 0x0600A3C4 RID: 41924 RVA: 0x002B489C File Offset: 0x002B2A9C
	public double GetBossHpPercentage(MonsterInfoPreview bossPreview)
	{
		if (bossPreview.IsDead)
		{
			return 0.0;
		}
		double num = (double)bossPreview.HpPpb;
		return Singleton<MathUtils>.Instance.Clamp(num / 100.0, 0.01, 100.0);
	}

	// Token: 0x0600A3C5 RID: 41925 RVA: 0x002B48EC File Offset: 0x002B2AEC
	public List<int> GetWaveBatch(int levelId, int waveConfigId)
	{
		int round = ConfigBase<WheelTowerConfig>.Instance.GetWaveConfigById(waveConfigId).Value.Round;
		IEnumerable<NewTowerWave> waveConfigListByLevelId = ConfigBase<WheelTowerConfig>.Instance.GetWaveConfigListByLevelId(levelId);
		List<int> list = new List<int>();
		foreach (NewTowerWave newTowerWave in waveConfigListByLevelId)
		{
			if (newTowerWave.Round == round && newTowerWave.IsShowInView)
			{
				list.Add(newTowerWave.Id);
			}
		}
		return list;
	}

	// Token: 0x0600A3C6 RID: 41926 RVA: 0x002B4980 File Offset: 0x002B2B80
	public List<int> GetRoundSelectBuffList(int round)
	{
		return this.GetCurrentLevelRecord(null).TeamChallengeInfos[round].BuffIds.ToList<int>();
	}

	// Token: 0x0600A3C7 RID: 41927 RVA: 0x002B49B4 File Offset: 0x002B2BB4
	public List<int> GetRoundSelectRoleIdList(int round)
	{
		NewTowerClimbingLevelRecord currentLevelRecord = this.GetCurrentLevelRecord(null);
		List<int> list = new List<int>();
		foreach (RoleSaveInfo roleSaveInfo in currentLevelRecord.TeamChallengeInfos[round].RoleSaveInfos)
		{
			list.Add(roleSaveInfo.RoleId);
		}
		return list;
	}

	// Token: 0x0600A3C8 RID: 41928 RVA: 0x002B4A28 File Offset: 0x002B2C28
	public int GetRoundScore(int round)
	{
		return this.ActivityData.GetRoundScore(this.EndlessMode, round);
	}

	// Token: 0x0600A3C9 RID: 41929 RVA: 0x002B4A3C File Offset: 0x002B2C3C
	public int GetRoundTotalScore(int round)
	{
		return this.ActivityData.GetRoundTotalScore(this.EndlessMode, round);
	}

	// Token: 0x0600A3CA RID: 41930 RVA: 0x002B4A50 File Offset: 0x002B2C50
	public int GetSelectedRoundTotalScore()
	{
		return this.GetRoundTotalScore(this.SelectedRound);
	}

	// Token: 0x0600A3CB RID: 41931 RVA: 0x002B4A5E File Offset: 0x002B2C5E
	public void SetEndlessMode(bool endless)
	{
		if (this.EndlessMode == endless)
		{
			return;
		}
		this.EndlessMode = endless;
		this.ResetSelectedData();
	}

	// Token: 0x0600A3CC RID: 41932 RVA: 0x002B4A78 File Offset: 0x002B2C78
	public void UpdateSelectRound(int round, bool force = false)
	{
		if (this.SelectedRound == round && !force)
		{
			return;
		}
		this.ResetSelectedData();
		this.SelectedEnergyInfo = this.ActivityData.GetRoundEnergyInfo(this.EndlessMode, round);
		this.SelectedRound = round;
		if (this.IsRoundChallenged(round, null))
		{
			this.SelectedBuff = this.GetRoundSelectBuffList(round)[0];
			this.SelectedRoleList = this.GetRoundSelectRoleIdList(round);
		}
	}

	// Token: 0x0600A3CD RID: 41933 RVA: 0x002B4AE9 File Offset: 0x002B2CE9
	public void ResetSelectedData()
	{
		this.SelectedRound = -1;
		this.SelectedBuff = -1;
		this.SelectedRoleList.Clear();
	}

	// Token: 0x0600A3CE RID: 41934 RVA: 0x002B4B04 File Offset: 0x002B2D04
	public bool CheckSelectTeamIsFull()
	{
		return this.SelectedRoleList.Count >= this.GetTeamMaxRoleCount();
	}

	// Token: 0x0600A3CF RID: 41935 RVA: 0x002B4B1C File Offset: 0x002B2D1C
	public bool CheckSelectedRoleEnergyEnough()
	{
		CSharpScript.Game.Module.Activity.ActivityContent.WheelTower.EnergyInfo selectedEnergyInfo = this.SelectedEnergyInfo;
		for (int i = 0; i < this.SelectedRoleList.Count; i++)
		{
			int roleId = this.SelectedRoleList[i];
			if (selectedEnergyInfo.GetRoleEnergy(roleId) <= 0)
			{
				return false;
			}
		}
		return true;
	}

	// Token: 0x0600A3D0 RID: 41936 RVA: 0x002B4B60 File Offset: 0x002B2D60
	public bool CheckBuffIsSelected()
	{
		return this.SelectedBuff > 0;
	}

	// Token: 0x0600A3D1 RID: 41937 RVA: 0x002B4B6B File Offset: 0x002B2D6B
	public bool CheckSelectedIsConflict()
	{
		return this.CheckCurrentSelectConflict().Count != 0;
	}

	// Token: 0x0600A3D2 RID: 41938 RVA: 0x002B4B7B File Offset: 0x002B2D7B
	public List<IConflictInfo> CheckCurrentSelectConflict()
	{
		return this.CheckConflictList(this.SelectedRoleList);
	}

	// Token: 0x0600A3D3 RID: 41939 RVA: 0x002B4B8C File Offset: 0x002B2D8C
	public List<IConflictInfo> CheckConflictList(List<int> roleIdList)
	{
		List<IConflictInfo> list = new List<IConflictInfo>();
		for (int i = 0; i < roleIdList.Count; i++)
		{
			int roleId = roleIdList[i];
			IConflictInfo conflictInfo = this.CheckConflict(roleId);
			if (conflictInfo != null)
			{
				list.Add(conflictInfo);
			}
		}
		return list;
	}

	// Token: 0x0600A3D4 RID: 41940 RVA: 0x002B4BCC File Offset: 0x002B2DCC
	[NullableContext(2)]
	public IConflictInfo CheckConflict(int roleId)
	{
		if (roleId <= 0)
		{
			return null;
		}
		if (this.IsTemplateRole(roleId))
		{
			return null;
		}
		CSharpScript.Game.Module.Activity.ActivityContent.WheelTower.EnergyInfo selectedEnergyInfo = this.SelectedEnergyInfo;
		IRoleInfo roleInfo = this.GetRoleInfo(roleId);
		bool flag = !selectedEnergyInfo.GetWeaponCanUse(roleInfo.Weapon, roleId);
		bool flag2 = false;
		foreach (int phantomIncId in roleInfo.Phantom)
		{
			if (!selectedEnergyInfo.GetPhantomCanUse(phantomIncId, roleId))
			{
				flag2 = true;
				break;
			}
		}
		if (flag || flag2)
		{
			return new ConflictInfo
			{
				RoleId = roleId,
				WeaponConflict = flag,
				PhantomConflict = flag2
			};
		}
		return null;
	}

	// Token: 0x0600A3D5 RID: 41941 RVA: 0x002B4C80 File Offset: 0x002B2E80
	public int GetConflictWeaponRoleId(int roleId)
	{
		int value = (ModelBase<WeaponModel>.Instance.GetWeaponDataByRoleDataId(roleId, true) as WeaponInstance).GetIncId().Value;
		return this.SelectedEnergyInfo.GetWeaponOccupyRoleId(value, roleId);
	}

	// Token: 0x0600A3D6 RID: 41942 RVA: 0x002B4CBC File Offset: 0x002B2EBC
	public IRoleInfo GetRoleInfo(int roleId)
	{
		int value = (ModelBase<WeaponModel>.Instance.GetWeaponDataByRoleDataId(roleId, true) as WeaponInstance).GetIncId().Value;
		List<int> phantom = new List<int>(ModelBase<PhantomBattleModel>.Instance.GetBattleDataById(roleId).GetIncrIdList());
		return new CSharpScript.Game.Module.Activity.ActivityContent.WheelTower.RoleInfo
		{
			RoleId = roleId,
			Weapon = value,
			Phantom = phantom
		};
	}

	// Token: 0x0600A3D7 RID: 41943 RVA: 0x002B4D18 File Offset: 0x002B2F18
	public void TmpToSelect()
	{
		this.SelectedRoleList.Clear();
		List<int> list = new List<int>();
		for (int i = 0; i < this.GetTeamMaxRoleCount(); i++)
		{
			int item;
			if (this.TmpSelectedRoleMap.TryGetValue(i, out item))
			{
				list.Add(item);
			}
		}
		this.SelectedRoleList.AddRange(list);
	}

	// Token: 0x0600A3D8 RID: 41944 RVA: 0x002B4D6C File Offset: 0x002B2F6C
	public void SelectToTmp()
	{
		this.TmpSelectedRoleMap.Clear();
		for (int i = 0; i < this.SelectedRoleList.Count; i++)
		{
			int value = this.SelectedRoleList[i];
			this.TmpSelectedRoleMap[i] = value;
		}
	}

	// Token: 0x0600A3D9 RID: 41945 RVA: 0x002B4DB4 File Offset: 0x002B2FB4
	public void SetTmpSelectRoleList(List<int> roleList)
	{
		this.TmpSelectedRoleMap.Clear();
		for (int i = 0; i < roleList.Count; i++)
		{
			this.TmpSelectedRoleMap[i] = roleList[i];
		}
	}

	// Token: 0x0600A3DA RID: 41946 RVA: 0x002B4DF0 File Offset: 0x002B2FF0
	public void TryAddOrDeleteRole(int roleId)
	{
		int roleSlot = this.GetRoleSlot(roleId);
		if (roleSlot != -1)
		{
			this.TmpSelectedRoleMap.Remove(roleSlot);
			return;
		}
		int firstEmptySlot = this.GetFirstEmptySlot();
		if (firstEmptySlot >= 0)
		{
			this.TmpSelectedRoleMap[firstEmptySlot] = roleId;
			return;
		}
		ControllerBase<ScrollingTipsController>.Instance.ShowTipsByTextId("WheelTower_TeamSelectFullTips", Array.Empty<object>());
	}

	// Token: 0x0600A3DB RID: 41947 RVA: 0x002B4E44 File Offset: 0x002B3044
	public int GetRoleSlot(int roleId)
	{
		if (roleId <= 0)
		{
			return -1;
		}
		for (int i = 0; i < this.GetTeamMaxRoleCount(); i++)
		{
			int num;
			if (this.TmpSelectedRoleMap.TryGetValue(i, out num) && num == roleId)
			{
				return i;
			}
		}
		return -1;
	}

	// Token: 0x0600A3DC RID: 41948 RVA: 0x002B4E7F File Offset: 0x002B307F
	public bool IsSelectRole(int roleId)
	{
		return this.GetRoleSlot(roleId) >= 0;
	}

	// Token: 0x0600A3DD RID: 41949 RVA: 0x002B4E8E File Offset: 0x002B308E
	public bool IsTempHasAnyEmptySlot()
	{
		return this.GetFirstEmptySlot() >= 0;
	}

	// Token: 0x0600A3DE RID: 41950 RVA: 0x002B4E9C File Offset: 0x002B309C
	private int GetFirstEmptySlot()
	{
		for (int i = 0; i < this.GetTeamMaxRoleCount(); i++)
		{
			if (!this.TmpSelectedRoleMap.ContainsKey(i))
			{
				return i;
			}
		}
		return -1;
	}

	// Token: 0x0600A3DF RID: 41951 RVA: 0x002B4ECC File Offset: 0x002B30CC
	[NullableContext(2)]
	public IWheelTowerCoverRecordViewData GetRecordPopupData()
	{
		IWheelTowerCoverRecordViewData result;
		if (!this.LevelRecordPopupDataMap.TryGetValue(this.EndlessMode, out result))
		{
			return null;
		}
		return result;
	}

	// Token: 0x0600A3E0 RID: 41952 RVA: 0x002B4EF1 File Offset: 0x002B30F1
	public void SetRecordPopupData(IWheelTowerCoverRecordViewData data)
	{
		this.LevelRecordPopupDataMap[this.EndlessMode] = data;
	}

	// Token: 0x0600A3E1 RID: 41953 RVA: 0x002B4F05 File Offset: 0x002B3105
	public void DeleteRecordPopupData()
	{
		this.LevelRecordPopupDataMap.Remove(this.EndlessMode);
	}

	// Token: 0x0600A3E2 RID: 41954 RVA: 0x002B4F1C File Offset: 0x002B311C
	public string GetScoreResourceIdByLevel(EScoreLevel level)
	{
		string result;
		if (!WheelTowerDefine.LevelItemMappingTable.TryGetValue(level, out result))
		{
			return "";
		}
		return result;
	}

	// Token: 0x0600A3E3 RID: 41955 RVA: 0x002B4F3F File Offset: 0x002B313F
	public EScoreLevel GetRoundScoreLevel(int score)
	{
		return EScoreLevel.None;
	}

	// Token: 0x0600A3E4 RID: 41956 RVA: 0x002B4F44 File Offset: 0x002B3144
	public EScoreLevel GetTotalScoreLevel(int score, bool? isEndless = null, int? levelId = null)
	{
		int levelId2 = (levelId != null && levelId.Value != 0) ? levelId.Value : this.GetCurrentLevelRecord(isEndless).LevelId;
		NewTowerLevel? levelConfigById = ConfigBase<WheelTowerConfig>.Instance.GetLevelConfigById(levelId2);
		EScoreLevel result = EScoreLevel.None;
		foreach (DicIntInt dicIntInt in levelConfigById.Value.ScoreLevelRuleIter())
		{
			int key = dicIntInt.Key;
			int value = dicIntInt.Value;
			if (score < value)
			{
				break;
			}
			result = (EScoreLevel)key;
		}
		return result;
	}

	// Token: 0x0600A3E5 RID: 41957 RVA: 0x002B4FE8 File Offset: 0x002B31E8
	[NullableContext(0)]
	public ValueTuple<int, int> GetScoreRange(int score)
	{
		int levelId = this.GetCurrentLevelRecord(null).LevelId;
		NewTowerLevel? levelConfigById = ConfigBase<WheelTowerConfig>.Instance.GetLevelConfigById(levelId);
		int num = 0;
		int item = 0;
		foreach (DicIntInt dicIntInt in levelConfigById.Value.ScoreLevelRuleIter())
		{
			int value = dicIntInt.Value;
			if (score < value)
			{
				return new ValueTuple<int, int>(num, value);
			}
			item = num;
			num = value;
		}
		return new ValueTuple<int, int>(item, num);
	}

	// Token: 0x0600A3E6 RID: 41958 RVA: 0x002B5090 File Offset: 0x002B3290
	public List<WheelTowerScoreLevelTargetData> GetScoreLevelList()
	{
		int levelId = this.GetCurrentLevelRecord(null).LevelId;
		List<WheelTowerScoreLevelTargetData> result;
		if (!this.LevelIdToScoreLevelTargetDataList.TryGetValue(levelId, out result))
		{
			NewTowerLevel? levelConfigById = ConfigBase<WheelTowerConfig>.Instance.GetLevelConfigById(levelId);
			List<WheelTowerScoreLevelTargetData> list = new List<WheelTowerScoreLevelTargetData>();
			foreach (DicIntInt dicIntInt in levelConfigById.Value.ScoreLevelRuleIter())
			{
				int key = dicIntInt.Key;
				int value = dicIntInt.Value;
				if (key != 0)
				{
					list.Add(new WheelTowerScoreLevelTargetData(key, value));
				}
			}
			this.LevelIdToScoreLevelTargetDataList[levelId] = list;
			return list;
		}
		return result;
	}

	// Token: 0x0600A3E7 RID: 41959 RVA: 0x002B515C File Offset: 0x002B335C
	public bool CheckInInstanceDungeon()
	{
		if (ControllerBase<GameModeController>.Instance.IsInInstance())
		{
			int instanceId = ModelBase<CreatureModel>.Instance.GetInstanceId();
			InstanceDungeon? config = ConfigBase<InstanceDungeonConfig>.Instance.GetConfig(instanceId);
			return config != null && config.GetValueOrDefault().InstSubType == 47;
		}
		return false;
	}

	// Token: 0x0600A3E8 RID: 41960 RVA: 0x002B51AC File Offset: 0x002B33AC
	public bool GetIsEndlessUnlockedInInstance()
	{
		if (this.IsEndlessUnlockedInInstance)
		{
			this.IsEndlessUnlockedInInstance = false;
			return true;
		}
		return false;
	}

	// Token: 0x0600A3E9 RID: 41961 RVA: 0x002B51C0 File Offset: 0x002B33C0
	public void SetIsEndlessUnlockedInInstance(bool value)
	{
		this.IsEndlessUnlockedInInstance = value;
	}

	// Token: 0x0600A3EA RID: 41962 RVA: 0x002B51CC File Offset: 0x002B33CC
	[NullableContext(2)]
	public string GetNextCycleRemainTime()
	{
		double cycleBeginTime = this.ActivityData.CycleBeginTime;
		if (cycleBeginTime == -1.0)
		{
			return null;
		}
		double serverTime = Singleton<TimeUtil>.Instance.GetServerTime();
		return this.RemainTimeToText(cycleBeginTime - serverTime);
	}

	// Token: 0x0600A3EB RID: 41963 RVA: 0x002B5208 File Offset: 0x002B3408
	[NullableContext(2)]
	public string GetCycleEndRemainTime()
	{
		double cycleEndTime = this.ActivityData.CycleEndTime;
		if (cycleEndTime == -1.0)
		{
			return null;
		}
		double serverTime = Singleton<TimeUtil>.Instance.GetServerTime();
		return this.RemainTimeToText(cycleEndTime - serverTime);
	}

	// Token: 0x0600A3EC RID: 41964 RVA: 0x002B5244 File Offset: 0x002B3444
	private string RemainTimeToText(double remainingTime)
	{
		if (remainingTime <= 1.0)
		{
			remainingTime = 1.0;
		}
		CommonDefine.ETimeType value = (remainingTime >= 86400.0) ? CommonDefine.ETimeType.Day : ((remainingTime >= 3600.0) ? CommonDefine.ETimeType.Hour : CommonDefine.ETimeType.Minute);
		CommonDefine.ETimeType value2 = (remainingTime >= 86400.0) ? CommonDefine.ETimeType.Hour : ((remainingTime >= 3600.0) ? CommonDefine.ETimeType.Minute : CommonDefine.ETimeType.Second);
		return Singleton<TimeUtil>.Instance.GetCountDownDataFormat2(remainingTime, new CommonDefine.ETimeType?(value), new CommonDefine.ETimeType?(value2)).CountDownText;
	}

	// Token: 0x0600A3ED RID: 41965 RVA: 0x002B52C4 File Offset: 0x002B34C4
	private void BuildRoleData()
	{
		IReadOnlyList<NewTowerRole> roleConfigList = ConfigBase<WheelTowerConfig>.Instance.GetRoleConfigList();
		if (roleConfigList == null)
		{
			return;
		}
		foreach (NewTowerRole newTowerRole in roleConfigList)
		{
			if (newTowerRole.TemplateRoleId != 0)
			{
				this.RoleToTemplate[newTowerRole.Id] = newTowerRole.TemplateRoleId;
				this.TemplateToRole[newTowerRole.TemplateRoleId] = newTowerRole.Id;
			}
		}
	}

	// Token: 0x0600A3EE RID: 41966 RVA: 0x002B5350 File Offset: 0x002B3550
	private void ClearRoleData()
	{
		this.RoleToTemplate.Clear();
		this.TemplateToRole.Clear();
		this.EnhancedRoleSetInterval.Clear();
	}

	// Token: 0x0600A3EF RID: 41967 RVA: 0x002B5373 File Offset: 0x002B3573
	public bool IsTemplateRole(int roleId)
	{
		return this.TemplateToRole.ContainsKey(roleId);
	}

	// Token: 0x0600A3F0 RID: 41968 RVA: 0x002B5384 File Offset: 0x002B3584
	public int GetTemplateRoleId(int roleId)
	{
		int result;
		if (!this.RoleToTemplate.TryGetValue(roleId, out result))
		{
			return 0;
		}
		return result;
	}

	// Token: 0x0600A3F1 RID: 41969 RVA: 0x002B53A4 File Offset: 0x002B35A4
	public int GetRealRoleId(int templateRoleId)
	{
		int result;
		if (!this.TemplateToRole.TryGetValue(templateRoleId, out result))
		{
			return 0;
		}
		return result;
	}

	// Token: 0x0600A3F2 RID: 41970 RVA: 0x002B53C4 File Offset: 0x002B35C4
	public int TryGetRealRoleId(int roleId)
	{
		if (!this.IsTemplateRole(roleId))
		{
			return roleId;
		}
		return this.GetRealRoleId(roleId);
	}

	// Token: 0x0600A3F3 RID: 41971 RVA: 0x002B53D8 File Offset: 0x002B35D8
	public string GetTemplateRoleDesc(int roleId)
	{
		int roleId2 = this.TryGetRealRoleId(roleId);
		return ConfigBase<WheelTowerConfig>.Instance.GetRoleConfigByRoleId(roleId2).Value.TemplateDesc;
	}

	// Token: 0x17000D99 RID: 3481
	// (get) Token: 0x0600A3F4 RID: 41972 RVA: 0x002B5408 File Offset: 0x002B3608
	public HashSet<int> EnhancedRoleSet
	{
		get
		{
			if (this.EnhancedRoleSetInterval.Count == 0)
			{
				this.EnhancedRoleSetInterval = new HashSet<int>(this.GetTowerConfig().GetEnhanceRoleIdsArray());
			}
			return this.EnhancedRoleSetInterval;
		}
	}

	// Token: 0x0600A3F5 RID: 41973 RVA: 0x002B5444 File Offset: 0x002B3644
	public List<int> GetEnhanceRoleIdList()
	{
		List<int> list = new List<int>();
		foreach (int item in this.EnhancedRoleSet)
		{
			list.Add(item);
		}
		return list;
	}

	// Token: 0x0600A3F6 RID: 41974 RVA: 0x002B54A0 File Offset: 0x002B36A0
	public unsafe List<WheelTowerRoleEnhanceSkillData> GetEnhanceSkillInfoList(int roleId)
	{
		NewTowerRole? roleConfigByRoleId = ConfigBase<WheelTowerConfig>.Instance.GetRoleConfigByRoleId(roleId);
		IReadOnlyList<Aki.Config.Skill> skillList = ConfigBase<RoleSkillConfig>.Instance.GetSkillList(roleId);
		List<WheelTowerRoleEnhanceSkillData> list = new List<WheelTowerRoleEnhanceSkillData>();
		foreach (int num in new int[]
		{
			11,
			2,
			3,
			6
		})
		{
			string enhanceSkillDesc = roleConfigByRoleId.Value.GetEnhanceSkillDesc(num);
			StringArray? enhanceSkillDescParam = roleConfigByRoleId.Value.GetEnhanceSkillDescParam(num);
			if (enhanceSkillDesc != null && enhanceSkillDescParam != null)
			{
				bool flag = false;
				foreach (Aki.Config.Skill skill in skillList)
				{
					if (skill.SkillType == num)
					{
						flag = true;
						list.Add(new WheelTowerRoleEnhanceSkillData
						{
							SkillName = skill.SkillName,
							SkillIcon = skill.Icon,
							SkillDesc = this.GetLocalDesc(enhanceSkillDesc, enhanceSkillDescParam.Value.ArrayString())
						});
						break;
					}
				}
				if (!flag)
				{
					Log instance = Singleton<Log>.Instance;
					ELogModule module = ELogModule.WheelTower;
					ELogAuthor author = ELogAuthor.CXJ;
					string message = "角色技能信息不存在";
					<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
					*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("roleId", roleId);
					*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("skillType", num);
					instance.Error(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
				}
			}
		}
		return list;
	}

	// Token: 0x0600A3F7 RID: 41975 RVA: 0x002B5638 File Offset: 0x002B3838
	public bool IsEnhanceRole(int roleId)
	{
		int item = this.TryGetRealRoleId(roleId);
		return this.EnhancedRoleSet.Contains(item);
	}

	// Token: 0x0600A3F8 RID: 41976 RVA: 0x002B565C File Offset: 0x002B385C
	public List<string> GetRoleEnhanceDesc(int roleId)
	{
		NewTowerRole? roleConfigByRoleId = ConfigBase<WheelTowerConfig>.Instance.GetRoleConfigByRoleId(roleId);
		List<string> list = new List<string>();
		foreach (int key in new int[]
		{
			11,
			2,
			3,
			6
		})
		{
			string enhanceSkillDesc = roleConfigByRoleId.Value.GetEnhanceSkillDesc(key);
			StringArray? enhanceSkillDescParam = roleConfigByRoleId.Value.GetEnhanceSkillDescParam(key);
			if (enhanceSkillDesc != null && enhanceSkillDescParam != null)
			{
				list.Add(this.GetLocalDesc(enhanceSkillDesc, enhanceSkillDescParam.Value.ArrayString()));
			}
		}
		return list;
	}

	// Token: 0x0600A3F9 RID: 41977 RVA: 0x002B56F4 File Offset: 0x002B38F4
	private string GetLocalDesc(string textId, string[] param)
	{
		return StringUtils.Format(ConfigMultiTextLang.GetLocalTextNew(textId, null), param);
	}

	// Token: 0x0600A3FA RID: 41978 RVA: 0x002B5704 File Offset: 0x002B3904
	public bool IsEnhanceSkill(int roleId, int skillId)
	{
		if (!this.IsEnhanceRole(roleId))
		{
			return false;
		}
		int skillType = ConfigBase<RoleSkillConfig>.Instance.GetSkillConfigById(skillId).Value.SkillType;
		return this.GetRoleSkillEnhanceDescAndParam(roleId, skillType) != null;
	}

	// Token: 0x0600A3FB RID: 41979 RVA: 0x002B5748 File Offset: 0x002B3948
	[return: Nullable(new byte[]
	{
		0,
		1,
		1,
		1
	})]
	public ValueTuple<string, string[]>? GetRoleSkillEnhanceDescAndParam(int roleId, int skillType)
	{
		NewTowerRole? roleConfigByRoleId = ConfigBase<WheelTowerConfig>.Instance.GetRoleConfigByRoleId(roleId);
		string enhanceSkillDesc = roleConfigByRoleId.Value.GetEnhanceSkillDesc(skillType);
		if (enhanceSkillDesc == null)
		{
			return null;
		}
		StringArray? enhanceSkillDescParam = roleConfigByRoleId.Value.GetEnhanceSkillDescParam(skillType);
		if (enhanceSkillDescParam == null)
		{
			return null;
		}
		return new ValueTuple<string, string[]>?(new ValueTuple<string, string[]>(enhanceSkillDesc, enhanceSkillDescParam.Value.ArrayString()));
	}

	// Token: 0x17000D9A RID: 3482
	// (get) Token: 0x0600A3FC RID: 41980 RVA: 0x002B57C0 File Offset: 0x002B39C0
	public Dictionary<int, int> SpecialUpRoleMap
	{
		get
		{
			if (this.SpecialUpRoleMapInternal == null)
			{
				Dictionary<int, int> dictionary = new Dictionary<int, int>();
				NewTowerParam towerConfig = this.GetTowerConfig();
				int specialUpRoleIdsLength = towerConfig.SpecialUpRoleIdsLength;
				for (int i = 0; i < specialUpRoleIdsLength; i++)
				{
					DicIntInt? dicIntInt = towerConfig.SpecialUpRoleIds(i);
					if (dicIntInt != null)
					{
						dictionary[dicIntInt.Value.Key] = dicIntInt.Value.Value;
					}
				}
				this.SpecialUpRoleMapInternal = dictionary;
			}
			return this.SpecialUpRoleMapInternal;
		}
	}

	// Token: 0x0600A3FD RID: 41981 RVA: 0x002B583C File Offset: 0x002B3A3C
	public int GetSpecialUpRoleAddEnergy(int roleId)
	{
		int result;
		if (!this.SpecialUpRoleMap.TryGetValue(roleId, out result))
		{
			return 0;
		}
		return result;
	}

	// Token: 0x0600A3FE RID: 41982 RVA: 0x002B585C File Offset: 0x002B3A5C
	[NullableContext(2)]
	public IWheelTowerMedalGroupData GetMedalGroupData(int groupId)
	{
		return this.ActivityData.GetMedalGroupData(groupId);
	}

	// Token: 0x0600A3FF RID: 41983 RVA: 0x002B586C File Offset: 0x002B3A6C
	public List<IWheelTowerMedalGroupData> GetSeasonMedalGroupList(int seasonId, EWheelTowerMedalType medalType)
	{
		IReadOnlyList<NewTowerMedal> medalConfigListBySeasonId = ConfigBase<WheelTowerConfig>.Instance.GetMedalConfigListBySeasonId(seasonId);
		if (medalConfigListBySeasonId == null || medalConfigListBySeasonId.Count == 0)
		{
			return new List<IWheelTowerMedalGroupData>();
		}
		HashSet<int> hashSet = new HashSet<int>();
		foreach (NewTowerMedal newTowerMedal in medalConfigListBySeasonId)
		{
			if (!hashSet.Contains(newTowerMedal.GroupId) && ((medalType == EWheelTowerMedalType.Season) ? (newTowerMedal.CycleId == 0) : (newTowerMedal.CycleId > 0)))
			{
				hashSet.Add(newTowerMedal.GroupId);
			}
		}
		List<IWheelTowerMedalGroupData> list = new List<IWheelTowerMedalGroupData>();
		foreach (int groupId in hashSet)
		{
			IWheelTowerMedalGroupData medalGroupData = this.GetMedalGroupData(groupId);
			if (medalGroupData != null)
			{
				list.Add(medalGroupData);
			}
		}
		return list;
	}

	// Token: 0x0600A400 RID: 41984 RVA: 0x002B5960 File Offset: 0x002B3B60
	public List<IWheelTowerMedalGroupData> GetAllSeasonMedalGroupList(int seasonId)
	{
		List<IWheelTowerMedalGroupData> seasonMedalGroupList = this.GetSeasonMedalGroupList(seasonId, EWheelTowerMedalType.Season);
		seasonMedalGroupList.AddRange(this.GetSeasonMedalGroupList(seasonId, EWheelTowerMedalType.Stage));
		return seasonMedalGroupList;
	}

	// Token: 0x0600A401 RID: 41985 RVA: 0x002B5978 File Offset: 0x002B3B78
	public int GetSeasonMedalReadId(int groupId)
	{
		if (groupId == 0)
		{
			return 0;
		}
		ServerStorageMap serverStorageMap = ModelBase<ServerStorageModel>.Instance.Get(EClientStorageSystemIdType.WheelTowerSeasonReview) as ServerStorageMap;
		if (serverStorageMap == null)
		{
			return 0;
		}
		return serverStorageMap.Get(groupId).GetValueOrDefault();
	}

	// Token: 0x0600A402 RID: 41986 RVA: 0x002B59B0 File Offset: 0x002B3BB0
	public bool HasUnreadSeasonMedalRedDot(int seasonId)
	{
		if (seasonId == 0)
		{
			return false;
		}
		List<IWheelTowerMedalGroupData> allSeasonMedalGroupList = this.GetAllSeasonMedalGroupList(seasonId);
		if (allSeasonMedalGroupList.Count == 0)
		{
			return false;
		}
		ServerStorageMap serverStorageMap = ModelBase<ServerStorageModel>.Instance.Get(EClientStorageSystemIdType.WheelTowerSeasonReview) as ServerStorageMap;
		if (serverStorageMap == null)
		{
			return false;
		}
		foreach (IWheelTowerMedalGroupData wheelTowerMedalGroupData in allSeasonMedalGroupList)
		{
			if (wheelTowerMedalGroupData.GroupId != 0 && wheelTowerMedalGroupData.CurrentMedalId > 0 && serverStorageMap.Get(wheelTowerMedalGroupData.GroupId).GetValueOrDefault() != wheelTowerMedalGroupData.CurrentMedalId)
			{
				return true;
			}
		}
		return false;
	}

	// Token: 0x0600A403 RID: 41987 RVA: 0x002B5A5C File Offset: 0x002B3C5C
	public void MarkSeasonMedalsRead(int seasonId)
	{
		if (seasonId == 0)
		{
			return;
		}
		List<IWheelTowerMedalGroupData> allSeasonMedalGroupList = this.GetAllSeasonMedalGroupList(seasonId);
		if (allSeasonMedalGroupList.Count == 0)
		{
			return;
		}
		ServerStorageMap serverStorageMap = ModelBase<ServerStorageModel>.Instance.Get(EClientStorageSystemIdType.WheelTowerSeasonReview) as ServerStorageMap;
		if (serverStorageMap == null)
		{
			return;
		}
		foreach (IWheelTowerMedalGroupData wheelTowerMedalGroupData in allSeasonMedalGroupList)
		{
			if (wheelTowerMedalGroupData.GroupId != 0 && wheelTowerMedalGroupData.CurrentMedalId > 0)
			{
				serverStorageMap.Set(wheelTowerMedalGroupData.GroupId, wheelTowerMedalGroupData.CurrentMedalId);
			}
		}
	}

	// Token: 0x0600A404 RID: 41988 RVA: 0x002B5AF4 File Offset: 0x002B3CF4
	public void CleanOldSeasonMedalsStorage(int currentSeasonId)
	{
		IReadOnlyList<NewTowerSeason> allSeasonConfigs = ConfigBase<WheelTowerConfig>.Instance.GetAllSeasonConfigs();
		if (allSeasonConfigs == null)
		{
			return;
		}
		ServerStorageMap serverStorageMap = ModelBase<ServerStorageModel>.Instance.Get(EClientStorageSystemIdType.WheelTowerSeasonReview) as ServerStorageMap;
		if (serverStorageMap == null)
		{
			return;
		}
		foreach (NewTowerSeason newTowerSeason in allSeasonConfigs)
		{
			if (newTowerSeason.Id != currentSeasonId && newTowerSeason.Id != 0)
			{
				IReadOnlyList<NewTowerMedal> medalConfigListBySeasonId = ConfigBase<WheelTowerConfig>.Instance.GetMedalConfigListBySeasonId(newTowerSeason.Id);
				if (medalConfigListBySeasonId != null)
				{
					foreach (NewTowerMedal newTowerMedal in medalConfigListBySeasonId)
					{
						if (newTowerMedal.GroupId != 0)
						{
							serverStorageMap.Delete(newTowerMedal.GroupId);
						}
					}
				}
			}
		}
	}

	// Token: 0x04004DC7 RID: 19911
	private int ActivityDataIdInternal = -1;

	// Token: 0x04004DC8 RID: 19912
	[Nullable(2)]
	private Dictionary<int, int> RoleCostMap;

	// Token: 0x04004DC9 RID: 19913
	private int DefaultRoleCost = -1;

	// Token: 0x04004DCA RID: 19914
	public bool EndlessMode;

	// Token: 0x04004DCB RID: 19915
	public int SelectedRound = -1;

	// Token: 0x04004DCC RID: 19916
	public int SelectedBuff = -1;

	// Token: 0x04004DCD RID: 19917
	public int SelectedBossId = -1;

	// Token: 0x04004DCE RID: 19918
	public List<int> SelectedRoleList = new List<int>();

	// Token: 0x04004DCF RID: 19919
	[Nullable(2)]
	public CSharpScript.Game.Module.Activity.ActivityContent.WheelTower.EnergyInfo SelectedEnergyInfo;

	// Token: 0x04004DD0 RID: 19920
	public readonly Dictionary<int, int> TmpSelectedRoleMap = new Dictionary<int, int>();

	// Token: 0x04004DD1 RID: 19921
	private readonly Dictionary<bool, IWheelTowerCoverRecordViewData> LevelRecordPopupDataMap = new Dictionary<bool, IWheelTowerCoverRecordViewData>();

	// Token: 0x04004DD2 RID: 19922
	private readonly Dictionary<int, List<WheelTowerScoreLevelTargetData>> LevelIdToScoreLevelTargetDataList = new Dictionary<int, List<WheelTowerScoreLevelTargetData>>();

	// Token: 0x04004DD3 RID: 19923
	public bool BlockEndlessUnlockTips = true;

	// Token: 0x04004DD4 RID: 19924
	private bool IsEndlessUnlockedInInstance;

	// Token: 0x04004DD5 RID: 19925
	public int CachedRoundInProgress = -1;

	// Token: 0x04004DD6 RID: 19926
	public bool IsTimeStopBanned;

	// Token: 0x04004DD7 RID: 19927
	private readonly Dictionary<int, int> RoleToTemplate = new Dictionary<int, int>();

	// Token: 0x04004DD8 RID: 19928
	private readonly Dictionary<int, int> TemplateToRole = new Dictionary<int, int>();

	// Token: 0x04004DD9 RID: 19929
	private HashSet<int> EnhancedRoleSetInterval = new HashSet<int>();

	// Token: 0x04004DDA RID: 19930
	public int TmpSelectRoleId;

	// Token: 0x04004DDB RID: 19931
	[Nullable(2)]
	private Dictionary<int, int> SpecialUpRoleMapInternal;
}
