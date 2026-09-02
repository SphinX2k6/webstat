using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Render.RuntimeBP.Scene.Common.DollMachine
{
	// Token: 0x02003B10 RID: 15120
	[UnrealObjectPath("/Game/Aki/Render/RuntimeBP/Scene/Common/DollMachine/BP_E_DollItem_2.BP_E_DollItem_2_C")]
	[UnrealStructLayout(1536, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 1536)]
	public class BP_E_DollItem_2_C : BP_DollActor_C, IUnrealUObject, IUnrealObject
	{
		// Token: 0x0602080C RID: 133132 RVA: 0x0092DDF5 File Offset: 0x0092BFF5
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_E_DollItem_2_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Render/RuntimeBP/Scene/Common/DollMachine/BP_E_DollItem_2.BP_E_DollItem_2_C");
			}
			return BP_E_DollItem_2_C._ClassPtr;
		}

		// Token: 0x0602080D RID: 133133 RVA: 0x0092DE1C File Offset: 0x0092C01C
		public BP_E_DollItem_2_C() : this(BuiltinUtils.AllocNativeUObject(BP_E_DollItem_2_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x0602080E RID: 133134 RVA: 0x0092DE44 File Offset: 0x0092C044
		[NullableContext(1)]
		public BP_E_DollItem_2_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_E_DollItem_2_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x170035E9 RID: 13801
		// (get) Token: 0x0602080F RID: 133135 RVA: 0x0092DE77 File Offset: 0x0092C077
		// (set) Token: 0x06020810 RID: 133136 RVA: 0x0092DE8B File Offset: 0x0092C08B
		[Nullable(2)]
		public unsafe USkeletalMeshComponent EpropJiwawa02Md10011
		{
			[NullableContext(2)]
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<USkeletalMeshComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_E_DollItem_2_C.__PropertyOffset_0);
			}
			[NullableContext(2)]
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_E_DollItem_2_C.__PropertyOffset_0, value);
			}
		}

		// Token: 0x06020811 RID: 133137 RVA: 0x0092DEA0 File Offset: 0x0092C0A0
		protected BP_E_DollItem_2_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x04010403 RID: 66563
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Render/RuntimeBP/Scene/Common/DollMachine/BP_E_DollItem_2.BP_E_DollItem_2_C";

		// Token: 0x04010404 RID: 66564
		private static IntPtr _ClassPtr;

		// Token: 0x04010405 RID: 66565
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x04010406 RID: 66566
		internal new static int __PropertyOffset_0;
	}
}
