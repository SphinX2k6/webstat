using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.Infrastructure
{
	// Token: 0x02005C65 RID: 23653
	public class InfrMaterialsDeliveryLockItem : InfrMaterialsDeliveryLockItemBase
	{
		// Token: 0x0603BC36 RID: 244790 RVA: 0x00F256BC File Offset: 0x00F238BC
		protected unsafe override void OnRegisterComponent()
		{
			int num = 3;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUISprite));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIButtonComponent));
			this.ComponentRegisterInfos = list;
			num2 = 1;
			List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
			CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
			Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
			num = 0;
			*span2[num] = new ValueTuple<int, Delegate>(2, new Action(this.OnClickFunction));
			this.BtnBindInfo = list2;
		}

		// Token: 0x0603BC37 RID: 244791 RVA: 0x00F25783 File Offset: 0x00F23983
		[NullableContext(1)]
		public void SetOnClickFunction(Action cb)
		{
			this.OnClickFunctionCb = cb;
		}

		// Token: 0x0603BC38 RID: 244792 RVA: 0x00F2578C File Offset: 0x00F2398C
		private void OnClickFunction()
		{
			Action onClickFunctionCb = this.OnClickFunctionCb;
			if (onClickFunctionCb == null)
			{
				return;
			}
			onClickFunctionCb();
		}

		// Token: 0x04021962 RID: 137570
		[Nullable(1)]
		private Action OnClickFunctionCb;

		// Token: 0x0200BCFC RID: 48380
		private class EChildType
		{
			// Token: 0x0403A3C1 RID: 238529
			public const int LockSprite = 0;

			// Token: 0x0403A3C2 RID: 238530
			public const int LockDescriptionText = 1;

			// Token: 0x0403A3C3 RID: 238531
			public const int FunctionButton = 2;
		}
	}
}
