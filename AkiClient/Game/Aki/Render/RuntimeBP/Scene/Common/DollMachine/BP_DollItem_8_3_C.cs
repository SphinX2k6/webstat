using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Render.RuntimeBP.Scene.Common.DollMachine
{
	// Token: 0x02003B05 RID: 15109
	[NullableContext(2)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Render/RuntimeBP/Scene/Common/DollMachine/BP_DollItem_8_3.BP_DollItem_8_3_C")]
	[UnrealStructLayout(1544, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 1544)]
	public class BP_DollItem_8_3_C : BP_DollActor_C, IUnrealUObject, IUnrealObject
	{
		// Token: 0x0602074D RID: 132941 RVA: 0x0092C7DA File Offset: 0x0092A9DA
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_DollItem_8_3_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Render/RuntimeBP/Scene/Common/DollMachine/BP_DollItem_8_3.BP_DollItem_8_3_C");
			}
			return BP_DollItem_8_3_C._ClassPtr;
		}

		// Token: 0x0602074E RID: 132942 RVA: 0x0092C800 File Offset: 0x0092AA00
		public BP_DollItem_8_3_C() : this(BuiltinUtils.AllocNativeUObject(BP_DollItem_8_3_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x0602074F RID: 132943 RVA: 0x0092C828 File Offset: 0x0092AA28
		[NullableContext(1)]
		public BP_DollItem_8_3_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_DollItem_8_3_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x170035B0 RID: 13744
		// (get) Token: 0x06020750 RID: 132944 RVA: 0x0092C85B File Offset: 0x0092AA5B
		// (set) Token: 0x06020751 RID: 132945 RVA: 0x0092C86F File Offset: 0x0092AA6F
		public unsafe UPointLightComponent PointLight1
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UPointLightComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_DollItem_8_3_C.__PropertyOffset_0);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_DollItem_8_3_C.__PropertyOffset_0, value);
			}
		}

		// Token: 0x170035B1 RID: 13745
		// (get) Token: 0x06020752 RID: 132946 RVA: 0x0092C884 File Offset: 0x0092AA84
		// (set) Token: 0x06020753 RID: 132947 RVA: 0x0092C898 File Offset: 0x0092AA98
		public unsafe USkeletalMeshComponent EpropJiwawa08YinchaMd10011
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<USkeletalMeshComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_DollItem_8_3_C.__PropertyOffset_1);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_DollItem_8_3_C.__PropertyOffset_1, value);
			}
		}

		// Token: 0x06020754 RID: 132948 RVA: 0x0092C8AD File Offset: 0x0092AAAD
		protected BP_DollItem_8_3_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x04010389 RID: 66441
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Render/RuntimeBP/Scene/Common/DollMachine/BP_DollItem_8_3.BP_DollItem_8_3_C";

		// Token: 0x0401038A RID: 66442
		private static IntPtr _ClassPtr;

		// Token: 0x0401038B RID: 66443
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x0401038C RID: 66444
		internal new static int __PropertyOffset_0;

		// Token: 0x0401038D RID: 66445
		internal new static int __PropertyOffset_1;
	}
}
