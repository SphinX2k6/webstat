using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Data.Fight.AssestStruct
{
	// Token: 0x02003EEF RID: 16111
	[NullableContext(1)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Data/Fight/AssestStruct/FK_Shake_AssestData.FK_Shake_AssestData_C")]
	[UnrealStructLayout(152, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 152)]
	public class FK_Shake_AssestData_C : UPrimaryDataAsset, IUnrealUObject, IUnrealObject
	{
		// Token: 0x060281CB RID: 164299 RVA: 0x00A0299A File Offset: 0x00A00B9A
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (FK_Shake_AssestData_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Data/Fight/AssestStruct/FK_Shake_AssestData.FK_Shake_AssestData_C");
			}
			return FK_Shake_AssestData_C._ClassPtr;
		}

		// Token: 0x060281CC RID: 164300 RVA: 0x00A029C0 File Offset: 0x00A00BC0
		public FK_Shake_AssestData_C() : this(BuiltinUtils.AllocNativeUObject(FK_Shake_AssestData_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x060281CD RID: 164301 RVA: 0x00A029E8 File Offset: 0x00A00BE8
		public FK_Shake_AssestData_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(FK_Shake_AssestData_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x17006090 RID: 24720
		// (get) Token: 0x060281CE RID: 164302 RVA: 0x00A02A1C File Offset: 0x00A00C1C
		// (set) Token: 0x060281CF RID: 164303 RVA: 0x00A02A55 File Offset: 0x00A00C55
		public FSkeletonGroup ShakeBonesData
		{
			get
			{
				base.FastCheckIsValid();
				FSkeletonGroup result;
				if ((result = this._ShakeBonesData) == null)
				{
					result = (this._ShakeBonesData = new FSkeletonGroup(base.NativePtr + (IntPtr)FK_Shake_AssestData_C.__PropertyOffset_0, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FSkeletonGroup.StaticStruct(), base.NativePtr + (IntPtr)FK_Shake_AssestData_C.__PropertyOffset_0, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17006091 RID: 24721
		// (get) Token: 0x060281D0 RID: 164304 RVA: 0x00A02A76 File Offset: 0x00A00C76
		// (set) Token: 0x060281D1 RID: 164305 RVA: 0x00A02A8A File Offset: 0x00A00C8A
		[Nullable(2)]
		public unsafe UCurveFloat ShakeCurve
		{
			[NullableContext(2)]
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UCurveFloat>(base.NativePtr / (IntPtr)sizeof(void*) + FK_Shake_AssestData_C.__PropertyOffset_1);
			}
			[NullableContext(2)]
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + FK_Shake_AssestData_C.__PropertyOffset_1, value);
			}
		}

		// Token: 0x17006092 RID: 24722
		// (get) Token: 0x060281D2 RID: 164306 RVA: 0x00A02A9F File Offset: 0x00A00C9F
		// (set) Token: 0x060281D3 RID: 164307 RVA: 0x00A02AAF File Offset: 0x00A00CAF
		public unsafe float ShakeTime
		{
			get
			{
				return *(base.NativePtr + (IntPtr)FK_Shake_AssestData_C.__PropertyOffset_2);
			}
			set
			{
				*(base.NativePtr + (IntPtr)FK_Shake_AssestData_C.__PropertyOffset_2) = value;
			}
		}

		// Token: 0x17006093 RID: 24723
		// (get) Token: 0x060281D4 RID: 164308 RVA: 0x00A02AC0 File Offset: 0x00A00CC0
		// (set) Token: 0x060281D5 RID: 164309 RVA: 0x00A02AD0 File Offset: 0x00A00CD0
		public unsafe float ShakeAmplitude
		{
			get
			{
				return *(base.NativePtr + (IntPtr)FK_Shake_AssestData_C.__PropertyOffset_3);
			}
			set
			{
				*(base.NativePtr + (IntPtr)FK_Shake_AssestData_C.__PropertyOffset_3) = value;
			}
		}

		// Token: 0x17006094 RID: 24724
		// (get) Token: 0x060281D6 RID: 164310 RVA: 0x00A02AE1 File Offset: 0x00A00CE1
		// (set) Token: 0x060281D7 RID: 164311 RVA: 0x00A02AF1 File Offset: 0x00A00CF1
		public unsafe int ShakeRange
		{
			get
			{
				return *(base.NativePtr + (IntPtr)FK_Shake_AssestData_C.__PropertyOffset_4);
			}
			set
			{
				*(base.NativePtr + (IntPtr)FK_Shake_AssestData_C.__PropertyOffset_4) = value;
			}
		}

		// Token: 0x17006095 RID: 24725
		// (get) Token: 0x060281D8 RID: 164312 RVA: 0x00A02B04 File Offset: 0x00A00D04
		// (set) Token: 0x060281D9 RID: 164313 RVA: 0x00A02B3D File Offset: 0x00A00D3D
		public FBoneFeedbackAnimConfigGroup FeedbackAnim
		{
			get
			{
				base.FastCheckIsValid();
				FBoneFeedbackAnimConfigGroup result;
				if ((result = this._FeedbackAnim) == null)
				{
					result = (this._FeedbackAnim = new FBoneFeedbackAnimConfigGroup(base.NativePtr + (IntPtr)FK_Shake_AssestData_C.__PropertyOffset_5, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FBoneFeedbackAnimConfigGroup.StaticStruct(), base.NativePtr + (IntPtr)FK_Shake_AssestData_C.__PropertyOffset_5, value.NativePtr, 1, false);
			}
		}

		// Token: 0x060281DA RID: 164314 RVA: 0x00A02B5E File Offset: 0x00A00D5E
		protected FK_Shake_AssestData_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x04015108 RID: 86280
		public new const string __ObjectPath = "/Game/Aki/Data/Fight/AssestStruct/FK_Shake_AssestData.FK_Shake_AssestData_C";

		// Token: 0x04015109 RID: 86281
		private static IntPtr _ClassPtr;

		// Token: 0x0401510A RID: 86282
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x0401510B RID: 86283
		internal static int __PropertyOffset_0;

		// Token: 0x0401510C RID: 86284
		[Nullable(2)]
		private FSkeletonGroup _ShakeBonesData;

		// Token: 0x0401510D RID: 86285
		internal static int __PropertyOffset_1;

		// Token: 0x0401510E RID: 86286
		internal static int __PropertyOffset_2;

		// Token: 0x0401510F RID: 86287
		internal static int __PropertyOffset_3;

		// Token: 0x04015110 RID: 86288
		internal static int __PropertyOffset_4;

		// Token: 0x04015111 RID: 86289
		internal static int __PropertyOffset_5;

		// Token: 0x04015112 RID: 86290
		[Nullable(2)]
		private FBoneFeedbackAnimConfigGroup _FeedbackAnim;
	}
}
