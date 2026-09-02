using System;
using System.Numerics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;

namespace AkiClient.Game.Aki.Data.UiRoleCamera.Struct
{
	// Token: 0x02003DF4 RID: 15860
	[HasGetTypeHash]
	[UnrealBlittableStruct(UnrealReflectionPropertyTypeCode.UnrealBlittableStruct)]
	[UnrealStructLayout(84, 4, UnrealReflectionPropertyTypeCode.UnrealBlittableStruct, PropertiesSize = 84)]
	[UnrealObjectPath("/Game/Aki/Data/UiRoleCamera/Struct/SUiRoleCameraSetting.SUiRoleCameraSetting")]
	[StructLayout(LayoutKind.Explicit, Pack = 4, Size = 84)]
	public struct SUiRoleCameraSetting : IEqualityOperators<SUiRoleCameraSetting, SUiRoleCameraSetting, bool>, IEquatable<SUiRoleCameraSetting>, IUnrealScriptStruct
	{
		// Token: 0x0602703A RID: 159802 RVA: 0x009E7DDC File Offset: 0x009E5FDC
		public SUiRoleCameraSetting(float 镜头Yaw灵敏度系数, float 镜头Pitch灵敏度系数, float 镜头缩放灵敏度系数, float 角色开始虚化仰视角, float 角色最大虚化仰视角, float Yaw限制Min, float Yaw限制Max, float Pitch限制Min, float Pitch限制Max, float 最小臂长, float 最大臂长, float 倍化手柄输入倍率, float 角色开始虚化距离, float 角色最大虚化距离, float 相机动画过程中角色开始虚化距离, float 相机动画过程中角色最大虚化距离, float 相机相对角色的最低高度, float 移动端旋转输入倍率, float 移动端缩放输入倍率, float 最大臂长时的光圈, float 最小臂长时的光圈)
		{
			this.镜头Yaw灵敏度系数 = 镜头Yaw灵敏度系数;
			this.镜头Pitch灵敏度系数 = 镜头Pitch灵敏度系数;
			this.镜头缩放灵敏度系数 = 镜头缩放灵敏度系数;
			this.角色开始虚化仰视角 = 角色开始虚化仰视角;
			this.角色最大虚化仰视角 = 角色最大虚化仰视角;
			this.Yaw限制Min = Yaw限制Min;
			this.Yaw限制Max = Yaw限制Max;
			this.Pitch限制Min = Pitch限制Min;
			this.Pitch限制Max = Pitch限制Max;
			this.最小臂长 = 最小臂长;
			this.最大臂长 = 最大臂长;
			this.倍化手柄输入倍率 = 倍化手柄输入倍率;
			this.角色开始虚化距离 = 角色开始虚化距离;
			this.角色最大虚化距离 = 角色最大虚化距离;
			this.相机动画过程中角色开始虚化距离 = 相机动画过程中角色开始虚化距离;
			this.相机动画过程中角色最大虚化距离 = 相机动画过程中角色最大虚化距离;
			this.相机相对角色的最低高度 = 相机相对角色的最低高度;
			this.移动端旋转输入倍率 = 移动端旋转输入倍率;
			this.移动端缩放输入倍率 = 移动端缩放输入倍率;
			this.最大臂长时的光圈 = 最大臂长时的光圈;
			this.最小臂长时的光圈 = 最小臂长时的光圈;
		}

		// Token: 0x0602703B RID: 159803 RVA: 0x009E7E90 File Offset: 0x009E6090
		public static bool operator ==(SUiRoleCameraSetting left, SUiRoleCameraSetting right)
		{
			return left.镜头Yaw灵敏度系数 == right.镜头Yaw灵敏度系数 && left.镜头Pitch灵敏度系数 == right.镜头Pitch灵敏度系数 && left.镜头缩放灵敏度系数 == right.镜头缩放灵敏度系数 && left.角色开始虚化仰视角 == right.角色开始虚化仰视角 && left.角色最大虚化仰视角 == right.角色最大虚化仰视角 && left.Yaw限制Min == right.Yaw限制Min && left.Yaw限制Max == right.Yaw限制Max && left.Pitch限制Min == right.Pitch限制Min && left.Pitch限制Max == right.Pitch限制Max && left.最小臂长 == right.最小臂长 && left.最大臂长 == right.最大臂长 && left.倍化手柄输入倍率 == right.倍化手柄输入倍率 && left.角色开始虚化距离 == right.角色开始虚化距离 && left.角色最大虚化距离 == right.角色最大虚化距离 && left.相机动画过程中角色开始虚化距离 == right.相机动画过程中角色开始虚化距离 && left.相机动画过程中角色最大虚化距离 == right.相机动画过程中角色最大虚化距离 && left.相机相对角色的最低高度 == right.相机相对角色的最低高度 && left.移动端旋转输入倍率 == right.移动端旋转输入倍率 && left.移动端缩放输入倍率 == right.移动端缩放输入倍率 && left.最大臂长时的光圈 == right.最大臂长时的光圈 && left.最小臂长时的光圈 == right.最小臂长时的光圈;
		}

		// Token: 0x0602703C RID: 159804 RVA: 0x009E7FE6 File Offset: 0x009E61E6
		public static bool operator !=(SUiRoleCameraSetting left, SUiRoleCameraSetting right)
		{
			return !(left == right);
		}

		// Token: 0x0602703D RID: 159805 RVA: 0x009E7FF2 File Offset: 0x009E61F2
		public bool Equals(SUiRoleCameraSetting other)
		{
			return this == other;
		}

		// Token: 0x0602703E RID: 159806 RVA: 0x009E8000 File Offset: 0x009E6200
		[NullableContext(2)]
		public override bool Equals(object obj)
		{
			if (obj is SUiRoleCameraSetting)
			{
				SUiRoleCameraSetting other = (SUiRoleCameraSetting)obj;
				return this.Equals(other);
			}
			return false;
		}

		// Token: 0x0602703F RID: 159807 RVA: 0x009E8028 File Offset: 0x009E6228
		public override int GetHashCode()
		{
			HashCode hashCode = default(HashCode);
			hashCode.Add<float>(this.镜头Yaw灵敏度系数);
			hashCode.Add<float>(this.镜头Pitch灵敏度系数);
			hashCode.Add<float>(this.镜头缩放灵敏度系数);
			hashCode.Add<float>(this.角色开始虚化仰视角);
			hashCode.Add<float>(this.角色最大虚化仰视角);
			hashCode.Add<float>(this.Yaw限制Min);
			hashCode.Add<float>(this.Yaw限制Max);
			hashCode.Add<float>(this.Pitch限制Min);
			hashCode.Add<float>(this.Pitch限制Max);
			hashCode.Add<float>(this.最小臂长);
			hashCode.Add<float>(this.最大臂长);
			hashCode.Add<float>(this.倍化手柄输入倍率);
			hashCode.Add<float>(this.角色开始虚化距离);
			hashCode.Add<float>(this.角色最大虚化距离);
			hashCode.Add<float>(this.相机动画过程中角色开始虚化距离);
			hashCode.Add<float>(this.相机动画过程中角色最大虚化距离);
			hashCode.Add<float>(this.相机相对角色的最低高度);
			hashCode.Add<float>(this.移动端旋转输入倍率);
			hashCode.Add<float>(this.移动端缩放输入倍率);
			hashCode.Add<float>(this.最大臂长时的光圈);
			hashCode.Add<float>(this.最小臂长时的光圈);
			return hashCode.ToHashCode();
		}

		// Token: 0x06027040 RID: 159808 RVA: 0x009E8155 File Offset: 0x009E6355
		public static UScriptStructStackOnlyPtr StaticStruct()
		{
			return (SUiRoleCameraSetting._ScriptStructPtr != 0) ? SUiRoleCameraSetting._ScriptStructPtr : UObjectGlobals.StaticLoadScriptStruct("/Game/Aki/Data/UiRoleCamera/Struct/SUiRoleCameraSetting.SUiRoleCameraSetting", ref SUiRoleCameraSetting._ScriptStructPtr);
		}

		// Token: 0x040145FF RID: 83455
		[FieldOffset(0)]
		public float 镜头Yaw灵敏度系数;

		// Token: 0x04014600 RID: 83456
		[FieldOffset(4)]
		public float 镜头Pitch灵敏度系数;

		// Token: 0x04014601 RID: 83457
		[FieldOffset(8)]
		public float 镜头缩放灵敏度系数;

		// Token: 0x04014602 RID: 83458
		[FieldOffset(12)]
		public float 角色开始虚化仰视角;

		// Token: 0x04014603 RID: 83459
		[FieldOffset(16)]
		public float 角色最大虚化仰视角;

		// Token: 0x04014604 RID: 83460
		[FieldOffset(20)]
		public float Yaw限制Min;

		// Token: 0x04014605 RID: 83461
		[FieldOffset(24)]
		public float Yaw限制Max;

		// Token: 0x04014606 RID: 83462
		[FieldOffset(28)]
		public float Pitch限制Min;

		// Token: 0x04014607 RID: 83463
		[FieldOffset(32)]
		public float Pitch限制Max;

		// Token: 0x04014608 RID: 83464
		[FieldOffset(36)]
		public float 最小臂长;

		// Token: 0x04014609 RID: 83465
		[FieldOffset(40)]
		public float 最大臂长;

		// Token: 0x0401460A RID: 83466
		[FieldOffset(44)]
		public float 倍化手柄输入倍率;

		// Token: 0x0401460B RID: 83467
		[FieldOffset(48)]
		public float 角色开始虚化距离;

		// Token: 0x0401460C RID: 83468
		[FieldOffset(52)]
		public float 角色最大虚化距离;

		// Token: 0x0401460D RID: 83469
		[FieldOffset(56)]
		public float 相机动画过程中角色开始虚化距离;

		// Token: 0x0401460E RID: 83470
		[FieldOffset(60)]
		public float 相机动画过程中角色最大虚化距离;

		// Token: 0x0401460F RID: 83471
		[FieldOffset(64)]
		public float 相机相对角色的最低高度;

		// Token: 0x04014610 RID: 83472
		[FieldOffset(68)]
		public float 移动端旋转输入倍率;

		// Token: 0x04014611 RID: 83473
		[FieldOffset(72)]
		public float 移动端缩放输入倍率;

		// Token: 0x04014612 RID: 83474
		[FieldOffset(76)]
		public float 最大臂长时的光圈;

		// Token: 0x04014613 RID: 83475
		[FieldOffset(80)]
		public float 最小臂长时的光圈;

		// Token: 0x04014614 RID: 83476
		public const string __ObjectPath = "/Game/Aki/Data/UiRoleCamera/Struct/SUiRoleCameraSetting.SUiRoleCameraSetting";

		// Token: 0x04014615 RID: 83477
		private static IntPtr _ScriptStructPtr;
	}
}
