using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

// Token: 0x0200147C RID: 5244
[NullableContext(1)]
[Nullable(0)]
public class NewPlayerSupportTrialRoleViewModel
{
	// Token: 0x17000C2B RID: 3115
	// (get) Token: 0x060092CB RID: 37579 RVA: 0x0026BA65 File Offset: 0x00269C65
	public ETrialRoleType TrialRoleType
	{
		get
		{
			return this.TrialRoleTypeIntl;
		}
	}

	// Token: 0x17000C2C RID: 3116
	// (get) Token: 0x060092CC RID: 37580 RVA: 0x0026BA6D File Offset: 0x00269C6D
	public string CaptionIcon
	{
		get
		{
			return this.CaptionIconIntl;
		}
	}

	// Token: 0x17000C2D RID: 3117
	// (get) Token: 0x060092CD RID: 37581 RVA: 0x0026BA75 File Offset: 0x00269C75
	public string CaptionText
	{
		get
		{
			return this.CaptionTextIntl;
		}
	}

	// Token: 0x17000C2E RID: 3118
	// (get) Token: 0x060092CE RID: 37582 RVA: 0x0026BA7D File Offset: 0x00269C7D
	public int? SelectedGroupId
	{
		get
		{
			return this.SelectedGroupIdIntl;
		}
	}

	// Token: 0x17000C2F RID: 3119
	// (get) Token: 0x060092CF RID: 37583 RVA: 0x0026BA85 File Offset: 0x00269C85
	public int HelpId
	{
		get
		{
			return this.HelpIdIntl;
		}
	}

	// Token: 0x060092D0 RID: 37584 RVA: 0x0026BA90 File Offset: 0x00269C90
	public NewPlayerSupportTrialRoleViewModel(ETrialRoleType trialRoleType, string captionIcon, string captionText, int helpId, int? selectedGroupId = null)
	{
		this.TrialRoleTypeIntl = trialRoleType;
		this.CaptionIconIntl = captionIcon;
		this.CaptionTextIntl = captionText;
		this.HelpIdIntl = helpId;
		this.SelectedGroupIdIntl = selectedGroupId;
	}

	// Token: 0x060092D1 RID: 37585 RVA: 0x0026BAEC File Offset: 0x00269CEC
	public int? GetCurUseTrialRoleId()
	{
		TrialRoleGroupData curUseTrialRole = ModelBase<TrialRoleModel>.Instance.GetCurUseTrialRole(this.TrialRoleType);
		if (curUseTrialRole == null)
		{
			return null;
		}
		return new int?(curUseTrialRole.TrialRoleId);
	}

	// Token: 0x060092D2 RID: 37586 RVA: 0x0026BB21 File Offset: 0x00269D21
	[NullableContext(2)]
	public TrialRoleGroupData CurUseTrialRoleGroupData()
	{
		return ModelBase<TrialRoleModel>.Instance.GetCurUseTrialRole(this.TrialRoleType);
	}

	// Token: 0x060092D3 RID: 37587 RVA: 0x0026BB33 File Offset: 0x00269D33
	[NullableContext(2)]
	public TrialRoleGroupData GetTrialRoleByGroupId(int groupId)
	{
		return ModelBase<TrialRoleModel>.Instance.GetDataByGroupId(groupId);
	}

	// Token: 0x060092D4 RID: 37588 RVA: 0x0026BB40 File Offset: 0x00269D40
	public List<TrialRoleGroupData> GetTrialRoleList()
	{
		return ModelBase<TrialRoleModel>.Instance.GetDataListByType(this.TrialRoleType);
	}

	// Token: 0x060092D5 RID: 37589 RVA: 0x0026BB52 File Offset: 0x00269D52
	public void SetRequestTrialRoleLvUpFunc(Action<int> func)
	{
		this.RequestTrialRoleLvUpFunc = func;
	}

	// Token: 0x060092D6 RID: 37590 RVA: 0x0026BB5B File Offset: 0x00269D5B
	[NullableContext(2)]
	public Action<int> GetRequestTrialRoleLvUpFunc()
	{
		return this.RequestTrialRoleLvUpFunc;
	}

	// Token: 0x060092D7 RID: 37591 RVA: 0x0026BB63 File Offset: 0x00269D63
	public void SetRequestSetCurUseTrialRoleFunc(Action<int, Action<int>> func)
	{
		this.RequestSetCurUseTrialRoleFunc = func;
	}

	// Token: 0x060092D8 RID: 37592 RVA: 0x0026BB6C File Offset: 0x00269D6C
	[return: Nullable(new byte[]
	{
		2,
		1
	})]
	public Action<int, Action<int>> GetRequestSetCurUseTrialRoleFunc()
	{
		return this.RequestSetCurUseTrialRoleFunc;
	}

	// Token: 0x060092D9 RID: 37593 RVA: 0x0026BB74 File Offset: 0x00269D74
	public void SetTrialRoleGroupUnlockDesc(Dictionary<int, string> descMap)
	{
		this.TrialGroupUnlockDescMap = descMap;
	}

	// Token: 0x060092DA RID: 37594 RVA: 0x0026BB80 File Offset: 0x00269D80
	[NullableContext(2)]
	public string GetTrialRoleGroupUnlockDesc(int groupId)
	{
		string result;
		if (!this.TrialGroupUnlockDescMap.TryGetValue(groupId, out result))
		{
			return null;
		}
		return result;
	}

	// Token: 0x040043E6 RID: 17382
	private ETrialRoleType TrialRoleTypeIntl;

	// Token: 0x040043E7 RID: 17383
	private string CaptionIconIntl = "";

	// Token: 0x040043E8 RID: 17384
	private string CaptionTextIntl = "";

	// Token: 0x040043E9 RID: 17385
	private int? SelectedGroupIdIntl;

	// Token: 0x040043EA RID: 17386
	private int HelpIdIntl;

	// Token: 0x040043EB RID: 17387
	private Dictionary<int, string> TrialGroupUnlockDescMap = new Dictionary<int, string>();

	// Token: 0x040043EC RID: 17388
	[Nullable(2)]
	private Action<int> RequestTrialRoleLvUpFunc;

	// Token: 0x040043ED RID: 17389
	[Nullable(new byte[]
	{
		2,
		1
	})]
	private Action<int, Action<int>> RequestSetCurUseTrialRoleFunc;
}
