using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Character.BaseCharacter.StateMachine
{
	// Token: 0x020042DD RID: 17117
	[NullableContext(1)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Character/BaseCharacter/StateMachine/BP_SM_TaskMontage.BP_SM_TaskMontage_C")]
	[UnrealStructLayout(88, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 88)]
	public class BP_SM_TaskMontage_C : UASMTask, IUnrealUObject, IUnrealObject
	{
		// Token: 0x0602D672 RID: 185970 RVA: 0x00ABF3AF File Offset: 0x00ABD5AF
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_SM_TaskMontage_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Character/BaseCharacter/StateMachine/BP_SM_TaskMontage.BP_SM_TaskMontage_C");
			}
			return BP_SM_TaskMontage_C._ClassPtr;
		}

		// Token: 0x0602D673 RID: 185971 RVA: 0x00ABF3D4 File Offset: 0x00ABD5D4
		public BP_SM_TaskMontage_C() : this(BuiltinUtils.AllocNativeUObject(BP_SM_TaskMontage_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x0602D674 RID: 185972 RVA: 0x00ABF3FC File Offset: 0x00ABD5FC
		public BP_SM_TaskMontage_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_SM_TaskMontage_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x17007BDC RID: 31708
		// (get) Token: 0x0602D675 RID: 185973 RVA: 0x00ABF42F File Offset: 0x00ABD62F
		// (set) Token: 0x0602D676 RID: 185974 RVA: 0x00ABF443 File Offset: 0x00ABD643
		public unsafe string MontageName
		{
			get
			{
				return FString.ToString((void*)(base.NativePtr + (byte*)((IntPtr)BP_SM_TaskMontage_C.__PropertyOffset_0)));
			}
			set
			{
				FString.CopyFrom((void*)(base.NativePtr + (byte*)((IntPtr)BP_SM_TaskMontage_C.__PropertyOffset_0)), value);
			}
		}

		// Token: 0x17007BDD RID: 31709
		// (get) Token: 0x0602D677 RID: 185975 RVA: 0x00ABF458 File Offset: 0x00ABD658
		// (set) Token: 0x0602D678 RID: 185976 RVA: 0x00ABF468 File Offset: 0x00ABD668
		public unsafe bool 加载期间隐藏模型
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SM_TaskMontage_C.__PropertyOffset_1) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_SM_TaskMontage_C.__PropertyOffset_1) = (value ? 1 : 0);
			}
		}

		// Token: 0x17007BDE RID: 31710
		// (get) Token: 0x0602D679 RID: 185977 RVA: 0x00ABF479 File Offset: 0x00ABD679
		// (set) Token: 0x0602D67A RID: 185978 RVA: 0x00ABF489 File Offset: 0x00ABD689
		public unsafe bool 允许打断
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SM_TaskMontage_C.__PropertyOffset_2) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_SM_TaskMontage_C.__PropertyOffset_2) = (value ? 1 : 0);
			}
		}

		// Token: 0x17007BDF RID: 31711
		// (get) Token: 0x0602D67B RID: 185979 RVA: 0x00ABF49A File Offset: 0x00ABD69A
		// (set) Token: 0x0602D67C RID: 185980 RVA: 0x00ABF4AA File Offset: 0x00ABD6AA
		public unsafe int BlendInTime
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SM_TaskMontage_C.__PropertyOffset_3);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_SM_TaskMontage_C.__PropertyOffset_3) = value;
			}
		}

		// Token: 0x17007BE0 RID: 31712
		// (get) Token: 0x0602D67D RID: 185981 RVA: 0x00ABF4BB File Offset: 0x00ABD6BB
		// (set) Token: 0x0602D67E RID: 185982 RVA: 0x00ABF4CB File Offset: 0x00ABD6CB
		public unsafe bool 生态蒙太奇强制Push到服务器
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SM_TaskMontage_C.__PropertyOffset_4) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_SM_TaskMontage_C.__PropertyOffset_4) = (value ? 1 : 0);
			}
		}

		// Token: 0x17007BE1 RID: 31713
		// (get) Token: 0x0602D67F RID: 185983 RVA: 0x00ABF4DC File Offset: 0x00ABD6DC
		// (set) Token: 0x0602D680 RID: 185984 RVA: 0x00ABF4F0 File Offset: 0x00ABD6F0
		public unsafe FGameplayTag ConfigReplaceTag
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SM_TaskMontage_C.__PropertyOffset_5);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_SM_TaskMontage_C.__PropertyOffset_5) = value;
			}
		}

		// Token: 0x0602D681 RID: 185985 RVA: 0x00ABF505 File Offset: 0x00ABD705
		protected BP_SM_TaskMontage_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x04019772 RID: 104306
		public new const string __ObjectPath = "/Game/Aki/Character/BaseCharacter/StateMachine/BP_SM_TaskMontage.BP_SM_TaskMontage_C";

		// Token: 0x04019773 RID: 104307
		private static IntPtr _ClassPtr;

		// Token: 0x04019774 RID: 104308
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x04019775 RID: 104309
		internal static int __PropertyOffset_0;

		// Token: 0x04019776 RID: 104310
		internal static int __PropertyOffset_1;

		// Token: 0x04019777 RID: 104311
		internal static int __PropertyOffset_2;

		// Token: 0x04019778 RID: 104312
		internal static int __PropertyOffset_3;

		// Token: 0x04019779 RID: 104313
		internal static int __PropertyOffset_4;

		// Token: 0x0401977A RID: 104314
		internal static int __PropertyOffset_5;
	}
}
