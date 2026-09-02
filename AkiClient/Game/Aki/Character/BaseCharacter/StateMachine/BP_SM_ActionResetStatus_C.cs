using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Character.BaseCharacter.StateMachine
{
	// Token: 0x020042AD RID: 17069
	[UnrealObjectPath("/Game/Aki/Character/BaseCharacter/StateMachine/BP_SM_ActionResetStatus.BP_SM_ActionResetStatus_C")]
	[UnrealStructLayout(48, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 48)]
	public class BP_SM_ActionResetStatus_C : UASMAction, IUnrealUObject, IUnrealObject
	{
		// Token: 0x0602D509 RID: 185609 RVA: 0x00ABCC9F File Offset: 0x00ABAE9F
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_SM_ActionResetStatus_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Character/BaseCharacter/StateMachine/BP_SM_ActionResetStatus.BP_SM_ActionResetStatus_C");
			}
			return BP_SM_ActionResetStatus_C._ClassPtr;
		}

		// Token: 0x0602D50A RID: 185610 RVA: 0x00ABCCC4 File Offset: 0x00ABAEC4
		public BP_SM_ActionResetStatus_C() : this(BuiltinUtils.AllocNativeUObject(BP_SM_ActionResetStatus_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x0602D50B RID: 185611 RVA: 0x00ABCCEC File Offset: 0x00ABAEEC
		[NullableContext(1)]
		public BP_SM_ActionResetStatus_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_SM_ActionResetStatus_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x0602D50C RID: 185612 RVA: 0x00ABCD1F File Offset: 0x00ABAF1F
		protected BP_SM_ActionResetStatus_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x04019685 RID: 104069
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Character/BaseCharacter/StateMachine/BP_SM_ActionResetStatus.BP_SM_ActionResetStatus_C";

		// Token: 0x04019686 RID: 104070
		private static IntPtr _ClassPtr;

		// Token: 0x04019687 RID: 104071
		private static IntPtr _ClassDefaultObjectPtr;
	}
}
