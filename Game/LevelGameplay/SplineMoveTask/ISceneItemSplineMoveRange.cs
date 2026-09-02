using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.LevelGamePlay.SplineMoveTask
{
	// Token: 0x02006ACA RID: 27338
	[NullableContext(1)]
	internal interface ISceneItemSplineMoveRange<[Nullable(0)] T> where T : Enum
	{
		// Token: 0x1700A29C RID: 41628
		// (get) Token: 0x06043980 RID: 276864
		// (set) Token: 0x06043981 RID: 276865
		T Type { get; set; }
	}
}
