using System;
using System.Runtime.CompilerServices;
using Aki.TDConfigMgr.Action;
using CSharpScript.Game.NewWorld.Pawn.Component;
using CSharpScript.Game.NewWorld.Pawn.Controllers;
using CSharpScript.Game.NewWorld.SceneItem;
using UnrealEngine;

namespace CSharpScript.Game.LevelGamePlay.LevelAi.Tasks
{
	// Token: 0x02006E29 RID: 28201
	[NullableContext(1)]
	[Nullable(0)]
	public class LevelAiTaskSitDown : LevelAiTask
	{
		// Token: 0x06044731 RID: 280369 RVA: 0x011C8234 File Offset: 0x011C6434
		public unsafe override void MakePlanExpansions(PlanningContext context, LevelAiWorldState worldState)
		{
			string reason = "Sit Down Task Make Plan Expansions";
			<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("LevelIndex", context.CurrentLevelIndex);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("StepIndex", context.CurrentStepIndex);
			base.PrintDescription(reason, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
			if (!this.IsInit)
			{
				this.Init();
			}
			this.CreatePlanSteps(context, worldState.MakeCopy());
		}

		// Token: 0x06044732 RID: 280370 RVA: 0x011C82BC File Offset: 0x011C64BC
		public void Init()
		{
			if (this.IsInit)
			{
				return;
			}
			NpcLeisureInteract npcLeisureInteract = this.Params as NpcLeisureInteract;
			if (npcLeisureInteract == null)
			{
				return;
			}
			this.NotifyTick = false;
			this.NotifyTaskFinished = false;
			switch (npcLeisureInteract.Option.Type)
			{
			case ENpcLeisureInteract.SitDown:
				this.SitDown((INpcSitDown)npcLeisureInteract.Option);
				this.NotifyTick = this.ChairNeedSetMorph;
				this.NotifyTaskFinished = this.ChairNeedSetMorph;
				return;
			case ENpcLeisureInteract.Swing:
				this.Swing((INpcSwing)npcLeisureInteract.Option);
				return;
			case ENpcLeisureInteract.SwingGetUp:
				this.SwingGetUp((INpcSwingGetUp)npcLeisureInteract.Option);
				return;
			default:
				return;
			}
		}

		// Token: 0x06044733 RID: 280371 RVA: 0x011C835C File Offset: 0x011C655C
		private void Swing(INpcSwing option)
		{
			EntityHandle entityByPbDataId = ModelBase<CreatureModel>.Instance.GetEntityByPbDataId(option.TargetNpcId);
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
			component.StartSwing(option.SwingDa, option.EntityId, new bool?(option.SkipSitDown.GetValueOrDefault()));
		}

		// Token: 0x06044734 RID: 280372 RVA: 0x011C83B8 File Offset: 0x011C65B8
		private void SwingGetUp(INpcSwingGetUp option)
		{
			EntityHandle entityByPbDataId = ModelBase<CreatureModel>.Instance.GetEntityByPbDataId(option.TargetNpcId);
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
			component.ExitLoopSwing();
		}

		// Token: 0x06044735 RID: 280373 RVA: 0x011C83EC File Offset: 0x011C65EC
		private void SitDown(INpcSitDown option)
		{
			int posEntityId = option.PosEntityId;
			this.ItemEntity = ModelBase<CreatureModel>.Instance.GetEntityByPbDataId(posEntityId);
			if (this.ItemEntity == null)
			{
				global::Log instance = Singleton<global::Log>.Instance;
				ELogModule module = ELogModule.LevelAi;
				ELogAuthor author = ELogAuthor.YJX;
				DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(64, 1);
				defaultInterpolatedStringHandler.AppendLiteral("[LevelAiTaskSitDown] Cannot Find Corresponding Item Entity for: ");
				defaultInterpolatedStringHandler.AppendFormatted<int>(posEntityId);
				instance.Info(module, author, defaultInterpolatedStringHandler.ToStringAndClear(), default(ReadOnlySpan<ValueTuple<string, object>>));
				return;
			}
			PawnInteractNewComponent component = this.ItemEntity.Entity.GetComponent<PawnInteractNewComponent>();
			if (component == null)
			{
				global::Log instance2 = Singleton<global::Log>.Instance;
				ELogModule module2 = ELogModule.LevelAi;
				ELogAuthor author2 = ELogAuthor.YJX;
				DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(65, 1);
				defaultInterpolatedStringHandler.AppendLiteral("[LevelAiTaskSitDown] Item Entity ");
				defaultInterpolatedStringHandler.AppendFormatted<int>(posEntityId);
				defaultInterpolatedStringHandler.AppendLiteral(" has no PawnInteractNewComponent");
				instance2.Error(module2, author2, defaultInterpolatedStringHandler.ToStringAndClear(), default(ReadOnlySpan<ValueTuple<string, object>>));
				return;
			}
			PawnChairController pawnChairController = component.GetSubEntityInteractLogicController() as PawnChairController;
			BaseActorComponent component2 = base.CreatureDataComponent.Entity.GetComponent<BaseActorComponent>();
			int pbDataId = base.CreatureDataComponent.GetPbDataId();
			LevelAiTaskSuccess levelAiTaskSuccess = new LevelAiTaskSuccess();
			levelAiTaskSuccess.Serialize(base.CharacterPlanComponent, base.CreatureDataComponent, this.Description, null);
			pawnChairController.Possess(base.CreatureDataComponent.Entity, false);
			Vector sitLocation = pawnChairController.GetSitLocation();
			Vector forwardDirection = pawnChairController.GetForwardDirection();
			Vector vector = Vector.Create();
			Vector vector2 = Vector.Create();
			forwardDirection.Multiply(100.0, vector);
			sitLocation.Addition(vector, vector2);
			LevelAiTaskMoveTo levelAiTaskMoveTo = new LevelAiTaskMoveTo();
			levelAiTaskMoveTo.Serialize(base.CharacterPlanComponent, base.CreatureDataComponent, this.Description + " Move To Nearby Chair Location: " + vector2.ToString(), null);
			levelAiTaskMoveTo.Target = Vector.Create();
			levelAiTaskMoveTo.Target.DeepCopy(vector2);
			levelAiTaskMoveTo.MoveState = EMoveSpeed.Walk;
			levelAiTaskMoveTo.MoveSpeed = 100f;
			levelAiTaskSuccess.NextNodes.Add(levelAiTaskMoveTo);
			LevelAiTaskSetItemCollision levelAiTaskSetItemCollision = new LevelAiTaskSetItemCollision();
			levelAiTaskSetItemCollision.Serialize(base.CharacterPlanComponent, base.CreatureDataComponent, this.Description + " Ignore Actor Collision", null);
			levelAiTaskSetItemCollision.ItemEntity = this.ItemEntity;
			levelAiTaskSetItemCollision.IsIgnore = true;
			levelAiTaskMoveTo.NextNodes.Add(levelAiTaskSetItemCollision);
			Vector actorLocationProxy = component2.ActorLocationProxy;
			Vector vector3 = Vector.Create(sitLocation.X, sitLocation.Y, actorLocationProxy.Z);
			LevelAiTaskMoveTo levelAiTaskMoveTo2 = new LevelAiTaskMoveTo();
			levelAiTaskMoveTo2.Serialize(base.CharacterPlanComponent, base.CreatureDataComponent, this.Description + " Move To Interact Location: " + vector3.ToString(), null);
			levelAiTaskMoveTo2.Target = Vector.Create();
			levelAiTaskMoveTo2.Target.DeepCopy(vector3);
			levelAiTaskMoveTo2.MoveState = EMoveSpeed.Walk;
			levelAiTaskMoveTo2.MoveSpeed = 70f;
			levelAiTaskSetItemCollision.NextNodes.Add(levelAiTaskMoveTo2);
			Vector vector4 = Vector.Create();
			Vector vector5 = Vector.Create();
			forwardDirection.Multiply(200.0, vector5);
			vector2.Addition(vector5, vector4);
			TurnAndPlayMontageParam @params = new TurnAndPlayMontageParam
			{
				EntityId = pbDataId,
				Pos = vector4,
				MontageId = option.MontageId.MontageId,
				IsAbpMontage = option.MontageId.IsAbp,
				LoopDuration = option.Duration
			};
			LevelAiTaskTurnAndPlayMontage levelAiTaskTurnAndPlayMontage = new LevelAiTaskTurnAndPlayMontage();
			levelAiTaskTurnAndPlayMontage.Serialize(base.CharacterPlanComponent, base.CreatureDataComponent, this.Description + " Turn To Chair And Play Sit Down Montage", @params);
			levelAiTaskMoveTo2.NextNodes.Add(levelAiTaskTurnAndPlayMontage);
			pawnChairController.UnPossess(base.CreatureDataComponent.Entity);
			LevelAiTaskMoveTo levelAiTaskMoveTo3 = new LevelAiTaskMoveTo();
			levelAiTaskMoveTo3.Serialize(base.CharacterPlanComponent, base.CreatureDataComponent, this.Description + " Move Back To Nearby Chair Location: " + vector2.ToString(), null);
			levelAiTaskMoveTo3.Target = Vector.Create();
			levelAiTaskMoveTo3.Target.DeepCopy(vector2);
			levelAiTaskMoveTo3.MoveState = EMoveSpeed.Walk;
			levelAiTaskMoveTo3.MoveSpeed = 70f;
			levelAiTaskTurnAndPlayMontage.NextNodes.Add(levelAiTaskMoveTo3);
			LevelAiTaskSetItemCollision levelAiTaskSetItemCollision2 = new LevelAiTaskSetItemCollision();
			levelAiTaskSetItemCollision2.Serialize(base.CharacterPlanComponent, base.CreatureDataComponent, this.Description + " Reset Actor Collision", null);
			levelAiTaskSetItemCollision2.ItemEntity = this.ItemEntity;
			levelAiTaskSetItemCollision2.IsIgnore = false;
			levelAiTaskMoveTo3.NextNodes.Add(levelAiTaskSetItemCollision2);
			if (this.NextNodes.Count > 0)
			{
				foreach (LevelAiStandaloneNode item in this.NextNodes)
				{
					levelAiTaskSetItemCollision2.NextNodes.Add(item);
				}
				this.NextNodes.Clear();
			}
			this.NextNodes.Add(levelAiTaskSuccess);
			this.IsInit = true;
			EntityHandle itemEntity = this.ItemEntity;
			bool? flag;
			if (itemEntity == null)
			{
				flag = null;
			}
			else
			{
				WorldEntity entity = itemEntity.Entity;
				if (entity == null)
				{
					flag = null;
				}
				else
				{
					SceneItemProceduralMaterialComponent component3 = entity.GetComponent<SceneItemProceduralMaterialComponent>();
					flag = ((component3 != null) ? new bool?(component3.HasCustomType(SceneItemProceduralMaterialComponent.ECustomPrimitiveDataSceneItemType.Chair)) : null);
				}
			}
			bool? flag2 = flag;
			this.ChairNeedSetMorph = flag2.GetValueOrDefault();
		}

		// Token: 0x06044736 RID: 280374 RVA: 0x011C88E8 File Offset: 0x011C6AE8
		protected override void TickTask(float deltaTime)
		{
			base.TickTask(deltaTime);
			if (this.ChairNeedSetMorph)
			{
				CharacterAnimationComponent component = base.CreatureDataComponent.Entity.GetComponent<CharacterAnimationComponent>();
				float? num;
				if (component == null)
				{
					num = null;
				}
				else
				{
					UAnimInstance animInstance = component.GetAnimInstance();
					num = ((animInstance != null) ? new float?(animInstance.GetCurveValue(Singleton<CharacterNameDefines>.Instance.SEAT_MORPH)) : null);
				}
				float? num2 = num;
				float valueOrDefault = num2.GetValueOrDefault();
				ControllerBase<AnimController>.Instance.SetSeatMorph(this.ItemEntity.Entity, base.CreatureDataComponent.Entity.Id, (double)valueOrDefault);
			}
		}

		// Token: 0x06044737 RID: 280375 RVA: 0x011C897C File Offset: 0x011C6B7C
		protected override void OnTaskFinished(ELevelAiNodeResult result)
		{
			base.OnTaskFinished(result);
			if (this.ChairNeedSetMorph)
			{
				this.ChairNeedSetMorph = false;
				EntityHandle itemEntity = this.ItemEntity;
				if (((itemEntity != null) ? itemEntity.Entity : null) != null)
				{
					ControllerBase<AnimController>.Instance.SetSeatMorph(this.ItemEntity.Entity, base.CreatureDataComponent.Entity.Id, 0.0);
				}
			}
		}

		// Token: 0x0402617B RID: 156027
		private const float NEARBY_CHAIR_OFFSET = 100f;

		// Token: 0x0402617C RID: 156028
		private const float MOVE_TO_NEARBY_CHAIR_SPEED = 100f;

		// Token: 0x0402617D RID: 156029
		private const float MOVE_TO_CHAIR_SPEED = 70f;

		// Token: 0x0402617E RID: 156030
		public bool CanRecordPlanProgress;

		// Token: 0x0402617F RID: 156031
		public int Cost;

		// Token: 0x04026180 RID: 156032
		private bool IsInit;

		// Token: 0x04026181 RID: 156033
		[Nullable(2)]
		private EntityHandle ItemEntity;

		// Token: 0x04026182 RID: 156034
		private bool ChairNeedSetMorph;
	}
}
