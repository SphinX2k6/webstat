using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Render
{
	// Token: 0x02004770 RID: 18288
	public class EffectNiagaraParameters : EffectParametersBase
	{
		// Token: 0x0602F730 RID: 194352 RVA: 0x00B47245 File Offset: 0x00B45445
		public EffectNiagaraParameters([Nullable(new byte[]
		{
			2,
			1
		})] Dictionary<FName, FKuroCurveFloat> floats = null, [Nullable(new byte[]
		{
			2,
			1
		})] Dictionary<FName, FKuroCurveVector> vectors = null, [Nullable(new byte[]
		{
			2,
			1
		})] Dictionary<FName, FKuroCurveLinearColor> colors = null)
		{
			if (floats != null)
			{
				this.FloatCurveMap = floats;
			}
			if (vectors != null)
			{
				this.VectorCurveMap = vectors;
			}
			if (colors != null)
			{
				this.LinearColorCurveMap = colors;
			}
			if (floats != null || vectors != null || colors != null)
			{
				this.HasCurveParameters = true;
			}
		}
	}
}
