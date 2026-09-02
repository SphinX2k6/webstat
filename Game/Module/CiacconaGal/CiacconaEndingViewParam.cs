using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.CiacconaGal
{
	// Token: 0x02005ED7 RID: 24279
	[NullableContext(1)]
	[Nullable(0)]
	public class CiacconaEndingViewParam : ICiacconaEndingViewParam
	{
		// Token: 0x170099EF RID: 39407
		// (get) Token: 0x0603D01E RID: 249886 RVA: 0x00F7EE7F File Offset: 0x00F7D07F
		// (set) Token: 0x0603D01F RID: 249887 RVA: 0x00F7EE87 File Offset: 0x00F7D087
		public CiacconaGalEndingData EndingData { get; set; }

		// Token: 0x170099F0 RID: 39408
		// (get) Token: 0x0603D020 RID: 249888 RVA: 0x00F7EE90 File Offset: 0x00F7D090
		// (set) Token: 0x0603D021 RID: 249889 RVA: 0x00F7EE98 File Offset: 0x00F7D098
		[Nullable(2)]
		public string LabelTextId { [NullableContext(2)] get; [NullableContext(2)] set; }
	}
}
