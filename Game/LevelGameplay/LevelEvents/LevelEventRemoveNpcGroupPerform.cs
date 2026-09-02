using System;
using System.Runtime.CompilerServices;
using Aki.TDConfigMgr.Action;
using CSharpScript.Game.NewWorld.Character.Common.Component.Move.AssistedWalk;

namespace CSharpScript.Game.LevelGamePlay.LevelEvents
{
	// Token: 0x02006BD4 RID: 27604
	public class LevelEventRemoveNpcGroupPerform : LevelEventBase
	{
		// Token: 0x0604408C RID: 278668 RVA: 0x011A5A2C File Offset: 0x011A3C2C
		public LevelEventRemoveNpcGroupPerform(int id) : base(id)
		{
		}

		// Token: 0x0604408D RID: 278669 RVA: 0x011A5A38 File Offset: 0x011A3C38
		[NullableContext(1)]
		public override void ExecuteNew(ActionParams inParams, GeneralContext context, int? actionId = null)
		{
			string key = (inParams as RemoveNpcGroupPerform).Key;
			HoldingHandsModel instance = ModelBase<HoldingHandsModel>.Instance;
			if (((instance != null) ? instance.GetRelation(key) : null) != null)
			{
				ControllerBase<HoldingHandsController>.Instance.RequestReleaseHands(key, "关卡行为", false, true);
			}
			if (Singleton<AssistedWalkUtils>.Instance.GetRelation(key) != null)
			{
				Singleton<AssistedWalkUtils>.Instance.RequestStopAssistedWalk(key, "关卡行为", global::EHandType.Right);
			}
			base.FinishExecute(true, false, true);
		}
	}
}
