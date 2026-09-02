using System;
using System.Runtime.CompilerServices;
using Aki.Protocol;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.RoleDev;
using CSharpScript.Game.Module.RoleUi.RoleDev.Define;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;

// Token: 0x02002818 RID: 10264
[NullableContext(1)]
[Nullable(new byte[]
{
	0,
	1
})]
[Controller(0)]
public class RoleDevController : UiControllerBase<RoleDevController>
{
	// Token: 0x06014434 RID: 82996 RVA: 0x005A429F File Offset: 0x005A249F
	protected override void OnRegisterNetEvent()
	{
	}

	// Token: 0x06014435 RID: 82997 RVA: 0x005A42A1 File Offset: 0x005A24A1
	protected override void OnUnRegisterNetEvent()
	{
	}

	// Token: 0x06014436 RID: 82998 RVA: 0x005A42A3 File Offset: 0x005A24A3
	protected override void OnAddEvents()
	{
	}

	// Token: 0x06014437 RID: 82999 RVA: 0x005A42A5 File Offset: 0x005A24A5
	protected override void OnRemoveEvents()
	{
	}

	// Token: 0x06014438 RID: 83000 RVA: 0x005A42A7 File Offset: 0x005A24A7
	private void OnLoadingNetDataDone()
	{
		this.RequestRoleDevelopConfig(null);
	}

	// Token: 0x06014439 RID: 83001 RVA: 0x005A42B0 File Offset: 0x005A24B0
	public UniTask RequestRoleDevelopConfigAndOpenView(int roleId)
	{
		RoleDevController.<RequestRoleDevelopConfigAndOpenView>d__5 <RequestRoleDevelopConfigAndOpenView>d__;
		<RequestRoleDevelopConfigAndOpenView>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<RequestRoleDevelopConfigAndOpenView>d__.<>4__this = this;
		<RequestRoleDevelopConfigAndOpenView>d__.roleId = roleId;
		<RequestRoleDevelopConfigAndOpenView>d__.<>1__state = -1;
		<RequestRoleDevelopConfigAndOpenView>d__.<>t__builder.Start<RoleDevController.<RequestRoleDevelopConfigAndOpenView>d__5>(ref <RequestRoleDevelopConfigAndOpenView>d__);
		return <RequestRoleDevelopConfigAndOpenView>d__.<>t__builder.Task;
	}

	// Token: 0x0601443A RID: 83002 RVA: 0x005A42FB File Offset: 0x005A24FB
	public void OpenRoleDevelopView(int roleId)
	{
		Singleton<UiManager>.Instance.OpenView(EUiViewName.RoleDevRootView, roleId, null);
	}

	// Token: 0x0601443B RID: 83003 RVA: 0x005A4314 File Offset: 0x005A2514
	[NullableContext(2)]
	public void RequestRoleDevelopConfig(Action callback = null)
	{
		RoleDevelopConfigRequest roleDevelopConfigRequest = RoleDevelopConfigRequest.Create();
		roleDevelopConfigRequest.Version = ModelBase<RoleDevModel>.Instance.Version;
		Singleton<Net>.Instance.Call<RoleDevelopConfigResponse>(ERequestMessageId.RoleDevelopConfigRequest, roleDevelopConfigRequest, delegate(RoleDevelopConfigResponse response, Net.CallbackStatus _)
		{
			if (response == null)
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.RoleDev;
				ELogAuthor author = ELogAuthor.WMQ;
				string message = "RoleDevelopConfig请求无响应";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("response", response);
				instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
				return;
			}
			RoleDevelopConfigs configs = response.Configs;
			if (configs == null)
			{
				Log instance2 = Singleton<Log>.Instance;
				ELogModule module2 = ELogModule.RoleDev;
				ELogAuthor author2 = ELogAuthor.LJS;
				string message2 = "RoleDevelopConfig Configs为空";
				ValueTuple<string, object> valueTuple2 = new ValueTuple<string, object>("response", response);
				instance2.Error(module2, author2, message2, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple2));
				return;
			}
			ModelBase<RoleDevModel>.Instance.UpdateRoleDevConfig(configs);
			Action callback2 = callback;
			if (callback2 == null)
			{
				return;
			}
			callback2();
		}, 0);
	}

	// Token: 0x0601443C RID: 83004 RVA: 0x005A4364 File Offset: 0x005A2564
	public void RequestRecordRoleMarkOperation(int roleId)
	{
		RoleUpdateDevelopTargetRequest roleUpdateDevelopTargetRequest = RoleUpdateDevelopTargetRequest.Create();
		roleUpdateDevelopTargetRequest.RoleId = roleId;
		roleUpdateDevelopTargetRequest.Source = 2;
		Singleton<Net>.Instance.Call<RoleUpdateDevelopTargetResponse>(ERequestMessageId.RoleUpdateDevelopTargetRequest, roleUpdateDevelopTargetRequest, delegate(RoleUpdateDevelopTargetResponse response, Net.CallbackStatus _)
		{
			if (response == null)
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.RoleDev;
				ELogAuthor author = ELogAuthor.WMQ;
				string message = "RoleUpdateDevelopTarget请求无响应";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("response", response);
				instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
				return;
			}
			if (response.ErrorCode != ErrorCode.Success)
			{
				ControllerBase<ErrorCodeController>.Instance.OpenErrorCodeTipView(response.ErrorCode, 28745, null, true, true);
			}
		}, 0);
	}

	// Token: 0x0601443D RID: 83005 RVA: 0x005A43B8 File Offset: 0x005A25B8
	private void HandleRoleUpdateDevelopTargetNotify(RoleUpdateDevelopTargetNotify notify, [Nullable(2)] Net.CallbackStatus _)
	{
		int roleId = notify.RoleId;
		if (ModelBase<RoleDevModel>.Instance != null)
		{
			ModelBase<RoleDevModel>.Instance.UpdateDevTargetRoleId(roleId);
		}
		Singleton<EventSystem>.Instance.Emit(EEventName.RoleDevTargetRoleIdChange);
	}

	// Token: 0x0601443E RID: 83006 RVA: 0x005A43F0 File Offset: 0x005A25F0
	private void HandleRoleDevelopConfigUpdateNotify(RoleDevelopConfigUpdateNotify notify, [Nullable(2)] Net.CallbackStatus _)
	{
		RoleDevelopConfigs configs = notify.Configs;
		if (configs == null)
		{
			Singleton<Log>.Instance.Error(ELogModule.RoleDev, ELogAuthor.LJS, "RoleDevelopConfigUpdateNotify Configs为空", default(ReadOnlySpan<ValueTuple<string, object>>));
			return;
		}
		ModelBase<RoleDevModel>.Instance.UpdateRoleDevConfig(configs);
	}

	// Token: 0x0601443F RID: 83007 RVA: 0x005A4434 File Offset: 0x005A2634
	[NullableContext(2)]
	private unsafe RoleDevLogEvent BuildRoleDevLogEvent(int roleId, ERoleDevMainPage mainPage, ERoleDevSubPageButton subPage)
	{
		RoleDevLogEvent result;
		try
		{
			CSharpScript.Game.Module.RoleUi.RoleDev.Define.ERoleType roleType = this.GetRoleType(roleId);
			result = new RoleDevLogEvent
			{
				i_role_id = roleId,
				i_role_type = (int)roleType,
				i_main_page = (int)mainPage,
				i_sub_page = (int)subPage
			};
		}
		catch (Exception ex)
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.RoleDev;
			ELogAuthor author = ELogAuthor.WMQ;
			string message = "构建角色培养日志数据失败";
			Exception error = ex;
			<>y__InlineArray3<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray3<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("roleId", roleId);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("mainPage", mainPage);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 2) = new ValueTuple<string, object>("subPage", subPage);
			instance.ErrorWithStack(module, author, message, error, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 3));
			result = null;
		}
		return result;
	}

	// Token: 0x06014440 RID: 83008 RVA: 0x005A4504 File Offset: 0x005A2704
	private unsafe CSharpScript.Game.Module.RoleUi.RoleDev.Define.ERoleType GetRoleType(int roleId)
	{
		CSharpScript.Game.Module.RoleUi.RoleDev.Define.ERoleType result;
		try
		{
			if (ModelBase<RoleModel>.Instance.GetRoleDataById(roleId, true) != null)
			{
				result = CSharpScript.Game.Module.RoleUi.RoleDev.Define.ERoleType.Owned;
			}
			else
			{
				result = CSharpScript.Game.Module.RoleUi.RoleDev.Define.ERoleType.NotOwned;
			}
		}
		catch (Exception ex)
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.RoleDev;
			ELogAuthor author = ELogAuthor.WMQ;
			string message = "获取角色类型失败";
			<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("roleId", roleId);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("error", ex.ToString());
			instance.Error(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
			result = CSharpScript.Game.Module.RoleUi.RoleDev.Define.ERoleType.NotOwned;
		}
		return result;
	}

	// Token: 0x06014441 RID: 83009 RVA: 0x005A45A0 File Offset: 0x005A27A0
	public void LogRoleDevPageClick(int roleId, ERoleDevMainPage mainPage)
	{
		RoleDevLogEvent roleDevLogEvent = this.BuildRoleDevLogEvent(roleId, mainPage, ERoleDevSubPageButton.None);
		if (roleDevLogEvent != null)
		{
			ControllerBase<LogReportController>.Instance.LogReport(roleDevLogEvent);
		}
	}

	// Token: 0x06014442 RID: 83010 RVA: 0x005A45C8 File Offset: 0x005A27C8
	public void LogRoleDevSubPageClick(int roleId, ERoleDevMainPage mainPage, ERoleDevSubPageButton subPage)
	{
		RoleDevLogEvent roleDevLogEvent = this.BuildRoleDevLogEvent(roleId, mainPage, subPage);
		if (roleDevLogEvent != null)
		{
			ControllerBase<LogReportController>.Instance.LogReport(roleDevLogEvent);
		}
	}
}
