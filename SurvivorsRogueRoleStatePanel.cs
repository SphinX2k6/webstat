using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x02001D87 RID: 7559
[NullableContext(1)]
[Nullable(0)]
public class SurvivorsRogueRoleStatePanel : UiPanelBase
{
	// Token: 0x1700117A RID: 4474
	// (get) Token: 0x0600DE91 RID: 56977 RVA: 0x003BE320 File Offset: 0x003BC520
	private float CurHp
	{
		get
		{
			if (this.AttrMap == null)
			{
				return 0f;
			}
			int num = this.AttrMap.Get(EKSC_AttrType.Life);
			if (num > 0)
			{
				return (float)num;
			}
			return 0f;
		}
	}

	// Token: 0x1700117B RID: 4475
	// (get) Token: 0x0600DE92 RID: 56978 RVA: 0x003BE354 File Offset: 0x003BC554
	private float MaxHp
	{
		get
		{
			if (this.AttrMap == null)
			{
				return this.LastValidMaxHp;
			}
			int num = this.AttrMap.Get(EKSC_AttrType.LifeMax);
			if (num > 0)
			{
				this.LastValidMaxHp = (float)num;
				return (float)num;
			}
			return this.LastValidMaxHp;
		}
	}

	// Token: 0x0600DE93 RID: 56979 RVA: 0x003BE392 File Offset: 0x003BC592
	public SurvivorsRogueRoleStatePanel()
	{
	}

	// Token: 0x0600DE94 RID: 56980 RVA: 0x003BE3CC File Offset: 0x003BC5CC
	public SurvivorsRogueRoleStatePanel(bool NeedRoleUpdate, bool NeedWeaponUpdate)
	{
		this.NeedRoleUpdate = NeedRoleUpdate;
		this.NeedWeaponUpdate = NeedWeaponUpdate;
	}

	// Token: 0x0600DE95 RID: 56981 RVA: 0x003BE41C File Offset: 0x003BC61C
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUIItem)),
			new ValueTuple<int, Type>(1, typeof(UUIHorizontalLayout)),
			new ValueTuple<int, Type>(2, typeof(UUIItem)),
			new ValueTuple<int, Type>(3, typeof(UUISprite)),
			new ValueTuple<int, Type>(4, typeof(UUISprite)),
			new ValueTuple<int, Type>(5, typeof(UUIText)),
			new ValueTuple<int, Type>(6, typeof(UUISprite)),
			new ValueTuple<int, Type>(7, typeof(UUIItem)),
			new ValueTuple<int, Type>(8, typeof(UUIText)),
			new ValueTuple<int, Type>(9, typeof(UUISprite)),
			new ValueTuple<int, Type>(10, typeof(UUIItem))
		};
	}

	// Token: 0x0600DE96 RID: 56982 RVA: 0x003BE528 File Offset: 0x003BC728
	protected override UniTask OnBeforeStartAsync()
	{
		SurvivorsRogueRoleStatePanel.<OnBeforeStartAsync>d__34 <OnBeforeStartAsync>d__;
		<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnBeforeStartAsync>d__.<>4__this = this;
		<OnBeforeStartAsync>d__.<>1__state = -1;
		<OnBeforeStartAsync>d__.<>t__builder.Start<SurvivorsRogueRoleStatePanel.<OnBeforeStartAsync>d__34>(ref <OnBeforeStartAsync>d__);
		return <OnBeforeStartAsync>d__.<>t__builder.Task;
	}

	// Token: 0x0600DE97 RID: 56983 RVA: 0x003BE56C File Offset: 0x003BC76C
	protected override void OnStart()
	{
		this.ShieldBarSprite = base.GetSprite(4);
		this.HpBarSprite = base.GetSprite(3);
		this.LowHpBarSprite = base.GetSprite(9);
		this.HpBufferSprite = base.GetSprite(6);
		this.HpText = base.GetText(5);
		this.HpText2 = base.GetText(8);
		this.HpTextMask = (base.GetItem(7).GetOwner().GetComponentByClass(ULGUICanvas.StaticClass()) as ULGUICanvas);
		this.RoleHpBarItem = base.GetItem(10);
		this.HpTextWidth = this.HpText.GetWidth();
		this.WeaponGridList = new GenericLayout<SurvivorsRogueWeaponStateGrid, ISurvivorsWeaponGridData>(base.GetHorizontalLayout(1), new Func<SurvivorsRogueWeaponStateGrid>(this.CreateWeaponItem), null, false, true);
		this.HpBufferAnimDuration = (float)ConfigCommonParamById.GetIntConfig("PlayerHPAttenuateBufferSpeed").GetValueOrDefault();
		this.ShieldBarPlayer = new LevelSequencePlayer(base.GetSprite(4));
		this.DeadEffectPlayer = new LevelSequencePlayer(base.GetRootItem());
	}

	// Token: 0x0600DE98 RID: 56984 RVA: 0x003BE66A File Offset: 0x003BC86A
	private SurvivorsRogueWeaponStateGrid CreateWeaponItem()
	{
		return new SurvivorsRogueWeaponStateGrid();
	}

	// Token: 0x0600DE99 RID: 56985 RVA: 0x003BE671 File Offset: 0x003BC871
	protected override void OnBeforeShow()
	{
		this.RefreshRoleGain();
		this.RefreshWeaponGain();
		this.OnAddEventListener();
		this.InitPlayerData();
	}

	// Token: 0x0600DE9A RID: 56986 RVA: 0x003BE68B File Offset: 0x003BC88B
	protected override void OnBeforeHide()
	{
		this.OnRemoveEventListener();
	}

	// Token: 0x0600DE9B RID: 56987 RVA: 0x003BE694 File Offset: 0x003BC894
	protected void OnAddEventListener()
	{
		Singleton<EventSystem>.Instance.Add<string, string>(EEventName.TextLanguageChange, new Action<string, string>(this.OnRefreshText));
		Singleton<EventSystem>.Instance.Add(EEventName.OnKscPlayerHpChanged, new Action(this.OnKscPlayerHpChanged));
		Singleton<EventSystem>.Instance.Add(EEventName.SurvivorsRoguePlayerEntityCreated, new Action(this.OnPlayerEntityCreated));
		if (this.NeedRoleUpdate)
		{
			Singleton<EventSystem>.Instance.Add<int>(EEventName.SurvivorsRogueRoleGainUpdate, new Action<int>(this.EventRefreshRoleGain));
		}
		if (this.NeedWeaponUpdate)
		{
			Singleton<EventSystem>.Instance.Add<int, bool>(EEventName.SurvivorsRogueWeaponGainUpdate, new Action<int, bool>(this.EventRefreshWeaponGain));
		}
	}

	// Token: 0x0600DE9C RID: 56988 RVA: 0x003BE740 File Offset: 0x003BC940
	protected void OnRemoveEventListener()
	{
		Singleton<EventSystem>.Instance.Remove(EEventName.TextLanguageChange, new Action<string, string>(this.OnRefreshText));
		Singleton<EventSystem>.Instance.Remove(EEventName.OnKscPlayerHpChanged, new Action(this.OnKscPlayerHpChanged));
		Singleton<EventSystem>.Instance.Remove(EEventName.SurvivorsRoguePlayerEntityCreated, new Action(this.OnPlayerEntityCreated));
		if (this.NeedRoleUpdate)
		{
			Singleton<EventSystem>.Instance.Remove(EEventName.SurvivorsRogueRoleGainUpdate, new Action<int>(this.EventRefreshRoleGain));
		}
		if (this.NeedWeaponUpdate)
		{
			Singleton<EventSystem>.Instance.Remove(EEventName.SurvivorsRogueWeaponGainUpdate, new Action<int, bool>(this.EventRefreshWeaponGain));
		}
	}

	// Token: 0x0600DE9D RID: 56989 RVA: 0x003BE7E9 File Offset: 0x003BC9E9
	private void OnPlayerEntityCreated()
	{
		this.InitPlayerData();
	}

	// Token: 0x0600DE9E RID: 56990 RVA: 0x003BE7F4 File Offset: 0x003BC9F4
	public void InitPlayerData()
	{
		KscSubModelBase curSubModel = ControllerBase<KuroSimpleCombatController>.Instance.CurSubModel;
		AKSC_Entity aksc_Entity = (curSubModel != null) ? curSubModel.KscPlayerEntity : null;
		if (aksc_Entity == null)
		{
			this.RoleHpBarItem.SetUIActive(false);
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
			this.RoleHpBarItem.SetUIActive(false);
			return;
		}
		this.AttrMap = tmap2;
		this.RefreshHpAndShield(false);
		this.RoleHpBarItem.SetUIActive(true);
	}

	// Token: 0x0600DE9F RID: 56991 RVA: 0x003BE871 File Offset: 0x003BCA71
	public void OnTick(float delta)
	{
		this.LerpBarPercent(delta);
	}

	// Token: 0x0600DEA0 RID: 56992 RVA: 0x003BE87A File Offset: 0x003BCA7A
	private void RefreshRoleGain()
	{
		this.RoleGrid.Refresh(ModelBase<SurvivorsRogueModel>.Instance.CurRoleId, ModelBase<SurvivorsRogueModel>.Instance.CurRoleLevel);
	}

	// Token: 0x0600DEA1 RID: 56993 RVA: 0x003BE89B File Offset: 0x003BCA9B
	private void EventRefreshRoleGain(int roleId)
	{
		this.RefreshRoleGain();
	}

	// Token: 0x0600DEA2 RID: 56994 RVA: 0x003BE8A4 File Offset: 0x003BCAA4
	private void RefreshWeaponGain()
	{
		this.WeaponGridList.RefreshByData(ModelBase<SurvivorsRogueModel>.Instance.GainData.GetWeaponGridDataList(null, null), null, false);
	}

	// Token: 0x0600DEA3 RID: 56995 RVA: 0x003BE8D7 File Offset: 0x003BCAD7
	private void EventRefreshWeaponGain(int weaponId, bool isLevelUp)
	{
		this.RefreshWeaponGain();
	}

	// Token: 0x0600DEA4 RID: 56996 RVA: 0x003BE8DF File Offset: 0x003BCADF
	private void OnRefreshText(string oldLang, string newLang)
	{
		this.RefreshHpAndShield(false);
	}

	// Token: 0x0600DEA5 RID: 56997 RVA: 0x003BE8E8 File Offset: 0x003BCAE8
	private void OnKscPlayerHpChanged()
	{
		this.RefreshHpAndShield(true);
	}

	// Token: 0x0600DEA6 RID: 56998 RVA: 0x003BE8F4 File Offset: 0x003BCAF4
	private void RefreshHpAndShield(bool bPlayBarAnimation = false)
	{
		if (this.AttrMap == null)
		{
			return;
		}
		float num = (float)this.AttrMap.Get(EKSC_AttrType.Shield);
		float num2 = this.CurHp / this.MaxHp;
		float shieldBarPercent = Math.Min(num / this.MaxHp, 1f);
		this.UeMargin.Right = -(1f - num2) * this.HpTextWidth;
		this.HpTextMask.SetRectClipOffset(this.UeMargin);
		DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(1, 2);
		defaultInterpolatedStringHandler.AppendFormatted<int>((int)Math.Ceiling((double)this.CurHp));
		defaultInterpolatedStringHandler.AppendLiteral("/");
		defaultInterpolatedStringHandler.AppendFormatted<int>((int)Math.Ceiling((double)this.MaxHp));
		string newText = defaultInterpolatedStringHandler.ToStringAndClear();
		this.HpText.SetText(newText, true);
		this.HpText2.SetText(newText, true);
		this.SetHpBarPercent(num2);
		this.SetShieldBarPercent(shieldBarPercent);
		this.UeMargin.Right = -(1f - num2) * this.HpTextWidth;
		this.HpTextMask.SetRectClipOffset(this.UeMargin);
		if (bPlayBarAnimation)
		{
			this.PlayBarAnimation();
		}
		else
		{
			this.StopBarLerpAnimation();
		}
		this.CurrentBarPercent = num2;
		if (num2 <= 0f)
		{
			this.DeadEffectPlayer.PlayOrReplaySequenceByName("Dead", false, null);
		}
	}

	// Token: 0x0600DEA7 RID: 56999 RVA: 0x003BEA38 File Offset: 0x003BCC38
	private void SetShieldBarPercent(float percent)
	{
		bool flag = percent > 0f;
		this.ShieldBarSprite.SetUIActive(flag);
		if (flag)
		{
			this.ShieldBarSprite.SetFillAmount(percent);
		}
		if (this.ExistShieldBar != flag)
		{
			this.ExistShieldBar = flag;
			if (flag)
			{
				this.ShieldBarPlayer.PlayLevelSequenceByName("Start", false, null, false);
			}
		}
	}

	// Token: 0x0600DEA8 RID: 57000 RVA: 0x003BEA98 File Offset: 0x003BCC98
	private void SetHpBarPercent(float percent)
	{
		if (percent <= 0.2f)
		{
			this.LowHpBarSprite.SetUIActive(true);
			this.HpBarSprite.SetUIActive(false);
			this.LowHpBarSprite.SetFillAmount(percent);
			return;
		}
		this.LowHpBarSprite.SetUIActive(false);
		this.HpBarSprite.SetUIActive(true);
		this.HpBarSprite.SetFillAmount(percent);
	}

	// Token: 0x0600DEA9 RID: 57001 RVA: 0x003BEAF8 File Offset: 0x003BCCF8
	private void PlayBarAnimation()
	{
		if (this.AttrMap == null)
		{
			return;
		}
		float num = this.CurHp / this.MaxHp;
		float currentBarPercent = this.CurrentBarPercent;
		if (num >= currentBarPercent)
		{
			return;
		}
		this.TargetBarPercent = num;
		this.SourceBarPercent = currentBarPercent;
		this.HpBufferAnimTime = 0f;
	}

	// Token: 0x0600DEAA RID: 57002 RVA: 0x003BEB41 File Offset: 0x003BCD41
	private void StopBarLerpAnimation()
	{
		this.TargetBarPercent = 0f;
		this.SourceBarPercent = 0f;
		this.HpBufferAnimTime = -1f;
		this.HpBufferSprite.SetUIActive(false);
	}

	// Token: 0x0600DEAB RID: 57003 RVA: 0x003BEB70 File Offset: 0x003BCD70
	private void SetBarBufferPercent(float percent)
	{
		this.HpBufferSprite.SetFillAmount(percent);
		this.HpBufferSprite.SetUIActive(true);
	}

	// Token: 0x0600DEAC RID: 57004 RVA: 0x003BEB8C File Offset: 0x003BCD8C
	private void LerpBarPercent(float delta)
	{
		if (this.HpBufferAnimTime == -1f)
		{
			return;
		}
		if (this.HpBufferAnimTime >= this.HpBufferAnimDuration)
		{
			this.StopBarLerpAnimation();
		}
		if (this.TargetBarPercent >= this.SourceBarPercent)
		{
			return;
		}
		float alpha = this.HpBufferAnimTime / this.HpBufferAnimDuration;
		float barBufferPercent = Singleton<MathUtils>.Instance.Lerp(this.SourceBarPercent, this.TargetBarPercent, alpha);
		this.SetBarBufferPercent(barBufferPercent);
		this.HpBufferAnimTime += delta;
	}

	// Token: 0x0600DEAD RID: 57005 RVA: 0x003BEC05 File Offset: 0x003BCE05
	[NullableContext(2)]
	public SurvivorsRogueWeaponStateGrid GetWeaponGrid(int weaponId)
	{
		return this.WeaponGridList.GetLayoutItemByKey(weaponId);
	}

	// Token: 0x0600DEAE RID: 57006 RVA: 0x003BEC18 File Offset: 0x003BCE18
	[NullableContext(2)]
	public SurvivorsRogueWeaponStateGrid GetWeaponGridByIndex(int index)
	{
		return this.WeaponGridList.GetLayoutItemByIndex(index);
	}

	// Token: 0x0600DEAF RID: 57007 RVA: 0x003BEC26 File Offset: 0x003BCE26
	public List<SurvivorsRogueWeaponStateGrid> GetAllWeaponGrid()
	{
		return this.WeaponGridList.GetLayoutItemList();
	}

	// Token: 0x0600DEB0 RID: 57008 RVA: 0x003BEC34 File Offset: 0x003BCE34
	[return: Nullable(new byte[]
	{
		2,
		1
	})]
	public override UUIItem[] GetGuideUiItemAndUiItemForShowEx(string[] configParams)
	{
		if (configParams.Length <= 2)
		{
			return null;
		}
		string a = configParams[2];
		if (a == "FirstWeapon")
		{
			GenericLayout<SurvivorsRogueWeaponStateGrid, ISurvivorsWeaponGridData> weaponGridList = this.WeaponGridList;
			SurvivorsRogueWeaponStateGrid survivorsRogueWeaponStateGrid = (weaponGridList != null) ? weaponGridList.GetLayoutItemByIndex(0) : null;
			if (survivorsRogueWeaponStateGrid == null)
			{
				return null;
			}
			return survivorsRogueWeaponStateGrid.GetGuideUiItemAndUiItemForShowEx(configParams);
		}
		else
		{
			if (!(a == "FirstTwoWeapon"))
			{
				return null;
			}
			UUIItem guideUiItem = base.GetGuideUiItem("1");
			if (guideUiItem == null)
			{
				return null;
			}
			return new UUIItem[]
			{
				guideUiItem,
				guideUiItem
			};
		}
	}

	// Token: 0x04006B02 RID: 27394
	private const float LOW_HP_PERCENT = 0.2f;

	// Token: 0x04006B03 RID: 27395
	private const string DEAD_SEQUENCE_NAME = "Dead";

	// Token: 0x04006B04 RID: 27396
	[Nullable(2)]
	private TMap<EKSC_AttrType, int> AttrMap;

	// Token: 0x04006B05 RID: 27397
	private UUISprite ShieldBarSprite;

	// Token: 0x04006B06 RID: 27398
	private UUISprite HpBarSprite;

	// Token: 0x04006B07 RID: 27399
	private UUISprite LowHpBarSprite;

	// Token: 0x04006B08 RID: 27400
	private UUISprite HpBufferSprite;

	// Token: 0x04006B09 RID: 27401
	private UUIText HpText;

	// Token: 0x04006B0A RID: 27402
	private UUIText HpText2;

	// Token: 0x04006B0B RID: 27403
	private ULGUICanvas HpTextMask;

	// Token: 0x04006B0C RID: 27404
	private UUIItem RoleHpBarItem;

	// Token: 0x04006B0D RID: 27405
	private float HpTextWidth;

	// Token: 0x04006B0E RID: 27406
	private FMargin UeMargin;

	// Token: 0x04006B0F RID: 27407
	private float CurrentBarPercent = -1f;

	// Token: 0x04006B10 RID: 27408
	private float TargetBarPercent;

	// Token: 0x04006B11 RID: 27409
	private float SourceBarPercent;

	// Token: 0x04006B12 RID: 27410
	private float HpBufferAnimTime = -1f;

	// Token: 0x04006B13 RID: 27411
	private float HpBufferAnimDuration;

	// Token: 0x04006B14 RID: 27412
	private float LastValidMaxHp = -1f;

	// Token: 0x04006B15 RID: 27413
	[Nullable(2)]
	private LevelSequencePlayer ShieldBarPlayer;

	// Token: 0x04006B16 RID: 27414
	private bool ExistShieldBar;

	// Token: 0x04006B17 RID: 27415
	[Nullable(2)]
	private LevelSequencePlayer DeadEffectPlayer;

	// Token: 0x04006B18 RID: 27416
	[Nullable(new byte[]
	{
		2,
		1,
		1
	})]
	private GenericLayout<SurvivorsRogueWeaponStateGrid, ISurvivorsWeaponGridData> WeaponGridList;

	// Token: 0x04006B19 RID: 27417
	[Nullable(2)]
	public SurvivorsRogueRoleInfoGrid RoleGrid;

	// Token: 0x04006B1A RID: 27418
	private readonly bool NeedRoleUpdate = true;

	// Token: 0x04006B1B RID: 27419
	private readonly bool NeedWeaponUpdate = true;

	// Token: 0x02008110 RID: 33040
	[NullableContext(0)]
	private static class EComponentDefine
	{
		// Token: 0x0402BE0F RID: 179727
		public const int RoleGrid = 0;

		// Token: 0x0402BE10 RID: 179728
		public const int WeaponLayout = 1;

		// Token: 0x0402BE11 RID: 179729
		public const int WeaponGrid = 2;

		// Token: 0x0402BE12 RID: 179730
		public const int RoleHpBar = 3;

		// Token: 0x0402BE13 RID: 179731
		public const int RoleShieldBar = 4;

		// Token: 0x0402BE14 RID: 179732
		public const int RoleHpNumber = 5;

		// Token: 0x0402BE15 RID: 179733
		public const int RoleHpBufferBar = 6;

		// Token: 0x0402BE16 RID: 179734
		public const int RoleHpMask = 7;

		// Token: 0x0402BE17 RID: 179735
		public const int RoleHpNumber2 = 8;

		// Token: 0x0402BE18 RID: 179736
		public const int RoleLowHpBar = 9;

		// Token: 0x0402BE19 RID: 179737
		public const int RoleHpBarItem = 10;
	}
}
