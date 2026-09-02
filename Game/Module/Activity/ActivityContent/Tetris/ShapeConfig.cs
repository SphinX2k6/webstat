using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.Activity.ActivityContent.Tetris
{
	// Token: 0x02006296 RID: 25238
	[NullableContext(1)]
	[Nullable(0)]
	public class ShapeConfig : IShapeConfig
	{
		// Token: 0x17009C48 RID: 40008
		// (get) Token: 0x0603F851 RID: 260177 RVA: 0x010491B3 File Offset: 0x010473B3
		// (set) Token: 0x0603F852 RID: 260178 RVA: 0x010491BB File Offset: 0x010473BB
		public int Id { get; set; }

		// Token: 0x17009C49 RID: 40009
		// (get) Token: 0x0603F853 RID: 260179 RVA: 0x010491C4 File Offset: 0x010473C4
		// (set) Token: 0x0603F854 RID: 260180 RVA: 0x010491CC File Offset: 0x010473CC
		public int[][] Matrix { get; set; }

		// Token: 0x17009C4A RID: 40010
		// (get) Token: 0x0603F855 RID: 260181 RVA: 0x010491D5 File Offset: 0x010473D5
		// (set) Token: 0x0603F856 RID: 260182 RVA: 0x010491DD File Offset: 0x010473DD
		public int Weight { get; set; }
	}
}
