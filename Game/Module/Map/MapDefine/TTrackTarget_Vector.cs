using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.Map.MapDefine
{
	// Token: 0x020058E9 RID: 22761
	[NullableContext(1)]
	[Nullable(0)]
	public class TTrackTarget_Vector : TTrackTarget
	{
		// Token: 0x06039C2C RID: 236588 RVA: 0x00EA0921 File Offset: 0x00E9EB21
		public TTrackTarget_Vector(Vector Value)
		{
		}

		// Token: 0x06039C2D RID: 236589 RVA: 0x00EA0930 File Offset: 0x00E9EB30
		public static implicit operator Vector(TTrackTarget_Vector target)
		{
			return target.Value;
		}

		// Token: 0x06039C2E RID: 236590 RVA: 0x00EA0938 File Offset: 0x00E9EB38
		public new static implicit operator TTrackTarget_Vector(Vector value)
		{
			return new TTrackTarget_Vector(value);
		}

		// Token: 0x06039C2F RID: 236591 RVA: 0x00EA0940 File Offset: 0x00E9EB40
		[NullableContext(2)]
		public override bool Equals(object obj)
		{
			TTrackTarget_Vector ttrackTarget_Vector = obj as TTrackTarget_Vector;
			return ttrackTarget_Vector != null && this.Value.Equals(ttrackTarget_Vector.Value, 9.999999747378752E-05);
		}

		// Token: 0x06039C30 RID: 236592 RVA: 0x00EA0973 File Offset: 0x00E9EB73
		public override int GetHashCode()
		{
			return this.Value.GetHashCode();
		}

		// Token: 0x04020C03 RID: 134147
		public Vector Value = Value;
	}
}
