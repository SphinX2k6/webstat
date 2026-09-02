using System;
using System.Runtime.CompilerServices;
using Aki.Config;

// Token: 0x0200284E RID: 10318
[NullableContext(1)]
[Nullable(0)]
public class RoleFavorRoleInfoContentData : RoleFavorContentDataBase
{
	// Token: 0x06014779 RID: 83833 RVA: 0x005AEA9C File Offset: 0x005ACC9C
	public RoleFavorRoleInfoContentData(int roleId, EFavorExperienceSubType favorExperienceSubType, FavorRoleInfo configData) : base(roleId)
	{
		this.FavorExperienceSubType = favorExperienceSubType;
		this.ConfigData = configData;
	}

	// Token: 0x17001AA8 RID: 6824
	// (get) Token: 0x0601477A RID: 83834 RVA: 0x005AEABA File Offset: 0x005ACCBA
	public override int ConfigId
	{
		get
		{
			return this.ConfigData.Id;
		}
	}

	// Token: 0x17001AA9 RID: 6825
	// (get) Token: 0x0601477B RID: 83835 RVA: 0x005AEAC7 File Offset: 0x005ACCC7
	public override int ConfigConGroupId
	{
		get
		{
			return this.ConfigData.CondGroupId;
		}
	}

	// Token: 0x17001AAA RID: 6826
	// (get) Token: 0x0601477C RID: 83836 RVA: 0x005AEAD4 File Offset: 0x005ACCD4
	public override string TitleTextId
	{
		get
		{
			return "";
		}
	}

	// Token: 0x17001AAB RID: 6827
	// (get) Token: 0x0601477D RID: 83837 RVA: 0x005AEADB File Offset: 0x005ACCDB
	public override string ContentTextId
	{
		get
		{
			return "";
		}
	}

	// Token: 0x0601477E RID: 83838 RVA: 0x005AEAE2 File Offset: 0x005ACCE2
	protected override EFavorContentType GetFavorContentType()
	{
		return EFavorContentType.ExperienceFile;
	}

	// Token: 0x04009E31 RID: 40497
	public FavorRoleInfo ConfigData;

	// Token: 0x04009E32 RID: 40498
	public EFavorExperienceSubType FavorExperienceSubType = EFavorExperienceSubType.RoleBaseInfo;
}
