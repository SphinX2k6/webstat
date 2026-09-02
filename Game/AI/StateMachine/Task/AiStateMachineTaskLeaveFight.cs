using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
using Aki.Config;
using Aki.TDConfigMgr.Component;
using AkiClient.Game.Aki.Render.RuntimeBP.Character.MaterialController;
using CSharpScript.Game.Effect;
using CSharpScript.Game.LevelGamePlay;
using CSharpScript.Game.Module.MonsterGroup;
using CSharpScript.Game.Utils.CombatStateMachine;
using UnrealEngine;

namespace CSharpScript.Game.AI.StateMachine.Task
{
	// Token: 0x020070D8 RID: 28888
	[NullableContext(1)]
	[Nullable(0)]
	public class AiStateMachineTaskLeaveFight : AiStateMachineTask
	{
		// Token: 0x060460A5 RID: 286885 RVA: 0x0126441C File Offset: 0x0126261C
		public AiStateMachineTaskLeaveFight(AiStateMachineBase stateMachineNode, CombatStateMachineDefine.Fsm.Task state) : base(stateMachineNode, state)
		{
		}

		// Token: 0x060460A6 RID: 286886 RVA: 0x01264468 File Offset: 0x01262668
		protected override bool OnInit(CombatStateMachineDefine.Fsm.Task task)
		{
			this.BlinkTime = task.TaskLeaveFight.BlinkTime;
			this.UsePatrolPointPriority = task.TaskLeaveFight.UsePatrolPointPriority;
			this.MaxStopTime = task.TaskLeaveFight.MaxStopTime;
			return true;
		}

		// Token: 0x060460A7 RID: 286887 RVA: 0x012644A0 File Offset: 0x012626A0
		public override void OnEnter(long? contextId = null)
		{
			this.Running = true;
			this.Teleported = false;
			AiController aiController = this.Node.AiController;
			if (aiController == null)
			{
				Singleton<Log>.Instance.Error(ELogModule.BehaviorTree, ELogAuthor.LCZ, "错误的Controller类型", default(ReadOnlySpan<ValueTuple<string, object>>));
				return;
			}
			this.Node.SkillComponent.StopAllSkills("AiStateMachineTaskLeaveFight.OnEnter");
			UAnimInstance mainAnimInstance = this.Node.AnimationComponent.MainAnimInstance;
			if (mainAnimInstance != null)
			{
				mainAnimInstance.Montage_Stop(0f, null);
			}
			AiWanderInfos aiWanderInfos = aiController.AiWanderInfos;
			AiWander? aiWander = (aiWanderInfos != null) ? aiWanderInfos.AiWander : null;
			if (aiWander == null)
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.BehaviorTree;
				ELogAuthor author = ELogAuthor.LCZ;
				string message = "没有配置AiWander";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("AiBaseId", aiController.AiBase.Value.Id);
				instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			}
			else
			{
				this.MoveStateActural = aiWander.Value.ResetMoveState;
				this.TsShowEffectDa = aiWander.Value.ShowEffectDaPath;
				this.TsHideEffectDa = aiWander.Value.HideEffectDaPath;
				this.TsShowMaterialDa = aiWander.Value.ShowMaterialDaPath;
				this.TsHideMaterialDa = aiWander.Value.HideMaterialDaPath;
			}
			CharacterActorComponent character = aiController.CharActorComp;
			MonsterPatrolInfo monsterInfoByEntityId = ModelBase<MonsterGroupPatrolModel>.Instance.GetMonsterInfoByEntityId(this.Node.Entity.Id);
			if (monsterInfoByEntityId != null)
			{
				this.InitLocation.DeepCopy(monsterInfoByEntityId.PauseLocation);
			}
			else
			{
				AiPatrolConfig config = aiController.AiPatrol.GetConfig();
				global::Vector vector = null;
				if (config != null)
				{
					int splineEntityId = config.SplineEntityId;
					CharacterPatrolComponent component = character.Entity.GetComponent<CharacterPatrolComponent>();
					if (component != null)
					{
						vector = component.GetLastPatrolLocation((long)config.SplineEntityId);
					}
				}
				if (vector != null)
				{
					this.InitLocation.DeepCopy(vector);
				}
				else
				{
					this.InitLocation.DeepCopy(this.Node.AiComponent.HatredInitLocation);
				}
			}
			if (aiWander == null || this.MoveStateActural == 3)
			{
				this.BlinkBegin(character);
			}
			else
			{
				AiStateMachineBase node = this.Node;
				bool flag;
				if (node == null)
				{
					flag = false;
				}
				else
				{
					CharacterActorComponent actorComponent = node.ActorComponent;
					flag = ((actorComponent != null) ? new bool?(actorComponent.IsAutonomousProxy) : null).GetValueOrDefault();
				}
				if (flag)
				{
					MoveCharacterPoint item = new MoveCharacterPoint
					{
						Index = 0,
						Position = global::Vector.Create(this.InitLocation),
						MoveState = new EPatrolMoveState?((EPatrolMoveState)this.MoveStateActural),
						MoveSpeed = new float?((float)400)
					};
					List<MoveCharacterPoint> list = new List<MoveCharacterPoint>();
					list.Add(item);
					MoveCharacterConfig config2 = new MoveCharacterConfig
					{
						Points = list,
						Navigation = true,
						IsFly = false,
						DebugMode = false,
						Loop = false,
						ReturnTimeoutFailed = new float?(this.MaxStopTime / 1000f),
						Callback = delegate(ELevelEventState result)
						{
							if (result == ELevelEventState.Success)
							{
								this.Finish(true);
								return;
							}
							this.BlinkBegin(character);
							Singleton<CombatLog>.Instance.Warn(CombatLog.EDebugModule.StateMachineNew, this.Node.Entity, "脱战复位未找到路，瞬移移动回初始点", default(ReadOnlySpan<ValueTuple<string, object>>));
						},
						ReturnFalseWhenNavigationFailed = true
					};
					this.Node.MoveComponent.MoveAlongPath(config2, "AiStateMachineTaskLeaveFight.OnEnter");
					BaseUnifiedStateComponent baseUnifiedStateComponent = character.Entity.CheckGetComponent<BaseUnifiedStateComponent>();
					if (baseUnifiedStateComponent.Valid)
					{
						int moveStateActural = this.MoveStateActural;
						if (moveStateActural != 1)
						{
							if (moveStateActural == 2)
							{
								baseUnifiedStateComponent.SetMoveState(ECharMoveState.Run);
							}
						}
						else
						{
							baseUnifiedStateComponent.SetMoveState(ECharMoveState.Walk);
						}
					}
				}
			}
			this.SetAiSceneEnable(aiController, false);
		}

		// Token: 0x060460A8 RID: 286888 RVA: 0x0126481C File Offset: 0x01262A1C
		private void SetAiSceneEnable(AiController aiController, bool enable)
		{
			AiPerception aiPerception = aiController.AiPerception as AiPerception;
			if (aiPerception != null)
			{
				aiPerception.SetAllAiSenseEnable(enable);
			}
		}

		// Token: 0x060460A9 RID: 286889 RVA: 0x0126483F File Offset: 0x01262A3F
		protected override void OnTick(float delta, long? contextId = null)
		{
			if (this.Node.AiController == null)
			{
				this.Finish(false);
				return;
			}
			if (this.InBlink)
			{
				this.BlinkTick(delta);
			}
		}

		// Token: 0x060460AA RID: 286890 RVA: 0x01264865 File Offset: 0x01262A65
		private void Finish(bool finish)
		{
			if (!this.Running)
			{
				return;
			}
			this.Node.TaskFinished = true;
			this.Running = false;
		}

		// Token: 0x060460AB RID: 286891 RVA: 0x01264884 File Offset: 0x01262A84
		public override void OnExit(long? contextId = null)
		{
			AiController aiController = this.Node.AiController;
			aiController.CharActorComp.SetInputDirect(global::Vector.ZeroVectorProxy, false);
			this.SetAiSceneEnable(aiController, true);
			TsBaseCharacter actor = this.Node.ActorComponent.Actor;
			if (this.InBlink)
			{
				actor.SetActorEnableCollision(true);
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.BehaviorTree;
				ELogAuthor author = ELogAuthor.LJM;
				string message = "AiWander[OnClear]怪物闪烁导致Actor碰撞为True";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("Actor:", actor);
				instance.Info(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			}
			int? num = this.HideMaterialData;
			int num2 = 0;
			if (num.GetValueOrDefault() >= num2 & num != null)
			{
				actor.CharRenderingComponent.RemoveMaterialControllerData(this.HideMaterialData.Value);
			}
			num = this.ShowMaterialData;
			num2 = 0;
			if (num.GetValueOrDefault() >= num2 & num != null)
			{
				actor.CharRenderingComponent.RemoveMaterialControllerData(this.ShowMaterialData.Value);
			}
			this.InBlink = false;
			this.Teleported = false;
			this.BlinkElapseTime = 0f;
			this.HideMaterialData = null;
			this.ShowMaterialData = null;
		}

		// Token: 0x060460AC RID: 286892 RVA: 0x012649A4 File Offset: 0x01262BA4
		private void BlinkBegin(CharacterActorComponent actor)
		{
			this.InBlink = true;
			this.BlinkElapseTime = 0f;
			this.ShowMaterialData = null;
			this.HideMaterialData = null;
			if (!string.IsNullOrEmpty(this.TsHideEffectDa))
			{
				EffectSystem instance = Singleton<EffectSystem>.Instance;
				UObject world = GlobalData.World;
				FTransformDouble? ftransformDouble = new FTransformDouble?(Singleton<MathUtils>.Instance.DefaultTransformDouble);
				int id = instance.SpawnEffect(world, ftransformDouble, this.TsHideEffectDa, "[AiStateMachineTaskLeaveFight.BlinkMoveBegin] hideEffect", new EffectContext(new int?(actor.Entity.Id), null, false), EEffectType.Scene, null, null, null, false, false);
				OneOf<KuroEffectActorHandle, AActor> effectActor = Singleton<EffectSystem>.Instance.GetEffectActor(id);
				if (effectActor.IsValid())
				{
					OneOf<KuroEffectActorHandle, AActor> self = effectActor;
					FVectorDouble actorLocation = actor.ActorLocation;
					self.D_K2_SetActorLocation(actorLocation, false, ref WorldGlobal.SweepHitResult, false);
				}
				else
				{
					Log instance2 = Singleton<Log>.Instance;
					ELogModule module = ELogModule.BehaviorTree;
					ELogAuthor author = ELogAuthor.LJM;
					string message = "AiWander瞬移隐藏特效生成失败";
					ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("Type", actor.Actor.GetName());
					instance2.Warn(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
				}
			}
			if (!string.IsNullOrEmpty(this.TsHideMaterialDa))
			{
				Singleton<ResourceSystem>.Instance.LoadAsync<PD_CharacterControllerData_C>(this.TsHideMaterialDa, delegate([Nullable(2)] PD_CharacterControllerData_C hideMaterial, string assetPath)
				{
					Log instance3 = Singleton<Log>.Instance;
					ELogModule module2 = ELogModule.BehaviorTree;
					ELogAuthor author2 = ELogAuthor.LJM;
					string message2 = "脱战隐藏材质加载回调";
					ValueTuple<string, object> valueTuple2 = new ValueTuple<string, object>("Type", actor.Actor.GetName());
					instance3.Info(module2, author2, message2, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple2));
					if (!this.Node.Activated)
					{
						return;
					}
					this.HideMaterialData = new int?(actor.Actor.CharRenderingComponent.AddMaterialControllerData(hideMaterial));
				}, 100, "js_undefined");
				return;
			}
			this.HideMaterialData = new int?(-1);
		}

		// Token: 0x060460AD RID: 286893 RVA: 0x01264AF8 File Offset: 0x01262CF8
		private void BlinkTick(float delta)
		{
			this.BlinkElapseTime += delta;
			if (this.BlinkElapseTime >= this.BlinkTime - 1000f && !this.Teleported)
			{
				this.BlinkTeleport();
				this.Teleported = true;
			}
			if (this.BlinkElapseTime >= this.BlinkTime)
			{
				this.BlinkEnd();
			}
		}

		// Token: 0x060460AE RID: 286894 RVA: 0x01264B54 File Offset: 0x01262D54
		private void BlinkTeleport()
		{
			CharacterActorComponent actor = this.Node.ActorComponent;
			this.Node.ActorComponent.SetMoveControlled(true, (double)(this.BlinkTime * 0.001f), "脱战传送");
			actor.SetActorLocation(this.InitLocation.ToUeVector(false), "脱战节点.执行瞬移重置位置", false);
			actor.FixBornLocation("脱战节点.修正角色地面位置", true, null, false, false, true);
			actor.Actor.SetActorEnableCollision(true);
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.BehaviorTree;
			ELogAuthor author = ELogAuthor.LJM;
			string message = "AiWander[BlinkMoveTick]怪物闪烁导致Actor碰撞为True";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("Actor:", actor.Actor.GetName());
			instance.Info(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			this.ResetAiInfo(actor);
			if (!string.IsNullOrEmpty(this.TsShowEffectDa))
			{
				EffectSystem instance2 = Singleton<EffectSystem>.Instance;
				UObject world = GlobalData.World;
				FTransformDouble? ftransformDouble = new FTransformDouble?(Singleton<MathUtils>.Instance.DefaultTransformDouble);
				int id = instance2.SpawnEffect(world, ftransformDouble, this.TsShowEffectDa, "[AiStateMachineTaskLeaveFight.BlinkMoveTick] showEffect", new EffectContext(new int?(actor.Entity.Id), null, false), EEffectType.Scene, null, null, null, false, false);
				OneOf<KuroEffectActorHandle, AActor> effectActor = Singleton<EffectSystem>.Instance.GetEffectActor(id);
				if (effectActor.IsValid())
				{
					OneOf<KuroEffectActorHandle, AActor> self = effectActor;
					FVectorDouble actorLocation = actor.ActorLocation;
					self.D_K2_SetActorLocation(actorLocation, false, ref WorldGlobal.SweepHitResult, false);
				}
				else
				{
					Log instance3 = Singleton<Log>.Instance;
					ELogModule module2 = ELogModule.BehaviorTree;
					ELogAuthor author2 = ELogAuthor.LJM;
					string message2 = "AiWander瞬移显示特效生成失败";
					ValueTuple<string, object> valueTuple2 = new ValueTuple<string, object>("Type", actor.Actor.GetName());
					instance3.Warn(module2, author2, message2, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple2));
				}
			}
			int? hideMaterialData = this.HideMaterialData;
			int num = 0;
			if (hideMaterialData.GetValueOrDefault() >= num & hideMaterialData != null)
			{
				actor.Actor.CharRenderingComponent.RemoveMaterialControllerData(this.HideMaterialData.Value);
				this.HideMaterialData = null;
			}
			if (!string.IsNullOrEmpty(this.TsShowMaterialDa))
			{
				Singleton<ResourceSystem>.Instance.LoadAsync<PD_CharacterControllerData_C>(this.TsShowMaterialDa, delegate([Nullable(2)] PD_CharacterControllerData_C showMaterial, string assetPath)
				{
					if (!this.Node.Activated)
					{
						return;
					}
					this.ShowMaterialData = new int?(actor.Actor.CharRenderingComponent.AddMaterialControllerData(showMaterial));
				}, 100, "js_undefined");
			}
			else
			{
				this.ShowMaterialData = new int?(-1);
			}
			actor.SetInputDirect(global::Vector.ZeroVectorProxy, false);
		}

		// Token: 0x060460AF RID: 286895 RVA: 0x01264D9C File Offset: 0x01262F9C
		private bool BlinkEnd()
		{
			CharacterActorComponent actorComponent = this.Node.ActorComponent;
			if (this.InBlink)
			{
				this.InBlink = false;
				if (!actorComponent.Actor.bActorEnableCollision)
				{
					Log instance = Singleton<Log>.Instance;
					ELogModule module = ELogModule.BehaviorTree;
					ELogAuthor author = ELogAuthor.LJM;
					string message = "AiWander[BlinkMoveEnd]怪物闪烁此刻Actor碰撞不应该为False,查看[BlinkMoveTick]是否置为True";
					ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("Actor:", actorComponent.Actor.GetName());
					instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
				}
				int? showMaterialData = this.ShowMaterialData;
				int num = 0;
				if (showMaterialData.GetValueOrDefault() >= num & showMaterialData != null)
				{
					actorComponent.Actor.CharRenderingComponent.RemoveMaterialControllerData(this.ShowMaterialData.Value);
					this.ShowMaterialData = null;
				}
				this.Finish(true);
				return true;
			}
			return false;
		}

		// Token: 0x060460B0 RID: 286896 RVA: 0x01264E58 File Offset: 0x01263058
		private void ResetAiInfo(CharacterActorComponent actor)
		{
			FRotator rotation = this.Node.Entity.GetComponent<CreatureDataComponent>().GetRotation();
			actor.SetActorRotation(rotation, "脱战节点.重置为基础方法", false);
		}

		// Token: 0x060460B1 RID: 286897 RVA: 0x01264E89 File Offset: 0x01263089
		public override void ToString(StringBuilder outBuilder, int depth = 0)
		{
			AiStateMachineHelper.AppendDepthSpace(outBuilder, depth);
		}

		// Token: 0x04027498 RID: 160920
		public float BlinkTime;

		// Token: 0x04027499 RID: 160921
		public bool UsePatrolPointPriority;

		// Token: 0x0402749A RID: 160922
		public float MaxStopTime;

		// Token: 0x0402749B RID: 160923
		private readonly global::Vector InitLocation = global::Vector.Create();

		// Token: 0x0402749C RID: 160924
		private bool InBlink;

		// Token: 0x0402749D RID: 160925
		private bool Teleported;

		// Token: 0x0402749E RID: 160926
		private float BlinkElapseTime;

		// Token: 0x0402749F RID: 160927
		private int? ShowMaterialData;

		// Token: 0x040274A0 RID: 160928
		private int? HideMaterialData;

		// Token: 0x040274A1 RID: 160929
		private int MoveStateActural;

		// Token: 0x040274A2 RID: 160930
		private string TsShowEffectDa = "";

		// Token: 0x040274A3 RID: 160931
		private string TsHideEffectDa = "";

		// Token: 0x040274A4 RID: 160932
		private string TsShowMaterialDa = "";

		// Token: 0x040274A5 RID: 160933
		private string TsHideMaterialDa = "";

		// Token: 0x040274A6 RID: 160934
		private bool Running;

		// Token: 0x040274A7 RID: 160935
		private const float BLINK_TIME = 1000f;

		// Token: 0x040274A8 RID: 160936
		private const int BLINK_TYPE = 3;
	}
}
