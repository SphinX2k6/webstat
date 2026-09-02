using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;

namespace AkiClient.Game.Aki.Render.RuntimeBP.PCG.LightPrefab.Struction
{
	// Token: 0x02003BE1 RID: 15329
	[HasGetTypeHash]
	[UnrealObjectPath("/Game/Aki/Render/RuntimeBP/PCG/LightPrefab/Struction/PCG_LightPrefab_Swing.PCG_LightPrefab_Swing")]
	[UnrealStructLayout(24, 4, UnrealReflectionPropertyTypeCode.UnrealScriptStructProxy, PropertiesSize = 24)]
	public class PCG_LightPrefab_Swing : UnrealUserDefinedStructProxy, IUnrealScriptStructProxy, IUnrealScriptStruct, IUnrealObject
	{
		// Token: 0x0602269D RID: 140957 RVA: 0x00964E97 File Offset: 0x00963097
		public static UScriptStructStackOnlyPtr StaticStruct()
		{
			return (PCG_LightPrefab_Swing._ScriptStructPtr != 0) ? PCG_LightPrefab_Swing._ScriptStructPtr : UObjectGlobals.StaticLoadScriptStruct("/Game/Aki/Render/RuntimeBP/PCG/LightPrefab/Struction/PCG_LightPrefab_Swing.PCG_LightPrefab_Swing", ref PCG_LightPrefab_Swing._ScriptStructPtr);
		}

		// Token: 0x1700409D RID: 16541
		// (get) Token: 0x0602269E RID: 140958 RVA: 0x00964EBB File Offset: 0x009630BB
		// (set) Token: 0x0602269F RID: 140959 RVA: 0x00964ECB File Offset: 0x009630CB
		public unsafe bool 开启摆动
		{
			get
			{
				return *(base.NativePtr + (IntPtr)PCG_LightPrefab_Swing.__PropertyOffset_0) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)PCG_LightPrefab_Swing.__PropertyOffset_0) = (value ? 1 : 0);
			}
		}

		// Token: 0x1700409E RID: 16542
		// (get) Token: 0x060226A0 RID: 140960 RVA: 0x00964EDC File Offset: 0x009630DC
		// (set) Token: 0x060226A1 RID: 140961 RVA: 0x00964EF0 File Offset: 0x009630F0
		public unsafe FVector 摆动方向
		{
			get
			{
				return *(base.NativePtr + (IntPtr)PCG_LightPrefab_Swing.__PropertyOffset_1);
			}
			set
			{
				*(base.NativePtr + (IntPtr)PCG_LightPrefab_Swing.__PropertyOffset_1) = value;
			}
		}

		// Token: 0x1700409F RID: 16543
		// (get) Token: 0x060226A2 RID: 140962 RVA: 0x00964F05 File Offset: 0x00963105
		// (set) Token: 0x060226A3 RID: 140963 RVA: 0x00964F15 File Offset: 0x00963115
		public unsafe float 摆动幅度
		{
			get
			{
				return *(base.NativePtr + (IntPtr)PCG_LightPrefab_Swing.__PropertyOffset_2);
			}
			set
			{
				*(base.NativePtr + (IntPtr)PCG_LightPrefab_Swing.__PropertyOffset_2) = value;
			}
		}

		// Token: 0x170040A0 RID: 16544
		// (get) Token: 0x060226A4 RID: 140964 RVA: 0x00964F26 File Offset: 0x00963126
		// (set) Token: 0x060226A5 RID: 140965 RVA: 0x00964F36 File Offset: 0x00963136
		public unsafe float 摆动频率
		{
			get
			{
				return *(base.NativePtr + (IntPtr)PCG_LightPrefab_Swing.__PropertyOffset_3);
			}
			set
			{
				*(base.NativePtr + (IntPtr)PCG_LightPrefab_Swing.__PropertyOffset_3) = value;
			}
		}

		// Token: 0x060226A6 RID: 140966 RVA: 0x00964F47 File Offset: 0x00963147
		public PCG_LightPrefab_Swing()
		{
		}

		// Token: 0x060226A7 RID: 140967 RVA: 0x00964F4F File Offset: 0x0096314F
		public PCG_LightPrefab_Swing(bool 开启摆动, FVector 摆动方向, float 摆动幅度, float 摆动频率)
		{
			this.开启摆动 = 开启摆动;
			this.摆动方向 = 摆动方向;
			this.摆动幅度 = 摆动幅度;
			this.摆动频率 = 摆动频率;
		}

		// Token: 0x060226A8 RID: 140968 RVA: 0x00964F74 File Offset: 0x00963174
		protected override IntPtr GetUStructPtr()
		{
			return PCG_LightPrefab_Swing.StaticStruct();
		}

		// Token: 0x060226A9 RID: 140969 RVA: 0x00964F80 File Offset: 0x00963180
		[NullableContext(2)]
		public PCG_LightPrefab_Swing(IntPtr NativePtr, UnrealObject MemoryOwner) : base(NativePtr, MemoryOwner)
		{
		}

		// Token: 0x060226AA RID: 140970 RVA: 0x00964F8A File Offset: 0x0096318A
		public PCG_LightPrefab_Swing(IntPtr NativePtr, bool bWithMoveAssign, bool bWithCopyAssignIfCannotMove) : base(NativePtr, bWithMoveAssign, bWithCopyAssignIfCannotMove)
		{
		}

		// Token: 0x060226AB RID: 140971 RVA: 0x00964F95 File Offset: 0x00963195
		[NullableContext(1)]
		public static IUnrealScriptStructProxy CreateFromPointer(IntPtr Pointer)
		{
			return new PCG_LightPrefab_Swing(Pointer, false, true);
		}

		// Token: 0x060226AC RID: 140972 RVA: 0x00964F9F File Offset: 0x0096319F
		[NullableContext(1)]
		public static IUnrealScriptStructProxy CreateReferenceFromPointer(IntPtr Pointer, UnrealObject MemoryOwner)
		{
			return new PCG_LightPrefab_Swing(Pointer, MemoryOwner);
		}

		// Token: 0x040116BB RID: 71355
		[Nullable(1)]
		public const string __ObjectPath = "/Game/Aki/Render/RuntimeBP/PCG/LightPrefab/Struction/PCG_LightPrefab_Swing.PCG_LightPrefab_Swing";

		// Token: 0x040116BC RID: 71356
		private static IntPtr _ScriptStructPtr;

		// Token: 0x040116BD RID: 71357
		internal static int __PropertyOffset_0;

		// Token: 0x040116BE RID: 71358
		internal static int __PropertyOffset_1;

		// Token: 0x040116BF RID: 71359
		internal static int __PropertyOffset_2;

		// Token: 0x040116C0 RID: 71360
		internal static int __PropertyOffset_3;
	}
}
