using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;

namespace AkiClient.Game.Aki.Render.RuntimeBP.TrailFields.Runtime
{
	// Token: 0x02003A2E RID: 14894
	[NullableContext(1)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Render/RuntimeBP/TrailFields/Runtime/STrailLandPair.STrailLandPair")]
	[UnrealStructLayout(32, 8, UnrealReflectionPropertyTypeCode.UnrealScriptStructProxy, PropertiesSize = 32)]
	public class STrailLandPair : UnrealUserDefinedStructProxy, IUnrealScriptStructProxy, IUnrealScriptStruct, IUnrealObject
	{
		// Token: 0x0601EA9F RID: 125599 RVA: 0x008FB161 File Offset: 0x008F9361
		public static UScriptStructStackOnlyPtr StaticStruct()
		{
			return (STrailLandPair._ScriptStructPtr != 0) ? STrailLandPair._ScriptStructPtr : UObjectGlobals.StaticLoadScriptStruct("/Game/Aki/Render/RuntimeBP/TrailFields/Runtime/STrailLandPair.STrailLandPair", ref STrailLandPair._ScriptStructPtr);
		}

		// Token: 0x17002BC6 RID: 11206
		// (get) Token: 0x0601EAA0 RID: 125600 RVA: 0x008FB188 File Offset: 0x008F9388
		// (set) Token: 0x0601EAA1 RID: 125601 RVA: 0x008FB1CB File Offset: 0x008F93CB
		public TArray<int> Index
		{
			get
			{
				base.FastCheckIsValid();
				TArray<int> result;
				if ((result = this._Index) == null)
				{
					result = (this._Index = new TArray<int>(base.NativePtr + (IntPtr)STrailLandPair.__PropertyOffset_0, base.MemoryOwner ?? this));
				}
				return result;
			}
			set
			{
				this.Index.CopyAssign(value);
			}
		}

		// Token: 0x17002BC7 RID: 11207
		// (get) Token: 0x0601EAA2 RID: 125602 RVA: 0x008FB1DC File Offset: 0x008F93DC
		// (set) Token: 0x0601EAA3 RID: 125603 RVA: 0x008FB21F File Offset: 0x008F941F
		public TArray<bool> Show
		{
			get
			{
				base.FastCheckIsValid();
				TArray<bool> result;
				if ((result = this._Show) == null)
				{
					result = (this._Show = new TArray<bool>(base.NativePtr + (IntPtr)STrailLandPair.__PropertyOffset_1, base.MemoryOwner ?? this));
				}
				return result;
			}
			set
			{
				this.Show.CopyAssign(value);
			}
		}

		// Token: 0x0601EAA4 RID: 125604 RVA: 0x008FB22D File Offset: 0x008F942D
		public STrailLandPair()
		{
		}

		// Token: 0x0601EAA5 RID: 125605 RVA: 0x008FB235 File Offset: 0x008F9435
		public STrailLandPair(TArray<int> Index, TArray<bool> Show)
		{
			this.Index = Index;
			this.Show = Show;
		}

		// Token: 0x0601EAA6 RID: 125606 RVA: 0x008FB24B File Offset: 0x008F944B
		protected override IntPtr GetUStructPtr()
		{
			return STrailLandPair.StaticStruct();
		}

		// Token: 0x0601EAA7 RID: 125607 RVA: 0x008FB257 File Offset: 0x008F9457
		[NullableContext(2)]
		public STrailLandPair(IntPtr NativePtr, UnrealObject MemoryOwner) : base(NativePtr, MemoryOwner)
		{
		}

		// Token: 0x0601EAA8 RID: 125608 RVA: 0x008FB261 File Offset: 0x008F9461
		public STrailLandPair(IntPtr NativePtr, bool bWithMoveAssign, bool bWithCopyAssignIfCannotMove) : base(NativePtr, bWithMoveAssign, bWithCopyAssignIfCannotMove)
		{
		}

		// Token: 0x0601EAA9 RID: 125609 RVA: 0x008FB26C File Offset: 0x008F946C
		public static IUnrealScriptStructProxy CreateFromPointer(IntPtr Pointer)
		{
			return new STrailLandPair(Pointer, false, true);
		}

		// Token: 0x0601EAAA RID: 125610 RVA: 0x008FB276 File Offset: 0x008F9476
		public static IUnrealScriptStructProxy CreateReferenceFromPointer(IntPtr Pointer, UnrealObject MemoryOwner)
		{
			return new STrailLandPair(Pointer, MemoryOwner);
		}

		// Token: 0x0400F202 RID: 61954
		public const string __ObjectPath = "/Game/Aki/Render/RuntimeBP/TrailFields/Runtime/STrailLandPair.STrailLandPair";

		// Token: 0x0400F203 RID: 61955
		private static IntPtr _ScriptStructPtr;

		// Token: 0x0400F204 RID: 61956
		internal static int __PropertyOffset_0;

		// Token: 0x0400F205 RID: 61957
		[Nullable(2)]
		private TArray<int> _Index;

		// Token: 0x0400F206 RID: 61958
		internal static int __PropertyOffset_1;

		// Token: 0x0400F207 RID: 61959
		[Nullable(2)]
		private TArray<bool> _Show;
	}
}
