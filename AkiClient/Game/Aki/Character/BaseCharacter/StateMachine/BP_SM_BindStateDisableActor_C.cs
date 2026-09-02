using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Character.BaseCharacter.StateMachine
{
	// Token: 0x020042BB RID: 17083
	[UnrealObjectPath("/Game/Aki/Character/BaseCharacter/StateMachine/BP_SM_BindStateDisableActor.BP_SM_BindStateDisableActor_C")]
	[UnrealStructLayout(48, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 48)]
	public class BP_SM_BindStateDisableActor_C : UASMBindState, IUnrealUObject, IUnrealObject
	{
		// Token: 0x0602D575 RID: 185717 RVA: 0x00ABD84E File Offset: 0x00ABBA4E
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_SM_BindStateDisableActor_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Character/BaseCharacter/StateMachine/BP_SM_BindStateDisableActor.BP_SM_BindStateDisableActor_C");
			}
			return BP_SM_BindStateDisableActor_C._ClassPtr;
		}

		// Token: 0x0602D576 RID: 185718 RVA: 0x00ABD874 File Offset: 0x00ABBA74
		public BP_SM_BindStateDisableActor_C() : this(BuiltinUtils.AllocNativeUObject(BP_SM_BindStateDisableActor_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x0602D577 RID: 185719 RVA: 0x00ABD89C File Offset: 0x00ABBA9C
		[NullableContext(1)]
		public BP_SM_BindStateDisableActor_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_SM_BindStateDisableActor_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x0602D578 RID: 185720 RVA: 0x00ABD8CF File Offset: 0x00ABBACF
		protected BP_SM_BindStateDisableActor_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x040196CD RID: 104141
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Character/BaseCharacter/StateMachine/BP_SM_BindStateDisableActor.BP_SM_BindStateDisableActor_C";

		// Token: 0x040196CE RID: 104142
		private static IntPtr _ClassPtr;

		// Token: 0x040196CF RID: 104143
		private static IntPtr _ClassDefaultObjectPtr;
	}
}
