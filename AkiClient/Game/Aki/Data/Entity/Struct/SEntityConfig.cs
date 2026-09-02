using System;
using System.Runtime.CompilerServices;
using AkiClient.Game.Aki.Character.BaseCharacter;
using AkiClient.Game.Aki.Data.Entity.Enum;
using AkiClient.Game.Aki.GamePlay;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Data.Entity.Struct
{
	// Token: 0x02003EF3 RID: 16115
	[NullableContext(1)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Data/Entity/Struct/SEntityConfig.SEntityConfig")]
	[UnrealStructLayout(672, 8, UnrealReflectionPropertyTypeCode.UnrealScriptStructProxy, PropertiesSize = 668)]
	public class SEntityConfig : UnrealUserDefinedStructProxy, IUnrealScriptStructProxy, IUnrealScriptStruct, IUnrealObject
	{
		// Token: 0x06028212 RID: 164370 RVA: 0x00A031C7 File Offset: 0x00A013C7
		public static UScriptStructStackOnlyPtr StaticStruct()
		{
			return (SEntityConfig._ScriptStructPtr != 0) ? SEntityConfig._ScriptStructPtr : UObjectGlobals.StaticLoadScriptStruct("/Game/Aki/Data/Entity/Struct/SEntityConfig.SEntityConfig", ref SEntityConfig._ScriptStructPtr);
		}

		// Token: 0x170060A6 RID: 24742
		// (get) Token: 0x06028213 RID: 164371 RVA: 0x00A031EB File Offset: 0x00A013EB
		// (set) Token: 0x06028214 RID: 164372 RVA: 0x00A031FB File Offset: 0x00A013FB
		public unsafe int ID
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SEntityConfig.__PropertyOffset_0);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SEntityConfig.__PropertyOffset_0) = value;
			}
		}

		// Token: 0x170060A7 RID: 24743
		// (get) Token: 0x06028215 RID: 164373 RVA: 0x00A0320C File Offset: 0x00A0140C
		// (set) Token: 0x06028216 RID: 164374 RVA: 0x00A03220 File Offset: 0x00A01420
		public unsafe string Name
		{
			get
			{
				return FString.ToString((void*)(base.NativePtr + (byte*)((IntPtr)SEntityConfig.__PropertyOffset_1)));
			}
			set
			{
				FString.CopyFrom((void*)(base.NativePtr + (byte*)((IntPtr)SEntityConfig.__PropertyOffset_1)), value);
			}
		}

		// Token: 0x170060A8 RID: 24744
		// (get) Token: 0x06028217 RID: 164375 RVA: 0x00A03235 File Offset: 0x00A01435
		// (set) Token: 0x06028218 RID: 164376 RVA: 0x00A03249 File Offset: 0x00A01449
		[Nullable(0)]
		public unsafe TEnumAsByte<EEntityType> EntityType
		{
			[NullableContext(0)]
			get
			{
				return *(base.NativePtr + (IntPtr)SEntityConfig.__PropertyOffset_2);
			}
			[NullableContext(0)]
			set
			{
				*(base.NativePtr + (IntPtr)SEntityConfig.__PropertyOffset_2) = value;
			}
		}

		// Token: 0x170060A9 RID: 24745
		// (get) Token: 0x06028219 RID: 164377 RVA: 0x00A03260 File Offset: 0x00A01460
		// (set) Token: 0x0602821A RID: 164378 RVA: 0x00A032A3 File Offset: 0x00A014A3
		public unsafe FText Title
		{
			get
			{
				base.FastCheckIsValid();
				FText result;
				if ((result = this._Title) == null)
				{
					result = (this._Title = new FText(base.NativePtr + (IntPtr)SEntityConfig.__PropertyOffset_3, base.MemoryOwner ?? this));
				}
				return result;
			}
			set
			{
				FText.NativeCopy((void*)(base.NativePtr + (byte*)((IntPtr)SEntityConfig.__PropertyOffset_3)), value.NativePtr, 1);
			}
		}

		// Token: 0x170060AA RID: 24746
		// (get) Token: 0x0602821B RID: 164379 RVA: 0x00A032BE File Offset: 0x00A014BE
		// (set) Token: 0x0602821C RID: 164380 RVA: 0x00A032CE File Offset: 0x00A014CE
		public unsafe int ModleId
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SEntityConfig.__PropertyOffset_4);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SEntityConfig.__PropertyOffset_4) = value;
			}
		}

		// Token: 0x170060AB RID: 24747
		// (get) Token: 0x0602821D RID: 164381 RVA: 0x00A032DF File Offset: 0x00A014DF
		// (set) Token: 0x0602821E RID: 164382 RVA: 0x00A032EF File Offset: 0x00A014EF
		public unsafe bool IsExchangeControl
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SEntityConfig.__PropertyOffset_5) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)SEntityConfig.__PropertyOffset_5) = (value ? 1 : 0);
			}
		}

		// Token: 0x170060AC RID: 24748
		// (get) Token: 0x0602821F RID: 164383 RVA: 0x00A03300 File Offset: 0x00A01500
		// (set) Token: 0x06028220 RID: 164384 RVA: 0x00A03343 File Offset: 0x00A01543
		public TArray<FName> Tag
		{
			get
			{
				base.FastCheckIsValid();
				TArray<FName> result;
				if ((result = this._Tag) == null)
				{
					result = (this._Tag = new TArray<FName>(base.NativePtr + (IntPtr)SEntityConfig.__PropertyOffset_6, base.MemoryOwner ?? this));
				}
				return result;
			}
			set
			{
				this.Tag.CopyAssign(value);
			}
		}

		// Token: 0x170060AD RID: 24749
		// (get) Token: 0x06028221 RID: 164385 RVA: 0x00A03354 File Offset: 0x00A01554
		// (set) Token: 0x06028222 RID: 164386 RVA: 0x00A03397 File Offset: 0x00A01597
		public TArray<FName> InteractionId
		{
			get
			{
				base.FastCheckIsValid();
				TArray<FName> result;
				if ((result = this._InteractionId) == null)
				{
					result = (this._InteractionId = new TArray<FName>(base.NativePtr + (IntPtr)SEntityConfig.__PropertyOffset_7, base.MemoryOwner ?? this));
				}
				return result;
			}
			set
			{
				this.InteractionId.CopyAssign(value);
			}
		}

		// Token: 0x170060AE RID: 24750
		// (get) Token: 0x06028223 RID: 164387 RVA: 0x00A033A5 File Offset: 0x00A015A5
		// (set) Token: 0x06028224 RID: 164388 RVA: 0x00A033B5 File Offset: 0x00A015B5
		public unsafe int AiControllerId
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SEntityConfig.__PropertyOffset_8);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SEntityConfig.__PropertyOffset_8) = value;
			}
		}

		// Token: 0x170060AF RID: 24751
		// (get) Token: 0x06028225 RID: 164389 RVA: 0x00A033C6 File Offset: 0x00A015C6
		// (set) Token: 0x06028226 RID: 164390 RVA: 0x00A033D6 File Offset: 0x00A015D6
		public unsafe int PropertyId
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SEntityConfig.__PropertyOffset_9);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SEntityConfig.__PropertyOffset_9) = value;
			}
		}

		// Token: 0x170060B0 RID: 24752
		// (get) Token: 0x06028227 RID: 164391 RVA: 0x00A033E7 File Offset: 0x00A015E7
		// (set) Token: 0x06028228 RID: 164392 RVA: 0x00A033FB File Offset: 0x00A015FB
		public unsafe FName StateType
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SEntityConfig.__PropertyOffset_10);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SEntityConfig.__PropertyOffset_10) = value;
			}
		}

		// Token: 0x170060B1 RID: 24753
		// (get) Token: 0x06028229 RID: 164393 RVA: 0x00A03410 File Offset: 0x00A01610
		// (set) Token: 0x0602822A RID: 164394 RVA: 0x00A0342F File Offset: 0x00A0162F
		public TSoftObjectPtr<UTexture> MapMarkId
		{
			get
			{
				return new TSoftObjectPtr<UTexture>(base.NativePtr + (IntPtr)SEntityConfig.__PropertyOffset_11, base.MemoryOwner ?? this);
			}
			set
			{
				FSoftObjectPtr.NativeCopy(base.NativePtr + (IntPtr)SEntityConfig.__PropertyOffset_11, (value != null) ? value.NativePtr : IntPtr.Zero, 1);
			}
		}

		// Token: 0x170060B2 RID: 24754
		// (get) Token: 0x0602822B RID: 164395 RVA: 0x00A03454 File Offset: 0x00A01654
		// (set) Token: 0x0602822C RID: 164396 RVA: 0x00A03468 File Offset: 0x00A01668
		[Nullable(new byte[]
		{
			0,
			1
		})]
		public unsafe TSubclassOf<UUserWidget> SpEnergyBar
		{
			[return: Nullable(new byte[]
			{
				0,
				1
			})]
			get
			{
				return *(base.NativePtr + (IntPtr)SEntityConfig.__PropertyOffset_12);
			}
			[param: Nullable(new byte[]
			{
				0,
				1
			})]
			set
			{
				*(base.NativePtr + (IntPtr)SEntityConfig.__PropertyOffset_12) = value;
			}
		}

		// Token: 0x170060B3 RID: 24755
		// (get) Token: 0x0602822D RID: 164397 RVA: 0x00A0347D File Offset: 0x00A0167D
		// (set) Token: 0x0602822E RID: 164398 RVA: 0x00A03491 File Offset: 0x00A01691
		[Nullable(0)]
		public unsafe TEnumAsByte<ECamp> Camp
		{
			[NullableContext(0)]
			get
			{
				return *(base.NativePtr + (IntPtr)SEntityConfig.__PropertyOffset_13);
			}
			[NullableContext(0)]
			set
			{
				*(base.NativePtr + (IntPtr)SEntityConfig.__PropertyOffset_13) = value;
			}
		}

		// Token: 0x170060B4 RID: 24756
		// (get) Token: 0x0602822F RID: 164399 RVA: 0x00A034A6 File Offset: 0x00A016A6
		// (set) Token: 0x06028230 RID: 164400 RVA: 0x00A034BA File Offset: 0x00A016BA
		public unsafe string remarks
		{
			get
			{
				return FString.ToString((void*)(base.NativePtr + (byte*)((IntPtr)SEntityConfig.__PropertyOffset_14)));
			}
			set
			{
				FString.CopyFrom((void*)(base.NativePtr + (byte*)((IntPtr)SEntityConfig.__PropertyOffset_14)), value);
			}
		}

		// Token: 0x170060B5 RID: 24757
		// (get) Token: 0x06028231 RID: 164401 RVA: 0x00A034D0 File Offset: 0x00A016D0
		// (set) Token: 0x06028232 RID: 164402 RVA: 0x00A03513 File Offset: 0x00A01713
		public TArray<FName> Bones
		{
			get
			{
				base.FastCheckIsValid();
				TArray<FName> result;
				if ((result = this._Bones) == null)
				{
					result = (this._Bones = new TArray<FName>(base.NativePtr + (IntPtr)SEntityConfig.__PropertyOffset_15, base.MemoryOwner ?? this));
				}
				return result;
			}
			set
			{
				this.Bones.CopyAssign(value);
			}
		}

		// Token: 0x170060B6 RID: 24758
		// (get) Token: 0x06028233 RID: 164403 RVA: 0x00A03521 File Offset: 0x00A01721
		// (set) Token: 0x06028234 RID: 164404 RVA: 0x00A03531 File Offset: 0x00A01731
		public unsafe int FocusPriority
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SEntityConfig.__PropertyOffset_16);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SEntityConfig.__PropertyOffset_16) = value;
			}
		}

		// Token: 0x170060B7 RID: 24759
		// (get) Token: 0x06028235 RID: 164405 RVA: 0x00A03544 File Offset: 0x00A01744
		// (set) Token: 0x06028236 RID: 164406 RVA: 0x00A03587 File Offset: 0x00A01787
		public TMap<int, int> DropConfig
		{
			get
			{
				base.FastCheckIsValid();
				TMap<int, int> result;
				if ((result = this._DropConfig) == null)
				{
					result = (this._DropConfig = new TMap<int, int>(base.NativePtr + (IntPtr)SEntityConfig.__PropertyOffset_17, base.MemoryOwner ?? this));
				}
				return result;
			}
			set
			{
				this.DropConfig.CopyAssign(value);
			}
		}

		// Token: 0x170060B8 RID: 24760
		// (get) Token: 0x06028237 RID: 164407 RVA: 0x00A03595 File Offset: 0x00A01795
		// (set) Token: 0x06028238 RID: 164408 RVA: 0x00A035A5 File Offset: 0x00A017A5
		public unsafe int EntityPropertyID
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SEntityConfig.__PropertyOffset_18);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SEntityConfig.__PropertyOffset_18) = value;
			}
		}

		// Token: 0x170060B9 RID: 24761
		// (get) Token: 0x06028239 RID: 164409 RVA: 0x00A035B6 File Offset: 0x00A017B6
		// (set) Token: 0x0602823A RID: 164410 RVA: 0x00A035C6 File Offset: 0x00A017C6
		public unsafe int RageModeId
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SEntityConfig.__PropertyOffset_19);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SEntityConfig.__PropertyOffset_19) = value;
			}
		}

		// Token: 0x170060BA RID: 24762
		// (get) Token: 0x0602823B RID: 164411 RVA: 0x00A035D7 File Offset: 0x00A017D7
		// (set) Token: 0x0602823C RID: 164412 RVA: 0x00A035E7 File Offset: 0x00A017E7
		public unsafe int HardnessModeId
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SEntityConfig.__PropertyOffset_20);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SEntityConfig.__PropertyOffset_20) = value;
			}
		}

		// Token: 0x170060BB RID: 24763
		// (get) Token: 0x0602823D RID: 164413 RVA: 0x00A035F8 File Offset: 0x00A017F8
		// (set) Token: 0x0602823E RID: 164414 RVA: 0x00A03608 File Offset: 0x00A01808
		public unsafe bool BeHitIgnoreRotate
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SEntityConfig.__PropertyOffset_21) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)SEntityConfig.__PropertyOffset_21) = (value ? 1 : 0);
			}
		}

		// Token: 0x170060BC RID: 24764
		// (get) Token: 0x0602823F RID: 164415 RVA: 0x00A0361C File Offset: 0x00A0181C
		// (set) Token: 0x06028240 RID: 164416 RVA: 0x00A0365F File Offset: 0x00A0185F
		public TMap<int, int> SceneOwnerDropConfig
		{
			get
			{
				base.FastCheckIsValid();
				TMap<int, int> result;
				if ((result = this._SceneOwnerDropConfig) == null)
				{
					result = (this._SceneOwnerDropConfig = new TMap<int, int>(base.NativePtr + (IntPtr)SEntityConfig.__PropertyOffset_22, base.MemoryOwner ?? this));
				}
				return result;
			}
			set
			{
				this.SceneOwnerDropConfig.CopyAssign(value);
			}
		}

		// Token: 0x170060BD RID: 24765
		// (get) Token: 0x06028241 RID: 164417 RVA: 0x00A0366D File Offset: 0x00A0186D
		// (set) Token: 0x06028242 RID: 164418 RVA: 0x00A03681 File Offset: 0x00A01881
		[Nullable(0)]
		public unsafe TEnumAsByte<EBossStateViewType> BossStateViewType
		{
			[NullableContext(0)]
			get
			{
				return *(base.NativePtr + (IntPtr)SEntityConfig.__PropertyOffset_23);
			}
			[NullableContext(0)]
			set
			{
				*(base.NativePtr + (IntPtr)SEntityConfig.__PropertyOffset_23) = value;
			}
		}

		// Token: 0x170060BE RID: 24766
		// (get) Token: 0x06028243 RID: 164419 RVA: 0x00A03698 File Offset: 0x00A01898
		// (set) Token: 0x06028244 RID: 164420 RVA: 0x00A036DB File Offset: 0x00A018DB
		public TArray<SHardnessStageInfo> HardnessPercentStage
		{
			get
			{
				base.FastCheckIsValid();
				TArray<SHardnessStageInfo> result;
				if ((result = this._HardnessPercentStage) == null)
				{
					result = (this._HardnessPercentStage = new TArray<SHardnessStageInfo>(base.NativePtr + (IntPtr)SEntityConfig.__PropertyOffset_24, base.MemoryOwner ?? this));
				}
				return result;
			}
			set
			{
				this.HardnessPercentStage.CopyAssign(value);
			}
		}

		// Token: 0x170060BF RID: 24767
		// (get) Token: 0x06028245 RID: 164421 RVA: 0x00A036E9 File Offset: 0x00A018E9
		// (set) Token: 0x06028246 RID: 164422 RVA: 0x00A036FD File Offset: 0x00A018FD
		[Nullable(0)]
		public unsafe TEnumAsByte<EHeadStateViewType> HeadStateViewType
		{
			[NullableContext(0)]
			get
			{
				return *(base.NativePtr + (IntPtr)SEntityConfig.__PropertyOffset_25);
			}
			[NullableContext(0)]
			set
			{
				*(base.NativePtr + (IntPtr)SEntityConfig.__PropertyOffset_25) = value;
			}
		}

		// Token: 0x170060C0 RID: 24768
		// (get) Token: 0x06028247 RID: 164423 RVA: 0x00A03712 File Offset: 0x00A01912
		// (set) Token: 0x06028248 RID: 164424 RVA: 0x00A03726 File Offset: 0x00A01926
		public unsafe FName HeadStateSocketName
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SEntityConfig.__PropertyOffset_26);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SEntityConfig.__PropertyOffset_26) = value;
			}
		}

		// Token: 0x170060C1 RID: 24769
		// (get) Token: 0x06028249 RID: 164425 RVA: 0x00A0373B File Offset: 0x00A0193B
		// (set) Token: 0x0602824A RID: 164426 RVA: 0x00A0374B File Offset: 0x00A0194B
		public unsafe int HeadStateZOffset
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SEntityConfig.__PropertyOffset_27);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SEntityConfig.__PropertyOffset_27) = value;
			}
		}

		// Token: 0x170060C2 RID: 24770
		// (get) Token: 0x0602824B RID: 164427 RVA: 0x00A0375C File Offset: 0x00A0195C
		// (set) Token: 0x0602824C RID: 164428 RVA: 0x00A0376C File Offset: 0x00A0196C
		public unsafe int HeadStateForwardOffset
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SEntityConfig.__PropertyOffset_28);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SEntityConfig.__PropertyOffset_28) = value;
			}
		}

		// Token: 0x170060C3 RID: 24771
		// (get) Token: 0x0602824D RID: 164429 RVA: 0x00A0377D File Offset: 0x00A0197D
		// (set) Token: 0x0602824E RID: 164430 RVA: 0x00A03791 File Offset: 0x00A01991
		[Nullable(0)]
		public unsafe TEnumAsByte<EGameplayFunctionType> SceneItemFunctionType
		{
			[NullableContext(0)]
			get
			{
				return *(base.NativePtr + (IntPtr)SEntityConfig.__PropertyOffset_29);
			}
			[NullableContext(0)]
			set
			{
				*(base.NativePtr + (IntPtr)SEntityConfig.__PropertyOffset_29) = value;
			}
		}

		// Token: 0x170060C4 RID: 24772
		// (get) Token: 0x0602824F RID: 164431 RVA: 0x00A037A6 File Offset: 0x00A019A6
		// (set) Token: 0x06028250 RID: 164432 RVA: 0x00A037B6 File Offset: 0x00A019B6
		public unsafe int SceneItemFunctionID
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SEntityConfig.__PropertyOffset_30);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SEntityConfig.__PropertyOffset_30) = value;
			}
		}

		// Token: 0x170060C5 RID: 24773
		// (get) Token: 0x06028251 RID: 164433 RVA: 0x00A037C8 File Offset: 0x00A019C8
		// (set) Token: 0x06028252 RID: 164434 RVA: 0x00A0380B File Offset: 0x00A01A0B
		public SAiWeaponSocket AiWeaponSocket
		{
			get
			{
				base.FastCheckIsValid();
				SAiWeaponSocket result;
				if ((result = this._AiWeaponSocket) == null)
				{
					result = (this._AiWeaponSocket = new SAiWeaponSocket(base.NativePtr + (IntPtr)SEntityConfig.__PropertyOffset_31, base.MemoryOwner ?? this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(SAiWeaponSocket.StaticStruct(), base.NativePtr + (IntPtr)SEntityConfig.__PropertyOffset_31, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170060C6 RID: 24774
		// (get) Token: 0x06028253 RID: 164435 RVA: 0x00A0382C File Offset: 0x00A01A2C
		// (set) Token: 0x06028254 RID: 164436 RVA: 0x00A0383C File Offset: 0x00A01A3C
		public unsafe int AiWeaponConfigId
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SEntityConfig.__PropertyOffset_32);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SEntityConfig.__PropertyOffset_32) = value;
			}
		}

		// Token: 0x170060C7 RID: 24775
		// (get) Token: 0x06028255 RID: 164437 RVA: 0x00A0384D File Offset: 0x00A01A4D
		// (set) Token: 0x06028256 RID: 164438 RVA: 0x00A0385D File Offset: 0x00A01A5D
		public unsafe int ForceLockOnCoefficient
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SEntityConfig.__PropertyOffset_33);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SEntityConfig.__PropertyOffset_33) = value;
			}
		}

		// Token: 0x170060C8 RID: 24776
		// (get) Token: 0x06028257 RID: 164439 RVA: 0x00A0386E File Offset: 0x00A01A6E
		// (set) Token: 0x06028258 RID: 164440 RVA: 0x00A0387E File Offset: 0x00A01A7E
		public unsafe int NpcMessageId
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SEntityConfig.__PropertyOffset_34);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SEntityConfig.__PropertyOffset_34) = value;
			}
		}

		// Token: 0x170060C9 RID: 24777
		// (get) Token: 0x06028259 RID: 164441 RVA: 0x00A03890 File Offset: 0x00A01A90
		// (set) Token: 0x0602825A RID: 164442 RVA: 0x00A038D3 File Offset: 0x00A01AD3
		public TMap<string, string> param
		{
			get
			{
				base.FastCheckIsValid();
				TMap<string, string> result;
				if ((result = this._param) == null)
				{
					result = (this._param = new TMap<string, string>(base.NativePtr + (IntPtr)SEntityConfig.__PropertyOffset_35, base.MemoryOwner ?? this));
				}
				return result;
			}
			set
			{
				this.param.CopyAssign(value);
			}
		}

		// Token: 0x170060CA RID: 24778
		// (get) Token: 0x0602825B RID: 164443 RVA: 0x00A038E1 File Offset: 0x00A01AE1
		// (set) Token: 0x0602825C RID: 164444 RVA: 0x00A038F1 File Offset: 0x00A01AF1
		public unsafe int AOILOD
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SEntityConfig.__PropertyOffset_36);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SEntityConfig.__PropertyOffset_36) = value;
			}
		}

		// Token: 0x170060CB RID: 24779
		// (get) Token: 0x0602825D RID: 164445 RVA: 0x00A03904 File Offset: 0x00A01B04
		// (set) Token: 0x0602825E RID: 164446 RVA: 0x00A03947 File Offset: 0x00A01B47
		public TArray<long> BornBuff
		{
			get
			{
				base.FastCheckIsValid();
				TArray<long> result;
				if ((result = this._BornBuff) == null)
				{
					result = (this._BornBuff = new TArray<long>(base.NativePtr + (IntPtr)SEntityConfig.__PropertyOffset_37, base.MemoryOwner ?? this));
				}
				return result;
			}
			set
			{
				this.BornBuff.CopyAssign(value);
			}
		}

		// Token: 0x170060CC RID: 24780
		// (get) Token: 0x0602825F RID: 164447 RVA: 0x00A03955 File Offset: 0x00A01B55
		// (set) Token: 0x06028260 RID: 164448 RVA: 0x00A03965 File Offset: 0x00A01B65
		public unsafe float AffectDistance
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SEntityConfig.__PropertyOffset_38);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SEntityConfig.__PropertyOffset_38) = value;
			}
		}

		// Token: 0x06028261 RID: 164449 RVA: 0x00A03976 File Offset: 0x00A01B76
		public SEntityConfig()
		{
		}

		// Token: 0x06028262 RID: 164450 RVA: 0x00A03980 File Offset: 0x00A01B80
		public SEntityConfig(int ID, string Name, [Nullable(0)] TEnumAsByte<EEntityType> EntityType, FText Title, int ModleId, bool IsExchangeControl, TArray<FName> Tag, TArray<FName> InteractionId, int AiControllerId, int PropertyId, FName StateType, TSoftObjectPtr<UTexture> MapMarkId, [Nullable(new byte[]
		{
			0,
			1
		})] TSubclassOf<UUserWidget> SpEnergyBar, [Nullable(0)] TEnumAsByte<ECamp> Camp, string remarks, TArray<FName> Bones, int FocusPriority, TMap<int, int> DropConfig, int EntityPropertyID, int RageModeId, int HardnessModeId, bool BeHitIgnoreRotate, TMap<int, int> SceneOwnerDropConfig, [Nullable(0)] TEnumAsByte<EBossStateViewType> BossStateViewType, TArray<SHardnessStageInfo> HardnessPercentStage, [Nullable(0)] TEnumAsByte<EHeadStateViewType> HeadStateViewType, FName HeadStateSocketName, int HeadStateZOffset, int HeadStateForwardOffset, [Nullable(0)] TEnumAsByte<EGameplayFunctionType> SceneItemFunctionType, int SceneItemFunctionID, SAiWeaponSocket AiWeaponSocket, int AiWeaponConfigId, int ForceLockOnCoefficient, int NpcMessageId, TMap<string, string> param, int AOILOD, TArray<long> BornBuff, float AffectDistance)
		{
			this.ID = ID;
			this.Name = Name;
			this.EntityType = EntityType;
			this.Title = Title;
			this.ModleId = ModleId;
			this.IsExchangeControl = IsExchangeControl;
			this.Tag = Tag;
			this.InteractionId = InteractionId;
			this.AiControllerId = AiControllerId;
			this.PropertyId = PropertyId;
			this.StateType = StateType;
			this.MapMarkId = MapMarkId;
			this.SpEnergyBar = SpEnergyBar;
			this.Camp = Camp;
			this.remarks = remarks;
			this.Bones = Bones;
			this.FocusPriority = FocusPriority;
			this.DropConfig = DropConfig;
			this.EntityPropertyID = EntityPropertyID;
			this.RageModeId = RageModeId;
			this.HardnessModeId = HardnessModeId;
			this.BeHitIgnoreRotate = BeHitIgnoreRotate;
			this.SceneOwnerDropConfig = SceneOwnerDropConfig;
			this.BossStateViewType = BossStateViewType;
			this.HardnessPercentStage = HardnessPercentStage;
			this.HeadStateViewType = HeadStateViewType;
			this.HeadStateSocketName = HeadStateSocketName;
			this.HeadStateZOffset = HeadStateZOffset;
			this.HeadStateForwardOffset = HeadStateForwardOffset;
			this.SceneItemFunctionType = SceneItemFunctionType;
			this.SceneItemFunctionID = SceneItemFunctionID;
			this.AiWeaponSocket = AiWeaponSocket;
			this.AiWeaponConfigId = AiWeaponConfigId;
			this.ForceLockOnCoefficient = ForceLockOnCoefficient;
			this.NpcMessageId = NpcMessageId;
			this.param = param;
			this.AOILOD = AOILOD;
			this.BornBuff = BornBuff;
			this.AffectDistance = AffectDistance;
		}

		// Token: 0x06028263 RID: 164451 RVA: 0x00A03AC8 File Offset: 0x00A01CC8
		protected override IntPtr GetUStructPtr()
		{
			return SEntityConfig.StaticStruct();
		}

		// Token: 0x06028264 RID: 164452 RVA: 0x00A03AD4 File Offset: 0x00A01CD4
		[NullableContext(2)]
		public SEntityConfig(IntPtr NativePtr, UnrealObject MemoryOwner) : base(NativePtr, MemoryOwner)
		{
		}

		// Token: 0x06028265 RID: 164453 RVA: 0x00A03ADE File Offset: 0x00A01CDE
		public SEntityConfig(IntPtr NativePtr, bool bWithMoveAssign, bool bWithCopyAssignIfCannotMove) : base(NativePtr, bWithMoveAssign, bWithCopyAssignIfCannotMove)
		{
		}

		// Token: 0x06028266 RID: 164454 RVA: 0x00A03AE9 File Offset: 0x00A01CE9
		public static IUnrealScriptStructProxy CreateFromPointer(IntPtr Pointer)
		{
			return new SEntityConfig(Pointer, false, true);
		}

		// Token: 0x06028267 RID: 164455 RVA: 0x00A03AF3 File Offset: 0x00A01CF3
		public static IUnrealScriptStructProxy CreateReferenceFromPointer(IntPtr Pointer, UnrealObject MemoryOwner)
		{
			return new SEntityConfig(Pointer, MemoryOwner);
		}

		// Token: 0x04015132 RID: 86322
		public const string __ObjectPath = "/Game/Aki/Data/Entity/Struct/SEntityConfig.SEntityConfig";

		// Token: 0x04015133 RID: 86323
		private static IntPtr _ScriptStructPtr;

		// Token: 0x04015134 RID: 86324
		internal static int __PropertyOffset_0;

		// Token: 0x04015135 RID: 86325
		internal static int __PropertyOffset_1;

		// Token: 0x04015136 RID: 86326
		internal static int __PropertyOffset_2;

		// Token: 0x04015137 RID: 86327
		internal static int __PropertyOffset_3;

		// Token: 0x04015138 RID: 86328
		[Nullable(2)]
		private FText _Title;

		// Token: 0x04015139 RID: 86329
		internal static int __PropertyOffset_4;

		// Token: 0x0401513A RID: 86330
		internal static int __PropertyOffset_5;

		// Token: 0x0401513B RID: 86331
		internal static int __PropertyOffset_6;

		// Token: 0x0401513C RID: 86332
		[Nullable(2)]
		private TArray<FName> _Tag;

		// Token: 0x0401513D RID: 86333
		internal static int __PropertyOffset_7;

		// Token: 0x0401513E RID: 86334
		[Nullable(2)]
		private TArray<FName> _InteractionId;

		// Token: 0x0401513F RID: 86335
		internal static int __PropertyOffset_8;

		// Token: 0x04015140 RID: 86336
		internal static int __PropertyOffset_9;

		// Token: 0x04015141 RID: 86337
		internal static int __PropertyOffset_10;

		// Token: 0x04015142 RID: 86338
		internal static int __PropertyOffset_11;

		// Token: 0x04015143 RID: 86339
		internal static int __PropertyOffset_12;

		// Token: 0x04015144 RID: 86340
		internal static int __PropertyOffset_13;

		// Token: 0x04015145 RID: 86341
		internal static int __PropertyOffset_14;

		// Token: 0x04015146 RID: 86342
		internal static int __PropertyOffset_15;

		// Token: 0x04015147 RID: 86343
		[Nullable(2)]
		private TArray<FName> _Bones;

		// Token: 0x04015148 RID: 86344
		internal static int __PropertyOffset_16;

		// Token: 0x04015149 RID: 86345
		internal static int __PropertyOffset_17;

		// Token: 0x0401514A RID: 86346
		[Nullable(2)]
		private TMap<int, int> _DropConfig;

		// Token: 0x0401514B RID: 86347
		internal static int __PropertyOffset_18;

		// Token: 0x0401514C RID: 86348
		internal static int __PropertyOffset_19;

		// Token: 0x0401514D RID: 86349
		internal static int __PropertyOffset_20;

		// Token: 0x0401514E RID: 86350
		internal static int __PropertyOffset_21;

		// Token: 0x0401514F RID: 86351
		internal static int __PropertyOffset_22;

		// Token: 0x04015150 RID: 86352
		[Nullable(2)]
		private TMap<int, int> _SceneOwnerDropConfig;

		// Token: 0x04015151 RID: 86353
		internal static int __PropertyOffset_23;

		// Token: 0x04015152 RID: 86354
		internal static int __PropertyOffset_24;

		// Token: 0x04015153 RID: 86355
		[Nullable(2)]
		private TArray<SHardnessStageInfo> _HardnessPercentStage;

		// Token: 0x04015154 RID: 86356
		internal static int __PropertyOffset_25;

		// Token: 0x04015155 RID: 86357
		internal static int __PropertyOffset_26;

		// Token: 0x04015156 RID: 86358
		internal static int __PropertyOffset_27;

		// Token: 0x04015157 RID: 86359
		internal static int __PropertyOffset_28;

		// Token: 0x04015158 RID: 86360
		internal static int __PropertyOffset_29;

		// Token: 0x04015159 RID: 86361
		internal static int __PropertyOffset_30;

		// Token: 0x0401515A RID: 86362
		internal static int __PropertyOffset_31;

		// Token: 0x0401515B RID: 86363
		[Nullable(2)]
		private SAiWeaponSocket _AiWeaponSocket;

		// Token: 0x0401515C RID: 86364
		internal static int __PropertyOffset_32;

		// Token: 0x0401515D RID: 86365
		internal static int __PropertyOffset_33;

		// Token: 0x0401515E RID: 86366
		internal static int __PropertyOffset_34;

		// Token: 0x0401515F RID: 86367
		internal static int __PropertyOffset_35;

		// Token: 0x04015160 RID: 86368
		[Nullable(new byte[]
		{
			2,
			1,
			1
		})]
		private TMap<string, string> _param;

		// Token: 0x04015161 RID: 86369
		internal static int __PropertyOffset_36;

		// Token: 0x04015162 RID: 86370
		internal static int __PropertyOffset_37;

		// Token: 0x04015163 RID: 86371
		[Nullable(2)]
		private TArray<long> _BornBuff;

		// Token: 0x04015164 RID: 86372
		internal static int __PropertyOffset_38;
	}
}
