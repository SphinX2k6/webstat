using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.RoleDev
{
	// Token: 0x02005049 RID: 20553
	[NullableContext(1)]
	[Nullable(0)]
	public class ButtonState : IButtonState
	{
		// Token: 0x17008B39 RID: 35641
		// (get) Token: 0x06034EB8 RID: 216760 RVA: 0x00D4697C File Offset: 0x00D44B7C
		// (set) Token: 0x06034EB9 RID: 216761 RVA: 0x00D46984 File Offset: 0x00D44B84
		public string Text { get; set; }

		// Token: 0x17008B3A RID: 35642
		// (get) Token: 0x06034EBA RID: 216762 RVA: 0x00D4698D File Offset: 0x00D44B8D
		// (set) Token: 0x06034EBB RID: 216763 RVA: 0x00D46995 File Offset: 0x00D44B95
		public bool IsHighlight { get; set; }
	}
}
