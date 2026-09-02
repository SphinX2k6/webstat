using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using AkiClient.Game.Aki.Data.Effect.Struct;
using AkiClient.Game.Aki.Render.RuntimeBP.Effect;
using AkiClient.Game.Aki.Render.RuntimeBP.Effect.Data;
using CSharpScript.Game.Effect;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Service.Flags;
using UnrealEngine.Utils;

// Token: 0x02000E80 RID: 3712
[UClass("/Game/Aki/TypeScript/Game/Effect/", EClassFlags.CLASS_None)]
[UnrealObjectPath("/Game/Aki/TypeScript/Game/Effect/TsEffectFunctionLibrary.TsEffectFunctionLibrary_C")]
public class TsEffectFunctionLibrary : UBlueprintFunctionLibrary, IUnrealUObject, IUnrealObject
{
	// Token: 0x06005A91 RID: 23185 RVA: 0x00163280 File Offset: 0x00161480
	[NullableContext(1)]
	[UFunction(EFunctionFlags.FUNC_None)]
	public unsafe static int SpawnEffect(UObject worldContext, UObject callObject, string path, FTransformDouble transform, string reason, EEffectPlay playType, bool disablePostProcess = false)
	{
		if (callObject == null || !callObject.IsValid())
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.RenderEffect;
			ELogAuthor author = ELogAuthor.LFJW;
			string message = "TsEffectFunctionLibrary.SpawnEffect失败，因为CallObject无效";
			<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("Path", path);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("Reason", reason);
			instance.Error(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
			return 0;
		}
		if (reason == null)
		{
			Log instance2 = Singleton<Log>.Instance;
			ELogModule module2 = ELogModule.Entity;
			ELogAuthor author2 = ELogAuthor.LFJW;
			string message2 = "TsEffectFunctionLibrary.SpawnEffectWithActor的Reason不能使用undefined";
			<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray2 = default(<>y__InlineArray2<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 0) = new ValueTuple<string, object>("蓝图对象", callObject);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 1) = new ValueTuple<string, object>("Reason", reason);
			instance2.Error(module2, author2, message2, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray2, 2));
			return 0;
		}
		if (reason.Length < 4)
		{
			Log instance3 = Singleton<Log>.Instance;
			ELogModule module3 = ELogModule.Entity;
			ELogAuthor author3 = ELogAuthor.LFJW;
			string message3 = "TsEffectFunctionLibrary.SpawnEffectWithActor的Reason字符串长度必须大于等于限制字符数量";
			<>y__InlineArray3<ValueTuple<string, object>> <>y__InlineArray3 = default(<>y__InlineArray3<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray3, 0) = new ValueTuple<string, object>("蓝图对象", callObject);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray3, 1) = new ValueTuple<string, object>("Reason", reason);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray3, 2) = new ValueTuple<string, object>("限制的字符数量", 4);
			instance3.Error(module3, author3, message3, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray3, 3));
			return 0;
		}
		string reason2 = "[蓝图:" + callObject.GetName() + "] " + reason;
		EffectSystem instance4 = Singleton<EffectSystem>.Instance;
		FTransformDouble? ftransformDouble = new FTransformDouble?(transform);
		int? num = new int?(instance4.SpawnEffect(worldContext, ftransformDouble, path, reason2, new EffectContext(null, callObject, disablePostProcess), global::EEffectType.Scene, null, null, null, false, false));
		return num.GetValueOrDefault();
	}

	// Token: 0x06005A92 RID: 23186 RVA: 0x00163418 File Offset: 0x00161618
	[NullableContext(1)]
	[UFunction(EFunctionFlags.FUNC_None)]
	public unsafe static int SpawnEffectUI(UObject worldContext, UObject callObject, string path, FTransformDouble transform, string reason)
	{
		if (callObject == null || !callObject.IsValid())
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.RenderEffect;
			ELogAuthor author = ELogAuthor.LFJW;
			string message = "TsEffectFunctionLibrary.SpawnEffectUI失败，因为CallObject无效";
			<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("Path", path);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("Reason", reason);
			instance.Error(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
			return 0;
		}
		if (reason == null)
		{
			Log instance2 = Singleton<Log>.Instance;
			ELogModule module2 = ELogModule.Entity;
			ELogAuthor author2 = ELogAuthor.LFJW;
			string message2 = "TsEffectFunctionLibrary.SpawnEffectUI的Reason不能使用undefined";
			<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray2 = default(<>y__InlineArray2<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 0) = new ValueTuple<string, object>("蓝图对象", callObject);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 1) = new ValueTuple<string, object>("Reason", reason);
			instance2.Error(module2, author2, message2, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray2, 2));
			return 0;
		}
		if (reason.Length < 4)
		{
			Log instance3 = Singleton<Log>.Instance;
			ELogModule module3 = ELogModule.Entity;
			ELogAuthor author3 = ELogAuthor.LFJW;
			string message3 = "TsEffectFunctionLibrary.SpawnEffectUI的Reason字符串长度必须大于等于限制字符数量";
			<>y__InlineArray3<ValueTuple<string, object>> <>y__InlineArray3 = default(<>y__InlineArray3<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray3, 0) = new ValueTuple<string, object>("蓝图对象", callObject);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray3, 1) = new ValueTuple<string, object>("Reason", reason);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray3, 2) = new ValueTuple<string, object>("限制的字符数量", 4);
			instance3.Error(module3, author3, message3, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray3, 3));
			return 0;
		}
		string reason2 = "[蓝图:" + callObject.GetName() + "] " + reason;
		EffectSystem instance4 = Singleton<EffectSystem>.Instance;
		FTransformDouble? ftransformDouble = new FTransformDouble?(transform);
		int? num = new int?(instance4.SpawnEffect(worldContext, ftransformDouble, path, reason2, new EffectContext(null, callObject, false), global::EEffectType.UiScene3D, null, null, null, false, false));
		return num.GetValueOrDefault();
	}

	// Token: 0x06005A93 RID: 23187 RVA: 0x001635B0 File Offset: 0x001617B0
	[NullableContext(1)]
	[UFunction(EFunctionFlags.FUNC_None)]
	public unsafe static int SpawnEffectWithActor(UObject worldContext, UObject callObject, AActor effectActor, string path, string reason, EEffectPlay playType, AkiClient.Game.Aki.Data.Effect.Struct.EEffectType effectType, bool disablePostProcess = false)
	{
		BP_EWorldType worldType = UKuroRenderingRuntimeBPPluginBPLibrary.GetWorldType(worldContext);
		if (worldType != BP_EWorldType.Editor && worldType != BP_EWorldType.EditorPreview)
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.RenderEffect;
			ELogAuthor author = ELogAuthor.CJH;
			string message = "TsEffectFunctionLibrary.SpawnEffectWithActor仅能于编辑时调用";
			<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("Path", path);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("Reason", reason);
			instance.Error(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
			return 0;
		}
		if (effectActor == null || !effectActor.IsValid())
		{
			Log instance2 = Singleton<Log>.Instance;
			ELogModule module2 = ELogModule.RenderEffect;
			ELogAuthor author2 = ELogAuthor.LFJW;
			string message2 = "TsEffectFunctionLibrary.SpawnEffectWithActor失败，因为effectActor参数无效";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("Reason", reason);
			instance2.Error(module2, author2, message2, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			return 0;
		}
		if (callObject == null || !callObject.IsValid())
		{
			Log instance3 = Singleton<Log>.Instance;
			ELogModule module3 = ELogModule.RenderEffect;
			ELogAuthor author3 = ELogAuthor.LFJW;
			string message3 = "SpawnEffectWithActor失败，因为CallObject无效";
			<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray2 = default(<>y__InlineArray2<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 0) = new ValueTuple<string, object>("Actor", effectActor.GetName());
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 1) = new ValueTuple<string, object>("Reason", reason);
			instance3.Error(module3, author3, message3, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray2, 2));
			return 0;
		}
		if (reason == null)
		{
			Log instance4 = Singleton<Log>.Instance;
			ELogModule module4 = ELogModule.Entity;
			ELogAuthor author4 = ELogAuthor.LFJW;
			string message4 = "TsEffectFunctionLibrary.SpawnEffectWithActor的Reason不能使用undefined";
			<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray3 = default(<>y__InlineArray2<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray3, 0) = new ValueTuple<string, object>("蓝图对象", callObject);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray3, 1) = new ValueTuple<string, object>("Reason", reason);
			instance4.Error(module4, author4, message4, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray3, 2));
			return 0;
		}
		if (reason.Length < 4)
		{
			Log instance5 = Singleton<Log>.Instance;
			ELogModule module5 = ELogModule.Entity;
			ELogAuthor author5 = ELogAuthor.LFJW;
			string message5 = "TsEffectFunctionLibrary.SpawnEffectWithActor的Reason字符串长度必须大于等于限制字符数量";
			<>y__InlineArray3<ValueTuple<string, object>> <>y__InlineArray4 = default(<>y__InlineArray3<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray4, 0) = new ValueTuple<string, object>("蓝图对象", callObject);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray4, 1) = new ValueTuple<string, object>("Reason", reason);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray4, 2) = new ValueTuple<string, object>("限制的字符数量", 4);
			instance5.Error(module5, author5, message5, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray4, 3));
			return 0;
		}
		string reason2 = "[蓝图:" + callObject.GetName() + "] " + reason;
		return Singleton<EffectSystem>.Instance.SpawnEffectWithActor(worldContext, effectActor, path, reason2, true, new EffectContext(null, callObject, disablePostProcess), false, (global::EEffectType)effectType);
	}

	// Token: 0x06005A94 RID: 23188 RVA: 0x001637D1 File Offset: 0x001619D1
	[UFunction(EFunctionFlags.FUNC_None)]
	public static void InitializeWithPreview(bool refresh)
	{
		Singleton<EffectSystem>.Instance.InitializeWithPreview(refresh);
	}

	// Token: 0x06005A95 RID: 23189 RVA: 0x001637DE File Offset: 0x001619DE
	[UFunction(EFunctionFlags.FUNC_None)]
	public static bool EffectHandleIsValid(int handle)
	{
		return Singleton<EffectSystem>.Instance.IsValid(handle);
	}

	// Token: 0x06005A96 RID: 23190 RVA: 0x001637EC File Offset: 0x001619EC
	[NullableContext(1)]
	[UFunction(EFunctionFlags.FUNC_None)]
	public unsafe static bool StopEffect(int handle, UObject callObject, string reason, bool immediately, bool destroyActor)
	{
		if (callObject == null || !callObject.IsValid())
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.RenderEffect;
			ELogAuthor author = ELogAuthor.LFJW;
			string message = "CallObject无效";
			<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("Reason", reason);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("Handle", handle);
			instance.Error(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
			return false;
		}
		if (reason == null)
		{
			Log instance2 = Singleton<Log>.Instance;
			ELogModule module2 = ELogModule.Entity;
			ELogAuthor author2 = ELogAuthor.LFJW;
			string message2 = "TsEffectFunctionLibrary.StopEffect的Reason不能使用undefined";
			<>y__InlineArray3<ValueTuple<string, object>> <>y__InlineArray2 = default(<>y__InlineArray3<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 0) = new ValueTuple<string, object>("蓝图对象", callObject);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 1) = new ValueTuple<string, object>("Reason", reason);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 2) = new ValueTuple<string, object>("Handle", handle);
			instance2.Error(module2, author2, message2, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray2, 3));
			return false;
		}
		if (reason.Length < 4)
		{
			Log instance3 = Singleton<Log>.Instance;
			ELogModule module3 = ELogModule.Entity;
			ELogAuthor author3 = ELogAuthor.LFJW;
			string message3 = "TsEffectFunctionLibrary.StopEffect的Reason字符串长度必须大于等于限制字符数量";
			<>y__InlineArray3<ValueTuple<string, object>> <>y__InlineArray3 = default(<>y__InlineArray3<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray3, 0) = new ValueTuple<string, object>("蓝图对象", callObject);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray3, 1) = new ValueTuple<string, object>("Reason", reason);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray3, 2) = new ValueTuple<string, object>("限制的字符数量", 4);
			instance3.Error(module3, author3, message3, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray3, 3));
			return false;
		}
		if (handle == 0)
		{
			Log instance4 = Singleton<Log>.Instance;
			ELogModule module4 = ELogModule.RenderEffect;
			ELogAuthor author4 = ELogAuthor.LFJW;
			string message4 = "特效句柄无效";
			<>y__InlineArray3<ValueTuple<string, object>> <>y__InlineArray4 = default(<>y__InlineArray3<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray4, 0) = new ValueTuple<string, object>("CallObject", callObject);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray4, 1) = new ValueTuple<string, object>("Reason", reason);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray4, 2) = new ValueTuple<string, object>("Handle", handle);
			instance4.Error(module4, author4, message4, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray4, 3));
			return false;
		}
		string reason2 = "[蓝图:" + callObject.GetName() + "] " + reason;
		return Singleton<EffectSystem>.Instance.StopEffectById(handle, reason2, immediately, null);
	}

	// Token: 0x06005A97 RID: 23191 RVA: 0x001639F0 File Offset: 0x00161BF0
	[NullableContext(1)]
	[UFunction(EFunctionFlags.FUNC_None)]
	public unsafe static bool PlayEffect(int handle, UObject callObject, string reason)
	{
		if (callObject == null || !callObject.IsValid())
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.RenderEffect;
			ELogAuthor author = ELogAuthor.LFJW;
			string message = "CallObject无效";
			<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("Reason", reason);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("Handle", handle);
			instance.Error(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
			return false;
		}
		if (reason == null)
		{
			Log instance2 = Singleton<Log>.Instance;
			ELogModule module2 = ELogModule.Entity;
			ELogAuthor author2 = ELogAuthor.LFJW;
			string message2 = "TsEffectFunctionLibrary.PlayEffect的Reason不能使用undefined";
			<>y__InlineArray3<ValueTuple<string, object>> <>y__InlineArray2 = default(<>y__InlineArray3<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 0) = new ValueTuple<string, object>("蓝图对象", callObject);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 1) = new ValueTuple<string, object>("Reason", reason);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 2) = new ValueTuple<string, object>("Handle", handle);
			instance2.Error(module2, author2, message2, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray2, 3));
			return false;
		}
		if (reason.Length < 4)
		{
			Log instance3 = Singleton<Log>.Instance;
			ELogModule module3 = ELogModule.Entity;
			ELogAuthor author3 = ELogAuthor.LFJW;
			string message3 = "TsEffectFunctionLibrary.PlayEffect的Reason字符串长度必须大于等于限制字符数量";
			<>y__InlineArray3<ValueTuple<string, object>> <>y__InlineArray3 = default(<>y__InlineArray3<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray3, 0) = new ValueTuple<string, object>("蓝图对象", callObject);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray3, 1) = new ValueTuple<string, object>("Reason", reason);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray3, 2) = new ValueTuple<string, object>("限制的字符数量", 4);
			instance3.Error(module3, author3, message3, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray3, 3));
			return false;
		}
		if (handle == 0)
		{
			Log instance4 = Singleton<Log>.Instance;
			ELogModule module4 = ELogModule.RenderEffect;
			ELogAuthor author4 = ELogAuthor.LFJW;
			string message4 = "特效句柄无效";
			<>y__InlineArray3<ValueTuple<string, object>> <>y__InlineArray4 = default(<>y__InlineArray3<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray4, 0) = new ValueTuple<string, object>("CallObject", callObject);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray4, 1) = new ValueTuple<string, object>("Reason", reason);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray4, 2) = new ValueTuple<string, object>("Handle", handle);
			instance4.Error(module4, author4, message4, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray4, 3));
			return false;
		}
		return true;
	}

	// Token: 0x06005A98 RID: 23192 RVA: 0x00163BC4 File Offset: 0x00161DC4
	[NullableContext(2)]
	[UFunction(EFunctionFlags.FUNC_None)]
	public static void SetEffectParameterNiagara(int handle, ref TArray<SEffectFloatParameter> userParameterFloat, ref TArray<SEffectColorParameter> userParameterColor, ref TArray<SEffectVectorParameter> userParameterVector, ref TArray<SEffectFloatParameter> materialParameterFloat, ref TArray<SEffectColorParameter> materialParameterColor)
	{
		if (handle == 0)
		{
			Singleton<Log>.Instance.Error(ELogModule.RenderEffect, ELogAuthor.LSY, "特效句柄无效", default(ReadOnlySpan<ValueTuple<string, object>>));
			return;
		}
		EffectParameterNiagara effectParameterNiagara = new EffectParameterNiagara();
		if (userParameterFloat != null)
		{
			TArray<SEffectFloatParameter> tarray = userParameterFloat;
			int num = tarray.Num();
			if (num > 0)
			{
				effectParameterNiagara.UserParameterFloat = new List<ValueTuple<FName, float>>();
				for (int i = 0; i < num; i++)
				{
					SEffectFloatParameter seffectFloatParameter = tarray.Get(i);
					effectParameterNiagara.UserParameterFloat.Add(new ValueTuple<FName, float>(seffectFloatParameter.Name, seffectFloatParameter.Value));
				}
			}
		}
		TArray<SEffectColorParameter> tarray2 = userParameterColor;
		int num2 = tarray2.Num();
		if (num2 > 0)
		{
			effectParameterNiagara.UserParameterColor = new List<ValueTuple<FName, FLinearColor>>();
			for (int j = 0; j < num2; j++)
			{
				SEffectColorParameter seffectColorParameter = tarray2.Get(j);
				effectParameterNiagara.UserParameterColor.Add(new ValueTuple<FName, FLinearColor>(seffectColorParameter.Name, seffectColorParameter.Value));
			}
		}
		if (userParameterVector != null)
		{
			TArray<SEffectVectorParameter> tarray3 = userParameterVector;
			int num3 = tarray3.Num();
			if (num3 > 0)
			{
				effectParameterNiagara.UserParameterVector = new List<ValueTuple<FName, FVector>>();
				for (int k = 0; k < num3; k++)
				{
					SEffectVectorParameter seffectVectorParameter = tarray3.Get(k);
					effectParameterNiagara.UserParameterVector.Add(new ValueTuple<FName, FVector>(seffectVectorParameter.Name, seffectVectorParameter.Value));
				}
			}
		}
		if (materialParameterFloat != null)
		{
			TArray<SEffectFloatParameter> tarray4 = materialParameterFloat;
			int num4 = tarray4.Num();
			if (num4 > 0)
			{
				effectParameterNiagara.MaterialParameterFloat = new List<ValueTuple<FName, float>>();
				for (int l = 0; l < num4; l++)
				{
					SEffectFloatParameter seffectFloatParameter2 = tarray4.Get(l);
					effectParameterNiagara.MaterialParameterFloat.Add(new ValueTuple<FName, float>(seffectFloatParameter2.Name, seffectFloatParameter2.Value));
				}
			}
		}
		if (materialParameterColor != null)
		{
			TArray<SEffectColorParameter> tarray5 = materialParameterColor;
			int num5 = tarray5.Num();
			if (num5 > 0)
			{
				effectParameterNiagara.MaterialParameterColor = new List<ValueTuple<FName, FLinearColor>>();
				for (int m = 0; m < num5; m++)
				{
					SEffectColorParameter seffectColorParameter2 = tarray5.Get(m);
					effectParameterNiagara.MaterialParameterColor.Add(new ValueTuple<FName, FLinearColor>(seffectColorParameter2.Name, seffectColorParameter2.Value));
				}
			}
		}
		Singleton<EffectSystem>.Instance.SetEffectParameterNiagara(handle, effectParameterNiagara);
	}

	// Token: 0x06005A99 RID: 23193 RVA: 0x00163DC4 File Offset: 0x00161FC4
	[UFunction(EFunctionFlags.FUNC_None)]
	public static void EditorTickHandle(int handle, float delta)
	{
		Singleton<EffectSystem>.Instance.TickHandleInEditor(handle, delta);
	}

	// Token: 0x06005A9A RID: 23194 RVA: 0x00163DD2 File Offset: 0x00161FD2
	[NullableContext(2)]
	[UFunction(EFunctionFlags.FUNC_None)]
	public static AActor GetEffectActor(int handle)
	{
		return Singleton<EffectSystem>.Instance.GetSureEffectActor(handle);
	}

	// Token: 0x06005A9B RID: 23195 RVA: 0x00163DE0 File Offset: 0x00161FE0
	public static bool? GetPlayType(EEffectPlay playType)
	{
		if (playType == EEffectPlay.Play)
		{
			return new bool?(true);
		}
		if (playType != EEffectPlay.DoNotPlay)
		{
			return null;
		}
		return new bool?(false);
	}

	// Token: 0x06005A9C RID: 23196 RVA: 0x00163E10 File Offset: 0x00162010
	[NullableContext(1)]
	[UFunction(EFunctionFlags.FUNC_None)]
	public static void AttachEffectActorToActor(int handle, AActor parent, FName socketName, EAttachmentRule locationRule, EAttachmentRule rotationRule, EAttachmentRule scaleRule, bool bWeldSimulatedBodies)
	{
		if (!Singleton<EffectSystem>.Instance.IsValid(handle))
		{
			return;
		}
		if (parent == null)
		{
			return;
		}
		OneOf<KuroEffectActorHandle, AActor> effectActor = Singleton<EffectSystem>.Instance.GetEffectActor(handle);
		FName? fname = new FName?(socketName);
		effectActor.K2_AttachToActor(parent, fname, locationRule, rotationRule, scaleRule, bWeldSimulatedBodies);
	}

	// Token: 0x06005A9D RID: 23197 RVA: 0x00163E50 File Offset: 0x00162050
	[NullableContext(1)]
	[UFunction(EFunctionFlags.FUNC_None)]
	public static void AttachEffectActorToComponent(int handle, USceneComponent parent, FName socketName, EAttachmentRule locationRule, EAttachmentRule rotationRule, EAttachmentRule scaleRule, bool bWeldSimulatedBodies)
	{
		if (!Singleton<EffectSystem>.Instance.IsValid(handle))
		{
			return;
		}
		if (parent == null)
		{
			return;
		}
		Singleton<EffectSystem>.Instance.GetEffectActor(handle).K2_AttachToComponent(parent, new FName?(socketName), locationRule, rotationRule, scaleRule, bWeldSimulatedBodies);
	}

	// Token: 0x06005A9E RID: 23198 RVA: 0x00163E82 File Offset: 0x00162082
	[UFunction(EFunctionFlags.FUNC_None)]
	public static void SetEffectActorRelativeLocation(int handle, FVectorDouble newRelativeLocation, bool bSweep, bool bTeleport)
	{
		if (!Singleton<EffectSystem>.Instance.IsValid(handle))
		{
			return;
		}
		Singleton<EffectSystem>.Instance.GetEffectActor(handle).D_K2_SetActorRelativeLocation(newRelativeLocation, bSweep, ref WorldGlobal.SweepHitResult, bTeleport);
	}

	// Token: 0x06005A9F RID: 23199 RVA: 0x00163EAB File Offset: 0x001620AB
	[UFunction(EFunctionFlags.FUNC_None)]
	public static void SetEffectHiddenInGame(int handle, bool value)
	{
		if (!Singleton<EffectSystem>.Instance.IsValid(handle))
		{
			return;
		}
		Singleton<EffectSystem>.Instance.SetEffectHidden(handle, value, "TsEffectFunctionLibrary.SetEffectHiddenInGame", false);
	}

	// Token: 0x06005AA0 RID: 23200 RVA: 0x00163ED0 File Offset: 0x001620D0
	[UFunction(EFunctionFlags.FUNC_None)]
	public static void SetEffectIgnoreVisibilityOptimize(int handle, bool ignore)
	{
		if (!Singleton<EffectSystem>.Instance.IsValid(handle))
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.RenderEffect;
			ELogAuthor author = ELogAuthor.WLJ;
			string message = "设置EffectIgnoreVisibilityOptimize，句柄失效";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("handle", handle);
			instance.Warn(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			return;
		}
		Singleton<EffectSystem>.Instance.SetEffectIgnoreVisibilityOptimize(handle, ignore);
	}

	// Token: 0x06005AA1 RID: 23201 RVA: 0x00163F24 File Offset: 0x00162124
	[UFunction(EFunctionFlags.FUNC_None)]
	public static void SetEffectStoppingTime(int handle, bool stoppingTime)
	{
		if (!Singleton<EffectSystem>.Instance.IsValid(handle))
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.RenderEffect;
			ELogAuthor author = ELogAuthor.WLJ;
			string message = "设置EffectStoppingTime，句柄失效";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("handle", handle);
			instance.Warn(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			return;
		}
		Singleton<EffectSystem>.Instance.SetEffectStoppingTime(handle, stoppingTime);
	}

	// Token: 0x06005AA2 RID: 23202 RVA: 0x00163F77 File Offset: 0x00162177
	[UFunction(EFunctionFlags.FUNC_None)]
	public static void SetGlobalStoppingTime(bool stoppingTime, float playTime)
	{
		Singleton<EffectSystem>.Instance.SetGlobalStoppingTime(stoppingTime, playTime);
	}

	// Token: 0x06005AA3 RID: 23203 RVA: 0x00163F85 File Offset: 0x00162185
	[NullableContext(1)]
	[UFunction(EFunctionFlags.FUNC_None)]
	public static void SetPublicToSequence(int handle, BP_EffectActor_C actor)
	{
	}

	// Token: 0x06005AA4 RID: 23204 RVA: 0x00163F87 File Offset: 0x00162187
	[NullableContext(1)]
	[UFunction(EFunctionFlags.FUNC_None)]
	public static void SetSimulateFromSequence(int handle, BP_EffectActor_C actor)
	{
	}

	// Token: 0x06005AA5 RID: 23205 RVA: 0x00163F89 File Offset: 0x00162189
	public new static UClassStackOnlyPtr StaticClass()
	{
		if (TsEffectFunctionLibrary._ClassPtr == IntPtr.Zero)
		{
			UObjectGlobals.StaticLoadClass(null, "/Game/Aki/TypeScript/Game/Effect/TsEffectFunctionLibrary.TsEffectFunctionLibrary_C");
		}
		return TsEffectFunctionLibrary._ClassPtr;
	}

	// Token: 0x06005AA6 RID: 23206 RVA: 0x00163FB0 File Offset: 0x001621B0
	public TsEffectFunctionLibrary() : this(BuiltinUtils.AllocNativeUObject(TsEffectFunctionLibrary.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
	{
	}

	// Token: 0x06005AA7 RID: 23207 RVA: 0x00163FD8 File Offset: 0x001621D8
	[NullableContext(1)]
	public TsEffectFunctionLibrary(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(TsEffectFunctionLibrary.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
	{
	}

	// Token: 0x06005AA8 RID: 23208 RVA: 0x0016400B File Offset: 0x0016220B
	protected TsEffectFunctionLibrary(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
	{
	}

	// Token: 0x06005AA9 RID: 23209 RVA: 0x00164014 File Offset: 0x00162214
	protected unsafe static void __CPPCALL_SpawnEffect_Implementation(TsEffectFunctionLibrary.__SpawnEffect_FunctionParams* __Params)
	{
		UObject orCreateUObjectByNativePointer = BuiltinUtils.GetOrCreateUObjectByNativePointer<UObject>(__Params->worldContext);
		UObject orCreateUObjectByNativePointer2 = BuiltinUtils.GetOrCreateUObjectByNativePointer<UObject>(__Params->callObject);
		string path = FString.ToString((void*)(&__Params->path));
		string reason = FString.ToString((void*)(&__Params->reason));
		EEffectPlay playType = (EEffectPlay)__Params->playType;
		__Params->__Result = TsEffectFunctionLibrary.SpawnEffect(orCreateUObjectByNativePointer, orCreateUObjectByNativePointer2, path, __Params->transform, reason, playType, __Params->disablePostProcess);
	}

	// Token: 0x06005AAA RID: 23210 RVA: 0x00164078 File Offset: 0x00162278
	protected unsafe static void __CPPCALL_SpawnEffectUI_Implementation(TsEffectFunctionLibrary.__SpawnEffectUI_FunctionParams* __Params)
	{
		UObject orCreateUObjectByNativePointer = BuiltinUtils.GetOrCreateUObjectByNativePointer<UObject>(__Params->worldContext);
		UObject orCreateUObjectByNativePointer2 = BuiltinUtils.GetOrCreateUObjectByNativePointer<UObject>(__Params->callObject);
		string path = FString.ToString((void*)(&__Params->path));
		string reason = FString.ToString((void*)(&__Params->reason));
		__Params->__Result = TsEffectFunctionLibrary.SpawnEffectUI(orCreateUObjectByNativePointer, orCreateUObjectByNativePointer2, path, __Params->transform, reason);
	}

	// Token: 0x06005AAB RID: 23211 RVA: 0x001640CC File Offset: 0x001622CC
	protected unsafe static void __CPPCALL_SpawnEffectWithActor_Implementation(TsEffectFunctionLibrary.__SpawnEffectWithActor_FunctionParams* __Params)
	{
		UObject orCreateUObjectByNativePointer = BuiltinUtils.GetOrCreateUObjectByNativePointer<UObject>(__Params->worldContext);
		UObject orCreateUObjectByNativePointer2 = BuiltinUtils.GetOrCreateUObjectByNativePointer<UObject>(__Params->callObject);
		AActor orCreateUObjectByNativePointer3 = BuiltinUtils.GetOrCreateUObjectByNativePointer<AActor>(__Params->effectActor);
		string path = FString.ToString((void*)(&__Params->path));
		string reason = FString.ToString((void*)(&__Params->reason));
		EEffectPlay playType = (EEffectPlay)__Params->playType;
		AkiClient.Game.Aki.Data.Effect.Struct.EEffectType effectType = (AkiClient.Game.Aki.Data.Effect.Struct.EEffectType)__Params->effectType;
		__Params->__Result = TsEffectFunctionLibrary.SpawnEffectWithActor(orCreateUObjectByNativePointer, orCreateUObjectByNativePointer2, orCreateUObjectByNativePointer3, path, reason, playType, effectType, __Params->disablePostProcess);
	}

	// Token: 0x06005AAC RID: 23212 RVA: 0x00164143 File Offset: 0x00162343
	protected unsafe static void __CPPCALL_InitializeWithPreview_Implementation(TsEffectFunctionLibrary.__InitializeWithPreview_FunctionParams* __Params)
	{
		TsEffectFunctionLibrary.InitializeWithPreview(__Params->refresh);
	}

	// Token: 0x06005AAD RID: 23213 RVA: 0x00164150 File Offset: 0x00162350
	protected unsafe static void __CPPCALL_EffectHandleIsValid_Implementation(TsEffectFunctionLibrary.__EffectHandleIsValid_FunctionParams* __Params)
	{
		__Params->__Result = TsEffectFunctionLibrary.EffectHandleIsValid(__Params->handle);
	}

	// Token: 0x06005AAE RID: 23214 RVA: 0x00164164 File Offset: 0x00162364
	protected unsafe static void __CPPCALL_StopEffect_Implementation(TsEffectFunctionLibrary.__StopEffect_FunctionParams* __Params)
	{
		UObject orCreateUObjectByNativePointer = BuiltinUtils.GetOrCreateUObjectByNativePointer<UObject>(__Params->callObject);
		string reason = FString.ToString((void*)(&__Params->reason));
		__Params->__Result = TsEffectFunctionLibrary.StopEffect(__Params->handle, orCreateUObjectByNativePointer, reason, __Params->immediately, __Params->destroyActor);
	}

	// Token: 0x06005AAF RID: 23215 RVA: 0x001641AC File Offset: 0x001623AC
	protected unsafe static void __CPPCALL_PlayEffect_Implementation(TsEffectFunctionLibrary.__PlayEffect_FunctionParams* __Params)
	{
		UObject orCreateUObjectByNativePointer = BuiltinUtils.GetOrCreateUObjectByNativePointer<UObject>(__Params->callObject);
		string reason = FString.ToString((void*)(&__Params->reason));
		__Params->__Result = TsEffectFunctionLibrary.PlayEffect(__Params->handle, orCreateUObjectByNativePointer, reason);
	}

	// Token: 0x06005AB0 RID: 23216 RVA: 0x001641E8 File Offset: 0x001623E8
	protected unsafe static void __CPPCALL_SetEffectParameterNiagara_Implementation(TsEffectFunctionLibrary.__SetEffectParameterNiagara_FunctionParams* __Params)
	{
		TArray<SEffectFloatParameter> tarray = new TArray<SEffectFloatParameter>(&__Params->userParameterFloat, true, true);
		TArray<SEffectColorParameter> tarray2 = new TArray<SEffectColorParameter>(&__Params->userParameterColor, true, true);
		TArray<SEffectVectorParameter> tarray3 = new TArray<SEffectVectorParameter>(&__Params->userParameterVector, true, true);
		TArray<SEffectFloatParameter> tarray4 = new TArray<SEffectFloatParameter>(&__Params->materialParameterFloat, true, true);
		TArray<SEffectColorParameter> tarray5 = new TArray<SEffectColorParameter>(&__Params->materialParameterColor, true, true);
		TsEffectFunctionLibrary.SetEffectParameterNiagara(__Params->handle, ref tarray, ref tarray2, ref tarray3, ref tarray4, ref tarray5);
		if (tarray != null)
		{
			tarray.CopyTo(&__Params->userParameterFloat, default(UScriptStructStackOnlyPtr));
		}
		if (tarray2 != null)
		{
			tarray2.CopyTo(&__Params->userParameterColor, default(UScriptStructStackOnlyPtr));
		}
		if (tarray3 != null)
		{
			tarray3.CopyTo(&__Params->userParameterVector, default(UScriptStructStackOnlyPtr));
		}
		if (tarray4 != null)
		{
			tarray4.CopyTo(&__Params->materialParameterFloat, default(UScriptStructStackOnlyPtr));
		}
		if (tarray5 != null)
		{
			tarray5.CopyTo(&__Params->materialParameterColor, default(UScriptStructStackOnlyPtr));
		}
	}

	// Token: 0x06005AB1 RID: 23217 RVA: 0x001642DA File Offset: 0x001624DA
	protected unsafe static void __CPPCALL_EditorTickHandle_Implementation(TsEffectFunctionLibrary.__EditorTickHandle_FunctionParams* __Params)
	{
		TsEffectFunctionLibrary.EditorTickHandle(__Params->handle, __Params->delta);
	}

	// Token: 0x06005AB2 RID: 23218 RVA: 0x001642ED File Offset: 0x001624ED
	protected unsafe static void __CPPCALL_GetEffectActor_Implementation(TsEffectFunctionLibrary.__GetEffectActor_FunctionParams* __Params)
	{
		ref IntPtr ptr = ref *(&__Params->__Result);
		AActor effectActor = TsEffectFunctionLibrary.GetEffectActor(__Params->handle);
		ptr = ((effectActor != null) ? effectActor.NativePtr : ((IntPtr)0));
	}

	// Token: 0x06005AB3 RID: 23219 RVA: 0x00164310 File Offset: 0x00162510
	protected unsafe static void __CPPCALL_AttachEffectActorToActor_Implementation(TsEffectFunctionLibrary.__AttachEffectActorToActor_FunctionParams* __Params)
	{
		AActor orCreateUObjectByNativePointer = BuiltinUtils.GetOrCreateUObjectByNativePointer<AActor>(__Params->parent);
		EAttachmentRule locationRule = (EAttachmentRule)__Params->locationRule;
		EAttachmentRule rotationRule = (EAttachmentRule)__Params->rotationRule;
		EAttachmentRule scaleRule = (EAttachmentRule)__Params->scaleRule;
		TsEffectFunctionLibrary.AttachEffectActorToActor(__Params->handle, orCreateUObjectByNativePointer, __Params->socketName, locationRule, rotationRule, scaleRule, __Params->bWeldSimulatedBodies);
	}

	// Token: 0x06005AB4 RID: 23220 RVA: 0x0016435C File Offset: 0x0016255C
	protected unsafe static void __CPPCALL_AttachEffectActorToComponent_Implementation(TsEffectFunctionLibrary.__AttachEffectActorToComponent_FunctionParams* __Params)
	{
		USceneComponent orCreateUObjectByNativePointer = BuiltinUtils.GetOrCreateUObjectByNativePointer<USceneComponent>(__Params->parent);
		EAttachmentRule locationRule = (EAttachmentRule)__Params->locationRule;
		EAttachmentRule rotationRule = (EAttachmentRule)__Params->rotationRule;
		EAttachmentRule scaleRule = (EAttachmentRule)__Params->scaleRule;
		TsEffectFunctionLibrary.AttachEffectActorToComponent(__Params->handle, orCreateUObjectByNativePointer, __Params->socketName, locationRule, rotationRule, scaleRule, __Params->bWeldSimulatedBodies);
	}

	// Token: 0x06005AB5 RID: 23221 RVA: 0x001643A5 File Offset: 0x001625A5
	protected unsafe static void __CPPCALL_SetEffectActorRelativeLocation_Implementation(TsEffectFunctionLibrary.__SetEffectActorRelativeLocation_FunctionParams* __Params)
	{
		TsEffectFunctionLibrary.SetEffectActorRelativeLocation(__Params->handle, __Params->newRelativeLocation, __Params->bSweep, __Params->bTeleport);
	}

	// Token: 0x06005AB6 RID: 23222 RVA: 0x001643C4 File Offset: 0x001625C4
	protected unsafe static void __CPPCALL_SetEffectHiddenInGame_Implementation(TsEffectFunctionLibrary.__SetEffectHiddenInGame_FunctionParams* __Params)
	{
		TsEffectFunctionLibrary.SetEffectHiddenInGame(__Params->handle, __Params->value);
	}

	// Token: 0x06005AB7 RID: 23223 RVA: 0x001643D7 File Offset: 0x001625D7
	protected unsafe static void __CPPCALL_SetEffectIgnoreVisibilityOptimize_Implementation(TsEffectFunctionLibrary.__SetEffectIgnoreVisibilityOptimize_FunctionParams* __Params)
	{
		TsEffectFunctionLibrary.SetEffectIgnoreVisibilityOptimize(__Params->handle, __Params->ignore);
	}

	// Token: 0x06005AB8 RID: 23224 RVA: 0x001643EA File Offset: 0x001625EA
	protected unsafe static void __CPPCALL_SetEffectStoppingTime_Implementation(TsEffectFunctionLibrary.__SetEffectStoppingTime_FunctionParams* __Params)
	{
		TsEffectFunctionLibrary.SetEffectStoppingTime(__Params->handle, __Params->stoppingTime);
	}

	// Token: 0x06005AB9 RID: 23225 RVA: 0x001643FD File Offset: 0x001625FD
	protected unsafe static void __CPPCALL_SetGlobalStoppingTime_Implementation(TsEffectFunctionLibrary.__SetGlobalStoppingTime_FunctionParams* __Params)
	{
		TsEffectFunctionLibrary.SetGlobalStoppingTime(__Params->stoppingTime, __Params->playTime);
	}

	// Token: 0x06005ABA RID: 23226 RVA: 0x00164410 File Offset: 0x00162610
	protected unsafe static void __CPPCALL_SetPublicToSequence_Implementation(TsEffectFunctionLibrary.__SetPublicToSequence_FunctionParams* __Params)
	{
		BP_EffectActor_C orCreateUObjectByNativePointer = BuiltinUtils.GetOrCreateUObjectByNativePointer<BP_EffectActor_C>(__Params->actor);
		TsEffectFunctionLibrary.SetPublicToSequence(__Params->handle, orCreateUObjectByNativePointer);
	}

	// Token: 0x06005ABB RID: 23227 RVA: 0x00164438 File Offset: 0x00162638
	protected unsafe static void __CPPCALL_SetSimulateFromSequence_Implementation(TsEffectFunctionLibrary.__SetSimulateFromSequence_FunctionParams* __Params)
	{
		BP_EffectActor_C orCreateUObjectByNativePointer = BuiltinUtils.GetOrCreateUObjectByNativePointer<BP_EffectActor_C>(__Params->actor);
		TsEffectFunctionLibrary.SetSimulateFromSequence(__Params->handle, orCreateUObjectByNativePointer);
	}

	// Token: 0x04002A08 RID: 10760
	private const int EFFECT_REASON_LENGTH_LIMIT = 4;

	// Token: 0x04002A09 RID: 10761
	[Nullable(1)]
	public new const string __ObjectPath = "/Game/Aki/TypeScript/Game/Effect/TsEffectFunctionLibrary.TsEffectFunctionLibrary_C";

	// Token: 0x04002A0A RID: 10762
	private static IntPtr _ClassPtr;

	// Token: 0x04002A0B RID: 10763
	private static IntPtr _ClassDefaultObjectPtr;

	// Token: 0x020072AB RID: 29355
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 144)]
	protected ref struct __SpawnEffect_FunctionParams
	{
		// Token: 0x04027C11 RID: 162833
		[FieldOffset(0)]
		public IntPtr worldContext;

		// Token: 0x04027C12 RID: 162834
		[FieldOffset(8)]
		public IntPtr callObject;

		// Token: 0x04027C13 RID: 162835
		[FieldOffset(16)]
		public FString path;

		// Token: 0x04027C14 RID: 162836
		[FieldOffset(32)]
		public FTransformDouble transform;

		// Token: 0x04027C15 RID: 162837
		[FieldOffset(96)]
		public FString reason;

		// Token: 0x04027C16 RID: 162838
		[FieldOffset(112)]
		public byte playType;

		// Token: 0x04027C17 RID: 162839
		[FieldOffset(113)]
		public bool disablePostProcess;

		// Token: 0x04027C18 RID: 162840
		[FieldOffset(120)]
		public IntPtr __WorldContext;

		// Token: 0x04027C19 RID: 162841
		[FieldOffset(128)]
		public int __Result;
	}

	// Token: 0x020072AC RID: 29356
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 128)]
	protected ref struct __SpawnEffectUI_FunctionParams
	{
		// Token: 0x04027C1A RID: 162842
		[FieldOffset(0)]
		public IntPtr worldContext;

		// Token: 0x04027C1B RID: 162843
		[FieldOffset(8)]
		public IntPtr callObject;

		// Token: 0x04027C1C RID: 162844
		[FieldOffset(16)]
		public FString path;

		// Token: 0x04027C1D RID: 162845
		[FieldOffset(32)]
		public FTransformDouble transform;

		// Token: 0x04027C1E RID: 162846
		[FieldOffset(96)]
		public FString reason;

		// Token: 0x04027C1F RID: 162847
		[FieldOffset(112)]
		public IntPtr __WorldContext;

		// Token: 0x04027C20 RID: 162848
		[FieldOffset(120)]
		public int __Result;
	}

	// Token: 0x020072AD RID: 29357
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 80)]
	protected ref struct __SpawnEffectWithActor_FunctionParams
	{
		// Token: 0x04027C21 RID: 162849
		[FieldOffset(0)]
		public IntPtr worldContext;

		// Token: 0x04027C22 RID: 162850
		[FieldOffset(8)]
		public IntPtr callObject;

		// Token: 0x04027C23 RID: 162851
		[FieldOffset(16)]
		public IntPtr effectActor;

		// Token: 0x04027C24 RID: 162852
		[FieldOffset(24)]
		public FString path;

		// Token: 0x04027C25 RID: 162853
		[FieldOffset(40)]
		public FString reason;

		// Token: 0x04027C26 RID: 162854
		[FieldOffset(56)]
		public byte playType;

		// Token: 0x04027C27 RID: 162855
		[FieldOffset(57)]
		public byte effectType;

		// Token: 0x04027C28 RID: 162856
		[FieldOffset(58)]
		public bool disablePostProcess;

		// Token: 0x04027C29 RID: 162857
		[FieldOffset(64)]
		public IntPtr __WorldContext;

		// Token: 0x04027C2A RID: 162858
		[FieldOffset(72)]
		public int __Result;
	}

	// Token: 0x020072AE RID: 29358
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 16)]
	protected ref struct __InitializeWithPreview_FunctionParams
	{
		// Token: 0x04027C2B RID: 162859
		[FieldOffset(0)]
		public bool refresh;

		// Token: 0x04027C2C RID: 162860
		[FieldOffset(8)]
		public IntPtr __WorldContext;
	}

	// Token: 0x020072AF RID: 29359
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 24)]
	protected ref struct __EffectHandleIsValid_FunctionParams
	{
		// Token: 0x04027C2D RID: 162861
		[FieldOffset(0)]
		public int handle;

		// Token: 0x04027C2E RID: 162862
		[FieldOffset(8)]
		public IntPtr __WorldContext;

		// Token: 0x04027C2F RID: 162863
		[FieldOffset(16)]
		public bool __Result;
	}

	// Token: 0x020072B0 RID: 29360
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 56)]
	protected ref struct __StopEffect_FunctionParams
	{
		// Token: 0x04027C30 RID: 162864
		[FieldOffset(0)]
		public int handle;

		// Token: 0x04027C31 RID: 162865
		[FieldOffset(8)]
		public IntPtr callObject;

		// Token: 0x04027C32 RID: 162866
		[FieldOffset(16)]
		public FString reason;

		// Token: 0x04027C33 RID: 162867
		[FieldOffset(32)]
		public bool immediately;

		// Token: 0x04027C34 RID: 162868
		[FieldOffset(33)]
		public bool destroyActor;

		// Token: 0x04027C35 RID: 162869
		[FieldOffset(40)]
		public IntPtr __WorldContext;

		// Token: 0x04027C36 RID: 162870
		[FieldOffset(48)]
		public bool __Result;
	}

	// Token: 0x020072B1 RID: 29361
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 48)]
	protected ref struct __PlayEffect_FunctionParams
	{
		// Token: 0x04027C37 RID: 162871
		[FieldOffset(0)]
		public int handle;

		// Token: 0x04027C38 RID: 162872
		[FieldOffset(8)]
		public IntPtr callObject;

		// Token: 0x04027C39 RID: 162873
		[FieldOffset(16)]
		public FString reason;

		// Token: 0x04027C3A RID: 162874
		[FieldOffset(32)]
		public IntPtr __WorldContext;

		// Token: 0x04027C3B RID: 162875
		[FieldOffset(40)]
		public bool __Result;
	}

	// Token: 0x020072B2 RID: 29362
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 96)]
	protected ref struct __SetEffectParameterNiagara_FunctionParams
	{
		// Token: 0x04027C3C RID: 162876
		[FieldOffset(0)]
		public int handle;

		// Token: 0x04027C3D RID: 162877
		[FieldOffset(8)]
		public byte userParameterFloat;

		// Token: 0x04027C3E RID: 162878
		[FieldOffset(24)]
		public byte userParameterColor;

		// Token: 0x04027C3F RID: 162879
		[FieldOffset(40)]
		public byte userParameterVector;

		// Token: 0x04027C40 RID: 162880
		[FieldOffset(56)]
		public byte materialParameterFloat;

		// Token: 0x04027C41 RID: 162881
		[FieldOffset(72)]
		public byte materialParameterColor;

		// Token: 0x04027C42 RID: 162882
		[FieldOffset(88)]
		public IntPtr __WorldContext;
	}

	// Token: 0x020072B3 RID: 29363
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 16)]
	protected ref struct __EditorTickHandle_FunctionParams
	{
		// Token: 0x04027C43 RID: 162883
		[FieldOffset(0)]
		public int handle;

		// Token: 0x04027C44 RID: 162884
		[FieldOffset(4)]
		public float delta;

		// Token: 0x04027C45 RID: 162885
		[FieldOffset(8)]
		public IntPtr __WorldContext;
	}

	// Token: 0x020072B4 RID: 29364
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 24)]
	protected ref struct __GetEffectActor_FunctionParams
	{
		// Token: 0x04027C46 RID: 162886
		[FieldOffset(0)]
		public int handle;

		// Token: 0x04027C47 RID: 162887
		[FieldOffset(8)]
		public IntPtr __WorldContext;

		// Token: 0x04027C48 RID: 162888
		[FieldOffset(16)]
		public IntPtr __Result;
	}

	// Token: 0x020072B5 RID: 29365
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 40)]
	protected ref struct __AttachEffectActorToActor_FunctionParams
	{
		// Token: 0x04027C49 RID: 162889
		[FieldOffset(0)]
		public int handle;

		// Token: 0x04027C4A RID: 162890
		[FieldOffset(8)]
		public IntPtr parent;

		// Token: 0x04027C4B RID: 162891
		[FieldOffset(16)]
		public FName socketName;

		// Token: 0x04027C4C RID: 162892
		[FieldOffset(28)]
		public byte locationRule;

		// Token: 0x04027C4D RID: 162893
		[FieldOffset(29)]
		public byte rotationRule;

		// Token: 0x04027C4E RID: 162894
		[FieldOffset(30)]
		public byte scaleRule;

		// Token: 0x04027C4F RID: 162895
		[FieldOffset(31)]
		public bool bWeldSimulatedBodies;

		// Token: 0x04027C50 RID: 162896
		[FieldOffset(32)]
		public IntPtr __WorldContext;
	}

	// Token: 0x020072B6 RID: 29366
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 40)]
	protected ref struct __AttachEffectActorToComponent_FunctionParams
	{
		// Token: 0x04027C51 RID: 162897
		[FieldOffset(0)]
		public int handle;

		// Token: 0x04027C52 RID: 162898
		[FieldOffset(8)]
		public IntPtr parent;

		// Token: 0x04027C53 RID: 162899
		[FieldOffset(16)]
		public FName socketName;

		// Token: 0x04027C54 RID: 162900
		[FieldOffset(28)]
		public byte locationRule;

		// Token: 0x04027C55 RID: 162901
		[FieldOffset(29)]
		public byte rotationRule;

		// Token: 0x04027C56 RID: 162902
		[FieldOffset(30)]
		public byte scaleRule;

		// Token: 0x04027C57 RID: 162903
		[FieldOffset(31)]
		public bool bWeldSimulatedBodies;

		// Token: 0x04027C58 RID: 162904
		[FieldOffset(32)]
		public IntPtr __WorldContext;
	}

	// Token: 0x020072B7 RID: 29367
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 48)]
	protected ref struct __SetEffectActorRelativeLocation_FunctionParams
	{
		// Token: 0x04027C59 RID: 162905
		[FieldOffset(0)]
		public int handle;

		// Token: 0x04027C5A RID: 162906
		[FieldOffset(8)]
		public FVectorDouble newRelativeLocation;

		// Token: 0x04027C5B RID: 162907
		[FieldOffset(32)]
		public bool bSweep;

		// Token: 0x04027C5C RID: 162908
		[FieldOffset(33)]
		public bool bTeleport;

		// Token: 0x04027C5D RID: 162909
		[FieldOffset(40)]
		public IntPtr __WorldContext;
	}

	// Token: 0x020072B8 RID: 29368
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 16)]
	protected ref struct __SetEffectHiddenInGame_FunctionParams
	{
		// Token: 0x04027C5E RID: 162910
		[FieldOffset(0)]
		public int handle;

		// Token: 0x04027C5F RID: 162911
		[FieldOffset(4)]
		public bool value;

		// Token: 0x04027C60 RID: 162912
		[FieldOffset(8)]
		public IntPtr __WorldContext;
	}

	// Token: 0x020072B9 RID: 29369
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 16)]
	protected ref struct __SetEffectIgnoreVisibilityOptimize_FunctionParams
	{
		// Token: 0x04027C61 RID: 162913
		[FieldOffset(0)]
		public int handle;

		// Token: 0x04027C62 RID: 162914
		[FieldOffset(4)]
		public bool ignore;

		// Token: 0x04027C63 RID: 162915
		[FieldOffset(8)]
		public IntPtr __WorldContext;
	}

	// Token: 0x020072BA RID: 29370
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 16)]
	protected ref struct __SetEffectStoppingTime_FunctionParams
	{
		// Token: 0x04027C64 RID: 162916
		[FieldOffset(0)]
		public int handle;

		// Token: 0x04027C65 RID: 162917
		[FieldOffset(4)]
		public bool stoppingTime;

		// Token: 0x04027C66 RID: 162918
		[FieldOffset(8)]
		public IntPtr __WorldContext;
	}

	// Token: 0x020072BB RID: 29371
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 16)]
	protected ref struct __SetGlobalStoppingTime_FunctionParams
	{
		// Token: 0x04027C67 RID: 162919
		[FieldOffset(0)]
		public bool stoppingTime;

		// Token: 0x04027C68 RID: 162920
		[FieldOffset(4)]
		public float playTime;

		// Token: 0x04027C69 RID: 162921
		[FieldOffset(8)]
		public IntPtr __WorldContext;
	}

	// Token: 0x020072BC RID: 29372
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 24)]
	protected ref struct __SetPublicToSequence_FunctionParams
	{
		// Token: 0x04027C6A RID: 162922
		[FieldOffset(0)]
		public int handle;

		// Token: 0x04027C6B RID: 162923
		[FieldOffset(8)]
		public IntPtr actor;

		// Token: 0x04027C6C RID: 162924
		[FieldOffset(16)]
		public IntPtr __WorldContext;
	}

	// Token: 0x020072BD RID: 29373
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 24)]
	protected ref struct __SetSimulateFromSequence_FunctionParams
	{
		// Token: 0x04027C6D RID: 162925
		[FieldOffset(0)]
		public int handle;

		// Token: 0x04027C6E RID: 162926
		[FieldOffset(8)]
		public IntPtr actor;

		// Token: 0x04027C6F RID: 162927
		[FieldOffset(16)]
		public IntPtr __WorldContext;
	}
}
