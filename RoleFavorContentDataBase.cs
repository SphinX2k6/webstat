using System;
using System.Runtime.CompilerServices;
using Aki.Config;

// Token: 0x0200284C RID: 10316
[NullableContext(1)]
[Nullable(0)]
public abstract class RoleFavorContentDataBase : IStaticVariableResetter
{
	// Token: 0x06014766 RID: 83814 RVA: 0x005AE988 File Offset: 0x005ACB88
	static RoleFavorContentDataBase()
	{
		StaticVariableRegister.RegisterAndExecute(new Action(RoleFavorContentDataBase.CreateStaticDefaultValue), new Action(RoleFavorContentDataBase.ResetStaticDefaultValue));
	}

	// Token: 0x06014767 RID: 83815 RVA: 0x005AE9A7 File Offset: 0x005ACBA7
	public RoleFavorContentDataBase(int roleId)
	{
		this.RoleId = roleId;
		this.InstanceIdInternal = RoleFavorContentDataBase.IdCounter++;
	}

	// Token: 0x17001A9C RID: 6812
	// (get) Token: 0x06014768 RID: 83816
	public abstract int ConfigId { get; }

	// Token: 0x17001A9D RID: 6813
	// (get) Token: 0x06014769 RID: 83817
	public abstract int ConfigConGroupId { get; }

	// Token: 0x17001A9E RID: 6814
	// (get) Token: 0x0601476A RID: 83818
	public abstract string TitleTextId { get; }

	// Token: 0x17001A9F RID: 6815
	// (get) Token: 0x0601476B RID: 83819
	public abstract string ContentTextId { get; }

	// Token: 0x0601476C RID: 83820
	protected abstract EFavorContentType GetFavorContentType();

	// Token: 0x17001AA0 RID: 6816
	// (get) Token: 0x0601476D RID: 83821 RVA: 0x005AE9C9 File Offset: 0x005ACBC9
	public int InstanceId
	{
		get
		{
			return this.InstanceIdInternal;
		}
	}

	// Token: 0x17001AA1 RID: 6817
	// (get) Token: 0x0601476E RID: 83822 RVA: 0x005AE9D1 File Offset: 0x005ACBD1
	public string Title
	{
		get
		{
			if (this.TitleTextId == "")
			{
				return "";
			}
			return ConfigMultiTextLang.GetLocalTextNew(this.TitleTextId, null) ?? "";
		}
	}

	// Token: 0x17001AA2 RID: 6818
	// (get) Token: 0x0601476F RID: 83823 RVA: 0x005AEA00 File Offset: 0x005ACC00
	public string Content
	{
		get
		{
			if (this.ContentTextId == "")
			{
				return "";
			}
			return ConfigMultiTextLang.GetLocalTextNew(this.ContentTextId, null) ?? "";
		}
	}

	// Token: 0x17001AA3 RID: 6819
	// (get) Token: 0x06014770 RID: 83824 RVA: 0x005AEA2F File Offset: 0x005ACC2F
	public EFavorContentType FavorContentType
	{
		get
		{
			return this.GetFavorContentType();
		}
	}

	// Token: 0x06014771 RID: 83825 RVA: 0x005AEA37 File Offset: 0x005ACC37
	public static void CreateStaticDefaultValue()
	{
		RoleFavorContentDataBase.IdCounter = 0;
	}

	// Token: 0x06014772 RID: 83826 RVA: 0x005AEA3F File Offset: 0x005ACC3F
	public static void ResetStaticDefaultValue()
	{
		RoleFavorContentDataBase.IdCounter = 0;
	}

	// Token: 0x04009E2C RID: 40492
	public int RoleId;

	// Token: 0x04009E2D RID: 40493
	private readonly int InstanceIdInternal;

	// Token: 0x04009E2E RID: 40494
	private static int IdCounter;
}
