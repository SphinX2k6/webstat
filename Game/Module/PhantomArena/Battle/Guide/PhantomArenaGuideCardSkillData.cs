using System;
using CSharpScript.Game.Module.PhantomArena.Battle.SkillInteract;

namespace CSharpScript.Game.Module.PhantomArena.Battle.Guide
{
	// Token: 0x0200560C RID: 22028
	public class PhantomArenaGuideCardSkillData : IPhantomArenaGuideCardSkillData
	{
		// Token: 0x17009066 RID: 36966
		// (get) Token: 0x06038292 RID: 230034 RVA: 0x00E38D61 File Offset: 0x00E36F61
		// (set) Token: 0x06038293 RID: 230035 RVA: 0x00E38D69 File Offset: 0x00E36F69
		public int CardId { get; set; }

		// Token: 0x17009067 RID: 36967
		// (get) Token: 0x06038294 RID: 230036 RVA: 0x00E38D72 File Offset: 0x00E36F72
		// (set) Token: 0x06038295 RID: 230037 RVA: 0x00E38D7A File Offset: 0x00E36F7A
		public int? SkillId { get; set; }

		// Token: 0x17009068 RID: 36968
		// (get) Token: 0x06038296 RID: 230038 RVA: 0x00E38D83 File Offset: 0x00E36F83
		// (set) Token: 0x06038297 RID: 230039 RVA: 0x00E38D8B File Offset: 0x00E36F8B
		public EPhantomArenaBuffEffectType? BuffType { get; set; }
	}
}
