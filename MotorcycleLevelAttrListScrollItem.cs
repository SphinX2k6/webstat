using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Module.Util;
using UnrealEngine;

// Token: 0x02002290 RID: 8848
[NullableContext(1)]
[Nullable(new byte[]
{
	0,
	1
})]
public class MotorcycleLevelAttrListScrollItem : GridProxyAbstract<IMotorLevelAttrData>
{
	// Token: 0x06010BA3 RID: 68515 RVA: 0x00494FA8 File Offset: 0x004931A8
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUIExtendToggle)),
			new ValueTuple<int, Type>(1, typeof(UUISprite)),
			new ValueTuple<int, Type>(2, typeof(UUITexture)),
			new ValueTuple<int, Type>(3, typeof(UUIText)),
			new ValueTuple<int, Type>(4, typeof(UUIText)),
			new ValueTuple<int, Type>(5, typeof(UUIText)),
			new ValueTuple<int, Type>(6, typeof(UUIItem)),
			new ValueTuple<int, Type>(7, typeof(UUIItem)),
			new ValueTuple<int, Type>(8, typeof(UUIText))
		};
		this.BtnBindInfo = new List<ValueTuple<int, Delegate>>
		{
			new ValueTuple<int, Delegate>(0, new Action<EToggleState>(this.ToggleEvent))
		};
	}

	// Token: 0x06010BA4 RID: 68516 RVA: 0x004950AC File Offset: 0x004932AC
	protected override void OnStart()
	{
		UUIExtendToggle extendToggle = base.GetExtendToggle(0);
		extendToggle.RootUIComp.Get().SetUIActive(true);
		extendToggle.CanExecuteChange.Unbind();
		extendToggle.CanExecuteChange.Bind(new Func<bool>(this.CanClickLikeToggle));
		this.LevelSequencePlayer = new LevelSequencePlayer(this.RootItem);
		base.GetItem(7).SetUIActive(false);
	}

	// Token: 0x06010BA5 RID: 68517 RVA: 0x00495113 File Offset: 0x00493313
	protected override void OnBeforeDestroy()
	{
		if (this.LevelSequencePlayer != null)
		{
			this.LevelSequencePlayer.Clear();
			this.LevelSequencePlayer = null;
		}
	}

	// Token: 0x06010BA6 RID: 68518 RVA: 0x00495130 File Offset: 0x00493330
	public override void Refresh(IMotorLevelAttrData data, bool isSelected, int gridIndex)
	{
		MotorAttr? motorAttrConfig = ConfigBase<MotorConfig>.Instance.GetMotorAttrConfig(data.AttrId);
		if (motorAttrConfig == null)
		{
			return;
		}
		base.GetSprite(1).useChangeColor = !data.IsShowBg;
		this.AttrDesc = motorAttrConfig.Value.Desc;
		if (!StringUtils.IsBlank(this.AttrDesc))
		{
			base.GetItem(6).SetUIActive(true);
			base.GetText(8).ShowTextNew(this.AttrDesc);
		}
		else
		{
			base.GetItem(6).SetUIActive(false);
		}
		int curLevel = ModelBase<MotorcycleDevelopModel>.Instance.GetCurLevel();
		bool isNumber = motorAttrConfig.Value.IsNumber;
		float num = ModelBase<MotorcycleDevelopModel>.Instance.GetAttrValueByType(data.AttrId, data.Level);
		float num2 = ModelBase<MotorcycleDevelopModel>.Instance.GetAttrValueByType(data.AttrId, curLevel);
		num = (motorAttrConfig.Value.IsPercent ? (num / 100f) : num);
		num2 = (motorAttrConfig.Value.IsPercent ? (num2 / 100f) : num2);
		float num3 = num - num2;
		string text = (num3 > 0f) ? StringUtils.Format("+{0}", new string[]
		{
			num3.ToString()
		}) : num3.ToString();
		string text2 = num2.ToString();
		string text3 = num.ToString();
		text = (motorAttrConfig.Value.IsPercent ? StringUtils.Format("{0}%", new string[]
		{
			text
		}) : text);
		text3 = (motorAttrConfig.Value.IsPercent ? StringUtils.Format("{0}%", new string[]
		{
			text3
		}) : text3);
		text2 = (motorAttrConfig.Value.IsPercent ? StringUtils.Format("{0}%", new string[]
		{
			text2
		}) : text2);
		if (!StringUtils.IsBlank(motorAttrConfig.Value.Suffix))
		{
			string text4 = ConfigMultiTextLang.GetLocalTextNew(motorAttrConfig.Value.Suffix, null) ?? "";
			text = StringUtils.Format("{0}{1}", new string[]
			{
				text,
				text4
			});
			text3 = StringUtils.Format("{0}{1}", new string[]
			{
				text3,
				text4
			});
			text2 = StringUtils.Format("{0}{1}", new string[]
			{
				text2,
				text4
			});
		}
		FColor fcolor = FColor.FromHex("97ff86");
		FColor fcolor2 = FColor.FromHex("c25757");
		if (!isNumber)
		{
			string text5 = StringUtils.Format(ConfigMultiTextLang.GetLocalTextNew("MotorBike_Status_Speed_Lv", null), new string[]
			{
				num.ToString()
			});
			text2 = ((num3 > 0f) ? "" : text5);
			text3 = ((num3 > 0f) ? "" : text5);
			text5 = StringUtils.Format(ConfigMultiTextLang.GetLocalTextNew("MotorBike_Status_Speed_LvUp", null), new string[]
			{
				num2.ToString(),
				num.ToString()
			});
			text = text5;
		}
		base.GetText(4).SetText((data.Level > curLevel) ? text2 : text3, true);
		base.GetText(5).SetText(text, true);
		base.GetText(5).SetColor((data.Level > curLevel) ? fcolor : fcolor2);
		base.GetText(5).SetUIActive(data.Level > curLevel && num3 != 0f);
		base.GetText(3).ShowTextNew(motorAttrConfig.Value.Name);
		base.SetTextureByPath(motorAttrConfig.Value.Icon, base.GetTexture(2), null, null);
	}

	// Token: 0x06010BA7 RID: 68519 RVA: 0x004954DD File Offset: 0x004936DD
	private bool CanClickLikeToggle()
	{
		return !StringUtils.IsBlank(this.AttrDesc);
	}

	// Token: 0x06010BA8 RID: 68520 RVA: 0x004954F0 File Offset: 0x004936F0
	protected void ToggleEvent(EToggleState bState)
	{
		bool flag = bState == EToggleState.ETT_Checked;
		base.GetText(8).SetUIActive(flag);
		base.GetItem(7).SetUIActive(flag);
		string sequenceName = flag ? "Show" : "Hide";
		if (this.LevelSequencePlayer != null)
		{
			this.LevelSequencePlayer.StopCurrentSequence(false, false);
			this.LevelSequencePlayer.PlayLevelSequenceByName(sequenceName, false, null, false);
		}
	}

	// Token: 0x040083FB RID: 33787
	[Nullable(2)]
	private LevelSequencePlayer LevelSequencePlayer;

	// Token: 0x040083FC RID: 33788
	private string AttrDesc = "";

	// Token: 0x0200855B RID: 34139
	[NullableContext(0)]
	private class EAttrItemDefine
	{
		// Token: 0x0402D209 RID: 184841
		public const int ToggleBase = 0;

		// Token: 0x0402D20A RID: 184842
		public const int SpriteBase = 1;

		// Token: 0x0402D20B RID: 184843
		public const int AttrIconTexture = 2;

		// Token: 0x0402D20C RID: 184844
		public const int AttrNameText = 3;

		// Token: 0x0402D20D RID: 184845
		public const int AttrBaseValue = 4;

		// Token: 0x0402D20E RID: 184846
		public const int AttrAddValue = 5;

		// Token: 0x0402D20F RID: 184847
		public const int Arrow = 6;

		// Token: 0x0402D210 RID: 184848
		public const int PanelDescription = 7;

		// Token: 0x0402D211 RID: 184849
		public const int TextDescription = 8;
	}
}
