using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Ui;

namespace CSharpScript.Game.Module.MovieMode
{
	// Token: 0x020056EE RID: 22254
	[NullableContext(2)]
	[Nullable(0)]
	[RequiredMember]
	public class MovieModeAspectViewParams : IMovieModeAspectViewParams
	{
		// Token: 0x17009107 RID: 37127
		// (get) Token: 0x06038A20 RID: 231968 RVA: 0x00E5798A File Offset: 0x00E55B8A
		// (set) Token: 0x06038A21 RID: 231969 RVA: 0x00E57992 File Offset: 0x00E55B92
		[RequiredMember]
		public bool IsBanAdaptation { get; set; }

		// Token: 0x17009108 RID: 37128
		// (get) Token: 0x06038A22 RID: 231970 RVA: 0x00E5799B File Offset: 0x00E55B9B
		// (set) Token: 0x06038A23 RID: 231971 RVA: 0x00E579A3 File Offset: 0x00E55BA3
		[RequiredMember]
		public ELayerType[] AdaptUiLayers { get; set; }

		// Token: 0x17009109 RID: 37129
		// (get) Token: 0x06038A24 RID: 231972 RVA: 0x00E579AC File Offset: 0x00E55BAC
		// (set) Token: 0x06038A25 RID: 231973 RVA: 0x00E579B4 File Offset: 0x00E55BB4
		[RequiredMember]
		public bool? IsIgnoreUiLayerVisible { get; set; }

		// Token: 0x06038A26 RID: 231974 RVA: 0x00E579BD File Offset: 0x00E55BBD
		[Obsolete("Constructors of types with required members are not supported in this version of your compiler.", true)]
		[CompilerFeatureRequired("RequiredMembers")]
		public MovieModeAspectViewParams()
		{
		}
	}
}
