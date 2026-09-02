using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Character.BaseCharacter.StateMachine
{
	// Token: 0x020042BA RID: 17082
	[UnrealObjectPath("/Game/Aki/Character/BaseCharacter/StateMachine/BP_SM_BindStateDelaySuicide.BP_SM_BindStateDelaySuicide_C")]
	[UnrealStructLayout(56, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 56)]
	public class BP_SM_BindStateDelaySuicide_C : UASMBindState, IUnrealUObject, IUnrealObject
	{
		// Token: 0x0602D56D RID: 185709 RVA: 0x00ABD782 File Offset: 0x00ABB982
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_SM_BindStateDelaySuicide_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Character/BaseCharacter/StateMachine/BP_SM_BindStateDelaySuicide.BP_SM_BindStateDelaySuicide_C");
			}
			return BP_SM_BindStateDelaySuicide_C._ClassPtr;
		}

		// Token: 0x0602D56E RID: 185710 RVA: 0x00ABD7A8 File Offset: 0x00ABB9A8
		public BP_SM_BindStateDelaySuicide_C() : this(BuiltinUtils.AllocNativeUObject(BP_SM_BindStateDelaySuicide_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x0602D56F RID: 185711 RVA: 0x00ABD7D0 File Offset: 0x00ABB9D0
		[NullableContext(1)]
		public BP_SM_BindStateDelaySuicide_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_SM_BindStateDelaySuicide_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x17007BA1 RID: 31649
		// (get) Token: 0x0602D570 RID: 185712 RVA: 0x00ABD803 File Offset: 0x00ABBA03
		// (set) Token: 0x0602D571 RID: 185713 RVA: 0x00ABD813 File Offset: 0x00ABBA13
		public unsafe int SuicideDelay
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SM_BindStateDelaySuicide_C.__PropertyOffset_0);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_SM_BindStateDelaySuicide_C.__PropertyOffset_0) = value;
			}
		}

		// Token: 0x17007BA2 RID: 31650
		// (get) Token: 0x0602D572 RID: 185714 RVA: 0x00ABD824 File Offset: 0x00ABBA24
		// (set) Token: 0x0602D573 RID: 185715 RVA: 0x00ABD834 File Offset: 0x00ABBA34
		public unsafe int DestroyDelay
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SM_BindStateDelaySuicide_C.__PropertyOffset_1);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_SM_BindStateDelaySuicide_C.__PropertyOffset_1) = value;
			}
		}

		// Token: 0x0602D574 RID: 185716 RVA: 0x00ABD845 File Offset: 0x00ABBA45
		protected BP_SM_BindStateDelaySuicide_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x040196C8 RID: 104136
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Character/BaseCharacter/StateMachine/BP_SM_BindStateDelaySuicide.BP_SM_BindStateDelaySuicide_C";

		// Token: 0x040196C9 RID: 104137
		private static IntPtr _ClassPtr;

		// Token: 0x040196CA RID: 104138
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x040196CB RID: 104139
		internal static int __PropertyOffset_0;

		// Token: 0x040196CC RID: 104140
		internal static int __PropertyOffset_1;
	}
}
