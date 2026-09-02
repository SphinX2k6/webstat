using System;
using System.Runtime.CompilerServices;
using UnrealEngine.Utils;

// Token: 0x0200005F RID: 95
[NullableContext(2)]
[Nullable(0)]
internal class Finalizer<TParam>
{
	// Token: 0x0600020A RID: 522 RVA: 0x0000C413 File Offset: 0x0000A613
	public void Dispose()
	{
		this._Callback = null;
		GC.SuppressFinalize(this);
	}

	// Token: 0x0600020B RID: 523 RVA: 0x0000C422 File Offset: 0x0000A622
	public Finalizer(TParam param, string reason, Action<TParam, string> callback)
	{
		this._Param = param;
		this._Reason = reason;
		this._Callback = callback;
	}

	// Token: 0x0600020C RID: 524 RVA: 0x0000C440 File Offset: 0x0000A640
	protected override void Finalize()
	{
		try
		{
			Action<TParam, string> callback = this._Callback;
			if (callback != null)
			{
				callback(this._Param, this._Reason);
			}
		}
		catch (Exception ex)
		{
			UnrealLogger.Error(ex.ToString());
		}
		finally
		{
			base.Finalize();
		}
	}

	// Token: 0x040001BA RID: 442
	private readonly TParam _Param;

	// Token: 0x040001BB RID: 443
	private readonly string _Reason;

	// Token: 0x040001BC RID: 444
	private Action<TParam, string> _Callback;
}
