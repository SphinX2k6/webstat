using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Character.BaseCharacter.StateMachine
{
	// Token: 0x020042DC RID: 17116
	[UnrealObjectPath("/Game/Aki/Character/BaseCharacter/StateMachine/BP_SM_TaskLeaveFight.BP_SM_TaskLeaveFight_C")]
	[UnrealStructLayout(64, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 57)]
	public class BP_SM_TaskLeaveFight_C : UASMTask, IUnrealUObject, IUnrealObject
	{
		// Token: 0x0602D668 RID: 185960 RVA: 0x00ABF2C4 File Offset: 0x00ABD4C4
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_SM_TaskLeaveFight_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Character/BaseCharacter/StateMachine/BP_SM_TaskLeaveFight.BP_SM_TaskLeaveFight_C");
			}
			return BP_SM_TaskLeaveFight_C._ClassPtr;
		}

		// Token: 0x0602D669 RID: 185961 RVA: 0x00ABF2E8 File Offset: 0x00ABD4E8
		public BP_SM_TaskLeaveFight_C() : this(BuiltinUtils.AllocNativeUObject(BP_SM_TaskLeaveFight_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x0602D66A RID: 185962 RVA: 0x00ABF310 File Offset: 0x00ABD510
		[NullableContext(1)]
		public BP_SM_TaskLeaveFight_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_SM_TaskLeaveFight_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x17007BD9 RID: 31705
		// (get) Token: 0x0602D66B RID: 185963 RVA: 0x00ABF343 File Offset: 0x00ABD543
		// (set) Token: 0x0602D66C RID: 185964 RVA: 0x00ABF353 File Offset: 0x00ABD553
		public unsafe int 最大停止时间超过时长直接传送
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SM_TaskLeaveFight_C.__PropertyOffset_0);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_SM_TaskLeaveFight_C.__PropertyOffset_0) = value;
			}
		}

		// Token: 0x17007BDA RID: 31706
		// (get) Token: 0x0602D66D RID: 185965 RVA: 0x00ABF364 File Offset: 0x00ABD564
		// (set) Token: 0x0602D66E RID: 185966 RVA: 0x00ABF374 File Offset: 0x00ABD574
		public unsafe int 脱战瞬移时间
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SM_TaskLeaveFight_C.__PropertyOffset_1);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_SM_TaskLeaveFight_C.__PropertyOffset_1) = value;
			}
		}

		// Token: 0x17007BDB RID: 31707
		// (get) Token: 0x0602D66F RID: 185967 RVA: 0x00ABF385 File Offset: 0x00ABD585
		// (set) Token: 0x0602D670 RID: 185968 RVA: 0x00ABF395 File Offset: 0x00ABD595
		public unsafe bool 是否使用最后一个巡逻点
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SM_TaskLeaveFight_C.__PropertyOffset_2) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_SM_TaskLeaveFight_C.__PropertyOffset_2) = (value ? 1 : 0);
			}
		}

		// Token: 0x0602D671 RID: 185969 RVA: 0x00ABF3A6 File Offset: 0x00ABD5A6
		protected BP_SM_TaskLeaveFight_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x0401976C RID: 104300
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Character/BaseCharacter/StateMachine/BP_SM_TaskLeaveFight.BP_SM_TaskLeaveFight_C";

		// Token: 0x0401976D RID: 104301
		private static IntPtr _ClassPtr;

		// Token: 0x0401976E RID: 104302
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x0401976F RID: 104303
		internal static int __PropertyOffset_0;

		// Token: 0x04019770 RID: 104304
		internal static int __PropertyOffset_1;

		// Token: 0x04019771 RID: 104305
		internal static int __PropertyOffset_2;
	}
}
