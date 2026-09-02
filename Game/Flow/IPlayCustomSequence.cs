using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Flow
{
	// Token: 0x02007038 RID: 28728
	[NullableContext(1)]
	public interface IPlayCustomSequence
	{
		// Token: 0x1700A511 RID: 42257
		// (get) Token: 0x060458A6 RID: 284838
		// (set) Token: 0x060458A7 RID: 284839
		int CustomSeqId { get; set; }

		// Token: 0x1700A512 RID: 42258
		// (get) Token: 0x060458A8 RID: 284840
		// (set) Token: 0x060458A9 RID: 284841
		int[] WhoIds { get; set; }

		// Token: 0x1700A513 RID: 42259
		// (get) Token: 0x060458AA RID: 284842
		// (set) Token: 0x060458AB RID: 284843
		bool? ResetCamera { get; set; }
	}
}
