using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.Activity.ActivityContent.SpringManor;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x02001121 RID: 4385
[NullableContext(1)]
[Nullable(0)]
public class GuessJokerGamePlayView : UiViewBase, IUiCameraBehavior
{
	// Token: 0x06007241 RID: 29249 RVA: 0x001DD320 File Offset: 0x001DB520
	public GuessJokerGamePlayView(UiViewInfo viewInfo) : base(viewInfo)
	{
	}

	// Token: 0x06007242 RID: 29250 RVA: 0x001DD358 File Offset: 0x001DB558
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUIItem)),
			new ValueTuple<int, Type>(1, typeof(UUIItem)),
			new ValueTuple<int, Type>(2, typeof(UUIItem)),
			new ValueTuple<int, Type>(3, typeof(UUIText)),
			new ValueTuple<int, Type>(4, typeof(UUIItem)),
			new ValueTuple<int, Type>(5, typeof(UUIItem)),
			new ValueTuple<int, Type>(6, typeof(UUIItem)),
			new ValueTuple<int, Type>(8, typeof(UUIButtonComponent)),
			new ValueTuple<int, Type>(7, typeof(UUIButtonComponent)),
			new ValueTuple<int, Type>(10, typeof(UUIButtonComponent)),
			new ValueTuple<int, Type>(9, typeof(UUIItem)),
			new ValueTuple<int, Type>(11, typeof(UUIItem)),
			new ValueTuple<int, Type>(12, typeof(UUIItem)),
			new ValueTuple<int, Type>(13, typeof(UUIItem)),
			new ValueTuple<int, Type>(14, typeof(UUISliderComponent)),
			new ValueTuple<int, Type>(15, typeof(UUIText)),
			new ValueTuple<int, Type>(16, typeof(UUIItem)),
			new ValueTuple<int, Type>(17, typeof(UUIItem)),
			new ValueTuple<int, Type>(18, typeof(UUIItem)),
			new ValueTuple<int, Type>(19, typeof(UUIItem)),
			new ValueTuple<int, Type>(20, typeof(UUIItem)),
			new ValueTuple<int, Type>(21, typeof(UUIItem)),
			new ValueTuple<int, Type>(22, typeof(UUIItem)),
			new ValueTuple<int, Type>(23, typeof(UUIItem)),
			new ValueTuple<int, Type>(24, typeof(UUIItem)),
			new ValueTuple<int, Type>(25, typeof(UUIItem)),
			new ValueTuple<int, Type>(26, typeof(UUIItem)),
			new ValueTuple<int, Type>(27, typeof(UUIItem)),
			new ValueTuple<int, Type>(28, typeof(UUIItem)),
			new ValueTuple<int, Type>(29, typeof(UUIItem)),
			new ValueTuple<int, Type>(30, typeof(UUIItem)),
			new ValueTuple<int, Type>(31, typeof(UUISprite)),
			new ValueTuple<int, Type>(32, typeof(UUIButtonComponent)),
			new ValueTuple<int, Type>(33, typeof(UUIItem)),
			new ValueTuple<int, Type>(34, typeof(UUIText)),
			new ValueTuple<int, Type>(35, typeof(UUIExtendToggle)),
			new ValueTuple<int, Type>(36, typeof(UUIText)),
			new ValueTuple<int, Type>(37, typeof(UUIItem)),
			new ValueTuple<int, Type>(38, typeof(UUIItem)),
			new ValueTuple<int, Type>(39, typeof(UUIText)),
			new ValueTuple<int, Type>(40, typeof(UUIItem)),
			new ValueTuple<int, Type>(41, typeof(UUIItem)),
			new ValueTuple<int, Type>(42, typeof(UUIButtonComponent)),
			new ValueTuple<int, Type>(43, typeof(UUIButtonComponent)),
			new ValueTuple<int, Type>(44, typeof(UUIButtonComponent)),
			new ValueTuple<int, Type>(45, typeof(UUIText)),
			new ValueTuple<int, Type>(46, typeof(UUIText)),
			new ValueTuple<int, Type>(47, typeof(UUISprite))
		};
		this.BtnBindInfo = new List<ValueTuple<int, Delegate>>
		{
			new ValueTuple<int, Delegate>(8, new Action(this.OnPlayCardButtonClick)),
			new ValueTuple<int, Delegate>(35, new Action<EToggleState>(this.OnHideToggleClick)),
			new ValueTuple<int, Delegate>(44, new Action(this.OnMaskButtonClick))
		};
	}

	// Token: 0x06007243 RID: 29251 RVA: 0x001DD80C File Offset: 0x001DBA0C
	protected override UniTask OnBeforeStartAsync()
	{
		GuessJokerGamePlayView.<OnBeforeStartAsync>d__24 <OnBeforeStartAsync>d__;
		<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnBeforeStartAsync>d__.<>4__this = this;
		<OnBeforeStartAsync>d__.<>1__state = -1;
		<OnBeforeStartAsync>d__.<>t__builder.Start<GuessJokerGamePlayView.<OnBeforeStartAsync>d__24>(ref <OnBeforeStartAsync>d__);
		return <OnBeforeStartAsync>d__.<>t__builder.Task;
	}

	// Token: 0x06007244 RID: 29252 RVA: 0x001DD84F File Offset: 0x001DBA4F
	protected override void OnBeforeShow()
	{
		this.PauseTimeDilation();
		this.InitPlayer();
		this.InitButtons();
		this.InitRound();
		this.InitInfo();
	}

	// Token: 0x06007245 RID: 29253 RVA: 0x001DD86F File Offset: 0x001DBA6F
	protected override void OnAfterShow()
	{
		GuessJokerGamePlayModel instance = ModelBase<GuessJokerGamePlayModel>.Instance;
		if (instance == null)
		{
			return;
		}
		instance.SetActiveDialogLogic(this.DialogLogic);
	}

	// Token: 0x06007246 RID: 29254 RVA: 0x001DD886 File Offset: 0x001DBA86
	protected override void OnBeforeHide()
	{
		GuessJokerGamePlayModel instance = ModelBase<GuessJokerGamePlayModel>.Instance;
		if (instance != null)
		{
			instance.SetActiveDialogLogic(null);
		}
		GuessJokerDialogLogic dialogLogic = this.DialogLogic;
		if (dialogLogic != null)
		{
			dialogLogic.Clear();
		}
		this.ResumeTimeDilation();
	}

	// Token: 0x06007247 RID: 29255 RVA: 0x001DD8B0 File Offset: 0x001DBAB0
	protected void PauseTimeDilation()
	{
		Singleton<UiTimeDilation>.Instance.AddWaitSetTimeDilationTag("GuessJokerGamePlayView");
	}

	// Token: 0x06007248 RID: 29256 RVA: 0x001DD8C1 File Offset: 0x001DBAC1
	protected void ResumeTimeDilation()
	{
		Singleton<UiTimeDilation>.Instance.DeleteWaitSetTimeDilationTag("GuessJokerGamePlayView");
	}

	// Token: 0x06007249 RID: 29257 RVA: 0x001DD8D4 File Offset: 0x001DBAD4
	public void PushCameraHandle(EUiViewName viewName, int viewId, bool isBlend)
	{
		GuessJokerAiConfig? jokerAiConfigByEntityId = ConfigBase<GuessJokerConfig>.Instance.GetJokerAiConfigByEntityId(this.NpcId);
		if (jokerAiConfigByEntityId == null)
		{
			return;
		}
		string cameraNameByCameraId = GuessJokerUtils.GetCameraNameByCameraId(jokerAiConfigByEntityId.Value.GamePlayCameraId);
		if (cameraNameByCameraId != null)
		{
			ControllerBase<UiCameraAnimationController>.Instance.PushCameraHandle((EUiViewName)cameraNameByCameraId, new int?(viewId), isBlend);
		}
	}

	// Token: 0x0600724A RID: 29258 RVA: 0x001DD92C File Offset: 0x001DBB2C
	[NullableContext(2)]
	public void PopCameraHandle(EUiViewName viewName, UiViewInfo stackTopInfo, int closeViewId, bool popOrDelete)
	{
		GuessJokerAiConfig? jokerAiConfigByEntityId = ConfigBase<GuessJokerConfig>.Instance.GetJokerAiConfigByEntityId(this.NpcId);
		if (jokerAiConfigByEntityId == null)
		{
			return;
		}
		string cameraNameByCameraId = GuessJokerUtils.GetCameraNameByCameraId(jokerAiConfigByEntityId.Value.GamePlayCameraId);
		if (cameraNameByCameraId != null)
		{
			ControllerBase<UiCameraAnimationController>.Instance.PopCameraHandle((EUiViewName)cameraNameByCameraId, stackTopInfo, closeViewId, popOrDelete);
		}
	}

	// Token: 0x0600724B RID: 29259 RVA: 0x001DD980 File Offset: 0x001DBB80
	private void OnGamePlayViewSequenceFinish(string sequenceName)
	{
		Action action;
		if (this.SequenceFinishCallbackMap.TryGetValue(sequenceName, out action) && action != null)
		{
			action();
			this.SequenceFinishCallbackMap.Remove(sequenceName);
		}
	}

	// Token: 0x0600724C RID: 29260 RVA: 0x001DD9B5 File Offset: 0x001DBBB5
	private void OnEventSequence(string sequenceName, string eventName)
	{
		if (sequenceName == "LevelChange" && eventName == "LevelChange")
		{
			this.UpdateRoundNumber();
		}
	}

	// Token: 0x0600724D RID: 29261 RVA: 0x001DD9D7 File Offset: 0x001DBBD7
	private void InitPlayer()
	{
		this.AiPlayerItem.SetRoleData(ModelBase<GuessJokerGamePlayModel>.Instance.GetRoleData(EGuessJokerPlayerType.Ai));
		this.MePlayerItem.SetRoleData(ModelBase<GuessJokerGamePlayModel>.Instance.GetRoleData(EGuessJokerPlayerType.Me));
	}

	// Token: 0x0600724E RID: 29262 RVA: 0x001DDA08 File Offset: 0x001DBC08
	private void InitButtons()
	{
		int roleId = ModelBase<GuessJokerGamePlayModel>.Instance.GetRoleId();
		GuessJokerAiConfig? jokerAiConfigByRoleId = ConfigBase<GuessJokerConfig>.Instance.GetJokerAiConfigByRoleId(roleId);
		if (jokerAiConfigByRoleId == null)
		{
			return;
		}
		string useSkillText = jokerAiConfigByRoleId.Value.UseSkillText;
		if (useSkillText != null)
		{
			string text = ConfigMultiTextLang.GetLocalTextNew(useSkillText, null) ?? "";
			GuessJokerSkillItem useSkillItem = this.UseSkillItem;
			if (useSkillItem != null)
			{
				useSkillItem.SetText(text);
			}
		}
		string giveUpSkillText = jokerAiConfigByRoleId.Value.GiveUpSkillText;
		if (giveUpSkillText != null)
		{
			string text2 = ConfigMultiTextLang.GetLocalTextNew(giveUpSkillText, null) ?? "";
			GuessJokerSkillItem giveUpSkillItem = this.GiveUpSkillItem;
			if (giveUpSkillItem == null)
			{
				return;
			}
			giveUpSkillItem.SetText(text2);
		}
	}

	// Token: 0x0600724F RID: 29263 RVA: 0x001DDAA8 File Offset: 0x001DBCA8
	private UniTask InitAllCards()
	{
		GuessJokerGamePlayView.<InitAllCards>d__36 <InitAllCards>d__;
		<InitAllCards>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<InitAllCards>d__.<>4__this = this;
		<InitAllCards>d__.<>1__state = -1;
		<InitAllCards>d__.<>t__builder.Start<GuessJokerGamePlayView.<InitAllCards>d__36>(ref <InitAllCards>d__);
		return <InitAllCards>d__.<>t__builder.Task;
	}

	// Token: 0x06007250 RID: 29264 RVA: 0x001DDAEC File Offset: 0x001DBCEC
	private UniTask InitBlankCard()
	{
		GuessJokerGamePlayView.<InitBlankCard>d__37 <InitBlankCard>d__;
		<InitBlankCard>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<InitBlankCard>d__.<>4__this = this;
		<InitBlankCard>d__.<>1__state = -1;
		<InitBlankCard>d__.<>t__builder.Start<GuessJokerGamePlayView.<InitBlankCard>d__37>(ref <InitBlankCard>d__);
		return <InitBlankCard>d__.<>t__builder.Task;
	}

	// Token: 0x06007251 RID: 29265 RVA: 0x001DDB30 File Offset: 0x001DBD30
	private void InitRound()
	{
		int roundNumber = ModelBase<GuessJokerGamePlayModel>.Instance.RoundNumber;
		UUIText text = base.GetText(3);
		DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(0, 1);
		defaultInterpolatedStringHandler.AppendFormatted<int>((roundNumber == 0) ? 1 : roundNumber);
		text.SetText(defaultInterpolatedStringHandler.ToStringAndClear(), true);
		this.BlankCardItem.RefreshCardItem();
		foreach (GuessJokerCardItem guessJokerCardItem in this.CardItemMap.Values)
		{
			if (guessJokerCardItem.Data.IsBlank())
			{
				guessJokerCardItem.RefreshCardItem();
			}
		}
	}

	// Token: 0x06007252 RID: 29266 RVA: 0x001DDBD8 File Offset: 0x001DBDD8
	private void InitInfo()
	{
		string playerNameByType = ModelBase<GuessJokerGamePlayModel>.Instance.GetPlayerNameByType(EGuessJokerPlayerType.Ai);
		Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(39), "GuessJoker_AiSelectText", new <>z__ReadOnlySingleElementList<object>(playerNameByType));
	}

	// Token: 0x06007253 RID: 29267 RVA: 0x001DDC0E File Offset: 0x001DBE0E
	public void HidePlayerButtons()
	{
		this.PlayGamePlayViewSequence("BtnHide", delegate
		{
			base.GetItem(29).SetUIActive(false);
		});
	}

	// Token: 0x06007254 RID: 29268 RVA: 0x001DDC28 File Offset: 0x001DBE28
	[return: Nullable(new byte[]
	{
		0,
		1
	})]
	private UniTask<GuessJokerCardItem> CreateCardItem(GuessJokerCardData cardData)
	{
		GuessJokerGamePlayView.<CreateCardItem>d__41 <CreateCardItem>d__;
		<CreateCardItem>d__.<>t__builder = AsyncUniTaskMethodBuilder<GuessJokerCardItem>.Create();
		<CreateCardItem>d__.<>4__this = this;
		<CreateCardItem>d__.cardData = cardData;
		<CreateCardItem>d__.<>1__state = -1;
		<CreateCardItem>d__.<>t__builder.Start<GuessJokerGamePlayView.<CreateCardItem>d__41>(ref <CreateCardItem>d__);
		return <CreateCardItem>d__.<>t__builder.Task;
	}

	// Token: 0x06007255 RID: 29269 RVA: 0x001DDC74 File Offset: 0x001DBE74
	protected override void OnBeforeDestroy()
	{
		foreach (GuessJokerCardItem guessJokerCardItem in this.CardItemMap.Values)
		{
			guessJokerCardItem.Destroy(null);
		}
		this.CardItemMap.Clear();
	}

	// Token: 0x06007256 RID: 29270 RVA: 0x001DDCD8 File Offset: 0x001DBED8
	[NullableContext(2)]
	public GuessJokerCardItem GetCardItemById(int cardId)
	{
		GuessJokerCardItem result;
		if (!this.CardItemMap.TryGetValue(cardId, out result))
		{
			return null;
		}
		return result;
	}

	// Token: 0x06007257 RID: 29271 RVA: 0x001DDCF8 File Offset: 0x001DBEF8
	public void SwapCardItemMap(int cardId1, int cardId2)
	{
		GuessJokerCardItem guessJokerCardItem2;
		GuessJokerCardItem guessJokerCardItem = this.CardItemMap.TryGetValue(cardId1, out guessJokerCardItem2) ? guessJokerCardItem2 : null;
		GuessJokerCardItem guessJokerCardItem4;
		GuessJokerCardItem guessJokerCardItem3 = this.CardItemMap.TryGetValue(cardId2, out guessJokerCardItem4) ? guessJokerCardItem4 : null;
		if (guessJokerCardItem != null && guessJokerCardItem3 != null)
		{
			this.CardItemMap[cardId1] = guessJokerCardItem3;
			this.CardItemMap[cardId2] = guessJokerCardItem;
		}
	}

	// Token: 0x06007258 RID: 29272 RVA: 0x001DDD50 File Offset: 0x001DBF50
	[NullableContext(2)]
	private LevelSequencePlayer GetOrCreateSequencePlayer(int componentDefine)
	{
		LevelSequencePlayer levelSequencePlayer;
		if (!this.SequencePlayerMap.TryGetValue(componentDefine, out levelSequencePlayer))
		{
			UUIItem item = base.GetItem(componentDefine);
			if (item == null)
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.GuessJokerCard;
				ELogAuthor author = ELogAuthor.LRC;
				DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(17, 1);
				defaultInterpolatedStringHandler.AppendLiteral("Item not found, $");
				defaultInterpolatedStringHandler.AppendFormatted<int>(componentDefine);
				instance.Error(module, author, defaultInterpolatedStringHandler.ToStringAndClear(), default(ReadOnlySpan<ValueTuple<string, object>>));
				return null;
			}
			levelSequencePlayer = new LevelSequencePlayer(item);
			this.SequencePlayerMap[componentDefine] = levelSequencePlayer;
		}
		return levelSequencePlayer;
	}

	// Token: 0x06007259 RID: 29273 RVA: 0x001DDDD0 File Offset: 0x001DBFD0
	public void SetPlayerPlayCardInteractiveCallback([Nullable(new byte[]
	{
		2,
		1
	})] Action<int[]> callback)
	{
		this.PlayerPlayCardInteractiveCallback = delegate(int[] playCardList)
		{
			this.HidePlayerButtons();
			Action<int[]> callback2 = callback;
			if (callback2 == null)
			{
				return;
			}
			callback2(playCardList);
		};
	}

	// Token: 0x0600725A RID: 29274 RVA: 0x001DDE03 File Offset: 0x001DC003
	[NullableContext(2)]
	public void SetPlayerCardClickCallback(Action<int, int, bool> callback)
	{
		this.PlayerCardClickCallback = callback;
	}

	// Token: 0x0600725B RID: 29275 RVA: 0x001DDE0C File Offset: 0x001DC00C
	public void SetFlipCoinClickEnable()
	{
		GuessJokerCoinFlipItem flipCoinItem = this.FlipCoinItem;
		if (flipCoinItem == null)
		{
			return;
		}
		flipCoinItem.SetClickEnable(true);
	}

	// Token: 0x0600725C RID: 29276 RVA: 0x001DDE1F File Offset: 0x001DC01F
	private void FlipCoinClickCallback()
	{
		GuessJokerCoinFlipItem flipCoinItem = this.FlipCoinItem;
		if (flipCoinItem != null)
		{
			flipCoinItem.SetClickEnable(false);
		}
		this.ShowFlipCoinEffect(false, delegate
		{
			this.ShowInitialRoundTip(true, delegate
			{
				ModelBase<GuessJokerGamePlayModel>.Instance.ChangeState(EGuessJokerCardStateType.RoundPlay);
			});
		});
	}

	// Token: 0x0600725D RID: 29277 RVA: 0x001DDE46 File Offset: 0x001DC046
	public void SetPlayerSkillRequestCallback(Action<bool> callback)
	{
		this.PlayerSkillRequestCallback = callback;
	}

	// Token: 0x0600725E RID: 29278 RVA: 0x001DDE50 File Offset: 0x001DC050
	public void UpdateRoundNumber()
	{
		int roundNumber = ModelBase<GuessJokerGamePlayModel>.Instance.RoundNumber;
		UUIText text = base.GetText(3);
		DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(0, 1);
		defaultInterpolatedStringHandler.AppendFormatted<int>((roundNumber == 0) ? 1 : roundNumber);
		text.SetText(defaultInterpolatedStringHandler.ToStringAndClear(), true);
	}

	// Token: 0x0600725F RID: 29279 RVA: 0x001DDE94 File Offset: 0x001DC094
	public void PlayGamePlayViewSequence(string sequenceName, [Nullable(2)] Action finishCallback = null)
	{
		LevelSequencePlayer gamePlayViewSequencePlayer = this.GamePlayViewSequencePlayer;
		if (gamePlayViewSequencePlayer != null)
		{
			gamePlayViewSequencePlayer.PlaySequencePurely(sequenceName, false, false, null, null, false);
		}
		if (finishCallback != null)
		{
			this.SequenceFinishCallbackMap[sequenceName] = finishCallback;
		}
	}

	// Token: 0x06007260 RID: 29280 RVA: 0x001DDED0 File Offset: 0x001DC0D0
	public void SetSkillProgress(EGuessJokerPlayerType playerType, float progress)
	{
		UUISprite uuisprite;
		if (playerType == EGuessJokerPlayerType.Ai)
		{
			UUISprite sprite = base.GetSprite(31);
			sprite.SetFillAmount(1f - progress);
			uuisprite = sprite;
		}
		else
		{
			base.GetSlider(14).SetValue(1f - progress, true);
			uuisprite = base.GetSprite(47);
		}
		if (uuisprite != null)
		{
			bool flag = 1f - progress > 0.3f;
			bool? lastSkillProgressAboveThreshold = this.LastSkillProgressAboveThreshold;
			bool flag2 = flag;
			if (!(lastSkillProgressAboveThreshold.GetValueOrDefault() == flag2 & lastSkillProgressAboveThreshold != null))
			{
				FColor color = flag ? FColor.FromHex("#98edf2") : FColor.FromHex("#ec435f");
				uuisprite.SetColor(color);
				this.LastSkillProgressAboveThreshold = new bool?(flag);
			}
		}
	}

	// Token: 0x06007261 RID: 29281 RVA: 0x001DDF77 File Offset: 0x001DC177
	public void ShowAiSkillProgress(bool isShow)
	{
		this.PlayStartOrCloseSequence(isShow, 30, null);
	}

	// Token: 0x06007262 RID: 29282 RVA: 0x001DDF84 File Offset: 0x001DC184
	[NullableContext(2)]
	public void ShowDialog(EGuessJokerPlayerType playerType, bool isShow, Action onComplete = null)
	{
		if (playerType != EGuessJokerPlayerType.Ai)
		{
			GuessJokerHeadItem mePlayerItem = this.MePlayerItem;
			if (mePlayerItem != null)
			{
				mePlayerItem.SetDialogueItemActive(isShow, onComplete);
			}
			return;
		}
		if (isShow)
		{
			base.GetItem(33).SetUIActive(true);
			this.PlayGamePlayViewSequence("DialogTipShow", onComplete);
			return;
		}
		this.PlayGamePlayViewSequence("DialogTipHide", delegate
		{
			this.GetItem(33).SetUIActive(false);
			Action onComplete2 = onComplete;
			if (onComplete2 == null)
			{
				return;
			}
			onComplete2();
		});
	}

	// Token: 0x06007263 RID: 29283 RVA: 0x001DDFFC File Offset: 0x001DC1FC
	public void SetDialogText(EGuessJokerPlayerType playerType, string textKey)
	{
		if (playerType == EGuessJokerPlayerType.Ai)
		{
			base.GetText(34).ShowTextNew(textKey);
			return;
		}
		GuessJokerHeadItem mePlayerItem = this.MePlayerItem;
		if (mePlayerItem != null)
		{
			mePlayerItem.SetDialogueText(textKey);
		}
	}

	// Token: 0x06007264 RID: 29284 RVA: 0x001DE030 File Offset: 0x001DC230
	public void ShowPlayerButtons(int normalCardPairCount)
	{
		base.GetButton(7).RootUIComp.Get().SetUIActive(false);
		base.GetButton(10).RootUIComp.Get().SetUIActive(false);
		base.GetText(36).ShowTextNew("GuessJoker_PlayCardConfirmText");
		base.GetItem(29).SetUIActive(true);
		this.PlayGamePlayViewSequence("BtnShow", null);
		if (normalCardPairCount > 0)
		{
			Singleton<EventSystem>.Instance.Emit<string>(EEventName.OnGuideTriggerEvent, "GuessJokerHasPair");
		}
	}

	// Token: 0x06007265 RID: 29285 RVA: 0x001DE0B8 File Offset: 0x001DC2B8
	public void ShowSkillInteractivePanel(bool isActive)
	{
		string sequenceName = isActive ? "SkillShow" : "SkillHide";
		if (isActive)
		{
			base.GetItem(11).SetUIActive(true);
			this.PlayGamePlayViewSequence(sequenceName, null);
			return;
		}
		this.PlayGamePlayViewSequence(sequenceName, delegate
		{
			base.GetItem(11).SetUIActive(false);
			this.PlayerSkillRequestCallback = null;
		});
	}

	// Token: 0x06007266 RID: 29286 RVA: 0x001DE102 File Offset: 0x001DC302
	public void UpdateCurrentPlayer(EGuessJokerPlayerType playerType)
	{
		this.AiPlayerItem.SetSelfRound(playerType == EGuessJokerPlayerType.Ai);
		this.MePlayerItem.SetSelfRound(playerType == EGuessJokerPlayerType.Me);
	}

	// Token: 0x06007267 RID: 29287 RVA: 0x001DE122 File Offset: 0x001DC322
	public void SetCurrentSkillInfo(int skillId, int skillRemindCount)
	{
		this.CurrentSkillRemindCount = skillRemindCount;
		Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(15), "GuessJoker_SkillChargesText", new <>z__ReadOnlySingleElementList<object>(this.CurrentSkillRemindCount));
	}

	// Token: 0x06007268 RID: 29288 RVA: 0x001DE154 File Offset: 0x001DC354
	public void ShowCards(int[] cardIdList, bool isShow)
	{
		foreach (int cardId in cardIdList)
		{
			GuessJokerCardItem cardItemById = this.GetCardItemById(cardId);
			if (cardItemById != null)
			{
				cardItemById.CardFlip(isShow, true);
			}
		}
	}

	// Token: 0x06007269 RID: 29289 RVA: 0x001DE188 File Offset: 0x001DC388
	public void BlankCardAnimPlay()
	{
		GuessJokerCardData blankCardData = ModelBase<GuessJokerGamePlayModel>.Instance.GetBlankCardData();
		if (blankCardData == null)
		{
			return;
		}
		if (!blankCardData.GetChange())
		{
			return;
		}
		this.BlankCardItem.RefreshCardChangeTexture();
		this.BlankCardItem.PlayCardSequence("Change", null);
		foreach (GuessJokerCardItem guessJokerCardItem in this.CardItemMap.Values)
		{
			if (guessJokerCardItem.Data.IsBlank())
			{
				guessJokerCardItem.RefreshCardChangeTexture();
				guessJokerCardItem.PlayCardSequence("Change", null);
			}
		}
	}

	// Token: 0x0600726A RID: 29290 RVA: 0x001DE22C File Offset: 0x001DC42C
	public void RemoveCardFromMiddleArea(Action finishCallback)
	{
		GuessJokerPositionPanelBase middlePanel = this.GetPositionPanel(ECardPositionType.Middle);
		foreach (int key in middlePanel.GetCardIdList())
		{
			this.CardItemMap.Remove(key);
		}
		middlePanel.ShowCardPairNotice(delegate
		{
			middlePanel.RemoveCards(finishCallback);
		});
	}

	// Token: 0x0600726B RID: 29291 RVA: 0x001DE2BC File Offset: 0x001DC4BC
	public void SetBlankCardDisable()
	{
		this.BlankCardItem.SetBlankCardDisable();
	}

	// Token: 0x0600726C RID: 29292 RVA: 0x001DE2CC File Offset: 0x001DC4CC
	public void DealCards(Action finishCallback)
	{
		List<GuessJokerCardData> allCardDataList = ModelBase<GuessJokerGamePlayModel>.Instance.GetAllCardDataList();
		List<GuessJokerCardItem> list = new List<GuessJokerCardItem>();
		List<GuessJokerCardItem> list2 = new List<GuessJokerCardItem>();
		foreach (GuessJokerCardData guessJokerCardData in allCardDataList)
		{
			GuessJokerCardItem item = this.CardItemMap[guessJokerCardData.Id];
			EGuessJokerPlayerType? belongPlayerType = guessJokerCardData.GetBelongPlayerType();
			if (belongPlayerType.GetValueOrDefault() == EGuessJokerPlayerType.Ai)
			{
				list.Add(item);
			}
			else
			{
				EGuessJokerPlayerType? eguessJokerPlayerType = belongPlayerType;
				EGuessJokerPlayerType eguessJokerPlayerType2 = EGuessJokerPlayerType.Me;
				if (eguessJokerPlayerType.GetValueOrDefault() == eguessJokerPlayerType2 & eguessJokerPlayerType != null)
				{
					list2.Add(item);
				}
			}
		}
		GuessJokerPositionPanelBase positionPanel = this.GetPositionPanel(ECardPositionType.AiInitial);
		GuessJokerPositionPanelBase positionPanel2 = this.GetPositionPanel(ECardPositionType.PlayerInitial);
		int completedCount = 0;
		Action finishCallback2 = delegate()
		{
			int completedCount = completedCount;
			completedCount++;
			if (completedCount == 2)
			{
				finishCallback();
			}
		};
		Singleton<AudioSystem>.Instance.PostEvent("play_ui_springfestival_ghostcard_card_deal");
		positionPanel.DealCards(list, finishCallback2, 150);
		positionPanel2.DealCards(list2, finishCallback2, 150);
	}

	// Token: 0x0600726D RID: 29293 RVA: 0x001DE3DC File Offset: 0x001DC5DC
	public void SetPositionPanelCardsDark(ECardPositionType position, bool isDark, int[] excludeCardIdList = null)
	{
		if (excludeCardIdList == null)
		{
			excludeCardIdList = Array.Empty<int>();
		}
		this.GetPositionPanel(position).SetCardsDarkExcept(isDark, excludeCardIdList.ToList<int>());
	}

	// Token: 0x0600726E RID: 29294 RVA: 0x001DE3FC File Offset: 0x001DC5FC
	[NullableContext(2)]
	private void PlayContinuousSequence(int componentDefine, Action completeCallback = null)
	{
		LevelSequencePlayer levelSequencePlayer = this.GetOrCreateSequencePlayer(componentDefine);
		if (levelSequencePlayer != null)
		{
			levelSequencePlayer.BindSequenceCloseEvent(delegate(string sequenceName)
			{
				if (sequenceName == "Start")
				{
					levelSequencePlayer.PlayLevelSequenceByName("Close", false, null, false);
					return;
				}
				if (sequenceName == "Close")
				{
					this.GetItem(componentDefine).SetUIActive(false);
					Action completeCallback3 = completeCallback;
					if (completeCallback3 == null)
					{
						return;
					}
					completeCallback3();
				}
			}, true);
			base.GetItem(componentDefine).SetUIActive(true);
			levelSequencePlayer.PlayLevelSequenceByName("Start", false, null, false);
			return;
		}
		Action completeCallback2 = completeCallback;
		if (completeCallback2 == null)
		{
			return;
		}
		completeCallback2();
	}

	// Token: 0x0600726F RID: 29295 RVA: 0x001DE494 File Offset: 0x001DC694
	[NullableContext(2)]
	private void PlayStartOrCloseSequence(bool isShow, int componentDefine, Action completeCallback = null)
	{
		LevelSequencePlayer orCreateSequencePlayer = this.GetOrCreateSequencePlayer(componentDefine);
		if (orCreateSequencePlayer == null)
		{
			Action completeCallback2 = completeCallback;
			if (completeCallback2 == null)
			{
				return;
			}
			completeCallback2();
			return;
		}
		else
		{
			orCreateSequencePlayer.BindSequenceCloseEvent(delegate(string sequenceName)
			{
				if (sequenceName == "Close")
				{
					this.GetItem(componentDefine).SetUIActive(false);
				}
				Action completeCallback3 = completeCallback;
				if (completeCallback3 == null)
				{
					return;
				}
				completeCallback3();
			}, true);
			if (isShow)
			{
				base.GetItem(componentDefine).SetUIActive(true);
				orCreateSequencePlayer.PlayLevelSequenceByName("Start", false, null, false);
				return;
			}
			orCreateSequencePlayer.PlayLevelSequenceByName("Close", false, null, false);
			return;
		}
	}

	// Token: 0x06007270 RID: 29296 RVA: 0x001DE532 File Offset: 0x001DC732
	public void PlaySkillEffect(int skillId, Action completeCallback)
	{
		GuessJokerSkillActivateItem skillActivateItem = this.SkillActivateItem;
		if (skillActivateItem != null)
		{
			skillActivateItem.Refresh(skillId);
		}
		this.PlayContinuousSequence(17, completeCallback);
	}

	// Token: 0x06007271 RID: 29297 RVA: 0x001DE54F File Offset: 0x001DC74F
	public void ShowFlipCoinEffect(bool isShow, Action completeCallback)
	{
		if (isShow)
		{
			GuessJokerCoinFlipItem flipCoinItem = this.FlipCoinItem;
			if (flipCoinItem != null)
			{
				flipCoinItem.Refresh();
			}
			this.PlayStartOrCloseSequence(true, 18, completeCallback);
			return;
		}
		this.PlayStartOrCloseSequence(false, 18, completeCallback);
	}

	// Token: 0x06007272 RID: 29298 RVA: 0x001DE57C File Offset: 0x001DC77C
	public void UpdateHp(EGuessJokerPlayerType playerType, Action completeCallback)
	{
		GuessJokerHeadItem guessJokerHeadItem = (playerType == EGuessJokerPlayerType.Ai) ? this.AiPlayerItem : this.MePlayerItem;
		if (guessJokerHeadItem != null)
		{
			guessJokerHeadItem.UpdateHp(completeCallback);
			return;
		}
		completeCallback();
	}

	// Token: 0x06007273 RID: 29299 RVA: 0x001DE5B0 File Offset: 0x001DC7B0
	public void UpdateSkill(EGuessJokerPlayerType playerType)
	{
		GuessJokerHeadItem guessJokerHeadItem = (playerType == EGuessJokerPlayerType.Ai) ? this.AiPlayerItem : this.MePlayerItem;
		if (guessJokerHeadItem != null)
		{
			guessJokerHeadItem.SetSkillUnlock(true);
		}
	}

	// Token: 0x06007274 RID: 29300 RVA: 0x001DE5DA File Offset: 0x001DC7DA
	private void UseSkill(bool isUse)
	{
		Action<bool> playerSkillRequestCallback = this.PlayerSkillRequestCallback;
		if (playerSkillRequestCallback == null)
		{
			return;
		}
		playerSkillRequestCallback(isUse);
	}

	// Token: 0x06007275 RID: 29301 RVA: 0x001DE5F0 File Offset: 0x001DC7F0
	public void SetCardChoose(int cardId, bool isSelected)
	{
		GuessJokerCardItem cardItemById = this.GetCardItemById(cardId);
		if (cardItemById == null)
		{
			return;
		}
		if (isSelected)
		{
			if (this.CurChooseCardItem != null && this.CurChooseCardItem != cardItemById)
			{
				this.CurChooseCardItem.SetChoose(false, true);
			}
			this.CurChooseCardItem = cardItemById;
		}
		else if (this.CurChooseCardItem == cardItemById)
		{
			this.CurChooseCardItem = null;
		}
		cardItemById.SetChoose(isSelected, true);
	}

	// Token: 0x06007276 RID: 29302 RVA: 0x001DE64B File Offset: 0x001DC84B
	public void ClearChooseCard()
	{
		if (this.CurChooseCardItem != null)
		{
			this.CurChooseCardItem.SetChoose(false, false);
			this.CurChooseCardItem = null;
		}
	}

	// Token: 0x06007277 RID: 29303 RVA: 0x001DE66C File Offset: 0x001DC86C
	public void SetCardsSelect(int cardId, Action finishCallback)
	{
		GuessJokerCardItem cardItemById = this.GetCardItemById(cardId);
		if (cardItemById != null)
		{
			cardItemById.SetSelectCardItem(finishCallback);
		}
	}

	// Token: 0x06007278 RID: 29304 RVA: 0x001DE68C File Offset: 0x001DC88C
	public void UpdateCardItemsHierarchyIndex()
	{
		List<GuessJokerCardItem> list = new List<GuessJokerCardItem>(this.CardItemMap.Values);
		list.Sort((GuessJokerCardItem a, GuessJokerCardItem b) => a.GetGlobalIndex() - b.GetGlobalIndex());
		for (int i = 0; i < list.Count; i++)
		{
			list[i].SetHierarchyIndex(i);
		}
	}

	// Token: 0x06007279 RID: 29305 RVA: 0x001DE6F0 File Offset: 0x001DC8F0
	public void ClearAllCardsChecking()
	{
		foreach (GuessJokerCardItem guessJokerCardItem in this.CardItemMap.Values)
		{
			guessJokerCardItem.ClearCheckingSign();
		}
	}

	// Token: 0x0600727A RID: 29306 RVA: 0x001DE748 File Offset: 0x001DC948
	public void ShowPlayerRoundStartTip(EGuessJokerPlayerType playerType, Action completeCallback)
	{
		int componentDefine = (playerType == EGuessJokerPlayerType.Ai) ? 21 : 22;
		this.PlayContinuousSequence(componentDefine, completeCallback);
	}

	// Token: 0x0600727B RID: 29307 RVA: 0x001DE768 File Offset: 0x001DC968
	public void ShowPlayerDrawCardTip(bool isShow, Action completeCallback)
	{
		int componentDefine = 25;
		this.PlayStartOrCloseSequence(isShow, componentDefine, completeCallback);
	}

	// Token: 0x0600727C RID: 29308 RVA: 0x001DE784 File Offset: 0x001DC984
	public void ShowInitialRoundTip(bool isShow, Action completeCallback)
	{
		int componentDefine = 26;
		this.PlayStartOrCloseSequence(isShow, componentDefine, completeCallback);
	}

	// Token: 0x0600727D RID: 29309 RVA: 0x001DE7A0 File Offset: 0x001DC9A0
	public void ShowDrawSpecialTip(bool isShow, bool isGood, EGuessJokerPlayerType playerType, Action completeCallback)
	{
		int componentDefine = isGood ? 24 : 23;
		int name = isGood ? 46 : 45;
		string text = isGood ? "GuessJoker_DrawBlankCardTipText" : "GuessJoker_DrawJokerTipText";
		string playerNameByType = ModelBase<GuessJokerGamePlayModel>.Instance.GetPlayerNameByType(playerType);
		Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(name), text.ToString(), new <>z__ReadOnlySingleElementList<object>(playerNameByType));
		this.PlayStartOrCloseSequence(isShow, componentDefine, completeCallback);
	}

	// Token: 0x0600727E RID: 29310 RVA: 0x001DE804 File Offset: 0x001DCA04
	public void ShowWinLoseReasonTip(EGuessJokerPlayerType playerType, string textKey, bool isGood, Action completeCallback)
	{
		int name = isGood ? 46 : 45;
		string playerNameByType = ModelBase<GuessJokerGamePlayModel>.Instance.GetPlayerNameByType(playerType);
		Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(name), textKey, new <>z__ReadOnlySingleElementList<object>(playerNameByType));
		base.GetText(name).ShowTextNew(textKey);
		int componentDefine = isGood ? 24 : 23;
		this.PlayContinuousSequence(componentDefine, completeCallback);
	}

	// Token: 0x0600727F RID: 29311 RVA: 0x001DE85F File Offset: 0x001DCA5F
	public void ShowOfficialRoundStartTip(Action completeCallback)
	{
		this.PlayContinuousSequence(27, completeCallback);
	}

	// Token: 0x06007280 RID: 29312 RVA: 0x001DE86C File Offset: 0x001DCA6C
	public void ShowAiSelectCardTip(bool isShow, Action completeCallback)
	{
		int componentDefine = 38;
		this.PlayStartOrCloseSequence(isShow, componentDefine, completeCallback);
	}

	// Token: 0x06007281 RID: 29313 RVA: 0x001DE888 File Offset: 0x001DCA88
	public GuessJokerPositionPanelBase GetPositionPanel(ECardPositionType position)
	{
		GuessJokerPositionPanelBase guessJokerPositionPanelBase;
		if (!this.PositionPanelMap.TryGetValue(position, out guessJokerPositionPanelBase))
		{
			guessJokerPositionPanelBase = new GuessJokerPositionPanelBase(position, this);
			this.PositionPanelMap[position] = guessJokerPositionPanelBase;
		}
		return guessJokerPositionPanelBase;
	}

	// Token: 0x06007282 RID: 29314 RVA: 0x001DE8BC File Offset: 0x001DCABC
	private void OnCardItemClick(GuessJokerCardItem cardItem)
	{
		GuessJokerCardData data = cardItem.Data;
		bool choose = cardItem.GetChoose();
		int id = data.Id;
		GuessJokerCardItem curChooseCardItem = this.CurChooseCardItem;
		int? num;
		if (curChooseCardItem == null)
		{
			num = null;
		}
		else
		{
			GuessJokerCardData data2 = curChooseCardItem.Data;
			num = ((data2 != null) ? new int?(data2.Id) : null);
		}
		int? num2 = num;
		int valueOrDefault = num2.GetValueOrDefault();
		Action<int, int, bool> playerCardClickCallback = this.PlayerCardClickCallback;
		if (playerCardClickCallback == null)
		{
			return;
		}
		playerCardClickCallback(id, valueOrDefault, choose);
	}

	// Token: 0x06007283 RID: 29315 RVA: 0x001DE92C File Offset: 0x001DCB2C
	private void OnCloseButtonClick()
	{
		ConfirmBoxDataNew confirmBoxDataNew = new ConfirmBoxDataNew(EConfirmBoxConfigId.GuessJokerExitConfirm);
		confirmBoxDataNew.IsEscViewTriggerCallBack = false;
		confirmBoxDataNew.FunctionMap[2] = delegate()
		{
			ModelBase<GuessJokerGamePlayModel>.Instance.GuessJokerExitSaveReport();
			ModelBase<GuessJokerGamePlayModel>.Instance.ExitGame();
			bool flag = false;
			int levelId = ModelBase<GuessJokerGamePlayModel>.Instance.GetLevelId();
			bool firstPass = ModelBase<SpringManorModel>.Instance.ActivityData.GetGuessJokerGameData(levelId).FirstPass;
			if (!ModelBase<GuessJokerGamePlayModel>.Instance.IsFinish && firstPass)
			{
				flag = true;
			}
			if (flag && levelId == 1010)
			{
				GuessJokerGamePlayModel instance = ModelBase<GuessJokerGamePlayModel>.Instance;
				if (instance == null)
				{
					return;
				}
				instance.HideAllGuessJokerNpc();
			}
		};
		ControllerBase<ConfirmBoxController>.Instance.ShowConfirmBoxNew(confirmBoxDataNew);
	}

	// Token: 0x06007284 RID: 29316 RVA: 0x001DE984 File Offset: 0x001DCB84
	private void OnPlayCardButtonClick()
	{
		List<IPlayCardInfo> playerPlayCardIdList = ModelBase<GuessJokerGamePlayModel>.Instance.GetPlayerPlayCardIdList();
		List<int> list = new List<int>();
		foreach (IPlayCardInfo playCardInfo in playerPlayCardIdList)
		{
			foreach (int item in playCardInfo.CardIdList)
			{
				list.Add(item);
			}
		}
		Singleton<Log>.Instance.Info(ELogModule.GuessJokerCard, ELogAuthor.LRC, "玩家出牌, $" + string.Join<int>(",", list), default(ReadOnlySpan<ValueTuple<string, object>>));
		Action<int[]> playerPlayCardInteractiveCallback = this.PlayerPlayCardInteractiveCallback;
		if (playerPlayCardInteractiveCallback == null)
		{
			return;
		}
		playerPlayCardInteractiveCallback(list.ToArray());
	}

	// Token: 0x06007285 RID: 29317 RVA: 0x001DEA40 File Offset: 0x001DCC40
	private void OnUseSkillButtonClick()
	{
		this.UseSkill(true);
	}

	// Token: 0x06007286 RID: 29318 RVA: 0x001DEA49 File Offset: 0x001DCC49
	private void OnGiveUpSkillButtonClick()
	{
		this.UseSkill(false);
	}

	// Token: 0x06007287 RID: 29319 RVA: 0x001DEA54 File Offset: 0x001DCC54
	private void OnHideToggleClick(EToggleState state)
	{
		bool uiactive = state != EToggleState.ETT_Checked;
		base.GetItem(37).SetUIActive(uiactive);
		base.GetItem(40).SetUIActive(uiactive);
		base.GetItem(41).SetUIActive(uiactive);
		base.GetButton(42).RootUIComp.Get().SetUIActive(uiactive);
		base.GetButton(43).RootUIComp.Get().SetUIActive(uiactive);
	}

	// Token: 0x06007288 RID: 29320 RVA: 0x001DEAC9 File Offset: 0x001DCCC9
	private void OnMaskButtonClick()
	{
		GuessJokerHeadItem aiPlayerItem = this.AiPlayerItem;
		if (aiPlayerItem == null)
		{
			return;
		}
		aiPlayerItem.ShowLockSkillTips(false);
	}

	// Token: 0x06007289 RID: 29321 RVA: 0x001DEADC File Offset: 0x001DCCDC
	[return: Nullable(new byte[]
	{
		2,
		1
	})]
	public override UUIItem[] GetGuideUiItemAndUiItemForShowEx(string[] configParams)
	{
		if (!(configParams[0] == "CardById"))
		{
			return null;
		}
		int cardId = int.Parse(configParams[1]);
		GuessJokerCardItem cardItemById = this.GetCardItemById(cardId);
		UUIItem uuiitem = (cardItemById != null) ? cardItemById.GetRootItem() : null;
		if (uuiitem == null)
		{
			return null;
		}
		return new UUIItem[]
		{
			uuiitem,
			uuiitem
		};
	}

	// Token: 0x04003724 RID: 14116
	private int NpcId;

	// Token: 0x04003725 RID: 14117
	[Nullable(2)]
	private PopupCaptionItem CaptionItem;

	// Token: 0x04003726 RID: 14118
	[Nullable(2)]
	private GuessJokerHeadItem AiPlayerItem;

	// Token: 0x04003727 RID: 14119
	[Nullable(2)]
	private GuessJokerHeadItem MePlayerItem;

	// Token: 0x04003728 RID: 14120
	[Nullable(2)]
	private GuessJokerCardItem BlankCardItem;

	// Token: 0x04003729 RID: 14121
	[Nullable(2)]
	private GuessJokerSkillItem UseSkillItem;

	// Token: 0x0400372A RID: 14122
	[Nullable(2)]
	private GuessJokerSkillItem GiveUpSkillItem;

	// Token: 0x0400372B RID: 14123
	[Nullable(2)]
	private GuessJokerSkillActivateItem SkillActivateItem;

	// Token: 0x0400372C RID: 14124
	[Nullable(2)]
	private GuessJokerCoinFlipItem FlipCoinItem;

	// Token: 0x0400372D RID: 14125
	private readonly Dictionary<ECardPositionType, GuessJokerPositionPanelBase> PositionPanelMap = new Dictionary<ECardPositionType, GuessJokerPositionPanelBase>();

	// Token: 0x0400372E RID: 14126
	private readonly Dictionary<int, GuessJokerCardItem> CardItemMap = new Dictionary<int, GuessJokerCardItem>();

	// Token: 0x0400372F RID: 14127
	[Nullable(2)]
	private GuessJokerCardItem CurChooseCardItem;

	// Token: 0x04003730 RID: 14128
	private bool? LastSkillProgressAboveThreshold;

	// Token: 0x04003731 RID: 14129
	[Nullable(new byte[]
	{
		2,
		1
	})]
	private Action<int[]> PlayerPlayCardInteractiveCallback;

	// Token: 0x04003732 RID: 14130
	[Nullable(2)]
	private Action<int, int, bool> PlayerCardClickCallback;

	// Token: 0x04003733 RID: 14131
	private int CurrentSkillRemindCount;

	// Token: 0x04003734 RID: 14132
	[Nullable(2)]
	private LevelSequencePlayer GamePlayViewSequencePlayer;

	// Token: 0x04003735 RID: 14133
	[Nullable(new byte[]
	{
		1,
		1,
		2
	})]
	private readonly Dictionary<string, Action> SequenceFinishCallbackMap = new Dictionary<string, Action>();

	// Token: 0x04003736 RID: 14134
	private readonly Dictionary<int, LevelSequencePlayer> SequencePlayerMap = new Dictionary<int, LevelSequencePlayer>();

	// Token: 0x04003737 RID: 14135
	[Nullable(2)]
	private GuessJokerDialogLogic DialogLogic;

	// Token: 0x04003738 RID: 14136
	[Nullable(2)]
	private Action<bool> PlayerSkillRequestCallback;

	// Token: 0x0200749B RID: 29851
	[NullableContext(0)]
	private static class EComponentDefine
	{
		// Token: 0x04028451 RID: 164945
		public const int CaptionItem = 0;

		// Token: 0x04028452 RID: 164946
		public const int AiPlayerItem = 1;

		// Token: 0x04028453 RID: 164947
		public const int MePlayerItem = 2;

		// Token: 0x04028454 RID: 164948
		public const int RoundText = 3;

		// Token: 0x04028455 RID: 164949
		public const int CardItem = 4;

		// Token: 0x04028456 RID: 164950
		public const int PlayerSelectArea = 5;

		// Token: 0x04028457 RID: 164951
		public const int AiSelectArea = 6;

		// Token: 0x04028458 RID: 164952
		public const int WithoutBlankButton = 7;

		// Token: 0x04028459 RID: 164953
		public const int PlayCardButton = 8;

		// Token: 0x0402845A RID: 164954
		public const int MiddleArea = 9;

		// Token: 0x0402845B RID: 164955
		public const int GiveUpButton = 10;

		// Token: 0x0402845C RID: 164956
		public const int SkillInteractivePanel = 11;

		// Token: 0x0402845D RID: 164957
		public const int UseSkillItem = 12;

		// Token: 0x0402845E RID: 164958
		public const int GiveUpSkillItem = 13;

		// Token: 0x0402845F RID: 164959
		public const int TimeSlider = 14;

		// Token: 0x04028460 RID: 164960
		public const int SkillLeftTimeText = 15;

		// Token: 0x04028461 RID: 164961
		public const int BarItem = 16;

		// Token: 0x04028462 RID: 164962
		public const int SkillActivateItem = 17;

		// Token: 0x04028463 RID: 164963
		public const int FlipCoinItem = 18;

		// Token: 0x04028464 RID: 164964
		public const int NumberBackPanel1 = 19;

		// Token: 0x04028465 RID: 164965
		public const int NumberBackPanel2 = 20;

		// Token: 0x04028466 RID: 164966
		public const int AiRoundStartTipItem = 21;

		// Token: 0x04028467 RID: 164967
		public const int PlayerRoundStartTipItem = 22;

		// Token: 0x04028468 RID: 164968
		public const int DrawJokerTipItem = 23;

		// Token: 0x04028469 RID: 164969
		public const int DrawBlankCardTipItem = 24;

		// Token: 0x0402846A RID: 164970
		public const int PlayerDrawCardTipItem = 25;

		// Token: 0x0402846B RID: 164971
		public const int InitialRoundTipItem = 26;

		// Token: 0x0402846C RID: 164972
		public const int OfficialRoundTipItem = 27;

		// Token: 0x0402846D RID: 164973
		public const int CheckItem = 28;

		// Token: 0x0402846E RID: 164974
		public const int PlayerButtonPanel = 29;

		// Token: 0x0402846F RID: 164975
		public const int AiProgressPanel = 30;

		// Token: 0x04028470 RID: 164976
		public const int AiProgressSprite = 31;

		// Token: 0x04028471 RID: 164977
		public const int BlankCardButton = 32;

		// Token: 0x04028472 RID: 164978
		public const int AiDialogItem = 33;

		// Token: 0x04028473 RID: 164979
		public const int AiDialogText = 34;

		// Token: 0x04028474 RID: 164980
		public const int HideToggle = 35;

		// Token: 0x04028475 RID: 164981
		public const int PlayButtonText = 36;

		// Token: 0x04028476 RID: 164982
		public const int HideItem = 37;

		// Token: 0x04028477 RID: 164983
		public const int AiSelectTipItem = 38;

		// Token: 0x04028478 RID: 164984
		public const int AiSelectText = 39;

		// Token: 0x04028479 RID: 164985
		public const int TipHideItem = 40;

		// Token: 0x0402847A RID: 164986
		public const int TitlePanel = 41;

		// Token: 0x0402847B RID: 164987
		public const int HelpButton = 42;

		// Token: 0x0402847C RID: 164988
		public const int CloseButton = 43;

		// Token: 0x0402847D RID: 164989
		public const int MaskButton = 44;

		// Token: 0x0402847E RID: 164990
		public const int BadTipText = 45;

		// Token: 0x0402847F RID: 164991
		public const int GoodTipText = 46;

		// Token: 0x04028480 RID: 164992
		public const int PlayerSkillProgressSprite = 47;
	}
}
