using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.TDConfigMgr.Component;
using CSharpScript.Game.NewWorld.SceneItem.Common.Component;
using UnrealEngine;

namespace CSharpScript.Game.Module.WuwaGo.Model.GameplayEntity
{
	// Token: 0x02004AE3 RID: 19171
	[NullableContext(2)]
	[Nullable(0)]
	public abstract class WuWaGoGameplayEntityBase : WuWaGoBaseUnit
	{
		// Token: 0x06031FB1 RID: 204721 RVA: 0x00C82E4C File Offset: 0x00C8104C
		[NullableContext(1)]
		protected WuWaGoGameplayEntityBase(EWuWaGoEntityType entityType, int pbDataId, Vector coordinate, Rotator rotator) : base(coordinate, rotator)
		{
		}

		// Token: 0x1700854D RID: 34125
		// (get) Token: 0x06031FB2 RID: 204722 RVA: 0x00C82E6C File Offset: 0x00C8106C
		public override bool Actionable
		{
			get
			{
				return false;
			}
		}

		// Token: 0x1700854E RID: 34126
		// (get) Token: 0x06031FB3 RID: 204723 RVA: 0x00C82E6F File Offset: 0x00C8106F
		public override bool MoveAbility
		{
			get
			{
				return false;
			}
		}

		// Token: 0x1700854F RID: 34127
		// (get) Token: 0x06031FB4 RID: 204724 RVA: 0x00C82E72 File Offset: 0x00C81072
		public IReadOnlyList<int> OpenAddClientTags
		{
			get
			{
				return this.OpenAddClientTagsInner;
			}
		}

		// Token: 0x06031FB5 RID: 204725 RVA: 0x00C82E7A File Offset: 0x00C8107A
		public void SetOpenAddClientTags(IReadOnlyList<int> tags)
		{
			this.OpenAddClientTagsInner = tags;
		}

		// Token: 0x17008550 RID: 34128
		// (get) Token: 0x06031FB6 RID: 204726 RVA: 0x00C82E83 File Offset: 0x00C81083
		// (set) Token: 0x06031FB7 RID: 204727 RVA: 0x00C82E8B File Offset: 0x00C8108B
		public EGameplayEntityState State { get; private set; }

		// Token: 0x17008551 RID: 34129
		// (get) Token: 0x06031FB8 RID: 204728 RVA: 0x00C82E94 File Offset: 0x00C81094
		// (set) Token: 0x06031FB9 RID: 204729 RVA: 0x00C82E9C File Offset: 0x00C8109C
		public int StandGridId { get; private set; }

		// Token: 0x06031FBA RID: 204730 RVA: 0x00C82EA5 File Offset: 0x00C810A5
		protected override AActor GetActorRaw()
		{
			return ControllerBase<CharacterController>.Instance.GetActor(this.EntityHandle);
		}

		// Token: 0x17008552 RID: 34130
		// (get) Token: 0x06031FBB RID: 204731 RVA: 0x00C82EB7 File Offset: 0x00C810B7
		public EntityHandle EntityHandle
		{
			get
			{
				return ModelBase<CreatureModel>.Instance.GetEntityByPbDataId(this.EntityPbDataId);
			}
		}

		// Token: 0x17008553 RID: 34131
		// (get) Token: 0x06031FBC RID: 204732 RVA: 0x00C82EC9 File Offset: 0x00C810C9
		public SceneItemMoveComponent SceneItemMoveComponent
		{
			get
			{
				EntityHandle entityHandle = this.EntityHandle;
				if (entityHandle == null)
				{
					return null;
				}
				WorldEntity entity = entityHandle.Entity;
				if (entity == null)
				{
					return null;
				}
				return entity.GetComponent<SceneItemMoveComponent>();
			}
		}

		// Token: 0x06031FBD RID: 204733 RVA: 0x00C82EE8 File Offset: 0x00C810E8
		public void SetStandGridId(int gridId)
		{
			if (this.StandGridId == gridId)
			{
				return;
			}
			base.MarkRollbackDirty();
			WuWaGoGrid standGridInner = this.StandGridInner;
			WuWaGoGrid wuWaGoGrid = (gridId == 0) ? null : ((standGridInner != null && standGridInner.Id == gridId) ? standGridInner : ModelBase<WuWaGoModel>.Instance.GetGridById(gridId));
			this.OnBeforeStandGridChanged(standGridInner, wuWaGoGrid);
			this.StandGridId = gridId;
			this.StandGridInner = wuWaGoGrid;
			this.OnAfterStandGridChanged(standGridInner, wuWaGoGrid);
		}

		// Token: 0x06031FBE RID: 204734 RVA: 0x00C82F4B File Offset: 0x00C8114B
		public void SetInitialState(EGameplayEntityState state)
		{
			this.InitialState = state;
		}

		// Token: 0x06031FBF RID: 204735 RVA: 0x00C82F54 File Offset: 0x00C81154
		public virtual bool SetState(EGameplayEntityState newState)
		{
			if (this.State == newState)
			{
				return false;
			}
			base.MarkRollbackDirty();
			this.State = newState;
			this.OnStateChanged(newState);
			return true;
		}

		// Token: 0x06031FC0 RID: 204736 RVA: 0x00C82F76 File Offset: 0x00C81176
		public virtual void Unlock()
		{
			this.State = this.InitialState;
		}

		// Token: 0x06031FC1 RID: 204737 RVA: 0x00C82F84 File Offset: 0x00C81184
		public virtual void RestoreInitialStateForGameOver()
		{
			this.State = this.InitialState;
		}

		// Token: 0x06031FC2 RID: 204738 RVA: 0x00C82F92 File Offset: 0x00C81192
		[NullableContext(1)]
		public override IRollbackCapture CaptureRollback()
		{
			return new GameplayEntityRollbackCapture<WuWaGoGameplayEntityBase>(this);
		}

		// Token: 0x06031FC3 RID: 204739 RVA: 0x00C82F9A File Offset: 0x00C8119A
		public void SetStateSilently(EGameplayEntityState newState)
		{
			if (this.State == newState)
			{
				return;
			}
			base.MarkRollbackDirty();
			this.State = newState;
		}

		// Token: 0x06031FC4 RID: 204740 RVA: 0x00C82FB3 File Offset: 0x00C811B3
		protected virtual void OnStateChanged(EGameplayEntityState newState)
		{
		}

		// Token: 0x06031FC5 RID: 204741 RVA: 0x00C82FB5 File Offset: 0x00C811B5
		protected void RestoreInitialStateWithStateChanged()
		{
			this.State = this.InitialState;
			this.OnStateChanged(this.InitialState);
		}

		// Token: 0x06031FC6 RID: 204742 RVA: 0x00C82FCF File Offset: 0x00C811CF
		protected virtual void OnBeforeStandGridChanged(WuWaGoGrid prevGrid, WuWaGoGrid nextGrid)
		{
		}

		// Token: 0x06031FC7 RID: 204743 RVA: 0x00C82FD1 File Offset: 0x00C811D1
		protected virtual void OnAfterStandGridChanged(WuWaGoGrid prevGrid, WuWaGoGrid nextGrid)
		{
		}

		// Token: 0x06031FC8 RID: 204744 RVA: 0x00C82FD4 File Offset: 0x00C811D4
		protected void SwitchSceneItemStateByGameplayEntityState(EGameplayEntityState newState, bool needTransition = true, bool jumpToEnd = false)
		{
			EntityHandle entityHandle = this.EntityHandle;
			WorldEntity worldEntity = (entityHandle != null) ? entityHandle.Entity : null;
			SceneItemActorComponent sceneItemActorComponent = (worldEntity != null) ? worldEntity.GetComponent<SceneItemActorComponent>() : null;
			CreatureDataComponent creatureDataComponent = (worldEntity != null) ? worldEntity.GetComponent<CreatureDataComponent>() : null;
			if (sceneItemActorComponent == null || creatureDataComponent == null)
			{
				return;
			}
			FGameplayTag? gameplayTagById = GameplayTagUtils.GetGameplayTagById(GameplayTagUtils.GetTagIdByName(newState.ToEnumString()));
			EKuroSceneInteractionState targetState;
			if (gameplayTagById == null || !creatureDataComponent.GetModelConfig().场景交互物状态列表.TryGetValue(gameplayTagById.Value, out targetState))
			{
				return;
			}
			sceneItemActorComponent.SwitchToState(targetState, needTransition, jumpToEnd);
		}

		// Token: 0x06031FC9 RID: 204745 RVA: 0x00C83054 File Offset: 0x00C81254
		public virtual void Destroy()
		{
			this.SetStandGridId(0);
			this.State = EGameplayEntityState.Locked;
			this.StandGridId = 0;
			this.StandGridInner = null;
		}

		// Token: 0x0401D3DF RID: 119775
		private WuWaGoGrid StandGridInner;

		// Token: 0x0401D3E0 RID: 119776
		public readonly int EntityPbDataId = pbDataId;

		// Token: 0x0401D3E1 RID: 119777
		private EGameplayEntityState InitialState = EGameplayEntityState.Normal;

		// Token: 0x0401D3E2 RID: 119778
		private IReadOnlyList<int> OpenAddClientTagsInner;

		// Token: 0x0401D3E5 RID: 119781
		public readonly EWuWaGoEntityType EntityType = entityType;
	}
}
