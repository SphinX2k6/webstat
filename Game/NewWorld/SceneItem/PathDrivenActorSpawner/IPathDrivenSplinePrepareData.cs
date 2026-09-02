using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.LevelGamePlay.SplineMoveTask;

namespace CSharpScript.Game.NewWorld.SceneItem.PathDrivenActorSpawner
{
	// Token: 0x0200483C RID: 18492
	[NullableContext(1)]
	public interface IPathDrivenSplinePrepareData
	{
		// Token: 0x1700825E RID: 33374
		// (get) Token: 0x060301E9 RID: 197097
		// (set) Token: 0x060301EA RID: 197098
		int SplineEntityId { get; set; }

		// Token: 0x1700825F RID: 33375
		// (get) Token: 0x060301EB RID: 197099
		// (set) Token: 0x060301EC RID: 197100
		ISceneItemSplineMoveConfig SplineMoveConfig { get; set; }

		// Token: 0x17008260 RID: 33376
		// (get) Token: 0x060301ED RID: 197101
		// (set) Token: 0x060301EE RID: 197102
		List<string> CurvePaths { get; set; }
	}
}
