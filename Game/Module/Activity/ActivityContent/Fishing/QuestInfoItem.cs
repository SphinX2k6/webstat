using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Module.Util;
using UnrealEngine;

namespace CSharpScript.Game.Module.Activity.ActivityContent.Fishing
{
	// Token: 0x020067CC RID: 26572
	[Nullable(new byte[]
	{
		0,
		1
	})]
	public class QuestInfoItem : GridProxyAbstract<IFishingDockQuestChildItemData>
	{
		// Token: 0x060424A7 RID: 271527 RVA: 0x01100EF8 File Offset: 0x010FF0F8
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

		// Token: 0x060424A8 RID: 271528 RVA: 0x01100F64 File Offset: 0x010FF164
		[NullableContext(1)]
		public override void Refresh(IFishingDockQuestChildItemData data, bool isSelected, int gridIndex)
		{
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(0), data.DesText, new <>z__ReadOnlySingleElementList<object>(data.MaxCount));
			UUIText text = base.GetText(1);
			bool flag = data.CurrentCount >= data.MaxCount;
			UUIText uuitext = text;
			DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(3, 2);
			defaultInterpolatedStringHandler.AppendLiteral("(");
			defaultInterpolatedStringHandler.AppendFormatted<int>(Math.Min(data.CurrentCount, data.MaxCount));
			defaultInterpolatedStringHandler.AppendLiteral("/");
			defaultInterpolatedStringHandler.AppendFormatted<int>(data.MaxCount);
			defaultInterpolatedStringHandler.AppendLiteral(")");
			uuitext.SetText(defaultInterpolatedStringHandler.ToStringAndClear(), true);
			UUIItem uuiitem = text;
			bool bUseChangeColor = flag;
			FColor? fcolor = new FColor?(text.changeColor);
			uuiitem.SetChangeColor(bUseChangeColor, fcolor);
		}

		// Token: 0x0200C813 RID: 51219
		private class EListComponent
		{
			// Token: 0x0403D92C RID: 252204
			public const int TxtInfo = 0;

			// Token: 0x0403D92D RID: 252205
			public const int TxtCount = 1;
		}
	}
}
