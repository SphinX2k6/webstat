using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.Reward;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.Activity.ActivityContent.MoonSignIn
{
	// Token: 0x0200672E RID: 26414
	[NullableContext(1)]
	[Nullable(0)]
	public class MoonSignInRewardView : UiViewBase
	{
		// Token: 0x06041E36 RID: 269878 RVA: 0x010E7FD8 File Offset: 0x010E61D8
		public MoonSignInRewardView(UiViewInfo info) : base(info)
		{
		}

		// Token: 0x06041E37 RID: 269879 RVA: 0x010E7FE4 File Offset: 0x010E61E4
		protected unsafe override void OnRegisterComponent()
		{
			int num = 14;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIScrollViewWithScrollbarComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(5, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(6, typeof(UUIScrollViewWithScrollbarComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(7, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(8, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(9, typeof(UUIButtonComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(10, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(11, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(12, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(13, typeof(UUIItem));
			this.ComponentRegisterInfos = list;
			num2 = 1;
			List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
			CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
			Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
			num = 0;
			*span2[num] = new ValueTuple<int, Delegate>(9, new Action(this.OnClickRewardBtn));
			this.BtnBindInfo = list2;
		}

		// Token: 0x06041E38 RID: 269880 RVA: 0x010E8220 File Offset: 0x010E6420
		protected override UniTask OnBeforeStartAsync()
		{
			MoonSignInRewardView.<OnBeforeStartAsync>d__6 <OnBeforeStartAsync>d__;
			<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeStartAsync>d__.<>4__this = this;
			<OnBeforeStartAsync>d__.<>1__state = -1;
			<OnBeforeStartAsync>d__.<>t__builder.Start<MoonSignInRewardView.<OnBeforeStartAsync>d__6>(ref <OnBeforeStartAsync>d__);
			return <OnBeforeStartAsync>d__.<>t__builder.Task;
		}

		// Token: 0x06041E39 RID: 269881 RVA: 0x010E8263 File Offset: 0x010E6463
		protected override void OnAddEventListener()
		{
			Singleton<EventSystem>.Instance.Add(EEventName.MoonSignRewardRefresh, new Action(this.MoonSignRewardRefresh));
		}

		// Token: 0x06041E3A RID: 269882 RVA: 0x010E8281 File Offset: 0x010E6481
		protected override void OnRemoveEventListener()
		{
			Singleton<EventSystem>.Instance.Remove(EEventName.MoonSignRewardRefresh, new Action(this.MoonSignRewardRefresh));
		}

		// Token: 0x06041E3B RID: 269883 RVA: 0x010E82A0 File Offset: 0x010E64A0
		protected override void OnStart()
		{
			this.NormalRewardGenericScrollView = new GenericScrollViewNew<NormalRewardItem, int>(base.GetScrollViewWithScrollbar(1), new Func<NormalRewardItem>(this.InitGridItem), null, false, null);
			this.GrandRewardGenericScrollView = new GenericScrollViewNew<RewardItem, IRewardItemData>(base.GetScrollViewWithScrollbar(6), new Func<RewardItem>(this.InitGrandRewardGridItem), null, false, null);
			base.GetItem(12).SetUIActive(false);
			base.GetItem(13).SetUIActive(true);
			this.NormalRewardGenericScrollView.BindScrollValueChange(delegate(FVector2D progress)
			{
				base.GetItem(12).SetUIActive(progress.X < 1f);
				base.GetItem(13).SetUIActive(progress.X > 0f);
			});
		}

		// Token: 0x06041E3C RID: 269884 RVA: 0x010E8322 File Offset: 0x010E6522
		protected override void OnBeforeShow()
		{
			this.MoonSignRewardRefresh();
		}

		// Token: 0x06041E3D RID: 269885 RVA: 0x010E832C File Offset: 0x010E652C
		private void RefreshGrandRewardScrollView()
		{
			MoonSignInData data = ControllerBase<MoonSignInController>.Instance.GetData();
			if (data == null)
			{
				return;
			}
			MoonPhaseReward? moonSignReward = ConfigBase<MoonSignInConfig>.Instance.GetMoonSignReward(data.Id);
			if (moonSignReward == null)
			{
				return;
			}
			List<TItem> dropPackagePreviewItemList = ConfigBase<CSharpScript.Game.Module.Reward.RewardConfig>.Instance.GetDropPackagePreviewItemList(moonSignReward.Value.Reward);
			bool moonGrandReward = data.MoonGrandReward;
			List<IRewardItemData> list = new List<IRewardItemData>();
			foreach (TItem itemData in dropPackagePreviewItemList)
			{
				RewardItemDataImpl item = new RewardItemDataImpl
				{
					ItemData = itemData,
					HaveFinish = moonGrandReward
				};
				list.Add(item);
			}
			this.GrandRewardGenericScrollView.RefreshByData(list, null, false);
		}

		// Token: 0x06041E3E RID: 269886 RVA: 0x010E83F4 File Offset: 0x010E65F4
		private NormalRewardItem InitGridItem()
		{
			return new NormalRewardItem();
		}

		// Token: 0x06041E3F RID: 269887 RVA: 0x010E83FB File Offset: 0x010E65FB
		private RewardItem InitGrandRewardGridItem()
		{
			return new RewardItem();
		}

		// Token: 0x06041E40 RID: 269888 RVA: 0x010E8404 File Offset: 0x010E6604
		private void MoonSignRewardRefresh()
		{
			GenericScrollViewNew<NormalRewardItem, int> normalRewardGenericScrollView = this.NormalRewardGenericScrollView;
			if (normalRewardGenericScrollView != null)
			{
				MoonSignInData data = ControllerBase<MoonSignInController>.Instance.GetData();
				normalRewardGenericScrollView.RefreshByData(((data != null) ? data.GetMoonNormalRewardData() : null) ?? new List<int>(), null, false);
			}
			this.RefreshGrandRewardScrollView();
			this.RefreshBtnState();
			this.RefreshDesText();
		}

		// Token: 0x06041E41 RID: 269889 RVA: 0x010E8458 File Offset: 0x010E6658
		private void RefreshDesText()
		{
			MoonSignInData data = ControllerBase<MoonSignInController>.Instance.GetData();
			if (data == null)
			{
				return;
			}
			MoonPhaseReward? moonSignReward = ConfigBase<MoonSignInConfig>.Instance.GetMoonSignReward(data.Id);
			if (moonSignReward == null)
			{
				return;
			}
			int count = data.HaveSelectMoonPhaseSelectList.Count;
			int needMoonNum = moonSignReward.Value.NeedMoonNum;
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(5), "MoonSignInGrandRewardDes", new <>z__ReadOnlyArray<object>(new object[]
			{
				needMoonNum.ToString(),
				count.ToString(),
				needMoonNum.ToString()
			}));
		}

		// Token: 0x06041E42 RID: 269890 RVA: 0x010E84EC File Offset: 0x010E66EC
		private void RefreshBtnState()
		{
			MoonSignInData data = ControllerBase<MoonSignInController>.Instance.GetData();
			if (data == null)
			{
				return;
			}
			bool moonGrandReward = data.MoonGrandReward;
			bool canGetMoonGrandReward = data.GetCanGetMoonGrandReward();
			base.GetItem(11).SetUIActive(moonGrandReward);
			base.GetItem(10).SetUIActive(!moonGrandReward && !canGetMoonGrandReward);
			base.GetButton(9).RootUIComp.Get().SetUIActive(!moonGrandReward && canGetMoonGrandReward);
		}

		// Token: 0x06041E43 RID: 269891 RVA: 0x010E855C File Offset: 0x010E675C
		private void OnClickRewardBtn()
		{
			MoonSignInData data = ControllerBase<MoonSignInController>.Instance.GetData();
			if (data == null)
			{
				return;
			}
			if (data.GetCanGetMoonGrandReward())
			{
				ControllerBase<MoonSignInController>.Instance.MoonPhaseRewardRequest(data.Id);
			}
		}

		// Token: 0x04024C27 RID: 150567
		private PopupCaptionItem CaptionItem;

		// Token: 0x04024C28 RID: 150568
		private GenericScrollViewNew<NormalRewardItem, int> NormalRewardGenericScrollView;

		// Token: 0x04024C29 RID: 150569
		private GenericScrollViewNew<RewardItem, IRewardItemData> GrandRewardGenericScrollView;

		// Token: 0x0200C764 RID: 51044
		[NullableContext(0)]
		private class EComponentDefine
		{
			// Token: 0x0403D629 RID: 251433
			public const int CaptionItem = 0;

			// Token: 0x0403D62A RID: 251434
			public const int RewardScrollView = 1;

			// Token: 0x0403D62B RID: 251435
			public const int RewardContentItem = 2;

			// Token: 0x0403D62C RID: 251436
			public const int RewardItem = 3;

			// Token: 0x0403D62D RID: 251437
			public const int MoonGrandRewardTitleText = 4;

			// Token: 0x0403D62E RID: 251438
			public const int MoonGrandRewardDesText = 5;

			// Token: 0x0403D62F RID: 251439
			public const int MoonGrandRewardScrollView = 6;

			// Token: 0x0403D630 RID: 251440
			public const int MoonGrandRewardContentItem = 7;

			// Token: 0x0403D631 RID: 251441
			public const int MoonGrandRewardItem = 8;

			// Token: 0x0403D632 RID: 251442
			public const int RewardBtn = 9;

			// Token: 0x0403D633 RID: 251443
			public const int UnFinishItem = 10;

			// Token: 0x0403D634 RID: 251444
			public const int ObtainedItem = 11;

			// Token: 0x0403D635 RID: 251445
			public const int LeftButton = 12;

			// Token: 0x0403D636 RID: 251446
			public const int RightButton = 13;
		}
	}
}
