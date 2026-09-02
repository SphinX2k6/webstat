using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.Activity.ActivityContent.Roverlike
{
	// Token: 0x020063BF RID: 25535
	[NullableContext(1)]
	public interface IRoverlikeBlessingSuitSelectParam
	{
		// Token: 0x17009D95 RID: 40341
		// (get) Token: 0x06040207 RID: 262663
		// (set) Token: 0x06040208 RID: 262664
		List<IRoverlikeBlessingSuitData> SuitDataList { get; set; }

		// Token: 0x17009D96 RID: 40342
		// (get) Token: 0x06040209 RID: 262665
		// (set) Token: 0x0604020A RID: 262666
		int SelectedIndex { get; set; }
	}
}
