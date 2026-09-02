using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Character.BaseCharacter.StateMachine
{
	// Token: 0x020042CD RID: 17101
	[UnrealObjectPath("/Game/Aki/Character/BaseCharacter/StateMachine/BP_SM_ConditionHasMoveInput.BP_SM_ConditionHasMoveInput_C")]
	[UnrealStructLayout(56, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 56)]
	public class BP_SM_ConditionHasMoveInput_C : UASMConditionBase, IUnrealUObject, IUnrealObject
	{
		// Token: 0x0602D5F5 RID: 185845 RVA: 0x00ABE649 File Offset: 0x00ABC849
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_SM_ConditionHasMoveInput_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Character/BaseCharacter/StateMachine/BP_SM_ConditionHasMoveInput.BP_SM_ConditionHasMoveInput_C");
			}
			return BP_SM_ConditionHasMoveInput_C._ClassPtr;
		}

		// Token: 0x0602D5F6 RID: 185846 RVA: 0x00ABE670 File Offset: 0x00ABC870
		public BP_SM_ConditionHasMoveInput_C() : this(BuiltinUtils.AllocNativeUObject(BP_SM_ConditionHasMoveInput_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x0602D5F7 RID: 185847 RVA: 0x00ABE698 File Offset: 0x00ABC898
		[NullableContext(1)]
		public BP_SM_ConditionHasMoveInput_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_SM_ConditionHasMoveInput_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x0602D5F8 RID: 185848 RVA: 0x00ABE6CB File Offset: 0x00ABC8CB
		protected BP_SM_ConditionHasMoveInput_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x04019720 RID: 104224
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Character/BaseCharacter/StateMachine/BP_SM_ConditionHasMoveInput.BP_SM_ConditionHasMoveInput_C";

		// Token: 0x04019721 RID: 104225
		private static IntPtr _ClassPtr;

		// Token: 0x04019722 RID: 104226
		private static IntPtr _ClassDefaultObjectPtr;
	}
}
