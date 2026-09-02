using System;
using System.Runtime.CompilerServices;
using Aki.TDConfigMgr.Action;

namespace CSharpScript.Game.LevelGamePlay
{
	// Token: 0x02006A2C RID: 27180
	[NullableContext(1)]
	[Nullable(0)]
	public class ActionSpawnDestructibleActorWithTrackCapability : ActionParams
	{
		// Token: 0x06043456 RID: 275542 RVA: 0x0114A3FC File Offset: 0x011485FC
		public ActionSpawnDestructibleActorWithTrackCapability(SpawnDestructibleActorWithTrackCapability spawnDestructibleParam)
		{
			this.SpawnDestructibleParam = spawnDestructibleParam;
		}

		// Token: 0x1700A235 RID: 41525
		// (get) Token: 0x06043457 RID: 275543 RVA: 0x0114A40B File Offset: 0x0114860B
		public SpawnDestructibleActorWithTrackCapability SpawnDestructibleParam { get; }
	}
}
