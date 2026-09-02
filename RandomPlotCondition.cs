using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game.LevelGamePlay.LevelConditions;

// Token: 0x02002748 RID: 10056
[NullableContext(1)]
[Nullable(0)]
public class RandomPlotCondition : IRandomPlotCondition
{
	// Token: 0x17001960 RID: 6496
	// (get) Token: 0x06013DB6 RID: 81334 RVA: 0x00588F36 File Offset: 0x00587136
	// (set) Token: 0x06013DB7 RID: 81335 RVA: 0x00588F3E File Offset: 0x0058713E
	public int ConditionGroupId { get; set; }

	// Token: 0x17001961 RID: 6497
	// (get) Token: 0x06013DB8 RID: 81336 RVA: 0x00588F47 File Offset: 0x00587147
	// (set) Token: 0x06013DB9 RID: 81337 RVA: 0x00588F4F File Offset: 0x0058714F
	public ConditionPassCallback Callback { get; set; }
}
