using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.Util;
using Cysharp.Threading.Tasks;
using UnrealEngine;

namespace CSharpScript.Game.Module.WorldMap.SubViews.GreatSword
{
	// Token: 0x02004BB7 RID: 19383
	[NullableContext(1)]
	[Nullable(0)]
	public class GreatSwordMarkTargetListPanel
	{
		// Token: 0x060329A3 RID: 207267 RVA: 0x00CAC948 File Offset: 0x00CAAB48
		public void Initialize(UUILayoutBase rootLayout)
		{
			this.TargetListLayout = new GenericLayoutAdd<GreatSwordMarkTargetListItemPanel>(rootLayout, new TLayoutRefresh<GreatSwordMarkTargetListItemPanel>(this.OnLayoutRefresh));
		}

		// Token: 0x060329A4 RID: 207268 RVA: 0x00CAC964 File Offset: 0x00CAAB64
		private ILayoutItem<GreatSwordMarkTargetListItemPanel> OnLayoutRefresh(object data, UUIItem uiItem, int index, int originalItemIndex)
		{
			GreatSwordMarkTargetListItemPanel greatSwordMarkTargetListItemPanel = new GreatSwordMarkTargetListItemPanel();
			greatSwordMarkTargetListItemPanel.CreateThenShowByActorAsync(uiItem.GetOwner(), null, false).Forget();
			return new LayoutItem<GreatSwordMarkTargetListItemPanel>
			{
				Key = data,
				Value = greatSwordMarkTargetListItemPanel
			};
		}

		// Token: 0x060329A5 RID: 207269 RVA: 0x00CAC9A0 File Offset: 0x00CAABA0
		public GreatSwordMarkTargetListItemPanel AddItemByKey(string key)
		{
			GenericLayoutAdd<GreatSwordMarkTargetListItemPanel> targetListLayout = this.TargetListLayout;
			GreatSwordMarkTargetListItemPanel greatSwordMarkTargetListItemPanel = ((targetListLayout != null) ? targetListLayout.GetLayoutItemByKey(key, 0) : null) as GreatSwordMarkTargetListItemPanel;
			if (greatSwordMarkTargetListItemPanel != null)
			{
				return greatSwordMarkTargetListItemPanel;
			}
			GenericLayoutAdd<GreatSwordMarkTargetListItemPanel> targetListLayout2 = this.TargetListLayout;
			if (targetListLayout2 != null)
			{
				targetListLayout2.AddItemToLayout(new object[]
				{
					key
				}, 0);
			}
			GenericLayoutAdd<GreatSwordMarkTargetListItemPanel> targetListLayout3 = this.TargetListLayout;
			greatSwordMarkTargetListItemPanel = (((targetListLayout3 != null) ? targetListLayout3.GetLayoutItemByKey(key, 0) : null) as GreatSwordMarkTargetListItemPanel);
			if (greatSwordMarkTargetListItemPanel != null)
			{
				greatSwordMarkTargetListItemPanel.SetState(false);
			}
			return greatSwordMarkTargetListItemPanel;
		}

		// Token: 0x060329A6 RID: 207270 RVA: 0x00CACA0D File Offset: 0x00CAAC0D
		public void Clear()
		{
			GenericLayoutAdd<GreatSwordMarkTargetListItemPanel> targetListLayout = this.TargetListLayout;
			if (targetListLayout == null)
			{
				return;
			}
			targetListLayout.ClearChildren();
		}

		// Token: 0x0401D7DE RID: 120798
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private GenericLayoutAdd<GreatSwordMarkTargetListItemPanel> TargetListLayout;
	}
}
