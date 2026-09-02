using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using CSharpScript.Core.Common;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.UiNavigation;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x02001E2C RID: 7724
[NullableContext(2)]
[Nullable(0)]
public class GuideFocusItem : UiPanelBase, IStaticVariableResetter
{
	// Token: 0x0600E455 RID: 58453 RVA: 0x003D7E03 File Offset: 0x003D6003
	static GuideFocusItem()
	{
		StaticVariableRegister.RegisterAndExecute(new Action(GuideFocusItem.CreateStaticDefaultValue), new Action(GuideFocusItem.ResetStaticDefaultValue));
	}

	// Token: 0x0600E456 RID: 58454 RVA: 0x003D7E22 File Offset: 0x003D6022
	public static void CreateStaticDefaultValue()
	{
		GuideFocusItem.IsOpenLog = false;
	}

	// Token: 0x0600E457 RID: 58455 RVA: 0x003D7E2A File Offset: 0x003D602A
	public static void ResetStaticDefaultValue()
	{
		GuideFocusItem.IsOpenLog = false;
	}

	// Token: 0x0600E458 RID: 58456 RVA: 0x003D7E34 File Offset: 0x003D6034
	[NullableContext(1)]
	public GuideFocusItem(UUIItem attachedItem, UUIItem attachedItemForShow, GuideFocusView owner)
	{
		this.Owner = owner;
		this.Config = new GuideFocusNew?((GuideFocusNew)this.Owner.GetGuideStepInfo().ViewData.ViewConf);
		this.AttachedItem = attachedItem;
		this.AttachedItemForShow = attachedItemForShow;
	}

	// Token: 0x0600E459 RID: 58457 RVA: 0x003D7EC5 File Offset: 0x003D60C5
	[NullableContext(1)]
	public void Init(UUIItem item)
	{
		if (item != null)
		{
			base.CreateThenShowByActorAsync(item.GetOwner(), null, false);
		}
	}

	// Token: 0x0600E45A RID: 58458 RVA: 0x003D7EDC File Offset: 0x003D60DC
	protected unsafe override void OnRegisterComponent()
	{
		int num = 5;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int num2 = 0;
		*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIButtonComponent));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIItem));
		this.ComponentRegisterInfos = list;
		num2 = 1;
		List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
		CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
		Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
		num = 0;
		*span2[num] = new ValueTuple<int, Delegate>(0, new Action(this.OnButtonClick));
		this.BtnBindInfo = list2;
	}

	// Token: 0x0600E45B RID: 58459 RVA: 0x003D7FE8 File Offset: 0x003D61E8
	protected override UniTask OnBeforeStartAsync()
	{
		GuideFocusItem.<OnBeforeStartAsync>d__29 <OnBeforeStartAsync>d__;
		<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnBeforeStartAsync>d__.<>4__this = this;
		<OnBeforeStartAsync>d__.<>1__state = -1;
		<OnBeforeStartAsync>d__.<>t__builder.Start<GuideFocusItem.<OnBeforeStartAsync>d__29>(ref <OnBeforeStartAsync>d__);
		return <OnBeforeStartAsync>d__.<>t__builder.Task;
	}

	// Token: 0x0600E45C RID: 58460 RVA: 0x003D802C File Offset: 0x003D622C
	protected override void OnStart()
	{
		ULGUICanvas ulguicanvas = Singleton<LguiUtil>.Instance.GetChildActorByHierarchyIndex(base.GetOriginalActor() as AUIBaseActor, 0).GetComponentByClass(ULGUICanvas.StaticClass()) as ULGUICanvas;
		if (this.Config.Value.OnlyFrame)
		{
			base.GetItem(3).SetUIActive(false);
		}
		else
		{
			base.GetItem(3).SetUIActive(true);
			this.TextPart.ShowText();
		}
		if (this.Config.Value.OnlyText)
		{
			base.GetItem(2).SetUIActive(false);
			ulguicanvas.clipFeatherNew = new FMargin(0f, 0f, 0f, 0f);
		}
		else
		{
			base.GetItem(2).SetUIActive(true);
			ulguicanvas.clipFeatherNew = new FMargin(10f, 10f, 10f, 10f);
		}
		this.MaskItem = base.GetItem(1);
		this.RectItem = base.GetItem(2);
		base.GetItem(1).SetUIActive(this.Config.Value.UseMask);
		this.ParentSelectable = (this.AttachedItem.GetOwner().GetComponentByClass(UUISelectableComponent.StaticClass()) as UUISelectableComponent);
		UUIButtonComponent button = base.GetButton(0);
		button.OnPointDownCallBack.Bind(new Action(this.OnButtonPointerDownCallBack));
		button.OnPointUpCallBack.Bind(new Action(this.OnButtonPointerUpCallBack));
		if (this.Config.Value.EnableHover)
		{
			button.OnPointEnterCallBack.Bind(new Action(this.OnButtonHover));
			button.OnPointExitCallBack.Bind(new Action(this.OnButtonUnHover));
		}
		UUIItem panelClickAnyWhere = base.GetItem(3);
		panelClickAnyWhere.SetUIActive(false);
		if (this.Config.Value.ClickAnywhere)
		{
			int clickAnywhereShowTime = this.Config.Value.ClickAnywhereShowTime;
			if (clickAnywhereShowTime > 0)
			{
				button.RootUIComp.Get().SetRaycastTarget(false);
				TimerSystem.GameplayTimeInstance.Delay(delegate(float _)
				{
					panelClickAnyWhere.SetUIActive(true);
					button.RootUIComp.Get().SetRaycastTarget(true);
				}, (float)clickAnywhereShowTime, null, null, true, 1f);
			}
		}
		this.ParentDraggableComponent = (this.AttachedItem.GetOwner().GetComponentByClass(UUIDraggableComponent.StaticClass()) as UUIDraggableComponent);
		UUIDraggableComponent uuidraggableComponent = button.RootUIComp.Get().GetOwner().GetComponentByClass(UUIDraggableComponent.StaticClass()) as UUIDraggableComponent;
		uuidraggableComponent.OnPointerDownCallBack.Bind(delegate(ULGUIPointerEventData eventData)
		{
			this.OnDraggablePointerDownCallBack(eventData);
		});
		uuidraggableComponent.OnPointerBeginDragCallBack.Bind(delegate(ULGUIPointerEventData eventData)
		{
			this.OnDraggablePointerBeginDragCallBack(eventData);
		});
		uuidraggableComponent.OnPointerDragCallBack.Bind(delegate(ULGUIPointerEventData eventData)
		{
			this.OnDraggablePointerDragCallBack(eventData);
		});
		uuidraggableComponent.OnPointerEndDragCallBack.Bind(delegate(ULGUIPointerEventData eventData)
		{
			this.OnDraggablePointerEndDragCallBack(eventData);
		});
		uuidraggableComponent.OnPointerUpCallBack.Bind(delegate(ULGUIPointerEventData eventData)
		{
			this.OnDraggablePointerUpCallBack(eventData);
		});
		ControllerBase<InputDistributeController>.Instance.BindTouches(new int[]
		{
			0,
			1,
			2,
			3,
			4,
			5,
			6,
			7,
			8,
			9
		}, new TInputHandle<InputDistributeDefine.ITouchData>(this.OnTouch));
	}

	// Token: 0x0600E45D RID: 58461 RVA: 0x003D837C File Offset: 0x003D657C
	protected override void OnBeforeShow()
	{
		GuideFocusView owner = this.Owner;
		if (owner != null && ((owner.Config != null) ? new bool?(owner.Config.GetValueOrDefault().UseMask) : null).GetValueOrDefault())
		{
			if (ControllerBase<GuideController>.Instance.CheckHasNewTagInHookNameForShow(this.Owner.Config.Value))
			{
				this.GuideCursorFollowItem = this.AttachedItemForShow;
				ControllerBase<UiNavigationNewController>.Instance.SetNavigationFocusForGuide(this.AttachedItemForShow);
			}
			else
			{
				this.GuideCursorFollowItem = this.AttachedItem;
				ControllerBase<UiNavigationNewController>.Instance.SetNavigationFocusForGuide(this.AttachedItem);
			}
			UiNavigationGlobalData.AddBlockListenerFocusTag("GuideFocus");
			return;
		}
		UUISelectableComponent parentSelectable = this.ParentSelectable;
		if (parentSelectable == null)
		{
			return;
		}
		parentSelectable.FocusListenerDelegate.Bind(new Action(this.TryFinishByClick));
	}

	// Token: 0x0600E45E RID: 58462 RVA: 0x003D8450 File Offset: 0x003D6650
	protected override void OnAfterHide()
	{
		this.GuideCursorFollowItem = null;
		this.HasLastGuideCursorViewportPos = false;
		GuideFocusView owner = this.Owner;
		if (owner != null && ((owner.Config != null) ? new bool?(owner.Config.GetValueOrDefault().UseMask) : null).GetValueOrDefault())
		{
			UiNavigationGlobalData.DeleteBlockListenerFocusTag("GuideFocus");
			ControllerBase<UiNavigationNewController>.Instance.ResetNavigationFocusForGuide();
			return;
		}
		UUISelectableComponent parentSelectable = this.ParentSelectable;
		if (parentSelectable == null)
		{
			return;
		}
		parentSelectable.FocusListenerDelegate.Unbind();
	}

	// Token: 0x0600E45F RID: 58463 RVA: 0x003D84D7 File Offset: 0x003D66D7
	protected override void OnAfterShow()
	{
		this.Owner.ReadyToShow = true;
	}

	// Token: 0x0600E460 RID: 58464 RVA: 0x003D84E8 File Offset: 0x003D66E8
	private void TryFinishByClick()
	{
		if (!this.Config.Value.UseClick)
		{
			return;
		}
		if (this.IsFinishing)
		{
			return;
		}
		this.IsFinishing = true;
		if (GuideFocusItem.IsOpenLog)
		{
			Singleton<Log>.Instance.Warn(ELogModule.Guide, ELogAuthor.TL, "TryFinishByClick done", default(ReadOnlySpan<ValueTuple<string, object>>));
		}
		this.Owner.DoCloseByFinished();
		TimerSystem.GameplayTimeInstance.Next(delegate(float _)
		{
			Singleton<Log>.Instance.Warn(ELogModule.Guide, ELogAuthor.TL, "DoCloseByFinished", default(ReadOnlySpan<ValueTuple<string, object>>));
		}, null, null);
	}

	// Token: 0x0600E461 RID: 58465 RVA: 0x003D8578 File Offset: 0x003D6778
	private void OnButtonClick()
	{
		if (GuideFocusItem.IsOpenLog)
		{
			Singleton<Log>.Instance.Warn(ELogModule.Guide, ELogAuthor.TL, "OnButtonClick enter", default(ReadOnlySpan<ValueTuple<string, object>>));
		}
		UUISelectableComponent parentSelectable = this.ParentSelectable;
		this.TryFinishByClick();
		if (this.HasExecutedClick)
		{
			return;
		}
		this.HasExecutedClick = true;
		if (parentSelectable == null || !parentSelectable.IsInteractable() || !this.AttachedItem.bIsUIActive)
		{
			return;
		}
		UUIExtendButtonComponent uuiextendButtonComponent = parentSelectable as UUIExtendButtonComponent;
		if (uuiextendButtonComponent != null && !uuiextendButtonComponent.OnClickCallBack.IsBound() && uuiextendButtonComponent.HelpGroupId > 0)
		{
			if (GuideFocusItem.IsOpenLog)
			{
				Singleton<Log>.Instance.Warn(ELogModule.Guide, ELogAuthor.HYF, "OnButtonClick execute parent SetDelegateForHelpClick UIExtendButtonComponent", default(ReadOnlySpan<ValueTuple<string, object>>));
			}
			ControllerBase<HelpController>.Instance.OpenHelpById(uuiextendButtonComponent.HelpGroupId);
			return;
		}
		UUIButtonComponent uuibuttonComponent = parentSelectable as UUIButtonComponent;
		if (uuibuttonComponent != null)
		{
			if (uuibuttonComponent.OnClickCallBack.IsBound())
			{
				if (GuideFocusItem.IsOpenLog)
				{
					Singleton<Log>.Instance.Warn(ELogModule.Guide, ELogAuthor.TL, "OnButtonClick execute parent OnClickCallBack UIButtonComponent", default(ReadOnlySpan<ValueTuple<string, object>>));
				}
				uuibuttonComponent.OnClickCallBack.Execute();
				return;
			}
		}
		else
		{
			UUISelectableButtonComponent uuiselectableButtonComponent = parentSelectable as UUISelectableButtonComponent;
			if (uuiselectableButtonComponent != null)
			{
				if (uuiselectableButtonComponent.OnClickCallBack.IsBound())
				{
					if (GuideFocusItem.IsOpenLog)
					{
						Singleton<Log>.Instance.Warn(ELogModule.Guide, ELogAuthor.TL, "OnButtonClick execute parent OnClickCallBack UISelectableButtonComponent", default(ReadOnlySpan<ValueTuple<string, object>>));
					}
					uuiselectableButtonComponent.OnClickCallBack.Execute();
					return;
				}
			}
			else
			{
				UUIToggleComponent uuitoggleComponent = parentSelectable as UUIToggleComponent;
				if (uuitoggleComponent != null)
				{
					uuitoggleComponent.SetState(!uuitoggleComponent.IsOn, true);
					if (GuideFocusItem.IsOpenLog)
					{
						Singleton<Log>.Instance.Warn(ELogModule.Guide, ELogAuthor.TL, "OnButtonClick execute parent SetState UIToggleComponent", default(ReadOnlySpan<ValueTuple<string, object>>));
						return;
					}
				}
				else
				{
					UUIExtendToggle uuiextendToggle = parentSelectable as UUIExtendToggle;
					if (uuiextendToggle != null)
					{
						if (GuideFocusItem.IsOpenLog)
						{
							Singleton<Log>.Instance.Warn(ELogModule.Guide, ELogAuthor.TL, "OnButtonClick execute parent SetToggleState ETT_Checked UIExtendToggle", default(ReadOnlySpan<ValueTuple<string, object>>));
						}
						if (this.Config.Value.EnableAllToggleState)
						{
							if (uuiextendToggle.GetToggleState() == EToggleState.ETT_UnChecked)
							{
								uuiextendToggle.SetToggleState(EToggleState.ETT_Checked, true, false, false);
							}
							else if (uuiextendToggle.GetToggleState() == EToggleState.ETT_Checked)
							{
								uuiextendToggle.SetToggleState(EToggleState.ETT_UnChecked, true, false, false);
							}
						}
						else if (uuiextendToggle.GetToggleState() == EToggleState.ETT_UnChecked)
						{
							uuiextendToggle.SetToggleState(EToggleState.ETT_Checked, true, false, false);
						}
						if (uuiextendToggle.GetToggleState() == EToggleState.ETT_UnDetermined && uuiextendToggle.OnUndeterminedClicked != null && GuideFocusItem.IsOpenLog)
						{
							Singleton<Log>.Instance.Warn(ELogModule.Guide, ELogAuthor.TZJ, "OnButtonClick execute parent OnUndeterminedClicked UIExtendToggle", default(ReadOnlySpan<ValueTuple<string, object>>));
							uuiextendToggle.OnUndeterminedClicked.Broadcast();
							return;
						}
					}
					else
					{
						UUISliderComponent uuisliderComponent = parentSelectable as UUISliderComponent;
						if (uuisliderComponent != null && uuisliderComponent.OnValueChangeCb.IsBound())
						{
							if (GuideFocusItem.IsOpenLog)
							{
								Singleton<Log>.Instance.Warn(ELogModule.Guide, ELogAuthor.TL, "OnButtonClick execute parent OnValueChangeCb UISliderComponent", default(ReadOnlySpan<ValueTuple<string, object>>));
							}
							uuisliderComponent.OnValueChangeCb.Execute(uuisliderComponent.Value);
						}
					}
				}
			}
		}
	}

	// Token: 0x0600E462 RID: 58466 RVA: 0x003D8838 File Offset: 0x003D6A38
	private void OnButtonPointerDownCallBack()
	{
		if (this.IsFinishing)
		{
			return;
		}
		if (GuideFocusItem.IsOpenLog)
		{
			Singleton<Log>.Instance.Warn(ELogModule.Guide, ELogAuthor.TL, "OnButtonPointerDownCallBack enter", default(ReadOnlySpan<ValueTuple<string, object>>));
		}
		UUISelectableComponent parentSelectable = this.ParentSelectable;
		if (parentSelectable == null || !parentSelectable.IsValid())
		{
			return;
		}
		if (GuideFocusItem.IsOpenLog)
		{
			Singleton<Log>.Instance.Warn(ELogModule.Guide, ELogAuthor.TL, "OnButtonPointerDownCallBack execute self", default(ReadOnlySpan<ValueTuple<string, object>>));
		}
		this.IsButtonDown = true;
		UUIButtonComponent uuibuttonComponent = parentSelectable as UUIButtonComponent;
		if (uuibuttonComponent != null)
		{
			if (uuibuttonComponent.OnPointDownCallBack.IsBound())
			{
				if (GuideFocusItem.IsOpenLog)
				{
					Singleton<Log>.Instance.Warn(ELogModule.Guide, ELogAuthor.TL, "OnButtonPointerDownCallBack execute parent UIButtonComponent", default(ReadOnlySpan<ValueTuple<string, object>>));
				}
				uuibuttonComponent.OnPointDownCallBack.Execute();
				return;
			}
		}
		else
		{
			UUIExtendToggle uuiextendToggle = parentSelectable as UUIExtendToggle;
			if (uuiextendToggle != null && uuiextendToggle.OnPointDownCallBack.IsBound())
			{
				if (GuideFocusItem.IsOpenLog)
				{
					Singleton<Log>.Instance.Warn(ELogModule.Guide, ELogAuthor.TL, "OnButtonPointerDownCallBack execute parent UIExtendToggle", default(ReadOnlySpan<ValueTuple<string, object>>));
				}
				uuiextendToggle.OnPointDownCallBack.Execute(EToggleState.ETT_Checked);
			}
		}
	}

	// Token: 0x0600E463 RID: 58467 RVA: 0x003D8940 File Offset: 0x003D6B40
	private void OnButtonPointerUpCallBack()
	{
		if (GuideFocusItem.IsOpenLog)
		{
			Singleton<Log>.Instance.Warn(ELogModule.Guide, ELogAuthor.TL, "OnButtonPointerUpCallBack enter", default(ReadOnlySpan<ValueTuple<string, object>>));
		}
		UUISelectableComponent parentSelectable = this.ParentSelectable;
		if (parentSelectable == null || !parentSelectable.IsValid())
		{
			return;
		}
		this.IsButtonDown = false;
		if (GuideFocusItem.IsOpenLog)
		{
			Singleton<Log>.Instance.Warn(ELogModule.Guide, ELogAuthor.TL, "OnButtonPointerUpCallBack execute self TryFinishByClick", default(ReadOnlySpan<ValueTuple<string, object>>));
		}
		UUIButtonComponent uuibuttonComponent = parentSelectable as UUIButtonComponent;
		if (uuibuttonComponent != null)
		{
			if (uuibuttonComponent.OnPointUpCallBack.IsBound())
			{
				if (GuideFocusItem.IsOpenLog)
				{
					Singleton<Log>.Instance.Warn(ELogModule.Guide, ELogAuthor.TL, "OnButtonPointerUpCallBack execute parent UIButtonComponent", default(ReadOnlySpan<ValueTuple<string, object>>));
				}
				this.TryFinishByClick();
				uuibuttonComponent.OnPointUpCallBack.Execute();
				return;
			}
		}
		else
		{
			UUIExtendToggle uuiextendToggle = parentSelectable as UUIExtendToggle;
			if (uuiextendToggle != null)
			{
				if (uuiextendToggle.OnPointUpCallBack.IsBound())
				{
					if (GuideFocusItem.IsOpenLog)
					{
						Singleton<Log>.Instance.Warn(ELogModule.Guide, ELogAuthor.TL, "OnButtonPointerUpCallBack execute parent UIExtendToggle", default(ReadOnlySpan<ValueTuple<string, object>>));
					}
					this.TryFinishByClick();
					uuiextendToggle.OnPointUpCallBack.Execute(EToggleState.ETT_Checked);
				}
				if (uuiextendToggle.OnPointUpCallBackWithEventData.IsBound())
				{
					if (GuideFocusItem.IsOpenLog)
					{
						Singleton<Log>.Instance.Warn(ELogModule.Guide, ELogAuthor.TL, "OnButtonPointerUpCallBack execute parent UIExtendToggle", default(ReadOnlySpan<ValueTuple<string, object>>));
					}
					this.TryFinishByClick();
					uuiextendToggle.OnPointUpCallBackWithEventData.Execute(EToggleState.ETT_Checked, null);
				}
			}
		}
	}

	// Token: 0x0600E464 RID: 58468 RVA: 0x003D8A94 File Offset: 0x003D6C94
	private void OnButtonHover()
	{
		if (GuideFocusItem.IsOpenLog)
		{
			Singleton<Log>.Instance.Warn(ELogModule.Guide, ELogAuthor.HYF, "OnButtonHover enter", default(ReadOnlySpan<ValueTuple<string, object>>));
		}
		UUISelectableComponent parentSelectable = this.ParentSelectable;
		if (parentSelectable == null || !parentSelectable.IsValid())
		{
			return;
		}
		if (GuideFocusItem.IsOpenLog)
		{
			Singleton<Log>.Instance.Warn(ELogModule.Guide, ELogAuthor.HYF, "OnButtonHover execute self", default(ReadOnlySpan<ValueTuple<string, object>>));
		}
		UUIButtonComponent uuibuttonComponent = parentSelectable as UUIButtonComponent;
		if (uuibuttonComponent != null)
		{
			if (uuibuttonComponent.OnPointEnterCallBack.IsBound())
			{
				if (GuideFocusItem.IsOpenLog)
				{
					Singleton<Log>.Instance.Warn(ELogModule.Guide, ELogAuthor.HYF, "OnButtonHover execute parent UIButtonComponent", default(ReadOnlySpan<ValueTuple<string, object>>));
				}
				uuibuttonComponent.OnPointEnterCallBack.Execute();
				return;
			}
		}
		else
		{
			UUIExtendToggle uuiextendToggle = parentSelectable as UUIExtendToggle;
			if (uuiextendToggle != null)
			{
				if (uuiextendToggle.OnHover.IsBound())
				{
					if (GuideFocusItem.IsOpenLog)
					{
						Singleton<Log>.Instance.Warn(ELogModule.Guide, ELogAuthor.HYF, "OnButtonHover execute parent UIExtendToggle", default(ReadOnlySpan<ValueTuple<string, object>>));
					}
					uuiextendToggle.OnHover.Broadcast();
				}
				if (uuiextendToggle.OnPointEnterCallBack.IsBound())
				{
					if (GuideFocusItem.IsOpenLog)
					{
						Singleton<Log>.Instance.Warn(ELogModule.Guide, ELogAuthor.HYF, "OnButtonHover execute parent UIExtendToggle", default(ReadOnlySpan<ValueTuple<string, object>>));
					}
					EToggleState toggleState = uuiextendToggle.GetToggleState();
					uuiextendToggle.OnPointEnterCallBack.Execute(toggleState);
				}
			}
		}
	}

	// Token: 0x0600E465 RID: 58469 RVA: 0x003D8BD8 File Offset: 0x003D6DD8
	private void OnButtonUnHover()
	{
		if (GuideFocusItem.IsOpenLog)
		{
			Singleton<Log>.Instance.Warn(ELogModule.Guide, ELogAuthor.HYF, "OnButtonUnHover enter", default(ReadOnlySpan<ValueTuple<string, object>>));
		}
		UUISelectableComponent parentSelectable = this.ParentSelectable;
		if (parentSelectable == null || !parentSelectable.IsValid())
		{
			return;
		}
		if (GuideFocusItem.IsOpenLog)
		{
			Singleton<Log>.Instance.Warn(ELogModule.Guide, ELogAuthor.HYF, "OnButtonUnHover execute self", default(ReadOnlySpan<ValueTuple<string, object>>));
		}
		UUIButtonComponent uuibuttonComponent = parentSelectable as UUIButtonComponent;
		if (uuibuttonComponent != null)
		{
			if (uuibuttonComponent.OnPointExitCallBack.IsBound())
			{
				if (GuideFocusItem.IsOpenLog)
				{
					Singleton<Log>.Instance.Warn(ELogModule.Guide, ELogAuthor.HYF, "OnButtonUnHover execute parent UIButtonComponent", default(ReadOnlySpan<ValueTuple<string, object>>));
				}
				uuibuttonComponent.OnPointExitCallBack.Execute();
				return;
			}
		}
		else
		{
			UUIExtendToggle uuiextendToggle = parentSelectable as UUIExtendToggle;
			if (uuiextendToggle != null)
			{
				if (GuideFocusItem.IsOpenLog)
				{
					Singleton<Log>.Instance.Warn(ELogModule.Guide, ELogAuthor.HYF, "OnButtonUnHover execute parent UIExtendToggle", default(ReadOnlySpan<ValueTuple<string, object>>));
				}
				uuiextendToggle.OnUnHover.Broadcast();
				if (uuiextendToggle.OnPointExitCallBack.IsBound())
				{
					if (GuideFocusItem.IsOpenLog)
					{
						Singleton<Log>.Instance.Warn(ELogModule.Guide, ELogAuthor.HYF, "OnButtonUnHover execute parent UIButtonComponent", default(ReadOnlySpan<ValueTuple<string, object>>));
					}
					EToggleState toggleState = uuiextendToggle.GetToggleState();
					uuiextendToggle.OnPointExitCallBack.Execute(toggleState);
				}
			}
		}
	}

	// Token: 0x0600E466 RID: 58470 RVA: 0x003D8D0C File Offset: 0x003D6F0C
	[NullableContext(1)]
	private void OnDraggablePointerDownCallBack(ULGUIPointerEventData eventData)
	{
		if (this.IsFinishing)
		{
			return;
		}
		if (GuideFocusItem.IsOpenLog)
		{
			Singleton<Log>.Instance.Warn(ELogModule.Guide, ELogAuthor.TL, "OnDraggablePointerDownCallBack enter", default(ReadOnlySpan<ValueTuple<string, object>>));
		}
		UUIDraggableComponent parentDraggableComponent = this.ParentDraggableComponent;
		if (parentDraggableComponent == null || !parentDraggableComponent.IsValid())
		{
			return;
		}
		if (GuideFocusItem.IsOpenLog)
		{
			Singleton<Log>.Instance.Warn(ELogModule.Guide, ELogAuthor.TL, "OnDraggablePointerDownCallBack execute self", default(ReadOnlySpan<ValueTuple<string, object>>));
		}
		if (parentDraggableComponent.OnPointerDownCallBack.IsBound())
		{
			if (GuideFocusItem.IsOpenLog)
			{
				Singleton<Log>.Instance.Warn(ELogModule.Guide, ELogAuthor.TL, "OnDraggablePointerDownCallBack execute parent", default(ReadOnlySpan<ValueTuple<string, object>>));
			}
			parentDraggableComponent.OnPointerDownCallBack.Execute(eventData);
		}
	}

	// Token: 0x0600E467 RID: 58471 RVA: 0x003D8DC0 File Offset: 0x003D6FC0
	[NullableContext(1)]
	private void OnDraggablePointerBeginDragCallBack(ULGUIPointerEventData eventData)
	{
		if (this.IsFinishing)
		{
			return;
		}
		if (GuideFocusItem.IsOpenLog)
		{
			Singleton<Log>.Instance.Warn(ELogModule.Guide, ELogAuthor.TL, "OnDraggablePointerBeginDragCallBack enter", default(ReadOnlySpan<ValueTuple<string, object>>));
		}
		UUIDraggableComponent parentDraggableComponent = this.ParentDraggableComponent;
		if (parentDraggableComponent == null || !parentDraggableComponent.IsValid())
		{
			return;
		}
		if (GuideFocusItem.IsOpenLog)
		{
			Singleton<Log>.Instance.Warn(ELogModule.Guide, ELogAuthor.TL, "OnDraggablePointerBeginDragCallBack execute self", default(ReadOnlySpan<ValueTuple<string, object>>));
		}
		this.IsDragging = true;
		if (parentDraggableComponent.OnPointerBeginDragCallBack.IsBound())
		{
			if (GuideFocusItem.IsOpenLog)
			{
				Singleton<Log>.Instance.Warn(ELogModule.Guide, ELogAuthor.TL, "OnDraggablePointerBeginDragCallBack execute parent", default(ReadOnlySpan<ValueTuple<string, object>>));
			}
			parentDraggableComponent.OnPointerBeginDragCallBack.Execute(eventData);
		}
	}

	// Token: 0x0600E468 RID: 58472 RVA: 0x003D8E78 File Offset: 0x003D7078
	[NullableContext(1)]
	private void OnDraggablePointerDragCallBack(ULGUIPointerEventData eventData)
	{
		if (this.IsFinishing)
		{
			return;
		}
		if (GuideFocusItem.IsOpenLog)
		{
			Singleton<Log>.Instance.Warn(ELogModule.Guide, ELogAuthor.TL, "OnDraggablePointerDragCallBack enter", default(ReadOnlySpan<ValueTuple<string, object>>));
		}
		UUIDraggableComponent parentDraggableComponent = this.ParentDraggableComponent;
		if (parentDraggableComponent == null || !parentDraggableComponent.IsValid())
		{
			return;
		}
		if (GuideFocusItem.IsOpenLog)
		{
			Singleton<Log>.Instance.Warn(ELogModule.Guide, ELogAuthor.TL, "OnDraggablePointerDragCallBack execute self", default(ReadOnlySpan<ValueTuple<string, object>>));
		}
		this.DragEventData = eventData;
		if (parentDraggableComponent.OnPointerDragCallBack.IsBound())
		{
			if (GuideFocusItem.IsOpenLog)
			{
				Singleton<Log>.Instance.Warn(ELogModule.Guide, ELogAuthor.TL, "OnDraggablePointerDragCallBack execute parent", default(ReadOnlySpan<ValueTuple<string, object>>));
			}
			parentDraggableComponent.OnPointerDragCallBack.Execute(eventData);
		}
	}

	// Token: 0x0600E469 RID: 58473 RVA: 0x003D8F30 File Offset: 0x003D7130
	[NullableContext(1)]
	private void OnDraggablePointerEndDragCallBack(ULGUIPointerEventData eventData)
	{
		if (GuideFocusItem.IsOpenLog)
		{
			Singleton<Log>.Instance.Warn(ELogModule.Guide, ELogAuthor.TL, "OnDraggablePointerEndDragCallBack enter", default(ReadOnlySpan<ValueTuple<string, object>>));
		}
		UUIDraggableComponent parentDraggableComponent = this.ParentDraggableComponent;
		if (parentDraggableComponent == null || !parentDraggableComponent.IsValid())
		{
			return;
		}
		if (GuideFocusItem.IsOpenLog)
		{
			Singleton<Log>.Instance.Warn(ELogModule.Guide, ELogAuthor.TL, "OnDraggablePointerEndDragCallBack execute self", default(ReadOnlySpan<ValueTuple<string, object>>));
		}
		this.IsDragging = false;
		if (parentDraggableComponent.OnPointerEndDragCallBack.IsBound())
		{
			if (GuideFocusItem.IsOpenLog)
			{
				Singleton<Log>.Instance.Warn(ELogModule.Guide, ELogAuthor.TL, "OnDraggablePointerEndDragCallBack execute parent", default(ReadOnlySpan<ValueTuple<string, object>>));
			}
			parentDraggableComponent.OnPointerEndDragCallBack.Execute(eventData);
		}
	}

	// Token: 0x0600E46A RID: 58474 RVA: 0x003D8FE0 File Offset: 0x003D71E0
	[NullableContext(1)]
	private void OnDraggablePointerUpCallBack(ULGUIPointerEventData eventData)
	{
		if (GuideFocusItem.IsOpenLog)
		{
			Singleton<Log>.Instance.Warn(ELogModule.Guide, ELogAuthor.TL, "OnDraggablePointerUpCallBack enter", default(ReadOnlySpan<ValueTuple<string, object>>));
		}
		UUIDraggableComponent parentDraggableComponent = this.ParentDraggableComponent;
		if (parentDraggableComponent == null || !parentDraggableComponent.IsValid())
		{
			return;
		}
		if (GuideFocusItem.IsOpenLog)
		{
			Singleton<Log>.Instance.Warn(ELogModule.Guide, ELogAuthor.TL, "OnDraggablePointerUpCallBack execute self", default(ReadOnlySpan<ValueTuple<string, object>>));
		}
		if (parentDraggableComponent.OnPointerUpCallBack.IsBound())
		{
			if (GuideFocusItem.IsOpenLog)
			{
				Singleton<Log>.Instance.Warn(ELogModule.Guide, ELogAuthor.TL, "OnDraggablePointerUpCallBack execute parent", default(ReadOnlySpan<ValueTuple<string, object>>));
			}
			parentDraggableComponent.OnPointerUpCallBack.Execute(eventData);
			if (GuideFocusItem.IsOpenLog)
			{
				Singleton<Log>.Instance.Warn(ELogModule.Guide, ELogAuthor.TL, "OnDraggablePointerUpCallBack execute TryFinishByClick", default(ReadOnlySpan<ValueTuple<string, object>>));
			}
			this.TryFinishByClick();
		}
	}

	// Token: 0x0600E46B RID: 58475 RVA: 0x003D90B1 File Offset: 0x003D72B1
	public void OnBaseViewCloseWhenFinish()
	{
		this.TextPart.OnBaseViewCloseWhenFinish();
	}

	// Token: 0x0600E46C RID: 58476 RVA: 0x003D90C0 File Offset: 0x003D72C0
	protected override void OnBeforeDestroy()
	{
		this.IsFinishing = true;
		if (this.IsDragging)
		{
			this.OnDraggablePointerEndDragCallBack(this.DragEventData);
			this.OnDraggablePointerUpCallBack(this.DragEventData);
			this.IsDragging = false;
			this.DragEventData = null;
		}
		if (this.IsButtonDown)
		{
			this.OnButtonPointerUpCallBack();
			this.IsButtonDown = false;
		}
		UUIButtonComponent button = base.GetButton(0);
		if (button != null)
		{
			button.OnPointDownCallBack.Unbind();
			button.OnPointUpCallBack.Unbind();
			if (this.Config != null && this.Config.GetValueOrDefault().EnableHover)
			{
				button.OnPointEnterCallBack.Unbind();
				button.OnPointExitCallBack.Unbind();
			}
			AActor owner = button.RootUIComp.Get().GetOwner();
			UUIDraggableComponent uuidraggableComponent = ((owner != null) ? owner.GetComponentByClass(UUIDraggableComponent.StaticClass()) : null) as UUIDraggableComponent;
			if (uuidraggableComponent != null)
			{
				uuidraggableComponent.OnPointerDownCallBack.Unbind();
				uuidraggableComponent.OnPointerBeginDragCallBack.Unbind();
				uuidraggableComponent.OnPointerDragCallBack.Unbind();
				uuidraggableComponent.OnPointerEndDragCallBack.Unbind();
				uuidraggableComponent.OnPointerUpCallBack.Unbind();
			}
		}
		ControllerBase<InputDistributeController>.Instance.UnBindTouches(new <>z__ReadOnlyArray<int>(new int[]
		{
			0,
			1,
			2,
			3,
			4,
			5,
			6,
			7,
			8,
			9
		}), new TInputHandle<InputDistributeDefine.ITouchData>(this.OnTouch));
	}

	// Token: 0x0600E46D RID: 58477 RVA: 0x003D9208 File Offset: 0x003D7408
	[NullableContext(1)]
	private void OnTouch(string touchIdName, InputDistributeDefine.ITouchData touchData, InputIdentification _)
	{
		int num = int.Parse(touchIdName);
		TouchFingerData touchFingerData = Singleton<TouchFingerManager>.Instance.GetTouchFingerData((EFingerIndex)num);
		USceneComponent usceneComponent;
		if (touchFingerData == null)
		{
			usceneComponent = null;
		}
		else
		{
			ULGUIPointerEventData pointerEventData = touchFingerData.GetPointerEventData();
			usceneComponent = ((pointerEventData != null) ? pointerEventData.pressComponent : null);
		}
		USceneComponent usceneComponent2 = usceneComponent;
		if (usceneComponent2 == null)
		{
			return;
		}
		if (usceneComponent2.GetOwner() != base.GetButton(0).GetOwner())
		{
			return;
		}
		Singleton<EventSystem>.Instance.Emit<int, AActor>(EEventName.GuideTouchIdInject, num, this.AttachedItem.GetOwner());
	}

	// Token: 0x0600E46E RID: 58478 RVA: 0x003D9278 File Offset: 0x003D7478
	public void OnTick(float delta)
	{
		if (!base.IsShowOrShowing)
		{
			return;
		}
		UUIItem rootItem = this.RootItem;
		if (rootItem == null || !rootItem.IsValid())
		{
			return;
		}
		UUIItem attachedItem = this.AttachedItem;
		if (attachedItem == null || !attachedItem.IsValid())
		{
			return;
		}
		this.ApplyButtonFollow();
		this.ApplyBgFollow();
		this.ApplyGuideCursorFollow();
		FocusItemText textPart = this.TextPart;
		if (textPart == null)
		{
			return;
		}
		textPart.OnTick(delta);
	}

	// Token: 0x0600E46F RID: 58479 RVA: 0x003D92E4 File Offset: 0x003D74E4
	private void ApplyGuideCursorFollow()
	{
		if (!Singleton<Info>.Instance.IsInGamepad())
		{
			return;
		}
		UUIItem guideCursorFollowItem = this.GuideCursorFollowItem;
		if (guideCursorFollowItem == null || !guideCursorFollowItem.IsValid())
		{
			return;
		}
		UUIItem uuiitem = guideCursorFollowItem;
		bool bIsScaledByDPI = true;
		FVector2D fvector2D = new FVector2D(0.5f, 0.5f);
		FVector2D positionInViewportWithPivot = uuiitem.GetPositionInViewportWithPivot(bIsScaledByDPI, fvector2D);
		if (this.HasLastGuideCursorViewportPos)
		{
			float num = Math.Abs(positionInViewportWithPivot.X - this.LastGuideCursorViewportPos.X);
			float num2 = Math.Abs(positionInViewportWithPivot.Y - this.LastGuideCursorViewportPos.Y);
			if (num < 0.5f && num2 < 0.5f)
			{
				return;
			}
		}
		this.LastGuideCursorViewportPos.X = positionInViewportWithPivot.X;
		this.LastGuideCursorViewportPos.Y = positionInViewportWithPivot.Y;
		this.HasLastGuideCursorViewportPos = true;
		ControllerBase<UiNavigationNewController>.Instance.RefreshNavigationMousePositionForGuide(guideCursorFollowItem);
	}

	// Token: 0x0600E470 RID: 58480 RVA: 0x003D93AC File Offset: 0x003D75AC
	public void OnDurationChange(float remainDuration)
	{
		if (!base.GetActive())
		{
			return;
		}
		FocusItemText textPart = this.TextPart;
		if (textPart == null)
		{
			return;
		}
		textPart.OnDurationChange(remainDuration);
	}

	// Token: 0x0600E471 RID: 58481 RVA: 0x003D93C8 File Offset: 0x003D75C8
	public void ApplyButtonFollow()
	{
		UUIItem attachedItemForShow = this.AttachedItemForShow;
		FVectorDouble fvectorDouble = attachedItemForShow.D_K2_GetComponentScale();
		if (this.Owner.GetGuideStepInfo().ViewData.IsMultiAttach)
		{
			List<UUIItem> multiAttachItems = this.Owner.GetGuideStepInfo().ViewData.GetMultiAttachItems();
			float[] array = new float[]
			{
				10000f,
				10000f
			};
			float[] array2 = new float[2];
			foreach (UUIItem item in (multiAttachItems ?? new List<UUIItem>()))
			{
				ValueTuple<float, float, float, float> attachItemBound = this.GetAttachItemBound(item);
				array[0] = Math.Min(array[0], attachItemBound.Item1);
				array[1] = Math.Min(array[1], attachItemBound.Item2);
				array2[0] = Math.Max(array2[0], attachItemBound.Item3);
				array2[1] = Math.Max(array2[1], attachItemBound.Item4);
			}
			this.RootItem.SetPivot(this.MultiAttachPivot);
			this.MultiAttachPos.Set(array[1], array[0], this.MultiAttachPos.Z);
			this.RootItem.SetLGUISpaceAbsolutePosition(this.MultiAttachPos);
			this.RootItem.SetHeight(array2[0] - array[0]);
			this.RootItem.SetWidth(array2[1] - array[1]);
		}
		else
		{
			FHitResult fhitResult = new FHitResult();
			this.RootItem.D_K2_SetWorldLocation(attachedItemForShow.D_K2_GetComponentLocation(), false, ref fhitResult, false);
			this.RootItem.SetPivot(attachedItemForShow.GetPivot());
			this.RootItem.SetHeight((float)((double)attachedItemForShow.Height * fvectorDouble.Y));
			this.RootItem.SetWidth((float)((double)attachedItemForShow.Width * fvectorDouble.X));
		}
		UUIItem attachedItem = this.AttachedItem;
		UUIItem uuiitem = base.GetButton(0).RootUIComp.Get();
		if (this.Config.Value.ClickAnywhere)
		{
			FHitResult fhitResult2 = new FHitResult();
			uuiitem.D_K2_SetWorldLocation(Singleton<UiLayer>.Instance.UiRootItem.D_K2_GetComponentLocation(), false, ref fhitResult2, false);
			uuiitem.SetPivot(Singleton<UiLayer>.Instance.UiRootItem.GetPivot());
			uuiitem.SetHeight(Singleton<UiLayer>.Instance.UiRootItem.Height);
			uuiitem.SetWidth(Singleton<UiLayer>.Instance.UiRootItem.Width);
			return;
		}
		if (this.Config.Value.ExpandClickArea)
		{
			uuiitem.SetPivot(attachedItemForShow.GetPivot());
			uuiitem.SetHeight(attachedItemForShow.Height);
			uuiitem.SetWidth(attachedItemForShow.Width);
			uuiitem.D_SetRelativeScale3D(attachedItemForShow.D_K2_GetComponentScale());
			FHitResult fhitResult3 = new FHitResult();
			uuiitem.D_K2_SetWorldLocation(attachedItemForShow.D_K2_GetComponentLocation(), false, ref fhitResult3, false);
			return;
		}
		uuiitem.SetPivot(attachedItem.GetPivot());
		uuiitem.SetHeight(attachedItem.Height);
		uuiitem.SetWidth(attachedItem.Width);
		uuiitem.D_SetRelativeScale3D(attachedItem.D_K2_GetComponentScale());
		FHitResult fhitResult4 = new FHitResult();
		uuiitem.D_K2_SetWorldLocation(attachedItem.D_K2_GetComponentLocation(), false, ref fhitResult4, false);
	}

	// Token: 0x0600E472 RID: 58482 RVA: 0x003D96D8 File Offset: 0x003D78D8
	public void ApplyBgFollow()
	{
		if (!this.Config.Value.UseMask)
		{
			return;
		}
		UUIItem maskItem = this.MaskItem;
		FHitResult fhitResult = new FHitResult();
		maskItem.D_K2_SetWorldLocation(Singleton<UiLayer>.Instance.UiRootItem.D_K2_GetComponentLocation(), false, ref fhitResult, false);
		maskItem.SetPivot(Singleton<UiLayer>.Instance.UiRootItem.GetPivot());
		maskItem.SetHeight(Singleton<UiLayer>.Instance.UiRootItem.Height);
		maskItem.SetWidth(Singleton<UiLayer>.Instance.UiRootItem.Width);
	}

	// Token: 0x0600E473 RID: 58483 RVA: 0x003D9760 File Offset: 0x003D7960
	[NullableContext(0)]
	private ValueTuple<float, float, float, float> GetAttachItemBound([Nullable(1)] UUIItem item)
	{
		FVector lguispaceCenterAbsolutePosition = item.GetLGUISpaceCenterAbsolutePosition();
		FVectorDouble fvectorDouble = item.D_K2_GetComponentScale();
		double num = (double)item.Width * fvectorDouble.X;
		double num2 = (double)item.Height * fvectorDouble.Y;
		double num3 = (double)lguispaceCenterAbsolutePosition.Y - num2 / 2.0;
		double num4 = (double)lguispaceCenterAbsolutePosition.Y + num2 / 2.0;
		double num5 = (double)lguispaceCenterAbsolutePosition.X - num / 2.0;
		double num6 = (double)lguispaceCenterAbsolutePosition.X + num / 2.0;
		return new ValueTuple<float, float, float, float>((float)num3, (float)num5, (float)num4, (float)num6);
	}

	// Token: 0x04006DC9 RID: 28105
	private const int CANVAS_CLIP_FEATHER = 10;

	// Token: 0x04006DCA RID: 28106
	private const float GUIDE_CURSOR_FOLLOW_THRESHOLD = 0.5f;

	// Token: 0x04006DCB RID: 28107
	public static bool IsOpenLog;

	// Token: 0x04006DCC RID: 28108
	private FocusItemText TextPart;

	// Token: 0x04006DCD RID: 28109
	public readonly GuideFocusView Owner;

	// Token: 0x04006DCE RID: 28110
	private readonly UUIItem AttachedItem;

	// Token: 0x04006DCF RID: 28111
	private readonly UUIItem AttachedItemForShow;

	// Token: 0x04006DD0 RID: 28112
	private UUIItem MaskItem;

	// Token: 0x04006DD1 RID: 28113
	public UUIItem RectItem;

	// Token: 0x04006DD2 RID: 28114
	public readonly GuideFocusNew? Config;

	// Token: 0x04006DD3 RID: 28115
	private bool IsFinishing;

	// Token: 0x04006DD4 RID: 28116
	private bool IsDragging;

	// Token: 0x04006DD5 RID: 28117
	private bool IsButtonDown;

	// Token: 0x04006DD6 RID: 28118
	private UUIDraggableComponent ParentDraggableComponent;

	// Token: 0x04006DD7 RID: 28119
	private UUISelectableComponent ParentSelectable;

	// Token: 0x04006DD8 RID: 28120
	private ULGUIPointerEventData DragEventData;

	// Token: 0x04006DD9 RID: 28121
	private FVector2D MultiAttachPivot = new FVector2D(0f, 0f);

	// Token: 0x04006DDA RID: 28122
	private FVector MultiAttachPos = new FVector(0f, 0f, 0f);

	// Token: 0x04006DDB RID: 28123
	private bool HasExecutedClick;

	// Token: 0x04006DDC RID: 28124
	private UUIItem GuideCursorFollowItem;

	// Token: 0x04006DDD RID: 28125
	private FVector2D LastGuideCursorViewportPos = new FVector2D(0f, 0f);

	// Token: 0x04006DDE RID: 28126
	private bool HasLastGuideCursorViewportPos;

	// Token: 0x0200818E RID: 33166
	[NullableContext(0)]
	private enum EFocusItem
	{
		// Token: 0x0402BFCF RID: 180175
		ClickArea,
		// Token: 0x0402BFD0 RID: 180176
		RectBg,
		// Token: 0x0402BFD1 RID: 180177
		RectView,
		// Token: 0x0402BFD2 RID: 180178
		TextPart,
		// Token: 0x0402BFD3 RID: 180179
		PanelClickAnyWhere = 3
	}
}
