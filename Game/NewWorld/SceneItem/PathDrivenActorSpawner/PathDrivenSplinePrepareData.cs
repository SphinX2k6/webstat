using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.LevelGamePlay.SplineMoveTask;

namespace CSharpScript.Game.NewWorld.SceneItem.PathDrivenActorSpawner
{
	// Token: 0x0200483D RID: 18493
	[NullableContext(1)]
	[Nullable(0)]
	public class PathDrivenSplinePrepareData : IPathDrivenSplinePrepareData
	{
		// Token: 0x17008261 RID: 33377
		// (get) Token: 0x060301EF RID: 197103 RVA: 0x00BABC3E File Offset: 0x00BA9E3E
		// (set) Token: 0x060301F0 RID: 197104 RVA: 0x00BABC46 File Offset: 0x00BA9E46
		public int SplineEntityId { get; set; }

		// Token: 0x17008262 RID: 33378
		// (get) Token: 0x060301F1 RID: 197105 RVA: 0x00BABC4F File Offset: 0x00BA9E4F
		// (set) Token: 0x060301F2 RID: 197106 RVA: 0x00BABC57 File Offset: 0x00BA9E57
		public ISceneItemSplineMoveConfig SplineMoveConfig { get; set; }

		// Token: 0x17008263 RID: 33379
		// (get) Token: 0x060301F3 RID: 197107 RVA: 0x00BABC60 File Offset: 0x00BA9E60
		// (set) Token: 0x060301F4 RID: 197108 RVA: 0x00BABC68 File Offset: 0x00BA9E68
		public List<string> CurvePaths { get; set; }
	}
}
