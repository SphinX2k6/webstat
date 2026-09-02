using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using Aki.Protocol;
using CSharpScript.Game.Module.Util;
using UnrealEngine;

namespace CSharpScript.Game.Module.RogueBattle
{
	// Token: 0x02005227 RID: 21031
	[NullableContext(1)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	public class RogueBattleTeamEditFetterIconItem : GridProxyAbstract<IRogueBattleRoleBondUpdateInfo>
	{
		// Token: 0x06035E26 RID: 220710 RVA: 0x00D8FF3C File Offset: 0x00D8E13C
		protected override void OnRegisterComponent()
		{
			this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
			{
				new ValueTuple<int, Type>(0, typeof(UUISprite)),
				new ValueTuple<int, Type>(1, typeof(UUITexture)),
				new ValueTuple<int, Type>(2, typeof(UUIItem)),
				new ValueTuple<int, Type>(3, typeof(UUIItem))
			};
		}

		// Token: 0x06035E27 RID: 220711 RVA: 0x00D8FFAC File Offset: 0x00D8E1AC
		public override void Refresh(IRogueBattleRoleBondUpdateInfo data, bool isSelected, int gridIndex)
		{
			RoleBondInfo newRoleBondInfo = data.NewRoleBondInfo;
			RogueResBond? rogueResBond = ConfigBase<RogueBattleConfig>.Instance.GetRogueResBond(newRoleBondInfo.ConfigId);
			RogueResBondLv? bondLvConfigByLv = ConfigBase<RogueBattleConfig>.Instance.GetBondLvConfigByLv(newRoleBondInfo.Level);
			if (rogueResBond == null || bondLvConfigByLv == null)
			{
				return;
			}
			UUITexture texture = base.GetTexture(1);
			UUIItem uuiitem = texture;
			bool bUseChangeColor = newRoleBondInfo.Level == 0;
			FColor? fcolor = new FColor?(texture.changeColor);
			uuiitem.SetChangeColor(bUseChangeColor, fcolor);
			base.SetTextureShowUntilLoaded(rogueResBond.Value.Icon, texture, null);
			UUIItem sprite = base.GetSprite(0);
			FColor color = FColor.FromHex((newRoleBondInfo.Level > 0) ? bondLvConfigByLv.Value.LvColor : "FFFFFF7F");
			sprite.SetColor(color);
			this.SetLinkEffectOn(false);
		}

		// Token: 0x06035E28 RID: 220712 RVA: 0x00D9006F File Offset: 0x00D8E26F
		public void SetLinkEffectOn(bool bOn)
		{
			base.GetItem(2).SetUIActive(bOn);
			base.GetItem(3).SetUIActive(bOn);
		}

		// Token: 0x06035E29 RID: 220713 RVA: 0x00D9008B File Offset: 0x00D8E28B
		public override object GetKey(IRogueBattleRoleBondUpdateInfo data, int displayIndex)
		{
			return data.NewRoleBondInfo.ConfigId;
		}
	}
}
