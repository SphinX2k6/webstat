using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.Roguelike
{
	// Token: 0x0200510A RID: 20746
	[NullableContext(2)]
	[Nullable(0)]
	public class RoguelikeRandomEventOpenParam : IRoguelikeRandomEventOpenParam
	{
		// Token: 0x17008C4B RID: 35915
		// (get) Token: 0x06035754 RID: 218964 RVA: 0x00D6B2DC File Offset: 0x00D694DC
		// (set) Token: 0x06035755 RID: 218965 RVA: 0x00D6B2E4 File Offset: 0x00D694E4
		public int BindId { get; set; }

		// Token: 0x17008C4C RID: 35916
		// (get) Token: 0x06035756 RID: 218966 RVA: 0x00D6B2ED File Offset: 0x00D694ED
		// (set) Token: 0x06035757 RID: 218967 RVA: 0x00D6B2F5 File Offset: 0x00D694F5
		public Action<int> SelectCallback { get; set; }
	}
}
