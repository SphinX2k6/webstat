using System;
using System.Runtime.CompilerServices;
using AkiClient.Game.Aki.Render.RuntimeBP.Battle;
using UnrealEngine;
using UnrealEngine.Extension;

namespace CSharpScript.Game.Render
{
	// Token: 0x0200473D RID: 18237
	public class WuYinQuBattleStateFightingToFighting : WuYinQuBattleStateBase
	{
		// Token: 0x0602F54A RID: 193866 RVA: 0x00B3942C File Offset: 0x00B3762C
		[NullableContext(1)]
		public WuYinQuBattleStateFightingToFighting(WuYinQuBattleActor Owner, EWuYinQuBattleState State, [Nullable(new byte[]
		{
			2,
			1
		})] StateMachine<WuYinQuBattleActor, EWuYinQuBattleState> StateMachine = null) : base(Owner, State, StateMachine)
		{
		}

		// Token: 0x0602F54B RID: 193867 RVA: 0x00B39440 File Offset: 0x00B37640
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
			Singleton<Log>.Instance.Info(ELogModule.RenderBattle, ELogAuthor.ZWY, "进入战斗过渡状态时没有Sequence资源，开始资源加载。", default(ReadOnlySpan<ValueTuple<string, object>>));
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
				string message = "进入战斗过渡状态时没有Sequence资源，资源加载失败。";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("WuYinQuBattleActor", this.Owner);
				instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			}, 100, "js_undefined");
		}

		// Token: 0x0602F54C RID: 193868 RVA: 0x00B39528 File Offset: 0x00B37728
		private void OnEnterAsync()
		{
			this.Timer = 0f;
			EWuYinQuState lastBattleState = this.Owner.GetLastBattleState();
			EWuYinQuState currentBattleState = this.Owner.GetCurrentBattleState();
			string text;
			switch (lastBattleState)
			{
			case EWuYinQuState.StateFighting1:
				text = "战斗阶段1";
				break;
			case EWuYinQuState.StateFighting2:
				text = "战斗阶段2";
				break;
			case EWuYinQuState.StateFighting3:
				text = "战斗阶段3";
				break;
			default:
				text = "未知状态";
				break;
			}
			string str = text;
			AKuroLevelSequenceActor kuroLevelSequenceActor = this.Owner.GetKuroLevelSequenceActor();
			string str2 = "未知状态";
			if (currentBattleState == EWuYinQuState.StateFighting1)
			{
				str2 = "战斗阶段1";
				if (kuroLevelSequenceActor != null && UKismetSystemLibrary.IsValid(kuroLevelSequenceActor) && UKismetSystemLibrary.IsValid(kuroLevelSequenceActor.GetSequence()) && UKismetSystemLibrary.IsValid(kuroLevelSequenceActor.SequencePlayer))
				{
					kuroLevelSequenceActor.SequencePlayer.JumpToMarkedFrame("FightingStart1");
					kuroLevelSequenceActor.SequencePlayer.Play();
				}
			}
			else if (currentBattleState == EWuYinQuState.StateFighting2)
			{
				str2 = "战斗阶段2";
				if (kuroLevelSequenceActor != null && UKismetSystemLibrary.IsValid(kuroLevelSequenceActor) && UKismetSystemLibrary.IsValid(kuroLevelSequenceActor.GetSequence()) && UKismetSystemLibrary.IsValid(kuroLevelSequenceActor.SequencePlayer))
				{
					kuroLevelSequenceActor.SequencePlayer.JumpToMarkedFrame("FightingStart2");
					kuroLevelSequenceActor.SequencePlayer.Play();
				}
			}
			else if (currentBattleState == EWuYinQuState.StateFighting3)
			{
				str2 = "战斗阶段3";
				if (kuroLevelSequenceActor != null && UKismetSystemLibrary.IsValid(kuroLevelSequenceActor) && UKismetSystemLibrary.IsValid(kuroLevelSequenceActor.GetSequence()) && UKismetSystemLibrary.IsValid(kuroLevelSequenceActor.SequencePlayer))
				{
					kuroLevelSequenceActor.SequencePlayer.JumpToMarkedFrame("FightingStart3");
					kuroLevelSequenceActor.SequencePlayer.Play();
				}
			}
			UMaterialParameterCollection globalMPC = this.Owner.WuYinQuFightingData.GlobalMPC;
			PDA_WuYinQuBattleData_C wuYinQuFightingData = this.Owner.WuYinQuFightingData;
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
				flinearColor = new FLinearColor(wuYinQuFightingData.LandscapeShowingRadiusCurve.GetFloatValue(1f), 0.0001f, 0f, 0f);
				UKismetMaterialLibrary.SetVectorParameterValue(world2, collection2, globalLandscapeRadiusAndHardness, flinearColor);
			}
			this.Owner.当前状态 = "从:" + str + "到:" + str2;
			Singleton<Log>.Instance.Info(ELogModule.RenderBattle, ELogAuthor.HCS, "进入战斗过度阶段", default(ReadOnlySpan<ValueTuple<string, object>>));
		}

		// Token: 0x0602F54D RID: 193869 RVA: 0x00B39790 File Offset: 0x00B37990
		protected override void OnUpdate(float delta)
		{
			EWuYinQuState currentBattleState = this.Owner.GetCurrentBattleState();
			if (this.Timer > this.Owner.WuYinQuFightingData.FightingTransitionTime)
			{
				if (currentBattleState == EWuYinQuState.StateFighting2)
				{
					this.StateMachine.Switch(EWuYinQuBattleState.Fighting2);
					return;
				}
				if (currentBattleState == EWuYinQuState.StateFighting3)
				{
					this.StateMachine.Switch(EWuYinQuBattleState.Fighting3);
					return;
				}
				Singleton<Log>.Instance.Error(ELogModule.RenderBattle, ELogAuthor.HCS, "战斗过度状态错误!!!!", default(ReadOnlySpan<ValueTuple<string, object>>));
			}
			this.Timer += delta / 1000f;
		}

		// Token: 0x0602F54E RID: 193870 RVA: 0x00B39818 File Offset: 0x00B37A18
		protected override void OnExit(EWuYinQuBattleState lastState)
		{
			Singleton<Log>.Instance.Info(ELogModule.RenderBattle, ELogAuthor.HCS, "退出战斗过度阶段", default(ReadOnlySpan<ValueTuple<string, object>>));
			this.SeqenceData = null;
			if (this.SeqenceDataLoading != -1)
			{
				Singleton<ResourceSystem>.Instance.CancelAsyncLoad(this.SeqenceDataLoading);
				this.SeqenceDataLoading = -1;
				Singleton<Log>.Instance.Error(ELogModule.RenderBattle, ELogAuthor.ZWY, "退出战斗过渡状态时还在加载资源，取消资源加载", default(ReadOnlySpan<ValueTuple<string, object>>));
			}
		}

		// Token: 0x0401AF2B RID: 110379
		protected float Timer;

		// Token: 0x0401AF2C RID: 110380
		protected bool LastUseFlowmapSky;

		// Token: 0x0401AF2D RID: 110381
		protected bool CurrentUseFlowmapSky;

		// Token: 0x0401AF2E RID: 110382
		[Nullable(2)]
		private ULevelSequence SeqenceData;

		// Token: 0x0401AF2F RID: 110383
		private int SeqenceDataLoading = -1;
	}
}
