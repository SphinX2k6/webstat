using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Character.BaseCharacter.StateMachine
{
	// Token: 0x020042CE RID: 17102
	[UnrealObjectPath("/Game/Aki/Character/BaseCharacter/StateMachine/BP_SM_ConditionHate.BP_SM_ConditionHate_C")]
	[UnrealStructLayout(56, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 56)]
	public class BP_SM_ConditionHate_C : UASMConditionBase, IUnrealUObject, IUnrealObject
	{
		// Token: 0x0602D5F9 RID: 185849 RVA: 0x00ABE6D4 File Offset: 0x00ABC8D4
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_SM_ConditionHate_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Character/BaseCharacter/StateMachine/BP_SM_ConditionHate.BP_SM_ConditionHate_C");
			}
			return BP_SM_ConditionHate_C._ClassPtr;
		}

		// Token: 0x0602D5FA RID: 185850 RVA: 0x00ABE6F8 File Offset: 0x00ABC8F8
		public BP_SM_ConditionHate_C() : this(BuiltinUtils.AllocNativeUObject(BP_SM_ConditionHate_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x0602D5FB RID: 185851 RVA: 0x00ABE720 File Offset: 0x00ABC920
		[NullableContext(1)]
		public BP_SM_ConditionHate_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_SM_ConditionHate_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x0602D5FC RID: 185852 RVA: 0x00ABE753 File Offset: 0x00ABC953
		protected BP_SM_ConditionHate_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x04019723 RID: 104227
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Character/BaseCharacter/StateMachine/BP_SM_ConditionHate.BP_SM_ConditionHate_C";

		// Token: 0x04019724 RID: 104228
		private static IntPtr _ClassPtr;

		// Token: 0x04019725 RID: 104229
		private static IntPtr _ClassDefaultObjectPtr;
	}
}
