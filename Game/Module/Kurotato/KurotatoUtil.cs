using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using UnrealEngine;

namespace CSharpScript.Game.Module.Kurotato
{
	// Token: 0x02005A6E RID: 23150
	[NullableContext(1)]
	[Nullable(0)]
	public static class KurotatoUtil
	{
		// Token: 0x0603A941 RID: 239937 RVA: 0x00ED5144 File Offset: 0x00ED3344
		public static string GetEffectDescription(IReadOnlyList<int> effectIdList)
		{
			List<string> list = new List<string>();
			foreach (int effectId in effectIdList)
			{
				list.Add(ConfigBase<KurotatoConfig>.Instance.GetEffectById(effectId).Value.Desc);
			}
			return string.Join("\n", list);
		}

		// Token: 0x0603A942 RID: 239938 RVA: 0x00ED51B8 File Offset: 0x00ED33B8
		public static List<string> GetEffectDescriptionLines(IReadOnlyList<int> effectIdList)
		{
			List<string> list = new List<string>();
			foreach (int effectId in effectIdList)
			{
				list.Add(ConfigBase<KurotatoConfig>.Instance.GetEffectById(effectId).Value.Desc);
			}
			return list;
		}

		// Token: 0x0603A943 RID: 239939 RVA: 0x00ED5224 File Offset: 0x00ED3424
		public static string GetPropertyShowValue(int propertyId, float value)
		{
			KurotatoProperty value2 = ConfigBase<KurotatoConfig>.Instance.GetPropertyById(propertyId).Value;
			KurotatoUtil.<>c__DisplayClass2_0 CS$<>8__locals1;
			CS$<>8__locals1.precision = value2.Precision;
			CS$<>8__locals1.factor = (float)Math.Pow(10.0, (double)CS$<>8__locals1.precision);
			switch (value2.ShowType)
			{
			case 2:
				return KurotatoUtil.<GetPropertyShowValue>g__CeilToPrecision|2_0(value / 100f, ref CS$<>8__locals1) + "%";
			case 3:
				return KurotatoUtil.<GetPropertyShowValue>g__CeilToPrecision|2_0(value, ref CS$<>8__locals1) + "%";
			}
			return KurotatoUtil.<GetPropertyShowValue>g__CeilToPrecision|2_0(value, ref CS$<>8__locals1);
		}

		// Token: 0x0603A944 RID: 239940 RVA: 0x00ED52C4 File Offset: 0x00ED34C4
		public static void SetAttrValueColor(UUIText text, float value, float? baseValue)
		{
			if (baseValue != null && value > baseValue.Value)
			{
				text.SetColor(FColor.FromHex("#31dea7"));
				return;
			}
			if (baseValue != null && value < baseValue.Value)
			{
				text.SetColor(FColor.FromHex("#f53864"));
				return;
			}
			text.SetColor(FColor.FromHex("#ffffff"));
		}

		// Token: 0x0603A945 RID: 239941 RVA: 0x00ED5329 File Offset: 0x00ED3529
		public static void ApplyAttrColor(UUIText text, float rawValue, float? baseValue, bool isLocked)
		{
			if (isLocked)
			{
				text.SetColor(FColor.FromHex("#ffffff"));
				return;
			}
			KurotatoUtil.SetAttrValueColor(text, rawValue, baseValue);
		}

		// Token: 0x0603A946 RID: 239942 RVA: 0x00ED5348 File Offset: 0x00ED3548
		public static string WrapAttrValueColor(string valueStr, float currentValue, float baseValue)
		{
			if (currentValue > baseValue)
			{
				DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(16, 2);
				defaultInterpolatedStringHandler.AppendLiteral("<color=");
				defaultInterpolatedStringHandler.AppendFormatted("#31dea7");
				defaultInterpolatedStringHandler.AppendLiteral(">");
				defaultInterpolatedStringHandler.AppendFormatted(valueStr);
				defaultInterpolatedStringHandler.AppendLiteral("</color>");
				return defaultInterpolatedStringHandler.ToStringAndClear();
			}
			if (currentValue < baseValue)
			{
				DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(16, 2);
				defaultInterpolatedStringHandler.AppendLiteral("<color=");
				defaultInterpolatedStringHandler.AppendFormatted("#f53864");
				defaultInterpolatedStringHandler.AppendLiteral(">");
				defaultInterpolatedStringHandler.AppendFormatted(valueStr);
				defaultInterpolatedStringHandler.AppendLiteral("</color>");
				return defaultInterpolatedStringHandler.ToStringAndClear();
			}
			return valueStr;
		}

		// Token: 0x0603A947 RID: 239943 RVA: 0x00ED53F4 File Offset: 0x00ED35F4
		public static List<IKurotatoAttrDisplay> GetItemAttrDisplayList(IReadOnlyList<int> effectIdList, bool colorCompare = false, bool showName = true, bool colorBySign = false)
		{
			List<IKurotatoAttrDisplay> list = new List<IKurotatoAttrDisplay>();
			KurotatoConfig instance = ConfigBase<KurotatoConfig>.Instance;
			foreach (int effectId in effectIdList)
			{
				KurotatoEffect? effectById = instance.GetEffectById(effectId);
				if (effectById != null)
				{
					KurotatoEffect value = effectById.Value;
					if (value.DisableShow != 1 && !(value.Type != "ModifyProp"))
					{
						string param = value.Param1 ?? "";
						string param2 = value.Param2 ?? "";
						string text = KurotatoUtil.ParseParamValue(param, "Prop");
						string s = KurotatoUtil.ParseParamValue(param2, "Amount");
						if (!string.IsNullOrEmpty(text))
						{
							KurotatoProperty? propertyByName = instance.GetPropertyByName(text);
							if (propertyByName != null)
							{
								KurotatoProperty value2 = propertyByName.Value;
								float num = 0f;
								float.TryParse(s, out num);
								string str = ConfigMultiTextLang.GetLocalTextNew(value2.ShowName, null) ?? value2.ShowName;
								string propertyShowValue = KurotatoUtil.GetPropertyShowValue(value2.Id, Math.Abs(num));
								string text2 = KurotatoUtil.GetItemAttrValueStr(num, propertyShowValue, colorBySign);
								if (!colorBySign && colorCompare)
								{
									text2 = KurotatoUtil.WrapAttrValueColor(text2, num, (float)value2.BasicValue);
								}
								string text3 = showName ? (str + " " + text2) : text2;
								list.Add(new KurotatoAttrDisplay
								{
									Icon = value2.Icon,
									Text = text3,
									PropertyId = value2.Id
								});
							}
						}
					}
				}
			}
			return list;
		}

		// Token: 0x0603A948 RID: 239944 RVA: 0x00ED55A8 File Offset: 0x00ED37A8
		private static string GetItemAttrValueStr(float amount, string showValue, bool colorBySign)
		{
			if (!colorBySign)
			{
				return ((amount >= 0f) ? "+" : "-") + showValue;
			}
			if (amount > 0f)
			{
				DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(16, 2);
				defaultInterpolatedStringHandler.AppendLiteral("<color=");
				defaultInterpolatedStringHandler.AppendFormatted("#31dea7");
				defaultInterpolatedStringHandler.AppendLiteral(">");
				defaultInterpolatedStringHandler.AppendFormatted(showValue);
				defaultInterpolatedStringHandler.AppendLiteral("</color>");
				return defaultInterpolatedStringHandler.ToStringAndClear();
			}
			if (amount < 0f)
			{
				DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(17, 2);
				defaultInterpolatedStringHandler.AppendLiteral("<color=");
				defaultInterpolatedStringHandler.AppendFormatted("#f53864");
				defaultInterpolatedStringHandler.AppendLiteral(">-");
				defaultInterpolatedStringHandler.AppendFormatted(showValue);
				defaultInterpolatedStringHandler.AppendLiteral("</color>");
				return defaultInterpolatedStringHandler.ToStringAndClear();
			}
			return showValue;
		}

		// Token: 0x0603A949 RID: 239945 RVA: 0x00ED5678 File Offset: 0x00ED3878
		public static List<IKurotatoAttrDisplay> GetItemAttrPreviewList(IReadOnlyList<int> effectIdList)
		{
			List<IKurotatoAttrDisplay> list = new List<IKurotatoAttrDisplay>();
			foreach (IKurotatoAttrDisplay kurotatoAttrDisplay in KurotatoUtil.GetItemAttrDisplayList(effectIdList, false, false, false))
			{
				list.Add(new KurotatoAttrDisplay
				{
					Icon = kurotatoAttrDisplay.Icon,
					Text = KurotatoUtil.WrapPreviewSignColor(kurotatoAttrDisplay.Text),
					PropertyId = kurotatoAttrDisplay.PropertyId
				});
			}
			return list;
		}

		// Token: 0x0603A94A RID: 239946 RVA: 0x00ED5704 File Offset: 0x00ED3904
		private static string WrapPreviewSignColor(string signedValueStr)
		{
			string value = signedValueStr.StartsWith("-") ? "#f53864" : "#31dea7";
			DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(16, 2);
			defaultInterpolatedStringHandler.AppendLiteral("<color=");
			defaultInterpolatedStringHandler.AppendFormatted(value);
			defaultInterpolatedStringHandler.AppendLiteral(">");
			defaultInterpolatedStringHandler.AppendFormatted(signedValueStr);
			defaultInterpolatedStringHandler.AppendLiteral("</color>");
			return defaultInterpolatedStringHandler.ToStringAndClear();
		}

		// Token: 0x0603A94B RID: 239947 RVA: 0x00ED5770 File Offset: 0x00ED3970
		[return: TupleElementNames(new string[]
		{
			"PropertyId",
			"LockValue"
		})]
		[return: Nullable(new byte[]
		{
			1,
			0
		})]
		public static List<ValueTuple<int, int>> GetItemAttrLockPreviewList(IReadOnlyList<int> effectIdList)
		{
			List<ValueTuple<int, int>> list = new List<ValueTuple<int, int>>();
			KurotatoConfig instance = ConfigBase<KurotatoConfig>.Instance;
			foreach (int effectId in effectIdList)
			{
				KurotatoEffect? effectById = instance.GetEffectById(effectId);
				if (effectById != null)
				{
					KurotatoEffect value = effectById.Value;
					if (value.DisableShow != 1 && !(value.Type != "LockProp"))
					{
						string text = KurotatoUtil.ParseParamValue(value.Param1 ?? "", "Prop");
						string s = KurotatoUtil.ParseParamValue(value.Param2 ?? "", "Value");
						if (!string.IsNullOrEmpty(text))
						{
							KurotatoProperty? propertyByName = instance.GetPropertyByName(text);
							if (propertyByName != null)
							{
								KurotatoProperty value2 = propertyByName.Value;
								int item;
								int.TryParse(s, out item);
								list.Add(new ValueTuple<int, int>(value2.Id, item));
							}
						}
					}
				}
			}
			return list;
		}

		// Token: 0x0603A94C RID: 239948 RVA: 0x00ED5880 File Offset: 0x00ED3A80
		public static string GetCardDesc(string desc, IReadOnlyList<string> descParams, int weaponId = 0, int weaponIncId = 0, bool colorCompare = false)
		{
			if (string.IsNullOrEmpty(desc))
			{
				return "";
			}
			string inString = ConfigMultiTextLang.GetLocalTextNew(desc, null) ?? "";
			List<string> list = new List<string>();
			foreach (string text in descParams)
			{
				if (text.StartsWith("GS"))
				{
					int num = int.Parse(text.Substring(2));
					KurotatoFormula? formulaById = ConfigBase<KurotatoConfig>.Instance.GetFormulaById(num);
					int num2 = (formulaById != null) ? formulaById.GetValueOrDefault().Precision : 0;
					float formulaResult = KurotatoFormulaUtil.GetFormulaResult(num, weaponId, weaponIncId);
					string text2 = (num2 > 0) ? formulaResult.ToString("F" + num2.ToString()) : formulaResult.ToString();
					if (colorCompare && weaponIncId > 0)
					{
						float formulaResult2 = KurotatoFormulaUtil.GetFormulaResult(num, weaponId, 0);
						if (formulaResult > formulaResult2)
						{
							List<string> list2 = list;
							DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(16, 2);
							defaultInterpolatedStringHandler.AppendLiteral("<color=");
							defaultInterpolatedStringHandler.AppendFormatted("#31dea7");
							defaultInterpolatedStringHandler.AppendLiteral(">");
							defaultInterpolatedStringHandler.AppendFormatted(text2);
							defaultInterpolatedStringHandler.AppendLiteral("</color>");
							list2.Add(defaultInterpolatedStringHandler.ToStringAndClear());
						}
						else if (formulaResult < formulaResult2)
						{
							List<string> list3 = list;
							DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(16, 2);
							defaultInterpolatedStringHandler.AppendLiteral("<color=");
							defaultInterpolatedStringHandler.AppendFormatted("#f53864");
							defaultInterpolatedStringHandler.AppendLiteral(">");
							defaultInterpolatedStringHandler.AppendFormatted(text2);
							defaultInterpolatedStringHandler.AppendLiteral("</color>");
							list3.Add(defaultInterpolatedStringHandler.ToStringAndClear());
						}
						else
						{
							list.Add(text2);
						}
					}
					else
					{
						list.Add(text2);
					}
				}
				else if (text.StartsWith("TB"))
				{
					int propertyId = int.Parse(text.Substring(2));
					KurotatoProperty? propertyById = ConfigBase<KurotatoConfig>.Instance.GetPropertyById(propertyId);
					list.Add((!string.IsNullOrEmpty((propertyById != null) ? propertyById.GetValueOrDefault().Icon : null)) ? ("<texture=" + propertyById.Value.Icon + ",0.3/>") : "");
				}
				else
				{
					list.Add(text);
				}
			}
			return StringUtils.Format(inString, list.ToArray());
		}

		// Token: 0x0603A94D RID: 239949 RVA: 0x00ED5AEC File Offset: 0x00ED3CEC
		public static List<IKurotatoAttrDisplay> GetWeaponPropertyDisplayList(IReadOnlyList<int> showPropertyIds, int weaponId, int weaponIncId = 0)
		{
			List<IKurotatoAttrDisplay> list = new List<IKurotatoAttrDisplay>();
			KurotatoConfig instance = ConfigBase<KurotatoConfig>.Instance;
			KurotatoWeaponGroup? weaponGroupConfigByWeaponId = instance.GetWeaponGroupConfigByWeaponId(weaponId);
			foreach (int propertyId in showPropertyIds)
			{
				KurotatoProperty? propertyById = instance.GetPropertyById(propertyId);
				if (propertyById != null)
				{
					KurotatoProperty value = propertyById.Value;
					string weaponPropertyDesc = value.WeaponPropertyDesc;
					if (!string.IsNullOrEmpty(weaponPropertyDesc))
					{
						List<string> list2 = new List<string>();
						foreach (string item in value.WeaponPropertyDescParamIter())
						{
							list2.Add(item);
						}
						if (!KurotatoUtil.ShouldHideWeaponPropertyByFormulaZero(value.Id, list2, weaponId, weaponIncId))
						{
							string text = KurotatoUtil.GetCardDesc(weaponPropertyDesc, list2, weaponId, weaponIncId, true);
							if (value.Id == 136 && weaponGroupConfigByWeaponId != null)
							{
								string weaponTypeDescSuffixByWeaponType = KurotatoUtil.GetWeaponTypeDescSuffixByWeaponType((EKurotatoWeaponType)weaponGroupConfigByWeaponId.Value.Type);
								if (!string.IsNullOrEmpty(weaponTypeDescSuffixByWeaponType))
								{
									text = text + " " + weaponTypeDescSuffixByWeaponType;
								}
							}
							list.Add(new KurotatoAttrDisplay
							{
								Icon = value.Icon,
								Text = text,
								PropertyId = value.Id
							});
						}
					}
				}
			}
			return list;
		}

		// Token: 0x0603A94E RID: 239950 RVA: 0x00ED5C78 File Offset: 0x00ED3E78
		private static bool ShouldHideWeaponPropertyByFormulaZero(int propertyId, IReadOnlyList<string> descParams, int weaponId, int weaponIncId)
		{
			if (propertyId - 139 > 1 && propertyId != 151)
			{
				return false;
			}
			if (descParams.Count != 1)
			{
				return false;
			}
			string text = descParams[0];
			return !string.IsNullOrEmpty(text) && text.StartsWith("GS") && KurotatoFormulaUtil.GetFormulaResult(int.Parse(text.Substring(2)), weaponId, weaponIncId) == 0f;
		}

		// Token: 0x0603A94F RID: 239951 RVA: 0x00ED5CDD File Offset: 0x00ED3EDD
		private static string GetWeaponTypeDescSuffixByWeaponType(EKurotatoWeaponType weaponGroupType)
		{
			if (weaponGroupType == EKurotatoWeaponType.Melee)
			{
				return ConfigMultiTextLang.GetLocalTextNew("KurotatoWeaponType_1", null) ?? "";
			}
			if (weaponGroupType != EKurotatoWeaponType.Ranged)
			{
				return "";
			}
			return ConfigMultiTextLang.GetLocalTextNew("KurotatoWeaponType_2", null) ?? "";
		}

		// Token: 0x0603A950 RID: 239952 RVA: 0x00ED5D18 File Offset: 0x00ED3F18
		private static string ParseParamValue(string param, string key)
		{
			if (string.IsNullOrEmpty(param))
			{
				return "";
			}
			string text = key + ":";
			if (param.StartsWith(text))
			{
				return param.Substring(text.Length);
			}
			return "";
		}

		// Token: 0x0603A951 RID: 239953 RVA: 0x00ED5D5C File Offset: 0x00ED3F5C
		[CompilerGenerated]
		internal static string <GetPropertyShowValue>g__CeilToPrecision|2_0(float n, ref KurotatoUtil.<>c__DisplayClass2_0 A_1)
		{
			return (Math.Ceiling((double)(n * A_1.factor)) / (double)A_1.factor).ToString("F" + A_1.precision.ToString());
		}
	}
}
