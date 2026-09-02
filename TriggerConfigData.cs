using System;
using System.Runtime.CompilerServices;

// Token: 0x02002EC3 RID: 11971
[NullableContext(1)]
[Nullable(0)]
public class TriggerConfigData : ITriggerConfig
{
	// Token: 0x1700213E RID: 8510
	// (get) Token: 0x06018951 RID: 100689 RVA: 0x006EAE83 File Offset: 0x006E9083
	// (set) Token: 0x06018952 RID: 100690 RVA: 0x006EAE8B File Offset: 0x006E908B
	public string Type { get; set; } = string.Empty;

	// Token: 0x1700213F RID: 8511
	// (get) Token: 0x06018953 RID: 100691 RVA: 0x006EAE94 File Offset: 0x006E9094
	// (set) Token: 0x06018954 RID: 100692 RVA: 0x006EAE9C File Offset: 0x006E909C
	public string[] Preset { get; set; } = Array.Empty<string>();

	// Token: 0x17002140 RID: 8512
	// (get) Token: 0x06018955 RID: 100693 RVA: 0x006EAEA5 File Offset: 0x006E90A5
	// (set) Token: 0x06018956 RID: 100694 RVA: 0x006EAEAD File Offset: 0x006E90AD
	public string Params { get; set; } = string.Empty;

	// Token: 0x17002141 RID: 8513
	// (get) Token: 0x06018957 RID: 100695 RVA: 0x006EAEB6 File Offset: 0x006E90B6
	// (set) Token: 0x06018958 RID: 100696 RVA: 0x006EAEBE File Offset: 0x006E90BE
	public string Formula { get; set; } = string.Empty;

	// Token: 0x17002142 RID: 8514
	// (get) Token: 0x06018959 RID: 100697 RVA: 0x006EAEC7 File Offset: 0x006E90C7
	// (set) Token: 0x0601895A RID: 100698 RVA: 0x006EAECF File Offset: 0x006E90CF
	public EExecuteType ExecuteType { get; set; }
}
