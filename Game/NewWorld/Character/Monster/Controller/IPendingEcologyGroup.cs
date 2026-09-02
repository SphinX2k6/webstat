using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.TDConfigMgr.Component;

namespace CSharpScript.Game.NewWorld.Character.Monster.Controller
{
	// Token: 0x020048DA RID: 18650
	[NullableContext(1)]
	public interface IPendingEcologyGroup
	{
		// Token: 0x170082CC RID: 33484
		// (get) Token: 0x06030A94 RID: 199316
		// (set) Token: 0x06030A95 RID: 199317
		GroupAiComponent GroupComp { get; set; }

		// Token: 0x170082CD RID: 33485
		// (get) Token: 0x06030A96 RID: 199318
		// (set) Token: 0x06030A97 RID: 199319
		HashSet<int> RegisteredPbDataIds { get; set; }
	}
}
