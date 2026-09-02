using System;
using System.Runtime.CompilerServices;
using AkiClient.Game.Aki.Character.Role.Common.Data.Enum;
using AkiClient.Game.Aki.Render.RuntimeBP.Character.MaterialController;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;

namespace AkiClient.Game.Aki.Character.BaseCharacter
{
	// Token: 0x02004284 RID: 17028
	[NullableContext(1)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Character/BaseCharacter/SUiAnimNotifyModel.SUiAnimNotifyModel")]
	[UnrealStructLayout(192, 16, UnrealReflectionPropertyTypeCode.UnrealScriptStructProxy, PropertiesSize = 185)]
	public class SUiAnimNotifyModel : UnrealUserDefinedStructProxy, IUnrealScriptStructProxy, IUnrealScriptStruct, IUnrealObject
	{
		// Token: 0x0602D3B9 RID: 185273 RVA: 0x00ABAA67 File Offset: 0x00AB8C67
		public static UScriptStructStackOnlyPtr StaticStruct()
		{
			return (SUiAnimNotifyModel._ScriptStructPtr != 0) ? SUiAnimNotifyModel._ScriptStructPtr : UObjectGlobals.StaticLoadScriptStruct("/Game/Aki/Character/BaseCharacter/SUiAnimNotifyModel.SUiAnimNotifyModel", ref SUiAnimNotifyModel._ScriptStructPtr);
		}

		// Token: 0x17007B46 RID: 31558
		// (get) Token: 0x0602D3BA RID: 185274 RVA: 0x00ABAA8B File Offset: 0x00AB8C8B
		// (set) Token: 0x0602D3BB RID: 185275 RVA: 0x00ABAA9F File Offset: 0x00AB8C9F
		public unsafe string SocketName
		{
			get
			{
				return FString.ToString((void*)(base.NativePtr + (byte*)((IntPtr)SUiAnimNotifyModel.__PropertyOffset_0)));
			}
			set
			{
				FString.CopyFrom((void*)(base.NativePtr + (byte*)((IntPtr)SUiAnimNotifyModel.__PropertyOffset_0)), value);
			}
		}

		// Token: 0x17007B47 RID: 31559
		// (get) Token: 0x0602D3BC RID: 185276 RVA: 0x00ABAAB4 File Offset: 0x00AB8CB4
		// (set) Token: 0x0602D3BD RID: 185277 RVA: 0x00ABAAC8 File Offset: 0x00AB8CC8
		public unsafe FTransform Transform
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SUiAnimNotifyModel.__PropertyOffset_1);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SUiAnimNotifyModel.__PropertyOffset_1) = value;
			}
		}

		// Token: 0x17007B48 RID: 31560
		// (get) Token: 0x0602D3BE RID: 185278 RVA: 0x00ABAADD File Offset: 0x00AB8CDD
		// (set) Token: 0x0602D3BF RID: 185279 RVA: 0x00ABAAFC File Offset: 0x00AB8CFC
		public TSoftObjectPtr<USkeletalMesh> ModelSoft
		{
			get
			{
				return new TSoftObjectPtr<USkeletalMesh>(base.NativePtr + (IntPtr)SUiAnimNotifyModel.__PropertyOffset_2, base.MemoryOwner ?? this);
			}
			set
			{
				FSoftObjectPtr.NativeCopy(base.NativePtr + (IntPtr)SUiAnimNotifyModel.__PropertyOffset_2, (value != null) ? value.NativePtr : IntPtr.Zero, 1);
			}
		}

		// Token: 0x17007B49 RID: 31561
		// (get) Token: 0x0602D3C0 RID: 185280 RVA: 0x00ABAB21 File Offset: 0x00AB8D21
		// (set) Token: 0x0602D3C1 RID: 185281 RVA: 0x00ABAB31 File Offset: 0x00AB8D31
		public unsafe int ModelIndex
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SUiAnimNotifyModel.__PropertyOffset_3);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SUiAnimNotifyModel.__PropertyOffset_3) = value;
			}
		}

		// Token: 0x17007B4A RID: 31562
		// (get) Token: 0x0602D3C2 RID: 185282 RVA: 0x00ABAB42 File Offset: 0x00AB8D42
		// (set) Token: 0x0602D3C3 RID: 185283 RVA: 0x00ABAB61 File Offset: 0x00AB8D61
		public TSoftObjectPtr<PD_CharacterControllerData_C> MaterialData
		{
			get
			{
				return new TSoftObjectPtr<PD_CharacterControllerData_C>(base.NativePtr + (IntPtr)SUiAnimNotifyModel.__PropertyOffset_4, base.MemoryOwner ?? this);
			}
			set
			{
				FSoftObjectPtr.NativeCopy(base.NativePtr + (IntPtr)SUiAnimNotifyModel.__PropertyOffset_4, (value != null) ? value.NativePtr : IntPtr.Zero, 1);
			}
		}

		// Token: 0x17007B4B RID: 31563
		// (get) Token: 0x0602D3C4 RID: 185284 RVA: 0x00ABAB86 File Offset: 0x00AB8D86
		// (set) Token: 0x0602D3C5 RID: 185285 RVA: 0x00ABAB9A File Offset: 0x00AB8D9A
		public unsafe string MaterialTypeName
		{
			get
			{
				return FString.ToString((void*)(base.NativePtr + (byte*)((IntPtr)SUiAnimNotifyModel.__PropertyOffset_5)));
			}
			set
			{
				FString.CopyFrom((void*)(base.NativePtr + (byte*)((IntPtr)SUiAnimNotifyModel.__PropertyOffset_5)), value);
			}
		}

		// Token: 0x17007B4C RID: 31564
		// (get) Token: 0x0602D3C6 RID: 185286 RVA: 0x00ABABAF File Offset: 0x00AB8DAF
		// (set) Token: 0x0602D3C7 RID: 185287 RVA: 0x00ABABC3 File Offset: 0x00AB8DC3
		[Nullable(0)]
		public unsafe TEnumAsByte<EPerformanceRoleState> AnimState
		{
			[NullableContext(0)]
			get
			{
				return *(base.NativePtr + (IntPtr)SUiAnimNotifyModel.__PropertyOffset_6);
			}
			[NullableContext(0)]
			set
			{
				*(base.NativePtr + (IntPtr)SUiAnimNotifyModel.__PropertyOffset_6) = value;
			}
		}

		// Token: 0x0602D3C8 RID: 185288 RVA: 0x00ABABD8 File Offset: 0x00AB8DD8
		public SUiAnimNotifyModel()
		{
		}

		// Token: 0x0602D3C9 RID: 185289 RVA: 0x00ABABE0 File Offset: 0x00AB8DE0
		public SUiAnimNotifyModel(string SocketName, FTransform Transform, TSoftObjectPtr<USkeletalMesh> ModelSoft, int ModelIndex, TSoftObjectPtr<PD_CharacterControllerData_C> MaterialData, string MaterialTypeName, [Nullable(0)] TEnumAsByte<EPerformanceRoleState> AnimState)
		{
			this.SocketName = SocketName;
			this.Transform = Transform;
			this.ModelSoft = ModelSoft;
			this.ModelIndex = ModelIndex;
			this.MaterialData = MaterialData;
			this.MaterialTypeName = MaterialTypeName;
			this.AnimState = AnimState;
		}

		// Token: 0x0602D3CA RID: 185290 RVA: 0x00ABAC1D File Offset: 0x00AB8E1D
		protected override IntPtr GetUStructPtr()
		{
			return SUiAnimNotifyModel.StaticStruct();
		}

		// Token: 0x0602D3CB RID: 185291 RVA: 0x00ABAC29 File Offset: 0x00AB8E29
		[NullableContext(2)]
		public SUiAnimNotifyModel(IntPtr NativePtr, UnrealObject MemoryOwner) : base(NativePtr, MemoryOwner)
		{
		}

		// Token: 0x0602D3CC RID: 185292 RVA: 0x00ABAC33 File Offset: 0x00AB8E33
		public SUiAnimNotifyModel(IntPtr NativePtr, bool bWithMoveAssign, bool bWithCopyAssignIfCannotMove) : base(NativePtr, bWithMoveAssign, bWithCopyAssignIfCannotMove)
		{
		}

		// Token: 0x0602D3CD RID: 185293 RVA: 0x00ABAC3E File Offset: 0x00AB8E3E
		public static IUnrealScriptStructProxy CreateFromPointer(IntPtr Pointer)
		{
			return new SUiAnimNotifyModel(Pointer, false, true);
		}

		// Token: 0x0602D3CE RID: 185294 RVA: 0x00ABAC48 File Offset: 0x00AB8E48
		public static IUnrealScriptStructProxy CreateReferenceFromPointer(IntPtr Pointer, UnrealObject MemoryOwner)
		{
			return new SUiAnimNotifyModel(Pointer, MemoryOwner);
		}

		// Token: 0x040195B6 RID: 103862
		public const string __ObjectPath = "/Game/Aki/Character/BaseCharacter/SUiAnimNotifyModel.SUiAnimNotifyModel";

		// Token: 0x040195B7 RID: 103863
		private static IntPtr _ScriptStructPtr;

		// Token: 0x040195B8 RID: 103864
		internal static int __PropertyOffset_0;

		// Token: 0x040195B9 RID: 103865
		internal static int __PropertyOffset_1;

		// Token: 0x040195BA RID: 103866
		internal static int __PropertyOffset_2;

		// Token: 0x040195BB RID: 103867
		internal static int __PropertyOffset_3;

		// Token: 0x040195BC RID: 103868
		internal static int __PropertyOffset_4;

		// Token: 0x040195BD RID: 103869
		internal static int __PropertyOffset_5;

		// Token: 0x040195BE RID: 103870
		internal static int __PropertyOffset_6;
	}
}
