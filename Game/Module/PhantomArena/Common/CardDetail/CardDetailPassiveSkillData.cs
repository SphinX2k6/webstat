using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.PhantomArena.Common.CardDetail
{
	// Token: 0x02005585 RID: 21893
	[NullableContext(1)]
	[Nullable(0)]
	public class CardDetailPassiveSkillData : ICardDetailPassiveSkillData
	{
		// Token: 0x17008FA7 RID: 36775
		// (get) Token: 0x06037C53 RID: 228435 RVA: 0x00E227C1 File Offset: 0x00E209C1
		// (set) Token: 0x06037C54 RID: 228436 RVA: 0x00E227C9 File Offset: 0x00E209C9
		public string Desc { get; set; }

		// Token: 0x17008FA8 RID: 36776
		// (get) Token: 0x06037C55 RID: 228437 RVA: 0x00E227D2 File Offset: 0x00E209D2
		// (set) Token: 0x06037C56 RID: 228438 RVA: 0x00E227DA File Offset: 0x00E209DA
		public List<string> Params { get; set; }

		// Token: 0x17008FA9 RID: 36777
		// (get) Token: 0x06037C57 RID: 228439 RVA: 0x00E227E3 File Offset: 0x00E209E3
		// (set) Token: 0x06037C58 RID: 228440 RVA: 0x00E227EB File Offset: 0x00E209EB
		public ICardDetailEffectCountData EffectCountData { get; set; }

		// Token: 0x17008FAA RID: 36778
		// (get) Token: 0x06037C59 RID: 228441 RVA: 0x00E227F4 File Offset: 0x00E209F4
		// (set) Token: 0x06037C5A RID: 228442 RVA: 0x00E227FC File Offset: 0x00E209FC
		public ICardDetailPassiveSkillFieldData FieldData { get; set; }
	}
}
