using System;
using System.Runtime.CompilerServices;
using Aki.TDConfigMgr.Action;
using CSharpScript.Game.Module.ItemDeliver;

namespace CSharpScript.Game.LevelGamePlay.LevelEvents
{
	// Token: 0x02006B84 RID: 27524
	public class LevelEventDeliverQuestBehavior : LevelEventBase
	{
		// Token: 0x06043F28 RID: 278312 RVA: 0x01199E8B File Offset: 0x0119808B
		public LevelEventDeliverQuestBehavior(int id) : base(id)
		{
		}

		// Token: 0x06043F29 RID: 278313 RVA: 0x01199E94 File Offset: 0x01198094
		[NullableContext(1)]
		public override void ExecuteNew(ActionParams inParams, GeneralContext context, int? actionId = null)
		{
			ActionDeliverQuestBehavior actionDeliverQuestBehavior = inParams as ActionDeliverQuestBehavior;
			if (actionDeliverQuestBehavior == null)
			{
				return;
			}
			EntityHandle entityByPbDataId = ModelBase<CreatureModel>.Instance.GetEntityByPbDataId(actionDeliverQuestBehavior.EntityId);
			string npcName = "";
			if (entityByPbDataId != null)
			{
				PawnInfoManageComponent component = entityByPbDataId.Entity.GetComponent<PawnInfoManageComponent>();
				npcName = (((component != null) ? component.PawnName : null) ?? "");
			}
			ControllerBase<ItemDeliverController>.Instance.OpenItemDeliverViewByHandInItem(actionDeliverQuestBehavior.Items, npcName, null, actionDeliverQuestBehavior.DescText, null);
		}
	}
}
