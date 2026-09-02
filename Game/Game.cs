using System;
using System.Runtime.CompilerServices;
using CSharpScript.Core.Common;
using CSharpScript.Core.Framework;
using CSharpScript.Game.Common;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Effect;
using CSharpScript.Game.InputSetting;
using CSharpScript.Game.Manager;
using CSharpScript.Game.Module.CombatMessage;
using CSharpScript.Game.Module.Plot;
using CSharpScript.Game.TickScore;
using CSharpScript.Game.Ui;
using CSharpScript.Game.World.Controller;
using CSharpScript.Launcher.SoPatch;
using CSharpScript.Typing;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game
{
	// Token: 0x020046CD RID: 18125
	[NullableContext(1)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	public class Game : Singleton<Game>
	{
		// Token: 0x0602F23A RID: 193082 RVA: 0x00B2B358 File Offset: 0x00B29558
		[NullableContext(0)]
		public UniTask<bool> Start([Nullable(1)] UGameInstance gameInstance)
		{
			Game.<Start>d__6 <Start>d__;
			<Start>d__.<>t__builder = AsyncUniTaskMethodBuilder<bool>.Create();
			<Start>d__.<>4__this = this;
			<Start>d__.gameInstance = gameInstance;
			<Start>d__.<>1__state = -1;
			<Start>d__.<>t__builder.Start<Game.<Start>d__6>(ref <Start>d__);
			return <Start>d__.<>t__builder.Task;
		}

		// Token: 0x0602F23B RID: 193083 RVA: 0x00B2B3A4 File Offset: 0x00B295A4
		[NullableContext(0)]
		public UniTask<bool> ModuleStart()
		{
			Game.<ModuleStart>d__7 <ModuleStart>d__;
			<ModuleStart>d__.<>t__builder = AsyncUniTaskMethodBuilder<bool>.Create();
			<ModuleStart>d__.<>1__state = -1;
			<ModuleStart>d__.<>t__builder.Start<Game.<ModuleStart>d__7>(ref <ModuleStart>d__);
			return <ModuleStart>d__.<>t__builder.Task;
		}

		// Token: 0x0602F23C RID: 193084 RVA: 0x00B2B3E0 File Offset: 0x00B295E0
		public void TickerStart()
		{
			Singleton<Core>.Instance.RegisterPreTick(delegate(float _)
			{
				UeMovementTickController.TickManagers();
			});
			Singleton<TickSystem>.Instance.Add(new Action<float>(this.TickPriority2), "GamePriority2", ETickingGroup.TG_PrePhysics, true, 2, false);
			Singleton<TickSystem>.Instance.Add(new Action<float>(this.TickPriority1), "GamePriority1", ETickingGroup.TG_PrePhysics, true, 1, false);
			Singleton<TickSystem>.Instance.Add(new Action<float>(this.Tick), "Game", ETickingGroup.TG_PrePhysics, true, 0, false);
			Singleton<TickSystem>.Instance.Add(new Action<float>(this.AfterTickPriority1), "GamePriority1", ETickingGroup.TG_PostPhysics, true, 1, false);
			Singleton<TickSystem>.Instance.Add(new Action<float>(this.AfterTick), "Game", ETickingGroup.TG_PostPhysics, true, 0, false);
			Singleton<TickSystem>.Instance.Add(new Action<float>(this.AfterCameraTick), "Game", ETickingGroup.TG_PostUpdateWork, true, 0, false);
			Singleton<TickSystem>.Instance.SetGamePrerequisiteTickFunction(ETickingGroup.TG_PrePhysics, 2);
			Singleton<Heartbeat>.Instance.RegisterTick();
		}

		// Token: 0x0602F23D RID: 193085 RVA: 0x00B2B4EC File Offset: 0x00B296EC
		public void Shutdown()
		{
			Singleton<Log>.Instance.Info(ELogModule.Game, ELogAuthor.WY, "Game.Shutdown Start", default(ReadOnlySpan<ValueTuple<string, object>>));
			Singleton<LogAnalyzer>.Instance.Clear();
			Singleton<TickProcessSystem>.Instance.Clear();
			Singleton<ThirdPartySdkManager>.Instance.Clear();
			Singleton<PakManager>.Instance.Clear();
			Singleton<Log>.Instance.Info(ELogModule.Game, ELogAuthor.WY, "Game.Shutdown PerformanceManager.Destroy Finished", default(ReadOnlySpan<ValueTuple<string, object>>));
			Singleton<TickSystem>.Instance.Destroy();
			Singleton<Log>.Instance.Info(ELogModule.Game, ELogAuthor.WY, "Game.Shutdown TickSystem.Destroy Finished", default(ReadOnlySpan<ValueTuple<string, object>>));
			Singleton<UiTimeDilation>.Instance.Destroy();
			Singleton<Log>.Instance.Info(ELogModule.Game, ELogAuthor.WY, "Game.Shutdown UiTimeDilation.Destroy Finished", default(ReadOnlySpan<ValueTuple<string, object>>));
			ControllerManagerBase<ControllerManager>.Instance.Clear();
			Singleton<Log>.Instance.Info(ELogModule.Game, ELogAuthor.WY, "Game.Shutdown ControllerManager.Clear Finished", default(ReadOnlySpan<ValueTuple<string, object>>));
			ModelManagerBase<ModelManager>.Instance.Clear();
			Singleton<Log>.Instance.Info(ELogModule.Game, ELogAuthor.WY, "Game.Shutdown ModelManagerCreator.Clear Finished", default(ReadOnlySpan<ValueTuple<string, object>>));
			Singleton<GameSettingsDeviceRender>.Instance.Clear();
			Singleton<Log>.Instance.Info(ELogModule.Game, ELogAuthor.WY, "Game.Shutdown GameSettingsRenderManager.Clear Finished", default(ReadOnlySpan<ValueTuple<string, object>>));
			Singleton<TaskSystem>.Instance.Clear();
			Singleton<Log>.Instance.Info(ELogModule.Game, ELogAuthor.WY, "Game.Shutdown TaskSystem.Clear Finished", default(ReadOnlySpan<ValueTuple<string, object>>));
			Singleton<EffectSystem>.Instance.Clear();
			Singleton<Log>.Instance.Info(ELogModule.Game, ELogAuthor.WY, "Game.Shutdown EffectSystem.Clear Finished", default(ReadOnlySpan<ValueTuple<string, object>>));
			UiTextTranslationUtils.Destroy();
			Singleton<Log>.Instance.Info(ELogModule.Game, ELogAuthor.WY, "Game.Shutdown UiTextTranslationUtils.Destroy Finished", default(ReadOnlySpan<ValueTuple<string, object>>));
			RichTextUtils.Destroy();
			Singleton<Log>.Instance.Info(ELogModule.Game, ELogAuthor.WY, "Game.Shutdown RichTextUtils.Destroy Finished", default(ReadOnlySpan<ValueTuple<string, object>>));
			Singleton<InputSettingsManager>.Instance.Clear();
			Singleton<Log>.Instance.Info(ELogModule.Game, ELogAuthor.LRX, "Game.Shutdown InputSettingsManager.Clear Finished", default(ReadOnlySpan<ValueTuple<string, object>>));
			Singleton<Application>.Instance.RemoveEditorPreEndPIEHandler(new Action(this.OnPreEndPIE));
			Singleton<Application>.Instance.Destroy();
			Singleton<Log>.Instance.Info(ELogModule.Game, ELogAuthor.WY, "Game.Shutdown Application.Destroy Finished", default(ReadOnlySpan<ValueTuple<string, object>>));
			Singleton<GameSettingsManager>.Instance.Clear();
			Singleton<Log>.Instance.Info(ELogModule.Game, ELogAuthor.WY, "Game.Shutdown GameSettingsManager.Clear Finished", default(ReadOnlySpan<ValueTuple<string, object>>));
			if (Singleton<Info>.Instance.UseFastInputCallback)
			{
				UKuroInputDelegateLibrary.DestroyEnvironment();
				Singleton<Log>.Instance.Info(ELogModule.Game, ELogAuthor.LRX, "Game.Shutdown UKuroInputDelegateLibrary.DestroyEnvironment Finished", default(ReadOnlySpan<ValueTuple<string, object>>));
			}
			UKuroPerceptionInterface.DestroyEnvironment();
			UKuroGameBudgetAllocatorCSharpInterface.DestroyEnvironment();
			Singleton<Log>.Instance.Info(ELogModule.Game, ELogAuthor.LRX, "Game.Shutdown UKuroGameBudgetAllocatorCSharpInterface.DestroyEnvironment Finished", default(ReadOnlySpan<ValueTuple<string, object>>));
			AsyncUtil.DestroyEnvironment();
			Singleton<Log>.Instance.Info(ELogModule.Game, ELogAuthor.WLJ, "Game.Shutdown AsyncUtil.DestroyEnvironment Finished", default(ReadOnlySpan<ValueTuple<string, object>>));
		}

		// Token: 0x0602F23E RID: 193086 RVA: 0x00B2B7A4 File Offset: 0x00B299A4
		private void DoLeaveLevel()
		{
			this.LeaveLevel();
		}

		// Token: 0x0602F23F RID: 193087 RVA: 0x00B2B7AC File Offset: 0x00B299AC
		private void ReconnectClearData()
		{
			this.Shutdown();
		}

		// Token: 0x0602F240 RID: 193088 RVA: 0x00B2B7B4 File Offset: 0x00B299B4
		private void ClearPatch()
		{
			this.Shutdown();
		}

		// Token: 0x0602F241 RID: 193089 RVA: 0x00B2B7BC File Offset: 0x00B299BC
		private void OnPreEndPIE()
		{
			Singleton<EventSystem>.Instance.Emit(EEventName.OnPreEndPIE);
			this.Shutdown();
		}

		// Token: 0x0602F242 RID: 193090 RVA: 0x00B2B7D4 File Offset: 0x00B299D4
		public void LockLoad()
		{
			Singleton<Log>.Instance.Info(ELogModule.Game, ELogAuthor.TL, "[Game.EndTravelMap] SetActorPermanentExtraStatic true", default(ReadOnlySpan<ValueTuple<string, object>>));
		}

		// Token: 0x0602F243 RID: 193091 RVA: 0x00B2B800 File Offset: 0x00B29A00
		public void UnlockLoad()
		{
			Singleton<Log>.Instance.Info(ELogModule.Game, ELogAuthor.TL, "[Game.EndTravelMap] SetActorPermanentExtraStatic false", default(ReadOnlySpan<ValueTuple<string, object>>));
		}

		// Token: 0x0602F244 RID: 193092 RVA: 0x00B2B829 File Offset: 0x00B29A29
		private void BeforeTravelMap()
		{
		}

		// Token: 0x0602F245 RID: 193093 RVA: 0x00B2B82B File Offset: 0x00B29A2B
		private void EndTravelMap()
		{
			this.UnlockLoad();
		}

		// Token: 0x0602F246 RID: 193094 RVA: 0x00B2B833 File Offset: 0x00B29A33
		private void OnClearScene()
		{
			this.ClearSceneAsync();
		}

		// Token: 0x0602F247 RID: 193095 RVA: 0x00B2B83C File Offset: 0x00B29A3C
		[NullableContext(0)]
		private UniTask<bool> ClearSceneAsync()
		{
			Game.<ClearSceneAsync>d__19 <ClearSceneAsync>d__;
			<ClearSceneAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder<bool>.Create();
			<ClearSceneAsync>d__.<>4__this = this;
			<ClearSceneAsync>d__.<>1__state = -1;
			<ClearSceneAsync>d__.<>t__builder.Start<Game.<ClearSceneAsync>d__19>(ref <ClearSceneAsync>d__);
			return <ClearSceneAsync>d__.<>t__builder.Task;
		}

		// Token: 0x0602F248 RID: 193096 RVA: 0x00B2B880 File Offset: 0x00B29A80
		private void ClearControllerAndModel()
		{
			GameModeModel instance = ModelBase<GameModeModel>.Instance;
			if (instance != null && instance.MapId > 0)
			{
				try
				{
					ControllerManagerBase<ControllerManager>.Instance.LeaveLevel();
				}
				catch (Exception ex)
				{
					Log instance2 = Singleton<Log>.Instance;
					ELogModule module = ELogModule.Game;
					ELogAuthor author = ELogAuthor.LFJW;
					string message = "[Game.LeaveLevel] 调用ControllerManager.LeaveLevel异常。";
					Exception error = ex;
					ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("error", ex.Message);
					instance2.ErrorWithStack(module, author, message, error, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
				}
				try
				{
					ModelManagerBase<ModelManager>.Instance.LeaveLevel();
				}
				catch (Exception ex2)
				{
					Log instance3 = Singleton<Log>.Instance;
					ELogModule module2 = ELogModule.Game;
					ELogAuthor author2 = ELogAuthor.LFJW;
					string message2 = "[Game.LeaveLevel] 调用ModelManager.LeaveLevel异常。";
					Exception error2 = ex2;
					ValueTuple<string, object> valueTuple2 = new ValueTuple<string, object>("error", ex2.Message);
					instance3.ErrorWithStack(module2, author2, message2, error2, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple2));
				}
			}
		}

		// Token: 0x0602F249 RID: 193097 RVA: 0x00B2B93C File Offset: 0x00B29B3C
		private void LeaveLevel()
		{
			Singleton<Log>.Instance.Info(ELogModule.World, ELogAuthor.LFJW, "[Game.LeaveLevel] LeaveLevel", default(ReadOnlySpan<ValueTuple<string, object>>));
			try
			{
				Singleton<EventSystem>.Instance.Emit(EEventName.ClearWorld);
			}
			catch (Exception ex)
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.Game;
				ELogAuthor author = ELogAuthor.LFJW;
				string message = "[Game.LeaveLevel] 调用EventSystem.Emit(EEventName.ClearWorld)异常。";
				Exception error = ex;
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("error", ex.Message);
				instance.ErrorWithStack(module, author, message, error, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			}
		}

		// Token: 0x0602F24A RID: 193098 RVA: 0x00B2B9B8 File Offset: 0x00B29BB8
		private unsafe void TickManager(ITickable tickTarget, float delta)
		{
			try
			{
				tickTarget.Tick(delta);
			}
			catch (Exception ex)
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.Game;
				ELogAuthor author = ELogAuthor.ZQR;
				string message = "Error when execute";
				Exception error = ex;
				<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("this type", tickTarget.GetType().Name);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("error", ex.Message);
				instance.ErrorWithStack(module, author, message, error, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
			}
		}

		// Token: 0x0602F24B RID: 193099 RVA: 0x00B2BA44 File Offset: 0x00B29C44
		public void TickPriority2(float delta)
		{
			if (Singleton<Core>.Instance.ForbiddenTickPriority)
			{
				return;
			}
			if (Singleton<TickSystem>.Instance.IsPaused)
			{
				return;
			}
			ControllerBase<PlotController>.Instance.TickPriority2(delta);
			ControllerBase<HoldingHandsController>.Instance.TickPriority2((double)delta);
			if (UeSkeletalTickController.EnabledNewSkelTickTiming && !UeMovementTickController.MovementPredictMode)
			{
				UeSkeletalTickController.TickManagers(delta * 0.001f);
			}
			ControllerBase<CombatMessageController>.Instance.TickPriority1(delta);
			ControllerBase<VehiclePathMoveController>.Instance.TickPriority1(delta);
			ControllerBase<ComponentForceTickController>.Instance.MoveTickPriority1(delta);
		}

		// Token: 0x0602F24C RID: 193100 RVA: 0x00B2BAC0 File Offset: 0x00B29CC0
		public void TickPriority1(float delta)
		{
			if (!Singleton<Core>.Instance.ForbiddenTickPriority)
			{
				if (!Singleton<TickSystem>.Instance.IsPaused)
				{
					UeMovementTickController.TickManagersPriority1(delta);
				}
				if (!UeMovementTickController.MovementPredictMode)
				{
					UeSkeletalTickController.TickManagersStep2();
				}
				else
				{
					UeSkeletalTickController.TickManagers(delta * 0.001f);
				}
				Singleton<TickSystem>.Instance.SetTickFunctionCompletionCallbackInMainThread(ETickingGroup.TG_PrePhysics, 1);
				return;
			}
			if (!UeMovementTickController.MovementPredictMode)
			{
				UeSkeletalTickController.TickManagersStep2();
				return;
			}
			UeSkeletalTickController.TickManagers(delta * 0.001f);
		}

		// Token: 0x0602F24D RID: 193101 RVA: 0x00B2BB2C File Offset: 0x00B29D2C
		private void Tick(float delta)
		{
			if (Singleton<Core>.Instance.ForbiddenTickPriority && !Singleton<TickSystem>.Instance.IsPaused)
			{
				ControllerBase<VehiclePathMoveController>.Instance.TickPriority1(delta);
				ControllerBase<ComponentForceTickController>.Instance.MoveTickPriority1(delta);
			}
			if (!Singleton<TickSystem>.Instance.IsPaused && !UeSkeletalTickController.EnabledNewSkelTickTiming)
			{
				UeSkeletalTickController.TickManagers(delta * 0.001f);
			}
			this.TickManager(Singleton<UiManager>.Instance, delta);
			this.TickManager(Singleton<UiSceneManager>.Instance, delta);
			this.TickManager(Singleton<UiCameraAnimationManager>.Instance, delta);
			this.TickManager(Singleton<RedDotSystem>.Instance, delta);
			ControllerManagerBase<ControllerManager>.Instance.Tick(delta);
			this.TickManager(Singleton<EffectSystem>.Instance, delta);
			this.TickManager(Singleton<TimeUtil>.Instance, delta);
			this.TickManager(Singleton<AudioController>.Instance, delta);
			this.TickManager(Singleton<AudioSystem>.Instance, delta);
			if (KuroApplication.IniPlatformNameIncludeEditor() == "Android")
			{
				this.TickManager(Singleton<SoPatchStatic>.Instance, delta);
			}
			if (!Singleton<TickSystem>.Instance.IsPaused)
			{
				this.TickManager(Singleton<TickScoreController>.Instance, delta);
			}
			Singleton<ResourceSystem>.Instance.UpdateDelayCallback(true);
		}

		// Token: 0x0602F24E RID: 193102 RVA: 0x00B2BC31 File Offset: 0x00B29E31
		public void AfterTickPriority1(float delta)
		{
			Singleton<Time>.Instance.AfterTickPriority1(delta);
			UeSkeletalTickController.DealCompleteSkeletalComp();
		}

		// Token: 0x0602F24F RID: 193103 RVA: 0x00B2BC44 File Offset: 0x00B29E44
		public void AfterTick(float delta)
		{
			if (!Singleton<TickSystem>.Instance.IsPaused)
			{
				UeSkeletalTickController.AfterTickManagers(delta * 0.001f);
				ControllerBase<BulletController>.Instance.AfterTick(delta);
				ControllerBase<ComponentForceTickController>.Instance.AfterTick(delta);
			}
			Singleton<EffectSystem>.Instance.AfterTick(delta);
			ControllerBase<CombatMessageController>.Instance.AfterTick(delta);
			ControllerBase<PlotController>.Instance.AfterTick(delta);
			ControllerBase<GameModeController>.Instance.AfterTick(delta);
		}

		// Token: 0x0602F250 RID: 193104 RVA: 0x00B2BCAB File Offset: 0x00B29EAB
		public void AfterCameraTick(float delta)
		{
			Singleton<UiManager>.Instance.AfterTick(delta);
			if (!Singleton<TickSystem>.Instance.IsPaused)
			{
				ControllerBase<HudUnitController>.Instance.AfterTick(delta);
			}
		}

		// Token: 0x0602F251 RID: 193105 RVA: 0x00B2BCD0 File Offset: 0x00B29ED0
		private UniTask InitEditorMetricsModule()
		{
			Game.<InitEditorMetricsModule>d__29 <InitEditorMetricsModule>d__;
			<InitEditorMetricsModule>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<InitEditorMetricsModule>d__.<>1__state = -1;
			<InitEditorMetricsModule>d__.<>t__builder.Start<Game.<InitEditorMetricsModule>d__29>(ref <InitEditorMetricsModule>d__);
			return <InitEditorMetricsModule>d__.<>t__builder.Task;
		}

		// Token: 0x0602F252 RID: 193106 RVA: 0x00B2BD0B File Offset: 0x00B29F0B
		private void CustomCommandProcessor(string command)
		{
			Singleton<EventSystem>.Instance.Emit<string>(EEventName.RunGm, command);
		}

		// Token: 0x0401ADA6 RID: 109990
		private readonly Stat UiStatsObject = Stat.Create("UI", "", "");

		// Token: 0x0401ADA7 RID: 109991
		private readonly Stat EffectStatsObject = Stat.Create("Effect", "", "");

		// Token: 0x0401ADA8 RID: 109992
		private readonly Stat OtherStatsObject = Stat.Create("Other", "", "");

		// Token: 0x0401ADA9 RID: 109993
		private readonly Stat TickScoreStatsObject = Stat.Create("TickScore", "", "");

		// Token: 0x0401ADAA RID: 109994
		[Nullable(2)]
		private FProcessCustomCommandDelegate CustomCommandProcessorDelegate;

		// Token: 0x0401ADAB RID: 109995
		private readonly bool UseStatConsoleCommand = true;
	}
}
