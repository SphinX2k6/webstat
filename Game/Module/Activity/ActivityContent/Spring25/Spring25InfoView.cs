using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Common;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.Activity.ActivityContent.Spring25
{
	// Token: 0x02006364 RID: 25444
	[NullableContext(1)]
	[Nullable(0)]
	public class Spring25InfoView : UiViewBase
	{
		// Token: 0x0603FE15 RID: 261653 RVA: 0x01062E43 File Offset: 0x01061043
		public Spring25InfoView(UiViewInfo info) : base(info)
		{
		}

		// Token: 0x17009CD2 RID: 40146
		// (get) Token: 0x0603FE16 RID: 261654 RVA: 0x01062E4C File Offset: 0x0106104C
		// (set) Token: 0x0603FE17 RID: 261655 RVA: 0x01062E54 File Offset: 0x01061054
		private PopupCaptionItem CaptionItem { get; set; }

		// Token: 0x17009CD3 RID: 40147
		// (get) Token: 0x0603FE18 RID: 261656 RVA: 0x01062E5D File Offset: 0x0106105D
		// (set) Token: 0x0603FE19 RID: 261657 RVA: 0x01062E65 File Offset: 0x01061065
		private GenericLayout<ContentItem, Spring25InfoContentData> ContentLayout { get; set; }

		// Token: 0x17009CD4 RID: 40148
		// (get) Token: 0x0603FE1A RID: 261658 RVA: 0x01062E6E File Offset: 0x0106106E
		// (set) Token: 0x0603FE1B RID: 261659 RVA: 0x01062E76 File Offset: 0x01061076
		private GenericLayout<ProgressItem, Spring25InfoProgressData> ProgressLayout { get; set; }

		// Token: 0x17009CD5 RID: 40149
		// (get) Token: 0x0603FE1C RID: 261660 RVA: 0x01062E7F File Offset: 0x0106107F
		// (set) Token: 0x0603FE1D RID: 261661 RVA: 0x01062E87 File Offset: 0x01061087
		private UiSequencePlayer BottomPlayer { get; set; }

		// Token: 0x17009CD6 RID: 40150
		// (get) Token: 0x0603FE1E RID: 261662 RVA: 0x01062E90 File Offset: 0x01061090
		// (set) Token: 0x0603FE1F RID: 261663 RVA: 0x01062E98 File Offset: 0x01061098
		private UUIInturnAnimController ContentPlayer { get; set; }

		// Token: 0x0603FE20 RID: 261664 RVA: 0x01062EA4 File Offset: 0x010610A4
		protected unsafe override void OnRegisterComponent()
		{
			int num = 13;
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
			*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIButtonComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(5, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(6, typeof(UUIHorizontalLayout));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(7, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(8, typeof(UUIButtonComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(9, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(10, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(11, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(12, typeof(UUIItem));
			this.ComponentRegisterInfos = list;
			num2 = 2;
			List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
			CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
			Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
			num = 0;
			*span2[num] = new ValueTuple<int, Delegate>(3, new Action(this.HandleLookClick));
			num++;
			*span2[num] = new ValueTuple<int, Delegate>(8, new Action(this.HandleBonusClick));
			this.BtnBindInfo = list2;
		}

		// Token: 0x0603FE21 RID: 261665 RVA: 0x010630E0 File Offset: 0x010612E0
		protected override UniTask OnBeforeStartAsync()
		{
			Spring25InfoView.<OnBeforeStartAsync>d__23 <OnBeforeStartAsync>d__;
			<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeStartAsync>d__.<>4__this = this;
			<OnBeforeStartAsync>d__.<>1__state = -1;
			<OnBeforeStartAsync>d__.<>t__builder.Start<Spring25InfoView.<OnBeforeStartAsync>d__23>(ref <OnBeforeStartAsync>d__);
			return <OnBeforeStartAsync>d__.<>t__builder.Task;
		}

		// Token: 0x0603FE22 RID: 261666 RVA: 0x01063123 File Offset: 0x01061323
		protected override void OnStart()
		{
			this.RefreshByOpenParam();
		}

		// Token: 0x0603FE23 RID: 261667 RVA: 0x0106312B File Offset: 0x0106132B
		protected override void OnAddEventListener()
		{
			Singleton<EventSystem>.Instance.Add(EEventName.Spring25DrawRewardDone, new Action(this.HandleSpring25DrawRewardDone));
			Singleton<EventSystem>.Instance.Add(EEventName.Spring25SkinRewardDone, new Action(this.HandleSpring25SkinRewardDone));
		}

		// Token: 0x0603FE24 RID: 261668 RVA: 0x01063165 File Offset: 0x01061365
		protected override void OnRemoveEventListener()
		{
			Singleton<EventSystem>.Instance.Remove(EEventName.Spring25DrawRewardDone, new Action(this.HandleSpring25DrawRewardDone));
			Singleton<EventSystem>.Instance.Remove(EEventName.Spring25SkinRewardDone, new Action(this.HandleSpring25SkinRewardDone));
		}

		// Token: 0x0603FE25 RID: 261669 RVA: 0x010631A0 File Offset: 0x010613A0
		private void RefreshByOpenParam()
		{
			Spring25InfoViewData spring25InfoViewData = this.OpenParam as Spring25InfoViewData;
			if (spring25InfoViewData == null)
			{
				return;
			}
			this.CaptionItem.SetTitleByTextIdAndArgNew(spring25InfoViewData.TitleTextId, Array.Empty<object>());
			UUIText text = base.GetText(4);
			if (text != null)
			{
				text.SetText(spring25InfoViewData.CurrentNum, true);
			}
			Singleton<LguiUtil>.Instance.TrySetLocalTextNew(base.GetText(5), spring25InfoViewData.TotalNumTextId, new <>z__ReadOnlySingleElementList<object>(spring25InfoViewData.TotalNumTextArg));
			this.RefreshContentAsync(spring25InfoViewData.ContentList);
			this.RefreshProgressAsync(spring25InfoViewData.ProgressList);
			this.RefreshBottomByState(spring25InfoViewData.BottomState);
		}

		// Token: 0x0603FE26 RID: 261670 RVA: 0x01063234 File Offset: 0x01061434
		private void RefreshBottomByState(ESpring25InfoBottomState state)
		{
			UUIButtonComponent button = base.GetButton(8);
			if (button != null)
			{
				button.RootUIComp.Get().SetUIActive(state == ESpring25InfoBottomState.QuestAllDoneFirstTime || state == ESpring25InfoBottomState.QuestAllDoneButNotFirst);
			}
			UUIItem item = base.GetItem(10);
			if (item != null)
			{
				item.SetUIActive(state <= ESpring25InfoBottomState.QuestAllDoneFirstTime);
			}
			UUIItem item2 = base.GetItem(11);
			if (item2 != null)
			{
				item2.SetUIActive(state <= ESpring25InfoBottomState.QuestAllDoneFirstTime);
			}
			if (state == ESpring25InfoBottomState.QuestAllDoneFirstTime)
			{
				LocalStorage.SetPlayer<bool>(ELocalStoragePlayerKey.Spring25FirstTimeTaskAllDone, false);
				this.BottomPlayer.LitePlayAsync("Switch", false, false);
			}
			UUIItem item3 = base.GetItem(12);
			if (item3 == null)
			{
				return;
			}
			item3.SetUIActive(state == ESpring25InfoBottomState.SkinRewarded);
		}

		// Token: 0x0603FE27 RID: 261671 RVA: 0x010632D4 File Offset: 0x010614D4
		private UniTask RefreshContentAsync(List<Spring25InfoContentData> dataList)
		{
			Spring25InfoView.<RefreshContentAsync>d__29 <RefreshContentAsync>d__;
			<RefreshContentAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<RefreshContentAsync>d__.<>4__this = this;
			<RefreshContentAsync>d__.dataList = dataList;
			<RefreshContentAsync>d__.<>1__state = -1;
			<RefreshContentAsync>d__.<>t__builder.Start<Spring25InfoView.<RefreshContentAsync>d__29>(ref <RefreshContentAsync>d__);
			return <RefreshContentAsync>d__.<>t__builder.Task;
		}

		// Token: 0x0603FE28 RID: 261672 RVA: 0x01063320 File Offset: 0x01061520
		private UniTask RefreshProgressAsync(List<Spring25InfoProgressData> dataList)
		{
			Spring25InfoView.<RefreshProgressAsync>d__30 <RefreshProgressAsync>d__;
			<RefreshProgressAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<RefreshProgressAsync>d__.<>4__this = this;
			<RefreshProgressAsync>d__.dataList = dataList;
			<RefreshProgressAsync>d__.<>1__state = -1;
			<RefreshProgressAsync>d__.<>t__builder.Start<Spring25InfoView.<RefreshProgressAsync>d__30>(ref <RefreshProgressAsync>d__);
			return <RefreshProgressAsync>d__.<>t__builder.Task;
		}

		// Token: 0x0603FE29 RID: 261673 RVA: 0x0106336B File Offset: 0x0106156B
		private ContentItem BuildContentItem()
		{
			return new ContentItem();
		}

		// Token: 0x0603FE2A RID: 261674 RVA: 0x01063372 File Offset: 0x01061572
		private ProgressItem BuildProgressItem()
		{
			return new ProgressItem();
		}

		// Token: 0x0603FE2B RID: 261675 RVA: 0x01063379 File Offset: 0x01061579
		private void HandleCloseClick()
		{
			base.CloseMe(null);
		}

		// Token: 0x0603FE2C RID: 261676 RVA: 0x01063382 File Offset: 0x01061582
		private void HandleLookClick()
		{
			ControllerBase<ActivitySpring25Controller>.Instance.HandleOpenSkinPreview();
		}

		// Token: 0x0603FE2D RID: 261677 RVA: 0x0106338E File Offset: 0x0106158E
		private void HandleBonusClick()
		{
			ControllerBase<ActivitySpring25Controller>.Instance.HandleRequestRewardSkin();
		}

		// Token: 0x0603FE2E RID: 261678 RVA: 0x0106339C File Offset: 0x0106159C
		private void HandleSpring25DrawRewardDone()
		{
			Spring25InfoViewData spring25InfoViewData = ModelBase<Spring25Model>.Instance.BuildInfoViewData();
			this.OpenParam = spring25InfoViewData;
			this.RefreshContentAsync(spring25InfoViewData.ContentList);
		}

		// Token: 0x0603FE2F RID: 261679 RVA: 0x010633C8 File Offset: 0x010615C8
		private void HandleSpring25SkinRewardDone()
		{
			Spring25InfoViewData spring25InfoViewData = ModelBase<Spring25Model>.Instance.BuildInfoViewData();
			this.OpenParam = spring25InfoViewData;
			this.RefreshBottomByState(spring25InfoViewData.BottomState);
		}

		// Token: 0x0200C3C7 RID: 50119
		[NullableContext(0)]
		private class EComponent
		{
			// Token: 0x0403C4DA RID: 247002
			public const int CaptionItem = 0;

			// Token: 0x0403C4DB RID: 247003
			public const int ContentLayout = 1;

			// Token: 0x0403C4DC RID: 247004
			public const int ContentTemplateItem = 2;

			// Token: 0x0403C4DD RID: 247005
			public const int LookButton = 3;

			// Token: 0x0403C4DE RID: 247006
			public const int CurrentNumText = 4;

			// Token: 0x0403C4DF RID: 247007
			public const int TotalNumText = 5;

			// Token: 0x0403C4E0 RID: 247008
			public const int ProgressLayout = 6;

			// Token: 0x0403C4E1 RID: 247009
			public const int ProgressTemplateItem = 7;

			// Token: 0x0403C4E2 RID: 247010
			public const int BonusButton = 8;

			// Token: 0x0403C4E3 RID: 247011
			public const int BottomItem = 9;

			// Token: 0x0403C4E4 RID: 247012
			public const int ProgressItem = 10;

			// Token: 0x0403C4E5 RID: 247013
			public const int CountItem = 11;

			// Token: 0x0403C4E6 RID: 247014
			public const int SkinRewardedItem = 12;
		}
	}
}
