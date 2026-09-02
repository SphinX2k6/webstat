using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Render.RuntimeBP.Scene.Common.DollMachine
{
	// Token: 0x02003B12 RID: 15122
	[UnrealObjectPath("/Game/Aki/Render/RuntimeBP/Scene/Common/DollMachine/BP_E_DollItem_4.BP_E_DollItem_4_C")]
	[UnrealStructLayout(1536, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 1536)]
	public class BP_E_DollItem_4_C : BP_DollActor_C, IUnrealUObject, IUnrealObject
	{
		// Token: 0x06020818 RID: 133144 RVA: 0x0092DF5D File Offset: 0x0092C15D
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_E_DollItem_4_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Render/RuntimeBP/Scene/Common/DollMachine/BP_E_DollItem_4.BP_E_DollItem_4_C");
			}
			return BP_E_DollItem_4_C._ClassPtr;
		}

		// Token: 0x06020819 RID: 133145 RVA: 0x0092DF84 File Offset: 0x0092C184
		public BP_E_DollItem_4_C() : this(BuiltinUtils.AllocNativeUObject(BP_E_DollItem_4_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x0602081A RID: 133146 RVA: 0x0092DFAC File Offset: 0x0092C1AC
		[NullableContext(1)]
		public BP_E_DollItem_4_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_E_DollItem_4_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x170035EB RID: 13803
		// (get) Token: 0x0602081B RID: 133147 RVA: 0x0092DFDF File Offset: 0x0092C1DF
		// (set) Token: 0x0602081C RID: 133148 RVA: 0x0092DFF3 File Offset: 0x0092C1F3
		[Nullable(2)]
		public unsafe USkeletalMeshComponent EpropJiwawa04Md10011
		{
			[NullableContext(2)]
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<USkeletalMeshComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_E_DollItem_4_C.__PropertyOffset_0);
			}
			[NullableContext(2)]
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_E_DollItem_4_C.__PropertyOffset_0, value);
			}
		}

		// Token: 0x0602081D RID: 133149 RVA: 0x0092E008 File Offset: 0x0092C208
		protected BP_E_DollItem_4_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x0401040B RID: 66571
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Render/RuntimeBP/Scene/Common/DollMachine/BP_E_DollItem_4.BP_E_DollItem_4_C";

		// Token: 0x0401040C RID: 66572
		private static IntPtr _ClassPtr;

		// Token: 0x0401040D RID: 66573
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x0401040E RID: 66574
		internal new static int __PropertyOffset_0;
	}
}
