using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Ui;
using UnrealEngine;

// Token: 0x02001E3D RID: 7741
[NullableContext(2)]
[Nullable(0)]
public class HandBookChipDesItem : UiPanelBase
{
	// Token: 0x0600E51E RID: 58654 RVA: 0x003DDEE4 File Offset: 0x003DC0E4
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(1, typeof(UUIItem)),
			new ValueTuple<int, Type>(3, typeof(UUIText)),
			new ValueTuple<int, Type>(2, typeof(UUIText)),
			new ValueTuple<int, Type>(4, typeof(UUIItem)),
			new ValueTuple<int, Type>(5, typeof(UUIItem)),
			new ValueTuple<int, Type>(0, typeof(UUIExtendToggle))
		};
		this.BtnBindInfo = new List<ValueTuple<int, Delegate>>
		{
			new ValueTuple<int, Delegate>(0, new Action<EToggleState>(this.OnToggleClicked))
		};
	}

	// Token: 0x0600E51F RID: 58655 RVA: 0x003DDFA3 File Offset: 0x003DC1A3
	protected override void OnStart()
	{
		this.Toggle = base.GetExtendToggle(0);
	}

	// Token: 0x0600E520 RID: 58656 RVA: 0x003DDFB2 File Offset: 0x003DC1B2
	private void OnToggleClicked(EToggleState state)
	{
		if (this.OnChildToggleCallback != null && state == EToggleState.ETT_Checked)
		{
			this.OnChildToggleCallback(this.ChipConfig.Value, this.Toggle);
		}
	}

	// Token: 0x0600E521 RID: 58657 RVA: 0x003DDFDC File Offset: 0x003DC1DC
	public void Refresh(int data, bool isSelect)
	{
		ChipHandBook? chipHandBookConfig = ConfigBase<HandBookConfig>.Instance.GetChipHandBookConfig(data);
		this.ChipConfig = chipHandBookConfig;
		HandBookEntry handBookInfo = ModelBase<HandBookModel>.Instance.GetHandBookInfo(EHandBookTabType.Chip, chipHandBookConfig.Value.Id);
		bool isLock = handBookInfo == null;
		this.IsLock = isLock;
		base.GetItem(1).SetUIActive(this.IsLock);
		base.GetText(2).SetUIActive(!this.IsLock);
		string infoDisplayTitle = ConfigBase<InfoDisplayModuleConfig>.Instance.GetInfoDisplayTitle(chipHandBookConfig.Value.Id);
		base.GetText(2).SetText(infoDisplayTitle, true);
		base.GetText(3).SetText(ConfigMultiTextLang.GetLocalTextNew("Text_Unknown_Text", null), true);
		UUIItem item = base.GetItem(4);
		UUIItem item2 = base.GetItem(5);
		bool uiactive = handBookInfo != null && !handBookInfo.IsRead;
		item2.SetUIActive(this.IsLock);
		if (this.IsLock)
		{
			item.SetUIActive(false);
		}
		else
		{
			item.SetUIActive(uiactive);
		}
		if (isSelect)
		{
			UUIExtendToggle toggle = this.Toggle;
			if (toggle == null)
			{
				return;
			}
			toggle.SetToggleState(EToggleState.ETT_Checked, true, false, false);
		}
	}

	// Token: 0x0600E522 RID: 58658 RVA: 0x003DE0EB File Offset: 0x003DC2EB
	[NullableContext(1)]
	public void BindChildToggleCallback(TChildChipToggleFunction toggleFunction)
	{
		this.OnChildToggleCallback = toggleFunction;
	}

	// Token: 0x0600E523 RID: 58659 RVA: 0x003DE0F4 File Offset: 0x003DC2F4
	public void RefreshNewState()
	{
		if (this.ChipConfig == null)
		{
			return;
		}
		HandBookEntry handBookInfo = ModelBase<HandBookModel>.Instance.GetHandBookInfo(EHandBookTabType.Chip, this.ChipConfig.Value.Id);
		bool uiactive = handBookInfo != null && !handBookInfo.IsRead;
		base.GetItem(4).SetUIActive(uiactive);
	}

	// Token: 0x04006E2B RID: 28203
	private TChildChipToggleFunction OnChildToggleCallback;

	// Token: 0x04006E2C RID: 28204
	private ChipHandBook? ChipConfig;

	// Token: 0x04006E2D RID: 28205
	private bool IsLock;

	// Token: 0x04006E2E RID: 28206
	private UUIExtendToggle Toggle;
}
