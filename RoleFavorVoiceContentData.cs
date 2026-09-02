using System;
using System.Runtime.CompilerServices;
using Aki.Config;

// Token: 0x0200284D RID: 10317
[NullableContext(1)]
[Nullable(0)]
public class RoleFavorVoiceContentData : RoleFavorContentDataBase
{
	// Token: 0x06014773 RID: 83827 RVA: 0x005AEA47 File Offset: 0x005ACC47
	public RoleFavorVoiceContentData(int roleId, EFavorVoiceType favorVoiceParamType, FavorWord configData) : base(roleId)
	{
		this.FavorVoiceParamType = favorVoiceParamType;
		this.ConfigData = configData;
	}

	// Token: 0x17001AA4 RID: 6820
	// (get) Token: 0x06014774 RID: 83828 RVA: 0x005AEA65 File Offset: 0x005ACC65
	public override int ConfigId
	{
		get
		{
			return this.ConfigData.Id;
		}
	}

	// Token: 0x17001AA5 RID: 6821
	// (get) Token: 0x06014775 RID: 83829 RVA: 0x005AEA72 File Offset: 0x005ACC72
	public override int ConfigConGroupId
	{
		get
		{
			return this.ConfigData.CondGroupId;
		}
	}

	// Token: 0x17001AA6 RID: 6822
	// (get) Token: 0x06014776 RID: 83830 RVA: 0x005AEA7F File Offset: 0x005ACC7F
	public override string TitleTextId
	{
		get
		{
			return this.ConfigData.Title;
		}
	}

	// Token: 0x17001AA7 RID: 6823
	// (get) Token: 0x06014777 RID: 83831 RVA: 0x005AEA8C File Offset: 0x005ACC8C
	public override string ContentTextId
	{
		get
		{
			return this.ConfigData.Content;
		}
	}

	// Token: 0x06014778 RID: 83832 RVA: 0x005AEA99 File Offset: 0x005ACC99
	protected override EFavorContentType GetFavorContentType()
	{
		return EFavorContentType.Voice;
	}

	// Token: 0x04009E2F RID: 40495
	public EFavorVoiceType FavorVoiceParamType = EFavorVoiceType.FavorNatureVoice;

	// Token: 0x04009E30 RID: 40496
	public FavorWord ConfigData;
}
