using System;
using System.Collections.Generic;
using Aki.Config;
using CSharpScript.Game.Ui;
using UnrealEngine;

// Token: 0x0200112F RID: 4399
public class GuessJokerHeroSkillItem : UiPanelBase
{
	// Token: 0x0600732C RID: 29484 RVA: 0x001E1F24 File Offset: 0x001E0124
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUIExtendToggle)),
			new ValueTuple<int, Type>(1, typeof(UUITexture)),
			new ValueTuple<int, Type>(2, typeof(UUITexture)),
			new ValueTuple<int, Type>(3, typeof(UUIItem)),
			new ValueTuple<int, Type>(4, typeof(UUIText)),
			new ValueTuple<int, Type>(5, typeof(UUIItem)),
			new ValueTuple<int, Type>(6, typeof(UUIText)),
			new ValueTuple<int, Type>(7, typeof(UUIText))
		};
		this.BtnBindInfo = new List<ValueTuple<int, Delegate>>
		{
			new ValueTuple<int, Delegate>(0, new Action<EToggleState>(this.OnClickToggle))
		};
	}

	// Token: 0x0600732D RID: 29485 RVA: 0x001E2010 File Offset: 0x001E0210
	protected override void OnStart()
	{
		int sex = ModelBase<WorldLevelModel>.Instance.Sex;
		base.GetTexture(1).SetUIActive(sex == 0);
		base.GetTexture(2).SetUIActive(sex == 1);
		JokerSkill? jokerSkill = ConfigBase<GuessJokerConfig>.Instance.GetJokerSkill(100001);
		if (jokerSkill == null)
		{
			return;
		}
		base.GetText(4).ShowTextNew(jokerSkill.Value.SkillName);
		base.GetText(6).ShowTextNew(jokerSkill.Value.SkillName);
		base.GetText(7).ShowTextNew(jokerSkill.Value.SkillDesc);
		this.RefreshDetail(false);
	}

	// Token: 0x0600732E RID: 29486 RVA: 0x001E20BA File Offset: 0x001E02BA
	public void CloseDetail()
	{
		base.GetExtendToggle(0).SetToggleStateForce(EToggleState.ETT_UnChecked, false, false, false);
		this.RefreshDetail(false);
	}

	// Token: 0x0600732F RID: 29487 RVA: 0x001E20D3 File Offset: 0x001E02D3
	private void RefreshDetail(bool isShowDetail)
	{
		base.GetItem(5).SetUIActive(isShowDetail);
		base.GetItem(3).SetUIActive(!isShowDetail);
	}

	// Token: 0x06007330 RID: 29488 RVA: 0x001E20F2 File Offset: 0x001E02F2
	private void OnClickToggle(EToggleState state)
	{
		if (state == EToggleState.ETT_Checked)
		{
			this.RefreshDetail(true);
			return;
		}
		this.RefreshDetail(false);
	}
}
