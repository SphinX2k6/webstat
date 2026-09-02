using System;
using System.Collections.Generic;
using Aki.Config;
using CSharpScript.Game.Module.Util;
using UnrealEngine;

namespace CSharpScript.Game.Module.RogueBattle
{
	// Token: 0x0200522E RID: 21038
	public class RogueBattleTokenElement : GridProxyAbstract<int>
	{
		// Token: 0x06035E55 RID: 220757 RVA: 0x00D90EF8 File Offset: 0x00D8F0F8
		protected override void OnRegisterComponent()
		{
			this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
			{
				new ValueTuple<int, Type>(0, typeof(UUISprite)),
				new ValueTuple<int, Type>(1, typeof(UUITexture))
			};
		}

		// Token: 0x06035E56 RID: 220758 RVA: 0x00D90F34 File Offset: 0x00D8F134
		public override void Refresh(int elementId, bool isSelected, int gridIndex)
		{
			ElementInfo? elementConfig = ConfigBase<CommonConfig>.Instance.GetElementConfig(elementId);
			if (elementConfig == null)
			{
				return;
			}
			FColor color = FColor.FromHex(elementConfig.Value.ElementColor);
			base.GetSprite(0).SetColor(color);
			base.SetTextureByPath(elementConfig.Value.Icon5, base.GetTexture(1), null, null);
		}
	}
}
