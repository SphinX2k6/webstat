using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Render.RuntimeBP.Scene.Common.DollMachine
{
	// Token: 0x02003B17 RID: 15127
	[UnrealObjectPath("/Game/Aki/Render/RuntimeBP/Scene/Common/DollMachine/BP_E_DollItem_8.BP_E_DollItem_8_C")]
	[UnrealStructLayout(1536, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 1536)]
	public class BP_E_DollItem_8_C : BP_DollActor_C, IUnrealUObject, IUnrealObject
	{
		// Token: 0x06020836 RID: 133174 RVA: 0x0092E2E1 File Offset: 0x0092C4E1
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_E_DollItem_8_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Render/RuntimeBP/Scene/Common/DollMachine/BP_E_DollItem_8.BP_E_DollItem_8_C");
			}
			return BP_E_DollItem_8_C._ClassPtr;
		}

		// Token: 0x06020837 RID: 133175 RVA: 0x0092E308 File Offset: 0x0092C508
		public BP_E_DollItem_8_C() : this(BuiltinUtils.AllocNativeUObject(BP_E_DollItem_8_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x06020838 RID: 133176 RVA: 0x0092E330 File Offset: 0x0092C530
		[NullableContext(1)]
		public BP_E_DollItem_8_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_E_DollItem_8_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x170035F0 RID: 13808
		// (get) Token: 0x06020839 RID: 133177 RVA: 0x0092E363 File Offset: 0x0092C563
		// (set) Token: 0x0602083A RID: 133178 RVA: 0x0092E377 File Offset: 0x0092C577
		[Nullable(2)]
		public unsafe USkeletalMeshComponent EpropJiwawa08Md10011
		{
			[NullableContext(2)]
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<USkeletalMeshComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_E_DollItem_8_C.__PropertyOffset_0);
			}
			[NullableContext(2)]
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_E_DollItem_8_C.__PropertyOffset_0, value);
			}
		}

		// Token: 0x0602083B RID: 133179 RVA: 0x0092E38C File Offset: 0x0092C58C
		protected BP_E_DollItem_8_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x0401041F RID: 66591
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Render/RuntimeBP/Scene/Common/DollMachine/BP_E_DollItem_8.BP_E_DollItem_8_C";

		// Token: 0x04010420 RID: 66592
		private static IntPtr _ClassPtr;

		// Token: 0x04010421 RID: 66593
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x04010422 RID: 66594
		internal new static int __PropertyOffset_0;
	}
}
