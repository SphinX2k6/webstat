using System;
using System.Runtime.CompilerServices;
using AkiClient.Game.Aki.Render.RuntimeBP.TrackParticles.DT;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Render.RuntimeBP.TrackParticles
{
	// Token: 0x02003A3A RID: 14906
	[NullableContext(1)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Render/RuntimeBP/TrackParticles/BP_TrackParticles.BP_TrackParticles_C")]
	[UnrealStructLayout(1336, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 1336)]
	public class BP_TrackParticles_C : AKuroBPActor, IUnrealUObject, IUnrealObject
	{
		// Token: 0x0601EBDC RID: 125916 RVA: 0x008FD4DB File Offset: 0x008FB6DB
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_TrackParticles_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Render/RuntimeBP/TrackParticles/BP_TrackParticles.BP_TrackParticles_C");
			}
			return BP_TrackParticles_C._ClassPtr;
		}

		// Token: 0x0601EBDD RID: 125917 RVA: 0x008FD500 File Offset: 0x008FB700
		public BP_TrackParticles_C() : this(BuiltinUtils.AllocNativeUObject(BP_TrackParticles_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x0601EBDE RID: 125918 RVA: 0x008FD528 File Offset: 0x008FB728
		public BP_TrackParticles_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_TrackParticles_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x17002C2A RID: 11306
		// (get) Token: 0x0601EBDF RID: 125919 RVA: 0x008FD55B File Offset: 0x008FB75B
		// (set) Token: 0x0601EBE0 RID: 125920 RVA: 0x008FD56F File Offset: 0x008FB76F
		[Nullable(2)]
		public unsafe USceneComponent DefaultSceneRoot
		{
			[NullableContext(2)]
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<USceneComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_TrackParticles_C.__PropertyOffset_0);
			}
			[NullableContext(2)]
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_TrackParticles_C.__PropertyOffset_0, value);
			}
		}

		// Token: 0x17002C2B RID: 11307
		// (get) Token: 0x0601EBE1 RID: 125921 RVA: 0x008FD584 File Offset: 0x008FB784
		// (set) Token: 0x0601EBE2 RID: 125922 RVA: 0x008FD5BD File Offset: 0x008FB7BD
		public TArray<UTexture2D> TrackTextureArray
		{
			get
			{
				base.FastCheckIsValid();
				TArray<UTexture2D> result;
				if ((result = this._TrackTextureArray) == null)
				{
					result = (this._TrackTextureArray = new TArray<UTexture2D>(base.NativePtr + (IntPtr)BP_TrackParticles_C.__PropertyOffset_1, this));
				}
				return result;
			}
			set
			{
				this.TrackTextureArray.CopyAssign(value);
			}
		}

		// Token: 0x17002C2C RID: 11308
		// (get) Token: 0x0601EBE3 RID: 125923 RVA: 0x008FD5CC File Offset: 0x008FB7CC
		// (set) Token: 0x0601EBE4 RID: 125924 RVA: 0x008FD605 File Offset: 0x008FB805
		public TArray<Struct_TrackParticles> TrackDataArray
		{
			get
			{
				base.FastCheckIsValid();
				TArray<Struct_TrackParticles> result;
				if ((result = this._TrackDataArray) == null)
				{
					result = (this._TrackDataArray = new TArray<Struct_TrackParticles>(base.NativePtr + (IntPtr)BP_TrackParticles_C.__PropertyOffset_2, this));
				}
				return result;
			}
			set
			{
				this.TrackDataArray.CopyAssign(value);
			}
		}

		// Token: 0x0601EBE5 RID: 125925 RVA: 0x008FD613 File Offset: 0x008FB813
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void UserConstructionScript()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_TrackParticles_C.__UserConstructionScript_NativeFunctionPtr, null);
		}

		// Token: 0x0601EBE6 RID: 125926 RVA: 0x008FD627 File Offset: 0x008FB827
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected virtual void UserConstructionScript_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_TrackParticles_C.__UserConstructionScript_NativeFunctionPtr, null, 0);
		}

		// Token: 0x0601EBE7 RID: 125927 RVA: 0x008FD63C File Offset: 0x008FB83C
		protected BP_TrackParticles_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x0400F2C8 RID: 62152
		public new const string __ObjectPath = "/Game/Aki/Render/RuntimeBP/TrackParticles/BP_TrackParticles.BP_TrackParticles_C";

		// Token: 0x0400F2C9 RID: 62153
		private static IntPtr _ClassPtr;

		// Token: 0x0400F2CA RID: 62154
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x0400F2CB RID: 62155
		internal static int __PropertyOffset_0;

		// Token: 0x0400F2CC RID: 62156
		internal static int __PropertyOffset_1;

		// Token: 0x0400F2CD RID: 62157
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private TArray<UTexture2D> _TrackTextureArray;

		// Token: 0x0400F2CE RID: 62158
		internal static int __PropertyOffset_2;

		// Token: 0x0400F2CF RID: 62159
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private TArray<Struct_TrackParticles> _TrackDataArray;

		// Token: 0x0400F2D0 RID: 62160
		private static IntPtr __UserConstructionScript_NativeFunctionPtr;
	}
}
