using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;

namespace AkiClient.Game.Aki.Character.BaseCharacter.Camera.MovieCamera
{
	// Token: 0x0200432B RID: 17195
	[HasGetTypeHash]
	[UnrealObjectPath("/Game/Aki/Character/BaseCharacter/Camera/MovieCamera/SMovieCameraConfigItem_SequenceSetting_FollowTarget.SMovieCameraConfigItem_SequenceSetting_FollowTarget")]
	[UnrealStructLayout(16, 4, UnrealReflectionPropertyTypeCode.UnrealScriptStructProxy, PropertiesSize = 16)]
	public class SMovieCameraConfigItem_SequenceSetting_FollowTarget : UnrealUserDefinedStructProxy, IUnrealScriptStructProxy, IUnrealScriptStruct, IUnrealObject
	{
		// Token: 0x0602D9D7 RID: 186839 RVA: 0x00AC4A30 File Offset: 0x00AC2C30
		public static UScriptStructStackOnlyPtr StaticStruct()
		{
			return (SMovieCameraConfigItem_SequenceSetting_FollowTarget._ScriptStructPtr != 0) ? SMovieCameraConfigItem_SequenceSetting_FollowTarget._ScriptStructPtr : UObjectGlobals.StaticLoadScriptStruct("/Game/Aki/Character/BaseCharacter/Camera/MovieCamera/SMovieCameraConfigItem_SequenceSetting_FollowTarget.SMovieCameraConfigItem_SequenceSetting_FollowTarget", ref SMovieCameraConfigItem_SequenceSetting_FollowTarget._ScriptStructPtr);
		}

		// Token: 0x17007D0A RID: 32010
		// (get) Token: 0x0602D9D8 RID: 186840 RVA: 0x00AC4A54 File Offset: 0x00AC2C54
		// (set) Token: 0x0602D9D9 RID: 186841 RVA: 0x00AC4A64 File Offset: 0x00AC2C64
		public unsafe bool IsFollowTarget
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SMovieCameraConfigItem_SequenceSetting_FollowTarget.__PropertyOffset_0) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)SMovieCameraConfigItem_SequenceSetting_FollowTarget.__PropertyOffset_0) = (value ? 1 : 0);
			}
		}

		// Token: 0x17007D0B RID: 32011
		// (get) Token: 0x0602D9DA RID: 186842 RVA: 0x00AC4A75 File Offset: 0x00AC2C75
		// (set) Token: 0x0602D9DB RID: 186843 RVA: 0x00AC4A89 File Offset: 0x00AC2C89
		public unsafe TEnumAsByte<EMovieCameraSequenceSettingFollowTargetType> FollowType
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SMovieCameraConfigItem_SequenceSetting_FollowTarget.__PropertyOffset_1);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SMovieCameraConfigItem_SequenceSetting_FollowTarget.__PropertyOffset_1) = value;
			}
		}

		// Token: 0x17007D0C RID: 32012
		// (get) Token: 0x0602D9DC RID: 186844 RVA: 0x00AC4A9E File Offset: 0x00AC2C9E
		// (set) Token: 0x0602D9DD RID: 186845 RVA: 0x00AC4AAE File Offset: 0x00AC2CAE
		public unsafe float FollowSpeed
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SMovieCameraConfigItem_SequenceSetting_FollowTarget.__PropertyOffset_2);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SMovieCameraConfigItem_SequenceSetting_FollowTarget.__PropertyOffset_2) = value;
			}
		}

		// Token: 0x17007D0D RID: 32013
		// (get) Token: 0x0602D9DE RID: 186846 RVA: 0x00AC4ABF File Offset: 0x00AC2CBF
		// (set) Token: 0x0602D9DF RID: 186847 RVA: 0x00AC4ACF File Offset: 0x00AC2CCF
		public unsafe float PitchFollowSpeed
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SMovieCameraConfigItem_SequenceSetting_FollowTarget.__PropertyOffset_3);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SMovieCameraConfigItem_SequenceSetting_FollowTarget.__PropertyOffset_3) = value;
			}
		}

		// Token: 0x17007D0E RID: 32014
		// (get) Token: 0x0602D9E0 RID: 186848 RVA: 0x00AC4AE0 File Offset: 0x00AC2CE0
		// (set) Token: 0x0602D9E1 RID: 186849 RVA: 0x00AC4AF0 File Offset: 0x00AC2CF0
		public unsafe float AngleFollowSpeed
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SMovieCameraConfigItem_SequenceSetting_FollowTarget.__PropertyOffset_4);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SMovieCameraConfigItem_SequenceSetting_FollowTarget.__PropertyOffset_4) = value;
			}
		}

		// Token: 0x0602D9E2 RID: 186850 RVA: 0x00AC4B01 File Offset: 0x00AC2D01
		public SMovieCameraConfigItem_SequenceSetting_FollowTarget()
		{
		}

		// Token: 0x0602D9E3 RID: 186851 RVA: 0x00AC4B09 File Offset: 0x00AC2D09
		public SMovieCameraConfigItem_SequenceSetting_FollowTarget(bool IsFollowTarget, TEnumAsByte<EMovieCameraSequenceSettingFollowTargetType> FollowType, float FollowSpeed, float PitchFollowSpeed, float AngleFollowSpeed)
		{
			this.IsFollowTarget = IsFollowTarget;
			this.FollowType = FollowType;
			this.FollowSpeed = FollowSpeed;
			this.PitchFollowSpeed = PitchFollowSpeed;
			this.AngleFollowSpeed = AngleFollowSpeed;
		}

		// Token: 0x0602D9E4 RID: 186852 RVA: 0x00AC4B36 File Offset: 0x00AC2D36
		protected override IntPtr GetUStructPtr()
		{
			return SMovieCameraConfigItem_SequenceSetting_FollowTarget.StaticStruct();
		}

		// Token: 0x0602D9E5 RID: 186853 RVA: 0x00AC4B42 File Offset: 0x00AC2D42
		[NullableContext(2)]
		public SMovieCameraConfigItem_SequenceSetting_FollowTarget(IntPtr NativePtr, UnrealObject MemoryOwner) : base(NativePtr, MemoryOwner)
		{
		}

		// Token: 0x0602D9E6 RID: 186854 RVA: 0x00AC4B4C File Offset: 0x00AC2D4C
		public SMovieCameraConfigItem_SequenceSetting_FollowTarget(IntPtr NativePtr, bool bWithMoveAssign, bool bWithCopyAssignIfCannotMove) : base(NativePtr, bWithMoveAssign, bWithCopyAssignIfCannotMove)
		{
		}

		// Token: 0x0602D9E7 RID: 186855 RVA: 0x00AC4B57 File Offset: 0x00AC2D57
		[NullableContext(1)]
		public static IUnrealScriptStructProxy CreateFromPointer(IntPtr Pointer)
		{
			return new SMovieCameraConfigItem_SequenceSetting_FollowTarget(Pointer, false, true);
		}

		// Token: 0x0602D9E8 RID: 186856 RVA: 0x00AC4B61 File Offset: 0x00AC2D61
		[NullableContext(1)]
		public static IUnrealScriptStructProxy CreateReferenceFromPointer(IntPtr Pointer, UnrealObject MemoryOwner)
		{
			return new SMovieCameraConfigItem_SequenceSetting_FollowTarget(Pointer, MemoryOwner);
		}

		// Token: 0x04019B7A RID: 105338
		[Nullable(1)]
		public const string __ObjectPath = "/Game/Aki/Character/BaseCharacter/Camera/MovieCamera/SMovieCameraConfigItem_SequenceSetting_FollowTarget.SMovieCameraConfigItem_SequenceSetting_FollowTarget";

		// Token: 0x04019B7B RID: 105339
		private static IntPtr _ScriptStructPtr;

		// Token: 0x04019B7C RID: 105340
		internal static int __PropertyOffset_0;

		// Token: 0x04019B7D RID: 105341
		internal static int __PropertyOffset_1;

		// Token: 0x04019B7E RID: 105342
		internal static int __PropertyOffset_2;

		// Token: 0x04019B7F RID: 105343
		internal static int __PropertyOffset_3;

		// Token: 0x04019B80 RID: 105344
		internal static int __PropertyOffset_4;
	}
}
