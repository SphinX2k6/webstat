using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using AkiClient.Game.Aki.Render.RuntimeBP.Effect;
using AkiClient.Game.Aki.Render.RuntimeBP.Effect.Data;
using AkiClient.Game.Aki.Render.RuntimeBP.Scene.Light;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Render.RuntimeBP.Scene.BlueprintLevel
{
	// Token: 0x02003B21 RID: 15137
	[NullableContext(1)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Render/RuntimeBP/Scene/BlueprintLevel/BP_SceneActorsChange.BP_SceneActorsChange_C")]
	[UnrealStructLayout(1544, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 1544)]
	public class BP_SceneActorsChange_C : AKuroEditorTickActor, IUnrealUObject, IUnrealObject
	{
		// Token: 0x060208C8 RID: 133320 RVA: 0x0092F5F4 File Offset: 0x0092D7F4
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_SceneActorsChange_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Render/RuntimeBP/Scene/BlueprintLevel/BP_SceneActorsChange.BP_SceneActorsChange_C");
			}
			return BP_SceneActorsChange_C._ClassPtr;
		}

		// Token: 0x060208C9 RID: 133321 RVA: 0x0092F618 File Offset: 0x0092D818
		public BP_SceneActorsChange_C() : this(BuiltinUtils.AllocNativeUObject(BP_SceneActorsChange_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x060208CA RID: 133322 RVA: 0x0092F640 File Offset: 0x0092D840
		public BP_SceneActorsChange_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_SceneActorsChange_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x17003614 RID: 13844
		// (get) Token: 0x060208CB RID: 133323 RVA: 0x0092F674 File Offset: 0x0092D874
		// (set) Token: 0x060208CC RID: 133324 RVA: 0x0092F6AD File Offset: 0x0092D8AD
		public FPointerToUberGraphFrame UberGraphFrame
		{
			get
			{
				base.FastCheckIsValid();
				FPointerToUberGraphFrame result;
				if ((result = this._UberGraphFrame) == null)
				{
					result = (this._UberGraphFrame = new FPointerToUberGraphFrame(base.NativePtr + (IntPtr)BP_SceneActorsChange_C.__PropertyOffset_0, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FPointerToUberGraphFrame.StaticStruct(), base.NativePtr + (IntPtr)BP_SceneActorsChange_C.__PropertyOffset_0, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17003615 RID: 13845
		// (get) Token: 0x060208CD RID: 133325 RVA: 0x0092F6CE File Offset: 0x0092D8CE
		// (set) Token: 0x060208CE RID: 133326 RVA: 0x0092F6E2 File Offset: 0x0092D8E2
		[Nullable(2)]
		public unsafe USceneComponent DefaultSceneRoot
		{
			[NullableContext(2)]
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<USceneComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_SceneActorsChange_C.__PropertyOffset_1);
			}
			[NullableContext(2)]
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_SceneActorsChange_C.__PropertyOffset_1, value);
			}
		}

		// Token: 0x17003616 RID: 13846
		// (get) Token: 0x060208CF RID: 133327 RVA: 0x0092F6F7 File Offset: 0x0092D8F7
		// (set) Token: 0x060208D0 RID: 133328 RVA: 0x0092F707 File Offset: 0x0092D907
		public unsafe float Delta_Seconds
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SceneActorsChange_C.__PropertyOffset_2);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_SceneActorsChange_C.__PropertyOffset_2) = value;
			}
		}

		// Token: 0x17003617 RID: 13847
		// (get) Token: 0x060208D1 RID: 133329 RVA: 0x0092F718 File Offset: 0x0092D918
		// (set) Token: 0x060208D2 RID: 133330 RVA: 0x0092F728 File Offset: 0x0092D928
		public unsafe bool IsTick
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SceneActorsChange_C.__PropertyOffset_3) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_SceneActorsChange_C.__PropertyOffset_3) = (value ? 1 : 0);
			}
		}

		// Token: 0x17003618 RID: 13848
		// (get) Token: 0x060208D3 RID: 133331 RVA: 0x0092F739 File Offset: 0x0092D939
		// (set) Token: 0x060208D4 RID: 133332 RVA: 0x0092F749 File Offset: 0x0092D949
		public unsafe float Time
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SceneActorsChange_C.__PropertyOffset_4);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_SceneActorsChange_C.__PropertyOffset_4) = value;
			}
		}

		// Token: 0x17003619 RID: 13849
		// (get) Token: 0x060208D5 RID: 133333 RVA: 0x0092F75A File Offset: 0x0092D95A
		// (set) Token: 0x060208D6 RID: 133334 RVA: 0x0092F76A File Offset: 0x0092D96A
		public unsafe float Duration
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SceneActorsChange_C.__PropertyOffset_5);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_SceneActorsChange_C.__PropertyOffset_5) = value;
			}
		}

		// Token: 0x1700361A RID: 13850
		// (get) Token: 0x060208D7 RID: 133335 RVA: 0x0092F77C File Offset: 0x0092D97C
		// (set) Token: 0x060208D8 RID: 133336 RVA: 0x0092F7B5 File Offset: 0x0092D9B5
		public TArray<ALight> LightGroup_01
		{
			get
			{
				base.FastCheckIsValid();
				TArray<ALight> result;
				if ((result = this._LightGroup_01) == null)
				{
					result = (this._LightGroup_01 = new TArray<ALight>(base.NativePtr + (IntPtr)BP_SceneActorsChange_C.__PropertyOffset_6, this));
				}
				return result;
			}
			set
			{
				this.LightGroup_01.CopyAssign(value);
			}
		}

		// Token: 0x1700361B RID: 13851
		// (get) Token: 0x060208D9 RID: 133337 RVA: 0x0092F7C4 File Offset: 0x0092D9C4
		// (set) Token: 0x060208DA RID: 133338 RVA: 0x0092F7FD File Offset: 0x0092D9FD
		public TArray<ALight> LightGroup_02
		{
			get
			{
				base.FastCheckIsValid();
				TArray<ALight> result;
				if ((result = this._LightGroup_02) == null)
				{
					result = (this._LightGroup_02 = new TArray<ALight>(base.NativePtr + (IntPtr)BP_SceneActorsChange_C.__PropertyOffset_7, this));
				}
				return result;
			}
			set
			{
				this.LightGroup_02.CopyAssign(value);
			}
		}

		// Token: 0x1700361C RID: 13852
		// (get) Token: 0x060208DB RID: 133339 RVA: 0x0092F80C File Offset: 0x0092DA0C
		// (set) Token: 0x060208DC RID: 133340 RVA: 0x0092F845 File Offset: 0x0092DA45
		public TArray<float> LightsIntensity_01
		{
			get
			{
				base.FastCheckIsValid();
				TArray<float> result;
				if ((result = this._LightsIntensity_01) == null)
				{
					result = (this._LightsIntensity_01 = new TArray<float>(base.NativePtr + (IntPtr)BP_SceneActorsChange_C.__PropertyOffset_8, this));
				}
				return result;
			}
			set
			{
				this.LightsIntensity_01.CopyAssign(value);
			}
		}

		// Token: 0x1700361D RID: 13853
		// (get) Token: 0x060208DD RID: 133341 RVA: 0x0092F854 File Offset: 0x0092DA54
		// (set) Token: 0x060208DE RID: 133342 RVA: 0x0092F88D File Offset: 0x0092DA8D
		public TArray<float> LightsIntensity_02
		{
			get
			{
				base.FastCheckIsValid();
				TArray<float> result;
				if ((result = this._LightsIntensity_02) == null)
				{
					result = (this._LightsIntensity_02 = new TArray<float>(base.NativePtr + (IntPtr)BP_SceneActorsChange_C.__PropertyOffset_9, this));
				}
				return result;
			}
			set
			{
				this.LightsIntensity_02.CopyAssign(value);
			}
		}

		// Token: 0x1700361E RID: 13854
		// (get) Token: 0x060208DF RID: 133343 RVA: 0x0092F89B File Offset: 0x0092DA9B
		// (set) Token: 0x060208E0 RID: 133344 RVA: 0x0092F8AB File Offset: 0x0092DAAB
		public unsafe bool TurnOffOrOn
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SceneActorsChange_C.__PropertyOffset_10) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_SceneActorsChange_C.__PropertyOffset_10) = (value ? 1 : 0);
			}
		}

		// Token: 0x1700361F RID: 13855
		// (get) Token: 0x060208E1 RID: 133345 RVA: 0x0092F8BC File Offset: 0x0092DABC
		// (set) Token: 0x060208E2 RID: 133346 RVA: 0x0092F8F5 File Offset: 0x0092DAF5
		public TArray<BP_KuroLightDecal_C> DecalGroup_01
		{
			get
			{
				base.FastCheckIsValid();
				TArray<BP_KuroLightDecal_C> result;
				if ((result = this._DecalGroup_01) == null)
				{
					result = (this._DecalGroup_01 = new TArray<BP_KuroLightDecal_C>(base.NativePtr + (IntPtr)BP_SceneActorsChange_C.__PropertyOffset_11, this));
				}
				return result;
			}
			set
			{
				this.DecalGroup_01.CopyAssign(value);
			}
		}

		// Token: 0x17003620 RID: 13856
		// (get) Token: 0x060208E3 RID: 133347 RVA: 0x0092F904 File Offset: 0x0092DB04
		// (set) Token: 0x060208E4 RID: 133348 RVA: 0x0092F93D File Offset: 0x0092DB3D
		public TArray<BP_KuroLightDecal_C> DecalGroup_02
		{
			get
			{
				base.FastCheckIsValid();
				TArray<BP_KuroLightDecal_C> result;
				if ((result = this._DecalGroup_02) == null)
				{
					result = (this._DecalGroup_02 = new TArray<BP_KuroLightDecal_C>(base.NativePtr + (IntPtr)BP_SceneActorsChange_C.__PropertyOffset_12, this));
				}
				return result;
			}
			set
			{
				this.DecalGroup_02.CopyAssign(value);
			}
		}

		// Token: 0x17003621 RID: 13857
		// (get) Token: 0x060208E5 RID: 133349 RVA: 0x0092F94C File Offset: 0x0092DB4C
		// (set) Token: 0x060208E6 RID: 133350 RVA: 0x0092F985 File Offset: 0x0092DB85
		public TArray<float> EmissiveIntensity_01
		{
			get
			{
				base.FastCheckIsValid();
				TArray<float> result;
				if ((result = this._EmissiveIntensity_01) == null)
				{
					result = (this._EmissiveIntensity_01 = new TArray<float>(base.NativePtr + (IntPtr)BP_SceneActorsChange_C.__PropertyOffset_13, this));
				}
				return result;
			}
			set
			{
				this.EmissiveIntensity_01.CopyAssign(value);
			}
		}

		// Token: 0x17003622 RID: 13858
		// (get) Token: 0x060208E7 RID: 133351 RVA: 0x0092F994 File Offset: 0x0092DB94
		// (set) Token: 0x060208E8 RID: 133352 RVA: 0x0092F9CD File Offset: 0x0092DBCD
		public TArray<float> EmissiveIntensity_02
		{
			get
			{
				base.FastCheckIsValid();
				TArray<float> result;
				if ((result = this._EmissiveIntensity_02) == null)
				{
					result = (this._EmissiveIntensity_02 = new TArray<float>(base.NativePtr + (IntPtr)BP_SceneActorsChange_C.__PropertyOffset_14, this));
				}
				return result;
			}
			set
			{
				this.EmissiveIntensity_02.CopyAssign(value);
			}
		}

		// Token: 0x17003623 RID: 13859
		// (get) Token: 0x060208E9 RID: 133353 RVA: 0x0092F9DC File Offset: 0x0092DBDC
		// (set) Token: 0x060208EA RID: 133354 RVA: 0x0092FA15 File Offset: 0x0092DC15
		public TArray<BP_EffectActor_C> EffectGroup_01
		{
			get
			{
				base.FastCheckIsValid();
				TArray<BP_EffectActor_C> result;
				if ((result = this._EffectGroup_01) == null)
				{
					result = (this._EffectGroup_01 = new TArray<BP_EffectActor_C>(base.NativePtr + (IntPtr)BP_SceneActorsChange_C.__PropertyOffset_15, this));
				}
				return result;
			}
			set
			{
				this.EffectGroup_01.CopyAssign(value);
			}
		}

		// Token: 0x17003624 RID: 13860
		// (get) Token: 0x060208EB RID: 133355 RVA: 0x0092FA24 File Offset: 0x0092DC24
		// (set) Token: 0x060208EC RID: 133356 RVA: 0x0092FA5D File Offset: 0x0092DC5D
		public TArray<BP_EffectActor_C> EffectGroup_02
		{
			get
			{
				base.FastCheckIsValid();
				TArray<BP_EffectActor_C> result;
				if ((result = this._EffectGroup_02) == null)
				{
					result = (this._EffectGroup_02 = new TArray<BP_EffectActor_C>(base.NativePtr + (IntPtr)BP_SceneActorsChange_C.__PropertyOffset_16, this));
				}
				return result;
			}
			set
			{
				this.EffectGroup_02.CopyAssign(value);
			}
		}

		// Token: 0x17003625 RID: 13861
		// (get) Token: 0x060208ED RID: 133357 RVA: 0x0092FA6C File Offset: 0x0092DC6C
		// (set) Token: 0x060208EE RID: 133358 RVA: 0x0092FAA5 File Offset: 0x0092DCA5
		public TArray<SEffectColorParameter> EffectColor_01
		{
			get
			{
				base.FastCheckIsValid();
				TArray<SEffectColorParameter> result;
				if ((result = this._EffectColor_01) == null)
				{
					result = (this._EffectColor_01 = new TArray<SEffectColorParameter>(base.NativePtr + (IntPtr)BP_SceneActorsChange_C.__PropertyOffset_17, this));
				}
				return result;
			}
			set
			{
				this.EffectColor_01.CopyAssign(value);
			}
		}

		// Token: 0x17003626 RID: 13862
		// (get) Token: 0x060208EF RID: 133359 RVA: 0x0092FAB4 File Offset: 0x0092DCB4
		// (set) Token: 0x060208F0 RID: 133360 RVA: 0x0092FAED File Offset: 0x0092DCED
		public TArray<SEffectColorParameter> EffectColor_02
		{
			get
			{
				base.FastCheckIsValid();
				TArray<SEffectColorParameter> result;
				if ((result = this._EffectColor_02) == null)
				{
					result = (this._EffectColor_02 = new TArray<SEffectColorParameter>(base.NativePtr + (IntPtr)BP_SceneActorsChange_C.__PropertyOffset_18, this));
				}
				return result;
			}
			set
			{
				this.EffectColor_02.CopyAssign(value);
			}
		}

		// Token: 0x060208F1 RID: 133361 RVA: 0x0092FAFC File Offset: 0x0092DCFC
		[NullableContext(2)]
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void SetEffect([Nullable(new byte[]
		{
			2,
			1
		})] ref TArray<BP_EffectActor_C> Array, ref TArray<SEffectColorParameter> List, bool bNewHidden)
		{
			BP_SceneActorsChange_C.__SetEffect_FunctionParams* ptr = stackalloc BP_SceneActorsChange_C.__SetEffect_FunctionParams[(UIntPtr)135] + 15L / (long)sizeof(BP_SceneActorsChange_C.__SetEffect_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_SceneActorsChange_C.__SetEffect_NativeFunctionPtr, (void*)ptr, 1);
			TArray<BP_EffectActor_C> tarray = Array;
			if (tarray != null)
			{
				tarray.MoveTo(&ptr->Array);
			}
			TArray<SEffectColorParameter> tarray2 = List;
			if (tarray2 != null)
			{
				tarray2.MoveTo(&ptr->List);
			}
			ptr->bNewHidden = bNewHidden;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_SceneActorsChange_C.__SetEffect_NativeFunctionPtr, (void*)ptr);
			TArray<BP_EffectActor_C> tarray3 = Array;
			if (tarray3 != null)
			{
				tarray3.MoveAssign(&ptr->Array);
			}
			TArray<SEffectColorParameter> tarray4 = List;
			if (tarray4 != null)
			{
				tarray4.MoveAssign(&ptr->List);
			}
			UnrealReflectionUtils.DestroyStruct(BP_SceneActorsChange_C.__SetEffect_NativeFunctionPtr, (void*)ptr, 1);
		}

		// Token: 0x060208F2 RID: 133362 RVA: 0x0092FBA8 File Offset: 0x0092DDA8
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void EffectUpdate([Nullable(new byte[]
		{
			2,
			1
		})] ref TArray<BP_EffectActor_C> Array, [Nullable(new byte[]
		{
			2,
			1
		})] ref TArray<BP_EffectActor_C> Array1, float ElapsedTime)
		{
			BP_SceneActorsChange_C.__EffectUpdate_FunctionParams* ptr = stackalloc BP_SceneActorsChange_C.__EffectUpdate_FunctionParams[(UIntPtr)271] + 15L / (long)sizeof(BP_SceneActorsChange_C.__EffectUpdate_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_SceneActorsChange_C.__EffectUpdate_NativeFunctionPtr, (void*)ptr, 1);
			TArray<BP_EffectActor_C> tarray = Array;
			if (tarray != null)
			{
				tarray.MoveTo(&ptr->Array);
			}
			TArray<BP_EffectActor_C> tarray2 = Array1;
			if (tarray2 != null)
			{
				tarray2.MoveTo(&ptr->Array1);
			}
			ptr->ElapsedTime = ElapsedTime;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_SceneActorsChange_C.__EffectUpdate_NativeFunctionPtr, (void*)ptr);
			TArray<BP_EffectActor_C> tarray3 = Array;
			if (tarray3 != null)
			{
				tarray3.MoveAssign(&ptr->Array);
			}
			TArray<BP_EffectActor_C> tarray4 = Array1;
			if (tarray4 != null)
			{
				tarray4.MoveAssign(&ptr->Array1);
			}
			UnrealReflectionUtils.DestroyStruct(BP_SceneActorsChange_C.__EffectUpdate_NativeFunctionPtr, (void*)ptr, 1);
		}

		// Token: 0x060208F3 RID: 133363 RVA: 0x0092FC54 File Offset: 0x0092DE54
		[NullableContext(2)]
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void GetEffectParam([Nullable(new byte[]
		{
			2,
			1
		})] ref TArray<BP_EffectActor_C> Array, in TArray<SEffectColorParameter> TargetArray, bool bHidden)
		{
			BP_SceneActorsChange_C.__GetEffectParam_FunctionParams* ptr = stackalloc BP_SceneActorsChange_C.__GetEffectParam_FunctionParams[(UIntPtr)119] + 15L / (long)sizeof(BP_SceneActorsChange_C.__GetEffectParam_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_SceneActorsChange_C.__GetEffectParam_NativeFunctionPtr, (void*)ptr, 1);
			TArray<BP_EffectActor_C> tarray = Array;
			if (tarray != null)
			{
				tarray.MoveTo(&ptr->Array);
			}
			object obj = TargetArray;
			if (obj != null)
			{
				obj.MoveTo(&ptr->TargetArray);
			}
			ptr->bHidden = bHidden;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_SceneActorsChange_C.__GetEffectParam_NativeFunctionPtr, (void*)ptr);
			TArray<BP_EffectActor_C> tarray2 = Array;
			if (tarray2 != null)
			{
				tarray2.MoveAssign(&ptr->Array);
			}
			object obj2 = TargetArray;
			if (obj2 != null)
			{
				obj2.MoveAssign(&ptr->TargetArray);
			}
			UnrealReflectionUtils.DestroyStruct(BP_SceneActorsChange_C.__GetEffectParam_NativeFunctionPtr, (void*)ptr, 1);
		}

		// Token: 0x060208F4 RID: 133364 RVA: 0x0092FCFC File Offset: 0x0092DEFC
		[NullableContext(2)]
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void SetDecal([Nullable(new byte[]
		{
			2,
			1
		})] ref TArray<BP_KuroLightDecal_C> Array, ref TArray<float> List, bool bNewHidden)
		{
			BP_SceneActorsChange_C.__SetDecal_FunctionParams* ptr = stackalloc BP_SceneActorsChange_C.__SetDecal_FunctionParams[(UIntPtr)95] + 15L / (long)sizeof(BP_SceneActorsChange_C.__SetDecal_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_SceneActorsChange_C.__SetDecal_NativeFunctionPtr, (void*)ptr, 1);
			TArray<BP_KuroLightDecal_C> tarray = Array;
			if (tarray != null)
			{
				tarray.MoveTo(&ptr->Array);
			}
			TArray<float> tarray2 = List;
			if (tarray2 != null)
			{
				tarray2.MoveTo(&ptr->List);
			}
			ptr->bNewHidden = bNewHidden;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_SceneActorsChange_C.__SetDecal_NativeFunctionPtr, (void*)ptr);
			TArray<BP_KuroLightDecal_C> tarray3 = Array;
			if (tarray3 != null)
			{
				tarray3.MoveAssign(&ptr->Array);
			}
			TArray<float> tarray4 = List;
			if (tarray4 != null)
			{
				tarray4.MoveAssign(&ptr->List);
			}
			UnrealReflectionUtils.DestroyStruct(BP_SceneActorsChange_C.__SetDecal_NativeFunctionPtr, (void*)ptr, 1);
		}

		// Token: 0x060208F5 RID: 133365 RVA: 0x0092FDA4 File Offset: 0x0092DFA4
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void DecalUpdate([Nullable(new byte[]
		{
			2,
			1
		})] ref TArray<BP_KuroLightDecal_C> Array, [Nullable(new byte[]
		{
			2,
			1
		})] ref TArray<BP_KuroLightDecal_C> Array1, float ElapsedTime)
		{
			BP_SceneActorsChange_C.__DecalUpdate_FunctionParams* ptr = stackalloc BP_SceneActorsChange_C.__DecalUpdate_FunctionParams[(UIntPtr)183] + 15L / (long)sizeof(BP_SceneActorsChange_C.__DecalUpdate_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_SceneActorsChange_C.__DecalUpdate_NativeFunctionPtr, (void*)ptr, 1);
			TArray<BP_KuroLightDecal_C> tarray = Array;
			if (tarray != null)
			{
				tarray.MoveTo(&ptr->Array);
			}
			TArray<BP_KuroLightDecal_C> tarray2 = Array1;
			if (tarray2 != null)
			{
				tarray2.MoveTo(&ptr->Array1);
			}
			ptr->ElapsedTime = ElapsedTime;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_SceneActorsChange_C.__DecalUpdate_NativeFunctionPtr, (void*)ptr);
			TArray<BP_KuroLightDecal_C> tarray3 = Array;
			if (tarray3 != null)
			{
				tarray3.MoveAssign(&ptr->Array);
			}
			TArray<BP_KuroLightDecal_C> tarray4 = Array1;
			if (tarray4 != null)
			{
				tarray4.MoveAssign(&ptr->Array1);
			}
			UnrealReflectionUtils.DestroyStruct(BP_SceneActorsChange_C.__DecalUpdate_NativeFunctionPtr, (void*)ptr, 1);
		}

		// Token: 0x060208F6 RID: 133366 RVA: 0x0092FE50 File Offset: 0x0092E050
		[NullableContext(2)]
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void GetDecalParam([Nullable(new byte[]
		{
			2,
			1
		})] ref TArray<BP_KuroLightDecal_C> Array, ref TArray<float> TargetArray, bool bNewHidden)
		{
			BP_SceneActorsChange_C.__GetDecalParam_FunctionParams* ptr = stackalloc BP_SceneActorsChange_C.__GetDecalParam_FunctionParams[(UIntPtr)111] + 15L / (long)sizeof(BP_SceneActorsChange_C.__GetDecalParam_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_SceneActorsChange_C.__GetDecalParam_NativeFunctionPtr, (void*)ptr, 1);
			TArray<BP_KuroLightDecal_C> tarray = Array;
			if (tarray != null)
			{
				tarray.MoveTo(&ptr->Array);
			}
			TArray<float> tarray2 = TargetArray;
			if (tarray2 != null)
			{
				tarray2.MoveTo(&ptr->TargetArray);
			}
			ptr->bNewHidden = bNewHidden;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_SceneActorsChange_C.__GetDecalParam_NativeFunctionPtr, (void*)ptr);
			TArray<BP_KuroLightDecal_C> tarray3 = Array;
			if (tarray3 != null)
			{
				tarray3.MoveAssign(&ptr->Array);
			}
			TArray<float> tarray4 = TargetArray;
			if (tarray4 != null)
			{
				tarray4.MoveAssign(&ptr->TargetArray);
			}
			UnrealReflectionUtils.DestroyStruct(BP_SceneActorsChange_C.__GetDecalParam_NativeFunctionPtr, (void*)ptr, 1);
		}

		// Token: 0x060208F7 RID: 133367 RVA: 0x0092FEF8 File Offset: 0x0092E0F8
		[NullableContext(2)]
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void SetLightsIntensity([Nullable(new byte[]
		{
			2,
			1
		})] ref TArray<ALight> Array, ref TArray<float> LightsIntensity, bool Hidden)
		{
			BP_SceneActorsChange_C.__SetLightsIntensity_FunctionParams* ptr = stackalloc BP_SceneActorsChange_C.__SetLightsIntensity_FunctionParams[(UIntPtr)103] + 15L / (long)sizeof(BP_SceneActorsChange_C.__SetLightsIntensity_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_SceneActorsChange_C.__SetLightsIntensity_NativeFunctionPtr, (void*)ptr, 1);
			TArray<ALight> tarray = Array;
			if (tarray != null)
			{
				tarray.MoveTo(&ptr->Array);
			}
			TArray<float> tarray2 = LightsIntensity;
			if (tarray2 != null)
			{
				tarray2.MoveTo(&ptr->LightsIntensity);
			}
			ptr->Hidden = Hidden;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_SceneActorsChange_C.__SetLightsIntensity_NativeFunctionPtr, (void*)ptr);
			TArray<ALight> tarray3 = Array;
			if (tarray3 != null)
			{
				tarray3.MoveAssign(&ptr->Array);
			}
			TArray<float> tarray4 = LightsIntensity;
			if (tarray4 != null)
			{
				tarray4.MoveAssign(&ptr->LightsIntensity);
			}
			UnrealReflectionUtils.DestroyStruct(BP_SceneActorsChange_C.__SetLightsIntensity_NativeFunctionPtr, (void*)ptr, 1);
		}

		// Token: 0x060208F8 RID: 133368 RVA: 0x0092FFA0 File Offset: 0x0092E1A0
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void LightsUpdate([Nullable(new byte[]
		{
			2,
			1
		})] ref TArray<ALight> Group01, [Nullable(new byte[]
		{
			2,
			1
		})] ref TArray<ALight> Group02, float ElapsedTime)
		{
			BP_SceneActorsChange_C.__LightsUpdate_FunctionParams* ptr = stackalloc BP_SceneActorsChange_C.__LightsUpdate_FunctionParams[(UIntPtr)191] + 15L / (long)sizeof(BP_SceneActorsChange_C.__LightsUpdate_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_SceneActorsChange_C.__LightsUpdate_NativeFunctionPtr, (void*)ptr, 1);
			TArray<ALight> tarray = Group01;
			if (tarray != null)
			{
				tarray.MoveTo(&ptr->Group01);
			}
			TArray<ALight> tarray2 = Group02;
			if (tarray2 != null)
			{
				tarray2.MoveTo(&ptr->Group02);
			}
			ptr->ElapsedTime = ElapsedTime;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_SceneActorsChange_C.__LightsUpdate_NativeFunctionPtr, (void*)ptr);
			TArray<ALight> tarray3 = Group01;
			if (tarray3 != null)
			{
				tarray3.MoveAssign(&ptr->Group01);
			}
			TArray<ALight> tarray4 = Group02;
			if (tarray4 != null)
			{
				tarray4.MoveAssign(&ptr->Group02);
			}
			UnrealReflectionUtils.DestroyStruct(BP_SceneActorsChange_C.__LightsUpdate_NativeFunctionPtr, (void*)ptr, 1);
		}

		// Token: 0x060208F9 RID: 133369 RVA: 0x0093004C File Offset: 0x0092E24C
		[NullableContext(2)]
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void GetLightsIntensity([Nullable(new byte[]
		{
			2,
			1
		})] ref TArray<ALight> Array, in TArray<float> TargetArray, bool bHidden)
		{
			BP_SceneActorsChange_C.__GetLightsIntensity_FunctionParams* ptr = stackalloc BP_SceneActorsChange_C.__GetLightsIntensity_FunctionParams[(UIntPtr)103] + 15L / (long)sizeof(BP_SceneActorsChange_C.__GetLightsIntensity_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_SceneActorsChange_C.__GetLightsIntensity_NativeFunctionPtr, (void*)ptr, 1);
			TArray<ALight> tarray = Array;
			if (tarray != null)
			{
				tarray.MoveTo(&ptr->Array);
			}
			object obj = TargetArray;
			if (obj != null)
			{
				obj.MoveTo(&ptr->TargetArray);
			}
			ptr->bHidden = bHidden;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_SceneActorsChange_C.__GetLightsIntensity_NativeFunctionPtr, (void*)ptr);
			TArray<ALight> tarray2 = Array;
			if (tarray2 != null)
			{
				tarray2.MoveAssign(&ptr->Array);
			}
			object obj2 = TargetArray;
			if (obj2 != null)
			{
				obj2.MoveAssign(&ptr->TargetArray);
			}
			UnrealReflectionUtils.DestroyStruct(BP_SceneActorsChange_C.__GetLightsIntensity_NativeFunctionPtr, (void*)ptr, 1);
		}

		// Token: 0x060208FA RID: 133370 RVA: 0x009300F4 File Offset: 0x0092E2F4
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void Timer(ref float ElapsedTime)
		{
			BP_SceneActorsChange_C.__Timer_FunctionParams* ptr = stackalloc BP_SceneActorsChange_C.__Timer_FunctionParams[(UIntPtr)23] + 15L / (long)sizeof(BP_SceneActorsChange_C.__Timer_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_SceneActorsChange_C.__Timer_NativeFunctionPtr, (void*)ptr, 1);
			ptr->ElapsedTime = ElapsedTime;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_SceneActorsChange_C.__Timer_NativeFunctionPtr, (void*)ptr);
			ElapsedTime = ptr->ElapsedTime;
		}

		// Token: 0x060208FB RID: 133371 RVA: 0x00930144 File Offset: 0x0092E344
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void ActorsChange(bool IsTick)
		{
			BP_SceneActorsChange_C.__ActorsChange_FunctionParams* ptr = stackalloc BP_SceneActorsChange_C.__ActorsChange_FunctionParams[(UIntPtr)27] + 15L / (long)sizeof(BP_SceneActorsChange_C.__ActorsChange_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_SceneActorsChange_C.__ActorsChange_NativeFunctionPtr, (void*)ptr, 1);
			ptr->IsTick = IsTick;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_SceneActorsChange_C.__ActorsChange_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x060208FC RID: 133372 RVA: 0x0093018A File Offset: 0x0092E38A
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void ReceiveBeginPlay()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_SceneActorsChange_C.__ReceiveBeginPlay_NativeFunctionPtr, null);
		}

		// Token: 0x060208FD RID: 133373 RVA: 0x0093019E File Offset: 0x0092E39E
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected virtual void ReceiveBeginPlay_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_SceneActorsChange_C.__ReceiveBeginPlay_NativeFunctionPtr, null, 0);
		}

		// Token: 0x060208FE RID: 133374 RVA: 0x009301B4 File Offset: 0x0092E3B4
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void ReceiveTick(float DeltaSeconds)
		{
			BP_SceneActorsChange_C.__ReceiveTick_FunctionParams* ptr = stackalloc BP_SceneActorsChange_C.__ReceiveTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_SceneActorsChange_C.__ReceiveTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_SceneActorsChange_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_SceneActorsChange_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x060208FF RID: 133375 RVA: 0x009301FC File Offset: 0x0092E3FC
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe virtual void ReceiveTick_Implementation(float DeltaSeconds)
		{
			BP_SceneActorsChange_C.__ReceiveTick_FunctionParams* ptr = stackalloc BP_SceneActorsChange_C.__ReceiveTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_SceneActorsChange_C.__ReceiveTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_SceneActorsChange_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_SceneActorsChange_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x06020900 RID: 133376 RVA: 0x00930244 File Offset: 0x0092E444
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void EditorTick(float DeltaSeconds)
		{
			BP_SceneActorsChange_C.__EditorTick_FunctionParams* ptr = stackalloc BP_SceneActorsChange_C.__EditorTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_SceneActorsChange_C.__EditorTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_SceneActorsChange_C.__EditorTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_SceneActorsChange_C.__EditorTick_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x06020901 RID: 133377 RVA: 0x0093028C File Offset: 0x0092E48C
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe virtual void EditorTick_Implementation(float DeltaSeconds)
		{
			BP_SceneActorsChange_C.__EditorTick_FunctionParams* ptr = stackalloc BP_SceneActorsChange_C.__EditorTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_SceneActorsChange_C.__EditorTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_SceneActorsChange_C.__EditorTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_SceneActorsChange_C.__EditorTick_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x06020902 RID: 133378 RVA: 0x009302D4 File Offset: 0x0092E4D4
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe void ExecuteUbergraph_BP_SceneActorsChange(int EntryPoint)
		{
			BP_SceneActorsChange_C.__ExecuteUbergraph_BP_SceneActorsChange_FunctionParams* ptr = stackalloc BP_SceneActorsChange_C.__ExecuteUbergraph_BP_SceneActorsChange_FunctionParams[(UIntPtr)27] + 15L / (long)sizeof(BP_SceneActorsChange_C.__ExecuteUbergraph_BP_SceneActorsChange_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_SceneActorsChange_C.__ExecuteUbergraph_BP_SceneActorsChange_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EntryPoint = EntryPoint;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_SceneActorsChange_C.__ExecuteUbergraph_BP_SceneActorsChange_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x06020903 RID: 133379 RVA: 0x0093031B File Offset: 0x0092E51B
		protected BP_SceneActorsChange_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x04010483 RID: 66691
		public new const string __ObjectPath = "/Game/Aki/Render/RuntimeBP/Scene/BlueprintLevel/BP_SceneActorsChange.BP_SceneActorsChange_C";

		// Token: 0x04010484 RID: 66692
		private static IntPtr _ClassPtr;

		// Token: 0x04010485 RID: 66693
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x04010486 RID: 66694
		internal static int __PropertyOffset_0;

		// Token: 0x04010487 RID: 66695
		[Nullable(2)]
		private FPointerToUberGraphFrame _UberGraphFrame;

		// Token: 0x04010488 RID: 66696
		internal static int __PropertyOffset_1;

		// Token: 0x04010489 RID: 66697
		internal static int __PropertyOffset_2;

		// Token: 0x0401048A RID: 66698
		internal static int __PropertyOffset_3;

		// Token: 0x0401048B RID: 66699
		internal static int __PropertyOffset_4;

		// Token: 0x0401048C RID: 66700
		internal static int __PropertyOffset_5;

		// Token: 0x0401048D RID: 66701
		internal static int __PropertyOffset_6;

		// Token: 0x0401048E RID: 66702
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private TArray<ALight> _LightGroup_01;

		// Token: 0x0401048F RID: 66703
		internal static int __PropertyOffset_7;

		// Token: 0x04010490 RID: 66704
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private TArray<ALight> _LightGroup_02;

		// Token: 0x04010491 RID: 66705
		internal static int __PropertyOffset_8;

		// Token: 0x04010492 RID: 66706
		[Nullable(2)]
		private TArray<float> _LightsIntensity_01;

		// Token: 0x04010493 RID: 66707
		internal static int __PropertyOffset_9;

		// Token: 0x04010494 RID: 66708
		[Nullable(2)]
		private TArray<float> _LightsIntensity_02;

		// Token: 0x04010495 RID: 66709
		internal static int __PropertyOffset_10;

		// Token: 0x04010496 RID: 66710
		internal static int __PropertyOffset_11;

		// Token: 0x04010497 RID: 66711
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private TArray<BP_KuroLightDecal_C> _DecalGroup_01;

		// Token: 0x04010498 RID: 66712
		internal static int __PropertyOffset_12;

		// Token: 0x04010499 RID: 66713
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private TArray<BP_KuroLightDecal_C> _DecalGroup_02;

		// Token: 0x0401049A RID: 66714
		internal static int __PropertyOffset_13;

		// Token: 0x0401049B RID: 66715
		[Nullable(2)]
		private TArray<float> _EmissiveIntensity_01;

		// Token: 0x0401049C RID: 66716
		internal static int __PropertyOffset_14;

		// Token: 0x0401049D RID: 66717
		[Nullable(2)]
		private TArray<float> _EmissiveIntensity_02;

		// Token: 0x0401049E RID: 66718
		internal static int __PropertyOffset_15;

		// Token: 0x0401049F RID: 66719
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private TArray<BP_EffectActor_C> _EffectGroup_01;

		// Token: 0x040104A0 RID: 66720
		internal static int __PropertyOffset_16;

		// Token: 0x040104A1 RID: 66721
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private TArray<BP_EffectActor_C> _EffectGroup_02;

		// Token: 0x040104A2 RID: 66722
		internal static int __PropertyOffset_17;

		// Token: 0x040104A3 RID: 66723
		[Nullable(2)]
		private TArray<SEffectColorParameter> _EffectColor_01;

		// Token: 0x040104A4 RID: 66724
		internal static int __PropertyOffset_18;

		// Token: 0x040104A5 RID: 66725
		[Nullable(2)]
		private TArray<SEffectColorParameter> _EffectColor_02;

		// Token: 0x040104A6 RID: 66726
		private static IntPtr __SetEffect_NativeFunctionPtr;

		// Token: 0x040104A7 RID: 66727
		private static IntPtr __EffectUpdate_NativeFunctionPtr;

		// Token: 0x040104A8 RID: 66728
		private static IntPtr __GetEffectParam_NativeFunctionPtr;

		// Token: 0x040104A9 RID: 66729
		private static IntPtr __SetDecal_NativeFunctionPtr;

		// Token: 0x040104AA RID: 66730
		private static IntPtr __DecalUpdate_NativeFunctionPtr;

		// Token: 0x040104AB RID: 66731
		private static IntPtr __GetDecalParam_NativeFunctionPtr;

		// Token: 0x040104AC RID: 66732
		private static IntPtr __SetLightsIntensity_NativeFunctionPtr;

		// Token: 0x040104AD RID: 66733
		private static IntPtr __LightsUpdate_NativeFunctionPtr;

		// Token: 0x040104AE RID: 66734
		private static IntPtr __GetLightsIntensity_NativeFunctionPtr;

		// Token: 0x040104AF RID: 66735
		private static IntPtr __Timer_NativeFunctionPtr;

		// Token: 0x040104B0 RID: 66736
		private static IntPtr __ActorsChange_NativeFunctionPtr;

		// Token: 0x040104B1 RID: 66737
		private static IntPtr __ReceiveBeginPlay_NativeFunctionPtr;

		// Token: 0x040104B2 RID: 66738
		private static IntPtr __ReceiveTick_NativeFunctionPtr;

		// Token: 0x040104B3 RID: 66739
		private static IntPtr __EditorTick_NativeFunctionPtr;

		// Token: 0x040104B4 RID: 66740
		private static IntPtr __ExecuteUbergraph_BP_SceneActorsChange_NativeFunctionPtr;

		// Token: 0x020099D3 RID: 39379
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 120)]
		protected ref struct __SetEffect_FunctionParams
		{
			// Token: 0x04032087 RID: 204935
			[FieldOffset(0)]
			public byte Array;

			// Token: 0x04032088 RID: 204936
			[FieldOffset(16)]
			public byte List;

			// Token: 0x04032089 RID: 204937
			[FieldOffset(32)]
			public bool bNewHidden;
		}

		// Token: 0x020099D4 RID: 39380
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 256)]
		protected ref struct __EffectUpdate_FunctionParams
		{
			// Token: 0x0403208A RID: 204938
			[FieldOffset(0)]
			public byte Array;

			// Token: 0x0403208B RID: 204939
			[FieldOffset(16)]
			public byte Array1;

			// Token: 0x0403208C RID: 204940
			[FieldOffset(32)]
			public float ElapsedTime;
		}

		// Token: 0x020099D5 RID: 39381
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 104)]
		protected ref struct __GetEffectParam_FunctionParams
		{
			// Token: 0x0403208D RID: 204941
			[FieldOffset(0)]
			public byte Array;

			// Token: 0x0403208E RID: 204942
			[FieldOffset(16)]
			public byte TargetArray;

			// Token: 0x0403208F RID: 204943
			[FieldOffset(32)]
			public bool bHidden;
		}

		// Token: 0x020099D6 RID: 39382
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 80)]
		protected ref struct __SetDecal_FunctionParams
		{
			// Token: 0x04032090 RID: 204944
			[FieldOffset(0)]
			public byte Array;

			// Token: 0x04032091 RID: 204945
			[FieldOffset(16)]
			public byte List;

			// Token: 0x04032092 RID: 204946
			[FieldOffset(32)]
			public bool bNewHidden;
		}

		// Token: 0x020099D7 RID: 39383
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 168)]
		protected ref struct __DecalUpdate_FunctionParams
		{
			// Token: 0x04032093 RID: 204947
			[FieldOffset(0)]
			public byte Array;

			// Token: 0x04032094 RID: 204948
			[FieldOffset(16)]
			public byte Array1;

			// Token: 0x04032095 RID: 204949
			[FieldOffset(32)]
			public float ElapsedTime;
		}

		// Token: 0x020099D8 RID: 39384
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 96)]
		protected ref struct __GetDecalParam_FunctionParams
		{
			// Token: 0x04032096 RID: 204950
			[FieldOffset(0)]
			public byte Array;

			// Token: 0x04032097 RID: 204951
			[FieldOffset(16)]
			public byte TargetArray;

			// Token: 0x04032098 RID: 204952
			[FieldOffset(32)]
			public bool bNewHidden;
		}

		// Token: 0x020099D9 RID: 39385
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 88)]
		protected ref struct __SetLightsIntensity_FunctionParams
		{
			// Token: 0x04032099 RID: 204953
			[FieldOffset(0)]
			public byte Array;

			// Token: 0x0403209A RID: 204954
			[FieldOffset(16)]
			public byte LightsIntensity;

			// Token: 0x0403209B RID: 204955
			[FieldOffset(32)]
			public bool Hidden;
		}

		// Token: 0x020099DA RID: 39386
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 176)]
		protected ref struct __LightsUpdate_FunctionParams
		{
			// Token: 0x0403209C RID: 204956
			[FieldOffset(0)]
			public byte Group01;

			// Token: 0x0403209D RID: 204957
			[FieldOffset(16)]
			public byte Group02;

			// Token: 0x0403209E RID: 204958
			[FieldOffset(32)]
			public float ElapsedTime;
		}

		// Token: 0x020099DB RID: 39387
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 88)]
		protected ref struct __GetLightsIntensity_FunctionParams
		{
			// Token: 0x0403209F RID: 204959
			[FieldOffset(0)]
			public byte Array;

			// Token: 0x040320A0 RID: 204960
			[FieldOffset(16)]
			public byte TargetArray;

			// Token: 0x040320A1 RID: 204961
			[FieldOffset(32)]
			public bool bHidden;
		}

		// Token: 0x020099DC RID: 39388
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 8)]
		protected ref struct __Timer_FunctionParams
		{
			// Token: 0x040320A2 RID: 204962
			[FieldOffset(0)]
			public float ElapsedTime;
		}

		// Token: 0x020099DD RID: 39389
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 12)]
		protected ref struct __ActorsChange_FunctionParams
		{
			// Token: 0x040320A3 RID: 204963
			[FieldOffset(0)]
			public bool IsTick;
		}

		// Token: 0x020099DE RID: 39390
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 4)]
		protected new ref struct __ReceiveTick_FunctionParams
		{
			// Token: 0x040320A4 RID: 204964
			[FieldOffset(0)]
			public float DeltaSeconds;
		}

		// Token: 0x020099DF RID: 39391
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 4)]
		protected new ref struct __EditorTick_FunctionParams
		{
			// Token: 0x040320A5 RID: 204965
			[FieldOffset(0)]
			public float DeltaSeconds;
		}

		// Token: 0x020099E0 RID: 39392
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 12)]
		protected ref struct __ExecuteUbergraph_BP_SceneActorsChange_FunctionParams
		{
			// Token: 0x040320A6 RID: 204966
			[FieldOffset(0)]
			public int EntryPoint;
		}
	}
}
