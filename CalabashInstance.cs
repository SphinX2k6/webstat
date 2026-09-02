using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using Aki.Protocol;

// Token: 0x020017E6 RID: 6118
[NullableContext(1)]
[Nullable(0)]
public class CalabashInstance
{
	// Token: 0x0600ADA2 RID: 44450 RVA: 0x002E330B File Offset: 0x002E150B
	public CalabashInstance()
	{
		this.LevelCatchGainMap = new Dictionary<int, int>();
		this.DevelopRewards = new Dictionary<int, List<ICalabashDevelopConditionState>>();
		this.RewardedLevelsSet = new HashSet<int>();
	}

	// Token: 0x0600ADA3 RID: 44451 RVA: 0x002E3334 File Offset: 0x002E1534
	public void SetBaseInfo(CalabashMsg baseInfo)
	{
		this.CalabashCurrentLevel = baseInfo.Level;
		this.CalabashCurrentExp = baseInfo.Exp;
		this.CalabashMaxLevel = ConfigBase<CalabashConfig>.Instance.GetCalabashMaxLevel();
		this.IdentifyGuaranteeCount = baseInfo.IdentifyGuaranteeCount;
		this.LowCostIdentifyGuaranteeCount = baseInfo.LowCostGuaranteeCount;
		this.SetUnlockCalabashDevelopRewards(baseInfo.UnlockedDevelopRewards.ToArray<CalabashDevelopInfo>());
	}

	// Token: 0x0600ADA4 RID: 44452 RVA: 0x002E3394 File Offset: 0x002E1594
	public void SetConfigInfo(CalabashCfg configInfo)
	{
		foreach (KeyValuePair<int, int> keyValuePair in configInfo.CatchGain)
		{
			int key = keyValuePair.Key;
			this.LevelCatchGainMap[key] = keyValuePair.Value;
		}
	}

	// Token: 0x17000E30 RID: 3632
	// (get) Token: 0x0600ADA5 RID: 44453 RVA: 0x002E33F8 File Offset: 0x002E15F8
	// (set) Token: 0x0600ADA6 RID: 44454 RVA: 0x002E3400 File Offset: 0x002E1600
	public int CalabashCurrentLevel
	{
		get
		{
			return this.CurrentLevel;
		}
		set
		{
			this.CurrentLevel = value;
		}
	}

	// Token: 0x17000E31 RID: 3633
	// (get) Token: 0x0600ADA7 RID: 44455 RVA: 0x002E3409 File Offset: 0x002E1609
	// (set) Token: 0x0600ADA8 RID: 44456 RVA: 0x002E3411 File Offset: 0x002E1611
	public int CalabashMaxLevel
	{
		get
		{
			return this.MaxLevel;
		}
		set
		{
			this.MaxLevel = value;
		}
	}

	// Token: 0x17000E32 RID: 3634
	// (get) Token: 0x0600ADA9 RID: 44457 RVA: 0x002E341A File Offset: 0x002E161A
	// (set) Token: 0x0600ADAA RID: 44458 RVA: 0x002E3422 File Offset: 0x002E1622
	public int CalabashCurrentExp
	{
		get
		{
			return this.CurrentExp;
		}
		set
		{
			this.CurrentExp = value;
		}
	}

	// Token: 0x17000E33 RID: 3635
	// (get) Token: 0x0600ADAB RID: 44459 RVA: 0x002E342B File Offset: 0x002E162B
	// (set) Token: 0x0600ADAC RID: 44460 RVA: 0x002E3433 File Offset: 0x002E1633
	public int IdentifyGuaranteeCount
	{
		get
		{
			return this.IdentifyGuaranteeCountInternal;
		}
		set
		{
			this.IdentifyGuaranteeCountInternal = value;
		}
	}

	// Token: 0x17000E34 RID: 3636
	// (get) Token: 0x0600ADAD RID: 44461 RVA: 0x002E343C File Offset: 0x002E163C
	// (set) Token: 0x0600ADAE RID: 44462 RVA: 0x002E3444 File Offset: 0x002E1644
	public int LowCostIdentifyGuaranteeCount
	{
		get
		{
			return this.LowCostIdentifyGuaranteeCountInternal;
		}
		set
		{
			this.LowCostIdentifyGuaranteeCountInternal = value;
		}
	}

	// Token: 0x0600ADAF RID: 44463 RVA: 0x002E3450 File Offset: 0x002E1650
	public void SetUnlockCalabashDevelopRewards(CalabashDevelopInfo[] developRewards)
	{
		this.DevelopRewards.Clear();
		foreach (CalabashDevelopInfo calabashDevelopInfo in developRewards)
		{
			List<ICalabashDevelopConditionState> list = new List<ICalabashDevelopConditionState>();
			foreach (Aki.Protocol.CalabashDevelopConditionState calabashDevelopConditionState in calabashDevelopInfo.UnlockConditions)
			{
				list.Add(new global::CalabashDevelopConditionState
				{
					ConditionId = calabashDevelopConditionState.ConditionId,
					Rewarded = calabashDevelopConditionState.Rewarded
				});
			}
			this.DevelopRewards[calabashDevelopInfo.MonsterId] = list;
		}
	}

	// Token: 0x0600ADB0 RID: 44464 RVA: 0x002E3500 File Offset: 0x002E1700
	public void SetUnlockCalabashDevelopReward(CalabashDevelopInfo developReward)
	{
		List<ICalabashDevelopConditionState> list = new List<ICalabashDevelopConditionState>();
		foreach (Aki.Protocol.CalabashDevelopConditionState calabashDevelopConditionState in developReward.UnlockConditions)
		{
			list.Add(new global::CalabashDevelopConditionState
			{
				ConditionId = calabashDevelopConditionState.ConditionId,
				Rewarded = calabashDevelopConditionState.Rewarded
			});
		}
		this.DevelopRewards[developReward.MonsterId] = list;
	}

	// Token: 0x0600ADB1 RID: 44465 RVA: 0x002E3584 File Offset: 0x002E1784
	public Dictionary<int, List<ICalabashDevelopConditionState>> GetUnlockCalabashDevelopRewards()
	{
		return this.DevelopRewards;
	}

	// Token: 0x0600ADB2 RID: 44466 RVA: 0x002E358C File Offset: 0x002E178C
	public void SetRewardedLevelsSet(List<int> levelList)
	{
		this.RewardedLevelsSet.Clear();
		foreach (int item in levelList)
		{
			this.RewardedLevelsSet.Add(item);
		}
	}

	// Token: 0x0600ADB3 RID: 44467 RVA: 0x002E35EC File Offset: 0x002E17EC
	public bool IsRewardedByLevel(int level)
	{
		return this.RewardedLevelsSet.Contains(level);
	}

	// Token: 0x0600ADB4 RID: 44468 RVA: 0x002E35FC File Offset: 0x002E17FC
	public int? GetCatchGainByLevel(int level)
	{
		int value;
		if (this.LevelCatchGainMap.TryGetValue(level, out value))
		{
			return new int?(value);
		}
		return null;
	}

	// Token: 0x04005242 RID: 21058
	private int CurrentLevel;

	// Token: 0x04005243 RID: 21059
	private int MaxLevel;

	// Token: 0x04005244 RID: 21060
	private int CurrentExp;

	// Token: 0x04005245 RID: 21061
	private int IdentifyGuaranteeCountInternal;

	// Token: 0x04005246 RID: 21062
	private int LowCostIdentifyGuaranteeCountInternal;

	// Token: 0x04005247 RID: 21063
	private readonly Dictionary<int, int> LevelCatchGainMap;

	// Token: 0x04005248 RID: 21064
	private readonly Dictionary<int, List<ICalabashDevelopConditionState>> DevelopRewards;

	// Token: 0x04005249 RID: 21065
	private readonly HashSet<int> RewardedLevelsSet;
}
