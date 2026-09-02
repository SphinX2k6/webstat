using System;
using System.Numerics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;

namespace AkiClient.Game.Aki.AI.AIFunctionCommon.KFCS_WandersData
{
	// Token: 0x0200438F RID: 17295
	[HasGetTypeHash]
	[UnrealBlittableStruct(UnrealReflectionPropertyTypeCode.UnrealBlittableStruct)]
	[UnrealStructLayout(20, 4, UnrealReflectionPropertyTypeCode.UnrealBlittableStruct, PropertiesSize = 20)]
	[UnrealObjectPath("/Game/Aki/AI/AIFunctionCommon/KFCS_WandersData/KFCS_DirectionData.KFCS_DirectionData")]
	[StructLayout(LayoutKind.Explicit, Pack = 4, Size = 20)]
	public struct KFCS_DirectionData : IEqualityOperators<KFCS_DirectionData, KFCS_DirectionData, bool>, IEquatable<KFCS_DirectionData>, IUnrealScriptStruct
	{
		// Token: 0x0602DD7E RID: 187774 RVA: 0x00ACE08F File Offset: 0x00ACC28F
		public KFCS_DirectionData(float 前走转向速度, float 后走转向速度, float 左走转向速度, float 右走转向速度, float 前跑转向速度)
		{
			this.前走转向速度 = 前走转向速度;
			this.后走转向速度 = 后走转向速度;
			this.左走转向速度 = 左走转向速度;
			this.右走转向速度 = 右走转向速度;
			this.前跑转向速度 = 前跑转向速度;
		}

		// Token: 0x0602DD7F RID: 187775 RVA: 0x00ACE0B8 File Offset: 0x00ACC2B8
		public static bool operator ==(KFCS_DirectionData left, KFCS_DirectionData right)
		{
			return left.前走转向速度 == right.前走转向速度 && left.后走转向速度 == right.后走转向速度 && left.左走转向速度 == right.左走转向速度 && left.右走转向速度 == right.右走转向速度 && left.前跑转向速度 == right.前跑转向速度;
		}

		// Token: 0x0602DD80 RID: 187776 RVA: 0x00ACE10D File Offset: 0x00ACC30D
		public static bool operator !=(KFCS_DirectionData left, KFCS_DirectionData right)
		{
			return !(left == right);
		}

		// Token: 0x0602DD81 RID: 187777 RVA: 0x00ACE119 File Offset: 0x00ACC319
		public bool Equals(KFCS_DirectionData other)
		{
			return this == other;
		}

		// Token: 0x0602DD82 RID: 187778 RVA: 0x00ACE128 File Offset: 0x00ACC328
		[NullableContext(2)]
		public override bool Equals(object obj)
		{
			if (obj is KFCS_DirectionData)
			{
				KFCS_DirectionData other = (KFCS_DirectionData)obj;
				return this.Equals(other);
			}
			return false;
		}

		// Token: 0x0602DD83 RID: 187779 RVA: 0x00ACE14D File Offset: 0x00ACC34D
		public override int GetHashCode()
		{
			return HashCode.Combine<float, float, float, float, float>(this.前走转向速度, this.后走转向速度, this.左走转向速度, this.右走转向速度, this.前跑转向速度);
		}

		// Token: 0x0602DD84 RID: 187780 RVA: 0x00ACE172 File Offset: 0x00ACC372
		public static UScriptStructStackOnlyPtr StaticStruct()
		{
			return (KFCS_DirectionData._ScriptStructPtr != 0) ? KFCS_DirectionData._ScriptStructPtr : UObjectGlobals.StaticLoadScriptStruct("/Game/Aki/AI/AIFunctionCommon/KFCS_WandersData/KFCS_DirectionData.KFCS_DirectionData", ref KFCS_DirectionData._ScriptStructPtr);
		}

		// Token: 0x04019E6F RID: 106095
		[FieldOffset(0)]
		public float 前走转向速度;

		// Token: 0x04019E70 RID: 106096
		[FieldOffset(4)]
		public float 后走转向速度;

		// Token: 0x04019E71 RID: 106097
		[FieldOffset(8)]
		public float 左走转向速度;

		// Token: 0x04019E72 RID: 106098
		[FieldOffset(12)]
		public float 右走转向速度;

		// Token: 0x04019E73 RID: 106099
		[FieldOffset(16)]
		public float 前跑转向速度;

		// Token: 0x04019E74 RID: 106100
		public const string __ObjectPath = "/Game/Aki/AI/AIFunctionCommon/KFCS_WandersData/KFCS_DirectionData.KFCS_DirectionData";

		// Token: 0x04019E75 RID: 106101
		private static IntPtr _ScriptStructPtr;
	}
}
