using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Character.BaseCharacter.StateMachine
{
	// Token: 0x020042C6 RID: 17094
	[UnrealObjectPath("/Game/Aki/Character/BaseCharacter/StateMachine/BP_SM_ConditionCheckGroupPatrol.BP_SM_ConditionCheckGroupPatrol_C")]
	[UnrealStructLayout(56, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 56)]
	public class BP_SM_ConditionCheckGroupPatrol_C : UASMConditionBase, IUnrealUObject, IUnrealObject
	{
		// Token: 0x0602D5CF RID: 185807 RVA: 0x00ABE1B8 File Offset: 0x00ABC3B8
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_SM_ConditionCheckGroupPatrol_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Character/BaseCharacter/StateMachine/BP_SM_ConditionCheckGroupPatrol.BP_SM_ConditionCheckGroupPatrol_C");
			}
			return BP_SM_ConditionCheckGroupPatrol_C._ClassPtr;
		}

		// Token: 0x0602D5D0 RID: 185808 RVA: 0x00ABE1DC File Offset: 0x00ABC3DC
		public BP_SM_ConditionCheckGroupPatrol_C() : this(BuiltinUtils.AllocNativeUObject(BP_SM_ConditionCheckGroupPatrol_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x0602D5D1 RID: 185809 RVA: 0x00ABE204 File Offset: 0x00ABC404
		[NullableContext(1)]
		public BP_SM_ConditionCheckGroupPatrol_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_SM_ConditionCheckGroupPatrol_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x0602D5D2 RID: 185810 RVA: 0x00ABE237 File Offset: 0x00ABC437
		protected BP_SM_ConditionCheckGroupPatrol_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x04019706 RID: 104198
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Character/BaseCharacter/StateMachine/BP_SM_ConditionCheckGroupPatrol.BP_SM_ConditionCheckGroupPatrol_C";

		// Token: 0x04019707 RID: 104199
		private static IntPtr _ClassPtr;

		// Token: 0x04019708 RID: 104200
		private static IntPtr _ClassDefaultObjectPtr;
	}
}
