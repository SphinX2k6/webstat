using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.Kurotato.View.PopupItemDetail
{
	// Token: 0x02005A8D RID: 23181
	[NullableContext(1)]
	public interface IInfoItemData
	{
		// Token: 0x17009593 RID: 38291
		// (get) Token: 0x0603AA7E RID: 240254
		// (set) Token: 0x0603AA7F RID: 240255
		int Level { get; set; }

		// Token: 0x17009594 RID: 38292
		// (get) Token: 0x0603AA80 RID: 240256
		// (set) Token: 0x0603AA81 RID: 240257
		string Description { get; set; }

		// Token: 0x17009595 RID: 38293
		// (get) Token: 0x0603AA82 RID: 240258
		// (set) Token: 0x0603AA83 RID: 240259
		int BuildLevel { get; set; }

		// Token: 0x17009596 RID: 38294
		// (get) Token: 0x0603AA84 RID: 240260
		// (set) Token: 0x0603AA85 RID: 240261
		bool IsArrowLevel { get; set; }
	}
}
