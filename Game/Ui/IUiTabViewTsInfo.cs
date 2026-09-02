using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Ui
{
	// Token: 0x02004A59 RID: 19033
	[NullableContext(1)]
	public interface IUiTabViewTsInfo
	{
		// Token: 0x17008487 RID: 33927
		// (get) Token: 0x06031B7C RID: 203644
		TCreateUiTabViewBase CreateUiTabView { get; }

		// Token: 0x17008488 RID: 33928
		// (get) Token: 0x06031B7D RID: 203645
		string ResourceId { get; }
	}
}
