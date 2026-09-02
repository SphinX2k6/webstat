using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using AkiClient.Game.Aki.Character.BaseCharacter;
using AkiClient.Game.Aki.Render.RuntimeBP.Character.Manager;
using AkiClient.Game.Aki.Render.RuntimeBP.Character.Npc;
using CSharpScript.Core.Common;
using CSharpScript.Game;
using Cysharp.Threading.Tasks;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Service.Flags;
using UnrealEngine.Utils;

// Token: 0x0200320B RID: 12811
[NullableContext(2)]
[Nullable(0)]
[UClass("/Game/Aki/TypeScript/Game/NewWorld/Character/SimpleNpc/Blueprint/", EClassFlags.CLASS_None)]
[UnrealObjectPath("/Game/Aki/TypeScript/Game/NewWorld/Character/SimpleNpc/Blueprint/TsSimpleNpc.TsSimpleNpc_C")]
public class TsSimpleNpc : AKuroEffectActor, IStaticVariableResetter, IUnrealUObject, IUnrealObject
{
	// Token: 0x0601A959 RID: 108889 RVA: 0x007E31A0 File Offset: 0x007E13A0
	static TsSimpleNpc()
	{
		StaticVariableRegister.RegisterAndExecute(new Action(TsSimpleNpc.CreateStaticDefaultValue), new Action(TsSimpleNpc.ResetStaticDefaultValue));
	}

	// Token: 0x170023F1 RID: 9201
	// (get) Token: 0x0601A95A RID: 108890 RVA: 0x007E31BF File Offset: 0x007E13BF
	// (set) Token: 0x0601A95B RID: 108891 RVA: 0x007E31D3 File Offset: 0x007E13D3
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe UCapsuleComponent CapsuleCollision
	{
		get
		{
			return BuiltinUtils.ObjectPropertyGetter<UCapsuleComponent>(base.NativePtr / (IntPtr)sizeof(void*) + TsSimpleNpc.__PropertyOffset_CapsuleCollision);
		}
		set
		{
			BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + TsSimpleNpc.__PropertyOffset_CapsuleCollision, value);
		}
	}

	// Token: 0x170023F2 RID: 9202
	// (get) Token: 0x0601A95C RID: 108892 RVA: 0x007E31E8 File Offset: 0x007E13E8
	// (set) Token: 0x0601A95D RID: 108893 RVA: 0x007E31FC File Offset: 0x007E13FC
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe USkeletalMeshComponent Mesh
	{
		get
		{
			return BuiltinUtils.ObjectPropertyGetter<USkeletalMeshComponent>(base.NativePtr / (IntPtr)sizeof(void*) + TsSimpleNpc.__PropertyOffset_Mesh);
		}
		set
		{
			BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + TsSimpleNpc.__PropertyOffset_Mesh, value);
		}
	}

	// Token: 0x170023F3 RID: 9203
	// (get) Token: 0x0601A95E RID: 108894 RVA: 0x007E3211 File Offset: 0x007E1411
	// (set) Token: 0x0601A95F RID: 108895 RVA: 0x007E3225 File Offset: 0x007E1425
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe CharRenderingComponent CharRenderingComponent
	{
		get
		{
			return BuiltinUtils.ObjectPropertyGetter<CharRenderingComponent>(base.NativePtr / (IntPtr)sizeof(void*) + TsSimpleNpc.__PropertyOffset_CharRenderingComponent);
		}
		set
		{
			BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + TsSimpleNpc.__PropertyOffset_CharRenderingComponent, value);
		}
	}

	// Token: 0x170023F4 RID: 9204
	// (get) Token: 0x0601A960 RID: 108896 RVA: 0x007E323C File Offset: 0x007E143C
	// (set) Token: 0x0601A961 RID: 108897 RVA: 0x007E3275 File Offset: 0x007E1475
	[Nullable(1)]
	[UProperty(EPropertyFlags.CPF_None)]
	public FSoftObjectPath DA
	{
		[NullableContext(1)]
		get
		{
			base.FastCheckIsValid();
			FSoftObjectPath result;
			if ((result = this._DA) == null)
			{
				result = (this._DA = new FSoftObjectPath(base.NativePtr + (IntPtr)TsSimpleNpc.__PropertyOffset_DA, this));
			}
			return result;
		}
		[NullableContext(1)]
		set
		{
			UnrealReflectionUtils.CopyNativeStruct(FSoftObjectPath.StaticStruct(), base.NativePtr + (IntPtr)TsSimpleNpc.__PropertyOffset_DA, (value != null) ? value.NativePtr : ((IntPtr)0), 1, false);
		}
	}

	// Token: 0x170023F5 RID: 9205
	// (get) Token: 0x0601A962 RID: 108898 RVA: 0x007E329D File Offset: 0x007E149D
	// (set) Token: 0x0601A963 RID: 108899 RVA: 0x007E32AD File Offset: 0x007E14AD
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe bool DisappearOnSunny
	{
		get
		{
			return *(base.NativePtr + (IntPtr)TsSimpleNpc.__PropertyOffset_DisappearOnSunny) != 0;
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsSimpleNpc.__PropertyOffset_DisappearOnSunny) = (value ? 1 : 0);
		}
	}

	// Token: 0x170023F6 RID: 9206
	// (get) Token: 0x0601A964 RID: 108900 RVA: 0x007E32BE File Offset: 0x007E14BE
	// (set) Token: 0x0601A965 RID: 108901 RVA: 0x007E32CE File Offset: 0x007E14CE
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe bool DisappearOnCloudy
	{
		get
		{
			return *(base.NativePtr + (IntPtr)TsSimpleNpc.__PropertyOffset_DisappearOnCloudy) != 0;
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsSimpleNpc.__PropertyOffset_DisappearOnCloudy) = (value ? 1 : 0);
		}
	}

	// Token: 0x170023F7 RID: 9207
	// (get) Token: 0x0601A966 RID: 108902 RVA: 0x007E32DF File Offset: 0x007E14DF
	// (set) Token: 0x0601A967 RID: 108903 RVA: 0x007E32EF File Offset: 0x007E14EF
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe bool DisappearOnRainy
	{
		get
		{
			return *(base.NativePtr + (IntPtr)TsSimpleNpc.__PropertyOffset_DisappearOnRainy) != 0;
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsSimpleNpc.__PropertyOffset_DisappearOnRainy) = (value ? 1 : 0);
		}
	}

	// Token: 0x170023F8 RID: 9208
	// (get) Token: 0x0601A968 RID: 108904 RVA: 0x007E3300 File Offset: 0x007E1500
	// (set) Token: 0x0601A969 RID: 108905 RVA: 0x007E3310 File Offset: 0x007E1510
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe bool DisappearOnThunderRain
	{
		get
		{
			return *(base.NativePtr + (IntPtr)TsSimpleNpc.__PropertyOffset_DisappearOnThunderRain) != 0;
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsSimpleNpc.__PropertyOffset_DisappearOnThunderRain) = (value ? 1 : 0);
		}
	}

	// Token: 0x170023F9 RID: 9209
	// (get) Token: 0x0601A96A RID: 108906 RVA: 0x007E3321 File Offset: 0x007E1521
	// (set) Token: 0x0601A96B RID: 108907 RVA: 0x007E3331 File Offset: 0x007E1531
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe bool DisappearOnSnowy
	{
		get
		{
			return *(base.NativePtr + (IntPtr)TsSimpleNpc.__PropertyOffset_DisappearOnSnowy) != 0;
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsSimpleNpc.__PropertyOffset_DisappearOnSnowy) = (value ? 1 : 0);
		}
	}

	// Token: 0x170023FA RID: 9210
	// (get) Token: 0x0601A96C RID: 108908 RVA: 0x007E3342 File Offset: 0x007E1542
	// (set) Token: 0x0601A96D RID: 108909 RVA: 0x007E3352 File Offset: 0x007E1552
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe int LodLevel
	{
		get
		{
			return *(base.NativePtr + (IntPtr)TsSimpleNpc.__PropertyOffset_LodLevel);
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsSimpleNpc.__PropertyOffset_LodLevel) = value;
		}
	}

	// Token: 0x170023FB RID: 9211
	// (get) Token: 0x0601A96E RID: 108910 RVA: 0x007E3363 File Offset: 0x007E1563
	// (set) Token: 0x0601A96F RID: 108911 RVA: 0x007E3373 File Offset: 0x007E1573
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe float DebugDitherValue
	{
		get
		{
			return *(base.NativePtr + (IntPtr)TsSimpleNpc.__PropertyOffset_DebugDitherValue);
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsSimpleNpc.__PropertyOffset_DebugDitherValue) = value;
		}
	}

	// Token: 0x170023FC RID: 9212
	// (get) Token: 0x0601A970 RID: 108912 RVA: 0x007E3384 File Offset: 0x007E1584
	[Nullable(1)]
	public CharacterDitherEffectController DitherEffectController
	{
		[NullableContext(1)]
		get
		{
			if (this.DitherEffectControllerInternal == null)
			{
				this.DitherEffectControllerInternal = new CharacterDitherEffectController(this, this.CharRenderingComponent);
			}
			return this.DitherEffectControllerInternal;
		}
	}

	// Token: 0x0601A971 RID: 108913 RVA: 0x007E33A8 File Offset: 0x007E15A8
	[UFunction(EFunctionFlags.FUNC_BlueprintNativeEvent)]
	public unsafe override void EditorInit()
	{
		int num;
		IntPtr ufunctionPtrAndSizeChecked = UnrealReflectionUtils.GetUFunctionPtrAndSizeChecked(base.NativePtr, new FName("EditorInit"), out num);
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

	// Token: 0x0601A972 RID: 108914 RVA: 0x007E3418 File Offset: 0x007E1618
	protected virtual void EditorInit_Implementation()
	{
		base.bEditorTickBySelected = true;
		this.CachedLocation = Vector.Create();
		this.TempLocation = Vector.Create();
		Vector cachedLocation = this.CachedLocation;
		FVectorDouble fvectorDouble = base.D_K2_GetActorLocation();
		cachedLocation.FromUeVector(fvectorDouble);
		if (this.Mesh != null)
		{
			this.TempAnimInstance = this.Mesh.AnimScriptInstance;
			this.TempAnimAsset = this.Mesh.AnimationData.AnimToPlay;
		}
		this.TempDaPath = this.DA.AssetPathName.ToString();
		this.LoadModel();
		if (!base.Tags.Contains(Singleton<CharacterNameDefines>.Instance.PFT_NO_SPAWN))
		{
			base.Tags.Add(Singleton<CharacterNameDefines>.Instance.PFT_NO_SPAWN);
		}
		base.bSetActorComponentTickEnabledByFocus = true;
		base.EditorSetActorComponentsTickEnabled(false);
	}

	// Token: 0x0601A973 RID: 108915 RVA: 0x007E34E4 File Offset: 0x007E16E4
	[UFunction(EFunctionFlags.FUNC_BlueprintNativeEvent)]
	public unsafe override void EditorTick(float deltaSeconds)
	{
		int num;
		IntPtr ufunctionPtrAndSizeChecked = UnrealReflectionUtils.GetUFunctionPtrAndSizeChecked(base.NativePtr, new FName("EditorTick"), out num);
		byte* ptr = stackalloc byte[(UIntPtr)((num != 0) ? (num + 15) : 0)];
		AKuroEffectActor.__EditorTick_FunctionParams* ptr2 = null;
		if (num != 0)
		{
			ptr2 = ((AKuroEffectActor.__EditorTick_FunctionParams*)ptr + 15L / (long)sizeof(AKuroEffectActor.__EditorTick_FunctionParams) & -16L);
			UnrealReflectionUtils.InitializeStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
			ptr2->DeltaSeconds = deltaSeconds;
		}
		UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ufunctionPtrAndSizeChecked, (void*)ptr2);
		if (num != 0)
		{
			UnrealReflectionUtils.DestroyStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
		}
	}

	// Token: 0x0601A974 RID: 108916 RVA: 0x007E355C File Offset: 0x007E175C
	protected virtual void EditorTick_Implementation(float deltaSeconds)
	{
		if (this.TempLocation == null)
		{
			this.EditorInit();
			return;
		}
		Vector tempLocation = this.TempLocation;
		FVectorDouble fvectorDouble = base.D_K2_GetActorLocation();
		tempLocation.FromUeVector(fvectorDouble);
		if (Vector.DistSquared(this.CachedLocation, this.TempLocation) > 900.0)
		{
			this.CachedLocation.DeepCopy(this.TempLocation);
			this.IsDirty = true;
			return;
		}
		if (this.Mesh != null)
		{
			if (this.Mesh.AnimationMode == EAnimationMode.AnimationBlueprint)
			{
				this.TempAnimAsset = null;
				if (this.Mesh.AnimScriptInstance != this.TempAnimInstance)
				{
					this.TempAnimInstance = this.Mesh.AnimScriptInstance;
					this.IsDirty = true;
					return;
				}
			}
			else if (this.Mesh.AnimationMode == EAnimationMode.AnimationSingleNode)
			{
				this.TempAnimInstance = null;
				if (this.Mesh.AnimationData.AnimToPlay != this.TempAnimAsset)
				{
					this.TempAnimAsset = this.Mesh.AnimationData.AnimToPlay;
					this.IsDirty = true;
					return;
				}
			}
		}
		if (this.TempDaPath != this.DA.AssetPathName.ToString())
		{
			this.TempDaPath = this.DA.AssetPathName.ToString();
			this.IsDirty = true;
			return;
		}
		if (this.IsDirty)
		{
			this.IsDirty = false;
			this.LoadModel();
			UKuroStaticLibrary.SetActorModify(this);
			return;
		}
		if (this.NeedResetCollision)
		{
			this.NeedResetCollision = false;
			this.SetDefaultCollision();
			this.ResetMeshLocation();
		}
	}

	// Token: 0x0601A975 RID: 108917 RVA: 0x007E36F0 File Offset: 0x007E18F0
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

	// Token: 0x0601A976 RID: 108918 RVA: 0x007E3760 File Offset: 0x007E1960
	protected virtual void ReceiveBeginPlay_Implementation()
	{
		this.InitData();
	}

	// Token: 0x0601A977 RID: 108919 RVA: 0x007E3768 File Offset: 0x007E1968
	public void InitData()
	{
		this.FindComponents();
		this.InitCollisionInfo();
		this.InitBaseInfo();
		this.InitRenderInfo();
		this.InitDaInfo();
		this.SetTickEnabled(false);
		this.SetMainShadowEnabled(false);
		ControllerBase<SimpleNpcController>.Instance.Add(this);
		base.Tags.Add(Singleton<CharacterNameDefines>.Instance.NO_SLIDE);
	}

	// Token: 0x0601A978 RID: 108920 RVA: 0x007E37C4 File Offset: 0x007E19C4
	private void InitCollisionInfo()
	{
		this.CapsuleCollision.bCanCharacterStandOn = false;
		this.CapsuleCollision.CanCharacterStepUpOn = ECanBeCharacterBase.ECB_No;
		this.CapsuleCollision.SetCollisionObjectType(ECollisionChannel.ECC_WorldStatic);
		this.CapsuleCollision.SetCollisionResponseToAllChannels(ECollisionResponse.ECR_Ignore);
		Singleton<CollisionUtils>.Instance.SetCollisionResponseToPawn(this.CapsuleCollision, EPawnChannel.All, ECollisionResponse.ECR_Block);
	}

	// Token: 0x0601A979 RID: 108921 RVA: 0x007E3818 File Offset: 0x007E1A18
	private void InitBaseInfo()
	{
		this.FlowLogic = new SimpleNpcFlowLogic(this);
		this.StartLocation = new FVectorDouble?(base.D_K2_GetActorLocation());
		this.StartLocationProxy = Vector.Create(this.StartLocation);
		this.IsInLogicRangeInternal = new bool?(false);
		this.RegisterLoopTimerId = null;
		TsBaseCharacter baseCharacter = Global.BaseCharacter;
		if (baseCharacter != null)
		{
			Vector actorLocationProxy = baseCharacter.CharacterActorComponent.ActorLocationProxy;
			this.TempDistanceSquared = Vector.DistSquared(this.StartLocationProxy, actorLocationProxy);
		}
		this.InstanceId = ++TsSimpleNpc.InstanceCount;
		if (GlobalData.IsPlayInEditor)
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.World;
			ELogAuthor author = ELogAuthor.CJH;
			string message = "创建SimpleNpc";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("Id", this.InstanceId);
			instance.Info(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
		}
	}

	// Token: 0x0601A97A RID: 108922 RVA: 0x007E38DD File Offset: 0x007E1ADD
	private void InitRenderInfo()
	{
		this.CharRenderingComponent.Init(ECharacterRenderingType.Npc);
		base.SetPrimitiveEntityType(2U);
		this.SetAnimUROParams();
	}

	// Token: 0x0601A97B RID: 108923 RVA: 0x007E38F8 File Offset: 0x007E1AF8
	private void InitDaInfo()
	{
		if (ObjectUtils.SoftObjectPathIsValid(this.DA))
		{
			this.IsNotUnload = true;
			this.IsModelLoadedInternal = false;
			return;
		}
		this.IsModelLoadedInternal = true;
		if (!GlobalData.IsPlayInEditor)
		{
			this.CacheComponents();
			this.CloseSkeletalMeshShadow();
		}
		this.CharRenderingComponent.UpdateNpcDitherComponent();
		ControllerBase<SimpleNpcController>.Instance.CheckNpcShowState(this, true, true);
	}

	// Token: 0x0601A97C RID: 108924 RVA: 0x007E3954 File Offset: 0x007E1B54
	[NullableContext(0)]
	[UFunction(EFunctionFlags.FUNC_BlueprintNativeEvent)]
	public unsafe virtual void ReceiveEndPlay(TEnumAsByte<EEndPlayReason> endPlayReason)
	{
		int num;
		IntPtr ufunctionPtrAndSizeChecked = UnrealReflectionUtils.GetUFunctionPtrAndSizeChecked(base.NativePtr, new FName("ReceiveEndPlay"), out num);
		byte* ptr = stackalloc byte[(UIntPtr)((num != 0) ? (num + 15) : 0)];
		TsSimpleNpc.__ReceiveEndPlay_FunctionParams* ptr2 = null;
		if (num != 0)
		{
			ptr2 = ((TsSimpleNpc.__ReceiveEndPlay_FunctionParams*)ptr + 15L / (long)sizeof(TsSimpleNpc.__ReceiveEndPlay_FunctionParams) & -16L);
			UnrealReflectionUtils.InitializeStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
			ptr2->endPlayReason = endPlayReason;
		}
		UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ufunctionPtrAndSizeChecked, (void*)ptr2);
		if (num != 0)
		{
			UnrealReflectionUtils.DestroyStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
		}
	}

	// Token: 0x0601A97D RID: 108925 RVA: 0x007E39CC File Offset: 0x007E1BCC
	[NullableContext(0)]
	protected unsafe void ReceiveEndPlay_Implementation(TEnumAsByte<EEndPlayReason> endPlayReason)
	{
		ControllerBase<SimpleNpcController>.Instance.Remove(this);
		if (this.RegisterLoopTimerId != null)
		{
			TimerSystem.Instance.Remove(this.RegisterLoopTimerId);
			this.RegisterLoopTimerId = null;
		}
		if (this.FlowLogic != null)
		{
			this.FlowLogic.Dispose();
			this.FlowLogic = null;
		}
		this.DA = null;
		this.DitherEffectControllerInternal = null;
		this.CachedComponents = null;
		if (GlobalData.IsPlayInEditor)
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.World;
			ELogAuthor author = ELogAuthor.CJH;
			string message = "销毁SimpleNpc";
			<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("Id", this.InstanceId);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("DeleteCount", ++TsSimpleNpc.DeleteCount);
			instance.Info(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
		}
	}

	// Token: 0x0601A97E RID: 108926 RVA: 0x007E3AA8 File Offset: 0x007E1CA8
	private void FindComponents()
	{
		if (this.CapsuleCollision == null || !this.CapsuleCollision.IsValid())
		{
			this.CapsuleCollision = (base.GetComponentByClass(UCapsuleComponent.StaticClass()) as UCapsuleComponent);
		}
		if (this.Mesh == null || !this.Mesh.IsValid())
		{
			this.Mesh = (base.GetComponentByClass(USkeletalMeshComponent.StaticClass()) as USkeletalMeshComponent);
		}
		if (this.CharRenderingComponent == null || !this.CharRenderingComponent.IsValid())
		{
			this.CharRenderingComponent = (base.GetComponentByClass(CharRenderingComponent.StaticClass()) as CharRenderingComponent);
		}
	}

	// Token: 0x0601A97F RID: 108927 RVA: 0x007E3B48 File Offset: 0x007E1D48
	[UFunction(EFunctionFlags.FUNC_BlueprintNativeEvent)]
	public unsafe virtual void LoadModel()
	{
		int num;
		IntPtr ufunctionPtrAndSizeChecked = UnrealReflectionUtils.GetUFunctionPtrAndSizeChecked(base.NativePtr, new FName("LoadModel"), out num);
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

	// Token: 0x0601A980 RID: 108928 RVA: 0x007E3BB8 File Offset: 0x007E1DB8
	protected void LoadModel_Implementation()
	{
		this.FindComponents();
		this.IsNotUnload = true;
		this.LoadModelByDA();
	}

	// Token: 0x0601A981 RID: 108929 RVA: 0x007E3BD0 File Offset: 0x007E1DD0
	[UFunction(EFunctionFlags.FUNC_BlueprintNativeEvent)]
	public unsafe virtual void DebugSetNpcDitherValue(float value)
	{
		int num;
		IntPtr ufunctionPtrAndSizeChecked = UnrealReflectionUtils.GetUFunctionPtrAndSizeChecked(base.NativePtr, new FName("DebugSetNpcDitherValue"), out num);
		byte* ptr = stackalloc byte[(UIntPtr)((num != 0) ? (num + 15) : 0)];
		TsSimpleNpc.__DebugSetNpcDitherValue_FunctionParams* ptr2 = null;
		if (num != 0)
		{
			ptr2 = ((TsSimpleNpc.__DebugSetNpcDitherValue_FunctionParams*)ptr + 15L / (long)sizeof(TsSimpleNpc.__DebugSetNpcDitherValue_FunctionParams) & -16L);
			UnrealReflectionUtils.InitializeStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
			ptr2->value = value;
		}
		UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ufunctionPtrAndSizeChecked, (void*)ptr2);
		if (num != 0)
		{
			UnrealReflectionUtils.DestroyStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
		}
	}

	// Token: 0x0601A982 RID: 108930 RVA: 0x007E3C46 File Offset: 0x007E1E46
	protected void DebugSetNpcDitherValue_Implementation(float value)
	{
		this.SetDitherEffect(value, ECharacterDitherType.Fight);
	}

	// Token: 0x0601A983 RID: 108931 RVA: 0x007E3C50 File Offset: 0x007E1E50
	[UFunction(EFunctionFlags.FUNC_BlueprintNativeEvent)]
	public unsafe virtual void SetDefaultCollision()
	{
		int num;
		IntPtr ufunctionPtrAndSizeChecked = UnrealReflectionUtils.GetUFunctionPtrAndSizeChecked(base.NativePtr, new FName("SetDefaultCollision"), out num);
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

	// Token: 0x0601A984 RID: 108932 RVA: 0x007E3CC0 File Offset: 0x007E1EC0
	protected void SetDefaultCollision_Implementation()
	{
		USkeletalMeshComponent mesh = this.Mesh;
		if (((mesh != null) ? mesh.SkeletalMesh : null) != null)
		{
			FBoxSphereBounds bounds = this.Mesh.SkeletalMesh.GetBounds();
			this.CapsuleCollision.CapsuleHalfHeight = bounds.BoxExtent.GetMax();
			this.CapsuleCollision.CapsuleRadius = 25f;
			return;
		}
		this.CapsuleCollision.CapsuleHalfHeight = 85f;
		this.CapsuleCollision.CapsuleRadius = 25f;
	}

	// Token: 0x0601A985 RID: 108933 RVA: 0x007E3D3C File Offset: 0x007E1F3C
	[UFunction(EFunctionFlags.FUNC_BlueprintNativeEvent)]
	public unsafe virtual void ResetMeshLocation()
	{
		int num;
		IntPtr ufunctionPtrAndSizeChecked = UnrealReflectionUtils.GetUFunctionPtrAndSizeChecked(base.NativePtr, new FName("ResetMeshLocation"), out num);
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

	// Token: 0x0601A986 RID: 108934 RVA: 0x007E3DAC File Offset: 0x007E1FAC
	protected void ResetMeshLocation_Implementation()
	{
		FHitResult fhitResult = new FHitResult();
		USceneComponent mesh = this.Mesh;
		FRotator frotator = new FRotator(0f, -90f, 0f);
		FVectorDouble fvectorDouble = new FVectorDouble(0.0, 0.0, (double)(-(double)this.CapsuleCollision.CapsuleHalfHeight));
		FVector fvector = Vector.OneVectorDouble;
		FTransformDouble ftransformDouble = new FTransformDouble(ref frotator, ref fvectorDouble, ref fvector);
		mesh.D_K2_SetRelativeTransform(ftransformDouble, false, ref fhitResult, false);
	}

	// Token: 0x0601A987 RID: 108935 RVA: 0x007E3E24 File Offset: 0x007E2024
	[UFunction(EFunctionFlags.FUNC_BlueprintNativeEvent)]
	public unsafe virtual void FindFloor()
	{
		int num;
		IntPtr ufunctionPtrAndSizeChecked = UnrealReflectionUtils.GetUFunctionPtrAndSizeChecked(base.NativePtr, new FName("FindFloor"), out num);
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

	// Token: 0x0601A988 RID: 108936 RVA: 0x007E3E94 File Offset: 0x007E2094
	protected void FindFloor_Implementation()
	{
		this.FindComponents();
		float scaledCapsuleHalfHeight = this.CapsuleCollision.GetScaledCapsuleHalfHeight();
		float scaledCapsuleRadius = this.CapsuleCollision.GetScaledCapsuleRadius();
		FVectorDouble fvectorDouble = base.D_K2_GetActorLocation();
		FVector fvector = new FVector((float)fvectorDouble.X, (float)fvectorDouble.Y, (float)fvectorDouble.Z - 500f - (scaledCapsuleHalfHeight - scaledCapsuleRadius));
		if (TsSimpleNpc.SphereTrace == null)
		{
			TsSimpleNpc.SphereTrace = new UTraceSphereElement();
			TsSimpleNpc.SphereTrace.bIsSingle = true;
			TsSimpleNpc.SphereTrace.bIgnoreSelf = true;
			TsSimpleNpc.SphereTrace.SetTraceTypeQuery(KuroTraceTypeQuery.IkGround);
		}
		UTraceSphereElement sphereTrace = TsSimpleNpc.SphereTrace;
		sphereTrace.WorldContextObject = this;
		sphereTrace.Radius = scaledCapsuleRadius;
		Singleton<TraceElementCommon>.Instance.SetStartLocation(sphereTrace, fvectorDouble);
		Singleton<TraceElementCommon>.Instance.SetEndLocation(sphereTrace, fvector);
		bool flag = Singleton<TraceElementCommon>.Instance.SphereTrace(sphereTrace, "SimpleNpc_FindFloor");
		UKuroHitResult hitResult = sphereTrace.HitResult;
		if (flag && hitResult.bBlockingHit)
		{
			FVectorDouble fvectorDouble2 = new FVectorDouble();
			Singleton<TraceElementCommon>.Instance.GetHitLocation(hitResult, 0, fvectorDouble2);
			fvectorDouble2.Z += (double)(scaledCapsuleHalfHeight - scaledCapsuleRadius);
			FHitResult fhitResult = new FHitResult();
			base.D_K2_SetActorLocation(fvectorDouble2, false, ref fhitResult, false);
		}
	}

	// Token: 0x0601A989 RID: 108937 RVA: 0x007E3FC0 File Offset: 0x007E21C0
	public bool LoadModelByDA()
	{
		if (this.CapsuleCollision == null || this.Mesh == null)
		{
			return false;
		}
		if (!ObjectUtils.SoftObjectPathIsValid(this.DA))
		{
			return false;
		}
		string text = this.DA.AssetPathName.ToString();
		if (string.IsNullOrEmpty(text))
		{
			return false;
		}
		Singleton<ResourceSystem>.Instance.LoadAsync<PD_NpcSetupData_C>(text, delegate([Nullable(2)] PD_NpcSetupData_C daConfig, string _)
		{
			if (this.IsNotUnload)
			{
				this.HandleLoadedDaConfig(daConfig, false);
			}
			this.SetTickEnabled(this.IsInLogicRangeInternal.Value);
			this.SetMainShadowEnabled(this.IsInLogicRangeInternal.Value);
		}, 100, "js_undefined");
		return true;
	}

	// Token: 0x0601A98A RID: 108938 RVA: 0x007E4034 File Offset: 0x007E2234
	private void HandleLoadedDaConfig(PD_NpcSetupData_C daConfig, bool isEditor = false)
	{
		if (daConfig == null)
		{
			Singleton<Log>.Instance.Error(ELogModule.Character, ELogAuthor.CJH, "[TsSimpleNpc.HandleLoadedDaConfig] DA资源类型错误", default(ReadOnlySpan<ValueTuple<string, object>>));
			return;
		}
		if (this.CapsuleCollision == null || this.Mesh == null)
		{
			return;
		}
		CombineMeshTool.LoadDaConfig(this, this.CapsuleCollision.GetRelativeTransform(), this.Mesh, daConfig);
		if (!isEditor)
		{
			this.CharRenderingComponent.UpdateNpcDitherComponent();
			ControllerBase<SimpleNpcController>.Instance.CheckNpcShowState(this, true, true);
		}
		if (!GlobalData.IsPlayInEditor)
		{
			this.CacheComponents();
			this.CloseSkeletalMeshShadow();
		}
		this.NeedResetCollision = true;
	}

	// Token: 0x0601A98B RID: 108939 RVA: 0x007E40BF File Offset: 0x007E22BF
	public void StartFlowLogic()
	{
		if (this.FlowLogic == null)
		{
			return;
		}
		this.FlowLogic.StartFlowLogic();
	}

	// Token: 0x0601A98C RID: 108940 RVA: 0x007E40D5 File Offset: 0x007E22D5
	public void SetDitherEffect(float dither, ECharacterDitherType ditherType = ECharacterDitherType.Temporary)
	{
		this.DitherEffectController.SetDitherEffect((double)dither, ditherType, true);
	}

	// Token: 0x0601A98D RID: 108941 RVA: 0x007E40E8 File Offset: 0x007E22E8
	[NullableContext(1)]
	[UFunction(EFunctionFlags.FUNC_BlueprintNativeEvent)]
	public unsafe virtual void ShowDialog(string text, float removeSeconds = -1f)
	{
		int num;
		IntPtr ufunctionPtrAndSizeChecked = UnrealReflectionUtils.GetUFunctionPtrAndSizeChecked(base.NativePtr, new FName("ShowDialog"), out num);
		byte* ptr = stackalloc byte[(UIntPtr)((num != 0) ? (num + 15) : 0)];
		TsSimpleNpc.__ShowDialog_FunctionParams* ptr2 = null;
		if (num != 0)
		{
			ptr2 = ((TsSimpleNpc.__ShowDialog_FunctionParams*)ptr + 15L / (long)sizeof(TsSimpleNpc.__ShowDialog_FunctionParams) & -16L);
			UnrealReflectionUtils.InitializeStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
			FString.CopyFrom((void*)(&ptr2->text), text);
			ptr2->removeSeconds = removeSeconds;
		}
		UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ufunctionPtrAndSizeChecked, (void*)ptr2);
		if (num != 0)
		{
			UnrealReflectionUtils.DestroyStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
		}
	}

	// Token: 0x0601A98E RID: 108942 RVA: 0x007E416C File Offset: 0x007E236C
	[NullableContext(1)]
	protected void ShowDialog_Implementation(string text, float removeSeconds = -1f)
	{
		if (this.FlowLogic == null)
		{
			return;
		}
		this.FlowLogic.AddHeadView().ContinueWith(delegate()
		{
			this.FlowLogic.ShowDialog(text, removeSeconds);
		}).Forget();
	}

	// Token: 0x0601A98F RID: 108943 RVA: 0x007E41C0 File Offset: 0x007E23C0
	[UFunction(EFunctionFlags.FUNC_BlueprintNativeEvent)]
	public unsafe virtual void HideDialog()
	{
		int num;
		IntPtr ufunctionPtrAndSizeChecked = UnrealReflectionUtils.GetUFunctionPtrAndSizeChecked(base.NativePtr, new FName("HideDialog"), out num);
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

	// Token: 0x0601A990 RID: 108944 RVA: 0x007E4230 File Offset: 0x007E2430
	protected void HideDialog_Implementation()
	{
		if (this.FlowLogic == null)
		{
			return;
		}
		this.FlowLogic.HideDialog();
	}

	// Token: 0x0601A991 RID: 108945 RVA: 0x007E4248 File Offset: 0x007E2448
	[NullableContext(1)]
	[UFunction(EFunctionFlags.FUNC_BlueprintNativeEvent)]
	public unsafe virtual bool TryPlayMontage(string montagePath)
	{
		int num;
		IntPtr ufunctionPtrAndSizeChecked = UnrealReflectionUtils.GetUFunctionPtrAndSizeChecked(base.NativePtr, new FName("TryPlayMontage"), out num);
		byte* ptr = stackalloc byte[(UIntPtr)((num != 0) ? (num + 15) : 0)];
		TsSimpleNpc.__TryPlayMontage_FunctionParams* ptr2 = null;
		if (num != 0)
		{
			ptr2 = ((TsSimpleNpc.__TryPlayMontage_FunctionParams*)ptr + 15L / (long)sizeof(TsSimpleNpc.__TryPlayMontage_FunctionParams) & -16L);
			UnrealReflectionUtils.InitializeStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
			FString.CopyFrom((void*)(&ptr2->montagePath), montagePath);
		}
		UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ufunctionPtrAndSizeChecked, (void*)ptr2);
		bool _Result = ptr2->__Result;
		if (num != 0)
		{
			UnrealReflectionUtils.DestroyStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
		}
		return _Result;
	}

	// Token: 0x0601A992 RID: 108946 RVA: 0x007E42CA File Offset: 0x007E24CA
	[NullableContext(1)]
	protected bool TryPlayMontage_Implementation(string montagePath)
	{
		return this.FlowLogic != null && this.FlowLogic.TryPlayMontage(montagePath);
	}

	// Token: 0x0601A993 RID: 108947 RVA: 0x007E42E4 File Offset: 0x007E24E4
	[UFunction(EFunctionFlags.FUNC_BlueprintNativeEvent)]
	public unsafe virtual void StopMontage()
	{
		int num;
		IntPtr ufunctionPtrAndSizeChecked = UnrealReflectionUtils.GetUFunctionPtrAndSizeChecked(base.NativePtr, new FName("StopMontage"), out num);
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

	// Token: 0x0601A994 RID: 108948 RVA: 0x007E4354 File Offset: 0x007E2554
	protected void StopMontage_Implementation()
	{
		if (this.FlowLogic == null)
		{
			return;
		}
		this.FlowLogic.StopMontage();
	}

	// Token: 0x0601A995 RID: 108949 RVA: 0x007E436A File Offset: 0x007E256A
	public void FilterFlowWorldState()
	{
		SimpleNpcFlowLogic flowLogic = this.FlowLogic;
		if (flowLogic == null)
		{
			return;
		}
		flowLogic.FilterFlowWorldState();
	}

	// Token: 0x170023FD RID: 9213
	// (get) Token: 0x0601A996 RID: 108950 RVA: 0x007E437C File Offset: 0x007E257C
	public bool IsHiding
	{
		get
		{
			return !this.IsNotUnload;
		}
	}

	// Token: 0x170023FE RID: 9214
	// (get) Token: 0x0601A997 RID: 108951 RVA: 0x007E4387 File Offset: 0x007E2587
	public FVectorDouble SelfLocation
	{
		get
		{
			return this.StartLocation.Value;
		}
	}

	// Token: 0x170023FF RID: 9215
	// (get) Token: 0x0601A998 RID: 108952 RVA: 0x007E4394 File Offset: 0x007E2594
	[Nullable(1)]
	public Vector SelfLocationProxy
	{
		[NullableContext(1)]
		get
		{
			return this.StartLocationProxy;
		}
	}

	// Token: 0x17002400 RID: 9216
	// (get) Token: 0x0601A999 RID: 108953 RVA: 0x007E439C File Offset: 0x007E259C
	public bool IsInLogicRange
	{
		get
		{
			return this.IsInLogicRangeInternal.Value;
		}
	}

	// Token: 0x0601A99A RID: 108954 RVA: 0x007E43AC File Offset: 0x007E25AC
	public void ChangeLogicRangeState(bool isInLogicRange)
	{
		bool? isInLogicRangeInternal = this.IsInLogicRangeInternal;
		if (!(isInLogicRangeInternal.GetValueOrDefault() == isInLogicRange & isInLogicRangeInternal != null))
		{
			if (isInLogicRange)
			{
				if (!this.IsModelLoadedInternal)
				{
					ControllerBase<SimpleNpcLoadController>.Instance.AddSimpleNpc(this);
					this.IsModelLoadedInternal = true;
				}
				this.SetLogicTickRunning(true);
			}
			else
			{
				this.SetLogicTickRunning(false);
			}
		}
		this.IsInLogicRangeInternal = new bool?(isInLogicRange);
	}

	// Token: 0x0601A99B RID: 108955 RVA: 0x007E4410 File Offset: 0x007E2610
	private void SetLogicTickRunning(bool isRun)
	{
		if (!isRun)
		{
			if (this.RegisterLoopTimerId != null)
			{
				if (TimerSystem.Instance.Has(this.RegisterLoopTimerId))
				{
					TimerSystem.Instance.Remove(this.RegisterLoopTimerId);
				}
				this.RegisterLoopTimerId = null;
				if (this.FlowLogic != null)
				{
					this.FlowLogic.ForceStopFlow();
				}
			}
			return;
		}
		if (this.RegisterLoopTimerId != null)
		{
			return;
		}
		this.LastGameSeconds = (float)Singleton<Time>.Instance.WorldTimeSeconds;
		this.RegisterLoopTimerId = TimerSystem.Instance.Forever(delegate(float _)
		{
			this.OnLogicTick();
		}, 100f, 1f, null, null, true);
	}

	// Token: 0x0601A99C RID: 108956 RVA: 0x007E44AC File Offset: 0x007E26AC
	private void OnLogicTick()
	{
		double worldTimeSeconds = Singleton<Time>.Instance.WorldTimeSeconds;
		double num = worldTimeSeconds - (double)this.LastGameSeconds;
		this.LastGameSeconds = (float)worldTimeSeconds;
		if (this.FlowLogic != null)
		{
			this.FlowLogic.Tick((float)num);
		}
	}

	// Token: 0x0601A99D RID: 108957 RVA: 0x007E44EB File Offset: 0x007E26EB
	private void CacheComponents()
	{
		this.CachedComponents = base.K2_GetComponentsByClass(UActorComponent.StaticClass());
	}

	// Token: 0x0601A99E RID: 108958 RVA: 0x007E4504 File Offset: 0x007E2704
	public void SetTickEnabled(bool value)
	{
		bool? isTickEnabled = this.IsTickEnabled;
		if (value == isTickEnabled.GetValueOrDefault() & isTickEnabled != null)
		{
			return;
		}
		this.IsTickEnabled = new bool?(value);
		TArray<UActorComponent> tarray = (this.CachedComponents != null) ? this.CachedComponents : base.K2_GetComponentsByClass(UActorComponent.StaticClass());
		int i = 0;
		int num = tarray.Num();
		while (i < num)
		{
			UActorComponent uactorComponent = tarray.Get(i);
			if (uactorComponent != null)
			{
				uactorComponent.SetComponentTickEnabled(value);
			}
			i++;
		}
	}

	// Token: 0x0601A99F RID: 108959 RVA: 0x007E4584 File Offset: 0x007E2784
	private void CloseSkeletalMeshShadow()
	{
		if (this.CachedComponents == null)
		{
			Singleton<Log>.Instance.Error(ELogModule.NPC, ELogAuthor.WY, "You must call CloseSkeletalMeshShadow after CacheComponents", default(ReadOnlySpan<ValueTuple<string, object>>));
			return;
		}
		int i = 0;
		int num = this.CachedComponents.Num();
		while (i < num)
		{
			UActorComponent uactorComponent = this.CachedComponents.Get(i);
			if (uactorComponent != null)
			{
				USkeletalMeshComponent uskeletalMeshComponent = uactorComponent as USkeletalMeshComponent;
				if (uskeletalMeshComponent != null)
				{
					uskeletalMeshComponent.SetCastShadow(false);
				}
			}
			i++;
		}
	}

	// Token: 0x0601A9A0 RID: 108960 RVA: 0x007E45F8 File Offset: 0x007E27F8
	public unsafe void SetMainShadowEnabled(bool value)
	{
		bool? isShowShadow = this.IsShowShadow;
		if (value == isShowShadow.GetValueOrDefault() & isShowShadow != null)
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.Entity;
			ELogAuthor author = ELogAuthor.WY;
			string message = "SetShadowEnabled, value === IsShowShadow";
			<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("Value", value);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("IsShowShadow", this.IsShowShadow);
			instance.Info(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
			return;
		}
		Log instance2 = Singleton<Log>.Instance;
		ELogModule module2 = ELogModule.Entity;
		ELogAuthor author2 = ELogAuthor.WY;
		string message2 = "SetShadowEnabled, value !== IsShowShadow";
		<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray2 = default(<>y__InlineArray2<ValueTuple<string, object>>);
		*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 0) = new ValueTuple<string, object>("Value", value);
		*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 1) = new ValueTuple<string, object>("IsShowShadow", this.IsShowShadow);
		instance2.Info(module2, author2, message2, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray2, 2));
		this.IsShowShadow = new bool?(value);
		TArray<UActorComponent> tarray = (this.CachedComponents != null) ? this.CachedComponents : base.K2_GetComponentsByClass(UActorComponent.StaticClass());
		if (tarray == null)
		{
			return;
		}
		int i = 0;
		int num = tarray.Num();
		while (i < num)
		{
			UActorComponent uactorComponent = tarray.Get(i);
			if (uactorComponent != null && uactorComponent is USkinnedMeshComponent && !(uactorComponent is USkeletalMeshComponent))
			{
				(uactorComponent as USkinnedMeshComponent).SetCastShadow(value);
				Log instance3 = Singleton<Log>.Instance;
				ELogModule module3 = ELogModule.Entity;
				ELogAuthor author3 = ELogAuthor.WY;
				string message3 = "SetShadowEnabled, SetCastShadow";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("Value", value);
				instance3.Info(module3, author3, message3, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			}
			i++;
		}
	}

	// Token: 0x17002401 RID: 9217
	// (get) Token: 0x0601A9A1 RID: 108961 RVA: 0x007E4789 File Offset: 0x007E2989
	public bool IsLodShow
	{
		get
		{
			return !Singleton<Info>.Instance.IsGameRunning() || Singleton<GameSettingsDeviceRender>.Instance.GameQualitySettingLevel >= (EGameQualitySettingLevel)this.LodLevel;
		}
	}

	// Token: 0x0601A9A2 RID: 108962 RVA: 0x007E47B0 File Offset: 0x007E29B0
	private void SetAnimUROParams()
	{
		FAnimUpdateRateParameters fanimUpdateRateParameters = new FAnimUpdateRateParameters();
		fanimUpdateRateParameters.bShouldUseLodMap = true;
		int num = this.Mesh.LODInfo.Num();
		fanimUpdateRateParameters.LODToFrameSkipMap.Empty(0);
		for (int i = 0; i < num; i++)
		{
			fanimUpdateRateParameters.LODToFrameSkipMap.Add(i, (i < 2) ? 0 : (i - 1));
		}
		fanimUpdateRateParameters.BaseNonRenderedUpdateRate = 8;
		fanimUpdateRateParameters.MaxEvalRateForInterpolation = num;
		EVisibilityBasedAnimTickOption visibilityBasedAnimTickOption = EVisibilityBasedAnimTickOption.OnlyTickPoseWhenRendered;
		FAnimUpdateRateParameters fanimUpdateRateParameters2 = fanimUpdateRateParameters;
		TArray<UActorComponent> tarray = base.K2_GetComponentsByClass(USkeletalMeshComponent.StaticClass());
		for (int j = 0; j < tarray.Num(); j++)
		{
			USkeletalMeshComponent uskeletalMeshComponent = tarray.Get(j) as USkeletalMeshComponent;
			uskeletalMeshComponent.bEnableUpdateRateOptimizations = true;
			uskeletalMeshComponent.SetAnimUpdateRateParameters(ref fanimUpdateRateParameters2);
			uskeletalMeshComponent.VisibilityBasedAnimTickOption = visibilityBasedAnimTickOption;
		}
	}

	// Token: 0x0601A9A3 RID: 108963 RVA: 0x007E486E File Offset: 0x007E2A6E
	public static void CreateStaticDefaultValue()
	{
		TsSimpleNpc.InstanceCount = 0;
		TsSimpleNpc.DeleteCount = 0;
		TsSimpleNpc.SphereTrace = null;
	}

	// Token: 0x0601A9A4 RID: 108964 RVA: 0x007E4882 File Offset: 0x007E2A82
	public static void ResetStaticDefaultValue()
	{
		TsSimpleNpc.InstanceCount = 0;
		TsSimpleNpc.DeleteCount = 0;
		TsSimpleNpc.SphereTrace = null;
	}

	// Token: 0x0601A9A5 RID: 108965 RVA: 0x007E4896 File Offset: 0x007E2A96
	public new static UClassStackOnlyPtr StaticClass()
	{
		if (TsSimpleNpc._ClassPtr == IntPtr.Zero)
		{
			UObjectGlobals.StaticLoadClass(null, "/Game/Aki/TypeScript/Game/NewWorld/Character/SimpleNpc/Blueprint/TsSimpleNpc.TsSimpleNpc_C");
		}
		return TsSimpleNpc._ClassPtr;
	}

	// Token: 0x0601A9A6 RID: 108966 RVA: 0x007E48BC File Offset: 0x007E2ABC
	public TsSimpleNpc() : this(BuiltinUtils.AllocNativeUObject(TsSimpleNpc.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
	{
	}

	// Token: 0x0601A9A7 RID: 108967 RVA: 0x007E48E4 File Offset: 0x007E2AE4
	[NullableContext(1)]
	public TsSimpleNpc(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(TsSimpleNpc.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
	{
	}

	// Token: 0x0601A9A8 RID: 108968 RVA: 0x007E4917 File Offset: 0x007E2B17
	protected TsSimpleNpc(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
	{
	}

	// Token: 0x0601A9A9 RID: 108969 RVA: 0x007E4920 File Offset: 0x007E2B20
	protected virtual void __CPPCALL_EditorInit_Implementation()
	{
		this.EditorInit_Implementation();
	}

	// Token: 0x0601A9AA RID: 108970 RVA: 0x007E4928 File Offset: 0x007E2B28
	[NullableContext(0)]
	protected unsafe virtual void __CPPCALL_EditorTick_Implementation(AKuroEffectActor.__EditorTick_FunctionParams* __Params)
	{
		this.EditorTick_Implementation(__Params->DeltaSeconds);
	}

	// Token: 0x0601A9AB RID: 108971 RVA: 0x007E4936 File Offset: 0x007E2B36
	protected virtual void __CPPCALL_ReceiveBeginPlay_Implementation()
	{
		this.ReceiveBeginPlay_Implementation();
	}

	// Token: 0x0601A9AC RID: 108972 RVA: 0x007E493E File Offset: 0x007E2B3E
	[NullableContext(0)]
	protected unsafe virtual void __CPPCALL_ReceiveEndPlay_Implementation(TsSimpleNpc.__ReceiveEndPlay_FunctionParams* __Params)
	{
		this.ReceiveEndPlay_Implementation(__Params->endPlayReason);
	}

	// Token: 0x0601A9AD RID: 108973 RVA: 0x007E494C File Offset: 0x007E2B4C
	protected virtual void __CPPCALL_LoadModel_Implementation()
	{
		this.LoadModel_Implementation();
	}

	// Token: 0x0601A9AE RID: 108974 RVA: 0x007E4954 File Offset: 0x007E2B54
	[NullableContext(0)]
	protected unsafe virtual void __CPPCALL_DebugSetNpcDitherValue_Implementation(TsSimpleNpc.__DebugSetNpcDitherValue_FunctionParams* __Params)
	{
		this.DebugSetNpcDitherValue_Implementation(__Params->value);
	}

	// Token: 0x0601A9AF RID: 108975 RVA: 0x007E4962 File Offset: 0x007E2B62
	protected virtual void __CPPCALL_SetDefaultCollision_Implementation()
	{
		this.SetDefaultCollision_Implementation();
	}

	// Token: 0x0601A9B0 RID: 108976 RVA: 0x007E496A File Offset: 0x007E2B6A
	protected virtual void __CPPCALL_ResetMeshLocation_Implementation()
	{
		this.ResetMeshLocation_Implementation();
	}

	// Token: 0x0601A9B1 RID: 108977 RVA: 0x007E4972 File Offset: 0x007E2B72
	protected virtual void __CPPCALL_FindFloor_Implementation()
	{
		this.FindFloor_Implementation();
	}

	// Token: 0x0601A9B2 RID: 108978 RVA: 0x007E497C File Offset: 0x007E2B7C
	[NullableContext(0)]
	protected unsafe virtual void __CPPCALL_ShowDialog_Implementation(TsSimpleNpc.__ShowDialog_FunctionParams* __Params)
	{
		string text = FString.ToString((void*)(&__Params->text));
		this.ShowDialog_Implementation(text, __Params->removeSeconds);
	}

	// Token: 0x0601A9B3 RID: 108979 RVA: 0x007E49A3 File Offset: 0x007E2BA3
	protected virtual void __CPPCALL_HideDialog_Implementation()
	{
		this.HideDialog_Implementation();
	}

	// Token: 0x0601A9B4 RID: 108980 RVA: 0x007E49AC File Offset: 0x007E2BAC
	[NullableContext(0)]
	protected unsafe virtual void __CPPCALL_TryPlayMontage_Implementation(TsSimpleNpc.__TryPlayMontage_FunctionParams* __Params)
	{
		string montagePath = FString.ToString((void*)(&__Params->montagePath));
		__Params->__Result = this.TryPlayMontage_Implementation(montagePath);
	}

	// Token: 0x0601A9B5 RID: 108981 RVA: 0x007E49D3 File Offset: 0x007E2BD3
	protected virtual void __CPPCALL_StopMontage_Implementation()
	{
		this.StopMontage_Implementation();
	}

	// Token: 0x0400D743 RID: 55107
	[Nullable(1)]
	private const string PROFILE_KEY = "SimpleNpc_FindFloor";

	// Token: 0x0400D744 RID: 55108
	private const float DEFAULT_HALF_HEIGHT = 85f;

	// Token: 0x0400D745 RID: 55109
	private const float DEFAULT_RADIUS = 25f;

	// Token: 0x0400D746 RID: 55110
	private const float DEFAULT_MESH_YAW = -90f;

	// Token: 0x0400D747 RID: 55111
	private const float FIND_FLOOR_RAY_LENGTH = 500f;

	// Token: 0x0400D748 RID: 55112
	private const float MIN_EDITOR_MOVE_CHANGED = 900f;

	// Token: 0x0400D749 RID: 55113
	private const int LOGIC_TICK_INTERVAL = 100;

	// Token: 0x0400D74A RID: 55114
	public double TempDistanceSquared;

	// Token: 0x0400D74B RID: 55115
	public float CurDither;

	// Token: 0x0400D74C RID: 55116
	public bool IsNotUnload;

	// Token: 0x0400D74D RID: 55117
	private SimpleNpcFlowLogic FlowLogic;

	// Token: 0x0400D74E RID: 55118
	private Vector TempLocation;

	// Token: 0x0400D74F RID: 55119
	private Vector CachedLocation;

	// Token: 0x0400D750 RID: 55120
	private UAnimInstance TempAnimInstance;

	// Token: 0x0400D751 RID: 55121
	private UAnimationAsset TempAnimAsset;

	// Token: 0x0400D752 RID: 55122
	private string TempDaPath;

	// Token: 0x0400D753 RID: 55123
	private bool NeedResetCollision;

	// Token: 0x0400D754 RID: 55124
	private bool IsDirty;

	// Token: 0x0400D755 RID: 55125
	private FVectorDouble? StartLocation;

	// Token: 0x0400D756 RID: 55126
	private Vector StartLocationProxy;

	// Token: 0x0400D757 RID: 55127
	private int InstanceId;

	// Token: 0x0400D758 RID: 55128
	private CharacterDitherEffectController DitherEffectControllerInternal;

	// Token: 0x0400D759 RID: 55129
	private bool? IsInLogicRangeInternal;

	// Token: 0x0400D75A RID: 55130
	private TimerHandle RegisterLoopTimerId;

	// Token: 0x0400D75B RID: 55131
	private float LastGameSeconds;

	// Token: 0x0400D75C RID: 55132
	private bool IsModelLoadedInternal;

	// Token: 0x0400D75D RID: 55133
	private static int InstanceCount;

	// Token: 0x0400D75E RID: 55134
	private static int DeleteCount;

	// Token: 0x0400D75F RID: 55135
	private static UTraceSphereElement SphereTrace;

	// Token: 0x0400D760 RID: 55136
	private bool? IsShowShadow;

	// Token: 0x0400D761 RID: 55137
	private bool? IsTickEnabled;

	// Token: 0x0400D762 RID: 55138
	[Nullable(new byte[]
	{
		2,
		1
	})]
	private TArray<UActorComponent> CachedComponents;

	// Token: 0x0400D763 RID: 55139
	[Nullable(1)]
	public new const string __ObjectPath = "/Game/Aki/TypeScript/Game/NewWorld/Character/SimpleNpc/Blueprint/TsSimpleNpc.TsSimpleNpc_C";

	// Token: 0x0400D764 RID: 55140
	private static IntPtr _ClassPtr;

	// Token: 0x0400D765 RID: 55141
	private static IntPtr _ClassDefaultObjectPtr;

	// Token: 0x0400D766 RID: 55142
	private static int __PropertyOffset_CapsuleCollision;

	// Token: 0x0400D767 RID: 55143
	private static int __PropertyOffset_Mesh;

	// Token: 0x0400D768 RID: 55144
	private static int __PropertyOffset_CharRenderingComponent;

	// Token: 0x0400D769 RID: 55145
	private static int __PropertyOffset_DA;

	// Token: 0x0400D76A RID: 55146
	private FSoftObjectPath _DA;

	// Token: 0x0400D76B RID: 55147
	private static int __PropertyOffset_DisappearOnSunny;

	// Token: 0x0400D76C RID: 55148
	private static int __PropertyOffset_DisappearOnCloudy;

	// Token: 0x0400D76D RID: 55149
	private static int __PropertyOffset_DisappearOnRainy;

	// Token: 0x0400D76E RID: 55150
	private static int __PropertyOffset_DisappearOnThunderRain;

	// Token: 0x0400D76F RID: 55151
	private static int __PropertyOffset_DisappearOnSnowy;

	// Token: 0x0400D770 RID: 55152
	private static int __PropertyOffset_LodLevel;

	// Token: 0x0400D771 RID: 55153
	private static int __PropertyOffset_DebugDitherValue;

	// Token: 0x02009413 RID: 37907
	[NullableContext(0)]
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 1)]
	protected new ref struct __ReceiveEndPlay_FunctionParams
	{
		// Token: 0x0403131C RID: 201500
		[FieldOffset(0)]
		public TEnumAsByte<EEndPlayReason> endPlayReason;
	}

	// Token: 0x02009414 RID: 37908
	[NullableContext(0)]
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 4)]
	protected ref struct __DebugSetNpcDitherValue_FunctionParams
	{
		// Token: 0x0403131D RID: 201501
		[FieldOffset(0)]
		public float value;
	}

	// Token: 0x02009415 RID: 37909
	[NullableContext(0)]
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 24)]
	protected ref struct __ShowDialog_FunctionParams
	{
		// Token: 0x0403131E RID: 201502
		[FieldOffset(0)]
		public FString text;

		// Token: 0x0403131F RID: 201503
		[FieldOffset(16)]
		public float removeSeconds;
	}

	// Token: 0x02009416 RID: 37910
	[NullableContext(0)]
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 24)]
	protected ref struct __TryPlayMontage_FunctionParams
	{
		// Token: 0x04031320 RID: 201504
		[FieldOffset(0)]
		public FString montagePath;

		// Token: 0x04031321 RID: 201505
		[FieldOffset(16)]
		public bool __Result;
	}
}
