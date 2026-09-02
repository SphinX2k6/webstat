using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.Activity.ActivityContent.Roverlike
{
	// Token: 0x020063BD RID: 25533
	[NullableContext(1)]
	public interface IRoverlikeBlessingSuitData
	{
		// Token: 0x17009D91 RID: 40337
		// (get) Token: 0x060401FE RID: 262654
		// (set) Token: 0x060401FF RID: 262655
		int SuitId { get; set; }

		// Token: 0x17009D92 RID: 40338
		// (get) Token: 0x06040200 RID: 262656
		// (set) Token: 0x06040201 RID: 262657
		List<int> BlessingIdList { get; set; }
	}
}
