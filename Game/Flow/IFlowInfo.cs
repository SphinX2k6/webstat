using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Flow
{
	// Token: 0x02007021 RID: 28705
	[NullableContext(1)]
	public interface IFlowInfo
	{
		// Token: 0x1700A4E8 RID: 42216
		// (get) Token: 0x0604584C RID: 284748
		// (set) Token: 0x0604584D RID: 284749
		int Id { get; set; }

		// Token: 0x1700A4E9 RID: 42217
		// (get) Token: 0x0604584E RID: 284750
		// (set) Token: 0x0604584F RID: 284751
		string Name { get; set; }

		// Token: 0x1700A4EA RID: 42218
		// (get) Token: 0x06045850 RID: 284752
		// (set) Token: 0x06045851 RID: 284753
		bool? _folded { get; set; }

		// Token: 0x1700A4EB RID: 42219
		// (get) Token: 0x06045852 RID: 284754
		// (set) Token: 0x06045853 RID: 284755
		int StateGenId { get; set; }

		// Token: 0x1700A4EC RID: 42220
		// (get) Token: 0x06045854 RID: 284756
		// (set) Token: 0x06045855 RID: 284757
		IStateInfo[] States { get; set; }
	}
}
