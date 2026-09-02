using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.Activity.ActivityContent.Roverlike
{
	// Token: 0x020063B4 RID: 25524
	[NullableContext(1)]
	[Nullable(0)]
	public class RoverlikeFloatTextData : IRoverlikeFloatTextData
	{
		// Token: 0x17009D89 RID: 40329
		// (get) Token: 0x060401B2 RID: 262578 RVA: 0x0106EF52 File Offset: 0x0106D152
		// (set) Token: 0x060401B3 RID: 262579 RVA: 0x0106EF5A File Offset: 0x0106D15A
		public ERoverlikeFloatTextType Type { get; set; }

		// Token: 0x17009D8A RID: 40330
		// (get) Token: 0x060401B4 RID: 262580 RVA: 0x0106EF63 File Offset: 0x0106D163
		// (set) Token: 0x060401B5 RID: 262581 RVA: 0x0106EF6B File Offset: 0x0106D16B
		public string TextKey { get; set; } = string.Empty;

		// Token: 0x17009D8B RID: 40331
		// (get) Token: 0x060401B6 RID: 262582 RVA: 0x0106EF74 File Offset: 0x0106D174
		// (set) Token: 0x060401B7 RID: 262583 RVA: 0x0106EF7C File Offset: 0x0106D17C
		public string[] TextParam { get; set; } = new string[0];
	}
}
