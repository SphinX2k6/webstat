using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using Aki.Config;
using Aki.TDConfigMgr.Action;

namespace CSharpScript.Game.Module.PhoneMessage
{
	// Token: 0x0200544D RID: 21581
	[NullableContext(1)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	[Config(0)]
	public class PhoneMsgConfig : ConfigBase<PhoneMsgConfig>
	{
		// Token: 0x0603700D RID: 225293 RVA: 0x00DF61A3 File Offset: 0x00DF43A3
		public ShortMessage? GetPhoneMsgConfig(int shortMessageId)
		{
			return ConfigShortMessageById.GetConfig(shortMessageId, true);
		}

		// Token: 0x0603700E RID: 225294 RVA: 0x00DF61AC File Offset: 0x00DF43AC
		public ChatPartner? GetChatPartnerConfig(int partnerId)
		{
			return ConfigChatPartnerById.GetConfig(partnerId, true);
		}

		// Token: 0x0603700F RID: 225295 RVA: 0x00DF61B5 File Offset: 0x00DF43B5
		public ChatBg? GetChatBgConfig(int bgId)
		{
			return ConfigChatBgById.GetConfig(bgId, true);
		}

		// Token: 0x06037010 RID: 225296 RVA: 0x00DF61BE File Offset: 0x00DF43BE
		[NullableContext(2)]
		public IReadOnlyList<ChatBg> GetAllChatBgConfigList()
		{
			return ConfigChatBgAll.GetConfigList(true);
		}

		// Token: 0x06037011 RID: 225297 RVA: 0x00DF61C6 File Offset: 0x00DF43C6
		public ChatDialog? GetChatDialogConfig(int dialogId)
		{
			return ConfigChatDialogById.GetConfig(dialogId, true);
		}

		// Token: 0x06037012 RID: 225298 RVA: 0x00DF61CF File Offset: 0x00DF43CF
		[NullableContext(2)]
		public IReadOnlyList<ChatDialog> GetAllChatDialogConfigList()
		{
			return ConfigChatDialogAll.GetConfigList(true);
		}

		// Token: 0x06037013 RID: 225299 RVA: 0x00DF61D7 File Offset: 0x00DF43D7
		public PhoneInputTime? GetPhoneInputTimeConfig(int id)
		{
			return ConfigPhoneInputTimeById.GetConfig(id, true);
		}

		// Token: 0x06037014 RID: 225300 RVA: 0x00DF61E0 File Offset: 0x00DF43E0
		public ShortMessage? GetShortMessageConfigByPlayFlow(PlayFlow playFlow)
		{
			string flowListName = playFlow.FlowListName;
			int flowId = playFlow.FlowId;
			int stateId = playFlow.StateId;
			IReadOnlyList<ShortMessage> configList = ConfigShortMessageByAll.GetConfigList(true);
			if (configList != null)
			{
				foreach (ShortMessage value in configList)
				{
					string[] array = value.FlowParam();
					if (array.Length == 3)
					{
						string text = array[0];
						string text2 = array[1];
						string text3 = array[2];
						if (text.Length > 0 && text2.Length > 0 && text3.Length > 0 && text == flowListName && int.Parse(text2) == flowId && int.Parse(text3) == stateId)
						{
							return new ShortMessage?(value);
						}
					}
				}
			}
			return null;
		}

		// Token: 0x06037015 RID: 225301 RVA: 0x00DF62C0 File Offset: 0x00DF44C0
		public ChatFilterType? GetChatFilterTypeConfig(int filterTypeId)
		{
			return ConfigChatFilterTypeById.GetConfig(filterTypeId, true);
		}

		// Token: 0x06037016 RID: 225302 RVA: 0x00DF62C9 File Offset: 0x00DF44C9
		public IEnumerable<ChatFilterType> GetAllChatFilterTypeConfigList()
		{
			return ConfigChatFilterTypeAll.GetConfigList(true);
		}

		// Token: 0x06037017 RID: 225303 RVA: 0x00DF62D1 File Offset: 0x00DF44D1
		public ChatPartnerFilter? GetChatPartnerFilterConfig(int filterId)
		{
			return ConfigChatPartnerFilterById.GetConfig(filterId, true);
		}

		// Token: 0x06037018 RID: 225304 RVA: 0x00DF62DC File Offset: 0x00DF44DC
		public IEnumerable<ChatPartnerFilter> GetChatPartnerFilterConfigListByFilterType(int filterTypeId)
		{
			IReadOnlyList<ChatPartnerFilter> configList = ConfigChatPartnerFilterAll.GetConfigList(true);
			if (configList == null)
			{
				return Enumerable.Empty<ChatPartnerFilter>();
			}
			List<ChatPartnerFilter> list = new List<ChatPartnerFilter>();
			foreach (ChatPartnerFilter item in configList)
			{
				if (item.Type == filterTypeId)
				{
					list.Add(item);
				}
			}
			list.Sort((ChatPartnerFilter a, ChatPartnerFilter b) => a.SortId.CompareTo(b.SortId));
			return list;
		}

		// Token: 0x06037019 RID: 225305 RVA: 0x00DF636C File Offset: 0x00DF456C
		public IEnumerable<ChatPartnerFilter> GetAllChatPartnerFilterConfigList()
		{
			IEnumerable<ChatPartnerFilter> configList = ConfigChatPartnerFilterAll.GetConfigList(true);
			return configList ?? Enumerable.Empty<ChatPartnerFilter>();
		}
	}
}
