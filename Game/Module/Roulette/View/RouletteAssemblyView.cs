using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using CSharpScript.Core.Common;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.Common.MediumItemGrid;
using CSharpScript.Game.Module.FilterSort.Sort.SortEntrance;
using CSharpScript.Game.Module.Inventory;
using CSharpScript.Game.Module.Roulette.View.Components;
using CSharpScript.Game.Module.SkipInterface;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.NewWorld.Character.Common.Component.Explore;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.Roulette.View
{
	// Token: 0x02005018 RID: 20504
	[NullableContext(1)]
	[Nullable(0)]
	public class RouletteAssemblyView : UiTickViewBase
	{
		// Token: 0x17008ACE RID: 35534
		// (get) Token: 0x06034D6A RID: 216426 RVA: 0x00D43F5F File Offset: 0x00D4215F
		private RouletteComponentAssembly RouletteComponent
		{
			get
			{
				return this.ViewProxy.GetRouletteComponent();
			}
		}

		// Token: 0x06034D6B RID: 216427 RVA: 0x00D43F6C File Offset: 0x00D4216C
		public RouletteAssemblyView(UiViewInfo viewInfo) : base(viewInfo)
		{
		}

		// Token: 0x06034D6C RID: 216428 RVA: 0x00D43F84 File Offset: 0x00D42184
		protected unsafe override void OnRegisterComponent()
		{
			if (this.OpenParam == null)
			{
				Singleton<Log>.Instance.Error(ELogModule.Phantom, ELogAuthor.YYZ, "[Roulette] 装配界面打开时未获取到参数", default(ReadOnlySpan<ValueTuple<string, object>>));
			}
			else
			{
				this.ViewProxy = (RouletteAssemblyViewProxy)this.OpenParam;
			}
			this.ViewProxy.RegisterView(this);
			int num = 17;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIExtendToggle));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIExtendToggle));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(5, typeof(UUILoopScrollViewComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(6, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(7, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(8, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(9, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(10, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(11, typeof(UUIExtendToggle));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(12, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(13, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(14, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(15, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(16, typeof(UUIItem));
			this.ComponentRegisterInfos = list;
			num2 = 3;
			List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
			CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
			Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
			num = 0;
			*span2[num] = new ValueTuple<int, Delegate>(3, new Action<EToggleState>(this.OnToggleLeftClicked));
			num++;
			*span2[num] = new ValueTuple<int, Delegate>(4, new Action<EToggleState>(this.OnToggleRightClicked));
			num++;
			*span2[num] = new ValueTuple<int, Delegate>(11, new Action<EToggleState>(this.OnToggleConfigClicked));
			this.BtnBindInfo = list2;
		}

		// Token: 0x06034D6D RID: 216429 RVA: 0x00D442B0 File Offset: 0x00D424B0
		protected override void OnAddEventListener()
		{
			Singleton<EventSystem>.Instance.Add<EInputControllerMainType, EInputControllerMainType>(EEventName.InputControllerMainTypeChange, new Action<EInputControllerMainType, EInputControllerMainType>(this.InputControllerMainTypeChange));
			Singleton<EventSystem>.Instance.Add<RouletteData>(EEventName.OnRouletteItemSelect, new Action<RouletteData>(this.OnRouletteButtonClicked));
			Singleton<EventSystem>.Instance.Add(EEventName.OnRouletteSaveDataChange, new Action(this.OnSaveDataChange));
			Singleton<EventSystem>.Instance.Add(EEventName.OnRouletteItemUnlock, new Action(this.OnButtonSwitch));
			Singleton<EventSystem>.Instance.Add(EEventName.RouletteNavigationComponentEmit, new Action(this.OnRouletteNavigationComponentEmit));
		}

		// Token: 0x06034D6E RID: 216430 RVA: 0x00D4434C File Offset: 0x00D4254C
		protected override void OnRemoveEventListener()
		{
			Singleton<EventSystem>.Instance.Remove(EEventName.InputControllerMainTypeChange, new Action<EInputControllerMainType, EInputControllerMainType>(this.InputControllerMainTypeChange));
			Singleton<EventSystem>.Instance.Remove(EEventName.OnRouletteItemSelect, new Action<RouletteData>(this.OnRouletteButtonClicked));
			Singleton<EventSystem>.Instance.Remove(EEventName.OnRouletteSaveDataChange, new Action(this.OnSaveDataChange));
			Singleton<EventSystem>.Instance.Remove(EEventName.OnRouletteItemUnlock, new Action(this.OnButtonSwitch));
			Singleton<EventSystem>.Instance.Remove(EEventName.RouletteNavigationComponentEmit, new Action(this.OnRouletteNavigationComponentEmit));
		}

		// Token: 0x06034D6F RID: 216431 RVA: 0x00D443E8 File Offset: 0x00D425E8
		protected override UniTask OnBeforeStartAsync()
		{
			RouletteAssemblyView.<OnBeforeStartAsync>d__23 <OnBeforeStartAsync>d__;
			<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeStartAsync>d__.<>4__this = this;
			<OnBeforeStartAsync>d__.<>1__state = -1;
			<OnBeforeStartAsync>d__.<>t__builder.Start<RouletteAssemblyView.<OnBeforeStartAsync>d__23>(ref <OnBeforeStartAsync>d__);
			return <OnBeforeStartAsync>d__.<>t__builder.Task;
		}

		// Token: 0x06034D70 RID: 216432 RVA: 0x00D4442B File Offset: 0x00D4262B
		protected override void OnStart()
		{
			this.InitRouletteInputManager();
			this.ViewProxy.Start();
		}

		// Token: 0x06034D71 RID: 216433 RVA: 0x00D44440 File Offset: 0x00D42640
		protected override void OnBeforeDestroy()
		{
			this.SetExploreSkill();
			ModelBase<RouletteModel>.Instance.SaveNewItemList();
			if (this.InputManager != null)
			{
				this.InputManager.Destroy();
				this.InputManager = null;
			}
			if (this.AssemblyGridScrollView != null)
			{
				this.AssemblyGridScrollView.ClearGridProxies();
				this.AssemblyGridScrollView = null;
			}
			this.CurrentSelectOnGridData = null;
			this.AssemblyTips.Destroy(null);
			this.ButtonSwitch.Destroy(null);
			this.CaptionItem.Destroy(null);
			this.SortEntrance.Destroy(null);
			this.ToggleLeft = null;
			this.ToggleRight = null;
			this.ViewProxy.Destroy();
		}

		// Token: 0x06034D72 RID: 216434 RVA: 0x00D444E4 File Offset: 0x00D426E4
		protected override void OnBeforeShow()
		{
			if (this.IsFirstShow)
			{
				this.TabItem.SelectTab((int)this.ViewProxy.CurrentRouletteType);
				this.IsFirstShow = false;
			}
			else
			{
				this.RefreshScrollView(true);
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.Phantom;
				ELogAuthor author = ELogAuthor.TZJ;
				string message = "刷新滑动列表2";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("this.ViewProxy.AssemblyGridDataMap", this.ViewProxy.AssemblyGridDataMap);
				instance.Info(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			}
			this.ViewProxy.BeforeShow();
			RouletteAssemblyTips assemblyTips = this.AssemblyTips;
			if (assemblyTips != null)
			{
				assemblyTips.RefreshPhantomInteractEquipmentPanel();
			}
			ButtonItem buttonPhantomEdit = this.ButtonPhantomEdit;
			if (buttonPhantomEdit == null)
			{
				return;
			}
			buttonPhantomEdit.BindRedDot(ERedDotName.RedDotPhantomInteractEditEntry, 0);
		}

		// Token: 0x06034D73 RID: 216435 RVA: 0x00D44582 File Offset: 0x00D42782
		protected override void OnAfterHide()
		{
			ButtonItem buttonPhantomEdit = this.ButtonPhantomEdit;
			if (buttonPhantomEdit == null)
			{
				return;
			}
			buttonPhantomEdit.UnBindGivenUid(0);
		}

		// Token: 0x06034D74 RID: 216436 RVA: 0x00D44598 File Offset: 0x00D42798
		protected override void OnTick(float delta)
		{
			ValueTuple<int?, int?> valueTuple = this.InputManager.Tick(delta);
			int? item = valueTuple.Item1;
			int? item2 = valueTuple.Item2;
			this.RouletteComponent.Refresh(item, item2);
		}

		// Token: 0x06034D75 RID: 216437 RVA: 0x00D445CB File Offset: 0x00D427CB
		private void OnRouletteTypeSwitch(int typeId)
		{
			this.ViewProxy.OnRouletteTypeSwitch((ERouletteType)typeId);
			this.RefreshTypeSwitch();
		}

		// Token: 0x06034D76 RID: 216438 RVA: 0x00D445E0 File Offset: 0x00D427E0
		private void RefreshTypeSwitch()
		{
			this.SetRouletteInputType();
			this.SetRoulettePlatformType();
			this.SetRouletteType();
			this.RouletteComponent.SetAllGridToggleSelfInteractive(true);
			this.RouletteComponent.AddAllGridToggleCanExecuteChangeEvent(new Func<RouletteData, EToggleState, bool>(this.OnCanRouletteToggleExecuteChange));
			this.AssemblyState = EAssemblyState.RouletteGridChoose;
			this.UpdateButtonEnable();
			this.SelectDefaultRouletteGrid();
		}

		// Token: 0x17008ACF RID: 35535
		// (get) Token: 0x06034D77 RID: 216439 RVA: 0x00D44635 File Offset: 0x00D42835
		// (set) Token: 0x06034D78 RID: 216440 RVA: 0x00D44640 File Offset: 0x00D42840
		private EAssemblyState AssemblyState
		{
			get
			{
				return this.ViewAssemblyState;
			}
			set
			{
				this.ViewAssemblyState = value;
				if (value == EAssemblyState.RouletteGridChoose)
				{
					this.RouletteComponent.SetTipsActive(true);
					if (Singleton<Info>.Instance.IsInTouch())
					{
						this.RouletteComponent.RefreshTipsByText("Text_ExploreToolsChooseMobile_Text", false);
						this.RouletteComponent.SetNameVisible(false);
						this.RouletteComponent.SetRingVisible(false);
					}
					else if (Singleton<Info>.Instance.IsInGamepad())
					{
						this.RouletteComponent.RefreshTipsByText("Text_ExploreToolsChoosePC_Text", false);
						this.RouletteComponent.SetRingVisible(true);
					}
					else if (Singleton<Info>.Instance.IsInKeyBoard())
					{
						this.RouletteComponent.RefreshTipsByText("Text_ExploreToolsChoosePC_Text", false);
						this.RouletteComponent.SetRingVisible(false);
					}
					this.InputManager.ActivateInput(true);
					return;
				}
				if (value != EAssemblyState.ScrollViewChoose)
				{
					return;
				}
				this.RouletteComponent.SetTipsActive(false);
				this.RouletteComponent.SetRingVisible(false);
				if (Singleton<Info>.Instance.IsInTouch())
				{
					this.RouletteComponent.SetNameVisible(true);
				}
				this.InputManager.ActivateInput(false);
				this.RefreshTabToggle();
				this.RefreshScrollView(false);
				this.RefreshSwitchButton();
			}
		}

		// Token: 0x06034D79 RID: 216441 RVA: 0x00D44754 File Offset: 0x00D42954
		[return: Nullable(new byte[]
		{
			2,
			1
		})]
		public override UUIItem[] GetGuideUiItemAndUiItemForShowEx(string[] configParams)
		{
			int num;
			if (configParams.Length != 1 || !int.TryParse(configParams[0], out num))
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.Guide;
				ELogAuthor author = ELogAuthor.JT;
				string message = "聚焦引导extraParam项配置有误";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("configParams", configParams);
				instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
				return null;
			}
			int num2 = int.Parse(configParams[0]);
			LoopScrollView<RouletteAssemblyGridItem, AssemblyGridData> assemblyGridScrollView = this.AssemblyGridScrollView;
			UUIItem uuiitem;
			if (assemblyGridScrollView == null)
			{
				uuiitem = null;
			}
			else
			{
				uuiitem = assemblyGridScrollView.GetGridAndScrollToByJudge(num2, (object itemIdObj, AssemblyGridData data) => (int)itemIdObj == data.Id, true);
			}
			UUIItem uuiitem2 = uuiitem;
			if (uuiitem2 != null)
			{
				return new UUIItem[]
				{
					uuiitem2,
					uuiitem2
				};
			}
			return null;
		}

		// Token: 0x06034D7A RID: 216442 RVA: 0x00D447F1 File Offset: 0x00D429F1
		private void SetRouletteType()
		{
			this.RouletteComponent.RefreshRouletteType();
		}

		// Token: 0x06034D7B RID: 216443 RVA: 0x00D447FE File Offset: 0x00D429FE
		private void SetRoulettePlatformType()
		{
			this.RouletteComponent.RefreshRoulettePlatformType();
		}

		// Token: 0x06034D7C RID: 216444 RVA: 0x00D4480C File Offset: 0x00D42A0C
		private void SetRouletteInputType()
		{
			this.RouletteComponent.RefreshRouletteInputType();
			bool flag = Singleton<Info>.Instance.IsInGamepad();
			base.GetItem(12).SetUIActive(flag);
			if (!flag)
			{
				return;
			}
			EToggleState state = (ModelBase<RouletteModel>.Instance.GetRouletteSelectConfig() == 1) ? EToggleState.ETT_Checked : EToggleState.ETT_UnChecked;
			base.GetExtendToggle(11).SetToggleState(state, false, false, false);
			UUIText text = base.GetText(13);
			Singleton<LguiUtil>.Instance.SetLocalTextNew(text, "Text_ExploreToolsClose_Text", Array.Empty<object>());
		}

		// Token: 0x06034D7D RID: 216445 RVA: 0x00D44883 File Offset: 0x00D42A83
		private void SwitchInputType()
		{
			this.SetRouletteInputType();
			this.InitRouletteInputManager();
			this.AssemblyState = EAssemblyState.RouletteGridChoose;
			this.SelectDefaultRouletteGrid();
		}

		// Token: 0x06034D7E RID: 216446 RVA: 0x00D448A0 File Offset: 0x00D42AA0
		private void OnButtonSwitch()
		{
			EAssemblyState assemblyState = (this.AssemblyState == EAssemblyState.RouletteGridChoose) ? EAssemblyState.ScrollViewChoose : EAssemblyState.RouletteGridChoose;
			this.AssemblyState = assemblyState;
		}

		// Token: 0x06034D7F RID: 216447 RVA: 0x00D448C4 File Offset: 0x00D42AC4
		private void InputControllerMainTypeChange(EInputControllerMainType eInputControllerMainType, EInputControllerMainType inputControllerMainType)
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.Phantom;
			ELogAuthor author = ELogAuthor.YYZ;
			string message = "检测到输入设备变化,切换装配界面表现";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("新输入类型", Singleton<Info>.Instance.InputControllerType);
			instance.Info(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			this.SwitchInputType();
		}

		// Token: 0x06034D80 RID: 216448 RVA: 0x00D4490C File Offset: 0x00D42B0C
		private void InitRouletteInputManager()
		{
			RouletteInputBase inputManager = this.InputManager;
			if (inputManager != null)
			{
				inputManager.Destroy();
			}
			this.InputManager = null;
			FVector lguispaceAbsolutePosition = base.GetItem(1).GetLGUISpaceAbsolutePosition();
			Vector2D beginPos = AngleCalculator.ConvertLguiPosToScreenPos((double)lguispaceAbsolutePosition.X, (double)lguispaceAbsolutePosition.Y);
			float? floatConfig = ConfigCommonParamById.GetFloatConfig("Roulette_Assembly_Gamepad_DeadLimit");
			this.InputManager = RouletteInputManager.CreateInput(Singleton<Info>.Instance.InputControllerMainType, beginPos, new ERouletteViewType?(ERouletteViewType.Assembly), null, floatConfig);
			this.InputManager.BindEvent();
			this.InputManager.OnInit();
			this.InputManager.SetIsNeedEmpty(true);
		}

		// Token: 0x06034D81 RID: 216449 RVA: 0x00D449A8 File Offset: 0x00D42BA8
		private void SelectDefaultRouletteGrid()
		{
			this.RouletteComponent.Reset();
			RouletteGridBase rouletteGridBase = null;
			if (this.ViewProxy.OpenParam.SelectGridId != null)
			{
				rouletteGridBase = this.RouletteComponent.GetGridByValidId(this.ViewProxy.OpenParam.SelectGridId.Value);
			}
			if (rouletteGridBase == null)
			{
				int valueOrDefault = this.ViewProxy.OpenParam.SelectGridIndex.GetValueOrDefault();
				rouletteGridBase = this.RouletteComponent.GetGridByIndex(valueOrDefault);
			}
			rouletteGridBase.SetGridToggleState(true, false);
			rouletteGridBase.SetGridEquipped(true);
			this.OnRouletteButtonClicked(rouletteGridBase.Data);
			if (Singleton<Info>.Instance.IsInGamepad())
			{
				this.AssemblyState = EAssemblyState.RouletteGridChoose;
				return;
			}
			this.AssemblyState = EAssemblyState.ScrollViewChoose;
		}

		// Token: 0x06034D82 RID: 216450 RVA: 0x00D44A60 File Offset: 0x00D42C60
		private void OnRouletteButtonClicked(RouletteData data)
		{
			RouletteData currentSelectOnGridData = this.CurrentSelectOnGridData;
			int? num = (currentSelectOnGridData != null) ? new int?(currentSelectOnGridData.GridIndex) : null;
			this.CurrentSelectOnGridData = data;
			if (num != null)
			{
				int? num2 = num;
				int gridIndex = this.CurrentSelectOnGridData.GridIndex;
				if (!(num2.GetValueOrDefault() == gridIndex & num2 != null))
				{
					RouletteGridBase gridByIndex = this.RouletteComponent.GetGridByIndex(num.Value);
					if (gridByIndex != null)
					{
						gridByIndex.SetGridToggleState(false, true);
					}
				}
			}
			this.RouletteComponent.SetCurrentGridByData(data);
			this.AssemblyState = EAssemblyState.ScrollViewChoose;
		}

		// Token: 0x06034D83 RID: 216451 RVA: 0x00D44AF4 File Offset: 0x00D42CF4
		private bool OnCanRouletteToggleExecuteChange(RouletteData itemData, EToggleState state)
		{
			if (this.CurrentSelectOnGridData != null && state == EToggleState.ETT_Checked)
			{
				bool flag = this.CurrentSelectOnGridData.GridIndex == itemData.GridIndex;
				if (Singleton<Info>.Instance.IsInGamepad() && flag)
				{
					this.OnButtonSwitch();
				}
				return !flag;
			}
			return true;
		}

		// Token: 0x06034D84 RID: 216452 RVA: 0x00D44B3B File Offset: 0x00D42D3B
		private void InitScrollView()
		{
			this.AssemblyGridScrollView = new LoopScrollView<RouletteAssemblyGridItem, AssemblyGridData>(base.GetLoopScrollViewComponent(5), (AUIBaseActor)base.GetItem(6).GetOwner(), new Func<RouletteAssemblyGridItem>(this.OnGridProxyCreate), false);
		}

		// Token: 0x06034D85 RID: 216453 RVA: 0x00D44B70 File Offset: 0x00D42D70
		private int GetGridRelativeIndex(AssemblyGridData gridData)
		{
			RouletteGridBase gridByValidId = this.RouletteComponent.GetGridByValidId(gridData.Id);
			if (gridByValidId != null)
			{
				return gridByValidId.Data.GridIndex + 1;
			}
			return 0;
		}

		// Token: 0x06034D86 RID: 216454 RVA: 0x00D44BA4 File Offset: 0x00D42DA4
		private void RefreshScrollView(bool keepSelect = false)
		{
			if (this.CurrentSelectOnGridData == null)
			{
				Singleton<Log>.Instance.Info(ELogModule.Phantom, ELogAuthor.YYZ, "未收到选中轮盘格子数据,无法刷新", default(ReadOnlySpan<ValueTuple<string, object>>));
				return;
			}
			ERouletteGridType gridType = this.CurrentSelectOnGridData.GridType;
			List<AssemblyGridData> list2;
			List<AssemblyGridData> list = this.ViewProxy.AssemblyGridDataMap.TryGetValue(gridType, out list2) ? list2 : new List<AssemblyGridData>();
			List<AssemblyGridData> list3 = new List<AssemblyGridData>();
			for (int i = 0; i < list.Count; i++)
			{
				AssemblyGridData assemblyGridData = list[i];
				if (gridType != ERouletteGridType.EquipItem || (list[i] as AssemblyEquipItemGridData).ItemType == this.EquipItemType)
				{
					assemblyGridData.State = this.JudgeAssemblyGridState(list[i], this.CurrentSelectOnGridData);
					assemblyGridData.RelativeIndex = this.GetGridRelativeIndex(list[i]);
					list3.Add(assemblyGridData);
				}
			}
			this.TempKeepSelect = keepSelect;
			this.RefreshItemFilterSort(30, list3);
		}

		// Token: 0x06034D87 RID: 216455 RVA: 0x00D44C8C File Offset: 0x00D42E8C
		private void RefreshScrollViewByData(int selectGridIndex, List<AssemblyGridData> newDataList)
		{
			this.CurrentSelectOnAssemblyData = null;
			this.AssemblyGridScrollView.DeselectCurrentGridProxy(false);
			base.GetLoopScrollViewComponent(5).RootUIComp.Get().SetUIActive(newDataList.Count > 0);
			base.GetItem(9).SetUIActive(newDataList.Count <= 0);
			if (newDataList.Count > 0)
			{
				this.AssemblyGridScrollView.ReloadData(newDataList, false);
				this.AssemblyGridScrollView.ScrollToGridIndex(selectGridIndex, true);
				this.AssemblyGridScrollView.SelectGridProxy(selectGridIndex, true);
				this.SelectAssemblyGridIndex = selectGridIndex;
				return;
			}
			this.SelectAssemblyGridIndex = -1;
			if (Singleton<Info>.Instance.IsInGamepad())
			{
				this.AssemblyState = EAssemblyState.RouletteGridChoose;
			}
			this.AssemblyTips.SetActive(false);
			this.RefreshSwitchButton();
			ButtonItem buttonPhantomEdit = this.ButtonPhantomEdit;
			if (buttonPhantomEdit == null)
			{
				return;
			}
			buttonPhantomEdit.SetUiActive(false);
		}

		// Token: 0x06034D88 RID: 216456 RVA: 0x00D44D5C File Offset: 0x00D42F5C
		private void OnRouletteNavigationComponentEmit()
		{
			if (!this.AssemblyGridScrollView.IsGridDisplaying(this.SelectAssemblyGridIndex))
			{
				return;
			}
			RouletteAssemblyGridItem rouletteAssemblyGridItem = this.AssemblyGridScrollView.UnsafeGetGridProxy(this.SelectAssemblyGridIndex, false);
			UUIItem uuiitem = (rouletteAssemblyGridItem != null) ? rouletteAssemblyGridItem.GetRootItem() : null;
			if (uuiitem != null)
			{
				ControllerBase<UiNavigationNewController>.Instance.SetNavigationFocusForView(uuiitem, true, true, true);
			}
		}

		// Token: 0x06034D89 RID: 216457 RVA: 0x00D44DB0 File Offset: 0x00D42FB0
		private EAssemblyGridState JudgeAssemblyGridState(AssemblyGridData assemblyData, RouletteData rouletteData)
		{
			EAssemblyGridState result = EAssemblyGridState.UnEquip;
			List<int> list = new List<int>();
			if (rouletteData.GridType == ERouletteGridType.EquipItem)
			{
				list.Add(this.ViewProxy.CurrentRouletteListSaveData.ExtraItemId);
			}
			else
			{
				list = this.ViewProxy.CurrentRouletteListSaveData.RouletteIdList;
			}
			if (list.Contains(assemblyData.Id))
			{
				result = EAssemblyGridState.Equipped;
			}
			if (assemblyData.Id == rouletteData.Id)
			{
				result = EAssemblyGridState.CurrentChoose;
			}
			return result;
		}

		// Token: 0x06034D8A RID: 216458 RVA: 0x00D44E18 File Offset: 0x00D43018
		private RouletteAssemblyGridItem OnGridProxyCreate()
		{
			RouletteAssemblyGridItem rouletteAssemblyGridItem = new RouletteAssemblyGridItem();
			rouletteAssemblyGridItem.BindOnExtendToggleStateChanged(new Action<MediumItemGridExtendCallback>(this.GridToggleFunction));
			return rouletteAssemblyGridItem;
		}

		// Token: 0x06034D8B RID: 216459 RVA: 0x00D44E34 File Offset: 0x00D43034
		private void GridToggleFunction(MediumItemGridExtendCallback callbackParameter)
		{
			int state = (int)callbackParameter.State;
			AssemblyGridData assemblyGridData = (AssemblyGridData)callbackParameter.Data;
			RouletteAssemblyGridItem rouletteAssemblyGridItem = (RouletteAssemblyGridItem)callbackParameter.MediumItemGrid;
			if (state == 1)
			{
				int selectedGridIndex = this.AssemblyGridScrollView.GetSelectedGridIndex();
				this.CurrentSelectOnAssemblyData = assemblyGridData;
				this.AssemblyGridScrollView.DeselectCurrentGridProxy(false);
				this.AssemblyGridScrollView.SelectGridProxy(assemblyGridData.Index, false);
				this.AssemblyGridScrollView.RefreshGridProxy(selectedGridIndex);
				this.RefreshSwitchButton();
				this.RefreshTips();
				if (ModelBase<RouletteModel>.Instance.TryRemoveNewItem(this.CurrentSelectOnAssemblyData.Id))
				{
					this.AssemblyGridScrollView.RefreshGridProxy(rouletteAssemblyGridItem.GridIndex);
				}
			}
		}

		// Token: 0x06034D8C RID: 216460 RVA: 0x00D44ED4 File Offset: 0x00D430D4
		private void RefreshSwitchButton()
		{
			base.GetItem(14).SetUIActive(false);
			if (this.CurrentSelectOnAssemblyData != null)
			{
				if (this.CurrentSelectOnAssemblyData.GridType == ERouletteGridType.Explore)
				{
					ExploreTools? exploreConfigById = ConfigBase<RouletteConfig>.Instance.GetExploreConfigById(this.CurrentSelectOnAssemblyData.Id);
					if (exploreConfigById == null)
					{
						return;
					}
					if (!ControllerBase<RouletteController>.Instance.CheckCanExploreSkillEquip(this.CurrentSelectOnAssemblyData.Id) || !exploreConfigById.Value.AssemblyEquipButton)
					{
						this.ButtonSwitch.SetActive(false);
						base.GetItem(14).SetUIActive(true);
						return;
					}
				}
				string showText = null;
				switch (this.CurrentSelectOnAssemblyData.State)
				{
				case EAssemblyGridState.UnEquip:
					showText = "Text_PhantomPutOn_Text";
					break;
				case EAssemblyGridState.Equipped:
					showText = "Text_PhantomReplace_Text";
					break;
				case EAssemblyGridState.CurrentChoose:
					showText = "Text_PhantomTakeOff_Text";
					break;
				}
				this.ButtonSwitch.SetShowText(showText);
				this.ButtonSwitch.SetActive(true);
				return;
			}
			this.ButtonSwitch.SetActive(false);
			ButtonItem buttonPhantomEdit = this.ButtonPhantomEdit;
			if (buttonPhantomEdit == null)
			{
				return;
			}
			buttonPhantomEdit.SetUiActive(false);
		}

		// Token: 0x06034D8D RID: 216461 RVA: 0x00D44FD8 File Offset: 0x00D431D8
		private void SelectedItem(int _)
		{
			AssemblyGridData currentSelectOnAssemblyData = this.CurrentSelectOnAssemblyData;
			RouletteData rouletteData = this.CurrentSelectOnGridData.DeepCopy();
			bool keepSelect = currentSelectOnAssemblyData.State == EAssemblyGridState.CurrentChoose;
			switch (currentSelectOnAssemblyData.State)
			{
			case EAssemblyGridState.UnEquip:
				rouletteData.Id = currentSelectOnAssemblyData.Id;
				rouletteData.State = EGridBehavior.Normal;
				if (currentSelectOnAssemblyData.GridType == ERouletteGridType.Explore)
				{
					int id = this.CurrentSelectOnGridData.Id;
					if (id != 0)
					{
						ModelBase<RouletteModel>.Instance.SendExploreToolEquipLogData(id, 0, (int)this.ViewProxy.CurrentRouletteType, null);
					}
					ModelBase<RouletteModel>.Instance.SendExploreToolEquipLogData(currentSelectOnAssemblyData.Id, 1, (int)this.ViewProxy.CurrentRouletteType, null);
				}
				else if (currentSelectOnAssemblyData.GridType == ERouletteGridType.EquipItem)
				{
					int id2 = this.CurrentSelectOnGridData.Id;
					if (id2 != 0)
					{
						ModelBase<RouletteModel>.Instance.SendExploreToolEquipLogData(3001, 0, (int)this.ViewProxy.CurrentRouletteType, new int?(id2));
					}
					ModelBase<RouletteModel>.Instance.SendExploreToolEquipLogData(3001, 1, (int)this.ViewProxy.CurrentRouletteType, new int?(currentSelectOnAssemblyData.Id));
				}
				break;
			case EAssemblyGridState.Equipped:
			{
				rouletteData.Id = currentSelectOnAssemblyData.Id;
				rouletteData.State = EGridBehavior.Normal;
				RouletteGridBase gridByValidId = this.RouletteComponent.GetGridByValidId(currentSelectOnAssemblyData.Id);
				RouletteData data = gridByValidId.Data;
				data.Id = this.CurrentSelectOnGridData.Id;
				if (this.CurrentSelectOnGridData.Id == 0)
				{
					data.State = EGridBehavior.CanAdd;
					data.Name = null;
				}
				else
				{
					data.State = EGridBehavior.Normal;
				}
				gridByValidId.RefreshGrid(data);
				int dataIndex = data.DataIndex;
				this.SaveTempDataMap(dataIndex, data);
				break;
			}
			case EAssemblyGridState.CurrentChoose:
				rouletteData.Id = 0;
				rouletteData.Name = null;
				rouletteData.State = EGridBehavior.CanAdd;
				if (currentSelectOnAssemblyData.GridType == ERouletteGridType.Explore)
				{
					ModelBase<RouletteModel>.Instance.SendExploreToolEquipLogData(currentSelectOnAssemblyData.Id, 0, (int)this.ViewProxy.CurrentRouletteType, null);
				}
				else if (currentSelectOnAssemblyData.GridType == ERouletteGridType.EquipItem)
				{
					ModelBase<RouletteModel>.Instance.SendExploreToolEquipLogData(3001, 0, (int)this.ViewProxy.CurrentRouletteType, new int?(currentSelectOnAssemblyData.Id));
				}
				break;
			}
			this.RouletteComponent.RefreshCurrentGridData(rouletteData);
			int dataIndex2 = this.CurrentSelectOnGridData.DataIndex;
			this.SaveTempDataMap(dataIndex2, rouletteData);
			this.CurrentSelectOnGridData = rouletteData;
			this.RefreshScrollView(keepSelect);
			this.RefreshSwitchButton();
			this.SaveTempData();
		}

		// Token: 0x06034D8E RID: 216462 RVA: 0x00D4523C File Offset: 0x00D4343C
		private void SaveTempDataMap(int dataIndex, RouletteData newData)
		{
			if (newData.GridType == ERouletteGridType.EquipItem)
			{
				this.ViewProxy.CurrentRouletteListSaveData.ExtraItemId = newData.Id;
				return;
			}
			List<int> rouletteIdList = this.ViewProxy.CurrentRouletteListSaveData.RouletteIdList;
			if (0 <= dataIndex && dataIndex < rouletteIdList.Count)
			{
				rouletteIdList[dataIndex] = newData.Id;
			}
		}

		// Token: 0x06034D8F RID: 216463 RVA: 0x00D45294 File Offset: 0x00D43494
		protected void RefreshItemFilterSort(int useWayId, List<AssemblyGridData> itemDataList)
		{
			this.SortEntrance.UpdateData((EFilterSortGroupId)useWayId, itemDataList, Array.Empty<object>());
			this.SortEntrance.SetActive(false);
		}

		// Token: 0x06034D90 RID: 216464 RVA: 0x00D452B4 File Offset: 0x00D434B4
		private void OnItemFilterSortRefresh(List<AssemblyGridData> list, bool isOutSideChange, EFilterSortType sortType)
		{
			int selectGridIndex = 0;
			if (this.TempKeepSelect)
			{
				selectGridIndex = this.AssemblyGridScrollView.GetSelectedGridIndex();
				this.TempKeepSelect = false;
			}
			else
			{
				for (int i = 0; i < list.Count; i++)
				{
					if (list[i].State == EAssemblyGridState.CurrentChoose)
					{
						selectGridIndex = i;
					}
				}
			}
			int? openParamSelectId = this.ViewProxy.OpenParam.SelectGridId;
			if (openParamSelectId != null)
			{
				int num = list.FindIndex((AssemblyGridData item) => item.Id == openParamSelectId.Value);
				if (num != -1)
				{
					selectGridIndex = num;
				}
			}
			this.RefreshScrollViewByData(selectGridIndex, list);
		}

		// Token: 0x06034D91 RID: 216465 RVA: 0x00D45354 File Offset: 0x00D43554
		public void RefreshTips()
		{
			ERouletteGridType gridType = this.CurrentSelectOnAssemblyData.GridType;
			AssemblyTipsData assemblyTipsData = null;
			switch (gridType)
			{
			case ERouletteGridType.Explore:
				this.AssemblyTips.SetActive(true);
				assemblyTipsData = this.CreateExploreSkillTipsData(this.CurrentSelectOnAssemblyData);
				break;
			case ERouletteGridType.Function:
			{
				this.AssemblyTips.SetActive(false);
				ButtonItem buttonPhantomEdit = this.ButtonPhantomEdit;
				if (buttonPhantomEdit == null)
				{
					return;
				}
				buttonPhantomEdit.SetUiActive(false);
				return;
			}
			case ERouletteGridType.EquipItem:
				this.AssemblyTips.SetActive(true);
				assemblyTipsData = this.CreateEquipItemTipsData(this.CurrentSelectOnAssemblyData);
				break;
			}
			this.AssemblyTips.Refresh(assemblyTipsData);
			ButtonItem buttonPhantomEdit2 = this.ButtonPhantomEdit;
			if (buttonPhantomEdit2 == null)
			{
				return;
			}
			buttonPhantomEdit2.SetUiActive(assemblyTipsData.ShowPhantomInteractEquipment);
		}

		// Token: 0x06034D92 RID: 216466 RVA: 0x00D453F8 File Offset: 0x00D435F8
		private AssemblyTipsData CreateExploreSkillTipsData(AssemblyGridData gridData)
		{
			AssemblyTipsData assemblyTipsData = new AssemblyTipsData();
			ExploreTools value = ConfigBase<RouletteConfig>.Instance.GetExploreConfigById(gridData.Id).Value;
			assemblyTipsData.GridType = ERouletteGridType.Explore;
			assemblyTipsData.GridId = gridData.Id;
			assemblyTipsData.TextMain = value.CurrentSkillInfo;
			assemblyTipsData.IsIconTexture = false;
			assemblyTipsData.IconPath = value.BackGround;
			assemblyTipsData.HelpId = value.HelpId;
			assemblyTipsData.Title = gridData.Name;
			assemblyTipsData.CanSetItemNum = ModelBase<RouletteModel>.Instance.GetExploreSkillShowSetNumById((ERouletteExploreId)gridData.Id);
			assemblyTipsData.NeedItemMap = value.Cost();
			assemblyTipsData.ShowPhantomInteractEquipment = ModelBase<PhantomInteractModel>.Instance.CheckIsPhantomInteractExploreTool(gridData.Id);
			HashSet<int> hashSet = new HashSet<int>();
			foreach (KeyValuePair<int, int> keyValuePair in value.Authorization())
			{
				hashSet.Add(keyValuePair.Value);
			}
			assemblyTipsData.Authorization = new List<int>(hashSet);
			return assemblyTipsData;
		}

		// Token: 0x06034D93 RID: 216467 RVA: 0x00D45510 File Offset: 0x00D43710
		private AssemblyTipsData CreateEquipItemTipsData(AssemblyGridData gridData)
		{
			AssemblyTipsData assemblyTipsData = new AssemblyTipsData();
			ItemInfo value = ConfigBase<InventoryConfig>.Instance.GetItemConfig(gridData.Id).Value;
			assemblyTipsData.GridType = ERouletteGridType.EquipItem;
			assemblyTipsData.GridId = gridData.Id;
			assemblyTipsData.BgQuality = (InventoryDefine.EQuality)value.QualityId;
			assemblyTipsData.Title = gridData.Name;
			assemblyTipsData.TextMain = value.AttributesDescription;
			assemblyTipsData.TextSub = value.BgDescription;
			if (value.ItemAccessLength > 0)
			{
				int[] itemAccessArray = value.GetItemAccessArray();
				for (int i = 0; i < itemAccessArray.Length; i++)
				{
					int getWayId = itemAccessArray[i];
					AccessPath? configById = ConfigBase<GetWayConfig>.Instance.GetConfigById(getWayId);
					if (configById != null)
					{
						GetWayItemData item = new GetWayItemData(getWayId, (EGetWayItemType)configById.Value.Type, configById.Value.Description, configById.Value.SortIndex, delegate()
						{
							SkipTaskManager.RunByConfigId(getWayId, gridData.Id);
						});
						assemblyTipsData.GetWayData.Add(item);
					}
				}
			}
			return assemblyTipsData;
		}

		// Token: 0x06034D94 RID: 216468 RVA: 0x00D45660 File Offset: 0x00D43860
		private void RefreshTabToggle()
		{
			if (this.CurrentSelectOnGridData == null)
			{
				Singleton<Log>.Instance.Info(ELogModule.Phantom, ELogAuthor.YYZ, "未收到选中轮盘格子数据,无法刷新", default(ReadOnlySpan<ValueTuple<string, object>>));
				return;
			}
			bool flag = this.CurrentSelectOnGridData.GridType == ERouletteGridType.EquipItem;
			base.GetItem(2).SetUIActive(flag);
			if (flag)
			{
				InventoryDefine.EItemType eitemType = this.EquipItemType;
				int id = this.CurrentSelectOnGridData.Id;
				if (id != 0)
				{
					eitemType = (ControllerBase<SpecialItemController>.Instance.IsSpecialItem(id) ? InventoryDefine.EItemType.SpecialItem : InventoryDefine.EItemType.Common);
					this.EquipItemType = eitemType;
				}
				if (eitemType == InventoryDefine.EItemType.Common)
				{
					this.ToggleLeft.SetToggleState(EToggleState.ETT_Checked, false, false, false);
					return;
				}
				this.ToggleRight.SetToggleState(EToggleState.ETT_Checked, false, false, false);
			}
		}

		// Token: 0x06034D95 RID: 216469 RVA: 0x00D45706 File Offset: 0x00D43906
		private bool CanTabToggleChanged(EToggleState state, InventoryDefine.EItemType type)
		{
			return state == EToggleState.ETT_UnChecked || this.EquipItemType != type;
		}

		// Token: 0x06034D96 RID: 216470 RVA: 0x00D45719 File Offset: 0x00D43919
		private void OnToggleLeftClicked(EToggleState state)
		{
			this.OnToggleClicked(InventoryDefine.EItemType.Common, state);
		}

		// Token: 0x06034D97 RID: 216471 RVA: 0x00D45723 File Offset: 0x00D43923
		private void OnToggleRightClicked(EToggleState state)
		{
			this.OnToggleClicked(InventoryDefine.EItemType.SpecialItem, state);
		}

		// Token: 0x06034D98 RID: 216472 RVA: 0x00D4572E File Offset: 0x00D4392E
		private void OnToggleClicked(InventoryDefine.EItemType newItemType, EToggleState state)
		{
			if (state != EToggleState.ETT_Checked)
			{
				return;
			}
			if (this.EquipItemType == newItemType)
			{
				return;
			}
			this.EquipItemType = newItemType;
			((this.EquipItemType == InventoryDefine.EItemType.Common) ? this.ToggleRight : this.ToggleLeft).SetToggleState(EToggleState.ETT_UnChecked, false, false, false);
			this.RefreshScrollView(false);
		}

		// Token: 0x06034D99 RID: 216473 RVA: 0x00D4576E File Offset: 0x00D4396E
		private void OnSaveDataChange()
		{
			this.UpdateButtonEnable();
		}

		// Token: 0x06034D9A RID: 216474 RVA: 0x00D45776 File Offset: 0x00D43976
		private void UpdateButtonEnable()
		{
			this.RefreshSwitchButton();
		}

		// Token: 0x06034D9B RID: 216475 RVA: 0x00D45780 File Offset: 0x00D43980
		private void SetExploreSkill()
		{
			ERouletteExploreId? endSwitchSkillId = this.ViewProxy.OpenParam.EndSwitchSkillId;
			if (endSwitchSkillId == null)
			{
				return;
			}
			ModelBase<CharacterExploreModel>.Instance.SetExploreSkillId((int)endSwitchSkillId.Value, EExploreSkillLayer.Roulette, "RouletteAssemblyView.SetExploreSkill");
			ControllerBase<RouletteController>.Instance.ExploreSkillSetRequest((int)endSwitchSkillId.Value, null, false);
		}

		// Token: 0x06034D9C RID: 216476 RVA: 0x00D457D4 File Offset: 0x00D439D4
		private void SaveTempData()
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.Phantom;
			ELogAuthor author = ELogAuthor.YYZ;
			string message = "保存当前轮盘数据";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("Type", this.ViewProxy.CurrentRouletteType);
			instance.Info(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			ControllerBase<RouletteController>.Instance.SaveRouletteDataRequest(this.ViewProxy.CurrentRouletteListSaveData, delegate(bool success)
			{
				if (!success)
				{
					this.OnRouletteTypeSwitch((int)this.ViewProxy.CurrentRouletteType);
				}
			});
		}

		// Token: 0x06034D9D RID: 216477 RVA: 0x00D45838 File Offset: 0x00D43A38
		private void OnToggleConfigClicked(EToggleState state)
		{
			int config = (state == EToggleState.ETT_Checked) ? 1 : 0;
			ModelBase<RouletteModel>.Instance.SaveRouletteSelectConfig(config);
		}

		// Token: 0x06034D9E RID: 216478 RVA: 0x00D45855 File Offset: 0x00D43A55
		private void OnPhantomEditClicked(int _)
		{
			ControllerBase<PhantomInteractController>.Instance.OpenPhantomVisionEditView(0, false);
		}

		// Token: 0x0401E75F RID: 124767
		private RouletteAssemblyViewProxy ViewProxy;

		// Token: 0x0401E760 RID: 124768
		[Nullable(2)]
		private RouletteInputBase InputManager;

		// Token: 0x0401E761 RID: 124769
		[Nullable(new byte[]
		{
			2,
			1,
			1
		})]
		private LoopScrollView<RouletteAssemblyGridItem, AssemblyGridData> AssemblyGridScrollView;

		// Token: 0x0401E762 RID: 124770
		private InventoryDefine.EItemType EquipItemType = InventoryDefine.EItemType.Common;

		// Token: 0x0401E763 RID: 124771
		[Nullable(2)]
		protected UUIExtendToggle ToggleLeft;

		// Token: 0x0401E764 RID: 124772
		[Nullable(2)]
		protected UUIExtendToggle ToggleRight;

		// Token: 0x0401E765 RID: 124773
		[Nullable(2)]
		private RouletteData CurrentSelectOnGridData;

		// Token: 0x0401E766 RID: 124774
		[Nullable(2)]
		private AssemblyGridData CurrentSelectOnAssemblyData;

		// Token: 0x0401E767 RID: 124775
		private EAssemblyState ViewAssemblyState;

		// Token: 0x0401E768 RID: 124776
		[Nullable(2)]
		private ButtonItem ButtonSwitch;

		// Token: 0x0401E769 RID: 124777
		[Nullable(2)]
		private PopupCaptionItem CaptionItem;

		// Token: 0x0401E76A RID: 124778
		[Nullable(2)]
		private RouletteAssemblyTips AssemblyTips;

		// Token: 0x0401E76B RID: 124779
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private SortEntrance<AssemblyGridData> SortEntrance;

		// Token: 0x0401E76C RID: 124780
		private bool IsFirstShow = true;

		// Token: 0x0401E76D RID: 124781
		[Nullable(2)]
		private RouletteAssemblyTabItem TabItem;

		// Token: 0x0401E76E RID: 124782
		[Nullable(2)]
		public UUIItem RouletteUiItem;

		// Token: 0x0401E76F RID: 124783
		[Nullable(2)]
		private ButtonItem ButtonPhantomEdit;

		// Token: 0x0401E770 RID: 124784
		protected int SelectAssemblyGridIndex;

		// Token: 0x0401E771 RID: 124785
		protected bool TempKeepSelect;
	}
}
