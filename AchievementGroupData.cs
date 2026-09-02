using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using Aki.Protocol;
using CSharpScript.Game.Module.Inventory;

// Token: 0x02000FD0 RID: 4048
[NullableContext(1)]
[Nullable(0)]
public class AchievementGroupData
{
	// Token: 0x1700082B RID: 2091
	// (get) Token: 0x0600681C RID: 26652 RVA: 0x001B2040 File Offset: 0x001B0240
	// (set) Token: 0x0600681D RID: 26653 RVA: 0x001B2048 File Offset: 0x001B0248
	public long UUID { get; set; }

	// Token: 0x0600681E RID: 26654 RVA: 0x001B2051 File Offset: 0x001B0251
	public void OnSetUUID(long uuid)
	{
		this.Id = (int)this.UUID;
	}

	// Token: 0x0600681F RID: 26655 RVA: 0x001B2060 File Offset: 0x001B0260
	public AchievementGroupData(int id)
	{
		this.Id = id;
	}

	// Token: 0x06006820 RID: 26656 RVA: 0x001B2093 File Offset: 0x001B0293
	public void Phrase(AchievementGroupEntry message)
	{
		this.HasGetRewardState = new bool?(message.IsReceive);
		this.FinishTime = new long?((long)((ulong)message.FinishTime));
		this.IfUnLock = true;
	}

	// Token: 0x06006821 RID: 26657 RVA: 0x001B20BF File Offset: 0x001B02BF
	public int GetId()
	{
		return this.Id;
	}

	// Token: 0x06006822 RID: 26658 RVA: 0x001B20C7 File Offset: 0x001B02C7
	public int GetSort()
	{
		return ConfigBase<AchievementConfig>.Instance.GetAchievementGroupSort(this.Id);
	}

	// Token: 0x06006823 RID: 26659 RVA: 0x001B20D9 File Offset: 0x001B02D9
	public string GetTitle()
	{
		return ConfigBase<AchievementConfig>.Instance.GetAchievementGroupTitle(this.Id);
	}

	// Token: 0x06006824 RID: 26660 RVA: 0x001B20EB File Offset: 0x001B02EB
	public string GetTitleId()
	{
		return ConfigBase<AchievementConfig>.Instance.GetAchievementGroupTitleId(this.Id);
	}

	// Token: 0x06006825 RID: 26661 RVA: 0x001B20FD File Offset: 0x001B02FD
	public string GetTexture()
	{
		return ConfigBase<AchievementConfig>.Instance.GetAchievementGroupIcon(this.Id);
	}

	// Token: 0x06006826 RID: 26662 RVA: 0x001B210F File Offset: 0x001B030F
	public string GetSmallIcon()
	{
		return ConfigBase<AchievementConfig>.Instance.GetAchievementGroupSmallIcon(this.Id);
	}

	// Token: 0x06006827 RID: 26663 RVA: 0x001B2121 File Offset: 0x001B0321
	public string GetBackgroundIcon()
	{
		return ConfigBase<AchievementConfig>.Instance.GetAchievementGroupBackgroundIcon(this.Id);
	}

	// Token: 0x06006828 RID: 26664 RVA: 0x001B2133 File Offset: 0x001B0333
	public int GetCategory()
	{
		return ConfigBase<AchievementConfig>.Instance.GetAchievementGroupCategory(this.Id);
	}

	// Token: 0x06006829 RID: 26665 RVA: 0x001B2145 File Offset: 0x001B0345
	public long? GetFinishTime()
	{
		return this.FinishTime;
	}

	// Token: 0x0600682A RID: 26666 RVA: 0x001B214D File Offset: 0x001B034D
	public bool GetShowState()
	{
		return this.IfUnLock && ConfigBase<AchievementConfig>.Instance.GetAchievementGroupEnable(this.Id);
	}

	// Token: 0x0600682B RID: 26667 RVA: 0x001B2170 File Offset: 0x001B0370
	public List<TItem> GetRewards()
	{
		if (!this.RewardInitState)
		{
			this.Rewards = new List<TItem>();
			DropPackage? achievementGroupReward = ConfigBase<AchievementConfig>.Instance.GetAchievementGroupReward(this.Id);
			if (achievementGroupReward != null)
			{
				int dropPreviewLength = achievementGroupReward.Value.DropPreviewLength;
				for (int i = 0; i < dropPreviewLength; i++)
				{
					DicIntInt? dicIntInt = achievementGroupReward.Value.DropPreview(i);
					int key = dicIntInt.Value.Key;
					int value = dicIntInt.Value.Value;
					TItem item = new TItem(new InventoryDefine.GetItemData(key, 0), value);
					this.Rewards.Add(item);
				}
			}
			this.RewardInitState = true;
		}
		return this.Rewards;
	}

	// Token: 0x0600682C RID: 26668 RVA: 0x001B222A File Offset: 0x001B042A
	public bool SmallItemRedPoint()
	{
		return this.RedPoint() || ModelBase<AchievementModel>.Instance.GetGroupAchievementsIsRedDot(this.Id);
	}

	// Token: 0x0600682D RID: 26669 RVA: 0x001B2246 File Offset: 0x001B0446
	public bool RedPoint()
	{
		return this.GetFinishState() == EAchievementStateEnum.CanGetReward && this.GetShowState() && this.GetRewards().Count > 0;
	}

	// Token: 0x0600682E RID: 26670 RVA: 0x001B2270 File Offset: 0x001B0470
	public int GetCurrentProgress()
	{
		List<AchievementData> groupAchievements = ModelBase<AchievementModel>.Instance.GetGroupAchievements(this.Id, true);
		int num = 0;
		using (List<AchievementData>.Enumerator enumerator = groupAchievements.GetEnumerator())
		{
			while (enumerator.MoveNext())
			{
				if (enumerator.Current.GetFinishState() != EAchievementStateEnum.UnFinished)
				{
					num++;
				}
			}
		}
		return num;
	}

	// Token: 0x0600682F RID: 26671 RVA: 0x001B22D4 File Offset: 0x001B04D4
	public int GetMaxProgress()
	{
		List<AchievementData> groupAchievements = ModelBase<AchievementModel>.Instance.GetGroupAchievements(this.Id, true);
		int num = 0;
		using (List<AchievementData>.Enumerator enumerator = groupAchievements.GetEnumerator())
		{
			while (enumerator.MoveNext())
			{
				if (enumerator.Current.GetShowState())
				{
					num++;
				}
			}
		}
		return num;
	}

	// Token: 0x06006830 RID: 26672 RVA: 0x001B2338 File Offset: 0x001B0538
	public EAchievementStateEnum GetFinishState()
	{
		if (this.HasGetRewardState.GetValueOrDefault())
		{
			return EAchievementStateEnum.HaveGetReward;
		}
		long? finishTime = this.FinishTime;
		long num = 0L;
		if (finishTime.GetValueOrDefault() > num & finishTime != null)
		{
			return EAchievementStateEnum.CanGetReward;
		}
		return EAchievementStateEnum.UnFinished;
	}

	// Token: 0x06006831 RID: 26673 RVA: 0x001B2378 File Offset: 0x001B0578
	public string GetAchievementGroupProgress()
	{
		int num = 0;
		int num2 = 0;
		foreach (AchievementData achievementData in ModelBase<AchievementModel>.Instance.GetGroupAchievements(this.Id, false))
		{
			if (achievementData.GetId() == 200101)
			{
				achievementData.PrintUnsafeAddress();
			}
			EAchievementStateEnum finishState = achievementData.GetFinishState();
			if ((!achievementData.GetHiddenState() || finishState != EAchievementStateEnum.UnFinished) && achievementData.GetMaxProgress() != null)
			{
				num++;
				if (finishState != EAchievementStateEnum.UnFinished)
				{
					num2++;
				}
			}
		}
		int value = (int)Math.Round((double)num2 * 100.0 / (double)num);
		DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(1, 1);
		defaultInterpolatedStringHandler.AppendFormatted<int>(value);
		defaultInterpolatedStringHandler.AppendLiteral("%");
		return defaultInterpolatedStringHandler.ToStringAndClear();
	}

	// Token: 0x04003198 RID: 12696
	private bool? HasGetRewardState = new bool?(false);

	// Token: 0x04003199 RID: 12697
	private long? FinishTime = new long?(0L);

	// Token: 0x0400319A RID: 12698
	private List<TItem> Rewards = new List<TItem>();

	// Token: 0x0400319B RID: 12699
	private bool RewardInitState;

	// Token: 0x0400319C RID: 12700
	private bool IfUnLock;

	// Token: 0x0400319D RID: 12701
	private int Id;
}
