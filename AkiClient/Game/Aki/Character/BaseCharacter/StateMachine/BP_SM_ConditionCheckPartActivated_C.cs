using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Character.BaseCharacter.StateMachine
{
	// Token: 0x020042CA RID: 17098
	[NullableContext(1)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Character/BaseCharacter/StateMachine/BP_SM_ConditionCheckPartActivated.BP_SM_ConditionCheckPartActivated_C")]
	[UnrealStructLayout(72, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 72)]
	public class BP_SM_ConditionCheckPartActivated_C : UASMConditionBase, IUnrealUObject, IUnrealObject
	{
		// Token: 0x0602D5E3 RID: 185827 RVA: 0x00ABE42D File Offset: 0x00ABC62D
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_SM_ConditionCheckPartActivated_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Character/BaseCharacter/StateMachine/BP_SM_ConditionCheckPartActivated.BP_SM_ConditionCheckPartActivated_C");
			}
			return BP_SM_ConditionCheckPartActivated_C._ClassPtr;
		}

		// Token: 0x0602D5E4 RID: 185828 RVA: 0x00ABE454 File Offset: 0x00ABC654
		public BP_SM_ConditionCheckPartActivated_C() : this(BuiltinUtils.AllocNativeUObject(BP_SM_ConditionCheckPartActivated_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x0602D5E5 RID: 185829 RVA: 0x00ABE47C File Offset: 0x00ABC67C
		public BP_SM_ConditionCheckPartActivated_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_SM_ConditionCheckPartActivated_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x17007BBC RID: 31676
		// (get) Token: 0x0602D5E6 RID: 185830 RVA: 0x00ABE4AF File Offset: 0x00ABC6AF
		// (set) Token: 0x0602D5E7 RID: 185831 RVA: 0x00ABE4C3 File Offset: 0x00ABC6C3
		public unsafe string 部位名
		{
			get
			{
				return FString.ToString((void*)(base.NativePtr + (byte*)((IntPtr)BP_SM_ConditionCheckPartActivated_C.__PropertyOffset_0)));
			}
			set
			{
				FString.CopyFrom((void*)(base.NativePtr + (byte*)((IntPtr)BP_SM_ConditionCheckPartActivated_C.__PropertyOffset_0)), value);
			}
		}

		// Token: 0x0602D5E8 RID: 185832 RVA: 0x00ABE4D8 File Offset: 0x00ABC6D8
		protected BP_SM_ConditionCheckPartActivated_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x04019714 RID: 104212
		public new const string __ObjectPath = "/Game/Aki/Character/BaseCharacter/StateMachine/BP_SM_ConditionCheckPartActivated.BP_SM_ConditionCheckPartActivated_C";

		// Token: 0x04019715 RID: 104213
		private static IntPtr _ClassPtr;

		// Token: 0x04019716 RID: 104214
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x04019717 RID: 104215
		internal static int __PropertyOffset_0;
	}
}
