using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;

namespace AkiClient.Game.Aki.Data.Camera.CameraDebugTool
{
	// Token: 0x02003F17 RID: 16151
	[NullableContext(1)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Data/Camera/CameraDebugTool/SCameraDebugTool_CameraFrameInfoRegion.SCameraDebugTool_CameraFrameInfoRegion")]
	[UnrealStructLayout(32, 8, UnrealReflectionPropertyTypeCode.UnrealScriptStructProxy, PropertiesSize = 32)]
	public class SCameraDebugTool_CameraFrameInfoRegion : UnrealUserDefinedStructProxy, IUnrealScriptStructProxy, IUnrealScriptStruct, IUnrealObject
	{
		// Token: 0x060284BB RID: 165051 RVA: 0x00A07269 File Offset: 0x00A05469
		public static UScriptStructStackOnlyPtr StaticStruct()
		{
			return (SCameraDebugTool_CameraFrameInfoRegion._ScriptStructPtr != 0) ? SCameraDebugTool_CameraFrameInfoRegion._ScriptStructPtr : UObjectGlobals.StaticLoadScriptStruct("/Game/Aki/Data/Camera/CameraDebugTool/SCameraDebugTool_CameraFrameInfoRegion.SCameraDebugTool_CameraFrameInfoRegion", ref SCameraDebugTool_CameraFrameInfoRegion._ScriptStructPtr);
		}

		// Token: 0x170061B0 RID: 25008
		// (get) Token: 0x060284BC RID: 165052 RVA: 0x00A0728D File Offset: 0x00A0548D
		// (set) Token: 0x060284BD RID: 165053 RVA: 0x00A0729D File Offset: 0x00A0549D
		public unsafe long StartFrame
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SCameraDebugTool_CameraFrameInfoRegion.__PropertyOffset_0);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SCameraDebugTool_CameraFrameInfoRegion.__PropertyOffset_0) = value;
			}
		}

		// Token: 0x170061B1 RID: 25009
		// (get) Token: 0x060284BE RID: 165054 RVA: 0x00A072AE File Offset: 0x00A054AE
		// (set) Token: 0x060284BF RID: 165055 RVA: 0x00A072BE File Offset: 0x00A054BE
		public unsafe long EndFrame
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SCameraDebugTool_CameraFrameInfoRegion.__PropertyOffset_1);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SCameraDebugTool_CameraFrameInfoRegion.__PropertyOffset_1) = value;
			}
		}

		// Token: 0x170061B2 RID: 25010
		// (get) Token: 0x060284C0 RID: 165056 RVA: 0x00A072D0 File Offset: 0x00A054D0
		// (set) Token: 0x060284C1 RID: 165057 RVA: 0x00A07313 File Offset: 0x00A05513
		public TArray<SCameraDebugTool_CameraFrameInfo> CameraFrameInfoArray
		{
			get
			{
				base.FastCheckIsValid();
				TArray<SCameraDebugTool_CameraFrameInfo> result;
				if ((result = this._CameraFrameInfoArray) == null)
				{
					result = (this._CameraFrameInfoArray = new TArray<SCameraDebugTool_CameraFrameInfo>(base.NativePtr + (IntPtr)SCameraDebugTool_CameraFrameInfoRegion.__PropertyOffset_2, base.MemoryOwner ?? this));
				}
				return result;
			}
			set
			{
				this.CameraFrameInfoArray.CopyAssign(value);
			}
		}

		// Token: 0x060284C2 RID: 165058 RVA: 0x00A07321 File Offset: 0x00A05521
		public SCameraDebugTool_CameraFrameInfoRegion()
		{
		}

		// Token: 0x060284C3 RID: 165059 RVA: 0x00A07329 File Offset: 0x00A05529
		public SCameraDebugTool_CameraFrameInfoRegion(long StartFrame, long EndFrame, TArray<SCameraDebugTool_CameraFrameInfo> CameraFrameInfoArray)
		{
			this.StartFrame = StartFrame;
			this.EndFrame = EndFrame;
			this.CameraFrameInfoArray = CameraFrameInfoArray;
		}

		// Token: 0x060284C4 RID: 165060 RVA: 0x00A07346 File Offset: 0x00A05546
		protected override IntPtr GetUStructPtr()
		{
			return SCameraDebugTool_CameraFrameInfoRegion.StaticStruct();
		}

		// Token: 0x060284C5 RID: 165061 RVA: 0x00A07352 File Offset: 0x00A05552
		[NullableContext(2)]
		public SCameraDebugTool_CameraFrameInfoRegion(IntPtr NativePtr, UnrealObject MemoryOwner) : base(NativePtr, MemoryOwner)
		{
		}

		// Token: 0x060284C6 RID: 165062 RVA: 0x00A0735C File Offset: 0x00A0555C
		public SCameraDebugTool_CameraFrameInfoRegion(IntPtr NativePtr, bool bWithMoveAssign, bool bWithCopyAssignIfCannotMove) : base(NativePtr, bWithMoveAssign, bWithCopyAssignIfCannotMove)
		{
		}

		// Token: 0x060284C7 RID: 165063 RVA: 0x00A07367 File Offset: 0x00A05567
		public static IUnrealScriptStructProxy CreateFromPointer(IntPtr Pointer)
		{
			return new SCameraDebugTool_CameraFrameInfoRegion(Pointer, false, true);
		}

		// Token: 0x060284C8 RID: 165064 RVA: 0x00A07371 File Offset: 0x00A05571
		public static IUnrealScriptStructProxy CreateReferenceFromPointer(IntPtr Pointer, UnrealObject MemoryOwner)
		{
			return new SCameraDebugTool_CameraFrameInfoRegion(Pointer, MemoryOwner);
		}

		// Token: 0x04015321 RID: 86817
		public const string __ObjectPath = "/Game/Aki/Data/Camera/CameraDebugTool/SCameraDebugTool_CameraFrameInfoRegion.SCameraDebugTool_CameraFrameInfoRegion";

		// Token: 0x04015322 RID: 86818
		private static IntPtr _ScriptStructPtr;

		// Token: 0x04015323 RID: 86819
		internal static int __PropertyOffset_0;

		// Token: 0x04015324 RID: 86820
		internal static int __PropertyOffset_1;

		// Token: 0x04015325 RID: 86821
		internal static int __PropertyOffset_2;

		// Token: 0x04015326 RID: 86822
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private TArray<SCameraDebugTool_CameraFrameInfo> _CameraFrameInfoArray;
	}
}
