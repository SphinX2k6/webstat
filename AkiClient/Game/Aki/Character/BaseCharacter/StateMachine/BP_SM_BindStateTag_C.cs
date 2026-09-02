using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Character.BaseCharacter.StateMachine
{
	// Token: 0x020042C1 RID: 17089
	[UnrealObjectPath("/Game/Aki/Character/BaseCharacter/StateMachine/BP_SM_BindStateTag.BP_SM_BindStateTag_C")]
	[UnrealStructLayout(64, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 60)]
	public class BP_SM_BindStateTag_C : UASMBindState, IUnrealUObject, IUnrealObject
	{
		// Token: 0x0602D5A5 RID: 185765 RVA: 0x00ABDD80 File Offset: 0x00ABBF80
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_SM_BindStateTag_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Character/BaseCharacter/StateMachine/BP_SM_BindStateTag.BP_SM_BindStateTag_C");
			}
			return BP_SM_BindStateTag_C._ClassPtr;
		}

		// Token: 0x0602D5A6 RID: 185766 RVA: 0x00ABDDA4 File Offset: 0x00ABBFA4
		public BP_SM_BindStateTag_C() : this(BuiltinUtils.AllocNativeUObject(BP_SM_BindStateTag_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x0602D5A7 RID: 185767 RVA: 0x00ABDDCC File Offset: 0x00ABBFCC
		[NullableContext(1)]
		public BP_SM_BindStateTag_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_SM_BindStateTag_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x17007BAF RID: 31663
		// (get) Token: 0x0602D5A8 RID: 185768 RVA: 0x00ABDDFF File Offset: 0x00ABBFFF
		// (set) Token: 0x0602D5A9 RID: 185769 RVA: 0x00ABDE13 File Offset: 0x00ABC013
		public unsafe FGameplayTag Tag
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SM_BindStateTag_C.__PropertyOffset_0);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_SM_BindStateTag_C.__PropertyOffset_0) = value;
			}
		}

		// Token: 0x0602D5AA RID: 185770 RVA: 0x00ABDE28 File Offset: 0x00ABC028
		protected BP_SM_BindStateTag_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x040196EC RID: 104172
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Character/BaseCharacter/StateMachine/BP_SM_BindStateTag.BP_SM_BindStateTag_C";

		// Token: 0x040196ED RID: 104173
		private static IntPtr _ClassPtr;

		// Token: 0x040196EE RID: 104174
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x040196EF RID: 104175
		internal static int __PropertyOffset_0;
	}
}
