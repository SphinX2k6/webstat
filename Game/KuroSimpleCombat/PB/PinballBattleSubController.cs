using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using Aki.Config;
using Aki.Protocol;
using AkiClient.Game.Aki.Character.BaseCharacter.Camera;
using AkiClient.Game.Aki.Data.SimpleCombat._3_3Pinball.GameBase.SpawnObj;
using CSharpScript.Core.Common;
using CSharpScript.Game.Camera;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.Activity.ActivityContent.Pinball;
using CSharpScript.Game.Module.InstanceDungeon;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using Google.Protobuf.Collections;
using UnrealEngine;
using UnrealEngine.Extension;

namespace CSharpScript.Game.KuroSimpleCombat.PB
{
	// Token: 0x02006FC3 RID: 28611
	[NullableContext(1)]
	[Nullable(0)]
	public class PinballBattleSubController : KscSubControllerBase, IStaticVariableResetter
	{
		// Token: 0x060452BE RID: 283326 RVA: 0x0120DC80 File Offset: 0x0120BE80
		static PinballBattleSubController()
		{
			StaticVariableRegister.RegisterAndExecute(new Action(PinballBattleSubController.CreateStaticDefaultValue), new Action(PinballBattleSubController.ResetStaticDefaultValue));
		}

		// Token: 0x060452BF RID: 283327 RVA: 0x0120DC9F File Offset: 0x0120BE9F
		public static void CreateStaticDefaultValue()
		{
			PinballBattleSubController.PlayerEntityKeys = new int[]
			{
				5001,
				4001,
				4017
			};
			PinballBattleSubController.UpdateStat = Stat.Create("PinballBattleSubController.Update", "", "");
			PinballBattleSubController.EnableSpineParallelUpdate = false;
			PinballBattleSubController.EnableSpineShadow = true;
		}

		// Token: 0x060452C0 RID: 283328 RVA: 0x0120DCDC File Offset: 0x0120BEDC
		public static void ResetStaticDefaultValue()
		{
			PinballBattleSubController.PlayerEntityKeys = null;
			PinballBattleSubController.UpdateStat = null;
			PinballBattleSubController.EnableSpineParallelUpdate = false;
			PinballBattleSubController.EnableSpineShadow = false;
		}

		// Token: 0x1700A4AD RID: 42157
		// (get) Token: 0x060452C1 RID: 283329 RVA: 0x0120DCF8 File Offset: 0x0120BEF8
		private bool IsFormationTestMode
		{
			get
			{
				CreatureModel instance = ModelBase<CreatureModel>.Instance;
				return ((instance != null) ? new int?(instance.GetInstanceId()) : null).GetValueOrDefault() == 9801;
			}
		}

		// Token: 0x060452C2 RID: 283330 RVA: 0x0120DD32 File Offset: 0x0120BF32
		protected override void CreateModel()
		{
			this.SubModel = new PinballBattleSubModel();
		}

		// Token: 0x060452C3 RID: 283331 RVA: 0x0120DD3F File Offset: 0x0120BF3F
		public PinballBattleSubModel GetModel()
		{
			return this.SubModel as PinballBattleSubModel;
		}

		// Token: 0x060452C4 RID: 283332 RVA: 0x0120DD4C File Offset: 0x0120BF4C
		public override bool IsTargetMap(int instSubType)
		{
			return instSubType == 45;
		}

		// Token: 0x060452C5 RID: 283333 RVA: 0x0120DD53 File Offset: 0x0120BF53
		[NullableContext(2)]
		protected override UClass GetKscWorldClass()
		{
			return UKSC_Shape2D_World.StaticClass().ToWeakClass();
		}

		// Token: 0x060452C6 RID: 283334 RVA: 0x0120DD64 File Offset: 0x0120BF64
		protected override KscCollisionAlgorithmConfig? GetCollisionAlgorithmConfig()
		{
			return new KscCollisionAlgorithmConfig?(new KscCollisionAlgorithmConfig
			{
				AlgorithmClass = UKuroFastCollisionAlgorithm_PhysicalGrid.StaticClass().ToWeakClass(),
				TickEnabled = false
			});
		}

		// Token: 0x060452C7 RID: 283335 RVA: 0x0120DDA0 File Offset: 0x0120BFA0
		protected override void OnInitMap()
		{
			FDamageConfig fdamageConfig = new FDamageConfig();
			fdamageConfig.AtkDamageId = 331;
			fdamageConfig.SpecialElement1DamageId = 331;
			fdamageConfig.SpecialElement2DamageId = 332;
			fdamageConfig.SpecialElement3DamageId = 333;
			fdamageConfig.SpecialElement4DamageId = 334;
			fdamageConfig.SpecialElement5DamageId = 335;
			fdamageConfig.CureDamageId = 336;
			fdamageConfig.ShieldDamageId = 337;
			fdamageConfig.EnableCompactNumberFormat = true;
			fdamageConfig.DamageFormatType = EDamageFormatType.Pinball;
			ControllerBase<DamageUiController>.Instance.SetUeDamageConfig(fdamageConfig, false);
		}

		// Token: 0x060452C8 RID: 283336 RVA: 0x0120DE25 File Offset: 0x0120C025
		protected override void OnMapLoaded()
		{
			this.IsMapLoadFinish = true;
			this.InitBulletWorld();
			this.InitLevelConfig();
			this.AddTreeListener();
			this.TryInitShapeWorld();
		}

		// Token: 0x060452C9 RID: 283337 RVA: 0x0120DE48 File Offset: 0x0120C048
		private void InitLevelConfig()
		{
			int curLevelId = ModelBase<PinballModel>.Instance.CurLevelId;
			if (curLevelId == 0)
			{
				Singleton<Log>.Instance.Error(ELogModule.PinballBattle, ELogAuthor.LJ, "PinballBattleSubController OnWorldDone levelId is 0", default(ReadOnlySpan<ValueTuple<string, object>>));
				return;
			}
			PinballBattleSubModel model = this.GetModel();
			PinballLevelConfig? pinballLevelConfigById = ConfigBase<PinballConfig>.Instance.GetPinballLevelConfigById(curLevelId);
			if (pinballLevelConfigById.Value.Type == 2)
			{
				model.SetLevelScoreTargetList((from k in pinballLevelConfigById.Value.ScoreLevelReward().Keys
				select (float)k).ToList<float>());
			}
			model.SetLevelConfig(pinballLevelConfigById);
		}

		// Token: 0x060452CA RID: 283338 RVA: 0x0120DEF4 File Offset: 0x0120C0F4
		protected override void OnWorldDone()
		{
			this.PlayerHpHandle.Init();
			KscHeadStateData kscPlayerHeadStateData = this.GetModel().KscPlayerHeadStateData;
			if (kscPlayerHeadStateData != null)
			{
				this.PlayerHpHandle.OnPlayerHpChange(kscPlayerHeadStateData);
			}
			this.InitAttrBounds();
			this.InitDamageConfigsNew();
			if (this.IsFormationTestMode)
			{
				this.TempInitKscEntities();
			}
			this.TempInitCamera(null);
			this.InitBackgroundMaterial();
			this.RefreshCameraFov();
			this.SetShapeWorldReady();
			this.CachedShowFlagTonemapper = UKismetSystemLibrary.GetConsoleVariableIntValue("r.Kuro.KuroBloomEnable");
			UKismetSystemLibrary.ExecuteConsoleCommand(GlobalData.World, "r.Kuro.KuroBloomEnable 0", null);
			this.CachedScreenSizeCullRatioFactor = UKismetSystemLibrary.GetConsoleVariableIntValue("r.ScreenSizeCullRatioFactor");
			UKismetSystemLibrary.ExecuteConsoleCommand(GlobalData.World, "r.ScreenSizeCullRatioFactor 0", null);
			this.CachedAntiAliasing = UKismetSystemLibrary.GetConsoleVariableIntValue("r.DefaultFeature.AntiAliasing");
			UKismetSystemLibrary.ExecuteConsoleCommand(GlobalData.World, "r.DefaultFeature.AntiAliasing 0", null);
			Singleton<InputExtraShowCursorCenter>.Instance.RegisterExtraRefreshData("PinballBattleInstanceForceShowCursor", new PinballBattleSubController.AlwaysShowCursor());
			this.CreateLaunchController();
			TArray<int> tarray = new TArray<int>();
			int[] pinballBroadcastBuffIdAll = ConfigBase<PinballConfig>.Instance.GetPinballBroadcastBuffIdAll();
			if (pinballBroadcastBuffIdAll != null)
			{
				foreach (int value in pinballBroadcastBuffIdAll)
				{
					tarray.Add(value);
				}
			}
			UKSC_Shape2D_World shapeWorld = this.ShapeWorld;
			if (shapeWorld == null)
			{
				return;
			}
			shapeWorld.SetBroadcastBuffIdList(tarray);
		}

		// Token: 0x060452CB RID: 283339 RVA: 0x0120E028 File Offset: 0x0120C228
		protected override void OnWorldReset()
		{
			this.ClearBulletWorld();
			this.KscEntityLeftBar = null;
			this.KscEntityRightBar = null;
			PinballBattlePlayerBarController leftBarController = this.LeftBarController;
			if (leftBarController != null)
			{
				leftBarController.Destroy();
			}
			PinballBattlePlayerBarController rightBarController = this.RightBarController;
			if (rightBarController != null)
			{
				rightBarController.Destroy();
			}
			this.LeftBarController = null;
			this.RightBarController = null;
			PinballBattleFeverBarController feverBarController = this.FeverBarController;
			if (feverBarController != null)
			{
				feverBarController.Destroy();
			}
			this.FeverBarController = null;
			BP_Fever_Bar_C feverBar = this.FeverBar;
			if (feverBar != null)
			{
				feverBar.K2_DestroyActor();
			}
			this.FeverBar = null;
			this.FeverBarMaterial = null;
			this.KscTeamPlayer = null;
			this.KscPlayerEntities = Array.Empty<AKSC_Shape2D_Entity_Player>();
			this.RemoveTreeListener();
			this.PlayerHpHandle.Clear();
			this.DamageInfo = null;
			this.PendingLoadBuffs = null;
			if (this.KscEntitySummonDelegateRef != null)
			{
				global::DelegateUtils.ReleaseManualReleaseDelegate(new <>A{00000018}<FTransformDouble, TArray<FKSC_SpawnEntity>, int>(this.OnKscEntitySummon));
				this.KscEntitySummonDelegateRef = null;
			}
			if (this.RelaunchPlayerDelegateRef != null)
			{
				global::DelegateUtils.ReleaseManualReleaseDelegate(new Action(this.OnRelaunchPlayer));
				this.RelaunchPlayerDelegateRef = null;
			}
			if (this.TeamAllDeadDelegateRef != null)
			{
				global::DelegateUtils.ReleaseManualReleaseDelegate(new Action(this.OnTeamAllDead));
				this.TeamAllDeadDelegateRef = null;
			}
			if (this.WorldUpdateOnceDelegateRef != null)
			{
				global::DelegateUtils.ReleaseManualReleaseDelegate(new Action(this.OnWorldUpdateOnce));
				this.WorldUpdateOnceDelegateRef = null;
			}
			this.ClearTotalDelegateList();
			UKSC_Shape2D_World shapeWorld = this.ShapeWorld;
			if (shapeWorld != null)
			{
				shapeWorld.ClearDamageInfo();
			}
			UKSC_Shape2D_World shapeWorld2 = this.ShapeWorld;
			if (shapeWorld2 != null)
			{
				shapeWorld2.ClearDamageTotalInfo();
			}
			UObject world = GlobalData.World;
			DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(23, 1);
			defaultInterpolatedStringHandler.AppendLiteral("r.Kuro.KuroBloomEnable ");
			defaultInterpolatedStringHandler.AppendFormatted<int>(this.CachedShowFlagTonemapper);
			UKismetSystemLibrary.ExecuteConsoleCommand(world, defaultInterpolatedStringHandler.ToStringAndClear(), null);
			UObject world2 = GlobalData.World;
			defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(28, 1);
			defaultInterpolatedStringHandler.AppendLiteral("r.ScreenSizeCullRatioFactor ");
			defaultInterpolatedStringHandler.AppendFormatted<int>(this.CachedScreenSizeCullRatioFactor);
			UKismetSystemLibrary.ExecuteConsoleCommand(world2, defaultInterpolatedStringHandler.ToStringAndClear(), null);
			UObject world3 = GlobalData.World;
			defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(30, 1);
			defaultInterpolatedStringHandler.AppendLiteral("r.DefaultFeature.AntiAliasing ");
			defaultInterpolatedStringHandler.AppendFormatted<int>(this.CachedAntiAliasing);
			UKismetSystemLibrary.ExecuteConsoleCommand(world3, defaultInterpolatedStringHandler.ToStringAndClear(), null);
			this.StopAllTimerTask();
			this.LastSyncRealTimeMs = 0.0;
			this.IsInitKscPlayerEntities = false;
			this.IsFormationDataReady = false;
			this.IsShapeWorldReady = false;
			PinballBattleLaunchPhaseController launchPhaseController = this.LaunchPhaseController;
			if (launchPhaseController != null)
			{
				launchPhaseController.Destroy();
			}
			this.LaunchPhaseController = null;
			UiPanelBase launchBallItem = this.LaunchBallItem;
			if (launchBallItem != null)
			{
				launchBallItem.Destroy(null);
			}
			this.LaunchBallItem = null;
			PinballBattleLaunchDirectionController launchDirectionController = this.LaunchDirectionController;
			if (launchDirectionController != null)
			{
				launchDirectionController.Destroy();
			}
			this.LaunchDirectionController = null;
			PinballBattleLaunchDirectionItem launchDirectionItem = this.LaunchDirectionItem;
			if (launchDirectionItem != null)
			{
				launchDirectionItem.Destroy(null);
			}
			this.LaunchDirectionItem = null;
			this.AlreadyRequestBonusWin = false;
			this.IsInFixCamera = false;
			this.IsInitShapeWorld = false;
			this.IsPreloadFinish = false;
			this.IsMapLoadFinish = false;
			this.ShapeWorld = null;
			Singleton<InputExtraShowCursorCenter>.Instance.UnRegisterExtraRefreshData("PinballBattleInstanceForceShowCursor");
			Singleton<UiTimeDilation>.Instance.DeleteWaitSetTimeDilationTag("PinballPreReset");
		}

		// Token: 0x060452CC RID: 283340 RVA: 0x0120E2FC File Offset: 0x0120C4FC
		protected override void AddEvents()
		{
			Singleton<EventSystem>.Instance.Add(EEventName.UIViewPortSizeChanged, new Action(this.RefreshCameraFov));
			Singleton<EventSystem>.Instance.Add<int>(EEventName.OnPinballScoreChanged, new Action<int>(this.OnScoreChanged));
			Singleton<EventSystem>.Instance.Add<EUiViewName, int>(EEventName.CloseView, new Action<EUiViewName, int>(this.OnCloseView));
		}

		// Token: 0x060452CD RID: 283341 RVA: 0x0120E358 File Offset: 0x0120C558
		protected override void RemoveEvents()
		{
			Singleton<EventSystem>.Instance.Remove(EEventName.UIViewPortSizeChanged, new Action(this.RefreshCameraFov));
			Singleton<EventSystem>.Instance.Remove<int>(EEventName.OnPinballScoreChanged, new Action<int>(this.OnScoreChanged));
			Singleton<EventSystem>.Instance.Remove(EEventName.CloseView, new Action<EUiViewName, int>(this.OnCloseView));
		}

		// Token: 0x060452CE RID: 283342 RVA: 0x0120E3B4 File Offset: 0x0120C5B4
		protected override void OnTick(float delta)
		{
			this.UpdateDamageInfo();
			this.UpdateDamageTotalInfo();
			this.UpdateCombo();
			PinballBattlePlayerBarController leftBarController = this.LeftBarController;
			if (leftBarController != null)
			{
				leftBarController.Update();
			}
			PinballBattlePlayerBarController rightBarController = this.RightBarController;
			if (rightBarController != null)
			{
				rightBarController.Update();
			}
			PinballBattleLaunchPhaseController launchPhaseController = this.LaunchPhaseController;
			if (launchPhaseController != null)
			{
				launchPhaseController.Tick(delta);
			}
			PinballBattleLaunchDirectionController launchDirectionController = this.LaunchDirectionController;
			if (launchDirectionController == null)
			{
				return;
			}
			launchDirectionController.Update(this.KscEntityLeftBar, this.KscEntityRightBar);
		}

		// Token: 0x060452CF RID: 283343 RVA: 0x0120E424 File Offset: 0x0120C624
		public override UniTask PreloadAsync()
		{
			PinballBattleSubController.<PreloadAsync>d__90 <PreloadAsync>d__;
			<PreloadAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<PreloadAsync>d__.<>4__this = this;
			<PreloadAsync>d__.<>1__state = -1;
			<PreloadAsync>d__.<>t__builder.Start<PinballBattleSubController.<PreloadAsync>d__90>(ref <PreloadAsync>d__);
			return <PreloadAsync>d__.<>t__builder.Task;
		}

		// Token: 0x060452D0 RID: 283344 RVA: 0x0120E468 File Offset: 0x0120C668
		private unsafe void TryInitShapeWorld()
		{
			if (!this.IsPreloadFinish || !this.IsMapLoadFinish || this.IsInitShapeWorld)
			{
				return;
			}
			UKSC_Shape2D_World uksc_Shape2D_World = Singleton<KscEnv>.Instance.KscWorld as UKSC_Shape2D_World;
			if (uksc_Shape2D_World == null)
			{
				KscLog.Error(KscLog.EModule.Common, ELogAuthor.WWJ, Singleton<KscEnv>.Instance.KscWorld, "TryInitShapeWorld 初始化失败, World不存在", default(ReadOnlySpan<ValueTuple<string, object>>));
				return;
			}
			KscLog.EModule flag = KscLog.EModule.Common;
			ELogAuthor author = ELogAuthor.WWJ;
			UObject kscWorld = Singleton<KscEnv>.Instance.KscWorld;
			string log = "TryInitShapeWorld";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("shapeWorld", uksc_Shape2D_World);
			KscLog.Debug(flag, author, kscWorld, log, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			this.IsInitShapeWorld = true;
			this.ShapeWorld = uksc_Shape2D_World;
			GameModeModel instance = ModelBase<GameModeModel>.Instance;
			FVectorDouble? fvectorDouble = (instance != null) ? instance.BornLocation : null;
			if (fvectorDouble != null)
			{
				this.WorldOrigin.FromConfigVector(fvectorDouble);
				this.WorldOriginTransform.SetLocation(this.WorldOrigin);
			}
			else
			{
				KscLog.EModule flag2 = KscLog.EModule.Common;
				ELogAuthor author2 = ELogAuthor.WWJ;
				UObject kscWorld2 = Singleton<KscEnv>.Instance.KscWorld;
				string log2 = "TryInitShapeWorld Failed";
				ValueTuple<string, object> valueTuple2 = new ValueTuple<string, object>("bornLocation", fvectorDouble);
				KscLog.Debug(flag2, author2, kscWorld2, log2, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple2));
			}
			UKSC_Shape2D_World uksc_Shape2D_World2 = uksc_Shape2D_World;
			FVectorDouble fvectorDouble2 = this.WorldOrigin.ToUeVector(false);
			uksc_Shape2D_World2.SetWorldOrigin(fvectorDouble2);
			UKSC_DA_Shape2D_World shapeWorldDa = this.GetModel().ShapeWorldDa;
			if (shapeWorldDa != null)
			{
				uksc_Shape2D_World.SetShape2DWorldDA(shapeWorldDa);
				this.InitLocation.X = (double)shapeWorldDa.InitLocation.X + this.WorldOrigin.X;
				this.InitLocation.Y = (double)shapeWorldDa.InitLocation.Y + this.WorldOrigin.Y;
			}
			else
			{
				KscLog.EModule flag3 = KscLog.EModule.Common;
				ELogAuthor author3 = ELogAuthor.WWJ;
				UObject kscWorld3 = Singleton<KscEnv>.Instance.KscWorld;
				string log3 = "TryInitShapeWorld Failed";
				ValueTuple<string, object> valueTuple3 = new ValueTuple<string, object>("shapeWorldDa", shapeWorldDa);
				KscLog.Debug(flag3, author3, kscWorld3, log3, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple3));
			}
			UKSC_DA_Shape2D_WorldBounds shapeWorldBoundsDa = this.GetModel().ShapeWorldBoundsDa;
			if (shapeWorldBoundsDa != null)
			{
				uksc_Shape2D_World.SetWorldBounds(shapeWorldBoundsDa);
				this.GroundPositionZ = shapeWorldBoundsDa.GroundPositionZ + (float)this.WorldOrigin.Z;
				this.InitLocation.Z = (double)this.GroundPositionZ;
				global::Vector location = this.WorldOriginTransform.GetLocation();
				location.Z = (double)this.GroundPositionZ;
				this.WorldOriginTransform.SetLocation(location);
			}
			else
			{
				KscLog.EModule flag4 = KscLog.EModule.Common;
				ELogAuthor author4 = ELogAuthor.WWJ;
				UObject kscWorld4 = Singleton<KscEnv>.Instance.KscWorld;
				string log4 = "TryInitShapeWorld Failed";
				ValueTuple<string, object> valueTuple4 = new ValueTuple<string, object>("shapeWorldBoundsDa", shapeWorldBoundsDa);
				KscLog.Debug(flag4, author4, kscWorld4, log4, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple4));
			}
			this.BornTransform.SetLocation(this.InitLocation);
			UDataTable shapeMaterialDt = this.GetModel().ShapeMaterialDt;
			if (shapeMaterialDt != null)
			{
				uksc_Shape2D_World.SetShapeMaterialDT(shapeMaterialDt);
			}
			else
			{
				KscLog.EModule flag5 = KscLog.EModule.Common;
				ELogAuthor author5 = ELogAuthor.WWJ;
				UObject kscWorld5 = Singleton<KscEnv>.Instance.KscWorld;
				string log5 = "TryInitShapeWorld Failed";
				ValueTuple<string, object> valueTuple5 = new ValueTuple<string, object>("shapeMaterialDt", shapeMaterialDt);
				KscLog.Debug(flag5, author5, kscWorld5, log5, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple5));
			}
			UDataTable bulletDataTable = this.GetModel().BulletDataTable;
			BulletModel instance2 = ModelBase<BulletModel>.Instance;
			UBulletWorld ubulletWorld = (instance2 != null) ? instance2.GetKuroBulletWorld() : null;
			if (ubulletWorld != null && bulletDataTable != null)
			{
				ubulletWorld.AddCommonBulletDataTable(bulletDataTable);
			}
			else
			{
				KscLog.EModule flag6 = KscLog.EModule.Common;
				ELogAuthor author6 = ELogAuthor.WWJ;
				UObject kscWorld6 = Singleton<KscEnv>.Instance.KscWorld;
				string log6 = "TryInitShapeWorld Failed";
				<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("bulletWorld", ubulletWorld);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("bulletDt", bulletDataTable);
				KscLog.Debug(flag6, author6, kscWorld6, log6, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
			}
			foreach (KeyValuePair<int, UKSC_DA_Buff> keyValuePair in this.GetModel().LoadedBuffDaMap)
			{
				int num;
				UKSC_DA_Buff uksc_DA_Buff;
				keyValuePair.Deconstruct(out num, out uksc_DA_Buff);
				int value = num;
				UKSC_DA_Buff key = uksc_DA_Buff;
				uksc_Shape2D_World.LoadedBuffDa.Add(key, value);
			}
			this.KscEntitySummonDelegateRef = global::DelegateUtils.ToManualReleaseDelegate<FOnKSCEntitySummon>(new <>A{00000018}<FTransformDouble, TArray<FKSC_SpawnEntity>, int>(this.OnKscEntitySummon));
			this.RelaunchPlayerDelegateRef = global::DelegateUtils.ToManualReleaseDelegate<FOnRelaunchPlayer>(new Action(this.OnRelaunchPlayer));
			this.TeamAllDeadDelegateRef = global::DelegateUtils.ToManualReleaseDelegate<FOnTeamAllDead>(new Action(this.OnTeamAllDead));
			uksc_Shape2D_World.AssignKSCEntitySummon(this.KscEntitySummonDelegateRef);
			uksc_Shape2D_World.AssignRelaunchPlayer(this.RelaunchPlayerDelegateRef);
			uksc_Shape2D_World.AssignTeamAllDead(this.TeamAllDeadDelegateRef);
		}

		// Token: 0x060452D1 RID: 283345 RVA: 0x0120E860 File Offset: 0x0120CA60
		protected UniTask LoadBulletDt()
		{
			PinballBattleSubController.<LoadBulletDt>d__92 <LoadBulletDt>d__;
			<LoadBulletDt>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<LoadBulletDt>d__.<>4__this = this;
			<LoadBulletDt>d__.<>1__state = -1;
			<LoadBulletDt>d__.<>t__builder.Start<PinballBattleSubController.<LoadBulletDt>d__92>(ref <LoadBulletDt>d__);
			return <LoadBulletDt>d__.<>t__builder.Task;
		}

		// Token: 0x060452D2 RID: 283346 RVA: 0x0120E8A4 File Offset: 0x0120CAA4
		protected UniTask LoadShapeWorldDa()
		{
			PinballBattleSubController.<LoadShapeWorldDa>d__93 <LoadShapeWorldDa>d__;
			<LoadShapeWorldDa>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<LoadShapeWorldDa>d__.<>4__this = this;
			<LoadShapeWorldDa>d__.<>1__state = -1;
			<LoadShapeWorldDa>d__.<>t__builder.Start<PinballBattleSubController.<LoadShapeWorldDa>d__93>(ref <LoadShapeWorldDa>d__);
			return <LoadShapeWorldDa>d__.<>t__builder.Task;
		}

		// Token: 0x060452D3 RID: 283347 RVA: 0x0120E8E8 File Offset: 0x0120CAE8
		protected UniTask LoadShapeWorldBoundsDa()
		{
			PinballBattleSubController.<LoadShapeWorldBoundsDa>d__94 <LoadShapeWorldBoundsDa>d__;
			<LoadShapeWorldBoundsDa>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<LoadShapeWorldBoundsDa>d__.<>4__this = this;
			<LoadShapeWorldBoundsDa>d__.<>1__state = -1;
			<LoadShapeWorldBoundsDa>d__.<>t__builder.Start<PinballBattleSubController.<LoadShapeWorldBoundsDa>d__94>(ref <LoadShapeWorldBoundsDa>d__);
			return <LoadShapeWorldBoundsDa>d__.<>t__builder.Task;
		}

		// Token: 0x060452D4 RID: 283348 RVA: 0x0120E92C File Offset: 0x0120CB2C
		protected UniTask LoadShapeMaterialDt()
		{
			PinballBattleSubController.<LoadShapeMaterialDt>d__95 <LoadShapeMaterialDt>d__;
			<LoadShapeMaterialDt>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<LoadShapeMaterialDt>d__.<>4__this = this;
			<LoadShapeMaterialDt>d__.<>1__state = -1;
			<LoadShapeMaterialDt>d__.<>t__builder.Start<PinballBattleSubController.<LoadShapeMaterialDt>d__95>(ref <LoadShapeMaterialDt>d__);
			return <LoadShapeMaterialDt>d__.<>t__builder.Task;
		}

		// Token: 0x060452D5 RID: 283349 RVA: 0x0120E970 File Offset: 0x0120CB70
		protected UniTask LoadShowBuffDa()
		{
			PinballBattleSubController.<LoadShowBuffDa>d__96 <LoadShowBuffDa>d__;
			<LoadShowBuffDa>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<LoadShowBuffDa>d__.<>4__this = this;
			<LoadShowBuffDa>d__.<>1__state = -1;
			<LoadShowBuffDa>d__.<>t__builder.Start<PinballBattleSubController.<LoadShowBuffDa>d__96>(ref <LoadShowBuffDa>d__);
			return <LoadShowBuffDa>d__.<>t__builder.Task;
		}

		// Token: 0x060452D6 RID: 283350 RVA: 0x0120E9B4 File Offset: 0x0120CBB4
		protected UniTask LoadSummonBuffDa()
		{
			PinballBattleSubController.<LoadSummonBuffDa>d__97 <LoadSummonBuffDa>d__;
			<LoadSummonBuffDa>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<LoadSummonBuffDa>d__.<>4__this = this;
			<LoadSummonBuffDa>d__.<>1__state = -1;
			<LoadSummonBuffDa>d__.<>t__builder.Start<PinballBattleSubController.<LoadSummonBuffDa>d__97>(ref <LoadSummonBuffDa>d__);
			return <LoadSummonBuffDa>d__.<>t__builder.Task;
		}

		// Token: 0x060452D7 RID: 283351 RVA: 0x0120E9F8 File Offset: 0x0120CBF8
		protected UniTask LoadRoleBornBuffDa()
		{
			PinballBattleSubController.<LoadRoleBornBuffDa>d__98 <LoadRoleBornBuffDa>d__;
			<LoadRoleBornBuffDa>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<LoadRoleBornBuffDa>d__.<>4__this = this;
			<LoadRoleBornBuffDa>d__.<>1__state = -1;
			<LoadRoleBornBuffDa>d__.<>t__builder.Start<PinballBattleSubController.<LoadRoleBornBuffDa>d__98>(ref <LoadRoleBornBuffDa>d__);
			return <LoadRoleBornBuffDa>d__.<>t__builder.Task;
		}

		// Token: 0x060452D8 RID: 283352 RVA: 0x0120EA3C File Offset: 0x0120CC3C
		private bool AddLoadBuffTask(int buffId, List<UniTask> outTasks)
		{
			if (this.PendingLoadBuffs == null)
			{
				this.PendingLoadBuffs = new HashSet<int>();
			}
			else if (this.PendingLoadBuffs.Contains(buffId))
			{
				return false;
			}
			KSCBuff? kscbuff;
			string text = (ConfigKSCBuffById.GetConfig(buffId, true) != null) ? kscbuff.GetValueOrDefault().AssetPath : null;
			if (string.IsNullOrEmpty(text))
			{
				return false;
			}
			CustomPromise promise = new CustomPromise();
			Singleton<ResourceSystem>.Instance.LoadAsync<UKSC_DA_Buff>(text, delegate([Nullable(2)] UKSC_DA_Buff daBuff, string _)
			{
				if (daBuff != null)
				{
					this.GetModel().LoadedBuffDaMap[buffId] = daBuff;
				}
				promise.SetResult();
			}, 100, "js_undefined");
			outTasks.Add(promise.Promise);
			this.PendingLoadBuffs.Add(buffId);
			return true;
		}

		// Token: 0x060452D9 RID: 283353 RVA: 0x0120EB08 File Offset: 0x0120CD08
		private UniTask LoadLaunchCurves()
		{
			PinballBattleSubController.<LoadLaunchCurves>d__100 <LoadLaunchCurves>d__;
			<LoadLaunchCurves>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<LoadLaunchCurves>d__.<>4__this = this;
			<LoadLaunchCurves>d__.<>1__state = -1;
			<LoadLaunchCurves>d__.<>t__builder.Start<PinballBattleSubController.<LoadLaunchCurves>d__100>(ref <LoadLaunchCurves>d__);
			return <LoadLaunchCurves>d__.<>t__builder.Task;
		}

		// Token: 0x060452DA RID: 283354 RVA: 0x0120EB4C File Offset: 0x0120CD4C
		private UniTask LoadLaunchBall()
		{
			PinballBattleSubController.<LoadLaunchBall>d__101 <LoadLaunchBall>d__;
			<LoadLaunchBall>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<LoadLaunchBall>d__.<>4__this = this;
			<LoadLaunchBall>d__.<>1__state = -1;
			<LoadLaunchBall>d__.<>t__builder.Start<PinballBattleSubController.<LoadLaunchBall>d__101>(ref <LoadLaunchBall>d__);
			return <LoadLaunchBall>d__.<>t__builder.Task;
		}

		// Token: 0x060452DB RID: 283355 RVA: 0x0120EB90 File Offset: 0x0120CD90
		protected UniTask LoadFeverBarClass()
		{
			PinballBattleSubController.<LoadFeverBarClass>d__102 <LoadFeverBarClass>d__;
			<LoadFeverBarClass>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<LoadFeverBarClass>d__.<>1__state = -1;
			<LoadFeverBarClass>d__.<>t__builder.Start<PinballBattleSubController.<LoadFeverBarClass>d__102>(ref <LoadFeverBarClass>d__);
			return <LoadFeverBarClass>d__.<>t__builder.Task;
		}

		// Token: 0x060452DC RID: 283356 RVA: 0x0120EBCC File Offset: 0x0120CDCC
		protected UniTask LoadFeverBarMaterial()
		{
			PinballBattleSubController.<LoadFeverBarMaterial>d__103 <LoadFeverBarMaterial>d__;
			<LoadFeverBarMaterial>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<LoadFeverBarMaterial>d__.<>4__this = this;
			<LoadFeverBarMaterial>d__.<>1__state = -1;
			<LoadFeverBarMaterial>d__.<>t__builder.Start<PinballBattleSubController.<LoadFeverBarMaterial>d__103>(ref <LoadFeverBarMaterial>d__);
			return <LoadFeverBarMaterial>d__.<>t__builder.Task;
		}

		// Token: 0x060452DD RID: 283357 RVA: 0x0120EC10 File Offset: 0x0120CE10
		private UniTask LoadDirectionItem()
		{
			PinballBattleSubController.<LoadDirectionItem>d__104 <LoadDirectionItem>d__;
			<LoadDirectionItem>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<LoadDirectionItem>d__.<>4__this = this;
			<LoadDirectionItem>d__.<>1__state = -1;
			<LoadDirectionItem>d__.<>t__builder.Start<PinballBattleSubController.<LoadDirectionItem>d__104>(ref <LoadDirectionItem>d__);
			return <LoadDirectionItem>d__.<>t__builder.Task;
		}

		// Token: 0x060452DE RID: 283358 RVA: 0x0120EC54 File Offset: 0x0120CE54
		public unsafe override void OnEntityRemoved(KscRemoveContext context, Dictionary<long, SimpleCombatEntityDieContext> protoContexts)
		{
			KscEntityHandle kscEntityHandle = this.GetModel().GetKscEntityHandle(context.CreatureDataId);
			if (((kscEntityHandle != null) ? kscEntityHandle.KscEntity : null) != null)
			{
				this.SetSpineCompTickEnabled(kscEntityHandle.KscEntity, false);
			}
			if (this.GetModel().GetEntity((int)context.CreatureDataId) == null)
			{
				return;
			}
			SimpleCombatEntityDieContext simpleCombatEntityDieContext = SimpleCombatEntityDieContext.Create();
			Aki.Protocol.Vector vector = Aki.Protocol.Vector.Create();
			vector.X = (float)context.Location.X;
			vector.Y = (float)context.Location.Y;
			vector.Z = (float)context.Location.Z;
			simpleCombatEntityDieContext.DiePos = vector;
			if (FNameUtil.GetDynamicFName(context.ReasonName.ToString()) == KscEntityRemoveReason.Dead)
			{
				this.TryTriggerDeathrattle((int)context.CreatureDataId);
				PinballEntityKilledCtxPb pinballEntityKilledCtxPb = PinballEntityKilledCtxPb.Create();
				pinballEntityKilledCtxPb.EntityId = context.KillerId;
				simpleCombatEntityDieContext.PinballEntityKilledCtx = pinballEntityKilledCtxPb;
				protoContexts[context.CreatureDataId] = simpleCombatEntityDieContext;
				return;
			}
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.PinballBattle;
			ELogAuthor author = ELogAuthor.LJ;
			string message = "移除星弹奇游实体失败: 未处理移除原因";
			<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("creatureDataId", context.CreatureDataId);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("reasonName", context.ReasonName);
			instance.Error(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
		}

		// Token: 0x060452DF RID: 283359 RVA: 0x0120EDCC File Offset: 0x0120CFCC
		public override void InitPropertyConfigs()
		{
			if (this.GetModel() == null)
			{
				return;
			}
			IReadOnlyList<PinballAttr> allAttrConfigs = ConfigBase<PinballBattleConfig>.Instance.GetAllAttrConfigs();
			if (allAttrConfigs != null)
			{
				foreach (PinballAttr value in allAttrConfigs)
				{
					this.GetModel().PinballPropertyConfigs[value.Id] = value;
				}
			}
			this.GetModel().InitMonsterAttrConfigs();
		}

		// Token: 0x060452E0 RID: 283360 RVA: 0x0120EE48 File Offset: 0x0120D048
		public override Dictionary<EKSC_AttrType, float> GetAttrsDefault(int propertyId)
		{
			Dictionary<EKSC_AttrType, float> dictionary = new Dictionary<EKSC_AttrType, float>();
			PinballAttr attrConfig;
			if (this.GetModel().PinballPropertyConfigs.TryGetValue(propertyId, out attrConfig))
			{
				this.GetModel().GetCommonAttrs(dictionary, attrConfig);
				return dictionary;
			}
			Dictionary<EKSC_AttrType, float> result;
			if (this.GetModel().PinballMonsterAttrConfigs.TryGetValue(propertyId, out result))
			{
				return result;
			}
			return dictionary;
		}

		// Token: 0x060452E1 RID: 283361 RVA: 0x0120EE97 File Offset: 0x0120D097
		public override void InitDamageConfigs()
		{
		}

		// Token: 0x060452E2 RID: 283362 RVA: 0x0120EE9C File Offset: 0x0120D09C
		private void InitDamageConfigsNew()
		{
			UKSC_Shape2D_World shapeWorld = this.ShapeWorld;
			if (shapeWorld == null)
			{
				KscLog.Error(KscLog.EModule.Load, ELogAuthor.WWJ, Singleton<KscEnv>.Instance.KscWorld, "InitDamageConfigsNew failed, No World", default(ReadOnlySpan<ValueTuple<string, object>>));
				return;
			}
			IReadOnlyList<PinballDamage> allDamageConfigs = ConfigBase<PinballBattleConfig>.Instance.GetAllDamageConfigs();
			if (allDamageConfigs == null)
			{
				KscLog.Error(KscLog.EModule.Load, ELogAuthor.WWJ, Singleton<KscEnv>.Instance.KscWorld, "InitDamageConfigsNew failed, No Configs", default(ReadOnlySpan<ValueTuple<string, object>>));
				return;
			}
			UKSC_DamageId damageData = shapeWorld.DamageData;
			if (damageData == null || !damageData.IsValid())
			{
				KscLog.Error(KscLog.EModule.Load, ELogAuthor.WWJ, Singleton<KscEnv>.Instance.KscWorld, "InitDamageIdConfig failed, No DamageData", default(ReadOnlySpan<ValueTuple<string, object>>));
				return;
			}
			KscLog.Debug(KscLog.EModule.Load, ELogAuthor.WWJ, Singleton<KscEnv>.Instance.KscWorld, "InitDamageIdConfig", default(ReadOnlySpan<ValueTuple<string, object>>));
			shapeWorld.SetDamageHandler(UKSC_DamageHandler_WF.StaticClass());
			Dictionary<int, FKSCDamage> damageIds = base.Model.DamageIds;
			foreach (PinballDamage pinballDamage in allDamageConfigs)
			{
				FKSCDamage fkscdamage = new FKSCDamage();
				fkscdamage.DamageID = (int)pinballDamage.Id;
				fkscdamage.CalculateType = (EKSC_CalculateType)pinballDamage.CalculateType;
				fkscdamage.Element = (EKSC_Element)pinballDamage.Element;
				fkscdamage.Amplify = (float)pinballDamage.Amplify * 0.0001f;
				fkscdamage.RelatedProperty = (EKSC_AttrType)pinballDamage.RelatedProperty;
				damageIds[(int)pinballDamage.Id] = fkscdamage;
				damageData.AddDamageData((int)pinballDamage.Id, fkscdamage);
				FKSC_Shape2D_DamageEffect fksc_Shape2D_DamageEffect = new FKSC_Shape2D_DamageEffect(pinballDamage.IsRecordedCombo == 1, (float)pinballDamage.RecoverSkillEnergy, (float)pinballDamage.RecoverSprintEnergy, (float)pinballDamage.RecoverFeverEnergy, pinballDamage.IsRecoverTeamSkillEnergy == 1);
				shapeWorld.AddDamageEffectData((int)pinballDamage.Id, fksc_Shape2D_DamageEffect);
			}
		}

		// Token: 0x060452E3 RID: 283363 RVA: 0x0120F074 File Offset: 0x0120D274
		protected override void InitEntityAndSkillDt()
		{
			KscUtil.LoadDt<FKSCEntityTableRow>(Singleton<KscEnv>.Instance.KscWorld, this.GetModel().GetEntityDtPath(), this.GetModel().EntityDataDt);
		}

		// Token: 0x060452E4 RID: 283364 RVA: 0x0120F09C File Offset: 0x0120D29C
		private void InitAttrBounds()
		{
			TMap<EKSC_AttrType, EKSC_AttrType> attributeIdsWithMax = Singleton<KscEnv>.Instance.KscWorld.AttributeIdsWithMax;
			attributeIdsWithMax.Add(EKSC_AttrType.Life, EKSC_AttrType.LifeMax);
			attributeIdsWithMax.Add(EKSC_AttrType.BaseLife, EKSC_AttrType.LifeMax);
			attributeIdsWithMax.Add(EKSC_AttrType.Shield, EKSC_AttrType.ShieldMax);
			attributeIdsWithMax.Add(EKSC_AttrType.SpecialEnergy1, EKSC_AttrType.SpecialEnergy1Max);
			attributeIdsWithMax.Add(EKSC_AttrType.SpecialEnergy2, EKSC_AttrType.SpecialEnergy2Max);
			attributeIdsWithMax.Add(EKSC_AttrType.SpecialEnergy3, EKSC_AttrType.SpecialEnergy3Max);
		}

		// Token: 0x060452E5 RID: 283365 RVA: 0x0120F0EF File Offset: 0x0120D2EF
		protected override void CreateEntityFilter()
		{
			this.RedirectFilter = this.EntityRedirectFilter;
		}

		// Token: 0x060452E6 RID: 283366 RVA: 0x0120F0FD File Offset: 0x0120D2FD
		[NullableContext(2)]
		protected override EntityHandle GetPossessedPlayerEntity()
		{
			return null;
		}

		// Token: 0x060452E7 RID: 283367 RVA: 0x0120F100 File Offset: 0x0120D300
		protected override void SyncPlayerTransform()
		{
		}

		// Token: 0x060452E8 RID: 283368 RVA: 0x0120F102 File Offset: 0x0120D302
		private void AddTreeListener()
		{
		}

		// Token: 0x060452E9 RID: 283369 RVA: 0x0120F104 File Offset: 0x0120D304
		private void RemoveTreeListener()
		{
		}

		// Token: 0x060452EA RID: 283370 RVA: 0x0120F106 File Offset: 0x0120D306
		public override void OnPlayerEntityCreated()
		{
		}

		// Token: 0x060452EB RID: 283371 RVA: 0x0120F108 File Offset: 0x0120D308
		private void OnPlayerEntityCreatedNew(AKSC_Shape2D_Entity_Player kscPlayer, PinballFormationRolePb roleData)
		{
			this.UpdateTranslucentSortPriority(kscPlayer, roleData.RoleId, null);
			USpineSkeletonAnimationComponent uspineSkeletonAnimationComponent = kscPlayer.GetComponentByClass(USpineSkeletonAnimationComponent.StaticClass()) as USpineSkeletonAnimationComponent;
			if (uspineSkeletonAnimationComponent != null && uspineSkeletonAnimationComponent.IsValid())
			{
				uspineSkeletonAnimationComponent.SetTickableWhenPaused(false);
			}
			TArray<UActorComponent> tarray = kscPlayer.K2_GetComponentsByClass(USpineSkeletonRendererComponent.StaticClass());
			for (int i = 0; i < tarray.Num(); i++)
			{
				USpineSkeletonRendererComponent uspineSkeletonRendererComponent = tarray.Get(i) as USpineSkeletonRendererComponent;
				if (uspineSkeletonRendererComponent != null && uspineSkeletonRendererComponent.IsValid())
				{
					uspineSkeletonRendererComponent.SetTickableWhenPaused(false);
				}
			}
		}

		// Token: 0x060452EC RID: 283372 RVA: 0x0120F198 File Offset: 0x0120D398
		private void OnTeamPlayerEntityCreated(AKSC_Shape2D_Entity_TeamPlayer kscTeamPlayer)
		{
			Dictionary<EKSC_AttrType, float> dictionary = new Dictionary<EKSC_AttrType, float>();
			this.GetModel().GetTeamAttrs(1001, dictionary);
			foreach (KeyValuePair<EKSC_AttrType, float> keyValuePair in dictionary)
			{
				kscTeamPlayer.SetAttr(keyValuePair.Key, (int)keyValuePair.Value);
			}
			PinballBattleFeverBarController feverBarController = this.FeverBarController;
			if (feverBarController == null)
			{
				return;
			}
			feverBarController.BindAttr(kscTeamPlayer);
		}

		// Token: 0x060452ED RID: 283373 RVA: 0x0120F21C File Offset: 0x0120D41C
		protected void InitKscPlayerEntities()
		{
			if (!this.IsShapeWorldReady)
			{
				return;
			}
			if (!this.IsFormationTestMode && !this.IsFormationDataReady)
			{
				return;
			}
			if (this.IsInitKscPlayerEntities)
			{
				return;
			}
			this.IsInitKscPlayerEntities = true;
			int formationLength = 3;
			List<PinballFormationRolePb> list = null;
			if (this.IsFormationDataReady)
			{
				PinballBattleSubModel model = this.GetModel();
				list = ((model != null) ? model.FormationData : null);
				if (list == null || list.Count == 0)
				{
					Log instance = Singleton<Log>.Instance;
					ELogModule module = ELogModule.PinballBattle;
					ELogAuthor author = ELogAuthor.WWJ;
					string message = "角色编队加载失败";
					ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("FormationData", list);
					instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
					return;
				}
				formationLength = list.Count;
			}
			ControllerBase<KuroSimpleCombatController>.Instance.AddEntityDt((long)this.GetCreatureSpawnId(), 10001, null, this.WorldOriginTransform.ToUeTransform(), delegate(AKSC_Entity kscEntity)
			{
				AKSC_Shape2D_Entity_TeamPlayer aksc_Shape2D_Entity_TeamPlayer = kscEntity as AKSC_Shape2D_Entity_TeamPlayer;
				if (aksc_Shape2D_Entity_TeamPlayer != null)
				{
					this.OnTeamPlayerEntityCreated(aksc_Shape2D_Entity_TeamPlayer);
					this.KscTeamPlayer = aksc_Shape2D_Entity_TeamPlayer;
					Singleton<EventSystem>.Instance.Emit<int>(EEventName.OnPinballEntityCreated, 10001);
				}
			});
			this.KscPlayerEntityIds = new int[formationLength];
			this.KscPlayerEntities = new AKSC_Shape2D_Entity_Player[formationLength];
			this.KscPlayerInitCount = 0;
			for (int i = 0; i < formationLength; i++)
			{
				int? num = null;
				PinballFormationRolePb pinballFormationRolePb = null;
				if (this.IsFormationDataReady)
				{
					pinballFormationRolePb = list[i];
					PinballRoleConfig? roleConfig = ConfigBase<PinballBattleConfig>.Instance.GetRoleConfig(pinballFormationRolePb.RoleId);
					num = ((roleConfig != null) ? new int?(roleConfig.GetValueOrDefault().KscEntityId) : null);
				}
				else
				{
					num = new int?(PinballBattleSubController.PlayerEntityKeys[i]);
				}
				if (num != null)
				{
					int creatureSpawnId = this.GetCreatureSpawnId();
					if (pinballFormationRolePb != null)
					{
						this.GetModel().SetRoleId2CreatureId(pinballFormationRolePb.RoleId, creatureSpawnId);
					}
					int positionIndex = i;
					PinballFormationRolePb capturedRoleData = pinballFormationRolePb;
					ControllerBase<KuroSimpleCombatController>.Instance.AddEntityDt((long)creatureSpawnId, num.Value, null, this.BornTransform.ToUeTransform(), delegate(AKSC_Entity kscEntity)
					{
						AKSC_Shape2D_Entity_Player aksc_Shape2D_Entity_Player = kscEntity as AKSC_Shape2D_Entity_Player;
						if (aksc_Shape2D_Entity_Player == null)
						{
							return;
						}
						PinballFormationRolePb capturedRoleData;
						if (capturedRoleData != null)
						{
							this.OnPlayerEntityCreatedNew(aksc_Shape2D_Entity_Player, capturedRoleData);
						}
						this.KscPlayerEntities[positionIndex] = aksc_Shape2D_Entity_Player;
						this.KscPlayerEntityIds[positionIndex] = aksc_Shape2D_Entity_Player.EntityId_;
						this.KscPlayerInitCount++;
						this.SetPlayerEntityActive(aksc_Shape2D_Entity_Player, false, true);
						IReadOnlyDictionary<int, PinballRoleTotalInfo> roleTotalMap = this.GetModel().RoleTotalMap;
						capturedRoleData = capturedRoleData;
						PinballRoleTotalInfo valueOrDefault = roleTotalMap.GetValueOrDefault((capturedRoleData != null) ? capturedRoleData.RoleId : 0);
						PinballBattleSubController <>4__this = this;
						AKSC_Shape2D_Entity_Player playerEntity = aksc_Shape2D_Entity_Player;
						IPinballRoleTotalInfo roleTotalData = valueOrDefault;
						PinballFormationRolePb capturedRoleData2 = capturedRoleData;
						<>4__this.BindPlayerEntityTotalDelegate(playerEntity, roleTotalData, (capturedRoleData2 != null) ? capturedRoleData2.RoleId : 0);
						if (this.KscPlayerInitCount == formationLength)
						{
							TArray<int> tarray = new TArray<int>();
							tarray.AddUninitialized(this.KscPlayerEntityIds.Length);
							this.KscPlayerEntityIds.CopyTo(tarray.AsSpan<int>());
							UKSC_Shape2D_World shapeWorld = this.ShapeWorld;
							if (shapeWorld != null)
							{
								shapeWorld.InitTeamPlayerEntityIds(tarray);
							}
							Singleton<EventSystem>.Instance.Emit(EEventName.OnKscPlayerCreate);
							this.WorldUpdateOnceDelegateRef = global::DelegateUtils.ToManualReleaseDelegate<FOnWorldUpdateOnce>(new Action(this.OnWorldUpdateOnce));
							UKSC_Shape2D_World shapeWorld2 = this.ShapeWorld;
							if (shapeWorld2 == null)
							{
								return;
							}
							shapeWorld2.AssignWorldUpdateOnce(this.WorldUpdateOnceDelegateRef);
						}
					});
				}
			}
		}

		// Token: 0x060452EE RID: 283374 RVA: 0x0120F42B File Offset: 0x0120D62B
		protected override void AddKscPlayerEntity()
		{
			if (this.IsFormationTestMode)
			{
				this.InitKscPlayerEntities();
			}
		}

		// Token: 0x060452EF RID: 283375 RVA: 0x0120F43C File Offset: 0x0120D63C
		private void TempInitKscEntities()
		{
			GameModeModel instance = ModelBase<GameModeModel>.Instance;
			int mapId = (instance != null) ? instance.MapConfig.MapId : 0;
			PinballBattleConfig instance2 = ConfigBase<PinballBattleConfig>.Instance;
			IReadOnlyList<PinballEntityTest> readOnlyList = (instance2 != null) ? instance2.GetWorldEntities(mapId) : null;
			if (readOnlyList == null)
			{
				return;
			}
			global::Vector vector = global::Vector.Create();
			global::Rotator rotator = global::Rotator.Create();
			foreach (PinballEntityTest pinballEntityTest in readOnlyList)
			{
				global::Transform transform = global::Transform.Create();
				Aki.Config.Vector value = pinballEntityTest.Location.Value;
				Aki.Config.Vector value2 = pinballEntityTest.Rotation.Value;
				vector.X = (double)value.X + this.WorldOrigin.X;
				vector.Y = (double)value.Y + this.WorldOrigin.Y;
				vector.Z = (double)this.GroundPositionZ;
				transform.SetLocation(vector);
				rotator.Pitch = value2.X;
				rotator.Yaw = value2.Y;
				rotator.Roll = value2.Z;
				transform.SetRotation(rotator.Quaternion(null));
				ControllerBase<KuroSimpleCombatController>.Instance.AddEntityDt((long)this.GetCreatureSpawnId(), pinballEntityTest.KscEntityId, null, transform.ToUeTransform(), new Action<AKSC_Entity>(this.OnAddKscEntity));
			}
		}

		// Token: 0x060452F0 RID: 283376 RVA: 0x0120F5A8 File Offset: 0x0120D7A8
		private void OnAddKscEntity(AKSC_Entity kscEntity)
		{
			AKSC_Shape2D_Entity_Bar aksc_Shape2D_Entity_Bar = kscEntity as AKSC_Shape2D_Entity_Bar;
			if (aksc_Shape2D_Entity_Bar != null)
			{
				this.OnAddKscBar(aksc_Shape2D_Entity_Bar);
			}
		}

		// Token: 0x060452F1 RID: 283377 RVA: 0x0120F5C8 File Offset: 0x0120D7C8
		private void SetShapeWorldReady()
		{
			this.IsShapeWorldReady = true;
			if (PinballBattleSubController.EnableSpineParallelUpdate)
			{
				UKismetSystemLibrary.ExecuteConsoleCommand(GlobalData.World, "spine.Renderer.EnableParallelUpdate 1", null);
			}
			else
			{
				UKismetSystemLibrary.ExecuteConsoleCommand(GlobalData.World, "spine.Renderer.EnableParallelUpdate 0", null);
			}
			if (PinballBattleSubController.EnableSpineShadow)
			{
				UKismetSystemLibrary.ExecuteConsoleCommand(GlobalData.World, "ksc.Shape.SpineShadowEnable 1", null);
			}
			else
			{
				UKismetSystemLibrary.ExecuteConsoleCommand(GlobalData.World, "ksc.Shape.SpineShadowEnable 0", null);
			}
			this.InitFeverBar();
			this.InitLaunchDirectionController();
			this.InitKscPlayerEntities();
		}

		// Token: 0x060452F2 RID: 283378 RVA: 0x0120F640 File Offset: 0x0120D840
		private void SetFormationDataReady()
		{
			this.IsFormationDataReady = true;
			this.InitKscPlayerEntities();
		}

		// Token: 0x060452F3 RID: 283379 RVA: 0x0120F650 File Offset: 0x0120D850
		[return: Nullable(2)]
		public global::Transform GetEntityTransform(global::Vector location, global::Rotator rotation)
		{
			location.X += this.WorldOrigin.X;
			location.Y += this.WorldOrigin.Y;
			location.Z = (double)this.GroundPositionZ;
			global::Transform transform = global::Transform.Create();
			transform.SetLocation(location);
			transform.SetRotation(rotation.Quaternion(null));
			return transform;
		}

		// Token: 0x060452F4 RID: 283380 RVA: 0x0120F6B3 File Offset: 0x0120D8B3
		[NullableContext(2)]
		public global::Transform GetPlayerEntityTransform()
		{
			return this.BornTransform;
		}

		// Token: 0x060452F5 RID: 283381 RVA: 0x0120F6BC File Offset: 0x0120D8BC
		public void OnAddKscBar(AKSC_Shape2D_Entity_Bar kscBarEntity)
		{
			PinballBattlePlayerBarController pinballBattlePlayerBarController = new PinballBattlePlayerBarController();
			pinballBattlePlayerBarController.Init(kscBarEntity, this.GetModel());
			if (kscBarEntity.Side == EKSC_ShapeBarSide.Left)
			{
				this.KscEntityLeftBar = kscBarEntity;
				this.LeftBarController = pinballBattlePlayerBarController;
				return;
			}
			this.KscEntityRightBar = kscBarEntity;
			this.RightBarController = pinballBattlePlayerBarController;
		}

		// Token: 0x060452F6 RID: 283382 RVA: 0x0120F704 File Offset: 0x0120D904
		private void TempInitCamera(float? overrideFov = null)
		{
			PinballWorldConfig? worldConfigCache = this.GetModel().WorldConfigCache;
			if (worldConfigCache == null)
			{
				return;
			}
			PinballWorldConfig value = worldConfigCache.Value;
			Aki.Config.Vector value2 = value.CameraLocation.Value;
			Aki.Config.Vector value3 = value.CameraRotation.Value;
			global::Vector vector = global::Vector.Create();
			vector.X = this.WorldOrigin.X + (double)value2.X;
			vector.Y = this.WorldOrigin.Y + (double)value2.Y;
			vector.Z = this.WorldOrigin.Z + (double)value2.Z;
			global::Rotator rotation = global::Rotator.Create(value3.X, value3.Y, value3.Z);
			float num = overrideFov ?? ((float)value.CameraFov);
			this.BaseFov = num;
			this.EnterFixCamera(vector, rotation, num);
		}

		// Token: 0x060452F7 RID: 283383 RVA: 0x0120F7F8 File Offset: 0x0120D9F8
		protected override void OnInit()
		{
			base.OnInit();
			Singleton<Net>.Instance.Register<PinballStartNotify>(ENotifyMessageId.PinballStartNotify, new Action<PinballStartNotify, Net.CallbackStatus>(this.OnPinballStartNotify));
			Singleton<Net>.Instance.Register<PinballInGameStateChangeNotify>(ENotifyMessageId.PinballInGameStateChangeNotify, new Action<PinballInGameStateChangeNotify, Net.CallbackStatus>(this.OnPinballGameStateChangeNotify));
			Singleton<Net>.Instance.Register<PinballSettleNotify>(ENotifyMessageId.PinballSettleNotify, new Action<PinballSettleNotify, Net.CallbackStatus>(this.OnPinballSettleNotify));
			Singleton<Net>.Instance.Register<PinballInGameStarChangeNotify>(ENotifyMessageId.PinballInGameStarChangeNotify, new Action<PinballInGameStarChangeNotify, Net.CallbackStatus>(this.OnPinballInGameStarChangeNotify));
			Singleton<Net>.Instance.Register<PinballUpdateWaveNotify>(ENotifyMessageId.PinballUpdateWaveNotify, new Action<PinballUpdateWaveNotify, Net.CallbackStatus>(this.OnPinballUpdateWaveNotify));
			Singleton<Net>.Instance.Register<PinballSpawnFirstFinishNotify>(ENotifyMessageId.PinballSpawnFirstFinishNotify, new Action<PinballSpawnFirstFinishNotify, Net.CallbackStatus>(this.OnPinballSpawnFinishNotify));
			this.GetModel().FirstWaveMonsterTracker.OnAllSpawned = delegate()
			{
				this.FirstStartLaunch();
			};
			this.GetModel().CurWaveMachineTracker.OnAllSpawned = delegate()
			{
				this.OnAllCurWaveMachineSpawned();
			};
		}

		// Token: 0x060452F8 RID: 283384 RVA: 0x0120F8EC File Offset: 0x0120DAEC
		protected override void OnClear()
		{
			base.OnClear();
			Singleton<Net>.Instance.UnRegister(ENotifyMessageId.PinballStartNotify);
			Singleton<Net>.Instance.UnRegister(ENotifyMessageId.PinballInGameStateChangeNotify);
			Singleton<Net>.Instance.UnRegister(ENotifyMessageId.PinballSettleNotify);
			Singleton<Net>.Instance.UnRegister(ENotifyMessageId.PinballInGameStarChangeNotify);
			Singleton<Net>.Instance.UnRegister(ENotifyMessageId.PinballUpdateWaveNotify);
			Singleton<Net>.Instance.UnRegister(ENotifyMessageId.PinballSpawnFirstFinishNotify);
			this.GetModel().FirstWaveMonsterTracker.OnAllSpawned = null;
			this.GetModel().CurWaveMachineTracker.OnAllSpawned = null;
		}

		// Token: 0x060452F9 RID: 283385 RVA: 0x0120F981 File Offset: 0x0120DB81
		private void OnPinballSpawnFinishNotify(PinballSpawnFirstFinishNotify notify, [Nullable(2)] Net.CallbackStatus status)
		{
			if (notify.WaveId != 1)
			{
				return;
			}
			this.GetModel().FirstWaveMonsterTracker.MarkServerDone();
		}

		// Token: 0x060452FA RID: 283386 RVA: 0x0120F9A0 File Offset: 0x0120DBA0
		private void OnPinballStartNotify(PinballStartNotify notify, [Nullable(2)] Net.CallbackStatus status)
		{
			if (notify.InProgressPb != null)
			{
				this.GetModel().PreloadFormationData = new List<PinballFormationRolePb>(notify.InProgressPb.PinballFormation);
				ModelBase<PinballModel>.Instance.CurLevelConfigId = notify.InProgressPb.LevelId;
			}
			if (notify.RealLevelId != 0)
			{
				ModelBase<PinballModel>.Instance.CurLevelId = notify.RealLevelId;
			}
		}

		// Token: 0x060452FB RID: 283387 RVA: 0x0120FA00 File Offset: 0x0120DC00
		private void OnPinballUpdateWaveNotify(PinballUpdateWaveNotify notify, [Nullable(2)] Net.CallbackStatus status)
		{
			int waveId = notify.WaveId;
			this.GetModel().CurWave = waveId;
			this.GetModel().CurWaveMachineTracker.MarkServerDone();
		}

		// Token: 0x060452FC RID: 283388 RVA: 0x0120FA30 File Offset: 0x0120DC30
		private void OnPinballInGameStarChangeNotify(PinballInGameStarChangeNotify notify, [Nullable(2)] Net.CallbackStatus status)
		{
			RepeatedField<int> starInfo = notify.StarInfo;
			PinballBattleSubModel model = this.GetModel();
			for (int i = 0; i < starInfo.Count; i++)
			{
				model.StarInfo[i] = starInfo[i];
			}
		}

		// Token: 0x060452FD RID: 283389 RVA: 0x0120FA6C File Offset: 0x0120DC6C
		private void OnPinballGameStateChangeNotify(PinballInGameStateChangeNotify notify, [Nullable(2)] Net.CallbackStatus status)
		{
			PinballInGameStatePb inGameState = notify.InGameState;
			PinballBattleSubModel model = this.GetModel();
			model.GameState = (int)inGameState;
			if (inGameState == PinballInGameStatePb.InProgress)
			{
				PinballInProgressPb inProgressPb = notify.InProgressPb;
				model.LevelId = inProgressPb.LevelId;
				model.UsedReviveTime = inProgressPb.ReviveTimesCost;
				model.MaxReviveTime = inProgressPb.MaxReviveTimes;
				model.SetFormationData(new List<PinballFormationRolePb>(inProgressPb.PinballFormation));
				model.MonsterAttrRate[EKSC_AttrType.Atk] = (float)inProgressPb.MonsterAttrRate[0] * 0.0001f;
				model.MonsterAttrRate[EKSC_AttrType.Def] = (float)inProgressPb.MonsterAttrRate[1] * 0.0001f;
				model.MonsterAttrRate[EKSC_AttrType.Life] = (float)inProgressPb.MonsterAttrRate[2] * 0.0001f;
				model.TeamBuffList = new List<int>(inProgressPb.AllyKscBuffIds);
				this.SetFormationDataReady();
			}
			else if (inGameState == PinballInGameStatePb.SettlePreSubmit)
			{
				PinballSettlePreSubmitPb settlePreSubmitPb = notify.SettlePreSubmitPb;
				model.UsedReviveTime = settlePreSubmitPb.ReviveTimesCost;
				model.MaxReviveTime = settlePreSubmitPb.MaxReviveTimes;
			}
			if (inGameState == PinballInGameStatePb.InProgress)
			{
				this.StartScheduledSyncData();
			}
			else
			{
				this.StopAllTimerTask();
			}
			this.HandleGameStateChangeReason(notify.ChangeReason);
		}

		// Token: 0x060452FE RID: 283390 RVA: 0x0120FB8C File Offset: 0x0120DD8C
		private void HandleGameStateChangeReason(PinballStateChangeReasonPb reason)
		{
			PinballController instance = ControllerBase<PinballController>.Instance;
			switch (reason)
			{
			case PinballStateChangeReasonPb.SettlePreSubmitAllTeamDeadNoRevive:
				this.RequestSettle();
				return;
			case PinballStateChangeReasonPb.SettlePreSubmitAllTeamDeadHaveRevive:
			{
				PinballBattleRevivePopupViewParam param = new PinballBattleRevivePopupViewParam
				{
					ConfirmCallback = delegate
					{
						this.RequestTeamRevive();
					},
					CancelCallback = delegate
					{
						this.RequestSettle();
					}
				};
				Singleton<UiManager>.Instance.OpenView(EUiViewName.PinballRevivePopupView, param, null);
				return;
			}
			case PinballStateChangeReasonPb.SettlePreSubmitTimeZero:
				this.RequestSettle();
				return;
			case PinballStateChangeReasonPb.SettlePreSubmitWaveClear:
				this.RequestSettle();
				return;
			default:
				if (reason != PinballStateChangeReasonPb.InProgressFirstStart)
				{
					if (reason != PinballStateChangeReasonPb.InProgressAllTeamRevive)
					{
						return;
					}
					UKSC_Shape2D_World shapeWorld = this.ShapeWorld;
					if (shapeWorld != null)
					{
						shapeWorld.ReviveTeam();
					}
					this.NeedSendLaunchRequest = true;
				}
				else if (instance != null)
				{
					instance.ShowLevelStartTips(this.GetModel().CurWave, this.GetModel().GetMaxWave(), null);
					return;
				}
				return;
			}
		}

		// Token: 0x060452FF RID: 283391 RVA: 0x0120FC4A File Offset: 0x0120DE4A
		public void FirstStartLaunch()
		{
			this.ReadyLaunch();
			this.NeedSendLaunchRequest = true;
			this.IsFirstLaunch = true;
			this.StartAutoLaunchTimer();
		}

		// Token: 0x06045300 RID: 283392 RVA: 0x0120FC66 File Offset: 0x0120DE66
		private void OnPinballSettleNotify(PinballSettleNotify notify, [Nullable(2)] Net.CallbackStatus status)
		{
			this.OnPinballSettleAsync(notify).Forget();
		}

		// Token: 0x06045301 RID: 283393 RVA: 0x0120FC74 File Offset: 0x0120DE74
		private UniTask OnPinballSettleAsync(PinballSettleNotify notify)
		{
			PinballBattleSubController.<OnPinballSettleAsync>d__140 <OnPinballSettleAsync>d__;
			<OnPinballSettleAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnPinballSettleAsync>d__.<>4__this = this;
			<OnPinballSettleAsync>d__.notify = notify;
			<OnPinballSettleAsync>d__.<>1__state = -1;
			<OnPinballSettleAsync>d__.<>t__builder.Start<PinballBattleSubController.<OnPinballSettleAsync>d__140>(ref <OnPinballSettleAsync>d__);
			return <OnPinballSettleAsync>d__.<>t__builder.Task;
		}

		// Token: 0x06045302 RID: 283394 RVA: 0x0120FCBF File Offset: 0x0120DEBF
		private void OnCloseView(EUiViewName viewName, int viewId)
		{
			if (viewName != EUiViewName.PinballBattlePauseView)
			{
				return;
			}
			CustomPromise canOpenSettleResultPromise = this.CanOpenSettleResultPromise;
			if (canOpenSettleResultPromise == null)
			{
				return;
			}
			canOpenSettleResultPromise.SetResult();
		}

		// Token: 0x06045303 RID: 283395 RVA: 0x0120FCE0 File Offset: 0x0120DEE0
		private UniTask OpenSettleViewAsync(bool isWin, Action openSettleView)
		{
			PinballBattleSubController.<OpenSettleViewAsync>d__142 <OpenSettleViewAsync>d__;
			<OpenSettleViewAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OpenSettleViewAsync>d__.<>4__this = this;
			<OpenSettleViewAsync>d__.isWin = isWin;
			<OpenSettleViewAsync>d__.openSettleView = openSettleView;
			<OpenSettleViewAsync>d__.<>1__state = -1;
			<OpenSettleViewAsync>d__.<>t__builder.Start<PinballBattleSubController.<OpenSettleViewAsync>d__142>(ref <OpenSettleViewAsync>d__);
			return <OpenSettleViewAsync>d__.<>t__builder.Task;
		}

		// Token: 0x06045304 RID: 283396 RVA: 0x0120FD34 File Offset: 0x0120DF34
		public unsafe void RequestGameDataSync()
		{
			if (Singleton<Time>.Instance.Now - this.LastSyncRealTimeMs < 5000.0)
			{
				return;
			}
			this.LastSyncRealTimeMs = Singleton<Time>.Instance.Now;
			PinballInGameSyncPayloadRequest pinballInGameSyncPayloadRequest = PinballInGameSyncPayloadRequest.Create();
			pinballInGameSyncPayloadRequest.Payload = this.GetModel().GetPayloadData();
			Singleton<Net>.Instance.Call<PinballInGameSyncPayloadResponse>(ERequestMessageId.PinballInGameSyncPayloadRequest, pinballInGameSyncPayloadRequest, delegate(PinballInGameSyncPayloadResponse response, Net.CallbackStatus status)
			{
				if (response == null)
				{
					return;
				}
				if (response.ErrorCode != Aki.Protocol.ErrorCode.Success)
				{
					Log instance = Singleton<Log>.Instance;
					ELogModule module = ELogModule.PinballBattle;
					ELogAuthor author = ELogAuthor.LJ;
					string message = "战斗数据定时同步返回错误";
					<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
					*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("errorCode", response.ErrorCode);
					*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("messageId", 27876);
					instance.Warn(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
				}
			}, 0);
		}

		// Token: 0x06045305 RID: 283397 RVA: 0x0120FDB5 File Offset: 0x0120DFB5
		private void StartScheduledSyncData()
		{
			if (this.PayloadSyncTimerHandle != null)
			{
				return;
			}
			this.PayloadSyncTimerHandle = TimerSystem.GameplayTimeInstance.Forever(delegate(float _)
			{
				this.RequestGameDataSync();
			}, 10000f, 1f, null, null, true);
		}

		// Token: 0x06045306 RID: 283398 RVA: 0x0120FDE9 File Offset: 0x0120DFE9
		private void StopScheduledSyncData()
		{
			if (this.PayloadSyncTimerHandle == null)
			{
				return;
			}
			TimerSystem.GameplayTimeInstance.Remove(this.PayloadSyncTimerHandle);
			this.PayloadSyncTimerHandle = null;
		}

		// Token: 0x06045307 RID: 283399 RVA: 0x0120FE0C File Offset: 0x0120E00C
		private void StopAllTimerTask()
		{
			this.StopScheduledSyncData();
			this.StopAutoLaunchTimer();
		}

		// Token: 0x06045308 RID: 283400 RVA: 0x0120FE1C File Offset: 0x0120E01C
		public void RequestTeamAllDie()
		{
			PinballTeamDieRequest message = PinballTeamDieRequest.Create();
			Singleton<Net>.Instance.Call<PinballTeamDieResponse>(ERequestMessageId.PinballTeamDieRequest, message, delegate(PinballTeamDieResponse response, Net.CallbackStatus status)
			{
				if (response == null)
				{
					return;
				}
				if (response.ErrorCode != Aki.Protocol.ErrorCode.Success)
				{
					ControllerBase<ErrorCodeController>.Instance.OpenErrorCodeTipView(response.ErrorCode, 19073, null, true, true);
				}
			}, 0);
		}

		// Token: 0x06045309 RID: 283401 RVA: 0x0120FE60 File Offset: 0x0120E060
		public void RequestTeamRevive()
		{
			PinballTeamReviveRequest message = PinballTeamReviveRequest.Create();
			Singleton<Net>.Instance.Call<PinballTeamReviveResponse>(ERequestMessageId.PinballTeamReviveRequest, message, delegate(PinballTeamReviveResponse response, Net.CallbackStatus status)
			{
				if (response == null)
				{
					return;
				}
				if (response.ErrorCode != Aki.Protocol.ErrorCode.Success)
				{
					ControllerBase<ErrorCodeController>.Instance.OpenErrorCodeTipView(response.ErrorCode, 26851, null, true, true);
				}
			}, 0);
		}

		// Token: 0x0604530A RID: 283402 RVA: 0x0120FEA4 File Offset: 0x0120E0A4
		public void RequestQuit()
		{
			this.StopAllTimerTask();
			PinballQuitRequest pinballQuitRequest = PinballQuitRequest.Create();
			pinballQuitRequest.Payload = this.GetModel().GetPayloadData();
			pinballQuitRequest.NeedNotify = true;
			Singleton<Net>.Instance.Call<PinballQuitResponse>(ERequestMessageId.PinballQuitRequest, pinballQuitRequest, delegate(PinballQuitResponse response, Net.CallbackStatus status)
			{
				if (response == null)
				{
					return;
				}
				if (response.ErrCode != Aki.Protocol.ErrorCode.Success)
				{
					ControllerBase<ErrorCodeController>.Instance.OpenErrorCodeTipView(response.ErrCode, 23372, null, true, true);
				}
			}, 0);
		}

		// Token: 0x0604530B RID: 283403 RVA: 0x0120FF08 File Offset: 0x0120E108
		[NullableContext(2)]
		public UniTask Restart(List<int> roleIdList = null)
		{
			PinballBattleSubController.<Restart>d__150 <Restart>d__;
			<Restart>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<Restart>d__.<>4__this = this;
			<Restart>d__.roleIdList = roleIdList;
			<Restart>d__.<>1__state = -1;
			<Restart>d__.<>t__builder.Start<PinballBattleSubController.<Restart>d__150>(ref <Restart>d__);
			return <Restart>d__.<>t__builder.Task;
		}

		// Token: 0x0604530C RID: 283404 RVA: 0x0120FF54 File Offset: 0x0120E154
		public void RequestBonusFullWin()
		{
			this.StopAllTimerTask();
			PinballBonusFullWinRequest pinballBonusFullWinRequest = PinballBonusFullWinRequest.Create();
			pinballBonusFullWinRequest.Payload = this.GetModel().GetPayloadData();
			Singleton<Net>.Instance.Call<PinballBonusFullWinResponse>(ERequestMessageId.PinballBonusFullWinRequest, pinballBonusFullWinRequest, delegate(PinballBonusFullWinResponse response, Net.CallbackStatus status)
			{
				if (response == null)
				{
					return;
				}
				if (response.ErrCode != Aki.Protocol.ErrorCode.Success)
				{
					ControllerBase<ErrorCodeController>.Instance.OpenErrorCodeTipView(response.ErrCode, 28773, null, true, true);
				}
			}, 0);
		}

		// Token: 0x0604530D RID: 283405 RVA: 0x0120FFB0 File Offset: 0x0120E1B0
		public void RequestSettle()
		{
			this.StopAllTimerTask();
			PinballSetPayloadRequest pinballSetPayloadRequest = PinballSetPayloadRequest.Create();
			pinballSetPayloadRequest.Payload = this.GetModel().GetPayloadData();
			Singleton<Net>.Instance.Call<PinballSetPayloadResponse>(ERequestMessageId.PinballSetPayloadRequest, pinballSetPayloadRequest, delegate(PinballSetPayloadResponse response, Net.CallbackStatus status)
			{
				if (response == null)
				{
					return;
				}
				if (response.ErrorCode != Aki.Protocol.ErrorCode.Success)
				{
					ControllerBase<ErrorCodeController>.Instance.OpenErrorCodeTipView(response.ErrorCode, 15536, null, true, true);
				}
			}, 0);
		}

		// Token: 0x0604530E RID: 283406 RVA: 0x0121000A File Offset: 0x0120E20A
		private void OnBlackFadeScreenFinish()
		{
			CustomPromise canRequestSettlePromise = this.CanRequestSettlePromise;
			if (canRequestSettlePromise == null)
			{
				return;
			}
			canRequestSettlePromise.SetResult();
		}

		// Token: 0x0604530F RID: 283407 RVA: 0x0121001C File Offset: 0x0120E21C
		private void RequestLaunch()
		{
			PinballInGameKickBallRequest message = PinballInGameKickBallRequest.Create();
			Singleton<Net>.Instance.Call<PinballInGameKickBallResponse>(ERequestMessageId.PinballInGameKickBallRequest, message, delegate(PinballInGameKickBallResponse response, Net.CallbackStatus status)
			{
				if (response == null)
				{
					return;
				}
				if (response.ErrorCode != Aki.Protocol.ErrorCode.Success)
				{
					ControllerBase<ErrorCodeController>.Instance.OpenErrorCodeTipView(response.ErrorCode, 27431, null, true, true);
				}
			}, 0);
		}

		// Token: 0x06045310 RID: 283408 RVA: 0x0121005F File Offset: 0x0120E25F
		private void OnScoreChanged(int score)
		{
			if (this.AlreadyRequestBonusWin)
			{
				return;
			}
			if (this.GetModel().CheckBonusFullWin())
			{
				this.AlreadyRequestBonusWin = true;
				this.RequestBonusFullWin();
			}
		}

		// Token: 0x06045311 RID: 283409 RVA: 0x01210084 File Offset: 0x0120E284
		public static void RequestEnterInst(int levelId, List<int> roleIdList)
		{
			PinballCtx pinballCtx = PinballCtx.Create();
			PinballLevelConfig? pinballLevelConfigById = ConfigBase<PinballConfig>.Instance.GetPinballLevelConfigById(levelId);
			if (pinballLevelConfigById == null)
			{
				KscLog.EModule flag = KscLog.EModule.Common;
				ELogAuthor author = ELogAuthor.LJ;
				UObject kscWorld = Singleton<KscEnv>.Instance.KscWorld;
				string log = "[星弹奇游]副本进入请求异常：关卡配置为空";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("levelId", levelId);
				KscLog.Error(flag, author, kscWorld, log, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
				return;
			}
			foreach (int num in roleIdList)
			{
				if (ConfigBase<PinballConfig>.Instance.GetPinballRoleConfigById(num) == null)
				{
					KscLog.EModule flag2 = KscLog.EModule.Common;
					ELogAuthor author2 = ELogAuthor.LJ;
					UObject kscWorld2 = Singleton<KscEnv>.Instance.KscWorld;
					string log2 = "[星弹奇游]副本进入请求异常：角色配置为空";
					ValueTuple<string, object> valueTuple2 = new ValueTuple<string, object>("roleId", num);
					KscLog.Error(flag2, author2, kscWorld2, log2, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple2));
					return;
				}
			}
			pinballCtx.LevelId = levelId;
			foreach (int item in roleIdList)
			{
				pinballCtx.FormationRoles.Add(item);
			}
			ModelBase<InstanceDungeonModel>.Instance.InstanceEnterContentText.PinballCtx = pinballCtx;
			int instId = pinballLevelConfigById.Value.InstId;
			if (pinballLevelConfigById.Value.Type == 4)
			{
				int dailyRandomLevelId = ModelBase<PinballModel>.Instance.ActivityData.GetDailyRandomLevelId();
				if (dailyRandomLevelId > 0)
				{
					instId = ConfigBase<PinballConfig>.Instance.GetPinballLevelConfigById(dailyRandomLevelId).Value.InstId;
				}
			}
			ControllerBase<InstanceDungeonController>.Instance.PrewarTeamFightRequest(instId, new List<int>(), 0, 0, null, null).Forget<bool>();
		}

		// Token: 0x06045312 RID: 283410 RVA: 0x01210234 File Offset: 0x0120E434
		protected override void OnHandleHeadHpInfo(FKSC_HeadHpContext headInfo)
		{
			bool flag = headInfo.HeadUiType == EKSC_HeadUiType.TopBoss;
			bool flag2 = headInfo.HeadUiType == EKSC_HeadUiType.Marble;
			if (!flag && !flag2)
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.PinballBattle;
				ELogAuthor author = ELogAuthor.LJ;
				DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(32, 1);
				defaultInterpolatedStringHandler.AppendLiteral("未处理的KSC头部UI数据！EKSC_HeadUiType = ");
				defaultInterpolatedStringHandler.AppendFormatted<EKSC_HeadUiType>(headInfo.HeadUiType);
				instance.Warn(module, author, defaultInterpolatedStringHandler.ToStringAndClear(), default(ReadOnlySpan<ValueTuple<string, object>>));
				return;
			}
			if (flag)
			{
				Singleton<EventSystem>.Instance.Emit<FKSC_HeadHpContext>(EEventName.OnPinballEntityHpChanged, headInfo);
			}
			if (flag2)
			{
				PinballBattleHeadStateManager pinballBattleHeadStateManager = this.GetModel().PinballBattleHeadStateManager;
				if (pinballBattleHeadStateManager == null)
				{
					return;
				}
				pinballBattleHeadStateManager.UpdateHeadState(headInfo);
			}
		}

		// Token: 0x06045313 RID: 283411 RVA: 0x012102CD File Offset: 0x0120E4CD
		protected override void OnHandlePlayerHeadHpInfo(KscHeadStateData kscPlayerHeadStateData, FKSC_HeadHpContext headInfo)
		{
			base.OnHandlePlayerHeadHpInfo(kscPlayerHeadStateData, headInfo);
			this.PlayerHpHandle.OnPlayerHpChange(kscPlayerHeadStateData);
			this.OnHandleHeadHpInfo(headInfo);
		}

		// Token: 0x06045314 RID: 283412 RVA: 0x012102EC File Offset: 0x0120E4EC
		protected override UniTask LoadHeadStateCurve()
		{
			PinballBattleSubController.<LoadHeadStateCurve>d__159 <LoadHeadStateCurve>d__;
			<LoadHeadStateCurve>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<LoadHeadStateCurve>d__.<>4__this = this;
			<LoadHeadStateCurve>d__.<>1__state = -1;
			<LoadHeadStateCurve>d__.<>t__builder.Start<PinballBattleSubController.<LoadHeadStateCurve>d__159>(ref <LoadHeadStateCurve>d__);
			return <LoadHeadStateCurve>d__.<>t__builder.Task;
		}

		// Token: 0x06045315 RID: 283413 RVA: 0x01210330 File Offset: 0x0120E530
		protected override UniTask LoadHeadStateDynamicBatchActor()
		{
			PinballBattleSubController.<LoadHeadStateDynamicBatchActor>d__160 <LoadHeadStateDynamicBatchActor>d__;
			<LoadHeadStateDynamicBatchActor>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<LoadHeadStateDynamicBatchActor>d__.<>4__this = this;
			<LoadHeadStateDynamicBatchActor>d__.<>1__state = -1;
			<LoadHeadStateDynamicBatchActor>d__.<>t__builder.Start<PinballBattleSubController.<LoadHeadStateDynamicBatchActor>d__160>(ref <LoadHeadStateDynamicBatchActor>d__);
			return <LoadHeadStateDynamicBatchActor>d__.<>t__builder.Task;
		}

		// Token: 0x06045316 RID: 283414 RVA: 0x01210374 File Offset: 0x0120E574
		protected override UniTask LoadHeadStateViewActor()
		{
			PinballBattleSubController.<LoadHeadStateViewActor>d__161 <LoadHeadStateViewActor>d__;
			<LoadHeadStateViewActor>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<LoadHeadStateViewActor>d__.<>4__this = this;
			<LoadHeadStateViewActor>d__.<>1__state = -1;
			<LoadHeadStateViewActor>d__.<>t__builder.Start<PinballBattleSubController.<LoadHeadStateViewActor>d__161>(ref <LoadHeadStateViewActor>d__);
			return <LoadHeadStateViewActor>d__.<>t__builder.Task;
		}

		// Token: 0x06045317 RID: 283415 RVA: 0x012103B7 File Offset: 0x0120E5B7
		public void OnInputTriggerBar()
		{
			PinballBattleLaunchPhaseController launchPhaseController = this.LaunchPhaseController;
			if (launchPhaseController != null && launchPhaseController.IsActive())
			{
				this.LaunchBall();
				return;
			}
			AKSC_Shape2D_Entity_Bar kscEntityLeftBar = this.KscEntityLeftBar;
			if (kscEntityLeftBar != null)
			{
				kscEntityLeftBar.TriggerBar();
			}
			AKSC_Shape2D_Entity_Bar kscEntityRightBar = this.KscEntityRightBar;
			if (kscEntityRightBar == null)
			{
				return;
			}
			kscEntityRightBar.TriggerBar();
		}

		// Token: 0x06045318 RID: 283416 RVA: 0x012103F8 File Offset: 0x0120E5F8
		public void OnInputRebuildBounds()
		{
			UKSC_DA_Shape2D_WorldBounds shapeWorldBoundsDa = this.GetModel().ShapeWorldBoundsDa;
			if (shapeWorldBoundsDa != null)
			{
				UKSC_Shape2D_World shapeWorld = this.ShapeWorld;
				if (shapeWorld == null)
				{
					return;
				}
				shapeWorld.RebuildWorldBounds(shapeWorldBoundsDa);
			}
		}

		// Token: 0x06045319 RID: 283417 RVA: 0x01210428 File Offset: 0x0120E628
		public void OnInputResetPlayerPosition()
		{
			UKSC_Shape2D_World shapeWorld = this.ShapeWorld;
			AKSC_Shape2D_Entity_Player aksc_Shape2D_Entity_Player = (shapeWorld != null) ? shapeWorld.TeamPlayerEntities.Get(0) : null;
			if (aksc_Shape2D_Entity_Player != null)
			{
				AKSC_Shape2D_Entity_Player aksc_Shape2D_Entity_Player2 = aksc_Shape2D_Entity_Player;
				FTransform ftransform = this.BornTransform.ToUeTransformOld();
				aksc_Shape2D_Entity_Player2.SetEntityTransformDebug(ftransform);
			}
		}

		// Token: 0x0604531A RID: 283418 RVA: 0x01210468 File Offset: 0x0120E668
		public bool OnInputUseSkill(int roleIndex, int skillIndex = 0)
		{
			if (roleIndex < this.KscPlayerEntities.Length)
			{
				AKSC_Shape2D_Entity_Player aksc_Shape2D_Entity_Player = this.KscPlayerEntities[roleIndex];
				if (aksc_Shape2D_Entity_Player != null && aksc_Shape2D_Entity_Player.IsPlayerAlive)
				{
					aksc_Shape2D_Entity_Player.UseSkill(skillIndex);
					Singleton<EventSystem>.Instance.Emit<int>(EEventName.OnPinballRoleUseSkill, this.GetModel().GetRoleIdByEntityId(aksc_Shape2D_Entity_Player.EntityId_).GetValueOrDefault());
					return true;
				}
			}
			return false;
		}

		// Token: 0x0604531B RID: 283419 RVA: 0x012104C7 File Offset: 0x0120E6C7
		public void OnInputUseTeamSkill(int skillIndex)
		{
			if (this.KscTeamPlayer != null)
			{
				this.KscTeamPlayer.UseSkill(skillIndex, true);
			}
		}

		// Token: 0x0604531C RID: 283420 RVA: 0x012104DE File Offset: 0x0120E6DE
		protected int GetCreatureSpawnId()
		{
			this.CreatureIdCounter++;
			return this.CreatureIdCounter;
		}

		// Token: 0x0604531D RID: 283421 RVA: 0x012104F4 File Offset: 0x0120E6F4
		private void OnKscEntitySummon(FTransformDouble ueOwnerTransform, in TArray<FKSC_SpawnEntity> contexts, int summonerEntityId)
		{
			int num = contexts.Num();
			for (int i = 0; i < num; i++)
			{
				FKSC_SpawnEntity fksc_SpawnEntity = contexts.Get(i);
				FTransformDouble transform;
				if (fksc_SpawnEntity.IsUseAbsoluteTrans)
				{
					FTransformDouble entityTrans = fksc_SpawnEntity.EntityTrans;
					FTransformDouble ftransformDouble = this.WorldOriginTransform.ToUeTransform();
					transform = UKismetMathLibrary.D_ComposeTransforms(entityTrans, ftransformDouble);
				}
				else
				{
					FTransformDouble entityTrans = fksc_SpawnEntity.EntityTrans;
					transform = UKismetMathLibrary.D_ComposeTransforms(entityTrans, ueOwnerTransform);
				}
				this.SpawnEntityById(this.GetCreatureSpawnId(), fksc_SpawnEntity.EntityId, transform, new int?(summonerEntityId));
			}
		}

		// Token: 0x0604531E RID: 283422 RVA: 0x01210573 File Offset: 0x0120E773
		private void OnRelaunchPlayer()
		{
			this.ReadyLaunch();
		}

		// Token: 0x0604531F RID: 283423 RVA: 0x0121057B File Offset: 0x0120E77B
		private void OnTeamAllDead()
		{
			this.RequestTeamAllDie();
		}

		// Token: 0x06045320 RID: 283424 RVA: 0x01210584 File Offset: 0x0120E784
		private void OnWorldUpdateOnce()
		{
			if (!Singleton<Info>.Instance.IsBuildShipping && this.ShapeWorld != null)
			{
				this.ShapeWorld.Entities_.Num();
				int num = this.ShapeWorld.ToAddEntities_.Num();
				if (num > 0)
				{
					for (int i = 0; i < num; i++)
					{
						this.ShapeWorld.ToAddEntities_.Get(i);
					}
				}
			}
			List<PinballFormationRolePb> list = this.GetModel().FormationData ?? new List<PinballFormationRolePb>();
			for (int j = 0; j < this.KscPlayerEntities.Length; j++)
			{
				AKSC_Shape2D_Entity_Player kscPlayer = this.KscPlayerEntities[j];
				PinballFormationRolePb pinballFormationRolePb = (list.Count > j) ? list[j] : null;
				if (pinballFormationRolePb != null)
				{
					this.InitPlayerEntityAttrAndBuffs(kscPlayer, pinballFormationRolePb);
				}
			}
			if (this.WorldUpdateOnceDelegateRef != null)
			{
				global::DelegateUtils.ReleaseManualReleaseDelegate(new Action(this.OnWorldUpdateOnce));
				this.WorldUpdateOnceDelegateRef = null;
			}
		}

		// Token: 0x06045321 RID: 283425 RVA: 0x01210660 File Offset: 0x0120E860
		private void InitPlayerEntityAttrAndBuffs(AKSC_Shape2D_Entity_Player kscPlayer, PinballFormationRolePb roleData)
		{
			PinballBattleSubModel model = this.GetModel();
			TMap<EKSC_AttrType, int> attrs_ = kscPlayer.GetSkillComp().AttrSet_.Attrs_;
			Dictionary<EKSC_AttrType, int> defaultAttrs = model.GetDefaultAttrs(attrs_);
			HashSet<int> valueOrDefault = model.RoleBornBuffsMap.GetValueOrDefault(roleData.RoleId);
			if (valueOrDefault != null)
			{
				foreach (int key in valueOrDefault)
				{
					UKSC_DA_Buff daBuff;
					if (model.LoadedBuffDaMap.TryGetValue(key, out daBuff))
					{
						kscPlayer.ApplyBuffSelf(daBuff);
					}
				}
			}
			List<int> teamBuffList = model.TeamBuffList;
			if (teamBuffList != null)
			{
				foreach (int key2 in teamBuffList)
				{
					UKSC_DA_Buff daBuff2;
					if (model.LoadedBuffDaMap.TryGetValue(key2, out daBuff2))
					{
						kscPlayer.ApplyBuffSelf(daBuff2);
					}
				}
			}
			Dictionary<EKSC_AttrType, float> dictionary = new Dictionary<EKSC_AttrType, float>();
			this.GetModel().GetRoleBornAttrs(roleData, dictionary);
			foreach (KeyValuePair<EKSC_AttrType, int> keyValuePair in attrs_)
			{
				EKSC_AttrType eksc_AttrType;
				int num;
				keyValuePair.Deconstruct(out eksc_AttrType, out num);
				EKSC_AttrType key3 = eksc_AttrType;
				int num2 = num;
				int valueOrDefault2 = defaultAttrs.GetValueOrDefault(key3, 0);
				int num3 = num2 - valueOrDefault2;
				if (num3 != 0)
				{
					dictionary[key3] = dictionary.GetValueOrDefault(key3, 0f) + (float)num3;
				}
			}
			float num4 = dictionary.GetValueOrDefault(EKSC_AttrType.LifeMax, 0f);
			if (num4 > 0f)
			{
				float valueOrDefault3 = dictionary.GetValueOrDefault(EKSC_AttrType.LifeChange, 0f);
				float valueOrDefault4 = dictionary.GetValueOrDefault(EKSC_AttrType.LifeExtra, 0f);
				num4 = (float)Math.Ceiling((double)(num4 * (1f + valueOrDefault3 * 0.0001f) + valueOrDefault4));
				dictionary[EKSC_AttrType.LifeMax] = num4;
				dictionary[EKSC_AttrType.Life] = num4;
				dictionary[EKSC_AttrType.BaseLife] = num4;
			}
			foreach (KeyValuePair<EKSC_AttrType, float> keyValuePair2 in dictionary)
			{
				kscPlayer.SetAttr(keyValuePair2.Key, (int)keyValuePair2.Value);
			}
			this.GetModel().SetRoleBaseAttrsRecord(roleData, dictionary);
		}

		// Token: 0x06045322 RID: 283426 RVA: 0x012108B0 File Offset: 0x0120EAB0
		protected bool SpawnEntityById(int creatureId, int configId, FTransformDouble transform, int? summonerEntityId = null)
		{
			PinballCreature? creatureConfig = ConfigBase<PinballBattleConfig>.Instance.GetCreatureConfigById(configId);
			if (creatureConfig == null)
			{
				KscLog.EModule flag = KscLog.EModule.Common;
				ELogAuthor author = ELogAuthor.WWJ;
				UObject kscWorld = Singleton<KscEnv>.Instance.KscWorld;
				string log = "[弹球玩法]实体配置不存在";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("creatureConfig", creatureConfig);
				KscLog.Error(flag, author, kscWorld, log, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
				return false;
			}
			int kscEntityId = creatureConfig.Value.KscEntityId;
			string entityPathById = ControllerBase<KuroSimpleCombatController>.Instance.CurSubModel.GetEntityPathById(kscEntityId);
			if (string.IsNullOrEmpty(entityPathById))
			{
				KscLog.EModule flag2 = KscLog.EModule.Common;
				ELogAuthor author2 = ELogAuthor.WWJ;
				UObject kscWorld2 = Singleton<KscEnv>.Instance.KscWorld;
				string log2 = "[弹球玩法]实体资产路径不存在";
				ValueTuple<string, object> valueTuple2 = new ValueTuple<string, object>("simpleCombatId", kscEntityId);
				KscLog.Error(flag2, author2, kscWorld2, log2, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple2));
				return false;
			}
			Dictionary<int, int> dictionary = null;
			if (summonerEntityId != null && creatureConfig.Value.SummonLifeInherit > 0)
			{
				KscEntityHandle kscEntityHandle;
				AKSC_Entity aksc_Entity = this.GetModel().KscEntities.TryGetValue(summonerEntityId.Value, out kscEntityHandle) ? ((kscEntityHandle != null) ? kscEntityHandle.KscEntity : null) : null;
				TMap<EKSC_AttrType, int> tmap;
				if (aksc_Entity == null)
				{
					tmap = null;
				}
				else
				{
					UKSC_SkillComp skillComp = aksc_Entity.GetSkillComp();
					if (skillComp == null)
					{
						tmap = null;
					}
					else
					{
						UKSC_AttrSet attrSet_ = skillComp.AttrSet_;
						tmap = ((attrSet_ != null) ? attrSet_.Attrs_ : null);
					}
				}
				TMap<EKSC_AttrType, int> tmap2 = tmap;
				if (tmap2 != null)
				{
					dictionary = new Dictionary<int, int>();
					float valueOrDefault = (float)tmap2.GetValueOrDefault(EKSC_AttrType.LifeMax, 0);
					float num = (float)creatureConfig.Value.SummonLifeInherit * 0.0001f;
					float num2 = (float)Math.Ceiling((double)(valueOrDefault * num));
					if (num2 > 0f)
					{
						dictionary[2] = (int)num2;
						dictionary[3] = (int)num2;
						dictionary[13] = (int)num2;
					}
				}
			}
			ControllerBase<KuroSimpleCombatController>.Instance.AsyncAddEntity(new KscEntityParam
			{
				CreatureId = (long)creatureId,
				SimpleCombatId = kscEntityId,
				AssetPath = entityPathById,
				PropertyId = creatureConfig.Value.AttrId,
				Transform = transform,
				Buffs = KscUtil.ToBuffParam(creatureConfig.Value.GetBornBuffArray(), null),
				AttributeMap = dictionary,
				FinishCallback = delegate(AKSC_Entity kscEntity)
				{
					UKSC_DA_Buff daBuff;
					if (summonerEntityId != null && creatureConfig.Value.SummonBuffId != 0 && this.GetModel().LoadedBuffDaMap.TryGetValue(creatureConfig.Value.SummonBuffId, out daBuff))
					{
						kscEntity.ApplyBuffByOther(daBuff, summonerEntityId.Value);
					}
					this.SetSpineCompTickEnabled(kscEntity, true);
				}
			});
			return true;
		}

		// Token: 0x06045323 RID: 283427 RVA: 0x01210AF0 File Offset: 0x0120ECF0
		private void RefreshCameraFov()
		{
			SceneCamera sceneCamera = ControllerBase<CameraController>.Instance.MainModel.SceneCamera;
			UCineCameraComponent ucineCameraComponent;
			if (sceneCamera == null)
			{
				ucineCameraComponent = null;
			}
			else
			{
				SceneCameraDisplayComponent displayComponent = sceneCamera.DisplayComponent;
				if (displayComponent == null)
				{
					ucineCameraComponent = null;
				}
				else
				{
					SceneSubCamera curSceneSubCamera = displayComponent.CurSceneSubCamera;
					if (curSceneSubCamera == null)
					{
						ucineCameraComponent = null;
					}
					else
					{
						BP_CineCamera_C camera = curSceneSubCamera.Camera;
						ucineCameraComponent = ((camera != null) ? camera.GetCineCameraComponent() : null);
					}
				}
			}
			UCineCameraComponent ucineCameraComponent2 = ucineCameraComponent;
			if (ucineCameraComponent2 == null)
			{
				return;
			}
			float fieldOfView = this.AdjustCameraFovByScreenHeight(this.BaseFov);
			ucineCameraComponent2.SetFieldOfView(fieldOfView);
		}

		// Token: 0x06045324 RID: 283428 RVA: 0x01210B58 File Offset: 0x0120ED58
		public float AdjustCameraFovByScreenHeight(float baseFov)
		{
			TsCharacterController characterController = Global.CharacterController;
			if (characterController != null)
			{
				int num = 0;
				int num2 = 0;
				characterController.GetViewportSize(ref num, ref num2);
				float num3 = (float)num / (float)num2;
				float num4 = MathCommon.DegreeToRadian(baseFov);
				float val = MathCommon.RadianToDegree(2f * (float)Math.Atan((double)(1.7777778f / num3) * Math.Tan((double)(num4 / 2f))));
				return Math.Max(baseFov, val);
			}
			return baseFov;
		}

		// Token: 0x06045325 RID: 283429 RVA: 0x01210BC0 File Offset: 0x0120EDC0
		private void InitBackgroundMaterial()
		{
			TArray<AActor> tarray = new TArray<AActor>();
			UGameplayStatics.GetAllActorsOfClassWithTag(GlobalData.World, AStaticMeshActor.StaticClass(), FNameUtil.GetDynamicFName("Background").Value, ref tarray);
			if (tarray.Num() == 0)
			{
				return;
			}
			AStaticMeshActor astaticMeshActor = tarray.Get(0) as AStaticMeshActor;
			UStaticMeshComponent ustaticMeshComponent = (astaticMeshActor != null) ? astaticMeshActor.StaticMeshComponent : null;
			UMaterialInterface sourceMaterial = (ustaticMeshComponent != null) ? ustaticMeshComponent.GetMaterial(0) : null;
			this.BgDynamicMat = ((ustaticMeshComponent != null) ? ustaticMeshComponent.CreateDynamicMaterialInstance(0, sourceMaterial, default(FName)) : null);
			int curLevelId = ModelBase<PinballModel>.Instance.CurLevelId;
			if (curLevelId != 0)
			{
				PinballLevelConfig? pinballLevelConfigById = ConfigBase<PinballConfig>.Instance.GetPinballLevelConfigById(curLevelId);
				if (pinballLevelConfigById == null)
				{
					return;
				}
				this.ChangeBackground(pinballLevelConfigById.Value.LevelBg);
			}
		}

		// Token: 0x06045326 RID: 283430 RVA: 0x01210C88 File Offset: 0x0120EE88
		private void ChangeBackground(string texturePath)
		{
			if (string.IsNullOrEmpty(texturePath))
			{
				return;
			}
			UTexture value = Singleton<ResourceSystem>.Instance.Load<UTexture>(texturePath, "js_undefined");
			UMaterialInstanceDynamic bgDynamicMat = this.BgDynamicMat;
			if (bgDynamicMat == null)
			{
				return;
			}
			bgDynamicMat.SetTextureParameterValue(FNameUtil.GetDynamicFName("Background").Value, value);
		}

		// Token: 0x06045327 RID: 283431 RVA: 0x01210CD4 File Offset: 0x0120EED4
		private void UpdateCombo()
		{
			if (this.ShapeWorld == null)
			{
				return;
			}
			int worldAttr = this.ShapeWorld.GetWorldAttr(EKSC_WorldAttrType.Combo);
			PinballBattleSubModel model = this.GetModel();
			if (model == null)
			{
				return;
			}
			model.SetCombo(worldAttr);
		}

		// Token: 0x06045328 RID: 283432 RVA: 0x01210D08 File Offset: 0x0120EF08
		private void UpdateDamageInfo()
		{
			if (this.ShapeWorld == null)
			{
				return;
			}
			if (this.DamageInfo == null)
			{
				this.DamageInfo = new TMap<int, int>();
			}
			this.ShapeWorld.GetDamageInfo(ref this.DamageInfo);
			this.GetModel().UpdateDamageInfo(this.DamageInfo);
		}

		// Token: 0x06045329 RID: 283433 RVA: 0x01210D48 File Offset: 0x0120EF48
		public void CreateLaunchController()
		{
			global::Vector vector = global::Vector.Create(this.WorldOrigin);
			vector.Z = (double)this.GroundPositionZ;
			PinballBattleSubModel model = this.GetModel();
			PinballWorldConfig? pinballWorldConfig = (model != null) ? model.WorldConfigCache : null;
			if (pinballWorldConfig != null)
			{
				vector.Y += (double)pinballWorldConfig.Value.LaunchSplineYOffset;
			}
			UiPanelBase launchBallItem = this.LaunchBallItem;
			if (launchBallItem != null)
			{
				launchBallItem.Show(null);
			}
			AActor rootActor = this.LaunchBallItem.GetRootActor();
			FHitResult fhitResult = new FHitResult();
			rootActor.D_K2_SetActorLocation(vector.ToUeVector(false), false, ref fhitResult, false);
			this.LaunchPhaseController = new PinballBattleLaunchPhaseController();
			this.LaunchPhaseController.SetupSplineMotion(rootActor, 319850000, this.LaunchSpeedCurve, this.LaunchDegCurve);
		}

		// Token: 0x0604532A RID: 283434 RVA: 0x01210E0F File Offset: 0x0120F00F
		public void ReadyLaunch()
		{
			this.SetAllPlayerEntityActive(false, true);
			PinballBattleLaunchPhaseController launchPhaseController = this.LaunchPhaseController;
			if (launchPhaseController == null)
			{
				return;
			}
			launchPhaseController.StartSplineMotion();
		}

		// Token: 0x0604532B RID: 283435 RVA: 0x01210E2C File Offset: 0x0120F02C
		public void LaunchBall()
		{
			PinballBattleLaunchPhaseController launchPhaseController = this.LaunchPhaseController;
			if (launchPhaseController == null || !launchPhaseController.IsActive())
			{
				return;
			}
			UKSC_Shape2D_World shapeWorld = this.ShapeWorld;
			AKSC_Shape2D_Entity_Player aksc_Shape2D_Entity_Player = (shapeWorld != null) ? shapeWorld.TeamPlayerEntities.Get(0) : null;
			if (aksc_Shape2D_Entity_Player == null)
			{
				return;
			}
			this.SetAllPlayerEntityActive(true, true);
			FVector value = this.LaunchPhaseController.GetCurrentActorPosition().Value;
			float currentAngle = this.LaunchPhaseController.GetCurrentAngle();
			UKSC_DA_Shape2D_World shapeWorldDa = this.GetModel().ShapeWorldDa;
			float launchSpeed = (shapeWorldDa != null) ? shapeWorldDa.LaunchSpeed : 0f;
			UKSC_Shape2DMove uksc_Shape2DMove = aksc_Shape2D_Entity_Player.GetMoveComponent() as UKSC_Shape2DMove;
			global::Transform transform = global::Transform.Create();
			transform.SetLocation(value);
			foreach (AKSC_Shape2D_Entity_Player aksc_Shape2D_Entity_Player2 in this.KscPlayerEntities)
			{
				if (aksc_Shape2D_Entity_Player2 != null && aksc_Shape2D_Entity_Player2.IsPlayerAlive)
				{
					AKSC_Entity aksc_Entity = aksc_Shape2D_Entity_Player2;
					FTransformDouble ftransformDouble = transform.ToUeTransform();
					aksc_Entity.SetTransformByWorld(ftransformDouble);
				}
			}
			FVector2D rotated = new FVector2D(0f, 1f).GetRotated(currentAngle);
			if (uksc_Shape2DMove != null)
			{
				uksc_Shape2DMove.Launch(launchSpeed, rotated, false, false);
			}
			this.LaunchPhaseController.StopSplineMotion();
			if (this.NeedSendLaunchRequest)
			{
				this.NeedSendLaunchRequest = false;
				this.RequestLaunch();
			}
			if (this.IsFirstLaunch)
			{
				Singleton<EventSystem>.Instance.Emit(EEventName.OnPinballFirstLaunch);
			}
			this.IsFirstLaunch = false;
			this.StopAutoLaunchTimer();
		}

		// Token: 0x0604532C RID: 283436 RVA: 0x01210F88 File Offset: 0x0120F188
		public void SetAllPlayerEntityActive(bool active, bool checkIsAlive = true)
		{
			foreach (AKSC_Shape2D_Entity_Player aksc_Shape2D_Entity_Player in this.KscPlayerEntities)
			{
				if (aksc_Shape2D_Entity_Player != null)
				{
					this.SetPlayerEntityActive(aksc_Shape2D_Entity_Player, active, checkIsAlive);
				}
			}
		}

		// Token: 0x0604532D RID: 283437 RVA: 0x01210FBA File Offset: 0x0120F1BA
		public void SetPlayerEntityActive(AKSC_Shape2D_Entity_Player entity, bool active, bool checkIsAlive = true)
		{
			if (checkIsAlive && !entity.IsPlayerAlive)
			{
				return;
			}
			entity.SetEntityActive(active);
			entity.SetActorHiddenInGame(!active);
			if (!active)
			{
				entity.SetLocationByWorld(this.EntityHidePosition);
			}
		}

		// Token: 0x0604532E RID: 283438 RVA: 0x01210FEC File Offset: 0x0120F1EC
		[return: Nullable(new byte[]
		{
			0,
			2
		})]
		private UniTask<UCurveFloat> LoadCurveAsync(string path)
		{
			PinballBattleSubController.<LoadCurveAsync>d__187 <LoadCurveAsync>d__;
			<LoadCurveAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder<UCurveFloat>.Create();
			<LoadCurveAsync>d__.path = path;
			<LoadCurveAsync>d__.<>1__state = -1;
			<LoadCurveAsync>d__.<>t__builder.Start<PinballBattleSubController.<LoadCurveAsync>d__187>(ref <LoadCurveAsync>d__);
			return <LoadCurveAsync>d__.<>t__builder.Task;
		}

		// Token: 0x0604532F RID: 283439 RVA: 0x01211030 File Offset: 0x0120F230
		private void InitFeverBar()
		{
			global::Transform transform = global::Transform.Create(this.WorldOriginTransform.ToUeTransform());
			PinballWorldConfig? worldConfigCache = this.GetModel().WorldConfigCache;
			float dissolveMin = 0f;
			float dissolveMax = 1f;
			if (worldConfigCache != null)
			{
				global::Vector location = transform.GetLocation();
				location.Y += (double)worldConfigCache.Value.FeverBarYOffset;
				transform.SetLocation(location);
				if (worldConfigCache.Value.FeverBarDissolveRangeLength > 1)
				{
					dissolveMin = worldConfigCache.Value.FeverBarDissolveRange(0);
					dissolveMax = worldConfigCache.Value.FeverBarDissolveRange(1);
				}
			}
			this.FeverBar = Singleton<ActorSystem>.Instance.Spawn<BP_Fever_Bar_C>(BP_Fever_Bar_C.StaticClass(), transform.ToUeTransform(), null);
			this.FeverBarController = new PinballBattleFeverBarController();
			this.FeverBarController.Init(this.FeverBar, dissolveMin, dissolveMax, this.FeverBarMaterial);
		}

		// Token: 0x06045330 RID: 283440 RVA: 0x0121111A File Offset: 0x0120F31A
		private void InitLaunchDirectionController()
		{
			if (this.LaunchDirectionItem == null)
			{
				return;
			}
			this.LaunchDirectionController = new PinballBattleLaunchDirectionController();
			this.LaunchDirectionController.Init(this.LaunchDirectionItem);
		}

		// Token: 0x06045331 RID: 283441 RVA: 0x01211141 File Offset: 0x0120F341
		public void BindBossSkillStateChangeDelegate(AKSC_Shape2D_Entity kscEntity)
		{
			this.ClearBossSkillStateChangeDelegate();
			this.BossSkillStateChangeDelegate = global::DelegateUtils.ToManualReleaseDelegate<FOnShape2DSkillStateChange>(new Action<int, EKSC_Skill_State>(this.OnBossSkillStateChange));
			kscEntity.AssignSkillStateChange(this.BossSkillStateChangeDelegate);
		}

		// Token: 0x06045332 RID: 283442 RVA: 0x0121116C File Offset: 0x0120F36C
		public void ClearBossSkillStateChangeDelegate()
		{
			if (this.BossSkillStateChangeDelegate != null)
			{
				global::DelegateUtils.ReleaseManualReleaseDelegate(new Action<int, EKSC_Skill_State>(this.OnBossSkillStateChange));
				this.BossSkillStateChangeDelegate = null;
			}
		}

		// Token: 0x06045333 RID: 283443 RVA: 0x01211190 File Offset: 0x0120F390
		private void ClearTotalDelegateList()
		{
			foreach (Delegate callBack in this.RoleSkillDelegateList)
			{
				global::DelegateUtils.ReleaseManualReleaseDelegate(callBack);
			}
			foreach (Delegate callBack2 in this.PlayerStateChangeDelegateList)
			{
				global::DelegateUtils.ReleaseManualReleaseDelegate(callBack2);
			}
			this.RoleSkillDelegateList.Clear();
			this.PlayerStateChangeDelegateList.Clear();
			this.ClearBossSkillStateChangeDelegate();
		}

		// Token: 0x06045334 RID: 283444 RVA: 0x0121123C File Offset: 0x0120F43C
		private void BindPlayerEntityTotalDelegate(AKSC_Shape2D_Entity_Player playerEntity, IPinballRoleTotalInfo roleTotalData, int roleId)
		{
			Action<int, EKSC_Skill_State> action = delegate(int skillIndex, EKSC_Skill_State state)
			{
				if (state != EKSC_Skill_State.BeginSkill)
				{
					return;
				}
				if (skillIndex == 1)
				{
					this.GetModel().DashTimes++;
					return;
				}
				if (skillIndex == 0)
				{
					IPinballRoleTotalInfo roleTotalData2 = roleTotalData;
					int skillTimes = roleTotalData2.SkillTimes;
					roleTotalData2.SkillTimes = skillTimes + 1;
				}
			};
			FOnShape2DSkillStateChange fonShape2DSkillStateChange = global::DelegateUtils.ToManualReleaseDelegate<FOnShape2DSkillStateChange>(action);
			this.RoleSkillDelegateList.Add(action);
			playerEntity.AssignSkillStateChange(fonShape2DSkillStateChange);
			Action<bool> action2 = delegate(bool isAlive)
			{
				Singleton<EventSystem>.Instance.Emit<int, bool>(EEventName.OnPinballRoleStateChange, this.GetModel().GetRoleIdByEntityId(playerEntity.EntityId_).GetValueOrDefault(), isAlive);
				int num;
				if (isAlive)
				{
					IPinballRoleTotalInfo roleTotalData2 = roleTotalData;
					num = roleTotalData2.ReviveTimes;
					roleTotalData2.ReviveTimes = num + 1;
					this.UpdateTranslucentSortPriority(playerEntity, roleId, null);
					return;
				}
				IPinballRoleTotalInfo roleTotalData3 = roleTotalData;
				num = roleTotalData3.DieTimes;
				roleTotalData3.DieTimes = num + 1;
				this.UpdateTranslucentSortPriority(playerEntity, roleId, new int?(1));
			};
			FOnPlayerStateChange fonPlayerStateChange = global::DelegateUtils.ToManualReleaseDelegate<FOnPlayerStateChange>(action2);
			this.PlayerStateChangeDelegateList.Add(action2);
			playerEntity.AssignPlayerStateChange(fonPlayerStateChange);
		}

		// Token: 0x06045335 RID: 283445 RVA: 0x012112C3 File Offset: 0x0120F4C3
		public void OnBossSkillStateChange(int skillIndex, EKSC_Skill_State state)
		{
			if (state != EKSC_Skill_State.BeginSkill)
			{
				return;
			}
			this.GetModel().BossSkillTimes++;
		}

		// Token: 0x06045336 RID: 283446 RVA: 0x012112E0 File Offset: 0x0120F4E0
		private void UpdateDamageTotalInfo()
		{
			if (this.ShapeWorld == null)
			{
				return;
			}
			if (this.DamageTotalInfo == null)
			{
				this.DamageTotalInfo = new TArray<FKSC_Shape2D_DamageTotalInfo>();
			}
			this.ShapeWorld.GetDamageTotalInfo(ref this.DamageTotalInfo);
			for (int i = 0; i < this.DamageTotalInfo.Num(); i++)
			{
				FKSC_Shape2D_DamageTotalInfo damageInfo = this.DamageTotalInfo.Get(i);
				this.ExecuteDamageTotalInfo(damageInfo);
			}
		}

		// Token: 0x06045337 RID: 283447 RVA: 0x01211344 File Offset: 0x0120F544
		private void ExecuteDamageTotalInfo(FKSC_Shape2D_DamageTotalInfo damageInfo)
		{
			int sourceEntityId = damageInfo.SourceEntityId;
			int targetEntityId = damageInfo.TargetEntityId;
			int damageId = damageInfo.DamageId;
			int damageValue = damageInfo.DamageValue;
			long collisionDamageId = this.ShapeWorld.DA_Shape2D_World.CollisionDamageId0;
			int valueOrDefault = this.GetModel().GetRoleIdByEntityId(sourceEntityId).GetValueOrDefault();
			PinballRoleTotalInfo pinballRoleTotalInfo;
			this.GetModel().RoleTotalMap.TryGetValue(valueOrDefault, out pinballRoleTotalInfo);
			IPinballRoleTotalInfo pinballRoleTotalInfo2 = pinballRoleTotalInfo;
			if (sourceEntityId == targetEntityId && pinballRoleTotalInfo2 != null)
			{
				pinballRoleTotalInfo2.DropCostHp += (float)damageValue;
				return;
			}
			if (pinballRoleTotalInfo2 != null)
			{
				if ((long)damageId == collisionDamageId)
				{
					this.GetModel().AttackTimes++;
				}
				else
				{
					this.GetModel().FullEnergyTimes++;
				}
			}
			int valueOrDefault2 = this.GetModel().GetRoleIdByEntityId(targetEntityId).GetValueOrDefault();
			PinballRoleTotalInfo pinballRoleTotalInfo3;
			this.GetModel().RoleTotalMap.TryGetValue(valueOrDefault2, out pinballRoleTotalInfo3);
			pinballRoleTotalInfo2 = pinballRoleTotalInfo3;
			if (pinballRoleTotalInfo2 != null)
			{
				pinballRoleTotalInfo2.HitCostHp += (float)damageValue;
			}
		}

		// Token: 0x06045338 RID: 283448 RVA: 0x01211444 File Offset: 0x0120F644
		public void StartAutoLaunchTimer()
		{
			if (this.AutoLaunchTimer != null)
			{
				return;
			}
			this.AutoLaunchTimer = TimerSystem.FlowTimeInstance.Delay(delegate(float _)
			{
				this.LaunchBall();
			}, (float)this.GetModel().WorldConfigCache.Value.ForceLaunchTime, null, null, true, 1f);
		}

		// Token: 0x06045339 RID: 283449 RVA: 0x01211497 File Offset: 0x0120F697
		public void StopAutoLaunchTimer()
		{
			if (this.AutoLaunchTimer == null)
			{
				return;
			}
			TimerSystem.FlowTimeInstance.Remove(this.AutoLaunchTimer);
			this.AutoLaunchTimer = null;
		}

		// Token: 0x0604533A RID: 283450 RVA: 0x012114BC File Offset: 0x0120F6BC
		private void TryTriggerDeathrattle(int creatureDataId)
		{
			IPinballBattleCombatInfo entity = this.GetModel().GetEntity(creatureDataId);
			if (entity == null || entity.EntityType != EPinballBattleEntityType.Drop)
			{
				return;
			}
			int configId = ((IPinballBattleActivityEntityInfo)entity).ConfigId;
			PinballCommonItem? commonItemConfigByConfigId = ConfigBase<PinballBattleConfig>.Instance.GetCommonItemConfigByConfigId(configId);
			if (commonItemConfigByConfigId == null)
			{
				return;
			}
			PinballDeathrattle? deathrattleConfig = ConfigBase<PinballBattleConfig>.Instance.GetDeathrattleConfig(commonItemConfigByConfigId.Value.Deathrattle);
			if (deathrattleConfig == null || deathrattleConfig.Value.Type != 2)
			{
				return;
			}
			for (int i = 0; i < deathrattleConfig.Value.BuffIdListLength; i++)
			{
				int configId2 = deathrattleConfig.Value.BuffIdList(i);
				PinballEffect? effectConfig = ConfigBase<PinballBattleConfig>.Instance.GetEffectConfig(configId2);
				if (effectConfig != null)
				{
					int type = effectConfig.Value.Type;
					if (type != 1)
					{
						if (type == 2)
						{
							this.ApplyBuffToEnemies(effectConfig.Value);
						}
					}
					else
					{
						this.ApplyBuffToAllies(effectConfig.Value.Param1);
					}
				}
			}
		}

		// Token: 0x0604533B RID: 283451 RVA: 0x012115DC File Offset: 0x0120F7DC
		private void ApplyBuffToAllies(string buffIdStr)
		{
			foreach (int buffId in this.ParseNumberArray(buffIdStr))
			{
				foreach (AKSC_Shape2D_Entity_Player aksc_Shape2D_Entity_Player in this.KscPlayerEntities)
				{
					ControllerBase<KuroSimpleCombatController>.Instance.ModifyBuffAsync(aksc_Shape2D_Entity_Player.EntityId_, true, buffId);
				}
			}
		}

		// Token: 0x0604533C RID: 283452 RVA: 0x01211658 File Offset: 0x0120F858
		private void ApplyBuffToEnemies(PinballEffect buffEffect)
		{
			List<IPinballBattleCombatInfo> list = new List<IPinballBattleCombatInfo>();
			this.GetModel().GetAllEntities(list);
			List<int> list2 = this.ParseNumberArray(buffEffect.Param2);
			List<int> list3 = this.ParseNumberArray(buffEffect.Param1);
			foreach (IPinballBattleCombatInfo pinballBattleCombatInfo in list)
			{
				if (pinballBattleCombatInfo.EntityType == EPinballBattleEntityType.Monster)
				{
					IPinballBattleActivityEntityInfo pinballBattleActivityEntityInfo = pinballBattleCombatInfo as IPinballBattleActivityEntityInfo;
					if (pinballBattleActivityEntityInfo != null)
					{
						int? logicProxy = this.GetModel().GetLogicProxy((long)pinballBattleCombatInfo.Uid);
						if (logicProxy == null)
						{
							Log instance = Singleton<Log>.Instance;
							ELogModule module = ELogModule.PinballBattle;
							ELogAuthor author = ELogAuthor.LJ;
							DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(28, 2);
							defaultInterpolatedStringHandler.AppendLiteral("获取怪物实体Id失败！ConfigId: ");
							defaultInterpolatedStringHandler.AppendFormatted<int>(pinballBattleActivityEntityInfo.ConfigId);
							defaultInterpolatedStringHandler.AppendLiteral(", Uid: ");
							defaultInterpolatedStringHandler.AppendFormatted<int>(pinballBattleCombatInfo.Uid);
							instance.Error(module, author, defaultInterpolatedStringHandler.ToStringAndClear(), default(ReadOnlySpan<ValueTuple<string, object>>));
						}
						else
						{
							PinballMonster? pinballMonsterConfigById = ConfigBase<PinballConfig>.Instance.GetPinballMonsterConfigById(pinballBattleActivityEntityInfo.ConfigId);
							if (pinballMonsterConfigById == null)
							{
								Log instance2 = Singleton<Log>.Instance;
								ELogModule module2 = ELogModule.PinballBattle;
								ELogAuthor author2 = ELogAuthor.LJ;
								DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(19, 1);
								defaultInterpolatedStringHandler.AppendLiteral("获取怪物配置失败！ConfigId: ");
								defaultInterpolatedStringHandler.AppendFormatted<int>(pinballBattleActivityEntityInfo.ConfigId);
								instance2.Error(module2, author2, defaultInterpolatedStringHandler.ToStringAndClear(), default(ReadOnlySpan<ValueTuple<string, object>>));
							}
							else
							{
								PinballMonsterType? pinballMonsterTypeConfigById = ConfigBase<PinballConfig>.Instance.GetPinballMonsterTypeConfigById(pinballMonsterConfigById.Value.MonsterType);
								if (pinballMonsterTypeConfigById == null)
								{
									Log instance3 = Singleton<Log>.Instance;
									ELogModule module3 = ELogModule.PinballBattle;
									ELogAuthor author3 = ELogAuthor.LJ;
									DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(38, 2);
									defaultInterpolatedStringHandler.AppendLiteral("获取怪物类型配置失败！ConfigId: ");
									defaultInterpolatedStringHandler.AppendFormatted<int>(pinballBattleActivityEntityInfo.ConfigId);
									defaultInterpolatedStringHandler.AppendLiteral(", MonsterTypeId: ");
									defaultInterpolatedStringHandler.AppendFormatted<int>(pinballMonsterConfigById.Value.MonsterType);
									instance3.Error(module3, author3, defaultInterpolatedStringHandler.ToStringAndClear(), default(ReadOnlySpan<ValueTuple<string, object>>));
								}
								else if (list2.Contains(pinballMonsterTypeConfigById.Value.RiskType))
								{
									foreach (int buffId in list3)
									{
										ControllerBase<KuroSimpleCombatController>.Instance.ModifyBuffAsync(logicProxy.Value, true, buffId);
									}
								}
							}
						}
					}
				}
			}
		}

		// Token: 0x0604533D RID: 283453 RVA: 0x012118EC File Offset: 0x0120FAEC
		private List<int> ParseNumberArray(string str)
		{
			string text = str.Replace("[", "").Replace("]", "").Trim();
			if (string.IsNullOrEmpty(text))
			{
				return new List<int>();
			}
			List<int> list = new List<int>();
			string[] array = text.Split(',', StringSplitOptions.None);
			for (int i = 0; i < array.Length; i++)
			{
				int item;
				if (int.TryParse(array[i].Trim(), out item))
				{
					list.Add(item);
				}
			}
			return list;
		}

		// Token: 0x0604533E RID: 283454 RVA: 0x01211964 File Offset: 0x0120FB64
		public void AddRoleChargeMaxEffectBuff(int roleId)
		{
			KscEntityHandle kscEntityByRoleId = this.GetModel().GetKscEntityByRoleId(roleId);
			AKSC_Shape2D_Entity_Player aksc_Shape2D_Entity_Player = ((kscEntityByRoleId != null) ? kscEntityByRoleId.KscEntity : null) as AKSC_Shape2D_Entity_Player;
			if (aksc_Shape2D_Entity_Player == null || !aksc_Shape2D_Entity_Player.IsPlayerAlive)
			{
				return;
			}
			ControllerBase<KuroSimpleCombatController>.Instance.ModifyBuffAsync(aksc_Shape2D_Entity_Player.EntityId_, true, this.GetModel().WorldConfigCache.Value.RoleChargeMaxBuffId);
		}

		// Token: 0x0604533F RID: 283455 RVA: 0x012119C4 File Offset: 0x0120FBC4
		public void RemoveRoleChargeMaxEffectBuff(int roleId)
		{
			KscEntityHandle kscEntityByRoleId = this.GetModel().GetKscEntityByRoleId(roleId);
			AKSC_Shape2D_Entity_Player aksc_Shape2D_Entity_Player = ((kscEntityByRoleId != null) ? kscEntityByRoleId.KscEntity : null) as AKSC_Shape2D_Entity_Player;
			if (aksc_Shape2D_Entity_Player == null)
			{
				return;
			}
			ControllerBase<KuroSimpleCombatController>.Instance.ModifyBuffAsync(aksc_Shape2D_Entity_Player.EntityId_, false, this.GetModel().WorldConfigCache.Value.RoleChargeMaxBuffId);
		}

		// Token: 0x06045340 RID: 283456 RVA: 0x01211A1C File Offset: 0x0120FC1C
		private void UpdateTranslucentSortPriority(AKSC_Shape2D_Entity_Player kscPlayer, int roleId, int? priority = null)
		{
			int? roleSlotIndex = this.GetModel().GetRoleSlotIndex(roleId);
			List<PinballFormationRolePb> formationData = this.GetModel().FormationData;
			int num = (formationData != null) ? formationData.Count : 0;
			if (roleSlotIndex != null && num != 0)
			{
				TArray<UActorComponent> tarray = kscPlayer.K2_GetComponentsByClass(USpineSkeletonRendererComponent.StaticClass());
				int num2 = tarray.Num();
				FName b = new FName("SpineShadow");
				for (int i = 0; i < num2; i++)
				{
					USpineSkeletonRendererComponent uspineSkeletonRendererComponent = (USpineSkeletonRendererComponent)tarray.Get(i);
					int num3 = priority ?? ((num - roleSlotIndex.Value) * 2 + 1);
					if (uspineSkeletonRendererComponent.GetFName() == b)
					{
						uspineSkeletonRendererComponent.SetTranslucentSortPriority(num3 - 1);
					}
					else
					{
						uspineSkeletonRendererComponent.SetTranslucentSortPriority(num3);
					}
				}
			}
		}

		// Token: 0x06045341 RID: 283457 RVA: 0x01211AF0 File Offset: 0x0120FCF0
		public bool HasAnyPlayerUseSkill()
		{
			AKSC_Shape2D_Entity_Player[] kscPlayerEntities = this.KscPlayerEntities;
			for (int i = 0; i < kscPlayerEntities.Length; i++)
			{
				UKSC_SkillComp skillComp_ = kscPlayerEntities[i].SkillComp_;
				TArray<UKSC_Skill> tarray = (skillComp_ != null) ? skillComp_.Skills_ : null;
				if (tarray != null && tarray.Num() > 0)
				{
					for (int j = 0; j < tarray.Num(); j++)
					{
						EKSC_Skill_State skillState_ = tarray.Get(j).SkillState_;
						if (skillState_ != EKSC_Skill_State.Ready && skillState_ != EKSC_Skill_State.EndCast && skillState_ != EKSC_Skill_State.EndSkill && skillState_ != EKSC_Skill_State.CoolDown)
						{
							return true;
						}
					}
				}
			}
			return false;
		}

		// Token: 0x06045342 RID: 283458 RVA: 0x01211B68 File Offset: 0x0120FD68
		public bool IsInDashCd()
		{
			UKSC_Shape2D_World shapeWorld = this.ShapeWorld;
			AKSC_Shape2D_Entity_Player aksc_Shape2D_Entity_Player = (shapeWorld != null) ? shapeWorld.CurrentPlayer : null;
			if (aksc_Shape2D_Entity_Player == null)
			{
				return false;
			}
			UKSC_SkillComp skillComp_ = aksc_Shape2D_Entity_Player.SkillComp_;
			TArray<UKSC_Skill> tarray = (skillComp_ != null) ? skillComp_.Skills_ : null;
			return tarray != null && tarray.Num() > 1 && tarray.Get(1).SkillState_ > EKSC_Skill_State.Ready;
		}

		// Token: 0x06045343 RID: 283459 RVA: 0x01211BC0 File Offset: 0x0120FDC0
		public float? GetDashNeedCost()
		{
			UKSC_Shape2D_World shapeWorld = this.ShapeWorld;
			AKSC_Shape2D_Entity_Player aksc_Shape2D_Entity_Player = (shapeWorld != null) ? shapeWorld.CurrentPlayer : null;
			if (aksc_Shape2D_Entity_Player == null)
			{
				return null;
			}
			UKSC_SkillComp skillComp_ = aksc_Shape2D_Entity_Player.SkillComp_;
			TArray<UKSC_Skill> tarray = (skillComp_ != null) ? skillComp_.Skills_ : null;
			if (tarray == null || tarray.Num() <= 1)
			{
				return null;
			}
			UKSC_DA_Skill daSkill_ = tarray.Get(1).DaSkill_;
			if (daSkill_ == null)
			{
				return null;
			}
			return new float?(daSkill_.CustomCostValue);
		}

		// Token: 0x06045344 RID: 283460 RVA: 0x01211C3C File Offset: 0x0120FE3C
		private void EnterFixCamera(global::Vector location, global::Rotator rotation, float fov)
		{
			if (this.IsInFixCamera)
			{
				return;
			}
			this.IsInFixCamera = true;
			SceneCamera sceneCamera = ControllerBase<CameraController>.Instance.MainModel.SceneCamera;
			if (sceneCamera == null)
			{
				return;
			}
			SceneCameraPlayerComponent playerComponent = sceneCamera.PlayerComponent;
			if (playerComponent == null)
			{
				return;
			}
			playerComponent.EnterFixSceneSubCamera(location, rotation, fov, 0f, 0f, ESceneSubCameraType.Fix, null, new EViewTargetBlendFunction?(EViewTargetBlendFunction.VTBlend_Linear), new float?(0f), new EViewTargetBlendFunction?(EViewTargetBlendFunction.VTBlend_Linear), new float?(0f), new bool?(false), null, new bool?(false), null, "", null, null, null, false, false);
		}

		// Token: 0x06045345 RID: 283461 RVA: 0x01211CC3 File Offset: 0x0120FEC3
		private void ExitFixCamera()
		{
			if (!this.IsInFixCamera)
			{
				return;
			}
			this.IsInFixCamera = false;
			SceneCamera sceneCamera = ControllerBase<CameraController>.Instance.MainModel.SceneCamera;
			if (sceneCamera == null)
			{
				return;
			}
			SceneCameraPlayerComponent playerComponent = sceneCamera.PlayerComponent;
			if (playerComponent == null)
			{
				return;
			}
			playerComponent.ExitFixSceneSubCamera(null, true);
		}

		// Token: 0x06045346 RID: 283462 RVA: 0x01211CFC File Offset: 0x0120FEFC
		private void ClearAllBullets()
		{
			BulletModel instance = ModelBase<BulletModel>.Instance;
			UBulletWorld ubulletWorld = (instance != null) ? instance.GetKuroBulletWorld() : null;
			if (ubulletWorld != null)
			{
				foreach (KscEntityHandle kscEntityHandle in this.GetModel().KscEntities.Values)
				{
					if (((kscEntityHandle != null) ? kscEntityHandle.KscEntity : null) != null)
					{
						ubulletWorld.DestroyAllBulletsByOwner(kscEntityHandle.KscEntity);
					}
				}
			}
		}

		// Token: 0x06045347 RID: 283463 RVA: 0x01211D84 File Offset: 0x0120FF84
		public void SetSpineCompTickEnabled(AKSC_Entity kscEntity, bool enabled)
		{
			USpineSkeletonAnimationComponent uspineSkeletonAnimationComponent = kscEntity.GetComponentByClass(USpineSkeletonAnimationComponent.StaticClass()) as USpineSkeletonAnimationComponent;
			if (uspineSkeletonAnimationComponent != null && uspineSkeletonAnimationComponent.IsValid())
			{
				uspineSkeletonAnimationComponent.SetComponentTickEnabled(enabled);
				if (enabled)
				{
					uspineSkeletonAnimationComponent.SetTickableWhenPaused(false);
				}
			}
			USpineSkeletonRendererComponent uspineSkeletonRendererComponent = kscEntity.GetComponentByClass(USpineSkeletonRendererComponent.StaticClass()) as USpineSkeletonRendererComponent;
			if (uspineSkeletonRendererComponent != null && uspineSkeletonRendererComponent.IsValid())
			{
				uspineSkeletonRendererComponent.SetComponentTickEnabled(enabled);
				if (enabled)
				{
					uspineSkeletonRendererComponent.SetTickableWhenPaused(false);
				}
			}
		}

		// Token: 0x06045348 RID: 283464 RVA: 0x01211DF8 File Offset: 0x0120FFF8
		public void OnAllCurWaveMachineSpawned()
		{
			foreach (AKSC_Entity aksc_Entity in this.GetModel().CurWaveMachineTracker.SpawnedEntities)
			{
				USpineSkeletonAnimationComponent uspineSkeletonAnimationComponent = aksc_Entity.GetComponentByClass(USpineSkeletonAnimationComponent.StaticClass()) as USpineSkeletonAnimationComponent;
				if (uspineSkeletonAnimationComponent != null && uspineSkeletonAnimationComponent.IsValid() && aksc_Entity.ActorHasTag(FNameUtil.GetDynamicFName("SyncAnim").Value))
				{
					uspineSkeletonAnimationComponent.SetAnimation(0, "Stand01", true);
				}
			}
		}

		// Token: 0x06045349 RID: 283465 RVA: 0x01211E98 File Offset: 0x01210098
		public void ClearGame(bool exitCamera = false)
		{
			this.ClearAllBullets();
			UKSC_Shape2D_World shapeWorld = this.ShapeWorld;
			if (shapeWorld != null)
			{
				shapeWorld.SetGameEnd();
			}
			foreach (AKSC_Shape2D_Entity_Player aksc_Shape2D_Entity_Player in this.KscPlayerEntities)
			{
				if (aksc_Shape2D_Entity_Player != null)
				{
					aksc_Shape2D_Entity_Player.SetEntityActive(false);
				}
			}
			this.EntityRedirectFilter.PreReset();
			if (exitCamera)
			{
				this.ExitFixCamera();
			}
		}

		// Token: 0x0402697C RID: 158076
		[Nullable(2)]
		private static int[] PlayerEntityKeys;

		// Token: 0x0402697D RID: 158077
		[Nullable(2)]
		private static Stat UpdateStat;

		// Token: 0x0402697E RID: 158078
		public static bool EnableSpineParallelUpdate;

		// Token: 0x0402697F RID: 158079
		public static bool EnableSpineShadow;

		// Token: 0x04026980 RID: 158080
		public const int PINBALL_TEAM_PLAYER_ENTITY_KEY = 10001;

		// Token: 0x04026981 RID: 158081
		private const int TEAM_PLAYER_ATTR_ID = 1001;

		// Token: 0x04026982 RID: 158082
		private const int MAX_FORMATION_ROLES = 3;

		// Token: 0x04026983 RID: 158083
		private const float BASE_ASPECT_RATIO = 1.7777778f;

		// Token: 0x04026984 RID: 158084
		private const string SCENE_BG_ACTOR_TAG = "Background";

		// Token: 0x04026985 RID: 158085
		private const string BG_MAT_TEX_PARAM_NAME = "Background";

		// Token: 0x04026986 RID: 158086
		private const int GAME_SYNC_INTERVAL = 10000;

		// Token: 0x04026987 RID: 158087
		private const int GAME_SYNC_REJECT_TIME = 5000;

		// Token: 0x04026988 RID: 158088
		private const int LAUNCH_WAY_SPLINE_ID = 319850000;

		// Token: 0x04026989 RID: 158089
		private FVectorDouble EntityHidePosition = new FVectorDouble(0.0, 0.0, 0.0);

		// Token: 0x0402698A RID: 158090
		private const string FORCE_SHOW_CURSOR_TAG = "PinballBattleInstanceForceShowCursor";

		// Token: 0x0402698B RID: 158091
		private const int DASH_SKILL_INDEX = 1;

		// Token: 0x0402698C RID: 158092
		private const int MAIN_SKILL_INDEX = 0;

		// Token: 0x0402698D RID: 158093
		private const int DEATHRATTLE_ADD_BUFF_TYPE = 2;

		// Token: 0x0402698E RID: 158094
		private const int EFFECT_TYPE_ALLY = 1;

		// Token: 0x0402698F RID: 158095
		private const int EFFECT_TYPE_ENEMY = 2;

		// Token: 0x04026990 RID: 158096
		private const int ROLE_ID_FEIXUE = 80850019;

		// Token: 0x04026991 RID: 158097
		private readonly PinballBattlePlayerHpHandle PlayerHpHandle = new PinballBattlePlayerHpHandle();

		// Token: 0x04026992 RID: 158098
		private readonly PinballBattleEntityRedirectFilter EntityRedirectFilter = new PinballBattleEntityRedirectFilter();

		// Token: 0x04026993 RID: 158099
		private int CreatureIdCounter;

		// Token: 0x04026994 RID: 158100
		[Nullable(2)]
		private UKSC_Shape2D_World ShapeWorld;

		// Token: 0x04026995 RID: 158101
		[Nullable(2)]
		private AKSC_Shape2D_Entity_Bar KscEntityLeftBar;

		// Token: 0x04026996 RID: 158102
		[Nullable(2)]
		private AKSC_Shape2D_Entity_Bar KscEntityRightBar;

		// Token: 0x04026997 RID: 158103
		[Nullable(2)]
		private BP_Fever_Bar_C FeverBar;

		// Token: 0x04026998 RID: 158104
		[Nullable(2)]
		private PinballBattleFeverBarController FeverBarController;

		// Token: 0x04026999 RID: 158105
		[Nullable(2)]
		private PinballBattlePlayerBarController LeftBarController;

		// Token: 0x0402699A RID: 158106
		[Nullable(2)]
		private PinballBattlePlayerBarController RightBarController;

		// Token: 0x0402699B RID: 158107
		private float GroundPositionZ;

		// Token: 0x0402699C RID: 158108
		private global::Vector WorldOrigin = global::Vector.Create();

		// Token: 0x0402699D RID: 158109
		private global::Transform WorldOriginTransform = global::Transform.Create();

		// Token: 0x0402699E RID: 158110
		private global::Transform BornTransform = global::Transform.Create();

		// Token: 0x0402699F RID: 158111
		private global::Vector InitLocation = global::Vector.Create();

		// Token: 0x040269A0 RID: 158112
		private bool IsShapeWorldReady;

		// Token: 0x040269A1 RID: 158113
		private bool IsInFixCamera;

		// Token: 0x040269A2 RID: 158114
		private bool IsInitShapeWorld;

		// Token: 0x040269A3 RID: 158115
		private bool IsPreloadFinish;

		// Token: 0x040269A4 RID: 158116
		private bool IsMapLoadFinish;

		// Token: 0x040269A5 RID: 158117
		[Nullable(2)]
		public AKSC_Shape2D_Entity_TeamPlayer KscTeamPlayer;

		// Token: 0x040269A6 RID: 158118
		private int[] KscPlayerEntityIds = Array.Empty<int>();

		// Token: 0x040269A7 RID: 158119
		private AKSC_Shape2D_Entity_Player[] KscPlayerEntities = Array.Empty<AKSC_Shape2D_Entity_Player>();

		// Token: 0x040269A8 RID: 158120
		private int KscPlayerInitCount;

		// Token: 0x040269A9 RID: 158121
		private bool IsFormationDataReady;

		// Token: 0x040269AA RID: 158122
		private bool IsInitKscPlayerEntities;

		// Token: 0x040269AB RID: 158123
		private bool NeedSendLaunchRequest;

		// Token: 0x040269AC RID: 158124
		[Nullable(2)]
		private TMap<int, int> DamageInfo;

		// Token: 0x040269AD RID: 158125
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private TArray<FKSC_Shape2D_DamageTotalInfo> DamageTotalInfo;

		// Token: 0x040269AE RID: 158126
		private bool IsFirstLaunch;

		// Token: 0x040269AF RID: 158127
		[Nullable(2)]
		private FOnWorldUpdateOnce WorldUpdateOnceDelegateRef;

		// Token: 0x040269B0 RID: 158128
		[Nullable(2)]
		private FOnKSCEntitySummon KscEntitySummonDelegateRef;

		// Token: 0x040269B1 RID: 158129
		[Nullable(2)]
		private FOnRelaunchPlayer RelaunchPlayerDelegateRef;

		// Token: 0x040269B2 RID: 158130
		[Nullable(2)]
		private FOnTeamAllDead TeamAllDeadDelegateRef;

		// Token: 0x040269B3 RID: 158131
		[Nullable(2)]
		private HashSet<int> PendingLoadBuffs;

		// Token: 0x040269B4 RID: 158132
		private int CachedShowFlagTonemapper;

		// Token: 0x040269B5 RID: 158133
		private int CachedScreenSizeCullRatioFactor;

		// Token: 0x040269B6 RID: 158134
		private int CachedAntiAliasing;

		// Token: 0x040269B7 RID: 158135
		[Nullable(2)]
		private UMaterialInstanceDynamic BgDynamicMat;

		// Token: 0x040269B8 RID: 158136
		[Nullable(2)]
		private UMaterialInstance FeverBarMaterial;

		// Token: 0x040269B9 RID: 158137
		[Nullable(2)]
		private TimerHandle PayloadSyncTimerHandle;

		// Token: 0x040269BA RID: 158138
		private double LastSyncRealTimeMs;

		// Token: 0x040269BB RID: 158139
		[Nullable(2)]
		private UCurveFloat LaunchSpeedCurve;

		// Token: 0x040269BC RID: 158140
		[Nullable(2)]
		private UCurveFloat LaunchDegCurve;

		// Token: 0x040269BD RID: 158141
		[Nullable(2)]
		private UiPanelBase LaunchBallItem;

		// Token: 0x040269BE RID: 158142
		[Nullable(2)]
		private PinballBattleLaunchDirectionItem LaunchDirectionItem;

		// Token: 0x040269BF RID: 158143
		[Nullable(2)]
		private PinballBattleLaunchDirectionController LaunchDirectionController;

		// Token: 0x040269C0 RID: 158144
		private bool AlreadyRequestBonusWin;

		// Token: 0x040269C1 RID: 158145
		[Nullable(2)]
		private CustomPromise CanRequestSettlePromise;

		// Token: 0x040269C2 RID: 158146
		[Nullable(2)]
		private CustomPromise CanOpenSettleResultPromise;

		// Token: 0x040269C3 RID: 158147
		private float BaseFov;

		// Token: 0x040269C4 RID: 158148
		[Nullable(2)]
		public PinballBattleLaunchPhaseController LaunchPhaseController;

		// Token: 0x040269C5 RID: 158149
		private readonly List<Delegate> RoleSkillDelegateList = new List<Delegate>();

		// Token: 0x040269C6 RID: 158150
		private readonly List<Delegate> PlayerStateChangeDelegateList = new List<Delegate>();

		// Token: 0x040269C7 RID: 158151
		[Nullable(2)]
		private FOnShape2DSkillStateChange BossSkillStateChangeDelegate;

		// Token: 0x040269C8 RID: 158152
		[Nullable(2)]
		private TimerHandle AutoLaunchTimer;

		// Token: 0x0200CC22 RID: 52258
		[NullableContext(0)]
		private class AlwaysShowCursor : IExtraShowCursor
		{
			// Token: 0x0604F99F RID: 326047 RVA: 0x01632930 File Offset: 0x01630B30
			public bool IsShowCursor()
			{
				return true;
			}
		}
	}
}
