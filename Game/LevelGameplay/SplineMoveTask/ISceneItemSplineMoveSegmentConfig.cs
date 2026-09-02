using System;

namespace CSharpScript.Game.LevelGamePlay.SplineMoveTask
{
	// Token: 0x02006AC6 RID: 27334
	public interface ISceneItemSplineMoveSegmentConfig
	{
		// Token: 0x1700A296 RID: 41622
		// (get) Token: 0x06043975 RID: 276853
		[Obsolete]
		ESceneItemSplineMoveSegmentConfigType Type { get; }

		// Token: 0x1700A297 RID: 41623
		// (get) Token: 0x06043976 RID: 276854
		// (set) Token: 0x06043977 RID: 276855
		float? WaitTime { get; set; }
	}
}
