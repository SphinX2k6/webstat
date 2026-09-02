using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using UnrealEngine;

namespace CSharpScript.Game.Module.InstanceDungeon
{
	// Token: 0x02005BD1 RID: 23505
	public class DropDownTitle : TitleItemBase<TakeWeedsDifficulty>
	{
		// Token: 0x0603B838 RID: 243768 RVA: 0x00F16AA3 File Offset: 0x00F14CA3
		[NullableContext(1)]
		public DropDownTitle(UUIItem uiItem) : base(uiItem)
		{
		}

		// Token: 0x0603B839 RID: 243769 RVA: 0x00F16AAC File Offset: 0x00F14CAC
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

		// Token: 0x0603B83A RID: 243770 RVA: 0x00F16AF4 File Offset: 0x00F14CF4
		[NullableContext(1)]
		public override void ShowTemp(TakeWeedsDifficulty data, DropDownItemBase<TakeWeedsDifficulty> selectedItemObj)
		{
			string str = ConfigMultiTextLang.GetLocalTextNew(data.Desc, null) ?? "";
			string str2 = StringUtils.Format(ConfigMultiTextLang.GetLocalTextNew("MowingPointMultiply", null) ?? "", new string[]
			{
				(data.Magnification / 100).ToString()
			});
			base.GetText(0).SetText(str + "•" + str2, true);
		}

		// Token: 0x0200BC3B RID: 48187
		private static class EDropDownTitleComponents
		{
			// Token: 0x0403A0E8 RID: 237800
			public const int TxtContent = 0;
		}
	}
}
