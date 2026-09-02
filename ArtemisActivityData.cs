using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using Aki.Protocol;

// Token: 0x020011A5 RID: 4517
public class ArtemisActivityData : ActivityBaseData
{
	// Token: 0x17000A00 RID: 2560
	// (get) Token: 0x060076C7 RID: 30407 RVA: 0x001F15A0 File Offset: 0x001EF7A0
	public int GetCacheActivityId
	{
		get
		{
			return this.CacheActivityId;
		}
	}

	// Token: 0x17000A01 RID: 2561
	// (get) Token: 0x060076C8 RID: 30408 RVA: 0x001F15A8 File Offset: 0x001EF7A8
	public int GetUnlockIndex
	{
		get
		{
			return this.UnlockIndex;
		}
	}

	// Token: 0x17000A02 RID: 2562
	// (get) Token: 0x060076C9 RID: 30409 RVA: 0x001F15B0 File Offset: 0x001EF7B0
	public int GetRewardedIndex
	{
		get
		{
			return this.RewardedIndex;
		}
	}

	// Token: 0x060076CA RID: 30410 RVA: 0x001F15B8 File Offset: 0x001EF7B8
	[NullableContext(1)]
	protected override void PhraseEx(ActivityData data)
	{
		if (data == null)
		{
			return;
		}
		ArtemisActivityInfo artemisActivityInfo = data.ArtemisActivityInfo;
		if (artemisActivityInfo == null)
		{
			return;
		}
		this.SetCacheActivityId(artemisActivityInfo.ActivityId);
		this.SetUnlockIndex(artemisActivityInfo.UnlockIndex);
		this.SetRewardedIndex(artemisActivityInfo.RewardedIndex);
	}

	// Token: 0x060076CB RID: 30411 RVA: 0x001F15F8 File Offset: 0x001EF7F8
	public void SetCacheActivityId(int id)
	{
		this.CacheActivityId = id;
	}

	// Token: 0x060076CC RID: 30412 RVA: 0x001F1601 File Offset: 0x001EF801
	public void SetUnlockIndex(int index)
	{
		this.UnlockIndex = index;
	}

	// Token: 0x060076CD RID: 30413 RVA: 0x001F160A File Offset: 0x001EF80A
	public void SetRewardedIndex(int index)
	{
		this.RewardedIndex = index;
	}

	// Token: 0x060076CE RID: 30414 RVA: 0x001F1614 File Offset: 0x001EF814
	public EArtemisState? GetArtemisStatus(int day)
	{
		int num = day + 1;
		if (num <= this.UnlockIndex)
		{
			if (num <= this.RewardedIndex)
			{
				return new EArtemisState?(EArtemisState.Rewarded);
			}
			if (num == this.RewardedIndex + 1)
			{
				return new EArtemisState?(EArtemisState.Unlock);
			}
		}
		return new EArtemisState?(EArtemisState.Lock);
	}

	// Token: 0x060076CF RID: 30415 RVA: 0x001F1656 File Offset: 0x001EF856
	public int GetArtemisRewardedIndex()
	{
		return Math.Max(this.RewardedIndex - 1, 0);
	}

	// Token: 0x060076D0 RID: 30416 RVA: 0x001F1666 File Offset: 0x001EF866
	public int GetArtemisUnlockIndex()
	{
		return Math.Max(this.UnlockIndex - 1, 0);
	}

	// Token: 0x060076D1 RID: 30417 RVA: 0x001F1678 File Offset: 0x001EF878
	public int GetArtemisDefaultOpenIndex()
	{
		int num;
		if (this.UnlockIndex > this.RewardedIndex)
		{
			num = this.RewardedIndex + 1;
		}
		else
		{
			num = this.UnlockIndex;
		}
		return Math.Max(num - 1, 0);
	}

	// Token: 0x060076D2 RID: 30418 RVA: 0x001F16AE File Offset: 0x001EF8AE
	public bool GetCanReceive()
	{
		return this.UnlockIndex > this.RewardedIndex;
	}

	// Token: 0x060076D3 RID: 30419 RVA: 0x001F16BE File Offset: 0x001EF8BE
	public override bool GetExDataRedPointShowState()
	{
		return this.GetCanReceive();
	}

	// Token: 0x060076D4 RID: 30420 RVA: 0x001F16C8 File Offset: 0x001EF8C8
	protected override bool GetExDataFinishShowState()
	{
		if (this.UnlockIndex == this.RewardedIndex)
		{
			IReadOnlyList<Artemis> artemisGroupByActivityId = ConfigBase<ArtemisActivityConfig>.Instance.GetArtemisGroupByActivityId(this.CacheActivityId);
			return this.UnlockIndex == ((artemisGroupByActivityId != null) ? artemisGroupByActivityId.Count : 0);
		}
		return false;
	}

	// Token: 0x04003975 RID: 14709
	private int CacheActivityId;

	// Token: 0x04003976 RID: 14710
	private int UnlockIndex;

	// Token: 0x04003977 RID: 14711
	private int RewardedIndex;
}
