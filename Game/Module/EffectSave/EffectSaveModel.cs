using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.EffectSave
{
	// Token: 0x02005D90 RID: 23952
	[NullableContext(1)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	[Model(0)]
	public class EffectSaveModel : ModelBase<EffectSaveModel>
	{
		// Token: 0x0603C4F2 RID: 247026 RVA: 0x00F4E29C File Offset: 0x00F4C49C
		protected override bool OnInit()
		{
			this.EffectSaveMap.Clear();
			return true;
		}

		// Token: 0x04021EA7 RID: 138919
		public FTransformDouble TempTransform = new FTransformDouble();

		// Token: 0x04021EA8 RID: 138920
		public FVectorDouble TempPosition = new FVectorDouble();

		// Token: 0x04021EA9 RID: 138921
		public FRotator TempRotation = new FRotator();

		// Token: 0x04021EAA RID: 138922
		public Dictionary<long, int> EffectSaveMap = new Dictionary<long, int>();
	}
}
