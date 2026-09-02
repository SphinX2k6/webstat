using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Utils
{
	// Token: 0x020046EE RID: 18158
	[NullableContext(1)]
	[Nullable(0)]
	public class CatapultToTargetResult
	{
		// Token: 0x0401AE80 RID: 110208
		public float Time1;

		// Token: 0x0401AE81 RID: 110209
		public readonly Vector StartPoint = Vector.Create();

		// Token: 0x0401AE82 RID: 110210
		public readonly Vector MiddlePoint = Vector.Create();

		// Token: 0x0401AE83 RID: 110211
		public readonly Vector EndPoint = Vector.Create();

		// Token: 0x0401AE84 RID: 110212
		public float GravityMagnitude;

		// Token: 0x0401AE85 RID: 110213
		public readonly Rotator EndRotator = Rotator.Create();

		// Token: 0x0401AE86 RID: 110214
		public readonly Vector GravityDirect = Vector.Create();
	}
}
