using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.Activity.ActivityContent.Tetris
{
	// Token: 0x02006295 RID: 25237
	[NullableContext(1)]
	public interface IShapeConfig
	{
		// Token: 0x17009C45 RID: 40005
		// (get) Token: 0x0603F84B RID: 260171
		// (set) Token: 0x0603F84C RID: 260172
		int Id { get; set; }

		// Token: 0x17009C46 RID: 40006
		// (get) Token: 0x0603F84D RID: 260173
		// (set) Token: 0x0603F84E RID: 260174
		int[][] Matrix { get; set; }

		// Token: 0x17009C47 RID: 40007
		// (get) Token: 0x0603F84F RID: 260175
		// (set) Token: 0x0603F850 RID: 260176
		int Weight { get; set; }
	}
}
