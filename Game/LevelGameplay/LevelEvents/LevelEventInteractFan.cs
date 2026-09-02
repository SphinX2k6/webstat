using System;
using System.Runtime.CompilerServices;
using Aki.TDConfigMgr.Action;
using CSharpScript.Game.NewWorld.SceneItem;

namespace CSharpScript.Game.LevelGamePlay.LevelEvents
{
	// Token: 0x02006BAD RID: 27565
	public class LevelEventInteractFan : LevelEventBase
	{
		// Token: 0x06043FE2 RID: 278498 RVA: 0x0119E60F File Offset: 0x0119C80F
		public LevelEventInteractFan(int id) : base(id)
		{
		}

		// Token: 0x06043FE3 RID: 278499 RVA: 0x0119E618 File Offset: 0x0119C818
		[NullableContext(1)]
		public override void ExecuteNew(ActionParams inParams, GeneralContext context, int? actionId = null)
		{
			ActionInteractFan actionInteractFan = inParams as ActionInteractFan;
			if (actionInteractFan == null)
			{
				return;
			}
			int entityId = actionInteractFan.EntityId;
			SceneItemFanComponent component = Singleton<EntitySystem>.Instance.GetComponent<SceneItemFanComponent>(entityId);
			if (component == null)
			{
				return;
			}
			component.ExecuteInteract();
			base.FinishExecute(true, false, true);
		}
	}
}
