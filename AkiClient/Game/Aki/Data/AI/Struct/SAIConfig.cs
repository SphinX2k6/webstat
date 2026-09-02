using System;
using System.Runtime.CompilerServices;
using AkiClient.Game.Aki.AI.AIFunctionCommon;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;

namespace AkiClient.Game.Aki.Data.AI.Struct
{
	// Token: 0x02003F1C RID: 16156
	[NullableContext(1)]
	[Nullable(0)]
	[HasGetTypeHash]
	[UnrealObjectPath("/Game/Aki/Data/AI/Struct/SAIConfig.SAIConfig")]
	[UnrealStructLayout(80, 8, UnrealReflectionPropertyTypeCode.UnrealScriptStructProxy, PropertiesSize = 80)]
	public class SAIConfig : UnrealUserDefinedStructProxy, IUnrealScriptStructProxy, IUnrealScriptStruct, IUnrealObject
	{
		// Token: 0x0602850F RID: 165135 RVA: 0x00A078F6 File Offset: 0x00A05AF6
		public static UScriptStructStackOnlyPtr StaticStruct()
		{
			return (SAIConfig._ScriptStructPtr != 0) ? SAIConfig._ScriptStructPtr : UObjectGlobals.StaticLoadScriptStruct("/Game/Aki/Data/AI/Struct/SAIConfig.SAIConfig", ref SAIConfig._ScriptStructPtr);
		}

		// Token: 0x170061C6 RID: 25030
		// (get) Token: 0x06028510 RID: 165136 RVA: 0x00A0791A File Offset: 0x00A05B1A
		// (set) Token: 0x06028511 RID: 165137 RVA: 0x00A07939 File Offset: 0x00A05B39
		public TSoftClassPtr<AAIController> AIController
		{
			get
			{
				return new TSoftClassPtr<AAIController>(base.NativePtr + (IntPtr)SAIConfig.__PropertyOffset_0, base.MemoryOwner ?? this);
			}
			set
			{
				FSoftObjectPtr.NativeCopy(base.NativePtr + (IntPtr)SAIConfig.__PropertyOffset_0, (value != null) ? value.NativePtr : IntPtr.Zero, 1);
			}
		}

		// Token: 0x170061C7 RID: 25031
		// (get) Token: 0x06028512 RID: 165138 RVA: 0x00A0795E File Offset: 0x00A05B5E
		// (set) Token: 0x06028513 RID: 165139 RVA: 0x00A07972 File Offset: 0x00A05B72
		[Nullable(0)]
		public unsafe TEnumAsByte<EActionPlan> 计划任务
		{
			[NullableContext(0)]
			get
			{
				return *(base.NativePtr + (IntPtr)SAIConfig.__PropertyOffset_1);
			}
			[NullableContext(0)]
			set
			{
				*(base.NativePtr + (IntPtr)SAIConfig.__PropertyOffset_1) = value;
			}
		}

		// Token: 0x170061C8 RID: 25032
		// (get) Token: 0x06028514 RID: 165140 RVA: 0x00A07987 File Offset: 0x00A05B87
		// (set) Token: 0x06028515 RID: 165141 RVA: 0x00A07997 File Offset: 0x00A05B97
		public unsafe int 鸣萤寻路样条ID
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SAIConfig.__PropertyOffset_2);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SAIConfig.__PropertyOffset_2) = value;
			}
		}

		// Token: 0x170061C9 RID: 25033
		// (get) Token: 0x06028516 RID: 165142 RVA: 0x00A079A8 File Offset: 0x00A05BA8
		// (set) Token: 0x06028517 RID: 165143 RVA: 0x00A079B8 File Offset: 0x00A05BB8
		public unsafe int 巡逻样条ID
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SAIConfig.__PropertyOffset_3);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SAIConfig.__PropertyOffset_3) = value;
			}
		}

		// Token: 0x170061CA RID: 25034
		// (get) Token: 0x06028518 RID: 165144 RVA: 0x00A079C9 File Offset: 0x00A05BC9
		// (set) Token: 0x06028519 RID: 165145 RVA: 0x00A079D9 File Offset: 0x00A05BD9
		public unsafe int PathPointList
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SAIConfig.__PropertyOffset_4);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SAIConfig.__PropertyOffset_4) = value;
			}
		}

		// Token: 0x170061CB RID: 25035
		// (get) Token: 0x0602851A RID: 165146 RVA: 0x00A079EA File Offset: 0x00A05BEA
		// (set) Token: 0x0602851B RID: 165147 RVA: 0x00A079FE File Offset: 0x00A05BFE
		public unsafe string 备注
		{
			get
			{
				return FString.ToString((void*)(base.NativePtr + (byte*)((IntPtr)SAIConfig.__PropertyOffset_5)));
			}
			set
			{
				FString.CopyFrom((void*)(base.NativePtr + (byte*)((IntPtr)SAIConfig.__PropertyOffset_5)), value);
			}
		}

		// Token: 0x0602851C RID: 165148 RVA: 0x00A07A13 File Offset: 0x00A05C13
		public SAIConfig()
		{
		}

		// Token: 0x0602851D RID: 165149 RVA: 0x00A07A1B File Offset: 0x00A05C1B
		public SAIConfig(TSoftClassPtr<AAIController> AIController, [Nullable(0)] TEnumAsByte<EActionPlan> 计划任务, int 鸣萤寻路样条ID, int 巡逻样条ID, int PathPointList, string 备注)
		{
			this.AIController = AIController;
			this.计划任务 = 计划任务;
			this.鸣萤寻路样条ID = 鸣萤寻路样条ID;
			this.巡逻样条ID = 巡逻样条ID;
			this.PathPointList = PathPointList;
			this.备注 = 备注;
		}

		// Token: 0x0602851E RID: 165150 RVA: 0x00A07A50 File Offset: 0x00A05C50
		protected override IntPtr GetUStructPtr()
		{
			return SAIConfig.StaticStruct();
		}

		// Token: 0x0602851F RID: 165151 RVA: 0x00A07A5C File Offset: 0x00A05C5C
		[NullableContext(2)]
		public SAIConfig(IntPtr NativePtr, UnrealObject MemoryOwner) : base(NativePtr, MemoryOwner)
		{
		}

		// Token: 0x06028520 RID: 165152 RVA: 0x00A07A66 File Offset: 0x00A05C66
		public SAIConfig(IntPtr NativePtr, bool bWithMoveAssign, bool bWithCopyAssignIfCannotMove) : base(NativePtr, bWithMoveAssign, bWithCopyAssignIfCannotMove)
		{
		}

		// Token: 0x06028521 RID: 165153 RVA: 0x00A07A71 File Offset: 0x00A05C71
		public static IUnrealScriptStructProxy CreateFromPointer(IntPtr Pointer)
		{
			return new SAIConfig(Pointer, false, true);
		}

		// Token: 0x06028522 RID: 165154 RVA: 0x00A07A7B File Offset: 0x00A05C7B
		public static IUnrealScriptStructProxy CreateReferenceFromPointer(IntPtr Pointer, UnrealObject MemoryOwner)
		{
			return new SAIConfig(Pointer, MemoryOwner);
		}

		// Token: 0x04015344 RID: 86852
		public const string __ObjectPath = "/Game/Aki/Data/AI/Struct/SAIConfig.SAIConfig";

		// Token: 0x04015345 RID: 86853
		private static IntPtr _ScriptStructPtr;

		// Token: 0x04015346 RID: 86854
		internal static int __PropertyOffset_0;

		// Token: 0x04015347 RID: 86855
		internal static int __PropertyOffset_1;

		// Token: 0x04015348 RID: 86856
		internal static int __PropertyOffset_2;

		// Token: 0x04015349 RID: 86857
		internal static int __PropertyOffset_3;

		// Token: 0x0401534A RID: 86858
		internal static int __PropertyOffset_4;

		// Token: 0x0401534B RID: 86859
		internal static int __PropertyOffset_5;
	}
}
