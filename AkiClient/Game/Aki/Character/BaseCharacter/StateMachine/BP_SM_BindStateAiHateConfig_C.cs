using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Character.BaseCharacter.StateMachine
{
	// Token: 0x020042B1 RID: 17073
	[UnrealObjectPath("/Game/Aki/Character/BaseCharacter/StateMachine/BP_SM_BindStateAiHateConfig.BP_SM_BindStateAiHateConfig_C")]
	[UnrealStructLayout(56, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 52)]
	public class BP_SM_BindStateAiHateConfig_C : UASMBindState, IUnrealUObject, IUnrealObject
	{
		// Token: 0x0602D51D RID: 185629 RVA: 0x00ABCF0D File Offset: 0x00ABB10D
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_SM_BindStateAiHateConfig_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Character/BaseCharacter/StateMachine/BP_SM_BindStateAiHateConfig.BP_SM_BindStateAiHateConfig_C");
			}
			return BP_SM_BindStateAiHateConfig_C._ClassPtr;
		}

		// Token: 0x0602D51E RID: 185630 RVA: 0x00ABCF34 File Offset: 0x00ABB134
		public BP_SM_BindStateAiHateConfig_C() : this(BuiltinUtils.AllocNativeUObject(BP_SM_BindStateAiHateConfig_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x0602D51F RID: 185631 RVA: 0x00ABCF5C File Offset: 0x00ABB15C
		[NullableContext(1)]
		public BP_SM_BindStateAiHateConfig_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_SM_BindStateAiHateConfig_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x17007B8B RID: 31627
		// (get) Token: 0x0602D520 RID: 185632 RVA: 0x00ABCF8F File Offset: 0x00ABB18F
		// (set) Token: 0x0602D521 RID: 185633 RVA: 0x00ABCF9F File Offset: 0x00ABB19F
		public unsafe int ConfigId
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SM_BindStateAiHateConfig_C.__PropertyOffset_0);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_SM_BindStateAiHateConfig_C.__PropertyOffset_0) = value;
			}
		}

		// Token: 0x0602D522 RID: 185634 RVA: 0x00ABCFB0 File Offset: 0x00ABB1B0
		protected BP_SM_BindStateAiHateConfig_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x04019693 RID: 104083
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Character/BaseCharacter/StateMachine/BP_SM_BindStateAiHateConfig.BP_SM_BindStateAiHateConfig_C";

		// Token: 0x04019694 RID: 104084
		private static IntPtr _ClassPtr;

		// Token: 0x04019695 RID: 104085
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x04019696 RID: 104086
		internal static int __PropertyOffset_0;
	}
}
