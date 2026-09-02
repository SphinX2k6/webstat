using System;
using System.Runtime.CompilerServices;
using Aki.TDConfigMgr.Action;

namespace CSharpScript.Game.LevelGamePlay
{
	// Token: 0x02006A28 RID: 27176
	[NullableContext(1)]
	[Nullable(0)]
	public class ActionSpawnBlueprintActor : ActionParams
	{
		// Token: 0x06043437 RID: 275511 RVA: 0x0114A2F0 File Offset: 0x011484F0
		public ActionSpawnBlueprintActor(ISpawnDestructibleStoneTrackTargetWhileRotate spawnBlueprintParam)
		{
			this.SpawnBlueprintParam = spawnBlueprintParam;
		}

		// Token: 0x1700A227 RID: 41511
		// (get) Token: 0x06043438 RID: 275512 RVA: 0x0114A2FF File Offset: 0x011484FF
		public ISpawnDestructibleStoneTrackTargetWhileRotate SpawnBlueprintParam { get; }
	}
}
