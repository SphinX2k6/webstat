using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.Activity.ActivityContent.Fishing
{
	// Token: 0x02006812 RID: 26642
	[NullableContext(2)]
	[Nullable(0)]
	public class FishingDockView : UiViewBase
	{
		// Token: 0x06042671 RID: 271985 RVA: 0x01105779 File Offset: 0x01103979
		[NullableContext(1)]
		public FishingDockView(UiViewInfo info) : base(info)
		{
		}

		// Token: 0x06042672 RID: 271986 RVA: 0x01105784 File Offset: 0x01103984
		protected unsafe override void OnRegisterComponent()
		{
			int num = 19;
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
			*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(5, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(6, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(7, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(8, typeof(UUIButtonComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(9, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(10, typeof(UUIButtonComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(11, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(12, typeof(UUIButtonComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(13, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(14, typeof(UUIButtonComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(15, typeof(UUIButtonComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(16, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(17, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(18, typeof(UUIItem));
			this.ComponentRegisterInfos = list;
			num2 = 5;
			List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
			CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
			Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
			num = 0;
			*span2[num] = new ValueTuple<int, Delegate>(8, new Action(this.OnClickIllustratedBtn));
			num++;
			*span2[num] = new ValueTuple<int, Delegate>(10, new Action(this.OnClickCabinBtn));
			num++;
			*span2[num] = new ValueTuple<int, Delegate>(12, new Action(this.OnClickTechnologyBtn));
			num++;
			*span2[num] = new ValueTuple<int, Delegate>(14, new Action(this.OnClickTransactionBtn));
			num++;
			*span2[num] = new ValueTuple<int, Delegate>(15, new Action(this.OnClickSailingBtn));
			this.BtnBindInfo = list2;
		}

		// Token: 0x06042673 RID: 271987 RVA: 0x01105AF6 File Offset: 0x01103CF6
		protected override void OnAddEventListener()
		{
			Singleton<EventSystem>.Instance.Add(EEventName.FishingRefreshBackpackData, new Action(this.FishingRefreshBackpackData));
		}

		// Token: 0x06042674 RID: 271988 RVA: 0x01105B14 File Offset: 0x01103D14
		protected override void OnRemoveEventListener()
		{
			Singleton<EventSystem>.Instance.Remove(EEventName.FishingRefreshBackpackData, new Action(this.FishingRefreshBackpackData));
		}

		// Token: 0x06042675 RID: 271989 RVA: 0x01105B34 File Offset: 0x01103D34
		protected override UniTask OnBeforeStartAsync()
		{
			FishingDockView.<OnBeforeStartAsync>d__12 <OnBeforeStartAsync>d__;
			<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeStartAsync>d__.<>4__this = this;
			<OnBeforeStartAsync>d__.<>1__state = -1;
			<OnBeforeStartAsync>d__.<>t__builder.Start<FishingDockView.<OnBeforeStartAsync>d__12>(ref <OnBeforeStartAsync>d__);
			return <OnBeforeStartAsync>d__.<>t__builder.Task;
		}

		// Token: 0x06042676 RID: 271990 RVA: 0x01105B78 File Offset: 0x01103D78
		protected override void OnStart()
		{
			FishingRewardLimitTimeButton limitTimeRewardItem = this.LimitTimeRewardItem;
			if (limitTimeRewardItem != null)
			{
				limitTimeRewardItem.RefreshActive();
			}
			LevelSequencePlayer roleTalkLevelSequencePlayer = this.RoleTalkLevelSequencePlayer;
			if (roleTalkLevelSequencePlayer != null)
			{
				roleTalkLevelSequencePlayer.PlayLevelSequenceByName("Start", false, null, false);
			}
			ControllerBase<RedDotController>.Instance.BindRedDot(ERedDotName.FishingTech, base.GetItem(17), null, 0);
		}

		// Token: 0x06042677 RID: 271991 RVA: 0x01105BD0 File Offset: 0x01103DD0
		protected override void OnBeforeShow()
		{
			this.RefreshView();
			FishingRewardLimitTimeButton limitTimeRewardItem = this.LimitTimeRewardItem;
			if (limitTimeRewardItem != null)
			{
				limitTimeRewardItem.RefreshActive();
			}
			this.RefreshShopRedDot();
			this.RefreshTechRedDot();
			FishingCurrencyItem fishingCurrencyItem = this.FishingCurrencyItem;
			if (fishingCurrencyItem == null)
			{
				return;
			}
			fishingCurrencyItem.RefreshItem();
		}

		// Token: 0x06042678 RID: 271992 RVA: 0x01105C05 File Offset: 0x01103E05
		protected override void OnBeforeDestroy()
		{
			ModelBase<FishingModel>.Instance.DockId = 0;
			ControllerBase<RedDotController>.Instance.UnBindGivenUi(ERedDotName.FishingTech, base.GetItem(17), 0);
			ControllerBase<FishingController>.Instance.ShowEffectInWorld();
		}

		// Token: 0x06042679 RID: 271993 RVA: 0x01105C34 File Offset: 0x01103E34
		private void RefreshShopRedDot()
		{
			int shopId = ModelBase<DockyardModel>.Instance.ShopId;
			bool uiactive = ModelBase<PayShopModel>.Instance.CheckShopItemCheckFlag((PayShopDefine.EPayShopTabType)shopId, 1);
			base.GetItem(18).SetUIActive(uiactive);
		}

		// Token: 0x0604267A RID: 271994 RVA: 0x01105C68 File Offset: 0x01103E68
		private void RefreshView()
		{
			FishingDockQuestItem fishingDockQuestItem = this.FishingDockQuestItem;
			if (fishingDockQuestItem != null)
			{
				fishingDockQuestItem.RefreshItem();
			}
			FishingDockReputationItem fishingDockReputationItem = this.FishingDockReputationItem;
			if (fishingDockReputationItem != null)
			{
				fishingDockReputationItem.RefreshItem();
			}
			bool uiactive = ModelBase<FunctionModel>.Instance.IsOpen(10077);
			UUIButtonComponent button = base.GetButton(14);
			if (button != null)
			{
				button.RootUIComp.Get().SetUIActive(uiactive);
			}
			this.RefreshCabinText();
			bool uiactive2 = ModelBase<FunctionModel>.Instance.IsOpen(10078);
			UUIButtonComponent button2 = base.GetButton(12);
			if (button2 != null)
			{
				button2.RootUIComp.Get().SetUIActive(uiactive2);
			}
			int allFishingTechCount = ModelBase<FishingModel>.Instance.AllFishingTechCount;
			int unlockFishingTechCount = ModelBase<FishingModel>.Instance.UnlockFishingTechCount;
			base.GetText(13).SetText(unlockFishingTechCount.ToString() + "/" + allFishingTechCount.ToString(), true);
			bool flag = ModelBase<FunctionModel>.Instance.IsOpen(10079);
			UUIButtonComponent button3 = base.GetButton(8);
			if (button3 != null)
			{
				button3.RootUIComp.Get().SetUIActive(flag);
			}
			FishingPermanentRewardButton permanentRewardItem = this.PermanentRewardItem;
			if (permanentRewardItem != null)
			{
				permanentRewardItem.SetUiActive(flag);
			}
			int allFishingItemCount = ModelBase<FishingModel>.Instance.AllFishingItemCount;
			int unLockFishingItemCount = ModelBase<FishingModel>.Instance.UnLockFishingItemCount;
			base.GetText(9).SetText(unLockFishingItemCount.ToString() + "/" + allFishingItemCount.ToString(), true);
			List<int> roleTalkIds = ModelBase<FishingModel>.Instance.RoleTalkIds;
			if (roleTalkIds != null)
			{
				roleTalkIds.Sort((int a, int b) => b - a);
			}
			if (roleTalkIds == null || roleTalkIds.Count == 0)
			{
				base.GetItem(3).SetUIActive(false);
				return;
			}
			base.GetItem(3).SetUIActive(true);
			FishingNotice fishingNotice = ConfigBase<FishingConfig>.Instance.GetFishingNotice(roleTalkIds[0]);
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(16), fishingNotice.AlertTip, Array.Empty<object>());
		}

		// Token: 0x0604267B RID: 271995 RVA: 0x01105E54 File Offset: 0x01104054
		private void OnClickBackBtn()
		{
			if (ControllerBase<FishingController>.Instance.IsInFishingShip())
			{
				ControllerBase<FishingController>.Instance.ConfirmToTeleportToPort(delegate
				{
					ControllerBase<FishingController>.Instance.TeleportToPortPosition(ModelBase<FishingModel>.Instance.DockId);
					Singleton<UiManager>.Instance.OpenView(EUiViewName.FishingLoadingView, false, delegate(bool _, int _)
					{
						base.CloseMe(null);
					});
				});
				return;
			}
			Singleton<UiManager>.Instance.OpenView(EUiViewName.FishingLoadingView, false, delegate(bool _, int _)
			{
				base.CloseMe(null);
			});
		}

		// Token: 0x0604267C RID: 271996 RVA: 0x01105EA5 File Offset: 0x011040A5
		private void OnClickSailingBtn()
		{
			Singleton<UiManager>.Instance.OpenView(EUiViewName.SailingView, null, null);
		}

		// Token: 0x0604267D RID: 271997 RVA: 0x01105EB8 File Offset: 0x011040B8
		private void OnClickIllustratedBtn()
		{
			ControllerBase<FishingController>.Instance.OpenFishingHandBookView();
		}

		// Token: 0x0604267E RID: 271998 RVA: 0x01105EC4 File Offset: 0x011040C4
		private void OnClickCabinBtn()
		{
			ControllerBase<FishingController>.Instance.OpenDockyardView();
		}

		// Token: 0x0604267F RID: 271999 RVA: 0x01105ED0 File Offset: 0x011040D0
		private void OnClickTechnologyBtn()
		{
			ControllerBase<FishingController>.Instance.OpenFishingTechRootView();
		}

		// Token: 0x06042680 RID: 272000 RVA: 0x01105EDC File Offset: 0x011040DC
		private void OnClickTransactionBtn()
		{
			ControllerBase<FishingController>.Instance.OpenDockyardShopView(null);
		}

		// Token: 0x06042681 RID: 272001 RVA: 0x01105EFC File Offset: 0x011040FC
		private void RefreshTechRedDot()
		{
			ModelBase<FishingModel>.Instance.RefreshTechCanLevelUp();
		}

		// Token: 0x06042682 RID: 272002 RVA: 0x01105F08 File Offset: 0x01104108
		private void FishingRefreshBackpackData()
		{
			this.RefreshCabinText();
		}

		// Token: 0x06042683 RID: 272003 RVA: 0x01105F10 File Offset: 0x01104110
		private void RefreshCabinText()
		{
			int backpackSize = ModelBase<DockyardModel>.Instance.BackpackSize;
			int backpackUseSize = ModelBase<DockyardModel>.Instance.BackpackUseSize;
			string str;
			if ((float)backpackUseSize / (float)backpackSize * 100f >= (float)ModelBase<FishingModel>.Instance.FishingBagRedPercentage)
			{
				str = StringUtils.Format("<color=#c25757>{0}</color>", new string[]
				{
					backpackUseSize.ToString() ?? ""
				});
			}
			else
			{
				str = StringUtils.Format("<color=#ffffff>{0}</color>", new string[]
				{
					backpackUseSize.ToString() ?? ""
				});
			}
			base.GetText(11).SetText(str + "/" + backpackSize.ToString(), true);
		}

		// Token: 0x04024F9F RID: 151455
		private PopupCaptionItem CaptionItem;

		// Token: 0x04024FA0 RID: 151456
		private FishingDockQuestItem FishingDockQuestItem;

		// Token: 0x04024FA1 RID: 151457
		private FishingDockReputationItem FishingDockReputationItem;

		// Token: 0x04024FA2 RID: 151458
		private FishingRewardLimitTimeButton LimitTimeRewardItem;

		// Token: 0x04024FA3 RID: 151459
		private FishingPermanentRewardButton PermanentRewardItem;

		// Token: 0x04024FA4 RID: 151460
		private LevelSequencePlayer RoleTalkLevelSequencePlayer;

		// Token: 0x04024FA5 RID: 151461
		private FishingCurrencyItem FishingCurrencyItem;

		// Token: 0x0200C843 RID: 51267
		[NullableContext(0)]
		private class EComponentDefine
		{
			// Token: 0x0403D9F3 RID: 252403
			public const int CaptionItem = 0;

			// Token: 0x0403D9F4 RID: 252404
			public const int ExpItem = 1;

			// Token: 0x0403D9F5 RID: 252405
			public const int QuestItem = 2;

			// Token: 0x0403D9F6 RID: 252406
			public const int RoleTalkItem = 3;

			// Token: 0x0403D9F7 RID: 252407
			public const int IllustratedRewardBtn = 4;

			// Token: 0x0403D9F8 RID: 252408
			public const int IllustratedRewardText = 5;

			// Token: 0x0403D9F9 RID: 252409
			public const int TimeLimitRewardBtn = 6;

			// Token: 0x0403D9FA RID: 252410
			public const int TimeLimitRewardText = 7;

			// Token: 0x0403D9FB RID: 252411
			public const int IllustratedBtn = 8;

			// Token: 0x0403D9FC RID: 252412
			public const int IllustratedText = 9;

			// Token: 0x0403D9FD RID: 252413
			public const int CabinBtn = 10;

			// Token: 0x0403D9FE RID: 252414
			public const int CabinText = 11;

			// Token: 0x0403D9FF RID: 252415
			public const int TechnologyBtn = 12;

			// Token: 0x0403DA00 RID: 252416
			public const int TechnologyText = 13;

			// Token: 0x0403DA01 RID: 252417
			public const int TransactionBtn = 14;

			// Token: 0x0403DA02 RID: 252418
			public const int SailingBtn = 15;

			// Token: 0x0403DA03 RID: 252419
			public const int RoleTalkText = 16;

			// Token: 0x0403DA04 RID: 252420
			public const int TechRedDotItem = 17;

			// Token: 0x0403DA05 RID: 252421
			public const int ShopRedDotItem = 18;
		}
	}
}
