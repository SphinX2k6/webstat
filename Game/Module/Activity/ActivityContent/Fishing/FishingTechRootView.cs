using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using Aki.Protocol;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.Activity.ActivityContent.Fishing
{
	// Token: 0x02006833 RID: 26675
	[NullableContext(1)]
	[Nullable(0)]
	public class FishingTechRootView : UiViewBase
	{
		// Token: 0x0604280D RID: 272397 RVA: 0x01111C9B File Offset: 0x0110FE9B
		public FishingTechRootView(UiViewInfo info) : base(info)
		{
		}

		// Token: 0x0604280E RID: 272398 RVA: 0x01111CC4 File Offset: 0x0110FEC4
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
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(5, typeof(UUIItem));
			this.ComponentRegisterInfos = list;
		}

		// Token: 0x0604280F RID: 272399 RVA: 0x01111DB1 File Offset: 0x0110FFB1
		protected override void OnAddEventListener()
		{
			Singleton<EventSystem>.Instance.Add<IProto_NormalItem, int, int>(EEventName.OnCommonItemCountRefresh, new Action<IProto_NormalItem, int, int>(this.OnCommonItemCountRefresh));
			Singleton<EventSystem>.Instance.Add(EEventName.OnCommonItemCountAnyChange, new Action<int, int>(this.OnCommonItemCountAnyChange));
		}

		// Token: 0x06042810 RID: 272400 RVA: 0x01111DEB File Offset: 0x0110FFEB
		protected override void OnRemoveEventListener()
		{
			Singleton<EventSystem>.Instance.Remove(EEventName.OnCommonItemCountRefresh, new Action<IProto_NormalItem, int, int>(this.OnCommonItemCountRefresh));
			Singleton<EventSystem>.Instance.Remove(EEventName.OnCommonItemCountAnyChange, new Action<int, int>(this.OnCommonItemCountAnyChange));
		}

		// Token: 0x06042811 RID: 272401 RVA: 0x01111E28 File Offset: 0x01110028
		protected override UniTask OnBeforeStartAsync()
		{
			FishingTechRootView.<OnBeforeStartAsync>d__11 <OnBeforeStartAsync>d__;
			<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeStartAsync>d__.<>4__this = this;
			<OnBeforeStartAsync>d__.<>1__state = -1;
			<OnBeforeStartAsync>d__.<>t__builder.Start<FishingTechRootView.<OnBeforeStartAsync>d__11>(ref <OnBeforeStartAsync>d__);
			return <OnBeforeStartAsync>d__.<>t__builder.Task;
		}

		// Token: 0x06042812 RID: 272402 RVA: 0x01111E6B File Offset: 0x0111006B
		private void OnClickClose()
		{
			base.CloseMe(null);
		}

		// Token: 0x06042813 RID: 272403 RVA: 0x01111E74 File Offset: 0x01110074
		protected override void OnStart()
		{
			ControllerBase<RedDotController>.Instance.BindRedDot(ERedDotName.FishingNormalTech, base.GetItem(4), null, 0);
			ControllerBase<RedDotController>.Instance.BindRedDot(ERedDotName.FishingRoleTech, base.GetItem(5), null, 0);
			if (this.OpenParam == null)
			{
				this.TabItemList[0].SetToggleState(EToggleState.ETT_Checked, true);
				return;
			}
			IFishingTechOpenParam fishingTechOpenParam = this.OpenParam as IFishingTechOpenParam;
			int num = fishingTechOpenParam.Type - 1;
			if (num < 0 || num >= this.TabItemList.Count)
			{
				return;
			}
			FishingTechTabItem fishingTechTabItem = this.TabItemList[num];
			if (fishingTechTabItem != null)
			{
				fishingTechTabItem.SetToggleState(EToggleState.ETT_Checked, true);
			}
			this.CurrentTabIndex = num;
			UiDynamicTab data = this.TabDataList[this.CurrentTabIndex];
			EUiTabViewName viewName = (EUiTabViewName)data.ChildViewName;
			this.TabViewComponent.ToggleCallBack(data, viewName, this.TabItemList[this.CurrentTabIndex], fishingTechOpenParam.NodeId, null);
		}

		// Token: 0x06042814 RID: 272404 RVA: 0x01111F6A File Offset: 0x0111016A
		protected override void OnBeforeShow()
		{
			if (this.IsInit)
			{
				Singleton<EventSystem>.Instance.Emit(EEventName.FishingTechViewComeBack);
				this.RefreshRedDot();
			}
			this.IsInit = true;
		}

		// Token: 0x06042815 RID: 272405 RVA: 0x01111F91 File Offset: 0x01110191
		protected override void OnBeforeDestroy()
		{
			ControllerBase<RedDotController>.Instance.UnBindGivenUi(ERedDotName.FishingNormalTech, base.GetItem(4), 0);
			ControllerBase<RedDotController>.Instance.UnBindGivenUi(ERedDotName.FishingRoleTech, base.GetItem(5), 0);
		}

		// Token: 0x06042816 RID: 272406 RVA: 0x01111FC4 File Offset: 0x011101C4
		private UniTask InitTabComponent()
		{
			FishingTechRootView.<InitTabComponent>d__16 <InitTabComponent>d__;
			<InitTabComponent>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<InitTabComponent>d__.<>4__this = this;
			<InitTabComponent>d__.<>1__state = -1;
			<InitTabComponent>d__.<>t__builder.Start<FishingTechRootView.<InitTabComponent>d__16>(ref <InitTabComponent>d__);
			return <InitTabComponent>d__.<>t__builder.Task;
		}

		// Token: 0x06042817 RID: 272407 RVA: 0x01112008 File Offset: 0x01110208
		private UniTask InitTabItem(UUIItem uiItem)
		{
			FishingTechRootView.<InitTabItem>d__17 <InitTabItem>d__;
			<InitTabItem>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<InitTabItem>d__.<>4__this = this;
			<InitTabItem>d__.uiItem = uiItem;
			<InitTabItem>d__.<>1__state = -1;
			<InitTabItem>d__.<>t__builder.Start<FishingTechRootView.<InitTabItem>d__17>(ref <InitTabItem>d__);
			return <InitTabItem>d__.<>t__builder.Task;
		}

		// Token: 0x06042818 RID: 272408 RVA: 0x01112054 File Offset: 0x01110254
		private void ToggleCallback(int tabIndex)
		{
			int currentTabIndex = this.CurrentTabIndex;
			this.CurrentTabIndex = tabIndex;
			if (currentTabIndex != -1)
			{
				this.TabItemList[currentTabIndex].SetToggleState(EToggleState.ETT_UnChecked, true);
			}
			UiDynamicTab data = this.TabDataList[tabIndex];
			EUiTabViewName viewName = (EUiTabViewName)data.ChildViewName;
			this.TabViewComponent.ToggleCallBack(data, viewName, this.TabItemList[this.CurrentTabIndex], null, null);
		}

		// Token: 0x06042819 RID: 272409 RVA: 0x011120C8 File Offset: 0x011102C8
		private bool CanExecuteChange(int tabIndex, bool _)
		{
			return this.CurrentTabIndex != tabIndex;
		}

		// Token: 0x0604281A RID: 272410 RVA: 0x011120D6 File Offset: 0x011102D6
		private void OnCommonItemCountAnyChange(int normalItem, int count)
		{
			if (FishingDefine.fishingItemList.Contains(normalItem))
			{
				this.RefreshRedDot();
			}
		}

		// Token: 0x0604281B RID: 272411 RVA: 0x011120EB File Offset: 0x011102EB
		private void OnCommonItemCountRefresh(IProto_NormalItem normalItem, int count, int lastCount)
		{
			if (FishingDefine.fishingItemList.Contains(normalItem.Id))
			{
				this.RefreshRedDot();
			}
		}

		// Token: 0x0604281C RID: 272412 RVA: 0x01112108 File Offset: 0x01110308
		private void RefreshRedDot()
		{
			foreach (FishingTech fishingTech in ConfigBase<FishingConfig>.Instance.GetFishingTechList())
			{
				Singleton<EventSystem>.Instance.Emit<int>(EEventName.OnFishingTechNodeRedDotRefresh, fishingTech.Id);
			}
			Singleton<EventSystem>.Instance.Emit<EFishingTechNodeType>(EEventName.OnFishingRoleTechRefresh, EFishingTechNodeType.MainRole);
			Singleton<EventSystem>.Instance.Emit<EFishingTechNodeType>(EEventName.OnFishingRoleTechRefresh, EFishingTechNodeType.Phoebe);
		}

		// Token: 0x0402503B RID: 151611
		protected PopupCaptionItem CaptionItem;

		// Token: 0x0402503C RID: 151612
		protected TabViewComponent<UiDynamicTab> TabViewComponent;

		// Token: 0x0402503D RID: 151613
		protected List<FishingTechTabItem> TabItemList = new List<FishingTechTabItem>();

		// Token: 0x0402503E RID: 151614
		protected List<UiDynamicTab> TabDataList = new List<UiDynamicTab>();

		// Token: 0x0402503F RID: 151615
		protected int CurrentTabIndex = -1;

		// Token: 0x04025040 RID: 151616
		private bool IsInit;

		// Token: 0x0200C873 RID: 51315
		[NullableContext(0)]
		private class EComponentDefine
		{
			// Token: 0x0403DB25 RID: 252709
			public const int CaptionItem = 0;

			// Token: 0x0403DB26 RID: 252710
			public const int TabComponent = 1;

			// Token: 0x0403DB27 RID: 252711
			public const int TabAItem = 2;

			// Token: 0x0403DB28 RID: 252712
			public const int TabBItem = 3;

			// Token: 0x0403DB29 RID: 252713
			public const int TabARedDotItem = 4;

			// Token: 0x0403DB2A RID: 252714
			public const int TabBRedDotItem = 5;
		}
	}
}
