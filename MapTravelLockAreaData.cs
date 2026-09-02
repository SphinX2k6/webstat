using System;

// Token: 0x0200138A RID: 5002
public class MapTravelLockAreaData
{
	// Token: 0x06008982 RID: 35202 RVA: 0x00242F9C File Offset: 0x0024119C
	public MapTravelLockAreaData(int areaId)
	{
		this.AreaId = areaId;
	}

	// Token: 0x17000BB9 RID: 3001
	// (get) Token: 0x06008983 RID: 35203 RVA: 0x00242FAB File Offset: 0x002411AB
	public int AreaId { get; }

	// Token: 0x17000BBA RID: 3002
	// (get) Token: 0x06008984 RID: 35204 RVA: 0x00242FB3 File Offset: 0x002411B3
	// (set) Token: 0x06008985 RID: 35205 RVA: 0x00242FBB File Offset: 0x002411BB
	public int ConditionGroupId { get; set; }

	// Token: 0x17000BBB RID: 3003
	// (get) Token: 0x06008986 RID: 35206 RVA: 0x00242FC4 File Offset: 0x002411C4
	// (set) Token: 0x06008987 RID: 35207 RVA: 0x00242FCC File Offset: 0x002411CC
	public int JumpId { get; set; }
}
