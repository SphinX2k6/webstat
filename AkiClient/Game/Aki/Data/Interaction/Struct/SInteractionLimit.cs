using System;
using System.Numerics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using AkiClient.Game.Aki.Data.Interaction.Enum;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;

namespace AkiClient.Game.Aki.Data.Interaction.Struct
{
	// Token: 0x02003E87 RID: 16007
	[HasGetTypeHash]
	[UnrealBlittableStruct(UnrealReflectionPropertyTypeCode.UnrealBlittableStruct)]
	[UnrealStructLayout(12, 4, UnrealReflectionPropertyTypeCode.UnrealBlittableStruct, PropertiesSize = 12)]
	[UnrealObjectPath("/Game/Aki/Data/Interaction/Struct/SInteractionLimit.SInteractionLimit")]
	[StructLayout(LayoutKind.Explicit, Pack = 4, Size = 12)]
	public struct SInteractionLimit : IEqualityOperators<SInteractionLimit, SInteractionLimit, bool>, IEquatable<SInteractionLimit>, IUnrealScriptStruct
	{
		// Token: 0x06027A67 RID: 162407 RVA: 0x009F7190 File Offset: 0x009F5390
		public SInteractionLimit(TEnumAsByte<EInteractOptionLimit> LimitType, int Times, float Duration)
		{
			this.LimitType = LimitType;
			this.Times = Times;
			this.Duration = Duration;
		}

		// Token: 0x06027A68 RID: 162408 RVA: 0x009F71A7 File Offset: 0x009F53A7
		public static bool operator ==(SInteractionLimit left, SInteractionLimit right)
		{
			return left.LimitType == right.LimitType && left.Times == right.Times && left.Duration == right.Duration;
		}

		// Token: 0x06027A69 RID: 162409 RVA: 0x009F71DA File Offset: 0x009F53DA
		public static bool operator !=(SInteractionLimit left, SInteractionLimit right)
		{
			return !(left == right);
		}

		// Token: 0x06027A6A RID: 162410 RVA: 0x009F71E6 File Offset: 0x009F53E6
		public bool Equals(SInteractionLimit other)
		{
			return this == other;
		}

		// Token: 0x06027A6B RID: 162411 RVA: 0x009F71F4 File Offset: 0x009F53F4
		[NullableContext(2)]
		public override bool Equals(object obj)
		{
			if (obj is SInteractionLimit)
			{
				SInteractionLimit other = (SInteractionLimit)obj;
				return this.Equals(other);
			}
			return false;
		}

		// Token: 0x06027A6C RID: 162412 RVA: 0x009F7219 File Offset: 0x009F5419
		public override int GetHashCode()
		{
			return HashCode.Combine<TEnumAsByte<EInteractOptionLimit>, int, float>(this.LimitType, this.Times, this.Duration);
		}

		// Token: 0x06027A6D RID: 162413 RVA: 0x009F7232 File Offset: 0x009F5432
		public static UScriptStructStackOnlyPtr StaticStruct()
		{
			return (SInteractionLimit._ScriptStructPtr != 0) ? SInteractionLimit._ScriptStructPtr : UObjectGlobals.StaticLoadScriptStruct("/Game/Aki/Data/Interaction/Struct/SInteractionLimit.SInteractionLimit", ref SInteractionLimit._ScriptStructPtr);
		}

		// Token: 0x04014CAB RID: 85163
		[FieldOffset(0)]
		public TEnumAsByte<EInteractOptionLimit> LimitType;

		// Token: 0x04014CAC RID: 85164
		[FieldOffset(4)]
		public int Times;

		// Token: 0x04014CAD RID: 85165
		[FieldOffset(8)]
		public float Duration;

		// Token: 0x04014CAE RID: 85166
		public const string __ObjectPath = "/Game/Aki/Data/Interaction/Struct/SInteractionLimit.SInteractionLimit";

		// Token: 0x04014CAF RID: 85167
		private static IntPtr _ScriptStructPtr;
	}
}
