using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Protocol;

// Token: 0x020013D1 RID: 5073
[NullableContext(1)]
public interface IRoleResultData
{
	// Token: 0x17000BD5 RID: 3029
	// (get) Token: 0x06008C34 RID: 35892
	// (set) Token: 0x06008C35 RID: 35893
	RoleSettleResult SuccessResult { get; set; }

	// Token: 0x17000BD6 RID: 3030
	// (get) Token: 0x06008C36 RID: 35894
	// (set) Token: 0x06008C37 RID: 35895
	List<int> CharacterValueList { get; set; }
}
