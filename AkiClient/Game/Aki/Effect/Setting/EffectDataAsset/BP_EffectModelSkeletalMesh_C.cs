using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Effect.Setting.EffectDataAsset
{
	// Token: 0x02003DE5 RID: 15845
	[NullableContext(1)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Effect/Setting/EffectDataAsset/BP_EffectModelSkeletalMesh.BP_EffectModelSkeletalMesh_C")]
	[UnrealStructLayout(1416, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 1416)]
	public class BP_EffectModelSkeletalMesh_C : BP_EffectModelBase_C, IUnrealUObject, IUnrealObject
	{
		// Token: 0x06026E93 RID: 159379 RVA: 0x009E5299 File Offset: 0x009E3499
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_EffectModelSkeletalMesh_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Effect/Setting/EffectDataAsset/BP_EffectModelSkeletalMesh.BP_EffectModelSkeletalMesh_C");
			}
			return BP_EffectModelSkeletalMesh_C._ClassPtr;
		}

		// Token: 0x06026E94 RID: 159380 RVA: 0x009E52C0 File Offset: 0x009E34C0
		public BP_EffectModelSkeletalMesh_C() : this(BuiltinUtils.AllocNativeUObject(BP_EffectModelSkeletalMesh_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x06026E95 RID: 159381 RVA: 0x009E52E8 File Offset: 0x009E34E8
		public BP_EffectModelSkeletalMesh_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_EffectModelSkeletalMesh_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x170059F8 RID: 23032
		// (get) Token: 0x06026E96 RID: 159382 RVA: 0x009E531B File Offset: 0x009E351B
		// (set) Token: 0x06026E97 RID: 159383 RVA: 0x009E532B File Offset: 0x009E352B
		public unsafe bool Looping
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_EffectModelSkeletalMesh_C.__PropertyOffset_0) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_EffectModelSkeletalMesh_C.__PropertyOffset_0) = (value ? 1 : 0);
			}
		}

		// Token: 0x170059F9 RID: 23033
		// (get) Token: 0x06026E98 RID: 159384 RVA: 0x009E533C File Offset: 0x009E353C
		// (set) Token: 0x06026E99 RID: 159385 RVA: 0x009E534C File Offset: 0x009E354C
		public unsafe bool Playing
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_EffectModelSkeletalMesh_C.__PropertyOffset_1) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_EffectModelSkeletalMesh_C.__PropertyOffset_1) = (value ? 1 : 0);
			}
		}

		// Token: 0x170059FA RID: 23034
		// (get) Token: 0x06026E9A RID: 159386 RVA: 0x009E5360 File Offset: 0x009E3560
		// (set) Token: 0x06026E9B RID: 159387 RVA: 0x009E5399 File Offset: 0x009E3599
		public FKuroCurveVector Location
		{
			get
			{
				base.FastCheckIsValid();
				FKuroCurveVector result;
				if ((result = this._Location) == null)
				{
					result = (this._Location = new FKuroCurveVector(base.NativePtr + (IntPtr)BP_EffectModelSkeletalMesh_C.__PropertyOffset_2, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FKuroCurveVector.StaticStruct(), base.NativePtr + (IntPtr)BP_EffectModelSkeletalMesh_C.__PropertyOffset_2, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170059FB RID: 23035
		// (get) Token: 0x06026E9C RID: 159388 RVA: 0x009E53BC File Offset: 0x009E35BC
		// (set) Token: 0x06026E9D RID: 159389 RVA: 0x009E53F5 File Offset: 0x009E35F5
		public FKuroCurveVector Rotation
		{
			get
			{
				base.FastCheckIsValid();
				FKuroCurveVector result;
				if ((result = this._Rotation) == null)
				{
					result = (this._Rotation = new FKuroCurveVector(base.NativePtr + (IntPtr)BP_EffectModelSkeletalMesh_C.__PropertyOffset_3, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FKuroCurveVector.StaticStruct(), base.NativePtr + (IntPtr)BP_EffectModelSkeletalMesh_C.__PropertyOffset_3, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170059FC RID: 23036
		// (get) Token: 0x06026E9E RID: 159390 RVA: 0x009E5418 File Offset: 0x009E3618
		// (set) Token: 0x06026E9F RID: 159391 RVA: 0x009E5451 File Offset: 0x009E3651
		public FKuroCurveVector Scale
		{
			get
			{
				base.FastCheckIsValid();
				FKuroCurveVector result;
				if ((result = this._Scale) == null)
				{
					result = (this._Scale = new FKuroCurveVector(base.NativePtr + (IntPtr)BP_EffectModelSkeletalMesh_C.__PropertyOffset_4, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FKuroCurveVector.StaticStruct(), base.NativePtr + (IntPtr)BP_EffectModelSkeletalMesh_C.__PropertyOffset_4, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170059FD RID: 23037
		// (get) Token: 0x06026EA0 RID: 159392 RVA: 0x009E5472 File Offset: 0x009E3672
		// (set) Token: 0x06026EA1 RID: 159393 RVA: 0x009E5482 File Offset: 0x009E3682
		public unsafe bool EnableCollision
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_EffectModelSkeletalMesh_C.__PropertyOffset_5) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_EffectModelSkeletalMesh_C.__PropertyOffset_5) = (value ? 1 : 0);
			}
		}

		// Token: 0x170059FE RID: 23038
		// (get) Token: 0x06026EA2 RID: 159394 RVA: 0x009E5493 File Offset: 0x009E3693
		// (set) Token: 0x06026EA3 RID: 159395 RVA: 0x009E54A7 File Offset: 0x009E36A7
		[Nullable(2)]
		public unsafe USkeletalMesh SkeletalMeshRef
		{
			[NullableContext(2)]
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<USkeletalMesh>(base.NativePtr / (IntPtr)sizeof(void*) + BP_EffectModelSkeletalMesh_C.__PropertyOffset_6);
			}
			[NullableContext(2)]
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_EffectModelSkeletalMesh_C.__PropertyOffset_6, value);
			}
		}

		// Token: 0x170059FF RID: 23039
		// (get) Token: 0x06026EA4 RID: 159396 RVA: 0x009E54BC File Offset: 0x009E36BC
		// (set) Token: 0x06026EA5 RID: 159397 RVA: 0x009E54D0 File Offset: 0x009E36D0
		[Nullable(2)]
		public unsafe UAnimationAsset AnimationRef
		{
			[NullableContext(2)]
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UAnimationAsset>(base.NativePtr / (IntPtr)sizeof(void*) + BP_EffectModelSkeletalMesh_C.__PropertyOffset_7);
			}
			[NullableContext(2)]
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_EffectModelSkeletalMesh_C.__PropertyOffset_7, value);
			}
		}

		// Token: 0x06026EA6 RID: 159398 RVA: 0x009E54E5 File Offset: 0x009E36E5
		protected BP_EffectModelSkeletalMesh_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x040144ED RID: 83181
		public new const string __ObjectPath = "/Game/Aki/Effect/Setting/EffectDataAsset/BP_EffectModelSkeletalMesh.BP_EffectModelSkeletalMesh_C";

		// Token: 0x040144EE RID: 83182
		private static IntPtr _ClassPtr;

		// Token: 0x040144EF RID: 83183
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x040144F0 RID: 83184
		internal new static int __PropertyOffset_0;

		// Token: 0x040144F1 RID: 83185
		internal new static int __PropertyOffset_1;

		// Token: 0x040144F2 RID: 83186
		internal new static int __PropertyOffset_2;

		// Token: 0x040144F3 RID: 83187
		[Nullable(2)]
		private FKuroCurveVector _Location;

		// Token: 0x040144F4 RID: 83188
		internal new static int __PropertyOffset_3;

		// Token: 0x040144F5 RID: 83189
		[Nullable(2)]
		private FKuroCurveVector _Rotation;

		// Token: 0x040144F6 RID: 83190
		internal new static int __PropertyOffset_4;

		// Token: 0x040144F7 RID: 83191
		[Nullable(2)]
		private FKuroCurveVector _Scale;

		// Token: 0x040144F8 RID: 83192
		internal new static int __PropertyOffset_5;

		// Token: 0x040144F9 RID: 83193
		internal new static int __PropertyOffset_6;

		// Token: 0x040144FA RID: 83194
		internal new static int __PropertyOffset_7;
	}
}
