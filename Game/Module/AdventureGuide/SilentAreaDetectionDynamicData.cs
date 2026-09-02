using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.AdventureGuide
{
	// Token: 0x0200619B RID: 24987
	[NullableContext(1)]
	[Nullable(0)]
	public class SilentAreaDetectionDynamicData : ISilentAreaDetectionDynamicData
	{
		// Token: 0x17009B2B RID: 39723
		// (get) Token: 0x0603F1CB RID: 258507 RVA: 0x0102F645 File Offset: 0x0102D845
		// (set) Token: 0x0603F1CC RID: 258508 RVA: 0x0102F64D File Offset: 0x0102D84D
		public bool IsShow { get; set; }

		// Token: 0x17009B2C RID: 39724
		// (get) Token: 0x0603F1CD RID: 258509 RVA: 0x0102F656 File Offset: 0x0102D856
		// (set) Token: 0x0603F1CE RID: 258510 RVA: 0x0102F65E File Offset: 0x0102D85E
		public int DangerType { get; set; }

		// Token: 0x17009B2D RID: 39725
		// (get) Token: 0x0603F1CF RID: 258511 RVA: 0x0102F667 File Offset: 0x0102D867
		// (set) Token: 0x0603F1D0 RID: 258512 RVA: 0x0102F66F File Offset: 0x0102D86F
		public SilentAreaDetectionRecord SilentAreaDetectionData { get; set; }

		// Token: 0x17009B2E RID: 39726
		// (get) Token: 0x0603F1D1 RID: 258513 RVA: 0x0102F678 File Offset: 0x0102D878
		// (set) Token: 0x0603F1D2 RID: 258514 RVA: 0x0102F680 File Offset: 0x0102D880
		[Nullable(2)]
		public ISilentAreaTitleData SilentAreaTitleData { [NullableContext(2)] get; [NullableContext(2)] set; }
	}
}
