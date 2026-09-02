using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Character.BaseCharacter
{
	// Token: 0x020041CF RID: 16847
	[NullableContext(1)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Character/BaseCharacter/BP_ReplaceHitEffect.BP_ReplaceHitEffect_C")]
	[UnrealStructLayout(320, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 320)]
	public class BP_ReplaceHitEffect_C : UPrimaryDataAsset, IUnrealUObject, IUnrealObject
	{
		// Token: 0x0602CCF7 RID: 183543 RVA: 0x00AB044B File Offset: 0x00AAE64B
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_ReplaceHitEffect_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Character/BaseCharacter/BP_ReplaceHitEffect.BP_ReplaceHitEffect_C");
			}
			return BP_ReplaceHitEffect_C._ClassPtr;
		}

		// Token: 0x0602CCF8 RID: 183544 RVA: 0x00AB0470 File Offset: 0x00AAE670
		public BP_ReplaceHitEffect_C() : this(BuiltinUtils.AllocNativeUObject(BP_ReplaceHitEffect_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x0602CCF9 RID: 183545 RVA: 0x00AB0498 File Offset: 0x00AAE698
		public BP_ReplaceHitEffect_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_ReplaceHitEffect_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x1700792A RID: 31018
		// (get) Token: 0x0602CCFA RID: 183546 RVA: 0x00AB04CB File Offset: 0x00AAE6CB
		// (set) Token: 0x0602CCFB RID: 183547 RVA: 0x00AB04E0 File Offset: 0x00AAE6E0
		public TSoftClassPtr<UKuroCameraShake> 震屏
		{
			get
			{
				return new TSoftClassPtr<UKuroCameraShake>(base.NativePtr + (IntPtr)BP_ReplaceHitEffect_C.__PropertyOffset_0, this);
			}
			set
			{
				FSoftObjectPtr.NativeCopy(base.NativePtr + (IntPtr)BP_ReplaceHitEffect_C.__PropertyOffset_0, (value != null) ? value.NativePtr : IntPtr.Zero, 1);
			}
		}

		// Token: 0x1700792B RID: 31019
		// (get) Token: 0x0602CCFC RID: 183548 RVA: 0x00AB0505 File Offset: 0x00AAE705
		// (set) Token: 0x0602CCFD RID: 183549 RVA: 0x00AB051A File Offset: 0x00AAE71A
		public TSoftObjectPtr<UEffectModelBase> 受击特效
		{
			get
			{
				return new TSoftObjectPtr<UEffectModelBase>(base.NativePtr + (IntPtr)BP_ReplaceHitEffect_C.__PropertyOffset_1, this);
			}
			set
			{
				FSoftObjectPtr.NativeCopy(base.NativePtr + (IntPtr)BP_ReplaceHitEffect_C.__PropertyOffset_1, (value != null) ? value.NativePtr : IntPtr.Zero, 1);
			}
		}

		// Token: 0x1700792C RID: 31020
		// (get) Token: 0x0602CCFE RID: 183550 RVA: 0x00AB053F File Offset: 0x00AAE73F
		// (set) Token: 0x0602CCFF RID: 183551 RVA: 0x00AB0554 File Offset: 0x00AAE754
		public TSoftObjectPtr<EffectModelAudio> 受击音效
		{
			get
			{
				return new TSoftObjectPtr<EffectModelAudio>(base.NativePtr + (IntPtr)BP_ReplaceHitEffect_C.__PropertyOffset_2, this);
			}
			set
			{
				FSoftObjectPtr.NativeCopy(base.NativePtr + (IntPtr)BP_ReplaceHitEffect_C.__PropertyOffset_2, (value != null) ? value.NativePtr : IntPtr.Zero, 1);
			}
		}

		// Token: 0x1700792D RID: 31021
		// (get) Token: 0x0602CD00 RID: 183552 RVA: 0x00AB0579 File Offset: 0x00AAE779
		// (set) Token: 0x0602CD01 RID: 183553 RVA: 0x00AB058E File Offset: 0x00AAE78E
		public TSoftObjectPtr<UEffectModelBase> 命中特效
		{
			get
			{
				return new TSoftObjectPtr<UEffectModelBase>(base.NativePtr + (IntPtr)BP_ReplaceHitEffect_C.__PropertyOffset_3, this);
			}
			set
			{
				FSoftObjectPtr.NativeCopy(base.NativePtr + (IntPtr)BP_ReplaceHitEffect_C.__PropertyOffset_3, (value != null) ? value.NativePtr : IntPtr.Zero, 1);
			}
		}

		// Token: 0x1700792E RID: 31022
		// (get) Token: 0x0602CD02 RID: 183554 RVA: 0x00AB05B3 File Offset: 0x00AAE7B3
		// (set) Token: 0x0602CD03 RID: 183555 RVA: 0x00AB05C3 File Offset: 0x00AAE7C3
		public unsafe bool 替换近战子弹顿帧
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_ReplaceHitEffect_C.__PropertyOffset_4) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_ReplaceHitEffect_C.__PropertyOffset_4) = (value ? 1 : 0);
			}
		}

		// Token: 0x1700792F RID: 31023
		// (get) Token: 0x0602CD04 RID: 183556 RVA: 0x00AB05D4 File Offset: 0x00AAE7D4
		// (set) Token: 0x0602CD05 RID: 183557 RVA: 0x00AB060D File Offset: 0x00AAE80D
		public STimeScale 顿帧
		{
			get
			{
				base.FastCheckIsValid();
				STimeScale result;
				if ((result = this._顿帧) == null)
				{
					result = (this._顿帧 = new STimeScale(base.NativePtr + (IntPtr)BP_ReplaceHitEffect_C.__PropertyOffset_5, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(STimeScale.StaticStruct(), base.NativePtr + (IntPtr)BP_ReplaceHitEffect_C.__PropertyOffset_5, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17007930 RID: 31024
		// (get) Token: 0x0602CD06 RID: 183558 RVA: 0x00AB0630 File Offset: 0x00AAE830
		// (set) Token: 0x0602CD07 RID: 183559 RVA: 0x00AB0669 File Offset: 0x00AAE869
		public TArray<FName> 不替换的部位
		{
			get
			{
				base.FastCheckIsValid();
				TArray<FName> result;
				if ((result = this._不替换的部位) == null)
				{
					result = (this._不替换的部位 = new TArray<FName>(base.NativePtr + (IntPtr)BP_ReplaceHitEffect_C.__PropertyOffset_6, this));
				}
				return result;
			}
			set
			{
				this.不替换的部位.CopyAssign(value);
			}
		}

		// Token: 0x0602CD08 RID: 183560 RVA: 0x00AB0677 File Offset: 0x00AAE877
		protected BP_ReplaceHitEffect_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x04018F9D RID: 102301
		public new const string __ObjectPath = "/Game/Aki/Character/BaseCharacter/BP_ReplaceHitEffect.BP_ReplaceHitEffect_C";

		// Token: 0x04018F9E RID: 102302
		private static IntPtr _ClassPtr;

		// Token: 0x04018F9F RID: 102303
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x04018FA0 RID: 102304
		internal static int __PropertyOffset_0;

		// Token: 0x04018FA1 RID: 102305
		internal static int __PropertyOffset_1;

		// Token: 0x04018FA2 RID: 102306
		internal static int __PropertyOffset_2;

		// Token: 0x04018FA3 RID: 102307
		internal static int __PropertyOffset_3;

		// Token: 0x04018FA4 RID: 102308
		internal static int __PropertyOffset_4;

		// Token: 0x04018FA5 RID: 102309
		internal static int __PropertyOffset_5;

		// Token: 0x04018FA6 RID: 102310
		[Nullable(2)]
		private STimeScale _顿帧;

		// Token: 0x04018FA7 RID: 102311
		internal static int __PropertyOffset_6;

		// Token: 0x04018FA8 RID: 102312
		[Nullable(2)]
		private TArray<FName> _不替换的部位;
	}
}
