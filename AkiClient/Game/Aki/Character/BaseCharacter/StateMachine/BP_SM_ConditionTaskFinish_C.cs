using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Character.BaseCharacter.StateMachine
{
	// Token: 0x020042D5 RID: 17109
	[UnrealObjectPath("/Game/Aki/Character/BaseCharacter/StateMachine/BP_SM_ConditionTaskFinish.BP_SM_ConditionTaskFinish_C")]
	[UnrealStructLayout(56, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 56)]
	public class BP_SM_ConditionTaskFinish_C : UASMConditionBase, IUnrealUObject, IUnrealObject
	{
		// Token: 0x0602D637 RID: 185911 RVA: 0x00ABECDE File Offset: 0x00ABCEDE
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_SM_ConditionTaskFinish_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Character/BaseCharacter/StateMachine/BP_SM_ConditionTaskFinish.BP_SM_ConditionTaskFinish_C");
			}
			return BP_SM_ConditionTaskFinish_C._ClassPtr;
		}

		// Token: 0x0602D638 RID: 185912 RVA: 0x00ABED04 File Offset: 0x00ABCF04
		public BP_SM_ConditionTaskFinish_C() : this(BuiltinUtils.AllocNativeUObject(BP_SM_ConditionTaskFinish_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x0602D639 RID: 185913 RVA: 0x00ABED2C File Offset: 0x00ABCF2C
		[NullableContext(1)]
		public BP_SM_ConditionTaskFinish_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_SM_ConditionTaskFinish_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x0602D63A RID: 185914 RVA: 0x00ABED5F File Offset: 0x00ABCF5F
		protected BP_SM_ConditionTaskFinish_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x04019749 RID: 104265
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Character/BaseCharacter/StateMachine/BP_SM_ConditionTaskFinish.BP_SM_ConditionTaskFinish_C";

		// Token: 0x0401974A RID: 104266
		private static IntPtr _ClassPtr;

		// Token: 0x0401974B RID: 104267
		private static IntPtr _ClassDefaultObjectPtr;
	}
}
