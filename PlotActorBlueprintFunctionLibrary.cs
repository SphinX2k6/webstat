using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Service.Flags;
using UnrealEngine.Utils;

// Token: 0x0200297B RID: 10619
[UClass("/Game/Aki/TypeScript/Game/Module/Sequence/", EClassFlags.CLASS_None)]
[UnrealObjectPath("/Game/Aki/TypeScript/Game/Module/Sequence/PlotActorBlueprintFunctionLibrary.PlotActorBlueprintFunctionLibrary_C")]
public class PlotActorBlueprintFunctionLibrary : UBlueprintFunctionLibrary, IStaticVariableResetter, IUnrealUObject, IUnrealObject
{
	// Token: 0x0601519F RID: 86431 RVA: 0x005D6B07 File Offset: 0x005D4D07
	static PlotActorBlueprintFunctionLibrary()
	{
		StaticVariableRegister.RegisterAndExecute(new Action(PlotActorBlueprintFunctionLibrary.CreateStaticDefaultValue), new Action(PlotActorBlueprintFunctionLibrary.ResetStaticDefaultValue));
	}

	// Token: 0x060151A0 RID: 86432 RVA: 0x005D6B26 File Offset: 0x005D4D26
	[NullableContext(1)]
	[UFunction(EFunctionFlags.FUNC_None)]
	public static void SetI18nBillboardComponentSpriteById(UBillboardComponent sprite, string id)
	{
		I18nUtils.SetI18nBillboardComponentSpriteById(sprite, id);
	}

	// Token: 0x060151A1 RID: 86433 RVA: 0x005D6B2F File Offset: 0x005D4D2F
	[NullableContext(1)]
	[UFunction(EFunctionFlags.FUNC_None)]
	public static void PlayFromStartForActor(ALevelSequenceActor actor)
	{
		if (actor == null || !actor.IsValid())
		{
			return;
		}
		if (actor.SequencePlayer != null)
		{
			actor.SequencePlayer.Play();
		}
	}

	// Token: 0x060151A2 RID: 86434 RVA: 0x005D6B50 File Offset: 0x005D4D50
	[NullableContext(1)]
	[UFunction(EFunctionFlags.FUNC_None)]
	public static void StopForActor(ALevelSequenceActor actor)
	{
		if (actor == null || !actor.IsValid())
		{
			return;
		}
		ULevelSequencePlayer sequencePlayer = actor.SequencePlayer;
		if (sequencePlayer == null)
		{
			return;
		}
		sequencePlayer.Stop();
	}

	// Token: 0x060151A3 RID: 86435 RVA: 0x005D6B6E File Offset: 0x005D4D6E
	[NullableContext(1)]
	[UFunction(EFunctionFlags.FUNC_None)]
	public static void UiTextureAttachToActor(AActor target, string textureKey)
	{
		PlotActorBlueprintFunctionLibrary.UiAttachToActorImpAsync(target, textureKey).Forget();
	}

	// Token: 0x060151A4 RID: 86436 RVA: 0x005D6B7C File Offset: 0x005D4D7C
	[NullableContext(1)]
	[UFunction(EFunctionFlags.FUNC_None)]
	public static void TextNiagaraSetTextureAndLength(AActor target, string textureKey)
	{
		PlotActorBlueprintFunctionLibrary.TextSetTextureAndLengthToNiagara(target, textureKey);
	}

	// Token: 0x060151A5 RID: 86437 RVA: 0x005D6B85 File Offset: 0x005D4D85
	[NullableContext(1)]
	[UFunction(EFunctionFlags.FUNC_None)]
	public static string GetMediaNameByKey(string key)
	{
		return I18nUtils.GetI18nPlotAudioMediaName(key) ?? "";
	}

	// Token: 0x060151A6 RID: 86438 RVA: 0x005D6B98 File Offset: 0x005D4D98
	[NullableContext(2)]
	[UFunction(EFunctionFlags.FUNC_None)]
	public static void PostAudioEventAtActor([Nullable(1)] string eventName, string externalName, string mediaName, AActor target)
	{
		if (string.IsNullOrEmpty(eventName))
		{
			return;
		}
		int item;
		if (string.IsNullOrEmpty(externalName) || string.IsNullOrEmpty(mediaName))
		{
			item = Singleton<AudioSystem>.Instance.PostEvent(eventName, target, null);
		}
		else
		{
			item = Singleton<AudioSystem>.Instance.PostEvent(eventName, target, new PostEventArgs?(new PostEventArgs
			{
				ExternalSourceName = externalName,
				ExternalSourceMediaName = mediaName
			}));
		}
		PlotActorBlueprintFunctionLibrary.AudioHandleCache.Add(item);
	}

	// Token: 0x060151A7 RID: 86439 RVA: 0x005D6C10 File Offset: 0x005D4E10
	[UFunction(EFunctionFlags.FUNC_None)]
	public static void StopAllAudioByPostAudioEventAtActor()
	{
		foreach (int handle in PlotActorBlueprintFunctionLibrary.AudioHandleCache)
		{
			Singleton<AudioSystem>.Instance.ExecuteAction(handle, EAudioActionType.Stop, null);
		}
		PlotActorBlueprintFunctionLibrary.AudioHandleCache.Clear();
	}

	// Token: 0x060151A8 RID: 86440 RVA: 0x005D6C7C File Offset: 0x005D4E7C
	[NullableContext(1)]
	[UFunction(EFunctionFlags.FUNC_None)]
	public static string AddSuffixByGender(string baseContent, [Nullable(2)] string addedMaleString, [Nullable(2)] string addedFemaleString)
	{
		return baseContent + ((ModelBase<PlayerInfoModel>.Instance.GetPlayerGender() == EPlayerGender.Male) ? (addedMaleString ?? "") : (addedFemaleString ?? ""));
	}

	// Token: 0x060151A9 RID: 86441 RVA: 0x005D6CA7 File Offset: 0x005D4EA7
	[NullableContext(1)]
	[UFunction(EFunctionFlags.FUNC_None)]
	public static string AddPrefixByGender(string baseContent, [Nullable(2)] string addedMaleString, [Nullable(2)] string addedFemaleString)
	{
		return ((ModelBase<PlayerInfoModel>.Instance.GetPlayerGender() == EPlayerGender.Male) ? (addedMaleString ?? "") : (addedFemaleString ?? "")) + baseContent;
	}

	// Token: 0x060151AA RID: 86442 RVA: 0x005D6CD4 File Offset: 0x005D4ED4
	[NullableContext(1)]
	private static UniTask UiAttachToActorImpAsync(AActor target, string key)
	{
		PlotActorBlueprintFunctionLibrary.<UiAttachToActorImpAsync>d__12 <UiAttachToActorImpAsync>d__;
		<UiAttachToActorImpAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<UiAttachToActorImpAsync>d__.target = target;
		<UiAttachToActorImpAsync>d__.key = key;
		<UiAttachToActorImpAsync>d__.<>1__state = -1;
		<UiAttachToActorImpAsync>d__.<>t__builder.Start<PlotActorBlueprintFunctionLibrary.<UiAttachToActorImpAsync>d__12>(ref <UiAttachToActorImpAsync>d__);
		return <UiAttachToActorImpAsync>d__.<>t__builder.Task;
	}

	// Token: 0x060151AB RID: 86443 RVA: 0x005D6D20 File Offset: 0x005D4F20
	[NullableContext(1)]
	private static void TextSetTextureAndLengthToNiagara(AActor target, string key)
	{
		if (target != null)
		{
			UNiagaraComponent niagaraComp = target.GetComponentByClass(UNiagaraComponent.StaticClass()) as UNiagaraComponent;
			if (niagaraComp != null)
			{
				string i18nPathAtCurrentLanguage = I18nUtils.GetI18nPathAtCurrentLanguage(key);
				if (i18nPathAtCurrentLanguage != null)
				{
					Singleton<ResourceSystem>.Instance.LoadAsync<UTexture2D>(i18nPathAtCurrentLanguage, delegate([Nullable(2)] UTexture2D texture, string _)
					{
						if (texture == null)
						{
							Singleton<Log>.Instance.Error(ELogModule.Battle, ELogAuthor.LLX, "[LLX]加载贴图失败", default(ReadOnlySpan<ValueTuple<string, object>>));
							return;
						}
						niagaraComp.SetKuroNiagaraEmitterCustomTexture("TextTex", "Mask", texture);
						niagaraComp.SetNiagaraVariableFloat("TexSize", (float)(texture.Blueprint_GetSizeX() / texture.Blueprint_GetSizeY()));
					}, ResourceSystem.EResourceLoadPriority.Ui, "js_undefined");
				}
			}
		}
	}

	// Token: 0x060151AC RID: 86444 RVA: 0x005D6D82 File Offset: 0x005D4F82
	public static void CreateStaticDefaultValue()
	{
		PlotActorBlueprintFunctionLibrary.AudioHandleCache = new List<int>();
	}

	// Token: 0x060151AD RID: 86445 RVA: 0x005D6D8E File Offset: 0x005D4F8E
	public static void ResetStaticDefaultValue()
	{
		PlotActorBlueprintFunctionLibrary.AudioHandleCache = null;
	}

	// Token: 0x060151AE RID: 86446 RVA: 0x005D6D96 File Offset: 0x005D4F96
	public new static UClassStackOnlyPtr StaticClass()
	{
		if (PlotActorBlueprintFunctionLibrary._ClassPtr == IntPtr.Zero)
		{
			UObjectGlobals.StaticLoadClass(null, "/Game/Aki/TypeScript/Game/Module/Sequence/PlotActorBlueprintFunctionLibrary.PlotActorBlueprintFunctionLibrary_C");
		}
		return PlotActorBlueprintFunctionLibrary._ClassPtr;
	}

	// Token: 0x060151AF RID: 86447 RVA: 0x005D6DBC File Offset: 0x005D4FBC
	public PlotActorBlueprintFunctionLibrary() : this(BuiltinUtils.AllocNativeUObject(PlotActorBlueprintFunctionLibrary.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
	{
	}

	// Token: 0x060151B0 RID: 86448 RVA: 0x005D6DE4 File Offset: 0x005D4FE4
	[NullableContext(1)]
	public PlotActorBlueprintFunctionLibrary(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(PlotActorBlueprintFunctionLibrary.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
	{
	}

	// Token: 0x060151B1 RID: 86449 RVA: 0x005D6E17 File Offset: 0x005D5017
	protected PlotActorBlueprintFunctionLibrary(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
	{
	}

	// Token: 0x060151B2 RID: 86450 RVA: 0x005D6E20 File Offset: 0x005D5020
	protected unsafe static void __CPPCALL_SetI18nBillboardComponentSpriteById_Implementation(PlotActorBlueprintFunctionLibrary.__SetI18nBillboardComponentSpriteById_FunctionParams* __Params)
	{
		UBillboardComponent orCreateUObjectByNativePointer = BuiltinUtils.GetOrCreateUObjectByNativePointer<UBillboardComponent>(__Params->sprite);
		string id = FString.ToString((void*)(&__Params->id));
		PlotActorBlueprintFunctionLibrary.SetI18nBillboardComponentSpriteById(orCreateUObjectByNativePointer, id);
	}

	// Token: 0x060151B3 RID: 86451 RVA: 0x005D6E4B File Offset: 0x005D504B
	protected unsafe static void __CPPCALL_PlayFromStartForActor_Implementation(PlotActorBlueprintFunctionLibrary.__PlayFromStartForActor_FunctionParams* __Params)
	{
		PlotActorBlueprintFunctionLibrary.PlayFromStartForActor(BuiltinUtils.GetOrCreateUObjectByNativePointer<ALevelSequenceActor>(__Params->actor));
	}

	// Token: 0x060151B4 RID: 86452 RVA: 0x005D6E5D File Offset: 0x005D505D
	protected unsafe static void __CPPCALL_StopForActor_Implementation(PlotActorBlueprintFunctionLibrary.__StopForActor_FunctionParams* __Params)
	{
		PlotActorBlueprintFunctionLibrary.StopForActor(BuiltinUtils.GetOrCreateUObjectByNativePointer<ALevelSequenceActor>(__Params->actor));
	}

	// Token: 0x060151B5 RID: 86453 RVA: 0x005D6E70 File Offset: 0x005D5070
	protected unsafe static void __CPPCALL_UiTextureAttachToActor_Implementation(PlotActorBlueprintFunctionLibrary.__UiTextureAttachToActor_FunctionParams* __Params)
	{
		AActor orCreateUObjectByNativePointer = BuiltinUtils.GetOrCreateUObjectByNativePointer<AActor>(__Params->target);
		string textureKey = FString.ToString((void*)(&__Params->textureKey));
		PlotActorBlueprintFunctionLibrary.UiTextureAttachToActor(orCreateUObjectByNativePointer, textureKey);
	}

	// Token: 0x060151B6 RID: 86454 RVA: 0x005D6E9C File Offset: 0x005D509C
	protected unsafe static void __CPPCALL_TextNiagaraSetTextureAndLength_Implementation(PlotActorBlueprintFunctionLibrary.__TextNiagaraSetTextureAndLength_FunctionParams* __Params)
	{
		AActor orCreateUObjectByNativePointer = BuiltinUtils.GetOrCreateUObjectByNativePointer<AActor>(__Params->target);
		string textureKey = FString.ToString((void*)(&__Params->textureKey));
		PlotActorBlueprintFunctionLibrary.TextNiagaraSetTextureAndLength(orCreateUObjectByNativePointer, textureKey);
	}

	// Token: 0x060151B7 RID: 86455 RVA: 0x005D6EC8 File Offset: 0x005D50C8
	protected unsafe static void __CPPCALL_GetMediaNameByKey_Implementation(PlotActorBlueprintFunctionLibrary.__GetMediaNameByKey_FunctionParams* __Params)
	{
		string key = FString.ToString((void*)(&__Params->key));
		FString.CopyFrom((void*)(&__Params->__Result), PlotActorBlueprintFunctionLibrary.GetMediaNameByKey(key));
	}

	// Token: 0x060151B8 RID: 86456 RVA: 0x005D6EF4 File Offset: 0x005D50F4
	protected unsafe static void __CPPCALL_PostAudioEventAtActor_Implementation(PlotActorBlueprintFunctionLibrary.__PostAudioEventAtActor_FunctionParams* __Params)
	{
		string eventName = FString.ToString((void*)(&__Params->eventName));
		string externalName = FString.ToString((void*)(&__Params->externalName));
		string mediaName = FString.ToString((void*)(&__Params->mediaName));
		AActor orCreateUObjectByNativePointer = BuiltinUtils.GetOrCreateUObjectByNativePointer<AActor>(__Params->target);
		PlotActorBlueprintFunctionLibrary.PostAudioEventAtActor(eventName, externalName, mediaName, orCreateUObjectByNativePointer);
	}

	// Token: 0x060151B9 RID: 86457 RVA: 0x005D6F3B File Offset: 0x005D513B
	protected unsafe static void __CPPCALL_StopAllAudioByPostAudioEventAtActor_Implementation(PlotActorBlueprintFunctionLibrary.__StopAllAudioByPostAudioEventAtActor_FunctionParams* __Params)
	{
		PlotActorBlueprintFunctionLibrary.StopAllAudioByPostAudioEventAtActor();
	}

	// Token: 0x060151BA RID: 86458 RVA: 0x005D6F44 File Offset: 0x005D5144
	protected unsafe static void __CPPCALL_AddSuffixByGender_Implementation(PlotActorBlueprintFunctionLibrary.__AddSuffixByGender_FunctionParams* __Params)
	{
		string baseContent = FString.ToString((void*)(&__Params->baseContent));
		string addedMaleString = FString.ToString((void*)(&__Params->addedMaleString));
		string addedFemaleString = FString.ToString((void*)(&__Params->addedFemaleString));
		FString.CopyFrom((void*)(&__Params->__Result), PlotActorBlueprintFunctionLibrary.AddSuffixByGender(baseContent, addedMaleString, addedFemaleString));
	}

	// Token: 0x060151BB RID: 86459 RVA: 0x005D6F8C File Offset: 0x005D518C
	protected unsafe static void __CPPCALL_AddPrefixByGender_Implementation(PlotActorBlueprintFunctionLibrary.__AddPrefixByGender_FunctionParams* __Params)
	{
		string baseContent = FString.ToString((void*)(&__Params->baseContent));
		string addedMaleString = FString.ToString((void*)(&__Params->addedMaleString));
		string addedFemaleString = FString.ToString((void*)(&__Params->addedFemaleString));
		FString.CopyFrom((void*)(&__Params->__Result), PlotActorBlueprintFunctionLibrary.AddPrefixByGender(baseContent, addedMaleString, addedFemaleString));
	}

	// Token: 0x0400A27C RID: 41596
	[Nullable(2)]
	private static List<int> AudioHandleCache;

	// Token: 0x0400A27D RID: 41597
	[Nullable(1)]
	public new const string __ObjectPath = "/Game/Aki/TypeScript/Game/Module/Sequence/PlotActorBlueprintFunctionLibrary.PlotActorBlueprintFunctionLibrary_C";

	// Token: 0x0400A27E RID: 41598
	private static IntPtr _ClassPtr;

	// Token: 0x0400A27F RID: 41599
	private static IntPtr _ClassDefaultObjectPtr;

	// Token: 0x02008C86 RID: 35974
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 32)]
	protected ref struct __SetI18nBillboardComponentSpriteById_FunctionParams
	{
		// Token: 0x0402F4F5 RID: 193781
		[FieldOffset(0)]
		public IntPtr sprite;

		// Token: 0x0402F4F6 RID: 193782
		[FieldOffset(8)]
		public FString id;

		// Token: 0x0402F4F7 RID: 193783
		[FieldOffset(24)]
		public IntPtr __WorldContext;
	}

	// Token: 0x02008C87 RID: 35975
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 16)]
	protected ref struct __PlayFromStartForActor_FunctionParams
	{
		// Token: 0x0402F4F8 RID: 193784
		[FieldOffset(0)]
		public IntPtr actor;

		// Token: 0x0402F4F9 RID: 193785
		[FieldOffset(8)]
		public IntPtr __WorldContext;
	}

	// Token: 0x02008C88 RID: 35976
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 16)]
	protected ref struct __StopForActor_FunctionParams
	{
		// Token: 0x0402F4FA RID: 193786
		[FieldOffset(0)]
		public IntPtr actor;

		// Token: 0x0402F4FB RID: 193787
		[FieldOffset(8)]
		public IntPtr __WorldContext;
	}

	// Token: 0x02008C89 RID: 35977
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 32)]
	protected ref struct __UiTextureAttachToActor_FunctionParams
	{
		// Token: 0x0402F4FC RID: 193788
		[FieldOffset(0)]
		public IntPtr target;

		// Token: 0x0402F4FD RID: 193789
		[FieldOffset(8)]
		public FString textureKey;

		// Token: 0x0402F4FE RID: 193790
		[FieldOffset(24)]
		public IntPtr __WorldContext;
	}

	// Token: 0x02008C8A RID: 35978
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 32)]
	protected ref struct __TextNiagaraSetTextureAndLength_FunctionParams
	{
		// Token: 0x0402F4FF RID: 193791
		[FieldOffset(0)]
		public IntPtr target;

		// Token: 0x0402F500 RID: 193792
		[FieldOffset(8)]
		public FString textureKey;

		// Token: 0x0402F501 RID: 193793
		[FieldOffset(24)]
		public IntPtr __WorldContext;
	}

	// Token: 0x02008C8B RID: 35979
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 40)]
	protected ref struct __GetMediaNameByKey_FunctionParams
	{
		// Token: 0x0402F502 RID: 193794
		[FieldOffset(0)]
		public FString key;

		// Token: 0x0402F503 RID: 193795
		[FieldOffset(16)]
		public IntPtr __WorldContext;

		// Token: 0x0402F504 RID: 193796
		[FieldOffset(24)]
		public FString __Result;
	}

	// Token: 0x02008C8C RID: 35980
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 64)]
	protected ref struct __PostAudioEventAtActor_FunctionParams
	{
		// Token: 0x0402F505 RID: 193797
		[FieldOffset(0)]
		public FString eventName;

		// Token: 0x0402F506 RID: 193798
		[FieldOffset(16)]
		public FString externalName;

		// Token: 0x0402F507 RID: 193799
		[FieldOffset(32)]
		public FString mediaName;

		// Token: 0x0402F508 RID: 193800
		[FieldOffset(48)]
		public IntPtr target;

		// Token: 0x0402F509 RID: 193801
		[FieldOffset(56)]
		public IntPtr __WorldContext;
	}

	// Token: 0x02008C8D RID: 35981
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 8)]
	protected ref struct __StopAllAudioByPostAudioEventAtActor_FunctionParams
	{
		// Token: 0x0402F50A RID: 193802
		[FieldOffset(0)]
		public IntPtr __WorldContext;
	}

	// Token: 0x02008C8E RID: 35982
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 72)]
	protected ref struct __AddSuffixByGender_FunctionParams
	{
		// Token: 0x0402F50B RID: 193803
		[FieldOffset(0)]
		public FString baseContent;

		// Token: 0x0402F50C RID: 193804
		[FieldOffset(16)]
		public FString addedMaleString;

		// Token: 0x0402F50D RID: 193805
		[FieldOffset(32)]
		public FString addedFemaleString;

		// Token: 0x0402F50E RID: 193806
		[FieldOffset(48)]
		public IntPtr __WorldContext;

		// Token: 0x0402F50F RID: 193807
		[FieldOffset(56)]
		public FString __Result;
	}

	// Token: 0x02008C8F RID: 35983
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 72)]
	protected ref struct __AddPrefixByGender_FunctionParams
	{
		// Token: 0x0402F510 RID: 193808
		[FieldOffset(0)]
		public FString baseContent;

		// Token: 0x0402F511 RID: 193809
		[FieldOffset(16)]
		public FString addedMaleString;

		// Token: 0x0402F512 RID: 193810
		[FieldOffset(32)]
		public FString addedFemaleString;

		// Token: 0x0402F513 RID: 193811
		[FieldOffset(48)]
		public IntPtr __WorldContext;

		// Token: 0x0402F514 RID: 193812
		[FieldOffset(56)]
		public FString __Result;
	}
}
