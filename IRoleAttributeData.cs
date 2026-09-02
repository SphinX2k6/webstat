using System;
using System.Runtime.CompilerServices;

// Token: 0x020027CB RID: 10187
[NullableContext(1)]
public interface IRoleAttributeData
{
	// Token: 0x17001988 RID: 6536
	// (get) Token: 0x0601425E RID: 82526
	// (set) Token: 0x0601425F RID: 82527
	string Name { get; set; }

	// Token: 0x17001989 RID: 6537
	// (get) Token: 0x06014260 RID: 82528
	// (set) Token: 0x06014261 RID: 82529
	int Level { get; set; }

	// Token: 0x1700198A RID: 6538
	// (get) Token: 0x06014262 RID: 82530
	// (set) Token: 0x06014263 RID: 82531
	int BreakLevel { get; set; }

	// Token: 0x1700198B RID: 6539
	// (get) Token: 0x06014264 RID: 82532
	// (set) Token: 0x06014265 RID: 82533
	int Exp { get; set; }
}
