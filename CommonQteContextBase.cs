using System;
using System.Runtime.CompilerServices;
using Aki.Config;
using AkiClient.Game.Aki.Data.Qte;
using UnrealEngine;

// Token: 0x0200260D RID: 9741
[NullableContext(2)]
[Nullable(0)]
public abstract class CommonQteContextBase
{
	// Token: 0x06013186 RID: 78214 RVA: 0x0054B94C File Offset: 0x00549B4C
	public bool IsPending()
	{
		return this.State == EQteState.Pending;
	}

	// Token: 0x06013187 RID: 78215 RVA: 0x0054B957 File Offset: 0x00549B57
	public bool IsPendingSuccess()
	{
		return this.State == EQteState.PendingSuccess;
	}

	// Token: 0x06013188 RID: 78216 RVA: 0x0054B962 File Offset: 0x00549B62
	public bool IsSuccess()
	{
		return this.State == EQteState.Success;
	}

	// Token: 0x06013189 RID: 78217 RVA: 0x0054B96D File Offset: 0x00549B6D
	public bool IsFail()
	{
		return this.State == EQteState.Fail;
	}

	// Token: 0x0601318A RID: 78218 RVA: 0x0054B978 File Offset: 0x00549B78
	public bool IsInvalid()
	{
		return this.State == EQteState.Invalid;
	}

	// Token: 0x0601318B RID: 78219 RVA: 0x0054B984 File Offset: 0x00549B84
	public bool IsActive()
	{
		int qteHandleId = ModelBase<CommonQteModel>.Instance.GetQteHandleId();
		return this.HandleId == qteHandleId || this.GroupHandleId == qteHandleId;
	}

	// Token: 0x0601318C RID: 78220 RVA: 0x0054B9B0 File Offset: 0x00549BB0
	public bool IsResponsible()
	{
		return this.IsActive() && this.IsPending();
	}

	// Token: 0x0601318D RID: 78221 RVA: 0x0054B9C2 File Offset: 0x00549BC2
	public void Response()
	{
		this.OnResponse();
	}

	// Token: 0x0601318E RID: 78222 RVA: 0x0054B9CA File Offset: 0x00549BCA
	protected virtual void OnResponse()
	{
	}

	// Token: 0x0601318F RID: 78223 RVA: 0x0054B9CC File Offset: 0x00549BCC
	public void ResponseEnd()
	{
		this.OnResponseEnd();
	}

	// Token: 0x06013190 RID: 78224 RVA: 0x0054B9D4 File Offset: 0x00549BD4
	protected virtual void OnResponseEnd()
	{
	}

	// Token: 0x06013191 RID: 78225 RVA: 0x0054B9D6 File Offset: 0x00549BD6
	public void QtePendingSuccess()
	{
		if (this.State == EQteState.PendingSuccess)
		{
			return;
		}
		this.State = EQteState.PendingSuccess;
		this.OnQtePendingSuccess();
	}

	// Token: 0x06013192 RID: 78226 RVA: 0x0054B9EF File Offset: 0x00549BEF
	protected virtual void OnQtePendingSuccess()
	{
	}

	// Token: 0x06013193 RID: 78227 RVA: 0x0054B9F4 File Offset: 0x00549BF4
	public void QteSuccess()
	{
		if (this.State == EQteState.Success)
		{
			return;
		}
		this.State = EQteState.Success;
		this.OnQteSuccess();
		if (this.SuccessCallback != null)
		{
			this.SuccessCallback(this);
		}
		this.SuccessCallback = null;
		if (this.GroupHandleId == -1)
		{
			ControllerBase<CommonQteController>.Instance.StopQte(this.HandleId);
		}
	}

	// Token: 0x06013194 RID: 78228 RVA: 0x0054BA4C File Offset: 0x00549C4C
	protected virtual void OnQteSuccess()
	{
	}

	// Token: 0x06013195 RID: 78229 RVA: 0x0054BA4E File Offset: 0x00549C4E
	public void SetQteSuccess()
	{
		if (this.PassTime < this.LeastDuration)
		{
			this.QtePendingSuccess();
			return;
		}
		this.QteSuccess();
	}

	// Token: 0x06013196 RID: 78230 RVA: 0x0054BA6C File Offset: 0x00549C6C
	public void QteFail()
	{
		if (this.State == EQteState.Fail)
		{
			return;
		}
		this.State = EQteState.Fail;
		this.OnQteFail();
		if (this.FailCallback != null)
		{
			this.FailCallback(this);
		}
		this.FailCallback = null;
		if (this.GroupHandleId == -1)
		{
			ControllerBase<CommonQteController>.Instance.StopQte(this.HandleId);
		}
	}

	// Token: 0x06013197 RID: 78231 RVA: 0x0054BAC4 File Offset: 0x00549CC4
	protected virtual void OnQteFail()
	{
	}

	// Token: 0x06013198 RID: 78232 RVA: 0x0054BAC6 File Offset: 0x00549CC6
	public void UpdateTime(float delta)
	{
		this.OnUpdateTime(delta);
	}

	// Token: 0x06013199 RID: 78233 RVA: 0x0054BACF File Offset: 0x00549CCF
	protected virtual void OnUpdateTime(float delta)
	{
	}

	// Token: 0x0601319A RID: 78234 RVA: 0x0054BAD1 File Offset: 0x00549CD1
	public void Clear()
	{
		if (this.IsPending())
		{
			this.State = EQteState.Invalid;
		}
		this.OnResponseEnd();
		this.OnClear();
		this.SuccessCallback = null;
		this.FailCallback = null;
		this.Resource = null;
		this.UiActor = null;
	}

	// Token: 0x0601319B RID: 78235 RVA: 0x0054BB0A File Offset: 0x00549D0A
	protected virtual void OnClear()
	{
	}

	// Token: 0x0601319C RID: 78236 RVA: 0x0054BB0C File Offset: 0x00549D0C
	public virtual SCommonQte GetConfig()
	{
		return this.Config;
	}

	// Token: 0x0601319D RID: 78237 RVA: 0x0054BB14 File Offset: 0x00549D14
	public virtual string GetAction(int? index = null)
	{
		return this.OnGetAction(index);
	}

	// Token: 0x0601319E RID: 78238 RVA: 0x0054BB1D File Offset: 0x00549D1D
	protected virtual string OnGetAction(int? index = null)
	{
		return null;
	}

	// Token: 0x0601319F RID: 78239 RVA: 0x0054BB20 File Offset: 0x00549D20
	[NullableContext(1)]
	public void SetConfig(SCommonQte config)
	{
		this.Config = config;
		if (config.BaseConfig.Duration < 0f)
		{
			this.IsPermanent = true;
		}
		else
		{
			this.Duration = config.BaseConfig.Duration * (float)Singleton<TimeUtil>.Instance.InverseMillisecond;
		}
		this.LeastDuration = config.BaseConfig.LeastDuration * (float)Singleton<TimeUtil>.Instance.InverseMillisecond;
		this.OnSetConfig(config);
	}

	// Token: 0x060131A0 RID: 78240 RVA: 0x0054BB90 File Offset: 0x00549D90
	[NullableContext(1)]
	protected virtual void OnSetConfig(SCommonQte config)
	{
	}

	// Token: 0x060131A1 RID: 78241 RVA: 0x0054BB94 File Offset: 0x00549D94
	[NullableContext(1)]
	public void SetGroupConfig(SCommonQteGroup groupConfig)
	{
		this.GroupConfig = groupConfig;
		if (groupConfig.Duration < 0f)
		{
			this.IsPermanent = true;
		}
		else
		{
			this.IsPermanent = false;
			this.Duration = groupConfig.Duration * (float)Singleton<TimeUtil>.Instance.InverseMillisecond;
		}
		this.LeastDuration = groupConfig.LeastDuration * (float)Singleton<TimeUtil>.Instance.InverseMillisecond;
		this.OnSetGroupConfig(groupConfig);
	}

	// Token: 0x060131A2 RID: 78242 RVA: 0x0054BBFC File Offset: 0x00549DFC
	[NullableContext(1)]
	protected virtual void OnSetGroupConfig(SCommonQteGroup config)
	{
	}

	// Token: 0x060131A3 RID: 78243 RVA: 0x0054BBFE File Offset: 0x00549DFE
	public object GetUiConfig()
	{
		return this.OnGetUiConfig();
	}

	// Token: 0x060131A4 RID: 78244 RVA: 0x0054BC06 File Offset: 0x00549E06
	protected virtual object OnGetUiConfig()
	{
		return null;
	}

	// Token: 0x060131A5 RID: 78245 RVA: 0x0054BC0C File Offset: 0x00549E0C
	public virtual bool CheckQteConditionAndDoSuccess()
	{
		if (this.CheckQteConditionMatch())
		{
			if (this.GroupContext != null)
			{
				this.CheckSuccessTime = DateTimeOffset.Now.ToUnixTimeMilliseconds();
				CommonQteGroupContext groupContext = this.GroupContext;
				if (groupContext != null)
				{
					groupContext.CheckQteConditionAndDoSuccess();
				}
			}
			else
			{
				this.SetQteSuccess();
			}
			return true;
		}
		return false;
	}

	// Token: 0x060131A6 RID: 78246 RVA: 0x0054BC59 File Offset: 0x00549E59
	public virtual bool CheckQteConditionMatch()
	{
		return false;
	}

	// Token: 0x060131A7 RID: 78247 RVA: 0x0054BC5C File Offset: 0x00549E5C
	public bool CheckQteSuccessInTime(float toleranceTime)
	{
		return this.CheckSuccessTime != 0L && (float)(DateTimeOffset.Now.ToUnixTimeMilliseconds() - this.CheckSuccessTime) < toleranceTime;
	}

	// Token: 0x060131A8 RID: 78248 RVA: 0x0054BC8B File Offset: 0x00549E8B
	public float GetRemainingTime()
	{
		return Math.Max(0f, this.Duration - this.PassTime);
	}

	// Token: 0x060131A9 RID: 78249 RVA: 0x0054BCA4 File Offset: 0x00549EA4
	public float GetRemainingTimeProgress()
	{
		if (this.Duration <= 0f)
		{
			return 1f;
		}
		return this.GetRemainingTime() / this.Duration;
	}

	// Token: 0x060131AA RID: 78250 RVA: 0x0054BCC6 File Offset: 0x00549EC6
	public virtual float GetProgress()
	{
		return 0f;
	}

	// Token: 0x060131AB RID: 78251 RVA: 0x0054BCCD File Offset: 0x00549ECD
	public virtual bool IsAttachToActor()
	{
		return false;
	}

	// Token: 0x060131AC RID: 78252 RVA: 0x0054BCD0 File Offset: 0x00549ED0
	public virtual SCommonQte_Attach? GetAttachConfig()
	{
		return null;
	}

	// Token: 0x060131AD RID: 78253 RVA: 0x0054BCE6 File Offset: 0x00549EE6
	public AActor GetAttachTarget()
	{
		IQteExtraParams extraParams = this.ExtraParams;
		if (extraParams == null)
		{
			return null;
		}
		return extraParams.AttachTarget;
	}

	// Token: 0x060131AE RID: 78254 RVA: 0x0054BCFC File Offset: 0x00549EFC
	public unsafe static string GetQteActionNameByActionId(int action, int? qteId = null)
	{
		QteInputActionMapping? config = ConfigQteInputActionMappingByQteInputActionId.GetConfig(action, true);
		if (config == null)
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.CommonQte;
			ELogAuthor author = ELogAuthor.GHY;
			string message = "QTE输入行为映射不存在";
			<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("action", action);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("QteId", qteId);
			instance.Error(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
			return null;
		}
		return config.Value.QteInputActionName;
	}

	// Token: 0x04009504 RID: 38148
	public ECommonQteContextType? Type;

	// Token: 0x04009505 RID: 38149
	public int HandleId = -1;

	// Token: 0x04009506 RID: 38150
	public int QteId;

	// Token: 0x04009507 RID: 38151
	public EQteSource? Source;

	// Token: 0x04009508 RID: 38152
	public EQteState State;

	// Token: 0x04009509 RID: 38153
	public SCommonQte Config;

	// Token: 0x0400950A RID: 38154
	public float Duration;

	// Token: 0x0400950B RID: 38155
	public float LeastDuration;

	// Token: 0x0400950C RID: 38156
	public float PassTime;

	// Token: 0x0400950D RID: 38157
	public bool IsPermanent;

	// Token: 0x0400950E RID: 38158
	public TCommonQteCallback SuccessCallback;

	// Token: 0x0400950F RID: 38159
	public TCommonQteCallback FailCallback;

	// Token: 0x04009510 RID: 38160
	public IQteExtraParams ExtraParams;

	// Token: 0x04009511 RID: 38161
	public IQteResource Resource;

	// Token: 0x04009512 RID: 38162
	public AActor UiActor;

	// Token: 0x04009513 RID: 38163
	public int AudioHandle;

	// Token: 0x04009514 RID: 38164
	public int GroupHandleId = -1;

	// Token: 0x04009515 RID: 38165
	public int QteGroupId;

	// Token: 0x04009516 RID: 38166
	public SCommonQteGroup GroupConfig;

	// Token: 0x04009517 RID: 38167
	public CommonQteGroupContext GroupContext;

	// Token: 0x04009518 RID: 38168
	public long CheckSuccessTime;
}
