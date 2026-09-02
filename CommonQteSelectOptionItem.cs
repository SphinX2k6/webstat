using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using AkiClient.Game.Aki.Data.Qte;
using CSharpScript.Core.Common;
using CSharpScript.Game.Module.SkillButtonUi;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x02002624 RID: 9764
[NullableContext(1)]
[Nullable(0)]
public class CommonQteSelectOptionItem : UiPanelBase
{
	// Token: 0x06013358 RID: 78680 RVA: 0x00555A1E File Offset: 0x00553C1E
	public void Init(int index, SCommonQteButton config, CommonQteSelectOptionPanel parent)
	{
		this.Index = index;
		this.UiConfig = config;
		this.ParentItem = parent;
	}

	// Token: 0x06013359 RID: 78681 RVA: 0x00555A38 File Offset: 0x00553C38
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUIExtendToggle)),
			new ValueTuple<int, Type>(1, typeof(UUIItem)),
			new ValueTuple<int, Type>(2, typeof(UUIText)),
			new ValueTuple<int, Type>(3, typeof(UUIItem))
		};
		if (!Singleton<Info>.Instance.IsInTouch())
		{
			this.ComponentRegisterInfos.Add(new ValueTuple<int, Type>(4, typeof(UUIItem)));
		}
	}

	// Token: 0x0601335A RID: 78682 RVA: 0x00555AD0 File Offset: 0x00553CD0
	protected override UniTask OnBeforeStartAsync()
	{
		CommonQteSelectOptionItem.<OnBeforeStartAsync>d__12 <OnBeforeStartAsync>d__;
		<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnBeforeStartAsync>d__.<>4__this = this;
		<OnBeforeStartAsync>d__.<>1__state = -1;
		<OnBeforeStartAsync>d__.<>t__builder.Start<CommonQteSelectOptionItem.<OnBeforeStartAsync>d__12>(ref <OnBeforeStartAsync>d__);
		return <OnBeforeStartAsync>d__.<>t__builder.Task;
	}

	// Token: 0x0601335B RID: 78683 RVA: 0x00555B14 File Offset: 0x00553D14
	protected override void OnStart()
	{
		base.OnStart();
		this.ToggleMain = base.GetExtendToggle(0);
		UUIExtendToggle toggleMain = this.ToggleMain;
		if (toggleMain != null)
		{
			toggleMain.OnPointDownCallBack.Bind(delegate(EToggleState _)
			{
				this.OnPress();
			});
		}
		if (this.KeyItem != null)
		{
			InputMultiKeyItem keyItem = this.KeyItem;
			if (keyItem != null)
			{
				keyItem.Hide(null);
			}
		}
		else
		{
			UUIItem item = base.GetItem(4);
			if (item != null)
			{
				item.SetUIActive(false);
			}
		}
		this.LevelSequencePlayer = new LevelSequencePlayer(this.RootItem);
		this.LevelSequencePlayer.BindSequenceCloseEvent(new TSequenceEndEvent(this.OnSequenceEndEvent), false);
	}

	// Token: 0x0601335C RID: 78684 RVA: 0x00555BB0 File Offset: 0x00553DB0
	protected override void OnBeforeDestroy()
	{
		base.OnBeforeDestroy();
		this.UnbindAction();
		UUIExtendToggle toggleMain = this.ToggleMain;
		if (toggleMain != null)
		{
			toggleMain.OnPointDownCallBack.Unbind();
		}
		LevelSequencePlayer levelSequencePlayer = this.LevelSequencePlayer;
		if (levelSequencePlayer != null)
		{
			levelSequencePlayer.Clear();
		}
		this.CommonQteContext = null;
		this.UiConfig = null;
		this.QteAction = "";
		this.ParentItem = null;
	}

	// Token: 0x0601335D RID: 78685 RVA: 0x00555C10 File Offset: 0x00553E10
	public void SetQteContext(CommonQteContextBase context)
	{
		CommonQteSelectOptionContext commonQteSelectOptionContext = context as CommonQteSelectOptionContext;
		if (commonQteSelectOptionContext == null)
		{
			return;
		}
		this.CommonQteContext = commonQteSelectOptionContext;
		string action = context.GetAction(new int?(this.Index));
		if (!string.IsNullOrEmpty(action))
		{
			this.QteAction = action;
			if (!Singleton<Info>.Instance.IsInTouch())
			{
				InputActionOrAxisKeyItem actionOrAxisKeyItem = new InputActionOrAxisKeyItem
				{
					ActionOrAxisName = action
				};
				InputMultiKeyItem keyItem = this.KeyItem;
				if (keyItem != null)
				{
					keyItem.RefreshByActionOrAxis(actionOrAxisKeyItem, false);
				}
			}
		}
		SCommonQteButton uiConfig = this.UiConfig;
		if (!string.IsNullOrEmpty((uiConfig != null) ? uiConfig.TextId : null))
		{
			UUIText text = base.GetText(2);
			Singleton<LguiUtil>.Instance.SetLocalTextNew(text, this.UiConfig.TextId, Array.Empty<object>());
		}
	}

	// Token: 0x0601335E RID: 78686 RVA: 0x00555CB8 File Offset: 0x00553EB8
	public void PlayQteStart()
	{
		this.OnSequenceEndEvent("Start");
		this.BindAction();
		base.SetUiActive(true);
	}

	// Token: 0x0601335F RID: 78687 RVA: 0x00555CD4 File Offset: 0x00553ED4
	public void PlayQteEnd()
	{
		InputMultiKeyItem keyItem = this.KeyItem;
		if (keyItem != null)
		{
			keyItem.Hide(null);
		}
		LevelSequencePlayer levelSequencePlayer = this.LevelSequencePlayer;
		if (levelSequencePlayer != null)
		{
			levelSequencePlayer.StopCurrentSequence(false, false);
		}
		CommonQteSelectOptionContext commonQteContext = this.CommonQteContext;
		if (commonQteContext != null && commonQteContext.IsSuccess())
		{
			CommonQteSelectOptionContext commonQteContext2 = this.CommonQteContext;
			int? num = (commonQteContext2 != null) ? new int?(commonQteContext2.SelectOption) : null;
			int index = this.Index;
			if (num.GetValueOrDefault() == index & num != null)
			{
				this.OnSequenceEndEvent("Success");
				goto IL_8C;
			}
		}
		this.OnSequenceEndEvent("Fail");
		IL_8C:
		this.UnbindAction();
	}

	// Token: 0x06013360 RID: 78688 RVA: 0x00555D74 File Offset: 0x00553F74
	private void OnSequenceEndEvent(string sequenceName)
	{
		if (sequenceName == "Start")
		{
			LevelSequencePlayer levelSequencePlayer = this.LevelSequencePlayer;
			if (levelSequencePlayer != null)
			{
				levelSequencePlayer.PlayLevelSequenceByName("Loop", false, null, false);
			}
			if (!Singleton<Info>.Instance.IsInTouch())
			{
				InputMultiKeyItem keyItem = this.KeyItem;
				if (keyItem == null)
				{
					return;
				}
				keyItem.Show(null);
				return;
			}
		}
		else if (sequenceName == "Success" || sequenceName == "Fail")
		{
			CommonQteSelectOptionPanel parentItem = this.ParentItem;
			if (parentItem == null)
			{
				return;
			}
			parentItem.OnOptionItemPlayEnded(this);
		}
	}

	// Token: 0x06013361 RID: 78689 RVA: 0x00555DF8 File Offset: 0x00553FF8
	private void BindAction()
	{
		if (this.HasBindAction)
		{
			return;
		}
		this.HasBindAction = true;
		if (!Singleton<Info>.Instance.IsInTouch())
		{
			ControllerBase<InputDistributeController>.Instance.BindActionIgnoreLimit(this.QteAction, new TInputHandle<InputDistributeDefine.EActionType>(this.OnInputCallback));
			if (this.QteAction == "幻象1")
			{
				ControllerBase<InputDistributeController>.Instance.BindActionIgnoreLimit("通用交互", new TInputHandle<InputDistributeDefine.EActionType>(this.OnInputInteract));
			}
		}
	}

	// Token: 0x06013362 RID: 78690 RVA: 0x00555E6C File Offset: 0x0055406C
	private void UnbindAction()
	{
		if (!this.HasBindAction)
		{
			return;
		}
		this.HasBindAction = false;
		if (!Singleton<Info>.Instance.IsInTouch())
		{
			ControllerBase<InputDistributeController>.Instance.UnBindActionIgnoreLimit(this.QteAction, new TInputHandle<InputDistributeDefine.EActionType>(this.OnInputCallback));
			if (this.QteAction == "幻象1")
			{
				ControllerBase<InputDistributeController>.Instance.UnBindActionIgnoreLimit("通用交互", new TInputHandle<InputDistributeDefine.EActionType>(this.OnInputInteract));
			}
		}
	}

	// Token: 0x06013363 RID: 78691 RVA: 0x00555EDE File Offset: 0x005540DE
	private void OnInputCallback(string actionName, InputDistributeDefine.EActionType actionType, InputIdentification inputIdentification)
	{
		CommonQteSelectOptionPanel parentItem = this.ParentItem;
		if (parentItem == null || !parentItem.IsValidInput())
		{
			return;
		}
		this.OnInput(actionType);
	}

	// Token: 0x06013364 RID: 78692 RVA: 0x00555F00 File Offset: 0x00554100
	private void OnInputInteract(string actionName, InputDistributeDefine.EActionType actionType, InputIdentification inputIdentification)
	{
		if (Singleton<Info>.Instance.IsInGamepad())
		{
			SkillButtonUiModel instance = ModelBase<SkillButtonUiModel>.Instance;
			bool flag;
			if (instance == null)
			{
				flag = false;
			}
			else
			{
				SkillButtonUiGamepadDataBase gamepadData = instance.GamepadData;
				flag = ((gamepadData != null) ? new bool?(gamepadData.SwitchInteractData.IsSwitchInteractOpen) : null).GetValueOrDefault();
			}
			if (flag)
			{
				SkillButtonUiModel instance2 = ModelBase<SkillButtonUiModel>.Instance;
				bool flag2;
				if (instance2 == null)
				{
					flag2 = false;
				}
				else
				{
					SkillButtonUiGamepadDataBase gamepadData2 = instance2.GamepadData;
					flag2 = (((gamepadData2 != null) ? new EGamepadSwitchInteractState?(gamepadData2.SwitchInteractData.State) : null).GetValueOrDefault() == EGamepadSwitchInteractState.Explore);
				}
				if (flag2 && this.QteAction == "幻象1")
				{
					this.OnInputCallback(actionName, actionType, inputIdentification);
					return;
				}
			}
		}
	}

	// Token: 0x06013365 RID: 78693 RVA: 0x00555FAD File Offset: 0x005541AD
	public void OnPress()
	{
		CommonQteSelectOptionPanel parentItem = this.ParentItem;
		if (parentItem == null || !parentItem.IsValidInput())
		{
			return;
		}
		this.OnInput(InputDistributeDefine.EActionType.Press);
	}

	// Token: 0x06013366 RID: 78694 RVA: 0x00555FD0 File Offset: 0x005541D0
	private void OnInput(InputDistributeDefine.EActionType actionType)
	{
		if (this.CommonQteContext != null && this.CommonQteContext.IsActive() && this.CommonQteContext.IsPending() && actionType == InputDistributeDefine.EActionType.Press)
		{
			this.CommonQteContext.SelectOption = this.Index;
			this.CommonQteContext.Response();
		}
	}

	// Token: 0x06013367 RID: 78695 RVA: 0x0055601E File Offset: 0x0055421E
	public void OnQtePause()
	{
		this.UnbindAction();
	}

	// Token: 0x06013368 RID: 78696 RVA: 0x00556026 File Offset: 0x00554226
	public void OnQteResume()
	{
		this.BindAction();
	}

	// Token: 0x06013369 RID: 78697 RVA: 0x00556030 File Offset: 0x00554230
	public void RefreshUiOffset()
	{
		SCommonQteButton uiConfig = this.UiConfig;
		if (uiConfig != null)
		{
			UUIItem rootItem = this.RootItem;
			if (rootItem != null)
			{
				rootItem.SetAnchorAlign(uiConfig.AnchorHAlign, uiConfig.AnchorVAlign);
			}
			UUIItem rootItem2 = this.RootItem;
			if (rootItem2 == null)
			{
				return;
			}
			rootItem2.SetAnchorOffset(uiConfig.AnchorOffset);
		}
	}

	// Token: 0x0601336A RID: 78698 RVA: 0x00556080 File Offset: 0x00554280
	public void SetAnchorOffsetX(float offset)
	{
		UUIItem item = base.GetItem(3);
		if (item == null)
		{
			return;
		}
		item.SetAnchorOffsetX(offset);
	}

	// Token: 0x040095EB RID: 38379
	private int Index = -1;

	// Token: 0x040095EC RID: 38380
	private string QteAction = "";

	// Token: 0x040095ED RID: 38381
	private bool HasBindAction;

	// Token: 0x040095EE RID: 38382
	[Nullable(2)]
	private CommonQteSelectOptionContext CommonQteContext;

	// Token: 0x040095EF RID: 38383
	[Nullable(2)]
	private LevelSequencePlayer LevelSequencePlayer;

	// Token: 0x040095F0 RID: 38384
	[Nullable(2)]
	private SCommonQteButton UiConfig;

	// Token: 0x040095F1 RID: 38385
	[Nullable(2)]
	private CommonQteSelectOptionPanel ParentItem;

	// Token: 0x040095F2 RID: 38386
	[Nullable(2)]
	private UUIExtendToggle ToggleMain;

	// Token: 0x040095F3 RID: 38387
	[Nullable(2)]
	private InputMultiKeyItem KeyItem;

	// Token: 0x020089C6 RID: 35270
	[NullableContext(0)]
	private enum EChildType
	{
		// Token: 0x0402E7A0 RID: 190368
		MainItem,
		// Token: 0x0402E7A1 RID: 190369
		RaycastItem,
		// Token: 0x0402E7A2 RID: 190370
		OptionText,
		// Token: 0x0402E7A3 RID: 190371
		OffsetItem,
		// Token: 0x0402E7A4 RID: 190372
		KeyItem
	}
}
