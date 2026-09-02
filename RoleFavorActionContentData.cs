using System;
using System.Runtime.CompilerServices;
using Aki.Config;

// Token: 0x02002850 RID: 10320
[NullableContext(1)]
[Nullable(0)]
public class RoleFavorActionContentData : RoleFavorContentDataBase
{
	// Token: 0x06014785 RID: 83845 RVA: 0x005AEB33 File Offset: 0x005ACD33
	public RoleFavorActionContentData(int roleId, EFavorActionType favorActionParamType, Motion configData) : base(roleId)
	{
		this.FavorActionParamType = favorActionParamType;
		this.ConfigData = configData;
	}

	// Token: 0x17001AB0 RID: 6832
	// (get) Token: 0x06014786 RID: 83846 RVA: 0x005AEB51 File Offset: 0x005ACD51
	public override int ConfigId
	{
		get
		{
			return this.ConfigData.Id;
		}
	}

	// Token: 0x17001AB1 RID: 6833
	// (get) Token: 0x06014787 RID: 83847 RVA: 0x005AEB5E File Offset: 0x005ACD5E
	public override int ConfigConGroupId
	{
		get
		{
			return this.ConfigData.CondGroupId;
		}
	}

	// Token: 0x17001AB2 RID: 6834
	// (get) Token: 0x06014788 RID: 83848 RVA: 0x005AEB6B File Offset: 0x005ACD6B
	public override string TitleTextId
	{
		get
		{
			return this.ConfigData.Title;
		}
	}

	// Token: 0x17001AB3 RID: 6835
	// (get) Token: 0x06014789 RID: 83849 RVA: 0x005AEB78 File Offset: 0x005ACD78
	public override string ContentTextId
	{
		get
		{
			return this.ConfigData.Content;
		}
	}

	// Token: 0x0601478A RID: 83850 RVA: 0x005AEB85 File Offset: 0x005ACD85
	protected override EFavorContentType GetFavorContentType()
	{
		return EFavorContentType.Action;
	}

	// Token: 0x04009E35 RID: 40501
	public EFavorActionType FavorActionParamType = EFavorActionType.IdleAction;

	// Token: 0x04009E36 RID: 40502
	public Motion ConfigData;
}
