using System;

namespace CSharpScript.Game.Module.Activity.ActivityContent.Roverlike
{
	// Token: 0x0200646F RID: 25711
	public static class ERoverActionSubViewTypeExtensions
	{
		// Token: 0x060407EC RID: 264172 RVA: 0x01087384 File Offset: 0x01085584
		public static string ToEnumString(this ERoverActionSubViewType value)
		{
			string result;
			switch (value)
			{
			case ERoverActionSubViewType.None:
				result = "None";
				break;
			case ERoverActionSubViewType.BlessingSuitPreview:
				result = "BlessingSuitPreview";
				break;
			case ERoverActionSubViewType.BlessingSuitSelect:
				result = "BlessingSuitSelect";
				break;
			case ERoverActionSubViewType.SelectBlessing:
				result = "SelectBlessing";
				break;
			case ERoverActionSubViewType.SelectReinforcement:
				result = "SelectReinforcement";
				break;
			case ERoverActionSubViewType.SelectEvent:
				result = "SelectEvent";
				break;
			case ERoverActionSubViewType.BlessingReinforcement:
				result = "BlessingReinforcement";
				break;
			default:
				result = value.ToString();
				break;
			}
			return result;
		}

		// Token: 0x060407ED RID: 264173 RVA: 0x010873FC File Offset: 0x010855FC
		public static ERoverActionSubViewType FromString(string name)
		{
			ERoverActionSubViewType result;
			if (!ERoverActionSubViewTypeExtensions.TryFromString(name, out result))
			{
				throw new InvalidCastException("从字符串转成枚举 ERoverActionSubViewType 失败, 字符串: " + name);
			}
			return result;
		}

		// Token: 0x060407EE RID: 264174 RVA: 0x01087428 File Offset: 0x01085628
		public static bool TryFromString(string name, out ERoverActionSubViewType value)
		{
			if (string.IsNullOrEmpty(name))
			{
				value = ERoverActionSubViewType.None;
				return false;
			}
			if (name != null)
			{
				int length = name.Length;
				if (length <= 11)
				{
					if (length != 4)
					{
						if (length == 11)
						{
							if (name == "SelectEvent")
							{
								value = ERoverActionSubViewType.SelectEvent;
								return true;
							}
						}
					}
					else if (name == "None")
					{
						value = ERoverActionSubViewType.None;
						return true;
					}
				}
				else if (length != 14)
				{
					switch (length)
					{
					case 18:
						if (name == "BlessingSuitSelect")
						{
							value = ERoverActionSubViewType.BlessingSuitSelect;
							return true;
						}
						break;
					case 19:
					{
						char c = name[0];
						if (c != 'B')
						{
							if (c == 'S')
							{
								if (name == "SelectReinforcement")
								{
									value = ERoverActionSubViewType.SelectReinforcement;
									return true;
								}
							}
						}
						else if (name == "BlessingSuitPreview")
						{
							value = ERoverActionSubViewType.BlessingSuitPreview;
							return true;
						}
						break;
					}
					case 21:
						if (name == "BlessingReinforcement")
						{
							value = ERoverActionSubViewType.BlessingReinforcement;
							return true;
						}
						break;
					}
				}
				else if (name == "SelectBlessing")
				{
					value = ERoverActionSubViewType.SelectBlessing;
					return true;
				}
			}
			value = ERoverActionSubViewType.None;
			return false;
		}

		// Token: 0x060407EF RID: 264175 RVA: 0x0108752F File Offset: 0x0108572F
		public static string[] GetStringValues()
		{
			return new string[]
			{
				"None",
				"BlessingSuitPreview",
				"BlessingSuitSelect",
				"SelectBlessing",
				"SelectReinforcement",
				"SelectEvent",
				"BlessingReinforcement"
			};
		}

		// Token: 0x060407F0 RID: 264176 RVA: 0x0108756F File Offset: 0x0108576F
		public static ERoverActionSubViewType[] GetValues()
		{
			return new ERoverActionSubViewType[]
			{
				ERoverActionSubViewType.None,
				ERoverActionSubViewType.BlessingSuitPreview,
				ERoverActionSubViewType.BlessingSuitSelect,
				ERoverActionSubViewType.SelectBlessing,
				ERoverActionSubViewType.SelectReinforcement,
				ERoverActionSubViewType.SelectEvent,
				ERoverActionSubViewType.BlessingReinforcement
			};
		}

		// Token: 0x060407F1 RID: 264177 RVA: 0x01087582 File Offset: 0x01085782
		public static string[] GetNames()
		{
			return new string[]
			{
				"None",
				"BlessingSuitPreview",
				"BlessingSuitSelect",
				"SelectBlessing",
				"SelectReinforcement",
				"SelectEvent",
				"BlessingReinforcement"
			};
		}
	}
}
