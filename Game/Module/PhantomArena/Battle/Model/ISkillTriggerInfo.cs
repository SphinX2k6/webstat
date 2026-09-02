using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.PhantomArena.Battle.SkillInteract;

namespace CSharpScript.Game.Module.PhantomArena.Battle.Model
{
	// Token: 0x020055FC RID: 22012
	[NullableContext(1)]
	public interface ISkillTriggerInfo
	{
		// Token: 0x17009011 RID: 36881
		// (get) Token: 0x06038178 RID: 229752
		// (set) Token: 0x06038179 RID: 229753
		EPhantomArenaBuffEffectType InteractType { get; set; }

		// Token: 0x17009012 RID: 36882
		// (get) Token: 0x0603817A RID: 229754
		// (set) Token: 0x0603817B RID: 229755
		List<int> SelectFightIdList { get; set; }

		// Token: 0x17009013 RID: 36883
		// (get) Token: 0x0603817C RID: 229756
		// (set) Token: 0x0603817D RID: 229757
		int SelectNum { get; set; }

		// Token: 0x17009014 RID: 36884
		// (get) Token: 0x0603817E RID: 229758
		// (set) Token: 0x0603817F RID: 229759
		int? SkillId { get; set; }

		// Token: 0x17009015 RID: 36885
		// (get) Token: 0x06038180 RID: 229760
		// (set) Token: 0x06038181 RID: 229761
		int? DataId { get; set; }

		// Token: 0x17009016 RID: 36886
		// (get) Token: 0x06038182 RID: 229762
		// (set) Token: 0x06038183 RID: 229763
		bool IsRole { get; set; }

		// Token: 0x17009017 RID: 36887
		// (get) Token: 0x06038184 RID: 229764
		// (set) Token: 0x06038185 RID: 229765
		bool IsPassive { get; set; }

		// Token: 0x17009018 RID: 36888
		// (get) Token: 0x06038186 RID: 229766
		// (set) Token: 0x06038187 RID: 229767
		bool IsFight { get; set; }

		// Token: 0x17009019 RID: 36889
		// (get) Token: 0x06038188 RID: 229768
		// (set) Token: 0x06038189 RID: 229769
		bool IsClickInteract { get; set; }
	}
}
