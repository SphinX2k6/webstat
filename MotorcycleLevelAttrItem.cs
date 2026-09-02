using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
using Aki.Config;
using CSharpScript.Game.Module.Util;
using UnrealEngine;

// Token: 0x0200228F RID: 8847
[NullableContext(1)]
[Nullable(new byte[]
{
	0,
	1
})]
public class MotorcycleLevelAttrItem : GridProxyAbstract<IMotorLevelAttrData>
{
	// Token: 0x06010B9F RID: 68511 RVA: 0x00494BE0 File Offset: 0x00492DE0
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUIItem)),
			new ValueTuple<int, Type>(1, typeof(UUITexture)),
			new ValueTuple<int, Type>(2, typeof(UUIText)),
			new ValueTuple<int, Type>(3, typeof(UUIText)),
			new ValueTuple<int, Type>(4, typeof(UUISprite))
		};
	}

	// Token: 0x06010BA0 RID: 68512 RVA: 0x00494C66 File Offset: 0x00492E66
	private string GetEnoughColorStr(bool isEnough, string value)
	{
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append(isEnough ? "<color=#97ff86>" : "<color=#c25757>");
		stringBuilder.Append(value);
		stringBuilder.Append("</color>");
		return stringBuilder.ToString();
	}

	// Token: 0x06010BA1 RID: 68513 RVA: 0x00494C9C File Offset: 0x00492E9C
	public override void Refresh(IMotorLevelAttrData data, bool isSelected, int gridIndex)
	{
		MotorAttr? motorAttrConfig = ConfigBase<MotorConfig>.Instance.GetMotorAttrConfig(data.AttrId);
		if (motorAttrConfig == null)
		{
			return;
		}
		int curLevel = ModelBase<MotorcycleDevelopModel>.Instance.GetCurLevel();
		bool flag = curLevel < data.Level && data.IsSpecial;
		base.GetSprite(4).SetUIActive(flag);
		base.GetItem(0).SetUIActive(!flag && data.IsShowBg);
		base.SetTextureByPath(motorAttrConfig.Value.Icon, base.GetTexture(1), null, null);
		Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(2), motorAttrConfig.Value.Name, Array.Empty<object>());
		bool isNumber = motorAttrConfig.Value.IsNumber;
		float num = ModelBase<MotorcycleDevelopModel>.Instance.GetAttrValueByType(data.AttrId, data.Level);
		float num2 = ModelBase<MotorcycleDevelopModel>.Instance.GetAttrValueByType(data.AttrId, curLevel);
		if (data.IsSpecial)
		{
			num2 = ModelBase<MotorcycleDevelopModel>.Instance.GetAttrValueByType(data.AttrId, data.Level - 1);
		}
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
		text2 = (motorAttrConfig.Value.IsPercent ? StringUtils.Format("{0}%", new string[]
		{
			text2
		}) : text2);
		text3 = (motorAttrConfig.Value.IsPercent ? StringUtils.Format("{0}%", new string[]
		{
			text3
		}) : text3);
		string newText;
		if (num3 != 0f)
		{
			bool flag2 = data.Level > curLevel;
			if (!isNumber)
			{
				string text4 = StringUtils.Format(ConfigMultiTextLang.GetLocalTextNew("MotorBike_Status_Speed_LvUp", null), new string[]
				{
					text2,
					text3
				});
				string text5 = StringUtils.Format(ConfigMultiTextLang.GetLocalTextNew("MotorBike_Status_Speed_Lv", null), new string[]
				{
					text3
				});
				text4 = this.GetEnoughColorStr(flag2, text4);
				newText = (flag2 ? text4 : text5);
			}
			else
			{
				text = this.GetEnoughColorStr(flag2, text);
				newText = (flag2 ? StringUtils.Format("{0}{1}", new string[]
				{
					text2,
					text
				}) : text3);
			}
		}
		else if (!isNumber)
		{
			newText = StringUtils.Format(ConfigMultiTextLang.GetLocalTextNew("MotorBike_Status_Speed_Lv", null), new string[]
			{
				text3
			});
		}
		else
		{
			newText = text3;
		}
		base.GetText(3).SetText(newText, true);
	}

	// Token: 0x0200855A RID: 34138
	[NullableContext(0)]
	private class EMotorLevelAttrItemComponent
	{
		// Token: 0x0402D204 RID: 184836
		public const int BgItem = 0;

		// Token: 0x0402D205 RID: 184837
		public const int TexIcon = 1;

		// Token: 0x0402D206 RID: 184838
		public const int TxtAttrName = 2;

		// Token: 0x0402D207 RID: 184839
		public const int TxtAttrValue = 3;

		// Token: 0x0402D208 RID: 184840
		public const int SprAdditionBg = 4;
	}
}
