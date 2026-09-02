using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Utils;
using UnrealEngine;

namespace CSharpScript.Game.LevelGamePlay.ItemInspect
{
	// Token: 0x02006E4A RID: 28234
	[NullableContext(1)]
	[Nullable(0)]
	public class ConeRangeChecker : ItemInspectRangeChecker
	{
		// Token: 0x06044854 RID: 280660 RVA: 0x011CFC68 File Offset: 0x011CDE68
		protected override void OnInit(IShapeParams @params)
		{
			ConeShapeParams coneShapeParams = (ConeShapeParams)@params;
			this.Rotation.Vector(this.UpToDownVector);
			this.Height = coneShapeParams.Height;
			this.Radius = coneShapeParams.Radius;
		}

		// Token: 0x06044855 RID: 280661 RVA: 0x011CFCA5 File Offset: 0x011CDEA5
		public override bool IsPointInside(IVector point)
		{
			this.TempVector.DeepCopy(point);
			return Singleton<MathUtils>.Instance.IsLocationInsideCone(this.Location, this.UpToDownVector, (double)this.Height, (double)this.Radius, this.TempVector);
		}

		// Token: 0x06044856 RID: 280662 RVA: 0x011CFCE0 File Offset: 0x011CDEE0
		public override void DebugDraw()
		{
			float height = this.Height;
			float radius = this.Radius;
			float length = (float)Math.Sqrt((double)(height * height + radius * radius));
			float num = (float)Math.Atan((double)(radius / height));
			UKismetSystemLibrary.D_DrawDebugCone(GlobalData.World, this.Location.ToUeVector(false), this.UpToDownVector.ToUeVector(false), length, num, num, 12, ColorUtils.LinearRed, 1f, 0f);
		}

		// Token: 0x04026248 RID: 156232
		protected readonly Vector UpToDownVector = Vector.Create();

		// Token: 0x04026249 RID: 156233
		private readonly Vector TempVector = Vector.Create();

		// Token: 0x0402624A RID: 156234
		private float Height;

		// Token: 0x0402624B RID: 156235
		private float Radius;
	}
}
