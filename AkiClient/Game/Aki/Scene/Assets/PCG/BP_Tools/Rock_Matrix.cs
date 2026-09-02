using System;
using System.Numerics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;

namespace AkiClient.Game.Aki.Scene.Assets.PCG.BP_Tools
{
	// Token: 0x020039EE RID: 14830
	[HasGetTypeHash]
	[UnrealBlittableStruct(UnrealReflectionPropertyTypeCode.UnrealBlittableStruct)]
	[UnrealStructLayout(24, 4, UnrealReflectionPropertyTypeCode.UnrealBlittableStruct, PropertiesSize = 24)]
	[UnrealObjectPath("/Game/Aki/Scene/Assets/PCG/BP_Tools/Rock_Matrix.Rock_Matrix")]
	[StructLayout(LayoutKind.Explicit, Pack = 4, Size = 24)]
	public struct Rock_Matrix : IEqualityOperators<Rock_Matrix, Rock_Matrix, bool>, IEquatable<Rock_Matrix>, IUnrealScriptStruct
	{
		// Token: 0x0601E131 RID: 123185 RVA: 0x008EB0F5 File Offset: 0x008E92F5
		public Rock_Matrix(float m_xx, float m_xy, float m_xz, float m_yy, float m_yz, float m_zz)
		{
			this.m_xx = m_xx;
			this.m_xy = m_xy;
			this.m_xz = m_xz;
			this.m_yy = m_yy;
			this.m_yz = m_yz;
			this.m_zz = m_zz;
		}

		// Token: 0x0601E132 RID: 123186 RVA: 0x008EB124 File Offset: 0x008E9324
		public static bool operator ==(Rock_Matrix left, Rock_Matrix right)
		{
			return left.m_xx == right.m_xx && left.m_xy == right.m_xy && left.m_xz == right.m_xz && left.m_yy == right.m_yy && left.m_yz == right.m_yz && left.m_zz == right.m_zz;
		}

		// Token: 0x0601E133 RID: 123187 RVA: 0x008EB187 File Offset: 0x008E9387
		public static bool operator !=(Rock_Matrix left, Rock_Matrix right)
		{
			return !(left == right);
		}

		// Token: 0x0601E134 RID: 123188 RVA: 0x008EB193 File Offset: 0x008E9393
		public bool Equals(Rock_Matrix other)
		{
			return this == other;
		}

		// Token: 0x0601E135 RID: 123189 RVA: 0x008EB1A4 File Offset: 0x008E93A4
		[NullableContext(2)]
		public override bool Equals(object obj)
		{
			if (obj is Rock_Matrix)
			{
				Rock_Matrix other = (Rock_Matrix)obj;
				return this.Equals(other);
			}
			return false;
		}

		// Token: 0x0601E136 RID: 123190 RVA: 0x008EB1C9 File Offset: 0x008E93C9
		public override int GetHashCode()
		{
			return HashCode.Combine<float, float, float, float, float, float>(this.m_xx, this.m_xy, this.m_xz, this.m_yy, this.m_yz, this.m_zz);
		}

		// Token: 0x0601E137 RID: 123191 RVA: 0x008EB1F4 File Offset: 0x008E93F4
		public static UScriptStructStackOnlyPtr StaticStruct()
		{
			return (Rock_Matrix._ScriptStructPtr != 0) ? Rock_Matrix._ScriptStructPtr : UObjectGlobals.StaticLoadScriptStruct("/Game/Aki/Scene/Assets/PCG/BP_Tools/Rock_Matrix.Rock_Matrix", ref Rock_Matrix._ScriptStructPtr);
		}

		// Token: 0x0400EC26 RID: 60454
		[FieldOffset(0)]
		public float m_xx;

		// Token: 0x0400EC27 RID: 60455
		[FieldOffset(4)]
		public float m_xy;

		// Token: 0x0400EC28 RID: 60456
		[FieldOffset(8)]
		public float m_xz;

		// Token: 0x0400EC29 RID: 60457
		[FieldOffset(12)]
		public float m_yy;

		// Token: 0x0400EC2A RID: 60458
		[FieldOffset(16)]
		public float m_yz;

		// Token: 0x0400EC2B RID: 60459
		[FieldOffset(20)]
		public float m_zz;

		// Token: 0x0400EC2C RID: 60460
		public const string __ObjectPath = "/Game/Aki/Scene/Assets/PCG/BP_Tools/Rock_Matrix.Rock_Matrix";

		// Token: 0x0400EC2D RID: 60461
		private static IntPtr _ScriptStructPtr;
	}
}
