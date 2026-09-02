using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Protocol;
using UnrealEngine;

namespace CSharpScript.Game.Module.RogueBattle
{
	// Token: 0x02005216 RID: 21014
	[NullableContext(1)]
	[Nullable(0)]
	internal class <RogueBattleSettleInfoRoleGrid>F0E37ABE6599E9F57B3333E379A1AB96877BE20C8298B0836CD56EC51AFB66B94__RogueBattleSettleInfoRoleGridLevelComponent : MediumItemGridComponent
	{
		// Token: 0x06035DF2 RID: 220658 RVA: 0x00D8F0F4 File Offset: 0x00D8D2F4
		protected override void OnRegisterComponent()
		{
			this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
			{
				new ValueTuple<int, Type>(0, typeof(UUIText)),
				new ValueTuple<int, Type>(1, typeof(UUIItem)),
				new ValueTuple<int, Type>(2, typeof(UUIItem)),
				new ValueTuple<int, Type>(3, typeof(UUIText))
			};
		}

		// Token: 0x06035DF3 RID: 220659 RVA: 0x00D8F164 File Offset: 0x00D8D364
		protected override string GetResourceId()
		{
			return "UiItem_ItemRoleInfo";
		}

		// Token: 0x06035DF4 RID: 220660 RVA: 0x00D8F16C File Offset: 0x00D8D36C
		protected override void OnRefresh(object data)
		{
			RogueResGainData rogueResGainData = (RogueResGainData)data;
			UUIText text = base.GetText(0);
			if (text != null)
			{
				text.SetText(string.Empty, true);
			}
			UUIText text2 = base.GetText(3);
			if (text2 == null)
			{
				return;
			}
			text2.SetText(rogueResGainData.RogueResRole.Level.ToString(), true);
		}
	}
}
