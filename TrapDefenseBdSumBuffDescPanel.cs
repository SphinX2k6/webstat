using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using CSharpScript.Game.Module.TrapDefense;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x02002C1A RID: 11290
[NullableContext(1)]
[Nullable(0)]
public class TrapDefenseBdSumBuffDescPanel : UiPanelBase
{
	// Token: 0x0601695F RID: 92511 RVA: 0x006449E0 File Offset: 0x00642BE0
	public UniTask Init(UUIItem item)
	{
		TrapDefenseBdSumBuffDescPanel.<Init>d__6 <Init>d__;
		<Init>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<Init>d__.<>4__this = this;
		<Init>d__.item = item;
		<Init>d__.<>1__state = -1;
		<Init>d__.<>t__builder.Start<TrapDefenseBdSumBuffDescPanel.<Init>d__6>(ref <Init>d__);
		return <Init>d__.<>t__builder.Task;
	}

	// Token: 0x06016960 RID: 92512 RVA: 0x00644A2B File Offset: 0x00642C2B
	protected override void OnBeforeCreate()
	{
	}

	// Token: 0x06016961 RID: 92513 RVA: 0x00644A30 File Offset: 0x00642C30
	protected unsafe override void OnRegisterComponent()
	{
		int num = 19;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int num2 = 0;
		*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(1, typeof(UUITexture));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(2, typeof(UUITexture));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(3, typeof(UUITexture));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(5, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(6, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(7, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(8, typeof(UUITexture));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(9, typeof(UUISprite));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(10, typeof(UUISprite));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(11, typeof(UUIExtendToggle));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(12, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(13, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(14, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(15, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(16, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(17, typeof(UUITexture));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(18, typeof(UUIItem));
		this.ComponentRegisterInfos = list;
		num2 = 1;
		List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
		CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
		Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
		num = 0;
		*span2[num] = new ValueTuple<int, Delegate>(11, new Action<EToggleState>(this.OnClickToggleRoot));
		this.BtnBindInfo = list2;
	}

	// Token: 0x06016962 RID: 92514 RVA: 0x00644D13 File Offset: 0x00642F13
	[Conditional("WITH_EDITOR")]
	private void EditorShowActorLabel()
	{
	}

	// Token: 0x06016963 RID: 92515 RVA: 0x00644D18 File Offset: 0x00642F18
	protected override UniTask OnBeforeStartAsync()
	{
		TrapDefenseBdSumBuffDescPanel.<OnBeforeStartAsync>d__10 <OnBeforeStartAsync>d__;
		<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnBeforeStartAsync>d__.<>4__this = this;
		<OnBeforeStartAsync>d__.<>1__state = -1;
		<OnBeforeStartAsync>d__.<>t__builder.Start<TrapDefenseBdSumBuffDescPanel.<OnBeforeStartAsync>d__10>(ref <OnBeforeStartAsync>d__);
		return <OnBeforeStartAsync>d__.<>t__builder.Task;
	}

	// Token: 0x06016964 RID: 92516 RVA: 0x00644D5C File Offset: 0x00642F5C
	protected override void OnStart()
	{
		TermExplanationRegistryParam param = new TermExplanationRegistryParam
		{
			UiText = base.GetText(6),
			ViewType = ETermExplanationViewType.Center,
			ReportType = ETermExplanationReportType.TrapDefenseBuff
		};
		ControllerBase<TermExplanationController>.Instance.RegisterTextHyperlinkByParam(param);
	}

	// Token: 0x06016965 RID: 92517 RVA: 0x00644D97 File Offset: 0x00642F97
	protected override void OnBeforeShow()
	{
	}

	// Token: 0x06016966 RID: 92518 RVA: 0x00644D99 File Offset: 0x00642F99
	protected override void OnBeforeDestroy()
	{
		base.GetExtendToggle(11).CanExecuteChange.Unbind();
		ControllerBase<TermExplanationController>.Instance.UnRegisterTextHyperlink(base.GetText(6));
	}

	// Token: 0x06016967 RID: 92519 RVA: 0x00644DC0 File Offset: 0x00642FC0
	private void UpdateDataBase(TrapDefenseBdBuffData data, TrapDefenseBdBuff? config = null)
	{
		this.BdBuffData = data;
		this.UpdateBgQuality();
		this.UpdateBuffConfig(config ?? data.BdBuffConfig);
		this.UpdateBdIcon();
	}

	// Token: 0x06016968 RID: 92520 RVA: 0x00644E00 File Offset: 0x00643000
	private void UpdateBuffConfig(TrapDefenseBdBuff config)
	{
		base.GetText(5).ShowTextNew(config.Name);
		Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(6), config.Desc, config.DescArgs());
		base.SetTextureByPath(config.Icon, base.GetTexture(3), null, null);
		base.SetTextureByPath(config.SubIcon, base.GetTexture(17), null, null);
	}

	// Token: 0x06016969 RID: 92521 RVA: 0x00644E7C File Offset: 0x0064307C
	public void UpdateBuffLockShowState()
	{
		base.GetText(5).ShowTextNew(ETrapDefenseTextKey.BdBuffLockShowName.ToString());
	}

	// Token: 0x0601696A RID: 92522 RVA: 0x00644E9C File Offset: 0x0064309C
	public void UpdateDataShowMode(TrapDefenseBdBuffData data)
	{
		bool isInstance = ModelBase<TrapDefenseModel>.Instance.ViewModelBdSum.IsInstance;
		TrapDefenseBdBuff showBdBuffConfig = data.GetShowBdBuffConfig(new bool?(isInstance));
		this.UpdateDataBase(data, new TrapDefenseBdBuff?(showBdBuffConfig));
		this.SetSwitchStrengthenShowState(data.IsCanSwitchStrengthen(new bool?(isInstance)));
		UUIItem item = base.GetItem(4);
		if (item != null)
		{
			item.SetUIActive(showBdBuffConfig.Level > 1);
		}
		this.SetRecommendByType(null);
		this.SetStrengthenEffect(null);
	}

	// Token: 0x0601696B RID: 92523 RVA: 0x00644F20 File Offset: 0x00643120
	public void UpdateDataSelectMode(TrapDefenseBdBuffData data)
	{
		this.UpdateDataBase(data, null);
		this.SetSwitchStrengthenShowState(false);
		UUIItem item = base.GetItem(4);
		if (item != null)
		{
			item.SetUIActive(false);
		}
		this.SetStrengthenEffect(null);
		this.UpdateRecommendState();
	}

	// Token: 0x0601696C RID: 92524 RVA: 0x00644F6C File Offset: 0x0064316C
	public void UpdateDataGetMode(TrapDefenseBdBuffData data)
	{
		this.UpdateDataBase(data, null);
		this.SetSwitchStrengthenShowState(false);
		UUIItem item = base.GetItem(4);
		if (item != null)
		{
			item.SetUIActive(data.IsStrengthenFinish());
		}
		this.SetRecommendByType(null);
		this.SetStrengthenEffect(null);
	}

	// Token: 0x0601696D RID: 92525 RVA: 0x00644FC8 File Offset: 0x006431C8
	public void UpdateDataStrengthenModeBefore(TrapDefenseBdBuffData data)
	{
		this.UpdateDataBase(data, new TrapDefenseBdBuff?(data.GetStrengthenBeforeConfig()));
		this.SetSwitchStrengthenShowState(false);
		UUIItem item = base.GetItem(4);
		if (item != null)
		{
			item.SetUIActive(false);
		}
		this.SetRecommendByType(null);
		this.SetStrengthenEffect(null);
	}

	// Token: 0x0601696E RID: 92526 RVA: 0x00645020 File Offset: 0x00643220
	public void UpdateDataStrengthenModeAfter(TrapDefenseBdBuffData data)
	{
		this.UpdateDataBase(data, new TrapDefenseBdBuff?(data.GetStrengthenConfig()));
		this.SetSwitchStrengthenShowState(false);
		UUIItem item = base.GetItem(4);
		if (item != null)
		{
			item.SetUIActive(true);
		}
		this.SetRecommendByType(null);
		int quality = data.Config.Quality;
		if (quality == 4)
		{
			this.SetStrengthenEffect(new int?(15));
			return;
		}
		if (quality == 5)
		{
			this.SetStrengthenEffect(new int?(16));
			return;
		}
		this.SetStrengthenEffect(null);
	}

	// Token: 0x0601696F RID: 92527 RVA: 0x006450A8 File Offset: 0x006432A8
	public void UpdateBdIcon()
	{
		string icon = this.BdBuffData.GetBelongBdData().Config.Icon;
		base.SetTextureByPath(icon, base.GetTexture(8), null, null);
	}

	// Token: 0x06016970 RID: 92528 RVA: 0x006450E4 File Offset: 0x006432E4
	private void UpdateBgQuality()
	{
		UUITexture texture = base.GetTexture(1);
		UUITexture texture2 = base.GetTexture(2);
		int quality = this.BdBuffData.Config.Quality;
		DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(22, 1);
		defaultInterpolatedStringHandler.AppendLiteral("T_TipsQualityTypeLevel");
		defaultInterpolatedStringHandler.AppendFormatted<int>(quality);
		string resId = defaultInterpolatedStringHandler.ToStringAndClear();
		defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(18, 1);
		defaultInterpolatedStringHandler.AppendLiteral("T_TermsIconBgLight");
		defaultInterpolatedStringHandler.AppendFormatted<int>(quality);
		string resId2 = defaultInterpolatedStringHandler.ToStringAndClear();
		this.SetTextureBgByResId(resId, texture);
		this.SetTextureBgByResId(resId2, texture2);
	}

	// Token: 0x06016971 RID: 92529 RVA: 0x00645170 File Offset: 0x00643370
	public void SetSelect(bool select)
	{
		UUIExtendToggle extendToggle = base.GetExtendToggle(11);
		EToggleState state = select ? EToggleState.ETT_Checked : EToggleState.ETT_UnChecked;
		if (extendToggle == null)
		{
			return;
		}
		extendToggle.SetToggleStateForce(state, false, false, false);
	}

	// Token: 0x06016972 RID: 92530 RVA: 0x0064519B File Offset: 0x0064339B
	private int GetRecommendEffectType(int quality)
	{
		switch (quality)
		{
		case 3:
			return 12;
		case 4:
			return 13;
		case 5:
			return 14;
		default:
			return 18;
		}
	}

	// Token: 0x06016973 RID: 92531 RVA: 0x006451C0 File Offset: 0x006433C0
	public void SetRecommendByType(int? type = null)
	{
		foreach (int num in new List<int>
		{
			18,
			12,
			13,
			14
		})
		{
			UUIItem item = base.GetItem(num);
			if (item != null)
			{
				int num2 = num;
				int? num3 = type;
				item.SetUIActive(num2 == num3.GetValueOrDefault() & num3 != null);
			}
		}
	}

	// Token: 0x06016974 RID: 92532 RVA: 0x00645254 File Offset: 0x00643454
	public void SetRecommendQualityLight(bool active, int quality)
	{
		UUISprite sprite = base.GetSprite(9);
		UUISprite sprite2 = base.GetSprite(10);
		sprite.SetUIActive(active);
		sprite2.SetUIActive(active);
		if (!active)
		{
			return;
		}
		string hexStr = "#A0FFB2FF";
		switch (quality)
		{
		case 3:
			hexStr = "#8DF7FFFF";
			break;
		case 4:
			hexStr = "#FE69FFFF";
			break;
		case 5:
			hexStr = "#FFDD56FF";
			break;
		}
		sprite.SetColor(FColor.FromHex(hexStr));
		sprite2.SetColor(FColor.FromHex(hexStr));
	}

	// Token: 0x06016975 RID: 92533 RVA: 0x006452D0 File Offset: 0x006434D0
	public void SetStrengthenEffect(int? type = null)
	{
		foreach (int num in new List<int>
		{
			15,
			16
		})
		{
			UUIItem item = base.GetItem(num);
			int num2 = num;
			int? num3 = type;
			item.SetUIActive(num2 == num3.GetValueOrDefault() & num3 != null);
		}
	}

	// Token: 0x06016976 RID: 92534 RVA: 0x0064534C File Offset: 0x0064354C
	public void SetTextureBgByResId(string resId, UUITexture uiTexture)
	{
		string resourcePath = ConfigBase<UiResourceConfig>.Instance.GetResourcePath(resId);
		base.SetTextureByPath(resourcePath, uiTexture, null, null);
	}

	// Token: 0x06016977 RID: 92535 RVA: 0x00645378 File Offset: 0x00643578
	public void SetSpriteBgByResId(string resId, UUISprite uiSprite)
	{
		string resourcePath = ConfigBase<UiResourceConfig>.Instance.GetResourcePath(resId);
		this.SetSpriteByPath(resourcePath, uiSprite, false, null, null);
	}

	// Token: 0x06016978 RID: 92536 RVA: 0x006453A4 File Offset: 0x006435A4
	public void SetSwitchStrengthenShowState(bool show)
	{
		this.SwitchComponent.SetActive(show);
		if (show)
		{
			this.SwitchComponent.SetToggleState(this.BdBuffData.IsShowStrengthen);
		}
	}

	// Token: 0x06016979 RID: 92537 RVA: 0x006453CB File Offset: 0x006435CB
	private void OnClickSwitchStrengthen(EToggleState state)
	{
		Action<bool, TrapDefenseBdBuffData> switchStrengthenCallback = this.SwitchStrengthenCallback;
		if (switchStrengthenCallback == null)
		{
			return;
		}
		switchStrengthenCallback(state == EToggleState.ETT_Checked, this.BdBuffData);
	}

	// Token: 0x0601697A RID: 92538 RVA: 0x006453E7 File Offset: 0x006435E7
	private void OnClickToggleRoot(EToggleState check)
	{
		Action<TrapDefenseBdBuffData> onSelectCallback = this.OnSelectCallback;
		if (onSelectCallback == null)
		{
			return;
		}
		onSelectCallback(this.BdBuffData);
	}

	// Token: 0x0601697B RID: 92539 RVA: 0x006453FF File Offset: 0x006435FF
	private bool CanExecuteChange()
	{
		Func<bool> onCanClickCallback = this.OnCanClickCallback;
		return onCanClickCallback != null && onCanClickCallback();
	}

	// Token: 0x0601697C RID: 92540 RVA: 0x00645414 File Offset: 0x00643614
	public void UpdateRecommendState()
	{
		bool item = this.BdBuffData.GetBelongBdData().PreAddedBuffIsActiveNewQuality(1).Item1;
		int quality = this.BdBuffData.Config.Quality;
		int? recommendByType = item ? new int?(this.GetRecommendEffectType(quality)) : null;
		this.SetRecommendByType(recommendByType);
		this.SetRecommendQualityLight(item, quality);
	}

	// Token: 0x0400AE67 RID: 44647
	public TrapDefenseBdBuffData BdBuffData;

	// Token: 0x0400AE68 RID: 44648
	public CommonSwitchItem SwitchComponent;

	// Token: 0x0400AE69 RID: 44649
	public Action<bool, TrapDefenseBdBuffData> SwitchStrengthenCallback;

	// Token: 0x0400AE6A RID: 44650
	public Action<TrapDefenseBdBuffData> OnSelectCallback;

	// Token: 0x0400AE6B RID: 44651
	public Func<bool> OnCanClickCallback;

	// Token: 0x02008F37 RID: 36663
	[NullableContext(0)]
	private class EChildType
	{
		// Token: 0x0403018D RID: 197005
		public const int ItemSwitchComponent = 0;

		// Token: 0x0403018E RID: 197006
		public const int TextureBgQualityLight = 1;

		// Token: 0x0403018F RID: 197007
		public const int TextureIconQualityLight = 2;

		// Token: 0x04030190 RID: 197008
		public const int TextureIcon = 3;

		// Token: 0x04030191 RID: 197009
		public const int ItemStrengthenTips = 4;

		// Token: 0x04030192 RID: 197010
		public const int TextTitle = 5;

		// Token: 0x04030193 RID: 197011
		public const int TextDesc = 6;

		// Token: 0x04030194 RID: 197012
		public const int ItemBdIcon = 7;

		// Token: 0x04030195 RID: 197013
		public const int TextureBdIcon = 8;

		// Token: 0x04030196 RID: 197014
		public const int SpriteRecommendQualityLight = 9;

		// Token: 0x04030197 RID: 197015
		public const int SpriteRecommendQualityLine = 10;

		// Token: 0x04030198 RID: 197016
		public const int ToggleRoot = 11;

		// Token: 0x04030199 RID: 197017
		public const int ItemRecommendEffectBlue = 12;

		// Token: 0x0403019A RID: 197018
		public const int ItemRecommendEffectPurple = 13;

		// Token: 0x0403019B RID: 197019
		public const int ItemRecommendEffectGold = 14;

		// Token: 0x0403019C RID: 197020
		public const int ItemStrengthenEffectPurple = 15;

		// Token: 0x0403019D RID: 197021
		public const int ItemStrengthenEffectGold = 16;

		// Token: 0x0403019E RID: 197022
		public const int TextureSubIcon = 17;

		// Token: 0x0403019F RID: 197023
		public const int ItemRecommendEffectGreen = 18;
	}
}
