using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Aki.Config;
using CSharpScript.Game.Module.HonamiStory;
using CSharpScript.Game.Ui;
using UnrealEngine;

// Token: 0x02001F02 RID: 7938
public class HonamiStoryBackpackValueCountItem : UiPanelBase
{
	// Token: 0x0600ECF6 RID: 60662 RVA: 0x00409660 File Offset: 0x00407860
	protected unsafe override void OnRegisterComponent()
	{
		int num = 8;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int num2 = 0;
		*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIButtonComponent));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(1, typeof(UUITexture));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIExtendToggle));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(5, typeof(UUIExtendToggle));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(6, typeof(UUIExtendToggle));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(7, typeof(UUIItem));
		this.ComponentRegisterInfos = list;
		num2 = 4;
		List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
		CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
		Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
		num = 0;
		*span2[num] = new ValueTuple<int, Delegate>(0, new Action(this.OnClickedCancel));
		num++;
		*span2[num] = new ValueTuple<int, Delegate>(3, new Action<EToggleState>(this.OnClickedToggle));
		num++;
		*span2[num] = new ValueTuple<int, Delegate>(5, new Action<EToggleState>(this.OnClickedTogglePluginA));
		num++;
		*span2[num] = new ValueTuple<int, Delegate>(6, new Action<EToggleState>(this.OnClickedTogglePluginB));
		this.BtnBindInfo = list2;
	}

	// Token: 0x0600ECF7 RID: 60663 RVA: 0x00409838 File Offset: 0x00407A38
	protected override void OnStart()
	{
		this.InDungeon = HonamiStoryUtil.CheckInHonamiStoryDungeon();
		int activityId = ModelBase<HonamiStoryModel>.Instance.ActivityId;
		HonamiStoryActivity value = ConfigBase<HonamiStoryConfig>.Instance.GetHonamiStoryActivityConfig(activityId).Value;
		int itemId = this.InDungeon ? value.InnerItemId : value.OutCoinItemId;
		base.SetItemIcon(base.GetTexture(1), itemId, null, null);
		base.GetItem(7).SetUIActive(!this.InDungeon);
		base.GetButton(0).RootUIComp.Get().SetUIActive(!this.InDungeon);
		string textStringId = this.InDungeon ? "HonamiStory_SellValue_Inner" : "HonamiStory_SellValue_Outer";
		Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(4), textStringId, Array.Empty<object>());
	}

	// Token: 0x0600ECF8 RID: 60664 RVA: 0x00409908 File Offset: 0x00407B08
	public void SetVisible(bool isVisible)
	{
		base.SetUiActive(isVisible);
		if (!this.InDungeon && isVisible)
		{
			base.GetExtendToggle(3).SetToggleState(EToggleState.ETT_UnChecked, false, false, false);
			base.GetExtendToggle(5).SetToggleState(EToggleState.ETT_UnChecked, false, false, false);
			base.GetExtendToggle(6).SetToggleState(EToggleState.ETT_UnChecked, false, false, false);
		}
	}

	// Token: 0x0600ECF9 RID: 60665 RVA: 0x0040995C File Offset: 0x00407B5C
	public void SetValue(int value)
	{
		if (value < 0)
		{
			Singleton<Log>.Instance.Error(ELogModule.HonamiStory, ELogAuthor.WHJ, "Controller value calculate Error", default(ReadOnlySpan<ValueTuple<string, object>>));
		}
		UUIText text = base.GetText(2);
		if (text == null)
		{
			return;
		}
		text.SetText(HonamiStoryUtil.GetPriceNumFormat(value), true);
	}

	// Token: 0x0600ECFA RID: 60666 RVA: 0x004099A4 File Offset: 0x00407BA4
	public void RefreshInGame()
	{
		string newText = HonamiStoryUtil.GetPriceNumFormat(ModelBase<HonamiStoryModel>.Instance.GetBackPackData(2, false).GetTotalValue()) ?? "";
		UUIText text = base.GetText(2);
		if (text == null)
		{
			return;
		}
		text.SetText(newText, true);
	}

	// Token: 0x0600ECFB RID: 60667 RVA: 0x004099E4 File Offset: 0x00407BE4
	private void OnClickedCancel()
	{
		HonamiStoryBackpackLogicController backpackLogic = ModelBase<HonamiStoryModel>.Instance.GetBackpackLogic();
		if (backpackLogic == null)
		{
			return;
		}
		backpackLogic.SetLogicState(EHonamiStoryBackpackLogicState.Normal, null, null);
	}

	// Token: 0x0600ECFC RID: 60668 RVA: 0x00409A10 File Offset: 0x00407C10
	private void OnClickedToggle(EToggleState toggleState)
	{
		bool isSelected = base.GetExtendToggle(3).GetToggleState() == EToggleState.ETT_Checked;
		HonamiStoryBackpackLogicController backpackLogic = ModelBase<HonamiStoryModel>.Instance.GetBackpackLogic();
		if (backpackLogic == null)
		{
			return;
		}
		backpackLogic.DoSellToAll(isSelected, EHonamiStoryItemType.Normal, 0);
	}

	// Token: 0x0600ECFD RID: 60669 RVA: 0x00409A44 File Offset: 0x00407C44
	private void OnClickedTogglePluginA(EToggleState toggleState)
	{
		bool isSelected = base.GetExtendToggle(5).GetToggleState() == EToggleState.ETT_Checked;
		HonamiStoryBackpackLogicController backpackLogic = ModelBase<HonamiStoryModel>.Instance.GetBackpackLogic();
		if (backpackLogic == null)
		{
			return;
		}
		backpackLogic.DoSellToAll(isSelected, EHonamiStoryItemType.Plugin, 1);
	}

	// Token: 0x0600ECFE RID: 60670 RVA: 0x00409A78 File Offset: 0x00407C78
	private void OnClickedTogglePluginB(EToggleState toggleState)
	{
		bool isSelected = base.GetExtendToggle(6).GetToggleState() == EToggleState.ETT_Checked;
		HonamiStoryBackpackLogicController backpackLogic = ModelBase<HonamiStoryModel>.Instance.GetBackpackLogic();
		if (backpackLogic == null)
		{
			return;
		}
		backpackLogic.DoSellToAll(isSelected, EHonamiStoryItemType.Plugin, 2);
	}

	// Token: 0x040071E3 RID: 29155
	private bool InDungeon;

	// Token: 0x0200825A RID: 33370
	private enum EItem
	{
		// Token: 0x0402C36A RID: 181098
		BtnCancel,
		// Token: 0x0402C36B RID: 181099
		Texture,
		// Token: 0x0402C36C RID: 181100
		TxtCost,
		// Token: 0x0402C36D RID: 181101
		Toggle,
		// Token: 0x0402C36E RID: 181102
		TxtTips,
		// Token: 0x0402C36F RID: 181103
		TogglePluginA,
		// Token: 0x0402C370 RID: 181104
		TogglePluginB,
		// Token: 0x0402C371 RID: 181105
		PanelToggle
	}
}
