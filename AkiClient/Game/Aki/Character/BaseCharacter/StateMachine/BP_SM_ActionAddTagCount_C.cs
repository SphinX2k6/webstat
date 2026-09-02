using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Character.BaseCharacter.StateMachine
{
	// Token: 0x020042A2 RID: 17058
	[UnrealObjectPath("/Game/Aki/Character/BaseCharacter/StateMachine/BP_SM_ActionAddTagCount.BP_SM_ActionAddTagCount_C")]
	[UnrealStructLayout(64, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 64)]
	public class BP_SM_ActionAddTagCount_C : UASMAction, IUnrealUObject, IUnrealObject
	{
		// Token: 0x0602D4C3 RID: 185539 RVA: 0x00ABC4AD File Offset: 0x00ABA6AD
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_SM_ActionAddTagCount_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Character/BaseCharacter/StateMachine/BP_SM_ActionAddTagCount.BP_SM_ActionAddTagCount_C");
			}
			return BP_SM_ActionAddTagCount_C._ClassPtr;
		}

		// Token: 0x0602D4C4 RID: 185540 RVA: 0x00ABC4D4 File Offset: 0x00ABA6D4
		public BP_SM_ActionAddTagCount_C() : this(BuiltinUtils.AllocNativeUObject(BP_SM_ActionAddTagCount_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x0602D4C5 RID: 185541 RVA: 0x00ABC4FC File Offset: 0x00ABA6FC
		[NullableContext(1)]
		public BP_SM_ActionAddTagCount_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_SM_ActionAddTagCount_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x17007B7C RID: 31612
		// (get) Token: 0x0602D4C6 RID: 185542 RVA: 0x00ABC52F File Offset: 0x00ABA72F
		// (set) Token: 0x0602D4C7 RID: 185543 RVA: 0x00ABC543 File Offset: 0x00ABA743
		public unsafe FGameplayTag Tag
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SM_ActionAddTagCount_C.__PropertyOffset_0);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_SM_ActionAddTagCount_C.__PropertyOffset_0) = value;
			}
		}

		// Token: 0x17007B7D RID: 31613
		// (get) Token: 0x0602D4C8 RID: 185544 RVA: 0x00ABC558 File Offset: 0x00ABA758
		// (set) Token: 0x0602D4C9 RID: 185545 RVA: 0x00ABC568 File Offset: 0x00ABA768
		public unsafe int Count
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SM_ActionAddTagCount_C.__PropertyOffset_1);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_SM_ActionAddTagCount_C.__PropertyOffset_1) = value;
			}
		}

		// Token: 0x0602D4CA RID: 185546 RVA: 0x00ABC579 File Offset: 0x00ABA779
		protected BP_SM_ActionAddTagCount_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x04019656 RID: 104022
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Character/BaseCharacter/StateMachine/BP_SM_ActionAddTagCount.BP_SM_ActionAddTagCount_C";

		// Token: 0x04019657 RID: 104023
		private static IntPtr _ClassPtr;

		// Token: 0x04019658 RID: 104024
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x04019659 RID: 104025
		internal static int __PropertyOffset_0;

		// Token: 0x0401965A RID: 104026
		internal static int __PropertyOffset_1;
	}
}
