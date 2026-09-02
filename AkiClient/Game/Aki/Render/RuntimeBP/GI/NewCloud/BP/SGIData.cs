using System;
using System.Numerics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;

namespace AkiClient.Game.Aki.Render.RuntimeBP.GI.NewCloud.BP
{
	// Token: 0x02003CCF RID: 15567
	[HasGetTypeHash]
	[UnrealBlittableStruct(UnrealReflectionPropertyTypeCode.UnrealBlittableStruct)]
	[UnrealStructLayout(4, 4, UnrealReflectionPropertyTypeCode.UnrealBlittableStruct, PropertiesSize = 4)]
	[UnrealObjectPath("/Game/Aki/Render/RuntimeBP/GI/NewCloud/BP/SGIData.SGIData")]
	[StructLayout(LayoutKind.Explicit, Pack = 4, Size = 4)]
	public struct SGIData : IEqualityOperators<SGIData, SGIData, bool>, IEquatable<SGIData>, IUnrealScriptStruct
	{
		// Token: 0x060251CD RID: 152013 RVA: 0x009B1368 File Offset: 0x009AF568
		public SGIData(float Time)
		{
			this.Time = Time;
		}

		// Token: 0x060251CE RID: 152014 RVA: 0x009B1371 File Offset: 0x009AF571
		public static bool operator ==(SGIData left, SGIData right)
		{
			return left.Time == right.Time;
		}

		// Token: 0x060251CF RID: 152015 RVA: 0x009B1381 File Offset: 0x009AF581
		public static bool operator !=(SGIData left, SGIData right)
		{
			return !(left == right);
		}

		// Token: 0x060251D0 RID: 152016 RVA: 0x009B138D File Offset: 0x009AF58D
		public bool Equals(SGIData other)
		{
			return this == other;
		}

		// Token: 0x060251D1 RID: 152017 RVA: 0x009B139C File Offset: 0x009AF59C
		[NullableContext(2)]
		public override bool Equals(object obj)
		{
			if (obj is SGIData)
			{
				SGIData other = (SGIData)obj;
				return this.Equals(other);
			}
			return false;
		}

		// Token: 0x060251D2 RID: 152018 RVA: 0x009B13C1 File Offset: 0x009AF5C1
		public override int GetHashCode()
		{
			return HashCode.Combine<float>(this.Time);
		}

		// Token: 0x060251D3 RID: 152019 RVA: 0x009B13CE File Offset: 0x009AF5CE
		public static UScriptStructStackOnlyPtr StaticStruct()
		{
			return (SGIData._ScriptStructPtr != 0) ? SGIData._ScriptStructPtr : UObjectGlobals.StaticLoadScriptStruct("/Game/Aki/Render/RuntimeBP/GI/NewCloud/BP/SGIData.SGIData", ref SGIData._ScriptStructPtr);
		}

		// Token: 0x040131AE RID: 78254
		[FieldOffset(0)]
		public float Time;

		// Token: 0x040131AF RID: 78255
		public const string __ObjectPath = "/Game/Aki/Render/RuntimeBP/GI/NewCloud/BP/SGIData.SGIData";

		// Token: 0x040131B0 RID: 78256
		private static IntPtr _ScriptStructPtr;
	}
}
