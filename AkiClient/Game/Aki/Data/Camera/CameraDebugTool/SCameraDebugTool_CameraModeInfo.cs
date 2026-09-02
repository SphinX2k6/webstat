using System;
using System.Runtime.CompilerServices;
using AkiClient.Game.Aki.Character.BaseCharacter;
using AkiClient.Game.Aki.Character.BaseCharacter.Camera;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;

namespace AkiClient.Game.Aki.Data.Camera.CameraDebugTool
{
	// Token: 0x02003F18 RID: 16152
	[UnrealObjectPath("/Game/Aki/Data/Camera/CameraDebugTool/SCameraDebugTool_CameraModeInfo.SCameraDebugTool_CameraModeInfo")]
	[UnrealStructLayout(136, 8, UnrealReflectionPropertyTypeCode.UnrealScriptStructProxy, PropertiesSize = 132)]
	public class SCameraDebugTool_CameraModeInfo : UnrealUserDefinedStructProxy, IUnrealScriptStructProxy, IUnrealScriptStruct, IUnrealObject
	{
		// Token: 0x060284C9 RID: 165065 RVA: 0x00A0737A File Offset: 0x00A0557A
		public static UScriptStructStackOnlyPtr StaticStruct()
		{
			return (SCameraDebugTool_CameraModeInfo._ScriptStructPtr != 0) ? SCameraDebugTool_CameraModeInfo._ScriptStructPtr : UObjectGlobals.StaticLoadScriptStruct("/Game/Aki/Data/Camera/CameraDebugTool/SCameraDebugTool_CameraModeInfo.SCameraDebugTool_CameraModeInfo", ref SCameraDebugTool_CameraModeInfo._ScriptStructPtr);
		}

		// Token: 0x170061B3 RID: 25011
		// (get) Token: 0x060284CA RID: 165066 RVA: 0x00A0739E File Offset: 0x00A0559E
		// (set) Token: 0x060284CB RID: 165067 RVA: 0x00A073B2 File Offset: 0x00A055B2
		public unsafe TEnumAsByte<ECustomCameraMode> CurrentCameraMode
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SCameraDebugTool_CameraModeInfo.__PropertyOffset_0);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SCameraDebugTool_CameraModeInfo.__PropertyOffset_0) = value;
			}
		}

		// Token: 0x170061B4 RID: 25012
		// (get) Token: 0x060284CC RID: 165068 RVA: 0x00A073C8 File Offset: 0x00A055C8
		// (set) Token: 0x060284CD RID: 165069 RVA: 0x00A0740B File Offset: 0x00A0560B
		[Nullable(1)]
		public TArray<bool> CameraModeEnabledArray
		{
			[NullableContext(1)]
			get
			{
				base.FastCheckIsValid();
				TArray<bool> result;
				if ((result = this._CameraModeEnabledArray) == null)
				{
					result = (this._CameraModeEnabledArray = new TArray<bool>(base.NativePtr + (IntPtr)SCameraDebugTool_CameraModeInfo.__PropertyOffset_1, base.MemoryOwner ?? this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				this.CameraModeEnabledArray.CopyAssign(value);
			}
		}

		// Token: 0x170061B5 RID: 25013
		// (get) Token: 0x060284CE RID: 165070 RVA: 0x00A07419 File Offset: 0x00A05619
		// (set) Token: 0x060284CF RID: 165071 RVA: 0x00A0742D File Offset: 0x00A0562D
		public unsafe TEnumAsByte<ECameraGravityMode> CurrentCameraGravityMode
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SCameraDebugTool_CameraModeInfo.__PropertyOffset_2);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SCameraDebugTool_CameraModeInfo.__PropertyOffset_2) = value;
			}
		}

		// Token: 0x170061B6 RID: 25014
		// (get) Token: 0x060284D0 RID: 165072 RVA: 0x00A07442 File Offset: 0x00A05642
		// (set) Token: 0x060284D1 RID: 165073 RVA: 0x00A07456 File Offset: 0x00A05656
		public unsafe FVectorDouble CameraGravityDirect
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SCameraDebugTool_CameraModeInfo.__PropertyOffset_3);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SCameraDebugTool_CameraModeInfo.__PropertyOffset_3) = value;
			}
		}

		// Token: 0x170061B7 RID: 25015
		// (get) Token: 0x060284D2 RID: 165074 RVA: 0x00A0746B File Offset: 0x00A0566B
		// (set) Token: 0x060284D3 RID: 165075 RVA: 0x00A0747F File Offset: 0x00A0567F
		public unsafe FVectorDouble PlayerGravityDirect
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SCameraDebugTool_CameraModeInfo.__PropertyOffset_4);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SCameraDebugTool_CameraModeInfo.__PropertyOffset_4) = value;
			}
		}

		// Token: 0x170061B8 RID: 25016
		// (get) Token: 0x060284D4 RID: 165076 RVA: 0x00A07494 File Offset: 0x00A05694
		// (set) Token: 0x060284D5 RID: 165077 RVA: 0x00A074A8 File Offset: 0x00A056A8
		public unsafe FRotator CameraRotationInGravity
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SCameraDebugTool_CameraModeInfo.__PropertyOffset_5);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SCameraDebugTool_CameraModeInfo.__PropertyOffset_5) = value;
			}
		}

		// Token: 0x170061B9 RID: 25017
		// (get) Token: 0x060284D6 RID: 165078 RVA: 0x00A074BD File Offset: 0x00A056BD
		// (set) Token: 0x060284D7 RID: 165079 RVA: 0x00A074D1 File Offset: 0x00A056D1
		public unsafe FVectorDouble PlayerLocationInGravity
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SCameraDebugTool_CameraModeInfo.__PropertyOffset_6);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SCameraDebugTool_CameraModeInfo.__PropertyOffset_6) = value;
			}
		}

		// Token: 0x170061BA RID: 25018
		// (get) Token: 0x060284D8 RID: 165080 RVA: 0x00A074E6 File Offset: 0x00A056E6
		// (set) Token: 0x060284D9 RID: 165081 RVA: 0x00A074FA File Offset: 0x00A056FA
		public unsafe FRotator PlayerRotatorInGravity
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SCameraDebugTool_CameraModeInfo.__PropertyOffset_7);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SCameraDebugTool_CameraModeInfo.__PropertyOffset_7) = value;
			}
		}

		// Token: 0x060284DA RID: 165082 RVA: 0x00A0750F File Offset: 0x00A0570F
		public SCameraDebugTool_CameraModeInfo()
		{
		}

		// Token: 0x060284DB RID: 165083 RVA: 0x00A07518 File Offset: 0x00A05718
		public SCameraDebugTool_CameraModeInfo(TEnumAsByte<ECustomCameraMode> CurrentCameraMode, [Nullable(1)] TArray<bool> CameraModeEnabledArray, TEnumAsByte<ECameraGravityMode> CurrentCameraGravityMode, FVectorDouble CameraGravityDirect, FVectorDouble PlayerGravityDirect, FRotator CameraRotationInGravity, FVectorDouble PlayerLocationInGravity, FRotator PlayerRotatorInGravity)
		{
			this.CurrentCameraMode = CurrentCameraMode;
			this.CameraModeEnabledArray = CameraModeEnabledArray;
			this.CurrentCameraGravityMode = CurrentCameraGravityMode;
			this.CameraGravityDirect = CameraGravityDirect;
			this.PlayerGravityDirect = PlayerGravityDirect;
			this.CameraRotationInGravity = CameraRotationInGravity;
			this.PlayerLocationInGravity = PlayerLocationInGravity;
			this.PlayerRotatorInGravity = PlayerRotatorInGravity;
		}

		// Token: 0x060284DC RID: 165084 RVA: 0x00A07568 File Offset: 0x00A05768
		protected override IntPtr GetUStructPtr()
		{
			return SCameraDebugTool_CameraModeInfo.StaticStruct();
		}

		// Token: 0x060284DD RID: 165085 RVA: 0x00A07574 File Offset: 0x00A05774
		[NullableContext(2)]
		public SCameraDebugTool_CameraModeInfo(IntPtr NativePtr, UnrealObject MemoryOwner) : base(NativePtr, MemoryOwner)
		{
		}

		// Token: 0x060284DE RID: 165086 RVA: 0x00A0757E File Offset: 0x00A0577E
		public SCameraDebugTool_CameraModeInfo(IntPtr NativePtr, bool bWithMoveAssign, bool bWithCopyAssignIfCannotMove) : base(NativePtr, bWithMoveAssign, bWithCopyAssignIfCannotMove)
		{
		}

		// Token: 0x060284DF RID: 165087 RVA: 0x00A07589 File Offset: 0x00A05789
		[NullableContext(1)]
		public static IUnrealScriptStructProxy CreateFromPointer(IntPtr Pointer)
		{
			return new SCameraDebugTool_CameraModeInfo(Pointer, false, true);
		}

		// Token: 0x060284E0 RID: 165088 RVA: 0x00A07593 File Offset: 0x00A05793
		[NullableContext(1)]
		public static IUnrealScriptStructProxy CreateReferenceFromPointer(IntPtr Pointer, UnrealObject MemoryOwner)
		{
			return new SCameraDebugTool_CameraModeInfo(Pointer, MemoryOwner);
		}

		// Token: 0x04015327 RID: 86823
		[Nullable(1)]
		public const string __ObjectPath = "/Game/Aki/Data/Camera/CameraDebugTool/SCameraDebugTool_CameraModeInfo.SCameraDebugTool_CameraModeInfo";

		// Token: 0x04015328 RID: 86824
		private static IntPtr _ScriptStructPtr;

		// Token: 0x04015329 RID: 86825
		internal static int __PropertyOffset_0;

		// Token: 0x0401532A RID: 86826
		internal static int __PropertyOffset_1;

		// Token: 0x0401532B RID: 86827
		[Nullable(2)]
		private TArray<bool> _CameraModeEnabledArray;

		// Token: 0x0401532C RID: 86828
		internal static int __PropertyOffset_2;

		// Token: 0x0401532D RID: 86829
		internal static int __PropertyOffset_3;

		// Token: 0x0401532E RID: 86830
		internal static int __PropertyOffset_4;

		// Token: 0x0401532F RID: 86831
		internal static int __PropertyOffset_5;

		// Token: 0x04015330 RID: 86832
		internal static int __PropertyOffset_6;

		// Token: 0x04015331 RID: 86833
		internal static int __PropertyOffset_7;
	}
}
