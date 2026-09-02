using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

// Token: 0x02002C9C RID: 11420
[NullableContext(1)]
[Nullable(0)]
public class UiMotorDataComponent : UiModelComponentBase
{
	// Token: 0x06016EAD RID: 93869 RVA: 0x0065A7BC File Offset: 0x006589BC
	public int NextLoadSeq()
	{
		int num = this.LoadSeqInternal + 1;
		this.LoadSeqInternal = num;
		return num;
	}

	// Token: 0x06016EAE RID: 93870 RVA: 0x0065A7DA File Offset: 0x006589DA
	public int GetLoadSeq()
	{
		return this.LoadSeqInternal;
	}

	// Token: 0x06016EAF RID: 93871 RVA: 0x0065A7E2 File Offset: 0x006589E2
	public void SetRequestedFrameId(int frameId)
	{
		this.RequestedFrameIdInternal = frameId;
	}

	// Token: 0x06016EB0 RID: 93872 RVA: 0x0065A7EB File Offset: 0x006589EB
	public int GetRequestedFrameId()
	{
		return this.RequestedFrameIdInternal;
	}

	// Token: 0x06016EB1 RID: 93873 RVA: 0x0065A7F3 File Offset: 0x006589F3
	public int GetSkinId()
	{
		return this.SkinIdInternal;
	}

	// Token: 0x06016EB2 RID: 93874 RVA: 0x0065A7FB File Offset: 0x006589FB
	public int GetFrameId()
	{
		return this.FrameIdInternal;
	}

	// Token: 0x06016EB3 RID: 93875 RVA: 0x0065A803 File Offset: 0x00658A03
	public List<int> GetStickerIdList()
	{
		return this.StickerIdListInternal;
	}

	// Token: 0x06016EB4 RID: 93876 RVA: 0x0065A80B File Offset: 0x00658A0B
	public List<int> GetDecorateIdList()
	{
		return this.DecorateIdListInternal;
	}

	// Token: 0x06016EB5 RID: 93877 RVA: 0x0065A813 File Offset: 0x00658A13
	public void SetSkinId(int skinId)
	{
		this.SkinIdInternal = skinId;
	}

	// Token: 0x06016EB6 RID: 93878 RVA: 0x0065A81C File Offset: 0x00658A1C
	public void SetFrameId(int frameId)
	{
		this.FrameIdInternal = frameId;
	}

	// Token: 0x06016EB7 RID: 93879 RVA: 0x0065A825 File Offset: 0x00658A25
	public void SetStickerIdList(List<int> stickerIdList)
	{
		this.StickerIdListInternal = stickerIdList;
	}

	// Token: 0x06016EB8 RID: 93880 RVA: 0x0065A82E File Offset: 0x00658A2E
	public void SetDecorateIdList(List<int> decorateIdList)
	{
		this.DecorateIdListInternal = decorateIdList;
	}

	// Token: 0x06016EB9 RID: 93881 RVA: 0x0065A838 File Offset: 0x00658A38
	public void SetDecorationId(int partId, int decorationId)
	{
		int num = partId - 1;
		while (this.DecorateIdListInternal.Count <= num)
		{
			this.DecorateIdListInternal.Add(0);
		}
		this.DecorateIdListInternal[num] = decorationId;
	}

	// Token: 0x06016EBA RID: 93882 RVA: 0x0065A874 File Offset: 0x00658A74
	public bool IsSameDecorationId(int partId, int decorationId)
	{
		int num = partId - 1;
		return num >= 0 && num < this.DecorateIdListInternal.Count && this.DecorateIdListInternal[num] == decorationId;
	}

	// Token: 0x06016EBB RID: 93883 RVA: 0x0065A8A8 File Offset: 0x00658AA8
	[NullableContext(2)]
	public void SetRoleData(int roleId, int skinId, string animPath = null)
	{
		this.RoleIdInternal = roleId;
		this.RoleSkinIdInternal = skinId;
		this.AnimPathInternal = (animPath ?? string.Empty);
	}

	// Token: 0x06016EBC RID: 93884 RVA: 0x0065A8C8 File Offset: 0x00658AC8
	public int GetRoleId()
	{
		return this.RoleIdInternal;
	}

	// Token: 0x06016EBD RID: 93885 RVA: 0x0065A8D0 File Offset: 0x00658AD0
	public int GetRoleSkinId()
	{
		return this.RoleSkinIdInternal;
	}

	// Token: 0x06016EBE RID: 93886 RVA: 0x0065A8D8 File Offset: 0x00658AD8
	public string GetAnimPath()
	{
		return this.AnimPathInternal;
	}

	// Token: 0x0400B0C0 RID: 45248
	private int SkinIdInternal;

	// Token: 0x0400B0C1 RID: 45249
	private List<int> StickerIdListInternal = new List<int>();

	// Token: 0x0400B0C2 RID: 45250
	private int FrameIdInternal;

	// Token: 0x0400B0C3 RID: 45251
	private List<int> DecorateIdListInternal = new List<int>();

	// Token: 0x0400B0C4 RID: 45252
	private int RoleIdInternal;

	// Token: 0x0400B0C5 RID: 45253
	private int RoleSkinIdInternal;

	// Token: 0x0400B0C6 RID: 45254
	private string AnimPathInternal = "";

	// Token: 0x0400B0C7 RID: 45255
	private int LoadSeqInternal;

	// Token: 0x0400B0C8 RID: 45256
	private int RequestedFrameIdInternal;
}
