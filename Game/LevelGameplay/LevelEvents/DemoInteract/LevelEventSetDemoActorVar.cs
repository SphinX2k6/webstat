using System;
using System.Runtime.CompilerServices;
using Aki.TDConfigMgr.Action;
using CSharpScript.Core.Common;

namespace CSharpScript.Game.LevelGamePlay.LevelEvents.DemoInteract
{
	// Token: 0x02006CA7 RID: 27815
	public class LevelEventSetDemoActorVar : LevelEventBase
	{
		// Token: 0x06044350 RID: 279376 RVA: 0x011B4060 File Offset: 0x011B2260
		public LevelEventSetDemoActorVar(int id) : base(id)
		{
		}

		// Token: 0x06044351 RID: 279377 RVA: 0x011B406C File Offset: 0x011B226C
		[NullableContext(1)]
		public override void ExecuteNew(ActionParams inParams, GeneralContext context, int? actionId = null)
		{
			if (!Singleton<Info>.Instance.IsPlayInEditor)
			{
				return;
			}
			SetActorVar setActorVar = inParams as SetActorVar;
			string[] array = setActorVar.ActorRef.PathName.Split('.', StringSplitOptions.None);
			array[1] + "." + array[2];
			string varLeft = setActorVar.VarLeft;
			if (LevelGamePlayUtils.GetVarValue(setActorVar.VarRight, context) == null)
			{
				Singleton<global::Log>.Instance.Error(ELogModule.LevelEvent, ELogAuthor.ZYL, "[LevelEventSetDemoActorVar] 获取目标变量值失败", default(ReadOnlySpan<ValueTuple<string, object>>));
				return;
			}
		}
	}
}
