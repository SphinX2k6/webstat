using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Service.Flags;
using UnrealEngine.Utils;

// Token: 0x02000D9C RID: 3484
[NullableContext(1)]
[Nullable(0)]
[UClass("/Game/Aki/TypeScript/Game/AnimNotifyState/", EClassFlags.CLASS_None)]
[UnrealObjectPath("/Game/Aki/TypeScript/Game/AnimNotifyState/TsAnimNotifyStateVolumeFogColor.TsAnimNotifyStateVolumeFogColor_C")]
public class TsAnimNotifyStateVolumeFogColor : TsAnimNotifyStateBase, IUnrealUObject, IUnrealObject
{
	// Token: 0x170004BA RID: 1210
	// (get) Token: 0x06004DB5 RID: 19893 RVA: 0x000AFDE1 File Offset: 0x000ADFE1
	// (set) Token: 0x06004DB6 RID: 19894 RVA: 0x000AFDF5 File Offset: 0x000ADFF5
	[Nullable(2)]
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe UMaterialParameterCollection MPCObject
	{
		[NullableContext(2)]
		get
		{
			return BuiltinUtils.ObjectPropertyGetter<UMaterialParameterCollection>(base.NativePtr / (IntPtr)sizeof(void*) + TsAnimNotifyStateVolumeFogColor.__PropertyOffset_MPCObject);
		}
		[NullableContext(2)]
		set
		{
			BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + TsAnimNotifyStateVolumeFogColor.__PropertyOffset_MPCObject, value);
		}
	}

	// Token: 0x170004BB RID: 1211
	// (get) Token: 0x06004DB7 RID: 19895 RVA: 0x000AFE0A File Offset: 0x000AE00A
	// (set) Token: 0x06004DB8 RID: 19896 RVA: 0x000AFE1E File Offset: 0x000AE01E
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe FLinearColor ActiveColor
	{
		get
		{
			return *(base.NativePtr + (IntPtr)TsAnimNotifyStateVolumeFogColor.__PropertyOffset_ActiveColor);
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsAnimNotifyStateVolumeFogColor.__PropertyOffset_ActiveColor) = value;
		}
	}

	// Token: 0x170004BC RID: 1212
	// (get) Token: 0x06004DB9 RID: 19897 RVA: 0x000AFE33 File Offset: 0x000AE033
	// (set) Token: 0x06004DBA RID: 19898 RVA: 0x000AFE43 File Offset: 0x000AE043
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe bool bUseBlend
	{
		get
		{
			return *(base.NativePtr + (IntPtr)TsAnimNotifyStateVolumeFogColor.__PropertyOffset_bUseBlend) != 0;
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsAnimNotifyStateVolumeFogColor.__PropertyOffset_bUseBlend) = (value ? 1 : 0);
		}
	}

	// Token: 0x170004BD RID: 1213
	// (get) Token: 0x06004DBB RID: 19899 RVA: 0x000AFE54 File Offset: 0x000AE054
	// (set) Token: 0x06004DBC RID: 19900 RVA: 0x000AFE64 File Offset: 0x000AE064
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe float BlendInDuration
	{
		get
		{
			return *(base.NativePtr + (IntPtr)TsAnimNotifyStateVolumeFogColor.__PropertyOffset_BlendInDuration);
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsAnimNotifyStateVolumeFogColor.__PropertyOffset_BlendInDuration) = value;
		}
	}

	// Token: 0x170004BE RID: 1214
	// (get) Token: 0x06004DBD RID: 19901 RVA: 0x000AFE75 File Offset: 0x000AE075
	// (set) Token: 0x06004DBE RID: 19902 RVA: 0x000AFE85 File Offset: 0x000AE085
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe float BlendOutDuration
	{
		get
		{
			return *(base.NativePtr + (IntPtr)TsAnimNotifyStateVolumeFogColor.__PropertyOffset_BlendOutDuration);
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsAnimNotifyStateVolumeFogColor.__PropertyOffset_BlendOutDuration) = value;
		}
	}

	// Token: 0x170004BF RID: 1215
	// (get) Token: 0x06004DBF RID: 19903 RVA: 0x000AFE98 File Offset: 0x000AE098
	// (set) Token: 0x06004DC0 RID: 19904 RVA: 0x000AFED1 File Offset: 0x000AE0D1
	[UProperty(EPropertyFlags.CPF_None)]
	public FKuroCurveFloat BlendInCurve
	{
		get
		{
			base.FastCheckIsValid();
			FKuroCurveFloat result;
			if ((result = this._BlendInCurve) == null)
			{
				result = (this._BlendInCurve = new FKuroCurveFloat(base.NativePtr + (IntPtr)TsAnimNotifyStateVolumeFogColor.__PropertyOffset_BlendInCurve, this));
			}
			return result;
		}
		set
		{
			UnrealReflectionUtils.CopyNativeStruct(FKuroCurveFloat.StaticStruct(), base.NativePtr + (IntPtr)TsAnimNotifyStateVolumeFogColor.__PropertyOffset_BlendInCurve, (value != null) ? value.NativePtr : ((IntPtr)0), 1, false);
		}
	}

	// Token: 0x170004C0 RID: 1216
	// (get) Token: 0x06004DC1 RID: 19905 RVA: 0x000AFEFC File Offset: 0x000AE0FC
	// (set) Token: 0x06004DC2 RID: 19906 RVA: 0x000AFF35 File Offset: 0x000AE135
	[UProperty(EPropertyFlags.CPF_None)]
	public FKuroCurveFloat BlendOutCurve
	{
		get
		{
			base.FastCheckIsValid();
			FKuroCurveFloat result;
			if ((result = this._BlendOutCurve) == null)
			{
				result = (this._BlendOutCurve = new FKuroCurveFloat(base.NativePtr + (IntPtr)TsAnimNotifyStateVolumeFogColor.__PropertyOffset_BlendOutCurve, this));
			}
			return result;
		}
		set
		{
			UnrealReflectionUtils.CopyNativeStruct(FKuroCurveFloat.StaticStruct(), base.NativePtr + (IntPtr)TsAnimNotifyStateVolumeFogColor.__PropertyOffset_BlendOutCurve, (value != null) ? value.NativePtr : ((IntPtr)0), 1, false);
		}
	}

	// Token: 0x06004DC3 RID: 19907 RVA: 0x000AFF60 File Offset: 0x000AE160
	private void setColor(USkeletalMeshComponent meshComp, FLinearColor color)
	{
		UKismetMaterialLibrary.SetVectorParameterValue(meshComp, this.MPCObject, FNameUtil.GetDynamicFName(TsAnimNotifyStateVolumeFogColor.PARAM_NAME).Value, color);
	}

	// Token: 0x06004DC4 RID: 19908 RVA: 0x000AFF8D File Offset: 0x000AE18D
	[NullableContext(2)]
	private float sampleAlpha(FKuroCurveFloat curve, float t)
	{
		if (curve != null)
		{
			return UKuroCurveLibrary.GetValue_Float(curve, t);
		}
		return t;
	}

	// Token: 0x06004DC5 RID: 19909 RVA: 0x000AFFA4 File Offset: 0x000AE1A4
	private FLinearColor lerpColor(FLinearColor a, FLinearColor b, float t)
	{
		return new FLinearColor(a.R + (b.R - a.R) * t, a.G + (b.G - a.G) * t, a.B + (b.B - a.B) * t, a.A + (b.A - a.A) * t);
	}

	// Token: 0x06004DC6 RID: 19910 RVA: 0x000B0010 File Offset: 0x000AE210
	[NullableContext(2)]
	[UFunction(EFunctionFlags.FUNC_BlueprintNativeEvent)]
	public unsafe override bool K2_NotifyBegin(USkeletalMeshComponent meshComp, UAnimSequenceBase animation, float totalDuration)
	{
		int num;
		IntPtr ufunctionPtrAndSizeChecked = UnrealReflectionUtils.GetUFunctionPtrAndSizeChecked(base.NativePtr, new FName("K2_NotifyBegin"), out num);
		byte* ptr = stackalloc byte[(UIntPtr)((num != 0) ? (num + 15) : 0)];
		UKuroAnimNotifyState.__K2_NotifyBegin_FunctionParams* ptr2 = null;
		if (num != 0)
		{
			ptr2 = ((UKuroAnimNotifyState.__K2_NotifyBegin_FunctionParams*)ptr + 15L / (long)sizeof(UKuroAnimNotifyState.__K2_NotifyBegin_FunctionParams) & -16L);
			UnrealReflectionUtils.InitializeStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
			*(&ptr2->MeshComp) = ((meshComp != null) ? meshComp.NativePtr : ((IntPtr)0));
			*(&ptr2->Animation) = ((animation != null) ? animation.NativePtr : ((IntPtr)0));
			ptr2->TotalDuration = totalDuration;
		}
		UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ufunctionPtrAndSizeChecked, (void*)ptr2);
		bool _Result = ptr2->__Result;
		if (num != 0)
		{
			UnrealReflectionUtils.DestroyStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
		}
		return _Result;
	}

	// Token: 0x06004DC7 RID: 19911 RVA: 0x000B00B8 File Offset: 0x000AE2B8
	[NullableContext(2)]
	protected virtual bool K2_NotifyBegin_Implementation(USkeletalMeshComponent meshComp, UAnimSequenceBase animation, float totalDuration)
	{
		UMaterialParameterCollection mpcobject = this.MPCObject;
		if (mpcobject == null || !mpcobject.IsValid())
		{
			return false;
		}
		this.OriginalColor = UKismetMaterialLibrary.GetVectorParameterValue(meshComp, this.MPCObject, FNameUtil.GetDynamicFName(TsAnimNotifyStateVolumeFogColor.PARAM_NAME).Value);
		if (!this.bUseBlend)
		{
			this.setColor(meshComp, this.ActiveColor);
			this.BlendPhase = TsAnimNotifyStateVolumeFogColor.EBlendPhase.Done;
			return true;
		}
		this.BlendElapsed = 0f;
		this.BlendPhase = ((this.BlendInDuration > 0f) ? TsAnimNotifyStateVolumeFogColor.EBlendPhase.In : TsAnimNotifyStateVolumeFogColor.EBlendPhase.Hold);
		return true;
	}

	// Token: 0x06004DC8 RID: 19912 RVA: 0x000B0144 File Offset: 0x000AE344
	[NullableContext(2)]
	[UFunction(EFunctionFlags.FUNC_BlueprintNativeEvent)]
	public unsafe override bool K2_NotifyTick(USkeletalMeshComponent meshComp, UAnimSequenceBase animation, float frameDeltaTime)
	{
		int num;
		IntPtr ufunctionPtrAndSizeChecked = UnrealReflectionUtils.GetUFunctionPtrAndSizeChecked(base.NativePtr, new FName("K2_NotifyTick"), out num);
		byte* ptr = stackalloc byte[(UIntPtr)((num != 0) ? (num + 15) : 0)];
		UKuroAnimNotifyState.__K2_NotifyTick_FunctionParams* ptr2 = null;
		if (num != 0)
		{
			ptr2 = ((UKuroAnimNotifyState.__K2_NotifyTick_FunctionParams*)ptr + 15L / (long)sizeof(UKuroAnimNotifyState.__K2_NotifyTick_FunctionParams) & -16L);
			UnrealReflectionUtils.InitializeStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
			*(&ptr2->MeshComp) = ((meshComp != null) ? meshComp.NativePtr : ((IntPtr)0));
			*(&ptr2->Animation) = ((animation != null) ? animation.NativePtr : ((IntPtr)0));
			ptr2->FrameDeltaTime = frameDeltaTime;
		}
		UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ufunctionPtrAndSizeChecked, (void*)ptr2);
		bool _Result = ptr2->__Result;
		if (num != 0)
		{
			UnrealReflectionUtils.DestroyStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
		}
		return _Result;
	}

	// Token: 0x06004DC9 RID: 19913 RVA: 0x000B01EC File Offset: 0x000AE3EC
	[NullableContext(2)]
	protected virtual bool K2_NotifyTick_Implementation(USkeletalMeshComponent meshComp, UAnimSequenceBase animation, float frameDeltaTime)
	{
		if (!this.bUseBlend || this.BlendPhase == TsAnimNotifyStateVolumeFogColor.EBlendPhase.Done)
		{
			return true;
		}
		UMaterialParameterCollection mpcobject = this.MPCObject;
		if (mpcobject == null || !mpcobject.IsValid())
		{
			return false;
		}
		this.BlendElapsed += frameDeltaTime;
		if (this.BlendPhase == TsAnimNotifyStateVolumeFogColor.EBlendPhase.In)
		{
			float num = (this.BlendInDuration > 0f) ? this.BlendInDuration : 1f;
			float num2 = Math.Min(this.BlendElapsed / num, 1f);
			float t = this.sampleAlpha(this.BlendInCurve, num2);
			this.setColor(meshComp, this.lerpColor(this.OriginalColor, this.ActiveColor, t));
			if (num2 >= 1f)
			{
				this.BlendPhase = TsAnimNotifyStateVolumeFogColor.EBlendPhase.Hold;
				this.BlendElapsed = 0f;
				this.setColor(meshComp, this.ActiveColor);
			}
			return true;
		}
		if (this.BlendPhase == TsAnimNotifyStateVolumeFogColor.EBlendPhase.Hold)
		{
			return true;
		}
		if (this.BlendPhase == TsAnimNotifyStateVolumeFogColor.EBlendPhase.Out)
		{
			float num3 = (this.BlendOutDuration > 0f) ? this.BlendOutDuration : 1f;
			float num4 = Math.Min(this.BlendElapsed / num3, 1f);
			float t2 = this.sampleAlpha(this.BlendOutCurve, num4);
			this.setColor(meshComp, this.lerpColor(this.BlendOutStartColor, this.OriginalColor, t2));
			if (num4 >= 1f)
			{
				this.BlendPhase = TsAnimNotifyStateVolumeFogColor.EBlendPhase.Done;
				this.setColor(meshComp, this.OriginalColor);
			}
		}
		return true;
	}

	// Token: 0x06004DCA RID: 19914 RVA: 0x000B0348 File Offset: 0x000AE548
	[NullableContext(2)]
	[UFunction(EFunctionFlags.FUNC_BlueprintNativeEvent)]
	public unsafe override bool K2_NotifyEnd(USkeletalMeshComponent meshComp, UAnimSequenceBase animation)
	{
		int num;
		IntPtr ufunctionPtrAndSizeChecked = UnrealReflectionUtils.GetUFunctionPtrAndSizeChecked(base.NativePtr, new FName("K2_NotifyEnd"), out num);
		byte* ptr = stackalloc byte[(UIntPtr)((num != 0) ? (num + 15) : 0)];
		UKuroAnimNotifyState.__K2_NotifyEnd_FunctionParams* ptr2 = null;
		if (num != 0)
		{
			ptr2 = ((UKuroAnimNotifyState.__K2_NotifyEnd_FunctionParams*)ptr + 15L / (long)sizeof(UKuroAnimNotifyState.__K2_NotifyEnd_FunctionParams) & -16L);
			UnrealReflectionUtils.InitializeStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
			*(&ptr2->MeshComp) = ((meshComp != null) ? meshComp.NativePtr : ((IntPtr)0));
			*(&ptr2->Animation) = ((animation != null) ? animation.NativePtr : ((IntPtr)0));
		}
		UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ufunctionPtrAndSizeChecked, (void*)ptr2);
		bool _Result = ptr2->__Result;
		if (num != 0)
		{
			UnrealReflectionUtils.DestroyStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
		}
		return _Result;
	}

	// Token: 0x06004DCB RID: 19915 RVA: 0x000B03E7 File Offset: 0x000AE5E7
	[NullableContext(2)]
	protected virtual bool K2_NotifyEnd_Implementation(USkeletalMeshComponent meshComp, UAnimSequenceBase animation)
	{
		UMaterialParameterCollection mpcobject = this.MPCObject;
		if (mpcobject == null || !mpcobject.IsValid())
		{
			return false;
		}
		this.setColor(meshComp, this.OriginalColor);
		this.BlendPhase = TsAnimNotifyStateVolumeFogColor.EBlendPhase.Done;
		return true;
	}

	// Token: 0x06004DCC RID: 19916 RVA: 0x000B0418 File Offset: 0x000AE618
	[UFunction(EFunctionFlags.FUNC_BlueprintNativeEvent)]
	public unsafe override string GetNotifyName()
	{
		int num;
		IntPtr ufunctionPtrAndSizeChecked = UnrealReflectionUtils.GetUFunctionPtrAndSizeChecked(base.NativePtr, new FName("GetNotifyName"), out num);
		byte* ptr = stackalloc byte[(UIntPtr)((num != 0) ? (num + 15) : 0)];
		UAnimNotifyState.__GetNotifyName_FunctionParams* ptr2 = null;
		if (num != 0)
		{
			ptr2 = ((UAnimNotifyState.__GetNotifyName_FunctionParams*)ptr + 15L / (long)sizeof(UAnimNotifyState.__GetNotifyName_FunctionParams) & -16L);
			UnrealReflectionUtils.InitializeStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
		}
		UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ufunctionPtrAndSizeChecked, (void*)ptr2);
		string result = FString.ToString((void*)(&ptr2->__Result));
		if (num != 0)
		{
			UnrealReflectionUtils.DestroyStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
		}
		return result;
	}

	// Token: 0x06004DCD RID: 19917 RVA: 0x000B0493 File Offset: 0x000AE693
	protected override string GetNotifyName_Implementation()
	{
		return "体积雾颜色控制通知状态";
	}

	// Token: 0x06004DCE RID: 19918 RVA: 0x000B049A File Offset: 0x000AE69A
	public new static UClassStackOnlyPtr StaticClass()
	{
		if (TsAnimNotifyStateVolumeFogColor._ClassPtr == IntPtr.Zero)
		{
			UObjectGlobals.StaticLoadClass(null, "/Game/Aki/TypeScript/Game/AnimNotifyState/TsAnimNotifyStateVolumeFogColor.TsAnimNotifyStateVolumeFogColor_C");
		}
		return TsAnimNotifyStateVolumeFogColor._ClassPtr;
	}

	// Token: 0x06004DCF RID: 19919 RVA: 0x000B04C0 File Offset: 0x000AE6C0
	public TsAnimNotifyStateVolumeFogColor() : this(BuiltinUtils.AllocNativeUObject(TsAnimNotifyStateVolumeFogColor.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
	{
	}

	// Token: 0x06004DD0 RID: 19920 RVA: 0x000B04E8 File Offset: 0x000AE6E8
	public TsAnimNotifyStateVolumeFogColor(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(TsAnimNotifyStateVolumeFogColor.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
	{
	}

	// Token: 0x06004DD1 RID: 19921 RVA: 0x000B051C File Offset: 0x000AE71C
	protected TsAnimNotifyStateVolumeFogColor(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
	{
	}

	// Token: 0x06004DD2 RID: 19922 RVA: 0x000B0570 File Offset: 0x000AE770
	[NullableContext(0)]
	protected unsafe virtual void __CPPCALL_K2_NotifyBegin_Implementation(UKuroAnimNotifyState.__K2_NotifyBegin_FunctionParams* __Params)
	{
		USkeletalMeshComponent orCreateUObjectByNativePointer = BuiltinUtils.GetOrCreateUObjectByNativePointer<USkeletalMeshComponent>(__Params->MeshComp);
		UAnimSequenceBase orCreateUObjectByNativePointer2 = BuiltinUtils.GetOrCreateUObjectByNativePointer<UAnimSequenceBase>(__Params->Animation);
		__Params->__Result = this.K2_NotifyBegin_Implementation(orCreateUObjectByNativePointer, orCreateUObjectByNativePointer2, __Params->TotalDuration);
	}

	// Token: 0x06004DD3 RID: 19923 RVA: 0x000B05AC File Offset: 0x000AE7AC
	[NullableContext(0)]
	protected unsafe virtual void __CPPCALL_K2_NotifyTick_Implementation(UKuroAnimNotifyState.__K2_NotifyTick_FunctionParams* __Params)
	{
		USkeletalMeshComponent orCreateUObjectByNativePointer = BuiltinUtils.GetOrCreateUObjectByNativePointer<USkeletalMeshComponent>(__Params->MeshComp);
		UAnimSequenceBase orCreateUObjectByNativePointer2 = BuiltinUtils.GetOrCreateUObjectByNativePointer<UAnimSequenceBase>(__Params->Animation);
		__Params->__Result = this.K2_NotifyTick_Implementation(orCreateUObjectByNativePointer, orCreateUObjectByNativePointer2, __Params->FrameDeltaTime);
	}

	// Token: 0x06004DD4 RID: 19924 RVA: 0x000B05E8 File Offset: 0x000AE7E8
	[NullableContext(0)]
	protected unsafe virtual void __CPPCALL_K2_NotifyEnd_Implementation(UKuroAnimNotifyState.__K2_NotifyEnd_FunctionParams* __Params)
	{
		USkeletalMeshComponent orCreateUObjectByNativePointer = BuiltinUtils.GetOrCreateUObjectByNativePointer<USkeletalMeshComponent>(__Params->MeshComp);
		UAnimSequenceBase orCreateUObjectByNativePointer2 = BuiltinUtils.GetOrCreateUObjectByNativePointer<UAnimSequenceBase>(__Params->Animation);
		__Params->__Result = this.K2_NotifyEnd_Implementation(orCreateUObjectByNativePointer, orCreateUObjectByNativePointer2);
	}

	// Token: 0x06004DD5 RID: 19925 RVA: 0x000B061B File Offset: 0x000AE81B
	[NullableContext(0)]
	protected unsafe virtual void __CPPCALL_GetNotifyName_Implementation(UAnimNotifyState.__GetNotifyName_FunctionParams* __Params)
	{
		FString.CopyFrom((void*)(&__Params->__Result), this.GetNotifyName_Implementation());
	}

	// Token: 0x0400166B RID: 5739
	protected FLinearColor OriginalColor = new FLinearColor(0f, 0f, 0f, 0f);

	// Token: 0x0400166C RID: 5740
	protected TsAnimNotifyStateVolumeFogColor.EBlendPhase BlendPhase;

	// Token: 0x0400166D RID: 5741
	protected float BlendElapsed;

	// Token: 0x0400166E RID: 5742
	protected FLinearColor BlendOutStartColor = new FLinearColor(0f, 0f, 0f, 0f);

	// Token: 0x0400166F RID: 5743
	[StaticVariableRuleIgnore]
	private static readonly string PARAM_NAME = "KuroVolumeColor";

	// Token: 0x04001670 RID: 5744
	public new const string __ObjectPath = "/Game/Aki/TypeScript/Game/AnimNotifyState/TsAnimNotifyStateVolumeFogColor.TsAnimNotifyStateVolumeFogColor_C";

	// Token: 0x04001671 RID: 5745
	private static IntPtr _ClassPtr;

	// Token: 0x04001672 RID: 5746
	private static IntPtr _ClassDefaultObjectPtr;

	// Token: 0x04001673 RID: 5747
	private static int __PropertyOffset_MPCObject;

	// Token: 0x04001674 RID: 5748
	private static int __PropertyOffset_ActiveColor;

	// Token: 0x04001675 RID: 5749
	private static int __PropertyOffset_bUseBlend;

	// Token: 0x04001676 RID: 5750
	private static int __PropertyOffset_BlendInDuration;

	// Token: 0x04001677 RID: 5751
	private static int __PropertyOffset_BlendOutDuration;

	// Token: 0x04001678 RID: 5752
	private static int __PropertyOffset_BlendInCurve;

	// Token: 0x04001679 RID: 5753
	[Nullable(2)]
	private FKuroCurveFloat _BlendInCurve;

	// Token: 0x0400167A RID: 5754
	private static int __PropertyOffset_BlendOutCurve;

	// Token: 0x0400167B RID: 5755
	[Nullable(2)]
	private FKuroCurveFloat _BlendOutCurve;

	// Token: 0x02007218 RID: 29208
	[NullableContext(0)]
	protected enum EBlendPhase
	{
		// Token: 0x04027A4F RID: 162383
		Done,
		// Token: 0x04027A50 RID: 162384
		Hold,
		// Token: 0x04027A51 RID: 162385
		In,
		// Token: 0x04027A52 RID: 162386
		Out
	}
}
