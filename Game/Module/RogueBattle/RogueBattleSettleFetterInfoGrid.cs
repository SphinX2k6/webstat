using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using Aki.Protocol;
using CSharpScript.Game.Module.Util;
using UnrealEngine;

namespace CSharpScript.Game.Module.RogueBattle
{
	// Token: 0x02005211 RID: 21009
	[NullableContext(1)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	public class RogueBattleSettleFetterInfoGrid : GridProxyAbstract<RoleBondInfo>
	{
		// Token: 0x06035DE9 RID: 220649 RVA: 0x00D8ED58 File Offset: 0x00D8CF58
		protected override void OnRegisterComponent()
		{
			this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
			{
				new ValueTuple<int, Type>(0, typeof(UUIExtendToggle)),
				new ValueTuple<int, Type>(1, typeof(UUITexture)),
				new ValueTuple<int, Type>(2, typeof(UUIText))
			};
		}

		// Token: 0x06035DEA RID: 220650 RVA: 0x00D8EDB4 File Offset: 0x00D8CFB4
		public override void Refresh(RoleBondInfo data, bool isSelected, int gridIndex)
		{
			RogueResBond? rogueResBond = ConfigBase<RogueBattleConfig>.Instance.GetRogueResBond(data.ConfigId);
			if (rogueResBond == null)
			{
				return;
			}
			base.SetTextureShowUntilLoaded(rogueResBond.Value.Icon, base.GetTexture(1), null);
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(2), "RogueRes_FightFormation_RoleLevel", new <>z__ReadOnlySingleElementList<object>(data.Level.ToString()));
		}
	}
}
