using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.NewWorld.Character.Common.Component.Move
{
	// Token: 0x02004915 RID: 18709
	[NullableContext(1)]
	[Nullable(0)]
	public class SClimbInfo
	{
		// Token: 0x06030E46 RID: 200262 RVA: 0x00C1D7BD File Offset: 0x00C1B9BD
		[NullableContext(2)]
		public SClimbInfo(bool? 攀爬移动中 = null, Vector2D 攀爬输入向量 = null, float? onWallAngle = null)
		{
			this.攀爬移动中 = 攀爬移动中.GetValueOrDefault();
			this.攀爬输入向量 = Vector2D.Create(攀爬输入向量);
			this.OnWallAngle = onWallAngle.GetValueOrDefault();
		}

		// Token: 0x06030E47 RID: 200263 RVA: 0x00C1D7EC File Offset: 0x00C1B9EC
		[NullableContext(2)]
		public bool Equals(SClimbInfo inB)
		{
			return inB != null && this.攀爬移动中 == inB.攀爬移动中 && this.攀爬输入向量.Equals(inB.攀爬输入向量, 9.999999747378752E-05) && Math.Abs(this.OnWallAngle - inB.OnWallAngle) < 1E-08f;
		}

		// Token: 0x06030E48 RID: 200264 RVA: 0x00C1D841 File Offset: 0x00C1BA41
		public void DeepCopy(SClimbInfo other)
		{
			this.攀爬移动中 = other.攀爬移动中;
			this.攀爬输入向量.DeepCopy(other.攀爬输入向量);
			this.OnWallAngle = other.OnWallAngle;
		}

		// Token: 0x06030E49 RID: 200265 RVA: 0x00C1D86C File Offset: 0x00C1BA6C
		public SClimbInfo Copy()
		{
			Vector2D vector2D = Vector2D.Create(this.攀爬输入向量);
			return new SClimbInfo(new bool?(this.攀爬移动中), vector2D, new float?(this.OnWallAngle));
		}

		// Token: 0x0401C1A8 RID: 115112
		public bool 攀爬移动中;

		// Token: 0x0401C1A9 RID: 115113
		public Vector2D 攀爬输入向量;

		// Token: 0x0401C1AA RID: 115114
		public float OnWallAngle;
	}
}
