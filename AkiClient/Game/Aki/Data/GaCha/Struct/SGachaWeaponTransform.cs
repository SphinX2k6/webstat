using System;
using System.Numerics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;

namespace AkiClient.Game.Aki.Data.GaCha.Struct
{
	// Token: 0x02003EB5 RID: 16053
	[HasGetTypeHash]
	[UnrealBlittableStruct(UnrealReflectionPropertyTypeCode.UnrealBlittableStruct)]
	[UnrealStructLayout(72, 4, UnrealReflectionPropertyTypeCode.UnrealBlittableStruct, PropertiesSize = 72)]
	[UnrealObjectPath("/Game/Aki/Data/GaCha/Struct/SGachaWeaponTransform.SGachaWeaponTransform")]
	[StructLayout(LayoutKind.Explicit, Pack = 4, Size = 72)]
	public struct SGachaWeaponTransform : IEqualityOperators<SGachaWeaponTransform, SGachaWeaponTransform, bool>, IEquatable<SGachaWeaponTransform>, IUnrealScriptStruct
	{
		// Token: 0x06027DCF RID: 163279 RVA: 0x009FC5FC File Offset: 0x009FA7FC
		public SGachaWeaponTransform(FVector Location, FVector Rotation, float Size, float RotateTime, FVector ScabbardOffset, bool ShowScabbard, FVector AxisRotate, FVector ScabbardRotationOffset)
		{
			this.Location = Location;
			this.Rotation = Rotation;
			this.Size = Size;
			this.RotateTime = RotateTime;
			this.ScabbardOffset = ScabbardOffset;
			this.ShowScabbard = ShowScabbard;
			this.AxisRotate = AxisRotate;
			this.ScabbardRotationOffset = ScabbardRotationOffset;
		}

		// Token: 0x06027DD0 RID: 163280 RVA: 0x009FC63C File Offset: 0x009FA83C
		public static bool operator ==(SGachaWeaponTransform left, SGachaWeaponTransform right)
		{
			return left.Location == right.Location && left.Rotation == right.Rotation && left.Size == right.Size && left.RotateTime == right.RotateTime && left.ScabbardOffset == right.ScabbardOffset && left.ShowScabbard == right.ShowScabbard && left.AxisRotate == right.AxisRotate && left.ScabbardRotationOffset == right.ScabbardRotationOffset;
		}

		// Token: 0x06027DD1 RID: 163281 RVA: 0x009FC6D2 File Offset: 0x009FA8D2
		public static bool operator !=(SGachaWeaponTransform left, SGachaWeaponTransform right)
		{
			return !(left == right);
		}

		// Token: 0x06027DD2 RID: 163282 RVA: 0x009FC6DE File Offset: 0x009FA8DE
		public bool Equals(SGachaWeaponTransform other)
		{
			return this == other;
		}

		// Token: 0x06027DD3 RID: 163283 RVA: 0x009FC6EC File Offset: 0x009FA8EC
		[NullableContext(2)]
		public override bool Equals(object obj)
		{
			if (obj is SGachaWeaponTransform)
			{
				SGachaWeaponTransform other = (SGachaWeaponTransform)obj;
				return this.Equals(other);
			}
			return false;
		}

		// Token: 0x06027DD4 RID: 163284 RVA: 0x009FC711 File Offset: 0x009FA911
		public override int GetHashCode()
		{
			return HashCode.Combine<FVector, FVector, float, float, FVector, bool, FVector, FVector>(this.Location, this.Rotation, this.Size, this.RotateTime, this.ScabbardOffset, this.ShowScabbard, this.AxisRotate, this.ScabbardRotationOffset);
		}

		// Token: 0x06027DD5 RID: 163285 RVA: 0x009FC748 File Offset: 0x009FA948
		public static UScriptStructStackOnlyPtr StaticStruct()
		{
			return (SGachaWeaponTransform._ScriptStructPtr != 0) ? SGachaWeaponTransform._ScriptStructPtr : UObjectGlobals.StaticLoadScriptStruct("/Game/Aki/Data/GaCha/Struct/SGachaWeaponTransform.SGachaWeaponTransform", ref SGachaWeaponTransform._ScriptStructPtr);
		}

		// Token: 0x04014EB4 RID: 85684
		[FieldOffset(0)]
		public FVector Location;

		// Token: 0x04014EB5 RID: 85685
		[FieldOffset(12)]
		public FVector Rotation;

		// Token: 0x04014EB6 RID: 85686
		[FieldOffset(24)]
		public float Size;

		// Token: 0x04014EB7 RID: 85687
		[FieldOffset(28)]
		public float RotateTime;

		// Token: 0x04014EB8 RID: 85688
		[FieldOffset(32)]
		public FVector ScabbardOffset;

		// Token: 0x04014EB9 RID: 85689
		[FieldOffset(44)]
		public bool ShowScabbard;

		// Token: 0x04014EBA RID: 85690
		[FieldOffset(48)]
		public FVector AxisRotate;

		// Token: 0x04014EBB RID: 85691
		[FieldOffset(60)]
		public FVector ScabbardRotationOffset;

		// Token: 0x04014EBC RID: 85692
		public const string __ObjectPath = "/Game/Aki/Data/GaCha/Struct/SGachaWeaponTransform.SGachaWeaponTransform";

		// Token: 0x04014EBD RID: 85693
		private static IntPtr _ScriptStructPtr;
	}
}
