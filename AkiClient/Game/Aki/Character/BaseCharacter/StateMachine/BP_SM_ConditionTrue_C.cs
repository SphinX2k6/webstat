using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Character.BaseCharacter.StateMachine
{
	// Token: 0x020042D7 RID: 17111
	[UnrealObjectPath("/Game/Aki/Character/BaseCharacter/StateMachine/BP_SM_ConditionTrue.BP_SM_ConditionTrue_C")]
	[UnrealStructLayout(56, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 56)]
	public class BP_SM_ConditionTrue_C : UASMConditionBase, IUnrealUObject, IUnrealObject
	{
		// Token: 0x0602D645 RID: 185925 RVA: 0x00ABEE53 File Offset: 0x00ABD053
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_SM_ConditionTrue_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Character/BaseCharacter/StateMachine/BP_SM_ConditionTrue.BP_SM_ConditionTrue_C");
			}
			return BP_SM_ConditionTrue_C._ClassPtr;
		}

		// Token: 0x0602D646 RID: 185926 RVA: 0x00ABEE78 File Offset: 0x00ABD078
		public BP_SM_ConditionTrue_C() : this(BuiltinUtils.AllocNativeUObject(BP_SM_ConditionTrue_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x0602D647 RID: 185927 RVA: 0x00ABEEA0 File Offset: 0x00ABD0A0
		[NullableContext(1)]
		public BP_SM_ConditionTrue_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_SM_ConditionTrue_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x0602D648 RID: 185928 RVA: 0x00ABEED3 File Offset: 0x00ABD0D3
		protected BP_SM_ConditionTrue_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x04019752 RID: 104274
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Character/BaseCharacter/StateMachine/BP_SM_ConditionTrue.BP_SM_ConditionTrue_C";

		// Token: 0x04019753 RID: 104275
		private static IntPtr _ClassPtr;

		// Token: 0x04019754 RID: 104276
		private static IntPtr _ClassDefaultObjectPtr;
	}
}
