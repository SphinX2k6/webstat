using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using UnrealEngine;

namespace CSharpScript.Game.Module.PhantomArena.Common.CardDetail
{
	// Token: 0x0200556B RID: 21867
	[NullableContext(1)]
	[Nullable(0)]
	public class CardDetailAttributeLayoutItem : UiPanelBase
	{
		// Token: 0x06037BC2 RID: 228290 RVA: 0x00E2189C File Offset: 0x00E1FA9C
		public CardDetailAttributeLayoutItem(UUILayoutBase layout, UUIItem templateItem = null)
		{
			this.AttributeLayout = new GenericLayout<CardDetailAttributeItem, CardDetailAttributeItemData>(layout, new Func<CardDetailAttributeItem>(this.CreateCardDetailAttributeItem), ((templateItem != null) ? templateItem.GetOwner() : null) as AUIBaseActor, false, true);
		}

		// Token: 0x06037BC3 RID: 228291 RVA: 0x00E218CF File Offset: 0x00E1FACF
		public void Refresh(List<CardDetailAttributeItemData> dataList)
		{
			this.AttributeLayout.RefreshByData(dataList, null, false);
		}

		// Token: 0x06037BC4 RID: 228292 RVA: 0x00E218DF File Offset: 0x00E1FADF
		public void SetLayoutActive(bool active)
		{
			UUIItem rootUiItem = this.AttributeLayout.GetRootUiItem();
			if (rootUiItem == null)
			{
				return;
			}
			rootUiItem.SetUIActive(active);
		}

		// Token: 0x06037BC5 RID: 228293 RVA: 0x00E218F7 File Offset: 0x00E1FAF7
		private CardDetailAttributeItem CreateCardDetailAttributeItem()
		{
			return new CardDetailAttributeItem();
		}

		// Token: 0x0401FEA2 RID: 130722
		private readonly GenericLayout<CardDetailAttributeItem, CardDetailAttributeItemData> AttributeLayout;
	}
}
