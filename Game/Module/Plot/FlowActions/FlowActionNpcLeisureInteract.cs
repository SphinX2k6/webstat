using System;
using Aki.TDConfigMgr.Action;

namespace CSharpScript.Game.Module.Plot.FlowActions
{
	// Token: 0x02005427 RID: 21543
	public class FlowActionNpcLeisureInteract : FlowActionBase
	{
		// Token: 0x06036F5E RID: 225118 RVA: 0x00DF35D4 File Offset: 0x00DF17D4
		protected override void OnExecute()
		{
			NpcLeisureInteract npcLeisureInteract = this.ActionInfo.Params as NpcLeisureInteract;
			if (npcLeisureInteract == null)
			{
				Singleton<global::Log>.Instance.Error(ELogModule.LevelEvent, ELogAuthor.CWZ, " LevelEventNpcLeisureInteract, 坐下参数为空", default(ReadOnlySpan<ValueTuple<string, object>>));
				return;
			}
			switch (npcLeisureInteract.Option.Type)
			{
			case ENpcLeisureInteract.SitDown:
				break;
			case ENpcLeisureInteract.Swing:
			{
				EntityHandle entityByPbDataId = ModelBase<CreatureModel>.Instance.GetEntityByPbDataId(((INpcSwing)npcLeisureInteract.Option).TargetNpcId);
				WorldEntity worldEntity = (entityByPbDataId != null) ? entityByPbDataId.Entity : null;
				if (worldEntity == null)
				{
					return;
				}
				CharacterSwingComponent component = worldEntity.GetComponent<CharacterSwingComponent>();
				if (component == null)
				{
					return;
				}
				component.StartSwing(((INpcSwing)npcLeisureInteract.Option).SwingDa, ((INpcSwing)npcLeisureInteract.Option).EntityId, new bool?(((INpcSwing)npcLeisureInteract.Option).SkipSitDown.GetValueOrDefault()));
				break;
			}
			case ENpcLeisureInteract.SwingGetUp:
			{
				EntityHandle entityByPbDataId2 = ModelBase<CreatureModel>.Instance.GetEntityByPbDataId(((INpcSwingGetUp)npcLeisureInteract.Option).TargetNpcId);
				WorldEntity worldEntity2 = (entityByPbDataId2 != null) ? entityByPbDataId2.Entity : null;
				if (worldEntity2 == null)
				{
					return;
				}
				CharacterSwingComponent component2 = worldEntity2.GetComponent<CharacterSwingComponent>();
				if (component2 == null)
				{
					return;
				}
				component2.ExitLoopSwing();
				return;
			}
			default:
				return;
			}
		}
	}
}
