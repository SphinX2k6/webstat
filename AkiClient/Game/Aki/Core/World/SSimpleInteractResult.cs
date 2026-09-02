using System;
using System.Numerics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;

namespace AkiClient.Game.Aki.Core.World
{
	// Token: 0x02003F45 RID: 16197
	[UnrealBlittableStruct(UnrealReflectionPropertyTypeCode.UnrealBlittableStruct)]
	[UnrealStructLayout(32, 4, UnrealReflectionPropertyTypeCode.UnrealBlittableStruct, PropertiesSize = 29)]
	[UnrealObjectPath("/Game/Aki/Core/World/SSimpleInteractResult.SSimpleInteractResult")]
	[StructLayout(LayoutKind.Explicit, Pack = 4, Size = 32)]
	public struct SSimpleInteractResult : IEqualityOperators<SSimpleInteractResult, SSimpleInteractResult, bool>, IEquatable<SSimpleInteractResult>, IUnrealScriptStruct
	{
		// Token: 0x06028713 RID: 165651 RVA: 0x00A0B0A2 File Offset: 0x00A092A2
		public SSimpleInteractResult(FVector Location, FRotator Rotator, float SquaredOffsetLength, bool Success)
		{
			this.Location = Location;
			this.Rotator = Rotator;
			this.SquaredOffsetLength = SquaredOffsetLength;
			this.Success = Success;
		}

		// Token: 0x06028714 RID: 165652 RVA: 0x00A0B0C4 File Offset: 0x00A092C4
		public static bool operator ==(SSimpleInteractResult left, SSimpleInteractResult right)
		{
			return left.Location == right.Location && left.Rotator == right.Rotator && left.SquaredOffsetLength == right.SquaredOffsetLength && left.Success == right.Success;
		}

		// Token: 0x06028715 RID: 165653 RVA: 0x00A0B115 File Offset: 0x00A09315
		public static bool operator !=(SSimpleInteractResult left, SSimpleInteractResult right)
		{
			return !(left == right);
		}

		// Token: 0x06028716 RID: 165654 RVA: 0x00A0B121 File Offset: 0x00A09321
		public bool Equals(SSimpleInteractResult other)
		{
			return this == other;
		}

		// Token: 0x06028717 RID: 165655 RVA: 0x00A0B130 File Offset: 0x00A09330
		[NullableContext(2)]
		public override bool Equals(object obj)
		{
			if (obj is SSimpleInteractResult)
			{
				SSimpleInteractResult other = (SSimpleInteractResult)obj;
				return this.Equals(other);
			}
			return false;
		}

		// Token: 0x06028718 RID: 165656 RVA: 0x00A0B155 File Offset: 0x00A09355
		public override int GetHashCode()
		{
			return HashCode.Combine<FVector, FRotator, float, bool>(this.Location, this.Rotator, this.SquaredOffsetLength, this.Success);
		}

		// Token: 0x06028719 RID: 165657 RVA: 0x00A0B174 File Offset: 0x00A09374
		public static UScriptStructStackOnlyPtr StaticStruct()
		{
			return (SSimpleInteractResult._ScriptStructPtr != 0) ? SSimpleInteractResult._ScriptStructPtr : UObjectGlobals.StaticLoadScriptStruct("/Game/Aki/Core/World/SSimpleInteractResult.SSimpleInteractResult", ref SSimpleInteractResult._ScriptStructPtr);
		}

		// Token: 0x04015469 RID: 87145
		[FieldOffset(0)]
		public FVector Location;

		// Token: 0x0401546A RID: 87146
		[FieldOffset(12)]
		public FRotator Rotator;

		// Token: 0x0401546B RID: 87147
		[FieldOffset(24)]
		public float SquaredOffsetLength;

		// Token: 0x0401546C RID: 87148
		[FieldOffset(28)]
		public bool Success;

		// Token: 0x0401546D RID: 87149
		public const string __ObjectPath = "/Game/Aki/Core/World/SSimpleInteractResult.SSimpleInteractResult";

		// Token: 0x0401546E RID: 87150
		private static IntPtr _ScriptStructPtr;
	}
}
