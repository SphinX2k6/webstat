using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

// Token: 0x020027B7 RID: 10167
[NullableContext(1)]
[Nullable(0)]
public class RoleAttributeData : RoleModuleDataBase
{
	// Token: 0x060141A5 RID: 82341 RVA: 0x0059DB15 File Offset: 0x0059BD15
	public RoleAttributeData(int roleId) : base(roleId)
	{
	}

	// Token: 0x060141A6 RID: 82342 RVA: 0x0059DB34 File Offset: 0x0059BD34
	public void SetRoleBaseAttr(int key, int value)
	{
		this.RoleBaseAttr[key] = value;
	}

	// Token: 0x060141A7 RID: 82343 RVA: 0x0059DB44 File Offset: 0x0059BD44
	public int GetRoleBaseAttr(int key)
	{
		int result;
		if (!this.RoleBaseAttr.TryGetValue(key, out result))
		{
			return 0;
		}
		return result;
	}

	// Token: 0x060141A8 RID: 82344 RVA: 0x0059DB64 File Offset: 0x0059BD64
	public void ClearRoleBaseAttr()
	{
		this.RoleBaseAttr.Clear();
	}

	// Token: 0x060141A9 RID: 82345 RVA: 0x0059DB71 File Offset: 0x0059BD71
	public void SetRoleAddAttr(int key, int value)
	{
		this.RoleAddAttr[key] = value;
	}

	// Token: 0x060141AA RID: 82346 RVA: 0x0059DB80 File Offset: 0x0059BD80
	public int GetRoleAddAttr(int key)
	{
		int result;
		if (!this.RoleAddAttr.TryGetValue(key, out result))
		{
			return 0;
		}
		return result;
	}

	// Token: 0x060141AB RID: 82347 RVA: 0x0059DBA0 File Offset: 0x0059BDA0
	public void ClearRoleAddAttr()
	{
		this.RoleAddAttr.Clear();
	}

	// Token: 0x060141AC RID: 82348 RVA: 0x0059DBB0 File Offset: 0x0059BDB0
	public Dictionary<int, int> GetOldRoleBaseAttr()
	{
		Dictionary<int, int> dictionary = new Dictionary<int, int>();
		foreach (int key in this.RoleBaseAttr.Keys)
		{
			dictionary[key] = 0;
		}
		return dictionary;
	}

	// Token: 0x060141AD RID: 82349 RVA: 0x0059DC10 File Offset: 0x0059BE10
	public Dictionary<int, int> GetOldRoleAddAttr()
	{
		Dictionary<int, int> dictionary = new Dictionary<int, int>();
		foreach (int key in this.RoleAddAttr.Keys)
		{
			dictionary[key] = 0;
		}
		return dictionary;
	}

	// Token: 0x060141AE RID: 82350 RVA: 0x0059DC70 File Offset: 0x0059BE70
	public Dictionary<int, int> GetBaseAttrList()
	{
		return this.RoleBaseAttr;
	}

	// Token: 0x060141AF RID: 82351 RVA: 0x0059DC78 File Offset: 0x0059BE78
	public Dictionary<int, int> GetAddAttrList()
	{
		return this.RoleAddAttr;
	}

	// Token: 0x060141B0 RID: 82352 RVA: 0x0059DC80 File Offset: 0x0059BE80
	public int GetAttrValueById(int id)
	{
		int num = 0;
		int num2;
		if (this.RoleBaseAttr.TryGetValue(id, out num2))
		{
			num += num2;
		}
		int num3;
		if (this.RoleAddAttr.TryGetValue(id, out num3))
		{
			num += num3;
		}
		return num;
	}

	// Token: 0x04009C69 RID: 40041
	protected Dictionary<int, int> RoleBaseAttr = new Dictionary<int, int>();

	// Token: 0x04009C6A RID: 40042
	protected Dictionary<int, int> RoleAddAttr = new Dictionary<int, int>();
}
