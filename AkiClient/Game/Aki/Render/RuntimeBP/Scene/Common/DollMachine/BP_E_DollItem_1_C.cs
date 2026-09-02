using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Render.RuntimeBP.Scene.Common.DollMachine
{
	// Token: 0x02003B0F RID: 15119
	[UnrealObjectPath("/Game/Aki/Render/RuntimeBP/Scene/Common/DollMachine/BP_E_DollItem_1.BP_E_DollItem_1_C")]
	[UnrealStructLayout(1536, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 1536)]
	public class BP_E_DollItem_1_C : BP_DollActor_C, IUnrealUObject, IUnrealObject
	{
		// Token: 0x06020806 RID: 133126 RVA: 0x0092DD44 File Offset: 0x0092BF44
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_E_DollItem_1_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Render/RuntimeBP/Scene/Common/DollMachine/BP_E_DollItem_1.BP_E_DollItem_1_C");
			}
			return BP_E_DollItem_1_C._ClassPtr;
		}

		// Token: 0x06020807 RID: 133127 RVA: 0x0092DD68 File Offset: 0x0092BF68
		public BP_E_DollItem_1_C() : this(BuiltinUtils.AllocNativeUObject(BP_E_DollItem_1_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x06020808 RID: 133128 RVA: 0x0092DD90 File Offset: 0x0092BF90
		[NullableContext(1)]
		public BP_E_DollItem_1_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_E_DollItem_1_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x170035E8 RID: 13800
		// (get) Token: 0x06020809 RID: 133129 RVA: 0x0092DDC3 File Offset: 0x0092BFC3
		// (set) Token: 0x0602080A RID: 133130 RVA: 0x0092DDD7 File Offset: 0x0092BFD7
		[Nullable(2)]
		public unsafe USkeletalMeshComponent EpropJiwawa01Md10011
		{
			[NullableContext(2)]
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<USkeletalMeshComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_E_DollItem_1_C.__PropertyOffset_0);
			}
			[NullableContext(2)]
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_E_DollItem_1_C.__PropertyOffset_0, value);
			}
		}

		// Token: 0x0602080B RID: 133131 RVA: 0x0092DDEC File Offset: 0x0092BFEC
		protected BP_E_DollItem_1_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x040103FF RID: 66559
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Render/RuntimeBP/Scene/Common/DollMachine/BP_E_DollItem_1.BP_E_DollItem_1_C";

		// Token: 0x04010400 RID: 66560
		private static IntPtr _ClassPtr;

		// Token: 0x04010401 RID: 66561
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x04010402 RID: 66562
		internal new static int __PropertyOffset_0;
	}
}
