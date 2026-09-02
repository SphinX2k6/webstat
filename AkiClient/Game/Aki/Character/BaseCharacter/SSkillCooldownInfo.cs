using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;

namespace AkiClient.Game.Aki.Character.BaseCharacter
{
	// Token: 0x0200427D RID: 17021
	[NullableContext(1)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Character/BaseCharacter/SSkillCooldownInfo.SSkillCooldownInfo")]
	[UnrealStructLayout(72, 8, UnrealReflectionPropertyTypeCode.UnrealScriptStructProxy, PropertiesSize = 72)]
	public class SSkillCooldownInfo : UnrealUserDefinedStructProxy, IUnrealScriptStructProxy, IUnrealScriptStruct, IUnrealObject
	{
		// Token: 0x0602D2E9 RID: 185065 RVA: 0x00AB95FC File Offset: 0x00AB77FC
		public static UScriptStructStackOnlyPtr StaticStruct()
		{
			return (SSkillCooldownInfo._ScriptStructPtr != 0) ? SSkillCooldownInfo._ScriptStructPtr : UObjectGlobals.StaticLoadScriptStruct("/Game/Aki/Character/BaseCharacter/SSkillCooldownInfo.SSkillCooldownInfo", ref SSkillCooldownInfo._ScriptStructPtr);
		}

		// Token: 0x17007AFA RID: 31482
		// (get) Token: 0x0602D2EA RID: 185066 RVA: 0x00AB9620 File Offset: 0x00AB7820
		// (set) Token: 0x0602D2EB RID: 185067 RVA: 0x00AB9630 File Offset: 0x00AB7830
		public unsafe float CdTime
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SSkillCooldownInfo.__PropertyOffset_0);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SSkillCooldownInfo.__PropertyOffset_0) = value;
			}
		}

		// Token: 0x17007AFB RID: 31483
		// (get) Token: 0x0602D2EC RID: 185068 RVA: 0x00AB9641 File Offset: 0x00AB7841
		// (set) Token: 0x0602D2ED RID: 185069 RVA: 0x00AB9651 File Offset: 0x00AB7851
		public unsafe float CdDelay
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SSkillCooldownInfo.__PropertyOffset_1);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SSkillCooldownInfo.__PropertyOffset_1) = value;
			}
		}

		// Token: 0x17007AFC RID: 31484
		// (get) Token: 0x0602D2EE RID: 185070 RVA: 0x00AB9662 File Offset: 0x00AB7862
		// (set) Token: 0x0602D2EF RID: 185071 RVA: 0x00AB9672 File Offset: 0x00AB7872
		public unsafe bool IsShareAllCdSkill
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SSkillCooldownInfo.__PropertyOffset_2) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)SSkillCooldownInfo.__PropertyOffset_2) = (value ? 1 : 0);
			}
		}

		// Token: 0x17007AFD RID: 31485
		// (get) Token: 0x0602D2F0 RID: 185072 RVA: 0x00AB9683 File Offset: 0x00AB7883
		// (set) Token: 0x0602D2F1 RID: 185073 RVA: 0x00AB9693 File Offset: 0x00AB7893
		public unsafe int MaxCount
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SSkillCooldownInfo.__PropertyOffset_3);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SSkillCooldownInfo.__PropertyOffset_3) = value;
			}
		}

		// Token: 0x17007AFE RID: 31486
		// (get) Token: 0x0602D2F2 RID: 185074 RVA: 0x00AB96A4 File Offset: 0x00AB78A4
		// (set) Token: 0x0602D2F3 RID: 185075 RVA: 0x00AB96B4 File Offset: 0x00AB78B4
		public unsafe int ShareGroupId
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SSkillCooldownInfo.__PropertyOffset_4);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SSkillCooldownInfo.__PropertyOffset_4) = value;
			}
		}

		// Token: 0x17007AFF RID: 31487
		// (get) Token: 0x0602D2F4 RID: 185076 RVA: 0x00AB96C5 File Offset: 0x00AB78C5
		// (set) Token: 0x0602D2F5 RID: 185077 RVA: 0x00AB96D5 File Offset: 0x00AB78D5
		public unsafe int SectionCount
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SSkillCooldownInfo.__PropertyOffset_5);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SSkillCooldownInfo.__PropertyOffset_5) = value;
			}
		}

		// Token: 0x17007B00 RID: 31488
		// (get) Token: 0x0602D2F6 RID: 185078 RVA: 0x00AB96E6 File Offset: 0x00AB78E6
		// (set) Token: 0x0602D2F7 RID: 185079 RVA: 0x00AB96F6 File Offset: 0x00AB78F6
		public unsafe int SectionRemaining
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SSkillCooldownInfo.__PropertyOffset_6);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SSkillCooldownInfo.__PropertyOffset_6) = value;
			}
		}

		// Token: 0x17007B01 RID: 31489
		// (get) Token: 0x0602D2F8 RID: 185080 RVA: 0x00AB9707 File Offset: 0x00AB7907
		// (set) Token: 0x0602D2F9 RID: 185081 RVA: 0x00AB9717 File Offset: 0x00AB7917
		public unsafe long NextSkillId
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SSkillCooldownInfo.__PropertyOffset_7);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SSkillCooldownInfo.__PropertyOffset_7) = value;
			}
		}

		// Token: 0x17007B02 RID: 31490
		// (get) Token: 0x0602D2FA RID: 185082 RVA: 0x00AB9728 File Offset: 0x00AB7928
		// (set) Token: 0x0602D2FB RID: 185083 RVA: 0x00AB9738 File Offset: 0x00AB7938
		public unsafe float StartTime
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SSkillCooldownInfo.__PropertyOffset_8);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SSkillCooldownInfo.__PropertyOffset_8) = value;
			}
		}

		// Token: 0x17007B03 RID: 31491
		// (get) Token: 0x0602D2FC RID: 185084 RVA: 0x00AB9749 File Offset: 0x00AB7949
		// (set) Token: 0x0602D2FD RID: 185085 RVA: 0x00AB9759 File Offset: 0x00AB7959
		public unsafe float StopTime
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SSkillCooldownInfo.__PropertyOffset_9);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SSkillCooldownInfo.__PropertyOffset_9) = value;
			}
		}

		// Token: 0x17007B04 RID: 31492
		// (get) Token: 0x0602D2FE RID: 185086 RVA: 0x00AB976A File Offset: 0x00AB796A
		// (set) Token: 0x0602D2FF RID: 185087 RVA: 0x00AB977A File Offset: 0x00AB797A
		public unsafe bool IsReset
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SSkillCooldownInfo.__PropertyOffset_10) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)SSkillCooldownInfo.__PropertyOffset_10) = (value ? 1 : 0);
			}
		}

		// Token: 0x17007B05 RID: 31493
		// (get) Token: 0x0602D300 RID: 185088 RVA: 0x00AB978B File Offset: 0x00AB798B
		// (set) Token: 0x0602D301 RID: 185089 RVA: 0x00AB979B File Offset: 0x00AB799B
		public unsafe bool IsResetOnChangeRole
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SSkillCooldownInfo.__PropertyOffset_11) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)SSkillCooldownInfo.__PropertyOffset_11) = (value ? 1 : 0);
			}
		}

		// Token: 0x17007B06 RID: 31494
		// (get) Token: 0x0602D302 RID: 185090 RVA: 0x00AB97AC File Offset: 0x00AB79AC
		// (set) Token: 0x0602D303 RID: 185091 RVA: 0x00AB97EF File Offset: 0x00AB79EF
		public TArray<FGameplayTag> CdTags
		{
			get
			{
				base.FastCheckIsValid();
				TArray<FGameplayTag> result;
				if ((result = this._CdTags) == null)
				{
					result = (this._CdTags = new TArray<FGameplayTag>(base.NativePtr + (IntPtr)SSkillCooldownInfo.__PropertyOffset_12, base.MemoryOwner ?? this));
				}
				return result;
			}
			set
			{
				this.CdTags.CopyAssign(value);
			}
		}

		// Token: 0x0602D304 RID: 185092 RVA: 0x00AB97FD File Offset: 0x00AB79FD
		public SSkillCooldownInfo()
		{
		}

		// Token: 0x0602D305 RID: 185093 RVA: 0x00AB9808 File Offset: 0x00AB7A08
		public SSkillCooldownInfo(float CdTime, float CdDelay, bool IsShareAllCdSkill, int MaxCount, int ShareGroupId, int SectionCount, int SectionRemaining, long NextSkillId, float StartTime, float StopTime, bool IsReset, bool IsResetOnChangeRole, TArray<FGameplayTag> CdTags)
		{
			this.CdTime = CdTime;
			this.CdDelay = CdDelay;
			this.IsShareAllCdSkill = IsShareAllCdSkill;
			this.MaxCount = MaxCount;
			this.ShareGroupId = ShareGroupId;
			this.SectionCount = SectionCount;
			this.SectionRemaining = SectionRemaining;
			this.NextSkillId = NextSkillId;
			this.StartTime = StartTime;
			this.StopTime = StopTime;
			this.IsReset = IsReset;
			this.IsResetOnChangeRole = IsResetOnChangeRole;
			this.CdTags = CdTags;
		}

		// Token: 0x0602D306 RID: 185094 RVA: 0x00AB9880 File Offset: 0x00AB7A80
		protected override IntPtr GetUStructPtr()
		{
			return SSkillCooldownInfo.StaticStruct();
		}

		// Token: 0x0602D307 RID: 185095 RVA: 0x00AB988C File Offset: 0x00AB7A8C
		[NullableContext(2)]
		public SSkillCooldownInfo(IntPtr NativePtr, UnrealObject MemoryOwner) : base(NativePtr, MemoryOwner)
		{
		}

		// Token: 0x0602D308 RID: 185096 RVA: 0x00AB9896 File Offset: 0x00AB7A96
		public SSkillCooldownInfo(IntPtr NativePtr, bool bWithMoveAssign, bool bWithCopyAssignIfCannotMove) : base(NativePtr, bWithMoveAssign, bWithCopyAssignIfCannotMove)
		{
		}

		// Token: 0x0602D309 RID: 185097 RVA: 0x00AB98A1 File Offset: 0x00AB7AA1
		public static IUnrealScriptStructProxy CreateFromPointer(IntPtr Pointer)
		{
			return new SSkillCooldownInfo(Pointer, false, true);
		}

		// Token: 0x0602D30A RID: 185098 RVA: 0x00AB98AB File Offset: 0x00AB7AAB
		public static IUnrealScriptStructProxy CreateReferenceFromPointer(IntPtr Pointer, UnrealObject MemoryOwner)
		{
			return new SSkillCooldownInfo(Pointer, MemoryOwner);
		}

		// Token: 0x04019545 RID: 103749
		public const string __ObjectPath = "/Game/Aki/Character/BaseCharacter/SSkillCooldownInfo.SSkillCooldownInfo";

		// Token: 0x04019546 RID: 103750
		private static IntPtr _ScriptStructPtr;

		// Token: 0x04019547 RID: 103751
		internal static int __PropertyOffset_0;

		// Token: 0x04019548 RID: 103752
		internal static int __PropertyOffset_1;

		// Token: 0x04019549 RID: 103753
		internal static int __PropertyOffset_2;

		// Token: 0x0401954A RID: 103754
		internal static int __PropertyOffset_3;

		// Token: 0x0401954B RID: 103755
		internal static int __PropertyOffset_4;

		// Token: 0x0401954C RID: 103756
		internal static int __PropertyOffset_5;

		// Token: 0x0401954D RID: 103757
		internal static int __PropertyOffset_6;

		// Token: 0x0401954E RID: 103758
		internal static int __PropertyOffset_7;

		// Token: 0x0401954F RID: 103759
		internal static int __PropertyOffset_8;

		// Token: 0x04019550 RID: 103760
		internal static int __PropertyOffset_9;

		// Token: 0x04019551 RID: 103761
		internal static int __PropertyOffset_10;

		// Token: 0x04019552 RID: 103762
		internal static int __PropertyOffset_11;

		// Token: 0x04019553 RID: 103763
		internal static int __PropertyOffset_12;

		// Token: 0x04019554 RID: 103764
		[Nullable(2)]
		private TArray<FGameplayTag> _CdTags;
	}
}
