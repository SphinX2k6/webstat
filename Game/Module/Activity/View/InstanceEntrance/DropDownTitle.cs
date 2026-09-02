using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.Activity.View.InstanceEntrance
{
	// Token: 0x020061E8 RID: 25064
	[NullableContext(1)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	public class DropDownTitle : TitleItemBase<ActivityEntranceDropDownContentData>
	{
		// Token: 0x0603F3E1 RID: 259041 RVA: 0x0103B0A5 File Offset: 0x010392A5
		public DropDownTitle(UUIItem uiItem) : base(uiItem)
		{
		}

		// Token: 0x0603F3E2 RID: 259042 RVA: 0x0103B0B0 File Offset: 0x010392B0
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

		// Token: 0x0603F3E3 RID: 259043 RVA: 0x0103B0F8 File Offset: 0x010392F8
		public override void ShowTemp(ActivityEntranceDropDownContentData data, DropDownItemBase<ActivityEntranceDropDownContentData> selectedItemObj)
		{
			string dropDownText = data.GetDropDownText();
			UUIText text = base.GetText(0);
			if (text == null)
			{
				return;
			}
			text.SetText(dropDownText, true);
		}

		// Token: 0x0200C323 RID: 49955
		[NullableContext(0)]
		private class EDropDownTitleComponent
		{
			// Token: 0x0403C24A RID: 246346
			public const int TxtContent = 0;
		}
	}
}
