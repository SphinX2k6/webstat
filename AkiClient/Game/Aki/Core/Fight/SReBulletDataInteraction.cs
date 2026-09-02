using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;

namespace AkiClient.Game.Aki.Core.Fight
{
	// Token: 0x02003F72 RID: 16242
	[NullableContext(1)]
	[Nullable(0)]
	[HasGetTypeHash]
	[UnrealObjectPath("/Game/Aki/Core/Fight/SReBulletDataInteraction.SReBulletDataInteraction")]
	[UnrealStructLayout(96, 8, UnrealReflectionPropertyTypeCode.UnrealScriptStructProxy, PropertiesSize = 96)]
	public class SReBulletDataInteraction : UnrealUserDefinedStructProxy, IUnrealScriptStructProxy, IUnrealScriptStruct, IUnrealObject
	{
		// Token: 0x0602894C RID: 166220 RVA: 0x00A0F734 File Offset: 0x00A0D934
		public static UScriptStructStackOnlyPtr StaticStruct()
		{
			return (SReBulletDataInteraction._ScriptStructPtr != 0) ? SReBulletDataInteraction._ScriptStructPtr : UObjectGlobals.StaticLoadScriptStruct("/Game/Aki/Core/Fight/SReBulletDataInteraction.SReBulletDataInteraction", ref SReBulletDataInteraction._ScriptStructPtr);
		}

		// Token: 0x170062FE RID: 25342
		// (get) Token: 0x0602894D RID: 166221 RVA: 0x00A0F758 File Offset: 0x00A0D958
		// (set) Token: 0x0602894E RID: 166222 RVA: 0x00A0F777 File Offset: 0x00A0D977
		public TSoftObjectPtr<BulletSceneInteraction_C> 水面交互
		{
			get
			{
				return new TSoftObjectPtr<BulletSceneInteraction_C>(base.NativePtr + (IntPtr)SReBulletDataInteraction.__PropertyOffset_0, base.MemoryOwner ?? this);
			}
			set
			{
				FSoftObjectPtr.NativeCopy(base.NativePtr + (IntPtr)SReBulletDataInteraction.__PropertyOffset_0, (value != null) ? value.NativePtr : IntPtr.Zero, 1);
			}
		}

		// Token: 0x170062FF RID: 25343
		// (get) Token: 0x0602894F RID: 166223 RVA: 0x00A0F79C File Offset: 0x00A0D99C
		// (set) Token: 0x06028950 RID: 166224 RVA: 0x00A0F7BB File Offset: 0x00A0D9BB
		public TSoftObjectPtr<BP_SceneBattleInteract_C> 场景物件交互
		{
			get
			{
				return new TSoftObjectPtr<BP_SceneBattleInteract_C>(base.NativePtr + (IntPtr)SReBulletDataInteraction.__PropertyOffset_1, base.MemoryOwner ?? this);
			}
			set
			{
				FSoftObjectPtr.NativeCopy(base.NativePtr + (IntPtr)SReBulletDataInteraction.__PropertyOffset_1, (value != null) ? value.NativePtr : IntPtr.Zero, 1);
			}
		}

		// Token: 0x06028951 RID: 166225 RVA: 0x00A0F7E0 File Offset: 0x00A0D9E0
		public SReBulletDataInteraction()
		{
		}

		// Token: 0x06028952 RID: 166226 RVA: 0x00A0F7E8 File Offset: 0x00A0D9E8
		public SReBulletDataInteraction(TSoftObjectPtr<BulletSceneInteraction_C> 水面交互, TSoftObjectPtr<BP_SceneBattleInteract_C> 场景物件交互)
		{
			this.水面交互 = 水面交互;
			this.场景物件交互 = 场景物件交互;
		}

		// Token: 0x06028953 RID: 166227 RVA: 0x00A0F7FE File Offset: 0x00A0D9FE
		protected override IntPtr GetUStructPtr()
		{
			return SReBulletDataInteraction.StaticStruct();
		}

		// Token: 0x06028954 RID: 166228 RVA: 0x00A0F80A File Offset: 0x00A0DA0A
		[NullableContext(2)]
		public SReBulletDataInteraction(IntPtr NativePtr, UnrealObject MemoryOwner) : base(NativePtr, MemoryOwner)
		{
		}

		// Token: 0x06028955 RID: 166229 RVA: 0x00A0F814 File Offset: 0x00A0DA14
		public SReBulletDataInteraction(IntPtr NativePtr, bool bWithMoveAssign, bool bWithCopyAssignIfCannotMove) : base(NativePtr, bWithMoveAssign, bWithCopyAssignIfCannotMove)
		{
		}

		// Token: 0x06028956 RID: 166230 RVA: 0x00A0F81F File Offset: 0x00A0DA1F
		public static IUnrealScriptStructProxy CreateFromPointer(IntPtr Pointer)
		{
			return new SReBulletDataInteraction(Pointer, false, true);
		}

		// Token: 0x06028957 RID: 166231 RVA: 0x00A0F829 File Offset: 0x00A0DA29
		public static IUnrealScriptStructProxy CreateReferenceFromPointer(IntPtr Pointer, UnrealObject MemoryOwner)
		{
			return new SReBulletDataInteraction(Pointer, MemoryOwner);
		}

		// Token: 0x0401566D RID: 87661
		public const string __ObjectPath = "/Game/Aki/Core/Fight/SReBulletDataInteraction.SReBulletDataInteraction";

		// Token: 0x0401566E RID: 87662
		private static IntPtr _ScriptStructPtr;

		// Token: 0x0401566F RID: 87663
		internal static int __PropertyOffset_0;

		// Token: 0x04015670 RID: 87664
		internal static int __PropertyOffset_1;
	}
}
