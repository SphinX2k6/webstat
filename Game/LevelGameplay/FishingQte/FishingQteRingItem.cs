using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.LevelGamePlay.FishingQte
{
	// Token: 0x02006E9A RID: 28314
	[NullableContext(1)]
	[Nullable(0)]
	public class FishingQteRingItem : UiPanelBase
	{
		// Token: 0x06044A9A RID: 281242 RVA: 0x011D8C6C File Offset: 0x011D6E6C
		public void Init(IFishingQteConfig config, FishingQteGameInfo gameInfo)
		{
			this.GameInfo = gameInfo;
			this.RingConfig = config;
			this.RingInfo = gameInfo.GetRingInfo();
			float num = this.RingConfig.HiddenInterval[0];
			float num2 = this.RingConfig.HiddenInterval[1];
			float num3 = 2f * num + num2;
			if (num3 > 0f)
			{
				this.PeriodAlphaTotalTime = num3;
			}
		}

		// Token: 0x06044A9B RID: 281243 RVA: 0x011D8CD0 File Offset: 0x011D6ED0
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
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(3, typeof(UUITexture));
			this.ComponentRegisterInfos = list;
		}

		// Token: 0x06044A9C RID: 281244 RVA: 0x011D8D7C File Offset: 0x011D6F7C
		protected override UniTask OnBeforeStartAsync()
		{
			FishingQteRingItem.<OnBeforeStartAsync>d__17 <OnBeforeStartAsync>d__;
			<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeStartAsync>d__.<>4__this = this;
			<OnBeforeStartAsync>d__.<>1__state = -1;
			<OnBeforeStartAsync>d__.<>t__builder.Start<FishingQteRingItem.<OnBeforeStartAsync>d__17>(ref <OnBeforeStartAsync>d__);
			return <OnBeforeStartAsync>d__.<>t__builder.Task;
		}

		// Token: 0x06044A9D RID: 281245 RVA: 0x011D8DBF File Offset: 0x011D6FBF
		protected override void OnStart()
		{
			this.LevelSequencePlayer = new LevelSequencePlayer(this.RootItem);
		}

		// Token: 0x06044A9E RID: 281246 RVA: 0x011D8DD2 File Offset: 0x011D6FD2
		protected override void OnBeforeDestroy()
		{
			LevelSequencePlayer levelSequencePlayer = this.LevelSequencePlayer;
			if (levelSequencePlayer != null)
			{
				levelSequencePlayer.Clear();
			}
			this.LevelSequencePlayer = null;
		}

		// Token: 0x06044A9F RID: 281247 RVA: 0x011D8DEC File Offset: 0x011D6FEC
		public void InitRing()
		{
			this.RingInfo.ClearValidAreas();
			UniTask.Create(delegate()
			{
				FishingQteRingItem.<<InitRing>b__20_0>d <<InitRing>b__20_0>d;
				<<InitRing>b__20_0>d.<>t__builder = AsyncUniTaskMethodBuilder.Create();
				<<InitRing>b__20_0>d.<>4__this = this;
				<<InitRing>b__20_0>d.<>1__state = -1;
				<<InitRing>b__20_0>d.<>t__builder.Start<FishingQteRingItem.<<InitRing>b__20_0>d>(ref <<InitRing>b__20_0>d);
				return <<InitRing>b__20_0>d.<>t__builder.Task;
			});
			this.RingQte.InitAllQteAreas();
			float cursorSpeed = this.GameInfo.CursorSpeed;
			float ringSpeed = this.GameInfo.RingSpeed;
			if (cursorSpeed > 0f && ringSpeed > 0f)
			{
				Singleton<Log>.Instance.Error(ELogModule.SceneGameplay, ELogAuthor.YYZ, "[FishingQte] 速度配置错误,同时存在指针速度和转盘速度", default(ReadOnlySpan<ValueTuple<string, object>>));
				return;
			}
			this.UpdateRotateMode((cursorSpeed > 0f) ? EFishingRotateMode.Arrow : EFishingRotateMode.Ring);
		}

		// Token: 0x06044AA0 RID: 281248 RVA: 0x011D8E78 File Offset: 0x011D7078
		[NullableContext(2)]
		public void OnAreaClick(EFishingAreaType areaType, ContinuousRingArea area)
		{
			switch (areaType)
			{
			case EFishingAreaType.BlankArea:
				this.RingBg.PlayAnim("Fail");
				this.RingQte.PlayAnim("Fail");
				return;
			case EFishingAreaType.QteArea:
				this.RingQte.PlayAnim("Success");
				this.PeriodAlphaCurrentTime = 0f;
				return;
			case EFishingAreaType.PerfectArea:
				this.RingQte.PlayAnim("PerfectQte");
				this.PeriodAlphaCurrentTime = 0f;
				return;
			default:
				return;
			}
		}

		// Token: 0x06044AA1 RID: 281249 RVA: 0x011D8EF0 File Offset: 0x011D70F0
		public void OnArrowStayAreaUpdate(int relativeValidAreaIndex)
		{
			List<RingArea> validAreas = this.RingInfo.GetValidAreas();
			if (relativeValidAreaIndex < 0 || relativeValidAreaIndex >= validAreas.Count)
			{
				return;
			}
			RingArea ringArea = validAreas[relativeValidAreaIndex];
			this.ArrowActiveStartYawAngle = (float)(-(float)Math.Max(ringArea.StartCellIndex - 1, 0) * 10);
			this.ArrowActiveEndYawAngle = (float)(-(float)ringArea.EndCellIndex * 10);
			if (this.ArrowActiveEndYawAngle >= this.ArrowActiveStartYawAngle)
			{
				this.ArrowActiveEndYawAngle -= 360f;
			}
			EArrowDirection arrowDirection = ringArea.ArrowDirection;
			if (arrowDirection != EArrowDirection.Clockwise)
			{
				if (arrowDirection == EArrowDirection.Anticlockwise)
				{
					this.CurrentRotator.Yaw = this.ArrowActiveEndYawAngle;
				}
			}
			else
			{
				this.CurrentRotator.Yaw = this.ArrowActiveStartYawAngle;
			}
			UUIItem arrow = this.Arrow;
			if (arrow == null)
			{
				return;
			}
			FRotator frotator = this.CurrentRotator.ToUeRotator();
			arrow.SetUIRelativeRotation(frotator);
		}

		// Token: 0x06044AA2 RID: 281250 RVA: 0x011D8FBC File Offset: 0x011D71BC
		public void OnTick(float delta)
		{
			if (this.GameInfo.IsGamePause())
			{
				return;
			}
			float cursorSpeed = this.GameInfo.CursorSpeed;
			float ringSpeed = this.GameInfo.RingSpeed;
			float cursorSpeed2 = (this.RotateMode == EFishingRotateMode.Arrow) ? cursorSpeed : ringSpeed;
			int direction = (this.RingInfo.ArrowDirection == EArrowDirection.Clockwise) ? -1 : 1;
			float deltaSecond = delta / 1000f;
			this.CurrentRotator.Yaw = this.GetRotatorYaw(direction, cursorSpeed2, deltaSecond);
			EFishingRotateMode rotateMode = this.RotateMode;
			if (rotateMode != EFishingRotateMode.Arrow)
			{
				if (rotateMode == EFishingRotateMode.Ring)
				{
					UUIItem rootItem = this.RingQte.GetRootItem();
					FRotator frotator = this.CurrentRotator.ToUeRotator();
					rootItem.SetUIRelativeRotation(frotator);
					this.RingInfo.CurrentArrowStayCellIndex = 36 - this.GetCurrentArrowStayCellIndex() + 1;
				}
			}
			else
			{
				UUIItem arrow = this.Arrow;
				if (arrow != null)
				{
					FRotator frotator = this.CurrentRotator.ToUeRotator();
					arrow.SetUIRelativeRotation(frotator);
				}
				this.RingInfo.CurrentArrowStayCellIndex = this.GetCurrentArrowStayCellIndex();
			}
			if (this.PeriodAlphaTotalTime > 0f)
			{
				float alphaInAlphaPeriod = this.GetAlphaInAlphaPeriod(this.PeriodAlphaCurrentTime);
				foreach (int continuousIndex in this.RingInfo.GetQteAreas().Keys)
				{
					this.RingQte.GetQteAreaTexture(continuousIndex).SetAlpha(alphaInAlphaPeriod);
				}
				foreach (int continuousIndex2 in this.RingInfo.GetPerfectAreas().Keys)
				{
					this.RingQte.GetPerfectAreaTexture(continuousIndex2).SetAlpha(alphaInAlphaPeriod);
				}
				this.PeriodAlphaCurrentTime += delta;
				if (this.PeriodAlphaCurrentTime >= this.PeriodAlphaTotalTime)
				{
					this.PeriodAlphaCurrentTime = 0f;
				}
			}
		}

		// Token: 0x06044AA3 RID: 281251 RVA: 0x011D91A8 File Offset: 0x011D73A8
		private float GetRotatorYaw(int direction, float cursorSpeed, float deltaSecond)
		{
			float num = this.CurrentRotator.Yaw;
			if (this.RingInfo.IsWholeRing)
			{
				num += (float)direction * (cursorSpeed * deltaSecond);
			}
			else
			{
				num += (float)direction * (cursorSpeed * deltaSecond);
				if (num < this.ArrowActiveEndYawAngle)
				{
					num = this.ArrowActiveEndYawAngle + 1f;
					this.RingInfo.OnArrowDirectionReverse();
				}
				if (num > this.ArrowActiveStartYawAngle)
				{
					num = this.ArrowActiveStartYawAngle;
					this.RingInfo.OnArrowDirectionReverse();
				}
			}
			if (num > 0f)
			{
				num -= 360f;
			}
			return num % 720f;
		}

		// Token: 0x06044AA4 RID: 281252 RVA: 0x011D9235 File Offset: 0x011D7435
		private int GetCurrentArrowStayCellIndex()
		{
			return (int)Math.Floor((double)(Math.Abs(this.CurrentRotator.Yaw) % 360f / 10f)) + 1;
		}

		// Token: 0x06044AA5 RID: 281253 RVA: 0x011D925C File Offset: 0x011D745C
		private float GetAlphaInAlphaPeriod(float currentTime)
		{
			float num = this.RingConfig.HiddenInterval[0];
			float num2 = this.RingConfig.HiddenInterval[1];
			float num3 = this.RingConfig.HiddenInterval[2];
			float num4 = (num2 - num3) / 2f;
			if (currentTime < num)
			{
				return 1f;
			}
			if (currentTime < num + num4)
			{
				return 1f - (currentTime - num) / num4;
			}
			if (currentTime < num + num4 + num3)
			{
				return 0f;
			}
			if (currentTime < num + num2)
			{
				return (currentTime - num - num4 - num3) / num4;
			}
			return 1f;
		}

		// Token: 0x06044AA6 RID: 281254 RVA: 0x011D92E8 File Offset: 0x011D74E8
		private void UpdateRotateMode(EFishingRotateMode mode)
		{
			this.RotateMode = mode;
			if (mode != EFishingRotateMode.Arrow && mode == EFishingRotateMode.Ring)
			{
				string resourcePath = ConfigBase<UiResourceConfig>.Instance.GetResourcePath("T_ControlPointLock");
				base.SetTextureByPath(resourcePath, base.GetTexture(3), null, null);
				UUIItem rootItem = this.RingQte.GetRootItem();
				FRotator frotator = Rotator.Create().ToUeRotator();
				rootItem.SetUIRelativeRotation(frotator);
			}
		}

		// Token: 0x06044AA7 RID: 281255 RVA: 0x011D9348 File Offset: 0x011D7548
		public void SpawnContinuousArea(int continuousIndex, EFishingAreaType type = EFishingAreaType.QteArea)
		{
			this.RingQte.SpawnContinuousArea(continuousIndex, type);
		}

		// Token: 0x040263A0 RID: 156576
		private const float YAW_MAX_ANGLE = 720f;

		// Token: 0x040263A1 RID: 156577
		protected IFishingQteConfig RingConfig;

		// Token: 0x040263A2 RID: 156578
		protected FishingQteGameInfo GameInfo;

		// Token: 0x040263A3 RID: 156579
		protected FishingQteRingInfo RingInfo;

		// Token: 0x040263A4 RID: 156580
		[Nullable(2)]
		protected FishingQteRingBgItem RingBg;

		// Token: 0x040263A5 RID: 156581
		[Nullable(2)]
		protected FishingQteRingQteItem RingQte;

		// Token: 0x040263A6 RID: 156582
		[Nullable(2)]
		protected LevelSequencePlayer LevelSequencePlayer;

		// Token: 0x040263A7 RID: 156583
		[Nullable(2)]
		private UUIItem Arrow;

		// Token: 0x040263A8 RID: 156584
		private Rotator CurrentRotator = Rotator.Create();

		// Token: 0x040263A9 RID: 156585
		private float ArrowActiveStartYawAngle;

		// Token: 0x040263AA RID: 156586
		private float ArrowActiveEndYawAngle;

		// Token: 0x040263AB RID: 156587
		protected float PeriodAlphaTotalTime;

		// Token: 0x040263AC RID: 156588
		protected float PeriodAlphaCurrentTime;

		// Token: 0x040263AD RID: 156589
		protected EFishingRotateMode RotateMode;

		// Token: 0x0200CB64 RID: 52068
		[NullableContext(0)]
		private class EComponents
		{
			// Token: 0x0403E6BC RID: 255676
			public const int Arrow = 0;

			// Token: 0x0403E6BD RID: 255677
			public const int RingBg = 1;

			// Token: 0x0403E6BE RID: 255678
			public const int RingQte = 2;

			// Token: 0x0403E6BF RID: 255679
			public const int TexArrow = 3;
		}
	}
}
