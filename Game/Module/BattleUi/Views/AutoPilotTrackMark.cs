using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Camera;
using CSharpScript.Game.Module.AutoPilot;
using CSharpScript.Game.Module.Map;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using UnrealEngine;

namespace CSharpScript.Game.Module.BattleUi.Views
{
	// Token: 0x02005F99 RID: 24473
	[NullableContext(2)]
	[Nullable(0)]
	public class AutoPilotTrackMark : UiPanelBase
	{
		// Token: 0x0603D719 RID: 251673 RVA: 0x00FA2A74 File Offset: 0x00FA0C74
		public AutoPilotTrackMark()
		{
			if (GlobalData.World == null)
			{
				return;
			}
			UUIItem uiRootItem = Singleton<UiLayer>.Instance.UiRootItem;
			this.LimitA = Math.Min(1176f, (((uiRootItem != null) ? uiRootItem.GetWidth() : 0f) - 1008f) / 2f);
			this.LimitB = Math.Min(712.5f, (((uiRootItem != null) ? uiRootItem.GetHeight() : 0f) - 495f) / 2f);
		}

		// Token: 0x0603D71A RID: 251674 RVA: 0x00FA2B37 File Offset: 0x00FA0D37
		[NullableContext(1)]
		public void Initialize(UUIItem parent)
		{
			base.CreateThenShowByResourceIdAsync("UiItem_Mark_Prefab", parent, true).Forget();
		}

		// Token: 0x0603D71B RID: 251675 RVA: 0x00FA2B4C File Offset: 0x00FA0D4C
		protected unsafe override void OnRegisterComponent()
		{
			int num = 6;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUISprite));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(5, typeof(UUINiagara));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(6, typeof(UUIItem));
			this.ComponentRegisterInfos = list;
		}

		// Token: 0x0603D71C RID: 251676 RVA: 0x00FA2C39 File Offset: 0x00FA0E39
		protected override void OnStart()
		{
			this.DistanceComp = base.GetItem(4);
			this.DirectionComp = base.GetItem(2);
			this.OnUiShow();
		}

		// Token: 0x0603D71D RID: 251677 RVA: 0x00FA2C5B File Offset: 0x00FA0E5B
		protected override void OnBeforeDestroy()
		{
			this.PointTransport = null;
			if (TimerSystem.Instance.Has(this.DelayTrackSequenceTimerId))
			{
				TimerSystem.Instance.Remove(this.DelayTrackSequenceTimerId);
			}
		}

		// Token: 0x0603D71E RID: 251678 RVA: 0x00FA2C87 File Offset: 0x00FA0E87
		public void OnUiShow()
		{
			UUIItem rootItem = this.RootItem;
			if (rootItem == null)
			{
				return;
			}
			rootItem.SetRelativeScale3D(new FVector(1f, 1f, 1f));
		}

		// Token: 0x0603D71F RID: 251679 RVA: 0x00FA2CAD File Offset: 0x00FA0EAD
		public void OnUiHide()
		{
		}

		// Token: 0x0603D720 RID: 251680 RVA: 0x00FA2CB0 File Offset: 0x00FA0EB0
		private void UpdateIcon()
		{
			if (!this.IsIconPathDirty)
			{
				return;
			}
			base.TrySetSpriteByPath(this.IconPath, base.GetSprite(0), false, null, null);
			this.IsIconPathDirty = false;
		}

		// Token: 0x0603D721 RID: 251681 RVA: 0x00FA2CEC File Offset: 0x00FA0EEC
		private void UpdateTrackDistance()
		{
			AutoPilotFindPathResult findPathResult = ModelBase<AutoPilotModel>.Instance.GetFindPathResult();
			if (findPathResult == null)
			{
				return;
			}
			Vector playerPoint = findPathResult.PlayerPoint;
			Vector trackingPoint = findPathResult.GetTrackingPoint();
			if (this.InRange && trackingPoint != null)
			{
				int num = (int)Math.Round(Vector.Distance(playerPoint, trackingPoint) * 0.009999999776482582);
				if (this.TrackDistanceDisplay != num)
				{
					this.TrackDistanceDisplay = num;
					Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(1), "Text_Meter_Text", new <>z__ReadOnlySingleElementList<object>(this.TrackDistanceDisplay.ToString()));
				}
				UUIItem distanceComp = this.DistanceComp;
				if (distanceComp == null)
				{
					return;
				}
				distanceComp.SetUIActive(true);
				return;
			}
			else
			{
				UUIItem distanceComp2 = this.DistanceComp;
				if (distanceComp2 == null)
				{
					return;
				}
				distanceComp2.SetUIActive(false);
				return;
			}
		}

		// Token: 0x0603D722 RID: 251682 RVA: 0x00FA2D94 File Offset: 0x00FA0F94
		public void Update(float delta)
		{
			if (GlobalData.World == null)
			{
				return;
			}
			if (Singleton<UiLayer>.Instance.UiRootItem == null)
			{
				return;
			}
			if (this.RootItem == null)
			{
				return;
			}
			if (!this.IsShowTrackingMark())
			{
				this.SetRootItemState(false);
				return;
			}
			this.SetRootItemState(true);
			this.UpdatePositionAndRotation(delta);
			this.UpdateTrackDistance();
			this.UpdateIcon();
		}

		// Token: 0x0603D723 RID: 251683 RVA: 0x00FA2DEC File Offset: 0x00FA0FEC
		protected void UpdatePositionAndRotation(float delta)
		{
			AutoPilotFindPathResult findPathResult = ModelBase<AutoPilotModel>.Instance.GetFindPathResult();
			Vector vector = (findPathResult != null) ? findPathResult.GetTrackingPoint() : null;
			if (vector == null)
			{
				return;
			}
			TsCharacterController characterController = Global.CharacterController;
			FVectorDouble fvectorDouble = vector.ToUeVector(false);
			bool flag = UGameplayStatics.D_ProjectWorldToScreen(characterController, fvectorDouble, ref this.ScreenPositionRef, false);
			if (!flag)
			{
				FTransformDouble value = ModelBase<CameraModel>.Instance.MainModel.CameraTransform.Value;
				FVectorDouble fvectorDouble2 = value.InverseTransformPositionNoScale(fvectorDouble);
				fvectorDouble2.X = -fvectorDouble2.X;
				FVectorDouble fvectorDouble3 = value.TransformPositionNoScale(fvectorDouble2);
				UGameplayStatics.D_ProjectWorldToScreen(characterController, fvectorDouble3, ref this.ScreenPositionRef, false);
			}
			this.ScreenPosition.Set((double)this.ScreenPositionRef.X, (double)this.ScreenPositionRef.Y);
			if (!this.LastScreenPosition.Equals(this.ScreenPosition, 1.0))
			{
				this.LastScreenPosition.DeepCopy(this.ScreenPosition);
				BattleUiModel instance = ModelBase<BattleUiModel>.Instance;
				this.ScreenPosition.MultiplyEqual((double)instance.ScreenPositionScale).AdditionEqual(instance.ScreenPositionOffset).MultiplyEqual(this.PointTransport);
				this.InRange = this.ClampToEllipse(this.ScreenPosition, flag);
				Vector2D vector2D = this.ScreenPosition.AdditionEqual(TrackDefine.center);
				this.RootItem.SetAnchorOffset(vector2D.ToUeVector2D(false));
				if (!this.InRange)
				{
					UUIItem directionComp = this.DirectionComp;
					FRotator frotator = new FRotator();
					frotator.Yaw = (float)(Math.Atan2(this.ScreenPosition.Y, this.ScreenPosition.X) * 57.2957763671875);
					directionComp.SetUIRelativeRotation(frotator);
					this.DirectionComp.SetUIActive(true);
					return;
				}
				this.DirectionComp.SetUIActive(false);
			}
		}

		// Token: 0x0603D724 RID: 251684 RVA: 0x00FA2FA0 File Offset: 0x00FA11A0
		private bool IsShowTrackingMark()
		{
			AutoPilotModel instance = ModelBase<AutoPilotModel>.Instance;
			AutoPilotFindPathResult autoPilotFindPathResult = (instance != null) ? instance.GetFindPathResult() : null;
			if (autoPilotFindPathResult == null)
			{
				return false;
			}
			if (autoPilotFindPathResult.MapId != ModelBase<MapModel>.Instance.CurrentWorldMapConfigId || autoPilotFindPathResult.GetTrackingPoint() == null)
			{
				return false;
			}
			string text = autoPilotFindPathResult.GetIsShowStartPoint() ? AutoPilotDefine.STARTPOPINT_ICONPATH : AutoPilotDefine.ENDPOINT_ICONPATH;
			if (this.IconPath != text)
			{
				this.IconPath = text;
				this.IsIconPathDirty = true;
			}
			return true;
		}

		// Token: 0x0603D725 RID: 251685 RVA: 0x00FA3014 File Offset: 0x00FA1214
		[NullableContext(1)]
		protected bool ClampToEllipse(Vector2D vector, bool inFront)
		{
			double x = vector.X;
			double y = vector.Y;
			float limitA = this.LimitA;
			float limitB = this.LimitB;
			if (inFront && x * x / (double)(limitA * limitA) + y * y / (double)(limitB * limitB) <= 1.0)
			{
				return true;
			}
			double num = (double)(limitA * limitB) / Math.Sqrt((double)(limitB * limitB) * x * x + (double)(limitA * limitA) * y * y);
			vector.MultiplyEqual((double)((float)num));
			return false;
		}

		// Token: 0x0603D726 RID: 251686 RVA: 0x00FA3087 File Offset: 0x00FA1287
		private void SetRootItemState(bool bActive)
		{
			if (this.RootItem == null)
			{
				return;
			}
			if (this.RootItem.IsUIActiveSelf() == bActive)
			{
				return;
			}
			this.RootItem.SetUIActive(bActive);
		}

		// Token: 0x0402287A RID: 141434
		private readonly float LimitA;

		// Token: 0x0402287B RID: 141435
		private readonly float LimitB;

		// Token: 0x0402287C RID: 141436
		protected FVector2D ScreenPositionRef = new FVector2D();

		// Token: 0x0402287D RID: 141437
		protected Vector2D PointTransport = Vector2D.Create(1.0, -1.0);

		// Token: 0x0402287E RID: 141438
		private TimerHandle DelayTrackSequenceTimerId;

		// Token: 0x0402287F RID: 141439
		[Nullable(1)]
		protected readonly Vector2D ScreenPosition = Vector2D.Create();

		// Token: 0x04022880 RID: 141440
		[Nullable(1)]
		protected readonly Vector2D LastScreenPosition = Vector2D.Create();

		// Token: 0x04022881 RID: 141441
		protected bool InRange;

		// Token: 0x04022882 RID: 141442
		private int TrackDistanceDisplay = -1;

		// Token: 0x04022883 RID: 141443
		private UUIItem DistanceComp;

		// Token: 0x04022884 RID: 141444
		protected UUIItem DirectionComp;

		// Token: 0x04022885 RID: 141445
		private string IconPath;

		// Token: 0x04022886 RID: 141446
		private bool IsIconPathDirty;

		// Token: 0x0200BF86 RID: 49030
		[NullableContext(0)]
		private enum ETrackedMark
		{
			// Token: 0x0403AF35 RID: 241461
			Icon,
			// Token: 0x0403AF36 RID: 241462
			Distance,
			// Token: 0x0403AF37 RID: 241463
			Direction,
			// Token: 0x0403AF38 RID: 241464
			TrackedButton,
			// Token: 0x0403AF39 RID: 241465
			DistanceItem,
			// Token: 0x0403AF3A RID: 241466
			WaveNiagara,
			// Token: 0x0403AF3B RID: 241467
			PanelIcon
		}
	}
}
