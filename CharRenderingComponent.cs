using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using AkiClient.Game.Aki.Character.Vehicle.Motor.Diy.HeadLight.Common.Component;
using AkiClient.Game.Aki.Render.RuntimeBP.Character;
using AkiClient.Game.Aki.Render.RuntimeBP.Character.Components;
using AkiClient.Game.Aki.Render.RuntimeBP.Character.Manager;
using AkiClient.Game.Aki.Render.RuntimeBP.Character.MaterialContainer;
using AkiClient.Game.Aki.Render.RuntimeBP.Character.MaterialController;
using AkiClient.Game.Aki.Render.RuntimeBP.Character.Npc;
using AkiClient.Game.Aki.Render.RuntimeBP.DecalShadow;
using AkiClient.Game.Aki.Render.RuntimeBP.Interaction;
using CSharpScript.Core.Common;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Render;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Service.Flags;
using UnrealEngine.Utils;

// Token: 0x020033FF RID: 13311
[UClass("/Game/Aki/TypeScript/Game/Render/Character/Manager/", EClassFlags.CLASS_None)]
[UnrealObjectPath("/Game/Aki/TypeScript/Game/Render/Character/Manager/CharRenderingComponent.CharRenderingComponent_C")]
public class CharRenderingComponent : UKuroCharRenderingComponent, IStaticVariableResetter, IUnrealUObject, IUnrealObject
{
	// Token: 0x17002565 RID: 9573
	// (get) Token: 0x0601BB24 RID: 113444 RVA: 0x00842D6F File Offset: 0x00840F6F
	// (set) Token: 0x0601BB25 RID: 113445 RVA: 0x00842D83 File Offset: 0x00840F83
	[Nullable(2)]
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe PDA_InteractionPlayerConfig_C InteractionConfig
	{
		[NullableContext(2)]
		get
		{
			return BuiltinUtils.ObjectPropertyGetter<PDA_InteractionPlayerConfig_C>(base.NativePtr / (IntPtr)sizeof(void*) + CharRenderingComponent.__PropertyOffset_InteractionConfig);
		}
		[NullableContext(2)]
		set
		{
			BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + CharRenderingComponent.__PropertyOffset_InteractionConfig, value);
		}
	}

	// Token: 0x17002566 RID: 9574
	// (get) Token: 0x0601BB26 RID: 113446 RVA: 0x00842D98 File Offset: 0x00840F98
	// (set) Token: 0x0601BB27 RID: 113447 RVA: 0x00842DAC File Offset: 0x00840FAC
	[Nullable(2)]
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe PDA_DecalShadowConfig_C DecalShadowConfig
	{
		[NullableContext(2)]
		get
		{
			return BuiltinUtils.ObjectPropertyGetter<PDA_DecalShadowConfig_C>(base.NativePtr / (IntPtr)sizeof(void*) + CharRenderingComponent.__PropertyOffset_DecalShadowConfig);
		}
		[NullableContext(2)]
		set
		{
			BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + CharRenderingComponent.__PropertyOffset_DecalShadowConfig, value);
		}
	}

	// Token: 0x17002567 RID: 9575
	// (get) Token: 0x0601BB28 RID: 113448 RVA: 0x00842DC1 File Offset: 0x00840FC1
	// (set) Token: 0x0601BB29 RID: 113449 RVA: 0x00842DD1 File Offset: 0x00840FD1
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe bool MonsterUseBodyEffect
	{
		get
		{
			return *(base.NativePtr + (IntPtr)CharRenderingComponent.__PropertyOffset_MonsterUseBodyEffect) != 0;
		}
		set
		{
			*(base.NativePtr + (IntPtr)CharRenderingComponent.__PropertyOffset_MonsterUseBodyEffect) = (value ? 1 : 0);
		}
	}

	// Token: 0x17002568 RID: 9576
	// (get) Token: 0x0601BB2A RID: 113450 RVA: 0x00842DE2 File Offset: 0x00840FE2
	// (set) Token: 0x0601BB2B RID: 113451 RVA: 0x00842DF2 File Offset: 0x00840FF2
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe bool UseProxy
	{
		get
		{
			return *(base.NativePtr + (IntPtr)CharRenderingComponent.__PropertyOffset_UseProxy) != 0;
		}
		set
		{
			*(base.NativePtr + (IntPtr)CharRenderingComponent.__PropertyOffset_UseProxy) = (value ? 1 : 0);
		}
	}

	// Token: 0x17002569 RID: 9577
	// (get) Token: 0x0601BB2C RID: 113452 RVA: 0x00842E04 File Offset: 0x00841004
	[Nullable(1)]
	[UProperty(EPropertyFlags.CPF_None)]
	public TArray<UMaterialInterface> ProxyMaterialsOverride
	{
		[NullableContext(1)]
		get
		{
			base.FastCheckIsValid();
			TArray<UMaterialInterface> result;
			if ((result = this._ProxyMaterialsOverride) == null)
			{
				result = (this._ProxyMaterialsOverride = new TArray<UMaterialInterface>(base.NativePtr + (IntPtr)CharRenderingComponent.__PropertyOffset_ProxyMaterialsOverride, this));
			}
			return result;
		}
	}

	// Token: 0x1700256A RID: 9578
	// (get) Token: 0x0601BB2D RID: 113453 RVA: 0x00842E3D File Offset: 0x0084103D
	// (set) Token: 0x0601BB2E RID: 113454 RVA: 0x00842E4D File Offset: 0x0084104D
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe bool ProxyRenderInMainPass
	{
		get
		{
			return *(base.NativePtr + (IntPtr)CharRenderingComponent.__PropertyOffset_ProxyRenderInMainPass) != 0;
		}
		set
		{
			*(base.NativePtr + (IntPtr)CharRenderingComponent.__PropertyOffset_ProxyRenderInMainPass) = (value ? 1 : 0);
		}
	}

	// Token: 0x1700256B RID: 9579
	// (get) Token: 0x0601BB2F RID: 113455 RVA: 0x00842E5E File Offset: 0x0084105E
	// (set) Token: 0x0601BB30 RID: 113456 RVA: 0x00842E6E File Offset: 0x0084106E
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe bool ProxyRenderShadow
	{
		get
		{
			return *(base.NativePtr + (IntPtr)CharRenderingComponent.__PropertyOffset_ProxyRenderShadow) != 0;
		}
		set
		{
			*(base.NativePtr + (IntPtr)CharRenderingComponent.__PropertyOffset_ProxyRenderShadow) = (value ? 1 : 0);
		}
	}

	// Token: 0x1700256C RID: 9580
	// (get) Token: 0x0601BB31 RID: 113457 RVA: 0x00842E7F File Offset: 0x0084107F
	// (set) Token: 0x0601BB32 RID: 113458 RVA: 0x00842E8F File Offset: 0x0084108F
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe bool ProxyRenderTrail
	{
		get
		{
			return *(base.NativePtr + (IntPtr)CharRenderingComponent.__PropertyOffset_ProxyRenderTrail) != 0;
		}
		set
		{
			*(base.NativePtr + (IntPtr)CharRenderingComponent.__PropertyOffset_ProxyRenderTrail) = (value ? 1 : 0);
		}
	}

	// Token: 0x1700256D RID: 9581
	// (get) Token: 0x0601BB33 RID: 113459 RVA: 0x00842EA0 File Offset: 0x008410A0
	// (set) Token: 0x0601BB34 RID: 113460 RVA: 0x00842EB0 File Offset: 0x008410B0
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe float DitherRemap
	{
		get
		{
			return *(base.NativePtr + (IntPtr)CharRenderingComponent.__PropertyOffset_DitherRemap);
		}
		set
		{
			*(base.NativePtr + (IntPtr)CharRenderingComponent.__PropertyOffset_DitherRemap) = value;
		}
	}

	// Token: 0x0601BB35 RID: 113461 RVA: 0x00842EC1 File Offset: 0x008410C1
	private void PreBodyInfoRuntimeInitEvent(FName bodyName)
	{
		this.PreBodyInfoRuntimeInit(bodyName);
	}

	// Token: 0x0601BB36 RID: 113462 RVA: 0x00842ECA File Offset: 0x008410CA
	private void PostBodyInfoRuntimeInitEvent(FName bodyName)
	{
		this.PostBodyInfoRuntimeInit(bodyName);
	}

	// Token: 0x0601BB37 RID: 113463 RVA: 0x00842ED4 File Offset: 0x008410D4
	[NullableContext(1)]
	[UFunction(EFunctionFlags.FUNC_BlueprintNativeEvent)]
	public unsafe virtual float QuickInitAndAddData(UObject data, [Nullable(2)] ASkeletalMeshActor meshActor = null)
	{
		int num;
		IntPtr ufunctionPtrAndSizeChecked = UnrealReflectionUtils.GetUFunctionPtrAndSizeChecked(base.NativePtr, new FName("QuickInitAndAddData"), out num);
		byte* ptr = stackalloc byte[(UIntPtr)((num != 0) ? (num + 15) : 0)];
		CharRenderingComponent.__QuickInitAndAddData_FunctionParams* ptr2 = null;
		if (num != 0)
		{
			ptr2 = ((CharRenderingComponent.__QuickInitAndAddData_FunctionParams*)ptr + 15L / (long)sizeof(CharRenderingComponent.__QuickInitAndAddData_FunctionParams) & -16L);
			UnrealReflectionUtils.InitializeStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
			*(&ptr2->data) = ((data != null) ? data.NativePtr : ((IntPtr)0));
			*(&ptr2->meshActor) = ((meshActor != null) ? meshActor.NativePtr : ((IntPtr)0));
		}
		UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ufunctionPtrAndSizeChecked, (void*)ptr2);
		float _Result = ptr2->__Result;
		if (num != 0)
		{
			UnrealReflectionUtils.DestroyStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
		}
		return _Result;
	}

	// Token: 0x0601BB38 RID: 113464 RVA: 0x00842F74 File Offset: 0x00841174
	[NullableContext(1)]
	protected float QuickInitAndAddData_Implementation(UObject data, [Nullable(2)] ASkeletalMeshActor meshActor = null)
	{
		RenderStats.Init();
		if (!this.CheckInit())
		{
			this.Init(ECharacterRenderingType.Sequence);
		}
		if (!(base.GetOwner() is TsBaseCharacter) && meshActor != null)
		{
			this.AddComponentByCase(ECharacterControllerCaseType.BodyCase0, meshActor.SkeletalMeshComponent);
		}
		int num = this.AddMaterialControllerData(data);
		this.SequenceHandleIds.Add(num);
		return (float)num;
	}

	// Token: 0x0601BB39 RID: 113465 RVA: 0x00842FC8 File Offset: 0x008411C8
	[NullableContext(1)]
	[UFunction(EFunctionFlags.FUNC_BlueprintNativeEvent)]
	public unsafe virtual float QuickInitAndAddDataWithMeshComponent(UObject data, [Nullable(2)] UMeshComponent meshComponent = null)
	{
		int num;
		IntPtr ufunctionPtrAndSizeChecked = UnrealReflectionUtils.GetUFunctionPtrAndSizeChecked(base.NativePtr, new FName("QuickInitAndAddDataWithMeshComponent"), out num);
		byte* ptr = stackalloc byte[(UIntPtr)((num != 0) ? (num + 15) : 0)];
		CharRenderingComponent.__QuickInitAndAddDataWithMeshComponent_FunctionParams* ptr2 = null;
		if (num != 0)
		{
			ptr2 = ((CharRenderingComponent.__QuickInitAndAddDataWithMeshComponent_FunctionParams*)ptr + 15L / (long)sizeof(CharRenderingComponent.__QuickInitAndAddDataWithMeshComponent_FunctionParams) & -16L);
			UnrealReflectionUtils.InitializeStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
			*(&ptr2->data) = ((data != null) ? data.NativePtr : ((IntPtr)0));
			*(&ptr2->meshComponent) = ((meshComponent != null) ? meshComponent.NativePtr : ((IntPtr)0));
		}
		UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ufunctionPtrAndSizeChecked, (void*)ptr2);
		float _Result = ptr2->__Result;
		if (num != 0)
		{
			UnrealReflectionUtils.DestroyStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
		}
		return _Result;
	}

	// Token: 0x0601BB3A RID: 113466 RVA: 0x00843068 File Offset: 0x00841268
	[NullableContext(1)]
	protected float QuickInitAndAddDataWithMeshComponent_Implementation(UObject data, [Nullable(2)] UMeshComponent meshComponent = null)
	{
		RenderStats.Init();
		if (!this.CheckInit())
		{
			this.Init(ECharacterRenderingType.Sequence);
		}
		if (!(base.GetOwner() is TsBaseCharacter) && meshComponent != null)
		{
			this.AddComponentByCase(ECharacterControllerCaseType.BodyCase0, meshComponent);
		}
		int num = this.AddMaterialControllerData(data);
		this.SequenceHandleIds.Add(num);
		return (float)num;
	}

	// Token: 0x0601BB3B RID: 113467 RVA: 0x008430B8 File Offset: 0x008412B8
	[NullableContext(1)]
	[UFunction(EFunctionFlags.FUNC_BlueprintNativeEvent)]
	public unsafe virtual float QuickInitAndAddDataGroup(UObject data, [Nullable(2)] ASkeletalMeshActor meshActor = null)
	{
		int num;
		IntPtr ufunctionPtrAndSizeChecked = UnrealReflectionUtils.GetUFunctionPtrAndSizeChecked(base.NativePtr, new FName("QuickInitAndAddDataGroup"), out num);
		byte* ptr = stackalloc byte[(UIntPtr)((num != 0) ? (num + 15) : 0)];
		CharRenderingComponent.__QuickInitAndAddDataGroup_FunctionParams* ptr2 = null;
		if (num != 0)
		{
			ptr2 = ((CharRenderingComponent.__QuickInitAndAddDataGroup_FunctionParams*)ptr + 15L / (long)sizeof(CharRenderingComponent.__QuickInitAndAddDataGroup_FunctionParams) & -16L);
			UnrealReflectionUtils.InitializeStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
			*(&ptr2->data) = ((data != null) ? data.NativePtr : ((IntPtr)0));
			*(&ptr2->meshActor) = ((meshActor != null) ? meshActor.NativePtr : ((IntPtr)0));
		}
		UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ufunctionPtrAndSizeChecked, (void*)ptr2);
		float _Result = ptr2->__Result;
		if (num != 0)
		{
			UnrealReflectionUtils.DestroyStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
		}
		return _Result;
	}

	// Token: 0x0601BB3C RID: 113468 RVA: 0x00843158 File Offset: 0x00841358
	[NullableContext(1)]
	protected float QuickInitAndAddDataGroup_Implementation(UObject data, [Nullable(2)] ASkeletalMeshActor meshActor = null)
	{
		RenderStats.Init();
		if (!this.CheckInit())
		{
			this.Init(ECharacterRenderingType.Sequence);
		}
		if (!(base.GetOwner() is TsBaseCharacter) && meshActor != null)
		{
			this.AddComponentByCase(ECharacterControllerCaseType.BodyCase0, meshActor.SkeletalMeshComponent);
		}
		int num = this.AddMaterialControllerDataGroup(data);
		this.SequenceHandleIds.Add(num);
		return (float)num;
	}

	// Token: 0x0601BB3D RID: 113469 RVA: 0x008431AC File Offset: 0x008413AC
	[NullableContext(1)]
	[UFunction(EFunctionFlags.FUNC_BlueprintNativeEvent)]
	public unsafe virtual float QuickInitAndAddDataGroupWithMeshComponent(UObject data, [Nullable(2)] UMeshComponent meshComponent = null)
	{
		int num;
		IntPtr ufunctionPtrAndSizeChecked = UnrealReflectionUtils.GetUFunctionPtrAndSizeChecked(base.NativePtr, new FName("QuickInitAndAddDataGroupWithMeshComponent"), out num);
		byte* ptr = stackalloc byte[(UIntPtr)((num != 0) ? (num + 15) : 0)];
		CharRenderingComponent.__QuickInitAndAddDataGroupWithMeshComponent_FunctionParams* ptr2 = null;
		if (num != 0)
		{
			ptr2 = ((CharRenderingComponent.__QuickInitAndAddDataGroupWithMeshComponent_FunctionParams*)ptr + 15L / (long)sizeof(CharRenderingComponent.__QuickInitAndAddDataGroupWithMeshComponent_FunctionParams) & -16L);
			UnrealReflectionUtils.InitializeStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
			*(&ptr2->data) = ((data != null) ? data.NativePtr : ((IntPtr)0));
			*(&ptr2->meshComponent) = ((meshComponent != null) ? meshComponent.NativePtr : ((IntPtr)0));
		}
		UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ufunctionPtrAndSizeChecked, (void*)ptr2);
		float _Result = ptr2->__Result;
		if (num != 0)
		{
			UnrealReflectionUtils.DestroyStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
		}
		return _Result;
	}

	// Token: 0x0601BB3E RID: 113470 RVA: 0x0084324C File Offset: 0x0084144C
	[NullableContext(1)]
	protected float QuickInitAndAddDataGroupWithMeshComponent_Implementation(UObject data, [Nullable(2)] UMeshComponent meshComponent = null)
	{
		RenderStats.Init();
		if (!this.CheckInit())
		{
			this.Init(ECharacterRenderingType.Sequence);
		}
		if (!(base.GetOwner() is TsBaseCharacter) && meshComponent != null)
		{
			this.AddComponentByCase(ECharacterControllerCaseType.BodyCase0, meshComponent);
		}
		int num = this.AddMaterialControllerDataGroup(data);
		this.SequenceHandleIds.Add(num);
		return (float)num;
	}

	// Token: 0x0601BB3F RID: 113471 RVA: 0x0084329C File Offset: 0x0084149C
	[UFunction(EFunctionFlags.FUNC_BlueprintNativeEvent)]
	public unsafe virtual void Init(ECharacterRenderingType renderType)
	{
		int num;
		IntPtr ufunctionPtrAndSizeChecked = UnrealReflectionUtils.GetUFunctionPtrAndSizeChecked(base.NativePtr, new FName("Init"), out num);
		byte* ptr = stackalloc byte[(UIntPtr)((num != 0) ? (num + 15) : 0)];
		CharRenderingComponent.__Init_FunctionParams* ptr2 = null;
		if (num != 0)
		{
			ptr2 = ((CharRenderingComponent.__Init_FunctionParams*)ptr + 15L / (long)sizeof(CharRenderingComponent.__Init_FunctionParams) & -16L);
			UnrealReflectionUtils.InitializeStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
			*(&ptr2->renderType) = (byte)renderType;
		}
		UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ufunctionPtrAndSizeChecked, (void*)ptr2);
		if (num != 0)
		{
			UnrealReflectionUtils.DestroyStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
		}
	}

	// Token: 0x0601BB40 RID: 113472 RVA: 0x00843314 File Offset: 0x00841514
	protected unsafe void Init_Implementation(ECharacterRenderingType renderType)
	{
		if (!this.IsValid())
		{
			return;
		}
		bool flag = false;
		this.CachedOwner = base.GetOwner();
		this.CachedOwnerName = this.CachedOwner.GetName();
		TsBaseCharacter tsBaseCharacter = this.CachedOwner as TsBaseCharacter;
		if (tsBaseCharacter != null)
		{
			this.CachedOwnerEntity = tsBaseCharacter.GetEntityNoBlueprint();
		}
		if (this.IsInit)
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.RenderCharacter;
			ELogAuthor author = ELogAuthor.MY;
			string message = "材质控制器已初始化";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("Actor", this.CachedOwnerName);
			instance.Info(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			flag = true;
		}
		if (renderType == ECharacterRenderingType.Error)
		{
			Log instance2 = Singleton<Log>.Instance;
			ELogModule module2 = ELogModule.RenderCharacter;
			ELogAuthor author2 = ELogAuthor.MY;
			string message2 = "错误：初始化参数错误. 初始化类型不应为Error";
			ValueTuple<string, object> valueTuple2 = new ValueTuple<string, object>("Actor", this.CachedOwnerName);
			instance2.Error(module2, author2, message2, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple2));
			flag = true;
		}
		if (!flag)
		{
			if (renderType == ECharacterRenderingType.Effect)
			{
				this.IsUiUpdate = GlobalData.IsUiSceneOpen;
			}
			if (renderType == ECharacterRenderingType.Npc)
			{
				TsBaseCharacter tsBaseCharacter2 = this.CachedOwner as TsBaseCharacter;
				if (tsBaseCharacter2 != null && tsBaseCharacter2.Mesh != null)
				{
					tsBaseCharacter2.Mesh.IsSpecialForLocalLightShadow = true;
				}
			}
			this.DeltaTime = 0f;
			this.IsOnMobile = (UKuroRenderingRuntimeBPPluginBPLibrary.GetWorldFeatureLevel(GlobalData.World) == KuroFeatureLevel.ES3_1);
			this.AllRenderComps = new List<CharRenderBase>();
			this.AllRenderCompsMap = new Dictionary<int, CharRenderBase>();
			this.IsInit = false;
			this.IsStartInvoke = false;
			this.RenderType = new ECharacterRenderingType?(renderType);
			this.TempRemoveList = new List<int>();
			this.SequenceHandleIds = new List<int>();
			this.IsDebug = false;
			foreach (CharRenderBase charRenderBase in this.GetRenderComps())
			{
				if (this.AllRenderCompsMap.ContainsKey(charRenderBase.GetComponentId()))
				{
					Log instance3 = Singleton<Log>.Instance;
					ELogModule module3 = ELogModule.RenderCharacter;
					ELogAuthor author3 = ELogAuthor.MY;
					string message3 = "错误:重复添加渲染模块 ID";
					<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
					*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("Actor", this.CachedOwnerName);
					*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("渲染模块ID", charRenderBase.GetComponentId());
					instance3.Error(module3, author3, message3, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
				}
				else
				{
					this.AllRenderCompsMap[charRenderBase.GetComponentId()] = charRenderBase;
					this.AllRenderComps.Add(charRenderBase);
					charRenderBase.Awake(this);
				}
			}
			this.IsInit = true;
			this.IsStartInvoke = false;
			this.IndexCount = 0;
			this.AllMaterialControlRuntimeDataGroupMap = new Dictionary<int, CharMaterialControlRuntimeDataGroup>();
			this.InvokeStart();
		}
	}

	// Token: 0x0601BB41 RID: 113473 RVA: 0x00843568 File Offset: 0x00841768
	[NullableContext(1)]
	[return: Nullable(2)]
	private unsafe CharRenderBase AddRenderCompDynamic(CharRenderBase comp)
	{
		if (!this.IsInit)
		{
			return null;
		}
		if (this.AllRenderCompsMap.ContainsKey(comp.GetComponentId()))
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.RenderCharacter;
			ELogAuthor author = ELogAuthor.MY;
			string message = "错误:动态重复添加渲染模块 ID";
			<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("Actor", this.CachedOwnerName);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("渲染模块ID", comp.GetComponentId());
			instance.Error(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
			return null;
		}
		comp.Awake(this);
		this.AllRenderCompsMap[comp.GetComponentId()] = comp;
		this.AllRenderComps.Add(comp);
		try
		{
			comp.Start();
		}
		catch
		{
			Log instance2 = Singleton<Log>.Instance;
			ELogModule module2 = ELogModule.RenderCharacter;
			ELogAuthor author2 = ELogAuthor.LSY;
			string message2 = "错误:动态添加组件初始化错误:";
			<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray2 = default(<>y__InlineArray2<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 0) = new ValueTuple<string, object>("Actor", base.GetOwner());
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 1) = new ValueTuple<string, object>("组件ID", comp.GetComponentId());
			instance2.Error(module2, author2, message2, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray2, 2));
			return null;
		}
		if (!comp.GetIsInitSuc())
		{
			Log instance3 = Singleton<Log>.Instance;
			ELogModule module3 = ELogModule.RenderCharacter;
			ELogAuthor author3 = ELogAuthor.LSY;
			string message3 = "错误:动态添加组件初始化错误:";
			<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray3 = default(<>y__InlineArray2<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray3, 0) = new ValueTuple<string, object>("Actor", base.GetOwner());
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray3, 1) = new ValueTuple<string, object>("组件ID", comp.GetComponentId());
			instance3.Error(module3, author3, message3, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray3, 2));
			return null;
		}
		return comp;
	}

	// Token: 0x0601BB42 RID: 113474 RVA: 0x0084370C File Offset: 0x0084190C
	[NullableContext(2)]
	[UFunction(EFunctionFlags.FUNC_BlueprintNativeEvent)]
	public unsafe virtual void SetLogicOwner(AActor owner)
	{
		int num;
		IntPtr ufunctionPtrAndSizeChecked = UnrealReflectionUtils.GetUFunctionPtrAndSizeChecked(base.NativePtr, new FName("SetLogicOwner"), out num);
		byte* ptr = stackalloc byte[(UIntPtr)((num != 0) ? (num + 15) : 0)];
		CharRenderingComponent.__SetLogicOwner_FunctionParams* ptr2 = null;
		if (num != 0)
		{
			ptr2 = ((CharRenderingComponent.__SetLogicOwner_FunctionParams*)ptr + 15L / (long)sizeof(CharRenderingComponent.__SetLogicOwner_FunctionParams) & -16L);
			UnrealReflectionUtils.InitializeStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
			*(&ptr2->owner) = ((owner != null) ? owner.NativePtr : ((IntPtr)0));
		}
		UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ufunctionPtrAndSizeChecked, (void*)ptr2);
		if (num != 0)
		{
			UnrealReflectionUtils.DestroyStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
		}
	}

	// Token: 0x0601BB43 RID: 113475 RVA: 0x00843790 File Offset: 0x00841990
	[NullableContext(2)]
	protected void SetLogicOwner_Implementation(AActor owner)
	{
		this.LogicOwner = owner;
		if (this.LogicOwner != null)
		{
			this.IsLogicOwnerTsEffectActor = (this.LogicOwner is AEffectSystemActor);
		}
	}

	// Token: 0x0601BB44 RID: 113476 RVA: 0x008437B8 File Offset: 0x008419B8
	[NullableContext(1)]
	[UFunction(EFunctionFlags.FUNC_BlueprintNativeEvent)]
	public unsafe virtual void AddComponent(string skelName, UMeshComponent skeletalComp)
	{
		int num;
		IntPtr ufunctionPtrAndSizeChecked = UnrealReflectionUtils.GetUFunctionPtrAndSizeChecked(base.NativePtr, new FName("AddComponent"), out num);
		byte* ptr = stackalloc byte[(UIntPtr)((num != 0) ? (num + 15) : 0)];
		CharRenderingComponent.__AddComponent_FunctionParams* ptr2 = null;
		if (num != 0)
		{
			ptr2 = ((CharRenderingComponent.__AddComponent_FunctionParams*)ptr + 15L / (long)sizeof(CharRenderingComponent.__AddComponent_FunctionParams) & -16L);
			UnrealReflectionUtils.InitializeStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
			FString.CopyFrom((void*)(&ptr2->skelName), skelName);
			*(&ptr2->skeletalComp) = ((skeletalComp != null) ? skeletalComp.NativePtr : ((IntPtr)0));
		}
		UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ufunctionPtrAndSizeChecked, (void*)ptr2);
		if (num != 0)
		{
			UnrealReflectionUtils.DestroyStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
		}
	}

	// Token: 0x0601BB45 RID: 113477 RVA: 0x0084384C File Offset: 0x00841A4C
	[NullableContext(1)]
	protected void AddComponent_Implementation(string skelName, UMeshComponent skeletalComp)
	{
		if (this.IsInDebugMode)
		{
			Singleton<Log>.Instance.Warn(ELogModule.RenderCharacter, ELogAuthor.ZJF, "【DEPRECATED】请使用AddComponentByCase接口", default(ReadOnlySpan<ValueTuple<string, object>>));
		}
		this.AddComponentInner(skelName, skeletalComp, false);
	}

	// Token: 0x0601BB46 RID: 113478 RVA: 0x00843888 File Offset: 0x00841A88
	[NullableContext(1)]
	[UFunction(EFunctionFlags.FUNC_BlueprintNativeEvent)]
	public unsafe virtual void AddComponentWithEmptyMaterial(string skelName, UMeshComponent skeletalComp)
	{
		int num;
		IntPtr ufunctionPtrAndSizeChecked = UnrealReflectionUtils.GetUFunctionPtrAndSizeChecked(base.NativePtr, new FName("AddComponentWithEmptyMaterial"), out num);
		byte* ptr = stackalloc byte[(UIntPtr)((num != 0) ? (num + 15) : 0)];
		CharRenderingComponent.__AddComponentWithEmptyMaterial_FunctionParams* ptr2 = null;
		if (num != 0)
		{
			ptr2 = ((CharRenderingComponent.__AddComponentWithEmptyMaterial_FunctionParams*)ptr + 15L / (long)sizeof(CharRenderingComponent.__AddComponentWithEmptyMaterial_FunctionParams) & -16L);
			UnrealReflectionUtils.InitializeStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
			FString.CopyFrom((void*)(&ptr2->skelName), skelName);
			*(&ptr2->skeletalComp) = ((skeletalComp != null) ? skeletalComp.NativePtr : ((IntPtr)0));
		}
		UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ufunctionPtrAndSizeChecked, (void*)ptr2);
		if (num != 0)
		{
			UnrealReflectionUtils.DestroyStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
		}
	}

	// Token: 0x0601BB47 RID: 113479 RVA: 0x00843919 File Offset: 0x00841B19
	[NullableContext(1)]
	protected void AddComponentWithEmptyMaterial_Implementation(string skelName, UMeshComponent skeletalComp)
	{
		this.AddComponentInner(skelName, skeletalComp, true);
	}

	// Token: 0x0601BB48 RID: 113480 RVA: 0x00843924 File Offset: 0x00841B24
	[NullableContext(1)]
	[UFunction(EFunctionFlags.FUNC_BlueprintNativeEvent)]
	public unsafe virtual void RemoveComponent(string skelName)
	{
		int num;
		IntPtr ufunctionPtrAndSizeChecked = UnrealReflectionUtils.GetUFunctionPtrAndSizeChecked(base.NativePtr, new FName("RemoveComponent"), out num);
		byte* ptr = stackalloc byte[(UIntPtr)((num != 0) ? (num + 15) : 0)];
		CharRenderingComponent.__RemoveComponent_FunctionParams* ptr2 = null;
		if (num != 0)
		{
			ptr2 = ((CharRenderingComponent.__RemoveComponent_FunctionParams*)ptr + 15L / (long)sizeof(CharRenderingComponent.__RemoveComponent_FunctionParams) & -16L);
			UnrealReflectionUtils.InitializeStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
			FString.CopyFrom((void*)(&ptr2->skelName), skelName);
		}
		UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ufunctionPtrAndSizeChecked, (void*)ptr2);
		if (num != 0)
		{
			UnrealReflectionUtils.DestroyStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
		}
	}

	// Token: 0x0601BB49 RID: 113481 RVA: 0x008439A0 File Offset: 0x00841BA0
	[NullableContext(1)]
	protected void RemoveComponent_Implementation(string skelName)
	{
		if (this.IsInDebugMode)
		{
			Singleton<Log>.Instance.Warn(ELogModule.RenderCharacter, ELogAuthor.ZJF, "【DEPRECATED】请使用RemoveComponentByCase接口", default(ReadOnlySpan<ValueTuple<string, object>>));
		}
		this.RemoveComponentInner(skelName);
	}

	// Token: 0x0601BB4A RID: 113482 RVA: 0x008439D8 File Offset: 0x00841BD8
	[NullableContext(2)]
	[UFunction(EFunctionFlags.FUNC_BlueprintNativeEvent)]
	public unsafe virtual void AddComponentByCase(ECharacterControllerCaseType caseType, UMeshComponent skeletalComp)
	{
		int num;
		IntPtr ufunctionPtrAndSizeChecked = UnrealReflectionUtils.GetUFunctionPtrAndSizeChecked(base.NativePtr, new FName("AddComponentByCase"), out num);
		byte* ptr = stackalloc byte[(UIntPtr)((num != 0) ? (num + 15) : 0)];
		CharRenderingComponent.__AddComponentByCase_FunctionParams* ptr2 = null;
		if (num != 0)
		{
			ptr2 = ((CharRenderingComponent.__AddComponentByCase_FunctionParams*)ptr + 15L / (long)sizeof(CharRenderingComponent.__AddComponentByCase_FunctionParams) & -16L);
			UnrealReflectionUtils.InitializeStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
			*(&ptr2->caseType) = (byte)caseType;
			*(&ptr2->skeletalComp) = ((skeletalComp != null) ? skeletalComp.NativePtr : ((IntPtr)0));
		}
		UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ufunctionPtrAndSizeChecked, (void*)ptr2);
		if (num != 0)
		{
			UnrealReflectionUtils.DestroyStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
		}
	}

	// Token: 0x0601BB4B RID: 113483 RVA: 0x00843A68 File Offset: 0x00841C68
	[NullableContext(2)]
	protected void AddComponentByCase_Implementation(ECharacterControllerCaseType caseType, UMeshComponent skeletalComp)
	{
		if (skeletalComp == null)
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.RenderCharacter;
			ELogAuthor author = ELogAuthor.MY;
			string message = "添加的MeshComponent是失效的";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("Actor", this.CachedOwner);
			instance.Warn(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			return;
		}
		string text = RenderConfig.MaterialControlAllCaseArray[(int)caseType];
		if (text != null)
		{
			this.AddComponentInner(text, skeletalComp, false);
		}
	}

	// Token: 0x0601BB4C RID: 113484 RVA: 0x00843ABC File Offset: 0x00841CBC
	[UFunction(EFunctionFlags.FUNC_BlueprintNativeEvent)]
	public unsafe virtual void RemoveComponentByCase(ECharacterControllerCaseType caseType)
	{
		int num;
		IntPtr ufunctionPtrAndSizeChecked = UnrealReflectionUtils.GetUFunctionPtrAndSizeChecked(base.NativePtr, new FName("RemoveComponentByCase"), out num);
		byte* ptr = stackalloc byte[(UIntPtr)((num != 0) ? (num + 15) : 0)];
		CharRenderingComponent.__RemoveComponentByCase_FunctionParams* ptr2 = null;
		if (num != 0)
		{
			ptr2 = ((CharRenderingComponent.__RemoveComponentByCase_FunctionParams*)ptr + 15L / (long)sizeof(CharRenderingComponent.__RemoveComponentByCase_FunctionParams) & -16L);
			UnrealReflectionUtils.InitializeStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
			*(&ptr2->caseType) = (byte)caseType;
		}
		UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ufunctionPtrAndSizeChecked, (void*)ptr2);
		if (num != 0)
		{
			UnrealReflectionUtils.DestroyStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
		}
	}

	// Token: 0x0601BB4D RID: 113485 RVA: 0x00843B34 File Offset: 0x00841D34
	protected void RemoveComponentByCase_Implementation(ECharacterControllerCaseType caseType)
	{
		string text = RenderConfig.MaterialControlAllCaseArray[(int)caseType];
		if (text != null)
		{
			this.RemoveComponentInner(text);
		}
	}

	// Token: 0x0601BB4E RID: 113486 RVA: 0x00843B54 File Offset: 0x00841D54
	[NullableContext(1)]
	public void AddComponentInner(string skelName, UMeshComponent skeletalComp, bool useEmptyMaterial)
	{
		if (this.UseMaterialContainerV2)
		{
			this.AddComponentInnerV2(skelName, skeletalComp, useEmptyMaterial);
		}
		else
		{
			CharMaterialContainer charMaterialContainer = this.GetComponent(1) as CharMaterialContainer;
			CharMaterialController charMaterialController = this.GetComponent(2) as CharMaterialController;
			bool flag = false;
			if (charMaterialController != null)
			{
				charMaterialController.RemoveSkeletalMeshMaterialControllerData(skelName);
			}
			if (charMaterialContainer != null)
			{
				charMaterialContainer.RemoveSkeletalComponent(skelName);
				flag = charMaterialContainer.AddSkeletalComponent((USkeletalMeshComponent)skeletalComp, skelName, useEmptyMaterial);
			}
			if (!flag)
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.RenderCharacter;
				ELogAuthor author = ELogAuthor.MY;
				string message = "添加的MeshComponent是失效的!";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("Actor", this.CachedOwner);
				instance.Warn(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			}
		}
		this.AddComponentForDecalShadow(skelName, skeletalComp);
	}

	// Token: 0x0601BB4F RID: 113487 RVA: 0x00843BEC File Offset: 0x00841DEC
	[NullableContext(1)]
	[UFunction(EFunctionFlags.FUNC_BlueprintNativeEvent)]
	public unsafe virtual void AddComponentInnerV2(string skelName, UMeshComponent skeletalComp, bool useEmptyMaterial)
	{
		int num;
		IntPtr ufunctionPtrAndSizeChecked = UnrealReflectionUtils.GetUFunctionPtrAndSizeChecked(base.NativePtr, new FName("AddComponentInnerV2"), out num);
		byte* ptr = stackalloc byte[(UIntPtr)((num != 0) ? (num + 15) : 0)];
		CharRenderingComponent.__AddComponentInnerV2_FunctionParams* ptr2 = null;
		if (num != 0)
		{
			ptr2 = ((CharRenderingComponent.__AddComponentInnerV2_FunctionParams*)ptr + 15L / (long)sizeof(CharRenderingComponent.__AddComponentInnerV2_FunctionParams) & -16L);
			UnrealReflectionUtils.InitializeStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
			FString.CopyFrom((void*)(&ptr2->skelName), skelName);
			*(&ptr2->skeletalComp) = ((skeletalComp != null) ? skeletalComp.NativePtr : ((IntPtr)0));
			ptr2->useEmptyMaterial = useEmptyMaterial;
		}
		UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ufunctionPtrAndSizeChecked, (void*)ptr2);
		if (num != 0)
		{
			UnrealReflectionUtils.DestroyStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
		}
	}

	// Token: 0x0601BB50 RID: 113488 RVA: 0x00843C84 File Offset: 0x00841E84
	[NullableContext(1)]
	protected void AddComponentInnerV2_Implementation(string skelName, UMeshComponent skeletalComp, bool useEmptyMaterial)
	{
		CharMaterialContainerV2 charMaterialContainerV = this.GetComponent(13) as CharMaterialContainerV2;
		if (charMaterialContainerV != null)
		{
			charMaterialContainerV.RemoveSkeletalComponent(skelName);
			charMaterialContainerV.AddSkeletalComponent((USkeletalMeshComponent)skeletalComp, skelName, useEmptyMaterial);
		}
	}

	// Token: 0x0601BB51 RID: 113489 RVA: 0x00843CB8 File Offset: 0x00841EB8
	[NullableContext(1)]
	public void RemoveComponentInner(string skelName)
	{
		if (this.UseMaterialContainerV2)
		{
			this.RemoveComponentInnerV2(skelName);
		}
		else
		{
			CharMaterialContainer charMaterialContainer = this.GetComponent(1) as CharMaterialContainer;
			CharMaterialController charMaterialController = this.GetComponent(2) as CharMaterialController;
			if (charMaterialController != null)
			{
				charMaterialController.RemoveSkeletalMeshMaterialControllerData(skelName);
			}
			if (charMaterialContainer != null && !charMaterialContainer.RemoveSkeletalComponent(skelName))
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.RenderCharacter;
				ELogAuthor author = ELogAuthor.MY;
				string message = "无法找到要删除的MeshComponent";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("Actor", base.GetOwner());
				instance.Warn(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			}
		}
		this.RemoveComponentFromDecalShadow(skelName);
	}

	// Token: 0x0601BB52 RID: 113490 RVA: 0x00843D3C File Offset: 0x00841F3C
	[NullableContext(1)]
	[UFunction(EFunctionFlags.FUNC_BlueprintNativeEvent)]
	public unsafe virtual void RemoveComponentInnerV2(string skelName)
	{
		int num;
		IntPtr ufunctionPtrAndSizeChecked = UnrealReflectionUtils.GetUFunctionPtrAndSizeChecked(base.NativePtr, new FName("RemoveComponentInnerV2"), out num);
		byte* ptr = stackalloc byte[(UIntPtr)((num != 0) ? (num + 15) : 0)];
		CharRenderingComponent.__RemoveComponentInnerV2_FunctionParams* ptr2 = null;
		if (num != 0)
		{
			ptr2 = ((CharRenderingComponent.__RemoveComponentInnerV2_FunctionParams*)ptr + 15L / (long)sizeof(CharRenderingComponent.__RemoveComponentInnerV2_FunctionParams) & -16L);
			UnrealReflectionUtils.InitializeStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
			FString.CopyFrom((void*)(&ptr2->skelName), skelName);
		}
		UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ufunctionPtrAndSizeChecked, (void*)ptr2);
		if (num != 0)
		{
			UnrealReflectionUtils.DestroyStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
		}
	}

	// Token: 0x0601BB53 RID: 113491 RVA: 0x00843DB8 File Offset: 0x00841FB8
	[NullableContext(1)]
	protected void RemoveComponentInnerV2_Implementation(string skelName)
	{
		CharMaterialContainerV2 charMaterialContainerV = this.GetComponent(13) as CharMaterialContainerV2;
		if (charMaterialContainerV != null)
		{
			charMaterialContainerV.RemoveSkeletalComponent(skelName);
		}
	}

	// Token: 0x0601BB54 RID: 113492 RVA: 0x00843DE0 File Offset: 0x00841FE0
	[NullableContext(1)]
	[UFunction(EFunctionFlags.FUNC_BlueprintNativeEvent)]
	[return: Nullable(2)]
	public unsafe virtual USkeletalMeshComponent GetSkeletalMeshComponent(string skelName)
	{
		int num;
		IntPtr ufunctionPtrAndSizeChecked = UnrealReflectionUtils.GetUFunctionPtrAndSizeChecked(base.NativePtr, new FName("GetSkeletalMeshComponent"), out num);
		byte* ptr = stackalloc byte[(UIntPtr)((num != 0) ? (num + 15) : 0)];
		CharRenderingComponent.__GetSkeletalMeshComponent_FunctionParams* ptr2 = null;
		if (num != 0)
		{
			ptr2 = ((CharRenderingComponent.__GetSkeletalMeshComponent_FunctionParams*)ptr + 15L / (long)sizeof(CharRenderingComponent.__GetSkeletalMeshComponent_FunctionParams) & -16L);
			UnrealReflectionUtils.InitializeStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
			FString.CopyFrom((void*)(&ptr2->skelName), skelName);
		}
		UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ufunctionPtrAndSizeChecked, (void*)ptr2);
		USkeletalMeshComponent orCreateUObjectByNativePointer = BuiltinUtils.GetOrCreateUObjectByNativePointer<USkeletalMeshComponent>(ptr2->__Result);
		if (num != 0)
		{
			UnrealReflectionUtils.DestroyStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
		}
		return orCreateUObjectByNativePointer;
	}

	// Token: 0x0601BB55 RID: 113493 RVA: 0x00843E68 File Offset: 0x00842068
	[NullableContext(1)]
	[return: Nullable(2)]
	protected USkeletalMeshComponent GetSkeletalMeshComponent_Implementation(string skelName)
	{
		if (this.UseMaterialContainerV2)
		{
			CharMaterialContainerV2 charMaterialContainerV = this.GetComponent(13) as CharMaterialContainerV2;
			if (charMaterialContainerV != null)
			{
				return charMaterialContainerV.GetSkeletalComponent(skelName);
			}
		}
		else
		{
			CharMaterialContainer charMaterialContainer = this.GetComponent(1) as CharMaterialContainer;
			if (charMaterialContainer != null)
			{
				CharBodyInfo charBodyInfo = (charMaterialContainer.AllBodyInfoList != null && charMaterialContainer.AllBodyInfoList.ContainsKey(skelName)) ? charMaterialContainer.AllBodyInfoList[skelName] : null;
				if (charBodyInfo == null)
				{
					return null;
				}
				return charBodyInfo.SkeletalComp;
			}
		}
		return null;
	}

	// Token: 0x0601BB56 RID: 113494 RVA: 0x00843ED8 File Offset: 0x008420D8
	[NullableContext(1)]
	[UFunction(EFunctionFlags.FUNC_BlueprintNativeEvent)]
	public unsafe virtual FName GetSkeletalMeshComponentBodyName(USkeletalMeshComponent skeletalComp)
	{
		int num;
		IntPtr ufunctionPtrAndSizeChecked = UnrealReflectionUtils.GetUFunctionPtrAndSizeChecked(base.NativePtr, new FName("GetSkeletalMeshComponentBodyName"), out num);
		byte* ptr = stackalloc byte[(UIntPtr)((num != 0) ? (num + 15) : 0)];
		CharRenderingComponent.__GetSkeletalMeshComponentBodyName_FunctionParams* ptr2 = null;
		if (num != 0)
		{
			ptr2 = ((CharRenderingComponent.__GetSkeletalMeshComponentBodyName_FunctionParams*)ptr + 15L / (long)sizeof(CharRenderingComponent.__GetSkeletalMeshComponentBodyName_FunctionParams) & -16L);
			UnrealReflectionUtils.InitializeStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
			*(&ptr2->skeletalComp) = ((skeletalComp != null) ? skeletalComp.NativePtr : ((IntPtr)0));
		}
		UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ufunctionPtrAndSizeChecked, (void*)ptr2);
		FName _Result = ptr2->__Result;
		if (num != 0)
		{
			UnrealReflectionUtils.DestroyStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
		}
		return _Result;
	}

	// Token: 0x0601BB57 RID: 113495 RVA: 0x00843F64 File Offset: 0x00842164
	[NullableContext(1)]
	protected FName GetSkeletalMeshComponentBodyName_Implementation(USkeletalMeshComponent skeletalComp)
	{
		if (this.UseMaterialContainerV2)
		{
			CharMaterialContainerV2 charMaterialContainerV = this.GetComponent(13) as CharMaterialContainerV2;
			if (charMaterialContainerV != null)
			{
				return charMaterialContainerV.GetSkeletalMeshComponentBodyName(skeletalComp);
			}
		}
		return FName.NAME_None;
	}

	// Token: 0x0601BB58 RID: 113496 RVA: 0x00843F98 File Offset: 0x00842198
	[UFunction(EFunctionFlags.FUNC_BlueprintNativeEvent)]
	public unsafe virtual bool CheckInit()
	{
		int num;
		IntPtr ufunctionPtrAndSizeChecked = UnrealReflectionUtils.GetUFunctionPtrAndSizeChecked(base.NativePtr, new FName("CheckInit"), out num);
		byte* ptr = stackalloc byte[(UIntPtr)((num != 0) ? (num + 15) : 0)];
		CharRenderingComponent.__CheckInit_FunctionParams* ptr2 = null;
		if (num != 0)
		{
			ptr2 = ((CharRenderingComponent.__CheckInit_FunctionParams*)ptr + 15L / (long)sizeof(CharRenderingComponent.__CheckInit_FunctionParams) & -16L);
			UnrealReflectionUtils.InitializeStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
		}
		UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ufunctionPtrAndSizeChecked, (void*)ptr2);
		bool _Result = ptr2->__Result;
		if (num != 0)
		{
			UnrealReflectionUtils.DestroyStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
		}
		return _Result;
	}

	// Token: 0x0601BB59 RID: 113497 RVA: 0x0084400D File Offset: 0x0084220D
	protected bool CheckInit_Implementation()
	{
		return this.IsInit;
	}

	// Token: 0x0601BB5A RID: 113498 RVA: 0x00844018 File Offset: 0x00842218
	[UFunction(EFunctionFlags.FUNC_BlueprintNativeEvent)]
	public unsafe virtual void SetDebug(bool value)
	{
		int num;
		IntPtr ufunctionPtrAndSizeChecked = UnrealReflectionUtils.GetUFunctionPtrAndSizeChecked(base.NativePtr, new FName("SetDebug"), out num);
		byte* ptr = stackalloc byte[(UIntPtr)((num != 0) ? (num + 15) : 0)];
		CharRenderingComponent.__SetDebug_FunctionParams* ptr2 = null;
		if (num != 0)
		{
			ptr2 = ((CharRenderingComponent.__SetDebug_FunctionParams*)ptr + 15L / (long)sizeof(CharRenderingComponent.__SetDebug_FunctionParams) & -16L);
			UnrealReflectionUtils.InitializeStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
			ptr2->value = value;
		}
		UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ufunctionPtrAndSizeChecked, (void*)ptr2);
		if (num != 0)
		{
			UnrealReflectionUtils.DestroyStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
		}
	}

	// Token: 0x0601BB5B RID: 113499 RVA: 0x0084408E File Offset: 0x0084228E
	protected void SetDebug_Implementation(bool value)
	{
		this.IsDebug = value;
	}

	// Token: 0x0601BB5C RID: 113500 RVA: 0x00844098 File Offset: 0x00842298
	[NullableContext(2)]
	[UFunction(EFunctionFlags.FUNC_BlueprintNativeEvent)]
	public unsafe virtual PD_MaterialDebug_C GetDebugInfo()
	{
		int num;
		IntPtr ufunctionPtrAndSizeChecked = UnrealReflectionUtils.GetUFunctionPtrAndSizeChecked(base.NativePtr, new FName("GetDebugInfo"), out num);
		byte* ptr = stackalloc byte[(UIntPtr)((num != 0) ? (num + 15) : 0)];
		CharRenderingComponent.__GetDebugInfo_FunctionParams* ptr2 = null;
		if (num != 0)
		{
			ptr2 = ((CharRenderingComponent.__GetDebugInfo_FunctionParams*)ptr + 15L / (long)sizeof(CharRenderingComponent.__GetDebugInfo_FunctionParams) & -16L);
			UnrealReflectionUtils.InitializeStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
		}
		UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ufunctionPtrAndSizeChecked, (void*)ptr2);
		PD_MaterialDebug_C orCreateUObjectByNativePointer = BuiltinUtils.GetOrCreateUObjectByNativePointer<PD_MaterialDebug_C>(ptr2->__Result);
		if (num != 0)
		{
			UnrealReflectionUtils.DestroyStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
		}
		return orCreateUObjectByNativePointer;
	}

	// Token: 0x0601BB5D RID: 113501 RVA: 0x00844114 File Offset: 0x00842314
	[NullableContext(2)]
	protected PD_MaterialDebug_C GetDebugInfo_Implementation()
	{
		CharMaterialController charMaterialController = this.GetComponent(2) as CharMaterialController;
		if (charMaterialController == null)
		{
			return null;
		}
		if (this.IsDebug)
		{
			charMaterialController.EnableDebug = true;
			return charMaterialController.DebugInfo;
		}
		charMaterialController.EnableDebug = false;
		return null;
	}

	// Token: 0x0601BB5E RID: 113502 RVA: 0x00844151 File Offset: 0x00842351
	[NullableContext(2)]
	public CharRenderBase GetComponent(int componentId)
	{
		if (this.IsInit && this.AllRenderCompsMap.ContainsKey(componentId))
		{
			return this.AllRenderCompsMap[componentId];
		}
		return null;
	}

	// Token: 0x0601BB5F RID: 113503 RVA: 0x00844177 File Offset: 0x00842377
	public void Tick(float delta)
	{
		this.Update(delta);
	}

	// Token: 0x0601BB60 RID: 113504 RVA: 0x00844180 File Offset: 0x00842380
	[UFunction(EFunctionFlags.FUNC_BlueprintNativeEvent)]
	public unsafe override void ReceiveEndPlay(EEndPlayReason endPlayReason)
	{
		int num;
		IntPtr ufunctionPtrAndSizeChecked = UnrealReflectionUtils.GetUFunctionPtrAndSizeChecked(base.NativePtr, new FName("ReceiveEndPlay"), out num);
		byte* ptr = stackalloc byte[(UIntPtr)((num != 0) ? (num + 15) : 0)];
		UActorComponent.__ReceiveEndPlay_FunctionParams* ptr2 = null;
		if (num != 0)
		{
			ptr2 = ((UActorComponent.__ReceiveEndPlay_FunctionParams*)ptr + 15L / (long)sizeof(UActorComponent.__ReceiveEndPlay_FunctionParams) & -16L);
			UnrealReflectionUtils.InitializeStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
			*(byte*)(&ptr2->EndPlayReason) = (byte)endPlayReason;
		}
		UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ufunctionPtrAndSizeChecked, (void*)ptr2);
		if (num != 0)
		{
			UnrealReflectionUtils.DestroyStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
		}
	}

	// Token: 0x0601BB61 RID: 113505 RVA: 0x008441F9 File Offset: 0x008423F9
	protected virtual void ReceiveEndPlay_Implementation(EEndPlayReason endPlayReason)
	{
		if (endPlayReason != EEndPlayReason.EndPlayInEditor)
		{
			this.Destroy();
		}
	}

	// Token: 0x0601BB62 RID: 113506 RVA: 0x00844205 File Offset: 0x00842405
	public float GetDeltaTime()
	{
		return this.DeltaTime;
	}

	// Token: 0x0601BB63 RID: 113507 RVA: 0x00844210 File Offset: 0x00842410
	[NullableContext(1)]
	public float GetTimeDilation(LogicalTimeDilationOut outVal)
	{
		float num = ControllerBase<RenderModuleController>.Instance.IsGamePaused ? 0f : ControllerBase<RenderModuleController>.Instance.GlobalTimeDilation;
		if (num == 0f)
		{
			return 0f;
		}
		if (this.LogicOwner != null && this.IsLogicOwnerTsEffectActor)
		{
			AEffectSystemActor aeffectSystemActor = (AEffectSystemActor)this.LogicOwner;
			num *= aeffectSystemActor.GetTimeScale();
		}
		else
		{
			Entity cachedOwnerEntity = this.CachedOwnerEntity;
			CharacterTimeScaleComponent characterTimeScaleComponent = (cachedOwnerEntity != null) ? cachedOwnerEntity.GetComponent<CharacterTimeScaleComponent>() : null;
			if (characterTimeScaleComponent != null)
			{
				float num2 = this.CachedOwnerEntity.TimeDilation * characterTimeScaleComponent.CurrentTimeScale;
				if (num2 > 1f)
				{
					num *= num2;
				}
				outVal.LogicalTimeDilation = num2;
			}
		}
		return num;
	}

	// Token: 0x0601BB64 RID: 113508 RVA: 0x008442B0 File Offset: 0x008424B0
	[UFunction(EFunctionFlags.FUNC_BlueprintNativeEvent)]
	public unsafe virtual bool GetInWater(float depthThreshold = 2f)
	{
		int num;
		IntPtr ufunctionPtrAndSizeChecked = UnrealReflectionUtils.GetUFunctionPtrAndSizeChecked(base.NativePtr, new FName("GetInWater"), out num);
		byte* ptr = stackalloc byte[(UIntPtr)((num != 0) ? (num + 15) : 0)];
		CharRenderingComponent.__GetInWater_FunctionParams* ptr2 = null;
		if (num != 0)
		{
			ptr2 = ((CharRenderingComponent.__GetInWater_FunctionParams*)ptr + 15L / (long)sizeof(CharRenderingComponent.__GetInWater_FunctionParams) & -16L);
			UnrealReflectionUtils.InitializeStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
			ptr2->depthThreshold = depthThreshold;
		}
		UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ufunctionPtrAndSizeChecked, (void*)ptr2);
		bool _Result = ptr2->__Result;
		if (num != 0)
		{
			UnrealReflectionUtils.DestroyStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
		}
		return _Result;
	}

	// Token: 0x0601BB65 RID: 113509 RVA: 0x0084432C File Offset: 0x0084252C
	protected bool GetInWater_Implementation(float depthThreshold = 2f)
	{
		CharSceneInteraction charSceneInteraction = this.GetComponent(5) as CharSceneInteraction;
		return charSceneInteraction != null && charSceneInteraction.GetInWater(depthThreshold);
	}

	// Token: 0x0601BB66 RID: 113510 RVA: 0x00844348 File Offset: 0x00842548
	public float GetWaterHitLocationZ()
	{
		CharSceneInteraction charSceneInteraction = this.GetComponent(5) as CharSceneInteraction;
		if (charSceneInteraction != null)
		{
			return (float)charSceneInteraction.GetWaterHitLocationZ();
		}
		return 0f;
	}

	// Token: 0x0601BB67 RID: 113511 RVA: 0x00844374 File Offset: 0x00842574
	[UFunction(EFunctionFlags.FUNC_BlueprintNativeEvent)]
	public unsafe virtual bool GetInAudioShr()
	{
		int num;
		IntPtr ufunctionPtrAndSizeChecked = UnrealReflectionUtils.GetUFunctionPtrAndSizeChecked(base.NativePtr, new FName("GetInAudioShr"), out num);
		byte* ptr = stackalloc byte[(UIntPtr)((num != 0) ? (num + 15) : 0)];
		CharRenderingComponent.__GetInAudioShr_FunctionParams* ptr2 = null;
		if (num != 0)
		{
			ptr2 = ((CharRenderingComponent.__GetInAudioShr_FunctionParams*)ptr + 15L / (long)sizeof(CharRenderingComponent.__GetInAudioShr_FunctionParams) & -16L);
			UnrealReflectionUtils.InitializeStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
		}
		UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ufunctionPtrAndSizeChecked, (void*)ptr2);
		bool _Result = ptr2->__Result;
		if (num != 0)
		{
			UnrealReflectionUtils.DestroyStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
		}
		return _Result;
	}

	// Token: 0x0601BB68 RID: 113512 RVA: 0x008443EC File Offset: 0x008425EC
	protected bool GetInAudioShr_Implementation()
	{
		CharSceneInteraction charSceneInteraction = this.GetComponent(5) as CharSceneInteraction;
		return charSceneInteraction != null && charSceneInteraction.GetInAudioShr();
	}

	// Token: 0x0601BB69 RID: 113513 RVA: 0x00844414 File Offset: 0x00842614
	public FName GetAudioShrTag()
	{
		CharSceneInteraction charSceneInteraction = this.GetComponent(5) as CharSceneInteraction;
		if (charSceneInteraction == null)
		{
			return FNameUtil.NONE;
		}
		return charSceneInteraction.GetAudioShrTag();
	}

	// Token: 0x0601BB6A RID: 113514 RVA: 0x0084443D File Offset: 0x0084263D
	public ECharacterRenderingType? GetRenderType()
	{
		return this.RenderType;
	}

	// Token: 0x0601BB6B RID: 113515 RVA: 0x00844448 File Offset: 0x00842648
	[UFunction(EFunctionFlags.FUNC_BlueprintNativeEvent)]
	public unsafe virtual void ResetAllRenderingState()
	{
		int num;
		IntPtr ufunctionPtrAndSizeChecked = UnrealReflectionUtils.GetUFunctionPtrAndSizeChecked(base.NativePtr, new FName("ResetAllRenderingState"), out num);
		byte* ptr = stackalloc byte[(UIntPtr)((num != 0) ? (num + 15) : 0)];
		byte* dest = null;
		if (num != 0)
		{
			dest = (ptr + 15L & -16L);
			UnrealReflectionUtils.InitializeStruct(ufunctionPtrAndSizeChecked, (void*)dest, 1);
		}
		UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ufunctionPtrAndSizeChecked, null);
		if (num != 0)
		{
			UnrealReflectionUtils.DestroyStruct(ufunctionPtrAndSizeChecked, (void*)dest, 1);
		}
	}

	// Token: 0x0601BB6C RID: 113516 RVA: 0x008444B8 File Offset: 0x008426B8
	protected void ResetAllRenderingState_Implementation()
	{
		foreach (CharRenderBase charRenderBase in this.AllRenderComps)
		{
			if (charRenderBase.GetIsInitSuc())
			{
				charRenderBase.OnResetRenderState();
			}
		}
		foreach (int p in this.AllMaterialControlRuntimeDataGroupMap.Keys)
		{
			Singleton<EventSystem>.Instance.EmitWithTarget<int>(this, EEventName.OnRemoveMaterialControllerGroup, p);
		}
		Dictionary<int, CharMaterialControlRuntimeDataGroup> allMaterialControlRuntimeDataGroupMap = this.AllMaterialControlRuntimeDataGroupMap;
		if (allMaterialControlRuntimeDataGroupMap == null)
		{
			return;
		}
		allMaterialControlRuntimeDataGroupMap.Clear();
	}

	// Token: 0x0601BB6D RID: 113517 RVA: 0x00844574 File Offset: 0x00842774
	public void PreBodyInfoRuntimeInit(FName bodyName)
	{
		foreach (CharRenderBase charRenderBase in this.AllRenderComps)
		{
			if (charRenderBase.GetIsInitSuc())
			{
				charRenderBase.PreBodyInfoRuntimeInit(bodyName);
			}
		}
	}

	// Token: 0x0601BB6E RID: 113518 RVA: 0x008445D0 File Offset: 0x008427D0
	public void PostBodyInfoRuntimeInit(FName bodyName)
	{
		foreach (CharRenderBase charRenderBase in this.AllRenderComps)
		{
			if (charRenderBase.GetIsInitSuc())
			{
				charRenderBase.PostBodyInfoRuntimeInit(bodyName);
			}
		}
	}

	// Token: 0x0601BB6F RID: 113519 RVA: 0x0084462C File Offset: 0x0084282C
	public void ResetAllRenderingStateForDebug()
	{
		CharMaterialController charMaterialController = this.GetComponent(2) as CharMaterialController;
		if (charMaterialController != null && charMaterialController.AllMaterialControlRuntimeDataMap.Count > 0)
		{
			charMaterialController.PrintCurrentInfo();
			this.ResetAllRenderingState();
		}
	}

	// Token: 0x0601BB70 RID: 113520 RVA: 0x00844664 File Offset: 0x00842864
	[NullableContext(2)]
	[UFunction(EFunctionFlags.FUNC_BlueprintNativeEvent)]
	public unsafe virtual int AddMaterialControllerDataGroup(UObject data)
	{
		int num;
		IntPtr ufunctionPtrAndSizeChecked = UnrealReflectionUtils.GetUFunctionPtrAndSizeChecked(base.NativePtr, new FName("AddMaterialControllerDataGroup"), out num);
		byte* ptr = stackalloc byte[(UIntPtr)((num != 0) ? (num + 15) : 0)];
		CharRenderingComponent.__AddMaterialControllerDataGroup_FunctionParams* ptr2 = null;
		if (num != 0)
		{
			ptr2 = ((CharRenderingComponent.__AddMaterialControllerDataGroup_FunctionParams*)ptr + 15L / (long)sizeof(CharRenderingComponent.__AddMaterialControllerDataGroup_FunctionParams) & -16L);
			UnrealReflectionUtils.InitializeStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
			*(&ptr2->data) = ((data != null) ? data.NativePtr : ((IntPtr)0));
		}
		UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ufunctionPtrAndSizeChecked, (void*)ptr2);
		int _Result = ptr2->__Result;
		if (num != 0)
		{
			UnrealReflectionUtils.DestroyStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
		}
		return _Result;
	}

	// Token: 0x0601BB71 RID: 113521 RVA: 0x008446EE File Offset: 0x008428EE
	[NullableContext(2)]
	protected int AddMaterialControllerDataGroup_Implementation(UObject data)
	{
		return (int)this.AddMaterialControllerDataGroupWithAnimObject(data, null);
	}

	// Token: 0x0601BB72 RID: 113522 RVA: 0x008446FC File Offset: 0x008428FC
	[NullableContext(2)]
	[UFunction(EFunctionFlags.FUNC_BlueprintNativeEvent)]
	public unsafe virtual float AddMaterialControllerDataGroupWithAnimObject(UObject data, USkeletalMeshComponent animObject = null)
	{
		int num;
		IntPtr ufunctionPtrAndSizeChecked = UnrealReflectionUtils.GetUFunctionPtrAndSizeChecked(base.NativePtr, new FName("AddMaterialControllerDataGroupWithAnimObject"), out num);
		byte* ptr = stackalloc byte[(UIntPtr)((num != 0) ? (num + 15) : 0)];
		CharRenderingComponent.__AddMaterialControllerDataGroupWithAnimObject_FunctionParams* ptr2 = null;
		if (num != 0)
		{
			ptr2 = ((CharRenderingComponent.__AddMaterialControllerDataGroupWithAnimObject_FunctionParams*)ptr + 15L / (long)sizeof(CharRenderingComponent.__AddMaterialControllerDataGroupWithAnimObject_FunctionParams) & -16L);
			UnrealReflectionUtils.InitializeStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
			*(&ptr2->data) = ((data != null) ? data.NativePtr : ((IntPtr)0));
			*(&ptr2->animObject) = ((animObject != null) ? animObject.NativePtr : ((IntPtr)0));
		}
		UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ufunctionPtrAndSizeChecked, (void*)ptr2);
		float _Result = ptr2->__Result;
		if (num != 0)
		{
			UnrealReflectionUtils.DestroyStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
		}
		return _Result;
	}

	// Token: 0x0601BB73 RID: 113523 RVA: 0x0084479C File Offset: 0x0084299C
	[NullableContext(2)]
	protected unsafe float AddMaterialControllerDataGroupWithAnimObject_Implementation(UObject data, USkeletalMeshComponent animObject = null)
	{
		PD_CharacterControllerDataGroup_C pd_CharacterControllerDataGroup_C = data as PD_CharacterControllerDataGroup_C;
		if (pd_CharacterControllerDataGroup_C == null)
		{
			return -1f;
		}
		int num = this.IndexCount + 1;
		this.IndexCount = num;
		int num2 = num;
		int num3;
		if (this.UseMaterialContainerV2)
		{
			num3 = (this.GetComponent(14) as CharMaterialControllerV2).GetEffectCount();
		}
		else
		{
			num3 = (this.GetComponent(2) as CharMaterialController).AllMaterialControlRuntimeDataMap.Count;
		}
		if (num3 > 20)
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.RenderCharacter;
			ELogAuthor author = ELogAuthor.MY;
			string message = "材质控制器添加失败，超过单个角色的材质控制器队列数量，检查是否进行了材质控制器移除和材质控制器特效的持续时间";
			<>y__InlineArray3<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray3<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("Actor", base.GetOwner());
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("添加的材质控制器名称", data);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 2) = new ValueTuple<string, object>("ID", num2);
			instance.Error(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 3));
		}
		if (pd_CharacterControllerDataGroup_C.CleanOriginEffect)
		{
			this.CleanOriginEffect();
		}
		CharMaterialControlRuntimeDataGroup charMaterialControlRuntimeDataGroup = new CharMaterialControlRuntimeDataGroup();
		charMaterialControlRuntimeDataGroup.Init(this, pd_CharacterControllerDataGroup_C, animObject);
		this.AllMaterialControlRuntimeDataGroupMap[num2] = charMaterialControlRuntimeDataGroup;
		Singleton<EventSystem>.Instance.EmitWithTarget<UObject, int>(this, EEventName.OnAddMaterialControllerGroup, data, num2);
		return (float)num2;
	}

	// Token: 0x0601BB74 RID: 113524 RVA: 0x008448C0 File Offset: 0x00842AC0
	public void CleanOriginEffect()
	{
		CharMaterialControllerV2 charMaterialControllerV = this.GetComponent(14) as CharMaterialControllerV2;
		if (charMaterialControllerV != null)
		{
			charMaterialControllerV.CleanOriginEffectByOtherData();
		}
	}

	// Token: 0x0601BB75 RID: 113525 RVA: 0x008448E4 File Offset: 0x00842AE4
	[UFunction(EFunctionFlags.FUNC_BlueprintNativeEvent)]
	public unsafe virtual void RemoveMaterialControllerDataGroup(int handle)
	{
		int num;
		IntPtr ufunctionPtrAndSizeChecked = UnrealReflectionUtils.GetUFunctionPtrAndSizeChecked(base.NativePtr, new FName("RemoveMaterialControllerDataGroup"), out num);
		byte* ptr = stackalloc byte[(UIntPtr)((num != 0) ? (num + 15) : 0)];
		CharRenderingComponent.__RemoveMaterialControllerDataGroup_FunctionParams* ptr2 = null;
		if (num != 0)
		{
			ptr2 = ((CharRenderingComponent.__RemoveMaterialControllerDataGroup_FunctionParams*)ptr + 15L / (long)sizeof(CharRenderingComponent.__RemoveMaterialControllerDataGroup_FunctionParams) & -16L);
			UnrealReflectionUtils.InitializeStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
			ptr2->handle = handle;
		}
		UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ufunctionPtrAndSizeChecked, (void*)ptr2);
		if (num != 0)
		{
			UnrealReflectionUtils.DestroyStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
		}
	}

	// Token: 0x0601BB76 RID: 113526 RVA: 0x0084495C File Offset: 0x00842B5C
	protected void RemoveMaterialControllerDataGroup_Implementation(int handle)
	{
		CharMaterialControlRuntimeDataGroup charMaterialControlRuntimeDataGroup;
		if (this.AllMaterialControlRuntimeDataGroupMap.TryGetValue(handle, out charMaterialControlRuntimeDataGroup))
		{
			charMaterialControlRuntimeDataGroup.EndState();
		}
	}

	// Token: 0x0601BB77 RID: 113527 RVA: 0x00844980 File Offset: 0x00842B80
	[UFunction(EFunctionFlags.FUNC_BlueprintNativeEvent)]
	public unsafe virtual void RemoveMaterialControllerDataGroupWithEnding(int handle)
	{
		int num;
		IntPtr ufunctionPtrAndSizeChecked = UnrealReflectionUtils.GetUFunctionPtrAndSizeChecked(base.NativePtr, new FName("RemoveMaterialControllerDataGroupWithEnding"), out num);
		byte* ptr = stackalloc byte[(UIntPtr)((num != 0) ? (num + 15) : 0)];
		CharRenderingComponent.__RemoveMaterialControllerDataGroupWithEnding_FunctionParams* ptr2 = null;
		if (num != 0)
		{
			ptr2 = ((CharRenderingComponent.__RemoveMaterialControllerDataGroupWithEnding_FunctionParams*)ptr + 15L / (long)sizeof(CharRenderingComponent.__RemoveMaterialControllerDataGroupWithEnding_FunctionParams) & -16L);
			UnrealReflectionUtils.InitializeStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
			ptr2->handle = handle;
		}
		UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ufunctionPtrAndSizeChecked, (void*)ptr2);
		if (num != 0)
		{
			UnrealReflectionUtils.DestroyStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
		}
	}

	// Token: 0x0601BB78 RID: 113528 RVA: 0x008449F8 File Offset: 0x00842BF8
	protected void RemoveMaterialControllerDataGroupWithEnding_Implementation(int handle)
	{
		CharMaterialControlRuntimeDataGroup charMaterialControlRuntimeDataGroup;
		if (this.AllMaterialControlRuntimeDataGroupMap.TryGetValue(handle, out charMaterialControlRuntimeDataGroup))
		{
			charMaterialControlRuntimeDataGroup.EndStateWithEnding();
		}
	}

	// Token: 0x0601BB79 RID: 113529 RVA: 0x00844A1B File Offset: 0x00842C1B
	[NullableContext(2)]
	public AActor GetCachedOwner()
	{
		return this.CachedOwner;
	}

	// Token: 0x0601BB7A RID: 113530 RVA: 0x00844A23 File Offset: 0x00842C23
	[NullableContext(1)]
	public string GetCachedOwnerName()
	{
		return this.CachedOwnerName;
	}

	// Token: 0x0601BB7B RID: 113531 RVA: 0x00844A2B File Offset: 0x00842C2B
	[NullableContext(2)]
	public Entity GetCachedOwnerEntity()
	{
		return this.CachedOwnerEntity;
	}

	// Token: 0x0601BB7C RID: 113532 RVA: 0x00844A34 File Offset: 0x00842C34
	[NullableContext(2)]
	private int AddMaterialControllerDataInner(PD_CharacterControllerData_C data, UObject userData = null, USkeletalMeshComponent animObject = null)
	{
		if (data == null)
		{
			return -1;
		}
		if (data.CleanOriginEffect)
		{
			this.CleanOriginEffect();
		}
		int num;
		if (this.UseMaterialContainerV2)
		{
			num = this.AddMaterialControllerDataInnerV2(data, userData, animObject);
		}
		else
		{
			CharMaterialController charMaterialController = this.GetComponent(2) as CharMaterialController;
			if (charMaterialController == null)
			{
				return -1;
			}
			if (CharRenderingComponent.DisableForDebug)
			{
				this.ResetAllRenderingStateForDebug();
				return -1;
			}
			num = charMaterialController.AddMaterialControllerData(data, userData);
		}
		Singleton<EventSystem>.Instance.EmitWithTarget<PD_CharacterControllerData_C, UObject, int>(this, EEventName.OnAddMaterialController, data, userData, num);
		return num;
	}

	// Token: 0x0601BB7D RID: 113533 RVA: 0x00844AA9 File Offset: 0x00842CA9
	public void OnRemoveMaterialController(int handle)
	{
	}

	// Token: 0x0601BB7E RID: 113534 RVA: 0x00844AAC File Offset: 0x00842CAC
	[NullableContext(2)]
	private int AddMaterialControllerDataInnerV2([Nullable(1)] PD_CharacterControllerData_C data, UObject userData = null, USkeletalMeshComponent animObject = null)
	{
		CharMaterialControllerV2 charMaterialControllerV = this.GetComponent(14) as CharMaterialControllerV2;
		if (charMaterialControllerV == null)
		{
			return -1;
		}
		return charMaterialControllerV.AddMaterialControllerData(data, userData, animObject);
	}

	// Token: 0x0601BB7F RID: 113535 RVA: 0x00844AD8 File Offset: 0x00842CD8
	[NullableContext(2)]
	public int AddMaterialControllerDataWithUserData(UObject data, UObject userData)
	{
		PD_CharacterControllerData_C data2 = data as PD_CharacterControllerData_C;
		return this.AddMaterialControllerDataInner(data2, userData, null);
	}

	// Token: 0x0601BB80 RID: 113536 RVA: 0x00844AF8 File Offset: 0x00842CF8
	[NullableContext(2)]
	[UFunction(EFunctionFlags.FUNC_BlueprintNativeEvent)]
	public unsafe virtual float AddMaterialControllerDataWithAnimObject(UObject data, USkeletalMeshComponent animObject, UObject userData = null)
	{
		int num;
		IntPtr ufunctionPtrAndSizeChecked = UnrealReflectionUtils.GetUFunctionPtrAndSizeChecked(base.NativePtr, new FName("AddMaterialControllerDataWithAnimObject"), out num);
		byte* ptr = stackalloc byte[(UIntPtr)((num != 0) ? (num + 15) : 0)];
		CharRenderingComponent.__AddMaterialControllerDataWithAnimObject_FunctionParams* ptr2 = null;
		if (num != 0)
		{
			ptr2 = ((CharRenderingComponent.__AddMaterialControllerDataWithAnimObject_FunctionParams*)ptr + 15L / (long)sizeof(CharRenderingComponent.__AddMaterialControllerDataWithAnimObject_FunctionParams) & -16L);
			UnrealReflectionUtils.InitializeStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
			*(&ptr2->data) = ((data != null) ? data.NativePtr : ((IntPtr)0));
			*(&ptr2->animObject) = ((animObject != null) ? animObject.NativePtr : ((IntPtr)0));
			*(&ptr2->userData) = ((userData != null) ? userData.NativePtr : ((IntPtr)0));
		}
		UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ufunctionPtrAndSizeChecked, (void*)ptr2);
		float _Result = ptr2->__Result;
		if (num != 0)
		{
			UnrealReflectionUtils.DestroyStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
		}
		return _Result;
	}

	// Token: 0x0601BB81 RID: 113537 RVA: 0x00844BAC File Offset: 0x00842DAC
	[NullableContext(2)]
	protected float AddMaterialControllerDataWithAnimObject_Implementation(UObject data, USkeletalMeshComponent animObject, UObject userData = null)
	{
		PD_CharacterControllerData_C data2 = data as PD_CharacterControllerData_C;
		return (float)this.AddMaterialControllerDataInner(data2, userData, animObject);
	}

	// Token: 0x0601BB82 RID: 113538 RVA: 0x00844BCC File Offset: 0x00842DCC
	[NullableContext(2)]
	[UFunction(EFunctionFlags.FUNC_BlueprintNativeEvent)]
	public unsafe virtual int AddMaterialControllerData(UObject data)
	{
		int num;
		IntPtr ufunctionPtrAndSizeChecked = UnrealReflectionUtils.GetUFunctionPtrAndSizeChecked(base.NativePtr, new FName("AddMaterialControllerData"), out num);
		byte* ptr = stackalloc byte[(UIntPtr)((num != 0) ? (num + 15) : 0)];
		CharRenderingComponent.__AddMaterialControllerData_FunctionParams* ptr2 = null;
		if (num != 0)
		{
			ptr2 = ((CharRenderingComponent.__AddMaterialControllerData_FunctionParams*)ptr + 15L / (long)sizeof(CharRenderingComponent.__AddMaterialControllerData_FunctionParams) & -16L);
			UnrealReflectionUtils.InitializeStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
			*(&ptr2->data) = ((data != null) ? data.NativePtr : ((IntPtr)0));
		}
		UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ufunctionPtrAndSizeChecked, (void*)ptr2);
		int _Result = ptr2->__Result;
		if (num != 0)
		{
			UnrealReflectionUtils.DestroyStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
		}
		return _Result;
	}

	// Token: 0x0601BB83 RID: 113539 RVA: 0x00844C58 File Offset: 0x00842E58
	[NullableContext(2)]
	protected int AddMaterialControllerData_Implementation(UObject data)
	{
		PD_CharacterControllerData_C data2 = data as PD_CharacterControllerData_C;
		return this.AddMaterialControllerDataInner(data2, null, null);
	}

	// Token: 0x0601BB84 RID: 113540 RVA: 0x00844C78 File Offset: 0x00842E78
	[UFunction(EFunctionFlags.FUNC_BlueprintNativeEvent)]
	public unsafe virtual void RemoveMaterialControllerData(int handle)
	{
		int num;
		IntPtr ufunctionPtrAndSizeChecked = UnrealReflectionUtils.GetUFunctionPtrAndSizeChecked(base.NativePtr, new FName("RemoveMaterialControllerData"), out num);
		byte* ptr = stackalloc byte[(UIntPtr)((num != 0) ? (num + 15) : 0)];
		CharRenderingComponent.__RemoveMaterialControllerData_FunctionParams* ptr2 = null;
		if (num != 0)
		{
			ptr2 = ((CharRenderingComponent.__RemoveMaterialControllerData_FunctionParams*)ptr + 15L / (long)sizeof(CharRenderingComponent.__RemoveMaterialControllerData_FunctionParams) & -16L);
			UnrealReflectionUtils.InitializeStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
			ptr2->handle = handle;
		}
		UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ufunctionPtrAndSizeChecked, (void*)ptr2);
		if (num != 0)
		{
			UnrealReflectionUtils.DestroyStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
		}
	}

	// Token: 0x0601BB85 RID: 113541 RVA: 0x00844CF0 File Offset: 0x00842EF0
	protected void RemoveMaterialControllerData_Implementation(int handle)
	{
		if (this.UseMaterialContainerV2)
		{
			CharMaterialControllerV2 charMaterialControllerV = this.GetComponent(14) as CharMaterialControllerV2;
			if (charMaterialControllerV == null)
			{
				return;
			}
			charMaterialControllerV.RemoveMaterialControllerData(handle);
			return;
		}
		else
		{
			CharMaterialController charMaterialController = this.GetComponent(2) as CharMaterialController;
			if (charMaterialController == null)
			{
				return;
			}
			charMaterialController.RemoveMaterialControllerData(handle);
			return;
		}
	}

	// Token: 0x0601BB86 RID: 113542 RVA: 0x00844D3C File Offset: 0x00842F3C
	public void RemoveAllUnloopedEffects()
	{
		CharMaterialContainerV2 charMaterialContainerV = this.GetComponent(13) as CharMaterialContainerV2;
		if (charMaterialContainerV == null)
		{
			return;
		}
		charMaterialContainerV.RemoveAllUnloopedEffects();
	}

	// Token: 0x0601BB87 RID: 113543 RVA: 0x00844D64 File Offset: 0x00842F64
	public void UpdateMaterialEffectsOnly()
	{
		if (this.UseMaterialContainerV2)
		{
			CharMaterialContainerV2 charMaterialContainerV = this.GetComponent(13) as CharMaterialContainerV2;
			if (charMaterialContainerV == null)
			{
				return;
			}
			charMaterialContainerV.UpdateEffectsOnly();
		}
	}

	// Token: 0x0601BB88 RID: 113544 RVA: 0x00844D94 File Offset: 0x00842F94
	[UFunction(EFunctionFlags.FUNC_BlueprintNativeEvent)]
	public unsafe virtual void SetEffectPause(int handle, bool paused)
	{
		int num;
		IntPtr ufunctionPtrAndSizeChecked = UnrealReflectionUtils.GetUFunctionPtrAndSizeChecked(base.NativePtr, new FName("SetEffectPause"), out num);
		byte* ptr = stackalloc byte[(UIntPtr)((num != 0) ? (num + 15) : 0)];
		CharRenderingComponent.__SetEffectPause_FunctionParams* ptr2 = null;
		if (num != 0)
		{
			ptr2 = ((CharRenderingComponent.__SetEffectPause_FunctionParams*)ptr + 15L / (long)sizeof(CharRenderingComponent.__SetEffectPause_FunctionParams) & -16L);
			UnrealReflectionUtils.InitializeStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
			ptr2->handle = handle;
			ptr2->paused = paused;
		}
		UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ufunctionPtrAndSizeChecked, (void*)ptr2);
		if (num != 0)
		{
			UnrealReflectionUtils.DestroyStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
		}
	}

	// Token: 0x0601BB89 RID: 113545 RVA: 0x00844E14 File Offset: 0x00843014
	protected void SetEffectPause_Implementation(int handle, bool paused)
	{
		if (this.UseMaterialContainerV2)
		{
			CharMaterialContainerV2 charMaterialContainerV = this.GetComponent(13) as CharMaterialContainerV2;
			if (charMaterialContainerV == null)
			{
				return;
			}
			charMaterialContainerV.SetEffectPause(handle, paused);
		}
	}

	// Token: 0x0601BB8A RID: 113546 RVA: 0x00844E44 File Offset: 0x00843044
	[UFunction(EFunctionFlags.FUNC_BlueprintNativeEvent)]
	public unsafe virtual void RemoveMaterialControllerDataWithEnding(int handle)
	{
		int num;
		IntPtr ufunctionPtrAndSizeChecked = UnrealReflectionUtils.GetUFunctionPtrAndSizeChecked(base.NativePtr, new FName("RemoveMaterialControllerDataWithEnding"), out num);
		byte* ptr = stackalloc byte[(UIntPtr)((num != 0) ? (num + 15) : 0)];
		CharRenderingComponent.__RemoveMaterialControllerDataWithEnding_FunctionParams* ptr2 = null;
		if (num != 0)
		{
			ptr2 = ((CharRenderingComponent.__RemoveMaterialControllerDataWithEnding_FunctionParams*)ptr + 15L / (long)sizeof(CharRenderingComponent.__RemoveMaterialControllerDataWithEnding_FunctionParams) & -16L);
			UnrealReflectionUtils.InitializeStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
			ptr2->handle = handle;
		}
		UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ufunctionPtrAndSizeChecked, (void*)ptr2);
		if (num != 0)
		{
			UnrealReflectionUtils.DestroyStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
		}
	}

	// Token: 0x0601BB8B RID: 113547 RVA: 0x00844EBC File Offset: 0x008430BC
	protected void RemoveMaterialControllerDataWithEnding_Implementation(int handle)
	{
		if (this.UseMaterialContainerV2)
		{
			CharMaterialControllerV2 charMaterialControllerV = this.GetComponent(14) as CharMaterialControllerV2;
			if (charMaterialControllerV == null)
			{
				return;
			}
			charMaterialControllerV.RemoveMaterialControllerDataWithEnding(handle);
			return;
		}
		else
		{
			CharMaterialController charMaterialController = this.GetComponent(2) as CharMaterialController;
			if (charMaterialController == null)
			{
				return;
			}
			charMaterialController.RemoveMaterialControllerDataWithEnding(handle);
			return;
		}
	}

	// Token: 0x0601BB8C RID: 113548 RVA: 0x00844F08 File Offset: 0x00843108
	public unsafe void UpdateNpcDitherComponent()
	{
		if (!this.IsInit)
		{
			return;
		}
		ECharacterRenderingType? renderType = this.RenderType;
		ECharacterRenderingType echaracterRenderingType = ECharacterRenderingType.Npc;
		if (!(renderType.GetValueOrDefault() == echaracterRenderingType & renderType != null))
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.RenderCharacter;
			ELogAuthor author = ELogAuthor.LSY;
			string message = "NPC更新不是NPC类型";
			<>y__InlineArray3<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray3<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("Owner", this.CachedOwnerName);
			ref ValueTuple<string, object> ptr = ref <PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1);
			string item = "EntityId";
			Entity cachedOwnerEntity = this.CachedOwnerEntity;
			ptr = new ValueTuple<string, object>(item, (cachedOwnerEntity != null) ? new int?(cachedOwnerEntity.Id) : null);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 2) = new ValueTuple<string, object>("实际类型", this.RenderType);
			instance.Error(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 3));
			return;
		}
		CharDitherEffect charDitherEffect = this.GetComponent(3) as CharDitherEffect;
		if (charDitherEffect == null)
		{
			return;
		}
		charDitherEffect.UpdateNpcDitherComponent();
	}

	// Token: 0x0601BB8D RID: 113549 RVA: 0x00844FF4 File Offset: 0x008431F4
	[UFunction(EFunctionFlags.FUNC_BlueprintNativeEvent)]
	public unsafe virtual void SetDitherEffect(float ditherRate, ECharacterDitherType ditherType)
	{
		int num;
		IntPtr ufunctionPtrAndSizeChecked = UnrealReflectionUtils.GetUFunctionPtrAndSizeChecked(base.NativePtr, new FName("SetDitherEffect"), out num);
		byte* ptr = stackalloc byte[(UIntPtr)((num != 0) ? (num + 15) : 0)];
		CharRenderingComponent.__SetDitherEffect_FunctionParams* ptr2 = null;
		if (num != 0)
		{
			ptr2 = ((CharRenderingComponent.__SetDitherEffect_FunctionParams*)ptr + 15L / (long)sizeof(CharRenderingComponent.__SetDitherEffect_FunctionParams) & -16L);
			UnrealReflectionUtils.InitializeStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
			ptr2->ditherRate = ditherRate;
			*(&ptr2->ditherType) = (byte)ditherType;
		}
		UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ufunctionPtrAndSizeChecked, (void*)ptr2);
		if (num != 0)
		{
			UnrealReflectionUtils.DestroyStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
		}
	}

	// Token: 0x0601BB8E RID: 113550 RVA: 0x00845074 File Offset: 0x00843274
	protected void SetDitherEffect_Implementation(float ditherRate, ECharacterDitherType ditherType)
	{
		CharDitherEffect charDitherEffect = this.GetComponent(3) as CharDitherEffect;
		if (charDitherEffect == null)
		{
			return;
		}
		float num = ditherRate;
		if (ditherType == ECharacterDitherType.Fight)
		{
			this.FightDitherRateCache = ditherRate;
			num = (this.DisableFightDither ? 1f : ditherRate);
		}
		num = (CharRenderingComponent.GlobalDisableDitherEffect ? 1f : num);
		num = Singleton<MathUtils>.Instance.Clamp(num / (1f - this.DitherRemap), 0f, 1f);
		try
		{
			charDitherEffect.SetDitherEffect(num, ditherType);
			this.SetBodyEffectOpacity(charDitherEffect.GetDitherRate());
			this.SetDecalShadowOpacity(charDitherEffect.GetDitherRate());
			this.SetRealTimeShadowOpacity(charDitherEffect.GetDitherRate());
		}
		catch (Exception ex)
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.Render;
			ELogAuthor author = ELogAuthor.LSY;
			string message = "CharacterRenderingComponent.SetDitherEffect执行异常";
			Exception error = ex;
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("error", ex.Message);
			instance.ErrorWithStack(module, author, message, error, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
		}
	}

	// Token: 0x0601BB8F RID: 113551 RVA: 0x00845154 File Offset: 0x00843354
	[UFunction(EFunctionFlags.FUNC_BlueprintNativeEvent)]
	public unsafe virtual void SetDisableFightDither(bool disable)
	{
		int num;
		IntPtr ufunctionPtrAndSizeChecked = UnrealReflectionUtils.GetUFunctionPtrAndSizeChecked(base.NativePtr, new FName("SetDisableFightDither"), out num);
		byte* ptr = stackalloc byte[(UIntPtr)((num != 0) ? (num + 15) : 0)];
		CharRenderingComponent.__SetDisableFightDither_FunctionParams* ptr2 = null;
		if (num != 0)
		{
			ptr2 = ((CharRenderingComponent.__SetDisableFightDither_FunctionParams*)ptr + 15L / (long)sizeof(CharRenderingComponent.__SetDisableFightDither_FunctionParams) & -16L);
			UnrealReflectionUtils.InitializeStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
			ptr2->disable = disable;
		}
		UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ufunctionPtrAndSizeChecked, (void*)ptr2);
		if (num != 0)
		{
			UnrealReflectionUtils.DestroyStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
		}
	}

	// Token: 0x0601BB90 RID: 113552 RVA: 0x008451CA File Offset: 0x008433CA
	protected void SetDisableFightDither_Implementation(bool disable)
	{
		this.DisableFightDither = disable;
		this.SetDitherEffect(this.FightDitherRateCache, ECharacterDitherType.Fight);
	}

	// Token: 0x0601BB91 RID: 113553 RVA: 0x008451E0 File Offset: 0x008433E0
	[UFunction(EFunctionFlags.FUNC_BlueprintNativeEvent)]
	public unsafe virtual void SetDitherApplyAll()
	{
		int num;
		IntPtr ufunctionPtrAndSizeChecked = UnrealReflectionUtils.GetUFunctionPtrAndSizeChecked(base.NativePtr, new FName("SetDitherApplyAll"), out num);
		byte* ptr = stackalloc byte[(UIntPtr)((num != 0) ? (num + 15) : 0)];
		byte* dest = null;
		if (num != 0)
		{
			dest = (ptr + 15L & -16L);
			UnrealReflectionUtils.InitializeStruct(ufunctionPtrAndSizeChecked, (void*)dest, 1);
		}
		UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ufunctionPtrAndSizeChecked, null);
		if (num != 0)
		{
			UnrealReflectionUtils.DestroyStruct(ufunctionPtrAndSizeChecked, (void*)dest, 1);
		}
	}

	// Token: 0x0601BB92 RID: 113554 RVA: 0x00845250 File Offset: 0x00843450
	protected void SetDitherApplyAll_Implementation()
	{
		CharDitherEffect charDitherEffect = this.GetComponent(3) as CharDitherEffect;
		if (charDitherEffect == null)
		{
			return;
		}
		charDitherEffect.SetDitherMask(new List<EKuroCharMeshPart>(), false);
	}

	// Token: 0x0601BB93 RID: 113555 RVA: 0x0084527C File Offset: 0x0084347C
	[UFunction(EFunctionFlags.FUNC_BlueprintNativeEvent)]
	public unsafe virtual void SetDitherApplyHeadsOnly()
	{
		int num;
		IntPtr ufunctionPtrAndSizeChecked = UnrealReflectionUtils.GetUFunctionPtrAndSizeChecked(base.NativePtr, new FName("SetDitherApplyHeadsOnly"), out num);
		byte* ptr = stackalloc byte[(UIntPtr)((num != 0) ? (num + 15) : 0)];
		byte* dest = null;
		if (num != 0)
		{
			dest = (ptr + 15L & -16L);
			UnrealReflectionUtils.InitializeStruct(ufunctionPtrAndSizeChecked, (void*)dest, 1);
		}
		UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ufunctionPtrAndSizeChecked, null);
		if (num != 0)
		{
			UnrealReflectionUtils.DestroyStruct(ufunctionPtrAndSizeChecked, (void*)dest, 1);
		}
	}

	// Token: 0x0601BB94 RID: 113556 RVA: 0x008452EC File Offset: 0x008434EC
	protected void SetDitherApplyHeadsOnly_Implementation()
	{
		CharDitherEffect charDitherEffect = this.GetComponent(3) as CharDitherEffect;
		if (charDitherEffect == null)
		{
			return;
		}
		charDitherEffect.SetDitherMask(RenderConfig.MeshPartsHeadArray.ToList<EKuroCharMeshPart>(), true);
	}

	// Token: 0x0601BB95 RID: 113557 RVA: 0x0084531C File Offset: 0x0084351C
	[UFunction(EFunctionFlags.FUNC_BlueprintNativeEvent)]
	public unsafe virtual void SetDitherUseHeadMaskHideEffect(bool enable)
	{
		int num;
		IntPtr ufunctionPtrAndSizeChecked = UnrealReflectionUtils.GetUFunctionPtrAndSizeChecked(base.NativePtr, new FName("SetDitherUseHeadMaskHideEffect"), out num);
		byte* ptr = stackalloc byte[(UIntPtr)((num != 0) ? (num + 15) : 0)];
		CharRenderingComponent.__SetDitherUseHeadMaskHideEffect_FunctionParams* ptr2 = null;
		if (num != 0)
		{
			ptr2 = ((CharRenderingComponent.__SetDitherUseHeadMaskHideEffect_FunctionParams*)ptr + 15L / (long)sizeof(CharRenderingComponent.__SetDitherUseHeadMaskHideEffect_FunctionParams) & -16L);
			UnrealReflectionUtils.InitializeStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
			ptr2->enable = enable;
		}
		UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ufunctionPtrAndSizeChecked, (void*)ptr2);
		if (num != 0)
		{
			UnrealReflectionUtils.DestroyStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
		}
	}

	// Token: 0x0601BB96 RID: 113558 RVA: 0x00845394 File Offset: 0x00843594
	protected void SetDitherUseHeadMaskHideEffect_Implementation(bool enable)
	{
		CharMaterialContainerV2 charMaterialContainerV = this.GetComponent(13) as CharMaterialContainerV2;
		if (charMaterialContainerV == null)
		{
			return;
		}
		charMaterialContainerV.EnableTickGetHeadPosInAllMeshes(enable);
	}

	// Token: 0x0601BB97 RID: 113559 RVA: 0x008453BC File Offset: 0x008435BC
	[UFunction(EFunctionFlags.FUNC_BlueprintNativeEvent)]
	public unsafe virtual void TempRemoveDither()
	{
		int num;
		IntPtr ufunctionPtrAndSizeChecked = UnrealReflectionUtils.GetUFunctionPtrAndSizeChecked(base.NativePtr, new FName("TempRemoveDither"), out num);
		byte* ptr = stackalloc byte[(UIntPtr)((num != 0) ? (num + 15) : 0)];
		byte* dest = null;
		if (num != 0)
		{
			dest = (ptr + 15L & -16L);
			UnrealReflectionUtils.InitializeStruct(ufunctionPtrAndSizeChecked, (void*)dest, 1);
		}
		UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ufunctionPtrAndSizeChecked, null);
		if (num != 0)
		{
			UnrealReflectionUtils.DestroyStruct(ufunctionPtrAndSizeChecked, (void*)dest, 1);
		}
	}

	// Token: 0x0601BB98 RID: 113560 RVA: 0x0084542C File Offset: 0x0084362C
	protected void TempRemoveDither_Implementation()
	{
		CharDitherEffect charDitherEffect = this.GetComponent(3) as CharDitherEffect;
		if (charDitherEffect == null)
		{
			return;
		}
		charDitherEffect.TempRemoveDither();
	}

	// Token: 0x0601BB99 RID: 113561 RVA: 0x00845450 File Offset: 0x00843650
	[UFunction(EFunctionFlags.FUNC_BlueprintNativeEvent)]
	public unsafe virtual void TempRecoverDither()
	{
		int num;
		IntPtr ufunctionPtrAndSizeChecked = UnrealReflectionUtils.GetUFunctionPtrAndSizeChecked(base.NativePtr, new FName("TempRecoverDither"), out num);
		byte* ptr = stackalloc byte[(UIntPtr)((num != 0) ? (num + 15) : 0)];
		byte* dest = null;
		if (num != 0)
		{
			dest = (ptr + 15L & -16L);
			UnrealReflectionUtils.InitializeStruct(ufunctionPtrAndSizeChecked, (void*)dest, 1);
		}
		UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ufunctionPtrAndSizeChecked, null);
		if (num != 0)
		{
			UnrealReflectionUtils.DestroyStruct(ufunctionPtrAndSizeChecked, (void*)dest, 1);
		}
	}

	// Token: 0x0601BB9A RID: 113562 RVA: 0x008454C0 File Offset: 0x008436C0
	protected void TempRecoverDither_Implementation()
	{
		CharDitherEffect charDitherEffect = this.GetComponent(3) as CharDitherEffect;
		if (charDitherEffect == null)
		{
			return;
		}
		charDitherEffect.TempRecoverDither();
	}

	// Token: 0x0601BB9B RID: 113563 RVA: 0x008454E4 File Offset: 0x008436E4
	public void RegisterBodyEffect(int handle)
	{
		CharBodyEffect charBodyEffect = this.GetComponent(9) as CharBodyEffect;
		if (this.IsInit && charBodyEffect == null)
		{
			charBodyEffect = (this.AddRenderCompDynamic(new CharBodyEffect()) as CharBodyEffect);
			if (charBodyEffect == null)
			{
				return;
			}
		}
		charBodyEffect.RegisterEffect(handle);
	}

	// Token: 0x0601BB9C RID: 113564 RVA: 0x00845528 File Offset: 0x00843728
	public void UnregisterBodyEffect(int handle)
	{
		CharBodyEffect charBodyEffect = this.GetComponent(9) as CharBodyEffect;
		if (charBodyEffect == null)
		{
			return;
		}
		charBodyEffect.UnregisterEffect(handle);
	}

	// Token: 0x0601BB9D RID: 113565 RVA: 0x00845550 File Offset: 0x00843750
	protected void SetBodyEffectOpacity(float opacity)
	{
		CharBodyEffect charBodyEffect = this.GetComponent(9) as CharBodyEffect;
		if (charBodyEffect == null)
		{
			return;
		}
		charBodyEffect.SetOpacity(opacity, ECharBodyEffectOpacityType.Default);
	}

	// Token: 0x0601BB9E RID: 113566 RVA: 0x00845578 File Offset: 0x00843778
	[UFunction(EFunctionFlags.FUNC_BlueprintNativeEvent)]
	public unsafe virtual float GetOpacityConsiderVisibility()
	{
		int num;
		IntPtr ufunctionPtrAndSizeChecked = UnrealReflectionUtils.GetUFunctionPtrAndSizeChecked(base.NativePtr, new FName("GetOpacityConsiderVisibility"), out num);
		byte* ptr = stackalloc byte[(UIntPtr)((num != 0) ? (num + 15) : 0)];
		CharRenderingComponent.__GetOpacityConsiderVisibility_FunctionParams* ptr2 = null;
		if (num != 0)
		{
			ptr2 = ((CharRenderingComponent.__GetOpacityConsiderVisibility_FunctionParams*)ptr + 15L / (long)sizeof(CharRenderingComponent.__GetOpacityConsiderVisibility_FunctionParams) & -16L);
			UnrealReflectionUtils.InitializeStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
		}
		UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ufunctionPtrAndSizeChecked, (void*)ptr2);
		float _Result = ptr2->__Result;
		if (num != 0)
		{
			UnrealReflectionUtils.DestroyStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
		}
		return _Result;
	}

	// Token: 0x0601BB9F RID: 113567 RVA: 0x008455F0 File Offset: 0x008437F0
	protected float GetOpacityConsiderVisibility_Implementation()
	{
		CharBodyEffect charBodyEffect = this.GetComponent(9) as CharBodyEffect;
		if (charBodyEffect == null)
		{
			return 1f;
		}
		return charBodyEffect.GetOpacityConsiderVisibility();
	}

	// Token: 0x0601BBA0 RID: 113568 RVA: 0x0084561C File Offset: 0x0084381C
	[NullableContext(2)]
	public void AddInteraction(PDA_InteractionPlayerConfig_C data, float updateInternalScale = 1f)
	{
		if (data == null)
		{
			return;
		}
		CharSceneInteraction charSceneInteraction = this.GetComponent(5) as CharSceneInteraction;
		if (charSceneInteraction != null && !charSceneInteraction.GetIsPossed())
		{
			charSceneInteraction.PossCharacter(data, updateInternalScale);
		}
		CharGrassInteraction charGrassInteraction = this.GetComponent(11) as CharGrassInteraction;
		if (charGrassInteraction != null)
		{
			charGrassInteraction.SetConfig(data);
		}
		if (!this.OnRoleGoDownFinishEventAdded && this.CachedOwnerEntity != null)
		{
			this.RemoveInteractionOnRoleGoDownFinish = new Action(this.RemoveInteraction);
			Singleton<EventSystem>.Instance.AddWithTarget(this.CachedOwnerEntity, EEventName.OnRoleGoDownFinish, this.RemoveInteractionOnRoleGoDownFinish);
			this.OnRoleGoDownFinishEventAdded = true;
		}
	}

	// Token: 0x0601BBA1 RID: 113569 RVA: 0x008456AC File Offset: 0x008438AC
	public void RemoveInteraction()
	{
		CharSceneInteraction charSceneInteraction = this.GetComponent(5) as CharSceneInteraction;
		if (charSceneInteraction != null)
		{
			charSceneInteraction.UnpossCharacter();
		}
		CharGrassInteraction charGrassInteraction = this.GetComponent(11) as CharGrassInteraction;
		if (charGrassInteraction != null)
		{
			charGrassInteraction.SetEnabled(false);
		}
	}

	// Token: 0x0601BBA2 RID: 113570 RVA: 0x008456E7 File Offset: 0x008438E7
	[NullableContext(2)]
	public void AddMotorExtraCompInner(PD_MotorExtraComponentData_C data)
	{
		if (this.MotorExtraComp == null || !this.MotorExtraComp.IsValid())
		{
			this.MotorExtraComp = new BP_MotorExtraComponent_C();
		}
		BP_MotorExtraComponent_C motorExtraComp = this.MotorExtraComp;
		if (motorExtraComp == null)
		{
			return;
		}
		motorExtraComp.AddAllMotorExtraComponent_Func(data, base.GetOwner());
	}

	// Token: 0x0601BBA3 RID: 113571 RVA: 0x00845720 File Offset: 0x00843920
	[NullableContext(2)]
	public void AddMotorExtraComp(UObject data)
	{
		PD_MotorExtraComponentData_C data2 = data as PD_MotorExtraComponentData_C;
		this.AddMotorExtraCompInner(data2);
	}

	// Token: 0x0601BBA4 RID: 113572 RVA: 0x0084573B File Offset: 0x0084393B
	public void RemoveMotorExtraComp()
	{
		if (this.MotorExtraComp != null && this.MotorExtraComp.IsValid())
		{
			this.MotorExtraComp.RemoveAllMotorExtraComponent_Func();
		}
	}

	// Token: 0x0601BBA5 RID: 113573 RVA: 0x00845760 File Offset: 0x00843960
	[NullableContext(1)]
	[UFunction(EFunctionFlags.FUNC_BlueprintNativeEvent)]
	public unsafe virtual void SetMaterialPropertyFloat(ECharacterBodySpecifiedType bodyType, float sectionIndex, ECharacterSlotSpecifiedType slotType, string propertyName, float value)
	{
		int num;
		IntPtr ufunctionPtrAndSizeChecked = UnrealReflectionUtils.GetUFunctionPtrAndSizeChecked(base.NativePtr, new FName("SetMaterialPropertyFloat"), out num);
		byte* ptr = stackalloc byte[(UIntPtr)((num != 0) ? (num + 15) : 0)];
		CharRenderingComponent.__SetMaterialPropertyFloat_FunctionParams* ptr2 = null;
		if (num != 0)
		{
			ptr2 = ((CharRenderingComponent.__SetMaterialPropertyFloat_FunctionParams*)ptr + 15L / (long)sizeof(CharRenderingComponent.__SetMaterialPropertyFloat_FunctionParams) & -16L);
			UnrealReflectionUtils.InitializeStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
			*(&ptr2->bodyType) = (byte)bodyType;
			ptr2->sectionIndex = sectionIndex;
			*(&ptr2->slotType) = (byte)slotType;
			FString.CopyFrom((void*)(&ptr2->propertyName), propertyName);
			ptr2->value = value;
		}
		UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ufunctionPtrAndSizeChecked, (void*)ptr2);
		if (num != 0)
		{
			UnrealReflectionUtils.DestroyStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
		}
	}

	// Token: 0x0601BBA6 RID: 113574 RVA: 0x00845800 File Offset: 0x00843A00
	[NullableContext(1)]
	protected void SetMaterialPropertyFloat_Implementation(ECharacterBodySpecifiedType bodyType, float sectionIndex, ECharacterSlotSpecifiedType slotType, string propertyName, float value)
	{
		CharPropertyModifier charPropertyModifier = this.GetComponent(6) as CharPropertyModifier;
		if (charPropertyModifier == null)
		{
			return;
		}
		charPropertyModifier.SetPropertyFloat(bodyType, (int)sectionIndex, slotType, FNameUtil.GetDynamicFName(propertyName), value);
	}

	// Token: 0x0601BBA7 RID: 113575 RVA: 0x00845834 File Offset: 0x00843A34
	[NullableContext(1)]
	[UFunction(EFunctionFlags.FUNC_BlueprintNativeEvent)]
	public unsafe virtual void SetMaterialPropertyColor(ECharacterBodySpecifiedType bodyType, float sectionIndex, ECharacterSlotSpecifiedType slotType, string propertyName, FLinearColor value)
	{
		int num;
		IntPtr ufunctionPtrAndSizeChecked = UnrealReflectionUtils.GetUFunctionPtrAndSizeChecked(base.NativePtr, new FName("SetMaterialPropertyColor"), out num);
		byte* ptr = stackalloc byte[(UIntPtr)((num != 0) ? (num + 15) : 0)];
		CharRenderingComponent.__SetMaterialPropertyColor_FunctionParams* ptr2 = null;
		if (num != 0)
		{
			ptr2 = ((CharRenderingComponent.__SetMaterialPropertyColor_FunctionParams*)ptr + 15L / (long)sizeof(CharRenderingComponent.__SetMaterialPropertyColor_FunctionParams) & -16L);
			UnrealReflectionUtils.InitializeStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
			*(&ptr2->bodyType) = (byte)bodyType;
			ptr2->sectionIndex = sectionIndex;
			*(&ptr2->slotType) = (byte)slotType;
			FString.CopyFrom((void*)(&ptr2->propertyName), propertyName);
			ptr2->value = value;
		}
		UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ufunctionPtrAndSizeChecked, (void*)ptr2);
		if (num != 0)
		{
			UnrealReflectionUtils.DestroyStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
		}
	}

	// Token: 0x0601BBA8 RID: 113576 RVA: 0x008458D4 File Offset: 0x00843AD4
	[NullableContext(1)]
	protected void SetMaterialPropertyColor_Implementation(ECharacterBodySpecifiedType bodyType, float sectionIndex, ECharacterSlotSpecifiedType slotType, string propertyName, FLinearColor value)
	{
		CharPropertyModifier charPropertyModifier = this.GetComponent(6) as CharPropertyModifier;
		if (charPropertyModifier == null)
		{
			return;
		}
		charPropertyModifier.SetPropertyColor(bodyType, (int)sectionIndex, slotType, FNameUtil.GetDynamicFName(propertyName), value);
	}

	// Token: 0x0601BBA9 RID: 113577 RVA: 0x00845908 File Offset: 0x00843B08
	[UFunction(EFunctionFlags.FUNC_BlueprintNativeEvent)]
	public unsafe virtual void SetMaterialPropertyFloatV2(FName name, float value, EKuroCharBodySpecifiedType bodyType, EKuroCharSlotSpecifiedType slotType, EKuroCharMeshPart meshPart)
	{
		int num;
		IntPtr ufunctionPtrAndSizeChecked = UnrealReflectionUtils.GetUFunctionPtrAndSizeChecked(base.NativePtr, new FName("SetMaterialPropertyFloatV2"), out num);
		byte* ptr = stackalloc byte[(UIntPtr)((num != 0) ? (num + 15) : 0)];
		CharRenderingComponent.__SetMaterialPropertyFloatV2_FunctionParams* ptr2 = null;
		if (num != 0)
		{
			ptr2 = ((CharRenderingComponent.__SetMaterialPropertyFloatV2_FunctionParams*)ptr + 15L / (long)sizeof(CharRenderingComponent.__SetMaterialPropertyFloatV2_FunctionParams) & -16L);
			UnrealReflectionUtils.InitializeStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
			ptr2->name = name;
			ptr2->value = value;
			*(&ptr2->bodyType) = (byte)bodyType;
			*(&ptr2->slotType) = (byte)slotType;
			*(&ptr2->meshPart) = (byte)meshPart;
		}
		UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ufunctionPtrAndSizeChecked, (void*)ptr2);
		if (num != 0)
		{
			UnrealReflectionUtils.DestroyStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
		}
	}

	// Token: 0x0601BBAA RID: 113578 RVA: 0x008459A4 File Offset: 0x00843BA4
	protected void SetMaterialPropertyFloatV2_Implementation(FName name, float value, EKuroCharBodySpecifiedType bodyType, EKuroCharSlotSpecifiedType slotType, EKuroCharMeshPart meshPart)
	{
		CharMaterialContainerV2 charMaterialContainerV = this.GetComponent(13) as CharMaterialContainerV2;
		if (charMaterialContainerV == null)
		{
			return;
		}
		charMaterialContainerV.SetFloatUpdateParamPermanent(name, value, bodyType, slotType, new EKuroCharMeshPart?(meshPart));
	}

	// Token: 0x0601BBAB RID: 113579 RVA: 0x008459D8 File Offset: 0x00843BD8
	[UFunction(EFunctionFlags.FUNC_BlueprintNativeEvent)]
	public unsafe virtual void AddFloatUpdateParamPermanentByIndexV2(FName name, float value, FName bodyName, float materialIndex)
	{
		int num;
		IntPtr ufunctionPtrAndSizeChecked = UnrealReflectionUtils.GetUFunctionPtrAndSizeChecked(base.NativePtr, new FName("AddFloatUpdateParamPermanentByIndexV2"), out num);
		byte* ptr = stackalloc byte[(UIntPtr)((num != 0) ? (num + 15) : 0)];
		CharRenderingComponent.__AddFloatUpdateParamPermanentByIndexV2_FunctionParams* ptr2 = null;
		if (num != 0)
		{
			ptr2 = ((CharRenderingComponent.__AddFloatUpdateParamPermanentByIndexV2_FunctionParams*)ptr + 15L / (long)sizeof(CharRenderingComponent.__AddFloatUpdateParamPermanentByIndexV2_FunctionParams) & -16L);
			UnrealReflectionUtils.InitializeStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
			ptr2->name = name;
			ptr2->value = value;
			ptr2->bodyName = bodyName;
			ptr2->materialIndex = materialIndex;
		}
		UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ufunctionPtrAndSizeChecked, (void*)ptr2);
		if (num != 0)
		{
			UnrealReflectionUtils.DestroyStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
		}
	}

	// Token: 0x0601BBAC RID: 113580 RVA: 0x00845A64 File Offset: 0x00843C64
	protected void AddFloatUpdateParamPermanentByIndexV2_Implementation(FName name, float value, FName bodyName, float materialIndex)
	{
		CharMaterialContainerV2 charMaterialContainerV = this.GetComponent(13) as CharMaterialContainerV2;
		if (charMaterialContainerV == null)
		{
			return;
		}
		charMaterialContainerV.AddFloatUpdateParamPermanentByIndex(name, value, bodyName, (int)materialIndex);
	}

	// Token: 0x0601BBAD RID: 113581 RVA: 0x00845A90 File Offset: 0x00843C90
	[UFunction(EFunctionFlags.FUNC_BlueprintNativeEvent)]
	public unsafe virtual void SetMaterialPropertyColorV2(FName name, FLinearColor value, EKuroCharBodySpecifiedType bodyType, EKuroCharSlotSpecifiedType slotType, EKuroCharMeshPart meshPart)
	{
		int num;
		IntPtr ufunctionPtrAndSizeChecked = UnrealReflectionUtils.GetUFunctionPtrAndSizeChecked(base.NativePtr, new FName("SetMaterialPropertyColorV2"), out num);
		byte* ptr = stackalloc byte[(UIntPtr)((num != 0) ? (num + 15) : 0)];
		CharRenderingComponent.__SetMaterialPropertyColorV2_FunctionParams* ptr2 = null;
		if (num != 0)
		{
			ptr2 = ((CharRenderingComponent.__SetMaterialPropertyColorV2_FunctionParams*)ptr + 15L / (long)sizeof(CharRenderingComponent.__SetMaterialPropertyColorV2_FunctionParams) & -16L);
			UnrealReflectionUtils.InitializeStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
			ptr2->name = name;
			ptr2->value = value;
			*(&ptr2->bodyType) = (byte)bodyType;
			*(&ptr2->slotType) = (byte)slotType;
			*(&ptr2->meshPart) = (byte)meshPart;
		}
		UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ufunctionPtrAndSizeChecked, (void*)ptr2);
		if (num != 0)
		{
			UnrealReflectionUtils.DestroyStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
		}
	}

	// Token: 0x0601BBAE RID: 113582 RVA: 0x00845B2C File Offset: 0x00843D2C
	protected void SetMaterialPropertyColorV2_Implementation(FName name, FLinearColor value, EKuroCharBodySpecifiedType bodyType, EKuroCharSlotSpecifiedType slotType, EKuroCharMeshPart meshPart)
	{
		CharMaterialContainerV2 charMaterialContainerV = this.GetComponent(13) as CharMaterialContainerV2;
		if (charMaterialContainerV == null)
		{
			return;
		}
		charMaterialContainerV.SetColorUpdateParamPermanent(name, value, bodyType, slotType, new EKuroCharMeshPart?(meshPart));
	}

	// Token: 0x0601BBAF RID: 113583 RVA: 0x00845B60 File Offset: 0x00843D60
	[NullableContext(1)]
	[UFunction(EFunctionFlags.FUNC_BlueprintNativeEvent)]
	public unsafe virtual void SetMaterialReplaceV2(UMaterialInterface material, EKuroCharBodySpecifiedType bodyType, EKuroCharSlotSpecifiedType slotType, EKuroCharMeshPart meshPart)
	{
		int num;
		IntPtr ufunctionPtrAndSizeChecked = UnrealReflectionUtils.GetUFunctionPtrAndSizeChecked(base.NativePtr, new FName("SetMaterialReplaceV2"), out num);
		byte* ptr = stackalloc byte[(UIntPtr)((num != 0) ? (num + 15) : 0)];
		CharRenderingComponent.__SetMaterialReplaceV2_FunctionParams* ptr2 = null;
		if (num != 0)
		{
			ptr2 = ((CharRenderingComponent.__SetMaterialReplaceV2_FunctionParams*)ptr + 15L / (long)sizeof(CharRenderingComponent.__SetMaterialReplaceV2_FunctionParams) & -16L);
			UnrealReflectionUtils.InitializeStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
			*(&ptr2->material) = ((material != null) ? material.NativePtr : ((IntPtr)0));
			*(&ptr2->bodyType) = (byte)bodyType;
			*(&ptr2->slotType) = (byte)slotType;
			*(&ptr2->meshPart) = (byte)meshPart;
		}
		UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ufunctionPtrAndSizeChecked, (void*)ptr2);
		if (num != 0)
		{
			UnrealReflectionUtils.DestroyStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
		}
	}

	// Token: 0x0601BBB0 RID: 113584 RVA: 0x00845C00 File Offset: 0x00843E00
	[NullableContext(1)]
	protected void SetMaterialReplaceV2_Implementation(UMaterialInterface material, EKuroCharBodySpecifiedType bodyType, EKuroCharSlotSpecifiedType slotType, EKuroCharMeshPart meshPart)
	{
		CharMaterialContainerV2 charMaterialContainerV = this.GetComponent(13) as CharMaterialContainerV2;
		if (charMaterialContainerV == null)
		{
			return;
		}
		charMaterialContainerV.SetExternalMaterialReplace(material, bodyType, slotType, new EKuroCharMeshPart?(meshPart));
	}

	// Token: 0x0601BBB1 RID: 113585 RVA: 0x00845C30 File Offset: 0x00843E30
	[NullableContext(1)]
	public void SetMaterialReplaceV2ByIndex(UMaterialInterface material, FName bodyName, int materialIndex)
	{
		CharMaterialContainerV2 charMaterialContainerV = this.GetComponent(13) as CharMaterialContainerV2;
		if (charMaterialContainerV == null)
		{
			return;
		}
		charMaterialContainerV.SetExternalMaterialReplaceByIndex(material, bodyName, materialIndex);
	}

	// Token: 0x0601BBB2 RID: 113586 RVA: 0x00845C58 File Offset: 0x00843E58
	[UFunction(EFunctionFlags.FUNC_BlueprintNativeEvent)]
	public unsafe virtual void RemoveExternalMaterialReplaceV2(EKuroCharBodySpecifiedType bodyType, EKuroCharSlotSpecifiedType slotType, EKuroCharMeshPart meshPart)
	{
		int num;
		IntPtr ufunctionPtrAndSizeChecked = UnrealReflectionUtils.GetUFunctionPtrAndSizeChecked(base.NativePtr, new FName("RemoveExternalMaterialReplaceV2"), out num);
		byte* ptr = stackalloc byte[(UIntPtr)((num != 0) ? (num + 15) : 0)];
		CharRenderingComponent.__RemoveExternalMaterialReplaceV2_FunctionParams* ptr2 = null;
		if (num != 0)
		{
			ptr2 = ((CharRenderingComponent.__RemoveExternalMaterialReplaceV2_FunctionParams*)ptr + 15L / (long)sizeof(CharRenderingComponent.__RemoveExternalMaterialReplaceV2_FunctionParams) & -16L);
			UnrealReflectionUtils.InitializeStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
			*(&ptr2->bodyType) = (byte)bodyType;
			*(&ptr2->slotType) = (byte)slotType;
			*(&ptr2->meshPart) = (byte)meshPart;
		}
		UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ufunctionPtrAndSizeChecked, (void*)ptr2);
		if (num != 0)
		{
			UnrealReflectionUtils.DestroyStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
		}
	}

	// Token: 0x0601BBB3 RID: 113587 RVA: 0x00845CE4 File Offset: 0x00843EE4
	protected void RemoveExternalMaterialReplaceV2_Implementation(EKuroCharBodySpecifiedType bodyType, EKuroCharSlotSpecifiedType slotType, EKuroCharMeshPart meshPart)
	{
		CharMaterialContainerV2 charMaterialContainerV = this.GetComponent(13) as CharMaterialContainerV2;
		if (charMaterialContainerV == null)
		{
			return;
		}
		charMaterialContainerV.RemoveExternalMaterialReplace(bodyType, slotType, new EKuroCharMeshPart?(meshPart));
	}

	// Token: 0x0601BBB4 RID: 113588 RVA: 0x00845D14 File Offset: 0x00843F14
	public void RemoveExternalMaterialReplaceV2ByIndex(FName bodyName, int materialIndex)
	{
		CharMaterialContainerV2 charMaterialContainerV = this.GetComponent(13) as CharMaterialContainerV2;
		if (charMaterialContainerV == null)
		{
			return;
		}
		charMaterialContainerV.RemoveExternalMaterialReplaceByIndex(bodyName, materialIndex);
	}

	// Token: 0x0601BBB5 RID: 113589 RVA: 0x00845D3C File Offset: 0x00843F3C
	[UFunction(EFunctionFlags.FUNC_BlueprintNativeEvent)]
	public unsafe virtual void SetStarScarEnergy(float value)
	{
		int num;
		IntPtr ufunctionPtrAndSizeChecked = UnrealReflectionUtils.GetUFunctionPtrAndSizeChecked(base.NativePtr, new FName("SetStarScarEnergy"), out num);
		byte* ptr = stackalloc byte[(UIntPtr)((num != 0) ? (num + 15) : 0)];
		CharRenderingComponent.__SetStarScarEnergy_FunctionParams* ptr2 = null;
		if (num != 0)
		{
			ptr2 = ((CharRenderingComponent.__SetStarScarEnergy_FunctionParams*)ptr + 15L / (long)sizeof(CharRenderingComponent.__SetStarScarEnergy_FunctionParams) & -16L);
			UnrealReflectionUtils.InitializeStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
			ptr2->value = value;
		}
		UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ufunctionPtrAndSizeChecked, (void*)ptr2);
		if (num != 0)
		{
			UnrealReflectionUtils.DestroyStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
		}
	}

	// Token: 0x0601BBB6 RID: 113590 RVA: 0x00845DB4 File Offset: 0x00843FB4
	protected void SetStarScarEnergy_Implementation(float value)
	{
		if (this.UseMaterialContainerV2)
		{
			CharMaterialContainerV2 charMaterialContainerV = this.GetComponent(13) as CharMaterialContainerV2;
			if (charMaterialContainerV == null)
			{
				return;
			}
			charMaterialContainerV.SetFloatUpdateParamPermanent(RenderConfig.StarScarEnergyControl, value, EKuroCharBodySpecifiedType.Body, EKuroCharSlotSpecifiedType.Body, new EKuroCharMeshPart?(EKuroCharMeshPart.Star));
			return;
		}
		else
		{
			CharMaterialContainer charMaterialContainer = this.GetComponent(1) as CharMaterialContainer;
			if (charMaterialContainer == null)
			{
				return;
			}
			charMaterialContainer.SetStarScarEnergy(value);
			return;
		}
	}

	// Token: 0x0601BBB7 RID: 113591 RVA: 0x00845E0C File Offset: 0x0084400C
	public void SetNoWater(bool value)
	{
		if (this.UseMaterialContainerV2)
		{
			CharMaterialContainerV2 charMaterialContainerV = this.GetComponent(13) as CharMaterialContainerV2;
			if (charMaterialContainerV == null)
			{
				return;
			}
			charMaterialContainerV.SetNoWater(value);
			return;
		}
		else
		{
			CharMaterialContainer charMaterialContainer = this.GetComponent(1) as CharMaterialContainer;
			if (charMaterialContainer == null)
			{
				return;
			}
			charMaterialContainer.SetNoWater(value);
			return;
		}
	}

	// Token: 0x0601BBB8 RID: 113592 RVA: 0x00845E54 File Offset: 0x00844054
	[UFunction(EFunctionFlags.FUNC_BlueprintNativeEvent)]
	public unsafe virtual void SetCapsuleDither(float value)
	{
		int num;
		IntPtr ufunctionPtrAndSizeChecked = UnrealReflectionUtils.GetUFunctionPtrAndSizeChecked(base.NativePtr, new FName("SetCapsuleDither"), out num);
		byte* ptr = stackalloc byte[(UIntPtr)((num != 0) ? (num + 15) : 0)];
		CharRenderingComponent.__SetCapsuleDither_FunctionParams* ptr2 = null;
		if (num != 0)
		{
			ptr2 = ((CharRenderingComponent.__SetCapsuleDither_FunctionParams*)ptr + 15L / (long)sizeof(CharRenderingComponent.__SetCapsuleDither_FunctionParams) & -16L);
			UnrealReflectionUtils.InitializeStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
			ptr2->value = value;
		}
		UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ufunctionPtrAndSizeChecked, (void*)ptr2);
		if (num != 0)
		{
			UnrealReflectionUtils.DestroyStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
		}
	}

	// Token: 0x0601BBB9 RID: 113593 RVA: 0x00845ECA File Offset: 0x008440CA
	protected void SetCapsuleDither_Implementation(float value)
	{
	}

	// Token: 0x0601BBBA RID: 113594 RVA: 0x00845ECC File Offset: 0x008440CC
	[UFunction(EFunctionFlags.FUNC_BlueprintNativeEvent)]
	public unsafe virtual void SetDecalShadowEnabled(bool enable)
	{
		int num;
		IntPtr ufunctionPtrAndSizeChecked = UnrealReflectionUtils.GetUFunctionPtrAndSizeChecked(base.NativePtr, new FName("SetDecalShadowEnabled"), out num);
		byte* ptr = stackalloc byte[(UIntPtr)((num != 0) ? (num + 15) : 0)];
		CharRenderingComponent.__SetDecalShadowEnabled_FunctionParams* ptr2 = null;
		if (num != 0)
		{
			ptr2 = ((CharRenderingComponent.__SetDecalShadowEnabled_FunctionParams*)ptr + 15L / (long)sizeof(CharRenderingComponent.__SetDecalShadowEnabled_FunctionParams) & -16L);
			UnrealReflectionUtils.InitializeStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
			ptr2->enable = enable;
		}
		UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ufunctionPtrAndSizeChecked, (void*)ptr2);
		if (num != 0)
		{
			UnrealReflectionUtils.DestroyStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
		}
	}

	// Token: 0x0601BBBB RID: 113595 RVA: 0x00845F44 File Offset: 0x00844144
	protected void SetDecalShadowEnabled_Implementation(bool enable)
	{
		CharDecalShadow charDecalShadow = this.GetComponent(10) as CharDecalShadow;
		if (charDecalShadow == null)
		{
			return;
		}
		if (enable)
		{
			charDecalShadow.EnableDecalShadow();
			return;
		}
		charDecalShadow.DisableDecalShadow();
	}

	// Token: 0x0601BBBC RID: 113596 RVA: 0x00845F74 File Offset: 0x00844174
	public void SetRealTimeShadowEnabled(bool enable)
	{
		CharDecalShadow charDecalShadow = this.GetComponent(10) as CharDecalShadow;
		if (charDecalShadow == null)
		{
			return;
		}
		if (enable)
		{
			charDecalShadow.EnableRealTimeShadow();
			return;
		}
		charDecalShadow.DisableRealTimeShadow();
	}

	// Token: 0x0601BBBD RID: 113597 RVA: 0x00845FA4 File Offset: 0x008441A4
	[UFunction(EFunctionFlags.FUNC_BlueprintNativeEvent)]
	public unsafe virtual void DisableAllShadowByDecalShadowComponent()
	{
		int num;
		IntPtr ufunctionPtrAndSizeChecked = UnrealReflectionUtils.GetUFunctionPtrAndSizeChecked(base.NativePtr, new FName("DisableAllShadowByDecalShadowComponent"), out num);
		byte* ptr = stackalloc byte[(UIntPtr)((num != 0) ? (num + 15) : 0)];
		byte* dest = null;
		if (num != 0)
		{
			dest = (ptr + 15L & -16L);
			UnrealReflectionUtils.InitializeStruct(ufunctionPtrAndSizeChecked, (void*)dest, 1);
		}
		UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ufunctionPtrAndSizeChecked, null);
		if (num != 0)
		{
			UnrealReflectionUtils.DestroyStruct(ufunctionPtrAndSizeChecked, (void*)dest, 1);
		}
	}

	// Token: 0x0601BBBE RID: 113598 RVA: 0x00846014 File Offset: 0x00844214
	protected void DisableAllShadowByDecalShadowComponent_Implementation()
	{
		CharDecalShadow charDecalShadow = this.GetComponent(10) as CharDecalShadow;
		if (charDecalShadow == null)
		{
			return;
		}
		charDecalShadow.DisableAllShadow();
	}

	// Token: 0x0601BBBF RID: 113599 RVA: 0x0084603C File Offset: 0x0084423C
	[NullableContext(1)]
	protected void AddComponentForDecalShadow(string name, UPrimitiveComponent comp)
	{
		CharDecalShadow charDecalShadow = this.GetComponent(10) as CharDecalShadow;
		if (charDecalShadow == null)
		{
			return;
		}
		charDecalShadow.AddPrimitiveComponent(name, comp);
	}

	// Token: 0x0601BBC0 RID: 113600 RVA: 0x00846064 File Offset: 0x00844264
	[NullableContext(1)]
	protected void RemoveComponentFromDecalShadow(string name)
	{
		CharDecalShadow charDecalShadow = this.GetComponent(10) as CharDecalShadow;
		if (charDecalShadow == null)
		{
			return;
		}
		charDecalShadow.RemovePrimitiveComponent(name);
	}

	// Token: 0x0601BBC1 RID: 113601 RVA: 0x0084608C File Offset: 0x0084428C
	protected void SetDecalShadowOpacity(float opacity)
	{
		CharDecalShadow charDecalShadow = this.GetComponent(10) as CharDecalShadow;
		if (charDecalShadow == null)
		{
			return;
		}
		charDecalShadow.SetDecalShadowOpacity(opacity);
	}

	// Token: 0x0601BBC2 RID: 113602 RVA: 0x008460B4 File Offset: 0x008442B4
	protected void SetRealTimeShadowOpacity(float opacity)
	{
		CharDecalShadow charDecalShadow = this.GetComponent(10) as CharDecalShadow;
		if (charDecalShadow == null)
		{
			return;
		}
		charDecalShadow.SetRealTimeShadowOpacity(opacity);
	}

	// Token: 0x0601BBC3 RID: 113603 RVA: 0x008460DC File Offset: 0x008442DC
	[UFunction(EFunctionFlags.FUNC_BlueprintNativeEvent)]
	public unsafe virtual void SetShouldCastShadow(bool castShadow)
	{
		int num;
		IntPtr ufunctionPtrAndSizeChecked = UnrealReflectionUtils.GetUFunctionPtrAndSizeChecked(base.NativePtr, new FName("SetShouldCastShadow"), out num);
		byte* ptr = stackalloc byte[(UIntPtr)((num != 0) ? (num + 15) : 0)];
		CharRenderingComponent.__SetShouldCastShadow_FunctionParams* ptr2 = null;
		if (num != 0)
		{
			ptr2 = ((CharRenderingComponent.__SetShouldCastShadow_FunctionParams*)ptr + 15L / (long)sizeof(CharRenderingComponent.__SetShouldCastShadow_FunctionParams) & -16L);
			UnrealReflectionUtils.InitializeStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
			ptr2->castShadow = castShadow;
		}
		UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ufunctionPtrAndSizeChecked, (void*)ptr2);
		if (num != 0)
		{
			UnrealReflectionUtils.DestroyStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
		}
	}

	// Token: 0x0601BBC4 RID: 113604 RVA: 0x00846154 File Offset: 0x00844354
	protected void SetShouldCastShadow_Implementation(bool castShadow)
	{
		CharDecalShadow charDecalShadow = this.GetComponent(10) as CharDecalShadow;
		if (charDecalShadow == null)
		{
			return;
		}
		charDecalShadow.SetShouldCastShadow(castShadow);
	}

	// Token: 0x0601BBC5 RID: 113605 RVA: 0x0084617C File Offset: 0x0084437C
	public void Update(float delta)
	{
		if (!this.CanUpdate)
		{
			return;
		}
		if (!this.IsValid())
		{
			return;
		}
		if (CharRenderingComponent.DisableForDebug)
		{
			this.ResetAllRenderingStateForDebug();
		}
		this.DeltaTime = delta;
		if (this.IsInit)
		{
			foreach (CharMaterialControlRuntimeDataGroup charMaterialControlRuntimeDataGroup in this.AllMaterialControlRuntimeDataGroupMap.Values)
			{
				if (!charMaterialControlRuntimeDataGroup.IsDead)
				{
					LogicalTimeDilationOut outVal = new LogicalTimeDilationOut
					{
						LogicalTimeDilation = 1f
					};
					charMaterialControlRuntimeDataGroup.BeforeUpdateState(delta, this.GetTimeDilation(outVal));
				}
			}
			foreach (CharRenderBase charRenderBase in this.AllRenderComps)
			{
				if (charRenderBase.GetIsInitSuc())
				{
					charRenderBase.Update();
				}
			}
			foreach (CharRenderBase charRenderBase2 in this.AllRenderComps)
			{
				if (charRenderBase2.GetIsInitSuc())
				{
					charRenderBase2.LateUpdate();
				}
			}
			this.DataGroupAfterUpdate(delta);
		}
		base.UpdateHitMesh(delta);
	}

	// Token: 0x0601BBC6 RID: 113606 RVA: 0x008462CC File Offset: 0x008444CC
	public unsafe void DataGroupAfterUpdate(float delta)
	{
		foreach (int num in this.AllMaterialControlRuntimeDataGroupMap.Keys)
		{
			CharMaterialControlRuntimeDataGroup charMaterialControlRuntimeDataGroup = this.AllMaterialControlRuntimeDataGroupMap[num];
			charMaterialControlRuntimeDataGroup.AfterUpdateState(delta);
			if (charMaterialControlRuntimeDataGroup.IsDead)
			{
				this.TempRemoveList.Add(num);
			}
		}
		if (this.TempRemoveList != null && this.TempRemoveList.Count > 0)
		{
			for (int i = 0; i < this.TempRemoveList.Count; i++)
			{
				int num2 = this.TempRemoveList[i];
				this.AllMaterialControlRuntimeDataGroupMap.Remove(num2);
				GlobalData.BpEventManager.材质播放结束时.Broadcast(num2);
				Singleton<EventSystem>.Instance.EmitWithTarget<int>(this, EEventName.OnRemoveMaterialControllerGroup, num2);
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.RenderCharacter;
				ELogAuthor author = ELogAuthor.ZJF;
				string message = "移除材质控制器组:";
				<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("Actor", base.GetOwner());
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("ID", num2);
				instance.Info(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
			}
			this.TempRemoveList.Clear();
		}
	}

	// Token: 0x0601BBC7 RID: 113607 RVA: 0x00846424 File Offset: 0x00844624
	[UFunction(EFunctionFlags.FUNC_BlueprintNativeEvent)]
	public unsafe virtual void SetEffectProgress(float progress, int handleId)
	{
		int num;
		IntPtr ufunctionPtrAndSizeChecked = UnrealReflectionUtils.GetUFunctionPtrAndSizeChecked(base.NativePtr, new FName("SetEffectProgress"), out num);
		byte* ptr = stackalloc byte[(UIntPtr)((num != 0) ? (num + 15) : 0)];
		CharRenderingComponent.__SetEffectProgress_FunctionParams* ptr2 = null;
		if (num != 0)
		{
			ptr2 = ((CharRenderingComponent.__SetEffectProgress_FunctionParams*)ptr + 15L / (long)sizeof(CharRenderingComponent.__SetEffectProgress_FunctionParams) & -16L);
			UnrealReflectionUtils.InitializeStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
			ptr2->progress = progress;
			ptr2->handleId = handleId;
		}
		UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ufunctionPtrAndSizeChecked, (void*)ptr2);
		if (num != 0)
		{
			UnrealReflectionUtils.DestroyStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
		}
	}

	// Token: 0x0601BBC8 RID: 113608 RVA: 0x008464A4 File Offset: 0x008446A4
	protected void SetEffectProgress_Implementation(float progress, int handleId)
	{
		if (this.UseMaterialContainerV2)
		{
			CharMaterialControllerV2 charMaterialControllerV = this.GetComponent(14) as CharMaterialControllerV2;
			if (charMaterialControllerV == null)
			{
				return;
			}
			charMaterialControllerV.SetEffectProgress(progress, handleId);
			return;
		}
		else
		{
			CharMaterialController charMaterialController = this.GetComponent(2) as CharMaterialController;
			if (charMaterialController == null)
			{
				return;
			}
			charMaterialController.SetEffectProgress(progress, handleId);
			return;
		}
	}

	// Token: 0x0601BBC9 RID: 113609 RVA: 0x008464F0 File Offset: 0x008446F0
	[UFunction(EFunctionFlags.FUNC_BlueprintNativeEvent)]
	public unsafe virtual void SetEffectGroupProgress(float progress, int groupHandleId)
	{
		int num;
		IntPtr ufunctionPtrAndSizeChecked = UnrealReflectionUtils.GetUFunctionPtrAndSizeChecked(base.NativePtr, new FName("SetEffectGroupProgress"), out num);
		byte* ptr = stackalloc byte[(UIntPtr)((num != 0) ? (num + 15) : 0)];
		CharRenderingComponent.__SetEffectGroupProgress_FunctionParams* ptr2 = null;
		if (num != 0)
		{
			ptr2 = ((CharRenderingComponent.__SetEffectGroupProgress_FunctionParams*)ptr + 15L / (long)sizeof(CharRenderingComponent.__SetEffectGroupProgress_FunctionParams) & -16L);
			UnrealReflectionUtils.InitializeStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
			ptr2->progress = progress;
			ptr2->groupHandleId = groupHandleId;
		}
		UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ufunctionPtrAndSizeChecked, (void*)ptr2);
		if (num != 0)
		{
			UnrealReflectionUtils.DestroyStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
		}
	}

	// Token: 0x0601BBCA RID: 113610 RVA: 0x00846570 File Offset: 0x00844770
	protected void SetEffectGroupProgress_Implementation(float progress, int groupHandleId)
	{
		CharMaterialControlRuntimeDataGroup charMaterialControlRuntimeDataGroup;
		if (this.AllMaterialControlRuntimeDataGroupMap.TryGetValue(groupHandleId, out charMaterialControlRuntimeDataGroup))
		{
			charMaterialControlRuntimeDataGroup.SetEffectProgress(progress);
		}
	}

	// Token: 0x0601BBCB RID: 113611 RVA: 0x00846594 File Offset: 0x00844794
	[UFunction(EFunctionFlags.FUNC_BlueprintNativeEvent)]
	public unsafe virtual void RefreshMaterialController()
	{
		int num;
		IntPtr ufunctionPtrAndSizeChecked = UnrealReflectionUtils.GetUFunctionPtrAndSizeChecked(base.NativePtr, new FName("RefreshMaterialController"), out num);
		byte* ptr = stackalloc byte[(UIntPtr)((num != 0) ? (num + 15) : 0)];
		byte* dest = null;
		if (num != 0)
		{
			dest = (ptr + 15L & -16L);
			UnrealReflectionUtils.InitializeStruct(ufunctionPtrAndSizeChecked, (void*)dest, 1);
		}
		UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ufunctionPtrAndSizeChecked, null);
		if (num != 0)
		{
			UnrealReflectionUtils.DestroyStruct(ufunctionPtrAndSizeChecked, (void*)dest, 1);
		}
	}

	// Token: 0x0601BBCC RID: 113612 RVA: 0x00846604 File Offset: 0x00844804
	protected void RefreshMaterialController_Implementation()
	{
		if (this.UseMaterialContainerV2)
		{
			CharMaterialContainerV2 charMaterialContainerV = this.GetComponent(13) as CharMaterialContainerV2;
			if (charMaterialContainerV == null)
			{
				return;
			}
			charMaterialContainerV.ForceUpdateOnce();
		}
	}

	// Token: 0x0601BBCD RID: 113613 RVA: 0x00846634 File Offset: 0x00844834
	public bool IsMaterialControllerDataValid(int handleId)
	{
		if (this.UseMaterialContainerV2)
		{
			CharMaterialControllerV2 charMaterialControllerV = this.GetComponent(14) as CharMaterialControllerV2;
			return charMaterialControllerV != null && charMaterialControllerV.GetRuntimeMaterialControllerValid(handleId);
		}
		CharMaterialController charMaterialController = this.GetComponent(2) as CharMaterialController;
		return charMaterialController != null && charMaterialController.GetRuntimeMaterialControllerValid(handleId);
	}

	// Token: 0x0601BBCE RID: 113614 RVA: 0x00846680 File Offset: 0x00844880
	[UFunction(EFunctionFlags.FUNC_BlueprintNativeEvent)]
	public unsafe virtual void Destroy()
	{
		int num;
		IntPtr ufunctionPtrAndSizeChecked = UnrealReflectionUtils.GetUFunctionPtrAndSizeChecked(base.NativePtr, new FName("Destroy"), out num);
		byte* ptr = stackalloc byte[(UIntPtr)((num != 0) ? (num + 15) : 0)];
		byte* dest = null;
		if (num != 0)
		{
			dest = (ptr + 15L & -16L);
			UnrealReflectionUtils.InitializeStruct(ufunctionPtrAndSizeChecked, (void*)dest, 1);
		}
		UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ufunctionPtrAndSizeChecked, null);
		if (num != 0)
		{
			UnrealReflectionUtils.DestroyStruct(ufunctionPtrAndSizeChecked, (void*)dest, 1);
		}
	}

	// Token: 0x0601BBCF RID: 113615 RVA: 0x008466F0 File Offset: 0x008448F0
	protected void Destroy_Implementation()
	{
		if (!this.IsInit)
		{
			return;
		}
		this.ResetAllRenderingState();
		foreach (CharRenderBase charRenderBase in this.AllRenderComps)
		{
			charRenderBase.Destroy();
		}
		this.AllRenderComps = new List<CharRenderBase>();
		this.AllRenderCompsMap.Clear();
		this.IsInit = false;
		this.IsStartInvoke = false;
		this.RenderType = new ECharacterRenderingType?(ECharacterRenderingType.Error);
		if (this.CachedOwnerEntity != null && this.RemoveInteractionOnRoleGoDownFinish != null)
		{
			Singleton<EventSystem>.Instance.RemoveWithTarget(this.CachedOwnerEntity, EEventName.OnRoleGoDownFinish, this.RemoveInteractionOnRoleGoDownFinish);
			this.OnRoleGoDownFinishEventAdded = false;
		}
		if (!ControllerBase<RenderModuleController>.Instance.RemoveCharRenderShell(this))
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.RenderCharacter;
			ELogAuthor author = ELogAuthor.MY;
			string message = "材质控制器销毁失败";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("Actor", base.GetOwner());
			instance.Warn(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
		}
	}

	// Token: 0x0601BBD0 RID: 113616 RVA: 0x008467EC File Offset: 0x008449EC
	[UFunction(EFunctionFlags.FUNC_BlueprintNativeEvent)]
	public unsafe virtual void OnFinalizedLevelSequence()
	{
		int num;
		IntPtr ufunctionPtrAndSizeChecked = UnrealReflectionUtils.GetUFunctionPtrAndSizeChecked(base.NativePtr, new FName("OnFinalizedLevelSequence"), out num);
		byte* ptr = stackalloc byte[(UIntPtr)((num != 0) ? (num + 15) : 0)];
		byte* dest = null;
		if (num != 0)
		{
			dest = (ptr + 15L & -16L);
			UnrealReflectionUtils.InitializeStruct(ufunctionPtrAndSizeChecked, (void*)dest, 1);
		}
		UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ufunctionPtrAndSizeChecked, null);
		if (num != 0)
		{
			UnrealReflectionUtils.DestroyStruct(ufunctionPtrAndSizeChecked, (void*)dest, 1);
		}
	}

	// Token: 0x0601BBD1 RID: 113617 RVA: 0x0084685C File Offset: 0x00844A5C
	protected void OnFinalizedLevelSequence_Implementation()
	{
		foreach (int handle in this.SequenceHandleIds)
		{
			this.RemoveMaterialControllerData(handle);
			this.RemoveMaterialControllerDataGroup(handle);
		}
		this.SequenceHandleIds = new List<int>();
		USkeletalMeshComponent mesh = ((ACharacter)base.GetOwner()).Mesh;
		mesh.SetCustomPrimitiveDataFloat(0, 0f);
		mesh.SetCustomPrimitiveDataFloat(1, 0f);
		mesh.ExposeToCinematicsCustomLightFactor = 0f;
		mesh.ExposeToCinematicsCustomLightYaw = 0f;
	}

	// Token: 0x0601BBD2 RID: 113618 RVA: 0x00846900 File Offset: 0x00844B00
	[NullableContext(1)]
	private CharRenderBase[] GetRenderComps()
	{
		this.UseMaterialContainerV2 = RenderConfig.UseMaterialContainerV2;
		return RenderUtil.GetRenderComps(this.RenderType.Value, this.UseMaterialContainerV2, this.MonsterUseBodyEffect);
	}

	// Token: 0x0601BBD3 RID: 113619 RVA: 0x0084692C File Offset: 0x00844B2C
	private unsafe void InvokeStart()
	{
		if (!this.IsStartInvoke)
		{
			this.IsStartInvoke = true;
			foreach (CharRenderBase charRenderBase in this.AllRenderComps)
			{
				try
				{
					charRenderBase.Start();
				}
				catch
				{
					Log instance = Singleton<Log>.Instance;
					ELogModule module = ELogModule.RenderCharacter;
					ELogAuthor author = ELogAuthor.LSY;
					string message = "错误:组件初始化错误:";
					<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
					*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("Actor", base.GetOwner());
					*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("组件ID", charRenderBase.GetComponentId());
					instance.Error(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
				}
			}
			foreach (CharRenderBase charRenderBase2 in this.AllRenderComps)
			{
				if (!charRenderBase2.GetIsInitSuc())
				{
					Log instance2 = Singleton<Log>.Instance;
					ELogModule module2 = ELogModule.RenderCharacter;
					ELogAuthor author2 = ELogAuthor.MY;
					string message2 = "错误:组件初始化错误:";
					<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray2 = default(<>y__InlineArray2<ValueTuple<string, object>>);
					*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 0) = new ValueTuple<string, object>("Actor", base.GetOwner());
					*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 1) = new ValueTuple<string, object>("组件ID", charRenderBase2.GetComponentId());
					instance2.Error(module2, author2, message2, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray2, 2));
				}
			}
			if (!this.IsRecord && Singleton<Info>.Instance.IsGameRunning())
			{
				ControllerBase<RenderModuleController>.Instance.AddCharRenderShell(this);
			}
			if (this.UseProxy)
			{
				TsBaseCharacter tsBaseCharacter = this.CachedOwner as TsBaseCharacter;
				if (tsBaseCharacter != null && tsBaseCharacter.Mesh != null)
				{
					this.AddProxy(tsBaseCharacter.Mesh);
				}
			}
			UKuroMaterialControllerComponent sureMaterialController = base.GetSureMaterialController();
			if (sureMaterialController != null)
			{
				FKuroMaterialControllerPreBodyInfoRuntimeReInit fkuroMaterialControllerPreBodyInfoRuntimeReInit = global::DelegateUtils.ToManualReleaseDelegate<FKuroMaterialControllerPreBodyInfoRuntimeReInit>(new Action<FName>(this.PreBodyInfoRuntimeInitEvent));
				sureMaterialController.RegisterPreBodyInfoRuntimeInitEvent(fkuroMaterialControllerPreBodyInfoRuntimeReInit);
			}
			if (sureMaterialController == null)
			{
				return;
			}
			FKuroMaterialControllerPostBodyInfoRuntimeReInit fkuroMaterialControllerPostBodyInfoRuntimeReInit = global::DelegateUtils.ToManualReleaseDelegate<FKuroMaterialControllerPostBodyInfoRuntimeReInit>(new Action<FName>(this.PostBodyInfoRuntimeInitEvent));
			sureMaterialController.RegisterPostBodyInfoRuntimeInitEvent(fkuroMaterialControllerPostBodyInfoRuntimeReInit);
		}
	}

	// Token: 0x0601BBD4 RID: 113620 RVA: 0x00846B40 File Offset: 0x00844D40
	[NullableContext(1)]
	private void AddProxy(USkeletalMeshComponent comp)
	{
		if (this.CachedOwner == null)
		{
			return;
		}
		AActor cachedOwner = this.CachedOwner;
		TSubclassOf<UActorComponent> @class = USkeletalMeshComponent.StaticClass();
		bool bManualAttachment = false;
		FTransform ftransform = new FTransform();
		this.Proxy = (USkeletalMeshComponent)cachedOwner.AddComponentByClass(@class, bManualAttachment, ftransform, false, new FName("Proxy"));
		this.Proxy.SetSkeletalMesh(comp.SkeletalMesh, true);
		this.Proxy.SetMasterPoseComponent(comp, false);
		this.Proxy.bUseBoundsFromMasterPoseComponent = true;
		this.Proxy.SetRenderInMainPass(this.ProxyRenderInMainPass);
		this.Proxy.SetCastShadow(this.ProxyRenderShadow);
		this.Proxy.SetRenderKuroTrail(this.ProxyRenderTrail);
		this.Proxy.K2_AttachToComponent(comp, null, EAttachmentRule.SnapToTarget, EAttachmentRule.SnapToTarget, EAttachmentRule.KeepRelative, true, true);
		if (this.ProxyMaterialsOverride != null && this.ProxyMaterialsOverride.Num() > 0)
		{
			int i = 0;
			int num = this.ProxyMaterialsOverride.Num();
			while (i < num)
			{
				this.Proxy.SetMaterial(i, this.ProxyMaterialsOverride.Get(i));
				i++;
			}
		}
	}

	// Token: 0x0601BBD5 RID: 113621 RVA: 0x00846C48 File Offset: 0x00844E48
	[UFunction(EFunctionFlags.FUNC_BlueprintNativeEvent)]
	public unsafe virtual bool ShouldTickAfterGoDown()
	{
		int num;
		IntPtr ufunctionPtrAndSizeChecked = UnrealReflectionUtils.GetUFunctionPtrAndSizeChecked(base.NativePtr, new FName("ShouldTickAfterGoDown"), out num);
		byte* ptr = stackalloc byte[(UIntPtr)((num != 0) ? (num + 15) : 0)];
		CharRenderingComponent.__ShouldTickAfterGoDown_FunctionParams* ptr2 = null;
		if (num != 0)
		{
			ptr2 = ((CharRenderingComponent.__ShouldTickAfterGoDown_FunctionParams*)ptr + 15L / (long)sizeof(CharRenderingComponent.__ShouldTickAfterGoDown_FunctionParams) & -16L);
			UnrealReflectionUtils.InitializeStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
		}
		UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ufunctionPtrAndSizeChecked, (void*)ptr2);
		bool _Result = ptr2->__Result;
		if (num != 0)
		{
			UnrealReflectionUtils.DestroyStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
		}
		return _Result;
	}

	// Token: 0x0601BBD6 RID: 113622 RVA: 0x00846CC0 File Offset: 0x00844EC0
	protected bool ShouldTickAfterGoDown_Implementation()
	{
		if (this.UseMaterialContainerV2)
		{
			CharMaterialContainerV2 charMaterialContainerV = this.GetComponent(13) as CharMaterialContainerV2;
			if (charMaterialContainerV != null)
			{
				return charMaterialContainerV.GetAnyUnloopEffect();
			}
		}
		return false;
	}

	// Token: 0x1700256E RID: 9582
	// (get) Token: 0x0601BBD7 RID: 113623 RVA: 0x00846CF0 File Offset: 0x00844EF0
	private bool IsInDebugMode
	{
		get
		{
			if (!Singleton<Info>.Instance.IsGameRunning())
			{
				this.IsInDebugModeInternal = new bool?(ModelBase<WorldModel>.Instance.IsStandalone || this.IsRecord || GlobalData.IsPlayInEditor);
			}
			else if (this.IsInDebugModeInternal == null)
			{
				this.IsInDebugModeInternal = new bool?(ModelBase<GameModeModel>.Instance.IsSilentLogin || ModelBase<WorldModel>.Instance.IsStandalone || this.IsRecord || GlobalData.IsPlayInEditor);
			}
			return this.IsInDebugModeInternal.Value;
		}
	}

	// Token: 0x1700256F RID: 9583
	// (get) Token: 0x0601BBD8 RID: 113624 RVA: 0x00846D7D File Offset: 0x00844F7D
	private bool IsRecord
	{
		get
		{
			if (this.IsRecordInternal == null)
			{
				this.IsRecordInternal = new bool?(base.GetOwner() is AKuroRecordCharacter);
			}
			return this.IsRecordInternal.Value;
		}
	}

	// Token: 0x0601BBD9 RID: 113625 RVA: 0x00846DB0 File Offset: 0x00844FB0
	[UFunction(EFunctionFlags.FUNC_BlueprintNativeEvent)]
	public unsafe override void ReceiveBeginPlay()
	{
		int num;
		IntPtr ufunctionPtrAndSizeChecked = UnrealReflectionUtils.GetUFunctionPtrAndSizeChecked(base.NativePtr, new FName("ReceiveBeginPlay"), out num);
		byte* ptr = stackalloc byte[(UIntPtr)((num != 0) ? (num + 15) : 0)];
		byte* dest = null;
		if (num != 0)
		{
			dest = (ptr + 15L & -16L);
			UnrealReflectionUtils.InitializeStruct(ufunctionPtrAndSizeChecked, (void*)dest, 1);
		}
		UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ufunctionPtrAndSizeChecked, null);
		if (num != 0)
		{
			UnrealReflectionUtils.DestroyStruct(ufunctionPtrAndSizeChecked, (void*)dest, 1);
		}
	}

	// Token: 0x0601BBDA RID: 113626 RVA: 0x00846E20 File Offset: 0x00845020
	protected virtual void ReceiveBeginPlay_Implementation()
	{
		base.SetComponentTickEnabled(this.IsRecord);
	}

	// Token: 0x0601BBDB RID: 113627 RVA: 0x00846E30 File Offset: 0x00845030
	[UFunction(EFunctionFlags.FUNC_BlueprintNativeEvent)]
	public unsafe override void ReceiveTick(float deltaSeconds)
	{
		int num;
		IntPtr ufunctionPtrAndSizeChecked = UnrealReflectionUtils.GetUFunctionPtrAndSizeChecked(base.NativePtr, new FName("ReceiveTick"), out num);
		byte* ptr = stackalloc byte[(UIntPtr)((num != 0) ? (num + 15) : 0)];
		UActorComponent.__ReceiveTick_FunctionParams* ptr2 = null;
		if (num != 0)
		{
			ptr2 = ((UActorComponent.__ReceiveTick_FunctionParams*)ptr + 15L / (long)sizeof(UActorComponent.__ReceiveTick_FunctionParams) & -16L);
			UnrealReflectionUtils.InitializeStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
			ptr2->DeltaSeconds = deltaSeconds;
		}
		UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ufunctionPtrAndSizeChecked, (void*)ptr2);
		if (num != 0)
		{
			UnrealReflectionUtils.DestroyStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
		}
	}

	// Token: 0x0601BBDC RID: 113628 RVA: 0x00846EA6 File Offset: 0x008450A6
	protected virtual void ReceiveTick_Implementation(float deltaSeconds)
	{
		if (this.IsRecord)
		{
			this.Update(deltaSeconds);
		}
	}

	// Token: 0x0601BBDD RID: 113629 RVA: 0x00846EB8 File Offset: 0x008450B8
	[UFunction(EFunctionFlags.FUNC_BlueprintNativeEvent)]
	public unsafe virtual void ReceiveSeqTick(float deltaSeconds)
	{
		int num;
		IntPtr ufunctionPtrAndSizeChecked = UnrealReflectionUtils.GetUFunctionPtrAndSizeChecked(base.NativePtr, new FName("ReceiveSeqTick"), out num);
		byte* ptr = stackalloc byte[(UIntPtr)((num != 0) ? (num + 15) : 0)];
		CharRenderingComponent.__ReceiveSeqTick_FunctionParams* ptr2 = null;
		if (num != 0)
		{
			ptr2 = ((CharRenderingComponent.__ReceiveSeqTick_FunctionParams*)ptr + 15L / (long)sizeof(CharRenderingComponent.__ReceiveSeqTick_FunctionParams) & -16L);
			UnrealReflectionUtils.InitializeStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
			ptr2->deltaSeconds = deltaSeconds;
		}
		UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ufunctionPtrAndSizeChecked, (void*)ptr2);
		if (num != 0)
		{
			UnrealReflectionUtils.DestroyStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
		}
	}

	// Token: 0x0601BBDE RID: 113630 RVA: 0x00846F2E File Offset: 0x0084512E
	protected void ReceiveSeqTick_Implementation(float deltaSeconds)
	{
		if (Singleton<Info>.Instance.IsGameRunning())
		{
			return;
		}
		this.Update(deltaSeconds);
	}

	// Token: 0x0601BBDF RID: 113631 RVA: 0x00846F44 File Offset: 0x00845144
	[NullableContext(1)]
	public void AddHitMeshInfoByPath(string dataPath, FName? hitPart, Vector impactPoint, Rotator hitRotator)
	{
		FTransformDouble transform = UKismetMathLibrary.MakeTransformDouble(impactPoint.ToUeVector(false), hitRotator.ToUeRotator(), Vector.OneVector);
		Singleton<ResourceSystem>.Instance.LoadAsync<PDA_HitMeshData_C>(dataPath, delegate([Nullable(2)] PDA_HitMeshData_C asset, string _)
		{
			if (asset != null)
			{
				UKuroCharRenderingComponent <>4__this = this;
				USkeletalMesh hitSkeletalMesh = asset.HitSkeletalMesh;
				FName socket = hitPart ?? FName.NAME_None;
				float lastTime = asset.LastTime;
				FTransform hitSkeletalMeshTransform = asset.HitSkeletalMeshTransform;
				<>4__this.AddHitMeshOnSocket(hitSkeletalMesh, transform, socket, lastTime, hitSkeletalMeshTransform);
			}
		}, 100, "js_undefined");
	}

	// Token: 0x0601BBE0 RID: 113632 RVA: 0x00846FA2 File Offset: 0x008451A2
	static CharRenderingComponent()
	{
		StaticVariableRegister.RegisterAndExecute(new Action(CharRenderingComponent.CreateStaticDefaultValue), new Action(CharRenderingComponent.ResetStaticDefaultValue));
	}

	// Token: 0x0601BBE1 RID: 113633 RVA: 0x00846FC1 File Offset: 0x008451C1
	public static void CreateStaticDefaultValue()
	{
		CharRenderingComponent.GlobalDisableDitherEffect = false;
		CharRenderingComponent.MotionMeshShadingRate = new EMaterialShadingRate[]
		{
			EMaterialShadingRate.MSR_2x2,
			EMaterialShadingRate.MSR_4x4
		};
		CharRenderingComponent.MotionVelocitySquared = new int[]
		{
			40000,
			250000
		};
		CharRenderingComponent.DisableForDebug = false;
	}

	// Token: 0x0601BBE2 RID: 113634 RVA: 0x00846FFD File Offset: 0x008451FD
	public static void ResetStaticDefaultValue()
	{
		CharRenderingComponent.GlobalDisableDitherEffect = false;
		CharRenderingComponent.MotionMeshShadingRate = null;
		CharRenderingComponent.MotionVelocitySquared = null;
		CharRenderingComponent.DisableForDebug = false;
	}

	// Token: 0x0601BBE3 RID: 113635 RVA: 0x00847017 File Offset: 0x00845217
	public new static UClassStackOnlyPtr StaticClass()
	{
		if (CharRenderingComponent._ClassPtr == IntPtr.Zero)
		{
			UObjectGlobals.StaticLoadClass(null, "/Game/Aki/TypeScript/Game/Render/Character/Manager/CharRenderingComponent.CharRenderingComponent_C");
		}
		return CharRenderingComponent._ClassPtr;
	}

	// Token: 0x0601BBE4 RID: 113636 RVA: 0x0084703C File Offset: 0x0084523C
	public CharRenderingComponent() : this(BuiltinUtils.AllocNativeUObject(CharRenderingComponent.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
	{
	}

	// Token: 0x0601BBE5 RID: 113637 RVA: 0x00847064 File Offset: 0x00845264
	[NullableContext(1)]
	public CharRenderingComponent(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(CharRenderingComponent.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
	{
	}

	// Token: 0x0601BBE6 RID: 113638 RVA: 0x00847097 File Offset: 0x00845297
	protected CharRenderingComponent(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
	{
	}

	// Token: 0x0601BBE7 RID: 113639 RVA: 0x008470C4 File Offset: 0x008452C4
	protected unsafe virtual void __CPPCALL_QuickInitAndAddData_Implementation(CharRenderingComponent.__QuickInitAndAddData_FunctionParams* __Params)
	{
		UObject orCreateUObjectByNativePointer = BuiltinUtils.GetOrCreateUObjectByNativePointer<UObject>(__Params->data);
		ASkeletalMeshActor orCreateUObjectByNativePointer2 = BuiltinUtils.GetOrCreateUObjectByNativePointer<ASkeletalMeshActor>(__Params->meshActor);
		__Params->__Result = this.QuickInitAndAddData_Implementation(orCreateUObjectByNativePointer, orCreateUObjectByNativePointer2);
	}

	// Token: 0x0601BBE8 RID: 113640 RVA: 0x008470F8 File Offset: 0x008452F8
	protected unsafe virtual void __CPPCALL_QuickInitAndAddDataWithMeshComponent_Implementation(CharRenderingComponent.__QuickInitAndAddDataWithMeshComponent_FunctionParams* __Params)
	{
		UObject orCreateUObjectByNativePointer = BuiltinUtils.GetOrCreateUObjectByNativePointer<UObject>(__Params->data);
		UMeshComponent orCreateUObjectByNativePointer2 = BuiltinUtils.GetOrCreateUObjectByNativePointer<UMeshComponent>(__Params->meshComponent);
		__Params->__Result = this.QuickInitAndAddDataWithMeshComponent_Implementation(orCreateUObjectByNativePointer, orCreateUObjectByNativePointer2);
	}

	// Token: 0x0601BBE9 RID: 113641 RVA: 0x0084712C File Offset: 0x0084532C
	protected unsafe virtual void __CPPCALL_QuickInitAndAddDataGroup_Implementation(CharRenderingComponent.__QuickInitAndAddDataGroup_FunctionParams* __Params)
	{
		UObject orCreateUObjectByNativePointer = BuiltinUtils.GetOrCreateUObjectByNativePointer<UObject>(__Params->data);
		ASkeletalMeshActor orCreateUObjectByNativePointer2 = BuiltinUtils.GetOrCreateUObjectByNativePointer<ASkeletalMeshActor>(__Params->meshActor);
		__Params->__Result = this.QuickInitAndAddDataGroup_Implementation(orCreateUObjectByNativePointer, orCreateUObjectByNativePointer2);
	}

	// Token: 0x0601BBEA RID: 113642 RVA: 0x00847160 File Offset: 0x00845360
	protected unsafe virtual void __CPPCALL_QuickInitAndAddDataGroupWithMeshComponent_Implementation(CharRenderingComponent.__QuickInitAndAddDataGroupWithMeshComponent_FunctionParams* __Params)
	{
		UObject orCreateUObjectByNativePointer = BuiltinUtils.GetOrCreateUObjectByNativePointer<UObject>(__Params->data);
		UMeshComponent orCreateUObjectByNativePointer2 = BuiltinUtils.GetOrCreateUObjectByNativePointer<UMeshComponent>(__Params->meshComponent);
		__Params->__Result = this.QuickInitAndAddDataGroupWithMeshComponent_Implementation(orCreateUObjectByNativePointer, orCreateUObjectByNativePointer2);
	}

	// Token: 0x0601BBEB RID: 113643 RVA: 0x00847194 File Offset: 0x00845394
	protected unsafe virtual void __CPPCALL_Init_Implementation(CharRenderingComponent.__Init_FunctionParams* __Params)
	{
		ECharacterRenderingType renderType = (ECharacterRenderingType)__Params->renderType;
		this.Init_Implementation(renderType);
	}

	// Token: 0x0601BBEC RID: 113644 RVA: 0x008471B0 File Offset: 0x008453B0
	protected unsafe virtual void __CPPCALL_SetLogicOwner_Implementation(CharRenderingComponent.__SetLogicOwner_FunctionParams* __Params)
	{
		AActor orCreateUObjectByNativePointer = BuiltinUtils.GetOrCreateUObjectByNativePointer<AActor>(__Params->owner);
		this.SetLogicOwner_Implementation(orCreateUObjectByNativePointer);
	}

	// Token: 0x0601BBED RID: 113645 RVA: 0x008471D0 File Offset: 0x008453D0
	protected unsafe virtual void __CPPCALL_AddComponent_Implementation(CharRenderingComponent.__AddComponent_FunctionParams* __Params)
	{
		string skelName = FString.ToString((void*)(&__Params->skelName));
		UMeshComponent orCreateUObjectByNativePointer = BuiltinUtils.GetOrCreateUObjectByNativePointer<UMeshComponent>(__Params->skeletalComp);
		this.AddComponent_Implementation(skelName, orCreateUObjectByNativePointer);
	}

	// Token: 0x0601BBEE RID: 113646 RVA: 0x00847200 File Offset: 0x00845400
	protected unsafe virtual void __CPPCALL_AddComponentWithEmptyMaterial_Implementation(CharRenderingComponent.__AddComponentWithEmptyMaterial_FunctionParams* __Params)
	{
		string skelName = FString.ToString((void*)(&__Params->skelName));
		UMeshComponent orCreateUObjectByNativePointer = BuiltinUtils.GetOrCreateUObjectByNativePointer<UMeshComponent>(__Params->skeletalComp);
		this.AddComponentWithEmptyMaterial_Implementation(skelName, orCreateUObjectByNativePointer);
	}

	// Token: 0x0601BBEF RID: 113647 RVA: 0x00847230 File Offset: 0x00845430
	protected unsafe virtual void __CPPCALL_RemoveComponent_Implementation(CharRenderingComponent.__RemoveComponent_FunctionParams* __Params)
	{
		string skelName = FString.ToString((void*)(&__Params->skelName));
		this.RemoveComponent_Implementation(skelName);
	}

	// Token: 0x0601BBF0 RID: 113648 RVA: 0x00847254 File Offset: 0x00845454
	protected unsafe virtual void __CPPCALL_AddComponentByCase_Implementation(CharRenderingComponent.__AddComponentByCase_FunctionParams* __Params)
	{
		ECharacterControllerCaseType caseType = (ECharacterControllerCaseType)__Params->caseType;
		UMeshComponent orCreateUObjectByNativePointer = BuiltinUtils.GetOrCreateUObjectByNativePointer<UMeshComponent>(__Params->skeletalComp);
		this.AddComponentByCase_Implementation(caseType, orCreateUObjectByNativePointer);
	}

	// Token: 0x0601BBF1 RID: 113649 RVA: 0x0084727C File Offset: 0x0084547C
	protected unsafe virtual void __CPPCALL_RemoveComponentByCase_Implementation(CharRenderingComponent.__RemoveComponentByCase_FunctionParams* __Params)
	{
		ECharacterControllerCaseType caseType = (ECharacterControllerCaseType)__Params->caseType;
		this.RemoveComponentByCase_Implementation(caseType);
	}

	// Token: 0x0601BBF2 RID: 113650 RVA: 0x00847298 File Offset: 0x00845498
	protected unsafe virtual void __CPPCALL_AddComponentInnerV2_Implementation(CharRenderingComponent.__AddComponentInnerV2_FunctionParams* __Params)
	{
		string skelName = FString.ToString((void*)(&__Params->skelName));
		UMeshComponent orCreateUObjectByNativePointer = BuiltinUtils.GetOrCreateUObjectByNativePointer<UMeshComponent>(__Params->skeletalComp);
		this.AddComponentInnerV2_Implementation(skelName, orCreateUObjectByNativePointer, __Params->useEmptyMaterial);
	}

	// Token: 0x0601BBF3 RID: 113651 RVA: 0x008472CC File Offset: 0x008454CC
	protected unsafe virtual void __CPPCALL_RemoveComponentInnerV2_Implementation(CharRenderingComponent.__RemoveComponentInnerV2_FunctionParams* __Params)
	{
		string skelName = FString.ToString((void*)(&__Params->skelName));
		this.RemoveComponentInnerV2_Implementation(skelName);
	}

	// Token: 0x0601BBF4 RID: 113652 RVA: 0x008472F0 File Offset: 0x008454F0
	protected unsafe virtual void __CPPCALL_GetSkeletalMeshComponent_Implementation(CharRenderingComponent.__GetSkeletalMeshComponent_FunctionParams* __Params)
	{
		string skelName = FString.ToString((void*)(&__Params->skelName));
		ref IntPtr ptr = ref *(&__Params->__Result);
		USkeletalMeshComponent skeletalMeshComponent_Implementation = this.GetSkeletalMeshComponent_Implementation(skelName);
		ptr = ((skeletalMeshComponent_Implementation != null) ? skeletalMeshComponent_Implementation.NativePtr : ((IntPtr)0));
	}

	// Token: 0x0601BBF5 RID: 113653 RVA: 0x00847328 File Offset: 0x00845528
	protected unsafe virtual void __CPPCALL_GetSkeletalMeshComponentBodyName_Implementation(CharRenderingComponent.__GetSkeletalMeshComponentBodyName_FunctionParams* __Params)
	{
		USkeletalMeshComponent orCreateUObjectByNativePointer = BuiltinUtils.GetOrCreateUObjectByNativePointer<USkeletalMeshComponent>(__Params->skeletalComp);
		__Params->__Result = this.GetSkeletalMeshComponentBodyName_Implementation(orCreateUObjectByNativePointer);
	}

	// Token: 0x0601BBF6 RID: 113654 RVA: 0x0084734E File Offset: 0x0084554E
	protected unsafe virtual void __CPPCALL_CheckInit_Implementation(CharRenderingComponent.__CheckInit_FunctionParams* __Params)
	{
		__Params->__Result = this.CheckInit_Implementation();
	}

	// Token: 0x0601BBF7 RID: 113655 RVA: 0x0084735C File Offset: 0x0084555C
	protected unsafe virtual void __CPPCALL_SetDebug_Implementation(CharRenderingComponent.__SetDebug_FunctionParams* __Params)
	{
		this.SetDebug_Implementation(__Params->value);
	}

	// Token: 0x0601BBF8 RID: 113656 RVA: 0x0084736A File Offset: 0x0084556A
	protected unsafe virtual void __CPPCALL_GetDebugInfo_Implementation(CharRenderingComponent.__GetDebugInfo_FunctionParams* __Params)
	{
		ref IntPtr ptr = ref *(&__Params->__Result);
		PD_MaterialDebug_C debugInfo_Implementation = this.GetDebugInfo_Implementation();
		ptr = ((debugInfo_Implementation != null) ? debugInfo_Implementation.NativePtr : ((IntPtr)0));
	}

	// Token: 0x0601BBF9 RID: 113657 RVA: 0x00847388 File Offset: 0x00845588
	protected unsafe virtual void __CPPCALL_ReceiveEndPlay_Implementation(UActorComponent.__ReceiveEndPlay_FunctionParams* __Params)
	{
		EEndPlayReason endPlayReason = __Params->EndPlayReason;
		this.ReceiveEndPlay_Implementation(endPlayReason);
	}

	// Token: 0x0601BBFA RID: 113658 RVA: 0x008473A8 File Offset: 0x008455A8
	protected unsafe virtual void __CPPCALL_GetInWater_Implementation(CharRenderingComponent.__GetInWater_FunctionParams* __Params)
	{
		__Params->__Result = this.GetInWater_Implementation(__Params->depthThreshold);
	}

	// Token: 0x0601BBFB RID: 113659 RVA: 0x008473BC File Offset: 0x008455BC
	protected unsafe virtual void __CPPCALL_GetInAudioShr_Implementation(CharRenderingComponent.__GetInAudioShr_FunctionParams* __Params)
	{
		__Params->__Result = this.GetInAudioShr_Implementation();
	}

	// Token: 0x0601BBFC RID: 113660 RVA: 0x008473CA File Offset: 0x008455CA
	protected virtual void __CPPCALL_ResetAllRenderingState_Implementation()
	{
		this.ResetAllRenderingState_Implementation();
	}

	// Token: 0x0601BBFD RID: 113661 RVA: 0x008473D4 File Offset: 0x008455D4
	protected unsafe virtual void __CPPCALL_AddMaterialControllerDataGroup_Implementation(CharRenderingComponent.__AddMaterialControllerDataGroup_FunctionParams* __Params)
	{
		UObject orCreateUObjectByNativePointer = BuiltinUtils.GetOrCreateUObjectByNativePointer<UObject>(__Params->data);
		__Params->__Result = this.AddMaterialControllerDataGroup_Implementation(orCreateUObjectByNativePointer);
	}

	// Token: 0x0601BBFE RID: 113662 RVA: 0x008473FC File Offset: 0x008455FC
	protected unsafe virtual void __CPPCALL_AddMaterialControllerDataGroupWithAnimObject_Implementation(CharRenderingComponent.__AddMaterialControllerDataGroupWithAnimObject_FunctionParams* __Params)
	{
		UObject orCreateUObjectByNativePointer = BuiltinUtils.GetOrCreateUObjectByNativePointer<UObject>(__Params->data);
		USkeletalMeshComponent orCreateUObjectByNativePointer2 = BuiltinUtils.GetOrCreateUObjectByNativePointer<USkeletalMeshComponent>(__Params->animObject);
		__Params->__Result = this.AddMaterialControllerDataGroupWithAnimObject_Implementation(orCreateUObjectByNativePointer, orCreateUObjectByNativePointer2);
	}

	// Token: 0x0601BBFF RID: 113663 RVA: 0x0084742F File Offset: 0x0084562F
	protected unsafe virtual void __CPPCALL_RemoveMaterialControllerDataGroup_Implementation(CharRenderingComponent.__RemoveMaterialControllerDataGroup_FunctionParams* __Params)
	{
		this.RemoveMaterialControllerDataGroup_Implementation(__Params->handle);
	}

	// Token: 0x0601BC00 RID: 113664 RVA: 0x0084743D File Offset: 0x0084563D
	protected unsafe virtual void __CPPCALL_RemoveMaterialControllerDataGroupWithEnding_Implementation(CharRenderingComponent.__RemoveMaterialControllerDataGroupWithEnding_FunctionParams* __Params)
	{
		this.RemoveMaterialControllerDataGroupWithEnding_Implementation(__Params->handle);
	}

	// Token: 0x0601BC01 RID: 113665 RVA: 0x0084744C File Offset: 0x0084564C
	protected unsafe virtual void __CPPCALL_AddMaterialControllerDataWithAnimObject_Implementation(CharRenderingComponent.__AddMaterialControllerDataWithAnimObject_FunctionParams* __Params)
	{
		UObject orCreateUObjectByNativePointer = BuiltinUtils.GetOrCreateUObjectByNativePointer<UObject>(__Params->data);
		USkeletalMeshComponent orCreateUObjectByNativePointer2 = BuiltinUtils.GetOrCreateUObjectByNativePointer<USkeletalMeshComponent>(__Params->animObject);
		UObject orCreateUObjectByNativePointer3 = BuiltinUtils.GetOrCreateUObjectByNativePointer<UObject>(__Params->userData);
		__Params->__Result = this.AddMaterialControllerDataWithAnimObject_Implementation(orCreateUObjectByNativePointer, orCreateUObjectByNativePointer2, orCreateUObjectByNativePointer3);
	}

	// Token: 0x0601BC02 RID: 113666 RVA: 0x0084748C File Offset: 0x0084568C
	protected unsafe virtual void __CPPCALL_AddMaterialControllerData_Implementation(CharRenderingComponent.__AddMaterialControllerData_FunctionParams* __Params)
	{
		UObject orCreateUObjectByNativePointer = BuiltinUtils.GetOrCreateUObjectByNativePointer<UObject>(__Params->data);
		__Params->__Result = this.AddMaterialControllerData_Implementation(orCreateUObjectByNativePointer);
	}

	// Token: 0x0601BC03 RID: 113667 RVA: 0x008474B2 File Offset: 0x008456B2
	protected unsafe virtual void __CPPCALL_RemoveMaterialControllerData_Implementation(CharRenderingComponent.__RemoveMaterialControllerData_FunctionParams* __Params)
	{
		this.RemoveMaterialControllerData_Implementation(__Params->handle);
	}

	// Token: 0x0601BC04 RID: 113668 RVA: 0x008474C0 File Offset: 0x008456C0
	protected unsafe virtual void __CPPCALL_SetEffectPause_Implementation(CharRenderingComponent.__SetEffectPause_FunctionParams* __Params)
	{
		this.SetEffectPause_Implementation(__Params->handle, __Params->paused);
	}

	// Token: 0x0601BC05 RID: 113669 RVA: 0x008474D4 File Offset: 0x008456D4
	protected unsafe virtual void __CPPCALL_RemoveMaterialControllerDataWithEnding_Implementation(CharRenderingComponent.__RemoveMaterialControllerDataWithEnding_FunctionParams* __Params)
	{
		this.RemoveMaterialControllerDataWithEnding_Implementation(__Params->handle);
	}

	// Token: 0x0601BC06 RID: 113670 RVA: 0x008474E4 File Offset: 0x008456E4
	protected unsafe virtual void __CPPCALL_SetDitherEffect_Implementation(CharRenderingComponent.__SetDitherEffect_FunctionParams* __Params)
	{
		ECharacterDitherType ditherType = (ECharacterDitherType)__Params->ditherType;
		this.SetDitherEffect_Implementation(__Params->ditherRate, ditherType);
	}

	// Token: 0x0601BC07 RID: 113671 RVA: 0x00847505 File Offset: 0x00845705
	protected unsafe virtual void __CPPCALL_SetDisableFightDither_Implementation(CharRenderingComponent.__SetDisableFightDither_FunctionParams* __Params)
	{
		this.SetDisableFightDither_Implementation(__Params->disable);
	}

	// Token: 0x0601BC08 RID: 113672 RVA: 0x00847513 File Offset: 0x00845713
	protected virtual void __CPPCALL_SetDitherApplyAll_Implementation()
	{
		this.SetDitherApplyAll_Implementation();
	}

	// Token: 0x0601BC09 RID: 113673 RVA: 0x0084751B File Offset: 0x0084571B
	protected virtual void __CPPCALL_SetDitherApplyHeadsOnly_Implementation()
	{
		this.SetDitherApplyHeadsOnly_Implementation();
	}

	// Token: 0x0601BC0A RID: 113674 RVA: 0x00847523 File Offset: 0x00845723
	protected unsafe virtual void __CPPCALL_SetDitherUseHeadMaskHideEffect_Implementation(CharRenderingComponent.__SetDitherUseHeadMaskHideEffect_FunctionParams* __Params)
	{
		this.SetDitherUseHeadMaskHideEffect_Implementation(__Params->enable);
	}

	// Token: 0x0601BC0B RID: 113675 RVA: 0x00847531 File Offset: 0x00845731
	protected virtual void __CPPCALL_TempRemoveDither_Implementation()
	{
		this.TempRemoveDither_Implementation();
	}

	// Token: 0x0601BC0C RID: 113676 RVA: 0x00847539 File Offset: 0x00845739
	protected virtual void __CPPCALL_TempRecoverDither_Implementation()
	{
		this.TempRecoverDither_Implementation();
	}

	// Token: 0x0601BC0D RID: 113677 RVA: 0x00847541 File Offset: 0x00845741
	protected unsafe virtual void __CPPCALL_GetOpacityConsiderVisibility_Implementation(CharRenderingComponent.__GetOpacityConsiderVisibility_FunctionParams* __Params)
	{
		__Params->__Result = this.GetOpacityConsiderVisibility_Implementation();
	}

	// Token: 0x0601BC0E RID: 113678 RVA: 0x00847550 File Offset: 0x00845750
	protected unsafe virtual void __CPPCALL_SetMaterialPropertyFloat_Implementation(CharRenderingComponent.__SetMaterialPropertyFloat_FunctionParams* __Params)
	{
		ECharacterBodySpecifiedType bodyType = (ECharacterBodySpecifiedType)__Params->bodyType;
		ECharacterSlotSpecifiedType slotType = (ECharacterSlotSpecifiedType)__Params->slotType;
		string propertyName = FString.ToString((void*)(&__Params->propertyName));
		this.SetMaterialPropertyFloat_Implementation(bodyType, __Params->sectionIndex, slotType, propertyName, __Params->value);
	}

	// Token: 0x0601BC0F RID: 113679 RVA: 0x00847590 File Offset: 0x00845790
	protected unsafe virtual void __CPPCALL_SetMaterialPropertyColor_Implementation(CharRenderingComponent.__SetMaterialPropertyColor_FunctionParams* __Params)
	{
		ECharacterBodySpecifiedType bodyType = (ECharacterBodySpecifiedType)__Params->bodyType;
		ECharacterSlotSpecifiedType slotType = (ECharacterSlotSpecifiedType)__Params->slotType;
		string propertyName = FString.ToString((void*)(&__Params->propertyName));
		this.SetMaterialPropertyColor_Implementation(bodyType, __Params->sectionIndex, slotType, propertyName, __Params->value);
	}

	// Token: 0x0601BC10 RID: 113680 RVA: 0x008475D0 File Offset: 0x008457D0
	protected unsafe virtual void __CPPCALL_SetMaterialPropertyFloatV2_Implementation(CharRenderingComponent.__SetMaterialPropertyFloatV2_FunctionParams* __Params)
	{
		EKuroCharBodySpecifiedType bodyType = (EKuroCharBodySpecifiedType)__Params->bodyType;
		EKuroCharSlotSpecifiedType slotType = (EKuroCharSlotSpecifiedType)__Params->slotType;
		EKuroCharMeshPart meshPart = (EKuroCharMeshPart)__Params->meshPart;
		this.SetMaterialPropertyFloatV2_Implementation(__Params->name, __Params->value, bodyType, slotType, meshPart);
	}

	// Token: 0x0601BC11 RID: 113681 RVA: 0x00847607 File Offset: 0x00845807
	protected unsafe virtual void __CPPCALL_AddFloatUpdateParamPermanentByIndexV2_Implementation(CharRenderingComponent.__AddFloatUpdateParamPermanentByIndexV2_FunctionParams* __Params)
	{
		this.AddFloatUpdateParamPermanentByIndexV2_Implementation(__Params->name, __Params->value, __Params->bodyName, __Params->materialIndex);
	}

	// Token: 0x0601BC12 RID: 113682 RVA: 0x00847628 File Offset: 0x00845828
	protected unsafe virtual void __CPPCALL_SetMaterialPropertyColorV2_Implementation(CharRenderingComponent.__SetMaterialPropertyColorV2_FunctionParams* __Params)
	{
		EKuroCharBodySpecifiedType bodyType = (EKuroCharBodySpecifiedType)__Params->bodyType;
		EKuroCharSlotSpecifiedType slotType = (EKuroCharSlotSpecifiedType)__Params->slotType;
		EKuroCharMeshPart meshPart = (EKuroCharMeshPart)__Params->meshPart;
		this.SetMaterialPropertyColorV2_Implementation(__Params->name, __Params->value, bodyType, slotType, meshPart);
	}

	// Token: 0x0601BC13 RID: 113683 RVA: 0x00847660 File Offset: 0x00845860
	protected unsafe virtual void __CPPCALL_SetMaterialReplaceV2_Implementation(CharRenderingComponent.__SetMaterialReplaceV2_FunctionParams* __Params)
	{
		UMaterialInterface orCreateUObjectByNativePointer = BuiltinUtils.GetOrCreateUObjectByNativePointer<UMaterialInterface>(__Params->material);
		EKuroCharBodySpecifiedType bodyType = (EKuroCharBodySpecifiedType)__Params->bodyType;
		EKuroCharSlotSpecifiedType slotType = (EKuroCharSlotSpecifiedType)__Params->slotType;
		EKuroCharMeshPart meshPart = (EKuroCharMeshPart)__Params->meshPart;
		this.SetMaterialReplaceV2_Implementation(orCreateUObjectByNativePointer, bodyType, slotType, meshPart);
	}

	// Token: 0x0601BC14 RID: 113684 RVA: 0x00847698 File Offset: 0x00845898
	protected unsafe virtual void __CPPCALL_RemoveExternalMaterialReplaceV2_Implementation(CharRenderingComponent.__RemoveExternalMaterialReplaceV2_FunctionParams* __Params)
	{
		EKuroCharBodySpecifiedType bodyType = (EKuroCharBodySpecifiedType)__Params->bodyType;
		EKuroCharSlotSpecifiedType slotType = (EKuroCharSlotSpecifiedType)__Params->slotType;
		EKuroCharMeshPart meshPart = (EKuroCharMeshPart)__Params->meshPart;
		this.RemoveExternalMaterialReplaceV2_Implementation(bodyType, slotType, meshPart);
	}

	// Token: 0x0601BC15 RID: 113685 RVA: 0x008476C3 File Offset: 0x008458C3
	protected unsafe virtual void __CPPCALL_SetStarScarEnergy_Implementation(CharRenderingComponent.__SetStarScarEnergy_FunctionParams* __Params)
	{
		this.SetStarScarEnergy_Implementation(__Params->value);
	}

	// Token: 0x0601BC16 RID: 113686 RVA: 0x008476D1 File Offset: 0x008458D1
	protected unsafe virtual void __CPPCALL_SetCapsuleDither_Implementation(CharRenderingComponent.__SetCapsuleDither_FunctionParams* __Params)
	{
		this.SetCapsuleDither_Implementation(__Params->value);
	}

	// Token: 0x0601BC17 RID: 113687 RVA: 0x008476DF File Offset: 0x008458DF
	protected unsafe virtual void __CPPCALL_SetDecalShadowEnabled_Implementation(CharRenderingComponent.__SetDecalShadowEnabled_FunctionParams* __Params)
	{
		this.SetDecalShadowEnabled_Implementation(__Params->enable);
	}

	// Token: 0x0601BC18 RID: 113688 RVA: 0x008476ED File Offset: 0x008458ED
	protected virtual void __CPPCALL_DisableAllShadowByDecalShadowComponent_Implementation()
	{
		this.DisableAllShadowByDecalShadowComponent_Implementation();
	}

	// Token: 0x0601BC19 RID: 113689 RVA: 0x008476F5 File Offset: 0x008458F5
	protected unsafe virtual void __CPPCALL_SetShouldCastShadow_Implementation(CharRenderingComponent.__SetShouldCastShadow_FunctionParams* __Params)
	{
		this.SetShouldCastShadow_Implementation(__Params->castShadow);
	}

	// Token: 0x0601BC1A RID: 113690 RVA: 0x00847703 File Offset: 0x00845903
	protected unsafe virtual void __CPPCALL_SetEffectProgress_Implementation(CharRenderingComponent.__SetEffectProgress_FunctionParams* __Params)
	{
		this.SetEffectProgress_Implementation(__Params->progress, __Params->handleId);
	}

	// Token: 0x0601BC1B RID: 113691 RVA: 0x00847717 File Offset: 0x00845917
	protected unsafe virtual void __CPPCALL_SetEffectGroupProgress_Implementation(CharRenderingComponent.__SetEffectGroupProgress_FunctionParams* __Params)
	{
		this.SetEffectGroupProgress_Implementation(__Params->progress, __Params->groupHandleId);
	}

	// Token: 0x0601BC1C RID: 113692 RVA: 0x0084772B File Offset: 0x0084592B
	protected virtual void __CPPCALL_RefreshMaterialController_Implementation()
	{
		this.RefreshMaterialController_Implementation();
	}

	// Token: 0x0601BC1D RID: 113693 RVA: 0x00847733 File Offset: 0x00845933
	protected virtual void __CPPCALL_Destroy_Implementation()
	{
		this.Destroy_Implementation();
	}

	// Token: 0x0601BC1E RID: 113694 RVA: 0x0084773B File Offset: 0x0084593B
	protected virtual void __CPPCALL_OnFinalizedLevelSequence_Implementation()
	{
		this.OnFinalizedLevelSequence_Implementation();
	}

	// Token: 0x0601BC1F RID: 113695 RVA: 0x00847743 File Offset: 0x00845943
	protected unsafe virtual void __CPPCALL_ShouldTickAfterGoDown_Implementation(CharRenderingComponent.__ShouldTickAfterGoDown_FunctionParams* __Params)
	{
		__Params->__Result = this.ShouldTickAfterGoDown_Implementation();
	}

	// Token: 0x0601BC20 RID: 113696 RVA: 0x00847751 File Offset: 0x00845951
	protected virtual void __CPPCALL_ReceiveBeginPlay_Implementation()
	{
		this.ReceiveBeginPlay_Implementation();
	}

	// Token: 0x0601BC21 RID: 113697 RVA: 0x00847759 File Offset: 0x00845959
	protected unsafe virtual void __CPPCALL_ReceiveTick_Implementation(UActorComponent.__ReceiveTick_FunctionParams* __Params)
	{
		this.ReceiveTick_Implementation(__Params->DeltaSeconds);
	}

	// Token: 0x0601BC22 RID: 113698 RVA: 0x00847767 File Offset: 0x00845967
	protected unsafe virtual void __CPPCALL_ReceiveSeqTick_Implementation(CharRenderingComponent.__ReceiveSeqTick_FunctionParams* __Params)
	{
		this.ReceiveSeqTick_Implementation(__Params->deltaSeconds);
	}

	// Token: 0x0400DFEC RID: 57324
	public ECharacterRenderingType? RenderType;

	// Token: 0x0400DFED RID: 57325
	[Nullable(new byte[]
	{
		2,
		1
	})]
	public List<CharRenderBase> AllRenderComps;

	// Token: 0x0400DFEE RID: 57326
	[Nullable(new byte[]
	{
		2,
		1
	})]
	public Dictionary<int, CharRenderBase> AllRenderCompsMap;

	// Token: 0x0400DFEF RID: 57327
	public bool IsInit;

	// Token: 0x0400DFF0 RID: 57328
	public bool IsStartInvoke;

	// Token: 0x0400DFF1 RID: 57329
	public float DeltaTime;

	// Token: 0x0400DFF2 RID: 57330
	public bool IsOnMobile;

	// Token: 0x0400DFF3 RID: 57331
	[Nullable(new byte[]
	{
		2,
		1
	})]
	public Dictionary<int, CharMaterialControlRuntimeDataGroup> AllMaterialControlRuntimeDataGroupMap;

	// Token: 0x0400DFF4 RID: 57332
	public int IndexCount;

	// Token: 0x0400DFF5 RID: 57333
	[Nullable(2)]
	private List<int> TempRemoveList;

	// Token: 0x0400DFF6 RID: 57334
	[Nullable(2)]
	private List<int> SequenceHandleIds;

	// Token: 0x0400DFF7 RID: 57335
	private bool IsDebug;

	// Token: 0x0400DFF8 RID: 57336
	[Nullable(2)]
	private AActor CachedOwner;

	// Token: 0x0400DFF9 RID: 57337
	[Nullable(1)]
	private string CachedOwnerName = "";

	// Token: 0x0400DFFA RID: 57338
	[Nullable(2)]
	private Entity CachedOwnerEntity;

	// Token: 0x0400DFFB RID: 57339
	[Nullable(2)]
	protected AActor LogicOwner;

	// Token: 0x0400DFFC RID: 57340
	protected bool IsLogicOwnerTsEffectActor;

	// Token: 0x0400DFFD RID: 57341
	public bool IsUiUpdate;

	// Token: 0x0400DFFE RID: 57342
	public bool UseMaterialContainerV2 = true;

	// Token: 0x0400DFFF RID: 57343
	public bool CanUpdate = true;

	// Token: 0x0400E000 RID: 57344
	[Nullable(1)]
	public static int[] MotionVelocitySquared;

	// Token: 0x0400E001 RID: 57345
	[Nullable(1)]
	public static EMaterialShadingRate[] MotionMeshShadingRate;

	// Token: 0x0400E002 RID: 57346
	public static bool DisableForDebug;

	// Token: 0x0400E003 RID: 57347
	[Nullable(2)]
	private USkeletalMeshComponent Proxy;

	// Token: 0x0400E004 RID: 57348
	[Nullable(2)]
	private BP_MotorExtraComponent_C MotorExtraComp;

	// Token: 0x0400E005 RID: 57349
	private bool DisableFightDither;

	// Token: 0x0400E006 RID: 57350
	private float FightDitherRateCache = 1f;

	// Token: 0x0400E007 RID: 57351
	public static bool GlobalDisableDitherEffect;

	// Token: 0x0400E008 RID: 57352
	protected bool OnRoleGoDownFinishEventAdded;

	// Token: 0x0400E009 RID: 57353
	[Nullable(2)]
	protected Action RemoveInteractionOnRoleGoDownFinish;

	// Token: 0x0400E00A RID: 57354
	private bool? IsInDebugModeInternal;

	// Token: 0x0400E00B RID: 57355
	private bool? IsRecordInternal;

	// Token: 0x0400E00C RID: 57356
	[Nullable(1)]
	public new const string __ObjectPath = "/Game/Aki/TypeScript/Game/Render/Character/Manager/CharRenderingComponent.CharRenderingComponent_C";

	// Token: 0x0400E00D RID: 57357
	private static IntPtr _ClassPtr;

	// Token: 0x0400E00E RID: 57358
	private static IntPtr _ClassDefaultObjectPtr;

	// Token: 0x0400E00F RID: 57359
	private static int __PropertyOffset_InteractionConfig;

	// Token: 0x0400E010 RID: 57360
	private static int __PropertyOffset_DecalShadowConfig;

	// Token: 0x0400E011 RID: 57361
	private static int __PropertyOffset_MonsterUseBodyEffect;

	// Token: 0x0400E012 RID: 57362
	private static int __PropertyOffset_UseProxy;

	// Token: 0x0400E013 RID: 57363
	private static int __PropertyOffset_ProxyMaterialsOverride;

	// Token: 0x0400E014 RID: 57364
	[Nullable(new byte[]
	{
		2,
		1
	})]
	private TArray<UMaterialInterface> _ProxyMaterialsOverride;

	// Token: 0x0400E015 RID: 57365
	private static int __PropertyOffset_ProxyRenderInMainPass;

	// Token: 0x0400E016 RID: 57366
	private static int __PropertyOffset_ProxyRenderShadow;

	// Token: 0x0400E017 RID: 57367
	private static int __PropertyOffset_ProxyRenderTrail;

	// Token: 0x0400E018 RID: 57368
	private static int __PropertyOffset_DitherRemap;

	// Token: 0x0200949E RID: 38046
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 24)]
	protected ref struct __QuickInitAndAddData_FunctionParams
	{
		// Token: 0x04031453 RID: 201811
		[FieldOffset(0)]
		public IntPtr data;

		// Token: 0x04031454 RID: 201812
		[FieldOffset(8)]
		public IntPtr meshActor;

		// Token: 0x04031455 RID: 201813
		[FieldOffset(16)]
		public float __Result;
	}

	// Token: 0x0200949F RID: 38047
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 24)]
	protected ref struct __QuickInitAndAddDataWithMeshComponent_FunctionParams
	{
		// Token: 0x04031456 RID: 201814
		[FieldOffset(0)]
		public IntPtr data;

		// Token: 0x04031457 RID: 201815
		[FieldOffset(8)]
		public IntPtr meshComponent;

		// Token: 0x04031458 RID: 201816
		[FieldOffset(16)]
		public float __Result;
	}

	// Token: 0x020094A0 RID: 38048
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 24)]
	protected ref struct __QuickInitAndAddDataGroup_FunctionParams
	{
		// Token: 0x04031459 RID: 201817
		[FieldOffset(0)]
		public IntPtr data;

		// Token: 0x0403145A RID: 201818
		[FieldOffset(8)]
		public IntPtr meshActor;

		// Token: 0x0403145B RID: 201819
		[FieldOffset(16)]
		public float __Result;
	}

	// Token: 0x020094A1 RID: 38049
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 24)]
	protected ref struct __QuickInitAndAddDataGroupWithMeshComponent_FunctionParams
	{
		// Token: 0x0403145C RID: 201820
		[FieldOffset(0)]
		public IntPtr data;

		// Token: 0x0403145D RID: 201821
		[FieldOffset(8)]
		public IntPtr meshComponent;

		// Token: 0x0403145E RID: 201822
		[FieldOffset(16)]
		public float __Result;
	}

	// Token: 0x020094A2 RID: 38050
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 1)]
	protected ref struct __Init_FunctionParams
	{
		// Token: 0x0403145F RID: 201823
		[FieldOffset(0)]
		public byte renderType;
	}

	// Token: 0x020094A3 RID: 38051
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 8)]
	protected ref struct __SetLogicOwner_FunctionParams
	{
		// Token: 0x04031460 RID: 201824
		[FieldOffset(0)]
		public IntPtr owner;
	}

	// Token: 0x020094A4 RID: 38052
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 24)]
	protected ref struct __AddComponent_FunctionParams
	{
		// Token: 0x04031461 RID: 201825
		[FieldOffset(0)]
		public FString skelName;

		// Token: 0x04031462 RID: 201826
		[FieldOffset(16)]
		public IntPtr skeletalComp;
	}

	// Token: 0x020094A5 RID: 38053
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 24)]
	protected ref struct __AddComponentWithEmptyMaterial_FunctionParams
	{
		// Token: 0x04031463 RID: 201827
		[FieldOffset(0)]
		public FString skelName;

		// Token: 0x04031464 RID: 201828
		[FieldOffset(16)]
		public IntPtr skeletalComp;
	}

	// Token: 0x020094A6 RID: 38054
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 16)]
	protected ref struct __RemoveComponent_FunctionParams
	{
		// Token: 0x04031465 RID: 201829
		[FieldOffset(0)]
		public FString skelName;
	}

	// Token: 0x020094A7 RID: 38055
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 16)]
	protected ref struct __AddComponentByCase_FunctionParams
	{
		// Token: 0x04031466 RID: 201830
		[FieldOffset(0)]
		public byte caseType;

		// Token: 0x04031467 RID: 201831
		[FieldOffset(8)]
		public IntPtr skeletalComp;
	}

	// Token: 0x020094A8 RID: 38056
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 1)]
	protected ref struct __RemoveComponentByCase_FunctionParams
	{
		// Token: 0x04031468 RID: 201832
		[FieldOffset(0)]
		public byte caseType;
	}

	// Token: 0x020094A9 RID: 38057
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 32)]
	protected ref struct __AddComponentInnerV2_FunctionParams
	{
		// Token: 0x04031469 RID: 201833
		[FieldOffset(0)]
		public FString skelName;

		// Token: 0x0403146A RID: 201834
		[FieldOffset(16)]
		public IntPtr skeletalComp;

		// Token: 0x0403146B RID: 201835
		[FieldOffset(24)]
		public bool useEmptyMaterial;
	}

	// Token: 0x020094AA RID: 38058
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 16)]
	protected ref struct __RemoveComponentInnerV2_FunctionParams
	{
		// Token: 0x0403146C RID: 201836
		[FieldOffset(0)]
		public FString skelName;
	}

	// Token: 0x020094AB RID: 38059
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 24)]
	protected ref struct __GetSkeletalMeshComponent_FunctionParams
	{
		// Token: 0x0403146D RID: 201837
		[FieldOffset(0)]
		public FString skelName;

		// Token: 0x0403146E RID: 201838
		[FieldOffset(16)]
		public IntPtr __Result;
	}

	// Token: 0x020094AC RID: 38060
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 24)]
	protected ref struct __GetSkeletalMeshComponentBodyName_FunctionParams
	{
		// Token: 0x0403146F RID: 201839
		[FieldOffset(0)]
		public IntPtr skeletalComp;

		// Token: 0x04031470 RID: 201840
		[FieldOffset(8)]
		public FName __Result;
	}

	// Token: 0x020094AD RID: 38061
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 1)]
	protected ref struct __CheckInit_FunctionParams
	{
		// Token: 0x04031471 RID: 201841
		[FieldOffset(0)]
		public bool __Result;
	}

	// Token: 0x020094AE RID: 38062
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 1)]
	protected ref struct __SetDebug_FunctionParams
	{
		// Token: 0x04031472 RID: 201842
		[FieldOffset(0)]
		public bool value;
	}

	// Token: 0x020094AF RID: 38063
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 8)]
	protected ref struct __GetDebugInfo_FunctionParams
	{
		// Token: 0x04031473 RID: 201843
		[FieldOffset(0)]
		public IntPtr __Result;
	}

	// Token: 0x020094B0 RID: 38064
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 8)]
	protected ref struct __GetInWater_FunctionParams
	{
		// Token: 0x04031474 RID: 201844
		[FieldOffset(0)]
		public float depthThreshold;

		// Token: 0x04031475 RID: 201845
		[FieldOffset(4)]
		public bool __Result;
	}

	// Token: 0x020094B1 RID: 38065
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 1)]
	protected ref struct __GetInAudioShr_FunctionParams
	{
		// Token: 0x04031476 RID: 201846
		[FieldOffset(0)]
		public bool __Result;
	}

	// Token: 0x020094B2 RID: 38066
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 16)]
	protected ref struct __AddMaterialControllerDataGroup_FunctionParams
	{
		// Token: 0x04031477 RID: 201847
		[FieldOffset(0)]
		public IntPtr data;

		// Token: 0x04031478 RID: 201848
		[FieldOffset(8)]
		public int __Result;
	}

	// Token: 0x020094B3 RID: 38067
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 24)]
	protected ref struct __AddMaterialControllerDataGroupWithAnimObject_FunctionParams
	{
		// Token: 0x04031479 RID: 201849
		[FieldOffset(0)]
		public IntPtr data;

		// Token: 0x0403147A RID: 201850
		[FieldOffset(8)]
		public IntPtr animObject;

		// Token: 0x0403147B RID: 201851
		[FieldOffset(16)]
		public float __Result;
	}

	// Token: 0x020094B4 RID: 38068
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 4)]
	protected ref struct __RemoveMaterialControllerDataGroup_FunctionParams
	{
		// Token: 0x0403147C RID: 201852
		[FieldOffset(0)]
		public int handle;
	}

	// Token: 0x020094B5 RID: 38069
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 4)]
	protected ref struct __RemoveMaterialControllerDataGroupWithEnding_FunctionParams
	{
		// Token: 0x0403147D RID: 201853
		[FieldOffset(0)]
		public int handle;
	}

	// Token: 0x020094B6 RID: 38070
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 32)]
	protected ref struct __AddMaterialControllerDataWithAnimObject_FunctionParams
	{
		// Token: 0x0403147E RID: 201854
		[FieldOffset(0)]
		public IntPtr data;

		// Token: 0x0403147F RID: 201855
		[FieldOffset(8)]
		public IntPtr animObject;

		// Token: 0x04031480 RID: 201856
		[FieldOffset(16)]
		public IntPtr userData;

		// Token: 0x04031481 RID: 201857
		[FieldOffset(24)]
		public float __Result;
	}

	// Token: 0x020094B7 RID: 38071
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 16)]
	protected ref struct __AddMaterialControllerData_FunctionParams
	{
		// Token: 0x04031482 RID: 201858
		[FieldOffset(0)]
		public IntPtr data;

		// Token: 0x04031483 RID: 201859
		[FieldOffset(8)]
		public int __Result;
	}

	// Token: 0x020094B8 RID: 38072
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 4)]
	protected ref struct __RemoveMaterialControllerData_FunctionParams
	{
		// Token: 0x04031484 RID: 201860
		[FieldOffset(0)]
		public int handle;
	}

	// Token: 0x020094B9 RID: 38073
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 8)]
	protected ref struct __SetEffectPause_FunctionParams
	{
		// Token: 0x04031485 RID: 201861
		[FieldOffset(0)]
		public int handle;

		// Token: 0x04031486 RID: 201862
		[FieldOffset(4)]
		public bool paused;
	}

	// Token: 0x020094BA RID: 38074
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 4)]
	protected ref struct __RemoveMaterialControllerDataWithEnding_FunctionParams
	{
		// Token: 0x04031487 RID: 201863
		[FieldOffset(0)]
		public int handle;
	}

	// Token: 0x020094BB RID: 38075
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 8)]
	protected ref struct __SetDitherEffect_FunctionParams
	{
		// Token: 0x04031488 RID: 201864
		[FieldOffset(0)]
		public float ditherRate;

		// Token: 0x04031489 RID: 201865
		[FieldOffset(4)]
		public byte ditherType;
	}

	// Token: 0x020094BC RID: 38076
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 1)]
	protected ref struct __SetDisableFightDither_FunctionParams
	{
		// Token: 0x0403148A RID: 201866
		[FieldOffset(0)]
		public bool disable;
	}

	// Token: 0x020094BD RID: 38077
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 1)]
	protected ref struct __SetDitherUseHeadMaskHideEffect_FunctionParams
	{
		// Token: 0x0403148B RID: 201867
		[FieldOffset(0)]
		public bool enable;
	}

	// Token: 0x020094BE RID: 38078
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 4)]
	protected ref struct __GetOpacityConsiderVisibility_FunctionParams
	{
		// Token: 0x0403148C RID: 201868
		[FieldOffset(0)]
		public float __Result;
	}

	// Token: 0x020094BF RID: 38079
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 40)]
	protected ref struct __SetMaterialPropertyFloat_FunctionParams
	{
		// Token: 0x0403148D RID: 201869
		[FieldOffset(0)]
		public byte bodyType;

		// Token: 0x0403148E RID: 201870
		[FieldOffset(4)]
		public float sectionIndex;

		// Token: 0x0403148F RID: 201871
		[FieldOffset(8)]
		public byte slotType;

		// Token: 0x04031490 RID: 201872
		[FieldOffset(16)]
		public FString propertyName;

		// Token: 0x04031491 RID: 201873
		[FieldOffset(32)]
		public float value;
	}

	// Token: 0x020094C0 RID: 38080
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 48)]
	protected ref struct __SetMaterialPropertyColor_FunctionParams
	{
		// Token: 0x04031492 RID: 201874
		[FieldOffset(0)]
		public byte bodyType;

		// Token: 0x04031493 RID: 201875
		[FieldOffset(4)]
		public float sectionIndex;

		// Token: 0x04031494 RID: 201876
		[FieldOffset(8)]
		public byte slotType;

		// Token: 0x04031495 RID: 201877
		[FieldOffset(16)]
		public FString propertyName;

		// Token: 0x04031496 RID: 201878
		[FieldOffset(32)]
		public FLinearColor value;
	}

	// Token: 0x020094C1 RID: 38081
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 20)]
	protected ref struct __SetMaterialPropertyFloatV2_FunctionParams
	{
		// Token: 0x04031497 RID: 201879
		[FieldOffset(0)]
		public FName name;

		// Token: 0x04031498 RID: 201880
		[FieldOffset(12)]
		public float value;

		// Token: 0x04031499 RID: 201881
		[FieldOffset(16)]
		public byte bodyType;

		// Token: 0x0403149A RID: 201882
		[FieldOffset(17)]
		public byte slotType;

		// Token: 0x0403149B RID: 201883
		[FieldOffset(18)]
		public byte meshPart;
	}

	// Token: 0x020094C2 RID: 38082
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 32)]
	protected ref struct __AddFloatUpdateParamPermanentByIndexV2_FunctionParams
	{
		// Token: 0x0403149C RID: 201884
		[FieldOffset(0)]
		public FName name;

		// Token: 0x0403149D RID: 201885
		[FieldOffset(12)]
		public float value;

		// Token: 0x0403149E RID: 201886
		[FieldOffset(16)]
		public FName bodyName;

		// Token: 0x0403149F RID: 201887
		[FieldOffset(28)]
		public float materialIndex;
	}

	// Token: 0x020094C3 RID: 38083
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 32)]
	protected ref struct __SetMaterialPropertyColorV2_FunctionParams
	{
		// Token: 0x040314A0 RID: 201888
		[FieldOffset(0)]
		public FName name;

		// Token: 0x040314A1 RID: 201889
		[FieldOffset(12)]
		public FLinearColor value;

		// Token: 0x040314A2 RID: 201890
		[FieldOffset(28)]
		public byte bodyType;

		// Token: 0x040314A3 RID: 201891
		[FieldOffset(29)]
		public byte slotType;

		// Token: 0x040314A4 RID: 201892
		[FieldOffset(30)]
		public byte meshPart;
	}

	// Token: 0x020094C4 RID: 38084
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 16)]
	protected ref struct __SetMaterialReplaceV2_FunctionParams
	{
		// Token: 0x040314A5 RID: 201893
		[FieldOffset(0)]
		public IntPtr material;

		// Token: 0x040314A6 RID: 201894
		[FieldOffset(8)]
		public byte bodyType;

		// Token: 0x040314A7 RID: 201895
		[FieldOffset(9)]
		public byte slotType;

		// Token: 0x040314A8 RID: 201896
		[FieldOffset(10)]
		public byte meshPart;
	}

	// Token: 0x020094C5 RID: 38085
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 3)]
	protected ref struct __RemoveExternalMaterialReplaceV2_FunctionParams
	{
		// Token: 0x040314A9 RID: 201897
		[FieldOffset(0)]
		public byte bodyType;

		// Token: 0x040314AA RID: 201898
		[FieldOffset(1)]
		public byte slotType;

		// Token: 0x040314AB RID: 201899
		[FieldOffset(2)]
		public byte meshPart;
	}

	// Token: 0x020094C6 RID: 38086
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 4)]
	protected ref struct __SetStarScarEnergy_FunctionParams
	{
		// Token: 0x040314AC RID: 201900
		[FieldOffset(0)]
		public float value;
	}

	// Token: 0x020094C7 RID: 38087
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 4)]
	protected ref struct __SetCapsuleDither_FunctionParams
	{
		// Token: 0x040314AD RID: 201901
		[FieldOffset(0)]
		public float value;
	}

	// Token: 0x020094C8 RID: 38088
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 1)]
	protected ref struct __SetDecalShadowEnabled_FunctionParams
	{
		// Token: 0x040314AE RID: 201902
		[FieldOffset(0)]
		public bool enable;
	}

	// Token: 0x020094C9 RID: 38089
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 1)]
	protected ref struct __SetShouldCastShadow_FunctionParams
	{
		// Token: 0x040314AF RID: 201903
		[FieldOffset(0)]
		public bool castShadow;
	}

	// Token: 0x020094CA RID: 38090
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 8)]
	protected ref struct __SetEffectProgress_FunctionParams
	{
		// Token: 0x040314B0 RID: 201904
		[FieldOffset(0)]
		public float progress;

		// Token: 0x040314B1 RID: 201905
		[FieldOffset(4)]
		public int handleId;
	}

	// Token: 0x020094CB RID: 38091
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 8)]
	protected ref struct __SetEffectGroupProgress_FunctionParams
	{
		// Token: 0x040314B2 RID: 201906
		[FieldOffset(0)]
		public float progress;

		// Token: 0x040314B3 RID: 201907
		[FieldOffset(4)]
		public int groupHandleId;
	}

	// Token: 0x020094CC RID: 38092
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 1)]
	protected ref struct __ShouldTickAfterGoDown_FunctionParams
	{
		// Token: 0x040314B4 RID: 201908
		[FieldOffset(0)]
		public bool __Result;
	}

	// Token: 0x020094CD RID: 38093
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 4)]
	protected ref struct __ReceiveSeqTick_FunctionParams
	{
		// Token: 0x040314B5 RID: 201909
		[FieldOffset(0)]
		public float deltaSeconds;
	}
}
