using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Ui;
using UnrealEngine;

namespace CSharpScript.Game.Module.Activity.ActivityContent.Roverlike
{
	// Token: 0x02006467 RID: 25703
	public class RoverlikeTalentTreeLevelDescItem : UiPanelBase
	{
		// Token: 0x0604079C RID: 264092 RVA: 0x010855A4 File Offset: 0x010837A4
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

		// Token: 0x0604079D RID: 264093 RVA: 0x0108560D File Offset: 0x0108380D
		[NullableContext(1)]
		public void SetContent(int level, string descTextId, IReadOnlyList<string> descParams)
		{
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(0), descTextId, descParams.ToArray<string>());
		}

		// Token: 0x0604079E RID: 264094 RVA: 0x01085627 File Offset: 0x01083827
		[NullableContext(1)]
		public void SetTitle(string titleTextId)
		{
			Singleton<LguiUtil>.Instance.TrySetLocalTextNew(base.GetText(1), titleTextId, Array.Empty<object>());
		}

		// Token: 0x0200C4BC RID: 50364
		private class ELevelDescDefine
		{
			// Token: 0x0403C8E0 RID: 248032
			public const int TxtDetail = 0;

			// Token: 0x0403C8E1 RID: 248033
			public const int TxtTitle = 1;
		}
	}
}
