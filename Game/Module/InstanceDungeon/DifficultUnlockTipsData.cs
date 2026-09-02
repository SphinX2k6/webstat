using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.InstanceDungeon
{
	// Token: 0x02005BAB RID: 23467
	[NullableContext(1)]
	[Nullable(0)]
	public class DifficultUnlockTipsData
	{
		// Token: 0x17009771 RID: 38769
		// (get) Token: 0x0603B5EE RID: 243182 RVA: 0x00F0A00A File Offset: 0x00F0820A
		// (set) Token: 0x0603B5EF RID: 243183 RVA: 0x00F0A012 File Offset: 0x00F08212
		public string Text { get; set; } = string.Empty;

		// Token: 0x17009772 RID: 38770
		// (get) Token: 0x0603B5F0 RID: 243184 RVA: 0x00F0A01B File Offset: 0x00F0821B
		// (set) Token: 0x0603B5F1 RID: 243185 RVA: 0x00F0A023 File Offset: 0x00F08223
		public object[] Params { get; set; } = Array.Empty<object>();
	}
}
