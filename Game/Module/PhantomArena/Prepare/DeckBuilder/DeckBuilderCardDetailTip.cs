using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Module.PhantomArena.Common.CardDetail;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.PhantomArena.Prepare.DeckBuilder
{
	// Token: 0x020054EE RID: 21742
	public class DeckBuilderCardDetailTip : UiPanelBase
	{
		// Token: 0x06037677 RID: 226935 RVA: 0x00E0EB58 File Offset: 0x00E0CD58
		protected override void OnRegisterComponent()
		{
			this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
			{
				new ValueTuple<int, Type>(0, typeof(UUIItem)),
				new ValueTuple<int, Type>(1, typeof(UUIItem)),
				new ValueTuple<int, Type>(2, typeof(UUIItem)),
				new ValueTuple<int, Type>(3, typeof(UUILayoutBase)),
				new ValueTuple<int, Type>(4, typeof(UUIItem)),
				new ValueTuple<int, Type>(5, typeof(UUIButtonComponent)),
				new ValueTuple<int, Type>(6, typeof(UUIButtonComponent))
			};
			this.BtnBindInfo = new List<ValueTuple<int, Delegate>>
			{
				new ValueTuple<int, Delegate>(5, new Action(this.OnCardDescBtnClick))
			};
		}

		// Token: 0x06037678 RID: 226936 RVA: 0x00E0EC30 File Offset: 0x00E0CE30
		protected override UniTask OnBeforeStartAsync()
		{
			DeckBuilderCardDetailTip.<OnBeforeStartAsync>d__6 <OnBeforeStartAsync>d__;
			<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeStartAsync>d__.<>4__this = this;
			<OnBeforeStartAsync>d__.<>1__state = -1;
			<OnBeforeStartAsync>d__.<>t__builder.Start<DeckBuilderCardDetailTip.<OnBeforeStartAsync>d__6>(ref <OnBeforeStartAsync>d__);
			return <OnBeforeStartAsync>d__.<>t__builder.Task;
		}

		// Token: 0x06037679 RID: 226937 RVA: 0x00E0EC74 File Offset: 0x00E0CE74
		protected UniTask InitDetailsItem()
		{
			DeckBuilderCardDetailTip.<InitDetailsItem>d__7 <InitDetailsItem>d__;
			<InitDetailsItem>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<InitDetailsItem>d__.<>4__this = this;
			<InitDetailsItem>d__.<>1__state = -1;
			<InitDetailsItem>d__.<>t__builder.Start<DeckBuilderCardDetailTip.<InitDetailsItem>d__7>(ref <InitDetailsItem>d__);
			return <InitDetailsItem>d__.<>t__builder.Task;
		}

		// Token: 0x0603767A RID: 226938 RVA: 0x00E0ECB8 File Offset: 0x00E0CEB8
		protected override void OnStart()
		{
			UUIButtonComponent button = base.GetButton(6);
			if (button != null)
			{
				button.RootUIComp.Get().SetUIActive(false);
			}
			this.EntryDescLayoutItem = new CardDetailEntryDescLayoutItem(base.GetLayoutBase(3), base.GetItem(4));
			base.GetItem(1).SetHierarchyIndex(0);
			UUIItem rootItem = this.RootItem;
			if (rootItem == null)
			{
				return;
			}
			rootItem.SetRaycastTarget(true);
		}

		// Token: 0x0603767B RID: 226939 RVA: 0x00E0ED1C File Offset: 0x00E0CF1C
		private void CheckMouseInTip()
		{
			if (this.RootItem == null || this.IsMouseInSlotItem)
			{
				this.RemoveTimer();
				return;
			}
			ULGUIPointerEventData pointerEventData = Singleton<LguiEventSystemManager>.Instance.GetPointerEventData(0, true);
			if (pointerEventData == null || !pointerEventData.enterComponentStack.Contains(this.RootItem))
			{
				base.SetUiActive(false);
				this.RemoveTimer();
			}
		}

		// Token: 0x0603767C RID: 226940 RVA: 0x00E0ED70 File Offset: 0x00E0CF70
		protected override void OnBeforeHide()
		{
			this.RemoveTimer();
		}

		// Token: 0x0603767D RID: 226941 RVA: 0x00E0ED78 File Offset: 0x00E0CF78
		public void AddTimer()
		{
			this.RemoveTimer();
			this.TimerHandle = TimerSystem.GameplayTimeInstance.Forever(delegate(float _)
			{
				this.CheckMouseInTip();
			}, 100f, 1f, null, null, true);
		}

		// Token: 0x0603767E RID: 226942 RVA: 0x00E0EDA9 File Offset: 0x00E0CFA9
		public void RemoveTimer()
		{
			if (this.TimerHandle != null)
			{
				TimerSystem.GameplayTimeInstance.Remove(this.TimerHandle);
				this.TimerHandle = null;
			}
		}

		// Token: 0x0603767F RID: 226943 RVA: 0x00E0EDCC File Offset: 0x00E0CFCC
		[NullableContext(2)]
		public void RefreshCard(int cardId, DeckInfo deckInfo = null)
		{
			CardDetailItemData detailViewDetailItemData = ModelBase<PhantomArenaModel>.Instance.GetDetailViewDetailItemData(cardId, deckInfo);
			this.DetailItem.Refresh(detailViewDetailItemData);
			PhantomBattleCard phantomBattleCardConfig = ConfigBase<PhantomArenaConfig>.Instance.GetPhantomBattleCardConfig(cardId);
			this.EntryDescLayoutItem.RefreshByCardConfig(phantomBattleCardConfig);
			this.IsEntryShow = false;
			this.RefreshEntryShowState();
		}

		// Token: 0x06037680 RID: 226944 RVA: 0x00E0EE17 File Offset: 0x00E0D017
		public void RefreshEntryShowState()
		{
			base.GetItem(1).SetUIActive(this.IsEntryShow);
		}

		// Token: 0x06037681 RID: 226945 RVA: 0x00E0EE2B File Offset: 0x00E0D02B
		private void OnCardDescBtnClick()
		{
			this.IsEntryShow = !this.IsEntryShow;
			this.RefreshEntryShowState();
		}

		// Token: 0x0401FCEA RID: 130282
		[Nullable(1)]
		protected CardDetailItem DetailItem;

		// Token: 0x0401FCEB RID: 130283
		[Nullable(1)]
		protected CardDetailEntryDescLayoutItem EntryDescLayoutItem;

		// Token: 0x0401FCEC RID: 130284
		[Nullable(2)]
		private TimerHandle TimerHandle;

		// Token: 0x0401FCED RID: 130285
		protected bool IsEntryShow;

		// Token: 0x0401FCEE RID: 130286
		public bool IsMouseInSlotItem;

		// Token: 0x0200B469 RID: 46185
		private static class EComponents
		{
			// Token: 0x04037D91 RID: 228753
			public const int DescRootItem = 0;

			// Token: 0x04037D92 RID: 228754
			public const int EntryRootItem = 1;

			// Token: 0x04037D93 RID: 228755
			public const int CardDetailsItem = 2;

			// Token: 0x04037D94 RID: 228756
			public const int EntryDescLayout = 3;

			// Token: 0x04037D95 RID: 228757
			public const int EntryDescLayoutItem = 4;

			// Token: 0x04037D96 RID: 228758
			public const int CardDescBtn = 5;

			// Token: 0x04037D97 RID: 228759
			public const int BtnMask = 6;
		}
	}
}
