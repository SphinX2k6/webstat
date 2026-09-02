using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Module.WorldMap.ViewComponent;
using Cysharp.Threading.Tasks;
using UnrealEngine;

namespace CSharpScript.Game.Module.WorldMap.SubViews.TrackMenu
{
	// Token: 0x02004B83 RID: 19331
	[NullableContext(1)]
	[Nullable(0)]
	public class TrackMenuPanel : WorldMapSecondaryUi
	{
		// Token: 0x060327D7 RID: 206807 RVA: 0x00CA19D8 File Offset: 0x00C9FBD8
		public override string GetResourceId()
		{
			return "UiItem_MapHandleNav";
		}

		// Token: 0x060327D8 RID: 206808 RVA: 0x00CA19E0 File Offset: 0x00C9FBE0
		protected unsafe override void OnRegisterComponent()
		{
			int num = 3;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIVerticalLayout));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIButtonComponent));
			this.ComponentRegisterInfos = list;
			num2 = 1;
			List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
			CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
			Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
			num = 0;
			*span2[num] = new ValueTuple<int, Delegate>(2, new Action(base.Close));
			this.BtnBindInfo = list2;
		}

		// Token: 0x060327D9 RID: 206809 RVA: 0x00CA1AA7 File Offset: 0x00C9FCA7
		protected override void OnStart()
		{
			UUIItem item = base.GetItem(1);
			if (item == null)
			{
				return;
			}
			item.SetUIActive(false);
		}

		// Token: 0x060327DA RID: 206810 RVA: 0x00CA1ABC File Offset: 0x00C9FCBC
		private void UpdateMenuUiItems(int count)
		{
			int count2 = this.MenuUiItems.Count;
			if (count == count2)
			{
				return;
			}
			if (count > count2)
			{
				for (int i = count2; i < count; i++)
				{
					LguiUtil instance = Singleton<LguiUtil>.Instance;
					UUIItem item = base.GetItem(1);
					UUIVerticalLayout verticalLayout = base.GetVerticalLayout(0);
					TWeakObjectPtr<UUIItem>? tweakObjectPtr = (verticalLayout != null) ? new TWeakObjectPtr<UUIItem>?(verticalLayout.RootUIComp) : null;
					UUIItem item2 = instance.CopyItem(item, (tweakObjectPtr != null) ? tweakObjectPtr.GetValueOrDefault() : null);
					this.MenuUiItems.Add(item2);
				}
				return;
			}
			for (int j = count; j < count2; j++)
			{
				this.MenuUiItems[j].SetUIActive(false);
			}
		}

		// Token: 0x060327DB RID: 206811 RVA: 0x00CA1B68 File Offset: 0x00C9FD68
		protected override void OnShowWorldMapSecondaryUi(params object[] param)
		{
			if (param.Length != 0)
			{
				ITrackMenuItemData[] array = param[0] as ITrackMenuItemData[];
				if (array != null)
				{
					this.UpdateMenuUiItems(array.Length);
					this.TrackMenuItems = new TrackMenuItem[array.Length];
					for (int i = 0; i < array.Length; i++)
					{
						ITrackMenuItemData trackData = array[i];
						TrackMenuItem trackMenuItem = new TrackMenuItem();
						this.TrackMenuItems[i] = trackMenuItem;
						trackMenuItem.Init(this.MenuUiItems[i], trackData).Forget();
					}
				}
			}
		}

		// Token: 0x060327DC RID: 206812 RVA: 0x00CA1BD8 File Offset: 0x00C9FDD8
		protected override void OnCloseWorldMapSecondaryUi()
		{
			if (this.TrackMenuItems.Length != 0)
			{
				this.MenuUiItems.RemoveRange(0, Math.Min(this.TrackMenuItems.Length, this.MenuUiItems.Count));
			}
			foreach (TrackMenuItem trackMenuItem in this.TrackMenuItems)
			{
				if (trackMenuItem != null)
				{
					trackMenuItem.Destroy(null);
				}
			}
			this.TrackMenuItems = Array.Empty<TrackMenuItem>();
		}

		// Token: 0x060327DD RID: 206813 RVA: 0x00CA1C41 File Offset: 0x00C9FE41
		protected override void OnBeforeDestroy()
		{
			this.TrackMenuItems = Array.Empty<TrackMenuItem>();
		}

		// Token: 0x060327DE RID: 206814 RVA: 0x00CA1C4E File Offset: 0x00C9FE4E
		protected override bool GetNeedBgItem()
		{
			return false;
		}

		// Token: 0x0401D73A RID: 120634
		private TrackMenuItem[] TrackMenuItems = Array.Empty<TrackMenuItem>();

		// Token: 0x0401D73B RID: 120635
		private readonly List<UUIItem> MenuUiItems = new List<UUIItem>();

		// Token: 0x0200AC53 RID: 44115
		[NullableContext(0)]
		public static class EChildType
		{
			// Token: 0x0403595C RID: 219484
			public const int VerticalLayout = 0;

			// Token: 0x0403595D RID: 219485
			public const int ItemRoot = 1;

			// Token: 0x0403595E RID: 219486
			public const int BtnMask = 2;
		}
	}
}
