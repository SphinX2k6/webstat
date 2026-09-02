using System;
using System.Runtime.CompilerServices;
using Aki.Protocol;
using Aki.TDConfigMgr.Action;
using CSharpScript.Game.Module.SeamlessTravel;
using UnrealEngine;

namespace CSharpScript.Game.Module.Teleport
{
	// Token: 0x02004EEE RID: 20206
	[NullableContext(2)]
	[Nullable(0)]
	public class TeleportContext : ITeleportContext, IStaticVariableResetter
	{
		// Token: 0x170089DF RID: 35295
		// (get) Token: 0x06034333 RID: 213811 RVA: 0x00D0E002 File Offset: 0x00D0C202
		// (set) Token: 0x06034334 RID: 213812 RVA: 0x00D0E00A File Offset: 0x00D0C20A
		[Nullable(1)]
		public string ClientReason { [NullableContext(1)] get; [NullableContext(1)] set; }

		// Token: 0x170089E0 RID: 35296
		// (get) Token: 0x06034335 RID: 213813 RVA: 0x00D0E013 File Offset: 0x00D0C213
		// (set) Token: 0x06034336 RID: 213814 RVA: 0x00D0E01B File Offset: 0x00D0C21B
		public FVectorDouble TargetPosition { get; set; }

		// Token: 0x170089E1 RID: 35297
		// (get) Token: 0x06034337 RID: 213815 RVA: 0x00D0E024 File Offset: 0x00D0C224
		// (set) Token: 0x06034338 RID: 213816 RVA: 0x00D0E02C File Offset: 0x00D0C22C
		public ETeleportMode? TeleportMode { get; set; }

		// Token: 0x170089E2 RID: 35298
		// (get) Token: 0x06034339 RID: 213817 RVA: 0x00D0E035 File Offset: 0x00D0C235
		// (set) Token: 0x0603433A RID: 213818 RVA: 0x00D0E03D File Offset: 0x00D0C23D
		public IRotator TargetRotation { get; set; }

		// Token: 0x170089E3 RID: 35299
		// (get) Token: 0x0603433B RID: 213819 RVA: 0x00D0E046 File Offset: 0x00D0C246
		// (set) Token: 0x0603433C RID: 213820 RVA: 0x00D0E04E File Offset: 0x00D0C24E
		public IVector TargetGravityDirect { get; set; }

		// Token: 0x170089E4 RID: 35300
		// (get) Token: 0x0603433D RID: 213821 RVA: 0x00D0E057 File Offset: 0x00D0C257
		// (set) Token: 0x0603433E RID: 213822 RVA: 0x00D0E05F File Offset: 0x00D0C25F
		public IVector TargetSpeed { get; set; }

		// Token: 0x170089E5 RID: 35301
		// (get) Token: 0x0603433F RID: 213823 RVA: 0x00D0E068 File Offset: 0x00D0C268
		// (set) Token: 0x06034340 RID: 213824 RVA: 0x00D0E070 File Offset: 0x00D0C270
		public TeleportReason? ServerReason { get; set; }

		// Token: 0x170089E6 RID: 35302
		// (get) Token: 0x06034341 RID: 213825 RVA: 0x00D0E079 File Offset: 0x00D0C279
		// (set) Token: 0x06034342 RID: 213826 RVA: 0x00D0E081 File Offset: 0x00D0C281
		public TransitionOptionPb Option { get; set; }

		// Token: 0x170089E7 RID: 35303
		// (get) Token: 0x06034343 RID: 213827 RVA: 0x00D0E08A File Offset: 0x00D0C28A
		// (set) Token: 0x06034344 RID: 213828 RVA: 0x00D0E092 File Offset: 0x00D0C292
		public int? TransitionConfigId { get; set; }

		// Token: 0x170089E8 RID: 35304
		// (get) Token: 0x06034345 RID: 213829 RVA: 0x00D0E09B File Offset: 0x00D0C29B
		// (set) Token: 0x06034346 RID: 213830 RVA: 0x00D0E0A3 File Offset: 0x00D0C2A3
		public ITeleportTransitionType TransitionConfig { get; set; }

		// Token: 0x170089E9 RID: 35305
		// (get) Token: 0x06034347 RID: 213831 RVA: 0x00D0E0AC File Offset: 0x00D0C2AC
		// (set) Token: 0x06034348 RID: 213832 RVA: 0x00D0E0B4 File Offset: 0x00D0C2B4
		public bool? NeedRestoreCamera { get; set; } = new bool?(true);

		// Token: 0x170089EA RID: 35306
		// (get) Token: 0x06034349 RID: 213833 RVA: 0x00D0E0BD File Offset: 0x00D0C2BD
		// (set) Token: 0x0603434A RID: 213834 RVA: 0x00D0E0C5 File Offset: 0x00D0C2C5
		public GameCtxPb GameCtx { get; set; }

		// Token: 0x170089EB RID: 35307
		// (get) Token: 0x0603434B RID: 213835 RVA: 0x00D0E0CE File Offset: 0x00D0C2CE
		// (set) Token: 0x0603434C RID: 213836 RVA: 0x00D0E0D6 File Offset: 0x00D0C2D6
		public Entity ElevatorEntity { get; set; }

		// Token: 0x170089EC RID: 35308
		// (get) Token: 0x0603434D RID: 213837 RVA: 0x00D0E0DF File Offset: 0x00D0C2DF
		// (set) Token: 0x0603434E RID: 213838 RVA: 0x00D0E0E7 File Offset: 0x00D0C2E7
		public bool? DisableAutoFade { get; set; } = new bool?(false);

		// Token: 0x170089ED RID: 35309
		// (get) Token: 0x0603434F RID: 213839 RVA: 0x00D0E0F0 File Offset: 0x00D0C2F0
		// (set) Token: 0x06034350 RID: 213840 RVA: 0x00D0E0F8 File Offset: 0x00D0C2F8
		public int? TeleportCfgId { get; set; }

		// Token: 0x170089EE RID: 35310
		// (get) Token: 0x06034351 RID: 213841 RVA: 0x00D0E101 File Offset: 0x00D0C301
		// (set) Token: 0x06034352 RID: 213842 RVA: 0x00D0E109 File Offset: 0x00D0C309
		public bool? NeedRequestToServer { get; set; } = new bool?(true);

		// Token: 0x170089EF RID: 35311
		// (get) Token: 0x06034353 RID: 213843 RVA: 0x00D0E112 File Offset: 0x00D0C312
		// (set) Token: 0x06034354 RID: 213844 RVA: 0x00D0E11A File Offset: 0x00D0C31A
		public bool? NeedWaitStreaming { get; set; } = new bool?(true);

		// Token: 0x170089F0 RID: 35312
		// (get) Token: 0x06034355 RID: 213845 RVA: 0x00D0E123 File Offset: 0x00D0C323
		// (set) Token: 0x06034356 RID: 213846 RVA: 0x00D0E12B File Offset: 0x00D0C32B
		public bool? KeepCameraRelativeRotation { get; set; } = new bool?(false);

		// Token: 0x170089F1 RID: 35313
		// (get) Token: 0x06034357 RID: 213847 RVA: 0x00D0E134 File Offset: 0x00D0C334
		// (set) Token: 0x06034358 RID: 213848 RVA: 0x00D0E13C File Offset: 0x00D0C33C
		public bool? KeepSpeedRelativeRotation { get; set; } = new bool?(false);

		// Token: 0x170089F2 RID: 35314
		// (get) Token: 0x06034359 RID: 213849 RVA: 0x00D0E145 File Offset: 0x00D0C345
		public GameModePromise StreamingCompleted
		{
			get
			{
				return this.StreamingCompletedInternal;
			}
		}

		// Token: 0x170089F3 RID: 35315
		// (get) Token: 0x0603435A RID: 213850 RVA: 0x00D0E14D File Offset: 0x00D0C34D
		public GameModePromise VoxelStreamingCompleted
		{
			get
			{
				return this.VoxelStreamingCompletedInternal;
			}
		}

		// Token: 0x170089F4 RID: 35316
		// (get) Token: 0x0603435B RID: 213851 RVA: 0x00D0E155 File Offset: 0x00D0C355
		public GameModePromise TeleportFinishRequest
		{
			get
			{
				return this.TeleportFinishRequestInternal;
			}
		}

		// Token: 0x170089F5 RID: 35317
		// (get) Token: 0x0603435C RID: 213852 RVA: 0x00D0E15D File Offset: 0x00D0C35D
		public GameModePromise CgTeleportCompleted
		{
			get
			{
				return this.CgTeleportCompletedInternal;
			}
		}

		// Token: 0x170089F6 RID: 35318
		// (get) Token: 0x0603435D RID: 213853 RVA: 0x00D0E165 File Offset: 0x00D0C365
		public GameModePromise TeleportWaitRequest
		{
			get
			{
				return this.TeleportWaitRequestInternal;
			}
		}

		// Token: 0x0603435E RID: 213854 RVA: 0x00D0E170 File Offset: 0x00D0C370
		[NullableContext(1)]
		public TeleportContext(ITeleportContext contextParams)
		{
			this.ClientReason = contextParams.ClientReason;
			this.TargetPosition = contextParams.TargetPosition;
			this.TeleportMode = new ETeleportMode?(contextParams.TeleportMode.GetValueOrDefault(ETeleportMode.Auto));
			this.TargetRotation = contextParams.TargetRotation;
			this.TargetGravityDirect = contextParams.TargetGravityDirect;
			this.TargetSpeed = contextParams.TargetSpeed;
			this.ServerReason = contextParams.ServerReason;
			this.Option = contextParams.Option;
			this.TransitionConfigId = contextParams.TransitionConfigId;
			ITeleportTransitionType transitionConfig;
			if (this.TransitionConfigId != null)
			{
				int? transitionConfigId = this.TransitionConfigId;
				int num = 0;
				if (transitionConfigId.GetValueOrDefault() > num & transitionConfigId != null)
				{
					transitionConfig = ModelBase<TeleportModel>.Instance.ParseTransitionConfig(this.TransitionConfigId.Value);
					goto IL_11D;
				}
			}
			transitionConfig = null;
			IL_11D:
			this.TransitionConfig = transitionConfig;
			this.TeleportCfgId = contextParams.TeleportCfgId;
			this.GameCtx = contextParams.GameCtx;
			if (contextParams.NeedRestoreCamera.GetValueOrDefault())
			{
				this.NeedRestoreCamera = contextParams.NeedRestoreCamera;
			}
			ITeleportTransitionType transitionConfig2 = this.TransitionConfig;
			if (transitionConfig2 != null && transitionConfig2.Type == ETeleportTransitionType.Seamless)
			{
				this.SeamlessConfig = new SeamlessTravelContext();
				this.SeamlessConfig.ParseParamsByConfig(this.TransitionConfig as ITeleportTransitionInSeamlessType);
				this.ForceInGameLoadMode = (this.TransitionConfig as ITeleportTransitionInSeamlessType).IsNormalStreamingLoad.GetValueOrDefault();
				this.Seamless = new bool?(true);
			}
			else
			{
				TransitionOptionPb option = contextParams.Option;
				if (((option != null) ? option.TransitionInSeamless : null) != null)
				{
					this.SeamlessConfig = new SeamlessTravelContext();
					this.SeamlessConfig.ParseParamsByProto(this.Option.TransitionInSeamless);
					this.ForceInGameLoadMode = this.Option.TransitionInSeamless.NormalStreamingLoad;
					this.Seamless = new bool?(true);
				}
			}
			if (contextParams.NeedRequestToServer != null)
			{
				this.NeedRequestToServer = contextParams.NeedRequestToServer;
			}
			if (contextParams.NeedWaitStreaming != null)
			{
				this.NeedWaitStreaming = contextParams.NeedWaitStreaming;
			}
			if (contextParams.DisableAutoFade != null)
			{
				this.DisableAutoFade = contextParams.DisableAutoFade;
			}
			if (contextParams.KeepCameraRelativeRotation != null)
			{
				this.KeepCameraRelativeRotation = contextParams.KeepCameraRelativeRotation;
			}
			if (contextParams.KeepSpeedRelativeRotation != null)
			{
				this.KeepSpeedRelativeRotation = contextParams.KeepSpeedRelativeRotation;
			}
			if (contextParams.ElevatorEntity != null)
			{
				this.ElevatorEntity = contextParams.ElevatorEntity;
			}
			this.StreamingCompletedInternal = new GameModePromise();
			this.VoxelStreamingCompletedInternal = new GameModePromise();
			this.TeleportFinishRequestInternal = new GameModePromise();
			this.CgTeleportCompletedInternal = new GameModePromise();
			this.TeleportWaitRequestInternal = new GameModePromise();
			this.TeleportCore = new TeleportCore(this);
			this.TeleportTransitionHelper = new TeleportTransitionHelper(this);
			this.TeleportStreamingHelper = new TeleportStreamingHelper(this);
			if (this.Seamless.GetValueOrDefault())
			{
				this.TeleportSeamlessHelper = new TeleportSeamlessHelper(this);
				if (this.KeepCameraRelativeRotation != null)
				{
					this.KeepCameraRelativeRotation = new bool?(true);
				}
			}
		}

		// Token: 0x0603435F RID: 213855 RVA: 0x00D0E4BE File Offset: 0x00D0C6BE
		[NullableContext(1)]
		public static TeleportContext CreateContext(ITeleportContext contextParams)
		{
			TeleportContext teleportContext = new TeleportContext(contextParams);
			TeleportContext.TeleportContextIdHandler++;
			teleportContext.TeleportContextId = TeleportContext.TeleportContextIdHandler;
			return teleportContext;
		}

		// Token: 0x06034360 RID: 213856 RVA: 0x00D0E4E0 File Offset: 0x00D0C6E0
		public void InitSeamlessContext()
		{
			this.ScreenEffectStarted = new GameModePromise();
			this.ScreenEffectEnded = new GameModePromise();
			this.SceneEffectStarted = new GameModePromise();
			this.SceneEffectEnded = new GameModePromise();
			this.LeastTimeFinished = new GameModePromise();
			this.TreadmillLoaded = new GameModePromise();
			this.TreadmillAppeared = new GameModePromise();
			this.TreadmillDisappeared = new GameModePromise();
			this.PostProcessBlendedIn = new GameModePromise();
			this.PostProcessBlendedOut = new GameModePromise();
			this.KiteAppeared = new GameModePromise();
		}

		// Token: 0x06034361 RID: 213857 RVA: 0x00D0E566 File Offset: 0x00D0C766
		static TeleportContext()
		{
			StaticVariableRegister.RegisterAndExecute(new Action(TeleportContext.CreateStaticDefaultValue), new Action(TeleportContext.ResetStaticDefaultValue));
		}

		// Token: 0x06034362 RID: 213858 RVA: 0x00D0E585 File Offset: 0x00D0C785
		public static void CreateStaticDefaultValue()
		{
			TeleportContext.TeleportContextIdHandler = 0;
		}

		// Token: 0x06034363 RID: 213859 RVA: 0x00D0E58D File Offset: 0x00D0C78D
		public static void ResetStaticDefaultValue()
		{
			TeleportContext.TeleportContextIdHandler = 0;
		}

		// Token: 0x0401E207 RID: 123399
		[Nullable(1)]
		public TeleportCore TeleportCore;

		// Token: 0x0401E208 RID: 123400
		[Nullable(1)]
		public TeleportTransitionHelper TeleportTransitionHelper;

		// Token: 0x0401E209 RID: 123401
		[Nullable(1)]
		public TeleportStreamingHelper TeleportStreamingHelper;

		// Token: 0x0401E20A RID: 123402
		public TeleportSeamlessHelper TeleportSeamlessHelper;

		// Token: 0x0401E20B RID: 123403
		private static int TeleportContextIdHandler;

		// Token: 0x0401E20C RID: 123404
		public int TeleportContextId;

		// Token: 0x0401E20D RID: 123405
		public Entity TeleportEntity;

		// Token: 0x0401E20E RID: 123406
		public TimerHandle CheckStreamingCompletedTimerId;

		// Token: 0x0401E20F RID: 123407
		private readonly GameModePromise StreamingCompletedInternal;

		// Token: 0x0401E210 RID: 123408
		private readonly GameModePromise VoxelStreamingCompletedInternal;

		// Token: 0x0401E211 RID: 123409
		private readonly GameModePromise TeleportFinishRequestInternal;

		// Token: 0x0401E212 RID: 123410
		private readonly GameModePromise CgTeleportCompletedInternal;

		// Token: 0x0401E213 RID: 123411
		private readonly GameModePromise TeleportWaitRequestInternal;

		// Token: 0x0401E214 RID: 123412
		public bool? Seamless = new bool?(false);

		// Token: 0x0401E215 RID: 123413
		public bool ForceInGameLoadMode;

		// Token: 0x0401E216 RID: 123414
		public bool IsInSeamlessTeleport;

		// Token: 0x0401E217 RID: 123415
		public SeamlessTravelContext SeamlessConfig;

		// Token: 0x0401E218 RID: 123416
		public bool UseTreadmill;

		// Token: 0x0401E219 RID: 123417
		public SeamlessTravelTreadmill Treadmill;

		// Token: 0x0401E21A RID: 123418
		public bool UseKeepKite;

		// Token: 0x0401E21B RID: 123419
		public SeamlessTravelKeepKite KeepKite;

		// Token: 0x0401E21C RID: 123420
		public bool UseKeepMovementMode;

		// Token: 0x0401E21D RID: 123421
		public SeamlessTravelKeepMovementMode KeepMovementMode;

		// Token: 0x0401E21E RID: 123422
		public SeamlessTravelPostProcess PostProcess;

		// Token: 0x0401E21F RID: 123423
		public SeamlessTravelScreenEffect ScreenEffect;

		// Token: 0x0401E220 RID: 123424
		public SeamlessTravelSceneEffect SceneEffect;

		// Token: 0x0401E221 RID: 123425
		public TimerHandle SeamlessEndHandle;

		// Token: 0x0401E222 RID: 123426
		public GameModePromise ScreenEffectStarted;

		// Token: 0x0401E223 RID: 123427
		public GameModePromise ScreenEffectEnded;

		// Token: 0x0401E224 RID: 123428
		public GameModePromise SceneEffectStarted;

		// Token: 0x0401E225 RID: 123429
		public GameModePromise SceneEffectEnded;

		// Token: 0x0401E226 RID: 123430
		public GameModePromise LeastTimeFinished;

		// Token: 0x0401E227 RID: 123431
		public GameModePromise TreadmillLoaded;

		// Token: 0x0401E228 RID: 123432
		public GameModePromise TreadmillAppeared;

		// Token: 0x0401E229 RID: 123433
		public GameModePromise TreadmillDisappeared;

		// Token: 0x0401E22A RID: 123434
		public GameModePromise PostProcessBlendedIn;

		// Token: 0x0401E22B RID: 123435
		public GameModePromise PostProcessBlendedOut;

		// Token: 0x0401E22C RID: 123436
		public GameModePromise KiteAppeared;
	}
}
