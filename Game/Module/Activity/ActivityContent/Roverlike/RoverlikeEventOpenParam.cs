using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.Activity.ActivityContent.Roverlike
{
	// Token: 0x020063C7 RID: 25543
	[NullableContext(1)]
	[Nullable(0)]
	public class RoverlikeEventOpenParam : IRoverlikeEventOpenParam
	{
		// Token: 0x17009DA7 RID: 40359
		// (get) Token: 0x0604022E RID: 262702 RVA: 0x0106FE01 File Offset: 0x0106E001
		// (set) Token: 0x0604022F RID: 262703 RVA: 0x0106FE09 File Offset: 0x0106E009
		public int EventIncId { get; set; }

		// Token: 0x17009DA8 RID: 40360
		// (get) Token: 0x06040230 RID: 262704 RVA: 0x0106FE12 File Offset: 0x0106E012
		// (set) Token: 0x06040231 RID: 262705 RVA: 0x0106FE1A File Offset: 0x0106E01A
		public List<int> ChoiceList { get; set; } = new List<int>();
	}
}
