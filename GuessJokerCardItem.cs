using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x02001129 RID: 4393
[NullableContext(2)]
[Nullable(0)]
public class GuessJokerCardItem : UiPanelBase
{
	// Token: 0x060072CF RID: 29391 RVA: 0x001DFF44 File Offset: 0x001DE144
	[NullableContext(1)]
	public GuessJokerCardItem(GuessJokerCardData cardData)
	{
		this.CardData = cardData;
	}

	// Token: 0x060072D0 RID: 29392 RVA: 0x001DFFE4 File Offset: 0x001DE1E4
	public GuessJokerCardItem()
	{
	}

	// Token: 0x17000952 RID: 2386
	// (get) Token: 0x060072D1 RID: 29393 RVA: 0x001E007C File Offset: 0x001DE27C
	public GuessJokerCardData Data
	{
		get
		{
			if (this.CardData == null)
			{
				Singleton<Log>.Instance.Error(ELogModule.GuessJokerCard, ELogAuthor.LRC, "CardData is undefined", default(ReadOnlySpan<ValueTuple<string, object>>));
				return null;
			}
			return this.CardData;
		}
	}

	// Token: 0x060072D2 RID: 29394 RVA: 0x001E00B8 File Offset: 0x001DE2B8
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUIExtendToggle)),
			new ValueTuple<int, Type>(1, typeof(UUITexture)),
			new ValueTuple<int, Type>(13, typeof(UUITexture)),
			new ValueTuple<int, Type>(2, typeof(UUIText)),
			new ValueTuple<int, Type>(3, typeof(UUIItem)),
			new ValueTuple<int, Type>(4, typeof(UUIItem)),
			new ValueTuple<int, Type>(5, typeof(UUIText)),
			new ValueTuple<int, Type>(6, typeof(UUIItem)),
			new ValueTuple<int, Type>(7, typeof(UUIItem)),
			new ValueTuple<int, Type>(8, typeof(UUISprite)),
			new ValueTuple<int, Type>(9, typeof(UUIText)),
			new ValueTuple<int, Type>(10, typeof(UUIItem)),
			new ValueTuple<int, Type>(11, typeof(UUIItem)),
			new ValueTuple<int, Type>(12, typeof(UUIItem)),
			new ValueTuple<int, Type>(14, typeof(UUITexture))
		};
		this.BtnBindInfo = new List<ValueTuple<int, Delegate>>
		{
			new ValueTuple<int, Delegate>(0, new Action<EToggleState>(this.OnToggle))
		};
	}

	// Token: 0x060072D3 RID: 29395 RVA: 0x001E0244 File Offset: 0x001DE444
	protected override UniTask OnBeforeStartAsync()
	{
		GuessJokerCardItem.<OnBeforeStartAsync>d__34 <OnBeforeStartAsync>d__;
		<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnBeforeStartAsync>d__.<>4__this = this;
		<OnBeforeStartAsync>d__.<>1__state = -1;
		<OnBeforeStartAsync>d__.<>t__builder.Start<GuessJokerCardItem.<OnBeforeStartAsync>d__34>(ref <OnBeforeStartAsync>d__);
		return <OnBeforeStartAsync>d__.<>t__builder.Task;
	}

	// Token: 0x060072D4 RID: 29396 RVA: 0x001E0288 File Offset: 0x001DE488
	protected override void OnStart()
	{
		this.Delegate = global::DelegateUtils.ToManualReleaseDelegate<FLTweenFloatSetterDynamic>(new Action<float>(this.UpdateMoveProgress));
		base.GetItem(10).SetUIActive(false);
		base.GetItem(11).SetUIActive(false);
		UUIExtendToggle extendToggle = base.GetExtendToggle(0);
		if (extendToggle == null)
		{
			return;
		}
		extendToggle.SetSelfInteractive(false);
	}

	// Token: 0x060072D5 RID: 29397 RVA: 0x001E02DC File Offset: 0x001DE4DC
	protected override void OnBeforeShow()
	{
		if (this.CardData == null)
		{
			return;
		}
		this.RefreshCardItem();
		this.CardFlip(this.CardData.GetBelongPlayerType().GetValueOrDefault() != EGuessJokerPlayerType.Ai, false);
	}

	// Token: 0x060072D6 RID: 29398 RVA: 0x001E0318 File Offset: 0x001DE518
	protected override void OnBeforeDestroy()
	{
		this.CardData = null;
		if (this.Delegate != null)
		{
			global::DelegateUtils.ReleaseManualReleaseDelegate(new Action<float>(this.UpdateMoveProgress));
			this.Delegate = null;
		}
		this.StopMove();
		this.XCurve = null;
		this.YCurve = null;
		this.ScaleCurve = null;
		base.GetItem(10).SetUIActive(false);
		base.GetItem(11).SetUIActive(false);
		LevelSequencePlayer sequencePlayer = this.SequencePlayer;
		if (sequencePlayer != null)
		{
			sequencePlayer.Clear();
		}
		this.SequencePlayer = null;
	}

	// Token: 0x060072D7 RID: 29399 RVA: 0x001E039B File Offset: 0x001DE59B
	[NullableContext(1)]
	private void OnEventSequence(string sequenceName, string eventName)
	{
		if (sequenceName == "Change" && eventName == "Change")
		{
			this.RefreshBlankCard();
		}
	}

	// Token: 0x060072D8 RID: 29400 RVA: 0x001E03C0 File Offset: 0x001DE5C0
	[NullableContext(1)]
	private void SequenceFinishEvent(string sequenceName)
	{
		Action action;
		if (this.SequenceFinishCallbackMap.TryGetValue(sequenceName, out action) && action != null)
		{
			action();
			this.SequenceFinishCallbackMap.Remove(sequenceName);
		}
	}

	// Token: 0x060072D9 RID: 29401 RVA: 0x001E03F8 File Offset: 0x001DE5F8
	public void RefreshCardItem()
	{
		if (this.CardData == null)
		{
			return;
		}
		int value = this.CardData.Value;
		if (this.CardData.IsBlank())
		{
			this.RefreshBlankCard();
		}
		else
		{
			if (this.CardData.IsJoker())
			{
				base.GetText(2).SetText("", true);
				base.GetText(5).SetText("", true);
			}
			else
			{
				UUIText text = base.GetText(2);
				DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(0, 1);
				defaultInterpolatedStringHandler.AppendFormatted<int>(value);
				text.SetText(defaultInterpolatedStringHandler.ToStringAndClear(), true);
				UUIText text2 = base.GetText(5);
				defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(0, 1);
				defaultInterpolatedStringHandler.AppendFormatted<int>(value);
				text2.SetText(defaultInterpolatedStringHandler.ToStringAndClear(), true);
			}
			base.SetTextureByPath(this.CardData.TexturePath, base.GetTexture(1), null, null);
		}
		base.GetItem(7).SetUIActive(this.CardData.IsBlank());
	}

	// Token: 0x060072DA RID: 29402 RVA: 0x001E04E8 File Offset: 0x001DE6E8
	private void RefreshBlankCard()
	{
		if (this.CardData == null)
		{
			return;
		}
		if (!this.CardData.IsBlank())
		{
			return;
		}
		int value = this.CardData.Value;
		if (this.CardData.HasChanged() && !this.CardData.IsChangedToJoker())
		{
			UUIText text = base.GetText(9);
			DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(0, 1);
			defaultInterpolatedStringHandler.AppendFormatted<int>(value);
			text.SetText(defaultInterpolatedStringHandler.ToStringAndClear(), true);
			UUIText text2 = base.GetText(5);
			defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(0, 1);
			defaultInterpolatedStringHandler.AppendFormatted<int>(value);
			text2.SetText(defaultInterpolatedStringHandler.ToStringAndClear(), true);
		}
		else
		{
			base.GetText(9).SetText("", true);
			base.GetText(5).SetText("", true);
		}
		base.GetText(2).SetText("", true);
		base.SetTextureByPath(this.CardData.TexturePath, base.GetTexture(1), null, null);
	}

	// Token: 0x060072DB RID: 29403 RVA: 0x001E05D8 File Offset: 0x001DE7D8
	public void RefreshCardChangeTexture()
	{
		if (this.CardData == null)
		{
			return;
		}
		if (!this.CardData.IsBlank())
		{
			return;
		}
		base.SetTextureByPath(this.CardData.TexturePath, base.GetTexture(13), null, null);
	}

	// Token: 0x060072DC RID: 29404 RVA: 0x001E0620 File Offset: 0x001DE820
	private void SetCardShow(bool isCardShow)
	{
		this.IsCardShow = isCardShow;
		base.GetItem(3).SetUIActive(!this.IsCardShow && !ModelBase<GuessJokerGamePlayModel>.Instance.IsShowAiCards);
		base.GetItem(4).SetUIActive(this.IsCardShow || ModelBase<GuessJokerGamePlayModel>.Instance.IsShowAiCards);
	}

	// Token: 0x060072DD RID: 29405 RVA: 0x001E0679 File Offset: 0x001DE879
	[NullableContext(1)]
	public void BindClickCallback(Action<GuessJokerCardItem> callback)
	{
		this.ClickCallback = callback;
	}

	// Token: 0x060072DE RID: 29406 RVA: 0x001E0682 File Offset: 0x001DE882
	protected void OnToggle(EToggleState state)
	{
		if (!this.IsClickEnable)
		{
			return;
		}
		Action<GuessJokerCardItem> clickCallback = this.ClickCallback;
		if (clickCallback == null)
		{
			return;
		}
		clickCallback(this);
	}

	// Token: 0x060072DF RID: 29407 RVA: 0x001E069E File Offset: 0x001DE89E
	public void ToggleStateChange(bool isSelect)
	{
		UUIExtendToggle extendToggle = base.GetExtendToggle(0);
		if (extendToggle != null)
		{
			extendToggle.SetToggleState(isSelect ? EToggleState.ETT_Checked : EToggleState.ETT_UnChecked, false, false, false);
		}
		UUIExtendToggle extendToggle2 = base.GetExtendToggle(0);
		if (extendToggle2 == null)
		{
			return;
		}
		extendToggle2.SetSelfInteractive(!isSelect);
	}

	// Token: 0x060072E0 RID: 29408 RVA: 0x001E06D2 File Offset: 0x001DE8D2
	public void SetToggleState(bool isSelect)
	{
		UUIExtendToggle extendToggle = base.GetExtendToggle(0);
		if (extendToggle == null)
		{
			return;
		}
		extendToggle.SetToggleState(isSelect ? EToggleState.ETT_Checked : EToggleState.ETT_UnChecked, false, false, false);
	}

	// Token: 0x060072E1 RID: 29409 RVA: 0x001E06F0 File Offset: 0x001DE8F0
	public void CardFlip(bool isCardShow, bool isNeedAim = true)
	{
		if (isNeedAim && isCardShow != this.IsCardShow)
		{
			string sequenceName = isCardShow ? "BackToFront" : "FrontToBack";
			this.PlayCardSequence(sequenceName, delegate
			{
				this.SetCardShow(isCardShow);
			});
			return;
		}
		this.SetCardShow(isCardShow);
	}

	// Token: 0x060072E2 RID: 29410 RVA: 0x001E0760 File Offset: 0x001DE960
	public void CardUp(bool isUp, Action onComplete = null)
	{
		ICardPositionConfig cardPositionConfig = GuessJokerDefine.GetCardPositionConfig(this.PositionType);
		FVector2D currentPosition = this.GetCurrentPosition();
		Vector2D targetPosition = new Vector2D((double)currentPosition.X, (double)currentPosition.Y + (double)(isUp ? cardPositionConfig.UpOffset : (-cardPositionConfig.UpOffset)).Value);
		if (isUp)
		{
			Singleton<AudioSystem>.Instance.PostEvent("play_ui_springfestival_ghostcard_card_friction");
		}
		int jokerParamConfig = GuessJokerUtils.GetJokerParamConfig(EGuessJokerParamKey.GuessJokerCardUpTime.ToString());
		this.SmoothMoveTo(targetPosition, onComplete, null, null, (float)jokerParamConfig);
	}

	// Token: 0x060072E3 RID: 29411 RVA: 0x001E081B File Offset: 0x001DEA1B
	public void SetDark(bool isDark)
	{
		if (isDark)
		{
			this.PlayCardSequence("CardDark", null);
			return;
		}
		this.PlayCardSequence("CardBright", null);
	}

	// Token: 0x060072E4 RID: 29412 RVA: 0x001E083C File Offset: 0x001DEA3C
	public void SetClickEnable(bool enable)
	{
		this.IsClickEnable = enable;
		UUIExtendToggle extendToggle = base.GetExtendToggle(0);
		if (extendToggle != null)
		{
			extendToggle.SetToggleState(enable ? (this.IsChoose ? EToggleState.ETT_Checked : EToggleState.ETT_UnChecked) : EToggleState.ETT_UnDetermined, false, false, false);
		}
		UUIExtendToggle extendToggle2 = base.GetExtendToggle(0);
		if (extendToggle2 == null)
		{
			return;
		}
		extendToggle2.SetSelfInteractive(enable);
	}

	// Token: 0x060072E5 RID: 29413 RVA: 0x001E088A File Offset: 0x001DEA8A
	public void SetChooseCardItem(bool isChoose)
	{
		if (isChoose)
		{
			this.PlayCardSequence("Sle", null);
			return;
		}
		this.PlayCardSequence("Unsle", null);
	}

	// Token: 0x060072E6 RID: 29414 RVA: 0x001E08A8 File Offset: 0x001DEAA8
	public void SetSelectCardItem(Action finishCallback = null)
	{
		this.PlayCardSequence("Press", finishCallback);
	}

	// Token: 0x060072E7 RID: 29415 RVA: 0x001E08B8 File Offset: 0x001DEAB8
	public void SetCheckCardItem(bool isCheck)
	{
		if (this.IsCardShow)
		{
			base.GetItem(12).SetUIActive(isCheck);
			return;
		}
		Singleton<Log>.Instance.Error(ELogModule.GuessJokerCard, ELogAuthor.LRC, "只有ai能使用SetCheckCardItem", default(ReadOnlySpan<ValueTuple<string, object>>));
	}

	// Token: 0x060072E8 RID: 29416 RVA: 0x001E08FC File Offset: 0x001DEAFC
	[NullableContext(1)]
	public void PlayCardSequence(string sequenceName, [Nullable(2)] Action finishCallback = null)
	{
		LevelSequencePlayer sequencePlayer = this.SequencePlayer;
		if (sequencePlayer != null)
		{
			sequencePlayer.PlaySequencePurely(sequenceName, false, false, null, null, false);
		}
		if (finishCallback != null)
		{
			this.SequenceFinishCallbackMap[sequenceName] = finishCallback;
		}
	}

	// Token: 0x060072E9 RID: 29417 RVA: 0x001E0938 File Offset: 0x001DEB38
	public void SetBlankCardDisable()
	{
		base.GetTexture(14).SetUIActive(true);
		this.SetAlpha(0.3f);
	}

	// Token: 0x060072EA RID: 29418 RVA: 0x001E0953 File Offset: 0x001DEB53
	[NullableContext(1)]
	public void UpdateCardData(GuessJokerCardData newCardData)
	{
		this.CardData = newCardData;
	}

	// Token: 0x060072EB RID: 29419 RVA: 0x001E095C File Offset: 0x001DEB5C
	[NullableContext(1)]
	public void SetUiParent(UUIItem parentItem)
	{
		Vector tempWorldPos = this.TempWorldPos;
		FVectorDouble fvectorDouble = this.RootItem.D_K2_GetComponentLocation();
		tempWorldPos.FromUeVector(fvectorDouble);
		Transform itemWorldTrans = this.ItemWorldTrans;
		FTransform ftransform = parentItem.K2_GetComponentToWorld();
		itemWorldTrans.FromUeTransform(ftransform);
		this.ItemWorldTrans.InverseTransformPosition(this.TempWorldPos, this.TempWorldPos);
		this.GetOriginalItem().SetUIParent(parentItem, false);
		this.ParentUiItem = parentItem;
		this.RootItem.SetUIRelativeLocation(this.TempWorldPos.ToUeVectorOld());
	}

	// Token: 0x060072EC RID: 29420 RVA: 0x001E09D7 File Offset: 0x001DEBD7
	[NullableContext(1)]
	public void SetPosition(Vector2D position)
	{
		if (this.RootItem != null)
		{
			this.RootItem.SetAnchorOffset(position.ToUeVector2D(false));
		}
	}

	// Token: 0x060072ED RID: 29421 RVA: 0x001E09F4 File Offset: 0x001DEBF4
	public void SetSize(float size)
	{
		if (this.RootItem != null)
		{
			UUIItem rootItem = this.RootItem;
			FVector fvector = new FVector(size, size, 1f);
			rootItem.SetUIRelativeScale3D(fvector);
			this.Size = size;
		}
	}

	// Token: 0x060072EE RID: 29422 RVA: 0x001E0A2C File Offset: 0x001DEC2C
	public void SetRotation(float angle)
	{
		if (this.RootItem != null)
		{
			FRotator frotator = new FRotator(0f, angle, 0f);
			this.RootItem.SetUIRelativeRotation(frotator);
			this.Rotation = angle;
		}
	}

	// Token: 0x060072EF RID: 29423 RVA: 0x001E0A67 File Offset: 0x001DEC67
	public void SetAlpha(float alpha)
	{
		if (this.RootItem != null)
		{
			this.RootItem.SetUIItemAlpha(alpha);
		}
	}

	// Token: 0x060072F0 RID: 29424 RVA: 0x001E0A80 File Offset: 0x001DEC80
	[NullableContext(1)]
	public void SmoothMoveTo(Vector2D targetPosition, [Nullable(2)] Action onComplete = null, float? targetSize = null, float? targetRotation = null, float duration = -1f)
	{
		if (duration < 0f)
		{
			duration = (float)GuessJokerUtils.GetJokerParamConfig(EGuessJokerParamKey.GuessJokerCardMoveTime.ToString());
		}
		if (this.IsMoving)
		{
			this.StopMove();
		}
		this.MoveCompleteCallback = onComplete;
		this.IsMoving = true;
		FVector2D currentPosition = this.GetCurrentPosition();
		FVector2D fvector2D = targetPosition.ToUeVector2D(false);
		float size = this.Size;
		float valueOrDefault = targetSize.GetValueOrDefault(size);
		float rotation = this.Rotation;
		float valueOrDefault2 = targetRotation.GetValueOrDefault(rotation);
		if (MathF.Abs(currentPosition.X - fvector2D.X) < 0.01f && MathF.Abs(currentPosition.Y - fvector2D.Y) < 0.01f && size == valueOrDefault && MathF.Abs(rotation - valueOrDefault2) < 0.01f)
		{
			this.OnMoveComplete();
			return;
		}
		this.StartPosition.X = currentPosition.X;
		this.StartPosition.Y = currentPosition.Y;
		this.TargetPosition.X = fvector2D.X;
		this.TargetPosition.Y = fvector2D.Y;
		this.StartSize = size;
		this.TargetSize = valueOrDefault;
		this.StartRotation = rotation;
		this.TargetRotation = valueOrDefault2;
		this.MoveTween = ULTweenBPLibrary.FloatTo(GlobalData.World, this.Delegate, 0f, 1f, duration / 1000f, 0f, LTweenEase.OutCubic);
		if (this.MoveTween != null)
		{
			this.MoveTween.OnCompleteCallBack.Bind(new Action(this.OnMoveComplete));
			return;
		}
		Singleton<Log>.Instance.Warn(ELogModule.GuessJokerCard, ELogAuthor.LRC, "SmoothMoveTo: MoveTween 创建失败，直接完成", default(ReadOnlySpan<ValueTuple<string, object>>));
		this.OnMoveComplete();
	}

	// Token: 0x060072F1 RID: 29425 RVA: 0x001E0C30 File Offset: 0x001DEE30
	public void StopMove()
	{
		if (this.MoveTween != null)
		{
			this.MoveTween.Kill(false);
			this.MoveTween.OnCompleteCallBack.Unbind();
			this.MoveTween = null;
		}
		this.IsMoving = false;
		Action moveCompleteCallback = this.MoveCompleteCallback;
		if (moveCompleteCallback != null)
		{
			moveCompleteCallback();
		}
		this.MoveCompleteCallback = null;
	}

	// Token: 0x060072F2 RID: 29426 RVA: 0x001E0C87 File Offset: 0x001DEE87
	public FVector2D GetCurrentPosition()
	{
		if (this.RootItem != null)
		{
			return this.RootItem.GetAnchorOffset();
		}
		return new FVector2D(0f, 0f);
	}

	// Token: 0x060072F3 RID: 29427 RVA: 0x001E0CAC File Offset: 0x001DEEAC
	private void UpdateMoveProgress(float progress)
	{
		if (this.RootItem != null)
		{
			float num = (this.XCurve != null) ? this.XCurve.GetFloatValue(progress) : progress;
			float num2 = (this.YCurve != null) ? this.YCurve.GetFloatValue(progress) : progress;
			float num3 = (this.ScaleCurve != null) ? this.ScaleCurve.GetFloatValue(progress) : progress;
			float inX = this.StartPosition.X + (this.TargetPosition.X - this.StartPosition.X) * num;
			float inY = this.StartPosition.Y + (this.TargetPosition.Y - this.StartPosition.Y) * num2;
			this.RootItem.SetAnchorOffset(new FVector2D(inX, inY));
			float num4 = this.StartSize + (this.TargetSize - this.StartSize) * num3;
			UUIItem rootItem = this.RootItem;
			FVector fvector = new FVector(num4, num4, 1f);
			rootItem.SetUIRelativeScale3D(fvector);
			this.Size = num4;
			float num5 = this.StartRotation + (this.TargetRotation - this.StartRotation) * progress;
			FRotator frotator = new FRotator(0f, num5, 0f);
			this.RootItem.SetUIRelativeRotation(frotator);
			this.Rotation = num5;
		}
	}

	// Token: 0x060072F4 RID: 29428 RVA: 0x001E0DE9 File Offset: 0x001DEFE9
	private void OnMoveComplete()
	{
		this.IsMoving = false;
		Action moveCompleteCallback = this.MoveCompleteCallback;
		if (moveCompleteCallback == null)
		{
			return;
		}
		moveCompleteCallback();
	}

	// Token: 0x060072F5 RID: 29429 RVA: 0x001E0E04 File Offset: 0x001DF004
	private UniTask InitXCurve()
	{
		GuessJokerCardItem.<InitXCurve>d__68 <InitXCurve>d__;
		<InitXCurve>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<InitXCurve>d__.<>4__this = this;
		<InitXCurve>d__.<>1__state = -1;
		<InitXCurve>d__.<>t__builder.Start<GuessJokerCardItem.<InitXCurve>d__68>(ref <InitXCurve>d__);
		return <InitXCurve>d__.<>t__builder.Task;
	}

	// Token: 0x060072F6 RID: 29430 RVA: 0x001E0E48 File Offset: 0x001DF048
	private UniTask InitYCurve()
	{
		GuessJokerCardItem.<InitYCurve>d__69 <InitYCurve>d__;
		<InitYCurve>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<InitYCurve>d__.<>4__this = this;
		<InitYCurve>d__.<>1__state = -1;
		<InitYCurve>d__.<>t__builder.Start<GuessJokerCardItem.<InitYCurve>d__69>(ref <InitYCurve>d__);
		return <InitYCurve>d__.<>t__builder.Task;
	}

	// Token: 0x060072F7 RID: 29431 RVA: 0x001E0E8C File Offset: 0x001DF08C
	private UniTask InitScaleCurve()
	{
		GuessJokerCardItem.<InitScaleCurve>d__70 <InitScaleCurve>d__;
		<InitScaleCurve>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<InitScaleCurve>d__.<>4__this = this;
		<InitScaleCurve>d__.<>1__state = -1;
		<InitScaleCurve>d__.<>t__builder.Start<GuessJokerCardItem.<InitScaleCurve>d__70>(ref <InitScaleCurve>d__);
		return <InitScaleCurve>d__.<>t__builder.Task;
	}

	// Token: 0x060072F8 RID: 29432 RVA: 0x001E0ECF File Offset: 0x001DF0CF
	public void SetChoose(bool isChoose, bool isPlayAnim)
	{
		if (this.IsChoose == isChoose)
		{
			return;
		}
		this.IsChoose = isChoose;
		if (isPlayAnim)
		{
			this.SetChooseCardItem(isChoose);
		}
		if (isChoose)
		{
			this.ToggleStateChange(true);
			return;
		}
		this.ToggleStateChange(false);
	}

	// Token: 0x060072F9 RID: 29433 RVA: 0x001E0EFE File Offset: 0x001DF0FE
	public bool GetChoose()
	{
		return this.IsChoose;
	}

	// Token: 0x060072FA RID: 29434 RVA: 0x001E0F06 File Offset: 0x001DF106
	public ECardPositionType GetPositionType()
	{
		return this.PositionType;
	}

	// Token: 0x060072FB RID: 29435 RVA: 0x001E0F0E File Offset: 0x001DF10E
	public void SetPositionType(ECardPositionType position)
	{
		this.PositionType = position;
	}

	// Token: 0x060072FC RID: 29436 RVA: 0x001E0F17 File Offset: 0x001DF117
	public void SetIndexInPanel(int index)
	{
		this.IndexInPanel = (int)(this.PositionType * (ECardPositionType)100 + index);
	}

	// Token: 0x060072FD RID: 29437 RVA: 0x001E0F2C File Offset: 0x001DF12C
	public void SetHierarchyIndex(int index)
	{
		UUIItem uuiitem = this.GetOriginalItem() ?? this.RootItem;
		if (uuiitem != null)
		{
			uuiitem.SetHierarchyIndex(index);
		}
	}

	// Token: 0x060072FE RID: 29438 RVA: 0x001E0F54 File Offset: 0x001DF154
	public int GetGlobalIndex()
	{
		return this.IndexInPanel;
	}

	// Token: 0x060072FF RID: 29439 RVA: 0x001E0F5C File Offset: 0x001DF15C
	public void SetChecking()
	{
		this.IsChecking = true;
	}

	// Token: 0x06007300 RID: 29440 RVA: 0x001E0F65 File Offset: 0x001DF165
	public void ClearCheckingSign()
	{
		if (this.IsChecking)
		{
			this.IsChecking = false;
			this.PlayCardSequence("EvilPressUnsle", null);
		}
	}

	// Token: 0x0400376A RID: 14186
	private GuessJokerCardData CardData;

	// Token: 0x0400376B RID: 14187
	private bool IsCardShow;

	// Token: 0x0400376C RID: 14188
	private bool IsChoose;

	// Token: 0x0400376D RID: 14189
	private bool IsClickEnable;

	// Token: 0x0400376E RID: 14190
	private bool IsChecking;

	// Token: 0x0400376F RID: 14191
	[Nullable(1)]
	private Action<GuessJokerCardItem> ClickCallback = delegate(GuessJokerCardItem _)
	{
	};

	// Token: 0x04003770 RID: 14192
	private int IndexInPanel;

	// Token: 0x04003771 RID: 14193
	private ECardPositionType PositionType = ECardPositionType.Middle;

	// Token: 0x04003772 RID: 14194
	private float Size = 1f;

	// Token: 0x04003773 RID: 14195
	private float Rotation;

	// Token: 0x04003774 RID: 14196
	[Nullable(1)]
	protected readonly Transform ItemWorldTrans = Transform.Create();

	// Token: 0x04003775 RID: 14197
	[Nullable(1)]
	protected readonly Vector TempWorldPos = Vector.Create();

	// Token: 0x04003776 RID: 14198
	private Action MoveCompleteCallback;

	// Token: 0x04003777 RID: 14199
	protected FLTweenFloatSetterDynamic Delegate;

	// Token: 0x04003778 RID: 14200
	private ULTweener MoveTween;

	// Token: 0x04003779 RID: 14201
	private bool IsMoving;

	// Token: 0x0400377A RID: 14202
	private UCurveFloat XCurve;

	// Token: 0x0400377B RID: 14203
	private UCurveFloat YCurve;

	// Token: 0x0400377C RID: 14204
	private UCurveFloat ScaleCurve;

	// Token: 0x0400377D RID: 14205
	private FVector2D StartPosition = new FVector2D();

	// Token: 0x0400377E RID: 14206
	private FVector2D TargetPosition = new FVector2D();

	// Token: 0x0400377F RID: 14207
	private float StartSize = 1f;

	// Token: 0x04003780 RID: 14208
	private float TargetSize = 1f;

	// Token: 0x04003781 RID: 14209
	private float StartRotation;

	// Token: 0x04003782 RID: 14210
	private float TargetRotation;

	// Token: 0x04003783 RID: 14211
	private GuessJokerCardBackItem BackItem;

	// Token: 0x04003784 RID: 14212
	private LevelSequencePlayer SequencePlayer;

	// Token: 0x04003785 RID: 14213
	[Nullable(new byte[]
	{
		1,
		1,
		2
	})]
	private readonly Dictionary<string, Action> SequenceFinishCallbackMap = new Dictionary<string, Action>();

	// Token: 0x020074AB RID: 29867
	[NullableContext(0)]
	private class EComponentDefine
	{
		// Token: 0x040284B1 RID: 165041
		public const int Toggle = 0;

		// Token: 0x040284B2 RID: 165042
		public const int Texture = 1;

		// Token: 0x040284B3 RID: 165043
		public const int NumberText = 2;

		// Token: 0x040284B4 RID: 165044
		public const int BackItem = 3;

		// Token: 0x040284B5 RID: 165045
		public const int FrontPanel = 4;

		// Token: 0x040284B6 RID: 165046
		public const int NumberText2 = 5;

		// Token: 0x040284B7 RID: 165047
		public const int GhostTipItem = 6;

		// Token: 0x040284B8 RID: 165048
		public const int BlankTipItem = 7;

		// Token: 0x040284B9 RID: 165049
		public const int BlankTipSprite = 8;

		// Token: 0x040284BA RID: 165050
		public const int BlankNumberText = 9;

		// Token: 0x040284BB RID: 165051
		public const int ChooseItem = 10;

		// Token: 0x040284BC RID: 165052
		public const int SelectItem = 11;

		// Token: 0x040284BD RID: 165053
		public const int CheckItem = 12;

		// Token: 0x040284BE RID: 165054
		public const int ChangeTexture = 13;

		// Token: 0x040284BF RID: 165055
		public const int DisableTexture = 14;
	}
}
