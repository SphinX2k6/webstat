using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Character.BaseCharacter
{
	// Token: 0x0200425A RID: 16986
	[HasGetTypeHash]
	[UnrealObjectPath("/Game/Aki/Character/BaseCharacter/SDynamicMontageParams.SDynamicMontageParams")]
	[UnrealStructLayout(24, 8, UnrealReflectionPropertyTypeCode.UnrealScriptStructProxy, PropertiesSize = 24)]
	public class SDynamicMontageParams : UnrealUserDefinedStructProxy, IUnrealScriptStructProxy, IUnrealScriptStruct, IUnrealObject
	{
		// Token: 0x0602D013 RID: 184339 RVA: 0x00AB53DC File Offset: 0x00AB35DC
		public static UScriptStructStackOnlyPtr StaticStruct()
		{
			return (SDynamicMontageParams._ScriptStructPtr != 0) ? SDynamicMontageParams._ScriptStructPtr : UObjectGlobals.StaticLoadScriptStruct("/Game/Aki/Character/BaseCharacter/SDynamicMontageParams.SDynamicMontageParams", ref SDynamicMontageParams._ScriptStructPtr);
		}

		// Token: 0x17007A18 RID: 31256
		// (get) Token: 0x0602D014 RID: 184340 RVA: 0x00AB5400 File Offset: 0x00AB3600
		// (set) Token: 0x0602D015 RID: 184341 RVA: 0x00AB5414 File Offset: 0x00AB3614
		[Nullable(2)]
		public unsafe UAnimSequenceBase 动画
		{
			[NullableContext(2)]
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UAnimSequenceBase>(base.NativePtr / (IntPtr)sizeof(void*) + SDynamicMontageParams.__PropertyOffset_0);
			}
			[NullableContext(2)]
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + SDynamicMontageParams.__PropertyOffset_0, value);
			}
		}

		// Token: 0x17007A19 RID: 31257
		// (get) Token: 0x0602D016 RID: 184342 RVA: 0x00AB5429 File Offset: 0x00AB3629
		// (set) Token: 0x0602D017 RID: 184343 RVA: 0x00AB5439 File Offset: 0x00AB3639
		public unsafe float 进入融合时间
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SDynamicMontageParams.__PropertyOffset_1);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SDynamicMontageParams.__PropertyOffset_1) = value;
			}
		}

		// Token: 0x17007A1A RID: 31258
		// (get) Token: 0x0602D018 RID: 184344 RVA: 0x00AB544A File Offset: 0x00AB364A
		// (set) Token: 0x0602D019 RID: 184345 RVA: 0x00AB545A File Offset: 0x00AB365A
		public unsafe float 退出融合时间
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SDynamicMontageParams.__PropertyOffset_2);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SDynamicMontageParams.__PropertyOffset_2) = value;
			}
		}

		// Token: 0x17007A1B RID: 31259
		// (get) Token: 0x0602D01A RID: 184346 RVA: 0x00AB546B File Offset: 0x00AB366B
		// (set) Token: 0x0602D01B RID: 184347 RVA: 0x00AB547B File Offset: 0x00AB367B
		public unsafe float 播放速率
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SDynamicMontageParams.__PropertyOffset_3);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SDynamicMontageParams.__PropertyOffset_3) = value;
			}
		}

		// Token: 0x17007A1C RID: 31260
		// (get) Token: 0x0602D01C RID: 184348 RVA: 0x00AB548C File Offset: 0x00AB368C
		// (set) Token: 0x0602D01D RID: 184349 RVA: 0x00AB549C File Offset: 0x00AB369C
		public unsafe float 开始时间
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SDynamicMontageParams.__PropertyOffset_4);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SDynamicMontageParams.__PropertyOffset_4) = value;
			}
		}

		// Token: 0x0602D01E RID: 184350 RVA: 0x00AB54AD File Offset: 0x00AB36AD
		public SDynamicMontageParams()
		{
		}

		// Token: 0x0602D01F RID: 184351 RVA: 0x00AB54B5 File Offset: 0x00AB36B5
		[NullableContext(1)]
		public SDynamicMontageParams(UAnimSequenceBase 动画, float 进入融合时间, float 退出融合时间, float 播放速率, float 开始时间)
		{
			this.动画 = 动画;
			this.进入融合时间 = 进入融合时间;
			this.退出融合时间 = 退出融合时间;
			this.播放速率 = 播放速率;
			this.开始时间 = 开始时间;
		}

		// Token: 0x0602D020 RID: 184352 RVA: 0x00AB54E2 File Offset: 0x00AB36E2
		protected override IntPtr GetUStructPtr()
		{
			return SDynamicMontageParams.StaticStruct();
		}

		// Token: 0x0602D021 RID: 184353 RVA: 0x00AB54EE File Offset: 0x00AB36EE
		[NullableContext(2)]
		public SDynamicMontageParams(IntPtr NativePtr, UnrealObject MemoryOwner) : base(NativePtr, MemoryOwner)
		{
		}

		// Token: 0x0602D022 RID: 184354 RVA: 0x00AB54F8 File Offset: 0x00AB36F8
		public SDynamicMontageParams(IntPtr NativePtr, bool bWithMoveAssign, bool bWithCopyAssignIfCannotMove) : base(NativePtr, bWithMoveAssign, bWithCopyAssignIfCannotMove)
		{
		}

		// Token: 0x0602D023 RID: 184355 RVA: 0x00AB5503 File Offset: 0x00AB3703
		[NullableContext(1)]
		public static IUnrealScriptStructProxy CreateFromPointer(IntPtr Pointer)
		{
			return new SDynamicMontageParams(Pointer, false, true);
		}

		// Token: 0x0602D024 RID: 184356 RVA: 0x00AB550D File Offset: 0x00AB370D
		[NullableContext(1)]
		public static IUnrealScriptStructProxy CreateReferenceFromPointer(IntPtr Pointer, UnrealObject MemoryOwner)
		{
			return new SDynamicMontageParams(Pointer, MemoryOwner);
		}

		// Token: 0x040193E1 RID: 103393
		[Nullable(1)]
		public const string __ObjectPath = "/Game/Aki/Character/BaseCharacter/SDynamicMontageParams.SDynamicMontageParams";

		// Token: 0x040193E2 RID: 103394
		private static IntPtr _ScriptStructPtr;

		// Token: 0x040193E3 RID: 103395
		internal static int __PropertyOffset_0;

		// Token: 0x040193E4 RID: 103396
		internal static int __PropertyOffset_1;

		// Token: 0x040193E5 RID: 103397
		internal static int __PropertyOffset_2;

		// Token: 0x040193E6 RID: 103398
		internal static int __PropertyOffset_3;

		// Token: 0x040193E7 RID: 103399
		internal static int __PropertyOffset_4;
	}
}
