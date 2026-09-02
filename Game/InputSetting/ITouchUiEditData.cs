using System;

namespace CSharpScript.Game.InputSetting
{
	// Token: 0x02007012 RID: 28690
	public interface ITouchUiEditData
	{
		// Token: 0x1700A4C7 RID: 42183
		// (get) Token: 0x0604574C RID: 284492
		// (set) Token: 0x0604574D RID: 284493
		int StorageId { get; set; }

		// Token: 0x1700A4C8 RID: 42184
		// (get) Token: 0x0604574E RID: 284494
		// (set) Token: 0x0604574F RID: 284495
		float OffsetX { get; set; }

		// Token: 0x1700A4C9 RID: 42185
		// (get) Token: 0x06045750 RID: 284496
		// (set) Token: 0x06045751 RID: 284497
		float OffsetY { get; set; }

		// Token: 0x1700A4CA RID: 42186
		// (get) Token: 0x06045752 RID: 284498
		// (set) Token: 0x06045753 RID: 284499
		float Scale { get; set; }

		// Token: 0x1700A4CB RID: 42187
		// (get) Token: 0x06045754 RID: 284500
		// (set) Token: 0x06045755 RID: 284501
		float Alpha { get; set; }

		// Token: 0x1700A4CC RID: 42188
		// (get) Token: 0x06045756 RID: 284502
		// (set) Token: 0x06045757 RID: 284503
		int HierarchyIndex { get; set; }

		// Token: 0x1700A4CD RID: 42189
		// (get) Token: 0x06045758 RID: 284504
		// (set) Token: 0x06045759 RID: 284505
		bool Editable { get; set; }

		// Token: 0x1700A4CE RID: 42190
		// (get) Token: 0x0604575A RID: 284506
		// (set) Token: 0x0604575B RID: 284507
		bool DefaultSelect { get; set; }

		// Token: 0x1700A4CF RID: 42191
		// (get) Token: 0x0604575C RID: 284508
		// (set) Token: 0x0604575D RID: 284509
		bool ShouldCheckOverlap { get; set; }
	}
}
