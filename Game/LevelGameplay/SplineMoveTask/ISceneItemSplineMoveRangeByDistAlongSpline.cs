using System;

namespace CSharpScript.Game.LevelGamePlay.SplineMoveTask
{
	// Token: 0x02006ACD RID: 27341
	public interface ISceneItemSplineMoveRangeByDistAlongSpline : ISceneItemSplineMoveRange
	{
		// Token: 0x1700A2A0 RID: 41632
		// (get) Token: 0x06043988 RID: 276872
		// (set) Token: 0x06043989 RID: 276873
		float StartDis { get; set; }

		// Token: 0x1700A2A1 RID: 41633
		// (get) Token: 0x0604398A RID: 276874
		// (set) Token: 0x0604398B RID: 276875
		float EndDis { get; set; }
	}
}
