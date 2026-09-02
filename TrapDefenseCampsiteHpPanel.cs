using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Protocol;
using Aki.TDConfigMgr.Quest;
using CSharpScript.Game.Module.BattleUi.Views;
using CSharpScript.Game.Module.GameMainView.TrapDefense;
using CSharpScript.Game.Module.TrapDefense;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x02001D9A RID: 7578
[NullableContext(1)]
[Nullable(0)]
public class TrapDefenseCampsiteHpPanel : BattleChildViewPanel
{
	// Token: 0x0600DF5E RID: 57182 RVA: 0x003C19E0 File Offset: 0x003BFBE0
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUIItem)),
			new ValueTuple<int, Type>(1, typeof(UUIItem)),
			new ValueTuple<int, Type>(2, typeof(UUIItem)),
			new ValueTuple<int, Type>(3, typeof(UUIItem)),
			new ValueTuple<int, Type>(4, typeof(UUIItem)),
			new ValueTuple<int, Type>(5, typeof(UUIItem)),
			new ValueTuple<int, Type>(6, typeof(UUIArtText)),
			new ValueTuple<int, Type>(7, typeof(UUIArtText)),
			new ValueTuple<int, Type>(8, typeof(UUIItem)),
			new ValueTuple<int, Type>(9, typeof(UUITexture))
		};
	}

	// Token: 0x0600DF5F RID: 57183 RVA: 0x003C1AD5 File Offset: 0x003BFCD5
	public override void InitializeTemp()
	{
		this.Sequence = new UiSequencePlayer(base.GetRootItem());
		this.Sequence.BindOnEndSequenceEvent(new Action<string>(this.OnEndSequenceEvent));
		this.RefreshStateByType(ECampsiteHpState.Normal);
		this.SetWarningItemActiveInner(this.IsInWarning);
	}

	// Token: 0x0600DF60 RID: 57184 RVA: 0x003C1B14 File Offset: 0x003BFD14
	private void OnEndSequenceEvent(string sequenceName)
	{
		if (sequenceName == "WarnOut")
		{
			UUIItem item = base.GetItem(8);
			if (item == null)
			{
				return;
			}
			item.SetUIActive(false);
			return;
		}
		else
		{
			if (sequenceName == "Hit")
			{
				this.RefreshStateByType(ECampsiteHpState.Normal);
				return;
			}
			if (sequenceName == "Treatment")
			{
				this.RefreshStateByType(ECampsiteHpState.Normal);
			}
			return;
		}
	}

	// Token: 0x0600DF61 RID: 57185 RVA: 0x003C1B6C File Offset: 0x003BFD6C
	protected override void OnShowBattleChildViewPanel(bool isFirst)
	{
		long health = ModelBase<TrapDefenseModel>.Instance.BattleData.GetHealth();
		base.GetArtText(6).SetText(health.ToString());
		base.GetArtText(7).SetUIActive(false);
		ModelBase<TrapDefenseModel>.Instance.BattleData.AddTreeVarUpdateDelegate(ETrapDefenseSystemVarType.Health, new TTreeVarUpdateDelegate(this.OnCampsiteHpUpdate));
	}

	// Token: 0x0600DF62 RID: 57186 RVA: 0x003C1BC5 File Offset: 0x003BFDC5
	protected override void OnBeforeShow()
	{
		this.Sequence.PlaySequencePurely("Start", false, false);
	}

	// Token: 0x0600DF63 RID: 57187 RVA: 0x003C1BDC File Offset: 0x003BFDDC
	protected override UniTask OnBeforeHideAsync()
	{
		TrapDefenseCampsiteHpPanel.<OnBeforeHideAsync>d__8 <OnBeforeHideAsync>d__;
		<OnBeforeHideAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnBeforeHideAsync>d__.<>4__this = this;
		<OnBeforeHideAsync>d__.<>1__state = -1;
		<OnBeforeHideAsync>d__.<>t__builder.Start<TrapDefenseCampsiteHpPanel.<OnBeforeHideAsync>d__8>(ref <OnBeforeHideAsync>d__);
		return <OnBeforeHideAsync>d__.<>t__builder.Task;
	}

	// Token: 0x0600DF64 RID: 57188 RVA: 0x003C1C1F File Offset: 0x003BFE1F
	protected override void OnHideBattleChildViewPanel()
	{
		ModelBase<TrapDefenseModel>.Instance.BattleData.RemoveTreeVarUpdateDelegate(ETrapDefenseSystemVarType.Health, new TTreeVarUpdateDelegate(this.OnCampsiteHpUpdate));
	}

	// Token: 0x0600DF65 RID: 57189 RVA: 0x003C1C3D File Offset: 0x003BFE3D
	protected override void OnBeforeDestroy()
	{
		this.Sequence.Clear();
	}

	// Token: 0x0600DF66 RID: 57190 RVA: 0x003C1C4C File Offset: 0x003BFE4C
	private void RefreshStateByType(ECampsiteHpState type)
	{
		if (type == ECampsiteHpState.Reduce)
		{
			this.Sequence.StopSequenceByKey("Treatment", false, true);
			this.Sequence.PlaySequencePurely("Hit", false, false);
			return;
		}
		if (type == ECampsiteHpState.Add)
		{
			this.Sequence.StopSequenceByKey("Hit", false, true);
			this.Sequence.PlaySequencePurely("Treatment", false, false);
			return;
		}
		UUIArtText artText = base.GetArtText(7);
		if (artText == null)
		{
			return;
		}
		artText.SetUIActive(false);
	}

	// Token: 0x0600DF67 RID: 57191 RVA: 0x003C1CC0 File Offset: 0x003BFEC0
	private void OnCampsiteHpUpdate([Nullable(2)] VarDefinePb lastVarDefine, VarDefinePb newVarDefine)
	{
		UUIArtText artText = base.GetArtText(6);
		if (lastVarDefine == null && newVarDefine != null)
		{
			artText.SetText(Singleton<MathUtils>.Instance.LongToNumber(newVarDefine.Int).ToString());
			this.RefreshStateByType(ECampsiteHpState.Normal);
			return;
		}
		if (lastVarDefine != null && newVarDefine != null)
		{
			long num = Singleton<MathUtils>.Instance.LongToNumber(lastVarDefine.Int);
			long num2 = Singleton<MathUtils>.Instance.LongToNumber(newVarDefine.Int);
			UUIArtText artText2 = base.GetArtText(7);
			artText2.SetUIActive(true);
			artText.SetText(Singleton<MathUtils>.Instance.LongToNumber(num2).ToString());
			if (num < num2)
			{
				artText2.SetText("+" + (num2 - num).ToString());
				this.RefreshStateByType(ECampsiteHpState.Add);
				return;
			}
			if (num > num2)
			{
				artText2.SetText((num2 - num).ToString());
				this.RefreshStateByType(ECampsiteHpState.Reduce);
			}
		}
	}

	// Token: 0x0600DF68 RID: 57192 RVA: 0x003C1D9E File Offset: 0x003BFF9E
	public void SetWarningItemActive(bool isInWarning)
	{
		if (this.IsInWarning == isInWarning)
		{
			return;
		}
		this.IsInWarning = isInWarning;
		this.SetWarningItemActiveInner(isInWarning);
	}

	// Token: 0x0600DF69 RID: 57193 RVA: 0x003C1DB8 File Offset: 0x003BFFB8
	private void SetWarningItemActiveInner(bool isInWarning)
	{
		if (isInWarning)
		{
			UUIItem item = base.GetItem(8);
			if (item != null)
			{
				item.SetUIActive(true);
			}
			this.Sequence.StopSequenceByKey("WarnOut", false, true);
			this.Sequence.PlaySequencePurely("Warn", false, false);
			return;
		}
		this.Sequence.StopSequenceByKey("Warn", false, true);
		this.Sequence.PlaySequencePurely("WarnOut", false, false);
	}

	// Token: 0x0600DF6A RID: 57194 RVA: 0x003C1E24 File Offset: 0x003C0024
	public void SetLightItemActive(bool isActive)
	{
		base.GetTexture(9).SetUIActive(isActive);
	}

	// Token: 0x04006B66 RID: 27494
	private bool IsInWarning;

	// Token: 0x04006B67 RID: 27495
	protected UiSequencePlayer Sequence;

	// Token: 0x02008132 RID: 33074
	[NullableContext(0)]
	private static class EComponentDefine
	{
		// Token: 0x0402BE9D RID: 179869
		public const int NormalBgSprite = 0;

		// Token: 0x0402BE9E RID: 179870
		public const int AddBgSprite = 1;

		// Token: 0x0402BE9F RID: 179871
		public const int ReduceBgSprite = 2;

		// Token: 0x0402BEA0 RID: 179872
		public const int NormalLightItem = 3;

		// Token: 0x0402BEA1 RID: 179873
		public const int AddLightItem = 4;

		// Token: 0x0402BEA2 RID: 179874
		public const int ReduceLightItem = 5;

		// Token: 0x0402BEA3 RID: 179875
		public const int HpNum = 6;

		// Token: 0x0402BEA4 RID: 179876
		public const int ChangeHpNum = 7;

		// Token: 0x0402BEA5 RID: 179877
		public const int WarningItem = 8;

		// Token: 0x0402BEA6 RID: 179878
		public const int TextureLight = 9;
	}
}
