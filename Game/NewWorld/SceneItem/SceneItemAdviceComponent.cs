using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.Advice;
using CSharpScript.Game.NewWorld.Common.Component;
using CSharpScript.Game.NewWorld.Pawn.Component;

namespace CSharpScript.Game.NewWorld.SceneItem
{
	// Token: 0x020047E7 RID: 18407
	[NullableContext(2)]
	[Nullable(0)]
	public class SceneItemAdviceComponent : EntityComponent
	{
		// Token: 0x0602FBE3 RID: 195555 RVA: 0x00B6F820 File Offset: 0x00B6DA20
		protected override void OnActivate()
		{
			PawnInteractNewComponent component = base.Entity.GetComponent<PawnInteractNewComponent>();
			if (component == null)
			{
				return;
			}
			if (component.GetInteractController() == null)
			{
				return;
			}
			CreatureDataComponent component2 = base.Entity.GetComponent<CreatureDataComponent>();
			if (component2 == null)
			{
				return;
			}
			AdviceEntityData adviceInfo = component2.GetAdviceInfo();
			if (adviceInfo == null)
			{
				return;
			}
			PawnInfoManageComponent component3 = base.Entity.GetComponent<PawnInfoManageComponent>();
			if (component3 == null)
			{
				return;
			}
			this.TagComponent = base.Entity.GetComponent<LevelTagComponent>();
			string text = ConfigBase<AdviceConfig>.Instance.GetAdviceInteractText();
			text = text.Replace("{PlayerName}", adviceInfo.GetPlayerName());
			component3.PawnName = text;
		}

		// Token: 0x0602FBE4 RID: 195556 RVA: 0x00B6F8AC File Offset: 0x00B6DAAC
		public void DoInteract()
		{
			this.ClearTimer();
			if (this.TagComponent.HasTag(GameplayTagDefine.EGameplayTagId["关卡.Common.状态.常态"]))
			{
				this.TagComponent.ChangeLocalLevelTag(GameplayTagDefine.EGameplayTagId["关卡.Common.状态.激活"], GameplayTagDefine.EGameplayTagId["关卡.Common.状态.常态"]);
				Singleton<EventSystem>.Instance.EmitWithTarget<int, bool>(base.Entity, EEventName.OnSceneItemStateChange, GameplayTagDefine.EGameplayTagId["关卡.Common.状态.激活"], false);
				this.ClearTimer();
				this.RevertTimer = TimerSystem.Instance.Delay(new TTimerAction(this.OnInteractFinish), 3000f, null, null, true, 1f);
			}
		}

		// Token: 0x0602FBE5 RID: 195557 RVA: 0x00B6F95C File Offset: 0x00B6DB5C
		private void OnInteractFinish(float delta)
		{
			this.ClearTimer();
			if (this.TagComponent.HasTag(GameplayTagDefine.EGameplayTagId["关卡.Common.状态.激活"]))
			{
				this.TagComponent.ChangeLocalLevelTag(GameplayTagDefine.EGameplayTagId["关卡.Common.状态.常态"], GameplayTagDefine.EGameplayTagId["关卡.Common.状态.激活"]);
				Singleton<EventSystem>.Instance.EmitWithTarget<int, bool>(base.Entity, EEventName.OnSceneItemStateChange, GameplayTagDefine.EGameplayTagId["关卡.Common.状态.常态"], true);
			}
		}

		// Token: 0x0602FBE6 RID: 195558 RVA: 0x00B6F9DA File Offset: 0x00B6DBDA
		private void ClearTimer()
		{
			if (this.RevertTimer != null)
			{
				TimerSystem.Instance.Remove(this.RevertTimer);
				this.RevertTimer = null;
			}
		}

		// Token: 0x0602FBE7 RID: 195559 RVA: 0x00B6F9FC File Offset: 0x00B6DBFC
		protected override bool OnEnd()
		{
			this.ClearTimer();
			return true;
		}

		// Token: 0x0602FBE8 RID: 195560 RVA: 0x00B6FA08 File Offset: 0x00B6DC08
		[NullableContext(1)]
		public override bool ClearComponent(EntityComponent componentTemplate)
		{
			if (!base.ClearComponent(componentTemplate))
			{
				return false;
			}
			SceneItemAdviceComponent sceneItemAdviceComponent = (SceneItemAdviceComponent)componentTemplate;
			if (base.CanResetComponentProperty("TagComponent"))
			{
				if (sceneItemAdviceComponent.TagComponent == null)
				{
					this.TagComponent = null;
				}
				else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<LevelTagComponent>(this.TagComponent), "TagComponent"))
				{
					return false;
				}
			}
			if (base.CanResetComponentProperty("RevertTimer"))
			{
				if (sceneItemAdviceComponent.RevertTimer == null)
				{
					this.RevertTimer = null;
				}
				else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<TimerHandle>(this.RevertTimer), "RevertTimer"))
				{
					return false;
				}
			}
			return true;
		}

		// Token: 0x0401B5C1 RID: 112065
		private const int REVERTIME = 3000;

		// Token: 0x0401B5C2 RID: 112066
		private LevelTagComponent TagComponent;

		// Token: 0x0401B5C3 RID: 112067
		private TimerHandle RevertTimer;
	}
}
