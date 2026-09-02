using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using UnrealEngine;

namespace CSharpScript.Game.Module.InstanceDungeon
{
	// Token: 0x02005BD0 RID: 23504
	public class DropDownItem : DropDownItemBase<TakeWeedsDifficulty>
	{
		// Token: 0x0603B834 RID: 243764 RVA: 0x00F169B2 File Offset: 0x00F14BB2
		[NullableContext(1)]
		public DropDownItem(UUIItem uiItem) : base(uiItem)
		{
		}

		// Token: 0x0603B835 RID: 243765 RVA: 0x00F169BC File Offset: 0x00F14BBC
		protected unsafe override void OnRegisterComponent()
		{
			int num = 2;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIExtendToggle));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIText));
			this.ComponentRegisterInfos = list;
		}

		// Token: 0x0603B836 RID: 243766 RVA: 0x00F16A28 File Offset: 0x00F14C28
		protected override void OnShowDropDownItemBase(TakeWeedsDifficulty data)
		{
			string str = ConfigMultiTextLang.GetLocalTextNew(data.Desc, null) ?? "";
			string str2 = StringUtils.Format(ConfigMultiTextLang.GetLocalTextNew("MowingPointMultiply", null) ?? "", new string[]
			{
				(data.Magnification / 100).ToString()
			});
			base.GetText(1).SetText(str + "•" + str2, true);
		}

		// Token: 0x0603B837 RID: 243767 RVA: 0x00F16A9A File Offset: 0x00F14C9A
		[NullableContext(2)]
		protected override UUIExtendToggle GetDropDownToggle()
		{
			return base.GetExtendToggle(0);
		}

		// Token: 0x0200BC3A RID: 48186
		private static class EDropDownItemComponents
		{
			// Token: 0x0403A0E6 RID: 237798
			public const int TogOption = 0;

			// Token: 0x0403A0E7 RID: 237799
			public const int TxtOption = 1;
		}
	}
}
