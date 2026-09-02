using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Render.RuntimeBP.PCG.GPUGrassInteraction
{
	// Token: 0x02003C14 RID: 15380
	[NullableContext(1)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Render/RuntimeBP/PCG/GPUGrassInteraction/BP_GPUFoliageInteraction.BP_GPUFoliageInteraction_C")]
	[UnrealStructLayout(200, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 200)]
	public class BP_GPUFoliageInteraction_C : UPrimaryDataAsset, IUnrealUObject, IUnrealObject
	{
		// Token: 0x06022FE9 RID: 143337 RVA: 0x00975813 File Offset: 0x00973A13
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_GPUFoliageInteraction_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Render/RuntimeBP/PCG/GPUGrassInteraction/BP_GPUFoliageInteraction.BP_GPUFoliageInteraction_C");
			}
			return BP_GPUFoliageInteraction_C._ClassPtr;
		}

		// Token: 0x06022FEA RID: 143338 RVA: 0x00975838 File Offset: 0x00973A38
		public BP_GPUFoliageInteraction_C() : this(BuiltinUtils.AllocNativeUObject(BP_GPUFoliageInteraction_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x06022FEB RID: 143339 RVA: 0x00975860 File Offset: 0x00973A60
		public BP_GPUFoliageInteraction_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_GPUFoliageInteraction_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x170043D8 RID: 17368
		// (get) Token: 0x06022FEC RID: 143340 RVA: 0x00975893 File Offset: 0x00973A93
		// (set) Token: 0x06022FED RID: 143341 RVA: 0x009758A3 File Offset: 0x00973AA3
		public unsafe int Bone_Count
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_GPUFoliageInteraction_C.__PropertyOffset_0);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_GPUFoliageInteraction_C.__PropertyOffset_0) = value;
			}
		}

		// Token: 0x170043D9 RID: 17369
		// (get) Token: 0x06022FEE RID: 143342 RVA: 0x009758B4 File Offset: 0x00973AB4
		// (set) Token: 0x06022FEF RID: 143343 RVA: 0x009758ED File Offset: 0x00973AED
		public TArray<int> Parent_ID
		{
			get
			{
				base.FastCheckIsValid();
				TArray<int> result;
				if ((result = this._Parent_ID) == null)
				{
					result = (this._Parent_ID = new TArray<int>(base.NativePtr + (IntPtr)BP_GPUFoliageInteraction_C.__PropertyOffset_1, this));
				}
				return result;
			}
			set
			{
				this.Parent_ID.CopyAssign(value);
			}
		}

		// Token: 0x170043DA RID: 17370
		// (get) Token: 0x06022FF0 RID: 143344 RVA: 0x009758FC File Offset: 0x00973AFC
		// (set) Token: 0x06022FF1 RID: 143345 RVA: 0x00975935 File Offset: 0x00973B35
		public TArray<int> PPID
		{
			get
			{
				base.FastCheckIsValid();
				TArray<int> result;
				if ((result = this._PPID) == null)
				{
					result = (this._PPID = new TArray<int>(base.NativePtr + (IntPtr)BP_GPUFoliageInteraction_C.__PropertyOffset_2, this));
				}
				return result;
			}
			set
			{
				this.PPID.CopyAssign(value);
			}
		}

		// Token: 0x170043DB RID: 17371
		// (get) Token: 0x06022FF2 RID: 143346 RVA: 0x00975944 File Offset: 0x00973B44
		// (set) Token: 0x06022FF3 RID: 143347 RVA: 0x0097597D File Offset: 0x00973B7D
		public TArray<int> Child_ID
		{
			get
			{
				base.FastCheckIsValid();
				TArray<int> result;
				if ((result = this._Child_ID) == null)
				{
					result = (this._Child_ID = new TArray<int>(base.NativePtr + (IntPtr)BP_GPUFoliageInteraction_C.__PropertyOffset_3, this));
				}
				return result;
			}
			set
			{
				this.Child_ID.CopyAssign(value);
			}
		}

		// Token: 0x170043DC RID: 17372
		// (get) Token: 0x06022FF4 RID: 143348 RVA: 0x0097598C File Offset: 0x00973B8C
		// (set) Token: 0x06022FF5 RID: 143349 RVA: 0x009759C5 File Offset: 0x00973BC5
		public TArray<float> BoneMask
		{
			get
			{
				base.FastCheckIsValid();
				TArray<float> result;
				if ((result = this._BoneMask) == null)
				{
					result = (this._BoneMask = new TArray<float>(base.NativePtr + (IntPtr)BP_GPUFoliageInteraction_C.__PropertyOffset_4, this));
				}
				return result;
			}
			set
			{
				this.BoneMask.CopyAssign(value);
			}
		}

		// Token: 0x170043DD RID: 17373
		// (get) Token: 0x06022FF6 RID: 143350 RVA: 0x009759D4 File Offset: 0x00973BD4
		// (set) Token: 0x06022FF7 RID: 143351 RVA: 0x00975A0D File Offset: 0x00973C0D
		public TArray<FMatrix> Transform
		{
			get
			{
				base.FastCheckIsValid();
				TArray<FMatrix> result;
				if ((result = this._Transform) == null)
				{
					result = (this._Transform = new TArray<FMatrix>(base.NativePtr + (IntPtr)BP_GPUFoliageInteraction_C.__PropertyOffset_5, this));
				}
				return result;
			}
			set
			{
				this.Transform.CopyAssign(value);
			}
		}

		// Token: 0x170043DE RID: 17374
		// (get) Token: 0x06022FF8 RID: 143352 RVA: 0x00975A1C File Offset: 0x00973C1C
		// (set) Token: 0x06022FF9 RID: 143353 RVA: 0x00975A55 File Offset: 0x00973C55
		public TArray<FQuat> Quat
		{
			get
			{
				base.FastCheckIsValid();
				TArray<FQuat> result;
				if ((result = this._Quat) == null)
				{
					result = (this._Quat = new TArray<FQuat>(base.NativePtr + (IntPtr)BP_GPUFoliageInteraction_C.__PropertyOffset_6, this));
				}
				return result;
			}
			set
			{
				this.Quat.CopyAssign(value);
			}
		}

		// Token: 0x170043DF RID: 17375
		// (get) Token: 0x06022FFA RID: 143354 RVA: 0x00975A64 File Offset: 0x00973C64
		// (set) Token: 0x06022FFB RID: 143355 RVA: 0x00975A9D File Offset: 0x00973C9D
		public TArray<FVector> P
		{
			get
			{
				base.FastCheckIsValid();
				TArray<FVector> result;
				if ((result = this._P) == null)
				{
					result = (this._P = new TArray<FVector>(base.NativePtr + (IntPtr)BP_GPUFoliageInteraction_C.__PropertyOffset_7, this));
				}
				return result;
			}
			set
			{
				this.P.CopyAssign(value);
			}
		}

		// Token: 0x06022FFC RID: 143356 RVA: 0x00975AAB File Offset: 0x00973CAB
		protected BP_GPUFoliageInteraction_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x04011C7F RID: 72831
		public new const string __ObjectPath = "/Game/Aki/Render/RuntimeBP/PCG/GPUGrassInteraction/BP_GPUFoliageInteraction.BP_GPUFoliageInteraction_C";

		// Token: 0x04011C80 RID: 72832
		private static IntPtr _ClassPtr;

		// Token: 0x04011C81 RID: 72833
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x04011C82 RID: 72834
		internal static int __PropertyOffset_0;

		// Token: 0x04011C83 RID: 72835
		internal static int __PropertyOffset_1;

		// Token: 0x04011C84 RID: 72836
		[Nullable(2)]
		private TArray<int> _Parent_ID;

		// Token: 0x04011C85 RID: 72837
		internal static int __PropertyOffset_2;

		// Token: 0x04011C86 RID: 72838
		[Nullable(2)]
		private TArray<int> _PPID;

		// Token: 0x04011C87 RID: 72839
		internal static int __PropertyOffset_3;

		// Token: 0x04011C88 RID: 72840
		[Nullable(2)]
		private TArray<int> _Child_ID;

		// Token: 0x04011C89 RID: 72841
		internal static int __PropertyOffset_4;

		// Token: 0x04011C8A RID: 72842
		[Nullable(2)]
		private TArray<float> _BoneMask;

		// Token: 0x04011C8B RID: 72843
		internal static int __PropertyOffset_5;

		// Token: 0x04011C8C RID: 72844
		[Nullable(2)]
		private TArray<FMatrix> _Transform;

		// Token: 0x04011C8D RID: 72845
		internal static int __PropertyOffset_6;

		// Token: 0x04011C8E RID: 72846
		[Nullable(2)]
		private TArray<FQuat> _Quat;

		// Token: 0x04011C8F RID: 72847
		internal static int __PropertyOffset_7;

		// Token: 0x04011C90 RID: 72848
		[Nullable(2)]
		private TArray<FVector> _P;
	}
}
