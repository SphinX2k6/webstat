using System;
using System.Collections.Generic;
using CSharpScript.Game.Module.Util;
using UnrealEngine;

namespace CSharpScript.Game.Module.RogueBattle
{
	// Token: 0x020051EF RID: 20975
	public class RougeBattleAttributeStarItem : GridProxyAbstract<bool>
	{
		// Token: 0x06035D7D RID: 220541 RVA: 0x00D8C60D File Offset: 0x00D8A80D
		protected override void OnRegisterComponent()
		{
			this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
			{
				new ValueTuple<int, Type>(0, typeof(UUIItem)),
				new ValueTuple<int, Type>(1, typeof(UUIItem))
			};
		}

		// Token: 0x06035D7E RID: 220542 RVA: 0x00D8C646 File Offset: 0x00D8A846
		public override void Refresh(bool data, bool isSelected, int gridIndex)
		{
			UUIItem item = base.GetItem(1);
			if (item == null)
			{
				return;
			}
			item.SetUIActive(data);
		}
	}
}
