using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using AkiClient.Game.Aki.Character.Input.Enum;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Input;
using CSharpScript.Game.Module.BattleUi;

// Token: 0x020017B4 RID: 6068
[NullableContext(1)]
[Nullable(new byte[]
{
	0,
	1
})]
[Model(0)]
public class BattleInputModel : ModelBase<BattleInputModel>
{
	// Token: 0x0600AB2B RID: 43819 RVA: 0x002DBF4C File Offset: 0x002DA14C
	protected override bool OnInit()
	{
		this.EnableStateList.Clear();
		this.VisibleStateList.Clear();
		for (int i = 0; i < 18; i++)
		{
			this.EnableStateList.Add(0);
			this.VisibleStateList.Add(0);
		}
		return true;
	}

	// Token: 0x0600AB2C RID: 43820 RVA: 0x002DBF95 File Offset: 0x002DA195
	public bool GetInputEnable(CSharpScript.Game.Input.EInputAction inputAction)
	{
		return this.EnableStateList[(int)inputAction] == 0;
	}

	// Token: 0x0600AB2D RID: 43821 RVA: 0x002DBFAB File Offset: 0x002DA1AB
	public bool GetInputVisible(CSharpScript.Game.Input.EInputAction inputAction)
	{
		return this.VisibleStateList[(int)inputAction] == 0;
	}

	// Token: 0x0600AB2E RID: 43822 RVA: 0x002DBFC4 File Offset: 0x002DA1C4
	public void SetInputEnable(CSharpScript.Game.Input.EInputAction inputAction, bool enable, EBattleInputReason reason)
	{
		int num = this.EnableStateList[(int)inputAction];
		if (!enable && num == 0 && ControllerBase<InputController>.Instance.IsKeyDown(inputAction))
		{
			ControllerBase<InputController>.Instance.InputAction(inputAction, EInputState.Release);
		}
		int num2 = VisibleStateUtil.SetVisible(num, enable, (int)reason);
		this.EnableStateList[(int)inputAction] = num2;
		if (num != num2)
		{
			BattleInputModel.DispatchEnableChangeEvent(inputAction, num2 == 0);
		}
	}

	// Token: 0x0600AB2F RID: 43823 RVA: 0x002DC02C File Offset: 0x002DA22C
	public void SetInputVisible(CSharpScript.Game.Input.EInputAction inputAction, bool visible, EBattleInputReason reason)
	{
		int num = this.VisibleStateList[(int)inputAction];
		int num2 = VisibleStateUtil.SetVisible(num, visible, (int)reason);
		this.VisibleStateList[(int)inputAction] = num2;
		if (num != num2)
		{
			BattleInputModel.DispatchVisibleChangeEvent(inputAction, num2 == 0);
		}
	}

	// Token: 0x0600AB30 RID: 43824 RVA: 0x002DC074 File Offset: 0x002DA274
	public void SetAllInputEnable(bool enable, EBattleInputReason reason)
	{
		for (int i = 0; i < 18; i++)
		{
			this.SetInputEnable((CSharpScript.Game.Input.EInputAction)((byte)i), enable, reason);
		}
	}

	// Token: 0x0600AB31 RID: 43825 RVA: 0x002DC0A0 File Offset: 0x002DA2A0
	public void SetAllInputVisible(bool visible, EBattleInputReason reason)
	{
		for (int i = 0; i < 18; i++)
		{
			this.SetInputVisible((CSharpScript.Game.Input.EInputAction)((byte)i), visible, reason);
		}
	}

	// Token: 0x0600AB32 RID: 43826 RVA: 0x002DC0CC File Offset: 0x002DA2CC
	public void SetAllInputEnableWithIgnoreSet(bool enable, HashSet<int> ignoreSet, EBattleInputReason reason)
	{
		for (int i = 0; i < 18; i++)
		{
			this.SetInputEnable((CSharpScript.Game.Input.EInputAction)((byte)i), ignoreSet.Contains(i) != enable, reason);
		}
	}

	// Token: 0x0600AB33 RID: 43827 RVA: 0x002DC101 File Offset: 0x002DA301
	private static void DispatchEnableChangeEvent(CSharpScript.Game.Input.EInputAction inputAction, bool enable)
	{
		Singleton<EventSystem>.Instance.Emit<CSharpScript.Game.Input.EInputAction, bool>(EEventName.BattleInputEnableChanged, inputAction, enable);
	}

	// Token: 0x0600AB34 RID: 43828 RVA: 0x002DC115 File Offset: 0x002DA315
	private static void DispatchVisibleChangeEvent(CSharpScript.Game.Input.EInputAction inputAction, bool visible)
	{
		Singleton<EventSystem>.Instance.Emit<CSharpScript.Game.Input.EInputAction, bool>(EEventName.BattleInputVisibleChanged, inputAction, visible);
	}

	// Token: 0x04005173 RID: 20851
	private readonly List<int> EnableStateList = new List<int>(18);

	// Token: 0x04005174 RID: 20852
	private readonly List<int> VisibleStateList = new List<int>(18);
}
