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
	// Token: 0x020063D6 RID: 25558
	[NullableContext(1)]
	[Nullable(0)]
	public class RoverlikeSubViewSelectBlessing : RoverlikeActionSubViewBase
	{
		// Token: 0x17009DBA RID: 40378
		// (get) Token: 0x060402D1 RID: 262865 RVA: 0x0107259A File Offset: 0x0107079A
		public override ERoverActionSubViewType SubViewType
		{
			get
			{
				return ERoverActionSubViewType.SelectBlessing;
			}
		}

		// Token: 0x17009DBB RID: 40379
		// (get) Token: 0x060402D2 RID: 262866 RVA: 0x0107259D File Offset: 0x0107079D
		public override string ResourceId
		{
			get
			{
				return "UiItem_RoverlikeBlessingSelect";
			}
		}

		// Token: 0x060402D3 RID: 262867 RVA: 0x010725A4 File Offset: 0x010707A4
		protected unsafe override void OnRegisterComponent()
		{
			int num = 7;
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
			num2++;
			*span[num2] = new ValueTuple<int, Type>(5, typeof(UUITexture));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(6, typeof(UUIText));
			this.ComponentRegisterInfos = list;
			num2 = 1;
			List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
			CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
			Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
			num = 0;
			*span2[num] = new ValueTuple<int, Delegate>(2, new Action(this.OnBtnConfirmClick));
			this.BtnBindInfo = list2;
		}

		// Token: 0x060402D4 RID: 262868 RVA: 0x010726F0 File Offset: 0x010708F0
		protected override void OnStart()
		{
			this.BlessingCardLayout = new GenericLayout<RoverlikeBlessingCardItem, IRoverlikeBlessingItemData>(base.GetHorizontalLayout(0), new Func<RoverlikeBlessingCardItem>(this.CreateBlessingItem), null, false, true);
			this.ButtonRefresh = new ButtonItem(base.GetItem(3));
			this.ButtonRefresh.SetFunction(delegate(int _)
			{
				this.OnBtnRefreshClick();
			});
		}

		// Token: 0x060402D5 RID: 262869 RVA: 0x01072747 File Offset: 0x01070947
		protected override void OnBeforeDestroy()
		{
			this.ChooseData = null;
		}

		// Token: 0x060402D6 RID: 262870 RVA: 0x01072750 File Offset: 0x01070950
		protected override void OnBeforeShow()
		{
			Singleton<EventSystem>.Instance.Add<int>(EEventName.OnPlayerCurrencyChange, new Action<int>(this.OnCurrencyChange));
		}

		// Token: 0x060402D7 RID: 262871 RVA: 0x0107276E File Offset: 0x0107096E
		protected override void OnBeforeHide()
		{
			Singleton<EventSystem>.Instance.Remove<int>(EEventName.OnPlayerCurrencyChange, new Action<int>(this.OnCurrencyChange));
		}

		// Token: 0x060402D8 RID: 262872 RVA: 0x0107278C File Offset: 0x0107098C
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
				RoverlikeInstanceData instanceData = ModelBase<RoverlikeModel>.Instance.InstanceData;
				RoverlikeGainEntry roverlikeGainEntry2 = (instanceData != null) ? instanceData.GetSameSlotIdBless(roverlikeGainEntry.ConfigId) : null;
				if (roverlikeGainEntry2 != null)
				{
					this.OpenBlessingReplaceView(roverlikeGainEntry2.ConfigId, roverlikeGainEntry);
					return;
				}
				ControllerBase<RoverlikeController>.Instance.RoverRogueChooseDataResultRequest(this.ChooseData.BindId, roverlikeGainEntry.IncId, null);
			});
		}

		// Token: 0x060402D9 RID: 262873 RVA: 0x010727A1 File Offset: 0x010709A1
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

		// Token: 0x060402DA RID: 262874 RVA: 0x010727B8 File Offset: 0x010709B8
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

		// Token: 0x060402DB RID: 262875 RVA: 0x01072814 File Offset: 0x01070A14
		private void OpenBlessingReplaceView(int curBlessConfigId, RoverlikeGainEntry newEntry)
		{
			RoverlikeBlessingReplaceParam param = new RoverlikeBlessingReplaceParam
			{
				CurBlessId = curBlessConfigId,
				NewBlessId = newEntry.ConfigId,
				Type = ERoverlikeBlessingReplaceType.Replace,
				OnConfirm = delegate
				{
					ControllerBase<RoverlikeController>.Instance.RoverRogueChooseDataResultRequest(this.ChooseData.BindId, newEntry.IncId, null);
				}
			};
			Singleton<UiManager>.Instance.OpenView(EUiViewName.RoverlikeBlessingReplaceView, param, null);
		}

		// Token: 0x060402DC RID: 262876 RVA: 0x0107287D File Offset: 0x01070A7D
		private RoverlikeBlessingCardItem CreateBlessingItem()
		{
			RoverlikeBlessingCardItem roverlikeBlessingCardItem = new RoverlikeBlessingCardItem();
			roverlikeBlessingCardItem.BindOnItemSelect(new Action<IRoverlikeBlessingItemData>(this.OnBlessingItemSelect));
			return roverlikeBlessingCardItem;
		}

		// Token: 0x060402DD RID: 262877 RVA: 0x01072896 File Offset: 0x01070A96
		private void RefreshBlessingLayout(List<IRoverlikeBlessingItemData> dataList)
		{
			this.BlessingCardLayout.RefreshByData(dataList, new Action(this.OnBlessingLayoutRefreshed), true);
		}

		// Token: 0x060402DE RID: 262878 RVA: 0x010728B1 File Offset: 0x01070AB1
		private void OnBlessingLayoutRefreshed()
		{
			Singleton<EventSystem>.Instance.Emit<string>(EEventName.OnGuideTriggerEvent, "RoverlikeSelectBlessing");
			ControllerBase<UiNavigationNewController>.Instance.MarkViewHandleRefreshNavigationDirty();
		}

		// Token: 0x060402DF RID: 262879 RVA: 0x010728D2 File Offset: 0x01070AD2
		private void RefreshBlessingSelection()
		{
			this.BlessingCardLayout.SelectGridProxy(this.SelectedEntryIndex, false);
			this.RefreshButton();
			this.RefreshSlotHighlight();
		}

		// Token: 0x060402E0 RID: 262880 RVA: 0x010728F4 File Offset: 0x01070AF4
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

		// Token: 0x060402E1 RID: 262881 RVA: 0x0107295C File Offset: 0x01070B5C
		private void RefreshRoleInfo()
		{
			if (this.ChooseData == null || this.ChooseData.Entries.Count == 0)
			{
				return;
			}
			RoverlikeGainEntry roverlikeGainEntry = this.ChooseData.Entries[0];
			RoverRogueBless? blessConfig = ConfigBase<RoverlikeConfig>.Instance.GetBlessConfig(roverlikeGainEntry.ConfigId);
			if (blessConfig == null)
			{
				return;
			}
			RoverRogueBlessRole? blessRoleConfig = ConfigBase<RoverlikeConfig>.Instance.GetBlessRoleConfig(blessConfig.Value.BlessRoleId);
			if (blessRoleConfig == null)
			{
				return;
			}
			base.SetTextureShowUntilLoaded(blessRoleConfig.Value.Stand, base.GetTexture(5), null);
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(6), blessRoleConfig.Value.BlessSelectDesc, Array.Empty<object>());
			if (!this.HasPlayedVoice)
			{
				this.HasPlayedVoice = true;
				RoverlikeInstanceData instanceData = ModelBase<RoverlikeModel>.Instance.InstanceData;
				if (instanceData == null)
				{
					return;
				}
				instanceData.PlayBlessRoleVoice(blessConfig.Value.BlessRoleId);
			}
		}

		// Token: 0x060402E2 RID: 262882 RVA: 0x01072A4C File Offset: 0x01070C4C
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

		// Token: 0x060402E3 RID: 262883 RVA: 0x01072B40 File Offset: 0x01070D40
		private void OnCurrencyChange(int itemId)
		{
			int? goldItemId = ModelBase<RoverlikeModel>.Instance.GoldItemId;
			if (!(itemId == goldItemId.GetValueOrDefault() & goldItemId != null))
			{
				return;
			}
			this.RefreshButton();
		}

		// Token: 0x060402E4 RID: 262884 RVA: 0x01072B74 File Offset: 0x01070D74
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
				RoverlikeInstanceData instanceData = ModelBase<RoverlikeModel>.Instance.InstanceData;
				RoverlikeGainEntry roverlikeGainEntry2 = (instanceData != null) ? instanceData.GetSameSlotIdBless(roverlikeGainEntry.ConfigId) : null;
				RoverlikeBlessingItemData item = new RoverlikeBlessingItemData
				{
					BlessId = roverlikeGainEntry.ConfigId,
					IncId = new int?(roverlikeGainEntry.IncId),
					CheckSameSlot = new bool?(true),
					ShowRecommend = new bool?(roverlikeGainEntry2 == null)
				};
				list.Add(item);
			}
			this.RefreshBlessingLayout(list);
			this.RefreshRoleInfo();
			this.RefreshButton();
			this.RefreshSlotHighlight();
		}

		// Token: 0x060402E5 RID: 262885 RVA: 0x01072C94 File Offset: 0x01070E94
		[return: Nullable(new byte[]
		{
			2,
			1
		})]
		public override UUIItem[] GetGuideUiItemAndUiItemForShowEx(string[] configParams)
		{
			int index;
			if (configParams.Length == 0 || !int.TryParse(configParams[0], out index))
			{
				return null;
			}
			GenericLayout<RoverlikeBlessingCardItem, IRoverlikeBlessingItemData> blessingCardLayout = this.BlessingCardLayout;
			UUIItem uuiitem;
			if (blessingCardLayout == null)
			{
				uuiitem = null;
			}
			else
			{
				RoverlikeBlessingCardItem layoutItemByIndex = blessingCardLayout.GetLayoutItemByIndex(index);
				uuiitem = ((layoutItemByIndex != null) ? layoutItemByIndex.GetGuideUiItem() : null);
			}
			UUIItem uuiitem2 = uuiitem;
			if (uuiitem2 == null)
			{
				return null;
			}
			return new UUIItem[]
			{
				uuiitem2,
				uuiitem2
			};
		}

		// Token: 0x04024005 RID: 147461
		[Nullable(new byte[]
		{
			2,
			1,
			1
		})]
		private GenericLayout<RoverlikeBlessingCardItem, IRoverlikeBlessingItemData> BlessingCardLayout;

		// Token: 0x04024006 RID: 147462
		[Nullable(2)]
		private RoverlikeChooseData ChooseData;

		// Token: 0x04024007 RID: 147463
		[Nullable(2)]
		private ButtonItem ButtonRefresh;

		// Token: 0x04024008 RID: 147464
		private int SelectedEntryIndex = -1;

		// Token: 0x04024009 RID: 147465
		private bool HasPlayedVoice;

		// Token: 0x0200C439 RID: 50233
		[NullableContext(0)]
		private class EComponents
		{
			// Token: 0x0403C679 RID: 247417
			public const int BlessingLayout = 0;

			// Token: 0x0403C67A RID: 247418
			public const int ItemBlessing = 1;

			// Token: 0x0403C67B RID: 247419
			public const int BtnConfirm = 2;

			// Token: 0x0403C67C RID: 247420
			public const int BtnRefresh = 3;

			// Token: 0x0403C67D RID: 247421
			public const int TxtRefreshCost = 4;

			// Token: 0x0403C67E RID: 247422
			public const int TexRole = 5;

			// Token: 0x0403C67F RID: 247423
			public const int TxtRoleName = 6;
		}
	}
}
