using System;
using System.Runtime.CompilerServices;
using Aki.TDConfigMgr.Action;
using CSharpScript.Game.NewWorld.Character.Npc.Logics;

namespace CSharpScript.Game.LevelGamePlay.LevelEvents
{
	// Token: 0x02006B80 RID: 27520
	public class LevelEventCloseWalkingOverlayMontage : LevelEventBase
	{
		// Token: 0x06043F1C RID: 278300 RVA: 0x011998B5 File Offset: 0x01197AB5
		public LevelEventCloseWalkingOverlayMontage(int id) : base(id)
		{
		}

		// Token: 0x06043F1D RID: 278301 RVA: 0x011998C0 File Offset: 0x01197AC0
		[NullableContext(1)]
		public override void ExecuteNew(ActionParams inParams, GeneralContext context, int? actionId = null)
		{
			CloseWalkingOverlayMontage closeWalkingOverlayMontage = inParams as CloseWalkingOverlayMontage;
			EntityHandle entityByPbDataId = ModelBase<CreatureModel>.Instance.GetEntityByPbDataId(closeWalkingOverlayMontage.EntityId);
			if (((entityByPbDataId != null) ? entityByPbDataId.Entity : null) == null)
			{
				base.FinishExecute(true, false, true);
				return;
			}
			int infoId = Singleton<PlayMontageUtils>.Instance.EntityIsPlayingMontage(entityByPbDataId.Entity.Id);
			Singleton<PlayMontageUtils>.Instance.ClearAndEndMontage(infoId, true, null);
			base.FinishExecute(true, false, true);
		}
	}
}
