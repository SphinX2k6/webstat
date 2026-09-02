using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Character.BaseCharacter.Camera.MovieCamera
{
	// Token: 0x02004326 RID: 17190
	[NullableContext(1)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Character/BaseCharacter/Camera/MovieCamera/SMovieCameraConfigItem.SMovieCameraConfigItem")]
	[UnrealStructLayout(264, 8, UnrealReflectionPropertyTypeCode.UnrealScriptStructProxy, PropertiesSize = 264)]
	public class SMovieCameraConfigItem : UnrealUserDefinedStructProxy, IUnrealScriptStructProxy, IUnrealScriptStruct, IUnrealObject
	{
		// Token: 0x0602D988 RID: 186760 RVA: 0x00AC4312 File Offset: 0x00AC2512
		public static UScriptStructStackOnlyPtr StaticStruct()
		{
			return (SMovieCameraConfigItem._ScriptStructPtr != 0) ? SMovieCameraConfigItem._ScriptStructPtr : UObjectGlobals.StaticLoadScriptStruct("/Game/Aki/Character/BaseCharacter/Camera/MovieCamera/SMovieCameraConfigItem.SMovieCameraConfigItem", ref SMovieCameraConfigItem._ScriptStructPtr);
		}

		// Token: 0x17007CF6 RID: 31990
		// (get) Token: 0x0602D989 RID: 186761 RVA: 0x00AC4336 File Offset: 0x00AC2536
		// (set) Token: 0x0602D98A RID: 186762 RVA: 0x00AC434A File Offset: 0x00AC254A
		public unsafe string Tip
		{
			get
			{
				return FString.ToString((void*)(base.NativePtr + (byte*)((IntPtr)SMovieCameraConfigItem.__PropertyOffset_0)));
			}
			set
			{
				FString.CopyFrom((void*)(base.NativePtr + (byte*)((IntPtr)SMovieCameraConfigItem.__PropertyOffset_0)), value);
			}
		}

		// Token: 0x17007CF7 RID: 31991
		// (get) Token: 0x0602D98B RID: 186763 RVA: 0x00AC435F File Offset: 0x00AC255F
		// (set) Token: 0x0602D98C RID: 186764 RVA: 0x00AC4373 File Offset: 0x00AC2573
		[Nullable(0)]
		public unsafe TEnumAsByte<EMovieCameraItemType> Type
		{
			[NullableContext(0)]
			get
			{
				return *(base.NativePtr + (IntPtr)SMovieCameraConfigItem.__PropertyOffset_1);
			}
			[NullableContext(0)]
			set
			{
				*(base.NativePtr + (IntPtr)SMovieCameraConfigItem.__PropertyOffset_1) = value;
			}
		}

		// Token: 0x17007CF8 RID: 31992
		// (get) Token: 0x0602D98D RID: 186765 RVA: 0x00AC4388 File Offset: 0x00AC2588
		// (set) Token: 0x0602D98E RID: 186766 RVA: 0x00AC43CB File Offset: 0x00AC25CB
		public TArray<SMovieCameraConfigItem_Condition> ConditionList
		{
			get
			{
				base.FastCheckIsValid();
				TArray<SMovieCameraConfigItem_Condition> result;
				if ((result = this._ConditionList) == null)
				{
					result = (this._ConditionList = new TArray<SMovieCameraConfigItem_Condition>(base.NativePtr + (IntPtr)SMovieCameraConfigItem.__PropertyOffset_2, base.MemoryOwner ?? this));
				}
				return result;
			}
			set
			{
				this.ConditionList.CopyAssign(value);
			}
		}

		// Token: 0x17007CF9 RID: 31993
		// (get) Token: 0x0602D98F RID: 186767 RVA: 0x00AC43DC File Offset: 0x00AC25DC
		// (set) Token: 0x0602D990 RID: 186768 RVA: 0x00AC441F File Offset: 0x00AC261F
		public SMovieCameraConfigItem_FightSubCameraSetting FightSubCameraSetting
		{
			get
			{
				base.FastCheckIsValid();
				SMovieCameraConfigItem_FightSubCameraSetting result;
				if ((result = this._FightSubCameraSetting) == null)
				{
					result = (this._FightSubCameraSetting = new SMovieCameraConfigItem_FightSubCameraSetting(base.NativePtr + (IntPtr)SMovieCameraConfigItem.__PropertyOffset_3, base.MemoryOwner ?? this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(SMovieCameraConfigItem_FightSubCameraSetting.StaticStruct(), base.NativePtr + (IntPtr)SMovieCameraConfigItem.__PropertyOffset_3, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17007CFA RID: 31994
		// (get) Token: 0x0602D991 RID: 186769 RVA: 0x00AC4440 File Offset: 0x00AC2640
		// (set) Token: 0x0602D992 RID: 186770 RVA: 0x00AC4483 File Offset: 0x00AC2683
		public SMovieCameraConfigItem_SequenceSetting SequenceSetting
		{
			get
			{
				base.FastCheckIsValid();
				SMovieCameraConfigItem_SequenceSetting result;
				if ((result = this._SequenceSetting) == null)
				{
					result = (this._SequenceSetting = new SMovieCameraConfigItem_SequenceSetting(base.NativePtr + (IntPtr)SMovieCameraConfigItem.__PropertyOffset_4, base.MemoryOwner ?? this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(SMovieCameraConfigItem_SequenceSetting.StaticStruct(), base.NativePtr + (IntPtr)SMovieCameraConfigItem.__PropertyOffset_4, value.NativePtr, 1, false);
			}
		}

		// Token: 0x0602D993 RID: 186771 RVA: 0x00AC44A4 File Offset: 0x00AC26A4
		public SMovieCameraConfigItem()
		{
		}

		// Token: 0x0602D994 RID: 186772 RVA: 0x00AC44AC File Offset: 0x00AC26AC
		public SMovieCameraConfigItem(string Tip, [Nullable(0)] TEnumAsByte<EMovieCameraItemType> Type, TArray<SMovieCameraConfigItem_Condition> ConditionList, SMovieCameraConfigItem_FightSubCameraSetting FightSubCameraSetting, SMovieCameraConfigItem_SequenceSetting SequenceSetting)
		{
			this.Tip = Tip;
			this.Type = Type;
			this.ConditionList = ConditionList;
			this.FightSubCameraSetting = FightSubCameraSetting;
			this.SequenceSetting = SequenceSetting;
		}

		// Token: 0x0602D995 RID: 186773 RVA: 0x00AC44D9 File Offset: 0x00AC26D9
		protected override IntPtr GetUStructPtr()
		{
			return SMovieCameraConfigItem.StaticStruct();
		}

		// Token: 0x0602D996 RID: 186774 RVA: 0x00AC44E5 File Offset: 0x00AC26E5
		[NullableContext(2)]
		public SMovieCameraConfigItem(IntPtr NativePtr, UnrealObject MemoryOwner) : base(NativePtr, MemoryOwner)
		{
		}

		// Token: 0x0602D997 RID: 186775 RVA: 0x00AC44EF File Offset: 0x00AC26EF
		public SMovieCameraConfigItem(IntPtr NativePtr, bool bWithMoveAssign, bool bWithCopyAssignIfCannotMove) : base(NativePtr, bWithMoveAssign, bWithCopyAssignIfCannotMove)
		{
		}

		// Token: 0x0602D998 RID: 186776 RVA: 0x00AC44FA File Offset: 0x00AC26FA
		public static IUnrealScriptStructProxy CreateFromPointer(IntPtr Pointer)
		{
			return new SMovieCameraConfigItem(Pointer, false, true);
		}

		// Token: 0x0602D999 RID: 186777 RVA: 0x00AC4504 File Offset: 0x00AC2704
		public static IUnrealScriptStructProxy CreateReferenceFromPointer(IntPtr Pointer, UnrealObject MemoryOwner)
		{
			return new SMovieCameraConfigItem(Pointer, MemoryOwner);
		}

		// Token: 0x04019B56 RID: 105302
		public const string __ObjectPath = "/Game/Aki/Character/BaseCharacter/Camera/MovieCamera/SMovieCameraConfigItem.SMovieCameraConfigItem";

		// Token: 0x04019B57 RID: 105303
		private static IntPtr _ScriptStructPtr;

		// Token: 0x04019B58 RID: 105304
		internal static int __PropertyOffset_0;

		// Token: 0x04019B59 RID: 105305
		internal static int __PropertyOffset_1;

		// Token: 0x04019B5A RID: 105306
		internal static int __PropertyOffset_2;

		// Token: 0x04019B5B RID: 105307
		[Nullable(2)]
		private TArray<SMovieCameraConfigItem_Condition> _ConditionList;

		// Token: 0x04019B5C RID: 105308
		internal static int __PropertyOffset_3;

		// Token: 0x04019B5D RID: 105309
		[Nullable(2)]
		private SMovieCameraConfigItem_FightSubCameraSetting _FightSubCameraSetting;

		// Token: 0x04019B5E RID: 105310
		internal static int __PropertyOffset_4;

		// Token: 0x04019B5F RID: 105311
		[Nullable(2)]
		private SMovieCameraConfigItem_SequenceSetting _SequenceSetting;
	}
}
