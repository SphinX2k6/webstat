using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Render.RuntimeBP.Scene.Common.DollMachine
{
	// Token: 0x02003AFA RID: 15098
	[NullableContext(2)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Render/RuntimeBP/Scene/Common/DollMachine/BP_DollItem_5_1.BP_DollItem_5_1_C")]
	[UnrealStructLayout(1544, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 1544)]
	public class BP_DollItem_5_1_C : BP_DollActor_C, IUnrealUObject, IUnrealObject
	{
		// Token: 0x060206F5 RID: 132853 RVA: 0x0092BE66 File Offset: 0x0092A066
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_DollItem_5_1_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Render/RuntimeBP/Scene/Common/DollMachine/BP_DollItem_5_1.BP_DollItem_5_1_C");
			}
			return BP_DollItem_5_1_C._ClassPtr;
		}

		// Token: 0x060206F6 RID: 132854 RVA: 0x0092BE8C File Offset: 0x0092A08C
		public BP_DollItem_5_1_C() : this(BuiltinUtils.AllocNativeUObject(BP_DollItem_5_1_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x060206F7 RID: 132855 RVA: 0x0092BEB4 File Offset: 0x0092A0B4
		[NullableContext(1)]
		public BP_DollItem_5_1_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_DollItem_5_1_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x1700359A RID: 13722
		// (get) Token: 0x060206F8 RID: 132856 RVA: 0x0092BEE7 File Offset: 0x0092A0E7
		// (set) Token: 0x060206F9 RID: 132857 RVA: 0x0092BEFB File Offset: 0x0092A0FB
		public unsafe UPointLightComponent PointLight
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UPointLightComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_DollItem_5_1_C.__PropertyOffset_0);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_DollItem_5_1_C.__PropertyOffset_0, value);
			}
		}

		// Token: 0x1700359B RID: 13723
		// (get) Token: 0x060206FA RID: 132858 RVA: 0x0092BF10 File Offset: 0x0092A110
		// (set) Token: 0x060206FB RID: 132859 RVA: 0x0092BF24 File Offset: 0x0092A124
		public unsafe USkeletalMeshComponent EpropJiwawa05Md10011
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<USkeletalMeshComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_DollItem_5_1_C.__PropertyOffset_1);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_DollItem_5_1_C.__PropertyOffset_1, value);
			}
		}

		// Token: 0x060206FC RID: 132860 RVA: 0x0092BF39 File Offset: 0x0092A139
		protected BP_DollItem_5_1_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x04010352 RID: 66386
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Render/RuntimeBP/Scene/Common/DollMachine/BP_DollItem_5_1.BP_DollItem_5_1_C";

		// Token: 0x04010353 RID: 66387
		private static IntPtr _ClassPtr;

		// Token: 0x04010354 RID: 66388
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x04010355 RID: 66389
		internal new static int __PropertyOffset_0;

		// Token: 0x04010356 RID: 66390
		internal new static int __PropertyOffset_1;
	}
}
