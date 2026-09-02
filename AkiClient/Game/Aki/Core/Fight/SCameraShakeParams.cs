using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;

namespace AkiClient.Game.Aki.Core.Fight
{
	// Token: 0x02003F6C RID: 16236
	[HasGetTypeHash]
	[UnrealObjectPath("/Game/Aki/Core/Fight/SCameraShakeParams.SCameraShakeParams")]
	[UnrealStructLayout(16, 8, UnrealReflectionPropertyTypeCode.UnrealScriptStructProxy, PropertiesSize = 16)]
	public class SCameraShakeParams : UnrealUserDefinedStructProxy, IUnrealScriptStructProxy, IUnrealScriptStruct, IUnrealObject
	{
		// Token: 0x06028894 RID: 166036 RVA: 0x00A0E530 File Offset: 0x00A0C730
		public static UScriptStructStackOnlyPtr StaticStruct()
		{
			return (SCameraShakeParams._ScriptStructPtr != 0) ? SCameraShakeParams._ScriptStructPtr : UObjectGlobals.StaticLoadScriptStruct("/Game/Aki/Core/Fight/SCameraShakeParams.SCameraShakeParams", ref SCameraShakeParams._ScriptStructPtr);
		}

		// Token: 0x170062B9 RID: 25273
		// (get) Token: 0x06028895 RID: 166037 RVA: 0x00A0E554 File Offset: 0x00A0C754
		// (set) Token: 0x06028896 RID: 166038 RVA: 0x00A0E568 File Offset: 0x00A0C768
		[Nullable(new byte[]
		{
			0,
			1
		})]
		public unsafe TSubclassOf<UCameraShakeBase> 震屏配置
		{
			[return: Nullable(new byte[]
			{
				0,
				1
			})]
			get
			{
				return *(base.NativePtr + (IntPtr)SCameraShakeParams.__PropertyOffset_0);
			}
			[param: Nullable(new byte[]
			{
				0,
				1
			})]
			set
			{
				*(base.NativePtr + (IntPtr)SCameraShakeParams.__PropertyOffset_0) = value;
			}
		}

		// Token: 0x170062BA RID: 25274
		// (get) Token: 0x06028897 RID: 166039 RVA: 0x00A0E57D File Offset: 0x00A0C77D
		// (set) Token: 0x06028898 RID: 166040 RVA: 0x00A0E58D File Offset: 0x00A0C78D
		public unsafe bool bForSelf
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SCameraShakeParams.__PropertyOffset_1) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)SCameraShakeParams.__PropertyOffset_1) = (value ? 1 : 0);
			}
		}

		// Token: 0x170062BB RID: 25275
		// (get) Token: 0x06028899 RID: 166041 RVA: 0x00A0E59E File Offset: 0x00A0C79E
		// (set) Token: 0x0602889A RID: 166042 RVA: 0x00A0E5AE File Offset: 0x00A0C7AE
		public unsafe float 衰减极限距离
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SCameraShakeParams.__PropertyOffset_2);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SCameraShakeParams.__PropertyOffset_2) = value;
			}
		}

		// Token: 0x0602889B RID: 166043 RVA: 0x00A0E5BF File Offset: 0x00A0C7BF
		public SCameraShakeParams()
		{
		}

		// Token: 0x0602889C RID: 166044 RVA: 0x00A0E5C7 File Offset: 0x00A0C7C7
		public SCameraShakeParams([Nullable(new byte[]
		{
			0,
			1
		})] TSubclassOf<UCameraShakeBase> 震屏配置, bool bForSelf, float 衰减极限距离)
		{
			this.震屏配置 = 震屏配置;
			this.bForSelf = bForSelf;
			this.衰减极限距离 = 衰减极限距离;
		}

		// Token: 0x0602889D RID: 166045 RVA: 0x00A0E5E4 File Offset: 0x00A0C7E4
		protected override IntPtr GetUStructPtr()
		{
			return SCameraShakeParams.StaticStruct();
		}

		// Token: 0x0602889E RID: 166046 RVA: 0x00A0E5F0 File Offset: 0x00A0C7F0
		[NullableContext(2)]
		public SCameraShakeParams(IntPtr NativePtr, UnrealObject MemoryOwner) : base(NativePtr, MemoryOwner)
		{
		}

		// Token: 0x0602889F RID: 166047 RVA: 0x00A0E5FA File Offset: 0x00A0C7FA
		public SCameraShakeParams(IntPtr NativePtr, bool bWithMoveAssign, bool bWithCopyAssignIfCannotMove) : base(NativePtr, bWithMoveAssign, bWithCopyAssignIfCannotMove)
		{
		}

		// Token: 0x060288A0 RID: 166048 RVA: 0x00A0E605 File Offset: 0x00A0C805
		[NullableContext(1)]
		public static IUnrealScriptStructProxy CreateFromPointer(IntPtr Pointer)
		{
			return new SCameraShakeParams(Pointer, false, true);
		}

		// Token: 0x060288A1 RID: 166049 RVA: 0x00A0E60F File Offset: 0x00A0C80F
		[NullableContext(1)]
		public static IUnrealScriptStructProxy CreateReferenceFromPointer(IntPtr Pointer, UnrealObject MemoryOwner)
		{
			return new SCameraShakeParams(Pointer, MemoryOwner);
		}

		// Token: 0x04015609 RID: 87561
		[Nullable(1)]
		public const string __ObjectPath = "/Game/Aki/Core/Fight/SCameraShakeParams.SCameraShakeParams";

		// Token: 0x0401560A RID: 87562
		private static IntPtr _ScriptStructPtr;

		// Token: 0x0401560B RID: 87563
		internal static int __PropertyOffset_0;

		// Token: 0x0401560C RID: 87564
		internal static int __PropertyOffset_1;

		// Token: 0x0401560D RID: 87565
		internal static int __PropertyOffset_2;
	}
}
