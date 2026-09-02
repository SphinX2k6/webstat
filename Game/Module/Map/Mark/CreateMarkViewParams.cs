using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.Map.MapDefine;
using UnrealEngine;

namespace CSharpScript.Game.Module.Map.Mark
{
	// Token: 0x02005810 RID: 22544
	public class CreateMarkViewParams
	{
		// Token: 0x04020983 RID: 133507
		public EMapType MapType = EMapType.WorldMap;

		// Token: 0x04020984 RID: 133508
		public float MarkScale = 1f;

		// Token: 0x04020985 RID: 133509
		[Nullable(2)]
		public UUIItem ViewParent;
	}
}
