using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Module.Reward;

// Token: 0x0200131F RID: 4895
[NullableContext(1)]
[Nullable(0)]
public class FightPhotoTaskData
{
	// Token: 0x06008589 RID: 34185 RVA: 0x0023278F File Offset: 0x0023098F
	public FightPhotoTaskData(PhotoFightReward config)
	{
		this.Config = config;
		this.RewardList = ConfigBase<CSharpScript.Game.Module.Reward.RewardConfig>.Instance.GetDropPackagePreviewItemList(config.RewardId);
	}

	// Token: 0x17000B65 RID: 2917
	// (get) Token: 0x0600858A RID: 34186 RVA: 0x002327C7 File Offset: 0x002309C7
	public bool IsFinished
	{
		get
		{
			return this.Status == EActivityTaskState.FinishedAndClaimed;
		}
	}

	// Token: 0x17000B66 RID: 2918
	// (get) Token: 0x0600858B RID: 34187 RVA: 0x002327D2 File Offset: 0x002309D2
	public bool IsUnclaimed
	{
		get
		{
			return this.Status == EActivityTaskState.FinishedAndUnclaimed;
		}
	}

	// Token: 0x17000B67 RID: 2919
	// (get) Token: 0x0600858C RID: 34188 RVA: 0x002327DD File Offset: 0x002309DD
	public bool IsDoing
	{
		get
		{
			return this.Status == EActivityTaskState.Active;
		}
	}

	// Token: 0x17000B68 RID: 2920
	// (get) Token: 0x0600858D RID: 34189 RVA: 0x002327E8 File Offset: 0x002309E8
	public int Id
	{
		get
		{
			return this.Config.Id;
		}
	}

	// Token: 0x17000B69 RID: 2921
	// (get) Token: 0x0600858E RID: 34190 RVA: 0x00232804 File Offset: 0x00230A04
	public int TabType
	{
		get
		{
			return this.Config.TabId;
		}
	}

	// Token: 0x17000B6A RID: 2922
	// (get) Token: 0x0600858F RID: 34191 RVA: 0x00232820 File Offset: 0x00230A20
	public string TaskName
	{
		get
		{
			return this.Config.Title;
		}
	}

	// Token: 0x04003F2B RID: 16171
	private readonly PhotoFightReward Config;

	// Token: 0x04003F2C RID: 16172
	public EActivityTaskState Status = EActivityTaskState.Active;

	// Token: 0x04003F2D RID: 16173
	public List<TItem> RewardList = new List<TItem>();
}
