using System;
using System.Runtime.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Render
{
	// Token: 0x0200476B RID: 18283
	public class EffectTemp : IStaticVariableResetter
	{
		// Token: 0x0602F719 RID: 194329 RVA: 0x00B46EC1 File Offset: 0x00B450C1
		static EffectTemp()
		{
			StaticVariableRegister.RegisterAndExecute(new Action(EffectTemp.CreateStaticDefaultValue), new Action(EffectTemp.ResetStaticDefaultValue));
		}

		// Token: 0x0602F71A RID: 194330 RVA: 0x00B46EE0 File Offset: 0x00B450E0
		public static void CreateStaticDefaultValue()
		{
			EffectTemp.FloatRef = 0.0;
			EffectTemp.FloatXRef = 0.0;
			EffectTemp.FloatYRef = 0.0;
			EffectTemp.FloatZRef = 0.0;
			EffectTemp.VectorRef = new FVector();
			EffectTemp.Vector2dRef = new FVector2D();
			EffectTemp.ColorRef = new FLinearColor();
			EffectTemp.Transform = new FTransform();
			EffectTemp.TsVector = Vector.Create(0.0, 0.0, 0.0);
			EffectTemp.Rotator = new FRotator();
			EffectTemp.Index = 0.0;
			EffectTemp.Number = 0.0;
			EffectTemp.Key = null;
		}

		// Token: 0x0602F71B RID: 194331 RVA: 0x00B46FA0 File Offset: 0x00B451A0
		public static void ResetStaticDefaultValue()
		{
			EffectTemp.FloatRef = 0.0;
			EffectTemp.FloatXRef = 0.0;
			EffectTemp.FloatYRef = 0.0;
			EffectTemp.FloatZRef = 0.0;
			EffectTemp.VectorRef = default(FVector);
			EffectTemp.Vector2dRef = default(FVector2D);
			EffectTemp.ColorRef = default(FLinearColor);
			EffectTemp.Transform = default(FTransform);
			EffectTemp.TsVector = null;
			EffectTemp.Rotator = default(FRotator);
			EffectTemp.Index = 0.0;
			EffectTemp.Number = 0.0;
			EffectTemp.Key = null;
		}

		// Token: 0x0602F71C RID: 194332 RVA: 0x00B47044 File Offset: 0x00B45244
		public static void Initialize()
		{
		}

		// Token: 0x0602F71D RID: 194333 RVA: 0x00B47046 File Offset: 0x00B45246
		public static void StartStat()
		{
		}

		// Token: 0x0602F71E RID: 194334 RVA: 0x00B47048 File Offset: 0x00B45248
		public static void StopStat()
		{
		}

		// Token: 0x0401B18C RID: 110988
		public static double FloatRef;

		// Token: 0x0401B18D RID: 110989
		public static double FloatXRef;

		// Token: 0x0401B18E RID: 110990
		public static double FloatYRef;

		// Token: 0x0401B18F RID: 110991
		public static double FloatZRef;

		// Token: 0x0401B190 RID: 110992
		public static FVector VectorRef;

		// Token: 0x0401B191 RID: 110993
		public static FVector2D Vector2dRef;

		// Token: 0x0401B192 RID: 110994
		public static FLinearColor ColorRef;

		// Token: 0x0401B193 RID: 110995
		public static FTransform Transform;

		// Token: 0x0401B194 RID: 110996
		[Nullable(1)]
		public static Vector TsVector;

		// Token: 0x0401B195 RID: 110997
		public static FRotator Rotator;

		// Token: 0x0401B196 RID: 110998
		public static double Index;

		// Token: 0x0401B197 RID: 110999
		public static double Number;

		// Token: 0x0401B198 RID: 111000
		[Nullable(1)]
		public static string Key;
	}
}
