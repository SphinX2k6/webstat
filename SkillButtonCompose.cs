using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Ui;
using UnrealEngine;

// Token: 0x020028E7 RID: 10471
public class SkillButtonCompose : UiPanelBase
{
	// Token: 0x06014CB5 RID: 85173 RVA: 0x005C2734 File Offset: 0x005C0934
	[NullableContext(1)]
	public SkillButtonCompose(UUIItem uiItem, Action onFunction)
	{
		this.ClickFunction = onFunction;
		base.CreateThenShowByActor(uiItem.GetOwner(), null);
	}

	// Token: 0x06014CB6 RID: 85174 RVA: 0x005C2750 File Offset: 0x005C0950
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(1, typeof(UUIButtonComponent)),
			new ValueTuple<int, Type>(0, typeof(UUITexture))
		};
		this.BtnBindInfo = new List<ValueTuple<int, Delegate>>
		{
			new ValueTuple<int, Delegate>(1, new Action(this.OnClick))
		};
	}

	// Token: 0x06014CB7 RID: 85175 RVA: 0x005C27B7 File Offset: 0x005C09B7
	public void Update(int id)
	{
		this.Id = id;
		if (this.Id == 0 || !ControllerBase<PhantomBattleController>.Instance.CheckIsMain(this.Id))
		{
			this.SetActive(false);
			return;
		}
		this.SetActive(true);
		this.RefreshTexture();
	}

	// Token: 0x06014CB8 RID: 85176 RVA: 0x005C27F0 File Offset: 0x005C09F0
	public void RefreshTexture()
	{
		PhantomBattleData phantomItemDataByUniqueId = ControllerBase<PhantomBattleController>.Instance.GetPhantomItemDataByUniqueId(this.Id);
		if (phantomItemDataByUniqueId == null)
		{
			return;
		}
		PhantomBattleInstance phantomInstanceByItemId = ModelBase<PhantomBattleModel>.Instance.GetPhantomInstanceByItemId(phantomItemDataByUniqueId.GetConfigId(false));
		if (phantomInstanceByItemId == null)
		{
			return;
		}
		PhantomSkill? phantomSkillInfoByLevel = phantomInstanceByItemId.GetPhantomSkillInfoByLevel();
		if (phantomSkillInfoByLevel == null)
		{
			return;
		}
		base.SetTextureByPath(phantomSkillInfoByLevel.Value.BattleViewIcon, base.GetTexture(0), null, null);
	}

	// Token: 0x06014CB9 RID: 85177 RVA: 0x005C2860 File Offset: 0x005C0A60
	private void OnClick()
	{
		if (this.ClickFunction != null)
		{
			this.ClickFunction();
		}
	}

	// Token: 0x0400A01A RID: 40986
	private int Id;

	// Token: 0x0400A01B RID: 40987
	[Nullable(1)]
	private readonly Action ClickFunction;

	// Token: 0x02008C3A RID: 35898
	private enum ESkillDefine
	{
		// Token: 0x0402F3BD RID: 193469
		EquipSkillIconTexture,
		// Token: 0x0402F3BE RID: 193470
		EquipSkillButton
	}
}
