using System;

namespace CSharpScript.Game.LevelGamePlay.SplineMoveTask
{
	// Token: 0x02006AD6 RID: 27350
	public class SceneItemSplineMoveRangeByPointIndex : ISceneItemSplineMoveRangeByPointIndex, ISceneItemSplineMoveRange
	{
		// Token: 0x1700A2C6 RID: 41670
		// (get) Token: 0x060439EC RID: 276972 RVA: 0x01171A42 File Offset: 0x0116FC42
		// (set) Token: 0x060439ED RID: 276973 RVA: 0x01171A4A File Offset: 0x0116FC4A
		public ESceneItemSplineMoveRangeType Type { get; set; }

		// Token: 0x1700A2C7 RID: 41671
		// (get) Token: 0x060439EE RID: 276974 RVA: 0x01171A53 File Offset: 0x0116FC53
		// (set) Token: 0x060439EF RID: 276975 RVA: 0x01171A5B File Offset: 0x0116FC5B
		public int StartIndex { get; set; }

		// Token: 0x1700A2C8 RID: 41672
		// (get) Token: 0x060439F0 RID: 276976 RVA: 0x01171A64 File Offset: 0x0116FC64
		// (set) Token: 0x060439F1 RID: 276977 RVA: 0x01171A6C File Offset: 0x0116FC6C
		public int EndIndex { get; set; }
	}
}
