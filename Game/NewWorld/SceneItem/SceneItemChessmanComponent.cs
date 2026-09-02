using System;
using System.Runtime.CompilerServices;
using Aki.TDConfigMgr.Component;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.LevelGamePlay;
using CSharpScript.Game.NewWorld.Common.Component;
using CSharpScript.Game.NewWorld.SceneItem.Common.Component;
using CSharpScript.Game.NewWorld.SceneItem.Jigsaw;
using UnrealEngine;

namespace CSharpScript.Game.NewWorld.SceneItem
{
	// Token: 0x020047EF RID: 18415
	[NullableContext(2)]
	[Nullable(0)]
	public class SceneItemChessmanComponent : EntityComponent
	{
		// Token: 0x0602FC98 RID: 195736 RVA: 0x00B7782C File Offset: 0x00B75A2C
		protected override bool OnInitData(IEntityArgs args = null)
		{
			ChessmanComponent config = args.GetP1<CreateEntityData>().GetParam<SceneItemChessmanComponent>() as ChessmanComponent;
			this.Config = config;
			return true;
		}

		// Token: 0x0602FC99 RID: 195737 RVA: 0x00B77854 File Offset: 0x00B75A54
		protected override bool OnStart()
		{
			this.ItemComponent = base.Entity.GetComponent<SceneItemJigsawItemComponent>();
			this.MoveComponent = base.Entity.GetComponent<SceneItemMoveComponent>();
			this.ActorComponent = base.Entity.GetComponent<SceneItemActorComponent>();
			this.TagComponent = base.Entity.GetComponent<LevelTagComponent>();
			SceneItemMoveComponent moveComponent = this.MoveComponent;
			if (moveComponent != null)
			{
				moveComponent.AddStopMoveCallback(new Action(this.OnTicTacToePieceMoveEnd));
			}
			Singleton<EventSystem>.Instance.AddWithTarget(base.Entity, EEventName.OnSceneInteractionShowCompleted, new Action(this.OnSceneInteractionLoadCompleted));
			return true;
		}

		// Token: 0x0602FC9A RID: 195738 RVA: 0x00B778E8 File Offset: 0x00B75AE8
		protected override bool OnEnd()
		{
			Singleton<EventSystem>.Instance.RemoveWithTarget(base.Entity, EEventName.OnSceneInteractionShowCompleted, new Action(this.OnSceneInteractionLoadCompleted));
			SceneItemMoveComponent moveComponent = this.MoveComponent;
			if (moveComponent != null)
			{
				moveComponent.RemoveStopMoveCallback(new Action(this.OnTicTacToePieceMoveEnd));
			}
			return true;
		}

		// Token: 0x0602FC9B RID: 195739 RVA: 0x00B77935 File Offset: 0x00B75B35
		[NullableContext(1)]
		public bool RegisterOnSceneInteractionLoadCompleted(Action callback)
		{
			SceneItemActorComponent actorComponent = this.ActorComponent;
			if (actorComponent != null && actorComponent.GetIsSceneInteractionLoadCompleted())
			{
				return false;
			}
			this.SceneInteractionLoadCompletedCallback = callback;
			return true;
		}

		// Token: 0x0602FC9C RID: 195740 RVA: 0x00B77955 File Offset: 0x00B75B55
		private void OnSceneInteractionLoadCompleted()
		{
			if (this.SceneInteractionLoadCompletedCallback != null)
			{
				this.SceneInteractionLoadCompletedCallback();
			}
		}

		// Token: 0x0602FC9D RID: 195741 RVA: 0x00B7796C File Offset: 0x00B75B6C
		private void OnPieceMoveStart()
		{
			LevelTagComponent tagComponent = this.TagComponent;
			if (tagComponent != null)
			{
				tagComponent.AddTag(new int?(GameplayTagDefine.EGameplayTagId["关卡.Common.表现.棋子.移动中"]));
			}
			ChessmanComponent config = this.Config;
			if (((config != null) ? config.StartMovingActions : null) == null)
			{
				return;
			}
			EntityContext context = EntityContext.Create(base.Entity.Id, null);
			ControllerBase<LevelGeneralController>.Instance.ExecuteActionsNew(this.Config.StartMovingActions, context, null);
		}

		// Token: 0x0602FC9E RID: 195742 RVA: 0x00B779E4 File Offset: 0x00B75BE4
		private void OnTicTacToePieceMoveEnd()
		{
			if (this.OnPieceMoveEnd != null)
			{
				SceneItemActorComponent actorComponent = this.ActorComponent;
				AActor aactor = (actorComponent != null) ? actorComponent.GetInteractionMainActor() : null;
				if (aactor != null)
				{
					this.OnPieceMoveEnd(aactor, this.ItemComponent, this.TargetJigsawIndex);
					this.TargetJigsawIndex = null;
				}
				this.OnPieceMoveEnd = null;
			}
			ChessmanComponent config = this.Config;
			if (((config != null) ? config.EndMovingActions : null) != null)
			{
				EntityContext context = EntityContext.Create(base.Entity.Id, null);
				ControllerBase<LevelGeneralController>.Instance.ExecuteActionsNew(this.Config.EndMovingActions, context, null);
			}
			LevelTagComponent tagComponent = this.TagComponent;
			if (tagComponent == null)
			{
				return;
			}
			tagComponent.RemoveTag(new int?(GameplayTagDefine.EGameplayTagId["关卡.Common.表现.棋子.移动中"]));
		}

		// Token: 0x0602FC9F RID: 195743 RVA: 0x00B77AA0 File Offset: 0x00B75CA0
		public void OnTicTacToePieceMove([Nullable(1)] JigsawIndex target, [Nullable(1)] Action<AActor, SceneItemJigsawItemComponent, JigsawIndex> onPieceMoveEnd, Vector movePoint0 = null, Vector movePoint1 = null, Vector movePoint2 = null)
		{
			SceneItemJigsawItemComponent itemComponent = this.ItemComponent;
			Vector vector;
			if (itemComponent == null)
			{
				vector = null;
			}
			else
			{
				SceneItemJigsawBaseComponent putDownBase = itemComponent.PutDownBase;
				vector = ((putDownBase != null) ? putDownBase.GetBlockLocationByIndex(target, true) : null);
			}
			Vector vector2 = vector;
			if (vector2 != null)
			{
				this.OnPieceMoveStart();
				if (movePoint0 == null || movePoint1 == null || movePoint2 == null)
				{
					SceneItemMoveComponent moveComponent = this.MoveComponent;
					if (moveComponent != null)
					{
						moveComponent.AddMoveTarget(new SceneItemMoveComponent.MoveTarget(vector2, 1f, 0f, -1f, -1f));
					}
				}
				else
				{
					SceneItemMoveComponent moveComponent2 = this.MoveComponent;
					if (moveComponent2 != null)
					{
						moveComponent2.AddMoveTarget(new SceneItemMoveComponent.MoveTarget(movePoint0, 0.25f, 0f, -1f, -1f));
					}
					SceneItemMoveComponent moveComponent3 = this.MoveComponent;
					if (moveComponent3 != null)
					{
						moveComponent3.AddMoveTarget(new SceneItemMoveComponent.MoveTarget(movePoint1, 0.25f, 0f, -1f, -1f));
					}
					SceneItemMoveComponent moveComponent4 = this.MoveComponent;
					if (moveComponent4 != null)
					{
						moveComponent4.AddMoveTarget(new SceneItemMoveComponent.MoveTarget(movePoint2, 0.25f, 0f, -1f, -1f));
					}
					SceneItemMoveComponent moveComponent5 = this.MoveComponent;
					if (moveComponent5 != null)
					{
						moveComponent5.AddMoveTarget(new SceneItemMoveComponent.MoveTarget(vector2, 0.25f, 0f, -1f, -1f));
					}
				}
				this.OnPieceMoveEnd = onPieceMoveEnd;
				this.TargetJigsawIndex = new JigsawIndex(target.Row, target.Col);
			}
		}

		// Token: 0x0602FCA0 RID: 195744 RVA: 0x00B77BE4 File Offset: 0x00B75DE4
		[NullableContext(1)]
		public void SetTicTacToePieceLocation(JigsawIndex target, [Nullable(new byte[]
		{
			2,
			1
		})] Action<AActor> refreshPickBoundsEvent)
		{
			SceneItemJigsawItemComponent itemComponent = this.ItemComponent;
			Vector vector;
			if (itemComponent == null)
			{
				vector = null;
			}
			else
			{
				SceneItemJigsawBaseComponent putDownBase = itemComponent.PutDownBase;
				vector = ((putDownBase != null) ? putDownBase.GetBlockLocationByIndex(target, true) : null);
			}
			Vector vector2 = vector;
			if (vector2 != null)
			{
				SceneItemMoveComponent moveComponent = this.MoveComponent;
				if (moveComponent != null)
				{
					moveComponent.StopMove(true, true);
				}
				SceneItemMoveComponent moveComponent2 = this.MoveComponent;
				if (moveComponent2 != null)
				{
					moveComponent2.AddStopMoveCallback(new Action(this.OnTicTacToePieceMoveEnd));
				}
				LevelTagComponent tagComponent = this.TagComponent;
				if (tagComponent != null)
				{
					tagComponent.RemoveTag(new int?(GameplayTagDefine.EGameplayTagId["关卡.Common.表现.棋子.出现"]));
				}
				LevelTagComponent tagComponent2 = this.TagComponent;
				if (tagComponent2 != null)
				{
					tagComponent2.AddTag(new int?(GameplayTagDefine.EGameplayTagId["关卡.Common.表现.棋子.消失"]));
				}
				this.TargetLocation = vector2;
				this.RefreshPickBoundsEvent = refreshPickBoundsEvent;
				if (this.SetLocationPerformanceTimerHandle == null)
				{
					this.SetLocationPerformanceTimerHandle = TimerSystem.Instance.Delay(new TTimerAction(this.ChessmanSetLocationPerformance), 1000f, null, null, true, 1f);
				}
			}
		}

		// Token: 0x0602FCA1 RID: 195745 RVA: 0x00B77CD4 File Offset: 0x00B75ED4
		private void ChessmanSetLocationPerformance(float _)
		{
			LevelTagComponent tagComponent = this.TagComponent;
			if (tagComponent != null)
			{
				tagComponent.RemoveTag(new int?(GameplayTagDefine.EGameplayTagId["关卡.Common.表现.棋子.消失"]));
			}
			LevelTagComponent tagComponent2 = this.TagComponent;
			if (tagComponent2 != null)
			{
				tagComponent2.AddTag(new int?(GameplayTagDefine.EGameplayTagId["关卡.Common.表现.棋子.出现"]));
			}
			TimerSystem.Instance.Delay(delegate(float _)
			{
				LevelTagComponent tagComponent3 = this.TagComponent;
				if (tagComponent3 == null)
				{
					return;
				}
				tagComponent3.RemoveTag(new int?(GameplayTagDefine.EGameplayTagId["关卡.Common.表现.棋子.出现"]));
			}, 1000f, null, null, true, 1f);
			SceneItemActorComponent actorComponent = this.ActorComponent;
			if (actorComponent != null)
			{
				actorComponent.SetActorLocation(this.TargetLocation.ToUeVector(false), "unknown", true);
			}
			SceneItemActorComponent actorComponent2 = this.ActorComponent;
			AActor aactor = (actorComponent2 != null) ? actorComponent2.GetInteractionMainActor() : null;
			if (aactor != null && this.RefreshPickBoundsEvent != null)
			{
				this.RefreshPickBoundsEvent(aactor);
			}
			this.SetLocationPerformanceTimerHandle = null;
			this.TargetLocation = null;
			this.RefreshPickBoundsEvent = null;
		}

		// Token: 0x0602FCA2 RID: 195746 RVA: 0x00B77DB4 File Offset: 0x00B75FB4
		public void OnTicTacToePieceMovingChange(bool moving)
		{
			if (moving)
			{
				LevelTagComponent tagComponent = this.TagComponent;
				if (tagComponent != null)
				{
					tagComponent.RemoveTag(new int?(GameplayTagDefine.EGameplayTagId["关卡.Common.表现.棋子.可操控"]));
				}
				LevelTagComponent tagComponent2 = this.TagComponent;
				if (tagComponent2 == null)
				{
					return;
				}
				tagComponent2.RemoveTag(new int?(GameplayTagDefine.EGameplayTagId["关卡.Common.表现.棋子.被选中"]));
				return;
			}
			else
			{
				LevelTagComponent tagComponent3 = this.TagComponent;
				if (tagComponent3 == null)
				{
					return;
				}
				tagComponent3.AddTag(new int?(GameplayTagDefine.EGameplayTagId["关卡.Common.表现.棋子.可操控"]));
				return;
			}
		}

		// Token: 0x0602FCA3 RID: 195747 RVA: 0x00B77E34 File Offset: 0x00B76034
		public void OnTicTacToePieceSelect(bool select, bool controller)
		{
			if (select)
			{
				LevelTagComponent tagComponent = this.TagComponent;
				if (tagComponent != null)
				{
					tagComponent.AddTag(new int?(GameplayTagDefine.EGameplayTagId["关卡.Common.表现.棋子.被选中"]));
				}
			}
			else
			{
				LevelTagComponent tagComponent2 = this.TagComponent;
				if (tagComponent2 != null)
				{
					tagComponent2.RemoveTag(new int?(GameplayTagDefine.EGameplayTagId["关卡.Common.表现.棋子.被选中"]));
				}
			}
			if (controller)
			{
				LevelTagComponent tagComponent3 = this.TagComponent;
				if (tagComponent3 == null)
				{
					return;
				}
				tagComponent3.AddTag(new int?(GameplayTagDefine.EGameplayTagId["关卡.Common.表现.棋子.可操控"]));
				return;
			}
			else
			{
				LevelTagComponent tagComponent4 = this.TagComponent;
				if (tagComponent4 == null)
				{
					return;
				}
				tagComponent4.RemoveTag(new int?(GameplayTagDefine.EGameplayTagId["关卡.Common.表现.棋子.可操控"]));
				return;
			}
		}

		// Token: 0x0602FCA4 RID: 195748 RVA: 0x00B77EE0 File Offset: 0x00B760E0
		[NullableContext(1)]
		public override bool ClearComponent(EntityComponent componentTemplate)
		{
			if (!base.ClearComponent(componentTemplate))
			{
				return false;
			}
			SceneItemChessmanComponent sceneItemChessmanComponent = (SceneItemChessmanComponent)componentTemplate;
			if (base.CanResetComponentProperty("ItemComponent"))
			{
				if (sceneItemChessmanComponent.ItemComponent == null)
				{
					this.ItemComponent = null;
				}
				else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<SceneItemJigsawItemComponent>(this.ItemComponent), "ItemComponent"))
				{
					return false;
				}
			}
			if (base.CanResetComponentProperty("MoveComponent"))
			{
				if (sceneItemChessmanComponent.MoveComponent == null)
				{
					this.MoveComponent = null;
				}
				else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<SceneItemMoveComponent>(this.MoveComponent), "MoveComponent"))
				{
					return false;
				}
			}
			if (base.CanResetComponentProperty("ActorComponent"))
			{
				if (sceneItemChessmanComponent.ActorComponent == null)
				{
					this.ActorComponent = null;
				}
				else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<SceneItemActorComponent>(this.ActorComponent), "ActorComponent"))
				{
					return false;
				}
			}
			if (base.CanResetComponentProperty("TagComponent"))
			{
				if (sceneItemChessmanComponent.TagComponent == null)
				{
					this.TagComponent = null;
				}
				else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<LevelTagComponent>(this.TagComponent), "TagComponent"))
				{
					return false;
				}
			}
			if (base.CanResetComponentProperty("Config"))
			{
				if (sceneItemChessmanComponent.Config == null)
				{
					this.Config = null;
				}
				else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<ChessmanComponent>(this.Config), "Config"))
				{
					return false;
				}
			}
			if (base.CanResetComponentProperty("SceneInteractionLoadCompletedCallback"))
			{
				if (sceneItemChessmanComponent.SceneInteractionLoadCompletedCallback == null)
				{
					this.SceneInteractionLoadCompletedCallback = null;
				}
				else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<Action>(this.SceneInteractionLoadCompletedCallback), "SceneInteractionLoadCompletedCallback"))
				{
					return false;
				}
			}
			if (base.CanResetComponentProperty("OnPieceMoveEnd"))
			{
				if (sceneItemChessmanComponent.OnPieceMoveEnd == null)
				{
					this.OnPieceMoveEnd = null;
				}
				else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<Action<AActor, SceneItemJigsawItemComponent, JigsawIndex>>(this.OnPieceMoveEnd), "OnPieceMoveEnd"))
				{
					return false;
				}
			}
			if (base.CanResetComponentProperty("TargetJigsawIndex"))
			{
				if (sceneItemChessmanComponent.TargetJigsawIndex == null)
				{
					this.TargetJigsawIndex = null;
				}
				else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<JigsawIndex>(this.TargetJigsawIndex), "TargetJigsawIndex"))
				{
					return false;
				}
			}
			if (base.CanResetComponentProperty("TargetLocation"))
			{
				if (sceneItemChessmanComponent.TargetLocation == null)
				{
					this.TargetLocation = null;
				}
				else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<Vector>(this.TargetLocation), "TargetLocation"))
				{
					return false;
				}
			}
			if (base.CanResetComponentProperty("SetLocationPerformanceTimerHandle"))
			{
				if (sceneItemChessmanComponent.SetLocationPerformanceTimerHandle == null)
				{
					this.SetLocationPerformanceTimerHandle = null;
				}
				else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<TimerHandle>(this.SetLocationPerformanceTimerHandle), "SetLocationPerformanceTimerHandle"))
				{
					return false;
				}
			}
			if (base.CanResetComponentProperty("RefreshPickBoundsEvent"))
			{
				if (sceneItemChessmanComponent.RefreshPickBoundsEvent == null)
				{
					this.RefreshPickBoundsEvent = null;
				}
				else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<Action<AActor>>(this.RefreshPickBoundsEvent), "RefreshPickBoundsEvent"))
				{
					return false;
				}
			}
			return true;
		}

		// Token: 0x0401B656 RID: 112214
		private const int CHESSMAN_SETLOCATION_PERFORMANCE_TIME = 1000;

		// Token: 0x0401B657 RID: 112215
		private SceneItemJigsawItemComponent ItemComponent;

		// Token: 0x0401B658 RID: 112216
		private SceneItemMoveComponent MoveComponent;

		// Token: 0x0401B659 RID: 112217
		private SceneItemActorComponent ActorComponent;

		// Token: 0x0401B65A RID: 112218
		private LevelTagComponent TagComponent;

		// Token: 0x0401B65B RID: 112219
		private ChessmanComponent Config;

		// Token: 0x0401B65C RID: 112220
		private Action SceneInteractionLoadCompletedCallback;

		// Token: 0x0401B65D RID: 112221
		[Nullable(new byte[]
		{
			2,
			1,
			1,
			1
		})]
		private Action<AActor, SceneItemJigsawItemComponent, JigsawIndex> OnPieceMoveEnd;

		// Token: 0x0401B65E RID: 112222
		private JigsawIndex TargetJigsawIndex;

		// Token: 0x0401B65F RID: 112223
		private Vector TargetLocation;

		// Token: 0x0401B660 RID: 112224
		private TimerHandle SetLocationPerformanceTimerHandle;

		// Token: 0x0401B661 RID: 112225
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private Action<AActor> RefreshPickBoundsEvent;
	}
}
