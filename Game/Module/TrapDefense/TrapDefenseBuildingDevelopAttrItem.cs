using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Module.Util;
using UnrealEngine;

namespace CSharpScript.Game.Module.TrapDefense
{
	// Token: 0x02004E16 RID: 19990
	[NullableContext(1)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	public class TrapDefenseBuildingDevelopAttrItem : GridProxyAbstract<ITrapDefenseBuildingDevelopAttrInfo>
	{
		// Token: 0x06033B20 RID: 211744 RVA: 0x00CEB418 File Offset: 0x00CE9618
		protected unsafe override void OnRegisterComponent()
		{
			int num = 3;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUITexture));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIText));
			this.ComponentRegisterInfos = list;
		}

		// Token: 0x06033B21 RID: 211745 RVA: 0x00CEB4A4 File Offset: 0x00CE96A4
		public override void Refresh(ITrapDefenseBuildingDevelopAttrInfo data, bool isSelected, int gridIndex)
		{
			this.Data = data;
			base.SetTextureByPath(data.Icon, base.GetTexture(0), null, null);
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(1), data.Name, Array.Empty<object>());
			if (data.MultiTxt.GetValueOrDefault())
			{
				Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(2), data.Value, Array.Empty<object>());
				return;
			}
			UUIText text = base.GetText(2);
			if (text == null)
			{
				return;
			}
			text.SetText(data.Value.ToString(), true);
		}

		// Token: 0x0401DEF9 RID: 122617
		protected ITrapDefenseBuildingDevelopAttrInfo Data;

		// Token: 0x0200AD92 RID: 44434
		[NullableContext(0)]
		private class EAttr
		{
			// Token: 0x04035E70 RID: 220784
			public const int Icon = 0;

			// Token: 0x04035E71 RID: 220785
			public const int Title = 1;

			// Token: 0x04035E72 RID: 220786
			public const int Value = 2;
		}
	}
}
