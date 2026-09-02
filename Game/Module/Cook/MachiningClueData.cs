using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.Cook
{
	// Token: 0x02005E05 RID: 24069
	[NullableContext(1)]
	[Nullable(0)]
	public class MachiningClueData : IMachiningClueData
	{
		// Token: 0x1700990A RID: 39178
		// (get) Token: 0x0603C92D RID: 248109 RVA: 0x00F62367 File Offset: 0x00F60567
		// (set) Token: 0x0603C92E RID: 248110 RVA: 0x00F6236F File Offset: 0x00F6056F
		public bool IsUnlock { get; set; }

		// Token: 0x1700990B RID: 39179
		// (get) Token: 0x0603C92F RID: 248111 RVA: 0x00F62378 File Offset: 0x00F60578
		// (set) Token: 0x0603C930 RID: 248112 RVA: 0x00F62380 File Offset: 0x00F60580
		public string ContentText { get; set; }
	}
}
