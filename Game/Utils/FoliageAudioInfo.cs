using System;
using System.Runtime.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Utils
{
	// Token: 0x020046F1 RID: 18161
	public class FoliageAudioInfo
	{
		// Token: 0x0401AE8A RID: 110218
		[Nullable(2)]
		public UPhysicalMaterial PhysicalMaterial;

		// Token: 0x0401AE8B RID: 110219
		public FName FoliageName = FNameUtil.NONE;

		// Token: 0x0401AE8C RID: 110220
		public bool IsAudioShrub;

		// Token: 0x0401AE8D RID: 110221
		public bool IsHitFoliage;

		// Token: 0x0401AE8E RID: 110222
		public FName AudioShrubTag = FNameUtil.NONE;
	}
}
