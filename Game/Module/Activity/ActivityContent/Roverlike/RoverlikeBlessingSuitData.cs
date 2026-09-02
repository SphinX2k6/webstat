using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.Activity.ActivityContent.Roverlike
{
	// Token: 0x020063BE RID: 25534
	[NullableContext(1)]
	[Nullable(0)]
	public class RoverlikeBlessingSuitData : IRoverlikeBlessingSuitData
	{
		// Token: 0x17009D93 RID: 40339
		// (get) Token: 0x06040202 RID: 262658 RVA: 0x0106FD21 File Offset: 0x0106DF21
		// (set) Token: 0x06040203 RID: 262659 RVA: 0x0106FD29 File Offset: 0x0106DF29
		public int SuitId { get; set; }

		// Token: 0x17009D94 RID: 40340
		// (get) Token: 0x06040204 RID: 262660 RVA: 0x0106FD32 File Offset: 0x0106DF32
		// (set) Token: 0x06040205 RID: 262661 RVA: 0x0106FD3A File Offset: 0x0106DF3A
		public List<int> BlessingIdList { get; set; } = new List<int>();
	}
}
