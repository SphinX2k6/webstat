using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

// Token: 0x02001879 RID: 6265
[NullableContext(1)]
[Nullable(0)]
public class BaseCheckCondition
{
	// Token: 0x17000EC1 RID: 3777
	// (get) Token: 0x0600B3AA RID: 45994 RVA: 0x002FE953 File Offset: 0x002FCB53
	// (set) Token: 0x0600B3AB RID: 45995 RVA: 0x002FE95B File Offset: 0x002FCB5B
	public virtual EComboTeachingCheckType Type { get; set; }

	// Token: 0x17000EC2 RID: 3778
	// (get) Token: 0x0600B3AC RID: 45996 RVA: 0x002FE964 File Offset: 0x002FCB64
	// (set) Token: 0x0600B3AD RID: 45997 RVA: 0x002FE96C File Offset: 0x002FCB6C
	protected virtual EComboTeachingSuccessCondition SuccessType { get; set; } = EComboTeachingSuccessCondition.Base;

	// Token: 0x17000EC3 RID: 3779
	// (get) Token: 0x0600B3AE RID: 45998 RVA: 0x002FE975 File Offset: 0x002FCB75
	// (set) Token: 0x0600B3AF RID: 45999 RVA: 0x002FE97D File Offset: 0x002FCB7D
	protected virtual EComboTeachingFailCondition FailType { get; set; } = EComboTeachingFailCondition.Base;

	// Token: 0x0600B3B0 RID: 46000 RVA: 0x002FE986 File Offset: 0x002FCB86
	public int GetConditionType()
	{
		if (!this.IsSuccessNode)
		{
			return (int)this.FailType;
		}
		return (int)this.SuccessType;
	}

	// Token: 0x0600B3B1 RID: 46001 RVA: 0x002FE9A0 File Offset: 0x002FCBA0
	public BaseCheckCondition(string paramsString, bool isSuccessNode)
	{
		this.OriginString = paramsString;
		this.IsSuccessNode = isSuccessNode;
		if (paramsString != null && paramsString.Length > 0)
		{
			if (isSuccessNode)
			{
				foreach (string text in paramsString.Substring(1, paramsString.Length - 2).Split('#', StringSplitOptions.None))
				{
					if (this.SuccessParamsArray == null)
					{
						this.SuccessParamsArray = new List<List<string>>();
					}
					string[] collection = text.Split(',', StringSplitOptions.None);
					this.SuccessParamsArray.Add(new List<string>(collection));
				}
				return;
			}
			this.ParamsArray = new List<string>(paramsString.Split('#', StringSplitOptions.None));
		}
	}

	// Token: 0x0600B3B2 RID: 46002 RVA: 0x002FEA54 File Offset: 0x002FCC54
	public virtual bool Check(IComboTeachingInfo data, [Nullable(2)] IBaseCheckConditionInfo param = null)
	{
		if (!this.IsSuccessNode)
		{
			return this.CheckFail(data, param);
		}
		return this.CheckSuccess(data, param);
	}

	// Token: 0x0600B3B3 RID: 46003 RVA: 0x002FEA6F File Offset: 0x002FCC6F
	protected virtual bool CheckSuccess(IComboTeachingInfo data, [Nullable(2)] IBaseCheckConditionInfo param = null)
	{
		return false;
	}

	// Token: 0x0600B3B4 RID: 46004 RVA: 0x002FEA72 File Offset: 0x002FCC72
	protected virtual bool CheckFail(IComboTeachingInfo data, [Nullable(2)] IBaseCheckConditionInfo param = null)
	{
		return false;
	}

	// Token: 0x0400550B RID: 21771
	[Nullable(new byte[]
	{
		2,
		1
	})]
	public List<string> ParamsArray;

	// Token: 0x0400550C RID: 21772
	[Nullable(new byte[]
	{
		2,
		1,
		1
	})]
	public List<List<string>> SuccessParamsArray;

	// Token: 0x0400550D RID: 21773
	public string OriginString = "";

	// Token: 0x0400550F RID: 21775
	protected bool IsSuccessNode;
}
