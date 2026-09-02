using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x02001F90 RID: 8080
[NullableContext(1)]
[Nullable(0)]
public abstract class HudUnitHandleBase
{
	// Token: 0x0600F242 RID: 62018 RVA: 0x00423549 File Offset: 0x00421749
	public void Initialize()
	{
		this.PlayerController = Global.CharacterController;
		this.PlayerCameraManager = Global.CharacterCameraManager;
		this.HudItem = Singleton<UiLayer>.Instance.GetBattleViewUnit(1);
		this.OnAddEvents();
		this.OnInitialize();
	}

	// Token: 0x0600F243 RID: 62019 RVA: 0x00423580 File Offset: 0x00421780
	protected void InitCursorAxis()
	{
		float num = (float)ConfigCommonParamById.GetIntConfig("MonsterCursorWidthToScreenPercent").Value / 100f;
		float num2 = (float)ConfigCommonParamById.GetIntConfig("MonsterCursorHeightToScreenPercent").Value / 100f;
		this.MajorAxis = this.HudItem.GetWidth() * num;
		this.MinorAxis = this.HudItem.GetHeight() * num2;
	}

	// Token: 0x0600F244 RID: 62020 RVA: 0x004235E7 File Offset: 0x004217E7
	public void Destroy()
	{
		this.OnDestroyed();
		this.OnRemoveEvents();
		this.DestroyAllHudUnit();
		this.IsDestroyed = true;
		HudEntitySet hudEntitySet = this.HudEntitySet;
		if (hudEntitySet != null)
		{
			hudEntitySet.Clear();
		}
		this.HudEntitySet = null;
	}

	// Token: 0x0600F245 RID: 62021 RVA: 0x0042361C File Offset: 0x0042181C
	public void Tick(float delta)
	{
		this.OnTick(delta);
		foreach (HudUnitBase hudUnitBase in this.HudUnitSet)
		{
			hudUnitBase.Tick(delta);
		}
	}

	// Token: 0x0600F246 RID: 62022 RVA: 0x00423674 File Offset: 0x00421874
	public void AfterTick(float delta)
	{
		this.OnAfterTick(delta);
		foreach (HudUnitBase hudUnitBase in this.HudUnitSet)
		{
			hudUnitBase.AfterTick(delta);
		}
	}

	// Token: 0x0600F247 RID: 62023 RVA: 0x004236CC File Offset: 0x004218CC
	protected virtual void OnInitialize()
	{
	}

	// Token: 0x0600F248 RID: 62024 RVA: 0x004236CE File Offset: 0x004218CE
	protected virtual void OnDestroyed()
	{
	}

	// Token: 0x0600F249 RID: 62025 RVA: 0x004236D0 File Offset: 0x004218D0
	protected virtual void OnTick(float delta)
	{
	}

	// Token: 0x0600F24A RID: 62026 RVA: 0x004236D2 File Offset: 0x004218D2
	protected virtual void OnAfterTick(float delta)
	{
	}

	// Token: 0x0600F24B RID: 62027 RVA: 0x004236D4 File Offset: 0x004218D4
	public virtual void OnShowHud()
	{
		this.IsHudVisible = true;
	}

	// Token: 0x0600F24C RID: 62028 RVA: 0x004236DD File Offset: 0x004218DD
	public void OnHideHud()
	{
		this.IsHudVisible = false;
	}

	// Token: 0x0600F24D RID: 62029 RVA: 0x004236E6 File Offset: 0x004218E6
	public virtual void OnInputControllerChanged(EInputControllerType last, EInputControllerType now)
	{
	}

	// Token: 0x0600F24E RID: 62030
	protected abstract void OnAddEvents();

	// Token: 0x0600F24F RID: 62031
	protected abstract void OnRemoveEvents();

	// Token: 0x0600F250 RID: 62032 RVA: 0x004236E8 File Offset: 0x004218E8
	[return: Nullable(new byte[]
	{
		0,
		2
	})]
	protected UniTask<T> NewHudUnit<[Nullable(0)] T>(Type hudUnitClass, string resourceId, bool showAfterCreate = true, bool needSafeZone = false) where T : HudUnitBase
	{
		HudUnitHandleBase.<NewHudUnit>d__31<T> <NewHudUnit>d__;
		<NewHudUnit>d__.<>t__builder = AsyncUniTaskMethodBuilder<T>.Create();
		<NewHudUnit>d__.<>4__this = this;
		<NewHudUnit>d__.hudUnitClass = hudUnitClass;
		<NewHudUnit>d__.resourceId = resourceId;
		<NewHudUnit>d__.showAfterCreate = showAfterCreate;
		<NewHudUnit>d__.needSafeZone = needSafeZone;
		<NewHudUnit>d__.<>1__state = -1;
		<NewHudUnit>d__.<>t__builder.Start<HudUnitHandleBase.<NewHudUnit>d__31<T>>(ref <NewHudUnit>d__);
		return <NewHudUnit>d__.<>t__builder.Task;
	}

	// Token: 0x0600F251 RID: 62033 RVA: 0x0042374C File Offset: 0x0042194C
	protected void NewHudUnitWithReturn<[Nullable(0)] T>(Type hudUnitClass, string resourceId, out T outHudUnit, bool showAfterCreate = true, [Nullable(new byte[]
	{
		2,
		1
	})] Action<T> onLoadedFinished = null, bool needSafeZone = false) where T : HudUnitBase
	{
		HudUnitBase hudUnitBase = Activator.CreateInstance(hudUnitClass) as HudUnitBase;
		T result = hudUnitBase as T;
		outHudUnit = result;
		hudUnitBase.Initialize(resourceId, showAfterCreate, needSafeZone).ContinueWith(delegate()
		{
			if (onLoadedFinished != null)
			{
				onLoadedFinished(result);
			}
		});
		this.HudUnitSet.Add(hudUnitBase);
	}

	// Token: 0x0600F252 RID: 62034 RVA: 0x004237BA File Offset: 0x004219BA
	protected void DestroyHudUnit(HudUnitBase hudUnit)
	{
		if (hudUnit == null)
		{
			return;
		}
		hudUnit.Destroy(null);
		this.HudUnitSet.Remove(hudUnit);
	}

	// Token: 0x0600F253 RID: 62035 RVA: 0x004237D4 File Offset: 0x004219D4
	protected void DestroyAllHudUnit()
	{
		foreach (HudUnitBase hudUnitBase in this.HudUnitSet)
		{
			hudUnitBase.Destroy(null);
		}
		this.HudUnitSet.Clear();
	}

	// Token: 0x0600F254 RID: 62036 RVA: 0x00423830 File Offset: 0x00421A30
	protected void NewHudEntitySet()
	{
		this.HudEntitySet = new HudEntitySet();
		this.HudEntitySet.Initialize();
	}

	// Token: 0x0600F255 RID: 62037 RVA: 0x00423848 File Offset: 0x00421A48
	private float GetViewportSizeX()
	{
		int num = 0;
		this.PlayerController.GetViewportSize(ref this.ViewportSizeX, ref num);
		return (float)this.ViewportSizeX;
	}

	// Token: 0x0600F256 RID: 62038 RVA: 0x00423871 File Offset: 0x00421A71
	private FVector2D GetUiRootItemSize()
	{
		return new FVector2D(this.HudItem.GetWidth(), this.HudItem.GetHeight());
	}

	// Token: 0x0600F257 RID: 62039 RVA: 0x00423890 File Offset: 0x00421A90
	private FVector2D ClampToEllipse(FVector2D vector, float majorAxis, float minorAxis, bool isInScreen)
	{
		float x = vector.X;
		float y = vector.Y;
		if (isInScreen && x * x / (majorAxis * majorAxis) + y * y / (minorAxis * minorAxis) <= 1f)
		{
			return vector;
		}
		float scale = majorAxis * minorAxis / (float)Math.Sqrt((double)(minorAxis * minorAxis * x * x + majorAxis * majorAxis * y * y));
		return vector * scale;
	}

	// Token: 0x0600F258 RID: 62040 RVA: 0x004238EC File Offset: 0x00421AEC
	protected FVector2D ScreenPositionToEllipsePosition(FVector2D screenPosition, bool isInScreen)
	{
		float viewportSizeX = this.GetViewportSizeX();
		FVector2D uiRootItemSize = this.GetUiRootItemSize();
		FVector2D vector = screenPosition * (uiRootItemSize.X / viewportSizeX);
		FVector2D fvector2D = uiRootItemSize * 0.5f;
		vector = vector - fvector2D;
		vector = vector * this.PointTransport;
		FVector2D fvector2D2 = this.ClampToEllipse(vector, this.MajorAxis, this.MinorAxis, isInScreen);
		return fvector2D2 + this.Center;
	}

	// Token: 0x0600F259 RID: 62041 RVA: 0x0042395F File Offset: 0x00421B5F
	private global::Vector GetTargetToPlayerVector(global::Vector playerLocation, global::Vector targetLocation)
	{
		targetLocation.Subtraction(playerLocation, this.TargetToPlayerVector);
		return this.TargetToPlayerVector;
	}

	// Token: 0x0600F25A RID: 62042 RVA: 0x00423978 File Offset: 0x00421B78
	private FVectorDouble GetCameraForwardVector()
	{
		return this.PlayerCameraManager.GetCameraRotation().VectorDouble();
	}

	// Token: 0x0600F25B RID: 62043 RVA: 0x00423998 File Offset: 0x00421B98
	protected global::Vector GetProjectionToFrontPosition(global::Vector playerLocation, FVectorDouble targetLocation)
	{
		this.TargetLocation.Set(targetLocation.X, targetLocation.Y, targetLocation.Z);
		global::Vector targetToPlayerVector = this.GetTargetToPlayerVector(playerLocation, this.TargetLocation);
		FVectorDouble cameraForwardVector = this.GetCameraForwardVector();
		FVectorDouble fvectorDouble = UKismetMathLibrary.D_ProjectVectorOnToVector(targetToPlayerVector.ToUeVector(false), cameraForwardVector);
		FVectorDouble fvectorDouble2 = fvectorDouble * 2.0;
		this.ProjectScreenLocation.Set(fvectorDouble2.X, fvectorDouble2.Y, fvectorDouble2.Z);
		targetToPlayerVector.SubtractionEqual(this.ProjectScreenLocation);
		playerLocation.Addition(targetToPlayerVector, this.TargetLocation);
		return this.TargetLocation;
	}

	// Token: 0x0600F25C RID: 62044 RVA: 0x00423A34 File Offset: 0x00421C34
	protected FVector2D? ProjectWorldToScreen(FVectorDouble worldLocation)
	{
		if (!UGameplayStatics.D_ProjectWorldToScreen(this.PlayerController, worldLocation, ref this.ScreenPositionRef, false))
		{
			return null;
		}
		return new FVector2D?(this.HudItem.GetCanvasScaler().ConvertPositionFromViewportToLGUICanvas(this.ScreenPositionRef));
	}

	// Token: 0x0600F25D RID: 62045 RVA: 0x00423A7C File Offset: 0x00421C7C
	[NullableContext(0)]
	protected ValueTuple<FVector2D, FVector2D?> GetInEllipsePosition([Nullable(1)] global::Vector playerLocation, FVectorDouble entityLocation)
	{
		bool flag = UGameplayStatics.D_ProjectWorldToScreen(this.PlayerController, entityLocation, ref this.ScreenPositionRef, false);
		FVector fvector = this.ScreenPositionRef;
		FVector2D screenPosition = new FVector2D(ref fvector);
		if (flag)
		{
			return new ValueTuple<FVector2D, FVector2D?>(this.ScreenPositionToEllipsePosition(screenPosition, true), new FVector2D?(this.ScreenPositionRef));
		}
		global::Vector projectionToFrontPosition = this.GetProjectionToFrontPosition(playerLocation, entityLocation);
		APlayerController playerController = this.PlayerController;
		FVectorDouble fvectorDouble = projectionToFrontPosition.ToUeVector(false);
		UGameplayStatics.D_ProjectWorldToScreen(playerController, fvectorDouble, ref this.ScreenPositionRef, false);
		return new ValueTuple<FVector2D, FVector2D?>(this.ScreenPositionToEllipsePosition(screenPosition, false), null);
	}

	// Token: 0x04007454 RID: 29780
	private const float CenterY = 62.5f;

	// Token: 0x04007455 RID: 29781
	private readonly HashSet<HudUnitBase> HudUnitSet = new HashSet<HudUnitBase>();

	// Token: 0x04007456 RID: 29782
	[Nullable(2)]
	protected HudEntitySet HudEntitySet;

	// Token: 0x04007457 RID: 29783
	[Nullable(2)]
	private APlayerController PlayerController;

	// Token: 0x04007458 RID: 29784
	[Nullable(2)]
	private APlayerCameraManager PlayerCameraManager;

	// Token: 0x04007459 RID: 29785
	private FVector2D ScreenPositionRef = new FVector2D();

	// Token: 0x0400745A RID: 29786
	[Nullable(2)]
	private UUIItem HudItem;

	// Token: 0x0400745B RID: 29787
	private readonly global::Vector TargetLocation = global::Vector.Create();

	// Token: 0x0400745C RID: 29788
	private int ViewportSizeX;

	// Token: 0x0400745D RID: 29789
	private readonly FVector2D PointTransport = new FVector2D(1f, -1f);

	// Token: 0x0400745E RID: 29790
	private float MajorAxis;

	// Token: 0x0400745F RID: 29791
	private float MinorAxis;

	// Token: 0x04007460 RID: 29792
	private readonly FVector2D Center = new FVector2D(0f, 62.5f);

	// Token: 0x04007461 RID: 29793
	private readonly global::Vector TargetToPlayerVector = global::Vector.Create();

	// Token: 0x04007462 RID: 29794
	private readonly global::Vector ProjectScreenLocation = global::Vector.Create();

	// Token: 0x04007463 RID: 29795
	protected bool IsHudVisible;

	// Token: 0x04007464 RID: 29796
	protected bool IsDestroyed;
}
