using System;
using System.Numerics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;

namespace AkiClient.Game.Aki.Render.RuntimeBP.PCG.AClusterBalloons
{
	// Token: 0x02003C51 RID: 15441
	[HasGetTypeHash]
	[UnrealBlittableStruct(UnrealReflectionPropertyTypeCode.UnrealBlittableStruct)]
	[UnrealStructLayout(52, 4, UnrealReflectionPropertyTypeCode.UnrealBlittableStruct, PropertiesSize = 52)]
	[UnrealObjectPath("/Game/Aki/Render/RuntimeBP/PCG/AClusterBalloons/S_BalloonsSetup.S_BalloonsSetup")]
	[StructLayout(LayoutKind.Explicit, Pack = 4, Size = 52)]
	public struct S_BalloonsSetup : IEqualityOperators<S_BalloonsSetup, S_BalloonsSetup, bool>, IEquatable<S_BalloonsSetup>, IUnrealScriptStruct
	{
		// Token: 0x0602399D RID: 145821 RVA: 0x00986F48 File Offset: 0x00985148
		public S_BalloonsSetup(int ptnum, float Px, float Py, float Pz, int up, int down, float upDis, float downDis, int ID_X, int ID_Y, int isStart, int isEnd, int isPivot)
		{
			this.ptnum = ptnum;
			this.Px = Px;
			this.Py = Py;
			this.Pz = Pz;
			this.up = up;
			this.down = down;
			this.upDis = upDis;
			this.downDis = downDis;
			this.ID_X = ID_X;
			this.ID_Y = ID_Y;
			this.isStart = isStart;
			this.isEnd = isEnd;
			this.isPivot = isPivot;
		}

		// Token: 0x0602399E RID: 145822 RVA: 0x00986FBC File Offset: 0x009851BC
		public static bool operator ==(S_BalloonsSetup left, S_BalloonsSetup right)
		{
			return left.ptnum == right.ptnum && left.Px == right.Px && left.Py == right.Py && left.Pz == right.Pz && left.up == right.up && left.down == right.down && left.upDis == right.upDis && left.downDis == right.downDis && left.ID_X == right.ID_X && left.ID_Y == right.ID_Y && left.isStart == right.isStart && left.isEnd == right.isEnd && left.isPivot == right.isPivot;
		}

		// Token: 0x0602399F RID: 145823 RVA: 0x0098708A File Offset: 0x0098528A
		public static bool operator !=(S_BalloonsSetup left, S_BalloonsSetup right)
		{
			return !(left == right);
		}

		// Token: 0x060239A0 RID: 145824 RVA: 0x00987096 File Offset: 0x00985296
		public bool Equals(S_BalloonsSetup other)
		{
			return this == other;
		}

		// Token: 0x060239A1 RID: 145825 RVA: 0x009870A4 File Offset: 0x009852A4
		[NullableContext(2)]
		public override bool Equals(object obj)
		{
			if (obj is S_BalloonsSetup)
			{
				S_BalloonsSetup other = (S_BalloonsSetup)obj;
				return this.Equals(other);
			}
			return false;
		}

		// Token: 0x060239A2 RID: 145826 RVA: 0x009870CC File Offset: 0x009852CC
		public override int GetHashCode()
		{
			HashCode hashCode = default(HashCode);
			hashCode.Add<int>(this.ptnum);
			hashCode.Add<float>(this.Px);
			hashCode.Add<float>(this.Py);
			hashCode.Add<float>(this.Pz);
			hashCode.Add<int>(this.up);
			hashCode.Add<int>(this.down);
			hashCode.Add<float>(this.upDis);
			hashCode.Add<float>(this.downDis);
			hashCode.Add<int>(this.ID_X);
			hashCode.Add<int>(this.ID_Y);
			hashCode.Add<int>(this.isStart);
			hashCode.Add<int>(this.isEnd);
			hashCode.Add<int>(this.isPivot);
			return hashCode.ToHashCode();
		}

		// Token: 0x060239A3 RID: 145827 RVA: 0x00987191 File Offset: 0x00985391
		public static UScriptStructStackOnlyPtr StaticStruct()
		{
			return (S_BalloonsSetup._ScriptStructPtr != 0) ? S_BalloonsSetup._ScriptStructPtr : UObjectGlobals.StaticLoadScriptStruct("/Game/Aki/Render/RuntimeBP/PCG/AClusterBalloons/S_BalloonsSetup.S_BalloonsSetup", ref S_BalloonsSetup._ScriptStructPtr);
		}

		// Token: 0x04012239 RID: 74297
		[FieldOffset(0)]
		public int ptnum;

		// Token: 0x0401223A RID: 74298
		[FieldOffset(4)]
		public float Px;

		// Token: 0x0401223B RID: 74299
		[FieldOffset(8)]
		public float Py;

		// Token: 0x0401223C RID: 74300
		[FieldOffset(12)]
		public float Pz;

		// Token: 0x0401223D RID: 74301
		[FieldOffset(16)]
		public int up;

		// Token: 0x0401223E RID: 74302
		[FieldOffset(20)]
		public int down;

		// Token: 0x0401223F RID: 74303
		[FieldOffset(24)]
		public float upDis;

		// Token: 0x04012240 RID: 74304
		[FieldOffset(28)]
		public float downDis;

		// Token: 0x04012241 RID: 74305
		[FieldOffset(32)]
		public int ID_X;

		// Token: 0x04012242 RID: 74306
		[FieldOffset(36)]
		public int ID_Y;

		// Token: 0x04012243 RID: 74307
		[FieldOffset(40)]
		public int isStart;

		// Token: 0x04012244 RID: 74308
		[FieldOffset(44)]
		public int isEnd;

		// Token: 0x04012245 RID: 74309
		[FieldOffset(48)]
		public int isPivot;

		// Token: 0x04012246 RID: 74310
		public const string __ObjectPath = "/Game/Aki/Render/RuntimeBP/PCG/AClusterBalloons/S_BalloonsSetup.S_BalloonsSetup";

		// Token: 0x04012247 RID: 74311
		private static IntPtr _ScriptStructPtr;
	}
}
