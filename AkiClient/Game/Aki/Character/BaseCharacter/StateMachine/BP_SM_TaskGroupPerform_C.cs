using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Character.BaseCharacter.StateMachine
{
	// Token: 0x020042DB RID: 17115
	[UnrealObjectPath("/Game/Aki/Character/BaseCharacter/StateMachine/BP_SM_TaskGroupPerform.BP_SM_TaskGroupPerform_C")]
	[UnrealStructLayout(48, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 48)]
	public class BP_SM_TaskGroupPerform_C : UASMTask, IUnrealUObject, IUnrealObject
	{
		// Token: 0x0602D664 RID: 185956 RVA: 0x00ABF23C File Offset: 0x00ABD43C
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_SM_TaskGroupPerform_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Character/BaseCharacter/StateMachine/BP_SM_TaskGroupPerform.BP_SM_TaskGroupPerform_C");
			}
			return BP_SM_TaskGroupPerform_C._ClassPtr;
		}

		// Token: 0x0602D665 RID: 185957 RVA: 0x00ABF260 File Offset: 0x00ABD460
		public BP_SM_TaskGroupPerform_C() : this(BuiltinUtils.AllocNativeUObject(BP_SM_TaskGroupPerform_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x0602D666 RID: 185958 RVA: 0x00ABF288 File Offset: 0x00ABD488
		[NullableContext(1)]
		public BP_SM_TaskGroupPerform_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_SM_TaskGroupPerform_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x0602D667 RID: 185959 RVA: 0x00ABF2BB File Offset: 0x00ABD4BB
		protected BP_SM_TaskGroupPerform_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x04019769 RID: 104297
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Character/BaseCharacter/StateMachine/BP_SM_TaskGroupPerform.BP_SM_TaskGroupPerform_C";

		// Token: 0x0401976A RID: 104298
		private static IntPtr _ClassPtr;

		// Token: 0x0401976B RID: 104299
		private static IntPtr _ClassDefaultObjectPtr;
	}
}
