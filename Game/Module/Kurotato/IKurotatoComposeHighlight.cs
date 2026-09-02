using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.Kurotato
{
	// Token: 0x02005A51 RID: 23121
	[NullableContext(1)]
	public interface IKurotatoComposeHighlight
	{
		// Token: 0x17009552 RID: 38226
		// (get) Token: 0x0603A865 RID: 239717
		// (set) Token: 0x0603A866 RID: 239718
		HashSet<int> UpgradeSelectionIds { get; set; }

		// Token: 0x17009553 RID: 38227
		// (get) Token: 0x0603A867 RID: 239719
		// (set) Token: 0x0603A868 RID: 239720
		HashSet<int> ArrowIncIds { get; set; }

		// Token: 0x17009554 RID: 38228
		// (get) Token: 0x0603A869 RID: 239721
		// (set) Token: 0x0603A86A RID: 239722
		HashSet<int> BagPairArrowIncIds { get; set; }
	}
}
