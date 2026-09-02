using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Ui
{
	// Token: 0x020049D1 RID: 18897
	[NullableContext(1)]
	public interface IUiViewBase
	{
		// Token: 0x17008420 RID: 33824
		// (get) Token: 0x06031701 RID: 202497
		// (set) Token: 0x06031702 RID: 202498
		UiViewBase ViewBase { get; set; }

		// Token: 0x17008421 RID: 33825
		// (get) Token: 0x06031703 RID: 202499
		// (set) Token: 0x06031704 RID: 202500
		int Priority { get; set; }

		// Token: 0x17008422 RID: 33826
		// (get) Token: 0x06031705 RID: 202501
		// (set) Token: 0x06031706 RID: 202502
		bool OnlyShowInMain { get; set; }
	}
}
