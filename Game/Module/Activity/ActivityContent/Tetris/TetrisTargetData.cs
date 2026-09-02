using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.Activity.ActivityContent.Tetris
{
	// Token: 0x020062A0 RID: 25248
	[NullableContext(1)]
	[Nullable(0)]
	public class TetrisTargetData : ITetrisTargetData
	{
		// Token: 0x17009C70 RID: 40048
		// (get) Token: 0x0603F8A6 RID: 260262 RVA: 0x0104932F File Offset: 0x0104752F
		// (set) Token: 0x0603F8A7 RID: 260263 RVA: 0x01049337 File Offset: 0x01047537
		public string Icon { get; set; }

		// Token: 0x17009C71 RID: 40049
		// (get) Token: 0x0603F8A8 RID: 260264 RVA: 0x01049340 File Offset: 0x01047540
		// (set) Token: 0x0603F8A9 RID: 260265 RVA: 0x01049348 File Offset: 0x01047548
		public int Num { get; set; }

		// Token: 0x17009C72 RID: 40050
		// (get) Token: 0x0603F8AA RID: 260266 RVA: 0x01049351 File Offset: 0x01047551
		// (set) Token: 0x0603F8AB RID: 260267 RVA: 0x01049359 File Offset: 0x01047559
		public string Tip { get; set; }
	}
}
