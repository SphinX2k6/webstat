using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using Aki.Protocol;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.ServerStorage;
using CSharpScript.Game.ServerStorage.Container;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x020025DF RID: 9695
[NullableContext(1)]
[Nullable(0)]
public class PhotographSetupView : UiViewBase
{
	// Token: 0x06012F48 RID: 77640 RVA: 0x0053DED8 File Offset: 0x0053C0D8
	public PhotographSetupView(UiViewInfo info) : base(info)
	{
	}

	// Token: 0x06012F49 RID: 77641 RVA: 0x0053DF34 File Offset: 0x0053C134
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUIExtendToggle)),
			new ValueTuple<int, Type>(1, typeof(UUIExtendToggle)),
			new ValueTuple<int, Type>(2, typeof(UUIExtendToggle)),
			new ValueTuple<int, Type>(9, typeof(UUIExtendToggle)),
			new ValueTuple<int, Type>(3, typeof(UUIItem)),
			new ValueTuple<int, Type>(4, typeof(UUIItem)),
			new ValueTuple<int, Type>(5, typeof(UUIItem)),
			new ValueTuple<int, Type>(6, typeof(UUIItem)),
			new ValueTuple<int, Type>(10, typeof(UUIItem)),
			new ValueTuple<int, Type>(7, typeof(UUIButtonComponent)),
			new ValueTuple<int, Type>(8, typeof(UUIItem)),
			new ValueTuple<int, Type>(11, typeof(UUIItem)),
			new ValueTuple<int, Type>(12, typeof(UUIScrollViewWithScrollbarComponent)),
			new ValueTuple<int, Type>(13, typeof(UUIItem)),
			new ValueTuple<int, Type>(14, typeof(UUIItem)),
			new ValueTuple<int, Type>(15, typeof(UUIItem)),
			new ValueTuple<int, Type>(16, typeof(UUIItem))
		};
		this.BtnBindInfo = new List<ValueTuple<int, Delegate>>
		{
			new ValueTuple<int, Delegate>(0, new Action<EToggleState>(this.OnClickedSetup)),
			new ValueTuple<int, Delegate>(1, new Action<EToggleState>(this.OnClickedExpression)),
			new ValueTuple<int, Delegate>(2, new Action<EToggleState>(this.OnClickedMotion)),
			new ValueTuple<int, Delegate>(9, new Action<EToggleState>(this.OnClickedFilter)),
			new ValueTuple<int, Delegate>(7, new Action(this.OnClickedCloseButton))
		};
	}

	// Token: 0x06012F4A RID: 77642 RVA: 0x0053E14E File Offset: 0x0053C34E
	private void OnClickedCloseButton()
	{
		base.CloseMe(null);
	}

	// Token: 0x06012F4B RID: 77643 RVA: 0x0053E157 File Offset: 0x0053C357
	private void OnClickedExpression(EToggleState toggleState)
	{
		this.RefreshTabState(EPhotoSettingMode.ExpressionSetup);
	}

	// Token: 0x06012F4C RID: 77644 RVA: 0x0053E160 File Offset: 0x0053C360
	private void OnClickedSetup(EToggleState toggleState)
	{
		this.RefreshTabState(EPhotoSettingMode.CameraSetup);
	}

	// Token: 0x06012F4D RID: 77645 RVA: 0x0053E169 File Offset: 0x0053C369
	private void OnClickedMotion(EToggleState toggleState)
	{
		this.RefreshTabState(EPhotoSettingMode.MotionSetup);
	}

	// Token: 0x06012F4E RID: 77646 RVA: 0x0053E174 File Offset: 0x0053C374
	private void OnClickedFilter(EToggleState toggleState)
	{
		ServerStorageBoolean serverStorageBoolean = ModelBase<ServerStorageModel>.Instance.Get(EClientStorageSystemIdType.FilterRedPoint) as ServerStorageBoolean;
		if (serverStorageBoolean.Get().GetValueOrDefault(true))
		{
			serverStorageBoolean.Set(new bool?(false));
			Singleton<EventSystem>.Instance.Emit(EEventName.RedDotFilter);
			PhotographTab photoFilterTab = this.PhotoFilterTab;
			if (photoFilterTab != null)
			{
				photoFilterTab.RefreshRedDot();
			}
		}
		this.RefreshTabState(EPhotoSettingMode.FilterSetup);
	}

	// Token: 0x06012F4F RID: 77647 RVA: 0x0053E1D8 File Offset: 0x0053C3D8
	protected override UniTask OnBeforeStartAsync()
	{
		PhotographSetupView.<OnBeforeStartAsync>d__23 <OnBeforeStartAsync>d__;
		<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnBeforeStartAsync>d__.<>4__this = this;
		<OnBeforeStartAsync>d__.<>1__state = -1;
		<OnBeforeStartAsync>d__.<>t__builder.Start<PhotographSetupView.<OnBeforeStartAsync>d__23>(ref <OnBeforeStartAsync>d__);
		return <OnBeforeStartAsync>d__.<>t__builder.Task;
	}

	// Token: 0x06012F50 RID: 77648 RVA: 0x0053E21C File Offset: 0x0053C41C
	protected override void OnStart()
	{
		this.AnimationController = (base.GetItem(3).GetOwner().GetComponentByClass(UUIInturnAnimController.StaticClass()) as UUIInturnAnimController);
		this.SelectTabToggle(this.PhotoSetupMode, true, true);
		this.SelectDefaultMotion();
		this.UiScrollView = base.GetScrollViewWithScrollbar(12);
		base.GetItem(16).SetUIActive(false);
	}

	// Token: 0x06012F51 RID: 77649 RVA: 0x0053E280 File Offset: 0x0053C480
	protected override void OnBeforeDestroy()
	{
		this.ClearMotionItem();
		this.ClearExpressionItem();
		this.ClearSetupItem();
		this.ClearFilterItem();
		this.TabItemMap.Clear();
		this.TabItemMap = null;
		this.PhotoFilterTab.Destroy(null);
		this.FilterToggleItem.Destroy(null);
	}

	// Token: 0x06012F52 RID: 77650 RVA: 0x0053E2D0 File Offset: 0x0053C4D0
	private void ScrollToSelectedItem(PhotoFilterItem item)
	{
		TTimerAction <>9__1;
		this.UiScrollView.OnLateUpdate.Bind(delegate(float deltaTime)
		{
			TimerSystemInstance gameplayTimeInstance = TimerSystem.GameplayTimeInstance;
			TTimerAction action;
			if ((action = <>9__1) == null)
			{
				action = (<>9__1 = delegate(float _)
				{
					FVector relativeLocation = this.UiScrollView.ContentUIItem.Get().RelativeLocation;
					FVector2D fvector2D = new FVector2D(ref relativeLocation);
					this.UiScrollView.StopMovement();
					this.UiScrollView.ScrollToBottom(ref fvector2D, item.GetRootItem(), false);
				});
			}
			gameplayTimeInstance.Next(action, null, null);
			UUIScrollViewWithScrollbarComponent uiScrollView = this.UiScrollView;
			if (uiScrollView != null && uiScrollView.IsValid())
			{
				this.UiScrollView.OnLateUpdate.Unbind();
			}
		});
	}

	// Token: 0x06012F53 RID: 77651 RVA: 0x0053E310 File Offset: 0x0053C510
	private void ScrollToSelectedItem(PhotographExpressionItem item)
	{
		TTimerAction <>9__1;
		this.UiScrollView.OnLateUpdate.Bind(delegate(float deltaTime)
		{
			TimerSystemInstance gameplayTimeInstance = TimerSystem.GameplayTimeInstance;
			TTimerAction action;
			if ((action = <>9__1) == null)
			{
				action = (<>9__1 = delegate(float _)
				{
					FVector relativeLocation = this.UiScrollView.ContentUIItem.Get().RelativeLocation;
					FVector2D fvector2D = new FVector2D(ref relativeLocation);
					this.UiScrollView.StopMovement();
					this.UiScrollView.ScrollToBottom(ref fvector2D, item.GetRootItem(), false);
				});
			}
			gameplayTimeInstance.Next(action, null, null);
			UUIScrollViewWithScrollbarComponent uiScrollView = this.UiScrollView;
			if (uiScrollView != null && uiScrollView.IsValid())
			{
				this.UiScrollView.OnLateUpdate.Unbind();
			}
		});
	}

	// Token: 0x06012F54 RID: 77652 RVA: 0x0053E34D File Offset: 0x0053C54D
	protected override void OnBeforeShow()
	{
		Singleton<EventSystem>.Instance.Emit<bool>(EEventName.OnPhotographSetUpViewVisibleChanged, true);
	}

	// Token: 0x06012F55 RID: 77653 RVA: 0x0053E360 File Offset: 0x0053C560
	protected override void OnAfterShow()
	{
		ControllerBase<RedDotController>.Instance.BindRedDot(ERedDotName.RedDotPhotoSetup, base.GetItem(15), null, 0);
	}

	// Token: 0x06012F56 RID: 77654 RVA: 0x0053E378 File Offset: 0x0053C578
	protected override void OnBeforeHide()
	{
		Singleton<EventSystem>.Instance.Emit<bool>(EEventName.OnPhotographSetUpViewVisibleChanged, false);
		ControllerBase<RedDotController>.Instance.UnBindGivenUi(ERedDotName.RedDotPhotoSetup, base.GetItem(15), 0);
	}

	// Token: 0x06012F57 RID: 77655 RVA: 0x0053E3A0 File Offset: 0x0053C5A0
	public void SetPanelVisible(bool isShow)
	{
		base.GetItem(11).SetUIActive(isShow);
		base.GetItem(16).SetUIActive(!isShow);
	}

	// Token: 0x06012F58 RID: 77656 RVA: 0x0053E3C4 File Offset: 0x0053C5C4
	private void InitTabToggle()
	{
		UUIExtendToggle extendToggle = base.GetExtendToggle(0);
		UUIExtendToggle extendToggle2 = base.GetExtendToggle(1);
		UUIExtendToggle extendToggle3 = base.GetExtendToggle(2);
		UUIExtendToggle extendToggle4 = base.GetExtendToggle(9);
		if (extendToggle2 != null)
		{
			extendToggle2.RootUIComp.Get().SetUIActive(false);
		}
		if (extendToggle3 != null)
		{
			extendToggle3.RootUIComp.Get().SetUIActive(false);
		}
		base.GetItem(10).SetUIActive(false);
		this.TabItemMap.Add(EPhotoSettingMode.CameraSetup, extendToggle);
		this.TabItemMap.Add(EPhotoSettingMode.ExpressionSetup, extendToggle2);
		this.TabItemMap.Add(EPhotoSettingMode.MotionSetup, extendToggle3);
		this.TabItemMap.Add(EPhotoSettingMode.FilterSetup, extendToggle4);
	}

	// Token: 0x06012F59 RID: 77657 RVA: 0x0053E464 File Offset: 0x0053C664
	private void RefreshTabState(EPhotoSettingMode newMode)
	{
		foreach (KeyValuePair<EPhotoSettingMode, UUIExtendToggle> keyValuePair in this.TabItemMap)
		{
			EPhotoSettingMode key = keyValuePair.Key;
			UUIExtendToggle value = keyValuePair.Value;
			if (key != newMode)
			{
				value.SetToggleStateForce(EToggleState.ETT_UnChecked, false, false, false);
			}
		}
		this.SetPhotoSetupMode(newMode);
	}

	// Token: 0x06012F5A RID: 77658 RVA: 0x0053E4D4 File Offset: 0x0053C6D4
	private void SelectTabToggle(EPhotoSettingMode newMode, bool selectOn, bool bFireEvent = false)
	{
		EToggleState state = selectOn ? EToggleState.ETT_Checked : EToggleState.ETT_UnChecked;
		UUIExtendToggle uuiextendToggle;
		if (this.TabItemMap.TryGetValue(newMode, out uuiextendToggle))
		{
			uuiextendToggle.SetToggleStateForce(state, bFireEvent, false, false);
		}
	}

	// Token: 0x06012F5B RID: 77659 RVA: 0x0053E503 File Offset: 0x0053C703
	private void SetPhotoSetupMode(EPhotoSettingMode newMode)
	{
		this.PhotoSetupMode = newMode;
		this.SetCameraSetupVisible(newMode == EPhotoSettingMode.CameraSetup);
		this.SetExpressionVisible(newMode == EPhotoSettingMode.ExpressionSetup);
		this.SetMotionVisible(newMode == EPhotoSettingMode.MotionSetup);
		this.SetFilterVisible(newMode == EPhotoSettingMode.FilterSetup);
	}

	// Token: 0x06012F5C RID: 77660 RVA: 0x0053E534 File Offset: 0x0053C734
	private UniTask InitializeExpressionSetup()
	{
		PhotographSetupView.<InitializeExpressionSetup>d__36 <InitializeExpressionSetup>d__;
		<InitializeExpressionSetup>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<InitializeExpressionSetup>d__.<>4__this = this;
		<InitializeExpressionSetup>d__.<>1__state = -1;
		<InitializeExpressionSetup>d__.<>t__builder.Start<PhotographSetupView.<InitializeExpressionSetup>d__36>(ref <InitializeExpressionSetup>d__);
		return <InitializeExpressionSetup>d__.<>t__builder.Task;
	}

	// Token: 0x06012F5D RID: 77661 RVA: 0x0053E578 File Offset: 0x0053C778
	private UniTask NewExpressionItem(int montageId)
	{
		PhotographSetupView.<NewExpressionItem>d__37 <NewExpressionItem>d__;
		<NewExpressionItem>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<NewExpressionItem>d__.<>4__this = this;
		<NewExpressionItem>d__.montageId = montageId;
		<NewExpressionItem>d__.<>1__state = -1;
		<NewExpressionItem>d__.<>t__builder.Start<PhotographSetupView.<NewExpressionItem>d__37>(ref <NewExpressionItem>d__);
		return <NewExpressionItem>d__.<>t__builder.Task;
	}

	// Token: 0x06012F5E RID: 77662 RVA: 0x0053E5C4 File Offset: 0x0053C7C4
	private void ClearExpressionItem()
	{
		foreach (PhotographExpressionItem photographExpressionItem in this.ExpressionItemSet)
		{
			photographExpressionItem.Destroy(null);
		}
		this.ExpressionItemSet.Clear();
		this.SelectedExpressionItem = null;
	}

	// Token: 0x06012F5F RID: 77663 RVA: 0x0053E628 File Offset: 0x0053C828
	private void SetExpressionVisible(bool bVisible)
	{
		foreach (PhotographExpressionItem photographExpressionItem in this.ExpressionItemSet)
		{
			photographExpressionItem.SetActive(bVisible);
		}
		UUIInturnAnimController animationController = this.AnimationController;
		if (animationController == null)
		{
			return;
		}
		animationController.Play("Start03", -1, false);
	}

	// Token: 0x06012F60 RID: 77664 RVA: 0x0053E690 File Offset: 0x0053C890
	private void OnSelectedExpressionItem(PhotographExpressionItem expressionItem, bool bSelectOn)
	{
		if (bSelectOn)
		{
			this.SelectOnExpressionItem(expressionItem);
			return;
		}
		this.DeselectOnExpressionItem(expressionItem);
	}

	// Token: 0x06012F61 RID: 77665 RVA: 0x0053E6A4 File Offset: 0x0053C8A4
	private void SelectOnExpressionItem(PhotographExpressionItem expressionItem)
	{
		if (this.SelectedExpressionItem != null)
		{
			this.SelectedExpressionItem.SetSelected(false, false);
		}
		int photoMontageId = expressionItem.GetPhotoMontageId();
		EntityHandle getCurrentEntity = ModelBase<SceneTeamModel>.Instance.GetCurrentEntity;
		ControllerBase<PhotographController>.Instance.PlayPhotoMontage(getCurrentEntity, photoMontageId);
		this.SelectedExpressionItem = expressionItem;
		this.SelectedExpressionItem.SetSelected(true, false);
		this.ScrollToSelectedItem(this.SelectedExpressionItem);
	}

	// Token: 0x06012F62 RID: 77666 RVA: 0x0053E704 File Offset: 0x0053C904
	private void DeselectOnExpressionItem(PhotographExpressionItem expressionItem)
	{
		if (this.SelectedExpressionItem != expressionItem)
		{
			return;
		}
		ControllerBase<PhotographController>.Instance.ResetPhotoMontage();
		this.SelectedExpressionItem = null;
	}

	// Token: 0x06012F63 RID: 77667 RVA: 0x0053E724 File Offset: 0x0053C924
	private void SelectDefaultMotion()
	{
		int montageId = ModelBase<PhotographModel>.Instance.MontageId;
		PhotographExpressionItem photographExpressionItem;
		if (!this.MotionItemMap.TryGetValue(montageId, out photographExpressionItem))
		{
			return;
		}
		if (this.SelectedMotionItem == photographExpressionItem)
		{
			return;
		}
		if (this.SelectedMotionItem != null)
		{
			this.SelectedMotionItem.SetSelected(false, false);
		}
		this.SelectedMotionItem = photographExpressionItem;
		PhotographExpressionItem selectedMotionItem = this.SelectedMotionItem;
		if (selectedMotionItem == null)
		{
			return;
		}
		selectedMotionItem.SetSelected(true, false);
	}

	// Token: 0x06012F64 RID: 77668 RVA: 0x0053E788 File Offset: 0x0053C988
	private UniTask InitializeMotionSetup()
	{
		PhotographSetupView.<InitializeMotionSetup>d__44 <InitializeMotionSetup>d__;
		<InitializeMotionSetup>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<InitializeMotionSetup>d__.<>4__this = this;
		<InitializeMotionSetup>d__.<>1__state = -1;
		<InitializeMotionSetup>d__.<>t__builder.Start<PhotographSetupView.<InitializeMotionSetup>d__44>(ref <InitializeMotionSetup>d__);
		return <InitializeMotionSetup>d__.<>t__builder.Task;
	}

	// Token: 0x06012F65 RID: 77669 RVA: 0x0053E7CC File Offset: 0x0053C9CC
	private UniTask CreateDefaultMotionItem()
	{
		PhotographSetupView.<CreateDefaultMotionItem>d__45 <CreateDefaultMotionItem>d__;
		<CreateDefaultMotionItem>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<CreateDefaultMotionItem>d__.<>4__this = this;
		<CreateDefaultMotionItem>d__.<>1__state = -1;
		<CreateDefaultMotionItem>d__.<>t__builder.Start<PhotographSetupView.<CreateDefaultMotionItem>d__45>(ref <CreateDefaultMotionItem>d__);
		return <CreateDefaultMotionItem>d__.<>t__builder.Task;
	}

	// Token: 0x06012F66 RID: 77670 RVA: 0x0053E810 File Offset: 0x0053CA10
	private UniTask NewMotionItem(int montageId)
	{
		PhotographSetupView.<NewMotionItem>d__46 <NewMotionItem>d__;
		<NewMotionItem>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<NewMotionItem>d__.<>4__this = this;
		<NewMotionItem>d__.montageId = montageId;
		<NewMotionItem>d__.<>1__state = -1;
		<NewMotionItem>d__.<>t__builder.Start<PhotographSetupView.<NewMotionItem>d__46>(ref <NewMotionItem>d__);
		return <NewMotionItem>d__.<>t__builder.Task;
	}

	// Token: 0x06012F67 RID: 77671 RVA: 0x0053E85C File Offset: 0x0053CA5C
	private void SetMotionVisible(bool bVisible)
	{
		foreach (PhotographExpressionItem photographExpressionItem in this.MotionItemMap.Values)
		{
			photographExpressionItem.SetActive(bVisible);
		}
	}

	// Token: 0x06012F68 RID: 77672 RVA: 0x0053E8B4 File Offset: 0x0053CAB4
	private void ClearMotionItem()
	{
		foreach (PhotographExpressionItem photographExpressionItem in this.MotionItemMap.Values)
		{
			photographExpressionItem.Destroy(null);
		}
		this.MotionItemMap.Clear();
		this.SelectedMotionItem = null;
	}

	// Token: 0x06012F69 RID: 77673 RVA: 0x0053E91C File Offset: 0x0053CB1C
	private bool OnCanExecuteChangeFunc(PhotographExpressionItem motionItem)
	{
		return this.SelectedMotionItem != motionItem;
	}

	// Token: 0x06012F6A RID: 77674 RVA: 0x0053E92A File Offset: 0x0053CB2A
	private void OnSelectedMotionItem(PhotographExpressionItem motionItem, bool bSelectOn)
	{
		if (bSelectOn)
		{
			this.SelectOnMotionItem(motionItem);
			return;
		}
		this.DeselectOnMotionItem(motionItem);
	}

	// Token: 0x06012F6B RID: 77675 RVA: 0x0053E940 File Offset: 0x0053CB40
	private void SelectOnMotionItem(PhotographExpressionItem motionItem)
	{
		if (this.SelectedMotionItem != null)
		{
			this.SelectedMotionItem.SetSelected(false, false);
		}
		int photoMontageId = motionItem.GetPhotoMontageId();
		if (photoMontageId == 0)
		{
			ControllerBase<PhotographController>.Instance.ResetPhotoMontage();
		}
		else
		{
			EntityHandle getCurrentEntity = ModelBase<SceneTeamModel>.Instance.GetCurrentEntity;
			ControllerBase<PhotographController>.Instance.PlayPhotoMontage(getCurrentEntity, photoMontageId);
		}
		this.SelectedMotionItem = motionItem;
		this.SelectedMotionItem.SetSelected(true, false);
		this.ScrollToSelectedItem(this.SelectedMotionItem);
	}

	// Token: 0x06012F6C RID: 77676 RVA: 0x0053E9AF File Offset: 0x0053CBAF
	private void DeselectOnMotionItem(PhotographExpressionItem motionItem)
	{
		if (this.SelectedMotionItem != motionItem)
		{
			return;
		}
		ControllerBase<PhotographController>.Instance.ResetPhotoMontage();
		this.SelectedMotionItem = null;
	}

	// Token: 0x06012F6D RID: 77677 RVA: 0x0053E9CC File Offset: 0x0053CBCC
	private UniTask InitializeCameraSetup()
	{
		PhotographSetupView.<InitializeCameraSetup>d__53 <InitializeCameraSetup>d__;
		<InitializeCameraSetup>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<InitializeCameraSetup>d__.<>4__this = this;
		<InitializeCameraSetup>d__.<>1__state = -1;
		<InitializeCameraSetup>d__.<>t__builder.Start<PhotographSetupView.<InitializeCameraSetup>d__53>(ref <InitializeCameraSetup>d__);
		return <InitializeCameraSetup>d__.<>t__builder.Task;
	}

	// Token: 0x06012F6E RID: 77678 RVA: 0x0053EA10 File Offset: 0x0053CC10
	private UniTask NewCameraSetupItem(EPhotoSetupValueType setupValueType, EPhotoSetupOptionType optionType)
	{
		PhotographSetupView.<NewCameraSetupItem>d__54 <NewCameraSetupItem>d__;
		<NewCameraSetupItem>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<NewCameraSetupItem>d__.<>4__this = this;
		<NewCameraSetupItem>d__.setupValueType = setupValueType;
		<NewCameraSetupItem>d__.optionType = optionType;
		<NewCameraSetupItem>d__.<>1__state = -1;
		<NewCameraSetupItem>d__.<>t__builder.Start<PhotographSetupView.<NewCameraSetupItem>d__54>(ref <NewCameraSetupItem>d__);
		return <NewCameraSetupItem>d__.<>t__builder.Task;
	}

	// Token: 0x06012F6F RID: 77679 RVA: 0x0053EA63 File Offset: 0x0053CC63
	private void OnSetupIndexChanged(int index)
	{
		this.RefreshAllOptionEnable();
		this.SelectDefaultMotion();
	}

	// Token: 0x06012F70 RID: 77680 RVA: 0x0053EA74 File Offset: 0x0053CC74
	[NullableContext(2)]
	private IPhotographSetupItem GetSetupItem(EPhotoSetupValueType valueType)
	{
		IPhotographSetupItem result;
		if (this.SetupItemMap.TryGetValue(valueType, out result))
		{
			return result;
		}
		return null;
	}

	// Token: 0x06012F71 RID: 77681 RVA: 0x0053EA94 File Offset: 0x0053CC94
	private void ClearSetupItem()
	{
		foreach (IPhotographSetupItem photographSetupItem in this.SetupItemMap.Values)
		{
			photographSetupItem.Destroy();
		}
		this.SetupItemMap.Clear();
	}

	// Token: 0x06012F72 RID: 77682 RVA: 0x0053EAF4 File Offset: 0x0053CCF4
	private void SetCameraSetupVisible(bool bVisible)
	{
		foreach (IPhotographSetupItem photographSetupItem in this.SetupItemMap.Values)
		{
			photographSetupItem.SetActive(bVisible);
		}
		if (bVisible)
		{
			this.RefreshAllOptionEnable();
		}
	}

	// Token: 0x06012F73 RID: 77683 RVA: 0x0053EB54 File Offset: 0x0053CD54
	private void RefreshAllOptionEnable()
	{
		foreach (IPhotographSetupItem photographSetupItem in this.SetupItemMap.Values)
		{
			photographSetupItem.SetEnable(true);
		}
		IEnumerable<KeyValuePair<EPhotoSetupValueType, float>> allPhotographOption = ModelBase<PhotographModel>.Instance.GetAllPhotographOption();
		PhotographConfig instance = ConfigBase<PhotographConfig>.Instance;
		foreach (KeyValuePair<EPhotoSetupValueType, float> keyValuePair in allPhotographOption)
		{
			EPhotoSetupValueType key = keyValuePair.Key;
			float value = keyValuePair.Value;
			PhotoSetup? photoSetupConfig = instance.GetPhotoSetupConfig(key);
			if (photoSetupConfig != null && photoSetupConfig.Value.Type == 0)
			{
				IntArray? subOptions = photoSetupConfig.Value.GetSubOptions((int)value);
				if (subOptions != null)
				{
					int arrayIntLength = subOptions.Value.ArrayIntLength;
					for (int i = 0; i < arrayIntLength; i++)
					{
						EPhotoSetupValueType valueType = (EPhotoSetupValueType)subOptions.Value.ArrayInt(i);
						IPhotographSetupItem setupItem = this.GetSetupItem(valueType);
						if (setupItem != null)
						{
							setupItem.SetEnable(false);
						}
					}
				}
			}
		}
	}

	// Token: 0x06012F74 RID: 77684 RVA: 0x0053EC94 File Offset: 0x0053CE94
	private UniTask InitializeFilterSetup()
	{
		PhotographSetupView.<InitializeFilterSetup>d__60 <InitializeFilterSetup>d__;
		<InitializeFilterSetup>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<InitializeFilterSetup>d__.<>4__this = this;
		<InitializeFilterSetup>d__.<>1__state = -1;
		<InitializeFilterSetup>d__.<>t__builder.Start<PhotographSetupView.<InitializeFilterSetup>d__60>(ref <InitializeFilterSetup>d__);
		return <InitializeFilterSetup>d__.<>t__builder.Task;
	}

	// Token: 0x06012F75 RID: 77685 RVA: 0x0053ECD8 File Offset: 0x0053CED8
	private UniTask NewFilterItem(int filterId)
	{
		PhotographSetupView.<NewFilterItem>d__61 <NewFilterItem>d__;
		<NewFilterItem>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<NewFilterItem>d__.<>4__this = this;
		<NewFilterItem>d__.filterId = filterId;
		<NewFilterItem>d__.<>1__state = -1;
		<NewFilterItem>d__.<>t__builder.Start<PhotographSetupView.<NewFilterItem>d__61>(ref <NewFilterItem>d__);
		return <NewFilterItem>d__.<>t__builder.Task;
	}

	// Token: 0x06012F76 RID: 77686 RVA: 0x0053ED24 File Offset: 0x0053CF24
	private void ClearFilterItem()
	{
		foreach (PhotoFilterItem photoFilterItem in this.FilterItemMap.Values)
		{
			photoFilterItem.Destroy(null);
		}
		this.FilterItemMap.Clear();
		this.SelectedFilterItem = null;
	}

	// Token: 0x06012F77 RID: 77687 RVA: 0x0053ED8C File Offset: 0x0053CF8C
	private void SetFilterVisible(bool bVisible)
	{
		this.FilterToggleItem.SetActive(bVisible);
		if (!bVisible)
		{
			this.SetFilterOptionVisible(false, false);
			return;
		}
		UUIInturnAnimController animationController = this.AnimationController;
		if (animationController == null)
		{
			return;
		}
		animationController.Play("Start02", -1, false);
	}

	// Token: 0x06012F78 RID: 77688 RVA: 0x0053EDC0 File Offset: 0x0053CFC0
	private void SetFilterOptionVisible(bool bVisible, bool isClickToggle = false)
	{
		foreach (PhotoFilterItem photoFilterItem in this.FilterItemMap.Values)
		{
			if (bVisible)
			{
				photoFilterItem.ShowFilterItem();
				int photographFilter = ModelBase<PhotographModel>.Instance.GetPhotographFilter();
				if (photoFilterItem.GetPhotoFilterId() == photographFilter)
				{
					this.SelectedFilterItem = photoFilterItem;
				}
			}
			else
			{
				photoFilterItem.PlayDisappearSequence(isClickToggle);
			}
		}
		if (bVisible && isClickToggle)
		{
			UUIInturnAnimController animationController = this.AnimationController;
			if (animationController != null)
			{
				animationController.Play("SwitchIn", -1, false);
			}
		}
		PhotoFilterItem photoFilterItem2;
		if (bVisible && this.SelectedFilterItem == null && this.FilterItemMap.TryGetValue(1, out photoFilterItem2))
		{
			ModelBase<PhotographModel>.Instance.SetPhotographFilter(photoFilterItem2.GetPhotoFilterId());
			this.SelectedFilterItem = photoFilterItem2;
			this.SelectedFilterItem.SetSelected(true, false);
		}
	}

	// Token: 0x06012F79 RID: 77689 RVA: 0x0053EE9C File Offset: 0x0053D09C
	private void OnSelectedFilterItem(PhotoFilterItem filterItem, bool bSelectOn)
	{
		if (bSelectOn)
		{
			this.SelectOnFilterItem(filterItem);
		}
	}

	// Token: 0x06012F7A RID: 77690 RVA: 0x0053EEA8 File Offset: 0x0053D0A8
	private void SelectOnFilterItem(PhotoFilterItem filterItem)
	{
		if (this.SelectedFilterItem != null)
		{
			this.SelectedFilterItem.SetSelected(false, false);
		}
		this.SelectedFilterItem = filterItem;
		this.SelectedFilterItem.SetSelected(true, false);
		this.ScrollToSelectedItem(this.SelectedFilterItem);
	}

	// Token: 0x06012F7B RID: 77691 RVA: 0x0053EEDF File Offset: 0x0053D0DF
	private void DeselectOnFilterItem()
	{
		if (this.SelectedFilterItem != null)
		{
			this.SelectedFilterItem.SetSelected(false, false);
			this.SelectedFilterItem = null;
			ModelBase<PhotographModel>.Instance.ClearSelectedPhotographFilter();
		}
	}

	// Token: 0x040093F8 RID: 37880
	private int SkinId;

	// Token: 0x040093F9 RID: 37881
	private EPhotoSettingMode PhotoSetupMode = EPhotoSettingMode.CameraSetup;

	// Token: 0x040093FA RID: 37882
	private ERoleMainAnimInstanceType RoleAnimType = ERoleMainAnimInstanceType.CommonAnim;

	// Token: 0x040093FB RID: 37883
	private readonly HashSet<PhotographExpressionItem> ExpressionItemSet = new HashSet<PhotographExpressionItem>();

	// Token: 0x040093FC RID: 37884
	private readonly Dictionary<int, PhotographExpressionItem> MotionItemMap = new Dictionary<int, PhotographExpressionItem>();

	// Token: 0x040093FD RID: 37885
	private readonly Dictionary<int, PhotoFilterItem> FilterItemMap = new Dictionary<int, PhotoFilterItem>();

	// Token: 0x040093FE RID: 37886
	[Nullable(2)]
	private PhotoFilterToggleItem FilterToggleItem;

	// Token: 0x040093FF RID: 37887
	[Nullable(2)]
	private PhotographTab PhotoFilterTab;

	// Token: 0x04009400 RID: 37888
	[Nullable(2)]
	private PhotographExpressionItem SelectedExpressionItem;

	// Token: 0x04009401 RID: 37889
	[Nullable(2)]
	private PhotographExpressionItem SelectedMotionItem;

	// Token: 0x04009402 RID: 37890
	[Nullable(2)]
	private PhotoFilterItem SelectedFilterItem;

	// Token: 0x04009403 RID: 37891
	public UUIScrollViewWithScrollbarComponent UiScrollView;

	// Token: 0x04009404 RID: 37892
	private readonly Dictionary<EPhotoSetupValueType, IPhotographSetupItem> SetupItemMap = new Dictionary<EPhotoSetupValueType, IPhotographSetupItem>();

	// Token: 0x04009405 RID: 37893
	[Nullable(2)]
	private UUIInturnAnimController AnimationController;

	// Token: 0x04009406 RID: 37894
	[Nullable(new byte[]
	{
		2,
		1
	})]
	private Dictionary<EPhotoSettingMode, UUIExtendToggle> TabItemMap = new Dictionary<EPhotoSettingMode, UUIExtendToggle>();

	// Token: 0x02008946 RID: 35142
	[NullableContext(0)]
	private enum ESetUpChildNode
	{
		// Token: 0x0402E513 RID: 189715
		TabSet,
		// Token: 0x0402E514 RID: 189716
		TabEmotion,
		// Token: 0x0402E515 RID: 189717
		TabMotion,
		// Token: 0x0402E516 RID: 189718
		LayoutContent,
		// Token: 0x0402E517 RID: 189719
		ItemExpressionSource,
		// Token: 0x0402E518 RID: 189720
		ItemOptionSetupSource,
		// Token: 0x0402E519 RID: 189721
		ItemValueSetupSource,
		// Token: 0x0402E51A RID: 189722
		ButtonBack,
		// Token: 0x0402E51B RID: 189723
		ItemExpressionDefault,
		// Token: 0x0402E51C RID: 189724
		TabFilter,
		// Token: 0x0402E51D RID: 189725
		ItemFilterSource,
		// Token: 0x0402E51E RID: 189726
		PanelAll,
		// Token: 0x0402E51F RID: 189727
		ScrollView,
		// Token: 0x0402E520 RID: 189728
		ItemDropDownSetupSource,
		// Token: 0x0402E521 RID: 189729
		ItemValueWithoutTitleSetupSource,
		// Token: 0x0402E522 RID: 189730
		RedDot,
		// Token: 0x0402E523 RID: 189731
		PanelHideOnly
	}
}
