using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Render.RuntimeBP.Scene.Common.DollMachine
{
	// Token: 0x02003AFC RID: 15100
	[NullableContext(2)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Render/RuntimeBP/Scene/Common/DollMachine/BP_DollItem_5_3.BP_DollItem_5_3_C")]
	[UnrealStructLayout(1544, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 1544)]
	public class BP_DollItem_5_3_C : BP_DollActor_C, IUnrealUObject, IUnrealObject
	{
		// Token: 0x06020705 RID: 132869 RVA: 0x0092C01E File Offset: 0x0092A21E
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_DollItem_5_3_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Render/RuntimeBP/Scene/Common/DollMachine/BP_DollItem_5_3.BP_DollItem_5_3_C");
			}
			return BP_DollItem_5_3_C._ClassPtr;
		}

		// Token: 0x06020706 RID: 132870 RVA: 0x0092C044 File Offset: 0x0092A244
		public BP_DollItem_5_3_C() : this(BuiltinUtils.AllocNativeUObject(BP_DollItem_5_3_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x06020707 RID: 132871 RVA: 0x0092C06C File Offset: 0x0092A26C
		[NullableContext(1)]
		public BP_DollItem_5_3_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_DollItem_5_3_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x1700359E RID: 13726
		// (get) Token: 0x06020708 RID: 132872 RVA: 0x0092C09F File Offset: 0x0092A29F
		// (set) Token: 0x06020709 RID: 132873 RVA: 0x0092C0B3 File Offset: 0x0092A2B3
		public unsafe UPointLightComponent PointLight
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UPointLightComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_DollItem_5_3_C.__PropertyOffset_0);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_DollItem_5_3_C.__PropertyOffset_0, value);
			}
		}

		// Token: 0x1700359F RID: 13727
		// (get) Token: 0x0602070A RID: 132874 RVA: 0x0092C0C8 File Offset: 0x0092A2C8
		// (set) Token: 0x0602070B RID: 132875 RVA: 0x0092C0DC File Offset: 0x0092A2DC
		public unsafe USkeletalMeshComponent EpropJiwawa05DizuoMd10011
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<USkeletalMeshComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_DollItem_5_3_C.__PropertyOffset_1);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_DollItem_5_3_C.__PropertyOffset_1, value);
			}
		}

		// Token: 0x0602070C RID: 132876 RVA: 0x0092C0F1 File Offset: 0x0092A2F1
		protected BP_DollItem_5_3_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x0401035C RID: 66396
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Render/RuntimeBP/Scene/Common/DollMachine/BP_DollItem_5_3.BP_DollItem_5_3_C";

		// Token: 0x0401035D RID: 66397
		private static IntPtr _ClassPtr;

		// Token: 0x0401035E RID: 66398
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x0401035F RID: 66399
		internal new static int __PropertyOffset_0;

		// Token: 0x04010360 RID: 66400
		internal new static int __PropertyOffset_1;
	}
}
