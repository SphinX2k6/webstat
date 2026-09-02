using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using AkiClient.Game.Aki.Character.BaseCharacter;
using AkiClient.Game.Aki.Character.BaseCharacter.Camera;
using CSharpScript.Game.Camera;
using UnrealEngine;

// Token: 0x02002C43 RID: 11331
[NullableContext(1)]
[Nullable(0)]
public class UiCamera
{
	// Token: 0x06016B18 RID: 92952 RVA: 0x0064CEF8 File Offset: 0x0064B0F8
	public UiCamera()
	{
		this.UiCameraComponentMap = new Dictionary<Type, UiCameraComponent>();
		this.UiCameraStructureStack = new global::Stack<UiCameraStructure>();
	}

	// Token: 0x06016B19 RID: 92953 RVA: 0x0064CF18 File Offset: 0x0064B118
	public bool Initialize()
	{
		WidgetCamera widgetCamera = ControllerBase<CameraController>.Instance.MainModel.WidgetCamera;
		if (widgetCamera == null)
		{
			Singleton<Log>.Instance.Warn(ELogModule.UiCamera, ELogAuthor.BB, "初始化界面摄像机时，找不到 widgetCamera 组件", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		WidgetCameraDisplayComponent component = widgetCamera.GetComponent<WidgetCameraDisplayComponent>();
		if (!component.Valid)
		{
			Singleton<Log>.Instance.Warn(ELogModule.UiCamera, ELogAuthor.BB, "初始化界面摄像机时，找不到 WidgetCameraDisplayComponent 组件", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		BP_CineCamera_C cineCamera = component.CineCamera;
		if (cineCamera == null || !cineCamera.IsValid())
		{
			Singleton<Log>.Instance.Warn(ELogModule.UiCamera, ELogAuthor.BB, "初始化界面摄像机时，CameraActor不可用", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		this.CameraActor = cineCamera;
		this.CameraActor.SetTickableWhenPaused(true);
		this.CineCameraComponent = cineCamera.GetCineCameraComponent();
		UCineCameraComponent cineCameraComponent = this.CineCameraComponent;
		if (cineCameraComponent != null)
		{
			cineCameraComponent.SetTickableWhenPaused(true);
		}
		this.AddUiCameraComponent(typeof(UiCameraPostEffectComponent), true);
		this.AddUiCameraComponent(typeof(UiCameraSequenceComponent), true);
		return true;
	}

	// Token: 0x06016B1A RID: 92954 RVA: 0x0064D00F File Offset: 0x0064B20F
	public void Destroy(float blendTime = 0f, EViewTargetBlendFunction blendFunction = EViewTargetBlendFunction.VTBlend_Linear, float blendExp = 0f)
	{
		this.Exit(blendTime, blendFunction, blendExp);
		this.ClearAllUiCameraComponent();
		this.CameraActor = null;
		this.CineCameraComponent = null;
	}

	// Token: 0x06016B1B RID: 92955 RVA: 0x0064D030 File Offset: 0x0064B230
	public void SetWorldLocation(FVectorDouble location)
	{
		BP_CineCamera_C cameraActor = this.CameraActor;
		if (cameraActor == null || !cameraActor.IsValid())
		{
			return;
		}
		FHitResult fhitResult = new FHitResult();
		this.CameraActor.D_K2_SetActorLocation(location, false, ref fhitResult, false);
	}

	// Token: 0x06016B1C RID: 92956 RVA: 0x0064D06C File Offset: 0x0064B26C
	public void SetWorldRotation(FRotator rotation)
	{
		BP_CineCamera_C cameraActor = this.CameraActor;
		if (cameraActor == null || !cameraActor.IsValid())
		{
			return;
		}
		this.CameraActor.K2_SetActorRotation(rotation, false);
	}

	// Token: 0x06016B1D RID: 92957 RVA: 0x0064D094 File Offset: 0x0064B294
	[NullableContext(2)]
	public unsafe void Enter(float blendTime = 0f, EViewTargetBlendFunction blendFunction = EViewTargetBlendFunction.VTBlend_Linear, float blendExp = 0f, Action callback = null)
	{
		if (this.IsEntered)
		{
			ControllerBase<CameraController>.Instance.EnterCameraMode(ECustomCameraMode.Widget, blendTime, blendFunction, blendExp, null, false, "MainCamera", null);
			return;
		}
		Log instance = Singleton<Log>.Instance;
		ELogModule module = ELogModule.UiCamera;
		ELogAuthor author = ELogAuthor.BB;
		string message = "进入Ui相机";
		<>y__InlineArray3<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray3<ValueTuple<string, object>>);
		*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("blendTime", blendTime);
		*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("blendFunction", blendFunction);
		*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 2) = new ValueTuple<string, object>("blendExp", blendExp);
		instance.Info(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 3));
		foreach (UiCameraComponent uiCameraComponent in this.UiCameraComponentMap.Values)
		{
			uiCameraComponent.Activate();
		}
		ControllerBase<CameraController>.Instance.EnterCameraMode(ECustomCameraMode.Widget, blendTime, blendFunction, blendExp, callback, false, "MainCamera", null);
		this.IsEntered = true;
	}

	// Token: 0x06016B1E RID: 92958 RVA: 0x0064D1A4 File Offset: 0x0064B3A4
	public unsafe void Exit(float blendTime = 0f, EViewTargetBlendFunction blendFunction = EViewTargetBlendFunction.VTBlend_Linear, float blendExp = 0f)
	{
		if (!this.IsEntered)
		{
			ControllerBase<CameraController>.Instance.ExitCameraMode(ECustomCameraMode.Widget, blendTime, blendFunction, blendExp, null, "MainCamera", null);
			return;
		}
		Log instance = Singleton<Log>.Instance;
		ELogModule module = ELogModule.UiCamera;
		ELogAuthor author = ELogAuthor.BB;
		string message = "退出Ui相机";
		<>y__InlineArray3<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray3<ValueTuple<string, object>>);
		*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("blendTime", blendTime);
		*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("blendFunction", blendFunction);
		*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 2) = new ValueTuple<string, object>("blendExp", blendExp);
		instance.Info(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 3));
		if (ModelBase<CameraModel>.Instance.MainModel.LogicHideHeadEnabled)
		{
			ControllerBase<CameraController>.Instance.ExitCameraMode(ECustomCameraMode.Widget, 0f, EViewTargetBlendFunction.VTBlend_Linear, 0f, null, "MainCamera", null);
		}
		else
		{
			ControllerBase<CameraController>.Instance.ExitCameraMode(ECustomCameraMode.Widget, blendTime, blendFunction, blendExp, null, "MainCamera", null);
		}
		foreach (UiCameraComponent uiCameraComponent in this.UiCameraComponentMap.Values)
		{
			uiCameraComponent.Deactivate();
		}
		this.ClearStructure();
		this.IsEntered = false;
	}

	// Token: 0x06016B1F RID: 92959 RVA: 0x0064D2E8 File Offset: 0x0064B4E8
	[NullableContext(0)]
	[return: Nullable(2)]
	public unsafe T PushStructure<T>() where T : UiCameraStructure, new()
	{
		Log instance = Singleton<Log>.Instance;
		ELogModule module = ELogModule.UiCamera;
		ELogAuthor author = ELogAuthor.JYS;
		string message = "PushStructure:";
		<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
		ref ValueTuple<string, object> ptr = ref <PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0);
		string item = "this.UiCameraStructureStack.Peek()?.constructor.name";
		UiCameraStructure uiCameraStructure = this.UiCameraStructureStack.Peek();
		ptr = new ValueTuple<string, object>(item, (uiCameraStructure != null) ? uiCameraStructure.GetType().Name : null);
		*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("uiCameraStructureClass.name", typeof(T).Name);
		instance.Info(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
		UiCameraStructure uiCameraStructure2 = this.UiCameraStructureStack.Peek();
		if (((uiCameraStructure2 != null) ? uiCameraStructure2.GetType() : null) == typeof(T))
		{
			Log instance2 = Singleton<Log>.Instance;
			ELogModule module2 = ELogModule.UiCamera;
			ELogAuthor author2 = ELogAuthor.JYS;
			string message2 = "PushStructure时，已经有相同的UiCameraStructure，直接返回此UiCameraStructure:";
			string item2 = "Name";
			UiCameraStructure uiCameraStructure3 = this.UiCameraStructureStack.Peek();
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>(item2, (uiCameraStructure3 != null) ? uiCameraStructure3.GetType().Name : null);
			instance2.Info(module2, author2, message2, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			return this.UiCameraStructureStack.Peek() as T;
		}
		UiCameraStructure uiCameraStructure4 = Activator.CreateInstance<T>();
		uiCameraStructure4.Initialize(this);
		uiCameraStructure4.Activate();
		this.UiCameraStructureStack.Push(uiCameraStructure4);
		return uiCameraStructure4 as T;
	}

	// Token: 0x06016B20 RID: 92960 RVA: 0x0064D420 File Offset: 0x0064B620
	public void PopStructure()
	{
		this.UiCameraStructureStack.Pop().Destroy();
		UiCameraStructure uiCameraStructure = this.UiCameraStructureStack.Peek();
		if (uiCameraStructure == null)
		{
			return;
		}
		uiCameraStructure.Activate();
	}

	// Token: 0x06016B21 RID: 92961 RVA: 0x0064D447 File Offset: 0x0064B647
	public UiCameraStructure GetStructure()
	{
		return this.UiCameraStructureStack.Peek();
	}

	// Token: 0x06016B22 RID: 92962 RVA: 0x0064D454 File Offset: 0x0064B654
	public void ClearStructure()
	{
		foreach (UiCameraStructure uiCameraStructure in this.UiCameraStructureStack)
		{
			uiCameraStructure.Destroy();
		}
		this.UiCameraStructureStack.Clear();
	}

	// Token: 0x06016B23 RID: 92963 RVA: 0x0064D4AC File Offset: 0x0064B6AC
	public UiCameraComponent AddUiCameraComponent(Type componentClass, bool bAutoActivate = true)
	{
		UiCameraComponent uiCameraComponent;
		if (!this.UiCameraComponentMap.TryGetValue(componentClass, out uiCameraComponent))
		{
			uiCameraComponent = (Activator.CreateInstance(componentClass) as UiCameraComponent);
			uiCameraComponent.Initialize(this);
			this.UiCameraComponentMap[componentClass] = uiCameraComponent;
		}
		if (this.IsEntered && bAutoActivate)
		{
			uiCameraComponent.Activate();
		}
		return uiCameraComponent;
	}

	// Token: 0x06016B24 RID: 92964 RVA: 0x0064D4FC File Offset: 0x0064B6FC
	public void DestroyUiCameraComponent(Type componentClass)
	{
		UiCameraComponent uiCameraComponent;
		if (!this.UiCameraComponentMap.TryGetValue(componentClass, out uiCameraComponent))
		{
			return;
		}
		uiCameraComponent.Destroy();
		this.UiCameraComponentMap.Remove(componentClass);
	}

	// Token: 0x06016B25 RID: 92965 RVA: 0x0064D530 File Offset: 0x0064B730
	private void ClearAllUiCameraComponent()
	{
		foreach (UiCameraComponent uiCameraComponent in this.UiCameraComponentMap.Values)
		{
			uiCameraComponent.Destroy();
		}
		this.UiCameraComponentMap.Clear();
	}

	// Token: 0x06016B26 RID: 92966 RVA: 0x0064D590 File Offset: 0x0064B790
	public T GetUiCameraComponent<[Nullable(0)] T>() where T : UiCameraComponent
	{
		return this.UiCameraComponentMap[typeof(T)] as T;
	}

	// Token: 0x06016B27 RID: 92967 RVA: 0x0064D5B1 File Offset: 0x0064B7B1
	public BP_CineCamera_C GetCameraActor()
	{
		return this.CameraActor;
	}

	// Token: 0x06016B28 RID: 92968 RVA: 0x0064D5B9 File Offset: 0x0064B7B9
	public UCineCameraComponent GetCineCameraComponent()
	{
		return this.CineCameraComponent;
	}

	// Token: 0x06016B29 RID: 92969 RVA: 0x0064D5C1 File Offset: 0x0064B7C1
	public bool GetIsEntered()
	{
		return this.IsEntered;
	}

	// Token: 0x0400AEF9 RID: 44793
	[Nullable(2)]
	protected BP_CineCamera_C CameraActor;

	// Token: 0x0400AEFA RID: 44794
	[Nullable(2)]
	protected UCineCameraComponent CineCameraComponent;

	// Token: 0x0400AEFB RID: 44795
	private readonly Dictionary<Type, UiCameraComponent> UiCameraComponentMap;

	// Token: 0x0400AEFC RID: 44796
	private readonly global::Stack<UiCameraStructure> UiCameraStructureStack;

	// Token: 0x0400AEFD RID: 44797
	private bool IsEntered;
}
