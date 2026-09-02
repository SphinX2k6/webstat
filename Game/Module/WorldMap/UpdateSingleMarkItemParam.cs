using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.WorldMap
{
	// Token: 0x02004B33 RID: 19251
	[NullableContext(1)]
	[Nullable(0)]
	public class UpdateSingleMarkItemParam
	{
		// Token: 0x0401D5D2 RID: 120274
		public Vector2D MapUiPosition;

		// Token: 0x0401D5D3 RID: 120275
		public float MapScale;

		// Token: 0x0401D5D4 RID: 120276
		public Vector PlayerWorldPosition;

		// Token: 0x0401D5D5 RID: 120277
		public bool IsDragging;

		// Token: 0x0401D5D6 RID: 120278
		public bool IsScaleDirty;

		// Token: 0x0401D5D7 RID: 120279
		public bool ForceViewUpdate;
	}
}
