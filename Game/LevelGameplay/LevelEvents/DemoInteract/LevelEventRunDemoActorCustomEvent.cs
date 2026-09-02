using System;
using System.Runtime.CompilerServices;
using Aki.TDConfigMgr.Action;
using CSharpScript.Core.Common;

namespace CSharpScript.Game.LevelGamePlay.LevelEvents.DemoInteract
{
	// Token: 0x02006CA6 RID: 27814
	public class LevelEventRunDemoActorCustomEvent : LevelEventBase
	{
		// Token: 0x0604434E RID: 279374 RVA: 0x011B4010 File Offset: 0x011B2210
		public LevelEventRunDemoActorCustomEvent(int id) : base(id)
		{
		}

		// Token: 0x0604434F RID: 279375 RVA: 0x011B401C File Offset: 0x011B221C
		[NullableContext(1)]
		public override void ExecuteNew(ActionParams inParams, GeneralContext context, int? actionId = null)
		{
			if (!Singleton<Info>.Instance.IsPlayInEditor)
			{
				return;
			}
			string[] array = (inParams as RunActorCustomEvent).ActorRef.PathName.Split('.', StringSplitOptions.None);
			array[1] + "." + array[2];
		}
	}
}
