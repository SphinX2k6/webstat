using System;
using System.Numerics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;

namespace AkiClient.Game.Aki.Scene.Assets.PCG.BP_Tools
{
	// Token: 0x020039EF RID: 14831
	[HasGetTypeHash]
	[UnrealBlittableStruct(UnrealReflectionPropertyTypeCode.UnrealBlittableStruct)]
	[UnrealStructLayout(12, 4, UnrealReflectionPropertyTypeCode.UnrealBlittableStruct, PropertiesSize = 12)]
	[UnrealObjectPath("/Game/Aki/Scene/Assets/PCG/BP_Tools/Rock_Matrix_3.Rock_Matrix_3")]
	[StructLayout(LayoutKind.Explicit, Pack = 4, Size = 12)]
	public struct Rock_Matrix_3 : IEqualityOperators<Rock_Matrix_3, Rock_Matrix_3, bool>, IEquatable<Rock_Matrix_3>, IUnrealScriptStruct
	{
		// Token: 0x0601E138 RID: 123192 RVA: 0x008EB218 File Offset: 0x008E9418
		public Rock_Matrix_3(float m_xy, float m_xz, float m_yz)
		{
			this.m_xy = m_xy;
			this.m_xz = m_xz;
			this.m_yz = m_yz;
		}

		// Token: 0x0601E139 RID: 123193 RVA: 0x008EB22F File Offset: 0x008E942F
		public static bool operator ==(Rock_Matrix_3 left, Rock_Matrix_3 right)
		{
			return left.m_xy == right.m_xy && left.m_xz == right.m_xz && left.m_yz == right.m_yz;
		}

		// Token: 0x0601E13A RID: 123194 RVA: 0x008EB25D File Offset: 0x008E945D
		public static bool operator !=(Rock_Matrix_3 left, Rock_Matrix_3 right)
		{
			return !(left == right);
		}

		// Token: 0x0601E13B RID: 123195 RVA: 0x008EB269 File Offset: 0x008E9469
		public bool Equals(Rock_Matrix_3 other)
		{
			return this == other;
		}

		// Token: 0x0601E13C RID: 123196 RVA: 0x008EB278 File Offset: 0x008E9478
		[NullableContext(2)]
		public override bool Equals(object obj)
		{
			if (obj is Rock_Matrix_3)
			{
				Rock_Matrix_3 other = (Rock_Matrix_3)obj;
				return this.Equals(other);
			}
			return false;
		}

		// Token: 0x0601E13D RID: 123197 RVA: 0x008EB29D File Offset: 0x008E949D
		public override int GetHashCode()
		{
			return HashCode.Combine<float, float, float>(this.m_xy, this.m_xz, this.m_yz);
		}

		// Token: 0x0601E13E RID: 123198 RVA: 0x008EB2B6 File Offset: 0x008E94B6
		public static UScriptStructStackOnlyPtr StaticStruct()
		{
			return (Rock_Matrix_3._ScriptStructPtr != 0) ? Rock_Matrix_3._ScriptStructPtr : UObjectGlobals.StaticLoadScriptStruct("/Game/Aki/Scene/Assets/PCG/BP_Tools/Rock_Matrix_3.Rock_Matrix_3", ref Rock_Matrix_3._ScriptStructPtr);
		}

		// Token: 0x0400EC2E RID: 60462
		[FieldOffset(0)]
		public float m_xy;

		// Token: 0x0400EC2F RID: 60463
		[FieldOffset(4)]
		public float m_xz;

		// Token: 0x0400EC30 RID: 60464
		[FieldOffset(8)]
		public float m_yz;

		// Token: 0x0400EC31 RID: 60465
		public const string __ObjectPath = "/Game/Aki/Scene/Assets/PCG/BP_Tools/Rock_Matrix_3.Rock_Matrix_3";

		// Token: 0x0400EC32 RID: 60466
		private static IntPtr _ScriptStructPtr;
	}
}
