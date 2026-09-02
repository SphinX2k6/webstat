using System;

namespace CSharpScript.Game.Module.Manufacture.Common
{
	// Token: 0x020059E7 RID: 23015
	public class ISingleItemInfo
	{
		// Token: 0x170094C3 RID: 38083
		// (get) Token: 0x0603A4E4 RID: 238820 RVA: 0x00EC836D File Offset: 0x00EC656D
		// (set) Token: 0x0603A4E5 RID: 238821 RVA: 0x00EC8375 File Offset: 0x00EC6575
		public int Proto_ItemId { get; set; }

		// Token: 0x170094C4 RID: 38084
		// (get) Token: 0x0603A4E6 RID: 238822 RVA: 0x00EC837E File Offset: 0x00EC657E
		// (set) Token: 0x0603A4E7 RID: 238823 RVA: 0x00EC8386 File Offset: 0x00EC6586
		public int Proto_ItemNum { get; set; }

		// Token: 0x170094C5 RID: 38085
		// (get) Token: 0x0603A4E8 RID: 238824 RVA: 0x00EC838F File Offset: 0x00EC658F
		// (set) Token: 0x0603A4E9 RID: 238825 RVA: 0x00EC8397 File Offset: 0x00EC6597
		public bool Proto_IsUnlock { get; set; }

		// Token: 0x170094C6 RID: 38086
		// (get) Token: 0x0603A4EA RID: 238826 RVA: 0x00EC83A0 File Offset: 0x00EC65A0
		// (set) Token: 0x0603A4EB RID: 238827 RVA: 0x00EC83A8 File Offset: 0x00EC65A8
		public bool? IsEmpty { get; set; }
	}
}
