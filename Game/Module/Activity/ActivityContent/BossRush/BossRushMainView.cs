using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.InstanceDungeon;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.Activity.ActivityContent.BossRush
{
	// Token: 0x020069C7 RID: 27079
	[NullableContext(1)]
	[Nullable(0)]
	public class BossRushMainView : UiViewBase
	{
		// Token: 0x06043218 RID: 274968 RVA: 0x0113EFFE File Offset: 0x0113D1FE
		public BossRushMainView(UiViewInfo viewInfo) : base(viewInfo)
		{
		}

		// Token: 0x06043219 RID: 274969 RVA: 0x0113F014 File Offset: 0x0113D214
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

		// Token: 0x0604321A RID: 274970 RVA: 0x0113F080 File Offset: 0x0113D280
		protected override UniTask OnBeforeStartAsync()
		{
			BossRushMainView.<OnBeforeStartAsync>d__7 <OnBeforeStartAsync>d__;
			<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeStartAsync>d__.<>4__this = this;
			<OnBeforeStartAsync>d__.<>1__state = -1;
			<OnBeforeStartAsync>d__.<>t__builder.Start<BossRushMainView.<OnBeforeStartAsync>d__7>(ref <OnBeforeStartAsync>d__);
			return <OnBeforeStartAsync>d__.<>t__builder.Task;
		}

		// Token: 0x0604321B RID: 274971 RVA: 0x0113F0C3 File Offset: 0x0113D2C3
		protected override void OnBeforeDestroy()
		{
			TabViewComponent<UiDynamicTab> tabViewComponent = this.TabViewComponent;
			if (tabViewComponent != null)
			{
				tabViewComponent.DestroyTabViewComponent();
			}
			this.TabViewComponent = null;
			ModelBase<BossRushModel>.Instance.OnlyOpenRewardView = false;
			ModelBase<BossRushModel>.Instance.PlayBackAnimation = false;
		}

		// Token: 0x0604321C RID: 274972 RVA: 0x0113F0F3 File Offset: 0x0113D2F3
		protected override void OnAddEventListener()
		{
			Singleton<EventSystem>.Instance.Add<EUiTabViewName>(EEventName.RequestChangeBossRushView, new Action<EUiTabViewName>(this.OnRequestChangeBossRushView));
		}

		// Token: 0x0604321D RID: 274973 RVA: 0x0113F111 File Offset: 0x0113D311
		protected override void OnRemoveEventListener()
		{
			Singleton<EventSystem>.Instance.Remove<EUiTabViewName>(EEventName.RequestChangeBossRushView, new Action<EUiTabViewName>(this.OnRequestChangeBossRushView));
		}

		// Token: 0x0604321E RID: 274974 RVA: 0x0113F12F File Offset: 0x0113D32F
		private void OnRequestChangeBossRushView(EUiTabViewName viewName)
		{
			TabComponentWithCaptionItem<CommonTabItem> tabComponent = this.TabComponent;
			if (tabComponent != null)
			{
				tabComponent.SelectToggleByIndex(this.GetViewIndex(viewName), false);
			}
			Singleton<EventSystem>.Instance.Emit<EUiTabViewName>(EEventName.BossRushSubViewChanged, viewName);
		}

		// Token: 0x0604321F RID: 274975 RVA: 0x0113F15B File Offset: 0x0113D35B
		protected override void OnStart()
		{
			TabComponentWithCaptionItem<CommonTabItem> tabComponent = this.TabComponent;
			if (tabComponent == null)
			{
				return;
			}
			tabComponent.SelectToggleByIndex(this.GetViewIndex(ModelBase<BossRushModel>.Instance.OnlyOpenRewardView ? EUiTabViewName.BossRushRewardView : EUiTabViewName.BossRushSelectView), true);
		}

		// Token: 0x06043220 RID: 274976 RVA: 0x0113F18C File Offset: 0x0113D38C
		private UniTask InitTab()
		{
			BossRushMainView.<InitTab>d__13 <InitTab>d__;
			<InitTab>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<InitTab>d__.<>4__this = this;
			<InitTab>d__.<>1__state = -1;
			<InitTab>d__.<>t__builder.Start<BossRushMainView.<InitTab>d__13>(ref <InitTab>d__);
			return <InitTab>d__.<>t__builder.Task;
		}

		// Token: 0x06043221 RID: 274977 RVA: 0x0113F1CF File Offset: 0x0113D3CF
		private CommonTabItem TabItemProxyCreate([Nullable(2)] UUIItem uiItem, int? index)
		{
			return new CommonTabItem();
		}

		// Token: 0x06043222 RID: 274978 RVA: 0x0113F1D8 File Offset: 0x0113D3D8
		private void ToggleCallBack(int index)
		{
			this.CurrentSelectIndex = index;
			UiDynamicTab data = this.TabDataList[index];
			EUiTabViewName viewName = (EUiTabViewName)data.ChildViewName;
			CommonTabItem tabItemByIndex = this.TabComponent.GetTabItemByIndex(index);
			this.TabViewComponent.ToggleCallBack(data, viewName, tabItemByIndex, null, null);
		}

		// Token: 0x06043223 RID: 274979 RVA: 0x0113F22B File Offset: 0x0113D42B
		private CommonTabData GetCommonData(int index)
		{
			return new CommonTabData("", null, null);
		}

		// Token: 0x06043224 RID: 274980 RVA: 0x0113F23C File Offset: 0x0113D43C
		private int GetViewIndex(EUiTabViewName tabName)
		{
			for (int i = 0; i < this.TabDataList.Count; i++)
			{
				if (this.TabDataList[i].ChildViewName == tabName)
				{
					return i;
				}
			}
			return 0;
		}

		// Token: 0x06043225 RID: 274981 RVA: 0x0113F284 File Offset: 0x0113D484
		private void BackClick()
		{
			if (this.CurrentSelectIndex != 0)
			{
				if (this.CurrentSelectIndex != this.GetViewIndex(EUiTabViewName.BossRushRewardView))
				{
					EUiTabViewName viewName = (EUiTabViewName)this.TabDataList[this.CurrentSelectIndex - 1].ChildViewName;
					ModelBase<BossRushModel>.Instance.PlayBackAnimation = true;
					this.OnRequestChangeBossRushView(viewName);
					return;
				}
				ModelBase<BossRushModel>.Instance.PlayBackAnimation = true;
				if (ModelBase<BossRushModel>.Instance.OnlyOpenRewardView)
				{
					ModelBase<BossRushModel>.Instance.OnlyOpenRewardView = false;
					base.CloseMe(null);
					return;
				}
				this.OnRequestChangeBossRushView(EUiTabViewName.BossRushSelectView);
				return;
			}
			else
			{
				if (ControllerBase<GameModeController>.Instance.IsInInstance())
				{
					ControllerBase<InstanceDungeonEntranceController>.Instance.LeaveInstanceDungeon().Forget<bool>();
					return;
				}
				base.CloseMe(null);
				return;
			}
		}

		// Token: 0x04025692 RID: 153234
		private List<UiDynamicTab> TabDataList = new List<UiDynamicTab>();

		// Token: 0x04025693 RID: 153235
		protected TabViewComponent<UiDynamicTab> TabViewComponent;

		// Token: 0x04025694 RID: 153236
		protected TabComponentWithCaptionItem<CommonTabItem> TabComponent;

		// Token: 0x04025695 RID: 153237
		private int CurrentSelectIndex;

		// Token: 0x0200C94A RID: 51530
		[NullableContext(0)]
		public class EComponent
		{
			// Token: 0x0403DE89 RID: 253577
			public const int CaptionItem = 0;

			// Token: 0x0403DE8A RID: 253578
			public const int ContentItem = 1;
		}
	}
}
