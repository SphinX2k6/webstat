using System;
using System.Runtime.CompilerServices;

// Token: 0x02003282 RID: 12930
public class MoveStateInfo
{
	// Token: 0x0601B106 RID: 110854 RVA: 0x0081AF4C File Offset: 0x0081914C
	[NullableContext(1)]
	public MoveStateInfo DeepCopy()
	{
		return new MoveStateInfo
		{
			TimeRatio = this.TimeRatio,
			PathRatio = this.PathRatio,
			PathDeltaSign = this.PathDeltaSign,
			IsFinish = this.IsFinish,
			ElapsedTime = this.ElapsedTime
		};
	}

	// Token: 0x0400DBF8 RID: 56312
	public double ElapsedTime;

	// Token: 0x0400DBF9 RID: 56313
	public double TimeRatio;

	// Token: 0x0400DBFA RID: 56314
	public double PathRatio;

	// Token: 0x0400DBFB RID: 56315
	public int PathDeltaSign = 1;

	// Token: 0x0400DBFC RID: 56316
	public bool IsFinish;
}
