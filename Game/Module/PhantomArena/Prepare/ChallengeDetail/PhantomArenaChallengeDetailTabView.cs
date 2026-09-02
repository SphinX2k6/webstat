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
	// Token: 0x0200551F RID: 21791
	[NullableContext(1)]
	[Nullable(0)]
	public class PhantomArenaChallengeDetailTabView : PhantomArenaChildViewBase
	{
		// Token: 0x17008F2A RID: 36650
		// (get) Token: 0x06037972 RID: 227698 RVA: 0x00E1AA0E File Offset: 0x00E18C0E
		// (set) Token: 0x06037973 RID: 227699 RVA: 0x00E1AA1B File Offset: 0x00E18C1B
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

		// Token: 0x06037974 RID: 227700 RVA: 0x00E1AA24 File Offset: 0x00E18C24
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
				new ValueTuple<int, Type>(6, typeof(UUIItem)),
				new ValueTuple<int, Type>(7, typeof(UUIText)),
				new ValueTuple<int, Type>(8, typeof(UUIScrollViewWithScrollbarComponent)),
				new ValueTuple<int, Type>(9, typeof(UUIItem)),
				new ValueTuple<int, Type>(10, typeof(UUIButtonComponent)),
				new ValueTuple<int, Type>(11, typeof(UUIText)),
				new ValueTuple<int, Type>(12, typeof(UUISprite)),
				new ValueTuple<int, Type>(13, typeof(UUISprite))
			};
			this.BtnBindInfo = new List<ValueTuple<int, Delegate>>
			{
				new ValueTuple<int, Delegate>(10, new Action(this.OnConfirmBtnClick))
			};
		}

		// Token: 0x06037975 RID: 227701 RVA: 0x00E1AB9C File Offset: 0x00E18D9C
		protected override UniTask OnBeforeStartAsync()
		{
			PhantomArenaChallengeDetailTabView.<OnBeforeStartAsync>d__12 <OnBeforeStartAsync>d__;
			<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeStartAsync>d__.<>4__this = this;
			<OnBeforeStartAsync>d__.<>1__state = -1;
			<OnBeforeStartAsync>d__.<>t__builder.Start<PhantomArenaChallengeDetailTabView.<OnBeforeStartAsync>d__12>(ref <OnBeforeStartAsync>d__);
			return <OnBeforeStartAsync>d__.<>t__builder.Task;
		}

		// Token: 0x06037976 RID: 227702 RVA: 0x00E1ABDF File Offset: 0x00E18DDF
		protected override void OnStart()
		{
			base.OnStart();
			this.RewardLayout = new GenericScrollViewNew<CommonItemSmallItemGrid, TItem>(base.GetScrollViewWithScrollbar(8), new Func<CommonItemSmallItemGrid>(this.CreateRewardItem), base.GetItem(9).GetOwner() as AUIBaseActor, false, null);
		}

		// Token: 0x06037977 RID: 227703 RVA: 0x00E1AC1C File Offset: 0x00E18E1C
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

		// Token: 0x06037978 RID: 227704 RVA: 0x00E1AD10 File Offset: 0x00E18F10
		public void RefreshView()
		{
			int challengeId = this.ViewModel.GetChallengeId();
			PhantomBattleChallenge phantomBattleChallenge = ConfigBase<PhantomArenaConfig>.Instance.GetPhantomBattleChallenge(challengeId);
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(2), phantomBattleChallenge.ChallengeName, Array.Empty<object>());
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(4), phantomBattleChallenge.NpcName, Array.Empty<object>());
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(5), phantomBattleChallenge.NpcTitle, Array.Empty<object>());
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(7), phantomBattleChallenge.PassConditionDesc, Array.Empty<object>());
			base.SetTextureByPath(phantomBattleChallenge.NpcChallengeIcon, base.GetTexture(3), null, null);
			this.SetSpriteByPath(phantomBattleChallenge.NpcLevelBgIcon, base.GetSprite(12), false, null, null);
			this.SetSpriteByPath(phantomBattleChallenge.NpcLevelIcon, base.GetSprite(13), false, null, null);
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
			bool isReChallenge = phantomBattleChallenge.IsReChallenge;
			string textStringId = isReChallenge ? "PhantomBattle_1087" : "PhantomBattle_1088";
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(11), textStringId, Array.Empty<object>());
			List<TItem> list = null;
			if (!isReChallenge)
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

		// Token: 0x06037979 RID: 227705 RVA: 0x00E1AF8C File Offset: 0x00E1918C
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

		// Token: 0x0603797A RID: 227706 RVA: 0x00E1AFB8 File Offset: 0x00E191B8
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

		// Token: 0x0603797B RID: 227707 RVA: 0x00E1AFE4 File Offset: 0x00E191E4
		private CommonItemSmallItemGrid CreateRewardItem()
		{
			return new CommonItemSmallItemGrid();
		}

		// Token: 0x0603797C RID: 227708 RVA: 0x00E1AFEC File Offset: 0x00E191EC
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

		// Token: 0x0603797D RID: 227709 RVA: 0x00E1B074 File Offset: 0x00E19274
		private void OnRoleItemClick()
		{
			base.OpenChildView(EPhantomArenaChildViewName.PhantomArenaRoleSelectTabView);
		}

		// Token: 0x0603797E RID: 227710 RVA: 0x00E1B07D File Offset: 0x00E1927D
		private void OnMyDeckItemClick()
		{
			this.ViewModel.SelectedDeckIndex = ((this.ViewModel.UsedDeckIndex >= 0) ? this.ViewModel.UsedDeckIndex : 0);
			base.OpenChildView(EPhantomArenaChildViewName.PhantomArenaDeckOverviewTabView);
		}

		// Token: 0x0603797F RID: 227711 RVA: 0x00E1B0B0 File Offset: 0x00E192B0
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

		// Token: 0x0401FDF6 RID: 130550
		private IPhantomArenaRoleOverviewItemData RoleItemData;

		// Token: 0x0401FDF7 RID: 130551
		private PhantomArenaRoleOverviewItem RoleItem;

		// Token: 0x0401FDF8 RID: 130552
		private DeckInfo MyDeckItemData;

		// Token: 0x0401FDF9 RID: 130553
		private PhantomArenaChallengeDetailDeckItem MyDeckItem;

		// Token: 0x0401FDFA RID: 130554
		private DeckInfo NpcDeckItemData;

		// Token: 0x0401FDFB RID: 130555
		private PhantomArenaChallengeDetailDeckItem NpcDeckItem;

		// Token: 0x0401FDFC RID: 130556
		protected GenericScrollViewNew<CommonItemSmallItemGrid, TItem> RewardLayout;

		// Token: 0x0401FDFD RID: 130557
		private bool IsRequesting;

		// Token: 0x0200B4B5 RID: 46261
		[NullableContext(0)]
		private static class EComponents
		{
			// Token: 0x04037F0F RID: 229135
			public const int RoleItem = 0;

			// Token: 0x04037F10 RID: 229136
			public const int MyDeckItem = 1;

			// Token: 0x04037F11 RID: 229137
			public const int GymTitleText = 2;

			// Token: 0x04037F12 RID: 229138
			public const int NpcTexture = 3;

			// Token: 0x04037F13 RID: 229139
			public const int NpcNameText = 4;

			// Token: 0x04037F14 RID: 229140
			public const int NpcLevelText = 5;

			// Token: 0x04037F15 RID: 229141
			public const int NpcDeckItem = 6;

			// Token: 0x04037F16 RID: 229142
			public const int ConditionText = 7;

			// Token: 0x04037F17 RID: 229143
			public const int RewardScrollView = 8;

			// Token: 0x04037F18 RID: 229144
			public const int RewardItem = 9;

			// Token: 0x04037F19 RID: 229145
			public const int ConfirmBtn = 10;

			// Token: 0x04037F1A RID: 229146
			public const int RewardTitleText = 11;

			// Token: 0x04037F1B RID: 229147
			public const int NpcLevelBgSprite = 12;

			// Token: 0x04037F1C RID: 229148
			public const int NpcLevelSprite = 13;
		}
	}
}
