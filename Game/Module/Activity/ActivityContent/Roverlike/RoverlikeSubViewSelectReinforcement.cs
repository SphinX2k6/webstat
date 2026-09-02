using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.Util;
using UnrealEngine;

namespace CSharpScript.Game.Module.Activity.ActivityContent.Roverlike
{
	// Token: 0x020063D7 RID: 25559
	[NullableContext(1)]
	[Nullable(0)]
	public class RoverlikeSubViewSelectReinforcement : RoverlikeActionSubViewBase
	{
		// Token: 0x17009DBC RID: 40380
		// (get) Token: 0x060402EA RID: 262890 RVA: 0x01072DD2 File Offset: 0x01070FD2
		public override ERoverActionSubViewType SubViewType
		{
			get
			{
				return ERoverActionSubViewType.SelectReinforcement;
			}
		}

		// Token: 0x17009DBD RID: 40381
		// (get) Token: 0x060402EB RID: 262891 RVA: 0x01072DD5 File Offset: 0x01070FD5
		public override string ResourceId
		{
			get
			{
				return "UiItem_RoverlikeRoleBuffSelect";
			}
		}

		// Token: 0x060402EC RID: 262892 RVA: 0x01072DDC File Offset: 0x01070FDC
		protected unsafe override void OnRegisterComponent()
		{
			int num = 6;
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
			this.ComponentRegisterInfos = list;
			num2 = 1;
			List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
			CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
			Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
			num = 0;
			*span2[num] = new ValueTuple<int, Delegate>(2, new Action(this.OnConfirmClick));
			this.BtnBindInfo = list2;
		}

		// Token: 0x060402ED RID: 262893 RVA: 0x01072F08 File Offset: 0x01071108
		protected override void OnStart()
		{
			this.ReinforcementLayout = new GenericLayout<RoverlikeReinforcementCardItem, IRoverlikeReinforcementItemData>(base.GetHorizontalLayout(0), new Func<RoverlikeReinforcementCardItem>(this.CreateReinforcementItem), null, false, true);
			this.RefreshBtn = new ButtonItem(base.GetItem(3));
			this.RefreshBtn.SetFunction(delegate(int _)
			{
				this.OnRefreshClick();
			});
		}

		// Token: 0x060402EE RID: 262894 RVA: 0x01072F5F File Offset: 0x0107115F
		protected override void OnBeforeDestroy()
		{
			this.ChooseData = null;
		}

		// Token: 0x060402EF RID: 262895 RVA: 0x01072F68 File Offset: 0x01071168
		protected override void OnBeforeShow()
		{
			Singleton<EventSystem>.Instance.Add<int>(EEventName.OnPlayerCurrencyChange, new Action<int>(this.OnCurrencyChange));
		}

		// Token: 0x060402F0 RID: 262896 RVA: 0x01072F86 File Offset: 0x01071186
		protected override void OnBeforeHide()
		{
			Singleton<EventSystem>.Instance.Remove<int>(EEventName.OnPlayerCurrencyChange, new Action<int>(this.OnCurrencyChange));
		}

		// Token: 0x060402F1 RID: 262897 RVA: 0x01072FA4 File Offset: 0x010711A4
		private void OnConfirmClick()
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
				ControllerBase<RoverlikeController>.Instance.RoverRogueChooseDataResultRequest(this.ChooseData.BindId, roverlikeGainEntry.IncId, null);
			});
		}

		// Token: 0x060402F2 RID: 262898 RVA: 0x01072FB9 File Offset: 0x010711B9
		private void OnRefreshClick()
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

		// Token: 0x060402F3 RID: 262899 RVA: 0x01072FD0 File Offset: 0x010711D0
		private void OnReinforcementItemSelect(IRoverlikeReinforcementItemData data)
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
			this.RefreshReinforcementSelection();
		}

		// Token: 0x060402F4 RID: 262900 RVA: 0x0107302B File Offset: 0x0107122B
		private RoverlikeReinforcementCardItem CreateReinforcementItem()
		{
			RoverlikeReinforcementCardItem roverlikeReinforcementCardItem = new RoverlikeReinforcementCardItem();
			roverlikeReinforcementCardItem.BindOnItemSelect(new Action<IRoverlikeReinforcementItemData>(this.OnReinforcementItemSelect));
			return roverlikeReinforcementCardItem;
		}

		// Token: 0x060402F5 RID: 262901 RVA: 0x01073044 File Offset: 0x01071244
		private void RefreshReinforcementLayout()
		{
			if (this.ChooseData == null)
			{
				return;
			}
			List<IRoverlikeReinforcementItemData> list = new List<IRoverlikeReinforcementItemData>();
			foreach (RoverlikeGainEntry roverlikeGainEntry in this.ChooseData.Entries)
			{
				RoverlikeReinforcementItemData item = new RoverlikeReinforcementItemData
				{
					ConfigId = roverlikeGainEntry.ConfigId,
					IncId = new int?(roverlikeGainEntry.IncId)
				};
				list.Add(item);
			}
			this.ReinforcementLayout.RefreshByData(list, new Action(this.OnReinforcementLayoutRefreshed), true);
		}

		// Token: 0x060402F6 RID: 262902 RVA: 0x010730E8 File Offset: 0x010712E8
		private void OnReinforcementLayoutRefreshed()
		{
			Singleton<EventSystem>.Instance.Emit<string>(EEventName.OnGuideTriggerEvent, "RoverlikeSelectReinforcement");
			ControllerBase<UiNavigationNewController>.Instance.MarkViewHandleRefreshNavigationDirty();
		}

		// Token: 0x060402F7 RID: 262903 RVA: 0x01073109 File Offset: 0x01071309
		private void RefreshReinforcementSelection()
		{
			this.ReinforcementLayout.SelectGridProxy(this.SelectedEntryIndex, false);
			this.RefreshButton();
		}

		// Token: 0x060402F8 RID: 262904 RVA: 0x01073124 File Offset: 0x01071324
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
			ButtonItem refreshBtn = this.RefreshBtn;
			if (refreshBtn != null)
			{
				refreshBtn.SetEnableClick(this.ChooseData.HasRefreshTime());
			}
			ButtonItem refreshBtn2 = this.RefreshBtn;
			if (refreshBtn2 != null)
			{
				refreshBtn2.SetLocalTextNew("RoverRogue_RefreshCount", new object[]
				{
					this.ChooseData.UseTime,
					this.ChooseData.MaxTime
				});
			}
			Singleton<LguiUtil>.Instance.SetLocalTextNew(text, "RoverRogue_RefreshCost", new <>z__ReadOnlySingleElementList<object>(this.ChooseData.RefreshCost));
			UUIItem uuiitem = text;
			bool bUseChangeColor = !this.ChooseData.HasRefreshCost();
			FColor? fcolor = new FColor?(text.changeColor);
			uuiitem.SetChangeColor(bUseChangeColor, fcolor);
		}

		// Token: 0x060402F9 RID: 262905 RVA: 0x01073214 File Offset: 0x01071414
		private void RefreshRoleInfo()
		{
			int mainRoleId = ModelBase<RoverlikeModel>.Instance.GetMainRoleId();
			RoleDataBase roleDataById = ModelBase<RoleModel>.Instance.GetRoleDataById(mainRoleId, true);
			RoleInfo? roleInfo = (roleDataById != null) ? new RoleInfo?(roleDataById.GetRoleConfig()) : null;
			if (roleInfo == null)
			{
				return;
			}
			base.SetTextureShowUntilLoaded(roleInfo.Value.FormationRoleCard, base.GetTexture(5), null);
		}

		// Token: 0x060402FA RID: 262906 RVA: 0x0107327C File Offset: 0x0107147C
		private void OnCurrencyChange(int itemId)
		{
			int? goldItemId = ModelBase<RoverlikeModel>.Instance.GoldItemId;
			if (!(itemId == goldItemId.GetValueOrDefault() & goldItemId != null))
			{
				return;
			}
			this.RefreshButton();
		}

		// Token: 0x060402FB RID: 262907 RVA: 0x010732B0 File Offset: 0x010714B0
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
			this.RefreshReinforcementLayout();
			this.RefreshRoleInfo();
			this.RefreshButton();
		}

		// Token: 0x060402FC RID: 262908 RVA: 0x01073314 File Offset: 0x01071514
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
			GenericLayout<RoverlikeReinforcementCardItem, IRoverlikeReinforcementItemData> reinforcementLayout = this.ReinforcementLayout;
			UUIItem uuiitem;
			if (reinforcementLayout == null)
			{
				uuiitem = null;
			}
			else
			{
				RoverlikeReinforcementCardItem layoutItemByIndex = reinforcementLayout.GetLayoutItemByIndex(index);
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

		// Token: 0x0402400A RID: 147466
		[Nullable(new byte[]
		{
			2,
			1,
			1
		})]
		private GenericLayout<RoverlikeReinforcementCardItem, IRoverlikeReinforcementItemData> ReinforcementLayout;

		// Token: 0x0402400B RID: 147467
		[Nullable(2)]
		private ButtonItem RefreshBtn;

		// Token: 0x0402400C RID: 147468
		[Nullable(2)]
		private RoverlikeChooseData ChooseData;

		// Token: 0x0402400D RID: 147469
		private int SelectedEntryIndex = -1;

		// Token: 0x0200C43C RID: 50236
		[NullableContext(0)]
		private class EComponents
		{
			// Token: 0x0403C683 RID: 247427
			public const int ReinforcementLayout = 0;

			// Token: 0x0403C684 RID: 247428
			public const int ItemReinforcement = 1;

			// Token: 0x0403C685 RID: 247429
			public const int BtnConfirm = 2;

			// Token: 0x0403C686 RID: 247430
			public const int BtnRefresh = 3;

			// Token: 0x0403C687 RID: 247431
			public const int TxtRefreshCost = 4;

			// Token: 0x0403C688 RID: 247432
			public const int TexRole = 5;
		}
	}
}
