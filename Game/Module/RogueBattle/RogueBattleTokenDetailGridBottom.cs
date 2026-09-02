using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Protocol;
using UnrealEngine;

namespace CSharpScript.Game.Module.RogueBattle
{
	// Token: 0x02005223 RID: 21027
	[NullableContext(1)]
	[Nullable(0)]
	public class RogueBattleTokenDetailGridBottom : MediumItemGridComponent
	{
		// Token: 0x06035E17 RID: 220695 RVA: 0x00D8FAC4 File Offset: 0x00D8DCC4
		protected override string GetResourceId()
		{
			return "UiItem_ItemRogue";
		}

		// Token: 0x06035E18 RID: 220696 RVA: 0x00D8FACB File Offset: 0x00D8DCCB
		protected override void OnRegisterComponent()
		{
			this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
			{
				new ValueTuple<int, Type>(0, typeof(UUIItem)),
				new ValueTuple<int, Type>(1, typeof(UUIText))
			};
		}

		// Token: 0x06035E19 RID: 220697 RVA: 0x00D8FB04 File Offset: 0x00D8DD04
		protected override void OnActivate()
		{
			this.CommonElementItem = new RogueBattleTokenElement();
			this.CommonElementItem.CreateThenShowByActorAsync(base.GetItem(0).GetOwner());
		}

		// Token: 0x06035E1A RID: 220698 RVA: 0x00D8FB2C File Offset: 0x00D8DD2C
		protected override void OnRefresh(object data)
		{
			List<IRogueBattleElementInfo> tokenSortElementInfo = RogueBattleUtils.GetTokenSortElementInfo((RogueResGainData)data);
			if (tokenSortElementInfo.Count <= 0)
			{
				return;
			}
			this.CommonElementItem.Refresh(tokenSortElementInfo[0].ElementId, false, 0);
			base.GetText(1).SetText(tokenSortElementInfo[0].Count.ToString(), true);
		}

		// Token: 0x0401EF4A RID: 126794
		[Nullable(2)]
		private RogueBattleTokenElement CommonElementItem;
	}
}
