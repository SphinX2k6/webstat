using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.AdventureGuide.Views
{
	// Token: 0x020061B3 RID: 25011
	[NullableContext(1)]
	[Nullable(0)]
	public class IPeriodicityChallengeItem
	{
		// Token: 0x17009B3C RID: 39740
		// (get) Token: 0x0603F247 RID: 258631 RVA: 0x0103369E File Offset: 0x0103189E
		// (set) Token: 0x0603F248 RID: 258632 RVA: 0x010336A6 File Offset: 0x010318A6
		public SoundAreaDetectionRecord Data { get; set; }

		// Token: 0x17009B3D RID: 39741
		// (get) Token: 0x0603F249 RID: 258633 RVA: 0x010336AF File Offset: 0x010318AF
		// (set) Token: 0x0603F24A RID: 258634 RVA: 0x010336B7 File Offset: 0x010318B7
		public bool Title { get; set; }

		// Token: 0x17009B3E RID: 39742
		// (get) Token: 0x0603F24B RID: 258635 RVA: 0x010336C0 File Offset: 0x010318C0
		// (set) Token: 0x0603F24C RID: 258636 RVA: 0x010336C8 File Offset: 0x010318C8
		[Nullable(2)]
		public IPeriodicityChallengeTopTips TopTips { [NullableContext(2)] get; [NullableContext(2)] set; }
	}
}
