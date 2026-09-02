using System;
using System.Runtime.CompilerServices;
using Aki.Config;
using Aki.Protocol;

// Token: 0x02001ED7 RID: 7895
[NullableContext(1)]
[Nullable(0)]
public class HonamiStoryPermanentTaskData
{
	// Token: 0x0600E9DB RID: 59867 RVA: 0x003F63CF File Offset: 0x003F45CF
	public HonamiStoryPermanentTaskData(int configId)
	{
		this.ConfigId = configId;
	}

	// Token: 0x0600E9DC RID: 59868 RVA: 0x003F63EC File Offset: 0x003F45EC
	private HonamiStoryResidentTask? GetConfig()
	{
		return ConfigBase<HonamiStoryConfig>.Instance.GetHonamiStoryPermanentTaskConfig(this.ConfigId);
	}

	// Token: 0x0600E9DD RID: 59869 RVA: 0x003F63FE File Offset: 0x003F45FE
	public void UpdateData(ConditionTask data)
	{
		this.StatusInternal = TaskStateResolver.TaskState[(ActivityTaskState)data.Status];
		this.Current = data.Current;
		this.Target = data.Target;
	}

	// Token: 0x0600E9DE RID: 59870 RVA: 0x003F642E File Offset: 0x003F462E
	public void UpdateState(EActivityTaskState state)
	{
		this.StatusInternal = state;
	}

	// Token: 0x17001202 RID: 4610
	// (get) Token: 0x0600E9DF RID: 59871 RVA: 0x003F6438 File Offset: 0x003F4638
	public int Id
	{
		get
		{
			return this.GetConfig().Value.Id;
		}
	}

	// Token: 0x17001203 RID: 4611
	// (get) Token: 0x0600E9E0 RID: 59872 RVA: 0x003F645C File Offset: 0x003F465C
	public int DropId
	{
		get
		{
			return this.GetConfig().Value.DropId;
		}
	}

	// Token: 0x17001204 RID: 4612
	// (get) Token: 0x0600E9E1 RID: 59873 RVA: 0x003F6480 File Offset: 0x003F4680
	public int JumpId
	{
		get
		{
			return this.GetConfig().Value.JumpId;
		}
	}

	// Token: 0x17001205 RID: 4613
	// (get) Token: 0x0600E9E2 RID: 59874 RVA: 0x003F64A3 File Offset: 0x003F46A3
	public EActivityTaskState Status
	{
		get
		{
			return this.StatusInternal;
		}
	}

	// Token: 0x17001206 RID: 4614
	// (get) Token: 0x0600E9E3 RID: 59875 RVA: 0x003F64AC File Offset: 0x003F46AC
	public string TaskName
	{
		get
		{
			return this.GetConfig().Value.RewardName;
		}
	}

	// Token: 0x040070C9 RID: 28873
	public int ConfigId;

	// Token: 0x040070CA RID: 28874
	private EActivityTaskState StatusInternal = EActivityTaskState.Active;

	// Token: 0x040070CB RID: 28875
	public int Current;

	// Token: 0x040070CC RID: 28876
	public int Target = 1;
}
