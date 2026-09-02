using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.Activity.ActivityContent.Roverlike
{
	// Token: 0x020063E2 RID: 25570
	[NullableContext(1)]
	[Nullable(0)]
	public class RoverlikeHandBookView : UiViewBase
	{
		// Token: 0x17009DC2 RID: 40386
		// (get) Token: 0x06040360 RID: 263008 RVA: 0x01074E95 File Offset: 0x01073095
		[Nullable(2)]
		private RoverlikeActivityData ActivityData
		{
			[NullableContext(2)]
			get
			{
				RoverlikeActivityController instance = ControllerBase<RoverlikeActivityController>.Instance;
				if (instance == null)
				{
					return null;
				}
				return instance.GetCurrentActivityData();
			}
		}

		// Token: 0x06040361 RID: 263009 RVA: 0x01074EA7 File Offset: 0x010730A7
		public RoverlikeHandBookView(UiViewInfo info) : base(info)
		{
		}

		// Token: 0x06040362 RID: 263010 RVA: 0x01074EBC File Offset: 0x010730BC
		protected unsafe override void OnRegisterComponent()
		{
			int num = 2;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIItem));
			this.ComponentRegisterInfos = list;
		}

		// Token: 0x06040363 RID: 263011 RVA: 0x01074F25 File Offset: 0x01073125
		protected override void OnAddEventListener()
		{
			Singleton<EventSystem>.Instance.Add<int>(EEventName.RefreshCommonActivityRedDot, new Action<int>(this.OnRefreshCommonActivityRedDot));
		}

		// Token: 0x06040364 RID: 263012 RVA: 0x01074F44 File Offset: 0x01073144
		protected override UniTask OnBeforeStartAsync()
		{
			RoverlikeHandBookView.<OnBeforeStartAsync>d__10 <OnBeforeStartAsync>d__;
			<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeStartAsync>d__.<>4__this = this;
			<OnBeforeStartAsync>d__.<>1__state = -1;
			<OnBeforeStartAsync>d__.<>t__builder.Start<RoverlikeHandBookView.<OnBeforeStartAsync>d__10>(ref <OnBeforeStartAsync>d__);
			return <OnBeforeStartAsync>d__.<>t__builder.Task;
		}

		// Token: 0x06040365 RID: 263013 RVA: 0x01074F87 File Offset: 0x01073187
		protected override void OnRemoveEventListener()
		{
			Singleton<EventSystem>.Instance.Remove<int>(EEventName.RefreshCommonActivityRedDot, new Action<int>(this.OnRefreshCommonActivityRedDot));
		}

		// Token: 0x06040366 RID: 263014 RVA: 0x01074FA5 File Offset: 0x010731A5
		protected override void OnBeforeDestroy()
		{
		}

		// Token: 0x06040367 RID: 263015 RVA: 0x01074FA8 File Offset: 0x010731A8
		private void InitTabComponent()
		{
			CommonTabComponentData<RoverlikeTabItem> data = new CommonTabComponentData<RoverlikeTabItem>(new Func<UUIItem, int?, RoverlikeTabItem>(this.ProxyCreate), new Action<int>(this.ToggleCallBack), new Func<int, CommonTabData>(this.GetCommonData));
			this.TabComponent = new TabComponentWithCaptionItem<RoverlikeTabItem>(base.GetItem(0), data, new Action(this.OnCloseClicked), false);
			this.TabComponent.SetHelpButtonShowState(false);
			this.TabViewComponent = new TabViewComponent<UiDynamicTab>(base.GetItem(1), EKeyMode.Default);
		}

		// Token: 0x06040368 RID: 263016 RVA: 0x01075020 File Offset: 0x01073220
		private UniTask RefreshTabListAsync()
		{
			RoverlikeHandBookView.<RefreshTabListAsync>d__14 <RefreshTabListAsync>d__;
			<RefreshTabListAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<RefreshTabListAsync>d__.<>4__this = this;
			<RefreshTabListAsync>d__.<>1__state = -1;
			<RefreshTabListAsync>d__.<>t__builder.Start<RoverlikeHandBookView.<RefreshTabListAsync>d__14>(ref <RefreshTabListAsync>d__);
			return <RefreshTabListAsync>d__.<>t__builder.Task;
		}

		// Token: 0x06040369 RID: 263017 RVA: 0x01075063 File Offset: 0x01073263
		private RoverlikeTabItem ProxyCreate([Nullable(2)] UUIItem uiItem, int? index)
		{
			return new RoverlikeTabItem();
		}

		// Token: 0x0604036A RID: 263018 RVA: 0x0107506C File Offset: 0x0107326C
		private CommonTabData GetCommonData(int index)
		{
			UiDynamicTab uiDynamicTab = this.TabDataList[index];
			return new CommonTabData(uiDynamicTab.Icon, new CommonTabTitleData(uiDynamicTab.TabName, Array.Empty<object>()), null);
		}

		// Token: 0x0604036B RID: 263019 RVA: 0x010750A4 File Offset: 0x010732A4
		private void ToggleCallBack(int index)
		{
			UiDynamicTab data = this.TabDataList[index];
			EUiTabViewName euiTabViewName = (EUiTabViewName)data.ChildViewName;
			RoverlikeTabItem tabItemByIndex = this.TabComponent.GetTabItemByIndex(index);
			this.TabViewComponent.ToggleCallBack(data, euiTabViewName, tabItemByIndex, null, null);
			this.CurSelectTabView = new EUiTabViewName?(euiTabViewName);
		}

		// Token: 0x0604036C RID: 263020 RVA: 0x010750FC File Offset: 0x010732FC
		private void OnRefreshCommonActivityRedDot(int activityId)
		{
			RoverlikeActivityData activityData = this.ActivityData;
			if (activityId != ((activityData != null) ? activityData.Id : 0) || this.ActivityData == null)
			{
				return;
			}
			this.RefreshAllTabRedDot();
		}

		// Token: 0x0604036D RID: 263021 RVA: 0x01075124 File Offset: 0x01073324
		private void RefreshAllTabRedDot()
		{
			for (int i = 0; i < this.TabDataList.Count; i++)
			{
				RoverlikeTabItem tabItemByIndex = this.TabComponent.GetTabItemByIndex(i);
				if (tabItemByIndex != null)
				{
					tabItemByIndex.SetRedDotState(this.TabHasRedDot((EUiTabViewName)this.TabDataList[i].ChildViewName));
				}
			}
		}

		// Token: 0x0604036E RID: 263022 RVA: 0x01075180 File Offset: 0x01073380
		private bool TabHasRedDot(EUiTabViewName viewName)
		{
			RoverlikeActivityData activityData = this.ActivityData;
			return activityData != null && viewName == EUiTabViewName.RoverlikeOutsideBlessTabView && activityData.GetNewUnlockedBlessIds().Count > 0;
		}

		// Token: 0x0604036F RID: 263023 RVA: 0x010751B6 File Offset: 0x010733B6
		private void OnCloseClicked()
		{
			base.CloseMe(null);
		}

		// Token: 0x04024023 RID: 147491
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private TabComponentWithCaptionItem<RoverlikeTabItem> TabComponent;

		// Token: 0x04024024 RID: 147492
		[Nullable(2)]
		private TabViewComponent<UiDynamicTab> TabViewComponent;

		// Token: 0x04024025 RID: 147493
		private List<UiDynamicTab> TabDataList = new List<UiDynamicTab>();

		// Token: 0x04024026 RID: 147494
		private EUiTabViewName? CurSelectTabView;

		// Token: 0x0200C44A RID: 50250
		[NullableContext(0)]
		private enum EComponents
		{
			// Token: 0x0403C6CF RID: 247503
			CaptionItem,
			// Token: 0x0403C6D0 RID: 247504
			Content
		}
	}
}
