using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.AdventureGuide
{
	// Token: 0x0200619A RID: 24986
	[NullableContext(1)]
	public interface ISilentAreaDetectionDynamicData
	{
		// Token: 0x17009B27 RID: 39719
		// (get) Token: 0x0603F1C3 RID: 258499
		// (set) Token: 0x0603F1C4 RID: 258500
		bool IsShow { get; set; }

		// Token: 0x17009B28 RID: 39720
		// (get) Token: 0x0603F1C5 RID: 258501
		// (set) Token: 0x0603F1C6 RID: 258502
		int DangerType { get; set; }

		// Token: 0x17009B29 RID: 39721
		// (get) Token: 0x0603F1C7 RID: 258503
		// (set) Token: 0x0603F1C8 RID: 258504
		SilentAreaDetectionRecord SilentAreaDetectionData { get; set; }

		// Token: 0x17009B2A RID: 39722
		// (get) Token: 0x0603F1C9 RID: 258505
		// (set) Token: 0x0603F1CA RID: 258506
		[Nullable(2)]
		ISilentAreaTitleData SilentAreaTitleData { [NullableContext(2)] get; [NullableContext(2)] set; }
	}
}
