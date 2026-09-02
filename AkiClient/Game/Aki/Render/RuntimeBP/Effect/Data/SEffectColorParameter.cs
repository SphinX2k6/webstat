using System;
using System.Numerics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;

namespace AkiClient.Game.Aki.Render.RuntimeBP.Effect.Data
{
	// Token: 0x02003D45 RID: 15685
	[HasGetTypeHash]
	[UnrealBlittableStruct(UnrealReflectionPropertyTypeCode.UnrealBlittableStruct)]
	[UnrealStructLayout(28, 4, UnrealReflectionPropertyTypeCode.UnrealBlittableStruct, PropertiesSize = 28)]
	[UnrealObjectPath("/Game/Aki/Render/RuntimeBP/Effect/Data/SEffectColorParameter.SEffectColorParameter")]
	[StructLayout(LayoutKind.Explicit, Pack = 4, Size = 28)]
	public struct SEffectColorParameter : IEqualityOperators<SEffectColorParameter, SEffectColorParameter, bool>, IEquatable<SEffectColorParameter>, IUnrealScriptStruct
	{
		// Token: 0x0602610A RID: 155914 RVA: 0x009CD02C File Offset: 0x009CB22C
		public SEffectColorParameter(FName Name, FLinearColor Value)
		{
			this.Name = Name;
			this.Value = Value;
		}

		// Token: 0x0602610B RID: 155915 RVA: 0x009CD03C File Offset: 0x009CB23C
		public static bool operator ==(SEffectColorParameter left, SEffectColorParameter right)
		{
			return left.Name == right.Name && left.Value == right.Value;
		}

		// Token: 0x0602610C RID: 155916 RVA: 0x009CD064 File Offset: 0x009CB264
		public static bool operator !=(SEffectColorParameter left, SEffectColorParameter right)
		{
			return !(left == right);
		}

		// Token: 0x0602610D RID: 155917 RVA: 0x009CD070 File Offset: 0x009CB270
		public bool Equals(SEffectColorParameter other)
		{
			return this == other;
		}

		// Token: 0x0602610E RID: 155918 RVA: 0x009CD080 File Offset: 0x009CB280
		[NullableContext(2)]
		public override bool Equals(object obj)
		{
			if (obj is SEffectColorParameter)
			{
				SEffectColorParameter other = (SEffectColorParameter)obj;
				return this.Equals(other);
			}
			return false;
		}

		// Token: 0x0602610F RID: 155919 RVA: 0x009CD0A5 File Offset: 0x009CB2A5
		public override int GetHashCode()
		{
			return HashCode.Combine<FName, FLinearColor>(this.Name, this.Value);
		}

		// Token: 0x06026110 RID: 155920 RVA: 0x009CD0B8 File Offset: 0x009CB2B8
		public static UScriptStructStackOnlyPtr StaticStruct()
		{
			return (SEffectColorParameter._ScriptStructPtr != 0) ? SEffectColorParameter._ScriptStructPtr : UObjectGlobals.StaticLoadScriptStruct("/Game/Aki/Render/RuntimeBP/Effect/Data/SEffectColorParameter.SEffectColorParameter", ref SEffectColorParameter._ScriptStructPtr);
		}

		// Token: 0x04013B59 RID: 80729
		[FieldOffset(0)]
		public FName Name;

		// Token: 0x04013B5A RID: 80730
		[FieldOffset(12)]
		public FLinearColor Value;

		// Token: 0x04013B5B RID: 80731
		public const string __ObjectPath = "/Game/Aki/Render/RuntimeBP/Effect/Data/SEffectColorParameter.SEffectColorParameter";

		// Token: 0x04013B5C RID: 80732
		private static IntPtr _ScriptStructPtr;
	}
}
