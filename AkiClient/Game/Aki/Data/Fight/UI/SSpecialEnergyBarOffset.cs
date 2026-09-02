using System;
using System.Numerics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;

namespace AkiClient.Game.Aki.Data.Fight.UI
{
	// Token: 0x02003EC4 RID: 16068
	[HasGetTypeHash]
	[UnrealBlittableStruct(UnrealReflectionPropertyTypeCode.UnrealBlittableStruct)]
	[UnrealStructLayout(24, 4, UnrealReflectionPropertyTypeCode.UnrealBlittableStruct, PropertiesSize = 24)]
	[UnrealObjectPath("/Game/Aki/Data/Fight/UI/SSpecialEnergyBarOffset.SSpecialEnergyBarOffset")]
	[StructLayout(LayoutKind.Explicit, Pack = 4, Size = 24)]
	public struct SSpecialEnergyBarOffset : IEqualityOperators<SSpecialEnergyBarOffset, SSpecialEnergyBarOffset, bool>, IEquatable<SSpecialEnergyBarOffset>, IUnrealScriptStruct
	{
		// Token: 0x06027EA2 RID: 163490 RVA: 0x009FDCAC File Offset: 0x009FBEAC
		public SSpecialEnergyBarOffset(int MinPercent, int MaxPercent, int MinOffsetX, int MinOffsetY, int MaxOffsetX, int MaxOffsetY)
		{
			this.MinPercent = MinPercent;
			this.MaxPercent = MaxPercent;
			this.MinOffsetX = MinOffsetX;
			this.MinOffsetY = MinOffsetY;
			this.MaxOffsetX = MaxOffsetX;
			this.MaxOffsetY = MaxOffsetY;
		}

		// Token: 0x06027EA3 RID: 163491 RVA: 0x009FDCDC File Offset: 0x009FBEDC
		public static bool operator ==(SSpecialEnergyBarOffset left, SSpecialEnergyBarOffset right)
		{
			return left.MinPercent == right.MinPercent && left.MaxPercent == right.MaxPercent && left.MinOffsetX == right.MinOffsetX && left.MinOffsetY == right.MinOffsetY && left.MaxOffsetX == right.MaxOffsetX && left.MaxOffsetY == right.MaxOffsetY;
		}

		// Token: 0x06027EA4 RID: 163492 RVA: 0x009FDD3F File Offset: 0x009FBF3F
		public static bool operator !=(SSpecialEnergyBarOffset left, SSpecialEnergyBarOffset right)
		{
			return !(left == right);
		}

		// Token: 0x06027EA5 RID: 163493 RVA: 0x009FDD4B File Offset: 0x009FBF4B
		public bool Equals(SSpecialEnergyBarOffset other)
		{
			return this == other;
		}

		// Token: 0x06027EA6 RID: 163494 RVA: 0x009FDD5C File Offset: 0x009FBF5C
		[NullableContext(2)]
		public override bool Equals(object obj)
		{
			if (obj is SSpecialEnergyBarOffset)
			{
				SSpecialEnergyBarOffset other = (SSpecialEnergyBarOffset)obj;
				return this.Equals(other);
			}
			return false;
		}

		// Token: 0x06027EA7 RID: 163495 RVA: 0x009FDD81 File Offset: 0x009FBF81
		public override int GetHashCode()
		{
			return HashCode.Combine<int, int, int, int, int, int>(this.MinPercent, this.MaxPercent, this.MinOffsetX, this.MinOffsetY, this.MaxOffsetX, this.MaxOffsetY);
		}

		// Token: 0x06027EA8 RID: 163496 RVA: 0x009FDDAC File Offset: 0x009FBFAC
		public static UScriptStructStackOnlyPtr StaticStruct()
		{
			return (SSpecialEnergyBarOffset._ScriptStructPtr != 0) ? SSpecialEnergyBarOffset._ScriptStructPtr : UObjectGlobals.StaticLoadScriptStruct("/Game/Aki/Data/Fight/UI/SSpecialEnergyBarOffset.SSpecialEnergyBarOffset", ref SSpecialEnergyBarOffset._ScriptStructPtr);
		}

		// Token: 0x04014F40 RID: 85824
		[FieldOffset(0)]
		public int MinPercent;

		// Token: 0x04014F41 RID: 85825
		[FieldOffset(4)]
		public int MaxPercent;

		// Token: 0x04014F42 RID: 85826
		[FieldOffset(8)]
		public int MinOffsetX;

		// Token: 0x04014F43 RID: 85827
		[FieldOffset(12)]
		public int MinOffsetY;

		// Token: 0x04014F44 RID: 85828
		[FieldOffset(16)]
		public int MaxOffsetX;

		// Token: 0x04014F45 RID: 85829
		[FieldOffset(20)]
		public int MaxOffsetY;

		// Token: 0x04014F46 RID: 85830
		public const string __ObjectPath = "/Game/Aki/Data/Fight/UI/SSpecialEnergyBarOffset.SSpecialEnergyBarOffset";

		// Token: 0x04014F47 RID: 85831
		private static IntPtr _ScriptStructPtr;
	}
}
