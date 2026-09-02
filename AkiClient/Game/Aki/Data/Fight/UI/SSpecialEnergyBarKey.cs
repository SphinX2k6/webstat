using System;
using System.Numerics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;

namespace AkiClient.Game.Aki.Data.Fight.UI
{
	// Token: 0x02003EC3 RID: 16067
	[HasGetTypeHash]
	[UnrealBlittableStruct(UnrealReflectionPropertyTypeCode.UnrealBlittableStruct)]
	[UnrealStructLayout(8, 4, UnrealReflectionPropertyTypeCode.UnrealBlittableStruct, PropertiesSize = 8)]
	[UnrealObjectPath("/Game/Aki/Data/Fight/UI/SSpecialEnergyBarKey.SSpecialEnergyBarKey")]
	[StructLayout(LayoutKind.Explicit, Pack = 4, Size = 8)]
	public struct SSpecialEnergyBarKey : IEqualityOperators<SSpecialEnergyBarKey, SSpecialEnergyBarKey, bool>, IEquatable<SSpecialEnergyBarKey>, IUnrealScriptStruct
	{
		// Token: 0x06027E9B RID: 163483 RVA: 0x009FDC06 File Offset: 0x009FBE06
		public SSpecialEnergyBarKey(int Action, int ActionType)
		{
			this.Action = Action;
			this.ActionType = ActionType;
		}

		// Token: 0x06027E9C RID: 163484 RVA: 0x009FDC16 File Offset: 0x009FBE16
		public static bool operator ==(SSpecialEnergyBarKey left, SSpecialEnergyBarKey right)
		{
			return left.Action == right.Action && left.ActionType == right.ActionType;
		}

		// Token: 0x06027E9D RID: 163485 RVA: 0x009FDC36 File Offset: 0x009FBE36
		public static bool operator !=(SSpecialEnergyBarKey left, SSpecialEnergyBarKey right)
		{
			return !(left == right);
		}

		// Token: 0x06027E9E RID: 163486 RVA: 0x009FDC42 File Offset: 0x009FBE42
		public bool Equals(SSpecialEnergyBarKey other)
		{
			return this == other;
		}

		// Token: 0x06027E9F RID: 163487 RVA: 0x009FDC50 File Offset: 0x009FBE50
		[NullableContext(2)]
		public override bool Equals(object obj)
		{
			if (obj is SSpecialEnergyBarKey)
			{
				SSpecialEnergyBarKey other = (SSpecialEnergyBarKey)obj;
				return this.Equals(other);
			}
			return false;
		}

		// Token: 0x06027EA0 RID: 163488 RVA: 0x009FDC75 File Offset: 0x009FBE75
		public override int GetHashCode()
		{
			return HashCode.Combine<int, int>(this.Action, this.ActionType);
		}

		// Token: 0x06027EA1 RID: 163489 RVA: 0x009FDC88 File Offset: 0x009FBE88
		public static UScriptStructStackOnlyPtr StaticStruct()
		{
			return (SSpecialEnergyBarKey._ScriptStructPtr != 0) ? SSpecialEnergyBarKey._ScriptStructPtr : UObjectGlobals.StaticLoadScriptStruct("/Game/Aki/Data/Fight/UI/SSpecialEnergyBarKey.SSpecialEnergyBarKey", ref SSpecialEnergyBarKey._ScriptStructPtr);
		}

		// Token: 0x04014F3C RID: 85820
		[FieldOffset(0)]
		public int Action;

		// Token: 0x04014F3D RID: 85821
		[FieldOffset(4)]
		public int ActionType;

		// Token: 0x04014F3E RID: 85822
		public const string __ObjectPath = "/Game/Aki/Data/Fight/UI/SSpecialEnergyBarKey.SSpecialEnergyBarKey";

		// Token: 0x04014F3F RID: 85823
		private static IntPtr _ScriptStructPtr;
	}
}
