using System;

namespace CSharpScript.Game.Module.PermanentRogue
{
	// Token: 0x0200565B RID: 22107
	public interface IRogueEndingItemParam
	{
		// Token: 0x17009091 RID: 37009
		// (get) Token: 0x060385D6 RID: 230870
		// (set) Token: 0x060385D7 RID: 230871
		int ConfigId { get; set; }

		// Token: 0x17009092 RID: 37010
		// (get) Token: 0x060385D8 RID: 230872
		// (set) Token: 0x060385D9 RID: 230873
		int Index { get; set; }

		// Token: 0x17009093 RID: 37011
		// (get) Token: 0x060385DA RID: 230874
		// (set) Token: 0x060385DB RID: 230875
		float? Rotation { get; set; }

		// Token: 0x17009094 RID: 37012
		// (get) Token: 0x060385DC RID: 230876
		// (set) Token: 0x060385DD RID: 230877
		bool IsSubView { get; set; }

		// Token: 0x17009095 RID: 37013
		// (get) Token: 0x060385DE RID: 230878
		// (set) Token: 0x060385DF RID: 230879
		bool IsUnlock { get; set; }
	}
}
