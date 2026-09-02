using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Protocol;

// Token: 0x020013D2 RID: 5074
[NullableContext(1)]
[Nullable(0)]
public class RoleResultData : IRoleResultData
{
	// Token: 0x17000BD7 RID: 3031
	// (get) Token: 0x06008C38 RID: 35896 RVA: 0x0024E0D4 File Offset: 0x0024C2D4
	// (set) Token: 0x06008C39 RID: 35897 RVA: 0x0024E0DC File Offset: 0x0024C2DC
	public RoleSettleResult SuccessResult { get; set; }

	// Token: 0x17000BD8 RID: 3032
	// (get) Token: 0x06008C3A RID: 35898 RVA: 0x0024E0E5 File Offset: 0x0024C2E5
	// (set) Token: 0x06008C3B RID: 35899 RVA: 0x0024E0ED File Offset: 0x0024C2ED
	public List<int> CharacterValueList { get; set; } = new List<int>();
}
