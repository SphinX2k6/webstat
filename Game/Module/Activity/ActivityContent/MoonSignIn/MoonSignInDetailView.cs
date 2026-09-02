using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.ItemReward;
using CSharpScript.Game.Module.Reward;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.Activity.ActivityContent.MoonSignIn
{
	// Token: 0x02006727 RID: 26407
	[NullableContext(2)]
	[Nullable(0)]
	public class MoonSignInDetailView : UiViewBase
	{
		// Token: 0x06041DF4 RID: 269812 RVA: 0x010E6365 File Offset: 0x010E4565
		[NullableContext(1)]
		public MoonSignInDetailView(UiViewInfo info) : base(info)
		{
		}

		// Token: 0x06041DF5 RID: 269813 RVA: 0x010E6370 File Offset: 0x010E4570
		protected unsafe override void OnRegisterComponent()
		{
			int num = 9;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIButtonComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIButtonComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIButtonComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(5, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(6, typeof(UUIButtonComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(10, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(11, typeof(UUIItem));
			this.ComponentRegisterInfos = list;
			num2 = 4;
			List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
			CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
			Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
			num = 0;
			*span2[num] = new ValueTuple<int, Delegate>(0, new Action(this.OnClickGoOnBtn));
			num++;
			*span2[num] = new ValueTuple<int, Delegate>(1, new Action(this.OnClickPreviousBtn));
			num++;
			*span2[num] = new ValueTuple<int, Delegate>(2, new Action(this.OnClickNextBtn));
			num++;
			*span2[num] = new ValueTuple<int, Delegate>(6, new Action(this.OnClickBackBtn));
			this.BtnBindInfo = list2;
		}

		// Token: 0x06041DF6 RID: 269814 RVA: 0x010E6569 File Offset: 0x010E4769
		protected override void OnAddEventListener()
		{
			Singleton<EventSystem>.Instance.Add<string>(EEventName.OnActivitySequenceEmitEvent, new Action<string>(this.OnActivitySequenceEmitEvent));
		}

		// Token: 0x06041DF7 RID: 269815 RVA: 0x010E6587 File Offset: 0x010E4787
		protected override void OnRemoveEventListener()
		{
			Singleton<EventSystem>.Instance.Remove(EEventName.OnActivitySequenceEmitEvent, new Action<string>(this.OnActivitySequenceEmitEvent));
		}

		// Token: 0x06041DF8 RID: 269816 RVA: 0x010E65A8 File Offset: 0x010E47A8
		protected override UniTask OnBeforeStartAsync()
		{
			MoonSignInDetailView.<OnBeforeStartAsync>d__11 <OnBeforeStartAsync>d__;
			<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeStartAsync>d__.<>4__this = this;
			<OnBeforeStartAsync>d__.<>1__state = -1;
			<OnBeforeStartAsync>d__.<>t__builder.Start<MoonSignInDetailView.<OnBeforeStartAsync>d__11>(ref <OnBeforeStartAsync>d__);
			return <OnBeforeStartAsync>d__.<>t__builder.Task;
		}

		// Token: 0x06041DF9 RID: 269817 RVA: 0x010E65EC File Offset: 0x010E47EC
		protected override void OnStart()
		{
			IMoonSignInDetailViewOpenData moonSignInDetailViewOpenData = this.OpenParam as IMoonSignInDetailViewOpenData;
			this.CurrentMoonId = moonSignInDetailViewOpenData.MoonId;
			base.GetButton(0).RootUIComp.Get().SetUIActive(false);
			if (moonSignInDetailViewOpenData.Wishing != null && moonSignInDetailViewOpenData.Wishing.Value)
			{
				this.OpenWishingPanel();
				return;
			}
			this.OpenIllustratedPanel();
			LevelSequencePlayer levelSequencePlayer = this.LevelSequencePlayer;
			if (levelSequencePlayer == null)
			{
				return;
			}
			levelSequencePlayer.PlayLevelSequenceByName("Start02", false, null, false);
		}

		// Token: 0x06041DFA RID: 269818 RVA: 0x010E6678 File Offset: 0x010E4878
		private void OpenWishingPanel()
		{
			IllustratedUnLockItem illustratedUnLockItem = this.IllustratedUnLockItem;
			if (illustratedUnLockItem != null)
			{
				illustratedUnLockItem.SetUiActive(true);
			}
			IllustratedLockItem illustratedLockItem = this.IllustratedLockItem;
			if (illustratedLockItem != null)
			{
				illustratedLockItem.SetUiActive(false);
			}
			IllustratedUnLockItem illustratedUnLockItem2 = this.IllustratedUnLockItem;
			if (illustratedUnLockItem2 != null)
			{
				illustratedUnLockItem2.RefreshItem(this.CurrentMoonId);
			}
			PhaseOfMoon? phaseOfMoon;
			this.HandleWishingReward = ((ConfigBase<MoonSignInConfig>.Instance.GetPhaseOfMoonById(this.CurrentMoonId) != null) ? phaseOfMoon.GetValueOrDefault().Reward : 0);
			WishingItem wishingItem = this.WishingItem;
			if (wishingItem != null)
			{
				wishingItem.RefreshItem(this.CurrentMoonId);
			}
			WishingItem wishingItem2 = this.WishingItem;
			if (wishingItem2 != null)
			{
				wishingItem2.SetUiActive(true);
			}
			base.GetItem(10).SetUIActive(false);
			base.GetItem(11).SetUIActive(false);
			base.GetButton(6).RootUIComp.Get().SetUIActive(false);
			LevelSequencePlayer levelSequencePlayer = this.LevelSequencePlayer;
			if (levelSequencePlayer == null)
			{
				return;
			}
			levelSequencePlayer.PlayLevelSequenceByName("Start01", false, null, false);
		}

		// Token: 0x06041DFB RID: 269819 RVA: 0x010E6771 File Offset: 0x010E4971
		private void CloseWishingPanel()
		{
			WishingItem wishingItem = this.WishingItem;
			if (wishingItem == null)
			{
				return;
			}
			wishingItem.SetUiActive(false);
		}

		// Token: 0x06041DFC RID: 269820 RVA: 0x010E6784 File Offset: 0x010E4984
		private void OpenIllustratedPanel()
		{
			this.CloseWishingPanel();
			MoonSignInData data = ControllerBase<MoonSignInController>.Instance.GetData();
			if (data == null)
			{
				return;
			}
			bool flag = data.CheckPhaseLock(this.CurrentMoonId);
			IllustratedUnLockItem illustratedUnLockItem = this.IllustratedUnLockItem;
			if (illustratedUnLockItem != null)
			{
				illustratedUnLockItem.SetUiActive(!flag);
			}
			IllustratedLockItem illustratedLockItem = this.IllustratedLockItem;
			if (illustratedLockItem != null)
			{
				illustratedLockItem.SetUiActive(flag);
			}
			if (flag)
			{
				IllustratedLockItem illustratedLockItem2 = this.IllustratedLockItem;
				if (illustratedLockItem2 != null)
				{
					illustratedLockItem2.RefreshItem(this.CurrentMoonId);
				}
			}
			else
			{
				IllustratedUnLockItem illustratedUnLockItem2 = this.IllustratedUnLockItem;
				if (illustratedUnLockItem2 != null)
				{
					illustratedUnLockItem2.RefreshItem(this.CurrentMoonId);
				}
			}
			base.GetItem(10).SetUIActive(true);
			base.GetItem(11).SetUIActive(true);
		}

		// Token: 0x06041DFD RID: 269821 RVA: 0x010E682C File Offset: 0x010E4A2C
		private void OpenHandleRewardView()
		{
			this.CloseWishingPanel();
			List<TItem> dropPackagePreviewItemList = ConfigBase<CSharpScript.Game.Module.Reward.RewardConfig>.Instance.GetDropPackagePreviewItemList(this.HandleWishingReward);
			List<RewardItemData> list = new List<RewardItemData>();
			foreach (TItem titem in dropPackagePreviewItemList)
			{
				RewardItemData item = new RewardItemData(titem.ItemData.ItemId, titem.Count, null, EDropItemType.Normal);
				list.Add(item);
			}
			ControllerBase<ItemRewardController>.Instance.OpenCommonRewardView(1009, list, null);
			this.HandleWishingReward = 0;
			base.GetButton(0).RootUIComp.Get().SetUIActive(false);
			base.GetItem(10).SetUIActive(true);
			base.GetItem(11).SetUIActive(true);
			base.GetButton(6).RootUIComp.Get().SetUIActive(true);
			LevelSequencePlayer levelSequencePlayer = this.LevelSequencePlayer;
			if (levelSequencePlayer != null)
			{
				levelSequencePlayer.PlayLevelSequenceByName("Next", false, null, false);
			}
			IllustratedUnLockItem illustratedUnLockItem = this.IllustratedUnLockItem;
			if (illustratedUnLockItem == null)
			{
				return;
			}
			illustratedUnLockItem.RefreshShareBtn();
		}

		// Token: 0x06041DFE RID: 269822 RVA: 0x010E6954 File Offset: 0x010E4B54
		private void OnClickGoOnBtn()
		{
			if (this.HandleWishingReward != 0)
			{
				this.OpenHandleRewardView();
			}
		}

		// Token: 0x06041DFF RID: 269823 RVA: 0x010E6964 File Offset: 0x010E4B64
		private void OnClickPreviousBtn()
		{
			if (this.HandleWishingReward != 0)
			{
				this.OpenHandleRewardView();
			}
			else
			{
				this.CurrentMoonId--;
				if (this.CurrentMoonId <= 0)
				{
					this.CurrentMoonId = 10;
				}
			}
			LevelSequencePlayer levelSequencePlayer = this.LevelSequencePlayer;
			if (levelSequencePlayer != null)
			{
				levelSequencePlayer.StopCurrentSequence(false, false);
			}
			LevelSequencePlayer levelSequencePlayer2 = this.LevelSequencePlayer;
			if (levelSequencePlayer2 == null)
			{
				return;
			}
			levelSequencePlayer2.PlayLevelSequenceByName("Switch", false, null, false);
		}

		// Token: 0x06041E00 RID: 269824 RVA: 0x010E69D4 File Offset: 0x010E4BD4
		private void OnClickNextBtn()
		{
			if (this.HandleWishingReward != 0)
			{
				this.OpenHandleRewardView();
			}
			else
			{
				this.CurrentMoonId++;
				if (this.CurrentMoonId > 10)
				{
					this.CurrentMoonId = 1;
				}
			}
			LevelSequencePlayer levelSequencePlayer = this.LevelSequencePlayer;
			if (levelSequencePlayer != null)
			{
				levelSequencePlayer.StopCurrentSequence(false, false);
			}
			LevelSequencePlayer levelSequencePlayer2 = this.LevelSequencePlayer;
			if (levelSequencePlayer2 == null)
			{
				return;
			}
			levelSequencePlayer2.PlayLevelSequenceByName("Switch", false, null, false);
		}

		// Token: 0x06041E01 RID: 269825 RVA: 0x010E6A43 File Offset: 0x010E4C43
		private void OnClickBackBtn()
		{
			base.CloseMe(null);
		}

		// Token: 0x06041E02 RID: 269826 RVA: 0x010E6A4C File Offset: 0x010E4C4C
		[NullableContext(1)]
		private void OnActivitySequenceEmitEvent(string name)
		{
			if (name == "Enter")
			{
				this.OpenIllustratedPanel();
			}
		}

		// Token: 0x06041E03 RID: 269827 RVA: 0x010E6A64 File Offset: 0x010E4C64
		private void SetNextAndBackBtnUiActive(bool active)
		{
			base.GetItem(10).SetUIActive(active);
			base.GetItem(11).SetUIActive(active);
			base.GetButton(6).RootUIComp.Get().SetUIActive(active);
		}

		// Token: 0x06041E04 RID: 269828 RVA: 0x010E6AA7 File Offset: 0x010E4CA7
		protected override void OnBeforeDestroy()
		{
			LevelSequencePlayer levelSequencePlayer = this.LevelSequencePlayer;
			if (levelSequencePlayer != null)
			{
				levelSequencePlayer.Clear();
			}
			this.LevelSequencePlayer = null;
		}

		// Token: 0x04024C1A RID: 150554
		private int CurrentMoonId;

		// Token: 0x04024C1B RID: 150555
		private IllustratedUnLockItem IllustratedUnLockItem;

		// Token: 0x04024C1C RID: 150556
		private IllustratedLockItem IllustratedLockItem;

		// Token: 0x04024C1D RID: 150557
		private WishingItem WishingItem;

		// Token: 0x04024C1E RID: 150558
		private int HandleWishingReward;

		// Token: 0x04024C1F RID: 150559
		private LevelSequencePlayer LevelSequencePlayer;

		// Token: 0x0200C757 RID: 51031
		[NullableContext(0)]
		private class EComponentDefine
		{
			// Token: 0x0403D5D4 RID: 251348
			public const int GoOnBtn = 0;

			// Token: 0x0403D5D5 RID: 251349
			public const int PreviousBtn = 1;

			// Token: 0x0403D5D6 RID: 251350
			public const int NextBtn = 2;

			// Token: 0x0403D5D7 RID: 251351
			public const int IllustratedUnLockItem = 3;

			// Token: 0x0403D5D8 RID: 251352
			public const int IllustratedLockItem = 4;

			// Token: 0x0403D5D9 RID: 251353
			public const int WishingItem = 5;

			// Token: 0x0403D5DA RID: 251354
			public const int BackBtn = 6;

			// Token: 0x0403D5DB RID: 251355
			public const int NextBtnItem = 10;

			// Token: 0x0403D5DC RID: 251356
			public const int PreviousBtnItem = 11;
		}
	}
}
