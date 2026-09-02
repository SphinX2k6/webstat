using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.LevelGamePlay.BigStuffedDoll
{
	// Token: 0x02006F56 RID: 28502
	[NullableContext(1)]
	public interface IBrokenRockJsonConfig
	{
		// Token: 0x1700A498 RID: 42136
		// (get) Token: 0x06044FD7 RID: 282583
		// (set) Token: 0x06044FD8 RID: 282584
		BrokenRockConfig[] Config { get; set; }

		// Token: 0x1700A499 RID: 42137
		// (get) Token: 0x06044FD9 RID: 282585
		// (set) Token: 0x06044FDA RID: 282586
		BrokenRockRingConfig[] Rings { get; set; }
	}
}
