using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.Roguelike
{
	// Token: 0x02005126 RID: 20774
	[NullableContext(1)]
	[Nullable(0)]
	public class RoguelikePhantomAffixStateItemData : IRoguelikePhantomAffixStateItemData
	{
		// Token: 0x17008C5F RID: 35935
		// (get) Token: 0x060357DC RID: 219100 RVA: 0x00D6DEB2 File Offset: 0x00D6C0B2
		// (set) Token: 0x060357DD RID: 219101 RVA: 0x00D6DEBA File Offset: 0x00D6C0BA
		public AffixEntry AffixEntry { get; set; }

		// Token: 0x17008C60 RID: 35936
		// (get) Token: 0x060357DE RID: 219102 RVA: 0x00D6DEC3 File Offset: 0x00D6C0C3
		// (set) Token: 0x060357DF RID: 219103 RVA: 0x00D6DECB File Offset: 0x00D6C0CB
		public bool IsUnlock { get; set; }
	}
}
