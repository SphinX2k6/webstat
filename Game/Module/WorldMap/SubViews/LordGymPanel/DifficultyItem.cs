using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Module.Util;
using UnrealEngine;

namespace CSharpScript.Game.Module.WorldMap.SubViews.LordGymPanel
{
	// Token: 0x02004BA9 RID: 19369
	[NullableContext(1)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	public class DifficultyItem : GridProxyAbstract<IDifficultyItemData>
	{
		// Token: 0x06032906 RID: 207110 RVA: 0x00CA87D8 File Offset: 0x00CA69D8
		protected unsafe override void OnRegisterComponent()
		{
			int num = 6;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUITexture));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIHorizontalLayout));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(5, typeof(UUIItem));
			this.ComponentRegisterInfos = list;
		}

		// Token: 0x06032907 RID: 207111 RVA: 0x00CA88C8 File Offset: 0x00CA6AC8
		protected override void OnStart()
		{
			UUIItem item = base.GetItem(2);
			if (item != null)
			{
				item.SetUIActive(false);
			}
			UUILayoutBase horizontalLayout = base.GetHorizontalLayout(4);
			Func<LordGymDifficultyStateItem> gridProxyCreateFunction = new Func<LordGymDifficultyStateItem>(this.CreateStateItem);
			UUIItem item2 = base.GetItem(5);
			this.StateLayout = new GenericLayout<LordGymDifficultyStateItem, ELordGymDifficultyState>(horizontalLayout, gridProxyCreateFunction, ((item2 != null) ? item2.GetOwner() : null) as AUIBaseActor, false, true);
		}

		// Token: 0x06032908 RID: 207112 RVA: 0x00CA8920 File Offset: 0x00CA6B20
		private LordGymDifficultyStateItem CreateStateItem()
		{
			return new LordGymDifficultyStateItem();
		}

		// Token: 0x06032909 RID: 207113 RVA: 0x00CA8928 File Offset: 0x00CA6B28
		public override void Refresh(IDifficultyItemData data, bool isSelected, int gridIndex)
		{
			if (data.NameTextArg != null)
			{
				Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(0), data.NameTextId, data.NameTextArg);
			}
			else
			{
				Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(0), data.NameTextId, Array.Empty<object>());
			}
			GenericLayout<LordGymDifficultyStateItem, ELordGymDifficultyState> stateLayout = this.StateLayout;
			if (stateLayout == null)
			{
				return;
			}
			stateLayout.RefreshByData(data.StateList, null, false);
		}

		// Token: 0x0603290A RID: 207114 RVA: 0x00CA8990 File Offset: 0x00CA6B90
		public override object GetKey(IDifficultyItemData data, int gridIndex)
		{
			return base.GridIndex;
		}

		// Token: 0x0401D7A8 RID: 120744
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private GenericLayout<LordGymDifficultyStateItem, ELordGymDifficultyState> StateLayout;
	}
}
