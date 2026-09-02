using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Launcher.Define;
using CSharpScript.Launcher.Platform;
using CSharpScript.Launcher.Ui.Splash;
using CSharpScript.Launcher.Update;
using CSharpScript.Launcher.Util;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;
using UnrealEngine.Extension;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Service.Flags;
using UnrealEngine.Utils;

// Token: 0x020034E5 RID: 13541
[UClass("/Game/Aki/TypeScript/Launcher/", EClassFlags.CLASS_None)]
[UnrealObjectPath("/Game/Aki/TypeScript/Launcher/TsSplash.TsSplash_C")]
public class TsSplash : UObject, IStaticVariableResetter, IUnrealUObject, IUnrealObject
{
	// Token: 0x0601C9E1 RID: 117217 RVA: 0x00895F3D File Offset: 0x0089413D
	static TsSplash()
	{
		StaticVariableRegister.RegisterAndExecute(new Action(TsSplash.CreateStaticDefaultValue), new Action(TsSplash.ResetStaticDefaultValue));
	}

	// Token: 0x0601C9E2 RID: 117218 RVA: 0x00895F5C File Offset: 0x0089415C
	public static void CreateStaticDefaultValue()
	{
		TsSplash.CurrentPhase = SplashPhase.SplashPhaseOne;
		TsSplash.WorldContext = null;
		TsSplash.KuroSplashVideo = null;
	}

	// Token: 0x0601C9E3 RID: 117219 RVA: 0x00895F70 File Offset: 0x00894170
	public static void ResetStaticDefaultValue()
	{
		TsSplash.CurrentPhase = SplashPhase.SplashPhaseOne;
		TsSplash.WorldContext = null;
		TsSplash.KuroSplashVideo = null;
	}

	// Token: 0x0601C9E4 RID: 117220 RVA: 0x00895F84 File Offset: 0x00894184
	[NullableContext(1)]
	[UFunction(EFunctionFlags.FUNC_None)]
	public void Init(UObject worldContext)
	{
		if (UKismetSystemLibrary.GetCommandLine().Contains("-SkipSplash"))
		{
			UGameplayStatics.OpenLevel(worldContext, new FName("/Game/Aki/Map/Launch/Bootstrap"), true, "");
			return;
		}
		TsSplash.WorldContext = worldContext;
		TsSplash.DoInit(worldContext);
		worldContext.GetWorld().AuthorityGameMode.bUseSeamlessTravel = true;
		this.ShowSplashView();
	}

	// Token: 0x0601C9E5 RID: 117221 RVA: 0x00895FDC File Offset: 0x008941DC
	[UFunction(EFunctionFlags.FUNC_None)]
	public float GetDelay()
	{
		return 0f;
	}

	// Token: 0x0601C9E6 RID: 117222 RVA: 0x00895FE4 File Offset: 0x008941E4
	[UFunction(EFunctionFlags.FUNC_None)]
	private void ChangeToPhaseOne()
	{
		if (!SplashRegionBlockLib.ShouldBlockPhaseOne())
		{
			TsSplash.CurrentPhase = SplashPhase.SplashPhaseOne;
			TsSplash.KuroSplashVideo.PlayAnimationLogo(delegate
			{
				if (Singleton<LauncherLanguageLib>.Instance.GetPackageLanguage() == "ko")
				{
					this.ChangeToPhaseSpecial();
					return;
				}
				this.ChangeToPhaseThree();
			});
			return;
		}
		if (Singleton<LauncherLanguageLib>.Instance.GetPackageLanguage() == "ko")
		{
			this.ChangeToPhaseSpecial();
			return;
		}
		this.ChangeToPhaseThree();
	}

	// Token: 0x0601C9E7 RID: 117223 RVA: 0x00896038 File Offset: 0x00894238
	[UFunction(EFunctionFlags.FUNC_None)]
	private void ChangeToPhaseSpecial()
	{
		TsSplash.CurrentPhase = SplashPhase.SplashPhaseSpecial;
		TsSplash.KuroSplashVideo.PlayPreventAddictionAnimation(new Action(this.ChangeToPhaseThree));
	}

	// Token: 0x0601C9E8 RID: 117224 RVA: 0x00896056 File Offset: 0x00894256
	[UFunction(EFunctionFlags.FUNC_None)]
	private void ChangeToPhaseThree()
	{
		TsSplash.CurrentPhase = SplashPhase.SplashPhaseThree;
		TsSplash.KuroSplashVideo.PlayCautionAnimation(new Action(this.ChangeScene));
	}

	// Token: 0x0601C9E9 RID: 117225 RVA: 0x00896074 File Offset: 0x00894274
	[UFunction(EFunctionFlags.FUNC_None)]
	public void ShowSplashView()
	{
		TsSplash.KuroSplashVideo = new SplashUiView();
		this.<ShowSplashView>g__InitAndPrepareAsync|11_0();
	}

	// Token: 0x0601C9EA RID: 117226 RVA: 0x00896087 File Offset: 0x00894287
	[UFunction(EFunctionFlags.FUNC_None)]
	public void ChangeScene()
	{
		TsSplash.KuroSplashVideo.StopCurrentAnimation();
		TsSplash.KuroSplashVideo.Destroy();
		UGameplayStatics.OpenLevel(TsSplash.WorldContext, new FName("/Game/Aki/Map/Launch/Bootstrap"), true, "");
	}

	// Token: 0x0601C9EB RID: 117227 RVA: 0x008960B8 File Offset: 0x008942B8
	[NullableContext(1)]
	private static void DoInit(UObject worldContext)
	{
		AppUtil.SetWorldContext(worldContext);
		Singleton<CloudGameManagerLauncher>.Instance.Init();
		Singleton<LauncherStorageLib>.Instance.Initialize();
		Singleton<LauncherResourceLib>.Instance.Initialize();
		Singleton<LauncherConfigLib>.Instance.Initialize();
		Singleton<LauncherLanguageLib>.Instance.Initialize(UKuroStaticLibrary.IsEditor(worldContext));
		Singleton<LauncherGameSettingLib>.Instance.Initialize();
		SplashRegionBlockLib.Initialize();
	}

	// Token: 0x0601C9EC RID: 117228 RVA: 0x00896112 File Offset: 0x00894312
	public new static UClassStackOnlyPtr StaticClass()
	{
		if (TsSplash._ClassPtr == IntPtr.Zero)
		{
			UObjectGlobals.StaticLoadClass(null, "/Game/Aki/TypeScript/Launcher/TsSplash.TsSplash_C");
		}
		return TsSplash._ClassPtr;
	}

	// Token: 0x0601C9ED RID: 117229 RVA: 0x00896138 File Offset: 0x00894338
	public TsSplash() : this(BuiltinUtils.AllocNativeUObject(TsSplash.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
	{
	}

	// Token: 0x0601C9EE RID: 117230 RVA: 0x00896160 File Offset: 0x00894360
	[NullableContext(1)]
	public TsSplash(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(TsSplash.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
	{
	}

	// Token: 0x0601C9EF RID: 117231 RVA: 0x00896193 File Offset: 0x00894393
	protected TsSplash(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
	{
	}

	// Token: 0x0601C9F0 RID: 117232 RVA: 0x0089619C File Offset: 0x0089439C
	protected unsafe virtual void __CPPCALL_Init_Implementation(TsSplash.__Init_FunctionParams* __Params)
	{
		UObject orCreateUObjectByNativePointer = BuiltinUtils.GetOrCreateUObjectByNativePointer<UObject>(__Params->worldContext);
		this.Init(orCreateUObjectByNativePointer);
	}

	// Token: 0x0601C9F1 RID: 117233 RVA: 0x008961BC File Offset: 0x008943BC
	protected unsafe virtual void __CPPCALL_GetDelay_Implementation(TsSplash.__GetDelay_FunctionParams* __Params)
	{
		__Params->__Result = this.GetDelay();
	}

	// Token: 0x0601C9F2 RID: 117234 RVA: 0x008961CA File Offset: 0x008943CA
	protected virtual void __CPPCALL_ChangeToPhaseOne_Implementation()
	{
		this.ChangeToPhaseOne();
	}

	// Token: 0x0601C9F3 RID: 117235 RVA: 0x008961D2 File Offset: 0x008943D2
	protected virtual void __CPPCALL_ChangeToPhaseSpecial_Implementation()
	{
		this.ChangeToPhaseSpecial();
	}

	// Token: 0x0601C9F4 RID: 117236 RVA: 0x008961DA File Offset: 0x008943DA
	protected virtual void __CPPCALL_ChangeToPhaseThree_Implementation()
	{
		this.ChangeToPhaseThree();
	}

	// Token: 0x0601C9F5 RID: 117237 RVA: 0x008961E2 File Offset: 0x008943E2
	protected virtual void __CPPCALL_ShowSplashView_Implementation()
	{
		this.ShowSplashView();
	}

	// Token: 0x0601C9F6 RID: 117238 RVA: 0x008961EA File Offset: 0x008943EA
	protected virtual void __CPPCALL_ChangeScene_Implementation()
	{
		this.ChangeScene();
	}

	// Token: 0x0601C9F8 RID: 117240 RVA: 0x00896218 File Offset: 0x00894418
	[CompilerGenerated]
	private UniTask <ShowSplashView>g__InitAndPrepareAsync|11_0()
	{
		TsSplash.<<ShowSplashView>g__InitAndPrepareAsync|11_0>d <<ShowSplashView>g__InitAndPrepareAsync|11_0>d;
		<<ShowSplashView>g__InitAndPrepareAsync|11_0>d.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<<ShowSplashView>g__InitAndPrepareAsync|11_0>d.<>4__this = this;
		<<ShowSplashView>g__InitAndPrepareAsync|11_0>d.<>1__state = -1;
		<<ShowSplashView>g__InitAndPrepareAsync|11_0>d.<>t__builder.Start<TsSplash.<<ShowSplashView>g__InitAndPrepareAsync|11_0>d>(ref <<ShowSplashView>g__InitAndPrepareAsync|11_0>d);
		return <<ShowSplashView>g__InitAndPrepareAsync|11_0>d.<>t__builder.Task;
	}

	// Token: 0x0400E67D RID: 59005
	public static SplashPhase CurrentPhase;

	// Token: 0x0400E67E RID: 59006
	[Nullable(2)]
	public static UObject WorldContext;

	// Token: 0x0400E67F RID: 59007
	[Nullable(2)]
	private static SplashUiView KuroSplashVideo;

	// Token: 0x0400E680 RID: 59008
	[Nullable(1)]
	public new const string __ObjectPath = "/Game/Aki/TypeScript/Launcher/TsSplash.TsSplash_C";

	// Token: 0x0400E681 RID: 59009
	private static IntPtr _ClassPtr;

	// Token: 0x0400E682 RID: 59010
	private static IntPtr _ClassDefaultObjectPtr;

	// Token: 0x0200969A RID: 38554
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 8)]
	protected ref struct __Init_FunctionParams
	{
		// Token: 0x04031B0B RID: 203531
		[FieldOffset(0)]
		public IntPtr worldContext;
	}

	// Token: 0x0200969B RID: 38555
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 4)]
	protected ref struct __GetDelay_FunctionParams
	{
		// Token: 0x04031B0C RID: 203532
		[FieldOffset(0)]
		public float __Result;
	}
}
