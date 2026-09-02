using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using CSharpScript.Game;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.BattleUi;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x02001E30 RID: 7728
public class GuideTipsView : GuideBaseView
{
	// Token: 0x0600E49F RID: 58527 RVA: 0x003DADF8 File Offset: 0x003D8FF8
	[NullableContext(1)]
	public GuideTipsView(UiViewInfo viewInfo) : base(viewInfo)
	{
	}

	// Token: 0x0600E4A0 RID: 58528 RVA: 0x003DAE08 File Offset: 0x003D9008
	protected unsafe override void OnRegisterComponent()
	{
		int num = 6;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int num2 = 0;
		*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(5, typeof(UUIItem));
		this.ComponentRegisterInfos = list;
	}

	// Token: 0x0600E4A1 RID: 58529 RVA: 0x003DAEF5 File Offset: 0x003D90F5
	protected override void OnGuideBaseViewAddEvent()
	{
		Singleton<EventSystem>.Instance.Add<bool>(EEventName.OnShowMouseCursor, new Action<bool>(this.OnShowMouseCursor));
	}

	// Token: 0x0600E4A2 RID: 58530 RVA: 0x003DAF13 File Offset: 0x003D9113
	protected override void OnGuideBaseViewRemoveEvent()
	{
		Singleton<EventSystem>.Instance.Remove(EEventName.OnShowMouseCursor, new Action<bool>(this.OnShowMouseCursor));
	}

	// Token: 0x0600E4A3 RID: 58531 RVA: 0x003DAF34 File Offset: 0x003D9134
	protected override void OnGuideBaseViewAfterHide()
	{
		base.UnbindInput(this.Config.Value.InputEnums(), this.Config.Value.InputEnums());
		if (this.UiViewSequence.HasSequenceNameInPlaying("Start"))
		{
			this.UiViewSequence.StopPrevSequence(true, true);
		}
	}

	// Token: 0x0600E4A4 RID: 58532 RVA: 0x003DAF8C File Offset: 0x003D918C
	protected override void OnBeforeGuideBaseViewCreate()
	{
		this.Config = new GuideTips?((GuideTips)this.GuideStepInfo.ViewData.ViewConf);
		List<string> list = new List<string>(this.Config.Value.InputEnumsIter());
		base.BindInput(list, list, new TInputHandle<float>(this.ProcessInput));
	}

	// Token: 0x0600E4A5 RID: 58533 RVA: 0x003DAFE8 File Offset: 0x003D91E8
	protected override void OnGuideBaseViewStart()
	{
		UUIText text = base.GetText(2);
		text.SetUIActive(false);
		text.SetUIActive(true);
		new GuideDescribeNew(text).SetUpText(this.Config.Value.Content, this.Config.Value.Button());
		GuidePrefabDefine.setPrefabText(text, text.GetText());
		UUIItem item = base.GetItem(4);
		float num = MathCommon.Clamp((float)this.Config.Value.UseMask / 100f, 0f, 1f);
		item.SetAlpha(num);
		item.SetRaycastTarget(num > 0f);
	}

	// Token: 0x0600E4A6 RID: 58534 RVA: 0x003DB08C File Offset: 0x003D928C
	protected override void OnGuideViewAfterShow()
	{
		UUIItem item = base.GetItem(3);
		if (base.TotalDuration > 0f)
		{
			this.CountDownItem = new GuideCountDownItem(base.TotalDuration);
			this.CountDownItem.Init(item);
		}
		else
		{
			item.SetUIActive(false);
		}
		base.BindInput(new List<string>(this.Config.Value.InputEnumsIter()), new List<string>(this.Config.Value.InputEnumsIter()), new TInputHandle<float>(this.ProcessInput));
	}

	// Token: 0x0600E4A7 RID: 58535 RVA: 0x003DB118 File Offset: 0x003D9318
	protected override UniTask OnBeforeHideAsync()
	{
		GuideTipsView.<OnBeforeHideAsync>d__13 <OnBeforeHideAsync>d__;
		<OnBeforeHideAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnBeforeHideAsync>d__.<>4__this = this;
		<OnBeforeHideAsync>d__.<>1__state = -1;
		<OnBeforeHideAsync>d__.<>t__builder.Start<GuideTipsView.<OnBeforeHideAsync>d__13>(ref <OnBeforeHideAsync>d__);
		return <OnBeforeHideAsync>d__.<>t__builder.Task;
	}

	// Token: 0x0600E4A8 RID: 58536 RVA: 0x003DB15C File Offset: 0x003D935C
	protected override void OnGuideBaseViewTick(float delta)
	{
		bool flag = this.IsAllowedViewShow() && ModelBase<BattleUiModel>.Instance.ChildViewData.GetChildVisible(EBattleUiChild.GuideTipsView) && !base.HasConflictView();
		if (!base.IsBusy && flag != this.IsBattleViewReady)
		{
			this.IsBattleViewReady = flag;
			this.SetActive(flag);
		}
	}

	// Token: 0x0600E4A9 RID: 58537 RVA: 0x003DB1B0 File Offset: 0x003D93B0
	protected override void OnAfterPlayStartSequence()
	{
		if (!this.Config.Value.UseLoopAnim)
		{
			this.UiViewSequence.StopSequenceByKey("AutoLoop1", false, false);
			return;
		}
		this.UiViewSequence.PlaySequence("AutoLoop1", false, null);
	}

	// Token: 0x0600E4AA RID: 58538 RVA: 0x003DB200 File Offset: 0x003D9400
	private void OnShowMouseCursor(bool isOn)
	{
		ControllerBase<InputDistributeController>.Instance.RefreshInputTag();
		if (!isOn || Singleton<UiManager>.Instance.IsViewShow(EUiViewName.GmView))
		{
			return;
		}
		if (this.IsAllowedViewShow() && this.GuideStepInfo.Config.TimeScale < 1f)
		{
			TsCharacterController characterController = Global.CharacterController;
			if (characterController == null)
			{
				return;
			}
			characterController.bShowMouseCursor = false;
			this.SetGameOnlyInputMode();
		}
	}

	// Token: 0x0600E4AB RID: 58539 RVA: 0x003DB268 File Offset: 0x003D9468
	private void SetGameOnlyInputMode()
	{
		TsCharacterController characterController = Global.CharacterController;
		if (this.InputModeReply == null && !UKuroInputFunctionLibrary.HasInputModeReply(this.InputModeReply))
		{
			this.InputModeReply = UKuroInputFunctionLibrary.SetGameOnlyInputMode(characterController, "GuideTipsView设置输入模式");
		}
	}

	// Token: 0x0600E4AC RID: 58540 RVA: 0x003DB2A7 File Offset: 0x003D94A7
	private void ReplyGameOnlyInputMode()
	{
		if (this.InputModeReply != null)
		{
			UKuroInputFunctionLibrary.ReplyInputMode(Global.CharacterController, this.InputModeReply);
			this.InputModeReply = null;
		}
	}

	// Token: 0x0600E4AD RID: 58541 RVA: 0x003DB2D0 File Offset: 0x003D94D0
	[NullableContext(1)]
	private void ProcessInput([Nullable(2)] string name, float value, InputIdentification _)
	{
		if (name != null)
		{
			this.CombineInputMap[name] = value;
			if (!base.IsAllCombineInputPass())
			{
				return;
			}
		}
		base.UnbindInput(this.Config.Value.InputEnums(), this.Config.Value.InputEnums());
		base.DoCloseByFinished();
	}

	// Token: 0x0600E4AE RID: 58542 RVA: 0x003DB328 File Offset: 0x003D9528
	protected override void OnDurationChange(float remainDuration)
	{
		if (this.CountDownItem != null)
		{
			this.CountDownItem.OnDurationChange(remainDuration);
		}
	}

	// Token: 0x0600E4AF RID: 58543 RVA: 0x003DB340 File Offset: 0x003D9540
	private bool IsAllowedViewShow()
	{
		foreach (EUiViewName name in GuideDefine.guideTipsAllowedViews)
		{
			if (Singleton<UiManager>.Instance.IsViewShow(name))
			{
				return true;
			}
		}
		return false;
	}

	// Token: 0x04006DF2 RID: 28146
	private GuideTips? Config;

	// Token: 0x04006DF3 RID: 28147
	[Nullable(2)]
	private GuideCountDownItem CountDownItem;

	// Token: 0x04006DF4 RID: 28148
	private bool IsBattleViewReady = true;

	// Token: 0x04006DF5 RID: 28149
	[Nullable(2)]
	private FInputModeReply InputModeReply;

	// Token: 0x0200819D RID: 33181
	private enum EGuideTipsView
	{
		// Token: 0x0402BFFC RID: 180220
		UiItemTips,
		// Token: 0x0402BFFD RID: 180221
		ToggleIcon,
		// Token: 0x0402BFFE RID: 180222
		GuideDescNew,
		// Token: 0x0402BFFF RID: 180223
		CountDownItem,
		// Token: 0x0402C000 RID: 180224
		UiItemBlackBg,
		// Token: 0x0402C001 RID: 180225
		IconParent
	}
}
