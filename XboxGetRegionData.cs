using System;
using System.Runtime.CompilerServices;

// Token: 0x02000EE5 RID: 3813
[NullableContext(1)]
[Nullable(0)]
public class XboxGetRegionData
{
	// Token: 0x170006E6 RID: 1766
	// (get) Token: 0x06005E05 RID: 24069 RVA: 0x001783CC File Offset: 0x001765CC
	// (set) Token: 0x06005E06 RID: 24070 RVA: 0x001783D4 File Offset: 0x001765D4
	public int LoginType { get; set; }

	// Token: 0x170006E7 RID: 1767
	// (get) Token: 0x06005E07 RID: 24071 RVA: 0x001783DD File Offset: 0x001765DD
	// (set) Token: 0x06005E08 RID: 24072 RVA: 0x001783E5 File Offset: 0x001765E5
	public string UserId { get; set; } = "";

	// Token: 0x170006E8 RID: 1768
	// (get) Token: 0x06005E09 RID: 24073 RVA: 0x001783EE File Offset: 0x001765EE
	// (set) Token: 0x06005E0A RID: 24074 RVA: 0x001783F6 File Offset: 0x001765F6
	public string UserName { get; set; } = "";

	// Token: 0x170006E9 RID: 1769
	// (get) Token: 0x06005E0B RID: 24075 RVA: 0x001783FF File Offset: 0x001765FF
	// (set) Token: 0x06005E0C RID: 24076 RVA: 0x00178407 File Offset: 0x00176607
	public string Token { get; set; } = "";
}
