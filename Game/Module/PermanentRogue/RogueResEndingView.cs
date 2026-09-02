using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.PermanentRogue
{
	// Token: 0x02005677 RID: 22135
	[NullableContext(1)]
	[Nullable(0)]
	public class RogueResEndingView : UiViewBase
	{
		// Token: 0x06038668 RID: 231016 RVA: 0x00E4846C File Offset: 0x00E4666C
		public RogueResEndingView(UiViewInfo viewInfo) : base(viewInfo)
		{
		}

		// Token: 0x06038669 RID: 231017 RVA: 0x00E48498 File Offset: 0x00E46698
		protected override void OnRegisterComponent()
		{
			this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
			{
				new ValueTuple<int, Type>(0, typeof(UUIItem)),
				new ValueTuple<int, Type>(1, typeof(UUIText)),
				new ValueTuple<int, Type>(2, typeof(UUIHorizontalLayout)),
				new ValueTuple<int, Type>(3, typeof(UUIItem)),
				new ValueTuple<int, Type>(4, typeof(UUIItem)),
				new ValueTuple<int, Type>(5, typeof(UUISliderComponent)),
				new ValueTuple<int, Type>(6, typeof(UUIButtonComponent)),
				new ValueTuple<int, Type>(7, typeof(UUIButtonComponent)),
				new ValueTuple<int, Type>(8, typeof(UUIScrollViewWithScrollbarComponent)),
				new ValueTuple<int, Type>(9, typeof(UUIItem)),
				new ValueTuple<int, Type>(10, typeof(UUIItem)),
				new ValueTuple<int, Type>(11, typeof(UUIItem))
			};
			this.BtnBindInfo = new List<ValueTuple<int, Delegate>>
			{
				new ValueTuple<int, Delegate>(6, new Action(this.OnClickLeft)),
				new ValueTuple<int, Delegate>(7, new Action(this.OnClickRight))
			};
		}

		// Token: 0x0603866A RID: 231018 RVA: 0x00E485F8 File Offset: 0x00E467F8
		protected override UniTask OnBeforeStartAsync()
		{
			RogueResEndingView.<OnBeforeStartAsync>d__12 <OnBeforeStartAsync>d__;
			<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeStartAsync>d__.<>4__this = this;
			<OnBeforeStartAsync>d__.<>1__state = -1;
			<OnBeforeStartAsync>d__.<>t__builder.Start<RogueResEndingView.<OnBeforeStartAsync>d__12>(ref <OnBeforeStartAsync>d__);
			return <OnBeforeStartAsync>d__.<>t__builder.Task;
		}

		// Token: 0x0603866B RID: 231019 RVA: 0x00E4863B File Offset: 0x00E4683B
		protected override void OnStart()
		{
			this.SeasonId = (int)this.OpenParam;
		}

		// Token: 0x0603866C RID: 231020 RVA: 0x00E48650 File Offset: 0x00E46850
		protected override void OnBeforeShow()
		{
			int[] endingAwardCount = ModelBase<ActivityPermanentRogueModel>.Instance.GetEndingAwardCount(this.SeasonId);
			RogueButtonItemA btnMulti = this.BtnMulti;
			DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(1, 2);
			defaultInterpolatedStringHandler.AppendFormatted<int>(endingAwardCount[0]);
			defaultInterpolatedStringHandler.AppendLiteral("/");
			defaultInterpolatedStringHandler.AppendFormatted<int>(endingAwardCount[1]);
			btnMulti.SetNum(defaultInterpolatedStringHandler.ToStringAndClear());
			RogueButtonItemA btnMulti2 = this.BtnMulti;
			if (btnMulti2 != null)
			{
				btnMulti2.BindRedDot(ERedDotName.RogueResEnding, new int?(this.SeasonId));
			}
			this.EndingIdList = ModelBase<ActivityPermanentRogueModel>.Instance.GetEndingListBySeasonId(this.SeasonId);
			int[] endingCount = ModelBase<ActivityPermanentRogueModel>.Instance.GetEndingCount(this.SeasonId);
			UUIItem item = base.GetItem(9);
			if (item != null)
			{
				item.SetUIActive(endingCount[0] == 0);
			}
			UUIItem item2 = base.GetItem(10);
			if (item2 != null)
			{
				item2.SetUIActive(endingCount[0] != 0);
			}
			UUIItem item3 = base.GetItem(11);
			if (item3 == null)
			{
				return;
			}
			item3.SetUIActive(endingCount[0] != 0);
		}

		// Token: 0x0603866D RID: 231021 RVA: 0x00E4873B File Offset: 0x00E4693B
		protected override void OnBeforeHide()
		{
			RogueButtonItemA btnMulti = this.BtnMulti;
			if (btnMulti == null)
			{
				return;
			}
			btnMulti.UnBindRedDot();
		}

		// Token: 0x0603866E RID: 231022 RVA: 0x00E4874D File Offset: 0x00E4694D
		protected override void OnBeforeDestroy()
		{
			this.CaptionItem = null;
			this.BtnMulti = null;
		}

		// Token: 0x0603866F RID: 231023 RVA: 0x00E48760 File Offset: 0x00E46960
		protected override void OnAddEventListener()
		{
			Singleton<EventSystem>.Instance.Add(EEventName.PermanentRogueRewardUpdate, new Action(this.OnRefreshAward));
			Singleton<EventSystem>.Instance.Add(EEventName.RogueResEndingRedDotUpdate, new Action(this.RefreshEndingRedDotList));
			Singleton<EventSystem>.Instance.Add<int>(EEventName.RogueResEndingSwitch, new Action<int>(this.RefreshEndingScrollChange));
			Singleton<EventSystem>.Instance.Add(EEventName.OnActivitySequenceEmitEvent, new Action<string>(this.OnStartAnimStart));
			base.GetSlider(5).OnValueChangeCb.Bind(new Action<float>(this.OnSizeSliderValueChanged));
			base.GetScrollViewWithScrollbar(8).OnScrollValueChange.Bind(new Action<FVector2D>(this.OnScrollValueChanged));
		}

		// Token: 0x06038670 RID: 231024 RVA: 0x00E48818 File Offset: 0x00E46A18
		protected override void OnRemoveEventListener()
		{
			Singleton<EventSystem>.Instance.Remove(EEventName.PermanentRogueRewardUpdate, new Action(this.OnRefreshAward));
			Singleton<EventSystem>.Instance.Remove(EEventName.RogueResEndingRedDotUpdate, new Action(this.RefreshEndingRedDotList));
			Singleton<EventSystem>.Instance.Remove(EEventName.RogueResEndingSwitch, new Action<int>(this.RefreshEndingScrollChange));
			Singleton<EventSystem>.Instance.Remove(EEventName.OnActivitySequenceEmitEvent, new Action<string>(this.OnStartAnimStart));
			base.GetSlider(5).OnValueChangeCb.Unbind();
			base.GetScrollViewWithScrollbar(8).OnScrollValueChange.Unbind();
		}

		// Token: 0x06038671 RID: 231025 RVA: 0x00E488B7 File Offset: 0x00E46AB7
		private RogueEndingCollectionItem InitEndingItem()
		{
			return new RogueEndingCollectionItem
			{
				OnItemClickCall = new Action<int>(this.OnClickItem)
			};
		}

		// Token: 0x06038672 RID: 231026 RVA: 0x00E488D0 File Offset: 0x00E46AD0
		private void OnClickBack()
		{
			base.CloseMe(null);
		}

		// Token: 0x06038673 RID: 231027 RVA: 0x00E488DC File Offset: 0x00E46ADC
		private void OnClickItem(int id)
		{
			bool endingIsUnlock = ModelBase<ActivityPermanentRogueModel>.Instance.GetEndingIsUnlock(id);
			if (!endingIsUnlock)
			{
				ControllerBase<ScrollingTipsController>.Instance.ShowTipsByTextId("Rogue_End_S1_Lock", Array.Empty<object>());
				return;
			}
			if (endingIsUnlock && !ModelBase<ActivityPermanentRogueModel>.Instance.GetCacheEndingOpen(id))
			{
				ModelBase<ActivityPermanentRogueModel>.Instance.SetCacheEndingOpen(id);
			}
			Singleton<UiManager>.Instance.OpenView(EUiViewName.RogueResEndingSubView, id, null);
		}

		// Token: 0x06038674 RID: 231028 RVA: 0x00E4893E File Offset: 0x00E46B3E
		private void OnClickTask()
		{
			Singleton<UiManager>.Instance.OpenView(EUiViewName.ActivityRewardPopUpView, ModelBase<ActivityPermanentRogueModel>.Instance.GetEndingAwardViewData(this.SeasonId), delegate(bool success, int viewId)
			{
				if (success)
				{
					base.AddChildViewById(viewId);
				}
			});
		}

		// Token: 0x06038675 RID: 231029 RVA: 0x00E4896B File Offset: 0x00E46B6B
		private void OnRefreshAward()
		{
		}

		// Token: 0x06038676 RID: 231030 RVA: 0x00E48970 File Offset: 0x00E46B70
		private void OnClickLeft()
		{
			int count = this.EndingRedDotList.Count;
			for (int i = count - 1; i >= 0; i--)
			{
				UUIItem itemByIndex = this.EndingScrollView.GetItemByIndex(this.EndingRedDotList[i]);
				if (this.EndingScrollView.IsItemInViewport(itemByIndex, 0.1f) == EOutOfBoundsType.OutOfBegin)
				{
					UUIItem itemByIndex2 = this.EndingScrollView.GetItemByIndex(this.EndingRedDotList[i]);
					this.EndingScrollView.ScrollTo(itemByIndex2, false);
					return;
				}
			}
			UUIItem itemByIndex3 = this.EndingScrollView.GetItemByIndex(this.EndingRedDotList[count - 1]);
			this.EndingScrollView.ScrollTo(itemByIndex3, false);
		}

		// Token: 0x06038677 RID: 231031 RVA: 0x00E48A14 File Offset: 0x00E46C14
		private void OnClickRight()
		{
			int count = this.EndingRedDotList.Count;
			for (int i = 0; i <= count - 2; i++)
			{
				UUIItem itemByIndex = this.EndingScrollView.GetItemByIndex(this.EndingRedDotList[i]);
				if (this.EndingScrollView.IsItemInViewport(itemByIndex, 0.1f) == EOutOfBoundsType.OutOfEnd)
				{
					UUIItem itemByIndex2 = this.EndingScrollView.GetItemByIndex(this.EndingRedDotList[i]);
					this.EndingScrollView.ScrollTo(itemByIndex2, false);
					return;
				}
			}
			UUIItem itemByIndex3 = this.EndingScrollView.GetItemByIndex(this.EndingRedDotList[count - 1]);
			this.EndingScrollView.ScrollTo(itemByIndex3, false);
		}

		// Token: 0x06038678 RID: 231032 RVA: 0x00E48AB6 File Offset: 0x00E46CB6
		private void OnSizeSliderValueChanged(float value)
		{
			UUIScrollViewWithScrollbarComponent scrollViewWithScrollbar = base.GetScrollViewWithScrollbar(8);
			if (scrollViewWithScrollbar != null)
			{
				scrollViewWithScrollbar.SetScrollProgress(1f - value);
			}
			this.StartFromSlider = true;
		}

		// Token: 0x06038679 RID: 231033 RVA: 0x00E48AD8 File Offset: 0x00E46CD8
		private void OnScrollValueChanged(FVector2D inVector)
		{
			float x = inVector.X;
			UUISliderComponent slider = base.GetSlider(5);
			if (!this.StartFromSlider && slider != null)
			{
				slider.SetValue(1f - x, false);
			}
			this.StartFromSlider = false;
			this.RefreshRedDotBtn();
		}

		// Token: 0x0603867A RID: 231034 RVA: 0x00E48B1C File Offset: 0x00E46D1C
		private void RefreshEndingRedDotList()
		{
			this.EndingRedDotList.Clear();
			for (int i = 0; i < this.EndingIdList.Count; i++)
			{
				int num = this.EndingIdList[i];
				if (ModelBase<ActivityPermanentRogueModel>.Instance.GetEndingIsUnlock(num) && !ModelBase<ActivityPermanentRogueModel>.Instance.GetCacheEndingOpen(num))
				{
					this.EndingRedDotList.Add(i);
				}
			}
			this.RefreshRedDotBtn();
		}

		// Token: 0x0603867B RID: 231035 RVA: 0x00E48B84 File Offset: 0x00E46D84
		private void RefreshEndingScrollChange(int endingId)
		{
			int num = this.EndingIdList.IndexOf(endingId);
			if (num == -1)
			{
				return;
			}
			UUIItem itemByIndex = this.EndingScrollView.GetItemByIndex(num);
			this.EndingScrollView.ScrollTo(itemByIndex, false);
		}

		// Token: 0x0603867C RID: 231036 RVA: 0x00E48BBD File Offset: 0x00E46DBD
		private void OnStartAnimStart(string param)
		{
			this.RefreshEnding();
		}

		// Token: 0x0603867D RID: 231037 RVA: 0x00E48BC8 File Offset: 0x00E46DC8
		private void RefreshEnding()
		{
			for (int i = 0; i < this.EndingIdList.Count; i++)
			{
				IRogueEndingItemParam item = new RogueEndingItemParam
				{
					ConfigId = this.EndingIdList[i],
					Index = i + 1,
					IsSubView = false,
					IsUnlock = ModelBase<ActivityPermanentRogueModel>.Instance.GetEndingIsUnlock(this.EndingIdList[i]),
					Rotation = new float?((i % 2 == 0) ? 9f : -9f)
				};
				this.EndingItemList.Add(item);
			}
			GenericScrollViewNew<RogueEndingCollectionItem, IRogueEndingItemParam> endingScrollView = this.EndingScrollView;
			if (endingScrollView == null)
			{
				return;
			}
			endingScrollView.RefreshByData(this.EndingItemList, new Action(this.RefreshEndingRedDotList), true);
		}

		// Token: 0x0603867E RID: 231038 RVA: 0x00E48C7C File Offset: 0x00E46E7C
		private void RefreshRedDotBtn()
		{
			if (this.EndingRedDotList.Count == 0)
			{
				UUIButtonComponent button = base.GetButton(6);
				if (button != null)
				{
					button.RootUIComp.Get().SetUIActive(false);
				}
				UUIButtonComponent button2 = base.GetButton(7);
				if (button2 == null)
				{
					return;
				}
				button2.RootUIComp.Get().SetUIActive(false);
				return;
			}
			else
			{
				UUIItem itemByIndex = this.EndingScrollView.GetItemByIndex(this.EndingRedDotList[0]);
				UUIItem itemByIndex2 = this.EndingScrollView.GetItemByIndex(this.EndingRedDotList[this.EndingRedDotList.Count - 1]);
				EOutOfBoundsType eoutOfBoundsType = this.EndingScrollView.IsItemInViewport(itemByIndex, 0.1f);
				UUIButtonComponent button3 = base.GetButton(6);
				if (button3 != null)
				{
					button3.RootUIComp.Get().SetUIActive(eoutOfBoundsType == EOutOfBoundsType.OutOfBegin);
				}
				EOutOfBoundsType eoutOfBoundsType2 = this.EndingScrollView.IsItemInViewport(itemByIndex2, 0.1f);
				UUIButtonComponent button4 = base.GetButton(7);
				if (button4 == null)
				{
					return;
				}
				button4.RootUIComp.Get().SetUIActive(eoutOfBoundsType2 == EOutOfBoundsType.OutOfEnd);
				return;
			}
		}

		// Token: 0x040202DC RID: 131804
		[Nullable(2)]
		private PopupCaptionItem CaptionItem;

		// Token: 0x040202DD RID: 131805
		[Nullable(2)]
		private RogueButtonItemA BtnMulti;

		// Token: 0x040202DE RID: 131806
		private const float ROTATION_PARAM = 9f;

		// Token: 0x040202DF RID: 131807
		private const float REDDOT_TOLERANCE = 0.1f;

		// Token: 0x040202E0 RID: 131808
		[Nullable(new byte[]
		{
			2,
			1,
			1
		})]
		private GenericScrollViewNew<RogueEndingCollectionItem, IRogueEndingItemParam> EndingScrollView;

		// Token: 0x040202E1 RID: 131809
		private int SeasonId;

		// Token: 0x040202E2 RID: 131810
		private List<int> EndingIdList = new List<int>();

		// Token: 0x040202E3 RID: 131811
		private readonly List<int> EndingRedDotList = new List<int>();

		// Token: 0x040202E4 RID: 131812
		private readonly List<IRogueEndingItemParam> EndingItemList = new List<IRogueEndingItemParam>();

		// Token: 0x040202E5 RID: 131813
		private bool StartFromSlider;
	}
}
