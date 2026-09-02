using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.LevelGamePlay.GravityFlip
{
	// Token: 0x02006E7E RID: 28286
	[NullableContext(2)]
	public interface IGravityFlipViewOpenParam
	{
		// Token: 0x1700A39E RID: 41886
		// (get) Token: 0x060449AB RID: 281003
		// (set) Token: 0x060449AC RID: 281004
		Action<int> SelectCallback { get; set; }
	}
}
