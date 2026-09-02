using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Character.BaseCharacter.Camera.MovieCamera
{
	// Token: 0x02004329 RID: 17193
	[NullableContext(1)]
	[Nullable(0)]
	[HasGetTypeHash]
	[UnrealObjectPath("/Game/Aki/Character/BaseCharacter/Camera/MovieCamera/SMovieCameraConfigItem_SequenceSetting.SMovieCameraConfigItem_SequenceSetting")]
	[UnrealStructLayout(208, 8, UnrealReflectionPropertyTypeCode.UnrealScriptStructProxy, PropertiesSize = 208)]
	public class SMovieCameraConfigItem_SequenceSetting : UnrealUserDefinedStructProxy, IUnrealScriptStructProxy, IUnrealScriptStruct, IUnrealObject
	{
		// Token: 0x0602D9AD RID: 186797 RVA: 0x00AC465A File Offset: 0x00AC285A
		public static UScriptStructStackOnlyPtr StaticStruct()
		{
			return (SMovieCameraConfigItem_SequenceSetting._ScriptStructPtr != 0) ? SMovieCameraConfigItem_SequenceSetting._ScriptStructPtr : UObjectGlobals.StaticLoadScriptStruct("/Game/Aki/Character/BaseCharacter/Camera/MovieCamera/SMovieCameraConfigItem_SequenceSetting.SMovieCameraConfigItem_SequenceSetting", ref SMovieCameraConfigItem_SequenceSetting._ScriptStructPtr);
		}

		// Token: 0x17007CFD RID: 31997
		// (get) Token: 0x0602D9AE RID: 186798 RVA: 0x00AC467E File Offset: 0x00AC287E
		// (set) Token: 0x0602D9AF RID: 186799 RVA: 0x00AC469D File Offset: 0x00AC289D
		public TSoftObjectPtr<ULevelSequence> SequenceAsset
		{
			get
			{
				return new TSoftObjectPtr<ULevelSequence>(base.NativePtr + (IntPtr)SMovieCameraConfigItem_SequenceSetting.__PropertyOffset_0, base.MemoryOwner ?? this);
			}
			set
			{
				FSoftObjectPtr.NativeCopy(base.NativePtr + (IntPtr)SMovieCameraConfigItem_SequenceSetting.__PropertyOffset_0, (value != null) ? value.NativePtr : IntPtr.Zero, 1);
			}
		}

		// Token: 0x17007CFE RID: 31998
		// (get) Token: 0x0602D9B0 RID: 186800 RVA: 0x00AC46C2 File Offset: 0x00AC28C2
		// (set) Token: 0x0602D9B1 RID: 186801 RVA: 0x00AC46D2 File Offset: 0x00AC28D2
		public unsafe float BlendInTime
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SMovieCameraConfigItem_SequenceSetting.__PropertyOffset_1);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SMovieCameraConfigItem_SequenceSetting.__PropertyOffset_1) = value;
			}
		}

		// Token: 0x17007CFF RID: 31999
		// (get) Token: 0x0602D9B2 RID: 186802 RVA: 0x00AC46E3 File Offset: 0x00AC28E3
		// (set) Token: 0x0602D9B3 RID: 186803 RVA: 0x00AC46F3 File Offset: 0x00AC28F3
		public unsafe float BlendOutTime
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SMovieCameraConfigItem_SequenceSetting.__PropertyOffset_2);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SMovieCameraConfigItem_SequenceSetting.__PropertyOffset_2) = value;
			}
		}

		// Token: 0x17007D00 RID: 32000
		// (get) Token: 0x0602D9B4 RID: 186804 RVA: 0x00AC4704 File Offset: 0x00AC2904
		// (set) Token: 0x0602D9B5 RID: 186805 RVA: 0x00AC4747 File Offset: 0x00AC2947
		public SMovieCameraConfigItem_SequenceSetting_BindTarget BindTargetSetting
		{
			get
			{
				base.FastCheckIsValid();
				SMovieCameraConfigItem_SequenceSetting_BindTarget result;
				if ((result = this._BindTargetSetting) == null)
				{
					result = (this._BindTargetSetting = new SMovieCameraConfigItem_SequenceSetting_BindTarget(base.NativePtr + (IntPtr)SMovieCameraConfigItem_SequenceSetting.__PropertyOffset_3, base.MemoryOwner ?? this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(SMovieCameraConfigItem_SequenceSetting_BindTarget.StaticStruct(), base.NativePtr + (IntPtr)SMovieCameraConfigItem_SequenceSetting.__PropertyOffset_3, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17007D01 RID: 32001
		// (get) Token: 0x0602D9B6 RID: 186806 RVA: 0x00AC4768 File Offset: 0x00AC2968
		// (set) Token: 0x0602D9B7 RID: 186807 RVA: 0x00AC47AB File Offset: 0x00AC29AB
		public SMovieCameraConfigItem_SequenceSetting_FollowTarget FollowTargetSetting
		{
			get
			{
				base.FastCheckIsValid();
				SMovieCameraConfigItem_SequenceSetting_FollowTarget result;
				if ((result = this._FollowTargetSetting) == null)
				{
					result = (this._FollowTargetSetting = new SMovieCameraConfigItem_SequenceSetting_FollowTarget(base.NativePtr + (IntPtr)SMovieCameraConfigItem_SequenceSetting.__PropertyOffset_4, base.MemoryOwner ?? this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(SMovieCameraConfigItem_SequenceSetting_FollowTarget.StaticStruct(), base.NativePtr + (IntPtr)SMovieCameraConfigItem_SequenceSetting.__PropertyOffset_4, value.NativePtr, 1, false);
			}
		}

		// Token: 0x0602D9B8 RID: 186808 RVA: 0x00AC47CC File Offset: 0x00AC29CC
		public SMovieCameraConfigItem_SequenceSetting()
		{
		}

		// Token: 0x0602D9B9 RID: 186809 RVA: 0x00AC47D4 File Offset: 0x00AC29D4
		public SMovieCameraConfigItem_SequenceSetting(TSoftObjectPtr<ULevelSequence> SequenceAsset, float BlendInTime, float BlendOutTime, SMovieCameraConfigItem_SequenceSetting_BindTarget BindTargetSetting, SMovieCameraConfigItem_SequenceSetting_FollowTarget FollowTargetSetting)
		{
			this.SequenceAsset = SequenceAsset;
			this.BlendInTime = BlendInTime;
			this.BlendOutTime = BlendOutTime;
			this.BindTargetSetting = BindTargetSetting;
			this.FollowTargetSetting = FollowTargetSetting;
		}

		// Token: 0x0602D9BA RID: 186810 RVA: 0x00AC4801 File Offset: 0x00AC2A01
		protected override IntPtr GetUStructPtr()
		{
			return SMovieCameraConfigItem_SequenceSetting.StaticStruct();
		}

		// Token: 0x0602D9BB RID: 186811 RVA: 0x00AC480D File Offset: 0x00AC2A0D
		[NullableContext(2)]
		public SMovieCameraConfigItem_SequenceSetting(IntPtr NativePtr, UnrealObject MemoryOwner) : base(NativePtr, MemoryOwner)
		{
		}

		// Token: 0x0602D9BC RID: 186812 RVA: 0x00AC4817 File Offset: 0x00AC2A17
		public SMovieCameraConfigItem_SequenceSetting(IntPtr NativePtr, bool bWithMoveAssign, bool bWithCopyAssignIfCannotMove) : base(NativePtr, bWithMoveAssign, bWithCopyAssignIfCannotMove)
		{
		}

		// Token: 0x0602D9BD RID: 186813 RVA: 0x00AC4822 File Offset: 0x00AC2A22
		public static IUnrealScriptStructProxy CreateFromPointer(IntPtr Pointer)
		{
			return new SMovieCameraConfigItem_SequenceSetting(Pointer, false, true);
		}

		// Token: 0x0602D9BE RID: 186814 RVA: 0x00AC482C File Offset: 0x00AC2A2C
		public static IUnrealScriptStructProxy CreateReferenceFromPointer(IntPtr Pointer, UnrealObject MemoryOwner)
		{
			return new SMovieCameraConfigItem_SequenceSetting(Pointer, MemoryOwner);
		}

		// Token: 0x04019B67 RID: 105319
		public const string __ObjectPath = "/Game/Aki/Character/BaseCharacter/Camera/MovieCamera/SMovieCameraConfigItem_SequenceSetting.SMovieCameraConfigItem_SequenceSetting";

		// Token: 0x04019B68 RID: 105320
		private static IntPtr _ScriptStructPtr;

		// Token: 0x04019B69 RID: 105321
		internal static int __PropertyOffset_0;

		// Token: 0x04019B6A RID: 105322
		internal static int __PropertyOffset_1;

		// Token: 0x04019B6B RID: 105323
		internal static int __PropertyOffset_2;

		// Token: 0x04019B6C RID: 105324
		internal static int __PropertyOffset_3;

		// Token: 0x04019B6D RID: 105325
		[Nullable(2)]
		private SMovieCameraConfigItem_SequenceSetting_BindTarget _BindTargetSetting;

		// Token: 0x04019B6E RID: 105326
		internal static int __PropertyOffset_4;

		// Token: 0x04019B6F RID: 105327
		[Nullable(2)]
		private SMovieCameraConfigItem_SequenceSetting_FollowTarget _FollowTargetSetting;
	}
}
