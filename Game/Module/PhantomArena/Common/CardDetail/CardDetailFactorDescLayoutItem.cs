using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using UnrealEngine;

namespace CSharpScript.Game.Module.PhantomArena.Common.CardDetail
{
	// Token: 0x02005573 RID: 21875
	[NullableContext(1)]
	[Nullable(0)]
	public class CardDetailFactorDescLayoutItem : UiPanelBase
	{
		// Token: 0x06037BDD RID: 228317 RVA: 0x00E21C36 File Offset: 0x00E1FE36
		public CardDetailFactorDescLayoutItem(UUILayoutBase layout, UUIItem templateItem = null)
		{
			this.FactorDescLayout = new GenericLayout<CardDetailFactorDescItem, CardDetailFactorDescItemData>(layout, new Func<CardDetailFactorDescItem>(this.CreateCardFactorDescItem), ((templateItem != null) ? templateItem.GetOwner() : null) as AUIBaseActor, false, true);
		}

		// Token: 0x06037BDE RID: 228318 RVA: 0x00E21C69 File Offset: 0x00E1FE69
		public void Refresh(List<CardDetailFactorDescItemData> factorDataList)
		{
			this.FactorDescLayout.RefreshByData(factorDataList, null, false);
		}

		// Token: 0x06037BDF RID: 228319 RVA: 0x00E21C79 File Offset: 0x00E1FE79
		public void SetLayoutActive(bool active)
		{
			UUIItem rootUiItem = this.FactorDescLayout.GetRootUiItem();
			if (rootUiItem == null)
			{
				return;
			}
			rootUiItem.SetUIActive(active);
		}

		// Token: 0x06037BE0 RID: 228320 RVA: 0x00E21C91 File Offset: 0x00E1FE91
		private CardDetailFactorDescItem CreateCardFactorDescItem()
		{
			return new CardDetailFactorDescItem();
		}

		// Token: 0x06037BE1 RID: 228321 RVA: 0x00E21C98 File Offset: 0x00E1FE98
		public override UUIItem[] GetGuideUiItemAndUiItemForShowEx(string[] configParams)
		{
			if (configParams == null || configParams.Length <= 1)
			{
				return null;
			}
			int displayIndex = int.Parse(configParams[1]);
			GenericLayout<CardDetailFactorDescItem, CardDetailFactorDescItemData> factorDescLayout = this.FactorDescLayout;
			UUIItem uuiitem = (factorDescLayout != null) ? factorDescLayout.GetGridByDisplayIndex(displayIndex) : null;
			if (uuiitem == null)
			{
				return null;
			}
			return new UUIItem[]
			{
				uuiitem,
				uuiitem
			};
		}

		// Token: 0x0401FEA9 RID: 130729
		private readonly GenericLayout<CardDetailFactorDescItem, CardDetailFactorDescItemData> FactorDescLayout;
	}
}
