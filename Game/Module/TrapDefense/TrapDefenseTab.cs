using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.TrapDefense
{
	// Token: 0x02004DC5 RID: 19909
	[NullableContext(1)]
	[Nullable(0)]
	public class TrapDefenseTab<[Nullable(2)] T> : ITrapDefenseTab<T>
	{
		// Token: 0x17008834 RID: 34868
		// (get) Token: 0x060338C5 RID: 211141 RVA: 0x00CE4644 File Offset: 0x00CE2844
		// (set) Token: 0x060338C6 RID: 211142 RVA: 0x00CE464C File Offset: 0x00CE284C
		public T TabType { get; set; }

		// Token: 0x17008835 RID: 34869
		// (get) Token: 0x060338C7 RID: 211143 RVA: 0x00CE4655 File Offset: 0x00CE2855
		// (set) Token: 0x060338C8 RID: 211144 RVA: 0x00CE465D File Offset: 0x00CE285D
		public string TabNameKey { get; set; } = "";
	}
}
