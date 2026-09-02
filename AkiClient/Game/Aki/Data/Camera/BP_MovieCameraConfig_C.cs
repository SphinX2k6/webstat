using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Data.Camera
{
	// Token: 0x02003F14 RID: 16148
	[UnrealObjectPath("/Game/Aki/Data/Camera/BP_MovieCameraConfig.BP_MovieCameraConfig_C")]
	[UnrealStructLayout(88, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 88)]
	public class BP_MovieCameraConfig_C : UPrimaryDataAsset, IUnrealUObject, IUnrealObject
	{
		// Token: 0x0602849B RID: 165019 RVA: 0x00A06EBC File Offset: 0x00A050BC
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_MovieCameraConfig_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Data/Camera/BP_MovieCameraConfig.BP_MovieCameraConfig_C");
			}
			return BP_MovieCameraConfig_C._ClassPtr;
		}

		// Token: 0x0602849C RID: 165020 RVA: 0x00A06EE0 File Offset: 0x00A050E0
		public BP_MovieCameraConfig_C() : this(BuiltinUtils.AllocNativeUObject(BP_MovieCameraConfig_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x0602849D RID: 165021 RVA: 0x00A06F08 File Offset: 0x00A05108
		[NullableContext(1)]
		public BP_MovieCameraConfig_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_MovieCameraConfig_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x170061A8 RID: 25000
		// (get) Token: 0x0602849E RID: 165022 RVA: 0x00A06F3B File Offset: 0x00A0513B
		// (set) Token: 0x0602849F RID: 165023 RVA: 0x00A06F4B File Offset: 0x00A0514B
		public unsafe float ZSmoothFactor
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_MovieCameraConfig_C.__PropertyOffset_0);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_MovieCameraConfig_C.__PropertyOffset_0) = value;
			}
		}

		// Token: 0x170061A9 RID: 25001
		// (get) Token: 0x060284A0 RID: 165024 RVA: 0x00A06F5C File Offset: 0x00A0515C
		// (set) Token: 0x060284A1 RID: 165025 RVA: 0x00A06F6C File Offset: 0x00A0516C
		public unsafe float ZSmoothDelta
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_MovieCameraConfig_C.__PropertyOffset_1);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_MovieCameraConfig_C.__PropertyOffset_1) = value;
			}
		}

		// Token: 0x060284A2 RID: 165026 RVA: 0x00A06F7D File Offset: 0x00A0517D
		protected BP_MovieCameraConfig_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x0401530C RID: 86796
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Data/Camera/BP_MovieCameraConfig.BP_MovieCameraConfig_C";

		// Token: 0x0401530D RID: 86797
		private static IntPtr _ClassPtr;

		// Token: 0x0401530E RID: 86798
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x0401530F RID: 86799
		internal static int __PropertyOffset_0;

		// Token: 0x04015310 RID: 86800
		internal static int __PropertyOffset_1;
	}
}
