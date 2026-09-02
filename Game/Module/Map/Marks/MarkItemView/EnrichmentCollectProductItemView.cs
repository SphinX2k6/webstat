using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.Map.Marks.MarkItem;

namespace CSharpScript.Game.Module.Map.Marks.MarkItemView
{
	// Token: 0x0200586A RID: 22634
	public class EnrichmentCollectProductItemView : ServerMarkItemView
	{
		// Token: 0x060398F7 RID: 235767 RVA: 0x00E9AB96 File Offset: 0x00E98D96
		[NullableContext(1)]
		public EnrichmentCollectProductItemView(EnrichmentCollectProductItem holder) : base(holder)
		{
		}

		// Token: 0x060398F8 RID: 235768 RVA: 0x00E9AB9F File Offset: 0x00E98D9F
		public override bool GetInteractiveFlag()
		{
			return false;
		}
	}
}
