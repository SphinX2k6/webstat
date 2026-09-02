using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Module.Util;
using UnrealEngine;

namespace CSharpScript.Game.Module.Kurotato.View.KurotatoLevelSelect
{
	// Token: 0x02005AB1 RID: 23217
	[Nullable(new byte[]
	{
		0,
		1
	})]
	public class KurotatoLevelTargetItem : GridProxyAbstract<KurotatoLevelTargetItemData>
	{
		// Token: 0x0603AB7A RID: 240506 RVA: 0x00EE2A3C File Offset: 0x00EE0C3C
		protected unsafe override void OnRegisterComponent()
		{
			int num = 3;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIItem));
			this.ComponentRegisterInfos = list;
		}

		// Token: 0x0603AB7B RID: 240507 RVA: 0x00EE2AC8 File Offset: 0x00EE0CC8
		[NullableContext(1)]
		public override void Refresh(KurotatoLevelTargetItemData data, bool isSelected, int gridIndex)
		{
			UUIText text = base.GetText(0);
			Singleton<LguiUtil>.Instance.SetLocalTextNew(text, data.Text, Array.Empty<object>());
			if (text != null)
			{
				UUIItem uuiitem = text;
				bool isFinish = data.IsFinish;
				FColor? fcolor = new FColor?(text.changeColor);
				uuiitem.SetChangeColor(isFinish, fcolor);
			}
			UUIItem item = base.GetItem(1);
			if (item != null)
			{
				item.SetUIActive(!data.IsEndless && data.IsFinish);
			}
			UUIItem item2 = base.GetItem(2);
			if (item2 == null)
			{
				return;
			}
			item2.SetUIActive(!data.IsEndless && !data.IsFinish);
		}

		// Token: 0x0200BAB8 RID: 47800
		private enum EComponent
		{
			// Token: 0x04039A45 RID: 236101
			TextDesc,
			// Token: 0x04039A46 RID: 236102
			ItemFinishIcon,
			// Token: 0x04039A47 RID: 236103
			ItemUnFinishIcon
		}
	}
}
