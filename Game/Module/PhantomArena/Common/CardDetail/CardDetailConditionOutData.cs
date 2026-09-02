using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.PhantomArena.Common.CardDetail
{
	// Token: 0x0200557D RID: 21885
	[NullableContext(1)]
	[Nullable(0)]
	public class CardDetailConditionOutData : ICardDetailConditionOutData
	{
		// Token: 0x17008F93 RID: 36755
		// (get) Token: 0x06037C27 RID: 228391 RVA: 0x00E226E6 File Offset: 0x00E208E6
		// (set) Token: 0x06037C28 RID: 228392 RVA: 0x00E226EE File Offset: 0x00E208EE
		public int CurrentProgress { get; set; }

		// Token: 0x17008F94 RID: 36756
		// (get) Token: 0x06037C29 RID: 228393 RVA: 0x00E226F7 File Offset: 0x00E208F7
		// (set) Token: 0x06037C2A RID: 228394 RVA: 0x00E226FF File Offset: 0x00E208FF
		public int MaxProgress { get; set; }

		// Token: 0x17008F95 RID: 36757
		// (get) Token: 0x06037C2B RID: 228395 RVA: 0x00E22708 File Offset: 0x00E20908
		// (set) Token: 0x06037C2C RID: 228396 RVA: 0x00E22710 File Offset: 0x00E20910
		public string Icon { get; set; }

		// Token: 0x17008F96 RID: 36758
		// (get) Token: 0x06037C2D RID: 228397 RVA: 0x00E22719 File Offset: 0x00E20919
		// (set) Token: 0x06037C2E RID: 228398 RVA: 0x00E22721 File Offset: 0x00E20921
		public string ConditionDesc { get; set; }

		// Token: 0x17008F97 RID: 36759
		// (get) Token: 0x06037C2F RID: 228399 RVA: 0x00E2272A File Offset: 0x00E2092A
		// (set) Token: 0x06037C30 RID: 228400 RVA: 0x00E22732 File Offset: 0x00E20932
		public string Title { get; set; }

		// Token: 0x17008F98 RID: 36760
		// (get) Token: 0x06037C31 RID: 228401 RVA: 0x00E2273B File Offset: 0x00E2093B
		// (set) Token: 0x06037C32 RID: 228402 RVA: 0x00E22743 File Offset: 0x00E20943
		public bool? TitleChangeColor { get; set; }
	}
}
