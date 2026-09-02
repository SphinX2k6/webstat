using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Character.BaseCharacter.StateMachine
{
	// Token: 0x0200429F RID: 17055
	[NullableContext(1)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Character/BaseCharacter/StateMachine/BP_SM_ActionActivatePart.BP_SM_ActionActivatePart_C")]
	[UnrealStructLayout(72, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 65)]
	public class BP_SM_ActionActivatePart_C : UASMAction, IUnrealUObject, IUnrealObject
	{
		// Token: 0x0602D4AD RID: 185517 RVA: 0x00ABC264 File Offset: 0x00ABA464
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_SM_ActionActivatePart_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Character/BaseCharacter/StateMachine/BP_SM_ActionActivatePart.BP_SM_ActionActivatePart_C");
			}
			return BP_SM_ActionActivatePart_C._ClassPtr;
		}

		// Token: 0x0602D4AE RID: 185518 RVA: 0x00ABC288 File Offset: 0x00ABA488
		public BP_SM_ActionActivatePart_C() : this(BuiltinUtils.AllocNativeUObject(BP_SM_ActionActivatePart_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x0602D4AF RID: 185519 RVA: 0x00ABC2B0 File Offset: 0x00ABA4B0
		public BP_SM_ActionActivatePart_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_SM_ActionActivatePart_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x17007B77 RID: 31607
		// (get) Token: 0x0602D4B0 RID: 185520 RVA: 0x00ABC2E3 File Offset: 0x00ABA4E3
		// (set) Token: 0x0602D4B1 RID: 185521 RVA: 0x00ABC2F7 File Offset: 0x00ABA4F7
		public unsafe string 部位名
		{
			get
			{
				return FString.ToString((void*)(base.NativePtr + (byte*)((IntPtr)BP_SM_ActionActivatePart_C.__PropertyOffset_0)));
			}
			set
			{
				FString.CopyFrom((void*)(base.NativePtr + (byte*)((IntPtr)BP_SM_ActionActivatePart_C.__PropertyOffset_0)), value);
			}
		}

		// Token: 0x17007B78 RID: 31608
		// (get) Token: 0x0602D4B2 RID: 185522 RVA: 0x00ABC30C File Offset: 0x00ABA50C
		// (set) Token: 0x0602D4B3 RID: 185523 RVA: 0x00ABC31C File Offset: 0x00ABA51C
		public unsafe bool 激活
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SM_ActionActivatePart_C.__PropertyOffset_1) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_SM_ActionActivatePart_C.__PropertyOffset_1) = (value ? 1 : 0);
			}
		}

		// Token: 0x0602D4B4 RID: 185524 RVA: 0x00ABC32D File Offset: 0x00ABA52D
		protected BP_SM_ActionActivatePart_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x04019648 RID: 104008
		public new const string __ObjectPath = "/Game/Aki/Character/BaseCharacter/StateMachine/BP_SM_ActionActivatePart.BP_SM_ActionActivatePart_C";

		// Token: 0x04019649 RID: 104009
		private static IntPtr _ClassPtr;

		// Token: 0x0401964A RID: 104010
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x0401964B RID: 104011
		internal static int __PropertyOffset_0;

		// Token: 0x0401964C RID: 104012
		internal static int __PropertyOffset_1;
	}
}
