using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.LevelGamePlay.MusicGamePlay
{
	// Token: 0x02006B3B RID: 27451
	[NullableContext(1)]
	public interface IMusicGamePlayConfig
	{
		// Token: 0x1700A326 RID: 41766
		// (get) Token: 0x06043D61 RID: 277857
		// (set) Token: 0x06043D62 RID: 277858
		float BgmOffset { get; set; }

		// Token: 0x1700A327 RID: 41767
		// (get) Token: 0x06043D63 RID: 277859
		// (set) Token: 0x06043D64 RID: 277860
		IBeatEntity[] Entities { get; set; }
	}
}
