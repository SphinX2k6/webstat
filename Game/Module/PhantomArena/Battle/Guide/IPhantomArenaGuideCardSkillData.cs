using System;
using CSharpScript.Game.Module.PhantomArena.Battle.SkillInteract;

namespace CSharpScript.Game.Module.PhantomArena.Battle.Guide
{
	// Token: 0x0200560B RID: 22027
	public interface IPhantomArenaGuideCardSkillData
	{
		// Token: 0x17009063 RID: 36963
		// (get) Token: 0x0603828C RID: 230028
		// (set) Token: 0x0603828D RID: 230029
		int CardId { get; set; }

		// Token: 0x17009064 RID: 36964
		// (get) Token: 0x0603828E RID: 230030
		// (set) Token: 0x0603828F RID: 230031
		int? SkillId { get; set; }

		// Token: 0x17009065 RID: 36965
		// (get) Token: 0x06038290 RID: 230032
		// (set) Token: 0x06038291 RID: 230033
		EPhantomArenaBuffEffectType? BuffType { get; set; }
	}
}
