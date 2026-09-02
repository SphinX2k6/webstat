using System;
using System.Numerics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;

namespace AkiClient.Game.Aki.Data.Fight.Struct
{
	// Token: 0x02003ECF RID: 16079
	[HasGetTypeHash]
	[UnrealBlittableStruct(UnrealReflectionPropertyTypeCode.UnrealBlittableStruct)]
	[UnrealStructLayout(32, 8, UnrealReflectionPropertyTypeCode.UnrealBlittableStruct, PropertiesSize = 32)]
	[UnrealObjectPath("/Game/Aki/Data/Fight/Struct/SGravityHookLockInfo.SGravityHookLockInfo")]
	[StructLayout(LayoutKind.Explicit, Pack = 8, Size = 32)]
	public struct SGravityHookLockInfo : IEqualityOperators<SGravityHookLockInfo, SGravityHookLockInfo, bool>, IEquatable<SGravityHookLockInfo>, IUnrealScriptStruct
	{
		// Token: 0x06027F60 RID: 163680 RVA: 0x009FF1B3 File Offset: 0x009FD3B3
		public SGravityHookLockInfo(bool IsValid, FVectorDouble Location)
		{
			this.IsValid = IsValid;
			this.Location = Location;
		}

		// Token: 0x06027F61 RID: 163681 RVA: 0x009FF1C3 File Offset: 0x009FD3C3
		public static bool operator ==(SGravityHookLockInfo left, SGravityHookLockInfo right)
		{
			return left.IsValid == right.IsValid && left.Location == right.Location;
		}

		// Token: 0x06027F62 RID: 163682 RVA: 0x009FF1E6 File Offset: 0x009FD3E6
		public static bool operator !=(SGravityHookLockInfo left, SGravityHookLockInfo right)
		{
			return !(left == right);
		}

		// Token: 0x06027F63 RID: 163683 RVA: 0x009FF1F2 File Offset: 0x009FD3F2
		public bool Equals(SGravityHookLockInfo other)
		{
			return this == other;
		}

		// Token: 0x06027F64 RID: 163684 RVA: 0x009FF200 File Offset: 0x009FD400
		[NullableContext(2)]
		public override bool Equals(object obj)
		{
			if (obj is SGravityHookLockInfo)
			{
				SGravityHookLockInfo other = (SGravityHookLockInfo)obj;
				return this.Equals(other);
			}
			return false;
		}

		// Token: 0x06027F65 RID: 163685 RVA: 0x009FF225 File Offset: 0x009FD425
		public override int GetHashCode()
		{
			return HashCode.Combine<bool, FVectorDouble>(this.IsValid, this.Location);
		}

		// Token: 0x06027F66 RID: 163686 RVA: 0x009FF238 File Offset: 0x009FD438
		public static UScriptStructStackOnlyPtr StaticStruct()
		{
			return (SGravityHookLockInfo._ScriptStructPtr != 0) ? SGravityHookLockInfo._ScriptStructPtr : UObjectGlobals.StaticLoadScriptStruct("/Game/Aki/Data/Fight/Struct/SGravityHookLockInfo.SGravityHookLockInfo", ref SGravityHookLockInfo._ScriptStructPtr);
		}

		// Token: 0x04014FB0 RID: 85936
		[FieldOffset(0)]
		public bool IsValid;

		// Token: 0x04014FB1 RID: 85937
		[FieldOffset(8)]
		public FVectorDouble Location;

		// Token: 0x04014FB2 RID: 85938
		public const string __ObjectPath = "/Game/Aki/Data/Fight/Struct/SGravityHookLockInfo.SGravityHookLockInfo";

		// Token: 0x04014FB3 RID: 85939
		private static IntPtr _ScriptStructPtr;
	}
}
