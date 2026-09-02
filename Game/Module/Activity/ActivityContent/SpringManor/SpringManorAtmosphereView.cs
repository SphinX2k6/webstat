using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Module.AutoAttach;
using CSharpScript.Game.Module.Reward;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.Activity.ActivityContent.SpringManor
{
	// Token: 0x02006343 RID: 25411
	[NullableContext(1)]
	[Nullable(0)]
	public class SpringManorAtmosphereView : UiViewBase
	{
		// Token: 0x0603FD0B RID: 261387 RVA: 0x0105E013 File Offset: 0x0105C213
		public SpringManorAtmosphereView(UiViewInfo viewInfo) : base(viewInfo)
		{
		}

		// Token: 0x0603FD0C RID: 261388 RVA: 0x0105E024 File Offset: 0x0105C224
		protected override void OnRegisterComponent()
		{
			this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
			{
				new ValueTuple<int, Type>(0, typeof(UUIItem)),
				new ValueTuple<int, Type>(1, typeof(UUIScrollViewWithScrollbarComponent)),
				new ValueTuple<int, Type>(2, typeof(UUIButtonComponent)),
				new ValueTuple<int, Type>(3, typeof(UUIItem)),
				new ValueTuple<int, Type>(4, typeof(UUIScrollViewWithScrollbarComponent)),
				new ValueTuple<int, Type>(5, typeof(UUIButtonComponent)),
				new ValueTuple<int, Type>(6, typeof(UUIScrollViewWithScrollbarComponent)),
				new ValueTuple<int, Type>(7, typeof(UUIItem)),
				new ValueTuple<int, Type>(8, typeof(UUIItem)),
				new ValueTuple<int, Type>(9, typeof(UUIItem)),
				new ValueTuple<int, Type>(10, typeof(UUIItem)),
				new ValueTuple<int, Type>(11, typeof(UUIItem)),
				new ValueTuple<int, Type>(12, typeof(UUIItem)),
				new ValueTuple<int, Type>(13, typeof(UUIItem)),
				new ValueTuple<int, Type>(14, typeof(UUIItem)),
				new ValueTuple<int, Type>(15, typeof(UUIItem)),
				new ValueTuple<int, Type>(16, typeof(UUIText)),
				new ValueTuple<int, Type>(17, typeof(UUIItem))
			};
		}

		// Token: 0x0603FD0D RID: 261389 RVA: 0x0105E1D4 File Offset: 0x0105C3D4
		protected override UniTask OnBeforeStartAsync()
		{
			SpringManorAtmosphereView.<OnBeforeStartAsync>d__10 <OnBeforeStartAsync>d__;
			<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeStartAsync>d__.<>4__this = this;
			<OnBeforeStartAsync>d__.<>1__state = -1;
			<OnBeforeStartAsync>d__.<>t__builder.Start<SpringManorAtmosphereView.<OnBeforeStartAsync>d__10>(ref <OnBeforeStartAsync>d__);
			return <OnBeforeStartAsync>d__.<>t__builder.Task;
		}

		// Token: 0x0603FD0E RID: 261390 RVA: 0x0105E217 File Offset: 0x0105C417
		protected override void OnStart()
		{
			this.InitCaption();
			this.InitLevelAttachView();
			this.InitGetWayScroll();
			this.InitUnlockScroll();
			this.InitRewardScroll();
			ButtonItem receiveButton = this.ReceiveButton;
			if (receiveButton == null)
			{
				return;
			}
			receiveButton.SetRedDotVisible(true);
		}

		// Token: 0x0603FD0F RID: 261391 RVA: 0x0105E248 File Offset: 0x0105C448
		protected override void OnBeforeShow()
		{
			this.RefreshLevelView();
			this.RefreshLevelExpDisplay();
		}

		// Token: 0x0603FD10 RID: 261392 RVA: 0x0105E256 File Offset: 0x0105C456
		protected override void OnBeforeHide()
		{
			Singleton<GameSettingsDeviceRender>.Instance.CancelPerformanceLimit(this.ViewInfo.Name);
		}

		// Token: 0x0603FD11 RID: 261393 RVA: 0x0105E272 File Offset: 0x0105C472
		private void RefreshView()
		{
			this.RefreshUnlockScroll();
			this.RefreshGetWayScroll();
			this.RefreshRewardPreview();
		}

		// Token: 0x0603FD12 RID: 261394 RVA: 0x0105E288 File Offset: 0x0105C488
		private void RefreshLevelExpDisplay()
		{
			SpringManorModel instance = ModelBase<SpringManorModel>.Instance;
			int atmosphereLevel = instance.ActivityData.GetAtmosphereLevel();
			bool flag = instance.IsMaxLevel(atmosphereLevel);
			UUIText text = base.GetText(16);
			if (flag)
			{
				if (text != null)
				{
					text.ShowTextNew("Spring26_Atmosphere_Max");
				}
				return;
			}
			int atmosphere = instance.ActivityData.GetAtmosphere();
			int nextLevel = instance.GetNextLevel();
			int levelNeedExp = instance.GetLevelNeedExp(nextLevel);
			if (text != null)
			{
				UUIText uuitext = text;
				DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(1, 2);
				defaultInterpolatedStringHandler.AppendFormatted<int>(atmosphere);
				defaultInterpolatedStringHandler.AppendLiteral("/");
				defaultInterpolatedStringHandler.AppendFormatted<int>(levelNeedExp);
				uuitext.SetText(defaultInterpolatedStringHandler.ToStringAndClear(), true);
			}
		}

		// Token: 0x0603FD13 RID: 261395 RVA: 0x0105E320 File Offset: 0x0105C520
		private void OnSelectLevel(int level, LevelItem levelItem)
		{
			if (this.SelectLevel == level)
			{
				return;
			}
			NoCircleAttachView<SpringLevelData, LevelItem> levelAttachView = this.LevelAttachView;
			LevelItem levelItem2 = (levelAttachView != null) ? levelAttachView.GetItemByShowIndex(this.SelectLevel - 1) : null;
			if (levelItem2 != null)
			{
				LevelItem levelItem3 = levelItem2;
				if (levelItem3 != null)
				{
					levelItem3.PlaySequence("SleToNor");
				}
			}
			levelItem.PlaySequence("NorToSle");
			this.SelectLevel = level;
			this.RefreshView();
		}

		// Token: 0x0603FD14 RID: 261396 RVA: 0x0105E380 File Offset: 0x0105C580
		private void InitCaption()
		{
			PopupCaptionItem caption = this.Caption;
			if (caption != null)
			{
				caption.SetCloseCallBack(delegate
				{
					base.CloseMe(null);
				});
			}
			PopupCaptionItem caption2 = this.Caption;
			if (caption2 == null)
			{
				return;
			}
			caption2.SetHelpCallBack(delegate
			{
				ControllerBase<HelpController>.Instance.OpenHelpById(495);
			});
		}

		// Token: 0x0603FD15 RID: 261397 RVA: 0x0105E3D9 File Offset: 0x0105C5D9
		private void InitRewardScroll()
		{
			this.RewardScrollView = new GenericScrollViewNew<CommonItemSmallItemGrid, TItem>(base.GetScrollViewWithScrollbar(6), () => new CommonItemSmallItemGrid
			{
				ShowReceivedCallBack = new Func<TItem, bool>(this.IsReceived)
			}, null, false, null);
		}

		// Token: 0x0603FD16 RID: 261398 RVA: 0x0105E3FC File Offset: 0x0105C5FC
		private bool IsReceived(TItem _)
		{
			return this.CachedReceived;
		}

		// Token: 0x0603FD17 RID: 261399 RVA: 0x0105E404 File Offset: 0x0105C604
		private void RefreshRewardPreview()
		{
			SpringManorModel instance = ModelBase<SpringManorModel>.Instance;
			AtmosphereLevel? levelConfig = instance.GetLevelConfig(this.SelectLevel);
			if (levelConfig == null || levelConfig.Value.DropId == 0)
			{
				this.SetRewardState(ERewardState.None);
				return;
			}
			bool flag = instance.ActivityData.IsLevelRewardClaimed(levelConfig.Value.Id);
			this.CachedReceived = flag;
			List<TItem> dropPackagePreviewItemList = ConfigBase<CSharpScript.Game.Module.Reward.RewardConfig>.Instance.GetDropPackagePreviewItemList(levelConfig.Value.DropId);
			GenericScrollViewNew<CommonItemSmallItemGrid, TItem> rewardScrollView = this.RewardScrollView;
			if (rewardScrollView != null)
			{
				rewardScrollView.RefreshByData(dropPackagePreviewItemList, null, false);
			}
			if (flag)
			{
				this.SetRewardState(ERewardState.Received);
				return;
			}
			if (instance.GetAtmosphereLevel() >= this.SelectLevel)
			{
				this.SetRewardState(ERewardState.CanReceive);
				return;
			}
			this.SetRewardState(ERewardState.Progress);
		}

		// Token: 0x0603FD18 RID: 261400 RVA: 0x0105E4C4 File Offset: 0x0105C6C4
		private void SetRewardState(ERewardState state)
		{
			bool flag = state == ERewardState.None;
			UUIItem item = base.GetItem(11);
			if (item != null)
			{
				item.SetUIActive(!flag);
			}
			UUIItem item2 = base.GetItem(12);
			if (item2 != null)
			{
				item2.SetUIActive(flag);
			}
			ButtonItem receiveButton = this.ReceiveButton;
			if (receiveButton != null)
			{
				receiveButton.SetUiActive(state == ERewardState.CanReceive);
			}
			UUIItem item3 = base.GetItem(9);
			if (item3 != null)
			{
				item3.SetUIActive(state == ERewardState.Progress);
			}
			UUIItem item4 = base.GetItem(10);
			if (item4 == null)
			{
				return;
			}
			item4.SetUIActive(state == ERewardState.Received);
		}

		// Token: 0x0603FD19 RID: 261401 RVA: 0x0105E543 File Offset: 0x0105C743
		private void InitGetWayScroll()
		{
			this.GetWayScrollView = new GenericScrollViewNew<GetWayItem, int>(base.GetScrollViewWithScrollbar(1), () => new GetWayItem
			{
				OnTrackPositionCallback = new Action(this.OnTrackPositionCallback)
			}, null, false, null);
		}

		// Token: 0x0603FD1A RID: 261402 RVA: 0x0105E566 File Offset: 0x0105C766
		private void InitUnlockScroll()
		{
			this.UnlockScrollView = new GenericScrollViewNew<UnlockItem, int>(base.GetScrollViewWithScrollbar(4), () => new UnlockItem
			{
				OnTrackPositionCallback = new Action(this.OnTrackPositionCallback)
			}, null, false, null);
		}

		// Token: 0x0603FD1B RID: 261403 RVA: 0x0105E589 File Offset: 0x0105C789
		private void OnTrackPositionCallback()
		{
			Singleton<UiManager>.Instance.ResetToBattleView(null);
		}

		// Token: 0x0603FD1C RID: 261404 RVA: 0x0105E598 File Offset: 0x0105C798
		private void RefreshGetWayScroll()
		{
			AtmosphereLevel? levelConfig = ModelBase<SpringManorModel>.Instance.GetLevelConfig(this.SelectLevel);
			if (levelConfig == null)
			{
				return;
			}
			List<int> list = new List<int>();
			for (int i = 0; i < levelConfig.Value.UpgradeWayLength; i++)
			{
				list.Add(levelConfig.Value.UpgradeWay(i));
			}
			GenericScrollViewNew<GetWayItem, int> getWayScrollView = this.GetWayScrollView;
			if (getWayScrollView == null)
			{
				return;
			}
			getWayScrollView.RefreshByData(list, null, false);
		}

		// Token: 0x0603FD1D RID: 261405 RVA: 0x0105E60C File Offset: 0x0105C80C
		private void RefreshUnlockScroll()
		{
			AtmosphereLevel? levelConfig = ModelBase<SpringManorModel>.Instance.GetLevelConfig(this.SelectLevel);
			if (levelConfig == null)
			{
				return;
			}
			List<int> list = new List<int>();
			for (int i = 0; i < levelConfig.Value.UnlockFunctionLength; i++)
			{
				list.Add(levelConfig.Value.UnlockFunction(i));
			}
			UUIItem item = base.GetItem(17);
			if (item != null)
			{
				item.SetUIActive(list.Count == 0);
			}
			GenericScrollViewNew<UnlockItem, int> unlockScrollView = this.UnlockScrollView;
			if (unlockScrollView == null)
			{
				return;
			}
			unlockScrollView.RefreshByData(list, null, false);
		}

		// Token: 0x0603FD1E RID: 261406 RVA: 0x0105E69C File Offset: 0x0105C89C
		private void InitLevelAttachView()
		{
			this.LevelAttachView = new NoCircleAttachView<SpringLevelData, LevelItem>(base.GetItem(13).GetOwner(), false);
			UUIItem item = base.GetItem(14);
			item.SetUIActive(false);
			this.LevelAttachView.CreateItems(item.GetOwner(), 0f, new Func<AActor, int, int, LevelItem>(this.CreateLevelItem), EAttachDirection.Horizontal);
		}

		// Token: 0x0603FD1F RID: 261407 RVA: 0x0105E6F8 File Offset: 0x0105C8F8
		private LevelItem CreateLevelItem(AActor actor, int index, int showNum)
		{
			LevelItem levelItem = new LevelItem();
			levelItem.CreateThenShowByActor(actor, null);
			levelItem.ClickCallback = new Action<int>(this.OnClickLevel);
			levelItem.SelectCallback = new Action<int, LevelItem>(this.OnSelectLevel);
			levelItem.GetIsSelectLevel = new Func<int, bool>(this.IsSelectLevel);
			return levelItem;
		}

		// Token: 0x0603FD20 RID: 261408 RVA: 0x0105E748 File Offset: 0x0105C948
		private void OnClickLevel(int level)
		{
			NoCircleAttachView<SpringLevelData, LevelItem> levelAttachView = this.LevelAttachView;
			int? num = (levelAttachView != null) ? new int?(levelAttachView.GetCurrentSelectIndex()) : null;
			int num2 = level - 1;
			if (!(num.GetValueOrDefault() == num2 & num != null))
			{
				this.LevelAttachView.AttachToIndex(level - 1, false);
			}
		}

		// Token: 0x0603FD21 RID: 261409 RVA: 0x0105E79C File Offset: 0x0105C99C
		private bool IsSelectLevel(int level)
		{
			return this.SelectLevel == level;
		}

		// Token: 0x0603FD22 RID: 261410 RVA: 0x0105E7A8 File Offset: 0x0105C9A8
		private void RefreshLevelView()
		{
			List<SpringLevelData> totalLevelData = ModelBase<SpringManorModel>.Instance.GetTotalLevelData();
			if (this.SelectLevel == -1)
			{
				int atmosphereLevel = ModelBase<SpringManorModel>.Instance.GetAtmosphereLevel();
				this.LevelAttachView.ReloadView(totalLevelData.Count, totalLevelData.ToArray(), atmosphereLevel - 1);
				this.LevelAttachView.AttachToIndex(atmosphereLevel - 1, true);
				return;
			}
			foreach (LevelItem levelItem in this.LevelAttachView.GetItems())
			{
				levelItem.SetData(totalLevelData.ToArray());
				if (levelItem != null)
				{
					levelItem.RefreshPerformance();
				}
			}
		}

		// Token: 0x0603FD23 RID: 261411 RVA: 0x0105E858 File Offset: 0x0105CA58
		private void OnClickReward(int _)
		{
			ControllerBase<SpringManorController>.Instance.RequestAtmosphereRewardReceive(delegate
			{
				this.RefreshView();
				this.RefreshLevelView();
			});
		}

		// Token: 0x04023DBF RID: 146879
		[Nullable(2)]
		private PopupCaptionItem Caption;

		// Token: 0x04023DC0 RID: 146880
		[Nullable(new byte[]
		{
			2,
			1,
			1
		})]
		private NoCircleAttachView<SpringLevelData, LevelItem> LevelAttachView;

		// Token: 0x04023DC1 RID: 146881
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private GenericScrollViewNew<GetWayItem, int> GetWayScrollView;

		// Token: 0x04023DC2 RID: 146882
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private GenericScrollViewNew<UnlockItem, int> UnlockScrollView;

		// Token: 0x04023DC3 RID: 146883
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private GenericScrollViewNew<CommonItemSmallItemGrid, TItem> RewardScrollView;

		// Token: 0x04023DC4 RID: 146884
		[Nullable(2)]
		private ButtonItem ReceiveButton;

		// Token: 0x04023DC5 RID: 146885
		private int SelectLevel = -1;

		// Token: 0x04023DC6 RID: 146886
		private bool CachedReceived;
	}
}
