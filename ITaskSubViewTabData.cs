using System;
using System.Runtime.CompilerServices;

// Token: 0x0200155B RID: 5467
[NullableContext(1)]
[Nullable(0)]
public struct ITaskSubViewTabData
{
	// Token: 0x17000D20 RID: 3360
	// (get) Token: 0x06009955 RID: 39253 RVA: 0x002822B3 File Offset: 0x002804B3
	// (set) Token: 0x06009956 RID: 39254 RVA: 0x002822BB File Offset: 0x002804BB
	public string TitleKey { readonly get; set; }

	// Token: 0x17000D21 RID: 3361
	// (get) Token: 0x06009957 RID: 39255 RVA: 0x002822C4 File Offset: 0x002804C4
	// (set) Token: 0x06009958 RID: 39256 RVA: 0x002822CC File Offset: 0x002804CC
	public string IconName { readonly get; set; }

	// Token: 0x17000D22 RID: 3362
	// (get) Token: 0x06009959 RID: 39257 RVA: 0x002822D5 File Offset: 0x002804D5
	// (set) Token: 0x0600995A RID: 39258 RVA: 0x002822DD File Offset: 0x002804DD
	public EActivityRegressTaskSubViewType Type { readonly get; set; }

	// Token: 0x17000D23 RID: 3363
	// (get) Token: 0x0600995B RID: 39259 RVA: 0x002822E6 File Offset: 0x002804E6
	// (set) Token: 0x0600995C RID: 39260 RVA: 0x002822EE File Offset: 0x002804EE
	public ERedDotName? RedDotName { readonly get; set; }
}
