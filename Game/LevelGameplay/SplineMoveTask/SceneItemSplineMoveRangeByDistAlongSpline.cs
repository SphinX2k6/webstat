using System;

namespace CSharpScript.Game.LevelGamePlay.SplineMoveTask
{
	// Token: 0x02006AD7 RID: 27351
	public class SceneItemSplineMoveRangeByDistAlongSpline : ISceneItemSplineMoveRangeByDistAlongSpline, ISceneItemSplineMoveRange
	{
		// Token: 0x1700A2C9 RID: 41673
		// (get) Token: 0x060439F3 RID: 276979 RVA: 0x01171A7D File Offset: 0x0116FC7D
		// (set) Token: 0x060439F4 RID: 276980 RVA: 0x01171A85 File Offset: 0x0116FC85
		public ESceneItemSplineMoveRangeType Type { get; set; }

		// Token: 0x1700A2CA RID: 41674
		// (get) Token: 0x060439F5 RID: 276981 RVA: 0x01171A8E File Offset: 0x0116FC8E
		// (set) Token: 0x060439F6 RID: 276982 RVA: 0x01171A96 File Offset: 0x0116FC96
		public float StartDis { get; set; }

		// Token: 0x1700A2CB RID: 41675
		// (get) Token: 0x060439F7 RID: 276983 RVA: 0x01171A9F File Offset: 0x0116FC9F
		// (set) Token: 0x060439F8 RID: 276984 RVA: 0x01171AA7 File Offset: 0x0116FCA7
		public float EndDis { get; set; }
	}
}
