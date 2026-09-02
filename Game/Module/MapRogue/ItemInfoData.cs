using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.MapRogue
{
	// Token: 0x0200598E RID: 22926
	[NullableContext(1)]
	[Nullable(0)]
	public class ItemInfoData : IItemInfoData
	{
		// Token: 0x1700947B RID: 38011
		// (get) Token: 0x0603A0FE RID: 237822 RVA: 0x00EB1FBB File Offset: 0x00EB01BB
		// (set) Token: 0x0603A0FF RID: 237823 RVA: 0x00EB1FC3 File Offset: 0x00EB01C3
		public string TitleId { get; set; } = string.Empty;

		// Token: 0x1700947C RID: 38012
		// (get) Token: 0x0603A100 RID: 237824 RVA: 0x00EB1FCC File Offset: 0x00EB01CC
		// (set) Token: 0x0603A101 RID: 237825 RVA: 0x00EB1FD4 File Offset: 0x00EB01D4
		public string Value { get; set; } = string.Empty;

		// Token: 0x1700947D RID: 38013
		// (get) Token: 0x0603A102 RID: 237826 RVA: 0x00EB1FDD File Offset: 0x00EB01DD
		// (set) Token: 0x0603A103 RID: 237827 RVA: 0x00EB1FE5 File Offset: 0x00EB01E5
		public bool ValueChangeColor { get; set; }
	}
}
