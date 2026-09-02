using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Module.Util;
using UnrealEngine;

namespace CSharpScript.Game.Module.BattleUi.Views
{
	// Token: 0x0200607A RID: 24698
	[Nullable(new byte[]
	{
		0,
		1
	})]
	public class BattleUiDescInfoItem : GridProxyAbstract<IBattleUiHoverTipsDescInfoC>
	{
		// Token: 0x0603E479 RID: 255097 RVA: 0x00FE6940 File Offset: 0x00FE4B40
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

		// Token: 0x0603E47A RID: 255098 RVA: 0x00FE69AC File Offset: 0x00FE4BAC
		[NullableContext(1)]
		public override void Refresh(IBattleUiHoverTipsDescInfoC data, bool isSelected, int gridIndex)
		{
			UUIText text = base.GetText(1);
			UUIText text2 = base.GetText(0);
			Singleton<LguiUtil>.Instance.SetLocalTextNew(text, data.DescKey, Array.Empty<object>());
			if (text2 != null)
			{
				text2.SetUIActive(!string.IsNullOrEmpty(data.TitleKey));
			}
			if (!string.IsNullOrEmpty(data.TitleKey))
			{
				Singleton<LguiUtil>.Instance.SetLocalTextNew(text2, data.TitleKey, Array.Empty<object>());
			}
		}

		// Token: 0x0200C14B RID: 49483
		private enum EDescChildType
		{
			// Token: 0x0403B862 RID: 243810
			TxtTitle,
			// Token: 0x0403B863 RID: 243811
			TxtDesc
		}
	}
}
