using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using Aki.Protocol;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.Activity.ActivityContent.Roverlike
{
	// Token: 0x0200642E RID: 25646
	[NullableContext(2)]
	[Nullable(0)]
	public class RoverlikeLootView : UiViewBase
	{
		// Token: 0x06040620 RID: 263712 RVA: 0x01081414 File Offset: 0x0107F614
		[NullableContext(1)]
		public RoverlikeLootView(UiViewInfo info) : base(info)
		{
		}

		// Token: 0x06040621 RID: 263713 RVA: 0x0108143C File Offset: 0x0107F63C
		protected unsafe override void OnRegisterComponent()
		{
			int num = 9;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUILoopScrollViewComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(5, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(6, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(7, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(8, typeof(UUIText));
			this.ComponentRegisterInfos = list;
		}

		// Token: 0x06040622 RID: 263714 RVA: 0x01081590 File Offset: 0x0107F790
		protected override UniTask OnBeforeStartAsync()
		{
			RoverlikeLootView.<OnBeforeStartAsync>d__20 <OnBeforeStartAsync>d__;
			<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeStartAsync>d__.<>4__this = this;
			<OnBeforeStartAsync>d__.<>1__state = -1;
			<OnBeforeStartAsync>d__.<>t__builder.Start<RoverlikeLootView.<OnBeforeStartAsync>d__20>(ref <OnBeforeStartAsync>d__);
			return <OnBeforeStartAsync>d__.<>t__builder.Task;
		}

		// Token: 0x06040623 RID: 263715 RVA: 0x010815D4 File Offset: 0x0107F7D4
		protected override void OnStart()
		{
			this.Caption = new PopupCaptionItem(base.GetItem(0));
			this.BtnConfirmRoot = base.GetItem(4);
			this.BtnConfirm = new ButtonItem(this.BtnConfirmRoot);
			this.PnlActivated = base.GetItem(5);
			this.PnlBubble = base.GetItem(6);
			this.TxtTips = base.GetText(8);
			this.LootScroll = new LoopScrollView<RoverlikeLootItem, RoverlikeLootGainEntry>(base.GetLoopScrollViewComponent(1), base.GetItem(2).GetOwner() as AUIBaseActor, new Func<RoverlikeLootItem>(this.CreateLootItem), false);
			this.InitFromOpenParam();
			this.Caption.SetCloseCallBack(delegate
			{
				base.CloseMe(null);
			});
			this.BtnConfirm.SetFunction(new Action<int>(this.OnClickConfirm));
			if (!this.IsInGame)
			{
				RoverlikeActivityData activityData = this.ActivityData;
				if (activityData != null)
				{
					activityData.MarkLootUnlockRedDotRead();
				}
			}
			this.RefreshLootScroll();
			this.UpdateConfirmState();
		}

		// Token: 0x06040624 RID: 263716 RVA: 0x010816C1 File Offset: 0x0107F8C1
		protected override void OnBeforeDestroy()
		{
			if (!this.IsInGame)
			{
				RoverlikeActivityData activityData = this.ActivityData;
				if (activityData == null)
				{
					return;
				}
				activityData.ClearNewUnlockedLootIds();
			}
		}

		// Token: 0x06040625 RID: 263717 RVA: 0x010816DC File Offset: 0x0107F8DC
		private void InitFromOpenParam()
		{
			RoverlikeLootViewOpenParam roverlikeLootViewOpenParam = this.OpenParam as RoverlikeLootViewOpenParam;
			this.IsInGame = (roverlikeLootViewOpenParam != null && roverlikeLootViewOpenParam.IsInGame);
			List<RoverRogueGainEntry> loots = ((roverlikeLootViewOpenParam != null) ? roverlikeLootViewOpenParam.Loots : null) ?? new List<RoverRogueGainEntry>();
			this.OnConfirmSelect = ((roverlikeLootViewOpenParam != null) ? roverlikeLootViewOpenParam.OnConfirmSelect : null);
			this.IsSelectMode = (this.OnConfirmSelect != null);
			this.DefaultSelectedLootId = ((roverlikeLootViewOpenParam != null) ? roverlikeLootViewOpenParam.DefaultSelectedLootId : 0);
			this.EquippedLootIds.Clear();
			foreach (int item in (((roverlikeLootViewOpenParam != null) ? roverlikeLootViewOpenParam.EquippedLootIds : null) ?? new List<int>()))
			{
				this.EquippedLootIds.Add(item);
			}
			if (this.IsInGame)
			{
				this.InitInGame(roverlikeLootViewOpenParam);
			}
			else
			{
				this.InitOutOfGame(roverlikeLootViewOpenParam);
			}
			this.LootDataList = this.BuildLootDataList(loots);
		}

		// Token: 0x06040626 RID: 263718 RVA: 0x010817DC File Offset: 0x0107F9DC
		private void InitInGame(RoverlikeLootViewOpenParam param)
		{
			this.CanSwitch = ((param != null) ? param.EnableUse : null).GetValueOrDefault();
		}

		// Token: 0x06040627 RID: 263719 RVA: 0x0108180C File Offset: 0x0107FA0C
		private void InitOutOfGame(RoverlikeLootViewOpenParam param)
		{
			this.CanSwitch = ((param != null) ? param.EnableUse : null).GetValueOrDefault(true);
		}

		// Token: 0x06040628 RID: 263720 RVA: 0x0108183C File Offset: 0x0107FA3C
		[NullableContext(1)]
		private List<RoverlikeLootGainEntry> BuildLootDataList(List<RoverRogueGainEntry> loots)
		{
			List<RoverlikeLootGainEntry> list = new List<RoverlikeLootGainEntry>();
			foreach (RoverRogueGainEntry proto in loots)
			{
				RoverlikeLootGainEntry roverlikeLootGainEntry = new RoverlikeLootGainEntry(proto);
				roverlikeLootGainEntry.IsEquipped = this.EquippedLootIds.Contains(roverlikeLootGainEntry.ConfigId);
				list.Add(roverlikeLootGainEntry);
			}
			list.Sort(delegate(RoverlikeLootGainEntry a, RoverlikeLootGainEntry b)
			{
				if (a.Unlock != b.Unlock)
				{
					if (!a.Unlock)
					{
						return 1;
					}
					return -1;
				}
				else
				{
					if (a.LootLv != b.LootLv)
					{
						return b.LootLv - a.LootLv;
					}
					return a.ConfigId - b.ConfigId;
				}
			});
			return list;
		}

		// Token: 0x06040629 RID: 263721 RVA: 0x010818D4 File Offset: 0x0107FAD4
		[NullableContext(1)]
		private RoverlikeLootItem CreateLootItem()
		{
			RoverlikeLootItem roverlikeLootItem = new RoverlikeLootItem();
			roverlikeLootItem.BindOnItemSelect(new Action<RoverlikeLootGainEntry>(this.OnSelectLoot));
			roverlikeLootItem.GetHasRedDot = new Func<RoverlikeLootGainEntry, bool>(this.IsLootRedDotVisible);
			return roverlikeLootItem;
		}

		// Token: 0x17009DF5 RID: 40437
		// (get) Token: 0x0604062A RID: 263722 RVA: 0x010818FF File Offset: 0x0107FAFF
		private RoverlikeActivityData ActivityData
		{
			get
			{
				RoverlikeActivityController instance = ControllerBase<RoverlikeActivityController>.Instance;
				if (instance == null)
				{
					return null;
				}
				return instance.GetCurrentActivityData();
			}
		}

		// Token: 0x0604062B RID: 263723 RVA: 0x01081911 File Offset: 0x0107FB11
		[NullableContext(1)]
		private bool IsLootRedDotVisible(RoverlikeLootGainEntry data)
		{
			if (this.IsInGame)
			{
				return false;
			}
			RoverlikeActivityData activityData = this.ActivityData;
			return activityData != null && activityData.IsLootNewUnlocked(data.ConfigId);
		}

		// Token: 0x0604062C RID: 263724 RVA: 0x01081934 File Offset: 0x0107FB34
		private void RefreshLootScroll()
		{
			this.LootScroll.RefreshByData(this.LootDataList, false, delegate
			{
				int defaultSelectIndex = this.GetDefaultSelectIndex();
				if (defaultSelectIndex >= 0)
				{
					this.OnSelectLoot(this.LootDataList[defaultSelectIndex]);
				}
			}, false);
		}

		// Token: 0x0604062D RID: 263725 RVA: 0x01081958 File Offset: 0x0107FB58
		private int GetDefaultSelectIndex()
		{
			if (this.IsSelectMode && this.DefaultSelectedLootId > 0)
			{
				int num = this.LootDataList.FindIndex((RoverlikeLootGainEntry entry) => entry.ConfigId == this.DefaultSelectedLootId && this.IsSelectable(entry));
				if (num >= 0)
				{
					return num;
				}
			}
			int num2 = this.LootDataList.FindIndex((RoverlikeLootGainEntry entry) => entry.Unlock && this.EquippedLootIds.Contains(entry.ConfigId));
			if (num2 >= 0)
			{
				return num2;
			}
			int num3 = this.LootDataList.FindIndex((RoverlikeLootGainEntry entry) => this.IsSelectable(entry));
			if (num3 >= 0)
			{
				return num3;
			}
			if (this.LootDataList.Count <= 0)
			{
				return -1;
			}
			return 0;
		}

		// Token: 0x0604062E RID: 263726 RVA: 0x010819E4 File Offset: 0x0107FBE4
		[NullableContext(1)]
		private void OnSelectLoot(RoverlikeLootGainEntry entry)
		{
			if (this.SelectedEntry == entry)
			{
				return;
			}
			if (!this.IsInGame)
			{
				RoverlikeActivityData activityData = this.ActivityData;
				if (activityData != null && activityData.IsLootNewUnlocked(entry.ConfigId))
				{
					this.ActivityData.MarkLootNewUnlockedRead(entry.ConfigId);
					int num = this.LootDataList.IndexOf(entry);
					if (num >= 0)
					{
						LoopScrollView<RoverlikeLootItem, RoverlikeLootGainEntry> lootScroll = this.LootScroll;
						if (lootScroll != null)
						{
							lootScroll.RefreshGridProxy(num);
						}
					}
				}
			}
			bool flag = this.SelectedEntry == null;
			this.SelectedEntry = entry;
			int num2 = this.LootDataList.IndexOf(entry);
			if (num2 >= 0)
			{
				this.LootScroll.SelectGridProxy(num2, false);
			}
			this.RefreshDetail(entry);
			this.UpdateConfirmState();
			if (!flag)
			{
				base.PlayOrReplaySequence("Switch", false, null);
			}
		}

		// Token: 0x0604062F RID: 263727 RVA: 0x01081AA3 File Offset: 0x0107FCA3
		[NullableContext(1)]
		private bool IsSelectable(RoverlikeLootGainEntry entry)
		{
			return entry.Unlock && !this.EquippedLootIds.Contains(entry.ConfigId);
		}

		// Token: 0x06040630 RID: 263728 RVA: 0x01081AC3 File Offset: 0x0107FCC3
		[NullableContext(1)]
		private void RefreshDetail(RoverlikeLootGainEntry entry)
		{
			RoverlikeLootCardItem detailCard = this.DetailCard;
			if (detailCard != null)
			{
				detailCard.Refresh(entry);
			}
			this.RefreshApplyRoleType(entry);
		}

		// Token: 0x06040631 RID: 263729 RVA: 0x01081AE0 File Offset: 0x0107FCE0
		[NullableContext(1)]
		private void RefreshApplyRoleType(RoverlikeLootGainEntry entry)
		{
			RoverRogueLoot? lootConfig = ConfigBase<RoverlikeConfig>.Instance.GetLootConfig(entry.ConfigId);
			int num = (lootConfig != null) ? lootConfig.GetValueOrDefault().ApplyRoleType : 0;
			if (num != 0)
			{
				UUIItem pnlBubble = this.PnlBubble;
				if (pnlBubble != null)
				{
					pnlBubble.SetUIActive(true);
				}
				RoverRogueRoleType? roleTypeConfig = ConfigBase<RoverlikeConfig>.Instance.GetRoleTypeConfig(num);
				RoverlikeLootElementIcon elementIcon = this.ElementIcon;
				if (elementIcon != null)
				{
					elementIcon.Refresh(((roleTypeConfig != null) ? roleTypeConfig.GetValueOrDefault().ElementIcon : null) ?? "");
				}
				Singleton<LguiUtil>.Instance.SetLocalTextNew(this.TxtTips, ((lootConfig != null) ? lootConfig.GetValueOrDefault().ApplyRoleTypeLockDesc : null) ?? "", Array.Empty<object>());
				return;
			}
			UUIItem pnlBubble2 = this.PnlBubble;
			if (pnlBubble2 == null)
			{
				return;
			}
			pnlBubble2.SetUIActive(false);
		}

		// Token: 0x06040632 RID: 263730 RVA: 0x01081BC0 File Offset: 0x0107FDC0
		private void UpdateConfirmState()
		{
			RoverlikeLootGainEntry selectedEntry = this.SelectedEntry;
			bool flag = selectedEntry != null && selectedEntry.Unlock && this.EquippedLootIds.Contains(selectedEntry.ConfigId);
			bool flag2 = selectedEntry != null && !flag;
			UUIItem pnlActivated = this.PnlActivated;
			if (pnlActivated != null)
			{
				pnlActivated.SetUIActive(flag);
			}
			UUIItem btnConfirmRoot = this.BtnConfirmRoot;
			if (btnConfirmRoot != null)
			{
				btnConfirmRoot.SetUIActive(flag2);
			}
			if (flag2)
			{
				this.BtnConfirm.SetEnableClick(this.CanConfirm());
			}
		}

		// Token: 0x06040633 RID: 263731 RVA: 0x01081C37 File Offset: 0x0107FE37
		private bool CanConfirm()
		{
			return this.SelectedEntry != null && this.IsSelectable(this.SelectedEntry) && (this.IsSelectMode || this.CanSwitch);
		}

		// Token: 0x06040634 RID: 263732 RVA: 0x01081C64 File Offset: 0x0107FE64
		private void OnClickConfirm(int _)
		{
			RoverlikeLootGainEntry selectedEntry = this.SelectedEntry;
			if (selectedEntry == null || !this.IsSelectable(selectedEntry))
			{
				return;
			}
			if (this.IsSelectMode)
			{
				this.ConfirmSelect(selectedEntry);
				return;
			}
			if (this.IsInGame)
			{
				this.ConfirmInGame(selectedEntry);
				return;
			}
			this.ConfirmOutOfGame(selectedEntry);
		}

		// Token: 0x06040635 RID: 263733 RVA: 0x01081CAC File Offset: 0x0107FEAC
		[NullableContext(1)]
		private void ConfirmSelect(RoverlikeLootGainEntry entry)
		{
			Action<int, int> onConfirmSelect = this.OnConfirmSelect;
			if (onConfirmSelect != null)
			{
				onConfirmSelect(entry.ConfigId, entry.LootLv);
			}
			base.CloseMe(null);
		}

		// Token: 0x06040636 RID: 263734 RVA: 0x01081CD2 File Offset: 0x0107FED2
		[NullableContext(1)]
		private void ConfirmInGame(RoverlikeLootGainEntry entry)
		{
			if (!this.CanSwitch)
			{
				return;
			}
			ControllerBase<RoverlikeController>.Instance.RoverRogueLootChangeRequest(entry.ConfigId, delegate(bool success)
			{
				if (success)
				{
					this.CanSwitch = false;
				}
				base.CloseMe(null);
			});
		}

		// Token: 0x06040637 RID: 263735 RVA: 0x01081CF9 File Offset: 0x0107FEF9
		[NullableContext(1)]
		private void ConfirmOutOfGame(RoverlikeLootGainEntry entry)
		{
		}

		// Token: 0x04024107 RID: 147719
		protected PopupCaptionItem Caption;

		// Token: 0x04024108 RID: 147720
		protected ButtonItem BtnConfirm;

		// Token: 0x04024109 RID: 147721
		private UUIItem BtnConfirmRoot;

		// Token: 0x0402410A RID: 147722
		private UUIItem PnlActivated;

		// Token: 0x0402410B RID: 147723
		private UUIItem PnlBubble;

		// Token: 0x0402410C RID: 147724
		private RoverlikeLootElementIcon ElementIcon;

		// Token: 0x0402410D RID: 147725
		private UUIText TxtTips;

		// Token: 0x0402410E RID: 147726
		[Nullable(new byte[]
		{
			2,
			1,
			1
		})]
		private LoopScrollView<RoverlikeLootItem, RoverlikeLootGainEntry> LootScroll;

		// Token: 0x0402410F RID: 147727
		private RoverlikeLootCardItem DetailCard;

		// Token: 0x04024110 RID: 147728
		[Nullable(1)]
		private List<RoverlikeLootGainEntry> LootDataList = new List<RoverlikeLootGainEntry>();

		// Token: 0x04024111 RID: 147729
		private RoverlikeLootGainEntry SelectedEntry;

		// Token: 0x04024112 RID: 147730
		private bool IsInGame;

		// Token: 0x04024113 RID: 147731
		private bool CanSwitch = true;

		// Token: 0x04024114 RID: 147732
		[Nullable(1)]
		private readonly HashSet<int> EquippedLootIds = new HashSet<int>();

		// Token: 0x04024115 RID: 147733
		private bool IsSelectMode;

		// Token: 0x04024116 RID: 147734
		private Action<int, int> OnConfirmSelect;

		// Token: 0x04024117 RID: 147735
		private int DefaultSelectedLootId;

		// Token: 0x0200C49D RID: 50333
		[NullableContext(0)]
		private class EComponents
		{
			// Token: 0x0403C84C RID: 247884
			public const int Caption = 0;

			// Token: 0x0403C84D RID: 247885
			public const int LootScroll = 1;

			// Token: 0x0403C84E RID: 247886
			public const int LootItemTemplate = 2;

			// Token: 0x0403C84F RID: 247887
			public const int DetailCard = 3;

			// Token: 0x0403C850 RID: 247888
			public const int BtnConfirm = 4;

			// Token: 0x0403C851 RID: 247889
			public const int PnlActivated = 5;

			// Token: 0x0403C852 RID: 247890
			public const int PnlBubble = 6;

			// Token: 0x0403C853 RID: 247891
			public const int PnlElementIcon = 7;

			// Token: 0x0403C854 RID: 247892
			public const int TxtTips = 8;
		}
	}
}
