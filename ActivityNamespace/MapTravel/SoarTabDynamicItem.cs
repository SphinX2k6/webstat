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
	// Token: 0x020043C2 RID: 17346
	[NullableContext(1)]
	[Nullable(0)]
	public class SoarTabDynamicItem : UiPanelBase, IDynamicScrollBaseItem<SoarChallengePlayData>
	{
		// Token: 0x0602E1D4 RID: 188884 RVA: 0x00AD79D4 File Offset: 0x00AD5BD4
		public UniTask Init(UUIItem actor)
		{
			SoarTabDynamicItem.<Init>d__1 <Init>d__;
			<Init>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<Init>d__.<>4__this = this;
			<Init>d__.actor = actor;
			<Init>d__.<>1__state = -1;
			<Init>d__.<>t__builder.Start<SoarTabDynamicItem.<Init>d__1>(ref <Init>d__);
			return <Init>d__.<>t__builder.Task;
		}

		// Token: 0x0602E1D5 RID: 188885 RVA: 0x00AD7A20 File Offset: 0x00AD5C20
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

		// Token: 0x0602E1D6 RID: 188886 RVA: 0x00AD7A8C File Offset: 0x00AD5C8C
		public FVector2D GetItemSize(SoarChallengePlayData itemData)
		{
			UUIItem rootItem = base.GetRootItem();
			this.VectorValue.Set((double)rootItem.GetWidth(), (double)rootItem.GetHeight());
			return this.VectorValue.ToUeVector2D(false);
		}

		// Token: 0x0602E1D7 RID: 188887 RVA: 0x00AD7AC5 File Offset: 0x00AD5CC5
		public void ClearItem()
		{
		}

		// Token: 0x0401A168 RID: 106856
		private Vector2D VectorValue;

		// Token: 0x0200A629 RID: 42537
		[NullableContext(0)]
		private class EComponents
		{
			// Token: 0x04033621 RID: 210465
			public const int NormalItem = 0;

			// Token: 0x04033622 RID: 210466
			public const int LockItem = 1;
		}
	}
}
