using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;

namespace AkiClient.Game.Aki.Data.Camera.CameraDebugTool
{
	// Token: 0x02003F1B RID: 16155
	[NullableContext(1)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Data/Camera/CameraDebugTool/SCameraDebugTool_SubCameraModification.SCameraDebugTool_SubCameraModification")]
	[UnrealStructLayout(56, 8, UnrealReflectionPropertyTypeCode.UnrealScriptStructProxy, PropertiesSize = 56)]
	public class SCameraDebugTool_SubCameraModification : UnrealUserDefinedStructProxy, IUnrealScriptStructProxy, IUnrealScriptStruct, IUnrealObject
	{
		// Token: 0x060284FF RID: 165119 RVA: 0x00A077AD File Offset: 0x00A059AD
		public static UScriptStructStackOnlyPtr StaticStruct()
		{
			return (SCameraDebugTool_SubCameraModification._ScriptStructPtr != 0) ? SCameraDebugTool_SubCameraModification._ScriptStructPtr : UObjectGlobals.StaticLoadScriptStruct("/Game/Aki/Data/Camera/CameraDebugTool/SCameraDebugTool_SubCameraModification.SCameraDebugTool_SubCameraModification", ref SCameraDebugTool_SubCameraModification._ScriptStructPtr);
		}

		// Token: 0x170061C2 RID: 25026
		// (get) Token: 0x06028500 RID: 165120 RVA: 0x00A077D1 File Offset: 0x00A059D1
		// (set) Token: 0x06028501 RID: 165121 RVA: 0x00A077E5 File Offset: 0x00A059E5
		public unsafe string CameraTag
		{
			get
			{
				return FString.ToString((void*)(base.NativePtr + (byte*)((IntPtr)SCameraDebugTool_SubCameraModification.__PropertyOffset_0)));
			}
			set
			{
				FString.CopyFrom((void*)(base.NativePtr + (byte*)((IntPtr)SCameraDebugTool_SubCameraModification.__PropertyOffset_0)), value);
			}
		}

		// Token: 0x170061C3 RID: 25027
		// (get) Token: 0x06028502 RID: 165122 RVA: 0x00A077FA File Offset: 0x00A059FA
		// (set) Token: 0x06028503 RID: 165123 RVA: 0x00A0780E File Offset: 0x00A05A0E
		public unsafe string CameraType
		{
			get
			{
				return FString.ToString((void*)(base.NativePtr + (byte*)((IntPtr)SCameraDebugTool_SubCameraModification.__PropertyOffset_1)));
			}
			set
			{
				FString.CopyFrom((void*)(base.NativePtr + (byte*)((IntPtr)SCameraDebugTool_SubCameraModification.__PropertyOffset_1)), value);
			}
		}

		// Token: 0x170061C4 RID: 25028
		// (get) Token: 0x06028504 RID: 165124 RVA: 0x00A07823 File Offset: 0x00A05A23
		// (set) Token: 0x06028505 RID: 165125 RVA: 0x00A07833 File Offset: 0x00A05A33
		public unsafe int CameraPriority
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SCameraDebugTool_SubCameraModification.__PropertyOffset_2);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SCameraDebugTool_SubCameraModification.__PropertyOffset_2) = value;
			}
		}

		// Token: 0x170061C5 RID: 25029
		// (get) Token: 0x06028506 RID: 165126 RVA: 0x00A07844 File Offset: 0x00A05A44
		// (set) Token: 0x06028507 RID: 165127 RVA: 0x00A07887 File Offset: 0x00A05A87
		public TArray<SCameraDebugTool_CameraProperty> ModifiedProperties
		{
			get
			{
				base.FastCheckIsValid();
				TArray<SCameraDebugTool_CameraProperty> result;
				if ((result = this._ModifiedProperties) == null)
				{
					result = (this._ModifiedProperties = new TArray<SCameraDebugTool_CameraProperty>(base.NativePtr + (IntPtr)SCameraDebugTool_SubCameraModification.__PropertyOffset_3, base.MemoryOwner ?? this));
				}
				return result;
			}
			set
			{
				this.ModifiedProperties.CopyAssign(value);
			}
		}

		// Token: 0x06028508 RID: 165128 RVA: 0x00A07895 File Offset: 0x00A05A95
		public SCameraDebugTool_SubCameraModification()
		{
		}

		// Token: 0x06028509 RID: 165129 RVA: 0x00A0789D File Offset: 0x00A05A9D
		public SCameraDebugTool_SubCameraModification(string CameraTag, string CameraType, int CameraPriority, TArray<SCameraDebugTool_CameraProperty> ModifiedProperties)
		{
			this.CameraTag = CameraTag;
			this.CameraType = CameraType;
			this.CameraPriority = CameraPriority;
			this.ModifiedProperties = ModifiedProperties;
		}

		// Token: 0x0602850A RID: 165130 RVA: 0x00A078C2 File Offset: 0x00A05AC2
		protected override IntPtr GetUStructPtr()
		{
			return SCameraDebugTool_SubCameraModification.StaticStruct();
		}

		// Token: 0x0602850B RID: 165131 RVA: 0x00A078CE File Offset: 0x00A05ACE
		[NullableContext(2)]
		public SCameraDebugTool_SubCameraModification(IntPtr NativePtr, UnrealObject MemoryOwner) : base(NativePtr, MemoryOwner)
		{
		}

		// Token: 0x0602850C RID: 165132 RVA: 0x00A078D8 File Offset: 0x00A05AD8
		public SCameraDebugTool_SubCameraModification(IntPtr NativePtr, bool bWithMoveAssign, bool bWithCopyAssignIfCannotMove) : base(NativePtr, bWithMoveAssign, bWithCopyAssignIfCannotMove)
		{
		}

		// Token: 0x0602850D RID: 165133 RVA: 0x00A078E3 File Offset: 0x00A05AE3
		public static IUnrealScriptStructProxy CreateFromPointer(IntPtr Pointer)
		{
			return new SCameraDebugTool_SubCameraModification(Pointer, false, true);
		}

		// Token: 0x0602850E RID: 165134 RVA: 0x00A078ED File Offset: 0x00A05AED
		public static IUnrealScriptStructProxy CreateReferenceFromPointer(IntPtr Pointer, UnrealObject MemoryOwner)
		{
			return new SCameraDebugTool_SubCameraModification(Pointer, MemoryOwner);
		}

		// Token: 0x0401533D RID: 86845
		public const string __ObjectPath = "/Game/Aki/Data/Camera/CameraDebugTool/SCameraDebugTool_SubCameraModification.SCameraDebugTool_SubCameraModification";

		// Token: 0x0401533E RID: 86846
		private static IntPtr _ScriptStructPtr;

		// Token: 0x0401533F RID: 86847
		internal static int __PropertyOffset_0;

		// Token: 0x04015340 RID: 86848
		internal static int __PropertyOffset_1;

		// Token: 0x04015341 RID: 86849
		internal static int __PropertyOffset_2;

		// Token: 0x04015342 RID: 86850
		internal static int __PropertyOffset_3;

		// Token: 0x04015343 RID: 86851
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private TArray<SCameraDebugTool_CameraProperty> _ModifiedProperties;
	}
}
