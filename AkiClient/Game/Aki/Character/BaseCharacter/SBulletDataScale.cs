using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Character.BaseCharacter
{
	// Token: 0x02004245 RID: 16965
	[HasGetTypeHash]
	[UnrealObjectPath("/Game/Aki/Character/BaseCharacter/SBulletDataScale.SBulletDataScale")]
	[UnrealStructLayout(24, 8, UnrealReflectionPropertyTypeCode.UnrealScriptStructProxy, PropertiesSize = 24)]
	public class SBulletDataScale : UnrealUserDefinedStructProxy, IUnrealScriptStructProxy, IUnrealScriptStruct, IUnrealObject
	{
		// Token: 0x0602CE93 RID: 183955 RVA: 0x00AB2FFC File Offset: 0x00AB11FC
		public static UScriptStructStackOnlyPtr StaticStruct()
		{
			return (SBulletDataScale._ScriptStructPtr != 0) ? SBulletDataScale._ScriptStructPtr : UObjectGlobals.StaticLoadScriptStruct("/Game/Aki/Character/BaseCharacter/SBulletDataScale.SBulletDataScale", ref SBulletDataScale._ScriptStructPtr);
		}

		// Token: 0x170079AA RID: 31146
		// (get) Token: 0x0602CE94 RID: 183956 RVA: 0x00AB3020 File Offset: 0x00AB1220
		// (set) Token: 0x0602CE95 RID: 183957 RVA: 0x00AB3034 File Offset: 0x00AB1234
		public unsafe FVector 缩放倍率
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SBulletDataScale.__PropertyOffset_0);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SBulletDataScale.__PropertyOffset_0) = value;
			}
		}

		// Token: 0x170079AB RID: 31147
		// (get) Token: 0x0602CE96 RID: 183958 RVA: 0x00AB3049 File Offset: 0x00AB1249
		// (set) Token: 0x0602CE97 RID: 183959 RVA: 0x00AB305D File Offset: 0x00AB125D
		[Nullable(2)]
		public unsafe UCurveVector 缩放倍率曲线
		{
			[NullableContext(2)]
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UCurveVector>(base.NativePtr / (IntPtr)sizeof(void*) + SBulletDataScale.__PropertyOffset_1);
			}
			[NullableContext(2)]
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + SBulletDataScale.__PropertyOffset_1, value);
			}
		}

		// Token: 0x0602CE98 RID: 183960 RVA: 0x00AB3072 File Offset: 0x00AB1272
		public SBulletDataScale()
		{
		}

		// Token: 0x0602CE99 RID: 183961 RVA: 0x00AB307A File Offset: 0x00AB127A
		[NullableContext(1)]
		public SBulletDataScale(FVector 缩放倍率, UCurveVector 缩放倍率曲线)
		{
			this.缩放倍率 = 缩放倍率;
			this.缩放倍率曲线 = 缩放倍率曲线;
		}

		// Token: 0x0602CE9A RID: 183962 RVA: 0x00AB3090 File Offset: 0x00AB1290
		protected override IntPtr GetUStructPtr()
		{
			return SBulletDataScale.StaticStruct();
		}

		// Token: 0x0602CE9B RID: 183963 RVA: 0x00AB309C File Offset: 0x00AB129C
		[NullableContext(2)]
		public SBulletDataScale(IntPtr NativePtr, UnrealObject MemoryOwner) : base(NativePtr, MemoryOwner)
		{
		}

		// Token: 0x0602CE9C RID: 183964 RVA: 0x00AB30A6 File Offset: 0x00AB12A6
		public SBulletDataScale(IntPtr NativePtr, bool bWithMoveAssign, bool bWithCopyAssignIfCannotMove) : base(NativePtr, bWithMoveAssign, bWithCopyAssignIfCannotMove)
		{
		}

		// Token: 0x0602CE9D RID: 183965 RVA: 0x00AB30B1 File Offset: 0x00AB12B1
		[NullableContext(1)]
		public static IUnrealScriptStructProxy CreateFromPointer(IntPtr Pointer)
		{
			return new SBulletDataScale(Pointer, false, true);
		}

		// Token: 0x0602CE9E RID: 183966 RVA: 0x00AB30BB File Offset: 0x00AB12BB
		[NullableContext(1)]
		public static IUnrealScriptStructProxy CreateReferenceFromPointer(IntPtr Pointer, UnrealObject MemoryOwner)
		{
			return new SBulletDataScale(Pointer, MemoryOwner);
		}

		// Token: 0x04019321 RID: 103201
		[Nullable(1)]
		public const string __ObjectPath = "/Game/Aki/Character/BaseCharacter/SBulletDataScale.SBulletDataScale";

		// Token: 0x04019322 RID: 103202
		private static IntPtr _ScriptStructPtr;

		// Token: 0x04019323 RID: 103203
		internal static int __PropertyOffset_0;

		// Token: 0x04019324 RID: 103204
		internal static int __PropertyOffset_1;
	}
}
