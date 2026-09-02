using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.RoleUi;

// Token: 0x02002CAD RID: 11437
[NullableContext(2)]
[Nullable(0)]
public class UiRoleLoadComponent : UiModelLoadComponent
{
	// Token: 0x06016F2C RID: 93996 RVA: 0x0065C4AB File Offset: 0x0065A6AB
	protected override void OnInit()
	{
		base.OnInit();
		this.UiRoleDataComponent = base.Owner.CheckGetComponent<UiRoleDataComponent>();
		this.UiRoleMorphComponent = base.Owner.GetComponent<UiRoleMorphComponent>();
	}

	// Token: 0x06016F2D RID: 93997 RVA: 0x0065C4D5 File Offset: 0x0065A6D5
	protected override void OnEnd()
	{
		base.OnEnd();
	}

	// Token: 0x06016F2E RID: 93998 RVA: 0x0065C4E0 File Offset: 0x0065A6E0
	public unsafe void LoadModelByRoleDataId(int roleDataId, int roleSkinId, bool waitMeshStreaming = false, Action loadFinishCallBack = null)
	{
		if (roleDataId == this.UiRoleDataComponent.RoleDataId)
		{
			UiRoleDataComponent uiRoleDataComponent = this.UiRoleDataComponent;
			int? num = (uiRoleDataComponent != null) ? new int?(uiRoleDataComponent.RoleSkinId) : null;
			if (roleSkinId == num.GetValueOrDefault() & num != null)
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.Character;
				ELogAuthor author = ELogAuthor.LZK;
				string message = "重复加载角色";
				<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("RoleDataId", roleDataId);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("RoleSkinId", roleSkinId);
				instance.Error(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
				return;
			}
		}
		this.UiRoleDataComponent.SetRoleDataId(roleDataId, roleSkinId);
		this.LoadFinishCallBack = loadFinishCallBack;
		base.LoadModel(waitMeshStreaming, null, 0);
	}

	// Token: 0x06016F2F RID: 93999 RVA: 0x0065C5B0 File Offset: 0x0065A7B0
	public void LoadModelByRoleConfigId(int roleConfigId, int skinId, bool waitMeshStreaming = false, Action loadFinishCallBack = null)
	{
		if (roleConfigId == this.UiRoleDataComponent.RoleConfigId)
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.Character;
			ELogAuthor author = ELogAuthor.LZK;
			string message = "重复加载角色";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("RoleConfigId", roleConfigId);
			instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			return;
		}
		this.UiRoleDataComponent.SetRoleConfigId(roleConfigId, skinId);
		this.LoadFinishCallBack = loadFinishCallBack;
		base.LoadModel(waitMeshStreaming, null, 0);
	}

	// Token: 0x06016F30 RID: 94000 RVA: 0x0065C618 File Offset: 0x0065A818
	[NullableContext(1)]
	protected override string GetAnimClassPath()
	{
		if (this.UiRoleDataComponent.RoleSkinId <= 0)
		{
			return ConfigBase<RoleConfig>.Instance.GetRoleConfig(this.UiRoleDataComponent.RoleConfigId).Value.UiScenePerformanceABP;
		}
		return ModelBase<RoleSkinModel>.Instance.GetRoleSkinData(this.UiRoleDataComponent.RoleSkinId).GetRoleSkinConfig().UiScenePerformanceABP;
	}

	// Token: 0x06016F31 RID: 94001 RVA: 0x0065C67B File Offset: 0x0065A87B
	[return: Nullable(new byte[]
	{
		2,
		1
	})]
	protected override List<string> GetAllMorphPathList()
	{
		UiRoleMorphComponent uiRoleMorphComponent = this.UiRoleMorphComponent;
		if (uiRoleMorphComponent == null)
		{
			return null;
		}
		return uiRoleMorphComponent.GetAllMorphPathList();
	}

	// Token: 0x06016F32 RID: 94002 RVA: 0x0065C68E File Offset: 0x0065A88E
	protected override void FinishLoad()
	{
		base.FinishLoad();
		UiRoleMorphComponent uiRoleMorphComponent = this.UiRoleMorphComponent;
		if (uiRoleMorphComponent == null)
		{
			return;
		}
		uiRoleMorphComponent.PreloadMorphData();
	}

	// Token: 0x0400B0FE RID: 45310
	private UiRoleDataComponent UiRoleDataComponent;

	// Token: 0x0400B0FF RID: 45311
	private UiRoleMorphComponent UiRoleMorphComponent;
}
