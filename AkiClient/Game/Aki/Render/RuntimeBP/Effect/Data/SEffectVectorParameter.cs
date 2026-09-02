using System;
using System.Numerics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;

namespace AkiClient.Game.Aki.Render.RuntimeBP.Effect.Data
{
	// Token: 0x02003D47 RID: 15687
	[HasGetTypeHash]
	[UnrealBlittableStruct(UnrealReflectionPropertyTypeCode.UnrealBlittableStruct)]
	[UnrealStructLayout(24, 4, UnrealReflectionPropertyTypeCode.UnrealBlittableStruct, PropertiesSize = 24)]
	[UnrealObjectPath("/Game/Aki/Render/RuntimeBP/Effect/Data/SEffectVectorParameter.SEffectVectorParameter")]
	[StructLayout(LayoutKind.Explicit, Pack = 4, Size = 24)]
	public struct SEffectVectorParameter : IEqualityOperators<SEffectVectorParameter, SEffectVectorParameter, bool>, IEquatable<SEffectVectorParameter>, IUnrealScriptStruct
	{
		// Token: 0x06026118 RID: 155928 RVA: 0x009CD188 File Offset: 0x009CB388
		public SEffectVectorParameter(FName Name, FVector Value)
		{
			this.Name = Name;
			this.Value = Value;
		}

		// Token: 0x06026119 RID: 155929 RVA: 0x009CD198 File Offset: 0x009CB398
		public static bool operator ==(SEffectVectorParameter left, SEffectVectorParameter right)
		{
			return left.Name == right.Name && left.Value == right.Value;
		}

		// Token: 0x0602611A RID: 155930 RVA: 0x009CD1C0 File Offset: 0x009CB3C0
		public static bool operator !=(SEffectVectorParameter left, SEffectVectorParameter right)
		{
			return !(left == right);
		}

		// Token: 0x0602611B RID: 155931 RVA: 0x009CD1CC File Offset: 0x009CB3CC
		public bool Equals(SEffectVectorParameter other)
		{
			return this == other;
		}

		// Token: 0x0602611C RID: 155932 RVA: 0x009CD1DC File Offset: 0x009CB3DC
		[NullableContext(2)]
		public override bool Equals(object obj)
		{
			if (obj is SEffectVectorParameter)
			{
				SEffectVectorParameter other = (SEffectVectorParameter)obj;
				return this.Equals(other);
			}
			return false;
		}

		// Token: 0x0602611D RID: 155933 RVA: 0x009CD201 File Offset: 0x009CB401
		public override int GetHashCode()
		{
			return HashCode.Combine<FName, FVector>(this.Name, this.Value);
		}

		// Token: 0x0602611E RID: 155934 RVA: 0x009CD214 File Offset: 0x009CB414
		public static UScriptStructStackOnlyPtr StaticStruct()
		{
			return (SEffectVectorParameter._ScriptStructPtr != 0) ? SEffectVectorParameter._ScriptStructPtr : UObjectGlobals.StaticLoadScriptStruct("/Game/Aki/Render/RuntimeBP/Effect/Data/SEffectVectorParameter.SEffectVectorParameter", ref SEffectVectorParameter._ScriptStructPtr);
		}

		// Token: 0x04013B61 RID: 80737
		[FieldOffset(0)]
		public FName Name;

		// Token: 0x04013B62 RID: 80738
		[FieldOffset(12)]
		public FVector Value;

		// Token: 0x04013B63 RID: 80739
		public const string __ObjectPath = "/Game/Aki/Render/RuntimeBP/Effect/Data/SEffectVectorParameter.SEffectVectorParameter";

		// Token: 0x04013B64 RID: 80740
		private static IntPtr _ScriptStructPtr;
	}
}
