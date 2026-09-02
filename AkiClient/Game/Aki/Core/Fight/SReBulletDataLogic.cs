using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;

namespace AkiClient.Game.Aki.Core.Fight
{
	// Token: 0x02003F73 RID: 16243
	[NullableContext(1)]
	[Nullable(0)]
	[HasGetTypeHash]
	[UnrealObjectPath("/Game/Aki/Core/Fight/SReBulletDataLogic.SReBulletDataLogic")]
	[UnrealStructLayout(48, 8, UnrealReflectionPropertyTypeCode.UnrealScriptStructProxy, PropertiesSize = 48)]
	public class SReBulletDataLogic : UnrealUserDefinedStructProxy, IUnrealScriptStructProxy, IUnrealScriptStruct, IUnrealObject
	{
		// Token: 0x06028958 RID: 166232 RVA: 0x00A0F832 File Offset: 0x00A0DA32
		public static UScriptStructStackOnlyPtr StaticStruct()
		{
			return (SReBulletDataLogic._ScriptStructPtr != 0) ? SReBulletDataLogic._ScriptStructPtr : UObjectGlobals.StaticLoadScriptStruct("/Game/Aki/Core/Fight/SReBulletDataLogic.SReBulletDataLogic", ref SReBulletDataLogic._ScriptStructPtr);
		}

		// Token: 0x17006300 RID: 25344
		// (get) Token: 0x06028959 RID: 166233 RVA: 0x00A0F856 File Offset: 0x00A0DA56
		// (set) Token: 0x0602895A RID: 166234 RVA: 0x00A0F875 File Offset: 0x00A0DA75
		public TSoftObjectPtr<BulletLogicType_C> 预设
		{
			get
			{
				return new TSoftObjectPtr<BulletLogicType_C>(base.NativePtr + (IntPtr)SReBulletDataLogic.__PropertyOffset_0, base.MemoryOwner ?? this);
			}
			set
			{
				FSoftObjectPtr.NativeCopy(base.NativePtr + (IntPtr)SReBulletDataLogic.__PropertyOffset_0, (value != null) ? value.NativePtr : IntPtr.Zero, 1);
			}
		}

		// Token: 0x0602895B RID: 166235 RVA: 0x00A0F89A File Offset: 0x00A0DA9A
		public SReBulletDataLogic()
		{
		}

		// Token: 0x0602895C RID: 166236 RVA: 0x00A0F8A2 File Offset: 0x00A0DAA2
		public SReBulletDataLogic(TSoftObjectPtr<BulletLogicType_C> 预设)
		{
			this.预设 = 预设;
		}

		// Token: 0x0602895D RID: 166237 RVA: 0x00A0F8B1 File Offset: 0x00A0DAB1
		protected override IntPtr GetUStructPtr()
		{
			return SReBulletDataLogic.StaticStruct();
		}

		// Token: 0x0602895E RID: 166238 RVA: 0x00A0F8BD File Offset: 0x00A0DABD
		[NullableContext(2)]
		public SReBulletDataLogic(IntPtr NativePtr, UnrealObject MemoryOwner) : base(NativePtr, MemoryOwner)
		{
		}

		// Token: 0x0602895F RID: 166239 RVA: 0x00A0F8C7 File Offset: 0x00A0DAC7
		public SReBulletDataLogic(IntPtr NativePtr, bool bWithMoveAssign, bool bWithCopyAssignIfCannotMove) : base(NativePtr, bWithMoveAssign, bWithCopyAssignIfCannotMove)
		{
		}

		// Token: 0x06028960 RID: 166240 RVA: 0x00A0F8D2 File Offset: 0x00A0DAD2
		public static IUnrealScriptStructProxy CreateFromPointer(IntPtr Pointer)
		{
			return new SReBulletDataLogic(Pointer, false, true);
		}

		// Token: 0x06028961 RID: 166241 RVA: 0x00A0F8DC File Offset: 0x00A0DADC
		public static IUnrealScriptStructProxy CreateReferenceFromPointer(IntPtr Pointer, UnrealObject MemoryOwner)
		{
			return new SReBulletDataLogic(Pointer, MemoryOwner);
		}

		// Token: 0x04015671 RID: 87665
		public const string __ObjectPath = "/Game/Aki/Core/Fight/SReBulletDataLogic.SReBulletDataLogic";

		// Token: 0x04015672 RID: 87666
		private static IntPtr _ScriptStructPtr;

		// Token: 0x04015673 RID: 87667
		internal static int __PropertyOffset_0;
	}
}
