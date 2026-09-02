using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;

namespace AkiClient.Game.Aki.CreatureTools.Designer
{
	// Token: 0x02003F2C RID: 16172
	[NullableContext(1)]
	[Nullable(0)]
	[HasGetTypeHash]
	[UnrealObjectPath("/Game/Aki/CreatureTools/Designer/NPCDataExport.NPCDataExport")]
	[UnrealStructLayout(184, 8, UnrealReflectionPropertyTypeCode.UnrealScriptStructProxy, PropertiesSize = 184)]
	public class NPCDataExport : UnrealUserDefinedStructProxy, IUnrealScriptStructProxy, IUnrealScriptStruct, IUnrealObject
	{
		// Token: 0x060285BF RID: 165311 RVA: 0x00A087D2 File Offset: 0x00A069D2
		public static UScriptStructStackOnlyPtr StaticStruct()
		{
			return (NPCDataExport._ScriptStructPtr != 0) ? NPCDataExport._ScriptStructPtr : UObjectGlobals.StaticLoadScriptStruct("/Game/Aki/CreatureTools/Designer/NPCDataExport.NPCDataExport", ref NPCDataExport._ScriptStructPtr);
		}

		// Token: 0x170061F2 RID: 25074
		// (get) Token: 0x060285C0 RID: 165312 RVA: 0x00A087F6 File Offset: 0x00A069F6
		// (set) Token: 0x060285C1 RID: 165313 RVA: 0x00A0880A File Offset: 0x00A06A0A
		public unsafe string 名称
		{
			get
			{
				return FString.ToString((void*)(base.NativePtr + (byte*)((IntPtr)NPCDataExport.__PropertyOffset_0)));
			}
			set
			{
				FString.CopyFrom((void*)(base.NativePtr + (byte*)((IntPtr)NPCDataExport.__PropertyOffset_0)), value);
			}
		}

		// Token: 0x170061F3 RID: 25075
		// (get) Token: 0x060285C2 RID: 165314 RVA: 0x00A0881F File Offset: 0x00A06A1F
		// (set) Token: 0x060285C3 RID: 165315 RVA: 0x00A08833 File Offset: 0x00A06A33
		public unsafe string 实体描述
		{
			get
			{
				return FString.ToString((void*)(base.NativePtr + (byte*)((IntPtr)NPCDataExport.__PropertyOffset_1)));
			}
			set
			{
				FString.CopyFrom((void*)(base.NativePtr + (byte*)((IntPtr)NPCDataExport.__PropertyOffset_1)), value);
			}
		}

		// Token: 0x170061F4 RID: 25076
		// (get) Token: 0x060285C4 RID: 165316 RVA: 0x00A08848 File Offset: 0x00A06A48
		// (set) Token: 0x060285C5 RID: 165317 RVA: 0x00A0885C File Offset: 0x00A06A5C
		public unsafe string 负责人
		{
			get
			{
				return FString.ToString((void*)(base.NativePtr + (byte*)((IntPtr)NPCDataExport.__PropertyOffset_2)));
			}
			set
			{
				FString.CopyFrom((void*)(base.NativePtr + (byte*)((IntPtr)NPCDataExport.__PropertyOffset_2)), value);
			}
		}

		// Token: 0x170061F5 RID: 25077
		// (get) Token: 0x060285C6 RID: 165318 RVA: 0x00A08871 File Offset: 0x00A06A71
		// (set) Token: 0x060285C7 RID: 165319 RVA: 0x00A08885 File Offset: 0x00A06A85
		public unsafe string 所属区域
		{
			get
			{
				return FString.ToString((void*)(base.NativePtr + (byte*)((IntPtr)NPCDataExport.__PropertyOffset_3)));
			}
			set
			{
				FString.CopyFrom((void*)(base.NativePtr + (byte*)((IntPtr)NPCDataExport.__PropertyOffset_3)), value);
			}
		}

		// Token: 0x170061F6 RID: 25078
		// (get) Token: 0x060285C8 RID: 165320 RVA: 0x00A0889A File Offset: 0x00A06A9A
		// (set) Token: 0x060285C9 RID: 165321 RVA: 0x00A088AA File Offset: 0x00A06AAA
		public unsafe long 造物ID
		{
			get
			{
				return *(base.NativePtr + (IntPtr)NPCDataExport.__PropertyOffset_4);
			}
			set
			{
				*(base.NativePtr + (IntPtr)NPCDataExport.__PropertyOffset_4) = value;
			}
		}

		// Token: 0x170061F7 RID: 25079
		// (get) Token: 0x060285CA RID: 165322 RVA: 0x00A088BB File Offset: 0x00A06ABB
		// (set) Token: 0x060285CB RID: 165323 RVA: 0x00A088CF File Offset: 0x00A06ACF
		public unsafe FIntVector 位置
		{
			get
			{
				return *(base.NativePtr + (IntPtr)NPCDataExport.__PropertyOffset_5);
			}
			set
			{
				*(base.NativePtr + (IntPtr)NPCDataExport.__PropertyOffset_5) = value;
			}
		}

		// Token: 0x170061F8 RID: 25080
		// (get) Token: 0x060285CC RID: 165324 RVA: 0x00A088E4 File Offset: 0x00A06AE4
		// (set) Token: 0x060285CD RID: 165325 RVA: 0x00A08903 File Offset: 0x00A06B03
		public TSoftObjectPtr<USkeletalMesh> 模型
		{
			get
			{
				return new TSoftObjectPtr<USkeletalMesh>(base.NativePtr + (IntPtr)NPCDataExport.__PropertyOffset_6, base.MemoryOwner ?? this);
			}
			set
			{
				FSoftObjectPtr.NativeCopy(base.NativePtr + (IntPtr)NPCDataExport.__PropertyOffset_6, (value != null) ? value.NativePtr : IntPtr.Zero, 1);
			}
		}

		// Token: 0x170061F9 RID: 25081
		// (get) Token: 0x060285CE RID: 165326 RVA: 0x00A08928 File Offset: 0x00A06B28
		// (set) Token: 0x060285CF RID: 165327 RVA: 0x00A0893C File Offset: 0x00A06B3C
		public unsafe string 类型
		{
			get
			{
				return FString.ToString((void*)(base.NativePtr + (byte*)((IntPtr)NPCDataExport.__PropertyOffset_7)));
			}
			set
			{
				FString.CopyFrom((void*)(base.NativePtr + (byte*)((IntPtr)NPCDataExport.__PropertyOffset_7)), value);
			}
		}

		// Token: 0x170061FA RID: 25082
		// (get) Token: 0x060285D0 RID: 165328 RVA: 0x00A08951 File Offset: 0x00A06B51
		// (set) Token: 0x060285D1 RID: 165329 RVA: 0x00A08965 File Offset: 0x00A06B65
		public unsafe string 所在任务
		{
			get
			{
				return FString.ToString((void*)(base.NativePtr + (byte*)((IntPtr)NPCDataExport.__PropertyOffset_8)));
			}
			set
			{
				FString.CopyFrom((void*)(base.NativePtr + (byte*)((IntPtr)NPCDataExport.__PropertyOffset_8)), value);
			}
		}

		// Token: 0x170061FB RID: 25083
		// (get) Token: 0x060285D2 RID: 165330 RVA: 0x00A0897A File Offset: 0x00A06B7A
		// (set) Token: 0x060285D3 RID: 165331 RVA: 0x00A0898A File Offset: 0x00A06B8A
		public unsafe int 生成任务步骤
		{
			get
			{
				return *(base.NativePtr + (IntPtr)NPCDataExport.__PropertyOffset_9);
			}
			set
			{
				*(base.NativePtr + (IntPtr)NPCDataExport.__PropertyOffset_9) = value;
			}
		}

		// Token: 0x170061FC RID: 25084
		// (get) Token: 0x060285D4 RID: 165332 RVA: 0x00A0899B File Offset: 0x00A06B9B
		// (set) Token: 0x060285D5 RID: 165333 RVA: 0x00A089AB File Offset: 0x00A06BAB
		public unsafe int 销毁任务步骤
		{
			get
			{
				return *(base.NativePtr + (IntPtr)NPCDataExport.__PropertyOffset_10);
			}
			set
			{
				*(base.NativePtr + (IntPtr)NPCDataExport.__PropertyOffset_10) = value;
			}
		}

		// Token: 0x170061FD RID: 25085
		// (get) Token: 0x060285D6 RID: 165334 RVA: 0x00A089BC File Offset: 0x00A06BBC
		// (set) Token: 0x060285D7 RID: 165335 RVA: 0x00A089CC File Offset: 0x00A06BCC
		public unsafe int 造物生成条件组
		{
			get
			{
				return *(base.NativePtr + (IntPtr)NPCDataExport.__PropertyOffset_11);
			}
			set
			{
				*(base.NativePtr + (IntPtr)NPCDataExport.__PropertyOffset_11) = value;
			}
		}

		// Token: 0x170061FE RID: 25086
		// (get) Token: 0x060285D8 RID: 165336 RVA: 0x00A089DD File Offset: 0x00A06BDD
		// (set) Token: 0x060285D9 RID: 165337 RVA: 0x00A089ED File Offset: 0x00A06BED
		public unsafe int 挂载AI
		{
			get
			{
				return *(base.NativePtr + (IntPtr)NPCDataExport.__PropertyOffset_12);
			}
			set
			{
				*(base.NativePtr + (IntPtr)NPCDataExport.__PropertyOffset_12) = value;
			}
		}

		// Token: 0x060285DA RID: 165338 RVA: 0x00A089FE File Offset: 0x00A06BFE
		public NPCDataExport()
		{
		}

		// Token: 0x060285DB RID: 165339 RVA: 0x00A08A08 File Offset: 0x00A06C08
		public NPCDataExport(string 名称, string 实体描述, string 负责人, string 所属区域, long 造物ID, FIntVector 位置, TSoftObjectPtr<USkeletalMesh> 模型, string 类型, string 所在任务, int 生成任务步骤, int 销毁任务步骤, int 造物生成条件组, int 挂载AI)
		{
			this.名称 = 名称;
			this.实体描述 = 实体描述;
			this.负责人 = 负责人;
			this.所属区域 = 所属区域;
			this.造物ID = 造物ID;
			this.位置 = 位置;
			this.模型 = 模型;
			this.类型 = 类型;
			this.所在任务 = 所在任务;
			this.生成任务步骤 = 生成任务步骤;
			this.销毁任务步骤 = 销毁任务步骤;
			this.造物生成条件组 = 造物生成条件组;
			this.挂载AI = 挂载AI;
		}

		// Token: 0x060285DC RID: 165340 RVA: 0x00A08A80 File Offset: 0x00A06C80
		protected override IntPtr GetUStructPtr()
		{
			return NPCDataExport.StaticStruct();
		}

		// Token: 0x060285DD RID: 165341 RVA: 0x00A08A8C File Offset: 0x00A06C8C
		[NullableContext(2)]
		public NPCDataExport(IntPtr NativePtr, UnrealObject MemoryOwner) : base(NativePtr, MemoryOwner)
		{
		}

		// Token: 0x060285DE RID: 165342 RVA: 0x00A08A96 File Offset: 0x00A06C96
		public NPCDataExport(IntPtr NativePtr, bool bWithMoveAssign, bool bWithCopyAssignIfCannotMove) : base(NativePtr, bWithMoveAssign, bWithCopyAssignIfCannotMove)
		{
		}

		// Token: 0x060285DF RID: 165343 RVA: 0x00A08AA1 File Offset: 0x00A06CA1
		public static IUnrealScriptStructProxy CreateFromPointer(IntPtr Pointer)
		{
			return new NPCDataExport(Pointer, false, true);
		}

		// Token: 0x060285E0 RID: 165344 RVA: 0x00A08AAB File Offset: 0x00A06CAB
		public static IUnrealScriptStructProxy CreateReferenceFromPointer(IntPtr Pointer, UnrealObject MemoryOwner)
		{
			return new NPCDataExport(Pointer, MemoryOwner);
		}

		// Token: 0x040153A4 RID: 86948
		public const string __ObjectPath = "/Game/Aki/CreatureTools/Designer/NPCDataExport.NPCDataExport";

		// Token: 0x040153A5 RID: 86949
		private static IntPtr _ScriptStructPtr;

		// Token: 0x040153A6 RID: 86950
		internal static int __PropertyOffset_0;

		// Token: 0x040153A7 RID: 86951
		internal static int __PropertyOffset_1;

		// Token: 0x040153A8 RID: 86952
		internal static int __PropertyOffset_2;

		// Token: 0x040153A9 RID: 86953
		internal static int __PropertyOffset_3;

		// Token: 0x040153AA RID: 86954
		internal static int __PropertyOffset_4;

		// Token: 0x040153AB RID: 86955
		internal static int __PropertyOffset_5;

		// Token: 0x040153AC RID: 86956
		internal static int __PropertyOffset_6;

		// Token: 0x040153AD RID: 86957
		internal static int __PropertyOffset_7;

		// Token: 0x040153AE RID: 86958
		internal static int __PropertyOffset_8;

		// Token: 0x040153AF RID: 86959
		internal static int __PropertyOffset_9;

		// Token: 0x040153B0 RID: 86960
		internal static int __PropertyOffset_10;

		// Token: 0x040153B1 RID: 86961
		internal static int __PropertyOffset_11;

		// Token: 0x040153B2 RID: 86962
		internal static int __PropertyOffset_12;
	}
}
