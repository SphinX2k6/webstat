using System;
using System.Runtime.CompilerServices;

// Token: 0x02002A8E RID: 10894
[NullableContext(2)]
[Nullable(new byte[]
{
	0,
	1
})]
[Model(0)]
public class SpecialTransitionModel : ModelBase<SpecialTransitionModel>
{
	// Token: 0x06015CEE RID: 89326 RVA: 0x0060BEF4 File Offset: 0x0060A0F4
	public ISpecialTransitionParams GetSpecialTransitionParams()
	{
		return this.SpecialTransitionParams;
	}

	// Token: 0x06015CEF RID: 89327 RVA: 0x0060BEFC File Offset: 0x0060A0FC
	[NullableContext(1)]
	public bool SetSpecialTransitionParams(ISpecialTransitionParams @params)
	{
		if (this.SpecialTransitionParams != null)
		{
			Singleton<Log>.Instance.Error(ELogModule.Loading, ELogAuthor.CB, "SpecialTransitionParams已存在,被重复设置", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		this.SpecialTransitionParams = @params;
		return true;
	}

	// Token: 0x06015CF0 RID: 89328 RVA: 0x0060BF37 File Offset: 0x0060A137
	public void ClearSpecialTransitionParams()
	{
		this.SpecialTransitionParams = null;
	}

	// Token: 0x06015CF1 RID: 89329 RVA: 0x0060BF40 File Offset: 0x0060A140
	public bool IsLoadingMode()
	{
		ISpecialTransitionParams specialTransitionParams = this.SpecialTransitionParams;
		return specialTransitionParams != null && specialTransitionParams.LoadingType != null;
	}

	// Token: 0x06015CF2 RID: 89330 RVA: 0x0060BF66 File Offset: 0x0060A166
	protected override bool OnClear()
	{
		this.SpecialTransitionParams = null;
		return true;
	}

	// Token: 0x0400A74B RID: 42827
	private ISpecialTransitionParams SpecialTransitionParams;
}
