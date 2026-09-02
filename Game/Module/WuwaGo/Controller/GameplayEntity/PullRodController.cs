using System;
using System.Runtime.CompilerServices;
using AkiClient.Game.Aki.Data.Gameplay.WuWaGo;
using AkiClient.Game.Aki.Render.RuntimeBP.Scene.Interaction;
using CSharpScript.Game.Module.WuwaGo.Controller.GameMode;
using CSharpScript.Game.Module.WuwaGo.Model;
using CSharpScript.Game.Module.WuwaGo.Model.GameplayEntity;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.WuwaGo.Controller.GameplayEntity
{
	// Token: 0x02004B14 RID: 19220
	[NullableContext(1)]
	[Nullable(0)]
	public class PullRodController : GameplayEntityControllerBase
	{
		// Token: 0x060321FD RID: 205309 RVA: 0x00C8B016 File Offset: 0x00C89216
		public PullRodController(WuWaGoGameplayEntityBase entity, WuWaGoGameData gameData, WuWaGoGameModeBase gameMode) : base(entity, gameData, gameMode)
		{
		}

		// Token: 0x17008597 RID: 34199
		// (get) Token: 0x060321FE RID: 205310 RVA: 0x00C8B021 File Offset: 0x00C89221
		private WuWaGoPullRodEntity PullRod
		{
			get
			{
				return this.Entity as WuWaGoPullRodEntity;
			}
		}

		// Token: 0x060321FF RID: 205311 RVA: 0x00C8B02E File Offset: 0x00C8922E
		protected override bool OnCreate()
		{
			if (!base.OnCreate())
			{
				return false;
			}
			this.IsDestroyed = false;
			base.ResetActorToEntityConfigInitialTransform();
			base.RegisterAttachedGridMoveParticipant();
			return true;
		}

		// Token: 0x06032200 RID: 205312 RVA: 0x00C8B04F File Offset: 0x00C8924F
		protected override void OnDestroy()
		{
			base.OnDestroy();
			this.IsDestroyed = true;
			base.UnregisterAttachedGridMoveParticipant();
		}

		// Token: 0x06032201 RID: 205313 RVA: 0x00C8B064 File Offset: 0x00C89264
		public override void OnRollbackRestore()
		{
			this.PresentationCancelToken++;
		}

		// Token: 0x06032202 RID: 205314 RVA: 0x00C8B074 File Offset: 0x00C89274
		public void PrepareInteractPresentation(EGameplayEntityState targetState)
		{
			this.PendingPresentationWaitInfo = null;
			SceneItemActorComponent sceneItemActorComponent = this.GetSceneItemActorComponent();
			if (sceneItemActorComponent == null || !sceneItemActorComponent.GetIsSceneInteractionLoadCompleted())
			{
				return;
			}
			SceneInteractionActor sceneInteractionActor = sceneItemActorComponent.GetInteractionMainActor() as SceneInteractionActor;
			if (sceneInteractionActor == null || !sceneInteractionActor.IsValid())
			{
				return;
			}
			EKuroSceneInteractionState key;
			SSceneInteractionitem ssceneInteractionitem = this.ResolveInteractPresentationState(sceneInteractionActor, targetState, out key);
			if (ssceneInteractionitem == null)
			{
				return;
			}
			float playRate = this.ApplyStatePlayRate(ssceneInteractionitem);
			sceneInteractionActor.States[key] = ssceneInteractionitem;
			SSceneInteractionSequence sequence = ssceneInteractionitem.Sequence;
			ULevelSequence ulevelSequence = (sequence != null) ? sequence.Sequence : null;
			if (ulevelSequence == null || !ulevelSequence.IsValid())
			{
				return;
			}
			this.PendingPresentationWaitInfo = new PullRodPresentationWaitInfo
			{
				SceneActor = sceneInteractionActor,
				Sequence = ulevelSequence,
				PlayRate = playRate
			};
		}

		// Token: 0x06032203 RID: 205315 RVA: 0x00C8B134 File Offset: 0x00C89334
		[NullableContext(0)]
		public UniTask<bool> WaitForInteractPresentation()
		{
			PullRodController.<WaitForInteractPresentation>d__14 <WaitForInteractPresentation>d__;
			<WaitForInteractPresentation>d__.<>t__builder = AsyncUniTaskMethodBuilder<bool>.Create();
			<WaitForInteractPresentation>d__.<>4__this = this;
			<WaitForInteractPresentation>d__.<>1__state = -1;
			<WaitForInteractPresentation>d__.<>t__builder.Start<PullRodController.<WaitForInteractPresentation>d__14>(ref <WaitForInteractPresentation>d__);
			return <WaitForInteractPresentation>d__.<>t__builder.Task;
		}

		// Token: 0x06032204 RID: 205316 RVA: 0x00C8B178 File Offset: 0x00C89378
		private float ApplyStatePlayRate(SSceneInteractionitem state)
		{
			float num = 1f;
			float globalMontagePlayRate = this.GetGlobalMontagePlayRate();
			num *= globalMontagePlayRate;
			if (state.Sequence != null)
			{
				state.Sequence.PlayRate = num;
			}
			return num;
		}

		// Token: 0x06032205 RID: 205317 RVA: 0x00C8B1B4 File Offset: 0x00C893B4
		protected override UniTask OnExecuteAction()
		{
			PullRodController.<OnExecuteAction>d__16 <OnExecuteAction>d__;
			<OnExecuteAction>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnExecuteAction>d__.<>4__this = this;
			<OnExecuteAction>d__.<>1__state = -1;
			<OnExecuteAction>d__.<>t__builder.Start<PullRodController.<OnExecuteAction>d__16>(ref <OnExecuteAction>d__);
			return <OnExecuteAction>d__.<>t__builder.Task;
		}

		// Token: 0x06032206 RID: 205318 RVA: 0x00C8B1F7 File Offset: 0x00C893F7
		[NullableContext(2)]
		private SceneItemActorComponent GetSceneItemActorComponent()
		{
			EntityHandle entityHandle = this.PullRod.EntityHandle;
			if (entityHandle == null)
			{
				return null;
			}
			WorldEntity entity = entityHandle.Entity;
			if (entity == null)
			{
				return null;
			}
			return entity.GetComponent<SceneItemActorComponent>();
		}

		// Token: 0x06032207 RID: 205319 RVA: 0x00C8B21C File Offset: 0x00C8941C
		[return: Nullable(2)]
		private SSceneInteractionitem ResolveInteractPresentationState(SceneInteractionActor sceneActor, EGameplayEntityState targetState, out EKuroSceneInteractionState presentationStateKey)
		{
			presentationStateKey = EKuroSceneInteractionState.State1;
			EKuroSceneInteractionState? ekuroSceneInteractionState = this.ResolveSceneInteractionState(targetState);
			if (ekuroSceneInteractionState == null)
			{
				return null;
			}
			EKuroSceneInteractionState currentState = sceneActor.GetCurrentState();
			SSceneInteractionitem ssceneInteractionitem;
			sceneActor.States.TryGetValue(currentState, out ssceneInteractionitem);
			EKuroSceneInteractionState? ekuroSceneInteractionState2 = null;
			EKuroSceneInteractionState value;
			if (ssceneInteractionitem != null && ssceneInteractionitem.TransitionMap.TryGetValue(ekuroSceneInteractionState.Value, out value))
			{
				ekuroSceneInteractionState2 = new EKuroSceneInteractionState?(value);
			}
			presentationStateKey = (ekuroSceneInteractionState2 ?? ekuroSceneInteractionState.Value);
			SSceneInteractionitem ssceneInteractionitem2;
			sceneActor.States.TryGetValue(presentationStateKey, out ssceneInteractionitem2);
			if (ssceneInteractionitem2 == null)
			{
				return null;
			}
			return ssceneInteractionitem2;
		}

		// Token: 0x06032208 RID: 205320 RVA: 0x00C8B2BC File Offset: 0x00C894BC
		private EKuroSceneInteractionState? ResolveSceneInteractionState(EGameplayEntityState targetState)
		{
			EntityHandle entityHandle = this.PullRod.EntityHandle;
			WorldEntity worldEntity = (entityHandle != null) ? entityHandle.Entity : null;
			CreatureDataComponent creatureDataComponent = (worldEntity != null) ? worldEntity.GetComponent<CreatureDataComponent>() : null;
			if (creatureDataComponent == null)
			{
				return null;
			}
			FGameplayTag? gameplayTagById = GameplayTagUtils.GetGameplayTagById(GameplayTagUtils.GetTagIdByName(targetState.ToEnumString()));
			EKuroSceneInteractionState value;
			if (gameplayTagById == null || !creatureDataComponent.GetModelConfig().场景交互物状态列表.TryGetValue(gameplayTagById.Value, out value))
			{
				return null;
			}
			return new EKuroSceneInteractionState?(value);
		}

		// Token: 0x06032209 RID: 205321 RVA: 0x00C8B340 File Offset: 0x00C89540
		private int ResolveStatePresentationWaitMs(IPullRodPresentationWaitInfo waitInfo)
		{
			SceneInteractionActor sceneActor = waitInfo.SceneActor;
			ULevelSequence sequence = waitInfo.Sequence;
			float playRate = waitInfo.PlayRate;
			if (!sceneActor.IsValid() || !sequence.IsValid() || playRate <= 0f)
			{
				return 0;
			}
			float activeSequenceRemainTime = sceneActor.GetActiveSequenceRemainTime(sequence);
			if (!float.IsFinite(activeSequenceRemainTime) || activeSequenceRemainTime <= 0f)
			{
				return 0;
			}
			float num = activeSequenceRemainTime * 1000f / playRate;
			if (!float.IsFinite(num) || num <= 0f)
			{
				return 0;
			}
			return Math.Min((int)Math.Ceiling((double)num), 5000);
		}

		// Token: 0x0603220A RID: 205322 RVA: 0x00C8B3C8 File Offset: 0x00C895C8
		private float GetGlobalMontagePlayRate()
		{
			BP_WuWaGo_C setting = WuWaGoGlobal.Setting;
			float? num = (setting != null) ? new float?(setting.MontagePlayRate) : null;
			if (num != null && num.GetValueOrDefault() > 0f)
			{
				return num.Value;
			}
			return 1f;
		}

		// Token: 0x0401D4C2 RID: 120002
		private const int PULL_ROD_PRESENTATION_TIMEOUT_MS = 5000;

		// Token: 0x0401D4C3 RID: 120003
		private const int PULL_ROD_PRESENTATION_POLL_INTERVAL_MS = 50;

		// Token: 0x0401D4C4 RID: 120004
		private const int MILLISECONDS_PER_SECOND = 1000;

		// Token: 0x0401D4C5 RID: 120005
		private const int PLAY_RATE_FIX = 1;

		// Token: 0x0401D4C6 RID: 120006
		private bool IsDestroyed;

		// Token: 0x0401D4C7 RID: 120007
		private int PresentationCancelToken;

		// Token: 0x0401D4C8 RID: 120008
		[Nullable(2)]
		private IPullRodPresentationWaitInfo PendingPresentationWaitInfo;
	}
}
