using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.Util;
using UnrealEngine;

namespace CSharpScript.Game.Module.WorldMap.SubViews
{
	// Token: 0x02004B5B RID: 19291
	[NullableContext(1)]
	[Nullable(0)]
	public class TipsListView
	{
		// Token: 0x0603263A RID: 206394 RVA: 0x00C9C28E File Offset: 0x00C9A48E
		public void Initialize(UUILayoutBase rootLayout)
		{
			this.InstanceCostTipView = new GenericLayoutAdd<InstanceDungeonCostTip>(rootLayout, new TLayoutRefresh<InstanceDungeonCostTip>(this.OnInstanceRefresh));
		}

		// Token: 0x0603263B RID: 206395 RVA: 0x00C9C2A8 File Offset: 0x00C9A4A8
		private ILayoutItem<InstanceDungeonCostTip> OnInstanceRefresh(object data, UUIItem uiItem, int index, int originalItemIndex)
		{
			InstanceDungeonCostTip instanceDungeonCostTip = new InstanceDungeonCostTip();
			instanceDungeonCostTip.SetRootActor(uiItem.GetOwner(), true);
			return new LayoutItem<InstanceDungeonCostTip>
			{
				Key = data,
				Value = instanceDungeonCostTip
			};
		}

		// Token: 0x0603263C RID: 206396 RVA: 0x00C9C2DC File Offset: 0x00C9A4DC
		public InstanceDungeonCostTip AddItemByKey(string key)
		{
			InstanceDungeonCostTip instanceDungeonCostTip = this.InstanceCostTipView.GetLayoutItemByKey(key, 0) as InstanceDungeonCostTip;
			if (instanceDungeonCostTip != null)
			{
				return instanceDungeonCostTip;
			}
			this.InstanceCostTipView.AddItemToLayout(new object[]
			{
				key
			}, 0);
			instanceDungeonCostTip = (this.InstanceCostTipView.GetLayoutItemByKey(key, 0) as InstanceDungeonCostTip);
			instanceDungeonCostTip.SetStarVisible(false);
			instanceDungeonCostTip.SetIconVisible(false);
			instanceDungeonCostTip.SetLeftText("");
			instanceDungeonCostTip.SetRightText("");
			return instanceDungeonCostTip;
		}

		// Token: 0x0603263D RID: 206397 RVA: 0x00C9C34F File Offset: 0x00C9A54F
		public void Clear()
		{
			GenericLayoutAdd<InstanceDungeonCostTip> instanceCostTipView = this.InstanceCostTipView;
			if (instanceCostTipView == null)
			{
				return;
			}
			instanceCostTipView.ClearChildren();
		}

		// Token: 0x0401D6AC RID: 120492
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private GenericLayoutAdd<InstanceDungeonCostTip> InstanceCostTipView;
	}
}
