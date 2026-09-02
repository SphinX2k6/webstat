using System;
using System.Numerics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;

namespace AkiClient.Game.Aki.Character.BaseCharacter.Camera
{
	// Token: 0x02004311 RID: 17169
	[HasGetTypeHash]
	[UnrealBlittableStruct(UnrealReflectionPropertyTypeCode.UnrealBlittableStruct)]
	[UnrealStructLayout(40, 4, UnrealReflectionPropertyTypeCode.UnrealBlittableStruct, PropertiesSize = 40)]
	[UnrealObjectPath("/Game/Aki/Character/BaseCharacter/Camera/SCameraModifier_Lens.SCameraModifier_Lens")]
	[StructLayout(LayoutKind.Explicit, Pack = 4, Size = 40)]
	public struct SCameraModifier_Lens : IEqualityOperators<SCameraModifier_Lens, SCameraModifier_Lens, bool>, IEquatable<SCameraModifier_Lens>, IUnrealScriptStruct
	{
		// Token: 0x0602D7C6 RID: 186310 RVA: 0x00AC1960 File Offset: 0x00ABFB60
		public SCameraModifier_Lens(float StartFStop, float EndFStop, float RadialBlurStartIntensity, float RadialBlurEndIntensity, FVector2D RadialBlurCenter, float RadialBlurRadius, float RadialBlurHardness, float RadialBlurPassNumber, float RadialBlurSampleNumber)
		{
			this.StartFStop = StartFStop;
			this.EndFStop = EndFStop;
			this.RadialBlurStartIntensity = RadialBlurStartIntensity;
			this.RadialBlurEndIntensity = RadialBlurEndIntensity;
			this.RadialBlurCenter = RadialBlurCenter;
			this.RadialBlurRadius = RadialBlurRadius;
			this.RadialBlurHardness = RadialBlurHardness;
			this.RadialBlurPassNumber = RadialBlurPassNumber;
			this.RadialBlurSampleNumber = RadialBlurSampleNumber;
		}

		// Token: 0x0602D7C7 RID: 186311 RVA: 0x00AC19B4 File Offset: 0x00ABFBB4
		public static bool operator ==(SCameraModifier_Lens left, SCameraModifier_Lens right)
		{
			return left.StartFStop == right.StartFStop && left.EndFStop == right.EndFStop && left.RadialBlurStartIntensity == right.RadialBlurStartIntensity && left.RadialBlurEndIntensity == right.RadialBlurEndIntensity && left.RadialBlurCenter == right.RadialBlurCenter && left.RadialBlurRadius == right.RadialBlurRadius && left.RadialBlurHardness == right.RadialBlurHardness && left.RadialBlurPassNumber == right.RadialBlurPassNumber && left.RadialBlurSampleNumber == right.RadialBlurSampleNumber;
		}

		// Token: 0x0602D7C8 RID: 186312 RVA: 0x00AC1A46 File Offset: 0x00ABFC46
		public static bool operator !=(SCameraModifier_Lens left, SCameraModifier_Lens right)
		{
			return !(left == right);
		}

		// Token: 0x0602D7C9 RID: 186313 RVA: 0x00AC1A52 File Offset: 0x00ABFC52
		public bool Equals(SCameraModifier_Lens other)
		{
			return this == other;
		}

		// Token: 0x0602D7CA RID: 186314 RVA: 0x00AC1A60 File Offset: 0x00ABFC60
		[NullableContext(2)]
		public override bool Equals(object obj)
		{
			if (obj is SCameraModifier_Lens)
			{
				SCameraModifier_Lens other = (SCameraModifier_Lens)obj;
				return this.Equals(other);
			}
			return false;
		}

		// Token: 0x0602D7CB RID: 186315 RVA: 0x00AC1A88 File Offset: 0x00ABFC88
		public override int GetHashCode()
		{
			HashCode hashCode = default(HashCode);
			hashCode.Add<float>(this.StartFStop);
			hashCode.Add<float>(this.EndFStop);
			hashCode.Add<float>(this.RadialBlurStartIntensity);
			hashCode.Add<float>(this.RadialBlurEndIntensity);
			hashCode.Add<FVector2D>(this.RadialBlurCenter);
			hashCode.Add<float>(this.RadialBlurRadius);
			hashCode.Add<float>(this.RadialBlurHardness);
			hashCode.Add<float>(this.RadialBlurPassNumber);
			hashCode.Add<float>(this.RadialBlurSampleNumber);
			return hashCode.ToHashCode();
		}

		// Token: 0x0602D7CC RID: 186316 RVA: 0x00AC1B19 File Offset: 0x00ABFD19
		public static UScriptStructStackOnlyPtr StaticStruct()
		{
			return (SCameraModifier_Lens._ScriptStructPtr != 0) ? SCameraModifier_Lens._ScriptStructPtr : UObjectGlobals.StaticLoadScriptStruct("/Game/Aki/Character/BaseCharacter/Camera/SCameraModifier_Lens.SCameraModifier_Lens", ref SCameraModifier_Lens._ScriptStructPtr);
		}

		// Token: 0x04019A5A RID: 105050
		[FieldOffset(0)]
		public float StartFStop;

		// Token: 0x04019A5B RID: 105051
		[FieldOffset(4)]
		public float EndFStop;

		// Token: 0x04019A5C RID: 105052
		[FieldOffset(8)]
		public float RadialBlurStartIntensity;

		// Token: 0x04019A5D RID: 105053
		[FieldOffset(12)]
		public float RadialBlurEndIntensity;

		// Token: 0x04019A5E RID: 105054
		[FieldOffset(16)]
		public FVector2D RadialBlurCenter;

		// Token: 0x04019A5F RID: 105055
		[FieldOffset(24)]
		public float RadialBlurRadius;

		// Token: 0x04019A60 RID: 105056
		[FieldOffset(28)]
		public float RadialBlurHardness;

		// Token: 0x04019A61 RID: 105057
		[FieldOffset(32)]
		public float RadialBlurPassNumber;

		// Token: 0x04019A62 RID: 105058
		[FieldOffset(36)]
		public float RadialBlurSampleNumber;

		// Token: 0x04019A63 RID: 105059
		public const string __ObjectPath = "/Game/Aki/Character/BaseCharacter/Camera/SCameraModifier_Lens.SCameraModifier_Lens";

		// Token: 0x04019A64 RID: 105060
		private static IntPtr _ScriptStructPtr;
	}
}
