using System;
using System.Runtime.CompilerServices;
using Aki.TDConfigMgr.Action;
using CSharpScript.Game.Common.Event;

namespace CSharpScript.Game.LevelGamePlay.LevelEvents
{
	// Token: 0x02006B6C RID: 27500
	public class LevelEventBreakWeakness : LevelEventBase
	{
		// Token: 0x06043EBD RID: 278205 RVA: 0x01193741 File Offset: 0x01191941
		public LevelEventBreakWeakness(int id) : base(id)
		{
		}

		// Token: 0x06043EBE RID: 278206 RVA: 0x0119374C File Offset: 0x0119194C
		[NullableContext(1)]
		public override void ExecuteNew(ActionParams inParams, GeneralContext context, int? actionId = null)
		{
			if (context.Type.GetValueOrDefault() != EGeneralContextType.Entity)
			{
				base.FinishExecute(false, false, true);
				return;
			}
			Entity entity = Singleton<EntitySystem>.Instance.Get((context as EntityContext).EntityId.Value);
			if (entity == null || !entity.Valid)
			{
				base.FinishExecute(false, false, true);
				return;
			}
			Singleton<EventSystem>.Instance.Emit<int>(EEventName.MonsterBeginBroken, entity.Id);
			base.FinishExecute(true, false, true);
		}
	}
}
