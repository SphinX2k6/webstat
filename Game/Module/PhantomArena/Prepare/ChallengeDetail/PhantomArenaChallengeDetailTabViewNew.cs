using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Module.Inventory;
using CSharpScript.Game.Module.PhantomArena.Prepare.DeckBuilder;
using CSharpScript.Game.Module.PhantomArena.Prepare.DeckDetail;
using CSharpScript.Game.Module.Reward;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.PhantomArena.Prepare.ChallengeDetail
{
	// Token: 0x02005520 RID: 21792
	[NullableContext(1)]
	[Nullable(0)]
	public class PhantomArenaChallengeDetailTabViewNew : PhantomArenaChildViewBase
	{
		// Token: 0x17008F2B RID: 36651
		// (get) Token: 0x06037982 RID: 227714 RVA: 0x00E1B125 File Offset: 0x00E19325
		// (set) Token: 0x06037983 RID: 227715 RVA: 0x00E1B132 File Offset: 0x00E19332
		public new IPhantomArenaChallengeDetailTabViewModel ViewModel
		{
			get
			{
				return this.ViewModel as IPhantomArenaChallengeDetailTabViewModel;
			}
			set
			{
				this.ViewModel = value;
			}
		}

		// Token: 0x06037984 RID: 227716 RVA: 0x00E1B13C File Offset: 0x00E1933C
		protected override void OnRegisterComponent()
		{
			this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
			{
				new ValueTuple<int, Type>(0, typeof(UUIItem)),
				new ValueTuple<int, Type>(1, typeof(UUIItem)),
				new ValueTuple<int, Type>(2, typeof(UUIText)),
				new ValueTuple<int, Type>(3, typeof(UUITexture)),
				new ValueTuple<int, Type>(4, typeof(UUIText)),
				new ValueTuple<int, Type>(5, typeof(UUIText)),
				new ValueTuple<int, Type>(6, typeof(UUIText)),
				new ValueTuple<int, Type>(7, typeof(UUIItem)),
				new ValueTuple<int, Type>(8, typeof(UUIText)),
				new ValueTuple<int, Type>(9, typeof(UUIScrollViewWithScrollbarComponent)),
				new ValueTuple<int, Type>(10, typeof(UUIItem)),
				new ValueTuple<int, Type>(11, typeof(UUIButtonComponent)),
				new ValueTuple<int, Type>(12, typeof(UUIText)),
				new ValueTuple<int, Type>(13, typeof(UUIButtonComponent))
			};
			this.BtnBindInfo = new List<ValueTuple<int, Delegate>>
			{
				new ValueTuple<int, Delegate>(11, new Action(this.OnConfirmBtnClick)),
				new ValueTuple<int, Delegate>(13, new Action(this.OnRecommendBtnClick))
			};
		}

		// Token: 0x06037985 RID: 227717 RVA: 0x00E1B2CC File Offset: 0x00E194CC
		protected override UniTask OnBeforeStartAsync()
		{
			PhantomArenaChallengeDetailTabViewNew.<OnBeforeStartAsync>d__13 <OnBeforeStartAsync>d__;
			<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeStartAsync>d__.<>4__this = this;
			<OnBeforeStartAsync>d__.<>1__state = -1;
			<OnBeforeStartAsync>d__.<>t__builder.Start<PhantomArenaChallengeDetailTabViewNew.<OnBeforeStartAsync>d__13>(ref <OnBeforeStartAsync>d__);
			return <OnBeforeStartAsync>d__.<>t__builder.Task;
		}

		// Token: 0x06037986 RID: 227718 RVA: 0x00E1B30F File Offset: 0x00E1950F
		protected override void OnStart()
		{
			base.OnStart();
			this.RewardLayout = new GenericScrollViewNew<CommonItemSmallItemGrid, TItem>(base.GetScrollViewWithScrollbar(9), new Func<CommonItemSmallItemGrid>(this.CreateRewardItem), base.GetItem(10).GetOwner() as AUIBaseActor, false, null);
		}

		// Token: 0x06037987 RID: 227719 RVA: 0x00E1B34C File Offset: 0x00E1954C
		protected override void OnBeforeShow()
		{
			this.ViewModel.SetViewTitle("PhantomArenaEntranceLevelTabView_Name");
			this.ViewModel.SetViewHelpBtnActive(false);
			this.ViewModel.SetViewIcon("SP_IconSoundRemnantArena4");
			if (this.ViewModel.SelectedCardRoleId == 0)
			{
				this.ViewModel.TextureCardRoleId = this.ViewModel.SelectedCardRoleId;
				this.ViewModel.HideRoleTexture(true);
			}
			else if (this.ViewModel.RoleTextureActive)
			{
				if (this.ViewModel.TextureCardRoleId != this.ViewModel.SelectedCardRoleId)
				{
					this.ViewModel.ChangeRoleTexture(this.ViewModel.SelectedCardRoleId, true);
				}
			}
			else
			{
				this.ViewModel.ShowRoleTexture(true);
				this.ViewModel.RefreshRoleTexture();
			}
			this.CheckAndPlayRoleSelectAnim();
			this.CheckAndPlayDeckSelectAnim();
			this.RefreshView();
		}

		// Token: 0x06037988 RID: 227720 RVA: 0x00E1B440 File Offset: 0x00E19640
		public void RefreshView()
		{
			int challengeId = this.ViewModel.GetChallengeId();
			PhantomBattleChallenge phantomBattleChallenge = ConfigBase<PhantomArenaConfig>.Instance.GetPhantomBattleChallenge(challengeId);
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(2), phantomBattleChallenge.ChallengeName, Array.Empty<object>());
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(4), phantomBattleChallenge.NpcName, Array.Empty<object>());
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(5), phantomBattleChallenge.NpcTitle, Array.Empty<object>());
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(8), phantomBattleChallenge.PassConditionDesc, Array.Empty<object>());
			UUIText text = base.GetText(6);
			if (text != null)
			{
				DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(3, 1);
				defaultInterpolatedStringHandler.AppendLiteral("Lv.");
				defaultInterpolatedStringHandler.AppendFormatted<int>(phantomBattleChallenge.NpcLevel);
				text.SetText(defaultInterpolatedStringHandler.ToStringAndClear(), true);
			}
			base.SetTextureByPath(phantomBattleChallenge.NpcChallengeIcon, base.GetTexture(3), null, null);
			this.RoleItemData = new PhantomArenaRoleOverviewItemData
			{
				CardRoleId = this.ViewModel.SelectedCardRoleId
			};
			this.RoleItem.Refresh(this.RoleItemData);
			this.MyDeckItemData = this.ViewModel.GetUsedDeck();
			if (this.MyDeckItemData != null)
			{
				this.MyDeckItem.Refresh(this.MyDeckItemData, false, 0);
			}
			else
			{
				this.MyDeckItem.Refresh(null, false, 0);
			}
			this.NpcDeckItemData = ModelBase<PhantomArenaModel>.Instance.CreateDeckInfoFromDeckConfigId(this.ViewModel.NpcDeckConfigId);
			if (this.NpcDeckItemData != null)
			{
				this.NpcDeckItem.Refresh(this.NpcDeckItemData, false, 0);
			}
			else
			{
				this.NpcDeckItem.Refresh(null, false, 0);
			}
			int recommendCardGroupId = phantomBattleChallenge.RecommendCardGroupId;
			if (!ModelBase<FunctionModel>.Instance.IsOpen(EFunctionType.PermanentPhantomArenaRecommend) || recommendCardGroupId == 0)
			{
				UUIButtonComponent button = base.GetButton(13);
				if (button != null)
				{
					button.RootUIComp.Get().SetUIActive(false);
				}
			}
			else
			{
				UUIButtonComponent button2 = base.GetButton(13);
				if (button2 != null)
				{
					button2.RootUIComp.Get().SetUIActive(true);
				}
				this.RecommendDeckInfo = ModelBase<PhantomArenaModel>.Instance.CreateDeckInfoFromDeckConfigId(recommendCardGroupId);
			}
			bool flag = ModelBase<PhantomArenaModel>.Instance.GetChallengeStateById(challengeId) == EChallengeState.Finish;
			string textStringId = flag ? "PhantomBattle_1087" : "PhantomBattle_1088";
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(12), textStringId, Array.Empty<object>());
			List<TItem> list = null;
			if (!flag)
			{
				list = ConfigBase<CSharpScript.Game.Module.Reward.RewardConfig>.Instance.GetDropPackagePreviewItemList(phantomBattleChallenge.FirstPassDropId);
			}
			else
			{
				list = new List<TItem>();
				if (phantomBattleChallenge.PassDropId() != null)
				{
					foreach (KeyValuePair<int, int> keyValuePair in phantomBattleChallenge.PassDropId())
					{
						int key = keyValuePair.Key;
						int value = keyValuePair.Value;
						InventoryDefine.GetItemData itemData = new InventoryDefine.GetItemData(key, 0);
						TItem item = new TItem(itemData, value);
						list.Add(item);
					}
				}
			}
			this.RewardLayout.RefreshByData(list, null, false);
		}

		// Token: 0x06037989 RID: 227721 RVA: 0x00E1B734 File Offset: 0x00E19934
		private void CheckAndPlayRoleSelectAnim()
		{
			if (this.ViewModel.RoleSelectedConfirmFlag)
			{
				PhantomArenaRoleOverviewItem roleItem = this.RoleItem;
				if (roleItem != null)
				{
					roleItem.PlaySelectAnim();
				}
				this.ViewModel.RoleSelectedConfirmFlag = false;
			}
		}

		// Token: 0x0603798A RID: 227722 RVA: 0x00E1B760 File Offset: 0x00E19960
		private void CheckAndPlayDeckSelectAnim()
		{
			if (this.ViewModel.DeckSelectedConfirmFlag)
			{
				PhantomArenaChallengeDetailDeckItem myDeckItem = this.MyDeckItem;
				if (myDeckItem != null)
				{
					myDeckItem.PlaySelectAnim();
				}
				this.ViewModel.DeckSelectedConfirmFlag = false;
			}
		}

		// Token: 0x0603798B RID: 227723 RVA: 0x00E1B78C File Offset: 0x00E1998C
		private CommonItemSmallItemGrid CreateRewardItem()
		{
			return new CommonItemSmallItemGrid();
		}

		// Token: 0x0603798C RID: 227724 RVA: 0x00E1B794 File Offset: 0x00E19994
		private void OnConfirmBtnClick()
		{
			if (this.IsRequesting)
			{
				return;
			}
			DeckInfo usedDeck = this.ViewModel.GetUsedDeck();
			int selectedCardRoleId = this.ViewModel.SelectedCardRoleId;
			if (selectedCardRoleId <= 0 || usedDeck == null || !usedDeck.CanDeckBeUsed())
			{
				ControllerBase<ScrollingTipsController>.Instance.ShowTipsByTextId("PhantomBattleGym_Not_Ready", Array.Empty<object>());
				return;
			}
			int challengeId = this.ViewModel.GetChallengeId();
			int deckServerId = usedDeck.GetDeckServerId();
			this.IsRequesting = true;
			PhantomArenaBattleController.RequestEnterPhantomArenaBattleAsync(challengeId, selectedCardRoleId, deckServerId).ContinueWith(delegate()
			{
				this.IsRequesting = false;
			}).Forget();
		}

		// Token: 0x0603798D RID: 227725 RVA: 0x00E1B81C File Offset: 0x00E19A1C
		private void OnRoleItemClick()
		{
			base.OpenChildView(EPhantomArenaChildViewName.PhantomArenaRoleSelectTabView);
		}

		// Token: 0x0603798E RID: 227726 RVA: 0x00E1B825 File Offset: 0x00E19A25
		private void OnMyDeckItemClick()
		{
			this.ViewModel.SelectedDeckIndex = ((this.ViewModel.UsedDeckIndex >= 0) ? this.ViewModel.UsedDeckIndex : 0);
			base.OpenChildView(EPhantomArenaChildViewName.PhantomArenaDeckOverviewTabView);
		}

		// Token: 0x0603798F RID: 227727 RVA: 0x00E1B858 File Offset: 0x00E19A58
		private void OnNpcDeckItemClick()
		{
			DeckInfo npcDeckItemData = this.NpcDeckItemData;
			if (npcDeckItemData == null)
			{
				return;
			}
			PhantomArenaDeckDetailViewData param = new PhantomArenaDeckDetailViewData
			{
				DeckInfo = npcDeckItemData,
				ShowLocked = false,
				ActivityId = base.ActivityId
			};
			EUiViewName name = ModelBase<PhantomArenaModel>.Instance.IsNewPhantomArenaActivity(base.ActivityId) ? EUiViewName.PhantomArenaDeckDetailViewNew : EUiViewName.PhantomArenaDeckDetailView;
			Singleton<UiManager>.Instance.OpenView(name, param, null);
		}

		// Token: 0x06037990 RID: 227728 RVA: 0x00E1B8BC File Offset: 0x00E19ABC
		private void OnRecommendBtnClick()
		{
			DeckInfo recommendDeckInfo = this.RecommendDeckInfo;
			if (recommendDeckInfo == null)
			{
				return;
			}
			PhantomArenaDeckDetailViewData param = new PhantomArenaDeckDetailViewData
			{
				DeckInfo = recommendDeckInfo,
				ShowLocked = true,
				ActivityId = base.ActivityId,
				IsRecommend = new bool?(true),
				SaveRecommendDeckCallback = new Action<DeckInfo>(this.OpenDeckOverviewTabView)
			};
			EUiViewName name = ModelBase<PhantomArenaModel>.Instance.IsNewPhantomArenaActivity(base.ActivityId) ? EUiViewName.PhantomArenaDeckDetailViewNew : EUiViewName.PhantomArenaDeckDetailView;
			Singleton<UiManager>.Instance.OpenView(name, param, null);
		}

		// Token: 0x06037991 RID: 227729 RVA: 0x00E1B93E File Offset: 0x00E19B3E
		private void OpenDeckOverviewTabView(DeckInfo deckInfo)
		{
			this.ViewModel.SelectedDeckIndex = ((this.ViewModel.UsedDeckIndex >= 0) ? this.ViewModel.UsedDeckIndex : 0);
			this.ViewModel.RecommendDeck = deckInfo;
			base.OpenChildView(EPhantomArenaChildViewName.PhantomArenaDeckOverviewTabView);
		}

		// Token: 0x0401FDFE RID: 130558
		private IPhantomArenaRoleOverviewItemData RoleItemData;

		// Token: 0x0401FDFF RID: 130559
		private PhantomArenaRoleOverviewItem RoleItem;

		// Token: 0x0401FE00 RID: 130560
		private DeckInfo MyDeckItemData;

		// Token: 0x0401FE01 RID: 130561
		private PhantomArenaChallengeDetailDeckItem MyDeckItem;

		// Token: 0x0401FE02 RID: 130562
		private DeckInfo NpcDeckItemData;

		// Token: 0x0401FE03 RID: 130563
		private PhantomArenaChallengeDetailDeckItem NpcDeckItem;

		// Token: 0x0401FE04 RID: 130564
		private DeckInfo RecommendDeckInfo;

		// Token: 0x0401FE05 RID: 130565
		protected GenericScrollViewNew<CommonItemSmallItemGrid, TItem> RewardLayout;

		// Token: 0x0401FE06 RID: 130566
		private bool IsRequesting;

		// Token: 0x0200B4B7 RID: 46263
		[NullableContext(0)]
		private static class EComponents
		{
			// Token: 0x04037F22 RID: 229154
			public const int RoleItem = 0;

			// Token: 0x04037F23 RID: 229155
			public const int MyDeckItem = 1;

			// Token: 0x04037F24 RID: 229156
			public const int GymTitleText = 2;

			// Token: 0x04037F25 RID: 229157
			public const int NpcTexture = 3;

			// Token: 0x04037F26 RID: 229158
			public const int NpcNameText = 4;

			// Token: 0x04037F27 RID: 229159
			public const int NpcLevelNameText = 5;

			// Token: 0x04037F28 RID: 229160
			public const int NpcLevelText = 6;

			// Token: 0x04037F29 RID: 229161
			public const int NpcDeckItem = 7;

			// Token: 0x04037F2A RID: 229162
			public const int ConditionText = 8;

			// Token: 0x04037F2B RID: 229163
			public const int RewardScrollView = 9;

			// Token: 0x04037F2C RID: 229164
			public const int RewardItem = 10;

			// Token: 0x04037F2D RID: 229165
			public const int ConfirmBtn = 11;

			// Token: 0x04037F2E RID: 229166
			public const int RewardTitleText = 12;

			// Token: 0x04037F2F RID: 229167
			public const int BtnRecommend = 13;
		}
	}
}
