using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.PhantomArena.Common.CardDetail
{
	// Token: 0x02005583 RID: 21891
	[NullableContext(1)]
	[Nullable(0)]
	public class CardDetailPassiveSkillFieldData : ICardDetailPassiveSkillFieldData
	{
		// Token: 0x17008FA1 RID: 36769
		// (get) Token: 0x06037C46 RID: 228422 RVA: 0x00E22797 File Offset: 0x00E20997
		// (set) Token: 0x06037C47 RID: 228423 RVA: 0x00E2279F File Offset: 0x00E2099F
		public ICardDetailConditionOutData OutData { get; set; }

		// Token: 0x17008FA2 RID: 36770
		// (get) Token: 0x06037C48 RID: 228424 RVA: 0x00E227A8 File Offset: 0x00E209A8
		// (set) Token: 0x06037C49 RID: 228425 RVA: 0x00E227B0 File Offset: 0x00E209B0
		public ICardDetailConditionInData InData { get; set; }
	}
}
