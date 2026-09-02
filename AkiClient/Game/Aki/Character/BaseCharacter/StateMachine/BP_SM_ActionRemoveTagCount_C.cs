using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Character.BaseCharacter.StateMachine
{
	// Token: 0x020042AB RID: 17067
	[UnrealObjectPath("/Game/Aki/Character/BaseCharacter/StateMachine/BP_SM_ActionRemoveTagCount.BP_SM_ActionRemoveTagCount_C")]
	[UnrealStructLayout(64, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 64)]
	public class BP_SM_ActionRemoveTagCount_C : UASMAction, IUnrealUObject, IUnrealObject
	{
		// Token: 0x0602D4F7 RID: 185591 RVA: 0x00ABCAD5 File Offset: 0x00ABACD5
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_SM_ActionRemoveTagCount_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Character/BaseCharacter/StateMachine/BP_SM_ActionRemoveTagCount.BP_SM_ActionRemoveTagCount_C");
			}
			return BP_SM_ActionRemoveTagCount_C._ClassPtr;
		}

		// Token: 0x0602D4F8 RID: 185592 RVA: 0x00ABCAFC File Offset: 0x00ABACFC
		public BP_SM_ActionRemoveTagCount_C() : this(BuiltinUtils.AllocNativeUObject(BP_SM_ActionRemoveTagCount_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x0602D4F9 RID: 185593 RVA: 0x00ABCB24 File Offset: 0x00ABAD24
		[NullableContext(1)]
		public BP_SM_ActionRemoveTagCount_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_SM_ActionRemoveTagCount_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x17007B84 RID: 31620
		// (get) Token: 0x0602D4FA RID: 185594 RVA: 0x00ABCB57 File Offset: 0x00ABAD57
		// (set) Token: 0x0602D4FB RID: 185595 RVA: 0x00ABCB6B File Offset: 0x00ABAD6B
		public unsafe FGameplayTag Tag
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SM_ActionRemoveTagCount_C.__PropertyOffset_0);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_SM_ActionRemoveTagCount_C.__PropertyOffset_0) = value;
			}
		}

		// Token: 0x17007B85 RID: 31621
		// (get) Token: 0x0602D4FC RID: 185596 RVA: 0x00ABCB80 File Offset: 0x00ABAD80
		// (set) Token: 0x0602D4FD RID: 185597 RVA: 0x00ABCB90 File Offset: 0x00ABAD90
		public unsafe int Count
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SM_ActionRemoveTagCount_C.__PropertyOffset_1);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_SM_ActionRemoveTagCount_C.__PropertyOffset_1) = value;
			}
		}

		// Token: 0x0602D4FE RID: 185598 RVA: 0x00ABCBA1 File Offset: 0x00ABADA1
		protected BP_SM_ActionRemoveTagCount_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x0401967A RID: 104058
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Character/BaseCharacter/StateMachine/BP_SM_ActionRemoveTagCount.BP_SM_ActionRemoveTagCount_C";

		// Token: 0x0401967B RID: 104059
		private static IntPtr _ClassPtr;

		// Token: 0x0401967C RID: 104060
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x0401967D RID: 104061
		internal static int __PropertyOffset_0;

		// Token: 0x0401967E RID: 104062
		internal static int __PropertyOffset_1;
	}
}
