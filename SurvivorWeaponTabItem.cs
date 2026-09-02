using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Module.Util;
using UnrealEngine;

// Token: 0x02002B3B RID: 11067
[NullableContext(1)]
[Nullable(new byte[]
{
	0,
	1
})]
public class SurvivorWeaponTabItem : GridProxyAbstract<SurvivorsHandbookWeaponData>
{
	// Token: 0x06016142 RID: 90434 RVA: 0x006204A0 File Offset: 0x0061E6A0
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUIExtendToggle)),
			new ValueTuple<int, Type>(1, typeof(UUITexture)),
			new ValueTuple<int, Type>(2, typeof(UUITexture)),
			new ValueTuple<int, Type>(3, typeof(UUIText)),
			new ValueTuple<int, Type>(4, typeof(UUIItem)),
			new ValueTuple<int, Type>(5, typeof(UUIItem))
		};
		this.BtnBindInfo = new List<ValueTuple<int, Delegate>>
		{
			new ValueTuple<int, Delegate>(0, new Action<EToggleState>(this.OnClickToggle))
		};
	}

	// Token: 0x06016143 RID: 90435 RVA: 0x0062055F File Offset: 0x0061E75F
	protected override void OnStart()
	{
		base.GetExtendToggle(0).CanExecuteChange.Bind(new Func<bool>(this.CanToggleExecuteChange));
	}

	// Token: 0x06016144 RID: 90436 RVA: 0x0062057E File Offset: 0x0061E77E
	private bool CanToggleExecuteChange()
	{
		return this.OnCanToggleClicked == null || this.OnCanToggleClicked(this.Data, false, base.GetExtendToggle(0).ToggleState);
	}

	// Token: 0x06016145 RID: 90437 RVA: 0x006205A8 File Offset: 0x0061E7A8
	public override void OnSelected(bool fireEvent)
	{
		if (fireEvent)
		{
			this.OnClickToggle(EToggleState.ETT_Checked);
		}
		base.GetExtendToggle(0).SetToggleStateForce(EToggleState.ETT_Checked, false, false, false);
	}

	// Token: 0x06016146 RID: 90438 RVA: 0x006205C4 File Offset: 0x0061E7C4
	public override void OnDeselected(bool fireEvent)
	{
		base.GetExtendToggle(0).SetToggleStateForce(EToggleState.ETT_UnChecked, false, false, false);
	}

	// Token: 0x06016147 RID: 90439 RVA: 0x006205D6 File Offset: 0x0061E7D6
	private void OnClickToggle(EToggleState state)
	{
		Action<SurvivorsHandbookWeaponData, SurvivorWeaponTabItem> onClickToggleCallBack = this.OnClickToggleCallBack;
		if (onClickToggleCallBack == null)
		{
			return;
		}
		onClickToggleCallBack(this.Data, this);
	}

	// Token: 0x06016148 RID: 90440 RVA: 0x006205F0 File Offset: 0x0061E7F0
	public override void Refresh(SurvivorsHandbookWeaponData data, bool isSelected, int gridIndex)
	{
		this.Data = data;
		SurvivorsWeapon value = ConfigBase<SurvivorsRogueConfig>.Instance.GetSurvivorsWeapon(data.Id).Value;
		if (isSelected)
		{
			this.OnSelected(false);
		}
		else
		{
			this.OnDeselected(false);
		}
		if (data.LockState.GetValueOrDefault())
		{
			UUIText text = base.GetText(3);
			if (text != null)
			{
				text.ShowTextNew("Text_Unknown_Text");
			}
			base.SetTextureByPath(value.Icon, base.GetTexture(2), null, null);
			UUITexture texture = base.GetTexture(2);
			if (texture != null)
			{
				texture.SetUIActive(true);
			}
		}
		else
		{
			UUIText text2 = base.GetText(3);
			if (text2 != null)
			{
				text2.ShowTextNew(value.Name);
			}
			UUITexture texture2 = base.GetTexture(2);
			if (texture2 != null)
			{
				texture2.SetUIActive(false);
			}
		}
		UUIItem item = base.GetItem(5);
		if (item != null)
		{
			item.SetUIActive(data.IsNew.GetValueOrDefault());
		}
		UUIItem item2 = base.GetItem(4);
		if (item2 != null)
		{
			item2.SetUIActive(data.LockState.GetValueOrDefault());
		}
		base.SetTextureByPath(value.Icon, base.GetTexture(1), null, null);
	}

	// Token: 0x06016149 RID: 90441 RVA: 0x00620714 File Offset: 0x0061E914
	public override object GetKey(SurvivorsHandbookWeaponData data, int displayIndex)
	{
		return data.Id;
	}

	// Token: 0x0400AA00 RID: 43520
	[Nullable(new byte[]
	{
		2,
		1
	})]
	public Func<SurvivorsHandbookWeaponData, bool, EToggleState, bool> OnCanToggleClicked;

	// Token: 0x0400AA01 RID: 43521
	[Nullable(new byte[]
	{
		2,
		1,
		1
	})]
	public Action<SurvivorsHandbookWeaponData, SurvivorWeaponTabItem> OnClickToggleCallBack;

	// Token: 0x0400AA02 RID: 43522
	[Nullable(2)]
	private SurvivorsHandbookWeaponData Data;
}
