using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Data.Camera.CameraDebugTool
{
	// Token: 0x02003F16 RID: 16150
	[NullableContext(1)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Data/Camera/CameraDebugTool/SCameraDebugTool_CameraFrameInfo.SCameraDebugTool_CameraFrameInfo")]
	[UnrealStructLayout(256, 8, UnrealReflectionPropertyTypeCode.UnrealScriptStructProxy, PropertiesSize = 256)]
	public class SCameraDebugTool_CameraFrameInfo : UnrealUserDefinedStructProxy, IUnrealScriptStructProxy, IUnrealScriptStruct, IUnrealObject
	{
		// Token: 0x060284A9 RID: 165033 RVA: 0x00A07058 File Offset: 0x00A05258
		public static UScriptStructStackOnlyPtr StaticStruct()
		{
			return (SCameraDebugTool_CameraFrameInfo._ScriptStructPtr != 0) ? SCameraDebugTool_CameraFrameInfo._ScriptStructPtr : UObjectGlobals.StaticLoadScriptStruct("/Game/Aki/Data/Camera/CameraDebugTool/SCameraDebugTool_CameraFrameInfo.SCameraDebugTool_CameraFrameInfo", ref SCameraDebugTool_CameraFrameInfo._ScriptStructPtr);
		}

		// Token: 0x170061AB RID: 25003
		// (get) Token: 0x060284AA RID: 165034 RVA: 0x00A0707C File Offset: 0x00A0527C
		// (set) Token: 0x060284AB RID: 165035 RVA: 0x00A0708C File Offset: 0x00A0528C
		public unsafe long FrameNumber
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SCameraDebugTool_CameraFrameInfo.__PropertyOffset_0);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SCameraDebugTool_CameraFrameInfo.__PropertyOffset_0) = value;
			}
		}

		// Token: 0x170061AC RID: 25004
		// (get) Token: 0x060284AC RID: 165036 RVA: 0x00A070A0 File Offset: 0x00A052A0
		// (set) Token: 0x060284AD RID: 165037 RVA: 0x00A070E3 File Offset: 0x00A052E3
		public TMap<string, string> DesiredCameraProps
		{
			get
			{
				base.FastCheckIsValid();
				TMap<string, string> result;
				if ((result = this._DesiredCameraProps) == null)
				{
					result = (this._DesiredCameraProps = new TMap<string, string>(base.NativePtr + (IntPtr)SCameraDebugTool_CameraFrameInfo.__PropertyOffset_1, base.MemoryOwner ?? this));
				}
				return result;
			}
			set
			{
				this.DesiredCameraProps.CopyAssign(value);
			}
		}

		// Token: 0x170061AD RID: 25005
		// (get) Token: 0x060284AE RID: 165038 RVA: 0x00A070F4 File Offset: 0x00A052F4
		// (set) Token: 0x060284AF RID: 165039 RVA: 0x00A07137 File Offset: 0x00A05337
		public TArray<SCameraDebugTool_ControllerModification> ControllerModifications
		{
			get
			{
				base.FastCheckIsValid();
				TArray<SCameraDebugTool_ControllerModification> result;
				if ((result = this._ControllerModifications) == null)
				{
					result = (this._ControllerModifications = new TArray<SCameraDebugTool_ControllerModification>(base.NativePtr + (IntPtr)SCameraDebugTool_CameraFrameInfo.__PropertyOffset_2, base.MemoryOwner ?? this));
				}
				return result;
			}
			set
			{
				this.ControllerModifications.CopyAssign(value);
			}
		}

		// Token: 0x170061AE RID: 25006
		// (get) Token: 0x060284B0 RID: 165040 RVA: 0x00A07148 File Offset: 0x00A05348
		// (set) Token: 0x060284B1 RID: 165041 RVA: 0x00A0718B File Offset: 0x00A0538B
		public TArray<SCameraDebugTool_SubCameraModification> SubCameraModifications
		{
			get
			{
				base.FastCheckIsValid();
				TArray<SCameraDebugTool_SubCameraModification> result;
				if ((result = this._SubCameraModifications) == null)
				{
					result = (this._SubCameraModifications = new TArray<SCameraDebugTool_SubCameraModification>(base.NativePtr + (IntPtr)SCameraDebugTool_CameraFrameInfo.__PropertyOffset_3, base.MemoryOwner ?? this));
				}
				return result;
			}
			set
			{
				this.SubCameraModifications.CopyAssign(value);
			}
		}

		// Token: 0x170061AF RID: 25007
		// (get) Token: 0x060284B2 RID: 165042 RVA: 0x00A0719C File Offset: 0x00A0539C
		// (set) Token: 0x060284B3 RID: 165043 RVA: 0x00A071DF File Offset: 0x00A053DF
		public SCameraDebugTool_CameraModeInfo CamerModeInfo
		{
			get
			{
				base.FastCheckIsValid();
				SCameraDebugTool_CameraModeInfo result;
				if ((result = this._CamerModeInfo) == null)
				{
					result = (this._CamerModeInfo = new SCameraDebugTool_CameraModeInfo(base.NativePtr + (IntPtr)SCameraDebugTool_CameraFrameInfo.__PropertyOffset_4, base.MemoryOwner ?? this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(SCameraDebugTool_CameraModeInfo.StaticStruct(), base.NativePtr + (IntPtr)SCameraDebugTool_CameraFrameInfo.__PropertyOffset_4, value.NativePtr, 1, false);
			}
		}

		// Token: 0x060284B4 RID: 165044 RVA: 0x00A07200 File Offset: 0x00A05400
		public SCameraDebugTool_CameraFrameInfo()
		{
		}

		// Token: 0x060284B5 RID: 165045 RVA: 0x00A07208 File Offset: 0x00A05408
		public SCameraDebugTool_CameraFrameInfo(long FrameNumber, TMap<string, string> DesiredCameraProps, TArray<SCameraDebugTool_ControllerModification> ControllerModifications, TArray<SCameraDebugTool_SubCameraModification> SubCameraModifications, SCameraDebugTool_CameraModeInfo CamerModeInfo)
		{
			this.FrameNumber = FrameNumber;
			this.DesiredCameraProps = DesiredCameraProps;
			this.ControllerModifications = ControllerModifications;
			this.SubCameraModifications = SubCameraModifications;
			this.CamerModeInfo = CamerModeInfo;
		}

		// Token: 0x060284B6 RID: 165046 RVA: 0x00A07235 File Offset: 0x00A05435
		protected override IntPtr GetUStructPtr()
		{
			return SCameraDebugTool_CameraFrameInfo.StaticStruct();
		}

		// Token: 0x060284B7 RID: 165047 RVA: 0x00A07241 File Offset: 0x00A05441
		[NullableContext(2)]
		public SCameraDebugTool_CameraFrameInfo(IntPtr NativePtr, UnrealObject MemoryOwner) : base(NativePtr, MemoryOwner)
		{
		}

		// Token: 0x060284B8 RID: 165048 RVA: 0x00A0724B File Offset: 0x00A0544B
		public SCameraDebugTool_CameraFrameInfo(IntPtr NativePtr, bool bWithMoveAssign, bool bWithCopyAssignIfCannotMove) : base(NativePtr, bWithMoveAssign, bWithCopyAssignIfCannotMove)
		{
		}

		// Token: 0x060284B9 RID: 165049 RVA: 0x00A07256 File Offset: 0x00A05456
		public static IUnrealScriptStructProxy CreateFromPointer(IntPtr Pointer)
		{
			return new SCameraDebugTool_CameraFrameInfo(Pointer, false, true);
		}

		// Token: 0x060284BA RID: 165050 RVA: 0x00A07260 File Offset: 0x00A05460
		public static IUnrealScriptStructProxy CreateReferenceFromPointer(IntPtr Pointer, UnrealObject MemoryOwner)
		{
			return new SCameraDebugTool_CameraFrameInfo(Pointer, MemoryOwner);
		}

		// Token: 0x04015316 RID: 86806
		public const string __ObjectPath = "/Game/Aki/Data/Camera/CameraDebugTool/SCameraDebugTool_CameraFrameInfo.SCameraDebugTool_CameraFrameInfo";

		// Token: 0x04015317 RID: 86807
		private static IntPtr _ScriptStructPtr;

		// Token: 0x04015318 RID: 86808
		internal static int __PropertyOffset_0;

		// Token: 0x04015319 RID: 86809
		internal static int __PropertyOffset_1;

		// Token: 0x0401531A RID: 86810
		[Nullable(new byte[]
		{
			2,
			1,
			1
		})]
		private TMap<string, string> _DesiredCameraProps;

		// Token: 0x0401531B RID: 86811
		internal static int __PropertyOffset_2;

		// Token: 0x0401531C RID: 86812
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private TArray<SCameraDebugTool_ControllerModification> _ControllerModifications;

		// Token: 0x0401531D RID: 86813
		internal static int __PropertyOffset_3;

		// Token: 0x0401531E RID: 86814
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private TArray<SCameraDebugTool_SubCameraModification> _SubCameraModifications;

		// Token: 0x0401531F RID: 86815
		internal static int __PropertyOffset_4;

		// Token: 0x04015320 RID: 86816
		[Nullable(2)]
		private SCameraDebugTool_CameraModeInfo _CamerModeInfo;
	}
}
