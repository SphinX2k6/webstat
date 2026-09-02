using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Ui;
using UnrealEngine;

namespace CSharpScript.Game.Module.InstanceDungeon.InstanceDungeonSubComponent
{
	// Token: 0x02005BFA RID: 23546
	public class InstanceDungeonTitleWidelyItem : UiPanelBase
	{
		// Token: 0x0603B951 RID: 244049 RVA: 0x00F1AD74 File Offset: 0x00F18F74
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

		// Token: 0x0603B952 RID: 244050 RVA: 0x00F1ADBC File Offset: 0x00F18FBC
		[NullableContext(2)]
		public void RefreshItem(string titleTextId)
		{
			Singleton<LguiUtil>.Instance.TrySetLocalTextNew(base.GetText(0), titleTextId, Array.Empty<object>());
		}

		// Token: 0x0200BC70 RID: 48240
		private enum EComponent
		{
			// Token: 0x0403A1A8 RID: 237992
			TitleText
		}
	}
}
