using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using Aki.TDConfigMgr.Action;
using Aki.TDConfigMgr.Component;
using CSharpScript.Core.Extension;
using CSharpScript.Game.Camera;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.Plot;
using CSharpScript.Game.Module.Plot.Flow;
using CSharpScript.Game.Module.Plot.PlotView;
using CSharpScript.Game.Ui;
using UnrealEngine;

// Token: 0x020031DE RID: 12766
[NullableContext(2)]
[Nullable(0)]
public class NpcPerformSystemUiState : NpcPerformBaseState
{
	// Token: 0x0601A756 RID: 108374 RVA: 0x007CEDCC File Offset: 0x007CCFCC
	[NullableContext(1)]
	public NpcPerformSystemUiState(EntityHandle owner, ENpcPerformState state, [Nullable(new byte[]
	{
		2,
		1
	})] StateMachine<EntityHandle, ENpcPerformState> stateMachine = null) : base(owner, state, stateMachine)
	{
	}

	// Token: 0x170023E8 RID: 9192
	// (get) Token: 0x0601A757 RID: 108375 RVA: 0x007CEE1D File Offset: 0x007CD01D
	// (set) Token: 0x0601A758 RID: 108376 RVA: 0x007CEE25 File Offset: 0x007CD025
	public EUiViewName? SystemUiViewName
	{
		get
		{
			return this.UiViewName;
		}
		set
		{
			this.UiViewName = value;
		}
	}

	// Token: 0x170023E9 RID: 9193
	// (get) Token: 0x0601A759 RID: 108377 RVA: 0x007CEE2E File Offset: 0x007CD02E
	// (set) Token: 0x0601A75A RID: 108378 RVA: 0x007CEE36 File Offset: 0x007CD036
	public int BoardId
	{
		get
		{
			return this.ShopId;
		}
		set
		{
			this.ShopId = value;
		}
	}

	// Token: 0x0601A75B RID: 108379 RVA: 0x007CEE40 File Offset: 0x007CD040
	protected override void OnCreate(IEntityArgs args)
	{
		base.OnCreate(args);
		Aki.TDConfigMgr.Component.NpcPerformComponent p = args.GetP1<Aki.TDConfigMgr.Component.NpcPerformComponent>();
		if (((p != null) ? p.ShowOnUiInteract : null) == null)
		{
			return;
		}
		this.InitShopPerformParams(p.ShowOnUiInteract);
		this.PlotPositionMap[EUiViewName.MingSuView] = EPlotLowLevelPosition.Right;
	}

	// Token: 0x0601A75C RID: 108380 RVA: 0x007CEE88 File Offset: 0x007CD088
	protected override void OnEnter(ENpcPerformState? lastState)
	{
		CommonNpcPerformComponent performComp = this.PerformComp;
		if (performComp != null)
		{
			performComp.SightTarget(new OneOf<BaseActorComponent, global::Vector, AActor>?(ControllerBase<CameraController>.Instance.MainModel.WidgetCamera.DisplayComponent.CineCamera), EStareActionType.SystemUI);
		}
		if (this.UiViewName == null)
		{
			return;
		}
		if (this.UiViewName == EUiViewName.ForgingRootView)
		{
			return;
		}
		NpcShopPerformParams shopParams = this.ShopParams;
		if (shopParams != null)
		{
			shopParams.TryLoadAllMontage();
		}
		if (Singleton<UiManager>.Instance.IsViewShow(this.UiViewName.Value))
		{
			this.IsViewOpening = true;
		}
		else
		{
			this.IsViewOpening = false;
			Singleton<EventSystem>.Instance.Add<EUiViewName, int>(EEventName.OpenView, new Action<EUiViewName, int>(this.OnOpenView));
		}
		this.AddEvents();
		this.SetForcedLod(true);
		this.TryPlayEnterMontage();
		this.TryPlayEnterFlow();
		this.InitCoolDown();
	}

	// Token: 0x0601A75D RID: 108381 RVA: 0x007CEF70 File Offset: 0x007CD170
	protected override void OnUpdate(float delta)
	{
		if (this.NpcUiInteractType == ENpcUiInteractType.AntiqueShop || this.NpcUiInteractType == ENpcUiInteractType.ChengXiaoShanShop)
		{
			return;
		}
		this.PlayStandByMontage();
	}

	// Token: 0x0601A75E RID: 108382 RVA: 0x007CEF8C File Offset: 0x007CD18C
	protected override void OnExit(ENpcPerformState nextState)
	{
		this.SetForcedLod(false);
		this.SetNpcAndChildEnable();
		CommonNpcPerformComponent performComp = this.PerformComp;
		if (performComp == null)
		{
			return;
		}
		performComp.SightTarget(null, EStareActionType.SystemUI);
	}

	// Token: 0x0601A75F RID: 108383 RVA: 0x007CEFC0 File Offset: 0x007CD1C0
	protected override void OnDestroy()
	{
		if (this.NpcPerformSequence != null)
		{
			this.NpcPerformSequence.Destroy();
			this.NpcPerformSequence = null;
		}
		this.DisableEntities.Clear();
	}

	// Token: 0x0601A760 RID: 108384 RVA: 0x007CEFE7 File Offset: 0x007CD1E7
	public override bool CanChangeFrom(ENpcPerformState fromState)
	{
		return fromState != ENpcPerformState.Destroy;
	}

	// Token: 0x0601A761 RID: 108385 RVA: 0x007CEFF4 File Offset: 0x007CD1F4
	[NullableContext(1)]
	private void InitShopPerformParams(INpcUiInteractType config)
	{
		this.NpcUiInteractType = config.Type;
		this.ShopParams = new NpcShopPerformParams();
		INpcUiInteractOnAntiqueShop npcUiInteractOnAntiqueShop = config as INpcUiInteractOnAntiqueShop;
		if (npcUiInteractOnAntiqueShop != null)
		{
			this.ShopParams.EnterMontageInfo = new NpcSystemUiMontageInfo(npcUiInteractOnAntiqueShop.EnterMontage);
			this.ShopParams.StandByMontageInfo = new NpcSystemUiMontageInfo(npcUiInteractOnAntiqueShop.StandByMontage);
			this.ShopParams.ShopSuccessMontageInfo = new NpcSystemUiMontageInfo(npcUiInteractOnAntiqueShop.ShopSuccessMontage);
			this.ShopParams.EnterFlow = npcUiInteractOnAntiqueShop.EnterFlow;
			this.ShopParams.ShopSuccessFlow = npcUiInteractOnAntiqueShop.ShopSuccessFlow;
			this.ShopParams.ShopFailedFlow = npcUiInteractOnAntiqueShop.ShopFailedFlow;
			this.ShopParams.UpgradeSequencePath = npcUiInteractOnAntiqueShop.UpgradeSequence;
			this.ShopParams.ShowNpcWhilePlayingSequence = false;
			return;
		}
		INpcUiInteractOnChengXiaoShanShop npcUiInteractOnChengXiaoShanShop = config as INpcUiInteractOnChengXiaoShanShop;
		if (npcUiInteractOnChengXiaoShanShop != null)
		{
			this.ShopParams.EnterMontageInfo = new NpcSystemUiMontageInfo(npcUiInteractOnChengXiaoShanShop.EnterMontage);
			this.ShopParams.StandByMontageInfo = new NpcSystemUiMontageInfo(npcUiInteractOnChengXiaoShanShop.StandByMontage);
			this.ShopParams.ShopSuccessMontageInfo = new NpcSystemUiMontageInfo(npcUiInteractOnChengXiaoShanShop.ShopSuccessMontage);
			this.ShopParams.EnterFlow = npcUiInteractOnChengXiaoShanShop.EnterFlow;
			this.ShopParams.ShopSuccessFlow = npcUiInteractOnChengXiaoShanShop.ShopSuccessFlow;
			this.ShopParams.ShopFailedFlow = npcUiInteractOnChengXiaoShanShop.ShopFailedFlow;
			this.ShopParams.UpgradeSequencePath = npcUiInteractOnChengXiaoShanShop.UpgradeSequence;
			this.ShopParams.FinishDeliverySequence = npcUiInteractOnChengXiaoShanShop.FinishDeliverySequence;
			this.ShopParams.ShowNpcWhilePlayingSequence = npcUiInteractOnChengXiaoShanShop.ShowNpcWhilePlayingSequence.GetValueOrDefault();
			return;
		}
		INpcUiInteractOnGramophone npcUiInteractOnGramophone = config as INpcUiInteractOnGramophone;
		if (npcUiInteractOnGramophone == null)
		{
			if (!(config is INpcUiInteractOnHandInItem))
			{
				INpcUiInteractOnShop npcUiInteractOnShop = config as INpcUiInteractOnShop;
				if (npcUiInteractOnShop != null)
				{
					this.ShopParams.EnterMontageInfo = new NpcSystemUiMontageInfo(npcUiInteractOnShop.EnterMontage);
					this.ShopParams.StandByMontageInfo = new NpcSystemUiMontageInfo(npcUiInteractOnShop.StandByMontage);
					this.ShopParams.ShopSuccessMontageInfo = new NpcSystemUiMontageInfo(npcUiInteractOnShop.ShopSuccessMontage);
					this.ShopParams.EnterFlow = npcUiInteractOnShop.EnterFlow;
					this.ShopParams.ShopSuccessFlow = npcUiInteractOnShop.ShopSuccessFlow;
					this.ShopParams.ShopFailedFlow = npcUiInteractOnShop.ShopFailedFlow;
					this.ShopParams.ShowNpcWhilePlayingSequence = false;
					return;
				}
				INpcUiInteractOnShopNew npcUiInteractOnShopNew = config as INpcUiInteractOnShopNew;
				if (npcUiInteractOnShopNew != null)
				{
					this.ShopParams.EnterMontageInfo = new NpcSystemUiMontageInfo(npcUiInteractOnShopNew.EnterMontage);
					this.ShopParams.StandByMontageInfo = new NpcSystemUiMontageInfo(npcUiInteractOnShopNew.StandByMontage);
					this.ShopParams.ShopSuccessMontageInfo = new NpcSystemUiMontageInfo(npcUiInteractOnShopNew.ShopSuccessMontage);
					this.ShopParams.EnterFlow = npcUiInteractOnShopNew.EnterFlow;
					this.ShopParams.ShopSuccessFlow = npcUiInteractOnShopNew.ShopSuccessFlow;
					this.ShopParams.ShopFailedFlow = npcUiInteractOnShopNew.ShopFailedFlow;
					this.ShopParams.ShowNpcWhilePlayingSequence = false;
					return;
				}
				INpcUiInteractOnSoundBox3 npcUiInteractOnSoundBox = config as INpcUiInteractOnSoundBox3;
				if (npcUiInteractOnSoundBox == null)
				{
					INpcUiInteractOnSunSpirit npcUiInteractOnSunSpirit = config as INpcUiInteractOnSunSpirit;
					if (npcUiInteractOnSunSpirit == null)
					{
						INpcUiInteractOnSoundBox35 npcUiInteractOnSoundBox2 = config as INpcUiInteractOnSoundBox35;
						if (npcUiInteractOnSoundBox2 == null)
						{
							INpcUiInteractOnVillageInfr npcUiInteractOnVillageInfr = config as INpcUiInteractOnVillageInfr;
							if (npcUiInteractOnVillageInfr != null)
							{
								this.ShopParams.EnterMontageInfo = new NpcSystemUiMontageInfo(npcUiInteractOnVillageInfr.EnterMontage);
								this.ShopParams.DeliverSuccessMontageInfo = new NpcSystemUiMontageInfo(npcUiInteractOnVillageInfr.DeliverSuccessMontage);
								this.ShopParams.CompleteMontageInfo = new NpcSystemUiMontageInfo(npcUiInteractOnVillageInfr.CompleteMontage);
								this.ShopParams.EnterFlow = npcUiInteractOnVillageInfr.EnterFlow;
								this.ShopParams.DeliverSuccessFlow = npcUiInteractOnVillageInfr.DeliverSuccessFlow;
								this.ShopParams.CompleteFlow = npcUiInteractOnVillageInfr.CompleteFlow;
								return;
							}
							INpcUiInteractOnDollGrabDelivery npcUiInteractOnDollGrabDelivery = config as INpcUiInteractOnDollGrabDelivery;
							if (npcUiInteractOnDollGrabDelivery == null)
							{
								return;
							}
							this.ShopParams.FirstDollMontageInfo = new NpcSystemUiMontageInfo(npcUiInteractOnDollGrabDelivery.OnFirstAchievementPerform.EventMontage);
							this.ShopParams.FirstDollMontageInfo.Duration = npcUiInteractOnDollGrabDelivery.OnFirstAchievementPerform.PerformDuration;
							this.ShopParams.SubsequentDollMontageInfo = new NpcSystemUiMontageInfo(npcUiInteractOnDollGrabDelivery.OnSubsequentAchievementPerform.EventMontage);
							this.ShopParams.SubsequentDollMontageInfo.Duration = npcUiInteractOnDollGrabDelivery.OnSubsequentAchievementPerform.PerformDuration;
							this.ShopParams.FirstDollPartMontageInfo = new NpcSystemUiMontageInfo(npcUiInteractOnDollGrabDelivery.OnNeverAchievementPerform.EventMontage);
							this.ShopParams.FirstDollPartMontageInfo.Duration = npcUiInteractOnDollGrabDelivery.OnNeverAchievementPerform.PerformDuration;
							this.ShopParams.SubsequentDollPartMontageInfo = new NpcSystemUiMontageInfo(npcUiInteractOnDollGrabDelivery.OnAlreadyAchievementPerform.EventMontage);
							this.ShopParams.SubsequentDollPartMontageInfo.Duration = npcUiInteractOnDollGrabDelivery.OnAlreadyAchievementPerform.PerformDuration;
							this.ShopParams.FirstDollFlow = npcUiInteractOnDollGrabDelivery.OnFirstAchievementPerform.Flow;
							this.ShopParams.SubsequentDollFlow = npcUiInteractOnDollGrabDelivery.OnSubsequentAchievementPerform.Flow;
							this.ShopParams.FirstDollPartFlow = npcUiInteractOnDollGrabDelivery.OnNeverAchievementPerform.Flow;
							this.ShopParams.SubsequentDollPartFlow = npcUiInteractOnDollGrabDelivery.OnAlreadyAchievementPerform.Flow;
						}
						else
						{
							this.ShopParams.EnterMontageInfo = new NpcSystemUiMontageInfo(npcUiInteractOnSoundBox2.EnterMontage);
							this.ShopParams.StandByMontageInfo = new NpcSystemUiMontageInfo(npcUiInteractOnSoundBox2.StandByMontage);
							this.ShopParams.ShopSuccessMontageInfo = new NpcSystemUiMontageInfo(npcUiInteractOnSoundBox2.ShopSuccessMontage);
							this.ShopParams.EnterFlow = npcUiInteractOnSoundBox2.EnterFlow;
							this.ShopParams.ShopSuccessFlow = npcUiInteractOnSoundBox2.ShopSuccessFlow;
							this.ShopParams.ShopFailedFlow = npcUiInteractOnSoundBox2.ShopFailedFlow;
							this.ShopParams.UpgradeFlow = npcUiInteractOnSoundBox2.UpgradeFlow;
							this.ShopParams.UpgradeSequencePath = npcUiInteractOnSoundBox2.UpgradeSequence;
							this.ShopParams.ShowNpcWhilePlayingSequence = false;
							IMontageAsset montageAsset = npcUiInteractOnSoundBox2.ExitMontage as IMontageAsset;
							if (montageAsset != null)
							{
								this.ShopParams.ExitMontageInfo = new NpcSystemUiMontageInfo(montageAsset.Asset);
								return;
							}
						}
					}
					else
					{
						this.ShopParams.EnterMontageInfo = new NpcSystemUiMontageInfo(npcUiInteractOnSunSpirit.EnterMontage);
						this.ShopParams.StandByMontageInfo = new NpcSystemUiMontageInfo(npcUiInteractOnSunSpirit.StandByMontage);
						this.ShopParams.ShopSuccessMontageInfo = new NpcSystemUiMontageInfo(npcUiInteractOnSunSpirit.ShopSuccessMontage);
						this.ShopParams.EnterFlow = npcUiInteractOnSunSpirit.EnterFlow;
						this.ShopParams.ShopSuccessFlow = npcUiInteractOnSunSpirit.ShopSuccessFlow;
						this.ShopParams.ShopFailedFlow = npcUiInteractOnSunSpirit.ShopFailedFlow;
						this.ShopParams.UpgradeFlow = npcUiInteractOnSunSpirit.UpgradeFlow;
						this.ShopParams.UpgradeSequencePath = npcUiInteractOnSunSpirit.UpgradeSequence;
						this.ShopParams.ShowNpcWhilePlayingSequence = false;
						IMontageAsset montageAsset2 = npcUiInteractOnSunSpirit.ExitMontage as IMontageAsset;
						if (montageAsset2 != null)
						{
							this.ShopParams.ExitMontageInfo = new NpcSystemUiMontageInfo(montageAsset2.Asset);
							return;
						}
					}
				}
				else
				{
					this.ShopParams.EnterMontageInfo = new NpcSystemUiMontageInfo(npcUiInteractOnSoundBox.EnterMontage);
					this.ShopParams.StandByMontageInfo = new NpcSystemUiMontageInfo(npcUiInteractOnSoundBox.StandByMontage);
					this.ShopParams.ShopSuccessMontageInfo = new NpcSystemUiMontageInfo(npcUiInteractOnSoundBox.ShopSuccessMontage);
					this.ShopParams.EnterFlow = npcUiInteractOnSoundBox.EnterFlow;
					this.ShopParams.ShopSuccessFlow = npcUiInteractOnSoundBox.ShopSuccessFlow;
					this.ShopParams.ShopFailedFlow = npcUiInteractOnSoundBox.ShopFailedFlow;
					this.ShopParams.UpgradeFlow = npcUiInteractOnSoundBox.UpgradeFlow;
					this.ShopParams.UpgradeSequencePath = npcUiInteractOnSoundBox.UpgradeSequence;
					this.ShopParams.ShowNpcWhilePlayingSequence = false;
					IMontageAsset montageAsset3 = npcUiInteractOnSoundBox.ExitMontage as IMontageAsset;
					if (montageAsset3 != null)
					{
						this.ShopParams.ExitMontageInfo = new NpcSystemUiMontageInfo(montageAsset3.Asset);
						return;
					}
				}
			}
			return;
		}
		this.ShopParams.EnterMontageInfo = new NpcSystemUiMontageInfo(npcUiInteractOnGramophone.EnterMontage);
		this.ShopParams.StandByMontageInfo = new NpcSystemUiMontageInfo(npcUiInteractOnGramophone.StandByMontage);
		this.ShopParams.SwitchMusicMontageInfo = new NpcSystemUiMontageInfo(npcUiInteractOnGramophone.SwitchMusicMontage);
		this.ShopParams.ExitMontageInfo = new NpcSystemUiMontageInfo(npcUiInteractOnGramophone.ExitMontage);
		this.ShopParams.EnterFlow = npcUiInteractOnGramophone.EnterFlow;
		this.ShopParams.ShopSuccessFlow = npcUiInteractOnGramophone.SuccessFlow;
		this.ShopParams.ShopFailedFlow = npcUiInteractOnGramophone.FailedFlow;
	}

	// Token: 0x0601A762 RID: 108386 RVA: 0x007CF7E0 File Offset: 0x007CD9E0
	private unsafe void TryPlayEnterMontage()
	{
		NpcShopPerformParams shopParams = this.ShopParams;
		string path;
		if (shopParams == null)
		{
			path = null;
		}
		else
		{
			NpcSystemUiMontageInfo enterMontageInfo = shopParams.EnterMontageInfo;
			path = ((enterMontageInfo != null) ? enterMontageInfo.Path : null);
		}
		if (!NpcSystemUiMontageInfo.IsPathValid(path))
		{
			return;
		}
		if (this.UiViewName == null || !this.IsViewOpening)
		{
			return;
		}
		global::Log instance = Singleton<global::Log>.Instance;
		ELogModule module = ELogModule.NPC;
		ELogAuthor author = ELogAuthor.WLJ;
		string message = "[NpcPerformSystemUiState]当打开界面时,播放进入界面的动作 EnterMontage";
		<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
		*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("EntityId", this.Owner.Id);
		*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("ViewName", this.UiViewName);
		instance.Info(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
		bool? isLoop = (this.NpcUiInteractType == ENpcUiInteractType.AntiqueShop || this.NpcUiInteractType == ENpcUiInteractType.ChengXiaoShanShop) ? null : new bool?(false);
		base.PlayMontage(new IPlayMontageParam
		{
			MontagePath = this.ShopParams.EnterMontageInfo.Path,
			IsLoop = isLoop,
			AnimStateParam = this.ShopParams.EnterMontageInfo.State,
			OnPlayCallback = delegate(UAnimMontage montage)
			{
				if (this.IsViewOpening)
				{
					return;
				}
				NpcShopPerformParams shopParams2 = this.ShopParams;
				bool flag;
				if (shopParams2 == null)
				{
					flag = true;
				}
				else
				{
					NpcSystemUiMontageInfo enterMontageInfo2 = shopParams2.EnterMontageInfo;
					bool? flag2;
					if (enterMontageInfo2 == null)
					{
						flag2 = null;
					}
					else
					{
						UAnimMontage asset = enterMontageInfo2.Asset;
						flag2 = ((asset != null) ? new bool?(asset.IsValid()) : null);
					}
					bool? flag3 = flag2;
					flag = !flag3.GetValueOrDefault();
				}
				if (flag)
				{
					return;
				}
				base.StopMontage(new IStopMontageParam
				{
					Montage = this.ShopParams.EnterMontageInfo.Asset
				});
			}
		});
	}

	// Token: 0x0601A763 RID: 108387 RVA: 0x007CF90C File Offset: 0x007CDB0C
	private unsafe void TryPlayEnterFlow()
	{
		NpcShopPerformParams shopParams = this.ShopParams;
		if (((shopParams != null) ? shopParams.EnterFlow : null) == null || this.UiViewName == null)
		{
			return;
		}
		global::Log instance = Singleton<global::Log>.Instance;
		ELogModule module = ELogModule.NPC;
		ELogAuthor author = ELogAuthor.WLJ;
		string message = "[NpcPerformSystemUiState]当打开界面时,播放进入界面的D级剧情 EnterFlow";
		<>y__InlineArray3<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray3<ValueTuple<string, object>>);
		*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("EntityId", this.Owner.Id);
		*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("ViewName", this.UiViewName);
		*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 2) = new ValueTuple<string, object>("FlowId", this.ShopParams.EnterFlow.FlowId);
		instance.Info(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 3));
		this.StartFlow(this.ShopParams.EnterFlow, this.UiViewName.Value, false);
	}

	// Token: 0x0601A764 RID: 108388 RVA: 0x007CF9F4 File Offset: 0x007CDBF4
	private void InitCoolDown()
	{
		this.BuySuccessNpcDialogueTimeInterval = (double)ConfigCommonParamById.GetIntConfig("BuySuccessNpcDialogueTimeInterval").GetValueOrDefault();
		this.StandByMontageStartTimeStamp = Singleton<Time>.Instance.WorldTimeSeconds;
		this.StandByMontageCd = (double)((Singleton<UiManager>.Instance.IsViewOpen(EUiViewName.PupuVillageItemView) || Singleton<UiManager>.Instance.IsViewOpen(EUiViewName.PhonographView)) ? 1f : 20f);
		this.ShopSuccessStartTimeStamp = Singleton<Time>.Instance.WorldTimeSeconds;
		this.ShopSuccessCd = 0.0;
	}

	// Token: 0x0601A765 RID: 108389 RVA: 0x007CFA80 File Offset: 0x007CDC80
	private void ResetCoolDown()
	{
		this.LastPlaySwitchMontageTime = 0.0;
		this.StandByMontageStartTimeStamp = 0.0;
		this.StandByMontageCd = 0.0;
		this.ShopSuccessCd = 0.0;
		this.ShopSuccessStartTimeStamp = 0.0;
	}

	// Token: 0x0601A766 RID: 108390 RVA: 0x007CFAD8 File Offset: 0x007CDCD8
	private void FinishUiOpenPerformance()
	{
		if (this.NpcUiInteractType == ENpcUiInteractType.AntiqueShop || this.NpcUiInteractType == ENpcUiInteractType.ChengXiaoShanShop)
		{
			NpcShopPerformParams shopParams = this.ShopParams;
			bool flag;
			if (shopParams == null)
			{
				flag = false;
			}
			else
			{
				NpcSystemUiMontageInfo enterMontageInfo = shopParams.EnterMontageInfo;
				bool? flag2;
				if (enterMontageInfo == null)
				{
					flag2 = null;
				}
				else
				{
					UAnimMontage asset = enterMontageInfo.Asset;
					flag2 = ((asset != null) ? new bool?(asset.IsValid()) : null);
				}
				bool? flag3 = flag2;
				flag = flag3.GetValueOrDefault();
			}
			if (flag)
			{
				base.PlayMontage(new IPlayMontageParam
				{
					MontageAsset = this.ShopParams.EnterMontageInfo.Asset,
					InSectionToStartMontageAt = new FName?(Singleton<CharacterNameDefines>.Instance.END_SECTION),
					AnimStateParam = this.ShopParams.EnterMontageInfo.State
				});
			}
		}
		this.SetNpcAndChildEnable();
		this.IsViewOpening = false;
		this.UiViewName = null;
		this.ResetCoolDown();
		this.RemoveEvents();
	}

	// Token: 0x0601A767 RID: 108391 RVA: 0x007CFBB4 File Offset: 0x007CDDB4
	private void AddEvents()
	{
		Singleton<EventSystem>.Instance.Add<EUiViewName, int>(EEventName.CloseView, new Action<EUiViewName, int>(this.OnCloseView));
		Singleton<EventSystem>.Instance.Add<int, int>(EEventName.BoughtItem, new Action<int, int>(this.OnBuySuccess));
		Singleton<EventSystem>.Instance.Add(EEventName.OnSubmitItemSuccess, new Action(this.OnSubmitItemSuccess));
		Singleton<EventSystem>.Instance.Add(EEventName.OnSubmitItemFail, new Action(this.OnSubmitItemFail));
		Singleton<EventSystem>.Instance.Add(EEventName.OnSubmitItemLevelUp, new Action(this.OnSubmitItemLevelUp));
		Singleton<EventSystem>.Instance.Add(EEventName.OnSubmitItemLevelMax, new Action(this.OnSubmitItemLevelMax));
		Singleton<EventSystem>.Instance.Add(EEventName.OnPhonographSwitchMusic, new Action(this.OnPhonographSwitchMusic));
		Singleton<EventSystem>.Instance.Add(EEventName.OnExitNpcInteract, new Action(this.OnExitNpcInteract));
		Singleton<EventSystem>.Instance.Add(EEventName.VillageDeliverySuccess, new Action(this.OnVillageDeliverySuccess));
		Singleton<EventSystem>.Instance.Add(EEventName.VillageCompleteDelivery, new Action(this.OnVillageCompleteDelivery));
		Singleton<EventSystem>.Instance.Add<bool, bool>(EEventName.OnDollGrabMachineDelivery, new Action<bool, bool>(this.OnDollGrabMachineDelivery));
	}

	// Token: 0x0601A768 RID: 108392 RVA: 0x007CFCF4 File Offset: 0x007CDEF4
	private void RemoveEvents()
	{
		Singleton<EventSystem>.Instance.Remove<EUiViewName, int>(EEventName.CloseView, new Action<EUiViewName, int>(this.OnCloseView));
		Singleton<EventSystem>.Instance.Remove<int, int>(EEventName.BoughtItem, new Action<int, int>(this.OnBuySuccess));
		Singleton<EventSystem>.Instance.Remove(EEventName.OnSubmitItemSuccess, new Action(this.OnSubmitItemSuccess));
		Singleton<EventSystem>.Instance.Remove(EEventName.OnSubmitItemFail, new Action(this.OnSubmitItemFail));
		Singleton<EventSystem>.Instance.Remove(EEventName.OnSubmitItemLevelUp, new Action(this.OnSubmitItemLevelUp));
		Singleton<EventSystem>.Instance.Remove(EEventName.OnSubmitItemLevelMax, new Action(this.OnSubmitItemLevelMax));
		Singleton<EventSystem>.Instance.Remove(EEventName.OnPhonographSwitchMusic, new Action(this.OnPhonographSwitchMusic));
		Singleton<EventSystem>.Instance.Remove(EEventName.OnExitNpcInteract, new Action(this.OnExitNpcInteract));
		Singleton<EventSystem>.Instance.Remove(EEventName.VillageDeliverySuccess, new Action(this.OnVillageDeliverySuccess));
		Singleton<EventSystem>.Instance.Remove(EEventName.VillageCompleteDelivery, new Action(this.OnVillageCompleteDelivery));
		Singleton<EventSystem>.Instance.Remove<bool, bool>(EEventName.OnDollGrabMachineDelivery, new Action<bool, bool>(this.OnDollGrabMachineDelivery));
	}

	// Token: 0x0601A769 RID: 108393 RVA: 0x007CFE34 File Offset: 0x007CE034
	private void OnOpenView(EUiViewName viewName, int viewId)
	{
		if (this.UiViewName == null)
		{
			Singleton<EventSystem>.Instance.Remove<EUiViewName, int>(EEventName.OpenView, new Action<EUiViewName, int>(this.OnOpenView));
			return;
		}
		if (this.UiViewName != viewName)
		{
			return;
		}
		this.IsViewOpening = true;
		Singleton<EventSystem>.Instance.Remove<EUiViewName, int>(EEventName.OpenView, new Action<EUiViewName, int>(this.OnOpenView));
		this.TryPlayEnterMontage();
	}

	// Token: 0x0601A76A RID: 108394 RVA: 0x007CFEB4 File Offset: 0x007CE0B4
	private void OnCloseView(EUiViewName viewName, int viewId)
	{
		if (this.UiViewName == null)
		{
			this.RemoveEvents();
			return;
		}
		if (this.UiViewName != viewName)
		{
			return;
		}
		this.FinishUiOpenPerformance();
		this.StateMachine.Switch(ENpcPerformState.Idle);
	}

	// Token: 0x0601A76B RID: 108395 RVA: 0x007CFF10 File Offset: 0x007CE110
	private unsafe void OnBuySuccess(int shopId, int id)
	{
		if (this.UiViewName == null)
		{
			return;
		}
		if (shopId != this.ShopId)
		{
			return;
		}
		PlotModel instance = ModelBase<PlotModel>.Instance;
		if (instance.IsInPlot && instance.PlotConfig.PlotLevel.GetValueOrDefault() == EPlotLevel.LevelD)
		{
			global::Log instance2 = Singleton<global::Log>.Instance;
			ELogModule module = ELogModule.NPC;
			ELogAuthor author = ELogAuthor.WLJ;
			string message = "[NpcPerformSystemUiState]当前正在播放D级剧情，不会再播放购买成功的D级剧情";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("EntityId", this.Owner.Id);
			instance2.Info(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			return;
		}
		double worldTime = Singleton<Time>.Instance.WorldTime;
		if (worldTime < this.CanPlayBuySuccessTimeStamp)
		{
			global::Log instance3 = Singleton<global::Log>.Instance;
			ELogModule module2 = ELogModule.NPC;
			ELogAuthor author2 = ELogAuthor.WLJ;
			string message2 = "[NpcPerformSystemUiState]处于冷却间隔中，无法再次播放购买成功D级剧情";
			<>y__InlineArray3<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray3<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("worldTime", worldTime);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("CanPlayBuySuccessTimeStamp", this.CanPlayBuySuccessTimeStamp);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 2) = new ValueTuple<string, object>("BuySuccessNpcDialogueTimeInterval", this.BuySuccessNpcDialogueTimeInterval);
			instance3.Info(module2, author2, message2, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 3));
			return;
		}
		this.CanPlayBuySuccessTimeStamp = worldTime + this.BuySuccessNpcDialogueTimeInterval;
		global::Log instance4 = Singleton<global::Log>.Instance;
		ELogModule module3 = ELogModule.NPC;
		ELogAuthor author3 = ELogAuthor.WLJ;
		string message3 = "[NpcPerformSystemUiState]当购买成功时播放提交成功动作 ShopSuccessMontage";
		<>y__InlineArray4<ValueTuple<string, object>> <>y__InlineArray2 = default(<>y__InlineArray4<ValueTuple<string, object>>);
		*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 0) = new ValueTuple<string, object>("EntityId", this.Owner.Id);
		*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 1) = new ValueTuple<string, object>("worldTime", worldTime);
		*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 2) = new ValueTuple<string, object>("BuySuccessNpcDialogueTimeInterval", this.BuySuccessNpcDialogueTimeInterval);
		*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 3) = new ValueTuple<string, object>("CanPlayBuySuccessTimeStamp", this.CanPlayBuySuccessTimeStamp);
		instance4.Info(module3, author3, message3, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray2, 4));
		NpcShopPerformParams shopParams = this.ShopParams;
		this.StartFlow((shopParams != null) ? shopParams.ShopSuccessFlow : null, this.UiViewName.Value, true);
		this.PlayBuySuccessMontage();
	}

	// Token: 0x0601A76C RID: 108396 RVA: 0x007D0118 File Offset: 0x007CE318
	private void OnPhonographSwitchMusic()
	{
		if (this.NpcUiInteractType != ENpcUiInteractType.Gramophone)
		{
			return;
		}
		NpcShopPerformParams shopParams = this.ShopParams;
		bool flag;
		if (shopParams == null)
		{
			flag = true;
		}
		else
		{
			NpcSystemUiMontageInfo switchMusicMontageInfo = shopParams.SwitchMusicMontageInfo;
			bool? flag2;
			if (switchMusicMontageInfo == null)
			{
				flag2 = null;
			}
			else
			{
				UAnimMontage asset = switchMusicMontageInfo.Asset;
				flag2 = ((asset != null) ? new bool?(asset.IsValid()) : null);
			}
			bool? flag3 = flag2;
			flag = !flag3.GetValueOrDefault();
		}
		if (flag)
		{
			return;
		}
		if (Singleton<Time>.Instance.WorldTime - this.LastPlaySwitchMontageTime < 2000.0)
		{
			return;
		}
		this.LastPlaySwitchMontageTime = Singleton<Time>.Instance.WorldTime;
		this.StandByMontageStartTimeStamp = Singleton<Time>.Instance.WorldTimeSeconds;
		this.StandByMontageCd = (double)(this.ShopParams.SwitchMusicMontageInfo.Asset.SequenceLength - 0.1f);
		base.PlayMontage(new IPlayMontageParam
		{
			MontageAsset = this.ShopParams.SwitchMusicMontageInfo.Asset,
			IsLoop = new bool?(false),
			AnimStateParam = this.ShopParams.SwitchMusicMontageInfo.State
		});
	}

	// Token: 0x0601A76D RID: 108397 RVA: 0x007D0220 File Offset: 0x007CE420
	private void OnExitNpcInteract()
	{
		if (this.NpcUiInteractType != ENpcUiInteractType.Gramophone && this.NpcUiInteractType != ENpcUiInteractType.SoundBox3 && this.NpcUiInteractType != ENpcUiInteractType.SunSpirit && this.NpcUiInteractType != ENpcUiInteractType.SoundBox35)
		{
			return;
		}
		NpcShopPerformParams shopParams = this.ShopParams;
		bool flag;
		if (shopParams == null)
		{
			flag = true;
		}
		else
		{
			NpcSystemUiMontageInfo exitMontageInfo = shopParams.ExitMontageInfo;
			bool? flag2;
			if (exitMontageInfo == null)
			{
				flag2 = null;
			}
			else
			{
				UAnimMontage asset = exitMontageInfo.Asset;
				flag2 = ((asset != null) ? new bool?(asset.IsValid()) : null);
			}
			bool? flag3 = flag2;
			flag = !flag3.GetValueOrDefault();
		}
		if (flag)
		{
			return;
		}
		base.PlayMontage(new IPlayMontageParam
		{
			MontageAsset = this.ShopParams.ExitMontageInfo.Asset,
			IsLoop = new bool?(false),
			AnimStateParam = this.ShopParams.ExitMontageInfo.State
		});
	}

	// Token: 0x0601A76E RID: 108398 RVA: 0x007D02E4 File Offset: 0x007CE4E4
	private unsafe void OnVillageDeliverySuccess()
	{
		if (this.UiViewName == null)
		{
			return;
		}
		global::Log instance = Singleton<global::Log>.Instance;
		ELogModule module = ELogModule.NPC;
		ELogAuthor author = ELogAuthor.LYX;
		string message = "[CollectionItemDisplay]当提交物品成功时,播放提交成功剧情 EnterFlow,播放提交成功动作 ShopSuccessMontage";
		<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
		*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("EntityId", this.Owner.Id);
		ref ValueTuple<string, object> ptr = ref <PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1);
		string item = "FlowId";
		NpcShopPerformParams shopParams = this.ShopParams;
		int? num;
		if (shopParams == null)
		{
			num = null;
		}
		else
		{
			PlayFlow deliverSuccessFlow = shopParams.DeliverSuccessFlow;
			num = ((deliverSuccessFlow != null) ? new int?(deliverSuccessFlow.FlowId) : null);
		}
		ptr = new ValueTuple<string, object>(item, num);
		instance.Info(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
		NpcShopPerformParams shopParams2 = this.ShopParams;
		if (((shopParams2 != null) ? shopParams2.DeliverSuccessFlow : null) != null)
		{
			ControllerBase<FlowController>.Instance.StartFlow(this.ShopParams.DeliverSuccessFlow.FlowListName, this.ShopParams.DeliverSuccessFlow.FlowId, this.ShopParams.DeliverSuccessFlow.StateId, null, 0L, false, false, false, null);
			Singleton<EventSystem>.Instance.Emit(EEventName.OnAntiqueShopUpgradeSequenceFinished);
		}
		this.PlayVillageDeliverySuccessMontage();
	}

	// Token: 0x0601A76F RID: 108399 RVA: 0x007D0408 File Offset: 0x007CE608
	private void PlayVillageDeliverySuccessMontage()
	{
		if (this.NpcUiInteractType != ENpcUiInteractType.VillageInfr)
		{
			return;
		}
		NpcShopPerformParams shopParams = this.ShopParams;
		bool flag;
		if (shopParams == null)
		{
			flag = true;
		}
		else
		{
			NpcSystemUiMontageInfo deliverSuccessMontageInfo = shopParams.DeliverSuccessMontageInfo;
			bool? flag2;
			if (deliverSuccessMontageInfo == null)
			{
				flag2 = null;
			}
			else
			{
				UAnimMontage asset = deliverSuccessMontageInfo.Asset;
				flag2 = ((asset != null) ? new bool?(asset.IsValid()) : null);
			}
			bool? flag3 = flag2;
			flag = !flag3.GetValueOrDefault();
		}
		if (flag)
		{
			return;
		}
		base.PlayMontage(new IPlayMontageParam
		{
			MontageAsset = this.ShopParams.DeliverSuccessMontageInfo.Asset,
			IsLoop = new bool?(false),
			AnimStateParam = this.ShopParams.DeliverSuccessMontageInfo.State
		});
	}

	// Token: 0x0601A770 RID: 108400 RVA: 0x007D04B0 File Offset: 0x007CE6B0
	private unsafe void OnVillageCompleteDelivery()
	{
		if (this.UiViewName == null)
		{
			return;
		}
		global::Log instance = Singleton<global::Log>.Instance;
		ELogModule module = ELogModule.NPC;
		ELogAuthor author = ELogAuthor.LYX;
		string message = "[CollectionItemDisplay]当提交物品成功时,播放提交成功剧情 EnterFlow,播放提交成功动作 ShopSuccessMontage";
		<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
		*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("EntityId", this.Owner.Id);
		ref ValueTuple<string, object> ptr = ref <PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1);
		string item = "FlowId";
		NpcShopPerformParams shopParams = this.ShopParams;
		int? num;
		if (shopParams == null)
		{
			num = null;
		}
		else
		{
			PlayFlow completeFlow = shopParams.CompleteFlow;
			num = ((completeFlow != null) ? new int?(completeFlow.FlowId) : null);
		}
		ptr = new ValueTuple<string, object>(item, num);
		instance.Info(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
		NpcShopPerformParams shopParams2 = this.ShopParams;
		if (((shopParams2 != null) ? shopParams2.CompleteFlow : null) != null)
		{
			ControllerBase<FlowController>.Instance.StartFlow(this.ShopParams.CompleteFlow.FlowListName, this.ShopParams.CompleteFlow.FlowId, this.ShopParams.CompleteFlow.StateId, null, 0L, false, false, false, null);
			Singleton<EventSystem>.Instance.Emit(EEventName.OnAntiqueShopUpgradeSequenceFinished);
		}
		this.PlayVillageCompleteMontage();
	}

	// Token: 0x0601A771 RID: 108401 RVA: 0x007D05D4 File Offset: 0x007CE7D4
	private void PlayVillageCompleteMontage()
	{
		if (this.NpcUiInteractType != ENpcUiInteractType.VillageInfr)
		{
			return;
		}
		NpcShopPerformParams shopParams = this.ShopParams;
		bool flag;
		if (shopParams == null)
		{
			flag = true;
		}
		else
		{
			NpcSystemUiMontageInfo completeMontageInfo = shopParams.CompleteMontageInfo;
			bool? flag2;
			if (completeMontageInfo == null)
			{
				flag2 = null;
			}
			else
			{
				UAnimMontage asset = completeMontageInfo.Asset;
				flag2 = ((asset != null) ? new bool?(asset.IsValid()) : null);
			}
			bool? flag3 = flag2;
			flag = !flag3.GetValueOrDefault();
		}
		if (flag)
		{
			return;
		}
		base.PlayMontage(new IPlayMontageParam
		{
			MontageAsset = this.ShopParams.CompleteMontageInfo.Asset,
			IsLoop = new bool?(false),
			AnimStateParam = this.ShopParams.CompleteMontageInfo.State
		});
	}

	// Token: 0x0601A772 RID: 108402 RVA: 0x007D067C File Offset: 0x007CE87C
	private unsafe void OnSubmitItemSuccess()
	{
		if (this.UiViewName == null)
		{
			return;
		}
		global::Log instance = Singleton<global::Log>.Instance;
		ELogModule module = ELogModule.NPC;
		ELogAuthor author = ELogAuthor.WLJ;
		string message = "[CollectionItemDisplay]当提交物品成功时,播放提交成功剧情 EnterFlow,播放提交成功动作 ShopSuccessMontage";
		<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
		*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("EntityId", this.Owner.Id);
		ref ValueTuple<string, object> ptr = ref <PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1);
		string item = "FlowId";
		NpcShopPerformParams shopParams = this.ShopParams;
		int? num;
		if (shopParams == null)
		{
			num = null;
		}
		else
		{
			PlayFlow shopSuccessFlow = shopParams.ShopSuccessFlow;
			num = ((shopSuccessFlow != null) ? new int?(shopSuccessFlow.FlowId) : null);
		}
		ptr = new ValueTuple<string, object>(item, num);
		instance.Info(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
		NpcShopPerformParams shopParams2 = this.ShopParams;
		this.StartFlow((shopParams2 != null) ? shopParams2.ShopSuccessFlow : null, this.UiViewName.Value, true);
		this.PlayBuySuccessMontage();
	}

	// Token: 0x0601A773 RID: 108403 RVA: 0x007D0760 File Offset: 0x007CE960
	private unsafe void OnSubmitItemFail()
	{
		if (this.UiViewName == null)
		{
			return;
		}
		global::Log instance = Singleton<global::Log>.Instance;
		ELogModule module = ELogModule.NPC;
		ELogAuthor author = ELogAuthor.WLJ;
		string message = "[CollectionItemDisplay]当提交物品失败时,播放提交物品失败剧情 ShopFailedFlow";
		<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
		*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("EntityId", this.Owner.Id);
		ref ValueTuple<string, object> ptr = ref <PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1);
		string item = "FlowId";
		NpcShopPerformParams shopParams = this.ShopParams;
		int? num;
		if (shopParams == null)
		{
			num = null;
		}
		else
		{
			PlayFlow shopFailedFlow = shopParams.ShopFailedFlow;
			num = ((shopFailedFlow != null) ? new int?(shopFailedFlow.FlowId) : null);
		}
		ptr = new ValueTuple<string, object>(item, num);
		instance.Info(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
		NpcShopPerformParams shopParams2 = this.ShopParams;
		this.StartFlow((shopParams2 != null) ? shopParams2.ShopFailedFlow : null, this.UiViewName.Value, true);
	}

	// Token: 0x0601A774 RID: 108404 RVA: 0x007D083C File Offset: 0x007CEA3C
	private unsafe void OnSubmitItemLevelUp()
	{
		if (this.NpcUiInteractType != ENpcUiInteractType.AntiqueShop && this.NpcUiInteractType != ENpcUiInteractType.ChengXiaoShanShop && this.NpcUiInteractType != ENpcUiInteractType.SoundBox3 && this.NpcUiInteractType != ENpcUiInteractType.SunSpirit && this.NpcUiInteractType != ENpcUiInteractType.SoundBox35)
		{
			global::Log instance = Singleton<global::Log>.Instance;
			ELogModule module = ELogModule.NPC;
			ELogAuthor author = ELogAuthor.WLJ;
			string message = "[CollectionItemDisplay]当提交物品升级成功时,Npc类型不是ChengXiaoShanShop或AntiqueShop,播放失败";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("NpcUiInteractType", this.NpcUiInteractType);
			instance.Info(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			return;
		}
		if (this.ShopParams == null)
		{
			Singleton<EventSystem>.Instance.Emit(EEventName.OnAntiqueShopUpgradeSequenceFinished);
			return;
		}
		if (this.ShopParams.UpgradeFlow != null)
		{
			ControllerBase<FlowController>.Instance.StartFlow(this.ShopParams.UpgradeFlow.FlowListName, this.ShopParams.UpgradeFlow.FlowId, this.ShopParams.UpgradeFlow.StateId, null, 0L, false, false, false, null);
			Singleton<EventSystem>.Instance.Emit(EEventName.OnAntiqueShopUpgradeSequenceFinished);
			return;
		}
		if (NpcSystemUiMontageInfo.IsPathValid(this.ShopParams.UpgradeSequencePath))
		{
			NpcSystemUiMontageInfo standByMontageInfo = this.ShopParams.StandByMontageInfo;
			if (NpcSystemUiMontageInfo.IsPathValid((standByMontageInfo != null) ? standByMontageInfo.Path : null))
			{
				if (this.NpcPerformSequence == null)
				{
					this.NpcPerformSequence = new NpcPerformSequence();
				}
				global::Log instance2 = Singleton<global::Log>.Instance;
				ELogModule module2 = ELogModule.NPC;
				ELogAuthor author2 = ELogAuthor.WLJ;
				string message2 = "[CollectionItemDisplay]当提交物品升级成功时,开始加载对应Sequence";
				<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("NpcUiInteractType", this.NpcUiInteractType);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("UpgradeSequencePath", this.ShopParams.UpgradeSequencePath);
				instance2.Info(module2, author2, message2, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
				this.NpcPerformSequence.Load(this.ShopParams.UpgradeSequencePath, new Action(this.OnLevelUpSequenceLoadCompelete));
				return;
			}
		}
		global::Log instance3 = Singleton<global::Log>.Instance;
		ELogModule module3 = ELogModule.NPC;
		ELogAuthor author3 = ELogAuthor.WLJ;
		string message3 = "[CollectionItemDisplay]当提交物品升级成功时,UpgradeSequencePath为空或者StandByMontagePath为Empty,播放失败";
		ValueTuple<string, object> valueTuple2 = new ValueTuple<string, object>("NpcUiInteractType", this.NpcUiInteractType);
		instance3.Info(module3, author3, message3, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple2));
		Singleton<EventSystem>.Instance.Emit(EEventName.OnAntiqueShopUpgradeSequencePlayFail);
	}

	// Token: 0x0601A775 RID: 108405 RVA: 0x007D0A3C File Offset: 0x007CEC3C
	private unsafe void OnLevelUpSequenceLoadCompelete()
	{
		EntityHandle owner = this.Owner;
		if (owner == null || !owner.Valid || this.ShopParams == null)
		{
			Singleton<EventSystem>.Instance.Emit(EEventName.OnAntiqueShopUpgradeSequenceFinished);
			return;
		}
		if (this.NpcPerformSequence == null)
		{
			global::Log instance = Singleton<global::Log>.Instance;
			ELogModule module = ELogModule.LevelSequencePlayer;
			ELogAuthor author = ELogAuthor.YJX;
			string message = "交付道具播放Sequence时Npc已销毁";
			<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("PbDataId", this.ConfigId);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("Path", this.ShopParams.UpgradeSequencePath);
			instance.Error(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
			Singleton<EventSystem>.Instance.Emit(EEventName.OnAntiqueShopUpgradeSequenceFinished);
			return;
		}
		global::Log instance2 = Singleton<global::Log>.Instance;
		ELogModule module2 = ELogModule.NPC;
		ELogAuthor author2 = ELogAuthor.WLJ;
		string message2 = "[CollectionItemDisplay]当提交物品升级成功时,开始播放对应Sequence";
		<>y__InlineArray3<ValueTuple<string, object>> <>y__InlineArray2 = default(<>y__InlineArray3<ValueTuple<string, object>>);
		*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 0) = new ValueTuple<string, object>("NpcUiInteractType", this.NpcUiInteractType);
		*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 1) = new ValueTuple<string, object>("FinishDeliverySequence", this.ShopParams.UpgradeSequencePath);
		*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 2) = new ValueTuple<string, object>("ShowNpcWhilePlayingSequence", this.ShopParams.ShowNpcWhilePlayingSequence);
		instance2.Info(module2, author2, message2, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray2, 3));
		if (!this.ShopParams.ShowNpcWhilePlayingSequence)
		{
			this.SetNpcAndChildDisable();
		}
		this.NpcPerformSequence.Play(new Action(this.OnLevelUpSequencePlayFinished));
	}

	// Token: 0x0601A776 RID: 108406 RVA: 0x007D0BB4 File Offset: 0x007CEDB4
	private unsafe void OnLevelUpSequencePlayFinished()
	{
		EntityHandle owner = this.Owner;
		if (owner == null || !owner.Valid || this.ShopParams == null)
		{
			Singleton<EventSystem>.Instance.Emit(EEventName.OnAntiqueShopUpgradeSequenceFinished);
			return;
		}
		if (this.NpcPerformSequence == null)
		{
			global::Log instance = Singleton<global::Log>.Instance;
			ELogModule module = ELogModule.LevelSequencePlayer;
			ELogAuthor author = ELogAuthor.YJX;
			string message = "交付道具播放Sequence时Npc已销毁";
			<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("PbDataId", this.ConfigId);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("Path", this.ShopParams.UpgradeSequencePath);
			instance.Error(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
			Singleton<EventSystem>.Instance.Emit(EEventName.OnAntiqueShopUpgradeSequenceFinished);
			return;
		}
		global::Log instance2 = Singleton<global::Log>.Instance;
		ELogModule module2 = ELogModule.NPC;
		ELogAuthor author2 = ELogAuthor.WLJ;
		string message2 = "[CollectionItemDisplay]当提交物品升级成功时,Sequence播放完成";
		<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray2 = default(<>y__InlineArray2<ValueTuple<string, object>>);
		*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 0) = new ValueTuple<string, object>("NpcUiInteractType", this.NpcUiInteractType);
		*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 1) = new ValueTuple<string, object>("FinishDeliverySequence", this.ShopParams.UpgradeSequencePath);
		instance2.Info(module2, author2, message2, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray2, 2));
		IPlayMontageParam playMontageParam = new IPlayMontageParam();
		NpcSystemUiMontageInfo enterMontageInfo = this.ShopParams.EnterMontageInfo;
		playMontageParam.MontageAsset = ((enterMontageInfo != null) ? enterMontageInfo.Asset : null);
		playMontageParam.InSectionToStartMontageAt = new FName?(Singleton<CharacterNameDefines>.Instance.LOOP_SECTION);
		NpcSystemUiMontageInfo enterMontageInfo2 = this.ShopParams.EnterMontageInfo;
		playMontageParam.AnimStateParam = ((enterMontageInfo2 != null) ? enterMontageInfo2.State : null);
		base.PlayMontage(playMontageParam);
		this.SetNpcAndChildEnable();
		Singleton<EventSystem>.Instance.Emit(EEventName.OnAntiqueShopUpgradeSequenceFinished);
	}

	// Token: 0x0601A777 RID: 108407 RVA: 0x007D0D4C File Offset: 0x007CEF4C
	private unsafe void OnSubmitItemLevelMax()
	{
		if (this.NpcUiInteractType != ENpcUiInteractType.AntiqueShop && this.NpcUiInteractType != ENpcUiInteractType.ChengXiaoShanShop && this.NpcUiInteractType != ENpcUiInteractType.SoundBox3 && this.NpcUiInteractType != ENpcUiInteractType.SunSpirit && this.NpcUiInteractType != ENpcUiInteractType.SoundBox35)
		{
			global::Log instance = Singleton<global::Log>.Instance;
			ELogModule module = ELogModule.NPC;
			ELogAuthor author = ELogAuthor.WLJ;
			string message = "[CollectionItemDisplay]当提交物品等级升至满级时,Npc类型不是ChengXiaoShanShop,播放失败";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("NpcUiInteractType", this.NpcUiInteractType);
			instance.Info(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			return;
		}
		if (this.ShopParams == null)
		{
			Singleton<EventSystem>.Instance.Emit(EEventName.OnAntiqueShopUpgradeSequenceFinished);
			return;
		}
		if (this.ShopParams.UpgradeFlow != null)
		{
			ControllerBase<FlowController>.Instance.StartFlow(this.ShopParams.UpgradeFlow.FlowListName, this.ShopParams.UpgradeFlow.FlowId, this.ShopParams.UpgradeFlow.StateId, null, 0L, false, false, false, null);
			Singleton<EventSystem>.Instance.Emit(EEventName.OnAntiqueShopUpgradeSequenceFinished);
			return;
		}
		string text = (this.NpcUiInteractType == ENpcUiInteractType.ChengXiaoShanShop) ? this.ShopParams.FinishDeliverySequence : this.ShopParams.UpgradeSequencePath;
		if (NpcSystemUiMontageInfo.IsPathValid(text))
		{
			NpcSystemUiMontageInfo standByMontageInfo = this.ShopParams.StandByMontageInfo;
			if (NpcSystemUiMontageInfo.IsPathValid((standByMontageInfo != null) ? standByMontageInfo.Path : null))
			{
				if (this.NpcPerformSequence == null)
				{
					this.NpcPerformSequence = new NpcPerformSequence();
				}
				global::Log instance2 = Singleton<global::Log>.Instance;
				ELogModule module2 = ELogModule.NPC;
				ELogAuthor author2 = ELogAuthor.WLJ;
				string message2 = "[CollectionItemDisplay]当提交物品等级升至满级时,开始加载对应Sequence";
				<>y__InlineArray3<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray3<ValueTuple<string, object>>);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("NpcUiInteractType", this.NpcUiInteractType);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("FinishDeliverySequence", text);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 2) = new ValueTuple<string, object>("ShowNpcWhilePlayingSequence", this.ShopParams.ShowNpcWhilePlayingSequence);
				instance2.Info(module2, author2, message2, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 3));
				this.NpcPerformSequence.Load(text, new Action(this.OnLevelMaxSequenceLoadCompelete));
				return;
			}
		}
		global::Log instance3 = Singleton<global::Log>.Instance;
		ELogModule module3 = ELogModule.NPC;
		ELogAuthor author3 = ELogAuthor.WLJ;
		string message3 = "[CollectionItemDisplay]当提交物品等级升至满级时,FinishDeliverySequence为空或者StandByMontagePath为Empty,播放失败";
		<>y__InlineArray3<ValueTuple<string, object>> <>y__InlineArray2 = default(<>y__InlineArray3<ValueTuple<string, object>>);
		*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 0) = new ValueTuple<string, object>("NpcUiInteractType", this.NpcUiInteractType);
		*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 1) = new ValueTuple<string, object>("FinishDeliverySequence", text);
		ref ValueTuple<string, object> ptr = ref <PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 2);
		string item = "StandByMontagePath";
		NpcSystemUiMontageInfo standByMontageInfo2 = this.ShopParams.StandByMontageInfo;
		ptr = new ValueTuple<string, object>(item, (standByMontageInfo2 != null) ? standByMontageInfo2.Path : null);
		instance3.Info(module3, author3, message3, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray2, 3));
		Singleton<EventSystem>.Instance.Emit(EEventName.OnAntiqueShopUpgradeSequencePlayFail);
	}

	// Token: 0x0601A778 RID: 108408 RVA: 0x007D0FD4 File Offset: 0x007CF1D4
	private unsafe void OnLevelMaxSequenceLoadCompelete()
	{
		EntityHandle owner = this.Owner;
		if (owner == null || !owner.Valid || this.ShopParams == null)
		{
			Singleton<EventSystem>.Instance.Emit(EEventName.OnAntiqueShopUpgradeSequenceFinished);
			return;
		}
		string item = (this.NpcUiInteractType == ENpcUiInteractType.ChengXiaoShanShop) ? this.ShopParams.FinishDeliverySequence : this.ShopParams.UpgradeSequencePath;
		if (this.NpcPerformSequence == null)
		{
			global::Log instance = Singleton<global::Log>.Instance;
			ELogModule module = ELogModule.LevelSequencePlayer;
			ELogAuthor author = ELogAuthor.YJX;
			string message = "交付道具播放Sequence时Npc已销毁";
			<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("PbDataId", this.ConfigId);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("Path", item);
			instance.Error(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
			Singleton<EventSystem>.Instance.Emit(EEventName.OnAntiqueShopUpgradeSequenceFinished);
			return;
		}
		global::Log instance2 = Singleton<global::Log>.Instance;
		ELogModule module2 = ELogModule.NPC;
		ELogAuthor author2 = ELogAuthor.WLJ;
		string message2 = "[CollectionItemDisplay]当提交物品等级升至满级时,开始播放对应Sequence";
		<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray2 = default(<>y__InlineArray2<ValueTuple<string, object>>);
		*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 0) = new ValueTuple<string, object>("NpcUiInteractType", this.NpcUiInteractType);
		*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 1) = new ValueTuple<string, object>("FinishDeliverySequence", item);
		instance2.Info(module2, author2, message2, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray2, 2));
		if (!this.ShopParams.ShowNpcWhilePlayingSequence)
		{
			this.SetNpcAndChildDisable();
		}
		this.NpcPerformSequence.Play(new Action(this.OnLevelMaxSequencePlayFinished));
	}

	// Token: 0x0601A779 RID: 108409 RVA: 0x007D1134 File Offset: 0x007CF334
	private unsafe void OnLevelMaxSequencePlayFinished()
	{
		EntityHandle owner = this.Owner;
		if (owner == null || !owner.Valid || this.ShopParams == null)
		{
			Singleton<EventSystem>.Instance.Emit(EEventName.OnAntiqueShopUpgradeSequenceFinished);
			return;
		}
		string item = (this.NpcUiInteractType == ENpcUiInteractType.ChengXiaoShanShop) ? this.ShopParams.FinishDeliverySequence : this.ShopParams.UpgradeSequencePath;
		if (this.NpcPerformSequence == null)
		{
			global::Log instance = Singleton<global::Log>.Instance;
			ELogModule module = ELogModule.LevelSequencePlayer;
			ELogAuthor author = ELogAuthor.YJX;
			string message = "交付道具播放Sequence时Npc已销毁";
			<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("PbDataId", this.ConfigId);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("Path", this.ShopParams.UpgradeSequencePath);
			instance.Error(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
			Singleton<EventSystem>.Instance.Emit(EEventName.OnAntiqueShopUpgradeSequenceFinished);
			return;
		}
		global::Log instance2 = Singleton<global::Log>.Instance;
		ELogModule module2 = ELogModule.NPC;
		ELogAuthor author2 = ELogAuthor.WLJ;
		string message2 = "[CollectionItemDisplay]当提交物品等级升至满级时,Sequence播放完成";
		<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray2 = default(<>y__InlineArray2<ValueTuple<string, object>>);
		*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 0) = new ValueTuple<string, object>("NpcUiInteractType", this.NpcUiInteractType);
		*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 1) = new ValueTuple<string, object>("FinishDeliverySequence", item);
		instance2.Info(module2, author2, message2, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray2, 2));
		IPlayMontageParam playMontageParam = new IPlayMontageParam();
		NpcSystemUiMontageInfo enterMontageInfo = this.ShopParams.EnterMontageInfo;
		playMontageParam.MontageAsset = ((enterMontageInfo != null) ? enterMontageInfo.Asset : null);
		playMontageParam.InSectionToStartMontageAt = new FName?(Singleton<CharacterNameDefines>.Instance.LOOP_SECTION);
		NpcSystemUiMontageInfo enterMontageInfo2 = this.ShopParams.EnterMontageInfo;
		playMontageParam.AnimStateParam = ((enterMontageInfo2 != null) ? enterMontageInfo2.State : null);
		base.PlayMontage(playMontageParam);
		this.SetNpcAndChildEnable();
		Singleton<EventSystem>.Instance.Emit(EEventName.OnAntiqueShopUpgradeSequenceFinished);
	}

	// Token: 0x0601A77A RID: 108410 RVA: 0x007D12E4 File Offset: 0x007CF4E4
	private void SetNpcAndChildDisable()
	{
		if (this.NpcPerformSequence == null)
		{
			return;
		}
		int handleId = this.Owner.Entity.Disable("播放Sequence隐藏Npc");
		this.DisableEntities.Add(new DisableEntityInfo
		{
			HandleId = handleId,
			EntityHandle = this.Owner
		});
		EntityHandle owner = this.Owner;
		CreatureDataComponent creatureDataComponent = (owner != null) ? owner.Entity.GetComponent<CreatureDataComponent>() : null;
		if (creatureDataComponent == null || !creatureDataComponent.Valid)
		{
			return;
		}
		List<int> childEntityIds = creatureDataComponent.GetBaseInfo().ChildEntityIds;
		if (childEntityIds != null)
		{
			List<int> list = childEntityIds;
			if (list == null || ((ICollection)list).Count >= 1)
			{
				CreatureModel instance = ModelBase<CreatureModel>.Instance;
				foreach (int pbDataId in childEntityIds)
				{
					EntityHandle entityByPbDataId = instance.GetEntityByPbDataId(pbDataId);
					if (entityByPbDataId != null && entityByPbDataId.Valid)
					{
						int handleId2 = entityByPbDataId.Entity.Disable("播放Sequence隐藏子实体");
						this.DisableEntities.Add(new DisableEntityInfo
						{
							HandleId = handleId2,
							EntityHandle = entityByPbDataId
						});
					}
				}
				return;
			}
		}
	}

	// Token: 0x0601A77B RID: 108411 RVA: 0x007D1414 File Offset: 0x007CF614
	private void SetForcedLod(bool forcedLod)
	{
		EntityHandle owner = this.Owner;
		BaseActorComponent baseActorComponent;
		if (owner == null)
		{
			baseActorComponent = null;
		}
		else
		{
			WorldEntity entity = owner.Entity;
			baseActorComponent = ((entity != null) ? entity.GetComponent<BaseActorComponent>() : null);
		}
		BaseActorComponent baseActorComponent2 = baseActorComponent;
		if (baseActorComponent2 != null)
		{
			USkeletalMeshComponent skeletalMesh = baseActorComponent2.SkeletalMesh;
			if (((skeletalMesh != null) ? new bool?(skeletalMesh.IsValid()) : null).GetValueOrDefault())
			{
				baseActorComponent2.SkeletalMesh.ForcedLodModel = ((forcedLod > false) ? 1 : 0);
			}
		}
	}

	// Token: 0x0601A77C RID: 108412 RVA: 0x007D147C File Offset: 0x007CF67C
	public void SetNpcAndChildEnable()
	{
		for (int i = 0; i < this.DisableEntities.Count; i++)
		{
			DisableEntityInfo disableEntityInfo = this.DisableEntities[i];
			disableEntityInfo.EntityHandle.Entity.Enable(disableEntityInfo.HandleId, "NpcPerformSystemUiState.SetNpcAndChildEnable");
		}
		this.DisableEntities.Clear();
	}

	// Token: 0x0601A77D RID: 108413 RVA: 0x007D14D4 File Offset: 0x007CF6D4
	private void StartFlow(PlayFlow playFlow, EUiViewName uiViewName, bool canBeAbandoned)
	{
		if (playFlow == null)
		{
			return;
		}
		EPlotLowLevelPosition? valueOrNull = this.PlotPositionMap.GetValueOrNull(uiViewName);
		UiParam uiParam = new UiParam
		{
			ViewName = new EUiViewName?(uiViewName),
			Position = new EPlotLowLevelPosition?(valueOrNull.GetValueOrDefault(EPlotLowLevelPosition.Center)),
			TextWidth = new EPlotTextWidthType?(EPlotTextWidthType.Short)
		};
		ControllerBase<FlowController>.Instance.StartFlowForView(playFlow.FlowListName, playFlow.FlowId, playFlow.StateId, uiParam, canBeAbandoned);
	}

	// Token: 0x0601A77E RID: 108414 RVA: 0x007D1548 File Offset: 0x007CF748
	private void PlayStandByMontage()
	{
		NpcShopPerformParams shopParams = this.ShopParams;
		bool flag;
		if (shopParams == null)
		{
			flag = false;
		}
		else
		{
			NpcSystemUiMontageInfo standByMontageInfo = shopParams.StandByMontageInfo;
			bool? flag2;
			if (standByMontageInfo == null)
			{
				flag2 = null;
			}
			else
			{
				UAnimMontage asset = standByMontageInfo.Asset;
				flag2 = ((asset != null) ? new bool?(asset.IsValid()) : null);
			}
			bool? flag3 = flag2;
			flag = flag3.GetValueOrDefault();
		}
		if (flag && this.StandByMontageStartTimeStamp != 0.0 && Singleton<Time>.Instance.WorldTimeSeconds > this.StandByMontageStartTimeStamp + this.StandByMontageCd)
		{
			bool flag4 = false;
			UAnimMontage asset2 = this.ShopParams.StandByMontageInfo.Asset;
			int num = asset2.CompositeSections.Num();
			for (int i = 0; i < num; i++)
			{
				FCompositeSection fcompositeSection = asset2.CompositeSections.Get(i);
				if (fcompositeSection != null && fcompositeSection.SectionName == Singleton<CharacterNameDefines>.Instance.LOOP_SECTION)
				{
					this.StandByMontageCd = (double)fcompositeSection.SegmentLength;
					flag4 = true;
				}
			}
			if (flag4)
			{
				base.PlayMontage(new IPlayMontageParam
				{
					MontageAsset = asset2,
					InSectionToStartMontageAt = new FName?(Singleton<CharacterNameDefines>.Instance.LOOP_SECTION),
					AnimStateParam = this.ShopParams.StandByMontageInfo.State
				});
				this.StandByMontageStartTimeStamp = Singleton<Time>.Instance.WorldTimeSeconds;
				return;
			}
			base.PlayMontage(new IPlayMontageParam
			{
				MontageAsset = asset2,
				AnimStateParam = this.ShopParams.StandByMontageInfo.State
			});
			this.StandByMontageStartTimeStamp = Singleton<Time>.Instance.WorldTimeSeconds;
			this.StandByMontageCd = (double)(asset2.SequenceLength + 20f);
		}
	}

	// Token: 0x0601A77F RID: 108415 RVA: 0x007D16E0 File Offset: 0x007CF8E0
	private void PlayBuySuccessMontage()
	{
		NpcShopPerformParams shopParams = this.ShopParams;
		UAnimMontage uanimMontage;
		if (shopParams == null)
		{
			uanimMontage = null;
		}
		else
		{
			NpcSystemUiMontageInfo enterMontageInfo = shopParams.EnterMontageInfo;
			uanimMontage = ((enterMontageInfo != null) ? enterMontageInfo.Asset : null);
		}
		UAnimMontage uanimMontage2 = uanimMontage;
		if (uanimMontage2 != null && uanimMontage2.IsValid())
		{
			EntityHandle owner = this.Owner;
			if (owner != null && owner.Valid)
			{
				BaseAnimationComponent animComp = this.AnimComp;
				bool? flag;
				if (animComp == null)
				{
					flag = null;
				}
				else
				{
					UAnimInstance mainAnimInstance = animComp.MainAnimInstance;
					flag = ((mainAnimInstance != null) ? new bool?(mainAnimInstance.Montage_IsPlaying(uanimMontage2)) : null);
				}
				bool? flag2 = flag;
				if (flag2.GetValueOrDefault())
				{
					return;
				}
			}
		}
		NpcShopPerformParams shopParams2 = this.ShopParams;
		UAnimMontage uanimMontage3;
		if (shopParams2 == null)
		{
			uanimMontage3 = null;
		}
		else
		{
			NpcSystemUiMontageInfo shopSuccessMontageInfo = shopParams2.ShopSuccessMontageInfo;
			uanimMontage3 = ((shopSuccessMontageInfo != null) ? shopSuccessMontageInfo.Asset : null);
		}
		UAnimMontage uanimMontage4 = uanimMontage3;
		if (uanimMontage4 != null && uanimMontage4.IsValid() && this.IsViewOpening && Singleton<Time>.Instance.WorldTimeSeconds > this.ShopSuccessStartTimeStamp + this.ShopSuccessCd)
		{
			IPlayMontageParam playMontageParam = new IPlayMontageParam();
			playMontageParam.MontageAsset = uanimMontage4;
			playMontageParam.IsLoop = new bool?(false);
			NpcShopPerformParams shopParams3 = this.ShopParams;
			IAnimStateParam animStateParam;
			if (shopParams3 == null)
			{
				animStateParam = null;
			}
			else
			{
				NpcSystemUiMontageInfo shopSuccessMontageInfo2 = shopParams3.ShopSuccessMontageInfo;
				animStateParam = ((shopSuccessMontageInfo2 != null) ? shopSuccessMontageInfo2.State : null);
			}
			playMontageParam.AnimStateParam = animStateParam;
			base.PlayMontage(playMontageParam);
			this.ShopSuccessStartTimeStamp = Singleton<Time>.Instance.WorldTimeSeconds;
			this.ShopSuccessCd = (double)uanimMontage4.SequenceLength;
			this.StandByMontageStartTimeStamp = Singleton<Time>.Instance.WorldTimeSeconds;
			this.StandByMontageCd = (double)(uanimMontage4.SequenceLength + 20f);
		}
	}

	// Token: 0x0601A780 RID: 108416 RVA: 0x007D1844 File Offset: 0x007CFA44
	private unsafe void OnDollGrabMachineDelivery(bool isAlreadyFirst, bool isComplete)
	{
		global::Log instance = Singleton<global::Log>.Instance;
		ELogModule module = ELogModule.NPC;
		ELogAuthor author = ELogAuthor.FJH;
		string message = "[DollGrabMachineDelivery]当提交物品成功时,播放提交成功剧情 EnterFlow,播放提交成功动作 ShopSuccessMontage";
		<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
		*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("isAlreadyFirst", isAlreadyFirst);
		*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("isComplete", isComplete);
		instance.Info(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
		PlayFlow playFlow = null;
		NpcSystemUiMontageInfo playMontage = null;
		if (!isAlreadyFirst && isComplete)
		{
			NpcShopPerformParams shopParams = this.ShopParams;
			playFlow = ((shopParams != null) ? shopParams.FirstDollFlow : null);
			NpcShopPerformParams shopParams2 = this.ShopParams;
			playMontage = ((shopParams2 != null) ? shopParams2.FirstDollMontageInfo : null);
		}
		else if (isAlreadyFirst && isComplete)
		{
			NpcShopPerformParams shopParams3 = this.ShopParams;
			playFlow = ((shopParams3 != null) ? shopParams3.SubsequentDollFlow : null);
			NpcShopPerformParams shopParams4 = this.ShopParams;
			playMontage = ((shopParams4 != null) ? shopParams4.SubsequentDollMontageInfo : null);
		}
		else if (!isAlreadyFirst && !isComplete)
		{
			NpcShopPerformParams shopParams5 = this.ShopParams;
			playFlow = ((shopParams5 != null) ? shopParams5.FirstDollPartFlow : null);
			NpcShopPerformParams shopParams6 = this.ShopParams;
			playMontage = ((shopParams6 != null) ? shopParams6.FirstDollPartMontageInfo : null);
		}
		else if (isAlreadyFirst && !isComplete)
		{
			NpcShopPerformParams shopParams7 = this.ShopParams;
			playFlow = ((shopParams7 != null) ? shopParams7.SubsequentDollPartFlow : null);
			NpcShopPerformParams shopParams8 = this.ShopParams;
			playMontage = ((shopParams8 != null) ? shopParams8.SubsequentDollPartMontageInfo : null);
		}
		this.PlayDollFlowAndMontage(playFlow, playMontage);
	}

	// Token: 0x0601A781 RID: 108417 RVA: 0x007D1978 File Offset: 0x007CFB78
	private void PlayDollFlowAndMontage(PlayFlow playFlow, NpcSystemUiMontageInfo playMontage)
	{
		if (playFlow != null && this.UiViewName != null)
		{
			this.StartFlow(playFlow, this.UiViewName.Value, true);
		}
		if (playMontage != null)
		{
			if (playMontage.Duration != null)
			{
				float? duration = playMontage.Duration;
				float num = 0f;
				if (duration.GetValueOrDefault() > num & duration != null)
				{
					TimerSystem.Instance.Delay(delegate(float _)
					{
						Singleton<EventSystem>.Instance.Emit<bool>(EEventName.OnDollGrabMachineDeliveryFinish, true);
					}, playMontage.Duration.Value * 1000f, null, null, true, 1f);
					if (NpcSystemUiMontageInfo.IsPathValid(playMontage.Path))
					{
						base.PlayMontage(new IPlayMontageParam
						{
							MontagePath = playMontage.Path,
							IsLoop = new bool?(false),
							AnimStateParam = playMontage.State
						});
						return;
					}
					return;
				}
			}
			if (NpcSystemUiMontageInfo.IsPathValid(playMontage.Path))
			{
				IPlayMontageParam playMontageParam = new IPlayMontageParam();
				playMontageParam.MontagePath = playMontage.Path;
				playMontageParam.IsLoop = new bool?(false);
				playMontageParam.AnimStateParam = playMontage.State;
				playMontageParam.OnEndCallback = delegate(UAnimMontage montage, bool bInterrupted)
				{
					if (!bInterrupted)
					{
						Singleton<EventSystem>.Instance.Emit<bool>(EEventName.OnDollGrabMachineDeliveryFinish, true);
					}
				};
				base.PlayMontage(playMontageParam);
			}
		}
	}

	// Token: 0x0400D5DF RID: 54751
	private const int STAND_BY_MONTAGE_CD = 20;

	// Token: 0x0400D5E0 RID: 54752
	private const int SWITCH_MONATGE_CD = 2000;

	// Token: 0x0400D5E1 RID: 54753
	private NpcShopPerformParams ShopParams;

	// Token: 0x0400D5E2 RID: 54754
	private ENpcUiInteractType NpcUiInteractType = ENpcUiInteractType.AntiqueShop;

	// Token: 0x0400D5E3 RID: 54755
	private EUiViewName? UiViewName;

	// Token: 0x0400D5E4 RID: 54756
	private bool IsViewOpening;

	// Token: 0x0400D5E5 RID: 54757
	private int ShopId;

	// Token: 0x0400D5E6 RID: 54758
	private NpcPerformSequence NpcPerformSequence;

	// Token: 0x0400D5E7 RID: 54759
	[Nullable(1)]
	private readonly List<DisableEntityInfo> DisableEntities = new List<DisableEntityInfo>();

	// Token: 0x0400D5E8 RID: 54760
	private double StandByMontageCd;

	// Token: 0x0400D5E9 RID: 54761
	private double StandByMontageStartTimeStamp;

	// Token: 0x0400D5EA RID: 54762
	private double ShopSuccessCd = --0.0;

	// Token: 0x0400D5EB RID: 54763
	private double ShopSuccessStartTimeStamp = --0.0;

	// Token: 0x0400D5EC RID: 54764
	private double BuySuccessNpcDialogueTimeInterval;

	// Token: 0x0400D5ED RID: 54765
	private double CanPlayBuySuccessTimeStamp;

	// Token: 0x0400D5EE RID: 54766
	private double LastPlaySwitchMontageTime;

	// Token: 0x0400D5EF RID: 54767
	[Nullable(1)]
	private readonly Dictionary<EUiViewName, EPlotLowLevelPosition> PlotPositionMap = new Dictionary<EUiViewName, EPlotLowLevelPosition>();
}
