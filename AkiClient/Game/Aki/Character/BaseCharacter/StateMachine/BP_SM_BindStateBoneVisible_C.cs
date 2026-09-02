using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Character.BaseCharacter.StateMachine
{
	// Token: 0x020042B4 RID: 17076
	[NullableContext(1)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Character/BaseCharacter/StateMachine/BP_SM_BindStateBoneVisible.BP_SM_BindStateBoneVisible_C")]
	[UnrealStructLayout(72, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 65)]
	public class BP_SM_BindStateBoneVisible_C : UASMBindState, IUnrealUObject, IUnrealObject
	{
		// Token: 0x0602D53F RID: 185663 RVA: 0x00ABD221 File Offset: 0x00ABB421
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_SM_BindStateBoneVisible_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Character/BaseCharacter/StateMachine/BP_SM_BindStateBoneVisible.BP_SM_BindStateBoneVisible_C");
			}
			return BP_SM_BindStateBoneVisible_C._ClassPtr;
		}

		// Token: 0x0602D540 RID: 185664 RVA: 0x00ABD248 File Offset: 0x00ABB448
		public BP_SM_BindStateBoneVisible_C() : this(BuiltinUtils.AllocNativeUObject(BP_SM_BindStateBoneVisible_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x0602D541 RID: 185665 RVA: 0x00ABD270 File Offset: 0x00ABB470
		public BP_SM_BindStateBoneVisible_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_SM_BindStateBoneVisible_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x17007B96 RID: 31638
		// (get) Token: 0x0602D542 RID: 185666 RVA: 0x00ABD2A3 File Offset: 0x00ABB4A3
		// (set) Token: 0x0602D543 RID: 185667 RVA: 0x00ABD2B7 File Offset: 0x00ABB4B7
		public unsafe string 骨骼名
		{
			get
			{
				return FString.ToString((void*)(base.NativePtr + (byte*)((IntPtr)BP_SM_BindStateBoneVisible_C.__PropertyOffset_0)));
			}
			set
			{
				FString.CopyFrom((void*)(base.NativePtr + (byte*)((IntPtr)BP_SM_BindStateBoneVisible_C.__PropertyOffset_0)), value);
			}
		}

		// Token: 0x17007B97 RID: 31639
		// (get) Token: 0x0602D544 RID: 185668 RVA: 0x00ABD2CC File Offset: 0x00ABB4CC
		// (set) Token: 0x0602D545 RID: 185669 RVA: 0x00ABD2DC File Offset: 0x00ABB4DC
		public unsafe bool 显示
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SM_BindStateBoneVisible_C.__PropertyOffset_1) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_SM_BindStateBoneVisible_C.__PropertyOffset_1) = (value ? 1 : 0);
			}
		}

		// Token: 0x0602D546 RID: 185670 RVA: 0x00ABD2ED File Offset: 0x00ABB4ED
		protected BP_SM_BindStateBoneVisible_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x040196A7 RID: 104103
		public new const string __ObjectPath = "/Game/Aki/Character/BaseCharacter/StateMachine/BP_SM_BindStateBoneVisible.BP_SM_BindStateBoneVisible_C";

		// Token: 0x040196A8 RID: 104104
		private static IntPtr _ClassPtr;

		// Token: 0x040196A9 RID: 104105
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x040196AA RID: 104106
		internal static int __PropertyOffset_0;

		// Token: 0x040196AB RID: 104107
		internal static int __PropertyOffset_1;
	}
}
