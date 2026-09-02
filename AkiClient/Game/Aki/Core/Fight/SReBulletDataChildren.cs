using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;

namespace AkiClient.Game.Aki.Core.Fight
{
	// Token: 0x02003F6F RID: 16239
	[HasGetTypeHash]
	[UnrealObjectPath("/Game/Aki/Core/Fight/SReBulletDataChildren.SReBulletDataChildren")]
	[UnrealStructLayout(24, 8, UnrealReflectionPropertyTypeCode.UnrealScriptStructProxy, PropertiesSize = 22)]
	public class SReBulletDataChildren : UnrealUserDefinedStructProxy, IUnrealScriptStructProxy, IUnrealScriptStruct, IUnrealObject
	{
		// Token: 0x06028911 RID: 166161 RVA: 0x00A0F148 File Offset: 0x00A0D348
		public static UScriptStructStackOnlyPtr StaticStruct()
		{
			return (SReBulletDataChildren._ScriptStructPtr != 0) ? SReBulletDataChildren._ScriptStructPtr : UObjectGlobals.StaticLoadScriptStruct("/Game/Aki/Core/Fight/SReBulletDataChildren.SReBulletDataChildren", ref SReBulletDataChildren._ScriptStructPtr);
		}

		// Token: 0x170062EC RID: 25324
		// (get) Token: 0x06028912 RID: 166162 RVA: 0x00A0F16C File Offset: 0x00A0D36C
		// (set) Token: 0x06028913 RID: 166163 RVA: 0x00A0F17C File Offset: 0x00A0D37C
		public unsafe long 召唤子弹ID
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SReBulletDataChildren.__PropertyOffset_0);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SReBulletDataChildren.__PropertyOffset_0) = value;
			}
		}

		// Token: 0x170062ED RID: 25325
		// (get) Token: 0x06028914 RID: 166164 RVA: 0x00A0F18D File Offset: 0x00A0D38D
		// (set) Token: 0x06028915 RID: 166165 RVA: 0x00A0F19D File Offset: 0x00A0D39D
		public unsafe float 召唤子弹延迟
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SReBulletDataChildren.__PropertyOffset_1);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SReBulletDataChildren.__PropertyOffset_1) = value;
			}
		}

		// Token: 0x170062EE RID: 25326
		// (get) Token: 0x06028916 RID: 166166 RVA: 0x00A0F1AE File Offset: 0x00A0D3AE
		// (set) Token: 0x06028917 RID: 166167 RVA: 0x00A0F1BE File Offset: 0x00A0D3BE
		public unsafe int 召唤子弹数量
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SReBulletDataChildren.__PropertyOffset_2);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SReBulletDataChildren.__PropertyOffset_2) = value;
			}
		}

		// Token: 0x170062EF RID: 25327
		// (get) Token: 0x06028918 RID: 166168 RVA: 0x00A0F1CF File Offset: 0x00A0D3CF
		// (set) Token: 0x06028919 RID: 166169 RVA: 0x00A0F1DF File Offset: 0x00A0D3DF
		public unsafe float 召唤子弹间隔
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SReBulletDataChildren.__PropertyOffset_3);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SReBulletDataChildren.__PropertyOffset_3) = value;
			}
		}

		// Token: 0x170062F0 RID: 25328
		// (get) Token: 0x0602891A RID: 166170 RVA: 0x00A0F1F0 File Offset: 0x00A0D3F0
		// (set) Token: 0x0602891B RID: 166171 RVA: 0x00A0F204 File Offset: 0x00A0D404
		public unsafe TEnumAsByte<EBulletChildrenType> 召唤触发
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SReBulletDataChildren.__PropertyOffset_4);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SReBulletDataChildren.__PropertyOffset_4) = value;
			}
		}

		// Token: 0x170062F1 RID: 25329
		// (get) Token: 0x0602891C RID: 166172 RVA: 0x00A0F219 File Offset: 0x00A0D419
		// (set) Token: 0x0602891D RID: 166173 RVA: 0x00A0F229 File Offset: 0x00A0D429
		public unsafe bool 失败是否停止
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SReBulletDataChildren.__PropertyOffset_5) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)SReBulletDataChildren.__PropertyOffset_5) = (value ? 1 : 0);
			}
		}

		// Token: 0x0602891E RID: 166174 RVA: 0x00A0F23A File Offset: 0x00A0D43A
		public SReBulletDataChildren()
		{
		}

		// Token: 0x0602891F RID: 166175 RVA: 0x00A0F242 File Offset: 0x00A0D442
		public SReBulletDataChildren(long 召唤子弹ID, float 召唤子弹延迟, int 召唤子弹数量, float 召唤子弹间隔, TEnumAsByte<EBulletChildrenType> 召唤触发, bool 失败是否停止)
		{
			this.召唤子弹ID = 召唤子弹ID;
			this.召唤子弹延迟 = 召唤子弹延迟;
			this.召唤子弹数量 = 召唤子弹数量;
			this.召唤子弹间隔 = 召唤子弹间隔;
			this.召唤触发 = 召唤触发;
			this.失败是否停止 = 失败是否停止;
		}

		// Token: 0x06028920 RID: 166176 RVA: 0x00A0F277 File Offset: 0x00A0D477
		protected override IntPtr GetUStructPtr()
		{
			return SReBulletDataChildren.StaticStruct();
		}

		// Token: 0x06028921 RID: 166177 RVA: 0x00A0F283 File Offset: 0x00A0D483
		[NullableContext(2)]
		public SReBulletDataChildren(IntPtr NativePtr, UnrealObject MemoryOwner) : base(NativePtr, MemoryOwner)
		{
		}

		// Token: 0x06028922 RID: 166178 RVA: 0x00A0F28D File Offset: 0x00A0D48D
		public SReBulletDataChildren(IntPtr NativePtr, bool bWithMoveAssign, bool bWithCopyAssignIfCannotMove) : base(NativePtr, bWithMoveAssign, bWithCopyAssignIfCannotMove)
		{
		}

		// Token: 0x06028923 RID: 166179 RVA: 0x00A0F298 File Offset: 0x00A0D498
		[NullableContext(1)]
		public static IUnrealScriptStructProxy CreateFromPointer(IntPtr Pointer)
		{
			return new SReBulletDataChildren(Pointer, false, true);
		}

		// Token: 0x06028924 RID: 166180 RVA: 0x00A0F2A2 File Offset: 0x00A0D4A2
		[NullableContext(1)]
		public static IUnrealScriptStructProxy CreateReferenceFromPointer(IntPtr Pointer, UnrealObject MemoryOwner)
		{
			return new SReBulletDataChildren(Pointer, MemoryOwner);
		}

		// Token: 0x0401564D RID: 87629
		[Nullable(1)]
		public const string __ObjectPath = "/Game/Aki/Core/Fight/SReBulletDataChildren.SReBulletDataChildren";

		// Token: 0x0401564E RID: 87630
		private static IntPtr _ScriptStructPtr;

		// Token: 0x0401564F RID: 87631
		internal static int __PropertyOffset_0;

		// Token: 0x04015650 RID: 87632
		internal static int __PropertyOffset_1;

		// Token: 0x04015651 RID: 87633
		internal static int __PropertyOffset_2;

		// Token: 0x04015652 RID: 87634
		internal static int __PropertyOffset_3;

		// Token: 0x04015653 RID: 87635
		internal static int __PropertyOffset_4;

		// Token: 0x04015654 RID: 87636
		internal static int __PropertyOffset_5;
	}
}
