using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Character.BaseCharacter.StateMachine
{
	// Token: 0x020042AF RID: 17071
	[UnrealObjectPath("/Game/Aki/Character/BaseCharacter/StateMachine/BP_SM_ActionSetRageFullAttribute.BP_SM_ActionSetRageFullAttribute_C")]
	[UnrealStructLayout(48, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 48)]
	public class BP_SM_ActionSetRageFullAttribute_C : UASMAction, IUnrealUObject, IUnrealObject
	{
		// Token: 0x0602D513 RID: 185619 RVA: 0x00ABCDD9 File Offset: 0x00ABAFD9
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_SM_ActionSetRageFullAttribute_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Character/BaseCharacter/StateMachine/BP_SM_ActionSetRageFullAttribute.BP_SM_ActionSetRageFullAttribute_C");
			}
			return BP_SM_ActionSetRageFullAttribute_C._ClassPtr;
		}

		// Token: 0x0602D514 RID: 185620 RVA: 0x00ABCE00 File Offset: 0x00ABB000
		public BP_SM_ActionSetRageFullAttribute_C() : this(BuiltinUtils.AllocNativeUObject(BP_SM_ActionSetRageFullAttribute_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x0602D515 RID: 185621 RVA: 0x00ABCE28 File Offset: 0x00ABB028
		[NullableContext(1)]
		public BP_SM_ActionSetRageFullAttribute_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_SM_ActionSetRageFullAttribute_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x0602D516 RID: 185622 RVA: 0x00ABCE5B File Offset: 0x00ABB05B
		protected BP_SM_ActionSetRageFullAttribute_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x0401968C RID: 104076
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Character/BaseCharacter/StateMachine/BP_SM_ActionSetRageFullAttribute.BP_SM_ActionSetRageFullAttribute_C";

		// Token: 0x0401968D RID: 104077
		private static IntPtr _ClassPtr;

		// Token: 0x0401968E RID: 104078
		private static IntPtr _ClassDefaultObjectPtr;
	}
}
