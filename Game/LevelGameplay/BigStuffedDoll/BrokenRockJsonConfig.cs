using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.LevelGamePlay.BigStuffedDoll
{
	// Token: 0x02006F57 RID: 28503
	[NullableContext(1)]
	[Nullable(0)]
	public class BrokenRockJsonConfig : IBrokenRockJsonConfig
	{
		// Token: 0x1700A49A RID: 42138
		// (get) Token: 0x06044FDB RID: 282587 RVA: 0x011F4FCF File Offset: 0x011F31CF
		// (set) Token: 0x06044FDC RID: 282588 RVA: 0x011F4FD7 File Offset: 0x011F31D7
		public BrokenRockConfig[] Config { get; set; }

		// Token: 0x1700A49B RID: 42139
		// (get) Token: 0x06044FDD RID: 282589 RVA: 0x011F4FE0 File Offset: 0x011F31E0
		// (set) Token: 0x06044FDE RID: 282590 RVA: 0x011F4FE8 File Offset: 0x011F31E8
		public BrokenRockRingConfig[] Rings { get; set; }
	}
}
