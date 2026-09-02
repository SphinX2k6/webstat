using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;

namespace AkiClient.Game.Aki.Render.RuntimeBP.PCG.RoadSpline.Structure
{
	// Token: 0x02003B9F RID: 15263
	[HasGetTypeHash]
	[UnrealObjectPath("/Game/Aki/Render/RuntimeBP/PCG/RoadSpline/Structure/SPCG_RoadSplineDecalProperity.SPCG_RoadSplineDecalProperity")]
	[UnrealStructLayout(28, 4, UnrealReflectionPropertyTypeCode.UnrealScriptStructProxy, PropertiesSize = 28)]
	public class SPCG_RoadSplineDecalProperity : UnrealUserDefinedStructProxy, IUnrealScriptStructProxy, IUnrealScriptStruct, IUnrealObject
	{
		// Token: 0x06021E69 RID: 138857 RVA: 0x00956C9F File Offset: 0x00954E9F
		public static UScriptStructStackOnlyPtr StaticStruct()
		{
			return (SPCG_RoadSplineDecalProperity._ScriptStructPtr != 0) ? SPCG_RoadSplineDecalProperity._ScriptStructPtr : UObjectGlobals.StaticLoadScriptStruct("/Game/Aki/Render/RuntimeBP/PCG/RoadSpline/Structure/SPCG_RoadSplineDecalProperity.SPCG_RoadSplineDecalProperity", ref SPCG_RoadSplineDecalProperity._ScriptStructPtr);
		}

		// Token: 0x17003DA1 RID: 15777
		// (get) Token: 0x06021E6A RID: 138858 RVA: 0x00956CC3 File Offset: 0x00954EC3
		// (set) Token: 0x06021E6B RID: 138859 RVA: 0x00956CD3 File Offset: 0x00954ED3
		public unsafe int 数量
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SPCG_RoadSplineDecalProperity.__PropertyOffset_0);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SPCG_RoadSplineDecalProperity.__PropertyOffset_0) = value;
			}
		}

		// Token: 0x17003DA2 RID: 15778
		// (get) Token: 0x06021E6C RID: 138860 RVA: 0x00956CE4 File Offset: 0x00954EE4
		// (set) Token: 0x06021E6D RID: 138861 RVA: 0x00956CF8 File Offset: 0x00954EF8
		public unsafe FVector2D 距离范围
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SPCG_RoadSplineDecalProperity.__PropertyOffset_1);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SPCG_RoadSplineDecalProperity.__PropertyOffset_1) = value;
			}
		}

		// Token: 0x17003DA3 RID: 15779
		// (get) Token: 0x06021E6E RID: 138862 RVA: 0x00956D0D File Offset: 0x00954F0D
		// (set) Token: 0x06021E6F RID: 138863 RVA: 0x00956D21 File Offset: 0x00954F21
		public unsafe FVector2D 大小范围
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SPCG_RoadSplineDecalProperity.__PropertyOffset_2);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SPCG_RoadSplineDecalProperity.__PropertyOffset_2) = value;
			}
		}

		// Token: 0x17003DA4 RID: 15780
		// (get) Token: 0x06021E70 RID: 138864 RVA: 0x00956D36 File Offset: 0x00954F36
		// (set) Token: 0x06021E71 RID: 138865 RVA: 0x00956D4A File Offset: 0x00954F4A
		public unsafe FVector2D 旋转范围
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SPCG_RoadSplineDecalProperity.__PropertyOffset_3);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SPCG_RoadSplineDecalProperity.__PropertyOffset_3) = value;
			}
		}

		// Token: 0x06021E72 RID: 138866 RVA: 0x00956D5F File Offset: 0x00954F5F
		public SPCG_RoadSplineDecalProperity()
		{
		}

		// Token: 0x06021E73 RID: 138867 RVA: 0x00956D67 File Offset: 0x00954F67
		public SPCG_RoadSplineDecalProperity(int 数量, FVector2D 距离范围, FVector2D 大小范围, FVector2D 旋转范围)
		{
			this.数量 = 数量;
			this.距离范围 = 距离范围;
			this.大小范围 = 大小范围;
			this.旋转范围 = 旋转范围;
		}

		// Token: 0x06021E74 RID: 138868 RVA: 0x00956D8C File Offset: 0x00954F8C
		protected override IntPtr GetUStructPtr()
		{
			return SPCG_RoadSplineDecalProperity.StaticStruct();
		}

		// Token: 0x06021E75 RID: 138869 RVA: 0x00956D98 File Offset: 0x00954F98
		[NullableContext(2)]
		public SPCG_RoadSplineDecalProperity(IntPtr NativePtr, UnrealObject MemoryOwner) : base(NativePtr, MemoryOwner)
		{
		}

		// Token: 0x06021E76 RID: 138870 RVA: 0x00956DA2 File Offset: 0x00954FA2
		public SPCG_RoadSplineDecalProperity(IntPtr NativePtr, bool bWithMoveAssign, bool bWithCopyAssignIfCannotMove) : base(NativePtr, bWithMoveAssign, bWithCopyAssignIfCannotMove)
		{
		}

		// Token: 0x06021E77 RID: 138871 RVA: 0x00956DAD File Offset: 0x00954FAD
		[NullableContext(1)]
		public static IUnrealScriptStructProxy CreateFromPointer(IntPtr Pointer)
		{
			return new SPCG_RoadSplineDecalProperity(Pointer, false, true);
		}

		// Token: 0x06021E78 RID: 138872 RVA: 0x00956DB7 File Offset: 0x00954FB7
		[NullableContext(1)]
		public static IUnrealScriptStructProxy CreateReferenceFromPointer(IntPtr Pointer, UnrealObject MemoryOwner)
		{
			return new SPCG_RoadSplineDecalProperity(Pointer, MemoryOwner);
		}

		// Token: 0x040111DB RID: 70107
		[Nullable(1)]
		public const string __ObjectPath = "/Game/Aki/Render/RuntimeBP/PCG/RoadSpline/Structure/SPCG_RoadSplineDecalProperity.SPCG_RoadSplineDecalProperity";

		// Token: 0x040111DC RID: 70108
		private static IntPtr _ScriptStructPtr;

		// Token: 0x040111DD RID: 70109
		internal static int __PropertyOffset_0;

		// Token: 0x040111DE RID: 70110
		internal static int __PropertyOffset_1;

		// Token: 0x040111DF RID: 70111
		internal static int __PropertyOffset_2;

		// Token: 0x040111E0 RID: 70112
		internal static int __PropertyOffset_3;
	}
}
