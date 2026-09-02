using System;
using System.Runtime.CompilerServices;
using AkiClient.Game.Aki.Data.Common.Struct;
using AkiClient.Game.Aki.Data.Entity.Enum;
using AkiClient.Game.Aki.Render.RuntimeBP.Effect.Enum;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Data.Entity.Struct
{
	// Token: 0x02003EF6 RID: 16118
	[NullableContext(1)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Data/Entity/Struct/SModelConfig.SModelConfig")]
	[UnrealStructLayout(1144, 8, UnrealReflectionPropertyTypeCode.UnrealScriptStructProxy, PropertiesSize = 1140)]
	public class SModelConfig : UnrealUserDefinedStructProxy, IUnrealScriptStructProxy, IUnrealScriptStruct, IUnrealObject
	{
		// Token: 0x06028276 RID: 164470 RVA: 0x00A03C4C File Offset: 0x00A01E4C
		public static UScriptStructStackOnlyPtr StaticStruct()
		{
			return (SModelConfig._ScriptStructPtr != 0) ? SModelConfig._ScriptStructPtr : UObjectGlobals.StaticLoadScriptStruct("/Game/Aki/Data/Entity/Struct/SModelConfig.SModelConfig", ref SModelConfig._ScriptStructPtr);
		}

		// Token: 0x170060CD RID: 24781
		// (get) Token: 0x06028277 RID: 164471 RVA: 0x00A03C70 File Offset: 0x00A01E70
		// (set) Token: 0x06028278 RID: 164472 RVA: 0x00A03C80 File Offset: 0x00A01E80
		public unsafe int ID
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SModelConfig.__PropertyOffset_0);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SModelConfig.__PropertyOffset_0) = value;
			}
		}

		// Token: 0x170060CE RID: 24782
		// (get) Token: 0x06028279 RID: 164473 RVA: 0x00A03C91 File Offset: 0x00A01E91
		// (set) Token: 0x0602827A RID: 164474 RVA: 0x00A03CB0 File Offset: 0x00A01EB0
		public TSoftClassPtr<AActor> 蓝图
		{
			get
			{
				return new TSoftClassPtr<AActor>(base.NativePtr + (IntPtr)SModelConfig.__PropertyOffset_1, base.MemoryOwner ?? this);
			}
			set
			{
				FSoftObjectPtr.NativeCopy(base.NativePtr + (IntPtr)SModelConfig.__PropertyOffset_1, (value != null) ? value.NativePtr : IntPtr.Zero, 1);
			}
		}

		// Token: 0x170060CF RID: 24783
		// (get) Token: 0x0602827B RID: 164475 RVA: 0x00A03CD5 File Offset: 0x00A01ED5
		// (set) Token: 0x0602827C RID: 164476 RVA: 0x00A03CF4 File Offset: 0x00A01EF4
		public TSoftObjectPtr<USkeletalMesh> 网格体
		{
			get
			{
				return new TSoftObjectPtr<USkeletalMesh>(base.NativePtr + (IntPtr)SModelConfig.__PropertyOffset_2, base.MemoryOwner ?? this);
			}
			set
			{
				FSoftObjectPtr.NativeCopy(base.NativePtr + (IntPtr)SModelConfig.__PropertyOffset_2, (value != null) ? value.NativePtr : IntPtr.Zero, 1);
			}
		}

		// Token: 0x170060D0 RID: 24784
		// (get) Token: 0x0602827D RID: 164477 RVA: 0x00A03D1C File Offset: 0x00A01F1C
		// (set) Token: 0x0602827E RID: 164478 RVA: 0x00A03D5F File Offset: 0x00A01F5F
		public TArray<TSoftObjectPtr<USkeletalMesh>> 子网格体
		{
			get
			{
				base.FastCheckIsValid();
				TArray<TSoftObjectPtr<USkeletalMesh>> result;
				if ((result = this._子网格体) == null)
				{
					result = (this._子网格体 = new TArray<TSoftObjectPtr<USkeletalMesh>>(base.NativePtr + (IntPtr)SModelConfig.__PropertyOffset_3, base.MemoryOwner ?? this));
				}
				return result;
			}
			set
			{
				this.子网格体.CopyAssign(value);
			}
		}

		// Token: 0x170060D1 RID: 24785
		// (get) Token: 0x0602827F RID: 164479 RVA: 0x00A03D70 File Offset: 0x00A01F70
		// (set) Token: 0x06028280 RID: 164480 RVA: 0x00A03DB3 File Offset: 0x00A01FB3
		public FSoftObjectPath DA
		{
			get
			{
				base.FastCheckIsValid();
				FSoftObjectPath result;
				if ((result = this._DA) == null)
				{
					result = (this._DA = new FSoftObjectPath(base.NativePtr + (IntPtr)SModelConfig.__PropertyOffset_4, base.MemoryOwner ?? this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FSoftObjectPath.StaticStruct(), base.NativePtr + (IntPtr)SModelConfig.__PropertyOffset_4, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170060D2 RID: 24786
		// (get) Token: 0x06028281 RID: 164481 RVA: 0x00A03DD4 File Offset: 0x00A01FD4
		// (set) Token: 0x06028282 RID: 164482 RVA: 0x00A03DF3 File Offset: 0x00A01FF3
		public TSoftClassPtr<UAnimInstance> 动画蓝图
		{
			get
			{
				return new TSoftClassPtr<UAnimInstance>(base.NativePtr + (IntPtr)SModelConfig.__PropertyOffset_5, base.MemoryOwner ?? this);
			}
			set
			{
				FSoftObjectPtr.NativeCopy(base.NativePtr + (IntPtr)SModelConfig.__PropertyOffset_5, (value != null) ? value.NativePtr : IntPtr.Zero, 1);
			}
		}

		// Token: 0x170060D3 RID: 24787
		// (get) Token: 0x06028283 RID: 164483 RVA: 0x00A03E18 File Offset: 0x00A02018
		// (set) Token: 0x06028284 RID: 164484 RVA: 0x00A03E2C File Offset: 0x00A0202C
		public unsafe string 描述
		{
			get
			{
				return FString.ToString((void*)(base.NativePtr + (byte*)((IntPtr)SModelConfig.__PropertyOffset_6)));
			}
			set
			{
				FString.CopyFrom((void*)(base.NativePtr + (byte*)((IntPtr)SModelConfig.__PropertyOffset_6)), value);
			}
		}

		// Token: 0x170060D4 RID: 24788
		// (get) Token: 0x06028285 RID: 164485 RVA: 0x00A03E44 File Offset: 0x00A02044
		// (set) Token: 0x06028286 RID: 164486 RVA: 0x00A03E87 File Offset: 0x00A02087
		public TMap<FGameplayTag, FSoftObjectPath> 动画列表
		{
			get
			{
				base.FastCheckIsValid();
				TMap<FGameplayTag, FSoftObjectPath> result;
				if ((result = this._动画列表) == null)
				{
					result = (this._动画列表 = new TMap<FGameplayTag, FSoftObjectPath>(base.NativePtr + (IntPtr)SModelConfig.__PropertyOffset_7, base.MemoryOwner ?? this));
				}
				return result;
			}
			set
			{
				this.动画列表.CopyAssign(value);
			}
		}

		// Token: 0x170060D5 RID: 24789
		// (get) Token: 0x06028287 RID: 164487 RVA: 0x00A03E98 File Offset: 0x00A02098
		// (set) Token: 0x06028288 RID: 164488 RVA: 0x00A03EDB File Offset: 0x00A020DB
		public TArray<string> BattleSockets
		{
			get
			{
				base.FastCheckIsValid();
				TArray<string> result;
				if ((result = this._BattleSockets) == null)
				{
					result = (this._BattleSockets = new TArray<string>(base.NativePtr + (IntPtr)SModelConfig.__PropertyOffset_8, base.MemoryOwner ?? this));
				}
				return result;
			}
			set
			{
				this.BattleSockets.CopyAssign(value);
			}
		}

		// Token: 0x170060D6 RID: 24790
		// (get) Token: 0x06028289 RID: 164489 RVA: 0x00A03EEC File Offset: 0x00A020EC
		// (set) Token: 0x0602828A RID: 164490 RVA: 0x00A03F2F File Offset: 0x00A0212F
		public TArray<string> NormalSockets
		{
			get
			{
				base.FastCheckIsValid();
				TArray<string> result;
				if ((result = this._NormalSockets) == null)
				{
					result = (this._NormalSockets = new TArray<string>(base.NativePtr + (IntPtr)SModelConfig.__PropertyOffset_9, base.MemoryOwner ?? this));
				}
				return result;
			}
			set
			{
				this.NormalSockets.CopyAssign(value);
			}
		}

		// Token: 0x170060D7 RID: 24791
		// (get) Token: 0x0602828B RID: 164491 RVA: 0x00A03F40 File Offset: 0x00A02140
		// (set) Token: 0x0602828C RID: 164492 RVA: 0x00A03F83 File Offset: 0x00A02183
		public TMap<FGameplayTag, FSoftObjectPath> 静态网格体列表
		{
			get
			{
				base.FastCheckIsValid();
				TMap<FGameplayTag, FSoftObjectPath> result;
				if ((result = this._静态网格体列表) == null)
				{
					result = (this._静态网格体列表 = new TMap<FGameplayTag, FSoftObjectPath>(base.NativePtr + (IntPtr)SModelConfig.__PropertyOffset_10, base.MemoryOwner ?? this));
				}
				return result;
			}
			set
			{
				this.静态网格体列表.CopyAssign(value);
			}
		}

		// Token: 0x170060D8 RID: 24792
		// (get) Token: 0x0602828D RID: 164493 RVA: 0x00A03F94 File Offset: 0x00A02194
		// (set) Token: 0x0602828E RID: 164494 RVA: 0x00A03FD7 File Offset: 0x00A021D7
		public TMap<FGameplayTag, FSoftObjectPath> 常驻特效列表
		{
			get
			{
				base.FastCheckIsValid();
				TMap<FGameplayTag, FSoftObjectPath> result;
				if ((result = this._常驻特效列表) == null)
				{
					result = (this._常驻特效列表 = new TMap<FGameplayTag, FSoftObjectPath>(base.NativePtr + (IntPtr)SModelConfig.__PropertyOffset_11, base.MemoryOwner ?? this));
				}
				return result;
			}
			set
			{
				this.常驻特效列表.CopyAssign(value);
			}
		}

		// Token: 0x170060D9 RID: 24793
		// (get) Token: 0x0602828F RID: 164495 RVA: 0x00A03FE8 File Offset: 0x00A021E8
		// (set) Token: 0x06028290 RID: 164496 RVA: 0x00A0402B File Offset: 0x00A0222B
		public TMap<FGameplayTag, FSoftObjectPath> 变化特效列表
		{
			get
			{
				base.FastCheckIsValid();
				TMap<FGameplayTag, FSoftObjectPath> result;
				if ((result = this._变化特效列表) == null)
				{
					result = (this._变化特效列表 = new TMap<FGameplayTag, FSoftObjectPath>(base.NativePtr + (IntPtr)SModelConfig.__PropertyOffset_12, base.MemoryOwner ?? this));
				}
				return result;
			}
			set
			{
				this.变化特效列表.CopyAssign(value);
			}
		}

		// Token: 0x170060DA RID: 24794
		// (get) Token: 0x06028291 RID: 164497 RVA: 0x00A0403C File Offset: 0x00A0223C
		// (set) Token: 0x06028292 RID: 164498 RVA: 0x00A0407F File Offset: 0x00A0227F
		public TMap<FGameplayTag, SNiagaraParam> 通用特效常驻参数
		{
			get
			{
				base.FastCheckIsValid();
				TMap<FGameplayTag, SNiagaraParam> result;
				if ((result = this._通用特效常驻参数) == null)
				{
					result = (this._通用特效常驻参数 = new TMap<FGameplayTag, SNiagaraParam>(base.NativePtr + (IntPtr)SModelConfig.__PropertyOffset_13, base.MemoryOwner ?? this));
				}
				return result;
			}
			set
			{
				this.通用特效常驻参数.CopyAssign(value);
			}
		}

		// Token: 0x170060DB RID: 24795
		// (get) Token: 0x06028293 RID: 164499 RVA: 0x00A04090 File Offset: 0x00A02290
		// (set) Token: 0x06028294 RID: 164500 RVA: 0x00A040D3 File Offset: 0x00A022D3
		public TMap<FGameplayTag, SNiagaraParam> 通用特效变化参数
		{
			get
			{
				base.FastCheckIsValid();
				TMap<FGameplayTag, SNiagaraParam> result;
				if ((result = this._通用特效变化参数) == null)
				{
					result = (this._通用特效变化参数 = new TMap<FGameplayTag, SNiagaraParam>(base.NativePtr + (IntPtr)SModelConfig.__PropertyOffset_14, base.MemoryOwner ?? this));
				}
				return result;
			}
			set
			{
				this.通用特效变化参数.CopyAssign(value);
			}
		}

		// Token: 0x170060DC RID: 24796
		// (get) Token: 0x06028295 RID: 164501 RVA: 0x00A040E4 File Offset: 0x00A022E4
		// (set) Token: 0x06028296 RID: 164502 RVA: 0x00A04127 File Offset: 0x00A02327
		public FSoftObjectPath 场景交互物
		{
			get
			{
				base.FastCheckIsValid();
				FSoftObjectPath result;
				if ((result = this._场景交互物) == null)
				{
					result = (this._场景交互物 = new FSoftObjectPath(base.NativePtr + (IntPtr)SModelConfig.__PropertyOffset_15, base.MemoryOwner ?? this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FSoftObjectPath.StaticStruct(), base.NativePtr + (IntPtr)SModelConfig.__PropertyOffset_15, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170060DD RID: 24797
		// (get) Token: 0x06028297 RID: 164503 RVA: 0x00A04148 File Offset: 0x00A02348
		// (set) Token: 0x06028298 RID: 164504 RVA: 0x00A0418B File Offset: 0x00A0238B
		public TMap<FGameplayTag, EKuroSceneInteractionState> 场景交互物状态列表
		{
			get
			{
				base.FastCheckIsValid();
				TMap<FGameplayTag, EKuroSceneInteractionState> result;
				if ((result = this._场景交互物状态列表) == null)
				{
					result = (this._场景交互物状态列表 = new TMap<FGameplayTag, EKuroSceneInteractionState>(base.NativePtr + (IntPtr)SModelConfig.__PropertyOffset_16, base.MemoryOwner ?? this));
				}
				return result;
			}
			set
			{
				this.场景交互物状态列表.CopyAssign(value);
			}
		}

		// Token: 0x170060DE RID: 24798
		// (get) Token: 0x06028299 RID: 164505 RVA: 0x00A0419C File Offset: 0x00A0239C
		// (set) Token: 0x0602829A RID: 164506 RVA: 0x00A041DF File Offset: 0x00A023DF
		[Nullable(new byte[]
		{
			1,
			0
		})]
		public TMap<FGameplayTag, TEnumAsByte<ESceneInteractionEffect>> 场景交互物特效列表
		{
			[return: Nullable(new byte[]
			{
				1,
				0
			})]
			get
			{
				base.FastCheckIsValid();
				TMap<FGameplayTag, TEnumAsByte<ESceneInteractionEffect>> result;
				if ((result = this._场景交互物特效列表) == null)
				{
					result = (this._场景交互物特效列表 = new TMap<FGameplayTag, TEnumAsByte<ESceneInteractionEffect>>(base.NativePtr + (IntPtr)SModelConfig.__PropertyOffset_17, base.MemoryOwner ?? this));
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
				this.场景交互物特效列表.CopyAssign(value);
			}
		}

		// Token: 0x170060DF RID: 24799
		// (get) Token: 0x0602829B RID: 164507 RVA: 0x00A041ED File Offset: 0x00A023ED
		// (set) Token: 0x0602829C RID: 164508 RVA: 0x00A041FD File Offset: 0x00A023FD
		public unsafe bool IsHiddenWithCamera
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SModelConfig.__PropertyOffset_18) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)SModelConfig.__PropertyOffset_18) = (value ? 1 : 0);
			}
		}

		// Token: 0x170060E0 RID: 24800
		// (get) Token: 0x0602829D RID: 164509 RVA: 0x00A0420E File Offset: 0x00A0240E
		// (set) Token: 0x0602829E RID: 164510 RVA: 0x00A0421E File Offset: 0x00A0241E
		public unsafe float ModelAlpha
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SModelConfig.__PropertyOffset_19);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SModelConfig.__PropertyOffset_19) = value;
			}
		}

		// Token: 0x170060E1 RID: 24801
		// (get) Token: 0x0602829F RID: 164511 RVA: 0x00A0422F File Offset: 0x00A0242F
		// (set) Token: 0x060282A0 RID: 164512 RVA: 0x00A0423F File Offset: 0x00A0243F
		public unsafe int 名字Z偏移
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SModelConfig.__PropertyOffset_20);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SModelConfig.__PropertyOffset_20) = value;
			}
		}

		// Token: 0x170060E2 RID: 24802
		// (get) Token: 0x060282A1 RID: 164513 RVA: 0x00A04250 File Offset: 0x00A02450
		// (set) Token: 0x060282A2 RID: 164514 RVA: 0x00A04260 File Offset: 0x00A02460
		public unsafe float 注释时的抬升角度
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SModelConfig.__PropertyOffset_21);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SModelConfig.__PropertyOffset_21) = value;
			}
		}

		// Token: 0x170060E3 RID: 24803
		// (get) Token: 0x060282A3 RID: 164515 RVA: 0x00A04271 File Offset: 0x00A02471
		// (set) Token: 0x060282A4 RID: 164516 RVA: 0x00A04285 File Offset: 0x00A02485
		[Nullable(0)]
		public unsafe TEnumAsByte<EBodyType> 体型类型
		{
			[NullableContext(0)]
			get
			{
				return *(base.NativePtr + (IntPtr)SModelConfig.__PropertyOffset_22);
			}
			[NullableContext(0)]
			set
			{
				*(base.NativePtr + (IntPtr)SModelConfig.__PropertyOffset_22) = value;
			}
		}

		// Token: 0x170060E4 RID: 24804
		// (get) Token: 0x060282A5 RID: 164517 RVA: 0x00A0429A File Offset: 0x00A0249A
		// (set) Token: 0x060282A6 RID: 164518 RVA: 0x00A042AA File Offset: 0x00A024AA
		public unsafe bool 主角蓝透
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SModelConfig.__PropertyOffset_23) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)SModelConfig.__PropertyOffset_23) = (value ? 1 : 0);
			}
		}

		// Token: 0x170060E5 RID: 24805
		// (get) Token: 0x060282A7 RID: 164519 RVA: 0x00A042BB File Offset: 0x00A024BB
		// (set) Token: 0x060282A8 RID: 164520 RVA: 0x00A042DA File Offset: 0x00A024DA
		public TSoftObjectPtr<UDataTable> 特效替换表
		{
			get
			{
				return new TSoftObjectPtr<UDataTable>(base.NativePtr + (IntPtr)SModelConfig.__PropertyOffset_24, base.MemoryOwner ?? this);
			}
			set
			{
				FSoftObjectPtr.NativeCopy(base.NativePtr + (IntPtr)SModelConfig.__PropertyOffset_24, (value != null) ? value.NativePtr : IntPtr.Zero, 1);
			}
		}

		// Token: 0x170060E6 RID: 24806
		// (get) Token: 0x060282A9 RID: 164521 RVA: 0x00A042FF File Offset: 0x00A024FF
		// (set) Token: 0x060282AA RID: 164522 RVA: 0x00A0431E File Offset: 0x00A0251E
		public TSoftObjectPtr<UDataTable> 蒙太奇替换表
		{
			get
			{
				return new TSoftObjectPtr<UDataTable>(base.NativePtr + (IntPtr)SModelConfig.__PropertyOffset_25, base.MemoryOwner ?? this);
			}
			set
			{
				FSoftObjectPtr.NativeCopy(base.NativePtr + (IntPtr)SModelConfig.__PropertyOffset_25, (value != null) ? value.NativePtr : IntPtr.Zero, 1);
			}
		}

		// Token: 0x170060E7 RID: 24807
		// (get) Token: 0x060282AB RID: 164523 RVA: 0x00A04343 File Offset: 0x00A02543
		// (set) Token: 0x060282AC RID: 164524 RVA: 0x00A04362 File Offset: 0x00A02562
		public TSoftObjectPtr<USkeletalMesh> 声骸掉落替换模型
		{
			get
			{
				return new TSoftObjectPtr<USkeletalMesh>(base.NativePtr + (IntPtr)SModelConfig.__PropertyOffset_26, base.MemoryOwner ?? this);
			}
			set
			{
				FSoftObjectPtr.NativeCopy(base.NativePtr + (IntPtr)SModelConfig.__PropertyOffset_26, (value != null) ? value.NativePtr : IntPtr.Zero, 1);
			}
		}

		// Token: 0x170060E8 RID: 24808
		// (get) Token: 0x060282AD RID: 164525 RVA: 0x00A04387 File Offset: 0x00A02587
		// (set) Token: 0x060282AE RID: 164526 RVA: 0x00A04397 File Offset: 0x00A02597
		public unsafe bool 隐藏葫芦
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SModelConfig.__PropertyOffset_27) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)SModelConfig.__PropertyOffset_27) = (value ? 1 : 0);
			}
		}

		// Token: 0x170060E9 RID: 24809
		// (get) Token: 0x060282AF RID: 164527 RVA: 0x00A043A8 File Offset: 0x00A025A8
		// (set) Token: 0x060282B0 RID: 164528 RVA: 0x00A043EB File Offset: 0x00A025EB
		public TArray<SModelDecorationConfig> UiModelDecorationArray
		{
			get
			{
				base.FastCheckIsValid();
				TArray<SModelDecorationConfig> result;
				if ((result = this._UiModelDecorationArray) == null)
				{
					result = (this._UiModelDecorationArray = new TArray<SModelDecorationConfig>(base.NativePtr + (IntPtr)SModelConfig.__PropertyOffset_28, base.MemoryOwner ?? this));
				}
				return result;
			}
			set
			{
				this.UiModelDecorationArray.CopyAssign(value);
			}
		}

		// Token: 0x170060EA RID: 24810
		// (get) Token: 0x060282B1 RID: 164529 RVA: 0x00A043F9 File Offset: 0x00A025F9
		// (set) Token: 0x060282B2 RID: 164530 RVA: 0x00A0440D File Offset: 0x00A0260D
		public unsafe FVectorDouble 骑摩托位置偏移
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SModelConfig.__PropertyOffset_29);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SModelConfig.__PropertyOffset_29) = value;
			}
		}

		// Token: 0x170060EB RID: 24811
		// (get) Token: 0x060282B3 RID: 164531 RVA: 0x00A04422 File Offset: 0x00A02622
		// (set) Token: 0x060282B4 RID: 164532 RVA: 0x00A04432 File Offset: 0x00A02632
		public unsafe int ToonCustomStencilValue
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SModelConfig.__PropertyOffset_30);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SModelConfig.__PropertyOffset_30) = value;
			}
		}

		// Token: 0x060282B5 RID: 164533 RVA: 0x00A04443 File Offset: 0x00A02643
		public SModelConfig()
		{
		}

		// Token: 0x060282B6 RID: 164534 RVA: 0x00A0444C File Offset: 0x00A0264C
		public SModelConfig(int ID, TSoftClassPtr<AActor> 蓝图, TSoftObjectPtr<USkeletalMesh> 网格体, TArray<TSoftObjectPtr<USkeletalMesh>> 子网格体, FSoftObjectPath DA, TSoftClassPtr<UAnimInstance> 动画蓝图, string 描述, TMap<FGameplayTag, FSoftObjectPath> 动画列表, TArray<string> BattleSockets, TArray<string> NormalSockets, TMap<FGameplayTag, FSoftObjectPath> 静态网格体列表, TMap<FGameplayTag, FSoftObjectPath> 常驻特效列表, TMap<FGameplayTag, FSoftObjectPath> 变化特效列表, TMap<FGameplayTag, SNiagaraParam> 通用特效常驻参数, TMap<FGameplayTag, SNiagaraParam> 通用特效变化参数, FSoftObjectPath 场景交互物, TMap<FGameplayTag, EKuroSceneInteractionState> 场景交互物状态列表, [Nullable(new byte[]
		{
			1,
			0
		})] TMap<FGameplayTag, TEnumAsByte<ESceneInteractionEffect>> 场景交互物特效列表, bool IsHiddenWithCamera, float ModelAlpha, int 名字Z偏移, float 注释时的抬升角度, [Nullable(0)] TEnumAsByte<EBodyType> 体型类型, bool 主角蓝透, TSoftObjectPtr<UDataTable> 特效替换表, TSoftObjectPtr<UDataTable> 蒙太奇替换表, TSoftObjectPtr<USkeletalMesh> 声骸掉落替换模型, bool 隐藏葫芦, TArray<SModelDecorationConfig> UiModelDecorationArray, FVectorDouble 骑摩托位置偏移, int ToonCustomStencilValue)
		{
			this.ID = ID;
			this.蓝图 = 蓝图;
			this.网格体 = 网格体;
			this.子网格体 = 子网格体;
			this.DA = DA;
			this.动画蓝图 = 动画蓝图;
			this.描述 = 描述;
			this.动画列表 = 动画列表;
			this.BattleSockets = BattleSockets;
			this.NormalSockets = NormalSockets;
			this.静态网格体列表 = 静态网格体列表;
			this.常驻特效列表 = 常驻特效列表;
			this.变化特效列表 = 变化特效列表;
			this.通用特效常驻参数 = 通用特效常驻参数;
			this.通用特效变化参数 = 通用特效变化参数;
			this.场景交互物 = 场景交互物;
			this.场景交互物状态列表 = 场景交互物状态列表;
			this.场景交互物特效列表 = 场景交互物特效列表;
			this.IsHiddenWithCamera = IsHiddenWithCamera;
			this.ModelAlpha = ModelAlpha;
			this.名字Z偏移 = 名字Z偏移;
			this.注释时的抬升角度 = 注释时的抬升角度;
			this.体型类型 = 体型类型;
			this.主角蓝透 = 主角蓝透;
			this.特效替换表 = 特效替换表;
			this.蒙太奇替换表 = 蒙太奇替换表;
			this.声骸掉落替换模型 = 声骸掉落替换模型;
			this.隐藏葫芦 = 隐藏葫芦;
			this.UiModelDecorationArray = UiModelDecorationArray;
			this.骑摩托位置偏移 = 骑摩托位置偏移;
			this.ToonCustomStencilValue = ToonCustomStencilValue;
		}

		// Token: 0x060282B7 RID: 164535 RVA: 0x00A04554 File Offset: 0x00A02754
		protected override IntPtr GetUStructPtr()
		{
			return SModelConfig.StaticStruct();
		}

		// Token: 0x060282B8 RID: 164536 RVA: 0x00A04560 File Offset: 0x00A02760
		[NullableContext(2)]
		public SModelConfig(IntPtr NativePtr, UnrealObject MemoryOwner) : base(NativePtr, MemoryOwner)
		{
		}

		// Token: 0x060282B9 RID: 164537 RVA: 0x00A0456A File Offset: 0x00A0276A
		public SModelConfig(IntPtr NativePtr, bool bWithMoveAssign, bool bWithCopyAssignIfCannotMove) : base(NativePtr, bWithMoveAssign, bWithCopyAssignIfCannotMove)
		{
		}

		// Token: 0x060282BA RID: 164538 RVA: 0x00A04575 File Offset: 0x00A02775
		public static IUnrealScriptStructProxy CreateFromPointer(IntPtr Pointer)
		{
			return new SModelConfig(Pointer, false, true);
		}

		// Token: 0x060282BB RID: 164539 RVA: 0x00A0457F File Offset: 0x00A0277F
		public static IUnrealScriptStructProxy CreateReferenceFromPointer(IntPtr Pointer, UnrealObject MemoryOwner)
		{
			return new SModelConfig(Pointer, MemoryOwner);
		}

		// Token: 0x0401516D RID: 86381
		public const string __ObjectPath = "/Game/Aki/Data/Entity/Struct/SModelConfig.SModelConfig";

		// Token: 0x0401516E RID: 86382
		private static IntPtr _ScriptStructPtr;

		// Token: 0x0401516F RID: 86383
		internal static int __PropertyOffset_0;

		// Token: 0x04015170 RID: 86384
		internal static int __PropertyOffset_1;

		// Token: 0x04015171 RID: 86385
		internal static int __PropertyOffset_2;

		// Token: 0x04015172 RID: 86386
		internal static int __PropertyOffset_3;

		// Token: 0x04015173 RID: 86387
		[Nullable(new byte[]
		{
			2,
			1,
			1
		})]
		private TArray<TSoftObjectPtr<USkeletalMesh>> _子网格体;

		// Token: 0x04015174 RID: 86388
		internal static int __PropertyOffset_4;

		// Token: 0x04015175 RID: 86389
		[Nullable(2)]
		private FSoftObjectPath _DA;

		// Token: 0x04015176 RID: 86390
		internal static int __PropertyOffset_5;

		// Token: 0x04015177 RID: 86391
		internal static int __PropertyOffset_6;

		// Token: 0x04015178 RID: 86392
		internal static int __PropertyOffset_7;

		// Token: 0x04015179 RID: 86393
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private TMap<FGameplayTag, FSoftObjectPath> _动画列表;

		// Token: 0x0401517A RID: 86394
		internal static int __PropertyOffset_8;

		// Token: 0x0401517B RID: 86395
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private TArray<string> _BattleSockets;

		// Token: 0x0401517C RID: 86396
		internal static int __PropertyOffset_9;

		// Token: 0x0401517D RID: 86397
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private TArray<string> _NormalSockets;

		// Token: 0x0401517E RID: 86398
		internal static int __PropertyOffset_10;

		// Token: 0x0401517F RID: 86399
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private TMap<FGameplayTag, FSoftObjectPath> _静态网格体列表;

		// Token: 0x04015180 RID: 86400
		internal static int __PropertyOffset_11;

		// Token: 0x04015181 RID: 86401
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private TMap<FGameplayTag, FSoftObjectPath> _常驻特效列表;

		// Token: 0x04015182 RID: 86402
		internal static int __PropertyOffset_12;

		// Token: 0x04015183 RID: 86403
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private TMap<FGameplayTag, FSoftObjectPath> _变化特效列表;

		// Token: 0x04015184 RID: 86404
		internal static int __PropertyOffset_13;

		// Token: 0x04015185 RID: 86405
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private TMap<FGameplayTag, SNiagaraParam> _通用特效常驻参数;

		// Token: 0x04015186 RID: 86406
		internal static int __PropertyOffset_14;

		// Token: 0x04015187 RID: 86407
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private TMap<FGameplayTag, SNiagaraParam> _通用特效变化参数;

		// Token: 0x04015188 RID: 86408
		internal static int __PropertyOffset_15;

		// Token: 0x04015189 RID: 86409
		[Nullable(2)]
		private FSoftObjectPath _场景交互物;

		// Token: 0x0401518A RID: 86410
		internal static int __PropertyOffset_16;

		// Token: 0x0401518B RID: 86411
		[Nullable(2)]
		private TMap<FGameplayTag, EKuroSceneInteractionState> _场景交互物状态列表;

		// Token: 0x0401518C RID: 86412
		internal static int __PropertyOffset_17;

		// Token: 0x0401518D RID: 86413
		[Nullable(new byte[]
		{
			2,
			0
		})]
		private TMap<FGameplayTag, TEnumAsByte<ESceneInteractionEffect>> _场景交互物特效列表;

		// Token: 0x0401518E RID: 86414
		internal static int __PropertyOffset_18;

		// Token: 0x0401518F RID: 86415
		internal static int __PropertyOffset_19;

		// Token: 0x04015190 RID: 86416
		internal static int __PropertyOffset_20;

		// Token: 0x04015191 RID: 86417
		internal static int __PropertyOffset_21;

		// Token: 0x04015192 RID: 86418
		internal static int __PropertyOffset_22;

		// Token: 0x04015193 RID: 86419
		internal static int __PropertyOffset_23;

		// Token: 0x04015194 RID: 86420
		internal static int __PropertyOffset_24;

		// Token: 0x04015195 RID: 86421
		internal static int __PropertyOffset_25;

		// Token: 0x04015196 RID: 86422
		internal static int __PropertyOffset_26;

		// Token: 0x04015197 RID: 86423
		internal static int __PropertyOffset_27;

		// Token: 0x04015198 RID: 86424
		internal static int __PropertyOffset_28;

		// Token: 0x04015199 RID: 86425
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private TArray<SModelDecorationConfig> _UiModelDecorationArray;

		// Token: 0x0401519A RID: 86426
		internal static int __PropertyOffset_29;

		// Token: 0x0401519B RID: 86427
		internal static int __PropertyOffset_30;
	}
}
