using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Character.BaseCharacter.StateMachine
{
	// Token: 0x020042D0 RID: 17104
	[NullableContext(1)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Character/BaseCharacter/StateMachine/BP_SM_ConditionListenEvent.BP_SM_ConditionListenEvent_C")]
	[UnrealStructLayout(72, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 72)]
	public class BP_SM_ConditionListenEvent_C : UASMConditionBase, IUnrealUObject, IUnrealObject
	{
		// Token: 0x0602D611 RID: 185873 RVA: 0x00ABE8EC File Offset: 0x00ABCAEC
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_SM_ConditionListenEvent_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Character/BaseCharacter/StateMachine/BP_SM_ConditionListenEvent.BP_SM_ConditionListenEvent_C");
			}
			return BP_SM_ConditionListenEvent_C._ClassPtr;
		}

		// Token: 0x0602D612 RID: 185874 RVA: 0x00ABE910 File Offset: 0x00ABCB10
		public BP_SM_ConditionListenEvent_C() : this(BuiltinUtils.AllocNativeUObject(BP_SM_ConditionListenEvent_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x0602D613 RID: 185875 RVA: 0x00ABE938 File Offset: 0x00ABCB38
		public BP_SM_ConditionListenEvent_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_SM_ConditionListenEvent_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x17007BC7 RID: 31687
		// (get) Token: 0x0602D614 RID: 185876 RVA: 0x00ABE96B File Offset: 0x00ABCB6B
		// (set) Token: 0x0602D615 RID: 185877 RVA: 0x00ABE97F File Offset: 0x00ABCB7F
		public unsafe string 监听事件名
		{
			get
			{
				return FString.ToString((void*)(base.NativePtr + (byte*)((IntPtr)BP_SM_ConditionListenEvent_C.__PropertyOffset_0)));
			}
			set
			{
				FString.CopyFrom((void*)(base.NativePtr + (byte*)((IntPtr)BP_SM_ConditionListenEvent_C.__PropertyOffset_0)), value);
			}
		}

		// Token: 0x0602D616 RID: 185878 RVA: 0x00ABE994 File Offset: 0x00ABCB94
		protected BP_SM_ConditionListenEvent_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x04019731 RID: 104241
		public new const string __ObjectPath = "/Game/Aki/Character/BaseCharacter/StateMachine/BP_SM_ConditionListenEvent.BP_SM_ConditionListenEvent_C";

		// Token: 0x04019732 RID: 104242
		private static IntPtr _ClassPtr;

		// Token: 0x04019733 RID: 104243
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x04019734 RID: 104244
		internal static int __PropertyOffset_0;
	}
}
