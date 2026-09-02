using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;

namespace AkiClient.Game.Aki.Character.BaseCharacter.Camera.MovieCamera
{
	// Token: 0x0200432A RID: 17194
	[UnrealObjectPath("/Game/Aki/Character/BaseCharacter/Camera/MovieCamera/SMovieCameraConfigItem_SequenceSetting_BindTarget.SMovieCameraConfigItem_SequenceSetting_BindTarget")]
	[UnrealStructLayout(136, 8, UnrealReflectionPropertyTypeCode.UnrealScriptStructProxy, PropertiesSize = 132)]
	public class SMovieCameraConfigItem_SequenceSetting_BindTarget : UnrealUserDefinedStructProxy, IUnrealScriptStructProxy, IUnrealScriptStruct, IUnrealObject
	{
		// Token: 0x0602D9BF RID: 186815 RVA: 0x00AC4835 File Offset: 0x00AC2A35
		public static UScriptStructStackOnlyPtr StaticStruct()
		{
			return (SMovieCameraConfigItem_SequenceSetting_BindTarget._ScriptStructPtr != 0) ? SMovieCameraConfigItem_SequenceSetting_BindTarget._ScriptStructPtr : UObjectGlobals.StaticLoadScriptStruct("/Game/Aki/Character/BaseCharacter/Camera/MovieCamera/SMovieCameraConfigItem_SequenceSetting_BindTarget.SMovieCameraConfigItem_SequenceSetting_BindTarget", ref SMovieCameraConfigItem_SequenceSetting_BindTarget._ScriptStructPtr);
		}

		// Token: 0x17007D02 RID: 32002
		// (get) Token: 0x0602D9C0 RID: 186816 RVA: 0x00AC4859 File Offset: 0x00AC2A59
		// (set) Token: 0x0602D9C1 RID: 186817 RVA: 0x00AC486D File Offset: 0x00AC2A6D
		public unsafe TEnumAsByte<EMovieCameraSequenceSettingBindTargetType> BindTargetType
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SMovieCameraConfigItem_SequenceSetting_BindTarget.__PropertyOffset_0);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SMovieCameraConfigItem_SequenceSetting_BindTarget.__PropertyOffset_0) = value;
			}
		}

		// Token: 0x17007D03 RID: 32003
		// (get) Token: 0x0602D9C2 RID: 186818 RVA: 0x00AC4882 File Offset: 0x00AC2A82
		// (set) Token: 0x0602D9C3 RID: 186819 RVA: 0x00AC4896 File Offset: 0x00AC2A96
		public unsafe FName AttachSocketName
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SMovieCameraConfigItem_SequenceSetting_BindTarget.__PropertyOffset_1);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SMovieCameraConfigItem_SequenceSetting_BindTarget.__PropertyOffset_1) = value;
			}
		}

		// Token: 0x17007D04 RID: 32004
		// (get) Token: 0x0602D9C4 RID: 186820 RVA: 0x00AC48AB File Offset: 0x00AC2AAB
		// (set) Token: 0x0602D9C5 RID: 186821 RVA: 0x00AC48BF File Offset: 0x00AC2ABF
		public unsafe FVectorDouble AttachLocationOffset
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SMovieCameraConfigItem_SequenceSetting_BindTarget.__PropertyOffset_2);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SMovieCameraConfigItem_SequenceSetting_BindTarget.__PropertyOffset_2) = value;
			}
		}

		// Token: 0x17007D05 RID: 32005
		// (get) Token: 0x0602D9C6 RID: 186822 RVA: 0x00AC48D4 File Offset: 0x00AC2AD4
		// (set) Token: 0x0602D9C7 RID: 186823 RVA: 0x00AC48E8 File Offset: 0x00AC2AE8
		public unsafe FRotator AttachRotatorOffset
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SMovieCameraConfigItem_SequenceSetting_BindTarget.__PropertyOffset_3);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SMovieCameraConfigItem_SequenceSetting_BindTarget.__PropertyOffset_3) = value;
			}
		}

		// Token: 0x17007D06 RID: 32006
		// (get) Token: 0x0602D9C8 RID: 186824 RVA: 0x00AC48FD File Offset: 0x00AC2AFD
		// (set) Token: 0x0602D9C9 RID: 186825 RVA: 0x00AC4911 File Offset: 0x00AC2B11
		public unsafe FVectorDouble SpecificLocationOffset
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SMovieCameraConfigItem_SequenceSetting_BindTarget.__PropertyOffset_4);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SMovieCameraConfigItem_SequenceSetting_BindTarget.__PropertyOffset_4) = value;
			}
		}

		// Token: 0x17007D07 RID: 32007
		// (get) Token: 0x0602D9CA RID: 186826 RVA: 0x00AC4926 File Offset: 0x00AC2B26
		// (set) Token: 0x0602D9CB RID: 186827 RVA: 0x00AC493A File Offset: 0x00AC2B3A
		public unsafe FRotator SpecificRotatorOffset
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SMovieCameraConfigItem_SequenceSetting_BindTarget.__PropertyOffset_5);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SMovieCameraConfigItem_SequenceSetting_BindTarget.__PropertyOffset_5) = value;
			}
		}

		// Token: 0x17007D08 RID: 32008
		// (get) Token: 0x0602D9CC RID: 186828 RVA: 0x00AC494F File Offset: 0x00AC2B4F
		// (set) Token: 0x0602D9CD RID: 186829 RVA: 0x00AC4963 File Offset: 0x00AC2B63
		public unsafe FVectorDouble WorldLocation
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SMovieCameraConfigItem_SequenceSetting_BindTarget.__PropertyOffset_6);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SMovieCameraConfigItem_SequenceSetting_BindTarget.__PropertyOffset_6) = value;
			}
		}

		// Token: 0x17007D09 RID: 32009
		// (get) Token: 0x0602D9CE RID: 186830 RVA: 0x00AC4978 File Offset: 0x00AC2B78
		// (set) Token: 0x0602D9CF RID: 186831 RVA: 0x00AC498C File Offset: 0x00AC2B8C
		public unsafe FRotator WorldRotation
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SMovieCameraConfigItem_SequenceSetting_BindTarget.__PropertyOffset_7);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SMovieCameraConfigItem_SequenceSetting_BindTarget.__PropertyOffset_7) = value;
			}
		}

		// Token: 0x0602D9D0 RID: 186832 RVA: 0x00AC49A1 File Offset: 0x00AC2BA1
		public SMovieCameraConfigItem_SequenceSetting_BindTarget()
		{
		}

		// Token: 0x0602D9D1 RID: 186833 RVA: 0x00AC49AC File Offset: 0x00AC2BAC
		public SMovieCameraConfigItem_SequenceSetting_BindTarget(TEnumAsByte<EMovieCameraSequenceSettingBindTargetType> BindTargetType, FName AttachSocketName, FVectorDouble AttachLocationOffset, FRotator AttachRotatorOffset, FVectorDouble SpecificLocationOffset, FRotator SpecificRotatorOffset, FVectorDouble WorldLocation, FRotator WorldRotation)
		{
			this.BindTargetType = BindTargetType;
			this.AttachSocketName = AttachSocketName;
			this.AttachLocationOffset = AttachLocationOffset;
			this.AttachRotatorOffset = AttachRotatorOffset;
			this.SpecificLocationOffset = SpecificLocationOffset;
			this.SpecificRotatorOffset = SpecificRotatorOffset;
			this.WorldLocation = WorldLocation;
			this.WorldRotation = WorldRotation;
		}

		// Token: 0x0602D9D2 RID: 186834 RVA: 0x00AC49FC File Offset: 0x00AC2BFC
		protected override IntPtr GetUStructPtr()
		{
			return SMovieCameraConfigItem_SequenceSetting_BindTarget.StaticStruct();
		}

		// Token: 0x0602D9D3 RID: 186835 RVA: 0x00AC4A08 File Offset: 0x00AC2C08
		[NullableContext(2)]
		public SMovieCameraConfigItem_SequenceSetting_BindTarget(IntPtr NativePtr, UnrealObject MemoryOwner) : base(NativePtr, MemoryOwner)
		{
		}

		// Token: 0x0602D9D4 RID: 186836 RVA: 0x00AC4A12 File Offset: 0x00AC2C12
		public SMovieCameraConfigItem_SequenceSetting_BindTarget(IntPtr NativePtr, bool bWithMoveAssign, bool bWithCopyAssignIfCannotMove) : base(NativePtr, bWithMoveAssign, bWithCopyAssignIfCannotMove)
		{
		}

		// Token: 0x0602D9D5 RID: 186837 RVA: 0x00AC4A1D File Offset: 0x00AC2C1D
		[NullableContext(1)]
		public static IUnrealScriptStructProxy CreateFromPointer(IntPtr Pointer)
		{
			return new SMovieCameraConfigItem_SequenceSetting_BindTarget(Pointer, false, true);
		}

		// Token: 0x0602D9D6 RID: 186838 RVA: 0x00AC4A27 File Offset: 0x00AC2C27
		[NullableContext(1)]
		public static IUnrealScriptStructProxy CreateReferenceFromPointer(IntPtr Pointer, UnrealObject MemoryOwner)
		{
			return new SMovieCameraConfigItem_SequenceSetting_BindTarget(Pointer, MemoryOwner);
		}

		// Token: 0x04019B70 RID: 105328
		[Nullable(1)]
		public const string __ObjectPath = "/Game/Aki/Character/BaseCharacter/Camera/MovieCamera/SMovieCameraConfigItem_SequenceSetting_BindTarget.SMovieCameraConfigItem_SequenceSetting_BindTarget";

		// Token: 0x04019B71 RID: 105329
		private static IntPtr _ScriptStructPtr;

		// Token: 0x04019B72 RID: 105330
		internal static int __PropertyOffset_0;

		// Token: 0x04019B73 RID: 105331
		internal static int __PropertyOffset_1;

		// Token: 0x04019B74 RID: 105332
		internal static int __PropertyOffset_2;

		// Token: 0x04019B75 RID: 105333
		internal static int __PropertyOffset_3;

		// Token: 0x04019B76 RID: 105334
		internal static int __PropertyOffset_4;

		// Token: 0x04019B77 RID: 105335
		internal static int __PropertyOffset_5;

		// Token: 0x04019B78 RID: 105336
		internal static int __PropertyOffset_6;

		// Token: 0x04019B79 RID: 105337
		internal static int __PropertyOffset_7;
	}
}
