using System;
using System.Runtime.CompilerServices;

// Token: 0x02001CE0 RID: 7392
[NullableContext(1)]
[Nullable(0)]
public class GachaPoolData
{
	// Token: 0x17001146 RID: 4422
	// (get) Token: 0x0600D8EA RID: 55530 RVA: 0x003A163A File Offset: 0x0039F83A
	// (set) Token: 0x0600D8EB RID: 55531 RVA: 0x003A1642 File Offset: 0x0039F842
	public ProtoGachaInfo GachaInfo { get; set; }

	// Token: 0x17001147 RID: 4423
	// (get) Token: 0x0600D8EC RID: 55532 RVA: 0x003A164B File Offset: 0x0039F84B
	// (set) Token: 0x0600D8ED RID: 55533 RVA: 0x003A1653 File Offset: 0x0039F853
	public ProtoGachaPoolInfo PoolInfo { get; set; }

	// Token: 0x0600D8EE RID: 55534 RVA: 0x003A165C File Offset: 0x0039F85C
	public GachaPoolData(ProtoGachaInfo gachaInfo, ProtoGachaPoolInfo poolInfo)
	{
		this.GachaInfo = gachaInfo;
		this.PoolInfo = poolInfo;
	}
}
