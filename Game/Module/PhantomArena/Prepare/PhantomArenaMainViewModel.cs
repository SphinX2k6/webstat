using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Protocol;
using CSharpScript.Game.Module.PhantomArena.Prepare.DeckBuilder;

namespace CSharpScript.Game.Module.PhantomArena.Prepare
{
	// Token: 0x020054A9 RID: 21673
	[NullableContext(1)]
	[Nullable(0)]
	public class PhantomArenaMainViewModel : IPhantomArenaDeckOverviewTabViewModel, IPhantomArenaTabViewModelBase, IPhantomArenaDeckBuilderTabViewModel, IPhantomArenaRoleSelectTabViewModel, IPhantomArenaChallengeDetailTabViewModel, IPhantomArenaMainViewModel
	{
		// Token: 0x17008E26 RID: 36390
		// (get) Token: 0x060372B6 RID: 225974 RVA: 0x00E0255B File Offset: 0x00E0075B
		// (set) Token: 0x060372B7 RID: 225975 RVA: 0x00E02563 File Offset: 0x00E00763
		public Dictionary<int, int> QuicklyBuildDeckUseTimes { get; set; } = new Dictionary<int, int>();

		// Token: 0x17008E27 RID: 36391
		// (get) Token: 0x060372B8 RID: 225976 RVA: 0x00E0256C File Offset: 0x00E0076C
		// (set) Token: 0x060372B9 RID: 225977 RVA: 0x00E02574 File Offset: 0x00E00774
		public int LastQuicklyBuildId { get; set; }

		// Token: 0x17008E28 RID: 36392
		// (get) Token: 0x060372BA RID: 225978 RVA: 0x00E0257D File Offset: 0x00E0077D
		// (set) Token: 0x060372BB RID: 225979 RVA: 0x00E02585 File Offset: 0x00E00785
		public int SelectedCardRoleId { get; set; }

		// Token: 0x17008E29 RID: 36393
		// (get) Token: 0x060372BC RID: 225980 RVA: 0x00E0258E File Offset: 0x00E0078E
		// (set) Token: 0x060372BD RID: 225981 RVA: 0x00E02596 File Offset: 0x00E00796
		public int TextureCardRoleId { get; set; }

		// Token: 0x17008E2A RID: 36394
		// (get) Token: 0x060372BE RID: 225982 RVA: 0x00E0259F File Offset: 0x00E0079F
		// (set) Token: 0x060372BF RID: 225983 RVA: 0x00E025A7 File Offset: 0x00E007A7
		public bool RoleTextureActive { get; set; }

		// Token: 0x17008E2B RID: 36395
		// (get) Token: 0x060372C0 RID: 225984 RVA: 0x00E025B0 File Offset: 0x00E007B0
		// (set) Token: 0x060372C1 RID: 225985 RVA: 0x00E025B8 File Offset: 0x00E007B8
		[Nullable(2)]
		public DeckInfo RecommendDeck { [NullableContext(2)] get; [NullableContext(2)] set; }

		// Token: 0x17008E2C RID: 36396
		// (get) Token: 0x060372C2 RID: 225986 RVA: 0x00E025C1 File Offset: 0x00E007C1
		// (set) Token: 0x060372C3 RID: 225987 RVA: 0x00E025C9 File Offset: 0x00E007C9
		public List<DeckInfo> EditableDeckList { get; set; } = new List<DeckInfo>();

		// Token: 0x17008E2D RID: 36397
		// (get) Token: 0x060372C4 RID: 225988 RVA: 0x00E025D2 File Offset: 0x00E007D2
		// (set) Token: 0x060372C5 RID: 225989 RVA: 0x00E025DA File Offset: 0x00E007DA
		public int UsedDeckIndex { get; set; }

		// Token: 0x17008E2E RID: 36398
		// (get) Token: 0x060372C6 RID: 225990 RVA: 0x00E025E3 File Offset: 0x00E007E3
		// (set) Token: 0x060372C7 RID: 225991 RVA: 0x00E025EB File Offset: 0x00E007EB
		public int SelectedDeckIndex { get; set; }

		// Token: 0x17008E2F RID: 36399
		// (get) Token: 0x060372C8 RID: 225992 RVA: 0x00E025F4 File Offset: 0x00E007F4
		// (set) Token: 0x060372C9 RID: 225993 RVA: 0x00E025FC File Offset: 0x00E007FC
		public bool CanShowRewardInRoleSelectTabView { get; set; }

		// Token: 0x17008E30 RID: 36400
		// (get) Token: 0x060372CA RID: 225994 RVA: 0x00E02605 File Offset: 0x00E00805
		// (set) Token: 0x060372CB RID: 225995 RVA: 0x00E0260D File Offset: 0x00E0080D
		public bool CanShowSelectBtnInRoleSelectTabView { get; set; }

		// Token: 0x17008E31 RID: 36401
		// (get) Token: 0x060372CC RID: 225996 RVA: 0x00E02616 File Offset: 0x00E00816
		// (set) Token: 0x060372CD RID: 225997 RVA: 0x00E0261E File Offset: 0x00E0081E
		public bool CanShowSelectBtnInDeckOverviewTabView { get; set; }

		// Token: 0x17008E32 RID: 36402
		// (get) Token: 0x060372CE RID: 225998 RVA: 0x00E02627 File Offset: 0x00E00827
		// (set) Token: 0x060372CF RID: 225999 RVA: 0x00E0262F File Offset: 0x00E0082F
		public int NpcId { get; set; }

		// Token: 0x17008E33 RID: 36403
		// (get) Token: 0x060372D0 RID: 226000 RVA: 0x00E02638 File Offset: 0x00E00838
		// (set) Token: 0x060372D1 RID: 226001 RVA: 0x00E02640 File Offset: 0x00E00840
		public int NpcDeckConfigId { get; set; }

		// Token: 0x17008E34 RID: 36404
		// (get) Token: 0x060372D2 RID: 226002 RVA: 0x00E02649 File Offset: 0x00E00849
		// (set) Token: 0x060372D3 RID: 226003 RVA: 0x00E02651 File Offset: 0x00E00851
		public List<int> CardRoleList { get; set; } = new List<int>();

		// Token: 0x17008E35 RID: 36405
		// (get) Token: 0x060372D4 RID: 226004 RVA: 0x00E0265A File Offset: 0x00E0085A
		// (set) Token: 0x060372D5 RID: 226005 RVA: 0x00E02662 File Offset: 0x00E00862
		public bool RoleSelectedConfirmFlag { get; set; }

		// Token: 0x17008E36 RID: 36406
		// (get) Token: 0x060372D6 RID: 226006 RVA: 0x00E0266B File Offset: 0x00E0086B
		// (set) Token: 0x060372D7 RID: 226007 RVA: 0x00E02673 File Offset: 0x00E00873
		public bool DeckSelectedConfirmFlag { get; set; }

		// Token: 0x17008E37 RID: 36407
		// (get) Token: 0x060372D8 RID: 226008 RVA: 0x00E0267C File Offset: 0x00E0087C
		// (set) Token: 0x060372D9 RID: 226009 RVA: 0x00E02684 File Offset: 0x00E00884
		public Action<int, bool> ChangeRoleTexture { get; set; }

		// Token: 0x17008E38 RID: 36408
		// (get) Token: 0x060372DA RID: 226010 RVA: 0x00E0268D File Offset: 0x00E0088D
		// (set) Token: 0x060372DB RID: 226011 RVA: 0x00E02695 File Offset: 0x00E00895
		public Action<bool> ShowRoleTexture { get; set; }

		// Token: 0x17008E39 RID: 36409
		// (get) Token: 0x060372DC RID: 226012 RVA: 0x00E0269E File Offset: 0x00E0089E
		// (set) Token: 0x060372DD RID: 226013 RVA: 0x00E026A6 File Offset: 0x00E008A6
		public Action<bool> HideRoleTexture { get; set; }

		// Token: 0x17008E3A RID: 36410
		// (get) Token: 0x060372DE RID: 226014 RVA: 0x00E026AF File Offset: 0x00E008AF
		// (set) Token: 0x060372DF RID: 226015 RVA: 0x00E026B7 File Offset: 0x00E008B7
		public Action PlayRoleTextureShowAnim { get; set; }

		// Token: 0x17008E3B RID: 36411
		// (get) Token: 0x060372E0 RID: 226016 RVA: 0x00E026C0 File Offset: 0x00E008C0
		// (set) Token: 0x060372E1 RID: 226017 RVA: 0x00E026C8 File Offset: 0x00E008C8
		public Action RefreshRoleTexture { get; set; }

		// Token: 0x17008E3C RID: 36412
		// (get) Token: 0x060372E2 RID: 226018 RVA: 0x00E026D1 File Offset: 0x00E008D1
		// (set) Token: 0x060372E3 RID: 226019 RVA: 0x00E026D9 File Offset: 0x00E008D9
		public Action<string> SetViewTitle { get; set; }

		// Token: 0x17008E3D RID: 36413
		// (get) Token: 0x060372E4 RID: 226020 RVA: 0x00E026E2 File Offset: 0x00E008E2
		// (set) Token: 0x060372E5 RID: 226021 RVA: 0x00E026EA File Offset: 0x00E008EA
		public Action<string> SetViewIcon { get; set; }

		// Token: 0x17008E3E RID: 36414
		// (get) Token: 0x060372E6 RID: 226022 RVA: 0x00E026F3 File Offset: 0x00E008F3
		// (set) Token: 0x060372E7 RID: 226023 RVA: 0x00E026FB File Offset: 0x00E008FB
		public Action<int> SetViewHelpId { get; set; }

		// Token: 0x17008E3F RID: 36415
		// (get) Token: 0x060372E8 RID: 226024 RVA: 0x00E02704 File Offset: 0x00E00904
		// (set) Token: 0x060372E9 RID: 226025 RVA: 0x00E0270C File Offset: 0x00E0090C
		public Action<bool> SetViewHelpBtnActive { get; set; }

		// Token: 0x060372EA RID: 226026 RVA: 0x00E02718 File Offset: 0x00E00918
		public void Init(int challengeId)
		{
			PhantomArenaModel instance = ModelBase<PhantomArenaModel>.Instance;
			this.ChallengeId = challengeId;
			if (challengeId > 0)
			{
				this.ChallengeInfo = instance.GetChallengeData(challengeId);
				this.CanShowSelectBtnInRoleSelectTabView = true;
				this.CanShowRewardInRoleSelectTabView = false;
				this.CanShowSelectBtnInDeckOverviewTabView = true;
			}
			else
			{
				this.CanShowSelectBtnInRoleSelectTabView = false;
				this.CanShowRewardInRoleSelectTabView = true;
				this.CanShowSelectBtnInDeckOverviewTabView = false;
			}
			int lastUsedCardRoleId = instance.GetLastUsedCardRoleId(this.ActivityId);
			this.CardRoleList = instance.GetCardRoleList(this.ActivityId);
			this.SelectedCardRoleId = lastUsedCardRoleId;
			this.TextureCardRoleId = lastUsedCardRoleId;
			int lastUsedCardDeckServerId = instance.GetLastUsedCardDeckServerId(this.ActivityId);
			this.UsedDeckIndex = ((lastUsedCardDeckServerId >= 0) ? lastUsedCardDeckServerId : -1);
			this.SelectedDeckIndex = this.UsedDeckIndex;
			this.UpdateEditableDeckList();
		}

		// Token: 0x060372EB RID: 226027 RVA: 0x00E027C9 File Offset: 0x00E009C9
		public void SetOverrideCloseFunc(Action func)
		{
			this.OverrideCloseFunc = func;
		}

		// Token: 0x060372EC RID: 226028 RVA: 0x00E027D2 File Offset: 0x00E009D2
		public void ResetOverrideCloseFunc()
		{
			this.OverrideCloseFunc = null;
		}

		// Token: 0x060372ED RID: 226029 RVA: 0x00E027DB File Offset: 0x00E009DB
		[NullableContext(2)]
		public Action GetOverrideCloseFunc()
		{
			return this.OverrideCloseFunc;
		}

		// Token: 0x060372EE RID: 226030 RVA: 0x00E027E3 File Offset: 0x00E009E3
		public void SetGetSwitchItemFunc([Nullable(new byte[]
		{
			1,
			2
		})] Func<PhantomArenaMainViewSwitchItem> getSwitchItemFunc)
		{
			this.GetSwitchItemFunc = getSwitchItemFunc;
		}

		// Token: 0x060372EF RID: 226031 RVA: 0x00E027EC File Offset: 0x00E009EC
		[NullableContext(2)]
		public PhantomArenaMainViewSwitchItem GetSwitchItem()
		{
			Func<PhantomArenaMainViewSwitchItem> getSwitchItemFunc = this.GetSwitchItemFunc;
			if (getSwitchItemFunc == null)
			{
				return null;
			}
			return getSwitchItemFunc();
		}

		// Token: 0x060372F0 RID: 226032 RVA: 0x00E027FF File Offset: 0x00E009FF
		public int GetChallengeId()
		{
			return this.ChallengeId;
		}

		// Token: 0x060372F1 RID: 226033 RVA: 0x00E02807 File Offset: 0x00E00A07
		[NullableContext(2)]
		public PhantomBattleChallengeInfo GetChallengeInfo()
		{
			return this.ChallengeInfo;
		}

		// Token: 0x060372F2 RID: 226034 RVA: 0x00E0280F File Offset: 0x00E00A0F
		[NullableContext(2)]
		public DeckInfo GetUsedDeck()
		{
			if (this.UsedDeckIndex < 0)
			{
				return null;
			}
			return ModelBase<PhantomArenaModel>.Instance.GetDeckByDeckId(this.UsedDeckIndex, this.ActivityId);
		}

		// Token: 0x060372F3 RID: 226035 RVA: 0x00E02834 File Offset: 0x00E00A34
		public void UpdateEditableDeckList()
		{
			this.EditableDeckList = ModelBase<PhantomArenaModel>.Instance.CreateEditableDeckListFromProtocolData(this.ActivityId);
			int count = this.EditableDeckList.Count;
			int maxDeckCount = ModelBase<PhantomArenaModel>.Instance.GetPhantomArenaActivityData(this.ActivityId).GetMaxDeckCount();
			if (this.EditableDeckList.Count < maxDeckCount)
			{
				this.EditableDeckList.Add(this.CreateEmptyTempDeck());
			}
			this.SelectedDeckIndex = Singleton<MathUtils>.Instance.Clamp(this.SelectedDeckIndex, 0, this.EditableDeckList.Count - 1);
			if (this.UsedDeckIndex >= count)
			{
				this.UsedDeckIndex = -1;
			}
		}

		// Token: 0x060372F4 RID: 226036 RVA: 0x00E028CC File Offset: 0x00E00ACC
		[NullableContext(2)]
		public DeckInfo GetCurEditDeck()
		{
			return this.CurEditDeck;
		}

		// Token: 0x060372F5 RID: 226037 RVA: 0x00E028D4 File Offset: 0x00E00AD4
		public List<DeckInfo> GetEditableDeckList()
		{
			return this.EditableDeckList;
		}

		// Token: 0x060372F6 RID: 226038 RVA: 0x00E028DC File Offset: 0x00E00ADC
		public DeckInfo CreateEmptyTempDeck()
		{
			return ModelBase<PhantomArenaModel>.Instance.CreateEmptyTempDeckInfo(this.ActivityId);
		}

		// Token: 0x060372F7 RID: 226039 RVA: 0x00E028EE File Offset: 0x00E00AEE
		public DeckInfo CreateTempDeckFromDeck(DeckInfo srcDeck)
		{
			return srcDeck.DeepCopy();
		}

		// Token: 0x060372F8 RID: 226040 RVA: 0x00E028F6 File Offset: 0x00E00AF6
		public void StartEditDeck(DeckInfo deck)
		{
			this.CurEditDeck = deck;
			DeckInfo curEditDeck = this.CurEditDeck;
			this.CurEditDeckRecordInfo = ((curEditDeck != null) ? curEditDeck.Record() : null);
		}

		// Token: 0x060372F9 RID: 226041 RVA: 0x00E02917 File Offset: 0x00E00B17
		public void EndEditDeck()
		{
			this.CurEditDeck = null;
			this.CurEditDeckRecordInfo = null;
			this.QuicklyBuildDeckUseTimes.Clear();
			this.LastQuicklyBuildId = 0;
		}

		// Token: 0x060372FA RID: 226042 RVA: 0x00E02939 File Offset: 0x00E00B39
		public void RecordDeck(DeckInfo deck)
		{
			DeckInfo curEditDeck = this.CurEditDeck;
			this.CurEditDeckRecordInfo = ((curEditDeck != null) ? curEditDeck.Record() : null);
		}

		// Token: 0x060372FB RID: 226043 RVA: 0x00E02953 File Offset: 0x00E00B53
		public bool CheckCurEditDeckHasChange()
		{
			return this.CurEditDeckRecordInfo != null && this.CurEditDeck != null && this.CurEditDeck.CheckDeckDifferent(this.CurEditDeckRecordInfo);
		}

		// Token: 0x060372FC RID: 226044 RVA: 0x00E02978 File Offset: 0x00E00B78
		public void RecordQuicklyBuildClick(int quicklyBuildId)
		{
			int num;
			if (this.QuicklyBuildDeckUseTimes.TryGetValue(quicklyBuildId, out num))
			{
				this.QuicklyBuildDeckUseTimes[quicklyBuildId] = num + 1;
			}
			else
			{
				this.QuicklyBuildDeckUseTimes[quicklyBuildId] = 1;
			}
			this.LastQuicklyBuildId = quicklyBuildId;
		}

		// Token: 0x060372FD RID: 226045 RVA: 0x00E029BC File Offset: 0x00E00BBC
		public void ReportDeckDelete(DeckInfo deckInfo)
		{
			PhantomArenaReportDeckUpdateContext context = new PhantomArenaReportDeckUpdateContext
			{
				ActivityId = this.ActivityId,
				DeckInfo = deckInfo,
				Operation = EPhantomArenaReportDeckOperation.Delete,
				QuicklyBuildDeckUseTimes = this.QuicklyBuildDeckUseTimes,
				LastQuicklyBuildId = this.LastQuicklyBuildId
			};
			ControllerBase<PhantomArenaController>.Instance.ReportDeckUpdate(context);
		}

		// Token: 0x060372FE RID: 226046 RVA: 0x00E02A0C File Offset: 0x00E00C0C
		public void ReportDeckCreate(DeckInfo deckInfo)
		{
			PhantomArenaReportDeckUpdateContext context = new PhantomArenaReportDeckUpdateContext
			{
				ActivityId = this.ActivityId,
				DeckInfo = deckInfo,
				Operation = EPhantomArenaReportDeckOperation.Create,
				QuicklyBuildDeckUseTimes = this.QuicklyBuildDeckUseTimes,
				LastQuicklyBuildId = this.LastQuicklyBuildId
			};
			ControllerBase<PhantomArenaController>.Instance.ReportDeckUpdate(context);
		}

		// Token: 0x060372FF RID: 226047 RVA: 0x00E02A5C File Offset: 0x00E00C5C
		public void ReportDeckCover(DeckInfo deckInfo)
		{
			PhantomArenaReportDeckUpdateContext context = new PhantomArenaReportDeckUpdateContext
			{
				ActivityId = this.ActivityId,
				DeckInfo = deckInfo,
				Operation = EPhantomArenaReportDeckOperation.Cover,
				QuicklyBuildDeckUseTimes = this.QuicklyBuildDeckUseTimes,
				LastQuicklyBuildId = this.LastQuicklyBuildId
			};
			ControllerBase<PhantomArenaController>.Instance.ReportDeckUpdate(context);
		}

		// Token: 0x0401FBF1 RID: 130033
		private int ChallengeId;

		// Token: 0x0401FBF2 RID: 130034
		public int ActivityId;

		// Token: 0x0401FBF3 RID: 130035
		[Nullable(2)]
		private PhantomBattleChallengeInfo ChallengeInfo;

		// Token: 0x0401FBF9 RID: 130041
		[Nullable(2)]
		private DeckInfo CurEditDeck;

		// Token: 0x0401FC0F RID: 130063
		[Nullable(2)]
		private Action OverrideCloseFunc;

		// Token: 0x0401FC10 RID: 130064
		[Nullable(2)]
		private Func<PhantomArenaMainViewSwitchItem> GetSwitchItemFunc;

		// Token: 0x0401FC11 RID: 130065
		[Nullable(2)]
		private DeckRecordInfo CurEditDeckRecordInfo;
	}
}
