using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Ui;
using UnrealEngine;

namespace CSharpScript.Game.Module.HonamiStory
{
	// Token: 0x02005C9B RID: 23707
	internal class SuccessDescriptionItem : UiPanelBase
	{
		// Token: 0x0603BD9D RID: 245149 RVA: 0x00F2B7F8 File Offset: 0x00F299F8
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

		// Token: 0x0603BD9E RID: 245150 RVA: 0x00F2B840 File Offset: 0x00F29A40
		[NullableContext(1)]
		public void SetDescriptionText(string desc, string[] param)
		{
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(0), desc, param);
		}
	}
}
