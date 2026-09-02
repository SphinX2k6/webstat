using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Ui;
using UnrealEngine;

// Token: 0x02001B56 RID: 6998
public class ExitSkillView : UiViewBase
{
	// Token: 0x0600CA76 RID: 51830 RVA: 0x0035E0EA File Offset: 0x0035C2EA
	[NullableContext(1)]
	public ExitSkillView(UiViewInfo viewInfo) : base(viewInfo)
	{
	}

	// Token: 0x0600CA77 RID: 51831 RVA: 0x0035E0F4 File Offset: 0x0035C2F4
	protected unsafe override void OnRegisterComponent()
	{
		int num = 8;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int num2 = 0;
		*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(5, typeof(UUIButtonComponent));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(6, typeof(UUIButtonComponent));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(7, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(8, typeof(UUIExtendToggle));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(9, typeof(UUIItem));
		this.ComponentRegisterInfos = list;
		num2 = 3;
		List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
		CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
		Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
		num = 0;
		*span2[num] = new ValueTuple<int, Delegate>(5, new Action(this.OnClickClose));
		num++;
		*span2[num] = new ValueTuple<int, Delegate>(6, new Action(this.OnClickClose));
		num++;
		*span2[num] = new ValueTuple<int, Delegate>(8, new Action<EToggleState>(this.OnlineModelToggleClick));
		this.BtnBindInfo = list2;
	}

	// Token: 0x0600CA78 RID: 51832 RVA: 0x0035E2A7 File Offset: 0x0035C4A7
	protected override void OnBeforeDestroy()
	{
		this.Data = null;
		List<ExitSkillItem> skillItems = this.SkillItems;
		if (skillItems != null)
		{
			skillItems.Clear();
		}
		this.SkillItems = null;
	}

	// Token: 0x0600CA79 RID: 51833 RVA: 0x0035E2C8 File Offset: 0x0035C4C8
	protected override void OnAddEventListener()
	{
		Singleton<EventSystem>.Instance.Add<ERefreshEditBattleRoleSlotDataReason>(EEventName.OnRefreshEditBattleRoleSlotData, new Action<ERefreshEditBattleRoleSlotDataReason>(this.OnRefreshEditBattleRoleSlotData));
	}

	// Token: 0x0600CA7A RID: 51834 RVA: 0x0035E2E6 File Offset: 0x0035C4E6
	protected override void OnRemoveEventListener()
	{
		Singleton<EventSystem>.Instance.Remove(EEventName.OnRefreshEditBattleRoleSlotData, new Action<ERefreshEditBattleRoleSlotDataReason>(this.OnRefreshEditBattleRoleSlotData));
	}

	// Token: 0x0600CA7B RID: 51835 RVA: 0x0035E304 File Offset: 0x0035C504
	protected override void OnStart()
	{
		this.Data = (this.OpenParam as ExitSkillViewData);
		this.SkillItems = new List<ExitSkillItem>();
		UUIItem[] array = new UUIItem[]
		{
			base.GetItem(2),
			base.GetItem(3),
			base.GetItem(4)
		};
		bool isMulti = ModelBase<GameModeModel>.Instance.IsMulti;
		base.GetItem(9).SetUIActive(isMulti);
		this.ShowMultiSkillDesc = (ModelBase<RoleModel>.Instance.IsShowMultiSkillDesc && isMulti);
		EToggleState state = this.ShowMultiSkillDesc ? EToggleState.ETT_Checked : EToggleState.ETT_UnChecked;
		base.GetExtendToggle(8).SetToggleState(state, false, false, false);
		this.RefreshTipsText(this.ShowMultiSkillDesc);
		ExitSkillViewData data = this.Data;
		List<ExitSkillItemData> list = (data != null) ? data.GetItems() : null;
		for (int i = 0; i < array.Length; i++)
		{
			UUIItem uuiitem = array[i];
			if (uuiitem != null)
			{
				ExitSkillItem exitSkillItem = new ExitSkillItem(uuiitem);
				this.SkillItems.Add(exitSkillItem);
				if (list != null && i < list.Count)
				{
					exitSkillItem.Refresh(list[i], this.ShowMultiSkillDesc);
				}
				else
				{
					exitSkillItem.Refresh(null, false);
				}
			}
		}
	}

	// Token: 0x0600CA7C RID: 51836 RVA: 0x0035E41C File Offset: 0x0035C61C
	private void RefreshTipsText(bool isMulti)
	{
		string textStringId = "Text_EditFormationSkill_Text";
		if (isMulti)
		{
			textStringId = "Text_EditFormationSkill_online_Text";
		}
		UUIText text = base.GetText(7);
		Singleton<LguiUtil>.Instance.SetLocalTextNew(text, textStringId, Array.Empty<object>());
	}

	// Token: 0x0600CA7D RID: 51837 RVA: 0x0035E451 File Offset: 0x0035C651
	private void OnClickClose()
	{
		Singleton<UiManager>.Instance.CloseView(EUiViewName.ExitSkillView, null);
	}

	// Token: 0x0600CA7E RID: 51838 RVA: 0x0035E464 File Offset: 0x0035C664
	private void OnlineModelToggleClick(EToggleState toggleState)
	{
		ModelBase<RoleModel>.Instance.IsShowMultiSkillDesc = (toggleState == EToggleState.ETT_Checked);
		this.ShowMultiSkillDesc = (toggleState == EToggleState.ETT_Checked);
		this.RefreshTipsText(this.ShowMultiSkillDesc);
		ExitSkillViewData data = this.Data;
		List<ExitSkillItemData> list = (data != null) ? data.GetItems() : null;
		if (list == null)
		{
			return;
		}
		if (this.SkillItems == null)
		{
			return;
		}
		for (int i = 0; i < this.SkillItems.Count; i++)
		{
			ExitSkillItem exitSkillItem = this.SkillItems[i];
			if (i < list.Count)
			{
				exitSkillItem.Refresh(list[i], this.ShowMultiSkillDesc);
			}
			else
			{
				exitSkillItem.Refresh(null, this.ShowMultiSkillDesc);
			}
		}
	}

	// Token: 0x0600CA7F RID: 51839 RVA: 0x0035E504 File Offset: 0x0035C704
	private void OnRefreshEditBattleRoleSlotData(ERefreshEditBattleRoleSlotDataReason reason)
	{
		if (this.SkillItems == null)
		{
			return;
		}
		EditBattleRoleSlotData[] getAllRoleSlotData = ModelBase<EditBattleTeamModel>.Instance.GetAllRoleSlotData;
		for (int i = 0; i < this.SkillItems.Count; i++)
		{
			ExitSkillItem exitSkillItem = this.SkillItems[i];
			EditBattleRoleSlotData editBattleRoleSlotData = getAllRoleSlotData[i];
			EditBattleRoleData editBattleRoleData = (editBattleRoleSlotData != null) ? editBattleRoleSlotData.GetRoleData : null;
			if (editBattleRoleSlotData == null || editBattleRoleData == null)
			{
				exitSkillItem.Refresh(null, false);
			}
			else
			{
				ExitSkillItemData data = new ExitSkillItemData
				{
					RoleId = new int?(editBattleRoleData.ConfigId),
					OnlineIndex = editBattleRoleData.OnlineIndex,
					PlayerId = new int?(editBattleRoleData.PlayerId)
				};
				exitSkillItem.Refresh(data, this.ShowMultiSkillDesc);
			}
		}
	}

	// Token: 0x040060DC RID: 24796
	[Nullable(2)]
	private ExitSkillViewData Data;

	// Token: 0x040060DD RID: 24797
	[Nullable(new byte[]
	{
		2,
		1
	})]
	private List<ExitSkillItem> SkillItems;

	// Token: 0x040060DE RID: 24798
	private bool ShowMultiSkillDesc;

	// Token: 0x02007E3B RID: 32315
	private enum EChildType
	{
		// Token: 0x0402AFF3 RID: 176115
		SlotContent,
		// Token: 0x0402AFF4 RID: 176116
		TabComponent,
		// Token: 0x0402AFF5 RID: 176117
		RoleSkillSlot1,
		// Token: 0x0402AFF6 RID: 176118
		RoleSkillSlot2,
		// Token: 0x0402AFF7 RID: 176119
		RoleSkillSlot3,
		// Token: 0x0402AFF8 RID: 176120
		CloseButton,
		// Token: 0x0402AFF9 RID: 176121
		BgButton,
		// Token: 0x0402AFFA RID: 176122
		TipsText,
		// Token: 0x0402AFFB RID: 176123
		OnlineModeToggle,
		// Token: 0x0402AFFC RID: 176124
		OnlineModeItem
	}
}
