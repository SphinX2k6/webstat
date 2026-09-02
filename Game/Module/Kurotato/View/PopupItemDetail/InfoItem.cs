using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Module.Util;
using UnrealEngine;

namespace CSharpScript.Game.Module.Kurotato.View.PopupItemDetail
{
	// Token: 0x02005A8F RID: 23183
	[Nullable(new byte[]
	{
		0,
		1
	})]
	internal class InfoItem : GridProxyAbstract<IInfoItemData>
	{
		// Token: 0x0603AA8F RID: 240271 RVA: 0x00EDD05C File Offset: 0x00EDB25C
		protected unsafe override void OnRegisterComponent()
		{
			int num = 2;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUISprite));
			this.ComponentRegisterInfos = list;
		}

		// Token: 0x0603AA90 RID: 240272 RVA: 0x00EDD0C8 File Offset: 0x00EDB2C8
		[NullableContext(1)]
		public override void Refresh(IInfoItemData data, bool isSelected, int gridIndex)
		{
			base.GetText(0).SetText("(" + data.Level.ToString() + ") " + data.Description, true);
			if (data.Level > data.BuildLevel)
			{
				base.GetText(0).SetColor(FColor.FromHex("#909090"));
			}
			else
			{
				base.GetText(0).SetColor(FColor.FromHex("#ffffff"));
			}
			base.GetSprite(1).SetUIActive(data.IsArrowLevel);
		}

		// Token: 0x0200BA7A RID: 47738
		private enum EInfoItemComp
		{
			// Token: 0x04039933 RID: 235827
			TextDesc,
			// Token: 0x04039934 RID: 235828
			SpriteArrow
		}
	}
}
