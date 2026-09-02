using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Render.RuntimeBP.PCG.Physics_Actor
{
	// Token: 0x02003BA8 RID: 15272
	[UnrealObjectPath("/Game/Aki/Render/RuntimeBP/PCG/Physics_Actor/BP_PhysicsActor_Parent.BP_PhysicsActor_Parent_C")]
	[UnrealStructLayout(1304, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 1304)]
	public class BP_PhysicsActor_Parent_C : AKuroBPActor, IUnrealUObject, IUnrealObject
	{
		// Token: 0x06021F90 RID: 139152 RVA: 0x00958C43 File Offset: 0x00956E43
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_PhysicsActor_Parent_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Render/RuntimeBP/PCG/Physics_Actor/BP_PhysicsActor_Parent.BP_PhysicsActor_Parent_C");
			}
			return BP_PhysicsActor_Parent_C._ClassPtr;
		}

		// Token: 0x06021F91 RID: 139153 RVA: 0x00958C68 File Offset: 0x00956E68
		public BP_PhysicsActor_Parent_C() : this(BuiltinUtils.AllocNativeUObject(BP_PhysicsActor_Parent_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x06021F92 RID: 139154 RVA: 0x00958C90 File Offset: 0x00956E90
		[NullableContext(1)]
		public BP_PhysicsActor_Parent_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_PhysicsActor_Parent_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x17003E00 RID: 15872
		// (get) Token: 0x06021F93 RID: 139155 RVA: 0x00958CC3 File Offset: 0x00956EC3
		// (set) Token: 0x06021F94 RID: 139156 RVA: 0x00958CD7 File Offset: 0x00956ED7
		[Nullable(2)]
		public unsafe USceneComponent DefaultSceneRoot
		{
			[NullableContext(2)]
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<USceneComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_PhysicsActor_Parent_C.__PropertyOffset_0);
			}
			[NullableContext(2)]
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_PhysicsActor_Parent_C.__PropertyOffset_0, value);
			}
		}

		// Token: 0x06021F95 RID: 139157 RVA: 0x00958CEC File Offset: 0x00956EEC
		protected BP_PhysicsActor_Parent_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x04011289 RID: 70281
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Render/RuntimeBP/PCG/Physics_Actor/BP_PhysicsActor_Parent.BP_PhysicsActor_Parent_C";

		// Token: 0x0401128A RID: 70282
		private static IntPtr _ClassPtr;

		// Token: 0x0401128B RID: 70283
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x0401128C RID: 70284
		internal static int __PropertyOffset_0;
	}
}
