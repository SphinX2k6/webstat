using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using Aki.Protocol;
using CSharpScript.Game.Module.RogueBattle;
using CSharpScript.Game.Module.Util;
using UnrealEngine;

// Token: 0x02002776 RID: 10102
[NullableContext(1)]
[Nullable(new byte[]
{
	0,
	1
})]
public class RogueBattleFetterIconItem : GridProxyAbstract<RogueBattleRoleBondUpdateInfo>
{
	// Token: 0x06013ED7 RID: 81623 RVA: 0x0058DD3E File Offset: 0x0058BF3E
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUISprite)),
			new ValueTuple<int, Type>(1, typeof(UUITexture))
		};
	}

	// Token: 0x06013ED8 RID: 81624 RVA: 0x0058DD77 File Offset: 0x0058BF77
	public override void Refresh(RogueBattleRoleBondUpdateInfo data, bool isSelected, int gridIndex)
	{
		this.Data = data;
		this.RefreshSelectState(false);
	}

	// Token: 0x06013ED9 RID: 81625 RVA: 0x0058DD88 File Offset: 0x0058BF88
	public void RefreshSelectState(bool isSelected)
	{
		RoleBondInfo roleBondInfo = isSelected ? this.Data.NewRoleBondInfo : this.Data.OldRoleBondInfo;
		RogueResBond? rogueResBond = ConfigBase<RogueBattleConfig>.Instance.GetRogueResBond(roleBondInfo.ConfigId);
		RogueResBondLv? bondLvConfigByLv = ConfigBase<RogueBattleConfig>.Instance.GetBondLvConfigByLv(roleBondInfo.Level);
		if (rogueResBond == null || bondLvConfigByLv == null)
		{
			return;
		}
		UUITexture texture = base.GetTexture(1);
		UUIItem uuiitem = texture;
		bool bUseChangeColor = roleBondInfo.Level == 0;
		FColor? fcolor = new FColor?(texture.changeColor);
		uuiitem.SetChangeColor(bUseChangeColor, fcolor);
		base.SetTextureShowUntilLoaded(rogueResBond.Value.Icon, texture, null);
		UUIItem sprite = base.GetSprite(0);
		FColor color = FColor.FromHex((roleBondInfo.Level > 0) ? bondLvConfigByLv.Value.LvColor : "FFFFFF7F");
		sprite.SetColor(color);
	}

	// Token: 0x04009B1C RID: 39708
	private RogueBattleRoleBondUpdateInfo Data;
}
