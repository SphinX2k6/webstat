using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Module.Util;
using UnrealEngine;

namespace CSharpScript.Game.Module.Activity.ActivityContent.Roverlike
{
	// Token: 0x0200643E RID: 25662
	[NullableContext(1)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	public class RoverlikeRoleSelectInfoItem : GridProxyAbstract<RoverlikeRoleSelectInfoItemData>
	{
		// Token: 0x060406C6 RID: 263878 RVA: 0x01083F20 File Offset: 0x01082120
		protected unsafe override void OnRegisterComponent()
		{
			int num = 2;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIText));
			this.ComponentRegisterInfos = list;
		}

		// Token: 0x060406C7 RID: 263879 RVA: 0x01083F8C File Offset: 0x0108218C
		public override void Refresh(RoverlikeRoleSelectInfoItemData data, bool isSelected, int gridIndex)
		{
			UUIText text = base.GetText(0);
			if (text != null)
			{
				Singleton<LguiUtil>.Instance.SetLocalTextNew(text, data.TitleTextId, Array.Empty<object>());
			}
			UUIText text2 = base.GetText(1);
			if (text2 != null)
			{
				Singleton<LguiUtil>.Instance.SetLocalTextNew(text2, data.DescTextId, Array.Empty<object>());
			}
		}

		// Token: 0x060406C8 RID: 263880 RVA: 0x01083FDB File Offset: 0x010821DB
		public override object GetKey(RoverlikeRoleSelectInfoItemData data, int gridIndex)
		{
			return gridIndex;
		}

		// Token: 0x0200C4B3 RID: 50355
		[NullableContext(0)]
		private class EComponents
		{
			// Token: 0x0403C8B0 RID: 247984
			public const int TxtInfoTitle = 0;

			// Token: 0x0403C8B1 RID: 247985
			public const int TxtInfoDescription = 1;
		}
	}
}
