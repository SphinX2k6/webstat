using System;
using System.Runtime.CompilerServices;
using AkiClient.Game.Aki.Data.Fight.Struct;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Character.BaseCharacter
{
	// Token: 0x020041CE RID: 16846
	[NullableContext(1)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Character/BaseCharacter/BP_PartHitEffect.BP_PartHitEffect_C")]
	[UnrealStructLayout(208, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 208)]
	public class BP_PartHitEffect_C : UPrimaryDataAsset, IUnrealUObject, IUnrealObject
	{
		// Token: 0x0602CCE1 RID: 183521 RVA: 0x00AB0174 File Offset: 0x00AAE374
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_PartHitEffect_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Character/BaseCharacter/BP_PartHitEffect.BP_PartHitEffect_C");
			}
			return BP_PartHitEffect_C._ClassPtr;
		}

		// Token: 0x0602CCE2 RID: 183522 RVA: 0x00AB0198 File Offset: 0x00AAE398
		public BP_PartHitEffect_C() : this(BuiltinUtils.AllocNativeUObject(BP_PartHitEffect_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x0602CCE3 RID: 183523 RVA: 0x00AB01C0 File Offset: 0x00AAE3C0
		public BP_PartHitEffect_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_PartHitEffect_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x17007921 RID: 31009
		// (get) Token: 0x0602CCE4 RID: 183524 RVA: 0x00AB01F4 File Offset: 0x00AAE3F4
		// (set) Token: 0x0602CCE5 RID: 183525 RVA: 0x00AB022D File Offset: 0x00AAE42D
		public TArray<SPartHitEffect> PartCollision
		{
			get
			{
				base.FastCheckIsValid();
				TArray<SPartHitEffect> result;
				if ((result = this._PartCollision) == null)
				{
					result = (this._PartCollision = new TArray<SPartHitEffect>(base.NativePtr + (IntPtr)BP_PartHitEffect_C.__PropertyOffset_0, this));
				}
				return result;
			}
			set
			{
				this.PartCollision.CopyAssign(value);
			}
		}

		// Token: 0x17007922 RID: 31010
		// (get) Token: 0x0602CCE6 RID: 183526 RVA: 0x00AB023C File Offset: 0x00AAE43C
		// (set) Token: 0x0602CCE7 RID: 183527 RVA: 0x00AB0275 File Offset: 0x00AAE475
		public TArray<SAimPart> AimParts
		{
			get
			{
				base.FastCheckIsValid();
				TArray<SAimPart> result;
				if ((result = this._AimParts) == null)
				{
					result = (this._AimParts = new TArray<SAimPart>(base.NativePtr + (IntPtr)BP_PartHitEffect_C.__PropertyOffset_1, this));
				}
				return result;
			}
			set
			{
				this.AimParts.CopyAssign(value);
			}
		}

		// Token: 0x17007923 RID: 31011
		// (get) Token: 0x0602CCE8 RID: 183528 RVA: 0x00AB0284 File Offset: 0x00AAE484
		// (set) Token: 0x0602CCE9 RID: 183529 RVA: 0x00AB02BD File Offset: 0x00AAE4BD
		public TArray<SLockOnPart> LockOnParts
		{
			get
			{
				base.FastCheckIsValid();
				TArray<SLockOnPart> result;
				if ((result = this._LockOnParts) == null)
				{
					result = (this._LockOnParts = new TArray<SLockOnPart>(base.NativePtr + (IntPtr)BP_PartHitEffect_C.__PropertyOffset_2, this));
				}
				return result;
			}
			set
			{
				this.LockOnParts.CopyAssign(value);
			}
		}

		// Token: 0x17007924 RID: 31012
		// (get) Token: 0x0602CCEA RID: 183530 RVA: 0x00AB02CB File Offset: 0x00AAE4CB
		// (set) Token: 0x0602CCEB RID: 183531 RVA: 0x00AB02DB File Offset: 0x00AAE4DB
		public unsafe float StartHideDistance
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_PartHitEffect_C.__PropertyOffset_3);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_PartHitEffect_C.__PropertyOffset_3) = value;
			}
		}

		// Token: 0x17007925 RID: 31013
		// (get) Token: 0x0602CCEC RID: 183532 RVA: 0x00AB02EC File Offset: 0x00AAE4EC
		// (set) Token: 0x0602CCED RID: 183533 RVA: 0x00AB02FC File Offset: 0x00AAE4FC
		public unsafe float CompleteHideDistance
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_PartHitEffect_C.__PropertyOffset_4);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_PartHitEffect_C.__PropertyOffset_4) = value;
			}
		}

		// Token: 0x17007926 RID: 31014
		// (get) Token: 0x0602CCEE RID: 183534 RVA: 0x00AB030D File Offset: 0x00AAE50D
		// (set) Token: 0x0602CCEF RID: 183535 RVA: 0x00AB031D File Offset: 0x00AAE51D
		public unsafe float StartDitherValue
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_PartHitEffect_C.__PropertyOffset_5);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_PartHitEffect_C.__PropertyOffset_5) = value;
			}
		}

		// Token: 0x17007927 RID: 31015
		// (get) Token: 0x0602CCF0 RID: 183536 RVA: 0x00AB0330 File Offset: 0x00AAE530
		// (set) Token: 0x0602CCF1 RID: 183537 RVA: 0x00AB0369 File Offset: 0x00AAE569
		public SLockOnConfig LockOnConfig
		{
			get
			{
				base.FastCheckIsValid();
				SLockOnConfig result;
				if ((result = this._LockOnConfig) == null)
				{
					result = (this._LockOnConfig = new SLockOnConfig(base.NativePtr + (IntPtr)BP_PartHitEffect_C.__PropertyOffset_6, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(SLockOnConfig.StaticStruct(), base.NativePtr + (IntPtr)BP_PartHitEffect_C.__PropertyOffset_6, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17007928 RID: 31016
		// (get) Token: 0x0602CCF2 RID: 183538 RVA: 0x00AB038C File Offset: 0x00AAE58C
		// (set) Token: 0x0602CCF3 RID: 183539 RVA: 0x00AB03C5 File Offset: 0x00AAE5C5
		public SCameraLockOnConfig CameraLockOnConfig
		{
			get
			{
				base.FastCheckIsValid();
				SCameraLockOnConfig result;
				if ((result = this._CameraLockOnConfig) == null)
				{
					result = (this._CameraLockOnConfig = new SCameraLockOnConfig(base.NativePtr + (IntPtr)BP_PartHitEffect_C.__PropertyOffset_7, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(SCameraLockOnConfig.StaticStruct(), base.NativePtr + (IntPtr)BP_PartHitEffect_C.__PropertyOffset_7, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17007929 RID: 31017
		// (get) Token: 0x0602CCF4 RID: 183540 RVA: 0x00AB03E8 File Offset: 0x00AAE5E8
		// (set) Token: 0x0602CCF5 RID: 183541 RVA: 0x00AB0421 File Offset: 0x00AAE621
		public SOcclusionDitherConfig OcclusionDitherConfig
		{
			get
			{
				base.FastCheckIsValid();
				SOcclusionDitherConfig result;
				if ((result = this._OcclusionDitherConfig) == null)
				{
					result = (this._OcclusionDitherConfig = new SOcclusionDitherConfig(base.NativePtr + (IntPtr)BP_PartHitEffect_C.__PropertyOffset_8, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(SOcclusionDitherConfig.StaticStruct(), base.NativePtr + (IntPtr)BP_PartHitEffect_C.__PropertyOffset_8, value.NativePtr, 1, false);
			}
		}

		// Token: 0x0602CCF6 RID: 183542 RVA: 0x00AB0442 File Offset: 0x00AAE642
		protected BP_PartHitEffect_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x04018F8B RID: 102283
		public new const string __ObjectPath = "/Game/Aki/Character/BaseCharacter/BP_PartHitEffect.BP_PartHitEffect_C";

		// Token: 0x04018F8C RID: 102284
		private static IntPtr _ClassPtr;

		// Token: 0x04018F8D RID: 102285
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x04018F8E RID: 102286
		internal static int __PropertyOffset_0;

		// Token: 0x04018F8F RID: 102287
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private TArray<SPartHitEffect> _PartCollision;

		// Token: 0x04018F90 RID: 102288
		internal static int __PropertyOffset_1;

		// Token: 0x04018F91 RID: 102289
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private TArray<SAimPart> _AimParts;

		// Token: 0x04018F92 RID: 102290
		internal static int __PropertyOffset_2;

		// Token: 0x04018F93 RID: 102291
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private TArray<SLockOnPart> _LockOnParts;

		// Token: 0x04018F94 RID: 102292
		internal static int __PropertyOffset_3;

		// Token: 0x04018F95 RID: 102293
		internal static int __PropertyOffset_4;

		// Token: 0x04018F96 RID: 102294
		internal static int __PropertyOffset_5;

		// Token: 0x04018F97 RID: 102295
		internal static int __PropertyOffset_6;

		// Token: 0x04018F98 RID: 102296
		[Nullable(2)]
		private SLockOnConfig _LockOnConfig;

		// Token: 0x04018F99 RID: 102297
		internal static int __PropertyOffset_7;

		// Token: 0x04018F9A RID: 102298
		[Nullable(2)]
		private SCameraLockOnConfig _CameraLockOnConfig;

		// Token: 0x04018F9B RID: 102299
		internal static int __PropertyOffset_8;

		// Token: 0x04018F9C RID: 102300
		[Nullable(2)]
		private SOcclusionDitherConfig _OcclusionDitherConfig;
	}
}
