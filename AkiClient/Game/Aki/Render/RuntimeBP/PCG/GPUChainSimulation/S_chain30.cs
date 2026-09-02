using System;
using System.Numerics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;

namespace AkiClient.Game.Aki.Render.RuntimeBP.PCG.GPUChainSimulation
{
	// Token: 0x02003C20 RID: 15392
	[HasGetTypeHash]
	[UnrealBlittableStruct(UnrealReflectionPropertyTypeCode.UnrealBlittableStruct)]
	[UnrealStructLayout(32, 4, UnrealReflectionPropertyTypeCode.UnrealBlittableStruct, PropertiesSize = 29)]
	[UnrealObjectPath("/Game/Aki/Render/RuntimeBP/PCG/GPUChainSimulation/S_chain30.S_chain30")]
	[StructLayout(LayoutKind.Explicit, Pack = 4, Size = 32)]
	public struct S_chain30 : IEqualityOperators<S_chain30, S_chain30, bool>, IEquatable<S_chain30>, IUnrealScriptStruct
	{
		// Token: 0x060231A3 RID: 143779 RVA: 0x00978928 File Offset: 0x00976B28
		public S_chain30(int left_index, int right_index, FVector Pos, float pos_left, float pos_right, bool isPinned)
		{
			this.left_index = left_index;
			this.right_index = right_index;
			this.Pos = Pos;
			this.pos_left = pos_left;
			this.pos_right = pos_right;
			this.isPinned = isPinned;
		}

		// Token: 0x060231A4 RID: 143780 RVA: 0x00978958 File Offset: 0x00976B58
		public static bool operator ==(S_chain30 left, S_chain30 right)
		{
			return left.left_index == right.left_index && left.right_index == right.right_index && left.Pos == right.Pos && left.pos_left == right.pos_left && left.pos_right == right.pos_right && left.isPinned == right.isPinned;
		}

		// Token: 0x060231A5 RID: 143781 RVA: 0x009789C0 File Offset: 0x00976BC0
		public static bool operator !=(S_chain30 left, S_chain30 right)
		{
			return !(left == right);
		}

		// Token: 0x060231A6 RID: 143782 RVA: 0x009789CC File Offset: 0x00976BCC
		public bool Equals(S_chain30 other)
		{
			return this == other;
		}

		// Token: 0x060231A7 RID: 143783 RVA: 0x009789DC File Offset: 0x00976BDC
		[NullableContext(2)]
		public override bool Equals(object obj)
		{
			if (obj is S_chain30)
			{
				S_chain30 other = (S_chain30)obj;
				return this.Equals(other);
			}
			return false;
		}

		// Token: 0x060231A8 RID: 143784 RVA: 0x00978A01 File Offset: 0x00976C01
		public override int GetHashCode()
		{
			return HashCode.Combine<int, int, FVector, float, float, bool>(this.left_index, this.right_index, this.Pos, this.pos_left, this.pos_right, this.isPinned);
		}

		// Token: 0x060231A9 RID: 143785 RVA: 0x00978A2C File Offset: 0x00976C2C
		public static UScriptStructStackOnlyPtr StaticStruct()
		{
			return (S_chain30._ScriptStructPtr != 0) ? S_chain30._ScriptStructPtr : UObjectGlobals.StaticLoadScriptStruct("/Game/Aki/Render/RuntimeBP/PCG/GPUChainSimulation/S_chain30.S_chain30", ref S_chain30._ScriptStructPtr);
		}

		// Token: 0x04011D8B RID: 73099
		[FieldOffset(0)]
		public int left_index;

		// Token: 0x04011D8C RID: 73100
		[FieldOffset(4)]
		public int right_index;

		// Token: 0x04011D8D RID: 73101
		[FieldOffset(8)]
		public FVector Pos;

		// Token: 0x04011D8E RID: 73102
		[FieldOffset(20)]
		public float pos_left;

		// Token: 0x04011D8F RID: 73103
		[FieldOffset(24)]
		public float pos_right;

		// Token: 0x04011D90 RID: 73104
		[FieldOffset(28)]
		public bool isPinned;

		// Token: 0x04011D91 RID: 73105
		public const string __ObjectPath = "/Game/Aki/Render/RuntimeBP/PCG/GPUChainSimulation/S_chain30.S_chain30";

		// Token: 0x04011D92 RID: 73106
		private static IntPtr _ScriptStructPtr;
	}
}
