using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Render.RuntimeBP.Scene.Common.DollMachine
{
	// Token: 0x02003B00 RID: 15104
	[NullableContext(2)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Render/RuntimeBP/Scene/Common/DollMachine/BP_DollItem_7_1.BP_DollItem_7_1_C")]
	[UnrealStructLayout(1544, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 1544)]
	public class BP_DollItem_7_1_C : BP_DollActor_C, IUnrealUObject, IUnrealObject
	{
		// Token: 0x06020725 RID: 132901 RVA: 0x0092C38E File Offset: 0x0092A58E
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_DollItem_7_1_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Render/RuntimeBP/Scene/Common/DollMachine/BP_DollItem_7_1.BP_DollItem_7_1_C");
			}
			return BP_DollItem_7_1_C._ClassPtr;
		}

		// Token: 0x06020726 RID: 132902 RVA: 0x0092C3B4 File Offset: 0x0092A5B4
		public BP_DollItem_7_1_C() : this(BuiltinUtils.AllocNativeUObject(BP_DollItem_7_1_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x06020727 RID: 132903 RVA: 0x0092C3DC File Offset: 0x0092A5DC
		[NullableContext(1)]
		public BP_DollItem_7_1_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_DollItem_7_1_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x170035A6 RID: 13734
		// (get) Token: 0x06020728 RID: 132904 RVA: 0x0092C40F File Offset: 0x0092A60F
		// (set) Token: 0x06020729 RID: 132905 RVA: 0x0092C423 File Offset: 0x0092A623
		public unsafe UPointLightComponent PointLight1
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UPointLightComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_DollItem_7_1_C.__PropertyOffset_0);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_DollItem_7_1_C.__PropertyOffset_0, value);
			}
		}

		// Token: 0x170035A7 RID: 13735
		// (get) Token: 0x0602072A RID: 132906 RVA: 0x0092C438 File Offset: 0x0092A638
		// (set) Token: 0x0602072B RID: 132907 RVA: 0x0092C44C File Offset: 0x0092A64C
		public unsafe USkeletalMeshComponent EpropJiwawa07Md10011
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<USkeletalMeshComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_DollItem_7_1_C.__PropertyOffset_1);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_DollItem_7_1_C.__PropertyOffset_1, value);
			}
		}

		// Token: 0x0602072C RID: 132908 RVA: 0x0092C461 File Offset: 0x0092A661
		protected BP_DollItem_7_1_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x04010370 RID: 66416
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Render/RuntimeBP/Scene/Common/DollMachine/BP_DollItem_7_1.BP_DollItem_7_1_C";

		// Token: 0x04010371 RID: 66417
		private static IntPtr _ClassPtr;

		// Token: 0x04010372 RID: 66418
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x04010373 RID: 66419
		internal new static int __PropertyOffset_0;

		// Token: 0x04010374 RID: 66420
		internal new static int __PropertyOffset_1;
	}
}
