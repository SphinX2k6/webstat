using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

// Token: 0x02003004 RID: 12292
[NullableContext(1)]
[Nullable(0)]
public class FoleySynthAllConfig
{
	// Token: 0x060190B7 RID: 102583 RVA: 0x0071C0D8 File Offset: 0x0071A2D8
	public bool IsLoadSuccess()
	{
		return this.CurLoadCount == 0;
	}

	// Token: 0x0400C40C RID: 50188
	public List<FoleySynthModel1Config> FoleySynthModel1Configs = new List<FoleySynthModel1Config>();

	// Token: 0x0400C40D RID: 50189
	public List<FoleySynthModel2Config> FoleySynthModel2Configs = new List<FoleySynthModel2Config>();

	// Token: 0x0400C40E RID: 50190
	public int Model2AccelerationMaxCount;

	// Token: 0x0400C40F RID: 50191
	public int Model2VelocityMaxCount;

	// Token: 0x0400C410 RID: 50192
	public int CurLoadCount;
}
