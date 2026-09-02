using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Character.BaseCharacter.StateMachine
{
	// Token: 0x020042A6 RID: 17062
	[NullableContext(1)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Character/BaseCharacter/StateMachine/BP_SM_ActionDispatchEvent.BP_SM_ActionDispatchEvent_C")]
	[UnrealStructLayout(64, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 64)]
	public class BP_SM_ActionDispatchEvent_C : UASMAction, IUnrealUObject, IUnrealObject
	{
		// Token: 0x0602D4DF RID: 185567 RVA: 0x00ABC7DD File Offset: 0x00ABA9DD
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_SM_ActionDispatchEvent_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Character/BaseCharacter/StateMachine/BP_SM_ActionDispatchEvent.BP_SM_ActionDispatchEvent_C");
			}
			return BP_SM_ActionDispatchEvent_C._ClassPtr;
		}

		// Token: 0x0602D4E0 RID: 185568 RVA: 0x00ABC804 File Offset: 0x00ABAA04
		public BP_SM_ActionDispatchEvent_C() : this(BuiltinUtils.AllocNativeUObject(BP_SM_ActionDispatchEvent_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x0602D4E1 RID: 185569 RVA: 0x00ABC82C File Offset: 0x00ABAA2C
		public BP_SM_ActionDispatchEvent_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_SM_ActionDispatchEvent_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x17007B82 RID: 31618
		// (get) Token: 0x0602D4E2 RID: 185570 RVA: 0x00ABC85F File Offset: 0x00ABAA5F
		// (set) Token: 0x0602D4E3 RID: 185571 RVA: 0x00ABC873 File Offset: 0x00ABAA73
		public unsafe string 派发事件名
		{
			get
			{
				return FString.ToString((void*)(base.NativePtr + (byte*)((IntPtr)BP_SM_ActionDispatchEvent_C.__PropertyOffset_0)));
			}
			set
			{
				FString.CopyFrom((void*)(base.NativePtr + (byte*)((IntPtr)BP_SM_ActionDispatchEvent_C.__PropertyOffset_0)), value);
			}
		}

		// Token: 0x0602D4E4 RID: 185572 RVA: 0x00ABC888 File Offset: 0x00ABAA88
		protected BP_SM_ActionDispatchEvent_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x04019669 RID: 104041
		public new const string __ObjectPath = "/Game/Aki/Character/BaseCharacter/StateMachine/BP_SM_ActionDispatchEvent.BP_SM_ActionDispatchEvent_C";

		// Token: 0x0401966A RID: 104042
		private static IntPtr _ClassPtr;

		// Token: 0x0401966B RID: 104043
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x0401966C RID: 104044
		internal static int __PropertyOffset_0;
	}
}
