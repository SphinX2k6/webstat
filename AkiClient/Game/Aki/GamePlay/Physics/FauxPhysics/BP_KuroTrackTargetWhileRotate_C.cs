using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.GamePlay.Physics.FauxPhysics
{
	// Token: 0x02003DCD RID: 15821
	[NullableContext(2)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/GamePlay/Physics/FauxPhysics/BP_KuroTrackTargetWhileRotate.BP_KuroTrackTargetWhileRotate_C")]
	[UnrealStructLayout(1056, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 1056)]
	public class BP_KuroTrackTargetWhileRotate_C : AActor, IUnrealUObject, IUnrealObject
	{
		// Token: 0x06026C05 RID: 158725 RVA: 0x009E12EE File Offset: 0x009DF4EE
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_KuroTrackTargetWhileRotate_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/GamePlay/Physics/FauxPhysics/BP_KuroTrackTargetWhileRotate.BP_KuroTrackTargetWhileRotate_C");
			}
			return BP_KuroTrackTargetWhileRotate_C._ClassPtr;
		}

		// Token: 0x06026C06 RID: 158726 RVA: 0x009E1314 File Offset: 0x009DF514
		public BP_KuroTrackTargetWhileRotate_C() : this(BuiltinUtils.AllocNativeUObject(BP_KuroTrackTargetWhileRotate_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x06026C07 RID: 158727 RVA: 0x009E133C File Offset: 0x009DF53C
		[NullableContext(1)]
		public BP_KuroTrackTargetWhileRotate_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_KuroTrackTargetWhileRotate_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x170058E5 RID: 22757
		// (get) Token: 0x06026C08 RID: 158728 RVA: 0x009E136F File Offset: 0x009DF56F
		// (set) Token: 0x06026C09 RID: 158729 RVA: 0x009E1383 File Offset: 0x009DF583
		public unsafe UKuroFauxPhysicsAxisRotateComponent KuroFauxPhysicsAxisRotate
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UKuroFauxPhysicsAxisRotateComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_KuroTrackTargetWhileRotate_C.__PropertyOffset_0);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_KuroTrackTargetWhileRotate_C.__PropertyOffset_0, value);
			}
		}

		// Token: 0x170058E6 RID: 22758
		// (get) Token: 0x06026C0A RID: 158730 RVA: 0x009E1398 File Offset: 0x009DF598
		// (set) Token: 0x06026C0B RID: 158731 RVA: 0x009E13AC File Offset: 0x009DF5AC
		public unsafe UKuroFauxPhysicsConeRotateComponent KuroFauxPhysicsConeRotate
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UKuroFauxPhysicsConeRotateComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_KuroTrackTargetWhileRotate_C.__PropertyOffset_1);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_KuroTrackTargetWhileRotate_C.__PropertyOffset_1, value);
			}
		}

		// Token: 0x170058E7 RID: 22759
		// (get) Token: 0x06026C0C RID: 158732 RVA: 0x009E13C1 File Offset: 0x009DF5C1
		// (set) Token: 0x06026C0D RID: 158733 RVA: 0x009E13D5 File Offset: 0x009DF5D5
		public unsafe UKuroFauxPhysicsFreeRotateComponent KuroFauxPhysicsFreeRotate
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UKuroFauxPhysicsFreeRotateComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_KuroTrackTargetWhileRotate_C.__PropertyOffset_2);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_KuroTrackTargetWhileRotate_C.__PropertyOffset_2, value);
			}
		}

		// Token: 0x170058E8 RID: 22760
		// (get) Token: 0x06026C0E RID: 158734 RVA: 0x009E13EA File Offset: 0x009DF5EA
		// (set) Token: 0x06026C0F RID: 158735 RVA: 0x009E13FE File Offset: 0x009DF5FE
		public unsafe UKuroFauxPhysicsTrackTargetComponent KuroFauxPhysicsTrackTarget
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UKuroFauxPhysicsTrackTargetComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_KuroTrackTargetWhileRotate_C.__PropertyOffset_3);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_KuroTrackTargetWhileRotate_C.__PropertyOffset_3, value);
			}
		}

		// Token: 0x06026C10 RID: 158736 RVA: 0x009E1413 File Offset: 0x009DF613
		protected BP_KuroTrackTargetWhileRotate_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x0401435B RID: 82779
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/GamePlay/Physics/FauxPhysics/BP_KuroTrackTargetWhileRotate.BP_KuroTrackTargetWhileRotate_C";

		// Token: 0x0401435C RID: 82780
		private static IntPtr _ClassPtr;

		// Token: 0x0401435D RID: 82781
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x0401435E RID: 82782
		internal static int __PropertyOffset_0;

		// Token: 0x0401435F RID: 82783
		internal static int __PropertyOffset_1;

		// Token: 0x04014360 RID: 82784
		internal static int __PropertyOffset_2;

		// Token: 0x04014361 RID: 82785
		internal static int __PropertyOffset_3;
	}
}
