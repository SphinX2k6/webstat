using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Character.Role.FemaleXL.Jiabeilina_FP.Data
{
	// Token: 0x02003FF0 RID: 16368
	[NullableContext(1)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Character/Role/FemaleXL/Jiabeilina_FP/Data/BP_FlyingFeatherConfig.BP_FlyingFeatherConfig_C")]
	[UnrealStructLayout(144, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 144)]
	public class BP_FlyingFeatherConfig_C : UPrimaryDataAsset, IUnrealUObject, IUnrealObject
	{
		// Token: 0x06029698 RID: 169624 RVA: 0x00A2D77B File Offset: 0x00A2B97B
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_FlyingFeatherConfig_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Character/Role/FemaleXL/Jiabeilina_FP/Data/BP_FlyingFeatherConfig.BP_FlyingFeatherConfig_C");
			}
			return BP_FlyingFeatherConfig_C._ClassPtr;
		}

		// Token: 0x06029699 RID: 169625 RVA: 0x00A2D7A0 File Offset: 0x00A2B9A0
		public BP_FlyingFeatherConfig_C() : this(BuiltinUtils.AllocNativeUObject(BP_FlyingFeatherConfig_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x0602969A RID: 169626 RVA: 0x00A2D7C8 File Offset: 0x00A2B9C8
		public BP_FlyingFeatherConfig_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_FlyingFeatherConfig_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x170066F8 RID: 26360
		// (get) Token: 0x0602969B RID: 169627 RVA: 0x00A2D7FB File Offset: 0x00A2B9FB
		// (set) Token: 0x0602969C RID: 169628 RVA: 0x00A2D80B File Offset: 0x00A2BA0B
		public unsafe int BulletDelayTime
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_FlyingFeatherConfig_C.__PropertyOffset_0);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_FlyingFeatherConfig_C.__PropertyOffset_0) = value;
			}
		}

		// Token: 0x170066F9 RID: 26361
		// (get) Token: 0x0602969D RID: 169629 RVA: 0x00A2D81C File Offset: 0x00A2BA1C
		// (set) Token: 0x0602969E RID: 169630 RVA: 0x00A2D82C File Offset: 0x00A2BA2C
		public unsafe int SkillId
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_FlyingFeatherConfig_C.__PropertyOffset_1);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_FlyingFeatherConfig_C.__PropertyOffset_1) = value;
			}
		}

		// Token: 0x170066FA RID: 26362
		// (get) Token: 0x0602969F RID: 169631 RVA: 0x00A2D83D File Offset: 0x00A2BA3D
		// (set) Token: 0x060296A0 RID: 169632 RVA: 0x00A2D851 File Offset: 0x00A2BA51
		public unsafe string BulletId
		{
			get
			{
				return FString.ToString((void*)(base.NativePtr + (byte*)((IntPtr)BP_FlyingFeatherConfig_C.__PropertyOffset_2)));
			}
			set
			{
				FString.CopyFrom((void*)(base.NativePtr + (byte*)((IntPtr)BP_FlyingFeatherConfig_C.__PropertyOffset_2)), value);
			}
		}

		// Token: 0x170066FB RID: 26363
		// (get) Token: 0x060296A1 RID: 169633 RVA: 0x00A2D866 File Offset: 0x00A2BA66
		// (set) Token: 0x060296A2 RID: 169634 RVA: 0x00A2D87A File Offset: 0x00A2BA7A
		public unsafe string FeatherTarget
		{
			get
			{
				return FString.ToString((void*)(base.NativePtr + (byte*)((IntPtr)BP_FlyingFeatherConfig_C.__PropertyOffset_3)));
			}
			set
			{
				FString.CopyFrom((void*)(base.NativePtr + (byte*)((IntPtr)BP_FlyingFeatherConfig_C.__PropertyOffset_3)), value);
			}
		}

		// Token: 0x170066FC RID: 26364
		// (get) Token: 0x060296A3 RID: 169635 RVA: 0x00A2D88F File Offset: 0x00A2BA8F
		// (set) Token: 0x060296A4 RID: 169636 RVA: 0x00A2D89F File Offset: 0x00A2BA9F
		public unsafe double MaxSpeed
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_FlyingFeatherConfig_C.__PropertyOffset_4);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_FlyingFeatherConfig_C.__PropertyOffset_4) = value;
			}
		}

		// Token: 0x170066FD RID: 26365
		// (get) Token: 0x060296A5 RID: 169637 RVA: 0x00A2D8B0 File Offset: 0x00A2BAB0
		// (set) Token: 0x060296A6 RID: 169638 RVA: 0x00A2D8C0 File Offset: 0x00A2BAC0
		public unsafe double Acceleration
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_FlyingFeatherConfig_C.__PropertyOffset_5);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_FlyingFeatherConfig_C.__PropertyOffset_5) = value;
			}
		}

		// Token: 0x170066FE RID: 26366
		// (get) Token: 0x060296A7 RID: 169639 RVA: 0x00A2D8D1 File Offset: 0x00A2BAD1
		// (set) Token: 0x060296A8 RID: 169640 RVA: 0x00A2D8E1 File Offset: 0x00A2BAE1
		public unsafe int MaxChangeStateTime
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_FlyingFeatherConfig_C.__PropertyOffset_6);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_FlyingFeatherConfig_C.__PropertyOffset_6) = value;
			}
		}

		// Token: 0x170066FF RID: 26367
		// (get) Token: 0x060296A9 RID: 169641 RVA: 0x00A2D8F2 File Offset: 0x00A2BAF2
		// (set) Token: 0x060296AA RID: 169642 RVA: 0x00A2D902 File Offset: 0x00A2BB02
		public unsafe int ArriveDistance
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_FlyingFeatherConfig_C.__PropertyOffset_7);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_FlyingFeatherConfig_C.__PropertyOffset_7) = value;
			}
		}

		// Token: 0x060296AB RID: 169643 RVA: 0x00A2D913 File Offset: 0x00A2BB13
		protected BP_FlyingFeatherConfig_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x040160F0 RID: 90352
		public new const string __ObjectPath = "/Game/Aki/Character/Role/FemaleXL/Jiabeilina_FP/Data/BP_FlyingFeatherConfig.BP_FlyingFeatherConfig_C";

		// Token: 0x040160F1 RID: 90353
		private static IntPtr _ClassPtr;

		// Token: 0x040160F2 RID: 90354
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x040160F3 RID: 90355
		internal static int __PropertyOffset_0;

		// Token: 0x040160F4 RID: 90356
		internal static int __PropertyOffset_1;

		// Token: 0x040160F5 RID: 90357
		internal static int __PropertyOffset_2;

		// Token: 0x040160F6 RID: 90358
		internal static int __PropertyOffset_3;

		// Token: 0x040160F7 RID: 90359
		internal static int __PropertyOffset_4;

		// Token: 0x040160F8 RID: 90360
		internal static int __PropertyOffset_5;

		// Token: 0x040160F9 RID: 90361
		internal static int __PropertyOffset_6;

		// Token: 0x040160FA RID: 90362
		internal static int __PropertyOffset_7;
	}
}
