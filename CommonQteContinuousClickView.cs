using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using AkiClient.Game.Aki.Data.Qte;
using CSharpScript.Core.Common;
using CSharpScript.Game.InputSetting;
using CSharpScript.Game.Module.Qte.View;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x02002636 RID: 9782
[NullableContext(1)]
[Nullable(new byte[]
{
	0,
	1
})]
public class CommonQteContinuousClickView : CommonQteViewBase<CommonQteContinuousClickContext>
{
	// Token: 0x060133E5 RID: 78821 RVA: 0x005581DA File Offset: 0x005563DA
	public CommonQteContinuousClickView(UiViewInfo viewInfo) : base(viewInfo)
	{
	}

	// Token: 0x060133E6 RID: 78822 RVA: 0x005581FC File Offset: 0x005563FC
	protected unsafe override void OnRegisterComponent()
	{
		base.OnRegisterComponent();
		int num;
		Span<ValueTuple<int, Type>> span;
		int num2;
		if (this.IsMobile)
		{
			num = 7;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIButtonComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUISprite));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(5, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(6, typeof(UUIItem));
			this.ComponentRegisterInfos = list;
			return;
		}
		num2 = 8;
		List<ValueTuple<int, Type>> list2 = new List<ValueTuple<int, Type>>(num2);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list2, num2);
		span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list2);
		num = 0;
		*span[num] = new ValueTuple<int, Type>(0, typeof(UUIItem));
		num++;
		*span[num] = new ValueTuple<int, Type>(1, typeof(UUIButtonComponent));
		num++;
		*span[num] = new ValueTuple<int, Type>(2, typeof(UUISprite));
		num++;
		*span[num] = new ValueTuple<int, Type>(3, typeof(UUIItem));
		num++;
		*span[num] = new ValueTuple<int, Type>(4, typeof(UUIItem));
		num++;
		*span[num] = new ValueTuple<int, Type>(5, typeof(UUIText));
		num++;
		*span[num] = new ValueTuple<int, Type>(6, typeof(UUIItem));
		num++;
		*span[num] = new ValueTuple<int, Type>(7, typeof(UUIItem));
		this.ComponentRegisterInfos = list2;
	}

	// Token: 0x060133E7 RID: 78823 RVA: 0x00558440 File Offset: 0x00556640
	protected override UniTask OnBeforeStartAsync()
	{
		CommonQteContinuousClickView.<OnBeforeStartAsync>d__21 <OnBeforeStartAsync>d__;
		<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnBeforeStartAsync>d__.<>4__this = this;
		<OnBeforeStartAsync>d__.<>1__state = -1;
		<OnBeforeStartAsync>d__.<>t__builder.Start<CommonQteContinuousClickView.<OnBeforeStartAsync>d__21>(ref <OnBeforeStartAsync>d__);
		return <OnBeforeStartAsync>d__.<>t__builder.Task;
	}

	// Token: 0x060133E8 RID: 78824 RVA: 0x00558484 File Offset: 0x00556684
	protected override void OnStart()
	{
		base.OnStart();
		if (this.IsMobile)
		{
			this.AnimItem = base.GetItem(0);
			this.BtnClick = base.GetButton(1);
			this.IconItem = base.GetSprite(2);
			this.BorderItem = base.GetItem(3);
			this.TipItem = base.GetItem(4);
			this.TipText = base.GetText(5);
		}
		else
		{
			this.AnimItem = base.GetItem(0);
			this.BtnClick = base.GetButton(1);
			this.IconItem = base.GetSprite(2);
			this.BorderItem = base.GetItem(3);
			this.TipItem = base.GetItem(4);
			this.TipText = base.GetText(5);
		}
		UUIButtonComponent btnClick = this.BtnClick;
		if (btnClick != null)
		{
			btnClick.OnPointDownCallBack.Bind(new Action(this.OnBtnClickPress));
		}
		this.LevelSequencePlayer = new LevelSequencePlayer(this.AnimItem);
		this.LevelSequencePlayer.BindSequenceCloseEvent(new TSequenceEndEvent(this.OnSequenceEndEvent), false);
		this.LevelSequencePlayerBorder = new LevelSequencePlayer(this.BorderItem);
		UUIItem animItem = this.AnimItem;
		if (animItem == null)
		{
			return;
		}
		animItem.SetUIActive(false);
	}

	// Token: 0x060133E9 RID: 78825 RVA: 0x005585AA File Offset: 0x005567AA
	protected override void OnBeforeDestroy()
	{
		base.OnBeforeDestroy();
		UUIButtonComponent btnClick = this.BtnClick;
		if (btnClick != null)
		{
			btnClick.OnPointDownCallBack.Unbind();
		}
		LevelSequencePlayer levelSequencePlayer = this.LevelSequencePlayer;
		if (levelSequencePlayer != null)
		{
			levelSequencePlayer.Clear();
		}
		LevelSequencePlayer levelSequencePlayerBorder = this.LevelSequencePlayerBorder;
		if (levelSequencePlayerBorder == null)
		{
			return;
		}
		levelSequencePlayerBorder.Clear();
	}

	// Token: 0x060133EA RID: 78826 RVA: 0x005585E9 File Offset: 0x005567E9
	protected override void OnRefreshActionUi(string action)
	{
		if (!this.IsMobile)
		{
			InputMultiKeyItem inputKeyItem = this.InputKeyItem;
			if (inputKeyItem != null)
			{
				inputKeyItem.RefreshByActionOrAxis(new InputActionOrAxisKeyItem
				{
					ActionOrAxisName = action
				}, false);
			}
			InputMultiKeyItem inputKeyItem2 = this.InputKeyItem;
			if (inputKeyItem2 == null)
			{
				return;
			}
			inputKeyItem2.Show(null);
		}
	}

	// Token: 0x060133EB RID: 78827 RVA: 0x00558624 File Offset: 0x00556824
	[NullableContext(2)]
	protected override void TryApplyQteUiConfig(object uiConfig)
	{
		this.IsShowLoop = false;
		this.IsShowCharge = true;
		this.IsUseQuickStart = false;
		SCommonQte_ContinuousClick scommonQte_ContinuousClick = uiConfig as SCommonQte_ContinuousClick;
		if (scommonQte_ContinuousClick == null)
		{
			return;
		}
		this.IsUseQuickStart = (scommonQte_ContinuousClick.ViewType == ECommonQteViewType_SingleButtonContinuousClick.单按钮连击快启动界面);
		this.IsHideTextOnPress = scommonQte_ContinuousClick.IsShowTip;
		this.TipTextId = scommonQte_ContinuousClick.UIConfig.TextId;
		if (scommonQte_ContinuousClick.PerformInterpSpeedForEnergyPercent > 0f)
		{
			this.PerformInterpSpeedForChargeDuration = scommonQte_ContinuousClick.PerformInterpSpeedForEnergyPercent / 100f / (float)Singleton<TimeUtil>.Instance.InverseMillisecond;
		}
		else
		{
			this.PerformInterpSpeedForChargeDuration = -1f;
		}
		if (scommonQte_ContinuousClick.HideProgressBar)
		{
			UUIItem item = base.GetItem(6);
			if (item == null)
			{
				return;
			}
			item.SetUIActive(false);
		}
	}

	// Token: 0x060133EC RID: 78828 RVA: 0x005586DD File Offset: 0x005568DD
	protected override bool IsContextMatched(CommonQteContextBase context)
	{
		return context is CommonQteContinuousClickContext;
	}

	// Token: 0x060133ED RID: 78829 RVA: 0x005586E8 File Offset: 0x005568E8
	protected override void OnRefreshIcon(ULGUITexturePackerSpriteData sprite)
	{
		UUISprite iconItem = this.IconItem;
		if (iconItem != null)
		{
			iconItem.SetSprite(sprite, false);
		}
		UUISprite iconItem2 = this.IconItem;
		if (iconItem2 == null)
		{
			return;
		}
		iconItem2.SetUIActive(true);
	}

	// Token: 0x060133EE RID: 78830 RVA: 0x00558710 File Offset: 0x00556910
	protected override void OnPlayQteStart()
	{
		UUIItem animItem = this.AnimItem;
		if (animItem != null)
		{
			animItem.SetUIActive(true);
		}
		this.PlayLifeCycleSequence(this.IsUseQuickStart ? "StartHaste" : "Start");
		if (this.IsShowBorder)
		{
			UUIItem borderItem = this.BorderItem;
			if (borderItem != null)
			{
				borderItem.SetUIActive(true);
			}
			LevelSequencePlayer levelSequencePlayerBorder = this.LevelSequencePlayerBorder;
			if (levelSequencePlayerBorder != null)
			{
				levelSequencePlayerBorder.PlayLevelSequenceByName("Start", false, null, false);
			}
		}
		if (!string.IsNullOrEmpty(this.TipTextId))
		{
			Singleton<LguiUtil>.Instance.SetLocalTextNew(this.TipText, this.TipTextId, Array.Empty<object>());
			UUIItem tipItem = this.TipItem;
			if (tipItem == null)
			{
				return;
			}
			tipItem.SetUIActive(true);
			return;
		}
		else
		{
			UUIItem tipItem2 = this.TipItem;
			if (tipItem2 == null)
			{
				return;
			}
			tipItem2.SetUIActive(false);
			return;
		}
	}

	// Token: 0x060133EF RID: 78831 RVA: 0x005587D0 File Offset: 0x005569D0
	private void PlayLifeCycleSequence(string sequenceName)
	{
		LevelSequencePlayer levelSequencePlayer = this.LevelSequencePlayer;
		object obj;
		if (levelSequencePlayer == null)
		{
			obj = null;
		}
		else
		{
			USequencePlayContext sequencePlayContext = levelSequencePlayer.GetSequencePlayContext(sequenceName);
			obj = ((sequencePlayContext != null) ? sequencePlayContext.PlayInfo : null);
		}
		object obj2 = obj;
		FName? content = (obj2 != null) ? new FName?(obj2.LevelSequence.AssetPathName) : null;
		if (content == null || FNameUtil.IsNothing(content) || content.ToString().Length <= 0)
		{
			TimerSystem.Instance.Next(delegate(float _)
			{
				if (this.LevelSequencePlayer != null)
				{
					this.OnSequenceEndEvent(sequenceName);
				}
			}, null, null);
			return;
		}
		LevelSequencePlayer levelSequencePlayer2 = this.LevelSequencePlayer;
		if (levelSequencePlayer2 == null)
		{
			return;
		}
		levelSequencePlayer2.PlayLevelSequenceByName(sequenceName, false, null, false);
	}

	// Token: 0x060133F0 RID: 78832 RVA: 0x00558898 File Offset: 0x00556A98
	private void StopLifeCycleSequence(string sequenceName)
	{
		LevelSequencePlayer levelSequencePlayer = this.LevelSequencePlayer;
		object obj;
		if (levelSequencePlayer == null)
		{
			obj = null;
		}
		else
		{
			USequencePlayContext sequencePlayContext = levelSequencePlayer.GetSequencePlayContext(sequenceName);
			obj = ((sequencePlayContext != null) ? sequencePlayContext.PlayInfo : null);
		}
		object obj2 = obj;
		FName? content = (obj2 != null) ? new FName?(obj2.LevelSequence.AssetPathName) : null;
		if (content != null && !FNameUtil.IsNothing(content) && content.ToString().Length > 0)
		{
			LevelSequencePlayer levelSequencePlayer2 = this.LevelSequencePlayer;
			if (levelSequencePlayer2 == null)
			{
				return;
			}
			levelSequencePlayer2.StopSequenceByKey(sequenceName, false, false);
		}
	}

	// Token: 0x060133F1 RID: 78833 RVA: 0x0055891C File Offset: 0x00556B1C
	private void OnSequenceEndEvent(string sequenceName)
	{
		if (!(sequenceName == "Start") && !(sequenceName == "StartHaste"))
		{
			if (sequenceName == "Success" || sequenceName == "Fail")
			{
				Singleton<UiManager>.Instance.CloseView(EUiViewName.CommonQteContinuousClickView, null);
			}
			return;
		}
		if (this.IsQteEnd)
		{
			return;
		}
		if (this.IsShowLoop)
		{
			LevelSequencePlayer levelSequencePlayer = this.LevelSequencePlayer;
			if (levelSequencePlayer != null)
			{
				levelSequencePlayer.PlayLevelSequenceByName("Loop", false, null, false);
			}
			if (!this.IsQtePause && this.LoopDuration > 0f)
			{
				this.SetPlayRate("Loop", 1f / this.LoopDuration);
			}
			else
			{
				this.SetPlayRate("Loop", 0f);
			}
		}
		if (this.IsShowCharge)
		{
			LevelSequencePlayer levelSequencePlayer2 = this.LevelSequencePlayer;
			if (levelSequencePlayer2 != null)
			{
				levelSequencePlayer2.PlayLevelSequenceByName("Charge", false, null, false);
			}
			this.SetPlayOrPause("Charge", false);
			if (this.CommonQteContext != null)
			{
				this.TargetChargeDuration = this.CommonQteContext.CurrentEnergyPercent / 100f;
				this.CurrentChargeDuration = this.TargetChargeDuration;
				this.SetPlaybackProgress("Charge", this.CurrentChargeDuration);
			}
		}
		this.IsQteStart = true;
		this.IsQteInteractive = true;
		CommonQteContinuousClickContext commonQteContext = this.CommonQteContext;
		if (commonQteContext == null)
		{
			return;
		}
		commonQteContext.StartComboTiming();
	}

	// Token: 0x060133F2 RID: 78834 RVA: 0x00558A70 File Offset: 0x00556C70
	protected override void OnBindAction()
	{
		if (Singleton<Info>.Instance.IsInKeyBoard())
		{
			ActionMapping? actionMappingConfigByActionName = ConfigBase<InputSettingsConfig>.Instance.GetActionMappingConfigByActionName(this.QteAction);
			if (actionMappingConfigByActionName != null)
			{
				string[] actionPcKeys = LanguageKeyTransUtils.GetKeyTrans(Singleton<InputSettingsManager>.Instance.CurrentDeviceLang).GetActionPcKeys(actionMappingConfigByActionName.Value);
				if (actionPcKeys != null && actionPcKeys.Contains(EKey.LeftMouseButton.ToString()))
				{
					UUIButtonComponent btnClick = this.BtnClick;
					if (btnClick == null)
					{
						return;
					}
					btnClick.OnPointDownCallBack.Unbind();
				}
			}
		}
	}

	// Token: 0x060133F3 RID: 78835 RVA: 0x00558AEF File Offset: 0x00556CEF
	private void OnBtnClickPress()
	{
		base.OnInputCallback(this.QteAction, InputDistributeDefine.EActionType.Press, null);
	}

	// Token: 0x060133F4 RID: 78836 RVA: 0x00558B00 File Offset: 0x00556D00
	protected override void OnInputPress()
	{
		if (this.IsHideTextOnPress)
		{
			UUIItem tipItem = this.TipItem;
			if (tipItem != null)
			{
				tipItem.SetUIActive(false);
			}
		}
		CommonQteContinuousClickContext commonQteContext = this.CommonQteContext;
		if (commonQteContext != null && commonQteContext.IsResponsible())
		{
			if (this.IsShowCharge)
			{
				this.CurrentChargeDuration = this.TargetChargeDuration;
				this.SetPlaybackProgress("Charge", this.CurrentChargeDuration);
			}
			LevelSequencePlayer levelSequencePlayer = this.LevelSequencePlayer;
			if (levelSequencePlayer != null)
			{
				levelSequencePlayer.PlayLevelSequenceByName("Press", false, null, false);
			}
			this.CommonQteContext.Response();
		}
	}

	// Token: 0x060133F5 RID: 78837 RVA: 0x00558B8C File Offset: 0x00556D8C
	protected override void OnHandleQteEnd()
	{
		if (this.CommonQteContext != null && this.IsShowCharge)
		{
			this.TargetChargeDuration = this.CommonQteContext.CurrentEnergyPercent / 100f;
			this.CurrentChargeDuration = this.TargetChargeDuration;
			this.SetPlaybackProgress("Charge", this.CurrentChargeDuration);
		}
		LevelSequencePlayer levelSequencePlayer = this.LevelSequencePlayer;
		if (levelSequencePlayer != null)
		{
			levelSequencePlayer.StopCurrentSequence(false, false);
		}
		CommonQteContinuousClickContext commonQteContext = this.CommonQteContext;
		if (commonQteContext != null && commonQteContext.IsSuccess())
		{
			this.PlayLifeCycleSequence("Success");
		}
		else
		{
			this.PlayLifeCycleSequence("Fail");
		}
		if (!this.IsQteStart)
		{
			this.StopLifeCycleSequence(this.IsUseQuickStart ? "StartHaste" : "Start");
		}
		if (this.IsShowBorder)
		{
			LevelSequencePlayer levelSequencePlayerBorder = this.LevelSequencePlayerBorder;
			if (levelSequencePlayerBorder != null)
			{
				levelSequencePlayerBorder.StopCurrentSequence(false, false);
			}
			LevelSequencePlayer levelSequencePlayerBorder2 = this.LevelSequencePlayerBorder;
			if (levelSequencePlayerBorder2 == null)
			{
				return;
			}
			levelSequencePlayerBorder2.PlayLevelSequenceByName("Close", false, null, false);
		}
	}

	// Token: 0x060133F6 RID: 78838 RVA: 0x00558C79 File Offset: 0x00556E79
	private void SetPlayRate(string sequenceName, float playRate)
	{
		UUIItem animItem = this.AnimItem;
		AUIBaseActor auibaseActor = ((animItem != null) ? animItem.GetOwner() : null) as AUIBaseActor;
		if (auibaseActor == null)
		{
			return;
		}
		ALevelSequenceActor sequencePlayerByKey = auibaseActor.GetSequencePlayerByKey(sequenceName);
		if (sequencePlayerByKey == null)
		{
			return;
		}
		ULevelSequencePlayer sequencePlayer = sequencePlayerByKey.SequencePlayer;
		if (sequencePlayer == null)
		{
			return;
		}
		sequencePlayer.SetPlayRate(playRate);
	}

	// Token: 0x060133F7 RID: 78839 RVA: 0x00558CB4 File Offset: 0x00556EB4
	private void SetPlayOrPause(string sequenceName, bool bPlay)
	{
		UUIItem animItem = this.AnimItem;
		AUIBaseActor auibaseActor = ((animItem != null) ? animItem.GetOwner() : null) as AUIBaseActor;
		ULevelSequencePlayer ulevelSequencePlayer;
		if (auibaseActor == null)
		{
			ulevelSequencePlayer = null;
		}
		else
		{
			ALevelSequenceActor sequencePlayerByKey = auibaseActor.GetSequencePlayerByKey(sequenceName);
			ulevelSequencePlayer = ((sequencePlayerByKey != null) ? sequencePlayerByKey.SequencePlayer : null);
		}
		ULevelSequencePlayer ulevelSequencePlayer2 = ulevelSequencePlayer;
		if (bPlay)
		{
			if (ulevelSequencePlayer2 != null)
			{
				ulevelSequencePlayer2.Play();
				return;
			}
		}
		else if (ulevelSequencePlayer2 != null)
		{
			ulevelSequencePlayer2.Pause();
		}
	}

	// Token: 0x060133F8 RID: 78840 RVA: 0x00558D08 File Offset: 0x00556F08
	private void SetPlaybackProgress(string sequenceName, float progress)
	{
		UUIItem animItem = this.AnimItem;
		AUIBaseActor auibaseActor = ((animItem != null) ? animItem.GetOwner() : null) as AUIBaseActor;
		ULevelSequencePlayer ulevelSequencePlayer;
		if (auibaseActor == null)
		{
			ulevelSequencePlayer = null;
		}
		else
		{
			ALevelSequenceActor sequencePlayerByKey = auibaseActor.GetSequencePlayerByKey(sequenceName);
			ulevelSequencePlayer = ((sequencePlayerByKey != null) ? sequencePlayerByKey.SequencePlayer : null);
		}
		ULevelSequencePlayer ulevelSequencePlayer2 = ulevelSequencePlayer;
		if (ulevelSequencePlayer2 == null)
		{
			return;
		}
		FFrameTime time = ulevelSequencePlayer2.GetDuration().Time;
		float num = (float)time.FrameNumber.Value + time.SubFrame;
		float num2 = num * Singleton<MathUtils>.Instance.Clamp(progress, 0f, 1f);
		if (num < 1f || num2 > num)
		{
			return;
		}
		FFrameTime time2 = ulevelSequencePlayer2.GetStartTime().Time;
		FFrameTime time3 = ulevelSequencePlayer2.GetEndTime().Time;
		float num3 = (float)time2.FrameNumber.Value + time2.SubFrame;
		float max = (float)time3.FrameNumber.Value + time3.SubFrame;
		float num4 = Singleton<MathUtils>.Instance.Clamp(num3 + num2, num3, max);
		int num5 = (int)Math.Floor((double)num4);
		float subFrame = num4 - (float)num5;
		FMovieSceneSequencePlaybackParams playbackPosition = new FMovieSceneSequencePlaybackParams(new FFrameTime(new FFrameNumber(num5), subFrame), 0f, "", EMovieScenePositionType.Frame, EUpdatePositionMethod.Play);
		ulevelSequencePlayer2.SetPlaybackPosition(playbackPosition);
	}

	// Token: 0x060133F9 RID: 78841 RVA: 0x00558E22 File Offset: 0x00557022
	protected override void OnQtePause()
	{
		base.OnQtePause();
		if (this.IsShowLoop)
		{
			this.SetPlayRate("Loop", 0f);
		}
	}

	// Token: 0x060133FA RID: 78842 RVA: 0x00558E44 File Offset: 0x00557044
	protected override void OnQteResume()
	{
		base.OnQteResume();
		if (this.IsShowLoop)
		{
			if (this.LoopDuration > 0f)
			{
				this.SetPlayRate("Loop", 1f / this.LoopDuration);
				return;
			}
			this.SetPlayRate("Loop", 0f);
		}
	}

	// Token: 0x060133FB RID: 78843 RVA: 0x00558E94 File Offset: 0x00557094
	protected override void OnTick(float delta)
	{
		if (this.IsQteEnd || this.IsQtePause)
		{
			return;
		}
		if (!this.IsQteStart)
		{
			CommonQteContinuousClickContext commonQteContext = this.CommonQteContext;
			if (commonQteContext != null && commonQteContext.ProgressOnBegin)
			{
				this.CommonQteContext.UpdateTime(delta);
			}
			return;
		}
		if (this.CommonQteContext == null || this.CommonQteContext.IsInvalid())
		{
			base.HandleQteEnd();
			return;
		}
		this.CommonQteContext.UpdateTime(delta);
		if (this.IsShowCharge)
		{
			this.TargetChargeDuration = this.CommonQteContext.CurrentEnergyPercent / 100f;
			if (this.PerformInterpSpeedForChargeDuration > 0f)
			{
				this.CurrentChargeDuration = Singleton<MathUtils>.Instance.InterpConstantTo(this.CurrentChargeDuration, this.TargetChargeDuration, delta, this.PerformInterpSpeedForChargeDuration);
			}
			else
			{
				this.CurrentChargeDuration = this.TargetChargeDuration;
			}
			this.SetPlaybackProgress("Charge", this.CurrentChargeDuration);
		}
		CommonQteModel instance = ModelBase<CommonQteModel>.Instance;
		if (instance != null && instance.IsRefreshMode)
		{
			this.RefreshUiOffset();
		}
	}

	// Token: 0x060133FC RID: 78844 RVA: 0x00558F8C File Offset: 0x0055718C
	protected override void RefreshUiOffset()
	{
		if (this.CommonQteContext == null)
		{
			return;
		}
		SCommonQte_ContinuousClick scommonQte_ContinuousClick = this.CommonQteContext.GetUiConfig() as SCommonQte_ContinuousClick;
		if (scommonQte_ContinuousClick != null)
		{
			SCommonQteButton uiconfig = scommonQte_ContinuousClick.UIConfig;
			UUIItem animItem = this.AnimItem;
			if (animItem != null)
			{
				animItem.SetAnchorAlign(uiconfig.AnchorHAlign, uiconfig.AnchorVAlign);
			}
			UUIItem animItem2 = this.AnimItem;
			if (animItem2 == null)
			{
				return;
			}
			animItem2.SetAnchorOffset(uiconfig.AnchorOffset);
		}
	}

	// Token: 0x0400964E RID: 38478
	[Nullable(2)]
	private UUIItem AnimItem;

	// Token: 0x0400964F RID: 38479
	[Nullable(2)]
	private UUIButtonComponent BtnClick;

	// Token: 0x04009650 RID: 38480
	[Nullable(2)]
	private UUISprite IconItem;

	// Token: 0x04009651 RID: 38481
	[Nullable(2)]
	private UUIItem BorderItem;

	// Token: 0x04009652 RID: 38482
	[Nullable(2)]
	private UUIItem TipItem;

	// Token: 0x04009653 RID: 38483
	[Nullable(2)]
	private UUIText TipText;

	// Token: 0x04009654 RID: 38484
	[Nullable(2)]
	private InputMultiKeyItem InputKeyItem;

	// Token: 0x04009655 RID: 38485
	[Nullable(2)]
	private LevelSequencePlayer LevelSequencePlayer;

	// Token: 0x04009656 RID: 38486
	[Nullable(2)]
	private LevelSequencePlayer LevelSequencePlayerBorder;

	// Token: 0x04009657 RID: 38487
	private bool IsShowLoop;

	// Token: 0x04009658 RID: 38488
	private bool IsShowCharge;

	// Token: 0x04009659 RID: 38489
	private float CurrentChargeDuration;

	// Token: 0x0400965A RID: 38490
	private float TargetChargeDuration;

	// Token: 0x0400965B RID: 38491
	private float PerformInterpSpeedForChargeDuration = -1f;

	// Token: 0x0400965C RID: 38492
	private bool IsHideTextOnPress;

	// Token: 0x0400965D RID: 38493
	private string TipTextId = "";

	// Token: 0x0400965E RID: 38494
	private bool IsUseQuickStart;

	// Token: 0x020089D1 RID: 35281
	[NullableContext(0)]
	private enum EChildType
	{
		// Token: 0x0402E7E5 RID: 190437
		AnimItem,
		// Token: 0x0402E7E6 RID: 190438
		BtnClick,
		// Token: 0x0402E7E7 RID: 190439
		Icon,
		// Token: 0x0402E7E8 RID: 190440
		BorderItem,
		// Token: 0x0402E7E9 RID: 190441
		TipItem,
		// Token: 0x0402E7EA RID: 190442
		TipText,
		// Token: 0x0402E7EB RID: 190443
		ProgressBar
	}

	// Token: 0x020089D2 RID: 35282
	[NullableContext(0)]
	private enum EDesktopChildType
	{
		// Token: 0x0402E7ED RID: 190445
		AnimItem,
		// Token: 0x0402E7EE RID: 190446
		BtnClick,
		// Token: 0x0402E7EF RID: 190447
		Icon,
		// Token: 0x0402E7F0 RID: 190448
		BorderItem,
		// Token: 0x0402E7F1 RID: 190449
		TipItem,
		// Token: 0x0402E7F2 RID: 190450
		TipText,
		// Token: 0x0402E7F3 RID: 190451
		ProgressBar,
		// Token: 0x0402E7F4 RID: 190452
		KeyItem
	}
}
