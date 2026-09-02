using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Render.RuntimeBP.Rain2.Configs
{
	// Token: 0x02003B41 RID: 15169
	[NullableContext(1)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Render/RuntimeBP/Rain2/Configs/PDA_RainConfig_CommonDrop.PDA_RainConfig_CommonDrop_C")]
	[UnrealStructLayout(480, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 480)]
	public class PDA_RainConfig_CommonDrop_C : UPrimaryDataAsset, IUnrealUObject, IUnrealObject
	{
		// Token: 0x06020DC6 RID: 134598 RVA: 0x00938F5B File Offset: 0x0093715B
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (PDA_RainConfig_CommonDrop_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Render/RuntimeBP/Rain2/Configs/PDA_RainConfig_CommonDrop.PDA_RainConfig_CommonDrop_C");
			}
			return PDA_RainConfig_CommonDrop_C._ClassPtr;
		}

		// Token: 0x06020DC7 RID: 134599 RVA: 0x00938F80 File Offset: 0x00937180
		public PDA_RainConfig_CommonDrop_C() : this(BuiltinUtils.AllocNativeUObject(PDA_RainConfig_CommonDrop_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x06020DC8 RID: 134600 RVA: 0x00938FA8 File Offset: 0x009371A8
		public PDA_RainConfig_CommonDrop_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(PDA_RainConfig_CommonDrop_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x170037AB RID: 14251
		// (get) Token: 0x06020DC9 RID: 134601 RVA: 0x00938FDC File Offset: 0x009371DC
		// (set) Token: 0x06020DCA RID: 134602 RVA: 0x00939015 File Offset: 0x00937215
		public TArray<UMaterialInterface> Materials
		{
			get
			{
				base.FastCheckIsValid();
				TArray<UMaterialInterface> result;
				if ((result = this._Materials) == null)
				{
					result = (this._Materials = new TArray<UMaterialInterface>(base.NativePtr + (IntPtr)PDA_RainConfig_CommonDrop_C.__PropertyOffset_0, this));
				}
				return result;
			}
			set
			{
				this.Materials.CopyAssign(value);
			}
		}

		// Token: 0x170037AC RID: 14252
		// (get) Token: 0x06020DCB RID: 134603 RVA: 0x00939024 File Offset: 0x00937224
		// (set) Token: 0x06020DCC RID: 134604 RVA: 0x0093905D File Offset: 0x0093725D
		public TArray<UStaticMesh> Meshes
		{
			get
			{
				base.FastCheckIsValid();
				TArray<UStaticMesh> result;
				if ((result = this._Meshes) == null)
				{
					result = (this._Meshes = new TArray<UStaticMesh>(base.NativePtr + (IntPtr)PDA_RainConfig_CommonDrop_C.__PropertyOffset_1, this));
				}
				return result;
			}
			set
			{
				this.Meshes.CopyAssign(value);
			}
		}

		// Token: 0x170037AD RID: 14253
		// (get) Token: 0x06020DCD RID: 134605 RVA: 0x0093906C File Offset: 0x0093726C
		// (set) Token: 0x06020DCE RID: 134606 RVA: 0x009390A5 File Offset: 0x009372A5
		public TArray<SCommonRainSpawnerConfig> Spawners
		{
			get
			{
				base.FastCheckIsValid();
				TArray<SCommonRainSpawnerConfig> result;
				if ((result = this._Spawners) == null)
				{
					result = (this._Spawners = new TArray<SCommonRainSpawnerConfig>(base.NativePtr + (IntPtr)PDA_RainConfig_CommonDrop_C.__PropertyOffset_2, this));
				}
				return result;
			}
			set
			{
				this.Spawners.CopyAssign(value);
			}
		}

		// Token: 0x170037AE RID: 14254
		// (get) Token: 0x06020DCF RID: 134607 RVA: 0x009390B3 File Offset: 0x009372B3
		// (set) Token: 0x06020DD0 RID: 134608 RVA: 0x009390C7 File Offset: 0x009372C7
		public unsafe FVector Gravity
		{
			get
			{
				return *(base.NativePtr + (IntPtr)PDA_RainConfig_CommonDrop_C.__PropertyOffset_3);
			}
			set
			{
				*(base.NativePtr + (IntPtr)PDA_RainConfig_CommonDrop_C.__PropertyOffset_3) = value;
			}
		}

		// Token: 0x170037AF RID: 14255
		// (get) Token: 0x06020DD1 RID: 134609 RVA: 0x009390DC File Offset: 0x009372DC
		// (set) Token: 0x06020DD2 RID: 134610 RVA: 0x009390F0 File Offset: 0x009372F0
		public unsafe FVector Wind
		{
			get
			{
				return *(base.NativePtr + (IntPtr)PDA_RainConfig_CommonDrop_C.__PropertyOffset_4);
			}
			set
			{
				*(base.NativePtr + (IntPtr)PDA_RainConfig_CommonDrop_C.__PropertyOffset_4) = value;
			}
		}

		// Token: 0x170037B0 RID: 14256
		// (get) Token: 0x06020DD3 RID: 134611 RVA: 0x00939105 File Offset: 0x00937305
		// (set) Token: 0x06020DD4 RID: 134612 RVA: 0x00939115 File Offset: 0x00937315
		public unsafe float Drag
		{
			get
			{
				return *(base.NativePtr + (IntPtr)PDA_RainConfig_CommonDrop_C.__PropertyOffset_5);
			}
			set
			{
				*(base.NativePtr + (IntPtr)PDA_RainConfig_CommonDrop_C.__PropertyOffset_5) = value;
			}
		}

		// Token: 0x170037B1 RID: 14257
		// (get) Token: 0x06020DD5 RID: 134613 RVA: 0x00939128 File Offset: 0x00937328
		// (set) Token: 0x06020DD6 RID: 134614 RVA: 0x00939161 File Offset: 0x00937361
		public FKuroCurveFloat OpacityCurve
		{
			get
			{
				base.FastCheckIsValid();
				FKuroCurveFloat result;
				if ((result = this._OpacityCurve) == null)
				{
					result = (this._OpacityCurve = new FKuroCurveFloat(base.NativePtr + (IntPtr)PDA_RainConfig_CommonDrop_C.__PropertyOffset_6, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FKuroCurveFloat.StaticStruct(), base.NativePtr + (IntPtr)PDA_RainConfig_CommonDrop_C.__PropertyOffset_6, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170037B2 RID: 14258
		// (get) Token: 0x06020DD7 RID: 134615 RVA: 0x00939184 File Offset: 0x00937384
		// (set) Token: 0x06020DD8 RID: 134616 RVA: 0x009391BD File Offset: 0x009373BD
		public FKuroCurveFloat StretchCurve
		{
			get
			{
				base.FastCheckIsValid();
				FKuroCurveFloat result;
				if ((result = this._StretchCurve) == null)
				{
					result = (this._StretchCurve = new FKuroCurveFloat(base.NativePtr + (IntPtr)PDA_RainConfig_CommonDrop_C.__PropertyOffset_7, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FKuroCurveFloat.StaticStruct(), base.NativePtr + (IntPtr)PDA_RainConfig_CommonDrop_C.__PropertyOffset_7, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170037B3 RID: 14259
		// (get) Token: 0x06020DD9 RID: 134617 RVA: 0x009391DE File Offset: 0x009373DE
		// (set) Token: 0x06020DDA RID: 134618 RVA: 0x009391EE File Offset: 0x009373EE
		public unsafe float CycleBoxX
		{
			get
			{
				return *(base.NativePtr + (IntPtr)PDA_RainConfig_CommonDrop_C.__PropertyOffset_8);
			}
			set
			{
				*(base.NativePtr + (IntPtr)PDA_RainConfig_CommonDrop_C.__PropertyOffset_8) = value;
			}
		}

		// Token: 0x170037B4 RID: 14260
		// (get) Token: 0x06020DDB RID: 134619 RVA: 0x009391FF File Offset: 0x009373FF
		// (set) Token: 0x06020DDC RID: 134620 RVA: 0x0093920F File Offset: 0x0093740F
		public unsafe float CycleBoxY
		{
			get
			{
				return *(base.NativePtr + (IntPtr)PDA_RainConfig_CommonDrop_C.__PropertyOffset_9);
			}
			set
			{
				*(base.NativePtr + (IntPtr)PDA_RainConfig_CommonDrop_C.__PropertyOffset_9) = value;
			}
		}

		// Token: 0x170037B5 RID: 14261
		// (get) Token: 0x06020DDD RID: 134621 RVA: 0x00939220 File Offset: 0x00937420
		// (set) Token: 0x06020DDE RID: 134622 RVA: 0x00939230 File Offset: 0x00937430
		public unsafe float CycleBoxZ_Positive
		{
			get
			{
				return *(base.NativePtr + (IntPtr)PDA_RainConfig_CommonDrop_C.__PropertyOffset_10);
			}
			set
			{
				*(base.NativePtr + (IntPtr)PDA_RainConfig_CommonDrop_C.__PropertyOffset_10) = value;
			}
		}

		// Token: 0x170037B6 RID: 14262
		// (get) Token: 0x06020DDF RID: 134623 RVA: 0x00939241 File Offset: 0x00937441
		// (set) Token: 0x06020DE0 RID: 134624 RVA: 0x00939251 File Offset: 0x00937451
		public unsafe float CycleBoxZ_Negative
		{
			get
			{
				return *(base.NativePtr + (IntPtr)PDA_RainConfig_CommonDrop_C.__PropertyOffset_11);
			}
			set
			{
				*(base.NativePtr + (IntPtr)PDA_RainConfig_CommonDrop_C.__PropertyOffset_11) = value;
			}
		}

		// Token: 0x170037B7 RID: 14263
		// (get) Token: 0x06020DE1 RID: 134625 RVA: 0x00939262 File Offset: 0x00937462
		// (set) Token: 0x06020DE2 RID: 134626 RVA: 0x00939276 File Offset: 0x00937476
		[Nullable(2)]
		public unsafe UNiagaraSystem Niagara
		{
			[NullableContext(2)]
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UNiagaraSystem>(base.NativePtr / (IntPtr)sizeof(void*) + PDA_RainConfig_CommonDrop_C.__PropertyOffset_12);
			}
			[NullableContext(2)]
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + PDA_RainConfig_CommonDrop_C.__PropertyOffset_12, value);
			}
		}

		// Token: 0x170037B8 RID: 14264
		// (get) Token: 0x06020DE3 RID: 134627 RVA: 0x0093928B File Offset: 0x0093748B
		// (set) Token: 0x06020DE4 RID: 134628 RVA: 0x0093929F File Offset: 0x0093749F
		[Nullable(2)]
		public unsafe UAkAudioEvent AudioEvent
		{
			[NullableContext(2)]
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UAkAudioEvent>(base.NativePtr / (IntPtr)sizeof(void*) + PDA_RainConfig_CommonDrop_C.__PropertyOffset_13);
			}
			[NullableContext(2)]
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + PDA_RainConfig_CommonDrop_C.__PropertyOffset_13, value);
			}
		}

		// Token: 0x06020DE5 RID: 134629 RVA: 0x009392B4 File Offset: 0x009374B4
		protected PDA_RainConfig_CommonDrop_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x040107B2 RID: 67506
		public new const string __ObjectPath = "/Game/Aki/Render/RuntimeBP/Rain2/Configs/PDA_RainConfig_CommonDrop.PDA_RainConfig_CommonDrop_C";

		// Token: 0x040107B3 RID: 67507
		private static IntPtr _ClassPtr;

		// Token: 0x040107B4 RID: 67508
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x040107B5 RID: 67509
		internal static int __PropertyOffset_0;

		// Token: 0x040107B6 RID: 67510
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private TArray<UMaterialInterface> _Materials;

		// Token: 0x040107B7 RID: 67511
		internal static int __PropertyOffset_1;

		// Token: 0x040107B8 RID: 67512
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private TArray<UStaticMesh> _Meshes;

		// Token: 0x040107B9 RID: 67513
		internal static int __PropertyOffset_2;

		// Token: 0x040107BA RID: 67514
		[Nullable(2)]
		private TArray<SCommonRainSpawnerConfig> _Spawners;

		// Token: 0x040107BB RID: 67515
		internal static int __PropertyOffset_3;

		// Token: 0x040107BC RID: 67516
		internal static int __PropertyOffset_4;

		// Token: 0x040107BD RID: 67517
		internal static int __PropertyOffset_5;

		// Token: 0x040107BE RID: 67518
		internal static int __PropertyOffset_6;

		// Token: 0x040107BF RID: 67519
		[Nullable(2)]
		private FKuroCurveFloat _OpacityCurve;

		// Token: 0x040107C0 RID: 67520
		internal static int __PropertyOffset_7;

		// Token: 0x040107C1 RID: 67521
		[Nullable(2)]
		private FKuroCurveFloat _StretchCurve;

		// Token: 0x040107C2 RID: 67522
		internal static int __PropertyOffset_8;

		// Token: 0x040107C3 RID: 67523
		internal static int __PropertyOffset_9;

		// Token: 0x040107C4 RID: 67524
		internal static int __PropertyOffset_10;

		// Token: 0x040107C5 RID: 67525
		internal static int __PropertyOffset_11;

		// Token: 0x040107C6 RID: 67526
		internal static int __PropertyOffset_12;

		// Token: 0x040107C7 RID: 67527
		internal static int __PropertyOffset_13;
	}
}
