using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Ui;
using UnrealEngine;

// Token: 0x02002094 RID: 8340
[NullableContext(2)]
[Nullable(0)]
public class KingShipAttributeItem : UiPanelBase
{
	// Token: 0x0600FE73 RID: 65139 RVA: 0x0045C3C0 File Offset: 0x0045A5C0
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUISprite)),
			new ValueTuple<int, Type>(1, typeof(UUISprite)),
			new ValueTuple<int, Type>(2, typeof(UUIItem)),
			new ValueTuple<int, Type>(3, typeof(UUIItem)),
			new ValueTuple<int, Type>(4, typeof(UUISprite)),
			new ValueTuple<int, Type>(5, typeof(UUISprite)),
			new ValueTuple<int, Type>(6, typeof(UUIItem)),
			new ValueTuple<int, Type>(7, typeof(UUIItem)),
			new ValueTuple<int, Type>(8, typeof(UUIItem)),
			new ValueTuple<int, Type>(9, typeof(UUIText)),
			new ValueTuple<int, Type>(10, typeof(UUIItem)),
			new ValueTuple<int, Type>(11, typeof(UUIButtonComponent))
		};
		this.BtnBindInfo = new List<ValueTuple<int, Delegate>>
		{
			new ValueTuple<int, Delegate>(11, new Action(this.OnClickButton))
		};
	}

	// Token: 0x0600FE74 RID: 65140 RVA: 0x0045C507 File Offset: 0x0045A707
	protected override void OnBeforeDestroy()
	{
		LevelSequencePlayer levelSequencePlayer = this.LevelSequencePlayer;
		if (levelSequencePlayer != null)
		{
			levelSequencePlayer.Clear();
		}
		this.LevelSequencePlayer = null;
	}

	// Token: 0x0600FE75 RID: 65141 RVA: 0x0045C524 File Offset: 0x0045A724
	protected override void OnStart()
	{
		base.GetItem(2).SetUIActive(false);
		base.GetItem(3).SetUIActive(false);
		this.RedSprite = base.GetSprite(4);
		this.NormalSprite = base.GetSprite(1);
		this.GreenSprite = base.GetSprite(5);
		this.LevelSequencePlayer = new LevelSequencePlayer(this.RootItem);
		this.LevelSequencePlayer.BindSequenceCloseEvent(delegate(string name)
		{
			if (name == "ArrowOut")
			{
				if (this.DownHideFlag)
				{
					base.GetItem(2).SetUIActive(false);
					this.DownHideFlag = false;
				}
				if (this.UpHideFlag)
				{
					base.GetItem(3).SetUIActive(false);
					this.UpHideFlag = false;
				}
			}
		}, false);
		this.BarSpeed = ConfigCommonParamById.GetFloatConfig("KingShipStaticAttributeChangeMoveSpeed").GetValueOrDefault();
		this.KingShipValueUseBigEffect = ConfigCommonParamById.GetFloatConfig("KingShipValueUseBigEffect").GetValueOrDefault();
		base.GetItem(8).SetUIActive(false);
	}

	// Token: 0x0600FE76 RID: 65142 RVA: 0x0045C5D8 File Offset: 0x0045A7D8
	[NullableContext(1)]
	public void RefreshItem(IKingShipAttributeItemData data, Action<bool> onClickTipsCallBack)
	{
		this.HaveRefresh = true;
		this.AttributeId = data.AttributeId;
		this.OnClickTipsCallBack = onClickTipsCallBack;
		this.SetSpriteByPath(ConfigBase<KingShipConfig>.Instance.GetKingShipAttribute(data.AttributeId).Icon, base.GetSprite(0), false, null, null);
		this.MaxCount = data.MaxCount;
		this.MinCount = data.MinCount;
		this.CurrentCount = data.Current;
		UUISprite normalSprite = this.NormalSprite;
		if (normalSprite != null)
		{
			normalSprite.SetFillAmount((float)this.CurrentCount / (float)this.MaxCount);
		}
		UUISprite greenSprite = this.GreenSprite;
		if (greenSprite != null)
		{
			greenSprite.SetFillAmount(0f);
		}
		UUISprite redSprite = this.RedSprite;
		if (redSprite == null)
		{
			return;
		}
		redSprite.SetFillAmount(0f);
	}

	// Token: 0x0600FE77 RID: 65143 RVA: 0x0045C6A0 File Offset: 0x0045A8A0
	public void SetIsShow(bool isShow)
	{
		this.IsShowByKingShip = isShow;
		base.GetItem(10).SetUIActive(isShow);
		if (isShow)
		{
			LevelSequencePlayer levelSequencePlayer = this.LevelSequencePlayer;
			if (levelSequencePlayer != null)
			{
				levelSequencePlayer.PlayLevelSequenceByName("Start", false, null, false);
			}
		}
		Singleton<EventSystem>.Instance.Emit<int, bool>(EEventName.OnKingShipAttrItemSetShow, this.AttributeId, isShow);
	}

	// Token: 0x0600FE78 RID: 65144 RVA: 0x0045C700 File Offset: 0x0045A900
	public void RefreshAttribute(int valueChange)
	{
		this.CurrentCount += valueChange;
		this.CurrentCount = Singleton<MathUtils>.Instance.Clamp(this.CurrentCount, this.MinCount, this.MaxCount);
		this.IsRedSpriteMoving = false;
		this.IsGreenSpriteMoving = false;
		if (valueChange < 0)
		{
			UUISprite redSprite = this.RedSprite;
			if (redSprite != null)
			{
				UUISprite normalSprite = this.NormalSprite;
				redSprite.SetFillAmount((normalSprite != null) ? normalSprite.fillAmount : 0f);
			}
			UUISprite normalSprite2 = this.NormalSprite;
			if (normalSprite2 != null)
			{
				normalSprite2.SetFillAmount((float)this.CurrentCount / (float)this.MaxCount);
			}
			UUISprite normalSprite3 = this.NormalSprite;
			if (normalSprite3 != null)
			{
				normalSprite3.SetUIActive(false);
			}
			UUISprite greenSprite = this.GreenSprite;
			if (greenSprite != null)
			{
				greenSprite.SetFillAmount(0f);
			}
			this.IsRedSpriteMoving = true;
			return;
		}
		UUISprite greenSprite2 = this.GreenSprite;
		if (greenSprite2 != null)
		{
			UUISprite normalSprite4 = this.NormalSprite;
			greenSprite2.SetFillAmount((normalSprite4 != null) ? normalSprite4.fillAmount : 0f);
		}
		UUISprite normalSprite5 = this.NormalSprite;
		if (normalSprite5 != null)
		{
			normalSprite5.SetFillAmount((float)this.CurrentCount / (float)this.MaxCount);
		}
		UUISprite normalSprite6 = this.NormalSprite;
		if (normalSprite6 != null)
		{
			normalSprite6.SetUIActive(false);
		}
		UUISprite redSprite2 = this.RedSprite;
		if (redSprite2 != null)
		{
			redSprite2.SetFillAmount(0f);
		}
		this.IsGreenSpriteMoving = true;
	}

	// Token: 0x0600FE79 RID: 65145 RVA: 0x0045C83C File Offset: 0x0045AA3C
	public void RefreshBuffItem(int buffChangeValue, int buffRounds)
	{
		if (buffChangeValue == 0)
		{
			return;
		}
		this.BuffValueList[buffChangeValue] = buffRounds;
	}

	// Token: 0x0600FE7A RID: 65146 RVA: 0x0045C850 File Offset: 0x0045AA50
	public void RefreshUpDownItem()
	{
		int num = 0;
		if (this.BuffValueList.Count <= 0)
		{
			this.SetDownItem(false);
			this.SetUpItem(false);
			return;
		}
		foreach (KeyValuePair<int, int> keyValuePair in this.BuffValueList)
		{
			num += keyValuePair.Key;
		}
		if (num > 0)
		{
			this.SetUpItem(true);
			this.SetDownItem(false);
			return;
		}
		this.SetUpItem(false);
		this.SetDownItem(true);
	}

	// Token: 0x0600FE7B RID: 65147 RVA: 0x0045C8E8 File Offset: 0x0045AAE8
	public void RefreshBuffRounds()
	{
		foreach (int key in new List<int>(this.BuffValueList.Keys))
		{
			int num = this.BuffValueList[key] - 1;
			if (num <= 0)
			{
				this.BuffValueList.Remove(key);
			}
			else
			{
				this.BuffValueList[key] = num;
			}
		}
	}

	// Token: 0x0600FE7C RID: 65148 RVA: 0x0045C970 File Offset: 0x0045AB70
	public void SetDownItem(bool visible)
	{
		if (base.GetItem(2).IsUIActiveSelf() != visible)
		{
			LevelSequencePlayer levelSequencePlayer = this.LevelSequencePlayer;
			if (levelSequencePlayer != null)
			{
				levelSequencePlayer.StopCurrentSequence(false, false);
			}
			if (visible)
			{
				base.GetItem(2).SetUIActive(true);
				LevelSequencePlayer levelSequencePlayer2 = this.LevelSequencePlayer;
				if (levelSequencePlayer2 == null)
				{
					return;
				}
				levelSequencePlayer2.PlayLevelSequenceByName("ArrowIn", false, null, false);
				return;
			}
			else
			{
				LevelSequencePlayer levelSequencePlayer3 = this.LevelSequencePlayer;
				if (levelSequencePlayer3 != null)
				{
					levelSequencePlayer3.PlayLevelSequenceByName("ArrowOut", false, null, false);
				}
				this.DownHideFlag = true;
			}
		}
	}

	// Token: 0x0600FE7D RID: 65149 RVA: 0x0045C9F8 File Offset: 0x0045ABF8
	public void SetUpItem(bool visible)
	{
		if (base.GetItem(3).IsUIActiveSelf() != visible)
		{
			LevelSequencePlayer levelSequencePlayer = this.LevelSequencePlayer;
			if (levelSequencePlayer != null)
			{
				levelSequencePlayer.StopCurrentSequence(false, false);
			}
			if (visible)
			{
				base.GetItem(3).SetUIActive(true);
				LevelSequencePlayer levelSequencePlayer2 = this.LevelSequencePlayer;
				if (levelSequencePlayer2 == null)
				{
					return;
				}
				levelSequencePlayer2.PlayLevelSequenceByName("ArrowIn", false, null, false);
				return;
			}
			else
			{
				LevelSequencePlayer levelSequencePlayer3 = this.LevelSequencePlayer;
				if (levelSequencePlayer3 != null)
				{
					levelSequencePlayer3.PlayLevelSequenceByName("ArrowOut", false, null, false);
				}
				this.UpHideFlag = true;
			}
		}
	}

	// Token: 0x0600FE7E RID: 65150 RVA: 0x0045CA80 File Offset: 0x0045AC80
	public void SetAttributeItem(bool visible, int value = 0)
	{
		if (!visible || value == 0)
		{
			base.GetItem(6).SetUIActive(false);
			base.GetItem(7).SetUIActive(false);
			return;
		}
		bool flag = (float)Math.Abs(value) >= this.KingShipValueUseBigEffect;
		base.GetItem(6).SetUIActive(flag);
		base.GetItem(7).SetUIActive(!flag);
		if (flag)
		{
			LevelSequencePlayer levelSequencePlayer = this.LevelSequencePlayer;
			if (levelSequencePlayer != null)
			{
				levelSequencePlayer.StopCurrentSequence(false, false);
			}
			LevelSequencePlayer levelSequencePlayer2 = this.LevelSequencePlayer;
			if (levelSequencePlayer2 == null)
			{
				return;
			}
			levelSequencePlayer2.PlayLevelSequenceByName("GLoop", false, null, false);
			return;
		}
		else
		{
			LevelSequencePlayer levelSequencePlayer3 = this.LevelSequencePlayer;
			if (levelSequencePlayer3 != null)
			{
				levelSequencePlayer3.StopCurrentSequence(false, false);
			}
			LevelSequencePlayer levelSequencePlayer4 = this.LevelSequencePlayer;
			if (levelSequencePlayer4 == null)
			{
				return;
			}
			levelSequencePlayer4.PlayLevelSequenceByName("Loop", false, null, false);
			return;
		}
	}

	// Token: 0x0600FE7F RID: 65151 RVA: 0x0045CB48 File Offset: 0x0045AD48
	public void Update()
	{
		if (this.GreenSprite == null || this.NormalSprite == null || this.RedSprite == null || (!this.IsRedSpriteMoving && !this.IsGreenSpriteMoving))
		{
			return;
		}
		if (this.IsGreenSpriteMoving)
		{
			if (this.GreenSprite.fillAmount < this.NormalSprite.fillAmount)
			{
				this.GreenSprite.SetUIActive(true);
				this.GreenSprite.SetFillAmount(this.GreenSprite.fillAmount + this.BarSpeed);
			}
			else
			{
				this.NormalSprite.SetUIActive(true);
				this.GreenSprite.SetUIActive(false);
				this.IsGreenSpriteMoving = false;
			}
		}
		if (this.IsRedSpriteMoving)
		{
			if (this.RedSprite.fillAmount > this.NormalSprite.fillAmount)
			{
				this.RedSprite.SetUIActive(true);
				this.RedSprite.SetFillAmount(this.RedSprite.fillAmount - this.BarSpeed);
				return;
			}
			this.NormalSprite.SetUIActive(true);
			this.RedSprite.SetUIActive(false);
			this.IsRedSpriteMoving = false;
		}
	}

	// Token: 0x0600FE80 RID: 65152 RVA: 0x0045CC54 File Offset: 0x0045AE54
	private void OnClickButton()
	{
		if (this.AttributeId == 0)
		{
			return;
		}
		base.GetItem(8).SetUIActive(true);
		Action<bool> onClickTipsCallBack = this.OnClickTipsCallBack;
		if (onClickTipsCallBack != null)
		{
			onClickTipsCallBack(true);
		}
		LevelSequencePlayer levelSequencePlayer = this.LevelSequencePlayer;
		if (levelSequencePlayer != null)
		{
			levelSequencePlayer.StopCurrentSequence(false, false);
		}
		LevelSequencePlayer levelSequencePlayer2 = this.LevelSequencePlayer;
		if (levelSequencePlayer2 != null)
		{
			levelSequencePlayer2.PlayOrReplaySequenceByName("InfoIn", false, null);
		}
		KingShipAttribute kingShipAttribute = ConfigBase<KingShipConfig>.Instance.GetKingShipAttribute(this.AttributeId);
		Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(9), kingShipAttribute.DesText, Array.Empty<object>());
	}

	// Token: 0x0600FE81 RID: 65153 RVA: 0x0045CCEC File Offset: 0x0045AEEC
	public void CloseTipsItem()
	{
		base.GetItem(8).SetUIActive(false);
		Action<bool> onClickTipsCallBack = this.OnClickTipsCallBack;
		if (onClickTipsCallBack != null)
		{
			onClickTipsCallBack(false);
		}
		LevelSequencePlayer levelSequencePlayer = this.LevelSequencePlayer;
		if (levelSequencePlayer != null)
		{
			levelSequencePlayer.StopCurrentSequence(false, false);
		}
		LevelSequencePlayer levelSequencePlayer2 = this.LevelSequencePlayer;
		if (levelSequencePlayer2 == null)
		{
			return;
		}
		levelSequencePlayer2.PlayOrReplaySequenceByName("InfoOut", false, null);
	}

	// Token: 0x0600FE82 RID: 65154 RVA: 0x0045CD4A File Offset: 0x0045AF4A
	[NullableContext(1)]
	public UUIItem GetShowItem()
	{
		return base.GetItem(10);
	}

	// Token: 0x040079E8 RID: 31208
	private int AttributeId;

	// Token: 0x040079E9 RID: 31209
	private int MaxCount;

	// Token: 0x040079EA RID: 31210
	private int MinCount;

	// Token: 0x040079EB RID: 31211
	private float BarSpeed;

	// Token: 0x040079EC RID: 31212
	private float KingShipValueUseBigEffect;

	// Token: 0x040079ED RID: 31213
	public int CurrentCount;

	// Token: 0x040079EE RID: 31214
	public bool HaveRefresh;

	// Token: 0x040079EF RID: 31215
	private bool IsRedSpriteMoving;

	// Token: 0x040079F0 RID: 31216
	private bool IsGreenSpriteMoving;

	// Token: 0x040079F1 RID: 31217
	private UUISprite RedSprite;

	// Token: 0x040079F2 RID: 31218
	private UUISprite GreenSprite;

	// Token: 0x040079F3 RID: 31219
	private UUISprite NormalSprite;

	// Token: 0x040079F4 RID: 31220
	private LevelSequencePlayer LevelSequencePlayer;

	// Token: 0x040079F5 RID: 31221
	public Action<bool> OnClickTipsCallBack;

	// Token: 0x040079F6 RID: 31222
	private bool UpHideFlag;

	// Token: 0x040079F7 RID: 31223
	private bool DownHideFlag;

	// Token: 0x040079F8 RID: 31224
	[Nullable(1)]
	private readonly Dictionary<int, int> BuffValueList = new Dictionary<int, int>();

	// Token: 0x040079F9 RID: 31225
	public bool IsShowByKingShip;

	// Token: 0x02008421 RID: 33825
	[NullableContext(0)]
	private class EComponentDefine
	{
		// Token: 0x0402CC72 RID: 183410
		public const int IconSprite = 0;

		// Token: 0x0402CC73 RID: 183411
		public const int BarSprite = 1;

		// Token: 0x0402CC74 RID: 183412
		public const int DownItem = 2;

		// Token: 0x0402CC75 RID: 183413
		public const int UpItem = 3;

		// Token: 0x0402CC76 RID: 183414
		public const int RedBarSprite = 4;

		// Token: 0x0402CC77 RID: 183415
		public const int GreenBarSprite = 5;

		// Token: 0x0402CC78 RID: 183416
		public const int StrongEffectItem = 6;

		// Token: 0x0402CC79 RID: 183417
		public const int WeekEffectItem = 7;

		// Token: 0x0402CC7A RID: 183418
		public const int TipsItem = 8;

		// Token: 0x0402CC7B RID: 183419
		public const int TipsText = 9;

		// Token: 0x0402CC7C RID: 183420
		public const int ShowItem = 10;

		// Token: 0x0402CC7D RID: 183421
		public const int Button = 11;
	}
}
