using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Character.BaseCharacter.StateMachine
{
	// Token: 0x020042AE RID: 17070
	[UnrealObjectPath("/Game/Aki/Character/BaseCharacter/StateMachine/BP_SM_ActionSendGameplayEvent.BP_SM_ActionSendGameplayEvent_C")]
	[UnrealStructLayout(64, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 60)]
	public class BP_SM_ActionSendGameplayEvent_C : UASMAction, IUnrealUObject, IUnrealObject
	{
		// Token: 0x0602D50D RID: 185613 RVA: 0x00ABCD28 File Offset: 0x00ABAF28
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_SM_ActionSendGameplayEvent_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Character/BaseCharacter/StateMachine/BP_SM_ActionSendGameplayEvent.BP_SM_ActionSendGameplayEvent_C");
			}
			return BP_SM_ActionSendGameplayEvent_C._ClassPtr;
		}

		// Token: 0x0602D50E RID: 185614 RVA: 0x00ABCD4C File Offset: 0x00ABAF4C
		public BP_SM_ActionSendGameplayEvent_C() : this(BuiltinUtils.AllocNativeUObject(BP_SM_ActionSendGameplayEvent_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x0602D50F RID: 185615 RVA: 0x00ABCD74 File Offset: 0x00ABAF74
		[NullableContext(1)]
		public BP_SM_ActionSendGameplayEvent_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_SM_ActionSendGameplayEvent_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x17007B89 RID: 31625
		// (get) Token: 0x0602D510 RID: 185616 RVA: 0x00ABCDA7 File Offset: 0x00ABAFA7
		// (set) Token: 0x0602D511 RID: 185617 RVA: 0x00ABCDBB File Offset: 0x00ABAFBB
		public unsafe FGameplayTag Tag
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SM_ActionSendGameplayEvent_C.__PropertyOffset_0);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_SM_ActionSendGameplayEvent_C.__PropertyOffset_0) = value;
			}
		}

		// Token: 0x0602D512 RID: 185618 RVA: 0x00ABCDD0 File Offset: 0x00ABAFD0
		protected BP_SM_ActionSendGameplayEvent_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x04019688 RID: 104072
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Character/BaseCharacter/StateMachine/BP_SM_ActionSendGameplayEvent.BP_SM_ActionSendGameplayEvent_C";

		// Token: 0x04019689 RID: 104073
		private static IntPtr _ClassPtr;

		// Token: 0x0401968A RID: 104074
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x0401968B RID: 104075
		internal static int __PropertyOffset_0;
	}
}
