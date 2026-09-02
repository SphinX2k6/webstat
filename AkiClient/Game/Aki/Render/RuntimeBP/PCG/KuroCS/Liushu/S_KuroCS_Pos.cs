using System;
using System.Numerics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;

namespace AkiClient.Game.Aki.Render.RuntimeBP.PCG.KuroCS.Liushu
{
	// Token: 0x02003BFB RID: 15355
	[HasGetTypeHash]
	[UnrealBlittableStruct(UnrealReflectionPropertyTypeCode.UnrealBlittableStruct)]
	[UnrealStructLayout(28, 4, UnrealReflectionPropertyTypeCode.UnrealBlittableStruct, PropertiesSize = 25)]
	[UnrealObjectPath("/Game/Aki/Render/RuntimeBP/PCG/KuroCS/Liushu/S_KuroCS_Pos.S_KuroCS_Pos")]
	[StructLayout(LayoutKind.Explicit, Pack = 4, Size = 28)]
	public struct S_KuroCS_Pos : IEqualityOperators<S_KuroCS_Pos, S_KuroCS_Pos, bool>, IEquatable<S_KuroCS_Pos>, IUnrealScriptStruct
	{
		// Token: 0x06022BE9 RID: 142313 RVA: 0x0096DB83 File Offset: 0x0096BD83
		public S_KuroCS_Pos(float X, float Y, float Z, int IDA, int IDB, float percent, bool hardPoint)
		{
			this.X = X;
			this.Y = Y;
			this.Z = Z;
			this.IDA = IDA;
			this.IDB = IDB;
			this.percent = percent;
			this.hardPoint = hardPoint;
		}

		// Token: 0x06022BEA RID: 142314 RVA: 0x0096DBBC File Offset: 0x0096BDBC
		public static bool operator ==(S_KuroCS_Pos left, S_KuroCS_Pos right)
		{
			return left.X == right.X && left.Y == right.Y && left.Z == right.Z && left.IDA == right.IDA && left.IDB == right.IDB && left.percent == right.percent && left.hardPoint == right.hardPoint;
		}

		// Token: 0x06022BEB RID: 142315 RVA: 0x0096DC2D File Offset: 0x0096BE2D
		public static bool operator !=(S_KuroCS_Pos left, S_KuroCS_Pos right)
		{
			return !(left == right);
		}

		// Token: 0x06022BEC RID: 142316 RVA: 0x0096DC39 File Offset: 0x0096BE39
		public bool Equals(S_KuroCS_Pos other)
		{
			return this == other;
		}

		// Token: 0x06022BED RID: 142317 RVA: 0x0096DC48 File Offset: 0x0096BE48
		[NullableContext(2)]
		public override bool Equals(object obj)
		{
			if (obj is S_KuroCS_Pos)
			{
				S_KuroCS_Pos other = (S_KuroCS_Pos)obj;
				return this.Equals(other);
			}
			return false;
		}

		// Token: 0x06022BEE RID: 142318 RVA: 0x0096DC6D File Offset: 0x0096BE6D
		public override int GetHashCode()
		{
			return HashCode.Combine<float, float, float, int, int, float, bool>(this.X, this.Y, this.Z, this.IDA, this.IDB, this.percent, this.hardPoint);
		}

		// Token: 0x06022BEF RID: 142319 RVA: 0x0096DC9E File Offset: 0x0096BE9E
		public static UScriptStructStackOnlyPtr StaticStruct()
		{
			return (S_KuroCS_Pos._ScriptStructPtr != 0) ? S_KuroCS_Pos._ScriptStructPtr : UObjectGlobals.StaticLoadScriptStruct("/Game/Aki/Render/RuntimeBP/PCG/KuroCS/Liushu/S_KuroCS_Pos.S_KuroCS_Pos", ref S_KuroCS_Pos._ScriptStructPtr);
		}

		// Token: 0x040119E6 RID: 72166
		[FieldOffset(0)]
		public float X;

		// Token: 0x040119E7 RID: 72167
		[FieldOffset(4)]
		public float Y;

		// Token: 0x040119E8 RID: 72168
		[FieldOffset(8)]
		public float Z;

		// Token: 0x040119E9 RID: 72169
		[FieldOffset(12)]
		public int IDA;

		// Token: 0x040119EA RID: 72170
		[FieldOffset(16)]
		public int IDB;

		// Token: 0x040119EB RID: 72171
		[FieldOffset(20)]
		public float percent;

		// Token: 0x040119EC RID: 72172
		[FieldOffset(24)]
		public bool hardPoint;

		// Token: 0x040119ED RID: 72173
		public const string __ObjectPath = "/Game/Aki/Render/RuntimeBP/PCG/KuroCS/Liushu/S_KuroCS_Pos.S_KuroCS_Pos";

		// Token: 0x040119EE RID: 72174
		private static IntPtr _ScriptStructPtr;
	}
}
