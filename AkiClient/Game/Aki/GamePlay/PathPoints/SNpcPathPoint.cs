using System;
using System.Numerics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;

namespace AkiClient.Game.Aki.GamePlay.PathPoints
{
	// Token: 0x02003DCF RID: 15823
	[HasGetTypeHash]
	[UnrealBlittableStruct(UnrealReflectionPropertyTypeCode.UnrealBlittableStruct)]
	[UnrealStructLayout(24, 4, UnrealReflectionPropertyTypeCode.UnrealBlittableStruct, PropertiesSize = 24)]
	[UnrealObjectPath("/Game/Aki/GamePlay/PathPoints/SNpcPathPoint.SNpcPathPoint")]
	[StructLayout(LayoutKind.Explicit, Pack = 4, Size = 24)]
	public struct SNpcPathPoint : IEqualityOperators<SNpcPathPoint, SNpcPathPoint, bool>, IEquatable<SNpcPathPoint>, IUnrealScriptStruct
	{
		// Token: 0x06026C27 RID: 158759 RVA: 0x009E15A8 File Offset: 0x009DF7A8
		public SNpcPathPoint(FName LandName, FVector Position)
		{
			this.LandName = LandName;
			this.Position = Position;
		}

		// Token: 0x06026C28 RID: 158760 RVA: 0x009E15B8 File Offset: 0x009DF7B8
		public static bool operator ==(SNpcPathPoint left, SNpcPathPoint right)
		{
			return left.LandName == right.LandName && left.Position == right.Position;
		}

		// Token: 0x06026C29 RID: 158761 RVA: 0x009E15E0 File Offset: 0x009DF7E0
		public static bool operator !=(SNpcPathPoint left, SNpcPathPoint right)
		{
			return !(left == right);
		}

		// Token: 0x06026C2A RID: 158762 RVA: 0x009E15EC File Offset: 0x009DF7EC
		public bool Equals(SNpcPathPoint other)
		{
			return this == other;
		}

		// Token: 0x06026C2B RID: 158763 RVA: 0x009E15FC File Offset: 0x009DF7FC
		[NullableContext(2)]
		public override bool Equals(object obj)
		{
			if (obj is SNpcPathPoint)
			{
				SNpcPathPoint other = (SNpcPathPoint)obj;
				return this.Equals(other);
			}
			return false;
		}

		// Token: 0x06026C2C RID: 158764 RVA: 0x009E1621 File Offset: 0x009DF821
		public override int GetHashCode()
		{
			return HashCode.Combine<FName, FVector>(this.LandName, this.Position);
		}

		// Token: 0x06026C2D RID: 158765 RVA: 0x009E1634 File Offset: 0x009DF834
		public static UScriptStructStackOnlyPtr StaticStruct()
		{
			return (SNpcPathPoint._ScriptStructPtr != 0) ? SNpcPathPoint._ScriptStructPtr : UObjectGlobals.StaticLoadScriptStruct("/Game/Aki/GamePlay/PathPoints/SNpcPathPoint.SNpcPathPoint", ref SNpcPathPoint._ScriptStructPtr);
		}

		// Token: 0x0401436B RID: 82795
		[FieldOffset(0)]
		public FName LandName;

		// Token: 0x0401436C RID: 82796
		[FieldOffset(12)]
		public FVector Position;

		// Token: 0x0401436D RID: 82797
		public const string __ObjectPath = "/Game/Aki/GamePlay/PathPoints/SNpcPathPoint.SNpcPathPoint";

		// Token: 0x0401436E RID: 82798
		private static IntPtr _ScriptStructPtr;
	}
}
