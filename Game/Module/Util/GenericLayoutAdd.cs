using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Ui;
using UnrealEngine;

namespace CSharpScript.Game.Module.Util
{
	// Token: 0x02004C5C RID: 19548
	[NullableContext(1)]
	[Nullable(0)]
	public class GenericLayoutAdd<[Nullable(0)] T> where T : UiPanelBase
	{
		// Token: 0x06032EE9 RID: 208617 RVA: 0x00CC2796 File Offset: 0x00CC0996
		public GenericLayoutAdd(UUILayoutBase layout, TLayoutRefresh<T> refreshFunction)
		{
			this.ProxyLayout = layout;
			this.RefreshFunction = refreshFunction;
			this.SaveOriginal();
		}

		// Token: 0x06032EEA RID: 208618 RVA: 0x00CC27D4 File Offset: 0x00CC09D4
		private void SaveOriginal()
		{
			if (this.ProxyLayout != null)
			{
				TArray<UUIItem> attachUIChildren = this.GetRootUiItem().GetAttachUIChildren();
				int i = 0;
				int num = attachUIChildren.Num();
				while (i < num)
				{
					UUIItem uuiitem = attachUIChildren.Get(i);
					if (uuiitem != null)
					{
						uuiitem.SetUIActive(false);
					}
					this.OriginalItemMap[i] = uuiitem;
					i++;
				}
			}
		}

		// Token: 0x06032EEB RID: 208619 RVA: 0x00CC2827 File Offset: 0x00CC0A27
		private UUIItem GetRootUiItem()
		{
			return this.ProxyLayout.GetRootComponent();
		}

		// Token: 0x06032EEC RID: 208620 RVA: 0x00CC2834 File Offset: 0x00CC0A34
		public void AddItemToLayout(object[] dataList, int hierarchyIndex = 0)
		{
			UUIItem uuiitem;
			if (!this.OriginalItemMap.TryGetValue(hierarchyIndex, out uuiitem))
			{
				Singleton<Log>.Instance.Error(ELogModule.ModuleUtil, ELogAuthor.XXJ, "查找不到对应HierarchyIndex的UIItem", default(ReadOnlySpan<ValueTuple<string, object>>));
				return;
			}
			uuiitem.SetUIActive(true);
			Dictionary<object, UiPanelBase> dictionary;
			if (!this.ItemMap.TryGetValue(hierarchyIndex, out dictionary))
			{
				dictionary = new Dictionary<object, UiPanelBase>();
				this.ItemMap[hierarchyIndex] = dictionary;
			}
			int i = 0;
			int num = dataList.Length;
			while (i < num)
			{
				UUIItem uuiitem2 = Singleton<LguiUtil>.Instance.CopyItem(uuiitem, this.GetRootUiItem());
				ILayoutItem<T> layoutItem = this.RefreshFunction(dataList[i], uuiitem2, i, hierarchyIndex);
				dictionary[layoutItem.Key] = layoutItem.Value;
				this.CopyListItem.Add(uuiitem2);
				i++;
			}
			uuiitem.SetUIActive(false);
		}

		// Token: 0x06032EED RID: 208621 RVA: 0x00CC2900 File Offset: 0x00CC0B00
		[return: Nullable(2)]
		public UiPanelBase GetLayoutItemByKey(object key, int hierarchyIndex = 0)
		{
			Dictionary<object, UiPanelBase> dictionary;
			if (this.ItemMap.TryGetValue(hierarchyIndex, out dictionary))
			{
				UiPanelBase result;
				dictionary.TryGetValue(key, out result);
				return result;
			}
			return null;
		}

		// Token: 0x06032EEE RID: 208622 RVA: 0x00CC292C File Offset: 0x00CC0B2C
		[return: Nullable(new byte[]
		{
			2,
			1,
			1
		})]
		public Dictionary<object, UiPanelBase> GetLayoutItemMap(int hierarchyIndex = 0)
		{
			Dictionary<object, UiPanelBase> result;
			this.ItemMap.TryGetValue(hierarchyIndex, out result);
			return result;
		}

		// Token: 0x06032EEF RID: 208623 RVA: 0x00CC294C File Offset: 0x00CC0B4C
		public void ClearChildren()
		{
			foreach (Dictionary<object, UiPanelBase> dictionary in this.ItemMap.Values)
			{
				foreach (UiPanelBase uiPanelBase in dictionary.Values)
				{
					uiPanelBase.Destroy(null);
				}
				dictionary.Clear();
			}
			this.ItemMap.Clear();
			foreach (UUIItem uuiitem in this.CopyListItem)
			{
				Singleton<ActorSystem>.Instance.Put("GenericLayoutAdd.ClearChildren", uuiitem.GetOwner(), null);
			}
			this.CopyListItem.Clear();
		}

		// Token: 0x0401DA5A RID: 121434
		[Nullable(2)]
		private readonly UUILayoutBase ProxyLayout;

		// Token: 0x0401DA5B RID: 121435
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private readonly TLayoutRefresh<T> RefreshFunction;

		// Token: 0x0401DA5C RID: 121436
		private readonly Dictionary<int, UUIItem> OriginalItemMap = new Dictionary<int, UUIItem>();

		// Token: 0x0401DA5D RID: 121437
		private readonly List<UUIItem> CopyListItem = new List<UUIItem>();

		// Token: 0x0401DA5E RID: 121438
		private readonly Dictionary<int, Dictionary<object, UiPanelBase>> ItemMap = new Dictionary<int, Dictionary<object, UiPanelBase>>();
	}
}
