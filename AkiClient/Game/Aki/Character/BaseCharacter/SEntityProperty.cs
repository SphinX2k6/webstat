using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;

namespace AkiClient.Game.Aki.Character.BaseCharacter
{
	// Token: 0x0200425D RID: 16989
	[NullableContext(1)]
	[Nullable(0)]
	[HasGetTypeHash]
	[UnrealObjectPath("/Game/Aki/Character/BaseCharacter/SEntityProperty.SEntityProperty")]
	[UnrealStructLayout(40, 8, UnrealReflectionPropertyTypeCode.UnrealScriptStructProxy, PropertiesSize = 40)]
	public class SEntityProperty : UnrealUserDefinedStructProxy, IUnrealScriptStructProxy, IUnrealScriptStruct, IUnrealObject
	{
		// Token: 0x0602D036 RID: 184374 RVA: 0x00AB5684 File Offset: 0x00AB3884
		public static UScriptStructStackOnlyPtr StaticStruct()
		{
			return (SEntityProperty._ScriptStructPtr != 0) ? SEntityProperty._ScriptStructPtr : UObjectGlobals.StaticLoadScriptStruct("/Game/Aki/Character/BaseCharacter/SEntityProperty.SEntityProperty", ref SEntityProperty._ScriptStructPtr);
		}

		// Token: 0x17007A1E RID: 31262
		// (get) Token: 0x0602D037 RID: 184375 RVA: 0x00AB56A8 File Offset: 0x00AB38A8
		// (set) Token: 0x0602D038 RID: 184376 RVA: 0x00AB56BC File Offset: 0x00AB38BC
		public unsafe string 备注
		{
			get
			{
				return FString.ToString((void*)(base.NativePtr + (byte*)((IntPtr)SEntityProperty.__PropertyOffset_0)));
			}
			set
			{
				FString.CopyFrom((void*)(base.NativePtr + (byte*)((IntPtr)SEntityProperty.__PropertyOffset_0)), value);
			}
		}

		// Token: 0x17007A1F RID: 31263
		// (get) Token: 0x0602D039 RID: 184377 RVA: 0x00AB56D1 File Offset: 0x00AB38D1
		// (set) Token: 0x0602D03A RID: 184378 RVA: 0x00AB56E1 File Offset: 0x00AB38E1
		public unsafe int 碰撞优先级
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SEntityProperty.__PropertyOffset_1);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SEntityProperty.__PropertyOffset_1) = value;
			}
		}

		// Token: 0x17007A20 RID: 31264
		// (get) Token: 0x0602D03B RID: 184379 RVA: 0x00AB56F2 File Offset: 0x00AB38F2
		// (set) Token: 0x0602D03C RID: 184380 RVA: 0x00AB5702 File Offset: 0x00AB3902
		public unsafe int 穿透优先级
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SEntityProperty.__PropertyOffset_2);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SEntityProperty.__PropertyOffset_2) = value;
			}
		}

		// Token: 0x17007A21 RID: 31265
		// (get) Token: 0x0602D03D RID: 184381 RVA: 0x00AB5713 File Offset: 0x00AB3913
		// (set) Token: 0x0602D03E RID: 184382 RVA: 0x00AB5723 File Offset: 0x00AB3923
		public unsafe int 受击映射索引ID
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SEntityProperty.__PropertyOffset_3);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SEntityProperty.__PropertyOffset_3) = value;
			}
		}

		// Token: 0x17007A22 RID: 31266
		// (get) Token: 0x0602D03F RID: 184383 RVA: 0x00AB5734 File Offset: 0x00AB3934
		// (set) Token: 0x0602D040 RID: 184384 RVA: 0x00AB5744 File Offset: 0x00AB3944
		public unsafe int 重量
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SEntityProperty.__PropertyOffset_4);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SEntityProperty.__PropertyOffset_4) = value;
			}
		}

		// Token: 0x17007A23 RID: 31267
		// (get) Token: 0x0602D041 RID: 184385 RVA: 0x00AB5755 File Offset: 0x00AB3955
		// (set) Token: 0x0602D042 RID: 184386 RVA: 0x00AB5765 File Offset: 0x00AB3965
		public unsafe int CaughtLevel
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SEntityProperty.__PropertyOffset_5);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SEntityProperty.__PropertyOffset_5) = value;
			}
		}

		// Token: 0x17007A24 RID: 31268
		// (get) Token: 0x0602D043 RID: 184387 RVA: 0x00AB5776 File Offset: 0x00AB3976
		// (set) Token: 0x0602D044 RID: 184388 RVA: 0x00AB5786 File Offset: 0x00AB3986
		public unsafe int 子弹受击顿帧时长比例
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SEntityProperty.__PropertyOffset_6);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SEntityProperty.__PropertyOffset_6) = value;
			}
		}

		// Token: 0x0602D045 RID: 184389 RVA: 0x00AB5797 File Offset: 0x00AB3997
		public SEntityProperty()
		{
		}

		// Token: 0x0602D046 RID: 184390 RVA: 0x00AB579F File Offset: 0x00AB399F
		public SEntityProperty(string 备注, int 碰撞优先级, int 穿透优先级, int 受击映射索引ID, int 重量, int CaughtLevel, int 子弹受击顿帧时长比例)
		{
			this.备注 = 备注;
			this.碰撞优先级 = 碰撞优先级;
			this.穿透优先级 = 穿透优先级;
			this.受击映射索引ID = 受击映射索引ID;
			this.重量 = 重量;
			this.CaughtLevel = CaughtLevel;
			this.子弹受击顿帧时长比例 = 子弹受击顿帧时长比例;
		}

		// Token: 0x0602D047 RID: 184391 RVA: 0x00AB57DC File Offset: 0x00AB39DC
		protected override IntPtr GetUStructPtr()
		{
			return SEntityProperty.StaticStruct();
		}

		// Token: 0x0602D048 RID: 184392 RVA: 0x00AB57E8 File Offset: 0x00AB39E8
		[NullableContext(2)]
		public SEntityProperty(IntPtr NativePtr, UnrealObject MemoryOwner) : base(NativePtr, MemoryOwner)
		{
		}

		// Token: 0x0602D049 RID: 184393 RVA: 0x00AB57F2 File Offset: 0x00AB39F2
		public SEntityProperty(IntPtr NativePtr, bool bWithMoveAssign, bool bWithCopyAssignIfCannotMove) : base(NativePtr, bWithMoveAssign, bWithCopyAssignIfCannotMove)
		{
		}

		// Token: 0x0602D04A RID: 184394 RVA: 0x00AB57FD File Offset: 0x00AB39FD
		public static IUnrealScriptStructProxy CreateFromPointer(IntPtr Pointer)
		{
			return new SEntityProperty(Pointer, false, true);
		}

		// Token: 0x0602D04B RID: 184395 RVA: 0x00AB5807 File Offset: 0x00AB3A07
		public static IUnrealScriptStructProxy CreateReferenceFromPointer(IntPtr Pointer, UnrealObject MemoryOwner)
		{
			return new SEntityProperty(Pointer, MemoryOwner);
		}

		// Token: 0x040193F0 RID: 103408
		public const string __ObjectPath = "/Game/Aki/Character/BaseCharacter/SEntityProperty.SEntityProperty";

		// Token: 0x040193F1 RID: 103409
		private static IntPtr _ScriptStructPtr;

		// Token: 0x040193F2 RID: 103410
		internal static int __PropertyOffset_0;

		// Token: 0x040193F3 RID: 103411
		internal static int __PropertyOffset_1;

		// Token: 0x040193F4 RID: 103412
		internal static int __PropertyOffset_2;

		// Token: 0x040193F5 RID: 103413
		internal static int __PropertyOffset_3;

		// Token: 0x040193F6 RID: 103414
		internal static int __PropertyOffset_4;

		// Token: 0x040193F7 RID: 103415
		internal static int __PropertyOffset_5;

		// Token: 0x040193F8 RID: 103416
		internal static int __PropertyOffset_6;
	}
}
