using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Flow
{
	// Token: 0x02007023 RID: 28707
	[NullableContext(1)]
	public interface IFlowListInfo
	{
		// Token: 0x1700A4F0 RID: 42224
		// (get) Token: 0x0604585C RID: 284764
		// (set) Token: 0x0604585D RID: 284765
		int FlowGenId { get; set; }

		// Token: 0x1700A4F1 RID: 42225
		// (get) Token: 0x0604585E RID: 284766
		// (set) Token: 0x0604585F RID: 284767
		Dictionary<int, ITextConfig> Texts { get; set; }

		// Token: 0x1700A4F2 RID: 42226
		// (get) Token: 0x06045860 RID: 284768
		// (set) Token: 0x06045861 RID: 284769
		IFlowInfo[] Flows { get; set; }
	}
}
