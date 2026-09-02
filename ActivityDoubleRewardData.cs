using System;
using System.Runtime.CompilerServices;
using Aki.Config;
using Aki.Protocol;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.AdventureGuide;
using CSharpScript.Game.Ui;

// Token: 0x02001316 RID: 4886
[NullableContext(1)]
[Nullable(0)]
public class ActivityDoubleRewardData : ActivityBaseData
{
	// Token: 0x060084FB RID: 34043 RVA: 0x002309CD File Offset: 0x0022EBCD
	protected override void PhraseEx(ActivityData data)
	{
		int leftUpCount = this.LeftUpCount;
		this.ConsumeUpCountInternal = data.DoubleInstActivityReward.GetDoubleInstRwdCount;
		if (leftUpCount != this.LeftUpCount && this.LeftUpCount == 0)
		{
			ControllerBase<AdventureGuideController>.Instance.UpdateAdventureNewSoundAreaTabRedDot();
		}
	}

	// Token: 0x060084FC RID: 34044 RVA: 0x00230A00 File Offset: 0x0022EC00
	public override bool GetExDataRedPointShowState()
	{
		if (this.LeftUpCount == 0)
		{
			return false;
		}
		long currentTime = this.GetCurrentTime();
		return ModelBase<ActivityModel>.Instance.GetActivityCacheData(base.Id, 0, (int)currentTime, 0, 0) != 1;
	}

	// Token: 0x060084FD RID: 34045 RVA: 0x00230A39 File Offset: 0x0022EC39
	protected override bool GetExDataFinishShowState()
	{
		return this.LeftUpCount == 0;
	}

	// Token: 0x060084FE RID: 34046 RVA: 0x00230A44 File Offset: 0x0022EC44
	private long GetCurrentTime()
	{
		DateTime dateTime = Singleton<TimeUtil>.Instance.GetDataFromTimeStamp(Singleton<TimeUtil>.Instance.GetServerTime());
		if (dateTime.Hour < Singleton<TimeUtil>.Instance.CrossDayHour)
		{
			dateTime = dateTime.AddDays(-1.0);
		}
		return dateTime.Date.AddHours((double)Singleton<TimeUtil>.Instance.CrossDayHour).Ticks / 10000L;
	}

	// Token: 0x060084FF RID: 34047 RVA: 0x00230AB3 File Offset: 0x0022ECB3
	public override bool NeedSelfControlFirstRedPoint()
	{
		return false;
	}

	// Token: 0x06008500 RID: 34048 RVA: 0x00230AB8 File Offset: 0x0022ECB8
	public void ReadDailyRedDot()
	{
		long currentTime = this.GetCurrentTime();
		ModelBase<ActivityModel>.Instance.SaveActivityData(base.Id, (int)currentTime, 0, 0, 1);
		Singleton<EventSystem>.Instance.Emit<int>(EEventName.RefreshCommonActivityRedDot, base.Id);
	}

	// Token: 0x17000B3B RID: 2875
	// (get) Token: 0x06008501 RID: 34049 RVA: 0x00230AF7 File Offset: 0x0022ECF7
	public int LeftUpCount
	{
		get
		{
			return this.TotalUpCount - this.ConsumeUpCountInternal;
		}
	}

	// Token: 0x17000B3C RID: 2876
	// (get) Token: 0x06008502 RID: 34050 RVA: 0x00230B08 File Offset: 0x0022ED08
	private int TotalUpCount
	{
		get
		{
			return ConfigDoubleRewardActivityById.GetConfig(base.Id, true).Value.Count;
		}
	}

	// Token: 0x17000B3D RID: 2877
	// (get) Token: 0x06008503 RID: 34051 RVA: 0x00230B34 File Offset: 0x0022ED34
	public EActivityDoubleRewardType SubType
	{
		get
		{
			return (EActivityDoubleRewardType)ConfigDoubleRewardActivityById.GetConfig(base.Id, true).Value.Type;
		}
	}

	// Token: 0x17000B3E RID: 2878
	// (get) Token: 0x06008504 RID: 34052 RVA: 0x00230B60 File Offset: 0x0022ED60
	public string Prefab
	{
		get
		{
			return ConfigDoubleRewardActivityById.GetConfig(base.Id, true).Value.Prefab;
		}
	}

	// Token: 0x17000B3F RID: 2879
	// (get) Token: 0x06008505 RID: 34053 RVA: 0x00230B8C File Offset: 0x0022ED8C
	public EDungeonType[] AdventureGuideUpList
	{
		get
		{
			if (this.UpDungeonTypeList == null)
			{
				switch (this.SubType)
				{
				case EActivityDoubleRewardType.Exp:
					this.UpDungeonTypeList = new EDungeonType[]
					{
						EDungeonType.Simulation
					};
					break;
				case EActivityDoubleRewardType.Growth:
					this.UpDungeonTypeList = new EDungeonType[]
					{
						EDungeonType.Mat,
						EDungeonType.Simulation
					};
					break;
				case EActivityDoubleRewardType.Sound:
					this.UpDungeonTypeList = new EDungeonType[]
					{
						EDungeonType.NoSoundArea
					};
					break;
				default:
					this.UpDungeonTypeList = new EDungeonType[]
					{
						EDungeonType.Simulation
					};
					break;
				}
			}
			return this.UpDungeonTypeList;
		}
	}

	// Token: 0x06008506 RID: 34054 RVA: 0x00230C14 File Offset: 0x0022EE14
	public int[] GetDungeonUpList(bool isInstance)
	{
		switch (this.SubType)
		{
		case EActivityDoubleRewardType.Exp:
			return new int[]
			{
				1
			};
		case EActivityDoubleRewardType.Growth:
			return new int[]
			{
				1,
				2
			};
		case EActivityDoubleRewardType.Sound:
			if (!isInstance)
			{
				return new int[]
				{
					3
				};
			}
			return new int[]
			{
				6
			};
		default:
			return new int[0];
		}
	}

	// Token: 0x06008507 RID: 34055 RVA: 0x00230C77 File Offset: 0x0022EE77
	[return: Nullable(new byte[]
	{
		0,
		1
	})]
	public ValueTuple<string, int, int> GetNumTxtAndParam()
	{
		return new ValueTuple<string, int, int>((this.LeftUpCount > 0) ? "Reward_doubling_time" : "Reward_doubling_end", this.LeftUpCount, this.TotalUpCount);
	}

	// Token: 0x06008508 RID: 34056 RVA: 0x00230C9F File Offset: 0x0022EE9F
	public Tuple<string, int, int> GetFullTipNumTxtAndParam()
	{
		return new Tuple<string, int, int>((this.LeftUpCount > 0) ? "Reward_doubling_tips" : "Reward_doubling_end_tips", this.LeftUpCount, this.TotalUpCount);
	}

	// Token: 0x06008509 RID: 34057 RVA: 0x00230CC8 File Offset: 0x0022EEC8
	public string GetFullTip()
	{
		Tuple<string, int, int> fullTipNumTxtAndParam = this.GetFullTipNumTxtAndParam();
		return StringUtils.FormatStaticBuilder(ConfigMultiTextLang.GetLocalTextNew(fullTipNumTxtAndParam.Item1, null), new object[]
		{
			fullTipNumTxtAndParam.Item2,
			fullTipNumTxtAndParam.Item3
		});
	}

	// Token: 0x0600850A RID: 34058 RVA: 0x00230D0F File Offset: 0x0022EF0F
	public void JumpToDungeon()
	{
		ControllerBase<AdventureGuideController>.Instance.OpenGuideView(new EUiTabViewName?(EUiTabViewName.NewSoundAreaView), new int?((int)this.AdventureGuideUpList[0]), null);
	}

	// Token: 0x04003F09 RID: 16137
	private int ConsumeUpCountInternal;

	// Token: 0x04003F0A RID: 16138
	[Nullable(2)]
	private EDungeonType[] UpDungeonTypeList;
}
