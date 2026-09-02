using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using AkiClient.Game.Aki.Character.BaseCharacter;
using CSharpScript.Game.Camera;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.Map;
using CSharpScript.Game.Module.Map.View.BaseMap;
using CSharpScript.Game.Module.WorldMap;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.BattleUi.Views
{
	// Token: 0x0200604B RID: 24651
	[NullableContext(2)]
	[Nullable(0)]
	public class MiniMapView : BattleVisibleChildView
	{
		// Token: 0x0603E2F7 RID: 254711 RVA: 0x00FE07D3 File Offset: 0x00FDE9D3
		public override void Initialize(object param = null)
		{
			base.Initialize(param);
			base.InitChildType(EBattleUiChild.MiniMap);
			this.IsInitFinished = false;
		}

		// Token: 0x0603E2F8 RID: 254712 RVA: 0x00FE07EC File Offset: 0x00FDE9EC
		protected override UniTask InitializeAsync(object param = null)
		{
			MiniMapView.<InitializeAsync>d__15 <InitializeAsync>d__;
			<InitializeAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<InitializeAsync>d__.<>4__this = this;
			<InitializeAsync>d__.<>1__state = -1;
			<InitializeAsync>d__.<>t__builder.Start<MiniMapView.<InitializeAsync>d__15>(ref <InitializeAsync>d__);
			return <InitializeAsync>d__.<>t__builder.Task;
		}

		// Token: 0x0603E2F9 RID: 254713 RVA: 0x00FE082F File Offset: 0x00FDEA2F
		public override void Reset()
		{
			this.MiniMap.Destroy(null);
			if (this.TimerId != null)
			{
				TimerSystem.GameplayTimeInstance.Remove(this.TimerId);
				this.TimerId = null;
			}
			base.Reset();
		}

		// Token: 0x0603E2FA RID: 254714 RVA: 0x00FE0864 File Offset: 0x00FDEA64
		protected unsafe override void OnRegisterComponent()
		{
			int num = 4;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUISprite));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIButtonComponent));
			this.ComponentRegisterInfos = list;
			num2 = 1;
			List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
			CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
			Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
			num = 0;
			*span2[num] = new ValueTuple<int, Delegate>(3, new Action(this.OpenMapView));
			this.BtnBindInfo = list2;
		}

		// Token: 0x0603E2FB RID: 254715 RVA: 0x00FE094C File Offset: 0x00FDEB4C
		private void OpenMapView()
		{
			ControllerBase<WorldMapController>.Instance.OpenView(EOpenMapType.Mouse, true, null, null);
		}

		// Token: 0x0603E2FC RID: 254716 RVA: 0x00FE095C File Offset: 0x00FDEB5C
		public void RefreshShow()
		{
			if (!this.IsInitFinished)
			{
				return;
			}
			EntityHandle getCurrentEntity = ModelBase<SceneTeamModel>.Instance.GetCurrentEntity;
			if (getCurrentEntity == null || !getCurrentEntity.Valid)
			{
				return;
			}
			CharacterActorComponent component = getCurrentEntity.Entity.GetComponent<CharacterActorComponent>();
			if (component == null)
			{
				return;
			}
			UUIItem item = base.GetItem(1);
			UUIItem sprite = base.GetSprite(2);
			int num = 90;
			float num2 = -(component.ActorRotationProxy.Yaw + (float)num);
			if (Math.Abs(this.TempPlayerRotator.Yaw - num2) > 10f)
			{
				this.TempPlayerRotator.Yaw = num2;
				item.SetUIRelativeRotation(this.TempPlayerRotator);
			}
			float desiredYaw = -(ModelBase<CameraModel>.Instance.MainModel.CameraRotator.Yaw + (float)num);
			this.TempSightRotator.Yaw = this.ClampCameraYaw(desiredYaw);
			sprite.SetUIRelativeRotation(this.TempSightRotator);
		}

		// Token: 0x0603E2FD RID: 254717 RVA: 0x00FE0A30 File Offset: 0x00FDEC30
		private float ClampCameraYaw(float desiredYaw)
		{
			ECustomCameraMode? cameraMode = ModelBase<CameraModel>.Instance.MainModel.CameraMode;
			ECustomCameraMode ecustomCameraMode = ECustomCameraMode.LockOn;
			if ((cameraMode.GetValueOrDefault() == ecustomCameraMode & cameraMode != null) && ModelBase<CameraModel>.Instance.MainModel.FightCamera != null && ModelBase<CameraModel>.Instance.MainModel.FightCamera.LogicComponent != null)
			{
				VirtualCamera currentCamera = ModelBase<CameraModel>.Instance.MainModel.FightCamera.LogicComponent.CurrentCamera;
				float yawLimitMin = currentCamera.YawLimitMin;
				float num = (currentCamera.YawLimitMax - yawLimitMin) % 360f;
				if (Singleton<MathUtils>.Instance.IsNearlyZero((double)num, null) || Singleton<MathUtils>.Instance.IsNearlyEqual((double)num, 360.0, null))
				{
					return Singleton<MathUtils>.Instance.Clamp(Singleton<MathUtils>.Instance.WrapAngle(desiredYaw), currentCamera.WorldYawMin, currentCamera.WorldYawMax);
				}
			}
			return desiredYaw;
		}

		// Token: 0x0603E2FE RID: 254718 RVA: 0x00FE0B22 File Offset: 0x00FDED22
		private void UpdateMarkItems(float _)
		{
			if (this.LastTickFrame == Singleton<Time>.Instance.Frame)
			{
				return;
			}
			this.LastTickFrame = Singleton<Time>.Instance.Frame;
			this.UpdateMarkItemsForStat();
		}

		// Token: 0x0603E2FF RID: 254719 RVA: 0x00FE0B50 File Offset: 0x00FDED50
		private void UpdateMarkItemsForStat()
		{
			if (!base.IsUiActiveInHierarchy())
			{
				return;
			}
			Vector playerLocation = Singleton<GeneralLogicTreeUtil>.Instance.GetPlayerLocation();
			if (playerLocation == null)
			{
				return;
			}
			if (this.MiniMap != null)
			{
				this.MiniMap.Tick();
				this.CachedPlayerLocation2D.X = playerLocation.X;
				this.CachedPlayerLocation2D.Y = playerLocation.Y;
				MapUtil.WorldPosition2UiPosition2D(this.CachedPlayerLocation2D, this.CachedPlayerLocation2D);
				this.CachedPlayerLocation2D.MultiplyEqual((double)this.RealMinimapScale).UnaryNegation(this.CachedPlayerLocation2D);
				this.MiniMap.GetRootItem().SetAnchorOffset(this.CachedPlayerLocation2D.ToUeVector2D(false));
				this.MiniMap.UpdateMinimapTiles(playerLocation);
				this.CachedAnchorOffset.FromUeVector2D(this.MiniMap.GetRootItem().GetAnchorOffset());
				float realMinimapScale = this.RealMinimapScale;
				this.MiniMap.MiniMapUpdateMarkItems(this.CachedAnchorOffset, realMinimapScale, playerLocation);
			}
		}

		// Token: 0x0603E300 RID: 254720 RVA: 0x00FE0C3E File Offset: 0x00FDEE3E
		public void RefreshOnPlatformChanged()
		{
			Singleton<EventSystem>.Instance.Emit(EEventName.ModelReady);
		}

		// Token: 0x0603E301 RID: 254721 RVA: 0x00FE0C50 File Offset: 0x00FDEE50
		public void SetRoguelikeVisible(bool visible)
		{
			base.SetVisible(1, visible);
		}

		// Token: 0x0603E302 RID: 254722 RVA: 0x00FE0C5A File Offset: 0x00FDEE5A
		public void SetBattleLinkVisible(bool visible)
		{
			base.SetVisible(2, visible);
		}

		// Token: 0x0603E303 RID: 254723 RVA: 0x00FE0C64 File Offset: 0x00FDEE64
		public void SetShipTowerVisible(bool visible)
		{
			base.SetVisible(3, visible);
		}

		// Token: 0x0603E304 RID: 254724 RVA: 0x00FE0C6E File Offset: 0x00FDEE6E
		public void RefreshMiniMap()
		{
			MiniMap miniMap = this.MiniMap;
			if (miniMap == null)
			{
				return;
			}
			miniMap.ChangeMapAsync(ModelBase<MapModel>.Instance.CurrentMapConfigId);
		}

		// Token: 0x04022DBB RID: 142779
		private const float UPDATE_INTERVAL = 100f;

		// Token: 0x04022DBC RID: 142780
		private const float PLAYER_ROTATE_UPDATE_THRESHOLD = 10f;

		// Token: 0x04022DBD RID: 142781
		private MiniMap MiniMap;

		// Token: 0x04022DBE RID: 142782
		private float RealMinimapScale;

		// Token: 0x04022DBF RID: 142783
		private bool IsInitFinished;

		// Token: 0x04022DC0 RID: 142784
		private TimerHandle TimerId;

		// Token: 0x04022DC1 RID: 142785
		private FRotator TempSightRotator = new FRotator(0f, 0f, 0f);

		// Token: 0x04022DC2 RID: 142786
		private FRotator TempPlayerRotator = new FRotator(0f, 0f, 0f);

		// Token: 0x04022DC3 RID: 142787
		[Nullable(1)]
		[StaticVariableRuleIgnore]
		private static readonly Stat StatUpdateMarkItems = Stat.Create("MiniMapView.UpdateMarkItems", "", "");

		// Token: 0x04022DC4 RID: 142788
		private int LastTickFrame = -1;

		// Token: 0x04022DC5 RID: 142789
		[Nullable(1)]
		private readonly Vector2D CachedPlayerLocation2D = Vector2D.Create();

		// Token: 0x04022DC6 RID: 142790
		[Nullable(1)]
		private readonly Vector2D CachedAnchorOffset = Vector2D.Create();

		// Token: 0x0200C10B RID: 49419
		[NullableContext(0)]
		private enum EChildComponentType
		{
			// Token: 0x0403B721 RID: 243489
			MiniMapRoot,
			// Token: 0x0403B722 RID: 243490
			PlayerItem,
			// Token: 0x0403B723 RID: 243491
			PlayerSight,
			// Token: 0x0403B724 RID: 243492
			MiniMapButton
		}

		// Token: 0x0200C10C RID: 49420
		[NullableContext(0)]
		private enum EVisibleReason
		{
			// Token: 0x0403B726 RID: 243494
			Default,
			// Token: 0x0403B727 RID: 243495
			Roguelike,
			// Token: 0x0403B728 RID: 243496
			BattleLink,
			// Token: 0x0403B729 RID: 243497
			ShipTower
		}
	}
}
