using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Module.BattleUi.Views;
using CSharpScript.Game.Ui;
using UnrealEngine;

// Token: 0x02002579 RID: 9593
[NullableContext(1)]
[Nullable(0)]
public class PhoneMsgTipViewB : UiTickViewBase
{
	// Token: 0x06012A89 RID: 76425 RVA: 0x00525004 File Offset: 0x00523204
	public PhoneMsgTipViewB(UiViewInfo viewInfo) : base(viewInfo)
	{
	}

	// Token: 0x06012A8A RID: 76426 RVA: 0x00525040 File Offset: 0x00523240
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUIButtonComponent)),
			new ValueTuple<int, Type>(1, typeof(UUISprite))
		};
		this.BtnBindInfo = new List<ValueTuple<int, Delegate>>
		{
			new ValueTuple<int, Delegate>(0, new Action(this.TurnToPhoneMsgPanel))
		};
	}

	// Token: 0x06012A8B RID: 76427 RVA: 0x005250A8 File Offset: 0x005232A8
	protected override void OnStart()
	{
		this.MsgData = (this.OpenParam as ShortMessage?);
		this.SeqPlayer = new LevelSequencePlayer(this.RootItem);
		if (this.MsgData == null)
		{
			base.CloseMe(null);
		}
		this.RootActor.OnSequencePlayEvent.Bind(new Action<string, string>(this.OnEventSequence));
	}

	// Token: 0x06012A8C RID: 76428 RVA: 0x0052510C File Offset: 0x0052330C
	protected override void OnTick(float delta)
	{
		if (this.HaveClosed)
		{
			return;
		}
		this.CloseTimerDown -= delta;
		float fillAmount = this.CloseTimerDown / 4000f;
		base.GetSprite(1).SetFillAmount(fillAmount);
		if (this.CloseTimerDown <= 0f)
		{
			this.HaveClosed = true;
			LevelSequencePlayer seqPlayer = this.SeqPlayer;
			if (seqPlayer != null)
			{
				seqPlayer.StopSequenceByKey("Out", false, false);
			}
			LevelSequencePlayer seqPlayer2 = this.SeqPlayer;
			if (seqPlayer2 == null)
			{
				return;
			}
			seqPlayer2.PlayLevelSequenceByName("Out", false, null, false);
		}
	}

	// Token: 0x06012A8D RID: 76429 RVA: 0x00525196 File Offset: 0x00523396
	protected override void OnBeforeDestroy()
	{
		LevelSequencePlayer seqPlayer = this.SeqPlayer;
		if (seqPlayer != null)
		{
			seqPlayer.Clear();
		}
		this.SeqPlayer = null;
		LguiFloatTween locationXTween = this.LocationXTween;
		if (locationXTween != null)
		{
			locationXTween.Destroy();
		}
		LguiFloatTween locationYTween = this.LocationYTween;
		if (locationYTween == null)
		{
			return;
		}
		locationYTween.Destroy();
	}

	// Token: 0x06012A8E RID: 76430 RVA: 0x005251D4 File Offset: 0x005233D4
	public int? GetMessageDataId()
	{
		if (this.MsgData == null)
		{
			return null;
		}
		return new int?(this.MsgData.Value.Id);
	}

	// Token: 0x06012A8F RID: 76431 RVA: 0x00525210 File Offset: 0x00523410
	private void OnEventSequence(string sequenceName, string eventName)
	{
		if (eventName == "Close_UI")
		{
			base.CloseMe(null);
		}
		if (eventName == "Particle_In")
		{
			UiViewBase viewByName = Singleton<UiManager>.Instance.GetViewByName(EUiViewName.BattleView);
			if (viewByName == null)
			{
				return;
			}
			BattleViewProxy battleViewProxy = viewByName.OpenParam as BattleViewProxy;
			if (battleViewProxy == null)
			{
				return;
			}
			UUIItem topPanelPhoneMsgButtonItem = battleViewProxy.GetTopPanelPhoneMsgButtonItem();
			if (topPanelPhoneMsgButtonItem == null)
			{
				return;
			}
			this.FlyToLocation(topPanelPhoneMsgButtonItem);
		}
	}

	// Token: 0x06012A90 RID: 76432 RVA: 0x00525278 File Offset: 0x00523478
	private void FlyToLocation(UUIItem item)
	{
		this.LocationXTween = new LguiFloatTween();
		this.LocationXTween.BindUpdateTween(delegate(float value)
		{
			this.TipsWorldPos.X = (double)value;
			UUIItem rootItem = this.RootItem;
			FVector fvector = this.TipsWorldPos.ToUeVectorOld();
			rootItem.SetUIWorldLocation(fvector);
		});
		this.LocationYTween = new LguiFloatTween();
		this.LocationYTween.BindUpdateTween(delegate(float value)
		{
			this.TipsWorldPos.Z = (double)value;
			UUIItem rootItem = this.RootItem;
			FVector fvector = this.TipsWorldPos.ToUeVectorOld();
			rootItem.SetUIWorldLocation(fvector);
		});
		float time = 0.25f;
		FVectorDouble fvectorDouble = this.RootItem.D_K2_GetComponentLocation();
		FVectorDouble fvectorDouble2 = item.D_K2_GetComponentLocation();
		this.TipsWorldPos.DeepCopy(fvectorDouble);
		this.LocationXTween.PlayTween((float)fvectorDouble.X, (float)fvectorDouble2.X, time, this.CurveX);
		this.LocationYTween.PlayTween((float)fvectorDouble.Z, (float)fvectorDouble2.Z, time, this.CurveY);
	}

	// Token: 0x06012A91 RID: 76433 RVA: 0x0052532F File Offset: 0x0052352F
	private void TurnToPhoneMsgPanel()
	{
		this.needShowTips = true;
		base.CloseMe(null);
	}

	// Token: 0x06012A92 RID: 76434 RVA: 0x0052533F File Offset: 0x0052353F
	protected override void OnAfterDestroyImplement()
	{
		if (this.needShowTips)
		{
			Singleton<UiManager>.Instance.OpenView(EUiViewName.PhoneMsgPanelViewBig, this.MsgData, null);
		}
	}

	// Token: 0x040091C3 RID: 37315
	private ShortMessage? MsgData;

	// Token: 0x040091C4 RID: 37316
	private float CloseTimerDown = 4000f;

	// Token: 0x040091C5 RID: 37317
	private bool HaveClosed;

	// Token: 0x040091C6 RID: 37318
	[Nullable(2)]
	private LevelSequencePlayer SeqPlayer;

	// Token: 0x040091C7 RID: 37319
	private LguiFloatTween LocationXTween;

	// Token: 0x040091C8 RID: 37320
	private LguiFloatTween LocationYTween;

	// Token: 0x040091C9 RID: 37321
	private readonly UCurveFloat CurveX;

	// Token: 0x040091CA RID: 37322
	private readonly UCurveFloat CurveY;

	// Token: 0x040091CB RID: 37323
	private const float CLOSE_TIME = 4000f;

	// Token: 0x040091CC RID: 37324
	protected global::Vector TipsWorldPos = global::Vector.Create(0.0, 0.0, 0.0);

	// Token: 0x040091CD RID: 37325
	private bool needShowTips;

	// Token: 0x02008897 RID: 34967
	[NullableContext(0)]
	private enum EComponent
	{
		// Token: 0x0402E222 RID: 188962
		BtnClick,
		// Token: 0x0402E223 RID: 188963
		ItemProgressBar
	}
}
