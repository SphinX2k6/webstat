using System;

namespace CSharpScript.Game.Module.Activity.ActivityContent.Tetris
{
	// Token: 0x0200629A RID: 25242
	public class CellInstance : ICellInstance
	{
		// Token: 0x17009C59 RID: 40025
		// (get) Token: 0x0603F875 RID: 260213 RVA: 0x0104925C File Offset: 0x0104745C
		// (set) Token: 0x0603F876 RID: 260214 RVA: 0x01049264 File Offset: 0x01047464
		public int ColorId { get; set; }

		// Token: 0x17009C5A RID: 40026
		// (get) Token: 0x0603F877 RID: 260215 RVA: 0x0104926D File Offset: 0x0104746D
		// (set) Token: 0x0603F878 RID: 260216 RVA: 0x01049275 File Offset: 0x01047475
		public EGemType GemType { get; set; }
	}
}
