using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnrealEngine;

// Token: 0x02002AD3 RID: 10963
public class SurvivorsRogueCardComponentLvDesc : SurvivorsRogueCardComponent
{
	// Token: 0x06015EB7 RID: 89783 RVA: 0x00616C7C File Offset: 0x00614E7C
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUIText))
		};
	}

	// Token: 0x06015EB8 RID: 89784 RVA: 0x00616C9F File Offset: 0x00614E9F
	[NullableContext(2)]
	protected override string OnGetResourceId()
	{
		return "UiItem_SurvivorsCardTips";
	}

	// Token: 0x06015EB9 RID: 89785 RVA: 0x00616CA6 File Offset: 0x00614EA6
	public override ECardMountPos GetLayoutLevel()
	{
		return ECardMountPos.Bottom;
	}

	// Token: 0x06015EBA RID: 89786 RVA: 0x00616CAC File Offset: 0x00614EAC
	protected override void OnRefresh([Nullable(new byte[]
	{
		1,
		2
	})] params object[] params_)
	{
		int? num = (params_.Length != 0 && params_[0] != null) ? ((int?)params_[0]) : null;
		ESurvivorsRogueItemType esurvivorsRogueItemType = (ESurvivorsRogueItemType)((params_.Length > 1 && params_[1] != null) ? ((int)params_[1]) : 0);
		if (num == null || num.Value == 0)
		{
			this.SetActive(false);
			return;
		}
		if (esurvivorsRogueItemType != ESurvivorsRogueItemType.Weapon)
		{
			if (esurvivorsRogueItemType == ESurvivorsRogueItemType.Character)
			{
				this.SetText("SurvivorsCard_RoleLv", new string[]
				{
					num.Value.ToString()
				});
			}
		}
		else
		{
			this.SetText("SurvivorsCard_WeaponLv", new string[]
			{
				num.Value.ToString()
			});
		}
		this.SetActive(true);
	}

	// Token: 0x06015EBB RID: 89787 RVA: 0x00616D5E File Offset: 0x00614F5E
	[NullableContext(1)]
	public void SetText(string txtId, params string[] args)
	{
		Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(0), txtId, args);
	}
}
