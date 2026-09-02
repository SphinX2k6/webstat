using System;
using System.Runtime.CompilerServices;

// Token: 0x02002111 RID: 8465
[NullableContext(1)]
[Nullable(0)]
public abstract class AssemblyLogData
{
	// Token: 0x17001371 RID: 4977
	// (get) Token: 0x0601033A RID: 66362
	// (set) Token: 0x0601033B RID: 66363
	public abstract string AssemblyId { get; set; }

	// Token: 0x17001372 RID: 4978
	// (get) Token: 0x0601033C RID: 66364
	// (set) Token: 0x0601033D RID: 66365
	public abstract CommonLogData AssemblyLogInfo { get; set; }

	// Token: 0x0601033E RID: 66366
	public abstract void SetLogDataToAssembly(IUnitLogData unitLogData);

	// Token: 0x0601033F RID: 66367
	public abstract bool CheckIsSend();

	// Token: 0x06010340 RID: 66368
	public abstract void AfterSend();

	// Token: 0x04007C78 RID: 31864
	public int SendTimePeriod;

	// Token: 0x04007C79 RID: 31865
	public double SendTimeAccumulate;
}
