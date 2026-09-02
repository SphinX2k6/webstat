using System;
using System.Runtime.CompilerServices;
using Aki.TDConfigMgr.Action;
using CSharpScript.Game.Module.Reward;

namespace CSharpScript.Game.LevelGamePlay.LevelEvents
{
	// Token: 0x02006BBE RID: 27582
	public class LevelEventPickupDropItem : LevelEventBase
	{
		// Token: 0x0604403C RID: 278588 RVA: 0x011A26F7 File Offset: 0x011A08F7
		public LevelEventPickupDropItem(int id) : base(id)
		{
		}

		// Token: 0x0604403D RID: 278589 RVA: 0x011A2700 File Offset: 0x011A0900
		[NullableContext(1)]
		public override void ExecuteNew(ActionParams inParams, GeneralContext context, int? actionId = null)
		{
			ActionPickupDropItem actionPickupDropItem = inParams as ActionPickupDropItem;
			if (actionPickupDropItem == null)
			{
				base.FinishExecute(false, false, true);
				return;
			}
			int entityId = actionPickupDropItem.EntityId;
			Entity entity = Singleton<EntitySystem>.Instance.Get(entityId);
			if (entity == null || !entity.Valid)
			{
				base.FinishExecute(false, false, true);
				return;
			}
			CreatureDataComponent component = entity.GetComponent<CreatureDataComponent>();
			if (!ControllerBase<RewardController>.Instance.PickUpFightDrop(component.GetCreatureDataId(), component.GetPbDataId(), new Action<bool>(this.OnResponse)))
			{
				base.FinishExecute(false, false, true);
			}
		}

		// Token: 0x0604403E RID: 278590 RVA: 0x011A2783 File Offset: 0x011A0983
		private void OnResponse(bool isSuccess)
		{
			base.FinishExecute(isSuccess, false, true);
		}
	}
}
