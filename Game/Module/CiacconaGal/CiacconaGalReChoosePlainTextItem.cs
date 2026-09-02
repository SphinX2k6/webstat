using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Ui;
using UnrealEngine;

namespace CSharpScript.Game.Module.CiacconaGal
{
	// Token: 0x02005EC0 RID: 24256
	public class CiacconaGalReChoosePlainTextItem : UiPanelBase
	{
		// Token: 0x0603CF76 RID: 249718 RVA: 0x00F7BDF0 File Offset: 0x00F79FF0
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

		// Token: 0x0603CF77 RID: 249719 RVA: 0x00F7BE38 File Offset: 0x00F7A038
		[NullableContext(1)]
		public void Refresh(string text)
		{
			if (StringUtils.IsEmpty(text))
			{
				return;
			}
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(0), text, Array.Empty<object>());
		}

		// Token: 0x0200BEB6 RID: 48822
		public class EPlainTextComponentDefine
		{
			// Token: 0x0403AB46 RID: 240454
			public const int Text = 0;
		}
	}
}
