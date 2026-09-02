using System;

// Token: 0x02002AC6 RID: 10950
public class SurvivorsMilestoneData
{
	// Token: 0x06015E89 RID: 89737 RVA: 0x00616300 File Offset: 0x00614500
	public SurvivorsMilestoneData(int id, int sortId, int goal, int dropId, bool isGot = false)
	{
		this.Id = id;
		this.SortId = sortId;
		this.Goal = goal;
		this.DropId = dropId;
		this.IsGot = isGot;
	}

	// Token: 0x06015E8A RID: 89738 RVA: 0x0061632D File Offset: 0x0061452D
	public bool IsReceivable(int currentPoint)
	{
		return this.IsAchieved(currentPoint) && !this.IsGot;
	}

	// Token: 0x06015E8B RID: 89739 RVA: 0x00616343 File Offset: 0x00614543
	public bool IsAchieved(int currentPoint)
	{
		return this.Goal <= currentPoint;
	}

	// Token: 0x0400A84D RID: 43085
	public int Id;

	// Token: 0x0400A84E RID: 43086
	public int SortId;

	// Token: 0x0400A84F RID: 43087
	public int Goal;

	// Token: 0x0400A850 RID: 43088
	public int DropId;

	// Token: 0x0400A851 RID: 43089
	public bool IsGot;
}
