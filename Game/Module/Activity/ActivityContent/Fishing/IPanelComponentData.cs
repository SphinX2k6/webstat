using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.Activity.ActivityContent.Fishing
{
	// Token: 0x020067BA RID: 26554
	[NullableContext(1)]
	public interface IPanelComponentData
	{
		// Token: 0x1700A101 RID: 41217
		// (get) Token: 0x060423DD RID: 271325
		// (set) Token: 0x060423DE RID: 271326
		string TitleText { get; set; }

		// Token: 0x1700A102 RID: 41218
		// (get) Token: 0x060423DF RID: 271327
		// (set) Token: 0x060423E0 RID: 271328
		Func<string> GetCountText { get; set; }

		// Token: 0x1700A103 RID: 41219
		// (get) Token: 0x060423E1 RID: 271329
		// (set) Token: 0x060423E2 RID: 271330
		int HelpBtnId { get; set; }

		// Token: 0x1700A104 RID: 41220
		// (get) Token: 0x060423E3 RID: 271331
		// (set) Token: 0x060423E4 RID: 271332
		string TimeText { get; set; }
	}
}
