using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Ui;
using UnrealEngine;

// Token: 0x02001EA4 RID: 7844
[NullableContext(2)]
[Nullable(0)]
internal class HandBookNounDesItem : UiPanelBase
{
	// Token: 0x0600E7D7 RID: 59351 RVA: 0x003EA268 File Offset: 0x003E8468
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

	// Token: 0x0600E7D8 RID: 59352 RVA: 0x003EA327 File Offset: 0x003E8527
	protected override void OnStart()
	{
		this.Toggle = base.GetExtendToggle(0);
	}

	// Token: 0x0600E7D9 RID: 59353 RVA: 0x003EA336 File Offset: 0x003E8536
	private void OnToggleClicked(EToggleState state)
	{
		if (this.OnChildToggleCallback != null && state == EToggleState.ETT_Checked)
		{
			this.OnChildToggleCallback(this.NounConfig.Value, this.Toggle);
		}
	}

	// Token: 0x0600E7DA RID: 59354 RVA: 0x003EA360 File Offset: 0x003E8560
	public void Refresh(int data, bool isSelect)
	{
		NounHandBook? nounHandBookConfig = ConfigBase<HandBookConfig>.Instance.GetNounHandBookConfig(data);
		this.NounConfig = nounHandBookConfig;
		HandBookEntry handBookInfo = ModelBase<HandBookModel>.Instance.GetHandBookInfo(EHandBookTabType.Noun, nounHandBookConfig.Value.Id);
		bool isLock = handBookInfo == null;
		this.IsLock = isLock;
		base.GetItem(1).SetUIActive(this.IsLock);
		base.GetText(2).SetUIActive(!this.IsLock);
		string infoDisplayTitle = ConfigBase<InfoDisplayModuleConfig>.Instance.GetInfoDisplayTitle(nounHandBookConfig.Value.Id);
		base.GetText(2).SetText(infoDisplayTitle, true);
		string newText = ConfigMultiTextLang.GetLocalTextNew("Text_Unknown_Text", null) ?? "";
		base.GetText(3).SetText(newText, true);
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
			toggle.SetToggleStateForce(EToggleState.ETT_Checked, true, true, false);
			return;
		}
		else
		{
			UUIExtendToggle toggle2 = this.Toggle;
			if (toggle2 == null)
			{
				return;
			}
			toggle2.SetToggleStateForce(EToggleState.ETT_UnChecked, true, true, false);
			return;
		}
	}

	// Token: 0x0600E7DB RID: 59355 RVA: 0x003EA491 File Offset: 0x003E8691
	[NullableContext(1)]
	public void BindChildToggleCallback(TChildNounToggleFunction toggleFunction)
	{
		this.OnChildToggleCallback = toggleFunction;
	}

	// Token: 0x0600E7DC RID: 59356 RVA: 0x003EA49C File Offset: 0x003E869C
	public void RefreshNewState()
	{
		if (this.NounConfig == null)
		{
			return;
		}
		HandBookEntry handBookInfo = ModelBase<HandBookModel>.Instance.GetHandBookInfo(EHandBookTabType.Noun, this.NounConfig.Value.Id);
		bool uiactive = handBookInfo != null && !handBookInfo.IsRead;
		base.GetItem(4).SetUIActive(uiactive);
	}

	// Token: 0x04006FCA RID: 28618
	private TChildNounToggleFunction OnChildToggleCallback;

	// Token: 0x04006FCB RID: 28619
	private NounHandBook? NounConfig;

	// Token: 0x04006FCC RID: 28620
	private bool IsLock;

	// Token: 0x04006FCD RID: 28621
	private UUIExtendToggle Toggle;
}
