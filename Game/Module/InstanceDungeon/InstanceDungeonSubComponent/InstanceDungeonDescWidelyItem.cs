using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Ui;
using UnrealEngine;

namespace CSharpScript.Game.Module.InstanceDungeon.InstanceDungeonSubComponent
{
	// Token: 0x02005BE5 RID: 23525
	public class InstanceDungeonDescWidelyItem : UiPanelBase
	{
		// Token: 0x0603B8D4 RID: 243924 RVA: 0x00F18608 File Offset: 0x00F16808
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

		// Token: 0x0603B8D5 RID: 243925 RVA: 0x00F18650 File Offset: 0x00F16850
		[NullableContext(2)]
		public void RefreshItem(string descTextId)
		{
			Singleton<LguiUtil>.Instance.TrySetLocalTextNew(base.GetText(0), descTextId, Array.Empty<object>());
		}

		// Token: 0x0200BC4D RID: 48205
		private enum EComponent
		{
			// Token: 0x0403A12D RID: 237869
			ContentText
		}
	}
}
