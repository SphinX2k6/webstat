using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.RoleDev
{
	// Token: 0x02005048 RID: 20552
	[NullableContext(1)]
	public interface IButtonState
	{
		// Token: 0x17008B37 RID: 35639
		// (get) Token: 0x06034EB4 RID: 216756
		// (set) Token: 0x06034EB5 RID: 216757
		string Text { get; set; }

		// Token: 0x17008B38 RID: 35640
		// (get) Token: 0x06034EB6 RID: 216758
		// (set) Token: 0x06034EB7 RID: 216759
		bool IsHighlight { get; set; }
	}
}
