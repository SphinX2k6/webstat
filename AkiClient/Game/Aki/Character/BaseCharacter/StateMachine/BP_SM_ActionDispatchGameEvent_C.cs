using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Character.BaseCharacter.StateMachine
{
	// Token: 0x020042A7 RID: 17063
	[UnrealObjectPath("/Game/Aki/Character/BaseCharacter/StateMachine/BP_SM_ActionDispatchGameEvent.BP_SM_ActionDispatchGameEvent_C")]
	[UnrealStructLayout(48, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 48)]
	public class BP_SM_ActionDispatchGameEvent_C : UASMAction, IUnrealUObject, IUnrealObject
	{
		// Token: 0x0602D4E5 RID: 185573 RVA: 0x00ABC891 File Offset: 0x00ABAA91
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_SM_ActionDispatchGameEvent_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Character/BaseCharacter/StateMachine/BP_SM_ActionDispatchGameEvent.BP_SM_ActionDispatchGameEvent_C");
			}
			return BP_SM_ActionDispatchGameEvent_C._ClassPtr;
		}

		// Token: 0x0602D4E6 RID: 185574 RVA: 0x00ABC8B8 File Offset: 0x00ABAAB8
		public BP_SM_ActionDispatchGameEvent_C() : this(BuiltinUtils.AllocNativeUObject(BP_SM_ActionDispatchGameEvent_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x0602D4E7 RID: 185575 RVA: 0x00ABC8E0 File Offset: 0x00ABAAE0
		[NullableContext(1)]
		public BP_SM_ActionDispatchGameEvent_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_SM_ActionDispatchGameEvent_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x0602D4E8 RID: 185576 RVA: 0x00ABC913 File Offset: 0x00ABAB13
		protected BP_SM_ActionDispatchGameEvent_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x0401966D RID: 104045
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Character/BaseCharacter/StateMachine/BP_SM_ActionDispatchGameEvent.BP_SM_ActionDispatchGameEvent_C";

		// Token: 0x0401966E RID: 104046
		private static IntPtr _ClassPtr;

		// Token: 0x0401966F RID: 104047
		private static IntPtr _ClassDefaultObjectPtr;
	}
}
