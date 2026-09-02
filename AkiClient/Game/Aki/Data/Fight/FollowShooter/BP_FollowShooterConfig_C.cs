using System;
using System.Runtime.CompilerServices;
using AkiClient.Game.Aki.Character.BaseCharacter;
using AkiClient.Game.Aki.Character.Input.Structures;
using AkiClient.Game.Aki.Data.Fight.Struct;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Data.Fight.FollowShooter
{
	// Token: 0x02003EDF RID: 16095
	[NullableContext(1)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Data/Fight/FollowShooter/BP_FollowShooterConfig.BP_FollowShooterConfig_C")]
	[UnrealStructLayout(672, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 672)]
	public class BP_FollowShooterConfig_C : UPrimaryDataAsset, IUnrealUObject, IUnrealObject
	{
		// Token: 0x06028147 RID: 164167 RVA: 0x00A01DE3 File Offset: 0x009FFFE3
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_FollowShooterConfig_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Data/Fight/FollowShooter/BP_FollowShooterConfig.BP_FollowShooterConfig_C");
			}
			return BP_FollowShooterConfig_C._ClassPtr;
		}

		// Token: 0x06028148 RID: 164168 RVA: 0x00A01E08 File Offset: 0x00A00008
		public BP_FollowShooterConfig_C() : this(BuiltinUtils.AllocNativeUObject(BP_FollowShooterConfig_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x06028149 RID: 164169 RVA: 0x00A01E30 File Offset: 0x00A00030
		public BP_FollowShooterConfig_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_FollowShooterConfig_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x1700606E RID: 24686
		// (get) Token: 0x0602814A RID: 164170 RVA: 0x00A01E63 File Offset: 0x00A00063
		// (set) Token: 0x0602814B RID: 164171 RVA: 0x00A01E73 File Offset: 0x00A00073
		public unsafe bool AutoEnable
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_FollowShooterConfig_C.__PropertyOffset_0) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_FollowShooterConfig_C.__PropertyOffset_0) = (value ? 1 : 0);
			}
		}

		// Token: 0x1700606F RID: 24687
		// (get) Token: 0x0602814C RID: 164172 RVA: 0x00A01E84 File Offset: 0x00A00084
		// (set) Token: 0x0602814D RID: 164173 RVA: 0x00A01E94 File Offset: 0x00A00094
		public unsafe bool NeedUploadData
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_FollowShooterConfig_C.__PropertyOffset_1) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_FollowShooterConfig_C.__PropertyOffset_1) = (value ? 1 : 0);
			}
		}

		// Token: 0x17006070 RID: 24688
		// (get) Token: 0x0602814E RID: 164174 RVA: 0x00A01EA8 File Offset: 0x00A000A8
		// (set) Token: 0x0602814F RID: 164175 RVA: 0x00A01EE1 File Offset: 0x00A000E1
		public TArray<SInputAction> NeedInputActions
		{
			get
			{
				base.FastCheckIsValid();
				TArray<SInputAction> result;
				if ((result = this._NeedInputActions) == null)
				{
					result = (this._NeedInputActions = new TArray<SInputAction>(base.NativePtr + (IntPtr)BP_FollowShooterConfig_C.__PropertyOffset_2, this));
				}
				return result;
			}
			set
			{
				this.NeedInputActions.CopyAssign(value);
			}
		}

		// Token: 0x17006071 RID: 24689
		// (get) Token: 0x06028150 RID: 164176 RVA: 0x00A01EF0 File Offset: 0x00A000F0
		// (set) Token: 0x06028151 RID: 164177 RVA: 0x00A01F29 File Offset: 0x00A00129
		public TArray<FGameplayTag> AddTagsWhenEnable
		{
			get
			{
				base.FastCheckIsValid();
				TArray<FGameplayTag> result;
				if ((result = this._AddTagsWhenEnable) == null)
				{
					result = (this._AddTagsWhenEnable = new TArray<FGameplayTag>(base.NativePtr + (IntPtr)BP_FollowShooterConfig_C.__PropertyOffset_3, this));
				}
				return result;
			}
			set
			{
				this.AddTagsWhenEnable.CopyAssign(value);
			}
		}

		// Token: 0x17006072 RID: 24690
		// (get) Token: 0x06028152 RID: 164178 RVA: 0x00A01F38 File Offset: 0x00A00138
		// (set) Token: 0x06028153 RID: 164179 RVA: 0x00A01F71 File Offset: 0x00A00171
		public TArray<FGameplayTag> AddTagsToPlayerWhenPossess
		{
			get
			{
				base.FastCheckIsValid();
				TArray<FGameplayTag> result;
				if ((result = this._AddTagsToPlayerWhenPossess) == null)
				{
					result = (this._AddTagsToPlayerWhenPossess = new TArray<FGameplayTag>(base.NativePtr + (IntPtr)BP_FollowShooterConfig_C.__PropertyOffset_4, this));
				}
				return result;
			}
			set
			{
				this.AddTagsToPlayerWhenPossess.CopyAssign(value);
			}
		}

		// Token: 0x17006073 RID: 24691
		// (get) Token: 0x06028154 RID: 164180 RVA: 0x00A01F80 File Offset: 0x00A00180
		// (set) Token: 0x06028155 RID: 164181 RVA: 0x00A01FB9 File Offset: 0x00A001B9
		public TArray<FGameplayTag> DisableWhenCurrentRoleHasTags
		{
			get
			{
				base.FastCheckIsValid();
				TArray<FGameplayTag> result;
				if ((result = this._DisableWhenCurrentRoleHasTags) == null)
				{
					result = (this._DisableWhenCurrentRoleHasTags = new TArray<FGameplayTag>(base.NativePtr + (IntPtr)BP_FollowShooterConfig_C.__PropertyOffset_5, this));
				}
				return result;
			}
			set
			{
				this.DisableWhenCurrentRoleHasTags.CopyAssign(value);
			}
		}

		// Token: 0x17006074 RID: 24692
		// (get) Token: 0x06028156 RID: 164182 RVA: 0x00A01FC8 File Offset: 0x00A001C8
		// (set) Token: 0x06028157 RID: 164183 RVA: 0x00A02001 File Offset: 0x00A00201
		public TMap<FGameplayTag, FGameplayTagContainer> AddTagsWhenCurrentRoleHasAnyTags
		{
			get
			{
				base.FastCheckIsValid();
				TMap<FGameplayTag, FGameplayTagContainer> result;
				if ((result = this._AddTagsWhenCurrentRoleHasAnyTags) == null)
				{
					result = (this._AddTagsWhenCurrentRoleHasAnyTags = new TMap<FGameplayTag, FGameplayTagContainer>(base.NativePtr + (IntPtr)BP_FollowShooterConfig_C.__PropertyOffset_6, this));
				}
				return result;
			}
			set
			{
				this.AddTagsWhenCurrentRoleHasAnyTags.CopyAssign(value);
			}
		}

		// Token: 0x17006075 RID: 24693
		// (get) Token: 0x06028158 RID: 164184 RVA: 0x00A0200F File Offset: 0x00A0020F
		// (set) Token: 0x06028159 RID: 164185 RVA: 0x00A0201F File Offset: 0x00A0021F
		public unsafe int DelayDisappearMillisecond
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_FollowShooterConfig_C.__PropertyOffset_7);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_FollowShooterConfig_C.__PropertyOffset_7) = value;
			}
		}

		// Token: 0x17006076 RID: 24694
		// (get) Token: 0x0602815A RID: 164186 RVA: 0x00A02030 File Offset: 0x00A00230
		// (set) Token: 0x0602815B RID: 164187 RVA: 0x00A02069 File Offset: 0x00A00269
		public SLockOnFollowShooter LockOnConfig
		{
			get
			{
				base.FastCheckIsValid();
				SLockOnFollowShooter result;
				if ((result = this._LockOnConfig) == null)
				{
					result = (this._LockOnConfig = new SLockOnFollowShooter(base.NativePtr + (IntPtr)BP_FollowShooterConfig_C.__PropertyOffset_8, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(SLockOnFollowShooter.StaticStruct(), base.NativePtr + (IntPtr)BP_FollowShooterConfig_C.__PropertyOffset_8, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17006077 RID: 24695
		// (get) Token: 0x0602815C RID: 164188 RVA: 0x00A0208A File Offset: 0x00A0028A
		// (set) Token: 0x0602815D RID: 164189 RVA: 0x00A0209A File Offset: 0x00A0029A
		public unsafe int AimType
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_FollowShooterConfig_C.__PropertyOffset_9);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_FollowShooterConfig_C.__PropertyOffset_9) = value;
			}
		}

		// Token: 0x17006078 RID: 24696
		// (get) Token: 0x0602815E RID: 164190 RVA: 0x00A020AB File Offset: 0x00A002AB
		// (set) Token: 0x0602815F RID: 164191 RVA: 0x00A020BF File Offset: 0x00A002BF
		public unsafe string SightResId
		{
			get
			{
				return FString.ToString((void*)(base.NativePtr + (byte*)((IntPtr)BP_FollowShooterConfig_C.__PropertyOffset_10)));
			}
			set
			{
				FString.CopyFrom((void*)(base.NativePtr + (byte*)((IntPtr)BP_FollowShooterConfig_C.__PropertyOffset_10)), value);
			}
		}

		// Token: 0x17006079 RID: 24697
		// (get) Token: 0x06028160 RID: 164192 RVA: 0x00A020D4 File Offset: 0x00A002D4
		// (set) Token: 0x06028161 RID: 164193 RVA: 0x00A0210D File Offset: 0x00A0030D
		public SBornTransform BornTransform
		{
			get
			{
				base.FastCheckIsValid();
				SBornTransform result;
				if ((result = this._BornTransform) == null)
				{
					result = (this._BornTransform = new SBornTransform(base.NativePtr + (IntPtr)BP_FollowShooterConfig_C.__PropertyOffset_11, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(SBornTransform.StaticStruct(), base.NativePtr + (IntPtr)BP_FollowShooterConfig_C.__PropertyOffset_11, value.NativePtr, 1, false);
			}
		}

		// Token: 0x1700607A RID: 24698
		// (get) Token: 0x06028162 RID: 164194 RVA: 0x00A02130 File Offset: 0x00A00330
		// (set) Token: 0x06028163 RID: 164195 RVA: 0x00A02169 File Offset: 0x00A00369
		public TArray<SFollowShooterTagConfig> AddTagByCheckCurrentRoleTag
		{
			get
			{
				base.FastCheckIsValid();
				TArray<SFollowShooterTagConfig> result;
				if ((result = this._AddTagByCheckCurrentRoleTag) == null)
				{
					result = (this._AddTagByCheckCurrentRoleTag = new TArray<SFollowShooterTagConfig>(base.NativePtr + (IntPtr)BP_FollowShooterConfig_C.__PropertyOffset_12, this));
				}
				return result;
			}
			set
			{
				this.AddTagByCheckCurrentRoleTag.CopyAssign(value);
			}
		}

		// Token: 0x1700607B RID: 24699
		// (get) Token: 0x06028164 RID: 164196 RVA: 0x00A02177 File Offset: 0x00A00377
		// (set) Token: 0x06028165 RID: 164197 RVA: 0x00A02187 File Offset: 0x00A00387
		public unsafe bool SetEntityEnableAfterMaterialController
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_FollowShooterConfig_C.__PropertyOffset_13) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_FollowShooterConfig_C.__PropertyOffset_13) = (value ? 1 : 0);
			}
		}

		// Token: 0x1700607C RID: 24700
		// (get) Token: 0x06028166 RID: 164198 RVA: 0x00A02198 File Offset: 0x00A00398
		// (set) Token: 0x06028167 RID: 164199 RVA: 0x00A021D1 File Offset: 0x00A003D1
		public FGameplayTagContainer DisableInputWhenHasTags
		{
			get
			{
				base.FastCheckIsValid();
				FGameplayTagContainer result;
				if ((result = this._DisableInputWhenHasTags) == null)
				{
					result = (this._DisableInputWhenHasTags = new FGameplayTagContainer(base.NativePtr + (IntPtr)BP_FollowShooterConfig_C.__PropertyOffset_14, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FGameplayTagContainer.StaticStruct(), base.NativePtr + (IntPtr)BP_FollowShooterConfig_C.__PropertyOffset_14, value.NativePtr, 1, false);
			}
		}

		// Token: 0x1700607D RID: 24701
		// (get) Token: 0x06028168 RID: 164200 RVA: 0x00A021F4 File Offset: 0x00A003F4
		// (set) Token: 0x06028169 RID: 164201 RVA: 0x00A0222D File Offset: 0x00A0042D
		public TArray<SFollowShooterEnablePriorityInfo> EnablePriority
		{
			get
			{
				base.FastCheckIsValid();
				TArray<SFollowShooterEnablePriorityInfo> result;
				if ((result = this._EnablePriority) == null)
				{
					result = (this._EnablePriority = new TArray<SFollowShooterEnablePriorityInfo>(base.NativePtr + (IntPtr)BP_FollowShooterConfig_C.__PropertyOffset_15, this));
				}
				return result;
			}
			set
			{
				this.EnablePriority.CopyAssign(value);
			}
		}

		// Token: 0x0602816A RID: 164202 RVA: 0x00A0223B File Offset: 0x00A0043B
		protected BP_FollowShooterConfig_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x040150A4 RID: 86180
		public new const string __ObjectPath = "/Game/Aki/Data/Fight/FollowShooter/BP_FollowShooterConfig.BP_FollowShooterConfig_C";

		// Token: 0x040150A5 RID: 86181
		private static IntPtr _ClassPtr;

		// Token: 0x040150A6 RID: 86182
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x040150A7 RID: 86183
		internal static int __PropertyOffset_0;

		// Token: 0x040150A8 RID: 86184
		internal static int __PropertyOffset_1;

		// Token: 0x040150A9 RID: 86185
		internal static int __PropertyOffset_2;

		// Token: 0x040150AA RID: 86186
		[Nullable(2)]
		private TArray<SInputAction> _NeedInputActions;

		// Token: 0x040150AB RID: 86187
		internal static int __PropertyOffset_3;

		// Token: 0x040150AC RID: 86188
		[Nullable(2)]
		private TArray<FGameplayTag> _AddTagsWhenEnable;

		// Token: 0x040150AD RID: 86189
		internal static int __PropertyOffset_4;

		// Token: 0x040150AE RID: 86190
		[Nullable(2)]
		private TArray<FGameplayTag> _AddTagsToPlayerWhenPossess;

		// Token: 0x040150AF RID: 86191
		internal static int __PropertyOffset_5;

		// Token: 0x040150B0 RID: 86192
		[Nullable(2)]
		private TArray<FGameplayTag> _DisableWhenCurrentRoleHasTags;

		// Token: 0x040150B1 RID: 86193
		internal static int __PropertyOffset_6;

		// Token: 0x040150B2 RID: 86194
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private TMap<FGameplayTag, FGameplayTagContainer> _AddTagsWhenCurrentRoleHasAnyTags;

		// Token: 0x040150B3 RID: 86195
		internal static int __PropertyOffset_7;

		// Token: 0x040150B4 RID: 86196
		internal static int __PropertyOffset_8;

		// Token: 0x040150B5 RID: 86197
		[Nullable(2)]
		private SLockOnFollowShooter _LockOnConfig;

		// Token: 0x040150B6 RID: 86198
		internal static int __PropertyOffset_9;

		// Token: 0x040150B7 RID: 86199
		internal static int __PropertyOffset_10;

		// Token: 0x040150B8 RID: 86200
		internal static int __PropertyOffset_11;

		// Token: 0x040150B9 RID: 86201
		[Nullable(2)]
		private SBornTransform _BornTransform;

		// Token: 0x040150BA RID: 86202
		internal static int __PropertyOffset_12;

		// Token: 0x040150BB RID: 86203
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private TArray<SFollowShooterTagConfig> _AddTagByCheckCurrentRoleTag;

		// Token: 0x040150BC RID: 86204
		internal static int __PropertyOffset_13;

		// Token: 0x040150BD RID: 86205
		internal static int __PropertyOffset_14;

		// Token: 0x040150BE RID: 86206
		[Nullable(2)]
		private FGameplayTagContainer _DisableInputWhenHasTags;

		// Token: 0x040150BF RID: 86207
		internal static int __PropertyOffset_15;

		// Token: 0x040150C0 RID: 86208
		[Nullable(2)]
		private TArray<SFollowShooterEnablePriorityInfo> _EnablePriority;
	}
}
