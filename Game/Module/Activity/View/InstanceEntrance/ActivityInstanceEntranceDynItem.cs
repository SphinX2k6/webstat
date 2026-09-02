using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.Activity.View.InstanceEntrance
{
	// Token: 0x020061E9 RID: 25065
	public class ActivityInstanceEntranceDynItem : UiPanelBase, IDynamicScrollBaseItem<ActivityEntranceItemData>
	{
		// Token: 0x0603F3E4 RID: 259044 RVA: 0x0103B120 File Offset: 0x01039320
		[NullableContext(1)]
		public UniTask Init(UUIItem actor)
		{
			ActivityInstanceEntranceDynItem.<Init>d__1 <Init>d__;
			<Init>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<Init>d__.<>4__this = this;
			<Init>d__.actor = actor;
			<Init>d__.<>1__state = -1;
			<Init>d__.<>t__builder.Start<ActivityInstanceEntranceDynItem.<Init>d__1>(ref <Init>d__);
			return <Init>d__.<>t__builder.Task;
		}

		// Token: 0x0603F3E5 RID: 259045 RVA: 0x0103B16C File Offset: 0x0103936C
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

		// Token: 0x0603F3E6 RID: 259046 RVA: 0x0103B1D8 File Offset: 0x010393D8
		[NullableContext(1)]
		public FVector2D GetItemSize(ActivityEntranceItemData data)
		{
			if (data.GetStyle() == 0)
			{
				UUIItem item = base.GetItem(0);
				return new FVector2D(item.GetWidth(), item.GetHeight());
			}
			UUIItem item2 = base.GetItem(1);
			return new FVector2D(item2.GetWidth(), item2.GetHeight());
		}

		// Token: 0x0603F3E7 RID: 259047 RVA: 0x0103B220 File Offset: 0x01039420
		public void ClearItem()
		{
		}

		// Token: 0x0200C324 RID: 49956
		private class EComponent
		{
			// Token: 0x0403C24B RID: 246347
			public const int InstanceSeriesItem = 0;

			// Token: 0x0403C24C RID: 246348
			public const int InstanceItem = 1;

			// Token: 0x0403C24D RID: 246349
			public const int LockInstanceSeriesItem = 2;

			// Token: 0x0403C24E RID: 246350
			public const int LockInstanceItem = 3;
		}
	}
}
