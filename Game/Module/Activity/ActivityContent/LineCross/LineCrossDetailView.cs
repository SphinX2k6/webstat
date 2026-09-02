using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.Activity.ActivityContent.LineCross
{
	// Token: 0x02006766 RID: 26470
	[NullableContext(1)]
	[Nullable(0)]
	public class LineCrossDetailView : UiViewBase
	{
		// Token: 0x06041FB1 RID: 270257 RVA: 0x010EDD59 File Offset: 0x010EBF59
		public LineCrossDetailView(UiViewInfo info) : base(info)
		{
		}

		// Token: 0x06041FB2 RID: 270258 RVA: 0x010EDD70 File Offset: 0x010EBF70
		protected unsafe override void OnRegisterComponent()
		{
			this.LineCrossDetailViewModel = (this.OpenParam as LineCrossDetailViewModel);
			LineCrossDetailViewModel lineCrossDetailViewModel = this.LineCrossDetailViewModel;
			if (lineCrossDetailViewModel != null)
			{
				lineCrossDetailViewModel.RegisterView(this);
			}
			int num = 12;
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
			*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(5, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(6, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(7, typeof(UUIScrollViewWithScrollbarComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(8, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(9, typeof(UUIButtonComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(10, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(11, typeof(UUIText));
			this.ComponentRegisterInfos = list;
			num2 = 1;
			List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
			CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
			Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
			num = 0;
			*span2[num] = new ValueTuple<int, Delegate>(9, new Action(this.OnClickBtn));
			this.BtnBindInfo = list2;
		}

		// Token: 0x06041FB3 RID: 270259 RVA: 0x010EDF88 File Offset: 0x010EC188
		private void OnClickBtn()
		{
			LineCrossActivityController instance = ControllerBase<LineCrossActivityController>.Instance;
			LineCrossDetailViewModel lineCrossDetailViewModel = this.LineCrossDetailViewModel;
			int? num;
			if (lineCrossDetailViewModel == null)
			{
				num = null;
			}
			else
			{
				LineCrossActivityData lineCrossActivityData = lineCrossDetailViewModel.LineCrossActivityData;
				num = ((lineCrossActivityData != null) ? new int?(lineCrossActivityData.Id) : null);
			}
			int? num2 = num;
			int valueOrDefault = num2.GetValueOrDefault();
			LineCrossDetailViewModel lineCrossDetailViewModel2 = this.LineCrossDetailViewModel;
			instance.RequestStartChallenge(valueOrDefault, (lineCrossDetailViewModel2 != null) ? lineCrossDetailViewModel2.GetCurrentChallengeId() : 0);
		}

		// Token: 0x06041FB4 RID: 270260 RVA: 0x010EDFEC File Offset: 0x010EC1EC
		protected override UniTask OnBeforeStartAsync()
		{
			LineCrossDetailView.<OnBeforeStartAsync>d__8 <OnBeforeStartAsync>d__;
			<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeStartAsync>d__.<>4__this = this;
			<OnBeforeStartAsync>d__.<>1__state = -1;
			<OnBeforeStartAsync>d__.<>t__builder.Start<LineCrossDetailView.<OnBeforeStartAsync>d__8>(ref <OnBeforeStartAsync>d__);
			return <OnBeforeStartAsync>d__.<>t__builder.Task;
		}

		// Token: 0x06041FB5 RID: 270261 RVA: 0x010EE02F File Offset: 0x010EC22F
		private void OnCloseBtnClick()
		{
			base.CloseMe(null);
		}

		// Token: 0x06041FB6 RID: 270262 RVA: 0x010EE038 File Offset: 0x010EC238
		public void RefreshRewardLayout(List<TItem> list)
		{
			GenericScrollViewNew<CommonItemSmallItemGrid, TItem> rewardLayout = this.RewardLayout;
			if (rewardLayout == null)
			{
				return;
			}
			rewardLayout.RefreshByData(list, null, false);
		}

		// Token: 0x06041FB7 RID: 270263 RVA: 0x010EE04D File Offset: 0x010EC24D
		protected override void OnBeforeShow()
		{
			LineCrossDetailViewModel lineCrossDetailViewModel = this.LineCrossDetailViewModel;
			if (lineCrossDetailViewModel == null)
			{
				return;
			}
			lineCrossDetailViewModel.OnShowView();
		}

		// Token: 0x06041FB8 RID: 270264 RVA: 0x010EE05F File Offset: 0x010EC25F
		public void ShowDescText(string desc)
		{
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(6), desc, Array.Empty<object>());
		}

		// Token: 0x06041FB9 RID: 270265 RVA: 0x010EE078 File Offset: 0x010EC278
		public void RefreshTitleText(string title)
		{
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(5), title, Array.Empty<object>());
		}

		// Token: 0x06041FBA RID: 270266 RVA: 0x010EE091 File Offset: 0x010EC291
		public void RefreshDifficultDescText(string desc)
		{
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(11), desc, Array.Empty<object>());
		}

		// Token: 0x06041FBB RID: 270267 RVA: 0x010EE0AB File Offset: 0x010EC2AB
		public void RefreshNumText(int num)
		{
			UUIText text = base.GetText(4);
			if (text == null)
			{
				return;
			}
			text.SetText(num.ToString(), true);
		}

		// Token: 0x06041FBC RID: 270268 RVA: 0x010EE0C8 File Offset: 0x010EC2C8
		public void RefreshDifficultItem(List<int> dataList, int selectData)
		{
			for (int i = 0; i < this.LineCrossItemList.Count; i++)
			{
				DifficultLineCrossItem difficultLineCrossItem = this.LineCrossItemList[i];
				if (i < dataList.Count)
				{
					difficultLineCrossItem.SetModel(this.LineCrossDetailViewModel);
					difficultLineCrossItem.Refresh(dataList[i], selectData);
					difficultLineCrossItem.Show(null);
				}
				else
				{
					difficultLineCrossItem.Hide(null);
				}
			}
		}

		// Token: 0x06041FBD RID: 270269 RVA: 0x010EE12C File Offset: 0x010EC32C
		public void RefreshDifficultItemSelection(int data)
		{
			foreach (DifficultLineCrossItem difficultLineCrossItem in this.LineCrossItemList)
			{
				difficultLineCrossItem.RefreshToggle(data);
			}
		}

		// Token: 0x06041FBE RID: 270270 RVA: 0x010EE180 File Offset: 0x010EC380
		public void RefreshMiddleByChallengeState(bool ifHiddenGroup, ELineCrossGroupState state)
		{
			LineCrossClawItem lineCrossClawItem = this.LineCrossClawItem;
			if (lineCrossClawItem == null)
			{
				return;
			}
			lineCrossClawItem.Refresh(ifHiddenGroup, state);
		}

		// Token: 0x06041FBF RID: 270271 RVA: 0x010EE194 File Offset: 0x010EC394
		public void PlaySwitchSequence()
		{
			base.PlaySequence("Switch", null, false);
		}

		// Token: 0x04024CE5 RID: 150757
		private readonly List<DifficultLineCrossItem> LineCrossItemList = new List<DifficultLineCrossItem>();

		// Token: 0x04024CE6 RID: 150758
		[Nullable(2)]
		private PopupCaptionItem CaptionItem;

		// Token: 0x04024CE7 RID: 150759
		[Nullable(2)]
		private LineCrossDetailViewModel LineCrossDetailViewModel;

		// Token: 0x04024CE8 RID: 150760
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private GenericScrollViewNew<CommonItemSmallItemGrid, TItem> RewardLayout;

		// Token: 0x04024CE9 RID: 150761
		[Nullable(2)]
		private LineCrossClawItem LineCrossClawItem;

		// Token: 0x0200C782 RID: 51074
		[NullableContext(0)]
		private class EComponent
		{
			// Token: 0x0403D6BD RID: 251581
			public const int CaptionItem = 0;

			// Token: 0x0403D6BE RID: 251582
			public const int DifficultItem1 = 1;

			// Token: 0x0403D6BF RID: 251583
			public const int DifficultItem2 = 2;

			// Token: 0x0403D6C0 RID: 251584
			public const int DifficultItem3 = 3;

			// Token: 0x0403D6C1 RID: 251585
			public const int NumText = 4;

			// Token: 0x0403D6C2 RID: 251586
			public const int TitleText = 5;

			// Token: 0x0403D6C3 RID: 251587
			public const int DescText = 6;

			// Token: 0x0403D6C4 RID: 251588
			public const int RewardLayout = 7;

			// Token: 0x0403D6C5 RID: 251589
			public const int RewardItem = 8;

			// Token: 0x0403D6C6 RID: 251590
			public const int Btn = 9;

			// Token: 0x0403D6C7 RID: 251591
			public const int ClawItem = 10;

			// Token: 0x0403D6C8 RID: 251592
			public const int DifficultDesc = 11;
		}
	}
}
