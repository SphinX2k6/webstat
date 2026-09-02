using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.LevelGamePlay.SplineMoveTask
{
	// Token: 0x02006ACE RID: 27342
	[NullableContext(2)]
	public interface ISceneItemSplineMoveConfig
	{
		// Token: 0x1700A2A2 RID: 41634
		// (get) Token: 0x0604398C RID: 276876
		// (set) Token: 0x0604398D RID: 276877
		ISceneItemSplineMoveSegmentConfig GlobalConfig { get; set; }

		// Token: 0x1700A2A3 RID: 41635
		// (get) Token: 0x0604398E RID: 276878
		// (set) Token: 0x0604398F RID: 276879
		[Nullable(new byte[]
		{
			2,
			1
		})]
		List<ISceneItemSplineMoveSegmentConfig> PointConfigs { [return: Nullable(new byte[]
		{
			2,
			1
		})] get; [param: Nullable(new byte[]
		{
			2,
			1
		})] set; }

		// Token: 0x1700A2A4 RID: 41636
		// (get) Token: 0x06043990 RID: 276880
		// (set) Token: 0x06043991 RID: 276881
		ISceneItemSplineMoveRange SplineMoveRange { get; set; }

		// Token: 0x1700A2A5 RID: 41637
		// (get) Token: 0x06043992 RID: 276882
		// (set) Token: 0x06043993 RID: 276883
		int MoveCount { get; set; }

		// Token: 0x1700A2A6 RID: 41638
		// (get) Token: 0x06043994 RID: 276884
		// (set) Token: 0x06043995 RID: 276885
		bool IsClosedLoop { get; set; }

		// Token: 0x1700A2A7 RID: 41639
		// (get) Token: 0x06043996 RID: 276886
		// (set) Token: 0x06043997 RID: 276887
		bool IsLookDir { get; set; }
	}
}
