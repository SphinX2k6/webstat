using System;
using System.Runtime.CompilerServices;

// Token: 0x020014DD RID: 5341
[NullableContext(2)]
[Nullable(0)]
public class PinballRoleViewOpenParam : IPinballRoleViewOpenParam
{
	// Token: 0x17000CD9 RID: 3289
	// (get) Token: 0x06009565 RID: 38245 RVA: 0x00270958 File Offset: 0x0026EB58
	// (set) Token: 0x06009566 RID: 38246 RVA: 0x00270960 File Offset: 0x0026EB60
	public int? RoleId { get; set; }

	// Token: 0x17000CDA RID: 3290
	// (get) Token: 0x06009567 RID: 38247 RVA: 0x00270969 File Offset: 0x0026EB69
	// (set) Token: 0x06009568 RID: 38248 RVA: 0x00270971 File Offset: 0x0026EB71
	public int[] FormationRoleIds { get; set; }
}
