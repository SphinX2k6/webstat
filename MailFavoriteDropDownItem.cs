using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using UnrealEngine;

// Token: 0x0200222C RID: 8748
[NullableContext(1)]
[Nullable(0)]
public class MailFavoriteDropDownItem : MailDropDownItem
{
	// Token: 0x06010860 RID: 67680 RVA: 0x0048494C File Offset: 0x00482B4C
	public MailFavoriteDropDownItem(UUIItem uiItem) : base(uiItem)
	{
	}

	// Token: 0x06010861 RID: 67681 RVA: 0x00484958 File Offset: 0x00482B58
	public override MailData[] GetFilteredMailList()
	{
		List<MailData> favoriteMails = ModelBase<MailModel>.Instance.GetFavoriteMails(null);
		Log instance = Singleton<Log>.Instance;
		ELogModule module = ELogModule.Mail;
		ELogAuthor author = ELogAuthor.YZY;
		string message = "邮件界面：获取收藏邮件";
		ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("length", (favoriteMails != null) ? new int?(favoriteMails.Count) : null);
		instance.Info(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
		return favoriteMails.ToArray();
	}

	// Token: 0x06010862 RID: 67682 RVA: 0x004849BC File Offset: 0x00482BBC
	public override string GetTitleText()
	{
		int favoriteMailCount = ModelBase<MailModel>.Instance.GetFavoriteMailCount();
		int favoriteMailCapacity = ModelBase<MailModel>.Instance.GetFavoriteMailCapacity();
		if (ModelBase<MailModel>.Instance.IsFavoriteMailSpaceNearFull())
		{
			return StringUtils.Format("<color=#c25757>{0}</color>/{1}", new string[]
			{
				favoriteMailCount.ToString(),
				favoriteMailCapacity.ToString()
			});
		}
		string localTextNew = ConfigMultiTextLang.GetLocalTextNew("Email_Inbox_Number", null);
		if (string.IsNullOrEmpty(localTextNew))
		{
			DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(1, 2);
			defaultInterpolatedStringHandler.AppendFormatted<int>(favoriteMailCount);
			defaultInterpolatedStringHandler.AppendLiteral("/");
			defaultInterpolatedStringHandler.AppendFormatted<int>(favoriteMailCapacity);
			return defaultInterpolatedStringHandler.ToStringAndClear();
		}
		return StringUtils.Format(localTextNew, new string[]
		{
			favoriteMailCount.ToString(),
			favoriteMailCapacity.ToString()
		});
	}

	// Token: 0x06010863 RID: 67683 RVA: 0x00484A71 File Offset: 0x00482C71
	protected override void OnShowDropDownItemBase(MailFilter data)
	{
		Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(1), data.Name, Array.Empty<object>());
		base.SetMailCount(this.GetTitleText());
	}
}
