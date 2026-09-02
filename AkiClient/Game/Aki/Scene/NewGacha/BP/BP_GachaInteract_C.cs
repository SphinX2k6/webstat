using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Scene.NewGacha.BP
{
	// Token: 0x020039C9 RID: 14793
	[NullableContext(2)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Scene/NewGacha/BP/BP_GachaInteract.BP_GachaInteract_C")]
	[UnrealStructLayout(1576, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 1569)]
	public class BP_GachaInteract_C : AKuroEditorTickActor, IUnrealUObject, IUnrealObject, IBPI_Gacha_C, IUnrealBlueprintInterface, IUnrealInterface
	{
		// Token: 0x0601DE97 RID: 122519 RVA: 0x008E6B95 File Offset: 0x008E4D95
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_GachaInteract_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Scene/NewGacha/BP/BP_GachaInteract.BP_GachaInteract_C");
			}
			return BP_GachaInteract_C._ClassPtr;
		}

		// Token: 0x0601DE98 RID: 122520 RVA: 0x008E6BBC File Offset: 0x008E4DBC
		public BP_GachaInteract_C() : this(BuiltinUtils.AllocNativeUObject(BP_GachaInteract_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x0601DE99 RID: 122521 RVA: 0x008E6BE4 File Offset: 0x008E4DE4
		[NullableContext(1)]
		public BP_GachaInteract_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_GachaInteract_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x170027C2 RID: 10178
		// (get) Token: 0x0601DE9A RID: 122522 RVA: 0x008E6C18 File Offset: 0x008E4E18
		// (set) Token: 0x0601DE9B RID: 122523 RVA: 0x008E6C51 File Offset: 0x008E4E51
		[Nullable(1)]
		public FPointerToUberGraphFrame UberGraphFrame
		{
			[NullableContext(1)]
			get
			{
				base.FastCheckIsValid();
				FPointerToUberGraphFrame result;
				if ((result = this._UberGraphFrame) == null)
				{
					result = (this._UberGraphFrame = new FPointerToUberGraphFrame(base.NativePtr + (IntPtr)BP_GachaInteract_C.__PropertyOffset_0, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FPointerToUberGraphFrame.StaticStruct(), base.NativePtr + (IntPtr)BP_GachaInteract_C.__PropertyOffset_0, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170027C3 RID: 10179
		// (get) Token: 0x0601DE9C RID: 122524 RVA: 0x008E6C72 File Offset: 0x008E4E72
		// (set) Token: 0x0601DE9D RID: 122525 RVA: 0x008E6C86 File Offset: 0x008E4E86
		public unsafe UChildActorComponent Sequence02
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UChildActorComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_GachaInteract_C.__PropertyOffset_1);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_GachaInteract_C.__PropertyOffset_1, value);
			}
		}

		// Token: 0x170027C4 RID: 10180
		// (get) Token: 0x0601DE9E RID: 122526 RVA: 0x008E6C9B File Offset: 0x008E4E9B
		// (set) Token: 0x0601DE9F RID: 122527 RVA: 0x008E6CAF File Offset: 0x008E4EAF
		public unsafe UStaticMeshComponent Plane
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UStaticMeshComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_GachaInteract_C.__PropertyOffset_2);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_GachaInteract_C.__PropertyOffset_2, value);
			}
		}

		// Token: 0x170027C5 RID: 10181
		// (get) Token: 0x0601DEA0 RID: 122528 RVA: 0x008E6CC4 File Offset: 0x008E4EC4
		// (set) Token: 0x0601DEA1 RID: 122529 RVA: 0x008E6CD8 File Offset: 0x008E4ED8
		public unsafe UStaticMeshComponent Cube
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UStaticMeshComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_GachaInteract_C.__PropertyOffset_3);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_GachaInteract_C.__PropertyOffset_3, value);
			}
		}

		// Token: 0x170027C6 RID: 10182
		// (get) Token: 0x0601DEA2 RID: 122530 RVA: 0x008E6CED File Offset: 0x008E4EED
		// (set) Token: 0x0601DEA3 RID: 122531 RVA: 0x008E6D01 File Offset: 0x008E4F01
		public unsafe USceneComponent DefaultSceneRoot
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<USceneComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_GachaInteract_C.__PropertyOffset_4);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_GachaInteract_C.__PropertyOffset_4, value);
			}
		}

		// Token: 0x170027C7 RID: 10183
		// (get) Token: 0x0601DEA4 RID: 122532 RVA: 0x008E6D16 File Offset: 0x008E4F16
		// (set) Token: 0x0601DEA5 RID: 122533 RVA: 0x008E6D26 File Offset: 0x008E4F26
		public unsafe float Timeline_0_NewTrack_1_10DC02544B28F1F647045DBFB41885D3
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_GachaInteract_C.__PropertyOffset_5);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_GachaInteract_C.__PropertyOffset_5) = value;
			}
		}

		// Token: 0x170027C8 RID: 10184
		// (get) Token: 0x0601DEA6 RID: 122534 RVA: 0x008E6D37 File Offset: 0x008E4F37
		// (set) Token: 0x0601DEA7 RID: 122535 RVA: 0x008E6D47 File Offset: 0x008E4F47
		public unsafe float Timeline_0_NewTrack_0_10DC02544B28F1F647045DBFB41885D3
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_GachaInteract_C.__PropertyOffset_6);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_GachaInteract_C.__PropertyOffset_6) = value;
			}
		}

		// Token: 0x170027C9 RID: 10185
		// (get) Token: 0x0601DEA8 RID: 122536 RVA: 0x008E6D58 File Offset: 0x008E4F58
		// (set) Token: 0x0601DEA9 RID: 122537 RVA: 0x008E6D6C File Offset: 0x008E4F6C
		[Nullable(0)]
		public unsafe TEnumAsByte<ETimelineDirection> Timeline_0__Direction_10DC02544B28F1F647045DBFB41885D3
		{
			[NullableContext(0)]
			get
			{
				return *(base.NativePtr + (IntPtr)BP_GachaInteract_C.__PropertyOffset_7);
			}
			[NullableContext(0)]
			set
			{
				*(base.NativePtr + (IntPtr)BP_GachaInteract_C.__PropertyOffset_7) = value;
			}
		}

		// Token: 0x170027CA RID: 10186
		// (get) Token: 0x0601DEAA RID: 122538 RVA: 0x008E6D81 File Offset: 0x008E4F81
		// (set) Token: 0x0601DEAB RID: 122539 RVA: 0x008E6D95 File Offset: 0x008E4F95
		public unsafe UTimelineComponent Timeline_0
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UTimelineComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_GachaInteract_C.__PropertyOffset_8);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_GachaInteract_C.__PropertyOffset_8, value);
			}
		}

		// Token: 0x170027CB RID: 10187
		// (get) Token: 0x0601DEAC RID: 122540 RVA: 0x008E6DAA File Offset: 0x008E4FAA
		// (set) Token: 0x0601DEAD RID: 122541 RVA: 0x008E6DBE File Offset: 0x008E4FBE
		[Nullable(0)]
		public unsafe TEnumAsByte<E_GachaResultNew> Gacha_Result
		{
			[NullableContext(0)]
			get
			{
				return *(base.NativePtr + (IntPtr)BP_GachaInteract_C.__PropertyOffset_9);
			}
			[NullableContext(0)]
			set
			{
				*(base.NativePtr + (IntPtr)BP_GachaInteract_C.__PropertyOffset_9) = value;
			}
		}

		// Token: 0x170027CC RID: 10188
		// (get) Token: 0x0601DEAE RID: 122542 RVA: 0x008E6DD3 File Offset: 0x008E4FD3
		// (set) Token: 0x0601DEAF RID: 122543 RVA: 0x008E6DE7 File Offset: 0x008E4FE7
		public unsafe ASpotLight SpotLightInteract
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<ASpotLight>(base.NativePtr / (IntPtr)sizeof(void*) + BP_GachaInteract_C.__PropertyOffset_10);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_GachaInteract_C.__PropertyOffset_10, value);
			}
		}

		// Token: 0x170027CD RID: 10189
		// (get) Token: 0x0601DEB0 RID: 122544 RVA: 0x008E6DFC File Offset: 0x008E4FFC
		// (set) Token: 0x0601DEB1 RID: 122545 RVA: 0x008E6E10 File Offset: 0x008E5010
		public unsafe ACameraActor CameraShow
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<ACameraActor>(base.NativePtr / (IntPtr)sizeof(void*) + BP_GachaInteract_C.__PropertyOffset_11);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_GachaInteract_C.__PropertyOffset_11, value);
			}
		}

		// Token: 0x170027CE RID: 10190
		// (get) Token: 0x0601DEB2 RID: 122546 RVA: 0x008E6E25 File Offset: 0x008E5025
		// (set) Token: 0x0601DEB3 RID: 122547 RVA: 0x008E6E39 File Offset: 0x008E5039
		public unsafe FLinearColor Purple
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_GachaInteract_C.__PropertyOffset_12);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_GachaInteract_C.__PropertyOffset_12) = value;
			}
		}

		// Token: 0x170027CF RID: 10191
		// (get) Token: 0x0601DEB4 RID: 122548 RVA: 0x008E6E4E File Offset: 0x008E504E
		// (set) Token: 0x0601DEB5 RID: 122549 RVA: 0x008E6E62 File Offset: 0x008E5062
		public unsafe FLinearColor Gold
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_GachaInteract_C.__PropertyOffset_13);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_GachaInteract_C.__PropertyOffset_13) = value;
			}
		}

		// Token: 0x170027D0 RID: 10192
		// (get) Token: 0x0601DEB6 RID: 122550 RVA: 0x008E6E77 File Offset: 0x008E5077
		// (set) Token: 0x0601DEB7 RID: 122551 RVA: 0x008E6E8B File Offset: 0x008E508B
		public unsafe FLinearColor Normal
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_GachaInteract_C.__PropertyOffset_14);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_GachaInteract_C.__PropertyOffset_14) = value;
			}
		}

		// Token: 0x170027D1 RID: 10193
		// (get) Token: 0x0601DEB8 RID: 122552 RVA: 0x008E6EA0 File Offset: 0x008E50A0
		// (set) Token: 0x0601DEB9 RID: 122553 RVA: 0x008E6EB4 File Offset: 0x008E50B4
		public unsafe FLinearColor AwardColor
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_GachaInteract_C.__PropertyOffset_15);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_GachaInteract_C.__PropertyOffset_15) = value;
			}
		}

		// Token: 0x170027D2 RID: 10194
		// (get) Token: 0x0601DEBA RID: 122554 RVA: 0x008E6EC9 File Offset: 0x008E50C9
		// (set) Token: 0x0601DEBB RID: 122555 RVA: 0x008E6EDD File Offset: 0x008E50DD
		public unsafe ASpotLight Spot_Light_Seq
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<ASpotLight>(base.NativePtr / (IntPtr)sizeof(void*) + BP_GachaInteract_C.__PropertyOffset_16);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_GachaInteract_C.__PropertyOffset_16, value);
			}
		}

		// Token: 0x170027D3 RID: 10195
		// (get) Token: 0x0601DEBC RID: 122556 RVA: 0x008E6EF2 File Offset: 0x008E50F2
		// (set) Token: 0x0601DEBD RID: 122557 RVA: 0x008E6F06 File Offset: 0x008E5106
		public unsafe BP_UpdateInteract_C UpdateInteract
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<BP_UpdateInteract_C>(base.NativePtr / (IntPtr)sizeof(void*) + BP_GachaInteract_C.__PropertyOffset_17);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_GachaInteract_C.__PropertyOffset_17, value);
			}
		}

		// Token: 0x170027D4 RID: 10196
		// (get) Token: 0x0601DEBE RID: 122558 RVA: 0x008E6F1B File Offset: 0x008E511B
		// (set) Token: 0x0601DEBF RID: 122559 RVA: 0x008E6F2F File Offset: 0x008E512F
		public unsafe ACameraActor CameraShowRoom
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<ACameraActor>(base.NativePtr / (IntPtr)sizeof(void*) + BP_GachaInteract_C.__PropertyOffset_18);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_GachaInteract_C.__PropertyOffset_18, value);
			}
		}

		// Token: 0x170027D5 RID: 10197
		// (get) Token: 0x0601DEC0 RID: 122560 RVA: 0x008E6F44 File Offset: 0x008E5144
		// (set) Token: 0x0601DEC1 RID: 122561 RVA: 0x008E6F54 File Offset: 0x008E5154
		public unsafe float WhiteScreenWeight
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_GachaInteract_C.__PropertyOffset_19);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_GachaInteract_C.__PropertyOffset_19) = value;
			}
		}

		// Token: 0x170027D6 RID: 10198
		// (get) Token: 0x0601DEC2 RID: 122562 RVA: 0x008E6F65 File Offset: 0x008E5165
		// (set) Token: 0x0601DEC3 RID: 122563 RVA: 0x008E6F75 File Offset: 0x008E5175
		public unsafe bool WhiteScreen
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_GachaInteract_C.__PropertyOffset_20) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_GachaInteract_C.__PropertyOffset_20) = (value ? 1 : 0);
			}
		}

		// Token: 0x170027D7 RID: 10199
		// (get) Token: 0x0601DEC4 RID: 122564 RVA: 0x008E6F86 File Offset: 0x008E5186
		// (set) Token: 0x0601DEC5 RID: 122565 RVA: 0x008E6F9A File Offset: 0x008E519A
		public unsafe ALevelSequenceActor LevelSequenceShow
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<ALevelSequenceActor>(base.NativePtr / (IntPtr)sizeof(void*) + BP_GachaInteract_C.__PropertyOffset_21);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_GachaInteract_C.__PropertyOffset_21, value);
			}
		}

		// Token: 0x170027D8 RID: 10200
		// (get) Token: 0x0601DEC6 RID: 122566 RVA: 0x008E6FAF File Offset: 0x008E51AF
		// (set) Token: 0x0601DEC7 RID: 122567 RVA: 0x008E6FC3 File Offset: 0x008E51C3
		public unsafe ALevelSequenceActor LevelSequenceInteract
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<ALevelSequenceActor>(base.NativePtr / (IntPtr)sizeof(void*) + BP_GachaInteract_C.__PropertyOffset_22);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_GachaInteract_C.__PropertyOffset_22, value);
			}
		}

		// Token: 0x170027D9 RID: 10201
		// (get) Token: 0x0601DEC8 RID: 122568 RVA: 0x008E6FD8 File Offset: 0x008E51D8
		// (set) Token: 0x0601DEC9 RID: 122569 RVA: 0x008E7011 File Offset: 0x008E5211
		[Nullable(1)]
		public TArray<ULevelSequence> LevelSeqAll
		{
			[NullableContext(1)]
			get
			{
				base.FastCheckIsValid();
				TArray<ULevelSequence> result;
				if ((result = this._LevelSeqAll) == null)
				{
					result = (this._LevelSeqAll = new TArray<ULevelSequence>(base.NativePtr + (IntPtr)BP_GachaInteract_C.__PropertyOffset_23, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				this.LevelSeqAll.CopyAssign(value);
			}
		}

		// Token: 0x170027DA RID: 10202
		// (get) Token: 0x0601DECA RID: 122570 RVA: 0x008E701F File Offset: 0x008E521F
		// (set) Token: 0x0601DECB RID: 122571 RVA: 0x008E7033 File Offset: 0x008E5233
		public unsafe AActor Root
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<AActor>(base.NativePtr / (IntPtr)sizeof(void*) + BP_GachaInteract_C.__PropertyOffset_24);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_GachaInteract_C.__PropertyOffset_24, value);
			}
		}

		// Token: 0x170027DB RID: 10203
		// (get) Token: 0x0601DECC RID: 122572 RVA: 0x008E7048 File Offset: 0x008E5248
		// (set) Token: 0x0601DECD RID: 122573 RVA: 0x008E7058 File Offset: 0x008E5258
		public unsafe bool FinishedInitGachaResults
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_GachaInteract_C.__PropertyOffset_25) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_GachaInteract_C.__PropertyOffset_25) = (value ? 1 : 0);
			}
		}

		// Token: 0x170027DC RID: 10204
		// (get) Token: 0x0601DECE RID: 122574 RVA: 0x008E7069 File Offset: 0x008E5269
		// (set) Token: 0x0601DECF RID: 122575 RVA: 0x008E7079 File Offset: 0x008E5279
		public unsafe bool ShowUpdaterOn
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_GachaInteract_C.__PropertyOffset_26) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_GachaInteract_C.__PropertyOffset_26) = (value ? 1 : 0);
			}
		}

		// Token: 0x170027DD RID: 10205
		// (get) Token: 0x0601DED0 RID: 122576 RVA: 0x008E708A File Offset: 0x008E528A
		// (set) Token: 0x0601DED1 RID: 122577 RVA: 0x008E709A File Offset: 0x008E529A
		public unsafe bool IsSkip
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_GachaInteract_C.__PropertyOffset_27) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_GachaInteract_C.__PropertyOffset_27) = (value ? 1 : 0);
			}
		}

		// Token: 0x170027DE RID: 10206
		// (get) Token: 0x0601DED2 RID: 122578 RVA: 0x008E70AB File Offset: 0x008E52AB
		// (set) Token: 0x0601DED3 RID: 122579 RVA: 0x008E70BF File Offset: 0x008E52BF
		public unsafe AStaticMeshActor SkyBoxShow
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<AStaticMeshActor>(base.NativePtr / (IntPtr)sizeof(void*) + BP_GachaInteract_C.__PropertyOffset_28);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_GachaInteract_C.__PropertyOffset_28, value);
			}
		}

		// Token: 0x170027DF RID: 10207
		// (get) Token: 0x0601DED4 RID: 122580 RVA: 0x008E70D4 File Offset: 0x008E52D4
		// (set) Token: 0x0601DED5 RID: 122581 RVA: 0x008E70E8 File Offset: 0x008E52E8
		[Nullable(1)]
		public unsafe string _string
		{
			[NullableContext(1)]
			get
			{
				return FString.ToString((void*)(base.NativePtr + (byte*)((IntPtr)BP_GachaInteract_C.__PropertyOffset_29)));
			}
			[NullableContext(1)]
			set
			{
				FString.CopyFrom((void*)(base.NativePtr + (byte*)((IntPtr)BP_GachaInteract_C.__PropertyOffset_29)), value);
			}
		}

		// Token: 0x170027E0 RID: 10208
		// (get) Token: 0x0601DED6 RID: 122582 RVA: 0x008E70FD File Offset: 0x008E52FD
		// (set) Token: 0x0601DED7 RID: 122583 RVA: 0x008E710D File Offset: 0x008E530D
		public unsafe bool tickable
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_GachaInteract_C.__PropertyOffset_30) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_GachaInteract_C.__PropertyOffset_30) = (value ? 1 : 0);
			}
		}

		// Token: 0x0601DED8 RID: 122584 RVA: 0x008E7120 File Offset: 0x008E5320
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void IntroStart(int Frame, float Subtime)
		{
			BP_GachaInteract_C.__IntroStart_FunctionParams* ptr = stackalloc BP_GachaInteract_C.__IntroStart_FunctionParams[(UIntPtr)23] + 15L / (long)sizeof(BP_GachaInteract_C.__IntroStart_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_GachaInteract_C.__IntroStart_NativeFunctionPtr, (void*)ptr, 1);
			ptr->Frame = Frame;
			ptr->Subtime = Subtime;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_GachaInteract_C.__IntroStart_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0601DED9 RID: 122585 RVA: 0x008E716D File Offset: 0x008E536D
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void TSGachaShowroomStart()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_GachaInteract_C.__TSGachaShowroomStart_NativeFunctionPtr, null);
		}

		// Token: 0x0601DEDA RID: 122586 RVA: 0x008E7184 File Offset: 0x008E5384
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void IsNewWorkFlow(ref bool IsNew)
		{
			BP_GachaInteract_C.__IsNewWorkFlow_FunctionParams* ptr = stackalloc BP_GachaInteract_C.__IsNewWorkFlow_FunctionParams[(UIntPtr)16] + 15L / (long)sizeof(BP_GachaInteract_C.__IsNewWorkFlow_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_GachaInteract_C.__IsNewWorkFlow_NativeFunctionPtr, (void*)ptr, 1);
			ptr->IsNew = IsNew;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_GachaInteract_C.__IsNewWorkFlow_NativeFunctionPtr, (void*)ptr);
			IsNew = ptr->IsNew;
		}

		// Token: 0x0601DEDB RID: 122587 RVA: 0x008E71D4 File Offset: 0x008E53D4
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void SelectLevelSeq(int Num)
		{
			BP_GachaInteract_C.__SelectLevelSeq_FunctionParams* ptr = stackalloc BP_GachaInteract_C.__SelectLevelSeq_FunctionParams[(UIntPtr)47] + 15L / (long)sizeof(BP_GachaInteract_C.__SelectLevelSeq_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_GachaInteract_C.__SelectLevelSeq_NativeFunctionPtr, (void*)ptr, 1);
			ptr->Num = Num;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_GachaInteract_C.__SelectLevelSeq_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0601DEDC RID: 122588 RVA: 0x008E721A File Offset: 0x008E541A
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void _5SSTenShotGold()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_GachaInteract_C.___5SSTenShotGold_NativeFunctionPtr, null);
		}

		// Token: 0x0601DEDD RID: 122589 RVA: 0x008E722E File Offset: 0x008E542E
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void _4SSTenShotPurple()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_GachaInteract_C.___4SSTenShotPurple_NativeFunctionPtr, null);
		}

		// Token: 0x0601DEDE RID: 122590 RVA: 0x008E7242 File Offset: 0x008E5442
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void _3SSOneShotGold()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_GachaInteract_C.___3SSOneShotGold_NativeFunctionPtr, null);
		}

		// Token: 0x0601DEDF RID: 122591 RVA: 0x008E7256 File Offset: 0x008E5456
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void _2SSOneShotPurple()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_GachaInteract_C.___2SSOneShotPurple_NativeFunctionPtr, null);
		}

		// Token: 0x0601DEE0 RID: 122592 RVA: 0x008E726A File Offset: 0x008E546A
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void _1SSOneShotNormal()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_GachaInteract_C.___1SSOneShotNormal_NativeFunctionPtr, null);
		}

		// Token: 0x0601DEE1 RID: 122593 RVA: 0x008E7280 File Offset: 0x008E5480
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void TSInitParameters(E_GachaResultNew GachaResult)
		{
			BP_GachaInteract_C.__TSInitParameters_FunctionParams* ptr = stackalloc BP_GachaInteract_C.__TSInitParameters_FunctionParams[(UIntPtr)16] + 15L / (long)sizeof(BP_GachaInteract_C.__TSInitParameters_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_GachaInteract_C.__TSInitParameters_NativeFunctionPtr, (void*)ptr, 1);
			ptr->GachaResult = GachaResult;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_GachaInteract_C.__TSInitParameters_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0601DEE2 RID: 122594 RVA: 0x008E72CB File Offset: 0x008E54CB
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void Init_Award_Parameters()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_GachaInteract_C.__Init_Award_Parameters_NativeFunctionPtr, null);
		}

		// Token: 0x0601DEE3 RID: 122595 RVA: 0x008E72DF File Offset: 0x008E54DF
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void UserConstructionScript()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_GachaInteract_C.__UserConstructionScript_NativeFunctionPtr, null);
		}

		// Token: 0x0601DEE4 RID: 122596 RVA: 0x008E72F3 File Offset: 0x008E54F3
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected virtual void UserConstructionScript_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_GachaInteract_C.__UserConstructionScript_NativeFunctionPtr, null, 0);
		}

		// Token: 0x0601DEE5 RID: 122597 RVA: 0x008E7308 File Offset: 0x008E5508
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void Timeline_0__FinishedFunc()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_GachaInteract_C.__Timeline_0__FinishedFunc_NativeFunctionPtr, null);
		}

		// Token: 0x0601DEE6 RID: 122598 RVA: 0x008E731C File Offset: 0x008E551C
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void Timeline_0__UpdateFunc()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_GachaInteract_C.__Timeline_0__UpdateFunc_NativeFunctionPtr, null);
		}

		// Token: 0x0601DEE7 RID: 122599 RVA: 0x008E7330 File Offset: 0x008E5530
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void InteractStart(int Frame, float Subtime)
		{
			BP_GachaInteract_C.__InteractStart_FunctionParams* ptr = stackalloc BP_GachaInteract_C.__InteractStart_FunctionParams[(UIntPtr)23] + 15L / (long)sizeof(BP_GachaInteract_C.__InteractStart_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_GachaInteract_C.__InteractStart_NativeFunctionPtr, (void*)ptr, 1);
			ptr->Frame = Frame;
			ptr->Subtime = Subtime;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_GachaInteract_C.__InteractStart_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0601DEE8 RID: 122600 RVA: 0x008E7380 File Offset: 0x008E5580
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void OutroStart(int Frame, float Subtime)
		{
			BP_GachaInteract_C.__OutroStart_FunctionParams* ptr = stackalloc BP_GachaInteract_C.__OutroStart_FunctionParams[(UIntPtr)23] + 15L / (long)sizeof(BP_GachaInteract_C.__OutroStart_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_GachaInteract_C.__OutroStart_NativeFunctionPtr, (void*)ptr, 1);
			ptr->Frame = Frame;
			ptr->Subtime = Subtime;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_GachaInteract_C.__OutroStart_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0601DEE9 RID: 122601 RVA: 0x008E73D0 File Offset: 0x008E55D0
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void ShowroomStart(int Frame, float Subtime)
		{
			BP_GachaInteract_C.__ShowroomStart_FunctionParams* ptr = stackalloc BP_GachaInteract_C.__ShowroomStart_FunctionParams[(UIntPtr)23] + 15L / (long)sizeof(BP_GachaInteract_C.__ShowroomStart_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_GachaInteract_C.__ShowroomStart_NativeFunctionPtr, (void*)ptr, 1);
			ptr->Frame = Frame;
			ptr->Subtime = Subtime;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_GachaInteract_C.__ShowroomStart_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0601DEEA RID: 122602 RVA: 0x008E741D File Offset: 0x008E561D
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void ReceiveBeginPlay()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_GachaInteract_C.__ReceiveBeginPlay_NativeFunctionPtr, null);
		}

		// Token: 0x0601DEEB RID: 122603 RVA: 0x008E7431 File Offset: 0x008E5631
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected virtual void ReceiveBeginPlay_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_GachaInteract_C.__ReceiveBeginPlay_NativeFunctionPtr, null, 0);
		}

		// Token: 0x0601DEEC RID: 122604 RVA: 0x008E7448 File Offset: 0x008E5648
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void ReceiveTick(float DeltaSeconds)
		{
			BP_GachaInteract_C.__ReceiveTick_FunctionParams* ptr = stackalloc BP_GachaInteract_C.__ReceiveTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_GachaInteract_C.__ReceiveTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_GachaInteract_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_GachaInteract_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0601DEED RID: 122605 RVA: 0x008E7490 File Offset: 0x008E5690
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe virtual void ReceiveTick_Implementation(float DeltaSeconds)
		{
			BP_GachaInteract_C.__ReceiveTick_FunctionParams* ptr = stackalloc BP_GachaInteract_C.__ReceiveTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_GachaInteract_C.__ReceiveTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_GachaInteract_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_GachaInteract_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x0601DEEE RID: 122606 RVA: 0x008E74D7 File Offset: 0x008E56D7
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void EndGachaSequence()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_GachaInteract_C.__EndGachaSequence_NativeFunctionPtr, null);
		}

		// Token: 0x0601DEEF RID: 122607 RVA: 0x008E74EB File Offset: 0x008E56EB
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void InitGachaResults()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_GachaInteract_C.__InitGachaResults_NativeFunctionPtr, null);
		}

		// Token: 0x0601DEF0 RID: 122608 RVA: 0x008E74FF File Offset: 0x008E56FF
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void WhiteScreenStart()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_GachaInteract_C.__WhiteScreenStart_NativeFunctionPtr, null);
		}

		// Token: 0x0601DEF1 RID: 122609 RVA: 0x008E7513 File Offset: 0x008E5713
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void WhiteScreenOff()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_GachaInteract_C.__WhiteScreenOff_NativeFunctionPtr, null);
		}

		// Token: 0x0601DEF2 RID: 122610 RVA: 0x008E7527 File Offset: 0x008E5727
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void Sequence_finshed()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_GachaInteract_C.__Sequence_finshed_NativeFunctionPtr, null);
		}

		// Token: 0x0601DEF3 RID: 122611 RVA: 0x008E753B File Offset: 0x008E573B
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void New_Outro()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_GachaInteract_C.__New_Outro_NativeFunctionPtr, null);
		}

		// Token: 0x0601DEF4 RID: 122612 RVA: 0x008E754F File Offset: 0x008E574F
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void SetGachaShowSeq()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_GachaInteract_C.__SetGachaShowSeq_NativeFunctionPtr, null);
		}

		// Token: 0x0601DEF5 RID: 122613 RVA: 0x008E7563 File Offset: 0x008E5763
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void Updater()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_GachaInteract_C.__Updater_NativeFunctionPtr, null);
		}

		// Token: 0x0601DEF6 RID: 122614 RVA: 0x008E7577 File Offset: 0x008E5777
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void Finished()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_GachaInteract_C.__Finished_NativeFunctionPtr, null);
		}

		// Token: 0x0601DEF7 RID: 122615 RVA: 0x008E758B File Offset: 0x008E578B
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void ReceiveDestroyed()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_GachaInteract_C.__ReceiveDestroyed_NativeFunctionPtr, null);
		}

		// Token: 0x0601DEF8 RID: 122616 RVA: 0x008E759F File Offset: 0x008E579F
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected virtual void ReceiveDestroyed_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_GachaInteract_C.__ReceiveDestroyed_NativeFunctionPtr, null, 0);
		}

		// Token: 0x0601DEF9 RID: 122617 RVA: 0x008E75B4 File Offset: 0x008E57B4
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void ReceiveEndPlay(EEndPlayReason EndPlayReason)
		{
			BP_GachaInteract_C.__ReceiveEndPlay_FunctionParams* ptr = stackalloc BP_GachaInteract_C.__ReceiveEndPlay_FunctionParams[(UIntPtr)16] + 15L / (long)sizeof(BP_GachaInteract_C.__ReceiveEndPlay_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_GachaInteract_C.__ReceiveEndPlay_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EndPlayReason = EndPlayReason;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_GachaInteract_C.__ReceiveEndPlay_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0601DEFA RID: 122618 RVA: 0x008E7600 File Offset: 0x008E5800
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe virtual void ReceiveEndPlay_Implementation(EEndPlayReason EndPlayReason)
		{
			BP_GachaInteract_C.__ReceiveEndPlay_FunctionParams* ptr = stackalloc BP_GachaInteract_C.__ReceiveEndPlay_FunctionParams[(UIntPtr)16] + 15L / (long)sizeof(BP_GachaInteract_C.__ReceiveEndPlay_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_GachaInteract_C.__ReceiveEndPlay_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EndPlayReason = EndPlayReason;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_GachaInteract_C.__ReceiveEndPlay_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x0601DEFB RID: 122619 RVA: 0x008E764C File Offset: 0x008E584C
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe void ExecuteUbergraph_BP_GachaInteract(int EntryPoint)
		{
			BP_GachaInteract_C.__ExecuteUbergraph_BP_GachaInteract_FunctionParams* ptr = stackalloc BP_GachaInteract_C.__ExecuteUbergraph_BP_GachaInteract_FunctionParams[(UIntPtr)343] + 15L / (long)sizeof(BP_GachaInteract_C.__ExecuteUbergraph_BP_GachaInteract_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_GachaInteract_C.__ExecuteUbergraph_BP_GachaInteract_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EntryPoint = EntryPoint;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_GachaInteract_C.__ExecuteUbergraph_BP_GachaInteract_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x0601DEFC RID: 122620 RVA: 0x008E7696 File Offset: 0x008E5896
		protected BP_GachaInteract_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x0400EA89 RID: 60041
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Scene/NewGacha/BP/BP_GachaInteract.BP_GachaInteract_C";

		// Token: 0x0400EA8A RID: 60042
		private static IntPtr _ClassPtr;

		// Token: 0x0400EA8B RID: 60043
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x0400EA8C RID: 60044
		internal static int __PropertyOffset_0;

		// Token: 0x0400EA8D RID: 60045
		private FPointerToUberGraphFrame _UberGraphFrame;

		// Token: 0x0400EA8E RID: 60046
		internal static int __PropertyOffset_1;

		// Token: 0x0400EA8F RID: 60047
		internal static int __PropertyOffset_2;

		// Token: 0x0400EA90 RID: 60048
		internal static int __PropertyOffset_3;

		// Token: 0x0400EA91 RID: 60049
		internal static int __PropertyOffset_4;

		// Token: 0x0400EA92 RID: 60050
		internal static int __PropertyOffset_5;

		// Token: 0x0400EA93 RID: 60051
		internal static int __PropertyOffset_6;

		// Token: 0x0400EA94 RID: 60052
		internal static int __PropertyOffset_7;

		// Token: 0x0400EA95 RID: 60053
		internal static int __PropertyOffset_8;

		// Token: 0x0400EA96 RID: 60054
		internal static int __PropertyOffset_9;

		// Token: 0x0400EA97 RID: 60055
		internal static int __PropertyOffset_10;

		// Token: 0x0400EA98 RID: 60056
		internal static int __PropertyOffset_11;

		// Token: 0x0400EA99 RID: 60057
		internal static int __PropertyOffset_12;

		// Token: 0x0400EA9A RID: 60058
		internal static int __PropertyOffset_13;

		// Token: 0x0400EA9B RID: 60059
		internal static int __PropertyOffset_14;

		// Token: 0x0400EA9C RID: 60060
		internal static int __PropertyOffset_15;

		// Token: 0x0400EA9D RID: 60061
		internal static int __PropertyOffset_16;

		// Token: 0x0400EA9E RID: 60062
		internal static int __PropertyOffset_17;

		// Token: 0x0400EA9F RID: 60063
		internal static int __PropertyOffset_18;

		// Token: 0x0400EAA0 RID: 60064
		internal static int __PropertyOffset_19;

		// Token: 0x0400EAA1 RID: 60065
		internal static int __PropertyOffset_20;

		// Token: 0x0400EAA2 RID: 60066
		internal static int __PropertyOffset_21;

		// Token: 0x0400EAA3 RID: 60067
		internal static int __PropertyOffset_22;

		// Token: 0x0400EAA4 RID: 60068
		internal static int __PropertyOffset_23;

		// Token: 0x0400EAA5 RID: 60069
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private TArray<ULevelSequence> _LevelSeqAll;

		// Token: 0x0400EAA6 RID: 60070
		internal static int __PropertyOffset_24;

		// Token: 0x0400EAA7 RID: 60071
		internal static int __PropertyOffset_25;

		// Token: 0x0400EAA8 RID: 60072
		internal static int __PropertyOffset_26;

		// Token: 0x0400EAA9 RID: 60073
		internal static int __PropertyOffset_27;

		// Token: 0x0400EAAA RID: 60074
		internal static int __PropertyOffset_28;

		// Token: 0x0400EAAB RID: 60075
		internal static int __PropertyOffset_29;

		// Token: 0x0400EAAC RID: 60076
		internal static int __PropertyOffset_30;

		// Token: 0x0400EAAD RID: 60077
		private static IntPtr __IntroStart_NativeFunctionPtr;

		// Token: 0x0400EAAE RID: 60078
		private static IntPtr __TSGachaShowroomStart_NativeFunctionPtr;

		// Token: 0x0400EAAF RID: 60079
		private static IntPtr __IsNewWorkFlow_NativeFunctionPtr;

		// Token: 0x0400EAB0 RID: 60080
		private static IntPtr __SelectLevelSeq_NativeFunctionPtr;

		// Token: 0x0400EAB1 RID: 60081
		private static IntPtr ___5SSTenShotGold_NativeFunctionPtr;

		// Token: 0x0400EAB2 RID: 60082
		private static IntPtr ___4SSTenShotPurple_NativeFunctionPtr;

		// Token: 0x0400EAB3 RID: 60083
		private static IntPtr ___3SSOneShotGold_NativeFunctionPtr;

		// Token: 0x0400EAB4 RID: 60084
		private static IntPtr ___2SSOneShotPurple_NativeFunctionPtr;

		// Token: 0x0400EAB5 RID: 60085
		private static IntPtr ___1SSOneShotNormal_NativeFunctionPtr;

		// Token: 0x0400EAB6 RID: 60086
		private static IntPtr __TSInitParameters_NativeFunctionPtr;

		// Token: 0x0400EAB7 RID: 60087
		private static IntPtr __Init_Award_Parameters_NativeFunctionPtr;

		// Token: 0x0400EAB8 RID: 60088
		private static IntPtr __UserConstructionScript_NativeFunctionPtr;

		// Token: 0x0400EAB9 RID: 60089
		private static IntPtr __Timeline_0__FinishedFunc_NativeFunctionPtr;

		// Token: 0x0400EABA RID: 60090
		private static IntPtr __Timeline_0__UpdateFunc_NativeFunctionPtr;

		// Token: 0x0400EABB RID: 60091
		private static IntPtr __InteractStart_NativeFunctionPtr;

		// Token: 0x0400EABC RID: 60092
		private static IntPtr __OutroStart_NativeFunctionPtr;

		// Token: 0x0400EABD RID: 60093
		private static IntPtr __ShowroomStart_NativeFunctionPtr;

		// Token: 0x0400EABE RID: 60094
		private static IntPtr __ReceiveBeginPlay_NativeFunctionPtr;

		// Token: 0x0400EABF RID: 60095
		private static IntPtr __ReceiveTick_NativeFunctionPtr;

		// Token: 0x0400EAC0 RID: 60096
		private static IntPtr __EndGachaSequence_NativeFunctionPtr;

		// Token: 0x0400EAC1 RID: 60097
		private static IntPtr __InitGachaResults_NativeFunctionPtr;

		// Token: 0x0400EAC2 RID: 60098
		private static IntPtr __WhiteScreenStart_NativeFunctionPtr;

		// Token: 0x0400EAC3 RID: 60099
		private static IntPtr __WhiteScreenOff_NativeFunctionPtr;

		// Token: 0x0400EAC4 RID: 60100
		private static IntPtr __Sequence_finshed_NativeFunctionPtr;

		// Token: 0x0400EAC5 RID: 60101
		private static IntPtr __New_Outro_NativeFunctionPtr;

		// Token: 0x0400EAC6 RID: 60102
		private static IntPtr __SetGachaShowSeq_NativeFunctionPtr;

		// Token: 0x0400EAC7 RID: 60103
		private static IntPtr __Updater_NativeFunctionPtr;

		// Token: 0x0400EAC8 RID: 60104
		private static IntPtr __Finished_NativeFunctionPtr;

		// Token: 0x0400EAC9 RID: 60105
		private static IntPtr __ReceiveDestroyed_NativeFunctionPtr;

		// Token: 0x0400EACA RID: 60106
		private static IntPtr __ReceiveEndPlay_NativeFunctionPtr;

		// Token: 0x0400EACB RID: 60107
		private static IntPtr __ExecuteUbergraph_BP_GachaInteract_NativeFunctionPtr;

		// Token: 0x02009736 RID: 38710
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 8)]
		protected ref struct __IntroStart_FunctionParams
		{
			// Token: 0x04031CA4 RID: 203940
			[FieldOffset(0)]
			public int Frame;

			// Token: 0x04031CA5 RID: 203941
			[FieldOffset(4)]
			public float Subtime;
		}

		// Token: 0x02009737 RID: 38711
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 1)]
		protected ref struct __IsNewWorkFlow_FunctionParams
		{
			// Token: 0x04031CA6 RID: 203942
			[FieldOffset(0)]
			public bool IsNew;
		}

		// Token: 0x02009738 RID: 38712
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 32)]
		protected ref struct __SelectLevelSeq_FunctionParams
		{
			// Token: 0x04031CA7 RID: 203943
			[FieldOffset(0)]
			public int Num;
		}

		// Token: 0x02009739 RID: 38713
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 1)]
		protected ref struct __TSInitParameters_FunctionParams
		{
			// Token: 0x04031CA8 RID: 203944
			[FieldOffset(0)]
			public TEnumAsByte<E_GachaResultNew> GachaResult;
		}

		// Token: 0x0200973A RID: 38714
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 8)]
		protected ref struct __InteractStart_FunctionParams
		{
			// Token: 0x04031CA9 RID: 203945
			[FieldOffset(0)]
			public int Frame;

			// Token: 0x04031CAA RID: 203946
			[FieldOffset(4)]
			public float Subtime;
		}

		// Token: 0x0200973B RID: 38715
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 8)]
		protected ref struct __OutroStart_FunctionParams
		{
			// Token: 0x04031CAB RID: 203947
			[FieldOffset(0)]
			public int Frame;

			// Token: 0x04031CAC RID: 203948
			[FieldOffset(4)]
			public float Subtime;
		}

		// Token: 0x0200973C RID: 38716
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 8)]
		protected ref struct __ShowroomStart_FunctionParams
		{
			// Token: 0x04031CAD RID: 203949
			[FieldOffset(0)]
			public int Frame;

			// Token: 0x04031CAE RID: 203950
			[FieldOffset(4)]
			public float Subtime;
		}

		// Token: 0x0200973D RID: 38717
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 4)]
		protected new ref struct __ReceiveTick_FunctionParams
		{
			// Token: 0x04031CAF RID: 203951
			[FieldOffset(0)]
			public float DeltaSeconds;
		}

		// Token: 0x0200973E RID: 38718
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 1)]
		protected new ref struct __ReceiveEndPlay_FunctionParams
		{
			// Token: 0x04031CB0 RID: 203952
			[FieldOffset(0)]
			public TEnumAsByte<EEndPlayReason> EndPlayReason;
		}

		// Token: 0x0200973F RID: 38719
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 328)]
		protected ref struct __ExecuteUbergraph_BP_GachaInteract_FunctionParams
		{
			// Token: 0x04031CB1 RID: 203953
			[FieldOffset(0)]
			public int EntryPoint;
		}
	}
}
