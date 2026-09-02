using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.PhoneMessage;

// Token: 0x02001FF3 RID: 8179
[NullableContext(1)]
[Nullable(new byte[]
{
	0,
	1
})]
[Model(0)]
public class InfoDisplayModel : ModelBase<InfoDisplayModel>
{
	// Token: 0x0600F6F8 RID: 63224 RVA: 0x00439CF4 File Offset: 0x00437EF4
	public void SetGroupInfo(List<int> infoIds)
	{
		this.GroupInfoIds = infoIds;
		this.GroupPageIndex = 0;
	}

	// Token: 0x0600F6F9 RID: 63225 RVA: 0x00439D04 File Offset: 0x00437F04
	public void ClearGroupInfo()
	{
		this.GroupInfoIds = new List<int>();
		this.GroupPageIndex = -1;
	}

	// Token: 0x0600F6FA RID: 63226 RVA: 0x00439D18 File Offset: 0x00437F18
	public bool IsInGroupMode()
	{
		return this.GroupInfoIds.Count > 0;
	}

	// Token: 0x0600F6FB RID: 63227 RVA: 0x00439D28 File Offset: 0x00437F28
	public int GetGroupPageCount()
	{
		return this.GroupInfoIds.Count;
	}

	// Token: 0x0600F6FC RID: 63228 RVA: 0x00439D35 File Offset: 0x00437F35
	public int GetGroupPageIndex()
	{
		return this.GroupPageIndex;
	}

	// Token: 0x0600F6FD RID: 63229 RVA: 0x00439D40 File Offset: 0x00437F40
	public int? GetGroupInfoIdByIndex(int index)
	{
		if (index < 0 || index >= this.GroupInfoIds.Count)
		{
			return null;
		}
		return new int?(this.GroupInfoIds[index]);
	}

	// Token: 0x0600F6FE RID: 63230 RVA: 0x00439D7A File Offset: 0x00437F7A
	public bool SetGroupPageIndex(int index)
	{
		if (index < 0 || index >= this.GroupInfoIds.Count)
		{
			return false;
		}
		this.GroupPageIndex = index;
		this.CurrentOpenId = this.GroupInfoIds[index];
		return true;
	}

	// Token: 0x0600F6FF RID: 63231 RVA: 0x00439DAA File Offset: 0x00437FAA
	public EAttachmentType GetCurrentShowAttachmentType()
	{
		return this.CurrentShowAttachmentType;
	}

	// Token: 0x0600F700 RID: 63232 RVA: 0x00439DB2 File Offset: 0x00437FB2
	public void SetCurrentShowAttachmentType(EAttachmentType value)
	{
		this.CurrentShowAttachmentType = value;
	}

	// Token: 0x0600F701 RID: 63233 RVA: 0x00439DBB File Offset: 0x00437FBB
	public int CurrentInformationId()
	{
		return this.CurrentOpenId;
	}

	// Token: 0x0600F702 RID: 63234 RVA: 0x00439DC3 File Offset: 0x00437FC3
	public void SetCurrentOpenInformationId(int id)
	{
		this.CurrentOpenId = id;
	}

	// Token: 0x0600F703 RID: 63235 RVA: 0x00439DCC File Offset: 0x00437FCC
	public string CurrentCurrentInformationTexture()
	{
		return this.CurrentDetailTexture;
	}

	// Token: 0x0600F704 RID: 63236 RVA: 0x00439DD4 File Offset: 0x00437FD4
	public void SetCurrentOpenInformationTexture(string path)
	{
		this.CurrentDetailTexture = path;
	}

	// Token: 0x0600F705 RID: 63237 RVA: 0x00439DDD File Offset: 0x00437FDD
	public void SetAnimName(string value)
	{
		this.AnimName = value;
	}

	// Token: 0x0600F706 RID: 63238 RVA: 0x00439DE6 File Offset: 0x00437FE6
	public string GetAnimName()
	{
		return this.AnimName;
	}

	// Token: 0x0600F707 RID: 63239 RVA: 0x00439DEE File Offset: 0x00437FEE
	public string GetCurrentShowSpineAtlasPath()
	{
		return this.CurrentSpineAtlasPath;
	}

	// Token: 0x0600F708 RID: 63240 RVA: 0x00439DF6 File Offset: 0x00437FF6
	public void SetCurrentShowSpineAtlasPath(string value)
	{
		this.CurrentSpineAtlasPath = value;
	}

	// Token: 0x0600F709 RID: 63241 RVA: 0x00439DFF File Offset: 0x00437FFF
	public string GetCurrentShowSpineDataPath()
	{
		return this.CurrentSpineDataPath;
	}

	// Token: 0x0600F70A RID: 63242 RVA: 0x00439E07 File Offset: 0x00438007
	public void SetCurrentShowSpineDataPath(string value)
	{
		this.CurrentSpineDataPath = value;
	}

	// Token: 0x0600F70B RID: 63243 RVA: 0x00439E10 File Offset: 0x00438010
	public string ConvertToHourMinuteString(float second)
	{
		int num = (int)Math.Floor((double)(second / 60f));
		int num2 = (int)Math.Floor((double)(second - (float)(num * 60)));
		string text = "0" + num.ToString();
		string text2 = "0" + num2.ToString();
		return text.Substring(text.Length - 2) + ":" + text2.Substring(text2.Length - 2);
	}

	// Token: 0x0400774A RID: 30538
	private int CurrentOpenId;

	// Token: 0x0400774B RID: 30539
	public EAttachmentType CurrentShowAttachmentType;

	// Token: 0x0400774C RID: 30540
	private string CurrentDetailTexture = "";

	// Token: 0x0400774D RID: 30541
	public string AnimName = "";

	// Token: 0x0400774E RID: 30542
	public string CurrentSpineAtlasPath = "";

	// Token: 0x0400774F RID: 30543
	public string CurrentSpineDataPath = "";

	// Token: 0x04007750 RID: 30544
	private List<int> GroupInfoIds = new List<int>();

	// Token: 0x04007751 RID: 30545
	private int GroupPageIndex = -1;
}
