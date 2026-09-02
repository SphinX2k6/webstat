using System;
using System.Numerics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;

namespace AkiClient.Game.Aki.AI.AIFunctionCommon.KFCS_WandersData
{
	// Token: 0x02004394 RID: 17300
	[HasGetTypeHash]
	[UnrealBlittableStruct(UnrealReflectionPropertyTypeCode.UnrealBlittableStruct)]
	[UnrealStructLayout(16, 4, UnrealReflectionPropertyTypeCode.UnrealBlittableStruct, PropertiesSize = 13)]
	[UnrealObjectPath("/Game/Aki/AI/AIFunctionCommon/KFCS_WandersData/SFightingPressure.SFightingPressure")]
	[StructLayout(LayoutKind.Explicit, Pack = 4, Size = 16)]
	public struct SFightingPressure : IEqualityOperators<SFightingPressure, SFightingPressure, bool>, IEquatable<SFightingPressure>, IUnrealScriptStruct
	{
		// Token: 0x0602DDD0 RID: 187856 RVA: 0x00ACE7E4 File Offset: 0x00ACC9E4
		public SFightingPressure(float 最大攻击间隔, float 最小攻击间隔, int 同时进攻数量, bool 血量检测)
		{
			this.最大攻击间隔 = 最大攻击间隔;
			this.最小攻击间隔 = 最小攻击间隔;
			this.同时进攻数量 = 同时进攻数量;
			this.血量检测 = 血量检测;
		}

		// Token: 0x0602DDD1 RID: 187857 RVA: 0x00ACE803 File Offset: 0x00ACCA03
		public static bool operator ==(SFightingPressure left, SFightingPressure right)
		{
			return left.最大攻击间隔 == right.最大攻击间隔 && left.最小攻击间隔 == right.最小攻击间隔 && left.同时进攻数量 == right.同时进攻数量 && left.血量检测 == right.血量检测;
		}

		// Token: 0x0602DDD2 RID: 187858 RVA: 0x00ACE83F File Offset: 0x00ACCA3F
		public static bool operator !=(SFightingPressure left, SFightingPressure right)
		{
			return !(left == right);
		}

		// Token: 0x0602DDD3 RID: 187859 RVA: 0x00ACE84B File Offset: 0x00ACCA4B
		public bool Equals(SFightingPressure other)
		{
			return this == other;
		}

		// Token: 0x0602DDD4 RID: 187860 RVA: 0x00ACE85C File Offset: 0x00ACCA5C
		[NullableContext(2)]
		public override bool Equals(object obj)
		{
			if (obj is SFightingPressure)
			{
				SFightingPressure other = (SFightingPressure)obj;
				return this.Equals(other);
			}
			return false;
		}

		// Token: 0x0602DDD5 RID: 187861 RVA: 0x00ACE881 File Offset: 0x00ACCA81
		public override int GetHashCode()
		{
			return HashCode.Combine<float, float, int, bool>(this.最大攻击间隔, this.最小攻击间隔, this.同时进攻数量, this.血量检测);
		}

		// Token: 0x0602DDD6 RID: 187862 RVA: 0x00ACE8A0 File Offset: 0x00ACCAA0
		public static UScriptStructStackOnlyPtr StaticStruct()
		{
			return (SFightingPressure._ScriptStructPtr != 0) ? SFightingPressure._ScriptStructPtr : UObjectGlobals.StaticLoadScriptStruct("/Game/Aki/AI/AIFunctionCommon/KFCS_WandersData/SFightingPressure.SFightingPressure", ref SFightingPressure._ScriptStructPtr);
		}

		// Token: 0x04019E9B RID: 106139
		[FieldOffset(0)]
		public float 最大攻击间隔;

		// Token: 0x04019E9C RID: 106140
		[FieldOffset(4)]
		public float 最小攻击间隔;

		// Token: 0x04019E9D RID: 106141
		[FieldOffset(8)]
		public int 同时进攻数量;

		// Token: 0x04019E9E RID: 106142
		[FieldOffset(12)]
		public bool 血量检测;

		// Token: 0x04019E9F RID: 106143
		public const string __ObjectPath = "/Game/Aki/AI/AIFunctionCommon/KFCS_WandersData/SFightingPressure.SFightingPressure";

		// Token: 0x04019EA0 RID: 106144
		private static IntPtr _ScriptStructPtr;
	}
}
