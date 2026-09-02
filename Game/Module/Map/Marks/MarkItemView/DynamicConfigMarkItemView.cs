using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.Map.Marks.MarkItem;
using UnrealEngine;

namespace CSharpScript.Game.Module.Map.Marks.MarkItemView
{
	// Token: 0x02005867 RID: 22631
	[NullableContext(1)]
	[Nullable(0)]
	public class DynamicConfigMarkItemView : MarkItemView
	{
		// Token: 0x060398EB RID: 235755 RVA: 0x00E9A99A File Offset: 0x00E98B9A
		public DynamicConfigMarkItemView(DynamicConfigMarkItem holder) : base(holder)
		{
		}

		// Token: 0x060398EC RID: 235756 RVA: 0x00E9A9A4 File Offset: 0x00E98BA4
		public override void OnIconPathChanged(string iconPath)
		{
			UUISprite sprite = base.GetSprite(1);
			base.LoadIcon(sprite, iconPath);
		}
	}
}
