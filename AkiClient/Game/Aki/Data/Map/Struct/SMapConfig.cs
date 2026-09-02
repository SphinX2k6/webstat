using System;
using System.Numerics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;

namespace AkiClient.Game.Aki.Data.Map.Struct
{
	// Token: 0x02003E64 RID: 15972
	[HasGetTypeHash]
	[UnrealBlittableStruct(UnrealReflectionPropertyTypeCode.UnrealBlittableStruct)]
	[UnrealStructLayout(16, 4, UnrealReflectionPropertyTypeCode.UnrealBlittableStruct, PropertiesSize = 16)]
	[UnrealObjectPath("/Game/Aki/Data/Map/Struct/SMapConfig.SMapConfig")]
	[StructLayout(LayoutKind.Explicit, Pack = 4, Size = 16)]
	public struct SMapConfig : IEqualityOperators<SMapConfig, SMapConfig, bool>, IEquatable<SMapConfig>, IUnrealScriptStruct
	{
		// Token: 0x060276E1 RID: 161505 RVA: 0x009F1A93 File Offset: 0x009EFC93
		public SMapConfig(int ID, FName MapPath)
		{
			this.ID = ID;
			this.MapPath = MapPath;
		}

		// Token: 0x060276E2 RID: 161506 RVA: 0x009F1AA3 File Offset: 0x009EFCA3
		public static bool operator ==(SMapConfig left, SMapConfig right)
		{
			return left.ID == right.ID && left.MapPath == right.MapPath;
		}

		// Token: 0x060276E3 RID: 161507 RVA: 0x009F1AC6 File Offset: 0x009EFCC6
		public static bool operator !=(SMapConfig left, SMapConfig right)
		{
			return !(left == right);
		}

		// Token: 0x060276E4 RID: 161508 RVA: 0x009F1AD2 File Offset: 0x009EFCD2
		public bool Equals(SMapConfig other)
		{
			return this == other;
		}

		// Token: 0x060276E5 RID: 161509 RVA: 0x009F1AE0 File Offset: 0x009EFCE0
		[NullableContext(2)]
		public override bool Equals(object obj)
		{
			if (obj is SMapConfig)
			{
				SMapConfig other = (SMapConfig)obj;
				return this.Equals(other);
			}
			return false;
		}

		// Token: 0x060276E6 RID: 161510 RVA: 0x009F1B05 File Offset: 0x009EFD05
		public override int GetHashCode()
		{
			return HashCode.Combine<int, FName>(this.ID, this.MapPath);
		}

		// Token: 0x060276E7 RID: 161511 RVA: 0x009F1B18 File Offset: 0x009EFD18
		public static UScriptStructStackOnlyPtr StaticStruct()
		{
			return (SMapConfig._ScriptStructPtr != 0) ? SMapConfig._ScriptStructPtr : UObjectGlobals.StaticLoadScriptStruct("/Game/Aki/Data/Map/Struct/SMapConfig.SMapConfig", ref SMapConfig._ScriptStructPtr);
		}

		// Token: 0x04014A68 RID: 84584
		[FieldOffset(0)]
		public int ID;

		// Token: 0x04014A69 RID: 84585
		[FieldOffset(4)]
		public FName MapPath;

		// Token: 0x04014A6A RID: 84586
		public const string __ObjectPath = "/Game/Aki/Data/Map/Struct/SMapConfig.SMapConfig";

		// Token: 0x04014A6B RID: 84587
		private static IntPtr _ScriptStructPtr;
	}
}
