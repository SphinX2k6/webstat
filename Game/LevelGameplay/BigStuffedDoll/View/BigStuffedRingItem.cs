using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.LevelGamePlay.BigStuffedDoll.View
{
	// Token: 0x02006F65 RID: 28517
	[NullableContext(1)]
	[Nullable(0)]
	public class BigStuffedRingItem : UiPanelBase
	{
		// Token: 0x1700A49D RID: 42141
		// (get) Token: 0x06045050 RID: 282704 RVA: 0x011F7E50 File Offset: 0x011F6050
		[Nullable(new byte[]
		{
			0,
			1
		})]
		public OneOf<BrokenRockRing, BrokenRockRingConfig> Config
		{
			[return: Nullable(new byte[]
			{
				0,
				1
			})]
			get
			{
				return this.RingConfig;
			}
		}

		// Token: 0x06045051 RID: 282705 RVA: 0x011F7E58 File Offset: 0x011F6058
		public BigStuffedRingItem(int id, AActor actor)
		{
			this.Id = id;
			this.MyRootActor = actor;
			this.RingConfig = ModelBase<BigStuffedDollModel>.Instance.GetRingConfig(id);
			if (!this.RingConfig.HasValue)
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.SceneGameplay;
				ELogAuthor author = ELogAuthor.YSQ;
				string message = "[BigStuffedDoll]环配置找不到";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("id", id);
				instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
				return;
			}
			if (this.RingConfig.IsT1)
			{
				this.IsWholeRing = (this.RingConfig.AsT1.InvalidBoxLength == 0);
			}
			else if (this.RingConfig.IsT2)
			{
				this.IsWholeRing = (this.RingConfig.AsT2.InvalidBox.Count == 0);
			}
			EArrowDirection arrowDirection = EArrowDirection.Clockwise;
			if (this.RingConfig.IsT1)
			{
				arrowDirection = (this.RingConfig.AsT1.IsAnticlockwise ? EArrowDirection.Anticlockwise : EArrowDirection.Clockwise);
			}
			else if (this.RingConfig.IsT2)
			{
				arrowDirection = (this.RingConfig.AsT2.IsAnticlockwise ? EArrowDirection.Anticlockwise : EArrowDirection.Clockwise);
			}
			this.RingInfo = ModelBase<BigStuffedDollModel>.Instance.GameInfo.AddRingInfo(id, arrowDirection);
			this.RingBg = new BigStuffedRingBgItem(this.Id, this.RingConfig, this.RingInfo);
			this.RingSpecialArea = new BigStuffedRingSpecialAreaItem(this.Id, this.RingConfig, this.RingInfo);
			this.RingLight = new BigStuffedRingLightItem(this.Id, this.RingConfig);
		}

		// Token: 0x06045052 RID: 282706 RVA: 0x011F7FEC File Offset: 0x011F61EC
		public BigStuffedRingItem(int id, AActor actor, [Nullable(2)] BrokenRockRingConfig config)
		{
			this.Id = id;
			this.MyRootActor = actor;
			if (config == null)
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.SceneGameplay;
				ELogAuthor author = ELogAuthor.YSQ;
				string message = "[BigStuffedDoll]环配置找不到";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("id", id);
				instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
				return;
			}
			this.IsWholeRing = (config.InvalidBox.Count == 0);
			EArrowDirection arrowDirection = config.IsAnticlockwise ? EArrowDirection.Anticlockwise : EArrowDirection.Clockwise;
			this.RingInfo = ModelBase<BigStuffedDollModel>.Instance.GameInfo.AddRingInfo(id, arrowDirection);
			this.RingBg = new BigStuffedRingBgItem(this.Id, config, this.RingInfo);
			this.RingSpecialArea = new BigStuffedRingSpecialAreaItem(this.Id, config, this.RingInfo);
			this.RingLight = new BigStuffedRingLightItem(this.Id, config);
		}

		// Token: 0x06045053 RID: 282707 RVA: 0x011F80E0 File Offset: 0x011F62E0
		public UniTask InitAsync()
		{
			BigStuffedRingItem.<InitAsync>d__31 <InitAsync>d__;
			<InitAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<InitAsync>d__.<>4__this = this;
			<InitAsync>d__.<>1__state = -1;
			<InitAsync>d__.<>t__builder.Start<BigStuffedRingItem.<InitAsync>d__31>(ref <InitAsync>d__);
			return <InitAsync>d__.<>t__builder.Task;
		}

		// Token: 0x06045054 RID: 282708 RVA: 0x011F8124 File Offset: 0x011F6324
		protected unsafe override void OnRegisterComponent()
		{
			int num = 6;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUITexture));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(5, typeof(UUIItem));
			this.ComponentRegisterInfos = list;
		}

		// Token: 0x06045055 RID: 282709 RVA: 0x011F8214 File Offset: 0x011F6414
		protected override UniTask OnBeforeStartAsync()
		{
			BigStuffedRingItem.<OnBeforeStartAsync>d__33 <OnBeforeStartAsync>d__;
			<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeStartAsync>d__.<>4__this = this;
			<OnBeforeStartAsync>d__.<>1__state = -1;
			<OnBeforeStartAsync>d__.<>t__builder.Start<BigStuffedRingItem.<OnBeforeStartAsync>d__33>(ref <OnBeforeStartAsync>d__);
			return <OnBeforeStartAsync>d__.<>t__builder.Task;
		}

		// Token: 0x06045056 RID: 282710 RVA: 0x011F8257 File Offset: 0x011F6457
		protected override void OnBeforeDestroy()
		{
			LevelSequencePlayer levelSequencePlayer = this.LevelSequencePlayer;
			if (levelSequencePlayer != null)
			{
				levelSequencePlayer.Clear();
			}
			this.LevelSequencePlayer = null;
		}

		// Token: 0x06045057 RID: 282711 RVA: 0x011F8274 File Offset: 0x011F6474
		[NullableContext(2)]
		public void OnAreaClick(EAreaType areaType, ContinuousArea area)
		{
			this.CurrentAreaType = areaType;
			this.CurrentContinuousIndex = ((area != null) ? area.ContinuousIndex : -1);
			string text = null;
			string text2 = null;
			switch (areaType)
			{
			case EAreaType.BlankArea:
				text = "Miss";
				break;
			case EAreaType.GoodArea:
				text = "Press01";
				text2 = "Light01";
				break;
			case EAreaType.PerfectArea:
			case EAreaType.BonusArea:
				text = "Press02";
				text2 = "Light02";
				break;
			}
			this.LevelSequencePlayer.StopCurrentSequence(true, true);
			if (text != null)
			{
				this.LevelSequencePlayer.PlayLevelSequenceByName(text, false, null, false);
			}
			if (text2 != null)
			{
				this.LevelSequencePlayer.PlayLevelSequenceByName(text2, false, null, false);
			}
		}

		// Token: 0x06045058 RID: 282712 RVA: 0x011F831C File Offset: 0x011F651C
		private void OnSequenceStart(string sequenceName)
		{
			if (sequenceName == "Miss" || sequenceName == "Press01" || sequenceName == "Press02")
			{
				Singleton<EventSystem>.Instance.Emit<int, EAreaType, int>(EEventName.OnBigStuffedDollRingItemSequencePlayStart, this.Id, this.CurrentAreaType, this.CurrentContinuousIndex);
			}
		}

		// Token: 0x06045059 RID: 282713 RVA: 0x011F8374 File Offset: 0x011F6574
		private void OnSequenceClose(string sequenceName)
		{
			if (sequenceName == "Miss" || sequenceName == "Press01" || sequenceName == "Press02")
			{
				Singleton<EventSystem>.Instance.Emit<int, EAreaType, int>(EEventName.OnBigStuffedDollRingItemSequencePlayEnd, this.Id, this.CurrentAreaType, this.CurrentContinuousIndex);
			}
		}

		// Token: 0x0604505A RID: 282714 RVA: 0x011F83CC File Offset: 0x011F65CC
		public void OnArrowEnter()
		{
			this.IsArrowStayHere = true;
			UUIItem arrow = this.Arrow;
			if (arrow != null)
			{
				arrow.SetUIActive(true);
			}
			this.LevelSequencePlayer.StopCurrentSequence(true, true);
			if (!this.InitAnimPlay)
			{
				this.LevelSequencePlayer.PlayLevelSequenceByName("Start01", false, null, false);
				this.InitAnimPlay = true;
				return;
			}
			this.LevelSequencePlayer.PlayLevelSequenceByName("In", false, null, false);
		}

		// Token: 0x0604505B RID: 282715 RVA: 0x011F8448 File Offset: 0x011F6648
		public void OnArrowExit()
		{
			this.IsArrowStayHere = false;
			UUIItem arrow = this.Arrow;
			if (arrow != null)
			{
				arrow.SetUIActive(false);
			}
			this.LevelSequencePlayer.StopCurrentSequence(true, true);
			if (!this.InitAnimPlay)
			{
				this.LevelSequencePlayer.PlayLevelSequenceByName("Start02", false, null, false);
				this.InitAnimPlay = true;
				return;
			}
			this.LevelSequencePlayer.PlayLevelSequenceByName("Out", false, null, false);
		}

		// Token: 0x0604505C RID: 282716 RVA: 0x011F84C4 File Offset: 0x011F66C4
		public void OnArrowStayAreaUpdate(int relativeValidAreaIndex)
		{
			if (!this.IsArrowStayHere)
			{
				return;
			}
			List<Area> validAreas = this.RingInfo.GetValidAreas();
			if (validAreas == null)
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.SceneGameplay;
				ELogAuthor author = ELogAuthor.YSQ;
				string message = "[BigStuffedDoll]初始化Arrow时：找不到有效区域";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("id", this.Id);
				instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
				return;
			}
			if (relativeValidAreaIndex >= 0)
			{
				int? num = (validAreas != null) ? new int?(validAreas.Count) : null;
				if (!(relativeValidAreaIndex >= num.GetValueOrDefault() & num != null))
				{
					Area area = validAreas[relativeValidAreaIndex];
					this.ArrowActiveStartYawAngle = (float)(-(float)Math.Max(area.StartCellIndex - 1, 0)) * 10f;
					this.ArrowActiveEndYawAngle = (float)(-(float)area.EndCellIndex) * 10f;
					if (this.ArrowActiveEndYawAngle >= this.ArrowActiveStartYawAngle)
					{
						this.ArrowActiveEndYawAngle -= 360f;
					}
					EArrowDirection arrowDirection = area.ArrowDirection;
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
					return;
				}
			}
			Log instance2 = Singleton<Log>.Instance;
			ELogModule module2 = ELogModule.SceneGameplay;
			ELogAuthor author2 = ELogAuthor.YSQ;
			string message2 = "[BigStuffedDoll]初始化Arrow时：相对有效区域索引越界";
			ValueTuple<string, object> valueTuple2 = new ValueTuple<string, object>("relativeValidAreaIndex", relativeValidAreaIndex);
			instance2.Error(module2, author2, message2, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple2));
		}

		// Token: 0x0604505D RID: 282717 RVA: 0x011F8630 File Offset: 0x011F6830
		public void OnTick(float delta)
		{
			BigStuffedDollModel instance = ModelBase<BigStuffedDollModel>.Instance;
			if (!this.IsArrowStayHere || this.RingConfig == null)
			{
				return;
			}
			if (instance.GetGameStage() != EGameStage.GamePlaying)
			{
				return;
			}
			int arrowSpeed = instance.GetArrowSpeed(new OneOf<BrokenRockRing, BrokenRockRingConfig>?(this.RingConfig));
			if (arrowSpeed == 0)
			{
				return;
			}
			int num = -1;
			EArrowDirection currentArrowDirection = instance.CurrentArrowDirection;
			if (currentArrowDirection != EArrowDirection.Clockwise)
			{
				if (currentArrowDirection == EArrowDirection.Anticlockwise)
				{
					num = 1;
				}
			}
			else
			{
				num = -1;
			}
			float num2 = delta / 1000f;
			float num3 = this.CurrentRotator.Yaw;
			if (this.IsWholeRing)
			{
				num3 = this.CurrentRotator.Yaw + (float)num * ((float)arrowSpeed * num2);
			}
			else
			{
				num3 = this.CurrentRotator.Yaw + (float)num * ((float)arrowSpeed * num2);
				if (num3 < this.ArrowActiveEndYawAngle)
				{
					num3 = this.ArrowActiveEndYawAngle;
					instance.ArrowDirectionReverse();
				}
				if (num3 > this.ArrowActiveStartYawAngle)
				{
					num3 = this.ArrowActiveStartYawAngle;
					instance.ArrowDirectionReverse();
				}
			}
			this.CurrentRotator.Yaw = num3;
			UUIItem arrow = this.Arrow;
			if (arrow == null)
			{
				return;
			}
			FRotator frotator = this.CurrentRotator.ToUeRotator();
			arrow.SetUIRelativeRotation(frotator);
		}

		// Token: 0x0604505E RID: 282718 RVA: 0x011F873F File Offset: 0x011F693F
		public void SpawnContinuousArea(int continuousIndex)
		{
			this.RingSpecialArea.SpawnSingleContinuousArea(continuousIndex);
		}

		// Token: 0x0604505F RID: 282719 RVA: 0x011F874D File Offset: 0x011F694D
		public int GetCurrentArrowStayCellIndex()
		{
			if (!this.IsArrowStayHere)
			{
				return 0;
			}
			return (int)Math.Floor((double)(Math.Abs(this.CurrentRotator.Yaw) % 360f / 10f)) + 1;
		}

		// Token: 0x040267F7 RID: 157687
		private const string BLANK_QTE_ANIM = "Miss";

		// Token: 0x040267F8 RID: 157688
		private const string GOODAREA_QTE_ANIM = "Press01";

		// Token: 0x040267F9 RID: 157689
		private const string BONUSAREA_QTE_ANIM = "Press02";

		// Token: 0x040267FA RID: 157690
		private const string SWITCH_IN_CURRENT = "In";

		// Token: 0x040267FB RID: 157691
		private const string SWITCH_OUT_CURRENT = "Out";

		// Token: 0x040267FC RID: 157692
		private const string CURRENT_RING_SHOW = "Start01";

		// Token: 0x040267FD RID: 157693
		private const string NOT_CURRENT_RING_SHOW = "Start02";

		// Token: 0x040267FE RID: 157694
		private const string COMMON_LIGHT = "Light01";

		// Token: 0x040267FF RID: 157695
		private const string PERFECT_LIGHT = "Light02";

		// Token: 0x04026800 RID: 157696
		public readonly int Id = -1;

		// Token: 0x04026801 RID: 157697
		[Nullable(new byte[]
		{
			0,
			1
		})]
		private readonly OneOf<BrokenRockRing, BrokenRockRingConfig> RingConfig;

		// Token: 0x04026802 RID: 157698
		[Nullable(2)]
		private readonly BigStuffedRingInfo RingInfo;

		// Token: 0x04026803 RID: 157699
		[Nullable(2)]
		private readonly AActor MyRootActor;

		// Token: 0x04026804 RID: 157700
		[Nullable(2)]
		private readonly BigStuffedRingBgItem RingBg;

		// Token: 0x04026805 RID: 157701
		[Nullable(2)]
		private readonly BigStuffedRingSpecialAreaItem RingSpecialArea;

		// Token: 0x04026806 RID: 157702
		[Nullable(2)]
		private readonly BigStuffedRingLightItem RingLight;

		// Token: 0x04026807 RID: 157703
		[Nullable(2)]
		protected LevelSequencePlayer LevelSequencePlayer;

		// Token: 0x04026808 RID: 157704
		[Nullable(2)]
		private UUIItem Arrow;

		// Token: 0x04026809 RID: 157705
		private bool IsArrowStayHere;

		// Token: 0x0402680A RID: 157706
		private readonly Rotator CurrentRotator = Rotator.Create();

		// Token: 0x0402680B RID: 157707
		private float ArrowActiveStartYawAngle;

		// Token: 0x0402680C RID: 157708
		private float ArrowActiveEndYawAngle;

		// Token: 0x0402680D RID: 157709
		private readonly bool IsWholeRing;

		// Token: 0x0402680E RID: 157710
		private bool InitAnimPlay;

		// Token: 0x0402680F RID: 157711
		private EAreaType CurrentAreaType;

		// Token: 0x04026810 RID: 157712
		private int CurrentContinuousIndex = -1;

		// Token: 0x0200CBFB RID: 52219
		[NullableContext(0)]
		private class EViewComponent
		{
			// Token: 0x0403E8C7 RID: 256199
			public const int FlagCurrentTexture = 0;

			// Token: 0x0403E8C8 RID: 256200
			public const int ContentRoot = 1;

			// Token: 0x0403E8C9 RID: 256201
			public const int Arrow = 2;

			// Token: 0x0403E8CA RID: 256202
			public const int RingBg = 3;

			// Token: 0x0403E8CB RID: 256203
			public const int RingSpecialArea = 4;

			// Token: 0x0403E8CC RID: 256204
			public const int RingLight = 5;
		}
	}
}
