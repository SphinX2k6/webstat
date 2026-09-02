using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using Aki.Protocol;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using UnrealEngine;

namespace CSharpScript.Game.Module.Activity.ActivityContent.SpringManor
{
	// Token: 0x0200634C RID: 25420
	[NullableContext(1)]
	[Nullable(0)]
	public class SpringManorBrochureView : UiViewBase
	{
		// Token: 0x0603FD61 RID: 261473 RVA: 0x0105FEC6 File Offset: 0x0105E0C6
		public SpringManorBrochureView(UiViewInfo viewInfo) : base(viewInfo)
		{
		}

		// Token: 0x0603FD62 RID: 261474 RVA: 0x0105FED0 File Offset: 0x0105E0D0
		protected override void OnRegisterComponent()
		{
			this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
			{
				new ValueTuple<int, Type>(0, typeof(UUIText)),
				new ValueTuple<int, Type>(1, typeof(UUIScrollViewWithScrollbarComponent)),
				new ValueTuple<int, Type>(2, typeof(UUIHorizontalLayout)),
				new ValueTuple<int, Type>(3, typeof(UUIItem)),
				new ValueTuple<int, Type>(4, typeof(UUIItem)),
				new ValueTuple<int, Type>(5, typeof(UUIText))
			};
		}

		// Token: 0x0603FD63 RID: 261475 RVA: 0x0105FF6C File Offset: 0x0105E16C
		protected override void OnStart()
		{
			AUIBaseActor rootActor = this.RootActor;
			if (rootActor != null)
			{
				rootActor.OnSequencePlayEvent.Bind(new Action<string, string>(this.OnPlaySequenceEvent));
			}
			this.CaptionItem = new PopupCaptionItem(base.GetItem(4));
			this.CaptionItem.SetHelpBtnActive(false);
			this.CaptionItem.SetCloseCallBack(delegate
			{
				Singleton<UiManager>.Instance.ResetToBattleView(null);
			});
			this.ScrollList = new GenericScrollViewNew<SpringManorBrochureItem, BrochureItemData>(base.GetScrollViewWithScrollbar(1), new Func<SpringManorBrochureItem>(this.InitDeTermItem), null, false, null);
		}

		// Token: 0x0603FD64 RID: 261476 RVA: 0x01060004 File Offset: 0x0105E204
		protected override void OnBeforeShow()
		{
			SpringManorBrochureViewOpenParam springManorBrochureViewOpenParam = this.OpenParam as SpringManorBrochureViewOpenParam;
			this.IsHideReward = (springManorBrochureViewOpenParam != null && springManorBrochureViewOpenParam.IsHideReward);
			this.ActivityId = ((springManorBrochureViewOpenParam != null) ? springManorBrochureViewOpenParam.ActivityId : ModelBase<SpringManorModel>.Instance.ActivityData.Id);
			PopupCaptionItem captionItem = this.CaptionItem;
			if (captionItem != null)
			{
				captionItem.SetTitleByTextIdAndArgNew("Brochure_ActivityName", Array.Empty<object>());
			}
			PopupCaptionItem captionItem2 = this.CaptionItem;
			if (captionItem2 != null)
			{
				captionItem2.SetHelpCallBack(new Action(this.OnClickMoreButton));
			}
			this.RefreshBrochureItem();
		}

		// Token: 0x0603FD65 RID: 261477 RVA: 0x0106008D File Offset: 0x0105E28D
		protected override void OnAddEventListener()
		{
			Singleton<EventSystem>.Instance.Add(EEventName.OnBrochureBookItemStateUpdate, new Action(this.OnBrochureBookItemStateUpdate));
		}

		// Token: 0x0603FD66 RID: 261478 RVA: 0x010600AB File Offset: 0x0105E2AB
		protected override void OnRemoveEventListener()
		{
			Singleton<EventSystem>.Instance.Remove(EEventName.OnBrochureBookItemStateUpdate, new Action(this.OnBrochureBookItemStateUpdate));
		}

		// Token: 0x0603FD67 RID: 261479 RVA: 0x010600CC File Offset: 0x0105E2CC
		private void OnPlaySequenceEvent(string sequenceName, string eventName)
		{
			if (eventName == "Sequence_Content_In")
			{
				GenericScrollViewNew<SpringManorBrochureItem, BrochureItemData> scrollList = this.ScrollList;
				UUIItem uuiitem = (scrollList != null) ? scrollList.GetItemByIndex(this.ScrollToTargetIndex) : null;
				if (uuiitem != null)
				{
					UUIScrollViewWithScrollbarComponent scrollViewWithScrollbar = base.GetScrollViewWithScrollbar(1);
					if (scrollViewWithScrollbar == null)
					{
						return;
					}
					scrollViewWithScrollbar.ScrollTo(uuiitem, true);
					return;
				}
			}
			else if (eventName == "Sequence_Brochure_Start_Unlock")
			{
				this.CheckAllItemPlayedSequence();
			}
		}

		// Token: 0x0603FD68 RID: 261480 RVA: 0x01060129 File Offset: 0x0105E329
		private SpringManorBrochureItem InitDeTermItem()
		{
			SpringManorBrochureItem springManorBrochureItem = new SpringManorBrochureItem();
			springManorBrochureItem.SetToggleCallBack(new Action<BrochureItemData>(this.ClickItem));
			springManorBrochureItem.SetClickGetButtonCallBack(new Action<BrochureItemData>(this.ClickGetButton));
			return springManorBrochureItem;
		}

		// Token: 0x0603FD69 RID: 261481 RVA: 0x01060154 File Offset: 0x0105E354
		private void OnClickMoreButton()
		{
			int helpId = ModelBase<ActivityModel>.Instance.GetActivityById(this.ActivityId).GetHelpId();
			ControllerBase<HelpController>.Instance.OpenHelpById(helpId);
		}

		// Token: 0x0603FD6A RID: 261482 RVA: 0x01060184 File Offset: 0x0105E384
		[NullableContext(2)]
		private void ClickGetButton(BrochureItemData tabData)
		{
			int num = (tabData != null) ? tabData.ConfigId : 0;
			if (num > 0)
			{
				BookItemInfo bookItemDataById = ModelBase<SpringManorModel>.Instance.ActivityData.GetBookItemDataById(num);
				if (bookItemDataById != null && bookItemDataById.BookItemState == BookItemState.BookItemUnlock)
				{
					ControllerBase<SpringManorController>.Instance.RequestBrochureReward(this.ActivityId, EBrochureType.Brochure, num, true);
				}
			}
		}

		// Token: 0x0603FD6B RID: 261483 RVA: 0x010601D4 File Offset: 0x0105E3D4
		[NullableContext(2)]
		public void ClickItem(BrochureItemData tabData)
		{
			SpringManorBrochureDetailViewOpenParam param = new SpringManorBrochureDetailViewOpenParam
			{
				ActivityId = this.ActivityId,
				StartIndex = ((tabData != null) ? tabData.Index : 0),
				IsHideReward = this.IsHideReward
			};
			Singleton<UiManager>.Instance.OpenView(EUiViewName.SpringManorBrochureDetailView, param, null);
		}

		// Token: 0x0603FD6C RID: 261484 RVA: 0x01060222 File Offset: 0x0105E422
		private void OnBrochureBookItemStateUpdate()
		{
			this.RefreshBrochureItem();
		}

		// Token: 0x0603FD6D RID: 261485 RVA: 0x0106022C File Offset: 0x0105E42C
		private void RefreshBrochureItem()
		{
			Brochure? springManorBrochureByActivityAndType = ConfigBase<SpringManorConfig>.Instance.GetSpringManorBrochureByActivityAndType(this.ActivityId, EBrochureType.Brochure);
			if (springManorBrochureByActivityAndType == null)
			{
				return;
			}
			List<BrochureItemData> list = new List<BrochureItemData>();
			int num = 0;
			int num2 = -1;
			int num3 = -1;
			for (int i = 0; i < springManorBrochureByActivityAndType.Value.BookItemIdsLength; i++)
			{
				int num4 = springManorBrochureByActivityAndType.Value.BookItemIds(i);
				if (ConfigBase<SpringManorConfig>.Instance.GetSpringManorBookItemById(num4) != null)
				{
					BrochureItemData brochureItemData = new BrochureItemData();
					if (this.IsHideReward)
					{
						brochureItemData.State = EBrochureState.Rewarded;
					}
					else
					{
						SpringManorData activityData = ModelBase<SpringManorModel>.Instance.ActivityData;
						brochureItemData.State = activityData.GetBookItemStateById(num4);
					}
					if (brochureItemData.State == EBrochureState.Rewarded)
					{
						num++;
					}
					else if (num2 < 0 && brochureItemData.State == EBrochureState.Lock)
					{
						num2 = i;
					}
					else if (num3 < 0 && brochureItemData.State == EBrochureState.Unlock)
					{
						num3 = i;
					}
					brochureItemData.ConfigId = num4;
					brochureItemData.Index = i;
					list.Add(brochureItemData);
				}
			}
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(5), "Brochure_ProgressStatus", new <>z__ReadOnlyArray<object>(new object[]
			{
				num,
				springManorBrochureByActivityAndType.Value.BookItemIdsLength
			}));
			this.ScrollToTargetIndex = ((num3 >= 0) ? num3 : ((num2 >= 0) ? num2 : 0));
			GenericScrollViewNew<SpringManorBrochureItem, BrochureItemData> scrollList = this.ScrollList;
			if (scrollList == null)
			{
				return;
			}
			scrollList.RefreshByData(list, null, false);
		}

		// Token: 0x0603FD6E RID: 261486 RVA: 0x010603A8 File Offset: 0x0105E5A8
		private void CheckAllItemPlayedSequence()
		{
			GenericScrollViewNew<SpringManorBrochureItem, BrochureItemData> scrollList = this.ScrollList;
			foreach (SpringManorBrochureItem springManorBrochureItem in (((scrollList != null) ? scrollList.GetScrollItemList() : null) ?? new List<SpringManorBrochureItem>()))
			{
				springManorBrochureItem.CheckPlayUnlockSequence();
			}
		}

		// Token: 0x04023DFE RID: 146942
		[Nullable(2)]
		private PopupCaptionItem CaptionItem;

		// Token: 0x04023DFF RID: 146943
		[Nullable(new byte[]
		{
			2,
			1,
			1
		})]
		private GenericScrollViewNew<SpringManorBrochureItem, BrochureItemData> ScrollList;

		// Token: 0x04023E00 RID: 146944
		private int ActivityId;

		// Token: 0x04023E01 RID: 146945
		private int ScrollToTargetIndex;

		// Token: 0x04023E02 RID: 146946
		private bool IsHideReward;
	}
}
