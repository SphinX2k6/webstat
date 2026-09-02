using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game.LevelGamePlay.LevelConditions;

// Token: 0x02002747 RID: 10055
[NullableContext(1)]
public interface IRandomPlotCondition
{
	// Token: 0x1700195E RID: 6494
	// (get) Token: 0x06013DB2 RID: 81330
	// (set) Token: 0x06013DB3 RID: 81331
	int ConditionGroupId { get; set; }

	// Token: 0x1700195F RID: 6495
	// (get) Token: 0x06013DB4 RID: 81332
	// (set) Token: 0x06013DB5 RID: 81333
	ConditionPassCallback Callback { get; set; }
}
