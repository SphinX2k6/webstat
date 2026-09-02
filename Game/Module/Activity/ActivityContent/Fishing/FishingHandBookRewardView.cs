using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.Activity.ActivityContent.Fishing
{
	// Token: 0x0200681B RID: 26651
	public class FishingHandBookRewardView : UiViewBase
	{
		// Token: 0x060426C5 RID: 272069 RVA: 0x01107B6F File Offset: 0x01105D6F
		[NullableContext(1)]
		public FishingHandBookRewardView(UiViewInfo info) : base(info)
		{
		}

		// Token: 0x060426C6 RID: 272070 RVA: 0x01107B78 File Offset: 0x01105D78
		protected unsafe override void OnRegisterComponent()
		{
			int num = 3;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIVerticalLayout));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIItem));
			this.ComponentRegisterInfos = list;
		}

		// Token: 0x060426C7 RID: 272071 RVA: 0x01107C02 File Offset: 0x01105E02
		protected override void OnAddEventListener()
		{
			Singleton<EventSystem>.Instance.Add(EEventName.FishingRefreshHandBookRewardView, new Action(this.FishingRefreshHandBookRewardView));
		}

		// Token: 0x060426C8 RID: 272072 RVA: 0x01107C20 File Offset: 0x01105E20
		protected override void OnRemoveEventListener()
		{
			Singleton<EventSystem>.Instance.Remove(EEventName.FishingRefreshHandBookRewardView, new Action(this.FishingRefreshHandBookRewardView));
		}

		// Token: 0x060426C9 RID: 272073 RVA: 0x01107C40 File Offset: 0x01105E40
		protected override UniTask OnBeforeStartAsync()
		{
			FishingHandBookRewardView.<OnBeforeStartAsync>d__7 <OnBeforeStartAsync>d__;
			<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeStartAsync>d__.<>4__this = this;
			<OnBeforeStartAsync>d__.<>1__state = -1;
			<OnBeforeStartAsync>d__.<>t__builder.Start<FishingHandBookRewardView.<OnBeforeStartAsync>d__7>(ref <OnBeforeStartAsync>d__);
			return <OnBeforeStartAsync>d__.<>t__builder.Task;
		}

		// Token: 0x060426CA RID: 272074 RVA: 0x01107C83 File Offset: 0x01105E83
		protected override void OnStart()
		{
			this.RewardItemLayout = new GenericLayout<FishingHandBookRewardItem, int>(base.GetVerticalLayout(1), new Func<FishingHandBookRewardItem>(this.InitRewardItem), null, false, true);
			this.RefreshLayout();
		}

		// Token: 0x060426CB RID: 272075 RVA: 0x01107CAC File Offset: 0x01105EAC
		[NullableContext(1)]
		private FishingHandBookRewardItem InitRewardItem()
		{
			return new FishingHandBookRewardItem();
		}

		// Token: 0x060426CC RID: 272076 RVA: 0x01107CB3 File Offset: 0x01105EB3
		private void FishingRefreshHandBookRewardView()
		{
			this.RefreshLayout();
		}

		// Token: 0x060426CD RID: 272077 RVA: 0x01107CBC File Offset: 0x01105EBC
		private void RefreshLayout()
		{
			List<IFishingReward> list = ModelBase<FishingModel>.Instance.FishingItemHandBookRewardMap.Values.ToList<IFishingReward>();
			list.Sort(delegate(IFishingReward a, IFishingReward b)
			{
				int num = a.IsTaken ? 2 : ((!a.IsFinished) ? 1 : 0);
				int num2 = b.IsTaken ? 2 : ((!b.IsFinished) ? 1 : 0);
				return num - num2;
			});
			List<int> list2 = new List<int>();
			foreach (IFishingReward fishingReward in list)
			{
				list2.Add(fishingReward.Id);
			}
			this.RewardItemLayout.RefreshByData(list2, delegate
			{
				GenericLayout<FishingHandBookRewardItem, int> rewardItemLayout = this.RewardItemLayout;
				if (rewardItemLayout == null)
				{
					return;
				}
				UUIInturnAnimController uiAnimController = rewardItemLayout.GetUiAnimController();
				if (uiAnimController == null)
				{
					return;
				}
				uiAnimController.Play("", -1, false);
			}, false);
		}

		// Token: 0x04024FB1 RID: 151473
		[Nullable(2)]
		private PopupCaptionItem CaptionItem;

		// Token: 0x04024FB2 RID: 151474
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private GenericLayout<FishingHandBookRewardItem, int> RewardItemLayout;

		// Token: 0x0200C851 RID: 51281
		private class EComponentDefine
		{
			// Token: 0x0403DA51 RID: 252497
			public const int CaptionItem = 0;

			// Token: 0x0403DA52 RID: 252498
			public const int RewardItemLayout = 1;

			// Token: 0x0403DA53 RID: 252499
			public const int RewardItem = 2;
		}
	}
}
