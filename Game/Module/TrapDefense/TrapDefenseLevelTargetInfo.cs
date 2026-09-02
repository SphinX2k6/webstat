using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.TrapDefense
{
	// Token: 0x02004DE6 RID: 19942
	[NullableContext(1)]
	[Nullable(0)]
	public class TrapDefenseLevelTargetInfo : ITrapDefenseLevelTargetInfo
	{
		// Token: 0x1700888B RID: 34955
		// (get) Token: 0x06033971 RID: 211313 RVA: 0x00CE4A14 File Offset: 0x00CE2C14
		// (set) Token: 0x06033972 RID: 211314 RVA: 0x00CE4A1C File Offset: 0x00CE2C1C
		public ETrapDefenseLevelTarget TargetType { get; set; }

		// Token: 0x1700888C RID: 34956
		// (get) Token: 0x06033973 RID: 211315 RVA: 0x00CE4A25 File Offset: 0x00CE2C25
		// (set) Token: 0x06033974 RID: 211316 RVA: 0x00CE4A2D File Offset: 0x00CE2C2D
		public string NameKey { get; set; } = "";

		// Token: 0x1700888D RID: 34957
		// (get) Token: 0x06033975 RID: 211317 RVA: 0x00CE4A36 File Offset: 0x00CE2C36
		// (set) Token: 0x06033976 RID: 211318 RVA: 0x00CE4A3E File Offset: 0x00CE2C3E
		public string IconKey { get; set; } = "";
	}
}
