using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.PhantomArena.Common.CardDetail
{
	// Token: 0x02005567 RID: 21863
	[NullableContext(1)]
	[Nullable(0)]
	public class CardDetailActiveSkillData : ICardDetailActiveSkillData
	{
		// Token: 0x17008F79 RID: 36729
		// (get) Token: 0x06037BB5 RID: 228277 RVA: 0x00E216AF File Offset: 0x00E1F8AF
		// (set) Token: 0x06037BB6 RID: 228278 RVA: 0x00E216B7 File Offset: 0x00E1F8B7
		public string Desc { get; set; }

		// Token: 0x17008F7A RID: 36730
		// (get) Token: 0x06037BB7 RID: 228279 RVA: 0x00E216C0 File Offset: 0x00E1F8C0
		// (set) Token: 0x06037BB8 RID: 228280 RVA: 0x00E216C8 File Offset: 0x00E1F8C8
		public List<string> Params { get; set; }
	}
}
