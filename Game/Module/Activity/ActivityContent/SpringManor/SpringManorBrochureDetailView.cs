using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using Aki.Protocol;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.Activity.ActivityContent.SpringManor
{
	// Token: 0x0200634A RID: 25418
	[NullableContext(1)]
	[Nullable(0)]
	public class SpringManorBrochureDetailView : UiViewBase
	{
		// Token: 0x0603FD47 RID: 261447 RVA: 0x0105F3EA File Offset: 0x0105D5EA
		public SpringManorBrochureDetailView(UiViewInfo viewInfo) : base(viewInfo)
		{
		}

		// Token: 0x0603FD48 RID: 261448 RVA: 0x0105F400 File Offset: 0x0105D600
		protected override void OnRegisterComponent()
		{
			this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
			{
				new ValueTuple<int, Type>(0, typeof(UUIItem)),
				new ValueTuple<int, Type>(1, typeof(UUITexture)),
				new ValueTuple<int, Type>(2, typeof(UUIItem)),
				new ValueTuple<int, Type>(3, typeof(UUIText)),
				new ValueTuple<int, Type>(4, typeof(UUIText)),
				new ValueTuple<int, Type>(5, typeof(UUIHorizontalLayout)),
				new ValueTuple<int, Type>(6, typeof(UUIItem)),
				new ValueTuple<int, Type>(7, typeof(UUIItem)),
				new ValueTuple<int, Type>(8, typeof(UUIScrollViewWithScrollbarComponent)),
				new ValueTuple<int, Type>(9, typeof(UUIHorizontalLayout)),
				new ValueTuple<int, Type>(10, typeof(UUIItem)),
				new ValueTuple<int, Type>(11, typeof(UUIButtonComponent)),
				new ValueTuple<int, Type>(12, typeof(UUIButtonComponent)),
				new ValueTuple<int, Type>(13, typeof(UUIButtonComponent)),
				new ValueTuple<int, Type>(14, typeof(UUIButtonComponent)),
				new ValueTuple<int, Type>(15, typeof(UUIItem))
			};
			this.BtnBindInfo = new List<ValueTuple<int, Delegate>>
			{
				new ValueTuple<int, Delegate>(12, new Action(this.OnClickBtnBrochureNext)),
				new ValueTuple<int, Delegate>(13, new Action(this.OnClickBtnBrochurePre)),
				new ValueTuple<int, Delegate>(11, new Action(this.OnClickBtnTracking)),
				new ValueTuple<int, Delegate>(14, new Action(this.OnClickRewardBtn))
			};
		}

		// Token: 0x0603FD49 RID: 261449 RVA: 0x0105F5F0 File Offset: 0x0105D7F0
		protected override void OnStart()
		{
			AUIBaseActor rootActor = this.RootActor;
			if (rootActor != null)
			{
				rootActor.OnSequencePlayEvent.Bind(new Action<string, string>(this.OnPlaySequenceEvent));
			}
			this.SequencePlayer = new LevelSequencePlayer(this.RootItem);
			this.CaptionItem = new PopupCaptionItem(base.GetItem(0));
			this.CaptionItem.SetCloseCallBack(delegate
			{
				base.CloseMe(null);
			});
			this.RewardItemLayout = new GenericLayout<CommonItemSmallItemGrid, TItem>(base.GetHorizontalLayout(9), new Func<CommonItemSmallItemGrid>(this.InitGridItem), null, false, true);
			UUIHorizontalLayout horizontalLayout = base.GetHorizontalLayout(5);
			this.BottomPointLayout = new GenericLayout<SpringManorBrochureDetailPointItem, int>(horizontalLayout, new Func<SpringManorBrochureDetailPointItem>(this.InitPointItem), null, false, true);
		}

		// Token: 0x0603FD4A RID: 261450 RVA: 0x0105F6A0 File Offset: 0x0105D8A0
		protected override void OnBeforeShow()
		{
			SpringManorBrochureDetailViewOpenParam springManorBrochureDetailViewOpenParam = this.OpenParam as SpringManorBrochureDetailViewOpenParam;
			this.ActivityId = ((springManorBrochureDetailViewOpenParam != null) ? springManorBrochureDetailViewOpenParam.ActivityId : 0);
			this.CurrentDetailPointIndex = ((springManorBrochureDetailViewOpenParam != null) ? springManorBrochureDetailViewOpenParam.StartIndex : 0);
			this.IsHideReward = (springManorBrochureDetailViewOpenParam != null && springManorBrochureDetailViewOpenParam.IsHideReward);
			ActivityBaseData activityById = ModelBase<ActivityModel>.Instance.GetActivityById(this.ActivityId);
			PopupCaptionItem captionItem = this.CaptionItem;
			if (captionItem != null)
			{
				captionItem.SetTitle((activityById != null) ? activityById.GetTitle() : null);
			}
			PopupCaptionItem captionItem2 = this.CaptionItem;
			if (captionItem2 != null)
			{
				captionItem2.SetHelpCallBack(new Action(this.OnClickMoreButton));
			}
			this.InitDetailData();
			this.RefreshPage();
			this.UpdateArrowBtnVisible();
		}

		// Token: 0x0603FD4B RID: 261451 RVA: 0x0105F74C File Offset: 0x0105D94C
		protected override void OnAddEventListener()
		{
			Singleton<EventSystem>.Instance.Add(EEventName.OnBrochureBookItemStateUpdate, new Action(this.OnBrochureBookItemStateUpdate));
		}

		// Token: 0x0603FD4C RID: 261452 RVA: 0x0105F76A File Offset: 0x0105D96A
		protected override void OnRemoveEventListener()
		{
			Singleton<EventSystem>.Instance.Remove(EEventName.OnBrochureBookItemStateUpdate, new Action(this.OnBrochureBookItemStateUpdate));
		}

		// Token: 0x0603FD4D RID: 261453 RVA: 0x0105F788 File Offset: 0x0105D988
		private void OnPlaySequenceEvent(string sequenceName, string eventName)
		{
			if (eventName == "Sequence_Switch_Left" || eventName == "Sequence_Switch_Right")
			{
				GenericLayout<SpringManorBrochureDetailPointItem, int> bottomPointLayout = this.BottomPointLayout;
				if (bottomPointLayout != null)
				{
					bottomPointLayout.SelectGridProxy(this.CurrentDetailPointIndex, false);
				}
				this.RefreshPage();
			}
		}

		// Token: 0x0603FD4E RID: 261454 RVA: 0x0105F7C2 File Offset: 0x0105D9C2
		private void OnBrochureBookItemStateUpdate()
		{
			this.RefreshPage();
		}

		// Token: 0x0603FD4F RID: 261455 RVA: 0x0105F7CA File Offset: 0x0105D9CA
		private CommonItemSmallItemGrid InitGridItem()
		{
			return new CommonItemSmallItemGrid
			{
				ShowReceivedCallBack = ((TItem _) => this.IsRewarded)
			};
		}

		// Token: 0x0603FD50 RID: 261456 RVA: 0x0105F7E3 File Offset: 0x0105D9E3
		private SpringManorBrochureDetailPointItem InitPointItem()
		{
			return new SpringManorBrochureDetailPointItem();
		}

		// Token: 0x0603FD51 RID: 261457 RVA: 0x0105F7EC File Offset: 0x0105D9EC
		private void OnClickMoreButton()
		{
			int helpId = ModelBase<ActivityModel>.Instance.GetActivityById(this.ActivityId).GetHelpId();
			ControllerBase<HelpController>.Instance.OpenHelpById(helpId);
		}

		// Token: 0x0603FD52 RID: 261458 RVA: 0x0105F81C File Offset: 0x0105DA1C
		private void OnClickRewardBtn()
		{
			int getCurDetailConfigId = this.GetCurDetailConfigId;
			SpringManorData activityData = ModelBase<SpringManorModel>.Instance.ActivityData;
			BookItemInfo bookItemInfo = (activityData != null) ? activityData.GetBookItemDataById(getCurDetailConfigId) : null;
			if (bookItemInfo != null && bookItemInfo.BookItemState == BookItemState.BookItemUnlock)
			{
				ControllerBase<SpringManorController>.Instance.RequestBrochureReward(this.ActivityId, EBrochureType.Brochure, getCurDetailConfigId, false);
			}
		}

		// Token: 0x17009CB8 RID: 40120
		// (get) Token: 0x0603FD53 RID: 261459 RVA: 0x0105F868 File Offset: 0x0105DA68
		private int GetCurDetailConfigId
		{
			get
			{
				int currentDetailPointIndex = this.CurrentDetailPointIndex;
				if (currentDetailPointIndex < 0 || currentDetailPointIndex >= this.DetailIds.Count)
				{
					return 0;
				}
				return this.DetailIds[currentDetailPointIndex];
			}
		}

		// Token: 0x0603FD54 RID: 261460 RVA: 0x0105F89C File Offset: 0x0105DA9C
		private void InitDetailData()
		{
			this.DetailIds.Clear();
			SpringManorConfig instance = ConfigBase<SpringManorConfig>.Instance;
			Brochure? brochure = (instance != null) ? instance.GetSpringManorBrochureByActivityAndType(this.ActivityId, EBrochureType.Brochure) : null;
			if (brochure == null)
			{
				return;
			}
			List<int> list = new List<int>();
			for (int i = 0; i < brochure.Value.BookItemIdsLength; i++)
			{
				int num = brochure.Value.BookItemIds(i);
				list.Add(num);
				SpringManorConfig instance2 = ConfigBase<SpringManorConfig>.Instance;
				BookItem? bookItem = (instance2 != null) ? instance2.GetSpringManorBookItemById(num) : null;
				if (bookItem != null)
				{
					this.DetailIds.Add(num);
				}
			}
			GenericLayout<SpringManorBrochureDetailPointItem, int> bottomPointLayout = this.BottomPointLayout;
			if (bottomPointLayout == null)
			{
				return;
			}
			bottomPointLayout.RefreshByData(list, delegate
			{
				GenericLayout<SpringManorBrochureDetailPointItem, int> bottomPointLayout2 = this.BottomPointLayout;
				if (bottomPointLayout2 == null)
				{
					return;
				}
				bottomPointLayout2.SelectGridProxy(this.CurrentDetailPointIndex, false);
			}, false);
		}

		// Token: 0x0603FD55 RID: 261461 RVA: 0x0105F970 File Offset: 0x0105DB70
		private void RefreshPage()
		{
			int getCurDetailConfigId = this.GetCurDetailConfigId;
			this.SetDetailInfo(getCurDetailConfigId);
			SpringManorConfig instance = ConfigBase<SpringManorConfig>.Instance;
			Brochure? brochure = (instance != null) ? instance.GetSpringManorBrochureByActivityAndType(this.ActivityId, EBrochureType.Brochure) : null;
			if (brochure == null)
			{
				return;
			}
			List<int> list = new List<int>();
			for (int i = 0; i < brochure.Value.BookItemIdsLength; i++)
			{
				list.Add(brochure.Value.BookItemIds(i));
			}
			GenericLayout<SpringManorBrochureDetailPointItem, int> bottomPointLayout = this.BottomPointLayout;
			if (bottomPointLayout == null)
			{
				return;
			}
			bottomPointLayout.RefreshByData(list, delegate
			{
				GenericLayout<SpringManorBrochureDetailPointItem, int> bottomPointLayout2 = this.BottomPointLayout;
				if (bottomPointLayout2 == null)
				{
					return;
				}
				bottomPointLayout2.SelectGridProxy(this.CurrentDetailPointIndex, false);
			}, false);
		}

		// Token: 0x0603FD56 RID: 261462 RVA: 0x0105FA14 File Offset: 0x0105DC14
		private void SetDetailInfo(int configId)
		{
			SpringManorConfig instance = ConfigBase<SpringManorConfig>.Instance;
			BookItem? bookItem = (instance != null) ? instance.GetSpringManorBookItemById(configId) : null;
			if (bookItem == null)
			{
				return;
			}
			BookItemState bookItemState = BookItemState.BookItemRewarded;
			if (!this.IsHideReward)
			{
				SpringManorData activityData = ModelBase<SpringManorModel>.Instance.ActivityData;
				BookItemInfo bookItemInfo = (activityData != null) ? activityData.GetBookItemDataById(configId) : null;
				if (bookItemInfo == null)
				{
					return;
				}
				bookItemState = bookItemInfo.BookItemState;
			}
			bool flag = bookItemState == BookItemState.BookItemLock;
			bool flag2 = bookItemState == BookItemState.BookItemRewarded;
			bool uiactive = bookItemState == BookItemState.BookItemUnlock;
			UUIItem item = base.GetItem(2);
			if (item != null)
			{
				item.SetUIActive(flag);
			}
			if (flag)
			{
				base.SetTextureByPath(bookItem.Value.ScreenIconPath, base.GetTexture(1), null, null);
				UUIText text = base.GetText(3);
				if (text != null)
				{
					text.ShowTextNew(bookItem.Value.GuideText);
				}
				string key = StringUtils.IsBlank(bookItem.Value.DescriptionTitle) ? bookItem.Value.GuideTitle : bookItem.Value.DescriptionTitle;
				UUIText text2 = base.GetText(4);
				if (text2 != null)
				{
					text2.ShowTextNew(key);
				}
			}
			else
			{
				UUIText text3 = base.GetText(3);
				if (text3 != null)
				{
					text3.ShowTextNew(bookItem.Value.DescriptionText);
				}
				base.SetTextureByPath(bookItem.Value.ScreenIconDonePath, base.GetTexture(1), null, null);
				UUIText text4 = base.GetText(4);
				if (text4 != null)
				{
					text4.ShowTextNew(bookItem.Value.DescriptionTitle);
				}
			}
			SpringManorConfig instance2 = ConfigBase<SpringManorConfig>.Instance;
			List<TItem> rewardItems = (instance2 != null) ? instance2.GetRewardItem(bookItem.Value.DroptId) : null;
			this.SetRewardItems(rewardItems, flag2);
			UUIButtonComponent button = base.GetButton(11);
			if (button != null)
			{
				button.RootUIComp.Get().SetUIActive(flag);
			}
			UUIButtonComponent button2 = base.GetButton(14);
			if (button2 != null)
			{
				button2.RootUIComp.Get().SetUIActive(uiactive);
			}
			UUIItem item2 = base.GetItem(15);
			if (item2 == null)
			{
				return;
			}
			item2.SetUIActive(flag2);
		}

		// Token: 0x0603FD57 RID: 261463 RVA: 0x0105FC2C File Offset: 0x0105DE2C
		[NullableContext(2)]
		public void SetRewardItems(List<TItem> rewardItems, bool isRewarded)
		{
			this.IsRewarded = isRewarded;
			bool flag = !this.IsHideReward && rewardItems != null && rewardItems.Count > 0;
			GenericLayout<CommonItemSmallItemGrid, TItem> rewardItemLayout = this.RewardItemLayout;
			if (rewardItemLayout != null)
			{
				rewardItemLayout.SetActive(flag);
			}
			if (flag)
			{
				GenericLayout<CommonItemSmallItemGrid, TItem> rewardItemLayout2 = this.RewardItemLayout;
				if (rewardItemLayout2 != null)
				{
					rewardItemLayout2.RefreshByData(rewardItems, null, false);
				}
			}
			UUIItem item = base.GetItem(7);
			if (item == null)
			{
				return;
			}
			item.SetUIActive(flag);
		}

		// Token: 0x0603FD58 RID: 261464 RVA: 0x0105FC94 File Offset: 0x0105DE94
		private void OnClickBtnBrochurePre()
		{
			if (this.CurrentDetailPointIndex <= 0)
			{
				return;
			}
			this.SequencePlayer.PlayLevelSequenceByName("Switch_Left", false, null, false);
			this.CurrentDetailPointIndex--;
			this.UpdateArrowBtnVisible();
		}

		// Token: 0x0603FD59 RID: 261465 RVA: 0x0105FCDC File Offset: 0x0105DEDC
		private void OnClickBtnBrochureNext()
		{
			if (this.CurrentDetailPointIndex >= this.DetailIds.Count - 1)
			{
				return;
			}
			this.SequencePlayer.PlayLevelSequenceByName("Switch_Right", false, null, false);
			this.CurrentDetailPointIndex++;
			this.UpdateArrowBtnVisible();
		}

		// Token: 0x0603FD5A RID: 261466 RVA: 0x0105FD30 File Offset: 0x0105DF30
		private void UpdateArrowBtnVisible()
		{
			int currentDetailPointIndex = this.CurrentDetailPointIndex;
			UUIButtonComponent button = base.GetButton(12);
			TWeakObjectPtr<UUIItem>? tweakObjectPtr = (button != null) ? new TWeakObjectPtr<UUIItem>?(button.RootUIComp) : null;
			if (tweakObjectPtr != null)
			{
				UUIItem uuiitem = tweakObjectPtr.GetValueOrDefault().Get();
				if (uuiitem != null)
				{
					uuiitem.SetUIActive(currentDetailPointIndex < this.DetailIds.Count - 1);
				}
			}
			UUIButtonComponent button2 = base.GetButton(13);
			TWeakObjectPtr<UUIItem>? tweakObjectPtr2 = (button2 != null) ? new TWeakObjectPtr<UUIItem>?(button2.RootUIComp) : null;
			if (tweakObjectPtr2 != null)
			{
				UUIItem uuiitem2 = tweakObjectPtr2.GetValueOrDefault().Get();
				if (uuiitem2 == null)
				{
					return;
				}
				uuiitem2.SetUIActive(currentDetailPointIndex > 0);
			}
		}

		// Token: 0x0603FD5B RID: 261467 RVA: 0x0105FDE4 File Offset: 0x0105DFE4
		private void OnClickBtnTracking()
		{
			SpringManorConfig instance = ConfigBase<SpringManorConfig>.Instance;
			BookItem? bookItem = (instance != null) ? instance.GetSpringManorBookItemById(this.GetCurDetailConfigId) : null;
			if (bookItem == null)
			{
				return;
			}
			if (bookItem.Value.TeleportEntityId > 0)
			{
				this.TeleportPlayerToEntity(this.GetCurDetailConfigId).Forget();
			}
		}

		// Token: 0x0603FD5C RID: 261468 RVA: 0x0105FE40 File Offset: 0x0105E040
		private UniTask TeleportPlayerToEntity(int configId)
		{
			SpringManorBrochureDetailView.<TeleportPlayerToEntity>d__31 <TeleportPlayerToEntity>d__;
			<TeleportPlayerToEntity>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<TeleportPlayerToEntity>d__.configId = configId;
			<TeleportPlayerToEntity>d__.<>1__state = -1;
			<TeleportPlayerToEntity>d__.<>t__builder.Start<SpringManorBrochureDetailView.<TeleportPlayerToEntity>d__31>(ref <TeleportPlayerToEntity>d__);
			return <TeleportPlayerToEntity>d__.<>t__builder.Task;
		}

		// Token: 0x04023DEE RID: 146926
		[Nullable(2)]
		private PopupCaptionItem CaptionItem;

		// Token: 0x04023DEF RID: 146927
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private GenericLayout<CommonItemSmallItemGrid, TItem> RewardItemLayout;

		// Token: 0x04023DF0 RID: 146928
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private GenericLayout<SpringManorBrochureDetailPointItem, int> BottomPointLayout;

		// Token: 0x04023DF1 RID: 146929
		private bool IsRewarded;

		// Token: 0x04023DF2 RID: 146930
		private int CurrentDetailPointIndex;

		// Token: 0x04023DF3 RID: 146931
		private readonly List<int> DetailIds = new List<int>();

		// Token: 0x04023DF4 RID: 146932
		private int ActivityId;

		// Token: 0x04023DF5 RID: 146933
		private bool IsHideReward;

		// Token: 0x04023DF6 RID: 146934
		[Nullable(2)]
		private LevelSequencePlayer SequencePlayer;
	}
}
