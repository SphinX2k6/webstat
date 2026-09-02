using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.Activity.ActivityContent.Tetris
{
	// Token: 0x0200629F RID: 25247
	[NullableContext(1)]
	public interface ITetrisTargetData
	{
		// Token: 0x17009C6D RID: 40045
		// (get) Token: 0x0603F8A0 RID: 260256
		// (set) Token: 0x0603F8A1 RID: 260257
		string Icon { get; set; }

		// Token: 0x17009C6E RID: 40046
		// (get) Token: 0x0603F8A2 RID: 260258
		// (set) Token: 0x0603F8A3 RID: 260259
		int Num { get; set; }

		// Token: 0x17009C6F RID: 40047
		// (get) Token: 0x0603F8A4 RID: 260260
		// (set) Token: 0x0603F8A5 RID: 260261
		string Tip { get; set; }
	}
}
