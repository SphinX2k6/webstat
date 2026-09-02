using System;
using System.Runtime.CompilerServices;
using Aki.Config;
using Aki.Protocol;
using CSharpScript.Game.Camera;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.LevelGamePlay;
using Cysharp.Threading.Tasks;
using UnrealEngine;

// Token: 0x02001F92 RID: 8082
[NullableContext(1)]
[Nullable(0)]
public class LockExecutionHandle : HudUnitHandleBase
{
	// Token: 0x0600F271 RID: 62065 RVA: 0x004241C0 File Offset: 0x004223C0
	protected override void OnInitialize()
	{
		this.MinDistanceSquare = (double)ConfigCommonParamById.GetIntConfig("LockExecutionShowDistance").Value;
	}

	// Token: 0x0600F272 RID: 62066 RVA: 0x004241E6 File Offset: 0x004223E6
	protected override void OnAddEvents()
	{
		Singleton<EventSystem>.Instance.Add<bool, int, ECustomOptionType?>(EEventName.OnEnterOrExitExecutionRange, new Action<bool, int, ECustomOptionType?>(this.OnEnterOrExitExecutionRange));
	}

	// Token: 0x0600F273 RID: 62067 RVA: 0x00424204 File Offset: 0x00422404
	protected override void OnRemoveEvents()
	{
		Singleton<EventSystem>.Instance.Remove<bool, int, ECustomOptionType?>(EEventName.OnEnterOrExitExecutionRange, new Action<bool, int, ECustomOptionType?>(this.OnEnterOrExitExecutionRange));
	}

	// Token: 0x0600F274 RID: 62068 RVA: 0x00424222 File Offset: 0x00422422
	private void OnEnterOrExitExecutionRange(bool isEnter, int entityId, ECustomOptionType? optionType)
	{
		if (isEnter && optionType.GetValueOrDefault() == ECustomOptionType.Execution)
		{
			this.OnShowExecutionUi(entityId);
			return;
		}
		this.OnHideExecutionUi(entityId);
	}

	// Token: 0x0600F275 RID: 62069 RVA: 0x00424240 File Offset: 0x00422440
	private void OnShowExecutionUi(int entityId)
	{
		EntityHandle entityHandle = this.EntityHandle;
		if (entityHandle != null && entityHandle.Id == entityId)
		{
			return;
		}
		EntityHandle entityById = ModelBase<CreatureModel>.Instance.GetEntityById(entityId);
		if (entityById == null)
		{
			this.OnRemove();
			return;
		}
		this.RemoveEntityEvents();
		this.EntityHandle = entityById;
		this.OnAdd();
	}

	// Token: 0x0600F276 RID: 62070 RVA: 0x0042428E File Offset: 0x0042248E
	private void OnHideExecutionUi(int entityId)
	{
		EntityHandle entityHandle = this.EntityHandle;
		if (entityHandle == null || entityHandle.Id != entityId)
		{
			return;
		}
		this.OnRemove();
	}

	// Token: 0x0600F277 RID: 62071 RVA: 0x004242B1 File Offset: 0x004224B1
	private void OnAdd()
	{
		this.AddEntityEvents();
		this.TryActivate();
	}

	// Token: 0x0600F278 RID: 62072 RVA: 0x004242BF File Offset: 0x004224BF
	private void OnRemove()
	{
		this.RemoveEntityEvents();
		this.IsActive = false;
		this.TryDeactivate();
		this.EntityHandle = null;
	}

	// Token: 0x0600F279 RID: 62073 RVA: 0x004242DB File Offset: 0x004224DB
	private void AddEntityEvents()
	{
		if (this.EntityHandle == null)
		{
			return;
		}
		Singleton<EventSystem>.Instance.AddWithTarget<ERemoveEntityType, EntityHandle>(this.EntityHandle, EEventName.RemoveEntity, new Action<ERemoveEntityType, EntityHandle>(this.OnRemoveEntity));
	}

	// Token: 0x0600F27A RID: 62074 RVA: 0x00424308 File Offset: 0x00422508
	private void RemoveEntityEvents()
	{
		if (this.EntityHandle == null)
		{
			return;
		}
		Singleton<EventSystem>.Instance.RemoveWithTarget<ERemoveEntityType, EntityHandle>(this.EntityHandle, EEventName.RemoveEntity, new Action<ERemoveEntityType, EntityHandle>(this.OnRemoveEntity));
	}

	// Token: 0x0600F27B RID: 62075 RVA: 0x00424335 File Offset: 0x00422535
	private void OnRemoveEntity(ERemoveEntityType removeType, EntityHandle handle)
	{
		if (this.EntityHandle == null)
		{
			return;
		}
		this.OnRemove();
	}

	// Token: 0x0600F27C RID: 62076 RVA: 0x00424346 File Offset: 0x00422546
	protected override void OnTick(float delta)
	{
		if (this.IsLoading)
		{
			return;
		}
		if (this.LockExecutionUnit == null)
		{
			return;
		}
		this.RefreshActiveAndPosition();
		if (this.IsActive)
		{
			this.LockExecutionUnit.TryShow();
			return;
		}
		this.LockExecutionUnit.TryHide(true);
	}

	// Token: 0x0600F27D RID: 62077 RVA: 0x00424380 File Offset: 0x00422580
	private void RefreshActiveAndPosition()
	{
		EntityHandle entityHandle = this.EntityHandle;
		if (entityHandle == null || !entityHandle.Valid)
		{
			this.IsActive = false;
			return;
		}
		FVectorDouble? worldLocation = this.GetWorldLocation();
		if (worldLocation == null)
		{
			this.IsActive = false;
			return;
		}
		global::Vector cameraLocation = ControllerBase<CameraController>.Instance.MainModel.CameraLocation;
		if (Math.Pow(cameraLocation.X - worldLocation.Value.X, 2.0) + Math.Pow(cameraLocation.Y - worldLocation.Value.Y, 2.0) + Math.Pow(cameraLocation.Z - worldLocation.Value.Z, 2.0) < this.MinDistanceSquare)
		{
			this.IsActive = false;
			return;
		}
		if (!HudUnitUtils.PositionUtil.ProjectWorldToScreen(worldLocation.Value, this.ScreenPos))
		{
			this.IsActive = false;
			return;
		}
		this.IsActive = true;
		this.LockExecutionUnit.GetRootItem().SetAnchorOffset(this.ScreenPos.ToUeVector2D(false));
	}

	// Token: 0x0600F27E RID: 62078 RVA: 0x0042448D File Offset: 0x0042268D
	private void TryActivate()
	{
		if (this.LockExecutionUnit == null)
		{
			this.Activate();
			return;
		}
		this.RefreshActiveAndPosition();
		if (this.IsActive)
		{
			this.LockExecutionUnit.TryShow();
			return;
		}
		this.LockExecutionUnit.TryHide(true);
	}

	// Token: 0x0600F27F RID: 62079 RVA: 0x004244C4 File Offset: 0x004226C4
	private void Activate()
	{
		if (this.IsLoading)
		{
			return;
		}
		this.IsLoading = true;
		base.NewHudUnit<LockExecutionUnit>(typeof(LockExecutionUnit), "UiItem_PutDeath", false, false).ContinueWith(delegate(LockExecutionUnit lockExecutionUnit)
		{
			if (lockExecutionUnit == null || this.IsDestroyed)
			{
				return;
			}
			this.IsLoading = false;
			this.LockExecutionUnit = lockExecutionUnit;
			this.RefreshActiveAndPosition();
			if (this.IsActive)
			{
				this.LockExecutionUnit.TryShow();
				return;
			}
			this.LockExecutionUnit.TryHide(false);
		});
	}

	// Token: 0x0600F280 RID: 62080 RVA: 0x004244FF File Offset: 0x004226FF
	private void TryDeactivate()
	{
		if (this.LockExecutionUnit == null)
		{
			return;
		}
		this.LockExecutionUnit.TryHide(true);
	}

	// Token: 0x0600F281 RID: 62081 RVA: 0x00424518 File Offset: 0x00422718
	private FVectorDouble? GetWorldLocation()
	{
		AActor owner = this.EntityHandle.Entity.GetComponent<BaseActorComponent>().Owner;
		if (!(owner is TsBaseCharacter))
		{
			return null;
		}
		return new FVectorDouble?((owner as TsBaseCharacter).Mesh.D_GetSocketLocation(LockExecutionHandle._hitCaseSocket));
	}

	// Token: 0x04007470 RID: 29808
	private static readonly FName _hitCaseSocket = new FName("HitCase");

	// Token: 0x04007471 RID: 29809
	private readonly Vector2D ScreenPos = new Vector2D();

	// Token: 0x04007472 RID: 29810
	[Nullable(2)]
	private LockExecutionUnit LockExecutionUnit;

	// Token: 0x04007473 RID: 29811
	[Nullable(2)]
	private EntityHandle EntityHandle;

	// Token: 0x04007474 RID: 29812
	private bool IsLoading;

	// Token: 0x04007475 RID: 29813
	private bool IsActive;

	// Token: 0x04007476 RID: 29814
	private double MinDistanceSquare;
}
