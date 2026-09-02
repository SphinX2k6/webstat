using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.Map.Marks.MarkItem;

namespace CSharpScript.Game.Module.Map.Marks.MarkItemView
{
	// Token: 0x0200587D RID: 22653
	public class PlayerMarkItemView : MarkItemView
	{
		// Token: 0x0603999B RID: 235931 RVA: 0x00E9CACB File Offset: 0x00E9ACCB
		[NullableContext(1)]
		public PlayerMarkItemView(PlayerMarkItem holder) : base(holder)
		{
		}

		// Token: 0x0603999C RID: 235932 RVA: 0x00E9CAD4 File Offset: 0x00E9ACD4
		public override bool GetInteractiveFlag()
		{
			return false;
		}
	}
}
