using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Ui;

namespace CSharpScript.Game.Module.MovieMode
{
	// Token: 0x020056ED RID: 22253
	[NullableContext(2)]
	public interface IMovieModeAspectViewParams
	{
		// Token: 0x17009104 RID: 37124
		// (get) Token: 0x06038A1A RID: 231962
		// (set) Token: 0x06038A1B RID: 231963
		bool IsBanAdaptation { get; set; }

		// Token: 0x17009105 RID: 37125
		// (get) Token: 0x06038A1C RID: 231964
		// (set) Token: 0x06038A1D RID: 231965
		ELayerType[] AdaptUiLayers { get; set; }

		// Token: 0x17009106 RID: 37126
		// (get) Token: 0x06038A1E RID: 231966
		// (set) Token: 0x06038A1F RID: 231967
		bool? IsIgnoreUiLayerVisible { get; set; }
	}
}
