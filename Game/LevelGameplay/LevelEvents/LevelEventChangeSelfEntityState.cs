using System;
using System.Runtime.CompilerServices;
using Aki.TDConfigMgr.Action;

namespace CSharpScript.Game.LevelGamePlay.LevelEvents
{
	// Token: 0x02006B75 RID: 27509
	public class LevelEventChangeSelfEntityState : LevelEventBase
	{
		// Token: 0x06043EE5 RID: 278245 RVA: 0x0119743D File Offset: 0x0119563D
		public LevelEventChangeSelfEntityState(int id) : base(id)
		{
		}

		// Token: 0x06043EE6 RID: 278246 RVA: 0x01197448 File Offset: 0x01195648
		[NullableContext(1)]
		public override void ExecuteNew(ActionParams inParams, GeneralContext context, int? actionId = null)
		{
			ChangeSelfEntityState changeSelfEntityState = inParams as ChangeSelfEntityState;
			int? num = null;
			num = new int?(GameplayTagUtils.GetTagIdByName(changeSelfEntityState.EntityState));
			int? num2 = null;
			EGeneralContextType? type = context.Type;
			if (type == null)
			{
				return;
			}
			EGeneralContextType valueOrDefault = type.GetValueOrDefault();
			if (valueOrDefault != EGeneralContextType.Entity)
			{
				if (valueOrDefault != EGeneralContextType.Trigger)
				{
					return;
				}
				num2 = (context as TriggerContext).TriggerEntityId;
			}
			else
			{
				num2 = (context as EntityContext).EntityId;
			}
			if (num == null || num2 == null)
			{
				return;
			}
			this.StateId = num.Value;
			EntityHandle entityById = ModelBase<CreatureModel>.Instance.GetEntityById(num2.Value);
			this.PbDataId = ModelBase<CreatureModel>.Instance.GetPbDataIdByEntity(entityById);
			base.CreateWaitEntityTask(this.PbDataId);
		}

		// Token: 0x06043EE7 RID: 278247 RVA: 0x0119750F File Offset: 0x0119570F
		protected override void ExecuteWhenEntitiesReady()
		{
			LevelGeneralCommons.PrechangeStateTag(this.PbDataId, this.StateId, "LevelEventChangeSelfEntityState");
			base.FinishExecute(true, false, true);
		}

		// Token: 0x06043EE8 RID: 278248 RVA: 0x01197530 File Offset: 0x01195730
		protected override void OnReset()
		{
			this.StateId = 0;
			this.PbDataId = 0;
		}

		// Token: 0x04025FDD RID: 155613
		private int StateId;

		// Token: 0x04025FDE RID: 155614
		private int PbDataId;
	}
}
