using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.Activity.ActivityContent.Fishing
{
	// Token: 0x020067BB RID: 26555
	[NullableContext(1)]
	[Nullable(0)]
	public class PanelComponentData : IPanelComponentData
	{
		// Token: 0x1700A105 RID: 41221
		// (get) Token: 0x060423E5 RID: 271333 RVA: 0x010FEAB8 File Offset: 0x010FCCB8
		// (set) Token: 0x060423E6 RID: 271334 RVA: 0x010FEAC0 File Offset: 0x010FCCC0
		public string TitleText { get; set; } = "";

		// Token: 0x1700A106 RID: 41222
		// (get) Token: 0x060423E7 RID: 271335 RVA: 0x010FEAC9 File Offset: 0x010FCCC9
		// (set) Token: 0x060423E8 RID: 271336 RVA: 0x010FEAD1 File Offset: 0x010FCCD1
		public Func<string> GetCountText { get; set; }

		// Token: 0x1700A107 RID: 41223
		// (get) Token: 0x060423E9 RID: 271337 RVA: 0x010FEADA File Offset: 0x010FCCDA
		// (set) Token: 0x060423EA RID: 271338 RVA: 0x010FEAE2 File Offset: 0x010FCCE2
		public int HelpBtnId { get; set; }

		// Token: 0x1700A108 RID: 41224
		// (get) Token: 0x060423EB RID: 271339 RVA: 0x010FEAEB File Offset: 0x010FCCEB
		// (set) Token: 0x060423EC RID: 271340 RVA: 0x010FEAF3 File Offset: 0x010FCCF3
		public string TimeText { get; set; } = "";
	}
}
