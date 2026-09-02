using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;

// Token: 0x02002849 RID: 10313
[NullableContext(1)]
[Nullable(0)]
public class RoleFavorVoiceClassifyData : RoleFavorClassifyDataBase
{
	// Token: 0x0601475A RID: 83802 RVA: 0x005AE78C File Offset: 0x005AC98C
	public RoleFavorVoiceClassifyData(string titleTableId, int roleId, EFavorVoiceType typeParam) : base(titleTableId, roleId)
	{
		this.TypeParam = typeParam;
	}

	// Token: 0x0601475B RID: 83803 RVA: 0x005AE7A4 File Offset: 0x005AC9A4
	protected override EFavorTabType GetFavorTabType()
	{
		return EFavorTabType.Voice;
	}

	// Token: 0x0601475C RID: 83804 RVA: 0x005AE7A8 File Offset: 0x005AC9A8
	protected override void InitContentDataList()
	{
		this.ContentDataList.Clear();
		IReadOnlyList<FavorWord> favorWordConfig = ConfigBase<RoleFavorConfig>.Instance.GetFavorWordConfig(this.RoleId, (int)this.TypeParam);
		if (favorWordConfig == null)
		{
			return;
		}
		int count = favorWordConfig.Count;
		for (int i = 0; i < count; i++)
		{
			FavorWord config = favorWordConfig[i];
			this.ContentDataList.Add(this.CreateVoiceContentData(config));
		}
	}

	// Token: 0x0601475D RID: 83805 RVA: 0x005AE808 File Offset: 0x005ACA08
	private RoleFavorVoiceContentData CreateVoiceContentData(FavorWord config)
	{
		return new RoleFavorVoiceContentData(this.RoleId, this.TypeParam, config);
	}

	// Token: 0x04009E2A RID: 40490
	public EFavorVoiceType TypeParam = EFavorVoiceType.FavorNatureVoice;
}
