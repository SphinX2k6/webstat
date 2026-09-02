using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using Aki.Config;
using Aki.Protocol;
using CSharpScript.Game.Common;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.Inventory;

// Token: 0x02002224 RID: 8740
[NullableContext(1)]
[Nullable(new byte[]
{
	0,
	1
})]
[Model(0)]
public class MailModel : ModelBase<MailModel>
{
	// Token: 0x060107E9 RID: 67561 RVA: 0x00481538 File Offset: 0x0047F738
	public int GetFavoriteMailCount()
	{
		int num = 0;
		using (Dictionary<string, MailData>.ValueCollection.Enumerator enumerator = this.MailMap.Values.GetEnumerator())
		{
			while (enumerator.MoveNext())
			{
				if (enumerator.Current.IsFavorite)
				{
					num++;
				}
			}
		}
		return num;
	}

	// Token: 0x060107EA RID: 67562 RVA: 0x00481598 File Offset: 0x0047F798
	public int GetFavoriteMailCapacity()
	{
		return ConfigBase<MailConfig>.Instance.GetFavoriteMailSize().GetValueOrDefault();
	}

	// Token: 0x060107EB RID: 67563 RVA: 0x004815B7 File Offset: 0x0047F7B7
	public bool IsFavoriteMailFull()
	{
		return this.GetFavoriteMailCount() >= this.GetFavoriteMailCapacity();
	}

	// Token: 0x060107EC RID: 67564 RVA: 0x004815CC File Offset: 0x0047F7CC
	public bool IsFavoriteMailSpaceNearFull()
	{
		double favoriteMailCapacity = (double)this.GetFavoriteMailCapacity();
		int mailSpaceWarningThresholdRate = ConfigBase<MailConfig>.Instance.GetMailSpaceWarningThresholdRate();
		int num = (int)Math.Floor(favoriteMailCapacity * (double)mailSpaceWarningThresholdRate / 100.0);
		return this.GetFavoriteMailCount() >= num;
	}

	// Token: 0x060107ED RID: 67565 RVA: 0x0048160A File Offset: 0x0047F80A
	public bool IsMailFavorite(string mailId)
	{
		MailData mailInstanceById = this.GetMailInstanceById(mailId);
		return mailInstanceById != null && mailInstanceById.IsFavorite;
	}

	// Token: 0x060107EE RID: 67566 RVA: 0x0048161E File Offset: 0x0047F81E
	public int GetMailSpaceWarningThreshold()
	{
		return ConfigBase<MailConfig>.Instance.GetMailSpaceWarningThreshold();
	}

	// Token: 0x060107EF RID: 67567 RVA: 0x0048162A File Offset: 0x0047F82A
	public bool IsMailSpaceNearFull()
	{
		return this.GetMailListLength() >= this.GetMailSpaceWarningThreshold();
	}

	// Token: 0x060107F0 RID: 67568 RVA: 0x0048163D File Offset: 0x0047F83D
	public bool CanRequestMailFavorite(string mailId, bool isFavorite)
	{
		if (this.GetMailInstanceById(mailId) == null)
		{
			return false;
		}
		if (isFavorite)
		{
			if (this.IsMailFavorite(mailId))
			{
				return false;
			}
			if (this.IsFavoriteMailFull())
			{
				return false;
			}
		}
		else if (!this.IsMailFavorite(mailId))
		{
			return false;
		}
		return true;
	}

	// Token: 0x060107F1 RID: 67569 RVA: 0x00481670 File Offset: 0x0047F870
	public void ApplyMailFavoriteResponse(string mailId, bool isFavorite, int state, long expiryTime)
	{
		MailData mailInstanceById = this.GetMailInstanceById(mailId);
		if (mailInstanceById == null)
		{
			return;
		}
		if (isFavorite && mailInstanceById.IsIntervalMail)
		{
			mailInstanceById.IntervalExpiryTime = mailInstanceById.ExpiryTime;
		}
		mailInstanceById.ExpiryTime = expiryTime;
		this.SetMailStatusByStatusCode(state, mailInstanceById);
		Singleton<EventSystem>.Instance.Emit<string, bool>(EEventName.MailFavoriteChanged, mailId, isFavorite);
	}

	// Token: 0x060107F2 RID: 67570 RVA: 0x004816C4 File Offset: 0x0047F8C4
	private void UpdateUnFinishedMailCountByMail(MailData mail)
	{
		if (!mail.GetWasScanned() || mail.GetAttachmentStatus() == EMailAttachment.AttachmentRemained)
		{
			if (this.UnFinishedMailSet.Contains(mail.Id))
			{
				Singleton<EventSystem>.Instance.Emit(EEventName.SwitchUnfinishedFlag);
				return;
			}
			this.UnFinishedMailSet.Add(mail.Id);
		}
		else
		{
			if (!this.UnFinishedMailSet.Contains(mail.Id))
			{
				Singleton<EventSystem>.Instance.Emit(EEventName.SwitchUnfinishedFlag);
				return;
			}
			this.UnFinishedMailSet.Remove(mail.Id);
		}
		Singleton<EventSystem>.Instance.Emit(EEventName.SwitchUnfinishedFlag);
	}

	// Token: 0x060107F3 RID: 67571 RVA: 0x00481760 File Offset: 0x0047F960
	public bool GetRedDotCouldLightOn()
	{
		return this.UnFinishedMailSet.Count > 0 && this.CheckOpenCondition();
	}

	// Token: 0x060107F4 RID: 67572 RVA: 0x00481778 File Offset: 0x0047F978
	public bool UnScannedRedPoint()
	{
		if (!this.CheckOpenCondition())
		{
			return false;
		}
		bool result = false;
		if (this.MailMap.Count > 0)
		{
			using (Dictionary<string, MailData>.ValueCollection.Enumerator enumerator = this.MailMap.Values.GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					if (!enumerator.Current.GetWasScanned())
					{
						result = true;
						break;
					}
				}
			}
		}
		return result;
	}

	// Token: 0x060107F5 RID: 67573 RVA: 0x004817F0 File Offset: 0x0047F9F0
	public bool GetRedDotImportant()
	{
		if (!this.CheckOpenCondition())
		{
			return false;
		}
		bool result = false;
		if (this.UnFinishedMailSet.Count > 0)
		{
			foreach (string id in this.UnFinishedMailSet)
			{
				if (this.GetMailInstanceById(id).GetMailLevel() == 2)
				{
					result = true;
					break;
				}
			}
		}
		return result;
	}

	// Token: 0x060107F6 RID: 67574 RVA: 0x0048186C File Offset: 0x0047FA6C
	public List<TItem> GetLastPickedAttachments()
	{
		List<TItem> list = new List<TItem>();
		foreach (MailAttachmentData mailAttachmentData in this.LastPickedAttachments)
		{
			InventoryDefine.IGetItemData itemData = new InventoryDefine.GetItemData(mailAttachmentData.GetItemId(), 0);
			TItem item = new TItem(itemData, mailAttachmentData.GetCount());
			list.Add(item);
		}
		return list;
	}

	// Token: 0x060107F7 RID: 67575 RVA: 0x004818E4 File Offset: 0x0047FAE4
	public void SetLastPickedAttachments(Dictionary<string, int> successIdMap, EMailAttachmentPickType pickType)
	{
		this.ClearLastPickedAttachments();
		Dictionary<int, int> dictionary = new Dictionary<int, int>();
		foreach (string text in successIdMap.Keys)
		{
			MailData mailInstanceById = this.GetMailInstanceById(text);
			foreach (PbMailAttachment pbMailAttachment in mailInstanceById.GetAttachmentInfo())
			{
				int? num = dictionary.ContainsKey(pbMailAttachment.Id) ? new int?(dictionary[pbMailAttachment.Id]) : null;
				int value = pbMailAttachment.Count + num.GetValueOrDefault();
				dictionary[pbMailAttachment.Id] = value;
			}
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.Mail;
			ELogAuthor author = ELogAuthor.YZY;
			string message = "邮件数据：领取邮件奖励";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("key", text);
			instance.Info(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			this.SetMailStatusByStatusCode(successIdMap[text], mailInstanceById);
		}
		foreach (KeyValuePair<int, int> keyValuePair in dictionary)
		{
			this.LastPickedAttachments.Add(new MailAttachmentData(keyValuePair.Key, keyValuePair.Value, true));
		}
		Singleton<EventSystem>.Instance.Emit<EMailAttachmentPickType>(EEventName.PickingAttachment, pickType);
	}

	// Token: 0x060107F8 RID: 67576 RVA: 0x00481A5C File Offset: 0x0047FC5C
	public void ClearLastPickedAttachments()
	{
		this.LastPickedAttachments.Clear();
	}

	// Token: 0x060107F9 RID: 67577 RVA: 0x00481A69 File Offset: 0x0047FC69
	public string GetCurrentSelectMailId()
	{
		return this.CurrentSelectMailId;
	}

	// Token: 0x060107FA RID: 67578 RVA: 0x00481A71 File Offset: 0x0047FC71
	public void SetCurrentSelectMailId(string newMailId)
	{
		this.CurrentSelectMailId = newMailId;
	}

	// Token: 0x060107FB RID: 67579 RVA: 0x00481A7A File Offset: 0x0047FC7A
	public void OpenWebBrowser(string url)
	{
		if (string.IsNullOrEmpty(url))
		{
			return;
		}
		ControllerBase<KuroSdkController>.Instance.OpenExternalUrl(url);
	}

	// Token: 0x060107FC RID: 67580 RVA: 0x00481A90 File Offset: 0x0047FC90
	private int MailSort(MailData mailDataA, MailData mailDataB)
	{
		if (mailDataA.GetWasScanned() != mailDataB.GetWasScanned())
		{
			if (!mailDataA.GetWasScanned())
			{
				return -1;
			}
			return 1;
		}
		else if (mailDataA.GetAttachmentStatus() != mailDataB.GetAttachmentStatus())
		{
			if (mailDataA.GetAttachmentStatus() >= mailDataB.GetAttachmentStatus())
			{
				return -1;
			}
			return 1;
		}
		else if (mailDataA.GetMailLevel() != mailDataB.GetMailLevel())
		{
			if (mailDataA.GetMailLevel() >= mailDataB.GetMailLevel())
			{
				return -1;
			}
			return 1;
		}
		else
		{
			if (mailDataA.GetReceiveTime() == mailDataB.GetReceiveTime())
			{
				return 1;
			}
			if (mailDataA.GetReceiveTime() >= mailDataB.GetReceiveTime())
			{
				return -1;
			}
			return 1;
		}
	}

	// Token: 0x060107FD RID: 67581 RVA: 0x00481B18 File Offset: 0x0047FD18
	public void ReloadMailList()
	{
		this.MailList.Clear();
		foreach (MailData item in this.MailMap.Values)
		{
			this.MailList.Add(item);
		}
		List<MailData> collection = this.MailList.OrderBy((MailData mail) => mail, Comparer<MailData>.Create(new Comparison<MailData>(this.MailSort))).ToList<MailData>();
		this.MailList.Clear();
		this.MailList.AddRange(collection);
	}

	// Token: 0x060107FE RID: 67582 RVA: 0x00481BD8 File Offset: 0x0047FDD8
	public List<MailData> GetMailList()
	{
		return this.MailList;
	}

	// Token: 0x060107FF RID: 67583 RVA: 0x00481BE0 File Offset: 0x0047FDE0
	private void SetValueOfMailList(MailData mail)
	{
		this.MailMap[mail.Id] = mail;
	}

	// Token: 0x06010800 RID: 67584 RVA: 0x00481BF4 File Offset: 0x0047FDF4
	public void DeleteMail(string mailId)
	{
		if (this.GetMailInstanceById(mailId) == null)
		{
			return;
		}
		if (this.UnFinishedMailSet.Contains(mailId))
		{
			this.UnFinishedMailSet.Remove(mailId);
			Singleton<EventSystem>.Instance.Emit(EEventName.SwitchUnfinishedFlag);
		}
		this.MailMap.Remove(mailId);
		this.ReloadMailList();
	}

	// Token: 0x06010801 RID: 67585 RVA: 0x00481C49 File Offset: 0x0047FE49
	public int GetMailListLength()
	{
		return this.MailMap.Count;
	}

	// Token: 0x06010802 RID: 67586 RVA: 0x00481C58 File Offset: 0x0047FE58
	public MailData GetMailInstanceById(string id)
	{
		MailData result;
		this.MailMap.TryGetValue(id, out result);
		return result;
	}

	// Token: 0x06010803 RID: 67587 RVA: 0x00481C78 File Offset: 0x0047FE78
	public void AddMail(PbMailInfo mailInfo, bool reloadList = true)
	{
		if (this.MailMap.Count >= this.GetMailCapacity())
		{
			Singleton<Log>.Instance.Error(ELogModule.Mail, ELogAuthor.YZY, "后端新增邮件时超出容量！", default(ReadOnlySpan<ValueTuple<string, object>>));
		}
		this.MakeMailInstance(mailInfo);
		if (reloadList)
		{
			this.ReloadMailList();
		}
	}

	// Token: 0x06010804 RID: 67588 RVA: 0x00481CC4 File Offset: 0x0047FEC4
	public void OnMailInfoSynced(MailInfosNotify response)
	{
		foreach (PbMailInfo other in response.MailInfos)
		{
			if (ModelBase<MailModel>.Instance.GetMailListLength() >= ModelBase<MailModel>.Instance.GetMailCapacity())
			{
				Singleton<Log>.Instance.Error(ELogModule.Mail, ELogAuthor.YZY, "[MailError]MailBox is fulfilled", default(ReadOnlySpan<ValueTuple<string, object>>));
			}
			PbMailInfo pbMailInfo = PbMailInfo.Create();
			pbMailInfo.MergeFrom(other);
			this.AddMail(pbMailInfo, false);
		}
		this.ReloadMailList();
	}

	// Token: 0x06010805 RID: 67589 RVA: 0x00481D58 File Offset: 0x0047FF58
	public int GetMailCapacity()
	{
		if (this.MailCapacity != null)
		{
			return this.MailCapacity.Value;
		}
		int? mailSize = ConfigBase<MailConfig>.Instance.GetMailSize();
		int? num = mailSize;
		int num2 = 0;
		if (num.GetValueOrDefault() > num2 & num != null)
		{
			this.MailCapacity = mailSize;
			return this.MailCapacity.Value;
		}
		return 0;
	}

	// Token: 0x06010806 RID: 67590 RVA: 0x00481DB8 File Offset: 0x0047FFB8
	private string GenerateOverLimitMailIdSuffix(long timeStamp)
	{
		DateTime localDateTime = DateTimeOffset.FromUnixTimeMilliseconds(timeStamp * (long)Singleton<TimeUtil>.Instance.InverseMillisecond).LocalDateTime;
		string text = Singleton<TimeUtil>.Instance.DateFormat4(localDateTime);
		int num = 1;
		if (this.DayToSpecialMailCount.ContainsKey(text))
		{
			num = this.DayToSpecialMailCount[text];
			num++;
		}
		this.DayToSpecialMailCount[text] = num;
		string str = this.FormatIdStringByLength(num, 3);
		return " " + text + " " + str;
	}

	// Token: 0x06010807 RID: 67591 RVA: 0x00481E38 File Offset: 0x00480038
	private string FormatIdStringByLength(int id, int length)
	{
		return (new string('0', length) + ((double)id % Math.Pow(10.0, (double)length)).ToString()).Substring(Math.Max(0, (new string('0', length) + ((double)id % Math.Pow(10.0, (double)length)).ToString()).Length - length));
	}

	// Token: 0x06010808 RID: 67592 RVA: 0x00481EA8 File Offset: 0x004800A8
	private unsafe void MakeMailInstance(PbMailInfo mailInformation)
	{
		Log instance = Singleton<Log>.Instance;
		ELogModule module = ELogModule.Mail;
		ELogAuthor author = ELogAuthor.YZY;
		string message = "邮件数据：创建邮件 ";
		ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("mailInformation.Id", mailInformation.Id);
		instance.Info(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
		int state = mailInformation.State;
		MailData mailData = new MailData();
		ObjectUtils.CopyValue(mailInformation, mailData);
		mailData.Id = mailInformation.Id;
		mailData.ConfigId = mailInformation.ConfigId;
		long receivedTime = mailInformation.ReceivedTime;
		mailData.Time = (int)(receivedTime & (long)((ulong)-1));
		mailData.Level = (int)mailInformation.Level;
		mailData.Title = mailInformation.Title;
		mailData.SetText(mailInformation.Content);
		ConfigBase<MailConfig>.Instance.ApplyTemplateJumpId(mailData);
		mailData.Sender = mailInformation.Sender;
		mailData.ExpiryTime = Singleton<MathUtils>.Instance.LongToBigInt(mailInformation.ExpiryTime);
		mailData.IsIntervalMail = mailInformation.IsIntervalMail;
		mailData.AttachmentInfos = mailInformation.Attachments.ToArray<PbMailAttachment>();
		mailData.ReadTime = Singleton<MathUtils>.Instance.LongToNumber(mailInformation.ReadTime);
		this.AddSpecialMail(mailData);
		this.SetValueOfMailList(mailData);
		this.SetMailStatusByStatusCode(state, mailData);
		if (mailData.IsIntervalMail && !mailData.IsFavorite)
		{
			mailData.IntervalExpiryTime = mailData.ExpiryTime;
		}
		Log instance2 = Singleton<Log>.Instance;
		ELogModule module2 = ELogModule.Mail;
		ELogAuthor author2 = ELogAuthor.YZY;
		string message2 = "邮件数据：创建邮件成功： ";
		<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
		*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("newMail.Id", mailData.Id);
		*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("title", mailData.Title);
		instance2.Info(module2, author2, message2, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
	}

	// Token: 0x06010809 RID: 67593 RVA: 0x00482034 File Offset: 0x00480234
	public bool IfNeedShowNewMail()
	{
		Dictionary<string, bool> dictionary = LocalStorage.GetPlayer<Dictionary<string, bool>>(ELocalStoragePlayerKey.HasShowNewMailTipsMap, null) ?? new Dictionary<string, bool>();
		foreach (KeyValuePair<string, MailData> keyValuePair in this.MailMap)
		{
			bool flag;
			if (keyValuePair.Value.GetIfShowNewMail() && (!dictionary.TryGetValue(keyValuePair.Key, out flag) || !flag))
			{
				return true;
			}
		}
		return false;
	}

	// Token: 0x0601080A RID: 67594 RVA: 0x004820BC File Offset: 0x004802BC
	public void SaveShowNewMailMap()
	{
		Dictionary<string, bool> dictionary = LocalStorage.GetPlayer<Dictionary<string, bool>>(ELocalStoragePlayerKey.HasShowNewMailTipsMap, null) ?? new Dictionary<string, bool>();
		foreach (KeyValuePair<string, MailData> keyValuePair in this.MailMap)
		{
			dictionary[keyValuePair.Key] = true;
		}
		LocalStorage.SetPlayer<Dictionary<string, bool>>(ELocalStoragePlayerKey.HasShowNewMailTipsMap, dictionary);
	}

	// Token: 0x0601080B RID: 67595 RVA: 0x00482134 File Offset: 0x00480334
	public void RefreshLocalNewMailMap()
	{
		Dictionary<string, bool> dictionary = LocalStorage.GetPlayer<Dictionary<string, bool>>(ELocalStoragePlayerKey.HasShowNewMailTipsMap, null) ?? new Dictionary<string, bool>();
		List<string> list = new List<string>();
		foreach (KeyValuePair<string, bool> keyValuePair in dictionary)
		{
			if (!this.MailMap.ContainsKey(keyValuePair.Key))
			{
				list.Add(keyValuePair.Key);
			}
		}
		foreach (string key in list)
		{
			dictionary.Remove(key);
		}
		foreach (KeyValuePair<string, MailData> keyValuePair2 in this.MailMap)
		{
			bool flag;
			if (keyValuePair2.Value.GetIfShowNewMail() && (!dictionary.TryGetValue(keyValuePair2.Key, out flag) || !flag))
			{
				dictionary[keyValuePair2.Key] = false;
			}
		}
		LocalStorage.SetPlayer<Dictionary<string, bool>>(ELocalStoragePlayerKey.HasShowNewMailTipsMap, dictionary);
	}

	// Token: 0x0601080C RID: 67596 RVA: 0x0048226C File Offset: 0x0048046C
	private void AddSpecialMail(MailData mailData)
	{
		EMailConfigType configId = (EMailConfigType)mailData.ConfigId;
		if (configId == EMailConfigType.BackpackOverLimitMail || configId == EMailConfigType.BackpackOverLimitWithCurrencyMail)
		{
			string str = this.GenerateOverLimitMailIdSuffix((long)mailData.Time);
			mailData.Title += str;
		}
	}

	// Token: 0x0601080D RID: 67597 RVA: 0x004822A8 File Offset: 0x004804A8
	public unsafe void SetMailStatusByStatusCode(int state, MailData mailInstance)
	{
		bool flag = (state & 1) != 0;
		bool flag2 = (state & 2) != 0;
		bool favorite = (state & 4) != 0;
		EMailAttachment emailAttachment = EMailAttachment.NoneAttachment;
		if (mailInstance.AttachmentInfos.Length == 0)
		{
			emailAttachment = EMailAttachment.NoneAttachment;
		}
		else if (mailInstance.AttachmentInfos.Length != 0)
		{
			emailAttachment = (flag2 ? EMailAttachment.AttachmentPicked : EMailAttachment.AttachmentRemained);
		}
		mailInstance.SetWasScanned((flag > false) ? 1 : 0);
		mailInstance.SetAttachmentStatus(emailAttachment);
		mailInstance.SetFavorite(favorite);
		this.UpdateUnFinishedMailCountByMail(mailInstance);
		Log instance = Singleton<Log>.Instance;
		ELogModule module = ELogModule.Mail;
		ELogAuthor author = ELogAuthor.YZY;
		string message = "邮件数据：邮件状态改变";
		<>y__InlineArray5<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray5<ValueTuple<string, object>>);
		*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray5<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("SetMailStatusByStatusCode:", emailAttachment);
		*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray5<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("id:", mailInstance.Id);
		*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray5<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 2) = new ValueTuple<string, object>("scanned:", flag);
		*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray5<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 3) = new ValueTuple<string, object>("taken:", flag2);
		ref ValueTuple<string, object> ptr = ref <PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray5<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 4);
		string item = "this.UnFinishedMailSet.length";
		HashSet<string> unFinishedMailSet = this.UnFinishedMailSet;
		ptr = new ValueTuple<string, object>(item, (unFinishedMailSet != null) ? new int?(unFinishedMailSet.Count) : null);
		instance.Info(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray5<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 5));
	}

	// Token: 0x0601080E RID: 67598 RVA: 0x004823DC File Offset: 0x004805DC
	public bool CheckOpenCondition()
	{
		return ModelBase<FunctionModel>.Instance.IsOpen(10020);
	}

	// Token: 0x0601080F RID: 67599 RVA: 0x004823ED File Offset: 0x004805ED
	public MailFilter GetMailFilterConfigData(EMailFilter type)
	{
		return ConfigBase<MailConfig>.Instance.GetMailFilterConfigById((int)type);
	}

	// Token: 0x06010810 RID: 67600 RVA: 0x004823FC File Offset: 0x004805FC
	public List<MailData> GetImportantMails(List<MailData> totalSortedMails = null)
	{
		List<MailData> list = totalSortedMails ?? this.GetMailList();
		List<MailData> list2 = new List<MailData>();
		for (int i = 0; i < list.Count; i++)
		{
			MailData mailData = list[i];
			if (mailData.GetMailLevel() == 2)
			{
				list2.Add(mailData);
			}
		}
		return list2;
	}

	// Token: 0x06010811 RID: 67601 RVA: 0x00482448 File Offset: 0x00480648
	public List<MailData> GetUnScanMails(List<MailData> totalSortedMails = null)
	{
		List<MailData> list = totalSortedMails ?? this.GetMailList();
		List<MailData> list2 = new List<MailData>();
		for (int i = 0; i < list.Count; i++)
		{
			MailData mailData = list[i];
			if (!mailData.GetWasScanned())
			{
				list2.Add(mailData);
			}
		}
		return list2;
	}

	// Token: 0x06010812 RID: 67602 RVA: 0x00482490 File Offset: 0x00480690
	public List<MailData> GetFavoriteMails(List<MailData> totalSortedMails = null)
	{
		List<MailData> list = totalSortedMails ?? this.GetMailList();
		List<MailData> list2 = new List<MailData>();
		for (int i = 0; i < list.Count; i++)
		{
			MailData mailData = list[i];
			if (mailData.IsFavorite)
			{
				list2.Add(mailData);
			}
		}
		return list2;
	}

	// Token: 0x040081D7 RID: 33239
	private const int ID_SHOW_LENGTH = 3;

	// Token: 0x040081D8 RID: 33240
	private Dictionary<string, MailData> MailMap = new Dictionary<string, MailData>();

	// Token: 0x040081D9 RID: 33241
	private List<MailData> MailList = new List<MailData>();

	// Token: 0x040081DA RID: 33242
	private string CurrentSelectMailId = "";

	// Token: 0x040081DB RID: 33243
	private HashSet<string> UnFinishedMailSet = new HashSet<string>();

	// Token: 0x040081DC RID: 33244
	private Dictionary<string, int> DayToSpecialMailCount = new Dictionary<string, int>();

	// Token: 0x040081DD RID: 33245
	public double LastTimeShowNewMailTipsTime;

	// Token: 0x040081DE RID: 33246
	private int? MailCapacity;

	// Token: 0x040081DF RID: 33247
	private List<MailAttachmentData> LastPickedAttachments = new List<MailAttachmentData>();
}
