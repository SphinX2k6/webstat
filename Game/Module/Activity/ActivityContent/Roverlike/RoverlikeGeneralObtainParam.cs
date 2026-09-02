using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.Activity.ActivityContent.Roverlike
{
	// Token: 0x020063C9 RID: 25545
	[NullableContext(1)]
	[Nullable(0)]
	public class RoverlikeGeneralObtainParam : IRoverlikeGeneralObtainParam
	{
		// Token: 0x17009DAB RID: 40363
		// (get) Token: 0x06040237 RID: 262711 RVA: 0x0106FE36 File Offset: 0x0106E036
		// (set) Token: 0x06040238 RID: 262712 RVA: 0x0106FE3E File Offset: 0x0106E03E
		public List<RoverlikeGainEntry> Entries { get; set; } = new List<RoverlikeGainEntry>();

		// Token: 0x17009DAC RID: 40364
		// (get) Token: 0x06040239 RID: 262713 RVA: 0x0106FE47 File Offset: 0x0106E047
		// (set) Token: 0x0604023A RID: 262714 RVA: 0x0106FE4F File Offset: 0x0106E04F
		public bool IsLose { get; set; }
	}
}
