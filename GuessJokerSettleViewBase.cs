using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using AkiClient.Game.Aki.Character.BaseCharacter;
using CSharpScript.Game.Module.Activity.ActivityContent.SpringManor;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using UnrealEngine;

// Token: 0x02001126 RID: 4390
[NullableContext(1)]
[Nullable(0)]
public abstract class GuessJokerSettleViewBase : UiViewBase, IUiCameraBehavior
{
	// Token: 0x060072B0 RID: 29360 RVA: 0x001DF91F File Offset: 0x001DDB1F
	protected GuessJokerSettleViewBase(UiViewInfo viewInfo) : base(viewInfo)
	{
	}

	// Token: 0x060072B1 RID: 29361 RVA: 0x001DF928 File Offset: 0x001DDB28
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUIItem)),
			new ValueTuple<int, Type>(1, typeof(UUIText)),
			new ValueTuple<int, Type>(2, typeof(UUITexture)),
			new ValueTuple<int, Type>(3, typeof(UUIText)),
			new ValueTuple<int, Type>(4, typeof(UUIButtonComponent)),
			new ValueTuple<int, Type>(5, typeof(UUIButtonComponent)),
			new ValueTuple<int, Type>(6, typeof(UUIItem)),
			new ValueTuple<int, Type>(7, typeof(UUIText)),
			new ValueTuple<int, Type>(8, typeof(UUIText))
		};
		this.BtnBindInfo = new List<ValueTuple<int, Delegate>>
		{
			new ValueTuple<int, Delegate>(4, new Action(this.OnClickRematchButton)),
			new ValueTuple<int, Delegate>(5, new Action(this.OnClickConfirmButton))
		};
	}

	// Token: 0x060072B2 RID: 29362 RVA: 0x001DFA44 File Offset: 0x001DDC44
	protected override void OnStart()
	{
		bool uiactive = true;
		int levelId = ModelBase<GuessJokerGamePlayModel>.Instance.GetLevelId();
		bool firstPass = ModelBase<SpringManorModel>.Instance.ActivityData.GetGuessJokerGameData(levelId).FirstPass;
		if (!ModelBase<GuessJokerGamePlayModel>.Instance.IsFinish && firstPass)
		{
			uiactive = false;
		}
		UUIButtonComponent button = base.GetButton(4);
		if (button == null)
		{
			return;
		}
		button.RootUIComp.Get().SetUIActive(uiactive);
	}

	// Token: 0x060072B3 RID: 29363 RVA: 0x001DFAA8 File Offset: 0x001DDCA8
	protected override void OnBeforeShow()
	{
		this.PauseTimeDilation();
		if (this.DialogLogic == null)
		{
			this.DialogLogic = new GuessJokerDialogLogic();
		}
		this.DialogLogic.InitData(new GuessJokerDialogData
		{
			GetDialogItem = ((EGuessJokerPlayerType playerType) => base.GetItem(6)),
			GetDialogText = ((EGuessJokerPlayerType playerType) => base.GetText(8))
		});
		UUIItem item = base.GetItem(6);
		if (item != null)
		{
			item.SetUIActive(false);
		}
		UUIText text = base.GetText(1);
		Singleton<LguiUtil>.Instance.SetLocalTextNew(text, "GuessJoker_WinText", new <>z__ReadOnlySingleElementList<object>(this.GetWinnerName()));
		base.SetTextureByPath(this.GetEmojiTexturePath(), base.GetTexture(2), null, null);
		base.GetText(3).ShowTextNew(this.GetDescText());
		string playerNameByType = ModelBase<GuessJokerGamePlayModel>.Instance.GetPlayerNameByType(EGuessJokerPlayerType.Ai);
		base.GetText(7).SetText(playerNameByType, true);
	}

	// Token: 0x060072B4 RID: 29364 RVA: 0x001DFB81 File Offset: 0x001DDD81
	protected override void OnAfterShow()
	{
		GuessJokerGamePlayModel instance = ModelBase<GuessJokerGamePlayModel>.Instance;
		if (instance != null)
		{
			instance.SetActiveDialogLogic(this.DialogLogic);
		}
		GuessJokerGamePlayModel instance2 = ModelBase<GuessJokerGamePlayModel>.Instance;
		if (instance2 == null)
		{
			return;
		}
		instance2.SetNpcPokerState(this.GetNpcPokerState());
	}

	// Token: 0x060072B5 RID: 29365 RVA: 0x001DFBAF File Offset: 0x001DDDAF
	protected override void OnBeforeHide()
	{
		GuessJokerGamePlayModel instance = ModelBase<GuessJokerGamePlayModel>.Instance;
		if (instance != null)
		{
			instance.SetActiveDialogLogic(null);
		}
		GuessJokerDialogLogic dialogLogic = this.DialogLogic;
		if (dialogLogic != null)
		{
			dialogLogic.Clear();
		}
		this.ResumeTimeDilation();
	}

	// Token: 0x060072B6 RID: 29366 RVA: 0x001DFBD9 File Offset: 0x001DDDD9
	protected void PauseTimeDilation()
	{
		Singleton<UiTimeDilation>.Instance.AddWaitSetTimeDilationTag("GuessJokerSettleViewBase");
	}

	// Token: 0x060072B7 RID: 29367 RVA: 0x001DFBEA File Offset: 0x001DDDEA
	protected void ResumeTimeDilation()
	{
		Singleton<UiTimeDilation>.Instance.DeleteWaitSetTimeDilationTag("GuessJokerSettleViewBase");
	}

	// Token: 0x060072B8 RID: 29368 RVA: 0x001DFBFC File Offset: 0x001DDDFC
	public void PushCameraHandle(EUiViewName viewName, int viewId, bool isBlend)
	{
		int roleId = ModelBase<GuessJokerGamePlayModel>.Instance.GetRoleId();
		GuessJokerAiConfig? jokerAiConfigByRoleId = ConfigBase<GuessJokerConfig>.Instance.GetJokerAiConfigByRoleId(roleId);
		if (jokerAiConfigByRoleId == null)
		{
			return;
		}
		string cameraNameByCameraId = GuessJokerUtils.GetCameraNameByCameraId(jokerAiConfigByRoleId.Value.SettleCameraId);
		if (cameraNameByCameraId != null)
		{
			this.CameraName = cameraNameByCameraId;
			ControllerBase<UiCameraAnimationController>.Instance.PushCameraHandle((EUiViewName)cameraNameByCameraId, new int?(viewId), isBlend);
		}
	}

	// Token: 0x060072B9 RID: 29369 RVA: 0x001DFC60 File Offset: 0x001DDE60
	[NullableContext(2)]
	public void PopCameraHandle(EUiViewName viewName, UiViewInfo stackTopInfo, int closeViewId, bool popOrDelete)
	{
		if (this.CameraName != null)
		{
			ControllerBase<UiCameraAnimationController>.Instance.PopCameraHandle((EUiViewName)this.CameraName, stackTopInfo, closeViewId, popOrDelete);
			this.CameraName = null;
		}
	}

	// Token: 0x060072BA RID: 29370 RVA: 0x001DFC8C File Offset: 0x001DDE8C
	private void OnClickRematchButton()
	{
		int levelId = ModelBase<GuessJokerGamePlayModel>.Instance.GetLevelId();
		ControllerBase<GuessJokerController>.Instance.RequestJokerGuessRematch(levelId, delegate
		{
			base.CloseMe(null);
		});
	}

	// Token: 0x060072BB RID: 29371 RVA: 0x001DFCBC File Offset: 0x001DDEBC
	private void OnClickConfirmButton()
	{
		int levelId = ModelBase<GuessJokerGamePlayModel>.Instance.GetLevelId();
		ModelBase<GuessJokerGamePlayModel>.Instance.ExitGame();
		bool flag = false;
		bool firstPass = ModelBase<SpringManorModel>.Instance.ActivityData.GetGuessJokerGameData(levelId).FirstPass;
		if (!ModelBase<GuessJokerGamePlayModel>.Instance.IsFinish && firstPass)
		{
			flag = true;
		}
		if (flag && levelId == 1010)
		{
			ModelBase<GuessJokerGamePlayModel>.Instance.HideAllGuessJokerNpc();
			base.CloseMe(null);
			return;
		}
		ModelBase<GuessJokerGamePlayModel>.Instance.OpenSelectRoleView(0).ContinueWith(delegate()
		{
			base.CloseMe(null);
		}).Forget();
	}

	// Token: 0x060072BC RID: 29372
	protected abstract string GetWinnerName();

	// Token: 0x060072BD RID: 29373
	protected abstract EPokerStateType GetNpcPokerState();

	// Token: 0x060072BE RID: 29374
	protected abstract string GetEmojiTexturePath();

	// Token: 0x060072BF RID: 29375
	protected abstract EUiViewName GetViewName();

	// Token: 0x060072C0 RID: 29376
	protected abstract string GetDescText();

	// Token: 0x04003768 RID: 14184
	[Nullable(2)]
	protected string CameraName;

	// Token: 0x04003769 RID: 14185
	[Nullable(2)]
	private GuessJokerDialogLogic DialogLogic;
}
