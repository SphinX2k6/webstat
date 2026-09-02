using System;
using System.Numerics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;

namespace AkiClient.Game.Aki.Data.PathLine.FogLine
{
	// Token: 0x02003E56 RID: 15958
	[HasGetTypeHash]
	[UnrealBlittableStruct(UnrealReflectionPropertyTypeCode.UnrealBlittableStruct)]
	[UnrealStructLayout(4, 4, UnrealReflectionPropertyTypeCode.UnrealBlittableStruct, PropertiesSize = 4)]
	[UnrealObjectPath("/Game/Aki/Data/PathLine/FogLine/S_AreaIDToMaskVal.S_AreaIDToMaskVal")]
	[StructLayout(LayoutKind.Explicit, Pack = 4, Size = 4)]
	public struct S_AreaIDToMaskVal : IEqualityOperators<S_AreaIDToMaskVal, S_AreaIDToMaskVal, bool>, IEquatable<S_AreaIDToMaskVal>, IUnrealScriptStruct
	{
		// Token: 0x06027635 RID: 161333 RVA: 0x009F0BD5 File Offset: 0x009EEDD5
		public S_AreaIDToMaskVal(int Mask)
		{
			this.Mask = Mask;
		}

		// Token: 0x06027636 RID: 161334 RVA: 0x009F0BDE File Offset: 0x009EEDDE
		public static bool operator ==(S_AreaIDToMaskVal left, S_AreaIDToMaskVal right)
		{
			return left.Mask == right.Mask;
		}

		// Token: 0x06027637 RID: 161335 RVA: 0x009F0BEE File Offset: 0x009EEDEE
		public static bool operator !=(S_AreaIDToMaskVal left, S_AreaIDToMaskVal right)
		{
			return !(left == right);
		}

		// Token: 0x06027638 RID: 161336 RVA: 0x009F0BFA File Offset: 0x009EEDFA
		public bool Equals(S_AreaIDToMaskVal other)
		{
			return this == other;
		}

		// Token: 0x06027639 RID: 161337 RVA: 0x009F0C08 File Offset: 0x009EEE08
		[NullableContext(2)]
		public override bool Equals(object obj)
		{
			if (obj is S_AreaIDToMaskVal)
			{
				S_AreaIDToMaskVal other = (S_AreaIDToMaskVal)obj;
				return this.Equals(other);
			}
			return false;
		}

		// Token: 0x0602763A RID: 161338 RVA: 0x009F0C2D File Offset: 0x009EEE2D
		public override int GetHashCode()
		{
			return HashCode.Combine<int>(this.Mask);
		}

		// Token: 0x0602763B RID: 161339 RVA: 0x009F0C3A File Offset: 0x009EEE3A
		public static UScriptStructStackOnlyPtr StaticStruct()
		{
			return (S_AreaIDToMaskVal._ScriptStructPtr != 0) ? S_AreaIDToMaskVal._ScriptStructPtr : UObjectGlobals.StaticLoadScriptStruct("/Game/Aki/Data/PathLine/FogLine/S_AreaIDToMaskVal.S_AreaIDToMaskVal", ref S_AreaIDToMaskVal._ScriptStructPtr);
		}

		// Token: 0x040149FA RID: 84474
		[FieldOffset(0)]
		public int Mask;

		// Token: 0x040149FB RID: 84475
		public const string __ObjectPath = "/Game/Aki/Data/PathLine/FogLine/S_AreaIDToMaskVal.S_AreaIDToMaskVal";

		// Token: 0x040149FC RID: 84476
		private static IntPtr _ScriptStructPtr;
	}
}
