using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Module.Reward;

// Token: 0x02001BC3 RID: 7107
public class FloroRanchMilestoneData
{
	// Token: 0x0600CED0 RID: 52944 RVA: 0x00371293 File Offset: 0x0036F493
	public FloroRanchMilestoneData(FloroRanchReward config)
	{
		this.Config = config;
		this.RewardList = ConfigBase<CSharpScript.Game.Module.Reward.RewardConfig>.Instance.GetDropPackagePreviewItemList(config.DropId);
	}

	// Token: 0x170010AF RID: 4271
	// (get) Token: 0x0600CED2 RID: 52946 RVA: 0x003712CD File Offset: 0x0036F4CD
	// (set) Token: 0x0600CED1 RID: 52945 RVA: 0x003712C4 File Offset: 0x0036F4C4
	public bool IsReceive
	{
		get
		{
			return this.IsReceiveInternal;
		}
		set
		{
			this.IsReceiveInternal = value;
		}
	}

	// Token: 0x170010B0 RID: 4272
	// (get) Token: 0x0600CED4 RID: 52948 RVA: 0x003712DE File Offset: 0x0036F4DE
	// (set) Token: 0x0600CED3 RID: 52947 RVA: 0x003712D5 File Offset: 0x0036F4D5
	public bool IsFinished
	{
		get
		{
			return this.IsFinishedInterval;
		}
		set
		{
			this.IsFinishedInterval = value;
		}
	}

	// Token: 0x170010B1 RID: 4273
	// (get) Token: 0x0600CED5 RID: 52949 RVA: 0x003712E6 File Offset: 0x0036F4E6
	public bool IsReceivable
	{
		get
		{
			return this.IsFinishedInterval && !this.IsReceiveInternal;
		}
	}

	// Token: 0x170010B2 RID: 4274
	// (get) Token: 0x0600CED6 RID: 52950 RVA: 0x003712FC File Offset: 0x0036F4FC
	public int Id
	{
		get
		{
			return this.Config.Id;
		}
	}

	// Token: 0x170010B3 RID: 4275
	// (get) Token: 0x0600CED7 RID: 52951 RVA: 0x00371318 File Offset: 0x0036F518
	public int Goal
	{
		get
		{
			return this.Config.NeedNum;
		}
	}

	// Token: 0x04006294 RID: 25236
	private readonly FloroRanchReward Config;

	// Token: 0x04006295 RID: 25237
	private bool IsReceiveInternal;

	// Token: 0x04006296 RID: 25238
	private bool IsFinishedInterval;

	// Token: 0x04006297 RID: 25239
	[Nullable(1)]
	public List<TItem> RewardList = new List<TItem>();
}
