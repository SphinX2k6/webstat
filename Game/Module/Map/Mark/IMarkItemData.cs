using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.Map.Mark
{
	// Token: 0x0200580E RID: 22542
	[NullableContext(2)]
	public interface IMarkItemData
	{
		// Token: 0x1700921E RID: 37406
		// (get) Token: 0x06039584 RID: 234884
		// (set) Token: 0x06039585 RID: 234885
		int[] ShowRange { get; set; }

		// Token: 0x1700921F RID: 37407
		// (get) Token: 0x06039586 RID: 234886
		// (set) Token: 0x06039587 RID: 234887
		string MarkPic { get; set; }

		// Token: 0x17009220 RID: 37408
		// (get) Token: 0x06039588 RID: 234888
		// (set) Token: 0x06039589 RID: 234889
		int? ShowPriority { get; set; }

		// Token: 0x17009221 RID: 37409
		// (get) Token: 0x0603958A RID: 234890
		// (set) Token: 0x0603958B RID: 234891
		float? Scale { get; set; }

		// Token: 0x17009222 RID: 37410
		// (get) Token: 0x0603958C RID: 234892
		// (set) Token: 0x0603958D RID: 234893
		float? CornerScale { get; set; }
	}
}
