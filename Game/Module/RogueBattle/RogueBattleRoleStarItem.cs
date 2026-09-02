using System;
using System.Collections.Generic;
using CSharpScript.Game.Module.Util;
using UnrealEngine;

namespace CSharpScript.Game.Module.RogueBattle
{
	// Token: 0x0200520B RID: 21003
	public class RogueBattleRoleStarItem : GridProxyAbstract<ERogueRoleStarState>
	{
		// Token: 0x06035DDF RID: 220639 RVA: 0x00D8E7DC File Offset: 0x00D8C9DC
		protected override void OnRegisterComponent()
		{
			this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
			{
				new ValueTuple<int, Type>(0, typeof(UUISprite)),
				new ValueTuple<int, Type>(1, typeof(UUISprite)),
				new ValueTuple<int, Type>(2, typeof(UUISprite)),
				new ValueTuple<int, Type>(3, typeof(UUIItem)),
				new ValueTuple<int, Type>(4, typeof(UUIItem))
			};
		}

		// Token: 0x06035DE0 RID: 220640 RVA: 0x00D8E862 File Offset: 0x00D8CA62
		protected override void OnStart()
		{
			base.GetSprite(0).SetUIActive(true);
		}

		// Token: 0x06035DE1 RID: 220641 RVA: 0x00D8E874 File Offset: 0x00D8CA74
		public override void Refresh(ERogueRoleStarState state, bool isSelected, int gridIndex)
		{
			base.GetSprite(1).SetUIActive(state == ERogueRoleStarState.Active);
			base.GetSprite(2).SetUIActive(state == ERogueRoleStarState.LightOn);
			base.GetItem(3).SetUIActive(state == ERogueRoleStarState.Active);
			base.GetItem(4).SetUIActive(state == ERogueRoleStarState.LightOn);
		}
	}
}
