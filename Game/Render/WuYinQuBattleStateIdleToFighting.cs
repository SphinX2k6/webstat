using System;
using System.Runtime.CompilerServices;
using AkiClient.Game.Aki.Render.RuntimeBP.Battle;
using UnrealEngine;
using UnrealEngine.Extension;

namespace CSharpScript.Game.Render
{
	// Token: 0x02004740 RID: 18240
	public class WuYinQuBattleStateIdleToFighting : WuYinQuBattleStateBase
	{
		// Token: 0x0602F559 RID: 193881 RVA: 0x00B39CCD File Offset: 0x00B37ECD
		[NullableContext(1)]
		public WuYinQuBattleStateIdleToFighting(WuYinQuBattleActor Owner, EWuYinQuBattleState State, [Nullable(new byte[]
		{
			2,
			1
		})] StateMachine<WuYinQuBattleActor, EWuYinQuBattleState> StateMachine = null) : base(Owner, State, StateMachine)
		{
		}

		// Token: 0x0602F55A RID: 193882 RVA: 0x00B39CE0 File Offset: 0x00B37EE0
		protected override void OnEnter(EWuYinQuBattleState? lastState)
		{
			AKuroLevelSequenceActor levelSequenceActor = this.Owner.GetKuroLevelSequenceActor();
			if (levelSequenceActor == null || !UKismetSystemLibrary.IsValid(levelSequenceActor) || !UKismetSystemLibrary.IsValid(levelSequenceActor.SequencePlayer))
			{
				return;
			}
			this.SeqenceData = levelSequenceActor.GetSequence();
			if (UKismetSystemLibrary.IsValid(this.SeqenceData))
			{
				levelSequenceActor.SetSequence(this.SeqenceData);
				this.OnEnterAsync();
				return;
			}
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.RenderBattle;
			ELogAuthor author = ELogAuthor.ZWY;
			string message = "进入Idle2Fighting的过度状态时没有Sequence资源，开始资源加载。";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("WuYinQuBattleActor", this.Owner);
			instance.Info(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			string path = levelSequenceActor.LevelSequence.AssetPathName.ToString();
			this.SeqenceDataLoading = Singleton<ResourceSystem>.Instance.LoadAsync<ULevelSequence>(path, delegate([Nullable(2)] ULevelSequence data, string _)
			{
				this.SeqenceDataLoading = -1;
				if (UKismetSystemLibrary.IsValid(data))
				{
					this.SeqenceData = data;
					levelSequenceActor.SetSequence(this.SeqenceData);
					this.OnEnterAsync();
					return;
				}
				Log instance2 = Singleton<Log>.Instance;
				ELogModule module2 = ELogModule.RenderBattle;
				ELogAuthor author2 = ELogAuthor.ZWY;
				string message2 = "进入Idle2Fighting的过度状态时没有Sequence资源，资源加载失败。";
				ValueTuple<string, object> valueTuple2 = new ValueTuple<string, object>("WuYinQuBattleActor", this.Owner);
				instance2.Error(module2, author2, message2, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple2));
			}, 100, "js_undefined");
		}

		// Token: 0x0602F55B RID: 193883 RVA: 0x00B39DD8 File Offset: 0x00B37FD8
		private void OnEnterAsync()
		{
			Singleton<Log>.Instance.Info(ELogModule.RenderBattle, ELogAuthor.HCS, "进入Idle2Fighting的过度状态", default(ReadOnlySpan<ValueTuple<string, object>>));
			this.Owner.当前状态 = "静止状态到战斗阶段1";
			PDA_WuYinQuBattleData_C wuYinQuFightingData = this.Owner.WuYinQuFightingData;
			FVectorDouble fvectorDouble = this.Owner.D_K2_GetActorLocation();
			ControllerBase<RenderModuleController>.Instance.AddBattleReference(fvectorDouble);
			AKuroLevelSequenceActor kuroLevelSequenceActor = this.Owner.GetKuroLevelSequenceActor();
			if (kuroLevelSequenceActor != null && UKismetSystemLibrary.IsValid(kuroLevelSequenceActor) && UKismetSystemLibrary.IsValid(kuroLevelSequenceActor.GetSequence()) && UKismetSystemLibrary.IsValid(kuroLevelSequenceActor.SequencePlayer))
			{
				if (kuroLevelSequenceActor.SequencePlayer.IsPlaying())
				{
					kuroLevelSequenceActor.SequencePlayer.Stop();
				}
				kuroLevelSequenceActor.SequencePlayer.Play();
				kuroLevelSequenceActor.SequencePlayer.JumpToMarkedFrame("FightingStart1");
			}
			if (wuYinQuFightingData.IdleToFightingTransitionTime > 0f && UKismetSystemLibrary.IsValid(wuYinQuFightingData.IdleToFightingCurve))
			{
				this.Timer = 0f;
				UMaterialParameterCollection globalMPC = this.Owner.WuYinQuFightingData.GlobalMPC;
				if (globalMPC != null)
				{
					UObject world = this.Owner.GetWorld();
					UMaterialParameterCollection collection = globalMPC;
					FName globalLandscapeCenterAndIntensity = WuYinQuBattleNameDefines.GlobalLandscapeCenterAndIntensity;
					FLinearColor flinearColor = new FLinearColor((float)fvectorDouble.X, (float)fvectorDouble.Y, (float)fvectorDouble.Z, 1f);
					UKismetMaterialLibrary.SetVectorParameterValue(world, collection, globalLandscapeCenterAndIntensity, flinearColor);
					UObject world2 = this.Owner.GetWorld();
					UMaterialParameterCollection collection2 = globalMPC;
					FName globalLandscapeRadiusAndHardness = WuYinQuBattleNameDefines.GlobalLandscapeRadiusAndHardness;
					flinearColor = new FLinearColor(0f, 0.0001f, 0f, 0f);
					UKismetMaterialLibrary.SetVectorParameterValue(world2, collection2, globalLandscapeRadiusAndHardness, flinearColor);
					UKismetMaterialLibrary.SetScalarParameterValue(this.Owner.GetWorld(), globalMPC, WuYinQuBattleNameDefines.GlobalBlackStoneErosion, 0f);
				}
				return;
			}
			StateMachine<WuYinQuBattleActor, EWuYinQuBattleState> stateMachine = this.StateMachine;
			if (stateMachine == null)
			{
				return;
			}
			stateMachine.Switch(EWuYinQuBattleState.Fighting1);
		}

		// Token: 0x0602F55C RID: 193884 RVA: 0x00B39F74 File Offset: 0x00B38174
		protected override void OnUpdate(float delta)
		{
			if (this.Timer > this.Owner.WuYinQuFightingData.IdleToFightingTransitionTime)
			{
				this.StateMachine.Switch(EWuYinQuBattleState.Fighting1);
				return;
			}
			this.Timer += delta / 1000f;
			float inTime = Singleton<MathUtils>.Instance.Clamp(this.Timer / this.Owner.WuYinQuFightingData.IdleToFightingTransitionTime, 0f, 1f);
			float parameterValue = Singleton<MathUtils>.Instance.Clamp(this.Owner.WuYinQuFightingData.IdleToFightingCurve.GetFloatValue(inTime), 0f, 1f);
			PDA_WuYinQuBattleData_C wuYinQuFightingData = this.Owner.WuYinQuFightingData;
			float floatValue = wuYinQuFightingData.LandscapeShowingRadiusCurve.GetFloatValue(inTime);
			UMaterialParameterCollection globalMPC = wuYinQuFightingData.GlobalMPC;
			if (globalMPC != null)
			{
				FVectorDouble fvectorDouble = this.Owner.D_K2_GetActorLocation();
				UObject world = this.Owner.GetWorld();
				UMaterialParameterCollection collection = globalMPC;
				FName globalLandscapeCenterAndIntensity = WuYinQuBattleNameDefines.GlobalLandscapeCenterAndIntensity;
				FLinearColor flinearColor = new FLinearColor((float)fvectorDouble.X, (float)fvectorDouble.Y, (float)fvectorDouble.Z, 1f);
				UKismetMaterialLibrary.SetVectorParameterValue(world, collection, globalLandscapeCenterAndIntensity, flinearColor);
				UObject world2 = this.Owner.GetWorld();
				UMaterialParameterCollection collection2 = globalMPC;
				FName globalLandscapeRadiusAndHardness = WuYinQuBattleNameDefines.GlobalLandscapeRadiusAndHardness;
				flinearColor = new FLinearColor(floatValue, 0.0001f, 0f, 0f);
				UKismetMaterialLibrary.SetVectorParameterValue(world2, collection2, globalLandscapeRadiusAndHardness, flinearColor);
				UKismetMaterialLibrary.SetScalarParameterValue(this.Owner.GetWorld(), globalMPC, WuYinQuBattleNameDefines.GlobalBlackStoneErosion, parameterValue);
			}
		}

		// Token: 0x0602F55D RID: 193885 RVA: 0x00B3A0C8 File Offset: 0x00B382C8
		protected override void OnExit(EWuYinQuBattleState lastState)
		{
			Singleton<Log>.Instance.Info(ELogModule.RenderBattle, ELogAuthor.HCS, "退出Idle2Fighting的过度状态", default(ReadOnlySpan<ValueTuple<string, object>>));
			this.SeqenceData = null;
			if (this.SeqenceDataLoading != -1)
			{
				Singleton<ResourceSystem>.Instance.CancelAsyncLoad(this.SeqenceDataLoading);
				this.SeqenceDataLoading = -1;
				Singleton<Log>.Instance.Error(ELogModule.RenderBattle, ELogAuthor.ZWY, "退出Idle2Fighting的过度状态时还在加载资源，取消资源加载", default(ReadOnlySpan<ValueTuple<string, object>>));
			}
		}

		// Token: 0x0401AF33 RID: 110387
		private float Timer;

		// Token: 0x0401AF34 RID: 110388
		[Nullable(2)]
		private ULevelSequence SeqenceData;

		// Token: 0x0401AF35 RID: 110389
		private int SeqenceDataLoading = -1;
	}
}
