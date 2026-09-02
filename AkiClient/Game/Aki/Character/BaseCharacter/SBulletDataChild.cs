using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;

namespace AkiClient.Game.Aki.Character.BaseCharacter
{
	// Token: 0x0200423F RID: 16959
	[HasGetTypeHash]
	[UnrealObjectPath("/Game/Aki/Character/BaseCharacter/SBulletDataChild.SBulletDataChild")]
	[UnrealStructLayout(24, 8, UnrealReflectionPropertyTypeCode.UnrealScriptStructProxy, PropertiesSize = 21)]
	public class SBulletDataChild : UnrealUserDefinedStructProxy, IUnrealScriptStructProxy, IUnrealScriptStruct, IUnrealObject
	{
		// Token: 0x0602CE05 RID: 183813 RVA: 0x00AB225C File Offset: 0x00AB045C
		public static UScriptStructStackOnlyPtr StaticStruct()
		{
			return (SBulletDataChild._ScriptStructPtr != 0) ? SBulletDataChild._ScriptStructPtr : UObjectGlobals.StaticLoadScriptStruct("/Game/Aki/Character/BaseCharacter/SBulletDataChild.SBulletDataChild", ref SBulletDataChild._ScriptStructPtr);
		}

		// Token: 0x1700797B RID: 31099
		// (get) Token: 0x0602CE06 RID: 183814 RVA: 0x00AB2280 File Offset: 0x00AB0480
		// (set) Token: 0x0602CE07 RID: 183815 RVA: 0x00AB2290 File Offset: 0x00AB0490
		public unsafe long 召唤子弹ID
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SBulletDataChild.__PropertyOffset_0);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SBulletDataChild.__PropertyOffset_0) = value;
			}
		}

		// Token: 0x1700797C RID: 31100
		// (get) Token: 0x0602CE08 RID: 183816 RVA: 0x00AB22A1 File Offset: 0x00AB04A1
		// (set) Token: 0x0602CE09 RID: 183817 RVA: 0x00AB22B1 File Offset: 0x00AB04B1
		public unsafe float 召唤子弹延迟
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SBulletDataChild.__PropertyOffset_1);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SBulletDataChild.__PropertyOffset_1) = value;
			}
		}

		// Token: 0x1700797D RID: 31101
		// (get) Token: 0x0602CE0A RID: 183818 RVA: 0x00AB22C2 File Offset: 0x00AB04C2
		// (set) Token: 0x0602CE0B RID: 183819 RVA: 0x00AB22D2 File Offset: 0x00AB04D2
		public unsafe int 召唤子弹数量
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SBulletDataChild.__PropertyOffset_2);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SBulletDataChild.__PropertyOffset_2) = value;
			}
		}

		// Token: 0x1700797E RID: 31102
		// (get) Token: 0x0602CE0C RID: 183820 RVA: 0x00AB22E3 File Offset: 0x00AB04E3
		// (set) Token: 0x0602CE0D RID: 183821 RVA: 0x00AB22F3 File Offset: 0x00AB04F3
		public unsafe float 召唤子弹间隔
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SBulletDataChild.__PropertyOffset_3);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SBulletDataChild.__PropertyOffset_3) = value;
			}
		}

		// Token: 0x1700797F RID: 31103
		// (get) Token: 0x0602CE0E RID: 183822 RVA: 0x00AB2304 File Offset: 0x00AB0504
		// (set) Token: 0x0602CE0F RID: 183823 RVA: 0x00AB2314 File Offset: 0x00AB0514
		public unsafe bool 销毁时生成子弹
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SBulletDataChild.__PropertyOffset_4) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)SBulletDataChild.__PropertyOffset_4) = (value ? 1 : 0);
			}
		}

		// Token: 0x0602CE10 RID: 183824 RVA: 0x00AB2325 File Offset: 0x00AB0525
		public SBulletDataChild()
		{
		}

		// Token: 0x0602CE11 RID: 183825 RVA: 0x00AB232D File Offset: 0x00AB052D
		public SBulletDataChild(long 召唤子弹ID, float 召唤子弹延迟, int 召唤子弹数量, float 召唤子弹间隔, bool 销毁时生成子弹)
		{
			this.召唤子弹ID = 召唤子弹ID;
			this.召唤子弹延迟 = 召唤子弹延迟;
			this.召唤子弹数量 = 召唤子弹数量;
			this.召唤子弹间隔 = 召唤子弹间隔;
			this.销毁时生成子弹 = 销毁时生成子弹;
		}

		// Token: 0x0602CE12 RID: 183826 RVA: 0x00AB235A File Offset: 0x00AB055A
		protected override IntPtr GetUStructPtr()
		{
			return SBulletDataChild.StaticStruct();
		}

		// Token: 0x0602CE13 RID: 183827 RVA: 0x00AB2366 File Offset: 0x00AB0566
		[NullableContext(2)]
		public SBulletDataChild(IntPtr NativePtr, UnrealObject MemoryOwner) : base(NativePtr, MemoryOwner)
		{
		}

		// Token: 0x0602CE14 RID: 183828 RVA: 0x00AB2370 File Offset: 0x00AB0570
		public SBulletDataChild(IntPtr NativePtr, bool bWithMoveAssign, bool bWithCopyAssignIfCannotMove) : base(NativePtr, bWithMoveAssign, bWithCopyAssignIfCannotMove)
		{
		}

		// Token: 0x0602CE15 RID: 183829 RVA: 0x00AB237B File Offset: 0x00AB057B
		[NullableContext(1)]
		public static IUnrealScriptStructProxy CreateFromPointer(IntPtr Pointer)
		{
			return new SBulletDataChild(Pointer, false, true);
		}

		// Token: 0x0602CE16 RID: 183830 RVA: 0x00AB2385 File Offset: 0x00AB0585
		[NullableContext(1)]
		public static IUnrealScriptStructProxy CreateReferenceFromPointer(IntPtr Pointer, UnrealObject MemoryOwner)
		{
			return new SBulletDataChild(Pointer, MemoryOwner);
		}

		// Token: 0x040192DA RID: 103130
		[Nullable(1)]
		public const string __ObjectPath = "/Game/Aki/Character/BaseCharacter/SBulletDataChild.SBulletDataChild";

		// Token: 0x040192DB RID: 103131
		private static IntPtr _ScriptStructPtr;

		// Token: 0x040192DC RID: 103132
		internal static int __PropertyOffset_0;

		// Token: 0x040192DD RID: 103133
		internal static int __PropertyOffset_1;

		// Token: 0x040192DE RID: 103134
		internal static int __PropertyOffset_2;

		// Token: 0x040192DF RID: 103135
		internal static int __PropertyOffset_3;

		// Token: 0x040192E0 RID: 103136
		internal static int __PropertyOffset_4;
	}
}
