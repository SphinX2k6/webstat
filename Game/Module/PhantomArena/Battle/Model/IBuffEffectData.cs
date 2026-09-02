using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Protocol;

namespace CSharpScript.Game.Module.PhantomArena.Battle.Model
{
	// Token: 0x020055FA RID: 22010
	[NullableContext(1)]
	public interface IBuffEffectData
	{
		// Token: 0x17009007 RID: 36871
		// (get) Token: 0x06038163 RID: 229731
		// (set) Token: 0x06038164 RID: 229732
		int SourceFightId { get; set; }

		// Token: 0x17009008 RID: 36872
		// (get) Token: 0x06038165 RID: 229733
		// (set) Token: 0x06038166 RID: 229734
		int SkillId { get; set; }

		// Token: 0x17009009 RID: 36873
		// (get) Token: 0x06038167 RID: 229735
		// (set) Token: 0x06038168 RID: 229736
		List<int> SelectFightIdList { get; set; }

		// Token: 0x1700900A RID: 36874
		// (get) Token: 0x06038169 RID: 229737
		// (set) Token: 0x0603816A RID: 229738
		PhantomBattleEffectResultInfo Effect { get; set; }

		// Token: 0x1700900B RID: 36875
		// (get) Token: 0x0603816B RID: 229739
		// (set) Token: 0x0603816C RID: 229740
		ENotifyMessageId? NotifyId { get; set; }
	}
}
