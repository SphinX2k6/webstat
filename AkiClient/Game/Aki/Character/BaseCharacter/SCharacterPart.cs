using System;
using System.Runtime.CompilerServices;
using AkiClient.Game.Aki.Render.RuntimeBP.Character.MaterialController;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Character.BaseCharacter
{
	// Token: 0x0200424C RID: 16972
	[NullableContext(1)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Character/BaseCharacter/SCharacterPart.SCharacterPart")]
	[UnrealStructLayout(368, 8, UnrealReflectionPropertyTypeCode.UnrealScriptStructProxy, PropertiesSize = 364)]
	public class SCharacterPart : UnrealUserDefinedStructProxy, IUnrealScriptStructProxy, IUnrealScriptStruct, IUnrealObject
	{
		// Token: 0x0602CEFF RID: 184063 RVA: 0x00AB3986 File Offset: 0x00AB1B86
		public static UScriptStructStackOnlyPtr StaticStruct()
		{
			return (SCharacterPart._ScriptStructPtr != 0) ? SCharacterPart._ScriptStructPtr : UObjectGlobals.StaticLoadScriptStruct("/Game/Aki/Character/BaseCharacter/SCharacterPart.SCharacterPart", ref SCharacterPart._ScriptStructPtr);
		}

		// Token: 0x170079C4 RID: 31172
		// (get) Token: 0x0602CF00 RID: 184064 RVA: 0x00AB39AA File Offset: 0x00AB1BAA
		// (set) Token: 0x0602CF01 RID: 184065 RVA: 0x00AB39BE File Offset: 0x00AB1BBE
		public unsafe string 部位名
		{
			get
			{
				return FString.ToString((void*)(base.NativePtr + (byte*)((IntPtr)SCharacterPart.__PropertyOffset_0)));
			}
			set
			{
				FString.CopyFrom((void*)(base.NativePtr + (byte*)((IntPtr)SCharacterPart.__PropertyOffset_0)), value);
			}
		}

		// Token: 0x170079C5 RID: 31173
		// (get) Token: 0x0602CF02 RID: 184066 RVA: 0x00AB39D4 File Offset: 0x00AB1BD4
		// (set) Token: 0x0602CF03 RID: 184067 RVA: 0x00AB3A17 File Offset: 0x00AB1C17
		public TArray<string> 骨骼名
		{
			get
			{
				base.FastCheckIsValid();
				TArray<string> result;
				if ((result = this._骨骼名) == null)
				{
					result = (this._骨骼名 = new TArray<string>(base.NativePtr + (IntPtr)SCharacterPart.__PropertyOffset_1, base.MemoryOwner ?? this));
				}
				return result;
			}
			set
			{
				this.骨骼名.CopyAssign(value);
			}
		}

		// Token: 0x170079C6 RID: 31174
		// (get) Token: 0x0602CF04 RID: 184068 RVA: 0x00AB3A25 File Offset: 0x00AB1C25
		// (set) Token: 0x0602CF05 RID: 184069 RVA: 0x00AB3A35 File Offset: 0x00AB1C35
		public unsafe bool 是否独立承伤
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SCharacterPart.__PropertyOffset_2) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)SCharacterPart.__PropertyOffset_2) = (value ? 1 : 0);
			}
		}

		// Token: 0x170079C7 RID: 31175
		// (get) Token: 0x0602CF06 RID: 184070 RVA: 0x00AB3A46 File Offset: 0x00AB1C46
		// (set) Token: 0x0602CF07 RID: 184071 RVA: 0x00AB3A56 File Offset: 0x00AB1C56
		public unsafe bool 是否出生激活
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SCharacterPart.__PropertyOffset_3) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)SCharacterPart.__PropertyOffset_3) = (value ? 1 : 0);
			}
		}

		// Token: 0x170079C8 RID: 31176
		// (get) Token: 0x0602CF08 RID: 184072 RVA: 0x00AB3A67 File Offset: 0x00AB1C67
		// (set) Token: 0x0602CF09 RID: 184073 RVA: 0x00AB3A7B File Offset: 0x00AB1C7B
		public unsafe FGameplayTag 部位标签
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SCharacterPart.__PropertyOffset_4);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SCharacterPart.__PropertyOffset_4) = value;
			}
		}

		// Token: 0x170079C9 RID: 31177
		// (get) Token: 0x0602CF0A RID: 184074 RVA: 0x00AB3A90 File Offset: 0x00AB1C90
		// (set) Token: 0x0602CF0B RID: 184075 RVA: 0x00AB3AA4 File Offset: 0x00AB1CA4
		public unsafe FGameplayTag 部位激活标签
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SCharacterPart.__PropertyOffset_5);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SCharacterPart.__PropertyOffset_5) = value;
			}
		}

		// Token: 0x170079CA RID: 31178
		// (get) Token: 0x0602CF0C RID: 184076 RVA: 0x00AB3AB9 File Offset: 0x00AB1CB9
		// (set) Token: 0x0602CF0D RID: 184077 RVA: 0x00AB3AC9 File Offset: 0x00AB1CC9
		public unsafe float 继承生命值比例
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SCharacterPart.__PropertyOffset_6);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SCharacterPart.__PropertyOffset_6) = value;
			}
		}

		// Token: 0x170079CB RID: 31179
		// (get) Token: 0x0602CF0E RID: 184078 RVA: 0x00AB3ADA File Offset: 0x00AB1CDA
		// (set) Token: 0x0602CF0F RID: 184079 RVA: 0x00AB3AEA File Offset: 0x00AB1CEA
		public unsafe bool 是否弱点
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SCharacterPart.__PropertyOffset_7) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)SCharacterPart.__PropertyOffset_7) = (value ? 1 : 0);
			}
		}

		// Token: 0x170079CC RID: 31180
		// (get) Token: 0x0602CF10 RID: 184080 RVA: 0x00AB3AFC File Offset: 0x00AB1CFC
		// (set) Token: 0x0602CF11 RID: 184081 RVA: 0x00AB3B3F File Offset: 0x00AB1D3F
		[Nullable(new byte[]
		{
			1,
			0
		})]
		public TSet<TEnumAsByte<EBulletType>> 弱点攻击类型
		{
			[return: Nullable(new byte[]
			{
				1,
				0
			})]
			get
			{
				base.FastCheckIsValid();
				TSet<TEnumAsByte<EBulletType>> result;
				if ((result = this._弱点攻击类型) == null)
				{
					result = (this._弱点攻击类型 = new TSet<TEnumAsByte<EBulletType>>(base.NativePtr + (IntPtr)SCharacterPart.__PropertyOffset_8, base.MemoryOwner ?? this));
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
				this.弱点攻击类型.CopyAssign(value);
			}
		}

		// Token: 0x170079CD RID: 31181
		// (get) Token: 0x0602CF12 RID: 184082 RVA: 0x00AB3B4D File Offset: 0x00AB1D4D
		// (set) Token: 0x0602CF13 RID: 184083 RVA: 0x00AB3B5D File Offset: 0x00AB1D5D
		public unsafe float 弱点受击角度
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SCharacterPart.__PropertyOffset_9);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SCharacterPart.__PropertyOffset_9) = value;
			}
		}

		// Token: 0x170079CE RID: 31182
		// (get) Token: 0x0602CF14 RID: 184084 RVA: 0x00AB3B6E File Offset: 0x00AB1D6E
		// (set) Token: 0x0602CF15 RID: 184085 RVA: 0x00AB3B7E File Offset: 0x00AB1D7E
		public unsafe bool 精准弱点受击角度判定
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SCharacterPart.__PropertyOffset_10) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)SCharacterPart.__PropertyOffset_10) = (value ? 1 : 0);
			}
		}

		// Token: 0x170079CF RID: 31183
		// (get) Token: 0x0602CF16 RID: 184086 RVA: 0x00AB3B90 File Offset: 0x00AB1D90
		// (set) Token: 0x0602CF17 RID: 184087 RVA: 0x00AB3BD3 File Offset: 0x00AB1DD3
		public TMap<string, string> 碰撞框朝向
		{
			get
			{
				base.FastCheckIsValid();
				TMap<string, string> result;
				if ((result = this._碰撞框朝向) == null)
				{
					result = (this._碰撞框朝向 = new TMap<string, string>(base.NativePtr + (IntPtr)SCharacterPart.__PropertyOffset_11, base.MemoryOwner ?? this));
				}
				return result;
			}
			set
			{
				this.碰撞框朝向.CopyAssign(value);
			}
		}

		// Token: 0x170079D0 RID: 31184
		// (get) Token: 0x0602CF18 RID: 184088 RVA: 0x00AB3BE1 File Offset: 0x00AB1DE1
		// (set) Token: 0x0602CF19 RID: 184089 RVA: 0x00AB3BF1 File Offset: 0x00AB1DF1
		public unsafe bool 是否盾牌
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SCharacterPart.__PropertyOffset_12) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)SCharacterPart.__PropertyOffset_12) = (value ? 1 : 0);
			}
		}

		// Token: 0x170079D1 RID: 31185
		// (get) Token: 0x0602CF1A RID: 184090 RVA: 0x00AB3C02 File Offset: 0x00AB1E02
		// (set) Token: 0x0602CF1B RID: 184091 RVA: 0x00AB3C12 File Offset: 0x00AB1E12
		public unsafe float 格挡判定角度
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SCharacterPart.__PropertyOffset_13);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SCharacterPart.__PropertyOffset_13) = value;
			}
		}

		// Token: 0x170079D2 RID: 31186
		// (get) Token: 0x0602CF1C RID: 184092 RVA: 0x00AB3C23 File Offset: 0x00AB1E23
		// (set) Token: 0x0602CF1D RID: 184093 RVA: 0x00AB3C33 File Offset: 0x00AB1E33
		public unsafe bool 是否传递伤害
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SCharacterPart.__PropertyOffset_14) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)SCharacterPart.__PropertyOffset_14) = (value ? 1 : 0);
			}
		}

		// Token: 0x170079D3 RID: 31187
		// (get) Token: 0x0602CF1E RID: 184094 RVA: 0x00AB3C44 File Offset: 0x00AB1E44
		// (set) Token: 0x0602CF1F RID: 184095 RVA: 0x00AB3C54 File Offset: 0x00AB1E54
		public unsafe bool 是否在目标创建时显示部位状态条
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SCharacterPart.__PropertyOffset_15) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)SCharacterPart.__PropertyOffset_15) = (value ? 1 : 0);
			}
		}

		// Token: 0x170079D4 RID: 31188
		// (get) Token: 0x0602CF20 RID: 184096 RVA: 0x00AB3C65 File Offset: 0x00AB1E65
		// (set) Token: 0x0602CF21 RID: 184097 RVA: 0x00AB3C79 File Offset: 0x00AB1E79
		public unsafe FName 部位状态条骨骼插槽
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SCharacterPart.__PropertyOffset_16);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SCharacterPart.__PropertyOffset_16) = value;
			}
		}

		// Token: 0x170079D5 RID: 31189
		// (get) Token: 0x0602CF22 RID: 184098 RVA: 0x00AB3C8E File Offset: 0x00AB1E8E
		// (set) Token: 0x0602CF23 RID: 184099 RVA: 0x00AB3C9E File Offset: 0x00AB1E9E
		public unsafe float 受击后血条显示时长
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SCharacterPart.__PropertyOffset_17);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SCharacterPart.__PropertyOffset_17) = value;
			}
		}

		// Token: 0x170079D6 RID: 31190
		// (get) Token: 0x0602CF24 RID: 184100 RVA: 0x00AB3CB0 File Offset: 0x00AB1EB0
		// (set) Token: 0x0602CF25 RID: 184101 RVA: 0x00AB3CF3 File Offset: 0x00AB1EF3
		public TArray<long> 属性快照Buff列表
		{
			get
			{
				base.FastCheckIsValid();
				TArray<long> result;
				if ((result = this._属性快照Buff列表) == null)
				{
					result = (this._属性快照Buff列表 = new TArray<long>(base.NativePtr + (IntPtr)SCharacterPart.__PropertyOffset_18, base.MemoryOwner ?? this));
				}
				return result;
			}
			set
			{
				this.属性快照Buff列表.CopyAssign(value);
			}
		}

		// Token: 0x170079D7 RID: 31191
		// (get) Token: 0x0602CF26 RID: 184102 RVA: 0x00AB3D01 File Offset: 0x00AB1F01
		// (set) Token: 0x0602CF27 RID: 184103 RVA: 0x00AB3D15 File Offset: 0x00AB1F15
		[Nullable(2)]
		public unsafe UEffectModelBase 扫描特效
		{
			[NullableContext(2)]
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UEffectModelBase>(base.NativePtr / (IntPtr)sizeof(void*) + SCharacterPart.__PropertyOffset_19);
			}
			[NullableContext(2)]
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + SCharacterPart.__PropertyOffset_19, value);
			}
		}

		// Token: 0x170079D8 RID: 31192
		// (get) Token: 0x0602CF28 RID: 184104 RVA: 0x00AB3D2C File Offset: 0x00AB1F2C
		// (set) Token: 0x0602CF29 RID: 184105 RVA: 0x00AB3D6F File Offset: 0x00AB1F6F
		public FSoftObjectPath 被扫描播放特效
		{
			get
			{
				base.FastCheckIsValid();
				FSoftObjectPath result;
				if ((result = this._被扫描播放特效) == null)
				{
					result = (this._被扫描播放特效 = new FSoftObjectPath(base.NativePtr + (IntPtr)SCharacterPart.__PropertyOffset_20, base.MemoryOwner ?? this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FSoftObjectPath.StaticStruct(), base.NativePtr + (IntPtr)SCharacterPart.__PropertyOffset_20, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170079D9 RID: 31193
		// (get) Token: 0x0602CF2A RID: 184106 RVA: 0x00AB3D90 File Offset: 0x00AB1F90
		// (set) Token: 0x0602CF2B RID: 184107 RVA: 0x00AB3DA4 File Offset: 0x00AB1FA4
		public unsafe string 扫描特效绑定骨骼名
		{
			get
			{
				return FString.ToString((void*)(base.NativePtr + (byte*)((IntPtr)SCharacterPart.__PropertyOffset_21)));
			}
			set
			{
				FString.CopyFrom((void*)(base.NativePtr + (byte*)((IntPtr)SCharacterPart.__PropertyOffset_21)), value);
			}
		}

		// Token: 0x170079DA RID: 31194
		// (get) Token: 0x0602CF2C RID: 184108 RVA: 0x00AB3DB9 File Offset: 0x00AB1FB9
		// (set) Token: 0x0602CF2D RID: 184109 RVA: 0x00AB3DCD File Offset: 0x00AB1FCD
		[Nullable(2)]
		public unsafe PD_CharacterControllerData_C 扫描材质特效
		{
			[NullableContext(2)]
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<PD_CharacterControllerData_C>(base.NativePtr / (IntPtr)sizeof(void*) + SCharacterPart.__PropertyOffset_22);
			}
			[NullableContext(2)]
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + SCharacterPart.__PropertyOffset_22, value);
			}
		}

		// Token: 0x170079DB RID: 31195
		// (get) Token: 0x0602CF2E RID: 184110 RVA: 0x00AB3DE2 File Offset: 0x00AB1FE2
		// (set) Token: 0x0602CF2F RID: 184111 RVA: 0x00AB3DF6 File Offset: 0x00AB1FF6
		public unsafe FName 合体骨骼名
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SCharacterPart.__PropertyOffset_23);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SCharacterPart.__PropertyOffset_23) = value;
			}
		}

		// Token: 0x0602CF30 RID: 184112 RVA: 0x00AB3E0B File Offset: 0x00AB200B
		public SCharacterPart()
		{
		}

		// Token: 0x0602CF31 RID: 184113 RVA: 0x00AB3E14 File Offset: 0x00AB2014
		public SCharacterPart(string 部位名, TArray<string> 骨骼名, bool 是否独立承伤, bool 是否出生激活, FGameplayTag 部位标签, FGameplayTag 部位激活标签, float 继承生命值比例, bool 是否弱点, [Nullable(new byte[]
		{
			1,
			0
		})] TSet<TEnumAsByte<EBulletType>> 弱点攻击类型, float 弱点受击角度, bool 精准弱点受击角度判定, TMap<string, string> 碰撞框朝向, bool 是否盾牌, float 格挡判定角度, bool 是否传递伤害, bool 是否在目标创建时显示部位状态条, FName 部位状态条骨骼插槽, float 受击后血条显示时长, TArray<long> 属性快照Buff列表, UEffectModelBase 扫描特效, FSoftObjectPath 被扫描播放特效, string 扫描特效绑定骨骼名, PD_CharacterControllerData_C 扫描材质特效, FName 合体骨骼名)
		{
			this.部位名 = 部位名;
			this.骨骼名 = 骨骼名;
			this.是否独立承伤 = 是否独立承伤;
			this.是否出生激活 = 是否出生激活;
			this.部位标签 = 部位标签;
			this.部位激活标签 = 部位激活标签;
			this.继承生命值比例 = 继承生命值比例;
			this.是否弱点 = 是否弱点;
			this.弱点攻击类型 = 弱点攻击类型;
			this.弱点受击角度 = 弱点受击角度;
			this.精准弱点受击角度判定 = 精准弱点受击角度判定;
			this.碰撞框朝向 = 碰撞框朝向;
			this.是否盾牌 = 是否盾牌;
			this.格挡判定角度 = 格挡判定角度;
			this.是否传递伤害 = 是否传递伤害;
			this.是否在目标创建时显示部位状态条 = 是否在目标创建时显示部位状态条;
			this.部位状态条骨骼插槽 = 部位状态条骨骼插槽;
			this.受击后血条显示时长 = 受击后血条显示时长;
			this.属性快照Buff列表 = 属性快照Buff列表;
			this.扫描特效 = 扫描特效;
			this.被扫描播放特效 = 被扫描播放特效;
			this.扫描特效绑定骨骼名 = 扫描特效绑定骨骼名;
			this.扫描材质特效 = 扫描材质特效;
			this.合体骨骼名 = 合体骨骼名;
		}

		// Token: 0x0602CF32 RID: 184114 RVA: 0x00AB3EE4 File Offset: 0x00AB20E4
		protected override IntPtr GetUStructPtr()
		{
			return SCharacterPart.StaticStruct();
		}

		// Token: 0x0602CF33 RID: 184115 RVA: 0x00AB3EF0 File Offset: 0x00AB20F0
		[NullableContext(2)]
		public SCharacterPart(IntPtr NativePtr, UnrealObject MemoryOwner) : base(NativePtr, MemoryOwner)
		{
		}

		// Token: 0x0602CF34 RID: 184116 RVA: 0x00AB3EFA File Offset: 0x00AB20FA
		public SCharacterPart(IntPtr NativePtr, bool bWithMoveAssign, bool bWithCopyAssignIfCannotMove) : base(NativePtr, bWithMoveAssign, bWithCopyAssignIfCannotMove)
		{
		}

		// Token: 0x0602CF35 RID: 184117 RVA: 0x00AB3F05 File Offset: 0x00AB2105
		public static IUnrealScriptStructProxy CreateFromPointer(IntPtr Pointer)
		{
			return new SCharacterPart(Pointer, false, true);
		}

		// Token: 0x0602CF36 RID: 184118 RVA: 0x00AB3F0F File Offset: 0x00AB210F
		public static IUnrealScriptStructProxy CreateReferenceFromPointer(IntPtr Pointer, UnrealObject MemoryOwner)
		{
			return new SCharacterPart(Pointer, MemoryOwner);
		}

		// Token: 0x04019352 RID: 103250
		public const string __ObjectPath = "/Game/Aki/Character/BaseCharacter/SCharacterPart.SCharacterPart";

		// Token: 0x04019353 RID: 103251
		private static IntPtr _ScriptStructPtr;

		// Token: 0x04019354 RID: 103252
		internal static int __PropertyOffset_0;

		// Token: 0x04019355 RID: 103253
		internal static int __PropertyOffset_1;

		// Token: 0x04019356 RID: 103254
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private TArray<string> _骨骼名;

		// Token: 0x04019357 RID: 103255
		internal static int __PropertyOffset_2;

		// Token: 0x04019358 RID: 103256
		internal static int __PropertyOffset_3;

		// Token: 0x04019359 RID: 103257
		internal static int __PropertyOffset_4;

		// Token: 0x0401935A RID: 103258
		internal static int __PropertyOffset_5;

		// Token: 0x0401935B RID: 103259
		internal static int __PropertyOffset_6;

		// Token: 0x0401935C RID: 103260
		internal static int __PropertyOffset_7;

		// Token: 0x0401935D RID: 103261
		internal static int __PropertyOffset_8;

		// Token: 0x0401935E RID: 103262
		[Nullable(new byte[]
		{
			2,
			0
		})]
		private TSet<TEnumAsByte<EBulletType>> _弱点攻击类型;

		// Token: 0x0401935F RID: 103263
		internal static int __PropertyOffset_9;

		// Token: 0x04019360 RID: 103264
		internal static int __PropertyOffset_10;

		// Token: 0x04019361 RID: 103265
		internal static int __PropertyOffset_11;

		// Token: 0x04019362 RID: 103266
		[Nullable(new byte[]
		{
			2,
			1,
			1
		})]
		private TMap<string, string> _碰撞框朝向;

		// Token: 0x04019363 RID: 103267
		internal static int __PropertyOffset_12;

		// Token: 0x04019364 RID: 103268
		internal static int __PropertyOffset_13;

		// Token: 0x04019365 RID: 103269
		internal static int __PropertyOffset_14;

		// Token: 0x04019366 RID: 103270
		internal static int __PropertyOffset_15;

		// Token: 0x04019367 RID: 103271
		internal static int __PropertyOffset_16;

		// Token: 0x04019368 RID: 103272
		internal static int __PropertyOffset_17;

		// Token: 0x04019369 RID: 103273
		internal static int __PropertyOffset_18;

		// Token: 0x0401936A RID: 103274
		[Nullable(2)]
		private TArray<long> _属性快照Buff列表;

		// Token: 0x0401936B RID: 103275
		internal static int __PropertyOffset_19;

		// Token: 0x0401936C RID: 103276
		internal static int __PropertyOffset_20;

		// Token: 0x0401936D RID: 103277
		[Nullable(2)]
		private FSoftObjectPath _被扫描播放特效;

		// Token: 0x0401936E RID: 103278
		internal static int __PropertyOffset_21;

		// Token: 0x0401936F RID: 103279
		internal static int __PropertyOffset_22;

		// Token: 0x04019370 RID: 103280
		internal static int __PropertyOffset_23;
	}
}
