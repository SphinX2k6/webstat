using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using CSharpScript.Core.Extension;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.PhantomArena.Battle.Model;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.PhantomArena.Battle.View.Discard
{
	// Token: 0x020055CB RID: 21963
	[NullableContext(1)]
	[Nullable(0)]
	public class PhantomArenaDiscardCardPanel : UiPanelBase
	{
		// Token: 0x06037F31 RID: 229169 RVA: 0x00E2C224 File Offset: 0x00E2A424
		protected override void OnRegisterComponent()
		{
			this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
			{
				new ValueTuple<int, Type>(0, typeof(UUIText)),
				new ValueTuple<int, Type>(1, typeof(UUIScrollViewWithScrollbarComponent)),
				new ValueTuple<int, Type>(2, typeof(UUIItem)),
				new ValueTuple<int, Type>(3, typeof(UUIItem)),
				new ValueTuple<int, Type>(4, typeof(UUIExtendToggle)),
				new ValueTuple<int, Type>(5, typeof(UUIButtonComponent)),
				new ValueTuple<int, Type>(6, typeof(UUIButtonComponent)),
				new ValueTuple<int, Type>(7, typeof(UUIText))
			};
			this.BtnBindInfo = new List<ValueTuple<int, Delegate>>
			{
				new ValueTuple<int, Delegate>(4, new Action<EToggleState>(this.OnVisibleToggleClick)),
				new ValueTuple<int, Delegate>(5, new Action(this.OnConfirmBtnClick)),
				new ValueTuple<int, Delegate>(6, new Action(this.OnEmptyBtnClick))
			};
		}

		// Token: 0x06037F32 RID: 229170 RVA: 0x00E2C33F File Offset: 0x00E2A53F
		protected override void OnStart()
		{
			this.Scroll = new GenericScrollViewNew<PhantomArenaDiscardCardItem, PhantomCardData>(base.GetScrollViewWithScrollbar(1), new Func<PhantomArenaDiscardCardItem>(this.InitItem), base.GetItem(2).GetOwner() as AUIBaseActor, false, null);
		}

		// Token: 0x06037F33 RID: 229171 RVA: 0x00E2C372 File Offset: 0x00E2A572
		protected override void OnAfterShow()
		{
			Singleton<EventSystem>.Instance.Emit(EEventName.OnPhantomArenaChooseCardPanelShow);
		}

		// Token: 0x06037F34 RID: 229172 RVA: 0x00E2C384 File Offset: 0x00E2A584
		protected override UniTask OnBeforeShowAsyncImplement()
		{
			PhantomArenaDiscardCardPanel.<OnBeforeShowAsyncImplement>d__9 <OnBeforeShowAsyncImplement>d__;
			<OnBeforeShowAsyncImplement>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeShowAsyncImplement>d__.<>4__this = this;
			<OnBeforeShowAsyncImplement>d__.<>1__state = -1;
			<OnBeforeShowAsyncImplement>d__.<>t__builder.Start<PhantomArenaDiscardCardPanel.<OnBeforeShowAsyncImplement>d__9>(ref <OnBeforeShowAsyncImplement>d__);
			return <OnBeforeShowAsyncImplement>d__.<>t__builder.Task;
		}

		// Token: 0x06037F35 RID: 229173 RVA: 0x00E2C3C8 File Offset: 0x00E2A5C8
		protected override void OnAfterHide()
		{
			base.GetItem(3).SetUIActive(true);
			this.ViewProxy.HideCardTips();
			this.ViewProxy.SetCaptionItemActive(true);
			this.ViewProxy.UnRegisterCantDragReason(EPhantomArenaCantDragReason.DiscardCardInteract);
			this.ViewProxy.SetIsMainInVisible(true);
			this.ViewProxy.SetInPanelInteractType(EPhantomArenaBattlePanelInteractType.MainView);
		}

		// Token: 0x06037F36 RID: 229174 RVA: 0x00E2C41D File Offset: 0x00E2A61D
		private PhantomArenaDiscardCardItem InitItem()
		{
			return new PhantomArenaDiscardCardItem
			{
				ClickCallback = new Action<PhantomCardData, bool>(this.CardClick)
			};
		}

		// Token: 0x06037F37 RID: 229175 RVA: 0x00E2C438 File Offset: 0x00E2A638
		private void OnVisibleToggleClick(EToggleState state)
		{
			bool flag = state != EToggleState.ETT_Checked;
			this.ViewProxy.SetIsMainInVisible(!flag);
			this.ViewProxy.HideCardTips();
			base.GetItem(3).SetUIActive(flag);
		}

		// Token: 0x06037F38 RID: 229176 RVA: 0x00E2C474 File Offset: 0x00E2A674
		private void OnConfirmBtnClick()
		{
			this.Data.ConfirmFunc(new List<int>(this.SelectedIdSet)).Finally(delegate()
			{
				if (this.Data.GuideType != null)
				{
					this.ViewProxy.GuideManager.TryFinishGuideByType(this.Data.GuideType.Value, Array.Empty<object>());
				}
			}).Forget();
		}

		// Token: 0x06037F39 RID: 229177 RVA: 0x00E2C4A7 File Offset: 0x00E2A6A7
		private void OnEmptyBtnClick()
		{
			this.ViewProxy.HideCardTips();
		}

		// Token: 0x06037F3A RID: 229178 RVA: 0x00E2C4B4 File Offset: 0x00E2A6B4
		private void CardClick(PhantomCardData data, bool isSelected)
		{
			int cardId = data.CardId;
			this.HandleSelectState(cardId);
			if (isSelected && this.Data.GuideType != null && !this.ViewProxy.GuideManager.CheckCanExecuteAndShowFailTips(this.Data.GuideType.Value, new object[]
			{
				data.ConfigId
			}))
			{
				return;
			}
			if (isSelected && this.SelectedIdSet.Count >= this.Data.LimitCount)
			{
				if (this.Data.LimitCount > 1)
				{
					ControllerBase<ScrollingTipsController>.Instance.ShowTipsByTextId(this.Data.SelectedTips, Array.Empty<object>());
					return;
				}
				this.CancelChooseLastState();
			}
			this.HandleChooseState(cardId, isSelected);
			this.RefreshTitle();
			this.RefreshConfirmInteractive();
		}

		// Token: 0x06037F3B RID: 229179 RVA: 0x00E2C580 File Offset: 0x00E2A780
		private void HandleChooseState(int selectId, bool isSelected)
		{
			PhantomArenaDiscardCardItem scrollItemByKey = this.Scroll.GetScrollItemByKey(selectId);
			if (scrollItemByKey != null)
			{
				scrollItemByKey.SetChooseState(isSelected);
			}
			if (isSelected)
			{
				this.SelectedIdSet.Add(selectId);
				return;
			}
			this.SelectedIdSet.Remove(selectId);
		}

		// Token: 0x06037F3C RID: 229180 RVA: 0x00E2C5C8 File Offset: 0x00E2A7C8
		private void CancelChooseLastState()
		{
			if (this.SelectedIdSet.Count <= 0)
			{
				return;
			}
			int num = this.SelectedIdSet.First<int>();
			if (num != 0)
			{
				this.HandleChooseState(num, false);
				this.ResetToggleState(num);
			}
		}

		// Token: 0x06037F3D RID: 229181 RVA: 0x00E2C602 File Offset: 0x00E2A802
		private void ResetToggleState(int selectId)
		{
			PhantomArenaDiscardCardItem scrollItemByKey = this.Scroll.GetScrollItemByKey(selectId);
			if (scrollItemByKey == null)
			{
				return;
			}
			scrollItemByKey.Card.SetToggleState(EToggleState.ETT_UnChecked, false);
		}

		// Token: 0x06037F3E RID: 229182 RVA: 0x00E2C628 File Offset: 0x00E2A828
		private void HandleSelectState(int selectId)
		{
			if (this.CurrentSelectId == selectId)
			{
				return;
			}
			if (this.CurrentSelectId != -1)
			{
				PhantomArenaDiscardCardItem scrollItemByKey = this.Scroll.GetScrollItemByKey(this.CurrentSelectId);
				if (scrollItemByKey != null)
				{
					scrollItemByKey.SetSelectState(false);
				}
			}
			PhantomArenaDiscardCardItem scrollItemByKey2 = this.Scroll.GetScrollItemByKey(selectId);
			if (scrollItemByKey2 != null)
			{
				scrollItemByKey2.SetSelectState(true);
				this.ViewProxy.ShowCardTips(scrollItemByKey2.Card.Data, false);
			}
			this.CurrentSelectId = selectId;
		}

		// Token: 0x06037F3F RID: 229183 RVA: 0x00E2C6A4 File Offset: 0x00E2A8A4
		private void RefreshTitle()
		{
			base.GetText(0).SetText(this.SelectedIdSet.Count.ToString() + "/" + this.Data.LimitCount.ToString(), true);
		}

		// Token: 0x06037F40 RID: 229184 RVA: 0x00E2C6EE File Offset: 0x00E2A8EE
		private void RefreshTitleTips()
		{
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(7), this.Data.TitleTips, Array.Empty<object>());
		}

		// Token: 0x06037F41 RID: 229185 RVA: 0x00E2C711 File Offset: 0x00E2A911
		private void RefreshConfirmInteractive()
		{
			base.GetButton(5).SetSelfInteractive(this.SelectedIdSet.Count >= this.Data.LimitCount);
		}

		// Token: 0x06037F42 RID: 229186 RVA: 0x00E2C73A File Offset: 0x00E2A93A
		public void RegisterViewProxy(PhantomArenaBattleProxy proxy)
		{
			this.ViewProxy = proxy;
		}

		// Token: 0x06037F43 RID: 229187 RVA: 0x00E2C743 File Offset: 0x00E2A943
		public void SetDiscardCardData(IDiscardCardPanelData data)
		{
			this.Data = data;
		}

		// Token: 0x06037F44 RID: 229188 RVA: 0x00E2C74C File Offset: 0x00E2A94C
		public override UUIItem[] GetGuideUiItemAndUiItemForShowEx(string[] configParams)
		{
			if (configParams.Length == 0)
			{
				return null;
			}
			if (configParams[0] == "BattleCardDiscardById")
			{
				int num = int.Parse(configParams[1]);
				foreach (PhantomArenaDiscardCardItem phantomArenaDiscardCardItem in this.Scroll.GetScrollItemList())
				{
					if (phantomArenaDiscardCardItem.Card.Data.ConfigId == num)
					{
						UUIItem rootItem = phantomArenaDiscardCardItem.Card.GetRootItem();
						if (rootItem != null)
						{
							return new UUIItem[]
							{
								rootItem,
								rootItem
							};
						}
					}
				}
			}
			return null;
		}

		// Token: 0x0401FFFD RID: 131069
		protected PhantomArenaBattleProxy ViewProxy;

		// Token: 0x0401FFFE RID: 131070
		protected GenericScrollViewNew<PhantomArenaDiscardCardItem, PhantomCardData> Scroll;

		// Token: 0x0401FFFF RID: 131071
		protected HashSet<int> SelectedIdSet = new HashSet<int>();

		// Token: 0x04020000 RID: 131072
		protected IDiscardCardPanelData Data;

		// Token: 0x04020001 RID: 131073
		protected int CurrentSelectId = -1;

		// Token: 0x0200B5BB RID: 46523
		[NullableContext(0)]
		private class EComponentDefine
		{
			// Token: 0x040383BB RID: 230331
			public const int Title = 0;

			// Token: 0x040383BC RID: 230332
			public const int Scroll = 1;

			// Token: 0x040383BD RID: 230333
			public const int ScrollItem = 2;

			// Token: 0x040383BE RID: 230334
			public const int ContentItem = 3;

			// Token: 0x040383BF RID: 230335
			public const int VisibleToggle = 4;

			// Token: 0x040383C0 RID: 230336
			public const int ConfirmBtn = 5;

			// Token: 0x040383C1 RID: 230337
			public const int EmptyBtn = 6;

			// Token: 0x040383C2 RID: 230338
			public const int TitleTips = 7;
		}
	}
}
