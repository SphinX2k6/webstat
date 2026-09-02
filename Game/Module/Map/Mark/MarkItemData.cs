using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.Map.Mark
{
	// Token: 0x0200580F RID: 22543
	[NullableContext(2)]
	[Nullable(0)]
	public class MarkItemData : IMarkItemData
	{
		// Token: 0x17009223 RID: 37411
		// (get) Token: 0x0603958E RID: 234894 RVA: 0x00E8E2C4 File Offset: 0x00E8C4C4
		// (set) Token: 0x0603958F RID: 234895 RVA: 0x00E8E2CC File Offset: 0x00E8C4CC
		public int[] ShowRange { get; set; }

		// Token: 0x17009224 RID: 37412
		// (get) Token: 0x06039590 RID: 234896 RVA: 0x00E8E2D5 File Offset: 0x00E8C4D5
		// (set) Token: 0x06039591 RID: 234897 RVA: 0x00E8E2DD File Offset: 0x00E8C4DD
		public string MarkPic { get; set; }

		// Token: 0x17009225 RID: 37413
		// (get) Token: 0x06039592 RID: 234898 RVA: 0x00E8E2E6 File Offset: 0x00E8C4E6
		// (set) Token: 0x06039593 RID: 234899 RVA: 0x00E8E2EE File Offset: 0x00E8C4EE
		public int? ShowPriority { get; set; }

		// Token: 0x17009226 RID: 37414
		// (get) Token: 0x06039594 RID: 234900 RVA: 0x00E8E2F7 File Offset: 0x00E8C4F7
		// (set) Token: 0x06039595 RID: 234901 RVA: 0x00E8E2FF File Offset: 0x00E8C4FF
		public float? Scale { get; set; }

		// Token: 0x17009227 RID: 37415
		// (get) Token: 0x06039596 RID: 234902 RVA: 0x00E8E308 File Offset: 0x00E8C508
		// (set) Token: 0x06039597 RID: 234903 RVA: 0x00E8E310 File Offset: 0x00E8C510
		public float? CornerScale { get; set; }
	}
}
