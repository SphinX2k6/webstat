using System;
using System.Runtime.CompilerServices;
using Aki.TDConfigMgr.Action;
using CSharpScript.Game.NewWorld.Common.Component;

namespace CSharpScript.Game.LevelGamePlay.LevelEvents
{
	// Token: 0x02006BB1 RID: 27569
	public class LevelEventLockEntity : LevelEventBase
	{
		// Token: 0x06043FF4 RID: 278516 RVA: 0x0119F593 File Offset: 0x0119D793
		public LevelEventLockEntity(int id) : base(id)
		{
		}

		// Token: 0x06043FF5 RID: 278517 RVA: 0x0119F59C File Offset: 0x0119D79C
		[NullableContext(1)]
		public override void ExecuteNew(ActionParams inParams, GeneralContext context, int? actionId = null)
		{
			if (context.Type.GetValueOrDefault() != EGeneralContextType.Entity || !(context as EntityContext).ClientExecuteActions)
			{
				base.FinishExecute(true, false, true);
				return;
			}
			this.Config = (inParams as LockEntity);
			base.CreateWaitEntityTask(this.Config.EntityIds);
		}

		// Token: 0x06043FF6 RID: 278518 RVA: 0x0119F5EC File Offset: 0x0119D7EC
		protected override void ExecuteWhenEntitiesReady()
		{
			foreach (int pbDataId in this.Config.EntityIds)
			{
				EntityHandle entityByPbDataId = ModelBase<CreatureModel>.Instance.GetEntityByPbDataId(pbDataId);
				if (entityByPbDataId != null && entityByPbDataId.IsInit)
				{
					LevelTagComponent component = entityByPbDataId.Entity.GetComponent<LevelTagComponent>();
					if (component != null)
					{
						component.AddServerTagByIdLocal(GameplayTagDefine.EGameplayTagId["关卡.Common.属性.锁定"], "LevelEventLockEntity");
					}
				}
			}
			base.FinishExecute(true, false, true);
		}

		// Token: 0x06043FF7 RID: 278519 RVA: 0x0119F690 File Offset: 0x0119D890
		protected override void OnReset()
		{
			this.Config = null;
		}

		// Token: 0x04026035 RID: 155701
		[Nullable(2)]
		private LockEntity Config;
	}
}
