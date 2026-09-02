using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Character.BaseCharacter
{
	// Token: 0x02004244 RID: 16964
	[NullableContext(2)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Character/BaseCharacter/SBulletDataMove.SBulletDataMove")]
	[UnrealStructLayout(144, 8, UnrealReflectionPropertyTypeCode.UnrealScriptStructProxy, PropertiesSize = 140)]
	public class SBulletDataMove : UnrealUserDefinedStructProxy, IUnrealScriptStructProxy, IUnrealScriptStruct, IUnrealObject
	{
		// Token: 0x0602CE61 RID: 183905 RVA: 0x00AB2BD4 File Offset: 0x00AB0DD4
		public static UScriptStructStackOnlyPtr StaticStruct()
		{
			return (SBulletDataMove._ScriptStructPtr != 0) ? SBulletDataMove._ScriptStructPtr : UObjectGlobals.StaticLoadScriptStruct("/Game/Aki/Character/BaseCharacter/SBulletDataMove.SBulletDataMove", ref SBulletDataMove._ScriptStructPtr);
		}

		// Token: 0x17007995 RID: 31125
		// (get) Token: 0x0602CE62 RID: 183906 RVA: 0x00AB2BF8 File Offset: 0x00AB0DF8
		// (set) Token: 0x0602CE63 RID: 183907 RVA: 0x00AB2C0C File Offset: 0x00AB0E0C
		[Nullable(0)]
		public unsafe TEnumAsByte<EBulletFollowType> 子弹跟随类型
		{
			[NullableContext(0)]
			get
			{
				return *(base.NativePtr + (IntPtr)SBulletDataMove.__PropertyOffset_0);
			}
			[NullableContext(0)]
			set
			{
				*(base.NativePtr + (IntPtr)SBulletDataMove.__PropertyOffset_0) = value;
			}
		}

		// Token: 0x17007996 RID: 31126
		// (get) Token: 0x0602CE64 RID: 183908 RVA: 0x00AB2C21 File Offset: 0x00AB0E21
		// (set) Token: 0x0602CE65 RID: 183909 RVA: 0x00AB2C35 File Offset: 0x00AB0E35
		public unsafe FName 骨骼名
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SBulletDataMove.__PropertyOffset_1);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SBulletDataMove.__PropertyOffset_1) = value;
			}
		}

		// Token: 0x17007997 RID: 31127
		// (get) Token: 0x0602CE66 RID: 183910 RVA: 0x00AB2C4A File Offset: 0x00AB0E4A
		// (set) Token: 0x0602CE67 RID: 183911 RVA: 0x00AB2C5A File Offset: 0x00AB0E5A
		public unsafe bool 跟随骨骼面向发射
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SBulletDataMove.__PropertyOffset_2) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)SBulletDataMove.__PropertyOffset_2) = (value ? 1 : 0);
			}
		}

		// Token: 0x17007998 RID: 31128
		// (get) Token: 0x0602CE68 RID: 183912 RVA: 0x00AB2C6B File Offset: 0x00AB0E6B
		// (set) Token: 0x0602CE69 RID: 183913 RVA: 0x00AB2C7B File Offset: 0x00AB0E7B
		public unsafe bool 瞄准发射
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SBulletDataMove.__PropertyOffset_3) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)SBulletDataMove.__PropertyOffset_3) = (value ? 1 : 0);
			}
		}

		// Token: 0x17007999 RID: 31129
		// (get) Token: 0x0602CE6A RID: 183914 RVA: 0x00AB2C8C File Offset: 0x00AB0E8C
		// (set) Token: 0x0602CE6B RID: 183915 RVA: 0x00AB2C9C File Offset: 0x00AB0E9C
		public unsafe bool 无限制追踪子弹
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SBulletDataMove.__PropertyOffset_4) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)SBulletDataMove.__PropertyOffset_4) = (value ? 1 : 0);
			}
		}

		// Token: 0x1700799A RID: 31130
		// (get) Token: 0x0602CE6C RID: 183916 RVA: 0x00AB2CAD File Offset: 0x00AB0EAD
		// (set) Token: 0x0602CE6D RID: 183917 RVA: 0x00AB2CBD File Offset: 0x00AB0EBD
		public unsafe bool 不改变朝向
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SBulletDataMove.__PropertyOffset_5) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)SBulletDataMove.__PropertyOffset_5) = (value ? 1 : 0);
			}
		}

		// Token: 0x1700799B RID: 31131
		// (get) Token: 0x0602CE6E RID: 183918 RVA: 0x00AB2CCE File Offset: 0x00AB0ECE
		// (set) Token: 0x0602CE6F RID: 183919 RVA: 0x00AB2CDE File Offset: 0x00AB0EDE
		public unsafe float 瞄准子弹最大射程
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SBulletDataMove.__PropertyOffset_6);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SBulletDataMove.__PropertyOffset_6) = value;
			}
		}

		// Token: 0x1700799C RID: 31132
		// (get) Token: 0x0602CE70 RID: 183920 RVA: 0x00AB2CEF File Offset: 0x00AB0EEF
		// (set) Token: 0x0602CE71 RID: 183921 RVA: 0x00AB2CFF File Offset: 0x00AB0EFF
		public unsafe float 瞄准子弹最大偏转角度
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SBulletDataMove.__PropertyOffset_7);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SBulletDataMove.__PropertyOffset_7) = value;
			}
		}

		// Token: 0x1700799D RID: 31133
		// (get) Token: 0x0602CE72 RID: 183922 RVA: 0x00AB2D10 File Offset: 0x00AB0F10
		// (set) Token: 0x0602CE73 RID: 183923 RVA: 0x00AB2D20 File Offset: 0x00AB0F20
		public unsafe bool 初始旋转是否面向目标
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SBulletDataMove.__PropertyOffset_8) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)SBulletDataMove.__PropertyOffset_8) = (value ? 1 : 0);
			}
		}

		// Token: 0x1700799E RID: 31134
		// (get) Token: 0x0602CE74 RID: 183924 RVA: 0x00AB2D31 File Offset: 0x00AB0F31
		// (set) Token: 0x0602CE75 RID: 183925 RVA: 0x00AB2D41 File Offset: 0x00AB0F41
		public unsafe float 初始旋转最大角度
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SBulletDataMove.__PropertyOffset_9);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SBulletDataMove.__PropertyOffset_9) = value;
			}
		}

		// Token: 0x1700799F RID: 31135
		// (get) Token: 0x0602CE76 RID: 183926 RVA: 0x00AB2D52 File Offset: 0x00AB0F52
		// (set) Token: 0x0602CE77 RID: 183927 RVA: 0x00AB2D62 File Offset: 0x00AB0F62
		public unsafe float 初始速度
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SBulletDataMove.__PropertyOffset_10);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SBulletDataMove.__PropertyOffset_10) = value;
			}
		}

		// Token: 0x170079A0 RID: 31136
		// (get) Token: 0x0602CE78 RID: 183928 RVA: 0x00AB2D73 File Offset: 0x00AB0F73
		// (set) Token: 0x0602CE79 RID: 183929 RVA: 0x00AB2D87 File Offset: 0x00AB0F87
		public unsafe UCurveFloat 速度变化曲线
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UCurveFloat>(base.NativePtr / (IntPtr)sizeof(void*) + SBulletDataMove.__PropertyOffset_11);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + SBulletDataMove.__PropertyOffset_11, value);
			}
		}

		// Token: 0x170079A1 RID: 31137
		// (get) Token: 0x0602CE7A RID: 183930 RVA: 0x00AB2D9C File Offset: 0x00AB0F9C
		// (set) Token: 0x0602CE7B RID: 183931 RVA: 0x00AB2DB0 File Offset: 0x00AB0FB0
		public unsafe FRotator 初始速度方向
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SBulletDataMove.__PropertyOffset_12);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SBulletDataMove.__PropertyOffset_12) = value;
			}
		}

		// Token: 0x170079A2 RID: 31138
		// (get) Token: 0x0602CE7C RID: 183932 RVA: 0x00AB2DC5 File Offset: 0x00AB0FC5
		// (set) Token: 0x0602CE7D RID: 183933 RVA: 0x00AB2DD9 File Offset: 0x00AB0FD9
		public unsafe FRotator 方向偏转速度
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SBulletDataMove.__PropertyOffset_13);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SBulletDataMove.__PropertyOffset_13) = value;
			}
		}

		// Token: 0x170079A3 RID: 31139
		// (get) Token: 0x0602CE7E RID: 183934 RVA: 0x00AB2DEE File Offset: 0x00AB0FEE
		// (set) Token: 0x0602CE7F RID: 183935 RVA: 0x00AB2E02 File Offset: 0x00AB1002
		public unsafe UCurveVector 方向偏转速度变化曲线
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UCurveVector>(base.NativePtr / (IntPtr)sizeof(void*) + SBulletDataMove.__PropertyOffset_14);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + SBulletDataMove.__PropertyOffset_14, value);
			}
		}

		// Token: 0x170079A4 RID: 31140
		// (get) Token: 0x0602CE80 RID: 183936 RVA: 0x00AB2E17 File Offset: 0x00AB1017
		// (set) Token: 0x0602CE81 RID: 183937 RVA: 0x00AB2E27 File Offset: 0x00AB1027
		public unsafe float 目标偏转速度
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SBulletDataMove.__PropertyOffset_15);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SBulletDataMove.__PropertyOffset_15) = value;
			}
		}

		// Token: 0x170079A5 RID: 31141
		// (get) Token: 0x0602CE82 RID: 183938 RVA: 0x00AB2E38 File Offset: 0x00AB1038
		// (set) Token: 0x0602CE83 RID: 183939 RVA: 0x00AB2E4C File Offset: 0x00AB104C
		public unsafe UCurveFloat 目标偏转速度变化曲线
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UCurveFloat>(base.NativePtr / (IntPtr)sizeof(void*) + SBulletDataMove.__PropertyOffset_16);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + SBulletDataMove.__PropertyOffset_16, value);
			}
		}

		// Token: 0x170079A6 RID: 31142
		// (get) Token: 0x0602CE84 RID: 183940 RVA: 0x00AB2E61 File Offset: 0x00AB1061
		// (set) Token: 0x0602CE85 RID: 183941 RVA: 0x00AB2E75 File Offset: 0x00AB1075
		public unsafe FVector 目标偏转速度分量
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SBulletDataMove.__PropertyOffset_17);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SBulletDataMove.__PropertyOffset_17) = value;
			}
		}

		// Token: 0x170079A7 RID: 31143
		// (get) Token: 0x0602CE86 RID: 183942 RVA: 0x00AB2E8A File Offset: 0x00AB108A
		// (set) Token: 0x0602CE87 RID: 183943 RVA: 0x00AB2E9E File Offset: 0x00AB109E
		public unsafe UCurveFloat 目标偏转速度分量Y变化曲线
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UCurveFloat>(base.NativePtr / (IntPtr)sizeof(void*) + SBulletDataMove.__PropertyOffset_18);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + SBulletDataMove.__PropertyOffset_18, value);
			}
		}

		// Token: 0x170079A8 RID: 31144
		// (get) Token: 0x0602CE88 RID: 183944 RVA: 0x00AB2EB3 File Offset: 0x00AB10B3
		// (set) Token: 0x0602CE89 RID: 183945 RVA: 0x00AB2EC7 File Offset: 0x00AB10C7
		public unsafe UCurveFloat 目标偏转速度分量Z变化曲线
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UCurveFloat>(base.NativePtr / (IntPtr)sizeof(void*) + SBulletDataMove.__PropertyOffset_19);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + SBulletDataMove.__PropertyOffset_19, value);
			}
		}

		// Token: 0x170079A9 RID: 31145
		// (get) Token: 0x0602CE8A RID: 183946 RVA: 0x00AB2EDC File Offset: 0x00AB10DC
		// (set) Token: 0x0602CE8B RID: 183947 RVA: 0x00AB2EF0 File Offset: 0x00AB10F0
		public unsafe FVector 合外力
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SBulletDataMove.__PropertyOffset_20);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SBulletDataMove.__PropertyOffset_20) = value;
			}
		}

		// Token: 0x0602CE8C RID: 183948 RVA: 0x00AB2F05 File Offset: 0x00AB1105
		public SBulletDataMove()
		{
		}

		// Token: 0x0602CE8D RID: 183949 RVA: 0x00AB2F10 File Offset: 0x00AB1110
		[NullableContext(1)]
		public SBulletDataMove([Nullable(0)] TEnumAsByte<EBulletFollowType> 子弹跟随类型, FName 骨骼名, bool 跟随骨骼面向发射, bool 瞄准发射, bool 无限制追踪子弹, bool 不改变朝向, float 瞄准子弹最大射程, float 瞄准子弹最大偏转角度, bool 初始旋转是否面向目标, float 初始旋转最大角度, float 初始速度, UCurveFloat 速度变化曲线, FRotator 初始速度方向, FRotator 方向偏转速度, UCurveVector 方向偏转速度变化曲线, float 目标偏转速度, UCurveFloat 目标偏转速度变化曲线, FVector 目标偏转速度分量, UCurveFloat 目标偏转速度分量Y变化曲线, UCurveFloat 目标偏转速度分量Z变化曲线, FVector 合外力)
		{
			this.子弹跟随类型 = 子弹跟随类型;
			this.骨骼名 = 骨骼名;
			this.跟随骨骼面向发射 = 跟随骨骼面向发射;
			this.瞄准发射 = 瞄准发射;
			this.无限制追踪子弹 = 无限制追踪子弹;
			this.不改变朝向 = 不改变朝向;
			this.瞄准子弹最大射程 = 瞄准子弹最大射程;
			this.瞄准子弹最大偏转角度 = 瞄准子弹最大偏转角度;
			this.初始旋转是否面向目标 = 初始旋转是否面向目标;
			this.初始旋转最大角度 = 初始旋转最大角度;
			this.初始速度 = 初始速度;
			this.速度变化曲线 = 速度变化曲线;
			this.初始速度方向 = 初始速度方向;
			this.方向偏转速度 = 方向偏转速度;
			this.方向偏转速度变化曲线 = 方向偏转速度变化曲线;
			this.目标偏转速度 = 目标偏转速度;
			this.目标偏转速度变化曲线 = 目标偏转速度变化曲线;
			this.目标偏转速度分量 = 目标偏转速度分量;
			this.目标偏转速度分量Y变化曲线 = 目标偏转速度分量Y变化曲线;
			this.目标偏转速度分量Z变化曲线 = 目标偏转速度分量Z变化曲线;
			this.合外力 = 合外力;
		}

		// Token: 0x0602CE8E RID: 183950 RVA: 0x00AB2FC8 File Offset: 0x00AB11C8
		protected override IntPtr GetUStructPtr()
		{
			return SBulletDataMove.StaticStruct();
		}

		// Token: 0x0602CE8F RID: 183951 RVA: 0x00AB2FD4 File Offset: 0x00AB11D4
		public SBulletDataMove(IntPtr NativePtr, UnrealObject MemoryOwner) : base(NativePtr, MemoryOwner)
		{
		}

		// Token: 0x0602CE90 RID: 183952 RVA: 0x00AB2FDE File Offset: 0x00AB11DE
		public SBulletDataMove(IntPtr NativePtr, bool bWithMoveAssign, bool bWithCopyAssignIfCannotMove) : base(NativePtr, bWithMoveAssign, bWithCopyAssignIfCannotMove)
		{
		}

		// Token: 0x0602CE91 RID: 183953 RVA: 0x00AB2FE9 File Offset: 0x00AB11E9
		[NullableContext(1)]
		public static IUnrealScriptStructProxy CreateFromPointer(IntPtr Pointer)
		{
			return new SBulletDataMove(Pointer, false, true);
		}

		// Token: 0x0602CE92 RID: 183954 RVA: 0x00AB2FF3 File Offset: 0x00AB11F3
		[NullableContext(1)]
		public static IUnrealScriptStructProxy CreateReferenceFromPointer(IntPtr Pointer, UnrealObject MemoryOwner)
		{
			return new SBulletDataMove(Pointer, MemoryOwner);
		}

		// Token: 0x0401930A RID: 103178
		[Nullable(1)]
		public const string __ObjectPath = "/Game/Aki/Character/BaseCharacter/SBulletDataMove.SBulletDataMove";

		// Token: 0x0401930B RID: 103179
		private static IntPtr _ScriptStructPtr;

		// Token: 0x0401930C RID: 103180
		internal static int __PropertyOffset_0;

		// Token: 0x0401930D RID: 103181
		internal static int __PropertyOffset_1;

		// Token: 0x0401930E RID: 103182
		internal static int __PropertyOffset_2;

		// Token: 0x0401930F RID: 103183
		internal static int __PropertyOffset_3;

		// Token: 0x04019310 RID: 103184
		internal static int __PropertyOffset_4;

		// Token: 0x04019311 RID: 103185
		internal static int __PropertyOffset_5;

		// Token: 0x04019312 RID: 103186
		internal static int __PropertyOffset_6;

		// Token: 0x04019313 RID: 103187
		internal static int __PropertyOffset_7;

		// Token: 0x04019314 RID: 103188
		internal static int __PropertyOffset_8;

		// Token: 0x04019315 RID: 103189
		internal static int __PropertyOffset_9;

		// Token: 0x04019316 RID: 103190
		internal static int __PropertyOffset_10;

		// Token: 0x04019317 RID: 103191
		internal static int __PropertyOffset_11;

		// Token: 0x04019318 RID: 103192
		internal static int __PropertyOffset_12;

		// Token: 0x04019319 RID: 103193
		internal static int __PropertyOffset_13;

		// Token: 0x0401931A RID: 103194
		internal static int __PropertyOffset_14;

		// Token: 0x0401931B RID: 103195
		internal static int __PropertyOffset_15;

		// Token: 0x0401931C RID: 103196
		internal static int __PropertyOffset_16;

		// Token: 0x0401931D RID: 103197
		internal static int __PropertyOffset_17;

		// Token: 0x0401931E RID: 103198
		internal static int __PropertyOffset_18;

		// Token: 0x0401931F RID: 103199
		internal static int __PropertyOffset_19;

		// Token: 0x04019320 RID: 103200
		internal static int __PropertyOffset_20;
	}
}
