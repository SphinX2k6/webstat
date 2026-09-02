using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.Motorcycle.Model
{
	// Token: 0x020056F7 RID: 22263
	[NullableContext(2)]
	[Nullable(0)]
	public class MotorcycleUiModelParam
	{
		// Token: 0x17009117 RID: 37143
		// (get) Token: 0x06038A6F RID: 232047 RVA: 0x00E58829 File Offset: 0x00E56A29
		// (set) Token: 0x06038A70 RID: 232048 RVA: 0x00E58831 File Offset: 0x00E56A31
		public int FrameId { get; set; }

		// Token: 0x17009118 RID: 37144
		// (get) Token: 0x06038A71 RID: 232049 RVA: 0x00E5883A File Offset: 0x00E56A3A
		// (set) Token: 0x06038A72 RID: 232050 RVA: 0x00E58842 File Offset: 0x00E56A42
		public int[] StickerIds { get; set; }

		// Token: 0x17009119 RID: 37145
		// (get) Token: 0x06038A73 RID: 232051 RVA: 0x00E5884B File Offset: 0x00E56A4B
		// (set) Token: 0x06038A74 RID: 232052 RVA: 0x00E58853 File Offset: 0x00E56A53
		public int[] DecorationIds { get; set; }
	}
}
