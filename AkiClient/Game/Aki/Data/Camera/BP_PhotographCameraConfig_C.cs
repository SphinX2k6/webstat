using System;
using System.Runtime.CompilerServices;
using AkiClient.Game.Aki.Character.BaseCharacter.Camera;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Data.Camera
{
	// Token: 0x02003F15 RID: 16149
	[UnrealObjectPath("/Game/Aki/Data/Camera/BP_PhotographCameraConfig.BP_PhotographCameraConfig_C")]
	[UnrealStructLayout(160, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 160)]
	public class BP_PhotographCameraConfig_C : UPrimaryDataAsset, IUnrealUObject, IUnrealObject
	{
		// Token: 0x060284A3 RID: 165027 RVA: 0x00A06F86 File Offset: 0x00A05186
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_PhotographCameraConfig_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Data/Camera/BP_PhotographCameraConfig.BP_PhotographCameraConfig_C");
			}
			return BP_PhotographCameraConfig_C._ClassPtr;
		}

		// Token: 0x060284A4 RID: 165028 RVA: 0x00A06FAC File Offset: 0x00A051AC
		public BP_PhotographCameraConfig_C() : this(BuiltinUtils.AllocNativeUObject(BP_PhotographCameraConfig_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x060284A5 RID: 165029 RVA: 0x00A06FD4 File Offset: 0x00A051D4
		[NullableContext(1)]
		public BP_PhotographCameraConfig_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_PhotographCameraConfig_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x170061AA RID: 25002
		// (get) Token: 0x060284A6 RID: 165030 RVA: 0x00A07008 File Offset: 0x00A05208
		// (set) Token: 0x060284A7 RID: 165031 RVA: 0x00A07041 File Offset: 0x00A05241
		[Nullable(new byte[]
		{
			1,
			0
		})]
		public TMap<TEnumAsByte<EPhotographCamera>, float> 基础
		{
			[return: Nullable(new byte[]
			{
				1,
				0
			})]
			get
			{
				base.FastCheckIsValid();
				TMap<TEnumAsByte<EPhotographCamera>, float> result;
				if ((result = this._基础) == null)
				{
					result = (this._基础 = new TMap<TEnumAsByte<EPhotographCamera>, float>(base.NativePtr + (IntPtr)BP_PhotographCameraConfig_C.__PropertyOffset_0, this));
				}
				return result;
			}
			[param: Nullable(new byte[]
			{
				1,
				0
			})]
			set
			{
				this.基础.CopyAssign(value);
			}
		}

		// Token: 0x060284A8 RID: 165032 RVA: 0x00A0704F File Offset: 0x00A0524F
		protected BP_PhotographCameraConfig_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x04015311 RID: 86801
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Data/Camera/BP_PhotographCameraConfig.BP_PhotographCameraConfig_C";

		// Token: 0x04015312 RID: 86802
		private static IntPtr _ClassPtr;

		// Token: 0x04015313 RID: 86803
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x04015314 RID: 86804
		internal static int __PropertyOffset_0;

		// Token: 0x04015315 RID: 86805
		[Nullable(new byte[]
		{
			2,
			0
		})]
		private TMap<TEnumAsByte<EPhotographCamera>, float> _基础;
	}
}
