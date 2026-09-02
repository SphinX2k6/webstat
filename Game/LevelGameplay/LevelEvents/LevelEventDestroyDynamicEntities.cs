using System;
using System.Runtime.CompilerServices;
using Aki.TDConfigMgr.Action;
using CSharpScript.Game.Common.Event;

namespace CSharpScript.Game.LevelGamePlay.LevelEvents
{
	// Token: 0x02006B85 RID: 27525
	public class LevelEventDestroyDynamicEntities : LevelEventBase
	{
		// Token: 0x06043F2A RID: 278314 RVA: 0x01199F01 File Offset: 0x01198101
		public LevelEventDestroyDynamicEntities(int id) : base(id)
		{
		}

		// Token: 0x06043F2B RID: 278315 RVA: 0x01199F0C File Offset: 0x0119810C
		[NullableContext(1)]
		public override void ExecuteNew(ActionParams inParams, GeneralContext context, int? actionId = null)
		{
			if ((inParams as DestroyDynamicEntities).DestroyEntitiesConfig.Type == EDynamicEntityType.VisionDisplay)
			{
				this.CurVisionEntityCount = 0;
				this.IsCheckingVisionDestroy = true;
				foreach (EntityHandle entityHandle in ModelBase<SceneTeamModel>.Instance.GetTeamEntities(true))
				{
					Entity entity = entityHandle.Entity;
					if (!(!entity) && !(!((entity != null) ? entity.GetComponent<CharacterVisionComponent>() : null)))
					{
						this.CurVisionEntityCount++;
						Singleton<EventSystem>.Instance.EmitWithTarget<Action>(entity, EEventName.VisionSummonEndByAction, delegate()
						{
							this.CurVisionEntityCount--;
							this.CheckVisionDestroyFinish();
						});
					}
				}
				this.IsCheckingVisionDestroy = false;
				this.CheckVisionDestroyFinish();
			}
		}

		// Token: 0x06043F2C RID: 278316 RVA: 0x01199FD8 File Offset: 0x011981D8
		private void CheckVisionDestroyFinish()
		{
			if (this.IsCheckingVisionDestroy)
			{
				return;
			}
			if (this.CurVisionEntityCount <= 0)
			{
				this.CurVisionEntityCount = 0;
				base.FinishExecute(true, false, true);
			}
		}

		// Token: 0x04025FF9 RID: 155641
		private int CurVisionEntityCount;

		// Token: 0x04025FFA RID: 155642
		private bool IsCheckingVisionDestroy;
	}
}
