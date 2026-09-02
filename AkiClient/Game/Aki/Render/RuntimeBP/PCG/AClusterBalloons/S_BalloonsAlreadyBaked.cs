using System;
using System.Numerics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;

namespace AkiClient.Game.Aki.Render.RuntimeBP.PCG.AClusterBalloons
{
	// Token: 0x02003C50 RID: 15440
	[HasGetTypeHash]
	[UnrealBlittableStruct(UnrealReflectionPropertyTypeCode.UnrealBlittableStruct)]
	[UnrealStructLayout(88, 4, UnrealReflectionPropertyTypeCode.UnrealBlittableStruct, PropertiesSize = 88)]
	[UnrealObjectPath("/Game/Aki/Render/RuntimeBP/PCG/AClusterBalloons/S_BalloonsAlreadyBaked.S_BalloonsAlreadyBaked")]
	[StructLayout(LayoutKind.Explicit, Pack = 4, Size = 88)]
	public struct S_BalloonsAlreadyBaked : IEqualityOperators<S_BalloonsAlreadyBaked, S_BalloonsAlreadyBaked, bool>, IEquatable<S_BalloonsAlreadyBaked>, IUnrealScriptStruct
	{
		// Token: 0x06023996 RID: 145814 RVA: 0x00986B80 File Offset: 0x00984D80
		public S_BalloonsAlreadyBaked(int index, float pos_x, float pos_y, float pos_z, float vel_x, float vel_y, float vel_z, float pos_old_x, float pos_old_y, float pos_old_z, int up, int down, float upDis, float downDis, int ID_X, int ID_Y, int isStart, int isEnd, float pos_bind_x, float pos_bind_y, float pos_bind_z, int isPivot)
		{
			this.index = index;
			this.pos_x = pos_x;
			this.pos_y = pos_y;
			this.pos_z = pos_z;
			this.vel_x = vel_x;
			this.vel_y = vel_y;
			this.vel_z = vel_z;
			this.pos_old_x = pos_old_x;
			this.pos_old_y = pos_old_y;
			this.pos_old_z = pos_old_z;
			this.up = up;
			this.down = down;
			this.upDis = upDis;
			this.downDis = downDis;
			this.ID_X = ID_X;
			this.ID_Y = ID_Y;
			this.isStart = isStart;
			this.isEnd = isEnd;
			this.pos_bind_x = pos_bind_x;
			this.pos_bind_y = pos_bind_y;
			this.pos_bind_z = pos_bind_z;
			this.isPivot = isPivot;
		}

		// Token: 0x06023997 RID: 145815 RVA: 0x00986C3C File Offset: 0x00984E3C
		public static bool operator ==(S_BalloonsAlreadyBaked left, S_BalloonsAlreadyBaked right)
		{
			return left.index == right.index && left.pos_x == right.pos_x && left.pos_y == right.pos_y && left.pos_z == right.pos_z && left.vel_x == right.vel_x && left.vel_y == right.vel_y && left.vel_z == right.vel_z && left.pos_old_x == right.pos_old_x && left.pos_old_y == right.pos_old_y && left.pos_old_z == right.pos_old_z && left.up == right.up && left.down == right.down && left.upDis == right.upDis && left.downDis == right.downDis && left.ID_X == right.ID_X && left.ID_Y == right.ID_Y && left.isStart == right.isStart && left.isEnd == right.isEnd && left.pos_bind_x == right.pos_bind_x && left.pos_bind_y == right.pos_bind_y && left.pos_bind_z == right.pos_bind_z && left.isPivot == right.isPivot;
		}

		// Token: 0x06023998 RID: 145816 RVA: 0x00986DA3 File Offset: 0x00984FA3
		public static bool operator !=(S_BalloonsAlreadyBaked left, S_BalloonsAlreadyBaked right)
		{
			return !(left == right);
		}

		// Token: 0x06023999 RID: 145817 RVA: 0x00986DAF File Offset: 0x00984FAF
		public bool Equals(S_BalloonsAlreadyBaked other)
		{
			return this == other;
		}

		// Token: 0x0602399A RID: 145818 RVA: 0x00986DC0 File Offset: 0x00984FC0
		[NullableContext(2)]
		public override bool Equals(object obj)
		{
			if (obj is S_BalloonsAlreadyBaked)
			{
				S_BalloonsAlreadyBaked other = (S_BalloonsAlreadyBaked)obj;
				return this.Equals(other);
			}
			return false;
		}

		// Token: 0x0602399B RID: 145819 RVA: 0x00986DE8 File Offset: 0x00984FE8
		public override int GetHashCode()
		{
			HashCode hashCode = default(HashCode);
			hashCode.Add<int>(this.index);
			hashCode.Add<float>(this.pos_x);
			hashCode.Add<float>(this.pos_y);
			hashCode.Add<float>(this.pos_z);
			hashCode.Add<float>(this.vel_x);
			hashCode.Add<float>(this.vel_y);
			hashCode.Add<float>(this.vel_z);
			hashCode.Add<float>(this.pos_old_x);
			hashCode.Add<float>(this.pos_old_y);
			hashCode.Add<float>(this.pos_old_z);
			hashCode.Add<int>(this.up);
			hashCode.Add<int>(this.down);
			hashCode.Add<float>(this.upDis);
			hashCode.Add<float>(this.downDis);
			hashCode.Add<int>(this.ID_X);
			hashCode.Add<int>(this.ID_Y);
			hashCode.Add<int>(this.isStart);
			hashCode.Add<int>(this.isEnd);
			hashCode.Add<float>(this.pos_bind_x);
			hashCode.Add<float>(this.pos_bind_y);
			hashCode.Add<float>(this.pos_bind_z);
			hashCode.Add<int>(this.isPivot);
			return hashCode.ToHashCode();
		}

		// Token: 0x0602399C RID: 145820 RVA: 0x00986F22 File Offset: 0x00985122
		public static UScriptStructStackOnlyPtr StaticStruct()
		{
			return (S_BalloonsAlreadyBaked._ScriptStructPtr != 0) ? S_BalloonsAlreadyBaked._ScriptStructPtr : UObjectGlobals.StaticLoadScriptStruct("/Game/Aki/Render/RuntimeBP/PCG/AClusterBalloons/S_BalloonsAlreadyBaked.S_BalloonsAlreadyBaked", ref S_BalloonsAlreadyBaked._ScriptStructPtr);
		}

		// Token: 0x04012221 RID: 74273
		[FieldOffset(0)]
		public int index;

		// Token: 0x04012222 RID: 74274
		[FieldOffset(4)]
		public float pos_x;

		// Token: 0x04012223 RID: 74275
		[FieldOffset(8)]
		public float pos_y;

		// Token: 0x04012224 RID: 74276
		[FieldOffset(12)]
		public float pos_z;

		// Token: 0x04012225 RID: 74277
		[FieldOffset(16)]
		public float vel_x;

		// Token: 0x04012226 RID: 74278
		[FieldOffset(20)]
		public float vel_y;

		// Token: 0x04012227 RID: 74279
		[FieldOffset(24)]
		public float vel_z;

		// Token: 0x04012228 RID: 74280
		[FieldOffset(28)]
		public float pos_old_x;

		// Token: 0x04012229 RID: 74281
		[FieldOffset(32)]
		public float pos_old_y;

		// Token: 0x0401222A RID: 74282
		[FieldOffset(36)]
		public float pos_old_z;

		// Token: 0x0401222B RID: 74283
		[FieldOffset(40)]
		public int up;

		// Token: 0x0401222C RID: 74284
		[FieldOffset(44)]
		public int down;

		// Token: 0x0401222D RID: 74285
		[FieldOffset(48)]
		public float upDis;

		// Token: 0x0401222E RID: 74286
		[FieldOffset(52)]
		public float downDis;

		// Token: 0x0401222F RID: 74287
		[FieldOffset(56)]
		public int ID_X;

		// Token: 0x04012230 RID: 74288
		[FieldOffset(60)]
		public int ID_Y;

		// Token: 0x04012231 RID: 74289
		[FieldOffset(64)]
		public int isStart;

		// Token: 0x04012232 RID: 74290
		[FieldOffset(68)]
		public int isEnd;

		// Token: 0x04012233 RID: 74291
		[FieldOffset(72)]
		public float pos_bind_x;

		// Token: 0x04012234 RID: 74292
		[FieldOffset(76)]
		public float pos_bind_y;

		// Token: 0x04012235 RID: 74293
		[FieldOffset(80)]
		public float pos_bind_z;

		// Token: 0x04012236 RID: 74294
		[FieldOffset(84)]
		public int isPivot;

		// Token: 0x04012237 RID: 74295
		public const string __ObjectPath = "/Game/Aki/Render/RuntimeBP/PCG/AClusterBalloons/S_BalloonsAlreadyBaked.S_BalloonsAlreadyBaked";

		// Token: 0x04012238 RID: 74296
		private static IntPtr _ScriptStructPtr;
	}
}
