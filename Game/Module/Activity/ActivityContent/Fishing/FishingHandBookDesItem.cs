using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Module.Util;
using UnrealEngine;

namespace CSharpScript.Game.Module.Activity.ActivityContent.Fishing
{
	// Token: 0x02006818 RID: 26648
	[Nullable(new byte[]
	{
		0,
		1
	})]
	public class FishingHandBookDesItem : GridProxyAbstract<IFishingHandBookDesData>
	{
		// Token: 0x060426B4 RID: 272052 RVA: 0x01107234 File Offset: 0x01105434
		protected unsafe override void OnRegisterComponent()
		{
			int num = 4;
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
			*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIItem));
			this.ComponentRegisterInfos = list;
		}

		// Token: 0x060426B5 RID: 272053 RVA: 0x011072E0 File Offset: 0x011054E0
		[NullableContext(1)]
		public override void Refresh(IFishingHandBookDesData data, bool isSelected, int gridIndex)
		{
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(0), data.DesText, Array.Empty<object>());
			base.GetText(1).SetText(data.DataText, true);
			base.GetItem(2).SetUIActive(data.IsGolden.GetValueOrDefault());
			base.GetItem(3).SetUIActive(data.IsSliver.GetValueOrDefault());
		}

		// Token: 0x0200C84D RID: 51277
		private class EComponentDefine
		{
			// Token: 0x0403DA3C RID: 252476
			public const int DesText = 0;

			// Token: 0x0403DA3D RID: 252477
			public const int DataText = 1;

			// Token: 0x0403DA3E RID: 252478
			public const int GoldenItem = 2;

			// Token: 0x0403DA3F RID: 252479
			public const int SilverItem = 3;
		}
	}
}
