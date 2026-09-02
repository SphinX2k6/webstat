using System;

namespace CSharpScript.Game.LevelGamePlay.SplineMoveTask
{
	// Token: 0x02006ACC RID: 27340
	public interface ISceneItemSplineMoveRangeByPointIndex : ISceneItemSplineMoveRange
	{
		// Token: 0x1700A29E RID: 41630
		// (get) Token: 0x06043984 RID: 276868
		// (set) Token: 0x06043985 RID: 276869
		int StartIndex { get; set; }

		// Token: 0x1700A29F RID: 41631
		// (get) Token: 0x06043986 RID: 276870
		// (set) Token: 0x06043987 RID: 276871
		int EndIndex { get; set; }
	}
}
