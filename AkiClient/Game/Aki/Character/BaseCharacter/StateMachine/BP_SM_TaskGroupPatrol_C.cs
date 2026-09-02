using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Character.BaseCharacter.StateMachine
{
	// Token: 0x020042DA RID: 17114
	[UnrealObjectPath("/Game/Aki/Character/BaseCharacter/StateMachine/BP_SM_TaskGroupPatrol.BP_SM_TaskGroupPatrol_C")]
	[UnrealStructLayout(48, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 48)]
	public class BP_SM_TaskGroupPatrol_C : UASMTask, IUnrealUObject, IUnrealObject
	{
		// Token: 0x0602D660 RID: 185952 RVA: 0x00ABF1B2 File Offset: 0x00ABD3B2
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_SM_TaskGroupPatrol_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Character/BaseCharacter/StateMachine/BP_SM_TaskGroupPatrol.BP_SM_TaskGroupPatrol_C");
			}
			return BP_SM_TaskGroupPatrol_C._ClassPtr;
		}

		// Token: 0x0602D661 RID: 185953 RVA: 0x00ABF1D8 File Offset: 0x00ABD3D8
		public BP_SM_TaskGroupPatrol_C() : this(BuiltinUtils.AllocNativeUObject(BP_SM_TaskGroupPatrol_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x0602D662 RID: 185954 RVA: 0x00ABF200 File Offset: 0x00ABD400
		[NullableContext(1)]
		public BP_SM_TaskGroupPatrol_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_SM_TaskGroupPatrol_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x0602D663 RID: 185955 RVA: 0x00ABF233 File Offset: 0x00ABD433
		protected BP_SM_TaskGroupPatrol_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x04019766 RID: 104294
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Character/BaseCharacter/StateMachine/BP_SM_TaskGroupPatrol.BP_SM_TaskGroupPatrol_C";

		// Token: 0x04019767 RID: 104295
		private static IntPtr _ClassPtr;

		// Token: 0x04019768 RID: 104296
		private static IntPtr _ClassDefaultObjectPtr;
	}
}
