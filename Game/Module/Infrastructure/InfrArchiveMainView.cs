using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.PhoneMessage;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.Infrastructure
{
	// Token: 0x02005C4F RID: 23631
	[NullableContext(1)]
	[Nullable(0)]
	public class InfrArchiveMainView : UiViewBase
	{
		// Token: 0x0603BB38 RID: 244536 RVA: 0x00F1F87C File Offset: 0x00F1DA7C
		public InfrArchiveMainView(UiViewInfo info) : base(info)
		{
		}

		// Token: 0x0603BB39 RID: 244537 RVA: 0x00F1F898 File Offset: 0x00F1DA98
		protected unsafe override void OnRegisterComponent()
		{
			int num = 11;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIVerticalLayout));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIButtonComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(5, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(6, typeof(UUIScrollViewWithScrollbarComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(7, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(8, typeof(UUIScrollViewWithScrollbarComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(9, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(10, typeof(UUIItem));
			this.ComponentRegisterInfos = list;
			num2 = 1;
			List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
			CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
			Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
			num = 0;
			*span2[num] = new ValueTuple<int, Delegate>(4, new Action(this.OnClickBtnStore));
			this.BtnBindInfo = list2;
		}

		// Token: 0x0603BB3A RID: 244538 RVA: 0x00F1FA6A File Offset: 0x00F1DC6A
		protected override void OnAddEventListener()
		{
			Singleton<EventSystem>.Instance.Add(EEventName.InfrastructureArchiveReadUpdate, new Action(this.OnArchiveReadUpdate));
		}

		// Token: 0x0603BB3B RID: 244539 RVA: 0x00F1FA88 File Offset: 0x00F1DC88
		protected override void OnRemoveEventListener()
		{
			Singleton<EventSystem>.Instance.Remove(EEventName.InfrastructureArchiveReadUpdate, new Action(this.OnArchiveReadUpdate));
		}

		// Token: 0x0603BB3C RID: 244540 RVA: 0x00F1FAA8 File Offset: 0x00F1DCA8
		protected override UniTask OnBeforeStartAsync()
		{
			InfrArchiveMainView.<OnBeforeStartAsync>d__9 <OnBeforeStartAsync>d__;
			<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeStartAsync>d__.<>4__this = this;
			<OnBeforeStartAsync>d__.<>1__state = -1;
			<OnBeforeStartAsync>d__.<>t__builder.Start<InfrArchiveMainView.<OnBeforeStartAsync>d__9>(ref <OnBeforeStartAsync>d__);
			return <OnBeforeStartAsync>d__.<>t__builder.Task;
		}

		// Token: 0x0603BB3D RID: 244541 RVA: 0x00F1FAEB File Offset: 0x00F1DCEB
		protected override void OnStart()
		{
			this.RefreshCaption();
			this.RefreshCardInfo();
			this.RefreshRedDot();
			this.MenuItemLayout.GetLayoutItemList()[0].SetToggleSelected(EToggleState.ETT_Checked);
		}

		// Token: 0x0603BB3E RID: 244542 RVA: 0x00F1FB16 File Offset: 0x00F1DD16
		protected override void OnBeforeDestroy()
		{
			this.UnBindRedDot();
		}

		// Token: 0x0603BB3F RID: 244543 RVA: 0x00F1FB1E File Offset: 0x00F1DD1E
		private void UnBindRedDot()
		{
			ControllerBase<RedDotController>.Instance.UnBindRedDot(ERedDotName.InfrArchive);
		}

		// Token: 0x0603BB40 RID: 244544 RVA: 0x00F1FB30 File Offset: 0x00F1DD30
		private void RefreshCardInfo()
		{
			InfrastructureDefine.EInfrArchiveTabType cardType = this.CardType;
			if (cardType != InfrastructureDefine.EInfrArchiveTabType.CollectCard)
			{
				if (cardType == InfrastructureDefine.EInfrArchiveTabType.RoleCard)
				{
					this.RefreshRoleCard();
				}
			}
			else
			{
				this.RefreshCollectCard();
			}
			this.RoleCardLayout.SetActive(this.CardType == InfrastructureDefine.EInfrArchiveTabType.RoleCard);
			this.CollectCardLayout.SetActive(this.CardType == InfrastructureDefine.EInfrArchiveTabType.CollectCard);
		}

		// Token: 0x0603BB41 RID: 244545 RVA: 0x00F1FB84 File Offset: 0x00F1DD84
		private UniTask CreateCaption()
		{
			InfrArchiveMainView.<CreateCaption>d__14 <CreateCaption>d__;
			<CreateCaption>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<CreateCaption>d__.<>4__this = this;
			<CreateCaption>d__.<>1__state = -1;
			<CreateCaption>d__.<>t__builder.Start<InfrArchiveMainView.<CreateCaption>d__14>(ref <CreateCaption>d__);
			return <CreateCaption>d__.<>t__builder.Task;
		}

		// Token: 0x0603BB42 RID: 244546 RVA: 0x00F1FBC8 File Offset: 0x00F1DDC8
		private UniTask CreateMenuItemLayout()
		{
			InfrArchiveMainView.<CreateMenuItemLayout>d__15 <CreateMenuItemLayout>d__;
			<CreateMenuItemLayout>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<CreateMenuItemLayout>d__.<>4__this = this;
			<CreateMenuItemLayout>d__.<>1__state = -1;
			<CreateMenuItemLayout>d__.<>t__builder.Start<InfrArchiveMainView.<CreateMenuItemLayout>d__15>(ref <CreateMenuItemLayout>d__);
			return <CreateMenuItemLayout>d__.<>t__builder.Task;
		}

		// Token: 0x0603BB43 RID: 244547 RVA: 0x00F1FC0B File Offset: 0x00F1DE0B
		private void CreateRoleCardLayout()
		{
			this.RoleCardLayout = new GenericScrollViewNew<InfrArchiveRoleCardItem, int>(base.GetScrollViewWithScrollbar(6), delegate()
			{
				InfrArchiveRoleCardItem infrArchiveRoleCardItem = new InfrArchiveRoleCardItem();
				infrArchiveRoleCardItem.SetSelectedCallBack(new Action<int>(this.OnClickRoleCard));
				return infrArchiveRoleCardItem;
			}, null, false, null);
		}

		// Token: 0x0603BB44 RID: 244548 RVA: 0x00F1FC2E File Offset: 0x00F1DE2E
		private void CreateCollectCardLayout()
		{
			this.CollectCardLayout = new GenericScrollViewNew<InfrArchiveCollectCardItem, int>(base.GetScrollViewWithScrollbar(8), () => new InfrArchiveCollectCardItem(), null, false, null);
		}

		// Token: 0x0603BB45 RID: 244549 RVA: 0x00F1FC64 File Offset: 0x00F1DE64
		private void RefreshCaption()
		{
			this.Caption.SetCloseCallBack(delegate
			{
				base.CloseMe(null);
			});
			this.Caption.SetHelpBtnActive(false);
		}

		// Token: 0x0603BB46 RID: 244550 RVA: 0x00F1FC8C File Offset: 0x00F1DE8C
		private void RefreshRoleCard()
		{
			IEnumerable<InfrPhoneMessage> infrPhoneMessageConfigList = ConfigBase<InfrastructureConfig>.Instance.GetInfrPhoneMessageConfigList();
			PhoneMsgModel phoneMsgModel = ModelBase<PhoneMsgModel>.Instance;
			List<int> data = (from item in infrPhoneMessageConfigList
			select item.Id into a
			orderby (!phoneMsgModel.IsPhoneMsgUnlock(a)) ? 1 : 0, a
			select a).ToList<int>();
			this.RoleCardLayout.RefreshByData(data, null, false);
		}

		// Token: 0x0603BB47 RID: 244551 RVA: 0x00F1FD24 File Offset: 0x00F1DF24
		private void RefreshCollectCard()
		{
			List<int> data = (from config in ConfigBase<InfrastructureConfig>.Instance.GetArchiveItemIdConfigList()
			select config.Id).OrderBy(delegate(int a)
			{
				InfrArchiveItem? archiveItemConfig = ConfigBase<InfrastructureConfig>.Instance.GetArchiveItemConfig(a);
				return (ModelBase<InventoryModel>.Instance.GetItemCountByConfigId(archiveItemConfig.Value.ItemId, 0) <= 0) ? 1 : 0;
			}).ThenBy((int a) => a).ToList<int>();
			this.CollectCardLayout.RefreshByData(data, null, false);
		}

		// Token: 0x0603BB48 RID: 244552 RVA: 0x00F1FDBB File Offset: 0x00F1DFBB
		private void OnClickBtnStore()
		{
			Singleton<UiManager>.Instance.OpenView(EUiViewName.ActivityRewardPopUpView, ModelBase<InfrastructureModel>.Instance.GetScoreRewardData(), delegate(bool success, int viewId)
			{
				if (success && Singleton<UiManager>.Instance.IsViewShow(EUiViewName.InfrArchiveMainView))
				{
					UiViewBase viewByName = Singleton<UiManager>.Instance.GetViewByName(EUiViewName.InfrArchiveMainView);
					if (viewByName == null)
					{
						return;
					}
					viewByName.AddChildViewById(viewId);
				}
			});
		}

		// Token: 0x0603BB49 RID: 244553 RVA: 0x00F1FDF8 File Offset: 0x00F1DFF8
		private void OnClickMenuItem(InfrastructureDefine.EInfrArchiveTabType cardType)
		{
			this.CardType = cardType;
			GenericLayout<InfrArchiveMenuItem, IInfrArchiveMenuItemData> menuItemLayout = this.MenuItemLayout;
			if (menuItemLayout != null)
			{
				(from item in menuItemLayout.GetLayoutItemList()
				where item.CardType != cardType
				select item).ToList<InfrArchiveMenuItem>().ForEach(delegate(InfrArchiveMenuItem item)
				{
					item.SetToggleSelected(EToggleState.ETT_UnChecked);
				});
			}
			this.RefreshCardInfo();
		}

		// Token: 0x0603BB4A RID: 244554 RVA: 0x00F1FE70 File Offset: 0x00F1E070
		private void OnClickRoleCard(int index)
		{
			InfrArchiveRoleCardItem scrollItemByIndex = this.RoleCardLayout.GetScrollItemByIndex(index);
			if (!ModelBase<PhoneMsgModel>.Instance.IsPhoneMsgUnlock(scrollItemByIndex.MsgId))
			{
				return;
			}
			ShortMessage? phoneMsgConfig = ConfigBase<PhoneMsgConfig>.Instance.GetPhoneMsgConfig(scrollItemByIndex.MsgId);
			PhoneMsgPanelViewData param = new PhoneMsgPanelViewData
			{
				ShortMessage = phoneMsgConfig,
				NeedShowTips = false,
				OpenWay = EPhoneMsgOpenWay.Infrastructure,
				ViewType = EPhoneMsgViewType.Big
			};
			Singleton<UiManager>.Instance.OpenView(EUiViewName.PhoneMsgPanelViewBig, param, null);
		}

		// Token: 0x0603BB4B RID: 244555 RVA: 0x00F1FEE1 File Offset: 0x00F1E0E1
		private void OnArchiveReadUpdate()
		{
			this.RefreshCollectCard();
		}

		// Token: 0x0603BB4C RID: 244556 RVA: 0x00F1FEEC File Offset: 0x00F1E0EC
		private void RefreshRedDot()
		{
			UUIItem item = base.GetItem(10);
			ControllerBase<RedDotController>.Instance.BindRedDot(ERedDotName.InfrArchive, item, null, 0);
		}

		// Token: 0x0603BB4D RID: 244557 RVA: 0x00F1FF14 File Offset: 0x00F1E114
		[return: Nullable(new byte[]
		{
			2,
			1
		})]
		public override UUIItem[] GetGuideUiItemAndUiItemForShowEx(string[] configParams)
		{
			if (configParams.Length == 0)
			{
				return null;
			}
			if (!(configParams[0] == "MenuItem"))
			{
				return null;
			}
			int index = int.Parse(configParams[1]);
			GenericLayout<InfrArchiveMenuItem, IInfrArchiveMenuItemData> menuItemLayout = this.MenuItemLayout;
			InfrArchiveMenuItem infrArchiveMenuItem = (menuItemLayout != null) ? menuItemLayout.GetLayoutItemByIndex(index) : null;
			if (infrArchiveMenuItem == null)
			{
				return null;
			}
			return infrArchiveMenuItem.GetGuideUiItemAndUiItemForShowEx(configParams);
		}

		// Token: 0x04021919 RID: 137497
		private PopupCaptionItem Caption = new PopupCaptionItem(null);

		// Token: 0x0402191A RID: 137498
		private GenericLayout<InfrArchiveMenuItem, IInfrArchiveMenuItemData> MenuItemLayout;

		// Token: 0x0402191B RID: 137499
		private GenericScrollViewNew<InfrArchiveRoleCardItem, int> RoleCardLayout;

		// Token: 0x0402191C RID: 137500
		private GenericScrollViewNew<InfrArchiveCollectCardItem, int> CollectCardLayout;

		// Token: 0x0402191D RID: 137501
		private InfrastructureDefine.EInfrArchiveTabType CardType = InfrastructureDefine.EInfrArchiveTabType.RoleCard;

		// Token: 0x0200BCC0 RID: 48320
		[NullableContext(0)]
		private class EChildType
		{
			// Token: 0x0403A26F RID: 238191
			public const int ItemCaption = 0;

			// Token: 0x0403A270 RID: 238192
			public const int PanelMenuLayout = 1;

			// Token: 0x0403A271 RID: 238193
			public const int PanelMenuItem = 2;

			// Token: 0x0403A272 RID: 238194
			public const int PanelLimitStore = 3;

			// Token: 0x0403A273 RID: 238195
			public const int BtnStore = 4;

			// Token: 0x0403A274 RID: 238196
			public const int TextTitle = 5;

			// Token: 0x0403A275 RID: 238197
			public const int ScrollRoleCard = 6;

			// Token: 0x0403A276 RID: 238198
			public const int ItemRoleCard = 7;

			// Token: 0x0403A277 RID: 238199
			public const int ScrollCollectCard = 8;

			// Token: 0x0403A278 RID: 238200
			public const int ItemCollectCard = 9;

			// Token: 0x0403A279 RID: 238201
			public const int ItemRedDot = 10;
		}
	}
}
