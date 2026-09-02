using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Launcher
{
	// Token: 0x02004486 RID: 17542
	public class StorageAlertLog : HotPatchLogData
	{
		// Token: 0x0602E4EC RID: 189676 RVA: 0x00ADE1C4 File Offset: 0x00ADC3C4
		[NullableContext(2)]
		public StorageAlertLog(int remainingSpace, string uniqueId = null, string playerId = null) : base("1711", uniqueId, playerId)
		{
			this.i_remaining_space = remainingSpace;
		}

		// Token: 0x0401A488 RID: 107656
		public int i_remaining_space;
	}
}
