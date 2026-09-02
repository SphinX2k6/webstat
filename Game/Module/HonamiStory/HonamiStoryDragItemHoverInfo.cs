using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.HonamiStory
{
	// Token: 0x02005C7B RID: 23675
	[NullableContext(1)]
	[Nullable(0)]
	public class HonamiStoryDragItemHoverInfo : IHonamiStoryDragItemHoverInfo
	{
		// Token: 0x170097F6 RID: 38902
		// (get) Token: 0x0603BD2A RID: 245034 RVA: 0x00F2B29E File Offset: 0x00F2949E
		// (set) Token: 0x0603BD2B RID: 245035 RVA: 0x00F2B2A6 File Offset: 0x00F294A6
		public bool IsValid { get; set; }

		// Token: 0x170097F7 RID: 38903
		// (get) Token: 0x0603BD2C RID: 245036 RVA: 0x00F2B2AF File Offset: 0x00F294AF
		// (set) Token: 0x0603BD2D RID: 245037 RVA: 0x00F2B2B7 File Offset: 0x00F294B7
		public int StartPosition { get; set; }

		// Token: 0x170097F8 RID: 38904
		// (get) Token: 0x0603BD2E RID: 245038 RVA: 0x00F2B2C0 File Offset: 0x00F294C0
		// (set) Token: 0x0603BD2F RID: 245039 RVA: 0x00F2B2C8 File Offset: 0x00F294C8
		public int EndPosition { get; set; }

		// Token: 0x170097F9 RID: 38905
		// (get) Token: 0x0603BD30 RID: 245040 RVA: 0x00F2B2D1 File Offset: 0x00F294D1
		// (set) Token: 0x0603BD31 RID: 245041 RVA: 0x00F2B2D9 File Offset: 0x00F294D9
		public int Height { get; set; }

		// Token: 0x170097FA RID: 38906
		// (get) Token: 0x0603BD32 RID: 245042 RVA: 0x00F2B2E2 File Offset: 0x00F294E2
		// (set) Token: 0x0603BD33 RID: 245043 RVA: 0x00F2B2EA File Offset: 0x00F294EA
		public int Width { get; set; }

		// Token: 0x170097FB RID: 38907
		// (get) Token: 0x0603BD34 RID: 245044 RVA: 0x00F2B2F3 File Offset: 0x00F294F3
		// (set) Token: 0x0603BD35 RID: 245045 RVA: 0x00F2B2FB File Offset: 0x00F294FB
		public List<int> FillPosList { get; set; } = new List<int>();
	}
}
