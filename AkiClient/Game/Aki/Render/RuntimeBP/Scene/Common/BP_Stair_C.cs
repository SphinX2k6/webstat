using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Render.RuntimeBP.Scene.Common
{
	// Token: 0x02003AE1 RID: 15073
	[UnrealObjectPath("/Game/Aki/Render/RuntimeBP/Scene/Common/BP_Stair.BP_Stair_C")]
	[UnrealStructLayout(1744, 16, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 1736)]
	public class BP_Stair_C : AKuroStair, IUnrealUObject, IUnrealObject
	{
		// Token: 0x060204C0 RID: 132288 RVA: 0x0092803C File Offset: 0x0092623C
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_Stair_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Render/RuntimeBP/Scene/Common/BP_Stair.BP_Stair_C");
			}
			return BP_Stair_C._ClassPtr;
		}

		// Token: 0x060204C1 RID: 132289 RVA: 0x00928060 File Offset: 0x00926260
		public BP_Stair_C() : this(BuiltinUtils.AllocNativeUObject(BP_Stair_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x060204C2 RID: 132290 RVA: 0x00928088 File Offset: 0x00926288
		[NullableContext(1)]
		public BP_Stair_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_Stair_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x170034DD RID: 13533
		// (get) Token: 0x060204C3 RID: 132291 RVA: 0x009280BB File Offset: 0x009262BB
		// (set) Token: 0x060204C4 RID: 132292 RVA: 0x009280CF File Offset: 0x009262CF
		[Nullable(2)]
		public unsafe USceneComponent DefaultSceneRoot
		{
			[NullableContext(2)]
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<USceneComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_Stair_C.__PropertyOffset_0);
			}
			[NullableContext(2)]
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_Stair_C.__PropertyOffset_0, value);
			}
		}

		// Token: 0x060204C5 RID: 132293 RVA: 0x009280E4 File Offset: 0x009262E4
		protected BP_Stair_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x040101E0 RID: 66016
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Render/RuntimeBP/Scene/Common/BP_Stair.BP_Stair_C";

		// Token: 0x040101E1 RID: 66017
		private static IntPtr _ClassPtr;

		// Token: 0x040101E2 RID: 66018
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x040101E3 RID: 66019
		internal static int __PropertyOffset_0;
	}
}
