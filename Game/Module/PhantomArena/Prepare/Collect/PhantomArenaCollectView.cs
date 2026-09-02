using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.PhantomArena.Prepare.Collect
{
	// Token: 0x0200551D RID: 21789
	[NullableContext(1)]
	[Nullable(0)]
	public class PhantomArenaCollectView : UiViewBase
	{
		// Token: 0x0603795A RID: 227674 RVA: 0x00E19FC5 File Offset: 0x00E181C5
		public PhantomArenaCollectView(UiViewInfo viewInfo) : base(viewInfo)
		{
		}

		// Token: 0x0603795B RID: 227675 RVA: 0x00E19FDC File Offset: 0x00E181DC
		protected override void OnRegisterComponent()
		{
			this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
			{
				new ValueTuple<int, Type>(0, typeof(UUIItem)),
				new ValueTuple<int, Type>(1, typeof(UUIText)),
				new ValueTuple<int, Type>(2, typeof(UUIItem)),
				new ValueTuple<int, Type>(3, typeof(UUIItem))
			};
		}

		// Token: 0x0603795C RID: 227676 RVA: 0x00E1A04C File Offset: 0x00E1824C
		protected override UniTask OnBeforeStartAsync()
		{
			PhantomArenaCollectView.<OnBeforeStartAsync>d__7 <OnBeforeStartAsync>d__;
			<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeStartAsync>d__.<>4__this = this;
			<OnBeforeStartAsync>d__.<>1__state = -1;
			<OnBeforeStartAsync>d__.<>t__builder.Start<PhantomArenaCollectView.<OnBeforeStartAsync>d__7>(ref <OnBeforeStartAsync>d__);
			return <OnBeforeStartAsync>d__.<>t__builder.Task;
		}

		// Token: 0x0603795D RID: 227677 RVA: 0x00E1A08F File Offset: 0x00E1828F
		protected override void OnBeforeShow()
		{
			this.TabComponent.SelectToggleByIndex(this.SelectIndex, false);
			if (ModelBase<PhantomArenaModel>.Instance.IsNewPhantomArenaActivity(this.ActivityId))
			{
				UUIItem item = base.GetItem(3);
				if (item != null)
				{
					item.SetUIActive(false);
				}
			}
			this.BindRedDot();
		}

		// Token: 0x0603795E RID: 227678 RVA: 0x00E1A0CE File Offset: 0x00E182CE
		protected override void OnBeforeHide()
		{
			this.UnBindRedDot();
		}

		// Token: 0x0603795F RID: 227679 RVA: 0x00E1A0D6 File Offset: 0x00E182D6
		protected override void OnAddEventListener()
		{
			Singleton<EventSystem>.Instance.Add(EEventName.OnPhantomArenaCardUnlock, new Action<int>(this.OnCardInfoUpdate));
			Singleton<EventSystem>.Instance.Add(EEventName.OnPhantomArenaCardOutlookUnlock, new Action<int>(this.OnCardInfoUpdate));
		}

		// Token: 0x06037960 RID: 227680 RVA: 0x00E1A110 File Offset: 0x00E18310
		protected override void OnRemoveEventListener()
		{
			Singleton<EventSystem>.Instance.Remove(EEventName.OnPhantomArenaCardUnlock, new Action<int>(this.OnCardInfoUpdate));
			Singleton<EventSystem>.Instance.Remove(EEventName.OnPhantomArenaCardOutlookUnlock, new Action<int>(this.OnCardInfoUpdate));
		}

		// Token: 0x06037961 RID: 227681 RVA: 0x00E1A14C File Offset: 0x00E1834C
		private void RefreshCount(EUiTabViewName viewName)
		{
			int num = 0;
			int num2 = 0;
			string textStringId = "";
			if (viewName == EUiTabViewName.PhantomArenaCollectBadgeTabView)
			{
				num = ModelBase<PhantomArenaModel>.Instance.GetBadgeUnlockCount(this.ActivityId);
				num2 = ModelBase<PhantomArenaModel>.Instance.GetBadgeAllCount(this.ActivityId);
				textStringId = "PhantomBattle_1118";
			}
			else if (viewName == EUiTabViewName.PhantomArenaCollectCardTabView || viewName == EUiTabViewName.PhantomArenaCollectCardTabViewNew)
			{
				num = ModelBase<PhantomArenaModel>.Instance.GetCardUnlockCount(this.ActivityId);
				num2 = ModelBase<PhantomArenaModel>.Instance.GetCardAllCount(this.ActivityId);
				textStringId = "PhantomBattle_1119";
			}
			Singleton<LguiUtil>.Instance.TrySetLocalTextNew(base.GetText(1), textStringId, new <>z__ReadOnlyArray<object>(new object[]
			{
				num,
				num2
			}));
		}

		// Token: 0x06037962 RID: 227682 RVA: 0x00E1A20B File Offset: 0x00E1840B
		private void OnClickBtnBack()
		{
			base.CloseMe(null);
		}

		// Token: 0x06037963 RID: 227683 RVA: 0x00E1A214 File Offset: 0x00E18414
		private void OnClickBtnHelp()
		{
			int helpGroupId = ModelBase<PhantomArenaModel>.Instance.IsNewPhantomArenaActivity(this.ActivityId) ? 477 : 338;
			ControllerBase<HelpController>.Instance.OpenHelpById(helpGroupId);
		}

		// Token: 0x06037964 RID: 227684 RVA: 0x00E1A24B File Offset: 0x00E1844B
		private CommonTabItem TabItemProxyCreate(UUIItem uiItem, int? _)
		{
			return new CommonTabItem();
		}

		// Token: 0x06037965 RID: 227685 RVA: 0x00E1A254 File Offset: 0x00E18454
		private void ToggleCallBack(int index)
		{
			UiDynamicTab data = this.TabDataList[index];
			EUiTabViewName viewName = (EUiTabViewName)data.ChildViewName;
			CommonTabItem tabItemByIndex = this.TabComponent.GetTabItemByIndex(index);
			this.SelectIndex = index;
			this.TabViewComponent.ToggleCallBack(data, viewName, tabItemByIndex, this.ActivityId, null);
			this.RefreshCount(viewName);
		}

		// Token: 0x06037966 RID: 227686 RVA: 0x00E1A2B8 File Offset: 0x00E184B8
		private CommonTabData GetCommonData(int index)
		{
			UiDynamicTab uiDynamicTab = this.TabDataList[index];
			return new CommonTabData(uiDynamicTab.Icon, new CommonTabTitleData(uiDynamicTab.TabName, Array.Empty<object>()), null);
		}

		// Token: 0x06037967 RID: 227687 RVA: 0x00E1A2F0 File Offset: 0x00E184F0
		private void OnCardInfoUpdate(int cardId)
		{
			EUiTabViewName viewName = (EUiTabViewName)this.TabDataList[this.SelectIndex].ChildViewName;
			this.RefreshCount(viewName);
		}

		// Token: 0x06037968 RID: 227688 RVA: 0x00E1A324 File Offset: 0x00E18524
		private void BindRedDot()
		{
			this.BindRedDotByName(EUiTabViewName.PhantomArenaCollectBadgeTabView.ToString(), ERedDotName.RedDotPhantomArenaBadgeReward.ToEnumString(), true);
			this.BindRedDotByName(EUiTabViewName.PhantomArenaCollectCardTabView.ToString(), ERedDotName.RedDotPhantomArenaCardReward.ToEnumString(), true);
		}

		// Token: 0x06037969 RID: 227689 RVA: 0x00E1A374 File Offset: 0x00E18574
		private void UnBindRedDot()
		{
			this.BindRedDotByName(EUiTabViewName.PhantomArenaCollectBadgeTabView.ToString(), ERedDotName.RedDotPhantomArenaBadgeReward.ToEnumString(), false);
			this.BindRedDotByName(EUiTabViewName.PhantomArenaCollectCardTabView.ToString(), ERedDotName.RedDotPhantomArenaCardReward.ToEnumString(), false);
		}

		// Token: 0x0603796A RID: 227690 RVA: 0x00E1A3C4 File Offset: 0x00E185C4
		private void BindRedDotByName(string viewName, string redDotName, bool bIsBind)
		{
			int num = this.TabDataList.FindIndex((UiDynamicTab config) => config.ChildViewName == viewName);
			if (num >= 0)
			{
				CommonTabItem tabItemByIndex = this.TabComponent.GetTabItemByIndex(num);
				if (bIsBind)
				{
					if (tabItemByIndex != null)
					{
						tabItemByIndex.BindRedDot((ERedDotName)Enum.Parse(typeof(ERedDotName), redDotName), new int?(this.ActivityId));
						return;
					}
				}
				else if (tabItemByIndex != null)
				{
					tabItemByIndex.UnBindRedDot();
				}
			}
		}

		// Token: 0x0401FDED RID: 130541
		protected int ActivityId;

		// Token: 0x0401FDEE RID: 130542
		private int SelectIndex;

		// Token: 0x0401FDEF RID: 130543
		private List<UiDynamicTab> TabDataList = new List<UiDynamicTab>();

		// Token: 0x0401FDF0 RID: 130544
		private TabComponentWithCaptionItem<CommonTabItem> TabComponent;

		// Token: 0x0401FDF1 RID: 130545
		private TabViewComponent<UiDynamicTab> TabViewComponent;

		// Token: 0x0200B4B0 RID: 46256
		[NullableContext(0)]
		private static class EComponents
		{
			// Token: 0x04037EF4 RID: 229108
			public const int ItemCaption = 0;

			// Token: 0x04037EF5 RID: 229109
			public const int TextNum = 1;

			// Token: 0x04037EF6 RID: 229110
			public const int ItemContent = 2;

			// Token: 0x04037EF7 RID: 229111
			public const int ItemTabPanel = 3;
		}
	}
}
