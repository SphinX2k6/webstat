using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using UnrealEngine;

namespace CSharpScript.Game.Module.Activity.ActivityContent.Roverlike
{
	// Token: 0x020063D2 RID: 25554
	[NullableContext(1)]
	[Nullable(0)]
	public class RoverlikeSubViewBlessingReinforcement : RoverlikeActionSubViewBase
	{
		// Token: 0x17009DB2 RID: 40370
		// (get) Token: 0x06040289 RID: 262793 RVA: 0x010713F0 File Offset: 0x0106F5F0
		public override ERoverActionSubViewType SubViewType
		{
			get
			{
				return ERoverActionSubViewType.SelectBlessing;
			}
		}

		// Token: 0x17009DB3 RID: 40371
		// (get) Token: 0x0604028A RID: 262794 RVA: 0x010713F3 File Offset: 0x0106F5F3
		public override string ResourceId
		{
			get
			{
				return "UiItem_RogueBlessingEnhance";
			}
		}

		// Token: 0x0604028B RID: 262795 RVA: 0x010713FC File Offset: 0x0106F5FC
		protected unsafe override void OnRegisterComponent()
		{
			int num = 5;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIHorizontalLayout));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIButtonComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIText));
			this.ComponentRegisterInfos = list;
			num2 = 1;
			List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
			CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
			Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
			num = 0;
			*span2[num] = new ValueTuple<int, Delegate>(2, new Action(this.OnBtnConfirmClick));
			this.BtnBindInfo = list2;
		}

		// Token: 0x0604028C RID: 262796 RVA: 0x01071508 File Offset: 0x0106F708
		protected override void OnStart()
		{
			this.BlessingCardLayout = new GenericLayout<RoverlikeBlessingCardItem, IRoverlikeBlessingItemData>(base.GetHorizontalLayout(0), new Func<RoverlikeBlessingCardItem>(this.CreateBlessingItem), null, false, true);
			this.ButtonRefresh = new ButtonItem(base.GetItem(3));
			this.ButtonRefresh.SetFunction(delegate(int _)
			{
				this.OnBtnRefreshClick();
			});
		}

		// Token: 0x0604028D RID: 262797 RVA: 0x0107155F File Offset: 0x0106F75F
		protected override void OnBeforeDestroy()
		{
			this.ChooseData = null;
		}

		// Token: 0x0604028E RID: 262798 RVA: 0x01071568 File Offset: 0x0106F768
		protected override void OnBeforeShow()
		{
			Singleton<EventSystem>.Instance.Add<int>(EEventName.OnPlayerCurrencyChange, new Action<int>(this.OnCurrencyChange));
		}

		// Token: 0x0604028F RID: 262799 RVA: 0x01071586 File Offset: 0x0106F786
		protected override void OnBeforeHide()
		{
			Singleton<EventSystem>.Instance.Remove<int>(EEventName.OnPlayerCurrencyChange, new Action<int>(this.OnCurrencyChange));
		}

		// Token: 0x06040290 RID: 262800 RVA: 0x010715A4 File Offset: 0x0106F7A4
		private void OnBtnConfirmClick()
		{
			base.TryInteractAction(delegate
			{
				if (this.SelectedEntryIndex < 0 || this.ChooseData == null)
				{
					return;
				}
				RoverlikeGainEntry roverlikeGainEntry = this.ChooseData.Entries[this.SelectedEntryIndex];
				if (roverlikeGainEntry == null)
				{
					return;
				}
				this.OpenBlessingEnhanceConfirmView(roverlikeGainEntry);
			});
		}

		// Token: 0x06040291 RID: 262801 RVA: 0x010715B9 File Offset: 0x0106F7B9
		private void OnBtnRefreshClick()
		{
			base.TryInteractAction(delegate
			{
				if (this.ChooseData == null)
				{
					return;
				}
				if (!this.ChooseData.CanRefresh())
				{
					ControllerBase<ScrollingTipsController>.Instance.ShowTipsByTextId("RoverRogue_InsufficientFund", Array.Empty<object>());
					return;
				}
				ControllerBase<RoverlikeController>.Instance.RoverRogueRefreshGainRequest(this.ChooseData.BindId, null);
			});
		}

		// Token: 0x06040292 RID: 262802 RVA: 0x010715D0 File Offset: 0x0106F7D0
		private void OnBlessingItemSelect(IRoverlikeBlessingItemData data)
		{
			if (this.ChooseData == null)
			{
				return;
			}
			int num = this.ChooseData.Entries.FindIndex(delegate(RoverlikeGainEntry entry)
			{
				int incId = entry.IncId;
				int? incId2 = data.IncId;
				return incId == incId2.GetValueOrDefault() & incId2 != null;
			});
			if (num < 0 || num == this.SelectedEntryIndex)
			{
				return;
			}
			this.SelectedEntryIndex = num;
			this.RefreshBlessingSelection();
		}

		// Token: 0x06040293 RID: 262803 RVA: 0x0107162C File Offset: 0x0106F82C
		private void OpenBlessingEnhanceConfirmView(RoverlikeGainEntry curBless)
		{
			RoverRogueBless? blessConfig = ConfigBase<RoverlikeConfig>.Instance.GetBlessConfig(curBless.ConfigId);
			RoverlikeBlessingReplaceParam param = new RoverlikeBlessingReplaceParam
			{
				CurBlessId = curBless.ConfigId,
				NewBlessId = ((blessConfig != null) ? blessConfig.GetValueOrDefault().NextBlessId : 0),
				Type = ERoverlikeBlessingReplaceType.Enhance,
				OnConfirm = delegate
				{
					ControllerBase<RoverlikeController>.Instance.RoverRogueChooseDataResultRequest(this.ChooseData.BindId, curBless.IncId, null);
				}
			};
			Singleton<UiManager>.Instance.OpenView(EUiViewName.RoverlikeBlessingReplaceView, param, null);
		}

		// Token: 0x06040294 RID: 262804 RVA: 0x010716C5 File Offset: 0x0106F8C5
		private RoverlikeBlessingCardItem CreateBlessingItem()
		{
			RoverlikeBlessingCardItem roverlikeBlessingCardItem = new RoverlikeBlessingCardItem();
			roverlikeBlessingCardItem.BindOnItemSelect(new Action<IRoverlikeBlessingItemData>(this.OnBlessingItemSelect));
			return roverlikeBlessingCardItem;
		}

		// Token: 0x06040295 RID: 262805 RVA: 0x010716DE File Offset: 0x0106F8DE
		private void RefreshBlessingLayout(List<IRoverlikeBlessingItemData> dataList)
		{
			this.BlessingCardLayout.RefreshByData(dataList, new Action(this.OnBlessingLayoutRefreshed), true);
		}

		// Token: 0x06040296 RID: 262806 RVA: 0x010716F9 File Offset: 0x0106F8F9
		private void OnBlessingLayoutRefreshed()
		{
			Singleton<EventSystem>.Instance.Emit<string>(EEventName.OnGuideTriggerEvent, "RoverlikeBlessingReinforcement");
			ControllerBase<UiNavigationNewController>.Instance.MarkViewHandleRefreshNavigationDirty();
		}

		// Token: 0x06040297 RID: 262807 RVA: 0x0107171A File Offset: 0x0106F91A
		private void RefreshBlessingSelection()
		{
			this.BlessingCardLayout.SelectGridProxy(this.SelectedEntryIndex, false);
			this.RefreshButton();
			this.RefreshSlotHighlight();
		}

		// Token: 0x06040298 RID: 262808 RVA: 0x0107173C File Offset: 0x0106F93C
		private void RefreshSlotHighlight()
		{
			RoverlikeActionSubViewManager actionSubViewManager = ModelBase<RoverlikeModel>.Instance.ActionSubViewManager;
			RoverlikeBattleTopPanel roverlikeBattleTopPanel = (actionSubViewManager != null) ? actionSubViewManager.GetActionTopPanel() : null;
			if (roverlikeBattleTopPanel == null)
			{
				return;
			}
			if (this.SelectedEntryIndex >= 0 && this.ChooseData != null)
			{
				RoverlikeGainEntry roverlikeGainEntry = this.ChooseData.Entries[this.SelectedEntryIndex];
				if (roverlikeGainEntry != null)
				{
					roverlikeBattleTopPanel.SetHighlightByBlessId(roverlikeGainEntry.ConfigId);
					return;
				}
			}
			roverlikeBattleTopPanel.ClearHighlight();
		}

		// Token: 0x06040299 RID: 262809 RVA: 0x010717A4 File Offset: 0x0106F9A4
		private void RefreshButton()
		{
			base.GetButton(2).SetSelfInteractive(this.SelectedEntryIndex >= 0);
			bool flag = this.ChooseData.EnableRefresh();
			base.GetItem(3).SetUIActive(flag);
			if (!flag)
			{
				return;
			}
			UUIText text = base.GetText(4);
			bool enableClick = this.ChooseData.HasRefreshTime();
			bool flag2 = this.ChooseData.HasRefreshCost();
			ButtonItem buttonRefresh = this.ButtonRefresh;
			if (buttonRefresh != null)
			{
				buttonRefresh.SetEnableClick(enableClick);
			}
			ButtonItem buttonRefresh2 = this.ButtonRefresh;
			if (buttonRefresh2 != null)
			{
				buttonRefresh2.SetLocalTextNew("RoverRogue_RefreshCount", new object[]
				{
					this.ChooseData.UseTime,
					this.ChooseData.MaxTime
				});
			}
			Singleton<LguiUtil>.Instance.SetLocalTextNew(text, "RoverRogue_RefreshCost", new <>z__ReadOnlySingleElementList<object>(this.ChooseData.RefreshCost));
			UUIItem uuiitem = text;
			bool bUseChangeColor = !flag2;
			FColor? fcolor = new FColor?(text.changeColor);
			uuiitem.SetChangeColor(bUseChangeColor, fcolor);
		}

		// Token: 0x0604029A RID: 262810 RVA: 0x01071898 File Offset: 0x0106FA98
		private void OnCurrencyChange(int itemId)
		{
			int? goldItemId = ModelBase<RoverlikeModel>.Instance.GoldItemId;
			if (!(itemId == goldItemId.GetValueOrDefault() & goldItemId != null))
			{
				return;
			}
			this.RefreshButton();
		}

		// Token: 0x0604029B RID: 262811 RVA: 0x010718CC File Offset: 0x0106FACC
		public override void OnRefreshSubView()
		{
			int bindId = (int)this.OpenParam;
			RoverlikeActionData actionData = ModelBase<RoverlikeModel>.Instance.ActionData;
			RoverlikeChooseData roverlikeChooseData = (actionData != null) ? actionData.GetChooseDataByBindId(bindId) : null;
			if (roverlikeChooseData == null || roverlikeChooseData.Entries.Count == 0)
			{
				return;
			}
			this.ChooseData = roverlikeChooseData;
			this.SelectedEntryIndex = -1;
			List<IRoverlikeBlessingItemData> list = new List<IRoverlikeBlessingItemData>();
			foreach (RoverlikeGainEntry roverlikeGainEntry in this.ChooseData.Entries)
			{
				RoverlikeBlessingItemData item = new RoverlikeBlessingItemData
				{
					BlessId = roverlikeGainEntry.ConfigId,
					IncId = new int?(roverlikeGainEntry.IncId),
					IsUp = new bool?(true)
				};
				list.Add(item);
			}
			this.RefreshBlessingLayout(list);
			this.RefreshButton();
			this.RefreshSlotHighlight();
		}

		// Token: 0x04023FF5 RID: 147445
		[Nullable(new byte[]
		{
			2,
			1,
			1
		})]
		private GenericLayout<RoverlikeBlessingCardItem, IRoverlikeBlessingItemData> BlessingCardLayout;

		// Token: 0x04023FF6 RID: 147446
		[Nullable(2)]
		private RoverlikeChooseData ChooseData;

		// Token: 0x04023FF7 RID: 147447
		[Nullable(2)]
		private ButtonItem ButtonRefresh;

		// Token: 0x04023FF8 RID: 147448
		private int SelectedEntryIndex = -1;

		// Token: 0x0200C433 RID: 50227
		[NullableContext(0)]
		private class EComponents
		{
			// Token: 0x0403C664 RID: 247396
			public const int BlessingLayout = 0;

			// Token: 0x0403C665 RID: 247397
			public const int ItemBlessing = 1;

			// Token: 0x0403C666 RID: 247398
			public const int BtnConfirm = 2;

			// Token: 0x0403C667 RID: 247399
			public const int BtnRefresh = 3;

			// Token: 0x0403C668 RID: 247400
			public const int TxtRefreshCost = 4;
		}
	}
}
