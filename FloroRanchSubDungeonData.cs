using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using Aki.Config;
using Aki.Protocol;
using CSharpScript.Game.Common;

// Token: 0x02001BCD RID: 7117
[NullableContext(1)]
[Nullable(0)]
public class FloroRanchSubDungeonData
{
	// Token: 0x0600CF16 RID: 53014 RVA: 0x003717E2 File Offset: 0x0036F9E2
	public FloroRanchSubDungeonData(FloroRanchSubIns config)
	{
		this.Config = config;
	}

	// Token: 0x0600CF17 RID: 53015 RVA: 0x003717F8 File Offset: 0x0036F9F8
	public void UpdateUnLockState(bool isUnLock)
	{
		this.IsUnLockInternal = isUnLock;
	}

	// Token: 0x170010C2 RID: 4290
	// (get) Token: 0x0600CF18 RID: 53016 RVA: 0x00371801 File Offset: 0x0036FA01
	public bool IsUnLock
	{
		get
		{
			return this.IsUnLockInternal;
		}
	}

	// Token: 0x0600CF19 RID: 53017 RVA: 0x00371809 File Offset: 0x0036FA09
	public void UpdateHistoryData(FloroRanchSubInsRecord historyData)
	{
		this.HasHistoryInternal = true;
		this.MaxDaysInternal = historyData.MaxDay;
		this.MaxCoinInternal = (int)Singleton<MathUtils>.Instance.LongToBigInt(historyData.MaxCoin);
	}

	// Token: 0x170010C3 RID: 4291
	// (get) Token: 0x0600CF1B RID: 53019 RVA: 0x0037183E File Offset: 0x0036FA3E
	// (set) Token: 0x0600CF1A RID: 53018 RVA: 0x00371835 File Offset: 0x0036FA35
	public bool IsFinished
	{
		get
		{
			return this.IsFinishedInternal;
		}
		set
		{
			this.IsFinishedInternal = value;
		}
	}

	// Token: 0x0600CF1C RID: 53020 RVA: 0x00371846 File Offset: 0x0036FA46
	public void SetInstanceId(int instanceId)
	{
		this.InstanceIdInternal = instanceId;
	}

	// Token: 0x170010C4 RID: 4292
	// (get) Token: 0x0600CF1D RID: 53021 RVA: 0x0037184F File Offset: 0x0036FA4F
	public int InstanceId
	{
		get
		{
			return this.InstanceIdInternal;
		}
	}

	// Token: 0x170010C5 RID: 4293
	// (get) Token: 0x0600CF1F RID: 53023 RVA: 0x00371860 File Offset: 0x0036FA60
	// (set) Token: 0x0600CF1E RID: 53022 RVA: 0x00371857 File Offset: 0x0036FA57
	public bool IsInstanceUnlock
	{
		get
		{
			return this.IsInstanceUnLockInternal;
		}
		set
		{
			this.IsInstanceUnLockInternal = value;
		}
	}

	// Token: 0x170010C6 RID: 4294
	// (get) Token: 0x0600CF21 RID: 53025 RVA: 0x00371871 File Offset: 0x0036FA71
	// (set) Token: 0x0600CF20 RID: 53024 RVA: 0x00371868 File Offset: 0x0036FA68
	public int ConditionId
	{
		get
		{
			return this.ConditionIdInternal;
		}
		set
		{
			this.ConditionIdInternal = value;
		}
	}

	// Token: 0x0600CF22 RID: 53026 RVA: 0x00371879 File Offset: 0x0036FA79
	public int GetMaxStage()
	{
		return this.Config.Stage;
	}

	// Token: 0x170010C7 RID: 4295
	// (get) Token: 0x0600CF23 RID: 53027 RVA: 0x00371886 File Offset: 0x0036FA86
	public int Difficulty
	{
		get
		{
			return this.Config.Difficulty;
		}
	}

	// Token: 0x0600CF24 RID: 53028 RVA: 0x00371893 File Offset: 0x0036FA93
	public int GetStageDay()
	{
		return this.Config.StageDays()[0];
	}

	// Token: 0x170010C8 RID: 4296
	// (get) Token: 0x0600CF25 RID: 53029 RVA: 0x003718A2 File Offset: 0x0036FAA2
	public int FirstReward
	{
		get
		{
			return this.Config.FirstTechReward;
		}
	}

	// Token: 0x170010C9 RID: 4297
	// (get) Token: 0x0600CF26 RID: 53030 RVA: 0x003718B0 File Offset: 0x0036FAB0
	public int AgainReward
	{
		get
		{
			int num = 0;
			foreach (int num2 in this.Config.TechReward())
			{
				num += num2;
			}
			return num;
		}
	}

	// Token: 0x170010CA RID: 4298
	// (get) Token: 0x0600CF27 RID: 53031 RVA: 0x003718E2 File Offset: 0x0036FAE2
	public int TagId
	{
		get
		{
			return this.Config.Tag;
		}
	}

	// Token: 0x170010CB RID: 4299
	// (get) Token: 0x0600CF28 RID: 53032 RVA: 0x003718EF File Offset: 0x0036FAEF
	public int[] RaceList
	{
		get
		{
			return this.Config.Race();
		}
	}

	// Token: 0x170010CC RID: 4300
	// (get) Token: 0x0600CF29 RID: 53033 RVA: 0x003718FC File Offset: 0x0036FAFC
	public int Id
	{
		get
		{
			return this.Config.Id;
		}
	}

	// Token: 0x170010CD RID: 4301
	// (get) Token: 0x0600CF2A RID: 53034 RVA: 0x00371909 File Offset: 0x0036FB09
	public bool IsEndlessMode
	{
		get
		{
			return this.Config.EndlessMode;
		}
	}

	// Token: 0x170010CE RID: 4302
	// (get) Token: 0x0600CF2C RID: 53036 RVA: 0x0037191F File Offset: 0x0036FB1F
	// (set) Token: 0x0600CF2B RID: 53035 RVA: 0x00371916 File Offset: 0x0036FB16
	public bool HasRedDot
	{
		get
		{
			return this.IsUnLock && this.IsInstanceUnLockInternal && this.HasRedDotInternal;
		}
		set
		{
			this.HasRedDotInternal = value;
		}
	}

	// Token: 0x170010CF RID: 4303
	// (get) Token: 0x0600CF2D RID: 53037 RVA: 0x0037193C File Offset: 0x0036FB3C
	public List<int> SelectedRaceIds
	{
		get
		{
			List<int> list = this.RaceList.ToList<int>();
			Dictionary<int, List<int>> player = LocalStorage.GetPlayer<Dictionary<int, List<int>>>(ELocalStoragePlayerKey.FloroRanchSelectedRaceIds, null);
			if (player == null)
			{
				return list;
			}
			List<int> recordRaceIds;
			player.TryGetValue(this.Id, out recordRaceIds);
			if (recordRaceIds == null || list.Count != recordRaceIds.Count)
			{
				return list;
			}
			if (list.FindAll((int id) => id != 0).TrueForAll((int id) => recordRaceIds.Contains(id)))
			{
				return recordRaceIds;
			}
			return list;
		}
	}

	// Token: 0x170010D0 RID: 4304
	// (get) Token: 0x0600CF2E RID: 53038 RVA: 0x003719DC File Offset: 0x0036FBDC
	public bool HasHistory
	{
		get
		{
			return this.HasHistoryInternal;
		}
	}

	// Token: 0x170010D1 RID: 4305
	// (get) Token: 0x0600CF2F RID: 53039 RVA: 0x003719E4 File Offset: 0x0036FBE4
	public int MaxDays
	{
		get
		{
			return this.MaxDaysInternal;
		}
	}

	// Token: 0x170010D2 RID: 4306
	// (get) Token: 0x0600CF30 RID: 53040 RVA: 0x003719EC File Offset: 0x0036FBEC
	public int MaxCoin
	{
		get
		{
			return this.MaxCoinInternal;
		}
	}

	// Token: 0x170010D3 RID: 4307
	// (get) Token: 0x0600CF31 RID: 53041 RVA: 0x003719F4 File Offset: 0x0036FBF4
	public string[] EnvironmentTextList
	{
		get
		{
			return this.Config.EnvironmentText();
		}
	}

	// Token: 0x170010D4 RID: 4308
	// (get) Token: 0x0600CF32 RID: 53042 RVA: 0x00371A01 File Offset: 0x0036FC01
	public int[] RecommendCardsList
	{
		get
		{
			return this.Config.RecommendCards();
		}
	}

	// Token: 0x170010D5 RID: 4309
	// (get) Token: 0x0600CF33 RID: 53043 RVA: 0x00371A0E File Offset: 0x0036FC0E
	public int[] RecommendToysList
	{
		get
		{
			return this.Config.RecommendToys();
		}
	}

	// Token: 0x040062A6 RID: 25254
	private FloroRanchSubIns Config;

	// Token: 0x040062A7 RID: 25255
	private bool IsUnLockInternal;

	// Token: 0x040062A8 RID: 25256
	private bool IsFinishedInternal;

	// Token: 0x040062A9 RID: 25257
	private bool IsInstanceUnLockInternal;

	// Token: 0x040062AA RID: 25258
	private int InstanceIdInternal;

	// Token: 0x040062AB RID: 25259
	private int ConditionIdInternal;

	// Token: 0x040062AC RID: 25260
	private bool HasHistoryInternal;

	// Token: 0x040062AD RID: 25261
	private int MaxDaysInternal;

	// Token: 0x040062AE RID: 25262
	private int MaxCoinInternal;

	// Token: 0x040062AF RID: 25263
	private bool HasRedDotInternal = true;
}
