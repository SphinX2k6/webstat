using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.Map.Marks.MarkItem;

namespace CSharpScript.Game.Module.Map.Marks.MarkItemView
{
	// Token: 0x02005888 RID: 22664
	public class TreasureBoxMarkItemView : ServerMarkItemView
	{
		// Token: 0x060399DF RID: 235999 RVA: 0x00E9D932 File Offset: 0x00E9BB32
		[NullableContext(1)]
		public TreasureBoxMarkItemView(TreasureBoxMarkItem holder) : base(holder)
		{
		}

		// Token: 0x060399E0 RID: 236000 RVA: 0x00E9D93B File Offset: 0x00E9BB3B
		public override bool GetInteractiveFlag()
		{
			return false;
		}
	}
}
