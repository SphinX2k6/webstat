using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.RoleDev
{
	// Token: 0x0200504A RID: 20554
	[NullableContext(1)]
	public interface IPlanSwitchButtonState
	{
		// Token: 0x17008B3B RID: 35643
		// (get) Token: 0x06034EBD RID: 216765
		// (set) Token: 0x06034EBE RID: 216766
		bool IsShow { get; set; }

		// Token: 0x17008B3C RID: 35644
		// (get) Token: 0x06034EBF RID: 216767
		// (set) Token: 0x06034EC0 RID: 216768
		string Text { get; set; }

		// Token: 0x17008B3D RID: 35645
		// (get) Token: 0x06034EC1 RID: 216769
		// (set) Token: 0x06034EC2 RID: 216770
		bool IsHighlight { get; set; }
	}
}
