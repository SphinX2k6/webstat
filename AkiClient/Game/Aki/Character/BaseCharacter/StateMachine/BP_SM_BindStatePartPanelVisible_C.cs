using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Character.BaseCharacter.StateMachine
{
	// Token: 0x020042BF RID: 17087
	[NullableContext(1)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Character/BaseCharacter/StateMachine/BP_SM_BindStatePartPanelVisible.BP_SM_BindStatePartPanelVisible_C")]
	[UnrealStructLayout(72, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 65)]
	public class BP_SM_BindStatePartPanelVisible_C : UASMBindState, IUnrealUObject, IUnrealObject
	{
		// Token: 0x0602D58F RID: 185743 RVA: 0x00ABDB50 File Offset: 0x00ABBD50
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_SM_BindStatePartPanelVisible_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Character/BaseCharacter/StateMachine/BP_SM_BindStatePartPanelVisible.BP_SM_BindStatePartPanelVisible_C");
			}
			return BP_SM_BindStatePartPanelVisible_C._ClassPtr;
		}

		// Token: 0x0602D590 RID: 185744 RVA: 0x00ABDB74 File Offset: 0x00ABBD74
		public BP_SM_BindStatePartPanelVisible_C() : this(BuiltinUtils.AllocNativeUObject(BP_SM_BindStatePartPanelVisible_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x0602D591 RID: 185745 RVA: 0x00ABDB9C File Offset: 0x00ABBD9C
		public BP_SM_BindStatePartPanelVisible_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_SM_BindStatePartPanelVisible_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x17007BA8 RID: 31656
		// (get) Token: 0x0602D592 RID: 185746 RVA: 0x00ABDBCF File Offset: 0x00ABBDCF
		// (set) Token: 0x0602D593 RID: 185747 RVA: 0x00ABDBE3 File Offset: 0x00ABBDE3
		public unsafe string 部位名
		{
			get
			{
				return FString.ToString((void*)(base.NativePtr + (byte*)((IntPtr)BP_SM_BindStatePartPanelVisible_C.__PropertyOffset_0)));
			}
			set
			{
				FString.CopyFrom((void*)(base.NativePtr + (byte*)((IntPtr)BP_SM_BindStatePartPanelVisible_C.__PropertyOffset_0)), value);
			}
		}

		// Token: 0x17007BA9 RID: 31657
		// (get) Token: 0x0602D594 RID: 185748 RVA: 0x00ABDBF8 File Offset: 0x00ABBDF8
		// (set) Token: 0x0602D595 RID: 185749 RVA: 0x00ABDC08 File Offset: 0x00ABBE08
		public unsafe bool 状态条显示
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SM_BindStatePartPanelVisible_C.__PropertyOffset_1) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_SM_BindStatePartPanelVisible_C.__PropertyOffset_1) = (value ? 1 : 0);
			}
		}

		// Token: 0x0602D596 RID: 185750 RVA: 0x00ABDC19 File Offset: 0x00ABBE19
		protected BP_SM_BindStatePartPanelVisible_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x040196DE RID: 104158
		public new const string __ObjectPath = "/Game/Aki/Character/BaseCharacter/StateMachine/BP_SM_BindStatePartPanelVisible.BP_SM_BindStatePartPanelVisible_C";

		// Token: 0x040196DF RID: 104159
		private static IntPtr _ClassPtr;

		// Token: 0x040196E0 RID: 104160
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x040196E1 RID: 104161
		internal static int __PropertyOffset_0;

		// Token: 0x040196E2 RID: 104162
		internal static int __PropertyOffset_1;
	}
}
