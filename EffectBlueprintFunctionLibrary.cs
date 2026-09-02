using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Protocol;
using AkiClient.Game.Aki.Render.RuntimeBP.Character.MaterialController;
using AkiClient.Game.Aki.Render.RuntimeBP.ScreenEffect;
using CSharpScript.Core.Common;
using CSharpScript.Game.Render;
using CSharpScript.Game.Render.DebugDraw;
using CSharpScript.Game.Render.Effect.ScreenEffectSystem;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Service.Flags;
using UnrealEngine.Utils;

// Token: 0x0200341F RID: 13343
[UClass("/Game/Aki/TypeScript/Game/Render/Effect/", EClassFlags.CLASS_None)]
[UnrealObjectPath("/Game/Aki/TypeScript/Game/Render/Effect/EffectBlueprintFunctionLibrary.EffectBlueprintFunctionLibrary_C")]
public class EffectBlueprintFunctionLibrary : UBlueprintFunctionLibrary, IUnrealUObject, IUnrealObject
{
	// Token: 0x0601BD80 RID: 114048 RVA: 0x0084DC50 File Offset: 0x0084BE50
	[NullableContext(1)]
	[UFunction(EFunctionFlags.FUNC_None)]
	public static void SetMaterialControllerDataSync(int entityId, string materialDataPath, bool isGroup)
	{
		EffectBlueprintFunctionLibrary.<>c__DisplayClass0_0 CS$<>8__locals1 = new EffectBlueprintFunctionLibrary.<>c__DisplayClass0_0();
		CS$<>8__locals1.materialDataPath = materialDataPath;
		if (CS$<>8__locals1.materialDataPath.Length <= 0 || CS$<>8__locals1.materialDataPath == "None")
		{
			return;
		}
		EntityHandle entityById = ModelBase<CreatureModel>.Instance.GetEntityById(entityId);
		WorldEntity worldEntity = (entityById != null) ? entityById.Entity : null;
		EffectBlueprintFunctionLibrary.<>c__DisplayClass0_0 CS$<>8__locals2 = CS$<>8__locals1;
		CharRenderingComponent component;
		if (worldEntity == null)
		{
			component = null;
		}
		else
		{
			CharacterActorComponent component2 = worldEntity.GetComponent<CharacterActorComponent>();
			if (component2 == null)
			{
				component = null;
			}
			else
			{
				TsBaseCharacter actor = component2.Actor;
				component = ((actor != null) ? actor.CharRenderingComponent : null);
			}
		}
		CS$<>8__locals2.component = component;
		if (CS$<>8__locals1.component == null)
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.Battle;
			ELogAuthor author = ELogAuthor.ZQR;
			string message = "无法找到角色渲染组件";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("entityId", entityId);
			instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			return;
		}
		if (isGroup)
		{
			Singleton<ResourceSystem>.Instance.LoadAsync<PD_CharacterControllerDataGroup_C>(CS$<>8__locals1.materialDataPath, delegate([Nullable(2)] PD_CharacterControllerDataGroup_C asset, string _)
			{
				if (asset == null)
				{
					Log instance2 = Singleton<Log>.Instance;
					ELogModule module2 = ELogModule.Battle;
					ELogAuthor author2 = ELogAuthor.YZ;
					string message2 = "无法找到材质效果组";
					ValueTuple<string, object> valueTuple2 = new ValueTuple<string, object>("materialDataPath", CS$<>8__locals1.materialDataPath);
					instance2.Error(module2, author2, message2, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple2));
					return;
				}
				CharRenderingComponent component3 = CS$<>8__locals1.component;
				if (component3 == null)
				{
					return;
				}
				component3.AddMaterialControllerDataGroup(asset);
			}, 100, "js_undefined");
		}
		else
		{
			Singleton<ResourceSystem>.Instance.LoadAsync<PD_CharacterControllerData_C>(CS$<>8__locals1.materialDataPath, delegate([Nullable(2)] PD_CharacterControllerData_C asset, string _)
			{
				if (asset == null)
				{
					Log instance2 = Singleton<Log>.Instance;
					ELogModule module2 = ELogModule.Battle;
					ELogAuthor author2 = ELogAuthor.YZ;
					string message2 = "无法找到材质效果";
					ValueTuple<string, object> valueTuple2 = new ValueTuple<string, object>("materialDataPath", CS$<>8__locals1.materialDataPath);
					instance2.Error(module2, author2, message2, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple2));
					return;
				}
				CharRenderingComponent component3 = CS$<>8__locals1.component;
				if (component3 == null)
				{
					return;
				}
				component3.AddMaterialControllerData(asset);
			}, 100, "js_undefined");
		}
		MaterialPush materialPush = MaterialPush.Create();
		materialPush.MaterialInfo = new MaterialInfo();
		materialPush.MaterialInfo.AssetName = CS$<>8__locals1.materialDataPath;
		materialPush.MaterialInfo.IsGroup = isGroup;
		Singleton<CombatNet>.Instance.Send(EPushMessageId.MaterialPush, worldEntity, materialPush, null, null, null);
	}

	// Token: 0x0601BD81 RID: 114049 RVA: 0x0084DDAD File Offset: 0x0084BFAD
	[NullableContext(1)]
	[UFunction(EFunctionFlags.FUNC_None)]
	public static void RecycleEffect(EffectViewComponent view)
	{
	}

	// Token: 0x0601BD82 RID: 114050 RVA: 0x0084DDAF File Offset: 0x0084BFAF
	[UFunction(EFunctionFlags.FUNC_None)]
	public static float AddDebugLineFromPlayer(FVector location, FLinearColor color, float width)
	{
		return (float)DebugDrawManager.AddDebugLineFromPlayer(global::Vector.Create(location), color, width);
	}

	// Token: 0x0601BD83 RID: 114051 RVA: 0x0084DDC4 File Offset: 0x0084BFC4
	[UFunction(EFunctionFlags.FUNC_None)]
	public static void ClearDebugDraw()
	{
		DebugDrawManager.ClearDebugDraw();
	}

	// Token: 0x0601BD84 RID: 114052 RVA: 0x0084DDCB File Offset: 0x0084BFCB
	[NullableContext(1)]
	[UFunction(EFunctionFlags.FUNC_None)]
	public static bool ValidateKuroAnimNotify(UKuroAnimNotify asset)
	{
		return asset.K2_ValidateAssets();
	}

	// Token: 0x0601BD85 RID: 114053 RVA: 0x0084DDD3 File Offset: 0x0084BFD3
	[NullableContext(1)]
	[UFunction(EFunctionFlags.FUNC_None)]
	public static bool ValidateKuroAnimNotifyState(UKuroAnimNotifyState asset)
	{
		return asset.K2_ValidateAssets();
	}

	// Token: 0x0601BD86 RID: 114054 RVA: 0x0084DDDB File Offset: 0x0084BFDB
	[UFunction(EFunctionFlags.FUNC_None)]
	public static void SetVisualizeCharacterWaterEffectTrace(bool enable)
	{
		SceneCharacterInteraction.SetTraceDebug(enable);
	}

	// Token: 0x0601BD87 RID: 114055 RVA: 0x0084DDE3 File Offset: 0x0084BFE3
	[UFunction(EFunctionFlags.FUNC_None)]
	public static void SetEffectSpawnLogEnabled(bool enabled)
	{
		Singleton<EffectGlobal>.Instance.EnableSpawnLog = enabled;
	}

	// Token: 0x0601BD88 RID: 114056 RVA: 0x0084DDF0 File Offset: 0x0084BFF0
	[UFunction(EFunctionFlags.FUNC_None)]
	public static void BeginDebugDrawFoliageDetect(FLinearColor color, float width)
	{
		Singleton<FoliageClusteredEffectManager>.Instance.BeginDebugDraw(color, width);
	}

	// Token: 0x0601BD89 RID: 114057 RVA: 0x0084DDFE File Offset: 0x0084BFFE
	[UFunction(EFunctionFlags.FUNC_None)]
	public static void EndDebugDrawFoliageDetect()
	{
		Singleton<FoliageClusteredEffectManager>.Instance.EndDebugDraw();
	}

	// Token: 0x0601BD8A RID: 114058 RVA: 0x0084DE0A File Offset: 0x0084C00A
	[UFunction(EFunctionFlags.FUNC_None)]
	public static void RefreshFoliageDetectConfig()
	{
		Singleton<FoliageClusteredEffectManager>.Instance.CacheFromConfig();
	}

	// Token: 0x0601BD8B RID: 114059 RVA: 0x0084DE16 File Offset: 0x0084C016
	[UFunction(EFunctionFlags.FUNC_None)]
	public static void SetEffectInPoolEnabled(bool enable)
	{
		Singleton<EffectGlobal>.Instance.AllowEffectInPool = enable;
	}

	// Token: 0x0601BD8C RID: 114060 RVA: 0x0084DE23 File Offset: 0x0084C023
	[UFunction(EFunctionFlags.FUNC_None)]
	public static void SetEffectOutPoolEnabled(bool enable)
	{
		Singleton<EffectGlobal>.Instance.AllowEffectOutPool = enable;
	}

	// Token: 0x0601BD8D RID: 114061 RVA: 0x0084DE30 File Offset: 0x0084C030
	[UFunction(EFunctionFlags.FUNC_None)]
	public static void EnableSceneObjectWaterEffectShowDebugTrace(bool enable)
	{
		Singleton<EffectGlobal>.Instance.SceneObjectWaterEffectShowDebugTrace = enable;
	}

	// Token: 0x0601BD8E RID: 114062 RVA: 0x0084DE3D File Offset: 0x0084C03D
	[UFunction(EFunctionFlags.FUNC_None)]
	public static void SetTsWriteTimeToCollectionEnabled(bool enable)
	{
		if (Singleton<Info>.Instance.IsGameRunning())
		{
			Singleton<RenderDataManager>.Instance.SetWriteTime(enable);
		}
	}

	// Token: 0x0601BD8F RID: 114063 RVA: 0x0084DE56 File Offset: 0x0084C056
	[UFunction(EFunctionFlags.FUNC_None)]
	public static void EffectCgMode(bool enable)
	{
		Singleton<EffectGlobal>.Instance.CgMode = enable;
	}

	// Token: 0x0601BD90 RID: 114064 RVA: 0x0084DE63 File Offset: 0x0084C063
	[NullableContext(1)]
	[UFunction(EFunctionFlags.FUNC_None)]
	public static BP_ScreenEffectSystem_C GetScreenEffectSystem()
	{
		return ScreenEffectSystem.GetInstance();
	}

	// Token: 0x0601BD91 RID: 114065 RVA: 0x0084DE6C File Offset: 0x0084C06C
	[NullableContext(1)]
	[UFunction(EFunctionFlags.FUNC_None)]
	public unsafe static void ChangeMaterialTextures([Nullable(2)] AActor actor, string assetPath)
	{
		if (actor == null)
		{
			return;
		}
		Singleton<ResourceSystem>.Instance.LoadAsync<UKuroChangeMaterialsTextures>(assetPath, delegate([Nullable(2)] UKuroChangeMaterialsTextures asset, string _)
		{
			if (asset == null || !asset.IsValid())
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.RenderCharacter;
				ELogAuthor author = ELogAuthor.LSY;
				string message = "ChangeMaterialTextures失败，因为asset无效";
				<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("Path", assetPath);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("actor", actor);
				instance.Error(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
				return;
			}
			UKuroChangeSkeletalMaterialsComponent ukuroChangeSkeletalMaterialsComponent = actor.GetComponentByClass(UKuroChangeSkeletalMaterialsComponent.StaticClass()) as UKuroChangeSkeletalMaterialsComponent;
			if (ukuroChangeSkeletalMaterialsComponent == null)
			{
				AActor actor2 = actor;
				TSubclassOf<UActorComponent> @class = UKuroChangeSkeletalMaterialsComponent.StaticClass();
				bool bManualAttachment = false;
				FTransform ftransform = new FTransform();
				ukuroChangeSkeletalMaterialsComponent = (actor2.AddComponentByClass(@class, bManualAttachment, ftransform, false, default(FName)) as UKuroChangeSkeletalMaterialsComponent);
			}
			ukuroChangeSkeletalMaterialsComponent.ChangeMaterialsWithDataAsset(asset);
		}, 100, "js_undefined");
	}

	// Token: 0x0601BD92 RID: 114066 RVA: 0x0084DEBA File Offset: 0x0084C0BA
	public new static UClassStackOnlyPtr StaticClass()
	{
		if (EffectBlueprintFunctionLibrary._ClassPtr == IntPtr.Zero)
		{
			UObjectGlobals.StaticLoadClass(null, "/Game/Aki/TypeScript/Game/Render/Effect/EffectBlueprintFunctionLibrary.EffectBlueprintFunctionLibrary_C");
		}
		return EffectBlueprintFunctionLibrary._ClassPtr;
	}

	// Token: 0x0601BD93 RID: 114067 RVA: 0x0084DEE0 File Offset: 0x0084C0E0
	public EffectBlueprintFunctionLibrary() : this(BuiltinUtils.AllocNativeUObject(EffectBlueprintFunctionLibrary.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
	{
	}

	// Token: 0x0601BD94 RID: 114068 RVA: 0x0084DF08 File Offset: 0x0084C108
	[NullableContext(1)]
	public EffectBlueprintFunctionLibrary(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(EffectBlueprintFunctionLibrary.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
	{
	}

	// Token: 0x0601BD95 RID: 114069 RVA: 0x0084DF3B File Offset: 0x0084C13B
	protected EffectBlueprintFunctionLibrary(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
	{
	}

	// Token: 0x0601BD96 RID: 114070 RVA: 0x0084DF44 File Offset: 0x0084C144
	protected unsafe static void __CPPCALL_SetMaterialControllerDataSync_Implementation(EffectBlueprintFunctionLibrary.__SetMaterialControllerDataSync_FunctionParams* __Params)
	{
		string materialDataPath = FString.ToString((void*)(&__Params->materialDataPath));
		EffectBlueprintFunctionLibrary.SetMaterialControllerDataSync(__Params->entityId, materialDataPath, __Params->isGroup);
	}

	// Token: 0x0601BD97 RID: 114071 RVA: 0x0084DF70 File Offset: 0x0084C170
	protected unsafe static void __CPPCALL_RecycleEffect_Implementation(EffectBlueprintFunctionLibrary.__RecycleEffect_FunctionParams* __Params)
	{
		EffectBlueprintFunctionLibrary.RecycleEffect(BuiltinUtils.GetOrCreateUObjectByNativePointer<EffectViewComponent>(__Params->view));
	}

	// Token: 0x0601BD98 RID: 114072 RVA: 0x0084DF82 File Offset: 0x0084C182
	protected unsafe static void __CPPCALL_AddDebugLineFromPlayer_Implementation(EffectBlueprintFunctionLibrary.__AddDebugLineFromPlayer_FunctionParams* __Params)
	{
		__Params->__Result = EffectBlueprintFunctionLibrary.AddDebugLineFromPlayer(__Params->location, __Params->color, __Params->width);
	}

	// Token: 0x0601BD99 RID: 114073 RVA: 0x0084DFA1 File Offset: 0x0084C1A1
	protected unsafe static void __CPPCALL_ClearDebugDraw_Implementation(EffectBlueprintFunctionLibrary.__ClearDebugDraw_FunctionParams* __Params)
	{
		EffectBlueprintFunctionLibrary.ClearDebugDraw();
	}

	// Token: 0x0601BD9A RID: 114074 RVA: 0x0084DFA8 File Offset: 0x0084C1A8
	protected unsafe static void __CPPCALL_ValidateKuroAnimNotify_Implementation(EffectBlueprintFunctionLibrary.__ValidateKuroAnimNotify_FunctionParams* __Params)
	{
		UKuroAnimNotify orCreateUObjectByNativePointer = BuiltinUtils.GetOrCreateUObjectByNativePointer<UKuroAnimNotify>(__Params->asset);
		__Params->__Result = EffectBlueprintFunctionLibrary.ValidateKuroAnimNotify(orCreateUObjectByNativePointer);
	}

	// Token: 0x0601BD9B RID: 114075 RVA: 0x0084DFD0 File Offset: 0x0084C1D0
	protected unsafe static void __CPPCALL_ValidateKuroAnimNotifyState_Implementation(EffectBlueprintFunctionLibrary.__ValidateKuroAnimNotifyState_FunctionParams* __Params)
	{
		UKuroAnimNotifyState orCreateUObjectByNativePointer = BuiltinUtils.GetOrCreateUObjectByNativePointer<UKuroAnimNotifyState>(__Params->asset);
		__Params->__Result = EffectBlueprintFunctionLibrary.ValidateKuroAnimNotifyState(orCreateUObjectByNativePointer);
	}

	// Token: 0x0601BD9C RID: 114076 RVA: 0x0084DFF5 File Offset: 0x0084C1F5
	protected unsafe static void __CPPCALL_SetVisualizeCharacterWaterEffectTrace_Implementation(EffectBlueprintFunctionLibrary.__SetVisualizeCharacterWaterEffectTrace_FunctionParams* __Params)
	{
		EffectBlueprintFunctionLibrary.SetVisualizeCharacterWaterEffectTrace(__Params->enable);
	}

	// Token: 0x0601BD9D RID: 114077 RVA: 0x0084E002 File Offset: 0x0084C202
	protected unsafe static void __CPPCALL_SetEffectSpawnLogEnabled_Implementation(EffectBlueprintFunctionLibrary.__SetEffectSpawnLogEnabled_FunctionParams* __Params)
	{
		EffectBlueprintFunctionLibrary.SetEffectSpawnLogEnabled(__Params->enabled);
	}

	// Token: 0x0601BD9E RID: 114078 RVA: 0x0084E00F File Offset: 0x0084C20F
	protected unsafe static void __CPPCALL_BeginDebugDrawFoliageDetect_Implementation(EffectBlueprintFunctionLibrary.__BeginDebugDrawFoliageDetect_FunctionParams* __Params)
	{
		EffectBlueprintFunctionLibrary.BeginDebugDrawFoliageDetect(__Params->color, __Params->width);
	}

	// Token: 0x0601BD9F RID: 114079 RVA: 0x0084E022 File Offset: 0x0084C222
	protected unsafe static void __CPPCALL_EndDebugDrawFoliageDetect_Implementation(EffectBlueprintFunctionLibrary.__EndDebugDrawFoliageDetect_FunctionParams* __Params)
	{
		EffectBlueprintFunctionLibrary.EndDebugDrawFoliageDetect();
	}

	// Token: 0x0601BDA0 RID: 114080 RVA: 0x0084E029 File Offset: 0x0084C229
	protected unsafe static void __CPPCALL_RefreshFoliageDetectConfig_Implementation(EffectBlueprintFunctionLibrary.__RefreshFoliageDetectConfig_FunctionParams* __Params)
	{
		EffectBlueprintFunctionLibrary.RefreshFoliageDetectConfig();
	}

	// Token: 0x0601BDA1 RID: 114081 RVA: 0x0084E030 File Offset: 0x0084C230
	protected unsafe static void __CPPCALL_SetEffectInPoolEnabled_Implementation(EffectBlueprintFunctionLibrary.__SetEffectInPoolEnabled_FunctionParams* __Params)
	{
		EffectBlueprintFunctionLibrary.SetEffectInPoolEnabled(__Params->enable);
	}

	// Token: 0x0601BDA2 RID: 114082 RVA: 0x0084E03D File Offset: 0x0084C23D
	protected unsafe static void __CPPCALL_SetEffectOutPoolEnabled_Implementation(EffectBlueprintFunctionLibrary.__SetEffectOutPoolEnabled_FunctionParams* __Params)
	{
		EffectBlueprintFunctionLibrary.SetEffectOutPoolEnabled(__Params->enable);
	}

	// Token: 0x0601BDA3 RID: 114083 RVA: 0x0084E04A File Offset: 0x0084C24A
	protected unsafe static void __CPPCALL_EnableSceneObjectWaterEffectShowDebugTrace_Implementation(EffectBlueprintFunctionLibrary.__EnableSceneObjectWaterEffectShowDebugTrace_FunctionParams* __Params)
	{
		EffectBlueprintFunctionLibrary.EnableSceneObjectWaterEffectShowDebugTrace(__Params->enable);
	}

	// Token: 0x0601BDA4 RID: 114084 RVA: 0x0084E057 File Offset: 0x0084C257
	protected unsafe static void __CPPCALL_SetTsWriteTimeToCollectionEnabled_Implementation(EffectBlueprintFunctionLibrary.__SetTsWriteTimeToCollectionEnabled_FunctionParams* __Params)
	{
		EffectBlueprintFunctionLibrary.SetTsWriteTimeToCollectionEnabled(__Params->enable);
	}

	// Token: 0x0601BDA5 RID: 114085 RVA: 0x0084E064 File Offset: 0x0084C264
	protected unsafe static void __CPPCALL_EffectCgMode_Implementation(EffectBlueprintFunctionLibrary.__EffectCgMode_FunctionParams* __Params)
	{
		EffectBlueprintFunctionLibrary.EffectCgMode(__Params->enable);
	}

	// Token: 0x0601BDA6 RID: 114086 RVA: 0x0084E071 File Offset: 0x0084C271
	protected unsafe static void __CPPCALL_GetScreenEffectSystem_Implementation(EffectBlueprintFunctionLibrary.__GetScreenEffectSystem_FunctionParams* __Params)
	{
		ref IntPtr ptr = ref *(&__Params->__Result);
		BP_ScreenEffectSystem_C screenEffectSystem = EffectBlueprintFunctionLibrary.GetScreenEffectSystem();
		ptr = ((screenEffectSystem != null) ? screenEffectSystem.NativePtr : ((IntPtr)0));
	}

	// Token: 0x0601BDA7 RID: 114087 RVA: 0x0084E090 File Offset: 0x0084C290
	protected unsafe static void __CPPCALL_ChangeMaterialTextures_Implementation(EffectBlueprintFunctionLibrary.__ChangeMaterialTextures_FunctionParams* __Params)
	{
		AActor orCreateUObjectByNativePointer = BuiltinUtils.GetOrCreateUObjectByNativePointer<AActor>(__Params->actor);
		string assetPath = FString.ToString((void*)(&__Params->assetPath));
		EffectBlueprintFunctionLibrary.ChangeMaterialTextures(orCreateUObjectByNativePointer, assetPath);
	}

	// Token: 0x0400E0EA RID: 57578
	[Nullable(1)]
	public new const string __ObjectPath = "/Game/Aki/TypeScript/Game/Render/Effect/EffectBlueprintFunctionLibrary.EffectBlueprintFunctionLibrary_C";

	// Token: 0x0400E0EB RID: 57579
	private static IntPtr _ClassPtr;

	// Token: 0x0400E0EC RID: 57580
	private static IntPtr _ClassDefaultObjectPtr;

	// Token: 0x020094D5 RID: 38101
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 40)]
	protected ref struct __SetMaterialControllerDataSync_FunctionParams
	{
		// Token: 0x040314BF RID: 201919
		[FieldOffset(0)]
		public int entityId;

		// Token: 0x040314C0 RID: 201920
		[FieldOffset(8)]
		public FString materialDataPath;

		// Token: 0x040314C1 RID: 201921
		[FieldOffset(24)]
		public bool isGroup;

		// Token: 0x040314C2 RID: 201922
		[FieldOffset(32)]
		public IntPtr __WorldContext;
	}

	// Token: 0x020094D6 RID: 38102
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 16)]
	protected ref struct __RecycleEffect_FunctionParams
	{
		// Token: 0x040314C3 RID: 201923
		[FieldOffset(0)]
		public IntPtr view;

		// Token: 0x040314C4 RID: 201924
		[FieldOffset(8)]
		public IntPtr __WorldContext;
	}

	// Token: 0x020094D7 RID: 38103
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 48)]
	protected ref struct __AddDebugLineFromPlayer_FunctionParams
	{
		// Token: 0x040314C5 RID: 201925
		[FieldOffset(0)]
		public FVector location;

		// Token: 0x040314C6 RID: 201926
		[FieldOffset(12)]
		public FLinearColor color;

		// Token: 0x040314C7 RID: 201927
		[FieldOffset(28)]
		public float width;

		// Token: 0x040314C8 RID: 201928
		[FieldOffset(32)]
		public IntPtr __WorldContext;

		// Token: 0x040314C9 RID: 201929
		[FieldOffset(40)]
		public float __Result;
	}

	// Token: 0x020094D8 RID: 38104
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 8)]
	protected ref struct __ClearDebugDraw_FunctionParams
	{
		// Token: 0x040314CA RID: 201930
		[FieldOffset(0)]
		public IntPtr __WorldContext;
	}

	// Token: 0x020094D9 RID: 38105
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 24)]
	protected ref struct __ValidateKuroAnimNotify_FunctionParams
	{
		// Token: 0x040314CB RID: 201931
		[FieldOffset(0)]
		public IntPtr asset;

		// Token: 0x040314CC RID: 201932
		[FieldOffset(8)]
		public IntPtr __WorldContext;

		// Token: 0x040314CD RID: 201933
		[FieldOffset(16)]
		public bool __Result;
	}

	// Token: 0x020094DA RID: 38106
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 24)]
	protected ref struct __ValidateKuroAnimNotifyState_FunctionParams
	{
		// Token: 0x040314CE RID: 201934
		[FieldOffset(0)]
		public IntPtr asset;

		// Token: 0x040314CF RID: 201935
		[FieldOffset(8)]
		public IntPtr __WorldContext;

		// Token: 0x040314D0 RID: 201936
		[FieldOffset(16)]
		public bool __Result;
	}

	// Token: 0x020094DB RID: 38107
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 16)]
	protected ref struct __SetVisualizeCharacterWaterEffectTrace_FunctionParams
	{
		// Token: 0x040314D1 RID: 201937
		[FieldOffset(0)]
		public bool enable;

		// Token: 0x040314D2 RID: 201938
		[FieldOffset(8)]
		public IntPtr __WorldContext;
	}

	// Token: 0x020094DC RID: 38108
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 16)]
	protected ref struct __SetEffectSpawnLogEnabled_FunctionParams
	{
		// Token: 0x040314D3 RID: 201939
		[FieldOffset(0)]
		public bool enabled;

		// Token: 0x040314D4 RID: 201940
		[FieldOffset(8)]
		public IntPtr __WorldContext;
	}

	// Token: 0x020094DD RID: 38109
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 32)]
	protected ref struct __BeginDebugDrawFoliageDetect_FunctionParams
	{
		// Token: 0x040314D5 RID: 201941
		[FieldOffset(0)]
		public FLinearColor color;

		// Token: 0x040314D6 RID: 201942
		[FieldOffset(16)]
		public float width;

		// Token: 0x040314D7 RID: 201943
		[FieldOffset(24)]
		public IntPtr __WorldContext;
	}

	// Token: 0x020094DE RID: 38110
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 8)]
	protected ref struct __EndDebugDrawFoliageDetect_FunctionParams
	{
		// Token: 0x040314D8 RID: 201944
		[FieldOffset(0)]
		public IntPtr __WorldContext;
	}

	// Token: 0x020094DF RID: 38111
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 8)]
	protected ref struct __RefreshFoliageDetectConfig_FunctionParams
	{
		// Token: 0x040314D9 RID: 201945
		[FieldOffset(0)]
		public IntPtr __WorldContext;
	}

	// Token: 0x020094E0 RID: 38112
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 16)]
	protected ref struct __SetEffectInPoolEnabled_FunctionParams
	{
		// Token: 0x040314DA RID: 201946
		[FieldOffset(0)]
		public bool enable;

		// Token: 0x040314DB RID: 201947
		[FieldOffset(8)]
		public IntPtr __WorldContext;
	}

	// Token: 0x020094E1 RID: 38113
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 16)]
	protected ref struct __SetEffectOutPoolEnabled_FunctionParams
	{
		// Token: 0x040314DC RID: 201948
		[FieldOffset(0)]
		public bool enable;

		// Token: 0x040314DD RID: 201949
		[FieldOffset(8)]
		public IntPtr __WorldContext;
	}

	// Token: 0x020094E2 RID: 38114
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 16)]
	protected ref struct __EnableSceneObjectWaterEffectShowDebugTrace_FunctionParams
	{
		// Token: 0x040314DE RID: 201950
		[FieldOffset(0)]
		public bool enable;

		// Token: 0x040314DF RID: 201951
		[FieldOffset(8)]
		public IntPtr __WorldContext;
	}

	// Token: 0x020094E3 RID: 38115
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 16)]
	protected ref struct __SetTsWriteTimeToCollectionEnabled_FunctionParams
	{
		// Token: 0x040314E0 RID: 201952
		[FieldOffset(0)]
		public bool enable;

		// Token: 0x040314E1 RID: 201953
		[FieldOffset(8)]
		public IntPtr __WorldContext;
	}

	// Token: 0x020094E4 RID: 38116
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 16)]
	protected ref struct __EffectCgMode_FunctionParams
	{
		// Token: 0x040314E2 RID: 201954
		[FieldOffset(0)]
		public bool enable;

		// Token: 0x040314E3 RID: 201955
		[FieldOffset(8)]
		public IntPtr __WorldContext;
	}

	// Token: 0x020094E5 RID: 38117
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 16)]
	protected ref struct __GetScreenEffectSystem_FunctionParams
	{
		// Token: 0x040314E4 RID: 201956
		[FieldOffset(0)]
		public IntPtr __WorldContext;

		// Token: 0x040314E5 RID: 201957
		[FieldOffset(8)]
		public IntPtr __Result;
	}

	// Token: 0x020094E6 RID: 38118
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 32)]
	protected ref struct __ChangeMaterialTextures_FunctionParams
	{
		// Token: 0x040314E6 RID: 201958
		[FieldOffset(0)]
		public IntPtr actor;

		// Token: 0x040314E7 RID: 201959
		[FieldOffset(8)]
		public FString assetPath;

		// Token: 0x040314E8 RID: 201960
		[FieldOffset(24)]
		public IntPtr __WorldContext;
	}
}
