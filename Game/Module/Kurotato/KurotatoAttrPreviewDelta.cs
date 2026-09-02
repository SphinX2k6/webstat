using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.Kurotato
{
	// Token: 0x02005A56 RID: 23126
	[NullableContext(1)]
	[Nullable(0)]
	public class KurotatoAttrPreviewDelta : IKurotatoAttrPreviewDelta
	{
		// Token: 0x17009561 RID: 38241
		// (get) Token: 0x0603A885 RID: 239749 RVA: 0x00ED3126 File Offset: 0x00ED1326
		// (set) Token: 0x0603A886 RID: 239750 RVA: 0x00ED312E File Offset: 0x00ED132E
		public int PropertyId { get; set; }

		// Token: 0x17009562 RID: 38242
		// (get) Token: 0x0603A887 RID: 239751 RVA: 0x00ED3137 File Offset: 0x00ED1337
		// (set) Token: 0x0603A888 RID: 239752 RVA: 0x00ED313F File Offset: 0x00ED133F
		public string ValueStr { get; set; }

		// Token: 0x17009563 RID: 38243
		// (get) Token: 0x0603A889 RID: 239753 RVA: 0x00ED3148 File Offset: 0x00ED1348
		// (set) Token: 0x0603A88A RID: 239754 RVA: 0x00ED3150 File Offset: 0x00ED1350
		public int? LockValue { get; set; }
	}
}
