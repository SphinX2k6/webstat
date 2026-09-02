using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;

namespace AkiClient.Game.Aki.Character.BaseCharacter
{
	// Token: 0x0200423B RID: 16955
	[NullableContext(1)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Character/BaseCharacter/SBatchBulletPositionPointMatrix.SBatchBulletPositionPointMatrix")]
	[UnrealStructLayout(72, 8, UnrealReflectionPropertyTypeCode.UnrealScriptStructProxy, PropertiesSize = 65)]
	public class SBatchBulletPositionPointMatrix : UnrealUserDefinedStructProxy, IUnrealScriptStructProxy, IUnrealScriptStruct, IUnrealObject
	{
		// Token: 0x0602CD8D RID: 183693 RVA: 0x00AB17E4 File Offset: 0x00AAF9E4
		public static UScriptStructStackOnlyPtr StaticStruct()
		{
			return (SBatchBulletPositionPointMatrix._ScriptStructPtr != 0) ? SBatchBulletPositionPointMatrix._ScriptStructPtr : UObjectGlobals.StaticLoadScriptStruct("/Game/Aki/Character/BaseCharacter/SBatchBulletPositionPointMatrix.SBatchBulletPositionPointMatrix", ref SBatchBulletPositionPointMatrix._ScriptStructPtr);
		}

		// Token: 0x1700794F RID: 31055
		// (get) Token: 0x0602CD8E RID: 183694 RVA: 0x00AB1808 File Offset: 0x00AAFA08
		// (set) Token: 0x0602CD8F RID: 183695 RVA: 0x00AB184B File Offset: 0x00AAFA4B
		public TArray<FVector> PositionOffset
		{
			get
			{
				base.FastCheckIsValid();
				TArray<FVector> result;
				if ((result = this._PositionOffset) == null)
				{
					result = (this._PositionOffset = new TArray<FVector>(base.NativePtr + (IntPtr)SBatchBulletPositionPointMatrix.__PropertyOffset_0, base.MemoryOwner ?? this));
				}
				return result;
			}
			set
			{
				this.PositionOffset.CopyAssign(value);
			}
		}

		// Token: 0x17007950 RID: 31056
		// (get) Token: 0x0602CD90 RID: 183696 RVA: 0x00AB1859 File Offset: 0x00AAFA59
		// (set) Token: 0x0602CD91 RID: 183697 RVA: 0x00AB186D File Offset: 0x00AAFA6D
		public unsafe string CenterKey
		{
			get
			{
				return FString.ToString((void*)(base.NativePtr + (byte*)((IntPtr)SBatchBulletPositionPointMatrix.__PropertyOffset_1)));
			}
			set
			{
				FString.CopyFrom((void*)(base.NativePtr + (byte*)((IntPtr)SBatchBulletPositionPointMatrix.__PropertyOffset_1)), value);
			}
		}

		// Token: 0x17007951 RID: 31057
		// (get) Token: 0x0602CD92 RID: 183698 RVA: 0x00AB1882 File Offset: 0x00AAFA82
		// (set) Token: 0x0602CD93 RID: 183699 RVA: 0x00AB1896 File Offset: 0x00AAFA96
		public unsafe string RotatorKey
		{
			get
			{
				return FString.ToString((void*)(base.NativePtr + (byte*)((IntPtr)SBatchBulletPositionPointMatrix.__PropertyOffset_2)));
			}
			set
			{
				FString.CopyFrom((void*)(base.NativePtr + (byte*)((IntPtr)SBatchBulletPositionPointMatrix.__PropertyOffset_2)), value);
			}
		}

		// Token: 0x17007952 RID: 31058
		// (get) Token: 0x0602CD94 RID: 183700 RVA: 0x00AB18AB File Offset: 0x00AAFAAB
		// (set) Token: 0x0602CD95 RID: 183701 RVA: 0x00AB18BB File Offset: 0x00AAFABB
		public unsafe float PositionOffsetScale
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SBatchBulletPositionPointMatrix.__PropertyOffset_3);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SBatchBulletPositionPointMatrix.__PropertyOffset_3) = value;
			}
		}

		// Token: 0x17007953 RID: 31059
		// (get) Token: 0x0602CD96 RID: 183702 RVA: 0x00AB18CC File Offset: 0x00AAFACC
		// (set) Token: 0x0602CD97 RID: 183703 RVA: 0x00AB18E0 File Offset: 0x00AAFAE0
		public unsafe FRotator RotatorOffset
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SBatchBulletPositionPointMatrix.__PropertyOffset_4);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SBatchBulletPositionPointMatrix.__PropertyOffset_4) = value;
			}
		}

		// Token: 0x17007954 RID: 31060
		// (get) Token: 0x0602CD98 RID: 183704 RVA: 0x00AB18F5 File Offset: 0x00AAFAF5
		// (set) Token: 0x0602CD99 RID: 183705 RVA: 0x00AB1909 File Offset: 0x00AAFB09
		[Nullable(0)]
		public unsafe TEnumAsByte<EBatchBulletBeginRotator> BeginRotator
		{
			[NullableContext(0)]
			get
			{
				return *(base.NativePtr + (IntPtr)SBatchBulletPositionPointMatrix.__PropertyOffset_5);
			}
			[NullableContext(0)]
			set
			{
				*(base.NativePtr + (IntPtr)SBatchBulletPositionPointMatrix.__PropertyOffset_5) = value;
			}
		}

		// Token: 0x0602CD9A RID: 183706 RVA: 0x00AB191E File Offset: 0x00AAFB1E
		public SBatchBulletPositionPointMatrix()
		{
		}

		// Token: 0x0602CD9B RID: 183707 RVA: 0x00AB1926 File Offset: 0x00AAFB26
		public SBatchBulletPositionPointMatrix(TArray<FVector> PositionOffset, string CenterKey, string RotatorKey, float PositionOffsetScale, FRotator RotatorOffset, [Nullable(0)] TEnumAsByte<EBatchBulletBeginRotator> BeginRotator)
		{
			this.PositionOffset = PositionOffset;
			this.CenterKey = CenterKey;
			this.RotatorKey = RotatorKey;
			this.PositionOffsetScale = PositionOffsetScale;
			this.RotatorOffset = RotatorOffset;
			this.BeginRotator = BeginRotator;
		}

		// Token: 0x0602CD9C RID: 183708 RVA: 0x00AB195B File Offset: 0x00AAFB5B
		protected override IntPtr GetUStructPtr()
		{
			return SBatchBulletPositionPointMatrix.StaticStruct();
		}

		// Token: 0x0602CD9D RID: 183709 RVA: 0x00AB1967 File Offset: 0x00AAFB67
		[NullableContext(2)]
		public SBatchBulletPositionPointMatrix(IntPtr NativePtr, UnrealObject MemoryOwner) : base(NativePtr, MemoryOwner)
		{
		}

		// Token: 0x0602CD9E RID: 183710 RVA: 0x00AB1971 File Offset: 0x00AAFB71
		public SBatchBulletPositionPointMatrix(IntPtr NativePtr, bool bWithMoveAssign, bool bWithCopyAssignIfCannotMove) : base(NativePtr, bWithMoveAssign, bWithCopyAssignIfCannotMove)
		{
		}

		// Token: 0x0602CD9F RID: 183711 RVA: 0x00AB197C File Offset: 0x00AAFB7C
		public static IUnrealScriptStructProxy CreateFromPointer(IntPtr Pointer)
		{
			return new SBatchBulletPositionPointMatrix(Pointer, false, true);
		}

		// Token: 0x0602CDA0 RID: 183712 RVA: 0x00AB1986 File Offset: 0x00AAFB86
		public static IUnrealScriptStructProxy CreateReferenceFromPointer(IntPtr Pointer, UnrealObject MemoryOwner)
		{
			return new SBatchBulletPositionPointMatrix(Pointer, MemoryOwner);
		}

		// Token: 0x040192A4 RID: 103076
		public const string __ObjectPath = "/Game/Aki/Character/BaseCharacter/SBatchBulletPositionPointMatrix.SBatchBulletPositionPointMatrix";

		// Token: 0x040192A5 RID: 103077
		private static IntPtr _ScriptStructPtr;

		// Token: 0x040192A6 RID: 103078
		internal static int __PropertyOffset_0;

		// Token: 0x040192A7 RID: 103079
		[Nullable(2)]
		private TArray<FVector> _PositionOffset;

		// Token: 0x040192A8 RID: 103080
		internal static int __PropertyOffset_1;

		// Token: 0x040192A9 RID: 103081
		internal static int __PropertyOffset_2;

		// Token: 0x040192AA RID: 103082
		internal static int __PropertyOffset_3;

		// Token: 0x040192AB RID: 103083
		internal static int __PropertyOffset_4;

		// Token: 0x040192AC RID: 103084
		internal static int __PropertyOffset_5;
	}
}
