using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using UnrealEngine;

namespace CSharpScript.Game.Module.PhantomArena.Common.CardDetail
{
	// Token: 0x02005570 RID: 21872
	[NullableContext(1)]
	[Nullable(0)]
	public class CardDetailEntryDescLayoutItem : UiPanelBase
	{
		// Token: 0x06037BD5 RID: 228309 RVA: 0x00E21A3B File Offset: 0x00E1FC3B
		public CardDetailEntryDescLayoutItem(UUILayoutBase layout, UUIItem templateItem = null)
		{
			this.EntryDescLayout = new GenericLayout<CardDetailEntryDescItem, int>(layout, new Func<CardDetailEntryDescItem>(this.CreateEntryDescItem), ((templateItem != null) ? templateItem.GetOwner() : null) as AUIBaseActor, false, true);
		}

		// Token: 0x06037BD6 RID: 228310 RVA: 0x00E21A6E File Offset: 0x00E1FC6E
		public void Refresh(List<int> entryIdList)
		{
			this.EntryDescLayout.RefreshByData(entryIdList, null, false);
		}

		// Token: 0x06037BD7 RID: 228311 RVA: 0x00E21A80 File Offset: 0x00E1FC80
		public unsafe void RefreshByCardConfig(PhantomBattleCard config)
		{
			List<int> list = new List<int>();
			list.AddRange(config.GetEntryIdListBytes());
			Span<int> cardFactorIdBytes = config.GetCardFactorIdBytes();
			for (int i = 0; i < cardFactorIdBytes.Length; i++)
			{
				int factorConfigId = *cardFactorIdBytes[i];
				int entryId = ConfigBase<PhantomArenaConfig>.Instance.GetPhantomBattleFactorConfig(factorConfigId).EntryId;
				if (entryId > 0 && !list.Contains(entryId))
				{
					list.Add(entryId);
				}
			}
			this.Refresh(list);
		}

		// Token: 0x06037BD8 RID: 228312 RVA: 0x00E21AFD File Offset: 0x00E1FCFD
		private CardDetailEntryDescItem CreateEntryDescItem()
		{
			return new CardDetailEntryDescItem();
		}

		// Token: 0x0401FEA5 RID: 130725
		private readonly GenericLayout<CardDetailEntryDescItem, int> EntryDescLayout;
	}
}
