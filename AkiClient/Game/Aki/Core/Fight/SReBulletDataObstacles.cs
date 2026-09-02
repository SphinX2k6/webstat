using System;
using System.Numerics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;

namespace AkiClient.Game.Aki.Core.Fight
{
	// Token: 0x02003F76 RID: 16246
	[HasGetTypeHash]
	[UnrealBlittableStruct(UnrealReflectionPropertyTypeCode.UnrealBlittableStruct)]
	[UnrealStructLayout(16, 4, UnrealReflectionPropertyTypeCode.UnrealBlittableStruct, PropertiesSize = 16)]
	[UnrealObjectPath("/Game/Aki/Core/Fight/SReBulletDataObstacles.SReBulletDataObstacles")]
	[StructLayout(LayoutKind.Explicit, Pack = 4, Size = 16)]
	public struct SReBulletDataObstacles : IEqualityOperators<SReBulletDataObstacles, SReBulletDataObstacles, bool>, IEquatable<SReBulletDataObstacles>, IUnrealScriptStruct
	{
		// Token: 0x060289BA RID: 166330 RVA: 0x00A1030C File Offset: 0x00A0E50C
		public SReBulletDataObstacles(FVector 检测位置, float 检测距离)
		{
			this.检测位置 = 检测位置;
			this.检测距离 = 检测距离;
		}

		// Token: 0x060289BB RID: 166331 RVA: 0x00A1031C File Offset: 0x00A0E51C
		public static bool operator ==(SReBulletDataObstacles left, SReBulletDataObstacles right)
		{
			return left.检测位置 == right.检测位置 && left.检测距离 == right.检测距离;
		}

		// Token: 0x060289BC RID: 166332 RVA: 0x00A10341 File Offset: 0x00A0E541
		public static bool operator !=(SReBulletDataObstacles left, SReBulletDataObstacles right)
		{
			return !(left == right);
		}

		// Token: 0x060289BD RID: 166333 RVA: 0x00A1034D File Offset: 0x00A0E54D
		public bool Equals(SReBulletDataObstacles other)
		{
			return this == other;
		}

		// Token: 0x060289BE RID: 166334 RVA: 0x00A1035C File Offset: 0x00A0E55C
		[NullableContext(2)]
		public override bool Equals(object obj)
		{
			if (obj is SReBulletDataObstacles)
			{
				SReBulletDataObstacles other = (SReBulletDataObstacles)obj;
				return this.Equals(other);
			}
			return false;
		}

		// Token: 0x060289BF RID: 166335 RVA: 0x00A10381 File Offset: 0x00A0E581
		public override int GetHashCode()
		{
			return HashCode.Combine<FVector, float>(this.检测位置, this.检测距离);
		}

		// Token: 0x060289C0 RID: 166336 RVA: 0x00A10394 File Offset: 0x00A0E594
		public static UScriptStructStackOnlyPtr StaticStruct()
		{
			return (SReBulletDataObstacles._ScriptStructPtr != 0) ? SReBulletDataObstacles._ScriptStructPtr : UObjectGlobals.StaticLoadScriptStruct("/Game/Aki/Core/Fight/SReBulletDataObstacles.SReBulletDataObstacles", ref SReBulletDataObstacles._ScriptStructPtr);
		}

		// Token: 0x040156A8 RID: 87720
		[FieldOffset(0)]
		public FVector 检测位置;

		// Token: 0x040156A9 RID: 87721
		[FieldOffset(12)]
		public float 检测距离;

		// Token: 0x040156AA RID: 87722
		public const string __ObjectPath = "/Game/Aki/Core/Fight/SReBulletDataObstacles.SReBulletDataObstacles";

		// Token: 0x040156AB RID: 87723
		private static IntPtr _ScriptStructPtr;
	}
}
