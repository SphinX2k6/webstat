using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.Roguelike
{
	// Token: 0x02005125 RID: 20773
	[NullableContext(1)]
	public interface IRoguelikePhantomAffixStateItemData
	{
		// Token: 0x17008C5D RID: 35933
		// (get) Token: 0x060357D8 RID: 219096
		// (set) Token: 0x060357D9 RID: 219097
		AffixEntry AffixEntry { get; set; }

		// Token: 0x17008C5E RID: 35934
		// (get) Token: 0x060357DA RID: 219098
		// (set) Token: 0x060357DB RID: 219099
		bool IsUnlock { get; set; }
	}
}
