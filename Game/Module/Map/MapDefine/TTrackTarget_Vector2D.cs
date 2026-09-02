using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.Map.MapDefine
{
	// Token: 0x020058EA RID: 22762
	[NullableContext(1)]
	[Nullable(0)]
	public class TTrackTarget_Vector2D : TTrackTarget
	{
		// Token: 0x06039C31 RID: 236593 RVA: 0x00EA0980 File Offset: 0x00E9EB80
		public TTrackTarget_Vector2D(Vector2D Value)
		{
		}

		// Token: 0x06039C32 RID: 236594 RVA: 0x00EA098F File Offset: 0x00E9EB8F
		public static implicit operator Vector2D(TTrackTarget_Vector2D target)
		{
			return target.Value;
		}

		// Token: 0x06039C33 RID: 236595 RVA: 0x00EA0997 File Offset: 0x00E9EB97
		public new static implicit operator TTrackTarget_Vector2D(Vector2D value)
		{
			return new TTrackTarget_Vector2D(value);
		}

		// Token: 0x06039C34 RID: 236596 RVA: 0x00EA09A0 File Offset: 0x00E9EBA0
		[NullableContext(2)]
		public override bool Equals(object obj)
		{
			TTrackTarget_Vector2D ttrackTarget_Vector2D = obj as TTrackTarget_Vector2D;
			return ttrackTarget_Vector2D != null && this.Value.Equals(ttrackTarget_Vector2D.Value, 9.999999747378752E-05);
		}

		// Token: 0x06039C35 RID: 236597 RVA: 0x00EA09D3 File Offset: 0x00E9EBD3
		public override int GetHashCode()
		{
			return this.Value.GetHashCode();
		}

		// Token: 0x04020C04 RID: 134148
		public Vector2D Value = Value;
	}
}
