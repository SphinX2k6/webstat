using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Render.RuntimeBP.Scene.Common.DollMachine
{
	// Token: 0x02003AF2 RID: 15090
	[NullableContext(2)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Render/RuntimeBP/Scene/Common/DollMachine/BP_DollItem_2_2.BP_DollItem_2_2_C")]
	[UnrealStructLayout(1544, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 1544)]
	public class BP_DollItem_2_2_C : BP_DollActor_C, IUnrealUObject, IUnrealObject
	{
		// Token: 0x060206B3 RID: 132787 RVA: 0x0092B75E File Offset: 0x0092995E
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_DollItem_2_2_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Render/RuntimeBP/Scene/Common/DollMachine/BP_DollItem_2_2.BP_DollItem_2_2_C");
			}
			return BP_DollItem_2_2_C._ClassPtr;
		}

		// Token: 0x060206B4 RID: 132788 RVA: 0x0092B784 File Offset: 0x00929984
		public BP_DollItem_2_2_C() : this(BuiltinUtils.AllocNativeUObject(BP_DollItem_2_2_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x060206B5 RID: 132789 RVA: 0x0092B7AC File Offset: 0x009299AC
		[NullableContext(1)]
		public BP_DollItem_2_2_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_DollItem_2_2_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x17003589 RID: 13705
		// (get) Token: 0x060206B6 RID: 132790 RVA: 0x0092B7DF File Offset: 0x009299DF
		// (set) Token: 0x060206B7 RID: 132791 RVA: 0x0092B7F3 File Offset: 0x009299F3
		public unsafe UPointLightComponent PointLight1
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UPointLightComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_DollItem_2_2_C.__PropertyOffset_0);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_DollItem_2_2_C.__PropertyOffset_0, value);
			}
		}

		// Token: 0x1700358A RID: 13706
		// (get) Token: 0x060206B8 RID: 132792 RVA: 0x0092B808 File Offset: 0x00929A08
		// (set) Token: 0x060206B9 RID: 132793 RVA: 0x0092B81C File Offset: 0x00929A1C
		public unsafe USkeletalMeshComponent EpropJiwawa02JianMd10011
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<USkeletalMeshComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_DollItem_2_2_C.__PropertyOffset_1);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_DollItem_2_2_C.__PropertyOffset_1, value);
			}
		}

		// Token: 0x060206BA RID: 132794 RVA: 0x0092B831 File Offset: 0x00929A31
		protected BP_DollItem_2_2_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x04010329 RID: 66345
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Render/RuntimeBP/Scene/Common/DollMachine/BP_DollItem_2_2.BP_DollItem_2_2_C";

		// Token: 0x0401032A RID: 66346
		private static IntPtr _ClassPtr;

		// Token: 0x0401032B RID: 66347
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x0401032C RID: 66348
		internal new static int __PropertyOffset_0;

		// Token: 0x0401032D RID: 66349
		internal new static int __PropertyOffset_1;
	}
}
