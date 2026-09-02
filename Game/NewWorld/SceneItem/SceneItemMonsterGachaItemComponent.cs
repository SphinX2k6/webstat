using System;
using System.Runtime.CompilerServices;
using Aki.TDConfigMgr.Component;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Render;
using UnrealEngine;

namespace CSharpScript.Game.NewWorld.SceneItem
{
	// Token: 0x02004801 RID: 18433
	[NullableContext(2)]
	[Nullable(0)]
	public class SceneItemMonsterGachaItemComponent : EntityComponent
	{
		// Token: 0x0602FED2 RID: 196306 RVA: 0x00B92AC0 File Offset: 0x00B90CC0
		protected override bool OnInitData(IEntityArgs args = null)
		{
			MonsterGachaItemComponent config = args.GetP1<CreateEntityData>().GetParam<SceneItemMonsterGachaItemComponent>() as MonsterGachaItemComponent;
			this.Config = config;
			return true;
		}

		// Token: 0x0602FED3 RID: 196307 RVA: 0x00B92AE6 File Offset: 0x00B90CE6
		protected override bool OnStart()
		{
			this.ActorComp = base.Entity.GetComponent<SceneItemActorComponent>();
			Singleton<EventSystem>.Instance.OnceWithTarget(base.Entity, EEventName.OnSceneInteractionLoadCompleted, new Action(this.OnSceneInteractionLoadCompleted));
			return true;
		}

		// Token: 0x0602FED4 RID: 196308 RVA: 0x00B92B1C File Offset: 0x00B90D1C
		private void OnSceneInteractionLoadCompleted()
		{
			Singleton<ResourceSystem>.Instance.LoadAsync<ItemMaterialControllerActorData>(this.Config.MaterialDataPath, delegate([Nullable(2)] ItemMaterialControllerActorData result, string _)
			{
				if (result == null)
				{
					return;
				}
				TArray<AActor> sceneInteractionAllActorsInLevel = SceneInteractionManager.Get().GetSceneInteractionAllActorsInLevel(this.ActorComp.GetSceneInteractionLevelHandleId());
				for (int i = 0; i < sceneInteractionAllActorsInLevel.Num(); i++)
				{
					AActor actor = sceneInteractionAllActorsInLevel.Get(i);
					Singleton<ItemMaterialManager>.Instance.AddMaterialData(actor, result);
				}
			}, 100, "js_undefined");
		}

		// Token: 0x0602FED5 RID: 196309 RVA: 0x00B92B48 File Offset: 0x00B90D48
		[NullableContext(1)]
		public override bool ClearComponent(EntityComponent componentTemplate)
		{
			if (!base.ClearComponent(componentTemplate))
			{
				return false;
			}
			SceneItemMonsterGachaItemComponent sceneItemMonsterGachaItemComponent = (SceneItemMonsterGachaItemComponent)componentTemplate;
			if (base.CanResetComponentProperty("Config"))
			{
				if (sceneItemMonsterGachaItemComponent.Config == null)
				{
					this.Config = null;
				}
				else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<MonsterGachaItemComponent>(this.Config), "Config"))
				{
					return false;
				}
			}
			if (base.CanResetComponentProperty("ActorComp"))
			{
				if (sceneItemMonsterGachaItemComponent.ActorComp == null)
				{
					this.ActorComp = null;
				}
				else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<SceneItemActorComponent>(this.ActorComp), "ActorComp"))
				{
					return false;
				}
			}
			return true;
		}

		// Token: 0x0401B830 RID: 112688
		private MonsterGachaItemComponent Config;

		// Token: 0x0401B831 RID: 112689
		private SceneItemActorComponent ActorComp;
	}
}
