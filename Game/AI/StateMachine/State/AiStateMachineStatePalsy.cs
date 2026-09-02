using System;
using System.Runtime.CompilerServices;
using System.Text;
using AkiClient.Game.Aki.Character.BaseCharacter;
using CSharpScript.Game.Camera;
using CSharpScript.Game.NewWorld.Pawn.Component;
using CSharpScript.Game.Utils.CombatStateMachine;
using UnrealEngine;

namespace CSharpScript.Game.AI.StateMachine.State
{
	// Token: 0x020070ED RID: 28909
	[NullableContext(1)]
	[Nullable(0)]
	public class AiStateMachineStatePalsy : AiStateMachineState
	{
		// Token: 0x06046146 RID: 287046 RVA: 0x012680ED File Offset: 0x012662ED
		public AiStateMachineStatePalsy(AiStateMachineBase stateMachineNode, CombatStateMachineDefine.Fsm.State state) : base(stateMachineNode, state)
		{
		}

		// Token: 0x06046147 RID: 287047 RVA: 0x01268110 File Offset: 0x01266310
		[NullableContext(2)]
		public unsafe override void OnActivate(AiStateMachineBase lastState = null, long? contextId = null)
		{
			if (!string.IsNullOrEmpty(this.CounterAttackCamera))
			{
				CounterAttackCameraData loadedAsset = Singleton<ResourceSystem>.Instance.GetLoadedAsset<CounterAttackCameraData>(this.CounterAttackCamera);
				if (loadedAsset != null)
				{
					ControllerBase<CameraController>.Instance.MainModel.FightCamera.LogicComponent.ApplyCameraModify(new FGameplayTag?(loadedAsset.CameraData.Tag), loadedAsset.CameraData.持续时间, loadedAsset.CameraData.淡入时间, loadedAsset.CameraData.淡出时间, loadedAsset.CameraData.摄像机配置, null, loadedAsset.CameraData.打断淡出时间, null, null, default(OneOf<TsBaseCharacter, TsBaseVehicle>), loadedAsset.CameraData.CameraAttachSocket, default(OneOf<TsBaseCharacter, TsBaseVehicle>));
					AiStateMachineBase node = this.Node;
					if (node != null)
					{
						PawnTimeScaleComponent timeScaleComponent = node.TimeScaleComponent;
						if (timeScaleComponent != null)
						{
							timeScaleComponent.SetTimeScale(loadedAsset.VictimTimeScale.优先级, loadedAsset.VictimTimeScale.时间膨胀值, loadedAsset.VictimTimeScale.时间膨胀变化曲线, loadedAsset.VictimTimeScale.时间膨胀时长, ETimeScaleSourceType.BeCountered, false, false);
						}
					}
					EntityHandle currentTarget = this.Node.AiController.AiHateList.GetCurrentTarget();
					if (currentTarget != null)
					{
						currentTarget.Entity.GetComponent<PawnTimeScaleComponent>().SetTimeScale(loadedAsset.AttackerTimeScale.优先级, loadedAsset.AttackerTimeScale.时间膨胀值, loadedAsset.AttackerTimeScale.时间膨胀变化曲线, loadedAsset.AttackerTimeScale.时间膨胀时长, ETimeScaleSourceType.BeCountered, false, false);
					}
					if (loadedAsset.CameraShake != null && !ControllerBase<CameraController>.Instance.MainModel.IsModeEnabled(ECustomCameraMode.Widget) && !ControllerBase<CameraController>.Instance.MainModel.IsModeEnabled(ECustomCameraMode.Sequence))
					{
						FVectorDouble value = ModelBase<CameraModel>.Instance.MainModel.FightCamera.GetComponent<FightCameraDisplayComponent>().CameraActor.D_K2_GetActorLocation();
						ControllerBase<CameraController>.Instance.PlayWorldCameraShake(loadedAsset.CameraShake, new FVectorDouble?(value), 0f, 100f, 1f, false, "MainCamera");
					}
				}
				else
				{
					CreatureDataComponent component = this.Node.Entity.GetComponent<CreatureDataComponent>();
					Log instance = Singleton<Log>.Instance;
					ELogModule module = ELogModule.Resource;
					ELogAuthor author = ELogAuthor.WCL;
					string message = "AiStateMachineStatePalsy Camera 资源加载资产为空";
					<>y__InlineArray3<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray3<ValueTuple<string, object>>);
					ref ValueTuple<string, object> ptr = ref <PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0);
					string item = "actorName";
					CharacterActorComponent actorComponent = this.Node.ActorComponent;
					ptr = new ValueTuple<string, object>(item, (actorComponent != null) ? actorComponent.Actor.GetName() : null);
					*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("pbDataId", component.GetPbDataId());
					*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 2) = new ValueTuple<string, object>("path", this.CounterAttackCamera);
					instance.Error(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 3));
				}
			}
			if (!string.IsNullOrEmpty(this.CounterAttackEffect))
			{
				CounterAttackEffectData loadedAsset2 = Singleton<ResourceSystem>.Instance.GetLoadedAsset<CounterAttackEffectData>(this.CounterAttackEffect);
				if (loadedAsset2 != null)
				{
					AiStateMachineBase node2 = this.Node;
					HitInformation hitInformation;
					if (node2 == null)
					{
						hitInformation = null;
					}
					else
					{
						CharacterHitComponent hitComponent = node2.HitComponent;
						hitInformation = ((hitComponent != null) ? hitComponent.LastHitData : null);
					}
					HitInformation hitInformation2 = hitInformation;
					if (hitInformation2 != null)
					{
						AiStateMachineBase node3 = this.Node;
						if (node3 == null)
						{
							return;
						}
						CharacterHitComponent hitComponent2 = node3.HitComponent;
						if (hitComponent2 == null)
						{
							return;
						}
						HitInformation hitData = hitInformation2;
						string effectPath = loadedAsset2.EffectDA.AssetPathName.ToString();
						FVector scale = loadedAsset2.Scale;
						hitComponent2.PlayCounterAttackEffect(hitData, effectPath, new FVectorDouble(ref scale));
						return;
					}
				}
				else
				{
					CreatureDataComponent component2 = this.Node.Entity.GetComponent<CreatureDataComponent>();
					Log instance2 = Singleton<Log>.Instance;
					ELogModule module2 = ELogModule.Resource;
					ELogAuthor author2 = ELogAuthor.WCL;
					string message2 = "AiStateMachineStatePalsy Effect 资源加载资产为空";
					<>y__InlineArray3<ValueTuple<string, object>> <>y__InlineArray2 = default(<>y__InlineArray3<ValueTuple<string, object>>);
					ref ValueTuple<string, object> ptr2 = ref <PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 0);
					string item2 = "actorName";
					CharacterActorComponent actorComponent2 = this.Node.ActorComponent;
					ptr2 = new ValueTuple<string, object>(item2, (actorComponent2 != null) ? actorComponent2.Actor.GetName() : null);
					*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 1) = new ValueTuple<string, object>("pbDataId", component2.GetPbDataId());
					*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 2) = new ValueTuple<string, object>("path", this.CounterAttackEffect);
					instance2.Error(module2, author2, message2, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray2, 3));
				}
			}
		}

		// Token: 0x06046148 RID: 287048 RVA: 0x012684E2 File Offset: 0x012666E2
		[NullableContext(2)]
		public override void OnDeactivate(AiStateMachineBase nextState = null, long? contextId = null)
		{
		}

		// Token: 0x06046149 RID: 287049 RVA: 0x012684E4 File Offset: 0x012666E4
		protected override bool OnInit(CombatStateMachineDefine.Fsm.State state)
		{
			this.CounterAttackEffect = state.BindPalsy.CounterAttackEffect;
			this.CounterAttackCamera = state.BindPalsy.CounterAttackCamera;
			return true;
		}

		// Token: 0x0604614A RID: 287050 RVA: 0x01268509 File Offset: 0x01266709
		public override void ToString(StringBuilder outBuilder, int depth = 0)
		{
			AiStateMachineHelper.AppendDepthSpace(outBuilder, depth);
		}

		// Token: 0x0402750C RID: 161036
		private string CounterAttackEffect = "";

		// Token: 0x0402750D RID: 161037
		private string CounterAttackCamera = "";
	}
}
