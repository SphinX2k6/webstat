using System;
using System.Runtime.CompilerServices;
using Aki.TDConfigMgr.Action;

namespace CSharpScript.Game.LevelGamePlay.LevelEvents
{
	// Token: 0x02006C08 RID: 27656
	public class LevelEventSpawnEffectV2 : LevelEventBase
	{
		// Token: 0x0604415F RID: 278879 RVA: 0x011AD444 File Offset: 0x011AB644
		public LevelEventSpawnEffectV2(int id) : base(id)
		{
		}

		// Token: 0x06044160 RID: 278880 RVA: 0x011AD450 File Offset: 0x011AB650
		[NullableContext(1)]
		public override void ExecuteNew(ActionParams inParams, GeneralContext context, int? actionId = null)
		{
			PlayEffect2 playEffect = inParams as PlayEffect2;
			if (playEffect == null)
			{
				return;
			}
			Singleton<SpawnEffectImplementation>.Instance.SpawnEffect(playEffect, context);
		}
	}
}
