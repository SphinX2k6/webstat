using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Core.Common;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.InputSetting;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x0200114C RID: 4428
[NullableContext(2)]
[Nullable(0)]
public class RhythmShipGameView : UiViewBase
{
	// Token: 0x060074A5 RID: 29861 RVA: 0x001E94C4 File Offset: 0x001E76C4
	[NullableContext(1)]
	public RhythmShipGameView(UiViewInfo viewInfo) : base(viewInfo)
	{
	}

	// Token: 0x060074A6 RID: 29862 RVA: 0x001E94F8 File Offset: 0x001E76F8
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUIButtonComponent)),
			new ValueTuple<int, Type>(1, typeof(UUIText)),
			new ValueTuple<int, Type>(2, typeof(UUIText)),
			new ValueTuple<int, Type>(3, typeof(UUIText)),
			new ValueTuple<int, Type>(4, typeof(UUIItem)),
			new ValueTuple<int, Type>(5, typeof(UUIItem)),
			new ValueTuple<int, Type>(6, typeof(UUIButtonComponent)),
			new ValueTuple<int, Type>(7, typeof(UUIButtonComponent)),
			new ValueTuple<int, Type>(8, typeof(UUIButtonComponent)),
			new ValueTuple<int, Type>(9, typeof(UUIButtonComponent)),
			new ValueTuple<int, Type>(10, typeof(UUIButtonComponent)),
			new ValueTuple<int, Type>(11, typeof(UUIButtonComponent)),
			new ValueTuple<int, Type>(12, typeof(UUIItem)),
			new ValueTuple<int, Type>(13, typeof(UUITexture)),
			new ValueTuple<int, Type>(14, typeof(UUIText)),
			new ValueTuple<int, Type>(15, typeof(UUISprite)),
			new ValueTuple<int, Type>(16, typeof(UUIItem)),
			new ValueTuple<int, Type>(17, typeof(UUITexture)),
			new ValueTuple<int, Type>(18, typeof(UUIItem)),
			new ValueTuple<int, Type>(19, typeof(UUIText)),
			new ValueTuple<int, Type>(20, typeof(UUIItem))
		};
		this.BtnBindInfo = new List<ValueTuple<int, Delegate>>
		{
			new ValueTuple<int, Delegate>(0, new Action(this.OnBtnPauseClick))
		};
	}

	// Token: 0x060074A7 RID: 29863 RVA: 0x001E9710 File Offset: 0x001E7910
	protected override UniTask OnBeforeStartAsync()
	{
		RhythmShipGameView.<OnBeforeStartAsync>d__17 <OnBeforeStartAsync>d__;
		<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnBeforeStartAsync>d__.<>4__this = this;
		<OnBeforeStartAsync>d__.<>1__state = -1;
		<OnBeforeStartAsync>d__.<>t__builder.Start<RhythmShipGameView.<OnBeforeStartAsync>d__17>(ref <OnBeforeStartAsync>d__);
		return <OnBeforeStartAsync>d__.<>t__builder.Task;
	}

	// Token: 0x060074A8 RID: 29864 RVA: 0x001E9754 File Offset: 0x001E7954
	protected override void OnBeforeShow()
	{
		base.OnBeforeShow();
		UUIText text = base.GetText(3);
		if (text != null)
		{
			text.SetUIActive(false);
		}
		UUITexture texture = base.GetTexture(5);
		if (texture != null)
		{
			texture.SetUIActive(false);
		}
		this.FeverProgressSprite = base.GetSprite(15);
		UUISprite feverProgressSprite = this.FeverProgressSprite;
		if (feverProgressSprite != null)
		{
			feverProgressSprite.SetWidth((float)this.DefaultProgessWidth * ((float)this.FeverScoreCache / (float)ModelBase<RhythmGameModel>.Instance.FeverCeiling));
		}
		this.ScroeMultiText = base.GetText(1);
		UUIText scroeMultiText = this.ScroeMultiText;
		if (scroeMultiText != null)
		{
			DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(1, 1);
			defaultInterpolatedStringHandler.AppendLiteral("x");
			defaultInterpolatedStringHandler.AppendFormatted<int>(this.MultiCache);
			scroeMultiText.SetText(defaultInterpolatedStringHandler.ToStringAndClear(), true);
		}
		this.ScoreText = base.GetText(2);
		UUIText scoreText = this.ScoreText;
		if (scoreText != null)
		{
			scoreText.SetText(this.ScoreCache.ToString(), true);
		}
		this.CurLineBtnDownCount = 0;
	}

	// Token: 0x060074A9 RID: 29865 RVA: 0x001E9840 File Offset: 0x001E7A40
	private void RefreshAutoJudgeInfo(int autoJudgeCount)
	{
		UUIText text = base.GetText(14);
		text.SetText(autoJudgeCount.ToString(), true);
		UUIItem uuiitem = text;
		bool bUseChangeColor = autoJudgeCount <= 0;
		FColor? fcolor = new FColor?(text.changeColor);
		uuiitem.SetChangeColor(bUseChangeColor, fcolor);
		UUITexture texture = base.GetTexture(13);
		UUIItem uuiitem2 = texture;
		bool bUseChangeColor2 = autoJudgeCount <= 0;
		fcolor = new FColor?(texture.changeColor);
		uuiitem2.SetChangeColor(bUseChangeColor2, fcolor);
	}

	// Token: 0x060074AA RID: 29866 RVA: 0x001E98A3 File Offset: 0x001E7AA3
	protected override void OnAfterShow()
	{
		base.OnAfterShow();
	}

	// Token: 0x060074AB RID: 29867 RVA: 0x001E98AC File Offset: 0x001E7AAC
	protected override void OnAddEventListener()
	{
		base.OnAddEventListener();
		Singleton<EventSystem>.Instance.Add<EKuroRhythmGameRating?, FKuroRhythmGameStatistics>(EEventName.OnRhythmGameNoteResultUpdate, new Action<EKuroRhythmGameRating?, FKuroRhythmGameStatistics>(this.OnRhythmGameNoteResultUpdate));
		Singleton<EventSystem>.Instance.Add(EEventName.OnRhythmGameFeverModeChanged, new Action<bool>(this.OnRhythmGameFeverModeChanged));
		Singleton<EventSystem>.Instance.Add(EEventName.OnRhythmGameFeverScoreChanged, new Action<int, int>(this.OnRhythmGameFeverScoreChanged));
		Singleton<EventSystem>.Instance.Add(EEventName.OnRhythmGameSpeedLevelConfigIndexChanged, new Action<int>(this.OnRhythmGameSpeedLevelConfigIndexChanged));
		Singleton<EventSystem>.Instance.Add<TTimerAction>(EEventName.OnRhythmGameStartCoolDown, new Action<TTimerAction>(this.OnRhythmGameStartCoolDown));
		Singleton<EventSystem>.Instance.Add(EEventName.OnRhythmGameAutoJudgeCountChanged, new Action<int>(this.OnRhythmGameAutoJudgeCountChanged));
		Singleton<EventSystem>.Instance.Add(EEventName.OnRhythmGameEndCoolDown, new Action(this.OnRhythmGameEndCoolDown));
		if (Singleton<Info>.Instance.IsInTouch())
		{
			Singleton<EventSystem>.Instance.Add(EEventName.OnTouchUiEditSave, new Action<ECommonTouchUiEditGroup>(this.OnTouchUiEditSave));
		}
		UUIButtonComponent button = base.GetButton(6);
		if (button != null)
		{
			button.OnPointDownCallBack.Bind(new Action(this.OnBtnFlickLeftClick));
		}
		UUIButtonComponent button2 = base.GetButton(7);
		if (button2 != null)
		{
			button2.OnPointDownCallBack.Bind(new Action(this.OnBtnTapLeftClick));
		}
		UUIButtonComponent button3 = base.GetButton(8);
		if (button3 != null)
		{
			button3.OnPointDownCallBack.Bind(new Action(this.OnBtnLineClick));
		}
		UUIButtonComponent button4 = base.GetButton(8);
		if (button4 != null)
		{
			button4.OnPointUpCallBack.Bind(new Action(this.OnBtnLineUp));
		}
		UUIButtonComponent button5 = base.GetButton(8);
		if (button5 != null)
		{
			button5.OnPointCancelCallBack.Bind(new Action(this.OnBtnLineUp));
		}
		UUIButtonComponent button6 = base.GetButton(9);
		if (button6 != null)
		{
			button6.OnPointDownCallBack.Bind(new Action(this.OnBtnFlickRightClick));
		}
		UUIButtonComponent button7 = base.GetButton(10);
		if (button7 != null)
		{
			button7.OnPointDownCallBack.Bind(new Action(this.OnBtnTapRightClick));
		}
		UUIButtonComponent button8 = base.GetButton(11);
		if (button8 != null)
		{
			button8.OnPointDownCallBack.Bind(new Action(this.OnBtnLineClick));
		}
		UUIButtonComponent button9 = base.GetButton(11);
		if (button9 != null)
		{
			button9.OnPointUpCallBack.Bind(new Action(this.OnBtnLineUp));
		}
		UUIButtonComponent button10 = base.GetButton(11);
		if (button10 == null)
		{
			return;
		}
		button10.OnPointCancelCallBack.Bind(new Action(this.OnBtnLineUp));
	}

	// Token: 0x060074AC RID: 29868 RVA: 0x001E9B10 File Offset: 0x001E7D10
	protected override void OnRemoveEventListener()
	{
		base.OnRemoveEventListener();
		Singleton<EventSystem>.Instance.Remove<EKuroRhythmGameRating?, FKuroRhythmGameStatistics>(EEventName.OnRhythmGameNoteResultUpdate, new Action<EKuroRhythmGameRating?, FKuroRhythmGameStatistics>(this.OnRhythmGameNoteResultUpdate));
		Singleton<EventSystem>.Instance.Remove(EEventName.OnRhythmGameFeverModeChanged, new Action<bool>(this.OnRhythmGameFeverModeChanged));
		Singleton<EventSystem>.Instance.Remove(EEventName.OnRhythmGameFeverScoreChanged, new Action<int, int>(this.OnRhythmGameFeverScoreChanged));
		Singleton<EventSystem>.Instance.Remove(EEventName.OnRhythmGameSpeedLevelConfigIndexChanged, new Action<int>(this.OnRhythmGameSpeedLevelConfigIndexChanged));
		Singleton<EventSystem>.Instance.Remove<TTimerAction>(EEventName.OnRhythmGameStartCoolDown, new Action<TTimerAction>(this.OnRhythmGameStartCoolDown));
		Singleton<EventSystem>.Instance.Remove(EEventName.OnRhythmGameEndCoolDown, new Action(this.OnRhythmGameEndCoolDown));
		Singleton<EventSystem>.Instance.Remove(EEventName.OnRhythmGameAutoJudgeCountChanged, new Action<int>(this.OnRhythmGameAutoJudgeCountChanged));
		if (Singleton<Info>.Instance.IsInTouch())
		{
			Singleton<EventSystem>.Instance.Remove(EEventName.OnTouchUiEditSave, new Action<ECommonTouchUiEditGroup>(this.OnTouchUiEditSave));
		}
	}

	// Token: 0x060074AD RID: 29869 RVA: 0x001E9C0F File Offset: 0x001E7E0F
	private void OnRhythmGameStartCoolDown(TTimerAction callback)
	{
		RhythmShipCoolDownPanel coolDownPanel = this.CoolDownPanel;
		if (coolDownPanel == null)
		{
			return;
		}
		coolDownPanel.PlayCoolDownSequence(callback);
	}

	// Token: 0x060074AE RID: 29870 RVA: 0x001E9C22 File Offset: 0x001E7E22
	private void OnRhythmGameAutoJudgeCountChanged(int autoJudgeCount)
	{
		this.RefreshAutoJudgeInfo(autoJudgeCount);
	}

	// Token: 0x060074AF RID: 29871 RVA: 0x001E9C2B File Offset: 0x001E7E2B
	private void OnRhythmGameEndCoolDown()
	{
		RhythmShipCoolDownPanel coolDownPanel = this.CoolDownPanel;
		if (coolDownPanel == null)
		{
			return;
		}
		coolDownPanel.StopCoolDownSequence();
	}

	// Token: 0x060074B0 RID: 29872 RVA: 0x001E9C40 File Offset: 0x001E7E40
	private void OnRhythmGameSpeedLevelConfigIndexChanged(int newValue)
	{
		int scoreMultiplierByLevel = ModelBase<RhythmGameModel>.Instance.GetScoreMultiplierByLevel(newValue);
		this.MultiCache = scoreMultiplierByLevel;
		UUIText scroeMultiText = this.ScroeMultiText;
		if (scroeMultiText == null)
		{
			return;
		}
		DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(1, 1);
		defaultInterpolatedStringHandler.AppendLiteral("x");
		defaultInterpolatedStringHandler.AppendFormatted<int>(scoreMultiplierByLevel);
		scroeMultiText.SetText(defaultInterpolatedStringHandler.ToStringAndClear(), true);
	}

	// Token: 0x060074B1 RID: 29873 RVA: 0x001E9C98 File Offset: 0x001E7E98
	private void OnRhythmGameNoteResultUpdate(EKuroRhythmGameRating? result, FKuroRhythmGameStatistics statistics)
	{
		EKuroRhythmGameRating? value = result;
		Log instance = Singleton<Log>.Instance;
		ELogModule module = ELogModule.RhythmGame;
		ELogAuthor author = ELogAuthor.CH;
		DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(52, 2);
		defaultInterpolatedStringHandler.AppendLiteral("OnRhythmGameNoteResultUpdate: result: ");
		defaultInterpolatedStringHandler.AppendFormatted<EKuroRhythmGameRating?>(value);
		defaultInterpolatedStringHandler.AppendLiteral(", statistics: ");
		defaultInterpolatedStringHandler.AppendFormatted<FKuroRhythmGameStatistics>(statistics);
		instance.Info(module, author, defaultInterpolatedStringHandler.ToStringAndClear(), default(ReadOnlySpan<ValueTuple<string, object>>));
		if (value != null)
		{
			RhythmGameHitResultPanel hitResultPanel = this.HitResultPanel;
			if (hitResultPanel != null)
			{
				hitResultPanel.SetHitResult(value.Value);
			}
		}
		UUIText scoreText = this.ScoreText;
		if (scoreText != null)
		{
			scoreText.SetUIActive(true);
		}
		if (statistics == null)
		{
			return;
		}
		UUIText scoreText2 = this.ScoreText;
		if (scoreText2 != null)
		{
			scoreText2.SetText(statistics.TotalScore.ToString(), true);
		}
		this.ScoreCache = statistics.TotalScore;
		RhythmGameComboPanel comboPanel = this.ComboPanel;
		if (comboPanel == null)
		{
			return;
		}
		comboPanel.SetCombo(statistics.Combo);
	}

	// Token: 0x060074B2 RID: 29874 RVA: 0x001E9D7C File Offset: 0x001E7F7C
	private void OnRhythmGameFeverModeChanged(bool bFeverActive)
	{
		if (bFeverActive)
		{
			RhythmGameRoleInfoPanel roleInfoPanel = this.RoleInfoPanel;
			if (roleInfoPanel == null)
			{
				return;
			}
			roleInfoPanel.ShowRoleFeverInfo();
		}
	}

	// Token: 0x060074B3 RID: 29875 RVA: 0x001E9D94 File Offset: 0x001E7F94
	private unsafe void OnRhythmGameFeverScoreChanged(int newScore, int oldScore)
	{
		float num = (float)newScore / (float)ModelBase<RhythmGameModel>.Instance.FeverCeiling;
		UUISprite feverProgressSprite = this.FeverProgressSprite;
		if (feverProgressSprite != null)
		{
			feverProgressSprite.SetWidth((float)this.DefaultProgessWidth * num);
		}
		this.FeverScoreCache = newScore;
		Log instance = Singleton<Log>.Instance;
		ELogModule module = ELogModule.RhythmGame;
		ELogAuthor author = ELogAuthor.CH;
		string message = "OnRhythmGameFeverScoreChanged:";
		<>y__InlineArray3<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray3<ValueTuple<string, object>>);
		*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("newScore", newScore);
		*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("oldScore", oldScore);
		*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 2) = new ValueTuple<string, object>("width", (float)this.DefaultProgessWidth * num);
		instance.Info(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 3));
	}

	// Token: 0x060074B4 RID: 29876 RVA: 0x001E9E58 File Offset: 0x001E8058
	private void OnBtnPauseClick()
	{
		if (!ControllerBase<RhythmGameController>.Instance.PlayerCanInput)
		{
			return;
		}
		Singleton<Log>.Instance.Info(ELogModule.RhythmGame, ELogAuthor.CH, "----OnBtnPauseClick----", default(ReadOnlySpan<ValueTuple<string, object>>));
		Singleton<UiManager>.Instance.OpenView(EUiViewName.RhythmShipPauseView, null, null);
	}

	// Token: 0x060074B5 RID: 29877 RVA: 0x001E9EA2 File Offset: 0x001E80A2
	private void OnBtnTapLeftClick()
	{
		ControllerBase<RhythmGameController>.Instance.OnPlayerInputDown(EKuroRhythmGameInputType.TapLeft);
	}

	// Token: 0x060074B6 RID: 29878 RVA: 0x001E9EAF File Offset: 0x001E80AF
	private void OnBtnTapRightClick()
	{
		ControllerBase<RhythmGameController>.Instance.OnPlayerInputDown(EKuroRhythmGameInputType.TapRight);
	}

	// Token: 0x060074B7 RID: 29879 RVA: 0x001E9EBC File Offset: 0x001E80BC
	private void OnBtnFlickLeftClick()
	{
		ControllerBase<RhythmGameController>.Instance.OnPlayerInputDown(EKuroRhythmGameInputType.FlickLeft);
	}

	// Token: 0x060074B8 RID: 29880 RVA: 0x001E9EC9 File Offset: 0x001E80C9
	private void OnBtnFlickRightClick()
	{
		ControllerBase<RhythmGameController>.Instance.OnPlayerInputDown(EKuroRhythmGameInputType.FlickRight);
	}

	// Token: 0x060074B9 RID: 29881 RVA: 0x001E9ED6 File Offset: 0x001E80D6
	private void OnBtnLineClick()
	{
		this.CurLineBtnDownCount++;
		if (this.CurLineBtnDownCount == 1)
		{
			ControllerBase<RhythmGameController>.Instance.OnPlayerInputDown(EKuroRhythmGameInputType.Line);
		}
	}

	// Token: 0x060074BA RID: 29882 RVA: 0x001E9EFA File Offset: 0x001E80FA
	private void OnBtnLineUp()
	{
		this.CurLineBtnDownCount--;
		if (this.CurLineBtnDownCount == 0)
		{
			ControllerBase<RhythmGameController>.Instance.OnPlayerInputUp(EKuroRhythmGameInputType.Line);
		}
	}

	// Token: 0x060074BB RID: 29883 RVA: 0x001E9F20 File Offset: 0x001E8120
	[NullableContext(1)]
	[return: Nullable(new byte[]
	{
		2,
		1
	})]
	public override UUIItem[] GetGuideUiItemAndUiItemForShowEx(string[] configParams)
	{
		if (configParams[0] == "Button")
		{
			int num = int.Parse(configParams[1]);
			if (num >= 0 && num < this.buttonList.Length)
			{
				UUIButtonComponent button = base.GetButton((int)this.buttonList[num]);
				TWeakObjectPtr<UUIItem>? tweakObjectPtr = (button != null) ? new TWeakObjectPtr<UUIItem>?(button.RootUIComp) : null;
				if (tweakObjectPtr == null)
				{
					return null;
				}
				return new UUIItem[]
				{
					tweakObjectPtr.Value,
					tweakObjectPtr.Value
				};
			}
		}
		return null;
	}

	// Token: 0x060074BC RID: 29884 RVA: 0x001E9FAD File Offset: 0x001E81AD
	private void OnTouchUiEditSave(ECommonTouchUiEditGroup group)
	{
		if (group != ECommonTouchUiEditGroup.RhythmShip)
		{
			return;
		}
		this.ApplyTouchUiData();
	}

	// Token: 0x060074BD RID: 29885 RVA: 0x001E9FBA File Offset: 0x001E81BA
	private void ApplyTouchUiData()
	{
		if (!Singleton<Info>.Instance.IsInTouch())
		{
			return;
		}
		TouchUiEditApplyHelper.ApplyCommonTouchUiEditData(ECommonTouchUiEditGroup.RhythmShip, this, "UiView_RhythmShipGame");
	}

	// Token: 0x0400384D RID: 14413
	private readonly int DefaultProgessWidth = 475;

	// Token: 0x0400384E RID: 14414
	[Nullable(1)]
	private readonly RhythmShipGameView.EViewComponent[] buttonList = new RhythmShipGameView.EViewComponent[]
	{
		RhythmShipGameView.EViewComponent.BtnLeft1,
		RhythmShipGameView.EViewComponent.BtnLeft2,
		RhythmShipGameView.EViewComponent.BtnLeft3,
		RhythmShipGameView.EViewComponent.BtnRight1,
		RhythmShipGameView.EViewComponent.BtnRight2,
		RhythmShipGameView.EViewComponent.BtnRight3
	};

	// Token: 0x0400384F RID: 14415
	private int RoleId;

	// Token: 0x04003850 RID: 14416
	private UUISprite FeverProgressSprite;

	// Token: 0x04003851 RID: 14417
	private UUIText ScroeMultiText;

	// Token: 0x04003852 RID: 14418
	private UUIText ScoreText;

	// Token: 0x04003853 RID: 14419
	private RhythmGameComboPanel ComboPanel;

	// Token: 0x04003854 RID: 14420
	private RhythmShipCoolDownPanel CoolDownPanel;

	// Token: 0x04003855 RID: 14421
	private RhythmGameHitResultPanel HitResultPanel;

	// Token: 0x04003856 RID: 14422
	private RhythmGameRoleInfoPanel RoleInfoPanel;

	// Token: 0x04003857 RID: 14423
	private int MultiCache = 1;

	// Token: 0x04003858 RID: 14424
	private int ScoreCache;

	// Token: 0x04003859 RID: 14425
	private int FeverScoreCache;

	// Token: 0x0400385A RID: 14426
	private int CurLineBtnDownCount;

	// Token: 0x020074D6 RID: 29910
	[NullableContext(0)]
	private enum EViewComponent
	{
		// Token: 0x04028553 RID: 165203
		BtnPause,
		// Token: 0x04028554 RID: 165204
		TextScoreMulti,
		// Token: 0x04028555 RID: 165205
		TextScore,
		// Token: 0x04028556 RID: 165206
		TextScroeProgress,
		// Token: 0x04028557 RID: 165207
		PnlCombo,
		// Token: 0x04028558 RID: 165208
		IconHitResult,
		// Token: 0x04028559 RID: 165209
		BtnLeft1,
		// Token: 0x0402855A RID: 165210
		BtnLeft2,
		// Token: 0x0402855B RID: 165211
		BtnLeft3,
		// Token: 0x0402855C RID: 165212
		BtnRight1,
		// Token: 0x0402855D RID: 165213
		BtnRight2,
		// Token: 0x0402855E RID: 165214
		BtnRight3,
		// Token: 0x0402855F RID: 165215
		ShieldItem,
		// Token: 0x04028560 RID: 165216
		ShieldIcon,
		// Token: 0x04028561 RID: 165217
		TextShieldNum,
		// Token: 0x04028562 RID: 165218
		SprProgress,
		// Token: 0x04028563 RID: 165219
		PnlRoleSpeak,
		// Token: 0x04028564 RID: 165220
		IconRole,
		// Token: 0x04028565 RID: 165221
		PnlSpeak,
		// Token: 0x04028566 RID: 165222
		TextSpeak,
		// Token: 0x04028567 RID: 165223
		PnlTime
	}
}
