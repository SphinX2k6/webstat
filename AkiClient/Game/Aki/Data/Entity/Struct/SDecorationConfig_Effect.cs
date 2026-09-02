using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;

namespace AkiClient.Game.Aki.Data.Entity.Struct
{
	// Token: 0x02003EF2 RID: 16114
	[NullableContext(1)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Data/Entity/Struct/SDecorationConfig_Effect.SDecorationConfig_Effect")]
	[UnrealStructLayout(112, 16, UnrealReflectionPropertyTypeCode.UnrealScriptStructProxy, PropertiesSize = 112)]
	public class SDecorationConfig_Effect : UnrealUserDefinedStructProxy, IUnrealScriptStructProxy, IUnrealScriptStruct, IUnrealObject
	{
		// Token: 0x06028204 RID: 164356 RVA: 0x00A030B4 File Offset: 0x00A012B4
		public static UScriptStructStackOnlyPtr StaticStruct()
		{
			return (SDecorationConfig_Effect._ScriptStructPtr != 0) ? SDecorationConfig_Effect._ScriptStructPtr : UObjectGlobals.StaticLoadScriptStruct("/Game/Aki/Data/Entity/Struct/SDecorationConfig_Effect.SDecorationConfig_Effect", ref SDecorationConfig_Effect._ScriptStructPtr);
		}

		// Token: 0x170060A3 RID: 24739
		// (get) Token: 0x06028205 RID: 164357 RVA: 0x00A030D8 File Offset: 0x00A012D8
		// (set) Token: 0x06028206 RID: 164358 RVA: 0x00A030F7 File Offset: 0x00A012F7
		public TSoftObjectPtr<UEffectModelBase> EffectData
		{
			get
			{
				return new TSoftObjectPtr<UEffectModelBase>(base.NativePtr + (IntPtr)SDecorationConfig_Effect.__PropertyOffset_0, base.MemoryOwner ?? this);
			}
			set
			{
				FSoftObjectPtr.NativeCopy(base.NativePtr + (IntPtr)SDecorationConfig_Effect.__PropertyOffset_0, (value != null) ? value.NativePtr : IntPtr.Zero, 1);
			}
		}

		// Token: 0x170060A4 RID: 24740
		// (get) Token: 0x06028207 RID: 164359 RVA: 0x00A0311C File Offset: 0x00A0131C
		// (set) Token: 0x06028208 RID: 164360 RVA: 0x00A03130 File Offset: 0x00A01330
		public unsafe string EffectSocketName
		{
			get
			{
				return FString.ToString((void*)(base.NativePtr + (byte*)((IntPtr)SDecorationConfig_Effect.__PropertyOffset_1)));
			}
			set
			{
				FString.CopyFrom((void*)(base.NativePtr + (byte*)((IntPtr)SDecorationConfig_Effect.__PropertyOffset_1)), value);
			}
		}

		// Token: 0x170060A5 RID: 24741
		// (get) Token: 0x06028209 RID: 164361 RVA: 0x00A03145 File Offset: 0x00A01345
		// (set) Token: 0x0602820A RID: 164362 RVA: 0x00A03159 File Offset: 0x00A01359
		public unsafe FTransform EffectTrans
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SDecorationConfig_Effect.__PropertyOffset_2);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SDecorationConfig_Effect.__PropertyOffset_2) = value;
			}
		}

		// Token: 0x0602820B RID: 164363 RVA: 0x00A0316E File Offset: 0x00A0136E
		public SDecorationConfig_Effect()
		{
		}

		// Token: 0x0602820C RID: 164364 RVA: 0x00A03176 File Offset: 0x00A01376
		public SDecorationConfig_Effect(TSoftObjectPtr<UEffectModelBase> EffectData, string EffectSocketName, FTransform EffectTrans)
		{
			this.EffectData = EffectData;
			this.EffectSocketName = EffectSocketName;
			this.EffectTrans = EffectTrans;
		}

		// Token: 0x0602820D RID: 164365 RVA: 0x00A03193 File Offset: 0x00A01393
		protected override IntPtr GetUStructPtr()
		{
			return SDecorationConfig_Effect.StaticStruct();
		}

		// Token: 0x0602820E RID: 164366 RVA: 0x00A0319F File Offset: 0x00A0139F
		[NullableContext(2)]
		public SDecorationConfig_Effect(IntPtr NativePtr, UnrealObject MemoryOwner) : base(NativePtr, MemoryOwner)
		{
		}

		// Token: 0x0602820F RID: 164367 RVA: 0x00A031A9 File Offset: 0x00A013A9
		public SDecorationConfig_Effect(IntPtr NativePtr, bool bWithMoveAssign, bool bWithCopyAssignIfCannotMove) : base(NativePtr, bWithMoveAssign, bWithCopyAssignIfCannotMove)
		{
		}

		// Token: 0x06028210 RID: 164368 RVA: 0x00A031B4 File Offset: 0x00A013B4
		public static IUnrealScriptStructProxy CreateFromPointer(IntPtr Pointer)
		{
			return new SDecorationConfig_Effect(Pointer, false, true);
		}

		// Token: 0x06028211 RID: 164369 RVA: 0x00A031BE File Offset: 0x00A013BE
		public static IUnrealScriptStructProxy CreateReferenceFromPointer(IntPtr Pointer, UnrealObject MemoryOwner)
		{
			return new SDecorationConfig_Effect(Pointer, MemoryOwner);
		}

		// Token: 0x0401512D RID: 86317
		public const string __ObjectPath = "/Game/Aki/Data/Entity/Struct/SDecorationConfig_Effect.SDecorationConfig_Effect";

		// Token: 0x0401512E RID: 86318
		private static IntPtr _ScriptStructPtr;

		// Token: 0x0401512F RID: 86319
		internal static int __PropertyOffset_0;

		// Token: 0x04015130 RID: 86320
		internal static int __PropertyOffset_1;

		// Token: 0x04015131 RID: 86321
		internal static int __PropertyOffset_2;
	}
}
