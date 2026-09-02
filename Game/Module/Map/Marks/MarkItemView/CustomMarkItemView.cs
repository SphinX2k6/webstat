using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.Map.Marks.MarkItem;

namespace CSharpScript.Game.Module.Map.Marks.MarkItemView
{
	// Token: 0x02005865 RID: 22629
	public class CustomMarkItemView : ServerMarkItemView
	{
		// Token: 0x060398E8 RID: 235752 RVA: 0x00E9A965 File Offset: 0x00E98B65
		[NullableContext(1)]
		public CustomMarkItemView(CustomMarkItem holder) : base(holder)
		{
		}

		// Token: 0x060398E9 RID: 235753 RVA: 0x00E9A96E File Offset: 0x00E98B6E
		public override bool GetInteractiveFlag()
		{
			CustomMarkItem customMarkItem = this.Holder as CustomMarkItem;
			return (customMarkItem == null || !customMarkItem.IsNewCustomMarkItem) && base.GetInteractiveFlag();
		}
	}
}
