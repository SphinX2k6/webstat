using System;
using System.Numerics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;

namespace AkiClient.Game.Aki.AI.AIFunctionCommon.KFCS_WandersData
{
	// Token: 0x02004391 RID: 17297
	[HasGetTypeHash]
	[UnrealBlittableStruct(UnrealReflectionPropertyTypeCode.UnrealBlittableStruct)]
	[UnrealStructLayout(20, 4, UnrealReflectionPropertyTypeCode.UnrealBlittableStruct, PropertiesSize = 20)]
	[UnrealObjectPath("/Game/Aki/AI/AIFunctionCommon/KFCS_WandersData/KFCS_WanderDistance.KFCS_WanderDistance")]
	[StructLayout(LayoutKind.Explicit, Pack = 4, Size = 20)]
	public struct KFCS_WanderDistance : IEqualityOperators<KFCS_WanderDistance, KFCS_WanderDistance, bool>, IEquatable<KFCS_WanderDistance>, IUnrealScriptStruct
	{
		// Token: 0x0602DDB1 RID: 187825 RVA: 0x00ACE4E8 File Offset: 0x00ACC6E8
		public KFCS_WanderDistance(float 近距离边界, float 远距离边界, float 追停距离, float 极近距离边界, float 极远距离界限)
		{
			this.近距离边界 = 近距离边界;
			this.远距离边界 = 远距离边界;
			this.追停距离 = 追停距离;
			this.极近距离边界 = 极近距离边界;
			this.极远距离界限 = 极远距离界限;
		}

		// Token: 0x0602DDB2 RID: 187826 RVA: 0x00ACE510 File Offset: 0x00ACC710
		public static bool operator ==(KFCS_WanderDistance left, KFCS_WanderDistance right)
		{
			return left.近距离边界 == right.近距离边界 && left.远距离边界 == right.远距离边界 && left.追停距离 == right.追停距离 && left.极近距离边界 == right.极近距离边界 && left.极远距离界限 == right.极远距离界限;
		}

		// Token: 0x0602DDB3 RID: 187827 RVA: 0x00ACE565 File Offset: 0x00ACC765
		public static bool operator !=(KFCS_WanderDistance left, KFCS_WanderDistance right)
		{
			return !(left == right);
		}

		// Token: 0x0602DDB4 RID: 187828 RVA: 0x00ACE571 File Offset: 0x00ACC771
		public bool Equals(KFCS_WanderDistance other)
		{
			return this == other;
		}

		// Token: 0x0602DDB5 RID: 187829 RVA: 0x00ACE580 File Offset: 0x00ACC780
		[NullableContext(2)]
		public override bool Equals(object obj)
		{
			if (obj is KFCS_WanderDistance)
			{
				KFCS_WanderDistance other = (KFCS_WanderDistance)obj;
				return this.Equals(other);
			}
			return false;
		}

		// Token: 0x0602DDB6 RID: 187830 RVA: 0x00ACE5A5 File Offset: 0x00ACC7A5
		public override int GetHashCode()
		{
			return HashCode.Combine<float, float, float, float, float>(this.近距离边界, this.远距离边界, this.追停距离, this.极近距离边界, this.极远距离界限);
		}

		// Token: 0x0602DDB7 RID: 187831 RVA: 0x00ACE5CA File Offset: 0x00ACC7CA
		public static UScriptStructStackOnlyPtr StaticStruct()
		{
			return (KFCS_WanderDistance._ScriptStructPtr != 0) ? KFCS_WanderDistance._ScriptStructPtr : UObjectGlobals.StaticLoadScriptStruct("/Game/Aki/AI/AIFunctionCommon/KFCS_WandersData/KFCS_WanderDistance.KFCS_WanderDistance", ref KFCS_WanderDistance._ScriptStructPtr);
		}

		// Token: 0x04019E8A RID: 106122
		[FieldOffset(0)]
		public float 近距离边界;

		// Token: 0x04019E8B RID: 106123
		[FieldOffset(4)]
		public float 远距离边界;

		// Token: 0x04019E8C RID: 106124
		[FieldOffset(8)]
		public float 追停距离;

		// Token: 0x04019E8D RID: 106125
		[FieldOffset(12)]
		public float 极近距离边界;

		// Token: 0x04019E8E RID: 106126
		[FieldOffset(16)]
		public float 极远距离界限;

		// Token: 0x04019E8F RID: 106127
		public const string __ObjectPath = "/Game/Aki/AI/AIFunctionCommon/KFCS_WandersData/KFCS_WanderDistance.KFCS_WanderDistance";

		// Token: 0x04019E90 RID: 106128
		private static IntPtr _ScriptStructPtr;
	}
}
