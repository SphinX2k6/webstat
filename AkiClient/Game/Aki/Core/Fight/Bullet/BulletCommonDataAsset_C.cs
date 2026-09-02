using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Core.Fight.Bullet
{
	// Token: 0x02003F83 RID: 16259
	[UnrealObjectPath("/Game/Aki/Core/Fight/Bullet/BulletCommonDataAsset.BulletCommonDataAsset_C")]
	[UnrealStructLayout(240, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 236)]
	public class BulletCommonDataAsset_C : UPrimaryDataAsset, IUnrealUObject, IUnrealObject
	{
		// Token: 0x06028A96 RID: 166550 RVA: 0x00A11F8A File Offset: 0x00A1018A
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BulletCommonDataAsset_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Core/Fight/Bullet/BulletCommonDataAsset.BulletCommonDataAsset_C");
			}
			return BulletCommonDataAsset_C._ClassPtr;
		}

		// Token: 0x06028A97 RID: 166551 RVA: 0x00A11FB0 File Offset: 0x00A101B0
		public BulletCommonDataAsset_C() : this(BuiltinUtils.AllocNativeUObject(BulletCommonDataAsset_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x06028A98 RID: 166552 RVA: 0x00A11FD8 File Offset: 0x00A101D8
		[NullableContext(1)]
		public BulletCommonDataAsset_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BulletCommonDataAsset_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x17006355 RID: 25429
		// (get) Token: 0x06028A99 RID: 166553 RVA: 0x00A1200C File Offset: 0x00A1020C
		// (set) Token: 0x06028A9A RID: 166554 RVA: 0x00A12045 File Offset: 0x00A10245
		[Nullable(new byte[]
		{
			1,
			0
		})]
		public TArray<TEnumAsByte<EObjectTypeQuery>> TakeAim
		{
			[return: Nullable(new byte[]
			{
				1,
				0
			})]
			get
			{
				base.FastCheckIsValid();
				TArray<TEnumAsByte<EObjectTypeQuery>> result;
				if ((result = this._TakeAim) == null)
				{
					result = (this._TakeAim = new TArray<TEnumAsByte<EObjectTypeQuery>>(base.NativePtr + (IntPtr)BulletCommonDataAsset_C.__PropertyOffset_0, this));
				}
				return result;
			}
			[param: Nullable(new byte[]
			{
				1,
				0
			})]
			set
			{
				this.TakeAim.CopyAssign(value);
			}
		}

		// Token: 0x17006356 RID: 25430
		// (get) Token: 0x06028A9B RID: 166555 RVA: 0x00A12054 File Offset: 0x00A10254
		// (set) Token: 0x06028A9C RID: 166556 RVA: 0x00A1208D File Offset: 0x00A1028D
		[Nullable(new byte[]
		{
			1,
			0
		})]
		public TArray<TEnumAsByte<EObjectTypeQuery>> Obstacles
		{
			[return: Nullable(new byte[]
			{
				1,
				0
			})]
			get
			{
				base.FastCheckIsValid();
				TArray<TEnumAsByte<EObjectTypeQuery>> result;
				if ((result = this._Obstacles) == null)
				{
					result = (this._Obstacles = new TArray<TEnumAsByte<EObjectTypeQuery>>(base.NativePtr + (IntPtr)BulletCommonDataAsset_C.__PropertyOffset_1, this));
				}
				return result;
			}
			[param: Nullable(new byte[]
			{
				1,
				0
			})]
			set
			{
				this.Obstacles.CopyAssign(value);
			}
		}

		// Token: 0x17006357 RID: 25431
		// (get) Token: 0x06028A9D RID: 166557 RVA: 0x00A1209C File Offset: 0x00A1029C
		// (set) Token: 0x06028A9E RID: 166558 RVA: 0x00A120D5 File Offset: 0x00A102D5
		[Nullable(new byte[]
		{
			1,
			0
		})]
		public TArray<TEnumAsByte<EObjectTypeQuery>> HitPoint
		{
			[return: Nullable(new byte[]
			{
				1,
				0
			})]
			get
			{
				base.FastCheckIsValid();
				TArray<TEnumAsByte<EObjectTypeQuery>> result;
				if ((result = this._HitPoint) == null)
				{
					result = (this._HitPoint = new TArray<TEnumAsByte<EObjectTypeQuery>>(base.NativePtr + (IntPtr)BulletCommonDataAsset_C.__PropertyOffset_2, this));
				}
				return result;
			}
			[param: Nullable(new byte[]
			{
				1,
				0
			})]
			set
			{
				this.HitPoint.CopyAssign(value);
			}
		}

		// Token: 0x17006358 RID: 25432
		// (get) Token: 0x06028A9F RID: 166559 RVA: 0x00A120E4 File Offset: 0x00A102E4
		// (set) Token: 0x06028AA0 RID: 166560 RVA: 0x00A1211D File Offset: 0x00A1031D
		[Nullable(new byte[]
		{
			1,
			0
		})]
		public TArray<TEnumAsByte<EObjectTypeQuery>> FastMoveTraceBullet_Type1
		{
			[return: Nullable(new byte[]
			{
				1,
				0
			})]
			get
			{
				base.FastCheckIsValid();
				TArray<TEnumAsByte<EObjectTypeQuery>> result;
				if ((result = this._FastMoveTraceBullet_Type1) == null)
				{
					result = (this._FastMoveTraceBullet_Type1 = new TArray<TEnumAsByte<EObjectTypeQuery>>(base.NativePtr + (IntPtr)BulletCommonDataAsset_C.__PropertyOffset_3, this));
				}
				return result;
			}
			[param: Nullable(new byte[]
			{
				1,
				0
			})]
			set
			{
				this.FastMoveTraceBullet_Type1.CopyAssign(value);
			}
		}

		// Token: 0x17006359 RID: 25433
		// (get) Token: 0x06028AA1 RID: 166561 RVA: 0x00A1212C File Offset: 0x00A1032C
		// (set) Token: 0x06028AA2 RID: 166562 RVA: 0x00A12165 File Offset: 0x00A10365
		[Nullable(new byte[]
		{
			1,
			0
		})]
		public TArray<TEnumAsByte<EObjectTypeQuery>> FastMoveTraceBullet_Type2
		{
			[return: Nullable(new byte[]
			{
				1,
				0
			})]
			get
			{
				base.FastCheckIsValid();
				TArray<TEnumAsByte<EObjectTypeQuery>> result;
				if ((result = this._FastMoveTraceBullet_Type2) == null)
				{
					result = (this._FastMoveTraceBullet_Type2 = new TArray<TEnumAsByte<EObjectTypeQuery>>(base.NativePtr + (IntPtr)BulletCommonDataAsset_C.__PropertyOffset_4, this));
				}
				return result;
			}
			[param: Nullable(new byte[]
			{
				1,
				0
			})]
			set
			{
				this.FastMoveTraceBullet_Type2.CopyAssign(value);
			}
		}

		// Token: 0x1700635A RID: 25434
		// (get) Token: 0x06028AA3 RID: 166563 RVA: 0x00A12174 File Offset: 0x00A10374
		// (set) Token: 0x06028AA4 RID: 166564 RVA: 0x00A121AD File Offset: 0x00A103AD
		[Nullable(new byte[]
		{
			1,
			0
		})]
		public TArray<TEnumAsByte<EObjectTypeQuery>> FastMoveTraceBullet_Type3
		{
			[return: Nullable(new byte[]
			{
				1,
				0
			})]
			get
			{
				base.FastCheckIsValid();
				TArray<TEnumAsByte<EObjectTypeQuery>> result;
				if ((result = this._FastMoveTraceBullet_Type3) == null)
				{
					result = (this._FastMoveTraceBullet_Type3 = new TArray<TEnumAsByte<EObjectTypeQuery>>(base.NativePtr + (IntPtr)BulletCommonDataAsset_C.__PropertyOffset_5, this));
				}
				return result;
			}
			[param: Nullable(new byte[]
			{
				1,
				0
			})]
			set
			{
				this.FastMoveTraceBullet_Type3.CopyAssign(value);
			}
		}

		// Token: 0x1700635B RID: 25435
		// (get) Token: 0x06028AA5 RID: 166565 RVA: 0x00A121BC File Offset: 0x00A103BC
		// (set) Token: 0x06028AA6 RID: 166566 RVA: 0x00A121F5 File Offset: 0x00A103F5
		[Nullable(new byte[]
		{
			1,
			0
		})]
		public TArray<TEnumAsByte<EObjectTypeQuery>> FastMoveTraceBullet_Type1_Special
		{
			[return: Nullable(new byte[]
			{
				1,
				0
			})]
			get
			{
				base.FastCheckIsValid();
				TArray<TEnumAsByte<EObjectTypeQuery>> result;
				if ((result = this._FastMoveTraceBullet_Type1_Special) == null)
				{
					result = (this._FastMoveTraceBullet_Type1_Special = new TArray<TEnumAsByte<EObjectTypeQuery>>(base.NativePtr + (IntPtr)BulletCommonDataAsset_C.__PropertyOffset_6, this));
				}
				return result;
			}
			[param: Nullable(new byte[]
			{
				1,
				0
			})]
			set
			{
				this.FastMoveTraceBullet_Type1_Special.CopyAssign(value);
			}
		}

		// Token: 0x1700635C RID: 25436
		// (get) Token: 0x06028AA7 RID: 166567 RVA: 0x00A12204 File Offset: 0x00A10404
		// (set) Token: 0x06028AA8 RID: 166568 RVA: 0x00A1223D File Offset: 0x00A1043D
		[Nullable(new byte[]
		{
			1,
			0
		})]
		public TArray<TEnumAsByte<EObjectTypeQuery>> FastMoveTraceBullet_Type2_Special
		{
			[return: Nullable(new byte[]
			{
				1,
				0
			})]
			get
			{
				base.FastCheckIsValid();
				TArray<TEnumAsByte<EObjectTypeQuery>> result;
				if ((result = this._FastMoveTraceBullet_Type2_Special) == null)
				{
					result = (this._FastMoveTraceBullet_Type2_Special = new TArray<TEnumAsByte<EObjectTypeQuery>>(base.NativePtr + (IntPtr)BulletCommonDataAsset_C.__PropertyOffset_7, this));
				}
				return result;
			}
			[param: Nullable(new byte[]
			{
				1,
				0
			})]
			set
			{
				this.FastMoveTraceBullet_Type2_Special.CopyAssign(value);
			}
		}

		// Token: 0x1700635D RID: 25437
		// (get) Token: 0x06028AA9 RID: 166569 RVA: 0x00A1224C File Offset: 0x00A1044C
		// (set) Token: 0x06028AAA RID: 166570 RVA: 0x00A12285 File Offset: 0x00A10485
		[Nullable(new byte[]
		{
			1,
			0
		})]
		public TArray<TEnumAsByte<EObjectTypeQuery>> FastMoveTraceBullet_Only_Bullet
		{
			[return: Nullable(new byte[]
			{
				1,
				0
			})]
			get
			{
				base.FastCheckIsValid();
				TArray<TEnumAsByte<EObjectTypeQuery>> result;
				if ((result = this._FastMoveTraceBullet_Only_Bullet) == null)
				{
					result = (this._FastMoveTraceBullet_Only_Bullet = new TArray<TEnumAsByte<EObjectTypeQuery>>(base.NativePtr + (IntPtr)BulletCommonDataAsset_C.__PropertyOffset_8, this));
				}
				return result;
			}
			[param: Nullable(new byte[]
			{
				1,
				0
			})]
			set
			{
				this.FastMoveTraceBullet_Only_Bullet.CopyAssign(value);
			}
		}

		// Token: 0x1700635E RID: 25438
		// (get) Token: 0x06028AAB RID: 166571 RVA: 0x00A12293 File Offset: 0x00A10493
		// (set) Token: 0x06028AAC RID: 166572 RVA: 0x00A122A3 File Offset: 0x00A104A3
		public unsafe float OnHitMaterialDelay
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BulletCommonDataAsset_C.__PropertyOffset_9);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BulletCommonDataAsset_C.__PropertyOffset_9) = value;
			}
		}

		// Token: 0x1700635F RID: 25439
		// (get) Token: 0x06028AAD RID: 166573 RVA: 0x00A122B4 File Offset: 0x00A104B4
		// (set) Token: 0x06028AAE RID: 166574 RVA: 0x00A122C4 File Offset: 0x00A104C4
		public unsafe float OnHitMaterialDuration
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BulletCommonDataAsset_C.__PropertyOffset_10);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BulletCommonDataAsset_C.__PropertyOffset_10) = value;
			}
		}

		// Token: 0x17006360 RID: 25440
		// (get) Token: 0x06028AAF RID: 166575 RVA: 0x00A122D5 File Offset: 0x00A104D5
		// (set) Token: 0x06028AB0 RID: 166576 RVA: 0x00A122E5 File Offset: 0x00A104E5
		public unsafe float OnHitMaterialCd
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BulletCommonDataAsset_C.__PropertyOffset_11);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BulletCommonDataAsset_C.__PropertyOffset_11) = value;
			}
		}

		// Token: 0x06028AB1 RID: 166577 RVA: 0x00A122F6 File Offset: 0x00A104F6
		protected BulletCommonDataAsset_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x0401571A RID: 87834
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Core/Fight/Bullet/BulletCommonDataAsset.BulletCommonDataAsset_C";

		// Token: 0x0401571B RID: 87835
		private static IntPtr _ClassPtr;

		// Token: 0x0401571C RID: 87836
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x0401571D RID: 87837
		internal static int __PropertyOffset_0;

		// Token: 0x0401571E RID: 87838
		[Nullable(new byte[]
		{
			2,
			0
		})]
		private TArray<TEnumAsByte<EObjectTypeQuery>> _TakeAim;

		// Token: 0x0401571F RID: 87839
		internal static int __PropertyOffset_1;

		// Token: 0x04015720 RID: 87840
		[Nullable(new byte[]
		{
			2,
			0
		})]
		private TArray<TEnumAsByte<EObjectTypeQuery>> _Obstacles;

		// Token: 0x04015721 RID: 87841
		internal static int __PropertyOffset_2;

		// Token: 0x04015722 RID: 87842
		[Nullable(new byte[]
		{
			2,
			0
		})]
		private TArray<TEnumAsByte<EObjectTypeQuery>> _HitPoint;

		// Token: 0x04015723 RID: 87843
		internal static int __PropertyOffset_3;

		// Token: 0x04015724 RID: 87844
		[Nullable(new byte[]
		{
			2,
			0
		})]
		private TArray<TEnumAsByte<EObjectTypeQuery>> _FastMoveTraceBullet_Type1;

		// Token: 0x04015725 RID: 87845
		internal static int __PropertyOffset_4;

		// Token: 0x04015726 RID: 87846
		[Nullable(new byte[]
		{
			2,
			0
		})]
		private TArray<TEnumAsByte<EObjectTypeQuery>> _FastMoveTraceBullet_Type2;

		// Token: 0x04015727 RID: 87847
		internal static int __PropertyOffset_5;

		// Token: 0x04015728 RID: 87848
		[Nullable(new byte[]
		{
			2,
			0
		})]
		private TArray<TEnumAsByte<EObjectTypeQuery>> _FastMoveTraceBullet_Type3;

		// Token: 0x04015729 RID: 87849
		internal static int __PropertyOffset_6;

		// Token: 0x0401572A RID: 87850
		[Nullable(new byte[]
		{
			2,
			0
		})]
		private TArray<TEnumAsByte<EObjectTypeQuery>> _FastMoveTraceBullet_Type1_Special;

		// Token: 0x0401572B RID: 87851
		internal static int __PropertyOffset_7;

		// Token: 0x0401572C RID: 87852
		[Nullable(new byte[]
		{
			2,
			0
		})]
		private TArray<TEnumAsByte<EObjectTypeQuery>> _FastMoveTraceBullet_Type2_Special;

		// Token: 0x0401572D RID: 87853
		internal static int __PropertyOffset_8;

		// Token: 0x0401572E RID: 87854
		[Nullable(new byte[]
		{
			2,
			0
		})]
		private TArray<TEnumAsByte<EObjectTypeQuery>> _FastMoveTraceBullet_Only_Bullet;

		// Token: 0x0401572F RID: 87855
		internal static int __PropertyOffset_9;

		// Token: 0x04015730 RID: 87856
		internal static int __PropertyOffset_10;

		// Token: 0x04015731 RID: 87857
		internal static int __PropertyOffset_11;
	}
}
