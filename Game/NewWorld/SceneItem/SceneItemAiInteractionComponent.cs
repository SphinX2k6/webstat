using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Common.Event;

namespace CSharpScript.Game.NewWorld.SceneItem
{
	// Token: 0x020047E8 RID: 18408
	[NullableContext(1)]
	[Nullable(0)]
	public class SceneItemAiInteractionComponent : EntityComponent, IComponentDependency
	{
		// Token: 0x170081EB RID: 33259
		// (get) Token: 0x0602FBEA RID: 195562 RVA: 0x00B6FAA0 File Offset: 0x00B6DCA0
		[Nullable(new byte[]
		{
			2,
			1
		})]
		public static Type[] Dependencies
		{
			[return: Nullable(new byte[]
			{
				2,
				1
			})]
			get
			{
				return new Type[]
				{
					typeof(SceneItemActorComponent)
				};
			}
		}

		// Token: 0x0602FBEB RID: 195563 RVA: 0x00B6FAB8 File Offset: 0x00B6DCB8
		protected override bool OnStart()
		{
			this.LastUsedTime = -2000.0;
			this.IsUsingByAi = new bool?(false);
			this.ClearSearchInfo();
			this.OnEntityDeadEvent = new Action(this.OnEntityDead);
			if (!base.Entity.GetComponent<CreatureDataComponent>().GetVisible())
			{
				this.EnableHandler = new int?(base.Entity.Disable("[SceneItemAiInteractionComponent.OnStart] visible为false"));
			}
			else
			{
				this.EnableHandler = new int?(-1);
			}
			this.MoveComp = base.Entity.GetComponent<AiWeaponMovementComponent>();
			AiInteractionItemQueryManager.Get().RegisterItem(base.Entity);
			return true;
		}

		// Token: 0x0602FBEC RID: 195564 RVA: 0x00B6FB56 File Offset: 0x00B6DD56
		protected override bool OnEnd()
		{
			AiInteractionItemQueryManager.Get().UnRegisterItem(base.Entity);
			return true;
		}

		// Token: 0x0602FBED RID: 195565 RVA: 0x00B6FB6A File Offset: 0x00B6DD6A
		private void ClearSearchInfo()
		{
			this.IsSearchByAi = new bool?(false);
			this.SearchEntity = null;
		}

		// Token: 0x0602FBEE RID: 195566 RVA: 0x00B6FB7F File Offset: 0x00B6DD7F
		public void OnEntityDead()
		{
			Singleton<EventSystem>.Instance.RemoveWithTarget(this.SearchEntity, EEventName.CharOnRoleDeadTargetSelf, this.OnEntityDeadEvent);
			this.ClearSearchInfo();
		}

		// Token: 0x0602FBEF RID: 195567 RVA: 0x00B6FBA3 File Offset: 0x00B6DDA3
		public void SetSearched(Entity searchEntity)
		{
			if (this.IsSearchByAi.GetValueOrDefault())
			{
				return;
			}
			this.IsSearchByAi = new bool?(true);
			this.SearchEntity = searchEntity;
			Singleton<EventSystem>.Instance.AddWithTarget(searchEntity, EEventName.CharOnRoleDeadTargetSelf, this.OnEntityDeadEvent);
		}

		// Token: 0x0602FBF0 RID: 195568 RVA: 0x00B6FBDD File Offset: 0x00B6DDDD
		public void SetUnSearched()
		{
			if (!this.IsSearchByAi.GetValueOrDefault())
			{
				return;
			}
			this.OnEntityDead();
		}

		// Token: 0x0602FBF1 RID: 195569 RVA: 0x00B6FBF3 File Offset: 0x00B6DDF3
		public void OnLastUsed()
		{
			this.SetUnSearched();
			this.LastUsedTime = Singleton<Time>.Instance.WorldTime;
		}

		// Token: 0x0602FBF2 RID: 195570 RVA: 0x00B6FC0B File Offset: 0x00B6DE0B
		public bool CanBeUsed()
		{
			if (this.MoveComp != null)
			{
				return !this.MoveComp.EnableMovement.Value;
			}
			return Singleton<Time>.Instance.WorldTime - this.LastUsedTime > 2000.0;
		}

		// Token: 0x0602FBF3 RID: 195571 RVA: 0x00B6FC48 File Offset: 0x00B6DE48
		public bool HiddenItem(bool bHidden)
		{
			if (bHidden != (this.EnableHandler.GetValueOrDefault() != -1))
			{
				if (bHidden)
				{
					this.EnableHandler = new int?(base.Entity.Disable("[SceneItemAiInteractionComponent.HiddenItem] bHidden为true"));
				}
				else
				{
					base.Entity.Enable(this.EnableHandler.Value, "[SceneItemAiInteractionComponent.HiddenItem] bHidden为false");
					this.EnableHandler = new int?(-1);
				}
				return true;
			}
			return false;
		}

		// Token: 0x0602FBF4 RID: 195572 RVA: 0x00B6FCB4 File Offset: 0x00B6DEB4
		public void ItemAttachEntity(Entity entity)
		{
		}

		// Token: 0x0602FBF5 RID: 195573 RVA: 0x00B6FCB6 File Offset: 0x00B6DEB6
		public bool IsSearchByOther(int entityId)
		{
			return this.IsSearchByAi.GetValueOrDefault() && this.SearchEntity.Id != entityId;
		}

		// Token: 0x0602FBF6 RID: 195574 RVA: 0x00B6FCD8 File Offset: 0x00B6DED8
		public override bool ClearComponent(EntityComponent componentTemplate)
		{
			if (!base.ClearComponent(componentTemplate))
			{
				return false;
			}
			SceneItemAiInteractionComponent sceneItemAiInteractionComponent = (SceneItemAiInteractionComponent)componentTemplate;
			if (base.CanResetComponentProperty("IsSearchByAi"))
			{
				this.IsSearchByAi = sceneItemAiInteractionComponent.IsSearchByAi;
			}
			if (base.CanResetComponentProperty("SearchEntity"))
			{
				if (sceneItemAiInteractionComponent.SearchEntity == null)
				{
					this.SearchEntity = null;
				}
				else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<Entity>(this.SearchEntity), "SearchEntity"))
				{
					return false;
				}
			}
			if (base.CanResetComponentProperty("IsUsingByAi"))
			{
				this.IsUsingByAi = sceneItemAiInteractionComponent.IsUsingByAi;
			}
			if (base.CanResetComponentProperty("LastUsedTime"))
			{
				this.LastUsedTime = sceneItemAiInteractionComponent.LastUsedTime;
			}
			if (base.CanResetComponentProperty("EnableHandler"))
			{
				this.EnableHandler = sceneItemAiInteractionComponent.EnableHandler;
			}
			if (base.CanResetComponentProperty("MoveComp"))
			{
				if (sceneItemAiInteractionComponent.MoveComp == null)
				{
					this.MoveComp = null;
				}
				else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<AiWeaponMovementComponent>(this.MoveComp), "MoveComp"))
				{
					return false;
				}
			}
			if (base.CanResetComponentProperty("OnEntityDeadEvent"))
			{
				if (sceneItemAiInteractionComponent.OnEntityDeadEvent == null)
				{
					this.OnEntityDeadEvent = null;
				}
				else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<Action>(this.OnEntityDeadEvent), "OnEntityDeadEvent"))
				{
					return false;
				}
			}
			return true;
		}

		// Token: 0x0401B5C4 RID: 112068
		private const int AI_USED_COLD_DOWN = 2000;

		// Token: 0x0401B5C5 RID: 112069
		public bool? IsSearchByAi;

		// Token: 0x0401B5C6 RID: 112070
		[Nullable(2)]
		public Entity SearchEntity;

		// Token: 0x0401B5C7 RID: 112071
		public bool? IsUsingByAi;

		// Token: 0x0401B5C8 RID: 112072
		public double LastUsedTime = -2000.0;

		// Token: 0x0401B5C9 RID: 112073
		public int? EnableHandler;

		// Token: 0x0401B5CA RID: 112074
		[Nullable(2)]
		public AiWeaponMovementComponent MoveComp;

		// Token: 0x0401B5CB RID: 112075
		[Nullable(2)]
		public Action OnEntityDeadEvent;
	}
}
