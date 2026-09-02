using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using CSharpScript.Game.Module.Common;
using UnrealEngine;

namespace CSharpScript.Game.Module.Manufacture.Forging.View
{
	// Token: 0x020059AB RID: 22955
	public class AttributeItemInternal : AttributeItem
	{
		// Token: 0x0603A1C1 RID: 238017 RVA: 0x00EB4E34 File Offset: 0x00EB3034
		protected unsafe override void OnRegisterComponent()
		{
			int num = 5;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(4, typeof(UUITexture));
			this.ComponentRegisterInfos = list;
		}

		// Token: 0x0603A1C2 RID: 238018 RVA: 0x00EB4F00 File Offset: 0x00EB3100
		public void SetBgActive()
		{
		}

		// Token: 0x0200B965 RID: 47461
		public class EAttributeItemInternalDefine
		{
			// Token: 0x0403942C RID: 234540
			public const int Name = 0;

			// Token: 0x0403942D RID: 234541
			public const int CurrentValue = 1;

			// Token: 0x0403942E RID: 234542
			public const int NextItem = 2;

			// Token: 0x0403942F RID: 234543
			public const int NextValue = 3;

			// Token: 0x04039430 RID: 234544
			public const int Icon = 4;
		}
	}
}
