using System;

// Token: 0x02002881 RID: 10369
public interface ILevelLayoutGridData
{
	// Token: 0x17001ABE RID: 6846
	// (get) Token: 0x06014866 RID: 84070
	// (set) Token: 0x06014867 RID: 84071
	bool IsChosen { get; set; }

	// Token: 0x17001ABF RID: 6847
	// (get) Token: 0x06014868 RID: 84072
	// (set) Token: 0x06014869 RID: 84073
	bool IsAvailable { get; set; }

	// Token: 0x17001AC0 RID: 6848
	// (get) Token: 0x0601486A RID: 84074
	// (set) Token: 0x0601486B RID: 84075
	int LevelContent { get; set; }
}
