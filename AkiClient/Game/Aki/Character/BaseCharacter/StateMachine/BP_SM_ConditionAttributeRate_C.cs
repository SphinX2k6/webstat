using System;
using System.Runtime.CompilerServices;
using AkiClient.Game.Aki.Protocol;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Character.BaseCharacter.StateMachine
{
	// Token: 0x020042C2 RID: 17090
	[UnrealObjectPath("/Game/Aki/Character/BaseCharacter/StateMachine/BP_SM_ConditionAttributeRate.BP_SM_ConditionAttributeRate_C")]
	[UnrealStructLayout(72, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 68)]
	public class BP_SM_ConditionAttributeRate_C : UASMConditionBase, IUnrealUObject, IUnrealObject
	{
		// Token: 0x0602D5AB RID: 185771 RVA: 0x00ABDE31 File Offset: 0x00ABC031
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_SM_ConditionAttributeRate_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Character/BaseCharacter/StateMachine/BP_SM_ConditionAttributeRate.BP_SM_ConditionAttributeRate_C");
			}
			return BP_SM_ConditionAttributeRate_C._ClassPtr;
		}

		// Token: 0x0602D5AC RID: 185772 RVA: 0x00ABDE58 File Offset: 0x00ABC058
		public BP_SM_ConditionAttributeRate_C() : this(BuiltinUtils.AllocNativeUObject(BP_SM_ConditionAttributeRate_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x0602D5AD RID: 185773 RVA: 0x00ABDE80 File Offset: 0x00ABC080
		[NullableContext(1)]
		public BP_SM_ConditionAttributeRate_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_SM_ConditionAttributeRate_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x17007BB0 RID: 31664
		// (get) Token: 0x0602D5AE RID: 185774 RVA: 0x00ABDEB3 File Offset: 0x00ABC0B3
		// (set) Token: 0x0602D5AF RID: 185775 RVA: 0x00ABDEC7 File Offset: 0x00ABC0C7
		public unsafe TEnumAsByte<EAttributeType> 分子
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SM_ConditionAttributeRate_C.__PropertyOffset_0);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_SM_ConditionAttributeRate_C.__PropertyOffset_0) = value;
			}
		}

		// Token: 0x17007BB1 RID: 31665
		// (get) Token: 0x0602D5B0 RID: 185776 RVA: 0x00ABDEDC File Offset: 0x00ABC0DC
		// (set) Token: 0x0602D5B1 RID: 185777 RVA: 0x00ABDEF0 File Offset: 0x00ABC0F0
		public unsafe TEnumAsByte<EAttributeType> 分母
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SM_ConditionAttributeRate_C.__PropertyOffset_1);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_SM_ConditionAttributeRate_C.__PropertyOffset_1) = value;
			}
		}

		// Token: 0x17007BB2 RID: 31666
		// (get) Token: 0x0602D5B2 RID: 185778 RVA: 0x00ABDF05 File Offset: 0x00ABC105
		// (set) Token: 0x0602D5B3 RID: 185779 RVA: 0x00ABDF15 File Offset: 0x00ABC115
		public unsafe int Min
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SM_ConditionAttributeRate_C.__PropertyOffset_2);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_SM_ConditionAttributeRate_C.__PropertyOffset_2) = value;
			}
		}

		// Token: 0x17007BB3 RID: 31667
		// (get) Token: 0x0602D5B4 RID: 185780 RVA: 0x00ABDF26 File Offset: 0x00ABC126
		// (set) Token: 0x0602D5B5 RID: 185781 RVA: 0x00ABDF36 File Offset: 0x00ABC136
		public unsafe int Max
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SM_ConditionAttributeRate_C.__PropertyOffset_3);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_SM_ConditionAttributeRate_C.__PropertyOffset_3) = value;
			}
		}

		// Token: 0x0602D5B6 RID: 185782 RVA: 0x00ABDF47 File Offset: 0x00ABC147
		protected BP_SM_ConditionAttributeRate_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x040196F0 RID: 104176
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Character/BaseCharacter/StateMachine/BP_SM_ConditionAttributeRate.BP_SM_ConditionAttributeRate_C";

		// Token: 0x040196F1 RID: 104177
		private static IntPtr _ClassPtr;

		// Token: 0x040196F2 RID: 104178
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x040196F3 RID: 104179
		internal static int __PropertyOffset_0;

		// Token: 0x040196F4 RID: 104180
		internal static int __PropertyOffset_1;

		// Token: 0x040196F5 RID: 104181
		internal static int __PropertyOffset_2;

		// Token: 0x040196F6 RID: 104182
		internal static int __PropertyOffset_3;
	}
}
