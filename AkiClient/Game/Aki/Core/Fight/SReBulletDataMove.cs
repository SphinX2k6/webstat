using System;
using System.Runtime.CompilerServices;
using AkiClient.Game.Aki.Character.BaseCharacter;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Core.Fight
{
	// Token: 0x02003F75 RID: 16245
	[NullableContext(1)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Core/Fight/SReBulletDataMove.SReBulletDataMove")]
	[UnrealStructLayout(296, 8, UnrealReflectionPropertyTypeCode.UnrealScriptStructProxy, PropertiesSize = 296)]
	public class SReBulletDataMove : UnrealUserDefinedStructProxy, IUnrealScriptStructProxy, IUnrealScriptStruct, IUnrealObject
	{
		// Token: 0x06028984 RID: 166276 RVA: 0x00A0FDDC File Offset: 0x00A0DFDC
		public static UScriptStructStackOnlyPtr StaticStruct()
		{
			return (SReBulletDataMove._ScriptStructPtr != 0) ? SReBulletDataMove._ScriptStructPtr : UObjectGlobals.StaticLoadScriptStruct("/Game/Aki/Core/Fight/SReBulletDataMove.SReBulletDataMove", ref SReBulletDataMove._ScriptStructPtr);
		}

		// Token: 0x1700630E RID: 25358
		// (get) Token: 0x06028985 RID: 166277 RVA: 0x00A0FE00 File Offset: 0x00A0E000
		// (set) Token: 0x06028986 RID: 166278 RVA: 0x00A0FE14 File Offset: 0x00A0E014
		[Nullable(0)]
		public unsafe TEnumAsByte<EBulletFollowType> 子弹跟随类型
		{
			[NullableContext(0)]
			get
			{
				return *(base.NativePtr + (IntPtr)SReBulletDataMove.__PropertyOffset_0);
			}
			[NullableContext(0)]
			set
			{
				*(base.NativePtr + (IntPtr)SReBulletDataMove.__PropertyOffset_0) = value;
			}
		}

		// Token: 0x1700630F RID: 25359
		// (get) Token: 0x06028987 RID: 166279 RVA: 0x00A0FE29 File Offset: 0x00A0E029
		// (set) Token: 0x06028988 RID: 166280 RVA: 0x00A0FE3D File Offset: 0x00A0E03D
		public unsafe string 骨骼网格体名字
		{
			get
			{
				return FString.ToString((void*)(base.NativePtr + (byte*)((IntPtr)SReBulletDataMove.__PropertyOffset_1)));
			}
			set
			{
				FString.CopyFrom((void*)(base.NativePtr + (byte*)((IntPtr)SReBulletDataMove.__PropertyOffset_1)), value);
			}
		}

		// Token: 0x17006310 RID: 25360
		// (get) Token: 0x06028989 RID: 166281 RVA: 0x00A0FE52 File Offset: 0x00A0E052
		// (set) Token: 0x0602898A RID: 166282 RVA: 0x00A0FE66 File Offset: 0x00A0E066
		public unsafe FName 骨骼名字
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SReBulletDataMove.__PropertyOffset_2);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SReBulletDataMove.__PropertyOffset_2) = value;
			}
		}

		// Token: 0x17006311 RID: 25361
		// (get) Token: 0x0602898B RID: 166283 RVA: 0x00A0FE7B File Offset: 0x00A0E07B
		// (set) Token: 0x0602898C RID: 166284 RVA: 0x00A0FE8B File Offset: 0x00A0E08B
		public unsafe bool 是否锁定缩放
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SReBulletDataMove.__PropertyOffset_3) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)SReBulletDataMove.__PropertyOffset_3) = (value ? 1 : 0);
			}
		}

		// Token: 0x17006312 RID: 25362
		// (get) Token: 0x0602898D RID: 166285 RVA: 0x00A0FE9C File Offset: 0x00A0E09C
		// (set) Token: 0x0602898E RID: 166286 RVA: 0x00A0FEAC File Offset: 0x00A0E0AC
		public unsafe bool 技能结束解除跟随骨骼
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SReBulletDataMove.__PropertyOffset_4) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)SReBulletDataMove.__PropertyOffset_4) = (value ? 1 : 0);
			}
		}

		// Token: 0x17006313 RID: 25363
		// (get) Token: 0x0602898F RID: 166287 RVA: 0x00A0FEBD File Offset: 0x00A0E0BD
		// (set) Token: 0x06028990 RID: 166288 RVA: 0x00A0FED1 File Offset: 0x00A0E0D1
		public unsafe FVector 跟随骨骼限制旋转
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SReBulletDataMove.__PropertyOffset_5);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SReBulletDataMove.__PropertyOffset_5) = value;
			}
		}

		// Token: 0x17006314 RID: 25364
		// (get) Token: 0x06028991 RID: 166289 RVA: 0x00A0FEE6 File Offset: 0x00A0E0E6
		// (set) Token: 0x06028992 RID: 166290 RVA: 0x00A0FEFA File Offset: 0x00A0E0FA
		[Nullable(0)]
		public unsafe TEnumAsByte<EInitialVelocityDirection> 出生初速度方向基准
		{
			[NullableContext(0)]
			get
			{
				return *(base.NativePtr + (IntPtr)SReBulletDataMove.__PropertyOffset_6);
			}
			[NullableContext(0)]
			set
			{
				*(base.NativePtr + (IntPtr)SReBulletDataMove.__PropertyOffset_6) = value;
			}
		}

		// Token: 0x17006315 RID: 25365
		// (get) Token: 0x06028993 RID: 166291 RVA: 0x00A0FF0F File Offset: 0x00A0E10F
		// (set) Token: 0x06028994 RID: 166292 RVA: 0x00A0FF23 File Offset: 0x00A0E123
		public unsafe string 出生初速度方向基准参数
		{
			get
			{
				return FString.ToString((void*)(base.NativePtr + (byte*)((IntPtr)SReBulletDataMove.__PropertyOffset_7)));
			}
			set
			{
				FString.CopyFrom((void*)(base.NativePtr + (byte*)((IntPtr)SReBulletDataMove.__PropertyOffset_7)), value);
			}
		}

		// Token: 0x17006316 RID: 25366
		// (get) Token: 0x06028995 RID: 166293 RVA: 0x00A0FF38 File Offset: 0x00A0E138
		// (set) Token: 0x06028996 RID: 166294 RVA: 0x00A0FF48 File Offset: 0x00A0E148
		public unsafe bool 初速度仅Z轴朝向
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SReBulletDataMove.__PropertyOffset_8) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)SReBulletDataMove.__PropertyOffset_8) = (value ? 1 : 0);
			}
		}

		// Token: 0x17006317 RID: 25367
		// (get) Token: 0x06028997 RID: 166295 RVA: 0x00A0FF59 File Offset: 0x00A0E159
		// (set) Token: 0x06028998 RID: 166296 RVA: 0x00A0FF6D File Offset: 0x00A0E16D
		public unsafe FRotator 初速度偏移方向
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SReBulletDataMove.__PropertyOffset_9);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SReBulletDataMove.__PropertyOffset_9) = value;
			}
		}

		// Token: 0x17006318 RID: 25368
		// (get) Token: 0x06028999 RID: 166297 RVA: 0x00A0FF82 File Offset: 0x00A0E182
		// (set) Token: 0x0602899A RID: 166298 RVA: 0x00A0FF96 File Offset: 0x00A0E196
		public unsafe FVector 初速度方向随机
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SReBulletDataMove.__PropertyOffset_10);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SReBulletDataMove.__PropertyOffset_10) = value;
			}
		}

		// Token: 0x17006319 RID: 25369
		// (get) Token: 0x0602899B RID: 166299 RVA: 0x00A0FFAC File Offset: 0x00A0E1AC
		// (set) Token: 0x0602899C RID: 166300 RVA: 0x00A0FFEF File Offset: 0x00A0E1EF
		[Nullable(new byte[]
		{
			1,
			0
		})]
		public TMap<TEnumAsByte<EBulletBeginVelocityLimit>, float> 初速度角度限制
		{
			[return: Nullable(new byte[]
			{
				1,
				0
			})]
			get
			{
				base.FastCheckIsValid();
				TMap<TEnumAsByte<EBulletBeginVelocityLimit>, float> result;
				if ((result = this._初速度角度限制) == null)
				{
					result = (this._初速度角度限制 = new TMap<TEnumAsByte<EBulletBeginVelocityLimit>, float>(base.NativePtr + (IntPtr)SReBulletDataMove.__PropertyOffset_11, base.MemoryOwner ?? this));
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
				this.初速度角度限制.CopyAssign(value);
			}
		}

		// Token: 0x1700631A RID: 25370
		// (get) Token: 0x0602899D RID: 166301 RVA: 0x00A0FFFD File Offset: 0x00A0E1FD
		// (set) Token: 0x0602899E RID: 166302 RVA: 0x00A1000D File Offset: 0x00A0E20D
		public unsafe float 发射上下角度限制
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SReBulletDataMove.__PropertyOffset_12);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SReBulletDataMove.__PropertyOffset_12) = value;
			}
		}

		// Token: 0x1700631B RID: 25371
		// (get) Token: 0x0602899F RID: 166303 RVA: 0x00A1001E File Offset: 0x00A0E21E
		// (set) Token: 0x060289A0 RID: 166304 RVA: 0x00A1002E File Offset: 0x00A0E22E
		public unsafe float 移动速度
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SReBulletDataMove.__PropertyOffset_13);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SReBulletDataMove.__PropertyOffset_13) = value;
			}
		}

		// Token: 0x1700631C RID: 25372
		// (get) Token: 0x060289A1 RID: 166305 RVA: 0x00A1003F File Offset: 0x00A0E23F
		// (set) Token: 0x060289A2 RID: 166306 RVA: 0x00A10053 File Offset: 0x00A0E253
		[Nullable(2)]
		public unsafe UCurveFloat 移动速度曲线
		{
			[NullableContext(2)]
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UCurveFloat>(base.NativePtr / (IntPtr)sizeof(void*) + SReBulletDataMove.__PropertyOffset_14);
			}
			[NullableContext(2)]
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + SReBulletDataMove.__PropertyOffset_14, value);
			}
		}

		// Token: 0x1700631D RID: 25373
		// (get) Token: 0x060289A3 RID: 166307 RVA: 0x00A10068 File Offset: 0x00A0E268
		// (set) Token: 0x060289A4 RID: 166308 RVA: 0x00A1007C File Offset: 0x00A0E27C
		[Nullable(0)]
		public unsafe TEnumAsByte<EMoveTrajectory> 运动轨迹类型
		{
			[NullableContext(0)]
			get
			{
				return *(base.NativePtr + (IntPtr)SReBulletDataMove.__PropertyOffset_15);
			}
			[NullableContext(0)]
			set
			{
				*(base.NativePtr + (IntPtr)SReBulletDataMove.__PropertyOffset_15) = value;
			}
		}

		// Token: 0x1700631E RID: 25374
		// (get) Token: 0x060289A5 RID: 166309 RVA: 0x00A10094 File Offset: 0x00A0E294
		// (set) Token: 0x060289A6 RID: 166310 RVA: 0x00A100D7 File Offset: 0x00A0E2D7
		public TArray<FVector> 运动轨迹参数数据
		{
			get
			{
				base.FastCheckIsValid();
				TArray<FVector> result;
				if ((result = this._运动轨迹参数数据) == null)
				{
					result = (this._运动轨迹参数数据 = new TArray<FVector>(base.NativePtr + (IntPtr)SReBulletDataMove.__PropertyOffset_16, base.MemoryOwner ?? this));
				}
				return result;
			}
			set
			{
				this.运动轨迹参数数据.CopyAssign(value);
			}
		}

		// Token: 0x1700631F RID: 25375
		// (get) Token: 0x060289A7 RID: 166311 RVA: 0x00A100E8 File Offset: 0x00A0E2E8
		// (set) Token: 0x060289A8 RID: 166312 RVA: 0x00A1012B File Offset: 0x00A0E32B
		public TArray<UCurveVector> 运动轨迹参数曲线
		{
			get
			{
				base.FastCheckIsValid();
				TArray<UCurveVector> result;
				if ((result = this._运动轨迹参数曲线) == null)
				{
					result = (this._运动轨迹参数曲线 = new TArray<UCurveVector>(base.NativePtr + (IntPtr)SReBulletDataMove.__PropertyOffset_17, base.MemoryOwner ?? this));
				}
				return result;
			}
			set
			{
				this.运动轨迹参数曲线.CopyAssign(value);
			}
		}

		// Token: 0x17006320 RID: 25376
		// (get) Token: 0x060289A9 RID: 166313 RVA: 0x00A10139 File Offset: 0x00A0E339
		// (set) Token: 0x060289AA RID: 166314 RVA: 0x00A1014D File Offset: 0x00A0E34D
		[Nullable(0)]
		public unsafe TEnumAsByte<EBulletTarget> 运动轨迹参数目标
		{
			[NullableContext(0)]
			get
			{
				return *(base.NativePtr + (IntPtr)SReBulletDataMove.__PropertyOffset_18);
			}
			[NullableContext(0)]
			set
			{
				*(base.NativePtr + (IntPtr)SReBulletDataMove.__PropertyOffset_18) = value;
			}
		}

		// Token: 0x17006321 RID: 25377
		// (get) Token: 0x060289AB RID: 166315 RVA: 0x00A10162 File Offset: 0x00A0E362
		// (set) Token: 0x060289AC RID: 166316 RVA: 0x00A10176 File Offset: 0x00A0E376
		public unsafe string 运动轨迹目标黑板Key值
		{
			get
			{
				return FString.ToString((void*)(base.NativePtr + (byte*)((IntPtr)SReBulletDataMove.__PropertyOffset_19)));
			}
			set
			{
				FString.CopyFrom((void*)(base.NativePtr + (byte*)((IntPtr)SReBulletDataMove.__PropertyOffset_19)), value);
			}
		}

		// Token: 0x17006322 RID: 25378
		// (get) Token: 0x060289AD RID: 166317 RVA: 0x00A1018B File Offset: 0x00A0E38B
		// (set) Token: 0x060289AE RID: 166318 RVA: 0x00A1019F File Offset: 0x00A0E39F
		[Nullable(0)]
		public unsafe TEnumAsByte<EBulletDestOffset> 终点偏移基准朝向
		{
			[NullableContext(0)]
			get
			{
				return *(base.NativePtr + (IntPtr)SReBulletDataMove.__PropertyOffset_20);
			}
			[NullableContext(0)]
			set
			{
				*(base.NativePtr + (IntPtr)SReBulletDataMove.__PropertyOffset_20) = value;
			}
		}

		// Token: 0x17006323 RID: 25379
		// (get) Token: 0x060289AF RID: 166319 RVA: 0x00A101B4 File Offset: 0x00A0E3B4
		// (set) Token: 0x060289B0 RID: 166320 RVA: 0x00A101C8 File Offset: 0x00A0E3C8
		public unsafe FVector 终点偏移
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SReBulletDataMove.__PropertyOffset_21);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SReBulletDataMove.__PropertyOffset_21) = value;
			}
		}

		// Token: 0x17006324 RID: 25380
		// (get) Token: 0x060289B1 RID: 166321 RVA: 0x00A101DD File Offset: 0x00A0E3DD
		// (set) Token: 0x060289B2 RID: 166322 RVA: 0x00A101F1 File Offset: 0x00A0E3F1
		public unsafe string 运动轨迹目标骨骼
		{
			get
			{
				return FString.ToString((void*)(base.NativePtr + (byte*)((IntPtr)SReBulletDataMove.__PropertyOffset_22)));
			}
			set
			{
				FString.CopyFrom((void*)(base.NativePtr + (byte*)((IntPtr)SReBulletDataMove.__PropertyOffset_22)), value);
			}
		}

		// Token: 0x060289B3 RID: 166323 RVA: 0x00A10206 File Offset: 0x00A0E406
		public SReBulletDataMove()
		{
		}

		// Token: 0x060289B4 RID: 166324 RVA: 0x00A10210 File Offset: 0x00A0E410
		public SReBulletDataMove([Nullable(0)] TEnumAsByte<EBulletFollowType> 子弹跟随类型, string 骨骼网格体名字, FName 骨骼名字, bool 是否锁定缩放, bool 技能结束解除跟随骨骼, FVector 跟随骨骼限制旋转, [Nullable(0)] TEnumAsByte<EInitialVelocityDirection> 出生初速度方向基准, string 出生初速度方向基准参数, bool 初速度仅Z轴朝向, FRotator 初速度偏移方向, FVector 初速度方向随机, [Nullable(new byte[]
		{
			1,
			0
		})] TMap<TEnumAsByte<EBulletBeginVelocityLimit>, float> 初速度角度限制, float 发射上下角度限制, float 移动速度, UCurveFloat 移动速度曲线, [Nullable(0)] TEnumAsByte<EMoveTrajectory> 运动轨迹类型, TArray<FVector> 运动轨迹参数数据, TArray<UCurveVector> 运动轨迹参数曲线, [Nullable(0)] TEnumAsByte<EBulletTarget> 运动轨迹参数目标, string 运动轨迹目标黑板Key值, [Nullable(0)] TEnumAsByte<EBulletDestOffset> 终点偏移基准朝向, FVector 终点偏移, string 运动轨迹目标骨骼)
		{
			this.子弹跟随类型 = 子弹跟随类型;
			this.骨骼网格体名字 = 骨骼网格体名字;
			this.骨骼名字 = 骨骼名字;
			this.是否锁定缩放 = 是否锁定缩放;
			this.技能结束解除跟随骨骼 = 技能结束解除跟随骨骼;
			this.跟随骨骼限制旋转 = 跟随骨骼限制旋转;
			this.出生初速度方向基准 = 出生初速度方向基准;
			this.出生初速度方向基准参数 = 出生初速度方向基准参数;
			this.初速度仅Z轴朝向 = 初速度仅Z轴朝向;
			this.初速度偏移方向 = 初速度偏移方向;
			this.初速度方向随机 = 初速度方向随机;
			this.初速度角度限制 = 初速度角度限制;
			this.发射上下角度限制 = 发射上下角度限制;
			this.移动速度 = 移动速度;
			this.移动速度曲线 = 移动速度曲线;
			this.运动轨迹类型 = 运动轨迹类型;
			this.运动轨迹参数数据 = 运动轨迹参数数据;
			this.运动轨迹参数曲线 = 运动轨迹参数曲线;
			this.运动轨迹参数目标 = 运动轨迹参数目标;
			this.运动轨迹目标黑板Key值 = 运动轨迹目标黑板Key值;
			this.终点偏移基准朝向 = 终点偏移基准朝向;
			this.终点偏移 = 终点偏移;
			this.运动轨迹目标骨骼 = 运动轨迹目标骨骼;
		}

		// Token: 0x060289B5 RID: 166325 RVA: 0x00A102D8 File Offset: 0x00A0E4D8
		protected override IntPtr GetUStructPtr()
		{
			return SReBulletDataMove.StaticStruct();
		}

		// Token: 0x060289B6 RID: 166326 RVA: 0x00A102E4 File Offset: 0x00A0E4E4
		[NullableContext(2)]
		public SReBulletDataMove(IntPtr NativePtr, UnrealObject MemoryOwner) : base(NativePtr, MemoryOwner)
		{
		}

		// Token: 0x060289B7 RID: 166327 RVA: 0x00A102EE File Offset: 0x00A0E4EE
		public SReBulletDataMove(IntPtr NativePtr, bool bWithMoveAssign, bool bWithCopyAssignIfCannotMove) : base(NativePtr, bWithMoveAssign, bWithCopyAssignIfCannotMove)
		{
		}

		// Token: 0x060289B8 RID: 166328 RVA: 0x00A102F9 File Offset: 0x00A0E4F9
		public static IUnrealScriptStructProxy CreateFromPointer(IntPtr Pointer)
		{
			return new SReBulletDataMove(Pointer, false, true);
		}

		// Token: 0x060289B9 RID: 166329 RVA: 0x00A10303 File Offset: 0x00A0E503
		public static IUnrealScriptStructProxy CreateReferenceFromPointer(IntPtr Pointer, UnrealObject MemoryOwner)
		{
			return new SReBulletDataMove(Pointer, MemoryOwner);
		}

		// Token: 0x0401568C RID: 87692
		public const string __ObjectPath = "/Game/Aki/Core/Fight/SReBulletDataMove.SReBulletDataMove";

		// Token: 0x0401568D RID: 87693
		private static IntPtr _ScriptStructPtr;

		// Token: 0x0401568E RID: 87694
		internal static int __PropertyOffset_0;

		// Token: 0x0401568F RID: 87695
		internal static int __PropertyOffset_1;

		// Token: 0x04015690 RID: 87696
		internal static int __PropertyOffset_2;

		// Token: 0x04015691 RID: 87697
		internal static int __PropertyOffset_3;

		// Token: 0x04015692 RID: 87698
		internal static int __PropertyOffset_4;

		// Token: 0x04015693 RID: 87699
		internal static int __PropertyOffset_5;

		// Token: 0x04015694 RID: 87700
		internal static int __PropertyOffset_6;

		// Token: 0x04015695 RID: 87701
		internal static int __PropertyOffset_7;

		// Token: 0x04015696 RID: 87702
		internal static int __PropertyOffset_8;

		// Token: 0x04015697 RID: 87703
		internal static int __PropertyOffset_9;

		// Token: 0x04015698 RID: 87704
		internal static int __PropertyOffset_10;

		// Token: 0x04015699 RID: 87705
		internal static int __PropertyOffset_11;

		// Token: 0x0401569A RID: 87706
		[Nullable(new byte[]
		{
			2,
			0
		})]
		private TMap<TEnumAsByte<EBulletBeginVelocityLimit>, float> _初速度角度限制;

		// Token: 0x0401569B RID: 87707
		internal static int __PropertyOffset_12;

		// Token: 0x0401569C RID: 87708
		internal static int __PropertyOffset_13;

		// Token: 0x0401569D RID: 87709
		internal static int __PropertyOffset_14;

		// Token: 0x0401569E RID: 87710
		internal static int __PropertyOffset_15;

		// Token: 0x0401569F RID: 87711
		internal static int __PropertyOffset_16;

		// Token: 0x040156A0 RID: 87712
		[Nullable(2)]
		private TArray<FVector> _运动轨迹参数数据;

		// Token: 0x040156A1 RID: 87713
		internal static int __PropertyOffset_17;

		// Token: 0x040156A2 RID: 87714
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private TArray<UCurveVector> _运动轨迹参数曲线;

		// Token: 0x040156A3 RID: 87715
		internal static int __PropertyOffset_18;

		// Token: 0x040156A4 RID: 87716
		internal static int __PropertyOffset_19;

		// Token: 0x040156A5 RID: 87717
		internal static int __PropertyOffset_20;

		// Token: 0x040156A6 RID: 87718
		internal static int __PropertyOffset_21;

		// Token: 0x040156A7 RID: 87719
		internal static int __PropertyOffset_22;
	}
}
