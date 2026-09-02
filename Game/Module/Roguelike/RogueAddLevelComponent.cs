using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.Roguelike
{
	// Token: 0x02005195 RID: 20885
	public class RogueAddLevelComponent : MediumItemGridComponent
	{
		// Token: 0x06035B94 RID: 220052 RVA: 0x00D80788 File Offset: 0x00D7E988
		protected unsafe override void OnRegisterComponent()
		{
			int num = 2;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUITexture));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIText));
			this.ComponentRegisterInfos = list;
		}

		// Token: 0x06035B95 RID: 220053 RVA: 0x00D807F1 File Offset: 0x00D7E9F1
		[NullableContext(1)]
		protected override string GetResourceId()
		{
			return "UiItem_ItemRogueRoleType";
		}

		// Token: 0x06035B96 RID: 220054 RVA: 0x00D807F8 File Offset: 0x00D7E9F8
		[NullableContext(2)]
		protected override void OnRefresh(object @params = null)
		{
			int num2;
			if (@params is int)
			{
				int num = (int)@params;
				num2 = num;
			}
			else
			{
				num2 = 0;
			}
			int num3 = num2;
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(1), "Text_LevelShow_Text", new <>z__ReadOnlySingleElementList<object>(num3));
		}
	}
}
