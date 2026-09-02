using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using Aki.Config;
using AkiClient.Game.Aki.Character.BaseCharacter;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.RacingBets;
using CSharpScript.Game.Module.RacingBets.Data;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x02002731 RID: 10033
[NullableContext(1)]
[Nullable(0)]
public class RacingBetsBettingView : UiTickViewBase, IUiCameraBehavior
{
	// Token: 0x06013CA4 RID: 81060 RVA: 0x005820CC File Offset: 0x005802CC
	public RacingBetsBettingView(UiViewInfo viewInfo) : base(viewInfo)
	{
	}

	// Token: 0x06013CA5 RID: 81061 RVA: 0x00582100 File Offset: 0x00580300
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUIText)),
			new ValueTuple<int, Type>(1, typeof(UUIText)),
			new ValueTuple<int, Type>(2, typeof(UUIHorizontalLayout)),
			new ValueTuple<int, Type>(3, typeof(UUIText)),
			new ValueTuple<int, Type>(4, typeof(UUIItem)),
			new ValueTuple<int, Type>(5, typeof(UUIItem)),
			new ValueTuple<int, Type>(6, typeof(UUIItem)),
			new ValueTuple<int, Type>(7, typeof(UUIButtonComponent)),
			new ValueTuple<int, Type>(8, typeof(UUIHorizontalLayout)),
			new ValueTuple<int, Type>(9, typeof(UUIItem)),
			new ValueTuple<int, Type>(10, typeof(UUIItem)),
			new ValueTuple<int, Type>(11, typeof(UUIButtonComponent)),
			new ValueTuple<int, Type>(12, typeof(UUITexture)),
			new ValueTuple<int, Type>(13, typeof(UUIText)),
			new ValueTuple<int, Type>(14, typeof(UUIItem)),
			new ValueTuple<int, Type>(15, typeof(UUIItem)),
			new ValueTuple<int, Type>(16, typeof(UUIItem)),
			new ValueTuple<int, Type>(17, typeof(UUIText)),
			new ValueTuple<int, Type>(18, typeof(UUIButtonComponent)),
			new ValueTuple<int, Type>(19, typeof(UUIText)),
			new ValueTuple<int, Type>(20, typeof(UUIText)),
			new ValueTuple<int, Type>(21, typeof(UUIText)),
			new ValueTuple<int, Type>(22, typeof(UUIText)),
			new ValueTuple<int, Type>(23, typeof(UUIText)),
			new ValueTuple<int, Type>(24, typeof(UUIText)),
			new ValueTuple<int, Type>(25, typeof(UUIItem)),
			new ValueTuple<int, Type>(26, typeof(UUIItem)),
			new ValueTuple<int, Type>(27, typeof(UUIItem)),
			new ValueTuple<int, Type>(28, typeof(UUIText))
		};
		this.BtnBindInfo = new List<ValueTuple<int, Delegate>>
		{
			new ValueTuple<int, Delegate>(7, new Action(this.OnClickCloseButton)),
			new ValueTuple<int, Delegate>(11, new Action(this.OnClickBetsButton)),
			new ValueTuple<int, Delegate>(18, new Action(this.OnClickCancelBetsButton))
		};
	}

	// Token: 0x06013CA6 RID: 81062 RVA: 0x00582400 File Offset: 0x00580600
	protected override UniTask OnBeforeStartAsync()
	{
		RacingBetsBettingView.<OnBeforeStartAsync>d__18 <OnBeforeStartAsync>d__;
		<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnBeforeStartAsync>d__.<>4__this = this;
		<OnBeforeStartAsync>d__.<>1__state = -1;
		<OnBeforeStartAsync>d__.<>t__builder.Start<RacingBetsBettingView.<OnBeforeStartAsync>d__18>(ref <OnBeforeStartAsync>d__);
		return <OnBeforeStartAsync>d__.<>t__builder.Task;
	}

	// Token: 0x06013CA7 RID: 81063 RVA: 0x00582444 File Offset: 0x00580644
	private UniTask InitComponents()
	{
		RacingBetsBettingView.<InitComponents>d__19 <InitComponents>d__;
		<InitComponents>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<InitComponents>d__.<>4__this = this;
		<InitComponents>d__.<>1__state = -1;
		<InitComponents>d__.<>t__builder.Start<RacingBetsBettingView.<InitComponents>d__19>(ref <InitComponents>d__);
		return <InitComponents>d__.<>t__builder.Task;
	}

	// Token: 0x06013CA8 RID: 81064 RVA: 0x00582487 File Offset: 0x00580687
	public void PushCameraHandle(EUiViewName viewName, int viewId, bool isBlend)
	{
		ControllerBase<UiCameraAnimationController>.Instance.PushCameraHandle((EUiViewName)this.CurSelectDango.DangoCamera, new int?(viewId), isBlend);
	}

	// Token: 0x06013CA9 RID: 81065 RVA: 0x005824AC File Offset: 0x005806AC
	protected override void OnBeforeShow()
	{
		int num = this.DangoActorDataList.FindIndex((IRacingBetsDangoActorData data) => data == this.CurSelectDango);
		this.DangoLayout.SelectGridProxy(num, false);
		this.CurSelectDangoActor = this.DangoActorList[num];
		this.FadeAllDangoActor(this.DangoActorList, num, true);
		this.RefreshUi(this.LegMatchData, this.CurSelectDango, this.CurSelectGearConfig.Value);
		this.RefreshCurrencyItem();
		RacingBetsSeasonData racingBetsSeasonData = ModelBase<RacingBetsModel>.Instance.GetRacingBetsSeasonData();
		ControllerBase<RacingBetsController>.Instance.TryRegisterNextDangoOddsUpdateRequest(racingBetsSeasonData);
		ControllerBase<RacingBetsController>.Instance.RacingBetsUpdateOddsRequest(0f);
	}

	// Token: 0x06013CAA RID: 81066 RVA: 0x00582546 File Offset: 0x00580746
	protected override void OnAddEventListener()
	{
		Singleton<EventSystem>.Instance.Add(EEventName.OnRacingBetsPlayerInfoUpdate, new Action(this.OnRacingBetsPlayerInfoUpdate));
		Singleton<EventSystem>.Instance.Add<int, bool>(EEventName.OnRacingBetsBettingInfoUpdate, new Action<int, bool>(this.OnRacingBetsBettingInfoUpdate));
	}

	// Token: 0x06013CAB RID: 81067 RVA: 0x00582580 File Offset: 0x00580780
	protected override void OnTick(float delta)
	{
		if (!this.Tickable)
		{
			return;
		}
		if (this.LegMatchData.GetLegMatchState() == ERacingBetsLegMatchState.BettingPeriod)
		{
			this.RefreshOddsTimeText(this.LegMatchData);
			this.RefreshBetRemindTimeText();
			return;
		}
		this.Tickable = false;
		this.ShowCloseConfirmBox();
	}

	// Token: 0x06013CAC RID: 81068 RVA: 0x005825BC File Offset: 0x005807BC
	private void RefreshUi(RacingBetsLegMatchData legMatchData, IRacingBetsDangoActorData dangoActorData, RacingBettingGear gearConfig)
	{
		if (dangoActorData.IsAbuDango)
		{
			base.GetItem(26).SetUIActive(false);
			base.GetItem(27).SetUIActive(true);
		}
		else
		{
			base.GetItem(26).SetUIActive(true);
			base.GetItem(27).SetUIActive(false);
			if (legMatchData.HasBetting)
			{
				this.RefreshBetsResultPanel(legMatchData, dangoActorData);
				base.GetItem(5).SetUIActive(true);
				base.GetItem(4).SetUIActive(false);
			}
			else
			{
				this.RefreshBetsPanel(legMatchData, dangoActorData, gearConfig);
				base.GetItem(4).SetUIActive(true);
				base.GetItem(5).SetUIActive(false);
			}
		}
		DangoData dangoData = Singleton<DangoManager>.Instance.GetDangoData(dangoActorData.DangoId);
		base.GetText(0).ShowTextNew(dangoData.NameKey);
		DangoSkill? dangoSkill;
		base.GetText(1).ShowTextNew(((dangoData.GetSkillConfig() != null) ? dangoSkill.GetValueOrDefault().Desc : null) ?? "");
		base.GetText(3).ShowTextNew(legMatchData.Name);
		base.GetItem(16).SetUIActive(false);
		this.RefreshOddsTimeText(legMatchData);
		foreach (RacingBetsDangoOddsItem racingBetsDangoOddsItem in this.DangoLayout.GetLayoutItemList())
		{
			racingBetsDangoOddsItem.RefreshOddsDango(legMatchData.BetDangoId);
		}
		base.GetText(22).ShowTextNew("Dango_MainPage_StatusTime_Bet");
		this.RefreshBetRemindTimeText();
	}

	// Token: 0x06013CAD RID: 81069 RVA: 0x00582744 File Offset: 0x00580944
	private void RefreshBetsPanel(RacingBetsLegMatchData legMatchData, IRacingBetsDangoActorData oddsData, RacingBettingGear gearConfig)
	{
		RacingBetsSeasonData racingBetsSeasonData = ModelBase<RacingBetsModel>.Instance.GetRacingBetsSeasonData();
		int currencyItemId = racingBetsSeasonData.GetCurrencyItemId();
		int betCostCount = racingBetsSeasonData.GetBetCostCount(gearConfig);
		this.BetsCostItem.RefreshUi(currencyItemId, betCostCount);
		int count = (int)Math.Ceiling((double)(betCostCount * oddsData.Odds) / 100.0);
		this.BetsRewardItem.RefreshUi(currencyItemId, count);
		UUIText text = base.GetText(24);
		DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(1, 1);
		defaultInterpolatedStringHandler.AppendLiteral("×");
		defaultInterpolatedStringHandler.AppendFormatted<int>(oddsData.Odds / 100);
		text.SetText(defaultInterpolatedStringHandler.ToStringAndClear(), true);
	}

	// Token: 0x06013CAE RID: 81070 RVA: 0x005827D8 File Offset: 0x005809D8
	private void RefreshBetsResultPanel(RacingBetsLegMatchData legMatchData, IRacingBetsDangoActorData oddsData)
	{
		int currencyItemId = ModelBase<RacingBetsModel>.Instance.GetRacingBetsSeasonData().GetCurrencyItemId();
		DangoData dangoData = Singleton<DangoManager>.Instance.GetDangoData(legMatchData.BetDangoId);
		base.SetTextureShowUntilLoaded(dangoData.Icon, base.GetTexture(12), null);
		base.GetText(13).ShowTextNew(dangoData.NameKey);
		this.BetsResultCostItem.RefreshUi(currencyItemId, legMatchData.BetGearCash);
		this.BetsResultRewardItem.RefreshUi(currencyItemId, legMatchData.GetOddsRewardCount());
		base.GetText(17).SetText(legMatchData.LeaveCancelNum.ToString(), true);
		base.GetButton(18).RootUIComp.Get().SetUIActive(legMatchData.LeaveCancelNum > 0);
		UUIText text = base.GetText(23);
		DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(1, 1);
		defaultInterpolatedStringHandler.AppendLiteral("×");
		defaultInterpolatedStringHandler.AppendFormatted<int>(legMatchData.Odds / 100);
		text.SetText(defaultInterpolatedStringHandler.ToStringAndClear(), true);
	}

	// Token: 0x06013CAF RID: 81071 RVA: 0x005828CC File Offset: 0x00580ACC
	private void RefreshOddsTimeText(RacingBetsLegMatchData legMatchData)
	{
		if (legMatchData.IsFinalOddsRefresh)
		{
			base.GetItem(25).SetUIActive(false);
			return;
		}
		base.GetItem(25).SetUIActive(true);
		base.GetText(19).ShowTextNew("Dango_BetPage_Function_NextBetRate");
		string newText = Singleton<TimeUtil>.Instance.DateFormat7String(this.LegMatchData.NextOddsRateRefreshTime);
		base.GetText(20).SetText(newText, true);
	}

	// Token: 0x06013CB0 RID: 81072 RVA: 0x00582938 File Offset: 0x00580B38
	private void RefreshBetRemindTimeText()
	{
		double serverTime = Singleton<TimeUtil>.Instance.GetServerTime();
		CommonDefine.ICountDown remainTimeDataFormat = Singleton<TimeUtil>.Instance.GetRemainTimeDataFormat3(this.LegMatchData.BetsEndTime * Singleton<TimeUtil>.Instance.Millisecond - serverTime);
		if (remainTimeDataFormat != null && remainTimeDataFormat.CountDownText != null)
		{
			base.GetText(21).SetText(remainTimeDataFormat.CountDownText, true);
		}
	}

	// Token: 0x06013CB1 RID: 81073 RVA: 0x00582994 File Offset: 0x00580B94
	private void RefreshCurrencyItem()
	{
		RacingBetsSeasonData racingBetsSeasonData = ModelBase<RacingBetsModel>.Instance.GetRacingBetsSeasonData();
		this.CommonCurrencyItem.RefreshTemp(racingBetsSeasonData.GetCurrencyItemId(), racingBetsSeasonData.GetCurrencyCount().ToString());
		this.CommonCurrencyItem.SetButtonActive(false);
	}

	// Token: 0x06013CB2 RID: 81074 RVA: 0x005829D7 File Offset: 0x00580BD7
	protected override void OnRemoveEventListener()
	{
		Singleton<EventSystem>.Instance.Remove(EEventName.OnRacingBetsPlayerInfoUpdate, new Action(this.OnRacingBetsPlayerInfoUpdate));
		Singleton<EventSystem>.Instance.Remove(EEventName.OnRacingBetsBettingInfoUpdate, new Action<int, bool>(this.OnRacingBetsBettingInfoUpdate));
	}

	// Token: 0x06013CB3 RID: 81075 RVA: 0x00582A14 File Offset: 0x00580C14
	protected override void OnBeforeHide()
	{
		int exceptIndex = this.DangoActorDataList.FindIndex((IRacingBetsDangoActorData data) => data == this.CurSelectDango);
		this.FadeAllDangoActor(this.DangoActorList, exceptIndex, false);
	}

	// Token: 0x06013CB4 RID: 81076 RVA: 0x00582A47 File Offset: 0x00580C47
	[NullableContext(2)]
	public void PopCameraHandle(EUiViewName viewName, UiViewInfo stackTopInfo, int closeViewId, bool popOrDelete)
	{
		ControllerBase<UiCameraAnimationController>.Instance.PopCameraHandle((EUiViewName)this.CurSelectDango.DangoCamera, stackTopInfo, closeViewId, popOrDelete);
	}

	// Token: 0x06013CB5 RID: 81077 RVA: 0x00582A68 File Offset: 0x00580C68
	private void SelectDangoActor(TsUiSceneDangoActor dangoActor)
	{
		if (this.CurSelectDangoActor == dangoActor)
		{
			return;
		}
		if (this.CurSelectDangoActor != null)
		{
			TsUiSceneDangoActor selectActor = this.CurSelectDangoActor;
			Singleton<UiModelUtil>.Instance.DangoFadeIn(this.CurSelectDangoActor, new ERoleFadeCurveDefine?(ERoleFadeCurveDefine.RoleFadeInCurve), delegate
			{
				if (selectActor.Model != null)
				{
					Singleton<UiModelUtil>.Instance.SetVisible(selectActor.Model, false);
				}
			});
		}
		this.CurSelectDangoActor = dangoActor;
		if (this.CurSelectDangoActor.Model != null)
		{
			Singleton<UiModelUtil>.Instance.SetVisible(this.CurSelectDangoActor.Model, true);
			Singleton<UiModelUtil>.Instance.DangoFadeOut(this.CurSelectDangoActor, null, null);
		}
	}

	// Token: 0x06013CB6 RID: 81078 RVA: 0x00582B04 File Offset: 0x00580D04
	private void FadeAllDangoActor(List<TsUiSceneDangoActor> dangoActorList, int exceptIndex, bool isFadeIn)
	{
		int index;
		Action <>9__0;
		int index2;
		for (index = 0; index < dangoActorList.Count; index = index2 + 1)
		{
			if (index != exceptIndex)
			{
				if (isFadeIn)
				{
					UiModelUtil instance = Singleton<UiModelUtil>.Instance;
					TsUiSceneDangoActor actor = dangoActorList[index];
					ERoleFadeCurveDefine? curveId = new ERoleFadeCurveDefine?(ERoleFadeCurveDefine.RoleFadeInCurve);
					Action fadeFinishCallBack;
					if ((fadeFinishCallBack = <>9__0) == null)
					{
						fadeFinishCallBack = (<>9__0 = delegate()
						{
							if (dangoActorList[index].Model != null)
							{
								Singleton<UiModelUtil>.Instance.SetVisible(dangoActorList[index].Model, false);
							}
						});
					}
					instance.DangoFadeIn(actor, curveId, fadeFinishCallBack);
				}
				else if (dangoActorList[index].Model != null)
				{
					Singleton<UiModelUtil>.Instance.SetVisible(dangoActorList[index].Model, true);
					Singleton<UiModelUtil>.Instance.DangoFadeOut(dangoActorList[index], null, null);
				}
			}
			index2 = index;
		}
	}

	// Token: 0x06013CB7 RID: 81079 RVA: 0x00582C04 File Offset: 0x00580E04
	private void ShowCloseConfirmBox()
	{
		ConfirmBoxDataNew confirmBoxDataNew = new ConfirmBoxDataNew(EConfirmBoxConfigId.RacingBetsBettingEndConfirm);
		confirmBoxDataNew.FunctionMap.Add(2, delegate
		{
			base.CloseMe(null);
		});
		confirmBoxDataNew.FunctionMap.Add(1, delegate
		{
			base.CloseMe(null);
		});
		ControllerBase<ConfirmBoxController>.Instance.ShowConfirmBoxNew(confirmBoxDataNew);
	}

	// Token: 0x06013CB8 RID: 81080 RVA: 0x00582C58 File Offset: 0x00580E58
	private RacingBetsGearItem BetsGearItemCreate()
	{
		RacingBetsGearItem racingBetsGearItem = new RacingBetsGearItem();
		racingBetsGearItem.BindClickGearItemCallBack(new Action<RacingBettingGear>(this.OnClickGearItem));
		return racingBetsGearItem;
	}

	// Token: 0x06013CB9 RID: 81081 RVA: 0x00582C71 File Offset: 0x00580E71
	private RacingBetsDangoOddsItem DangoItemCreate()
	{
		RacingBetsDangoOddsItem racingBetsDangoOddsItem = new RacingBetsDangoOddsItem();
		racingBetsDangoOddsItem.BindClickGearItemCallBack(new Action<IRacingBetsDangoActorData>(this.OnClickDangoItem));
		return racingBetsDangoOddsItem;
	}

	// Token: 0x06013CBA RID: 81082 RVA: 0x00582C8C File Offset: 0x00580E8C
	private void OnClickGearItem(RacingBettingGear data)
	{
		this.CurSelectGearConfig = new RacingBettingGear?(data);
		int gridIndex = this.GearConfigList.ToList<RacingBettingGear>().FindIndex((RacingBettingGear value) => data.Id == value.Id);
		this.BetGearLayout.SelectGridProxy(gridIndex, false);
		this.RefreshBetsPanel(this.LegMatchData, this.CurSelectDango, this.CurSelectGearConfig.Value);
	}

	// Token: 0x06013CBB RID: 81083 RVA: 0x00582D00 File Offset: 0x00580F00
	private void OnClickDangoItem(IRacingBetsDangoActorData data)
	{
		this.CurSelectDango = data2;
		int num = this.DangoActorDataList.FindIndex((IRacingBetsDangoActorData data) => data == this.CurSelectDango);
		this.DangoLayout.SelectGridProxy(num, false);
		this.RefreshUi(this.LegMatchData, data2, this.CurSelectGearConfig.Value);
		this.SelectDangoActor(this.DangoActorList[num]);
		Singleton<UiCameraAnimationManager>.Instance.PushCameraHandleByHandleName(this.CurSelectDango.DangoCamera, true, true, "1001", false, null, null);
	}

	// Token: 0x06013CBC RID: 81084 RVA: 0x00582D8B File Offset: 0x00580F8B
	private void OnClickCloseButton()
	{
		base.CloseMe(null);
	}

	// Token: 0x06013CBD RID: 81085 RVA: 0x00582D94 File Offset: 0x00580F94
	private void OnClickBetsButton()
	{
		if (this.CurSelectDango.IsAbuDango)
		{
			Singleton<Log>.Instance.Warn(ELogModule.RacingBets, ELogAuthor.LRC, "阿布团子不能下注", default(ReadOnlySpan<ValueTuple<string, object>>));
			return;
		}
		ConfirmBoxDataNew confirmBoxDataNew = new ConfirmBoxDataNew(EConfirmBoxConfigId.RacingBetsBettingConfirm);
		confirmBoxDataNew.FunctionMap.Add(2, delegate
		{
			RacingBetsSeasonData racingBetsSeasonData = ModelBase<RacingBetsModel>.Instance.GetRacingBetsSeasonData();
			int betCostCount = racingBetsSeasonData.GetBetCostCount(this.CurSelectGearConfig.Value);
			ControllerBase<RacingBetsController>.Instance.RacingBetsGearRequest(racingBetsSeasonData.Id, this.LegMatchData, this.CurSelectDango.DangoId, this.CurSelectGearConfig.Value.Id, betCostCount);
		});
		ControllerBase<ConfirmBoxController>.Instance.ShowConfirmBoxNew(confirmBoxDataNew);
	}

	// Token: 0x06013CBE RID: 81086 RVA: 0x00582E00 File Offset: 0x00581000
	private void OnClickCancelBetsButton()
	{
		ConfirmBoxDataNew confirmBoxDataNew = new ConfirmBoxDataNew(EConfirmBoxConfigId.RacingBetsCancelBettingConfirm);
		confirmBoxDataNew.FunctionMap.Add(2, delegate
		{
			RacingBetsSeasonData racingBetsSeasonData = ModelBase<RacingBetsModel>.Instance.GetRacingBetsSeasonData();
			ControllerBase<RacingBetsController>.Instance.RacingBetsGearRefundRequest(racingBetsSeasonData.Id, this.LegMatchData, this.LegMatchData.BetDangoId);
		});
		ControllerBase<ConfirmBoxController>.Instance.ShowConfirmBoxNew(confirmBoxDataNew);
	}

	// Token: 0x06013CBF RID: 81087 RVA: 0x00582E3C File Offset: 0x0058103C
	private void OnRacingBetsPlayerInfoUpdate()
	{
		this.RefreshUi(this.LegMatchData, this.CurSelectDango, this.CurSelectGearConfig.Value);
	}

	// Token: 0x06013CC0 RID: 81088 RVA: 0x00582E5C File Offset: 0x0058105C
	private void OnRacingBetsBettingInfoUpdate(int dangoId, bool isBetting)
	{
		this.RefreshUi(this.LegMatchData, this.CurSelectDango, this.CurSelectGearConfig.Value);
		DangoData dangoData = Singleton<DangoManager>.Instance.GetDangoData(this.CurSelectDango.DangoId);
		if (isBetting)
		{
			TsUiSceneDangoActor curSelectDangoActor = this.CurSelectDangoActor;
			if (curSelectDangoActor != null)
			{
				curSelectDangoActor.SetState(EDangoState.ActionPerform, 1f, 0f);
			}
			Singleton<AudioSystem>.Instance.PostEvent(dangoData.DangoConfig.Value.CheerAudio);
			return;
		}
		if (dangoId == this.CurSelectDango.DangoId)
		{
			TsUiSceneDangoActor curSelectDangoActor2 = this.CurSelectDangoActor;
			if (curSelectDangoActor2 != null)
			{
				curSelectDangoActor2.SetState(EDangoState.ActionPerform, 4f, 0f);
			}
			Singleton<AudioSystem>.Instance.PostEvent(dangoData.DangoConfig.Value.DeathAudio);
		}
	}

	// Token: 0x04009A0B RID: 39435
	private bool Tickable = true;

	// Token: 0x04009A0C RID: 39436
	private IRacingBetsDangoActorData CurSelectDango;

	// Token: 0x04009A0D RID: 39437
	private RacingBettingGear? CurSelectGearConfig;

	// Token: 0x04009A0E RID: 39438
	[Nullable(2)]
	private TsUiSceneDangoActor CurSelectDangoActor;

	// Token: 0x04009A0F RID: 39439
	private RacingBetsLegMatchData LegMatchData;

	// Token: 0x04009A10 RID: 39440
	private List<IRacingBetsDangoActorData> DangoActorDataList = new List<IRacingBetsDangoActorData>();

	// Token: 0x04009A11 RID: 39441
	private List<TsUiSceneDangoActor> DangoActorList = new List<TsUiSceneDangoActor>();

	// Token: 0x04009A12 RID: 39442
	private IReadOnlyList<RacingBettingGear> GearConfigList = new List<RacingBettingGear>();

	// Token: 0x04009A13 RID: 39443
	private RacingBetsCostItem BetsCostItem;

	// Token: 0x04009A14 RID: 39444
	private RacingBetsCostItem BetsRewardItem;

	// Token: 0x04009A15 RID: 39445
	private RacingBetsCostItem BetsResultCostItem;

	// Token: 0x04009A16 RID: 39446
	private RacingBetsCostItem BetsResultRewardItem;

	// Token: 0x04009A17 RID: 39447
	private CommonCurrencyItem CommonCurrencyItem;

	// Token: 0x04009A18 RID: 39448
	private GenericLayout<RacingBetsGearItem, RacingBettingGear> BetGearLayout;

	// Token: 0x04009A19 RID: 39449
	private GenericLayout<RacingBetsDangoOddsItem, IRacingBetsDangoActorData> DangoLayout;

	// Token: 0x02008ADD RID: 35549
	[NullableContext(0)]
	private class EComponent
	{
		// Token: 0x0402ED20 RID: 191776
		public const int DangoNameText = 0;

		// Token: 0x0402ED21 RID: 191777
		public const int DangoSkillText = 1;

		// Token: 0x0402ED22 RID: 191778
		public const int DangoLayout = 2;

		// Token: 0x0402ED23 RID: 191779
		public const int LegMatchName = 3;

		// Token: 0x0402ED24 RID: 191780
		public const int BetPanel = 4;

		// Token: 0x0402ED25 RID: 191781
		public const int BetResultPanel = 5;

		// Token: 0x0402ED26 RID: 191782
		public const int CurrencyItem = 6;

		// Token: 0x0402ED27 RID: 191783
		public const int CloseButton = 7;

		// Token: 0x0402ED28 RID: 191784
		public const int BetsGearLayout = 8;

		// Token: 0x0402ED29 RID: 191785
		public const int BetsCostItem = 9;

		// Token: 0x0402ED2A RID: 191786
		public const int BetsRewardItem = 10;

		// Token: 0x0402ED2B RID: 191787
		public const int BetsButton = 11;

		// Token: 0x0402ED2C RID: 191788
		public const int DangoTexture = 12;

		// Token: 0x0402ED2D RID: 191789
		public const int DangoName = 13;

		// Token: 0x0402ED2E RID: 191790
		public const int BetsResultCostItem = 14;

		// Token: 0x0402ED2F RID: 191791
		public const int BetsResultRewardItem = 15;

		// Token: 0x0402ED30 RID: 191792
		public const int RemainCancelItem = 16;

		// Token: 0x0402ED31 RID: 191793
		public const int RemainCancelNumText = 17;

		// Token: 0x0402ED32 RID: 191794
		public const int CancelButton = 18;

		// Token: 0x0402ED33 RID: 191795
		public const int BetUpdateDescText = 19;

		// Token: 0x0402ED34 RID: 191796
		public const int BetUpdateTimeText = 20;

		// Token: 0x0402ED35 RID: 191797
		public const int TimeText = 21;

		// Token: 0x0402ED36 RID: 191798
		public const int TimeDescText = 22;

		// Token: 0x0402ED37 RID: 191799
		public const int BetOddsText = 23;

		// Token: 0x0402ED38 RID: 191800
		public const int NotBetOddsText = 24;

		// Token: 0x0402ED39 RID: 191801
		public const int OddsTimeItem = 25;

		// Token: 0x0402ED3A RID: 191802
		public const int BetInfoPanel = 26;

		// Token: 0x0402ED3B RID: 191803
		public const int AbuInfoPanel = 27;

		// Token: 0x0402ED3C RID: 191804
		public const int AbuDescText = 28;
	}
}
