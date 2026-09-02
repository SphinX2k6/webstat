using System;
using System.Runtime.CompilerServices;
using Aki.TDConfigMgr.Action;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.LevelGamePlay.OperationRestrict;
using CSharpScript.Game.Ui;

namespace CSharpScript.Game.LevelGamePlay.SwordControl
{
	// Token: 0x02006A99 RID: 27289
	[NullableContext(1)]
	[Nullable(0)]
	public class SwordControlGroundController : IStaticVariableResetter
	{
		// Token: 0x060437B7 RID: 276407 RVA: 0x01162D60 File Offset: 0x01160F60
		static SwordControlGroundController()
		{
			StaticVariableRegister.RegisterAndExecute(new Action(SwordControlGroundController.CreateStaticDefaultValue), new Action(SwordControlGroundController.ResetStaticDefaultValue));
		}

		// Token: 0x060437B8 RID: 276408 RVA: 0x01162E88 File Offset: 0x01161088
		public static void CreateStaticDefaultValue()
		{
			SwordControlGroundController.Owner = SwordControlGroundController.ESwordControlGroundOwner.None;
			SwordControlGroundController.ViewId = null;
			SwordControlGroundController.TemporaryTimer = null;
			SwordControlGroundController.IsOpening = false;
			SwordControlGroundController.IsClosing = false;
			SwordControlGroundController.InputRestricted = false;
			SwordControlGroundController.CloseAfterOpen = false;
			SwordControlGroundController.PendingGameplayOpenAfterClose = false;
			SwordControlGroundController.PendingTemporaryDuration = 3000f;
			SwordControlGroundController.CloseEventListening = false;
		}

		// Token: 0x060437B9 RID: 276409 RVA: 0x01162EDC File Offset: 0x011610DC
		public static void ResetStaticDefaultValue()
		{
			SwordControlGroundController.Owner = SwordControlGroundController.ESwordControlGroundOwner.None;
			SwordControlGroundController.ViewId = null;
			SwordControlGroundController.TemporaryTimer = null;
			SwordControlGroundController.IsOpening = false;
			SwordControlGroundController.IsClosing = false;
			SwordControlGroundController.InputRestricted = false;
			SwordControlGroundController.CloseAfterOpen = false;
			SwordControlGroundController.PendingGameplayOpenAfterClose = false;
			SwordControlGroundController.PendingTemporaryDuration = 3000f;
			SwordControlGroundController.CloseEventListening = false;
		}

		// Token: 0x060437BA RID: 276410 RVA: 0x01162F30 File Offset: 0x01161130
		public static void OpenTemporary(float duration = 3000f)
		{
			if (SwordControlGroundController.Owner == SwordControlGroundController.ESwordControlGroundOwner.Gameplay)
			{
				SwordControlGroundController.LogReturn("OpenTemporary", "GameplayOwner", 0);
				return;
			}
			if (SwordControlGroundController.IsClosing)
			{
				SwordControlGroundController.LogReturn("OpenTemporary", "Closing", 0);
				return;
			}
			float num = SwordControlGroundController.NormalizeDuration(duration);
			if (SwordControlGroundController.Owner == SwordControlGroundController.ESwordControlGroundOwner.Temporary)
			{
				SwordControlGroundController.PendingTemporaryDuration = num;
				if (!SwordControlGroundController.IsOpening)
				{
					SwordControlGroundController.StartTemporaryTimer(num);
				}
				return;
			}
			if (SwordControlGroundController.IsOpening)
			{
				SwordControlGroundController.LogReturn("OpenTemporary", "OpeningWithoutTemporaryOwner", 0);
				return;
			}
			if (Singleton<UiManager>.Instance.IsViewOpen(EUiViewName.SwordControlGroundView))
			{
				SwordControlGroundController.LogReturn("OpenTemporary", "ViewAlreadyOpenWithoutOwner", 0);
				return;
			}
			SwordControlGroundController.Owner = SwordControlGroundController.ESwordControlGroundOwner.Temporary;
			SwordControlGroundController.IsOpening = true;
			SwordControlGroundController.CloseAfterOpen = false;
			SwordControlGroundController.PendingTemporaryDuration = num;
			UiManager instance = Singleton<UiManager>.Instance;
			EUiViewName swordControlGroundView = EUiViewName.SwordControlGroundView;
			object param = null;
			TOpenViewCallBack finishCallback;
			if ((finishCallback = SwordControlGroundController.<>O.<0>__OnOpenViewFinished) == null)
			{
				finishCallback = (SwordControlGroundController.<>O.<0>__OnOpenViewFinished = new TOpenViewCallBack(SwordControlGroundController.OnOpenViewFinished));
			}
			instance.OpenView(swordControlGroundView, param, finishCallback);
		}

		// Token: 0x060437BB RID: 276411 RVA: 0x01163010 File Offset: 0x01161210
		public static void OpenByGameplay()
		{
			SwordControlGroundController.RemoveTemporaryTimer();
			if (SwordControlGroundController.IsClosing)
			{
				SwordControlGroundController.LogReturn("OpenByGameplay", "ClosingAndPendingOpen", 0);
				SwordControlGroundController.PendingGameplayOpenAfterClose = true;
				return;
			}
			if (SwordControlGroundController.IsOpening)
			{
				SwordControlGroundController.Owner = SwordControlGroundController.ESwordControlGroundOwner.Gameplay;
				SwordControlGroundController.CloseAfterOpen = false;
				SwordControlGroundController.LogReturn("OpenByGameplay", "OpeningAndPendingOpen", 0);
				return;
			}
			if (SwordControlGroundController.Owner == SwordControlGroundController.ESwordControlGroundOwner.Gameplay)
			{
				SwordControlGroundController.LogReturn("OpenByGameplay", "GameplayOwner", 0);
				return;
			}
			if (SwordControlGroundController.Owner == SwordControlGroundController.ESwordControlGroundOwner.Temporary)
			{
				SwordControlGroundController.Owner = SwordControlGroundController.ESwordControlGroundOwner.Gameplay;
				SwordControlGroundController.CloseAfterOpen = false;
				SwordControlGroundController.LogReturn("OpenByGameplay", "TemporaryOwner", 0);
				return;
			}
			SwordControlGroundController.Owner = SwordControlGroundController.ESwordControlGroundOwner.Gameplay;
			SwordControlGroundController.IsOpening = true;
			SwordControlGroundController.CloseAfterOpen = false;
			UiManager instance = Singleton<UiManager>.Instance;
			EUiViewName swordControlGroundView = EUiViewName.SwordControlGroundView;
			object param = null;
			TOpenViewCallBack finishCallback;
			if ((finishCallback = SwordControlGroundController.<>O.<0>__OnOpenViewFinished) == null)
			{
				finishCallback = (SwordControlGroundController.<>O.<0>__OnOpenViewFinished = new TOpenViewCallBack(SwordControlGroundController.OnOpenViewFinished));
			}
			instance.OpenView(swordControlGroundView, param, finishCallback);
		}

		// Token: 0x060437BC RID: 276412 RVA: 0x011630E0 File Offset: 0x011612E0
		public static void CloseByGameplay()
		{
			if (SwordControlGroundController.Owner != SwordControlGroundController.ESwordControlGroundOwner.Gameplay)
			{
				SwordControlGroundController.LogReturn("CloseByGameplay", "NotGameplayOwner", 0);
				return;
			}
			SwordControlGroundController.RemoveTemporaryTimer();
			if (SwordControlGroundController.IsOpening && SwordControlGroundController.ViewId == null)
			{
				SwordControlGroundController.LogReturn("CloseByGameplay", "OpeningWithoutViewId", 0);
				SwordControlGroundController.Owner = SwordControlGroundController.ESwordControlGroundOwner.None;
				SwordControlGroundController.CloseAfterOpen = true;
				return;
			}
			SwordControlGroundController.Owner = SwordControlGroundController.ESwordControlGroundOwner.None;
			SwordControlGroundController.CloseCurrentView();
		}

		// Token: 0x060437BD RID: 276413 RVA: 0x01163148 File Offset: 0x01161348
		private static void OnOpenViewFinished(bool success, int viewId)
		{
			SwordControlGroundController.IsOpening = false;
			if (!success)
			{
				SwordControlGroundController.LogReturn("OnOpenViewFinished", "OpenFailed", viewId);
				SwordControlGroundController.ResetState();
				return;
			}
			SwordControlGroundController.ViewId = new int?(viewId);
			SwordControlGroundController.AddCloseEventListener();
			SwordControlGroundController.SetInputRestricted(true);
			if (SwordControlGroundController.CloseAfterOpen || SwordControlGroundController.Owner == SwordControlGroundController.ESwordControlGroundOwner.None)
			{
				SwordControlGroundController.LogReturn("OnOpenViewFinished", "CloseAfterOpen", viewId);
				SwordControlGroundController.CloseAfterOpen = false;
				SwordControlGroundController.CloseCurrentView();
				return;
			}
			if (SwordControlGroundController.Owner == SwordControlGroundController.ESwordControlGroundOwner.Temporary)
			{
				SwordControlGroundController.StartTemporaryTimer(SwordControlGroundController.PendingTemporaryDuration);
			}
		}

		// Token: 0x060437BE RID: 276414 RVA: 0x011631C8 File Offset: 0x011613C8
		private static void StartTemporaryTimer(float duration)
		{
			SwordControlGroundController.RemoveTemporaryTimer();
			SwordControlGroundController.TemporaryTimer = TimerSystem.GameplayTimeInstance.Delay(delegate(float _)
			{
				SwordControlGroundController.OnTemporaryTimerFinished();
			}, duration, null, "SwordControlGroundController.OpenTemporary", true, 1f);
		}

		// Token: 0x060437BF RID: 276415 RVA: 0x01163215 File Offset: 0x01161415
		private static void OnTemporaryTimerFinished()
		{
			SwordControlGroundController.TemporaryTimer = null;
			if (SwordControlGroundController.Owner != SwordControlGroundController.ESwordControlGroundOwner.Temporary)
			{
				SwordControlGroundController.LogReturn("OnTemporaryTimerFinished", "NotTemporaryOwner", 0);
				return;
			}
			SwordControlGroundController.Owner = SwordControlGroundController.ESwordControlGroundOwner.None;
			SwordControlGroundController.CloseCurrentView();
		}

		// Token: 0x060437C0 RID: 276416 RVA: 0x01163244 File Offset: 0x01161444
		private static void CloseCurrentView()
		{
			if (SwordControlGroundController.ViewId == null)
			{
				SwordControlGroundController.LogReturn("CloseCurrentView", "ViewIdUndefined", 0);
				SwordControlGroundController.ResetState();
				return;
			}
			int viewId = SwordControlGroundController.ViewId.Value;
			SwordControlGroundController.IsClosing = true;
			Singleton<UiManager>.Instance.CloseViewById(viewId, delegate(bool _)
			{
				int? viewId = SwordControlGroundController.ViewId;
				int viewId2 = viewId;
				if (viewId.GetValueOrDefault() == viewId2 & viewId != null)
				{
					SwordControlGroundController.ResetState();
				}
			});
		}

		// Token: 0x060437C1 RID: 276417 RVA: 0x011632AB File Offset: 0x011614AB
		private static void AddCloseEventListener()
		{
			if (SwordControlGroundController.CloseEventListening)
			{
				return;
			}
			EventSystem instance = Singleton<EventSystem>.Instance;
			EEventName name = EEventName.CloseView;
			Action<EUiViewName, int> handle;
			if ((handle = SwordControlGroundController.<>O.<1>__OnCloseView) == null)
			{
				handle = (SwordControlGroundController.<>O.<1>__OnCloseView = new Action<EUiViewName, int>(SwordControlGroundController.OnCloseView));
			}
			instance.Add<EUiViewName, int>(name, handle);
			SwordControlGroundController.CloseEventListening = true;
		}

		// Token: 0x060437C2 RID: 276418 RVA: 0x011632E3 File Offset: 0x011614E3
		private static void RemoveCloseEventListener()
		{
			if (!SwordControlGroundController.CloseEventListening)
			{
				return;
			}
			EventSystem instance = Singleton<EventSystem>.Instance;
			EEventName name = EEventName.CloseView;
			Action<EUiViewName, int> handle;
			if ((handle = SwordControlGroundController.<>O.<1>__OnCloseView) == null)
			{
				handle = (SwordControlGroundController.<>O.<1>__OnCloseView = new Action<EUiViewName, int>(SwordControlGroundController.OnCloseView));
			}
			instance.Remove<EUiViewName, int>(name, handle);
			SwordControlGroundController.CloseEventListening = false;
		}

		// Token: 0x060437C3 RID: 276419 RVA: 0x0116331C File Offset: 0x0116151C
		private static void OnCloseView(EUiViewName viewName, int viewId)
		{
			if (!(viewName != EUiViewName.SwordControlGroundView))
			{
				int? viewId2 = SwordControlGroundController.ViewId;
				if (viewId == viewId2.GetValueOrDefault() & viewId2 != null)
				{
					bool pendingGameplayOpenAfterClose = SwordControlGroundController.PendingGameplayOpenAfterClose;
					SwordControlGroundController.ResetState();
					if (pendingGameplayOpenAfterClose)
					{
						SwordControlGroundController.OpenByGameplay();
					}
					return;
				}
			}
		}

		// Token: 0x060437C4 RID: 276420 RVA: 0x01163364 File Offset: 0x01161564
		private static void ResetState()
		{
			SwordControlGroundController.RemoveTemporaryTimer();
			SwordControlGroundController.RemoveCloseEventListener();
			SwordControlGroundController.Owner = SwordControlGroundController.ESwordControlGroundOwner.None;
			SwordControlGroundController.ViewId = null;
			SwordControlGroundController.IsOpening = false;
			SwordControlGroundController.IsClosing = false;
			SwordControlGroundController.CloseAfterOpen = false;
			SwordControlGroundController.PendingGameplayOpenAfterClose = false;
			SwordControlGroundController.PendingTemporaryDuration = 3000f;
			SwordControlGroundController.SetInputRestricted(false);
		}

		// Token: 0x060437C5 RID: 276421 RVA: 0x011633B4 File Offset: 0x011615B4
		private static void RemoveTemporaryTimer()
		{
			TimerHandle temporaryTimer = SwordControlGroundController.TemporaryTimer;
			if (temporaryTimer != null)
			{
				temporaryTimer.Remove();
			}
			SwordControlGroundController.TemporaryTimer = null;
		}

		// Token: 0x060437C6 RID: 276422 RVA: 0x011633CD File Offset: 0x011615CD
		private static float NormalizeDuration(float duration)
		{
			if (duration <= 0f)
			{
				return 3000f;
			}
			return duration;
		}

		// Token: 0x060437C7 RID: 276423 RVA: 0x011633DE File Offset: 0x011615DE
		private static void SetInputRestricted(bool restricted)
		{
			if (SwordControlGroundController.InputRestricted == restricted)
			{
				return;
			}
			SwordControlGroundController.InputRestricted = restricted;
			Singleton<OperationRestrictUtils>.Instance.SetOperationRestrictByOption(restricted ? SwordControlGroundController.restrictOperationOption : SwordControlGroundController.enableOperationOption);
		}

		// Token: 0x060437C8 RID: 276424 RVA: 0x01163408 File Offset: 0x01161608
		private unsafe static void LogReturn(string method, string reason, int viewId = 0)
		{
			if (viewId == 0)
			{
				viewId = SwordControlGroundController.ViewId.GetValueOrDefault();
			}
			global::Log instance = Singleton<global::Log>.Instance;
			ELogModule module = ELogModule.Level;
			ELogAuthor author = ELogAuthor.HF;
			string message = "[SwordControlGroundController]接口调用提前返回";
			<>y__InlineArray8<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray8<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray8<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("method", method);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray8<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("reason", reason);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray8<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 2) = new ValueTuple<string, object>("owner", SwordControlGroundController.GetOwnerName());
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray8<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 3) = new ValueTuple<string, object>("viewId", viewId);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray8<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 4) = new ValueTuple<string, object>("isOpening", SwordControlGroundController.IsOpening);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray8<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 5) = new ValueTuple<string, object>("isClosing", SwordControlGroundController.IsClosing);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray8<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 6) = new ValueTuple<string, object>("closeAfterOpen", SwordControlGroundController.CloseAfterOpen);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray8<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 7) = new ValueTuple<string, object>("pendingGameplayOpenAfterClose", SwordControlGroundController.PendingGameplayOpenAfterClose);
			instance.Info(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray8<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 8));
		}

		// Token: 0x060437C9 RID: 276425 RVA: 0x01163534 File Offset: 0x01161734
		private static string GetOwnerName()
		{
			SwordControlGroundController.ESwordControlGroundOwner owner = SwordControlGroundController.Owner;
			if (owner == SwordControlGroundController.ESwordControlGroundOwner.Temporary)
			{
				return "Temporary";
			}
			if (owner != SwordControlGroundController.ESwordControlGroundOwner.Gameplay)
			{
				return "None";
			}
			return "Gameplay";
		}

		// Token: 0x04025B0C RID: 154380
		private const float DEFAULT_TEMPORARY_DURATION = 3000f;

		// Token: 0x04025B0D RID: 154381
		[StaticVariableRuleIgnore]
		private static readonly IDisableModulePlayerOperation restrictOperationOption = new IDisableModulePlayerOperation
		{
			Type = EPlayerOperationType.DisableModule,
			SkillOption = new IDisableSectionalSkillOperation
			{
				Type = ESkillOperationType.DisableSection,
				DisplayMode = new EDisplayModeInSkillOp?(EDisplayModeInSkillOp.Disable),
				DisableSkillWheel = new bool?(true),
				DisableBattleSkill = new IDisableBattleSkillOptions
				{
					IsDisablePhantomSkill = new bool?(true),
					IsDisableCharacterSectionalSkill = new IDisableCharacterSectionalSkillOption
					{
						DisableJump = new bool?(true),
						DisableShowClimb = new bool?(true),
						DisableDodge = new bool?(true),
						DisableSkill1 = new bool?(true),
						DisableUltimateSkill = new bool?(true),
						DisableExploreInput = new bool?(true),
						DisableSwitchRole1 = new bool?(true),
						DisableSwitchRole2 = new bool?(true),
						DisableSwitchRole3 = new bool?(true),
						DisableLock = new bool?(true),
						DisableAim = new bool?(true)
					}
				},
				DisableSwitchRole = new bool?(true)
			}
		};

		// Token: 0x04025B0E RID: 154382
		[StaticVariableRuleIgnore]
		private static readonly IEnableAllPlayerOperation enableOperationOption = new IEnableAllPlayerOperation
		{
			Type = EPlayerOperationType.EnableAll
		};

		// Token: 0x04025B0F RID: 154383
		private static SwordControlGroundController.ESwordControlGroundOwner Owner;

		// Token: 0x04025B10 RID: 154384
		private static int? ViewId;

		// Token: 0x04025B11 RID: 154385
		[Nullable(2)]
		private static TimerHandle TemporaryTimer;

		// Token: 0x04025B12 RID: 154386
		private static bool IsOpening;

		// Token: 0x04025B13 RID: 154387
		private static bool IsClosing;

		// Token: 0x04025B14 RID: 154388
		private static bool InputRestricted;

		// Token: 0x04025B15 RID: 154389
		private static bool CloseAfterOpen;

		// Token: 0x04025B16 RID: 154390
		private static bool PendingGameplayOpenAfterClose;

		// Token: 0x04025B17 RID: 154391
		private static float PendingTemporaryDuration;

		// Token: 0x04025B18 RID: 154392
		private static bool CloseEventListening;

		// Token: 0x0200C9D8 RID: 51672
		[NullableContext(0)]
		private enum ESwordControlGroundOwner
		{
			// Token: 0x0403E081 RID: 254081
			None,
			// Token: 0x0403E082 RID: 254082
			Temporary,
			// Token: 0x0403E083 RID: 254083
			Gameplay
		}

		// Token: 0x0200C9D9 RID: 51673
		[CompilerGenerated]
		private static class <>O
		{
			// Token: 0x0403E084 RID: 254084
			[Nullable(0)]
			public static TOpenViewCallBack <0>__OnOpenViewFinished;

			// Token: 0x0403E085 RID: 254085
			[Nullable(0)]
			public static Action<EUiViewName, int> <1>__OnCloseView;
		}
	}
}
