using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Character.BaseCharacter.StateMachine
{
	// Token: 0x020042A3 RID: 17059
	[UnrealObjectPath("/Game/Aki/Character/BaseCharacter/StateMachine/BP_SM_ActionCameraLockOn.BP_SM_ActionCameraLockOn_C")]
	[UnrealStructLayout(56, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 49)]
	public class BP_SM_ActionCameraLockOn_C : UASMAction, IUnrealUObject, IUnrealObject
	{
		// Token: 0x0602D4CB RID: 185547 RVA: 0x00ABC582 File Offset: 0x00ABA782
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_SM_ActionCameraLockOn_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Character/BaseCharacter/StateMachine/BP_SM_ActionCameraLockOn.BP_SM_ActionCameraLockOn_C");
			}
			return BP_SM_ActionCameraLockOn_C._ClassPtr;
		}

		// Token: 0x0602D4CC RID: 185548 RVA: 0x00ABC5A8 File Offset: 0x00ABA7A8
		public BP_SM_ActionCameraLockOn_C() : this(BuiltinUtils.AllocNativeUObject(BP_SM_ActionCameraLockOn_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x0602D4CD RID: 185549 RVA: 0x00ABC5D0 File Offset: 0x00ABA7D0
		[NullableContext(1)]
		public BP_SM_ActionCameraLockOn_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_SM_ActionCameraLockOn_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x17007B7E RID: 31614
		// (get) Token: 0x0602D4CE RID: 185550 RVA: 0x00ABC603 File Offset: 0x00ABA803
		// (set) Token: 0x0602D4CF RID: 185551 RVA: 0x00ABC613 File Offset: 0x00ABA813
		public unsafe bool 是否解耦
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SM_ActionCameraLockOn_C.__PropertyOffset_0) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_SM_ActionCameraLockOn_C.__PropertyOffset_0) = (value ? 1 : 0);
			}
		}

		// Token: 0x0602D4D0 RID: 185552 RVA: 0x00ABC624 File Offset: 0x00ABA824
		protected BP_SM_ActionCameraLockOn_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x0401965B RID: 104027
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Character/BaseCharacter/StateMachine/BP_SM_ActionCameraLockOn.BP_SM_ActionCameraLockOn_C";

		// Token: 0x0401965C RID: 104028
		private static IntPtr _ClassPtr;

		// Token: 0x0401965D RID: 104029
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x0401965E RID: 104030
		internal static int __PropertyOffset_0;
	}
}
