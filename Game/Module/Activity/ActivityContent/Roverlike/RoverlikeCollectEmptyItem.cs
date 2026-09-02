using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.Activity.ActivityContent.Roverlike
{
	// Token: 0x020063E3 RID: 25571
	[Nullable(new byte[]
	{
		0,
		1
	})]
	public class RoverlikeCollectEmptyItem : SyncGridProxyAbstract<IRoverlikeCollectEmptyData>
	{
		// Token: 0x06040370 RID: 263024 RVA: 0x010751C0 File Offset: 0x010733C0
		protected unsafe override void OnRegisterComponent()
		{
			int num = 2;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIText));
			this.ComponentRegisterInfos = list;
		}

		// Token: 0x06040371 RID: 263025 RVA: 0x0107522C File Offset: 0x0107342C
		[NullableContext(1)]
		public override void Refresh(IRoverlikeCollectEmptyData data)
		{
			UUIText text = base.GetText(1);
			if (text != null && !StringUtils.IsEmpty(data.Txt))
			{
				Singleton<LguiUtil>.Instance.SetLocalTextNew(text, data.Txt, Array.Empty<object>());
			}
		}

		// Token: 0x0200C44D RID: 50253
		private class EComponents
		{
			// Token: 0x0403C6D9 RID: 247513
			public const int PanelSelf = 0;

			// Token: 0x0403C6DA RID: 247514
			public const int TxtInfo = 1;
		}
	}
}
