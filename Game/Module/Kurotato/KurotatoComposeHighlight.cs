using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.Kurotato
{
	// Token: 0x02005A52 RID: 23122
	[NullableContext(1)]
	[Nullable(0)]
	public class KurotatoComposeHighlight : IKurotatoComposeHighlight
	{
		// Token: 0x17009555 RID: 38229
		// (get) Token: 0x0603A86B RID: 239723 RVA: 0x00ED30B0 File Offset: 0x00ED12B0
		// (set) Token: 0x0603A86C RID: 239724 RVA: 0x00ED30B8 File Offset: 0x00ED12B8
		public HashSet<int> UpgradeSelectionIds { get; set; }

		// Token: 0x17009556 RID: 38230
		// (get) Token: 0x0603A86D RID: 239725 RVA: 0x00ED30C1 File Offset: 0x00ED12C1
		// (set) Token: 0x0603A86E RID: 239726 RVA: 0x00ED30C9 File Offset: 0x00ED12C9
		public HashSet<int> ArrowIncIds { get; set; }

		// Token: 0x17009557 RID: 38231
		// (get) Token: 0x0603A86F RID: 239727 RVA: 0x00ED30D2 File Offset: 0x00ED12D2
		// (set) Token: 0x0603A870 RID: 239728 RVA: 0x00ED30DA File Offset: 0x00ED12DA
		public HashSet<int> BagPairArrowIncIds { get; set; }
	}
}
