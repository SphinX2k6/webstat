using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.LevelGamePlay.GravityFlip
{
	// Token: 0x02006E7F RID: 28287
	[NullableContext(2)]
	[Nullable(0)]
	public class GravityFlipViewOpenParam : IGravityFlipViewOpenParam
	{
		// Token: 0x1700A39F RID: 41887
		// (get) Token: 0x060449AD RID: 281005 RVA: 0x011D5B7C File Offset: 0x011D3D7C
		// (set) Token: 0x060449AE RID: 281006 RVA: 0x011D5B84 File Offset: 0x011D3D84
		public Action<int> SelectCallback { get; set; }
	}
}
