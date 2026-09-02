using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.PhantomArena.Battle.View.RoleCutIn
{
	// Token: 0x020055B5 RID: 21941
	[NullableContext(1)]
	public interface IPhantomArenaRoleCutInData
	{
		// Token: 0x17008FDB RID: 36827
		// (get) Token: 0x06037DD3 RID: 228819
		// (set) Token: 0x06037DD4 RID: 228820
		int SkillId { get; set; }

		// Token: 0x17008FDC RID: 36828
		// (get) Token: 0x06037DD5 RID: 228821
		// (set) Token: 0x06037DD6 RID: 228822
		Action CloseCallback { get; set; }
	}
}
