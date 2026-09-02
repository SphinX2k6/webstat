using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Module.InstanceDungeon.ExchangeReward;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using UnrealEngine;

// Token: 0x020021FF RID: 8703
public class LordGymItem : UiPanelBase, IGridProxy<int>
{
	// Token: 0x060106BE RID: 67262 RVA: 0x0047CEDF File Offset: 0x0047B0DF
	[NullableContext(1)]
	public LordGymItem(Action<int> onClickBack, Func<int, bool> lordCanExecuteChange)
	{
		this.OnClickBack = onClickBack;
		this.LordCanExecuteChange = lordCanExecuteChange;
	}

	// Token: 0x17001449 RID: 5193
	// (get) Token: 0x060106BF RID: 67263 RVA: 0x0047CEFC File Offset: 0x0047B0FC
	// (set) Token: 0x060106C0 RID: 67264 RVA: 0x0047CF04 File Offset: 0x0047B104
	[Nullable(new byte[]
	{
		2,
		1
	})]
	public IScrollViewDelegate<IGridProxy<int>, int> ScrollViewDelegate { [return: Nullable(new byte[]
	{
		2,
		1
	})] get; [param: Nullable(new byte[]
	{
		2,
		1
	})] set; }

	// Token: 0x1700144A RID: 5194
	// (get) Token: 0x060106C1 RID: 67265 RVA: 0x0047CF0D File Offset: 0x0047B10D
	// (set) Token: 0x060106C2 RID: 67266 RVA: 0x0047CF15 File Offset: 0x0047B115
	public int GridIndex { get; set; }

	// Token: 0x1700144B RID: 5195
	// (get) Token: 0x060106C3 RID: 67267 RVA: 0x0047CF1E File Offset: 0x0047B11E
	// (set) Token: 0x060106C4 RID: 67268 RVA: 0x0047CF26 File Offset: 0x0047B126
	public int DisplayIndex { get; set; }

	// Token: 0x060106C5 RID: 67269 RVA: 0x0047CF30 File Offset: 0x0047B130
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUIExtendToggle)),
			new ValueTuple<int, Type>(1, typeof(UUIText)),
			new ValueTuple<int, Type>(2, typeof(UUISprite)),
			new ValueTuple<int, Type>(3, typeof(UUIItem)),
			new ValueTuple<int, Type>(4, typeof(UUIItem))
		};
		this.BtnBindInfo = new List<ValueTuple<int, Delegate>>
		{
			new ValueTuple<int, Delegate>(0, new Action<EToggleState>(this.OnClickLordBtn))
		};
	}

	// Token: 0x060106C6 RID: 67270 RVA: 0x0047CFD9 File Offset: 0x0047B1D9
	protected override void OnStart()
	{
		this.LordToggle = base.GetExtendToggle(0);
		this.LordToggle.CanExecuteChange.Bind(new Func<bool>(this.CanExecuteChange));
	}

	// Token: 0x060106C7 RID: 67271 RVA: 0x0047D004 File Offset: 0x0047B204
	protected override void OnBeforeDestroy()
	{
		this.OnClickBack = null;
		this.LordId = -1;
	}

	// Token: 0x060106C8 RID: 67272 RVA: 0x0047D014 File Offset: 0x0047B214
	public void Refresh(int data, bool isSelected, int gridIndex)
	{
		this.RefreshByLordId(data);
		this.LordToggle.SetToggleState(isSelected ? EToggleState.ETT_Checked : EToggleState.ETT_UnChecked, false, false, false);
	}

	// Token: 0x060106C9 RID: 67273 RVA: 0x0047D033 File Offset: 0x0047B233
	public void Clear()
	{
	}

	// Token: 0x060106CA RID: 67274 RVA: 0x0047D035 File Offset: 0x0047B235
	public void OnSelected(bool fireEvent)
	{
		this.LordToggle.SetToggleState(EToggleState.ETT_Checked, fireEvent, false, false);
	}

	// Token: 0x060106CB RID: 67275 RVA: 0x0047D047 File Offset: 0x0047B247
	public void OnDeselected(bool fireEvent)
	{
		this.LordToggle.SetToggleState(EToggleState.ETT_UnChecked, fireEvent, false, false);
	}

	// Token: 0x060106CC RID: 67276 RVA: 0x0047D059 File Offset: 0x0047B259
	[NullableContext(1)]
	public object GetKey(int data, int gridIndex)
	{
		return this.LordId;
	}

	// Token: 0x060106CD RID: 67277 RVA: 0x0047D068 File Offset: 0x0047B268
	public void RefreshByLordId(int lordId)
	{
		this.LordId = lordId;
		base.GetItem(3).SetUIActive(!ModelBase<LordGymModel>.Instance.GetLordGymIsUnLock(this.LordId) || !ModelBase<LordGymModel>.Instance.GetLastGymFinish(this.LordId));
		LordGym? lordGymConfig = ConfigBase<LordGymConfig>.Instance.GetLordGymConfig(this.LordId);
		if (lordGymConfig == null)
		{
			return;
		}
		LordGym value = lordGymConfig.Value;
		base.GetItem(4).SetUIActive(!ModelBase<ExchangeRewardModel>.Instance.GetRewardIfCanExchange(value.RewardId));
		this.SetSpriteByPath(value.IconPath, base.GetSprite(2), false, null, null);
		Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(1), value.GymTitle, Array.Empty<object>());
	}

	// Token: 0x060106CE RID: 67278 RVA: 0x0047D12F File Offset: 0x0047B32F
	private void OnClickLordBtn(EToggleState toggleState)
	{
		if (this.OnClickBack != null)
		{
			this.OnClickBack(this.LordId);
		}
	}

	// Token: 0x060106CF RID: 67279 RVA: 0x0047D14A File Offset: 0x0047B34A
	private bool CanExecuteChange()
	{
		return this.LordCanExecuteChange == null || this.LordCanExecuteChange(this.LordId);
	}

	// Token: 0x04008165 RID: 33125
	private int LordId = -1;

	// Token: 0x04008166 RID: 33126
	[Nullable(2)]
	private Action<int> OnClickBack;

	// Token: 0x04008167 RID: 33127
	[Nullable(2)]
	private readonly Func<int, bool> LordCanExecuteChange;

	// Token: 0x04008168 RID: 33128
	[Nullable(2)]
	private UUIExtendToggle LordToggle;

	// Token: 0x020084CF RID: 33999
	private class EChildType
	{
		// Token: 0x0402CFEF RID: 184303
		public const int LordToggle = 0;

		// Token: 0x0402CFF0 RID: 184304
		public const int LevelText = 1;

		// Token: 0x0402CFF1 RID: 184305
		public const int IconSprite = 2;

		// Token: 0x0402CFF2 RID: 184306
		public const int LockItem = 3;

		// Token: 0x0402CFF3 RID: 184307
		public const int FinishItem = 4;
	}
}
