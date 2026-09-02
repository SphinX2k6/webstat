using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Character.BaseCharacter.StateMachine
{
	// Token: 0x020042C7 RID: 17095
	[UnrealObjectPath("/Game/Aki/Character/BaseCharacter/StateMachine/BP_SM_ConditionCheckGroupPerform.BP_SM_ConditionCheckGroupPerform_C")]
	[UnrealStructLayout(56, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 56)]
	public class BP_SM_ConditionCheckGroupPerform_C : UASMConditionBase, IUnrealUObject, IUnrealObject
	{
		// Token: 0x0602D5D3 RID: 185811 RVA: 0x00ABE240 File Offset: 0x00ABC440
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_SM_ConditionCheckGroupPerform_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Character/BaseCharacter/StateMachine/BP_SM_ConditionCheckGroupPerform.BP_SM_ConditionCheckGroupPerform_C");
			}
			return BP_SM_ConditionCheckGroupPerform_C._ClassPtr;
		}

		// Token: 0x0602D5D4 RID: 185812 RVA: 0x00ABE264 File Offset: 0x00ABC464
		public BP_SM_ConditionCheckGroupPerform_C() : this(BuiltinUtils.AllocNativeUObject(BP_SM_ConditionCheckGroupPerform_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x0602D5D5 RID: 185813 RVA: 0x00ABE28C File Offset: 0x00ABC48C
		[NullableContext(1)]
		public BP_SM_ConditionCheckGroupPerform_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_SM_ConditionCheckGroupPerform_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x0602D5D6 RID: 185814 RVA: 0x00ABE2BF File Offset: 0x00ABC4BF
		protected BP_SM_ConditionCheckGroupPerform_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x04019709 RID: 104201
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Character/BaseCharacter/StateMachine/BP_SM_ConditionCheckGroupPerform.BP_SM_ConditionCheckGroupPerform_C";

		// Token: 0x0401970A RID: 104202
		private static IntPtr _ClassPtr;

		// Token: 0x0401970B RID: 104203
		private static IntPtr _ClassDefaultObjectPtr;
	}
}
