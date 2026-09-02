using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using Aki.Protocol;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.Roguelike;
using CSharpScript.Game.Module.Util;
using UnrealEngine;

// Token: 0x02002D2B RID: 11563
[NullableContext(1)]
[Nullable(new byte[]
{
	0,
	1
})]
public class WeeklyRogueArtifactItem : GridProxyAbstract<RogueWeeklyEntry>
{
	// Token: 0x0601756F RID: 95599 RVA: 0x006788F8 File Offset: 0x00676AF8
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUIExtendToggle)),
			new ValueTuple<int, Type>(1, typeof(UUITexture)),
			new ValueTuple<int, Type>(2, typeof(UUIText)),
			new ValueTuple<int, Type>(3, typeof(UUIText)),
			new ValueTuple<int, Type>(4, typeof(UUIHorizontalLayout)),
			new ValueTuple<int, Type>(5, typeof(UUIItem)),
			new ValueTuple<int, Type>(6, typeof(UUIItem))
		};
		this.BtnBindInfo = new List<ValueTuple<int, Delegate>>
		{
			new ValueTuple<int, Delegate>(0, new Action<EToggleState>(this.OnClick))
		};
	}

	// Token: 0x06017570 RID: 95600 RVA: 0x006789CD File Offset: 0x00676BCD
	protected override void OnStart()
	{
		this.TagLayout = new GenericLayout<WeeklyRogueTagItem, int>(base.GetHorizontalLayout(4), new Func<WeeklyRogueTagItem>(this.OnCreateTagItem), null, false, true);
	}

	// Token: 0x06017571 RID: 95601 RVA: 0x006789F0 File Offset: 0x00676BF0
	protected override void OnBeforeShow()
	{
		Singleton<EventSystem>.Instance.Add(EEventName.WeeklyRogueDescModeChange, new Action(this.OnDescModeChange));
	}

	// Token: 0x06017572 RID: 95602 RVA: 0x00678A0E File Offset: 0x00676C0E
	protected override void OnBeforeHide()
	{
		Singleton<EventSystem>.Instance.Remove(EEventName.WeeklyRogueDescModeChange, new Action(this.OnDescModeChange));
	}

	// Token: 0x06017573 RID: 95603 RVA: 0x00678A2C File Offset: 0x00676C2C
	public override void Refresh(RogueWeeklyEntry data, bool isSelected, int gridIndex)
	{
		this.Data = data;
		this.UpdateByConfigId(data.ConfigId);
	}

	// Token: 0x06017574 RID: 95604 RVA: 0x00678A44 File Offset: 0x00676C44
	private void OnClick(EToggleState state)
	{
		int? obj = (base.GetExtendToggle(0).GetToggleState() == EToggleState.ETT_Checked) ? new int?(base.GridIndex) : null;
		Action<int?> onSelectedChange = this.OnSelectedChange;
		if (onSelectedChange == null)
		{
			return;
		}
		onSelectedChange(obj);
	}

	// Token: 0x06017575 RID: 95605 RVA: 0x00678A88 File Offset: 0x00676C88
	public override void OnSelected(bool fireEvent)
	{
		base.GetExtendToggle(0).SetToggleState(EToggleState.ETT_Checked, false, false, false);
		ModelBase<WeeklyRogueModel>.Instance.SelectEntry = this.Data;
	}

	// Token: 0x06017576 RID: 95606 RVA: 0x00678AAB File Offset: 0x00676CAB
	public override void OnDeselected(bool fireEvent)
	{
		base.GetExtendToggle(0).SetToggleState(EToggleState.ETT_UnChecked, false, false, false);
		ModelBase<WeeklyRogueModel>.Instance.SelectEntry = null;
	}

	// Token: 0x06017577 RID: 95607 RVA: 0x00678AC9 File Offset: 0x00676CC9
	private void OnDescModeChange()
	{
		if (this.ConfigId == 0)
		{
			return;
		}
		this.RefreshDesc();
	}

	// Token: 0x06017578 RID: 95608 RVA: 0x00678ADC File Offset: 0x00676CDC
	private void RefreshDesc()
	{
		RogueWeeklyBuffPool? rogueWeeklyBuffPool = ConfigBase<WeeklyRogueConfig>.Instance.GetRogueWeeklyBuffPool(this.ConfigId);
		if (rogueWeeklyBuffPool == null)
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.WeeklyRogue;
			ELogAuthor author = ELogAuthor.LPH;
			string message = "刷新周常肉鸽信物格子失败，找不到对应的配置";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("ConfigId", this.ConfigId);
			instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			return;
		}
		if (ModelBase<WeeklyRogueModel>.Instance.DescMode == EDescModel.SIMPLE)
		{
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(3), rogueWeeklyBuffPool.Value.BuffDescSimple, ModelBase<WeeklyRogueModel>.Instance.GetRogueWeeklyBuffDescParam(this.ConfigId));
			return;
		}
		Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(3), rogueWeeklyBuffPool.Value.BuffDesc, ModelBase<WeeklyRogueModel>.Instance.GetRogueWeeklyBuffDescParam(this.ConfigId));
	}

	// Token: 0x06017579 RID: 95609 RVA: 0x00678BA8 File Offset: 0x00676DA8
	public void UpdateByConfigId(int configId)
	{
		this.ConfigId = configId;
		RogueWeeklyBuffPool? rogueWeeklyBuffPool = ConfigBase<WeeklyRogueConfig>.Instance.GetRogueWeeklyBuffPool(configId);
		if (rogueWeeklyBuffPool == null)
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.WeeklyRogue;
			ELogAuthor author = ELogAuthor.LPH;
			string message = "刷新周常肉鸽信物格子失败，找不到对应的配置";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("ConfigId", configId);
			instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			return;
		}
		UUIItem item = base.GetItem(6);
		RogueWeeklyEntry data = this.Data;
		bool? flag;
		if (data == null)
		{
			flag = null;
		}
		else
		{
			RogueWeeklyBuff rogueWeeklyBuff = data.RogueWeeklyBuff;
			flag = ((rogueWeeklyBuff != null) ? new bool?(rogueWeeklyBuff.IsNew) : null);
		}
		bool? flag2 = flag;
		item.SetUIActive(flag2.GetValueOrDefault());
		Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(2), rogueWeeklyBuffPool.Value.BuffName, Array.Empty<object>());
		this.RefreshDesc();
		base.SetTextureByPath(rogueWeeklyBuffPool.Value.BuffIcon, base.GetTexture(1), null, null);
		this.TagLayout.RefreshByData(ModelBase<WeeklyRogueModel>.Instance.GetRogueWeeklyBuffTagIdList(configId), null, false);
	}

	// Token: 0x0601757A RID: 95610 RVA: 0x00678CB2 File Offset: 0x00676EB2
	public void SetInteractive(bool bActive)
	{
		base.GetExtendToggle(0).SetSelfInteractive(bActive);
	}

	// Token: 0x0601757B RID: 95611 RVA: 0x00678CC1 File Offset: 0x00676EC1
	private WeeklyRogueTagItem OnCreateTagItem()
	{
		return new WeeklyRogueTagItem();
	}

	// Token: 0x0400B343 RID: 45891
	[Nullable(new byte[]
	{
		2,
		1
	})]
	private GenericLayout<WeeklyRogueTagItem, int> TagLayout;

	// Token: 0x0400B344 RID: 45892
	private RogueWeeklyEntry Data;

	// Token: 0x0400B345 RID: 45893
	private int ConfigId;

	// Token: 0x0400B346 RID: 45894
	[Nullable(2)]
	public Action<int?> OnSelectedChange;

	// Token: 0x02008FEE RID: 36846
	[NullableContext(0)]
	private enum EComponents
	{
		// Token: 0x040304B8 RID: 197816
		ToggleItem,
		// Token: 0x040304B9 RID: 197817
		TexIcon,
		// Token: 0x040304BA RID: 197818
		TxtName,
		// Token: 0x040304BB RID: 197819
		TxtDesc,
		// Token: 0x040304BC RID: 197820
		TagLayout,
		// Token: 0x040304BD RID: 197821
		TagItem,
		// Token: 0x040304BE RID: 197822
		NewItem
	}
}
