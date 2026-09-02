using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.UiNavigation;
using CSharpScript.Game.Ui;
using CSharpScript.Module.InstanceDungeon;

// Token: 0x02002CCB RID: 11467
[NullableContext(1)]
[Nullable(0)]
public class TeachScrollMoveComponent : HotKeyComponent
{
	// Token: 0x0601718F RID: 94607 RVA: 0x006667F6 File Offset: 0x006649F6
	public TeachScrollMoveComponent(int hotKeyMapIndex) : base(hotKeyMapIndex)
	{
		ControllerBase<InputDistributeController>.Instance.BindAction("组合主键", new TInputHandle<InputDistributeDefine.EActionType>(this.OnInputCombineButton));
	}

	// Token: 0x06017190 RID: 94608 RVA: 0x0066681A File Offset: 0x00664A1A
	protected override void OnClear()
	{
		ControllerBase<InputDistributeController>.Instance.UnBindAction("组合主键", new TInputHandle<InputDistributeDefine.EActionType>(this.OnInputCombineButton));
	}

	// Token: 0x06017191 RID: 94609 RVA: 0x00666837 File Offset: 0x00664A37
	private void OnInputCombineButton(string actionName, InputDistributeDefine.EActionType actionType, InputIdentification inputIdentification)
	{
		this.IsMainKeyPress = (actionType == InputDistributeDefine.EActionType.Press);
		this.RefreshActiveState();
	}

	// Token: 0x06017192 RID: 94610 RVA: 0x0066684C File Offset: 0x00664A4C
	protected override void OnInputAxis(string axisName, float value)
	{
		if (value == 0f)
		{
			return;
		}
		if (this.Listener != null)
		{
			if ((double)Math.Abs(value) <= 0.1)
			{
				if (this.TempValue != 0f)
				{
					this.TempValue = 0f;
					ControllerBase<UiNavigationNewController>.Instance.ScrollBarChangeScheduleByListener(this.Listener, 0f);
				}
				return;
			}
			this.TempValue = value;
			ControllerBase<UiNavigationNewController>.Instance.ScrollBarChangeScheduleByListener(this.Listener, value);
		}
	}

	// Token: 0x06017193 RID: 94611 RVA: 0x006668C4 File Offset: 0x00664AC4
	protected override void OnRefreshSelfHotKeyState(UiNavigationViewHandle viewHandle)
	{
		string bindButtonTag = base.GetBindButtonTag();
		if (StringUtils.IsEmpty(bindButtonTag))
		{
			return;
		}
		this.Listener = viewHandle.GetActiveListenerByTag(bindButtonTag);
		this.RefreshActiveState();
	}

	// Token: 0x06017194 RID: 94612 RVA: 0x006668F4 File Offset: 0x00664AF4
	protected void RefreshActiveState()
	{
		if (!this.IsMainKeyPress || !this.CheckInTeachDungeon() || this.Listener == null || !this.Listener.IsListenerActive())
		{
			base.SetVisibleMode(HotKeyViewDefine.ELogicMode.ListenerActive, false, false);
			return;
		}
		base.SetVisibleMode(HotKeyViewDefine.ELogicMode.ListenerActive, true, false);
	}

	// Token: 0x06017195 RID: 94613 RVA: 0x00666930 File Offset: 0x00664B30
	private bool CheckInTeachDungeon()
	{
		int instanceId = ModelBase<InstanceDungeonEntranceModel>.Instance.InstanceId;
		return instanceId != 0 && ConfigBase<InstanceDungeonConfig>.Instance.GetConfig(instanceId).Value.InstSubType == 7;
	}

	// Token: 0x0400B1C4 RID: 45508
	private const double THRESHOLD = 0.1;

	// Token: 0x0400B1C5 RID: 45509
	private float TempValue;

	// Token: 0x0400B1C6 RID: 45510
	private bool IsMainKeyPress;

	// Token: 0x0400B1C7 RID: 45511
	[Nullable(2)]
	private TsUiNavigationBehaviorListener Listener;
}
