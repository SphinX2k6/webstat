using System;
using System.Runtime.CompilerServices;
using AkiClient.Game.Aki.Protocol;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Character.BaseCharacter.StateMachine
{
	// Token: 0x020042C3 RID: 17091
	[UnrealObjectPath("/Game/Aki/Character/BaseCharacter/StateMachine/BP_SM_ConditionAttribute.BP_SM_ConditionAttribute_C")]
	[UnrealStructLayout(72, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 68)]
	public class BP_SM_ConditionAttribute_C : UASMConditionBase, IUnrealUObject, IUnrealObject
	{
		// Token: 0x0602D5B7 RID: 185783 RVA: 0x00ABDF50 File Offset: 0x00ABC150
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_SM_ConditionAttribute_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Character/BaseCharacter/StateMachine/BP_SM_ConditionAttribute.BP_SM_ConditionAttribute_C");
			}
			return BP_SM_ConditionAttribute_C._ClassPtr;
		}

		// Token: 0x0602D5B8 RID: 185784 RVA: 0x00ABDF74 File Offset: 0x00ABC174
		public BP_SM_ConditionAttribute_C() : this(BuiltinUtils.AllocNativeUObject(BP_SM_ConditionAttribute_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x0602D5B9 RID: 185785 RVA: 0x00ABDF9C File Offset: 0x00ABC19C
		[NullableContext(1)]
		public BP_SM_ConditionAttribute_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_SM_ConditionAttribute_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x17007BB4 RID: 31668
		// (get) Token: 0x0602D5BA RID: 185786 RVA: 0x00ABDFCF File Offset: 0x00ABC1CF
		// (set) Token: 0x0602D5BB RID: 185787 RVA: 0x00ABDFE3 File Offset: 0x00ABC1E3
		public unsafe TEnumAsByte<EAttributeType> 属性类型
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SM_ConditionAttribute_C.__PropertyOffset_0);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_SM_ConditionAttribute_C.__PropertyOffset_0) = value;
			}
		}

		// Token: 0x17007BB5 RID: 31669
		// (get) Token: 0x0602D5BC RID: 185788 RVA: 0x00ABDFF8 File Offset: 0x00ABC1F8
		// (set) Token: 0x0602D5BD RID: 185789 RVA: 0x00ABE008 File Offset: 0x00ABC208
		public unsafe int Min
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SM_ConditionAttribute_C.__PropertyOffset_1);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_SM_ConditionAttribute_C.__PropertyOffset_1) = value;
			}
		}

		// Token: 0x17007BB6 RID: 31670
		// (get) Token: 0x0602D5BE RID: 185790 RVA: 0x00ABE019 File Offset: 0x00ABC219
		// (set) Token: 0x0602D5BF RID: 185791 RVA: 0x00ABE029 File Offset: 0x00ABC229
		public unsafe int Max
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SM_ConditionAttribute_C.__PropertyOffset_2);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_SM_ConditionAttribute_C.__PropertyOffset_2) = value;
			}
		}

		// Token: 0x0602D5C0 RID: 185792 RVA: 0x00ABE03A File Offset: 0x00ABC23A
		protected BP_SM_ConditionAttribute_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x040196F7 RID: 104183
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Character/BaseCharacter/StateMachine/BP_SM_ConditionAttribute.BP_SM_ConditionAttribute_C";

		// Token: 0x040196F8 RID: 104184
		private static IntPtr _ClassPtr;

		// Token: 0x040196F9 RID: 104185
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x040196FA RID: 104186
		internal static int __PropertyOffset_0;

		// Token: 0x040196FB RID: 104187
		internal static int __PropertyOffset_1;

		// Token: 0x040196FC RID: 104188
		internal static int __PropertyOffset_2;
	}
}
