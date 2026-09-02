using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.BattleUi.Views;
using CSharpScript.Game.Ui;
using UnrealEngine;

// Token: 0x02001D34 RID: 7476
[NullableContext(1)]
[Nullable(0)]
public class MotorcycleArrowHpPlayerItem : UiPanelBase
{
	// Token: 0x0600DC18 RID: 56344 RVA: 0x003B282C File Offset: 0x003B0A2C
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(1, typeof(UUIArtText)),
			new ValueTuple<int, Type>(2, typeof(UUIItem)),
			new ValueTuple<int, Type>(3, typeof(UUIItem)),
			new ValueTuple<int, Type>(4, typeof(UUIItem)),
			new ValueTuple<int, Type>(5, typeof(UUIItem))
		};
	}

	// Token: 0x0600DC19 RID: 56345 RVA: 0x003B28B4 File Offset: 0x003B0AB4
	protected override void OnStart()
	{
		this.HpText = base.GetArtText(1);
		this.SequencePlayer = new LevelSequencePlayer(this.RootItem);
		this.TweenAnimPlayer.InitTweenAnim(2, base.GetItem(2), false);
		this.TweenAnimPlayer.InitTweenAnim(3, base.GetItem(3), false);
		this.TweenAnimPlayer.InitTweenAnim(4, base.GetItem(4), false);
		this.TweenAnimPlayer.InitTweenAnim(5, base.GetItem(5), false);
		this.DigitScroll.Init(0f, 0f, 500f);
	}

	// Token: 0x0600DC1A RID: 56346 RVA: 0x003B294C File Offset: 0x003B0B4C
	protected override void OnBeforeShow()
	{
		this.OnAddEventListener();
		this.InitPlayerData();
		this.SequencePlayer.PlaySequencePurely("Start", false, false, null, null, false);
	}

	// Token: 0x0600DC1B RID: 56347 RVA: 0x003B2982 File Offset: 0x003B0B82
	protected override void OnBeforeHide()
	{
		this.OnRemoveEventListener();
	}

	// Token: 0x0600DC1C RID: 56348 RVA: 0x003B298A File Offset: 0x003B0B8A
	protected void OnAddEventListener()
	{
		Singleton<EventSystem>.Instance.Add(EEventName.OnKscPlayerHpChanged, new Action(this.OnKscPlayerHpChanged));
		Singleton<EventSystem>.Instance.Add(EEventName.OnKscPlayerCreate, new Action(this.OnKscPlayerCreate));
	}

	// Token: 0x0600DC1D RID: 56349 RVA: 0x003B29C4 File Offset: 0x003B0BC4
	protected void OnRemoveEventListener()
	{
		Singleton<EventSystem>.Instance.Remove(EEventName.OnKscPlayerHpChanged, new Action(this.OnKscPlayerHpChanged));
		Singleton<EventSystem>.Instance.Remove(EEventName.OnKscPlayerCreate, new Action(this.OnKscPlayerCreate));
	}

	// Token: 0x0600DC1E RID: 56350 RVA: 0x003B29FE File Offset: 0x003B0BFE
	private void OnKscPlayerCreate()
	{
		this.InitPlayerData();
	}

	// Token: 0x0600DC1F RID: 56351 RVA: 0x003B2A08 File Offset: 0x003B0C08
	public void InitPlayerData()
	{
		KscSubModelBase curSubModel = ControllerBase<KuroSimpleCombatController>.Instance.CurSubModel;
		AKSC_Entity aksc_Entity = (curSubModel != null) ? curSubModel.KscPlayerEntity : null;
		if (aksc_Entity == null)
		{
			return;
		}
		UKSC_SkillComp skillComp = aksc_Entity.GetSkillComp();
		TMap<EKSC_AttrType, int> tmap;
		if (skillComp == null)
		{
			tmap = null;
		}
		else
		{
			UKSC_AttrSet attrSet_ = skillComp.AttrSet_;
			tmap = ((attrSet_ != null) ? attrSet_.Attrs_ : null);
		}
		TMap<EKSC_AttrType, int> tmap2 = tmap;
		if (tmap2 == null)
		{
			return;
		}
		Singleton<Log>.Instance.Info(ELogModule.UiComponent, ELogAuthor.TZQ, "[摩托战斗]UI初始化角色生命值成功", default(ReadOnlySpan<ValueTuple<string, object>>));
		this.AttrMap = tmap2;
		this.RefreshHpInfo();
	}

	// Token: 0x0600DC20 RID: 56352 RVA: 0x003B2A7C File Offset: 0x003B0C7C
	private void OnKscPlayerHpChanged()
	{
		this.RefreshHpInfo();
	}

	// Token: 0x0600DC21 RID: 56353 RVA: 0x003B2A84 File Offset: 0x003B0C84
	public void RefreshHpInfo()
	{
		int num = 0;
		if (this.AttrMap != null)
		{
			num = this.AttrMap.Get(EKSC_AttrType.Life);
		}
		if (this.LastHp == num)
		{
			return;
		}
		if (!this.IsFirst)
		{
			this.DigitScroll.SetTarget((float)num);
			this.SequencePlayer.StopPlayingSequence(false, true);
			if (num > this.LastHp)
			{
				this.TweenAnimPlayer.PlayTweenAnim(5);
				this.TweenAnimPlayer.PlayTweenAnim(3);
			}
			else
			{
				this.TweenAnimPlayer.PlayTweenAnim(4);
				this.TweenAnimPlayer.PlayTweenAnim(2);
				Singleton<AudioSystem>.Instance.PostEvent("play_ui_moto_battle_hurt_start");
			}
		}
		else
		{
			this.DigitScroll.Reset((float)num);
			UUIArtText hpText = this.HpText;
			if (hpText != null)
			{
				hpText.SetText(MotorcycleUtil.CompactNumberFormat((float)num));
			}
		}
		this.IsFirst = false;
		this.LastHp = num;
	}

	// Token: 0x0600DC22 RID: 56354 RVA: 0x003B2B58 File Offset: 0x003B0D58
	public void OnTick(float delta)
	{
		if (!this.DigitScroll.IsFinished())
		{
			float num = this.DigitScroll.Tick(delta);
			UUIArtText hpText = this.HpText;
			if (hpText == null)
			{
				return;
			}
			hpText.SetText(MotorcycleUtil.CompactNumberFormat((float)Math.Floor((double)num)));
		}
	}

	// Token: 0x04006946 RID: 26950
	private const int SCROLL_DURATION = 500;

	// Token: 0x04006947 RID: 26951
	private const string HURT_EVENT_NAME = "play_ui_moto_battle_hurt_start";

	// Token: 0x04006948 RID: 26952
	[Nullable(2)]
	protected UUIArtText HpText;

	// Token: 0x04006949 RID: 26953
	[Nullable(2)]
	private TMap<EKSC_AttrType, int> AttrMap;

	// Token: 0x0400694A RID: 26954
	[Nullable(2)]
	private LevelSequencePlayer SequencePlayer;

	// Token: 0x0400694B RID: 26955
	private int LastHp = -1;

	// Token: 0x0400694C RID: 26956
	private bool IsFirst = true;

	// Token: 0x0400694D RID: 26957
	private readonly DigitScroll DigitScroll = new DigitScroll();

	// Token: 0x0400694E RID: 26958
	private readonly BattleUiTweenAnimPlayer TweenAnimPlayer = new BattleUiTweenAnimPlayer();

	// Token: 0x020080C4 RID: 32964
	[NullableContext(0)]
	private static class EComponentDefine
	{
		// Token: 0x0402BC9F RID: 179359
		public const int Self = 0;

		// Token: 0x0402BCA0 RID: 179360
		public const int HpText = 1;

		// Token: 0x0402BCA1 RID: 179361
		public const int Hit = 2;

		// Token: 0x0402BCA2 RID: 179362
		public const int Life = 3;

		// Token: 0x0402BCA3 RID: 179363
		public const int HitEnd = 4;

		// Token: 0x0402BCA4 RID: 179364
		public const int LifeEnd = 5;
	}
}
