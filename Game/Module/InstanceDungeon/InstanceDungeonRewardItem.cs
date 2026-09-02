using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Module.Inventory;
using CSharpScript.Game.Module.Util;
using UnrealEngine;

namespace CSharpScript.Game.Module.InstanceDungeon
{
	// Token: 0x02005BC9 RID: 23497
	public class InstanceDungeonRewardItem : GridProxyAbstract<ValueTuple<int, int>>
	{
		// Token: 0x0603B7F5 RID: 243701 RVA: 0x00F154F8 File Offset: 0x00F136F8
		protected unsafe override void OnRegisterComponent()
		{
			int num = 3;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIGridLayout));
			this.ComponentRegisterInfos = list;
		}

		// Token: 0x0603B7F6 RID: 243702 RVA: 0x00F15582 File Offset: 0x00F13782
		protected override void OnStart()
		{
			this.Layout = new GenericLayout<CommonItemSmallItemGrid, TItem>(base.GetGridLayout(2), new Func<CommonItemSmallItemGrid>(this.OnRewardLayoutUpdater), null, false, true);
		}

		// Token: 0x0603B7F7 RID: 243703 RVA: 0x00F155A5 File Offset: 0x00F137A5
		[NullableContext(1)]
		private CommonItemSmallItemGrid OnRewardLayoutUpdater()
		{
			return new CommonItemSmallItemGrid();
		}

		// Token: 0x0603B7F8 RID: 243704 RVA: 0x00F155AC File Offset: 0x00F137AC
		public override void Refresh(ValueTuple<int, int> data, bool isSelected, int gridIndex)
		{
			Dictionary<int, int> dropShowInfo = ConfigBase<AdventureGuideConfig>.Instance.GetDropShowInfo(data.Item2);
			List<TItem> list = new List<TItem>();
			foreach (KeyValuePair<int, int> keyValuePair in dropShowInfo)
			{
				TItem item = new TItem
				{
					ItemData = new InventoryDefine.GetItemData(keyValuePair.Key, 0),
					Count = keyValuePair.Value
				};
				list.Add(item);
			}
			this.Layout.RefreshByData(list, null, false);
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(0), "InstanceRewardDes", new <>z__ReadOnlySingleElementList<object>(data.Item1));
			this.SelfLevel = data.Item1;
		}

		// Token: 0x0603B7F9 RID: 243705 RVA: 0x00F1567C File Offset: 0x00F1387C
		public void SetCurrentItem(int currentItemLevel)
		{
			UUIItem item = base.GetItem(1);
			if (item == null)
			{
				return;
			}
			item.SetUIActive(this.SelfLevel == currentItemLevel);
		}

		// Token: 0x04021832 RID: 137266
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private GenericLayout<CommonItemSmallItemGrid, TItem> Layout;

		// Token: 0x04021833 RID: 137267
		private int SelfLevel = -1;

		// Token: 0x0200BC33 RID: 48179
		private static class EChildType
		{
			// Token: 0x0403A0CD RID: 237773
			public const int TitleText = 0;

			// Token: 0x0403A0CE RID: 237774
			public const int CurrentItem = 1;

			// Token: 0x0403A0CF RID: 237775
			public const int RewardLayout = 2;
		}
	}
}
