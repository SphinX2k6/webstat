using System;
using System.Runtime.CompilerServices;
using AkiClient.Game.Aki.Render.RuntimeBP.Character.MaterialController;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Data.Gameplay.Tetris
{
	// Token: 0x02003E9B RID: 16027
	[NullableContext(1)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Data/Gameplay/Tetris/Bp_Tetris.Bp_Tetris_C")]
	[UnrealStructLayout(1128, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 1128)]
	public class Bp_Tetris_C : UPrimaryDataAsset, IUnrealUObject, IUnrealObject
	{
		// Token: 0x06027BBE RID: 162750 RVA: 0x009F9432 File Offset: 0x009F7632
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (Bp_Tetris_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Data/Gameplay/Tetris/Bp_Tetris.Bp_Tetris_C");
			}
			return Bp_Tetris_C._ClassPtr;
		}

		// Token: 0x06027BBF RID: 162751 RVA: 0x009F9458 File Offset: 0x009F7658
		public Bp_Tetris_C() : this(BuiltinUtils.AllocNativeUObject(Bp_Tetris_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x06027BC0 RID: 162752 RVA: 0x009F9480 File Offset: 0x009F7680
		public Bp_Tetris_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(Bp_Tetris_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x17005E94 RID: 24212
		// (get) Token: 0x06027BC1 RID: 162753 RVA: 0x009F94B3 File Offset: 0x009F76B3
		// (set) Token: 0x06027BC2 RID: 162754 RVA: 0x009F94C7 File Offset: 0x009F76C7
		public unsafe FVector2D DefaultBoardSize
		{
			get
			{
				return *(base.NativePtr + (IntPtr)Bp_Tetris_C.__PropertyOffset_0);
			}
			set
			{
				*(base.NativePtr + (IntPtr)Bp_Tetris_C.__PropertyOffset_0) = value;
			}
		}

		// Token: 0x17005E95 RID: 24213
		// (get) Token: 0x06027BC3 RID: 162755 RVA: 0x009F94DC File Offset: 0x009F76DC
		// (set) Token: 0x06027BC4 RID: 162756 RVA: 0x009F94EC File Offset: 0x009F76EC
		public unsafe float CubeSize
		{
			get
			{
				return *(base.NativePtr + (IntPtr)Bp_Tetris_C.__PropertyOffset_1);
			}
			set
			{
				*(base.NativePtr + (IntPtr)Bp_Tetris_C.__PropertyOffset_1) = value;
			}
		}

		// Token: 0x17005E96 RID: 24214
		// (get) Token: 0x06027BC5 RID: 162757 RVA: 0x009F94FD File Offset: 0x009F76FD
		// (set) Token: 0x06027BC6 RID: 162758 RVA: 0x009F950D File Offset: 0x009F770D
		public unsafe float CubeControlTime
		{
			get
			{
				return *(base.NativePtr + (IntPtr)Bp_Tetris_C.__PropertyOffset_2);
			}
			set
			{
				*(base.NativePtr + (IntPtr)Bp_Tetris_C.__PropertyOffset_2) = value;
			}
		}

		// Token: 0x17005E97 RID: 24215
		// (get) Token: 0x06027BC7 RID: 162759 RVA: 0x009F951E File Offset: 0x009F771E
		// (set) Token: 0x06027BC8 RID: 162760 RVA: 0x009F952E File Offset: 0x009F772E
		public unsafe float EndlessModeSpeedUpInterval
		{
			get
			{
				return *(base.NativePtr + (IntPtr)Bp_Tetris_C.__PropertyOffset_3);
			}
			set
			{
				*(base.NativePtr + (IntPtr)Bp_Tetris_C.__PropertyOffset_3) = value;
			}
		}

		// Token: 0x17005E98 RID: 24216
		// (get) Token: 0x06027BC9 RID: 162761 RVA: 0x009F953F File Offset: 0x009F773F
		// (set) Token: 0x06027BCA RID: 162762 RVA: 0x009F954F File Offset: 0x009F774F
		public unsafe float SingleControlTimeReduce
		{
			get
			{
				return *(base.NativePtr + (IntPtr)Bp_Tetris_C.__PropertyOffset_4);
			}
			set
			{
				*(base.NativePtr + (IntPtr)Bp_Tetris_C.__PropertyOffset_4) = value;
			}
		}

		// Token: 0x17005E99 RID: 24217
		// (get) Token: 0x06027BCB RID: 162763 RVA: 0x009F9560 File Offset: 0x009F7760
		// (set) Token: 0x06027BCC RID: 162764 RVA: 0x009F9570 File Offset: 0x009F7770
		public unsafe float MinCubeControlTime
		{
			get
			{
				return *(base.NativePtr + (IntPtr)Bp_Tetris_C.__PropertyOffset_5);
			}
			set
			{
				*(base.NativePtr + (IntPtr)Bp_Tetris_C.__PropertyOffset_5) = value;
			}
		}

		// Token: 0x17005E9A RID: 24218
		// (get) Token: 0x06027BCD RID: 162765 RVA: 0x009F9581 File Offset: 0x009F7781
		// (set) Token: 0x06027BCE RID: 162766 RVA: 0x009F9591 File Offset: 0x009F7791
		public unsafe float SpawnNextTetrominoInterval
		{
			get
			{
				return *(base.NativePtr + (IntPtr)Bp_Tetris_C.__PropertyOffset_6);
			}
			set
			{
				*(base.NativePtr + (IntPtr)Bp_Tetris_C.__PropertyOffset_6) = value;
			}
		}

		// Token: 0x17005E9B RID: 24219
		// (get) Token: 0x06027BCF RID: 162767 RVA: 0x009F95A2 File Offset: 0x009F77A2
		// (set) Token: 0x06027BD0 RID: 162768 RVA: 0x009F95B2 File Offset: 0x009F77B2
		public unsafe float PrepareAreaMinY
		{
			get
			{
				return *(base.NativePtr + (IntPtr)Bp_Tetris_C.__PropertyOffset_7);
			}
			set
			{
				*(base.NativePtr + (IntPtr)Bp_Tetris_C.__PropertyOffset_7) = value;
			}
		}

		// Token: 0x17005E9C RID: 24220
		// (get) Token: 0x06027BD1 RID: 162769 RVA: 0x009F95C3 File Offset: 0x009F77C3
		// (set) Token: 0x06027BD2 RID: 162770 RVA: 0x009F95D3 File Offset: 0x009F77D3
		public unsafe float PrepareAreaMaxY
		{
			get
			{
				return *(base.NativePtr + (IntPtr)Bp_Tetris_C.__PropertyOffset_8);
			}
			set
			{
				*(base.NativePtr + (IntPtr)Bp_Tetris_C.__PropertyOffset_8) = value;
			}
		}

		// Token: 0x17005E9D RID: 24221
		// (get) Token: 0x06027BD3 RID: 162771 RVA: 0x009F95E4 File Offset: 0x009F77E4
		// (set) Token: 0x06027BD4 RID: 162772 RVA: 0x009F961D File Offset: 0x009F781D
		public TMap<int, int> ScoreRule
		{
			get
			{
				base.FastCheckIsValid();
				TMap<int, int> result;
				if ((result = this._ScoreRule) == null)
				{
					result = (this._ScoreRule = new TMap<int, int>(base.NativePtr + (IntPtr)Bp_Tetris_C.__PropertyOffset_9, this));
				}
				return result;
			}
			set
			{
				this.ScoreRule.CopyAssign(value);
			}
		}

		// Token: 0x17005E9E RID: 24222
		// (get) Token: 0x06027BD5 RID: 162773 RVA: 0x009F962B File Offset: 0x009F782B
		// (set) Token: 0x06027BD6 RID: 162774 RVA: 0x009F9640 File Offset: 0x009F7840
		public TSoftObjectPtr<EffectModelGroup> NormalModeLineClearEffect
		{
			get
			{
				return new TSoftObjectPtr<EffectModelGroup>(base.NativePtr + (IntPtr)Bp_Tetris_C.__PropertyOffset_10, this);
			}
			set
			{
				FSoftObjectPtr.NativeCopy(base.NativePtr + (IntPtr)Bp_Tetris_C.__PropertyOffset_10, (value != null) ? value.NativePtr : IntPtr.Zero, 1);
			}
		}

		// Token: 0x17005E9F RID: 24223
		// (get) Token: 0x06027BD7 RID: 162775 RVA: 0x009F9665 File Offset: 0x009F7865
		// (set) Token: 0x06027BD8 RID: 162776 RVA: 0x009F967A File Offset: 0x009F787A
		public TSoftObjectPtr<EffectModelGroup> NormalModeTetrominoLockEffect
		{
			get
			{
				return new TSoftObjectPtr<EffectModelGroup>(base.NativePtr + (IntPtr)Bp_Tetris_C.__PropertyOffset_11, this);
			}
			set
			{
				FSoftObjectPtr.NativeCopy(base.NativePtr + (IntPtr)Bp_Tetris_C.__PropertyOffset_11, (value != null) ? value.NativePtr : IntPtr.Zero, 1);
			}
		}

		// Token: 0x17005EA0 RID: 24224
		// (get) Token: 0x06027BD9 RID: 162777 RVA: 0x009F969F File Offset: 0x009F789F
		// (set) Token: 0x06027BDA RID: 162778 RVA: 0x009F96B4 File Offset: 0x009F78B4
		public TSoftObjectPtr<EffectModelGroup> NormalModeTetrominoSpawnEffect
		{
			get
			{
				return new TSoftObjectPtr<EffectModelGroup>(base.NativePtr + (IntPtr)Bp_Tetris_C.__PropertyOffset_12, this);
			}
			set
			{
				FSoftObjectPtr.NativeCopy(base.NativePtr + (IntPtr)Bp_Tetris_C.__PropertyOffset_12, (value != null) ? value.NativePtr : IntPtr.Zero, 1);
			}
		}

		// Token: 0x17005EA1 RID: 24225
		// (get) Token: 0x06027BDB RID: 162779 RVA: 0x009F96D9 File Offset: 0x009F78D9
		// (set) Token: 0x06027BDC RID: 162780 RVA: 0x009F96EE File Offset: 0x009F78EE
		public TSoftObjectPtr<EffectModelGroup> NormalModeTetrominoMoveTrailEffect
		{
			get
			{
				return new TSoftObjectPtr<EffectModelGroup>(base.NativePtr + (IntPtr)Bp_Tetris_C.__PropertyOffset_13, this);
			}
			set
			{
				FSoftObjectPtr.NativeCopy(base.NativePtr + (IntPtr)Bp_Tetris_C.__PropertyOffset_13, (value != null) ? value.NativePtr : IntPtr.Zero, 1);
			}
		}

		// Token: 0x17005EA2 RID: 24226
		// (get) Token: 0x06027BDD RID: 162781 RVA: 0x009F9713 File Offset: 0x009F7913
		// (set) Token: 0x06027BDE RID: 162782 RVA: 0x009F9728 File Offset: 0x009F7928
		public TSoftObjectPtr<EffectModelGroup> NormalModeAreaLoopEffect
		{
			get
			{
				return new TSoftObjectPtr<EffectModelGroup>(base.NativePtr + (IntPtr)Bp_Tetris_C.__PropertyOffset_14, this);
			}
			set
			{
				FSoftObjectPtr.NativeCopy(base.NativePtr + (IntPtr)Bp_Tetris_C.__PropertyOffset_14, (value != null) ? value.NativePtr : IntPtr.Zero, 1);
			}
		}

		// Token: 0x17005EA3 RID: 24227
		// (get) Token: 0x06027BDF RID: 162783 RVA: 0x009F974D File Offset: 0x009F794D
		// (set) Token: 0x06027BE0 RID: 162784 RVA: 0x009F9762 File Offset: 0x009F7962
		public TSoftObjectPtr<EffectModelGroup> NormalModeAreaLoopEffect2
		{
			get
			{
				return new TSoftObjectPtr<EffectModelGroup>(base.NativePtr + (IntPtr)Bp_Tetris_C.__PropertyOffset_15, this);
			}
			set
			{
				FSoftObjectPtr.NativeCopy(base.NativePtr + (IntPtr)Bp_Tetris_C.__PropertyOffset_15, (value != null) ? value.NativePtr : IntPtr.Zero, 1);
			}
		}

		// Token: 0x17005EA4 RID: 24228
		// (get) Token: 0x06027BE1 RID: 162785 RVA: 0x009F9787 File Offset: 0x009F7987
		// (set) Token: 0x06027BE2 RID: 162786 RVA: 0x009F979C File Offset: 0x009F799C
		public TSoftObjectPtr<ItemMaterialControllerActorData> NormalModeMinoDestroyEffect
		{
			get
			{
				return new TSoftObjectPtr<ItemMaterialControllerActorData>(base.NativePtr + (IntPtr)Bp_Tetris_C.__PropertyOffset_16, this);
			}
			set
			{
				FSoftObjectPtr.NativeCopy(base.NativePtr + (IntPtr)Bp_Tetris_C.__PropertyOffset_16, (value != null) ? value.NativePtr : IntPtr.Zero, 1);
			}
		}

		// Token: 0x17005EA5 RID: 24229
		// (get) Token: 0x06027BE3 RID: 162787 RVA: 0x009F97C1 File Offset: 0x009F79C1
		// (set) Token: 0x06027BE4 RID: 162788 RVA: 0x009F97D6 File Offset: 0x009F79D6
		public TSoftObjectPtr<EffectModelGroup> MainLineModeTetrominoSpawnEffect
		{
			get
			{
				return new TSoftObjectPtr<EffectModelGroup>(base.NativePtr + (IntPtr)Bp_Tetris_C.__PropertyOffset_17, this);
			}
			set
			{
				FSoftObjectPtr.NativeCopy(base.NativePtr + (IntPtr)Bp_Tetris_C.__PropertyOffset_17, (value != null) ? value.NativePtr : IntPtr.Zero, 1);
			}
		}

		// Token: 0x17005EA6 RID: 24230
		// (get) Token: 0x06027BE5 RID: 162789 RVA: 0x009F97FB File Offset: 0x009F79FB
		// (set) Token: 0x06027BE6 RID: 162790 RVA: 0x009F9810 File Offset: 0x009F7A10
		public TSoftObjectPtr<EffectModelGroup> MainLineModeTetrominoMoveTrailEffect
		{
			get
			{
				return new TSoftObjectPtr<EffectModelGroup>(base.NativePtr + (IntPtr)Bp_Tetris_C.__PropertyOffset_18, this);
			}
			set
			{
				FSoftObjectPtr.NativeCopy(base.NativePtr + (IntPtr)Bp_Tetris_C.__PropertyOffset_18, (value != null) ? value.NativePtr : IntPtr.Zero, 1);
			}
		}

		// Token: 0x17005EA7 RID: 24231
		// (get) Token: 0x06027BE7 RID: 162791 RVA: 0x009F9835 File Offset: 0x009F7A35
		// (set) Token: 0x06027BE8 RID: 162792 RVA: 0x009F984A File Offset: 0x009F7A4A
		public TSoftObjectPtr<EffectModelGroup> MainLineModeTetrominoLockEffect
		{
			get
			{
				return new TSoftObjectPtr<EffectModelGroup>(base.NativePtr + (IntPtr)Bp_Tetris_C.__PropertyOffset_19, this);
			}
			set
			{
				FSoftObjectPtr.NativeCopy(base.NativePtr + (IntPtr)Bp_Tetris_C.__PropertyOffset_19, (value != null) ? value.NativePtr : IntPtr.Zero, 1);
			}
		}

		// Token: 0x17005EA8 RID: 24232
		// (get) Token: 0x06027BE9 RID: 162793 RVA: 0x009F986F File Offset: 0x009F7A6F
		// (set) Token: 0x06027BEA RID: 162794 RVA: 0x009F9884 File Offset: 0x009F7A84
		public TSoftObjectPtr<EffectModelGroup> MainLineModeLineClearEffect
		{
			get
			{
				return new TSoftObjectPtr<EffectModelGroup>(base.NativePtr + (IntPtr)Bp_Tetris_C.__PropertyOffset_20, this);
			}
			set
			{
				FSoftObjectPtr.NativeCopy(base.NativePtr + (IntPtr)Bp_Tetris_C.__PropertyOffset_20, (value != null) ? value.NativePtr : IntPtr.Zero, 1);
			}
		}

		// Token: 0x17005EA9 RID: 24233
		// (get) Token: 0x06027BEB RID: 162795 RVA: 0x009F98A9 File Offset: 0x009F7AA9
		// (set) Token: 0x06027BEC RID: 162796 RVA: 0x009F98BE File Offset: 0x009F7ABE
		public TSoftObjectPtr<ItemMaterialControllerActorData> MainLineModeMinoDestroyEffect
		{
			get
			{
				return new TSoftObjectPtr<ItemMaterialControllerActorData>(base.NativePtr + (IntPtr)Bp_Tetris_C.__PropertyOffset_21, this);
			}
			set
			{
				FSoftObjectPtr.NativeCopy(base.NativePtr + (IntPtr)Bp_Tetris_C.__PropertyOffset_21, (value != null) ? value.NativePtr : IntPtr.Zero, 1);
			}
		}

		// Token: 0x17005EAA RID: 24234
		// (get) Token: 0x06027BED RID: 162797 RVA: 0x009F98E3 File Offset: 0x009F7AE3
		// (set) Token: 0x06027BEE RID: 162798 RVA: 0x009F98F8 File Offset: 0x009F7AF8
		public TSoftObjectPtr<EffectModelGroup> NormalModeFailEffect
		{
			get
			{
				return new TSoftObjectPtr<EffectModelGroup>(base.NativePtr + (IntPtr)Bp_Tetris_C.__PropertyOffset_22, this);
			}
			set
			{
				FSoftObjectPtr.NativeCopy(base.NativePtr + (IntPtr)Bp_Tetris_C.__PropertyOffset_22, (value != null) ? value.NativePtr : IntPtr.Zero, 1);
			}
		}

		// Token: 0x17005EAB RID: 24235
		// (get) Token: 0x06027BEF RID: 162799 RVA: 0x009F991D File Offset: 0x009F7B1D
		// (set) Token: 0x06027BF0 RID: 162800 RVA: 0x009F9932 File Offset: 0x009F7B32
		public TSoftObjectPtr<EffectModelGroup> MainLineModeFailEffect
		{
			get
			{
				return new TSoftObjectPtr<EffectModelGroup>(base.NativePtr + (IntPtr)Bp_Tetris_C.__PropertyOffset_23, this);
			}
			set
			{
				FSoftObjectPtr.NativeCopy(base.NativePtr + (IntPtr)Bp_Tetris_C.__PropertyOffset_23, (value != null) ? value.NativePtr : IntPtr.Zero, 1);
			}
		}

		// Token: 0x17005EAC RID: 24236
		// (get) Token: 0x06027BF1 RID: 162801 RVA: 0x009F9957 File Offset: 0x009F7B57
		// (set) Token: 0x06027BF2 RID: 162802 RVA: 0x009F996C File Offset: 0x009F7B6C
		public TSoftObjectPtr<PD_CharacterControllerData_C> NormalModePlayerOutlineEffect
		{
			get
			{
				return new TSoftObjectPtr<PD_CharacterControllerData_C>(base.NativePtr + (IntPtr)Bp_Tetris_C.__PropertyOffset_24, this);
			}
			set
			{
				FSoftObjectPtr.NativeCopy(base.NativePtr + (IntPtr)Bp_Tetris_C.__PropertyOffset_24, (value != null) ? value.NativePtr : IntPtr.Zero, 1);
			}
		}

		// Token: 0x17005EAD RID: 24237
		// (get) Token: 0x06027BF3 RID: 162803 RVA: 0x009F9991 File Offset: 0x009F7B91
		// (set) Token: 0x06027BF4 RID: 162804 RVA: 0x009F99A6 File Offset: 0x009F7BA6
		public TSoftObjectPtr<PD_CharacterControllerData_C> MainLineModePlayerOutlineEffect
		{
			get
			{
				return new TSoftObjectPtr<PD_CharacterControllerData_C>(base.NativePtr + (IntPtr)Bp_Tetris_C.__PropertyOffset_25, this);
			}
			set
			{
				FSoftObjectPtr.NativeCopy(base.NativePtr + (IntPtr)Bp_Tetris_C.__PropertyOffset_25, (value != null) ? value.NativePtr : IntPtr.Zero, 1);
			}
		}

		// Token: 0x17005EAE RID: 24238
		// (get) Token: 0x06027BF5 RID: 162805 RVA: 0x009F99CB File Offset: 0x009F7BCB
		// (set) Token: 0x06027BF6 RID: 162806 RVA: 0x009F99E0 File Offset: 0x009F7BE0
		public TSoftObjectPtr<PD_CharacterControllerData_C> NormalModePlayerDeadEffect
		{
			get
			{
				return new TSoftObjectPtr<PD_CharacterControllerData_C>(base.NativePtr + (IntPtr)Bp_Tetris_C.__PropertyOffset_26, this);
			}
			set
			{
				FSoftObjectPtr.NativeCopy(base.NativePtr + (IntPtr)Bp_Tetris_C.__PropertyOffset_26, (value != null) ? value.NativePtr : IntPtr.Zero, 1);
			}
		}

		// Token: 0x17005EAF RID: 24239
		// (get) Token: 0x06027BF7 RID: 162807 RVA: 0x009F9A05 File Offset: 0x009F7C05
		// (set) Token: 0x06027BF8 RID: 162808 RVA: 0x009F9A19 File Offset: 0x009F7C19
		public unsafe string AudioGameSpeedUp
		{
			get
			{
				return FString.ToString((void*)(base.NativePtr + (byte*)((IntPtr)Bp_Tetris_C.__PropertyOffset_27)));
			}
			set
			{
				FString.CopyFrom((void*)(base.NativePtr + (byte*)((IntPtr)Bp_Tetris_C.__PropertyOffset_27)), value);
			}
		}

		// Token: 0x17005EB0 RID: 24240
		// (get) Token: 0x06027BF9 RID: 162809 RVA: 0x009F9A2E File Offset: 0x009F7C2E
		// (set) Token: 0x06027BFA RID: 162810 RVA: 0x009F9A42 File Offset: 0x009F7C42
		public unsafe string AudioTetrominoStartFall
		{
			get
			{
				return FString.ToString((void*)(base.NativePtr + (byte*)((IntPtr)Bp_Tetris_C.__PropertyOffset_28)));
			}
			set
			{
				FString.CopyFrom((void*)(base.NativePtr + (byte*)((IntPtr)Bp_Tetris_C.__PropertyOffset_28)), value);
			}
		}

		// Token: 0x17005EB1 RID: 24241
		// (get) Token: 0x06027BFB RID: 162811 RVA: 0x009F9A57 File Offset: 0x009F7C57
		// (set) Token: 0x06027BFC RID: 162812 RVA: 0x009F9A6B File Offset: 0x009F7C6B
		public unsafe string AudioGameFail
		{
			get
			{
				return FString.ToString((void*)(base.NativePtr + (byte*)((IntPtr)Bp_Tetris_C.__PropertyOffset_29)));
			}
			set
			{
				FString.CopyFrom((void*)(base.NativePtr + (byte*)((IntPtr)Bp_Tetris_C.__PropertyOffset_29)), value);
			}
		}

		// Token: 0x17005EB2 RID: 24242
		// (get) Token: 0x06027BFD RID: 162813 RVA: 0x009F9A80 File Offset: 0x009F7C80
		// (set) Token: 0x06027BFE RID: 162814 RVA: 0x009F9A94 File Offset: 0x009F7C94
		public unsafe string AudioGameSuccess
		{
			get
			{
				return FString.ToString((void*)(base.NativePtr + (byte*)((IntPtr)Bp_Tetris_C.__PropertyOffset_30)));
			}
			set
			{
				FString.CopyFrom((void*)(base.NativePtr + (byte*)((IntPtr)Bp_Tetris_C.__PropertyOffset_30)), value);
			}
		}

		// Token: 0x17005EB3 RID: 24243
		// (get) Token: 0x06027BFF RID: 162815 RVA: 0x009F9AA9 File Offset: 0x009F7CA9
		// (set) Token: 0x06027C00 RID: 162816 RVA: 0x009F9ABD File Offset: 0x009F7CBD
		public unsafe string AudioGameRestart
		{
			get
			{
				return FString.ToString((void*)(base.NativePtr + (byte*)((IntPtr)Bp_Tetris_C.__PropertyOffset_31)));
			}
			set
			{
				FString.CopyFrom((void*)(base.NativePtr + (byte*)((IntPtr)Bp_Tetris_C.__PropertyOffset_31)), value);
			}
		}

		// Token: 0x17005EB4 RID: 24244
		// (get) Token: 0x06027C01 RID: 162817 RVA: 0x009F9AD2 File Offset: 0x009F7CD2
		// (set) Token: 0x06027C02 RID: 162818 RVA: 0x009F9AE6 File Offset: 0x009F7CE6
		public unsafe string AudioTetrominoRotate
		{
			get
			{
				return FString.ToString((void*)(base.NativePtr + (byte*)((IntPtr)Bp_Tetris_C.__PropertyOffset_32)));
			}
			set
			{
				FString.CopyFrom((void*)(base.NativePtr + (byte*)((IntPtr)Bp_Tetris_C.__PropertyOffset_32)), value);
			}
		}

		// Token: 0x17005EB5 RID: 24245
		// (get) Token: 0x06027C03 RID: 162819 RVA: 0x009F9AFB File Offset: 0x009F7CFB
		// (set) Token: 0x06027C04 RID: 162820 RVA: 0x009F9B0F File Offset: 0x009F7D0F
		public unsafe string AudioAimingMove
		{
			get
			{
				return FString.ToString((void*)(base.NativePtr + (byte*)((IntPtr)Bp_Tetris_C.__PropertyOffset_33)));
			}
			set
			{
				FString.CopyFrom((void*)(base.NativePtr + (byte*)((IntPtr)Bp_Tetris_C.__PropertyOffset_33)), value);
			}
		}

		// Token: 0x06027C05 RID: 162821 RVA: 0x009F9B24 File Offset: 0x009F7D24
		protected Bp_Tetris_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x04014D8D RID: 85389
		public new const string __ObjectPath = "/Game/Aki/Data/Gameplay/Tetris/Bp_Tetris.Bp_Tetris_C";

		// Token: 0x04014D8E RID: 85390
		private static IntPtr _ClassPtr;

		// Token: 0x04014D8F RID: 85391
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x04014D90 RID: 85392
		internal static int __PropertyOffset_0;

		// Token: 0x04014D91 RID: 85393
		internal static int __PropertyOffset_1;

		// Token: 0x04014D92 RID: 85394
		internal static int __PropertyOffset_2;

		// Token: 0x04014D93 RID: 85395
		internal static int __PropertyOffset_3;

		// Token: 0x04014D94 RID: 85396
		internal static int __PropertyOffset_4;

		// Token: 0x04014D95 RID: 85397
		internal static int __PropertyOffset_5;

		// Token: 0x04014D96 RID: 85398
		internal static int __PropertyOffset_6;

		// Token: 0x04014D97 RID: 85399
		internal static int __PropertyOffset_7;

		// Token: 0x04014D98 RID: 85400
		internal static int __PropertyOffset_8;

		// Token: 0x04014D99 RID: 85401
		internal static int __PropertyOffset_9;

		// Token: 0x04014D9A RID: 85402
		[Nullable(2)]
		private TMap<int, int> _ScoreRule;

		// Token: 0x04014D9B RID: 85403
		internal static int __PropertyOffset_10;

		// Token: 0x04014D9C RID: 85404
		internal static int __PropertyOffset_11;

		// Token: 0x04014D9D RID: 85405
		internal static int __PropertyOffset_12;

		// Token: 0x04014D9E RID: 85406
		internal static int __PropertyOffset_13;

		// Token: 0x04014D9F RID: 85407
		internal static int __PropertyOffset_14;

		// Token: 0x04014DA0 RID: 85408
		internal static int __PropertyOffset_15;

		// Token: 0x04014DA1 RID: 85409
		internal static int __PropertyOffset_16;

		// Token: 0x04014DA2 RID: 85410
		internal static int __PropertyOffset_17;

		// Token: 0x04014DA3 RID: 85411
		internal static int __PropertyOffset_18;

		// Token: 0x04014DA4 RID: 85412
		internal static int __PropertyOffset_19;

		// Token: 0x04014DA5 RID: 85413
		internal static int __PropertyOffset_20;

		// Token: 0x04014DA6 RID: 85414
		internal static int __PropertyOffset_21;

		// Token: 0x04014DA7 RID: 85415
		internal static int __PropertyOffset_22;

		// Token: 0x04014DA8 RID: 85416
		internal static int __PropertyOffset_23;

		// Token: 0x04014DA9 RID: 85417
		internal static int __PropertyOffset_24;

		// Token: 0x04014DAA RID: 85418
		internal static int __PropertyOffset_25;

		// Token: 0x04014DAB RID: 85419
		internal static int __PropertyOffset_26;

		// Token: 0x04014DAC RID: 85420
		internal static int __PropertyOffset_27;

		// Token: 0x04014DAD RID: 85421
		internal static int __PropertyOffset_28;

		// Token: 0x04014DAE RID: 85422
		internal static int __PropertyOffset_29;

		// Token: 0x04014DAF RID: 85423
		internal static int __PropertyOffset_30;

		// Token: 0x04014DB0 RID: 85424
		internal static int __PropertyOffset_31;

		// Token: 0x04014DB1 RID: 85425
		internal static int __PropertyOffset_32;

		// Token: 0x04014DB2 RID: 85426
		internal static int __PropertyOffset_33;
	}
}
