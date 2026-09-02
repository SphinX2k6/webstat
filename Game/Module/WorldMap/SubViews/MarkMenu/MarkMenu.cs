using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Module.Map.Marks.MarkItem;
using CSharpScript.Game.Module.WorldMap.ViewComponent;
using Cysharp.Threading.Tasks;
using UnrealEngine;

namespace CSharpScript.Game.Module.WorldMap.SubViews.MarkMenu
{
	// Token: 0x02004B99 RID: 19353
	[NullableContext(1)]
	[Nullable(0)]
	public class MarkMenu : WorldMapSecondaryUi
	{
		// Token: 0x06032891 RID: 206993 RVA: 0x00CA69DF File Offset: 0x00CA4BDF
		public override string GetResourceId()
		{
			return "UiItem_MarkList_Prefab";
		}

		// Token: 0x06032892 RID: 206994 RVA: 0x00CA69E8 File Offset: 0x00CA4BE8
		protected unsafe override void OnRegisterComponent()
		{
			int num = 4;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIButtonComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIButtonComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIItem));
			this.ComponentRegisterInfos = list;
			num2 = 1;
			List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
			CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
			Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
			num = 0;
			*span2[num] = new ValueTuple<int, Delegate>(0, new Action(base.Close));
			this.BtnBindInfo = list2;
		}

		// Token: 0x06032893 RID: 206995 RVA: 0x00CA6AD0 File Offset: 0x00CA4CD0
		protected override void OnStart()
		{
			UUIItem item = base.GetItem(3);
			if (item == null)
			{
				return;
			}
			item.SetUIActive(false);
		}

		// Token: 0x06032894 RID: 206996 RVA: 0x00CA6AE4 File Offset: 0x00CA4CE4
		private List<UUIItem> GetOrAddUsedItems(int count)
		{
			this.UsedUiItems.Clear();
			int num = count - this.MenuUiItems.Count;
			for (int i = 0; i < num; i++)
			{
				UUIItem item = Singleton<LguiUtil>.Instance.CopyItem(base.GetItem(3), base.GetItem(2));
				this.MenuUiItems.Add(item);
			}
			for (int j = 0; j < this.MenuUiItems.Count; j++)
			{
				bool flag = j < count;
				if (flag)
				{
					this.UsedUiItems.Add(this.MenuUiItems[j]);
				}
				this.MenuUiItems[j].SetUIActive(flag);
			}
			return this.UsedUiItems;
		}

		// Token: 0x06032895 RID: 206997 RVA: 0x00CA6B8C File Offset: 0x00CA4D8C
		protected override void OnShowWorldMapSecondaryUi(params object[] param)
		{
			if (param.Length != 0)
			{
				List<MarkItem> list = param[0] as List<MarkItem>;
				this.UsedUiItems = this.GetOrAddUsedItems(list.Count);
				this.MarkMenuItems = new List<MarkMenuItem>(list.Count);
				int num = 0;
				using (List<MarkItem>.Enumerator enumerator = list.GetEnumerator())
				{
					while (enumerator.MoveNext())
					{
						MarkMenu.<>c__DisplayClass8_0 CS$<>8__locals1 = new MarkMenu.<>c__DisplayClass8_0();
						CS$<>8__locals1.<>4__this = this;
						CS$<>8__locals1.markItem = enumerator.Current;
						MarkMenu.<>c__DisplayClass8_1 CS$<>8__locals2 = new MarkMenu.<>c__DisplayClass8_1();
						CS$<>8__locals2.CS$<>8__locals1 = CS$<>8__locals1;
						CS$<>8__locals2.markMenuItem = new MarkMenuItem();
						UUIItem uiItem = this.UsedUiItems[num++];
						CS$<>8__locals2.markMenuItem.Init(uiItem, CS$<>8__locals2.CS$<>8__locals1.markItem).ContinueWith(new Action(CS$<>8__locals2.<OnShowWorldMapSecondaryUi>g__OnCreateDone|0));
					}
				}
			}
		}

		// Token: 0x06032896 RID: 206998 RVA: 0x00CA6C74 File Offset: 0x00CA4E74
		protected override void OnCloseWorldMapSecondaryUi()
		{
			if (this.MarkMenuItems == null || this.MarkMenuItems.Count == 0)
			{
				return;
			}
			foreach (MarkMenuItem markMenuItem in this.MarkMenuItems)
			{
				UUIItem rootItem = markMenuItem.GetRootItem();
				if (rootItem != null)
				{
					this.MenuUiItems.Remove(rootItem);
				}
				markMenuItem.Destroy(null);
			}
		}

		// Token: 0x06032897 RID: 206999 RVA: 0x00CA6CF4 File Offset: 0x00CA4EF4
		protected override void OnBeforeDestroy()
		{
			this.MarkMenuItems = null;
			this.MenuUiItems.Clear();
			this.UsedUiItems.Clear();
		}

		// Token: 0x06032898 RID: 207000 RVA: 0x00CA6D13 File Offset: 0x00CA4F13
		protected override bool GetNeedBgItem()
		{
			return false;
		}

		// Token: 0x0401D77C RID: 120700
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private List<MarkMenuItem> MarkMenuItems;

		// Token: 0x0401D77D RID: 120701
		private List<UUIItem> MenuUiItems = new List<UUIItem>();

		// Token: 0x0401D77E RID: 120702
		private List<UUIItem> UsedUiItems = new List<UUIItem>();

		// Token: 0x0200AC70 RID: 44144
		[NullableContext(0)]
		public static class EComponents
		{
			// Token: 0x040359B3 RID: 219571
			public const int Modal = 0;

			// Token: 0x040359B4 RID: 219572
			public const int ScrollView = 1;

			// Token: 0x040359B5 RID: 219573
			public const int MenuItemRoot = 2;

			// Token: 0x040359B6 RID: 219574
			public const int MenuItem = 3;
		}
	}
}
