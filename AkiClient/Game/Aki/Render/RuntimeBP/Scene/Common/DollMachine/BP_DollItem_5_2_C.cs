using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Render.RuntimeBP.Scene.Common.DollMachine
{
	// Token: 0x02003AFB RID: 15099
	[NullableContext(2)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Render/RuntimeBP/Scene/Common/DollMachine/BP_DollItem_5_2.BP_DollItem_5_2_C")]
	[UnrealStructLayout(1544, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 1544)]
	public class BP_DollItem_5_2_C : BP_DollActor_C, IUnrealUObject, IUnrealObject
	{
		// Token: 0x060206FD RID: 132861 RVA: 0x0092BF42 File Offset: 0x0092A142
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_DollItem_5_2_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Render/RuntimeBP/Scene/Common/DollMachine/BP_DollItem_5_2.BP_DollItem_5_2_C");
			}
			return BP_DollItem_5_2_C._ClassPtr;
		}

		// Token: 0x060206FE RID: 132862 RVA: 0x0092BF68 File Offset: 0x0092A168
		public BP_DollItem_5_2_C() : this(BuiltinUtils.AllocNativeUObject(BP_DollItem_5_2_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x060206FF RID: 132863 RVA: 0x0092BF90 File Offset: 0x0092A190
		[NullableContext(1)]
		public BP_DollItem_5_2_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_DollItem_5_2_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x1700359C RID: 13724
		// (get) Token: 0x06020700 RID: 132864 RVA: 0x0092BFC3 File Offset: 0x0092A1C3
		// (set) Token: 0x06020701 RID: 132865 RVA: 0x0092BFD7 File Offset: 0x0092A1D7
		public unsafe UPointLightComponent PointLight1
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UPointLightComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_DollItem_5_2_C.__PropertyOffset_0);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_DollItem_5_2_C.__PropertyOffset_0, value);
			}
		}

		// Token: 0x1700359D RID: 13725
		// (get) Token: 0x06020702 RID: 132866 RVA: 0x0092BFEC File Offset: 0x0092A1EC
		// (set) Token: 0x06020703 RID: 132867 RVA: 0x0092C000 File Offset: 0x0092A200
		public unsafe USkeletalMeshComponent EpropJiwawa05BallMd10011
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<USkeletalMeshComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_DollItem_5_2_C.__PropertyOffset_1);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_DollItem_5_2_C.__PropertyOffset_1, value);
			}
		}

		// Token: 0x06020704 RID: 132868 RVA: 0x0092C015 File Offset: 0x0092A215
		protected BP_DollItem_5_2_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x04010357 RID: 66391
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Render/RuntimeBP/Scene/Common/DollMachine/BP_DollItem_5_2.BP_DollItem_5_2_C";

		// Token: 0x04010358 RID: 66392
		private static IntPtr _ClassPtr;

		// Token: 0x04010359 RID: 66393
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x0401035A RID: 66394
		internal new static int __PropertyOffset_0;

		// Token: 0x0401035B RID: 66395
		internal new static int __PropertyOffset_1;
	}
}
