using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Render.RuntimeBP.Scene.Common.DollMachine
{
	// Token: 0x02003AFD RID: 15101
	[NullableContext(2)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Render/RuntimeBP/Scene/Common/DollMachine/BP_DollItem_6_1.BP_DollItem_6_1_C")]
	[UnrealStructLayout(1544, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 1544)]
	public class BP_DollItem_6_1_C : BP_DollActor_C, IUnrealUObject, IUnrealObject
	{
		// Token: 0x0602070D RID: 132877 RVA: 0x0092C0FA File Offset: 0x0092A2FA
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_DollItem_6_1_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Render/RuntimeBP/Scene/Common/DollMachine/BP_DollItem_6_1.BP_DollItem_6_1_C");
			}
			return BP_DollItem_6_1_C._ClassPtr;
		}

		// Token: 0x0602070E RID: 132878 RVA: 0x0092C120 File Offset: 0x0092A320
		public BP_DollItem_6_1_C() : this(BuiltinUtils.AllocNativeUObject(BP_DollItem_6_1_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x0602070F RID: 132879 RVA: 0x0092C148 File Offset: 0x0092A348
		[NullableContext(1)]
		public BP_DollItem_6_1_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_DollItem_6_1_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x170035A0 RID: 13728
		// (get) Token: 0x06020710 RID: 132880 RVA: 0x0092C17B File Offset: 0x0092A37B
		// (set) Token: 0x06020711 RID: 132881 RVA: 0x0092C18F File Offset: 0x0092A38F
		public unsafe UPointLightComponent PointLight
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UPointLightComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_DollItem_6_1_C.__PropertyOffset_0);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_DollItem_6_1_C.__PropertyOffset_0, value);
			}
		}

		// Token: 0x170035A1 RID: 13729
		// (get) Token: 0x06020712 RID: 132882 RVA: 0x0092C1A4 File Offset: 0x0092A3A4
		// (set) Token: 0x06020713 RID: 132883 RVA: 0x0092C1B8 File Offset: 0x0092A3B8
		public unsafe USkeletalMeshComponent EpropJiwawa06Md10011
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<USkeletalMeshComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_DollItem_6_1_C.__PropertyOffset_1);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_DollItem_6_1_C.__PropertyOffset_1, value);
			}
		}

		// Token: 0x06020714 RID: 132884 RVA: 0x0092C1CD File Offset: 0x0092A3CD
		protected BP_DollItem_6_1_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x04010361 RID: 66401
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Render/RuntimeBP/Scene/Common/DollMachine/BP_DollItem_6_1.BP_DollItem_6_1_C";

		// Token: 0x04010362 RID: 66402
		private static IntPtr _ClassPtr;

		// Token: 0x04010363 RID: 66403
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x04010364 RID: 66404
		internal new static int __PropertyOffset_0;

		// Token: 0x04010365 RID: 66405
		internal new static int __PropertyOffset_1;
	}
}
