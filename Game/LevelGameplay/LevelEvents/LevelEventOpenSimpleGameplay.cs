using System;
using System.Runtime.CompilerServices;
using Aki.Config;
using Aki.TDConfigMgr.Action;
using CSharpScript.Game.LevelGamePlay.BigStuffedDoll;
using CSharpScript.Game.LevelGamePlay.Cipher;
using CSharpScript.Game.LevelGamePlay.DollGrabMachine;
using CSharpScript.Game.LevelGamePlay.FindSunSprite;
using CSharpScript.Game.LevelGamePlay.FishingQte;
using CSharpScript.Game.LevelGamePlay.Hourglass;
using CSharpScript.Game.LevelGamePlay.ItemInspect;
using CSharpScript.Game.LevelGamePlay.LevelEvents.SimpleGameplay;
using CSharpScript.Game.LevelGamePlay.LevelPickControl;
using CSharpScript.Game.LevelGamePlay.LifePoint;
using CSharpScript.Game.LevelGamePlay.ProjectPuzzle;
using CSharpScript.Game.LevelGamePlay.SceneInspection;
using CSharpScript.Game.LevelGamePlay.SeekTrace;
using CSharpScript.Game.LevelGamePlay.SignalDeviceControl;
using CSharpScript.Game.LevelGamePlay.TuningStand;
using CSharpScript.Game.LevelGamePlay.WriteLetter;
using CSharpScript.Game.Module.Interaction;
using CSharpScript.Game.Module.MusicalInstrument;
using CSharpScript.Game.Module.Sheriff;
using CSharpScript.Game.Module.WuwaGo.Controller;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;

namespace CSharpScript.Game.LevelGamePlay.LevelEvents
{
	// Token: 0x02006BBB RID: 27579
	[NullableContext(1)]
	[Nullable(0)]
	public class LevelEventOpenSimpleGameplay : LevelEventBase, ISimpleGameplayOpenHost
	{
		// Token: 0x1700A33E RID: 41790
		// (get) Token: 0x0604401D RID: 278557 RVA: 0x011A0E87 File Offset: 0x0119F087
		// (set) Token: 0x0604401E RID: 278558 RVA: 0x011A0E8F File Offset: 0x0119F08F
		public GeneralContext Context { get; set; } = new GeneralContext();

		// Token: 0x1700A33F RID: 41791
		// (get) Token: 0x0604401F RID: 278559 RVA: 0x011A0E98 File Offset: 0x0119F098
		[Nullable(new byte[]
		{
			1,
			2
		})]
		public Action<string> SetFinishSendSelfEvent
		{
			[return: Nullable(new byte[]
			{
				1,
				2
			})]
			get
			{
				return new Action<string>(this.SetFinishSendSelfEventImpl);
			}
		}

		// Token: 0x1700A340 RID: 41792
		// (get) Token: 0x06044020 RID: 278560 RVA: 0x011A0EA6 File Offset: 0x0119F0A6
		[Nullable(new byte[]
		{
			1,
			2
		})]
		public Action<string> SetFailSendSelfEvent
		{
			[return: Nullable(new byte[]
			{
				1,
				2
			})]
			get
			{
				return new Action<string>(this.SetFailSendSelfEventImpl);
			}
		}

		// Token: 0x1700A341 RID: 41793
		// (get) Token: 0x06044021 RID: 278561 RVA: 0x011A0EB4 File Offset: 0x0119F0B4
		public Action<long> SetCreatureDataId
		{
			get
			{
				return new Action<long>(this.SetCreatureDataIdImpl);
			}
		}

		// Token: 0x1700A342 RID: 41794
		// (get) Token: 0x06044022 RID: 278562 RVA: 0x011A0EC2 File Offset: 0x0119F0C2
		public Action FinishCallback
		{
			get
			{
				return new Action(this.FinishCallbackImpl);
			}
		}

		// Token: 0x1700A343 RID: 41795
		// (get) Token: 0x06044023 RID: 278563 RVA: 0x011A0ED0 File Offset: 0x0119F0D0
		public Action<bool> FinishWithResultCallback
		{
			get
			{
				return new Action<bool>(this.FinishWithResultCallbackImpl);
			}
		}

		// Token: 0x06044024 RID: 278564 RVA: 0x011A0EDE File Offset: 0x0119F0DE
		[NullableContext(2)]
		private void SetFinishSendSelfEventImpl(string eventName)
		{
			this.FinishSendSelfEvent = eventName;
		}

		// Token: 0x06044025 RID: 278565 RVA: 0x011A0EE7 File Offset: 0x0119F0E7
		[NullableContext(2)]
		private void SetFailSendSelfEventImpl(string eventName)
		{
			this.FailSendSelfEvent = eventName;
		}

		// Token: 0x06044026 RID: 278566 RVA: 0x011A0EF0 File Offset: 0x0119F0F0
		private void SetCreatureDataIdImpl(long id)
		{
			this.CreatureDataId = id;
		}

		// Token: 0x06044027 RID: 278567 RVA: 0x011A0EF9 File Offset: 0x0119F0F9
		public LevelEventOpenSimpleGameplay(int id) : base(id)
		{
		}

		// Token: 0x06044028 RID: 278568 RVA: 0x011A0F18 File Offset: 0x0119F118
		public override void ExecuteNew(ActionParams inParams, GeneralContext context, int? actionId = null)
		{
			OpenSimpleGameplay openSimpleGameplay = inParams as OpenSimpleGameplay;
			if (openSimpleGameplay == null)
			{
				Singleton<global::Log>.Instance.Error(ELogModule.Event, ELogAuthor.CJH, "参数不合法", default(ReadOnlySpan<ValueTuple<string, object>>));
				return;
			}
			int? num = null;
			EntityContext entityContext = context as EntityContext;
			if (entityContext != null)
			{
				num = entityContext.EntityId;
			}
			else
			{
				DynamicInteractContext dynamicInteractContext = context as DynamicInteractContext;
				if (dynamicInteractContext != null)
				{
					num = dynamicInteractContext.EntityId;
				}
			}
			IUiGame gameplayConfig = openSimpleGameplay.GameplayConfig;
			if ((gameplayConfig is ISignalDevice || gameplayConfig is ISignalDevice2 || gameplayConfig is ILifePoint || gameplayConfig is IFishingRoulette || gameplayConfig is ITuningStand || gameplayConfig is IItemInspection || gameplayConfig is ITraceTracing || gameplayConfig is IFindSunSpirit || gameplayConfig is IDaemonHack || gameplayConfig is IProjectorPuzzle || gameplayConfig is IProjectionMachine) && num == null)
			{
				Singleton<global::Log>.Instance.Error(ELogModule.Event, ELogAuthor.CJH, "上下文不合法", default(ReadOnlySpan<ValueTuple<string, object>>));
				return;
			}
			this.Context = context;
			ISimpleGameplayOpenHandler simpleGameplayOpenHandler = SimpleGameplayHandlerRegistry.Open.Get(openSimpleGameplay.GameplayConfig.Type);
			if (simpleGameplayOpenHandler != null)
			{
				simpleGameplayOpenHandler.Open(openSimpleGameplay.GameplayConfig, openSimpleGameplay, this);
				return;
			}
			gameplayConfig = openSimpleGameplay.GameplayConfig;
			ICipherGameplay cipherGameplay = gameplayConfig as ICipherGameplay;
			if (cipherGameplay != null)
			{
				TsInteractionUtils.RegisterOpenViewName(EUiViewName.CipherView);
				this.OpenCipher(cipherGameplay.CipherId);
				return;
			}
			ISignalBreakGameplay signalBreakGameplay = gameplayConfig as ISignalBreakGameplay;
			if (signalBreakGameplay != null)
			{
				TsInteractionUtils.RegisterOpenViewName(EUiViewName.SignalDecodeView);
				Singleton<UiManager>.Instance.OpenView(EUiViewName.SignalDecodeView, signalBreakGameplay.SignalBreakId, null);
				return;
			}
			if (gameplayConfig is ISundialPuzzleGameplay)
			{
				TsInteractionUtils.RegisterOpenViewName(EUiViewName.SundialControlView);
				Singleton<UiManager>.Instance.OpenView(EUiViewName.SundialControlView, null, null);
				return;
			}
			ISignalDevice signalDevice = gameplayConfig as ISignalDevice;
			if (signalDevice != null)
			{
				this.FinishSendSelfEvent = openSimpleGameplay.FinishSendSelfEvent;
				Entity entity = Singleton<EntitySystem>.Instance.Get(num.Value);
				this.CreatureDataId = entity.GetComponent<CreatureDataComponent>().GetCreatureDataId();
				TsInteractionUtils.RegisterOpenViewName(EUiViewName.SignalDeviceView);
				ControllerBase<SignalDeviceController>.Instance.OpenGameplay(signalDevice.Config, this.FinishCallback);
				return;
			}
			ISignalDevice2 signalDevice2 = gameplayConfig as ISignalDevice2;
			if (signalDevice2 != null)
			{
				this.FinishSendSelfEvent = openSimpleGameplay.FinishSendSelfEvent;
				Entity entity2 = Singleton<EntitySystem>.Instance.Get(num.Value);
				this.CreatureDataId = entity2.GetComponent<CreatureDataComponent>().GetCreatureDataId();
				TsInteractionUtils.RegisterOpenViewName(EUiViewName.SignalDeviceChasingMoonView);
				ControllerBase<SignalDeviceController>.Instance.OpenGameplayChasingMoon(signalDevice2.Config, this.FinishCallback);
				return;
			}
			IMorseCode morseCode = gameplayConfig as IMorseCode;
			if (morseCode != null)
			{
				TsInteractionUtils.RegisterOpenViewName(EUiViewName.SignalDecodeView);
				ControllerBase<SignalDecodeController>.Instance.Open(morseCode.MorseCodeId);
				return;
			}
			IRenjuChess renjuChess = gameplayConfig as IRenjuChess;
			if (renjuChess != null)
			{
				ControllerBase<LevelPickInteractController>.Instance.EnterPickInteractModel(renjuChess, false);
				return;
			}
			ILifePoint lifePoint = gameplayConfig as ILifePoint;
			if (lifePoint != null)
			{
				LifePointView.Params param = new LifePointView.Params
				{
					Config = lifePoint,
					EntityId = num.Value,
					Callback = this.FinishCallback
				};
				this.FinishSendSelfEvent = openSimpleGameplay.FinishSendSelfEvent;
				Entity entity3 = Singleton<EntitySystem>.Instance.Get(num.Value);
				this.CreatureDataId = entity3.GetComponent<CreatureDataComponent>().GetCreatureDataId();
				TsInteractionUtils.RegisterOpenViewName(EUiViewName.LifePointView);
				Singleton<UiManager>.Instance.OpenView(EUiViewName.LifePointView, param, null);
				return;
			}
			IBrokenRock brokenRock = gameplayConfig as IBrokenRock;
			if (brokenRock == null)
			{
				if (gameplayConfig is IFishingRoulette)
				{
					this.FinishSendSelfEvent = openSimpleGameplay.FinishSendSelfEvent;
					Entity entity4 = Singleton<EntitySystem>.Instance.Get(num.Value);
					this.CreatureDataId = entity4.GetComponent<CreatureDataComponent>().GetCreatureDataId();
					ControllerBase<FishingQteController>.Instance.OpenGameplay(entity4, delegate(bool success)
					{
						if (success)
						{
							TsInteractionUtils.RegisterOpenViewName(EUiViewName.FishingQteView);
						}
					});
					return;
				}
				if (gameplayConfig is IDaolingAuthentication)
				{
					TsInteractionUtils.RegisterOpenViewName(EUiViewName.LiuLiDaoLingView);
					Singleton<UiManager>.Instance.OpenView(EUiViewName.LiuLiDaoLingView, null, null);
					return;
				}
				IReigns reigns = gameplayConfig as IReigns;
				if (reigns != null)
				{
					TsInteractionUtils.RegisterOpenViewName(EUiViewName.KingShipMainView);
					IKingShipMainViewOpenData kingShipOpenData = KingShipUtil.GetKingShipOpenData(reigns.ReignsId);
					Singleton<UiManager>.Instance.OpenView(EUiViewName.KingShipLoadingView, kingShipOpenData, null);
					return;
				}
				ITuningStand tuningStand = gameplayConfig as ITuningStand;
				if (tuningStand != null)
				{
					this.FinishSendSelfEvent = openSimpleGameplay.FinishSendSelfEvent;
					Entity entity5 = Singleton<EntitySystem>.Instance.Get(num.Value);
					this.CreatureDataId = entity5.GetComponent<CreatureDataComponent>().GetCreatureDataId();
					TsInteractionUtils.RegisterOpenViewName(EUiViewName.TuningStandView);
					TuningStandView.Params param2 = new TuningStandView.Params
					{
						Config = tuningStand,
						Cb = this.FinishCallback
					};
					Singleton<UiManager>.Instance.OpenView(EUiViewName.TuningStandView, param2, null);
					return;
				}
				IItemInspection itemInspection = gameplayConfig as IItemInspection;
				if (itemInspection != null)
				{
					this.FinishSendSelfEvent = openSimpleGameplay.FinishSendSelfEvent;
					Entity entity6 = Singleton<EntitySystem>.Instance.Get(num.Value);
					this.CreatureDataId = entity6.GetComponent<CreatureDataComponent>().GetCreatureDataId();
					ItemInspectController instance = ControllerBase<ItemInspectController>.Instance;
					IItemInspection config = itemInspection;
					Action<EUiViewName> onBeforeOpenView;
					if ((onBeforeOpenView = LevelEventOpenSimpleGameplay.<>O.<0>__RegisterOpenViewName) == null)
					{
						onBeforeOpenView = (LevelEventOpenSimpleGameplay.<>O.<0>__RegisterOpenViewName = new Action<EUiViewName>(TsInteractionUtils.RegisterOpenViewName));
					}
					instance.OpenItemInspect(config, onBeforeOpenView, delegate(bool result)
					{
						if (result)
						{
							this.FinishCallback();
						}
					});
					return;
				}
				ISceneInspection sceneInspection = gameplayConfig as ISceneInspection;
				if (sceneInspection != null)
				{
					TsInteractionUtils.RegisterOpenViewName(EUiViewName.CheckInteractionView);
					CheckInteractionOpenParam param3 = new CheckInteractionOpenParam
					{
						Config = sceneInspection,
						Context = GeneralContext.Copy(context)
					};
					Singleton<UiManager>.Instance.OpenView(EUiViewName.CheckInteractionView, param3, null);
					return;
				}
				ITraceTracing traceTracing = gameplayConfig as ITraceTracing;
				if (traceTracing != null)
				{
					this.FinishSendSelfEvent = openSimpleGameplay.FinishSendSelfEvent;
					Entity entity7 = Singleton<EntitySystem>.Instance.Get(num.Value);
					this.CreatureDataId = entity7.GetComponent<CreatureDataComponent>().GetCreatureDataId();
					TsInteractionUtils.RegisterOpenViewName(EUiViewName.SeekTraceView);
					SeekTraceController.OpenSeekTrace(traceTracing, num.Value, delegate(bool result)
					{
						if (result)
						{
							this.FinishCallback();
						}
					});
					return;
				}
				IFindSunSpirit findSunSpirit = gameplayConfig as IFindSunSpirit;
				if (findSunSpirit != null)
				{
					this.FinishSendSelfEvent = openSimpleGameplay.FinishSendSelfEvent;
					this.FailSendSelfEvent = openSimpleGameplay.FailSendSelfEvent;
					CreatureDataComponent component = Singleton<EntitySystem>.Instance.Get(num.Value).GetComponent<CreatureDataComponent>();
					this.CreatureDataId = component.GetCreatureDataId();
					TsInteractionUtils.RegisterOpenViewName(EUiViewName.FindSunSpiritView);
					ControllerBase<FindSunSpiritController>.Instance.StartFindSunSpirit(findSunSpirit, this.FinishWithResultCallback, component.GetPbDataId());
					return;
				}
				IDaemonHack daemonHack = gameplayConfig as IDaemonHack;
				if (daemonHack != null)
				{
					this.FinishSendSelfEvent = openSimpleGameplay.FinishSendSelfEvent;
					this.FailSendSelfEvent = openSimpleGameplay.FailSendSelfEvent;
					Entity entity8 = Singleton<EntitySystem>.Instance.Get(num.Value);
					if (entity8 != null)
					{
						CreatureDataComponent component2 = entity8.GetComponent<CreatureDataComponent>();
						this.CreatureDataId = component2.GetCreatureDataId();
					}
					TsInteractionUtils.RegisterOpenViewName(EUiViewName.GolemHackingGameView);
					int configId = 0;
					configId = ControllerBase<GolemHackingController>.Instance.OpenGameplayView(daemonHack.Ids, delegate(bool result)
					{
						if (result)
						{
							this.FinishCallback();
							ControllerBase<GolemHackingController>.Instance.OnUiGameplayFinish(configId);
						}
					}, daemonHack.FinishOnClose.GetValueOrDefault(), null);
					return;
				}
				if (gameplayConfig is IProjectorPuzzle)
				{
					this.FinishSendSelfEvent = openSimpleGameplay.FinishSendSelfEvent;
					this.FailSendSelfEvent = openSimpleGameplay.FailSendSelfEvent;
					CreatureDataComponent component3 = Singleton<EntitySystem>.Instance.Get(num.Value).GetComponent<CreatureDataComponent>();
					this.CreatureDataId = component3.GetCreatureDataId();
					TsInteractionUtils.RegisterOpenViewName(EUiViewName.ProjectorPuzzleView);
					ProjectorPuzzleController.StartProjectorPuzzle(num.Value, this.FinishWithResultCallback);
					return;
				}
				IDollGrab dollGrab = gameplayConfig as IDollGrab;
				if (dollGrab != null)
				{
					this.FinishSendSelfEvent = openSimpleGameplay.FinishSendSelfEvent;
					this.FailSendSelfEvent = openSimpleGameplay.FailSendSelfEvent;
					CreatureDataComponent component4 = Singleton<EntitySystem>.Instance.Get(num.Value).GetComponent<CreatureDataComponent>();
					this.CreatureDataId = component4.GetCreatureDataId();
					ControllerBase<DollGrabMachineController>.Instance.StartDollGrabMachine(dollGrab);
					return;
				}
				IProjectionMachine projectionMachine = gameplayConfig as IProjectionMachine;
				if (projectionMachine != null)
				{
					this.FinishSendSelfEvent = openSimpleGameplay.FinishSendSelfEvent;
					this.FailSendSelfEvent = openSimpleGameplay.FailSendSelfEvent;
					CreatureDataComponent component5 = Singleton<EntitySystem>.Instance.Get(num.Value).GetComponent<CreatureDataComponent>();
					this.CreatureDataId = component5.GetCreatureDataId();
					int pbDataId = component5.GetPbDataId();
					TsInteractionUtils.RegisterOpenViewName(EUiViewName.ProjectionPhotoView);
					ControllerBase<ProjectionPhotoController>.Instance.StartProjectionPhotoGameplay(this.CreatureDataId, pbDataId, projectionMachine, this.FinishWithResultCallback);
					return;
				}
				IDollGrabShowcase dollGrabShowcase = gameplayConfig as IDollGrabShowcase;
				if (dollGrabShowcase != null)
				{
					this.FinishSendSelfEvent = openSimpleGameplay.FinishSendSelfEvent;
					this.FailSendSelfEvent = openSimpleGameplay.FailSendSelfEvent;
					CreatureDataComponent component6 = Singleton<EntitySystem>.Instance.Get(num.Value).GetComponent<CreatureDataComponent>();
					this.CreatureDataId = component6.GetCreatureDataId();
					ControllerBase<DollGrabShowcaseController>.Instance.StartDollGrabShowcaseView(dollGrabShowcase);
					return;
				}
				IWuWaGoGame wuWaGoGame = gameplayConfig as IWuWaGoGame;
				if (wuWaGoGame != null)
				{
					this.FinishSendSelfEvent = openSimpleGameplay.FinishSendSelfEvent;
					this.FailSendSelfEvent = openSimpleGameplay.FailSendSelfEvent;
					Entity entity9 = Singleton<EntitySystem>.Instance.Get(num.Value);
					this.CreatureDataId = entity9.GetComponent<CreatureDataComponent>().GetCreatureDataId();
					ControllerBase<WuWaGoController>.Instance.StartGameplay(wuWaGoGame.LevelCenterId, this.FinishWithResultCallback).Forget<bool>();
					return;
				}
				ISheriffReasoning sheriffReasoning = gameplayConfig as ISheriffReasoning;
				if (sheriffReasoning != null)
				{
					TsInteractionUtils.RegisterOpenViewName(EUiViewName.SheriffMainView);
					ControllerBase<SheriffController>.Instance.OpenAnalysisClueView(sheriffReasoning.Id);
					return;
				}
				IWriteLetter writeLetter = gameplayConfig as IWriteLetter;
				if (writeLetter != null)
				{
					ControllerBase<WriteLetterController>.Instance.OpenWriteLetter(writeLetter);
					return;
				}
				IQteHourglass qteHourglass = gameplayConfig as IQteHourglass;
				if (qteHourglass != null)
				{
					HourglassOpenParam param4 = new HourglassOpenParam
					{
						Config = qteHourglass,
						AutoStartQte = new bool?(false)
					};
					Singleton<UiManager>.Instance.OpenView(EUiViewName.QteHourglassView, param4, null);
					return;
				}
				IInstrumentQteGameplay instrumentQteGameplay = gameplayConfig as IInstrumentQteGameplay;
				if (instrumentQteGameplay == null)
				{
					return;
				}
				MusicalInstrumentQteConfig? config2 = ConfigMusicalInstrumentQteConfigById.GetConfig(instrumentQteGameplay.Id, true);
				if (config2 != null)
				{
					MusicalInstrumentQteConfig valueOrDefault = config2.GetValueOrDefault();
					ControllerBase<MusicalInstrumentController>.Instance.Enter(new MusicalInstrumentEnterParam
					{
						Type = (EInstrumentType)valueOrDefault.InstrumentType,
						QteId = new int?(valueOrDefault.Id)
					}).Forget();
					return;
				}
				Singleton<global::Log>.Instance.Error(ELogModule.MusicalInstrument, ELogAuthor.CB, "乐器Qte:获取乐器Qte配置失败", default(ReadOnlySpan<ValueTuple<string, object>>));
				return;
			}
			else
			{
				GeneralLogicTreeContext generalLogicTreeContext = context as GeneralLogicTreeContext;
				if (generalLogicTreeContext == null || !(context.Type == EGeneralContextType.GeneralLogicTree))
				{
					Singleton<global::Log>.Instance.Error(ELogModule.Event, ELogAuthor.CJH, "大个布偶坚固岩石玩法开启失败：只能由行为中打开", default(ReadOnlySpan<ValueTuple<string, object>>));
					return;
				}
				this.FinishSendSelfEvent = openSimpleGameplay.FinishSendSelfEvent;
				TsInteractionUtils.RegisterOpenViewName(EUiViewName.BigStuffedDollView);
				ControllerBase<BigStuffedDollController>.Instance.Open(brokenRock.Id, generalLogicTreeContext.TreeConfigId, this.FinishCallback);
				return;
			}
		}

		// Token: 0x06044029 RID: 278569 RVA: 0x011A197B File Offset: 0x0119FB7B
		private void OpenCipher(string cipherId)
		{
			ControllerBase<CipherController>.Instance.OpenCipherView(cipherId);
		}

		// Token: 0x0604402A RID: 278570 RVA: 0x011A1988 File Offset: 0x0119FB88
		private void FinishCallbackImpl()
		{
			if (this.FinishSendSelfEvent != null)
			{
				LevelGeneralNetworks.RequestEntitySendEvent(this.CreatureDataId, this.FinishSendSelfEvent);
			}
		}

		// Token: 0x0604402B RID: 278571 RVA: 0x011A19A4 File Offset: 0x0119FBA4
		private void FinishWithResultCallbackImpl(bool result)
		{
			if (result && this.FinishSendSelfEvent != null)
			{
				LevelGeneralNetworks.RequestEntitySendEvent(this.CreatureDataId, this.FinishSendSelfEvent);
			}
			if (!result && this.FailSendSelfEvent != null)
			{
				LevelGeneralNetworks.RequestEntitySendEvent(this.CreatureDataId, this.FailSendSelfEvent);
			}
			this.FinishSendSelfEvent = null;
			this.FailSendSelfEvent = null;
		}

		// Token: 0x0402603C RID: 155708
		[Nullable(2)]
		private string FinishSendSelfEvent;

		// Token: 0x0402603D RID: 155709
		[Nullable(2)]
		private string FailSendSelfEvent;

		// Token: 0x0402603E RID: 155710
		private long CreatureDataId = -1L;

		// Token: 0x0200CA6E RID: 51822
		[CompilerGenerated]
		private static class <>O
		{
			// Token: 0x0403E337 RID: 254775
			[Nullable(0)]
			public static Action<EUiViewName> <0>__RegisterOpenViewName;
		}
	}
}
