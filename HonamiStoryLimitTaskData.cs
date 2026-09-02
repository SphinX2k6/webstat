using System;
using System.Runtime.CompilerServices;
using Aki.Config;
using Aki.Protocol;

// Token: 0x02001ED5 RID: 7893
[NullableContext(1)]
[Nullable(0)]
public class HonamiStoryLimitTaskData
{
	// Token: 0x0600E9C8 RID: 59848 RVA: 0x003F61DE File Offset: 0x003F43DE
	public HonamiStoryLimitTaskData(int configId)
	{
		this.ConfigId = configId;
	}

	// Token: 0x0600E9C9 RID: 59849 RVA: 0x003F61FB File Offset: 0x003F43FB
	private HonamiStoryLimitTask? GetConfig()
	{
		return ConfigBase<HonamiStoryConfig>.Instance.GetHonamiStoryLimitTaskConfig(this.ConfigId);
	}

	// Token: 0x0600E9CA RID: 59850 RVA: 0x003F620D File Offset: 0x003F440D
	public void UpdateData(ConditionTask data)
	{
		this.StatusInternal = TaskStateResolver.TaskState[(ActivityTaskState)data.Status];
		this.Current = data.Current;
		this.Target = data.Target;
	}

	// Token: 0x0600E9CB RID: 59851 RVA: 0x003F623D File Offset: 0x003F443D
	public void UpdateState(EActivityTaskState state)
	{
		this.StatusInternal = state;
	}

	// Token: 0x170011F5 RID: 4597
	// (get) Token: 0x0600E9CC RID: 59852 RVA: 0x003F6248 File Offset: 0x003F4448
	public int Id
	{
		get
		{
			return this.GetConfig().Value.Id;
		}
	}

	// Token: 0x170011F6 RID: 4598
	// (get) Token: 0x0600E9CD RID: 59853 RVA: 0x003F626C File Offset: 0x003F446C
	public int DropId
	{
		get
		{
			return this.GetConfig().Value.DropId;
		}
	}

	// Token: 0x170011F7 RID: 4599
	// (get) Token: 0x0600E9CE RID: 59854 RVA: 0x003F6290 File Offset: 0x003F4490
	public int JumpId
	{
		get
		{
			return this.GetConfig().Value.JumpId;
		}
	}

	// Token: 0x170011F8 RID: 4600
	// (get) Token: 0x0600E9CF RID: 59855 RVA: 0x003F62B3 File Offset: 0x003F44B3
	public EActivityTaskState Status
	{
		get
		{
			return this.StatusInternal;
		}
	}

	// Token: 0x170011F9 RID: 4601
	// (get) Token: 0x0600E9D0 RID: 59856 RVA: 0x003F62BC File Offset: 0x003F44BC
	public string TaskName
	{
		get
		{
			return this.GetConfig().Value.RewardName;
		}
	}

	// Token: 0x040070C3 RID: 28867
	public int ConfigId;

	// Token: 0x040070C4 RID: 28868
	private EActivityTaskState StatusInternal = EActivityTaskState.Active;

	// Token: 0x040070C5 RID: 28869
	public int Current;

	// Token: 0x040070C6 RID: 28870
	public int Target = 1;
}
