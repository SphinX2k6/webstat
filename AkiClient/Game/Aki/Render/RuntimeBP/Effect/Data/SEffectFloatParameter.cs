using System;
using System.Numerics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;

namespace AkiClient.Game.Aki.Render.RuntimeBP.Effect.Data
{
	// Token: 0x02003D46 RID: 15686
	[HasGetTypeHash]
	[UnrealBlittableStruct(UnrealReflectionPropertyTypeCode.UnrealBlittableStruct)]
	[UnrealStructLayout(16, 4, UnrealReflectionPropertyTypeCode.UnrealBlittableStruct, PropertiesSize = 16)]
	[UnrealObjectPath("/Game/Aki/Render/RuntimeBP/Effect/Data/SEffectFloatParameter.SEffectFloatParameter")]
	[StructLayout(LayoutKind.Explicit, Pack = 4, Size = 16)]
	public struct SEffectFloatParameter : IEqualityOperators<SEffectFloatParameter, SEffectFloatParameter, bool>, IEquatable<SEffectFloatParameter>, IUnrealScriptStruct
	{
		// Token: 0x06026111 RID: 155921 RVA: 0x009CD0DC File Offset: 0x009CB2DC
		public SEffectFloatParameter(FName Name, float Value)
		{
			this.Name = Name;
			this.Value = Value;
		}

		// Token: 0x06026112 RID: 155922 RVA: 0x009CD0EC File Offset: 0x009CB2EC
		public static bool operator ==(SEffectFloatParameter left, SEffectFloatParameter right)
		{
			return left.Name == right.Name && left.Value == right.Value;
		}

		// Token: 0x06026113 RID: 155923 RVA: 0x009CD111 File Offset: 0x009CB311
		public static bool operator !=(SEffectFloatParameter left, SEffectFloatParameter right)
		{
			return !(left == right);
		}

		// Token: 0x06026114 RID: 155924 RVA: 0x009CD11D File Offset: 0x009CB31D
		public bool Equals(SEffectFloatParameter other)
		{
			return this == other;
		}

		// Token: 0x06026115 RID: 155925 RVA: 0x009CD12C File Offset: 0x009CB32C
		[NullableContext(2)]
		public override bool Equals(object obj)
		{
			if (obj is SEffectFloatParameter)
			{
				SEffectFloatParameter other = (SEffectFloatParameter)obj;
				return this.Equals(other);
			}
			return false;
		}

		// Token: 0x06026116 RID: 155926 RVA: 0x009CD151 File Offset: 0x009CB351
		public override int GetHashCode()
		{
			return HashCode.Combine<FName, float>(this.Name, this.Value);
		}

		// Token: 0x06026117 RID: 155927 RVA: 0x009CD164 File Offset: 0x009CB364
		public static UScriptStructStackOnlyPtr StaticStruct()
		{
			return (SEffectFloatParameter._ScriptStructPtr != 0) ? SEffectFloatParameter._ScriptStructPtr : UObjectGlobals.StaticLoadScriptStruct("/Game/Aki/Render/RuntimeBP/Effect/Data/SEffectFloatParameter.SEffectFloatParameter", ref SEffectFloatParameter._ScriptStructPtr);
		}

		// Token: 0x04013B5D RID: 80733
		[FieldOffset(0)]
		public FName Name;

		// Token: 0x04013B5E RID: 80734
		[FieldOffset(12)]
		public float Value;

		// Token: 0x04013B5F RID: 80735
		public const string __ObjectPath = "/Game/Aki/Render/RuntimeBP/Effect/Data/SEffectFloatParameter.SEffectFloatParameter";

		// Token: 0x04013B60 RID: 80736
		private static IntPtr _ScriptStructPtr;
	}
}
