using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace ActivityNamespace.MapTravel
{
	// Token: 0x020043C1 RID: 17345
	[NullableContext(1)]
	[Nullable(0)]
	public class MapTravelTabDynamicItem : UiPanelBase, IDynamicScrollBaseItem<MapTravelAreaData>
	{
		// Token: 0x0602E1CF RID: 188879 RVA: 0x00AD78D8 File Offset: 0x00AD5AD8
		public UniTask Init(UUIItem actor)
		{
			MapTravelTabDynamicItem.<Init>d__1 <Init>d__;
			<Init>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<Init>d__.<>4__this = this;
			<Init>d__.actor = actor;
			<Init>d__.<>1__state = -1;
			<Init>d__.<>t__builder.Start<MapTravelTabDynamicItem.<Init>d__1>(ref <Init>d__);
			return <Init>d__.<>t__builder.Task;
		}

		// Token: 0x0602E1D0 RID: 188880 RVA: 0x00AD7924 File Offset: 0x00AD5B24
		protected unsafe override void OnRegisterComponent()
		{
			int num = 2;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIItem));
			this.ComponentRegisterInfos = list;
		}

		// Token: 0x0602E1D1 RID: 188881 RVA: 0x00AD7990 File Offset: 0x00AD5B90
		public FVector2D GetItemSize(MapTravelAreaData itemData)
		{
			UUIItem rootItem = base.GetRootItem();
			this.VectorValue.Set((double)rootItem.GetWidth(), (double)rootItem.GetHeight());
			return this.VectorValue.ToUeVector2D(false);
		}

		// Token: 0x0602E1D2 RID: 188882 RVA: 0x00AD79C9 File Offset: 0x00AD5BC9
		public void ClearItem()
		{
		}

		// Token: 0x0401A167 RID: 106855
		private Vector2D VectorValue;

		// Token: 0x0200A627 RID: 42535
		[NullableContext(0)]
		private class EComponents
		{
			// Token: 0x0403361A RID: 210458
			public const int NormalItem = 0;

			// Token: 0x0403361B RID: 210459
			public const int LockItem = 1;
		}
	}
}
