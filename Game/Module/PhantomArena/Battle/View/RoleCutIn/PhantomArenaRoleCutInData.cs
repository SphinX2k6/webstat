using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.PhantomArena.Battle.View.RoleCutIn
{
	// Token: 0x020055B6 RID: 21942
	[NullableContext(1)]
	[Nullable(0)]
	public class PhantomArenaRoleCutInData : IPhantomArenaRoleCutInData
	{
		// Token: 0x17008FDD RID: 36829
		// (get) Token: 0x06037DD7 RID: 228823 RVA: 0x00E279FB File Offset: 0x00E25BFB
		// (set) Token: 0x06037DD8 RID: 228824 RVA: 0x00E27A03 File Offset: 0x00E25C03
		public int SkillId { get; set; }

		// Token: 0x17008FDE RID: 36830
		// (get) Token: 0x06037DD9 RID: 228825 RVA: 0x00E27A0C File Offset: 0x00E25C0C
		// (set) Token: 0x06037DDA RID: 228826 RVA: 0x00E27A14 File Offset: 0x00E25C14
		public Action CloseCallback { get; set; }
	}
}
