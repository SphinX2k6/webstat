using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Module.AutoAttach;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.Menu.SubViews.FilterSetting
{
	// Token: 0x020057A7 RID: 22439
	[NullableContext(1)]
	[Nullable(0)]
	public class FilterSettingView : UiTickViewBase
	{
		// Token: 0x060390C4 RID: 233668 RVA: 0x00E74F35 File Offset: 0x00E73135
		public FilterSettingView(UiViewInfo viewInfo) : base(viewInfo)
		{
		}

		// Token: 0x060390C5 RID: 233669 RVA: 0x00E74F48 File Offset: 0x00E73148
		protected override void OnRegisterComponent()
		{
			this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
			{
				new ValueTuple<int, Type>(0, typeof(UUITexture)),
				new ValueTuple<int, Type>(7, typeof(UUITexture)),
				new ValueTuple<int, Type>(8, typeof(UUIItem)),
				new ValueTuple<int, Type>(9, typeof(UUIButtonComponent)),
				new ValueTuple<int, Type>(10, typeof(UUIButtonComponent)),
				new ValueTuple<int, Type>(5, typeof(UUIText)),
				new ValueTuple<int, Type>(6, typeof(UUIText)),
				new ValueTuple<int, Type>(12, typeof(UUIButtonComponent)),
				new ValueTuple<int, Type>(13, typeof(UUIButtonComponent)),
				new ValueTuple<int, Type>(14, typeof(UUIItem)),
				new ValueTuple<int, Type>(1, typeof(UUIItem)),
				new ValueTuple<int, Type>(2, typeof(UUIItem)),
				new ValueTuple<int, Type>(3, typeof(UUIItem)),
				new ValueTuple<int, Type>(4, typeof(UUIItem)),
				new ValueTuple<int, Type>(11, typeof(UUIItem)),
				new ValueTuple<int, Type>(15, typeof(UUIExtendToggle)),
				new ValueTuple<int, Type>(16, typeof(UUIItem)),
				new ValueTuple<int, Type>(17, typeof(UUIDraggableComponent)),
				new ValueTuple<int, Type>(18, typeof(UUIItem)),
				new ValueTuple<int, Type>(19, typeof(UUIItem)),
				new ValueTuple<int, Type>(21, typeof(UUIExtendToggle)),
				new ValueTuple<int, Type>(22, typeof(UUIExtendToggle)),
				new ValueTuple<int, Type>(23, typeof(UUIItem)),
				new ValueTuple<int, Type>(24, typeof(UUIVerticalLayout)),
				new ValueTuple<int, Type>(26, typeof(UUIButtonComponent))
			};
			this.BtnBindInfo = new List<ValueTuple<int, Delegate>>
			{
				new ValueTuple<int, Delegate>(9, new Action(this.OnResetClick)),
				new ValueTuple<int, Delegate>(10, new Action(this.OnConfirmClick)),
				new ValueTuple<int, Delegate>(13, new Action(this.OnLeftArrowClick)),
				new ValueTuple<int, Delegate>(12, new Action(this.OnRightArrowClick)),
				new ValueTuple<int, Delegate>(15, new Action<EToggleState>(this.OnHideClick)),
				new ValueTuple<int, Delegate>(21, new Action<EToggleState>(this.OnColorPaletteToggleClick)),
				new ValueTuple<int, Delegate>(22, new Action<EToggleState>(this.OnSeniorParamToggleClick)),
				new ValueTuple<int, Delegate>(26, new Action(this.OnDefaultFilterClick))
			};
		}

		// Token: 0x060390C6 RID: 233670 RVA: 0x00E75269 File Offset: 0x00E73469
		protected override void OnBeforeCreate()
		{
			this.VmCache = (this.OpenParam as FilterSettingViewModel);
			Action onViewBeforeCreate = this.VmCache.OnViewBeforeCreate;
			if (onViewBeforeCreate != null)
			{
				onViewBeforeCreate();
			}
			UKismetSystemLibrary.ExecuteConsoleCommand(GlobalData.World, "r.Kuro.KuroEnableScreenFilter 1", null);
		}

		// Token: 0x060390C7 RID: 233671 RVA: 0x00E752A2 File Offset: 0x00E734A2
		protected override void OnStart()
		{
		}

		// Token: 0x060390C8 RID: 233672 RVA: 0x00E752A4 File Offset: 0x00E734A4
		protected override void OnBeforeShow()
		{
			FilterSettingViewModel vmCache = this.VmCache;
			if (vmCache == null)
			{
				return;
			}
			Action<string> onViewBeforeShow = vmCache.OnViewBeforeShow;
			if (onViewBeforeShow == null)
			{
				return;
			}
			onViewBeforeShow(this.ViewInfo.Name);
		}

		// Token: 0x060390C9 RID: 233673 RVA: 0x00E752D0 File Offset: 0x00E734D0
		protected override void OnAfterHide()
		{
			FilterSettingViewModel vmCache = this.VmCache;
			if (vmCache == null)
			{
				return;
			}
			Action<string> onViewAfterHide = vmCache.OnViewAfterHide;
			if (onViewAfterHide == null)
			{
				return;
			}
			onViewAfterHide(this.ViewInfo.Name);
		}

		// Token: 0x060390CA RID: 233674 RVA: 0x00E752FC File Offset: 0x00E734FC
		protected override void OnAfterDestroy()
		{
			Singleton<UiLayer>.Instance.SetLayerActive(ELayerType.HUD, true);
			FilterSettingController instance = ControllerBase<FilterSettingController>.Instance;
			if (instance != null)
			{
				FilterCameraComponent cameraComponent = instance.CameraComponent;
				if (cameraComponent != null)
				{
					cameraComponent.ClosePhotograph();
				}
			}
			FilterSettingController instance2 = ControllerBase<FilterSettingController>.Instance;
			if (instance2 != null)
			{
				instance2.SwitchFilter(true);
			}
			FilterSettingController instance3 = ControllerBase<FilterSettingController>.Instance;
			if (instance3 == null)
			{
				return;
			}
			instance3.ApplyFilterSetting();
		}

		// Token: 0x060390CB RID: 233675 RVA: 0x00E75350 File Offset: 0x00E73550
		protected override UniTask OnBeforeStartAsync()
		{
			FilterSettingView.<OnBeforeStartAsync>d__18 <OnBeforeStartAsync>d__;
			<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeStartAsync>d__.<>4__this = this;
			<OnBeforeStartAsync>d__.<>1__state = -1;
			<OnBeforeStartAsync>d__.<>t__builder.Start<FilterSettingView.<OnBeforeStartAsync>d__18>(ref <OnBeforeStartAsync>d__);
			return <OnBeforeStartAsync>d__.<>t__builder.Task;
		}

		// Token: 0x060390CC RID: 233676 RVA: 0x00E75394 File Offset: 0x00E73594
		protected override void OnBeforeDestroy()
		{
			CircleAttachView<FilterSetting, FilterSettingPixListItem> circleItem = this.CircleItem;
			if (circleItem != null)
			{
				circleItem.Clear();
			}
			this.CircleItem = null;
			GenericLayout<FilterSeniorParamSliderItem, FilterSeniorSetting> seniorParamLayout = this.SeniorParamLayout;
			if (seniorParamLayout != null)
			{
				seniorParamLayout.ClearChildren();
			}
			this.SeniorParamLayout = null;
			FilterSettingViewModel vmCache = this.VmCache;
			if (vmCache != null)
			{
				Action onViewDestroy = vmCache.OnViewDestroy;
				if (onViewDestroy != null)
				{
					onViewDestroy();
				}
			}
			this.VmCache = null;
			LoadAsyncPromise<UCurveFloat> offsetHandle = this.OffsetHandle;
			if (offsetHandle != null)
			{
				offsetHandle.CancelAsyncLoad();
			}
			LoadAsyncPromise<UCurveFloat> scaleHandle = this.ScaleHandle;
			if (scaleHandle != null)
			{
				scaleHandle.CancelAsyncLoad();
			}
			LoadAsyncPromise<UCurveFloat> alphaHandle = this.AlphaHandle;
			if (alphaHandle != null)
			{
				alphaHandle.CancelAsyncLoad();
			}
			if (this.CurvesCache != null)
			{
				this.CurvesCache = new UCurveFloat[0];
				this.CurvesCache = null;
			}
		}

		// Token: 0x060390CD RID: 233677 RVA: 0x00E75444 File Offset: 0x00E73644
		protected override void OnAddEventListener()
		{
			UUIDraggableComponent draggable = base.GetDraggable(17);
			if (draggable != null)
			{
				draggable.OnPointerDragCallBack.Bind(new Action<ULGUIPointerEventData>(this.OnDragMoved));
			}
			if (draggable != null)
			{
				draggable.OnPointerBeginDragCallBack.Bind(new Action<ULGUIPointerEventData>(this.OnDragBegin));
			}
			if (draggable != null)
			{
				draggable.OnPointerEndDragCallBack.Bind(new Action<ULGUIPointerEventData>(this.OnDragEnded));
			}
			if (draggable != null)
			{
				draggable.OnPointerDownCallBack.Bind(new Action<ULGUIPointerEventData>(this.OnDragBegin));
			}
			if (draggable != null)
			{
				draggable.OnPointerUpCallBack.Bind(new Action<ULGUIPointerEventData>(this.OnDragEnded));
			}
			ControllerBase<InputDistributeController>.Instance.BindAxis("UiMoveForward", new TInputHandle<float>(this.OnInputUiMoveForward));
			ControllerBase<InputDistributeController>.Instance.BindAxis("UiMoveRight", new TInputHandle<float>(this.OnInputUiMoveRight));
			ControllerBase<InputDistributeController>.Instance.BindAxis("UiLookUp", new TInputHandle<float>(this.OnInputUiLookUp));
			ControllerBase<InputDistributeController>.Instance.BindAxis("UiTurn", new TInputHandle<float>(this.OnInputUiTurn));
		}

		// Token: 0x060390CE RID: 233678 RVA: 0x00E75558 File Offset: 0x00E73758
		protected override void OnRemoveEventListener()
		{
			UUIDraggableComponent draggable = base.GetDraggable(17);
			if (draggable != null)
			{
				draggable.OnPointerDragCallBack.Unbind();
			}
			if (draggable != null)
			{
				draggable.OnPointerBeginDragCallBack.Unbind();
			}
			if (draggable != null)
			{
				draggable.OnPointerEndDragCallBack.Unbind();
			}
			if (draggable != null)
			{
				draggable.OnPointerDownCallBack.Unbind();
			}
			if (draggable != null)
			{
				draggable.OnPointerUpCallBack.Unbind();
			}
			if (draggable != null)
			{
				draggable.OnPointerScrollCallBack.Unbind();
			}
			ControllerBase<InputDistributeController>.Instance.UnBindAxis("UiMoveForward", new TInputHandle<float>(this.OnInputUiMoveForward));
			ControllerBase<InputDistributeController>.Instance.UnBindAxis("UiMoveRight", new TInputHandle<float>(this.OnInputUiMoveRight));
			ControllerBase<InputDistributeController>.Instance.UnBindAxis("UiLookUp", new TInputHandle<float>(this.OnInputUiLookUp));
			ControllerBase<InputDistributeController>.Instance.UnBindAxis("UiTurn", new TInputHandle<float>(this.OnInputUiTurn));
		}

		// Token: 0x060390CF RID: 233679 RVA: 0x00E75640 File Offset: 0x00E73840
		protected override void OnTick(float delta)
		{
			if (this.VmCache == null)
			{
				return;
			}
			if (!this.VmCache.IsHideByClick)
			{
				Action onPadChangeStop = this.VmCache.OnPadChangeStop;
				if (onPadChangeStop != null)
				{
					onPadChangeStop();
				}
			}
			FilterSettingViewModel vmCache = this.VmCache;
			CircleAttachView<FilterSetting, FilterSettingPixListItem> circleItem = this.CircleItem;
			vmCache.PadLock = (circleItem != null && circleItem.MovingState());
			if (!this.VmCache.CameraRotationLock && !this.VmCache.PadLock && Singleton<LguiEventSystemManager>.Instance.GetNowHitComponentName() == "TexFilter")
			{
				ULGUIPointerEventData pointerEventData = Singleton<LguiEventSystemManager>.Instance.GetPointerEventData(0, false);
				if (pointerEventData != null)
				{
					FVector worldPointInPlane = pointerEventData.GetWorldPointInPlane();
					EPointerEventType eventType = pointerEventData.eventType;
					if (eventType != EPointerEventType.Down)
					{
						if (eventType - EPointerEventType.BeginDrag <= 1)
						{
							this.VmCache.HorizontalReal = new float?(worldPointInPlane.X);
							this.VmCache.VerticalReal = new float?(worldPointInPlane.Z);
							Action onPadChanged = this.VmCache.OnPadChanged;
							if (onPadChanged != null)
							{
								onPadChanged();
							}
						}
					}
					else
					{
						this.VmCache.HorizontalReal = new float?(worldPointInPlane.X);
						this.VmCache.VerticalReal = new float?(worldPointInPlane.Z);
						Action onPadChanged2 = this.VmCache.OnPadChanged;
						if (onPadChanged2 != null)
						{
							onPadChanged2();
						}
					}
				}
			}
			if (this.VmCache.IsDirty)
			{
				if (this.VmCache.IsPropertyDirty(4) || this.VmCache.IsPropertyDirty(8))
				{
					UUITexture texture = base.GetTexture(7);
					if (texture != null)
					{
						MathUtils instance = Singleton<MathUtils>.Instance;
						FilterSettingViewModel vmCache2 = this.VmCache;
						float from = (vmCache2.UpLeftPos != null) ? vmCache2.UpLeftPos.GetValueOrDefault().X : 0f;
						FilterSettingViewModel vmCache3 = this.VmCache;
						float inX = instance.Lerp(from, (vmCache3.UpRightPos != null) ? vmCache3.UpRightPos.GetValueOrDefault().X : 0f, this.VmCache.HorizontalNormalized);
						float inY = 0f;
						MathUtils instance2 = Singleton<MathUtils>.Instance;
						FilterSettingViewModel vmCache4 = this.VmCache;
						float from2 = (vmCache4.DownLeftPos != null) ? vmCache4.DownLeftPos.GetValueOrDefault().Z : 0f;
						FilterSettingViewModel vmCache5 = this.VmCache;
						FVector fvector = new FVector(inX, inY, instance2.Lerp(from2, (vmCache5.UpLeftPos != null) ? vmCache5.UpLeftPos.GetValueOrDefault().Z : 0f, this.VmCache.VerticalNormalized));
						texture.SetUIWorldLocation(fvector);
					}
					Singleton<LguiUtil>.Instance.TrySetLocalTextNew(base.GetText(5), this.VmCache.CoordinateTextId, new <>z__ReadOnlyArray<object>(new object[]
					{
						this.VmCache.HorizontalString,
						this.VmCache.VerticalString
					}));
				}
				if (this.VmCache.IsPropertyDirty(2))
				{
					FilterSettingSliderItem sliderItem = this.SliderItem;
					if (sliderItem != null)
					{
						sliderItem.SetTitleText(this.VmCache.IntensityString);
					}
					FilterSettingSliderItem sliderItem2 = this.SliderItem;
					if (sliderItem2 != null)
					{
						sliderItem2.SetSliderValue(this.VmCache.IntensityNormalized);
					}
				}
				if (this.VmCache.IsPropertyDirty(16))
				{
					Singleton<LguiUtil>.Instance.TrySetLocalTextNew(base.GetText(6), this.VmCache.FilterNameTextId, Array.Empty<object>());
				}
				if (this.VmCache.IsPropertyDirty(32))
				{
					base.TrySetTextureByPath(this.VmCache.FilterPadTexturePath, base.GetTexture(0), null, null);
				}
				if (this.VmCache.IsPropertyDirty(64))
				{
					if (!this.VmCache.IsHideByPad)
					{
						Singleton<AudioSystem>.Instance.PostEvent("play_ui_ia_com_click_small");
					}
					UUIItem item = base.GetItem(14);
					if (item != null)
					{
						item.SetUIActive(!this.VmCache.IsHideByPad);
					}
					UUIItem item2 = base.GetItem(16);
					if (item2 != null)
					{
						item2.SetUIActive(!this.VmCache.IsHideByPad);
					}
					UUIButtonComponent button = base.GetButton(26);
					if (button != null)
					{
						button.RootUIComp.Get().SetUIActive(!this.VmCache.IsHideByPad);
					}
					UUIExtendToggle extendToggle = base.GetExtendToggle(15);
					if (extendToggle != null)
					{
						UUIItem uuiitem = extendToggle.RootUIComp.Get();
						if (uuiitem != null)
						{
							uuiitem.SetUIActive(!this.VmCache.IsHideByPad);
						}
					}
				}
				if (this.VmCache.IsPropertyDirty(128))
				{
					if (this.VmCache.IsHideByClick)
					{
						UUIItem item3 = base.GetItem(18);
						if (item3 != null)
						{
							item3.SetUIActive(false);
						}
						UUIItem item4 = base.GetItem(23);
						if (item4 != null)
						{
							item4.SetUIActive(false);
						}
					}
					else
					{
						this.RefreshOption(this.IsColorPalette);
					}
					UUIItem item5 = base.GetItem(14);
					if (item5 != null)
					{
						item5.SetUIActive(!this.VmCache.IsHideByClick);
					}
					UUIItem item6 = base.GetItem(16);
					if (item6 != null)
					{
						item6.SetUIActive(!this.VmCache.IsHideByClick);
					}
					UUIButtonComponent button2 = base.GetButton(26);
					if (button2 != null)
					{
						button2.RootUIComp.Get().SetUIActive(!this.VmCache.IsHideByClick);
					}
					UUIExtendToggle extendToggle2 = base.GetExtendToggle(15);
					if (extendToggle2 != null)
					{
						extendToggle2.SetToggleStateForce(this.VmCache.IsHideByClick ? EToggleState.ETT_Checked : EToggleState.ETT_UnChecked, false, false, false);
					}
				}
				if (this.VmCache.IsPropertyDirty(256))
				{
					UUIItem item7 = base.GetItem(8);
					if (item7 != null)
					{
						item7.SetUIActive(this.VmCache.IsSliderActive);
					}
				}
				if (this.VmCache.IsPropertyDirty(512))
				{
					GenericLayout<FilterSeniorParamSliderItem, FilterSeniorSetting> seniorParamLayout = this.SeniorParamLayout;
					if (seniorParamLayout != null)
					{
						seniorParamLayout.RefreshWithoutDataSync();
					}
				}
				this.VmCache.CleanDirty();
			}
			base.GetButton(10).SetSelfInteractive(this.VmCache.IsFilterChanged && !this.VmCache.IsApplyClicked);
		}

		// Token: 0x060390D0 RID: 233680 RVA: 0x00E75BCC File Offset: 0x00E73DCC
		[return: Nullable(new byte[]
		{
			0,
			1,
			1
		})]
		private UniTask<UCurveFloat[]> LoadCurveResource()
		{
			FilterSettingView.<LoadCurveResource>d__23 <LoadCurveResource>d__;
			<LoadCurveResource>d__.<>t__builder = AsyncUniTaskMethodBuilder<UCurveFloat[]>.Create();
			<LoadCurveResource>d__.<>4__this = this;
			<LoadCurveResource>d__.<>1__state = -1;
			<LoadCurveResource>d__.<>t__builder.Start<FilterSettingView.<LoadCurveResource>d__23>(ref <LoadCurveResource>d__);
			return <LoadCurveResource>d__.<>t__builder.Task;
		}

		// Token: 0x060390D1 RID: 233681 RVA: 0x00E75C0F File Offset: 0x00E73E0F
		private FilterSeniorParamSliderItem CreateFilterSeniorParamSliderItem()
		{
			return new FilterSeniorParamSliderItem
			{
				ParentViewModel = this.VmCache
			};
		}

		// Token: 0x060390D2 RID: 233682 RVA: 0x00E75C22 File Offset: 0x00E73E22
		protected override void OnDestroy()
		{
		}

		// Token: 0x060390D3 RID: 233683 RVA: 0x00E75C24 File Offset: 0x00E73E24
		private void OnResetClick()
		{
			FilterSettingViewModel vmCache = this.VmCache;
			if (vmCache == null)
			{
				return;
			}
			Action onResetClick = vmCache.OnResetClick;
			if (onResetClick == null)
			{
				return;
			}
			onResetClick();
		}

		// Token: 0x060390D4 RID: 233684 RVA: 0x00E75C40 File Offset: 0x00E73E40
		private void OnDefaultFilterClick()
		{
			ConfirmBoxDataNew confirmBoxDataNew = new ConfirmBoxDataNew(EConfirmBoxConfigId.GameSettingDefaultFilter);
			confirmBoxDataNew.FunctionMap.Add(2, delegate
			{
				CircleAttachView<FilterSetting, FilterSettingPixListItem> circleItem = this.CircleItem;
				if (circleItem != null)
				{
					circleItem.AttachToIndex(0, false);
				}
				FilterSettingViewModel vmCache = this.VmCache;
				if (vmCache != null)
				{
					Action<int> onIndexChanged = vmCache.OnIndexChanged;
					if (onIndexChanged != null)
					{
						onIndexChanged(0);
					}
				}
				this.OnResetClick();
				DefaultFilterLogEvent logData = new DefaultFilterLogEvent();
				ControllerBase<LogReportController>.Instance.LogReport(logData);
			});
			ControllerBase<ConfirmBoxController>.Instance.ShowConfirmBoxNew(confirmBoxDataNew);
		}

		// Token: 0x060390D5 RID: 233685 RVA: 0x00E75C7C File Offset: 0x00E73E7C
		private void OnConfirmClick()
		{
			FilterSettingViewModel vmCache = this.VmCache;
			if (vmCache != null)
			{
				Action onConfirmClick = vmCache.OnConfirmClick;
				if (onConfirmClick != null)
				{
					onConfirmClick();
				}
			}
			base.GetButton(10).SetSelfInteractive(false);
			CircleAttachView<FilterSetting, FilterSettingPixListItem> circleItem = this.CircleItem;
			if (circleItem == null)
			{
				return;
			}
			circleItem.RefreshItems();
		}

		// Token: 0x060390D6 RID: 233686 RVA: 0x00E75CB8 File Offset: 0x00E73EB8
		private void OnLeftArrowClick()
		{
			CircleAttachView<FilterSetting, FilterSettingPixListItem> circleItem = this.CircleItem;
			if (circleItem != null)
			{
				circleItem.AttachToNextItem(-1);
			}
			FilterSettingViewModel vmCache = this.VmCache;
			if (vmCache == null)
			{
				return;
			}
			Action onLeftArrowClick = vmCache.OnLeftArrowClick;
			if (onLeftArrowClick == null)
			{
				return;
			}
			onLeftArrowClick();
		}

		// Token: 0x060390D7 RID: 233687 RVA: 0x00E75CE6 File Offset: 0x00E73EE6
		private void OnRightArrowClick()
		{
			CircleAttachView<FilterSetting, FilterSettingPixListItem> circleItem = this.CircleItem;
			if (circleItem != null)
			{
				circleItem.AttachToNextItem(1);
			}
			FilterSettingViewModel vmCache = this.VmCache;
			if (vmCache == null)
			{
				return;
			}
			Action onRightArrowClick = vmCache.OnRightArrowClick;
			if (onRightArrowClick == null)
			{
				return;
			}
			onRightArrowClick();
		}

		// Token: 0x060390D8 RID: 233688 RVA: 0x00E75D14 File Offset: 0x00E73F14
		private void OnHideClick(EToggleState state)
		{
			FilterSettingViewModel vmCache = this.VmCache;
			if (vmCache == null)
			{
				return;
			}
			Action onHideClick = vmCache.OnHideClick;
			if (onHideClick == null)
			{
				return;
			}
			onHideClick();
		}

		// Token: 0x060390D9 RID: 233689 RVA: 0x00E75D30 File Offset: 0x00E73F30
		private void OnCloseClick()
		{
			FilterSettingViewModel vmCache = this.VmCache;
			if (vmCache == null)
			{
				return;
			}
			Action onCloseClick = vmCache.OnCloseClick;
			if (onCloseClick == null)
			{
				return;
			}
			onCloseClick();
		}

		// Token: 0x060390DA RID: 233690 RVA: 0x00E75D4C File Offset: 0x00E73F4C
		private void OpenHelpView()
		{
			ControllerBase<HelpController>.Instance.OpenHelpById(323);
		}

		// Token: 0x060390DB RID: 233691 RVA: 0x00E75D5D File Offset: 0x00E73F5D
		private void OnColorPaletteToggleClick(EToggleState state)
		{
			this.RefreshOption(true);
		}

		// Token: 0x060390DC RID: 233692 RVA: 0x00E75D66 File Offset: 0x00E73F66
		private void OnSeniorParamToggleClick(EToggleState state)
		{
			this.RefreshOption(false);
		}

		// Token: 0x060390DD RID: 233693 RVA: 0x00E75D70 File Offset: 0x00E73F70
		private void RefreshOption(bool isColorPalette)
		{
			this.IsColorPalette = isColorPalette;
			UUIItem item = base.GetItem(18);
			if (item != null)
			{
				item.SetUIActive(isColorPalette);
			}
			UUIItem item2 = base.GetItem(23);
			if (item2 != null)
			{
				item2.SetUIActive(!isColorPalette);
			}
			UUIExtendToggle extendToggle = base.GetExtendToggle(21);
			if (extendToggle != null)
			{
				extendToggle.SetToggleStateForce(isColorPalette ? EToggleState.ETT_Checked : EToggleState.ETT_UnChecked, false, false, false);
			}
			UUIExtendToggle extendToggle2 = base.GetExtendToggle(22);
			if (extendToggle2 == null)
			{
				return;
			}
			extendToggle2.SetToggleStateForce((!isColorPalette) ? EToggleState.ETT_Checked : EToggleState.ETT_UnChecked, false, false, false);
		}

		// Token: 0x060390DE RID: 233694 RVA: 0x00E75DE8 File Offset: 0x00E73FE8
		[NullableContext(2)]
		private void OnDragMoved(ULGUIPointerEventData eventData)
		{
			FilterSettingViewModel vmCache = this.VmCache;
			if (vmCache == null)
			{
				return;
			}
			Action<ULGUIPointerEventData> onDragMoved = vmCache.OnDragMoved;
			if (onDragMoved == null)
			{
				return;
			}
			onDragMoved(eventData);
		}

		// Token: 0x060390DF RID: 233695 RVA: 0x00E75E05 File Offset: 0x00E74005
		private void OnDragBegin(ULGUIPointerEventData _)
		{
			FilterSettingViewModel vmCache = this.VmCache;
			if (vmCache == null)
			{
				return;
			}
			Action onDragBegin = vmCache.OnDragBegin;
			if (onDragBegin == null)
			{
				return;
			}
			onDragBegin();
		}

		// Token: 0x060390E0 RID: 233696 RVA: 0x00E75E21 File Offset: 0x00E74021
		private void OnDragEnded(ULGUIPointerEventData _)
		{
			FilterSettingViewModel vmCache = this.VmCache;
			if (vmCache == null)
			{
				return;
			}
			Action onDragEnded = vmCache.OnDragEnded;
			if (onDragEnded == null)
			{
				return;
			}
			onDragEnded();
		}

		// Token: 0x060390E1 RID: 233697 RVA: 0x00E75E40 File Offset: 0x00E74040
		private unsafe void OnInputUiMoveForward(string axisName, float value, InputIdentification _)
		{
			if (value > 0f)
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.Audio;
				ELogAuthor author = ELogAuthor.WZ;
				string message = "OnInputUiMoveForward";
				<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("axisName", axisName);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("value", value);
				instance.Info(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
			}
			if (!this.IsColorPalette)
			{
				return;
			}
			FilterSettingViewModel vmCache = this.VmCache;
			if (vmCache == null)
			{
				return;
			}
			Action<string, float> onInputUiMoveForward = vmCache.OnInputUiMoveForward;
			if (onInputUiMoveForward == null)
			{
				return;
			}
			onInputUiMoveForward(axisName, value);
		}

		// Token: 0x060390E2 RID: 233698 RVA: 0x00E75ED4 File Offset: 0x00E740D4
		private unsafe void OnInputUiMoveRight(string axisName, float value, InputIdentification _)
		{
			if (value > 0f)
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.Audio;
				ELogAuthor author = ELogAuthor.WZ;
				string message = "OnInputUiMoveRight";
				<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("axisName", axisName);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("value", value);
				instance.Info(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
			}
			if (!this.IsColorPalette)
			{
				return;
			}
			FilterSettingViewModel vmCache = this.VmCache;
			if (vmCache == null)
			{
				return;
			}
			Action<string, float> onInputUiMoveRight = vmCache.OnInputUiMoveRight;
			if (onInputUiMoveRight == null)
			{
				return;
			}
			onInputUiMoveRight(axisName, value);
		}

		// Token: 0x060390E3 RID: 233699 RVA: 0x00E75F66 File Offset: 0x00E74166
		private void OnInputUiLookUp(string axisName, float value, InputIdentification _)
		{
			FilterSettingViewModel vmCache = this.VmCache;
			if (vmCache == null)
			{
				return;
			}
			Action<string, float> onInputUiLookUp = vmCache.OnInputUiLookUp;
			if (onInputUiLookUp == null)
			{
				return;
			}
			onInputUiLookUp(axisName, value);
		}

		// Token: 0x060390E4 RID: 233700 RVA: 0x00E75F84 File Offset: 0x00E74184
		private void OnInputUiTurn(string axisName, float value, InputIdentification _)
		{
			FilterSettingViewModel vmCache = this.VmCache;
			if (vmCache == null)
			{
				return;
			}
			Action<string, float> onInputUiTurn = vmCache.OnInputUiTurn;
			if (onInputUiTurn == null)
			{
				return;
			}
			onInputUiTurn(axisName, value);
		}

		// Token: 0x060390E5 RID: 233701 RVA: 0x00E75FA4 File Offset: 0x00E741A4
		private FilterSettingPixListItem CreateCircleItem(AActor actor, int index, int showNum)
		{
			FilterSettingPixListItem filterSettingPixListItem = new FilterSettingPixListItem(actor);
			filterSettingPixListItem.ParentViewModel = this.VmCache;
			UCurveFloat[] curvesCache = this.CurvesCache;
			filterSettingPixListItem.OffsetCurve = ((curvesCache != null) ? curvesCache[0] : null);
			UCurveFloat[] curvesCache2 = this.CurvesCache;
			filterSettingPixListItem.ScaleCurve = ((curvesCache2 != null) ? curvesCache2[1] : null);
			UCurveFloat[] curvesCache3 = this.CurvesCache;
			filterSettingPixListItem.AlphaCurve = ((curvesCache3 != null) ? curvesCache3[2] : null);
			return filterSettingPixListItem;
		}

		// Token: 0x040207AC RID: 133036
		[Nullable(2)]
		public FilterSettingViewModel VmCache;

		// Token: 0x040207AD RID: 133037
		public bool IsColorPalette = true;

		// Token: 0x040207AE RID: 133038
		[Nullable(2)]
		private FilterSettingSliderItem SliderItem;

		// Token: 0x040207AF RID: 133039
		[Nullable(2)]
		private PopupCaptionItem CaptionItem;

		// Token: 0x040207B0 RID: 133040
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private CircleAttachView<FilterSetting, FilterSettingPixListItem> CircleItem;

		// Token: 0x040207B1 RID: 133041
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private GenericLayout<FilterSeniorParamSliderItem, FilterSeniorSetting> SeniorParamLayout;

		// Token: 0x040207B2 RID: 133042
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private LoadAsyncPromise<UCurveFloat> OffsetHandle;

		// Token: 0x040207B3 RID: 133043
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private LoadAsyncPromise<UCurveFloat> ScaleHandle;

		// Token: 0x040207B4 RID: 133044
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private LoadAsyncPromise<UCurveFloat> AlphaHandle;

		// Token: 0x040207B5 RID: 133045
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private UCurveFloat[] CurvesCache;

		// Token: 0x0200B82A RID: 47146
		[NullableContext(0)]
		public class EComponent
		{
			// Token: 0x04038F5E RID: 233310
			public const int FilterTexture = 0;

			// Token: 0x04038F5F RID: 233311
			public const int UpLeftItem = 1;

			// Token: 0x04038F60 RID: 233312
			public const int UpRightItem = 2;

			// Token: 0x04038F61 RID: 233313
			public const int DownLeftItem = 3;

			// Token: 0x04038F62 RID: 233314
			public const int DownRightItem = 4;

			// Token: 0x04038F63 RID: 233315
			public const int CoordinatesText = 5;

			// Token: 0x04038F64 RID: 233316
			public const int FilterNameText = 6;

			// Token: 0x04038F65 RID: 233317
			public const int PointSelectionTexture = 7;

			// Token: 0x04038F66 RID: 233318
			public const int SliderRootItem = 8;

			// Token: 0x04038F67 RID: 233319
			public const int ResetFilterParamButton = 9;

			// Token: 0x04038F68 RID: 233320
			public const int ApplyButton = 10;

			// Token: 0x04038F69 RID: 233321
			public const int MiddleTextureItem = 11;

			// Token: 0x04038F6A RID: 233322
			public const int RightArrowButton = 12;

			// Token: 0x04038F6B RID: 233323
			public const int LeftArrowButton = 13;

			// Token: 0x04038F6C RID: 233324
			public const int CaptionItem = 14;

			// Token: 0x04038F6D RID: 233325
			public const int HideToggle = 15;

			// Token: 0x04038F6E RID: 233326
			public const int DraggingHideRootItem = 16;

			// Token: 0x04038F6F RID: 233327
			public const int ScreenDrag = 17;

			// Token: 0x04038F70 RID: 233328
			public const int PointRootItem = 18;

			// Token: 0x04038F71 RID: 233329
			public const int PixListRootItem = 19;

			// Token: 0x04038F72 RID: 233330
			public const int LayoutTab = 20;

			// Token: 0x04038F73 RID: 233331
			public const int ToggleColorPalette = 21;

			// Token: 0x04038F74 RID: 233332
			public const int ToggleSeniorParam = 22;

			// Token: 0x04038F75 RID: 233333
			public const int ItemSeniorParamPanel = 23;

			// Token: 0x04038F76 RID: 233334
			public const int LayoutSeniorParam = 24;

			// Token: 0x04038F77 RID: 233335
			public const int ItemSeniorParamSlider = 25;

			// Token: 0x04038F78 RID: 233336
			public const int BtnDefaultFilter = 26;
		}
	}
}
