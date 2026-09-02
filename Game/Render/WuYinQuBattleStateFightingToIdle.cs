using System;
using System.Runtime.CompilerServices;
using AkiClient.Game.Aki.Render.RuntimeBP.Battle;
using UnrealEngine;
using UnrealEngine.Extension;

namespace CSharpScript.Game.Render
{
	// Token: 0x0200473E RID: 18238
	public class WuYinQuBattleStateFightingToIdle : WuYinQuBattleStateBase
	{
		// Token: 0x0602F54F RID: 193871 RVA: 0x00B39884 File Offset: 0x00B37A84
		[NullableContext(1)]
		public WuYinQuBattleStateFightingToIdle(WuYinQuBattleActor Owner, EWuYinQuBattleState State, [Nullable(new byte[]
		{
			2,
			1
		})] StateMachine<WuYinQuBattleActor, EWuYinQuBattleState> StateMachine = null) : base(Owner, State, StateMachine)
		{
		}

		// Token: 0x0602F550 RID: 193872 RVA: 0x00B39898 File Offset: 0x00B37A98
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
			Singleton<Log>.Instance.Info(ELogModule.RenderBattle, ELogAuthor.ZWY, "进入Fighting2Idle过度状态没有Sequence资源，开始资源加载。", default(ReadOnlySpan<ValueTuple<string, object>>));
			this.SeqenceDataLoading = Singleton<ResourceSystem>.Instance.LoadAsync<ULevelSequence>(levelSequenceActor.LevelSequence.AssetPathName.ToString(), delegate([Nullable(2)] ULevelSequence data, string path)
			{
				this.SeqenceDataLoading = -1;
				if (UKismetSystemLibrary.IsValid(data))
				{
					this.SeqenceData = data;
					levelSequenceActor.SetSequence(this.SeqenceData);
					this.OnEnterAsync();
					return;
				}
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.RenderBattle;
				ELogAuthor author = ELogAuthor.ZWY;
				string message = "进入Fighting2Idle过度状态没有Sequence资源，资源加载失败。";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("WuYinQuBattleActor", this.Owner);
				instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			}, 100, "js_undefined");
		}

		// Token: 0x0602F551 RID: 193873 RVA: 0x00B39980 File Offset: 0x00B37B80
		private void OnEnterAsync()
		{
			Singleton<Log>.Instance.Info(ELogModule.RenderBattle, ELogAuthor.HCS, "进入Fighting2Idle过度状态", default(ReadOnlySpan<ValueTuple<string, object>>));
			ControllerBase<RenderModuleController>.Instance.DecBattleReference();
			this.Owner.当前状态 = "战斗阶段到静止状态";
			PDA_WuYinQuBattleData_C wuYinQuFightingData = this.Owner.WuYinQuFightingData;
			AKuroLevelSequenceActor kuroLevelSequenceActor = this.Owner.GetKuroLevelSequenceActor();
			if (kuroLevelSequenceActor != null && UKismetSystemLibrary.IsValid(kuroLevelSequenceActor) && UKismetSystemLibrary.IsValid(kuroLevelSequenceActor.GetSequence()) && UKismetSystemLibrary.IsValid(kuroLevelSequenceActor.SequencePlayer))
			{
				kuroLevelSequenceActor.SequencePlayer.Play();
				kuroLevelSequenceActor.SequencePlayer.JumpToMarkedFrame("FightingOverStart");
			}
			if (wuYinQuFightingData.FightingToIdleTransitionTime <= 0f || !UKismetSystemLibrary.IsValid(wuYinQuFightingData.FightingToIdleCurve))
			{
				this.StateMachine.Switch(EWuYinQuBattleState.Idle);
				return;
			}
			this.Timer = 0f;
		}

		// Token: 0x0602F552 RID: 193874 RVA: 0x00B39A50 File Offset: 0x00B37C50
		protected override void OnUpdate(float delta)
		{
			if (this.Timer <= this.Owner.WuYinQuFightingData.FightingToIdleTransitionTime)
			{
				this.Timer += delta / 1000f;
				float inTime = Singleton<MathUtils>.Instance.Clamp(this.Timer / this.Owner.WuYinQuFightingData.FightingToIdleTransitionTime, 0f, 1f);
				float num = Singleton<MathUtils>.Instance.Clamp(this.Owner.WuYinQuFightingData.FightingToIdleCurve.GetFloatValue(inTime), 0f, 1f);
				PDA_WuYinQuBattleData_C wuYinQuFightingData = this.Owner.WuYinQuFightingData;
				UMaterialParameterCollection globalMPC = wuYinQuFightingData.GlobalMPC;
				if (globalMPC != null)
				{
					float floatValue = wuYinQuFightingData.LandscapeFadingRadiusCurve.GetFloatValue(inTime);
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
					UKismetMaterialLibrary.SetScalarParameterValue(this.Owner.GetWorld(), globalMPC, WuYinQuBattleNameDefines.GlobalBlackStoneErosion, 1f - num);
				}
				return;
			}
			StateMachine<WuYinQuBattleActor, EWuYinQuBattleState> stateMachine = this.StateMachine;
			if (stateMachine == null)
			{
				return;
			}
			stateMachine.Switch(EWuYinQuBattleState.Idle);
		}

		// Token: 0x0602F553 RID: 193875 RVA: 0x00B39BB0 File Offset: 0x00B37DB0
		protected override void OnExit(EWuYinQuBattleState lastState)
		{
			Singleton<Log>.Instance.Info(ELogModule.RenderBattle, ELogAuthor.HCS, "退出Fighting2Idle过度状态", default(ReadOnlySpan<ValueTuple<string, object>>));
			UMaterialParameterCollection globalMPC = this.Owner.WuYinQuFightingData.GlobalMPC;
			if (globalMPC != null)
			{
				FVectorDouble fvectorDouble = this.Owner.D_K2_GetActorLocation();
				UObject world = this.Owner.GetWorld();
				UMaterialParameterCollection collection = globalMPC;
				FName globalLandscapeCenterAndIntensity = WuYinQuBattleNameDefines.GlobalLandscapeCenterAndIntensity;
				FLinearColor flinearColor = new FLinearColor((float)fvectorDouble.X, (float)fvectorDouble.Y, (float)fvectorDouble.Z, 0f);
				UKismetMaterialLibrary.SetVectorParameterValue(world, collection, globalLandscapeCenterAndIntensity, flinearColor);
			}
			this.SeqenceData = null;
			if (this.SeqenceDataLoading != -1)
			{
				Singleton<ResourceSystem>.Instance.CancelAsyncLoad(this.SeqenceDataLoading);
				this.SeqenceDataLoading = -1;
				Singleton<Log>.Instance.Error(ELogModule.RenderBattle, ELogAuthor.ZWY, "退出Fighting2Idle过度状态时还在加载资源，取消资源加载", default(ReadOnlySpan<ValueTuple<string, object>>));
			}
		}

		// Token: 0x0401AF30 RID: 110384
		private float Timer;

		// Token: 0x0401AF31 RID: 110385
		[Nullable(2)]
		private ULevelSequence SeqenceData;

		// Token: 0x0401AF32 RID: 110386
		private int SeqenceDataLoading = -1;
	}
}
