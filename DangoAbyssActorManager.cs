using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnrealEngine;

// Token: 0x02001AB4 RID: 6836
[NullableContext(1)]
[Nullable(0)]
public class DangoAbyssActorManager : IStaticVariableResetter
{
	// Token: 0x0600C415 RID: 50197 RVA: 0x0033BF7B File Offset: 0x0033A17B
	static DangoAbyssActorManager()
	{
		StaticVariableRegister.RegisterAndExecute(new Action(DangoAbyssActorManager.CreateStaticDefaultValue), new Action(DangoAbyssActorManager.ResetStaticDefaultValue));
	}

	// Token: 0x0600C416 RID: 50198 RVA: 0x0033BF9A File Offset: 0x0033A19A
	public static void CreateStaticDefaultValue()
	{
		DangoAbyssActorManager.CreateUseWay = EUiModelUseWay.AbyssDango;
		DangoAbyssActorManager.DangoSkeletalObserverHandleMap = new Dictionary<int, SkeletalObserverHandle>();
	}

	// Token: 0x0600C417 RID: 50199 RVA: 0x0033BFAD File Offset: 0x0033A1AD
	public static void ResetStaticDefaultValue()
	{
		DangoAbyssActorManager.CreateUseWay = EUiModelUseWay.RoleInLogin;
		DangoAbyssActorManager.DangoSkeletalObserverHandleMap = null;
	}

	// Token: 0x0600C418 RID: 50200 RVA: 0x0033BFBC File Offset: 0x0033A1BC
	public static void InitIndexDangoSkeletalObserverHandle(int index)
	{
		SkeletalObserverHandle value;
		if (!DangoAbyssActorManager.DangoSkeletalObserverHandleMap.TryGetValue(index, out value))
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.Activity;
			ELogAuthor author = ELogAuthor.YZY;
			string message = "初始化 DangoActorObserver";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("index", index);
			instance.Info(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			value = SkeletalObserverManager.NewSkeletalObserver(DangoAbyssActorManager.CreateUseWay);
			DangoAbyssActorManager.DangoSkeletalObserverHandleMap.Add(index, value);
		}
	}

	// Token: 0x0600C419 RID: 50201 RVA: 0x0033C020 File Offset: 0x0033A220
	public unsafe static void RefreshDangoSkeletalObserverHandle(int index, DangoAbyssDefine.IDangoAbyssActorData data, [Nullable(2)] Action callBack)
	{
		DangoAbyssActorManager.<>c__DisplayClass6_0 CS$<>8__locals1 = new DangoAbyssActorManager.<>c__DisplayClass6_0();
		CS$<>8__locals1.data = data;
		CS$<>8__locals1.callBack = callBack;
		SkeletalObserverHandle skeletalObserverHandle;
		DangoAbyssActorManager.DangoSkeletalObserverHandleMap.TryGetValue(index, out skeletalObserverHandle);
		if (skeletalObserverHandle == null || skeletalObserverHandle.Model == null)
		{
			DangoAbyssActorManager.DestroyDangoSkeletalObserverHandle(index);
			DangoAbyssActorManager.InitIndexDangoSkeletalObserverHandle(index);
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.Activity;
			ELogAuthor author = ELogAuthor.YZY;
			string message = "RefreshDangoSkeletalObserverHandle使用错误";
			<>y__InlineArray3<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray3<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("index", index);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("handleExist", skeletalObserverHandle != null);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 2) = new ValueTuple<string, object>("modelExist", ((skeletalObserverHandle != null) ? skeletalObserverHandle.Model : null) != null);
			instance.Error(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 3));
			DangoAbyssActorManager.DangoSkeletalObserverHandleMap.TryGetValue(index, out skeletalObserverHandle);
		}
		if (skeletalObserverHandle == null)
		{
			Log instance2 = Singleton<Log>.Instance;
			ELogModule module2 = ELogModule.Activity;
			ELogAuthor author2 = ELogAuthor.YZY;
			string message2 = "没有初始化index observer";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("index", index);
			instance2.Error(module2, author2, message2, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			return;
		}
		UiModelBase model = skeletalObserverHandle.Model;
		CS$<>8__locals1.meshId = CS$<>8__locals1.data.MeshId;
		UiModelDataComponent uiModelDataComponent = model.CheckGetComponent<UiModelDataComponent>();
		if (uiModelDataComponent != null && uiModelDataComponent.ModelConfigId == CS$<>8__locals1.meshId)
		{
			if (uiModelDataComponent.GetModelLoadState() == EUiModelLoadState.LoadComplete)
			{
				Action callBack2 = CS$<>8__locals1.callBack;
				if (callBack2 == null)
				{
					return;
				}
				callBack2();
			}
			return;
		}
		if (ConfigBase<SkeletalObserverConfig>.Instance.GetMeshConfig(CS$<>8__locals1.meshId) == null)
		{
			return;
		}
		CS$<>8__locals1.actorComponent = model.CheckGetComponent<UiModelActorComponent>();
		CS$<>8__locals1.animationComponent = model.CheckGetComponent<UiModelAnimationComponent>();
		CS$<>8__locals1.animationComponent.StopAnimation();
		string dangoPointCase = CS$<>8__locals1.data.DangoPointCase;
		CS$<>8__locals1.actorComponent.SetTransformByTag(dangoPointCase);
		CS$<>8__locals1.loadComponent = model.CheckGetComponent<UiAbyssDangoLoadComponent>();
		CS$<>8__locals1.animationComponent.SetAnimationMode(EAnimationMode.AnimationSingleNode);
		string standAnimationName = CS$<>8__locals1.data.StandAnimationName;
		Singleton<ResourceSystem>.Instance.LoadAsync<UAnimationAsset>(standAnimationName, delegate([Nullable(2)] UAnimationAsset result, string _)
		{
			if (result != null)
			{
				CS$<>8__locals1.loadComponent.LoadModelByDangoId(CS$<>8__locals1.data.DangoId, CS$<>8__locals1.meshId, true, delegate
				{
					CS$<>8__locals1.<RefreshDangoSkeletalObserverHandle>g__loadFinishCallBack|0(result);
				});
			}
		}, 100, "Ui.DangoUi");
	}

	// Token: 0x0600C41A RID: 50202 RVA: 0x0033C22C File Offset: 0x0033A42C
	public static void RefreshSkeletalObserverAnimation(int index, string animationName, bool loop)
	{
		SkeletalObserverHandle skeletalObserverHandle;
		if (DangoAbyssActorManager.DangoSkeletalObserverHandleMap.TryGetValue(index, out skeletalObserverHandle))
		{
			UiModelBase model = skeletalObserverHandle.Model;
			UiModelAnimationComponent animationComponent = model.CheckGetComponent<UiModelAnimationComponent>();
			animationComponent.StopAnimation();
			Singleton<ResourceSystem>.Instance.LoadAsync<UAnimationAsset>(animationName, delegate(UAnimationAsset result, string _)
			{
				if (result != null)
				{
					animationComponent.PlayAnimation(result, loop);
				}
			}, 100, "Ui.DangoUi");
			return;
		}
		Log instance = Singleton<Log>.Instance;
		ELogModule module = ELogModule.Activity;
		ELogAuthor author = ELogAuthor.YZY;
		string message = "没有初始化index observer";
		ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("index", index);
		instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
	}

	// Token: 0x0600C41B RID: 50203 RVA: 0x0033C2C4 File Offset: 0x0033A4C4
	public static void ClearAllDangoSkeletalObserverHandle()
	{
		foreach (SkeletalObserverHandle skeletalObserverHandle in DangoAbyssActorManager.DangoSkeletalObserverHandleMap.Values)
		{
			SkeletalObserverManager.DestroySkeletalObserver(skeletalObserverHandle);
		}
		DangoAbyssActorManager.DangoSkeletalObserverHandleMap.Clear();
	}

	// Token: 0x0600C41C RID: 50204 RVA: 0x0033C324 File Offset: 0x0033A524
	public static void DestroyDangoSkeletalObserverHandle(int index)
	{
		SkeletalObserverHandle skeletalObserverHandle;
		if (DangoAbyssActorManager.DangoSkeletalObserverHandleMap.TryGetValue(index, out skeletalObserverHandle))
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.Activity;
			ELogAuthor author = ELogAuthor.YZY;
			string message = "销毁 DangoActorObserver";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("index", index);
			instance.Info(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			SkeletalObserverManager.DestroySkeletalObserver(skeletalObserverHandle);
			DangoAbyssActorManager.DangoSkeletalObserverHandleMap.Remove(index);
		}
	}

	// Token: 0x04005E2D RID: 24109
	private static EUiModelUseWay CreateUseWay;

	// Token: 0x04005E2E RID: 24110
	private static Dictionary<int, SkeletalObserverHandle> DangoSkeletalObserverHandleMap;
}
