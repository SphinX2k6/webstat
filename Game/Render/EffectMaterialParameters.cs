using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Render
{
	// Token: 0x0200476F RID: 18287
	[NullableContext(1)]
	[Nullable(0)]
	public class EffectMaterialParameters : EffectParametersBase
	{
		// Token: 0x0602F725 RID: 194341 RVA: 0x00B4716F File Offset: 0x00B4536F
		public EffectMaterialParameters([Nullable(new byte[]
		{
			2,
			1
		})] Dictionary<FName, FKuroCurveFloat> floats = null, [Nullable(new byte[]
		{
			2,
			1
		})] Dictionary<FName, FKuroCurveLinearColor> colors = null)
		{
			if (floats != null)
			{
				this.FloatCurveMap = floats;
			}
			if (colors != null)
			{
				this.LinearColorCurveMap = colors;
			}
			if (floats != null || colors != null)
			{
				this.HasCurveParameters = true;
			}
		}

		// Token: 0x0602F726 RID: 194342 RVA: 0x00B47198 File Offset: 0x00B45398
		public override void CollectFloatCurve(FName name, FKuroCurveFloat value)
		{
			base.CollectFloatCurve(name, value);
			this.IsMaterialParameterDirty = true;
		}

		// Token: 0x0602F727 RID: 194343 RVA: 0x00B471A9 File Offset: 0x00B453A9
		public override void CollectVectorCurve(FName name, FKuroCurveVector value)
		{
			base.CollectVectorCurve(name, value);
			this.IsMaterialParameterDirty = true;
		}

		// Token: 0x0602F728 RID: 194344 RVA: 0x00B471BA File Offset: 0x00B453BA
		public override void CollectLinearColorCurve(FName name, FKuroCurveLinearColor value)
		{
			base.CollectLinearColorCurve(name, value);
			this.IsMaterialParameterDirty = true;
		}

		// Token: 0x0602F729 RID: 194345 RVA: 0x00B471CB File Offset: 0x00B453CB
		public override void CollectFloatConst(FName name, float value)
		{
			base.CollectFloatConst(name, value);
			this.IsMaterialParameterDirty = true;
		}

		// Token: 0x0602F72A RID: 194346 RVA: 0x00B471DC File Offset: 0x00B453DC
		public override void CollectVectorConst(FName name, FVector value)
		{
			base.CollectVectorConst(name, value);
			this.IsMaterialParameterDirty = true;
		}

		// Token: 0x0602F72B RID: 194347 RVA: 0x00B471ED File Offset: 0x00B453ED
		public override void CollectLinearColorConst(FName name, FLinearColor value)
		{
			base.CollectLinearColorConst(name, value);
			this.IsMaterialParameterDirty = true;
		}

		// Token: 0x0602F72C RID: 194348 RVA: 0x00B471FE File Offset: 0x00B453FE
		public override void RemoveFloatCurveOrConst(FName name)
		{
			base.RemoveFloatCurveOrConst(name);
			this.IsMaterialParameterDirty = true;
		}

		// Token: 0x0602F72D RID: 194349 RVA: 0x00B4720E File Offset: 0x00B4540E
		public override void RemoveLinearColorCurveOrConst(FName name)
		{
			base.RemoveLinearColorCurveOrConst(name);
			this.IsMaterialParameterDirty = true;
		}

		// Token: 0x0602F72E RID: 194350 RVA: 0x00B4721E File Offset: 0x00B4541E
		public override void RemoveVectorCurveOrConst(FName name)
		{
			base.RemoveVectorCurveOrConst(name);
			this.IsMaterialParameterDirty = true;
		}

		// Token: 0x0602F72F RID: 194351 RVA: 0x00B4722E File Offset: 0x00B4542E
		[NullableContext(2)]
		public void Tick(UObject target, float time)
		{
			this.Apply(target, time, this.IsMaterialParameterDirty);
			this.IsMaterialParameterDirty = false;
		}

		// Token: 0x0401B19D RID: 111005
		private bool IsMaterialParameterDirty;
	}
}
