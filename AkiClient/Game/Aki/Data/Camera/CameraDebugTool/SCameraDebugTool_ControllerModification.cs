using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;

namespace AkiClient.Game.Aki.Data.Camera.CameraDebugTool
{
	// Token: 0x02003F1A RID: 16154
	[NullableContext(1)]
	[Nullable(0)]
	[HasGetTypeHash]
	[UnrealObjectPath("/Game/Aki/Data/Camera/CameraDebugTool/SCameraDebugTool_ControllerModification.SCameraDebugTool_ControllerModification")]
	[UnrealStructLayout(64, 8, UnrealReflectionPropertyTypeCode.UnrealScriptStructProxy, PropertiesSize = 64)]
	public class SCameraDebugTool_ControllerModification : UnrealUserDefinedStructProxy, IUnrealScriptStructProxy, IUnrealScriptStruct, IUnrealObject
	{
		// Token: 0x060284EF RID: 165103 RVA: 0x00A07684 File Offset: 0x00A05884
		public static UScriptStructStackOnlyPtr StaticStruct()
		{
			return (SCameraDebugTool_ControllerModification._ScriptStructPtr != 0) ? SCameraDebugTool_ControllerModification._ScriptStructPtr : UObjectGlobals.StaticLoadScriptStruct("/Game/Aki/Data/Camera/CameraDebugTool/SCameraDebugTool_ControllerModification.SCameraDebugTool_ControllerModification", ref SCameraDebugTool_ControllerModification._ScriptStructPtr);
		}

		// Token: 0x170061BE RID: 25022
		// (get) Token: 0x060284F0 RID: 165104 RVA: 0x00A076A8 File Offset: 0x00A058A8
		// (set) Token: 0x060284F1 RID: 165105 RVA: 0x00A076BC File Offset: 0x00A058BC
		public unsafe string ControllerName
		{
			get
			{
				return FString.ToString((void*)(base.NativePtr + (byte*)((IntPtr)SCameraDebugTool_ControllerModification.__PropertyOffset_0)));
			}
			set
			{
				FString.CopyFrom((void*)(base.NativePtr + (byte*)((IntPtr)SCameraDebugTool_ControllerModification.__PropertyOffset_0)), value);
			}
		}

		// Token: 0x170061BF RID: 25023
		// (get) Token: 0x060284F2 RID: 165106 RVA: 0x00A076D1 File Offset: 0x00A058D1
		// (set) Token: 0x060284F3 RID: 165107 RVA: 0x00A076E5 File Offset: 0x00A058E5
		public unsafe string PropertyName
		{
			get
			{
				return FString.ToString((void*)(base.NativePtr + (byte*)((IntPtr)SCameraDebugTool_ControllerModification.__PropertyOffset_1)));
			}
			set
			{
				FString.CopyFrom((void*)(base.NativePtr + (byte*)((IntPtr)SCameraDebugTool_ControllerModification.__PropertyOffset_1)), value);
			}
		}

		// Token: 0x170061C0 RID: 25024
		// (get) Token: 0x060284F4 RID: 165108 RVA: 0x00A076FA File Offset: 0x00A058FA
		// (set) Token: 0x060284F5 RID: 165109 RVA: 0x00A0770E File Offset: 0x00A0590E
		public unsafe string OldValue
		{
			get
			{
				return FString.ToString((void*)(base.NativePtr + (byte*)((IntPtr)SCameraDebugTool_ControllerModification.__PropertyOffset_2)));
			}
			set
			{
				FString.CopyFrom((void*)(base.NativePtr + (byte*)((IntPtr)SCameraDebugTool_ControllerModification.__PropertyOffset_2)), value);
			}
		}

		// Token: 0x170061C1 RID: 25025
		// (get) Token: 0x060284F6 RID: 165110 RVA: 0x00A07723 File Offset: 0x00A05923
		// (set) Token: 0x060284F7 RID: 165111 RVA: 0x00A07737 File Offset: 0x00A05937
		public unsafe string NewValue
		{
			get
			{
				return FString.ToString((void*)(base.NativePtr + (byte*)((IntPtr)SCameraDebugTool_ControllerModification.__PropertyOffset_3)));
			}
			set
			{
				FString.CopyFrom((void*)(base.NativePtr + (byte*)((IntPtr)SCameraDebugTool_ControllerModification.__PropertyOffset_3)), value);
			}
		}

		// Token: 0x060284F8 RID: 165112 RVA: 0x00A0774C File Offset: 0x00A0594C
		public SCameraDebugTool_ControllerModification()
		{
		}

		// Token: 0x060284F9 RID: 165113 RVA: 0x00A07754 File Offset: 0x00A05954
		public SCameraDebugTool_ControllerModification(string ControllerName, string PropertyName, string OldValue, string NewValue)
		{
			this.ControllerName = ControllerName;
			this.PropertyName = PropertyName;
			this.OldValue = OldValue;
			this.NewValue = NewValue;
		}

		// Token: 0x060284FA RID: 165114 RVA: 0x00A07779 File Offset: 0x00A05979
		protected override IntPtr GetUStructPtr()
		{
			return SCameraDebugTool_ControllerModification.StaticStruct();
		}

		// Token: 0x060284FB RID: 165115 RVA: 0x00A07785 File Offset: 0x00A05985
		[NullableContext(2)]
		public SCameraDebugTool_ControllerModification(IntPtr NativePtr, UnrealObject MemoryOwner) : base(NativePtr, MemoryOwner)
		{
		}

		// Token: 0x060284FC RID: 165116 RVA: 0x00A0778F File Offset: 0x00A0598F
		public SCameraDebugTool_ControllerModification(IntPtr NativePtr, bool bWithMoveAssign, bool bWithCopyAssignIfCannotMove) : base(NativePtr, bWithMoveAssign, bWithCopyAssignIfCannotMove)
		{
		}

		// Token: 0x060284FD RID: 165117 RVA: 0x00A0779A File Offset: 0x00A0599A
		public static IUnrealScriptStructProxy CreateFromPointer(IntPtr Pointer)
		{
			return new SCameraDebugTool_ControllerModification(Pointer, false, true);
		}

		// Token: 0x060284FE RID: 165118 RVA: 0x00A077A4 File Offset: 0x00A059A4
		public static IUnrealScriptStructProxy CreateReferenceFromPointer(IntPtr Pointer, UnrealObject MemoryOwner)
		{
			return new SCameraDebugTool_ControllerModification(Pointer, MemoryOwner);
		}

		// Token: 0x04015337 RID: 86839
		public const string __ObjectPath = "/Game/Aki/Data/Camera/CameraDebugTool/SCameraDebugTool_ControllerModification.SCameraDebugTool_ControllerModification";

		// Token: 0x04015338 RID: 86840
		private static IntPtr _ScriptStructPtr;

		// Token: 0x04015339 RID: 86841
		internal static int __PropertyOffset_0;

		// Token: 0x0401533A RID: 86842
		internal static int __PropertyOffset_1;

		// Token: 0x0401533B RID: 86843
		internal static int __PropertyOffset_2;

		// Token: 0x0401533C RID: 86844
		internal static int __PropertyOffset_3;
	}
}
