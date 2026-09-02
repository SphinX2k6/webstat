using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.Activity.ActivityContent.Roverlike
{
	// Token: 0x020063E5 RID: 25573
	[Nullable(new byte[]
	{
		0,
		1
	})]
	public class RoverlikeCollectTitleItem : SyncGridProxyAbstract<IRoverlikeCollectTitleData>
	{
		// Token: 0x0604037A RID: 263034 RVA: 0x010752A4 File Offset: 0x010734A4
		protected unsafe override void OnRegisterComponent()
		{
			int num = 1;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int index = 0;
			*span[index] = new ValueTuple<int, Type>(0, typeof(UUIText));
			this.ComponentRegisterInfos = list;
		}

		// Token: 0x0604037B RID: 263035 RVA: 0x010752EC File Offset: 0x010734EC
		[NullableContext(1)]
		public override void Refresh(IRoverlikeCollectTitleData data)
		{
			if (!StringUtils.IsEmpty(data.TitleKey))
			{
				Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(0), data.TitleKey, Array.Empty<object>());
			}
		}

		// Token: 0x0200C44E RID: 50254
		private enum EComponents
		{
			// Token: 0x0403C6DC RID: 247516
			TxtName
		}
	}
}
