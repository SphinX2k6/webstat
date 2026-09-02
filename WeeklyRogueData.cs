using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using Aki.Protocol;
using CSharpScript.Game.Common.Event;

// Token: 0x02002D57 RID: 11607
[NullableContext(1)]
[Nullable(0)]
public class WeeklyRogueData : ActivityBaseData
{
	// Token: 0x060176E9 RID: 95977 RVA: 0x0067F8D4 File Offset: 0x0067DAD4
	public override bool GetExDataRedPointShowState()
	{
		return false;
	}

	// Token: 0x060176EA RID: 95978 RVA: 0x0067F8D7 File Offset: 0x0067DAD7
	public bool GetRogueRedDotState()
	{
		return this.CheckIfInShowTime() && (this.HasScoreRewardEnable() || this.HasNewCycle());
	}

	// Token: 0x060176EB RID: 95979 RVA: 0x0067F8F4 File Offset: 0x0067DAF4
	public bool SaveFirstCheckRedDotState()
	{
		if (ModelBase<ActivityModel>.Instance.GetActivityCacheData(base.Id, 0, this.CycleId, 0, 0) == 1)
		{
			return true;
		}
		ModelBase<ActivityModel>.Instance.SaveActivityData(base.Id, this.CycleId, 0, 0, 1);
		Singleton<EventSystem>.Instance.Emit<int>(EEventName.RefreshCommonActivityRedDot, base.Id);
		Singleton<EventSystem>.Instance.Emit(EEventName.WeeklyRogueRedDotInfoRefresh);
		return false;
	}

	// Token: 0x060176EC RID: 95980 RVA: 0x0067F961 File Offset: 0x0067DB61
	public bool HasNewCycle()
	{
		return base.GetPreGuideQuestFinishState() && !this.IsScoreRewardAllReceive() && ModelBase<ActivityModel>.Instance.GetActivityCacheData(base.Id, 0, this.CycleId, 0, 0) == 0;
	}

	// Token: 0x060176ED RID: 95981 RVA: 0x0067F994 File Offset: 0x0067DB94
	public bool HasScoreRewardEnable()
	{
		if (this.AwardsInfoList == null)
		{
			return false;
		}
		using (List<RogueWeeklyAward>.Enumerator enumerator = this.AwardsInfoList.GetEnumerator())
		{
			while (enumerator.MoveNext())
			{
				if (enumerator.Current.SignState == SignState.Unlock)
				{
					return true;
				}
			}
		}
		return false;
	}

	// Token: 0x060176EE RID: 95982 RVA: 0x0067F9F8 File Offset: 0x0067DBF8
	public bool IsScoreRewardAllDone()
	{
		if (this.AwardsInfoList == null)
		{
			return true;
		}
		using (List<RogueWeeklyAward>.Enumerator enumerator = this.AwardsInfoList.GetEnumerator())
		{
			while (enumerator.MoveNext())
			{
				if (enumerator.Current.SignState == SignState.Lock)
				{
					return false;
				}
			}
		}
		return true;
	}

	// Token: 0x060176EF RID: 95983 RVA: 0x0067FA5C File Offset: 0x0067DC5C
	public bool IsScoreRewardAllReceive()
	{
		if (this.AwardsInfoList == null)
		{
			return true;
		}
		using (List<RogueWeeklyAward>.Enumerator enumerator = this.AwardsInfoList.GetEnumerator())
		{
			while (enumerator.MoveNext())
			{
				if (enumerator.Current.SignState != SignState.IsReceive)
				{
					return false;
				}
			}
		}
		return true;
	}

	// Token: 0x060176F0 RID: 95984 RVA: 0x0067FAC0 File Offset: 0x0067DCC0
	public void SetScoreRewardState(int id, SignState state)
	{
		if (this.AwardsInfoList == null)
		{
			return;
		}
		foreach (RogueWeeklyAward rogueWeeklyAward in this.AwardsInfoList)
		{
			if (rogueWeeklyAward.ConfigId == id)
			{
				rogueWeeklyAward.SignState = state;
				break;
			}
		}
	}

	// Token: 0x060176F1 RID: 95985 RVA: 0x0067FB28 File Offset: 0x0067DD28
	public EActivityRewardState GetScoreRewardStateById(int id)
	{
		RogueWeeklyAward rogueWeeklyAward = null;
		if (this.AwardsInfoList != null)
		{
			foreach (RogueWeeklyAward rogueWeeklyAward2 in this.AwardsInfoList)
			{
				if (rogueWeeklyAward2.ConfigId == id)
				{
					rogueWeeklyAward = rogueWeeklyAward2;
					break;
				}
			}
		}
		if (rogueWeeklyAward != null && rogueWeeklyAward.SignState == SignState.IsReceive)
		{
			return EActivityRewardState.Claimed;
		}
		if (rogueWeeklyAward != null && rogueWeeklyAward.SignState == SignState.Lock)
		{
			return EActivityRewardState.Disabled;
		}
		return EActivityRewardState.Enable;
	}

	// Token: 0x060176F2 RID: 95986 RVA: 0x0067FBA8 File Offset: 0x0067DDA8
	public RogueWeeklyCycle? GetCycleConfig()
	{
		RogueWeeklyCycle? rogueWeeklyCycleConfig = ConfigBase<WeeklyRogueConfig>.Instance.GetRogueWeeklyCycleConfig(this.CycleId);
		if (rogueWeeklyCycleConfig != null)
		{
			return new RogueWeeklyCycle?(rogueWeeklyCycleConfig.Value);
		}
		return null;
	}

	// Token: 0x060176F3 RID: 95987 RVA: 0x0067FBE5 File Offset: 0x0067DDE5
	public double GetCycleRemainTime()
	{
		return (double)base.EndShowTime - Singleton<Time>.Instance.ServerTimeStamp / 1000.0;
	}

	// Token: 0x060176F4 RID: 95988 RVA: 0x0067FC04 File Offset: 0x0067DE04
	public int GetCycleBlackFlowerCost()
	{
		if (this.FreeCount > 0)
		{
			return 0;
		}
		RogueWeeklyCycle? cycleConfig = this.GetCycleConfig();
		if (cycleConfig == null)
		{
			return 0;
		}
		int num = 999;
		int num2 = 0;
		int blackFlowerCostLength = cycleConfig.Value.BlackFlowerCostLength;
		for (int i = 0; i < blackFlowerCostLength; i++)
		{
			int key = cycleConfig.Value.BlackFlowerCost(i).Value.Key;
			if (key < num)
			{
				num = key;
			}
			if (key > num2)
			{
				num2 = key;
			}
		}
		int result = 0;
		int curWorldLevel = ModelBase<WorldLevelModel>.Instance.CurWorldLevel;
		int num3;
		if (curWorldLevel < num)
		{
			num3 = num;
		}
		else if (curWorldLevel > num2)
		{
			num3 = num2;
		}
		else
		{
			num3 = curWorldLevel;
		}
		for (int j = 0; j < blackFlowerCostLength; j++)
		{
			DicIntInt? dicIntInt = cycleConfig.Value.BlackFlowerCost(j);
			if (dicIntInt != null && dicIntInt.Value.Key == num3)
			{
				result = dicIntInt.Value.Value;
				break;
			}
		}
		return result;
	}

	// Token: 0x060176F5 RID: 95989 RVA: 0x0067FD0C File Offset: 0x0067DF0C
	public int GetLvInfo()
	{
		RogueWeeklyCycle? cycleConfig = this.GetCycleConfig();
		if (cycleConfig == null)
		{
			return 0;
		}
		int num = 999;
		int num2 = 0;
		int diffLength = cycleConfig.Value.DiffLength;
		for (int i = 0; i < diffLength; i++)
		{
			int key = cycleConfig.Value.Diff(i).Value.Key;
			if (key < num)
			{
				num = key;
			}
			if (key > num2)
			{
				num2 = key;
			}
		}
		int result = 0;
		int curWorldLevel = ModelBase<WorldLevelModel>.Instance.CurWorldLevel;
		int num3;
		if (curWorldLevel < num)
		{
			num3 = num;
		}
		else if (curWorldLevel > num2)
		{
			num3 = num2;
		}
		else
		{
			num3 = curWorldLevel;
		}
		for (int j = 0; j < diffLength; j++)
		{
			DicIntInt? dicIntInt = cycleConfig.Value.Diff(j);
			if (dicIntInt != null && dicIntInt.Value.Key == num3)
			{
				result = dicIntInt.Value.Value;
				break;
			}
		}
		return result;
	}

	// Token: 0x060176F6 RID: 95990 RVA: 0x0067FE08 File Offset: 0x0067E008
	public int GetScoreRate()
	{
		RogueWeeklyCycle? cycleConfig = this.GetCycleConfig();
		if (cycleConfig == null)
		{
			return 0;
		}
		return (int)Math.Round((double)cycleConfig.Value.ScoreRate / 100.0);
	}

	// Token: 0x060176F7 RID: 95991 RVA: 0x0067FE48 File Offset: 0x0067E048
	public CommonDefine.ICountDown GetCycleCountDownData()
	{
		double num = this.GetCycleRemainTime();
		if (num <= 1.0)
		{
			num = 1.0;
		}
		CommonDefine.ETimeType value = (num >= 86400.0) ? CommonDefine.ETimeType.Day : ((num >= 3600.0) ? CommonDefine.ETimeType.Hour : CommonDefine.ETimeType.Minute);
		CommonDefine.ETimeType value2 = (num >= 86400.0) ? CommonDefine.ETimeType.Hour : ((num >= 3600.0) ? CommonDefine.ETimeType.Minute : CommonDefine.ETimeType.Second);
		return Singleton<TimeUtil>.Instance.GetCountDownDataFormat2(num, new CommonDefine.ETimeType?(value), new CommonDefine.ETimeType?(value2));
	}

	// Token: 0x060176F8 RID: 95992 RVA: 0x0067FECC File Offset: 0x0067E0CC
	public void OnQuestStateChange(int questId, QuestState state)
	{
		if (this.LocalConfig == null)
		{
			return;
		}
		int[] array = this.LocalConfig.Value.PreShowGuideQuest();
		bool flag = false;
		int[] array2 = array;
		for (int i = 0; i < array2.Length; i++)
		{
			if (array2[i] == questId)
			{
				flag = true;
				break;
			}
		}
		if (!flag)
		{
			return;
		}
		if (state < QuestState.Finish)
		{
			return;
		}
		Singleton<EventSystem>.Instance.Emit<int>(EEventName.RefreshCommonActivityRedDot, base.Id);
		Singleton<EventSystem>.Instance.Emit(EEventName.WeeklyRogueRedDotInfoRefresh);
	}

	// Token: 0x060176F9 RID: 95993 RVA: 0x0067FF44 File Offset: 0x0067E144
	protected override void PhraseEx(ActivityData data)
	{
		RogueWeeklyData rogueWeeklyData = data.RogueWeeklyData;
		if (rogueWeeklyData == null)
		{
			Singleton<Log>.Instance.Error(ELogModule.WeeklyRogue, ELogAuthor.LPH, "WeeklyRogueData无周常数据", default(ReadOnlySpan<ValueTuple<string, object>>));
			return;
		}
		if (this.CheckIfInShowTime())
		{
			ModelBase<WeeklyRogueModel>.Instance.CurrentActivityId = data.Id;
		}
		int cycleId = this.CycleId;
		this.CycleId = rogueWeeklyData.CycleId;
		if (cycleId != rogueWeeklyData.CycleId)
		{
			Singleton<EventSystem>.Instance.Emit(EEventName.WeeklyRogueCycleRefresh);
		}
		this.LastInstInfo = rogueWeeklyData.RogueWeeklyLastInfo;
		this.Score = rogueWeeklyData.Score;
		this.AwardsInfoList = new List<RogueWeeklyAward>();
		foreach (RogueWeeklyAward item in rogueWeeklyData.RogueWeeklyAwards)
		{
			this.AwardsInfoList.Add(item);
		}
		this.WorldLevel = rogueWeeklyData.CurWorldLevel;
		this.FreeCount = Math.Max(0, rogueWeeklyData.MaxFreeCount - rogueWeeklyData.UseFreeCount);
		this.FreeCountMax = rogueWeeklyData.MaxFreeCount;
		Singleton<EventSystem>.Instance.Emit(EEventName.WeeklyRogueRedDotInfoRefresh);
	}

	// Token: 0x060176FA RID: 95994 RVA: 0x00680068 File Offset: 0x0067E268
	protected override bool GetExDataFinishShowState()
	{
		if (!base.IsUnLock())
		{
			return false;
		}
		if (!base.GetPreGuideQuestFinishState())
		{
			return false;
		}
		if (this.AwardsInfoList == null)
		{
			return false;
		}
		using (List<RogueWeeklyAward>.Enumerator enumerator = this.AwardsInfoList.GetEnumerator())
		{
			while (enumerator.MoveNext())
			{
				if (enumerator.Current.SignState != SignState.IsReceive)
				{
					return false;
				}
			}
		}
		return true;
	}

	// Token: 0x0400B3B0 RID: 46000
	public int Score;

	// Token: 0x0400B3B1 RID: 46001
	[Nullable(2)]
	public RogueWeeklyLastInfo LastInstInfo;

	// Token: 0x0400B3B2 RID: 46002
	[Nullable(new byte[]
	{
		2,
		1
	})]
	public List<RogueWeeklyAward> AwardsInfoList;

	// Token: 0x0400B3B3 RID: 46003
	public int CycleId;

	// Token: 0x0400B3B4 RID: 46004
	public int WorldLevel;

	// Token: 0x0400B3B5 RID: 46005
	public int FreeCount;

	// Token: 0x0400B3B6 RID: 46006
	public int FreeCountMax;
}
