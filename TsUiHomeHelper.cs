using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.UiComponent.UiHomeButton;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Service.Flags;
using UnrealEngine.Utils;

// Token: 0x02002C56 RID: 11350
[UClass("/Game/Aki/TypeScript/Game/Module/UiComponent/UiHomeButton/", EClassFlags.CLASS_None)]
[UnrealObjectPath("/Game/Aki/TypeScript/Game/Module/UiComponent/UiHomeButton/TsUiHomeHelper.TsUiHomeHelper_C")]
public class TsUiHomeHelper : ULGUIBehaviour, IUnrealUObject, IUnrealObject
{
	// Token: 0x06016C25 RID: 93221 RVA: 0x00650188 File Offset: 0x0064E388
	public void CreateHomeBtn(int homeBtnStyle, bool snapSize = false)
	{
		if (this.HasCreate)
		{
			Singleton<Log>.Instance.Error(ELogModule.HomeBtn, ELogAuthor.CB, "Home键被重复创建", default(ReadOnlySpan<ValueTuple<string, object>>));
			return;
		}
		this.CreateHomeBtnAsync(homeBtnStyle, snapSize).Forget();
	}

	// Token: 0x06016C26 RID: 93222 RVA: 0x006501CC File Offset: 0x0064E3CC
	private UniTask CreateHomeBtnAsync(int homeBtnStyle, bool snapSize = false)
	{
		TsUiHomeHelper.<CreateHomeBtnAsync>d__3 <CreateHomeBtnAsync>d__;
		<CreateHomeBtnAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<CreateHomeBtnAsync>d__.<>4__this = this;
		<CreateHomeBtnAsync>d__.homeBtnStyle = homeBtnStyle;
		<CreateHomeBtnAsync>d__.snapSize = snapSize;
		<CreateHomeBtnAsync>d__.<>1__state = -1;
		<CreateHomeBtnAsync>d__.<>t__builder.Start<TsUiHomeHelper.<CreateHomeBtnAsync>d__3>(ref <CreateHomeBtnAsync>d__);
		return <CreateHomeBtnAsync>d__.<>t__builder.Task;
	}

	// Token: 0x06016C27 RID: 93223 RVA: 0x0065021F File Offset: 0x0064E41F
	private void OnBtnClick()
	{
		ControllerBase<HomeBtnController>.Instance.ExecuteBtnClick();
	}

	// Token: 0x06016C28 RID: 93224 RVA: 0x0065022B File Offset: 0x0064E42B
	public new static UClassStackOnlyPtr StaticClass()
	{
		if (TsUiHomeHelper._ClassPtr == IntPtr.Zero)
		{
			UObjectGlobals.StaticLoadClass(null, "/Game/Aki/TypeScript/Game/Module/UiComponent/UiHomeButton/TsUiHomeHelper.TsUiHomeHelper_C");
		}
		return TsUiHomeHelper._ClassPtr;
	}

	// Token: 0x06016C29 RID: 93225 RVA: 0x00650250 File Offset: 0x0064E450
	public TsUiHomeHelper() : this(BuiltinUtils.AllocNativeUObject(TsUiHomeHelper.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
	{
	}

	// Token: 0x06016C2A RID: 93226 RVA: 0x00650278 File Offset: 0x0064E478
	[NullableContext(1)]
	public TsUiHomeHelper(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(TsUiHomeHelper.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
	{
	}

	// Token: 0x06016C2B RID: 93227 RVA: 0x006502AB File Offset: 0x0064E4AB
	protected TsUiHomeHelper(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
	{
	}

	// Token: 0x0400AF65 RID: 44901
	private bool HasCreate;

	// Token: 0x0400AF66 RID: 44902
	[Nullable(2)]
	private HomeBtnItem HomeBtnItem;

	// Token: 0x0400AF67 RID: 44903
	[Nullable(1)]
	public new const string __ObjectPath = "/Game/Aki/TypeScript/Game/Module/UiComponent/UiHomeButton/TsUiHomeHelper.TsUiHomeHelper_C";

	// Token: 0x0400AF68 RID: 44904
	private static IntPtr _ClassPtr;

	// Token: 0x0400AF69 RID: 44905
	private static IntPtr _ClassDefaultObjectPtr;
}
