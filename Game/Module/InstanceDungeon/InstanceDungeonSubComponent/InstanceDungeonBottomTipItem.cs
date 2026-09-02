using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Module.Util;
using UnrealEngine;

namespace CSharpScript.Game.Module.InstanceDungeon.InstanceDungeonSubComponent
{
	// Token: 0x02005BE0 RID: 23520
	[Nullable(new byte[]
	{
		0,
		1
	})]
	public class InstanceDungeonBottomTipItem : GridProxyAbstract<InstanceDungeonBottomTipItemData>
	{
		// Token: 0x0603B8BC RID: 243900 RVA: 0x00F180B8 File Offset: 0x00F162B8
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

		// Token: 0x0603B8BD RID: 243901 RVA: 0x00F18100 File Offset: 0x00F16300
		[NullableContext(1)]
		public override void Refresh(InstanceDungeonBottomTipItemData data, bool isSelected, int gridIndex)
		{
			string textId = data.TextId;
			string[] textArgs = data.TextArgs;
			if (textArgs != null)
			{
				Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(0), textId, textArgs);
				return;
			}
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(0), textId, Array.Empty<object>());
		}

		// Token: 0x0200BC49 RID: 48201
		private enum EComponent
		{
			// Token: 0x0403A11F RID: 237855
			DescText
		}
	}
}
