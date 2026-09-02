using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.BattleUi.Views;
using CSharpScript.Game.NewWorld.Character.Role.Component;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x0200235A RID: 9050
[NullableContext(2)]
[Nullable(0)]
public class FreeRunningQteView : PanelQteView
{
	// Token: 0x060114B0 RID: 70832 RVA: 0x004C1E56 File Offset: 0x004C0056
	[NullableContext(1)]
	public FreeRunningQteView(UiViewInfo viewInfo) : base(viewInfo)
	{
	}

	// Token: 0x060114B1 RID: 70833 RVA: 0x004C1E78 File Offset: 0x004C0078
	protected unsafe override void OnRegisterComponent()
	{
		base.OnRegisterComponent();
		int num;
		Span<ValueTuple<int, Type>> span;
		int num2;
		if (this.IsMobile)
		{
			num = 3;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIButtonComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUISprite));
			this.ComponentRegisterInfos = list;
			return;
		}
		num2 = 5;
		List<ValueTuple<int, Type>> list2 = new List<ValueTuple<int, Type>>(num2);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list2, num2);
		span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list2);
		num = 0;
		*span[num] = new ValueTuple<int, Type>(0, typeof(UUIItem));
		num++;
		*span[num] = new ValueTuple<int, Type>(1, typeof(UUIItem));
		num++;
		*span[num] = new ValueTuple<int, Type>(2, typeof(UUIItem));
		num++;
		*span[num] = new ValueTuple<int, Type>(3, typeof(UUISprite));
		num++;
		*span[num] = new ValueTuple<int, Type>(4, typeof(UUIButtonComponent));
		this.ComponentRegisterInfos = list2;
	}

	// Token: 0x060114B2 RID: 70834 RVA: 0x004C1FD0 File Offset: 0x004C01D0
	protected override UniTask OnBeforeStartAsync()
	{
		FreeRunningQteView.<OnBeforeStartAsync>d__14 <OnBeforeStartAsync>d__;
		<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnBeforeStartAsync>d__.<>4__this = this;
		<OnBeforeStartAsync>d__.<>1__state = -1;
		<OnBeforeStartAsync>d__.<>t__builder.Start<FreeRunningQteView.<OnBeforeStartAsync>d__14>(ref <OnBeforeStartAsync>d__);
		return <OnBeforeStartAsync>d__.<>t__builder.Task;
	}

	// Token: 0x060114B3 RID: 70835 RVA: 0x004C2014 File Offset: 0x004C0214
	protected override void OnStart()
	{
		if (this.IsMobile)
		{
			this.AnimItem = base.GetItem(0);
			this.BtnClick = base.GetButton(1);
			UUIButtonComponent btnClick = this.BtnClick;
			if (btnClick != null)
			{
				btnClick.OnPointDownCallBack.Bind(new Action(this.OnPress));
			}
		}
		else
		{
			this.AnimItem = base.GetItem(0);
			this.BtnClick = base.GetButton(4);
			UUIButtonComponent btnClick2 = this.BtnClick;
			if (btnClick2 != null)
			{
				btnClick2.SetActive(false, false);
			}
		}
		this.LevelSequencePlayer = new LevelSequencePlayer(this.AnimItem);
		this.LevelSequencePlayer.BindSequenceCloseEvent(new TSequenceEndEvent(this.OnSequenceEndEvent), false);
		this.InitQteData();
	}

	// Token: 0x060114B4 RID: 70836 RVA: 0x004C20C3 File Offset: 0x004C02C3
	protected override void OnAfterPlayStartSequence()
	{
		this.OnViewSequenceEndEvent();
	}

	// Token: 0x060114B5 RID: 70837 RVA: 0x004C20CB File Offset: 0x004C02CB
	protected override void OnBeforeDestroyImplement()
	{
		LevelSequencePlayer levelSequencePlayer = this.LevelSequencePlayer;
		if (levelSequencePlayer == null)
		{
			return;
		}
		levelSequencePlayer.Clear();
	}

	// Token: 0x060114B6 RID: 70838 RVA: 0x004C20E0 File Offset: 0x004C02E0
	private void OnViewSequenceEndEvent()
	{
		if (this.IsQteEnd)
		{
			return;
		}
		UUIItem animItem = this.AnimItem;
		if (animItem != null)
		{
			animItem.SetUIActive(true);
		}
		LevelSequencePlayer levelSequencePlayer = this.LevelSequencePlayer;
		if (levelSequencePlayer == null)
		{
			return;
		}
		levelSequencePlayer.PlayLevelSequenceByName("Start", false, null, false);
	}

	// Token: 0x060114B7 RID: 70839 RVA: 0x004C2128 File Offset: 0x004C0328
	[NullableContext(1)]
	private void OnSequenceEndEvent(string sequenceName)
	{
		if (sequenceName == "Start")
		{
			if (this.IsQteEnd)
			{
				return;
			}
			LevelSequencePlayer levelSequencePlayer = this.LevelSequencePlayer;
			if (levelSequencePlayer != null)
			{
				levelSequencePlayer.PlayLevelSequenceByName("Loop", false, null, false);
			}
			if (this.LoopDuration > 0)
			{
				if (this.IsPause)
				{
					this.SetPlayRate("Loop", 0f);
				}
				else
				{
					this.SetPlayRate("Loop", 1f / this.LoopDuration);
				}
			}
			int handleId = (int)(this.OpenParam ?? 0);
			ModelBase<PanelQteModel>.Instance.ResetLeftTime(handleId);
			if (!this.IsMobile)
			{
				UUIItem item = base.GetItem(1);
				if (item != null)
				{
					item.SetUIActive(true);
				}
				CombineKeyItem keyItem = this.KeyItem;
				if (keyItem != null)
				{
					keyItem.Show(null);
				}
			}
			this.IsQteStart = true;
		}
	}

	// Token: 0x060114B8 RID: 70840 RVA: 0x004C2210 File Offset: 0x004C0410
	protected override void OnBeforeShow()
	{
		base.OnBeforeShow();
		if (!ModelBase<PanelQteModel>.Instance.IsInQte.GetValueOrDefault())
		{
			Singleton<Log>.Instance.Info(ELogModule.PanelQte, ELogAuthor.WWJ, "界面打开时qte已经结束了", default(ReadOnlySpan<ValueTuple<string, object>>));
			Singleton<UiManager>.Instance.CloseView(EUiViewName.FreeRunningQteView, null);
		}
	}

	// Token: 0x060114B9 RID: 70841 RVA: 0x004C2263 File Offset: 0x004C0463
	protected override void OnAfterShow()
	{
		base.OnAfterShow();
		this.ResumeQte();
	}

	// Token: 0x060114BA RID: 70842 RVA: 0x004C2271 File Offset: 0x004C0471
	protected override void OnBeforeHide()
	{
		this.PauseQte();
		base.OnBeforeHide();
	}

	// Token: 0x060114BB RID: 70843 RVA: 0x004C227F File Offset: 0x004C047F
	protected override void OnBeforeDestroy()
	{
		base.OnBeforeDestroy();
		if (this.IsMobile)
		{
			UUIButtonComponent btnClick = this.BtnClick;
			if (btnClick != null)
			{
				btnClick.OnPointDownCallBack.Unbind();
			}
		}
		this.StopDelayTimer();
	}

	// Token: 0x060114BC RID: 70844 RVA: 0x004C22AB File Offset: 0x004C04AB
	protected override void RefreshVisible()
	{
	}

	// Token: 0x060114BD RID: 70845 RVA: 0x004C22AD File Offset: 0x004C04AD
	private void StopDelayTimer()
	{
		if (this.DelayTimer != null)
		{
			TimerSystem.Instance.Remove(this.DelayTimer);
			this.DelayTimer = null;
		}
	}

	// Token: 0x060114BE RID: 70846 RVA: 0x004C22D0 File Offset: 0x004C04D0
	private UniTask LoadIcon([Nullable(new byte[]
	{
		2,
		1
	})] TSoftObjectPtr<ULGUITexturePackerSpriteData> iconRef)
	{
		FreeRunningQteView.<LoadIcon>d__26 <LoadIcon>d__;
		<LoadIcon>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<LoadIcon>d__.<>4__this = this;
		<LoadIcon>d__.iconRef = iconRef;
		<LoadIcon>d__.<>1__state = -1;
		<LoadIcon>d__.<>t__builder.Start<FreeRunningQteView.<LoadIcon>d__26>(ref <LoadIcon>d__);
		return <LoadIcon>d__.<>t__builder.Task;
	}

	// Token: 0x060114BF RID: 70847 RVA: 0x004C231C File Offset: 0x004C051C
	private void InitQteData()
	{
		int num = (int)(this.OpenParam ?? 0);
		if (!ModelBase<PanelQteModel>.Instance.IsInQte.GetValueOrDefault())
		{
			Singleton<Log>.Instance.Info(ELogModule.PanelQte, ELogAuthor.WWJ, "界面打开时qte已经结束了", default(ReadOnlySpan<ValueTuple<string, object>>));
			Singleton<UiManager>.Instance.CloseView(EUiViewName.FreeRunningQteView, null);
			return;
		}
		PanelQteContext context = ModelBase<PanelQteModel>.Instance.GetContext();
		if (num != context.QteHandleId)
		{
			Singleton<Log>.Instance.Error(ELogModule.PanelQte, ELogAuthor.WWJ, "qte handleId 不匹配", default(ReadOnlySpan<ValueTuple<string, object>>));
			Singleton<UiManager>.Instance.CloseView(EUiViewName.FreeRunningQteView, null);
			return;
		}
		this.LoopDuration = context.Config.Duration;
		this.QteAction = context.Config.Action;
		this.IsQteInteractive = true;
		Singleton<EventSystem>.Instance.Emit<string>(EEventName.FreeRunningQteStart, this.QteAction);
	}

	// Token: 0x060114C0 RID: 70848 RVA: 0x004C2408 File Offset: 0x004C0608
	protected override void OnAddEventListener()
	{
		base.OnAddEventListener();
		Singleton<EventSystem>.Instance.Add(EEventName.TriggerUiTimeDilation, new Action(this.OnTriggerUiTimeDilation));
		this.BindAction();
	}

	// Token: 0x060114C1 RID: 70849 RVA: 0x004C242F File Offset: 0x004C062F
	protected override void OnRemoveEventListener()
	{
		base.OnRemoveEventListener();
		Singleton<EventSystem>.Instance.Remove(EEventName.TriggerUiTimeDilation, new Action(this.OnTriggerUiTimeDilation));
		this.UnbindAction();
	}

	// Token: 0x060114C2 RID: 70850 RVA: 0x004C2458 File Offset: 0x004C0658
	private void BindAction()
	{
		if (this.HasBindAction)
		{
			return;
		}
		this.HasBindAction = true;
		if (!this.IsMobile)
		{
			PanelQteContext context = ModelBase<PanelQteModel>.Instance.GetContext();
			this.QteAction = context.Config.Action;
			CombineKeyItem keyItem = this.KeyItem;
			if (keyItem != null)
			{
				keyItem.RefreshAction(this.QteAction);
			}
			ControllerBase<InputDistributeController>.Instance.BindAction(this.QteAction, new TInputHandle<InputDistributeDefine.EActionType>(this.OnInputCallback));
		}
	}

	// Token: 0x060114C3 RID: 70851 RVA: 0x004C24CC File Offset: 0x004C06CC
	private void UnbindAction()
	{
		if (!this.HasBindAction)
		{
			return;
		}
		this.HasBindAction = false;
		if (!this.IsMobile)
		{
			ControllerBase<InputDistributeController>.Instance.UnBindAction(this.QteAction, new TInputHandle<InputDistributeDefine.EActionType>(this.OnInputCallback));
			this.QteAction = string.Empty;
		}
	}

	// Token: 0x060114C4 RID: 70852 RVA: 0x004C2518 File Offset: 0x004C0718
	private void OnTriggerUiTimeDilation()
	{
		if (Singleton<Time>.Instance.TimeDilation == 0f)
		{
			this.PauseQte();
			return;
		}
		this.ResumeQte();
	}

	// Token: 0x060114C5 RID: 70853 RVA: 0x004C2538 File Offset: 0x004C0738
	private bool IsValidInput()
	{
		if (this.IsQteEnd || (!this.IsQteStart && !this.IsQteInteractive))
		{
			return false;
		}
		if (this.QteAction == "幻象1")
		{
			TsBaseCharacter baseCharacter = Global.BaseCharacter;
			if (baseCharacter == null || !baseCharacter.IsValid())
			{
				return false;
			}
			CharacterActorComponent characterActorComponent = baseCharacter.CharacterActorComponent;
			Entity entity = (characterActorComponent != null) ? characterActorComponent.Entity : null;
			if (entity == null)
			{
				return false;
			}
			RoleSceneInteractComponent component = entity.GetComponent<RoleSceneInteractComponent>();
			if (component == null || !component.CanActivateFixHook())
			{
				return false;
			}
		}
		return true;
	}

	// Token: 0x060114C6 RID: 70854 RVA: 0x004C25B1 File Offset: 0x004C07B1
	[NullableContext(1)]
	private void OnInputCallback(string actionName, InputDistributeDefine.EActionType actionType, InputIdentification identification)
	{
		if (!this.IsValidInput())
		{
			return;
		}
		if (actionType == InputDistributeDefine.EActionType.Press)
		{
			this.OnInput();
		}
	}

	// Token: 0x060114C7 RID: 70855 RVA: 0x004C25C5 File Offset: 0x004C07C5
	private void OnPress()
	{
		if (!this.IsValidInput())
		{
			return;
		}
		this.OnInput();
	}

	// Token: 0x060114C8 RID: 70856 RVA: 0x004C25D8 File Offset: 0x004C07D8
	private void OnInput()
	{
		int handleId = (int)(this.OpenParam ?? 0);
		ModelBase<PanelQteModel>.Instance.SetQteResult(handleId, true);
		ControllerBase<PanelQteController>.Instance.StopQte(handleId, false);
	}

	// Token: 0x060114C9 RID: 70857 RVA: 0x004C2618 File Offset: 0x004C0818
	protected override void HandleQteEnd()
	{
		if (this.DelayTimer != null)
		{
			return;
		}
		if (!this.IsMobile)
		{
			base.GetItem(1).SetUIActive(false);
		}
		LevelSequencePlayer levelSequencePlayer = this.LevelSequencePlayer;
		if (levelSequencePlayer != null)
		{
			levelSequencePlayer.StopCurrentSequence(false, false);
		}
		if (ModelBase<PanelQteModel>.Instance.IsQteSuccess())
		{
			LevelSequencePlayer levelSequencePlayer2 = this.LevelSequencePlayer;
			if (levelSequencePlayer2 != null)
			{
				levelSequencePlayer2.PlayLevelSequenceByName("Success", false, null, false);
			}
		}
		else
		{
			LevelSequencePlayer levelSequencePlayer3 = this.LevelSequencePlayer;
			if (levelSequencePlayer3 != null)
			{
				levelSequencePlayer3.PlayLevelSequenceByName("Fail", false, null, false);
			}
		}
		this.DelayTimer = TimerSystem.Instance.Delay(delegate(float _)
		{
			this.DelayTimer = null;
			Singleton<UiManager>.Instance.CloseView(EUiViewName.FreeRunningQteView, null);
		}, 500f, null, null, true, 1f);
	}

	// Token: 0x060114CA RID: 70858 RVA: 0x004C26CF File Offset: 0x004C08CF
	[NullableContext(1)]
	private void SetPlayRate(string sequenceName, float playRate)
	{
		AUIBaseActor auibaseActor = this.AnimItem.GetOwner() as AUIBaseActor;
		if (auibaseActor == null)
		{
			return;
		}
		ALevelSequenceActor sequencePlayerByKey = auibaseActor.GetSequencePlayerByKey(sequenceName);
		if (sequencePlayerByKey == null)
		{
			return;
		}
		ULevelSequencePlayer sequencePlayer = sequencePlayerByKey.SequencePlayer;
		if (sequencePlayer == null)
		{
			return;
		}
		sequencePlayer.SetPlayRate(playRate);
	}

	// Token: 0x060114CB RID: 70859 RVA: 0x004C2701 File Offset: 0x004C0901
	private void PauseQte()
	{
		this.IsPause = true;
		if (this.DelayTimer != null)
		{
			this.DelayTimer.Pause();
		}
		this.SetPlayRate("Loop", 0f);
	}

	// Token: 0x060114CC RID: 70860 RVA: 0x004C2730 File Offset: 0x004C0930
	private void ResumeQte()
	{
		if (this.IsPause)
		{
			if (this.DelayTimer != null)
			{
				this.DelayTimer.Resume();
			}
			this.SetPlayRate("Loop", 1f / this.LoopDuration);
			this.IsPause = false;
		}
	}

	// Token: 0x040087E1 RID: 34785
	private CombineKeyItem KeyItem;

	// Token: 0x040087E2 RID: 34786
	private TimerHandle DelayTimer;

	// Token: 0x040087E3 RID: 34787
	private UUIItem AnimItem;

	// Token: 0x040087E4 RID: 34788
	private UUIButtonComponent BtnClick;

	// Token: 0x040087E5 RID: 34789
	private UUISprite IconItem;

	// Token: 0x040087E6 RID: 34790
	private LevelSequencePlayer LevelSequencePlayer;

	// Token: 0x040087E7 RID: 34791
	private Number LoopDuration = 0;

	// Token: 0x040087E8 RID: 34792
	private bool HasBindAction;

	// Token: 0x040087E9 RID: 34793
	[Nullable(1)]
	private string QteAction = string.Empty;

	// Token: 0x040087EA RID: 34794
	private bool IsQteInteractive;

	// Token: 0x0200866A RID: 34410
	[NullableContext(0)]
	private enum EPadChildType
	{
		// Token: 0x0402D78E RID: 186254
		AnimItem,
		// Token: 0x0402D78F RID: 186255
		BtnClick,
		// Token: 0x0402D790 RID: 186256
		Icon
	}

	// Token: 0x0200866B RID: 34411
	[NullableContext(0)]
	private enum EDesktopChildType
	{
		// Token: 0x0402D792 RID: 186258
		AnimItem,
		// Token: 0x0402D793 RID: 186259
		KeyItemContainer,
		// Token: 0x0402D794 RID: 186260
		KeyItem,
		// Token: 0x0402D795 RID: 186261
		Icon,
		// Token: 0x0402D796 RID: 186262
		BtnClick
	}
}
