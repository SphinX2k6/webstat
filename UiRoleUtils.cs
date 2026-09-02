using System;
using System.Runtime.CompilerServices;
using AkiClient.Game.Aki.Render.RuntimeBP.Character.MaterialController;
using CSharpScript.Game.Utils;

// Token: 0x02002C5B RID: 11355
[NullableContext(1)]
[Nullable(0)]
public class UiRoleUtils
{
	// Token: 0x06016C53 RID: 93267 RVA: 0x00650E08 File Offset: 0x0064F008
	public static void PlayRoleChangeEffect(TsUiSceneRoleActor roleActor)
	{
		if (roleActor == null)
		{
			Singleton<Log>.Instance.Error(ELogModule.Role, ELogAuthor.TL, "PlayRoleChangeEffect roleActor is null", default(ReadOnlySpan<ValueTuple<string, object>>));
			return;
		}
		UiModelBase model = roleActor.Model;
		if (model == null)
		{
			return;
		}
		UiModelRenderingMaterialComponent uiModelRenderingMaterialComponent = model.CheckGetComponent<UiModelRenderingMaterialComponent>();
		string effectPath = EffectUtil.GetEffectPath("ChangeRoleMaterialController");
		PD_CharacterControllerData_C loadedAsset = Singleton<ResourceSystem>.Instance.GetLoadedAsset<PD_CharacterControllerData_C>(effectPath);
		if (loadedAsset != null && uiModelRenderingMaterialComponent != null)
		{
			uiModelRenderingMaterialComponent.AddRenderingMaterialByData(loadedAsset);
		}
		Singleton<UiModelUtil>.Instance.PlayEffectOnRoot(model, "ChangeRoleEffect");
	}

	// Token: 0x06016C54 RID: 93268 RVA: 0x00650E80 File Offset: 0x0064F080
	public static void PlayRoleLevelUpEffect(TsUiSceneRoleActor roleActor)
	{
		if (roleActor == null)
		{
			Singleton<Log>.Instance.Error(ELogModule.Role, ELogAuthor.TL, "PlayRoleLevelUpEffect roleActor is null", default(ReadOnlySpan<ValueTuple<string, object>>));
			return;
		}
		UiModelBase model = roleActor.Model;
		Singleton<UiModelUtil>.Instance.SetRenderingMaterial(model, "RoleLevelUpMaterialController");
		Singleton<UiModelUtil>.Instance.PlayEffectOnRoot(model, "RoleLevelUpEffect");
	}

	// Token: 0x06016C55 RID: 93269 RVA: 0x00650ED8 File Offset: 0x0064F0D8
	public static void PlayRoleBreachFinishEffect(TsUiSceneRoleActor roleActor)
	{
		if (roleActor == null)
		{
			Singleton<Log>.Instance.Error(ELogModule.Role, ELogAuthor.TL, "PlayRoleBreachFinishEffect roleActor is null", default(ReadOnlySpan<ValueTuple<string, object>>));
			return;
		}
		UiModelBase model = roleActor.Model;
		Singleton<UiModelUtil>.Instance.SetRenderingMaterial(model, "RoleBreachFinishMaterialController");
		Singleton<UiModelUtil>.Instance.PlayEffectOnRoot(model, "RoleBreachFinishEffect");
	}
}
