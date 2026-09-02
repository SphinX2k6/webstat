using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;

namespace AkiClient.Game.Aki.Character.BaseCharacter.Camera.MovieCamera
{
	// Token: 0x02004328 RID: 17192
	[HasGetTypeHash]
	[UnrealObjectPath("/Game/Aki/Character/BaseCharacter/Camera/MovieCamera/SMovieCameraConfigItem_FightSubCameraSetting.SMovieCameraConfigItem_FightSubCameraSetting")]
	[UnrealStructLayout(16, 4, UnrealReflectionPropertyTypeCode.UnrealScriptStructProxy, PropertiesSize = 16)]
	public class SMovieCameraConfigItem_FightSubCameraSetting : UnrealUserDefinedStructProxy, IUnrealScriptStructProxy, IUnrealScriptStruct, IUnrealObject
	{
		// Token: 0x0602D9A1 RID: 186785 RVA: 0x00AC459A File Offset: 0x00AC279A
		public static UScriptStructStackOnlyPtr StaticStruct()
		{
			return (SMovieCameraConfigItem_FightSubCameraSetting._ScriptStructPtr != 0) ? SMovieCameraConfigItem_FightSubCameraSetting._ScriptStructPtr : UObjectGlobals.StaticLoadScriptStruct("/Game/Aki/Character/BaseCharacter/Camera/MovieCamera/SMovieCameraConfigItem_FightSubCameraSetting.SMovieCameraConfigItem_FightSubCameraSetting", ref SMovieCameraConfigItem_FightSubCameraSetting._ScriptStructPtr);
		}

		// Token: 0x17007CFB RID: 31995
		// (get) Token: 0x0602D9A2 RID: 186786 RVA: 0x00AC45BE File Offset: 0x00AC27BE
		// (set) Token: 0x0602D9A3 RID: 186787 RVA: 0x00AC45D2 File Offset: 0x00AC27D2
		public unsafe FGameplayTag FightSubCameraTag
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SMovieCameraConfigItem_FightSubCameraSetting.__PropertyOffset_0);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SMovieCameraConfigItem_FightSubCameraSetting.__PropertyOffset_0) = value;
			}
		}

		// Token: 0x17007CFC RID: 31996
		// (get) Token: 0x0602D9A4 RID: 186788 RVA: 0x00AC45E7 File Offset: 0x00AC27E7
		// (set) Token: 0x0602D9A5 RID: 186789 RVA: 0x00AC45F7 File Offset: 0x00AC27F7
		public unsafe float TimeLength
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SMovieCameraConfigItem_FightSubCameraSetting.__PropertyOffset_1);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SMovieCameraConfigItem_FightSubCameraSetting.__PropertyOffset_1) = value;
			}
		}

		// Token: 0x0602D9A6 RID: 186790 RVA: 0x00AC4608 File Offset: 0x00AC2808
		public SMovieCameraConfigItem_FightSubCameraSetting()
		{
		}

		// Token: 0x0602D9A7 RID: 186791 RVA: 0x00AC4610 File Offset: 0x00AC2810
		public SMovieCameraConfigItem_FightSubCameraSetting(FGameplayTag FightSubCameraTag, float TimeLength)
		{
			this.FightSubCameraTag = FightSubCameraTag;
			this.TimeLength = TimeLength;
		}

		// Token: 0x0602D9A8 RID: 186792 RVA: 0x00AC4626 File Offset: 0x00AC2826
		protected override IntPtr GetUStructPtr()
		{
			return SMovieCameraConfigItem_FightSubCameraSetting.StaticStruct();
		}

		// Token: 0x0602D9A9 RID: 186793 RVA: 0x00AC4632 File Offset: 0x00AC2832
		[NullableContext(2)]
		public SMovieCameraConfigItem_FightSubCameraSetting(IntPtr NativePtr, UnrealObject MemoryOwner) : base(NativePtr, MemoryOwner)
		{
		}

		// Token: 0x0602D9AA RID: 186794 RVA: 0x00AC463C File Offset: 0x00AC283C
		public SMovieCameraConfigItem_FightSubCameraSetting(IntPtr NativePtr, bool bWithMoveAssign, bool bWithCopyAssignIfCannotMove) : base(NativePtr, bWithMoveAssign, bWithCopyAssignIfCannotMove)
		{
		}

		// Token: 0x0602D9AB RID: 186795 RVA: 0x00AC4647 File Offset: 0x00AC2847
		[NullableContext(1)]
		public static IUnrealScriptStructProxy CreateFromPointer(IntPtr Pointer)
		{
			return new SMovieCameraConfigItem_FightSubCameraSetting(Pointer, false, true);
		}

		// Token: 0x0602D9AC RID: 186796 RVA: 0x00AC4651 File Offset: 0x00AC2851
		[NullableContext(1)]
		public static IUnrealScriptStructProxy CreateReferenceFromPointer(IntPtr Pointer, UnrealObject MemoryOwner)
		{
			return new SMovieCameraConfigItem_FightSubCameraSetting(Pointer, MemoryOwner);
		}

		// Token: 0x04019B63 RID: 105315
		[Nullable(1)]
		public const string __ObjectPath = "/Game/Aki/Character/BaseCharacter/Camera/MovieCamera/SMovieCameraConfigItem_FightSubCameraSetting.SMovieCameraConfigItem_FightSubCameraSetting";

		// Token: 0x04019B64 RID: 105316
		private static IntPtr _ScriptStructPtr;

		// Token: 0x04019B65 RID: 105317
		internal static int __PropertyOffset_0;

		// Token: 0x04019B66 RID: 105318
		internal static int __PropertyOffset_1;
	}
}
