using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Data.Entity.Struct
{
	// Token: 0x02003EF1 RID: 16113
	[NullableContext(1)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Data/Entity/Struct/SDecorationConfig.SDecorationConfig")]
	[UnrealStructLayout(360, 8, UnrealReflectionPropertyTypeCode.UnrealScriptStructProxy, PropertiesSize = 360)]
	public class SDecorationConfig : UnrealUserDefinedStructProxy, IUnrealScriptStructProxy, IUnrealScriptStruct, IUnrealObject
	{
		// Token: 0x060281E2 RID: 164322 RVA: 0x00A02C10 File Offset: 0x00A00E10
		public static UScriptStructStackOnlyPtr StaticStruct()
		{
			return (SDecorationConfig._ScriptStructPtr != 0) ? SDecorationConfig._ScriptStructPtr : UObjectGlobals.StaticLoadScriptStruct("/Game/Aki/Data/Entity/Struct/SDecorationConfig.SDecorationConfig", ref SDecorationConfig._ScriptStructPtr);
		}

		// Token: 0x17006096 RID: 24726
		// (get) Token: 0x060281E3 RID: 164323 RVA: 0x00A02C34 File Offset: 0x00A00E34
		// (set) Token: 0x060281E4 RID: 164324 RVA: 0x00A02C48 File Offset: 0x00A00E48
		public unsafe string Tips
		{
			get
			{
				return FString.ToString((void*)(base.NativePtr + (byte*)((IntPtr)SDecorationConfig.__PropertyOffset_0)));
			}
			set
			{
				FString.CopyFrom((void*)(base.NativePtr + (byte*)((IntPtr)SDecorationConfig.__PropertyOffset_0)), value);
			}
		}

		// Token: 0x17006097 RID: 24727
		// (get) Token: 0x060281E5 RID: 164325 RVA: 0x00A02C5D File Offset: 0x00A00E5D
		// (set) Token: 0x060281E6 RID: 164326 RVA: 0x00A02C7C File Offset: 0x00A00E7C
		public TSoftObjectPtr<USkeletalMesh> SkeletalMesh
		{
			get
			{
				return new TSoftObjectPtr<USkeletalMesh>(base.NativePtr + (IntPtr)SDecorationConfig.__PropertyOffset_1, base.MemoryOwner ?? this);
			}
			set
			{
				FSoftObjectPtr.NativeCopy(base.NativePtr + (IntPtr)SDecorationConfig.__PropertyOffset_1, (value != null) ? value.NativePtr : IntPtr.Zero, 1);
			}
		}

		// Token: 0x17006098 RID: 24728
		// (get) Token: 0x060281E7 RID: 164327 RVA: 0x00A02CA1 File Offset: 0x00A00EA1
		// (set) Token: 0x060281E8 RID: 164328 RVA: 0x00A02CB1 File Offset: 0x00A00EB1
		public unsafe bool SetMasterFollow
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SDecorationConfig.__PropertyOffset_2) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)SDecorationConfig.__PropertyOffset_2) = (value ? 1 : 0);
			}
		}

		// Token: 0x17006099 RID: 24729
		// (get) Token: 0x060281E9 RID: 164329 RVA: 0x00A02CC2 File Offset: 0x00A00EC2
		// (set) Token: 0x060281EA RID: 164330 RVA: 0x00A02CD6 File Offset: 0x00A00ED6
		public unsafe string SubMeshName
		{
			get
			{
				return FString.ToString((void*)(base.NativePtr + (byte*)((IntPtr)SDecorationConfig.__PropertyOffset_3)));
			}
			set
			{
				FString.CopyFrom((void*)(base.NativePtr + (byte*)((IntPtr)SDecorationConfig.__PropertyOffset_3)), value);
			}
		}

		// Token: 0x1700609A RID: 24730
		// (get) Token: 0x060281EB RID: 164331 RVA: 0x00A02CEB File Offset: 0x00A00EEB
		// (set) Token: 0x060281EC RID: 164332 RVA: 0x00A02D0A File Offset: 0x00A00F0A
		public TSoftClassPtr<UAnimInstance> AnimBlueprint
		{
			get
			{
				return new TSoftClassPtr<UAnimInstance>(base.NativePtr + (IntPtr)SDecorationConfig.__PropertyOffset_4, base.MemoryOwner ?? this);
			}
			set
			{
				FSoftObjectPtr.NativeCopy(base.NativePtr + (IntPtr)SDecorationConfig.__PropertyOffset_4, (value != null) ? value.NativePtr : IntPtr.Zero, 1);
			}
		}

		// Token: 0x1700609B RID: 24731
		// (get) Token: 0x060281ED RID: 164333 RVA: 0x00A02D30 File Offset: 0x00A00F30
		// (set) Token: 0x060281EE RID: 164334 RVA: 0x00A02D73 File Offset: 0x00A00F73
		public TArray<FName> AttachSocket
		{
			get
			{
				base.FastCheckIsValid();
				TArray<FName> result;
				if ((result = this._AttachSocket) == null)
				{
					result = (this._AttachSocket = new TArray<FName>(base.NativePtr + (IntPtr)SDecorationConfig.__PropertyOffset_5, base.MemoryOwner ?? this));
				}
				return result;
			}
			set
			{
				this.AttachSocket.CopyAssign(value);
			}
		}

		// Token: 0x1700609C RID: 24732
		// (get) Token: 0x060281EF RID: 164335 RVA: 0x00A02D84 File Offset: 0x00A00F84
		// (set) Token: 0x060281F0 RID: 164336 RVA: 0x00A02DC7 File Offset: 0x00A00FC7
		public TArray<FTransform> AttachTrans
		{
			get
			{
				base.FastCheckIsValid();
				TArray<FTransform> result;
				if ((result = this._AttachTrans) == null)
				{
					result = (this._AttachTrans = new TArray<FTransform>(base.NativePtr + (IntPtr)SDecorationConfig.__PropertyOffset_6, base.MemoryOwner ?? this));
				}
				return result;
			}
			set
			{
				this.AttachTrans.CopyAssign(value);
			}
		}

		// Token: 0x1700609D RID: 24733
		// (get) Token: 0x060281F1 RID: 164337 RVA: 0x00A02DD8 File Offset: 0x00A00FD8
		// (set) Token: 0x060281F2 RID: 164338 RVA: 0x00A02E1B File Offset: 0x00A0101B
		public TArray<SDecorationConfig_Effect> Effects
		{
			get
			{
				base.FastCheckIsValid();
				TArray<SDecorationConfig_Effect> result;
				if ((result = this._Effects) == null)
				{
					result = (this._Effects = new TArray<SDecorationConfig_Effect>(base.NativePtr + (IntPtr)SDecorationConfig.__PropertyOffset_7, base.MemoryOwner ?? this));
				}
				return result;
			}
			set
			{
				this.Effects.CopyAssign(value);
			}
		}

		// Token: 0x1700609E RID: 24734
		// (get) Token: 0x060281F3 RID: 164339 RVA: 0x00A02E2C File Offset: 0x00A0102C
		// (set) Token: 0x060281F4 RID: 164340 RVA: 0x00A02E6F File Offset: 0x00A0106F
		public FGameplayTagContainer DisplayTags
		{
			get
			{
				base.FastCheckIsValid();
				FGameplayTagContainer result;
				if ((result = this._DisplayTags) == null)
				{
					result = (this._DisplayTags = new FGameplayTagContainer(base.NativePtr + (IntPtr)SDecorationConfig.__PropertyOffset_8, base.MemoryOwner ?? this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FGameplayTagContainer.StaticStruct(), base.NativePtr + (IntPtr)SDecorationConfig.__PropertyOffset_8, value.NativePtr, 1, false);
			}
		}

		// Token: 0x1700609F RID: 24735
		// (get) Token: 0x060281F5 RID: 164341 RVA: 0x00A02E90 File Offset: 0x00A01090
		// (set) Token: 0x060281F6 RID: 164342 RVA: 0x00A02ED3 File Offset: 0x00A010D3
		public FGameplayTagContainer HideTags
		{
			get
			{
				base.FastCheckIsValid();
				FGameplayTagContainer result;
				if ((result = this._HideTags) == null)
				{
					result = (this._HideTags = new FGameplayTagContainer(base.NativePtr + (IntPtr)SDecorationConfig.__PropertyOffset_9, base.MemoryOwner ?? this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FGameplayTagContainer.StaticStruct(), base.NativePtr + (IntPtr)SDecorationConfig.__PropertyOffset_9, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170060A0 RID: 24736
		// (get) Token: 0x060281F7 RID: 164343 RVA: 0x00A02EF4 File Offset: 0x00A010F4
		// (set) Token: 0x060281F8 RID: 164344 RVA: 0x00A02F37 File Offset: 0x00A01137
		public FGameplayTagContainer UIDisplayTags
		{
			get
			{
				base.FastCheckIsValid();
				FGameplayTagContainer result;
				if ((result = this._UIDisplayTags) == null)
				{
					result = (this._UIDisplayTags = new FGameplayTagContainer(base.NativePtr + (IntPtr)SDecorationConfig.__PropertyOffset_10, base.MemoryOwner ?? this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FGameplayTagContainer.StaticStruct(), base.NativePtr + (IntPtr)SDecorationConfig.__PropertyOffset_10, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170060A1 RID: 24737
		// (get) Token: 0x060281F9 RID: 164345 RVA: 0x00A02F58 File Offset: 0x00A01158
		// (set) Token: 0x060281FA RID: 164346 RVA: 0x00A02F9B File Offset: 0x00A0119B
		public FGameplayTagContainer UIHideTags
		{
			get
			{
				base.FastCheckIsValid();
				FGameplayTagContainer result;
				if ((result = this._UIHideTags) == null)
				{
					result = (this._UIHideTags = new FGameplayTagContainer(base.NativePtr + (IntPtr)SDecorationConfig.__PropertyOffset_11, base.MemoryOwner ?? this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FGameplayTagContainer.StaticStruct(), base.NativePtr + (IntPtr)SDecorationConfig.__PropertyOffset_11, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170060A2 RID: 24738
		// (get) Token: 0x060281FB RID: 164347 RVA: 0x00A02FBC File Offset: 0x00A011BC
		// (set) Token: 0x060281FC RID: 164348 RVA: 0x00A02FDB File Offset: 0x00A011DB
		public TSoftClassPtr<UAnimInstance> UIAnimBlueprint
		{
			get
			{
				return new TSoftClassPtr<UAnimInstance>(base.NativePtr + (IntPtr)SDecorationConfig.__PropertyOffset_12, base.MemoryOwner ?? this);
			}
			set
			{
				FSoftObjectPtr.NativeCopy(base.NativePtr + (IntPtr)SDecorationConfig.__PropertyOffset_12, (value != null) ? value.NativePtr : IntPtr.Zero, 1);
			}
		}

		// Token: 0x060281FD RID: 164349 RVA: 0x00A03000 File Offset: 0x00A01200
		public SDecorationConfig()
		{
		}

		// Token: 0x060281FE RID: 164350 RVA: 0x00A03008 File Offset: 0x00A01208
		public SDecorationConfig(string Tips, TSoftObjectPtr<USkeletalMesh> SkeletalMesh, bool SetMasterFollow, string SubMeshName, TSoftClassPtr<UAnimInstance> AnimBlueprint, TArray<FName> AttachSocket, TArray<FTransform> AttachTrans, TArray<SDecorationConfig_Effect> Effects, FGameplayTagContainer DisplayTags, FGameplayTagContainer HideTags, FGameplayTagContainer UIDisplayTags, FGameplayTagContainer UIHideTags, TSoftClassPtr<UAnimInstance> UIAnimBlueprint)
		{
			this.Tips = Tips;
			this.SkeletalMesh = SkeletalMesh;
			this.SetMasterFollow = SetMasterFollow;
			this.SubMeshName = SubMeshName;
			this.AnimBlueprint = AnimBlueprint;
			this.AttachSocket = AttachSocket;
			this.AttachTrans = AttachTrans;
			this.Effects = Effects;
			this.DisplayTags = DisplayTags;
			this.HideTags = HideTags;
			this.UIDisplayTags = UIDisplayTags;
			this.UIHideTags = UIHideTags;
			this.UIAnimBlueprint = UIAnimBlueprint;
		}

		// Token: 0x060281FF RID: 164351 RVA: 0x00A03080 File Offset: 0x00A01280
		protected override IntPtr GetUStructPtr()
		{
			return SDecorationConfig.StaticStruct();
		}

		// Token: 0x06028200 RID: 164352 RVA: 0x00A0308C File Offset: 0x00A0128C
		[NullableContext(2)]
		public SDecorationConfig(IntPtr NativePtr, UnrealObject MemoryOwner) : base(NativePtr, MemoryOwner)
		{
		}

		// Token: 0x06028201 RID: 164353 RVA: 0x00A03096 File Offset: 0x00A01296
		public SDecorationConfig(IntPtr NativePtr, bool bWithMoveAssign, bool bWithCopyAssignIfCannotMove) : base(NativePtr, bWithMoveAssign, bWithCopyAssignIfCannotMove)
		{
		}

		// Token: 0x06028202 RID: 164354 RVA: 0x00A030A1 File Offset: 0x00A012A1
		public static IUnrealScriptStructProxy CreateFromPointer(IntPtr Pointer)
		{
			return new SDecorationConfig(Pointer, false, true);
		}

		// Token: 0x06028203 RID: 164355 RVA: 0x00A030AB File Offset: 0x00A012AB
		public static IUnrealScriptStructProxy CreateReferenceFromPointer(IntPtr Pointer, UnrealObject MemoryOwner)
		{
			return new SDecorationConfig(Pointer, MemoryOwner);
		}

		// Token: 0x04015117 RID: 86295
		public const string __ObjectPath = "/Game/Aki/Data/Entity/Struct/SDecorationConfig.SDecorationConfig";

		// Token: 0x04015118 RID: 86296
		private static IntPtr _ScriptStructPtr;

		// Token: 0x04015119 RID: 86297
		internal static int __PropertyOffset_0;

		// Token: 0x0401511A RID: 86298
		internal static int __PropertyOffset_1;

		// Token: 0x0401511B RID: 86299
		internal static int __PropertyOffset_2;

		// Token: 0x0401511C RID: 86300
		internal static int __PropertyOffset_3;

		// Token: 0x0401511D RID: 86301
		internal static int __PropertyOffset_4;

		// Token: 0x0401511E RID: 86302
		internal static int __PropertyOffset_5;

		// Token: 0x0401511F RID: 86303
		[Nullable(2)]
		private TArray<FName> _AttachSocket;

		// Token: 0x04015120 RID: 86304
		internal static int __PropertyOffset_6;

		// Token: 0x04015121 RID: 86305
		[Nullable(2)]
		private TArray<FTransform> _AttachTrans;

		// Token: 0x04015122 RID: 86306
		internal static int __PropertyOffset_7;

		// Token: 0x04015123 RID: 86307
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private TArray<SDecorationConfig_Effect> _Effects;

		// Token: 0x04015124 RID: 86308
		internal static int __PropertyOffset_8;

		// Token: 0x04015125 RID: 86309
		[Nullable(2)]
		private FGameplayTagContainer _DisplayTags;

		// Token: 0x04015126 RID: 86310
		internal static int __PropertyOffset_9;

		// Token: 0x04015127 RID: 86311
		[Nullable(2)]
		private FGameplayTagContainer _HideTags;

		// Token: 0x04015128 RID: 86312
		internal static int __PropertyOffset_10;

		// Token: 0x04015129 RID: 86313
		[Nullable(2)]
		private FGameplayTagContainer _UIDisplayTags;

		// Token: 0x0401512A RID: 86314
		internal static int __PropertyOffset_11;

		// Token: 0x0401512B RID: 86315
		[Nullable(2)]
		private FGameplayTagContainer _UIHideTags;

		// Token: 0x0401512C RID: 86316
		internal static int __PropertyOffset_12;
	}
}
