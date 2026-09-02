using System;
using System.Numerics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;

namespace AkiClient.Game.Aki.Data.UiRoleCamera.Struct
{
	// Token: 0x02003DF3 RID: 15859
	[HasGetTypeHash]
	[UnrealBlittableStruct(UnrealReflectionPropertyTypeCode.UnrealBlittableStruct)]
	[UnrealStructLayout(16, 4, UnrealReflectionPropertyTypeCode.UnrealBlittableStruct, PropertiesSize = 16)]
	[UnrealObjectPath("/Game/Aki/Data/UiRoleCamera/Struct/SUiRoleCameraOffsetSetting.SUiRoleCameraOffsetSetting")]
	[StructLayout(LayoutKind.Explicit, Pack = 4, Size = 16)]
	public struct SUiRoleCameraOffsetSetting : IEqualityOperators<SUiRoleCameraOffsetSetting, SUiRoleCameraOffsetSetting, bool>, IEquatable<SUiRoleCameraOffsetSetting>, IUnrealScriptStruct
	{
		// Token: 0x06027033 RID: 159795 RVA: 0x009E7CFD File Offset: 0x009E5EFD
		public SUiRoleCameraOffsetSetting(float 镜头浮动最大高度, float 镜头浮动最低高度, float 镜头浮动最短臂长, float 镜头浮动最长臂长)
		{
			this.镜头浮动最大高度 = 镜头浮动最大高度;
			this.镜头浮动最低高度 = 镜头浮动最低高度;
			this.镜头浮动最短臂长 = 镜头浮动最短臂长;
			this.镜头浮动最长臂长 = 镜头浮动最长臂长;
		}

		// Token: 0x06027034 RID: 159796 RVA: 0x009E7D1C File Offset: 0x009E5F1C
		public static bool operator ==(SUiRoleCameraOffsetSetting left, SUiRoleCameraOffsetSetting right)
		{
			return left.镜头浮动最大高度 == right.镜头浮动最大高度 && left.镜头浮动最低高度 == right.镜头浮动最低高度 && left.镜头浮动最短臂长 == right.镜头浮动最短臂长 && left.镜头浮动最长臂长 == right.镜头浮动最长臂长;
		}

		// Token: 0x06027035 RID: 159797 RVA: 0x009E7D58 File Offset: 0x009E5F58
		public static bool operator !=(SUiRoleCameraOffsetSetting left, SUiRoleCameraOffsetSetting right)
		{
			return !(left == right);
		}

		// Token: 0x06027036 RID: 159798 RVA: 0x009E7D64 File Offset: 0x009E5F64
		public bool Equals(SUiRoleCameraOffsetSetting other)
		{
			return this == other;
		}

		// Token: 0x06027037 RID: 159799 RVA: 0x009E7D74 File Offset: 0x009E5F74
		[NullableContext(2)]
		public override bool Equals(object obj)
		{
			if (obj is SUiRoleCameraOffsetSetting)
			{
				SUiRoleCameraOffsetSetting other = (SUiRoleCameraOffsetSetting)obj;
				return this.Equals(other);
			}
			return false;
		}

		// Token: 0x06027038 RID: 159800 RVA: 0x009E7D99 File Offset: 0x009E5F99
		public override int GetHashCode()
		{
			return HashCode.Combine<float, float, float, float>(this.镜头浮动最大高度, this.镜头浮动最低高度, this.镜头浮动最短臂长, this.镜头浮动最长臂长);
		}

		// Token: 0x06027039 RID: 159801 RVA: 0x009E7DB8 File Offset: 0x009E5FB8
		public static UScriptStructStackOnlyPtr StaticStruct()
		{
			return (SUiRoleCameraOffsetSetting._ScriptStructPtr != 0) ? SUiRoleCameraOffsetSetting._ScriptStructPtr : UObjectGlobals.StaticLoadScriptStruct("/Game/Aki/Data/UiRoleCamera/Struct/SUiRoleCameraOffsetSetting.SUiRoleCameraOffsetSetting", ref SUiRoleCameraOffsetSetting._ScriptStructPtr);
		}

		// Token: 0x040145F9 RID: 83449
		[FieldOffset(0)]
		public float 镜头浮动最大高度;

		// Token: 0x040145FA RID: 83450
		[FieldOffset(4)]
		public float 镜头浮动最低高度;

		// Token: 0x040145FB RID: 83451
		[FieldOffset(8)]
		public float 镜头浮动最短臂长;

		// Token: 0x040145FC RID: 83452
		[FieldOffset(12)]
		public float 镜头浮动最长臂长;

		// Token: 0x040145FD RID: 83453
		public const string __ObjectPath = "/Game/Aki/Data/UiRoleCamera/Struct/SUiRoleCameraOffsetSetting.SUiRoleCameraOffsetSetting";

		// Token: 0x040145FE RID: 83454
		private static IntPtr _ScriptStructPtr;
	}
}
