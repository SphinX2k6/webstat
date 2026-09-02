using System;
using System.Runtime.CompilerServices;

// Token: 0x02001C03 RID: 7171
[NullableContext(1)]
[Nullable(0)]
public class FloroRanchSelectRaceData
{
	// Token: 0x0600D08A RID: 53386 RVA: 0x00376188 File Offset: 0x00374388
	public FloroRanchSelectRaceData(int raceId, FloroRanchSubDungeonData subDungeonData, EFloroRanchActivityDataType activityDataType)
	{
		this.RaceId = raceId;
		this.SubDungeonData = subDungeonData;
		this.ActivityDataType = activityDataType;
	}

	// Token: 0x170010FB RID: 4347
	// (get) Token: 0x0600D08B RID: 53387 RVA: 0x003761A5 File Offset: 0x003743A5
	// (set) Token: 0x0600D08C RID: 53388 RVA: 0x003761AD File Offset: 0x003743AD
	public int RaceId { get; set; }

	// Token: 0x170010FC RID: 4348
	// (get) Token: 0x0600D08D RID: 53389 RVA: 0x003761B6 File Offset: 0x003743B6
	// (set) Token: 0x0600D08E RID: 53390 RVA: 0x003761BE File Offset: 0x003743BE
	public FloroRanchSubDungeonData SubDungeonData { get; set; }

	// Token: 0x170010FD RID: 4349
	// (get) Token: 0x0600D08F RID: 53391 RVA: 0x003761C7 File Offset: 0x003743C7
	// (set) Token: 0x0600D090 RID: 53392 RVA: 0x003761CF File Offset: 0x003743CF
	public EFloroRanchActivityDataType ActivityDataType { get; set; }
}
