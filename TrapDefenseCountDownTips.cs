using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.GameMainView.TrapDefense;
using CSharpScript.Game.Ui;
using UnrealEngine;

// Token: 0x02001DAA RID: 7594
[NullableContext(1)]
[Nullable(0)]
public class TrapDefenseCountDownTips : UiTickViewBase
{
	// Token: 0x0600E01E RID: 57374 RVA: 0x003C47E3 File Offset: 0x003C29E3
	public TrapDefenseCountDownTips(UiViewInfo viewInfo) : base(viewInfo)
	{
	}

	// Token: 0x0600E01F RID: 57375 RVA: 0x003C47F3 File Offset: 0x003C29F3
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUIArtText)),
			new ValueTuple<int, Type>(1, typeof(UUINiagara))
		};
	}

	// Token: 0x0600E020 RID: 57376 RVA: 0x003C482C File Offset: 0x003C2A2C
	protected override void OnStart()
	{
		this.Sequence = new UiSequencePlayer(base.GetRootItem());
		this.Data = (this.OpenParam as ITrapDefenseCountDownTipsData);
		this.CountDownTime = this.Data.CountDownTime * (float)Singleton<TimeUtil>.Instance.InverseMillisecond;
		this.ShowTextNum = this.Data.CountDownTime;
		this.Niagara = base.GetUiNiagara(1);
		this.SetCountDownText(this.ShowTextNum);
	}

	// Token: 0x0600E021 RID: 57377 RVA: 0x003C48A4 File Offset: 0x003C2AA4
	protected override void OnBeforeDestroy()
	{
		this.Sequence.Clear();
		ITrapDefenseCountDownTipsData data = this.Data;
		Action action = (data != null) ? data.Callback : null;
		if (action != null)
		{
			action();
		}
	}

	// Token: 0x0600E022 RID: 57378 RVA: 0x003C48D8 File Offset: 0x003C2AD8
	protected override void OnTick(float deltaTime)
	{
		if (!this.CanTick)
		{
			return;
		}
		this.CountDownTime -= deltaTime;
		if (this.CountDownTime <= 0f)
		{
			this.CanTick = false;
			base.CloseMe(null);
			return;
		}
		if (this.ShowTextNum - (float)((int)(this.CountDownTime / (float)Singleton<TimeUtil>.Instance.InverseMillisecond)) >= 1f)
		{
			this.ShowTextNum -= 1f;
			this.SetCountDownText(this.ShowTextNum);
		}
	}

	// Token: 0x0600E023 RID: 57379 RVA: 0x003C4958 File Offset: 0x003C2B58
	private void SetCountDownText(float num)
	{
		this.Niagara.SetNiagaraVarInt("Number_Start Frame", (int)(num - 1f));
		this.Niagara.SetNiagaraVarInt("Number_End Frame", (int)num);
		UUIArtText artText = base.GetArtText(0);
		if (artText != null)
		{
			artText.SetText(num.ToString());
		}
		this.Sequence.PlaySequencePurely("Change", false, false);
	}

	// Token: 0x04006B92 RID: 27538
	[Nullable(2)]
	protected ITrapDefenseCountDownTipsData Data;

	// Token: 0x04006B93 RID: 27539
	private float CountDownTime;

	// Token: 0x04006B94 RID: 27540
	private float ShowTextNum;

	// Token: 0x04006B95 RID: 27541
	private bool CanTick = true;

	// Token: 0x04006B96 RID: 27542
	private UUINiagara Niagara;

	// Token: 0x04006B97 RID: 27543
	private UiSequencePlayer Sequence;

	// Token: 0x0200814B RID: 33099
	[NullableContext(0)]
	private static class EComponentDefine
	{
		// Token: 0x0402BF05 RID: 179973
		public const int CountDownText = 0;

		// Token: 0x0402BF06 RID: 179974
		public const int Niagara = 1;
	}
}
