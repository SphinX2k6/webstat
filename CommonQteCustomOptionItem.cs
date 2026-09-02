using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using AkiClient.Game.Aki.Data.Qte;
using CSharpScript.Core.Common;
using CSharpScript.Game.Module.SkillButtonUi;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x02002619 RID: 9753
[NullableContext(2)]
[Nullable(0)]
public class CommonQteCustomOptionItem : UiPanelBase
{
	// Token: 0x0601327A RID: 78458 RVA: 0x00550D96 File Offset: 0x0054EF96
	[NullableContext(1)]
	public void Init(int index, SCommonQteButton config, CommonQteCustomOptionPanel parent)
	{
		this.Index = index;
		this.UiConfig = config;
		this.ParentItem = parent;
	}

	// Token: 0x0601327B RID: 78459 RVA: 0x00550DB0 File Offset: 0x0054EFB0
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUIButtonComponent)),
			new ValueTuple<int, Type>(1, typeof(UUIText)),
			new ValueTuple<int, Type>(2, typeof(UUIItem)),
			new ValueTuple<int, Type>(3, typeof(UUISliderComponent))
		};
		if (!Singleton<Info>.Instance.IsInTouch())
		{
			this.ComponentRegisterInfos.Add(new ValueTuple<int, Type>(4, typeof(UUIItem)));
			this.ComponentRegisterInfos.Add(new ValueTuple<int, Type>(5, typeof(UUIItem)));
		}
	}

	// Token: 0x0601327C RID: 78460 RVA: 0x00550E64 File Offset: 0x0054F064
	protected override UniTask OnBeforeStartAsync()
	{
		CommonQteCustomOptionItem.<OnBeforeStartAsync>d__13 <OnBeforeStartAsync>d__;
		<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnBeforeStartAsync>d__.<>4__this = this;
		<OnBeforeStartAsync>d__.<>1__state = -1;
		<OnBeforeStartAsync>d__.<>t__builder.Start<CommonQteCustomOptionItem.<OnBeforeStartAsync>d__13>(ref <OnBeforeStartAsync>d__);
		return <OnBeforeStartAsync>d__.<>t__builder.Task;
	}

	// Token: 0x0601327D RID: 78461 RVA: 0x00550EA8 File Offset: 0x0054F0A8
	protected override void OnStart()
	{
		base.OnStart();
		this.BtnMain = base.GetButton(0);
		this.DurationBar = base.GetSlider(3);
		UUISliderComponent durationBar = this.DurationBar;
		if (durationBar != null)
		{
			durationBar.SetValue(1f, true);
		}
		UUISliderComponent durationBar2 = this.DurationBar;
		if (durationBar2 != null)
		{
			durationBar2.SetSelfInteractive(false);
		}
		UUIItem item = base.GetItem(2);
		if (item != null)
		{
			item.SetUIActive(false);
		}
		UUIText text = base.GetText(1);
		if (text != null)
		{
			text.SetUIActive(false);
		}
		UUIButtonComponent btnMain = this.BtnMain;
		if (btnMain != null)
		{
			btnMain.OnPointDownCallBack.Bind(new Action(this.OnPress));
		}
		if (this.KeyItem != null)
		{
			InputMultiKeyItem keyItem = this.KeyItem;
			if (keyItem != null)
			{
				keyItem.Hide(null);
			}
		}
		else
		{
			UUIItem item2 = base.GetItem(5);
			if (item2 != null)
			{
				item2.SetUIActive(false);
			}
		}
		UUIItem uiItem = Singleton<Info>.Instance.IsInTouch() ? this.RootItem : base.GetItem(4);
		this.LevelSequencePlayer = new LevelSequencePlayer(uiItem);
		this.LevelSequencePlayer.BindSequenceCloseEvent(new TSequenceEndEvent(this.OnSequenceEndEvent), false);
	}

	// Token: 0x0601327E RID: 78462 RVA: 0x00550FB8 File Offset: 0x0054F1B8
	protected override void OnBeforeDestroy()
	{
		base.OnBeforeDestroy();
		this.UnbindAction();
		UUIButtonComponent btnMain = this.BtnMain;
		if (btnMain != null)
		{
			btnMain.OnPointDownCallBack.Unbind();
		}
		LevelSequencePlayer levelSequencePlayer = this.LevelSequencePlayer;
		if (levelSequencePlayer != null)
		{
			levelSequencePlayer.Clear();
		}
		this.CommonQteContext = null;
		this.UiConfig = null;
		this.QteAction = "";
		this.ParentItem = null;
	}

	// Token: 0x0601327F RID: 78463 RVA: 0x00551018 File Offset: 0x0054F218
	[NullableContext(1)]
	public void SetQteContext(CommonQteContextBase context)
	{
		CommonQteSelectOptionContext commonQteSelectOptionContext = context as CommonQteSelectOptionContext;
		if (commonQteSelectOptionContext == null)
		{
			return;
		}
		this.CommonQteContext = commonQteSelectOptionContext;
		string action = context.GetAction(new int?(this.Index));
		if (!string.IsNullOrEmpty(action))
		{
			this.QteAction = action;
			if (!Singleton<Info>.Instance.IsInTouch())
			{
				InputActionOrAxisKeyItem actionOrAxisKeyItem = new InputActionOrAxisKeyItem
				{
					ActionOrAxisName = action
				};
				InputMultiKeyItem keyItem = this.KeyItem;
				if (keyItem != null)
				{
					keyItem.RefreshByActionOrAxis(actionOrAxisKeyItem, false);
				}
			}
		}
		SCommonQteButton uiConfig = this.UiConfig;
		string text = (uiConfig != null) ? uiConfig.TextId : null;
		UUIText text2 = base.GetText(1);
		if (!string.IsNullOrEmpty(text))
		{
			Singleton<LguiUtil>.Instance.SetLocalTextNew(text2, text, Array.Empty<object>());
			if (text2 != null)
			{
				text2.SetUIActive(true);
			}
		}
		UUIItem item = base.GetItem(2);
		if (item != null)
		{
			item.SetUIActive(!context.IsPermanent);
		}
		this.RefreshUiOffset();
	}

	// Token: 0x06013280 RID: 78464 RVA: 0x005510E8 File Offset: 0x0054F2E8
	public void PlayQteStart()
	{
		LevelSequencePlayer levelSequencePlayer = this.LevelSequencePlayer;
		if (levelSequencePlayer != null)
		{
			levelSequencePlayer.PlayLevelSequenceByName("Start", false, null, false);
		}
		this.OnSequenceEndEvent("Start");
		this.BindAction();
		base.SetUiActive(true);
	}

	// Token: 0x06013281 RID: 78465 RVA: 0x00551130 File Offset: 0x0054F330
	public void PlayQteEnd()
	{
		InputMultiKeyItem keyItem = this.KeyItem;
		if (keyItem != null)
		{
			keyItem.Hide(null);
		}
		LevelSequencePlayer levelSequencePlayer = this.LevelSequencePlayer;
		if (levelSequencePlayer != null)
		{
			levelSequencePlayer.StopCurrentSequence(false, false);
		}
		CommonQteSelectOptionContext commonQteContext = this.CommonQteContext;
		if (commonQteContext != null && commonQteContext.IsSuccess())
		{
			CommonQteSelectOptionContext commonQteContext2 = this.CommonQteContext;
			int? num = (commonQteContext2 != null) ? new int?(commonQteContext2.SelectOption) : null;
			int index = this.Index;
			if (num.GetValueOrDefault() == index & num != null)
			{
				LevelSequencePlayer levelSequencePlayer2 = this.LevelSequencePlayer;
				if (levelSequencePlayer2 == null)
				{
					goto IL_B8;
				}
				levelSequencePlayer2.PlayLevelSequenceByName("Press", false, null, false);
				goto IL_B8;
			}
		}
		LevelSequencePlayer levelSequencePlayer3 = this.LevelSequencePlayer;
		if (levelSequencePlayer3 != null)
		{
			levelSequencePlayer3.PlayLevelSequenceByName("Close", false, null, false);
		}
		IL_B8:
		this.UnbindAction();
	}

	// Token: 0x06013282 RID: 78466 RVA: 0x005511FC File Offset: 0x0054F3FC
	[NullableContext(1)]
	private void OnSequenceEndEvent(string sequenceName)
	{
		if (sequenceName == "Start")
		{
			LevelSequencePlayer levelSequencePlayer = this.LevelSequencePlayer;
			if (levelSequencePlayer != null)
			{
				levelSequencePlayer.PlayLevelSequenceByName("Loop", false, null, false);
			}
			if (!Singleton<Info>.Instance.IsInTouch())
			{
				InputMultiKeyItem keyItem = this.KeyItem;
				if (keyItem == null)
				{
					return;
				}
				keyItem.Show(null);
				return;
			}
		}
		else if (sequenceName == "Press" || sequenceName == "Close")
		{
			CommonQteCustomOptionPanel parentItem = this.ParentItem;
			if (parentItem == null)
			{
				return;
			}
			parentItem.OnOptionItemPlayEnded(this);
		}
	}

	// Token: 0x06013283 RID: 78467 RVA: 0x00551280 File Offset: 0x0054F480
	private void BindAction()
	{
		if (this.HasBindAction)
		{
			return;
		}
		this.HasBindAction = true;
		if (!Singleton<Info>.Instance.IsInTouch())
		{
			ControllerBase<InputDistributeController>.Instance.BindActionIgnoreLimit(this.QteAction, new TInputHandle<InputDistributeDefine.EActionType>(this.OnInputCallback));
			if (this.QteAction == "幻象1")
			{
				ControllerBase<InputDistributeController>.Instance.BindActionIgnoreLimit("通用交互", new TInputHandle<InputDistributeDefine.EActionType>(this.OnInputInteract));
			}
		}
	}

	// Token: 0x06013284 RID: 78468 RVA: 0x005512F4 File Offset: 0x0054F4F4
	private void UnbindAction()
	{
		if (!this.HasBindAction)
		{
			return;
		}
		this.HasBindAction = false;
		if (!Singleton<Info>.Instance.IsInTouch())
		{
			ControllerBase<InputDistributeController>.Instance.UnBindActionIgnoreLimit(this.QteAction, new TInputHandle<InputDistributeDefine.EActionType>(this.OnInputCallback));
			if (this.QteAction == "幻象1")
			{
				ControllerBase<InputDistributeController>.Instance.UnBindActionIgnoreLimit("通用交互", new TInputHandle<InputDistributeDefine.EActionType>(this.OnInputInteract));
			}
		}
	}

	// Token: 0x06013285 RID: 78469 RVA: 0x00551366 File Offset: 0x0054F566
	[NullableContext(1)]
	private void OnInputCallback(string actionName, InputDistributeDefine.EActionType actionType, InputIdentification inputIdentification)
	{
		CommonQteCustomOptionPanel parentItem = this.ParentItem;
		if (parentItem == null || !parentItem.IsValidInput())
		{
			return;
		}
		this.OnInput(actionType);
	}

	// Token: 0x06013286 RID: 78470 RVA: 0x00551388 File Offset: 0x0054F588
	[NullableContext(1)]
	private void OnInputInteract(string actionName, InputDistributeDefine.EActionType actionType, InputIdentification inputIdentification)
	{
		if (Singleton<Info>.Instance.IsInGamepad())
		{
			SkillButtonUiModel instance = ModelBase<SkillButtonUiModel>.Instance;
			bool flag;
			if (instance == null)
			{
				flag = false;
			}
			else
			{
				SkillButtonUiGamepadDataBase gamepadData = instance.GamepadData;
				flag = ((gamepadData != null) ? new bool?(gamepadData.SwitchInteractData.IsSwitchInteractOpen) : null).GetValueOrDefault();
			}
			if (flag)
			{
				SkillButtonUiModel instance2 = ModelBase<SkillButtonUiModel>.Instance;
				bool flag2;
				if (instance2 == null)
				{
					flag2 = false;
				}
				else
				{
					SkillButtonUiGamepadDataBase gamepadData2 = instance2.GamepadData;
					flag2 = (((gamepadData2 != null) ? new EGamepadSwitchInteractState?(gamepadData2.SwitchInteractData.State) : null).GetValueOrDefault() == EGamepadSwitchInteractState.Explore);
				}
				if (flag2 && this.QteAction == "幻象1")
				{
					this.OnInputCallback(actionName, actionType, inputIdentification);
					return;
				}
			}
		}
	}

	// Token: 0x06013287 RID: 78471 RVA: 0x00551435 File Offset: 0x0054F635
	public void OnPress()
	{
		CommonQteCustomOptionPanel parentItem = this.ParentItem;
		if (parentItem == null || !parentItem.IsValidInput())
		{
			return;
		}
		this.OnInput(InputDistributeDefine.EActionType.Press);
	}

	// Token: 0x06013288 RID: 78472 RVA: 0x00551458 File Offset: 0x0054F658
	private void OnInput(InputDistributeDefine.EActionType actionType)
	{
		if (this.CommonQteContext != null && this.CommonQteContext.IsActive() && this.CommonQteContext.IsPending() && actionType == InputDistributeDefine.EActionType.Press)
		{
			this.CommonQteContext.SelectOption = this.Index;
			this.CommonQteContext.Response();
		}
	}

	// Token: 0x06013289 RID: 78473 RVA: 0x005514A6 File Offset: 0x0054F6A6
	public void OnQtePause()
	{
		this.UnbindAction();
	}

	// Token: 0x0601328A RID: 78474 RVA: 0x005514AE File Offset: 0x0054F6AE
	public void OnQteResume()
	{
		this.BindAction();
	}

	// Token: 0x0601328B RID: 78475 RVA: 0x005514B6 File Offset: 0x0054F6B6
	public void SetProgress(Number progress)
	{
		UUISliderComponent durationBar = this.DurationBar;
		if (durationBar == null)
		{
			return;
		}
		durationBar.SetValue(progress, true);
	}

	// Token: 0x0601328C RID: 78476 RVA: 0x005514D0 File Offset: 0x0054F6D0
	public void RefreshUiOffset()
	{
		SCommonQteButton uiConfig = this.UiConfig;
		if (uiConfig != null)
		{
			UUIItem rootItem = this.RootItem;
			if (rootItem != null)
			{
				rootItem.SetAnchorAlign(uiConfig.AnchorHAlign, uiConfig.AnchorVAlign);
			}
			UUIItem rootItem2 = this.RootItem;
			if (rootItem2 == null)
			{
				return;
			}
			rootItem2.SetAnchorOffset(uiConfig.AnchorOffset);
		}
	}

	// Token: 0x0400957E RID: 38270
	private int Index = -1;

	// Token: 0x0400957F RID: 38271
	[Nullable(1)]
	private string QteAction = "";

	// Token: 0x04009580 RID: 38272
	private bool HasBindAction;

	// Token: 0x04009581 RID: 38273
	private CommonQteSelectOptionContext CommonQteContext;

	// Token: 0x04009582 RID: 38274
	private LevelSequencePlayer LevelSequencePlayer;

	// Token: 0x04009583 RID: 38275
	private SCommonQteButton UiConfig;

	// Token: 0x04009584 RID: 38276
	private CommonQteCustomOptionPanel ParentItem;

	// Token: 0x04009585 RID: 38277
	private UUIButtonComponent BtnMain;

	// Token: 0x04009586 RID: 38278
	private UUISliderComponent DurationBar;

	// Token: 0x04009587 RID: 38279
	private InputMultiKeyItem KeyItem;

	// Token: 0x020089B1 RID: 35249
	[NullableContext(0)]
	private enum EChildType
	{
		// Token: 0x0402E744 RID: 190276
		BtnMain,
		// Token: 0x0402E745 RID: 190277
		DescText,
		// Token: 0x0402E746 RID: 190278
		DurationPanel,
		// Token: 0x0402E747 RID: 190279
		DurationBar,
		// Token: 0x0402E748 RID: 190280
		AnimItem,
		// Token: 0x0402E749 RID: 190281
		KeyItem
	}
}
