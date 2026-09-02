using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using Aki.Protocol;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.Inventory;
using CSharpScript.Game.Module.Reward;

// Token: 0x02001589 RID: 5513
[NullableContext(1)]
[Nullable(0)]
public class ActivityRunData : ActivityExData
{
	// Token: 0x06009AF5 RID: 39669 RVA: 0x00289461 File Offset: 0x00287661
	public ActivityRunData(int activityId) : base(activityId)
	{
	}

	// Token: 0x17000D2E RID: 3374
	// (get) Token: 0x06009AF6 RID: 39670 RVA: 0x00289475 File Offset: 0x00287675
	public int Id
	{
		get
		{
			return this.IdInternal;
		}
	}

	// Token: 0x06009AF7 RID: 39671 RVA: 0x0028947D File Offset: 0x0028767D
	public int GetMaxScore()
	{
		return this.MaxScore;
	}

	// Token: 0x06009AF8 RID: 39672 RVA: 0x00289485 File Offset: 0x00287685
	public int GetMiniTime()
	{
		return this.MinTime;
	}

	// Token: 0x06009AF9 RID: 39673 RVA: 0x0028948D File Offset: 0x0028768D
	public bool GetRedPoint()
	{
		return this.GetIsShow() && (this.GetChallengeNewLocalRedPoint() || this.GetScoreRedPoint());
	}

	// Token: 0x06009AFA RID: 39674 RVA: 0x002894B0 File Offset: 0x002876B0
	public List<int> GetScoreArray()
	{
		List<int> list = new List<int>();
		if (this.ScoreRewardMap != null)
		{
			foreach (ValueTuple<int, int> valueTuple in this.ScoreRewardMap.Values)
			{
				list.Add(valueTuple.Item1);
			}
		}
		return list;
	}

	// Token: 0x06009AFB RID: 39675 RVA: 0x0028951C File Offset: 0x0028771C
	public int GetScoreIndexScore(int scoreIndex)
	{
		ValueTuple<int, int> valueTuple;
		if (this.ScoreRewardMap != null && this.ScoreRewardMap.TryGetValue(scoreIndex, out valueTuple))
		{
			return valueTuple.Item1;
		}
		return 0;
	}

	// Token: 0x06009AFC RID: 39676 RVA: 0x0028954C File Offset: 0x0028774C
	public List<TItem> GetScoreIndexPreviewItem(int index)
	{
		List<int> list = new List<int>();
		if (this.ScoreRewardMap != null)
		{
			list = new List<int>(this.ScoreRewardMap.Keys);
		}
		int count = list.Count;
		int num = 0;
		for (int i = 0; i < count; i++)
		{
			if (list[i] == index)
			{
				num = this.ScoreRewardMap[list[i]].Item2;
				break;
			}
		}
		List<TItem> list2 = new List<TItem>();
		if (num > 0)
		{
			DropPackage? dropPackage;
			Dictionary<int, int> dictionary = (ConfigBase<CSharpScript.Game.Module.Reward.RewardConfig>.Instance.GetDropPackage(num) != null) ? dropPackage.GetValueOrDefault().DropPreview() : null;
			if (dictionary != null)
			{
				foreach (KeyValuePair<int, int> keyValuePair in dictionary)
				{
					int num2;
					int num3;
					keyValuePair.Deconstruct(out num2, out num3);
					int itemId = num2;
					int count2 = num3;
					TItem item = new TItem(new InventoryDefine.GetItemData(itemId, 0), count2);
					list2.Add(item);
				}
			}
		}
		return list2;
	}

	// Token: 0x06009AFD RID: 39677 RVA: 0x00289660 File Offset: 0x00287860
	public int GetScoreIndex(int score)
	{
		List<int> list = new List<int>();
		if (this.ScoreRewardMap != null)
		{
			list = new List<int>(this.ScoreRewardMap.Keys);
		}
		int count = list.Count;
		for (int i = 0; i < count; i++)
		{
			ValueTuple<int, int> valueTuple;
			if (this.ScoreRewardMap != null && this.ScoreRewardMap.TryGetValue(i, out valueTuple) && score == valueTuple.Item1)
			{
				return i;
			}
		}
		return 0;
	}

	// Token: 0x06009AFE RID: 39678 RVA: 0x002896C4 File Offset: 0x002878C4
	public EActivityRunStateEnum GetScoreIndexCannotGetReward(int index)
	{
		List<int> list = new List<int>();
		if (this.ScoreRewardMap != null)
		{
			list = new List<int>(this.ScoreRewardMap.Keys);
		}
		long num = 0L;
		ValueTuple<int, int> valueTuple;
		if (this.ScoreRewardMap != null && this.ScoreRewardMap.TryGetValue(index, out valueTuple))
		{
			num = (long)valueTuple.Item1;
		}
		if ((long)this.MaxScore < num)
		{
			return EActivityRunStateEnum.UnFinished;
		}
		if (!this.TakenScoresIndex.Contains(list[index]))
		{
			return EActivityRunStateEnum.CanGetReward;
		}
		return EActivityRunStateEnum.HaveGetReward;
	}

	// Token: 0x06009AFF RID: 39679 RVA: 0x00289738 File Offset: 0x00287938
	private bool GetScoreRedPoint()
	{
		List<int> list = new List<int>();
		if (this.ScoreRewardMap != null)
		{
			list = new List<int>(this.ScoreRewardMap.Keys);
		}
		int count = list.Count;
		for (int i = 0; i < count; i++)
		{
			if (this.GetScoreIndexCannotGetReward(i) == EActivityRunStateEnum.CanGetReward)
			{
				return true;
			}
		}
		return false;
	}

	// Token: 0x06009B00 RID: 39680 RVA: 0x00289784 File Offset: 0x00287984
	public bool GetIfRewardAllFinished()
	{
		List<int> list = new List<int>();
		if (this.ScoreRewardMap != null)
		{
			list = new List<int>(this.ScoreRewardMap.Keys);
		}
		int count = list.Count;
		for (int i = 0; i < count; i++)
		{
			if (this.GetScoreIndexCannotGetReward(i) != EActivityRunStateEnum.HaveGetReward)
			{
				return false;
			}
		}
		return true;
	}

	// Token: 0x06009B01 RID: 39681 RVA: 0x002897D0 File Offset: 0x002879D0
	public string GetTitle()
	{
		return ConfigBase<ActivityRunConfig>.Instance.GetActivityRunTitle(this.IdInternal);
	}

	// Token: 0x06009B02 RID: 39682 RVA: 0x002897E2 File Offset: 0x002879E2
	public long GetMarkId()
	{
		return (long)ConfigBase<ActivityRunConfig>.Instance.GetActivityRunMarkId(this.IdInternal);
	}

	// Token: 0x06009B03 RID: 39683 RVA: 0x002897F5 File Offset: 0x002879F5
	public string GetBackgroundTexturePath()
	{
		return ConfigBase<ActivityRunConfig>.Instance.GetActivityRunTexture(this.IdInternal);
	}

	// Token: 0x06009B04 RID: 39684 RVA: 0x00289807 File Offset: 0x00287A07
	public void SetChallengeLocalRedPointState(bool state)
	{
		ModelBase<ActivityModel>.Instance.SaveActivityData(this.ActivityId, this.IdInternal, 0, 0, (state > false) ? 1 : 0);
		Singleton<EventSystem>.Instance.Emit<int>(EEventName.RefreshRunActivityRedDot, this.IdInternal);
		base.RefreshActivityRedPoint();
	}

	// Token: 0x06009B05 RID: 39685 RVA: 0x00289841 File Offset: 0x00287A41
	public bool GetChallengeNewLocalRedPoint()
	{
		return ModelBase<ActivityModel>.Instance.GetActivityCacheData(this.ActivityId, 1, this.IdInternal, 0, 0) == 1;
	}

	// Token: 0x06009B06 RID: 39686 RVA: 0x0028985F File Offset: 0x00287A5F
	public bool GetIsShow()
	{
		return this.IsOpen && this.CheckIfInShowTime();
	}

	// Token: 0x06009B07 RID: 39687 RVA: 0x00289874 File Offset: 0x00287A74
	public void SetIsOpen(bool state)
	{
		this.IsOpen = state;
	}

	// Token: 0x17000D2F RID: 3375
	// (get) Token: 0x06009B08 RID: 39688 RVA: 0x0028987D File Offset: 0x00287A7D
	public long BeginOpenTime
	{
		get
		{
			return this.BeginOpenTimeInternal;
		}
	}

	// Token: 0x17000D30 RID: 3376
	// (get) Token: 0x06009B09 RID: 39689 RVA: 0x00289885 File Offset: 0x00287A85
	public long EndOpenTime
	{
		get
		{
			return this.EndOpenTimeInternal;
		}
	}

	// Token: 0x06009B0A RID: 39690 RVA: 0x0028988D File Offset: 0x00287A8D
	public void OnGetScoreReward(int scoreIndex)
	{
		if (!this.TakenScoresIndex.Contains(scoreIndex))
		{
			this.TakenScoresIndex.Add(scoreIndex);
			Singleton<EventSystem>.Instance.Emit<int>(EEventName.RefreshRunActivityRedDot, this.IdInternal);
			base.RefreshActivityRedPoint();
		}
	}

	// Token: 0x06009B0B RID: 39691 RVA: 0x002898C8 File Offset: 0x00287AC8
	public bool CheckIfInShowTime()
	{
		if (this.BeginOpenTime == 0L && this.EndOpenTime == 0L)
		{
			return true;
		}
		double serverTime = Singleton<TimeUtil>.Instance.GetServerTime();
		return serverTime >= (double)this.BeginOpenTime && serverTime <= (double)this.EndOpenTime;
	}

	// Token: 0x06009B0C RID: 39692 RVA: 0x0028990C File Offset: 0x00287B0C
	public void OnChallengeEnd(ParkourChallengeEndNotify data)
	{
		this.CurrentScore = data.Score;
		this.CurrentTime = data.Duration;
		if (this.CurrentScore > this.MaxScore)
		{
			this.MaxScore = this.CurrentScore;
		}
		if (this.CurrentTime < this.MinTime || this.MinTime == 0)
		{
			this.MinTime = this.CurrentTime;
		}
		Singleton<EventSystem>.Instance.Emit<int>(EEventName.RefreshRunActivityRedDot, this.IdInternal);
		base.RefreshActivityRedPoint();
	}

	// Token: 0x06009B0D RID: 39693 RVA: 0x0028998C File Offset: 0x00287B8C
	public void Phrase(object data)
	{
		Aki.Protocol.ParkourChallenge parkourChallenge = data as Aki.Protocol.ParkourChallenge;
		if (parkourChallenge != null)
		{
			this.IdInternal = parkourChallenge.ChallengeId;
			this.TakenScoresIndex = new List<int>();
			if (parkourChallenge.TakenScoreIndex != null)
			{
				foreach (int item in parkourChallenge.TakenScoreIndex)
				{
					this.TakenScoresIndex.Add(item);
				}
			}
			this.MaxScore = parkourChallenge.MaxScore;
			this.MinTime = parkourChallenge.MinDuration;
		}
		else
		{
			ParkourActivityChallenge parkourActivityChallenge = data as ParkourActivityChallenge;
			if (parkourActivityChallenge != null)
			{
				this.IdInternal = parkourActivityChallenge.ChallengeId;
				this.BeginOpenTimeInternal = parkourActivityChallenge.BeginTime;
				this.EndOpenTimeInternal = parkourActivityChallenge.EndTime;
			}
		}
		if (this.ScoreRewardMap == null)
		{
			this.ScoreRewardMap = ConfigBase<ActivityRunConfig>.Instance.GetActivityRunScoreMap(this.IdInternal);
		}
		Singleton<EventSystem>.Instance.Emit<int>(EEventName.RefreshRunActivityRedDot, this.IdInternal);
		base.RefreshActivityRedPoint();
	}

	// Token: 0x04004757 RID: 18263
	private int IdInternal;

	// Token: 0x04004758 RID: 18264
	private List<int> TakenScoresIndex = new List<int>();

	// Token: 0x04004759 RID: 18265
	private int MaxScore;

	// Token: 0x0400475A RID: 18266
	private int MinTime;

	// Token: 0x0400475B RID: 18267
	private int CurrentScore;

	// Token: 0x0400475C RID: 18268
	private int CurrentTime;

	// Token: 0x0400475D RID: 18269
	private bool IsOpen;

	// Token: 0x0400475E RID: 18270
	private long BeginOpenTimeInternal;

	// Token: 0x0400475F RID: 18271
	private long EndOpenTimeInternal;

	// Token: 0x04004760 RID: 18272
	[Nullable(new byte[]
	{
		2,
		0
	})]
	private Dictionary<int, ValueTuple<int, int>> ScoreRewardMap;
}
