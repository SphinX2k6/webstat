using System;

namespace CSharpScript.Game.Module.Kurotato
{
	// Token: 0x02005A3C RID: 23100
	public class KurotatoRoleSkillInfo : IKurotatoRoleSkillInfo
	{
		// Token: 0x170094F1 RID: 38129
		// (get) Token: 0x0603A798 RID: 239512 RVA: 0x00ED2CE4 File Offset: 0x00ED0EE4
		// (set) Token: 0x0603A799 RID: 239513 RVA: 0x00ED2CEC File Offset: 0x00ED0EEC
		public int AttrId { get; set; }

		// Token: 0x170094F2 RID: 38130
		// (get) Token: 0x0603A79A RID: 239514 RVA: 0x00ED2CF5 File Offset: 0x00ED0EF5
		// (set) Token: 0x0603A79B RID: 239515 RVA: 0x00ED2CFD File Offset: 0x00ED0EFD
		public int Value { get; set; }

		// Token: 0x170094F3 RID: 38131
		// (get) Token: 0x0603A79C RID: 239516 RVA: 0x00ED2D06 File Offset: 0x00ED0F06
		// (set) Token: 0x0603A79D RID: 239517 RVA: 0x00ED2D0E File Offset: 0x00ED0F0E
		public bool IsRecommend { get; set; }

		// Token: 0x170094F4 RID: 38132
		// (get) Token: 0x0603A79E RID: 239518 RVA: 0x00ED2D17 File Offset: 0x00ED0F17
		// (set) Token: 0x0603A79F RID: 239519 RVA: 0x00ED2D1F File Offset: 0x00ED0F1F
		public bool? IsAddition { get; set; }

		// Token: 0x170094F5 RID: 38133
		// (get) Token: 0x0603A7A0 RID: 239520 RVA: 0x00ED2D28 File Offset: 0x00ED0F28
		// (set) Token: 0x0603A7A1 RID: 239521 RVA: 0x00ED2D30 File Offset: 0x00ED0F30
		public int? BaseValue { get; set; }

		// Token: 0x170094F6 RID: 38134
		// (get) Token: 0x0603A7A2 RID: 239522 RVA: 0x00ED2D39 File Offset: 0x00ED0F39
		// (set) Token: 0x0603A7A3 RID: 239523 RVA: 0x00ED2D41 File Offset: 0x00ED0F41
		public bool? IsLocked { get; set; }

		// Token: 0x170094F7 RID: 38135
		// (get) Token: 0x0603A7A4 RID: 239524 RVA: 0x00ED2D4A File Offset: 0x00ED0F4A
		// (set) Token: 0x0603A7A5 RID: 239525 RVA: 0x00ED2D52 File Offset: 0x00ED0F52
		public int? LockedValue { get; set; }
	}
}
