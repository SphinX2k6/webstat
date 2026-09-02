using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.Util;
using Cysharp.Threading.Tasks;
using UnrealEngine;

namespace CSharpScript.Game.Module.WorldMap.SubViews.PunishReport
{
	// Token: 0x02004B92 RID: 19346
	[NullableContext(1)]
	[Nullable(0)]
	public class PunishReportTargetListPanel
	{
		// Token: 0x06032867 RID: 206951 RVA: 0x00CA5C31 File Offset: 0x00CA3E31
		public void Initialize(UUILayoutBase rootLayout)
		{
			this.TargetListLayout = new GenericLayoutAdd<PunishReportTargetListItemPanel>(rootLayout, new TLayoutRefresh<PunishReportTargetListItemPanel>(this.OnLayoutRefresh));
		}

		// Token: 0x06032868 RID: 206952 RVA: 0x00CA5C4C File Offset: 0x00CA3E4C
		private ILayoutItem<PunishReportTargetListItemPanel> OnLayoutRefresh(object data, UUIItem uiItem, int index, int originalItemIndex)
		{
			PunishReportTargetListItemPanel punishReportTargetListItemPanel = new PunishReportTargetListItemPanel();
			punishReportTargetListItemPanel.CreateThenShowByActorAsync((uiItem != null) ? uiItem.GetOwner() : null, null, false).Forget();
			return new LayoutItem<PunishReportTargetListItemPanel>
			{
				Key = data,
				Value = punishReportTargetListItemPanel
			};
		}

		// Token: 0x06032869 RID: 206953 RVA: 0x00CA5C8C File Offset: 0x00CA3E8C
		public PunishReportTargetListItemPanel AddItemByKey(string key)
		{
			GenericLayoutAdd<PunishReportTargetListItemPanel> targetListLayout = this.TargetListLayout;
			PunishReportTargetListItemPanel punishReportTargetListItemPanel = ((targetListLayout != null) ? targetListLayout.GetLayoutItemByKey(key, 0) : null) as PunishReportTargetListItemPanel;
			if (punishReportTargetListItemPanel != null)
			{
				return punishReportTargetListItemPanel;
			}
			GenericLayoutAdd<PunishReportTargetListItemPanel> targetListLayout2 = this.TargetListLayout;
			if (targetListLayout2 != null)
			{
				targetListLayout2.AddItemToLayout(new object[]
				{
					key
				}, 0);
			}
			GenericLayoutAdd<PunishReportTargetListItemPanel> targetListLayout3 = this.TargetListLayout;
			punishReportTargetListItemPanel = (((targetListLayout3 != null) ? targetListLayout3.GetLayoutItemByKey(key, 0) : null) as PunishReportTargetListItemPanel);
			punishReportTargetListItemPanel.SetDescTxt("");
			punishReportTargetListItemPanel.SetNumTxt("");
			punishReportTargetListItemPanel.SetState(EPunishReportTargetListItemPanelState.Lock);
			return punishReportTargetListItemPanel;
		}

		// Token: 0x0603286A RID: 206954 RVA: 0x00CA5D0C File Offset: 0x00CA3F0C
		public void Clear()
		{
			GenericLayoutAdd<PunishReportTargetListItemPanel> targetListLayout = this.TargetListLayout;
			if (targetListLayout == null)
			{
				return;
			}
			targetListLayout.ClearChildren();
		}

		// Token: 0x0401D76C RID: 120684
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private GenericLayoutAdd<PunishReportTargetListItemPanel> TargetListLayout;
	}
}
