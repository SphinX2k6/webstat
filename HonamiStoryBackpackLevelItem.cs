using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.HonamiStory;
using CSharpScript.Game.Module.Inventory;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x02001F00 RID: 7936
[NullableContext(2)]
[Nullable(0)]
public class HonamiStoryBackpackLevelItem : UiPanelBase
{
	// Token: 0x0600ECE3 RID: 60643 RVA: 0x0040883A File Offset: 0x00406A3A
	public HonamiStoryBackpackLevelItem(bool isInDungeon)
	{
		this.IsInDungeon = isInDungeon;
	}

	// Token: 0x0600ECE4 RID: 60644 RVA: 0x0040884C File Offset: 0x00406A4C
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUIText)),
			new ValueTuple<int, Type>(1, typeof(UUIText)),
			new ValueTuple<int, Type>(2, typeof(UUIText)),
			new ValueTuple<int, Type>(3, typeof(UUIButtonComponent)),
			new ValueTuple<int, Type>(4, typeof(UUISprite)),
			new ValueTuple<int, Type>(5, typeof(UUIItem)),
			new ValueTuple<int, Type>(6, typeof(UUISprite)),
			new ValueTuple<int, Type>(7, typeof(UUINiagara)),
			new ValueTuple<int, Type>(8, typeof(UUISprite)),
			new ValueTuple<int, Type>(9, typeof(UUITexture)),
			new ValueTuple<int, Type>(11, typeof(UUIText))
		};
		this.BtnBindInfo = new List<ValueTuple<int, Delegate>>
		{
			new ValueTuple<int, Delegate>(3, new Action(this.OnClickedUpdate))
		};
	}

	// Token: 0x0600ECE5 RID: 60645 RVA: 0x0040897C File Offset: 0x00406B7C
	protected override UniTask OnBeforeStartAsync()
	{
		HonamiStoryBackpackLevelItem.<OnBeforeStartAsync>d__16 <OnBeforeStartAsync>d__;
		<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnBeforeStartAsync>d__.<>4__this = this;
		<OnBeforeStartAsync>d__.<>1__state = -1;
		<OnBeforeStartAsync>d__.<>t__builder.Start<HonamiStoryBackpackLevelItem.<OnBeforeStartAsync>d__16>(ref <OnBeforeStartAsync>d__);
		return <OnBeforeStartAsync>d__.<>t__builder.Task;
	}

	// Token: 0x0600ECE6 RID: 60646 RVA: 0x004089BF File Offset: 0x00406BBF
	protected override void OnStart()
	{
		this.LevelSequencePlayer = new LevelSequencePlayer(this.RootItem);
	}

	// Token: 0x0600ECE7 RID: 60647 RVA: 0x004089D4 File Offset: 0x00406BD4
	protected override void OnBeforeShow()
	{
		HonamiStoryActivityData activityData = ModelBase<HonamiStoryModel>.Instance.GetActivityData(false);
		this.ActivityOpen = (activityData != null && activityData.GetPreGuideQuestFinishState());
		HonamiStoryLevelPowerItem powerItem = this.PowerItem;
		if (powerItem != null)
		{
			powerItem.RefreshPowerVisible(this.ActivityOpen);
		}
		this.RefreshLifeSupport();
		this.RefreshPowerLevel(false, false, 0, 0);
		this.CheckCanUpgrade();
		Singleton<EventSystem>.Instance.Add(EEventName.OnHonamiStoryLifeSupportLevelUp, new Action(this.ShowSuccessPanel));
	}

	// Token: 0x0600ECE8 RID: 60648 RVA: 0x00408A47 File Offset: 0x00406C47
	protected override void OnBeforeHide()
	{
		Singleton<EventSystem>.Instance.Remove(EEventName.OnHonamiStoryLifeSupportLevelUp, new Action(this.ShowSuccessPanel));
	}

	// Token: 0x0600ECE9 RID: 60649 RVA: 0x00408A68 File Offset: 0x00406C68
	public void RefreshLifeSupport()
	{
		int lifeSupportMaxLevel = ModelBase<HonamiStoryModel>.Instance.GetPlayerData().GetLifeSupportMaxLevel();
		int lifeSupportLevel = ModelBase<HonamiStoryModel>.Instance.GetPlayerData().LifeSupportLevel;
		bool flag = ModelBase<FunctionModel>.Instance.IsOpen(10122);
		bool flag2 = !this.IsInDungeon && lifeSupportLevel < lifeSupportMaxLevel && flag;
		bool flag3 = HonamiStoryUtil.CheckInHonamiStoryDungeon();
		UUIButtonComponent button = base.GetButton(3);
		if (button != null)
		{
			button.RootUIComp.Get().SetUIActive(flag2);
		}
		string resourceId = flag2 ? "T_BackpackUpdateBgB" : "T_BackpackUpdateBg";
		string path = ConfigBase<UiResourceConfig>.Instance.GetResourcePath(resourceId) ?? string.Empty;
		base.SetTextureByPath(path, base.GetTexture(9), null, null);
		bool flag4 = ModelBase<FunctionModel>.Instance.IsOpen(10105);
		UUIText text = base.GetText(1);
		if (text != null)
		{
			text.SetUIActive(flag4 && lifeSupportLevel != lifeSupportMaxLevel);
		}
		UUISprite sprite = base.GetSprite(8);
		if (sprite != null)
		{
			sprite.SetUIActive(flag4 && lifeSupportLevel == lifeSupportMaxLevel);
		}
		string key = flag4 ? "HonamiStory_TableValue_1" : "HonamiStory_TableValue_0";
		UUIText text2 = base.GetText(11);
		if (text2 != null)
		{
			text2.ShowTextNew(key);
		}
		if (flag4 && lifeSupportLevel != lifeSupportMaxLevel)
		{
			UUIText text3 = base.GetText(1);
			if (text3 != null)
			{
				DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(0, 1);
				defaultInterpolatedStringHandler.AppendFormatted<int>(lifeSupportLevel);
				text3.SetText(defaultInterpolatedStringHandler.ToStringAndClear(), true);
			}
		}
		EFormationAttributeId attrId = EFormationAttributeId.HonamiStoryLifeSupport;
		if (flag3)
		{
			float value = ControllerBase<FormationAttributeController>.Instance.GetValue(attrId);
			float max = ControllerBase<FormationAttributeController>.Instance.GetMax(attrId);
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(2), "HonamiStory_LifeSupport_Value", new <>z__ReadOnlyArray<object>(new object[]
			{
				value,
				max
			}));
			UUISprite sprite2 = base.GetSprite(4);
			if (sprite2 != null)
			{
				sprite2.SetFillAmount(value / max);
			}
		}
		else
		{
			int curMaxValue = ModelBase<HonamiStoryModel>.Instance.GetPlayerData().GetCurMaxValue();
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(2), "HonamiStory_LifeSupport_Value", new <>z__ReadOnlyArray<object>(new object[]
			{
				curMaxValue,
				curMaxValue
			}));
			UUISprite sprite3 = base.GetSprite(4);
			if (sprite3 != null)
			{
				sprite3.SetFillAmount((float)(curMaxValue / curMaxValue));
			}
		}
		string lifeSupportIcon = ModelBase<HonamiStoryModel>.Instance.GetPlayerData().GetLifeSupportIcon();
		this.SetSpriteByPath(lifeSupportIcon, base.GetSprite(6), false, null, null);
	}

	// Token: 0x0600ECEA RID: 60650 RVA: 0x00408CC4 File Offset: 0x00406EC4
	public void RefreshPowerLevel(bool needAnim, bool isAdd, int oldValue, int newValue)
	{
		if (!this.ActivityOpen)
		{
			return;
		}
		if (needAnim)
		{
			this.FrameCount = 0;
			this.IsAdd = isAdd;
			this.NewValue = newValue;
			if (this.AnimTimerHandle != null)
			{
				if (this.AnimTimerHandle.Valid())
				{
					TimerSystem.GameplayTimeInstance.Remove(this.AnimTimerHandle);
				}
				this.OldValue = this.CurValue;
			}
			else
			{
				this.OldValue = oldValue;
			}
			this.AnimTimerHandle = TimerSystem.GameplayTimeInstance.Next(new TTimerAction(this.OnPowerAnim), null, null);
			if (isAdd)
			{
				LevelSequencePlayer levelSequencePlayer = this.LevelSequencePlayer;
				if (levelSequencePlayer != null)
				{
					levelSequencePlayer.PlayOrReplaySequenceByName("Up", false, null);
				}
				LevelSequencePlayer levelSequencePlayer2 = this.LevelSequencePlayer;
				if (levelSequencePlayer2 != null && levelSequencePlayer2.IsPlayingSequence("Down"))
				{
					LevelSequencePlayer levelSequencePlayer3 = this.LevelSequencePlayer;
					if (levelSequencePlayer3 == null)
					{
						return;
					}
					levelSequencePlayer3.StopSequenceByKey("Down", false, false);
					return;
				}
			}
			else
			{
				LevelSequencePlayer levelSequencePlayer4 = this.LevelSequencePlayer;
				if (levelSequencePlayer4 != null)
				{
					levelSequencePlayer4.PlayOrReplaySequenceByName("Down", false, null);
				}
				LevelSequencePlayer levelSequencePlayer5 = this.LevelSequencePlayer;
				if (levelSequencePlayer5 != null && levelSequencePlayer5.IsPlayingSequence("Up"))
				{
					LevelSequencePlayer levelSequencePlayer6 = this.LevelSequencePlayer;
					if (levelSequencePlayer6 == null)
					{
						return;
					}
					levelSequencePlayer6.StopSequenceByKey("Up", false, false);
				}
			}
			return;
		}
		if (newValue != 0)
		{
			UUIText text = base.GetText(0);
			if (text == null)
			{
				return;
			}
			DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(0, 1);
			defaultInterpolatedStringHandler.AppendFormatted<int>(newValue);
			text.SetText(defaultInterpolatedStringHandler.ToStringAndClear(), true);
			return;
		}
		else
		{
			int powerLevel = ModelBase<HonamiStoryModel>.Instance.GetPlayerData().PowerLevel;
			UUIText text2 = base.GetText(0);
			if (text2 == null)
			{
				return;
			}
			DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(0, 1);
			defaultInterpolatedStringHandler.AppendFormatted<int>(powerLevel);
			text2.SetText(defaultInterpolatedStringHandler.ToStringAndClear(), true);
			return;
		}
	}

	// Token: 0x0600ECEB RID: 60651 RVA: 0x00408E5B File Offset: 0x0040705B
	public void SetIsEnable(bool value)
	{
		UUIItem rootItem = this.RootItem;
		if (rootItem != null)
		{
			rootItem.SetAlpha(value ? 1f : 0.4f);
		}
		UUIButtonComponent button = base.GetButton(3);
		if (button == null)
		{
			return;
		}
		button.SetSelfInteractive(value);
	}

	// Token: 0x0600ECEC RID: 60652 RVA: 0x00408E90 File Offset: 0x00407090
	public void CheckCanUpgrade()
	{
		HonamiStoryActivityData activityData = ModelBase<HonamiStoryModel>.Instance.GetActivityData(true);
		if (activityData == null)
		{
			return;
		}
		if (!ModelBase<FunctionModel>.Instance.IsOpen(10122))
		{
			return;
		}
		int lifeSupportLevel = ModelBase<HonamiStoryModel>.Instance.GetPlayerData().LifeSupportLevel;
		int lifeSupportMaxLevel = ModelBase<HonamiStoryModel>.Instance.GetPlayerData().GetLifeSupportMaxLevel();
		if (!this.IsInDungeon && lifeSupportLevel < lifeSupportMaxLevel)
		{
			int curLevelId = ModelBase<HonamiStoryModel>.Instance.GetPlayerData().GetCurLevelId(lifeSupportLevel);
			Dictionary<int, int> dictionary = ConfigBase<HonamiStoryConfig>.Instance.GetLifeSupport(curLevelId).Value.ConsumeItems();
			int? num = null;
			int value;
			if (dictionary.TryGetValue(activityData.OutCoinItemId, out value))
			{
				num = new int?(value);
			}
			int currencyCount = ModelBase<HonamiStoryModel>.Instance.GetCurrencyCount();
			bool flag;
			if (num != null)
			{
				int? num2 = num;
				int num3 = currencyCount;
				flag = (num2.GetValueOrDefault() <= num3 & num2 != null);
			}
			else
			{
				flag = false;
			}
			bool flag2 = flag;
			if (flag2 != this.IsAnimOn)
			{
				this.IsAnimOn = flag2;
				if (flag2)
				{
					LevelSequencePlayer levelSequencePlayer = this.LevelSequencePlayer;
					if (levelSequencePlayer == null)
					{
						return;
					}
					levelSequencePlayer.PlayLevelSequenceByName("Tips_Circle", false, null, false);
					return;
				}
				else
				{
					UUINiagara uiNiagara = base.GetUiNiagara(7);
					if (uiNiagara == null)
					{
						return;
					}
					uiNiagara.SetUIActive(false);
				}
			}
			return;
		}
		UUINiagara uiNiagara2 = base.GetUiNiagara(7);
		if (uiNiagara2 == null)
		{
			return;
		}
		uiNiagara2.SetUIActive(false);
	}

	// Token: 0x0600ECED RID: 60653 RVA: 0x00408FD0 File Offset: 0x004071D0
	private void OnClickedUpdate()
	{
		if (this.IsInDungeon)
		{
			return;
		}
		int lifeSupportLevel = ModelBase<HonamiStoryModel>.Instance.GetPlayerData().LifeSupportLevel;
		int lifeSupportMaxLevel = ModelBase<HonamiStoryModel>.Instance.GetPlayerData().GetLifeSupportMaxLevel();
		if (lifeSupportLevel < lifeSupportMaxLevel)
		{
			int num = lifeSupportLevel + 1;
			int num2 = lifeSupportLevel + 1;
			int id = num + 1;
			HonamiStoryActivityData activityData = ModelBase<HonamiStoryModel>.Instance.GetActivityData(true);
			if (activityData == null)
			{
				return;
			}
			int itemCountByConfigId = ModelBase<InventoryModel>.Instance.GetItemCountByConfigId(activityData.OutCoinItemId, 0);
			Dictionary<int, int> dictionary = ConfigBase<HonamiStoryConfig>.Instance.GetLifeSupport(num).Value.ConsumeItems();
			int? num3 = null;
			int value;
			if (dictionary.TryGetValue(activityData.OutCoinItemId, out value))
			{
				num3 = new int?(value);
			}
			int steadyValue = ConfigBase<HonamiStoryConfig>.Instance.GetLifeSupport(num).Value.SteadyValue;
			int steadyValue2 = ConfigBase<HonamiStoryConfig>.Instance.GetLifeSupport(id).Value.SteadyValue;
			ItemConfig itemConfigData = ConfigBase<InventoryConfig>.Instance.GetItemConfigData(activityData.OutCoinItemId);
			string value2 = string.Empty;
			if (itemConfigData != null && !string.IsNullOrEmpty(itemConfigData.IconSmall))
			{
				value2 = itemConfigData.IconSmall;
			}
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append("<texture=");
			stringBuilder.Append(value2);
			stringBuilder.Append("/>");
			int valueOrDefault = num3.GetValueOrDefault();
			ConfirmBoxDataNew confirmBoxDataNew = new ConfirmBoxDataNew(EConfirmBoxConfigId.HonamiStoryLifeSupportLevelConfirm);
			confirmBoxDataNew.SetTextArgs(new string[]
			{
				valueOrDefault.ToString(),
				stringBuilder.ToString(),
				num2.ToString(),
				steadyValue.ToString(),
				steadyValue2.ToString()
			});
			confirmBoxDataNew.FunctionMap.Add(2, new Action(this.RequestForUpgrade));
			if (itemCountByConfigId < valueOrDefault)
			{
				confirmBoxDataNew.SetTipsBgRed = true;
				confirmBoxDataNew.SetTableTextArgNew("Text_NotEnoughItem_Text", Array.Empty<object>());
				confirmBoxDataNew.InteractionMap.Add(1, false);
			}
			ControllerBase<ConfirmBoxController>.Instance.ShowConfirmBoxNew(confirmBoxDataNew);
		}
	}

	// Token: 0x0600ECEE RID: 60654 RVA: 0x004091C4 File Offset: 0x004073C4
	private void RequestForUpgrade()
	{
		ControllerBase<HonamiStoryController>.Instance.RequestHonamiStoryLifeSupportUp().ContinueWith(delegate(bool _)
		{
			this.RefreshLifeSupport();
		});
	}

	// Token: 0x0600ECEF RID: 60655 RVA: 0x004091E4 File Offset: 0x004073E4
	private void ShowSuccessPanel()
	{
		this.CheckCanUpgrade();
		int lifeSupportLevel = ModelBase<HonamiStoryModel>.Instance.GetPlayerData().LifeSupportLevel;
		int lifeSupportMaxLevel = ModelBase<HonamiStoryModel>.Instance.GetPlayerData().GetLifeSupportMaxLevel();
		int steadyValue = ConfigBase<HonamiStoryConfig>.Instance.GetLifeSupport(lifeSupportLevel).Value.SteadyValue;
		int steadyValue2 = ConfigBase<HonamiStoryConfig>.Instance.GetLifeSupport(lifeSupportLevel + 1).Value.SteadyValue;
		List<IAttributeInfo> list = new List<IAttributeInfo>();
		AttributeInfo item = new AttributeInfo
		{
			Name = "HonamiStory_Tech_TalentTreeTips",
			ShowArrow = new bool?(true),
			PreText = steadyValue.ToString(),
			CurText = steadyValue2.ToString()
		};
		list.Add(item);
		LevelUpSuccessAttributeData data = new LevelUpSuccessAttributeData
		{
			LevelInfo = new LevelInfo
			{
				PreUpgradeLv = lifeSupportLevel - 1,
				UpgradeLv = lifeSupportLevel,
				FormatStringId = "Text_LevelShow_Text",
				IsMaxLevel = new bool?(lifeSupportLevel == lifeSupportMaxLevel)
			},
			WiderScrollView = new bool?(true),
			AttributeInfo = list
		};
		ControllerBase<RoleLevelUpSuccessController>.Instance.OpenSuccessAttributeView(data, null);
	}

	// Token: 0x0600ECF0 RID: 60656 RVA: 0x004092FC File Offset: 0x004074FC
	private void OnPowerAnim(float _)
	{
		this.FrameCount++;
		int num = this.IsAdd ? 9 : 6;
		this.CurValue = (this.IsAdd ? ((int)Math.Ceiling((double)((float)this.OldValue + (float)((this.NewValue - this.OldValue) * this.FrameCount) / (float)num))) : ((int)Math.Floor((double)((float)this.OldValue - (float)((this.OldValue - this.NewValue) * this.FrameCount) / (float)num))));
		if (this.IsAdd)
		{
			this.CurValue = Math.Min(this.NewValue, this.CurValue);
		}
		else
		{
			this.CurValue = Math.Max(this.NewValue, this.CurValue);
		}
		UUIText text = base.GetText(0);
		if (text != null)
		{
			DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(0, 1);
			defaultInterpolatedStringHandler.AppendFormatted<int>(this.CurValue);
			text.SetText(defaultInterpolatedStringHandler.ToStringAndClear(), true);
		}
		if (this.FrameCount < num)
		{
			this.AnimTimerHandle = TimerSystem.GameplayTimeInstance.Next(new TTimerAction(this.OnPowerAnim), null, null);
			return;
		}
		this.AnimTimerHandle = null;
	}

	// Token: 0x040071D5 RID: 29141
	private const int ADD_FRAME = 9;

	// Token: 0x040071D6 RID: 29142
	private const int DOWN_FRAME = 6;

	// Token: 0x040071D7 RID: 29143
	private bool ActivityOpen;

	// Token: 0x040071D8 RID: 29144
	private bool IsAnimOn;

	// Token: 0x040071D9 RID: 29145
	private int OldValue;

	// Token: 0x040071DA RID: 29146
	private int CurValue;

	// Token: 0x040071DB RID: 29147
	private int NewValue;

	// Token: 0x040071DC RID: 29148
	private bool IsAdd;

	// Token: 0x040071DD RID: 29149
	private LevelSequencePlayer LevelSequencePlayer;

	// Token: 0x040071DE RID: 29150
	private TimerHandle AnimTimerHandle;

	// Token: 0x040071DF RID: 29151
	private int FrameCount;

	// Token: 0x040071E0 RID: 29152
	private HonamiStoryLevelPowerItem PowerItem;

	// Token: 0x040071E1 RID: 29153
	private readonly bool IsInDungeon;

	// Token: 0x02008257 RID: 33367
	[NullableContext(0)]
	private enum EItem
	{
		// Token: 0x0402C355 RID: 181077
		TxtPower,
		// Token: 0x0402C356 RID: 181078
		TxtLevel,
		// Token: 0x0402C357 RID: 181079
		TxtNum,
		// Token: 0x0402C358 RID: 181080
		BtnUpdate,
		// Token: 0x0402C359 RID: 181081
		Bar,
		// Token: 0x0402C35A RID: 181082
		PowerItem,
		// Token: 0x0402C35B RID: 181083
		StateSprite,
		// Token: 0x0402C35C RID: 181084
		Niagara,
		// Token: 0x0402C35D RID: 181085
		SpriteMax,
		// Token: 0x0402C35E RID: 181086
		TexBg,
		// Token: 0x0402C35F RID: 181087
		PanelTips,
		// Token: 0x0402C360 RID: 181088
		TxtName
	}
}
