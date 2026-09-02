using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using Aki.Protocol;
using CSharpScript.Game.Module.Util;
using UnrealEngine;

namespace CSharpScript.Game.Module.RogueBattle
{
	// Token: 0x0200521D RID: 21021
	[NullableContext(1)]
	[Nullable(0)]
	public class RogueBattleGridElementComponent : MediumItemGridComponent
	{
		// Token: 0x06035E09 RID: 220681 RVA: 0x00D8F85D File Offset: 0x00D8DA5D
		protected override string GetResourceId()
		{
			return "UiItem_ItemRogueElement";
		}

		// Token: 0x06035E0A RID: 220682 RVA: 0x00D8F864 File Offset: 0x00D8DA64
		protected override void OnRegisterComponent()
		{
			this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
			{
				new ValueTuple<int, Type>(0, typeof(UUIVerticalLayout))
			};
		}

		// Token: 0x06035E0B RID: 220683 RVA: 0x00D8F887 File Offset: 0x00D8DA87
		protected override void OnActivate()
		{
			this.GenericLayout = new GenericLayout<RogueBattleTokenElement, int>(base.GetVerticalLayout(0), new Func<RogueBattleTokenElement>(this.CreateElement), null, false, true);
		}

		// Token: 0x06035E0C RID: 220684 RVA: 0x00D8F8AA File Offset: 0x00D8DAAA
		private RogueBattleTokenElement CreateElement()
		{
			return new RogueBattleTokenElement();
		}

		// Token: 0x06035E0D RID: 220685 RVA: 0x00D8F8B4 File Offset: 0x00D8DAB4
		protected override void OnRefresh(object data)
		{
			int[] tokenSortElementInfoByCount = RogueBattleUtils.GetTokenSortElementInfoByCount((RogueResGainData)data);
			GenericLayout<RogueBattleTokenElement, int> genericLayout = this.GenericLayout;
			if (genericLayout == null)
			{
				return;
			}
			genericLayout.RefreshByData(tokenSortElementInfoByCount.ToList<int>(), null, false);
		}

		// Token: 0x0401EF41 RID: 126785
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private GenericLayout<RogueBattleTokenElement, int> GenericLayout;
	}
}
