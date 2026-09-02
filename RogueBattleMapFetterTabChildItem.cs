using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using Aki.Protocol;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.RogueBattle;
using CSharpScript.Game.Module.Util;
using UnrealEngine;

// Token: 0x02002778 RID: 10104
public class RogueBattleMapFetterTabChildItem : GridProxyAbstract<int>
{
	// Token: 0x06013EDB RID: 81627 RVA: 0x0058DE64 File Offset: 0x0058C064
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUIExtendToggle)),
			new ValueTuple<int, Type>(1, typeof(UUIText)),
			new ValueTuple<int, Type>(2, typeof(UUIText))
		};
		this.BtnBindInfo = new List<ValueTuple<int, Delegate>>
		{
			new ValueTuple<int, Delegate>(0, new Action<EToggleState>(this.OnClickToggle))
		};
	}

	// Token: 0x06013EDC RID: 81628 RVA: 0x0058DEE1 File Offset: 0x0058C0E1
	protected override void OnStart()
	{
		base.GetExtendToggle(0).CanExecuteChange.Bind(new Func<bool>(this.CanExecuteChange));
	}

	// Token: 0x06013EDD RID: 81629 RVA: 0x0058DF00 File Offset: 0x0058C100
	public void SetSelected(bool isSelected)
	{
		EToggleState state = isSelected ? EToggleState.ETT_Checked : EToggleState.ETT_UnChecked;
		base.GetExtendToggle(0).SetToggleState(state, false, false, false);
	}

	// Token: 0x06013EDE RID: 81630 RVA: 0x0058DF26 File Offset: 0x0058C126
	private bool CanExecuteChange()
	{
		return this.CanExecuteChangeFunction == null || this.CanExecuteChangeFunction(this.BondId, base.GetExtendToggle(0).GetToggleState());
	}

	// Token: 0x06013EDF RID: 81631 RVA: 0x0058DF50 File Offset: 0x0058C150
	public override void Refresh(int data, bool isSelected, int gridIndex)
	{
		this.BondId = data;
		this.SetSelected(this.BondId == ModelBase<RogueBattleModel>.Instance.CurrentMapSummaryBond);
		RogueResBond? rogueResBond = ConfigBase<RogueBattleConfig>.Instance.GetRogueResBond(this.BondId);
		RoleBondInfo roleBondDataById = ModelBase<RogueBattleModel>.Instance.GetRoleBondDataById(this.BondId);
		FColor color = FColor.FromHex(ConfigBase<RogueBattleConfig>.Instance.GetBondLvConfigByLv(roleBondDataById.Level).Value.LvColor);
		UUIText text = base.GetText(1);
		UUIText text2 = base.GetText(2);
		text.SetColor(color);
		Singleton<LguiUtil>.Instance.SetLocalTextNew(text, rogueResBond.Value.Name, Array.Empty<object>());
		if (roleBondDataById != null && roleBondDataById.Level > 0)
		{
			text2.SetColor(color);
			Singleton<LguiUtil>.Instance.SetLocalTextNew(text2, "RogueResSynergyLV", new <>z__ReadOnlySingleElementList<object>(roleBondDataById.Level));
			base.GetText(2).SetUIActive(true);
			return;
		}
		base.GetText(2).SetUIActive(false);
	}

	// Token: 0x06013EE0 RID: 81632 RVA: 0x0058E050 File Offset: 0x0058C250
	private void OnClickToggle(EToggleState state)
	{
		ModelBase<RogueBattleModel>.Instance.CurrentMapSummaryBond = this.BondId;
		Singleton<EventSystem>.Instance.Emit<int>(EEventName.RogueResMapSummaryBondUpdate, this.BondId);
	}

	// Token: 0x04009B21 RID: 39713
	private int BondId;

	// Token: 0x04009B22 RID: 39714
	[Nullable(2)]
	public Func<int, EToggleState, bool> CanExecuteChangeFunction;
}
