using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.Activity.View.InstanceEntrance
{
	// Token: 0x020061E7 RID: 25063
	[NullableContext(1)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	public class DropDownItem : DropDownItemBase<ActivityEntranceDropDownContentData>
	{
		// Token: 0x0603F3DD RID: 259037 RVA: 0x0103AFF4 File Offset: 0x010391F4
		public DropDownItem(UUIItem uiItem) : base(uiItem)
		{
		}

		// Token: 0x0603F3DE RID: 259038 RVA: 0x0103B000 File Offset: 0x01039200
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

		// Token: 0x0603F3DF RID: 259039 RVA: 0x0103B06C File Offset: 0x0103926C
		protected override void OnShowDropDownItemBase(ActivityEntranceDropDownContentData data)
		{
			string newText = data.GetTogOptionText() ?? "";
			UUIText text = base.GetText(1);
			if (text == null)
			{
				return;
			}
			text.SetText(newText, true);
		}

		// Token: 0x0603F3E0 RID: 259040 RVA: 0x0103B09C File Offset: 0x0103929C
		protected override UUIExtendToggle GetDropDownToggle()
		{
			return base.GetExtendToggle(0);
		}

		// Token: 0x0200C322 RID: 49954
		[NullableContext(0)]
		private class EDropDownItemComponent
		{
			// Token: 0x0403C248 RID: 246344
			public const int TogOption = 0;

			// Token: 0x0403C249 RID: 246345
			public const int TxtOption = 1;
		}
	}
}
