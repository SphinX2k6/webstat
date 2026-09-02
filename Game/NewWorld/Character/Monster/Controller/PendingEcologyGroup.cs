using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.TDConfigMgr.Component;

namespace CSharpScript.Game.NewWorld.Character.Monster.Controller
{
	// Token: 0x020048DB RID: 18651
	[NullableContext(1)]
	[Nullable(0)]
	public class PendingEcologyGroup : IPendingEcologyGroup
	{
		// Token: 0x170082CE RID: 33486
		// (get) Token: 0x06030A98 RID: 199320 RVA: 0x00BFE2EE File Offset: 0x00BFC4EE
		// (set) Token: 0x06030A99 RID: 199321 RVA: 0x00BFE2F6 File Offset: 0x00BFC4F6
		public GroupAiComponent GroupComp { get; set; }

		// Token: 0x170082CF RID: 33487
		// (get) Token: 0x06030A9A RID: 199322 RVA: 0x00BFE2FF File Offset: 0x00BFC4FF
		// (set) Token: 0x06030A9B RID: 199323 RVA: 0x00BFE307 File Offset: 0x00BFC507
		public HashSet<int> RegisteredPbDataIds { get; set; } = new HashSet<int>();
	}
}
