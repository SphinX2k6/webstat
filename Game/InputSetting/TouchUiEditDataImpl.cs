using System;

namespace CSharpScript.Game.InputSetting
{
	// Token: 0x02007013 RID: 28691
	public class TouchUiEditDataImpl : ITouchUiEditData
	{
		// Token: 0x1700A4D0 RID: 42192
		// (get) Token: 0x0604575E RID: 284510 RVA: 0x012293EB File Offset: 0x012275EB
		// (set) Token: 0x0604575F RID: 284511 RVA: 0x012293F3 File Offset: 0x012275F3
		public int StorageId { get; set; }

		// Token: 0x1700A4D1 RID: 42193
		// (get) Token: 0x06045760 RID: 284512 RVA: 0x012293FC File Offset: 0x012275FC
		// (set) Token: 0x06045761 RID: 284513 RVA: 0x01229404 File Offset: 0x01227604
		public float OffsetX { get; set; }

		// Token: 0x1700A4D2 RID: 42194
		// (get) Token: 0x06045762 RID: 284514 RVA: 0x0122940D File Offset: 0x0122760D
		// (set) Token: 0x06045763 RID: 284515 RVA: 0x01229415 File Offset: 0x01227615
		public float OffsetY { get; set; }

		// Token: 0x1700A4D3 RID: 42195
		// (get) Token: 0x06045764 RID: 284516 RVA: 0x0122941E File Offset: 0x0122761E
		// (set) Token: 0x06045765 RID: 284517 RVA: 0x01229426 File Offset: 0x01227626
		public float Scale { get; set; }

		// Token: 0x1700A4D4 RID: 42196
		// (get) Token: 0x06045766 RID: 284518 RVA: 0x0122942F File Offset: 0x0122762F
		// (set) Token: 0x06045767 RID: 284519 RVA: 0x01229437 File Offset: 0x01227637
		public float Alpha { get; set; }

		// Token: 0x1700A4D5 RID: 42197
		// (get) Token: 0x06045768 RID: 284520 RVA: 0x01229440 File Offset: 0x01227640
		// (set) Token: 0x06045769 RID: 284521 RVA: 0x01229448 File Offset: 0x01227648
		public int HierarchyIndex { get; set; }

		// Token: 0x1700A4D6 RID: 42198
		// (get) Token: 0x0604576A RID: 284522 RVA: 0x01229451 File Offset: 0x01227651
		// (set) Token: 0x0604576B RID: 284523 RVA: 0x01229459 File Offset: 0x01227659
		public bool Editable { get; set; }

		// Token: 0x1700A4D7 RID: 42199
		// (get) Token: 0x0604576C RID: 284524 RVA: 0x01229462 File Offset: 0x01227662
		// (set) Token: 0x0604576D RID: 284525 RVA: 0x0122946A File Offset: 0x0122766A
		public bool DefaultSelect { get; set; }

		// Token: 0x1700A4D8 RID: 42200
		// (get) Token: 0x0604576E RID: 284526 RVA: 0x01229473 File Offset: 0x01227673
		// (set) Token: 0x0604576F RID: 284527 RVA: 0x0122947B File Offset: 0x0122767B
		public bool ShouldCheckOverlap { get; set; }
	}
}
