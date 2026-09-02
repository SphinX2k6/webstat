using System;
using System.Runtime.CompilerServices;
using Aki.TDConfigMgr.Action;
using CSharpScript.Game.NewWorld.SceneItem;

namespace CSharpScript.Game.LevelGamePlay.LevelEvents
{
	// Token: 0x02006BAE RID: 27566
	public class LevelEventInteractGravityFlip : LevelEventBase
	{
		// Token: 0x06043FE4 RID: 278500 RVA: 0x0119E656 File Offset: 0x0119C856
		public LevelEventInteractGravityFlip(int id) : base(id)
		{
		}

		// Token: 0x06043FE5 RID: 278501 RVA: 0x0119E660 File Offset: 0x0119C860
		[NullableContext(1)]
		public override void ExecuteNew(ActionParams inParams, GeneralContext context, int? actionId = null)
		{
			ActionInteractGravityFlip actionInteractGravityFlip = inParams as ActionInteractGravityFlip;
			if (actionInteractGravityFlip == null)
			{
				return;
			}
			int entityId = actionInteractGravityFlip.EntityId;
			SceneItemGravityFlipComponent component = Singleton<EntitySystem>.Instance.GetComponent<SceneItemGravityFlipComponent>(entityId);
			if (component == null)
			{
				return;
			}
			component.ExecuteInteract();
			base.FinishExecute(true, false, true);
		}
	}
}
