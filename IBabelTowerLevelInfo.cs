using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

// Token: 0x020011E6 RID: 4582
[NullableContext(1)]
public interface IBabelTowerLevelInfo
{
	// Token: 0x17000A2B RID: 2603
	// (get) Token: 0x0600792A RID: 31018
	// (set) Token: 0x0600792B RID: 31019
	int BabelTowerLevelId { get; set; }

	// Token: 0x17000A2C RID: 2604
	// (get) Token: 0x0600792C RID: 31020
	// (set) Token: 0x0600792D RID: 31021
	int InstanceId { get; set; }

	// Token: 0x17000A2D RID: 2605
	// (get) Token: 0x0600792E RID: 31022
	// (set) Token: 0x0600792F RID: 31023
	List<int> RoleList { get; set; }

	// Token: 0x17000A2E RID: 2606
	// (get) Token: 0x06007930 RID: 31024
	// (set) Token: 0x06007931 RID: 31025
	List<int> BuffList { get; set; }

	// Token: 0x17000A2F RID: 2607
	// (get) Token: 0x06007932 RID: 31026
	// (set) Token: 0x06007933 RID: 31027
	int BuffCount { get; set; }

	// Token: 0x17000A30 RID: 2608
	// (get) Token: 0x06007934 RID: 31028
	// (set) Token: 0x06007935 RID: 31029
	int StarNumber { get; set; }
}
