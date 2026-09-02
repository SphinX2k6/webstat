using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.PhantomArena.Prepare.Entrance
{
	// Token: 0x020054C2 RID: 21698
	[NullableContext(1)]
	[Nullable(0)]
	public class PhantomArenaEntranceGymTabView : PhantomArenaChildViewBase
	{
		// Token: 0x17008E95 RID: 36501
		// (get) Token: 0x06037440 RID: 226368 RVA: 0x00E0572B File Offset: 0x00E0392B
		// (set) Token: 0x06037441 RID: 226369 RVA: 0x00E05738 File Offset: 0x00E03938
		public new PhantomArenaEntranceViewModel ViewModel
		{
			get
			{
				return this.ViewModel as PhantomArenaEntranceViewModel;
			}
			set
			{
				this.ViewModel = value;
			}
		}

		// Token: 0x06037442 RID: 226370 RVA: 0x00E05744 File Offset: 0x00E03944
		protected override void OnRegisterComponent()
		{
			this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
			{
				new ValueTuple<int, Type>(0, typeof(UUIDraggableComponent)),
				new ValueTuple<int, Type>(1, typeof(UUIItem)),
				new ValueTuple<int, Type>(2, typeof(UUIItem)),
				new ValueTuple<int, Type>(3, typeof(UUIItem)),
				new ValueTuple<int, Type>(4, typeof(UUIItem)),
				new ValueTuple<int, Type>(5, typeof(UUIItem)),
				new ValueTuple<int, Type>(6, typeof(UUIItem)),
				new ValueTuple<int, Type>(7, typeof(UUIItem)),
				new ValueTuple<int, Type>(8, typeof(UUIItem)),
				new ValueTuple<int, Type>(9, typeof(UUIButtonComponent)),
				new ValueTuple<int, Type>(10, typeof(UUIButtonComponent)),
				new ValueTuple<int, Type>(11, typeof(UUIButtonComponent)),
				new ValueTuple<int, Type>(12, typeof(UUIItem)),
				new ValueTuple<int, Type>(13, typeof(UUIItem)),
				new ValueTuple<int, Type>(14, typeof(UUIItem)),
				new ValueTuple<int, Type>(15, typeof(UUISprite)),
				new ValueTuple<int, Type>(16, typeof(UUIItem)),
				new ValueTuple<int, Type>(17, typeof(UUIItem)),
				new ValueTuple<int, Type>(18, typeof(UUIItem))
			};
			this.BtnBindInfo = new List<ValueTuple<int, Delegate>>
			{
				new ValueTuple<int, Delegate>(9, new Action(this.OnClickCard)),
				new ValueTuple<int, Delegate>(10, new Action(this.OnClickRole)),
				new ValueTuple<int, Delegate>(11, new Action(this.OnClickCollect))
			};
		}

		// Token: 0x06037443 RID: 226371 RVA: 0x00E05960 File Offset: 0x00E03B60
		protected override UniTask OnBeforeStartAsync()
		{
			PhantomArenaEntranceGymTabView.<OnBeforeStartAsync>d__15 <OnBeforeStartAsync>d__;
			<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeStartAsync>d__.<>4__this = this;
			<OnBeforeStartAsync>d__.<>1__state = -1;
			<OnBeforeStartAsync>d__.<>t__builder.Start<PhantomArenaEntranceGymTabView.<OnBeforeStartAsync>d__15>(ref <OnBeforeStartAsync>d__);
			return <OnBeforeStartAsync>d__.<>t__builder.Task;
		}

		// Token: 0x06037444 RID: 226372 RVA: 0x00E059A4 File Offset: 0x00E03BA4
		protected override void OnStart()
		{
			base.GetItem(1).SetWidth(base.GetItem(13).GetWidth());
			DragInteractParam param = new DragInteractParam
			{
				Draggable = base.GetDraggable(0),
				CallbackOnDown = new Action(this.OnDown),
				CallbackOnDrag = new Action<Vector2D>(this.OnDrag),
				CallbackOnInertia = new Action<Vector2D>(this.OnInertia)
			};
			this.TweenerDelegate = global::DelegateUtils.ToManualReleaseDelegate<FLTweenVector2SetterDynamic>(new Action<FVector2D>(this.OnTweenUpdate));
			this.DragComponent = new DragInteractComponent(param);
			this.SequencePlayer.BindOnEndSequenceEvent(new Action<string>(this.OnSequenceEnd));
			FVector2D anchorOffset = base.GetItem(14).GetAnchorOffset();
			this.GymOffset = Vector2D.Create((double)anchorOffset.X, (double)anchorOffset.Y);
		}

		// Token: 0x06037445 RID: 226373 RVA: 0x00E05A74 File Offset: 0x00E03C74
		protected override void OnBeforeShow()
		{
			this.DragComponent.Enable();
			this.BindRedDot();
			this.RefreshBackground();
			this.RefreshBtns();
		}

		// Token: 0x06037446 RID: 226374 RVA: 0x00E05A93 File Offset: 0x00E03C93
		protected override void OnAfterShow()
		{
			this.UpdateBgOffsetMin();
		}

		// Token: 0x06037447 RID: 226375 RVA: 0x00E05A9B File Offset: 0x00E03C9B
		protected override void OnBeforeHide()
		{
			this.UnBindRedDot();
			this.DragComponent.Disable();
		}

		// Token: 0x06037448 RID: 226376 RVA: 0x00E05AAE File Offset: 0x00E03CAE
		protected override void OnAddEventListener()
		{
			Singleton<EventSystem>.Instance.Add(EEventName.UIViewPortSizeChanged, new Action(this.OnViewportSizeChange));
			Singleton<EventSystem>.Instance.Add(EEventName.OnPhantomArenaChallengeUpdate, new Action(this.OnChallengeUpdate));
		}

		// Token: 0x06037449 RID: 226377 RVA: 0x00E05AE5 File Offset: 0x00E03CE5
		protected override void OnRemoveEventListener()
		{
			Singleton<EventSystem>.Instance.Remove(EEventName.UIViewPortSizeChanged, new Action(this.OnViewportSizeChange));
			Singleton<EventSystem>.Instance.Remove(EEventName.OnPhantomArenaChallengeUpdate, new Action(this.OnChallengeUpdate));
		}

		// Token: 0x0603744A RID: 226378 RVA: 0x00E05B1C File Offset: 0x00E03D1C
		private void OnViewportSizeChange()
		{
			this.UpdateBgOffsetMin();
			FVector2D anchorOffset = base.GetItem(13).GetAnchorOffset();
			this.SetPosition(Vector2D.Create((double)anchorOffset.X, (double)anchorOffset.Y), false);
		}

		// Token: 0x0603744B RID: 226379 RVA: 0x00E05B58 File Offset: 0x00E03D58
		protected override void OnBeforeDestroy()
		{
			global::DelegateUtils.ReleaseManualReleaseDelegate(new Action<FVector2D>(this.OnTweenUpdate));
			if (this.GuideTimerHandle != null && TimerSystem.RealTimeInstance.Has(this.GuideTimerHandle))
			{
				TimerSystem.RealTimeInstance.Remove(this.GuideTimerHandle);
				this.GuideTimerHandle = null;
			}
		}

		// Token: 0x0603744C RID: 226380 RVA: 0x00E05BA8 File Offset: 0x00E03DA8
		private void RefreshBackground()
		{
			if (this.IsSwitching)
			{
				this.SequencePlayer.StopPrevSequence(true, true);
			}
			this.Background.RefreshBg(true, this.LastHoverLevel);
			this.IsSwitching = true;
			this.SequencePlayer.PlaySequence("AreaSwitch", false, new float?(1.6f));
		}

		// Token: 0x0603744D RID: 226381 RVA: 0x00E05C00 File Offset: 0x00E03E00
		private void RefreshBtns()
		{
			bool flag = ModelBase<FunctionModel>.Instance.IsOpen(EFunctionType.PhantomArenaCard);
			base.SetButtonUiActive(9, flag);
			bool flag2 = ModelBase<FunctionModel>.Instance.IsOpen(EFunctionType.PhantomArenaRole);
			base.SetButtonUiActive(10, flag2);
			bool flag3 = ModelBase<FunctionModel>.Instance.IsOpen(EFunctionType.PhantomArenaCollect);
			base.SetButtonUiActive(11, flag3);
			base.GetSprite(15).SetUIActive(flag || flag2 || flag3);
		}

		// Token: 0x0603744E RID: 226382 RVA: 0x00E05C6C File Offset: 0x00E03E6C
		private void PlayUnlock()
		{
			foreach (GymItemBase gymItemBase in this.GymItemMap.Values)
			{
				gymItemBase.PlayUnlock();
			}
		}

		// Token: 0x0603744F RID: 226383 RVA: 0x00E05CC4 File Offset: 0x00E03EC4
		private void OnClickLevel(int level)
		{
			PhantomBattleGym? phantomBattleGymConfigByLevel = ModelBase<PhantomArenaModel>.Instance.GetPhantomBattleGymConfigByLevel(level, base.ActivityId);
			if (phantomBattleGymConfigByLevel == null)
			{
				return;
			}
			if (phantomBattleGymConfigByLevel.Value.IfRepeat)
			{
				this.ViewModel.SetTabView(EPhantomArenaChildViewName.PhantomArenaEntranceRepeatTabView, false);
				return;
			}
			BattleMatchViewOpenParam param = new BattleMatchViewOpenParam
			{
				Level = level,
				ActivityId = base.ActivityId
			};
			Singleton<UiManager>.Instance.OpenView(EUiViewName.PhantomArenaMatchView, param, null);
		}

		// Token: 0x06037450 RID: 226384 RVA: 0x00E05D38 File Offset: 0x00E03F38
		private void OnFocusLevel(int level)
		{
			this.KillPositionTweener(new bool?(true));
			Vector2D gymFocusPosition = this.GetGymFocusPosition(level);
			this.SetPosition(gymFocusPosition, true);
		}

		// Token: 0x06037451 RID: 226385 RVA: 0x00E05D64 File Offset: 0x00E03F64
		private Vector2D GetGymFocusPosition(int level)
		{
			double num = this.GymItemMap[level].GetAnchorOffsetX() - -700.0;
			return Vector2D.Create(330.0 - num, 0.0);
		}

		// Token: 0x06037452 RID: 226386 RVA: 0x00E05DA6 File Offset: 0x00E03FA6
		private void OnHoverLevel(int level)
		{
			if (PhantomArenaDefine.positionGymLevel[this.LastHoverLevel - 1] == PhantomArenaDefine.positionGymLevel[level - 1])
			{
				return;
			}
			this.LastHoverLevel = level;
			this.RefreshBackground();
		}

		// Token: 0x06037453 RID: 226387 RVA: 0x00E05DD4 File Offset: 0x00E03FD4
		private void OnUnHoverLevel(int level)
		{
		}

		// Token: 0x06037454 RID: 226388 RVA: 0x00E05DD6 File Offset: 0x00E03FD6
		private void OnSequenceEnd(string sequenceName)
		{
			if (sequenceName == "AreaSwitch")
			{
				this.IsSwitching = false;
				this.Background.RefreshBg(false, this.LastHoverLevel);
				return;
			}
			if (sequenceName == "Start")
			{
				this.PlayUnlock();
			}
		}

		// Token: 0x06037455 RID: 226389 RVA: 0x00E05E14 File Offset: 0x00E04014
		private void OnClickCard()
		{
			PhantomArenaMainViewOpenParam param = new PhantomArenaMainViewOpenParam
			{
				ChallengeId = 0,
				OpenView = EPhantomArenaChildViewName.PhantomArenaDeckOverviewTabView,
				ActivityId = base.ActivityId
			};
			Singleton<UiManager>.Instance.OpenView(EUiViewName.PhantomArenaMainView, param, null);
		}

		// Token: 0x06037456 RID: 226390 RVA: 0x00E05E54 File Offset: 0x00E04054
		private void OnClickRole()
		{
			PhantomArenaMainViewOpenParam param = new PhantomArenaMainViewOpenParam
			{
				ChallengeId = 0,
				OpenView = EPhantomArenaChildViewName.PhantomArenaRoleSelectTabView,
				ActivityId = base.ActivityId
			};
			Singleton<UiManager>.Instance.OpenView(EUiViewName.PhantomArenaMainView, param, null);
		}

		// Token: 0x06037457 RID: 226391 RVA: 0x00E05E92 File Offset: 0x00E04092
		private void OnClickCollect()
		{
			Singleton<UiManager>.Instance.OpenView(EUiViewName.PhantomArenaCollectView, base.ActivityId, null);
		}

		// Token: 0x06037458 RID: 226392 RVA: 0x00E05EAF File Offset: 0x00E040AF
		private void OnDown()
		{
			this.KillPositionTweener(new bool?(true));
		}

		// Token: 0x06037459 RID: 226393 RVA: 0x00E05EC0 File Offset: 0x00E040C0
		private void OnDrag(Vector2D delta)
		{
			if (this.GymOffset == null)
			{
				return;
			}
			Vector2D inTarget = Vector2D.Create(this.GymOffset).AdditionEqual(delta);
			this.SetPosition(inTarget, false);
		}

		// Token: 0x0603745A RID: 226394 RVA: 0x00E05EF0 File Offset: 0x00E040F0
		private void OnInertia(Vector2D speed)
		{
			Vector2D vector2D = Vector2D.Create();
			speed.Multiply(0.6179999709129333, vector2D);
			Vector2D inTarget = Vector2D.Create(this.GymOffset).AdditionEqual(vector2D);
			this.SetPosition(inTarget, true);
		}

		// Token: 0x0603745B RID: 226395 RVA: 0x00E05F30 File Offset: 0x00E04130
		[NullableContext(2)]
		public void SetPosition(Vector2D inTarget, bool bUseTween)
		{
			if (inTarget == null)
			{
				return;
			}
			Vector2D vector2D = Vector2D.Create();
			if (inTarget != null)
			{
				vector2D.DeepCopy(inTarget);
			}
			Vector2D position = Vector2D.Create(vector2D.X, vector2D.Y);
			vector2D = this.ClampPosition(position);
			FVector2D startValue = this.GymOffset.ToUeVector2D(false);
			FVector2D fvector2D = vector2D.ToUeVector2D(false);
			bool flag = this.NearlyPosition(this.GymOffset.X, (double)fvector2D.X);
			if (!bUseTween || flag)
			{
				FVector2D anchorOffset = vector2D.ToUeVector2D(false);
				FVector2D anchorOffset2 = Vector2D.Create(vector2D.X * 0.85, vector2D.Y).ToUeVector2D(false);
				base.GetItem(14).SetAnchorOffset(anchorOffset2);
				base.GetItem(13).SetAnchorOffset(anchorOffset);
				this.GymOffset = vector2D;
				return;
			}
			this.KillPositionTweener(null);
			this.PositionTweener = ULTweenBPLibrary.Vector2To(GlobalData.World, this.TweenerDelegate, startValue, fvector2D, 0.618f, 0f, LTweenEase.OutQuad);
		}

		// Token: 0x0603745C RID: 226396 RVA: 0x00E06028 File Offset: 0x00E04228
		private bool NearlyPosition(double srcPositionX, double dstPositionX)
		{
			return Singleton<MathUtils>.Instance.IsNearlyEqual(srcPositionX, dstPositionX, null);
		}

		// Token: 0x0603745D RID: 226397 RVA: 0x00E0604A File Offset: 0x00E0424A
		private Vector2D ClampPosition(Vector2D position)
		{
			double x = position.X;
			return Vector2D.Create(MathCommon.Clamp(position.X, this.BgOffsetMin, 330.0), 0.0);
		}

		// Token: 0x0603745E RID: 226398 RVA: 0x00E0607B File Offset: 0x00E0427B
		private void KillPositionTweener(bool? callComplete = null)
		{
			ULTweener positionTweener = this.PositionTweener;
			if (positionTweener != null && positionTweener.IsValid())
			{
				this.PositionTweener.Kill(callComplete.GetValueOrDefault());
				this.PositionTweener = null;
			}
		}

		// Token: 0x0603745F RID: 226399 RVA: 0x00E060AC File Offset: 0x00E042AC
		private void UpdateBgOffsetMin()
		{
			double num = (double)base.GetItem(13).Width;
			double num2 = (double)base.GetItem(13).GetParentAsUIItem().Width;
			this.BgOffsetMin = num2 - num;
		}

		// Token: 0x06037460 RID: 226400 RVA: 0x00E060E8 File Offset: 0x00E042E8
		private void OnTweenUpdate(FVector2D value)
		{
			Vector2D inTarget = Vector2D.Create(value);
			this.SetPosition(inTarget, false);
		}

		// Token: 0x06037461 RID: 226401 RVA: 0x00E0610C File Offset: 0x00E0430C
		private void BindRedDot()
		{
			this.UnBindRedDot();
			ControllerBase<RedDotController>.Instance.BindRedDot(ERedDotName.RedDotPhantomArenaCollect, base.GetItem(18), null, base.ActivityId);
			ControllerBase<RedDotController>.Instance.BindRedDot(ERedDotName.RedDotPhantomArenaRole, base.GetItem(17), null, base.ActivityId);
			base.GetItem(16).SetUIActive(false);
			foreach (GymItemBase gymItemBase in this.GymItemMap.Values)
			{
				gymItemBase.RefreshRedDot();
			}
		}

		// Token: 0x06037462 RID: 226402 RVA: 0x00E061B4 File Offset: 0x00E043B4
		private void UnBindRedDot()
		{
			ControllerBase<RedDotController>.Instance.UnBindGivenUi(ERedDotName.RedDotPhantomArenaCollect, base.GetItem(18), 0);
			ControllerBase<RedDotController>.Instance.UnBindGivenUi(ERedDotName.RedDotPhantomArenaRole, base.GetItem(17), 0);
		}

		// Token: 0x06037463 RID: 226403 RVA: 0x00E061E8 File Offset: 0x00E043E8
		private void OnChallengeUpdate()
		{
			foreach (GymItemBase gymItemBase in this.GymItemMap.Values)
			{
				gymItemBase.RefreshRedDot();
			}
		}

		// Token: 0x06037464 RID: 226404 RVA: 0x00E06240 File Offset: 0x00E04440
		[return: Nullable(new byte[]
		{
			2,
			1
		})]
		public override UUIItem[] GetGuideUiItemAndUiItemForShowEx([Nullable(new byte[]
		{
			2,
			1
		})] string[] configParams)
		{
			if (configParams == null || configParams.Length == 0)
			{
				return null;
			}
			if (!(configParams[0] == "GuideHook"))
			{
				return null;
			}
			if (configParams.Length < 2)
			{
				return null;
			}
			string text = configParams[1];
			UUIItem guideUiItem = base.GetGuideUiItem(text);
			if (text == "1")
			{
				this.GuideTimerHandle = TimerSystem.RealTimeInstance.Delay(delegate(float _)
				{
					this.OnFocusLevel(7);
				}, 1000f, null, null, true, 1f);
			}
			if (guideUiItem == null)
			{
				return null;
			}
			return new UUIItem[]
			{
				guideUiItem,
				guideUiItem
			};
		}

		// Token: 0x0401FC48 RID: 130120
		private int LastHoverLevel = 1;

		// Token: 0x0401FC49 RID: 130121
		private bool IsSwitching;

		// Token: 0x0401FC4A RID: 130122
		private readonly Dictionary<int, GymItemBase> GymItemMap = new Dictionary<int, GymItemBase>();

		// Token: 0x0401FC4B RID: 130123
		[Nullable(2)]
		private DragInteractComponent DragComponent;

		// Token: 0x0401FC4C RID: 130124
		[Nullable(2)]
		private Vector2D GymOffset;

		// Token: 0x0401FC4D RID: 130125
		[Nullable(2)]
		private EntranceBackgroundPanel Background;

		// Token: 0x0401FC4E RID: 130126
		[Nullable(2)]
		private ULTweener PositionTweener;

		// Token: 0x0401FC4F RID: 130127
		[Nullable(2)]
		private FLTweenVector2SetterDynamic TweenerDelegate;

		// Token: 0x0401FC50 RID: 130128
		private double BgOffsetMin;

		// Token: 0x0401FC51 RID: 130129
		[Nullable(2)]
		private TimerHandle GuideTimerHandle;

		// Token: 0x0200B42A RID: 46122
		[NullableContext(0)]
		private class EComponent
		{
			// Token: 0x04037C19 RID: 228377
			public const int DragLevel = 0;

			// Token: 0x04037C1A RID: 228378
			public const int ContentMain = 1;

			// Token: 0x04037C1B RID: 228379
			public const int BtnLevel1 = 2;

			// Token: 0x04037C1C RID: 228380
			public const int BtnLevel2 = 3;

			// Token: 0x04037C1D RID: 228381
			public const int BtnLevel3 = 4;

			// Token: 0x04037C1E RID: 228382
			public const int BtnLevel4 = 5;

			// Token: 0x04037C1F RID: 228383
			public const int BtnLevel5 = 6;

			// Token: 0x04037C20 RID: 228384
			public const int BtnLevel6 = 7;

			// Token: 0x04037C21 RID: 228385
			public const int BtnLevel7 = 8;

			// Token: 0x04037C22 RID: 228386
			public const int BtnMenuCard = 9;

			// Token: 0x04037C23 RID: 228387
			public const int BtnMenuRole = 10;

			// Token: 0x04037C24 RID: 228388
			public const int BtnMenuCollect = 11;

			// Token: 0x04037C25 RID: 228389
			public const int PanelBg = 12;

			// Token: 0x04037C26 RID: 228390
			public const int ContentBg = 13;

			// Token: 0x04037C27 RID: 228391
			public const int PanelBtnLevel = 14;

			// Token: 0x04037C28 RID: 228392
			public const int SpriteBtnBg = 15;

			// Token: 0x04037C29 RID: 228393
			public const int ItemRedDotCard = 16;

			// Token: 0x04037C2A RID: 228394
			public const int ItemRedDotRole = 17;

			// Token: 0x04037C2B RID: 228395
			public const int ItemRedDotCollect = 18;
		}
	}
}
