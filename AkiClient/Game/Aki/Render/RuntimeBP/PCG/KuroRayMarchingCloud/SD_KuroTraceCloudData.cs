using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;

namespace AkiClient.Game.Aki.Render.RuntimeBP.PCG.KuroRayMarchingCloud
{
	// Token: 0x02003BEA RID: 15338
	[HasGetTypeHash]
	[UnrealObjectPath("/Game/Aki/Render/RuntimeBP/PCG/KuroRayMarchingCloud/SD_KuroTraceCloudData.SD_KuroTraceCloudData")]
	[UnrealStructLayout(20, 4, UnrealReflectionPropertyTypeCode.UnrealScriptStructProxy, PropertiesSize = 20)]
	public class SD_KuroTraceCloudData : UnrealUserDefinedStructProxy, IUnrealScriptStructProxy, IUnrealScriptStruct, IUnrealObject
	{
		// Token: 0x060228AF RID: 141487 RVA: 0x009683A3 File Offset: 0x009665A3
		public static UScriptStructStackOnlyPtr StaticStruct()
		{
			return (SD_KuroTraceCloudData._ScriptStructPtr != 0) ? SD_KuroTraceCloudData._ScriptStructPtr : UObjectGlobals.StaticLoadScriptStruct("/Game/Aki/Render/RuntimeBP/PCG/KuroRayMarchingCloud/SD_KuroTraceCloudData.SD_KuroTraceCloudData", ref SD_KuroTraceCloudData._ScriptStructPtr);
		}

		// Token: 0x17004168 RID: 16744
		// (get) Token: 0x060228B0 RID: 141488 RVA: 0x009683C7 File Offset: 0x009665C7
		// (set) Token: 0x060228B1 RID: 141489 RVA: 0x009683D7 File Offset: 0x009665D7
		public unsafe float Time
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SD_KuroTraceCloudData.__PropertyOffset_0);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SD_KuroTraceCloudData.__PropertyOffset_0) = value;
			}
		}

		// Token: 0x17004169 RID: 16745
		// (get) Token: 0x060228B2 RID: 141490 RVA: 0x009683E8 File Offset: 0x009665E8
		// (set) Token: 0x060228B3 RID: 141491 RVA: 0x009683FC File Offset: 0x009665FC
		public unsafe FLinearColor LightWeight
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SD_KuroTraceCloudData.__PropertyOffset_1);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SD_KuroTraceCloudData.__PropertyOffset_1) = value;
			}
		}

		// Token: 0x060228B4 RID: 141492 RVA: 0x00968411 File Offset: 0x00966611
		public SD_KuroTraceCloudData()
		{
		}

		// Token: 0x060228B5 RID: 141493 RVA: 0x00968419 File Offset: 0x00966619
		public SD_KuroTraceCloudData(float Time, FLinearColor LightWeight)
		{
			this.Time = Time;
			this.LightWeight = LightWeight;
		}

		// Token: 0x060228B6 RID: 141494 RVA: 0x0096842F File Offset: 0x0096662F
		protected override IntPtr GetUStructPtr()
		{
			return SD_KuroTraceCloudData.StaticStruct();
		}

		// Token: 0x060228B7 RID: 141495 RVA: 0x0096843B File Offset: 0x0096663B
		[NullableContext(2)]
		public SD_KuroTraceCloudData(IntPtr NativePtr, UnrealObject MemoryOwner) : base(NativePtr, MemoryOwner)
		{
		}

		// Token: 0x060228B8 RID: 141496 RVA: 0x00968445 File Offset: 0x00966645
		public SD_KuroTraceCloudData(IntPtr NativePtr, bool bWithMoveAssign, bool bWithCopyAssignIfCannotMove) : base(NativePtr, bWithMoveAssign, bWithCopyAssignIfCannotMove)
		{
		}

		// Token: 0x060228B9 RID: 141497 RVA: 0x00968450 File Offset: 0x00966650
		[NullableContext(1)]
		public static IUnrealScriptStructProxy CreateFromPointer(IntPtr Pointer)
		{
			return new SD_KuroTraceCloudData(Pointer, false, true);
		}

		// Token: 0x060228BA RID: 141498 RVA: 0x0096845A File Offset: 0x0096665A
		[NullableContext(1)]
		public static IUnrealScriptStructProxy CreateReferenceFromPointer(IntPtr Pointer, UnrealObject MemoryOwner)
		{
			return new SD_KuroTraceCloudData(Pointer, MemoryOwner);
		}

		// Token: 0x040117EE RID: 71662
		[Nullable(1)]
		public const string __ObjectPath = "/Game/Aki/Render/RuntimeBP/PCG/KuroRayMarchingCloud/SD_KuroTraceCloudData.SD_KuroTraceCloudData";

		// Token: 0x040117EF RID: 71663
		private static IntPtr _ScriptStructPtr;

		// Token: 0x040117F0 RID: 71664
		internal static int __PropertyOffset_0;

		// Token: 0x040117F1 RID: 71665
		internal static int __PropertyOffset_1;
	}
}
