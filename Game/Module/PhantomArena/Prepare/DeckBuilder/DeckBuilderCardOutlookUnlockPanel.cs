using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Module.Item;
using CSharpScript.Game.Module.PhantomArena.Common.CardItem.Item;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.PhantomArena.Prepare.DeckBuilder
{
	// Token: 0x020054F7 RID: 21751
	[NullableContext(2)]
	[Nullable(0)]
	public class DeckBuilderCardOutlookUnlockPanel : UiPanelBase, IDeckBuilderCardInfoViewPanelSequencePlayer
	{
		// Token: 0x060376BB RID: 227003 RVA: 0x00E0F6C0 File Offset: 0x00E0D8C0
		protected override void OnRegisterComponent()
		{
			this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
			{
				new ValueTuple<int, Type>(0, typeof(UUIItem)),
				new ValueTuple<int, Type>(1, typeof(UUIText)),
				new ValueTuple<int, Type>(2, typeof(UUIItem))
			};
		}

		// Token: 0x060376BC RID: 227004 RVA: 0x00E0F71C File Offset: 0x00E0D91C
		protected override UniTask OnBeforeStartAsync()
		{
			DeckBuilderCardOutlookUnlockPanel.<OnBeforeStartAsync>d__5 <OnBeforeStartAsync>d__;
			<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeStartAsync>d__.<>4__this = this;
			<OnBeforeStartAsync>d__.<>1__state = -1;
			<OnBeforeStartAsync>d__.<>t__builder.Start<DeckBuilderCardOutlookUnlockPanel.<OnBeforeStartAsync>d__5>(ref <OnBeforeStartAsync>d__);
			return <OnBeforeStartAsync>d__.<>t__builder.Task;
		}

		// Token: 0x060376BD RID: 227005 RVA: 0x00E0F75F File Offset: 0x00E0D95F
		[NullableContext(1)]
		public void Refresh(IDeckBuilderCardOutlookUnlockPanelData data)
		{
			this.Data = data;
			this.CardItem.Refresh(data.CardId);
			this.RefreshOutlookUnlockedState();
		}

		// Token: 0x060376BE RID: 227006 RVA: 0x00E0F780 File Offset: 0x00E0D980
		public void RefreshOutlookUnlockedState()
		{
			bool flag = ModelBase<PhantomArenaModel>.Instance.IsCardOutlookUnlock(this.Data.CardId);
			this.UnlockBtnItem.SetActive(!flag);
			base.GetText(1).SetUIActive(!flag);
			if (!flag)
			{
				PhantomBattleCard phantomBattleCardConfig = ConfigBase<PhantomArenaConfig>.Instance.GetPhantomBattleCardConfig(this.Data.CardId);
				int itemId = phantomBattleCardConfig.UpOutLookConsumeItems()[0].ItemId;
				int count = phantomBattleCardConfig.UpOutLookConsumeItems()[0].Count;
				int itemCountByConfigId = ModelBase<InventoryModel>.Instance.GetItemCountByConfigId(itemId, 0);
				bool flag2 = ModelBase<FunctionModel>.Instance.IsOpen(EFunctionType.PhantomArenaCardOutlookUnlock);
				bool flag3 = ModelBase<PhantomArenaModel>.Instance.IsCardUnlock(this.Data.CardId);
				bool flag4 = flag2 && flag3;
				bool flag5 = itemCountByConfigId >= count;
				string iconSmall = ConfigBase<ItemConfig>.Instance.GetConfig(itemId).Value.IconSmall;
				string textStringId = flag5 ? "PhantomBattle_1012" : "PhantomBattle_1011";
				Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(1), textStringId, new <>z__ReadOnlyArray<object>(new object[]
				{
					iconSmall,
					count
				}));
				base.GetText(1).SetUIActive(flag4);
				string textId = (!flag4) ? "GenericPrompt_Unlocked_TipsText" : "PhantomBattle_1131";
				this.UnlockBtnItem.SetEnableClick(flag4 && flag5);
				this.UnlockBtnItem.SetLocalTextNew(textId, Array.Empty<object>());
			}
		}

		// Token: 0x060376BF RID: 227007 RVA: 0x00E0F8E2 File Offset: 0x00E0DAE2
		private void OnUnlockBtnClick(int _)
		{
			ControllerBase<PhantomArenaController>.Instance.CardOutLookUpRequest(this.Data.CardId, null);
		}

		// Token: 0x060376C0 RID: 227008 RVA: 0x00E0F8FC File Offset: 0x00E0DAFC
		public void PlaySwitchSequence()
		{
			this.SequencePlayer.PlayOrReplaySequenceByName("Switch", false, null);
		}

		// Token: 0x060376C1 RID: 227009 RVA: 0x00E0F924 File Offset: 0x00E0DB24
		public void PlayShowSequence()
		{
			this.SequencePlayer.PlayOrReplaySequenceByName("Start", false, null);
		}

		// Token: 0x0401FD0C RID: 130316
		private IDeckBuilderCardOutlookUnlockPanelData Data;

		// Token: 0x0401FD0D RID: 130317
		private CardOutlookPreviewItem CardItem;

		// Token: 0x0401FD0E RID: 130318
		private ButtonItem UnlockBtnItem;

		// Token: 0x0401FD0F RID: 130319
		private LevelSequencePlayer SequencePlayer;

		// Token: 0x0200B470 RID: 46192
		[NullableContext(0)]
		private static class EComponents
		{
			// Token: 0x04037DB0 RID: 228784
			public const int CardItem = 0;

			// Token: 0x04037DB1 RID: 228785
			public const int UnlockTipText = 1;

			// Token: 0x04037DB2 RID: 228786
			public const int UnlockBtnItem = 2;
		}
	}
}
