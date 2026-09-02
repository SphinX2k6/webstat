using System;
using System.Runtime.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.Map.MapDefine
{
	// Token: 0x020058E7 RID: 22759
	[NullableContext(1)]
	[Nullable(0)]
	public abstract class TTrackTarget
	{
		// Token: 0x06039C22 RID: 236578 RVA: 0x00EA0896 File Offset: 0x00E9EA96
		public static implicit operator TTrackTarget(AActor value)
		{
			return new TTrackTarget_AActor(value);
		}

		// Token: 0x06039C23 RID: 236579 RVA: 0x00EA089E File Offset: 0x00E9EA9E
		public static implicit operator TTrackTarget(Vector value)
		{
			return new TTrackTarget_Vector(value);
		}

		// Token: 0x06039C24 RID: 236580 RVA: 0x00EA08A6 File Offset: 0x00E9EAA6
		public static implicit operator TTrackTarget(Vector2D value)
		{
			return new TTrackTarget_Vector2D(value);
		}

		// Token: 0x06039C25 RID: 236581 RVA: 0x00EA08AE File Offset: 0x00E9EAAE
		public static implicit operator TTrackTarget(int value)
		{
			return new TTrackTarget_Int(value);
		}

		// Token: 0x06039C26 RID: 236582 RVA: 0x00EA08B6 File Offset: 0x00E9EAB6
		public static implicit operator TTrackTarget(float value)
		{
			return new TTrackTarget_Int((int)value);
		}

		// Token: 0x06039C27 RID: 236583 RVA: 0x00EA08C0 File Offset: 0x00E9EAC0
		[NullableContext(2)]
		public static implicit operator TEntityIdOrPos(TTrackTarget value)
		{
			TTrackTarget_Vector ttrackTarget_Vector = value as TTrackTarget_Vector;
			if (ttrackTarget_Vector != null)
			{
				return new TEntityIdOrPos_Vector(ttrackTarget_Vector);
			}
			TTrackTarget_Int ttrackTarget_Int = value as TTrackTarget_Int;
			if (ttrackTarget_Int != null)
			{
				return new TEntityIdOrPos_Int(ttrackTarget_Int);
			}
			return null;
		}
	}
}
