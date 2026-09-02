using System;
using System.Runtime.CompilerServices;
using Aki.TDConfigMgr.Action;

namespace CSharpScript.Game.LevelGamePlay.LevelEvents
{
	// Token: 0x02006BB8 RID: 27576
	public class LevelEventNpcLeisureInteract : LevelEventBase
	{
		// Token: 0x06044013 RID: 278547 RVA: 0x011A0A2B File Offset: 0x0119EC2B
		public LevelEventNpcLeisureInteract(int id) : base(id)
		{
		}

		// Token: 0x06044014 RID: 278548 RVA: 0x011A0A34 File Offset: 0x0119EC34
		[NullableContext(1)]
		public override void ExecuteNew(ActionParams inParams, GeneralContext context, int? actionId = null)
		{
			NpcLeisureInteract npcLeisureInteract = inParams as NpcLeisureInteract;
			if (npcLeisureInteract == null)
			{
				Singleton<global::Log>.Instance.Error(ELogModule.LevelEvent, ELogAuthor.CWZ, " LevelEventNpcLeisureInteract, 坐下参数为空", default(ReadOnlySpan<ValueTuple<string, object>>));
				return;
			}
			INpcLeisureInteractType option = npcLeisureInteract.Option;
			INpcSitDown npcSitDown = option as INpcSitDown;
			if (npcSitDown != null)
			{
				ENpcLeisureInteract type = npcSitDown.Type;
				return;
			}
			INpcSwingGetUp npcSwingGetUp = option as INpcSwingGetUp;
			if (npcSwingGetUp == null)
			{
				INpcSwing npcSwing = option as INpcSwing;
				if (npcSwing != null)
				{
					if (npcSwing.Type != ENpcLeisureInteract.Swing)
					{
						return;
					}
					EntityHandle entityByPbDataId = ModelBase<CreatureModel>.Instance.GetEntityByPbDataId(npcSwing.TargetNpcId);
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
					component.StartSwing(npcSwing.SwingDa, npcSwing.EntityId, npcSwing.SkipSitDown);
				}
				return;
			}
			if (npcSwingGetUp.Type != ENpcLeisureInteract.SwingGetUp)
			{
				return;
			}
			EntityHandle entityByPbDataId2 = ModelBase<CreatureModel>.Instance.GetEntityByPbDataId(npcSwingGetUp.TargetNpcId);
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
		}
	}
}
