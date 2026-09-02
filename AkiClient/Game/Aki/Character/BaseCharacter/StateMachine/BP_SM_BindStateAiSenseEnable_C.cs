using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Character.BaseCharacter.StateMachine
{
	// Token: 0x020042B2 RID: 17074
	[UnrealObjectPath("/Game/Aki/Character/BaseCharacter/StateMachine/BP_SM_BindStateAiSenseEnable.BP_SM_BindStateAiSenseEnable_C")]
	[UnrealStructLayout(56, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 52)]
	public class BP_SM_BindStateAiSenseEnable_C : UASMBindState, IUnrealUObject, IUnrealObject
	{
		// Token: 0x0602D523 RID: 185635 RVA: 0x00ABCFB9 File Offset: 0x00ABB1B9
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_SM_BindStateAiSenseEnable_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Character/BaseCharacter/StateMachine/BP_SM_BindStateAiSenseEnable.BP_SM_BindStateAiSenseEnable_C");
			}
			return BP_SM_BindStateAiSenseEnable_C._ClassPtr;
		}

		// Token: 0x0602D524 RID: 185636 RVA: 0x00ABCFE0 File Offset: 0x00ABB1E0
		public BP_SM_BindStateAiSenseEnable_C() : this(BuiltinUtils.AllocNativeUObject(BP_SM_BindStateAiSenseEnable_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x0602D525 RID: 185637 RVA: 0x00ABD008 File Offset: 0x00ABB208
		[NullableContext(1)]
		public BP_SM_BindStateAiSenseEnable_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_SM_BindStateAiSenseEnable_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x17007B8C RID: 31628
		// (get) Token: 0x0602D526 RID: 185638 RVA: 0x00ABD03B File Offset: 0x00ABB23B
		// (set) Token: 0x0602D527 RID: 185639 RVA: 0x00ABD04B File Offset: 0x00ABB24B
		public unsafe int ConfigId
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SM_BindStateAiSenseEnable_C.__PropertyOffset_0);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_SM_BindStateAiSenseEnable_C.__PropertyOffset_0) = value;
			}
		}

		// Token: 0x0602D528 RID: 185640 RVA: 0x00ABD05C File Offset: 0x00ABB25C
		protected BP_SM_BindStateAiSenseEnable_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x04019697 RID: 104087
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Character/BaseCharacter/StateMachine/BP_SM_BindStateAiSenseEnable.BP_SM_BindStateAiSenseEnable_C";

		// Token: 0x04019698 RID: 104088
		private static IntPtr _ClassPtr;

		// Token: 0x04019699 RID: 104089
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x0401969A RID: 104090
		internal static int __PropertyOffset_0;
	}
}
