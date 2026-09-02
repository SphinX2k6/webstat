using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.Menu.SubViews.EyeProtect
{
	// Token: 0x020057B0 RID: 22448
	[NullableContext(1)]
	[Nullable(0)]
	public class EyeProtectView : UiViewBase
	{
		// Token: 0x06039127 RID: 233767 RVA: 0x00E76DE8 File Offset: 0x00E74FE8
		public EyeProtectView(UiViewInfo viewInfo) : base(viewInfo)
		{
		}

		// Token: 0x06039128 RID: 233768 RVA: 0x00E76DFC File Offset: 0x00E74FFC
		protected override void OnRegisterComponent()
		{
			this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
			{
				new ValueTuple<int, Type>(0, typeof(UUIItem)),
				new ValueTuple<int, Type>(1, typeof(UUIVerticalLayout)),
				new ValueTuple<int, Type>(2, typeof(UUIItem)),
				new ValueTuple<int, Type>(3, typeof(UUIItem)),
				new ValueTuple<int, Type>(4, typeof(UUIItem)),
				new ValueTuple<int, Type>(5, typeof(UUIExtendToggle)),
				new ValueTuple<int, Type>(6, typeof(UUIItem)),
				new ValueTuple<int, Type>(7, typeof(UUIDraggableComponent)),
				new ValueTuple<int, Type>(8, typeof(UUIItem))
			};
		}

		// Token: 0x06039129 RID: 233769 RVA: 0x00E76EDA File Offset: 0x00E750DA
		protected override void OnBeforeCreate()
		{
			this.VmCache = (this.OpenParam as EyeProtectViewModel);
			this.VmCache.OnSliderValueChange = new Action(this.RefreshApplyBtn);
		}

		// Token: 0x0603912A RID: 233770 RVA: 0x00E76F04 File Offset: 0x00E75104
		protected override UniTask OnBeforeStartAsync()
		{
			EyeProtectView.<OnBeforeStartAsync>d__10 <OnBeforeStartAsync>d__;
			<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeStartAsync>d__.<>4__this = this;
			<OnBeforeStartAsync>d__.<>1__state = -1;
			<OnBeforeStartAsync>d__.<>t__builder.Start<EyeProtectView.<OnBeforeStartAsync>d__10>(ref <OnBeforeStartAsync>d__);
			return <OnBeforeStartAsync>d__.<>t__builder.Task;
		}

		// Token: 0x0603912B RID: 233771 RVA: 0x00E76F47 File Offset: 0x00E75147
		protected override void OnBeforeShow()
		{
			Singleton<UiTimeDilation>.Instance.AddWaitSetTimeDilationTag(this.ViewInfo.Name);
		}

		// Token: 0x0603912C RID: 233772 RVA: 0x00E76F63 File Offset: 0x00E75163
		protected override void OnBeforeHide()
		{
			Singleton<UiTimeDilation>.Instance.DeleteWaitSetTimeDilationTag(this.ViewInfo.Name);
		}

		// Token: 0x0603912D RID: 233773 RVA: 0x00E76F80 File Offset: 0x00E75180
		protected override void OnBeforeDestroy()
		{
			Singleton<UiLayer>.Instance.SetLayerActive(ELayerType.HUD, true);
			EyeProtectViewModel vmCache = this.VmCache;
			if (vmCache != null)
			{
				FilterCameraComponent filterCameraComponent = vmCache.FilterCameraComponent;
				if (filterCameraComponent != null)
				{
					filterCameraComponent.ClosePhotograph();
				}
			}
			base.GetExtendToggle(5).OnStateChange.Remove(new Action<EToggleState>(this.OnEyeToggleStateChange));
			ControllerBase<EyeProtectController>.Instance.SwitchFilter(true);
			ControllerBase<EyeProtectController>.Instance.ApplyEyeProtectSetting();
		}

		// Token: 0x0603912E RID: 233774 RVA: 0x00E76FE8 File Offset: 0x00E751E8
		protected override void OnStart()
		{
			if (this.VmCache == null)
			{
				return;
			}
			this.LayoutItems = new GenericLayout<EyeProtectItem, EyeProtectItemData>(base.GetVerticalLayout(1), new Func<EyeProtectItem>(this.CreateEyeProtectItem), null, false, true);
			this.ItemDataList = this.VmCache.GetModeDataList();
			this.LayoutItems.RefreshByData(this.ItemDataList, null, false);
			this.SelectTagByIndex(this.VmCache.ModeCurValue.GetValueOrDefault());
		}

		// Token: 0x0603912F RID: 233775 RVA: 0x00E7705C File Offset: 0x00E7525C
		protected override void OnAddEventListener()
		{
			UUIDraggableComponent draggable = base.GetDraggable(7);
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
			ControllerBase<InputDistributeController>.Instance.BindAxis("UiLookUp", new TInputHandle<float>(this.OnInputUiLookUp));
			ControllerBase<InputDistributeController>.Instance.BindAxis("UiTurn", new TInputHandle<float>(this.OnInputUiTurn));
		}

		// Token: 0x06039130 RID: 233776 RVA: 0x00E77138 File Offset: 0x00E75338
		protected override void OnRemoveEventListener()
		{
			UUIDraggableComponent draggable = base.GetDraggable(7);
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
			ControllerBase<InputDistributeController>.Instance.UnBindAxis("UiLookUp", new TInputHandle<float>(this.OnInputUiLookUp));
			ControllerBase<InputDistributeController>.Instance.UnBindAxis("UiTurn", new TInputHandle<float>(this.OnInputUiTurn));
		}

		// Token: 0x06039131 RID: 233777 RVA: 0x00E771E7 File Offset: 0x00E753E7
		private EyeProtectItem CreateEyeProtectItem()
		{
			return new EyeProtectItem
			{
				SelectCallback = new Action<int>(this.SelectTagByIndex),
				CanExecuteChange = new Func<int, bool>(this.CanToggleChange)
			};
		}

		// Token: 0x06039132 RID: 233778 RVA: 0x00E77214 File Offset: 0x00E75414
		private void SelectTagByIndex(int gridIndex)
		{
			EyeProtectItemData eyeProtectItemData = this.ItemDataList[gridIndex];
			if (eyeProtectItemData == null)
			{
				return;
			}
			GenericLayout<EyeProtectItem, EyeProtectItemData> layoutItems = this.LayoutItems;
			if (layoutItems != null)
			{
				layoutItems.SelectGridProxy(gridIndex, false);
			}
			EyeProtectViewModel vmCache = this.VmCache;
			if (vmCache != null)
			{
				vmCache.OnModeValueChange(eyeProtectItemData.GetModeValue());
			}
			this.RefreshApplyBtn();
			if (eyeProtectItemData.GetModeValue() == 2)
			{
				base.GetItem(3).SetUIActive(true);
				return;
			}
			base.GetItem(3).SetUIActive(false);
		}

		// Token: 0x06039133 RID: 233779 RVA: 0x00E77288 File Offset: 0x00E75488
		private bool CanToggleChange(int gridIndex)
		{
			GenericLayout<EyeProtectItem, EyeProtectItemData> layoutItems = this.LayoutItems;
			int? num = (layoutItems != null) ? new int?(layoutItems.GetSelectedGridIndex()) : null;
			return !(gridIndex == num.GetValueOrDefault() & num != null);
		}

		// Token: 0x06039134 RID: 233780 RVA: 0x00E772CA File Offset: 0x00E754CA
		private void OnResetClick(int _)
		{
			this.HandleResetClick();
		}

		// Token: 0x06039135 RID: 233781 RVA: 0x00E772D4 File Offset: 0x00E754D4
		private void HandleResetClick()
		{
			EyeProtectViewModel vmCache = this.VmCache;
			if (vmCache == null || vmCache.ModeCurValue.GetValueOrDefault() != 2)
			{
				ControllerBase<ScrollingTipsController>.Instance.ShowTipsByTextId("EyeProtectMode_Tips_ResetFail", Array.Empty<object>());
				return;
			}
			EyeProtectItem eyeProtectItem = null;
			List<EyeProtectSliderData> sliderDataList = this.VmCache.GetSliderDataList(EModeValue.Custom);
			if (sliderDataList != null)
			{
				foreach (EyeProtectSliderData eyeProtectSliderData in sliderDataList)
				{
					eyeProtectSliderData.OnChangeValue(eyeProtectSliderData.DefaultCurValue);
				}
				if (this.LayoutItems != null)
				{
					foreach (EyeProtectItem eyeProtectItem2 in this.LayoutItems.GetLayoutItemList())
					{
						EyeProtectItemData data = eyeProtectItem2.Data;
						if (data != null && data.GetModeValue() == 2)
						{
							eyeProtectItem = eyeProtectItem2;
							break;
						}
					}
					if (eyeProtectItem != null)
					{
						GenericScrollViewNew<EyeProtectSliderItem, EyeProtectSliderData> scrollView = eyeProtectItem.ScrollView;
						if (scrollView != null)
						{
							scrollView.RefreshByData(sliderDataList, null, false);
						}
						ControllerBase<ScrollingTipsController>.Instance.ShowTipsByTextId("EyeProtectMode_Tips_ResetSuccess", Array.Empty<object>());
					}
				}
			}
		}

		// Token: 0x06039136 RID: 233782 RVA: 0x00E77408 File Offset: 0x00E75608
		private void OnConfirmClick(int _)
		{
			this.HandleConfirmClick();
		}

		// Token: 0x06039137 RID: 233783 RVA: 0x00E77410 File Offset: 0x00E75610
		private void HandleConfirmClick()
		{
			EyeProtectViewModel vmCache = this.VmCache;
			if (vmCache != null && vmCache.IsDirty)
			{
				EyeProtectViewModel vmCache2 = this.VmCache;
				if (vmCache2 != null)
				{
					vmCache2.OnModeValueApply();
				}
				if (this.LayoutItems != null)
				{
					foreach (EyeProtectItem eyeProtectItem in this.LayoutItems.GetLayoutItemList())
					{
						eyeProtectItem.OnApply(this.VmCache.ModeCurValue.Value);
					}
				}
				List<EyeProtectSliderData> sliderDataList = this.VmCache.GetSliderDataList(EModeValue.Custom);
				if (sliderDataList != null)
				{
					foreach (EyeProtectSliderData eyeProtectSliderData in sliderDataList)
					{
						eyeProtectSliderData.OnApplyValue();
					}
					this.VmCache.IsSliderDirty = false;
				}
				ModelBase<MenuModel>.Instance.IsEdited = true;
			}
			ControllerBase<ScrollingTipsController>.Instance.ShowTipsByTextId("EyeProtectMode_Tips_ApplySuccess", Array.Empty<object>());
			this.RefreshApplyBtn();
		}

		// Token: 0x06039138 RID: 233784 RVA: 0x00E77528 File Offset: 0x00E75728
		private void OnEyeToggleStateChange(EToggleState state)
		{
			base.GetItem(6).SetUIActive(state == EToggleState.ETT_Checked);
			base.GetItem(8).SetUIActive(state == EToggleState.ETT_Checked);
		}

		// Token: 0x06039139 RID: 233785 RVA: 0x00E7754C File Offset: 0x00E7574C
		private void OnCloseClick()
		{
			EyeProtectViewModel vmCache = this.VmCache;
			if (vmCache != null && vmCache.IsDirty)
			{
				ConfirmBoxDataNew confirmBoxDataNew = new ConfirmBoxDataNew(EConfirmBoxConfigId.EyeProtectModeExit);
				confirmBoxDataNew.FunctionMap.Add(2, new Action(this.CloseMySelf));
				ControllerBase<ConfirmBoxController>.Instance.ShowConfirmBoxNew(confirmBoxDataNew);
				return;
			}
			this.CloseMySelf();
		}

		// Token: 0x0603913A RID: 233786 RVA: 0x00E775A3 File Offset: 0x00E757A3
		public void CloseMySelf()
		{
			ControllerBase<FilterSettingController>.Instance.CloseViewAndReturnWorld();
		}

		// Token: 0x0603913B RID: 233787 RVA: 0x00E775B0 File Offset: 0x00E757B0
		private void OpenHelpView()
		{
			ControllerBase<HelpController>.Instance.OpenHelpById(390);
		}

		// Token: 0x0603913C RID: 233788 RVA: 0x00E775C4 File Offset: 0x00E757C4
		private void RefreshApplyBtn()
		{
			EyeProtectViewModel vmCache = this.VmCache;
			bool? flag = (vmCache != null) ? new bool?(vmCache.IsDirty) : null;
			ButtonItem confirmBtnItem = this.ConfirmBtnItem;
			if (confirmBtnItem == null)
			{
				return;
			}
			confirmBtnItem.SetEnableClick(flag.GetValueOrDefault());
		}

		// Token: 0x0603913D RID: 233789 RVA: 0x00E77608 File Offset: 0x00E75808
		[NullableContext(2)]
		private void OnDragMoved(ULGUIPointerEventData eventData)
		{
			EyeProtectViewModel vmCache = this.VmCache;
			if (vmCache == null)
			{
				return;
			}
			vmCache.OnDragMoved(eventData);
		}

		// Token: 0x0603913E RID: 233790 RVA: 0x00E7761B File Offset: 0x00E7581B
		private void OnDragBegin(ULGUIPointerEventData _)
		{
			EyeProtectViewModel vmCache = this.VmCache;
			if (vmCache == null)
			{
				return;
			}
			vmCache.OnDragBegin();
		}

		// Token: 0x0603913F RID: 233791 RVA: 0x00E7762D File Offset: 0x00E7582D
		private void OnDragEnded(ULGUIPointerEventData _)
		{
			EyeProtectViewModel vmCache = this.VmCache;
			if (vmCache == null)
			{
				return;
			}
			vmCache.OnDragEnded();
		}

		// Token: 0x06039140 RID: 233792 RVA: 0x00E7763F File Offset: 0x00E7583F
		private void OnInputUiLookUp(string axisName, float value, InputIdentification _)
		{
			EyeProtectViewModel vmCache = this.VmCache;
			if (vmCache == null)
			{
				return;
			}
			vmCache.OnInputUiLookUp(axisName, value);
		}

		// Token: 0x06039141 RID: 233793 RVA: 0x00E77653 File Offset: 0x00E75853
		private void OnInputUiTurn(string axisName, float value, InputIdentification _)
		{
			EyeProtectViewModel vmCache = this.VmCache;
			if (vmCache == null)
			{
				return;
			}
			vmCache.OnInputUiTurn(axisName, value);
		}

		// Token: 0x040207D6 RID: 133078
		[Nullable(2)]
		public EyeProtectViewModel VmCache;

		// Token: 0x040207D7 RID: 133079
		[Nullable(2)]
		private PopupCaptionItem CaptionItem;

		// Token: 0x040207D8 RID: 133080
		[Nullable(new byte[]
		{
			2,
			1,
			1
		})]
		private GenericLayout<EyeProtectItem, EyeProtectItemData> LayoutItems;

		// Token: 0x040207D9 RID: 133081
		private List<EyeProtectItemData> ItemDataList = new List<EyeProtectItemData>();

		// Token: 0x040207DA RID: 133082
		[Nullable(2)]
		private ButtonItem ResetBtnItem;

		// Token: 0x040207DB RID: 133083
		[Nullable(2)]
		private ButtonItem ConfirmBtnItem;

		// Token: 0x0200B834 RID: 47156
		[NullableContext(0)]
		public class EComponent
		{
			// Token: 0x04038FA1 RID: 233377
			public const int CaptionItem = 0;

			// Token: 0x04038FA2 RID: 233378
			public const int Layout = 1;

			// Token: 0x04038FA3 RID: 233379
			public const int Item = 2;

			// Token: 0x04038FA4 RID: 233380
			public const int BtnReset = 3;

			// Token: 0x04038FA5 RID: 233381
			public const int BtnConfirm = 4;

			// Token: 0x04038FA6 RID: 233382
			public const int TogEye = 5;

			// Token: 0x04038FA7 RID: 233383
			public const int Parent = 6;

			// Token: 0x04038FA8 RID: 233384
			public const int ScreenDrag = 7;

			// Token: 0x04038FA9 RID: 233385
			public const int TexMask = 8;
		}
	}
}
