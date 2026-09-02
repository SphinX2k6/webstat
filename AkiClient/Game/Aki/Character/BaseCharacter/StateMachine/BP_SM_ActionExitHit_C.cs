using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Character.BaseCharacter.StateMachine
{
	// Token: 0x020042A9 RID: 17065
	[UnrealObjectPath("/Game/Aki/Character/BaseCharacter/StateMachine/BP_SM_ActionExitHit.BP_SM_ActionExitHit_C")]
	[UnrealStructLayout(48, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 48)]
	public class BP_SM_ActionExitHit_C : UASMAction, IUnrealUObject, IUnrealObject
	{
		// Token: 0x0602D4ED RID: 185581 RVA: 0x00ABC9A4 File Offset: 0x00ABABA4
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_SM_ActionExitHit_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Character/BaseCharacter/StateMachine/BP_SM_ActionExitHit.BP_SM_ActionExitHit_C");
			}
			return BP_SM_ActionExitHit_C._ClassPtr;
		}

		// Token: 0x0602D4EE RID: 185582 RVA: 0x00ABC9C8 File Offset: 0x00ABABC8
		public BP_SM_ActionExitHit_C() : this(BuiltinUtils.AllocNativeUObject(BP_SM_ActionExitHit_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x0602D4EF RID: 185583 RVA: 0x00ABC9F0 File Offset: 0x00ABABF0
		[NullableContext(1)]
		public BP_SM_ActionExitHit_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_SM_ActionExitHit_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x0602D4F0 RID: 185584 RVA: 0x00ABCA23 File Offset: 0x00ABAC23
		protected BP_SM_ActionExitHit_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x04019673 RID: 104051
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Character/BaseCharacter/StateMachine/BP_SM_ActionExitHit.BP_SM_ActionExitHit_C";

		// Token: 0x04019674 RID: 104052
		private static IntPtr _ClassPtr;

		// Token: 0x04019675 RID: 104053
		private static IntPtr _ClassDefaultObjectPtr;
	}
}
