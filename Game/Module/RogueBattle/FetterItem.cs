using System;
using System.Collections.Generic;
using Aki.Config;
using CSharpScript.Game.Module.Util;
using UnrealEngine;

namespace CSharpScript.Game.Module.RogueBattle
{
	// Token: 0x020051D5 RID: 20949
	public class FetterItem : GridProxyAbstract<FetterData>
	{
		// Token: 0x06035D33 RID: 220467 RVA: 0x00D8A964 File Offset: 0x00D88B64
		protected override void OnRegisterComponent()
		{
			this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
			{
				new ValueTuple<int, Type>(0, typeof(UUISprite)),
				new ValueTuple<int, Type>(1, typeof(UUITexture)),
				new ValueTuple<int, Type>(2, typeof(UUIText))
			};
		}

		// Token: 0x06035D34 RID: 220468 RVA: 0x00D8A9BE File Offset: 0x00D88BBE
		public override void Refresh(FetterData data, bool isSelected, int gridIndex)
		{
			this.Refresh(data);
		}

		// Token: 0x06035D35 RID: 220469 RVA: 0x00D8A9C8 File Offset: 0x00D88BC8
		public void Refresh(FetterData data)
		{
			RogueResBond? rogueResBond = ConfigBase<RogueBattleConfig>.Instance.GetRogueResBond(data.Id);
			RogueResBondLv? bondLvConfigByLv = ConfigBase<RogueBattleConfig>.Instance.GetBondLvConfigByLv(data.Lv);
			if (rogueResBond == null || bondLvConfigByLv == null)
			{
				return;
			}
			UUITexture texture = base.GetTexture(1);
			UUIItem uuiitem = texture;
			bool bUseChangeColor = data.Lv == 0;
			FColor? fcolor = new FColor?(texture.changeColor);
			uuiitem.SetChangeColor(bUseChangeColor, fcolor);
			base.SetTextureShowUntilLoaded(rogueResBond.Value.Icon, texture, null);
			UUISprite sprite = base.GetSprite(0);
			FColor color = FColor.FromHex(bondLvConfigByLv.Value.LvColor);
			sprite.SetColor(color);
			sprite.SetUIActive(data.Lv > 0);
			base.GetText(2).SetText(data.Star.ToString(), true);
		}
	}
}
