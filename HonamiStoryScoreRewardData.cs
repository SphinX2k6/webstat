using System;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Module.HonamiStory;

// Token: 0x02001EE5 RID: 7909
[NullableContext(1)]
[Nullable(0)]
public class HonamiStoryScoreRewardData
{
	// Token: 0x0600EA66 RID: 60006 RVA: 0x003F9969 File Offset: 0x003F7B69
	public HonamiStoryScoreRewardData(int configId)
	{
		this.ConfigId = configId;
	}

	// Token: 0x0600EA67 RID: 60007 RVA: 0x003F9978 File Offset: 0x003F7B78
	private HonamiStoryScoreReward? GetConfig()
	{
		return ConfigBase<HonamiStoryConfig>.Instance.GetHonamiStoryScoreRewardConfig(this.ConfigId);
	}

	// Token: 0x0600EA68 RID: 60008 RVA: 0x003F998A File Offset: 0x003F7B8A
	public void UpdateState(EHonamiStoryCollectState state)
	{
		this.StateInternal = state;
	}

	// Token: 0x1700120E RID: 4622
	// (get) Token: 0x0600EA69 RID: 60009 RVA: 0x003F9993 File Offset: 0x003F7B93
	public EHonamiStoryCollectState State
	{
		get
		{
			return this.StateInternal;
		}
	}

	// Token: 0x1700120F RID: 4623
	// (get) Token: 0x0600EA6A RID: 60010 RVA: 0x003F999C File Offset: 0x003F7B9C
	public int Id
	{
		get
		{
			return this.GetConfig().Value.Id;
		}
	}

	// Token: 0x17001210 RID: 4624
	// (get) Token: 0x0600EA6B RID: 60011 RVA: 0x003F99C0 File Offset: 0x003F7BC0
	public string Name
	{
		get
		{
			return this.GetConfig().Value.Name;
		}
	}

	// Token: 0x17001211 RID: 4625
	// (get) Token: 0x0600EA6C RID: 60012 RVA: 0x003F99E4 File Offset: 0x003F7BE4
	public string LockTip
	{
		get
		{
			return this.GetConfig().Value.LockTip;
		}
	}

	// Token: 0x17001212 RID: 4626
	// (get) Token: 0x0600EA6D RID: 60013 RVA: 0x003F9A08 File Offset: 0x003F7C08
	public int Score
	{
		get
		{
			return this.GetConfig().Value.Score;
		}
	}

	// Token: 0x17001213 RID: 4627
	// (get) Token: 0x0600EA6E RID: 60014 RVA: 0x003F9A2C File Offset: 0x003F7C2C
	public int DropId
	{
		get
		{
			return this.GetConfig().Value.DropId;
		}
	}

	// Token: 0x040070FD RID: 28925
	public int ConfigId;

	// Token: 0x040070FE RID: 28926
	private EHonamiStoryCollectState StateInternal;
}
