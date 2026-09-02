using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Data.Level.PlaneYinyou.BP
{
	// Token: 0x02003E79 RID: 15993
	[NullableContext(2)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Data/Level/PlaneYinyou/BP/BP_Plane.BP_Plane_C")]
	[UnrealStructLayout(1040, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 1040)]
	public class BP_Plane_C : AActor, IUnrealUObject, IUnrealObject
	{
		// Token: 0x0602795D RID: 162141 RVA: 0x009F59F8 File Offset: 0x009F3BF8
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_Plane_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Data/Level/PlaneYinyou/BP/BP_Plane.BP_Plane_C");
			}
			return BP_Plane_C._ClassPtr;
		}

		// Token: 0x0602795E RID: 162142 RVA: 0x009F5A1C File Offset: 0x009F3C1C
		public BP_Plane_C() : this(BuiltinUtils.AllocNativeUObject(BP_Plane_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x0602795F RID: 162143 RVA: 0x009F5A44 File Offset: 0x009F3C44
		[NullableContext(1)]
		public BP_Plane_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_Plane_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x17005DB5 RID: 23989
		// (get) Token: 0x06027960 RID: 162144 RVA: 0x009F5A77 File Offset: 0x009F3C77
		// (set) Token: 0x06027961 RID: 162145 RVA: 0x009F5A8B File Offset: 0x009F3C8B
		public unsafe USkeletalMeshComponent SkeletalMesh
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<USkeletalMeshComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_Plane_C.__PropertyOffset_0);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_Plane_C.__PropertyOffset_0, value);
			}
		}

		// Token: 0x17005DB6 RID: 23990
		// (get) Token: 0x06027962 RID: 162146 RVA: 0x009F5AA0 File Offset: 0x009F3CA0
		// (set) Token: 0x06027963 RID: 162147 RVA: 0x009F5AB4 File Offset: 0x009F3CB4
		public unsafe USceneComponent DefaultSceneRoot
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<USceneComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_Plane_C.__PropertyOffset_1);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_Plane_C.__PropertyOffset_1, value);
			}
		}

		// Token: 0x06027964 RID: 162148 RVA: 0x009F5AC9 File Offset: 0x009F3CC9
		protected BP_Plane_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x04014C00 RID: 84992
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Data/Level/PlaneYinyou/BP/BP_Plane.BP_Plane_C";

		// Token: 0x04014C01 RID: 84993
		private static IntPtr _ClassPtr;

		// Token: 0x04014C02 RID: 84994
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x04014C03 RID: 84995
		internal static int __PropertyOffset_0;

		// Token: 0x04014C04 RID: 84996
		internal static int __PropertyOffset_1;
	}
}
