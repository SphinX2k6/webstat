using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Module.Util;
using UnrealEngine;

// Token: 0x020021F9 RID: 8697
public class LordGymDifficultyItem : GridProxyAbstract<int>
{
	// Token: 0x06010673 RID: 67187 RVA: 0x0047B644 File Offset: 0x00479844
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUIExtendToggle)),
			new ValueTuple<int, Type>(1, typeof(UUIText)),
			new ValueTuple<int, Type>(2, typeof(UUIItem)),
			new ValueTuple<int, Type>(3, typeof(UUIItem)),
			new ValueTuple<int, Type>(4, typeof(UUIItem))
		};
		if (this.OnToggleClick != null)
		{
			this.BtnBindInfo = new List<ValueTuple<int, Delegate>>
			{
				new ValueTuple<int, Delegate>(0, new Action<EToggleState>(this.<OnRegisterComponent>g__CallBack|4_0))
			};
		}
	}

	// Token: 0x06010674 RID: 67188 RVA: 0x0047B6F5 File Offset: 0x004798F5
	protected override void OnStart()
	{
		if (this.CanExecuteChangeCallBack != null)
		{
			UUIExtendToggle extendToggle = base.GetExtendToggle(0);
			if (extendToggle != null)
			{
				extendToggle.CanExecuteChange.Bind(delegate()
				{
					Func<int, bool> canExecuteChangeCallBack = this.CanExecuteChangeCallBack;
					return canExecuteChangeCallBack == null || canExecuteChangeCallBack(base.GridIndex);
				});
			}
		}
		base.GetItem(4).SetUIActive(false);
	}

	// Token: 0x06010675 RID: 67189 RVA: 0x0047B730 File Offset: 0x00479930
	public override void Refresh(int data, bool isSelected, int gridIndex)
	{
		this.LordId = data;
		bool uiactive = !ModelBase<LordGymModel>.Instance.GetLordGymIsUnLock(this.LordId) || !ModelBase<LordGymModel>.Instance.GetLastGymFinish(this.LordId);
		base.GetItem(2).SetUIActive(uiactive);
		LordGym? lordGymConfig = ConfigBase<LordGymConfig>.Instance.GetLordGymConfig(this.LordId);
		if (lordGymConfig == null)
		{
			return;
		}
		LordGym value = lordGymConfig.Value;
		bool lordGymIsFinish = ModelBase<LordGymModel>.Instance.GetLordGymIsFinish(this.LordId);
		base.GetItem(3).SetUIActive(lordGymIsFinish);
		this.SetLevelText(value);
		EToggleState state = isSelected ? EToggleState.ETT_Checked : EToggleState.ETT_UnChecked;
		base.GetExtendToggle(0).SetToggleState(state, false, false, false);
	}

	// Token: 0x06010676 RID: 67190 RVA: 0x0047B7DD File Offset: 0x004799DD
	protected virtual void SetLevelText(LordGym config)
	{
		Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(1), config.GymTitle, Array.Empty<object>());
	}

	// Token: 0x06010677 RID: 67191 RVA: 0x0047B7FC File Offset: 0x004799FC
	public override void OnSelected(bool fireEvent)
	{
		base.GetExtendToggle(0).SetToggleState(EToggleState.ETT_Checked, fireEvent, false, false);
	}

	// Token: 0x06010678 RID: 67192 RVA: 0x0047B80F File Offset: 0x00479A0F
	public override void OnDeselected(bool fireEvent)
	{
		base.GetExtendToggle(0).SetToggleState(EToggleState.ETT_UnChecked, fireEvent, false, false);
	}

	// Token: 0x0601067A RID: 67194 RVA: 0x0047B831 File Offset: 0x00479A31
	[CompilerGenerated]
	private void <OnRegisterComponent>g__CallBack|4_0(EToggleState state)
	{
		Action<int> onToggleClick = this.OnToggleClick;
		if (onToggleClick == null)
		{
			return;
		}
		onToggleClick(base.GridIndex);
	}

	// Token: 0x04008153 RID: 33107
	private int LordId = -1;

	// Token: 0x04008154 RID: 33108
	[Nullable(2)]
	public Action<int> OnToggleClick;

	// Token: 0x04008155 RID: 33109
	[Nullable(2)]
	public Func<int, bool> CanExecuteChangeCallBack;

	// Token: 0x020084BC RID: 33980
	private class EComponent
	{
		// Token: 0x0402CF85 RID: 184197
		public const int LordToggle = 0;

		// Token: 0x0402CF86 RID: 184198
		public const int LevelText = 1;

		// Token: 0x0402CF87 RID: 184199
		public const int LockItem = 2;

		// Token: 0x0402CF88 RID: 184200
		public const int FinishItem = 3;

		// Token: 0x0402CF89 RID: 184201
		public const int RedDotItem = 4;
	}
}
