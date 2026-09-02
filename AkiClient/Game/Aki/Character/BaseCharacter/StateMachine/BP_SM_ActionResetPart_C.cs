using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Character.BaseCharacter.StateMachine
{
	// Token: 0x020042AC RID: 17068
	[NullableContext(1)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Character/BaseCharacter/StateMachine/BP_SM_ActionResetPart.BP_SM_ActionResetPart_C")]
	[UnrealStructLayout(72, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 66)]
	public class BP_SM_ActionResetPart_C : UASMAction, IUnrealUObject, IUnrealObject
	{
		// Token: 0x0602D4FF RID: 185599 RVA: 0x00ABCBAA File Offset: 0x00ABADAA
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_SM_ActionResetPart_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Character/BaseCharacter/StateMachine/BP_SM_ActionResetPart.BP_SM_ActionResetPart_C");
			}
			return BP_SM_ActionResetPart_C._ClassPtr;
		}

		// Token: 0x0602D500 RID: 185600 RVA: 0x00ABCBD0 File Offset: 0x00ABADD0
		public BP_SM_ActionResetPart_C() : this(BuiltinUtils.AllocNativeUObject(BP_SM_ActionResetPart_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x0602D501 RID: 185601 RVA: 0x00ABCBF8 File Offset: 0x00ABADF8
		public BP_SM_ActionResetPart_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_SM_ActionResetPart_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x17007B86 RID: 31622
		// (get) Token: 0x0602D502 RID: 185602 RVA: 0x00ABCC2B File Offset: 0x00ABAE2B
		// (set) Token: 0x0602D503 RID: 185603 RVA: 0x00ABCC3F File Offset: 0x00ABAE3F
		public unsafe string 部位名
		{
			get
			{
				return FString.ToString((void*)(base.NativePtr + (byte*)((IntPtr)BP_SM_ActionResetPart_C.__PropertyOffset_0)));
			}
			set
			{
				FString.CopyFrom((void*)(base.NativePtr + (byte*)((IntPtr)BP_SM_ActionResetPart_C.__PropertyOffset_0)), value);
			}
		}

		// Token: 0x17007B87 RID: 31623
		// (get) Token: 0x0602D504 RID: 185604 RVA: 0x00ABCC54 File Offset: 0x00ABAE54
		// (set) Token: 0x0602D505 RID: 185605 RVA: 0x00ABCC64 File Offset: 0x00ABAE64
		public unsafe bool 重置激活
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SM_ActionResetPart_C.__PropertyOffset_1) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_SM_ActionResetPart_C.__PropertyOffset_1) = (value ? 1 : 0);
			}
		}

		// Token: 0x17007B88 RID: 31624
		// (get) Token: 0x0602D506 RID: 185606 RVA: 0x00ABCC75 File Offset: 0x00ABAE75
		// (set) Token: 0x0602D507 RID: 185607 RVA: 0x00ABCC85 File Offset: 0x00ABAE85
		public unsafe bool 重置血量
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SM_ActionResetPart_C.__PropertyOffset_2) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_SM_ActionResetPart_C.__PropertyOffset_2) = (value ? 1 : 0);
			}
		}

		// Token: 0x0602D508 RID: 185608 RVA: 0x00ABCC96 File Offset: 0x00ABAE96
		protected BP_SM_ActionResetPart_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x0401967F RID: 104063
		public new const string __ObjectPath = "/Game/Aki/Character/BaseCharacter/StateMachine/BP_SM_ActionResetPart.BP_SM_ActionResetPart_C";

		// Token: 0x04019680 RID: 104064
		private static IntPtr _ClassPtr;

		// Token: 0x04019681 RID: 104065
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x04019682 RID: 104066
		internal static int __PropertyOffset_0;

		// Token: 0x04019683 RID: 104067
		internal static int __PropertyOffset_1;

		// Token: 0x04019684 RID: 104068
		internal static int __PropertyOffset_2;
	}
}
